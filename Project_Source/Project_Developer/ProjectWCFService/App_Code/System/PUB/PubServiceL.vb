Imports Syscom.Server.PUB

Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System

' 注意: 若變更此處的類別名稱 "PubServiceL"，也必須更新 Web.config 與關聯之 .svc 檔案中 "PubServiceL" 的參考。
Public Class PubServiceL
    Implements IPubServiceL

    Public Sub DoWork() Implements IPubServiceL.DoWork
    End Sub

#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"
    Public Function queryPUBContractsForBILRPT09460() As DataSet Implements IPubServiceL.queryPUBContractsForBILRPT09460
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractsForBILRPT09460()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region " Add by Elly.Gao on 2016/12/27 for 兵檢資料轉換作業 OHMConvertMilitaryExcelUI"
    Public Function queryAreaCodeGovByGovADist(ByVal strGovAndDistCode As String) As DataSet Implements IPubServiceL.queryAreaCodeGovByGovADist
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryAreaCodeGovByGovADist(strGovAndDistCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region


#Region "200901010 轉診轉出--建議轉診科別 by Add tor"
    Public Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet Implements IPubServiceL.queryPUBDeptHealthOpdDeptCodeName_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDeptHealthOpdDeptCodeName_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region


#Region "20091021 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查) Dc = 'N'，add by Tor"
    Function queryPUBOrderByDate_L(ByVal OutDate As String) As DataSet Implements IPubServiceL.queryPUBOrderByDate_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBOrderByDate_L(OutDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function



#End Region
#Region "20150915 PUBDeptSect 科診維護   by Will,Lin"

    ' 依條件查詢科診名稱 
    Function queryPubDeptSectByCond_L(ByVal strDeptCode As String, ByVal strSectId As String) As DataSet Implements IPubServiceL.queryPubDeptSectByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubDeptSectByCond_L(strDeptCode, strSectId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    ' 新增科診名稱 
    Function insertPubDeptSect_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPubDeptSect_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPubDeptSect_L(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除科診名稱
    Function deletePubDeptSectByPK_L(ByVal strDeptCode As String, ByVal strSectId As String) As Integer Implements IPubServiceL.deletePubDeptSectByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePubDeptSectByPK_L(strDeptCode, strSectId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '更新科診名稱
    Function updatePubDeptSectByCond_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePubDeptSectByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePubDeptSectByCond_L(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#Region "2015/11/11 科診屬性代碼查詢(PUB_Dept_Sect) by Eddie,Lu"

#Region "     科診屬性代碼查詢 "
    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBDeptSectqueryCboData(ByVal typeId As Integer) As DataSet Implements IPubServiceL.PUBDeptSectqueryCboData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDeptSectqueryCboData(typeId)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region


#End Region

#Region "20150915 PUBDepartmentUI 科室檔維護   by Will,Lin"

    ' 依條件查詢科室檔資料 
    Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As DataSet Implements IPubServiceL.queryPUBDepartmentByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDepartmentByCond(strDeptCode, strDeptName, strDeptEnName)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    ' 新增科室檔資料 
    Function insertPUBDepartment(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBDepartment
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBDepartment(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除科室檔資料
    Function deletePUBDepartment(ByVal strDeptCode As String) As Integer Implements IPubServiceL.deletePUBDepartment
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBDepartment(strDeptCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '更新科室檔資料
    Function updatePUBDepartment(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBDepartment
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBDepartment(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryPubDeptSect_L(ByVal strDeptCode As String) As DataSet Implements IPubServiceL.queryPubDeptSect_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubDeptSect_L(strDeptCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    '獲取Department資料
    Function queryPUBDepartmentCA() As DataSet Implements IPubServiceL.queryPUBDepartmentCA
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDepartmentByCA()
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function


#End Region
#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"

    Public Function querySheetCode_L(ByVal strPubSheetCode As String) As DataSet Implements IPubServiceL.querySheetCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.querySheetCode_L(strPubSheetCode)
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function

#End Region

#Region "20090814 PUBBodySiteUI 部位檔維護  by tianxie"

    ' 查詢某一部位 
    Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As DataSet Implements IPubServiceL.queryPUBBodySiteByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBBodySiteByCond(strBodySiteCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    ' 查詢某一部位 
    Function queryNhiBodySiteCodeByColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet Implements IPubServiceL.queryNhiBodySiteCodeByColumnValue
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryNhiBodySiteCodeByColumnValue(columnName, columnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As DataSet Implements IPubServiceL.queryMainBodySiteCodeByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryMainBodySiteCodeByCond(strBodySiteCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '新增部位
    Function insertPUBBodySite(ByVal ds As DataSet) As Integer Implements IPubServiceL.insertPUBBodySite
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBBodySite(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除部位
    Function deletePUBBodySiteByPK(ByRef pk_Body_Site_Code As String) As Integer Implements IPubServiceL.deletePUBBodySiteByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBBodySiteByPK(pk_Body_Site_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '更新部位
    Function updatePUBBodySite(ByVal ds As DataSet) As Integer Implements IPubServiceL.updatePUBBodySite
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBBodySite(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150915 PUBNhiCodeUI 健保支付標準檔  Add by Runxia"

    ' 查詢特定治療項目基本檔資料 
    Function queryPUBMajorNoEquByCond_L(ByVal strMajorcareCode As String) As DataSet Implements IPubServiceL.queryPUBMajorNoEquByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBMajorNoEquByCond_L(strMajorcareCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    ' 查詢健保支付標準檔,(檢驗檢查)  
    Function queryPUBNhiCodeByCond_L(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet Implements IPubServiceL.queryPUBNhiCodeByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBNhiCodeByCond_L(strEffectDate, strInsuCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除健保支付標準檔
    Function deletePUBNhiCodeByInsuCode_L(ByVal strInsuCode As String) As Integer Implements IPubServiceL.deletePUBNhiCodeByInsuCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBNhiCodeByInsuCode_L(strInsuCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '確定儲存 健保支付標準檔
    Function confirmPUBNhiCode_L(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBNhiCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBNhiCode_L(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBNhiCodeUpDown_L(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet Implements IPubServiceL.queryPUBNhiCodeUpDown_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBNhiCodeUpDown_L(strEffectDate, strInsuCode, itype)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBNhiDeptCode() As DataSet Implements IPubServiceL.queryPUBNhiDeptCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBNhiDeptCode()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20100422 PubPatientSevereDiseaseBO 病患重大傷病記錄檔  Add by Runxia"
    '查詢病患重大傷病記錄檔
    Function queryPUBPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date) As DataSet Implements IPubServiceL.queryPUBPatientSevereDiseaseByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientSevereDiseaseByCond_L(strChartNo, strIcdCode, dateEffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '新增病患重大傷病記錄檔
    Function insertPUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.insertPUBPatientSevereDisease_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBPatientSevereDisease_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除病患重大傷病記錄檔
    Function deletePUBPatientSevereDisease_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal strEffectDate As String) As Integer Implements IPubServiceL.deletePUBPatientSevereDisease_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBPatientSevereDisease_L(strChartNo, strIcdCode, strEffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '修改病患重大傷病記錄檔
    Function updatePUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.updatePUBPatientSevereDisease_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBPatientSevereDisease_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    '由Icd_code查詢對應的診斷英文名
    Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet Implements IPubServiceL.queryPubDiseaseEnNameByIcdCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubDiseaseEnNameByIcdCode_L(strIcdCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#Region "     病歷號查詢(顯示是否) "
    ''' <summary>
    ''' 病歷號查詢(顯示是否)
    ''' </summary>
    ''' <returns>String) as DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-03</remarks>
    Public Function PUBPatientSevereDiseasequeryByPKYNShow(ByRef pk_Chart_No As String, ByRef pk_Icd_Code As String, ByRef pk_Effect_Date As Date) As DataSet Implements IPubServiceL.PUBPatientSevereDiseasequeryByPKYNShow

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPatientSevereDiseasequeryByPKYNShow(pk_Chart_No, pk_Icd_Code, pk_Effect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "20150914 PUBPatientHealthCardUI 全國醫療卡維護檔 Add by Will,Lin"

    Function queryPUBPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As DataSet Implements IPubServiceL.queryPUBPatientHealthCardByCond_L

        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientHealthCardByCond_L(strChartNo, strEffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPubPatientFlagByChartNo_L(ByVal strChartNo As String) As DataSet Implements IPubServiceL.queryPubPatientFlagByChartNo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubPatientFlagByChartNo_L(strChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '新增全國醫療服務卡維護檔
    Function insertPUBPatientHealthCard_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.insertPUBPatientHealthCard_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBPatientHealthCard_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function insertPUBHealthAndFlag_L(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer Implements IPubServiceL.insertPUBHealthAndFlag_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBHealthAndFlag_L(dsHealth, dsFlag, blFlag)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function updatePUBPatientHealthCard_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.updatePUBPatientHealthCard_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBPatientHealthCard_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function deletePUBPatientHealthCard_L(ByVal strChartNo As String, ByVal strEffectDate As String) As Integer Implements IPubServiceL.deletePUBPatientHealthCard_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBPatientHealthCard_L(strChartNo, strEffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBPhaServicesUI 藥事服務費基本檔 Add by Will,Lin"
    '依條件查詢輸入護理資訊檔資料
    Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceL.queryPUBPhaServicesByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPhaServicesByCond(strMainIdentityId, strDeptCode, strPhaServicesTypeId, strOrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    '新增輸入護理資訊檔資料
    Function insertPUBPhaServices(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBPhaServices
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBPhaServices(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除輸入護理資訊檔資料
    Function deletePUBPhaServicesByPK(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String) As Integer Implements IPubServiceL.deletePUBPhaServicesByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBPhaServicesByPK(strMainIdentityId, strDeptCode, strPhaServicesTypeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '更新輸入護理資訊檔資料
    Function updatePUBPhaServices(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBPhaServices
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBPhaServices(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBDisIdentityUI 優待身份基本檔維護 Add by Will,Lin"
    '查詢優待身份基本資料
    Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As DataSet Implements IPubServiceL.queryPUBDisIdentityByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDisIdentityByCond(DisIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    '新增優待身份基本檔資料
    Function insertPUBDisIdentity(ByVal ds As DataSet) As Integer Implements IPubServiceL.insertPUBDisIdentity
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBDisIdentity(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '刪除優待身份基本檔資料
    Function deletePUBDisIdentityByPK(ByRef DisIdentityCode As String) As Integer Implements IPubServiceL.deletePUBDisIdentityByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBDisIdentityByPK(DisIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    '修改優待身份基本檔資料
    Function updatePUBDisIdentity(ByVal ds As Data.DataSet) As Integer Implements IPubServiceL.updatePUBDisIdentity
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBDisIdentity(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBDisIdentitySetUI 優待身分折扣設定檔 add by Will,Lin"
    Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String) As System.Data.DataSet Implements IPubServiceL.queryPUBDisIdentitySetByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDisIdentitySetByCond(dateEffectDate, strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBDisIdentitySet
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBDisIdentitySet(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBAccountUI 費用項目對應檔 add by Will,Lin"
    Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet Implements IPubServiceL.queryPUBAccountByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBAccountByCond(strAccountId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBAccount(ByVal saveData As DataSet) As Integer Implements IPubServiceL.insertPUBAccount
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBAccount(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function updatePUBAccount(ByVal saveData As DataSet) As Integer Implements IPubServiceL.updatePUBAccount
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBAccount(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function deletePUBAccountByPK(ByVal strAccountId As String) As Integer Implements IPubServiceL.deletePUBAccountByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBAccountByPK(strAccountId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBExamineUI 診察費基本檔維護 add by Will,Lin"
    Function queryPUBExamineByCond_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                     ByVal strDeptCode As String, ByVal strSectionId As String, _
                                     ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                     ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceL.queryPUBExamineByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBExamineByCond_L(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId, strOrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBExamine_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBExamine_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBExamine_L(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function deletePUBExamineByPK_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                  ByVal strDeptCode As String, ByVal strSectionId As String, _
                                  ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String) As Integer Implements IPubServiceL.deletePUBExamineByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBExamineByPK_L(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function updatePUBExamine_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBExamine_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBExamine_L(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"
    Function queryPUBPartByAll() As DataSet Implements IPubServiceL.queryPUBPartByAll
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPartByAll()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBSubIdentityForCombo_L() As DataSet Implements IPubServiceL.queryPUBSubIdentityForCombo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSubIdentityForCombo_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceL.queryPUBPartDiscountByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPartDiscountByCond(dateEffectDate, strDisIdentityCode, strPartCode, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function confirmPUBPartDiscount(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBPartDiscount
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBPartDiscount(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150910 PUBPartUI 部分負擔基本檔 add by Will,Lin"
    Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String) As DataSet Implements IPubServiceL.queryPUBPartByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPartByCond(dateEffectDate, strPartCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function confirmPUBPart(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBPart
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBPart(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150909 PUBRegisterFeeUI 掛號費基本維護檔 add by Will,Lin"
    Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet Implements IPubServiceL.queryPUBRegisterFeeByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBRegisterFeeByCond(pk_Source_Id, strSubIdentityCode, strDeptCode, strMedicalTypeId, strOrderCode, strSectionId, strFirstReg)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.insertPUBRegisterFee
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBRegisterFee(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function updatePUBRegisterFee(ByVal ds As DataSet) As Integer Implements IPubServiceL.updatePUBRegisterFee
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBRegisterFee(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function deletePUBRegisterFeeByPK(ByVal pk_Source_Id As String, ByRef pk_Sub_Identity_Code As System.String, ByVal strFirstReg As String, ByRef pk_Dept_Code As System.String, ByRef pk_Section_Id As System.String, ByRef pk_Medical_Type_Id As System.String) As Integer Implements IPubServiceL.deletePUBRegisterFeeByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBRegisterFeeByPK(pk_Source_Id, pk_Sub_Identity_Code, strFirstReg, pk_Dept_Code, pk_Section_Id, pk_Medical_Type_Id)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150909 PUBPtDisabilityUI 病患殘障記錄檔 add by Will,Lin"
    Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet Implements IPubServiceL.queryPUBPtDisabilityByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPtDisabilityByCond_L(pk_Chart_No, pk_Patient_Disability_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBPtDisability_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.insertPUBPtDisability_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBPtDisability_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function updatePUBPtDisabilityByPK_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.updatePUBPtDisabilityByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBPtDisabilityByPK_L(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function deletePUBPtDisabilityByPK_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As Integer) As Integer Implements IPubServiceL.deletePUBPtDisabilityByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBPtDisabilityByPK_L(pk_Chart_No, pk_Patient_Disability_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBSysCodeByTypeIdForDisability_L(ByVal strTypeId As String) As DataSet Implements IPubServiceL.queryPUBSysCodeByTypeIdForDisability_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSysCodeByTypeIdForDisability_L(strTypeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBSysCodeByIcdCodingQuery_L() As DataSet Implements IPubServiceL.queryPUBSysCodeByIcdCodingQuery_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSysCodeByIcdCodingQuery_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150908 PUBPatientQuotaUI 病患合約機構累積檔 add by Will"
    Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceL.queryPUBPatientQuotaByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientQuotaByCond(dateEffectDate, strContractCode, strChartNo, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBPatientQuota
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBPatientQuota(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150904 PUBMajorcareUI 特定治療項目基本檔維護 add by Will,Lin"
    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet Implements IPubServiceL.queryPUBMajorcareByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBMajorcareByCond(strMajorcareCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBMajorcare(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBMajorcare
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBMajorcare(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Function updatePUBMajorcare(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBMajorcare
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBMajorcare(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function deletePUBMajorcareByPK(ByVal strMajorcareCode As String) As Integer Implements IPubServiceL.deletePUBMajorcareByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBMajorcareByPK(strMajorcareCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150904 PUBSubIdentityUI 身份二代碼基本檔 add by Will,Lin"
    Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet Implements IPubServiceL.queryPUBSubIdentityByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSubIdentityByCond(strSubIdentityCode, strMainIdentityId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function insertPUBSubIdentity(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBSubIdentity
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBSubIdentity(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Function updatePUBSubIdentity(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBSubIdentity
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBSubIdentity(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function deletePUBSubIdentityByPK(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As Integer Implements IPubServiceL.deletePUBSubIdentityByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBSubIdentityByPK(strSubIdentityCode, strMainIdentityId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150904 PUBSubIdentitySetUI 身份二代碼計價設定檔維護 add by Will,Lin"
    Public Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                          ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                          ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceL.queryPUBSubIdentitySetByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSubIdentitySetByCond(dateEffectDate, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function confirmPUBSubIdentitySet(ByVal dsSaveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBSubIdentitySet
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.confirmPUBSubIdentitySet(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150904 PUBContractUI 合約機構基本檔 add by Will,Lin"
    Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet Implements IPubServiceL.queryPUBContractByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractByCond(strContractCode, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function deletePUBContractByPK(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As Integer Implements IPubServiceL.deletePUBContractByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePUBContractByPK(strContractCode, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Function insertPUBContract(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.insertPUBContract
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.insertPUBContract(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function updatePUBContract(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceL.updatePUBContract
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.updatePUBContract(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20150903 PUBContractQuotaUI 合約機構記賬累積檔維護 add by Will,Lin"
    Function queryPUBContractQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceL.queryPUBContractQuotaByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractQuotaByCond(dateEffectDate, strContractCode, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function confirmContractQuota(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmContractQuota
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmContractQuota(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


#End Region

#Region "20150831 PUBContractPartSetUI 合約身份部份負擔記帳設定檔 add by Will,Lin"
    Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBContractPart
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBContractPart(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceL.queryPUBContractPartSetByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractPartSetByCond(dateEffectDate, strContractCode, strSubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


#End Region

#Region "20150831 PUBContractSetUI 合約身份記扣帳設定維護 add by Will,Lin"
    ''' <summary>
    ''' 根據生效日 合約機關代碼 醫令類型 院內費用項目 醫令項目代碼取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderTypeId"></param>
    ''' <param name="strAccountId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="isNullQuerySubIdentityCode">True:按空字串查詢  False：不作為必要查詢條件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean) As System.Data.DataSet Implements IPubServiceL.queryPUBContractSetByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractSetByCond(dateEffectDate, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, isNullQuerySubIdentityCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBSubIdentityByCV
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSubIdentityByCV(strColumnName, strColumnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBContractByColumnValue2_L(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBContractByColumnValue2_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractByColumnValue2_L(strColumnName, strColumnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBContractByColumnValue
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBContractByColumnValue(strColumnName, strColumnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function confirmContractSet(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmContractSet
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmContractSet(saveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150831 PUBAddPartUI 加收部分負擔維護檔 add by Will,Lin"
    '查詢加收部分負擔基本檔資料
    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String) As DataSet Implements IPubServiceL.queryPUBAddPartByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBAddPartByCond(dateEffectDate, strPartTypeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

    '確定加收部分負擔基本檔資料
    Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBAddPart
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBAddPart(dsSaveData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

#End Region

#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    Function queryConsuDept_L() As DataSet Implements IPubServiceL.queryConsuDept_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryConsuDept_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region


#Region "20090724 取得登錄人員信息   by Add Ming"
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet Implements IPubServiceL.queryPUBEmployeeByCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBEmployeeByCode(EmployeeCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region

#Region "20090703 PUBSysCodeBO 共用代碼檔維護 by Add Syscom Yunfei"

    ' 獲取PUBSysCodeBO資料
    Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBSysCodeByCV
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSysCodeByCV(strColumnName, strColumnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet Implements IPubServiceL.queryPUBSheetByCV
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSheetByCV(strLoginID)
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function

    Function queryPUBSheetByCode_L(ByVal strLoginID As String) As DataSet Implements IPubServiceL.queryPUBSheetByCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSheetByCode_L(strLoginID)
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function
#End Region

#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    Function queryPUBDeptCodeNameCA3() As DataSet Implements IPubServiceL.queryPUBDeptCodeNameCA3
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDeptCodeNameCA3()
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function
#End Region
#Region "20090708 PUBDepartmentBO_E1 取得科系資料來源 by Add Syscom Johsn"

    Function queryPUBDepartmentCode() As DataSet Implements IPubServiceL.queryPUBDepartmentCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDepartmentCode()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region

#Region "20100527 add by Merry 費用項目對應檔維護- 依傳入TypeID取得代碼檔資料"
    Function queryPUBSysCode_L(ByVal TypeID As String) As DataSet Implements IPubServiceL.queryPUBSysCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSysCode_L(TypeID)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20091012 查詢  轉診回覆  by Add ChenYang"

    Function queryPubPatientByPK_L(ByRef pk_Chart_No As System.String) As DataSet Implements IPubServiceL.queryPubPatientByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubPatientByPK_L(pk_Chart_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As DataSet Implements IPubServiceL.queryPubHospitalByKey_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubHospitalByKey_L(LanguageTypeId, EffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20090317 add by Alan 掛號 - 取得所有細分科 "

    'Public Function queryPUBDepartmentAll_B() As DataSet
    '    Try
    '        Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
    '        Return k1.queryPUBDepartmentAll_B()
    '    Catch ex As Exception
    '        log.Error(ex.Message)
    '        Throw ex
    '    End Try
    'End Function

    Public Function queryPUBDepartmentAll_D(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return k1.queryPUBDepartmentAll_D(conn)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    'Public Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As System.Data.DataSet
    '    Try
    '        Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
    '        Return k1.queryPUBDepartmentAll_D2(SourceType)
    '    Catch ex As Exception
    '        log.Error(ex.Message)
    '        Throw ex
    '    End Try

    'End Function

#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    Function queryprisendInfo_L() As DataSet Implements IPubServiceL.queryprisendInfo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryprisendInfo_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "20100112 排成醫令維護   by Add coco"
    Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String) As DataSet Implements IPubServiceL.queryPUBSheetDetailByCond1
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSheetDetailByCond1(strSheetCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "
    Function queryPUBPostalCodeForCountryName_L() As DataSet Implements IPubServiceL.queryPUBPostalCodeForCountryName_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPostalCodeForCountryName_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet Implements IPubServiceL.queryPUBPostalCodeForTownName_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPostalCodeForTownName_L(strCountryName)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet Implements IPubServiceL.queryPUBPatientForOMODiagnosisCertificate_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientForOMODiagnosisCertificate_L(strChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet Implements IPubServiceL.queryPUBDoctorLicenseByEmployeeCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDoctorLicenseByEmployeeCode_L(EmployeeCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    Public Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet Implements IPubServiceL.queryPUBPatientBychartNo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientBychartNo_L(chartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String Implements IPubServiceL.queryDefault_Body_Site_Code
        Try
            Return PUBDelegate.getInstance.queryDefault_Body_Site_Code(strOrder_Code, strFavor_Type_Id)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As DataSet Implements IPubServiceL.queryPUBOrderMappingSpecimenByOrderCode
        Try
            Return PUBDelegate.getInstance.queryPUBOrderMappingSpecimenByOrderCode(strOrder_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBSysCodeNot0
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSysCodeNot0(strColumnName, strColumnValue)
        Catch ex As Exception
            Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Function
#End Region

#Region "20090824 PUBBodySiteBO 查詢有效部位檔資料  by windfog"
    ''' <summary>
    ''' 查詢有效部位檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBBodySiteUnDelete() As DataSet Implements IPubServiceL.queryPUBBodySiteUnDelete
        Try
            Return PUBDelegate.getInstance.queryPUBBodySiteUnDelete()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20100303 獲得所屬部門下的所有部門   by Add ming"
    Public Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet Implements IPubServiceL.queryPUBDepartmentByCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDepartmentByCode_L(code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20090724 所屬單位查詢醫師信息   by Add Ming"
    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As DataSet Implements IPubServiceL.queryPUBDoctorByDeptCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDoctorByDeptCode(DeptCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet Implements IPubServiceL.queryPUBDoctorByDoctorCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDoctorByDoctorCode(DoctorCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20100622  常用維護科別資料來源 add by coco"
    Function queryRefferalDeptOMO_L() As DataSet Implements IPubServiceL.queryRefferalDeptOMO_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryRefferalDeptOMO_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20100526 PUBDepartmentBO_E2  次專科基本檔所屬科別combobox資料  add by liuye"
    Function queryPUBDepartmentEffectByColumnValue_L(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet Implements IPubServiceL.queryPUBDepartmentEffectByColumnValue_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDepartmentEffectByColumnValue_L(strColumnName, strColumnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "     與RuleTransfer_N1關聯的切出部分 "
    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-5-24</remarks>
    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer Implements IPubServiceL.QuerymessageDataSet_L

        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QuerymessageDataSet_L(dsQueryCond, OperationDS, totalRuleResult, messageDataSet)

        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try

    End Function

#End Region

#Region "20100427 查詢 PUBConfigBO_E2 ,add by Mark"

    ''' <summary>
    ''' 查詢 PUBConfigBO_E2
    ''' </summary>
    ''' <param name="pk_Config_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBConfigByPK_L(ByVal pk_Config_Name As String) As System.Data.DataSet Implements IPubServiceL.queryPUBConfigByPK_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBConfigByPK_L(pk_Config_Name)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20091012 PUPHospitalBO_E2 根據傳入時間查詢 by Add Tor"
    Public Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As DataSet Implements IPubServiceL.queryPUBHospitalBOByReferralOutDate_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBHospitalBOByReferralOutDate_L(strReferralOutDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20091030 取得外國國籍名稱 , Add by tony"
    Function queryNationalName_L() As DataSet Implements IPubServiceL.queryNationalName_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryNationalName_L
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20091030 取得居住地區欄位 , Add by tony"
    Function queryAreaCode_L() As DataSet Implements IPubServiceL.queryAreaCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryAreaCode_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20091103 取得肺結核資料 , Add by tony"
    Function queryTuberculosis_L() As DataSet Implements IPubServiceL.queryTuberculosis_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryTuberculosis_L()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20090818 PUBSyscodeBO 公用代碼檔維護  by mark"
    Function queryPUBSyscodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet Implements IPubServiceL.queryPUBSyscodeByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSyscodeByCond(iTypeId, strCodeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region ""
    Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet Implements IPubServiceL.queryPUBBodySiteNotMainSiteData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBBodySiteNotMainSiteData(MainBodySiteCode, conn)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "'檢驗檢查 檢體欄位顯示 根據某一個OrderCode 設定檢體ComboBox資料 add by prince"
    Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet Implements IPubServiceL.queryOrderMappingSpecimenByCond4
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryOrderMappingSpecimenByCond4(OrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150918 PUBPatientDisabilityUI 病患殘障紀錄檔   by Will,Lin"

    Function queryPUBPatientDisabilityByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet Implements IPubServiceL.queryPUBPatientDisabilityByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBPatientDisabilityByCond_L(strChartNo, strEffectDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function confirmPUBPatientDisability_L(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer Implements IPubServiceL.confirmPUBPatientDisability_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.confirmPUBPatientDisability_L(strChartNo, strEffectDate, ds, blflag)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
    Function queryMaxPatientDisabilityNo_L(ByVal strChartNo As String) As DataSet Implements IPubServiceL.queryMaxPatientDisabilityNo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryMaxPatientDisabilityNo_L(strChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20150915 PUBPatientBO_E2 根據病歷號查詢 ,add by Remote"
    ''' <summary>
    ''' 國際疫苗申請書輸入依條件查詢
    ''' </summary>
    ''' <param name="strChart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet Implements IPubServiceL.queryPUBPatientAndBasicData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientAndBasicData(strChart_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region


#Region "2015/10/20 檢核規則維護 成醫舊程式搬移 by HE,Alien"

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 查詢 "
    Public Function queryByPkRuleCode(ByVal pk_Rule_Code As System.String) As DataSet Implements IPubServiceL.queryByPkRuleCode
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryByPkRuleCode(pk_Rule_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 刪除 "

    Public Function deleteByPkRuleCode(ByVal pk_Rule_Code As System.String) As Integer Implements IPubServiceL.deleteByPkRuleCode
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.deleteByPkRuleCode(pk_Rule_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

    Public Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer Implements IPubServiceL.confirmRuleData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.confirmRuleData(confirmType, RuleDS)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function deleteRuleData(ByVal ruleCode As String) As Boolean Implements IPubServiceL.deleteRuleData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.deleteRuleData(ruleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function getRuleSerialNo() As String Implements IPubServiceL.getRuleSerialNo
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getRuleSerialNo()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function initPUBRuleCheckUIInfo() As DataSet Implements IPubServiceL.initPUBRuleCheckUIInfo
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.initPUBRuleCheckUIInfo()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function initPUBRuleQueryInfo() As DataSet Implements IPubServiceL.initPUBRuleQueryInfo
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.initPUBRuleQueryInfo()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet Implements IPubServiceL.queryRuleDataByRuleParam
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleDataByRuleParam(RuleParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    '記錄使用者更新或刪除檢核規則
    Public Function InsertPUB_Rule_Transaction_Log(ByVal ds As DataSet) As Integer Implements IPubServiceL.InsertPUB_Rule_Transaction_Log
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.InsertPUB_Rule_Transaction_Log(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet Implements IPubServiceL.queryRuleByCondition
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleByCondition(itemParam, detailParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable Implements IPubServiceL.queryRuleDoctorByEmployeeCodes
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleDoctorByEmployeeCodes(employeeCodes)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet Implements IPubServiceL.queryRuleGroup
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleGroup(itemParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function querySelectedRuleData(ByVal selectRuleCode As String) As DataSet Implements IPubServiceL.querySelectedRuleData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.querySelectedRuleData(selectRuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 改名稱
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getExprre(ByVal ds As String) As String Implements IPubServiceL.getExprre
        Try
            Return PUBDelegate.getInstance.getExprre(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2015/10/26 檢核規則維護 成醫舊程式搬移 by HE,Alien"
    Public Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer Implements IPubServiceL.confirmTreeRuleData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.confirmTreeRuleData(confirmType, RuleDS)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function getRuleMaintainSerialNo() As Integer Implements IPubServiceL.getRuleMaintainSerialNo
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getRuleMaintainSerialNo
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Public Function initPUBRuleTreeQueryInfo() As DataSet Implements IPubServiceL.initPUBRuleTreeQueryInfo
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.initPUBRuleTreeQueryInfo
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function querySelectedTreeRuleData(ByVal selectRuleCode As String) As DataSet Implements IPubServiceL.querySelectedTreeRuleData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.querySelectedTreeRuleData(selectRuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet Implements IPubServiceL.queryTreeRuleByCondition
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryTreeRuleByCondition(itemParam, detailParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


#End Region
#Region "20100809 病歷量審查作業"

    Function queryPUBDoctorByDoctorCode2_L(ByVal DoctorCode As String) As DataSet Implements IPubServiceL.queryPUBDoctorByDoctorCode2_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBDoctorByDoctorCode2_L(DoctorCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20120326 取得病患資料及戶籍地 , Add by Runxia"
    ''' <summary>
    ''' 取得病患資料及戶籍地
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>by Runxia on 2012-3-26</remarks>
    Public Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet Implements IPubServiceL.queryPUBPatientAndArea
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBPatientAndArea(strChartNo)

        Catch ex As Exception

            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20090724 員工編號查詢醫師信息   by Add Ming"
    Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As DataSet Implements IPubServiceL.queryPUBDoctorByEmployeeCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDoctorByEmployeeCode(EmployeeCode)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2012/04/02 科室/團隊查詢(PUBDepartmentBO_E2) by liuye"

#Region "     科室/團隊查詢 "
    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    Public Function queryPUBDepartmentCodeIsIpdDeptY_L() As DataSet Implements IPubServiceL.queryPUBDepartmentCodeIsIpdDeptY_L

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBDepartmentCodeIsIpdDeptY_L()

        Catch ex As Exception

            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/04/22 add by Kaiwen 醫令項目代碼對應健保碼 "

    Function queryPubOrderByOrderCode2_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceL.queryPubOrderByOrderCode2_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubOrderByOrderCode2_L(strOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function queryPubNhiCode_L(ByVal strInsuCode As String) As DataSet Implements IPubServiceL.queryPubNhiCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubNhiCode_L(strInsuCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function queryPubInsuCode_L(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataSet Implements IPubServiceL.queryPubInsuCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubInsuCode_L(strEffectDate, strOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function deletePubInsuCode_L(ByVal ds As DataSet) As Integer Implements IPubServiceL.deletePubInsuCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.deletePubInsuCode_L(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function queryPubInsuCodeBySeqNo_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceL.queryPubInsuCodeBySeqNo_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubInsuCodeBySeqNo_L(strOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function confirmPUBInsuCode_L(ByVal saveData As DataSet) As DataSet Implements IPubServiceL.confirmPUBInsuCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.confirmPUBInsuCode_L(saveData)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Function queryPubInsuCodeByOrderCode_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceL.queryPubInsuCodeByOrderCode_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPubInsuCodeByOrderCode_L(strOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/04/22 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Kaiwen"

    ''' <summary>
    ''' 醫令項目代碼對應健保碼修改
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen Yang on 2012-5-14</remarks>
    Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.updatePUBInsuCodeByPK_L

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.updatePUBInsuCodeByPK_L(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try

    End Function

#End Region

#Region "20160507 PUBSysCodeBO 檢驗組別,IO類別(PUBSysCodeBO_E2) Add by Remote"

    Function querySpicemenType() As DataSet Implements IPubServiceL.querySpicemenType
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.querySpicemenType()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20160518 PUBPreventiveCare 預防保健基本檔設定維護 ,add by Remote"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Function PUBPreventiveCareInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPreventiveCareInsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPreventiveCareInsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try

    End Function

#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Function PUBPreventiveCareUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPreventiveCareUpdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPreventiveCareUpdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Function PubPreventiveCareDeleteByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As Integer Implements IPubServiceL.PubPreventiveCareDeleteByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPreventiveCareDeleteByPK(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Function PUBPreventiveCareQueryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As System.Data.DataSet Implements IPubServiceL.PUBPreventiveCareQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPreventiveCareQueryByPK(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareQueryAll() As System.Data.DataSet Implements IPubServiceL.PUBPreventiveCareQueryAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPreventiveCareQueryAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function PUBPreventiveCareQueryByLikePK(ByRef pk_Care_Item_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBPreventiveCareQueryByLikePK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPreventiveCareQueryByLikePK(pk_Care_Item_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "  取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Function queryPUBCareItemAgeSex() As DataSet Implements IPubServiceL.queryPUBCareItemAgeSex
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBCareItemAgeSex()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region



#End Region

#Region "2016/05/11 MDC15主次要診斷碼維護作業(DRG_MDC15_Diagnosis) by Xiaozhi,Yu"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    Public Function PUBInsuDeptdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBInsuDeptdeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBInsuDeptdeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-11</remarks>
    Public Function PUBInsuDeptQueryByPKROC(ByRef Insu_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBInsuDeptQueryByPKROC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBInsuDeptQueryByPKROC(Insu_Dept_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢全部(民國年) "
    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-07</remarks>
    Public Function queryAllROC() As System.Data.DataSet Implements IPubServiceL.queryAllROC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryAllROC()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Elly on 2016-05-07</remarks>
    Public Function PUBInsuDeptInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBInsuDeptInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBInsuDeptInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Elly on 2016-05-07</remarks>
    Public Function PUBInsuDeptUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBInsuDeptUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBInsuDeptUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016-05-19 PUBSubIdentityBO_E2 身份二查詢  Add by Xiaozhi"
    Function queryPUBSubMedicalType() As DataSet Implements IPubServiceL.queryPUBSubMedicalType
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSubMedicalType()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/05/24 五都戶籍地設定維護(PUBAreaCodeNSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBAreaCodeNdeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeNdeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBAreaCodeNQueryByPKROC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeNQueryByPKROC(Area_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     查詢全部(民國年) "
    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function queryAreaCodeAll() As System.Data.DataSet Implements IPubServiceL.queryAreaCodeAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryAreaCodeAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBAreaCodeNInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeNInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBAreaCodeNUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeNUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/05/25 行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBAreaCodeGovdeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeGovdeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBAreaCodeGovQueryByPKROC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeGovQueryByPKROC(Area_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     查詢全部(民國年) "
    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryAreaCodeGovAll() As System.Data.DataSet Implements IPubServiceL.queryAreaCodeGovAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryAreaCodeGovAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBAreaCodeGovInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeGovInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBAreaCodeGovUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAreaCodeGovUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/05/26 郵遞區號對應戶籍地設定維護(PUBPostalAreaSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalAreadeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBPostalAreadeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalAreadeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBPostalAreaQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalAreaQueryByPK(Postal_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以所有PK查詢資料"
    ''' <summary>
    ''' 以所有PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalAreaQueryByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBPostalAreaQueryByPKAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalAreaQueryByPKAll(Postal_Code, Area_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢全部() "
    ''' <summary>
    ''' 查詢全部()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryPostalAreaAll() As System.Data.DataSet Implements IPubServiceL.queryPostalAreaAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPostalAreaAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPostalAreaInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalAreaInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPostalAreaUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalAreaUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/05/27 郵遞區號對應行政區設定維護(PUBPostalGovAreaSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalGovAreadeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBPostalGovAreadeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalGovAreadeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalGovAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBPostalGovAreaQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalGovAreaQueryByPK(Postal_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢全部() "
    ''' <summary>
    ''' 查詢全部()
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryPostalGovAreaAll() As System.Data.DataSet Implements IPubServiceL.queryPostalGovAreaAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPostalGovAreaAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalGovAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPostalGovAreaInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalGovAreaInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBPostalGovAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBPostalGovAreaUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPostalGovAreaUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "20160601  資料來源Type_Id = '128'(PUBSysCodeBO_E2) Add by Remote"

    Function queryPUBSysCodeSourceId() As DataSet Implements IPubServiceL.queryPUBSysCodeSourceId
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSysCodeSourceId()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20160606 查詢病歷關系"
    Function queryPUBPatientContactByCond_L(ByVal strChartNo As String) As DataSet Implements IPubServiceL.queryPUBPatientContactByCond_L
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBPatientContactByCond_L(strChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
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
    Public Function PUBDiseaseICD10MappinginsertData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBDiseaseICD10MappinginsertData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappinginsertData(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     修改 Method "
    ''' <summary>
    ''' 修改 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingupdateData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBDiseaseICD10MappingupdateData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingupdateData(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingdeleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As Integer Implements IPubServiceL.PUBDiseaseICD10MappingdeleteData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingdeleteData(pk_Disease_Type_Id, pk_ICD_Code, pk_ICD10_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBDiseaseICD10MappingqueryGridData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingqueryGridData(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     取得Gird資料ByPk "
    ''' <summary>
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBDiseaseICD10MappingqueryGridDataByPk

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingqueryGridDataByPk(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingquertCmbData() As DataSet Implements IPubServiceL.PUBDiseaseICD10MappingquertCmbData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingquertCmbData()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer Implements IPubServiceL.PUBDiseaseICD10MappingfCheckIcdCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDiseaseICD10MappingfCheckIcdCode(strICD, strTBName)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "20160620 由來源,病歷號,就診日期 取得就醫序號 by remote_liu "

    Function queryMedicalSn(ByVal inParam() As String) As DataSet Implements IPubServiceL.queryMedicalSn
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryMedicalSn(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20160620 由來源,病歷號,就診日期 取得媽媽姓名 by remote_liu "

    Function queryMotherName(ByVal inParam() As String) As DataSet Implements IPubServiceL.queryMotherName
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryMotherName(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20160620 護理站 by remote_liu "

    Function queryStationNo() As DataSet Implements IPubServiceL.queryStationNo
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryStationNo()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/06/29 ICD10科別對照檔(PUB_ICD10_Dept) by Li,Han"

#Region "     新增 Method "
    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptinsertData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBICD10DeptinsertData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptinsertData(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptdeleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String) As Integer Implements IPubServiceL.PUBICD10DeptdeleteData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptdeleteData(pk_Kind_Code, pk_Disease_Type_Id, pk_ICD10_Code, pk_Insu_Dept_Code, pk_Insu_Sub_Dept_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBICD10DeptqueryGridData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptqueryGridData(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得Gird資料ByPK "
    ''' <summary>
    ''' 取得Gird資料ByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBICD10DeptqueryGridDataByPk

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptqueryGridDataByPk(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryCmbData(ByRef strTBName As String, ByRef strWhere As String) As DataSet Implements IPubServiceL.PUBICD10DeptqueryCmbData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptqueryCmbData(strTBName, strWhere)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer Implements IPubServiceL.PUBICD10DeptfCheckIcdCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBICD10DeptfCheckIcdCode(strICD, strTBName)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "  2016/06/28 取得手術法(PUBOrderBO_E2) by Remote    "

    Function PUBOrderOrderName(ByVal inParam() As String) As DataSet Implements IPubServiceL.PUBOrderOrderName
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBOrderOrderName(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "  2016/06/28 取得費用(PUBOrderPriceBO_E2) by Remote    "

    Function PUBOrderPrice(ByVal inParam() As String) As DataSet Implements IPubServiceL.PUBOrderPrice
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBOrderPrice(inParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "     2016/06/29 傷口分類(PUBSysCodeBO_E2) by Remote "

    Function PUBSyscodeWoundType() As DataSet Implements IPubServiceL.PUBSyscodeWoundType
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBSyscodeWoundType()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "     2016/06/29 部位(PUBBodySiteBO_E2) by Remote  "

    Function PUBBodySiteBodyparts() As DataSet Implements IPubServiceL.PUBBodySiteBodyparts
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBBodySiteBodyparts()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "    2016/06/98 側位 by Remote(PUBSysCodeBO_E2)  "

    Function PUBSyscodeBodySide() As DataSet Implements IPubServiceL.PUBSyscodeBodySide
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBSyscodeBodySide()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "     2016/07/05 急作手術分級(PUBSysCodeBO_E2) by Remote "

    Function PUBSyscodeUrgentClass() As DataSet Implements IPubServiceL.PUBSyscodeUrgentClass
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.PUBSyscodeUrgentClass()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20160813 PUBSheetBO 檢驗單資料for ComboBox by Add Remote"

    Function queryPUBSheetCode() As DataSet Implements IPubServiceL.queryPUBSheetCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryPUBSheetCode()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region
#Region "2016/09/09 add by qun 依據健保碼內容查詢主手術碼設定下拉選單"
    Public Function queryICD10PCS_Code(ByVal strInsuCode As System.String) As DataSet Implements IPubServiceL.queryICD10PCS_Code
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.queryICD10PCS_Code(strInsuCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/09/23 新增非藥品替代醫令檔(PUBOrderAlternativeUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBOrderAlternativeInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBOrderAlternativeInsertByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderAlternativeInsertByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBOrderAlternativeUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceL.PUBOrderAlternativeUpdateByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderAlternativeUpdateByPK(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBOrderAlternativedeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.PUBOrderAlternativedeleteChoose

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderAlternativedeleteChoose(dsDelete)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢資料"
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBOrderAlternativequeryByPKOrderCode(ByRef Order_Code As System.String) As System.Data.DataSet Implements IPubServiceL.PUBOrderAlternativequeryByPKOrderCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderAlternativequeryByPKOrderCode(Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "20090820 PUBOrderStandingBO 常備醫令檔 Add by william"
    '查詢
    Function queryPUBOrderStandingByCond(ByVal strDept_Code As String, ByVal strOrder_Code As String) As DataSet Implements IPubServiceL.queryPUBOrderStandingByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBOrderStandingByCond(strDept_Code, strOrder_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '新增
    Function insertPUBOrderStanding(ByVal saveData As DataSet) As Integer Implements IPubServiceL.insertPUBOrderStanding
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPUBOrderStanding(saveData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '刪除
    Function deletePUBOrderStandingByPK(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As System.String, ByVal iWeek As System.Int32, ByVal strConsumption_Dept As System.String) As Integer Implements IPubServiceL.deletePUBOrderStandingByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.deletePUBOrderStandingByPK(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek, strConsumption_Dept)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '更新
    Function updatePUBOrderStanding(ByVal saveData As DataSet) As Integer Implements IPubServiceL.updatePUBOrderStanding
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.updatePUBOrderStanding(saveData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean Implements IPubServiceL.queryPUBOrderStandingTimeIsExist
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBOrderStandingTimeIsExist(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '查詢科別/護理站的下拉式選單內容
    Public Function queryPUBOrderStandingByDept() As DataSet Implements IPubServiceL.queryPUBOrderStandingByDept
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBOrderStandingByDept()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2017/1/16 非藥品替代醫令檔維護 add by Michelle"
    '新增
    Function insertPUBOrder(ByVal dsData As DataSet) As Integer Implements IPubServiceL.insertPUBOrder
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPUBOrder(dsData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '刪除
    Function DeletePUBOrder(ByVal dsDelete As DataSet) As Integer Implements IPubServiceL.DeletePUBOrder
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.DeletePUBOrder(dsDelete)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '修改
    Function updatePUBOrder(ByVal dsData As DataSet) As Integer Implements IPubServiceL.updatePUBOrder
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.updatePUBOrder(dsData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

End Class
