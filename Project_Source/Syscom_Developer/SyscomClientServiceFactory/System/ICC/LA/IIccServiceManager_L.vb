Public Interface IIccServiceManager_L

#Region "20090909 已上傳歷史資料維護  ICC_Health_Upload & ICC_Inoculation_Upload, add by  Jianhui"
    Function queryICCHealthUploadandICCInoculationUploadByCond(ByVal strUploadTypeId As String _
                                                  , ByVal strChartNo As String _
                                                  , ByVal strSourceSn As String _
                                                  , ByVal strCreateSearchTime As String _
                                                  , ByVal strA00 As String _
                                                  , ByVal strA01 As String _
                                                  , ByVal strA17 As String _
                                                  , ByVal strIsBabyStool As String _
                                                  , ByVal strA12 As String) As System.Data.DataSet

    Function queryICCHealthUploadandICCInoculationUploadByCond2(ByVal strUploadTypeId As String _
                                                 , ByVal strChartNo As String _
                                                 , ByVal strSourceSn As String _
                                                 , ByVal strCreateSearchTime As String _
                                                 , ByVal strA00 As String _
                                                 , ByVal strA01 As String _
                                                 , ByVal strA17 As String _
                                                 , ByVal strIsBabyStool As String _
                                                 , ByVal strA12 As String) As System.Data.DataSet

    Function queryICCHealthUploadandICCInoculationUploadByPage1Cond(ByVal strUploadTypeId As String _
                                                  , ByVal strChartNo As String _
                                                  , ByVal strSourceSn As String _
                                                  , ByVal strCreateSearchTime As String _
                                                  , ByVal strA00 As String _
                                                  , ByVal strA01 As String _
                                                  , ByVal strA17 As String _
                                                  , ByVal strIsBabyStool As String _
                                                  , ByVal strA12 As String) As System.Data.DataSet

    Function updateICCHealthUpload(ByVal strCancelUser As String _
                                         , ByVal strChartNo As String _
                                         , ByVal strSourceSn As String) As Integer

    Function updateICCInoculationUpload(ByVal strCancelUser As String _
                                        , ByVal strChartNo As String _
                                        , ByVal strSourceSn As String) As Integer

    Sub deleteICCInoculationUploadBS(ByVal dsSaveData As DataSet)
#End Region

#Region "20090911 新增預防接種資料 add by Johsn "
    Function insertICCInoculationUpload(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20090911 新增健保就醫資料 ICCCreateHealthUploadBS   Add by Yunfei"
    Function insertICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer
#End Region


#Region "20090914 自行檢核錯資料_檢核條件_是否為必要欄位  ICC_Must_Field_Verify, add by  Jianhui"

    '''''''''''''' 是否為必要欄位

    Function queryICCMustFieldVerify(ByVal strTreatmentCategoryId As String) As DataSet
    Function insertICCMustFieldVerify(ByVal ds As DataSet) As Integer
    Function updateICCMustFieldVerify(ByVal ds As DataSet) As Integer
    Function deleteCCMustFieldVerify(ByVal pkid As String) As Integer
    '''''''''''''' 欄位長度范圍
    Function queryIccFieldLengthVerify(ByVal strId As String) As DataSet
    Function insertIccFieldLengthVerify(ByVal ds As DataSet) As Integer
    Function updateIccFieldLengthVerify(ByVal ds As DataSet) As Integer
    Function deleteIccFieldLengthVerify(ByVal pkid As String) As Integer
    '''''''''''''' 欄位 自身檢核
    Function queryIccSelfVerify(ByVal strId As String) As DataSet
    Function insertIccSelfVerify(ByVal ds As DataSet) As Integer
    Function updateIccSelfVerify(ByVal ds As DataSet) As Integer
    Function deleteIccSelfVerify(ByVal pkid As String) As Integer
    ''''''''''''''	交叉資料檢核
    Function queryIccInteractVerify1ById(ByVal strId As String) As DataSet
    Function insertIccInteractVerify1(ByVal ds As DataSet) As Integer
    Function updateIccInteractVerify1(ByVal ds As DataSet) As Integer
    Function deleteIccInteractVerify1(ByVal pkid As String) As Integer
    '''''''''''''' 5.	交叉資料檢核2
    Function queryIccInteractVerify2ById(ByVal strId As String) As DataSet
    Function insertIccInteractVerify2(ByVal ds As DataSet) As Integer
    Function updateIccInteractVerify2(ByVal ds As DataSet) As Integer
    Function deleteIccInteractVerify2(ByVal pkid As String) As Integer
    '''''''''''''' 	交叉資料檢核3
    Function queryIccInteractVerify3ById(ByVal strId As String) As DataSet
    Function insertIccInteractVerify3(ByVal ds As DataSet) As Integer
    Function updateIccInteractVerify3(ByVal ds As DataSet) As Integer
    Function deleteIccInteractVerify3(ByVal pkid As String) As Integer
    '''''''''''''' 	交叉資料檢核4
    Function queryIccInteractVerify4ById(ByVal strId As String) As DataSet
    Function insertIccInteractVerify4(ByVal ds As DataSet) As Integer
    Function updateIccInteractVerify4(ByVal ds As DataSet) As Integer
    Function deleteIccInteractVerify4(ByVal pkid As String) As Integer

    Function queryICCOnlineCheckById(ByVal strId As String) As DataSet
    Function insertICCOnlineCheckById(ByVal ds As DataSet) As Integer
    Function updateICCOnlineCheckById(ByVal ds As DataSet) As Integer
    Function deleteICCOnlineCheckById(ByVal pkid As String) As Integer

    Function queryDeletekeystateByInoculationSn(ByVal strId As String) As DataSet
      
#End Region

#Region "20090914 檢視預防接種資料 add by Johsn"
    '新增資料
    Function insertICCBacterinUpload(ByVal dsSaveData As DataSet) As Integer
    '修改資料
    Function updateICCInoculationUploadBS(ByVal dsSaveData As DataSet) As Integer
    '查詢資料
    Function queryICCInoculationUploadByPK(ByVal strInoculationSn As String) As DataSet
    '儲存資料
    Function confirmICCInoculationUploadBS(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20090916 檢視健保就醫資料 add by Yunfei"
    '新增資料
    Function insertICCOrderUpload(ByVal dsSaveData As DataSet) As Integer
    '修改資料
    Function updateICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer
    '查詢資料
    Function queryICCHealthOrderUpload(ByVal strHealthSn As String) As DataSet
    '儲存資料
    Function confirmICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20100105 查詢已上傳資料 add by Yi "
    Function queryICCInoculationUpload(ByVal strInoculationSn As String) As System.Data.DataSet
    Function deleteICCInoculationUploadByPk(ByVal pkId As String) As Integer
    Function queryA24ByOutpatient_Sn_L(ByVal strInoculationSn As String) As System.Data.DataSet
    Function updateICCInoculationUploadByPk_L(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20110816 疫苗批號補正 Inoculation_Sn , add by Runxia"
    Function queryICCInoculationSn_L(ByVal strChartNo As String) As System.Data.DataSet
#End Region

#Region "20150805 IccCloudDrugPatientBO 雲端藥歷轉檔同意書名單登錄  , add by Runxia"

   ' 依條件查詢雲端藥歷轉檔同意書名單
    Function QueryIccCloudDrugPatientByCond(ByVal strIdno As String, ByVal dMedicalDate As String) As DataSet

   ' 新增雲端藥歷轉檔同意書名單
    Function InsertIccCloudDrugPatient(ByVal dsSaveData As DataSet) As Integer
       
    ' 依據PK刪除雲端藥歷轉檔同意書名單
    Function DeleteIccCloudDrugPatientByPK(ByVal strIdno As String, ByVal dMedicalDate As DateTime) As Integer
       
    ' 更新雲端藥歷轉檔同意書名單
   Function UpdateIccCloudDrugPatient(ByVal dsSaveData As DataSet) As Integer
#End Region

#Region "20151209 IccAlertRecQueryBO_E2 雲端藥歷重複用藥查詢 add by Runxia"

    ''' <summary>
    ''' 雲端藥歷重複用藥查詢
    ''' </summary>
    ''' <param name="Query_Type">查詢類別</param>
    ''' <param name="ST_Visit_Date">就醫日期(起)</param>
    ''' <param name="ED_Visit_Date">就醫日期(迄)</param>
    ''' <param name="Chart_No">病歷號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryIccAlertRecByCond(ByRef Query_Type As String, ByVal ST_Visit_Date As String, ByVal ED_Visit_Date As String, ByVal Chart_No As String) As DataSet
#End Region

#Region "20160106 IccCloudPatientBO_E2 雲端藥歷同意書登錄查詢  , add by Brian"

    ' 依條件查詢雲端藥歷同意書登錄名單
    Function QueryIccCloudPatientQryByCond(ByVal Query_Type As String, ByVal dCreate_Time As String, ByVal dModified_Time As String, ByVal IdNo As System.String) As DataSet

#End Region
End Interface



