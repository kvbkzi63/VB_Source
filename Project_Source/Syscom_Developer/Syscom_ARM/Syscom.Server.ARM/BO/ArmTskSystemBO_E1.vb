Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.SQL

Public Class ArmTskSystemBO_E1
    Inherits ArmTskSystemBO

    ''' <summary>
    ''' 維護檔進行查詢
    ''' </summary>
    ''' <param name="app_system_no"></param>
    ''' <param name="tsk_sub_system_no"></param>
    ''' <param name="tsk_task_no"></param>
    ''' <param name="tsk_task_name"></param>
    ''' <param name="tsk_display_order"></param>
    ''' <param name="tsk_task_flag_no"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAllSystem(ByVal app_system_no As String, ByVal tsk_sub_system_no As String, ByVal tsk_task_no As String, ByVal tsk_task_name As String, ByVal tsk_display_order As String, ByVal tsk_task_flag_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT C.app_system_no, " & vbCrLf)
            sqlString.Append("       C.app_system_name, " & vbCrLf)
            sqlString.Append("       A.tsk_sub_system_no, " & vbCrLf)
            sqlString.Append("       B.sub_system_name, " & vbCrLf)
            sqlString.Append("       A.tsk_task_no, " & vbCrLf)
            sqlString.Append("       A.tsk_task_name, " & vbCrLf)
            sqlString.Append("       A.tsk_display_order, " & vbCrLf)
            sqlString.Append("       A.tsk_task_flag_no, " & vbCrLf)
            sqlString.Append("       Rtrim(D.Code_Name) AS tsk_task_flag_name, " & vbCrLf)
            sqlString.Append("       A.tsk_creator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.tsk_create_datetime) AS tsk_create_datetime, " & vbCrLf)
            sqlString.Append("       A.tsk_operator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.tsk_update_datetime) AS tsk_update_datetime " & vbCrLf)
            sqlString.Append("FROM   ARM_Tsk_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Sub_System AS B " & vbCrLf)
            sqlString.Append("                  INNER JOIN ARM_App_System AS C " & vbCrLf)
            sqlString.Append("                    ON B.sub_app_system_no = C.app_system_no " & vbCrLf)
            sqlString.Append("         ON A.tsk_sub_system_no = B.sub_system_no " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS D " & vbCrLf)
            sqlString.Append("         ON D.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND D.Code_Id = A.tsk_task_flag_no " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If app_system_no <> "" Then
                sqlString.Append("       AND C.app_system_no = @app_system_no " & vbCrLf)
            End If

            If tsk_sub_system_no <> "" Then
                sqlString.Append("       AND A.tsk_sub_system_no = @tsk_sub_system_no " & vbCrLf)
            End If

            If tsk_task_no <> "" Then
                sqlString.Append("       AND A.tsk_task_no = @tsk_task_no " & vbCrLf)
            End If

            If tsk_task_name <> "" Then
                sqlString.Append("       AND A.tsk_task_name = @tsk_task_name " & vbCrLf)
            End If

            If tsk_display_order <> "" Then
                sqlString.Append("       AND A.tsk_display_order = @tsk_display_order " & vbCrLf)
            End If

            If tsk_task_flag_no <> "" Then
                sqlString.Append("       AND A.tsk_task_flag_no = @tsk_task_flag_no " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY C.app_display_order, " & vbCrLf)
            sqlString.Append("          B.sub_display_order, " & vbCrLf)
            sqlString.Append("          A.tsk_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@app_system_no", app_system_no)
            command.Parameters.AddWithValue("@tsk_sub_system_no", tsk_sub_system_no)
            command.Parameters.AddWithValue("@tsk_task_no", tsk_task_no)
            command.Parameters.AddWithValue("@tsk_task_name", tsk_task_name)
            command.Parameters.AddWithValue("@tsk_display_order", tsk_display_order)
            command.Parameters.AddWithValue("@tsk_task_flag_no", tsk_task_flag_no)
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
    Public Function getTskSystemCombobox(ByVal tsk_sub_system_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT tsk_task_no, " & vbCrLf)
            sqlString.Append("       tsk_task_name, " & vbCrLf)
            sqlString.Append("       Rtrim(tsk_task_no) + ' - ' + Rtrim(tsk_task_name) AS cbo_tsk_system " & vbCrLf)
            sqlString.Append("FROM   Arm_Tsk_System " & vbCrLf)
            sqlString.Append("WHERE  tsk_sub_system_no = @tsk_sub_system_no " & vbCrLf)
            sqlString.Append("ORDER  BY tsk_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@tsk_sub_system_no", tsk_sub_system_no)
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
