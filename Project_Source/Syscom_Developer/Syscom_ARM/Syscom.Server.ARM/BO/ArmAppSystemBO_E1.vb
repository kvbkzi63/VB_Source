Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.SQL

Public Class ArmAppSystemBO_E1
    Inherits ArmAppSystemBO

    ''' <summary>
    ''' 維護檔進行查詢
    ''' </summary>
    ''' <param name="app_system_no"></param>
    ''' <param name="app_system_name"></param>
    ''' <param name="app_display_order"></param>
    ''' <param name="app_flag_no"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAppSystem(ByVal app_system_no As String, ByVal app_system_name As String, ByVal app_display_order As String, ByVal app_flag_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT A.app_system_no, " & vbCrLf)
            sqlString.Append("       A.app_system_name, " & vbCrLf)
            sqlString.Append("       A.app_display_order, " & vbCrLf)
            sqlString.Append("       A.app_flag_no, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Code_Name) AS app_flag_name, " & vbCrLf)
            sqlString.Append("       app_creator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(app_create_datetime) AS app_create_datetime, " & vbCrLf)
            sqlString.Append("       app_operator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(app_update_datetime) AS app_update_datetime" & vbCrLf)
            sqlString.Append("FROM   ARM_App_System AS A " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS B " & vbCrLf)
            sqlString.Append("         ON B.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND A.app_flag_no = B.Code_Id " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If app_system_no <> "" Then
                sqlString.Append("       AND A.app_system_no = @app_system_no " & vbCrLf)
            End If

            If app_system_name <> "" Then
                sqlString.Append("       AND A.app_system_name = @app_system_name " & vbCrLf)
            End If

            If app_display_order <> "" Then
                sqlString.Append("       AND A.app_display_order = @app_display_order " & vbCrLf)
            End If

            If app_flag_no <> "" Then
                sqlString.Append("       AND A.app_flag_no = @app_flag_no " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY A.app_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@app_system_no", app_system_no)
            command.Parameters.AddWithValue("@app_system_name", app_system_name)
            command.Parameters.AddWithValue("@app_display_order", app_display_order)
            command.Parameters.AddWithValue("@app_flag_no", app_flag_no)
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
    ''' 維護檔進行查詢(下拉式選單)
    ''' </summary>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAppSystemCombobox(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT app_system_no, " & vbCrLf)
            sqlString.Append("       app_system_name, " & vbCrLf)
            sqlString.Append("       Rtrim(app_system_no) + ' - ' + Rtrim(app_system_name) AS cbo_app_system " & vbCrLf)
            sqlString.Append("FROM   ARM_App_System " & vbCrLf)
            sqlString.Append("ORDER  BY app_display_order ")

            command.CommandText = sqlString.ToString
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

End Class
