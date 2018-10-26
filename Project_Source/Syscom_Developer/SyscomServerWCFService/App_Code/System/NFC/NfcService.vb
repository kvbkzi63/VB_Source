Imports Syscom.Comm.EXP
Imports Syscom.Server.NFC
Imports Syscom.Server.CMM
' 注意: 若變更此處的類別名稱 "NfcService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "NfcService" 的參考。
Public Class NfcService
    Implements INfcService

    Public Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As System.Data.DataSet Implements INfcService.QueryNFCNotifyMsgByCond
        Try
            Return NFCDelegate.getInstance.QueryNFCNotifyMsgByCond(StartSendDate, EndSendDate, Fun_Function_No, Type, Level, Status, Recipient, sendUser)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function initialNfcQueryExportUI() As System.Data.DataSet Implements INfcService.initialNfcQueryExportUI
        Try
            Return NFCDelegate.getInstance.initialNfcQueryExportUI()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function


    Public Function InsertNFCNotifyMsg(ByVal data As System.Data.DataSet) As String Implements INfcService.InsertNFCNotifyMsg
        Try
            Return NFCDelegate.getInstance.InsertNFCNotifyMsg(data)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As System.Data.DataSet Implements INfcService.QueryNFCNotifyMsgByUserId
        Try
            Return NFCDelegate.getInstance.QueryNFCNotifyMsgByUserId(UserId)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function readUIMessage24HrAuto(ByVal empNO As String) As System.Data.DataSet Implements INfcService.readUIMessage24HrAuto
        Try
            Return NFCDelegate.getInstance.readUIMessage24Hr(empNO)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function readUIMessage24Hr(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet Implements INfcService.readUIMessage24Hr
        Try
            Return NFCDelegate.getInstance.readUIMessage24Hr(empNO, depNo)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function readUIMessageAuto(ByVal empNO As String) As System.Data.DataSet Implements INfcService.readUIMessageAuto
        Try
            Return NFCDelegate.getInstance.readUIMessage(empNO)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function readUIMessage(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet Implements INfcService.readUIMessage
        Try
            Return NFCDelegate.getInstance.readUIMessage(empNO, depNo)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyAllUI
        Try
            NFCDelegate.getInstance.NotifyAllUI(subject, msg, startTime, endTime)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyAllUIExternal(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyAllUIExternal
        Try
            NFCDelegate.getInstance.NotifyAllUI(subject, msg, startTime, endTime, external)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyDepUI
        Try
            NFCDelegate.getInstance.NotifyDepUI(empDept, subject, msg, startTime, endTime)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyDepUIExternal(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyDepUIExternal
        Try
            NFCDelegate.getInstance.NotifyDepUI(empDept, subject, msg, startTime, endTime, external)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyUIMulti(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyUIMulti
        Try
            NFCDelegate.getInstance.NotifyUI(drEmpNo, subject, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyUIMultiExternal(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyUIMultiExternal
        Try
            NFCDelegate.getInstance.NotifyUI(drEmpNo, subject, msg, external)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyUI
        Try
            NFCDelegate.getInstance.NotifyUI(drEmpNo, subject, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyUIExternal(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, ByVal external As String) Implements INfcService.NotifyUIExternal
        Try
            NFCDelegate.getInstance.NotifyUI(drEmpNo, subject, msg, external)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyMailMulti(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String) Implements INfcService.NotifyMailMulti
        Try
            NFCDelegate.getInstance.NotifyMail(EmpMail, subject, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyMailMultiReply(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String) Implements INfcService.NotifyMailMultiReply
        Try
            NFCDelegate.getInstance.NotifyMail(EmpMail, subject, msg, replymsg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyMail
        Try
            NFCDelegate.getInstance.NotifyMail(EmpMail, subject, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyMailReply(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifyMailReply
        Try
            NFCDelegate.getInstance.NotifyMail(EmpMail, subject, msg, replymsg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifySMSMulti(ByVal drEmpNo() As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifySMSMulti
        Try
            NFCDelegate.getInstance.NotifySMS(drEmpNo, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifySMSMultiWithSubject(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String) Implements INfcService.NotifySMSMultiWithSubject
        Try
            NFCDelegate.getInstance.NotifySMSMultiWithSubject(drEmpNo, subject, msg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, SpecFlag)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifySMS(ByVal drEmpNo As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "") Implements INfcService.NotifySMS
        Try
            NFCDelegate.getInstance.NotifySMS(drEmpNo, msg)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Sub NotifyByFunctionNo(ByVal inSystemNo As String, ByVal inSubSystemNo As String, ByVal inTaskNo As String, ByVal inFunctionNo As String, _
                                 ByVal inMsgTitle As String, ByVal inMsgLevel As String, ByVal inMsgContent As String) Implements INfcService.NotifyByFunctionNo
        Try
            NFCDelegate.getInstance.NotifyByFunctionNo(inSystemNo, inSubSystemNo, inTaskNo, inFunctionNo, inMsgTitle, inMsgLevel, inMsgContent)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Function queryNFCNotifierByFunc(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements INfcService.queryNFCNotifierByFunc
        Try
            Return NFCDelegate.getInstance.queryNFCNotifierByFunc(columnName, columnValue)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function saveNFCNotifierByFunc(ByVal inSaveData As System.Data.DataSet) As Integer Implements INfcService.saveNFCNotifierByFunc
        Try
            Return NFCDelegate.getInstance.saveNFCNotifierByFunc(inSaveData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deleteNFCNotifierByFunc(ByVal inDeleteData As System.Data.DataSet) As Integer Implements INfcService.deleteNFCNotifierByFunc
        Try
            Return NFCDelegate.getInstance.deleteNFCNotifierByFunc(inDeleteData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function getNotifyMessageByDeploy(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements INfcService.getNotifyMessageByDeploy
        Try
            Dim nfc As NFCDelegate = NFCDelegate.getInstance
            Return nfc.getNotifyMessageByDeploy(columnName, columnValue)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function QueryDeployByToDay(ByVal _type As String, ByVal user As String) As System.Data.DataSet Implements INfcService.QueryDeployByToDay
        Try
            Dim nfc As NFCDelegate = NFCDelegate.getInstance
            Return nfc.QueryDeployByToDay(_type, user)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 立即顯示訊息時窗
    ''' </summary>
    ''' <param name="drEmpNo">通知人員</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks></remarks>
    Public Sub NotifyUIExternalRightNow(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String) Implements INfcService.NotifyUIExternalRightNow
        Try
            NFCDelegate.getInstance.NotifyUIRigthNow(drEmpNo, subject, msg, external)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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
    Public Sub NotifyMailWithEsrFormat(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String) Implements INfcService.NotifyMailWithEsrFormat
        Try
            NFCDelegate.getInstance.NotifyMailWithEsrFormat(EmpMail, subject, msg, replymsg, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, SpecFlag)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
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

    Public Sub NotifyUIWithStartAndEndTime(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Start_Time As String, End_Time As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String) Implements INfcService.NotifyUIWithStartAndEndTime
        Try
            NFCDelegate.getInstance.NotifyUIWithStartAndEndTime(drEmpNo, subject, msg, Start_Time, End_Time, App_System_No, Sub_System_No, Tsk_Task_no, Fun_Function_No, CreateUser, SpecFlag)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Sub

    Public Function reMarkRead(ByVal ds As System.Data.DataSet) As Integer Implements INfcService.reMarkRead
        Try
            Return NFCDelegate.getInstance.reMarkRead(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#Region "   群組維護"
    ''' <summary>
    ''' 查詢訊息群組成員
    ''' </summary>
    ''' <param name="GroupID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGroupMember(ByVal GroupID As String) As System.Data.DataSet Implements INfcService.queryGroupMember
        Try
            Return NFCDelegate.getInstance.queryGroupMember(GroupID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 查詢訊息群組成員
    ''' </summary>
    ''' <param name="GroupID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGroupMember1(ByVal GroupID As String) As System.Data.DataSet Implements INfcService.queryGroupMember1
        Try
            Return NFCDelegate.getInstance.queryGroupMember1(GroupID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    Public Function insertGroupMember(ByVal ds As System.Data.DataSet) As Integer Implements INfcService.insertGroupMember
        Try
            Return NFCDelegate.getInstance.insertGroupMember(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer Implements INfcService.deleteGroupMember
        Try
            Return NFCDelegate.getInstance.deleteGroupMember(groupID, employeeCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deleteGroupMembers(ByVal ds As System.Data.DataSet) As Integer Implements INfcService.deleteGroupMembers
        Try
            Return NFCDelegate.getInstance.deleteGroupMembers(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String) As Integer Implements INfcService.deleteSenderByGroupTxId
        Try
            Return NFCDelegate.getInstance.deleteSenderByGroupTxId(Group_Tx_Id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function


    Public Function updateSender(ByRef ds As System.Data.DataSet) As Integer Implements INfcService.updateSender
        Try
            Return NFCDelegate.getInstance.updateSender(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    '新增群組名稱
    Public Function insertGroup(ByVal groupName As String, createUser As String) As Integer Implements INfcService.insertGroup
        Try
            Return NFCDelegate.getInstance.insertGroup(groupName, createUser)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    '刪除群組名稱
    Public Function deleteGroup(ByVal groupID As String) As Integer Implements INfcService.deleteGroup
        Try
            Return NFCDelegate.getInstance.deleteGroup(groupID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    '查詢群組名稱By User
    Public Function queryGroupByUser(ByVal employee_Code As String) As System.Data.DataSet Implements INfcService.queryGroupByUser
        Try
            Return NFCDelegate.getInstance.queryGroupByUser(employee_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "   更新IP and 回饋"
    ''' <summary>
    ''' 更新讀取IP
    ''' </summary>
    ''' <param name="mid"></param>
    ''' <param name="call_IP"></param>
    ''' <param name="modified_User"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String) As Integer Implements INfcService.UpdateIP
        Try
            Return NFCDelegate.getInstance.UpdateIP(mid, call_IP, modified_User)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 更新 回饋="O"
    ''' </summary>
    ''' <param name="mid"></param>
    ''' <param name="modified_User"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String) As Integer Implements INfcService.UpdateSpecFlag
        Try
            Return NFCDelegate.getInstance.UpdateSpecFlag(mid, modified_User)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function UpdateReplayMsg(ByVal mid As String, ByVal replayMsg As String, ByVal modifyUser As String) As Integer Implements INfcService.UpdateReplayMsg
        Try
            Return NFCDelegate.getInstance.UpdateReplayMsg(mid, replayMsg, modifyUser)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "   取得訊息片語"

    Public Function getNfcPhrase(ByVal ID As String) As System.Data.DataSet Implements INfcService.getNfcPhrase
        Try
            Return NFCDelegate.getInstance.getNfcPhrase(ID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function
#End Region

#Region "2017/03/10 更新訊息結束時間(Nfc_Notify_Msg) by Jun"

#Region "     更新訊息結束時間 "
    ''' <summary>
    ''' 更新訊息結束時間
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function updateNfcNotifyMsgEndTime(ByVal ds As System.Data.DataSet) As Integer Implements INfcService.updateNfcNotifyMsgEndTime

        Try

            Dim tempDelegate As NFCDelegate = NFCDelegate.getInstance

            Return tempDelegate.updateNfcNotifyMsgEndTime(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以主旨取得通知訊息 "
    ''' <summary>
    ''' 以主旨取得通知訊息
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function queryNfcNotifyMsgBySubject(ByVal subject As String) As System.Data.DataSet Implements INfcService.queryNfcNotifyMsgBySubject

        Try

            Dim tempDelegate As NFCDelegate = NFCDelegate.getInstance

            Return tempDelegate.queryNfcNotifyMsgBySubject(subject)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region


#Region "2017/03/21 查詢危險值通報處理情形回覆  by Tony.Chu"

#Region "     查詢 "

    Public Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, _
                                      ByVal Status As String) As System.Data.DataSet Implements INfcService.QueryNFCNotifyMsg

        Try
            Dim tempDelegate As NFCDelegate = NFCDelegate.getInstance

            Return tempDelegate.QueryNFCNotifyMsg(MID, UserId, StartDate, EndDate, Status)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region




#Region "     更新 "

    Public Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, ByVal Modified_Time As String) _
        As System.Data.DataSet Implements INfcService.UpdateNFCNotifyMsg

        Try
            Dim tempDelegate As NFCDelegate = NFCDelegate.getInstance

            Return tempDelegate.UpdateNFCNotifyMsg(MID, ReplyMsg, Modified_User, Modified_Time)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region

#End Region

End Class
