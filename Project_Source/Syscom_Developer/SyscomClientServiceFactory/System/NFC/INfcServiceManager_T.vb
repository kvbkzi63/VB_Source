Public Interface INfcServiceManager_T

    Function readUIMessage24Hr(ByVal empNO As String) As System.Data.DataSet
    Function readUIMessage24Hr(ByVal empNO As String, ByVal depNo As String) As DataSet
    Function readUIMessage(ByVal empNO As String) As System.Data.DataSet
    Function readUIMessage(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet
    Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyUI(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyUI(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyMail(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyMail(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifySMS(ByVal drEmpNo() As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifySMS(ByVal drEmpNo As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Function queryNFCNotifierByFunc(ByVal columnName As String(), ByVal columnValue As Object()) As DataSet
    Function saveNFCNotifierByFunc(ByVal inSaveData As DataSet) As Integer
    Function deleteNFCNotifierByFunc(ByVal inDeleteData As DataSet) As Integer
    Function getNotifyMessageByDeploy(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet
    Function QueryDeployByToDay(ByVal _type As String, ByVal user As String) As System.Data.DataSet
    Sub NotifyUIRigthNow(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")
    Sub NotifySMSMultiWithSubject(ByVal drEmpNo() As String, subject As String, ByVal msg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String)
    Sub NotifyMailWithEsrFormat(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String)
    Sub NotifyUIWithStartAndEndTime(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Start_Time As String, End_Time As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal Spec_Flag As String)
    Function reMarkRead(ByVal ds As System.Data.DataSet) As Integer

    Function InsertNFCNotifyMsg(ByVal data As System.Data.DataSet) As String

    Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As System.Data.DataSet
     
    Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As System.Data.DataSet
     
    Function initialNfcQueryExportUI() As System.Data.DataSet

    Function insertGroupMember(ByVal ds As System.Data.DataSet) As Integer

    Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer

    Function deleteGroupMembers(ByVal ds As System.Data.DataSet) As Integer

    Function queryGroupMember(ByVal GroupID As String) As System.Data.DataSet

    Function queryGroupMember1(ByVal GroupID As String) As System.Data.DataSet

    Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String) As Integer

    Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String) As Integer

    Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String) As Integer

    Function updateSender(ByRef ds As System.Data.DataSet) As Integer

    Function insertGroup(ByVal groupName As String, createUser As String) As Integer

    Function deleteGroup(ByVal groupID As String) As Integer

    Function queryGroupByUser(ByVal employee_Code As String) As System.Data.DataSet

    Function UpdateReplayMsg(ByVal MID As String, ByVal replayMsg As String, ByVal modifyUser As String) As Integer

    Function getNfcPhrase(ByVal ID As String) As System.Data.DataSet

#Region "2017/03/10 更新訊息結束時間(Nfc_Notify_Msg) by Jun"

    Function updateNfcNotifyMsgEndTime(ByVal ds As System.Data.DataSet) As Integer

    Function queryNfcNotifyMsgBySubject(ByVal subject As String) As System.Data.DataSet


#End Region


#Region "2017/03/21 查詢危險值通報處理情形回覆  by Tony.Chu"


    '查詢 
    Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, _
                                      ByVal Status As String) As System.Data.DataSet


    '更新
    Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, _
                                ByVal Modified_Time As String) As System.Data.DataSet


#End Region

End Interface
