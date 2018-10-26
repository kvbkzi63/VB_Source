Public Interface IPubServiceManager_L

#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"
    Function queryPUBContractsForBILRPT09460() As DataSet

#End Region

#Region " Add by Elly.Gao on 2016/12/27 for 兵檢資料轉換作業 OHMConvertMilitaryExcelUI"
    Function queryAreaCodeGovByGovADist(ByVal strGovAndDistCode As String) As DataSet
#End Region

#Region "20091021 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查) Dc = 'N'，add by Tor"
    Function queryPUBOrderByDate_L(ByVal OutDate As String) As DataSet
#End Region

#Region "200901010 轉診轉出--建議轉診科別 by Add tor"
    Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet
#End Region

#Region "20150915 PUBDeptSect 科診維護   by Will,Lin"

    ' 依條件查詢科診名稱 
    Function queryPubDeptSectByCond_L(ByVal strDeptCode As String, ByVal strSectId As String) As DataSet

    ' 新增科診名稱 
    Function insertPubDeptSect_L(ByVal dsSaveData As DataSet) As Integer

    '刪除科診名稱
    Function deletePubDeptSectByPK_L(ByVal strDeptCode As String, ByVal strSectId As String) As Integer

    '更新科診名稱
    Function updatePubDeptSectByCond_L(ByVal dsSaveData As DataSet) As Integer

#Region "2015/11/11 科診屬性代碼查詢(PUB_Dept_Sect) by Eddie,Lu"

    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Function PUBDeptSectqueryCboData(ByVal typeId As Integer) As DataSet


#End Region


#End Region

#Region "20150915 PUBDepartmentUI 科室檔維護   by Will,Lin"

    ' 依條件查詢科室檔資料 
    Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As DataSet

    ' 新增科室檔資料 
    Function insertPUBDepartment(ByVal dsSaveData As DataSet) As Integer

    '刪除科室檔資料
    Function deletePUBDepartment(ByVal strDeptCode As String) As Integer

    '更新科室檔資料
    Function updatePUBDepartment(ByVal dsSaveData As DataSet) As Integer

    Function queryPubDeptSect_L(ByVal strDeptCode As String) As DataSet

    '獲取Department資料
    Function queryPUBDepartmentCA() As DataSet
#End Region

#Region "20090814 PUBBodySiteUI 部位檔維護  by tianxie"

    ' 查詢某一部位 
    Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As DataSet

    ' 查詢某一部位 
    Function queryNhiBodySiteCodeByColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet

    Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As DataSet

    '新增部位
    Function insertPUBBodySite(ByVal ds As DataSet) As Integer

    '刪除部位
    Function deletePUBBodySiteByPK(ByRef pk_Body_Site_Code As String) As Integer

    '更新部位
    Function updatePUBBodySite(ByVal ds As DataSet) As Integer


#End Region

#Region "20150915 PUBNhiCodeUI 健保支付標準檔  Add by Runxia"

    ' 查詢特定治療項目基本檔資料 
    Function queryPUBMajorNoEquByCond_L(ByVal strMajorcareCode As String) As DataSet

    ' 查詢健保支付標準檔,(檢驗檢查)  
    Function queryPUBNhiCodeByCond_L(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet

    '刪除健保支付標準檔
    Function deletePUBNhiCodeByInsuCode_L(ByVal strInsuCode As String) As Integer

    '確定儲存 健保支付標準檔
    Function confirmPUBNhiCode_L(ByVal saveData As DataSet) As DataSet
    Function queryPUBNhiCodeUpDown_L(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet

    Function queryPUBNhiDeptCode() As DataSet

#End Region

#Region "20100422 PubPatientSevereDiseaseBO 病患重大傷病記錄檔  Add by Runxia"

    '查詢病患重大傷病記錄檔
    Function queryPUBPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date) As DataSet

    '新增病患重大傷病記錄檔
    Function insertPUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer

    '刪除病患重大傷病記錄檔
    Function deletePUBPatientSevereDisease_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal strEffectDate As String) As Integer

    '修改病患重大傷病記錄檔
    Function updatePUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer

    '由Icd_code查詢對應的診斷英文名
    Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet

    ''' <summary>
    ''' 病歷號查詢(顯示是否)
    ''' </summary>
    ''' <returns>String) as DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-03</remarks>
    Function PUBPatientSevereDiseasequeryByPKYNShow(ByRef pk_Chart_No As String, ByRef pk_Icd_Code As String, ByRef pk_Effect_Date As Date) As DataSet

#End Region

#Region "20150914 PUBPatientHealthCardUI 全國醫療卡維護檔 Add by Will,Lin"

    Function queryPUBPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As DataSet

    Function queryPubPatientFlagByChartNo_L(ByVal strChartNo As String) As DataSet

    '新增全國醫療服務卡維護檔
    Function insertPUBPatientHealthCard_L(ByVal ds As DataSet) As Integer

    Function insertPUBHealthAndFlag_L(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer

    Function updatePUBPatientHealthCard_L(ByVal ds As DataSet) As Integer

    Function deletePUBPatientHealthCard_L(ByVal strChartNo As String, ByVal strEffectDate As String) As Integer

#End Region

#Region "20150911 PUBPhaServicesUI 藥事服務費基本檔 Add by Will,Lin"

    '依條件查詢輸入護理資訊檔資料
    Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet

    '新增輸入護理資訊檔資料
    Function insertPUBPhaServices(ByVal dsSaveData As DataSet) As Integer

    '刪除輸入護理資訊檔資料
    Function deletePUBPhaServicesByPK(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String) As Integer

    '更新輸入護理資訊檔資料
    Function updatePUBPhaServices(ByVal dsSaveData As DataSet) As Integer

#End Region

#Region "20150911 PUBDisIdentityUI 優待身份基本檔維護 Add by Will,Lin"

    '查詢優待身份基本資料
    Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As DataSet

    '新增優待身份基本檔資料
    Function insertPUBDisIdentity(ByVal ds As DataSet) As Integer

    '刪除優待身份基本檔資料
    Function deletePUBDisIdentityByPK(ByRef DisIdentityCode As String) As Integer

    '修改優待身份基本檔資料
    Function updatePUBDisIdentity(ByVal ds As Data.DataSet) As Integer

#End Region

#Region "20150911 PUBDisIdentitySetUI 優待身分折扣設定檔 add by Will,Lin"

    '依條件查詢
    Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String) As System.Data.DataSet

    '新增折扣身分資料
    Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150911 PUBAccountUI 項目費用對應檔 add by Will,Lin"

    '費用項目對應檔維護- 依傳入TypeID取得代碼檔資料
    Function queryPUBSysCode_L(ByVal TypeID As String) As DataSet

    '依條件查詢費用項目對應檔資料
    Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet

    '新增費用項目對應檔
    Function insertPUBAccount(ByVal saveData As DataSet) As Integer

    '更新費用項目對應檔
    Function updatePUBAccount(ByVal saveData As DataSet) As Integer

    '刪除費用項目對應檔
    Function deletePUBAccountByPK(ByVal strAccountId As String) As Integer

#End Region

#Region "20150911 PUBExamineUI 診察費基本檔維護 add by Will,Lin"

    '依條件查詢診察費基本檔資料
    Function queryPUBExamineByCond_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                     ByVal strDeptCode As String, ByVal strSectionId As String, _
                                     ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                     ByVal strOrderCode As String) As System.Data.DataSet
    '新增診察費基本檔資料
    Function insertPUBExamine_L(ByVal dsSaveData As DataSet) As Integer
    '刪除診察費基本檔資料
    Function deletePUBExamineByPK_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                  ByVal strDeptCode As String, ByVal strSectionId As String, _
                                  ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String) As Integer
    '更新診察費基本檔資料
    Function updatePUBExamine_L(ByVal dsSaveData As DataSet) As Integer

#End Region

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"

    '查詢
    Function queryPUBPartByAll() As DataSet
    '查詢
    Function queryPUBSubIdentityForCombo_L() As DataSet
    '查詢
    Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String) As DataSet
    '修改
    Function confirmPUBPartDiscount(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150910 PUBPartUI 部分負擔基本檔 add by Will,Lin"
    '查詢
    Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String) As DataSet
    '確認
    Function confirmPUBPart(ByVal saveData As DataSet) As DataSet
#End Region

#Region "20150909 PUBRegisterFeeUI 掛號費基本維護檔 add by Will,Lin"
    '查詢
    Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet
    '新增
    Function insertPUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer
    '修改
    Function updatePUBRegisterFee(ByVal ds As DataSet) As Integer
    '刪除
    Function deletePUBRegisterFeeByPK(ByVal pk_Source_Id As String, ByRef pk_Sub_Identity_Code As System.String, ByVal strFirstReg As String, ByRef pk_Dept_Code As System.String, ByRef pk_Section_Id As System.String, ByRef pk_Medical_Type_Id As System.String) As Integer

#End Region

#Region "20150909 PUBPtDisabilityUI 病患殘障記錄檔 add by Will,Lin"

    '查詢
    Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet
    '新增
    Function insertPUBPtDisability_L(ByVal ds As DataSet) As Integer
    '修改
    Function updatePUBPtDisabilityByPK_L(ByVal ds As DataSet) As Integer
    '刪除
    Function deletePUBPtDisabilityByPK_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As Integer) As Integer
    '查詢
    Function queryPUBSysCodeByTypeIdForDisability_L(ByVal strTypeId As String) As DataSet

#End Region

#Region "20150908 PUBPatientQuotaUI 病患合約機構累積檔 add by Will"

    Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String) As DataSet

    Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet


#End Region

#Region "20150904 PUBMajorcareUI 特定治療項目基本檔維護 add by Will,Lin"

    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet

    Function insertPUBMajorcare(ByVal dsSaveData As DataSet) As Integer

    Function updatePUBMajorcare(ByVal dsSaveData As DataSet) As Integer

    Function deletePUBMajorcareByPK(ByVal strMajorcareCode As String) As Integer

#End Region

#Region "20150904 PUBSubIdentityUI 身份二代碼基本檔 add by Will,Lin"

    Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet

    Function insertPUBSubIdentity(ByVal dsSaveData As DataSet) As Integer

    Function updatePUBSubIdentity(ByVal dsSaveData As DataSet) As Integer

    Function deletePUBSubIdentityByPK(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As Integer

#End Region

#Region "20150904 PUBSubIdentitySetUI 身份二代碼計價設定檔維護 add by Will,Lin"

    Function confirmPUBSubIdentitySet(ByVal dsSaveData As DataSet) As DataSet

    Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                          ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                          ByVal strOrderCode As String) As System.Data.DataSet

#End Region

#Region "20150903 PUBContractUI 合約機構基本檔 add by Will,Lin"
    Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet

    Function deletePUBContractByPK(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As Integer

    Function insertPUBContract(ByVal dsSaveData As DataSet) As Integer

    Function updatePUBContract(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20150903 PUBContractQuotaUI 合約機構記賬累積檔維護 add by Will,Lin"

    Function queryPUBContractQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet

    Function confirmContractQuota(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150903 PUBContractPartSetUI 合約身份部份負擔記帳設定檔 add by Will,Lin"
    Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet
    Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet

#End Region

#Region "20150831 PUBContractSetUI 合約身分記帳設定維護 add by Will,Lin"

    Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean) As System.Data.DataSet

    Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    Function queryPUBContractByColumnValue2_L(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
    Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    Function confirmContractSet(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150831 PUBAddPartUI 加收部分負擔維護檔 add by Will,Lin"

    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String) As DataSet

    Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet

#End Region

#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    Function queryConsuDept_L() As DataSet
#End Region

#Region "20090706 PUBSysCodeBO 共用代碼檔維護 by Add Syscom Yunfei"
    ' 獲取PUBSysCodeBO資料
    Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
#End Region

#Region "20090708 PUBDepartmentBO_E1 取得科系資料來源 by Add Syscom Johsn"
    Function queryPUBDepartmentCode() As DataSet
#End Region

#Region "20091012 查詢  轉診回覆  by Add ChenYang"

    Function queryPubPatientByPK_L(ByRef pk_Chart_No As System.String) As DataSet

    'Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As DataSet

#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    Function queryprisendInfo_L() As DataSet
#End Region

#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "

    Function queryPUBPostalCodeForCountryName_L() As DataSet

    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet

    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet

    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet
#End Region

#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet
#End Region
#Region "20100622  常用維護科別資料來源 add by coco"
    Function queryRefferalDeptOMO_L() As DataSet
#End Region

#Region "20100526 PUBDepartmentBO_E2  次專科基本檔所屬科別combobox資料  add by liuye"
    Function queryPUBDepartmentEffectByColumnValue_L(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet
#End Region

#Region "20090724 取得登錄人員信息   by Add Ming"
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet
#End Region

#Region "20110106 營養諮詢作業使用 add by yunfei"
    ''' <summary>
    ''' 查詢所屬科室之醫師信息
    ''' </summary>
    ''' <param name="DeptCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As System.Data.DataSet

#End Region

#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    ''' <summary>
    ''' 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位
    ''' </summary>
    ''' <param name="strOrder_Code">令代碼</param>
    ''' <returns>手術處置基本檔 (PubOrderOrTreatBO) 中預設部位</returns>
    ''' <remarks></remarks>
    Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String
    Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As DataSet
#End Region

#Region "20100303 獲得所屬部門下的所有部門   by Add ming"
    Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet
#End Region

#Region "20090817 OMOFavorBO 常用處置維護 add by windfog"
    ''' <summary>
    ''' 查找部位當中的所有沒有刪除的部位資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBBodySiteUnDelete() As DataSet
#End Region

#Region "2012/05/24 與RuleTransfer_N1關聯的切出部分(PUBRuleTransferN1BS_E2) by liuye"

    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-5-24</remarks>
    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer

#End Region

#Region "20100427 查詢 PUBConfigBO_E2 ,add by Mark"
    ''' <summary>
    ''' 查詢 PUBConfigBO_E2
    ''' </summary>
    ''' <param name="pk_Config_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBConfigByPK_L(ByVal pk_Config_Name As String) As System.Data.DataSet
#End Region

#Region "20091012 PUPHospitalBO_E2 根據傳入時間查詢 by Add Tor"
    Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As DataSet
#End Region

#Region "20091102 取得外國國籍名稱 , Add by tony"
    Function queryNationalName_L() As DataSet
#End Region

#Region "20091102  取得居住地區欄位 , Add by tony"
    Function queryAreaCode_L() As DataSet
#End Region

#Region "20091103 取得肺結核資料 , Add by tony"
    Function queryTuberculosis_L() As DataSet
#End Region

#Region "20090818 PUBSyscodeBO 公用代碼檔維護  by mark"
    Function queryPUBSyscodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
#End Region

#Region "20150918 PUBPatientDisabilityUI 病患殘障紀錄檔   by Will,Lin"

    Function queryPUBPatientDisabilityByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet

    Function confirmPUBPatientDisability_L(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer

    Function queryMaxPatientDisabilityNo_L(ByVal strChartNo As String) As DataSet



#End Region

#Region ""
    Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet

    Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet
#End Region

#Region "20150915 PUBPatientBO_E2 根據病歷號查詢 ,add by Remote"
    ''' <summary>
    '''  國際疫苗申請書輸入依條件查詢
    ''' </summary>
    ''' <param name="strChart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet
#End Region

#Region "2015/10/20 檢核規則維護 成醫舊程式搬移 by HE,Alien"

    Function queryByPkRuleCode(ByVal pk_Rule_Code As String) As DataSet

    Function deleteByPkRuleCode(ByVal pk_Rule_Code As String) As Integer

    Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

    Function deleteRuleData(ByVal ruleCode As String) As Boolean

    Function getRuleSerialNo() As String

    Function initPUBRuleCheckUIInfo() As DataSet

    Function initPUBRuleQueryInfo() As DataSet

    Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet

    '記錄使用者更新或刪除檢核規則
    Function InsertPUB_Rule_Transaction_Log(ByVal ds As DataSet) As Integer

    Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet

    Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable

    Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet

    Function querySelectedRuleData(ByVal selectRuleCode As String) As DataSet

    ''' <summary>
    ''' 改名稱
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getExprre(ByVal ds As String) As String
#End Region

#Region "2015/10/26 檢核規則維護 成醫舊程式搬移 by HE,Alien"

    Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

    Function getRuleMaintainSerialNo() As Integer

    Function initPUBRuleTreeQueryInfo() As DataSet

    Function querySelectedTreeRuleData(ByVal selectRuleCode As String) As DataSet

    Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet

#End Region


#Region "2015/12/16 所屬單位查詢醫師信息   by Add Charles"

    Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet
#End Region

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet

    Function queryPUBSheetByCode_L(ByVal strDeptCode As String) As DataSet
#End Region
#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"

    Function querySheetCode_L(ByVal strPubSheetCode As String) As DataSet

#End Region
#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
#End Region
#Region "20100112 排成醫令維護    by Add Coco"
    Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String) As DataSet
#End Region
#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    Function queryPUBDeptCodeNameCA3() As DataSet
#End Region
#Region "20100809 病歷量審查作業 add by Johsn"

    Function queryPUBDoctorByDoctorCode2_L(ByVal DoctorCode As String) As DataSet

#End Region
#Region "20090724 員工編號查詢醫師信息   by Add Ming"
    Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As DataSet
#End Region
    ''' <summary>
    ''' 取得病患資料及戶籍地
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>by Runxia on 2012-3-26</remarks>
    Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet
#Region "2012/04/02 科室/團隊查詢(PUBDepartmentBO_E2) by liuye"

    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    Function queryPUBDepartmentCodeIsIpdDeptY_L() As DataSet



#End Region

#Region "2016/04/22 add by Kaiwen 醫令項目代碼對應健保碼  "
    Function queryPubOrderByOrderCode2_L(ByVal strOrderCode As String) As DataSet
    Function queryPubNhiCode_L(ByVal strInsuCode As String) As DataSet
    Function queryPubInsuCode_L(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataSet
    Function deletePubInsuCode_L(ByVal ds As DataSet) As Integer
    Function queryPubInsuCodeBySeqNo_L(ByVal strOrderCode As String) As DataSet
    Function confirmPUBInsuCode_L(ByVal saveData As DataSet) As DataSet
    '取得OrderCode對應的健保碼
    Function queryPubInsuCodeByOrderCode_L(ByVal strOrderCode As String) As DataSet
#End Region

#Region "2016/04/22 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Kaiwen"

    ''' <summary>
    ''' 醫令項目代碼對應健保碼修改
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen</remarks>
    Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "20160507 PUBSysCodeBO_E2 檢驗組別,IO類別 ,add by Remote"
    Function querySpicemenType() As DataSet
#End Region

#Region "20160517 PUBPreventiveCare 預防保健基本檔設定維護 ,add by Remote"
#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PUBPreventiveCareInsert(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PUBPreventiveCareUpdate(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PubPreventiveCareDeleteByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As Integer

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PUBPreventiveCareQueryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As System.Data.DataSet

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PUBPreventiveCareQueryAll() As System.Data.DataSet

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function PUBPreventiveCareQueryByLikePK(ByRef pk_Care_Item_Code As System.String) As System.Data.DataSet

#End Region

#Region "     取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Function queryPUBCareItemAgeSex() As DataSet

#End Region


#End Region


#Region "2016/05/16 健保科別設定維護(PUBInsuDeptSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBInsuDeptdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(健保科別代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBInsuDeptQueryByPKROC(ByRef pk_Icd_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Elly on 2016-05-06</remarks>
    Function queryAllROC() As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBInsuDeptInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-06</remarks>
    Function PUBInsuDeptUpdateByPK(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/05/19 看診目的(PUBSysCodeBO_E2) by Xiaozhi"
    Function queryPUBSubMedicalType() As DataSet
#End Region

#Region "2016/05/24 五都戶籍地設定維護(PUBAreaCodeNSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Function PUBAreaCodeNdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(戶籍地代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Function PUBAreaCodeNQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Elly on 2016-05-24</remarks>
    Function queryAreaCodeAll() As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Function PUBAreaCodeNInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Function PUBAreaCodeNUpdateByPK(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/05/25 行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Function PUBAreaCodeGovdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(戶籍地代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Function PUBAreaCodeGovQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Elly on 2016-05-25</remarks>
    Function queryAreaCodeGovAll() As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Function PUBAreaCodeGovInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Function PUBAreaCodeGovUpdateByPK(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "2016/05/26 郵遞區號對應戶籍地設定維護(PUBPostalAreaSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 以所有PK查詢資料()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalAreaQueryByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function queryPostalAreaAll() As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#Region "2016/06/01 資料來源type_id = '128'(PUBSysCodeBO_E2) by Remote"
    Function queryPUBSysCodeSourceId() As DataSet
#End Region

#End Region

#Region "2016/05/27 郵遞區號對應行政區設定維護(PUBPostalGovAreaSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalGovAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalGovAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function queryPostalGovAreaAll() As System.Data.DataSet

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalGovAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Function PUBPostalGovAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "20160606 查詢病歷關系"
    Function queryPUBPatientContactByCond_L(ByVal strChartNo As String) As System.Data.DataSet

    Function queryPUBSysCodeByIcdCodingQuery_L() As DataSet
#End Region

#Region "     取得就醫序號 "
    ''' <summary>
    ''' 取得就醫序號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-20</remarks>
    Function queryMedicalSn(ByVal inParam() As String) As System.Data.DataSet
#End Region

#Region "     取得媽媽姓名 "
    ''' <summary>
    ''' 取得媽媽姓名
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-20</remarks>
    Function queryMotherName(ByVal inParam() As String) As System.Data.DataSet
#End Region

#Region "20160620 護理站 ,add by Remote"
    Function queryStationNo() As DataSet
#End Region

#Region "2016/06/28 ICD9_ICD10對照檔(PUB_Disease_ICD10_Mapping) by Li,Han"

    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappinginsertData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappingupdateData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappingdeleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As Integer

    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappingqueryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBDiseaseICD10MappingqueryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappingquertCmbData() As DataSet

    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Function PUBDiseaseICD10MappingfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer


#End Region

#Region "2016/06/29 ICD10科別對照檔(PUB_ICD10_Dept) by Li,Han"

    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptinsertData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptdeleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String) As Integer

    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptqueryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Gird資料ByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptqueryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptqueryCmbData(ByRef strTBName As String, ByRef strWhere As String) As DataSet

    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Function PUBICD10DeptfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer


#End Region


#Region "  2016/06/28 取得費用(PUBOrderPriceBO_E2) by Remote    "
    Function PUBOrderPrice(ByVal inParam() As String) As DataSet
#End Region

#Region "  2016/06/28 取得手術法(PUBOrderBO_E2) by Remote    "
    Function PUBOrderOrderName(ByVal inParam() As String) As DataSet
#End Region

#Region "     2016/06/28 傷口分類(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 傷口分類
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Function PUBSyscodeWoundType() As DataSet

#End Region

#Region "   2016/06/28 部位 by Remote   "
    ''' <summary>
    ''' 部位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Function PUBBodySiteBodyparts() As DataSet

#End Region

#Region "   2016/06/28 側位 by Remote   "
    ''' <summary>
    ''' 側位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Function PUBSyscodeBodySide() As DataSet

#End Region

#Region "    2016/07/04 急作手術分級 by Remote(PUBSysCodeBO_E2)  "
    ''' <summary>
    ''' 急作手術分級
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-07-04</remarks>
    Function PUBSyscodeUrgentClass() As DataSet

#End Region

#Region "    2016/08/13 檢驗單 by Remote(PUBsheetCodeBO_E2)  "
    ''' <summary>
    ''' 檢驗單
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-08-13</remarks>
    Function queryPUBSheetCode() As DataSet

#End Region
#Region "2016/09/12 add by qun 依據健保碼內容查詢主手術碼設定下拉選單"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks></remarks>
    Function queryICD10PCS_Code(ByVal strInsuCode As System.String) As DataSet

#End Region

#Region "2016/09/23 新增非藥品替代醫令檔(PUBOrderAlternativeUI) by Xiaozhi"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBOrderAlternativeInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-06</remarks>
    Function PUBOrderAlternativeUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBOrderAlternativedeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(醫令碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-16</remarks>
    Function PUBOrderAlternativequeryByPKOrderCode(ByRef Order_Code As System.String) As System.Data.DataSet


#End Region

#Region "20090820 PUBOrderStandingBO 常備醫令檔 Add by william"
    '查詢
    Function queryPUBOrderStandingByCond(ByVal strDept_Code As String, ByVal strOrder_Code As String) As DataSet
    '新增
    Function insertPUBOrderStanding(ByVal saveData As DataSet) As Integer
    '刪除
    Function deletePUBOrderStandingByPK(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Int32, ByVal strConsumption_Dept As String) As Integer
    '更新
    Function updatePUBOrderStanding(ByVal saveData As DataSet) As Integer

    Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean
    '查詢科別/護理站
    Function queryPUBOrderStandingByDept() As DataSet

#End Region

#Region "          2017/1/16 非藥品替代醫令檔維護 add by Michelle"

    '新增
    Function insertPUBOrder(ByVal dsData As DataSet) As Integer

    '修改
    Function updatePUBOrder(ByVal dsData As DataSet) As Integer

    '刪除
    Function DeletePUBOrder(ByVal dsDelete As DataSet) As Integer

#End Region

End Interface
