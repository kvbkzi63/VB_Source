Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.NfcServiceReference

Partial Public Class NfcServiceManager

#Region "     訊息群組維護"
    ''' <summary>
    ''' 查詢訊息群組成員
    ''' </summary>
    ''' <param name="GroupID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGroupMember(ByVal GroupID As String) As System.Data.DataSet Implements INfcServiceManager.queryGroupMember
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGroupMember(GroupID)
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
    Public Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String) As Integer Implements INfcServiceManager.deleteSenderByGroupTxId
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteSenderByGroupTxId(Group_Tx_Id)
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
    Public Function updateSender(ByRef ds As System.Data.DataSet) As Integer Implements INfcServiceManager.updateSender
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updateSender(ds)
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
    Public Function queryGroupMember1(ByVal id As String) As System.Data.DataSet Implements INfcServiceManager.queryGroupMember1
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGroupMember1(id)
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

    '新增訊息群組成員
    Public Function insertGroupMember(ByVal ds As DataSet) As Integer Implements INfcServiceManager.insertGroupMember
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGroupMember(ds)
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
    '刪除訊息群組成員
    Public Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer Implements INfcServiceManager.deleteGroupMember
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGroupMember(groupID, employeeCode)
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
    Public Function deleteGroupMembers(ByVal ds As DataSet) As Integer Implements INfcServiceManager.deleteGroupMembers
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGroupMembers(ds)
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

    Public Function insertGroup(ByVal groupName As String, createUser As String) As Integer Implements INfcServiceManager.insertGroup
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertGroup(groupName, createUser)
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
    '刪除群組名稱
    Public Function deleteGroup(ByVal groupID As String) As Integer Implements INfcServiceManager.deleteGroup
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteGroup(groupID)
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
    '查詢群組名稱By User
    Public Function queryGroupByUser(ByVal employee_Code As String) As System.Data.DataSet Implements INfcServiceManager.queryGroupByUser
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryGroupByUser(employee_Code)
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

#Region "   查詢當天發版通知,註記已讀"
    Public Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String) As Integer Implements INfcServiceManager.UpdateIP
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.UpdateIP(mid, call_IP, modified_User)
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

    Public Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String) As Integer Implements INfcServiceManager.UpdateSpecFlag
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.UpdateSpecFlag(mid, modified_User)
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

    Public Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As System.Data.DataSet Implements INfcServiceManager.QueryNFCNotifyMsgByCond
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.QueryNFCNotifyMsgByCond(StartSendDate, EndSendDate, Fun_Function_No, Type, Level, Status, Recipient, sendUser)
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

    Public Function initialNfcQueryExportUI() As System.Data.DataSet Implements INfcServiceManager.initialNfcQueryExportUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.initialNfcQueryExportUI()
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


    Public Function InsertNFCNotifyMsg(ByVal data As System.Data.DataSet) As String Implements INfcServiceManager.InsertNFCNotifyMsg
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.InsertNFCNotifyMsg(data)
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

    Public Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As System.Data.DataSet Implements INfcServiceManager.QueryNFCNotifyMsgByUserId
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.QueryNFCNotifyMsgByUserId(UserId)
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
    ''' 讀取24小時前的個人訊息，不需傳 depNo，由程式去撈資料
    ''' </summary>
    ''' <param name="empNO">員工號</param>    
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function readUIMessage24Hr(ByVal empNO As String) As System.Data.DataSet Implements INfcServiceManager.readUIMessage24Hr
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.readUIMessage24HrAuto(empNO)
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
    ''' 讀取24小時前的個人訊息，需傳 depNo
    ''' </summary>
    Public Function readUIMessage24Hr(ByVal empNO As String, ByVal depNo As String) As DataSet Implements INfcServiceManager.readUIMessage24Hr
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.readUIMessage24Hr(empNO, depNo)
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
    ''' 讀取個人訊息，不需傳 depNo，由程式去撈資料
    ''' </summary>
    ''' <param name="empNO">員工號</param>    
    Public Function readUIMessage(ByVal empNO As String) As System.Data.DataSet Implements INfcServiceManager.readUIMessage
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.readUIMessageAuto(empNO)
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
    ''' 讀取個人訊息，需傳 depNo 
    ''' </summary>
    Public Function readUIMessage(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet Implements INfcServiceManager.readUIMessage
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.readUIMessage(empNO, depNo)
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
    ''' 通知到所有使用者 UI 畫面
    ''' </summary>    
    Public Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyAllUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyAllUI(subject, msg, startTime, endTime, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到所有使用者 UI 畫面
    ''' </summary>    
    Public Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyAllUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyAllUIExternal(subject, msg, startTime, endTime, external, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到部門使用者 UI 畫面
    ''' </summary>
    Public Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyDepUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyDepUI(empDept, subject, msg, startTime, endTime, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到部門使用者 UI 畫面
    ''' </summary>
    Public Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyDepUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyDepUIExternal(empDept, subject, msg, startTime, endTime, external, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>
    ''' <remarks></remarks>
    Public Sub NotifyUI(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUIMulti(drEmpNo, subject, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks></remarks>
    Public Sub NotifyUI(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUIMultiExternal(drEmpNo, subject, msg, external, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>    
    ''' <remarks></remarks>
    Public Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUI(drEmpNo, subject, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks></remarks>
    Public Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyUI
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUIExternal(drEmpNo, subject, msg, external)
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

    ''' <summary>
    ''' 通知到多個使用者 Mail
    ''' </summary>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>    
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyMail
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyMailMulti(EmpMail, subject, msg)
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

    ''' <summary>
    ''' 通知到多個使用者 Mail
    ''' </summary>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg">需要回覆或連絡時的內容 ex: 請回 call 2065  陳先生 </param>
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyMail
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyMailMultiReply(EmpMail, subject, msg, replymsg)
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

    ''' <summary>
    ''' 通知到使用者 Mail
    ''' </summary>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>    
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyMail
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyMail(EmpMail, subject, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 Mail
    ''' </summary>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg">需要回覆或連絡時的內容 ex: 請回 call 2065  陳先生 </param>
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyMail
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyMailReply(EmpMail, subject, msg, replymsg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">多個員工號</param>
    ''' <param name="msg">通知訊息</param>    
    ''' <remarks>通知訊息最多 160 個字</remarks>
    Public Sub NotifySMS(ByVal drEmpNo() As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifySMS
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifySMSMulti(drEmpNo, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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



    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>    
    ''' <remarks>通知訊息最多 160 個字</remarks>
    Public Sub NotifySMS(ByVal drEmpNo As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifySMS
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifySMS(drEmpNo, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No)
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

    ''' <summary>
    ''' 通知對象維護-查詢
    ''' </summary>
    ''' <param name="columnName">欄位名稱</param>
    ''' <param name="columnValue">欄位值</param>    
    ''' <remarks></remarks>
    Public Function queryNFCNotifierByFunc(ByVal columnName As String(), ByVal columnValue As Object()) As DataSet Implements INfcServiceManager.queryNFCNotifierByFunc
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryNFCNotifierByFunc(columnName, columnValue)
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
    ''' 通知對象維護-存檔
    ''' </summary>
    ''' <param name="inSaveData">存檔資料</param>
    ''' <remarks></remarks>
    Public Function saveNFCNotifierByFunc(ByVal inSaveData As DataSet) As Integer Implements INfcServiceManager.saveNFCNotifierByFunc
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.saveNFCNotifierByFunc(inSaveData)
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
    ''' 通知對象維護-刪除
    ''' </summary>
    ''' <param name="inDeleteData">刪除資料</param>
    ''' <remarks></remarks>
    Public Function deleteNFCNotifierByFunc(ByVal inDeleteData As DataSet) As Integer Implements INfcServiceManager.deleteNFCNotifierByFunc
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deleteNFCNotifierByFunc(inDeleteData)
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
    '''  取得發版通知-查詢
    ''' </summary>
    ''' <param name="columnName">欄位名稱</param>
    ''' <param name="columnValue">欄位值</param>    
    ''' <remarks></remarks>
    Public Function getNotifyMessageByDeploy(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements INfcServiceManager.getNotifyMessageByDeploy
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getNotifyMessageByDeploy(columnName, columnValue)
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
    '''  取得發版通知-查詢-By Extunction
    ''' </summary>
    ''' <param name="_type">_Type</param>
    ''' <param name="user">user</param>
    ''' <remarks></remarks>
    Public Function QueryDeployByToDay(ByVal _type As String, ByVal user As String) As System.Data.DataSet Implements INfcServiceManager.QueryDeployByToDay
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.QueryDeployByToDay(_type, user)
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
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks></remarks>
    Public Sub NotifyUIRigthNow(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcServiceManager.NotifyUIRigthNow
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUIExternalRightNow(drEmpNo, subject, msg, external)
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

    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">多個員工號</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">通知訊息</param>
    ''' <remarks>
    ''' Created in  2014/11/6, 下午 05:12 by Chris
    ''' </remarks>
    Public Sub NotifySMSMultiWithSubject(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String) Implements INfcServiceManager.NotifySMSMultiWithSubject
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifySMSMultiWithSubject(drEmpNo, subject, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, Spec_Flag)
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


    ''' <summary>
    ''' 異常通報系統回饋到使用者 Mail
    ''' </summary>
    ''' <param name="EmpMail">多個員工 Mail</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg"></param>
    ''' <remarks>
    ''' Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好
    ''' Created in  2014/11/6, 下午 05:32 by Chris
    ''' </remarks>
    Public Sub NotifyMailWithEsrFormat(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String) Implements INfcServiceManager.NotifyMailWithEsrFormat
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyMailWithEsrFormat(EmpMail, subject, msg, replymsg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, Spec_Flag)
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

    ''' <summary>
    ''' 通知到多個使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo"> 原工編號 </param>
    ''' <param name="subject"> 主旨 </param>
    ''' <param name="msg"> 訊息 </param>
    ''' <param name="Start_Time"> 開始時間 </param>
    ''' <param name="End_Time"> 結束時間 </param>
    ''' <remarks>
    ''' Created in  2014/11/6, 下午 05:58 by Chris
    ''' </remarks>
    ''' <exception cref="Syscom.Comm.EXP.CommonException"> CMMCMMD001 </exception>

    Public Sub NotifyUIWithStartAndEndTime(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Start_Time As String, End_Time As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String) Implements INfcServiceManager.NotifyUIWithStartAndEndTime
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.NotifyUIWithStartAndEndTime(drEmpNo, subject, msg, Start_Time, End_Time, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, Spec_Flag)
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

    Public Function reMarkRead(ByVal ds As System.Data.DataSet) As Integer Implements INfcServiceManager.reMarkRead
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.reMarkRead(ds)
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
    'Function UpdateReplayMsg(ByVal MID As String, ByVal replayMsg As String, ByVal modifyUser As String) As Integer
    Public Function UpdateReplayMsg(ByVal MID As String, ByVal replayMsg As String, ByVal modifyUser As String) As Integer Implements INfcServiceManager.UpdateReplayMsg
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.UpdateReplayMsg(MID, replayMsg, modifyUser)
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

    Public Function getNfcPhrase(ByVal PhraseId As String) As System.Data.DataSet Implements INfcServiceManager.getNfcPhrase
        Dim instance As NfcServiceClient = Nothing
        Try
            instance = getNfcService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getNfcPhrase(PhraseId)
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

#Region "2017/03/10 更新訊息結束時間(Nfc_Notify_Msg) by Jun"

#Region "     更新訊息結束時間 "
    ''' <summary>
    ''' 更新訊息結束時間
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function updateNfcNotifyMsgEndTime(ByVal ds As System.Data.DataSet) As Integer Implements INfcServiceManager.updateNfcNotifyMsgEndTime

        Dim tempclient As NfcServiceClient = Nothing

        Try
            tempclient = getNfcService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updateNfcNotifyMsgEndTime(ds)
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


#Region "     以主旨取得通知訊息 "
    ''' <summary>
    ''' 以主旨取得通知訊息
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function queryNfcNotifyMsgBySubject(ByVal subject As String) As System.Data.DataSet Implements INfcServiceManager.queryNfcNotifyMsgBySubject

        Dim tempclient As NfcServiceClient = Nothing

        Try
            tempclient = getNfcService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryNfcNotifyMsgBySubject(subject)
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


#Region "2017/03/21 查詢危險值通報處理情形回覆  by Tony.Chu"

#Region "    查詢 "
    Public Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, _
                                      ByVal Status As String) As System.Data.DataSet Implements INfcServiceManager.QueryNFCNotifyMsg

        Dim tempclient As NfcServiceClient = Nothing

        Try

            tempclient = getNfcService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryNFCNotifyMsg(MID, UserId, StartDate, EndDate, Status)

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


#Region "    更新 "
    Public Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, ByVal Modified_Time As String) _
        As System.Data.DataSet Implements INfcServiceManager.UpdateNFCNotifyMsg

        Dim tempclient As NfcServiceClient = Nothing

        Try

            tempclient = getNfcService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UpdateNFCNotifyMsg(MID, ReplyMsg, Modified_User, Modified_Time)

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

End Class
