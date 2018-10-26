Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO

Public Class ArmRoleRightsBO_E1
    Inherits ArmRolerightsBO

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Shadows ReadOnly Property getInstance() As ArmRoleRightsBO_E1
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New ArmRoleRightsBO_E1()
    End Class

#End Region

    ''' <summary>
    ''' 查詢角色ID 以Roleid為索引
    ''' </summary>
    ''' <param name="Roleid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectRoleRights(ByVal RoleID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT CASE " & vbCrLf)
            sqlString.Append("         WHEN D.fun_function_name IS NOT NULL THEN Rtrim(D.fun_function_name) " & vbCrLf)
            sqlString.Append("         WHEN C.tsk_task_name IS NOT NULL THEN Rtrim(C.tsk_task_name) " & vbCrLf)
            sqlString.Append("         ELSE Rtrim(B.sub_system_name) " & vbCrLf)
            sqlString.Append("       END                                                     AS rrs_rights_name, " & vbCrLf)
            sqlString.Append("       Rtrim(A.rrs_rights_id) + '@' + Rtrim(A.rrs_rights_type) AS nodeValue, " & vbCrLf)
            sqlString.Append("       D.fun_special_flag, " & vbCrLf)
            sqlString.Append("       A.* " & vbCrLf)
            sqlString.Append("FROM   ARM_Rolerights AS A " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN ARM_Sub_System AS B " & vbCrLf)
            sqlString.Append("         ON A.rrs_rights_type = 'sub' " & vbCrLf)
            sqlString.Append("            AND A.rrs_rights_id = B.sub_system_no " & vbCrLf)
            sqlString.Append("            AND B.sub_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN ARM_Tsk_System AS C " & vbCrLf)
            sqlString.Append("         ON A.rrs_rights_type = 'tsk' " & vbCrLf)
            sqlString.Append("            AND A.rrs_rights_id = C.tsk_task_no " & vbCrLf)
            sqlString.Append("            AND C.tsk_task_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN ARM_Fun_System AS D " & vbCrLf)
            sqlString.Append("         ON A.rrs_rights_type = 'fun' " & vbCrLf)
            sqlString.Append("            AND A.rrs_rights_id = D.fun_function_no " & vbCrLf)
            sqlString.Append("            AND D.fun_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  ( B.sub_app_system_no IS NOT NULL " & vbCrLf)
            sqlString.Append("          OR C.tsk_task_no IS NOT NULL " & vbCrLf)
            sqlString.Append("          OR D.fun_function_no IS NOT NULL ) " & vbCrLf)
            sqlString.Append("       AND A.rrs_role_id = @rrs_role_id " & vbCrLf)
            sqlString.Append("ORDER  BY A.rrs_role_id, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_type, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_id ")


            '只取有按鈕權限的功能層級
            sqlString.Append("SELECT  " & vbCrLf)
            sqlString.Append("       Rtrim(D.fun_function_name)                              AS rrs_rights_name, " & vbCrLf)
            sqlString.Append("       Rtrim(A.rrs_rights_id) + '@' + Rtrim(A.rrs_rights_type) AS nodeValue, " & vbCrLf)
            sqlString.Append("       D.fun_special_flag, " & vbCrLf)
            sqlString.Append("       A.* " & vbCrLf)
            sqlString.Append("FROM   ARM_Rolerights AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Fun_System AS D " & vbCrLf)
            sqlString.Append("         ON A.rrs_rights_type = 'fun' " & vbCrLf)
            sqlString.Append("            AND A.rrs_rights_id = D.fun_function_no " & vbCrLf)
            sqlString.Append("            AND D.fun_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  D.fun_function_no IS NOT NULL " & vbCrLf)
            sqlString.Append("       AND A.rrs_role_id = @rrs_role_id " & vbCrLf)
            sqlString.Append("       AND D.fun_special_flag = 'Y' " & vbCrLf)
            sqlString.Append("ORDER  BY A.rrs_role_id, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_type, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_id ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@rrs_role_id", RoleID)
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''查詢角色功能設定全部資料
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryAllRoleRights(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT ''                             AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("       ''                             AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("       app_system_no + '@app'         AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("       '[系統] - ' + app_system_name  AS Layer_Code_Name, " & vbCrLf)
            sqlString.Append("       app_display_order              AS app_display_order, " & vbCrLf)
            sqlString.Append("       0                              AS sub_display_order, " & vbCrLf)
            sqlString.Append("       0                              AS tsk_display_order, " & vbCrLf)
            sqlString.Append("       0                              AS fun_display_order " & vbCrLf)
            sqlString.Append("FROM   ARM_App_System " & vbCrLf)
            sqlString.Append("WHERE  app_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT A.sub_app_system_no + '@app'       AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("       B.app_system_name                  AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("       A.sub_system_no + '@sub'           AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("       '[子系統] - ' + A.sub_system_name  AS Layer_Code_Name, " & vbCrLf)
            sqlString.Append("       999                                AS app_display_order, " & vbCrLf)
            sqlString.Append("       A.sub_display_order                AS sub_display_order, " & vbCrLf)
            sqlString.Append("       0                                  AS tsk_display_order, " & vbCrLf)
            sqlString.Append("       0                                  AS fun_display_order " & vbCrLf)
            sqlString.Append("FROM   ARM_Sub_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_App_System AS B " & vbCrLf)
            sqlString.Append("         ON A.sub_app_system_no = B.app_system_no " & vbCrLf)
            sqlString.Append("            AND B.app_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  A.sub_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT A.tsk_sub_system_no + '@sub'   AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("       B.sub_system_name              AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("       A.tsk_task_no + '@tsk'         AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("       '[作業] - ' + A.tsk_task_name  AS Layer_Code_Name, " & vbCrLf)
            sqlString.Append("       999                            AS app_display_order, " & vbCrLf)
            sqlString.Append("       999                            AS sub_display_order, " & vbCrLf)
            sqlString.Append("       A.tsk_display_order            AS tsk_display_order, " & vbCrLf)
            sqlString.Append("       0                              AS fun_display_order " & vbCrLf)
            sqlString.Append("FROM   ARM_Tsk_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Sub_System AS B " & vbCrLf)
            sqlString.Append("         ON A.tsk_sub_system_no = B.sub_system_no " & vbCrLf)
            sqlString.Append("            AND B.sub_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  A.tsk_task_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT A.fun_task_no + '@tsk'                             AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("       B.tsk_task_name                                    AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("       A.fun_function_no + '@fun@' + A.fun_special_flag   AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("       '[功能] - ' + A.fun_function_name                  AS Layer_Code_Name, " & vbCrLf)
            sqlString.Append("       999                                                AS app_display_order, " & vbCrLf)
            sqlString.Append("       999                                                AS sub_display_order, " & vbCrLf)
            sqlString.Append("       999                                                AS tsk_display_order, " & vbCrLf)
            sqlString.Append("       A.fun_display_order                                AS fun_display_order " & vbCrLf)
            sqlString.Append("FROM   ARM_Fun_System AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Tsk_System AS B " & vbCrLf)
            sqlString.Append("         ON A.fun_task_no = B.tsk_task_no " & vbCrLf)
            sqlString.Append("            AND B.tsk_task_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  A.fun_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("ORDER  BY app_display_order, " & vbCrLf)
            sqlString.Append("          sub_display_order, " & vbCrLf)
            sqlString.Append("          tsk_display_order, " & vbCrLf)
            sqlString.Append("          fun_display_order ")

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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 刪除角色功能設定全部資料
    ''' </summary>
    ''' <param name="pk_rrs_role_id"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteAllRoleRights(ByVal pk_rrs_role_id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " rrs_role_id=@rrs_role_id "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@rrs_role_id", pk_rrs_role_id)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢角色ID 以 userMemberOf 為索引
    ''' </summary>
    ''' <param name="userMemberOf">使用者歸屬角色</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRoleRightsByMemberOf(ByVal userMemberOf As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim token() As String = userMemberOf.Split(",")
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT DISTINCT A.*, " & vbCrLf)
            sqlString.Append("                D.fun_special_flag " & vbCrLf)
            sqlString.Append("FROM   ARM_Rolerights AS A " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Fun_System AS D " & vbCrLf)
            sqlString.Append("         ON A.rrs_rights_type = 'fun' " & vbCrLf)
            sqlString.Append("            AND A.rrs_rights_id = D.fun_function_no " & vbCrLf)
            sqlString.Append("            AND D.fun_flag_no = 'Y' " & vbCrLf)
            sqlString.Append("WHERE  D.fun_function_no IS NOT NULL " & vbCrLf)
            sqlString.Append("       AND A.rrs_role_id IN ( " & vbCrLf)

            Dim comToken As String = ""
            For i As Integer = 0 To token.Count - 1
                If comToken <> "" Then
                    comToken &= ","
                End If
                comToken &= "@" & i
            Next

            sqlString.Append(" " & comToken & " " & vbCrLf)
            sqlString.Append("       ) " & vbCrLf)
            sqlString.Append("ORDER  BY A.rrs_role_id, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_type, " & vbCrLf)
            sqlString.Append("          A.rrs_rights_id ")

            command.CommandText = sqlString.ToString
            For i As Integer = 0 To token.Count - 1
                command.Parameters.AddWithValue("@" & i, token(i))
            Next
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

End Class
