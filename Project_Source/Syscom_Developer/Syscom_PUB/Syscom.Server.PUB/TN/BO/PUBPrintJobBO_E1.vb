'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPrintJobBO_E1.vb
'*              Title:	
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Barry
'*        Create Date:	2010/10/22
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SNC
Imports Syscom.Comm.Utility.StringUtil
Imports System.Text

Public Class PUBPrintJobBO_E1
    Inherits PubPrintJobBO


    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"
    Private Shared instance As PUBPrintJobBO_E1
    Public Overloads Shared Function getInstance() As PUBPrintJobBO_E1
        If instance Is Nothing Then
            instance = New PUBPrintJobBO_E1
        End If
        Return instance
    End Function
    Public Sub New()
    End Sub
#End Region

    Public Function insertPrintJobData(ByVal ds As System.Data.DataSet) As DataSet
        Try
            Dim count As Integer = 0



            Using conn As System.Data.IDbConnection = getAuthenticConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(0).Rows

                    Dim serial = StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNoTx(AbstractFactory.SncType.typeD, "ReportJob", 1, -1, conn), "0"c, 8)


                    Dim sqlString As String = "insert " & tableName & "(Job_ID,Report_ID,Report_Name,Condition_Param,Report_Status,Create_User,Create_Time)" & _
                                                   " values(" & _
                                                    "'" & nvl(row.Item("Job_ID")) & serial & "'," & _
                                                    "'" & nvl(row.Item("Report_ID")) & "'," & _
                                                   "'" & nvl(row.Item("Report_Name")) & "', " & _
                                                   "'" & nvl(row.Item("Condition_Param")) & "'," & _
                                                   "'" & nvl(row.Item("Report_Status")) & "'," & _
                                                   "'" & nvl(row.Item("Create_User")) & "'," & _
                                                   "'" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "')"

                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With

                        'command.Parameters.AddWithValue("@Job_ID", row.Item("Job_ID") & serial)
                        'command.Parameters.AddWithValue("@Report_ID", row.Item("Report_ID"))
                        'command.Parameters.AddWithValue("@Report_Name", row.Item("Report_Name"))
                        'command.Parameters.AddWithValue("@Condition_Param", row.Item("Condition_Param"))
                        'command.Parameters.AddWithValue("@Condition_Param", "")
                        'command.Parameters.AddWithValue("@Report_Status", row.Item("Report_Status"))
                        'command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        'command.Parameters.AddWithValue("@Create_Time", Now)
                        'command.Parameters.AddWithValue("@Modified_User", row.Item("Create_User"))
                        'command.Parameters.AddWithValue("@Modified_Time", Now)
                        Dim cnt As Integer = command.ExecuteNonQuery

                        '將序號更新至DataSet中
                        row.Item("Job_ID") = row.Item("Job_ID") & serial

                        count = count + cnt
                    End Using
                Next
            End Using

            'Dim sqlString As String = "insert " & tableName & "(Job_ID,Report_ID,Report_Name,Condition_Param,Report_Status,Create_User,Create_Time)" & _
            '                        " values(@Job_ID,@Report_ID,@Report_Name,@Condition_Param,@Report_Status,@Create_User,@Create_Time)"

            'Using conn As System.Data.IDbConnection = getAuthenticConnection()
            '    conn.Open()
            '    For Each row As DataRow In ds.Tables(0).Rows



            '        Using command As SqlCommand = New SqlCommand
            '            With command
            '                .CommandText = sqlString
            '                .CommandType = CommandType.Text
            '                .Connection = CType(conn, SqlConnection)
            '            End With
            '            Dim serial = StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNoTx(AbstractFactory.typeD, "ReportJob", 1, -1), "0"c, 8)
            '            command.Parameters.AddWithValue("@Job_ID", row.Item("Job_ID") & serial)
            '            command.Parameters.AddWithValue("@Report_ID", row.Item("Report_ID"))
            '            command.Parameters.AddWithValue("@Report_Name", row.Item("Report_Name"))
            '            'command.Parameters.AddWithValue("@Condition_Param", row.Item("Condition_Param"))


            '            command.Parameters.AddWithValue("@Condition_Param", "")
            '            command.Parameters.AddWithValue("@Report_Status", row.Item("Report_Status"))

            '            command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
            '            command.Parameters.AddWithValue("@Create_Time", Now)
            '            'command.Parameters.AddWithValue("@Modified_User", row.Item("Create_User"))
            '            'command.Parameters.AddWithValue("@Modified_Time", Now)
            '            Dim cnt As Integer = command.ExecuteNonQuery

            '            '將序號更新至DataSet中
            '            row.Item("Job_ID") = row.Item("Job_ID") & serial

            '            count = count + cnt
            '        End Using
            '    Next
            'End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try
    End Function
    ''' <summary>
    ''' 依條件查出資料
    ''' </summary>
    ''' <param name="cond"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBPrintJobByCond(ByVal cond As DataTable) As DataSet

        Dim ds As DataSet
        Dim whereStr As String
        '"User", "Start_DateTime", "End_DateTime", "System", "Report_Name"
        Dim user As String = StringUtil.nvl(cond.Rows(0).Item("User"))
        Dim startDateTime As String = StringUtil.nvl(cond.Rows(0).Item("Start_DateTime"))
        Dim endDateTime As String = StringUtil.nvl(cond.Rows(0).Item("End_DateTime"))
        Dim system As String = StringUtil.nvl(cond.Rows(0).Item("System"))
        Dim reportName As String = StringUtil.nvl(cond.Rows(0).Item("Report_Name"))
        Dim downloadCheck As String = StringUtil.nvl(cond.Rows(0).Item("DownloadCheck"))
        whereStr = "where 1=1"
        If StringUtil.nvl(user) <> "" Then
            whereStr &= " and Create_User='" & user & "'"
        End If
        If StringUtil.nvl(startDateTime) <> "" Then
            whereStr &= " and Create_Time>='" & startDateTime & "'"
        End If
        If StringUtil.nvl(endDateTime) <> "" Then
            whereStr &= " and Create_Time<='" & endDateTime & "'"
        End If
        If StringUtil.nvl(system) <> "" Then
            whereStr &= " and substring(Report_ID,1,3)='" & system & "'"
        End If
        If StringUtil.nvl(reportName) <> "" Then
            whereStr &= " and Report_Name='" & reportName & "'"
        End If
        If StringUtil.nvl(downloadCheck) = "True" Then
            whereStr &= " and ISNULL(Download_Cnt,0)=0"
        End If

        Try
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim SqlStr As New StringBuilder
            SqlStr.Append(" ").AppendLine(" Select")
            SqlStr.Append(" ").AppendLine(" Job_ID")
            SqlStr.Append(" ").AppendLine(" ,Report_ID")
            SqlStr.Append(" ").AppendLine(" ,FID")
            SqlStr.Append(" ").AppendLine(" ,Report_Name")
            SqlStr.Append(" ").AppendLine(" ,Condition_Param")
            SqlStr.Append(" ").AppendLine(" ,Report_Status ")
            SqlStr.Append(" ").AppendLine(" ,Process_Msg ")
            SqlStr.Append(" ").AppendLine(" ,Create_User")
            SqlStr.Append(" ").AppendLine(" ,[dbo].[AdToRocTime](Create_Time) as Create_Time")
            SqlStr.Append(" ").AppendLine(" ,Modified_User")
            SqlStr.Append(" ").AppendLine(" ,[dbo].[AdToRocTime](Modified_Time) as Modified_Time")
            SqlStr.Append(" ").AppendLine(" ,Download_Cnt")
            SqlStr.Append(" ").AppendLine(" ,case Report_Status ")
            SqlStr.Append(" ").AppendLine("     when 'N' then '未執行' ")
            SqlStr.Append(" ").AppendLine("     when 'B' then 'Batch處理中'")
            SqlStr.Append(" ").AppendLine("     when 'P' then '處理中'  ")
            SqlStr.Append(" ").AppendLine("     when 'S' then '成功' ")
            SqlStr.Append(" ").AppendLine("     when 'F' then '失敗' ")
            SqlStr.Append(" ").AppendLine(" else Report_Status end 'Status'")
            SqlStr.Append(" ").AppendLine(" From  PUB_Print_Job ")
            SqlStr.Append(" ").AppendLine(whereStr)
 
            command.CommandText = SqlStr.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Print_Job")
                adapter.Fill(ds, "PUB_Print_Job")
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function
    ''' <summary>
    ''' 查出目前的系統
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBPrintJobReportType() As DataSet

        Dim ds As DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "select distinct(SUBSTRING(Report_ID, 1, 3))reportType " & _
                                  "from PUB_Print_Job " & _
                                  "order by reportType "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Print_Job")
                adapter.Fill(ds, "PUB_Print_Job")
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function
    ''' <summary>
    ''' 查出目前的報表
    ''' </summary>
    ''' <param name="reportType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBPrintJobReportByType(ByVal reportType As String, ByVal userId As String) As DataSet

        Dim ds As DataSet
        Dim whereStr As String = "where 1=1"
        If StringUtil.nvl(reportType) <> "" Then
            whereStr &= " and substring(Report_ID,1,3)='" & reportType & "' "
        End If
        If StringUtil.nvl(userId) <> "" Then
            whereStr &= " and Create_User='" & userId & "' "
        End If

        Try
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "select distinct(Report_Name) " & _
                                  "from PUB_Print_Job " & _
                                  "" & whereStr

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Print_Job")
                adapter.Fill(ds, "PUB_Print_Job")
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function


    Public Function queryPUBPrintJob(ByVal JobID As String, ByVal UserID As String) As DataSet

        Dim ds As DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select * " & _
                                  "From  PUB_Print_Job " & _
                                  "Where Job_ID='" & JobID & "' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Print_Job")
                adapter.Fill(ds, "PUB_Print_Job")
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    ''' <summary>
    ''' 程式說明：更新報表列印狀態
    ''' 開發人員：Charles
    ''' 開發日期：2015/09/02
    ''' </summary>
    ''' <param name="JobID"></param>
    ''' <param name="ReportStatus"></param>
    ''' <param name="UserID"></param>
    ''' <param name="ProcessMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setReportStatus(ByVal JobID As String, ByVal ReportStatus As String, _
                                    ByVal UserID As String, ByVal ProcessMsg As String) As Integer

        Dim var1 As New System.Text.StringBuilder
        Dim result As Integer

        var1.Append(" Update PUB_Print_Job" & vbCrLf)
        var1.Append(" Set Report_Status='" & ReportStatus & "'," & _
                    " Process_Msg='" & Replace(ProcessMsg, "'", "''") & "', " & _
                    " Modified_User='" & UserID & "' , " & _
                    " Modified_Time='" & Now.ToString("yyyy/MM/dd H:m:s") & "' " & vbCrLf)
        var1.Append(" Where Job_Id='" & JobID & "'" & vbCrLf)

        Using _sqlConnection As SqlConnection = getAuthenticConnection()
            Try
                If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()


                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)

                result = _command.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using

        Return result

    End Function

    ''' <summary>
    ''' 程式說明：累計下載次數
    ''' 開發人員：Charles
    ''' 開發日期：2015/09/02
    ''' </summary>
    ''' <param name="JobID">工作序號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function increaseDownloadCnt(ByVal JobID As String) As Integer

        Dim var1 As New System.Text.StringBuilder
        Dim result As Integer

        var1.AppendLine(" Update PUB_Print_Job")
        var1.AppendLine(" set Download_Cnt=Download_Cnt+1")
        var1.AppendLine(" Where Job_Id='" & JobID & "'")

        Using _sqlConnection As SqlConnection = getAuthenticConnection()
            Try
                If _sqlConnection.State <> ConnectionState.Open Then _sqlConnection.Open()


                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)

                result = _command.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using

        Return result

    End Function


End Class
