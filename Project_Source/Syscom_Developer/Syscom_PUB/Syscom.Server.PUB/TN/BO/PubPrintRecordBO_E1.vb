'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表列印記錄檔查詢作業
'*              Title:	PubPrintRecordBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	ChenYu.Guo
'*        Create Date:	2015-06-01
'*      Last Modifier:	ChenYu.Guo
'*   Last Modify Date:	2015-06-01
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text
Imports System.Net
Imports System.Text.RegularExpressions



Public Class PubPrintRecordBO_E1
    Inherits PubPrintRecordBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubPrintRecordBO_E1
    Public Overloads Shared Function GetInstance() As PubPrintRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubPrintRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region " 報表列印記錄檔查詢作業 "

    ''' <summary>
    ''' 報表列印記錄檔查詢作業
    ''' </summary>
    ''' <param name="reportID" >報表代碼</param>
    ''' <param name="reportName" >報表名稱</param>
    ''' <param name="createUse" >列印者</param>
    ''' <param name="createTime" >Start_Time</param>
    ''' <param name="endTime" >Create_Time</param>
    ''' <param name="printIP" >IPV4 or IPV6</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function QueryPrintRecord(ByRef reportID As String, ByRef reportName As String, ByRef createUse As String, ByRef createTime As String, ByRef endTime As String, ByRef printIP As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Report_ID , Report_Name , Create_User , Create_Time , Print_Machine_Name ,  ")
            'content.AppendLine(" Print_IP , Print_IPv6                from " & tableName)
            content.AppendLine(" Print_IP               from " & tableName)
            content.AppendLine("   where Report_ID like @Report_ID ")
            content.AppendLine(" and Report_Name like @Report_Name ")
            content.AppendLine(" and Create_Time > @Start_Time and Create_Time < @End_Time ")
            content.AppendLine(" and Create_User = @Create_User ")
            content.AppendLine(" and Print_IP like @Print_IP ")
            'If GetValidatedIP(printIP) = "IPv4" Then
            '    content.AppendLine(" and Print_IP like @Print_IP ")
            'ElseIf GetValidatedIP(printIP) = "IPv6" Then
            '    content.AppendLine(" and Print_IPv6 like @Print_IP ")
            'ElseIf GetValidatedIP(printIP) = "error" Then
            '    content.AppendLine(" and (Print_IP like @Print_IP or Print_IPv6 like @Print_IP) ")
            'End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_ID", "%" & reportID & "%")
            command.Parameters.AddWithValue("@Report_Name", "%" & reportName & "%")
            command.Parameters.AddWithValue("@Start_Time", createTime)
            command.Parameters.AddWithValue("@End_Time", endTime)
            command.Parameters.AddWithValue("@Create_User", createUse)
            command.Parameters.AddWithValue("@Print_IP", "%" & printIP & "%")

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
            Throw New CommonException("CMMCMMB911", ex)
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 驗證IPv4,IPv6 "
    Public Function GetValidatedIP(ipStr As String) As String
        Dim validatedIP As String = String.Empty
        If IsValidIP(ipStr) Then
            validatedIP = "IPv4"
        Else
            If Uri.CheckHostName(ipStr) = UriHostNameType.IPv6 Then
                validatedIP = "IPv6"
            Else
                validatedIP = "error"
            End If
        End If

        Return validatedIP
    End Function
    Public Function IsValidIP(addr As String) As Boolean

        Dim pattern As String = "^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$"
        Dim check As New Regex(pattern)
        Dim valid As Boolean = False
        If addr = "" Then
            valid = False
        Else
            valid = check.IsMatch(addr, 0)
        End If

        Return valid

    End Function
#End Region

#Region "    將列印報表、預覽報表的資料 新增至 PUB_Print_Record  "

    Public Function insertRPTPrintClient(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try

            '查詢Report_Name
            Dim ds_QueryReportName As New DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim commandQueryReportName As SqlCommand = sqlConn.CreateCommand()

            Dim content As New System.Text.StringBuilder
            content.Append("  select Report_Name from PUB_Report_Desc")
            content.AppendLine(" where Report_Id ='" & ds.Tables("PUB_Print_Record").Rows(0).Item("Report_Id").ToString & "'")

            commandQueryReportName.CommandText = content.ToString
            
            Using adapter As SqlDataAdapter = New SqlDataAdapter(commandQueryReportName)
                ds_QueryReportName = New DataSet("PUB_Report_Desc")
                adapter.Fill(ds_QueryReportName, "PUB_Report_Desc")
            End Using

            '新增至 PUB_Print_Record
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Report_ID , Create_User , Create_Time , Report_Name , Print_IP ,  " & _
             " Print_Machine_Name ) " & _
             " values( @Report_ID , @Create_User , @Create_Time , @Report_Name , @Print_IP ,  " & _
             " @Print_Machine_Name             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Report_ID", row.Item("Report_ID"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", Now)
                    command.Parameters.AddWithValue("@Report_Name", ds_QueryReportName.Tables("PUB_Report_Desc").Rows(0).Item("Report_Name").ToString)
                    command.Parameters.AddWithValue("@Print_IP", row.Item("Print_IP"))
                    command.Parameters.AddWithValue("@Print_Machine_Name", row.Item("Print_Machine_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            '將資料筆數寫入PUB_Report_Alarm
            Dim sqlStringPUBReportAlarm As String = "update PUB_Report_Alarm set " & _
           " Rpt_Count=@Rpt_Count , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
           " where  Report_ID=@Report_ID            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlStringPUBReportAlarm
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Report_ID", row.Item("Report_ID"))
                    command.Parameters.AddWithValue("@Rpt_Count", row.Item("Rpt_Count"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next


            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
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

