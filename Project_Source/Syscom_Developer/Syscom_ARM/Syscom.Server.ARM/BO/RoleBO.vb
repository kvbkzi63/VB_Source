Imports System.DirectoryServices
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Server.CMM

Public Class RoleBO

    Dim tableName As String = "Role"                        'Table名稱
    Dim columnName() As String = {"角色名稱", "是否歸屬"}   '欄位名稱

#Region "角色歸屬的相關操作"

    ''' <summary>
    ''' 取所歸屬的角色
    ''' </summary>
    ''' <param name="inputds" >查詢資料</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-8-29</remarks>
    Public Function RoleBelongQuery(ByVal inputds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("--使用者所屬權限" & vbCrLf)
            sqlString.Append("SELECT ARN.[roleID]                          AS roleID, " & vbCrLf)
            sqlString.Append("       ARN.[roleName]                        AS roleName " & vbCrLf)
            sqlString.Append("FROM   Arm_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN Arm_RoleName AS ARN " & vbCrLf)
            sqlString.Append("         ON AR.Role = ARN.[roleID] " & vbCrLf)
            sqlString.Append("WHERE  AR.Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("       AND ARN.[isValid] = 'Y' ")
            sqlString.Append(";" & vbCrLf)
            sqlString.Append("--全部權限的樹狀結構" & vbCrLf)
            sqlString.Append("SELECT DISTINCT ''                                                       AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("                ''                                                       AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("                Substring (AR.roleID, 1, 3)                              AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("                Isnull(ASS.sub_system_name, Substring (AR.roleID, 1, 3)) AS Layer_Code_Name " & vbCrLf)
            sqlString.Append("FROM   Arm_RoleName AS AR " & vbCrLf)
            sqlString.Append("       LEFT JOIN Arm_Sub_System AS ASS " & vbCrLf)
            sqlString.Append("         ON Substring (AR.roleID, 1, 3) = ASS.sub_system_no " & vbCrLf)
            sqlString.Append("WHERE  AR.isValid = 'Y' " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT Substring (roleID, 1, 3) AS Parent_Code_Id, " & vbCrLf)
            sqlString.Append("       Substring (roleID, 1, 3) AS Parent_Code_Name, " & vbCrLf)
            sqlString.Append("       roleID                   AS Layer_Code_Id, " & vbCrLf)
            sqlString.Append("       roleName                 AS Layer_Code_Name " & vbCrLf)
            sqlString.Append("FROM   Arm_RoleName " & vbCrLf)
            sqlString.Append("WHERE  isValid = 'Y' ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", inputds.Tables(0).Rows(0).Item("userid"))
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
    ''' 更新
    ''' </summary>
    ''' <param name="dsParam"></param>
    ''' <param name="dsRoleInfo"></param>
    ''' <remarks></remarks>
    Public Function RoleBelongUpdate(ByVal dsParam As DataSet, ByVal dsRoleInfo As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Dim scope As TransactionScope = Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim EmployeeCode As String = ""

            If dsParam.Tables.Count > 0 Then
                EmployeeCode = dsParam.Tables("User").Rows(0).Item("UserID").ToString
            End If

            scope = SQLConnFactory.getInstance.getRequiredTransactionScope

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim m_ARMRolesBO As New ArmRolesBO

            '先刪除所有角色資料
            DeleteByEmployeeCode(EmployeeCode, conn)

            '新增角色資料
            count = m_ARMRolesBO.insert(dsRoleInfo, conn)

            scope.Complete()

            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
            If scope IsNot Nothing Then scope.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 刪除 員工代碼 所包含的角色
    ''' </summary>
    ''' <param name="Employee_Code" >員工代碼</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-8-30</remarks>
    Private Function DeleteByEmployeeCode(ByVal Employee_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = _
            "delete from Arm_Roles where " & _
            " Employee_Code = @Employee_Code             "

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
                command.Parameters.AddWithValue("@Employee_Code", Employee_Code)

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
    ''' SearchResultCollection -> DataSet
    ''' </summary>
    ''' <param name="src"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function transformToDataSet(ByVal src As SearchResultCollection) As DataSet
        Dim ds As DataSet
        ds = genDataSet()

        '將查詢結果塞到DataSet的DataTable中
        For Each sr As SearchResult In src
            Dim paraValue(columnName.Length - 1) As Object

            paraValue(0) = sr.Properties("cn").Item(0).ToString()
            paraValue(1) = "0"

            ds.Tables(0).Rows.Add(paraValue)
        Next

        '將Table中的資料以PK欄位做遞增排序
        Dim dsTmp As New DataSet
        Dim rows() As System.Data.DataRow = ds.Tables(0).Select("1=1", "角色名稱")

        dsTmp = genDataSet()

        For i As Integer = 0 To rows.Length - 1
            dsTmp.Tables(0).ImportRow(rows(i))
        Next

        Return dsTmp
    End Function

    ''' <summary>
    ''' 產生一個DataSet且加入一個空的Table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function genDataSet() As DataSet
        Dim ds As New DataSet
        ds.Tables.Add(tableName)
        For i As Integer = 0 To columnName.Length - 1
            ds.Tables(tableName).Columns.Add(columnName(i))
        Next
        '設定Table PKey
        Dim pkcs() As Data.DataColumn = {ds.Tables(tableName).Columns("角色名稱")}
        ds.Tables(tableName).PrimaryKey = pkcs
        Return ds
    End Function

#End Region

#Region "角色的相關操作 - By Table "

    ''' <summary>
    ''' 新增角色 每個 Role 第一個是ID, NAME, IsVALID
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Function AddRole(ByVal ds As DataSet) As Integer
        Try
            Dim armBo As ArmRoleNameBO_E1 = ArmRoleNameBO_E1.getInstance
            Return armBo.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        End Try
    End Function

    ''' <summary>
    ''' 更新角色 使用第一個欄位資料查詢而第二第三欄位資料用來更新
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Function ModifyRole(ByVal ds As DataSet) As Integer
        Try
            Dim armBo As ArmRoleNameBO_E1 = ArmRoleNameBO_E1.getInstance
            Return armBo.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try
    End Function

    ''' <summary>
    ''' 刪除角色 只傳RoleId
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Function DeleteRole(ByVal ds As DataSet) As Integer
        Try
            Dim count As Integer = 0
            If ds.Tables.Count > 0 Then
                Dim roleId As String = ds.Tables(0).Rows(0).Item("roleID").ToString
                Dim armBo As ArmRoleNameBO_E1 = ArmRoleNameBO_E1.getInstance
                Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                    Using PubConn As System.Data.IDbConnection = armBo.getConnection
                        PubConn.Open()
                        count += armBo.delete(roleId, PubConn)
                        count += ArmRoleRightsBO_E1.getInstance.deleteAllRoleRights(roleId, PubConn)
                        count += armBo.deleteAllRole(roleId, PubConn)
                    End Using
                    Scope.Complete()
                End Using
            End If
            Return count
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得角色權限
    ''' </summary>
    ''' <param name="roleID" ></param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-7-18</remarks>
    Public Function QueryRole(ByVal roleID As String, ByVal roleName As String, ByVal isValid As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim tableName As String = "Role"

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(A.roleID)                    AS roleID, " & vbCrLf)
            sqlString.Append("       Rtrim(A.roleName)                  AS roleName, " & vbCrLf)
            sqlString.Append("       A.isValid                          AS isValid, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Code_Name)                 AS isValidName, " & vbCrLf)
            sqlString.Append("       A.isAgent                          AS isAgent, " & vbCrLf)
            sqlString.Append("       Rtrim(C.Code_Name)                 AS isAgentName, " & vbCrLf)
            sqlString.Append("       A.creator_no                       AS creator_no, " & vbCrLf)
            sqlString.Append("       dbo.Adtoroctime(A.create_datetime) AS create_datetime, " & vbCrLf)
            sqlString.Append("       A.operator_no                      AS operator_no, " & vbCrLf)
            sqlString.Append("       dbo.Adtoroctime(A.update_datetime) AS update_datetime, " & vbCrLf)
            sqlString.Append("       A.opd_flag, " & vbCrLf)
            sqlString.Append("       A.eis_flag, " & vbCrLf)
            sqlString.Append("       A.pcs_flag, " & vbCrLf)
            sqlString.Append("       A.roleMember,  " & vbCrLf)
            sqlString.Append("       A.del_Flag  " & vbCrLf)
            sqlString.Append("FROM   Arm_RoleName AS A " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS B " & vbCrLf)
            sqlString.Append("         ON B.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND B.Code_Id = A.isValid " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN PUB_Syscode AS C " & vbCrLf)
            sqlString.Append("         ON C.Type_Id = '9000' " & vbCrLf)
            sqlString.Append("            AND C.Code_Id = A.isAgent " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)


            If roleID <> "" Then
                sqlString.Append("       AND A.roleID LIKE @roleID " & vbCrLf)
            End If

            If roleName <> "" Then
                sqlString.Append("       AND A.roleName LIKE @roleName " & vbCrLf)
            End If

            If isValid <> "" Then
                sqlString.Append("       AND A.isValid = @isValid " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY A.roleID ")
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@roleID", "%" & roleID & "%")
            command.Parameters.AddWithValue("@roleName", "%" & roleName & "%")
            command.Parameters.AddWithValue("@isValid", isValid)
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

#End Region

#Region "多面向查詢功能"

    ''' <summary>
    ''' 查詢人員的角色與功能
    ''' </summary>
    ''' <param name="Employee_Code" >員工代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function RoleQueryByEmployee(ByVal Employee_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT DISTINCT Rtrim(AR.Role)             AS '角色代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(ARN.roleName)        AS '角色名稱', " & vbCrLf)
            sqlString.Append("                Rtrim(ARR.rrs_rights_id)   AS '功能代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(ASS.sub_system_name) AS '功能名稱' " & vbCrLf)
            sqlString.Append("FROM   ARM_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_RoleName AS ARN " & vbCrLf)
            sqlString.Append("         ON AR.Role = ARN.roleID " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Rolerights AS ARR " & vbCrLf)
            sqlString.Append("         ON Rtrim(AR.Role) = Rtrim(ARR.rrs_role_id) " & vbCrLf)
            sqlString.Append("            AND ARR.rrs_rights_type = 'sub' " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Sub_System AS ASS " & vbCrLf)
            sqlString.Append("         ON Rtrim(ARR.rrs_rights_id) = Rtrim(ASS.sub_system_no) " & vbCrLf)
            sqlString.Append("WHERE  AR.Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT DISTINCT Rtrim(AR.Role)           AS '角色代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(ARN.roleName)      AS '角色名稱', " & vbCrLf)
            sqlString.Append("                Rtrim(ARR.rrs_rights_id) AS '功能代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(ATS.tsk_task_name) AS '功能名稱' " & vbCrLf)
            sqlString.Append("FROM   ARM_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_RoleName AS ARN " & vbCrLf)
            sqlString.Append("         ON AR.Role = ARN.roleID " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Rolerights AS ARR " & vbCrLf)
            sqlString.Append("         ON Rtrim(AR.Role) = Rtrim(ARR.rrs_role_id) " & vbCrLf)
            sqlString.Append("            AND ARR.rrs_rights_type = 'tsk' " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Tsk_System AS ATS " & vbCrLf)
            sqlString.Append("         ON Rtrim(ARR.rrs_rights_id) = Rtrim(ATS.tsk_task_no) " & vbCrLf)
            sqlString.Append("WHERE  AR.Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append("SELECT DISTINCT Rtrim(AR.Role)               AS '角色代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(ARN.roleName)          AS '角色名稱', " & vbCrLf)
            sqlString.Append("                Rtrim(ARR.rrs_rights_id)     AS '功能代碼', " & vbCrLf)
            sqlString.Append("                Rtrim(AFS.fun_function_name) AS '功能名稱' " & vbCrLf)
            sqlString.Append("FROM   ARM_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_RoleName AS ARN " & vbCrLf)
            sqlString.Append("         ON AR.Role = ARN.roleID " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Rolerights AS ARR " & vbCrLf)
            sqlString.Append("         ON Rtrim(AR.Role) = Rtrim(ARR.rrs_role_id) " & vbCrLf)
            sqlString.Append("            AND ARR.rrs_rights_type = 'fun' " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Fun_System AS AFS " & vbCrLf)
            sqlString.Append("         ON Rtrim(ARR.rrs_rights_id) = Rtrim(AFS.fun_function_no) " & vbCrLf)
            sqlString.Append("WHERE  AR.Employee_Code = @Employee_Code ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", Employee_Code)
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
    ''' 查詢角色歸屬的人員
    ''' </summary>
    ''' <param name="Role_Id" >角色代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByRole(ByVal Role_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(AR.Employee_Code) AS '員工編號', " & vbCrLf)
            sqlString.Append("       Rtrim(PE.Employee_Name) AS '姓名' " & vbCrLf)
            sqlString.Append("FROM   ARM_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Employee AS PE " & vbCrLf)
            sqlString.Append("         ON AR.Employee_Code = PE.Employee_Code " & vbCrLf)
            sqlString.Append("                  AND pe.Assume_End_Date >= Getdate() " & vbCrLf)
            sqlString.Append("WHERE  Role = @Role_Id ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Role_Id", Role_Id)
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
    ''' 查詢功能歸屬的人員
    ''' </summary>
    ''' <param name="Fun_Function_No" >功能代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByFunction(ByVal Fun_Function_No As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(AR.Employee_Code) AS '員工編號', " & vbCrLf)
            sqlString.Append("       Rtrim(PE.Employee_Name) AS '姓名', " & vbCrLf)
            sqlString.Append("       Rtrim(ARN.roleId)       AS '角色代碼', " & vbCrLf)
            sqlString.Append("       Rtrim(ARN.roleName)     AS '角色名稱' " & vbCrLf)
            sqlString.Append("FROM   ARM_Roles AS AR " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_RoleName AS ARN " & vbCrLf)
            sqlString.Append("         ON Rtrim(AR.Role) = Rtrim(ARN.roleID) " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Employee AS PE " & vbCrLf)
            sqlString.Append("         ON AR.Employee_Code = PE.Employee_Code " & vbCrLf)
            sqlString.Append("          AND PE.Assume_End_Date >= Getdate() " & vbCrLf)
            sqlString.Append("       INNER JOIN ARM_Rolerights AS ARR " & vbCrLf)
            sqlString.Append("         ON Rtrim(AR.Role) = Rtrim(ARR.rrs_role_id) " & vbCrLf)
            sqlString.Append("WHERE  ARR.rrs_rights_id = @Fun_Function_No " & vbCrLf)
            sqlString.Append("       AND ARR.rrs_rights_type = 'fun' ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Fun_Function_No", Fun_Function_No)
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

#End Region

    ''' <summary>
    ''' 取得SQL連線
    ''' </summary> 
    ''' <remarks>by Sean.Lin on 2013-7-18</remarks>
    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
