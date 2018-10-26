Imports System.Data.SqlClient
'Imports Syscom.Server.SQL
Imports Syscom.Server.BO
'Imports Syscom.Comm.TableFactory
'Imports Syscom.Comm.Utility
'Imports Syscom.Comm.EXP
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PUBPrintConfigBO_E1
    Inherits PubPrintConfigBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPrintConfigBO_E1
    Public Overloads Shared Function GetInstance() As PUBPrintConfigBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBPrintConfigBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "   報表列印共用功能"

    ''' <summary>
    ''' 取得報表列印資訊
    ''' </summary>
    ''' <param name="reportID"></param>
    ''' <param name="printerType"></param>
    ''' <param name="printerCond"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportInfo(ByVal reportID As String, ByVal printerType As String, ByVal printerCond As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim tb_PUBPrintConfig As String = "PUB_Print_Config"
        Dim tb_PUBHospital As String = "PUB_Hospital"
        Dim tb_PUBReportAlarm As String = "PUB_Report_Alarm"
        Try
            Dim hospitalCode As String = System.Configuration.ConfigurationManager.AppSettings.Item("Hospital_Code")
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getPUBConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select A.Report_ID,A.Report_Name,ISNULL(A.System_Code,'') as System_Code,ISNULL(A.Report_Desc,'') as Report_Desc,B.Print_Type,B.Print_Cond,B.Printer_Name, " & vbCrLf)
            sqlString.Append("(select Hospital_Name from PUB_Hospital   where Language_Type_Id='1' and   Hospital_Code=@Hospital_Code and CAST(GETDATE() as Date) between Effect_Date and End_Date ) Hospital_CH , " & vbCrLf)
            sqlString.Append("(select Hospital_Name from PUB_Hospital   where Language_Type_Id='2' and   Hospital_Code=@Hospital_Code and CAST(GETDATE() as Date) between Effect_Date and End_Date ) Hospital_EN " & vbCrLf)
            sqlString.Append("from PUB_Report_Desc as A " & vbCrLf)
            sqlString.Append("   left  outer join PUB_Print_Config as B " & vbCrLf)
            sqlString.Append("   ON A.report_ID=B.Report_ID " & vbCrLf)
            sqlString.Append("   where A.report_id=@reportID and B.Print_Type=@printerType and B.Print_Cond=@printerCond")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@reportID", reportID)
            command.Parameters.AddWithValue("@printerType", printerType)
            command.Parameters.AddWithValue("@printerCond", printerCond)
            command.Parameters.AddWithValue("@Hospital_Code", hospitalCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tb_PUBPrintConfig)
                adapter.Fill(ds, tb_PUBPrintConfig)
            End Using

            '將PUB_Hospitalds中的Datatable加入至ds當中
            Dim sqlString0 As New System.Text.StringBuilder
            sqlString0.Append("Select [Language_Type_Id] " & vbCrLf)
            sqlString0.Append("      ,[Hospital_Code] " & vbCrLf)
            sqlString0.Append("      ,[Effect_Date] " & vbCrLf)
            sqlString0.Append("      ,[End_Date] " & vbCrLf)
            sqlString0.Append("      ,[Hospital_Name] " & vbCrLf)
            sqlString0.Append("      ,[Hospital_Short_Name] " & vbCrLf)
            sqlString0.Append("      ,[Telephone] " & vbCrLf)
            sqlString0.Append("      ,[Fax] " & vbCrLf)
            sqlString0.Append("      ,[Voice_Tel] " & vbCrLf)
            sqlString0.Append("      ,[Postal_Code] " & vbCrLf)
            sqlString0.Append("      ,[Address] " & vbCrLf)
            sqlString0.Append("      ,[Principal_Name] " & vbCrLf)
            sqlString0.Append("      ,[Principal_Email] " & vbCrLf)
            sqlString0.Append("      ,[Hospital_Level_Id] " & vbCrLf)
            sqlString0.Append("      ,[URL] " & vbCrLf)
            sqlString0.Append("      ,[Unified_Business_No] " & vbCrLf)
            sqlString0.Append(" " & vbCrLf)
            sqlString0.Append("  FROM [PUB_Hospital] " & vbCrLf)
            sqlString0.Append("  where Hospital_Code = @Hospital_Code1")

            command.CommandText = sqlString0.ToString
            command.Parameters.AddWithValue("@Hospital_Code1", hospitalCode)

            Dim PUB_Hospitalds As DataSet = New DataSet
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                PUB_Hospitalds = New DataSet(tb_PUBHospital)
                adapter.Fill(PUB_Hospitalds, tb_PUBHospital)
            End Using
            ds.Tables.Add(PUB_Hospitalds.Tables(0).Copy)

            '將PUB_Report_Alarm中的Datatable加入至ds當中
            Dim sqlString1 As New System.Text.StringBuilder
            sqlString1.Append("select Rpt_Alarm_Count from PUB_Report_Alarm where Report_ID=@_reportID and Rpt_Is_Active='Y'")
            command.CommandText = sqlString1.ToString
            command.Parameters.AddWithValue("@_reportID", reportID)

            Dim PUB_Report_AlarmDs As DataSet = New DataSet
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                PUB_Report_AlarmDs = New DataSet(tb_PUBReportAlarm)
                adapter.Fill(PUB_Report_AlarmDs, tb_PUBReportAlarm)
            End Using
            ds.Tables.Add(PUB_Report_AlarmDs.Tables(0).Copy)

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region ""
    ''' <summary>
    ''' 取得 PUB DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPUBConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region

End Class
