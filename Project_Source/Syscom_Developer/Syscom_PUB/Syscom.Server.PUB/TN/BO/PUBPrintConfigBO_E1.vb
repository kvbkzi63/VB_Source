Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports System.Text

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
    '''依Report_ID取得報表設定資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryReportConfigByReportId(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PUB_Print_Config"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getPUBConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   PUB_Print_Config " & vbCrLf)
            sqlStr.Append("WHERE  Report_Id = '" & inReportId & "' ")

            command.CommandText = sqlStr.ToString
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId">報表代碼</param>
    ''' <param name="conn">資料庫連結</param>
    ''' <returns>String</returns>
    ''' <remarks>L:本機印表 , R:遠端印表 , A:本機 and 遠端印表</remarks>
    Public Function queryReportMode(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim tableName As String = "PUB_Print_Config"
        Dim connFlag As Boolean = conn Is Nothing
        Dim pvtLocalFlag, pvtRemoteFlag As Boolean
        Dim pvtPrintMode As String = ""

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getPUBConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   PUB_Print_Config " & vbCrLf)
            sqlStr.Append("WHERE  Report_Id = '" & inReportId & "' ")

            command.CommandText = sqlStr.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            '判斷列印模式處理
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("Print_Type").ToString.Trim = "1" Then
                    pvtLocalFlag = True
                    pvtPrintMode = "L"
                ElseIf ds.Tables(0).Rows(i).Item("Print_Type").ToString.Trim = "2" Then
                    pvtRemoteFlag = True
                    pvtPrintMode = "R"
                End If

                If pvtLocalFlag AndAlso pvtRemoteFlag Then
                    pvtPrintMode = "A"
                    Exit For
                End If
            Next

            Return pvtPrintMode
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

#Region " 報表維護資料查詢作業 QueryByPKLike "

    ''' <summary>
    ''' 報表維護資料查詢作業
    ''' </summary>
    ''' <param name="Report_Id" >報表代碼</param>
    ''' <param name="Print_Type" >報表類型</param>
    ''' <param name="Print_Cond" >列印條件</param>
    ''' <param name="Printer_Name" >印表機名稱</param>
    ''' <param name="Paper_Size" >備註</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-14</remarks>
    Public Function PrintConfigQueryByLikeColumn(ByVal Report_Id As String, ByVal Print_Type As String, ByVal Print_Cond As String, ByVal Printer_Name As String, ByVal Paper_Size As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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

            content.Append("  Select A.Report_ID " & vbCrLf)
            content.Append("      ,B.Report_Name " & vbCrLf)
            content.Append("      ,A.Print_Type " & vbCrLf)
            content.Append("      ,A.Print_Cond " & vbCrLf)
            content.Append("      ,A.Printer_Name " & vbCrLf)
            content.Append("      ,A.Paper_Size " & vbCrLf)
            content.Append("  FROM PUB_Print_Config as A " & vbCrLf)
            content.Append("  left join PUB_Report_Desc as B on A.Report_ID = B.Report_ID")
            content.AppendLine(" where A.Report_ID like @Report_ID and A.Print_Type ")
            content.AppendLine(" like @Print_Type and A.Print_Cond like @Print_Cond")
            content.AppendLine("")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_ID", "%" & Report_Id & "%")
            command.Parameters.AddWithValue("@Print_Type", "%" & Print_Type & "%")
            command.Parameters.AddWithValue("@Print_Cond", "%" & Print_Cond & "%")
            command.Parameters.AddWithValue("@Printer_Name", "%" & Printer_Name & "%")
            command.Parameters.AddWithValue("@Paper_Size", "%" & Paper_Size & "%")

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

#Region " 報表維護資料查詢作業 QueryByPK "

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PrintConfigQueryByPK(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.Append("  Select A.Report_ID " & vbCrLf)
            content.Append("      ,B.Report_Name " & vbCrLf)
            content.Append("      ,A.Print_Type " & vbCrLf)
            content.Append("      ,A.Print_Cond " & vbCrLf)
            content.Append("      ,A.Printer_Name " & vbCrLf)
            content.Append("      ,A.Paper_Size " & vbCrLf)
            content.Append("  FROM PUB_Print_Config as A " & vbCrLf)
            content.Append("  left join PUB_Report_Desc as B on A.Report_ID = B.Report_ID")
            content.AppendLine("   where A.Report_Id=@Report_Id and A.Print_Type=@Print_Type and A.Print_Cond=@Print_Cond            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_Id", pk_Report_Id)
            command.Parameters.AddWithValue("@Print_Type", pk_Print_Type)
            command.Parameters.AddWithValue("@Print_Cond", pk_Print_Cond)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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

    ''' <summary>
    ''' 取得 PUB DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPUBConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
