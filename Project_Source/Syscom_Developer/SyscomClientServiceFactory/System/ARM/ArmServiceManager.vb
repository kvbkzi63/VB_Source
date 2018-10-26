Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.ArmServiceReference

Partial Public Class ArmServiceManager

#Region "授權與認證 (LoginModuleBO)"

    'Private Property AppContext As Object

    Public Function Login(ByVal id As String, ByVal password As String, Optional ByVal system_type_id As String = "") As System.Data.DataSet Implements IArmServiceManager.Login
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.Login(id, password, system_type_id)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function LoginForSys(ByVal role As String) As DataTable Implements IArmServiceManager.LoginForSys
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.LoginForSys(role)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function LoginForAgent(ByVal loginUserId As String, ByVal userRoleArrayList() As String) As DataSet Implements IArmServiceManager.LoginForAgent
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.LoginForAgent(loginUserId, userRoleArrayList)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    ''' <summary>
    ''' 回傳個人資料、授權功能資料，根據ID、PassWord、Section_ID
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function LoginModuleLoginBySectionCode(ByVal id As String, ByVal password As String, ByVal SectionCode As String) As DataSet Implements IArmServiceManager.LoginModuleLoginBySectionCode
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.LoginModuleLoginBySectionCode(id, password, SectionCode)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
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
    Public Function queryForRoleRightsMaintain(ByVal RoleID As String) As DataSet Implements IArmServiceManager.queryForRoleRightsMaintain
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryForRoleRightsMaintain(RoleID)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    ''' <summary>
    ''' Role權限的新增與刪除
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub ConfirmRoleRights(ByVal ds As DataSet) Implements IArmServiceManager.ConfirmRoleRights
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.ConfirmRoleRights(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Sub

#End Region

#Region "使用者相關操作 (UserBS)"

    Public Function ArmForUser(ByVal id As String, ByVal password As String) As System.Data.DataSet Implements IArmServiceManager.ArmForUser
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.ArmForUser(id, password)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "使用者相關操作 (UserBO)"

    Public Sub AddUser(ByVal ds As System.Data.DataSet) Implements IArmServiceManager.AddUser
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.AddUser(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Sub

    Public Sub ModifyUser(ByVal ds As System.Data.DataSet) Implements IArmServiceManager.ModifyUser
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.ModifyUser(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Sub

    Public Sub DeleteUser(ByVal ds As System.Data.DataSet) Implements IArmServiceManager.DeleteUser
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.DeleteUser(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Sub

    Public Function QueryUser(ByVal ds As System.Data.DataSet) As System.Data.DataSet Implements IArmServiceManager.QueryUser
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.QueryUser(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function ChangePassword(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.ChangePassword
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.ChangePassword(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function ResetPassword(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.ResetPassword
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.ResetPassword(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "角色相關操作 (RoleBO)"

    Public Function AddRole(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.AddRole
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AddRole(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function ModifyRole(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.ModifyRole
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.ModifyRole(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function DeleteRole(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.DeleteRole
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.DeleteRole(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function QueryRole(ByVal roleID As String, ByVal roleName As String, ByVal isValid As String) As System.Data.DataSet Implements IArmServiceManager.QueryRole
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.QueryRole(roleID, roleName, isValid)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RoleBelongQuery(ByVal ds As System.Data.DataSet) As System.Data.DataSet Implements IArmServiceManager.RoleBelongQuery
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.RoleBelongQuery(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RoleBelongUpdate(ByVal dsParam As System.Data.DataSet, ByVal dsRoleInfo As System.Data.DataSet) As Integer Implements IArmServiceManager.RoleBelongUpdate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.RoleBelongUpdate(dsParam, dsRoleInfo)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "系統操作 (ArmAppSystemBO_E1)"

    Public Function AppGetAppSystem(ByVal app_system_no As String, ByVal app_system_name As String, ByVal app_display_order As String, ByVal app_flag_no As String) As DataSet Implements IArmServiceManager.AppGetAppSystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppGetAppSystem(app_system_no, app_system_name, app_display_order, app_flag_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function AppQueryByPK(ByRef pk_app_system_no As String) As System.Data.DataSet Implements IArmServiceManager.AppQueryByPK
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppQueryByPK(pk_app_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function AppDelete(ByRef pk_app_system_no As String) As Integer Implements IArmServiceManager.AppDelete
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppDelete(pk_app_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function AppInsert(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.AppInsert
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppInsert(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function AppUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.AppUpdate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppUpdate(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function AppGetAppSystemCombobox() As DataSet Implements IArmServiceManager.AppGetAppSystemCombobox
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.AppGetAppSystemCombobox
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "子系統操作 (ArmSubSystemBO_E1)"

    Public Function SubGetSubSystem(ByVal sub_system_no As String, ByVal sub_system_name As String, ByVal sub_app_system_no As String, ByVal sub_display_order As String, ByVal sub_flag_no As String) As DataSet Implements IArmServiceManager.SubGetSubSystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubGetSubSystem(sub_system_no, sub_system_name, sub_app_system_no, sub_display_order, sub_flag_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function SubQueryByPK(ByRef pk_sub_system_no As String) As System.Data.DataSet Implements IArmServiceManager.SubQueryByPK
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubQueryByPK(pk_sub_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function SubInsert(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.SubInsert
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubInsert(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function SubUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.SubUpdate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubUpdate(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function SubDelete(ByRef pk_sub_system_no As String) As Integer Implements IArmServiceManager.SubDelete
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubDelete(pk_sub_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function SubGetSubSystemCombobox(ByVal sub_app_system_no As String) As DataSet Implements IArmServiceManager.SubGetSubSystemCombobox
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.SubGetSubSystemCombobox(sub_app_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "作業操作 (ArmTskSystemBO_E1)"

    Public Function TskGetAllSystem(ByVal app_system_no As String, ByVal tsk_sub_system_no As String, ByVal tsk_task_no As String, ByVal tsk_task_name As String, ByVal tsk_display_order As String, ByVal tsk_task_flag_no As String) As DataSet Implements IArmServiceManager.TskGetAllSystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskGetAllSystem(app_system_no, tsk_sub_system_no, tsk_task_no, tsk_task_name, tsk_display_order, tsk_task_flag_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function TskQueryByPK(ByRef pk_tsk_task_no As String) As System.Data.DataSet Implements IArmServiceManager.TskQueryByPK
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskQueryByPK(pk_tsk_task_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function TskInsert(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.TskInsert
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskInsert(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function TskUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.TskUpdate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskUpdate(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function TskDelete(ByRef pk_tsk_task_no As String) As Integer Implements IArmServiceManager.TskDelete
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskDelete(pk_tsk_task_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function TskGetTskSystemCombobox(ByVal tsk_sub_system_no As String) As DataSet Implements IArmServiceManager.TskGetTskSystemCombobox
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.TskGetTskSystemCombobox(tsk_sub_system_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "功能操作 (ArmFunSystemBO_E1)"

    Public Function FunGetAllSystem(ByVal app_system_no As String, ByVal sub_system_no As String, ByVal fun_task_no As String, ByVal fun_function_no As String, ByVal fun_function_name As String, ByVal fun_content As String, ByVal fun_special_flag As String, ByVal fun_display_order As String, ByVal fun_flag_no As String) As DataSet Implements IArmServiceManager.FunGetAllSystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunGetAllSystem(app_system_no, sub_system_no, fun_task_no, fun_function_no, fun_function_name, fun_content, fun_special_flag, fun_display_order, fun_flag_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function FunQueryByPK(ByRef pk_fun_function_no As String) As System.Data.DataSet Implements IArmServiceManager.FunQueryByPK
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunQueryByPK(pk_fun_function_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function FunQueryByLogin() As DataSet Implements IArmServiceManager.FunQueryByLogin
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunQueryByLogin
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function FunInsert(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.FunInsert
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunInsert(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function FunUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IArmServiceManager.FunUpdate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunUpdate(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function FunDelete(ByRef pk_fun_function_no As String) As Integer Implements IArmServiceManager.FunDelete
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.FunDelete(pk_fun_function_no)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "使用者登入資訊(by Lits on 2010-07-03)"

    Function insertLogonDate(ByVal ip As String, ByVal employeeCode As String) As Int32 Implements IArmServiceManager.insertLogonDate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertLogonDate(ip, employeeCode)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function updateLogoutDate(ByVal ip As String, ByVal employeeCode As String) As Int32 Implements IArmServiceManager.updateLogoutDate
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateLogoutDate(ip, employeeCode)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function queryIP() As DataSet Implements IArmServiceManager.queryIP
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryIP
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function insertLogonDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32 Implements IArmServiceManager.insertLogonDateBySystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertLogonDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function updateLogoutDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String) As Int32 Implements IArmServiceManager.updateLogoutDateBySystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateLogoutDateBySystem(systemNo, loginDate, ip, employeeCode, agentCode, machineName)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function queryIPBySystem(ByVal systemNo As String) As DataSet Implements IArmServiceManager.queryIPBySystem
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryIPBySystem(systemNo)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function queryEmployeeRoleData(ByVal role As String, ByVal employeeCode As String) As DataSet Implements IArmServiceManager.queryEmployeeRoleData
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryEmployeeRoleData(role, employeeCode)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Function getPassword(ByVal user As String) As String Implements IArmServiceManager.getPassword
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getPassword(user)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
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
    Function saveLogonFailure(ByVal employeeCode As String, ByVal ip As String, ByVal machineName As String) As Integer Implements IArmServiceManager.saveLogonFailure
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.saveLogonFailure(employeeCode, ip, machineName)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "2012-09-28 個人化設定-我的最愛"

    Public Function insertProfile(ByVal ds As DataSet) As String Implements IArmServiceManager.insertProfile
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertProfile(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Public Function deleteProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As Integer Implements IArmServiceManager.deleteProfile
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteProfile(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Public Function queryProfileByPk(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File_Name As String) As DataSet Implements IArmServiceManager.queryProfileByPk
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryProfileByPk(pk_System_No, pk_Employee_Code, pk_Sub_File_Name)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Public Function queryProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByVal flag As String = "") As DataSet Implements IArmServiceManager.queryProfile
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryProfile(pk_System_No, pk_Employee_Code, flag)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
    Public Function updateProfileDefault(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File As String, Optional ByVal flag As String = "Y") As Integer Implements IArmServiceManager.updateProfileDefault
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateProfileDefault(pk_System_No, pk_Employee_Code, pk_Sub_File, flag)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
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
    Public Function RoleQueryByEmployee(ByVal Employee_Code As String) As DataSet Implements IArmServiceManager.RoleQueryByEmployee
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.RoleQueryByEmployee(Employee_Code)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢角色歸屬的人員
    ''' </summary>
    ''' <param name="Role_Id" >角色代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByRole(ByVal Role_Id As String) As DataSet Implements IArmServiceManager.EmployeeQueryByRole
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.EmployeeQueryByRole(Role_Id)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢功能歸屬的人員
    ''' </summary>
    ''' <param name="Fun_Function_No" >功能代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function EmployeeQueryByFunction(ByVal Fun_Function_No As String) As DataSet Implements IArmServiceManager.EmployeeQueryByFunction
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.EmployeeQueryByFunction(Fun_Function_No)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "紀錄/查詢使用者執行過的作業"
    Public Function insertFunRecord(ByVal ds As DataSet) As Int32 Implements IArmServiceManager.insertFunRecord
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.insertFunRecord(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function
#End Region

#Region "授權代理操作 (ArmAgentAuthorizationBO_E1)"

    Public Function insertArmAgentAuth(ByVal ds As DataSet) As Integer Implements IArmServiceManager.insertArmAgentAuth
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertArmAgentAuth(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function deleteArmAgentAuth(ByVal employeeCode As String, ByVal agentCode As String, ByVal roleId As String, ByVal effectDate As String) As Integer Implements IArmServiceManager.deleteArmAgentAuth
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteArmAgentAuth(employeeCode, agentCode, roleId, effectDate)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryByAgentEmployeeCode(ByRef pk_employee_code As System.String, ByRef pk_agent_code As System.String, ByVal role_id As String, ByVal effect_date As String, ByVal end_date As String) As System.Data.DataSet Implements IArmServiceManager.queryByAgentEmployeeCode
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryByAgentEmployeeCode(pk_employee_code, pk_agent_code, role_id, effect_date, end_date)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "點擊次數統計 (ArmRecordBO_E1)"

    Public Function queryArmRecord(ByVal employeeCode As String, ByVal functionNo As String, ByVal startDate As String, ByVal endDate As String) As System.Data.DataSet Implements IArmServiceManager.queryArmRecord
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryArmRecord(employeeCode, functionNo, startDate, endDate)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
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
    Public Function queryRoleRightsByMemberOf(ByVal userMemberOf As String) As DataSet Implements IArmServiceManager.queryRoleRightsByMemberOf
        Dim instance As ArmServiceClient = Nothing
        Try
            instance = getArmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryRoleRightsByMemberOf(userMemberOf)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "    登入失敗超過3次UI (ArmLogonFailureBO_E1) "

#Region "2016/02/18 登入失敗超過3次查詢(Arm_Logon_Failure) by Hsiao,Kaiwen"

#Region "     登入失敗超過3次查詢 "
    ''' <summary>
    ''' 登入失敗超過3次查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Public Function ArmLogonFailureQueryLoginFailure(ByVal str_StartDay As String, ByVal str_EndDay As String) As System.Data.DataSet Implements IArmServiceManager.ArmLogonFailureQueryLoginFailure

        Dim tempclient As ArmServiceClient = Nothing

        Try
            tempclient = getArmService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.ArmLogonFailureQueryLoginFailure(str_StartDay, str_EndDay)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#End Region


#End Region

End Class