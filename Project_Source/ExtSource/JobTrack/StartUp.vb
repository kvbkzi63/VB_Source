Imports System.Data
Imports System.Collections
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.IO.Compression
Imports System.Drawing
Imports System.Linq
Imports System.Configuration
Imports System.Data.SqlClient
Imports Syscom.Server.CMM
Imports Microsoft.VisualBasic.DateAndTime
Imports Microsoft.VisualBasic.Information
Module StartUp
    Public Sub Main()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("JobDBConnectionString").ConnectionString.ToString())

        Try
            Dim ds As DataSet = QueryDelayJobList(conn)
            If ds IsNot Nothing Then
                ProcessMain(ds)
            End If

        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
        Finally
            conn.Close()
            conn.Dispose()

        End Try

    End Sub


#Region " 取得逾期工作列表 "

    ''' <summary>
    ''' 取得逾期工作列表
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-17</remarks>
    Public Function QueryDelayJobList(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet


        Try
            Dim ds As DataSet

            conn.Open()
            Dim Content As New StringBuilder
            Content.AppendLine("Select DATEDIFF (day,CONVERT(datetime,Issue_DeadLine),CONVERT(datetime,GETDATE())) 'Days', ")
            Content.AppendLine("	   JSAR.Project_ID,")
            Content.AppendLine("	   PP.Project_Name,")
            Content.AppendLine("	   PPS.System_Name,")
            Content.AppendLine("	   PPSF.Function_Name,")
            Content.AppendLine("	   PG.Employee_Name PG_Name,")
            Content.AppendLine("	   PG.Email PG_Email,")
            Content.AppendLine("	   SA.Employee_Name SA,")
            Content.AppendLine("	   SA.Email SA_Email,")
            Content.AppendLine("	   SD.Employee_Name SD,")
            Content.AppendLine("	   SD.Email SD_Email,")
            Content.AppendLine("	   Assign_Date,")
            Content.AppendLine("	   JSAR.System_Code,")
            Content.AppendLine("	   JSAR.Function_Code,")
            Content.AppendLine("	   Mail_Subject,")
            Content.AppendLine("	   JSAR.Issue_DeadLine,")
            Content.AppendLine("	   JSAR.SD_Issue_Deadline,")
            Content.AppendLine("	   AssignPE.Employee_Name Assign_User,")
            Content.AppendLine("	   Issue_Desc ")
            Content.AppendLine("  From JOB_SA_Assign_Record JSAR")
            Content.AppendLine(" Inner Join PRJ_Project PP On PP.Project_ID=JSAR.Project_ID")
            Content.AppendLine(" Inner Join PRJ_Project_System PPS On PPS.Project_ID=PP.Project_ID And PPS.System_Code=JSAR.System_Code")
            Content.AppendLine(" Inner Join PRJ_Project_System_Function PPSF On PPSF.Project_ID=PP.Project_ID And PPSF.System_Code=PPS.System_Code And PPSF.Function_Code=JSAR.Function_Code")
            Content.AppendLine(" Inner Join PUB_Employee PG On PG.Employee_Code=JSAR.PG_Employee_Code")
            Content.AppendLine("  Left Join PUB_Employee SA On SA.Employee_Code=JSAR.Create_User And SA.Nrs_Level_Id='2'")
            Content.AppendLine(" Inner Join PUB_Employee AssignPE On AssignPE.Employee_Code=JSAR.Create_User ")
            Content.AppendLine("  Left Join PUB_Employee SD On (SD.Employee_Code=JSAR.Create_User Or SD.Employee_Code=JSAR.SD_Employee_Code) And SD.Nrs_Level_Id='3'")
            Content.AppendLine("Where Isnull(Reply_Date,'') = ''")
            Content.AppendLine("  And Isnull(Cancel,'') <> 'Y'")
            Content.AppendLine("  And Isnull(SD_Confirm,'') = 'Y'")
            'Content.AppendLine("  And JSAR.PG_Employee_Code ='201606    '")
            Content.AppendLine("  And JSAR.Project_ID Not In('JobApp','Test01')")
            Content.AppendLine("  And DATEDIFF (day,CONVERT(datetime,Issue_DeadLine),CONVERT(datetime,GETDATE())) > (Select Config_Value")
            Content.AppendLine("																				    From PUB_Config ")
            Content.AppendLine("																				   Where Config_Name='JOB_DelayDay')")
            Content.AppendLine("  Order By PG_EMPLOYEE_CODE,Days")
            Content.AppendLine("   ")
            Content.AppendLine("   ")
            Content.AppendLine(" ")
            Content.AppendLine("")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Job")
                adapter.Fill(ds, "Job")
            End Using

            Return ds

        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
        End Try

    End Function

#End Region
#Region "     主流程"
    Private Sub ProcessMain(ByVal ds As DataSet)
        Try
            Dim query = (From q In ds.Tables(0)
                         Group By PG_Name = q.Item("PG_Name") Into grp = Group).
                            Select(Function(c) New With {.PG_Name = c.PG_Name}).ToList

            For Each y In query
                Dim MainReceiver As String = ds.Tables(0).Select("PG_Name='" & y.PG_Name & "'")(0).Item("PG_Email")
                Dim JobList As DataTable = ds.Tables(0).Select("PG_Name='" & y.PG_Name & "'").CopyToDataTable
                Dim CCuser As String = GetCCUser(JobList)
                Dim MailBody As StringBuilder = GenMailBody(JobList)

                If SendMail.getInstance.SendMail(MainReceiver, CCuser, "[專案工作管理]-需求逾期通知-" & y.PG_Name, MailBody.ToString, True) = 0 Then

                End If

            Next

            If DateDiff(DateInterval.Day, CDate("2017/12/25"), Now) < 0 Then
                Dim TotalList As New StringBuilder
                TotalList.AppendLine("<div>")
                TotalList.AppendLine("	Dear Joseph 以下為各PG目前派工系統內，逾期未提交工作列表</div>")
                TotalList.AppendLine("<div>")
                TotalList.AppendLine("	&nbsp;</div>")
                For Each y In query
                    Dim JobList As DataTable = ds.Tables(0).Select("PG_Name='" & y.PG_Name & "'").CopyToDataTable
                    GetTotalList(JobList, TotalList)
                Next
                SendMail.getInstance.SendMail("Joseph_Lin@cloudmaster.com.tw", "Will_Lin@Syscom.com.tw", "[專案工作管理]-需求逾期通知", TotalList.ToString, True)
                'SendMail.getInstance.SendMail("Will_Lin@Syscom.com.tw", "[專案工作管理]-需求逾期通知", TotalList.ToString, True)

            End If

        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)

        End Try
    End Sub
    Private Sub GetTotalList(ByVal dt As DataTable, ByRef Content As StringBuilder)

        Try
            Content.AppendLine("<div>")
            Content.AppendLine("	PG:" & dt.Rows(0).Item("PG_Name") & " 逾期未提交工作如下</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	&nbsp;</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	&nbsp;</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 900"">")
            Content.AppendLine("		<tbody>")
            Content.AppendLine("			<tr>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>專案代號</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>專案名稱</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>所屬系統</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>所屬功能</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>主旨</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>派工日</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>派送者</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#0000cd;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>預計完成日</strong></span></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#0000cd;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>SD預計完成日</strong></span></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#ff0000;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>逾期天數</strong></span></span></td>")
            Content.AppendLine("			</tr>")
            For i As Int32 = 0 To dt.Rows.Count - 1
                Content.AppendLine("			<tr>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Project_ID") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Project_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("System_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Function_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Mail_Subject") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Assign_Date") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Assign_User") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					<span style=""color:#0000cd;"">" & dt.Rows(i).Item("Issue_DeadLine") & "</span></td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					<span style=""color:#0000cd;"">" & dt.Rows(i).Item("SD_Issue_DeadLine") & "</span></td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                If IsDate(dt.Rows(i).Item("Issue_DeadLine")) AndAlso IsDate(dt.Rows(i).Item("SD_Issue_DeadLine")) Then
                    If DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), CDate(dt.Rows(i).Item("SD_Issue_DeadLine"))) > 0 Then
                        Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("SD_Issue_DeadLine")), Now) & "</span></td>")
                    Else
                        Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), Now) & "</span></td>")
                    End If
                ElseIf IsDate(dt.Rows(i).Item("Issue_DeadLine")) Then
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), Now) & "</span></td>")
                ElseIf IsDate(dt.Rows(i).Item("SD_Issue_DeadLine")) Then
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("SD_Issue_DeadLine")), Now) & "</span></td>")
                Else
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Assign_Date")), Now) & "</span></td>")
                End If
                Content.AppendLine("			</tr>")
            Next

            Content.AppendLine("		</tbody>")
            Content.AppendLine("	</table>")
            Content.AppendLine("</div>")
            Content.AppendLine("<p>")
            Content.AppendLine("	&nbsp;</p>")
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
        End Try
    End Sub
    Private Function GenMailBody(ByVal dt As DataTable) As StringBuilder
        Dim str As New StringBuilder

        Try
            Dim Content As New StringBuilder
            Content.AppendLine("<div>")
            Content.AppendLine("	Dear " & dt.Rows(0).Item("PG_Name") & ":</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	&nbsp;</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	你有下列需求已逾期，如有開發上的困難請與SA/SD聯繫視情況展延交期</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	&nbsp;</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	&nbsp;</div>")
            Content.AppendLine("<div>")
            Content.AppendLine("	<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 900"">")
            Content.AppendLine("		<tbody>")
            Content.AppendLine("			<tr>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>專案代號</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>專案名稱</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>所屬系統</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>所屬功能</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>主旨</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>派工日</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""font-family:arial,helvetica,sans-serif;""><strong>派送者</strong></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#0000cd;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>預計完成日</strong></span></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#0000cd;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>SD預計完成日</strong></span></span></td>")
            Content.AppendLine("				<td style=""text-align: center;"">")
            Content.AppendLine("					<span style=""color:#ff0000;""><span style=""font-family:arial,helvetica,sans-serif;""><strong>逾期天數</strong></span></span></td>")
            Content.AppendLine("			</tr>")
            For i As Int32 = 0 To dt.Rows.Count - 1
                Content.AppendLine("			<tr>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Project_ID") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Project_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("System_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Function_Name") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Mail_Subject") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Assign_Date") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					" & dt.Rows(i).Item("Assign_User") & "</td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					<span style=""color:#0000cd;"">" & dt.Rows(i).Item("Issue_DeadLine") & "</span></td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                Content.AppendLine("					<span style=""color:#0000cd;"">" & dt.Rows(i).Item("SD_Issue_DeadLine") & "</span></td>")
                Content.AppendLine("				<td style=""text-align: center;"">")
                If IsDate(dt.Rows(i).Item("Issue_DeadLine")) AndAlso IsDate(dt.Rows(i).Item("SD_Issue_DeadLine")) Then
                    If DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), CDate(dt.Rows(i).Item("SD_Issue_DeadLine"))) > 0 Then
                        Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("SD_Issue_DeadLine")), Now) & "</span></td>")
                    Else
                        Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), Now) & "</span></td>")
                    End If
                ElseIf IsDate(dt.Rows(i).Item("Issue_DeadLine")) Then
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Issue_DeadLine")), Now) & "</span></td>")
                ElseIf IsDate(dt.Rows(i).Item("SD_Issue_DeadLine")) Then
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("SD_Issue_DeadLine")), Now) & "</span></td>")
                Else
                    Content.AppendLine("					<span style=""color:#ff0000;"">" & DateDiff(DateInterval.Day, CDate(dt.Rows(i).Item("Assign_Date")), Now) & "</span></td>")
                End If
                Content.AppendLine("			</tr>")
            Next

            Content.AppendLine("		</tbody>")
            Content.AppendLine("	</table>")
            Content.AppendLine("</div>")
            Content.AppendLine("<p>")
            Content.AppendLine("	&nbsp;</p>")
            str = Content
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)

        End Try
        Return str
    End Function
    Private Function GetCCUser(ByVal dt As DataTable) As String
        Dim CCUser As New List(Of String)
        Try

            For i As Int32 = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("SA_Email").ToString.Trim <> "" AndAlso Not CCUser.Contains(dt.Rows(i).Item("SA_Email").ToString.Trim) Then
                    CCUser.Add(dt.Rows(i).Item("SA_Email").ToString.Trim)
                End If
                If dt.Rows(i).Item("SD_Email").ToString.Trim <> "" AndAlso Not CCUser.Contains(dt.Rows(i).Item("SD_Email").ToString.Trim) Then
                    CCUser.Add(dt.Rows(i).Item("SD_Email").ToString.Trim)
                End If
            Next

        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)

        End Try

        Return String.Join(";", CCUser)
    End Function
#End Region

End Module
