Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class ARMDelegate

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As ARMDelegate
        Try
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return New ARMDelegate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "授權與認證 (LoginModuleBO)"

    ''' <summary>
    ''' 對使用者進行認證動作
    ''' </summary>
    ''' <param name="id">使用者帳號</param>
    ''' <param name="password">使用者密碼</param>
    ''' <returns>測試階段，目前回傳空字串等於通過，若不為空字串則為錯誤訊息</returns>
    ''' <remarks></remarks>
    Public Function Login(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As DataSet
        Try
            Dim instance As LoginModuleBO = New LoginModuleBO
            Return instance.Login(id, password, system_type_id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 對使用者進行認證
    ''' </summary>
    ''' <param name="role"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoginForSys(ByVal role As String) As DataTable
        Try
            Dim instance As LoginModuleBO = New LoginModuleBO
            Return instance.LoginForSys(role)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 對使用者進行認證
    ''' </summary>
    ''' <param name="userRoleArrayList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoginForAgent(ByVal loginUserId As String, ByVal userRoleArrayList() As String) As DataSet
        Try
            Dim instance As LoginModuleBO = New LoginModuleBO
            Return instance.LoginForAgent(loginUserId, userRoleArrayList)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 回傳個人資料、授權功能資料，根據ID、PassWord、Section_ID
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function LoginModuleLoginBySectionCode(ByVal id As String, ByVal password As String, ByVal SectionCode As String) As DataSet

        Dim m_LoginModule As LoginModuleBO = New LoginModuleBO
        Try

            Return m_LoginModule.LoginBySectionCode(id, password, SectionCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "系統相關操作 (SystemBS)"

    ''' <summary>
    ''' 取得角色功能設定維護畫面的資料
    ''' </summary>
    ''' <param name="RoleID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryForRoleRightsMaintain(ByVal RoleID As String) As DataSet
        Try
            Dim instance As RoleBS = RoleBS.getInstance
            Return instance.queryForRoleRightsMaintain(RoleID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' Role權限的新增與刪除
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub ConfirmRoleRights(ByVal ds As DataSet)
        Try
            Dim instance As RoleBS = RoleBS.getInstance
            instance.ConfirmRoleRights(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "使用者相關操作 (UserBS)"

    Public Function ArmForUser(ByVal id As String, ByVal password As String) As DataSet
        Try
            Dim instance As UserBS = New UserBS
            Return instance.ArmForUser(id, password)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "使用者相關操作 (UserBO)"

    Public Sub AddUser(ByVal ds As DataSet)
        Try
            Dim instance As UserBO = New UserBO
            instance.AddUser(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub ModifyUser(ByVal ds As DataSet)
        Try
            Dim instance As UserBO = New UserBO
            instance.ModifyUser(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub DeleteUser(ByVal ds As DataSet)
        Try
            Dim instance As UserBO = New UserBO
            instance.DeleteUser(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Function QueryUser(ByVal ds As DataSet) As DataSet
        Try
            Dim instance As UserBO = New UserBO
            Return instance.QueryUser(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function ChangePassword(ByVal ds As DataSet) As Integer
        Try
            Dim instance As UserBO = New UserBO
            Return instance.ChangePassword(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function ResetPassword(ByVal ds As DataSet) As Integer
        Try
            Dim instance As UserBO = New UserBO
            Return instance.ResetPassword(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "角色相關操作 (RoleBO)"

    Public Function AddRole(ByVal ds As DataSet) As Integer
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.AddRole(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function ModifyRole(ByVal ds As DataSet) As Integer
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.ModifyRole(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function DeleteRole(ByVal ds As DataSet) As Integer
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.DeleteRole(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function QueryRole(ByVal roleID As String, ByVal roleName As String, ByVal isValid As String) As DataSet
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.QueryRole(roleID, roleName, isValid)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function RoleBelongQuery(ByVal ds As DataSet) As DataSet
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.RoleBelongQuery(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function RoleBelongUpdate(ByVal dsParam As DataSet, ByVal dsRoleInfo As DataSet) As Integer
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.RoleBelongUpdate(dsParam, dsRoleInfo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "系統操作 (ArmAppSystemBO_E1)"

    Public Function AppGetAppSystem(ByVal app_system_no As String, ByVal app_system_name As String, ByVal app_display_order As String, ByVal app_flag_no As String) As DataSet
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.getAppSystem(app_system_no, app_system_name, app_display_order, app_flag_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AppQueryByPK(ByRef pk_app_system_no As String) As DataSet
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.getAppSystem(pk_app_system_no, "", "", "")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AppInsert(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AppUpdate(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AppDelete(ByRef pk_app_system_no As String) As Integer
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.delete(pk_app_system_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AppGetAppSystemCombobox() As DataSet
        Try
            Dim instance As ArmAppSystemBO_E1 = New ArmAppSystemBO_E1
            Return instance.getAppSystemCombobox()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "子系統操作 (ArmSubSystemBO_E1)"

    Public Function SubGetSubSystem(ByVal sub_system_no As String, ByVal sub_system_name As String, ByVal sub_app_system_no As String, ByVal sub_display_order As String, ByVal sub_flag_no As String) As DataSet
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.getSubSystem(sub_system_no, sub_system_name, sub_app_system_no, sub_display_order, sub_flag_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function SubQueryByPK(ByRef pk_sub_system_no As String) As DataSet
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.getSubSystem(pk_sub_system_no, "", "", "", "")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function SubInsert(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function SubDelete(ByRef pk_sub_system_no As String) As Integer
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.delete(pk_sub_system_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function SubUpdate(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function SubGetSubSystemCombobox(ByVal sub_app_system_no As String) As DataSet
        Try
            Dim instance As ArmSubSystemBO_E1 = New ArmSubSystemBO_E1
            Return instance.getSubSystemCombobox(sub_app_system_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "作業操作 (ArmTskSystemBO_E1)"

    Public Function TskGetAllSystem(ByVal app_system_no As String, ByVal tsk_sub_system_no As String, ByVal tsk_task_no As String, ByVal tsk_task_name As String, ByVal tsk_display_order As String, ByVal tsk_task_flag_no As String) As DataSet
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.getAllSystem(app_system_no, tsk_sub_system_no, tsk_task_no, tsk_task_name, tsk_display_order, tsk_task_flag_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskQueryByPK(ByRef pk_tsk_task_no As String) As DataSet
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.getAllSystem("", "", pk_tsk_task_no, "", "", "")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskInsert(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskDelete(ByRef pk_tsk_task_no As String) As Integer
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.delete(pk_tsk_task_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskUpdate(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskGetTskSystemCombobox(ByVal tsk_sub_system_no As String) As DataSet
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.getTskSystemCombobox(tsk_sub_system_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "功能操作 (ArmFunSystemBO_E1)"

    Public Function FunGetAllSystem(ByVal app_system_no As String, ByVal sub_system_no As String, ByVal fun_task_no As String, ByVal fun_function_no As String, ByVal fun_function_name As String, ByVal fun_content As String, ByVal fun_special_flag As String, ByVal fun_display_order As String, ByVal fun_flag_no As String) As DataSet
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.getAllSystem(app_system_no, sub_system_no, fun_task_no, fun_function_no, fun_function_name, fun_content, fun_special_flag, fun_display_order, fun_flag_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function FunQueryByPK(ByRef pk_fun_function_no As String) As DataSet
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.getAllSystem("", "", "", pk_fun_function_no, "", "", "", "", "")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function FunQueryByLogin() As DataSet
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.queryByLogin
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function FunInsert(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function FunDelete(ByRef pk_fun_function_no As String) As Integer
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.delete(pk_fun_function_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function FunUpdate(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmFunSystemBO_E1 = New ArmFunSystemBO_E1
            Return instance.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "使用者登入資訊(by Lits on 2010-07-03)"
    Public Function insertLogonDate(ByVal ip As String, ByVal employeeCode As String) As Int32
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.insertLogonDate(ip, employeeCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function updateLogoutDate(ByVal ip As String, ByVal employeeCode As String) As Int32
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.updateLogoutDate(ip, employeeCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function queryIP() As DataSet
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.queryIP()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function insertLogonDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.insertLogonDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function updateLogoutDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.updateLogoutDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryIPBySystem(ByVal systemNo As String) As DataSet
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.queryIPBySystem(systemNo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryEmployeeRoleData(ByVal role As String, ByVal employeeCode As String) As DataSet
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.queryEmployeeRoleData(role, employeeCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function GetPassword(ByVal user As String) As String
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.GetPassword(user)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 記錄登入失敗
    ''' </summary>
    ''' <param name="employeeCode"></param>
    ''' <param name="ip"></param>
    ''' <param name="machineName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function saveLogonFailure(ByVal employeeCode As String, ByVal ip As String, ByVal machineName As String) As Integer
        Try
            Dim instance As LogonInfoBS = New LogonInfoBS
            Return instance.saveLogonFailure(employeeCode, ip, machineName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2012-09-28 個人化設定-我的最愛"

    Public Function insertProfile(ByVal ds As DataSet) As String
        Dim bs As New ArmProfileBS
        Try
            Return bs.insertProfileBS(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function delete(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As Integer
        Try
            Dim bo As New ArmProfileBO_E1
            Return bo.delete(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function queryProfileByPk(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As DataSet
        Try
            Dim bo As New ArmProfileBO_E1
            Return bo.queryByPK(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByVal flag As String = "") As DataSet
        Try
            Dim bo As New ArmProfileBO_E1
            Return bo.queryProfile(pk_System_No, pk_Employee_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function updateProfileDefault(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File As String, Optional ByVal flag As String = "Y") As Integer
        Try
            Dim bo As New ArmProfileBO_E1
            Return bo.updateProfileDefault(pk_System_No, pk_Employee_Code, pk_Sub_File, flag)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function RoleQueryByEmployee(ByVal Employee_Code As String) As DataSet
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.RoleQueryByEmployee(Employee_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 查詢角色歸屬的人員
    ''' </summary>
    ''' <param name="Role_Id" >角色代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByRole(ByVal Role_Id As String) As DataSet
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.EmployeeQueryByRole(Role_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 查詢功能歸屬的人員
    ''' </summary>
    ''' <param name="Fun_Function_No" >功能代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByFunction(ByVal Fun_Function_No As String) As DataSet
        Try
            Dim instance As RoleBO = New RoleBO
            Return instance.EmployeeQueryByFunction(Fun_Function_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "紀錄/查詢使用者執行過的作業"
    Public Function insertFunRecord(ByVal ds As DataSet) As Int32
        Try
            Dim instance As Syscom.Server.ARM.ArmRecordBO_E1 = Syscom.Server.ARM.ArmRecordBO_E1.getInstance
            Return instance.insertData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "授權代理操作 (ArmAgentAuthorizationBO_E1)"

    Public Function insertArmAgentAuth(ByVal ds As DataSet) As Integer
        Try
            Dim instance As ArmAgentAuthorizationBO_E1 = ArmAgentAuthorizationBO_E1.getInstance
            Return instance.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function deleteArmAgentAuth(ByVal employeeCode As String, ByVal agentCode As String, ByVal roleId As String, ByVal effectDate As String) As Integer
        Try
            Dim instance As ArmAgentAuthorizationBO_E1 = ArmAgentAuthorizationBO_E1.getInstance
            Return instance.delete(employeeCode, agentCode, roleId, CDate(effectDate))
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryByAgentEmployeeCode(ByRef pk_employee_code As System.String, ByRef pk_agent_code As System.String, ByVal role_id As String, ByVal effect_date As String, ByVal end_date As String) As System.Data.DataSet
        Try
            Dim instance As ArmAgentAuthorizationBO_E1 = ArmAgentAuthorizationBO_E1.getInstance
            Return instance.queryByAgentEmployeeCode(pk_employee_code, pk_agent_code, role_id, effect_date, end_date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "點擊次數統計 (ArmRecordBO_E1)"

    Public Function queryArmRecord(ByVal employeeCode As String, ByVal functionNo As String, ByVal startDate As String, ByVal endDate As String) As System.Data.DataSet
        Try
            Dim instance As ArmRecordBO_E1 = ArmRecordBO_E1.GetInstance
            Return instance.queryArmRecord(employeeCode, functionNo, startDate, endDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "單檔維護控制權限 (ArmRoleRightsBO_E1)"

    ''' <summary>
    ''' 查詢角色ID 以 userMemberOf 為索引
    ''' </summary>
    ''' <param name="userMemberOf">使用者歸屬角色</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRoleRightsByMemberOf(ByVal userMemberOf As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As ArmRoleRightsBO_E1 = ArmRoleRightsBO_E1.getInstance
            Return instance.queryRoleRightsByMemberOf(userMemberOf, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "    登入失敗超過3次UI (ArmLogonFailureBO_E1) "

#Region "2016/02/18 登入失敗超過3次查詢(Arm_Logon_Failure) by Hsiao,Kaiwen"

    ''' <summary>
    ''' 登入失敗超過3次查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Public Function ArmLogonFailureQueryLoginFailure(ByVal str_StartDay As String, ByVal str_EndDay As String) As System.Data.DataSet

        Dim m_ArmLogonFailure As ArmLogonFailureBO_E1 = New ArmLogonFailureBO_E1
        Try

            Return m_ArmLogonFailure.ArmLogonFailureQueryLoginFailure(str_StartDay, str_EndDay)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"登入失敗超過3次查詢"})

        End Try

    End Function

#End Region


#End Region

End Class