Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Project.Comm.JOB
Imports Syscom.Server.FTM
Imports Syscom.Comm.Utility
Imports System.IO
Imports System.Windows.Forms
Imports Syscom.Server.SQL
Imports System.Transactions
Imports Syscom.Server.CMM
Imports Syscom.Server.SNC

Public Class JobSAAssignRecordBO_E1
    Inherits JobSaAssignRecordBO
#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobSAAssignRecordBO_E1
    Public Overloads Shared Function GetInstance() As JobSAAssignRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobSAAssignRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

    Dim pt As New JobSaAssignRecordDataTableFactory.JOBSAAssignRecordPt


#Region " UI初始化 "

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function initialSAAssignJobUI(ByVal Employee As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As DataSet

        Try

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT RTRIM(Project_ID) Project_ID,Project_Name,Project_Status  ")
            Content.AppendLine("  FROM PRJ_Project Where End_Date is null Order By Project_Name;")
            Content.AppendLine("SELECT RTRIM(System_Code) System_Code, RTRIM(System_Name) System_Name,Project_ID  FROM PRJ_Project_System ;")
            Content.AppendLine("SELECT RTRIM(Function_Code) Function_Code, RTRIM(Function_Name) Function_Name,System_Code,Project_ID  FROM PRJ_Project_System_Function Where ISNULL(DC,'Y') <> 'N';")
            Content.AppendLine("SELECT RTRIM(Employee_Code) Employee_Code,RTRIM(Employee_Name) Employee_Name,Email")
            Content.AppendLine("  FROM PUB_Employee")
            Content.AppendLine("Where Nrs_Level_Id='1' ")
            Content.AppendLine("  And Assume_End_Date is null")
            Content.AppendLine("union all")
            Content.AppendLine("SELECT RTRIM(Employee_Code) Employee_Code,'(離職)' + RTRIM(Employee_Name) Employee_Name,Email")
            Content.AppendLine("  FROM PUB_Employee")
            Content.AppendLine("Where Nrs_Level_Id='1' ")
            Content.AppendLine("  And Assume_End_Date is not null;")
            Content.AppendLine("SELECT RTRIM(Employee_Code) Employee_Code,RTRIM(Employee_Name) Employee_Name,Email")
            Content.AppendLine("  FROM PUB_Employee")
            Content.AppendLine("Where Nrs_Level_Id='2' ")
            Content.AppendLine("  and Assume_End_Date is null")
            Content.AppendLine("Order By Employee_En_Name")
            Content.AppendLine("Select *") '------------MailGroup
            Content.AppendLine("  From PRJ_Mail_Group")
            Content.AppendLine(" Where Belong_Employee_Code=@Employee And isnull(Temporary,'N')='N'")
            Content.AppendLine("SELECT RTRIM(Employee_Code) Employee_Code,RTRIM(Employee_Name) Employee_Name,Email") '------------SDList
            Content.AppendLine("  FROM PUB_Employee")
            Content.AppendLine("Where Nrs_Level_Id='3'")
            Content.AppendLine("  and Assume_End_Date is null")
            Content.AppendLine("Order By Employee_En_Name")
            Content.AppendLine("SELECT Hospital_Code,") '------------HospList
            Content.AppendLine("	   Hospital_Short_Name")
            Content.AppendLine("  FROM PUB_Hospital")
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Employee", Employee)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet()
                adapter.Fill(retDS)
            End Using
            retDS.Tables(0).TableName = "Project"
            retDS.Tables(1).TableName = "System"
            retDS.Tables(2).TableName = "Function"
            retDS.Tables(3).TableName = "PGList"
            retDS.Tables(4).TableName = "SAList"
            retDS.Tables(5).TableName = "MailGroup"
            retDS.Tables(6).TableName = "SDList"
            retDS.Tables(7).TableName = "HospList"
            Return retDS


        Catch sqlex As SqlException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", cmex)
            Throw cmex
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function InitialSAReplyDialogUI(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As DataSet
        Dim JOB_Code As String = ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim
        Try

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT TOP 1 JOB_Code")
            Content.AppendLine("      ,Reply_Seq")
            Content.AppendLine("      ,Reply_Note")
            Content.AppendLine("      ,FID")
            Content.AppendLine("      ,SA_Reply_ATT_FID")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("  FROM JOB_SA_Reject_Record")
            Content.AppendLine("  Where Job_Code=@JOB_Code")
            Content.AppendLine("Order By Reply_Seq DESC")



            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet("JOB_SA_Reject_Record")
                adapter.Fill(retDS, "JOB_SA_Reject_Record")
            End Using

            Return retDS


        Catch sqlex As SqlException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", cmex)
            Throw cmex
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("", ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region "     新增"

    ''' <summary>
    ''' 新增派工紀錄
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function AssignNewJOB(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        retDS.Tables(0).Columns.Add("Job_Code")
        Try
#If DEBUG Then
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
#End If

            Dim count As Integer = 0
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If
            Dim IssueID As String() = ds.Tables(0).Rows(0).Item("Issue_Id").ToString.Trim.Split(",")
            Dim jobID As String = Now.ToString("yyyyMMdd") & StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeA, "JobAssign", 0, 99999), CChar("0"), 5)

            If Not IsDate(ds.Tables(0).Rows(0).Item("Issue_Deadline")) Then
                ds.Tables(0).Rows(0).Item("Issue_Deadline") = DBNull.Value
            End If
            If Not IsDate(ds.Tables(0).Rows(0).Item("SD_Issue_Deadline")) Then
                ds.Tables(0).Rows(0).Item("SD_Issue_Deadline") = DBNull.Value
            End If
            ds.Tables(0).Rows(0).Item("Job_Code") = jobID.ToString
            Dim cnt As Integer = insert(ds, conn)
            Dim CCUser As String = ds.Tables(0).Rows(0).Item("CCUser").ToString.Trim

            If CCUser.Length = 0 Then
                CCUser = JobMailGroupBO_E1.GetInstance.GetMailAddressFromGroup(jobID.ToString, conn)
            End If

            '更新需求單狀態
            For Each Id In IssueID
                If Id.Equals("") Then Continue For
                cnt += UpdateIssueRecordForNewJob(jobID.ToString, ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim, Id, ds.Tables(0).Rows(0).Item("Assign_Source").ToString.Trim, conn)
            Next

            If cnt > 0 Then

                Select Case ds.Tables(0).Rows(0).Item("Target").ToString.Trim
                    Case "PG"
                        If ds.Tables(0).Rows(0).Item("Assign_Source").ToString.Trim.Equals("2") Then
                            retDS.Tables(0).Rows.Add(AssignJobToPG(ds, jobID.ToString, CCUser, conn), jobID.ToString)
                        Else
                            retDS = SDConfirmJOB(ds, conn)
                        End If
                    Case "SA", "SD"
                        retDS.Tables(0).Rows.Add(AssignJobToSAorSD(ds, jobID.ToString, CCUser, conn), jobID.ToString)
                End Select

            End If
            Dim UpdateStatusDS As New DataSet
            UpdateStatusDS.Tables.Add(New DataTable("Action"))
            UpdateStatusDS.Tables(0).Columns.Add("Action")
            UpdateStatusDS.Tables(0).Columns.Add("JOB_Code")
            UpdateStatusDS.Tables(0).Columns.Add("Status")
            UpdateStatusDS.Tables(0).Columns.Add("Create_User")
            UpdateStatusDS.Tables(0).Rows.Add("UpdateJOBStatus", jobID.ToString, "0", ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim)
            JobPGJobBO_E1.GetInstance.UpdateJobStatus(UpdateStatusDS, conn)
#If DEBUG Then
                scope.Complete()
            End Using
#End If

            Return retDS
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' SD確認
    ''' </summary>
    ''' <returns></returns>

    Public Function SDConfirmJOB(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Dim scope As TransactionScope = Nothing


        Try
            If connFlag Then
                conn = GetConnection()
                conn.Open()
#If DEBUG Then
                scope = SQLConnFactory.getInstance.getRequiredTransactionScope
#End If
            End If
            Dim JobID As String = ds.Tables(0).Rows(0).Item("Job_Code").ToString.Trim
            Dim CCUser As String = JobMailGroupBO_E1.GetInstance.GetMailAddressFromGroup(JobID, conn)
            If Not IsDate(ds.Tables(0).Rows(0).Item("SD_Issue_Deadline")) Then
                ds.Tables(0).Rows(0).Item("SD_Issue_Deadline") = ds.Tables(0).Rows(0).Item("Issue_Deadline")
            End If
            If UpdateSDConfirm(ds, conn) > 0 Then
                Dim message As StringBuilder = GetMailStringForPG(JobID, ds, "3", conn)
                Dim mailTitle As New StringBuilder
                '信件標題
                mailTitle.Append(GetMailSubject(JobID, conn))
                Dim client = FTMDelegate.getInstance
                Dim FID As String = ""
                '暫時性作法，後續慢慢改為寫入歷程檔
                If CheckMethodUtil.CheckHasTable(ds, JobSaSpecfilesDataTableFactory.tableName) AndAlso CheckMethodUtil.CheckHasValue(ds.Tables(JobSaSpecfilesDataTableFactory.tableName)) Then
                    FID = ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.FID).ToString.Trim
                    ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.JOB_Code) = JobID
                    Dim FilesDS As New DataSet
                    FilesDS.Tables.Add(ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Copy)
                    Dim cnt As Integer = JobSaSpecfilesBO.GetInstance.insert(FilesDS, conn)
                Else
                    FID = ds.Tables(0).Rows(0).Item("FID").ToString.Trim
                End If
                'SA發的派工 覆核完要回信
                If ds.Tables(0).Columns.Contains("Assign_Source") AndAlso ds.Tables(0).Rows(0).Item("Assign_Source").ToString.Trim.Equals("3") Then
                    CCUser &= ";" & GetEmailByColumnName(JobID.ToString, pt.Create_User, conn)
                    CCUser &= ";" & GetEmailByColumnName(JobID.ToString, pt.SD_Employee_Code, conn)
                End If

                If FID.Length > 0 Then
                    'Step.1 下載檔案
                    Dim obj As Object = client.downloadFile(FID, False, conn)
                    'Step.3 取得檔案副檔名
                    Dim DataType As String = FID.Split(".")(1)
                    '(0) 檔案資料byte() , (1) client端的預設檔名
                    '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                    FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                    SendMail.getInstance.SendMail(GetEmailByColumnName(JobID.ToString, pt.PG_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1), True)
                Else
                    SendMail.getInstance.SendMail(GetEmailByColumnName(JobID.ToString, pt.PG_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, True)

                End If
            End If
            If scope IsNot Nothing Then
                scope.Complete()
                scope.Dispose()
            End If

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
                scope = Nothing
            End If

        End Try

        retDS.Tables(0).Rows.Add("1")
        Return retDS
    End Function

    ''' <summary>
    ''' 派送工作到PG
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="jobID"></param>
    ''' <param name="CCUser"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function AssignJobToPG(ByVal ds As DataSet, ByVal jobID As String, ByVal CCUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim cnt As Integer = 0
            Dim message As StringBuilder = GetMailStringForPG(jobID.ToString, ds, Source.SA, conn)
            Dim mailTitle As New StringBuilder
            '信件標題
            mailTitle.Append(GetMailSubject(jobID.ToString, conn))
            Dim client = FTMDelegate.getInstance
            Dim FID As String = ""

            If CheckMethodUtil.CheckHasValue(ds.Tables(JobSaSpecfilesDataTableFactory.tableName)) Then
                FID = ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.FID).ToString.Trim
                ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.JOB_Code) = jobID
                Dim FilesDS As New DataSet
                FilesDS.Tables.Add(ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Copy)
                cnt += JobSaSpecfilesBO.GetInstance.insert(FilesDS, conn)
            End If

            If FID.Length > 0 Then
                'Step.1 下載檔案
                Dim obj As Object = client.downloadFile(FID, False, conn)
                'Step.3 取得檔案副檔名
                Dim DataType As String = FID.Split(".")(1)
                '(0) 檔案資料byte() , (1) client端的預設檔名
                '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                cnt += SendMail.getInstance.SendMail(GetEmailByColumnName(jobID.ToString, pt.SD_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1), True)
            Else
                cnt += SendMail.getInstance.SendMail(GetEmailByColumnName(jobID.ToString, pt.SD_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, True)
            End If
            Return cnt
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"PG派工"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 派送工作到SA或SD
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="jobID"></param>
    ''' <param name="CCUser"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function AssignJobToSAorSD(ByVal ds As DataSet, ByVal jobID As String, ByVal CCUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            If UpdateSDConfirm(ds, conn) < 1 Then Throw New Exception

            Dim cnt As Integer = 0
            Dim message As StringBuilder = GetMailStringForSAorSD(jobID.ToString, ds, conn)
            Dim mailTitle As New StringBuilder
            '信件標題
            mailTitle.Append(GetMailSubject(jobID.ToString, conn))
            Dim client = FTMDelegate.getInstance
            Dim FID As String = ""
            If CheckMethodUtil.CheckHasValue(ds.Tables(JobSaSpecfilesDataTableFactory.tableName)) Then
                FID = ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.FID).ToString.Trim
                ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Rows(0).Item(JobSaSpecfilesDataTableFactory.DBColumnName.JOB_Code) = jobID
                Dim FilesDS As New DataSet
                FilesDS.Tables.Add(ds.Tables(JobSaSpecfilesDataTableFactory.tableName).Copy)
                cnt += JobSaSpecfilesBO.GetInstance.insert(FilesDS, conn)
            End If

            If FID.Length > 0 Then
                'Step.1 下載檔案
                Dim obj As Object = client.downloadFile(FID, False, conn)
                'Step.3 取得檔案副檔名
                Dim DataType As String = FID.Split(".")(1)
                '(0) 檔案資料byte() , (1) client端的預設檔名
                '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                cnt += SendMail.getInstance.SendMail(GetEmailByColumnName(jobID.ToString, pt.PG_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1), True)
            Else
                cnt += SendMail.getInstance.SendMail(GetEmailByColumnName(jobID.ToString, pt.PG_Employee_Code, conn), CCUser, mailTitle.ToString, message.ToString, True)
            End If
            Return cnt
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg("AssignJobToPG fail:" & ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"SD/SA派工"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Private Function UpdateSDConfirm(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update JOB_SA_Assign_Record")
            Content.AppendLine("  Set SD_Confirm='Y',SD_Note=@SD_Note,FID=@FID ,PG_Employee_Code=@PG_Employee_Code,")
            Content.AppendLine("      SD_Estimate_Cost=@SD_Estimate_Cost,SD_Cost_Time=@SD_Cost_Time,SD_Confirm_Date=getdate(),SD_Issue_Deadline=@SD_Issue_Deadline ")
            Content.AppendLine("  Where JOB_Code=@Job_Code")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                    command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Job_Code", row.Item("Job_Code"))
                    command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                    command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                    command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                    command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            Return count

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"SD確認"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' 更新問題單
    ''' </summary>
    ''' <param name="Job_Code"></param>
    ''' <param name="Modified_User"></param>
    ''' <param name="Issue_Id"></param>
    ''' <param name="AssignLevel">SA派工或者SD派工</param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function UpdateIssueRecordForNewJob(ByVal Job_Code As String, ByVal Modified_User As String, ByVal Issue_Id As String, ByVal AssignLevel As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder

            Select Case Issue_Id.Split("-")(0)
                Case "Service"
                    Content.AppendLine("Update JOB_Service_Record")
                    Content.AppendLine("  Set Job_Code=@Job_Code,Issue_Status='3',Modified_User=@Modified_User ,Modified_Time=@Modified_Time")
                    Content.AppendLine("  Where Issue_Id=@Issue_Id")
                    Content.AppendLine("")
                Case "QA"
                    Content.AppendLine("Update Job_QA_Bug_Record")
                    Content.AppendLine("  Set  ")
                    Select Case AssignLevel
                        Case "2"
                            Content.AppendLine("     Test_Result='03' ")
                        Case "3"
                            Content.AppendLine("     Test_Result='04' ")
                    End Select
                    'Content.AppendLine("     ,Modified_User=@Modified_User")
                    'Content.AppendLine("     ,Modified_Time=@Modified_Time")
                    Content.AppendLine("     ,Job_Code=@Job_Code")
                    Content.AppendLine("  Where Bug_Id=@Issue_Id")
                    Content.AppendLine("")
            End Select


            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Job_Code", Job_Code)
                command.Parameters.AddWithValue("@Modified_User", Modified_User)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                command.Parameters.AddWithValue("@Issue_Id", Issue_Id.Split("-")(1))

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            Return count
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新需求單狀態"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    Private Function UpdateIssueRecordForFinushJob(ByVal Job_Code As String, ByVal Modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing
        Dim LogMsg As String = ""

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update JOB_Service_Record")
            Content.AppendLine("  Set Issue_Status='1',Finish_Date=getdate(), Modified_Time=@Modified_Time")
            Content.AppendLine("  Where Job_Code=@Job_Code")
            Content.AppendLine(";")
            Content.AppendLine("Update Job_QA_Bug_Record")
            Content.AppendLine("  Set Test_Result='06',Modified_Time=@Modified_Time")
            Content.AppendLine("  Where Job_Code=@Job_Code")
            Content.AppendLine("")
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Job_Code", Job_Code)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            LogMsg = "寫入異動紀錄 "
            Try
                count += UpdateBugAmount(Job_Code, conn)

            Catch sqlex As SqlException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
            End Try
            LogMsg = ""
            Return count

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新需求單狀態"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


#Region " 更新版次的BUG數量 "

    ''' <summary>
    ''' 更新版次的BUG數量
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function UpdateBugAmount(ByVal JobCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = JobQaBugRecordBO_E1.GetInstance.dynamicQueryWithColumnValue({"Job_Code"}, {JobCode}, conn)
            If Not CheckMethodUtil.CheckHasValue(ds) Then Return 0
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim IssueLevel As String = ds.Tables(0).Rows(0).Item(0)
            Dim Content As New StringBuilder


            Select Case ds.Tables(0).Rows(0).Item("Issue_Level").ToString.Trim
                Case "1"
                    IssueLevel = "Urgent"
                Case "2"
                    IssueLevel = "Important"
                Case "3"
                    IssueLevel = "Normal"
            End Select
            Content.AppendLine("Update Job_QA_Test_Record ")
            Content.AppendLine("   Set Total_UnTest=Total_UnTest+1,")
            Content.AppendLine("       Modified_Time=getdate()")
            Content.AppendLine("Where Version_Id=@Version_Id")
            Content.AppendLine("")


            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                command.Parameters.AddWithValue("@Version_Id", ds.Tables(0).Rows(0).Item("Version_Id").ToString.Trim)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新版次的BUG數量"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#Region "取得派工發信的Html字串"
    Enum Source As Integer
        SA = 2
        SD = 3
    End Enum
    Private Function GetMailStringForPG(ByVal JobCode As String, ByVal ds As DataSet, ByVal Source As Source, Optional ByRef conn As System.Data.IDbConnection = Nothing) As StringBuilder

        Try
            Dim retStr As New StringBuilder


            Dim message As New StringBuilder


            message.Append(" <!DOCTYPE HTML>")
            message.Append("<html>")
            message.Append("<head>")
            message.Append("<title>凌群K9派工通知</title>")
            message.Append("</head>")
            message.Append("<body>")
            message.Append("<div>")
            message.Append("<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 1500"">")
            message.Append("<tbody>")
            If Source = Source.SA Then
                message.AppendLine("		<tr>")
                message.AppendLine("			<td colspan=""11"" style=""text-align: left; width: 1500"">")
                message.AppendLine("				<p><span style=""font-size:16px;""> Dear  " & GetEmployeeName(JobCode, "SD_Employee_Code", conn) & ":</span></p>")
                message.AppendLine("                <p><span style=""font-size:16px;""><span style=""color:#ff0000;"">     請協助進行派工覆核!! </span></span></p>")
                message.AppendLine("		</tr>")
            End If
            message.AppendLine("		<tr>")
            message.AppendLine("			<td style=""text-align: center; width: 200px"">")
            message.AppendLine("				派工編號</td>")
            message.AppendLine("			<td style=""text-align: center; width: 160px"">")
            message.AppendLine("				派工日</td>")
            message.AppendLine("			<td style=""text-align: center; width: 80px"">")
            message.AppendLine("				所屬專案</td>")
            message.AppendLine("			<td style=""text-align: center; width: 170px"">")
            message.AppendLine("				派工人員</td>")
            message.AppendLine("			<td style=""text-align: center; width: 80px"">")
            message.AppendLine("				系統別</td>")
            message.AppendLine("			<td style=""text-align: center; width: 170px"">")
            message.AppendLine("				負責人員</td>")
            message.AppendLine("			<td style=""text-align: center; width: 200px"">")
            message.AppendLine("				歸屬功能(UI名稱)</td>")
            message.AppendLine("			<td style=""text-align: center; width: 120px"">")
            message.AppendLine("				需求類別</td>")
            message.AppendLine("			<td style=""text-align: center; width: 220px"">")
            message.AppendLine("				評估需求時間</td>")
            message.AppendLine("			<td style=""text-align: center; width: 160px"">")
            message.AppendLine("				預期完成日</td>")
            message.AppendLine("			<td style=""text-align: center; width: 200px"">")
            message.AppendLine("				備註</td>")
            message.AppendLine("		</tr>")
            message.AppendLine("		<tr>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				").Append(JobCode).Append("</td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-family:comic sans ms,cursive;""><span style=""color:#ff0000;"">")
            message.AppendLine("				").Append(Now.ToString("yyyy/MM/dd"))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(GetEmployeeName(JobCode, "Create_User", conn))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("System_Code").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("PG_Employee_Code").ToString.Trim).Append("-").Append("").Append(GetEmployeeName(JobCode, "PG_Employee_Code", conn))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Function_Code").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(GetIssueNameByCodeId(ds.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim, conn))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Estimate_Cost").ToString.Trim & " 人日")
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Issue_Deadline").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("		</tr>")
            If Not Source = Source.SA Then
                message.AppendLine("		<tr>")
                message.AppendLine("			<td colspan=""9"" style=""text-align: center;"">")
                message.AppendLine("				<span style=""font-size:16px;""><span style=""color:#ff0000;"">已通過覆核。&nbsp;</span></span></td>")
                message.AppendLine("		</tr>")
                message.AppendLine("		<tr>")
                message.AppendLine("			<td style=""text-align: center;"">")
                message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
                message.AppendLine("				").Append("SD備註")
                message.AppendLine("				</span></span></td>")
                message.AppendLine("			<td colspan=""8"" style=""text-align: center;"">")
                message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
                message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("SD_Note").ToString.Trim)
                message.AppendLine("				</span></span></td>")
                message.AppendLine("		</tr>")
            End If
            message.Append("</tbody>")
            message.Append("</table>")
            message.Append("</body>")
            message.Append("</html>")
            Return message

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function

    ''' <summary>
    ''' 取得SA派工信件的Mail字串
    ''' </summary>
    ''' <param name="JobCode"></param>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function GetMailStringForSAorSD(ByVal JobCode As String, ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As StringBuilder

        Try
            Dim retStr As New StringBuilder


            Dim message As New StringBuilder


            message.Append(" <!DOCTYPE HTML>")
            message.Append("<html>")
            message.Append("<head>")
            message.Append("<title>凌群K9派工通知</title>")
            message.Append("</head>")
            message.Append("<body>")
            message.Append("<div>")
            message.Append("<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 1500"">")
            message.Append("<tbody>")
            message.AppendLine("		<tr>")
            message.AppendLine("			<td style=""text-align: center; width: 160px"">")
            message.AppendLine("				派工日</td>")
            message.AppendLine("			<td style=""text-align: center; width: 80px"">")
            message.AppendLine("				所屬專案</td>")
            message.AppendLine("			<td style=""text-align: center; width: 170px"">")
            message.AppendLine("				派工人員</td>")
            message.AppendLine("			<td style=""text-align: center; width: 80px"">")
            message.AppendLine("				系統別</td>")
            message.AppendLine("			<td style=""text-align: center; width: 170px"">")
            message.AppendLine("				負責人員</td>")
            message.AppendLine("			<td style=""text-align: center; width: 200px"">")
            message.AppendLine("				歸屬功能(UI名稱)</td>")
            message.AppendLine("			<td style=""text-align: center; width: 120px"">")
            message.AppendLine("				需求類別</td>")
            message.AppendLine("			<td style=""text-align: center; width: 220px"">")
            message.AppendLine("				評估需求時間</td>")
            message.AppendLine("			<td style=""text-align: center; width: 160px"">")
            message.AppendLine("				預期完成日</td>")
            message.AppendLine("			<td style=""text-align: center; width: 200px"">")
            message.AppendLine("				備註</td>")
            message.AppendLine("		</tr>")
            message.AppendLine("		<tr>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-family:comic sans ms,cursive;""><span style=""color:#ff0000;"">")
            message.AppendLine("				").Append(Now.ToString("yyyy/MM/dd"))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(GetEmployeeName(JobCode, "Create_User", conn))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("System_Code").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("PG_Name").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Function_Code").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(GetIssueNameByCodeId(ds.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim, conn))
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Estimate_Cost").ToString.Trim & " 人日")
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Issue_Deadline").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("			<td style=""text-align: center;"">")
            message.AppendLine("				<span style=""font-size:16px;""><span style=""font-family:comic sans ms,cursive;"">")
            message.AppendLine("				").Append(ds.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim)
            message.AppendLine("				</span></span></td>")
            message.AppendLine("		</tr>")
            message.Append("</tbody>")
            message.Append("</table>")
            message.Append("</body>")
            message.Append("</html>")
            Return message

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得SA派工信件的Mail字串"})
        End Try
    End Function
#End Region

    ''' <summary>
    ''' 回覆PG工作提交
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function ReplyJobSubmit(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim jobID As New StringBuilder
        Dim result As Boolean = ds.Tables(0).Rows(0).Item("Result").ToString.Trim
        Try

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Select Case result
                Case True
                    Return ConfirmJobSubmit(ds, conn)
                Case False
                    Return RejectJobSubmit(ds, "SA", conn)
            End Select


        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' 確認需求結果
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function ConfirmJobSubmit(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim jobID As New StringBuilder
        Dim retDS As New DataSet
        Dim rejectSeq As Int32 = 0
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        retDS.Tables(0).Columns.Add("Job_Code")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE JOB_SA_Assign_Record")
            Content.AppendLine("   SET Finish_Date = getdate()")
            Content.AppendLine("      ,Reject_Flag  = NULL")
            Content.AppendLine("      ,Modified_User  = @Modified_User")
            Content.AppendLine("      ,Modified_Time  =getdate()")
            Content.AppendLine(" WHERE Job_Code=@Job_Code")
            Content.AppendLine("")


            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope




                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@JOB_Code", ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim)
                    command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)



                    Dim cnt As Integer = command.ExecuteNonQuery
                    '更新需求單狀態
                    Try
                        cnt += UpdateIssueRecordForFinushJob(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim, conn)
                    Catch ex As Exception
                        Throw ex
                    End Try
                    If cnt > 0 Then
                        Dim mailTitle As New StringBuilder
                        Dim message As New StringBuilder
                        '信件標題
                        mailTitle.Append(GetMailSubject(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn)).Append("-(完成)")
                        message.Append("派工編號:").Append(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim).AppendLine()
                        message.Append("回覆狀況:").Append("SA已測試完畢").AppendLine()
                        message.Append("測試結果:").Append("測試OK").AppendLine()

                        SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn), mailTitle.ToString, message.ToString)

                    End If

                    retDS.Tables(0).Rows.Add(cnt, jobID.ToString)
                End Using
                scope.Complete()
            End Using
            Return retDS

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

    ''' <summary>
    ''' 作廢
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function CancelJob(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        Dim rejectSeq As Int32 = 0
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE JOB_SA_Assign_Record")
            Content.AppendLine("   SET Cancel = 'Y'")
            Content.AppendLine("      ,Cancel_Reason  = @Cancel_Reason")
            Content.AppendLine("      ,Modified_User  = @Modified_User")
            Content.AppendLine("      ,Modified_Time  =getdate()")
            Content.AppendLine("      ,Cancel_User  = @Modified_User")
            Content.AppendLine("      ,Cancel_Time  =getdate()")
            Content.AppendLine(" WHERE Job_Code=@Job_Code")
            Content.AppendLine("Update Job_QA_Bug_Record ")
            Content.AppendLine("   SET Test_Result = '01'")
            Content.AppendLine("      ,JOB_Code  = NULL")
            Content.AppendLine("      ,Modified_User  = @Modified_User")
            Content.AppendLine("      ,Modified_Time  =getdate()")
            Content.AppendLine(" WHERE Job_Code=@Job_Code")
            Content.AppendLine("   And ISNULL(Test_Result,'') in ('03','04')")




            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@JOB_Code", ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim)
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                command.Parameters.AddWithValue("@Cancel_Reason", ds.Tables(0).Rows(0).Item("Cancel_Reason").ToString.Trim)



                Dim cnt As Integer = command.ExecuteNonQuery

                If cnt > 0 Then
                    Dim mailTitle As New StringBuilder
                    Dim message As New StringBuilder
                    '信件標題
                    mailTitle.Append(GetMailSubject(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn)).Append("-(工作項目取消)")
                    message.Append("派工編號:").Append(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim).AppendLine()
                    message.Append("作廢原因:").Append(ds.Tables(0).Rows(0).Item("Cancel_Reason").ToString.Trim).AppendLine()
                    If ds.Tables(0).Rows(0).Item("Cancel_Reason").ToString.Trim.Equals("SA") Then
                        SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn), GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.SD_Employee_Code, conn), mailTitle.ToString, message.ToString)
                    Else
                        SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn), GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.Create_User, conn), mailTitle.ToString, message.ToString)
                    End If
                End If

                retDS.Tables(0).Rows.Add(cnt)
            End Using

            Return retDS
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

    ''' <summary>
    ''' 需求提交退件
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>

    Public Function RejectJobSubmit(ByVal ds As DataSet, Optional User As String = "SA", Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        Dim rejectSeq As Int32 = 0
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        retDS.Tables(0).Columns.Add("Job_Code")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine(" ")
            Content.AppendLine("INSERT INTO  JOB_SA_Reject_Record ")
            Content.AppendLine("           ( JOB_Code ")
            Content.AppendLine("           , Reply_Seq ")
            Content.AppendLine("           , Reply_Note ")
            Content.AppendLine("           , FID ")
            Content.AppendLine("           , SA_Reply_ATT_FID ")
            Content.AppendLine("           , Create_User ")
            Content.AppendLine("           , Create_Time ")
            Content.AppendLine("           , Modified_User ")
            Content.AppendLine("           , Modified_Time )")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@JOB_Code")
            Content.AppendLine("           ,@Reply_Seq")
            Content.AppendLine("           ,@Reply_Note")
            Content.AppendLine("           ,@FID")
            Content.AppendLine("           ,@SA_Reply_ATT_FID")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,getdate()")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,getdate())")
            Content.AppendLine(";")
            Content.AppendLine("UPDATE JOB_SA_Assign_Record")
            Content.AppendLine("   SET Reject_Flag  = 1")
            Content.AppendLine("      ,Reply_Date = NULL")
            Content.AppendLine("      ,Modified_User  = @Modified_User")
            Content.AppendLine("      ,Modified_Time  =getdate()")
            Content.AppendLine(" WHERE Job_Code=@Job_Code")
            Content.AppendLine("")

            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@JOB_Code", ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim)
                    command.Parameters.AddWithValue("@Reply_Seq", QueryRejectTime(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn))
                    command.Parameters.AddWithValue("@Reply_Note", ds.Tables(0).Rows(0).Item("Reply_Note").ToString.Trim)
                    command.Parameters.AddWithValue("@FID", ds.Tables(0).Rows(0).Item("FID").ToString.Trim)
                    command.Parameters.AddWithValue("@SA_Reply_ATT_FID", ds.Tables(0).Rows(0).Item("SA_Reply_ATT_FID").ToString.Trim)
                    command.Parameters.AddWithValue("@Create_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                    command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)


                    Dim cnt As Integer = command.ExecuteNonQuery

                    If cnt > 0 Then
                        Dim mailTitle As New StringBuilder
                        Dim message As New StringBuilder
                        '信件標題
                        mailTitle.Append(GetMailSubject(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn)).Append("-(退件)")
                        message.Append("派工編號:").Append(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim).AppendLine()
                        message.Append("測試狀況:").Append("QA/SA已測試完畢").AppendLine()
                        message.Append("測試結果:").AppendLine()
                        message.Append("與實際需求不符或有BUG，請至派工系統查看回覆情況").AppendLine()
                        message.Append(ds.Tables(0).Rows(0).Item("Reply_Note").ToString.Trim).AppendLine()


                        Dim client = FTMDelegate.getInstance
                        Dim ATTFID As String = ds.Tables(0).Rows(0).Item("SA_Reply_ATT_FID").ToString.Trim
                        If ATTFID.Length > 0 Then
                            'Step.1 下載檔案
                            Dim obj As Object = client.downloadFile(ATTFID)
                            'Step.3 取得檔案副檔名
                            Dim DataType As String = ATTFID.Split(".")(1)
                            '(0) 檔案資料byte() , (1) client端的預設檔名
                            '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                            FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                            SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn), "", mailTitle.ToString, message.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1))
                        Else
                            If User.Equals("QA") Then
                                SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn),
                                                          GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.Create_User, conn), mailTitle.ToString, message.ToString)
                            Else
                                SendMail.getInstance.SendMail(GetEmailByColumnName(ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, pt.PG_Employee_Code, conn), mailTitle.ToString, message.ToString)
                            End If
                        End If


                    End If
                    '更新工作狀態
                    Dim UpdateStatusDS As New DataSet
                    UpdateStatusDS.Tables.Add(New DataTable("Action"))
                    UpdateStatusDS.Tables(0).Columns.Add("Action")
                    UpdateStatusDS.Tables(0).Columns.Add("JOB_Code")
                    UpdateStatusDS.Tables(0).Columns.Add("Status")
                    UpdateStatusDS.Tables(0).Columns.Add("Create_User")
                    UpdateStatusDS.Tables(0).Rows.Add("UpdateJOBStatus", ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, "0", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                    JobPGJobBO_E1.GetInstance.UpdateJobStatus(UpdateStatusDS, conn)

                    retDS.Tables(0).Rows.Add(cnt, ds.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim)
                End Using
                scope.Complete()

            End Using
            Return retDS

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

    Public Function ApplyDBModified(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim cnt As Int32 = 0
        Dim System As String = ds.Tables(0).Rows(0).Item("System").ToString.Trim
        Dim ApplyUser As String = ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim
        Dim ApplyUserName As String = ds.Tables(0).Rows(0).Item("Create_User_Name").ToString.Trim
        Dim TableName As String = ds.Tables(0).Rows(0).Item("Table_Name").ToString.Trim
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Try
                '寫入異動記錄檔
                cnt = InsertIntoDBModifiedcRecord(ds, conn)

            Catch sqlex As SqlException
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {"寫入異動記錄檔"})
            End Try


            Try

                If cnt > 0 Then
                    Dim message As New StringBuilder
                    message.AppendLine("<p>申請人:").Append(ApplyUserName).Append("</p>")
                    message.AppendLine("<p>已於 ").Append(Now.ToString("yyyy/MM/dd")).Append("提出DB異動申請，煩請撥空進行調整</p>")
                    message.AppendLine("<p><span style=""color:#ff0000;"">系統郵件請勿直接回覆</span></p>")
                    Dim FileName As String = Now.ToString("yyyyMMdd") & TableName & "(" & System & ")" & "(" & ApplyUserName & ")"
                    Dim mailTitle As New StringBuilder
                    '信件標題
                    mailTitle.Append("[DB異動申請單]").Append(FileName)
                    Dim client = FTMDelegate.getInstance
                    Dim FID As String = ds.Tables(0).Rows(0).Item("FID").ToString.Trim

                    If FID.Length > 0 Then
                        'Step.1 下載檔案
                        Dim obj As Object = client.downloadFile(FID)
                        'Step.3 取得檔案副檔名
                        Dim DataType As String = FID.Split(".")(1)
                        '(0) 檔案資料byte() , (1) client端的預設檔名
                        '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                        FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                        SendMail.getInstance.SendMail(GetMailReceiver(ds.Tables(0).Rows(0).Item("DBA_Employee_Code").ToString.Trim, conn),
                                                      GetMailReceiver(ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim, conn),
                                                      mailTitle.ToString, message.ToString, New MemoryStream(CType(obj(0), Byte())), FileName & ".docx", True)
                    End If
                    retDS.Tables(0).Rows.Add("申請完成")
                Else
                    Throw New Exception("寫入異動記錄檔失敗")
                End If

            Catch sqlex As SqlException
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {"寫入異動記錄檔"})
            End Try

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"寫入異動記錄檔"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return retDS
    End Function


    Private Function InsertIntoDBModifiedcRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim Project_ID As String = ds.Tables(0).Rows(0).Item("Project_ID")
            Dim DBA_Employee_Code As String = ds.Tables(0).Rows(0).Item("DBA_Employee_Code")
            Dim DB_Name As String = ds.Tables(0).Rows(0).Item("DB_Name")
            Dim Table_Name As String = ds.Tables(0).Rows(0).Item("Table_Name")
            Dim Table_Ch_Name As String = ds.Tables(0).Rows(0).Item("Table_Ch_Name")
            Dim Index As String = ds.Tables(0).Rows(0).Item("Index")
            Dim Restrict As String = ds.Tables(0).Rows(0).Item("Restrict")
            Dim Modified_Classify As String = ds.Tables(0).Rows(0).Item("Modified_Classify")
            Dim Sql_Script As String = ds.Tables(0).Rows(0).Item("Sql_Script")
            Dim Modified_FID As String = ds.Tables(0).Rows(0).Item("FID")
            Dim Create_User As String = ds.Tables(0).Rows(0).Item("Create_User")
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO JOB_SA_DBModified_Record")
            Content.AppendLine("           (Project_ID")
            Content.AppendLine("           , Seq_No")
            Content.AppendLine("           ,DBA_Employee_Code")
            Content.AppendLine("           ,DB_Name")
            Content.AppendLine("           ,Table_Name")
            Content.AppendLine("           ,Table_Ch_Name")
            Content.AppendLine("           ,[Index]")
            Content.AppendLine("           ,[Restrict]")
            Content.AppendLine("           ,Modified_Classify")
            Content.AppendLine("           ,Sql_Script")
            Content.AppendLine("           ,Modified_FID")
            Content.AppendLine("           ,Create_User")
            Content.AppendLine("           ,Create_Time")
            Content.AppendLine("           ,Modified_User")
            Content.AppendLine("           ,Modified_Time)")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Project_ID ")
            Content.AppendLine("           ,@Seq_No ")
            Content.AppendLine("           ,@DBA_Employee_Code ")
            Content.AppendLine("           ,@DB_Name ")
            Content.AppendLine("           ,@Table_Name ")
            Content.AppendLine("           ,@Table_Ch_Name ")
            Content.AppendLine("           ,@Index ")
            Content.AppendLine("           ,@Restrict ")
            Content.AppendLine("           ,@Modified_Classify ")
            Content.AppendLine("           ,@Sql_Script ")
            Content.AppendLine("           ,@Modified_FID ")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,getdate()")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,getdate())")
            Content.AppendLine("")


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Project_ID", Project_ID)
                command.Parameters.AddWithValue("@Seq_No", QueryMaxSeqByTable("Seq_No", "JOB_SA_DBModified_Record", {"Project_Id"}, New Dictionary(Of String, String) From {{"Project_Id", Project_ID}}, conn))
                command.Parameters.AddWithValue("@DBA_Employee_Code", DBA_Employee_Code)
                command.Parameters.AddWithValue("@DB_Name", DB_Name)
                command.Parameters.AddWithValue("@Table_Name", Table_Name)
                command.Parameters.AddWithValue("@Table_Ch_Name", Table_Ch_Name)
                command.Parameters.AddWithValue("@Index", Index)
                command.Parameters.AddWithValue("@Restrict", Restrict)
                command.Parameters.AddWithValue("@Modified_Classify", Modified_Classify)
                command.Parameters.AddWithValue("@Sql_Script", Sql_Script)
                command.Parameters.AddWithValue("@Modified_FID", Modified_FID)
                command.Parameters.AddWithValue("@Modified_User", Create_User)
                command.Parameters.AddWithValue("@Create_User", Create_User)

                Dim cnt As Integer = command.ExecuteNonQuery
                Return cnt
            End Using



        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"寫入異動記錄檔"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
        Return 0
    End Function

    ''' <summary>
    ''' 新增派工紀錄
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function InsertIntoSAAssignRecord(ByVal JOB_Code As String, ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing
        Dim mailTitle As New StringBuilder


        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [JOB_SA_Assign_Record]")
            Content.AppendLine("           ([JOB_Code]")
            Content.AppendLine("           ,[Assign_Date]")
            Content.AppendLine("           ,[Project_ID]")
            Content.AppendLine("           ,[PG_Employee_Code]")
            Content.AppendLine("           ,[System_Code]")
            Content.AppendLine("           ,[Function_Code]")
            Content.AppendLine("           ,[Issue_Classify]")
            Content.AppendLine("           ,[Issue_Deadline]")
            Content.AppendLine("           ,[Issue_Desc]")
            Content.AppendLine("           ,[FID]")
            Content.AppendLine("           ,[RTF_FID]")
            Content.AppendLine("           ,[Mail_Subject]")
            Content.AppendLine("           ,[Mail_Group_Id]")
            Content.AppendLine("           ,[Test_Report_Flag]")
            Content.AppendLine("           ,[Assign_Source]")
            Content.AppendLine("           ,[SD_Employee_Code]")
            Content.AppendLine("           ,[Estimate_Cost]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@JOB_Code  ")
            Content.AppendLine("           ,@Assign_Date ")
            Content.AppendLine("           ,@Project_ID ")
            Content.AppendLine("           ,@PG_Employee_Code ")
            Content.AppendLine("           ,@System_Code ")
            Content.AppendLine("           ,@Function_Code ")
            Content.AppendLine("           ,@Issue_Classify ")
            Content.AppendLine("           ,@Issue_Deadline ")
            Content.AppendLine("           ,@Issue_Desc ")
            Content.AppendLine("           ,@FID ")
            Content.AppendLine("           ,@RTF_FID ")
            Content.AppendLine("           ,@Mail_Subject ")
            Content.AppendLine("           ,@Mail_Group_Id ")
            Content.AppendLine("           ,@Test_Report_Flag ")
            Content.AppendLine("           ,@Assign_Source ")
            Content.AppendLine("           ,@SD_Employee_Code ")
            Content.AppendLine("           ,@Estimate_Cost ")
            Content.AppendLine("           ,@Create_User ")
            Content.AppendLine("           ,@Create_Time ")
            Content.AppendLine("           ,@Modified_User ")
            Content.AppendLine("           ,@Modified_Time)")
            Content.AppendLine("")


            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@JOB_Code", JOB_Code)
                command.Parameters.AddWithValue("@Assign_Date", Now)
                command.Parameters.AddWithValue("@Project_ID", ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim)
                command.Parameters.AddWithValue("@PG_Employee_Code", ds.Tables(0).Rows(0).Item("PG_Employee_Code").ToString.Trim)
                command.Parameters.AddWithValue("@System_Code", ds.Tables(0).Rows(0).Item("System_Code").ToString.Trim)
                command.Parameters.AddWithValue("@Function_Code", ds.Tables(0).Rows(0).Item("Function_Code").ToString.Trim)
                command.Parameters.AddWithValue("@Issue_Classify", ds.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim)
                command.Parameters.AddWithValue("@Issue_Deadline", ds.Tables(0).Rows(0).Item("Issue_Deadline").ToString.Trim)
                command.Parameters.AddWithValue("@Issue_Desc", ds.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim)
                command.Parameters.AddWithValue("@FID", ds.Tables(0).Rows(0).Item("FID").ToString.Trim)
                command.Parameters.AddWithValue("@RTF_FID", ds.Tables(0).Rows(0).Item("RTF_FID").ToString.Trim)
                command.Parameters.AddWithValue("@Mail_Subject", ds.Tables(0).Rows(0).Item("Mail_Subject").ToString.Trim)
                command.Parameters.AddWithValue("@Mail_Group_Id", ds.Tables(0).Rows(0).Item("Mail_Group_Id").ToString.Trim)
                command.Parameters.AddWithValue("@Test_Report_Flag", ds.Tables(0).Rows(0).Item("Test_Report_Flag").ToString.Trim)
                command.Parameters.AddWithValue("@Assign_Source", ds.Tables(0).Rows(0).Item("Assign_Source").ToString.Trim)
                command.Parameters.AddWithValue("@SD_Employee_Code", ds.Tables(0).Rows(0).Item("SD_Employee_Code").ToString.Trim)
                command.Parameters.AddWithValue("@Estimate_Cost", ds.Tables(0).Rows(0).Item("Estimate_Cost").ToString.Trim)
                command.Parameters.AddWithValue("@Create_User", ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim)
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim)
                command.Parameters.AddWithValue("@Modified_Time", Now)

                Dim cnt As Integer = command.ExecuteNonQuery


                Return cnt
            End Using
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


#End Region

#Region "     查詢"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function QueryRejectTime(ByVal JOB_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet
        Try

            Dim Content As New StringBuilder
            Content.AppendLine("Select isnull(Max(Reply_Seq)+1,1) ")
            Content.AppendLine("  FROM JOB_SA_Reject_Record")
            Content.AppendLine("Where JOB_Code=@JOB_Code")



            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Reject_Time")
                adapter.Fill(ds, "Reject_Time")
            End Using

            Return CInt(ds.Tables(0).Rows(0).Item(0))

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

    ''' <summary>
    ''' 查詢MaxSeq
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-15</remarks>
    Public Function QueryMaxSeqByTable(ByVal SeqColumnName As String, ByVal TableName As String, ByVal PkColumnName As String(), ByVal PkValue As Dictionary(Of String, String), Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet
        Try

            Dim Content As New StringBuilder
            Content.AppendLine("Select isnull(Max(" & SeqColumnName & ")+1,1) ")
            Content.AppendLine("  FROM " & TableName & "")
            Content.AppendLine("Where 1=1")
            For Each c As String In PkColumnName
                Content.Append("And " & c & "=@" & c & "")
            Next



            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            For Each c As String In PkColumnName
                command.Parameters.AddWithValue("@" & c, PkValue(c))
            Next


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("GetMaxSeq")
                adapter.Fill(ds, "GetMaxSeq")
            End Using

            Return CInt(ds.Tables(0).Rows(0).Item(0))

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

    Private Function GetMailReceiver(ByVal Employee_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String


        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select EMail From PUB_Employee Where Employee_Code=@Employee_Code"

            command.Parameters.AddWithValue("@Employee_Code", Employee_Code)

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

    Public Function GetMailSubject(ByVal JOB_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String


        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("Select  '[' + RTRIM(PS.Code_En_Name) + ']-' AS 需求類別")
            Content.AppendLine("       ,CASE  RTRIM(PH.Hospital_Short_Name)")
            Content.AppendLine("        WHEN '' THEN '[無所屬醫院]-'  ")
            Content.AppendLine("        ELSE '[' + RTRIM(PH.Hospital_Short_Name) + ']-'")
            Content.AppendLine("        END '所屬醫院'")
            Content.AppendLine("       ,'[' + RTRIM(PP.Project_Name) + ']-' AS 專案名稱")
            Content.AppendLine("       ,'[' + RTRIM(PPS.System_Name) + ']-' AS 系統別")
            Content.AppendLine("       ,'[' + RTRIM(PPSF.Function_Name) + ']-' AS 所屬功能")
            Content.AppendLine("	   ,Case ISNULL(JSAR.Mail_Subject,'') When '' Then '無主旨' Else ISNULL(JSAR.Mail_Subject,'') End AS 主旨")
            Content.AppendLine("  From JOB_SA_Assign_Record JSAR")
            Content.AppendLine("Inner Join PUB_Syscode PS on PS.Type_Id='9999' and JSAR.Issue_Classify =PS.Code_Id")
            Content.AppendLine("Inner Join  PRJ_Project PP on PP.Project_ID= JSAR.Project_ID")
            Content.AppendLine("Inner Join  PRJ_Project_System PPS on PPS.Project_ID= JSAR.Project_ID And PPS.System_Code=JSAR.System_Code")
            Content.AppendLine("Inner Join  PRJ_Project_System_Function PPSF on PPSF.Project_ID= JSAR.Project_ID And PPSF.System_Code=JSAR.System_Code And PPSF.Function_Code=JSAR.Function_Code")
            Content.AppendLine("Left Join PUB_Hospital PH On PH.Hospital_Code =JSAR.Hospital_Code")
            Content.AppendLine("Where 1=1")
            Content.AppendLine("  And Job_Code=@Job_Code")
            Content.AppendLine("")



            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)

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

    Private Function GetEmailByColumnName(ByVal JobCode As String, ByVal ColumnName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select EMail From PUB_Employee Where Employee_Code=(Select " & ColumnName & " From  JOB_SA_Assign_Record Where JOB_Code=@JobCode)"

            command.Parameters.AddWithValue("@JobCode", JobCode)

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


    Public Function GetEmployeeName(ByVal JobCode As String, ByVal ColumnName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Employee_En_Name From PUB_Employee Where Employee_Code= (Select " & ColumnName & " From  JOB_SA_Assign_Record Where JOB_Code=@JobCode)"

            command.Parameters.AddWithValue("@JobCode", JobCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Name")
                adapter.Fill(ds, "Name")
            End Using

            Return ds.Tables(0).Rows(0).Item("Employee_En_Name").ToString.Trim

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



#Region " 查詢已派工清單 "

    ''' <summary>
    ''' 查詢已派工清單
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-16</remarks>
    Public Function QueryJobList(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim AssignDateS As String = ds.Tables(0).Rows(0).Item("AssignDateS").ToString.Trim
        Dim AssignDateE As String = ds.Tables(0).Rows(0).Item("AssignDateE").ToString.Trim
        Dim PG_Employee_Code As String = ds.Tables(0).Rows(0).Item("PG_Employee_Code").ToString.Trim
        Dim Project_ID As String = ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
        Dim System_Code As String = ds.Tables(0).Rows(0).Item("System_Code").ToString.Trim
        Dim Create_User As String = ds.Tables(0).Rows(0).Item("Create_User").ToString.Trim
        Dim Nrs_Level_Id As String = ds.Tables(0).Rows(0).Item("Nrs_Level_Id").ToString.Trim
        Dim SD_Confirm As String = ds.Tables(0).Rows(0).Item("SD_Confirm").ToString.Trim
        Dim Status As String = ds.Tables(0).Rows(0).Item("Status").ToString.Trim
        Dim Cancel As String = ds.Tables(0).Rows(0).Item("Cancel").ToString.Trim
        Dim MainSDEmployeeCode As String = ds.Tables(0).Rows(0).Item("Main_SD_Employee_Code").ToString.Trim

        Try
            Dim retDS As DataSet

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("Select RTRIM(JSAR.[JOB_Code]) JOB_Code")
            Content.AppendLine("      ,RTRIM(JSAR.[Assign_Date]) Assign_Date")
            Content.AppendLine("      ,RTRIM(JSAR.[Project_ID]) Project_ID")
            Content.AppendLine("      ,RTRIM(RP.[Project_Name]) Project_Name")
            Content.AppendLine("      ,RTRIM(JSAR.[PG_Employee_Code]) PG_Employee_Code")
            Content.AppendLine("      ,RTRIM(PE.[Employee_Name]) Employee_Name")
            Content.AppendLine("      ,RTRIM(JSAR.[Finish_Date]) Finish_Date")
            Content.AppendLine("      ,RTRIM(JSAR.[System_Code]) System_Code")
            Content.AppendLine("      ,RTRIM(RPS.[System_Name]) System_Name")
            Content.AppendLine("      ,RTRIM(JSAR.[Function_Code]) Function_Code")
            Content.AppendLine("      ,RTRIM(RPSF.[Function_Name]) Function_Name")
            Content.AppendLine("      ,RTRIM(JSAR.[Issue_Classify]) Issue_Classify")
            Content.AppendLine("      ,RTRIM(JSAR.[Issue_Deadline]) Issue_Deadline")
            Content.AppendLine("      ,RTRIM(JSAR.[SD_Issue_Deadline]) SD_Issue_Deadline")
            Content.AppendLine("      ,RTRIM(JSAR.[Issue_Desc]) Issue_Desc")
            Content.AppendLine("      ,RTRIM(JSAR.[Reply_Date]) Reply_Date")
            Content.AppendLine("      ,RTRIM(JSAR.[Create_User]) Create_User")
            Content.AppendLine("      ,RTRIM(JSAR.[Create_Time]) Create_Time")
            Content.AppendLine("      ,RTRIM(JSAR.[Modified_User]) Modified_User")
            Content.AppendLine("      ,RTRIM(JSAR.[Modified_Time]) Modified_Time")
            Content.AppendLine("      ,ISNULL((Select TOP 1 RTRIM(FID) From JOB_PG_JOB_Record Where JOB_Code=JSAR.JOB_Code Order By Seq_No Desc),'') Report_FID")
            Content.AppendLine("      ,RTRIM(JSAR.[Reject_Flag]) Reject_Flag")
            Content.AppendLine("      ,RTRIM(JSAR.[Cancel]) Cancel")
            Content.AppendLine("      ,RTRIM(JSAR.[Mail_Subject]) Mail_Subject")
            Content.AppendLine("      ,RTRIM(JSAR.[SD_Employee_Code]) SD_Employee_Code")
            Content.AppendLine("      ,RTRIM(JSAR.[Test_Report_Flag]) Test_Report_Flag")
            Content.AppendLine("      ,Case ISNULL((Select Top 1 FID From JOB_SA_SpecFiles JSSF Where JSSF.Job_Code=JSAR.Job_Code Order By Create_Time Desc),'')")
            Content.AppendLine("	   When '' Then RTRIM(JSAR.FID)")
            Content.AppendLine("	   Else RTRIM((Select Top 1 FID From JOB_SA_SpecFiles JSSF Where JSSF.Job_Code=JSAR.Job_Code Order By Create_Time Desc)) End  FID")
            Content.AppendLine("      ,RTRIM(PE1.[Employee_Name]) Assign_User")
            Content.AppendLine("      ,RTRIM(JSAR.[SD_Confirm]) SD_Confirm")
            Content.AppendLine("      ,RTRIM(JSAR.[SD_Note]) SD_Note")
            Content.AppendLine("      ,RTRIM(JSAR.[System_Code]) System_Code")
            Content.AppendLine("      ,RTRIM(JSAR.[Estimate_Cost]) Estimate_Cost")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Short_Name]) Hospital_Short_Name")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Code]) Hospital_Code")
            Content.AppendLine("      ,DATEDIFF (day,CONVERT(datetime,Issue_Deadline),CONVERT(datetime,GETDATE())) Delay_Days")
            Content.AppendLine("	  ,RTRIM(JSAR.FID) ")
            Content.AppendLine("	  ,RTRIM(SASpec.FID) SA_Spec_FID")
            Content.AppendLine("	  ,RTRIM(SDSpec.FID) SD_Spec_FID")
            Content.AppendLine("	  ,RTRIM(JSAR.RTF_FID) RTF_FID")
            Content.AppendLine("  FROM [JOB_SA_Assign_Record] JSAR")
            Content.AppendLine("Inner Join PRJ_Project RP On RP.Project_ID =JSAR.Project_ID and End_Date is null")
            Content.AppendLine("Inner Join PRJ_Project_System RPS On RPS.Project_ID=JSAR.Project_ID And RPS.System_Code =JSAR.System_Code")
            Content.AppendLine("Inner Join PRJ_Project_System_Function RPSF On RPSF.Project_ID=JSAR.Project_ID And RPSF.System_Code =JSAR.System_Code And RPSF.Function_Code=JSAR.Function_Code ")
            Content.AppendLine("Inner Join PUB_Employee PE On PE.Employee_Code =JSAR.PG_Employee_Code")
            Content.AppendLine("Inner Join PUB_Employee PE1 On PE1.Employee_Code =JSAR.Create_User")
            Content.AppendLine("Left Join PUB_Hospital PH On PH.Hospital_Code =JSAR.Hospital_Code")
            Content.AppendLine("Left Join JOB_SA_SpecFiles SASpec On SASpec.Job_Code =JSAR.Job_Code And SASpec.Source in('1','2')")
            Content.AppendLine("Left Join JOB_SA_SpecFiles SDSpec On SDSpec.Job_Code =JSAR.Job_Code And SDSpec.Source='3'")
            Content.AppendLine(" Where 1=1")

            If AssignDateS.Length > 0 Then
                Content.AppendLine(" And JSAR.Assign_Date >=@AssignDateS")
            End If
            If AssignDateE.Length > 0 Then
                Content.AppendLine(" And JSAR.Assign_Date <=@AssignDateE")
            End If

            If PG_Employee_Code.Length > 0 Then
                Content.AppendLine(" And JSAR.PG_Employee_Code =@PG_Employee_Code")
            End If
            If Project_ID.Length > 0 Then
                Content.AppendLine(" And JSAR.Project_ID =@Project_ID")
            End If
            If System_Code.Length > 0 Then
                Content.AppendLine(" And JSAR.System_Code =@System_Code")
            End If

            If Create_User.Length > 0 Then
                Content.AppendLine(" And JSAR.Create_User =@Create_User")
            End If

            'If Nrs_Level_Id = "2" Then
            '    Content.AppendLine(" And JSAR.Create_User =@Create_User")
            'Else
            If MainSDEmployeeCode.Length = 0 Then
                'Content.AppendLine(" And (JSAR.Create_User =@Create_User Or JSAR.SD_Employee_Code =@Create_User)")
            Else
                'Content.AppendLine(" And (JSAR.Create_User =@Create_User Or JSAR.SD_Employee_Code in (@Create_User,@MainSDEmployeeCode))")
                Content.AppendLine(" And JSAR.SD_Employee_Code =@MainSDEmployeeCode ")
            End If
            'End If

            If SD_Confirm.Equals("Y") Then
                Content.AppendLine(" And Isnull(JSAR.SD_Confirm,'N') =@SD_Confirm")
            End If
            Select Case Status
                Case "Close"
                    Content.AppendLine(" And JSAR.Finish_Date Is not null")
                Case "UnClose"
                    Content.AppendLine(" And JSAR.Finish_Date Is null")
                Case "UnConfirm"
                    Content.AppendLine(" And JSAR.Finish_Date Is null")
                    Content.AppendLine(" And isnull(Reply_Date,'') <> '' ")
                    Content.AppendLine(" And isnull(Reject_Flag,'') <> '1' ")
                Case "UnProcess"
                    Content.AppendLine(" And JSAR.Finish_Date Is null")
                    Content.AppendLine(" And isnull(Reply_Date,'') = '' ")
            End Select
            Content.AppendLine(" And Isnull(JSAR.Cancel,'N') = @Cancel")

            Content.AppendLine("Order By Assign_Date Desc ;")


            '查詢異動申請紀錄
            Content.AppendLine("SELECT  RTRIM(PP.Project_Name) Project_Name")
            Content.AppendLine("	   ,RTRIM(JSDR.Create_Time) Create_Time ")
            Content.AppendLine("	   ,RTRIM(JSDR.DB_Name) DB_Name ")
            Content.AppendLine("	   ,RTRIM(JSDR.Table_Name) Table_Name ")
            Content.AppendLine("	   ,RTRIM(JSDR.Modified_Classify) Modified_Classify ")
            Content.AppendLine("	   ,RTRIM(PE.Employee_Name) DBA_Name ")
            Content.AppendLine("	   ,Case When JSDR.is_modified is null then '未處理'")
            Content.AppendLine("	    When JSDR.is_modified='N' Then '退件'")
            Content.AppendLine("	    Else '已處理'")
            Content.AppendLine("	    End  'Modified_Status'")
            Content.AppendLine("	   ,RTRIM(JSDR.Modified_FID) Modified_FID")
            Content.AppendLine("	   ,RTRIM(JSDR.Project_ID) Project_ID")
            Content.AppendLine("	   ,RTRIM(JSDR.Seq_No) Seq_No")
            Content.AppendLine("	   ,RTRIM(JSDR.Reject_Reason) Reject_Reason")
            Content.AppendLine("  FROM JOB_SA_DBModified_Record JSDR")
            Content.AppendLine("Inner Join PUB_Employee PE ON JSDR.DBA_Employee_Code=PE.Employee_Code")
            Content.AppendLine("Inner Join PRJ_Project PP ON JSDR.Project_ID=PP.Project_ID")
            Content.AppendLine("Where 1=2")
            If Create_User.Length > 0 Then
                Content.AppendLine("  And JSDR.Create_User=@Create_User")
            End If
            If AssignDateS.Length > 0 Then
                Content.AppendLine(" And JSDR.Create_Time >= Convert(datetime,@AssignDateS)  ")
            End If
            If AssignDateE.Length > 0 Then
                Content.AppendLine(" And JSDR.Create_Time <= Convert(datetime,@AssignDateE) ")
            End If
            If Project_ID.Length > 0 Then
                Content.AppendLine(" And JSDR.Project_ID =@Project_ID")
            End If
            Content.AppendLine("")



            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            If AssignDateS.Length > 0 Then
                command.Parameters.AddWithValue("@AssignDateS", AssignDateS)
            End If
            If AssignDateE.Length > 0 Then
                command.Parameters.AddWithValue("@AssignDateE", AssignDateE)
            End If

            If PG_Employee_Code.Length > 0 Then
                command.Parameters.AddWithValue("@PG_Employee_Code", PG_Employee_Code)
            End If
            If Project_ID.Length > 0 Then
                command.Parameters.AddWithValue("@Project_ID", Project_ID)
            End If
            If System_Code.Length > 0 Then
                command.Parameters.AddWithValue("@System_Code", System_Code)
            End If
            If Create_User.Length > 0 Then
                command.Parameters.AddWithValue("@Create_User", Create_User)
            End If
            If MainSDEmployeeCode.Length > 0 Then
                command.Parameters.AddWithValue("@MainSDEmployeeCode", MainSDEmployeeCode)
            End If

            If SD_Confirm.Equals("Y") Then
                command.Parameters.AddWithValue("@SD_Confirm", "N")
            End If
            command.Parameters.AddWithValue("@Cancel", Cancel)


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet()
                adapter.Fill(retDS)
            End Using


            retDS.Tables(0).TableName = "JOBLIST"
            retDS.Tables(1).TableName = "Modified_Record"


            Return retDS

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

#Region " 查詢派工紀錄(歷史查詢) "

    ''' <summary>
    ''' 查詢派工紀錄(歷史查詢)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Public Function QueryJobAssignRecord(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim HospCode As String = input.Tables(0).Rows(0).Item("Hospital_Code").ToString.Trim
            Dim ProjectId As String = input.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            Dim SystemCode As String = input.Tables(0).Rows(0).Item("System_Code").ToString.Trim
            Dim FunctionCode As String = input.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
            Dim CreateUser As String = input.Tables(0).Rows(0).Item("Create_User").ToString.Trim
            Dim SDate As String = input.Tables(0).Rows(0).Item("Assign_SDate").ToString.Trim
            Dim EDate As String = input.Tables(0).Rows(0).Item("Assign_EDate").ToString.Trim

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("/****** SSMS 中 SelectTopNRows 命令的指令碼  ******/")
            Content.AppendLine("SELECT convert(char, Assign_Date, 111) Assign_Date ")
            Content.AppendLine("	  ,RTRIM(PE.Employee_En_Name) Assign_User")
            Content.AppendLine("	  ,RTRIM(PH.Hospital_Name) Hospital_Name")
            Content.AppendLine("	  ,RTRIM(PP.Project_Id) Project_Id")
            Content.AppendLine("	  ,RTRIM(PP.Project_Name) Project_Name")
            Content.AppendLine("	  ,RTRIM(PPS.System_Code) System_Code")
            Content.AppendLine("	  ,RTRIM(PPS.System_Name) System_Name")
            Content.AppendLine("	  ,RTRIM(PPSF.Function_Code) Function_Code")
            Content.AppendLine("	  ,RTRIM(PPSF.Function_Name) Function_Name")
            Content.AppendLine("	  ,RTRIM(PE.Employee_Code) Employee_Code ")
            Content.AppendLine("      ,RTRIM(PH.Hospital_Code) Hospital_Code")
            Content.AppendLine("	  ,RTRIM(JSAR.Mail_Subject) Mail_Subject")
            Content.AppendLine("	  ,RTRIM(JSAR.Job_Code) Job_Code")
            Content.AppendLine("  FROM JOB_SA_Assign_Record JSAR")
            Content.AppendLine("Inner Join JOB_SA_SpecFiles JSS On JSS.JOB_Code = JSAR.JOB_Code")
            Content.AppendLine("Inner Join PUB_Employee PE On PE.Employee_Code = JSAR.Create_User")
            Content.AppendLine("Inner Join PUB_Hospital PH On PH.Hospital_Code = JSAR.Hospital_Code")
            Content.AppendLine("Inner Join PRJ_Project PP On PP.Project_ID = JSAR.Project_ID")
            Content.AppendLine("Inner Join PRJ_Project_System PPS On PPS.Project_ID = PP.Project_ID And PPS.System_Code=JSAR.System_Code")
            Content.AppendLine("Inner Join PRJ_Project_System_Function PPSF On PPSF.Project_ID = PP.Project_ID And PPSF.System_Code=JSAR.System_Code And PPSF.Function_Code=JSAR.Function_Code")
            Content.AppendLine("Where 1=1")
            If HospCode <> "" Then
                Content.AppendLine("  And JSAR.Hospital_Code=@Hospital_Code")
            End If
            If ProjectId <> "" Then
                Content.AppendLine("  And JSAR.Project_ID=@ProjectId")
            End If
            If SystemCode <> "" Then
                Content.AppendLine("  And JSAR.System_Code=@SystemCode")
            End If
            If FunctionCode <> "" Then
                Content.AppendLine("  And JSAR.Function_Code=@FunctionCode")
            End If
            If CreateUser <> "" Then
                Content.AppendLine("  And JSAR.Create_User=@CreateUser")
            End If
            If SDate <> "" AndAlso EDate <> "" Then
                Content.AppendLine("  And JSAR.Create_Time Between @SDate And @EDate")
            ElseIf SDate <> "" Then
                Content.AppendLine("  And JSAR.Create_Time >= @SDate  ")
            ElseIf EDate <> "" Then
                Content.AppendLine("  And JSAR.Create_Time <= @EDate  ")
            End If
            Content.AppendLine("  And ISNULL(JSAR.Cancel,'') <> 'N'")
            Content.AppendLine("order by JSAR.Assign_Date,Assign_User")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            If HospCode <> "" Then
                command.Parameters.AddWithValue("@Hospital_Code", HospCode)
            End If
            If ProjectId <> "" Then
                command.Parameters.AddWithValue("@ProjectId", ProjectId)
            End If
            If SystemCode <> "" Then
                command.Parameters.AddWithValue("@SystemCode", SystemCode)
            End If
            If FunctionCode <> "" Then
                command.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            End If
            If CreateUser <> "" Then
                command.Parameters.AddWithValue("@CreateUser", CreateUser)
            End If
            If SDate <> "" Then
                command.Parameters.AddWithValue("@SDate", SDate)
            End If
            If EDate <> "" Then
                command.Parameters.AddWithValue("@EDate", EDate)
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


#End Region

#Region "查詢未處理所屬專案系統需求單"

#Region " 查詢未解決需求紀錄 "

    ''' <summary>
    ''' 查詢未解決需求紀錄
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-07-28</remarks>
    Public Function QueryUnfinishIssueRecordList(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As DataSet
            Dim StartDate As String = ds.Tables(0).Rows(0).Item("Start_Date").ToString.Trim
            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("")
            Content.AppendLine("             Select  Convert(Char,JSR.Receive_DateTime,120) Receive_Date")
            Content.AppendLine("					,RTRIM(JSR.Issue_Classify) + '-' + RTRIM(PS.Code_En_Name) AS Issue_Classify ")
            Content.AppendLine("                    ,RTRIM(PP.Project_Name)  AS Project_Name ")
            Content.AppendLine("                    ,RTRIM(PH.Hospital_Short_Name)  AS Hospital_Short_Name ")
            Content.AppendLine("                    ,RTRIM(PPS.System_Name) AS System_Name ")
            Content.AppendLine("                    ,RTRIM(PPSF.Function_Name) AS Function_Name ")
            Content.AppendLine("                    ,Convert(char,JSR.Issue_Id) AS Issue_Id ")
            Content.AppendLine("					,RTRIM(JSR.Issue_Description) AS Issue_Description ")
            Content.AppendLine("					,RTRIM(PE.Employee_En_Name) AS Employee_En_Name ")
            Content.AppendLine("					,'Service' AS 'Source' ")
            Content.AppendLine("					,RTRIM(PP.Project_ID) Project_ID")
            Content.AppendLine("					,RTRIM(PPS.System_Code) System_Code")
            Content.AppendLine("					,RTRIM(PPSF.Function_Code) Function_Code")
            Content.AppendLine("					,RTRIM(PH.Hospital_Code) Hospital_Code")
            Content.AppendLine("					,RTRIM(JSR.Att_FID) Att_FID")
            Content.AppendLine("					,'' Test_Version")
            Content.AppendLine("					,'' Version_Id")
            Content.AppendLine("					,Estimated_Finish_Date")
            Content.AppendLine("               From JOB_Service_Record JSR ")
            Content.AppendLine("             Inner Join PUB_Syscode PS on PS.Type_Id='9999' and JSR.Issue_Classify =PS.Code_Id ")
            Content.AppendLine("             Inner Join  PRJ_Project PP on PP.Project_ID= JSR.Project_ID ")
            Content.AppendLine("             Inner Join  PRJ_Project_System PPS on PPS.Project_ID= JSR.Project_ID And PPS.System_Code=JSR.System_Code ")
            Content.AppendLine("             Inner Join  PRJ_Project_System_Function PPSF on PPSF.Project_ID= JSR.Project_ID And PPSF.System_Code=JSR.System_Code And PPSF.Function_Code=JSR.Function_Code ")
            Content.AppendLine("             Inner Join  PUB_Employee PE on PE.Employee_Code= JSR.Create_User ")
            Content.AppendLine("             INNER JOIN  PUB_Hospital as PH ON PH.Hospital_Code=JSR.Hospital_Code")
            Content.AppendLine("             Where 1=1 ")
            Content.AppendLine("			   And JSR.Issue_Status = '2'")
            Content.AppendLine("			   And JSR.Finish_Date is null")
            If IsDate(StartDate) Then
                Content.AppendLine("			   And JSR.Create_Time Between '" & StartDate & "' and getdate()")
            End If
            Content.AppendLine("			   And Isnull(JSR.Cancel,'') <> 'Y'")
            Content.AppendLine("			   Union All")
            Content.AppendLine("             Select  Convert(Char,JQBR.Create_Time,120) Receive_Date")
            Content.AppendLine("					,RTRIM(JQBR.Issue_Classify) + '-' + RTRIM(PS.Code_En_Name) AS Issue_Classify ")
            Content.AppendLine("                    ,RTRIM(PP.Project_Name)  AS Project_Name ")
            Content.AppendLine("                    ,RTRIM(PH.Hospital_Short_Name)  AS Hospital_Short_Name ")
            Content.AppendLine("                    ,RTRIM(PPS.System_Name) AS System_Name ")
            Content.AppendLine("                    ,RTRIM(PPSF.Function_Name) AS Function_Name ")
            Content.AppendLine("                    ,Convert(char,JQBR.Bug_Id) AS Issue_Id ")
            Content.AppendLine("					,RTRIM(JQBR.Issue_Desc) AS Issue_Description ")
            Content.AppendLine("					,RTRIM(PE.Employee_En_Name) AS Employee_En_Name ")
            Content.AppendLine("					,'QA' Source")
            Content.AppendLine("					,RTRIM(PP.Project_ID) Project_ID")
            Content.AppendLine("					,RTRIM(PPS.System_Code) System_Code")
            Content.AppendLine("					,RTRIM(PPSF.Function_Code) Function_Code")
            Content.AppendLine("					,RTRIM(JQTR.Hospital_Code) Hospital_Code")
            Content.AppendLine("		            ,RTRIM((Select Substring(AttQuery.FID,2,len(AttQuery.FID)) AS FID From(")
            Content.AppendLine("					 Select(")
            Content.AppendLine("						Select  ',' +  RTRIM(ATF.FID) ")
            Content.AppendLine("						  From Job_QA_Attached_Files ATF  ")
            Content.AppendLine("						 Where ATF.Bug_Id=JQBR.Bug_Id And ATF.Version_Id = JQBR.Version_Id")
            Content.AppendLine("					  FOR XML PATH('')) AS FID) AttQuery)) As Att_FID")
            Content.AppendLine("					,RTRIM(JQTR.Test_Version) Test_Version")
            Content.AppendLine("					,RTRIM(JQBR.Version_Id) Version_Id")
            Content.AppendLine("					,'' Estimated_Finish_Date")
            Content.AppendLine("               From Job_QA_Bug_Record JQBR ")
            Content.AppendLine("             Inner Join  Job_QA_Test_Record JQTR on JQTR.Version_Id= JQBR.Version_Id ")
            Content.AppendLine("             Inner Join  PUB_Syscode PS on PS.Type_Id='9005' and JQBR.Issue_Classify =PS.Code_Id  ")
            Content.AppendLine("             Inner Join  PRJ_Project PP on PP.Project_ID= JQTR.Project_ID ")
            Content.AppendLine("             Inner Join  PRJ_Project_System PPS on PPS.Project_ID= JQTR.Project_ID And PPS.System_Code=JQBR.System_Code ")
            Content.AppendLine("             Inner Join  PRJ_Project_System_Function PPSF on PPSF.Project_ID= JQTR.Project_ID And PPSF.System_Code=JQBR.System_Code And PPSF.Function_Code=JQBR.Function_Code ")
            Content.AppendLine("             Inner Join  PUB_Employee PE on PE.Employee_Code= JQBR.Create_User ")
            Content.AppendLine("             Inner Join  PUB_Hospital PH on PH.Hospital_Code= JQTR.Hospital_Code ")
            Content.AppendLine("             Where 1=1 ")
            Content.AppendLine("			   And JQBR.Test_Result in ('01')")
            If IsDate(StartDate) Then
                Content.AppendLine("			   And JQBR.Create_Time Between '" & StartDate & "' and getdate()")
            End If
            Content.AppendLine("Order By Project_Name,System_Name,Function_Name,Receive_Date")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet("Issue_List")
                adapter.Fill(retDS, "Issue_List")
            End Using

            Return retDS

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

#Region " 取得需求名稱 "

    ''' <summary>
    ''' 取得需求名稱
    ''' </summary>
    ''' <param name="CodeId" >CodeId</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function GetIssueNameByCodeId(ByVal CodeId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Code_Name From PUB_Syscode Where Type_Id='9999' And Code_Id=@CodeId"

            command.Parameters.AddWithValue("@CodeId", CodeId)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Syscode")
                adapter.Fill(ds, "PUB_Syscode")
            End Using

            Return ds.Tables(0).Rows(0)(0).ToString.Trim

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

#Region " 需求展期 "

    ''' <summary>
    ''' 需求展期
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-17</remarks>
    Public Function IssueExtension(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine(" update JOB_SA_Assign_Record set Issue_Deadline=@Issue_Deadline")
            Content.AppendLine(" where  JOB_Code=@JOB_Code     ")
            Content.AppendLine("")


            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                    command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))

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

#Region "     工作轉派"

    ''' <summary>
    ''' JOB轉派
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function SAJobTransfer(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet
            ds.Tables.Add(New DataTable("Result"))
            ds.Tables(0).Columns.Add("Result")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If
            'Mail通知PG
            Dim MailBody As New StringBuilder
            MailBody.AppendLine("此需求已由SD/SA重新分派，如有未完成工作請與相關人員聯絡並完成交接")
            MailBody.AppendLine("")
            SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.PG_Employee_Code, conn), GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, True)
            MailBody.Clear()
            Dim CCUser = JobMailGroupBO_E1.GetInstance.GetMailAddressFromGroup(input.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn)
            Dim FID As String = input.Tables(0).Rows(0).Item("FID").ToString.Trim
            Select Case input.Tables(0).Rows(0).Item("Source").ToString.Trim
                Case "2"
                    'Mail通知SD
                    MailBody.AppendLine("Dear ").Append(GetEmployeeName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.SD_Employee_Code, conn))
                    MailBody.AppendLine("")
                    MailBody.AppendLine("此需求已由SA重新分派，煩請協助覆核")
                    MailBody.AppendLine("")
                    SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.SD_Employee_Code, conn), GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, True)
                    MailBody.Clear()
                    MailBody = GetMailStringForPG(input.Tables(0).Rows(0).Item("JOB_Code"), queryByPK(input.Tables(0).Rows(0).Item("JOB_Code"), conn), Source.SA, conn)
                    '將資料轉至新的處理人員
                    Dim Content As New StringBuilder
                    Content.AppendLine("Update JOB_SA_Assign_Record ")
                    Content.AppendLine("   Set SD_Confirm = NULL,PG_Employee_Code=@PG_Employee_Code,Modified_User=@Modified_User,Modified_Time=getdate()")
                    Content.AppendLine(" Where JOB_Code=@JOB_Code")
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = Content.ToString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@PG_Employee_Code", input.Tables(0).Rows(0).Item("PG_Employee_Code"))
                        command.Parameters.AddWithValue("@JOB_Code", input.Tables(0).Rows(0).Item("JOB_Code"))
                        command.Parameters.AddWithValue("@Modified_User", input.Tables(0).Rows(0).Item("Modified_User"))

                        Dim cnt As Integer = command.ExecuteNonQuery
                        ds.Tables(0).Rows.Add(cnt)
                    End Using

                    If FID.Length > 0 Then
                        'Step.1 下載檔案
                        Dim obj As Object = FTMDelegate.getInstance.downloadFile(FID, False, conn)
                        'Step.3 取得檔案副檔名
                        Dim DataType As String = FID.Split(".")(1)
                        '(0) 檔案資料byte() , (1) client端的預設檔名
                        '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                        FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                        SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.PG_Employee_Code, conn), CCUser, GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1), True)
                    Else
                        SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.PG_Employee_Code, conn), CCUser, GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, True)
                    End If

                Case Else
                    '將資料轉至新的處理人員
                    Dim Content As New StringBuilder
                    Content.AppendLine("Update JOB_SA_Assign_Record ")
                    Content.AppendLine("   Set PG_Employee_Code=@PG_Employee_Code,Modified_User=@Modified_User,Modified_Time=getdate()")
                    Content.AppendLine(" Where JOB_Code=@JOB_Code")
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = Content.ToString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@PG_Employee_Code", input.Tables(0).Rows(0).Item("PG_Employee_Code"))
                        command.Parameters.AddWithValue("@JOB_Code", input.Tables(0).Rows(0).Item("JOB_Code"))
                        command.Parameters.AddWithValue("@Modified_User", input.Tables(0).Rows(0).Item("Modified_User"))

                        Dim cnt As Integer = command.ExecuteNonQuery
                        ds.Tables(0).Rows.Add(cnt)
                    End Using
                    MailBody.Clear()
                    MailBody = GetMailStringForPG(input.Tables(0).Rows(0).Item("JOB_Code"), queryByPK(input.Tables(0).Rows(0).Item("JOB_Code"), conn), Source.SD, conn)
                    If FID.Length > 0 Then
                        'Step.1 下載檔案
                        Dim obj As Object = FTMDelegate.getInstance.downloadFile(FID, False, conn)
                        'Step.3 取得檔案副檔名
                        Dim DataType As String = FID.Split(".")(1)
                        '(0) 檔案資料byte() , (1) client端的預設檔名
                        '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                        FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                        SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.PG_Employee_Code, conn), CCUser, GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, New MemoryStream(CType(obj(0), Byte())), obj(1), True)
                    Else
                        SendMail.getInstance.SendMail(GetEmailByColumnName(input.Tables(0).Rows(0).Item("JOB_Code"), pt.PG_Employee_Code, conn), CCUser, GetMailSubject(input.Tables(0).Rows(0).Item("JOB_Code"), conn), MailBody.ToString, True)
                    End If
            End Select

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

#Region "查詢派工單"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2018-09-04</remarks>
    Public Function QueryJobForModifiy(ByVal JOB_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet
        Try

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT *")
            Content.AppendLine("      ,'' as Action")
            Content.AppendLine("  FROM [JOB_SA_Assign_Record]")
            Content.AppendLine("Where Job_Code=@JOB_Code")
            Content.AppendLine("")



            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("JobData")
                adapter.Fill(ds, "JobData")
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

#Region "更新派工單"

    ''' <summary>
    ''' 更新派工單
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2018-09-17</remarks>
    Public Function JobModifiy(ByVal ds As DataSet) As DataSet

        Try
            Dim retDS As DataSet = New DataSet
            retDS.Tables.Add(New DataTable("Cnt"))
            retDS.Tables("Cnt").Columns.Add("Cnt")
            retDS.Tables(0).Rows.Add(update(ds))
            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        End Try

    End Function

#End Region


#End Region
End Class
