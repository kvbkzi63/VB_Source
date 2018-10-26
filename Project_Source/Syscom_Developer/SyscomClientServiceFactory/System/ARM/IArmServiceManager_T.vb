Public Interface IArmServiceManager_T

#Region "授權與認證 (LoginModuleBO)"

    Function Login(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As DataSet
    Function LoginForSys(ByVal role As String) As DataTable
    Function LoginForAgent(ByVal loginUserId As String, ByVal userRoleArrayList() As String) As DataSet
    Function LoginModuleLoginBySectionCode(ByVal id As String, ByVal password As String, ByVal SectionCode As String) As DataSet

#End Region

#Region "系統相關操作 (SystemBS)"

    Function queryForRoleRightsMaintain(ByVal RoleID As String) As DataSet
    Sub ConfirmRoleRights(ByVal ds As DataSet)

#End Region

#Region "使用者相關操作 (UserBS)"

    Function ArmForUser(ByVal id As String, ByVal password As String) As DataSet

#End Region

#Region "使用者相關操作 (UserBO)"

    Sub AddUser(ByVal ds As DataSet)
    Sub ModifyUser(ByVal ds As DataSet)
    Sub DeleteUser(ByVal ds As DataSet)
    Function QueryUser(ByVal ds As DataSet) As DataSet
    Function ChangePassword(ByVal ds As DataSet) As Integer
    Function ResetPassword(ByVal ds As DataSet) As Integer

#End Region

#Region "角色相關操作 (RoleBO)"

    Function AddRole(ByVal ds As DataSet) As Integer
    Function ModifyRole(ByVal ds As DataSet) As Integer
    Function DeleteRole(ByVal ds As DataSet) As Integer
    Function QueryRole(ByVal roleID As String, ByVal roleName As String, ByVal isValid As String) As DataSet
    Function RoleBelongQuery(ByVal ds As DataSet) As DataSet
    Function RoleBelongUpdate(ByVal dsParam As DataSet, ByVal dsRoleInfo As DataSet) As Integer

#End Region

#Region "系統操作 (ArmAppSystemBO_E1)"

    Function AppGetAppSystem(ByVal app_system_no As String, ByVal app_system_name As String, ByVal app_display_order As String, ByVal app_flag_no As String) As DataSet
    Function AppQueryByPK(ByRef pk_app_system_no As String) As DataSet
    Function AppInsert(ByVal ds As DataSet) As Integer
    Function AppDelete(ByRef pk_app_system_no As String) As Integer
    Function AppUpdate(ByVal ds As DataSet) As Integer
    Function AppGetAppSystemCombobox() As DataSet

#End Region

#Region "子系統操作 (ArmSubSystemBO_E1)"

    Function SubGetSubSystem(ByVal sub_system_no As String, ByVal sub_system_name As String, ByVal sub_app_system_no As String, ByVal sub_display_order As String, ByVal sub_flag_no As String) As DataSet
    Function SubQueryByPK(ByRef pk_sub_system_no As String) As DataSet
    Function SubInsert(ByVal ds As DataSet) As Integer
    Function SubDelete(ByRef pk_sub_system_no As String) As Integer
    Function SubUpdate(ByVal ds As DataSet) As Integer
    Function SubGetSubSystemCombobox(ByVal sub_app_system_no As String) As DataSet

#End Region

#Region "作業操作 (ArmTskSystemBO_E1)"

    Function TskGetAllSystem(ByVal app_system_no As String, ByVal tsk_sub_system_no As String, ByVal tsk_task_no As String, ByVal tsk_task_name As String, ByVal tsk_display_order As String, ByVal tsk_task_flag_no As String) As DataSet
    Function TskQueryByPK(ByRef pk_tsk_task_no As String) As DataSet
    Function TskInsert(ByVal ds As DataSet) As Integer
    Function TskDelete(ByRef pk_tsk_task_no As String) As Integer
    Function TskUpdate(ByVal ds As DataSet) As Integer
    Function TskGetTskSystemCombobox(ByVal tsk_sub_system_no As String) As DataSet

#End Region

#Region "功能操作 (ArmFunSystemBO_E1)"

    Function FunGetAllSystem(ByVal app_system_no As String, ByVal sub_system_no As String, ByVal fun_task_no As String, ByVal fun_function_no As String, ByVal fun_function_name As String, ByVal fun_content As String, ByVal fun_special_flag As String, ByVal fun_display_order As String, ByVal fun_flag_no As String) As DataSet
    Function FunQueryByPK(ByRef pk_fun_function_no As String) As DataSet
    Function FunQueryByLogin() As DataSet
    Function FunInsert(ByVal ds As DataSet) As Integer
    Function FunUpdate(ByVal ds As DataSet) As Integer
    Function FunDelete(ByRef pk_fun_function_no As String) As Integer

#End Region

#Region "使用者登入資訊(by Lits on 2010-07-03)"

    Function insertLogonDate(ByVal ip As String, ByVal employeeCode As String) As Int32
    Function updateLogoutDate(ByVal ip As String, ByVal employeeCode As String) As Int32
    Function queryIP() As DataSet
    Function insertLogonDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32
    Function updateLogoutDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32
    Function queryIPBySystem(ByVal systemNo As String) As DataSet
    Function queryEmployeeRoleData(ByVal role As String, ByVal employeeCode As String) As DataSet
    Function getPassword(ByVal user As String) As String
    Function saveLogonFailure(ByVal employeeCode As String, ByVal ip As String, ByVal machineName As String) As Integer
#End Region

#Region "2012-09-28 個人化設定-我的最愛"

    Function insertProfile(ByVal ds As DataSet) As String
    Function deleteProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As Integer
    Function queryProfileByPk(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As DataSet
    Function queryProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByVal flag As String = "") As DataSet
    Function updateProfileDefault(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File As String, Optional ByVal flag As String = "Y") As Integer

#End Region

#Region "多面向查詢功能"

    ''' <summary>
    ''' 查詢人員的角色與功能
    ''' </summary>
    ''' <param name="Employee_Code" >員工代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Function RoleQueryByEmployee(ByVal Employee_Code As String) As DataSet

    ''' <summary>
    ''' 查詢角色歸屬的人員
    ''' </summary>
    ''' <param name="Role_Id" >角色代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Function EmployeeQueryByRole(ByVal Role_Id As String) As DataSet

    ''' <summary>
    ''' 查詢功能歸屬的人員
    ''' </summary>
    ''' <param name="Fun_Function_No" >功能代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Function EmployeeQueryByFunction(ByVal Fun_Function_No As String) As DataSet

#End Region

#Region "紀錄/查詢使用者執行過的作業"
    Function insertFunRecord(ByVal ds As DataSet) As Int32
#End Region

#Region "授權代理操作 (ArmAgentAuthorizationBO_E1)"

    Function insertArmAgentAuth(ByVal ds As DataSet) As Integer

    Function deleteArmAgentAuth(ByVal employeeCode As String, ByVal agentCode As String, ByVal roleId As String, ByVal effectDate As String) As Integer

    Function queryByAgentEmployeeCode(ByRef pk_employee_code As System.String, ByRef pk_agent_code As System.String, ByVal role_id As String, ByVal effect_date As String, ByVal end_date As String) As System.Data.DataSet

#End Region

#Region "點擊次數統計 (ArmRecordBO_E1)"

    Function queryArmRecord(ByVal employeeCode As String, ByVal functionNo As String, ByVal startDate As String, ByVal endDate As String) As System.Data.DataSet

#End Region

#Region "單檔維護控制權限 (ArmRoleRightsBO_E1)"

    ''' <summary>
    ''' 查詢角色ID 以 userMemberOf 為索引
    ''' </summary>
    ''' <param name="userMemberOf">使用者歸屬角色</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryRoleRightsByMemberOf(ByVal userMemberOf As String) As DataSet

#End Region

#Region "    登入失敗超過3次UI (ArmLogonFailureBO_E1) "

#Region "2016/02/18 登入失敗超過3次查詢(Arm_Logon_Failure) by Hsiao,Kaiwen"

    ''' <summary>
    ''' 登入失敗超過3次查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Function ArmLogonFailureQueryLoginFailure(ByVal str_StartDay As String, ByVal str_EndDay As String) As System.Data.DataSet


#End Region


#End Region

End Interface