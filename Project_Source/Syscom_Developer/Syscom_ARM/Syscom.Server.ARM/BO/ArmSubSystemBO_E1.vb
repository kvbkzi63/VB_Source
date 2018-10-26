Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.SQL

Public Class ArmSubSystemBO_E1
    Inherits ArmSubSystemBO

    ''' <summary>
    ''' 維護檔進行查詢
    ''' </summary>
    ''' <param name="sub_system_no"></param>
    ''' <param name="sub_system_name"></param>
    ''' <param name="sub_app_system_no"></param>
    ''' <param name="sub_display_order"></param>
    ''' <param name="sub_flag_no"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSubSystem(ByVal sub_system_no As String, ByVal sub_system_name As String, ByVal sub_app_system_no As String, ByVal sub_display_order As String, ByVal sub_flag_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT A.sub_app_system_no, " & vbCrLf)
            sqlString.Append("       C.app_system_name, " & vbCrLf)
            sqlString.Append("       A.sub_system_no, " & vbCrLf)
            sqlString.Append("       A.sub_system_name, " & vbCrLf)
            sqlString.Append("       A.sub_display_order, " & vbCrLf)
            sqlString.Append("       A.sub_flag_no, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Code_Name) AS sub_flag_name, " & vbCrLf)
            sqlString.Append("       A.sub_creator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.sub_create_datetime) AS sub_create_datetime, " & vbCrLf)
            sqlString.Append("       A.sub_operator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.sub_update_datetime) AS sub_update_datetime " & vbCrLf)
            sqlString.Append("FROM   ARM_Sub_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_App_System AS C " & vbCrLf)
            sqlString.Append("         ON A.sub_app_system_no = C.app_system_no " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS B " & vbCrLf)
            sqlString.Append("         ON B.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND B.Code_Id = A.sub_flag_no " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If sub_system_no <> "" Then
                sqlString.Append("       AND A.sub_system_no = @sub_system_no " & vbCrLf)
            End If

            If sub_system_name <> "" Then
                sqlString.Append("       AND A.sub_system_name = @sub_system_name " & vbCrLf)
            End If

            If sub_app_system_no <> "" Then
                sqlString.Append("       AND A.sub_app_system_no = @sub_app_system_no " & vbCrLf)
            End If

            If sub_display_order <> "" Then
                sqlString.Append("       AND A.sub_display_order = @sub_display_order " & vbCrLf)
            End If

            If sub_flag_no <> "" Then
                sqlString.Append("       AND A.sub_flag_no = @sub_flag_no " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY C.app_display_order, " & vbCrLf)
            sqlString.Append("          A.sub_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@sub_system_no", sub_system_no)
            command.Parameters.AddWithValue("@sub_system_name", sub_system_name)
            command.Parameters.AddWithValue("@sub_app_system_no", sub_app_system_no)
            command.Parameters.AddWithValue("@sub_display_order", sub_display_order)
            command.Parameters.AddWithValue("@sub_flag_no", sub_flag_no)
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
    Public Function getSubSystemCombobox(ByVal sub_app_system_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT sub_system_no, " & vbCrLf)
            sqlString.Append("       sub_system_name, " & vbCrLf)
            sqlString.Append("       Rtrim(sub_system_no) + ' - ' + Rtrim(sub_system_name) AS cbo_sub_system " & vbCrLf)
            sqlString.Append("FROM   ARM_Sub_System " & vbCrLf)
            sqlString.Append("WHERE  sub_app_system_no = @sub_app_system_no " & vbCrLf)
            sqlString.Append("ORDER  BY sub_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@sub_app_system_no", sub_app_system_no)
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
