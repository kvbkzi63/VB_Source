
Imports System.Data.SqlClient
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Public Class PUBIpConfigBO_E1
    Inherits PUBIpConfigBO
    ''' <summary>
    ''' 根據IP取得對應單位
    ''' </summary>
    ''' <param name="ip"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryStationByIP(ByVal ip As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PUB_Ip_Config"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT IP, " & vbCrLf)
            sqlStr.Append("       IP_Name, " & vbCrLf)
            sqlStr.Append("       Station_No, " & vbCrLf)
            sqlStr.Append("       Is_Default " & vbCrLf)
            sqlStr.Append("FROM   PUB_Ip_Config " & vbCrLf)
            sqlStr.Append("WHERE  IP = '" & ip & "' ")


            command.CommandText = sqlStr.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException

            Throw sqlex

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
    '''取得Term_Code設定資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryStationByTermCode(ByVal inTermCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PCS_Terminal_Config1"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   PCS_Terminal_Config " & vbCrLf)
            sqlStr.Append("WHERE  Term_Code = '" & inTermCode & "' ")


            command.CommandText = sqlStr.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException

            Throw sqlex

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
    '''取得 PUB DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getPUBConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
End Class
