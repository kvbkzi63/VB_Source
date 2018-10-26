Imports System.Data
Imports System.Collections.Generic

' 注意: 若變更此處的類別名稱 "IUclService"，也必須更新 Web.config 中 "IUclService" 的參考。
<ServiceContract()>
Public Interface IUclService

#Region "20090312 add by AlanTsai, 代碼基本檔查詢"
    '==================================================================================================
    '=程式名稱：代碼基本檔查詢
    '=程式版本：ver 1.0
    '=開發日期：20090312
    '=開發人員：AlanTsai
    '=備註：Return Data Set
    '==================================================================================================
    <OperationContract()>
    Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, Optional ByVal OtherQueryConditionDS As DataSet = Nothing) As DataSet

#End Region

#Region "20090409 add by James, 戶籍地查詢"
    '==================================================================================================
    '=程式名稱：戶籍地查詢
    '=程式版本：ver 1.0
    '=開發日期：20090409
    '=開發人員：James
    '=備註：Return Data Set
    '==================================================================================================

    <OperationContract()>
    Function queryUclPostalAreaAll() As DataSet

    <OperationContract()>
    Function queryUclPostalAreaAllNew() As DataSet

    <OperationContract()>
    Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As DataSet

#End Region

#Region "20090602 add by James, 共用元件-身份別連動設定"
    <OperationContract()>
    Function queryUclIdentityInitial() As DataSet
    <OperationContract()>
    Function queryUclIdentityInitial2(ByVal inSourceType As String) As DataSet

#End Region

#Region "20090414 add by James, 病歷號查詢"
    '==================================================================================================
    '=程式名稱：病歷號查詢
    '=程式版本：ver 1.0
    '=開發日期：20090414
    '=開發人員：James
    '=備註：Return Data Set
    '==================================================================================================

    <OperationContract()>
    Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet
#End Region

    '#Region "20090511 共用元件-ComboBoxGrid  by James"
    '    '==================================================================================================
    '    '=程式名稱：共用元件-ComboBoxGrid
    '    '=程式版本：ver 1.0
    '    '=開發日期：20090511
    '    '=開發人員：James
    '    '=備註：Return Data Set
    '    '==================================================================================================

    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function queryOMOFavorByFavorId(ByVal favorId As String, _
    '                                       ByVal doctorDeptCode As String, _
    '                                       ByVal favorTypeId As String, _
    '                                       ByVal favorCategory As String, _
    '                                       ByVal code As String, _
    '                                       ByVal codeName As String _
    '                                     ) As DataSet


    '隨輸隨選 醫囑診斷 PUB_Disease
    <OperationContract()>
    Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

    '隨輸隨選 藥品 OPH_Pharmacy_Base
    <OperationContract()>
    Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, Optional ByVal IsEqualMatch As String = "N") As DataSet



    <OperationContract()>
    Function DoUclAction(ByVal ds As DataSet) As DataSet

    '隨輸隨選 醫令 PUB_Order
    <OperationContract()>
    Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, Optional ByVal BasicDateStr As String = "") As DataSet


    '#Region "控管項目維護-同類藥"
    '    ''' <summary>
    '    ''' 查詢藥名
    '    ''' </summary>
    '    ''' <param name="Pharmacy_12_code">成大十二碼藥名</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    <OperationContract()> _
    '<FaultContract(GetType(WCFFaultContractException))> _
    '    Function OPHControlItemQueryDrug(ByVal Pharmacy_12_code As String) As DataSet
    '#End Region
    '#End Region

    '#Region "20090602 add by James, 共用元件-身份別連動設定"
    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function queryUclIdentityInitial() As DataSet
    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function queryUclIdentityInitial2(ByVal inSourceType As String) As DataSet
    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function getPfamKindFromNCKM_CommonDB_PfamDT(ByVal idNo As String) As String
    '#End Region

#Region "20100121 add by AlanTsai, SMTP設定查詢"
    '==================================================================================================
    '=程式名稱：SMTP設定查詢
    '=程式版本：ver 1.0
    '=開發日期：20100121
    '=開發人員：AlanTsai
    '=備註：Return Data Set
    '==================================================================================================
    <OperationContract()>
    Function querySMTPData() As DataSet

#End Region

    '#Region "2011/01/17, Add By 谷官, UCLIcdCode"
    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function get3FrontIcdCode(ByVal outpatientSn As String, ByVal sysFlag As String) As DataTable
    '    <OperationContract()> _
    '    <FaultContract(GetType(WCFFaultContractException))> _
    '    Function getIcdDataForChangeIdentityUI(ByVal chartNo As String, ByVal outpatientSn As String, ByVal opdVisitDate As Date, ByVal sysFlag As String) As DataTable
    '#End Region


#Region "2013/02/23 給藥確認提示說明作業(UclHintDataBO) by Sean.Lin"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    <OperationContract()>
    Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer



    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    <OperationContract()>
    Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As System.Data.DataSet



    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    <OperationContract()>
    Function UclHintDataBOdelete(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As Integer



    ''' <summary>
    ''' 更新資料庫內容
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    <OperationContract()>
    Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer



    ''' <summary>
    ''' 查詢提示資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    <OperationContract()>
    Function UclHintDataBOqueryData(ByVal UIName As String) As DataSet

    ''' <summary>
    ''' 查詢提示資料全部
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-3-6</remarks>
    <OperationContract()>
    Function UclHintDataBOqueryDataAll() As DataSet


#End Region

#Region "2015/04/10 共用元件-片語查詢(UCLPhraseBO_E1)  by Alan.Tsai"

    ''' <summary>
    ''' 片語查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2015-4-10</remarks>
    <OperationContract()>
    Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As DataSet

#End Region

#Region "2015/04/16 共用元件-常用醫令查詢(UCLOrderFavorDialogUI)  by Alan.Tsai"

    '1
    <OperationContract()>
    Function queryOMOOrderFavorInit(ByVal queryData As DataSet) As DataSet

    '2
    <OperationContract()>
    Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String,
                                       ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String,
                                       ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String,
                                       ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As DataSet

    '3
    <OperationContract()>
    Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As DataSet

    '4
    <OperationContract()>
    Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, Optional ByVal inHospCode As String = "") As DataSet
    '5
    <OperationContract()>
    Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                     ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String,
                                                     ByVal IsChoiceDcOrder As String) As DataSet

    '6
    <OperationContract()>
    Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                      ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String,
                                                      ByVal IsChoiceDcOrder As String) As DataSet

    <OperationContract()>
    Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                             ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, ByVal IsChoiceDcOrder As String) As DataSet

    '7
    <OperationContract()>
    Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As DataSet
    '8
    <OperationContract()>
    Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As DataSet

    '9
    <OperationContract()>
    Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet

    '10
    <OperationContract()>
    Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet

    '11
    <OperationContract()>
    Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String,
                                            ByVal OrderTypeId As String,
                                            ByVal DrugType As String,
                                            ByVal FavorId As String,
                                            ByVal DoctorDeptCode As String,
                                            ByVal PackageCode As String,
                                            ByVal ChartNo As String,
                                            ByVal OutpatientSn As String,
                                            ByVal IsChoiceDcOrder As String) As DataSet

    '12
    <OperationContract()>
    Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As DataSet

    '13
    <OperationContract()>
    Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String,
                                      ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String,
                                      ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String,
                                      ByVal IsChoiceDcOrder As String) As DataSet

    '14
    <OperationContract()>
    Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

    '15
    <OperationContract()>
    Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As DataSet

    '16
    <OperationContract()>
    Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet

    '17
    <OperationContract()>
    Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String,
                                   ByVal DoctorCode As String, ByVal DeptCode As String,
                                   ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

    '18
    <OperationContract()>
    Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As DataSet

    '19
    <OperationContract()>
    Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

    '20
    <OperationContract()>
    Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As DataSet

    '21
    <OperationContract()>
    Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String,
                            ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String,
                            ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String,
                            ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet

#End Region

#Region "2012-06-06 查詢 Print Condition"

    ''' <summary>
    ''' 查詢 Print Condition
    ''' </summary>
    ''' <param name="Param">查詢參數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract>
    Function QueryPrintCondition(ByVal Param As Dictionary(Of String, Object)) As DataSet

    ''' <summary>
    ''' 取得登入者Term_Code所囑之Print Condition
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract>
    Function GetLoginUserPrintCond(ByVal Param As Dictionary(Of String, Object)) As DataTable

#End Region

End Interface
