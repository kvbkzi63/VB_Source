Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO

Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility

Public Class PUBDynamicBS
    Implements IDisposable

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "########## getInstance() ##########"

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBDynamicBS
        Try

            Return New PUBDynamicBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    ''' <summary>
    '''以 SQL String 動態查詢
    ''' </summary>
    ''' <param name="sqlString">查詢的 SQL 字串</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks>不建議直接使用此方法</remarks>
    Public Function dynamicQuery(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("DynamicQuery")
                adapter.Fill(ds, "DynamicQuery")
                'adapter.FillSchema(ds, SchemaType.Mapped, "DynamicQuery")
            End Using
            Return ds
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.StackTrace, sqlex)
            CreateTXTLogFile("PUBDynamicBS-dynamicQuery-SQLStr", sqlString, False)
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function dynamicQueryForEis(ByRef DynamicSelect As String) As DataSet

        Dim sqlConn As SqlConnection = Nothing

        Try
            Dim ds As New DataSet
            sqlConn = getEisConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = DynamicSelect
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                adapter.Fill(ds, "Query_Detail")
                adapter.FillSchema(ds, SchemaType.Mapped, "Query_Detail")
            End Using
            Return ds
        Catch ex As Exception
            '追蹤用on 20161021 by Lits
            CreateTXTLogFile("dynamicQueryForEis", DynamicSelect.ToString, False)
            Throw ex
        Finally
            If sqlConn IsNot Nothing Then
                sqlConn.Dispose()
            End If
        End Try
    End Function

    Public Function dynamicQueryEmr(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getEmrConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("DynamicQuery")
                adapter.Fill(ds, "DynamicQuery")
                adapter.FillSchema(ds, SchemaType.Mapped, "DynamicQuery")
            End Using
            Return ds
        Catch sqlex As SqlException
            '追蹤用on 20161021 by Lits
            CreateTXTLogFile("dynamicQueryEmr", sqlString.ToString, False)

            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''取得資料庫連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Private Function getEisConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getEisDBSqlConn
    End Function

    Public Function getEmrConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getEmrDBSqlConn
    End Function

    '追蹤用 By Lits on 20161013
    Private Sub CreateTXTLogFile(ByVal ActionFunctionName As String, ByVal data As String, ByVal result As Boolean)

        Dim sysdate As String = Now.ToString("yyyyMMddHHmmddfff")

        Dim FilePath As String = "C:\TempFile\" & sysdate & "-" & ActionFunctionName & ".txt"


        Dim sw As StreamWriter = New StreamWriter(FilePath, True)

        sw.WriteLine("    -------------------------------------------------")

        sw.WriteLine("    " & ActionFunctionName)

        sw.WriteLine("    -------------------------------------------------")

        sw.WriteLine("    是否成功? >> " & result)
        sw.WriteLine("    --------")

        sw.WriteLine("    -------------------------------------------------")
        sw.WriteLine("    SQL Script Begin***********************************************")
        sw.WriteLine(data)
        sw.WriteLine("    SQL Script End***********************************************")


        '關閉檔案
        sw.Flush()
        sw.Close()
    End Sub
#Region "檢查SQL 語法"
    ''' <summary>
    ''' 檢查SQL 語法是否正確
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateSQL(sql As String) As Boolean
        Dim bResult As Boolean
        Dim conn As SqlConnection = getConnection()
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandText = "SET PARSEONLY ON"
        cmd.ExecuteNonQuery()
        Try
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            bResult = True
        Catch ex As Exception
            bResult = False
        Finally
            cmd.CommandText = "SET PARSEONLY OFF"
            cmd.ExecuteNonQuery()
            If ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return bResult
    End Function
#End Region
End Class
