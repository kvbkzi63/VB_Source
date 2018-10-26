Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class JobDoActionBS

    Private Sub New()

    End Sub

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobDoActionBS
    Public Overloads Shared Function GetInstance() As JobDoActionBS
        If myInstance Is Nothing Then
            myInstance = New JobDoActionBS
        End If
        Return myInstance
    End Function

#End Region

    Public Function PRJDoAction(ByVal ds As DataSet) As DataSet
        Try

            Dim action As String = ds.Tables(0).Rows(0).Item("Action").ToString.Trim

            Select Case action
                Case "QueryJobProjectMaintainData"
                    Return JobProjectMaintainBO_E1.GetInstance.QueryJobProjectMaintainData(ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim,
                                                                                           ds.Tables(0).Rows(0).Item("Project_Name").ToString.Trim,
                                                                                           ds.Tables(0).Rows(0).Item("Start_Date").ToString.Trim,
                                                                                           ds.Tables(0).Rows(0).Item("End_Date").ToString.Trim,
                                                                                           ds.Tables(0).Rows(0).Item("Project_Manager").ToString.Trim)
                Case "InsertNewProject"
                    Return JobProjectMaintainBO_E1.GetInstance.InsertNewProject(ds)
                Case "InsertNewSystem"
                    Return JobProjectMaintainBO_E1.GetInstance.InsertNewSystem(ds)
                Case "InsertNewFunction"
                    Return JobProjectMaintainBO_E1.GetInstance.InsertNewFunction(ds)
                Case "UpdateProject"
                    Return JobProjectMaintainBO_E1.GetInstance.UpdateProject(ds)
                Case "UpdateProjectSystem"
                    Return JobProjectMaintainBO_E1.GetInstance.UpdateProjectSystem(ds)
                Case "UpdateProjectFunction"
                    Return JobProjectMaintainBO_E1.GetInstance.UpdateProjectFunction(ds)
                Case "QueryJobProjectSystem"
                    Return JobProjectMaintainBO_E1.GetInstance.QueryJobProjectSystem(ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim)
                Case "QueryJobProjectSystemFunction"
                    Return JobProjectMaintainBO_E1.GetInstance.QueryJobProjectSystemFunction(ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim, ds.Tables(0).Rows(0).Item("System_Code").ToString.Trim)
                Case "DeleteProject"
                    Return JobProjectMaintainBO_E1.GetInstance.DeleteProject(ds)
                Case "DeleteProjectSystem"
                    Return JobProjectMaintainBO_E1.GetInstance.DeleteProjectSystem(ds)
                Case "DeleteProjectSystemFunction"
                    Return JobProjectMaintainBO_E1.GetInstance.DeleteProjectSystemFunction(ds)
                Case "initialSAAssignJobUI"
                    Return JobSAAssignRecordBO_E1.GetInstance.initialSAAssignJobUI(ds.Tables(0).Rows(0).Item("Employee_Code"))
                Case "AssignNewJOB"
                    Return JobSAAssignRecordBO_E1.GetInstance.AssignNewJOB(ds)
                Case "QueryJobList"
                    Return JobSAAssignRecordBO_E1.GetInstance.QueryJobList(ds)
                Case "QyeryPGJobList"
                    Return JobPGJobBO_E1.GetInstance.QyeryPGJobList(ds)
                Case "UpdatePGJobSubmit"
                    Return JobPGJobBO_E1.GetInstance.UpdatePGJobSubmit(ds)
                Case "ReplyPGSubmit"
                    Return JobSAAssignRecordBO_E1.GetInstance.ReplyJobSubmit(ds)
                Case "InitialSAReplyDialogUI"
                    Return JobSAAssignRecordBO_E1.GetInstance.InitialSAReplyDialogUI(ds)
                Case "ApplyDBModified"
                    Return JobSAAssignRecordBO_E1.GetInstance.ApplyDBModified(ds)
                Case "QuerySADBModifyRecord"
                    Return JobDBModifiyBO_E1.GetInstance.QuerySADBModifyRecord(ds)
                Case "QueryDBModifyInitialData"
                    Return JobDBModifiyBO_E1.GetInstance.QueryDBModifyInitialData(ds)
                Case "DBAReplyModify"
                    Return JobDBModifiyBO_E1.GetInstance.DBAReplyModify(ds)
                Case "CancelJob"
                    Return JobSAAssignRecordBO_E1.GetInstance.CancelJob(ds)
                Case "QueryMailGroup"
                    Return JobMailGroupBO_E1.GetInstance.QueryJobMailGroup(ds)
                Case "QueryMailGroupDetail"
                    Return JobMailGroupBO_E1.GetInstance.QueryJobMailGroupDetail(ds)
                Case "DeleteMailGroup"
                    Return JobMailGroupBO_E1.GetInstance.DeleteMailGroup(ds)
                Case "DeleteMailGroupDetail"
                    Return JobMailGroupBO_E1.GetInstance.DeleteMailGroupDetail(ds)
                Case "InsertMailGroup"
                    Return JobMailGroupBO_E1.GetInstance.InsertNewMailGroup(ds)
                Case "InsertMailGroupDetail"
                    Return JobMailGroupBO_E1.GetInstance.InsertMailGroupDetail(ds)
                Case "UpdateMailGroup"
                    Return JobMailGroupBO_E1.GetInstance.UpdateMailGroup(ds)
                Case "UpdateMailGroupDetail"
                    Return JobMailGroupBO_E1.GetInstance.UpdateMailGroupDetail(ds)
                Case "QueryEmployeeListByLevel"
                    Return QueryEmployeeListByLevel(ds.Tables(0).Rows(0).Item("Level"))
                Case "SDConfirmJOB"
                    Return JobSAAssignRecordBO_E1.GetInstance.SDConfirmJOB(ds)
                Case "InitialJOBEmployeeMaintainUI"
                    Return JobEmployeeMaintainBO_E1.GetInstance.InitialJobEmployeeMaintainUI
                Case "InsertJobEmployeeMaintainUI"
                    Return JobEmployeeMaintainBO_E1.GetInstance.InsertJobEmployeeMaintainUI(ds)
                Case "UpdateJobEmployeeMaintainUI"
                    Return JobEmployeeMaintainBO_E1.GetInstance.UpdateJobEmployeeMaintainUI(ds)
                Case "DeleteJobEmployeeMaintainUI"
                    Return JobEmployeeMaintainBO_E1.GetInstance.DeleteJobEmployeeMaintainUI(ds)
                Case "QueryJobEmployeeMaintainUI"
                    Return JobEmployeeMaintainBO_E1.GetInstance.QueryJobEmployeeMaintainUI(ds)
                Case "QueryServiceRecordList"
                    Return JobServiceRecordBO_E1.GetInstance.QueryServiceRecordList(ds)
                Case "CreateNewIssueRecord"
                    Return JobServiceRecordBO_E1.GetInstance.CreateNewIssueRecord(ds)
                Case "QueryUnfinishIssueRecordList"
                    Return JobSAAssignRecordBO_E1.GetInstance.QueryUnfinishIssueRecordList(ds)
                Case "CreateTempMailGroup"
                    Return JobMailGroupBO_E1.GetInstance.CreateTempMailGroup(ds)
                Case "ImportSystemAndFunctionList"
                    Return JobProjectMaintainBO_E1.GetInstance.ImportSystemAndFunctionList(ds)
                Case "CancelServiceRecord"
                    Return JobServiceRecordBO_E1.GetInstance.CancelServiceRecord(ds)
                Case "LoarRejectRecord"
                    Return JobServiceReplyRecordBO_E1.GetInstance.QueryServiceRejectRecord(ds)
                Case "CreateNewServiceRejectRecord"
                    Return JobServiceReplyRecordBO_E1.GetInstance.CreateNewServiceRejectRecord(ds)
                Case "QuerySystemDataByProjectID"
                    Return QuerySystemDataByProjectID(ds.Tables(0).Rows(0).Item("Project_ID").ToString)
                Case "QueryFunctionDataByProjectIDandSystemCode"
                    Return QueryFunctionDataByProjectIDandSystemCode(ds.Tables(0).Rows(0).Item("Project_ID").ToString, ds.Tables(0).Rows(0).Item("System_Code").ToString)
                Case "QueryTestVerByProjectAndDeployKind"
                    Return JobQaTestRecordBO_E1.GetInstance.QueryTestVerByProjectAndDeployKind(ds)
                Case "CreateNewTestVer"
                    Return JobQaTestRecordBO_E1.GetInstance.CreateNewTestVer(ds)
                Case "GetMaxTestVersionBeforeCreate"
                    Return JobQaTestRecordBO_E1.GetInstance.GetMaxTestVersionBeforeCreate(ds)
                Case "CreateNewBug"
                    Return JobQaBugRecordBO_E1.GetInstance.CreateNewBug(ds)
                Case "UpdateVersionDesc"
                    Return JobQaTestRecordBO_E1.GetInstance.UpdateVersionDesc(ds)
                Case "QueryBugRecord"
                    Return JobQaTestRecordBO_E1.GetInstance.QueryBugRecord(ds)
                Case "QueryBugDetailForModifiy"
                    Return JobQaBugRecordBO_E1.GetInstance.QueryBugDetailForModifiy(ds)
                Case "UpdateBugRecordForRetest"
                    Return JobQaBugRecordBO_E1.GetInstance.UpdateBugRecordForRetest(ds)
                Case "InitialJobNoteGrid"
                    Return JobQaBugRecordBO_E1.GetInstance.InitialJobNoteGrid(ds)
                Case "TestVersionClose"
                    Return JobQaBugRecordBO_E1.GetInstance.TestVersionClose(ds)
                Case "CheckJobStatusBeforeClose"
                    Return JobQaBugRecordBO_E1.GetInstance.CheckJobStatusBeforeClose(ds)
                Case "IssueExtension"
                    Return JobSAAssignRecordBO_E1.GetInstance.IssueExtension(ds)
                Case "ServerRecordExport"
                    Return JobServiceRecordBO_E1.GetInstance.QueryServiceRecordForExportReport(ds)
                Case "ModifyIssueRecord"
                    Return JobServiceRecordBO_E1.GetInstance.ModifyIssueRecord(ds)
                Case "QueryJobAssignRecord"
                    Return JobSAAssignRecordBO_E1.GetInstance.QueryJobAssignRecord(ds)
                Case "GetSpecRecord"
                    Return GetSpecRecord(ds.Tables(0).Rows(0).Item("Job_Code"))
                Case "SAJobTransfer"
                    Return JobSAAssignRecordBO_E1.GetInstance.SAJobTransfer(ds)
                Case "ExportTestRecord"
                    Return JobQaTestRecordBO_E1.GetInstance.ExportTestRecord(ds)
                Case "UpdateJobStatus"
                    Return JobPGJobBO_E1.GetInstance.UpdateJobStatus(ds)
                Case "QueryPhraseList"
                    Return JobPhraseBO_E1.GetInstance.QueryPhrasebyCond(ds)
                Case "InsertIntoPhrase"
                    Return JobPhraseBO_E1.GetInstance.InsertInto(ds)
                Case "UpdatePhrase"
                    Return JobPhraseBO_E1.GetInstance.UpdatePhrase(ds)
                Case "DeletePhrase"
                    Return JobPhraseBO_E1.GetInstance.deletePhrase(ds)
                Case "QueryJobForModifiy"
                    Return JobSAAssignRecordBO_E1.GetInstance.QueryJobForModifiy(ds.Tables(0).Rows(0).Item("Job_Code"))
                Case "JobModifiy"
                    Return JobSAAssignRecordBO_E1.GetInstance.JobModifiy(ds)
                Case Else
                    Return Nothing
            End Select


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PRJDoAction"})
        End Try
        Return Nothing
    End Function

#Region " 查詢員工基本檔 "

    ''' <summary>
    ''' 查詢PG員工基本檔
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function QueryEmployeeListByLevel(ByVal Level As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Employee_Code,Employee_Name,Employee_En_Name,EMail From PUB_Employee Where Nrs_Level_Id >= '" & Level & "' and Assume_End_Date is null Order By Employee_En_Name"


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Employee")
                adapter.Fill(ds, "PUB_Employee")
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

#Region " 查詢附件紀錄 "

    ''' <summary>
    ''' 查詢附件紀錄
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Public Function GetSpecRecord(ByVal JOB_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim Content As New StringBuilder
            Content.AppendLine("Select Case When JSS.Source='3' Then 'SD'")
            Content.AppendLine("	   Else 'SA' End Source")
            Content.AppendLine("	  ,PE.Employee_Name Create_User")
            Content.AppendLine("	  ,convert(char, JSS.Create_Time, 111) Create_Time")
            Content.AppendLine("	  ,JSS.FID")
            Content.AppendLine("  From JOB_SA_SpecFiles JSS")
            Content.AppendLine("Inner Join PUB_Employee PE On PE.Employee_Code=JSS.Create_User")
            Content.AppendLine(" Where JOB_Code=@JOB_Code")
            Content.AppendLine("")

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("JOB_SA_SpecFiles")
                adapter.Fill(ds, "JOB_SA_SpecFiles")
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


#Region "     查詢專案與系統所屬功能"

#Region " 查詢歸屬功能 "

    ''' <summary>
    ''' 查詢歸屬功能
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-09-30</remarks>
    Public Function QueryFunctionDataByProjectIDandSystemCode(ByVal ProjectID As String, ByVal SystemCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Project_ID]")
            Content.AppendLine("      ,[System_Code]")
            Content.AppendLine("      ,[Function_Code]")
            Content.AppendLine("      ,[Function_Name]")
            Content.AppendLine("  FROM [PRJ_Project_System_Function]")
            Content.AppendLine("  Where Project_Id=@ProjectID")
            Content.AppendLine("    And System_Code=@SystemCode")
            Content.AppendLine("    And ISNULL(Dc,'N')='N'")
            Content.AppendLine(" Order By Function_Name")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@ProjectID", ProjectID)
            command.Parameters.AddWithValue("@SystemCode", SystemCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PRJ_Project_System_Function")
                adapter.Fill(ds, "PRJ_Project_System_Function")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢歸屬功能"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 查詢所屬系統 "

    ''' <summary>
    ''' 查詢所屬系統
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-09-30</remarks>
    Public Function QuerySystemDataByProjectID(ByVal ProjectID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Project_ID]")
            Content.AppendLine("      ,[System_Code]")
            Content.AppendLine("      ,[System_Name]")
            Content.AppendLine("      ,[SA_Employee_Code]")
            Content.AppendLine("  FROM [PRJ_Project_System]")
            Content.AppendLine(" Where Project_Id=@ProjectID")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@ProjectID", ProjectID)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PRJ_Project_System")
                adapter.Fill(ds, "PRJ_Project_System")
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

End Class
