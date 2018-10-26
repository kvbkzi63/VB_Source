Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports System.Configuration
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.PUB

Public Class LoginModuleBO

#Region " 變數宣告 "

    '宣告Log
    Dim log As LOGDelegate = LOGDelegate.getInstance

#End Region

#Region " 回傳個人資料、授權功能資料"

    ''' <summary>
    ''' 回傳個人資料、授權功能資料
    ''' </summary>
    ''' <param name="id">登入帳號</param>
    ''' <param name="password">登入密碼</param>
    ''' <param name="system_type_id">系統歸屬 O:門診 E:急診 I:住院</param>
    ''' <returns>回傳 DataSet 包含兩個DataTable (1)UserInfo(2)AppInfo</returns>
    ''' <remarks></remarks>
    Public Function Login(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As DataSet
 
        Dim ds As New DataSet
        Dim employeeCode As String = ""
        Dim conn As System.Data.IDbConnection = getConnection()
        Try

            'employeeCode = GetEmployeeCodeByDrCode(id, conn)
            'If employeeCode <> "" Then
            '    Return LoginProcess(employeeCode, password, system_type_id)
            'Else
            Return LoginProcess(id, password, system_type_id)
            'End If


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("ARMCMME001", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 回傳個人資料、授權功能資料
    ''' </summary>
    ''' <param name="pk_roleID"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoginForSys(ByRef pk_roleID As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataTable
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT fun_function_no, " & vbCrLf)
            sqlString.Append("       fun_function_name, " & vbCrLf)
            sqlString.Append("       fun_display_order, " & vbCrLf)
            sqlString.Append("       fun_content, " & vbCrLf)
            sqlString.Append("       sub_system_no, " & vbCrLf)
            sqlString.Append("       sub_system_name, " & vbCrLf)
            sqlString.Append("       sub_display_order, " & vbCrLf)
            sqlString.Append("       fun_task_no, " & vbCrLf)
            sqlString.Append("       tsk_task_name, " & vbCrLf)
            sqlString.Append("       tsk_display_order, " & vbCrLf)
            sqlString.Append("       app_system_no " & vbCrLf)
            sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
            sqlString.Append("       arm_tsk_system, " & vbCrLf)
            sqlString.Append("       arm_sub_system, " & vbCrLf)
            sqlString.Append("       arm_app_system " & vbCrLf)
            sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
            sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
            sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
            sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                 WHERE  ( ( rrs_role_id = @rrs_role_id ) " & vbCrLf)
            sqlString.Append("                                          AND rrs_rights_type = @Fun )) " & vbCrLf)
            sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                 WHERE  ( ( rrs_role_id = @rrs_role_id ) " & vbCrLf)
            sqlString.Append("                                          AND rrs_rights_type = @Tsk )) " & vbCrLf)
            sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                   WHERE  ( ( rrs_role_id = @rrs_role_id ) " & vbCrLf)
            sqlString.Append("                                            AND rrs_rights_type = @Sub )) ) " & vbCrLf)
            sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
            sqlString.Append("          sub_system_no, " & vbCrLf)
            sqlString.Append("          tsk_display_order, " & vbCrLf)
            sqlString.Append("          fun_task_no, " & vbCrLf)
            sqlString.Append("          fun_display_order, " & vbCrLf)
            sqlString.Append("          fun_function_no ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@rrs_role_id", pk_roleID)
            command.Parameters.AddWithValue("@Flag_No", "Y")
            command.Parameters.AddWithValue("@Fun", "fun")
            command.Parameters.AddWithValue("@Tsk", "tsk")
            command.Parameters.AddWithValue("@Sub", "sub")
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("AppInfo")
                adapter.Fill(ds, "AppInfo")
                'adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
            End Using
            Return ds.Tables(0)
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
    ''' 回傳代理的資料、授權功能資料
    ''' </summary>
    ''' <param name="userRoleArrayList"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoginForAgent(ByVal loginUserId As String, ByRef userRoleArrayList() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim userid As String = ""
        Dim username As String = ""
        Dim userbirthday As String = ""
        Dim usermail As String = ""
        Dim userdepartmentnumber As String = ""
        Dim userdepartment As String = ""
        Dim useraccexpireddate As String = ""
        Dim userpwdexpireddate As String = ""
        Dim useraccountcontrol As String = ""
        Dim userlocked As String = ""
        Dim useractivate As String = ""
        Dim userWarningMessage As String = ""
        Dim userErrMessage As String = ""
        Dim userMemberOf As String = ""
        Dim dtUserInfo As New DataTable("UserInfo")
        Dim connFlag As Boolean = conn Is Nothing
        Try
            '使用DB中的資料
            Dim pub As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
            Dim empDS As DataSet = pub.queryByPK(loginUserId)

            userid = loginUserId
            username = empDS.Tables(0).Rows(0).Item("Employee_Name").ToString.Trim

            '2014-09-01 Sean 統一取得Employee Method
            Dim dsTemp As DataSet = pub.queryEmployeeByEmpCodeAndDate(loginUserId, Now.Date)
            If dsTemp.Tables(0).Rows.Count <> 0 Then
                userdepartmentnumber = dsTemp.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim
                userdepartment = dsTemp.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim
            End If

            For Each roleId As String In userRoleArrayList
                If userMemberOf <> "" Then
                    userMemberOf &= ","
                End If
                userMemberOf &= "'" & roleId & "'"
            Next

            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT fun_function_no, " & vbCrLf)
            sqlString.Append("       fun_function_name, " & vbCrLf)
            sqlString.Append("       fun_display_order, " & vbCrLf)
            sqlString.Append("       fun_content, " & vbCrLf)
            sqlString.Append("       sub_system_no, " & vbCrLf)
            sqlString.Append("       sub_system_name, " & vbCrLf)
            sqlString.Append("       sub_display_order, " & vbCrLf)
            sqlString.Append("       fun_task_no, " & vbCrLf)
            sqlString.Append("       tsk_task_name, " & vbCrLf)
            sqlString.Append("       tsk_display_order, " & vbCrLf)
            sqlString.Append("       app_system_no " & vbCrLf)
            sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
            sqlString.Append("       arm_tsk_system, " & vbCrLf)
            sqlString.Append("       arm_sub_system, " & vbCrLf)
            sqlString.Append("       arm_app_system " & vbCrLf)
            sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
            sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
            sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
            sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
            sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                 WHERE  ( ( " & vbCrLf)

            For i As Integer = 0 To userRoleArrayList.Count - 1
                If i <> 0 Then
                    sqlString.Append(" OR ")
                End If
                sqlString.Append("rrs_role_id = @rrs_role_id" & i)
            Next

            sqlString.Append("                                          ) " & vbCrLf)
            sqlString.Append("                                          AND rrs_rights_type = @Fun )) " & vbCrLf)
            sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                 WHERE  ( ( " & vbCrLf)

            For i As Integer = 0 To userRoleArrayList.Count - 1
                If i <> 0 Then
                    sqlString.Append(" OR ")
                End If
                sqlString.Append("rrs_role_id = @rrs_role_id" & i)
            Next

            sqlString.Append("                                          ) " & vbCrLf)
            sqlString.Append("                                          AND rrs_rights_type = @Tsk )) " & vbCrLf)
            sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
            sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
            sqlString.Append("                                 WHERE  ( ( " & vbCrLf)

            For i As Integer = 0 To userRoleArrayList.Count - 1
                If i <> 0 Then
                    sqlString.Append(" OR ")
                End If
                sqlString.Append("rrs_role_id = @rrs_role_id" & i)
            Next

            sqlString.Append("                                          ) " & vbCrLf)
            sqlString.Append("                                            AND rrs_rights_type = @Sub )) ) " & vbCrLf)
            sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
            sqlString.Append("          sub_system_no, " & vbCrLf)
            sqlString.Append("          tsk_display_order, " & vbCrLf)
            sqlString.Append("          fun_task_no, " & vbCrLf)
            sqlString.Append("          fun_display_order, " & vbCrLf)
            sqlString.Append("          fun_function_no ")

            command.CommandText = sqlString.ToString
            For i As Integer = 0 To userRoleArrayList.Count - 1
                command.Parameters.AddWithValue("@rrs_role_id" & i, userRoleArrayList(i).ToString.Trim.PadRight(50, " "))
            Next
            command.Parameters.AddWithValue("@Flag_No", "Y")
            command.Parameters.AddWithValue("@Fun", "fun")
            command.Parameters.AddWithValue("@Tsk", "tsk")
            command.Parameters.AddWithValue("@Sub", "sub")
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("AppInfo")
                adapter.Fill(ds, "AppInfo")
                'adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
            End Using

            dtUserInfo.Columns.Add("user-id")
            dtUserInfo.Columns.Add("user-name")
            dtUserInfo.Columns.Add("user-birthday")
            dtUserInfo.Columns.Add("user-mail")
            dtUserInfo.Columns.Add("user-departmentnumber")
            dtUserInfo.Columns.Add("user-department")
            dtUserInfo.Columns.Add("user-acc-expired-date")
            dtUserInfo.Columns.Add("user-pwd-expired-date")
            dtUserInfo.Columns.Add("user-account-control")
            dtUserInfo.Columns.Add("user-locked")
            dtUserInfo.Columns.Add("user-activate")
            dtUserInfo.Columns.Add("user-WarningMessage")
            dtUserInfo.Columns.Add("user-ErrMessage")
            dtUserInfo.Columns.Add("user-memberof")
            dtUserInfo.Rows.Add()

            dtUserInfo.Rows(0).Item("user-id") = userid
            dtUserInfo.Rows(0).Item("user-name") = username
            dtUserInfo.Rows(0).Item("user-birthday") = userbirthday
            dtUserInfo.Rows(0).Item("user-mail") = usermail
            dtUserInfo.Rows(0).Item("user-departmentnumber") = userdepartmentnumber
            dtUserInfo.Rows(0).Item("user-department") = userdepartment
            dtUserInfo.Rows(0).Item("user-acc-expired-date") = useraccexpireddate
            dtUserInfo.Rows(0).Item("user-pwd-expired-date") = userpwdexpireddate
            dtUserInfo.Rows(0).Item("user-account-control") = useraccountcontrol
            dtUserInfo.Rows(0).Item("user-locked") = userlocked
            dtUserInfo.Rows(0).Item("user-activate") = useractivate
            dtUserInfo.Rows(0).Item("user-WarningMessage") = userWarningMessage
            dtUserInfo.Rows(0).Item("user-ErrMessage") = userErrMessage
            dtUserInfo.Rows(0).Item("user-memberof") = userMemberOf
            ds.Tables.Add(dtUserInfo)

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
    ''' 使用 AD 進行驗證
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoginForAD(ByVal id As String, ByVal password As String) As DataSet
        Try
            Dim entry As DirectoryServices.DirectoryEntry
            Dim path As System.Text.StringBuilder = New System.Text.StringBuilder
            path.Append(ConfigurationManager.AppSettings.Item("ADSPrePath")).Append(ConfigurationManager.AppSettings.Item("ADSUserPath"))

            If ConfigurationManager.AppSettings.Item("ADAuth").ToString.Trim = "N" Then
                entry = New DirectoryServices.DirectoryEntry(path.ToString)
            Else
                entry = New DirectoryServices.DirectoryEntry(path.ToString, id, password, AuthenticationTypes.Secure)

                '20090624 add by Rich (Bind to the native AdsObject to force authentication.) http://support.microsoft.com/kb/326340/
                Dim obj As Object = entry.NativeObject
                '該使用者: " & id & " 已通過驗證"
            End If

            Dim mySearcher As New System.DirectoryServices.DirectorySearcher(entry)

            '20090624 add by Rich (縮小搜尋範圍至兩個屬性)
            mySearcher.PropertiesToLoad.Add(ADEntry.ARM_USER_NAME)
            mySearcher.PropertiesToLoad.Add(ADEntry.ARM_USER_MEMBEROF)

            mySearcher.PageSize = 1
            mySearcher.ServerTimeLimit = New TimeSpan(0, 0, 30)
            mySearcher.ClientTimeout = New TimeSpan(0, 10, 0)

            mySearcher.Filter = "(&(anr=" & id & ")(objectCategory=person))"

            Dim user As SearchResult = mySearcher.FindOne
            Dim pub As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
            Dim dsTemp As DataSet = Nothing 'pub.queryDeptCodeByEmployeeCode(id)
            Dim deptCode As String = ""
            Dim deptName As String = ""
            Dim userName As String = ""
            If user.Properties(ADEntry.ARM_USER_NAME).Count > 0 Then
                userName = user.Properties(ADEntry.ARM_USER_NAME).Item(0).ToString.Trim
            Else
                userName = ""
            End If
            If dsTemp.Tables(0).Rows.Count <> 0 Then
                deptCode = dsTemp.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim()
                deptName = dsTemp.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim()
            End If

            Return Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 回傳個人資料、授權功能資料
    ''' </summary>
    ''' <param name="id">登入帳號</param>
    ''' <param name="password">登入密碼</param>
    ''' <param name="system_type_id">系統歸屬 O:門診 E:急診 I:住院</param>
    ''' <returns>回傳 DataSet 包含兩個DataTable (1)UserInfo(2)AppInfo</returns>
    ''' <remarks></remarks>
    Private Function LoginProcess(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As DataSet
        Dim userid As String = ""
        Dim username As String = ""
        Dim userbirthday As String = ""
        Dim usermail As String = ""
        Dim userdepartmentnumber As String = ""
        Dim userdepartment As String = ""
        Dim useraccexpireddate As String = ""
        Dim userpwdexpireddate As String = ""
        Dim useraccountcontrol As String = ""
        Dim userlocked As String = ""
        Dim useractivate As String = ""
        Dim userWarningMessage As String = ""
        Dim userErrMessage As String = ""
        Dim userMemberOf As String = ""
        Dim userNrsLevelId As String = ""
        Dim userRoleList As StringBuilder = New StringBuilder
        Dim userRoleArrayList As ArrayList = New ArrayList
        'ADD KMUH by doctor所屬科
        Dim userdrDeptCode As String = ""
        Dim userdrDeptName As String = ""


        Dim ds As New DataSet
        Dim dtUserInfo As New DataTable("UserInfo")

        Dim conn As System.Data.IDbConnection = getConnection()
        Try
            If UserAuthenticate(id, password, conn) Then 'User 認證(Table)

                '使用DB中的資料
                Dim pub As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
                Dim empDS As DataSet = pub.queryByPK(id, conn)

                userid = id
                If empDS.Tables(0).Rows.Count > 0 Then
                    username = empDS.Tables(0).Rows(0).Item("Employee_Name").ToString.Trim
                    If empDS.Tables(0).Columns.Contains("Nrs_Level_Id") Then
                        userNrsLevelId = empDS.Tables(0).Rows(0).Item("Nrs_Level_Id").ToString.Trim
                    End If
                End If

                '取得密碼修改時間
                Select Case HospConfigUtil.HospConfig
                    Case HospConfigUtil.hospConfigList.Tw_Kmuh
                        Dim usrBO As New UserBO
                        Dim dsPwd As DataSet = usrBO.QueryUserPassword(id, conn)
                        If dsPwd.Tables(0).Rows.Count > 0 Then
                            userpwdexpireddate = CDate(dsPwd.Tables(0).Rows(0).Item("Modified_Date")).ToString("yyyy/MM/dd")
                        End If
                End Select

                '2014-09-01 Sean 統一取得Employee Method
                Dim dsTemp As DataSet = pub.queryEmployeeByEmpCodeAndDate(id, Now.Date, conn)
                If dsTemp.Tables(0).Rows.Count > 0 Then
                    userdepartmentnumber = dsTemp.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim
                    userdepartment = dsTemp.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim
                    userdrDeptCode = dsTemp.Tables(0).Rows(0).Item("dr_Dept_Code").ToString.Trim
                    userdrDeptName = dsTemp.Tables(0).Rows(0).Item("dr_Dept_Name").ToString.Trim
                End If

                ' 取得角色清單(GetRoleList)
                Dim retDs As DataSet = Nothing
                retDs = getRoleList(id.Trim, conn)

                If retDs.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In retDs.Tables(0).Rows
                        userRoleList.Append("'").Append(row.Item("Role").ToString.Trim).Append("',")
                        userRoleArrayList.Add(row.Item("Role").ToString.Trim)
                    Next
                End If

                '填入角色歸屬
                userMemberOf = userRoleList.ToString

                If userRoleList.Length > 0 Then

                    Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                    Dim command As SqlCommand = sqlConn.CreateCommand()
                    Dim sqlString As New System.Text.StringBuilder
                    sqlString.Append("SELECT fun_function_no, " & vbCrLf)
                    sqlString.Append("       fun_function_name, " & vbCrLf)
                    sqlString.Append("       fun_display_order, " & vbCrLf)
                    sqlString.Append("       fun_content, " & vbCrLf)
                    sqlString.Append("       sub_system_no, " & vbCrLf)
                    sqlString.Append("       sub_system_name, " & vbCrLf)
                    sqlString.Append("       sub_display_order, " & vbCrLf)
                    sqlString.Append("       fun_task_no, " & vbCrLf)
                    sqlString.Append("       tsk_task_name, " & vbCrLf)
                    sqlString.Append("       tsk_display_order, " & vbCrLf)
                    sqlString.Append("       app_system_no " & vbCrLf)
                    sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
                    sqlString.Append("       arm_tsk_system, " & vbCrLf)
                    sqlString.Append("       arm_sub_system, " & vbCrLf)
                    sqlString.Append("       arm_app_system " & vbCrLf)
                    sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
                    sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Fun ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Tsk ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                   WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                          ) AND rrs_rights_type = @Sub ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) ) " & vbCrLf)
                    sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
                    sqlString.Append("          sub_system_no, " & vbCrLf)
                    sqlString.Append("          tsk_display_order, " & vbCrLf)
                    sqlString.Append("          fun_task_no, " & vbCrLf)
                    sqlString.Append("          fun_display_order, " & vbCrLf)
                    sqlString.Append("          fun_function_no ")

                    command.CommandText = sqlString.ToString

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        command.Parameters.AddWithValue("@rrs_role_id" & i, userRoleArrayList.Item(i).ToString.Trim.PadRight(50, " "))
                    Next
                    command.Parameters.AddWithValue("@Flag_No", "Y")
                    command.Parameters.AddWithValue("@Fun", "fun")
                    command.Parameters.AddWithValue("@Tsk", "tsk")
                    command.Parameters.AddWithValue("@Sub", "sub")
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(ds, "AppInfo")
                        adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
                    End Using
                Else
                    '無歸屬任何角色
                    Dim dtTemp As New DataTable("AppInfo")
                    ds.Tables.Add(dtTemp)
                End If
            Else
                userErrMessage = "密碼有誤"

                '填入角色歸屬
                userMemberOf = userRoleList.ToString

                If userRoleList.Length <> 0 Then

                    Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                    Dim command As SqlCommand = sqlConn.CreateCommand()
                    Dim sqlString As New System.Text.StringBuilder
                    sqlString.Append("SELECT fun_function_no, " & vbCrLf)
                    sqlString.Append("       fun_function_name, " & vbCrLf)
                    sqlString.Append("       fun_display_order, " & vbCrLf)
                    sqlString.Append("       fun_content, " & vbCrLf)
                    sqlString.Append("       sub_system_no, " & vbCrLf)
                    sqlString.Append("       sub_system_name, " & vbCrLf)
                    sqlString.Append("       sub_display_order, " & vbCrLf)
                    sqlString.Append("       fun_task_no, " & vbCrLf)
                    sqlString.Append("       tsk_task_name, " & vbCrLf)
                    sqlString.Append("       tsk_display_order, " & vbCrLf)
                    sqlString.Append("       app_system_no " & vbCrLf)
                    sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
                    sqlString.Append("       arm_tsk_system, " & vbCrLf)
                    sqlString.Append("       arm_sub_system, " & vbCrLf)
                    sqlString.Append("       arm_app_system " & vbCrLf)
                    sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
                    sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Fun ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Tsk ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                   WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                          ) AND rrs_rights_type = @Sub ")

                    If system_type_id <> "" Then
                        Select Case system_type_id
                            Case "O"
                                sqlString.Append(" AND opd_flag = 'Y' ")
                            Case "E"
                                sqlString.Append(" AND eis_flag = 'Y' ")
                            Case "I"
                                sqlString.Append(" AND pcs_flag = 'Y' ")
                        End Select
                    End If

                    sqlString.Append("                                                                     )) ) " & vbCrLf)
                    sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
                    sqlString.Append("          sub_system_no, " & vbCrLf)
                    sqlString.Append("          tsk_display_order, " & vbCrLf)
                    sqlString.Append("          fun_task_no, " & vbCrLf)
                    sqlString.Append("          fun_display_order, " & vbCrLf)
                    sqlString.Append("          fun_function_no ")

                    command.CommandText = sqlString.ToString
                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        command.Parameters.AddWithValue("@rrs_role_id" & i, userRoleArrayList.Item(i).ToString.Trim.PadRight(50, " "))
                    Next
                    command.Parameters.AddWithValue("@Flag_No", "Y")
                    command.Parameters.AddWithValue("@Fun", "fun")
                    command.Parameters.AddWithValue("@Tsk", "tsk")
                    command.Parameters.AddWithValue("@Sub", "sub")
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(ds, "AppInfo")
                        adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
                    End Using
                Else
                    '無歸屬任何角色
                    Dim dtTemp As New DataTable("AppInfo")
                    ds.Tables.Add(dtTemp)
                End If
            End If

            dtUserInfo.Columns.Add("user-id")
            dtUserInfo.Columns.Add("user-name")
            dtUserInfo.Columns.Add("user-birthday")
            dtUserInfo.Columns.Add("user-mail")
            dtUserInfo.Columns.Add("user-departmentnumber")
            dtUserInfo.Columns.Add("user-department")
            dtUserInfo.Columns.Add("user-acc-expired-date")
            dtUserInfo.Columns.Add("user-pwd-expired-date")
            dtUserInfo.Columns.Add("user-account-control")
            dtUserInfo.Columns.Add("user-locked")
            dtUserInfo.Columns.Add("user-activate")
            dtUserInfo.Columns.Add("user-WarningMessage")
            dtUserInfo.Columns.Add("user-ErrMessage")
            dtUserInfo.Columns.Add("user-memberof")
            dtUserInfo.Columns.Add("user-nrs-level-id")
            dtUserInfo.Columns.Add("user-dr-Dept-Code")
            dtUserInfo.Columns.Add("user-dr-Dept-Name")
            dtUserInfo.Rows.Add()

            dtUserInfo.Rows(0).Item("user-id") = userid
            dtUserInfo.Rows(0).Item("user-name") = username
            dtUserInfo.Rows(0).Item("user-birthday") = userbirthday
            dtUserInfo.Rows(0).Item("user-mail") = usermail
            dtUserInfo.Rows(0).Item("user-departmentnumber") = userdepartmentnumber
            dtUserInfo.Rows(0).Item("user-department") = userdepartment
            dtUserInfo.Rows(0).Item("user-acc-expired-date") = useraccexpireddate
            dtUserInfo.Rows(0).Item("user-pwd-expired-date") = userpwdexpireddate
            dtUserInfo.Rows(0).Item("user-account-control") = useraccountcontrol
            dtUserInfo.Rows(0).Item("user-locked") = userlocked
            dtUserInfo.Rows(0).Item("user-activate") = useractivate
            dtUserInfo.Rows(0).Item("user-WarningMessage") = userWarningMessage
            dtUserInfo.Rows(0).Item("user-ErrMessage") = userErrMessage
            dtUserInfo.Rows(0).Item("user-memberof") = userMemberOf
            dtUserInfo.Rows(0).Item("user-nrs-level-id") = userNrsLevelId
            dtUserInfo.Rows(0).Item("user-dr-Dept-Code") = userdrDeptCode
            dtUserInfo.Rows(0).Item("user-dr-Dept-Name") = userdrDeptName
            ds.Tables.Add(dtUserInfo)

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("ARMCMME001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 根據醫師碼取得employee_code
    ''' </summary>
    ''' <param name="drCode">醫師碼</param>
    ''' <param name="conn">連線</param>
    ''' <returns>回傳 DataSet 包含兩個DataTable (1)UserInfo(2)AppInfo</returns>
    ''' <remarks></remarks>
    Private Function GetEmployeeCodeByDrCode(ByVal drCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim sqlString As New StringBuilder
        Dim ds As New DataSet
        Try


            sqlString.Append("Select Employee_Code      " & vbCrLf)
            sqlString.Append("  From Pub_Doctor" & vbCrLf)
            sqlString.Append(" Where 1=1" & vbCrLf)
            sqlString.Append("   And Doctor_Code=@Doctor_Code " & vbCrLf)
            Using Command As SqlCommand = conn.CreateCommand
                Command.CommandText = sqlString.ToString
                Command.Parameters.Add("@Doctor_Code", SqlDbType.Char).Value = drCode
                Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                    adapter.Fill(ds, "EmployeeCode")
                End Using
            End Using
            If CheckMethodUtil.CheckHasTable(ds) AndAlso CheckMethodUtil.CheckHasValue(ds.Tables("EmployeeCode")) Then
                Return ds.Tables("EmployeeCode").Rows(0).Item("Employee_Code").ToString.Trim
            Else
                Return ""
            End If
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("ARMCMME001", ex)
        End Try
    End Function
#End Region

#Region " 使用者Table密碼認證"

    ''' <summary>
    ''' 使用者Table密碼認證
    ''' </summary>
    ''' <param name="employee_code"></param>
    ''' <param name="pwd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UserAuthenticate(ByVal employee_code As String, ByVal pwd As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Boolean
        If conn Is Nothing Then
            conn = getConnection()
        End If
        'Dim sqlarm As String = "select * from Arm_Password where Employee_Code=@Employee_Code and Password=@Password "
        Dim _nowDate As String = Now.ToString("yyyyMMdd")
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Append("select A.employee_code from Arm_Password A " & vbCrLf)
        sqlString.Append("	left Join  PUB_Employee B ON  A.employee_code=B.Employee_Code " & vbCrLf)
        sqlString.Append("	and convert(varchar,B.Assume_End_Date,112) >=@_nowDate " & vbCrLf)
        sqlString.Append(" where  A.Employee_Code=@Employee_Code and A.Password=@Password ")



        Dim tableName As String = "userPwd"
        Dim TmpDs As DataSet
        Dim armConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
        Dim armcommand As SqlCommand = armConn.CreateCommand()
        armcommand.CommandText = sqlString.ToString
        armcommand.Parameters.AddWithValue("@_nowDate", _nowDate)
        armcommand.Parameters.AddWithValue("@Employee_Code", employee_code.Trim)
        armcommand.Parameters.AddWithValue("@Password", PassWordUtil.Encrypt(pwd.Trim, PassWordUtil.getPrimaryKey))
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(armcommand)
                TmpDs = New DataSet(tableName)
                adapter.Fill(TmpDs, tableName)
            End Using
            If TmpDs.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            armConn.Close()
        End Try

    End Function

#End Region

#Region " 回傳個人資料、授權功能資料，根據ID、PassWord、Section_ID"

    ''' <summary>
    ''' 回傳個人資料、授權功能資料，根據ID、PassWord、Section_ID
    ''' </summary>
    ''' <param name="id">登入帳號</param>
    ''' <param name="password">登入密碼</param>
    ''' <param name="SectionCode">使用者院區代碼</param>
    ''' <returns>回傳 DataSet 包含兩個DataTable (1)UserInfo(2)AppInfo</returns>
    ''' <remarks></remarks>
    Public Function LoginBySectionCode(ByVal id As String, ByVal password As String, ByVal SectionCode As String) As DataSet
        Dim userid As String = ""
        Dim username As String = ""
        Dim userbirthday As String = ""
        Dim usermail As String = ""
        Dim userdepartmentnumber As String = ""
        Dim userdepartment As String = ""
        Dim useraccexpireddate As String = ""
        Dim userpwdexpireddate As String = ""
        Dim useraccountcontrol As String = ""
        Dim userlocked As String = ""
        Dim useractivate As String = ""
        Dim userErrMessage As String = ""
        Dim userWarningMessage As String = ""
        Dim userRoleList As StringBuilder = New StringBuilder
        Dim userRoleArrayList As ArrayList = New ArrayList

        Dim ds As New DataSet("LoginInfo")

        Dim MyTable As New DataTable("UserInfo")
        MyTable.Columns.Add("user-id")
        MyTable.Columns.Add("user-name")
        MyTable.Columns.Add("user-birthday")
        MyTable.Columns.Add("user-mail")
        MyTable.Columns.Add("user-departmentnumber")
        MyTable.Columns.Add("user-department")
        MyTable.Columns.Add("user-acc-expired-date")
        MyTable.Columns.Add("user-pwd-expired-date")
        MyTable.Columns.Add("user-account-control")
        MyTable.Columns.Add("user-locked")
        MyTable.Columns.Add("user-activate")
        MyTable.Columns.Add("user-WarningMessage")
        MyTable.Columns.Add("user-ErrMessage")
        MyTable.Columns.Add("user-memberof")

        MyTable.Rows.Add()
        'LOGDelegate.getInstance.fileDebugMsg("========進入登入驗證程式︰" & Now.ToString("yyyy-MM-dd hh:mm:ss") & "==========")



        LOGDelegate.getInstance.dbInfoMsg("登入者: " & id & "  登入時間: " & Now.ToString)
        Dim conn As System.Data.IDbConnection = getConnection()
        Try

            '取得驗證結果
            Dim PassWordVerify As String = UserAuthenticateBySectionCode(id, password, SectionCode)

            '為空表示認證成功，密碼與院區正確
            If PassWordVerify = "" Then 'User 認證(Table)

                MyTable.Rows(0).Item("user-id") = userid
                MyTable.Rows(0).Item("user-name") = username
                MyTable.Rows(0).Item("user-birthday") = userbirthday
                MyTable.Rows(0).Item("user-mail") = usermail
                MyTable.Rows(0).Item("user-departmentnumber") = userdepartmentnumber
                MyTable.Rows(0).Item("user-department") = userdepartment
                MyTable.Rows(0).Item("user-acc-expired-date") = useraccexpireddate
                MyTable.Rows(0).Item("user-pwd-expired-date") = userpwdexpireddate
                MyTable.Rows(0).Item("user-account-control") = useraccountcontrol
                MyTable.Rows(0).Item("user-locked") = userlocked
                MyTable.Rows(0).Item("user-activate") = useractivate
                MyTable.Rows(0).Item("user-WarningMessage") = userWarningMessage
                MyTable.Rows(0).Item("user-ErrMessage") = userErrMessage


                '使用DB中的資料
                Dim pub As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance

                '2014-09-01 Sean 統一取得Employee Method
                'Dim dsTemp As DataSet = pub.queryDeptCodeByEmployeeCode(id)
                Dim dsTemp As DataSet = pub.queryEmployeeByEmpCodeAndDate(id, Now.Date)

                If dsTemp.Tables(0).Rows.Count <> 0 Then
                    MyTable.Rows(0).Item("user-departmentnumber") = dsTemp.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim
                    MyTable.Rows(0).Item("user-department") = dsTemp.Tables(0).Rows(0).Item("Dept_Name").ToString.Trim
                End If

                ' 取得角色清單(GetRoleList)
                Dim retDs As DataSet = Nothing
                retDs = getRoleList(id.Trim)

                If retDs.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In retDs.Tables(0).Rows
                        userRoleList.Append("'").Append(row.Item("Role").ToString.Trim).Append("',")
                        userRoleArrayList.Add(row.Item("Role").ToString.Trim)
                    Next
                End If


                '填入角色歸屬
                MyTable.Rows(0).Item("user-memberof") = userRoleList.ToString
                ds.Tables.Add(MyTable)



                If userRoleList.Length <> 0 Then

                    Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                    Dim command As SqlCommand = sqlConn.CreateCommand()
                    Dim sqlString As New System.Text.StringBuilder
                    sqlString.Append("SELECT fun_function_no, " & vbCrLf)
                    sqlString.Append("       fun_function_name, " & vbCrLf)
                    sqlString.Append("       fun_display_order, " & vbCrLf)
                    sqlString.Append("       fun_content, " & vbCrLf)
                    sqlString.Append("       sub_system_no, " & vbCrLf)
                    sqlString.Append("       sub_system_name, " & vbCrLf)
                    sqlString.Append("       sub_display_order, " & vbCrLf)
                    sqlString.Append("       fun_task_no, " & vbCrLf)
                    sqlString.Append("       tsk_task_name, " & vbCrLf)
                    sqlString.Append("       tsk_display_order, " & vbCrLf)
                    sqlString.Append("       app_system_no " & vbCrLf)
                    sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
                    sqlString.Append("       arm_tsk_system, " & vbCrLf)
                    sqlString.Append("       arm_sub_system, " & vbCrLf)
                    sqlString.Append("       arm_app_system " & vbCrLf)
                    sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
                    sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Fun ")

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Tsk ")


                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                   WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                          ) AND rrs_rights_type = @Sub ")



                    sqlString.Append("                                                                     )) ) " & vbCrLf)
                    sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
                    sqlString.Append("          sub_system_no, " & vbCrLf)
                    sqlString.Append("          tsk_display_order, " & vbCrLf)
                    sqlString.Append("          fun_task_no, " & vbCrLf)
                    sqlString.Append("          fun_display_order, " & vbCrLf)
                    sqlString.Append("          fun_function_no ")

                    command.CommandText = sqlString.ToString

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        command.Parameters.AddWithValue("@rrs_role_id" & i, userRoleArrayList.Item(i).ToString.Trim.PadRight(50, " "))
                    Next
                    command.Parameters.AddWithValue("@Flag_No", "Y")
                    command.Parameters.AddWithValue("@Fun", "fun")
                    command.Parameters.AddWithValue("@Tsk", "tsk")
                    command.Parameters.AddWithValue("@Sub", "sub")
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(ds, "AppInfo")
                        adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
                    End Using
                    Return ds
                Else
                    '無歸屬任何角色
                    Dim dtTemp As New DataTable("AppInfo")
                    ds.Tables.Add(dtTemp)
                    Return ds
                End If
            Else

                '設定要顯示的驗證訊息(密碼錯誤 or 院區錯誤)
                MyTable.Rows(0).Item("user-ErrMessage") = PassWordVerify

                '填入角色歸屬
                MyTable.Rows(0).Item("user-memberof") = userRoleList.ToString
                ds.Tables.Add(MyTable)

                If userRoleList.Length <> 0 Then

                    Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                    Dim command As SqlCommand = sqlConn.CreateCommand()
                    Dim sqlString As New System.Text.StringBuilder
                    sqlString.Append("SELECT fun_function_no, " & vbCrLf)
                    sqlString.Append("       fun_function_name, " & vbCrLf)
                    sqlString.Append("       fun_display_order, " & vbCrLf)
                    sqlString.Append("       fun_content, " & vbCrLf)
                    sqlString.Append("       sub_system_no, " & vbCrLf)
                    sqlString.Append("       sub_system_name, " & vbCrLf)
                    sqlString.Append("       sub_display_order, " & vbCrLf)
                    sqlString.Append("       fun_task_no, " & vbCrLf)
                    sqlString.Append("       tsk_task_name, " & vbCrLf)
                    sqlString.Append("       tsk_display_order, " & vbCrLf)
                    sqlString.Append("       app_system_no " & vbCrLf)
                    sqlString.Append("FROM   arm_fun_system, " & vbCrLf)
                    sqlString.Append("       arm_tsk_system, " & vbCrLf)
                    sqlString.Append("       arm_sub_system, " & vbCrLf)
                    sqlString.Append("       arm_app_system " & vbCrLf)
                    sqlString.Append("WHERE  ( app_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND sub_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND tsk_task_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND fun_flag_no = @Flag_No " & vbCrLf)
                    sqlString.Append("         AND app_system_no = sub_app_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_sub_system.sub_system_no = tsk_sub_system_no " & vbCrLf)
                    sqlString.Append("         AND arm_tsk_system.tsk_task_no = fun_task_no ) " & vbCrLf)
                    sqlString.Append("       AND ( fun_function_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Fun ")

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR fun_task_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                 FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                 WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                        ) AND rrs_rights_type = @Tsk ")

                    sqlString.Append("                                                                     )) " & vbCrLf)
                    sqlString.Append("              OR sub_system_no IN (SELECT rrs_rights_id " & vbCrLf)
                    sqlString.Append("                                   FROM   arm_rolerights " & vbCrLf)
                    sqlString.Append("                                   WHERE  ( ( ")

                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        If i <> 0 Then
                            sqlString.Append(" OR ")
                        End If
                        sqlString.Append("rrs_role_id = @rrs_role_id" & i)
                    Next

                    sqlString.Append("                                          ) AND rrs_rights_type = @Sub ")

                    sqlString.Append("                                                                     )) ) " & vbCrLf)
                    sqlString.Append("ORDER  BY sub_display_order, " & vbCrLf)
                    sqlString.Append("          sub_system_no, " & vbCrLf)
                    sqlString.Append("          tsk_display_order, " & vbCrLf)
                    sqlString.Append("          fun_task_no, " & vbCrLf)
                    sqlString.Append("          fun_display_order, " & vbCrLf)
                    sqlString.Append("          fun_function_no ")

                    command.CommandText = sqlString.ToString
                    For i As Integer = 0 To userRoleArrayList.Count - 1
                        command.Parameters.AddWithValue("@rrs_role_id" & i, userRoleArrayList.Item(i).ToString.Trim.PadRight(50, " "))
                    Next
                    command.Parameters.AddWithValue("@Flag_No", "Y")
                    command.Parameters.AddWithValue("@Fun", "fun")
                    command.Parameters.AddWithValue("@Tsk", "tsk")
                    command.Parameters.AddWithValue("@Sub", "sub")
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(ds, "AppInfo")
                        adapter.FillSchema(ds, SchemaType.Mapped, "AppInfo")
                    End Using

                    LOGDelegate.getInstance.dbInfoMsg("登入者: " & id & "  登入成功: " & Now.ToString)
                    Return ds
                Else
                    '無歸屬任何角色
                    Dim dtTemp As New DataTable("AppInfo")
                    ds.Tables.Add(dtTemp)

                    LOGDelegate.getInstance.fileDebugMsg("該使用者無歸屬任何角色，即給予初始角色︰" & Now.ToString("yyyy-MM-dd hh:mm:ss"))
                    LOGDelegate.getInstance.fileDebugMsg("========結束登入驗證程式︰" & Now.ToString("yyyy-MM-dd hh:mm:ss") & "==========")

                    Return ds
                End If
            End If
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("ARMCMME001", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

#End Region

#Region " 使用者Table密碼認證，根據ID、PassWord、Section_ID，正確回傳空字串"

    ''' <summary>
    ''' 使用者Table密碼認證，根據ID、PassWord、Section_ID，正確回傳空字串
    ''' </summary>
    ''' <param name="employee_code"></param>
    ''' <param name="pwd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UserAuthenticateBySectionCode(ByVal employee_code As String, ByVal pwd As String, ByVal SectionCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            Dim resultStr As String = ""

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim tableName As String = "userPwd"

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT AP.* " & vbCrLf)
            sqlString.Append("FROM   Arm_Password AP " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Employee PE " & vbCrLf)
            sqlString.Append("         ON PE.Employee_Code = AP.Employee_Code " & vbCrLf)
            sqlString.Append("WHERE  AP.Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("       AND AP.Password = @Password " & vbCrLf)

            command.CommandText = sqlString.ToString

            command.Parameters.AddWithValue("@Employee_Code", employee_code)
            command.Parameters.AddWithValue("@Password", PassWordUtil.Encrypt(pwd.Trim, PassWordUtil.getPrimaryKey))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            '密碼對了要驗證院區
            If ds.Tables(0).Rows.Count > 0 Then

                sqlString = New StringBuilder
                sqlString.Append("SELECT AP.* " & vbCrLf)
                sqlString.Append("FROM   Arm_Password AP " & vbCrLf)
                sqlString.Append("       INNER JOIN PUB_Employee PE " & vbCrLf)
                sqlString.Append("         ON PE.Employee_Code = AP.Employee_Code " & vbCrLf)
                sqlString.Append("WHERE  AP.Employee_Code = @Employee_Code " & vbCrLf)
                sqlString.Append("       AND AP.Password = @Password " & vbCrLf)
                sqlString.Append("       AND SECTION_Code = @SECTION_Code ")

                command = sqlConn.CreateCommand()
                command.CommandText = sqlString.ToString

                command.Parameters.AddWithValue("@Employee_Code", employee_code)
                command.Parameters.AddWithValue("@Password", PassWordUtil.Encrypt(pwd.Trim, PassWordUtil.getPrimaryKey))
                command.Parameters.AddWithValue("@SECTION_Code", SectionCode)

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName)
                    adapter.Fill(ds, tableName)
                End Using

                If ds.Tables(0).Rows.Count > 0 Then
                    resultStr = ""
                Else
                    '院區不正確 
                    resultStr = "院区不正确"
                End If


            Else
                '密碼不正確 
                resultStr = "密码不正确"

            End If


            Return resultStr



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

#Region " 取得User 所屬Role"

    ''' <summary>
    ''' 取得User 所屬Role
    ''' </summary>
    ''' <param name="employee_code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getRoleList(ByVal employee_code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim userRoleList As StringBuilder = New StringBuilder
        Dim userRoleArrayList As ArrayList = New ArrayList
        If conn Is Nothing Then
            conn = getConnection()
        End If

        Dim sqlarm As String = "select role from Arm_Roles where Employee_Code=@Employee_Code"
        Dim tableName As String = "Roles"
        Dim TmpDs As DataSet
        Dim armConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
        Dim armcommand As SqlCommand = armConn.CreateCommand()
        armcommand.CommandText = sqlarm
        armcommand.Parameters.AddWithValue("@Employee_Code", employee_code.Trim)
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(armcommand)
                TmpDs = New DataSet(tableName)
                adapter.Fill(TmpDs, tableName)
            End Using
            Return TmpDs
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            armConn.Close()
        End Try
    End Function

#End Region

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function

End Class