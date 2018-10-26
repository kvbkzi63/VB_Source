'/*
'*****************************************************************************
'*
'*    Page/Class Name:  需求管理紀錄
'*              Title:	JobServiceRecordBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-07-28
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-07-28
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Project.Comm.JOB
Imports Syscom.Server.FTM
Imports System.IO

Public Class JobServiceRecordBO_E1
    Inherits JobServiceRecordBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobServiceRecordBO_E1
    Public Overloads Shared Function GetInstance() As JobServiceRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobServiceRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

    Public Function CreateNewIssueRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As New DataSet
            retDS.Tables.Add(New DataTable("Result"))
            retDS.Tables(0).Columns.Add("Result")
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim MaxSeq As Int32 = QueryMaxSeqNumber(conn)
            For Each dr As DataRow In ds.Tables(0).Rows
                dr("Issue_Id") = MaxSeq
                MaxSeq += 1
            Next

            retDS.Tables(0).Rows.Add(insert(ds, conn))

            If retDS.Tables(0).Rows(0).Item(0) > 0 Then
                '轉SA/SD處理 需發MAIL
                If ds.Tables(0).Rows(0).Item("Issue_Status").ToString.Equals("2") Then
                    SendMailToProcessingEmployee(ds, conn)
                End If

                Return retDS
            Else
                Throw New Exception
            End If
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


#Region "     發送Mail給處理人員"

    Private Function SendMailToProcessingEmployee(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Boolean
        Dim ret As Boolean = True
        Dim connFlag As Boolean = conn Is Nothing

        Try

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim FID As String = ds.Tables(0).Rows(0).Item("ATT_FID").ToString.Trim

            If FID.Length > 0 Then
                Dim client = FTMDelegate.getInstance

                'Step.1 下載檔案
                Dim obj As Object = client.downloadFile(FID)
                'Step.3 取得檔案副檔名
                Dim DataType As String = FID.Split(".")(1)
                '(0) 檔案資料byte() , (1) client端的預設檔名
                '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                SendMail.getInstance.SendMail(GetEmailByEmployeeCode(ds.Tables(0).Rows(0).Item("Processing_Employee_Code").ToString.Trim, conn), "",
                                              GetMailSubject(ds.Tables(0).Rows(0).Item("Issue_Id").ToString.Trim, conn),
                                              GetMailContent(ds, conn), New MemoryStream(CType(obj(0), Byte())), "需求紀錄附件檔.zip", True)
            Else
                SendMail.getInstance.SendMail(GetEmailByEmployeeCode(ds.Tables(0).Rows(0).Item("Processing_Employee_Code").ToString.Trim, conn),
                                              GetMailSubject(ds.Tables(0).Rows(0).Item("Issue_Id").ToString.Trim, conn),
                                              GetMailContent(ds, conn), True)
            End If


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"發送Mail給處理人員"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
        Return False
    End Function


#End Region

#End Region

#Region "     修改 Method "
#Region " 更新問題紀錄單 "

    ''' <summary>
    ''' 更新問題紀錄單
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-11-28</remarks>
    Public Function ModifyIssueRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        Try
            retDS.Tables.Add(New DataTable("Result"))
            retDS.Tables(0).Columns.Add("cnt")
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            retDS.Tables(0).Rows.Add(update(ds, conn))

            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     刪除 Method "
#Region " 作廢需求單 "

    ''' <summary>
    ''' 作廢需求單
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Will.Lin on 2017-09-08</remarks>
    Public Function CancelServiceRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update JOB_Service_Record")
            Content.AppendLine("   Set Cancel='Y',Cancel_Reason=@Cancel_Reason,Cancel_Time=getdate(),Cancel_User=@Cancel_User")
            Content.AppendLine("Where Issue_Id=@Issue_Id")
            Content.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                    command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                    command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)
            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"作廢需求單"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     查詢 Method "

#Region " 匯出Service紀錄 "

    ''' <summary>
    ''' 匯出Service紀錄
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2017-11-15</remarks>
    Public Function QueryServiceRecordForExportReport(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT")
            Content.AppendLine("      RTRIM(A.Job_Code)  as  '派工單號' ,")
            Content.AppendLine("      RTRIM(H.Project_Name)  as  '所屬專案' ,")
            Content.AppendLine("      RTRIM(Hospital_Short_Name)  as  '醫院別' ,")
            Content.AppendLine("      Receive_DateTime  as  '提出日期時間' ,")
            Content.AppendLine("      RTRIM(F.Code_Name)  as  '來源' ,")
            Content.AppendLine("      Contact_User  as  '提出單位/使用者' ,")
            Content.AppendLine("      RTRIM(Contact_Note)  as  '分機/mail' ,")
            Content.AppendLine("      RTRIM(Issue_Description)  as  '問題敘述' ,")
            Content.AppendLine("      E.Code_Name  as  '問題分類' ,")
            Content.AppendLine("      G.System_Name  as  '作業點' ,")
            Content.AppendLine("      RTRIM(Processing_Approach)  as  '問題回覆 / 處理過程' ,")
            Content.AppendLine("      Employee_Name  as  '處理人員' ,")
            Content.AppendLine("      RTRIM( Processing_Cost)  as  '處理工時(hr)' ,")
            Content.AppendLine("               case ")
            Content.AppendLine("    when Finish_Date is NULL and Issue_Status in ('1','5') then Estimated_Finish_Date ")
            Content.AppendLine("    else Finish_Date end as  '完成日' ,")
            Content.AppendLine("      RTRIM(D.Code_Name)  as  '狀態' ,")
            Content.AppendLine("      RTRIM(Note)  as  '備註' ")
            Content.AppendLine("  FROM JOB_Service_Record  as A")
            Content.AppendLine("    INNER JOIN PUB_Hospital as B ON A.Hospital_Code=B.Hospital_Code")
            Content.AppendLine("    INNER JOIN PUB_Employee as C ON A.Processing_Employee_Code=C.Employee_Code")
            Content.AppendLine("    INNER JOIN PUB_Syscode as D ON A.Issue_Status=D.Code_Id and D.Type_Id='9998'")
            Content.AppendLine("    INNER JOIN PUB_Syscode as E ON A.Issue_Classify=E.Code_Id and E.Type_Id='9999'")
            Content.AppendLine("    INNER JOIN PUB_Syscode as F ON A.Issue_Source=F.Code_Id and F.Type_Id='9997'")
            Content.AppendLine("    INNER JOIN PRJ_Project as H ON H.Project_Id=@Project_Id")
            Content.AppendLine("    INNER JOIN PRJ_Project_System as G ON G.Project_Id=@Project_Id And A.System_Code=G.System_Code")
            Content.AppendLine("   WHERE A.Project_Id =@Project_Id")
            Content.AppendLine("                  AND A.Cancel is NULL")
            Content.AppendLine("ORDER BY Receive_DateTime")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Project_Id", input.Tables(0).Rows(0).Item("Project_Id"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#Region " 查詢需求紀錄列表 "

    ''' <summary>
    ''' 查詢需求紀錄列表
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-07-28</remarks>
    Public Function QueryServiceRecordList(ByVal inputDS As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim JobCode As String = inputDS.Tables(0).Rows(0).Item("Job_Code").ToString.Trim
            Dim ProjectID As String = inputDS.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            Dim SystemCode As String = inputDS.Tables(0).Rows(0).Item("System_Code").ToString.Trim
            Dim FunctionCode As String = inputDS.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
            Dim IssueStatus As String = inputDS.Tables(0).Rows(0).Item("Issue_Status").ToString.Trim
            Dim SDate As String = inputDS.Tables(0).Rows(0).Item("SDate").ToString.Trim
            Dim EDate As String = inputDS.Tables(0).Rows(0).Item("EDate").ToString.Trim
            Dim Hospital_Code As String = inputDS.Tables(0).Rows(0).Item("Hospital_Code").ToString.Trim
            Dim Processing_Employee_Code As String = inputDS.Tables(0).Rows(0).Item("Processing_Employee_Code").ToString.Trim
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Isnull(RTRIM(JSR.Job_Code),'') Job_Code")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Project_Id),'') Project_Id")
            Content.AppendLine("      ,Isnull(RTRIM(PP.Project_Name),'') Project_Name")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Code]) Hospital_Code")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Short_Name]) Hospital_Short_Name")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.System_Code),'') System_Code")
            Content.AppendLine("      ,Isnull(RTRIM(PPS.System_Name),'') System_Name")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Function_Code),'') Function_Code")
            Content.AppendLine("      ,Isnull(RTRIM(PPSF.Function_Name),'') Function_Name")
            Content.AppendLine("      ,JSR.Receive_DateTime")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Issue_Source),'') Issue_Source")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Issue_Classify),'') Issue_Classify")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Issue_Status),'') Issue_Status")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Contact_User),'') Contact_User")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Contact_Way),'') Contact_Way")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Contact_Note),'') Contact_Note")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Processing_Approach),'') Processing_Approach")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Processing_Employee_Code),'') Processing_Employee_Code")
            Content.AppendLine("      ,Isnull(RTRIM(PE.Employee_Name),'') Processing_Employee_Name")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Processing_Cost),'') Processing_Cost")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Finish_Date),'') Finish_Date")
            Content.AppendLine("      ,JSR.Estimated_Finish_Date")
            Content.AppendLine("      ,JSR.Issue_Description")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Note),'') Note")
            Content.AppendLine("      ,Isnull(RTRIM(PE1.Employee_Name),'') SA")
            Content.AppendLine("      ,Isnull(RTRIM(PE2.Employee_Name),'') SD")
            Content.AppendLine("      ,Isnull(RTRIM(PE3.Employee_Name),'') PG")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Issue_Id),'') Issue_Id")
            Content.AppendLine("      ,Isnull(RTRIM(JSR.Create_User),'') Create_User")
            Content.AppendLine("  FROM JOB_Service_Record JSR")
            Content.AppendLine("Inner Join PRJ_Project PP on PP.Project_Id=JSR.Project_Id")
            Content.AppendLine("Inner Join PRJ_Project_System PPS on PP.Project_Id=PPS.Project_Id And PPS.System_Code=JSR.System_Code")
            Content.AppendLine("Inner Join PRJ_Project_System_Function PPSF on PPSF.Project_Id=JSR.Project_Id And PPSF.System_Code=JSR.System_Code  And PPSF.Function_Code=JSR.Function_Code")
            Content.AppendLine("Inner Join PUB_Employee PE on PE.Employee_Code=JSR.Processing_Employee_Code  ")
            Content.AppendLine("Left Join PUB_Hospital PH On PH.Hospital_Code =JSR.Hospital_Code")
            Content.AppendLine("Left Join JOB_SA_Assign_Record JSAR On JSAR.Job_Code =JSR.Job_Code")
            Content.AppendLine("Left Join PUB_Employee PE1 On JSAR.Create_User =PE1.Employee_Code") 'SA
            Content.AppendLine("Left Join PUB_Employee PE2 On JSAR.SD_Employee_Code =PE2.Employee_Code") 'SD
            Content.AppendLine("Left Join PUB_Employee PE3 On JSAR.PG_Employee_Code =PE3.Employee_Code") 'PG

            Content.AppendLine("Where 1=1")
            Content.AppendLine("")

            Content.AppendLine("")
            If ProjectID <> "" Then
                Content.AppendLine(" And JSR.Project_Id=@Project_Id")
            End If

            If SystemCode <> "" Then
                Content.AppendLine(" And JSR.System_Code=@System_Code")
            End If
            If FunctionCode <> "" Then
                Content.AppendLine(" And JSR.Function_Code=@Function_Code")
            End If

            If IssueStatus <> "" Then
                Content.AppendLine(" And JSR.Issue_Status=@Issue_Status")
            End If
            If SDate <> "" AndAlso EDate <> "" Then
                Content.AppendLine(" And  JSR.Receive_DateTime between @SDate And  @EDate")
            ElseIf SDate <> "" AndAlso EDate = "" Then
                Content.AppendLine(" And  JSR.Receive_DateTime >= @SDate  ")
            ElseIf SDate = "" AndAlso EDate <> "" Then
                Content.AppendLine(" And  JSR.Receive_DateTime <= @EDate  ")
            End If
            If Hospital_Code <> "" Then
                Content.AppendLine(" And JSR.Hospital_Code=@Hospital_Code")
            End If
            If Processing_Employee_Code <> "" Then
                Content.AppendLine(" And JSR.Processing_Employee_Code=@Processing_Employee_Code")
            End If
            If JobCode <> "" Then
                Content.AppendLine(" And JSR.JOB_Code=@Job_Code")
            End If
            Content.AppendLine(" And  JSR.Cancel Is Null ")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            If ProjectID <> "" Then
                command.Parameters.AddWithValue("@Project_Id", ProjectID)
            End If
            If SystemCode <> "" Then
                command.Parameters.AddWithValue("@System_Code", SystemCode)
            End If

            If FunctionCode <> "" Then
                command.Parameters.AddWithValue("@Function_Code", FunctionCode)
            End If

            If IssueStatus <> "" Then
                command.Parameters.AddWithValue("@Issue_Status", IssueStatus)
            End If

            If Hospital_Code <> "" Then
                command.Parameters.AddWithValue("@Hospital_Code", Hospital_Code)
            End If

            If Processing_Employee_Code <> "" Then
                command.Parameters.AddWithValue("@Processing_Employee_Code", Processing_Employee_Code)
            End If

            If SDate <> "" Then
                command.Parameters.AddWithValue("@SDate", SDate)
            End If
            If EDate <> "" Then
                command.Parameters.AddWithValue("@EDate", EDate)
            End If
            If JobCode <> "" Then
                command.Parameters.AddWithValue("@Job_Code", JobCode)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


#End Region


#Region " 查詢流水號最大碼 "

    ''' <summary>
    ''' 查詢流水號最大碼
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-07-28</remarks>
    Public Function QueryMaxSeqNumber(Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select Count(1)+1 FROM JOB_Service_Record "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return CInt(ds.Tables(0).Rows(0).Item(0))

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢流水號最大碼"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region "     查詢取得處理人員的EMail"
    Private Function GetEmailByEmployeeCode(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select EMail From PUB_Employee Where Employee_Code=@EmployeeCode"

            command.Parameters.AddWithValue("@EmployeeCode", EmployeeCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("EMail")
                adapter.Fill(ds, "EMail")
            End Using

            Return ds.Tables(0).Rows(0).Item("EMail").ToString.Trim

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

    Private Function GetNameByEmployeeCode(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Employee_En_Name From PUB_Employee Where Employee_Code=@EmployeeCode"

            command.Parameters.AddWithValue("@EmployeeCode", EmployeeCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("EMail")
                adapter.Fill(ds, "EMail")
            End Using

            Return ds.Tables(0).Rows(0).Item("EMail").ToString.Trim

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

#End Region

#Region "     取得郵件標題"
    Public Function GetMailSubject(ByVal Issue_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String


        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("Select  '[Service]-' AS 來源")
            Content.AppendLine("       ,'[' + RTRIM(PS.Code_En_Name) + ']-' AS 需求類別")
            Content.AppendLine("       ,'[' + RTRIM(PP.Project_Name) + ']-' AS 專案名稱")
            Content.AppendLine("       ,'[' + RTRIM(PPS.System_Name) + ']-' AS 系統別")
            Content.AppendLine("       ,'[' + RTRIM(PPSF.Function_Name) + ']-' AS 所屬功能")
            Content.AppendLine("       ,'需求紀錄單(編號-").Append(Issue_Id).Append(")' AS 流水號")
            Content.AppendLine("  From JOB_Service_Record JSR")
            Content.AppendLine("Inner Join PUB_Syscode PS on PS.Type_Id='9999' and JSR.Issue_Classify =PS.Code_Id")
            Content.AppendLine("Inner Join  PRJ_Project PP on PP.Project_ID= JSR.Project_ID")
            Content.AppendLine("Inner Join  PRJ_Project_System PPS on PPS.Project_ID= JSR.Project_ID And PPS.System_Code=JSR.System_Code")
            Content.AppendLine("Inner Join  PRJ_Project_System_Function PPSF on PPSF.Project_ID= JSR.Project_ID And PPSF.System_Code=JSR.System_Code And PPSF.Function_Code=JSR.Function_Code")
            Content.AppendLine("Where 1=1")
            Content.AppendLine("  And JSR.Issue_Id=@Issue_Id")
            Content.AppendLine("")



            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Issue_Id", Issue_Id)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PRJ_Project")
                adapter.Fill(ds, "PRJ_Project")
            End Using

            Dim MailSubject As String = ""
            For Each c As DataColumn In ds.Tables(0).Columns
                MailSubject &= ds.Tables(0).Rows(0).Item(c.ColumnName).ToString.Trim
            Next


            Return MailSubject

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try



    End Function


#End Region

#Region "     取得郵件標題"
    Public Function GetMailContent(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String


        Dim connFlag As Boolean = conn Is Nothing

        Try

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim MainData As DataSet = QueryMailContent(ds.Tables(0).Rows(0).Item("Issue_Id").ToString.Trim, conn)
            Dim SDEmployeeName As String = MainData.Tables(0).Rows(0).Item("SD_Name").ToString.Trim
            Dim CreateEmployeeName As String = MainData.Tables(0).Rows(0).Item("Create_User").ToString.Trim
            Dim ProjectName As String = MainData.Tables(0).Rows(0).Item("Project_Name").ToString.Trim
            Dim SystemName As String = MainData.Tables(0).Rows(0).Item("System_Name").ToString.Trim
            Dim FunctionName As String = MainData.Tables(0).Rows(0).Item("Function_Name").ToString.Trim
            Dim IssueClassify As String = MainData.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim
            Dim IssueDescription As String = MainData.Tables(0).Rows(0).Item("Issue_Description").ToString.Trim
            Dim ContactNote As String = MainData.Tables(0).Rows(0).Item("Contact_Note").ToString.Trim
            Dim ContactWay As String = MainData.Tables(0).Rows(0).Item("Contact_Way").ToString.Trim
            Dim ContactUser As String = MainData.Tables(0).Rows(0).Item("Contact_User").ToString.Trim
            Dim EstimatedFinishDate As String = MainData.Tables(0).Rows(0).Item("Estimated_Finish_Date").ToString.Trim
            Dim SourceWay As String = MainData.Tables(0).Rows(0).Item("Source").ToString.Trim
            Dim ReceiveDateTime As String = MainData.Tables(0).Rows(0).Item("Receive_DateTime").ToString.Trim
            Dim Note As String = MainData.Tables(0).Rows(0).Item("Note").ToString.Trim

            Dim Content As New StringBuilder
            Content.AppendLine("<p>")
            Content.AppendLine("	<span style=""font-size:16px;"">Dear ").Append(SDEmployeeName).Append(":</span></p>")
            Content.AppendLine("<p>")
            Content.AppendLine("	<span style=""font-size:16px;"">請協助處理此需求</span></p>")
            Content.AppendLine("<table border=""2"" cellpadding=""1"" cellspacing=""3"" style=""width: 500px"">")
            Content.AppendLine("	<tbody>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">所屬專案</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;""><span style=""background-color:yellow;"">").Append(ProjectName).Append("</span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">系統別</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(SystemName).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">提出日期</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(ReceiveDateTime).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">來源</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(SourceWay).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">預期完成日</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(EstimatedFinishDate).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">提出單位/人員</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(ContactUser).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">聯絡方式</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(ContactWay).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">電話/傳真/郵件</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(ContactNote).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">問題敘述</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(IssueDescription).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">問題分類</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(IssueClassify).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">功能名稱</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;""><span style=""background-color:lime;"">").Append(FunctionName).Append("</span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">備註</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(Note).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""row"" style=""text-align: right;"">")
            Content.AppendLine("				<span style=""font-size:16px;"">記錄人員</span></th>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style=""font-size:16px;"">").Append(CreateEmployeeName).Append("</span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th colspan=""2"" scope=""row"" style=""text-align: center;"">")
            Content.AppendLine("				<span style=""font-size:16px;""><span style=""color:#ff0000;"">請進行派工，若處理完畢請至【需求管理系統】進行需求結案</span></span></th>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("	</tbody>")
            Content.AppendLine("</table>")
            Content.AppendLine("<p>")
            Content.AppendLine("	&nbsp;</p>")
            Content.AppendLine("<p>")
            Content.AppendLine("	&nbsp;</p>")
            Content.AppendLine("<p>")
            Content.AppendLine("	&nbsp;</p>")



            Return Content.ToString

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得郵件內容"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try



    End Function

#Region " 取得郵件需要資料 "

    ''' <summary>
    ''' 取得郵件需要資料
    ''' </summary>
    ''' <param name="Issue_Id" >流水號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-07-28</remarks>
    Public Function QueryMailContent(ByVal Issue_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine(" ")
            Content.AppendLine("SELECT Isnull(RTRIM(PP.Project_Name),'') Project_Name  ")
            Content.AppendLine("	  ,Isnull(RTRIM(PPS.System_Name),'')  + '-'+ Isnull(RTRIM(PPS.System_Code),'') System_Name       ")
            Content.AppendLine("	  ,Isnull(RTRIM(PPSF.Function_Name),'') + '-'+ Isnull(RTRIM(PPSF.Function_Code),'') Function_Name    ")
            Content.AppendLine("	  ,Isnull(RTRIM(PPSD.Employee_En_Name),'') SD_Name    ")
            Content.AppendLine("	  ,Isnull(RTRIM(PPSD.Employee_En_Name),'') Create_User   ")
            Content.AppendLine("	  ,CONVERT(char,JSR.Receive_DateTime,120) Receive_DateTime")
            Content.AppendLine("	  ,IssueSource.Code_Name 'Source'")
            Content.AppendLine("	  ,Issue_Status.Code_Name 'Issue_Status'")
            Content.AppendLine("	  ,JSR.Contact_User")
            Content.AppendLine("	  ,Contact_Way.Code_Name 'Contact_Way'")
            Content.AppendLine("	  ,JSR.Contact_Note")
            Content.AppendLine("	  ,JSR.Issue_Description")
            Content.AppendLine("	  ,JSR.Note")
            Content.AppendLine("	  ,JSR.Estimated_Finish_Date")
            Content.AppendLine("	  ,IssueClassify.Code_Name Issue_Classify")
            Content.AppendLine("  FROM JOB_Service_Record JSR")
            Content.AppendLine("Inner Join PRJ_Project PP On PP.Project_ID=JSR.Project_ID")
            Content.AppendLine("Inner Join PRJ_Project_System PPS On PPS.Project_ID=JSR.Project_ID And PPS.System_Code=JSR.System_Code")
            Content.AppendLine("Inner Join PRJ_Project_System_Function PPSF On PPSF.Project_ID=JSR.Project_ID And PPSF.System_Code=JSR.System_Code And PPSF.Function_Code=JSR.Function_Code")
            Content.AppendLine("Inner Join PUB_Employee PPSD On PPSD.Employee_Code=JSR.Processing_Employee_Code ")
            Content.AppendLine("Inner Join PUB_Employee PPCreateUser On PPCreateUser.Employee_Code=JSR.Create_User ")
            Content.AppendLine("Inner Join PUB_Syscode IssueSource On IssueSource.Type_Id='9997' And IssueSource.Code_Id=JSR.Issue_Source")
            Content.AppendLine("Inner Join PUB_Syscode Issue_Status On Issue_Status.Type_Id='9998' And Issue_Status.Code_Id=JSR.Issue_Status")
            Content.AppendLine(" Left Join PUB_Syscode Contact_Way On Contact_Way.Type_Id='9997' And Contact_Way.Code_Id=JSR.Contact_Way")
            Content.AppendLine("Inner Join PUB_Syscode IssueClassify On IssueClassify.Type_Id='9999' And IssueClassify.Code_Id=JSR.Issue_Classify")
            Content.AppendLine("Where Issue_Id=@Issue_Id")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Issue_Id", Issue_Id)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#End Region
#End Region

End Class

