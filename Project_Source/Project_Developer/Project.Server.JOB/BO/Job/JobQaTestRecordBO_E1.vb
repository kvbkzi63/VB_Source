'/*
'*****************************************************************************
'*
'*    Page/Class Name:  QA工作管理
'*              Title:	JobQaTestRecordBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-10-01
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-10-01
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.SNC
Imports Syscom.Comm.Utility.StringUtil
Imports Project.Comm.JOB

Public Class JobQaTestRecordBO_E1
    Inherits JobQaTestRecordBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobQaTestRecordBO_E1
    Public Overloads Shared Function GetInstance() As JobQaTestRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobQaTestRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
#Region " 新增版次 "

    ''' <summary>
    ''' 新增版次
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function CreateNewTestVer(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet("Result")
        retDS.Tables.Add("Result")
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                row("Version_Id") = Now.ToString("yyyyMMdd") & row(JobQaTestRecordDataTableFactory.DBColumnName.Project_Id).ToString & row(JobQaTestRecordDataTableFactory.DBColumnName.Deploy_Kind).ToString & StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeA, "BUG_20170000", 0, 9999), CChar("0"), 4)
                row(JobQaTestRecordDataTableFactory.DBColumnName.Total_Amount) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Total_Closed) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Total_UnClose) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Total_UnTest) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Urgent_UnClose) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Urgent_Closed) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Important_Closed) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Important_UnClose) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Normal_Closed) = 0
                row(JobQaTestRecordDataTableFactory.DBColumnName.Normal_UnClose) = 0
            Next
            retDS.Tables(0).Rows.Add(insert(ds, conn))

            Return retDS

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

#End Region

#End Region

#Region "     修改 Method "

#Region " 更新版次說明 "

    ''' <summary>
    ''' 更新版次說明
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function UpdateVersionDesc(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("Result")
        retDS.Tables("Result").Columns.Add("cnt")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update Job_QA_Test_Record ")
            Content.AppendLine("   Set Version_Desc=@Version_Desc,")
            Content.AppendLine("	   Modified_User=@Modified_User,")
            Content.AppendLine("       Modified_Time=getdate()")
            Content.AppendLine("Where Version_Id=@Version_Id")
            Content.AppendLine(" ")
            Content.AppendLine("")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Version_Desc", ds.Tables(0).Rows(0).Item("Version_Desc"))
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User"))
                command.Parameters.AddWithValue("@Version_Id", ds.Tables(0).Rows(0).Item("Version_Id"))

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
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


#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#Region " 查詢版次列表 "

    ''' <summary>
    ''' 查詢版次列表
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function QueryTestVerByProjectAndDeployKind(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Version_Id")
            Content.AppendLine("      ,Project_Id")
            Content.AppendLine("      ,Deploy_Kind")
            Content.AppendLine("      ,Deploy_Date")
            Content.AppendLine("      ,Test_Version")
            Content.AppendLine("      ,Version_Desc")
            Content.AppendLine("      ,(Select count(JQBR1.Bug_Id) From Job_QA_Bug_Record JQBR1 Where JQBR1.Version_Id=JQTR.Version_Id) Total_Amount")
            Content.AppendLine("      ,(Select count(JQBR2.Bug_Id) From Job_QA_Bug_Record JQBR2 Where JQBR2.Version_Id=JQTR.Version_Id And JQBR2.Test_Result in ('01','02','03','04','05')) Total_UnClose")
            Content.AppendLine("      ,(Select count(JQBR3.Bug_Id) From Job_QA_Bug_Record JQBR3 Where JQBR3.Version_Id=JQTR.Version_Id And JQBR3.Test_Result in ('07','08','09','10')) Total_Closed")
            Content.AppendLine("      ,(Select count(JQBR4.Bug_Id) From Job_QA_Bug_Record JQBR4 Where JQBR4.Version_Id=JQTR.Version_Id And JQBR4.Test_Result in ('06')) Total_UnTest")
            Content.AppendLine("      ,(Select count(JQBR5.Bug_Id) From Job_QA_Bug_Record JQBR5 Where JQBR5.Version_Id=JQTR.Version_Id And JQBR5.Issue_Level = '1' And JQBR5.Test_Result in ('01','02','03','04','05')) Urgent_UnClose")
            Content.AppendLine("      ,(Select count(JQBR6.Bug_Id) From Job_QA_Bug_Record JQBR6 Where JQBR6.Version_Id=JQTR.Version_Id And JQBR6.Issue_Level = '1' And JQBR6.Test_Result in ('07','08','09','10')) Urgent_Closed")
            Content.AppendLine("      ,(Select count(JQBR7.Bug_Id) From Job_QA_Bug_Record JQBR7 Where JQBR7.Version_Id=JQTR.Version_Id And JQBR7.Issue_Level = '2' And JQBR7.Test_Result in ('01','02','03','04','05')) Important_UnClose")
            Content.AppendLine("      ,(Select count(JQBR8.Bug_Id) From Job_QA_Bug_Record JQBR8 Where JQBR8.Version_Id=JQTR.Version_Id And JQBR8.Issue_Level = '2' And JQBR8.Test_Result in ('07','08','09','10'))  Important_Closed")
            Content.AppendLine("      ,(Select count(JQBR9.Bug_Id) From Job_QA_Bug_Record JQBR9 Where JQBR9.Version_Id=JQTR.Version_Id And JQBR9.Issue_Level = '3' And JQBR9.Test_Result in ('01','02','03','04','05',NULL)) Normal_UnClose")
            Content.AppendLine("      ,(Select count(JQBR10.Bug_Id) From Job_QA_Bug_Record JQBR10 Where JQBR10.Version_Id=JQTR.Version_Id And JQBR10.Issue_Level = '3' And JQBR10.Test_Result in ('07','08','09','10'))  Normal_Closed")
            Content.AppendLine("      ,Close_Flag")
            Content.AppendLine("  FROM Job_QA_Test_Record JQTR")
            Content.AppendLine(" Where Project_Id=@Project_Id")
            Content.AppendLine("   And Deploy_Kind=@Deploy_Kind")
            Content.AppendLine("   And Hospital_Code=@Hospital_Code")
            Content.AppendLine("Order By Test_Version Desc")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Project_Id", input.Tables(0).Rows(0).Item("Project_Id"))
            command.Parameters.AddWithValue("@Deploy_Kind", input.Tables(0).Rows(0).Item("Deploy_Kind"))
            command.Parameters.AddWithValue("@Hospital_Code", input.Tables(0).Rows(0).Item("Hospital_Code"))

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

#Region " 取得最大版號 "

    ''' <summary>
    ''' 取得最大版號
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function GetMaxTestVersionBeforeCreate(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT isnull(Max(Test_Version),0)")
            Content.AppendLine("  FROM Job_QA_Test_Record")
            Content.AppendLine(" Where Project_Id=@Project_Id")
            Content.AppendLine("   And Deploy_Kind=@Deploy_Kind")
            Content.AppendLine("   And Hospital_Code=@Hospital_Code")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Project_Id", input.Tables(0).Rows(0).Item("Project_Id"))
            command.Parameters.AddWithValue("@Deploy_Kind", input.Tables(0).Rows(0).Item("Deploy_Kind"))
            command.Parameters.AddWithValue("@Hospital_Code", input.Tables(0).Rows(0).Item("Hospital_Code"))

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

#Region " 查看BUG清單 "

    ''' <summary>
    ''' 查看BUG清單
    ''' </summary>
    ''' <param name="input" ></param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function QueryBugRecord(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("Select RTRIM(JQR.Bug_Id) As Bug_Id")
            Content.AppendLine("	  ,RTRIM(JQR.Create_User) As Modified_User")
            Content.AppendLine("	  ,RTRIM(PE.Employee_Name) As Test_Employee_Name")
            Content.AppendLine("	  ,RTRIM(PH.Hospital_Code) As Hospital_Code")
            Content.AppendLine("	  ,RTRIM(PH.Hospital_Short_Name) As Hospital_Name")
            Content.AppendLine("	  ,RTRIM(JQR.Test_Result) As 'Status'")
            Content.AppendLine("	  ,RTRIM(JQR.Issue_Classify) As Issue_Classify")
            Content.AppendLine("	  ,RTRIM(JQR.Issue_Level) As Issue_Level")
            Content.AppendLine("	  ,RTRIM(JQR.Issue_Subject) As Issue_Subject")
            Content.AppendLine("	  ,RTRIM(JQTR.Test_Version) As Test_Version")
            Content.AppendLine("	  ,RTRIM(JQTR.Version_Id) As Version_Id")
            Content.AppendLine("  From Job_QA_Bug_Record JQR")
            Content.AppendLine("  Inner Join PUB_Employee PE On JQR.Create_User = PE.Employee_Code")
            Content.AppendLine("  Inner Join Job_QA_Test_Record JQTR On JQTR.Version_Id = JQR.Version_Id")
            Content.AppendLine("  Inner Join PUB_Hospital PH On PH.Hospital_Code = JQTR.Hospital_Code")
            Content.AppendLine("Where 1=1")
            If input.Tables(0).Rows(0).Item("Version_Id").ToString.Length > 0 Then
                Content.AppendLine("  And JQR.Version_Id=@Version_Id")
            End If
            If input.Tables(0).Rows(0).Item("Create_User").ToString.Length > 0 Then
                Content.AppendLine("  And JQR.Create_User=@Create_User")
            End If
            If input.Tables(0).Rows(0).Item("Hospital_Code").ToString.Length > 0 Then
                Content.AppendLine("  And JQTR.Hospital_Code=@Hospital_Code")
            End If
            If input.Tables(0).Rows(0).Item("Project_Id").ToString.Length > 0 Then
                Content.AppendLine("  And JQTR.Project_Id=@Project_Id")
            End If
            If input.Tables(0).Rows(0).Item("Deploy_Kind").ToString.Length > 0 Then
                Content.AppendLine("  And JQTR.Deploy_Kind=@Deploy_Kind")
            End If
            Select Case input.Tables(0).Rows(0).Item("Test_Result").ToString
                Case "StillWatting"
                    Content.AppendLine("  And JQR.Test_Result='06'")

                Case "UnClose"
                    Content.AppendLine("  And JQR.Test_Result not in ('07')")
            End Select
            Content.AppendLine("")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            If input.Tables(0).Rows(0).Item("Version_Id").ToString.Length > 0 Then
                command.Parameters.AddWithValue("@Version_Id", input.Tables(0).Rows(0).Item("Version_Id"))
            End If
            If input.Tables(0).Rows(0).Item("Create_User").ToString.Length > 0 Then
                command.Parameters.AddWithValue("@Create_User", input.Tables(0).Rows(0).Item("Create_User"))
            End If
            If input.Tables(0).Rows(0).Item("Hospital_Code").ToString.Length > 0 Then
                command.Parameters.AddWithValue("@Hospital_Code", input.Tables(0).Rows(0).Item("Hospital_Code"))
            End If
            If input.Tables(0).Rows(0).Item("Project_Id").ToString.Length > 0 Then
                command.Parameters.AddWithValue("@Project_Id", input.Tables(0).Rows(0).Item("Project_Id"))
            End If
            If input.Tables(0).Rows(0).Item("Deploy_Kind").ToString.Length > 0 Then
                command.Parameters.AddWithValue("@Deploy_Kind", input.Tables(0).Rows(0).Item("Deploy_Kind"))
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

#Region "匯出報表"

    Public Function ExportTestRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("    Select RTRIM(BUG_ID) BUG_ID ")
            If ds.Tables("Action").Rows(0).Item("Test_Version") Then
                Content.AppendLine("		  ,RTRIM(JQTR.Test_Version) '測得版次'")
            End If
            If ds.Tables("Action").Rows(0).Item("System_Name") Then
                Content.AppendLine("		  ,RTRIM(PPS.System_Name) '所屬子系統'")
            End If
            If ds.Tables("Action").Rows(0).Item("Function_Name") Then
                Content.AppendLine("		  ,RTRIM(PPSF.Function_Name) '所屬功能'")
            End If
            If ds.Tables("Action").Rows(0).Item("Status") Then
                Content.AppendLine("		  ,RTRIM(PS.Code_Name) 'Status'")
            End If
            If ds.Tables("Action").Rows(0).Item("Issue_Subject") Then
                Content.AppendLine("		  ,RTRIM(JQBR.Issue_Subject) '問題主旨'")
            End If
            If ds.Tables("Action").Rows(0).Item("Issue_Desc") Then
                Content.AppendLine("		  ,RTRIM(JQBR.Issue_Desc) '問題描述'")
            End If
            If ds.Tables("Action").Rows(0).Item("Issue_Classify") Then
                Content.AppendLine("		  ,RTRIM(PS1.Code_Name) '問題類別'")
            End If
            If ds.Tables("Action").Rows(0).Item("Issue_Level") Then
                Content.AppendLine("		  ,RTRIM(PS2.Code_Name) '嚴重性'")
            End If
            If ds.Tables("Action").Rows(0).Item("Test_Employee_Name") Then
                Content.AppendLine("		  ,RTRIM(PE.Employee_Name) '測試者'")
            End If
            Content.AppendLine("      From Job_QA_Test_Record JQTR")
            Content.AppendLine("Inner Join Job_QA_Bug_Record JQBR On JQBR.Version_Id=JQTR.Version_Id")
            Content.AppendLine("Inner Join PRJ_Project PP On PP.Project_ID=JQTR.Project_ID")
            Content.AppendLine("Inner Join PRJ_Project_System PPS On PPS.Project_ID=PP.Project_ID ")
            Content.AppendLine("Inner Join PRJ_Project_System_Function PPSF On PPSF.Project_ID=PPS.Project_ID And PPSF.System_Code=PPS.System_Code And PPSF.Function_Code=JQBR.Function_Code")
            Content.AppendLine("Inner Join PUB_Syscode PS On PS.Type_Id='9006' And PS.Code_Id=JQBR.Test_Result")
            Content.AppendLine("Inner Join PUB_Syscode PS1 On PS1.Type_Id='9005' And PS1.Code_Id=JQBR.Issue_Classify")
            Content.AppendLine("Inner Join PUB_Syscode PS2 On PS2.Type_Id='9004' And PS2.Code_Id=JQBR.Issue_Level")
            Content.AppendLine("Inner Join PUB_Employee PE On PE.Employee_Code=JQBR.Modified_User")
            Content.AppendLine("Where JQTR.Project_Id=@Project_Id")
            Content.AppendLine("  And JQTR.Deploy_Kind=@Deploy_Kind")
            If ds.Tables("Action").Rows(0).Item("Test_Version_Condition").ToString.Trim <> "" Then
                Content.AppendLine("  And JQTR.Test_Version=@Test_Version_Condition")
            End If
            Content.AppendLine("And JQTR.Hospital_Code=@Hospital_Code")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Project_Id", ds.Tables(0).Rows(0).Item("Project_Id"))
            command.Parameters.AddWithValue("@Deploy_Kind", ds.Tables(0).Rows(0).Item("Deploy_Kind"))
            If ds.Tables("Action").Rows(0).Item("Test_Version_Condition").ToString.Trim <> "" Then
                command.Parameters.AddWithValue("@Test_Version_Condition", ds.Tables(0).Rows(0).Item("Test_Version_Condition"))
            End If
            command.Parameters.AddWithValue("@Hospital_Code", ds.Tables(0).Rows(0).Item("Hospital_Code"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet(tableName)
                adapter.Fill(retDS, tableName)
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

End Class

