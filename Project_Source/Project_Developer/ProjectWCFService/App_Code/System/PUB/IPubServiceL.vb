Imports System.ServiceModel
Imports System.Data

' 注意: 若變更此處的類別名稱 "IPubServiceL"，也必須更新 Web.config 中 "IPubServiceL" 的參考。
<ServiceContract()> _
Public Interface IPubServiceL

    <OperationContract()> _
    Sub DoWork()

#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"
    <OperationContract()>
    Function queryPUBContractsForBILRPT09460() As DataSet
#End Region

#Region " Add by Elly.Gao on 2016/12/27 for 兵檢資料轉換作業 OHMConvertMilitaryExcelUI"
    <OperationContract()>
    Function queryAreaCodeGovByGovADist(ByVal strGovAndDistCode As String) As DataSet
#End Region

#Region "200901010 轉診轉出--建議轉診科別 by Add tor"
    <OperationContract()>
    Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet
#End Region

#Region "20091021 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查) Dc = 'N'，add by Tor"
    <OperationContract()>
    Function queryPUBOrderByDate_L(ByVal OutDate As String) As DataSet
#End Region



#Region "20150915 PUBDeptSect 科診維護   by Will,Lin"

    ' 依條件查詢科診名稱 
    <OperationContract()> _
    Function queryPubDeptSectByCond_L(ByVal strDeptCode As String, ByVal strSectId As String) As DataSet

    ' 新增科診名稱 
    <OperationContract()> _
    Function insertPubDeptSect_L(ByVal dsSaveData As DataSet) As Integer

    '刪除科診名稱
    <OperationContract()> _
    Function deletePubDeptSectByPK_L(ByVal strDeptCode As String, ByVal strSectId As String) As Integer

    '更新科診名稱
    <OperationContract()> _
    Function updatePubDeptSectByCond_L(ByVal dsSaveData As DataSet) As Integer

#Region "2015/11/11 科診屬性代碼查詢(PUB_Dept_Sect) by Eddie,Lu"

    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    <OperationContract()> _
    Function PUBDeptSectqueryCboData(ByVal typeId As Integer) As DataSet

#End Region


#End Region


#Region "20150915 PUBDepartmentUI 科室檔維護   by Will,Lin"

    ' 依條件查詢科室檔資料 
    <OperationContract()> _
    Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As DataSet

    ' 新增科室檔資料 
    <OperationContract()> _
    Function insertPUBDepartment(ByVal dsSaveData As DataSet) As Integer

    '刪除科室檔資料
    <OperationContract()> _
    Function deletePUBDepartment(ByVal strDeptCode As String) As Integer

    '更新科室檔資料
    <OperationContract()> _
    Function updatePUBDepartment(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function queryPubDeptSect_L(ByVal strDeptCode As String) As DataSet

    '獲取Department資料
    <OperationContract()> _
    Function queryPUBDepartmentCA() As DataSet


#End Region

#Region "20090814 PUBBodySiteUI 部位檔維護  by tianxie"

    ' 查詢某一部位 
    <OperationContract()> _
    Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As DataSet
    ' 查詢某一部位 
    <OperationContract()> _
    Function queryNhiBodySiteCodeByColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet
    <OperationContract()> _
    Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As DataSet
    '新增部位
    <OperationContract()> _
    Function insertPUBBodySite(ByVal ds As DataSet) As Integer
    '刪除部位
    <OperationContract()> _
    Function deletePUBBodySiteByPK(ByRef pk_Body_Site_Code As String) As Integer
    '更新部位
    <OperationContract()> _
    Function updatePUBBodySite(ByVal ds As DataSet) As Integer

#End Region

#Region "20150915 PUBNhiCodeUI 健保支付標準檔  Add by Runxia"

    ' 查詢特定治療項目基本檔資料 
    <OperationContract()> _
    Function queryPUBMajorNoEquByCond_L(ByVal strMajorcareCode As String) As DataSet

    ' 查詢健保支付標準檔,(檢驗檢查)  
    <OperationContract()> _
    Function queryPUBNhiCodeByCond_L(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet

    '刪除健保支付標準檔
    <OperationContract()> _
    Function deletePUBNhiCodeByInsuCode_L(ByVal strInsuCode As String) As Integer

    '確定儲存 健保支付標準檔
    <OperationContract()> _
    Function confirmPUBNhiCode_L(ByVal saveData As DataSet) As DataSet

    <OperationContract()> _
    Function queryPUBNhiCodeUpDown_L(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet

    <OperationContract()> _
    Function queryPUBNhiDeptCode() As DataSet
#End Region

#Region "20100422 PubPatientSevereDiseaseBO 病患重大傷病記錄檔  Add by Runxia"

    '查詢病患重大傷病記錄檔
    <OperationContract()> _
    Function queryPUBPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date) As DataSet

    '新增病患重大傷病記錄檔
    <OperationContract()> _
    Function insertPUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer

    '刪除病患重大傷病記錄檔
    <OperationContract()> _
    Function deletePUBPatientSevereDisease_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal strEffectDate As String) As Integer

    '修改病患重大傷病記錄檔
    <OperationContract()> _
    Function updatePUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer


    '由Icd_code查詢對應的診斷英文名
    <OperationContract()> _
    Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet

    ''' <summary>
    ''' 病歷號查詢(顯示是否)
    ''' </summary>
    ''' <returns>String) as DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-03</remarks>
    <OperationContract()> _
    Function PUBPatientSevereDiseasequeryByPKYNShow(ByRef pk_Chart_No As String, ByRef pk_Icd_Code As String, ByRef pk_Effect_Date As Date) As DataSet

#End Region

#Region "20150914 PUBPatientHealthCardUI 全國醫療卡維護檔 Add by Will,Lin"

    <OperationContract()> _
    Function queryPUBPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As DataSet

    <OperationContract()> _
    Function queryPubPatientFlagByChartNo_L(ByVal strChartNo As String) As DataSet

    '新增全國醫療服務卡維護檔
    <OperationContract()> _
    Function insertPUBPatientHealthCard_L(ByVal ds As DataSet) As Integer

    <OperationContract()> _
    Function insertPUBHealthAndFlag_L(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer

    <OperationContract()> _
    Function updatePUBPatientHealthCard_L(ByVal ds As DataSet) As Integer

    <OperationContract()> _
    Function deletePUBPatientHealthCard_L(ByVal strChartNo As String, ByVal strEffectDate As String) As Integer

#End Region

#Region "20150911 PUBPhaServicesUI 藥事服務費基本檔 Add by Will,Lin"

    '依條件查詢輸入護理資訊檔資料
    <OperationContract()> _
    Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet

    '新增輸入護理資訊檔資料
    <OperationContract()> _
    Function insertPUBPhaServices(ByVal dsSaveData As DataSet) As Integer

    '刪除輸入護理資訊檔資料
    <OperationContract()> _
    Function deletePUBPhaServicesByPK(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String) As Integer

    '更新輸入護理資訊檔資料
    <OperationContract()> _
    Function updatePUBPhaServices(ByVal dsSaveData As DataSet) As Integer

#End Region

#Region "20150911 PUBDisIdentityUI 優待身份基本檔維護 Add by Will,Lin"

    '查詢優待身份基本資料
    <OperationContract()> _
    Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As DataSet

    '新增優待身份基本檔資料
    <OperationContract()> _
    Function insertPUBDisIdentity(ByVal ds As DataSet) As Integer

    '刪除優待身份基本檔資料
    <OperationContract()> _
    Function deletePUBDisIdentityByPK(ByRef DisIdentityCode As String) As Integer

    '修改優待身份基本檔資料
    <OperationContract()> _
    Function updatePUBDisIdentity(ByVal ds As Data.DataSet) As Integer

#End Region

#Region "20150911 PUBDisIdentitySetUI 優待身分折扣設定檔 add by Will,Lin"

    '依條件查詢
    <OperationContract()> _
    Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String) As System.Data.DataSet

    '新增折扣身分資料
    <OperationContract()> _
    Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150911 PUBAccountUI 費用項目對應檔 add by Will,Lin"

    '依條件查詢費用項目對應檔資料
    <OperationContract()> _
    Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet

    '新增費用項目對應檔
    <OperationContract()> _
    Function insertPUBAccount(ByVal saveData As DataSet) As Integer

    '更新費用項目對應檔
    <OperationContract()> _
    Function updatePUBAccount(ByVal saveData As DataSet) As Integer

    '刪除費用項目對應檔
    <OperationContract()> _
    Function deletePUBAccountByPK(ByVal strAccountId As String) As Integer


#End Region

#Region "20150911 PUBExamineUI 診察費基本檔維護 add by Will,Lin"

    '依條件查詢診察費基本檔資料
    <OperationContract()> _
    Function queryPUBExamineByCond_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                     ByVal strDeptCode As String, ByVal strSectionId As String, _
                                     ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                     ByVal strOrderCode As String) As System.Data.DataSet
    '新增診察費基本檔資料
    <OperationContract()> _
    Function insertPUBExamine_L(ByVal dsSaveData As DataSet) As Integer
    '刪除診察費基本檔資料
    <OperationContract()> _
    Function deletePUBExamineByPK_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                  ByVal strDeptCode As String, ByVal strSectionId As String, _
                                  ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String) As Integer
    '更新診察費基本檔資料
    <OperationContract()> _
    Function updatePUBExamine_L(ByVal dsSaveData As DataSet) As Integer

#End Region

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"

    '查詢
    <OperationContract()> _
    Function queryPUBPartByAll() As DataSet
    '查詢
    <OperationContract()> _
    Function queryPUBSubIdentityForCombo_L() As DataSet
    '查詢
    <OperationContract()> _
    Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String) As DataSet
    '修改
    <OperationContract()> _
    Function confirmPUBPartDiscount(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150910 PUBPartUI 部分負擔基本檔 add by Will,Lin"
    '查詢
    <OperationContract()> _
    Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String) As DataSet
    '新增
    <OperationContract()> _
    Function confirmPUBPart(ByVal saveData As DataSet) As DataSet
#End Region

#Region "20150909 PUBRegisterFeeUI 掛號費基本維護檔 add by Will,Lin"
    '查詢
    <OperationContract()> _
    Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet
    '新增
    <OperationContract()> _
    Function insertPUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer
    '修改
    <OperationContract()> _
    Function updatePUBRegisterFee(ByVal ds As DataSet) As Integer
    '刪除
    <OperationContract()> _
    Function deletePUBRegisterFeeByPK(ByVal pk_Source_Id As String, ByRef pk_Sub_Identity_Code As System.String, ByVal strFirstReg As String, ByRef pk_Dept_Code As System.String, ByRef pk_Section_Id As System.String, ByRef pk_Medical_Type_Id As System.String) As Integer

#End Region

#Region "20150909 PUBPtDisabilityUI 病患殘障記錄檔 add by Will,Lin"
    '查詢
    <OperationContract()> _
    Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet
    '新增
    <OperationContract()> _
    Function insertPUBPtDisability_L(ByVal ds As DataSet) As Integer
    '修改
    <OperationContract()> _
    Function updatePUBPtDisabilityByPK_L(ByVal ds As DataSet) As Integer
    '刪除
    <OperationContract()> _
    Function deletePUBPtDisabilityByPK_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As Integer) As Integer
    '查詢
    <OperationContract()> _
    Function queryPUBSysCodeByTypeIdForDisability_L(ByVal strTypeId As String) As DataSet


#End Region

#Region "20150908 PUBPatientQuotaUI 病患合約機構累積檔 add by Will"


    <OperationContract()> _
    Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String) As DataSet

    <OperationContract()> _
    Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150904 PUBMajorcareUI 特定治療項目基本檔維護 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet

    <OperationContract()> _
    Function insertPUBMajorcare(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function updatePUBMajorcare(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function deletePUBMajorcareByPK(ByVal strMajorcareCode As String) As Integer

#End Region

#Region "20150904 PUBSubIdentityUI 身份二代碼基本檔 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet

    <OperationContract()> _
    Function insertPUBSubIdentity(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function updatePUBSubIdentity(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function deletePUBSubIdentityByPK(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As Integer

#End Region

#Region "20150904 PUBSubIdentitySetUI 身份二代碼計價設定檔維護 add by Will,Lin"

    <OperationContract()> _
    Function confirmPUBSubIdentitySet(ByVal dsSaveData As DataSet) As DataSet

    <OperationContract()> _
    Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                          ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                          ByVal strOrderCode As String) As System.Data.DataSet

#End Region

#Region "20150904 PUBContractUI 合約機構基本檔 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet

    <OperationContract()> _
    Function deletePUBContractByPK(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As Integer

    <OperationContract()> _
    Function insertPUBContract(ByVal dsSaveData As DataSet) As Integer

    <OperationContract()> _
    Function updatePUBContract(ByVal dsSaveData As DataSet) As Integer

#End Region

#Region "20150903 PUBContractQuotaUI 合約機構記賬累積檔維護 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBContractQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet

    <OperationContract()> _
    Function confirmContractQuota(ByVal saveData As DataSet) As DataSet

#End Region

#Region "20150903 PUBContractPartSetUI 合約身份部份負擔記帳設定檔 add by Will,Lin"

    <OperationContract()> _
    Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet

    <OperationContract()> _
    Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet

#End Region

#Region "20150831 PUBContractSetUI 合約身分扣記帳設定維護 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean) As System.Data.DataSet

    <OperationContract()> _
    Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    <OperationContract()> _
    Function queryPUBContractByColumnValue2_L(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    <OperationContract()> _
    Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    <OperationContract()> _
    Function confirmContractSet(ByVal saveData As DataSet) As DataSet


#End Region

#Region "20150831 PUBAddPartUI 加收部分負擔維護檔 add by Will,Lin"

    <OperationContract()> _
    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String) As DataSet

    <OperationContract()> _
    Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet

#End Region

#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    <OperationContract()> _
    Function queryConsuDept_L() As DataSet
#End Region

#Region "20090724 取得登錄人員信息   by Add Ming"
    <OperationContract()> _
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet
#End Region

#Region "20090703 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取PUBSysCodeBO資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

    <OperationContract()> _
    Function queryPUBSysCodeByIcdCodingQuery_L() As DataSet
#End Region

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    <OperationContract()> _
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet

    <OperationContract()> _
    Function queryPUBSheetByCode_L(ByVal strDeptCode As String) As DataSet
#End Region

#Region "20090708 PUBDepartmentBO_E1 取得科系資料來源 by Add Johsn"
    <OperationContract()> _
    Function queryPUBDepartmentCode() As DataSet
#End Region

#Region "20100527 add by Merry 費用項目對應檔維護- 依傳入TypeID取得代碼檔資料"
    <OperationContract()> _
    Function queryPUBSysCode_L(ByVal TypeID As String) As DataSet
#End Region

#Region "20091012 查詢  轉診回覆  by Add ChenYang"
    <OperationContract()> _
    Function queryPubPatientByPK_L(ByRef pk_Chart_No As System.String) As DataSet
    <OperationContract()> _
    Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As DataSet
#End Region

#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"
    <OperationContract()>
    Function querySheetCode_L(ByVal strPubSheetCode As String) As DataSet
#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    <OperationContract()> _
    Function queryprisendInfo_L() As DataSet
#End Region
#Region "20100112 排成醫令維護    by Add Coco"
    <OperationContract()>
    Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String) As DataSet
#End Region
#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
#End Region
#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    <OperationContract()>
    Function queryPUBDeptCodeNameCA3() As DataSet
#End Region
#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "
    <OperationContract()> _
    Function queryPUBPostalCodeForCountryName_L() As DataSet
    <OperationContract()> _
    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet
    <OperationContract()> _
    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet
    <OperationContract()> _
    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet
#End Region

#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    <OperationContract()>
    Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet
#End Region

#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    <OperationContract()> _
    Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String
    <OperationContract()> _
    Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As System.Data.DataSet
#End Region


#Region "20090824 PUBBodySiteBO 查詢有效部位檔資料  by windfog"
    ''' <summary>
    ''' 查詢有效部位檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function queryPUBBodySiteUnDelete() As DataSet
#End Region

#Region "20100303 獲得所屬部門下的所有部門   by Add ming"
    <OperationContract()> _
    Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet


#End Region

#Region "20100526 PUBDepartmentBO_E2  次專科基本檔所屬科別combobox資料  add by liuye"
    <OperationContract()> _
    Function queryPUBDepartmentEffectByColumnValue_L(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet
#End Region

#Region "20090724 所屬單位查詢醫師信息   by Add Ming"
    <OperationContract()> _
    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As DataSet
    <OperationContract()> _
    Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet
#End Region

#Region "20100622  常用維護科別資料來源 add by coco"
    <OperationContract()> _
    Function queryRefferalDeptOMO_L() As DataSet
#End Region

#Region "2012/05/24 與RuleTransfer_N1關聯的切出部分(PUBRuleTransferN1BS_E2) by liuye"

    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-5-24</remarks>
    <OperationContract()> _
    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer

#End Region

#Region "20100427 查詢 PUBConfigBO_E2 ,add by Mark"

    ''' <summary>
    ''' 查詢 PUBConfigBO_E2
    ''' </summary>
    ''' <param name="pk_Config_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function queryPUBConfigByPK_L(ByVal pk_Config_Name As String) As System.Data.DataSet
#End Region

#Region "20091012 PUPHospitalBO_E2 根據傳入時間查詢 by Add Tor"
    <OperationContract()> _
    Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As DataSet
#End Region

#Region "20091030 取得外國國籍名稱 , Add by tony"
    <OperationContract()> _
    Function queryNationalName_L() As DataSet
#End Region

#Region "20091030 取得居住地區欄位 , Add by tony"
    <OperationContract()> _
    Function queryAreaCode_L() As DataSet
#End Region

#Region "20091103 取得肺結核資料 , Add by tony"
    <OperationContract()> _
    Function queryTuberculosis_L() As DataSet
#End Region

#Region "20090818 PUBSyscodeBO 公用代碼檔維護  by mark"
    <OperationContract()> _
    Function queryPUBSyscodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
#End Region

#Region ""

    ''' <summary>
    ''' 查診展班週數
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-10</remarks>
    <OperationContract()> _
    Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet

#End Region

#Region "'檢驗檢查 檢體欄位顯示 根據某一個OrderCode 設定檢體ComboBox資料"
    <OperationContract()> _
    Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet

#End Region

#Region "20150918 PUBPatientDisabilityUI 病患殘障紀錄檔   by Will,Lin"

    <OperationContract()> _
    Function queryPUBPatientDisabilityByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet

    <OperationContract()> _
    Function confirmPUBPatientDisability_L(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer

    <OperationContract()> _
    Function queryMaxPatientDisabilityNo_L(ByVal strChartNo As String) As DataSet

#End Region

#Region " 20150915 PUBPatientBO_E2 根據病歷號查詢 ,add by Remote"
    ''' <summary>
    ''' 依條件查詢國際疫苗申請書輸入
    ''' </summary>
    ''' <param name="strChart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <OperationContract()> _
    Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet

#End Region

#Region "2015/10/20 檢核規則維護 成醫舊程式搬移 by HE,Alien"

    <OperationContract()> _
    Function queryByPkRuleCode(ByVal pk_Rule_Code As System.String) As DataSet

    <OperationContract()> _
    Function deleteByPkRuleCode(ByVal pk_Rule_Code As System.String) As Integer

    <OperationContract()> _
    Function initPUBRuleCheckUIInfo() As DataSet

    <OperationContract()> _
    Function initPUBRuleQueryInfo() As DataSet

    <OperationContract()> _
    Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet

    <OperationContract()> _
    Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

    <OperationContract()> _
    Function querySelectedRuleData(ByVal selectRuleCode As String) As DataSet

    <OperationContract()> _
    Function deleteRuleData(ByVal ruleCode As String) As Boolean

    <OperationContract()> _
    Function getRuleSerialNo() As String

    <OperationContract()> _
    Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet

    <OperationContract()> _
    Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet

    <OperationContract()> _
    Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable

    '記錄使用者更新或刪除檢核規則
    <OperationContract()> _
    Function InsertPUB_Rule_Transaction_Log(ByVal ds As DataSet) As Integer

    ''' <summary>
    ''' 改名稱
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()> _
    Function getExprre(ByVal ds As String) As String
#End Region

#Region "2015/10/26 檢核規則維護 成醫舊程式搬移 by HE,Alien"

    <OperationContract()> _
    Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

    <OperationContract()> _
    Function getRuleMaintainSerialNo() As Integer

    <OperationContract()> _
    Function initPUBRuleTreeQueryInfo() As DataSet

    <OperationContract()> _
    Function querySelectedTreeRuleData(ByVal selectRuleCode As String) As DataSet

    <OperationContract()> _
    Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet


#End Region

#Region "20100809 病歷量審查作業 add by Johsn"

    <OperationContract()> _
    Function queryPUBDoctorByDoctorCode2_L(ByVal DoctorCode As String) As DataSet

#End Region

#Region "20120326 取得病患資料及戶籍地 , Add by Runxia"
    ''' <summary>
    ''' 取得病患資料及戶籍地
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>by Runxia on 2012-3-26</remarks>
    <OperationContract()> _
    Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet

#End Region
#Region "20090724 員工編號查詢醫師信息   by Add Ming"
    <OperationContract()> _
    Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As DataSet
#End Region
#Region "2012/04/02 科室/團隊查詢(PUBDepartmentBO_E2) by liuye"

    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    <OperationContract()> _
    Function queryPUBDepartmentCodeIsIpdDeptY_L() As DataSet


#End Region

#Region "2016/04/22 add by Kaiwen 醫令項目代碼對應健保碼  "
    <OperationContract()> _
    Function queryPubOrderByOrderCode2_L(ByVal strOrderCode As String) As DataSet

    <OperationContract()> _
    Function queryPubNhiCode_L(ByVal strInsuCode As String) As DataSet

    <OperationContract()> _
    Function queryPubInsuCode_L(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataSet

    <OperationContract()> _
    Function deletePubInsuCode_L(ByVal ds As DataSet) As Integer

    <OperationContract()> _
    Function queryPubInsuCodeBySeqNo_L(ByVal strOrderCode As String) As DataSet

    <OperationContract()> _
    Function confirmPUBInsuCode_L(ByVal saveData As DataSet) As DataSet

    '取得OrderCode對應的健保碼
    <OperationContract()> _
    Function queryPubInsuCodeByOrderCode_L(ByVal strOrderCode As String) As DataSet
#End Region

#Region "2016/04/22 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Kaiwen"

    ''' <summary>
    ''' 醫令項目代碼對應健保碼修改
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen Yang on 2012-5-14</remarks>
    <OperationContract()> _
    Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet) As Integer


#End Region

#Region "20160507 PUBSysCodeBO 檢驗組別,IO類別(PUBSysCodeBO_E2) Add by Remote"
    <OperationContract()> _
    Function querySpicemenType() As DataSet

#End Region

#Region "2016/05/11 MDC15重大外傷診斷碼維護作業(DRG_MDC15_Diagnosis) by Xiaozhi,Yu"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    <OperationContract()> _
    Function PUBInsuDeptdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    <OperationContract()> _
    Function PUBInsuDeptQueryByPKROC(ByRef Insu_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    <OperationContract()> _
    Function queryAllROC() As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    <OperationContract()> _
    Function PUBInsuDeptInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-07</remarks>
    <OperationContract()> _
    Function PUBInsuDeptUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#End Region


#Region "20160518 PUBPreventiveCare 預防保健基本檔設定維護 ,add by Remote"


#Region "  新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    '''  <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function PUBPreventiveCareInsert(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "  修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    '''  <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function PUBPreventiveCareUpdate(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function PubPreventiveCareDeleteByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As Integer

#End Region

#Region "  以PK查詢資料 "

    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    '''  <remarks>by Remote_Liu on 2016-05-11</remarks>
    <OperationContract()> _
    Function PUBPreventiveCareQueryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As System.Data.DataSet

#End Region

#Region "  查詢全部 "

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    '''  <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function PUBPreventiveCareQueryAll() As System.Data.DataSet

#End Region

#Region "  查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    '''  <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function PUBPreventiveCareQueryByLikePK(ByRef pk_Care_Item_Code As System.String) As System.Data.DataSet

#End Region

#Region "  取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    <OperationContract()> _
    Function queryPUBCareItemAgeSex() As DataSet

#End Region

#End Region

#Region "2016-05-19 PUBSubIdentityBO_E2 身份二查詢  Add by Xiaozhi"
    <OperationContract()> _
    Function queryPUBSubMedicalType() As DataSet

#End Region

#Region "2016/05/24 五都戶籍地設定維護(PUBAreaCodeNSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    <OperationContract()> _
    Function PUBAreaCodeNdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    <OperationContract()> _
    Function PUBAreaCodeNQueryByPKROC(ByRef Insu_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    <OperationContract()> _
    Function queryAreaCodeAll() As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    <OperationContract()> _
    Function PUBAreaCodeNInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-24</remarks>
    <OperationContract()> _
    Function PUBAreaCodeNUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "2016/05/25 行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBAreaCodeGovdeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(縣市代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBAreaCodeGovQueryByPKROC(ByRef Gov_County_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function queryAreaCodeGovAll() As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBAreaCodeGovInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBAreaCodeGovUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "2016/05/26 郵遞區號對應戶籍地設定維護(PUBPostalAreaSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 以所有PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalAreaQueryByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 查詢全部()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function queryPostalAreaAll() As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "2016/05/27 郵遞區號對應行政區設定維護(PUBPostalGovAreaSetupUI) by Xiaozhi"

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalGovAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalGovAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet


    ''' <summary>
    ''' 查詢全部()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function queryPostalGovAreaAll() As System.Data.DataSet


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalGovAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBPostalGovAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

#End Region

#Region "20160601  資料來源Type_Id = '128'(PUBSysCodeBO_E2) Add by Remote"
    <OperationContract()> _
    Function queryPUBSysCodeSourceId() As DataSet

#End Region

#Region "20160606 查詢病歷關系"
    <OperationContract()> _
    Function queryPUBPatientContactByCond_L(ByVal strChartNo As String) As System.Data.DataSet
#End Region

#Region "2016/06/28 ICD9_ICD10對照檔(PUB_Disease_ICD10_Mapping) by Li,Han"

    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappinginsertData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingupdateData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingdeleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As Integer

    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingqueryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingqueryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingquertCmbData() As DataSet

    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    <OperationContract()> _
    Function PUBDiseaseICD10MappingfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer

#End Region
#Region "20160620 由來源,病歷號,就診日期 取得就醫序號 by remote_liu "
    <OperationContract()> _
    Function queryMedicalSn(ByVal inParam() As String) As DataSet

#End Region

#Region "20160620 由病歷號,就診日期 取得媽媽姓名 by remote_liu "
    <OperationContract()> _
    Function queryMotherName(ByVal inParam() As String) As DataSet

#End Region

#Region "20160620 護理站 by remote_liu "
    <OperationContract()> _
    Function queryStationNo() As DataSet

#End Region

#Region "2016/06/29 ICD10科別對照檔(PUB_ICD10_Dept) by Li,Han"

    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptinsertData(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptdeleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String) As Integer

    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptqueryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Gird資料ByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptqueryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptqueryCmbData(ByRef strTBName As String, ByRef strWhere As String) As DataSet

    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    <OperationContract()> _
    Function PUBICD10DeptfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer

#End Region

#Region "  2016/06/28 取得手術法(PUBOrderBO_E2) by Remote    "
    <OperationContract()> _
    Function PUBOrderOrderName(ByVal inParam() As String) As DataSet

#End Region

#Region "  2016/06/28 取得費用(PUBOrderPriceBO_E2) by Remote    "
    <OperationContract()> _
    Function PUBOrderPrice(ByVal inParam() As String) As DataSet

#End Region

#Region "     2016/06/29 傷口分類(PUBSysCodeBO_E2) by Remote "
    <OperationContract()> _
    Function PUBSyscodeWoundType() As DataSet

#End Region

#Region "     2016/06/29 部位(PUBBodySiteBO_E2) by Remote  "
    <OperationContract()> _
    Function PUBBodySiteBodyparts() As DataSet

#End Region

#Region "    2016/06/98 側位 by Remote(PUBSysCodeBO_E2)  "
    <OperationContract()> _
    Function PUBSyscodeBodySide() As DataSet

#End Region

#Region "     2016/07/05 急作手術分級(PUBSysCodeBO_E2) by Remote "
    <OperationContract()> _
    Function PUBSyscodeUrgentClass() As DataSet

#End Region

#Region "20160813 PUBSheetBO 檢驗單資料for ComboBox by Add Remote"
    <OperationContract()> _
    Function queryPUBSheetCode() As DataSet

#End Region
#Region "2016/09/09 add by qun 依據健保碼內容查詢主手術碼設定下拉選單"
    <OperationContract()> _
    Function queryICD10PCS_Code(ByVal strInsuCode As System.String) As DataSet
#End Region

#Region "2016/09/23 新增非藥品替代醫令檔(PUBOrderAlternativeUI) by Xiaozhi"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBOrderAlternativeInsertByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by  Elly on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBOrderAlternativeUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBOrderAlternativedeleteChoose(ByVal dsDelete As DataSet) As Integer

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    <OperationContract()> _
    Function PUBOrderAlternativequeryByPKOrderCode(ByRef Postal_Code As System.String) As System.Data.DataSet

#End Region

#Region "20090820 PUBOrderStandingBO 常備醫令檔 Add by william"
    '查詢
    <OperationContract()> _
    Function queryPUBOrderStandingByCond(ByVal strDept_Code As String, ByVal strOrder_Code As String) As DataSet
    '新增
    <OperationContract()> _
    Function insertPUBOrderStanding(ByVal saveData As DataSet) As Integer
    '刪除
    <OperationContract()> _
    Function deletePUBOrderStandingByPK(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Int32, ByVal strConsumption_Dept As String) As Integer
    '更新
    <OperationContract()> _
    Function updatePUBOrderStanding(ByVal saveData As DataSet) As Integer
    '時間區間是否符合
    <OperationContract()> _
    Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean

    '查詢科別/護理站的下拉式選單內容
    <OperationContract()> _
    Function queryPUBOrderStandingByDept() As DataSet

#End Region

#Region "          2017/1/16 非藥品替代醫令檔維護 add by Michelle"

    '新增
    <OperationContract()> _
    Function insertPUBOrder(ByVal dsData As DataSet) As Integer

    '修改
    <OperationContract()> _
    Function updatePUBOrder(ByVal dsData As DataSet) As Integer

    '刪除
    <OperationContract()> _
    Function DeletePUBOrder(ByVal dsDelete As DataSet) As Integer

#End Region

End Interface
