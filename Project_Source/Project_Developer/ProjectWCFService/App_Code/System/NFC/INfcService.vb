' 注意: 若變更此處的類別名稱 "INfcService"，也必須更新 Web.config 中 "INfcService" 的參考。
<ServiceContract()> _
Public Interface INfcService

    <OperationContract()> _
    Function readUIMessage24HrAuto(ByVal empNO As String) As System.Data.DataSet

    <OperationContract()> _
    Function readUIMessage24Hr(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet

    <OperationContract()> _
    Function readUIMessageAuto(ByVal empNO As String) As System.Data.DataSet

    <OperationContract()> _
    Function readUIMessage(ByVal empNO As String, ByVal depNo As String) As System.Data.DataSet

    <OperationContract()> _
    Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyAllUIExternal(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyDepUIExternal(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyUIMulti(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()>
    Sub NotifyUIMultiExternal(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyUIExternal(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, ByVal external As String)

    <OperationContract()> _
    Sub NotifyMailMulti(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String)

    <OperationContract()> _
    Sub NotifyMailMultiReply(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String)

    <OperationContract()> _
    Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifyMailReply(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifySMS(ByVal drEmpNo As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifySMSMulti(ByVal drEmpNo() As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "")

    <OperationContract()> _
    Sub NotifySMSMultiWithSubject(ByVal drEmpNo() As String, subject As String, ByVal msg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String)

    <OperationContract()> _
    Sub NotifyByFunctionNo(ByVal inSystemNo As String, ByVal inSubSystemNo As String, ByVal inTaskNo As String, ByVal inFunctionNo As String, _
                                 ByVal inMsgTitle As String, ByVal inMsgLevel As String, ByVal inMsgContent As String)

    <OperationContract()> _
    Function queryNFCNotifierByFunc(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

    <OperationContract()> _
    Function saveNFCNotifierByFunc(ByVal inSaveData As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function deleteNFCNotifierByFunc(ByVal inDeleteData As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function getNotifyMessageByDeploy(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

    <OperationContract()> _
    Function QueryDeployByToDay(ByVal _type As String, ByVal user As String) As System.Data.DataSet

    <OperationContract()> _
    Sub NotifyUIExternalRightNow(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal external As String)

    <OperationContract()> _
    Sub NotifyMailWithEsrFormat(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String)

    <OperationContract()> _
    Sub NotifyUIWithStartAndEndTime(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Start_Time As String, End_Time As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal SpecFlag As String)

    <OperationContract()> _
    Function reMarkRead(ByVal ds As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function InsertNFCNotifyMsg(ByVal data As System.Data.DataSet) As String

    <OperationContract()> _
    Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As System.Data.DataSet


    <OperationContract()> _
    Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As System.Data.DataSet
 
    <OperationContract()> _
    Function initialNfcQueryExportUI() As System.Data.DataSet

    <OperationContract()> _
    Function insertGroupMember(ByVal ds As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer

    <OperationContract()> _
    Function deleteGroupMembers(ByVal ds As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function queryGroupMember(ByVal GroupID As String) As System.Data.DataSet

    <OperationContract()> _
    Function queryGroupMember1(ByVal GroupID As String) As System.Data.DataSet

    <OperationContract()> _
    Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String) As Integer

    <OperationContract()> _
    Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String) As Integer

    <OperationContract()> _
    Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String) As Integer

    <OperationContract()> _
    Function updateSender(ByRef ds As System.Data.DataSet) As Integer

    <OperationContract()> _
    Function insertGroup(ByVal groupName As String, createUser As String) As Integer

    <OperationContract()> _
    Function deleteGroup(ByVal groupID As String) As Integer

    <OperationContract()> _
    Function queryGroupByUser(ByVal employee_Code As String) As System.Data.DataSet

    <OperationContract()> _
    Function UpdateReplayMsg(ByVal MID As String, ByVal replayMsg As String, ByVal modifyUser As String) As Integer

    <OperationContract()> _
    Function getNfcPhrase(ByVal ID As String) As System.Data.DataSet

#Region "2017/03/10 更新訊息結束時間(Nfc_Notify_Msg) by Jun"

    ''' <summary>
    ''' 更新訊息結束時間
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    <OperationContract()> _
    Function updateNfcNotifyMsgEndTime(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 以主旨取得通知訊息
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    <OperationContract()> _
    Function queryNfcNotifyMsgBySubject(ByVal subject As String) As System.Data.DataSet

#End Region

#Region "2017/03/21 查詢危險值通報處理情形回覆  by Tony.Chu"

    ''' <summary>
    ''' 查詢 
    ''' </summary>
    ''' <param name="MID" > 編號</param>
    ''' <param name="UserId" >查詢接收人員</param>
    ''' <param name="StartDate" >查詢發送日期(起)</param>
    ''' <param name="EndDate" >查詢發送日期(迄)</param>
    ''' <param name="Status" >查詢類別</param>
    <OperationContract()> _
    Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, _
                                      ByVal Status As String) As System.Data.DataSet


    
    ''' <summary>
    ''' 查詢 查詢危險值通報處理情形回覆
    ''' </summary>
    ''' <param name="MID" >編號</param>
    ''' <param name="ReplyMsg" >處理情形</param>
    ''' <param name="Modified_User" >處理人員</param>
    ''' <param name="Modified_Time" >處理時間</param>
    <OperationContract()> _
    Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, ByVal Modified_Time As String) As System.Data.DataSet

#End Region

End Interface
