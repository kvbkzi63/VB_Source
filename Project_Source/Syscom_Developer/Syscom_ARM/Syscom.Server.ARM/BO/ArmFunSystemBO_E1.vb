Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.SQL

Public Class ArmFunSystemBO_E1
    Inherits ArmFunSystemBO

    ''' <summary>
    ''' 維護檔進行查詢
    ''' </summary>
    ''' <param name="app_system_no"></param>
    ''' <param name="sub_system_no"></param>
    ''' <param name="fun_task_no"></param>
    ''' <param name="fun_function_no"></param>
    ''' <param name="fun_function_name"></param>
    ''' <param name="fun_content"></param>
    ''' <param name="fun_special_flag"></param>
    ''' <param name="fun_display_order"></param>
    ''' <param name="fun_flag_no"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAllSystem(ByVal app_system_no As String, ByVal sub_system_no As String, ByVal fun_task_no As String, ByVal fun_function_no As String, ByVal fun_function_name As String, ByVal fun_content As String, ByVal fun_special_flag As String, ByVal fun_display_order As String, ByVal fun_flag_no As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT D.app_system_no, " & vbCrLf)
            sqlString.Append("       D.app_system_name, " & vbCrLf)
            sqlString.Append("       C.sub_system_no, " & vbCrLf)
            sqlString.Append("       C.sub_system_name, " & vbCrLf)
            sqlString.Append("       A.fun_task_no, " & vbCrLf)
            sqlString.Append("       B.tsk_task_name, " & vbCrLf)
            sqlString.Append("       A.fun_function_no, " & vbCrLf)
            sqlString.Append("       A.fun_function_name, " & vbCrLf)
            sqlString.Append("       A.fun_content, " & vbCrLf)
            sqlString.Append("       A.Fun_System_Memo, " & vbCrLf)
            sqlString.Append("       A.fun_special_flag, " & vbCrLf)
            sqlString.Append("       Rtrim(E.Code_Name)                     AS fun_special_flag_name, " & vbCrLf)
            sqlString.Append("       A.fun_display_order, " & vbCrLf)
            sqlString.Append("       A.fun_flag_no, " & vbCrLf)
            sqlString.Append("       Rtrim(F.Code_Name)                     AS fun_flag_name, " & vbCrLf)
            sqlString.Append("       A.fun_creator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.fun_create_datetime) AS fun_create_datetime, " & vbCrLf)
            sqlString.Append("       A.fun_operator_no, " & vbCrLf)
            sqlString.Append("       dbo.AdToRocTime(A.fun_update_datetime) AS fun_update_datetime " & vbCrLf)
            sqlString.Append("FROM   ARM_Fun_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Tsk_System AS B " & vbCrLf)
            sqlString.Append("                  INNER JOIN ARM_Sub_System AS C " & vbCrLf)
            sqlString.Append("                             INNER JOIN ARM_App_System AS D " & vbCrLf)
            sqlString.Append("                               ON C.sub_app_system_no = D.app_system_no " & vbCrLf)
            sqlString.Append("                    ON B.tsk_sub_system_no = C.sub_system_no " & vbCrLf)
            sqlString.Append("         ON A.fun_task_no = B.tsk_task_no " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS E " & vbCrLf)
            sqlString.Append("         ON E.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND A.fun_special_flag = E.Code_Id " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS F " & vbCrLf)
            sqlString.Append("         ON F.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND A.fun_flag_no = F.Code_Id " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If app_system_no <> "" Then
                sqlString.Append("       AND D.app_system_no = @app_system_no " & vbCrLf)
            End If

            If sub_system_no <> "" Then
                sqlString.Append("       AND C.sub_system_no = @sub_system_no " & vbCrLf)
            End If

            If fun_task_no <> "" Then
                sqlString.Append("       AND A.fun_task_no = @fun_task_no " & vbCrLf)
            End If

            If fun_function_no <> "" Then
                sqlString.Append("       AND A.fun_function_no = @fun_function_no " & vbCrLf)
            End If

            If fun_function_name <> "" Then
                sqlString.Append("       AND A.fun_function_name = @fun_function_name " & vbCrLf)
            End If

            If fun_content <> "" Then
                sqlString.Append("       AND A.fun_content = @fun_content " & vbCrLf)
            End If

            If fun_display_order <> "" Then
                sqlString.Append("       AND A.fun_display_order = @fun_display_order " & vbCrLf)
            End If

            If fun_special_flag <> "" Then
                sqlString.Append("       AND A.fun_special_flag = @fun_special_flag " & vbCrLf)
            End If

            If fun_flag_no <> "" Then
                sqlString.Append("       AND A.fun_flag_no = @fun_flag_no " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY D.app_display_order, " & vbCrLf)
            sqlString.Append("          C.sub_display_order, " & vbCrLf)
            sqlString.Append("          B.tsk_display_order, " & vbCrLf)
            sqlString.Append("          A.fun_display_order ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@app_system_no", app_system_no)
            command.Parameters.AddWithValue("@sub_system_no", sub_system_no)
            command.Parameters.AddWithValue("@fun_task_no", fun_task_no)
            command.Parameters.AddWithValue("@fun_function_no", fun_function_no)
            command.Parameters.AddWithValue("@fun_function_name", fun_function_name)
            command.Parameters.AddWithValue("@fun_content", fun_content)
            command.Parameters.AddWithValue("@fun_display_order", fun_display_order)
            command.Parameters.AddWithValue("@fun_special_flag", fun_special_flag)
            command.Parameters.AddWithValue("@fun_flag_no", fun_flag_no)
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
    ''' 登入取得基本權限功能
    ''' </summary>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryByLogin(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT TOP 1 D.app_system_no, " & vbCrLf)
            sqlString.Append("             D.app_system_name, " & vbCrLf)
            sqlString.Append("             C.sub_system_no, " & vbCrLf)
            sqlString.Append("             C.sub_system_name, " & vbCrLf)
            sqlString.Append("             B.tsk_task_no, " & vbCrLf)
            sqlString.Append("             B.tsk_task_name, " & vbCrLf)
            sqlString.Append("             A.* " & vbCrLf)
            sqlString.Append("FROM   Arm_Fun_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Tsk_System AS B " & vbCrLf)
            sqlString.Append("                  INNER JOIN ARM_Sub_System AS C " & vbCrLf)
            sqlString.Append("                             INNER JOIN ARM_App_System AS D " & vbCrLf)
            sqlString.Append("                               ON C.sub_app_system_no = D.app_system_no " & vbCrLf)
            sqlString.Append("                    ON B.tsk_sub_system_no = C.sub_system_no " & vbCrLf)
            sqlString.Append("         ON A.fun_task_no = B.tsk_task_no " & vbCrLf)
            sqlString.Append("WHERE  fun_function_name = '帳號密碼修改' ")

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
