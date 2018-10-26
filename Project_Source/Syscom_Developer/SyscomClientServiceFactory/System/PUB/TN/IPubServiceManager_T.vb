Imports Syscom.Comm.LOG

Public Interface IPubServiceManager_T

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"
    Function queryPUBDisIdentityAll() As DataSet

#End Region

#Region "20150903 PUBContractUI 合約機構基本檔 add by Will,Lin"
    Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet
#End Region

#Region "20150812 【ExportList】 add by Will,Lin"
    '動態查詢報表資訊
    Function PubExportQueryData(ByVal sql As String, ByVal getConnection As String) As DataSet
    '查詢欄位初始化設定
    Function PubExportListDataQuery(ByVal Report_id As String) As DataSet

#End Region

#Region "20150810 【共用查詢平台】相關method , add by Will,Lin"
    '新增
    Function PUBExportInsertData(ByVal ds As DataSet) As Integer
    '修改
    Function PUBExportUpdateData(ByVal Report_Id As String, ByVal ds As DataSet) As Integer
    '刪除
    Function PUBExportDeleteData(ByVal Report_Id As String) As Integer
    '查詢主表單
    Function PUBExportMasterDataQuery(ByVal Report_id As String) As DataSet

    '查詢表身
    Function PUBExportDetailDataQuery(ByVal Report_id As String) As DataSet

    '新增後查詢
    Function PUBExportQueryForInsert(ByVal Report_id As String) As DataSet

#End Region

#Region "20090618 取得系統時間  , add by James"
    Function GetSystemNowTime() As Date
#End Region

#Region "20090720 PUBConfig , Added by James"
    Function queryPubConfigWhereConfigNameEquals(ByVal ConfigName As String) As System.Data.DataSet
    Function queryAllPUBConfig() As System.Data.DataSet
    Function updatePUBConfig(ByVal ds As System.Data.DataSet) As Integer
    Function queryPUBConfigWhereConfigNameIn(ByVal configName As String) As DataSet
#End Region

#Region "系統版本更新記錄檔"
    Function DynamicQueryByColumn(ByRef queryData As DataSet) As System.Data.DataSet
    Function insertPUBSystermVersion(ByVal queryData As System.Data.DataSet) As Integer
#End Region

#Region "2013/09/25 醫師檔相關作業(PUBDOCTORBO_E1) by Sean.Lin"

    ''' <summary>
    ''' 查詢醫師檔作為CBO 資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Function PUBDOCTORBOE1queryForCbo(ByVal SectionCode As String) As DataSet

    ''' <summary>
    ''' 進行醫師驗證
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Function queryDoctorFromEmployee(ByVal Employee_Code As String, ByVal Doctor_Code As String) As DataSet

#End Region

#Region "20090820 add by Rich, PUBPartBO_E1"

    Function queryPubPartByKey(ByVal regDate As String) As System.Data.DataSet
#End Region

#Region "20090820 add by James, PUBSysCodeBO_E1"

    Function queryPUBSyscodePKey(ByVal inTypeId As String, ByVal inCodeId As String) As System.Data.DataSet
    Function queryPUBSysCodebyTypeId(ByVal TypeId As String) As System.Data.DataSet
#End Region

#Region "20090820 add by James, 員工資料相關查詢(PUBEmployee)"

    Function queryEmployeeByDate(ByVal EmployeeCode As String, ByVal JudgeDate As String) As DataSet

    Function DoPubAction(ByVal ds As DataSet) As DataSet

#End Region

#Region "20090820 add by Rich, PubPatientBO_E1"

    Function queryPubPatientByIdno(ByVal Idno As String) As System.Data.DataSet

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-09</remarks>
    Function queryPubPatientByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet

#End Region

#Region "20090820 add by James, PUBPatientSevereDiseaseBO_E1"

    Function queryPubPatientSevereDiseaseByKey(ByVal Chart_No As String) As System.Data.DataSet
#End Region

#Region "20090820 add by James, PUBPatientDisabilityBO_E1"

    Function queryPubPatientDisabilityByKey(ByVal Chart_No As String) As System.Data.DataSet
#End Region

#Region "20090820 add by James, PUBPatientFlagBO_E1"

    Function queryPubPatientFlagByKey(ByVal Chart_No As String) As System.Data.DataSet
#End Region

#Region "2016/06/10 add by Lits Pub_IP_Config 維護"
    Function insertPubIPConfig(ByVal ds As System.Data.DataSet) As Integer
    Function updatePubIPConfig(ByVal ds As System.Data.DataSet) As Integer
    Function deletePubIPConfig(ByVal ip As System.String) As Integer
    Function queryPubIPConfig(ByVal ip As System.String) As DataSet
    Function queryStationByIP(ByVal ip As String) As DataSet
#End Region

#Region "2012/04/06 add by Alan 取得Term_Code設定資料"
    Function queryStationByTermCode(ByVal inTermCode As String) As DataSet
#End Region

#Region " 負責寫前端程式所有 log 紀錄"

    Sub doClientLog(ByVal level As LOGDelegate.LogLevel, ByVal callerType As String, ByVal methodName As String, ByVal message As String)

#End Region

#Region "2014/09/01 員工資料相關查詢(PUBEmployee) by Sean.Lin"

    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Function PUBEmployeequeryEmployeeByEmpCode(ByVal EmployeeCode As String) As DataSet

    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Function PUBEmployeequeryEmployeeByEmpCodeAndDate(ByVal EmployeeCode As String, ByVal JudgeDate As Date) As DataSet


#End Region

#Region "2014/11/04 參數設定(PubConfig) by Sean.Lin"

    ''' <summary>
    ''' 查詢By參數設定名稱
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigQueryByConfigName(ByVal configName As String) As DataSet

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigqueryByPK(ByRef pk_Config_Name As System.String) As DataSet

    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigdelete(ByRef pk_Config_Name As System.String) As Integer

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfiginsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigqueryAll() As System.Data.DataSet

    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Function PubConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet


#End Region

#Region "2014/11/04 系統參數設定維護(PubConfig) by Alan.Tsai"

    ''' <summary>
    ''' 根據系統參數名稱查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Function queryPUBConfigLikePKey(ByVal inConfigName As String) As DataSet

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Function qureyPUBConfigAll() As DataSet

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Function savePUBConfig(ByVal inSaveDs As DataSet) As DataSet

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Function deletePUBConfig(ByVal inDeleteDs As DataSet) As DataSet


#End Region

#Region "2014/11/08 公用類別代碼維護(PubSyscodeType) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Function queryPUBSyscodeTypeLikePKey(ByVal inTypeId As String) As DataSet

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Function qureyPUBSyscodeTypeAll() As DataSet

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Function savePUBSyscodeType(ByVal inSaveDs As DataSet) As DataSet

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Function deletePUBSyscodeType(ByVal inDeleteDs As DataSet) As DataSet


#End Region

#Region "2014/11/09 公用代碼維護(PubSyscode) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼、公用代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function queryPUBSyscodeLikePKey(ByVal inTypeId As String, ByVal inCodeId As String) As DataSet

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function qureyPUBSyscodeAll() As DataSet

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function savePUBSyscode(ByVal inSaveDs As DataSet) As DataSet

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function deletePUBSyscode(ByVal inDeleteDs As DataSet) As DataSet


#End Region

#Region "2014/11/09 醫事機構維護(PubSyscode) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別、生效日期與醫院代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function queryPUBHospitalLikePKey(ByVal inLanguageTypeId As String, ByVal inEffectDate As String, ByVal inHospitalCode As String) As DataSet

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function qureyPUBHospitalAll() As DataSet

    ''' <summary>
    ''' 畫面初始化資料查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-10</remarks>
    Function initPubHospital() As DataSet

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function savePUBHospital(ByVal inSaveDs As DataSet) As DataSet

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Function deletePUBHospital(ByVal inDeleteDs As DataSet) As DataSet


#End Region

#Region "2014/12/02 by Lits 取得員工全部資料"
    ''' <summary>
    ''' 取得員工全部資料 
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    Function queryEmployeeALL(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

    ''' <summary>
    ''' 取得員工全部資料 By Dept
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    Function queryEmployeeByDept(ByVal dept As String) As DataSet

#End Region

#Region "20090415 假日檔維護 add by James"

    Function queryPubHolidayAll() As Data.DataSet
    Function queryPubHolidayByKey(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet
    Function insertPubHoliday(ByVal dsParam As DataSet) As Integer
    Function deletePubHoliday(ByVal holidayDate As String, ByVal subSysCode As String) As Integer
    Function updatePubHoliday(ByVal dsParam As DataSet) As Integer
    Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal datestrHolidayYear As Date, ByVal strSubSystemCode As String) As DataSet

#End Region

#Region "20100128 add by Rich, PUBOrderPriceBO_E1"

    Function queryOrderPriceDataByOrder(ByVal OrderCode As String) As DataTable

#End Region

#Region "20090511 科室資料維護 add by James"
    'Function queryPUBDepartmentAll_B() As DataSet
    'Function queryPUBDepartmentByKey(ByVal deptCode As String) As DataSet
    Function queryPUBDepartmentAll_D() As DataSet

    Function queryPUBDepartmentBySmallDept() As DataSet

    'Function queryPUBDepartmentAllDept() As DataSet

    Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As DataSet
#End Region

#Region "2009/07/20, Add By 谷官, 收退費(OPCReceiptUI)"
    Function getEndDateForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String) As DataTable
    Function getIcdCodeForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String, ByVal IcdCodeDT As DataTable) As DataTable
    'Function PPatientUIInit() As DataSet
    Function queryPubChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet
    Function queryPUBSheet() As DataSet

    Function queryPUBSheetSheetSheetCodeByDeptCode(ByVal DeptCode As String) As DataSet

    Function getPatientDisabilityRecordForReceiptUI(ByVal ChartNo As String) As DataTable
    Function insertPatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer
    Function updatePatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer
    Function getMaxPatientDisabilityNoForReceiptUI(ByVal ChartNo As String) As Integer

#End Region

#Region "由表單代碼 Sheet_Code取得表單資訊"

    Function queryPubSheetBySheetCode(ByVal SheetCode As String) As DataSet

#End Region

#Region "20090602 add by James 身份別連動設定"

    Function queryPUBSysCode(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False) As DataSet
    'Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet
    'Function queryPUBDisIdentityAll() As DataSet
    'Function queryPUBContractAll() As DataSet

#End Region

#Region "20090803 add by Rich, PUBSysCodeBO_E1"

    Function queryPUBSysCodeInCond(ByVal TypeId As String) As DataSet

#End Region

#Region "2010/01/20, Add By 谷官, 健保資料設定(OPCSetHealthInsuData)"
    Function getMedicalPartAmt(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal) As DataTable
    Function getPubOrderPriceDataForOPCAPI(ByVal keyValue As DataSet) As DataTable
#End Region

#Region "2012-02-14 PUBPatientAllergyNew相關程式"
    Function InitUI() As DataSet

    Function Find_AllergyRecord(ByVal Chart_No As String) As DataTable

    Function Find_PatientData(ByVal Chart_No As String) As DataTable

    Function Find_AllergyHistory(ByVal Chart_No As String) As DataTable

    Sub AddNew_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Create_Time As String, ByVal Create_User As String)


    Function AddNew_AllergyRecord_NKDA(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String

    Function AddNew_AllergyRecord_OTHER(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String

    Sub Modify_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Modified_User As String, ByVal Modified_Time As String)

    Sub Delete_AllergyRecord(ByVal Chart_No As String, ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Cancel As String, ByVal Modified_User As String, ByVal Modified_Time As String, ByVal Allergy_no As String)

    Sub Reset_IsFromICCard(ByVal Chart_No As String, ByVal Drug1 As String, ByVal Drug2 As String, ByVal Drug3 As String)
#End Region

#Region "20100226 動態查詢 by Jen"
    Function dynamicQuery(ByVal sqlStr As String) As DataSet

#End Region



#Region "2013-03-21 add by 嚴崑銘"
    Function GetPubConfigValue(ByVal configName As String) As String
    Function IsPubConfigActive(ByVal configName As String) As Boolean
    Function CheckIdNo(ByVal strIdNo As String) As Integer
#End Region

#Region "醫令自費與健保價格查詢"
    Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet

#End Region
#Region "常用一般診斷查詢"
    Function queryPUBDiseaseByFavor(ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet
    Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet
#End Region

#Region "2009/09/18, Add By Alan, 一般醫令查詢"
    Function queryPUBOrderByCond(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal Specimen As String, ByVal Body_Site As String) As DataSet
    Function queryPUBOrderByLanguage(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String) As DataSet
    Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String) As DataSet
    Function queryPUBOrderIsDC(ByVal inOrderCode As String) As DataSet
#End Region

#Region "20100730 add by Rich, OPHPhraseBO_E1"

    Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String) As DataSet

#End Region

#Region "20100825 add by Rich, 非PUB動態SQL"

    ''' <summary>
    ''' 非PUB動態SQL
    ''' </summary>
    ''' <param name="sqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RuleDynamicQueryNotPub(ByRef sqlString As String) As System.Data.DataSet

#End Region

#Region "2013/07/22 955236 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥"

    ''' <summary>
    ''' 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Outpatient_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(ByVal Chart_No As String, ByVal Outpatient_Sn As String) As DataSet

#End Region

#Region "同類藥檢核"

    ''' <summary>
    ''' 同類藥檢核查詢
    ''' </summary>
    ''' <param name="Phamarcy12code">成大十二碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QuerySameKineMedicine(ByVal Phamarcy12code As String) As DataSet

#End Region

#Region "化療藥檢核 by markwu"
    ''' <summary>
    ''' 程式功能：化療藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String) As DataSet
    ''' <summary>
    ''' 程式功能：化療藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function EMRMedicineRecordRuleQuery2(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String, ByVal end_date As String) As DataSet
#End Region

    ''' <summary>
    ''' Insert OPH_Alert_Record
    ''' </summary>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function InsertOPH_Alert_Record(ByVal InputDs As DataSet) As Int32

#Region "20090819 add by Rich, 檢核規則 PUBRuleBO_E1"

    Function RuleQueryAll() As System.Data.DataSet
    Function RuleInsert(ByVal ds As System.Data.DataSet) As Integer
    Function RuleDynamicQuery(ByRef sqlString As String) As System.Data.DataSet
    Function RuleDynamicQueryPCS(ByRef sqlString As String) As System.Data.DataSet
    Function RuleDynamicQueryForEis(ByRef sqlString As String) As System.Data.DataSet
    Function RuleDynamicQueryEmr(ByVal sqlString As String) As System.Data.DataSet
    Function RuleDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet
    Function RuleQueryByPK(ByRef pk_Rule_Code As System.String) As System.Data.DataSet
    Function RuleDelete(ByRef pk_Rule_Code As System.String) As Integer
    Function RuleUpdate(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "20090819 add by Rich, 檢核規則 PUBRuleDetailBO_E1"

    Function RuleDetailQueryAll() As System.Data.DataSet
    Function RuleDetailInsert(ByVal ds As System.Data.DataSet) As Integer
    Function RuleDetailDynamicQuery(ByRef sqlString As String) As System.Data.DataSet
    Function RuleDetailDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet
    Function RuleDetailQueryByPK(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As System.Data.DataSet
    Function RuleDetailDelete(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As Integer
    Function RuleDetailUpdate(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "20091216 add by Rich, PUBRuleBS"

    Function getCallFormDS(ByVal RuleCode As String) As System.Data.DataSet
    Function RuleExpressionStrQuery(ByVal RuleCode As String) As System.Data.DataSet
    Function RuleDetailQuery(ByVal RuleCode As String) As System.Data.DataSet
    Function getCheckRuleDS(ByVal RuleCode As String, ByVal ValueData As String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String) As System.Data.DataSet
    Function RuleClassQuery(ByVal RuleCode As String, ByVal ValueData As String) As System.Data.DataSet
    Function RuleQueryByCond(ByRef pk_Rule_Code As System.String, ByVal Source As String, ByVal Medical_Identity_Id As String, ByVal Base_Date As String) As System.Data.DataSet
    Function RuleCodeTransfer1(ByVal OrderCode As String) As System.Data.DataSet
    Function RuleCodeTransfer2(ByVal Insu_Code As String) As System.Data.DataSet
    Function queryItemName(ByVal Item_Code As String) As System.Data.DataSet
    Function queryRuleValueData(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
    Function queryClassAndField(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
    Function queryRuleCode(ByVal Item_Code As String, ByVal Value_Data As String, ByVal Base_Date As String) As System.Data.DataSet

    ''' <summary>
    ''' 搜尋歷史醫令
    ''' </summary>
    ''' <param name="Medical_Sn">就醫序號</param>
    ''' <param name="SystemType">系統歸屬 {O}門診 or {E}急診 or {I}住院</param>
    ''' <param name="Location">C,P,S</param>
    ''' <returns>所有歷史醫令的資料集</returns>
    ''' <remarks>by Rich on 2012-05-30</remarks>
    Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet

#End Region

#Region "成大碼轉健保碼"

    ''' <summary>
    ''' 成大碼轉健保碼
    ''' </summary>
    ''' <param name="OrderCodeDS"></param>
    ''' <param name="BasicDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryInsuCodeByOrderCode(ByVal OrderCodeDS As DataSet, Optional ByVal BasicDate As String = "") As DataSet

#End Region

#Region "2015/06/01 單張報表描述檔維護(Pub_Report_Desc) by ChenYu.Guo"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubReportDescdelete(ByRef pk_Report_ID As System.String) As Integer

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubReportDescQueryByLikeColumn(ByRef reportID As String, ByRef reportName As String, ByRef SystemCode As String) As DataSet

    ''' <summary>
    ''' QueryByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubReportDescQueryByPK(ByRef pk_Report_ID As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubReportDescinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubReportDescupdate(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2015/06/01 報表列印記錄檔查詢作業(Pub_Print_Record) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Function PubPrintRecordQueryPrintRecord(ByRef reportID As String, ByRef reportName As String, ByRef createUse As String, ByRef createTime As String, ByRef endTime As String, ByRef printIP As String) As DataSet

    ''' <summary>
    ''' 將列印報表、預覽報表的資料 新增至 PUB_Print_Record
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Function insertRPTPrintClient(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2015-06-29 遠端報表列印 by Lits ADD"
    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryReportConfigByReportId(ByVal inReportId As String) As DataSet

    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryReportMode(ByVal inReportId As String) As String

    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="inStationNo"></param>
    ''' <param name="inTermCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryReportAllConfig(ByVal inReportId As String, ByVal inStationNo As String, ByVal inTermCode As String) As DataSet

    ''' <summary>
    ''' 取得報表列印資訊
    ''' </summary>
    ''' <param name="repprtID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getReportInfo(ByVal repprtID As String, ByVal printerType As String, ByVal printerCond As String) As DataSet

#End Region

#Region "2015/07/10 報表維護資料(PUB_Print_Config 與 PUB_Report_Desc) by Kaiwen,Hsiao"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfiginsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigupdate(ByVal dsPubPrintConfig As System.Data.DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigdelete(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As Integer

    ''' <summary>
    ''' QueryByPK
    ''' </summary>
    Function PUBPrintConfigQueryByPK(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigqueryAll() As System.Data.DataSet

    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

    ''' <summary>
    ''' 報表列印記錄檔查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigQueryByLikeColumn(ByVal Report_Id As String, ByVal Print_Type As String, ByVal Print_Cond As String, ByVal Printer_Name As String, ByVal Paper_Size As String) As DataSet

    ''' <summary>
    ''' 新增 PUB_Print_Config、PUB_Report_Desc 資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBPrintConfigBSInsert(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer


#End Region

#Region "2015/07/15 大分科所屬細分科統計(PUB_Department) by ChenYu.Guo"

    ''' <summary>
    ''' 大分科所屬細分科統計
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-07-15</remarks>
    Function queryPUBDepartmentCount() As DataSet


#End Region

#Region "2015/07/14 病人身高體重登記作業(Pub_Patient_BodyRecord) by Sharon.Du"

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Function PubPatientBodyRecorddelete(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As Integer

    ''' <summary>
    ''' 以PK查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Function PubPatientBodyRecordqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As System.Data.DataSet

    ''' <summary>
    ''' 以病歷號、來源別、登錄單位查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Overloads Function PubPatientBodyRecordqueryPubPatientBodyrecordByCond(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, ByVal ChartNo As String) As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Function PubPatientBodyRecordinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Function PubPatientBodyRecordupdate(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2015/07/27 醫令主檔(PubOrder) by Sean.Lin"

    ''' <summary>
    ''' 查詢醫令項目基本檔   
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <param name="dc">Y、N，空字串表示不判斷</param>
    ''' <param name="judgeDate" >yyyy/MM/dd，空字串表示不判斷，判斷日當天仍有效的Order</param>
    ''' <remarks>by Sean.Lin on 2015-07-27</remarks>
    Function PubOrderqueryByOrderCode(ByVal strOrderCode As String, ByVal dc As String, ByVal judgeDate As String) As DataSet


#End Region

#Region "2015/08/07 報表警示設定維護檔(PUB_Report_Alarm) by Hsiao.Kaiwen"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Function PUBReportAlarminsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Function PUBReportAlarmupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBReportAlarmdelete(ByRef pk_Report_ID As System.String) As Integer

    ''' <summary>
    ''' 查詢報表列印記錄檔
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBReportAlarmQueryByLikeColumn(ByVal Report_ID As String, ByVal Report_Name As String, ByVal Rpt_Alarm_Count As String, ByVal Rpt_Is_Active As String) As DataSet

    ''' <summary>
    ''' 查詢PK資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBReportAlarmQueryByPK(ByVal Report_ID As String) As DataSet

    ''' <summary>
    ''' 查詢報表ID-初始化Combobox
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBReportAlarmQueryReportId() As DataSet

    ''' <summary>
    ''' 查詢 Alarm Count
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Function PUBReportAlarmCountQuery(ByVal Report_ID As String) As Integer



#End Region

#Region "2015/08/12 吸菸嚼檳榔問卷(PUB_Patient_Personal_Habits) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢該病患最近一年內的勸戒之記錄
    ''' </summary>
    ''' <returns>DataSet</returns> 
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Function QueryInOneYearAdmonishRecord(ByRef ChartNo As String) As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Function PUBPatientPersonalHabitsinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Function PUBPatientPersonalHabitsupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Function PUBPatientPersonalHabitsqueryByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet

#End Region

#Region "2015/08/12 TOCC問卷(PUB_Patient_TOCC) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢是否存在該患當日之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Function QueryTodayPatientTOCCRecord(ByRef ChartNo As String) As DataSet

    ''' <summary>
    ''' 新增TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen.Yu on 2015-08-14</remarks>
    Function PUBPatientTOCCinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Function PUBPatientTOCCupdate(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "2015/08/18 取得APP 伺服器系統日期時間 By Lits"

    ''' <summary>
    ''' 取得APP 伺服器系統日期時間
    ''' </summary>
    ''' <returns>伺服器系統日期時間 </returns>
    ''' <remarks></remarks>

    Function getApServerSystemDateTime() As DateTime

#End Region

#Region "2015/08/21 診間查詢form診間誤餐登記(PUB_Zone_Room) by ChenYu.Guo"

    ''' <summary>
    ''' queryPUBZoneRoomForMissMeal
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-21</remarks>
    Function queryPUBZoneRoomForMissMeal(ByVal Room_Code As String) As DataSet

#End Region


#Region "2015/09/02 報表列印工作 Add By Charles"

    Function insertPrintJobData(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2015/09/02 PUBPrintJobQueryUI(報表執行進度查詢) Add By Charles "

    Function queryPUBPrintJobByCond(ByVal cond As DataTable) As DataSet

    Function queryPUBPrintJobReportType() As DataSet

    Function queryPUBPrintJobReportByType(ByVal reportType As String, ByVal userId As String) As DataSet

    Function increaseDownloadCnt(ByVal JobID As String) As Integer
#End Region

#Region "2015/09/10 查診展班週數(PUB_Config) by ChenYu.Guo"

    ''' <summary>
    ''' 查診展班週數
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-09-10</remarks>
    Function PUBConfigQueryExpandWeek() As DataSet


#End Region

#Region "2015/09/28 查詢看診目的(PUB_Medical_Type_Id) by Will,Lin"
    Function getPUBMedicalTypeId() As DataSet

#End Region

#Region "2015/09/29 取得藥品名稱自動搜尋視窗的藥品資料 ChenYu.Guo"

    ''' <summary>
    ''' 取得藥品名稱自動搜尋視窗的藥品資料
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Function Get_PharmacyBase(ByRef orderName As String) As DataTable

#End Region

#Region "2015/09/29 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料 ChenYu.Guo"

    ''' <summary>
    ''' 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料(原Get_PharmacyClass)
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Function Get_PharmacyClassAndCompositionAndATC(ByVal orderName As String, ByVal NameType As String) As DataTable

#End Region

#Region "2015/10/05 查詢TOCC關閉視窗之控制(PUB_Config) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢TOCC關閉視窗之控制
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Function PUBConfigQueryTOCCCloseWindows() As String


#End Region

#Region "2015/10/30 過敏藥品查詢(PUB_Patient_Allergy) by Eddie,Lu"

    ''' <summary>
    ''' 過敏藥品查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Function queryPUBPatientAllergyByCond(ByRef pk_Chart_No As System.String) As System.Data.DataSet


#End Region

#Region "2015/11/11 看診目的基本檔維護作業(PUB_Medical_Type) by Eddie,Lu"

    ''' <summary>
    ''' 一般查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypequery(ByRef medicalTypeId As String, ByRef medicalTypeName As String, ByRef medicalTypeCtrlId As String, ByRef disIdentityCode As String, ByRef Contract_Code1 As String, ByRef Contract_Code2 As String, ByRef partCode As String, ByRef cardSn As String, ByRef icMedicalTypeId As String, ByRef caseTypeId As String, ByVal pedSort As Integer, ByVal surSort As Integer, ByVal medSort As Integer, ByVal entSort As Integer, ByVal uroSort As Integer, ByRef rehSort As Integer, ByVal ipdSort As Integer, ByVal opdSort As Integer, ByVal emgSort As Integer) As DataSet

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypedelete(ByRef pk_Medical_Type_Id As System.String) As Integer

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypeinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypeupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypequeryAll() As System.Data.DataSet

    ''' <summary>
    ''' 取得Cbo資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBMedicalTypequeryCboData() As DataSet

#End Region

#Region "檢驗表單維護 PubLisSheet"
    'Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32

    'Function PubLisSheetUpdate(ByVal SheetCode As String, _
    '                           ByVal SheetName As String, _
    '                           ByVal DeptCode As String, _
    '                           ByVal IsEmergencySheet As String, _
    '                           ByVal SheetCollectNote As String, _
    '                           ByVal SheetNote As String, _
    '                           ByVal SheetContactTel As String, _
    '                           ByVal Dc As String, _
    '                           ByVal User As String) As Int32

    'Function PubLisSheetDelete(ByVal SheetCode As String) As Int32

    'Function PubLisSheetQuery(ByVal SheetCode As String, _
    '                          ByVal SheetName As String, _
    '                          ByVal DeptCode As String, _
    '                          ByVal SheetContactTel As String) As DataSet

    'Function queryPUBDepartmentAllDept() As DataSet
#End Region

#Region "2016/04/19 add by Kaiwen, 排除藥費(PUBExcludeDrugSetBO_E1)"
    Function queryExclusiveDrugSetData2(ByVal OrderCode As String) As DataTable
    Function insertExclusiveDrugSetByOrderCode(ByVal OrderCode As String, ByVal insertData As DataSet) As Integer

#End Region

#Region "2016/04/19 Add by Kaiwen, 找多個TypeId的syscode (PUBNhiIndexSetUI)【查詢Syscode(多筆)】 "

    ''' <summary>
    ''' 找多個TypeId的syscode
    ''' </summary>
    ''' <param name="TypeIds"></param>
    ''' <returns></returns>
    ''' <remarks>Add by Jen</remarks>
    Function querySyscodeByTypeIds(ByVal TypeIds() As Integer) As DataTable

#End Region

#Region "2016/04/19 查詢健保支付標準檔資料(PUBNhiCodeBO) , Added by Kaiwen "
    Function queryPubNhiCodeEffectData(ByVal inEffectDate As String, ByVal inInsuCode As String, ByVal inOrderCode As String) As DataTable

#End Region

#Region "2016/04/19 醫療支付公用主檔 (醫令控制畫面) , Added by Kaiwen"

    Function initPUBOrderInfo(ByVal initType As String) As DataSet

    Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet

    Function checkProcessStatus(ByVal OldOrderDT As DataTable, ByVal NewOrderDT As DataTable) As DataSet

    Function commitOrderRelatedData(ByVal OrderRelatedData As DataSet) As Integer

    Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataSet

    Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataSet


#End Region

#Region "2016/04/19 舊程式OPHPB_BS , Added by Kaiwen"

#Region "2016/04/19 由Order_Code查詢藥品碼資料(舊程式OPHPB_queryPharmacyBaseByOrderCode(OrderCode)), Added by Kaiwen"

    Function queryPharmacyBaseByOrderCode(ByVal OrderCode As String) As DataTable

#End Region


#End Region

#Region "2016/04/19  依醫令刪除所有相關表格資料 Log ,  add by Kaiwen "

    Function deletePUBOrderLog(ByVal inOrderCode As String, ByVal inOrderName As String, ByVal inOrderTypeId As String, ByVal inOrderMode As String, ByVal inExecutionUser As String) As Integer

    Function deletePUBOrderByOrderCode(ByVal inOrderCode As String) As Integer

#End Region

#Region "2016/04/19  PUBAddQueryUI ,add by Kaiwen"

    ''' <summary>
    ''' 兒童加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryAdd(ByVal Order_Code As String) As DataTable

    ''' <summary>
    ''' 急件加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryAdd_EMG(ByVal Order_Code As String) As DataTable

    ''' <summary>
    ''' 牙科轉診加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryAdd_Dental(ByVal Order_Code As String) As DataTable

    ''' <summary>
    ''' 科別加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable


#End Region

#Region "2016/04/19 PUBInsuCodeBO , Added by Kaiwen"

#Region " 查詢資料"

    Function queryPubInsuCodeEffectData(ByVal inEffectDate As String, ByVal inOrderTypeId As String, ByVal inOrderCode As String) As DataTable

#End Region

#End Region

#Region "2016/04/22   取得群組醫令, Added by Kaiwen "

    Function queryAddOrderData(ByVal AddOrderCode As String) As DataTable

    Function queryAddOrderDetailData(ByVal AddOrderCode As String) As DataTable

    Function queryAddOptionOrderData(ByVal AddOrderCode As String, ByVal AddOrderDetailNo As Integer) As DataTable


#Region "2016/05/10 更新群組醫令維護檔 By Will"
    ''' <summary>
    ''' InsertTo AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateAddOrder(ByVal ds As DataSet) As Integer

    ''' <summary>
    ''' Delete AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="addOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function deleteAddOrder(ByVal addOrderCode As String) As Integer

#End Region
#End Region

#Region "2016/04/25 檢驗表單維護 PubLisSheet by Kaiwen"
    Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32

    Function PubLisSheetUpdate(ByVal UpdateData As DataSet) As Int32

    Function PubLisSheetDelete(ByVal SheetCode As String) As Int32

    Function PubLisSheetQuery(ByVal SheetCode As String, _
                              ByVal SheetName As String, _
                              ByVal DeptCode As String, _
                              ByVal SheetContactTel As String) As DataSet

#Region "     以ＰＫ查詢資料 "

    Function PubSheetQueryByPK(ByVal pk_Sheet_Code As String, ByVal pk_Sheet_Name As System.String, ByVal pk_Dept_Code As System.String) As DataSet
#End Region

#Region "     以ＰＫ Like 的方式查詢資料 "

    Function PubSheetQueryByLikePK(ByVal pk_Sheet_Code As String) As DataSet
#End Region

#End Region

#Region "2016/04/25  PubDepartment by Kaiwen"
    Function queryPUBDepartmentBySourceType(ByVal inSourceType As String) As DataSet

    Function queryPUBDepartmentAllDept() As DataSet
#End Region

#Region "2016/04/26  PUBExaminationSheetDetailMaintainBS 檢驗醫令明細維護, Added by Kaiwen"

    Function PUBExaminationSheetDetailMaintainGetInitInfo(ByVal User As String) As DataSet

    Function PUBExaminationSheetDetailMaintainGetOrderList(ByVal SheetCode As String) As DataSet

    Function PUBExaminationSheetDetailMaintainGetOrderInfo(ByVal OrderCode As String) As DataSet

    Function PUBExaminationSheetDetailMaintainWriteBackEditedInfo(ByVal InputData As DataSet, ByVal User As String) As Int32

    Function PUBExaminationSheetDetailMaintainQuerySheetDetail(ByVal SheetCode As String, ByVal OrderCode As String) As DataSet

    Function PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(ByVal InputData As DataSet) As Int32

    Function PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(ByVal InputData As DataSet, ByVal User As String) As Int32

#End Region

#Region "2016/04/26 檢查表單維護,  Added By Kaiwen"

    Function initSheetData() As DataSet

    Function querySheetDetailData(ByVal SheetCode As String) As DataTable

    Function confirmSheetData(ByVal sheetDS As DataSet) As Boolean

    Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable

#End Region


#Region "2016/04/28 PUBRisFormMaintainSheetDetailUI, Added by Kaiwen"

    Function InsertIntoPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32

    Function DeleteFromPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32

    Function PUBRisFormMaintainGetAvalibleSheet(ByVal User As String) As DataSet

#End Region

#Region "2016/04/28 PUBSheetDisplayUI 表單開單顯示檔維護"

    Function QueryPubSheetDisplayByCond(ByVal Sheet_Type_Id As String, ByVal Sheet_Main_Display As String, ByVal Sheet_Sub_Display As String) As System.Data.DataSet


    Function PUBSheetDisplayInsert(ByVal ds As DataSet) As Integer

    Function PUBSheetDisplayDelete(ByRef pk_Sheet_Type_Id As System.String, ByRef pk_Sheet_Main_Display As System.String, ByRef pk_Sheet_Sub_Display As System.String) As Integer

    Function PUBSheetDisplayUpdate(ByVal ds As DataSet) As Integer


#End Region

#Region "2016/05/24  表單開單顯示醫令檔檔基本資料維護, added by Roger"

    Function PUBSheetDisplayOrderInsert(ByVal ds As DataSet) As Integer


    Function PUBSheetDisplayOrderUpdate(ByVal ds As DataSet) As Integer


    Function PUBSheetDisplayOrderDelete(ByRef pk_Sheet_Sub_Display As System.String, ByRef pk_Order_Display_Code As System.String) As Integer


    Function QueryPubSheetDisplayOrderByCond(ByVal Sheet_Sub_Display As String, ByVal Order_Code As String, ByVal Order_Display_Code As String, ByVal Order_Display_Name As String) As DataSet

    Function queryPUBBodySiteMainSiteData() As DataSet

    Function QueryPubSheetDisplayOrderCombodata(ByVal MainBodySite As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

    Function QuerySheetDisplayOrderAll() As System.Data.DataSet

    Function QuerySheetDisplayOrderCheckDS(ByVal strOrderCode As String, ByVal strMainBodySite As String, ByVal strBodySite As String, ByVal strSiteID As String) As System.Data.DataSet
#End Region

#Region "2016/05/17  郵遞區號設定維護, added by Roger"
    Function PUBPostalCodeInsert(ByVal ds As DataSet) As Integer

    Function PUBPostalCodeupdate(ByVal ds As DataSet) As Integer

    Function PUBPostalCodedelete(ByVal Postal_Code As String) As Integer

    Function PUBPostalCodequery(ByVal Postal_Code As String, ByVal Postal_Name As String, ByVal County_Name As String, ByVal Town_Name As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet


#End Region

#Region "預防保健執行設定維護 BY Roger "

    Function insertPUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer


    Function updatePUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer


    Function deletePUBPreventiveCareExe(ByRef pk_Care_Order_Code As System.String, ByRef pk_Pre_Care_Order_Code As System.String) As Integer


    Function queryPUBPreventiveCareExeByCond(ByVal PreCareOrderCode As String, ByVal CareOrderCode As String, ByVal AgeControlId As String) As System.Data.DataSet

    Function getPUBPreventiveCareExeCombodata() As DataSet

#End Region

#Region "2016/05/20 病患DNR記錄檔(PUB_Patient_DNR) by Eddie,Lu"

    ''' <summary>
    ''' 新增With DNR流水號
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatientDNRinsertWithDNRNo(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatientDNRqueryByPKROC(ByRef pk_Chart_No As System.String, ByRef strDNRKindId As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatientDNRdelete(ByRef pk_Chart_No As System.String, ByRef pk_Source_Kind As System.String, ByRef pk_DNR_No As System.Int32) As Integer

    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatientDNRqueryCboDs() As DataSet

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatientDNRupdate(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/05/20 病患特殊註記顯示排序檔(PUB_Pat_Flag_Sort) by Eddie,Lu"

    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatFlagSortdelete(ByRef pk_Flag_Id As System.String) As Integer

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatFlagSortqueryByPKROC(ByRef pk_Flag_Id As System.String, ByRef strFlagSortId As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatFlagSortqueryCboDs() As DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatFlagSortinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Function PUBPatFlagSortupdate(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱)  By Li.Han"
    ''' <summary>
    ''' 取得中文名稱
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBRulequeryRuleNameByCode(ByVal strSQL As String) As String
#End Region

#Region "2016/06/07 查詢透析院所代號 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢透析院所代號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Function PubHospitalqueryByNow() As System.Data.DataSet

#End Region

    '#Region "2016/06/07 以病歷號查詢關聯表的資料 (For KLH 用) by ChenYu.Guo"

    '    ''' <summary>
    '    ''' 以病歷號查詢關聯表的資料
    '    ''' </summary>
    '    ''' <returns>System.Data.DataSet</returns>
    '    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    '    Function PubPatientqueryRelationInfoByPK(ByRef pk_Chart_No As System.String, ByRef pk_Pip_Type As System.String) As System.Data.DataSet

    '#End Region

#Region "2016/06/07 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Function PubPatientBodyrecordQueryByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet

#End Region

#Region "以 Type_Id 查詢資料 by Gary.Chiang"

    ''' <summary>
    ''' 以 Type_Id 查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Gary on 2016-05-16</remarks>
    Function PubSyscodeQueryByTypeId(ByRef pk_Type_Id As System.Int32) As System.Data.DataSet
#End Region

#Region "2016/06/14 通過Chart_No查詢PUB_Patient_Allergy的資料 by Gary.Chiang"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_Allergy的資料
    ''' </summary>
    ''' <remarks></remarks>
    Function PubPatientAllergyqueryTopByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet

#End Region


#Region "2016/06/17 寫入ISS_Item By Will"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemInsert(ByRef ds As DataSet) As Integer

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemUpdate(ByRef ds As DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemQueryAll() As DataSet

    ''' <summary>
    ''' 查詢最近一筆評分資料
    ''' </summary>
    ''' <param name="pk_Chart_No"></param>
    ''' <param name="pk_Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBPatientISSBOqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Medical_Sn As System.String) As DataSet

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBPatientISSDelete(ByVal Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
#End Region
#Region "20160623 入院護理評估的身高體重塞入PUB_Patient_BodyRecord"
    ''' <summary>
    ''' 入院護理評估的身高體重塞入PUB_Patient_BodyRecord
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kasim on 20160623</remarks>
    Function PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ByVal ds As System.Data.DataSet) As Integer
#End Region

#Region "2016/06/29 住院護理站基本檔維護(Pub_Station) by Hanru"

    ''' <summary>
    ''' 新增護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Function insertPubStation(ByVal ds As DataSet) As Integer

    ''' <summary>
    ''' 修改護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Function updatePubStation(ByVal ds As DataSet) As Integer

    ''' <summary>
    ''' 刪除護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Function deletePubStation(ByRef pk_Station_No As String) As Integer

    ''' <summary>
    ''' 查詢護理站基本檔資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Function queryPubStationByCond(ByVal pk_Station_No As String) As DataSet


#End Region


#Region "2016/06/30 檢查醫令不須報到部門維護作業(PUB_Order_Exam_Nocheckin_Dept) by Jun"

    ''' <summary>
    ''' 取得門急住個別的不需報到科別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Function getInitialOrderExamNoCheckinDept(ByVal chartNo As String) As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Function PUBOrderExamNocheckinDeptinsert(ByVal ds As System.Data.DataSet) As Integer


    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Function PUBOrderExamNocheckinDeptdelete(ByRef pk_Order_Code As System.String) As Integer

#End Region

#Region "2016/07/13 科室主管檔 add by kudy.sue"
    Function queryPubDeptLeaderByCond(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As System.Data.DataSet

    '新增
    Function insertPubDeptLeader(ByVal dsData As DataSet) As Integer

    '修改
    Function updatePubDeptLeader(ByVal dsData As DataSet) As Integer

    '刪除
    Function deletePubDeptLeader(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As Integer


#End Region

#Region "2016/07/15 特殊屬性輸入元件(PUBLabIndication04) by Margaret.Tsai"

    ''' <summary>
    ''' 特殊屬性輸入元件
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Margaret.Tsai on 2016-07-15</remarks>
    Function PUBLabIndication04QureyPUBLabIndication04() As DataSet

    Function PUBLabIndication10QureyPUBLabIndication10(ByVal inIDNO As String, ByVal inOrderDate As String) As DataSet


#End Region

#Region "2009-12-10 Added by Alan,寫入IC卡重大傷病與藥物過敏資料 "

    Function InsertPatientData(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet) As Integer

    Function InsertPatientData2(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet, ByVal Prevent As DataSet) As Integer
#End Region

#Region "2016/08/23 更新病人聯絡資料 Will"
    ''' <summary>
    '''更新病人聯絡資料
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Function updatePatContactInfo(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/08/25 成本中心設定維護(PUB_Acc_Dept) by Chi,Wang"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Function PUBAccDeptinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Function PUBAccDeptupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Function QueryPubAccDeptByPK(ByVal tmp As String) As System.Data.DataSet

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Function PUBAccDeptDelete(ByVal PK As String) As Integer
#End Region



#Region "成本中心部門查詢 2016-09-19 by 林承毅"

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by 林承毅 on 2016-09-19</remarks>
    Function QueryPubAccDeptName(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
#End Region


#Region "2016/09/19 轉入健保醫令價格異動檔(PUBNhiCodeImportBO_E1) by Chi,Wang"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Function PUBNhiCodeImportBOE1ImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Function PUBNhiCodeImportBOE1importorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Function PUBNhiCodeImportBOE1query(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet


#End Region

#Region "2016/10/01 尋找停用醫令替代項目 By Will Lin"

    ''' <summary>
    ''' 尋找停用醫令替代項目
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Function queryOrderAlternativeForOEIOtherLack(ByVal OrderCode As String) As DataSet

    ''' <summary>
    ''' 查詢被DC的醫令
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Function queryPUBOrderDC(ByVal inOrderCode As String) As DataSet

#End Region

    ''' <summary>
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Function queryUserMappingPUBSheet(ByVal currentUser As String) As DataSet

    ''' <summary>
    ''' 查詢登入使用者可用的表單對應儀器
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Function queryUserMappingApparatusCode(ByVal currentUser As String) As DataSet

#Region " 2016/10/14 檢核規則維護(PubRuleReason) By Kaiwen "

#Region "     以ＰＫ查詢資料 "
    Function queryRuleReasonByRuleCode(ByVal pk_Rule_Code As String) As DataSet

#End Region

#End Region

#Region "20130430 add by Alan,自費衛材核定記錄維護"

    Function insertPUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer
    Function updatePUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer
    Function deletePUBMaterialSelfpayApply(ByVal OrderCode As String, ByVal EffectDate As Date)
    Function queryPUBMaterialSelfpayApply(ByVal sqlString As String) As DataSet

#End Region


#Region " 2016/10/20 取得醫院資料 By Chi,Wang "
    Function queryHospitalInfo(ByVal HospitalCode As String, ByVal LanguageTypeId As String, ByVal EffectDate As Date) As DataSet

#End Region

#Region "20101217 add by Rich, 事前審查適應症查詢"

    Function queryPUBOrderByOrderCode(ByVal Order_Code As String) As System.Data.DataSet

#End Region

#Region "PUBZoneRoomBO_E1  區診間維護檔"
    Function queryPUBZoneRoomByCond(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet

    Function insertPUBZoneRoom(ByVal dsSaveData As DataSet) As Integer

    Function updatePUBZoneRoom(ByVal dsSaveData As DataSet) As Integer

    Function deletePUBZoneRoomByPK(ByVal strZoneId As String, ByVal strRoomCode As String) As Integer
#End Region

#Region "2016/12/15 自費衛材核定記錄維護(PUBMaterialSelfpayApply) by Hsiao,Kaiwen"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Function PUBMaterialSelfpayApplyinsert(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Function PUBMaterialSelfpayApplyupdate(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Function PUBMaterialSelfpayApplyDelete(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As Integer

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Function queryPubMaterialSelfpayApplyByPK(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet

    ''' <summary>
    ''' 以ＰＫ Like 查詢資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Function queryPubMaterialSelfpayApplyByPKLike(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet


#End Region

#Region "2017/02/23 轉入健保醫令價格異動檔衛材(PUBNhiCodeImportM) by Chi,Wang"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Function PUBNhiCodeImportMImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Function PUBNhiCodeImportMimportorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Function PUBNhiCodeImportMquery(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet


#End Region

#Region "2017/03/21 病患傳送風險(PUBPatientTransferRiskUI) by Will,Lin"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Function InsertIntoPUBPatientTransferRisk(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Function QueryPUBPatientTransferRiskLevel(ByVal strChartNo As String, ByVal strOutpatientSn As String) As String

#End Region
#End Region

#Region "查詢醫令是否已存在(PUB_Sheet_Detail)"
    Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet
#End Region

#Region "2017/04/06 看診目的排序設定(Pub_Medical_Type_Sort) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Function InsertPubMedicalTypeSort(ByVal stremployeecode As String) As Integer


#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Function QueryPubMedicalTypeSort(ByVal stremployeecode As String) As DataSet

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Function DeletePubMedicalTypeSort(ByVal stremployeecode As String) As Integer


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Function UpdatePubMedicalTypeSort(ByVal ds As DataSet, ByVal stremployeecode As String) As Integer


#End Region
#End Region

#Region "2017/04/13 檢查醫令不須列印部門維護作業(PUB_Order_Exam_NoPrint_Dept) by Michelle"

    ''' <summary>
    ''' 取得門急住個別的不需列印科別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Function getInitialOrderExamNoPrintDept(ByVal orderCode As String) As DataSet

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Function PUBOrderExamNoPrintDeptdelete(ByRef pk_Order_Code As System.String) As Integer

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Function PUBOrderExamNoPrintDeptinsert(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2017/04/14 PubDrAddControlUI 特定醫師加成控制檔維護 by Hsu-Yuan,Yang"

    Function PubDrAddControlInsert(ByVal ds As DataSet) As Integer

    Function PubDrAddControlUpdate(ByVal ds As DataSet) As Integer

    Function PubDrAddControlDelete(ByRef pk_Dept_Code As String, ByRef pk_Order_Code As String, ByRef pk_Employee_Code As String) As Integer

    Function QueryPubDrAddControlByPK(ByRef deptCode As String, ByRef orderCode As String, ByRef employeeCode As String) As DataSet

#End Region

End Interface


