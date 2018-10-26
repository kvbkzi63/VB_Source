
Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Project.Comm.JOB
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Public Class JobPGJobBO_E1

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobPGJobBO_E1
    Public Overloads Shared Function GetInstance() As JobPGJobBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobPGJobBO_E1
        End If
        Return myInstance
    End Function

#End Region


#Region " 查詢PG工作清單 "

    ''' <summary>
    ''' 查詢PG工作清單
    ''' </summary>
    ''' <param name="ds" >傳入員工號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Public Function QyeryPGJobList(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim employeeCode As String = ds.Tables(0).Rows(0).Item("Employee_Code").ToString.Trim
        Dim status As String = ds.Tables(0).Rows(0).Item("Status").ToString.Trim
        Dim SDate As String = ds.Tables(0).Rows(0).Item("AssignDateS").ToString.Trim
        Dim EDate As String = ds.Tables(0).Rows(0).Item("AssignDateE").ToString.Trim
        Try
            Dim retds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT RTRIM(JSAR.JOB_Code) JOB_Code")
            Content.AppendLine("      ,RTRIM(JSAR.Assign_Date) Assign_Date")
            Content.AppendLine("      ,RTRIM(JSAR.Project_ID) Project_ID")
            Content.AppendLine("	  ,RTRIM(PP.Project_Name) Project_Name")
            Content.AppendLine("      ,RTRIM(PE.Employee_En_Name) Assign_User")
            Content.AppendLine("      ,RTRIM(JSAR.Finish_Date) Finish_Date")
            Content.AppendLine("      ,RTRIM(JSAR.System_Code) System_Code")
            Content.AppendLine("	  ,RTRIM(PPS.System_Name) System_Name")
            Content.AppendLine("      ,RTRIM(JSAR.Function_Code) Function_Code")
            Content.AppendLine("	  ,RTRIM(PPSF.Function_Name) Function_Name")
            Content.AppendLine("      ,RTRIM(JSAR.Issue_Classify) Issue_Classify")
            Content.AppendLine("      ,Case When JSAR.SD_Issue_Deadline is Null Then Issue_Deadline")
            Content.AppendLine("	   Else JSAR.SD_Issue_Deadline End Issue_Deadline")
            Content.AppendLine("      ,RTRIM(JSAR.Issue_Desc) Issue_Desc")
            Content.AppendLine("      ,RTRIM(JSAR.Reply_Date) Reply_Date")
            Content.AppendLine("	  ,RTRIM(PE.Employee_En_Name) Employee_En_Name")
            Content.AppendLine("      ,RTRIM(JSAR.Create_User) Create_User")
            Content.AppendLine("      ,RTRIM(JSAR.Create_Time) Create_Time")
            Content.AppendLine("      ,RTRIM(JSAR.Modified_User) Modified_User")
            Content.AppendLine("      ,RTRIM(JSAR.Modified_Time) Modified_Time")
            Content.AppendLine("      ,RTRIM(JSAR.FID) FID")
            Content.AppendLine("      ,RTRIM(JSAR.RTF_FID) RTF_FID")
            Content.AppendLine("      ,RTRIM(JSAR.Reject_Flag) Reject_Flag")
            Content.AppendLine("      ,RTRIM(JSAR.Cancel) Cancel")
            Content.AppendLine("      ,(SELECT Count(Seq_No)+ 1 Seq_No FROM JOB_PG_JOB_Record Where System_Code=JSAR.System_Code And Create_User=JSAR.PG_Employee_Code And  CONVERT(char(10), Create_Time, 20)=@Create_Time) Seq_No")
            Content.AppendLine("      ,RTRIM(JSAR.[Mail_Subject]) Mail_Subject")
            Content.AppendLine("      ,RTRIM(JSAR.[Test_Report_Flag]) Test_Report_Flag")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Short_Name]) Hospital_Short_Name")
            Content.AppendLine("      ,RTRIM(PH.[Hospital_Code]) Hospital_Code")
            Content.AppendLine("      ,Case ISNULL((Select TOP 1 FID From JOB_PG_JOB_Record PJR Where PJR.JOB_Code=JSAR.JOB_Code Order By Create_Time Desc),'') ")
            Content.AppendLine("	   When '' Then 'N'")
            Content.AppendLine("	   Else 'Y' End Uploaded")
            Content.AppendLine("	  ,RTRIM(JSAR.[SD_Note]) SD_Note")
            Content.AppendLine("	  ,RTRIM(JSAR.Issue_Deadline) SA_Deadline")
            Content.AppendLine("	  ,RTRIM(JSAR.Estimate_Cost) SA_Cost")
            Content.AppendLine("	  ,RTRIM(JSAR.SD_Issue_Deadline) SD_Deadline")
            Content.AppendLine("	  ,RTRIM(JSAR.SD_Estimate_Cost) SD_Cost")
            Content.AppendLine("	  ,Case When ISNULL(JSAR.Reply_Date,'') <> '' Then '2'")
            Content.AppendLine("	   Else ISNULL((Select Top 1 Status From JOB_PG_JOB_Status_Record JPJSR Where JPJSR.JOB_Code=JSAR.JOB_Code Order By Create_Time Desc),'0') ")
            Content.AppendLine("	   End JOB_Status")
            Content.AppendLine("	  ,RTRIM(JSAR.Job_Special_Status) Job_Special_Status")
            Content.AppendLine("  FROM JOB_SA_Assign_Record JSAR")
            Content.AppendLine("Inner Join PUB_Employee PE On JSAR.Create_User=PE.Employee_Code")
            Content.AppendLine("Inner Join PRJ_Project PP On PP.Project_ID=JSAR.Project_ID")
            Content.AppendLine("Inner Join PRJ_Project_System PPS On PPS.Project_ID=JSAR.Project_ID And PPS.System_Code=JSAR.System_Code")
            Content.AppendLine("Inner Join PRJ_Project_System_Function PPSF On PPSF.Project_ID=JSAR.Project_ID And PPSF.System_Code=JSAR.System_Code And PPSF.Function_Code=JSAR.Function_Code")
            Content.AppendLine("Left Join PUB_Hospital PH On PH.Hospital_Code =JSAR.Hospital_Code")
            Content.AppendLine("Where PG_Employee_Code=@PG_Employee_Code")
            Select Case status
                Case "Finish"
                    Content.AppendLine("And Finish_Date is not null")
                Case "UnFinish"
                    Content.AppendLine("And Finish_Date is null")
                Case "Reply"
                    Content.AppendLine("And Reply_Date is not null")
                Case "UnProcess"
                    Content.AppendLine(" And Finish_Date Is null")
                    Content.AppendLine(" And isnull(Reply_Date,'') = '' ")
                    Content.AppendLine(" And isnull(JSAR.Cancel,'') = '' ")
                Case "Cancel"
                    Content.AppendLine(" And isnull(JSAR.Cancel,'') = 'Y' ")
            End Select

            If SDate.Length > 0 Then
                Content.AppendLine("And Assign_Date >= @SDate")

            End If

            If EDate.Length > 0 Then
                Content.AppendLine("And Assign_Date <= @EDate")

            End If
            Content.AppendLine("And SD_Confirm = 'Y'")

            Content.AppendLine("Order By Cancel asc, Assign_Date desc,Reply_date,Finish_Date asc")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@PG_Employee_Code", employeeCode)
            command.Parameters.AddWithValue("@Create_Time", Now.ToString("yyyy-MM-dd"))

            If SDate.Length > 0 Then
                command.Parameters.AddWithValue("@SDate", SDate)
            End If

            If EDate.Length > 0 Then
                command.Parameters.AddWithValue("@EDate", EDate)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retds = New DataSet("PGJobList")
                adapter.Fill(retds, "PGJobList")
            End Using

            retds.Merge(QueryTodoList(employeeCode, conn).Copy)

            Return retds

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

#Region " 查詢代辦清單 "

    ''' <summary>
    ''' 查詢代辦清單
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2018-09-21</remarks>
    Public Function QueryTodoList(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("Select JOB_Code,Issue_Deadline 預估完成日,Mail_Subject 主旨,Issue_Desc 內容描述  ")
            Content.AppendLine("From JOB_SA_Assign_Record JSAR")
            Content.AppendLine("Where PG_Employee_Code=@PG_Employee_Code")
            Content.AppendLine("  And Reply_Date is null")
            Content.AppendLine("  And Finish_Date is null")
            Content.AppendLine("  And ISNULL(Cancel,'') <> 'Y'")
            Content.AppendLine("  And ISNULL(SD_Confirm,'') <> ''")
            Content.AppendLine("  And (Select A.Status From　JOB_PG_JOB_Status_Record A  Where JSAR.Job_Code=A.JOB_Code And A.Seq_No=")
            Content.AppendLine("  (Select MAX(Seq_No) From JOB_PG_JOB_Status_Record JPJSR Where JSAR.Job_Code=JPJSR.JOB_Code))　= '0'")
            Content.AppendLine("")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString


            command.Parameters.AddWithValue("@PG_Employee_Code", EmployeeCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("TodoList")
                adapter.Fill(ds, "TodoList")
            End Using

            Return ds.Tables(0)

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


#Region " 提交工作 "

    ''' <summary>
    ''' 提交工作
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Public Function UpdatePGJobSubmit(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet

        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim JOB_Code As String = ds.Tables(0).Rows(0).Item("JOB_Code")
            Dim Modified_User As String = ds.Tables(0).Rows(0).Item("Modified_User")
            Dim Issue_Level As String = ds.Tables(0).Rows(0).Item("Issue_Level")
            Dim Issue_Cost_Time As String = ds.Tables(0).Rows(0).Item("Issue_Cost_Time")
            Dim Content As New StringBuilder
            Content.AppendLine("Update JOB_SA_Assign_Record")
            Content.AppendLine("Set Reply_Date=getdate(),Modified_User=@Modified_User,Modified_Time=getdate(),Reject_Flag = NULL")
            Content.AppendLine("    ,Issue_Level=@Issue_Level,Issue_Cost_Time=@Issue_Cost_Time")
            Content.AppendLine("Where JOB_Code=@JOB_Code")
            Content.AppendLine("")
            Dim CCUser As String = JobMailGroupBO_E1.GetInstance.GetMailAddressFromGroup(JOB_Code, conn)

            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                If connFlag Then
                    conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                    conn.Open()
                End If

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@JOB_Code", JOB_Code)
                    command.Parameters.AddWithValue("@Modified_User", Modified_User)
                    command.Parameters.AddWithValue("@Issue_Level", Issue_Level)
                    command.Parameters.AddWithValue("@Issue_Cost_Time", Issue_Cost_Time)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using

                If count > 0 Then
                    Dim mailTitle As New StringBuilder
                    Dim message As StringBuilder = GetMailString(JOB_Code, ds, conn)
                    '信件標題
                    mailTitle.Append("[程式提交]-").Append(JobSAAssignRecordBO_E1.GetInstance.GetMailSubject(JOB_Code, conn)).Append("-").Append(Modified_User)


                    SendMail.getInstance.SendMail(GetMainReceiver(JOB_Code, conn),
                                                  CCUser, mailTitle.ToString, message.ToString, True)

                End If
                '寫入新紀錄
                InesrtNewRecord(ds, conn)
                Dim UpdateStatusDS As New DataSet
                UpdateStatusDS.Tables.Add(New DataTable("Action"))
                UpdateStatusDS.Tables(0).Columns.Add("Action")
                UpdateStatusDS.Tables(0).Columns.Add("JOB_Code")
                UpdateStatusDS.Tables(0).Columns.Add("Status")
                UpdateStatusDS.Tables(0).Columns.Add("Create_User")
                UpdateStatusDS.Tables(0).Rows.Add("UpdateJOBStatus", JOB_Code, "2", Modified_User)
                JobPGJobBO_E1.GetInstance.UpdateJobStatus(UpdateStatusDS, conn)
                scope.Complete()
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

    Private Function InesrtNewRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO JOB_PG_JOB_Record")
            Content.AppendLine("           (JOB_Code")
            Content.AppendLine("           ,Seq_No")
            Content.AppendLine("           ,Issue_Desc")
            Content.AppendLine("           ,FID")
            Content.AppendLine("           ,System_Code")
            Content.AppendLine("           ,Create_User")
            Content.AppendLine("           ,Create_Time")
            Content.AppendLine("           ,Modified_User")
            Content.AppendLine("           ,Modified_Time")
            Content.AppendLine("           ,ChangeSet_No")
            Content.AppendLine("           ,ChangeSet_Note)")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@JOB_Code ")
            Content.AppendLine("           ,(Select isnull(Max(Seq_No)+1,1) ")
            Content.AppendLine("		       From JOB_PG_JOB_Record ")
            Content.AppendLine("			   Where JOB_Code = @JOB_Code")
            Content.AppendLine("		    ) ")
            Content.AppendLine("           ,@Issue_Desc ")
            Content.AppendLine("           ,@FID ")
            Content.AppendLine("           ,@System_Code ")
            Content.AppendLine("           ,@Create_User ")
            Content.AppendLine("           ,@Create_Time ")
            Content.AppendLine("           ,@Modified_User ")
            Content.AppendLine("           ,@Modified_Time ")
            Content.AppendLine("           ,@ChangeSet_No ")
            Content.AppendLine("           ,@ChangeSet_Note )")
            Content.AppendLine("")

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@JOB_Code", ds.Tables(0).Rows(0).Item("JOB_Code"))
                command.Parameters.AddWithValue("@Issue_Desc", ds.Tables(0).Rows(0).Item("Issue_Desc"))
                command.Parameters.AddWithValue("@FID", ds.Tables(0).Rows(0).Item("FID"))
                command.Parameters.AddWithValue("@System_Code", ds.Tables(0).Rows(0).Item("System_Code"))
                command.Parameters.AddWithValue("@Create_User", ds.Tables(0).Rows(0).Item("Modified_User"))
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", Now)
                command.Parameters.AddWithValue("@ChangeSet_No", ds.Tables(0).Rows(0).Item("ChangeSet_No"))
                command.Parameters.AddWithValue("@ChangeSet_Note", ds.Tables(0).Rows(0).Item("ChangeSet_Note"))

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using


            Return count

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


#Region "發送提交通知"

    Private Function GetMailString(ByVal JobCode As String, ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As StringBuilder

        Try
            Dim retStr As New StringBuilder


            Dim message As New StringBuilder


            Dim Content As New StringBuilder
            Content.AppendLine("<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 800px"">")
            Content.AppendLine("	<thead>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<th scope=""col"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">派工編號 &nbsp;</span></span></span></span></th>")
            Content.AppendLine("			<th scope=""col"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;"">").Append(JobCode).Append("</span></span></th>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("	</thead>")
            Content.AppendLine("	<tbody>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td style=""text-align: center;"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">&nbsp;程式提交日 &nbsp; &nbsp; &nbsp; &nbsp;</span></span></span></span></td>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px;"">").Append(Now.ToString("yyyy/MM/dd HH:mm:ss")).Append("</span></span></span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td style=""text-align: center;"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">&nbsp; 提交人員 &nbsp; &nbsp; &nbsp; &nbsp;</span></span></span></span></td>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px;"">").Append(JobSAAssignRecordBO_E1.GetInstance.GetEmployeeName(JobCode, "PG_Employee_Code", conn)).Append("</span></span></span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td style=""text-align: center;"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">提交內容 &nbsp;</span></span></span></span></td>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px;"">").Append(ds.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim).Append("</span></span></span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td style=""text-align: center;"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">需求難度 &nbsp;</span></span></span></span></td>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px;"">").Append(GetCodeNameByConfigNameAndCodeId(ds.Tables(0).Rows(0).Item("Issue_Level").ToString.Trim, "JOB_Issue_Level", conn)).Append("</span></span></span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td style=""text-align: center;"">")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px; "">耗費時間 &nbsp;</span></span></span></span></td>")
            Content.AppendLine("			<td>")
            Content.AppendLine("				<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;=""><span style=""font-size:14px;"">").Append(ds.Tables(0).Rows(0).Item("Issue_Cost_Time").ToString.Trim).Append("</span></span></span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("		<tr>")
            Content.AppendLine("			<td colspan=""2"">")
            Content.AppendLine("				<span style=""font-size:16px;""><span style=""color:#ff0000;""> 請派工人員確認後至派工系統進行回覆。&nbsp;</span></span></td>")
            Content.AppendLine("		</tr>")
            Content.AppendLine("	</tbody>")
            Content.AppendLine("</table>")
            Content.AppendLine("<p>")
            Content.AppendLine("	<span style="" font-size:14px;=""><span style="" font-size:14px;""><span style="" font-size:14px;="">&nbsp;</span></span></span></p>")

            Return Content

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function

    Private Function GetMainReceiver(ByVal JobCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String


        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select EMail From PUB_Employee Where Employee_Code=(Select Create_User From  JOB_SA_Assign_Record Where JOB_Code=@JobCode)"

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

    Private Function GetCodeNameByConfigNameAndCodeId(ByVal Code_Id As String, ByVal Config_Name As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim configName As String = ""
            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Config_Value]")
            Content.AppendLine("  FROM [ProjectDB].[dbo].[PUB_Config]")
            Content.AppendLine("  Where Config_Name=@Config_Name")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Config_Name", Config_Name)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Config_Value")
                adapter.Fill(ds, "Config_Value")
            End Using

            If CheckMethodUtil.CheckHasValue(ds) Then

                Dim TempV As String = ds.Tables(0).Rows(0).Item(0).ToString.Trim
                For Each s As String In TempV.Split(",")
                    If s.Split("-")(0).Equals(Code_Id) Then
                        configName = s.Split("-")(1)
                        Return configName
                    End If

                Next

            End If

            Return configName

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

#Region "     更新工作狀態"

    Public Function UpdateJobStatus(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Insert Into JOB_PG_JOB_Status_Record(JOB_Code,Seq_No,Status,Create_User,Create_Time)")
            Content.AppendLine("Values(@JOB_Code,(Select ISNULL(MAX(Seq_No),0)+1 From JOB_PG_JOB_Status_Record Where JOB_Code=@JOB_Code),@Status,@Create_User,getdate())")
            Content.AppendLine("")

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
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
                    command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))

                    retDS.Tables(0).Rows.Add(command.ExecuteNonQuery)
                End Using
            Next

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


End Class
