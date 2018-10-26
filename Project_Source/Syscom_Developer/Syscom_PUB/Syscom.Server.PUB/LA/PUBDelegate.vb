Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection
''' <summary>
''' 加入REF所需之BO，沒有用到的BO我都註解掉，如果你有加入其他BO的話請記得把對應的註解拿掉
''' </summary>
''' <remarks>
''' Created in  2015/4/29, 下午 03:05 by Chris
''' </remarks>
Partial Public Class PUBDelegate


#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"
    Function queryPUBContractsForBILRPT09460() As DataSet
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.queryPUBContractsForBILRPT09460()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region " Add by Elly.Gao on 2016/12/27 for 兵檢資料轉換作業 OHMConvertMilitaryExcelUI"
    Function queryAreaCodeGovByGovADist(ByVal strGovAndDistCode As String) As DataSet
        Dim instance As New PUBAreaCodeGovBO_E2
        Try
            Return instance.queryAreaCodeGovByGovADist(strGovAndDistCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region


#Region "20090616 PUBDepartmentBO 科室檔維護  , add by Syscom Ming"
    '依條件查詢科室檔資料
    Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentByCond(strDeptCode, strDeptName, strDeptEnName)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    '新增科室檔資料
    Function insertPUBDepartment(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    '刪除科室檔資料
    Function deletePUBDepartment(ByVal strDeptCode As String) As Integer
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.delete(strDeptCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    '更新科室檔資料
    Function updatePUBDepartment(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "
    Function queryPUBPostalCodeForCountryName_L() As DataSet
        Dim instance As New PUBPostalCodeBO_E2
        Try
            Return instance.queryPUBPostalCodeForCountryName()
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet
        Dim instance As New PUBPostalCodeBO_E2
        Try
            Return instance.queryPUBPostalCodeForTownName(strCountryName)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet
        Dim instance As New PUBPatientBO_E2
        Try
            Return instance.queryPUBPatientForOMODiagnosisCertificate(strChartNo)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet
        Dim instance As New PUBDoctorLicenseBO_E2
        Try
            Return instance.queryPUBDoctorLicenseByEmployeeCode(EmployeeCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20090624 PUBMajorcareBO 特定治療項目基本檔維護  , add by Syscom Johsn"
    '查詢特定治療項目基本檔資料
    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet
        Dim instance As New PUBMajorcareBO_E2
        Try
            Return instance.queryPUBMajorcareByCond(strMajorcareCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增特定治療項目基本檔資料
    Function insertPUBMajorcare(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PubMajorcareBO
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除特定治療項目基本檔資料
    Function deletePUBMajorcareByPK(ByVal strMajorcareCode As String) As Integer
        Dim instance As New PubMajorcareBO
        Try
            Return instance.delete(strMajorcareCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '更新特定治療項目基本檔資料
    Function updatePUBMajorcare(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PubMajorcareBO
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090624 PUBPartBO 部份負擔基本檔維護  , add by Syscom flag"
    '查詢部份負擔基本檔資料
    Public Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String) As DataSet
        Dim instance As New PUBPartBO_E2
        Try
            Return instance.queryPUBPartByCond(dateEffectDate, strPartCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090625 PUBPartBS 部份負擔基本檔維護  , add by Syscom flag"
    '確定儲存健保部份負擔資料
    Public Function confirmPUBPart(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBPartBS_E2
        Try
            Return instance.confirmPUBPart(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region


#Region "20090721 PUBPartDiscountBO 部份負擔優待基本檔維護  , add by syscom coco"
    '查詢部份負擔基本檔資料
    Public Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String) As DataSet
        Dim instance As New PUBPartDiscountBO_E2
        Try
            Return instance.queryPUBPartDiscountByCond(dateEffectDate, strDisIdentityCode, strPartCode, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20090721 PUBPartBO 部份負擔基本檔維護 查詢全部 , add by syscom coco"
    '查詢部份負擔基本檔資料
    Public Function queryPUBPartByAll() As DataSet
        Dim instance As New PUBPartDiscountBO_E2
        Try
            Return instance.queryPUBPartByAll()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBPartDiscountBS 部份負擔優待基本檔維護  , add by syscom coco"
    '確定儲存健保部份負擔資料
    Public Function confirmPUBPartDiscount(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBPartDiscountBS_E2
        Try
            Return instance.confirmPUBPartDiscount(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090625 PUBDepartmentBO 科室檔維護  , add by Syscom Max"
    Public Function queryPUBDepartmentByDeptCodeSAndDeptCodeE(ByVal strDeptCodeS As String, ByVal strDeptCodeE As String) As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentByDeptCodeSAndDeptCodeE(strDeptCodeS, strDeptCodeE)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090702 PUBOrderBO 查詢醫令項目基本檔  , add by Syscom Ming"
    '查詢醫令項目基本檔
    Public Function queryPUBOrderByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderByCond(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    ''' <summary>
    '''  查詢醫令項目基本檔
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <param name="strOrderName"></param>
    ''' <param name="strLanguageFlag"></param>
    ''' <param name="strFavor_Type_Id">D:常用處置維護  H:常用檢驗(查)維護 A:常用診斷維護 E:常用藥品維護 G：常用衛材維護 </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBOrderByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String, ByVal strFavor_Type_Id As String) As DataSet
        Select Case strFavor_Type_Id
            Case "D"
                Return queryPUBOrderByCond(strOrderCode, strOrderName, strLanguageFlag)
            Case "H"
                Return queryPUBOrderHByCond(strOrderCode, strOrderName, strLanguageFlag)
                'Case "A"
                '    Return queryPUBOrderAByCond(strOrderCode, strOrderName, strLanguageFlag)
            Case "E"
                Return queryPUBOrderEByCond(strOrderCode, strOrderName, strLanguageFlag)
            Case "G"
                Return queryPUBOrderGByCond(strOrderCode, strOrderName, strLanguageFlag)
            Case "J"
                Return queryPUBOrderJByCond(strOrderCode, strOrderName, strLanguageFlag)
            Case Else
                Return Nothing
        End Select
    End Function
    ''' <summary>
    ''' 查詢醫令項目基本檔 常用檢驗(查)維護
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <param name="strOrderName"></param>
    ''' <param name="strLanguageFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function queryPUBOrderHByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderHByCond(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    '''' <summary>
    '''' 查詢醫令項目基本檔 常用診斷維護
    '''' </summary>
    '''' <param name="strOrderCode"></param>
    '''' <param name="strOrderName"></param>
    '''' <param name="strLanguageFlag"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function queryPUBOrderAByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
    '    Dim instance As New PUBOrderBO_E2
    '    Try
    '        Return instance.queryPUBOrderAByCond(strOrderCode, strOrderName, strLanguageFlag)
    '    Catch ex As Exception
    '        log.Error(ex.ToString)
    '        Throw ex
    '    End Try
    'End Function

    ''' <summary>
    ''' 查詢醫令項目基本檔 常用藥品維護
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <param name="strOrderName"></param>
    ''' <param name="strLanguageFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function queryPUBOrderEByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderEByCond(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢醫令項目基本檔 常用衛材維護
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <param name="strOrderName"></param>
    ''' <param name="strLanguageFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function queryPUBOrderGByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderGByCond(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    Private Function queryPUBOrderJByCond(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderJByCond(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

#Region "20090703 PUBDepartmentBO_E1 科室檔維護 by Add Syscom Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentByCA() As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentCA()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentByIsRegDept() As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentByIsRegDept()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090703 PUBSysCodeBO 共用代碼檔維護 by Add Syscom Yunfei"
    ''' <summary>
    ''' 獲取PUBSysCodeBO資料
    ''' </summary>
    ''' <param name="strColumnName">表字段對象</param>
    ''' <param name="strColumnValue">字段值對象</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByCV(strColumnName, strColumnValue)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090708 PUBDepartmentBO_E1 取得科系資料來源 by Add Syscom Johsn"
    Public Function queryPUBDepartmentCode() As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentCode()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20090715 PUBPatientBodyRecordBO 輸入護理資訊檔維護, add by Syscom Merry_Jing"
    '    '依條件查詢輸入護理資訊檔資料
    '    Function queryPUBPatientBodyRecordByCond(ByVal strChartNo As String) As DataSet
    '        Dim instance As New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return instance.queryPUBPatientBodyRecordByCond(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增輸入護理資訊檔資料
    '    Function insertPUBPatientBodyRecord(ByVal dsSaveData As DataSet) As Integer
    '        Dim instance As New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return instance.insert(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除輸入護理資訊檔資料
    '    Function deletePUBPatientBodyRecordByPK(ByVal strChartNo As String, ByVal strMeasureTime As String) As Integer
    '        Dim instance As New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return instance.delete(strChartNo, strMeasureTime)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '更新輸入護理資訊檔資料
    '    Function updatePUBPatientBodyRecord(ByVal dsSaveData As DataSet) As Integer
    '        Dim instance As New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return instance.update(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region


#Region "20090717 PUBPhaServicesBO 藥事服務費基本檔, add by Syscom Max"
    '依條件查詢輸入護理資訊檔資料
    Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet
        Dim instance As New PUBPhaServicesBO_E2
        Try
            Return instance.queryPUBPhaServicesByCond(strMainIdentityId, strDeptCode, strPhaServicesTypeId, strOrderCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增輸入護理資訊檔資料
    Function insertPUBPhaServices(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBPhaServicesBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除輸入護理資訊檔資料
    Function deletePUBPhaServicesByPK(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String) As Integer
        Dim instance As New PUBPhaServicesBO_E2
        Try
            Return instance.delete(strMainIdentityId, strDeptCode, strPhaServicesTypeId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '更新輸入護理資訊檔資料
    Function updatePUBPhaServices(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBPhaServicesBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090717 PubExamineBO 診察費基本檔維護  , add by Mark"
    '依條件查詢診察費基本檔資料
    Function queryPUBExamineByCond_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                     ByVal strDeptCode As String, ByVal strSectionId As String, _
                                     ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                     ByVal strOrderCode As String) As System.Data.DataSet
        Dim instance As New PUBExamineBO_E2
        Try
            Return instance.queryPUBExamineByCond(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId, strOrderCode)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增診察費基本檔資料
    Function insertPUBExamine_L(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBExamineBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除診察費基本檔資料
    Function deletePUBExamineByPK_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                  ByVal strDeptCode As String, ByVal strSectionId As String, _
                                  ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String) As Integer
        Dim instance As New PUBExamineBO_E2
        Try
            Return instance.delete(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '更新診察費基本檔資料
    Function updatePUBExamine_L(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBExamineBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090720 PUBSysCodeBO 共用代碼檔維護 by Add Jianhui"

    Public Function queryPUBSysCodeByCode(ByRef strColumnName As String(), ByRef strOperator As String(), ByRef strColumnValue As Object()) As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByCode(strColumnName, strOperator, strColumnValue)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region
#Region "2010/01/21 PUBSysCodeBO 共用代碼檔維護 by Add pearl"

    Public Function queryPUBSysCodeByCode2() As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByCode2()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractQuotaBO 合約機構記帳累計檔維護 by Add Yunfei  20080818 修改添加字段SubIdentityCode"
    Public Function queryPUBContractQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet

        Dim instance As New PUBContractQuotaBO_E2
        Try
            Return instance.queryPUBContractQuotaByCond(dateEffectDate, strContractCode, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractQuotaBS 合約機構記帳累計檔維護 by Add Yunfei"
    Public Function confirmContractQuota(ByVal saveData As DataSet) As DataSet

        Dim instance As New PUBContractQuotaBS_E2
        Try
            Return instance.confirmContractQuota(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractBO_E1 合約共用檔維護 by Add Yunfei"
    Public Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.queryPUBContractByColumnValue(strColumnName, strColumnValue)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    Function queryPUBContractBySubIdentityCode57or40() As DataSet
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.queryPUBContractBySubIdentityCode57or40()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20090721 PUBPatientQuotaBO 病患合約機構記帳累積檔- by Add tony"
    Public Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String) As System.Data.DataSet
        Dim instance As New PUBPatientQuotaBO_E2
        Try
            Return instance.queryPUBPatientQuotaByCond(dateEffectDate, strContractCode, strChartNo, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20090721 PUBPatientQuotaBS 病患合約機構記帳累積檔- by Add tony"
    Public Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBPatientQuotaBS_E2
        Try
            Return instance.confirmPUBPatientQuota(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
    '#Region "20090721 PUBContractBO_E1 合約共用檔維護 by Add tony"
    '    Public Function queryPUBContractByCheckQuotaIdAndDc(ByVal strCheckQuotaId As String, ByRef strDc As String) As System.Data.DataSet
    '        Dim instance As New PUBContractBO_E2
    '        Try
    '            Return instance.queryPUBContractByCheckQuotaIdAndDc(strCheckQuotaId, strDc)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region


#Region "20090721 PUBSubIdentitySetBO 身份二代碼計價設定檔維護 , add by Mark"
    '依條件查詢身份二代碼計價設定檔資料
    Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                          ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                          ByVal strOrderCode As String) As System.Data.DataSet
        Dim instance As New PUBSubIdentitySetBO_E2
        Try
            Return instance.queryPUBSubIdentitySetByCond(dateEffectDate, strSubIdentityCode, strOrderTypeId, _
                                                         strAccountId, strOrderCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBSubIdentitySetBS 身份二代碼計價設定檔維護 , add by Mark"
    '確定保存身份二代碼計價設定檔資料
    Function confirmPUBSubIdentitySet(ByVal dsSaveData As DataSet) As DataSet
        Dim instance As New PUBSubIdentitySetBS_E2
        Try
            Return instance.confirmPUBSubIdentitySet(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractBO_E2 合約機構基本檔維護 Add by Merry_Jing"
    '依條件查詢合約機構基本檔資料
    Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.queryPUBContractByCond(strContractCode, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增合約機構基本檔資料
    Function insertPUBContract(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除合約機構基本檔資料
    Function deletePUBContractByPK(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As Integer
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.delete(strContractCode, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '更新合約機構基本檔資料
    Function updatePUBContract(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBAddPartBO 加收部分負擔基本檔 Add by Johsn"
    '查詢加收部分負擔基本檔資料
    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String) As DataSet
        Dim instance As New PUBAddPartBO_E2
        Try
            Return instance.queryPUBAddPartByCond(dateEffectDate, strPartTypeId)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
    '確定加收部分負擔基本檔資料
    Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet
        Dim instance As New PUBAddPartBS_E2
        Try
            Return instance.confirmPUBAddPart(dsSaveData)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090721 PUBContractSetBO 合約身份折扣記賬設定檔維護 by Add Yunfei"
    Public Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean) As System.Data.DataSet

        Dim instance As New PUBContractSetBO_E2
        Try
            Return instance.queryPUBContractSetByCond(dateEffectDate, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, isNullQuerySubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region


#Region "20090721 PUBContractSetBS 合約身份折扣記賬設定檔維護 by Add Yunfei"
    Public Function confirmContractSet(ByVal saveData As DataSet) As DataSet

        Dim instance As New PUBContractSetBS_E2
        Try
            Return instance.confirmContractSet(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region


#Region "20090723 PUBDisIdentitySetBO 優待身份折扣設定檔- by Add tony"
    Public Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String) As System.Data.DataSet
        Dim instance As New PUBDisIdentitySetBO_E2
        Try
            Return instance.queryPUBDisIdentitySetByCond(dateEffectDate, strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090723 PUBDisIdentitySetBS 優待身份折扣設定檔- by Add tony"
    Public Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBDisIdentitySetBS_E2
        Try
            Return instance.confirmPUBDisIdentitySet(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20090723 PUBDisIdentityBO_E2 優待身份基本檔維護 Add by liuye"
    '查詢優待身份基本資料
    Public Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As DataSet
        Dim instance As New PUBDisIdentityBO_E2
        Try
            Return instance.queryPUBDisIdentityByCond(DisIdentityCode)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增優待身份基本檔資料
    Public Function insertPUBDisIdentity(ByVal ds As DataSet) As Integer
        Dim instance As New PUBDisIdentityBO_E2
        Try
            Return instance.insert(ds)
        Catch ex As Exception
            '   log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除優待身份基本檔資料
    Public Function deletePUBDisIdentityByPK(ByRef DisIdentityCode As String) As Integer
        Dim instance As New PUBDisIdentityBO_E2
        Try
            Return instance.delete(DisIdentityCode)
        Catch ex As Exception
            '  log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '修改優待身份基本檔資料
    Public Function updatePUBDisIdentity(ByVal ds As Data.DataSet) As Integer
        Dim instance As New PUBDisIdentityBO_E2
        Try
            Return instance.update(ds)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20090724 PUBSheetBO 表單維護 Add by Yunfei"
    '    '查詢表單資料
    '    Public Function queryPUBSheetByCond(ByVal strSheetCode As String) As DataSet
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.queryPUBSheetByCond(strSheetCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增表單資料
    '    Public Function insertPUBSheet(ByVal dsSave As DataSet) As Integer
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.insert(dsSave)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除表單及明細資料
    '    Public Function deletePUBSheetAndDetail(ByVal strSheetCode As String) As Integer
    '        Dim instance As New PUBSheetBS_E2
    '        Try
    '            Return instance.deletePUBSheetAndDetail(strSheetCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '修改表單資料
    '    Public Function updatePUBSheet(ByVal dsSave As Data.DataSet) As Integer
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.update(dsSave)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region


    '#Region "20090724 查詢批價項目作業  當strKindId='1'時取得看診醫師資料來源 add by Johsn"
    '    '取得看診醫師資料來源
    '    Function queryPUBEmployeeCode(ByVal strKindId As String) As DataSet
    '        Dim instance As New PUBEmployeeBO_E2
    '        Try
    '            Return instance.queryPUBEmployeeCode(strKindId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090724 查詢批價項目作業  就醫科別資料來源 by Add Johsn"
    '    '取得就醫科別資料來源
    '    Function queryPUBDepartmentCodeAndName() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentCodeAndName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090724 員工編號查詢醫師信息   by Add Ming"
    '取得就醫科別資料來源
    Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As DataSet
        Dim instance As New PUBDoctorBO_E2
        Try
            Return instance.queryPUBDoctorByEmployeeCode(EmployeeCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20090724 取得登錄人員信息   by Add Ming"
    '取得就醫科別資料來源
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet
        Dim instance As New PUBEmployeeBO_E2
        Try
            Return instance.queryPUBEmployeeByCode(EmployeeCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
    '#Region "20090724 所屬單位查詢醫師信息   by Add Ming"
    '    '取得就醫科別資料來源
    '    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As DataSet
    '        Dim instance As New PUBDoctorBO_E2
    '        Try
    '            Return instance.queryPUBDoctorByDeptCode(DeptCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Public Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet
    '        Dim instance As New PUBDoctorBO_E2
    '        Try
    '            Return instance.queryPUBDoctorByDoctorCode(DoctorCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090727 PUBSubIdentityBO_E2 身份二代碼基本檔維護 Add by Merry_Jing"
    '依條件查詢身份二代碼基本檔資料
    Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet
        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.queryPUBSubIdentityByCond(strSubIdentityCode, strMainIdentityId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增身份二代碼基本檔資料
    Function insertPUBSubIdentity(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除身份二代碼基本檔資料
    Function deletePUBSubIdentityByPK(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As Integer
        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.delete(strSubIdentityCode, strMainIdentityId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '更新身份二代碼基本檔資料
    Function updatePUBSubIdentity(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20090727  費用項目對應檔- by Add tony"
    Public Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet
        Dim instance As New PUBAccountBO_E2
        Try
            Return instance.queryPUBAccountByCond(strAccountId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '新增費用項目對應檔資料
    Public Function insertPUBAccount(ByVal saveData As DataSet) As Integer
        Dim instance As New PUBAccountBO_E2
        Try
            Return instance.insert(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '修改費用項目對應檔資料
    Public Function updatePUBAccount(ByVal saveData As DataSet) As Integer
        Dim instance As New PUBAccountBO_E2
        Try
            Return instance.update(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除費用項目對應檔資料
    Public Function deletePUBAccountByPK(ByVal strAccountId As String) As Integer
        Dim instance As New PUBAccountBO_E2
        Try
            Return instance.delete(strAccountId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#End Region
    '#Region "20090728 役男複檢基本資料檔  取得縣市別資料來源 by Add Johsn"
    '    '取得縣市別資料來源
    '    Function queryPUBAreaCode() As DataSet
    '        Dim instance As New PUBAreaCodeBO_E2
    '        Try
    '            Return instance.queryPUBAreaCode()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function queryPUBAreaCodeByPK(ByVal Area_Code As String) As DataSet
    '        Dim instance As New PUBAreaCodeBO_E2
    '        Try
    '            Return instance.queryByPK(Area_Code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090730 PUBOrderBO 查詢醫令項目基本檔  Order_Type_Id(醫令類型)=’H’(檢驗檢查) , add by Mark"
    '查詢醫令項目基本檔
    Public Function queryPUBOrderByCond2(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strLanguageFlag As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPUBOrderByCond2(strOrderCode, strOrderName, strLanguageFlag)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "200907030 PUBHolidayBO 假日檔維護  by coco"
    '    '查詢某一假日
    '    Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal datestrHolidayYear As Date, ByVal strSubSystemCode As String) As DataSet
    '        Dim instance As New PUBHolidayBO_E2
    '        Try
    '            Return instance.queryPUBHolidayByCond(strHolidayYear, datestrHolidayYear, strSubSystemCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try

    '    End Function

    '    '新增假日
    '    Function insertPUBHoliday(ByVal saveData As DataSet) As Integer
    '        Dim instance As New PUBHolidayBO_E2
    '        Try
    '            Return instance.insert(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '刪除假日
    '    Function deletePUBHoliday(ByVal datestrHolidayYear As String, ByVal strSubSystemCode As String) As Integer
    '        Dim instance As New PUBHolidayBO_E2
    '        Try
    '            Return instance.delete(datestrHolidayYear, strSubSystemCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '更新假日
    '    Function updatePUBHoliday(ByVal saveData As DataSet) As Integer
    '        Dim instance As New PUBHolidayBO_E2

    '        Try
    '            Return instance.update(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090731 PUBSheetDetailBO 表單明細維護 , add by Mark"
    '    '依表單代碼查詢資料
    '    Public Function queryPUBSheetDetailByCond(ByVal strSheetCode As String, ByVal blnAllFlag As Boolean) As System.Data.DataSet
    '        Dim instance As New PUBSheetDetailBO_E2
    '        Try
    '            Return instance.queryPUBSheetDetailByCond(strSheetCode, blnAllFlag)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090731 PUBSheetDetailBS 表單明細維護 , add by Mark"
    '    '確定保存表單明細資料
    '    Public Function confirmPUBSheetDetail(ByVal saveData As DataSet) As Integer
    '        Dim instance As New PUBSheetDetailBS_E2
    '        Try
    '            Return instance.confirmPUBSheetDetail(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090804 平均看診時間維護  科別資料來源 by Add Mark"
    '    '取得科別資料來源
    '    Function queryPUBDepartmentEffectCodeAndName() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentEffectCodeAndName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090811 診區診間檔維護  診間資料來源 Add by liuye"
    '    '取得診區資料來源
    '    Function queryPUBZoneRoomAll() As DataSet
    '        Dim instance As New PUBZoneRoomBO_E2
    '        Try
    '            Return instance.queryAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090814 PUBBodySiteBO 部位檔維護  by tianxie"
    '查詢某一部位
    Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As DataSet
        Dim instance As New PUBBodySiteBO_E2
        Try
            Return instance.queryPUBBodySiteByCond(strBodySiteCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '查詢某一部位
    Function queryNhiBodySiteCodeByColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByCV(columnName, columnValue)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As DataSet
        Dim instance As New PUBBodySiteBO_E2
        Try
            Return instance.queryMainBodySiteCodeByCond(strBodySiteCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '新增部位
    Function insertPUBBodySite(ByVal ds As DataSet) As Integer
        Dim instance As New PUBBodySiteBO_E2
        Try
            Return instance.insert(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '刪除部位
    Function deletePUBBodySiteByPK(ByRef pk_Body_Site_Code As String) As Integer
        Dim instance As New PUBBodySiteBO_E2
        Try
            Return instance.delete(pk_Body_Site_Code)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '更新部位
    Function updatePUBBodySite(ByVal ds As DataSet) As Integer
        Dim instance As New PUBBodySiteBO_E2

        Try
            Return instance.update(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#End Region

#Region "20090818 PUBDisIdentityBO_E2 公共元件維護 by Add Yunfei "
    Public Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet

        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.queryPUBSubIdentityByCV(strColumnName, strColumnValue)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090818 PUBSyscodeBO 公用代碼檔維護  by mark"
    '查詢
    Function queryPUBSyscodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByCond(iTypeId, strCodeId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '    '新增
    '    Function insertPUBSyscode(ByVal saveData As DataSet) As Integer
    '        Dim instance As New PubSyscodeBO
    '        Try
    '            Return instance.insert(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '刪除
    '    Function deletePUBSyscode(ByVal iTypeId As Integer, ByVal strCodeId As String) As Integer
    '        Dim instance As New PubSyscodeBO
    '        Try
    '            Return instance.delete(iTypeId, strCodeId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '更新
    '    Function updatePUBSyscode(ByVal saveData As DataSet) As Integer
    '        Dim instance As New PubSyscodeBO

    '        Try
    '            Return instance.update(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

#End Region

    '#Region "20090818 PUBSysCodeBO_E2 查詢醫令類別 Add by liuye"
    '    Function queryPUBSysCodeByTCD() As DataSet
    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeByTCD()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20090820 PubRegisterFeeBO_E2 掛號費基本檔維護  by chen yang"
    '查詢
    Public Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet
        Dim instance As New PUBRegisterFeeBO_E2
        Try
            Return instance.queryPUBRegisterFeeByCond(pk_Source_Id, strSubIdentityCode, strDeptCode, strMedicalTypeId, strOrderCode, strSectionId, strFirstReg)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '新增
    Public Function insertPUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer
        Dim instance As New PUBRegisterFeeBO_E2
        Try
            Return instance.insert(ds)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function


    '刪除
    Public Function deletePUBRegisterFeeByPK(ByVal pk_Source_Id As String, ByRef pk_Sub_Identity_Code As System.String, ByVal strFirstReg As String, ByRef pk_Dept_Code As System.String, ByRef pk_Section_Id As System.String, ByRef pk_Medical_Type_Id As System.String) As Integer
        Dim instance As New PUBRegisterFeeBO_E2
        Try
            Return instance.delete(pk_Source_Id, pk_Sub_Identity_Code, strFirstReg, pk_Dept_Code, pk_Section_Id, pk_Medical_Type_Id)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '更新
    Public Function updatePUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer
        Dim instance As New PUBRegisterFeeBO_E2
        Try
            Return instance.update(ds)
        Catch ex As Exception
            '.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#End Region

#Region "20090820 PUBOrderStandingBO 常備醫令檔 Add by william"
    '查詢
    Function queryPUBOrderStandingByCond(ByVal strDeptCode As String, ByVal strOrder_Code As String) As DataSet
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.queryPUBOrderStandingByCond(strDeptCode, strOrder_Code)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '新增
    Function insertPUBOrderStanding(ByVal saveData As DataSet) As Integer
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.insert(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '刪除
    Function deletePUBOrderStandingByPK(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As System.String, ByVal iWeek As System.Int32, ByVal strConsumption_Dept As System.String) As Integer
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.delete(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek, strConsumption_Dept)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '更新
    Function updatePUBOrderStanding(ByVal saveData As DataSet) As Integer
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.update(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.queryPUBOrderStandingTimeIsExist(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '查詢科別/護理站的下拉式選單內容
    Public Function queryPUBOrderStandingByDept() As DataSet
        Dim instance As New PUBOrderStandingBO_E2
        Try
            Return instance.queryPUBOrderStandingByDept()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"科別/護理站"})
        End Try
    End Function

#End Region

    '#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    '    ''' <summary>
    '    ''' 查詢默認部位
    '    ''' </summary>
    '    ''' <param name="strOrder_Code"></param>
    '    ''' <param name="strFavor_Type_Id">D:常用處置維護  H:常用檢驗(查)維護 A:常用診斷維護 E:常用藥品維護 G：常用衛材維護</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String
    '        Select Case strFavor_Type_Id
    '            Case "D"
    '                Dim ds As DataSet = PubOrderOrTreatBO.GetInstance.queryByPK(strOrder_Code)
    '                If (ds.Tables(0).Rows.Count > 0) Then
    '                    Return ds.Tables(0).Rows(0)("Default_Body_Site_Code").ToString
    '                End If
    '            Case "H"
    '                Dim ds As DataSet = PubOrderExaminationBO.GetInstance.queryByPK(strOrder_Code)
    '                If (ds.Tables(0).Rows.Count > 0) Then
    '                    Return ds.Tables(0).Rows(0)("Default_Body_Site_Code").ToString
    '                End If
    '            Case "A"
    '            Case "E"
    '            Case "G"
    '        End Select
    '        Return String.Empty
    '    End Function
    '    ''' <summary>
    '    '''  查詢醫令代碼對應檢體檔
    '    ''' </summary>
    '    ''' <param name="strOrder_Code"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As System.Data.DataSet
    '        Try
    '            Return PUBOrderMappingSpecimenBO_E2.GetInstance.queryPUBOrderMappingSpecimenByOrderCode(strOrder_Code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20090824 PUBBodySiteBO 查詢有效部位檔資料  by windfog"
    ''' <summary>
    ''' 查詢有效部位檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBBodySiteUnDelete() As DataSet
        Try
            Return PubBodySiteBO.GetInstance.dynamicQueryWithColumnValue(New String() {"Dc "}, New Object() {"N"})
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
    '#Region "20090825 PUBDiseaseBO_E2 查詢有效的PUBDisease 資料  by windfog"
    '    ''' <summary>
    '    ''' 查詢有效的PUBDisease 資料
    '    ''' </summary>
    '    ''' <param name="strIcd_Code"></param>
    '    ''' <param name="strDisease_Name"></param>
    '    ''' <param name="strLanguageFlag"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function queryPUBDiseaseEffected(ByVal strIcd_Code As String, ByVal strDisease_Name As String, ByVal strLanguageFlag As String) As DataSet
    '        Try
    '            Return PUBDiseaseBO_E2.GetInstance.queryPUBDiseaseEffected(strIcd_Code, strDisease_Name, strLanguageFlag)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090826 牙醫師週班表維護作業 取得牙科治療 strDeptKind=7 add by Johsn"
    '    Function queryPUBDepartmentByDeptType(ByVal strDeptType As String) As DataSet
    '        Try
    '            Return PUBDepartmentBO_E2.GetInstance.queryPUBDepartmentByDeptType(strDeptType)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090831 役男複檢批價明細 取得縣市別(合約機構代碼) add by tony"
    '    Function queryPUBContractCodeBySubIdentityCodeAndDc() As DataSet
    '        Try
    '            Return PUBContractBO_E2.GetInstance.queryPUBContractCodeBySubIdentityCodeAndDc()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090901 科室檔維護--查詢小科 by Add XaJian"
    Function queryPUBDeptCode() As DataSet
        Try
            Return PUBDepartmentBO_E2.GetInstance.queryPUBDeptCode()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20090902 add by Alan 表單主檔(PUB_Sheet)"

    '    Public Function queryPUBSheetDeptData() As DataSet
    '        Try
    '            Dim instance As PUBSheetBO_E1 = New PUBSheetBO_E1
    '            Return instance.queryPUBSheetDeptData()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Public Function queryPUBSheetDeptSheetData() As DataSet
    '        Try
    '            Dim instance As PUBSheetBO_E1 = New PUBSheetBO_E1
    '            Return instance.queryPUBSheetDeptSheetData()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Public Function queryPUBSheetSheetData(ByVal DeptCode As String) As DataSet
    '        Try
    '            Dim instance As PUBSheetBO_E1 = New PUBSheetBO_E1
    '            Return instance.queryPUBSheetSheetData(DeptCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "20090908 查詢病歷資料 PUBPatientBO_E2 add by Yunfei"
    '    '查詢病患資料
    '    Function queryPUBPatientByCond(ByVal strChartNo As String) As DataTable
    '        Try
    '            Return PUBPatientBO_E2.GetInstance.queryPUBPatientByCond(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090909 病患病歷資料顯示區資料 PUB_Patient_Flag PUB_Syscode PUB_Patient_Allergy PUB_Patient_Severe_Disease PUB_Patient_Operation_History PUB_Patient_Past_Disease_History PUB_Patient_Personal_Habits PUB_Family_History PUB_Patient_Abroad_History add by Yunfei "
    '    Function queryPUBPatientAll(ByVal strChartNo As String) As System.Data.DataSet
    '        Try
    '            Return PUBPatientBO_E2.GetInstance.queryPUBPatientAll(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090910 門診診斷代號開立次數排行表--初始化科別 by Add XaJianming"
    '    Function queryPUBDeptCodeName() As DataSet
    '        Try
    '            Return PUBDepartmentBO_E2.GetInstance.queryPUBDeptCodeName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090914 emrDB PUBDepartmentBO_E2 科室檔維護 by Add Syscom Yunfei"
    '    ''' <summary>
    '    ''' 獲取Department資料
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBDepartmentCA2() As DataSet
    '        Try
    '            Return PUBDepartmentBO_E2.GetInstance.queryPUBDepartmentCA2()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090914 emrDB PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    '    ''' <summary>
    '    ''' 獲取Department資料
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBSysCodeByCV2(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
    '        Try
    '            Dim pubSysCode As New PUBSysCodeBO_E2
    '            Return pubSysCode.queryPUBSysCodeByCV2(strColumnName, strColumnValue)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090915 PUBPostalAreaBO_E2 鄉鎮區別檔維護 by Add Mark"
    '    '查詢鄉鎮區別
    '    Function queryPubPostalAreaByCountyCode(ByVal strCountyCode As String) As DataSet
    '        Try
    '            Return PUBPostalAreaBO_E2.GetInstance.queryPubPostalAreaByCountyCode(strCountyCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20090915 PUBContractPartSetBO 合約身份部份負擔記帳設定檔  , add by Syscom Pearl"
    '查詢合約身份部份負擔記帳設定資料
    Public Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet
        Dim instance As New PUBContractPartSetBO_E2
        Try
            Return instance.queryPUBContractPartSetByCond(dateEffectDate, strContractCode, strSubIdentityCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20090915 PUBContractPartSetBO 合約身份部份負擔記帳設定檔  , add by Syscom Pearl"
    '確定儲存合約身份部份負擔記帳設定資料
    Public Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBContractPartSetBS_E2
        Try
            Return instance.confirmPUBContractPart(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region


    '#Region "20090917 PUBContractBO_E2 合約共用檔維護 by Add Pearl"
    '    Public Function queryPUBContractBySubIdentitycode(ByVal strSubIdentitycode As String) As DataSet
    '        Dim instance As New PUBContractBO_E2
    '        Try
    '            Return instance.queryPUBContractBySubIdentitycode(strSubIdentitycode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090917 PUBSysCodeBO_E2 查詢腸胃道疾病名稱 Add by liuye"
    '    Function queryPUBSysCodeByTypeId() As DataSet
    '        Try
    '            Dim instance As PUBSysCodeBO_E2 = New PUBSysCodeBO_E2
    '            Return instance.queryPUBSysCodeByTypeId()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090918 PUBStationBO_E2 PUBStationBO 檔案查詢代號和名稱 Add by Tor"
    '    Function queryPUBStationNOAndNameAll(Optional ByVal station_No As String = Nothing) As DataSet

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.queryPUBStationNOAndNameAll(station_No)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090918 PUBPatientBO 合并病歷處理 Add by Pearl"
    '    Function queryChartByCond(ByVal chartNo As String) As DataSet
    '        Try
    '            Return PUBPatientBO_E2.GetInstance.queryChartByCond(chartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20090921 PUBSubIdentityBO_E2 身份二查詢  Add by liuye"
    '    Function queryPUBSubIdentityandContract() As DataSet
    '        Try

    '            Dim instance As PUBSubIdentityBO_E2 = New PUBSubIdentityBO_E2
    '            Return instance.queryPUBSubIdentityandContract()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region
    '#Region "20090921  查詢全院員工  Add by tony"
    '    Function queryPUBEmployeeByall() As DataSet
    '        Try

    '            Dim instance As PUBEmployeeBO_E2 = New PUBEmployeeBO_E2
    '            Return instance.queryPUBEmployeeByall()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet
        Try

            Dim instance As PUBSheetBO_E2 = New PUBSheetBO_E2
            Return instance.queryPUBSheetByCV(strLoginID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function queryPUBSheetByCode_L(ByVal strLoginID As String) As DataSet
        Try

            Dim instance As PUBSheetBO_E2 = New PUBSheetBO_E2
            Return instance.queryPUBSheetByCode_L(strLoginID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '    Function queryPUBAreaCodeByAreaCode(ByVal strAreaCode As String) As DataSet
    '        Try

    '            Dim instance As PUBAreaCodeBO_E2 = New PUBAreaCodeBO_E2
    '            Return instance.queryPUBAreaCodeByAreaCode(strAreaCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20090922 PUBContractBO_E2 合約機構查詢  Add by liuye"
    '    Function queryPUBContractsId() As DataSet
    '        Try
    '            Dim instance As PUBContractBO_E2 = New PUBContractBO_E2
    '            Return instance.queryPUBContractsId()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    Function queryPUBDeptCodeNameCA3() As DataSet
        Try
            Dim instance As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
            Return instance.queryPUBDeptCodeNameCA3()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Try
            Dim pubSysCode As New PUBSysCodeBO_E2
            Return pubSysCode.queryPUBSysCodeNot0(strColumnName, strColumnValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20091009   取得戶籍地資料來源 by Add Johsn"
    '    '取得戶籍地資料來源
    '    Public Function queryPUBAreaCodeAll() As DataSet
    '        Try
    '            Dim instance As PUBAreaCodeBO_E2 = PUBAreaCodeBO_E2.GetInstance()
    '            Return instance.queryAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20091012 PUBDentalAddControlBO_E2 牙科轉診加成控制檔, add by zxy"
    '    '依條件查詢牙科轉診加成控制檔
    '    Function queryPUBDentalAddControlByCond_L(ByVal strDeptCode As String, ByVal strOrderCode As String, ByVal strDoctorCode As String) As DataSet
    '        Try
    '            Return PUBDentalAddControlBO_E2.GetInstance.queryPUBDentalAddControlByCond(strDeptCode, strOrderCode, strDoctorCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增營養諮詢疾病別與醫令碼之對應檔
    '    Function insertPUBDentalAddControl_L(ByVal dsSaveData As DataSet) As Integer
    '        Try
    '            Return PUBDentalAddControlBO_E2.GetInstance.insert(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除營養諮詢疾病別與醫令碼之對應檔
    '    Function deletePUBDentalAddControlByPK_L(ByVal strDeptCode As String, ByVal strOrderCode As String, ByVal strDoctorCode As String) As Integer
    '        Try
    '            Return PUBDentalAddControlBO_E2.GetInstance.delete(strDeptCode, strOrderCode, strDoctorCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '更新營養諮詢疾病別與醫令碼之對應檔
    '    Function updatePUBDentalAddControl_L(ByVal dsSaveData As DataSet) As Integer
    '        Try
    '            Return PUBDentalAddControlBO_E2.GetInstance.update(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '查詢,初始化醫師代號
    '    Function queryPUBEmployeeByProfessalKindId_L() As DataSet
    '        Try
    '            Return PUBDentalAddControlBO_E2.GetInstance.queryPUBEmployeeByProfessalKindId()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "200901010 轉診轉出--建議轉診科別 by Add tor"

    Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet
        Try
            Dim instance As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
            Return instance.queryPUBDeptHealthOpdDeptCodeName_L()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

    '#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    '    Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet
    '        Try
    '            Dim instance As PUBPatientBO_E2 = New PUBPatientBO_E2
    '            Return instance.queryPUBPatientBychartNo_L(chartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20091012 PUBHospitalBO_E2 根據傳入時間查詢 by Add Tor"

    Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As DataSet
        Try
            Dim instance As PUBHospitalBO_E2 = New PUBHospitalBO_E2
            Return instance.queryPUBHospitalBOByReferralOutDate_L(strReferralOutDate)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20091012 查詢 醫師名稱  當工作時間在strReferralOutDate 時 取得看診醫師資料來源 by Add Tor"

    Function queryPUBEmployeeCodeByReferralOutDate_L(ByVal strCode As String, ByVal strReferralOutDate As String) As DataSet
        Try
            Dim instance As PUBEmployeeBO_E2 = New PUBEmployeeBO_E2
            Return instance.queryPUBEmployeeCodeByReferralOutDate_L(strCode, strReferralOutDate)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

#Region "20091012 查詢 查詢科別健保碼   by Add Tor"

    Function queryPUBDeptHealthByCode_L(ByVal code As String) As DataSet
        Try
            Dim instance As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
            Return instance.queryPUBDeptHealthByCode_L(code)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

    '#Region "20091012 查詢    by Add Tor"

    '    Function queryPUBPatientPastDiseaseHistoryByCode_L(ByVal code As String) As DataSet
    '        Try
    '            Dim instance As PubPatientPastDiseaseHistoryBO_E2 = New PubPatientPastDiseaseHistoryBO_E2
    '            Return instance.queryPUBPatientPastDiseaseHistoryByCode_L(code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20091012 查詢  轉診回覆  by Add ChenYang"
    Function queryPubPatientByPK_L(ByRef pk_Chart_No As System.String) As DataSet
        Try
            Dim instance As PUBPatientBO_E2 = New PUBPatientBO_E2
            Return instance.queryByPK(pk_Chart_No)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As DataSet
        Try
            Dim instance As PUBHospitalBO_E2 = New PUBHospitalBO_E2
            Return instance.queryPubHospitalByKey_L(LanguageTypeId, EffectDate)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

    '#Region "20091012 查詢    by Add Tor"

    '    Function queryPUBHospitalBOForPrint_L() As DataSet
    '        Try
    '            Dim instance As PUBHospitalBO_E2 = New PUBHospitalBO_E2
    '            Return instance.queryPUBHospitalBOForPrint_L()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "20091014 查詢資料 PUB_Patient 中的部分信息 PUBPatientBO_E2，add by Yunfei"
    '    Function queryPUBPatientBaseInfoByChartNo_L(ByVal strChartNo As String) As DataSet
    '        Try
    '            Dim instance As PUBPatientBO_E2 = New PUBPatientBO_E2
    '            Return instance.queryPUBPatientBaseInfoByChartNo_L(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20091015 查詢病歷關系，add by Dashan"
    Function queryPUBPatientContactByCond_L(ByVal strChartNo As String) As System.Data.DataSet
        Try
            Dim instance As PUBPatientContactBO_E2 = New PUBPatientContactBO_E2
            Return instance.queryPUBPatientContactByCond(strChartNo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '    Function queryPUBPatientContactByChartNo_L(ByVal strChartNo As String) As System.Data.DataSet
    '        Try
    '            Dim instance As PUBPatientContactBO_E2 = New PUBPatientContactBO_E2
    '            Return instance.queryPUBPatientContactByChartNo(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20091016 牙科X光醫令照射列印作業，add by zhangwei"
    '    Function queryPUBSysCodeByX1_L(ByVal iTypeId As Integer, ByVal strCodeId1 As String, ByVal strCodeId2 As String) As DataSet
    '        Try
    '            Dim instance As PUBSysCodeBO_E2 = New PUBSysCodeBO_E2
    '            Return instance.queryPUBSysCodeByX1_L(iTypeId, strCodeId1, strCodeId2)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    Function queryPUBSysCodeByX2_L(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet
    '        Try
    '            Dim instance As PUBSysCodeBO_E2 = New PUBSysCodeBO_E2
    '            Return instance.queryPUBSysCodeByX2_L(iTypeId, strCodeId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20091021 查詢資料 PUB_Order 中的部分信息 PUBOrderBO_E2，add by Tor"
    Function queryPUBOrderByDate_L(ByVal OutDate As String) As DataSet
        Try
            Dim instance As PUBOrderBO_E2 = New PUBOrderBO_E2
            Return instance.queryPubOrderDataByDate(OutDate)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20091019 查詢PUB_Syscode,add by zxy"
    '    Function queryByPK_L(ByRef pk_Type_Id As System.Int32, ByRef pk_Code_Id As System.String) As System.Data.DataSet
    '        Try
    '            Return PubSyscodeBO.GetInstance.queryByPK(pk_Type_Id, pk_Code_Id)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20091026 查詢項目健保碼 PUBOrderPriceBO_E2,add by ChenYang"
    Function queryPUBOrderPriceByCode(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataTable
        Try
            Return PUBOrderPriceBO_E2.GetInstance.queryPUBOrderPriceByCode(strEffectDate, strOrderCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

#Region "20091026 查詢 PUBConfigBO_E2 ,add by ChenYang"
    Function queryPUBConfigByPK_L(ByVal pk_Config_Name As String) As System.Data.DataSet
        Try
            Return PUBConfigBO_E2.GetInstance.queryByPK(pk_Config_Name)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region
    '#Region "20091021 取得病患資料 , Add by zxy"
    '    Public Function queryPUBPatientByChartNoOrId_L(ByVal strChartNo As String, ByVal strID As String) As DataSet
    '        Try
    '            Return PUBPatientBO_E2.GetInstance.queryPUBPatientByChartNoOrId(strChartNo, strID)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
#Region "20091030 取得外國國籍名稱 , Add by tony"
    Function queryNationalName_L() As DataSet
        Try
            Dim instance As PUBSysCodeBO_E2 = New PUBSysCodeBO_E2
            Return instance.queryPUBSysCodeNameByTypeId()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20091030 取得居住地區欄位 , Add by tony"
    Function queryAreaCode_L() As DataSet
        Try
            Return PUBAreaCodeBO_E2.GetInstance.queryAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20091103 取得肺結核資料 , Add by tony"
    Function queryTuberculosis_L() As DataSet
        Try
            Return PUBConfigBO_E2.GetInstance.queryTuberculosis()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20091120 取得醫令 , Add by Dashan"
    '        Function queryPubOrderByOrderCode_L(ByVal strOrderCode As String) As DataSet
    '                Dim instance As New PUBOrderBO_E2
    '                Try
    '                        Return instance.queryPubOrderByOrderCode(strOrderCode)
    '                Catch ex As Exception
    '                        log.Error(ex.ToString)
    '                        Throw ex
    '                End Try
    '        End Function
    '#End Region

    '#Region "20091120 查詢有效的PUBDisease區間資料 , Add by Dashan"
    '        Function queryPUBDiseaseCodeSE_L(ByVal strCollectionCodeS As String, ByVal strCollectionCodeE As String) As DataSet
    '                Try
    '                        Return PUBDiseaseBO_E2.GetInstance.queryPUBDiseaseCodeSE(strCollectionCodeS, strCollectionCodeE)
    '                Catch ex As Exception
    '                        log.Error(ex.ToString)
    '                        Throw ex
    '                End Try
    '        End Function
    '#End Region
#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    Function queryConsuDept_L() As DataSet
        Dim instance As New PUBConfigBO_E2
        Try
            Return instance.queryConsuDept()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20091210 PUB_SHEET_MEREGE 查詢表單資料for 可選擇表單grid by Add tony"
    '    Function queryPUBSheetSlecet_L(ByVal strBloodSpecimen As String) As DataSet
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.queryPUBSheetSlecet(strBloodSpecimen)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20091210 PUB_SHEET_MEREGE 查詢表單資料for 彙總表單grid by Add tony"
    '    Function queryPUBSheetMerge_L(ByVal strPubSheetCode As String, ByVal strBloodSpecimen As String) As DataSet
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.queryPUBSheetMerge(strPubSheetCode, strBloodSpecimen)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20091210 PUB_SHEET_MEREGE 查詢表單資料for 不可彙總醫令grid by Add tony"
    '    Function queryOrderCodeMerge_L(ByVal strSheetCode As String) As System.Data.DataSet
    '        Dim instance As New PUBSheetDetailBO_E2
    '        Try
    '            Return instance.queryOrderCodeMerge(strSheetCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20091210 PUB_SHEET_MEREGE 點選確定按鈕操作  by Add tony"
    '    Function confirmPUBSheetMerge_L(ByVal dsSaveData As DataSet) As Integer
    '        Dim instance As New PUBSheetMergeBS_E2
    '        Try
    '            Return instance.confirmPUBSheetMerge(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20091211 PUB_SHEET_MEREGE 取得血液代碼   by Add tony"
    '    Function queryBloodSpecimen_L() As DataSet
    '        Dim instance As New PUBConfigBO_E2
    '        Try
    '            Return instance.queryBloodSpecimen()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function


    '#End Region

    '#Region "20091229    by Add jianhui"
    '    Function queryURLByName(ByVal strName As String) As DataSet
    '        Dim instance As New PUBConfigBO_E2
    '        Try
    '            Return instance.queryURLByName(strName)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20091211 特殊屬性主檔維護  by Add Mark Zhang"
    '    '查詢表單資料for ComboBox
    '    Function queryPUBSheetAllForComboBox_L() As DataSet
    '        Dim instance As New PUBSheetBO_E2
    '        Try
    '            Return instance.queryPUBSheetAllForComboBox()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '查詢醫令項目基本檔
    '    Function queryPUBOrderByCode_L(ByVal strOrderCode As String) As DataSet
    '        Dim instance As New PUBOrderBO_E2
    '        Try
    '            Return instance.queryPUBOrderByCode(strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '查詢已存在之特殊屬性項目
    '    Function queryPUBPubIndicationItemAll_L() As DataSet
    '        Dim instance As New PubIndicationItemBO_E2
    '        Try
    '            Return instance.queryPUBPubIndicationItemAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '查詢已存在之特殊屬性細項
    '    Function queryPubIndicationItemDetailAll_L() As DataSet
    '        Dim instance As New PubIndicationItemDetailBO_E2
    '        Try
    '            Return instance.queryPubIndicationItemDetailAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '查詢主檔資料
    '    Function queryPubIndicationByCond_L(ByVal strSheetCode As String, ByVal strOrderCode As String) As DataSet
    '        Dim instance As New PubIndicationBO_E2
    '        Try
    '            Return instance.queryPubIndicationByCond(strSheetCode, strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '確定儲存主檔資料
    '    Function confirmPUBIndication_L(ByVal dsSaveData As DataSet, ByVal strSheetCode As String, ByVal strOrderCode As String, ByVal strCurrUser As String) As Integer
    '        Dim instance As New PUBIndicationBS_E2
    '        Try
    '            Return instance.confirmPUBIndication(dsSaveData, strSheetCode, strOrderCode, strCurrUser)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20091225 查詢 轉介科別  add by Fan"
    '    Function queryPUBDeptCodeAndNameByCodeDC_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDeptCodeAndNameByCodeDC()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    Function queryprisendInfo_L() As DataSet
        Dim instance As New PUBConfigBO_E2
        Try
            Return instance.queryprisendInfo()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region
#Region "20100112 排成醫令維護 Add by coco"
    Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String) As DataSet
        Dim instance As New PUBSheetDetailBO_E2
        Try
            Return instance.queryPUBSheetDetailByCond1(strSheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '#Region "2010/01/14 DEP 取得治療類別 add by zhangwei"
    '    Function queryPUBSysCodeByTreatmentTypeId_L(ByVal strTypeId As String, ByVal strCodeId As String) As DataSet
    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeByTreatmentTypeId(strTypeId, strCodeId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20100128  取得性別 年齡 來源 轉歸別 診斷類型 主次 add by Johsn"
    Function queryPUBSysCodeByIcdCodingQuery_L() As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByIcdCodingQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '#Region "20100205  query for轉介科別  add by tony"
    '    Function queryRefferalDept_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryRefferalDept()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20100208  身份二查詢for 優待身份折扣設定檔combox  by Add  tony"
    Function queryPUBSubIdentityForCombo_L() As DataSet
        Dim instance As New PUBSubIdentityBO_E2
        Try
            Return instance.queryPUBSubIdentityForCombo()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20100223  病人透析紀錄管理 add by Merry"
    '    Function updatePUBPatientContactByPK_L(ByVal dsSaveData As DataSet) As Integer
    '        Dim instance As New PUBPatientContactBO_E2
    '        Try
    '            Return instance.updatePUBPatientContactByPK(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function insertPUBPatientContactByPK_L(ByVal dsSaveData As DataSet) As Integer
    '        Dim instance As New PUBPatientContactBO_E2
    '        Try
    '            Return instance.insert(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '選出最大Patient_Contact_No,用於新增時Patient_Contact_No遞增
    '    Function queryPUBPatientContactForMaxNo_L(ByVal strChartNo As String) As DataSet
    '        Dim instance As New PUBPatientContactBO_E2
    '        Try
    '            Return instance.queryPUBPatientContactForMaxNo(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20100303 獲得所屬部門下的所有部門   by Add ming"

    Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet
        Try
            Dim instance As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
            Return instance.queryPUBDepartmentByCode_L(code)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region
    '#Region "2010/03/30 查詢診斷作業 add by Mark"
    '    ' 依ICDCode查詢有效的PUBDisease資料
    '    Function queryPUBDiseaseByCode_L(ByVal strIcd_Code As String) As DataSet
    '        Try
    '            Dim instance As PUBDiseaseBO_E2 = New PUBDiseaseBO_E2
    '            Return instance.queryPUBDiseaseByCode(strIcd_Code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region
    '#Region "20100331 門診健檢套餐報價作業 合約機構combo   by Add tony"

    '    Function queryPUBContractForCombo_L() As DataSet
    '        Try
    '            Dim instance As PUBContractBO_E2 = New PUBContractBO_E2
    '            Return instance.queryPUBContractForCombo()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region
    '#Region "20100330 PUBOrderBO 門診健檢套餐報價作業 查詢醫令項目基本檔  add by tony"

    '    Function queryPUBOrderForPackage_L(ByVal strOrderCode As String, ByVal strOrderName As String, ByVal strOrderEnName As String, ByVal strAccountId As String, ByVal strOrderTypeId As String, ByVal strQuotationDate As String) As System.Data.DataSet
    '        Try
    '            Dim instance As PUBOrderBO_E2 = New PUBOrderBO_E2
    '            Return instance.queryPUBOrderForPackage(strOrderCode, strOrderName, strOrderEnName, strAccountId, strOrderTypeId, strQuotationDate)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region
    '#Region "20100401  門診健檢套餐報價作業  Click 加作折扣設定頁籤-加作折扣設定Grid-刪除(X) Button  add by tony"
    '    Function deletePubContractSet1_L(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String) As Integer
    '        Try
    '            Dim instance As PUBContractSetBO_E2 = New PUBContractSetBO_E2
    '            Return instance.deletePubContractSet1(strEffectDate, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100401  門診健檢套餐報價作業  Click 加作折扣設定頁籤- 存檔Button or F10  add by tony"
    '    Function queryPUBContractSet_L(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String) As System.Data.DataSet
    '        Try
    '            Dim instance As PUBContractSetBO_E2 = New PUBContractSetBO_E2
    '            Return instance.queryPUBContractSet(strEffectDate, strContractCode, strSubIdentityCode, strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    Function insertPUBContractSet_L(ByVal dsSaveData As DataSet) As Integer
    '        Try
    '            Dim instance As PUBContractSetBO_E2 = New PUBContractSetBO_E2
    '            Return instance.insert(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region
    '#Region "20100401  門診健檢套餐報價作業  Click 加作折扣設定頁籤- 全部刪除Button or Shift+F12  add by tony"
    '    Function deletePubContractSet2_L(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String) As Integer
    '        Try
    '            Dim instance As PUBContractSetBO_E2 = New PUBContractSetBO_E2
    '            Return instance.deletePubContractSet2(strEffectDate, strContractCode, strSubIdentityCode, strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100401  門診健檢套餐報價作業  Click加作折扣設定頁籤- 查詢Button or F3  add by tony"
    '    Function queryPUBContractSet2_L(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet
    '        Try
    '            Dim instance As PUBContractSetBO_E2 = New PUBContractSetBO_E2
    '            Return instance.queryPUBContractSet2(strEffectDate, strContractCode, strSubIdentityCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100401 健檢套餐報價作業定價頁簽科別combobox by Add tony"
    '    Function queryPUBDepartmentForSellCombo_L() As DataSet
    '        Try
    '            Return PUBDepartmentBO_E2.GetInstance.queryPUBDepartmentForSellCombo_L()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20100420 PUBPatientHealthCardBO 全國醫療服務卡維護檔  Add by Runxia"
    '查詢全國醫療服務卡維護檔
    Function queryPUBPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As DataSet
        Try
            Return PUBPatientHealthCardBO_E2.GetInstance.queryPubPatientHealthCardByCond_L(strChartNo, strEffectDate)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增全國醫療服務卡維護檔
    Function insertPUBPatientHealthCard_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPatientHealthCardBO_E2.GetInstance.insert(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除全國醫療服務卡維護檔
    Function deletePUBPatientHealthCard_L(ByVal strChartNo As String, ByVal strEffectDate As String) As Integer
        Try
            Return PUBPatientHealthCardBO_E2.GetInstance.delete(strChartNo, strEffectDate)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '修改全國醫療服務卡維護檔
    Function updatePUBPatientHealthCard_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPatientHealthCardBO_E2.GetInstance.update(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20100422 PubPatientSevereDiseaseBO 病患重大傷病記錄檔  Add by Runxia"
    '查詢病患重大傷病記錄檔
    Function queryPUBPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date) As DataSet
        Try
            Return PUBPatientSevereDiseaseBO_E2.GetInstance.queryPubPatientSevereDiseaseByCond_L(strChartNo, strIcdCode, dateEffectDate)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增病患重大傷病記錄檔
    Function insertPUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPatientSevereDiseaseBO_E2.GetInstance.insert(ds)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '刪除病患重大傷病記錄檔
    Function deletePUBPatientSevereDisease_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal strEffectDate As String) As Integer
        Try
            Return PUBPatientSevereDiseaseBO_E2.GetInstance.delete(strChartNo, strIcdCode, strEffectDate)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '修改病患重大傷病記錄檔
    Function updatePUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPatientSevereDiseaseBO_E2.GetInstance.update(ds)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '由Icd_code查詢對應的診斷英文名
    Public Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet
        Try
            Return PUBPatientSevereDiseaseBO_E2.GetInstance.queryPubDiseaseEnNameByIcdCode_L(strIcdCode)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#Region "     病歷號查詢(顯示是否) "
    ''' <summary>
    ''' 病歷號查詢(顯示是否)
    ''' </summary>
    ''' <returns>String) as DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-03</remarks>
    Public Function PUBPatientSevereDiseasequeryByPKYNShow(ByRef pk_Chart_No As String, ByRef pk_Icd_Code As String, ByRef pk_Effect_Date As Date) As DataSet

        Dim m_PUBPatientSevereDisease As PUBPatientSevereDiseaseBO_E2 = New PUBPatientSevereDiseaseBO_E2
        Try

            Return m_PUBPatientSevereDisease.queryByPKYNShow(pk_Chart_No, pk_Icd_Code, pk_Effect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"病歷號查詢(顯示是否)"})

        End Try

    End Function

#End Region


#End Region

    '#Region "20100421 PUBZoneRoomBO_E2  區診間維護檔 ,add by Pearl"
    '    Function queryPUBZoneRoomByCond_L(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet
    '        Try
    '            Return PUBZoneRoomBO_E2.GetInstance.queryPUBZoneRoomByCond(strZoneId, strRoomCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    Function insertPUBZoneRoom_L(ByVal dsSaveData As DataSet) As Integer
    '        Try
    '            Return PUBZoneRoomBO_E2.GetInstance.insert(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    Function updatePUBZoneRoom_L(ByVal dsSaveData As DataSet) As Integer
    '        Try
    '            Return PUBZoneRoomBO_E2.GetInstance.update(dsSaveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    Function deletePUBZoneRoomByPK_L(ByVal strZoneId As String, ByVal strRoomCode As String) As Integer
    '        Try
    '            Return PUBZoneRoomBO_E2.GetInstance.delete(strZoneId, strRoomCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20100426 彙總檢驗單維護-查詢彙總檢驗單名稱 by Add tony"
    '    Function querySheetName_L(ByVal strSheetCode As String, ByVal blnFlag As Boolean) As System.Data.DataSet
    '        Dim dsDB As New Data.DataSet
    '        Dim instance As New PUBSheetMergeBO_E2
    '        Try
    '            Return instance.querySheetName(strSheetCode, blnFlag)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100426 彙總檢驗單維護-刪除merge_mark by Add tony"
    '    Function deletePUBSheetMergeByCond_L(ByVal strMerge As String) As Integer
    '        Dim dsDB As New Data.DataSet
    '        Dim instance As New PUBSheetMergeBO_E2
    '        Try
    '            Return instance.deletePUBSheetMergeByCond(strMerge)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100406  身份二查詢for 門診健檢套餐報價combox  by Add  tony"
    '    Function queryPUBSubIdentityForCombo1_L(ByVal strContractCode As String) As DataSet
    '        Dim instance As New PUBSubIdentityBO_E2
    '        Try
    '            Return instance.queryPUBSubIdentityForCombo1(strContractCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20100511 語音掛號路徑查詢  Add by pearl"
    '    Function queryREGVoiceInfo_L() As DataSet
    '        Dim instance As New PUBConfigBO_E2
    '        Try
    '            Return instance.queryREGVoiceInfo()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
#Region "20100526 PUBDepartmentBO_E2  次專科基本檔所屬科別combobox資料  add by liuye"
    Function queryPUBDepartmentEffectByColumnValue_L(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPUBDepartmentEffectByColumnValue(strColumnName, strColumnValue)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
#Region "20100526 科診名稱維護  , add by tima_qin"
    '依條件查詢科診名稱
    Function queryPubDeptSectByCond_L(ByVal strDeptCode As String, ByVal strSectId As String) As DataSet
        Dim instance As New PUBDeptSectBO_E2
        Try
            Return instance.queryPubDeptSectByCond(strDeptCode, strSectId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '新增科診名稱
    Function insertPubDeptSect_L(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBDeptSectBO_E2
        Try
            Return instance.insert(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '刪除科診名稱
    Function deletePubDeptSectByPK_L(ByVal strDeptCode As String, ByVal strSectId As String) As Integer
        Dim instance As New PUBDeptSectBO_E2
        Try
            Return instance.delete(strDeptCode, strSectId)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '更新科診名稱
    Function updatePubDeptSectByCond_L(ByVal dsSaveData As DataSet) As Integer
        Dim instance As New PUBDeptSectBO_E2
        Try
            Return instance.update(dsSaveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#Region "2015/11/11 科診屬性代碼查詢(PUB_Dept_Sect) by Eddie,Lu"

#Region "     科診屬性代碼查詢 "
    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBDeptSectqueryCboData(ByVal typeId As Integer) As DataSet

        Dim m_PUBDeptSect As PUBDeptSectBO_E2 = New PUBDeptSectBO_E2
        Try

            Return m_PUBDeptSect.queryCboData(typeId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"科診屬性代碼查詢"})

        End Try

    End Function

#End Region


#End Region


#End Region

#Region "20100527 add by Merry 費用項目對應檔維護- 依傳入TypeID取得代碼檔資料"
    Public Function queryPUBSysCode_L(ByVal TypeID As String) As DataSet
        Try
            Dim k1 As PUBSysCodeBO_E2 = New PUBSysCodeBO_E2
            Return k1.queryPUBSysCodeAll(TypeID)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20100601 查詢套餐內容Grid.檢體ComboBox下拉選單資料 add by tima_qin"
    '    Function queryPUBSpecimenIdCombobox(ByVal strOrderCode As String, ByVal strFlag As String) As DataSet
    '        Dim instance As New PUBOrderMappingSpecimenBO_E2
    '        Try
    '            Return instance.queryPUBSpecimenIdCombobox(strOrderCode, strFlag)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "2016/04/22 add by Kaiwen 醫令項目代碼對應健保碼"
    '查詢醫令項目檔
    Function queryPubOrderByOrderCode2_L(ByVal strOrderCode As String) As DataSet
        Dim instance As New PUBOrderBO_E2
        Try
            Return instance.queryPubOrderByOrderCode2(strOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '查詢健保支付標準檔
    Function queryPubNhiCode_L(ByVal strInsuCode As String) As DataSet
        Dim instance As New PUBNhiCodeBO_E2
        Try
            Return instance.queryPubNhiCode(strInsuCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '刪除醫令項目代碼對應健保碼
    Function deletePubInsuCode_L(ByVal ds As DataSet) As Integer
        Dim instance As New PUBInsuCodeBO_E2
        Try
            Return instance.deletePubInsuCode(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '查詢醫令項目代碼對應健保碼
    Function queryPubInsuCode_L(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataSet
        Dim instance As New PUBInsuCodeBO_E2
        Try
            Return instance.queryPubInsuCode(strEffectDate, strOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取得OrderCode對應的健保碼
    Function queryPubInsuCodeByOrderCode_L(ByVal strOrderCode As String) As DataSet
        Dim instance As New PUBInsuCodeBO_E2
        Try
            Return instance.queryPubInsuCodeByOrderCode(strOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '取號
    Function queryPubInsuCodeBySeqNo_L(ByVal strOrderCode As String) As DataSet
        Dim instance As New PUBInsuCodeBO_E2
        Try
            Return instance.queryPubInsuCodeBySeqNo(strOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function confirmPUBInsuCode_L(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBInsuCodeBS_E2
        Try
            Return instance.confirmPUBInsuCode(saveData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20100603  Add By Tor 健保支付標準檔"
    ' 查詢特定治療項目基本檔資料 Add By Tor
    Function queryPUBMajorNoEquByCond_L(ByVal strMajorcareCode As String) As DataSet
        Dim instance As New PUBMajorcareBO_E2
        Try
            Return instance.queryPUBMajorNoEquByCond(strMajorcareCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    ' 查詢健保支付標準檔,(檢驗檢查)  
    Function queryPUBNhiCodeByCond_L(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet
        Dim instance As New PUBNhiCodeBO_E2
        Try
            Return instance.queryPUBNhiCodeByCond(strEffectDate, strInsuCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '確定儲存 健保支付標準檔
    Public Function confirmPUBNhiCode_L(ByVal saveData As DataSet) As DataSet
        Dim instance As New PUBNhiCodeBS_E2
        Try
            Return instance.confirmPUBNhiCode(saveData)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
#Region "20100608  科室維護  add by tima_qin"
    Function queryPubDeptSect_L(ByVal strDeptCode As String) As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryPubDeptSect(strDeptCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "2010/06/08 健保支付標準檔 查詢健保支付點數  add Mark"
    '    Function queryPubNhiCodeForPrice_L(ByVal strInsuCode As String) As DataSet
    '        Dim instance As New PUBNhiCodeBO_E2
    '        Try
    '            Return instance.queryPubNhiCodeForPrice(strInsuCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "2010/06/21  評值項目維護 add pearl"
    '    Function updatePUBSyscodeDepNutritionProblem_L(ByVal saveData As DataSet, ByVal strUI As String) As Integer
    '        Dim instance As New PUBSyscodeDepNutritionProblemBS_E2
    '        Try
    '            Return instance.updatePUBSyscodeDepNutritionProblem(saveData, strUI)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function deletePUBSyscodeDepNutritionProblem_L(ByVal typeId As String, ByVal strEvaluationItemId As String, ByVal strUI As String) As Integer
    '        Dim instance As New PUBSyscodeDepNutritionProblemBS_E2
    '        Try
    '            Return instance.deletePUBSyscodeDepNutritionProblem(typeId, strEvaluationItemId, strUI)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20100621 PUBSysCodeBO 共用代碼檔維護小兒預防註射疫苗領取登錄 by Add Syscom coco"
    '    Function queryPUBSysCodeByCond01_L(ByVal iTypeId As String) As DataSet
    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeByCond01(iTypeId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
#Region "20100622  常用維護科別資料來源 add by coco"
    Function queryRefferalDeptOMO_L() As DataSet
        Dim instance As New PUBDepartmentBO_E2
        Try
            Return instance.queryRefferalDeptOMO()
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
    '#Region "20100623  根據主key查詢假期檔 add By Tor"
    '    Function queryHolidatByPK_L(ByVal strHolidayDate As String, ByVal strSubSystemCode As String) As DataSet
    '        Dim instance As New PubHolidayBO
    '        Try
    '            Return instance.queryByPK(strHolidayDate, strSubSystemCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    'queryBetweenDate

    '#End Region
    '#Region "20100624 PUB_Patient_BodyRecord  add by liuye"
    '    Function queryPUBPatientBodyRecordWithColumnValue_L(ByRef strcolumnName As String(), ByRef strcolumnValue As Object()) As DataSet
    '        Dim instance As New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return instance.dynamicQueryWithColumnValue(strcolumnName, strcolumnValue)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100625 過敏史查詢 add by liuye"
    '    Function queryPUBPatientAllergyByWithChartNo_L(ByVal strChartNo As String) As DataSet
    '        Dim instance As New PUBPatientAllergyBO_E2
    '        Try
    '            Return instance.queryPUBPatientAllergyByWithChartNo(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20100713  門診健檢套餐報價作業-產生報價單 Add by Tima_Qin"
    '    Function queryPUBContractForExcel_L(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet
    '        Dim instance As New PUBContractBO_E2
    '        Try
    '            Return instance.queryPUBContractForExcel(strContractCode, strSubIdentityCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"
    Function querySheetCode_L(ByVal strPubSheetCode As String) As DataSet
        Dim instance As New PUBSheetBO_E2
        Try
            Return instance.querySheetCode(strPubSheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20100809 病歷量審查作業"

    Function queryPUBDoctorByDoctorCode2_L(ByVal DoctorCode As String) As DataSet
        Dim instance As New PUBDoctorBO_E2
        Try
            Return instance.queryPUBDoctorByDoctorCode2(DoctorCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    '#Region "20100824 PUBOrderBO 客戶關懷追蹤篩選作業 查詢醫令項目For ListBox  add by Mark Zhang"
    '    '查詢醫令項目
    '    Function queryPUBOrderForListBox_L() As DataSet
    '        Dim instance As New PUBOrderBO_E2
    '        Try
    '            Return Nothing 'instance.queryPUBOrderForListBox()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20100906 病歷調閱班表維護  add by Runxia"

    '    Function queryPUBHolidayByYearAndMonth_L(ByVal strYear As String, ByVal strMonth As String) As DataSet
    '        Dim instance As New PUBHolidayBO_E2
    '        Try
    '            Return instance.queryPUBHolidayByYearAndMonth(strYear, strMonth)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "20100913 PUBSysCodeBO 復健治療實際執行治療日數明細表 by Add Syscom pearl"

    '    Function queryPUBSysCodeByCond36_L() As DataSet
    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeByCond36()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

#Region "20100929 健保支付標準檔  查詢上一筆下一筆和刪除事件 add by liuye"
    Function queryPUBNhiCodeUpDown_L(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet
        Dim instance As New PUBNhiCodeBO_E2
        Try
            Return instance.queryPUBNhiCodeUpDown(strEffectDate, strInsuCode, itype)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    Function deletePUBNhiCodeByInsuCode_L(ByVal strInsuCode As String) As Integer
        Dim instance As New PUBNhiCodeBO_E2
        Try
            Return instance.deletePUBNhiCodeByInsuCode(strInsuCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢健保科別(加成)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>

    Function queryPUBNhiDeptCode() As DataSet
        Dim instance As New PUBNhiCodeBO_E2
        Try
            Return instance.queryPUBNhiDeptCode()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region
    '#Region "20101014 for PIPWriteQSPatientQuota  add by liuye"
    '    Function insertPUBPatientQuotaforPIPQS_L(ByVal dsDB As DataSet, ByVal dtOrderRecord As DataTable, ByRef strReturn As String) As String
    '        Dim instance As New PUBPatientQuotaBS_E2
    '        Try
    '            Return instance.insertPUBPatientQuotaforPIPQS(dsDB, dtOrderRecord, strReturn)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20101014 成人健檢申報管理 , Add by Runxia"
    '    Function queryPUBPatientForOHMAphcApllyRecord_L(ByVal strChartNo As String, ByVal strIdno As String) As DataSet
    '        Dim instance As New PUBPatientBO_E2
    '        Try
    '            Return instance.queryPUBPatientForOHMAphcApllyRecode(strChartNo, strIdno)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20101115 營養相關代碼維護 , Add by pearl"
    '    Function queryPUBSysCodeByTypeId2_L(ByVal TypeId As String()) As DataSet
    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeByTypeId2(TypeId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20101127 護理站維護 , Add by Mark"
    '    '查詢護理站資料
    '    Function queryPUBStationByPk_L(ByVal strStationNo As String) As DataSet
    '        Dim instance As New PUBStationBO_E2
    '        Try
    '            Return instance.queryByPK(strStationNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    '修改護理站之區域種類
    '    Function updatePUBStationForRegionKind_L(ByVal strStationNo As String, _
    '                                             ByVal strRegionKind As String, _
    '                                             ByVal strUserId As String) As Integer
    '        Dim instance As New PUBStationBO_E2
    '        Try
    '            Return instance.updatePUBStationForRegionKind(strStationNo, strRegionKind, strUserId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20101216 查詢醫令代碼對應檢體檔 add by mark zhang"
    '    ''' <summary>
    '    '''  查詢醫令代碼對應檢體檔
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function queryPUBOrderMappingSpecimenForAll_L() As System.Data.DataSet
    '        Try
    '            Return PUBOrderMappingSpecimenBO_E2.GetInstance.queryPUBOrderMappingSpecimenForAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20101224 PUBContractBO_E2 合約共用檔維護 by mark zhang"
    Function queryPUBContractByColumnValue2_L(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet
        Dim instance As New PUBContractBO_E2
        Try
            Return instance.queryPUBContractByColumnValue2(strColumnName, strColumnValue)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20101229 查詢聯系人信息以及重大傷病卡號"
    '    Function queryPUBPatientContactByCond(ByVal strChartNo As String, ByVal strIdNo As String) As System.Data.DataSet
    '        Dim instance As New PUBPatientContactBO_E2
    '        Try
    '            Return instance.queryPUBPatientContactByCond(strChartNo, strIdNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20110104 根據輸入的員工編號取得員工姓名 add by Runxia"
    Function queryPUBEmployeeByPK_L(ByVal strEmployeeCode As String) As System.Data.DataSet
        Dim instance As New PUBEmployeeBO_E2
        Try
            Return instance.queryByPK(strEmployeeCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region


    '#Region "20110106 營養諮詢作業使用 add by yunfei"
    '    ''' <summary>
    '    ''' 查詢所屬科室之醫師信息
    '    ''' </summary>
    '    ''' <param name="DeptCode"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBDoctorByDeptCode2(ByVal DeptCode As String) As System.Data.DataSet
    '        Dim instance As New PUBDoctorBO_E2
    '        Try
    '            Return instance.queryPUBDoctorByDeptCode2(DeptCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110110 腹膜透析排程預約  add by Runxia"
    '    ''' <summary>
    '    ''' 腹膜透析排程預約假日資料查詢
    '    ''' </summary>
    '    ''' <param name="strHolidayDate"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBHolidayByHolidayDate_L(ByVal strHolidayDate As String) As System.Data.DataSet
    '        Dim instance As New PUBHolidayBO_E2
    '        Try
    '            Return instance.queryPUBHolidayByHolidayDate(strHolidayDate)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110124 PUBContractBO_E2 OHM家醫科健檢報告列印寄發ComboBox資料來源 by mark zhang"
    '    Function queryPUBContractForComboBox_L() As DataSet
    '        Dim instance As New PUBContractBO_E2
    '        Try
    '            Return instance.queryPUBContractForComboBox()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110124 PUBDepartmentBO_E2 OHM家醫科健檢報告列印寄發ComboBox資料來源 by mark zhang"
    '    Function queryPUBDepartmentForCobomBox_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentForCobomBox()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110211 PUBDepartmentBO_E2 診區科別對照維護cobox科別資料來源  by johsn wu"
    '    Function queryPUBDepartmentIsEmg_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.dynamicQueryWithColumnValue(New String() {"Is_Emg_Dept", "Dc"}, New String() {"Y", "N"})
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110216 候床查詢 科別combobox by Add johsn wu"
    '    Function queryPUBDepartmentForQueryWaitingBed_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentForQueryWaitingBed()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110303 依登入的ID(操作人員)取得員工信息 by Add Runxia"

    '    Function queryPUBEmployeeByID_L(ByVal strEmployeeCode As String) As DataSet
    '        Dim instance As New PUBEmployeeBO_E2
    '        Try
    '            Return instance.queryPUBEmployeeByID(strEmployeeCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20110304 病患殘障記錄檔 by Add Runxia"

    Function queryPUBPatientDisabilityByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet
        Dim instance As New PUBPatientDisabilityBO_E2
        Try
            Return instance.queryPUBPatientDisabilityByCond(strChartNo, strEffectDate)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    Function confirmPUBPatientDisability_L(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer
        Dim instance As New PUBPatientDisabilityBS_E2
        Try
            Return instance.confirmPUBPatientDisability(strChartNo, strEffectDate, ds, blflag)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    Function queryMaxPatientDisabilityNo_L(ByVal strChartNo As String) As DataSet
        Dim instance As New PUBPatientDisabilityBO_E2
        Try
            Return instance.queryMaxPatientDisabilityNo(strChartNo)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    Function queryPUBSysCodeByTypeIdForDisability_L(ByVal strTypeId As String) As DataSet
        Dim instance As New PUBSysCodeBO_E2
        Try
            Return instance.queryPUBSysCodeByTypeIdForDisability(strTypeId)
        Catch ex As Exception
            '  log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

    '#Region "20110307 戶籍地檔維護  add by runxia "
    '    '查詢戶籍地檔資料
    '    Function queryPUBAreaCodeByCond_L(ByVal strAreaCode As String) As DataSet
    '        Try
    '            Return PUBAreaCodeBO_E2.GetInstance.queryPUBAreaCodeByCond(strAreaCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增戶籍地檔資料
    '    Function insertPUBAreaCode_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBAreaCodeBO_E2.GetInstance.insert(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除戶籍地檔資料
    '    Function deletePUBAreaCode_L(ByVal strAreaCode As String) As Integer
    '        Try
    '            Return PUBAreaCodeBO_E2.GetInstance.delete(strAreaCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '修改戶籍地檔資料
    '    Function updatePUBAreaCode_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBAreaCodeBO_E2.GetInstance.update(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110307 郵遞區號維護  add by pearl "
    '    '查詢郵遞區號資料
    '    Function queryPUBPostalCodeByCond_L(ByVal strPostalCode As String) As DataSet
    '        Try
    '            Return PUBPostalCodeBO_E2.GetInstance.queryPUBPostalCodeByCond(strPostalCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增郵遞區號資料
    '    Function insertPUBPostalCode_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBPostalCodeBO_E2.GetInstance.insert(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除郵遞區號資料
    '    Function deletePUBPostalCode_L(ByVal strPostalCode As String) As Integer
    '        Try
    '            Return PUBPostalCodeBO_E2.GetInstance.delete(strPostalCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '修改郵遞區號資料
    '    Function updatePUBPostalCode_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBPostalCodeBO_E2.GetInstance.update(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110309 郵遞區號對應戶籍地檔  add by pearl "
    '    '查詢郵遞區號對應戶籍地檔資料
    '    Function queryPubPostalAreaByCond_L(ByVal Postal_Code As String, ByVal Area_Code As String) As DataSet
    '        Try
    '            Return PUBPostalAreaBO_E2.GetInstance.queryPubPostalAreaByCond(Postal_Code, Area_Code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增郵遞區號對應戶籍地檔資料
    '    Function insertPubPostalArea_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBPostalAreaBO_E2.GetInstance.insert(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除郵遞區號對應戶籍地檔資料
    '    Function deletePubPostalArea_L(ByVal Postal_Code As String, ByVal Area_Code As String) As Integer
    '        Try
    '            Return PUBPostalAreaBO_E2.GetInstance.delete(Postal_Code, Area_Code)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '修改郵遞區號對應戶籍地檔資料
    '    Function updatePubPostalArea_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBPostalAreaBO_E2.GetInstance.updateByCond(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110318  門診健檢套餐報價作業  Click 加作折扣設定頁籤- 存檔Button or F10  add by mark zhang"
    '    Function insertPUBContractSetByCond_L(ByVal saveData As DataSet, _
    '                                          ByVal strEffectDate As String, _
    '                                          ByVal strContractCode As String, _
    '                                          ByVal strSubIdentityCode As String, _
    '                                          ByVal strOrderCode As String) As Integer
    '        Try
    '            Dim instance As PUBContractSetBS_E2 = New PUBContractSetBS_E2
    '            Return instance.insertPUBContractSetByCond(saveData, strEffectDate, strContractCode, strSubIdentityCode, strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "20110329 表單位置檔  add by Yunfei "
    '    '查詢表單位置檔資料
    '    Function queryPUBSheetLocationByCond_L(ByVal strSheetCode As String, ByVal strZoneId As String) As DataSet
    '        Try
    '            Return PUBSheetLocationBO_E2.GetInstance.queryPUBSheetLocationByCond(strSheetCode, strZoneId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '新增表單位置檔資料
    '    Function insertPUBSheetLocation_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBSheetLocationBO_E2.GetInstance.insert(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '刪除表單位置檔資料
    '    Function deletePUBSheetLocationByPK_L(ByVal strSheetCode As String, ByVal strZoneId As String) As Integer
    '        Try
    '            Return PUBSheetLocationBO_E2.GetInstance.delete(strSheetCode, strZoneId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '    '修改表單位置檔資料
    '    Function updatePUBSheetLocation_L(ByVal ds As DataSet) As Integer
    '        Try
    '            Return PUBSheetLocationBO_E2.GetInstance.update(ds)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20110608 PUBContractBO_E2 合約機構查詢（Sub_Identity_Code=91、82、01）  Add by liuye"
    '    Function queryPUBContractsSubIdentityCodeIN_L(ByVal strSubIdentityCode As String) As DataSet
    '        Try
    '            Return PUBContractBO_E2.GetInstance.queryPUBContractsSubIdentityCodeIN(strSubIdentityCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110705  by Add Yunfei"
    '    ''' <summary>
    '    ''' 獲取資料
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBInsuDeptCodeAndName_L() As DataSet
    '        Try
    '            Return PUBInsuDeptBO_E2.getInstance.queryPUBInsuDeptCodeAndName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110811 急診掛號病人表  離院型態資料來源  Add by prince"
    '    Function queryPUBSysCodeCodeAndName_L() As DataSet

    '        Dim instance As New PUBSysCodeBO_E2
    '        Try
    '            Return instance.queryPUBSysCodeCodeAndName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20110907 急診掛號病人表  離院型態資料來源  Add by prince"
    '    Function queryPUBDepartmentCodeAndName1_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentCodeAndName1()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

#Region "20110908  全國醫療服務卡維護檔新增修改  Add by Runxia "
    Function queryPubPatientFlagByChartNo_L(ByVal strChartNo As String) As DataSet
        Dim instance As New PubPatientFlagBO_E2
        Try
            Return instance.queryPubPatientFlagByChartNo(strChartNo)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    Function insertPUBHealthAndFlag_L(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer
        Dim instance As New PUBPatientHealthCardBS_E2
        Try
            Return instance.insertPUBHealthAndFlag(dsHealth, dsFlag, blFlag)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
#End Region

#Region "20111006  病患殘障記錄檔增修刪查  Add by ChenYang "

    '查詢
    Public Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet
        Try
            Return PUBPtDisabilityBO_E2.GetInstance.queryPUBPtDisabilityByCond_L(pk_Chart_No, pk_Patient_Disability_No)
        Catch ex As Exception
            ' log.Error(ex.ToString)
            Throw ex
        End Try
    End Function
    '新增
    Public Function insertPUBPtDisability_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPtDisabilityBO_E2.GetInstance.insert(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '刪除
    Function deletePUBPtDisabilityByPK_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As Integer) As Integer
        Try
            Return PUBPtDisabilityBO_E2.GetInstance.delete(pk_Chart_No, pk_Patient_Disability_No)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

    '修改
    Function updatePUBPtDisabilityByPK_L(ByVal ds As DataSet) As Integer
        Try
            Return PUBPtDisabilityBO_E2.GetInstance.update(ds)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#End Region

    '#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "
    '    Function queryPUBPostalCodeForCountryName_L() As DataSet
    '        Dim instance As New PUBPostalCodeBO_E2
    '        Try
    '            Return instance.queryPUBPostalCodeForCountryName()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet
    '        Dim instance As New PUBPostalCodeBO_E2
    '        Try
    '            Return instance.queryPUBPostalCodeForTownName(strCountryName)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet
    '        Dim instance As New PUBPatientBO_E2
    '        Try
    '            Return instance.queryPUBPatientForOMODiagnosisCertificate(strChartNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet
    '        Dim instance As New PUBDoctorLicenseBO_E2
    '        Try
    '            Return instance.queryPUBDoctorLicenseByEmployeeCode(EmployeeCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "2012/03/07 優待身分下拉選單查詢(PUBDisIdentityBO_E2) by liuye"

    '#Region "     優待身分下拉選單查詢 "
    '    ''' <summary>
    '    ''' 優待身分下拉選單查詢
    '    ''' </summary>
    '    ''' <returns>System.Data.DataSet</returns>
    '    ''' <remarks>by liuye on 2012-3-7</remarks>
    '    Public Function QueryPubDisIdentityBOWithColumnValue_L(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

    '        Dim m_PUBDisIdentityBOE2 As PUBDisIdentityBO_E2 = New PUBDisIdentityBO_E2
    '        Try

    '            Return m_PUBDisIdentityBOE2.QueryPubDisIdentityBOWithColumnValue(columnName, columnValue)
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region

    '#End Region

    '#Region "20120312  身份代碼查詢 for ComboBox  by Add Mark Zhang"
    '    ''' <summary>
    '    ''' 身份代碼查詢
    '    ''' </summary>
    '    ''' <returns>System.Data.DataSet</returns>
    '    ''' <remarks>by Mark Zhang on 2012-3-12</remarks>
    '    Public Function queryPUBSubIdentityForComboBox2_L() As DataSet
    '        Dim m_PUBSubIdentityBOE2 As PUBSubIdentityBO_E2 = New PUBSubIdentityBO_E2
    '        Try

    '            Return m_PUBSubIdentityBOE2.queryPUBSubIdentityForComboBox2()
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region

    '#Region "20120313 身分資料變更 , Add by Mark Zhang"
    '    ''' <summary>
    '    ''' 身分資料變更
    '    ''' </summary>
    '    ''' <returns>筆數</returns>
    '    ''' <remarks>by Mark Zhang on 2012-3-13</remarks>
    '    Public Function updatePUBPatientByDS_L(ByRef ds As DataSet) As Integer
    '        Dim m_PUBPatientBOE2 As PUBPatientBO_E2 = New PUBPatientBO_E2
    '        Try

    '            Return m_PUBPatientBOE2.updatePUBPatientByDS(ds)
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region

#Region "20120326 取得病患資料及戶籍地 , Add by Runxia"
    ''' <summary>
    ''' 取得病患資料及戶籍地
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>by Runxia on 2012-3-26</remarks>
    Public Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet
        Dim m_PUBPatientBOE2 As PUBPatientBO_E2 = New PUBPatientBO_E2
        Try

            Return m_PUBPatientBOE2.queryPUBPatientAndArea(strChartNo)
        Catch ex As Exception



            Throw ex

        End Try

    End Function

#End Region

    '#Region "20120326   申復爭議作業  Add by Runxia"
    '    ''' <summary>
    '    ''' 申復爭議作業
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function queryPUBDepartmentCodeForIHD_L() As DataSet
    '        Dim m_PUBDepartmentBOE2 As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
    '        Try

    '            Return m_PUBDepartmentBOE2.queryPUBDepartmentCodeForIHD()
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try
    '    End Function

    '#End Region

#Region "2012/04/02 科室/團隊查詢(PUBDepartmentBO_E2) by liuye"

#Region "     科室/團隊查詢 "
    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    Public Function queryPUBDepartmentCodeIsIpdDeptY_L() As DataSet

        Dim m_PUBDepartmentBO_E2 As PUBDepartmentBO_E2 = New PUBDepartmentBO_E2
        Try

            Return m_PUBDepartmentBO_E2.queryPUBDepartmentCodeIsIpdDeptY()
        Catch ex As Exception



            Throw ex

        End Try

    End Function

#End Region


#End Region



#Region "     2016/04/22 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Kaiwen"

#Region "     醫令項目代碼對應健保碼修改"

    ''' <summary>
    ''' 醫令項目代碼對應健保碼修改
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen Yang on 2012-5-14</remarks>
    Public Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBInsuCodeBO_E2 As PUBInsuCodeBO_E2 = New PUBInsuCodeBO_E2
        Try

            Return m_PUBInsuCodeBO_E2.updatePUBInsuCodeByPK_L(ds)
        Catch ex As Exception

            Throw ex

        End Try

    End Function

#End Region

#End Region

    '#Region "2012/05/14 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Chen Yang"
    '#End Region

    '#Region "2012/05/24 與RuleTransfer_N1關聯的切出部分(PUBRuleTransferN1BS_E2) by liuye"

    '#Region "     與RuleTransfer_N1關聯的切出部分 "
    '    ''' <summary>
    '    ''' 與RuleTransfer_N1關聯的切出部分
    '    ''' </summary>
    '    ''' <returns>Integer</returns>
    '    ''' <remarks>by liuye on 2012-5-24</remarks>
    '    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer

    '        Dim m_PUBRuleTransferN1BS_E2 As PUBRuleTransferN1BS_E2 = New PUBRuleTransferN1BS_E2
    '        Try
    '            '20120525 暫不提交
    '            Return m_PUBRuleTransferN1BS_E2.QuerymessageDataSet(dsQueryCond, OperationDS, totalRuleResult, messageDataSet)
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region


    '#End Region

    '#Region "20120604 PUBSubIdentityBO_E2 身份二查詢ForEmd by Add  Chen Yang"
    '    Function queryPUBSubIdentityandContractForEmd() As DataSet
    '        Try

    '            Dim instance As PUBSubIdentityBO_E2 = New PUBSubIdentityBO_E2
    '            Return instance.queryPUBSubIdentityandContractForEmd()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "20120626 add by prince 醫令項目計價碼對應名稱"
    '    '查詢醫令項目檔
    '    Function queryPubOrderByOrderCode3_L(ByVal strOrderCode As String) As DataSet
    '        Dim instance As New PUBOrderBO_E2
    '        Try
    '            Return instance.queryPubOrderByOrderCode3_L(strOrderCode)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region

    '#Region "2012-07-03 臨床營養照顧紀錄-Objective(PUBPatientBO_E2) by Johsn,wu"

    '#Region "     臨床營養照顧紀錄-Objective "
    '    ''' <summary>
    '    ''' 取得身高,最近體重,最近磅重日
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks>by Johsn,wu on 2012-07-03</remarks>
    '    Public Function QueryPubPatientHeightBW_L(ByVal strChartNo As String) As DataSet

    '        Dim m_PUBPatientBO_E2 As PUBPatientBO_E2 = New PUBPatientBO_E2
    '        Try
    '            Return m_PUBPatientBO_E2.QueryPubPatientHeightBW_L(strChartNo)
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region

    '#End Region

    '#Region "2012-07-03 臨床營養照顧紀錄-Objective(PUBPatientBodyRecordBO_E2) by Johsn,wu"

    '#Region "     臨床營養照顧紀錄-Objective "
    '    ''' <summary>
    '    ''' 取得前次磅重日,前次体重
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks>by Johsn,wu on 2012-07-03</remarks>
    '    Public Function QueryPubPatientBodyRecordPreBW_L(ByVal strChartNo As String) As DataSet

    '        Dim m_PUBPatientBodyRecordBO_E2 As PUBPatientBodyRecordBO_E2 = New PUBPatientBodyRecordBO_E2
    '        Try
    '            Return m_PUBPatientBodyRecordBO_E2.QueryPubPatientBodyRecordPreBW_L(strChartNo)
    '        Catch ex As Exception

    '            log.Error(ex.ToString)

    '            Throw ex

    '        End Try

    '    End Function

    '#End Region

    '#End Region

    '#Region "20120716 PUBStationBO_E2 PUBStationBO 以代號查詢資料 Add by yehui"
    '    Function queryPUBStationByCond(Optional ByVal station_No As String = Nothing) As DataSet

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.queryPUBStationByCond(station_No)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20120716 PUBStationBO_E2 PUBStationBO 新增資料 Add by yehui"
    '    Function insertPUBStation(Optional ByVal saveData As DataSet = Nothing) As Integer

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.insertPUBStation(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20120716 PUBStationBO_E2 PUBStationBO 更新資料 Add by yehui"
    '    Function updatePUBStation(Optional ByVal saveData As DataSet = Nothing) As Integer

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.updatePUBStation(saveData)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20120716 PUBStationBO_E2 PUBStationBO 刪除資料 Add by yehui"
    '    Function deletePUBStationByPK(Optional ByVal strStationNo As String = Nothing) As Integer

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.deletePUBStationByPK(strStationNo)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region
    '#Region "20120716 PUBStationBO_E2 PUBStationBO 查詢資料 Add by yehui"
    '    Function queryall() As DataSet

    '        Try
    '            Dim instance As PUBStationBO_E2 = New PUBStationBO_E2
    '            Return instance.queryAll()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20120821  急診片語維護科別資料來源 add by prince"
    '    Function queryPUBDepartmentEMO_L() As DataSet
    '        Dim instance As New PUBDepartmentBO_E2
    '        Try
    '            Return instance.queryPUBDepartmentEMO()
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    '#Region "20120906  健保門診處方箋報表 add by Runxia"
    '    Function queryPrinterName_L(ByVal strReportId As String) As DataSet
    '        Dim instance As New PUBPrintConfigBO_E2
    '        Try
    '            Return instance.queryPrinterName(strReportId)
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region



    '#Region "**2014-04-07 add by 長禎 - 病患重大傷病記錄修改、刪除時，寫入Log檔"

    '    '刪除病患重大傷病記錄時，寫入Log檔
    '    ''' <summary>
    '    ''' 刪除病患重大傷病記錄時，寫入Log檔
    '    ''' </summary>
    '    ''' <param name="ChartNo">病歷號</param>
    '    ''' <param name="IcdCode">ICDCode</param>
    '    ''' <param name="EffectDate">生效日</param>
    '    ''' <param name="Certificate_Sn">證明文號</param>
    '    ''' <param name="Is_From_Iccard">Is_From_Iccard</param>
    '    ''' <param name="Modify_User">異動人員</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Function deletePUBPatientSevereDiseaseWithLog_L(ByVal ChartNo As String, ByVal IcdCode As String, ByVal EffectDate As String, ByVal Certificate_Sn As String, ByVal Is_From_Iccard As String, ByVal Modify_User As String) As Integer
    '        Try
    '            '取得證明文號 -> 刪除時不適用
    '            'Dim Certificate_Sn As String = PUBPatientSevereDiseaseLogBO_E2.getInstance.GetCertificate_Sn(ChartNo, IcdCode, EffectDate) '先取得證明文號 -> 刪除時不適用
    '            Dim Modify_Type As String = "D" '刪除
    '            Dim RtnVal As Integer = 0

    '            'RtnVal = PUBPatientSevereDiseaseBO_E2.GetInstance.delete(ChartNo, IcdCode, EffectDate) '刪除使用者資料
    '            '寫入 Log 檔
    '            RtnVal = PUBPatientSevereDiseaseLogBO_E2.getInstance.InsertPubPatientServerDiseaseLog(ChartNo, IcdCode, EffectDate, Certificate_Sn, Is_From_Iccard, Modify_Type, Modify_User)

    '            Return RtnVal
    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function



    '    '修改病患重大傷病記錄時，寫入Log檔
    '    ''' <summary>
    '    ''' 修改病患重大傷病記錄時，寫入Log檔
    '    ''' </summary>
    '    ''' <param name="ds">修改資料之DataSet</param>
    '    ''' <param name="Modify_User">異動人員</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Function updatePUBPatientSevereDiseaseWithLog_L(ByVal ds As DataSet, ByVal Modify_User As String) As Integer
    '        Try
    '            Dim RtnVal As Integer = 0
    '            'RtnVal = PUBPatientSevereDiseaseBO_E2.GetInstance.update(ds) '更新使用者資料


    '            '若有修改，才寫入 Log 檔
    '            'If RtnVal > 0 Then 
    '                Dim Modify_Type As String = "E" '修改

    '                Dim ChartNo As String = ""
    '                Dim IcdCode As String = ""
    '                Dim EffectDate As String = ""
    '                Dim Certificate_Sn As String = "" '證明文號
    '                Dim Is_From_Iccard As String = ""


    '                '寫入 Log 檔
    '                For Each row As DataRow In ds.Tables(0).Rows
    '                    ChartNo = If(row.Table.Columns.Contains("Chart_No"), row.Item("Chart_No"), Nothing)
    '                    IcdCode = If(row.Table.Columns.Contains("Icd_Code"), row.Item("Icd_Code"), Nothing)
    '                    EffectDate = If(row.Table.Columns.Contains("Effect_Date"), row.Item("Effect_Date"), Nothing)
    '                    Certificate_Sn = If(row.Table.Columns.Contains("Certificate_Sn"), row.Item("Certificate_Sn"), Nothing)
    '                    'End_Date = If(row.Table.Columns.Contains("End_Date"), row.Item("End_Date"), Nothing)
    '                    Is_From_Iccard = If(row.Table.Columns.Contains("Is_From_Iccard"), row.Item("Is_From_Iccard"), Nothing)
    '                    'Modify_Type = If(row.Table.Columns.Contains("Modify_Type"), row.Item("Modify_Type"), Nothing)
    '                    'Modify_User = If(row.Table.Columns.Contains("Modify_User"), row.Item("Modify_User"), Nothing)
    '                    'Modify_Time = If(row.Table.Columns.Contains("Modify_Time"), row.Item("Modify_Time"), Nothing)

    '                    '寫入 Log 檔
    '                    RtnVal = RtnVal + PUBPatientSevereDiseaseLogBO_E2.getInstance.InsertPubPatientServerDiseaseLog(ChartNo, IcdCode, EffectDate, Certificate_Sn, Is_From_Iccard, Modify_Type, Modify_User)
    '                    ''或
    '                    'PUBPatientSevereDiseaseBO_E2.getInstance.InsertPubPatientServerDiseaseLog(strChartNo, strIcdCode, strEffectDate, "", Modify_Type, Modify_User)
    '                Next
    '           'End If

    '            Return RtnVal

    '        Catch ex As Exception
    '            log.Error(ex.ToString)
    '            Throw ex
    '        End Try
    '    End Function

    '#End Region


    '#Region "**2014-04-11 add by 長禎 - 查詢病患重大傷病異動記錄(修改、刪除)"
    '    ''' <summary>
    '    ''' 查詢病患重大傷病異動記錄(修改、刪除)
    '    '''   1. 查詢全部
    '    '''   2. 部分查詢  
    '    ''' </summary>
    '    ''' <param name="Chart_No">病歷號</param>
    '    ''' <param name="Icd_Code">Icd_Code</param>
    '    ''' <param name="Effect_Date">生效日</param>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks></remarks>
    '    Function queryPUBPatientSevereDiseaseLog_L(ByVal Chart_No As String, ByVal Icd_Code As String, ByVal Effect_Date As String) As DataSet
    '        'If Chart_No = "" And Icd_Code = "" And Effect_Date = "" Then '查詢全部
    '        '    Return PUBPatientSevereDiseaseLogBO_E2.getInstance.queryAll()
    '        'Else '以PK查詢
    '        '    Return PUBPatientSevereDiseaseLogBO_E2.getInstance.queryByPK(Chart_No, Icd_Code, Effect_Date)
    '        'End If
    '        Return PUBPatientSevereDiseaseLogBO_E2.getInstance.queryPubPatientServerDiseaseLog(Chart_No, Icd_Code, Effect_Date)
    '    End Function

    '#End Region

#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet
        Try
            Dim instance As PUBPatientBO_E2 = New PUBPatientBO_E2
            Return instance.queryPUBPatientBychartNo_L(chartNo)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function
#End Region


#Region "20090724 所屬單位查詢醫師信息   by Add Ming"
    '取得就醫科別資料來源
    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As DataSet
        Dim instance As New PUBDoctorBO_E2
        Try
            Return instance.queryPUBDoctorByDeptCode(DeptCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet
        Dim instance As New PUBDoctorBO_E2
        Try
            Return instance.queryPUBDoctorByDoctorCode(DoctorCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    ''' <summary>
    ''' 查詢默認部位
    ''' </summary>
    ''' <param name="strOrder_Code"></param>
    ''' <param name="strFavor_Type_Id">D:常用處置維護  H:常用檢驗(查)維護 A:常用診斷維護 E:常用藥品維護 G：常用衛材維護</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String
        Select Case strFavor_Type_Id
            Case "D"
                Dim ds As DataSet = PubOrderOrTreatBO.GetInstance.queryByPK(strOrder_Code)
                If (ds.Tables(0).Rows.Count > 0) Then
                    Return ds.Tables(0).Rows(0)("Default_Body_Site_Code").ToString
                End If
            Case "H"
                Dim ds As DataSet = PubOrderExaminationBO.GetInstance.queryByPK(strOrder_Code)
                If (ds.Tables(0).Rows.Count > 0) Then
                    Return ds.Tables(0).Rows(0)("Default_Body_Site_Code").ToString
                End If
            Case "A"
            Case "E"
            Case "G"
        End Select
        Return String.Empty
    End Function
    ''' <summary>
    '''  查詢醫令代碼對應檢體檔
    ''' </summary>
    ''' <param name="strOrder_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As System.Data.DataSet
        Try
            Return PUBOrderMappingSpecimenBO_E2.GetInstance.queryPUBOrderMappingSpecimenByOrderCode(strOrder_Code)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "2012/05/24 與RuleTransfer_N1關聯的切出部分(PUBRuleTransferN1BS_E2) by liuye"

#Region "     與RuleTransfer_N1關聯的切出部分 "
    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-5-24</remarks>
    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer

        Dim m_PUBRuleTransferN1BS_E2 As PUBRuleTransferN1BS_E2 = New PUBRuleTransferN1BS_E2
        Try
            '20120525 暫不提交
            Return m_PUBRuleTransferN1BS_E2.QuerymessageDataSet(dsQueryCond, OperationDS, totalRuleResult, messageDataSet)
        Catch ex As Exception

            Throw ex

        End Try

    End Function

#End Region


#End Region

#Region "add by prince 20150911"
    Public Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet
        Dim instance As PUBOrderMappingSpecimenBO_E1 = PUBOrderMappingSpecimenBO_E1.GetInstance
        Try
            Return instance.queryOrderMappingSpecimenByCond4(OrderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region



#Region "20150915 由病歷號 取得姓名、性別、出生年月日、國籍 、身份證號、電話號碼、通訊處 ,add by Remote"
    ''' <summary>
    ''' 國際疫苗申請書輸入
    ''' </summary>
    ''' <param name="strChart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet
        Try
            Return PUBPatientBO_E2.GetInstance.queryPUBPatientAndBasicData(strChart_No)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2015/10/20 檢核規則維護 成醫舊程式搬移 by HE,Alien"

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 查詢 "
    Public Function queryByPkRuleCode(ByVal pk_Rule_Code As System.String) As DataSet
        Try
            Dim instance As PubPuleReasonBO_E2 = PubPuleReasonBO_E2.GetInstance
            Return instance.queryByPkRuleCode(pk_Rule_Code)

        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 刪除 "

    ''' <summary>
    ''' 檢核規則理由DGV(dgv_CheckReason) - 刪除
    ''' </summary>
    ''' <param name="pk_Rule_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteByPkRuleCode(ByVal pk_Rule_Code As System.String) As Integer
        Try
            Dim instance As PubPuleReasonBO_E2 = PubPuleReasonBO_E2.GetInstance
            Return instance.deleteByPkRuleCode(pk_Rule_Code)

        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 初始檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function initPUBRuleCheckUIInfo() As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.initPUBRuleCheckUIInfo()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢規則檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBRuleQueryInfo() As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.initPUBRuleQueryInfo()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.queryRuleDataByRuleParam(RuleParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：確認查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="confirmType">確認類別</param>
    ''' <param name="RuleDS">規則資料</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.confirmRuleData(confirmType, RuleDS)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function querySelectedRuleData(ByVal selectRuleCode As String) As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.querySelectedRuleData(selectRuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：刪除查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="ruleCode">檢核規則碼</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function deleteRuleData(ByVal ruleCode As String) As Boolean
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.deleteRuleData(ruleCode)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRuleSerialNo() As String
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.getRuleSerialNo()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢ruleclass(續接)
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.queryRuleGroup(itemParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢ruleclass(查詢)
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet
        Try
            Dim instance As PUBRuleCheckBS = PUBRuleCheckBS.getInstance
            Return instance.queryRuleByCondition(itemParam, detailParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 程式說明：依員工碼查醫師資料(for 規則編輯器)
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="employeeCodes">員工碼</param>
    ''' <returns>DataTable</returns>
    Public Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable
        Try
            Dim instance As PUBDOCTORBO_E1 = PUBDOCTORBO_E1.getInstance
            Return instance.queryRuleDoctorByEmployeeCodes(employeeCodes)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    '記錄使用者更新或刪除檢核規則
    Public Function InsertPUB_Rule_Transaction_Log(ByVal ds As DataSet) As Integer
        Try
            Dim instance As PUBRuleTransactionLogBO_E1 = PUBRuleTransactionLogBO_E1.getInstance
            Return instance.insert(ds)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 改名稱
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getExprre(ByVal ds As String) As String
        Return PUBRuleBO_E1.getInstance.getExprre(ds)
    End Function
#End Region

#Region "2015/10/26 檢核規則維護 成醫舊程式搬移 by HE,Alien"

    ''' <summary>
    ''' 程式說明：確認查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="confirmType">確認類別</param>
    ''' <param name="RuleDS">規則資料</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer
        Try
            Dim instance As PUBRuleCheckTreeBS = PUBRuleCheckTreeBS.getInstance
            Return instance.confirmTreeRuleData(confirmType, RuleDS)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRuleMaintainSerialNo() As Integer
        Try
            Dim instance As PUBRuleCheckTreeBS = PUBRuleCheckTreeBS.getInstance
            Return instance.getRuleMaintainSerialNo
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function


    '----------------tree edition----------------------
    ''' <summary>
    ''' 查詢規則檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBRuleTreeQueryInfo() As DataSet
        Try
            Dim instance As PUBRuleCheckTreeBS = PUBRuleCheckTreeBS.getInstance
            Return instance.initPUBRuleTreeQueryInfo()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 查詢檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function querySelectedTreeRuleData(ByVal selectRuleCode As String) As DataSet
        Try
            Dim instance As PUBRuleCheckTreeBS = PUBRuleCheckTreeBS.getInstance
            Return instance.querySelectedTreeRuleData(selectRuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' 查詢ruleclass(查詢)
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet
        Try
            Dim instance As PUBRuleCheckTreeBS = PUBRuleCheckTreeBS.getInstance
            Return instance.queryTreeRuleByCondition(itemParam, detailParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function


#End Region

#Region "20160507  檢驗組別,IO類別(PUBSysCodeBO_E2) Add by Remote"
    Function querySpicemenType() As DataSet
        Try
            Return PUBSysCodeBO_E2.getInstance.querySpicemenType()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/05/18 PUBPreventiveCare 預防保健基本檔設定維護 ,add by Remote"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareInsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareUpdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PubPreventiveCareDeleteByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As Integer

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.delete(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareQueryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As System.Data.DataSet

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.queryByPK(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareQueryAll() As System.Data.DataSet

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareQueryByLikePK(ByRef pk_Care_Item_Code As System.String) As System.Data.DataSet

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.queryByLikePK(pk_Care_Item_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region

#Region " 取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function queryPUBCareItemAgeSex() As DataSet

        Dim m_PUBPreventiveCare As PUBPreventiveCareBO_E2 = New PUBPreventiveCareBO_E2
        Try

            Return m_PUBPreventiveCare.queryPUBCareItemAgeSex()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"確認診斷碼是否存在"})

        End Try

    End Function

#End Region

#End Region

#Region "2016/05/16 健保科別設定維護(PUBInsuDeptSetupUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBInsuDeptInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBInsuDeptSetup As PUBInsuDeptSetupBO_E2 = New PUBInsuDeptSetupBO_E2
        Try

            Return m_PUBInsuDeptSetup.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBInsuDeptUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBInsuDeptSetup As PUBInsuDeptSetupBO_E2 = New PUBInsuDeptSetupBO_E2
        Try

            Return m_PUBInsuDeptSetup.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBInsuDeptdeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBInsuDeptSetup As PUBInsuDeptSetupBO_E2 = New PUBInsuDeptSetupBO_E2
        Try

            Return m_PUBInsuDeptSetup.deleteChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBInsuDeptQueryByPKROC(ByRef Insu_Dept_Code As System.String) As System.Data.DataSet

        Dim m_PUBInsuDeptSetup As PUBInsuDeptSetupBO_E2 = New PUBInsuDeptSetupBO_E2
        Try

            Return m_PUBInsuDeptSetup.queryByPKROC(Insu_Dept_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(民國年)"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function queryAllROC() As System.Data.DataSet

        Dim m_PUBInsuDeptSetup As PUBInsuDeptSetupBO_E2 = New PUBInsuDeptSetupBO_E2
        Try

            Return m_PUBInsuDeptSetup.queryAllROC()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部(民國年)"})

        End Try

    End Function

#End Region




#End Region

#Region "2016-05-19 PUBSubIdentityBO_E2 身份二查詢  Add by Xiaozhi"
    Function queryPUBSubMedicalType() As DataSet
        Try

            Dim instance As PUBSubIdentityBO_E2 = New PUBSubIdentityBO_E2
            Return instance.queryPUBSubMedicalType()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try
    End Function

#End Region

#Region "2016/05/24 五都戶籍地設定維護(PUBAreaCodeNSetupUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Public Function PUBAreaCodeNInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBAreaCodeNSetup As PUBAreaCodeNBO_E2 = New PUBAreaCodeNBO_E2
        Try

            Return m_PUBAreaCodeNSetup.InsertAreaCode(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Public Function PUBAreaCodeNUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBAreaCodeNSetup As PUBAreaCodeNBO_E2 = New PUBAreaCodeNBO_E2
        Try

            Return m_PUBAreaCodeNSetup.UpdateAreaCode(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Public Function PUBAreaCodeNdeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBAreaCodeNSetup As PUBAreaCodeNBO_E2 = New PUBAreaCodeNBO_E2
        Try

            Return m_PUBAreaCodeNSetup.deleteAreaCodeChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Public Function PUBAreaCodeNQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet

        Dim m_PUBAreaCodeNSetup As PUBAreaCodeNBO_E2 = New PUBAreaCodeNBO_E2
        Try

            Return m_PUBAreaCodeNSetup.queryAreaCodeByPK(Area_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(民國年)"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function queryAreaCodeAll() As System.Data.DataSet

        Dim m_PUBAreaCodeNSetup As PUBAreaCodeNBO_E2 = New PUBAreaCodeNBO_E2
        Try

            Return m_PUBAreaCodeNSetup.queryAreaCodeAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部(民國年)"})

        End Try

    End Function

#End Region




#End Region

#Region "2016/05/25 行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBAreaCodeGovSetup As PUBAreaCodeGovBO_E2 = New PUBAreaCodeGovBO_E2
        Try

            Return m_PUBAreaCodeGovSetup.InsertAreaCodeGov(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBAreaCodeGovSetup As PUBAreaCodeGovBO_E2 = New PUBAreaCodeGovBO_E2
        Try

            Return m_PUBAreaCodeGovSetup.UpdateAreaCodeGov(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovdeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBAreaCodeGovSetup As PUBAreaCodeGovBO_E2 = New PUBAreaCodeGovBO_E2
        Try

            Return m_PUBAreaCodeGovSetup.deleteAreaCodeGovChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet

        Dim m_PUBAreaCodeGovSetup As PUBAreaCodeGovBO_E2 = New PUBAreaCodeGovBO_E2
        Try

            Return m_PUBAreaCodeGovSetup.queryAreaCodeGovByPK(Area_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(縣市代碼)"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryAreaCodeGovAll() As System.Data.DataSet

        Dim m_PUBAreaCodeGovSetup As PUBAreaCodeGovBO_E2 = New PUBAreaCodeGovBO_E2
        Try

            Return m_PUBAreaCodeGovSetup.queryAreaCodeGovAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部()"})

        End Try

    End Function

#End Region




#End Region

#Region "2016/05/26 郵遞區號對應行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.InsertPostalArea(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.UpdatePostalArea(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.deletePostalAreaChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.queryPostalAreaByPK(Postal_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(縣市代碼)"})

        End Try

    End Function

#End Region

#Region "     以所有PK查詢資料 "
    ''' <summary>
    ''' 以所有PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalAreaQueryByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String) As System.Data.DataSet

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.queryPostalAreaByPKAll(Postal_Code, Area_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(郵遞區號)"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryPostalAreaAll() As System.Data.DataSet

        Dim m_PUBPostalAreaSetup As PUBPostalAreaBO_E2 = New PUBPostalAreaBO_E2
        Try

            Return m_PUBPostalAreaSetup.queryPostalAreaAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部()"})

        End Try

    End Function

#End Region




#End Region

#Region "2016/05/26 郵遞區號對應行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-27</remarks>
    Public Function PUBPostalGovAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPostalGovAreaSetup As PUBPostalGovAreaBO_E2 = New PUBPostalGovAreaBO_E2
        Try

            Return m_PUBPostalGovAreaSetup.InsertPostalGovArea(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalGovAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPostalGovAreaSetup As PUBPostalGovAreaBO_E2 = New PUBPostalGovAreaBO_E2
        Try

            Return m_PUBPostalGovAreaSetup.UpdatePostalGovArea(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalGovAreadeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBPostalGovAreaSetup As PUBPostalGovAreaBO_E2 = New PUBPostalGovAreaBO_E2
        Try

            Return m_PUBPostalGovAreaSetup.deletePostalGovAreaChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBPostalGovAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet

        Dim m_PUBPostalGovAreaSetup As PUBPostalGovAreaBO_E2 = New PUBPostalGovAreaBO_E2
        Try

            Return m_PUBPostalGovAreaSetup.queryPostalGovAreaByPK(Postal_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(縣市代碼)"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryPostalGovAreaAll() As System.Data.DataSet

        Dim m_PUBPostalGovAreaSetup As PUBPostalGovAreaBO_E2 = New PUBPostalGovAreaBO_E2
        Try

            Return m_PUBPostalGovAreaSetup.queryPostalGovAreaAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部()"})

        End Try

    End Function

#End Region




#End Region

#Region "20160601  資料來源Type_Id = '128'(PUBSysCodeBO_E2) Add by Remote"
    ''' <summary>
    ''' 資料來源（門診，急診，住院）
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeSourceId() As DataSet
        Try
            Return PUBSysCodeBO_E2.getInstance.queryPUBSysCodeSourceId()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "20160620 由來源,病歷號,就診日期 取得就醫序號 by remote_liu "

    ''' <summary>
    ''' 由來源,病歷號,就診日期取得就醫序號
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <param name="conn">The connection.</param>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-20</remarks>
    Public Function queryMedicalSn(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Return PUBPatientBO_E2.GetInstance.queryMedicalSn(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "20160620 由病歷號,就診日期 取得媽媽姓名 by remote_liu "

    ''' <summary>
    ''' 由來源,病歷號,就診日期取得就醫序號
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <param name="conn">The connection.</param>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-20</remarks>

    Public Function queryMotherName(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Return PUBPatientBO_E2.GetInstance.queryMotherName(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "20160620 護理站 by remote_liu "

    ''' <summary>
    ''' 護理站
    ''' </summary>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-20</remarks>

    Public Function queryStationNo(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Return PUBDoctorBO_E2.getInstance.queryStationNo()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/06/28 ICD9_ICD10對照檔(PUB_Disease_ICD10_Mapping) by Li,Han"

#Region "     新增 Method "
    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappinginsertData(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.insertData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增 Method"})

        End Try

    End Function

#End Region


#Region "     修改 Method "
    ''' <summary>
    ''' 修改 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingupdateData(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.updateData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改 Method"})

        End Try

    End Function

#End Region


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingdeleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As Integer

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.deleteData(pk_Disease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除 Method"})

        End Try

    End Function

#End Region


#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.queryGridData(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Gird資料"})

        End Try

    End Function

#End Region

#Region "     取得Gird資料ByPk "
    ''' <summary>
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.queryGridDataByPk(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Gird資料ByPk"})

        End Try

    End Function

#End Region

#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingquertCmbData() As DataSet

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.quertCmbData()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Combox資料"})

        End Try

    End Function

#End Region


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer

        Dim m_PUBDiseaseICD10Mapping As PUBDiseaseICD10MappingBO_E2 = New PUBDiseaseICD10MappingBO_E2
        Try

            Return m_PUBDiseaseICD10Mapping.fCheckIcdCode(strICD, strTBName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查該診斷是否存在"})

        End Try

    End Function

#End Region


#End Region

#Region "2016/06/29 ICD10科別對照檔(PUB_ICD10_Dept) by Li,Han"

#Region "     新增 Method "
    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptinsertData(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.insertData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增 Method"})

        End Try

    End Function

#End Region


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptdeleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String) As Integer

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.deleteData(pk_Kind_Code, pk_Disease_Type_Id, pk_ICD10_Code, pk_Insu_Dept_Code, pk_Insu_Sub_Dept_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除 Method"})

        End Try

    End Function

#End Region


#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.queryGridData(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Gird資料"})

        End Try

    End Function

#End Region


#Region "     取得Gird資料ByPK "
    ''' <summary>
    ''' 取得Gird資料ByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.queryGridDataByPk(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Gird資料ByPK"})

        End Try

    End Function

#End Region


#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryCmbData(ByRef strTBName As String, ByRef strWhere As String) As DataSet

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.queryCmbData(strTBName, strWhere)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Combox資料"})

        End Try

    End Function

#End Region


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer

        Dim m_PUBICD10Dept As PubIcd10DeptBO_E2 = New PubIcd10DeptBO_E2
        Try

            Return m_PUBICD10Dept.fCheckIcdCode(strICD, strTBName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查該診斷是否存在"})

        End Try

    End Function

#End Region


#End Region

#Region "  2016/06/28 取得費用(PUBOrderPriceBO_E2) by Remote    "

    ''' <summary>
    ''' 取得費用
    ''' </summary>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-28</remarks>

    Public Function PUBOrderPrice(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Return PUBOrderPriceBO_E2.GetInstance.PUBOrderPrice(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "  2016/06/28 取得手術法(PUBOrderBO_E2) by Remote    "

    ''' <summary>
    ''' 取得手術法
    ''' </summary>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-28</remarks>

    Public Function PUBOrderOrderName(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Return PUBOrderBO_E2.getInstance.PUBOrderOrderName(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "     2016/06/28 傷口分類(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 傷口分類
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBSyscodeWoundType() As DataSet

        Try
            Return PUBSysCodeBO_E2.getInstance.PUBSyscodeWoundType()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "     2016/06/28 部位(PUBBodySiteBO_E2) by Remote  "
    ''' <summary>
    ''' 部位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBBodySiteBodyparts() As DataSet

        Try
            Return PUBBodySiteBO_E2.GetInstance.PUBBodySiteBodyparts()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "    2016/06/28 側位 by Remote(PUBSysCodeBO_E2)  "
    ''' <summary>
    ''' 側位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBSyscodeBodySide() As DataSet

        Try
            Return PUBSysCodeBO_E2.getInstance.PUBSyscodeBodySide()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "     2016/07/05 急作手術分級(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 急作手術分級
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-07-05</remarks>
    Public Function PUBSyscodeUrgentClass() As DataSet

        Try
            Return PUBSysCodeBO_E2.getInstance.PUBSyscodeUrgentClass()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "20160813 PUBSheetBO 檢驗單資料for ComboBox by Add Remote"
    ''' <summary>
    ''' 檢驗單
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-08-13</remarks>
    Public Function queryPUBSheetCode() As DataSet

        Try
            Return PUBSheetBO_E2.getInstance.queryPUBSheetCode()
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/09/09 add by qun 依據健保碼內容查詢主手術碼設定下拉選單"
    ''' <summary>
    ''' 依據健保碼內容查詢主手術碼設定下拉選單
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by qun on 2016-09-09</remarks>
    Public Function queryICD10PCS_Code(ByVal strInsuCode As System.String) As DataSet
        Dim instance As New PubDiseaseIcd10pcsInsuMappingBO_E2
        Try
            Return instance.queryICD10PCS_Code(strInsuCode)
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/09/23 新增非藥品替代醫令檔(PUBOrderAlternativeUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBOrderAlternativeInsertByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBOrderAlternative As PUBOrderAlternativeBO_E2 = New PUBOrderAlternativeBO_E2
        Try

            Return m_PUBOrderAlternative.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function


#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBOrderAlternativeUpdateByPK(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBOrderAlternative As PUBOrderAlternativeBO_E2 = New PUBOrderAlternativeBO_E2
        Try

            Return m_PUBOrderAlternative.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBOrderAlternativedeleteChoose(ByVal dsDelete As DataSet) As Integer

        Dim m_PUBOrderAlternative As PUBOrderAlternativeBO_E2 = New PUBOrderAlternativeBO_E2
        Try

            Return m_PUBOrderAlternative.deleteChoose(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除多筆資料"})

        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi on 2016-05-11</remarks>
    Public Function PUBOrderAlternativequeryByPKOrderCode(ByRef Order_Code As System.String) As System.Data.DataSet

        Dim m_PUBOrderAlternative As PUBOrderAlternativeBO_E2 = New PUBOrderAlternativeBO_E2
        Try

            Return m_PUBOrderAlternative.queryByPKOrderCode(Order_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢資料(醫令碼)"})

        End Try

    End Function

#End Region


#End Region

#Region "          2017/1/16 非藥品替代醫令檔維護 add by Michelle"

#Region "   2017/1/16 非藥品替代醫令檔維護 add by Michelle"
    
    Public Function insertPUBOrder(ByVal dsData As DataSet) As Integer
        Try
            'Return INPBedBO_E1.GetInstance.insert(dsData)
            Return PUBOrderAlternativeBO_E2.GetInstance.newPUBOrderByOrderCode(dsData, "Insert")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    Public Function updatePUBOrder(ByVal dsData As DataSet) As Integer
        Try
            'Return INPBedBO_E1.GetInstance.insert(dsData)
            Return PUBOrderAlternativeBO_E2.GetInstance.newPUBOrderByOrderCode(dsData, "Update")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function
#End Region

#Region "  2017/1/16  非藥品替代醫令檔維護刪除 add by Michelle"
   
    Public Function DeletePUBOrder(ByVal dsDelete As DataSet) As Integer
        Try
            'Return INPBedBO_E1.GetInstance.delete(_Bed_No)
            Return PUBOrderAlternativeBO_E2.GetInstance.DeletePUBOrderAlternativeByOrderCode(dsDelete)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function
#End Region

#End Region

End Class
