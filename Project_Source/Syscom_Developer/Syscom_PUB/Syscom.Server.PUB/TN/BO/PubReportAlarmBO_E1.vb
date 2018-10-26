'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表警示設定維護檔
'*              Title:	PUBReportAlarmBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao.Kaiwen
'*        Create Date:	2015-08-07
'*      Last Modifier:	Hsiao.Kaiwen
'*   Last Modify Date:	2015-08-07
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP



Public Class PUBReportAlarmBO_E1
    Inherits PubReportAlarmBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBReportAlarmBO_E1
    Public Overloads Shared Function GetInstance() As PUBReportAlarmBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBReportAlarmBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    Public Function PUBReportAlarmQueryByLikeColumn(ByVal Report_ID As String, ByVal Report_Name As String, ByVal Rpt_Alarm_Count As String, ByVal Rpt_Is_Active As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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


            content.Append("SELECT PUB_Report_Alarm.Report_ID, PUB_Report_Desc.Report_Name,PUB_Report_Alarm.Rpt_Alarm_Count,PUB_Report_Alarm.Rpt_Is_Active FROM " & tableName)
            content.AppendLine(" left join PUB_Report_Desc on PUB_Report_Alarm.Report_ID =  PUB_Report_Desc.Report_ID ")
            content.AppendLine(" where 1=1 ")
            content.AppendLine(" and PUB_Report_Alarm.Report_ID like @Report_ID and PUB_Report_Alarm.Rpt_Alarm_Count ")
            content.AppendLine(" like @Rpt_Alarm_Count and PUB_Report_Alarm.Rpt_Is_Active like @Rpt_Is_Active ")

            If Report_Name <> "" Then
                content.AppendLine(" and PUB_Report_Desc.Report_Name like @Report_Name ")
            End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_ID", "%" & Report_ID & "%")

            If Report_Name <> "" Then
                command.Parameters.AddWithValue("@Report_Name", "%" & Report_Name & "%")
            End If

            command.Parameters.AddWithValue("@Rpt_Alarm_Count", "%" & Rpt_Alarm_Count & "%")
            command.Parameters.AddWithValue("@Rpt_Is_Active", "%" & Rpt_Is_Active & "%")

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

#Region "     查詢報表ID-初始化Combobox "

    Public Function PUBReportAlarmQueryReportId(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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

            content.Append("  select sub_system_no,sub_system_name from ARM_Sub_System")
           
            command.CommandText = content.ToString
           

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("QueryReportID")
                adapter.Fill(ds, "QueryReportID")
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢系統縮寫名稱"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function
#End Region

#Region "     查詢 Alarm Count "
    Public Function PUBReportAlarmCountQuery(ByVal Report_ID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Dim count As Integer = 0

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim content As New System.Text.StringBuilder
            content.Append("   select Rpt_Alarm_Count from PUB_Report_Alarm")
            content.AppendLine(" where Report_ID = @Report_ID ")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_ID", Report_ID)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            If ds.Tables(tableName).Rows.Count <> 0 Then
                count = CInt(ds.Tables(tableName).Rows(0).Item("Rpt_Alarm_Count").ToString)
            Else
                count = -1
            End If

            Return count

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

End Class

