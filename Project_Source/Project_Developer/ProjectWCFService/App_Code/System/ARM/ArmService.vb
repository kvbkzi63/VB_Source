' 注意: 若變更此處的類別名稱 "ArmService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "ArmService" 的參考。
Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.ARM

Public Class ArmService
    Implements IArmService

#Region "授權與認證 (LoginModuleBO)"

    Function Login(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As DataSet Implements IArmService.Login
        Try
            Return ARMDelegate.getInstance.Login(id, password, system_type_id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function LoginForSys(ByVal role As String) As DataTable Implements IArmService.LoginForSys
        Try
            Return ARMDelegate.getInstance.LoginForSys(role)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function LoginForAgent(ByVal loginUserId As String, ByVal userRoleArrayList() As String) As DataSet Implements IArmService.LoginForAgent
        Try
            Return ARMDelegate.getInstance.LoginForAgent(loginUserId, userRoleArrayList)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 回傳個人資料、授權功能資料，根據ID、PassWord、Section_ID
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function LoginModuleLoginBySectionCode(ByVal id As String, ByVal password As String, ByVal SectionCode As String) As DataSet Implements IArmService.LoginModuleLoginBySectionCode

        Try

            Dim tempDelegate As ARMDelegate = ARMDelegate.getInstance

            Return tempDelegate.LoginModuleLoginBySectionCode(id, password, SectionCode)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

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
    Public Function queryForRoleRightsMaintain(ByVal RoleID As String) As DataSet Implements IArmService.queryForRoleRightsMaintain
        Try
            Return ARMDelegate.getInstance.queryForRoleRightsMaintain(RoleID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' Role權限的新增與刪除
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub ConfirmRoleRights(ByVal ds As DataSet) Implements IArmService.ConfirmRoleRights
        Try
            ARMDelegate.getInstance.ConfirmRoleRights(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

#End Region

#Region "使用者相關操作 (UserBS)"

    Function ArmForUser(ByVal id As String, ByVal password As String) As DataSet Implements IArmService.ArmForUser
        Try
            Return ARMDelegate.getInstance.ArmForUser(id, password)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "使用者相關操作 (UserBO)"

    Sub AddUser(ByVal ds As DataSet) Implements IArmService.AddUser
        Try
            ARMDelegate.getInstance.AddUser(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Sub ModifyUser(ByVal ds As DataSet) Implements IArmService.ModifyUser
        Try
            ARMDelegate.getInstance.ModifyUser(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Sub DeleteUser(ByVal ds As DataSet) Implements IArmService.DeleteUser
        Try
            ARMDelegate.getInstance.DeleteUser(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Function QueryUser(ByVal ds As DataSet) As DataSet Implements IArmService.QueryUser
        Try
            Return ARMDelegate.getInstance.QueryUser(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function ChangePassword(ByVal ds As DataSet) As Integer Implements IArmService.ChangePassword
        Try
            Return ARMDelegate.getInstance.ChangePassword(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function ResetPassword(ByVal ds As DataSet) As Integer Implements IArmService.ResetPassword
        Try
            Return ARMDelegate.getInstance.ResetPassword(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "角色相關操作 (RoleBO)"

    Function AddRole(ByVal ds As DataSet) As Integer Implements IArmService.AddRole
        Try
            Return ARMDelegate.getInstance.AddRole(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function ModifyRole(ByVal ds As DataSet) As Integer Implements IArmService.ModifyRole
        Try
            Return ARMDelegate.getInstance.ModifyRole(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function DeleteRole(ByVal ds As DataSet) As Integer Implements IArmService.DeleteRole
        Try
            Return ARMDelegate.getInstance.DeleteRole(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function QueryRole(ByVal roleID As String, ByVal roleName As String, ByVal isValid As String) As DataSet Implements IArmService.QueryRole
        Try
            Return ARMDelegate.getInstance.QueryRole(roleID, roleName, isValid)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function RoleBelongQuery(ByVal ds As DataSet) As DataSet Implements IArmService.RoleBelongQuery
        Try
            Return ARMDelegate.getInstance.RoleBelongQuery(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function RoleBelongUpdate(ByVal dsParam As DataSet, ByVal dsRoleInfo As DataSet) As Integer Implements IArmService.RoleBelongUpdate
        Try
            Return ARMDelegate.getInstance.RoleBelongUpdate(dsParam, dsRoleInfo)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "系統操作 (ArmAppSystemBO_E1)"

    Public Function AppGetAppSystem(ByVal app_system_no As String, ByVal app_system_name As String, ByVal app_display_order As String, ByVal app_flag_no As String) As DataSet Implements IArmService.AppGetAppSystem
        Try
            Return ARMDelegate.getInstance.AppGetAppSystem(app_system_no, app_system_name, app_display_order, app_flag_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function AppQueryByPK(ByRef pk_app_system_no As String) As DataSet Implements IArmService.AppQueryByPK
        Try
            Return ARMDelegate.getInstance.AppQueryByPK(pk_app_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function AppInsert(ByVal ds As DataSet) As Integer Implements IArmService.AppInsert
        Try
            Return ARMDelegate.getInstance.AppInsert(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function AppDelete(ByRef pk_app_system_no As String) As Integer Implements IArmService.AppDelete
        Try
            Return ARMDelegate.getInstance.AppDelete(pk_app_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function AppUpdate(ByVal ds As DataSet) As Integer Implements IArmService.AppUpdate
        Try
            Return ARMDelegate.getInstance.AppUpdate(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function AppGetAppSystemCombobox() As DataSet Implements IArmService.AppGetAppSystemCombobox
        Try
            Return ARMDelegate.getInstance.AppGetAppSystemCombobox
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "子系統操作 (ArmSubSystemBO_E1)"

    Public Function SubGetSubSystem(ByVal sub_system_no As String, ByVal sub_system_name As String, ByVal sub_app_system_no As String, ByVal sub_display_order As String, ByVal sub_flag_no As String) As DataSet Implements IArmService.SubGetSubSystem
        Try
            Return ARMDelegate.getInstance.SubGetSubSystem(sub_system_no, sub_system_name, sub_app_system_no, sub_display_order, sub_flag_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function SubQueryByPK(ByRef pk_sub_system_no As String) As DataSet Implements IArmService.SubQueryByPK
        Try
            Return ARMDelegate.getInstance.SubQueryByPK(pk_sub_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function SubInsert(ByVal ds As DataSet) As Integer Implements IArmService.SubInsert
        Try
            Return ARMDelegate.getInstance.SubInsert(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function SubDelete(ByRef pk_sub_system_no As String) As Integer Implements IArmService.SubDelete
        Try
            Return ARMDelegate.getInstance.SubDelete(pk_sub_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function SubUpdate(ByVal ds As DataSet) As Integer Implements IArmService.SubUpdate
        Try
            Return ARMDelegate.getInstance.SubUpdate(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function SubGetSubSystemCombobox(ByVal sub_app_system_no As String) As DataSet Implements IArmService.SubGetSubSystemCombobox
        Try
            Return ARMDelegate.getInstance.SubGetSubSystemCombobox(sub_app_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "作業操作 (ArmTskSystemBO_E1)"

    Public Function TskGetAllSystem(ByVal app_system_no As String, ByVal tsk_sub_system_no As String, ByVal tsk_task_no As String, ByVal tsk_task_name As String, ByVal tsk_display_order As String, ByVal tsk_task_flag_no As String) As DataSet Implements IArmService.TskGetAllSystem
        Try
            Dim instance As ArmTskSystemBO_E1 = New ArmTskSystemBO_E1
            Return instance.getAllSystem(app_system_no, tsk_sub_system_no, tsk_task_no, tsk_task_name, tsk_display_order, tsk_task_flag_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function TskQueryByPK(ByRef pk_tsk_task_no As String) As DataSet Implements IArmService.TskQueryByPK
        Try
            Return ARMDelegate.getInstance.TskQueryByPK(pk_tsk_task_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function TskInsert(ByVal ds As DataSet) As Integer Implements IArmService.TskInsert
        Try
            Return ARMDelegate.getInstance.TskInsert(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function TskDelete(ByRef pk_tsk_task_no As String) As Integer Implements IArmService.TskDelete
        Try
            Return ARMDelegate.getInstance.TskDelete(pk_tsk_task_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function TskUpdate(ByVal ds As DataSet) As Integer Implements IArmService.TskUpdate
        Try
            Return ARMDelegate.getInstance.TskUpdate(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function TskGetTskSystemCombobox(ByVal tsk_sub_system_no As String) As DataSet Implements IArmService.TskGetTskSystemCombobox
        Try
            Return ARMDelegate.getInstance.TskGetTskSystemCombobox(tsk_sub_system_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "功能操作 (ArmFunSystemBO_E1)"

    Public Function FunGetAllSystem(ByVal app_system_no As String, ByVal sub_system_no As String, ByVal fun_task_no As String, ByVal fun_function_no As String, ByVal fun_function_name As String, ByVal fun_content As String, ByVal fun_special_flag As String, ByVal fun_display_order As String, ByVal fun_flag_no As String) As DataSet Implements IArmService.FunGetAllSystem
        Try
            Return ARMDelegate.getInstance.FunGetAllSystem(app_system_no, sub_system_no, fun_task_no, fun_function_no, fun_function_name, fun_content, fun_special_flag, fun_display_order, fun_flag_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function FunQueryByPK(ByRef pk_fun_function_no As String) As DataSet Implements IArmService.FunQueryByPK
        Try
            Return ARMDelegate.getInstance.FunQueryByPK(pk_fun_function_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function FunQueryByLogin() As DataSet Implements IArmService.FunQueryByLogin
        Try
            Return ARMDelegate.getInstance.FunQueryByLogin
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function FunInsert(ByVal ds As DataSet) As Integer Implements IArmService.FunInsert
        Try
            Return ARMDelegate.getInstance.FunInsert(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function FunDelete(ByRef pk_fun_function_no As String) As Integer Implements IArmService.FunDelete
        Try
            Return ARMDelegate.getInstance.FunDelete(pk_fun_function_no)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function FunUpdate(ByVal ds As DataSet) As Integer Implements IArmService.FunUpdate
        Try
            Return ARMDelegate.getInstance.FunUpdate(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "使用者登入資訊(by Lits on 2010-07-03)"
    Function insertLogonDate(ByVal ip As String, ByVal employeeCode As String) As Int32 Implements IArmService.insertLogonDate
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.insertLogonDate(ip, employeeCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function updateLogoutDate(ByVal ip As String, ByVal employeeCode As String) As Int32 Implements IArmService.updateLogoutDate
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.updateLogoutDate(ip, employeeCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function queryIP() As DataSet Implements IArmService.queryIP
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.queryIP()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function insertLogonDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32 Implements IArmService.insertLogonDateBySystem
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.insertLogonDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function updateLogoutDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32 Implements IArmService.updateLogoutDateBySystem
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.updateLogoutDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function queryIPBySystem(ByVal systemNo As String) As DataSet Implements IArmService.queryIPBySystem
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.queryIPBySystem(systemNo)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Function queryEmployeeRoleData(ByVal role As String, ByVal employeeCode As String) As DataSet Implements IArmService.queryEmployeeRoleData
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.queryEmployeeRoleData(role, employeeCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Function getPassword(ByVal user As String) As String Implements IArmService.getPassword
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.GetPassword(user)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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
    Public Function saveLogonFailure(ByVal employeeCode As String, ByVal ip As String, ByVal machineName As String) As Integer Implements IArmService.saveLogonFailure
        Try
            Dim arm As ARMDelegate = ARMDelegate.getInstance
            Return arm.saveLogonFailure(employeeCode, ip, machineName)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "2012-09-28 個人化設定-我的最愛"
    Public Function insertProfile(ByVal ds As DataSet) As String Implements IArmService.insertProfile
        Try
            Dim profile As ARMDelegate = ARMDelegate.getInstance
            Return profile.insertProfile(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Public Function deleteProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As Integer Implements IArmService.deleteProfile
        Try
            Dim profile As ARMDelegate = ARMDelegate.getInstance
            Return profile.delete(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Public Function queryProfileByPk(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As DataSet Implements IArmService.queryProfileByPk
        Try
            Dim profile As ARMDelegate = ARMDelegate.getInstance
            Return profile.queryProfileByPk(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Public Function queryProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByVal flag As String = "") As DataSet Implements IArmService.queryProfile
        Try
            Dim profile As ARMDelegate = ARMDelegate.getInstance
            Return profile.queryProfile(pk_System_No, pk_Employee_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function updateProfileDefault(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File As String, Optional ByVal flag As String = "Y") As Integer Implements IArmService.updateProfileDefault
        Try
            Dim profile As ARMDelegate = ARMDelegate.getInstance
            Return profile.updateProfileDefault(pk_System_No, pk_Employee_Code, pk_Sub_File, flag)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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
    Public Function RoleQueryByEmployee(ByVal Employee_Code As String) As DataSet Implements IArmService.RoleQueryByEmployee
        Try
            Return ARMDelegate.getInstance.RoleQueryByEmployee(Employee_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 查詢角色歸屬的人員
    ''' </summary>
    ''' <param name="Role_Id" >角色代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByRole(ByVal Role_Id As String) As DataSet Implements IArmService.EmployeeQueryByRole
        Try
            Return ARMDelegate.getInstance.EmployeeQueryByRole(Role_Id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 查詢功能歸屬的人員
    ''' </summary>
    ''' <param name="Fun_Function_No" >功能代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByFunction(ByVal Fun_Function_No As String) As DataSet Implements IArmService.EmployeeQueryByFunction
        Try
            Return ARMDelegate.getInstance.EmployeeQueryByFunction(Fun_Function_No)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "紀錄/查詢使用者執行過的作業"
    Public Function insertFunRecord(ByVal ds As DataSet) As Int32 Implements IArmService.insertFunRecord
        Try
            Dim obj As ARMDelegate = ARMDelegate.getInstance
            Return obj.insertFunRecord(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "授權代理操作 (ArmAgentAuthorizationBO_E1)"

    Public Function insertArmAgentAuth(ByVal ds As DataSet) As Integer Implements IArmService.insertArmAgentAuth
        Try
            Dim instance As ARMDelegate = ARMDelegate.getInstance
            Return instance.insertArmAgentAuth(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deleteArmAgentAuth(ByVal employeeCode As String, ByVal agentCode As String, ByVal roleId As String, ByVal effectDate As String) As Integer Implements IArmService.deleteArmAgentAuth
        Try
            Dim instance As ARMDelegate = ARMDelegate.getInstance
            Return instance.deleteArmAgentAuth(employeeCode, agentCode, roleId, effectDate)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function queryByAgentEmployeeCode(ByRef pk_employee_code As System.String, ByRef pk_agent_code As System.String, ByVal role_id As String, ByVal effect_date As String, ByVal end_date As String) As System.Data.DataSet Implements IArmService.queryByAgentEmployeeCode
        Try
            Dim instance As ARMDelegate = ARMDelegate.getInstance
            Return instance.queryByAgentEmployeeCode(pk_employee_code, pk_agent_code, role_id, effect_date, end_date)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "點擊次數統計 (ArmRecordBO_E1)"

    Public Function queryArmRecord(ByVal employeeCode As String, ByVal functionNo As String, ByVal startDate As String, ByVal endDate As String) As System.Data.DataSet Implements IArmService.queryArmRecord
        Try
            Dim instance As ARMDelegate = ARMDelegate.getInstance
            Return instance.queryArmRecord(employeeCode, functionNo, startDate, endDate)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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
    Public Function queryRoleRightsByMemberOf(ByVal userMemberOf As String) As DataSet Implements IArmService.queryRoleRightsByMemberOf
        Try
            Dim instance As ARMDelegate = ARMDelegate.getInstance
            Return instance.queryRoleRightsByMemberOf(userMemberOf)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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
    Public Function ArmLogonFailureQueryLoginFailure(ByVal str_StartDay As String, ByVal str_EndDay As String) As System.Data.DataSet Implements IArmService.ArmLogonFailureQueryLoginFailure

        Try

            Dim tempDelegate As ARMDelegate = ARMDelegate.getInstance

            Return tempDelegate.ArmLogonFailureQueryLoginFailure(str_StartDay, str_EndDay)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region



End Class
