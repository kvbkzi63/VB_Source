Public Interface IIccServiceManager_T

    ''' <summary>
    ''' 查詢 雲端藥歷/關懷用藥 連線記錄
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryIccConnectionHistory(Param As Dictionary(Of String, Object)) As DataSet

#Region "上傳資料維護"

    ''' <summary>
    ''' 取得初始化 ICCUploadDataQueryUI 所需資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function InitialIccUploadDataQueryUI(Param As Dictionary(Of String, Object)) As DataSet

    ''' <summary>
    ''' 查詢上傳檔
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryIccUploadData(Param As Dictionary(Of String, Object)) As DataSet

    ''' <summary>
    ''' 查詢上傳檔明細
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryIccUploadDataDetail(Param As Dictionary(Of String, Object)) As DataSet

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SaveIccUploadData(Param As Dictionary(Of String, Object), InputDs As DataSet) As DataSet

#End Region

#Region "24小時上傳比率"

    ''' <summary>
    ''' 查詢24小時上傳比率
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Query24HourUploadedRate(Param As Dictionary(Of String, Object)) As DataSet

    ''' <summary>
    ''' 取得24小時未上傳資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Query24UnuploadData(Param As Dictionary(Of String, Object)) As DataSet

#End Region

#Region "回饋資料匯入查詢"

    ''' <summary>
    ''' 將回饋檔存入資料庫
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ImportFeedbackData(Param As Dictionary(Of String, Object), InputDs As DataSet) As Int32

    ''' <summary>
    ''' 查詢當日已匯入次數
    ''' </summary>
    ''' <param name="Import_Date">匯入日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryMaxCountOfDay(Import_Date As Date) As Int32

    ''' <summary>
    ''' 查詢回饋檔資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryFeedBackData(Param As Dictionary(Of String, Object)) As DataSet

#End Region

#Region "回饋資料(用藥重複)匯入查詢"

    ''' <summary>
    ''' 將回饋檔(用藥重複)存入資料庫
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ImportFeedbackDuporderData(Param As Dictionary(Of String, Object), InputDs As DataSet) As Int32


    ''' <summary>
    ''' 查詢回饋檔(用藥重複)資料
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryFeedBackDuporderData(Param As Dictionary(Of String, Object)) As DataSet

#End Region

#Region "20090929 add by Rich, ICCCardBS"

    Function queryGetRegisterBasic(ByVal Card_Sn As String) As DataSet
    Function updateGetRegisterBasic(ByVal retValue As DataSet) As Integer
    Function insertGetRegisterBasic(ByVal retValue As DataSet) As Integer
    Function deleteWriteNewBorn(ByVal pk_Card_Sn As String) As Integer
    Function deleteUpdateICCard(ByVal pk_Card_Sn As String) As Integer
    Function deleteUnGetSeqNumber(ByVal pk_Card_Sn As String) As Integer
    Function queryGetLastSeqNum(ByVal Card_Sn As String) As DataSet
    Function updateGetLastSeqNum(ByVal Card_Sn As String, ByVal retLastSeqNum As String) As Integer
    Function insertGetLastSeqNum(ByVal Card_Sn As String, ByVal retLastSeqNum As String) As Integer
    Function queryGetCriticalIllness(ByVal Card_Sn As String) As DataSet
    Function updateGetCriticalIllness(ByVal Card_Sn As String, ByVal retRetain As String, ByVal rethospitalMark As String, ByVal retValueList As DataSet) As Integer
    Function insertGetCriticalIllness(ByVal Card_Sn As String, ByVal retRetain As String, ByVal rethospitalMark As String, ByVal retValueList As DataSet) As Integer
    Function queryGetTreatmentNoNeedHPC(ByVal Card_Sn As String) As DataSet
    Function updateGetTreatmentNoNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As DataSet, ByVal retIllnessValueList As DataSet) As Integer
    Function deleteGetTreatmentNoNeedHPC(ByVal Card_Sn As String) As Integer
    Function insertGetTreatmentNoNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As DataSet, ByVal retIllnessValueList As DataSet) As Integer
    Function queryGetTreatmentNeedHPC(ByVal Card_Sn As String) As DataSet
    Function updateGetTreatmentNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As DataSet, ByVal retIllnessValueList As DataSet) As Integer
    Function deleteGetTreatmentNeedHPC(ByVal Card_Sn As String) As Integer
    Function insertGetTreatmentNeedHPC(ByVal Card_Sn As String, ByVal retTreatmentValueList As DataSet, ByVal retIllnessValueList As DataSet) As Integer
    Function queryGetRegisterPrevent(ByVal Card_Sn As String) As DataSet
    Function updateGetRegisterPrevent(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertGetRegisterPrevent(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryGetRegisterPregnant(ByVal Card_Sn As String) As DataSet
    Function updateGetRegisterPregnant(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertGetRegisterPregnant(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryReadPrescriptMain(ByVal Card_Sn As String) As DataSet
    Function updateReadPrescriptMain(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertReadPrescriptMain(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryReadPrescriptLongTerm(ByVal Card_Sn As String) As DataSet
    Function updateReadPrescriptLongTerm(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertReadPrescriptLongTerm(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryReadPrescriptHVE(ByVal Card_Sn As String) As DataSet
    Function updateReadPrescriptHVE(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertReadPrescriptHVE(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryReadPrescriptAllergic(ByVal Card_Sn As String) As DataSet
    Function updateReadPrescriptAllergic(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertReadPrescriptAllergic(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryGetInoculateData(ByVal Card_Sn As String) As DataSet
    Function updateGetInoculateData(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertGetInoculateData(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer

    Function queryGetOrganDonate(ByVal Card_Sn As String) As DataSet
    Function updateGetOrganDonate(ByVal Card_Sn As String, ByVal retOrganDonateMark As String) As Integer
    Function insertGetOrganDonate(ByVal Card_Sn As String, ByVal retOrganDonateMark As String) As Integer
    Function deleteWriteTreatmentCode(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteTreatmentFee(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteHealthInsurance(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteEmergentTel(ByVal pk_Card_Sn As String) As Integer
    Function deleteWritePredeliveryCheckup(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteMultiPrescript(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteAllergicMedicines(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteInoculateData(ByVal pk_Card_Sn As String) As Integer
    Function deleteWriteOrganDonate(ByVal pk_Card_Sn As String) As Integer
    Function queryGetEmergentTel(ByVal Card_Sn As String) As DataSet
    Function updateGetEmergentTel(ByVal Card_Sn As String, ByVal retEmergentTel As String) As Integer
    Function insertGetEmergentTel(ByVal Card_Sn As String, ByVal retEmergentTel As String) As Integer
    Function queryGetCumulativeData(ByVal Card_Sn As String) As DataSet
    Function updateGetCumulativeData(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function insertGetCumulativeData(ByVal Card_Sn As String, ByVal retValueList As DataSet) As Integer
    Function queryGetCumulativeFee(ByVal Card_Sn As String) As DataSet
    Function updateGetCumulativeFee(ByVal Card_Sn As String, ByVal retOutpatientFeeToatl As String, ByVal retHospitalFeeToatl As String) As Integer
    Function insertGetCumulativeFee(ByVal Card_Sn As String, ByVal retOutpatientFeeToatl As String, ByVal retHospitalFeeToatl As String) As Integer
    Function queryGetBasicData(ByVal Card_Sn As String) As DataSet
    Function updateGetBasicData(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function updateGetBasicData2(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function insertGetBasicData(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function deleteGetBasicData(ByVal Card_Sn As String) As Integer
    Function insertGetBasicData2(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function queryReadPrescription(ByVal Card_Sn As String) As DataSet
    Function updateReadPrescription(ByVal Card_Sn As String, ByVal retMainValueList As DataSet, ByVal retLongTermValueList As DataSet, ByVal retHVEValueList As DataSet, ByVal retAllergicValueList As DataSet) As Integer
    Function deleteReadPrescription(ByVal Card_Sn As String) As Integer
    Function insertReadPrescription(ByVal Card_Sn As String, ByVal retMainValueList As DataSet, ByVal retLongTermValueList As DataSet, ByVal retHVEValueList As DataSet, ByVal retAllergicValueList As DataSet) As Integer
    Function deleteWritePrescription(ByVal pk_Card_Sn As String) As Integer
    Function queryGetRegisterBasic2(ByVal Card_Sn As String) As DataSet
    Function updateGetRegisterBasic2(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function insertGetRegisterBasic2(ByVal Card_Sn As String, ByVal retValue As DataSet) As Integer
    Function deleteWriteTreatmentData(ByVal pk_Card_Sn As String) As Integer

#End Region

#Region "20090929 add by Rich, ICCUploadBS"

    Function insertInsertHealth(ByVal seqNumber As String, ByVal uploadType As String, ByVal sourceType1 As String, ByVal srcSeq As String, ByVal medicalRecNo As String, ByVal mb1Value As DataSet, ByVal mb2ValueList As DataSet, ByVal createUser As String, ByVal createTime As DateTime, ByVal errorCodeMessage As String) As Integer
    Function insertInsertInoculate(ByVal seqNumber As String, ByVal uploadType As String, ByVal sourceType1 As String, ByVal srcSeq As String, ByVal medicalRecNo As String, ByVal fBabyStool As Boolean, ByVal mb1Value As DataSet, ByVal mb2ValueList As DataSet, ByVal createUser As String, ByVal createTime As DateTime, ByVal treatmentTime As DateTime) As Integer
    Function queryGetMustUploadField(ByVal treatmentCategoryId As String, ByVal dataType As String) As DataSet
    Function queryUpload(ByVal healthSnListStr As String, ByVal inoculationSnListStr As String, ByVal uploadTypeId As String, ByVal fBatch As Boolean, ByVal user As String, ByVal Config_Name_Path As String, ByVal Config_Name_Mail As String) As DataSet
    Function updateUpload(ByVal ds As DataSet, ByVal user As String) As Integer
    Function updateUpload2(ByVal ds As DataSet, ByVal UPLOAD_DATE As String, ByVal user As String) As Integer
    Function queryMust_Field_Verify(ByVal mb1ValueA01 As String, ByVal mb1ValueA23 As String) As DataSet
    Function queryField_Length_Verify(ByVal totalID As String) As DataSet
    Function querySelf_Verify(ByVal totalID As String) As DataSet
    Function queryInteract_Verify1() As DataSet
    Function queryInteract_Verify2() As DataSet
    Function queryInteract_Verify3() As DataSet
    Function queryInteract_Verify4() As DataSet
    Function queryOnlineCheck(ByVal ID As String) As DataSet

#End Region

#Region "更新處方簽章"

    Function UpdateICCOrderUploadForPrescriptionSignA79(ByVal ds As DataSet) As String
    Function UpdateICCBacterinUploadForPrescriptionSignA79(ByVal ds As DataSet) As String

#End Region

#Region "2010/10/20, add by 谷官, 取得醫療院所代碼Config"
    Function getConfigDataForICCUpload() As DataTable
#End Region

#Region "2015/09/17 病人雲端藥歷(ICC_Cloud_Drug_Patient) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢病人雲端藥歷筆數
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-17</remarks>
    Function ICCCloudDrugPatientQueryCountByChartNo(ByVal chartNo As String) As Integer

    ''' <summary>
    ''' 查詢雲端藥歷有效病人
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-18</remarks>
    Function ICCCloudDrugPatientQueryEffectivePatient() As DataSet

#End Region

#Region "2015/09/17 雲端藥歷檔(ICC_Cloud_Drugs) by ChenYu.Guo"

    ''' <summary>
    ''' 指定顯示欄位查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-17</remarks>
    Function ICCCloudDrugsQueryAssignColumnsByIdNo(ByVal idNo As String) As DataSet

#End Region

#Region "2015/10/27 IC卡必要欄位檢核維護作業(ICC_Must_Field_Verify) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifydeleteByPk(ByVal pkCode As String) As Integer

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyqueryAll() As System.Data.DataSet


    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyqueryByPK(ByRef pk_Serial_Sn As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 序號查詢(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyqueryByPKYNShow(ByRef pk_Serial_Sn As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCMustFieldVerifyqueryAllYNShow() As System.Data.DataSet

#End Region

#Region "2015/10/27 IC卡欄位長度範圍檢核維護作業(ICC_Field_Length_Verify) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCFieldLengthVerifydelete(ByVal pkCode As String) As Integer

    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCFieldLengthVerifyqueryByPK(ByRef pk_ID As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCFieldLengthVerifyinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCFieldLengthVerifyupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-27</remarks>
    Function ICCFieldLengthVerifyqueryAll() As System.Data.DataSet


#End Region

#Region "2015/10/28 IC卡線上檢核維護作業(ICC_Online_Check) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckdelete(ByVal pk_ID As String) As Integer

    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckqueryByPK(ByRef pk_ID As String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckqueryAllYNShow() As System.Data.DataSet

    ''' <summary>
    ''' ID查詢(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckqueryByPKYNShow(ByRef pk_ID As String) As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCOnlineCheckqueryAll() As System.Data.DataSet


#End Region

#Region "2015/10/28 IC卡欄位自身檢核維護作業(ICC_Self_Verify) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifydelete(ByVal pk_ID As String) As Integer

    ''' <summary>
    ''' ID查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyqueryByPK(ByRef pk_ID As String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyqueryAllYNShow() As System.Data.DataSet

    ''' <summary>
    ''' ID查詢(顯示是,否)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyqueryByPKYNShow(ByRef pk_ID As String) As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-28</remarks>
    Function ICCSelfVerifyqueryAll() As System.Data.DataSet


#End Region

#Region "2015/10/30 IC卡交叉檢核1維護作業(ICC_Interact_Verify1) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1delete(ByRef pk_Serial_Sn As String) As Integer

    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1queryByPK(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1queryAllYNShow() As DataSet

    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1insert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1update(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify1queryAll() As System.Data.DataSet


#End Region

#Region "2015/10/30 IC卡交叉檢核2維護作業(ICC_Interact_Verify2) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2delete(ByRef pk_Serial_Sn As String) As Integer

    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2queryByPK(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2queryAllYNShow() As DataSet

    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2insert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2update(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify2queryAll() As System.Data.DataSet


#End Region

#Region "2015/10/30 IC卡交叉檢核3維護作業(ICC_Interact_Verify3) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify3delete(ByRef pk_Serial_Sn As String) As Integer

    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify3queryByPK(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify3insert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify3update(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify3queryAll() As System.Data.DataSet


#End Region

#Region "2015/10/30 IC卡交叉檢核4維護作業(ICC_Interact_Verify4) by Eddie,Lu"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4delete(ByRef pk_Serial_Sn As String) As Integer

    ''' <summary>
    ''' 序號查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4queryByPK(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 查詢全部(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4queryAllYNShow() As DataSet

    ''' <summary>
    ''' 序號查詢(顯示是否)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4queryByPKYNShow(ByRef pk_Serial_Sn As String) As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4insert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4update(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function ICCInteractVerify4queryAll() As System.Data.DataSet


#End Region

#Region "2015/10/30 健保卡上傳維護(ICCUploadDataMaintainBS) by Sean.Lin"

    ''' <summary>
    ''' 作廢上傳資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2015-10-30</remarks>
    Function ICCUploadDataMaintainBSCancelData(ByVal ds As DataSet) As Integer


#End Region


#Region "取得各類名稱"

    ''' <summary>
    ''' 取得診斷名稱
    ''' </summary>
    ''' <param name="IcdCode">診斷碼</param>
    ''' <param name="IsGetEngName">True:英文, False:中文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetIcdName(IcdCode As String, IsGetEngName As Boolean) As String

    ''' <summary>
    ''' 取得醫院名稱
    ''' </summary>
    ''' <param name="HospCode">醫療院所代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetHospName(HospCode As String) As String

    ''' <summary>
    ''' 取得治療項目名稱
    ''' </summary>
    ''' <param name="TreatmentCode">治療項代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTreatmentName(TreatmentCode As String) As String

#End Region

#Region "2016/11/08 DNR註記新增與更新 Will Lin"
    Function ProcessPatientOrganDonate(ByVal ChartNo As String, ByVal DNRKindId As String, ByVal LoginUser As String) As Int32

#End Region

End Interface



