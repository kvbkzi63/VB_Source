Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.PUB

Public Class PubService
    Implements IPubService

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"
    Public Function queryPUBDisIdentityAll() As DataSet Implements IPubService.queryPUBDisIdentityAll
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDisIdentityAll()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "20150903 PUBContractUI 合約機構基本檔 add by Will,Lin"
    Public Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet Implements IPubService.queryPUBSubIdentityAll
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSubIdentityAll(inSourceType)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "20150812 【ExportList】 add by Will,Lin"
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function PubExportQueryData(ByVal sql As String, ByVal getConnection As String) As DataSet Implements IPubService.PubExportQueryData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PubExportQueryData(sql, getConnection)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 初始化資訊
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function PubExportListDataQuery(ByVal Report_id As String) As DataSet Implements IPubService.PubExportListDataQuery
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PubExportListDataQuery(Report_id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "20150810 【共用查詢平台】相關method add by Will,Lin"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportInsertData(ByVal ds As DataSet) As Integer Implements IPubService.PUBExportInsertData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportSetInsertData(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportDeleteDataByPk(ByVal Report_Id As String) As Integer Implements IPubService.PUBExportDeleteData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportSetDeleteData(Report_Id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportUpdateData(ByVal Report_Id As String, ByVal ds As DataSet) As Integer Implements IPubService.PUBExportUpdateData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportSetUpdateData(Report_Id, ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 查詢主表單資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportMasterDataQuery(ByVal Report_id As String) As DataSet Implements IPubService.PUBExportMasterDataQuery
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportSetQueryExportData(Report_id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 查詢表身資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportDetailDataQuery(ByVal Report_id As String) As DataSet Implements IPubService.PUBExportDetailDataQuery
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportSetQueryExportDetailData(Report_id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 新增後查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Function PUBExportQueryForInsert(ByVal Report_id As String) As DataSet Implements IPubService.PUBExportQueryForInsert
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBExportQueryForInsert(Report_id)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "20090606 add by Alan 取得印表機名稱與列印紙張大小"

    Function PUBPrintConfigQueryByPK(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As DataSet Implements IPubService.PUBPrintConfigQueryByPK
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.PUBPrintConfigQueryByPK(pk_Report_Id, pk_Print_Type, pk_Print_Cond)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "20090618 取得系統時間  , add by James"
    Function GetSystemNowTime() As Date Implements IPubService.GetSystemNowTime
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.GetSystemNowTime()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "20090720 PUBConfig , Added by James"

    Public Function queryPubConfigWhereConfigNameEquals(ByVal ConfigName As String) As System.Data.DataSet Implements IPubService.queryPubConfigWhereConfigNameEquals
        Try
            Dim _myDelegate As PUBDelegate = PUBDelegate.getInstance
            Return _myDelegate.queryPubConfigWhereConfigNameEquals(ConfigName)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "2013/09/25 醫師檔相關作業(PUBDOCTORBO_E1) by Sean.Lin"

#Region "     查詢醫師檔作為CBO 資料 "

    ''' <summary>
    ''' 查詢醫師檔作為CBO 資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function PUBDOCTORBOE1queryForCbo(ByVal SectionCode As String) As DataSet Implements IPubService.PUBDOCTORBOE1queryForCbo

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBDOCTORBOE1queryForCbo(SectionCode)

        Catch cmex As CommonException

            Throw ServerExceptionHandler.ProccessException(cmex)

        Catch ex As Exception

            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))

        End Try

    End Function

#End Region

    ''' <summary>
    ''' 進行醫師驗證
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryDoctorFromEmployee(ByVal Employee_Code As String, ByVal Doctor_Code As String) As DataSet Implements IPubService.queryDoctorFromEmployee
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.queryDoctorFromEmployee(Employee_Code, Doctor_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "系統版本更新記錄檔"

    Public Function DynamicQueryByColumn(ByRef queryData As DataSet) As System.Data.DataSet Implements IPubService.DynamicQueryByColumn
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.DynamicQueryByColumn(queryData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function insertPUBSystermVersion(ByVal queryData As System.Data.DataSet) As Integer Implements IPubService.insertPUBSystermVersion

        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPUBSystermVersion(queryData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "20090820 add by Rich, PUBPartBO_E1"

    Public Function queryPubPartByKey(ByVal regDate As String) As System.Data.DataSet Implements IPubService.queryPubPartByKey
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPartByKey(regDate)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function
#End Region

#Region "2013-03-21 add by 嚴崑銘"
    ''' <summary>
    ''' 取得 Pub_Config 設定值
    ''' </summary>
    ''' <param name="configName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPubConfigValue(ByVal configName As String) As String Implements IPubService.GetPubConfigValue
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.GetPubConfigValue(configName)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得 Pub_Config 設定值是否代表已生效
    ''' </summary>
    ''' <param name="configName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPubConfigActive(ByVal configName As String) As Boolean Implements IPubService.IsPubConfigActive
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.IsPubConfigActive(configName)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 檢查身分證號
    ''' </summary>
    ''' <param name="strIdNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckIdNo(ByVal strIdNo As String) As Integer Implements IPubService.CheckIdNo
        Try
            Dim strTemp = ""
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.CheckIdNo(strIdNo, strTemp)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region

#Region "20090820 add by James, PUBSysCodeBO_E1"

    Public Function queryPUBSyscodePKey(ByVal inTypeId As String, ByVal inCodeId As String) As System.Data.DataSet Implements IPubService.queryPUBSyscodePKey
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBSyscodePKey(inTypeId, inCodeId)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try
    End Function

    Public Function queryPUBSysCodebyTypeId(ByVal TypeId As String) As System.Data.DataSet Implements IPubService.queryPUBSysCodebyTypeId
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBSysCodebyTypeId(TypeId)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try
    End Function

#End Region

#Region "20090820 add by James, 員工資料相關查詢(PUBEmployee)"

    Public Function queryEmployeeByDate(ByVal EmployeeCode As String, ByVal JudgeDate As String) As DataSet Implements IPubService.queryEmployeeByDate
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryEmployeeByDate(EmployeeCode, JudgeDate)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    Public Function DoPubAction(ByVal ds As DataSet) As DataSet Implements IPubService.DoPubAction
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.DoPubAction(ds)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


#End Region

#Region "20090820 add by Rich, PubPatientBO_E1"

    Public Function queryPubPatientByIdno(ByVal Idno As String) As System.Data.DataSet Implements IPubService.queryPubPatientByIdno
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPatientByIdno(Idno)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-09</remarks>
    Public Function queryPubPatientByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubService.queryPubPatientByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPatientByPK(pk_Chart_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "20090820 add by James, PUBPatientSevereDiseaseBO_E1"

    Public Function queryPubPatientSevereDiseaseByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubService.queryPubPatientSevereDiseaseByKey
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPatientSevereDiseaseByKey(Chart_No)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function
#End Region

#Region "20090820 add by James, PUBPatientDisabilityBO_E1"

    Public Function queryPubPatientDisabilityByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubService.queryPubPatientDisabilityByKey
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPatientDisabilityByKey(Chart_No)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function
#End Region

#Region "20090820 add by James, PUBPatientFlagBO_E1"

    Public Function queryPubPatientFlagByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubService.queryPubPatientFlagByKey
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubPatientFlagByKey(Chart_No)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region

#Region "20090820 add by Rich, PUBConfigBO_E1"

    Public Function queryAllPUBConfig() As System.Data.DataSet Implements IPubService.queryAllPUBConfig
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryAllPUBConfig
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function updatePUBConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.updatePUBConfig
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.updatePUBConfig(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function queryPUBConfigWhereConfigNameIn(ByVal configName As String) As DataSet Implements IPubService.queryPUBConfigWhereConfigNameIn
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBConfigWhereConfigNameIn(configName)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "2012/04/06 add by Alan 取得Term_Code設定資料"
    Public Function queryStationByTermCode(ByVal inTermCode As String) As DataSet Implements IPubService.queryStationByTermCode
        Try
            Dim _ip As PUBDelegate = PUBDelegate.getInstance
            Return _ip.queryStationByTermCode(inTermCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "20100226 動態查詢 by Jen"

    Public Function dynamicQuery(ByVal sqlStr As String) As DataSet Implements IPubService.dynamicQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.dynamicQuery(sqlStr) 'Return Nothing
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region " 負責寫前端程式 log 紀錄"

    Public Sub doClientLog(ByVal level As LOGDelegate.LogLevel, ByVal callerType As String, ByVal methodName As String, ByVal message As String) Implements IPubService.doClientLog
        Try
            LOGDelegate.getInstance.dbClientErrorMsg(level, callerType, methodName, message)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD001", ex))
        End Try
    End Sub

#End Region

#Region "2014/09/01 員工資料相關查詢(PUBEmployee) by Sean.Lin"

#Region "     根據員工編號取得員工資料 "
    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCode(ByVal EmployeeCode As String) As DataSet Implements IPubService.PUBEmployeequeryEmployeeByEmpCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBEmployeequeryEmployeeByEmpCode(EmployeeCode)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region


#Region "     根據員工編號和日期取得有效期限的員工資料 "
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCodeAndDate(ByVal EmployeeCode As String, ByVal JudgeDate As Date) As DataSet Implements IPubService.PUBEmployeequeryEmployeeByEmpCodeAndDate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBEmployeequeryEmployeeByEmpCodeAndDate(EmployeeCode, JudgeDate)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region


#End Region

#Region "2014/11/04 參數設定(PubConfig) by Sean.Lin"

#Region "     查詢By參數設定名稱 "
    ''' <summary>
    ''' 查詢By參數設定名稱
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigQueryByConfigName(ByVal configName As String) As DataSet Implements IPubService.PubConfigQueryByConfigName

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigQueryByConfigName(configName)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryByPK(ByRef pk_Config_Name As System.String) As DataSet Implements IPubService.PubConfigqueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigqueryByPK(pk_Config_Name)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdelete(ByRef pk_Config_Name As System.String) As Integer Implements IPubService.PubConfigdelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigdelete(pk_Config_Name)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfiginsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubConfiginsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfiginsert(ds)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubConfigupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigupdate(ds)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryAll() As System.Data.DataSet Implements IPubService.PubConfigqueryAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigqueryAll()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region


#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements IPubService.PubConfigdynamicQueryWithColumnValue

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubConfigdynamicQueryWithColumnValue(columnName, columnValue)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

#End Region

    ''' <summary>
    ''' 根據系統參數名稱查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function queryPUBConfigLikePKey(ByVal inConfigName As String) As DataSet Implements IPubService.queryPUBConfigLikePKey

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBConfigLikePKey(inConfigName)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function qureyPUBConfigAll() As DataSet Implements IPubService.qureyPUBConfigAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.qureyPUBConfigAll()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function savePUBConfig(ByVal inSaveDs As DataSet) As DataSet Implements IPubService.savePUBConfig

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.savePUBConfig(inSaveDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function deletePUBConfig(ByVal inDeleteDs As DataSet) As DataSet Implements IPubService.deletePUBConfig

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.deletePUBConfig(inDeleteDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


#End Region

#Region "2014/11/08 公用類別代碼維護(PubSyscodeType) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function queryPUBSyscodeTypeLikePKey(ByVal inTypeId As String) As DataSet Implements IPubService.queryPUBSyscodeTypeLikePKey

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBSyscodeTypeLikePKey(inTypeId)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function qureyPUBSyscodeTypeAll() As DataSet Implements IPubService.qureyPUBSyscodeTypeAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.qureyPUBSyscodeTypeAll()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function savePUBSyscodeType(ByVal inSaveDs As DataSet) As DataSet Implements IPubService.savePUBSyscodeType

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.savePUBSyscodeType(inSaveDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function deletePUBSyscodeType(ByVal inDeleteDs As DataSet) As DataSet Implements IPubService.deletePUBSyscodeType

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.deletePUBSyscodeType(inDeleteDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


#End Region

#Region "2014/11/09 公用代碼維護(PubSyscode) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBSyscodeLikePKey(ByVal inTypeId As String, ByVal inCodeId As String) As DataSet Implements IPubService.queryPUBSyscodeLikePKey

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBSyscodeLikePKey(inTypeId, inCodeId)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function qureyPUBSyscodeAll() As DataSet Implements IPubService.qureyPUBSyscodeAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.qureyPUBSyscodeAll()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBSyscode(ByVal inSaveDs As DataSet) As DataSet Implements IPubService.savePUBSyscode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.savePUBSyscode(inSaveDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBSyscode(ByVal inDeleteDs As DataSet) As DataSet Implements IPubService.deletePUBSyscode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.deletePUBSyscode(inDeleteDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


#End Region

#Region "2014/11/09 醫事機構維護(PubHospital) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別、生效日期與醫院代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBHospitalLikePKey(ByVal inLanguageTypeId As String, ByVal inEffectDate As String, ByVal inHospitalCode As String) As DataSet Implements IPubService.queryPUBHospitalLikePKey

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBHospitalLikePKey(inLanguageTypeId, inEffectDate, inHospitalCode)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function qureyPUBHospitalAll() As DataSet Implements IPubService.qureyPUBHospitalAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.qureyPUBHospitalAll()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' 畫面初始化資料查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-10</remarks>
    Public Function initPubHospital() As DataSet Implements IPubService.initPubHospital

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.initPubHospital()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBHospital(ByVal inSaveDs As DataSet) As DataSet Implements IPubService.savePUBHospital

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.savePUBHospital(inSaveDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBHospital(ByVal inDeleteDs As DataSet) As DataSet Implements IPubService.deletePUBHospital

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.deletePUBHospital(inDeleteDs)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function


#End Region

#Region "2014/12/02 by Lits 取得員工全部資料"
    ''' <summary>
    ''' 取得員工全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    Public Function queryEmployeeALL() As DataSet Implements IPubService.queryEmployeeALL

        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryEmployeeALL()

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' 取得員工全部資料 By 部們
    ''' </summary>
    ''' <returns>dept</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    Public Function queryEmployeeByDept(ByVal dept As String) As DataSet Implements IPubService.queryEmployeeByDept
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryEmployeeByDept(dept)

        Catch ex As Exception

            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing

        End Try
    End Function
#End Region

#Region "20090414 假日維護檔, add by James"


    Function queryPubHolidayAll() As DataSet Implements IPubService.queryPubHolidayAll
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBHolidayAll()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

    Function queryPubHolidayByKey(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet Implements IPubService.queryPubHolidayByKey
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBHolidayByKey(holidayDate, subSysCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function


    Function insertPubHoliday(ByVal dsParam As DataSet) As Integer Implements IPubService.insertPubHoliday
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPUBHoliday(dsParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function


    Function deletePubHoliday(ByVal holidayDate As String, ByVal subSysCode As String) As Integer Implements IPubService.deletePubHoliday
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.deletePUBHoliday(holidayDate, subSysCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function


    Function updatePubHoliday(ByVal dsParam As Data.DataSet) As Integer Implements IPubService.updatePubHoliday
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.updatePUBHoliday(dsParam)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

    Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal datestrHolidayYear As Date, ByVal strSubSystemCode As String) As DataSet Implements IPubService.queryPUBHolidayByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBHolidayByCond(strHolidayYear, datestrHolidayYear, strSubSystemCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20090803 add by Rich, PUBSysCodeBO_E1"

    Public Function queryPUBSysCodeInCond(ByVal TypeId As String) As DataSet Implements IPubService.queryPUBSysCodeInCond
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBSysCodeInCond(TypeId)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function

#End Region

#Region "20090317 add by Alan 掛號 - 依傳入TypeID取得代碼檔資料"
    Public Function queryPUBSysCode(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False) As System.Data.DataSet Implements IPubService.queryPUBSysCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBSysCode(TypeID, multiCodeIdFlag)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)

            Return Nothing
        End Try
    End Function
#End Region

#Region "2009/08/11 add by markwu,病患基本檔"

    'Public Function PPatientInit() As DataSet Implements IPubService.PPatientUIInit
    '    Try
    '        Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
    '        Return pubDlg.PPInitUI

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function queryPubChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet Implements IPubService.queryPubChartNoByKey
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPubChartNoByKey(codeNo, codeType)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "20090317 add by Alan 掛號 - 取得所有細分科"
    Public Function queryPUBDepartmentAll_D() As System.Data.DataSet Implements IPubService.queryPUBDepartmentAll_D
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBDepartmentAll_D()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得科室資料
    ''' </summary>
    ''' <returns>科室資料</returns>
    ''' <author>Ken</author>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentBySmallDept() As DataSet Implements IPubService.queryPUBDepartmentBySmallDept
        Try
            Dim _myDelegate As PUBDelegate = PUBDelegate.getInstance

            Return _myDelegate.queryPUBDepartmentBySmallDept
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：依據來源別O、E、I，取得對應的門診、急診、住院 科別
    ''' 開發人員：Charles
    ''' 調整日期：2015/12/16
    ''' </summary>
    ''' <param name="SourceType">O：門診、E：急診、I：住院</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As DataSet Implements IPubService.queryPUBDepartmentAll_D2
        Try
            Dim _myDelegate As PUBDelegate = PUBDelegate.getInstance

            Return _myDelegate.queryPUBDepartmentAll_D2(SourceType)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20100128 add by Rich, PUBOrderPriceBO_E1"

    Public Function queryOrderPriceData(ByVal OrderCode As String) As DataTable Implements IPubService.queryOrderPriceDataByOrder
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryOrderPriceDataByOrder(OrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "2010/01/20, Add By 谷官, 健保資料設定(OPCSetHealthInsuData)"

    ''' <summary>
    ''' 藥品加收部負
    ''' </summary>
    ''' <param name="OpdChargeDate">門診批價日</param>
    ''' <param name="MedicalAmt">藥品金額</param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getMedicalPartAmt(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal) As DataTable Implements IPubService.getMedicalPartAmt
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getMedicalPartAmt(OpdChargeDate, MedicalAmt)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function getPubOrderPriceDataForOPCAPI(ByVal keyValue As DataSet) As DataTable Implements IPubService.getPubOrderPriceDataForOPCAPI
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getPubOrderPriceDataForOPCAPI(keyValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "2012-02-14 PUBPatientAllergyNew相關程式"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Function InitUI() As DataSet Implements IPubService.InitUI
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.InitUI()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Function Find_AllergyRecord(ByVal Chart_No As String) As DataTable Implements IPubService.Find_AllergyRecord
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.Find_AllergyRecord(Chart_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Function Find_PatientData(ByVal Chart_No As String) As DataTable Implements IPubService.Find_PatientData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.Find_PatientData(Chart_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Function Find_AllergyHistory(ByVal Chart_No As String) As DataTable Implements IPubService.Find_AllergyHistory
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.Find_AllergyHistory(Chart_No)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Sub AddNew_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Create_Time As String, ByVal Create_User As String) Implements IPubService.AddNew_AllergyRecord
        Try
            PUBDelegate.getInstance.AddNew_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Create_User, Create_Time)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Function AddNew_AllergyRecord_NKDA(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                                 ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                                 ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                                 ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                                 ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, ByVal Modified_Time As String, _
                                 ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String Implements IPubService.AddNew_AllergyRecord_NKDA
        Try
            Return PUBDelegate.getInstance.AddNew_AllergyRecord_NKDA(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Severity, _
                              Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Pharmacy_12_Code, ADRNotification_No, Cancel, _
                              Create_User, Create_Time, Modified_User, _
                              Modified_Time, Drug_Allergy_Id, Limit_Strength, order_name)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function AddNew_AllergyRecord_OTHER(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                                 ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                                 ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                                 ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                                 ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, ByVal Modified_Time As String, _
                                 ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String Implements IPubService.AddNew_AllergyRecord_OTHER
        Try
            Return PUBDelegate.getInstance.AddNew_AllergyRecord_OTHER(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Severity, _
                              Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Pharmacy_12_Code, ADRNotification_No, Cancel, _
                              Create_User, Create_Time, Modified_User, _
                              Modified_Time, Drug_Allergy_Id, Limit_Strength, order_name)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Sub Modify_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Modified_User As String, ByVal Modified_Time As String) Implements IPubService.Modify_AllergyRecord
        Try
            PUBDelegate.getInstance.Modify_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Modified_User, Modified_Time)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Sub Delete_AllergyRecord(ByVal Chart_No As String, ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Cancel As String, ByVal Modified_User As String, ByVal Modified_Time As String, ByVal Allergy_no As String) Implements IPubService.Delete_AllergyRecord
        Try
            PUBDelegate.getInstance.Delete_AllergyRecord(Chart_No, Allergy_Code, Allergy_Item, Cancel, Modified_User, Modified_Time, Allergy_no)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' 957195.20121211 移除凌群exception handler
    ''' </remarks>
    Public Sub Reset_IsFromICCard(ByVal Chart_No As String, ByVal Drug1 As String, ByVal Drug2 As String, ByVal Drug3 As String) Implements IPubService.Reset_IsFromICCard
        Try
            PUBDelegate.getInstance.Reset_IsFromICCard(Chart_No, Drug1, Drug2, Drug3)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        End Try
    End Sub
#End Region

#Region "2009/07/20, Add By 谷官, 收退費(OPCReceiptUI)"
    ''' <summary>
    ''' 程式說明：取得殘障記錄的迄日
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.04
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="OpdVisitDate">看診日期</param>
    ''' <returns>殘障記錄的迄日</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function getEndDateForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String) As DataTable Implements IPubService.getEndDateForReceiptUI
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.getEndDateForReceiptUI(ChartNo, OpdVisitDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 程式說明：取得是否有有效的殘障紀錄 by Chart_No
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>回傳0，則無相關紀錄，回傳1則有</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function getPatientDisabilityRecordForReceiptUI(ByVal ChartNo As String) As DataTable Implements IPubService.getPatientDisabilityRecordForReceiptUI
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.getPatientDisabilityRecordForReceiptUI(ChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：新增有效的殘障紀錄 by Chart_No
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function insertPatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer Implements IPubService.insertPatientDisabilityRecordForReceiptUI
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.insertPatientDisabilityRecordForReceiptUI(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：修改有效的殘障紀錄 by Chart_No
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ds">病歷號</param>
    ''' <returns></returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function updatePatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer Implements IPubService.updatePatientDisabilityRecordForReceiptUI
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.updatePatientDisabilityRecordForReceiptUI(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 程式說明：取得殘障序號的最大值 by Chart_No
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.06
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>殘障記錄的迄日</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function getMaxPatientDisabilityNoForReceiptUI(ByVal ChartNo As String) As Integer Implements IPubService.getMaxPatientDisabilityNoForReceiptUI
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.getMaxPatientDisabilityNoForReceiptUI(ChartNo)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 程式說明：取得重大傷病的Icd_Code、證明文號、起迄日
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.04
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="OpdVisitDate">看診日期</param>
    ''' <param name="IcdCodeDT">診斷檔的前3個診斷的Icd_Code、證明文號、起迄日</param>
    ''' <returns>Icd_Code</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function getIcdCodeForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String, ByVal IcdCodeDT As DataTable) As DataTable Implements IPubService.getIcdCodeForReceiptUI
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getIcdCodeForReceiptUI(ChartNo, OpdVisitDate, IcdCodeDT)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function
#End Region

    ''' <summary>  
    ''' 程式說明：取得所有PUB Sheet資料
    ''' 開發人員：James
    ''' 開發日期：2009.09.26
    ''' </summary>  
    ''' <returns>PUB Sheet資料</returns>
    Public Function queryPUBSheet() As DataSet Implements IPubService.queryPUBSheet

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPUBSheet()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 依科室代碼查詢表單代碼 (已trim掉空白)
    ''' </summary>
    ''' <param name="DeptCode">科室代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <remarks>
    ''' Sheet_Type_Id = '2'
    ''' </remarks>
    Public Function queryPUBSheetSheetSheetCodeByDeptCode(ByVal DeptCode As String) As DataSet Implements IPubService.queryPUBSheetSheetSheetCodeByDeptCode
        Try
            Return PUBDelegate.getInstance.queryPUBSheetSheetSheetCodeByDeptCode(DeptCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#Region "由表單代碼 Sheet_Code取得表單資訊"

    Public Function queryPubSheetBySheetCode(ByVal SheetCode As String) As DataSet Implements IPubService.queryPubSheetBySheetCode
        Try
            Return PUBDelegate.getInstance.queryPubSheetBySheetCode(SheetCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "常用一般診斷查詢"

    Public Function queryPUBDiseaseByFavor(ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IPubService.queryPUBDiseaseByFavor

        Try
            Return PUBDelegate.getInstance.queryPUBDiseaseByFavor(code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try

    End Function

    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IPubService.queryPUBDiseaseByFavor2

        Try
            Return PUBDelegate.getInstance.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try

    End Function

#Region "2009/09/18, Add By Alan, 查詢一般醫令"

    ''' <summary>  
    ''' 程式說明：查詢一般醫令
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.18
    ''' </summary> 
    ''' <returns>表單明細</returns>
    Public Function queryPUBOrderByCond(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal Specimen As String, ByVal Body_Site As String) As DataSet Implements IPubService.queryPUBOrderByCond
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPUBOrderByCond(OrderCode, OrderName, OrderTypeId, Specimen, Body_Site)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderByLanguage(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String) As DataSet Implements IPubService.queryPUBOrderByLanguage
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPUBOrderByLanguage(OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String) As DataSet Implements IPubService.queryPUBOrderByLanguage3
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag, ChartNo, OutpatientSn)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderIsDC(ByVal inOrderCode As String) As DataSet Implements IPubService.queryPUBOrderIsDC
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPUBOrderIsDC(inOrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try
    End Function

#End Region


#End Region

#Region " 醫令自費與健保價格查詢"

    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet Implements IPubService.queryPUBOrderOwnAndNhiPrice

        Try
            Return PUBDelegate.getInstance.queryPUBOrderOwnAndNhiPrice(OrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Throw ex
        End Try

    End Function
#End Region

#Region "20100730 add by Rich, OPHPhraseBO_E1"

    Public Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String) As DataSet Implements IPubService.queryPhraseNameByOPHRuleReason
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "20100825 add by Rich, 非PUB動態SQL"

    ''' <summary>
    ''' 非PUB動態SQL
    ''' </summary>
    ''' <param name="sqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleDynamicQueryNotPub(ByRef sqlString As String) As System.Data.DataSet Implements IPubService.RuleDynamicQueryNotPub
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDynamicQueryNotPub(sqlString)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "2013/07/22 955236 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥"

    ''' <summary>
    ''' 撈出病人之前看診的紀錄並找出有開立藥品且藥品尚未過期的藥
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Outpatient_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(ByVal Chart_No As String, ByVal Outpatient_Sn As String) As DataSet Implements IPubService.PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(Chart_No, Outpatient_Sn)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "同類藥檢核"

    ''' <summary>
    ''' 同類藥檢核查詢
    ''' </summary>
    ''' <param name="Phamarcy12code">成大十二碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QuerySameKineMedicine(ByVal Phamarcy12code As String) As DataSet Implements IPubService.QuerySameKineMedicine
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.QuerySameKineMedicine(Phamarcy12code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

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
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String) As DataSet Implements IPubService.EMRMedicineRecordRuleQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.EMRMedicineRecordRuleQuery(Chart_no, orderCode, Start_Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式功能：化療藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EMRMedicineRecordRuleQuery2(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String, ByVal end_Date As String) As DataSet Implements IPubService.EMRMedicineRecordRuleQuery2
        Try
            Try
                Dim instance As PUBDelegate = PUBDelegate.getInstance
                Return instance.EMRMedicineRecordRuleQuery(Chart_no, orderCode, Start_Date, end_Date)
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

    ''' <summary>
    ''' Insert OPH_Alert_Record
    ''' </summary>
    ''' <param name="InputDs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertOPH_Alert_Record(ByVal InputDs As DataSet) As Int32 Implements IPubService.InsertOPH_Alert_Record
        Try
            Return PUBDelegate.getInstance.InsertOPH_Alert_Record(InputDs)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#Region "20090819 add by Rich, 檢核規則 PUBRuleBO_E1"

    Public Function RuleQueryAll() As System.Data.DataSet Implements IPubService.RuleQueryAll
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleQueryAll
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.RuleInsert
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleInsert(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function

    Public Function RuleDynamicQuery(ByRef sqlString As String) As System.Data.DataSet Implements IPubService.RuleDynamicQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDynamicQuery(sqlString)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDynamicQueryPCS(ByRef sqlString As String) As System.Data.DataSet Implements IPubService.RuleDynamicQueryPCS
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDynamicQueryPCS(sqlString)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDynamicQueryEmr(ByVal sqlString As String) As System.Data.DataSet Implements IPubService.RuleDynamicQueryEmr
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDynamicQueryEmr(sqlString)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet Implements IPubService.RuleDynamicQueryWithColumnValue
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDynamicQueryWithColumnValue(columnName, columnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleQueryByPK(ByRef pk_Rule_Code As System.String) As System.Data.DataSet Implements IPubService.RuleQueryByPK
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleQueryByPK(pk_Rule_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDelete(ByRef pk_Rule_Code As System.String) As Integer Implements IPubService.RuleDelete
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDelete(pk_Rule_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function

    Public Function RuleUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.RuleUpdate
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleUpdate(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function


    Public Function dynamicQueryForEis(ByRef SQLStr As String) As DataSet Implements IPubService.dynamicQueryForEis
        Try
            Dim instance As PUBDynamicBS = PUBDynamicBS.getInstance
            Return instance.dynamicQueryForEis(SQLStr)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20090819 add by Rich, 檢核規則 PUBRuleDetailBO_E1"

    Public Function RuleDetailQueryAll() As System.Data.DataSet Implements IPubService.RuleDetailQueryAll
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailQueryAll
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDetailInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.RuleDetailInsert
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailInsert(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function

    Public Function RuleDetailDynamicQuery(ByRef sqlString As String) As System.Data.DataSet Implements IPubService.RuleDetailDynamicQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailDynamicQuery(sqlString)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDetailDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet Implements IPubService.RuleDetailDynamicQueryWithColumnValue
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailDynamicQueryWithColumnValue(columnName, columnValue)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDetailQueryByPK(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As System.Data.DataSet Implements IPubService.RuleDetailQueryByPK
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailQueryByPK(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDetailDelete(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As Integer Implements IPubService.RuleDetailDelete
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailDelete(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function

    Public Function RuleDetailUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.RuleDetailUpdate
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailUpdate(ds)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return -1
        End Try
    End Function

#End Region

#Region "20091216 add by Rich, PUBRuleBS"

    Public Function getCallFormDS(ByVal RuleCode As String) As DataSet Implements IPubService.getCallFormDS
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getCallFormDS(RuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleExpressionStrQuery(ByVal RuleCode As String) As System.Data.DataSet Implements IPubService.RuleExpressionStrQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleExpressionStrQuery(RuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleDetailQuery(ByVal RuleCode As String) As System.Data.DataSet Implements IPubService.RuleDetailQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleDetailQuery(RuleCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function getCheckRuleDS(ByVal RuleCode As String, ByVal ValueData As String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String) As DataSet Implements IPubService.getCheckRuleDS
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.getCheckRuleDS(RuleCode, ValueData, Source, Main_Identity_Id, Base_Date)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleClassQuery(ByVal RuleCode As String, ByVal ValueData As String) As System.Data.DataSet Implements IPubService.RuleClassQuery
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleClassQuery(RuleCode, ValueData)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleQueryByCond(ByRef pk_Rule_Code As System.String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String) As System.Data.DataSet Implements IPubService.RuleQueryByCond
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleQueryByCond(pk_Rule_Code, Source, Main_Identity_Id, Base_Date)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleCodeTransfer1(ByVal OrderCode As String) As System.Data.DataSet Implements IPubService.RuleCodeTransfer1
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleCodeTransfer1(OrderCode)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function RuleCodeTransfer2(ByVal Insu_Code As String) As System.Data.DataSet Implements IPubService.RuleCodeTransfer2
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.RuleCodeTransfer2(Insu_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryItemName(ByVal Item_Code As String) As System.Data.DataSet Implements IPubService.queryItemName
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryItemName(Item_Code)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleValueData(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet Implements IPubService.queryRuleValueData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleValueData(Item_Code, Value_Data)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryClassAndField(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet Implements IPubService.queryClassAndField
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryClassAndField(Item_Code, Value_Data)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryRuleCode(ByVal Item_Code As String, ByVal Value_Data As String, ByVal Base_Date As String) As System.Data.DataSet Implements IPubService.queryRuleCode
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryRuleCode(Item_Code, Value_Data, Base_Date)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 搜尋歷史醫令
    ''' </summary>
    ''' <param name="Medical_Sn">就醫序號</param>
    ''' <param name="SystemType">系統歸屬 {O}門診 or {E}急診 or {I}住院</param>
    ''' <param name="Location">C,P,S</param>
    ''' <returns>所有歷史醫令的資料集</returns>
    ''' <remarks>by Rich on 2012-05-30</remarks>
    Public Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet Implements IPubService.GetCurrentOrderset
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.GetCurrentOrderset(Medical_Sn, SystemType, Location)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

#End Region

#Region "成大碼轉健保碼"

    ''' <summary>
    ''' 成大碼轉健保碼
    ''' </summary>
    ''' <param name="OrderCodeDS"></param>
    ''' <param name="BasicDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryInsuCodeByOrderCode(ByVal OrderCodeDS As DataSet, Optional ByVal BasicDate As String = "") As DataSet Implements IPubService.queryInsuCodeByOrderCode

        Try
            Return PUBDelegate.getInstance.queryInsuCodeByOrderCode(OrderCodeDS, BasicDate)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

    End Function


#End Region

#Region "2015/06/01 單張報表描述檔維護(Pub_Report_Desc) by ChenYu.Guo"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescdelete(ByRef pk_Report_ID As System.String) As Integer Implements IPubService.PubReportDescdelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubReportDescdelete(pk_Report_ID)

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
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByLikeColumn(ByRef reportID As String, ByRef reportName As String, ByRef SystemCode As String) As DataSet Implements IPubService.PubReportDescQueryByLikeColumn

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubReportDescQueryByLikeColumn(reportID, reportName, SystemCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     QueryByPK "
    ''' <summary>
    ''' QueryByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByPK(ByRef pk_Report_ID As System.String) As System.Data.DataSet Implements IPubService.PubReportDescQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubReportDescQueryByPK(pk_Report_ID)

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
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubReportDescinsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubReportDescinsert(ds)

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
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubReportDescupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubReportDescupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2015/06/01 報表列印記錄檔查詢作業(Pub_Print_Record) by ChenYu.Guo"

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubPrintRecordQueryPrintRecord(ByRef reportID As String, ByRef reportName As String, ByRef createUse As String, ByRef createTime As String, ByRef endTime As String, ByRef printIP As String) As DataSet Implements IPubService.PubPrintRecordQueryPrintRecord

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPrintRecordQueryPrintRecord(reportID, reportName, createUse, createTime, endTime, printIP)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     將列印報表、預覽報表的資料 新增至 PUB_Print_Record "
    ''' <summary>
    ''' 將列印報表、預覽報表的資料 新增至 PUB_Print_Record
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function insertRPTPrintClient(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.insertRPTPrintClient

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.insertRPTPrintClient(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2015/07/14 身高體重登記作業(Pub_Patient_BodyRecord) by Sharon.Du"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecorddelete(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As Integer Implements IPubService.PubPatientBodyRecorddelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyRecorddelete(pk_Chart_No, pk_Measure_Time)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以PK查詢 "
    ''' <summary>
    ''' 以PK查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordQueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As System.Data.DataSet Implements IPubService.PubPatientBodyRecordQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyRecordQueryByPK(pk_Chart_No, pk_Measure_Time)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以病歷號、來源別、登錄單位查詢 "
    ''' <summary>
    ''' 以病歷號、來源別、登錄單位查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Overloads Function PubPatientBodyRecordqueryPubPatientBodyrecordByCond(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, ByVal ChartNo As String) As System.Data.DataSet Implements IPubService.PubPatientBodyRecordqueryPubPatientBodyrecordByCond

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyRecordqueryPubPatientBodyrecordByCond(gblSourceTypeId, gblKeyinUnit, ChartNo)

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
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubPatientBodyRecordinsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyRecordinsert(ds)

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
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubPatientBodyRecordupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyRecordupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2015-06-29 遠端報表列印 by Lits ADD"
    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportConfigByReportId(ByVal inReportId As String) As DataSet Implements IPubService.queryReportConfigByReportId
        Try
            Dim _ip As PUBDelegate = PUBDelegate.getInstance
            Return _ip.queryReportConfigByReportId(inReportId)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function queryReportMode(ByVal inReportId As String) As String Implements IPubService.queryReportMode
        Try
            Dim _ip As PUBDelegate = PUBDelegate.getInstance
            Return _ip.queryReportMode(inReportId)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 取得報表列印資訊
    ''' </summary>
    ''' <param name="repprtID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportInfo(ByVal repprtID As String, ByVal printerType As String, ByVal printerCond As String) As DataSet Implements IPubService.getReportInfo
        Try
            Dim _ip As Syscom.Server.RPT.RPTDelegate = Syscom.Server.RPT.RPTDelegate.getInstance
            Return _ip.getReportInfo(repprtID, printerType, printerCond)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="inStationNo"></param>
    ''' <param name="inTermCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function queryReportAllConfig(ByVal inReportId As String, ByVal inStationNo As String, ByVal inTermCode As String) As DataSet Implements IPubService.queryReportAllConfig
        Try
            Dim _ip As PUBDelegate = PUBDelegate.getInstance
            Return _ip.queryReportAllConfig(inReportId, inStationNo, inTermCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

#Region "2015/07/10 報表維護資料(PUB_Print_Config 與 PUB_Report_Desc) by Kaiwen,Hsiao"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfiginsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPrintConfiginsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfiginsert(ds)

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
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigupdate(ByVal dsPubPrintConfig As System.Data.DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer Implements IPubService.PUBPrintConfigupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfigupdate(dsPubPrintConfig, dsPubReportDesc)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     刪除 "

    Public Function PUBPrintConfigdelete(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As Integer Implements IPubService.PUBPrintConfigdelete

        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return PUBDelegate.getInstance.PUBPrintConfigdelete(pk_Report_Id, pk_Print_Type, pk_Print_Cond)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigqueryAll() As System.Data.DataSet Implements IPubService.PUBPrintConfigqueryAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfigqueryAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements IPubService.PUBPrintConfigdynamicQueryWithColumnValue

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfigdynamicQueryWithColumnValue(columnName, columnValue)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     報表列印記錄檔查詢 "
    ''' <summary>
    ''' 報表列印記錄檔查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigQueryByLikeColumn(ByVal Report_Id As String, ByVal Print_Type As String, ByVal Print_Cond As String, ByVal Printer_Name As String, ByVal Paper_Size As String) As DataSet Implements IPubService.PUBPrintConfigQueryByLikeColumn

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfigQueryByLikeColumn(Report_Id, Print_Type, Print_Cond, Printer_Name, Paper_Size)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     新增 PUB_Print_Config、PUB_Report_Desc 資料 "

    ''' <summary>
    ''' 新增 PUB_Print_Config、PUB_Report_Desc 資料
    ''' </summary>

    Public Function PUBPrintConfigBSInsert(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer Implements IPubService.PUBPrintConfigBSInsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPrintConfigBSInsert(dsPubPrintConfig, dsPubReportDesc)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#End Region

#End Region

#Region "2015/07/15 大分科所屬細分科統計(PUB_Department) by ChenYu.Guo"

    ''' <summary>
    ''' 大分科所屬細分科統計
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-07-15</remarks>
    Public Function PUBDepartmentqueryPUBDepartmentCount() As DataSet Implements IPubService.queryPUBDepartmentCount

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBDepartmentCount()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2015/07/27 醫令主檔(PubOrder) by Sean.Lin"

#Region "     查詢醫令項目基本檔 "
    ''' <summary>
    ''' 查詢醫令項目基本檔   
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <param name="dc">Y、N，空字串表示不判斷</param>
    ''' <param name="judgeDate" >yyyy/MM/dd，空字串表示不判斷，判斷日當天仍有效的Order</param>
    ''' <remarks>by Sean.Lin on 2015-07-27</remarks>
    Public Function PubOrderqueryByOrderCode(ByVal strOrderCode As String, ByVal dc As String, ByVal judgeDate As String) As DataSet Implements IPubService.PubOrderqueryByOrderCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubOrderqueryByOrderCode(strOrderCode, dc, judgeDate)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2015/08/07 報表警示設定維護檔(PUB_Report_Alarm) by Hsiao.Kaiwen"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function PUBReportAlarminsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBReportAlarminsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarminsert(ds)

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
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function PUBReportAlarmupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBReportAlarmupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarmupdate(ds)

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
    ''' 刪除
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmdelete(ByRef pk_Report_ID As System.String) As Integer Implements IPubService.PUBReportAlarmdelete

        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return PUBDelegate.getInstance.PUBReportAlarmdelete(pk_Report_ID)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢報表警示設定維護檔 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByLikeColumn(ByVal Report_ID As String, ByVal Report_Name As String, ByVal Rpt_Alarm_Count As String, ByVal Rpt_Is_Active As String) As DataSet Implements IPubService.PUBReportAlarmQueryByLikeColumn

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarmQueryByLikeColumn(Report_ID, Report_Name, Rpt_Alarm_Count, Rpt_Is_Active)

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
    ''' 查詢PK資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByPK(ByVal Report_ID As String) As DataSet Implements IPubService.PUBReportAlarmQueryByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarmQueryByPK(Report_ID)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢報表ID-初始化Combobox "

    ''' <summary>
    ''' 查詢報表ID-初始化Combobox
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryReportId() As DataSet Implements IPubService.PUBReportAlarmQueryReportId

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarmQueryReportId()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢 Alarm Count "

    ''' <summary>
    ''' 查詢 Alarm Count
    ''' </summary>
    ''' <returns>Integer</returns>    
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmCountQuery(ByVal Report_ID As String) As Integer Implements IPubService.PUBReportAlarmCountQuery

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBReportAlarmCountQuery(Report_ID)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#End Region

#End Region

#Region "2015/08/12 吸菸嚼檳榔問卷(PUB_Patient_Personal_Habits) by ChenYu.Guo"

#Region "     查詢該病患最近一年內的勸戒之記錄 "
    ''' <summary>
    ''' 查詢該病患最近一年內的勸戒之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function QueryInOneYearAdmonishRecord(ByRef ChartNo As String) As DataSet Implements IPubService.QueryInOneYearAdmonishRecord

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryInOneYearAdmonishRecord(ChartNo)

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
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientPersonalHabitsinsert

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientPersonalHabitsinsert(ds)

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
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientPersonalHabitsupdate

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientPersonalHabitsupdate(ds)

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
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsqueryByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubService.PUBPatientPersonalHabitsqueryByPK

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientPersonalHabitsqueryByPK(pk_Chart_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2015/08/12 TOCC問卷(PUB_Patient_TOCC) by ChenYu.Guo"

#Region "     查詢是否存在該患當日之記錄 "
    ''' <summary>
    ''' 查詢是否存在該患當日之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function QueryTodayPatientTOCCRecord(ByRef ChartNo As String) As DataSet Implements IPubService.QueryTodayPatientTOCCRecord

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryTodayPatientTOCCRecord(ChartNo)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     新增TOCC問卷結果 "
    ''' <summary>
    ''' 新增TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen.Yu on 2015-08-14</remarks>
    Public Function PUBPatientTOCCinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientTOCCinsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPatientTOCCinsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     修改TOCC問卷結果 "
    ''' <summary>
    ''' 修改TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Public Function PUBPatientTOCCupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientTOCCupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPatientTOCCupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2015/08/19 取得後端 AP Server 系統日期時間 By Lits"

    ''' <summary>
    ''' 取得後端 AP Server 系統日期時間
    ''' </summary>
    ''' <returns>AP Server 系統日期時間</returns>
    ''' <remarks></remarks>
    Public Function getApServerSystemDateTime() As DateTime Implements IPubService.getApServerSystemDateTime
        Try
            Return Now

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2015/08/21 診間查詢form診間誤餐登記(PUB_Zone_Room) by ChenYu.Guo"

#Region "     queryPUBZoneRoomForMissMeal "
    ''' <summary>
    ''' queryPUBZoneRoomForMissMeal
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-21</remarks>
    Public Function queryPUBZoneRoomForMissMeal(ByVal Room_Code As String) As DataSet Implements IPubService.queryPUBZoneRoomForMissMeal

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBZoneRoomForMissMeal(Room_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2015/09/02 報表列印工作 Add By Charles"

    Public Function insertPrintJobData(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.insertPrintJobData
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPrintJobData(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Sub PUBReportJobProcess(ByVal JobID As String, ByVal UserID As String) Implements IPubService.PUBReportJobProcess
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            oper.PUBReportJobProcess(JobID, UserID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))

        End Try
    End Sub

#End Region

#Region "2015/09/02 PUBPrintJobQueryUI(報表執行進度查詢) Add By Charles "

    Public Function queryPUBPrintJobByCond(ByVal cond As DataTable) As DataSet Implements IPubService.queryPUBPrintJobByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBPrintJobByCond(cond)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function queryPUBPrintJobReportType() As DataSet Implements IPubService.queryPUBPrintJobReportType
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBPrintJobReportType()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function queryPUBPrintJobReportByType(ByVal reportType As String, ByVal userId As String) As DataSet Implements IPubService.queryPUBPrintJobReportByType
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBPrintJobReportByType(reportType, userId)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function increaseDownloadCnt(ByVal JobID As String) As Integer Implements IPubService.increaseDownloadCnt
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.increaseDownloadCnt(JobID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2015/09/10 查診展班週數(PUB_Config) by ChenYu.Guo"

#Region "     查診展班週數 "
    ''' <summary>
    ''' 查診展班週數
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-10</remarks>
    Public Function PUBConfigQueryExpandWeek() As DataSet Implements IPubService.PUBConfigQueryExpandWeek

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBConfigQueryExpandWeek()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "20090803 add by Rich, PUBBodySiteBO_E1"

    Public Function queryPUBBodySiteMainSiteData() As DataSet Implements IPubService.queryPUBBodySiteMainSiteData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBBodySiteMainSiteData
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String) As DataSet Implements IPubService.queryPUBBodySiteNotMainSiteData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBBodySiteNotMainSiteData(MainBodySiteCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2015/09/28 查詢看診目的(PUB_Medical_Type_Id) by Will,Lin"
#Region "     查詢看診目的 "
    ''' <summary>
    ''' 查詢看診目的
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Will,Lin</remarks>
    Public Function getPUBMedicalTypeId() As DataSet Implements IPubService.getPUBMedicalTypeId
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance()
            Return oper.getPUBMedicalTypeId()
        Catch ex As Exception
            Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function
#End Region
#End Region

#Region "2015/09/29 取得藥品名稱自動搜尋視窗的藥品資料 ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品名稱自動搜尋視窗的藥品資料
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyBase(ByRef orderName As String) As DataTable Implements IPubService.Get_PharmacyBase

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.Get_PharmacyBase(orderName)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2015/09/29 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料 ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料(原Get_PharmacyClass)
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyClassAndCompositionAndATC(ByVal orderName As String, ByVal NameType As String) As DataTable Implements IPubService.Get_PharmacyClassAndCompositionAndATC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.Get_PharmacyClassAndCompositionAndATC(orderName, NameType)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2015/10/05 查詢TOCC關閉視窗之控制(PUB_Config) by ChenYu.Guo"

#Region "     查詢TOCC關閉視窗之控制 "
    ''' <summary>
    ''' 查詢TOCC關閉視窗之控制
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Public Function PUBConfigQueryTOCCCloseWindows() As String Implements IPubService.PUBConfigQueryTOCCCloseWindows

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBConfigQueryTOCCCloseWindows()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2015/10/30 過敏藥品查詢(PUB_Patient_Allergy) by Eddie,Lu"

#Region "     過敏藥品查詢 "
    ''' <summary>
    ''' 過敏藥品查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function queryPUBPatientAllergyByCond(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubService.queryPUBPatientAllergyByCond

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBPatientAllergyByCond(pk_Chart_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2015/11/11 看診目的基本檔維護作業(PUB_Medical_Type) by Eddie,Lu"

#Region "     一般查詢 "
    ''' <summary>
    ''' 一般查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequery(ByRef medicalTypeId As String, ByRef medicalTypeName As String, ByRef medicalTypeCtrlId As String, ByRef disIdentityCode As String, ByRef Contract_Code1 As String, ByRef Contract_Code2 As String, ByRef partCode As String, ByRef cardSn As String, ByRef icMedicalTypeId As String, ByRef caseTypeId As String, ByVal pedSort As Integer, ByVal surSort As Integer, ByVal medSort As Integer, ByVal entSort As Integer, ByVal uroSort As Integer, ByRef rehSort As Integer, ByVal ipdSort As Integer, ByVal opdSort As Integer, ByVal emgSort As Integer) As DataSet Implements IPubService.PUBMedicalTypequery

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypequery(medicalTypeId, medicalTypeName, medicalTypeCtrlId, disIdentityCode, Contract_Code1, Contract_Code2, partCode, cardSn, icMedicalTypeId, caseTypeId, pedSort, surSort, medSort, entSort, uroSort, rehSort, ipdSort, opdSort, emgSort)


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
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypedelete(ByRef pk_Medical_Type_Id As System.String) As Integer Implements IPubService.PUBMedicalTypedelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypedelete(pk_Medical_Type_Id)

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
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBMedicalTypeinsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypeinsert(ds)

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
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBMedicalTypeupdate

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypeupdate(ds)

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
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryAll() As System.Data.DataSet Implements IPubService.PUBMedicalTypequeryAll

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypequeryAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "     取得Cbo資料 "
    ''' <summary>
    ''' 取得Cbo資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryCboData() As DataSet Implements IPubService.PUBMedicalTypequeryCboData

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMedicalTypequeryCboData()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2016/04/19 add by Kaiwen, 排除藥費(PUBExcludeDrugSetBO_E1) "

    Public Function queryExclusiveDrugSetData2(ByVal OrderCode As String) As DataTable Implements IPubService.queryExclusiveDrugSetData2
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryExclusiveDrugSetData2(OrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function insertExclusiveDrugSetByOrderCode(ByVal OrderCode As String, ByVal insertData As DataSet) As Integer Implements IPubService.insertExclusiveDrugSetByOrderCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertExclusiveDrugSetByOrderCode(OrderCode, insertData)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2016/04/19 Add by Kaiwen, 找多個TypeId的syscode (PUBNhiIndexSetUI)【查詢Syscode(多筆)】 "

    Public Function querySyscodeByTypeIds(ByVal TypeIds() As Integer) As DataTable Implements IPubService.querySyscodeByTypeIds
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.querySyscodeByTypeIds(TypeIds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2016/04/19 查詢健保支付標準檔資料(PUBNhiCodeBO) , Added by Kaiwen"

    Public Function queryPubNhiCodeEffectData(ByVal inEffectDate As String, ByVal inInsuCode As String, ByVal inOrderCode As String) As DataTable Implements IPubService.queryPubNhiCodeEffectData

        Try
            Return PUBDelegate.getInstance.queryPubNhiCodeEffectData(inEffectDate, inInsuCode, inOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#End Region

#Region "2016/04/19 醫療支付公用主檔 (醫令控制畫面) , Added by Kaiwen"

    'Public Function initPUBOrderUIInfo() As DataSet Implements IPubPartialService.initPUBOrderUIInfo
    '    Try
    '        Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
    '        Return pubDlg.initPUBOrderUIInfo()
    '    Catch ex As Exception
    '        nckuh.server.cmm.ServerExceptionHandler.ProccessException(ex)
    '    End Try
    'End Function

    Public Function initPUBOrderInfo(ByVal initType As String) As DataSet Implements IPubService.initPUBOrderInfo
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.initPUBOrderInfo(initType)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet Implements IPubService.queryOrderData

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryOrderData(OrderCode, EffectDate)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function checkProcessStatus(ByVal OldOrderDT As DataTable, ByVal NewOrderDT As DataTable) As DataSet Implements IPubService.checkProcessStatus
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.checkProcessStatus(OldOrderDT, NewOrderDT)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function commitOrderRelatedData(ByVal OrderRelatedData As DataSet) As Integer Implements IPubService.commitOrderRelatedData
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.commitOrderRelatedData(OrderRelatedData)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataSet Implements IPubService.queryPreOrNextRecordOrder
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPreOrNextRecordOrder(partialOrderCode, orderTypeId, isPre)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataSet Implements IPubService.queryPreOrNextRecordOrder2
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2016/04/19 舊程式OPHPB_BS , Added by Kaiwen"

#Region "2016/04/19 由Order_Code查詢藥品碼資料(舊程式OPHPB_queryPharmacyBaseByOrderCode(OrderCode)), Added by Kaiwen"

    Public Function queryPharmacyBaseByOrderCode(ByVal OrderCode As String) As DataTable Implements IPubService.queryPharmacyBaseByOrderCode

        Try
            Return PUBDelegate.getInstance.queryPharmacyBaseByOrderCode(OrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/04/19  依醫令刪除所有相關表格資料 Log ,add by Kaiwen "
    ''' <summary>
    ''' 依醫令刪除所有相關表格資料 Log
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <param name="inOrderName"></param>
    ''' <param name="inOrderTypeId"></param>
    ''' <param name="inOrderMode"></param>
    ''' <param name="inExecutionUser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePUBOrderLog(ByVal inOrderCode As String, ByVal inOrderName As String, ByVal inOrderTypeId As String, ByVal inOrderMode As String, ByVal inExecutionUser As String) As Integer Implements IPubService.deletePUBOrderLog
        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.deletePUBOrderLog(inOrderCode, inOrderName, inOrderTypeId, inOrderMode, inExecutionUser)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function deletePUBOrderByOrderCode(ByVal inOrderCode As String) As Integer Implements IPubService.deletePUBOrderByOrderCode

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
            Return pubDlg.deletePUBOrderByOrderCode(inOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#End Region

#Region "2016/04/19  PUBAddQueryUI ,add by Kaiwen"

    ' "2011/09/07 Add By Immy 兒童加成查詢"
    Public Function QueryAdd(ByVal Order_Code As String) As DataTable Implements IPubService.QueryAdd
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.QueryAdd(Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    ' "2011/09/07 Add By Immy 急件加成查詢"
    Public Function QueryAdd_EMG(ByVal Order_Code As String) As DataTable Implements IPubService.QueryAdd_EMG
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.QueryAdd_EMG(Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    ' "2011/09/07 Add By Immy 牙科轉診加成查詢"
    Public Function QueryAddd_Dental(ByVal Order_Code As String) As DataTable Implements IPubService.QueryAdd_Dental
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.QueryAdd_Dental(Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    ' "2011/09/07 Add By Immy 科別加成查詢"
    Public Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable Implements IPubService.QueryAdd_Dept
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.QueryAdd_Dept(Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#End Region

#Region "2016/04/19 PUBInsuCodeBO , Added by Kaiwen"

#Region " 查詢資料"

    Public Function queryPubInsuCodeEffectData(ByVal inEffectDate As String, ByVal inOrderTypeId As String, ByVal inOrderCode As String) As DataTable Implements IPubService.queryPubInsuCodeEffectData

        Try
            Return PUBDelegate.getInstance.queryPubInsuCodeEffectData(inEffectDate, inOrderTypeId, inOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#End Region

#Region "2016/04/22   取得群組醫令, Added by Kaiwen "

    Public Function queryAddOrderData(ByVal AddOrderCode As String) As DataTable Implements IPubService.queryAddOrderData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryAddOrderData(AddOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryAddOrderDetailData(ByVal AddOrderCode As String) As DataTable Implements IPubService.queryAddOrderDetailData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryAddOrderDetailData(AddOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryAddOptionOrderData(ByVal AddOrderCode As String, ByVal AddOrderDetailNo As Integer) As DataTable Implements IPubService.queryAddOptionOrderData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryAddOptionOrderData(AddOrderCode, AddOrderDetailNo)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#Region "2016/05/10 更新群組醫令維護檔 By Will"
    ''' <summary>
    ''' InsertTo AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAddOrder(ByVal ds As DataSet) As Integer Implements IPubService.UpdateAddOrder
        Try
            Return PUBDelegate.getInstance.UpdateAddOrder(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Delete AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="addOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteAddOrder(ByVal addOrderCode As String) As Integer Implements IPubService.deleteAddOrder
        Try
            Return PUBDelegate.getInstance.deleteAddOrder(addOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region
#End Region

#Region "2016/04/25 檢驗表單維護 PubLisSheet by Kaiwen"

    Public Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32 Implements IPubService.PubLisSheetInsert
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.PubLisSheetInsert(InputData)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function PubLisSheetUpdate(ByVal UpdateData As DataSet) As Int32 Implements IPubService.PubLisSheetUpdate
        Try
            Return PUBDelegate.getInstance.PubLisSheetUpdate(UpdateData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function PubLisSheetDelete(ByVal SheetCode As String) As Int32 Implements IPubService.PubLisSheetDelete
        Try
            Return PUBDelegate.getInstance.PubLisSheetDelete(SheetCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function PubLisSheetQuery(ByVal SheetCode As String, _
                                     ByVal SheetName As String, _
                                     ByVal DeptCode As String, _
                                     ByVal SheetContactTel As String) As DataSet Implements IPubService.PubLisSheetQuery
        Try
            Return PUBDelegate.getInstance.PubLisSheetQuery(SheetCode, _
                                                            SheetName, _
                                                            DeptCode, SheetContactTel)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


#Region "     以ＰＫ查詢資料 "
    Public Function PubSheetQueryByPK(ByVal pk_Sheet_Code As String, ByVal pk_Sheet_Name As System.String, ByVal pk_Dept_Code As System.String) As DataSet Implements IPubService.PubSheetQueryByPK
        Try
            Return PUBDelegate.getInstance.PubSheetQueryByPK(pk_Sheet_Code, pk_Sheet_Name, pk_Dept_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#Region "     以ＰＫ Like 的方式查詢資料 "
    Public Function PubSheetQueryByLikePK(ByVal pk_Sheet_Code As String) As DataSet Implements IPubService.PubSheetQueryByLikePK
        Try
            Return PUBDelegate.getInstance.PubSheetQueryByLikePK(pk_Sheet_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#End Region

#Region "2016/04/25  PubDepartment by Kaiwen"
    ''' <summary>
    ''' 依來源別(O,E,I)取得小分科
    ''' </summary>
    ''' <param name="inSourceType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentBySourceType(ByVal inSourceType As String) As DataSet Implements IPubService.queryPUBDepartmentBySourceType
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBDepartmentBySourceType(inSourceType)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function queryPUBDepartmentAllDept() As DataSet Implements IPubService.queryPUBDepartmentAllDept
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryPUBDepartmentAllDept()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "2016/04/26  PUBExaminationSheetDetailMaintainBS 檢驗醫令明細維護, Added by Kaiwen"

    Public Function PUBExaminationSheetDetailMaintainGetInitInfo(ByVal User As String) As DataSet Implements IPubService.PUBExaminationSheetDetailMaintainGetInitInfo
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainGetInitInfo(User)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainGetOrderList(ByVal SheetCode As String) As DataSet Implements IPubService.PUBExaminationSheetDetailMaintainGetOrderList
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainGetOrderList(SheetCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function PUBExaminationSheetDetailMaintainGetOrderInfo(ByVal OrderCode As String) As DataSet Implements IPubService.PUBExaminationSheetDetailMaintainGetOrderInfo
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainGetOrderInfo(OrderCode)


        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainWriteBackEditedInfo(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubService.PUBExaminationSheetDetailMaintainWriteBackEditedInfo
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainWriteBackEditedInfo(InputData, User)


        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainQuerySheetDetail(ByVal SheetCode As String, ByVal OrderCode As String) As DataSet Implements IPubService.PUBExaminationSheetDetailMaintainQuerySheetDetail
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainQuerySheetDetail(SheetCode, OrderCode)


        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(ByVal InputData As DataSet) As Int32 Implements IPubService.PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(InputData)


        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubService.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail
        Try
            Return PUBDelegate.getInstance.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(InputData, User)


        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/04/26  檢查表單維護, Added by Kaiwen"

    Public Function initSheetData() As DataSet Implements IPubService.initSheetData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.initSheetData

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function querySheetDetailData(ByVal SheetCode As String) As DataTable Implements IPubService.querySheetDetailData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.querySheetDetailData(SheetCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function confirmSheetData(ByVal sheetDS As DataSet) As Boolean Implements IPubService.confirmSheetData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.confirmSheetData(sheetDS)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable Implements IPubService.queryLikeOrderData
        Try
            Dim instance As PUBDelegate = PUBDelegate.getInstance
            Return instance.queryLikeOrderData(LikeOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2016/04/28 PUBRisFormMaintainSheetDetailUI, Added by Kaiwen"

    Public Function InsertIntoPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubService.InsertIntoPubSheetDetailAndPubOrderExamination
        Try
            Return PUBDelegate.getInstance.InsertIntoPubSheetDetailAndPubOrderExamination(InputData, User)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function DeleteFromPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubService.DeleteFromPubSheetDetailAndPubOrderExamination
        Try
            Return PUBDelegate.getInstance.DeleteFromPubSheetDetailAndPubOrderExamination(InputData, User)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function PUBRisFormMaintainGetAvalibleSheet(ByVal User As String) As DataSet Implements IPubService.PUBRisFormMaintainGetAvalibleSheet
        Try
            Return PUBDelegate.getInstance.PUBRisFormMaintainGetAvalibleSheet(User)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2016/04/28 PUBSheetDisplayUI 表單開單顯示檔維護"

#Region " 新增"
    ''' <summary>
    ''' 表單開單顯示檔維護_新增
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SheetDisplayInsert(ByVal ds As DataSet) As Integer Implements IPubService.PUBSheetDisplayInsert

        Try
            Return PUBDelegate.getInstance.PUBSheetDisplayInsert(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region " 修改"
    ''' <summary>
    ''' 表單開單顯示檔維護_修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function SheetDisplayUpdate(ByVal ds As DataSet) As Integer Implements IPubService.PUBSheetDisplayUpdate

        Try

            Return PUBDelegate.getInstance.PUBSheetDisplayUpdate(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region " 刪除"
    ''' <summary>
    '''表單開單顯示檔維護_以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SheetDisplayDelete(ByRef pk_Sheet_Type_Id As System.String, ByRef pk_Sheet_Main_Display As System.String, ByRef pk_Sheet_Sub_Display As System.String) As Integer Implements IPubService.PUBSheetDisplayDelete


        Try

            Return PUBDelegate.getInstance.PUBSheetDisplayDelete(pk_Sheet_Type_Id, pk_Sheet_Main_Display, pk_Sheet_Sub_Display)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try
    End Function

#End Region

#Region " 查詢"
    '' <summary>
    ' 表單開單顯示檔維護_查詢
    '' </summary>
    '' <returns>Integer</returns>
    '' <remarks></remarks>
    Public Function SheetDisplayQuery(ByVal Sheet_Type_Id As String, ByVal Sheet_Main_Display As String, ByVal Sheet_Sub_Display As String) As System.Data.DataSet Implements IPubService.QueryPubSheetDisplayByCond
        Try
            Return PUBDelegate.getInstance.QueryPubSheetDisplayByCond(Sheet_Type_Id, Sheet_Main_Display, Sheet_Sub_Display)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try

    End Function

#End Region

#End Region

#Region "2016/05/20 表單開單顯示醫令檔檔基本資料維護 added by Roger "

#Region " 新增"
    ''' <summary>
    ''' 表單開單顯示檔維護_新增
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SheetDisplayOrderInsert(ByVal ds As DataSet) As Integer Implements IPubService.PUBSheetDisplayOrderInsert

        Try
            Return PUBDelegate.getInstance.PUBSheetDisplayOrderInsert(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region " 修改"
    ''' <summary>
    ''' 表單開單顯示檔維護_修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function SheetDisplayOrderUpdate(ByVal ds As DataSet) As Integer Implements IPubService.PUBSheetDisplayOrderUpdate

        Try

            Return PUBDelegate.getInstance.PUBSheetDisplayOrderUpdate(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region " 刪除"
    ''' <summary>
    '''表單開單顯示檔維護_以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SheetDisplayOrderDelete(ByRef pk_Sheet_Sub_Display As System.String, ByRef pk_Order_Display_Code As System.String) As Integer Implements IPubService.PUBSheetDisplayOrderDelete


        Try

            Return PUBDelegate.getInstance.PUBSheetDisplayOrderDelete(pk_Sheet_Sub_Display, pk_Order_Display_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try
    End Function
#End Region

#Region " 查詢"
    '' <summary>
    '' 表單開單顯示檔維護_查詢
    '' </summary>
    '' <returns>Integer</returns>
    '' <remarks></remarks>
    Public Function SheetDisplayOrderQuery(ByVal Sheet_Sub_Display As String, ByVal Order_Code As String, ByVal Order_Display_Code As String, ByVal Order_Display_Name As String) As System.Data.DataSet Implements IPubService.QueryPubSheetDisplayOrderByCond
        Try
            Return PUBDelegate.getInstance.QueryPubSheetDisplayOrderByCond(Sheet_Sub_Display, Order_Code, Order_Display_Code, Order_Display_Name)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try

    End Function
#End Region

#Region "取得ComboBox資料"
    '' <summary>
    '' 表單開單顯示醫令檔維護_取得ComboBox資料
    '' </summary>
    '' <returns>datatable</returns>
    '' <remarks></remarks>
    Public Function QueryPubSheetDisplayOrderCombodata(ByVal MainBodySite As String) As DataSet Implements IPubService.QueryPubSheetDisplayOrderCombodata
        Try
            Return PUBDelegate.getInstance.QueryPubSheetDisplayOrderCombodata(MainBodySite)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try
    End Function
#End Region

#Region "查詢全部"
    Public Function SheetDisplayOrderQueryAll() As System.Data.DataSet Implements IPubService.QuerySheetDisplayOrderAll
        Try
            Return PUBDelegate.getInstance.QuerySheetDisplayOrderAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try

    End Function
#End Region

#Region "          是否重複資料查詢"
    Public Function QuerySheetDisplayOrderCheckDS(ByVal strOrderCode As String, ByVal strMainBodySite As String, ByVal strBodySite As String, ByVal strSiteID As String) As System.Data.DataSet Implements IPubService.QuerySheetDisplayOrderCheckDS
        Try
            Return PUBDelegate.getInstance.QuerySheetDisplayOrderCheckDS(strOrderCode, strMainBodySite, strBodySite, strSiteID)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try
    End Function
#End Region
#End Region

#Region "2016/05/17  郵遞區號設定維護, added by Roger"

#Region " 新增"
    ''' <summary>
    ''' 郵遞區號設定維護新增
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PostalCodeInsert(ByVal ds As DataSet) As Integer Implements IPubService.PUBPostalCodeInsert

        Try
            Return PUBDelegate.getInstance.PUBPostalCodeInsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region " 修改"
    ''' <summary>
    ''' 郵遞區號設定維護修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-01-22</remarks>
    Public Function PostalCodeupdate(ByVal ds As DataSet) As Integer Implements IPubService.PUBPostalCodeupdate

        Try

            Return PUBDelegate.getInstance.PUBPostalCodeupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#Region " 刪除"

    ''' <summary>
    '''郵遞區號設定維護以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PostalCodedelete(ByVal Postal_Code As String) As Integer Implements IPubService.PUBPostalCodedelete


        Try

            Return PUBDelegate.getInstance.PUBPostalCodedelete(Postal_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function


#End Region

#Region " 查詢"
    ''' <summary>
    ''' 郵遞區號設定維護查詢
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks></remarks>

    Public Function PostalCodequery(ByVal Postal_Code As String, ByVal Postal_Name As String, ByVal County_Name As String, ByVal Town_Name As String) As System.Data.DataSet Implements IPubService.PUBPostalCodequery

        Try
            Return PUBDelegate.getInstance.PUBPostalCodequery(Postal_Code, Postal_Name, County_Name, Town_Name)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function




#End Region
#End Region

#Region "2016/05/20 病患DNR記錄檔(PUB_Patient_DNR) by Eddie,Lu"

#Region "     新增With DNR流水號 "
    ''' <summary>
    ''' 新增With DNR流水號
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRinsertWithDNRNo(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientDNRinsertWithDNRNo

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientDNRinsertWithDNRNo(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryByPKROC(ByRef pk_Chart_No As System.String, ByRef strDNRKindId As System.String) As System.Data.DataSet Implements IPubService.PUBPatientDNRqueryByPKROC

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientDNRqueryByPKROC(pk_Chart_No, strDNRKindId)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRdelete(ByRef pk_Chart_No As System.String, ByRef pk_Source_Kind As System.String, ByRef pk_DNR_No As System.Int32) As Integer Implements IPubService.PUBPatientDNRdelete

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientDNRdelete(pk_Chart_No, pk_Source_Kind, pk_DNR_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryCboDs() As DataSet Implements IPubService.PUBPatientDNRqueryCboDs

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientDNRqueryCboDs()

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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatientDNRupdate

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatientDNRupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/05/20 病患特殊註記顯示排序檔(PUB_Pat_Flag_Sort) by Eddie,Lu"

#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortdelete(ByRef pk_Flag_Id As System.String) As Integer Implements IPubService.PUBPatFlagSortdelete

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatFlagSortdelete(pk_Flag_Id)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryByPKROC(ByRef pk_Flag_Id As System.String, ByRef strFlagSortId As System.String) As System.Data.DataSet Implements IPubService.PUBPatFlagSortqueryByPKROC

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatFlagSortqueryByPKROC(pk_Flag_Id, strFlagSortId)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryCboDs() As DataSet Implements IPubService.PUBPatFlagSortqueryCboDs

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatFlagSortqueryCboDs()

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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatFlagSortinsert

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatFlagSortinsert(ds)

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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBPatFlagSortupdate

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBPatFlagSortupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "預防保健執行設定維護 BY Roger "

#Region "新增"
    Public Function insertPUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.insertPUBPreventiveCareExe

        Try
            Return PUBDelegate.getInstance.insertPUBPreventiveCareExe(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try
    End Function
#End Region

#Region "修改"
    Public Function updatePUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.updatePUBPreventiveCareExe

        Try
            Return PUBDelegate.getInstance.updatePUBPreventiveCareExe(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try
    End Function
#End Region

#Region "刪除"
    Public Function deletePUBPreventiveCareExe(ByRef CareOrderCode As System.String, ByRef PreCareOrderCode As System.String) As Integer Implements IPubService.deletePUBPreventiveCareExe

        Try
            Return PUBDelegate.getInstance.deletePUBPreventiveCareExe(CareOrderCode, PreCareOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try
    End Function
#End Region

#Region "查詢"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>by Roger</remarks>
    Public Function queryPUBPreventiveCareExeByCond(ByVal PreCareOrderCode As String, ByVal CareOrderCode As String, ByVal AgeControlId As String) As System.Data.DataSet Implements IPubService.queryPUBPreventiveCareExeByCond
        Try
            Return PUBDelegate.getInstance.queryPUBPreventiveCareExeByCond(PreCareOrderCode, CareOrderCode, AgeControlId)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing

        End Try
    End Function

#End Region

#Region "取得Combobox資料"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>by Roger</remarks>
    Public Function getPUBPreventiveCareExeCombodata() As DataSet Implements IPubService.getPUBPreventiveCareExeCombodata
        Try
            Return PUBDelegate.getInstance.getPUBPreventiveCareExeCombodata()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#End Region

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱)  By Li.Han"
    ''' <summary>
    ''' 取得中文名稱
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBRulequeryRuleNameByCode(ByVal strSQL As String) As String Implements IPubService.PUBRulequeryRuleNameByCode
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBRulequeryRuleNameByCode(strSQL)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/06/07 查詢透析院所代號 (For KLH 用) by ChenYu.Guo"
    ''' <summary>
    ''' 查詢透析院所代號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubHospitalqueryByNow() As System.Data.DataSet Implements IPubService.PubHospitalqueryByNow
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubHospitalqueryByNow()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

    '#Region "2016/06/07 以病歷號查詢關聯表的資料 (For KLH 用) by ChenYu.Guo"

    '    ''' <summary>
    '    ''' 以病歷號查詢關聯表的資料
    '    ''' </summary>
    '    ''' <returns>System.Data.DataSet</returns>
    '    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    '    Public Function PubPatientqueryRelationInfoByPK(ByRef pk_Chart_No As System.String, ByRef pk_Pip_Type As System.String) As System.Data.DataSet Implements IPubService.PubPatientqueryRelationInfoByPK
    '        Try

    '            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

    '            Return tempDelegate.PubPatientqueryRelationInfoByPK(pk_Chart_No, pk_Pip_Type)

    '        Catch cmex As CommonException
    '            Throw ServerExceptionHandler.ProccessException(cmex)
    '        Catch ex As Exception
    '            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
    '            Return Nothing
    '        End Try

    '    End Function
    '#End Region

#Region "2016/06/07 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubPatientBodyrecordQueryByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubService.PubPatientBodyrecordQueryByChartNo
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientBodyrecordQueryByChartNo(pk_Chart_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/06/10 add by Lits Pub_IP_Config 維護"
    Public Function insertPubIPConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.insertPubIPConfig
        Try
            Dim _Ip As PUBDelegate = PUBDelegate.getInstance
            Return _Ip.insertPubIPConfig(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function updatePubIPConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.updatePubIPConfig
        Try
            Dim _Ip As PUBDelegate = PUBDelegate.getInstance
            Return _Ip.updatePubIPConfig(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function deletePubIPConfig(ByVal ip As System.String) As Integer Implements IPubService.deletePubIPConfig
        Try
            Dim _Ip As PUBDelegate = PUBDelegate.getInstance
            Return _Ip.deletePubIPConfig(ip)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function queryPubIPConfig(ByVal ip As System.String) As DataSet Implements IPubService.queryPubIPConfig
        Try
            Dim _Ip As PUBDelegate = PUBDelegate.getInstance
            Return _Ip.queryPubIPConfig(ip)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    Public Function queryStationByIP(ByVal ip As String) As DataSet Implements IPubService.queryStationByIP
        Try
            Dim _ip As PUBDelegate = PUBDelegate.getInstance
            Return _ip.queryStationByIP(ip)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
#End Region

#Region "2016/06/13 以 Type_Id 查詢資料 by Gary.Chiang"
    ''' <summary>
    ''' 以 Type_Id 查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Kira on 2016-06-13</remarks>
    Public Function PubSyscodeQueryByTypeId(ByRef pk_Type_Id As System.Int32) As System.Data.DataSet Implements IPubService.PubSyscodeQueryByTypeId
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubSyscodeQueryByTypeId(pk_Type_Id)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region
#Region "2016/06/13 以 Type_Id 查詢資料 by Gary.Chiang"

    ''' <summary>
    '''通過Chart_No查詢PUB_Patient_Allergy的資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Kira on 2016/06/12</remarks>
    Public Function PubPatientAllergyqueryTopByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubService.PubPatientAllergyqueryTopByChartNo
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatientAllergyqueryTopByChartNo(pk_Chart_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/06/17 寫入ISS_Item By Will"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Public Function PubIssItemInsert(ByRef ds As DataSet) As Integer Implements IPubService.PubIssItemInsert
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubIssItemInsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Public Function PubIssItemUpdate(ByRef ds As DataSet) As Integer Implements IPubService.PubIssItemUpdate
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubIssItemupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Public Function PubIssItemQueryAll() As DataSet Implements IPubService.PubIssItemQueryAll
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubIssItemQueryAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 查詢最近一筆評分資料
    ''' </summary>
    ''' <param name="pk_Chart_No"></param>
    ''' <param name="pk_Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBPatientISSBOqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Medical_Sn As System.String) As DataSet Implements IPubService.PUBPatientISSBOqueryByPK
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBPatientISSBOqueryByPK(pk_Chart_No, pk_Medical_Sn)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Medical_Sn"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-01-17</remarks>
    Public Function PubPatientIssDelete(ByVal Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer Implements IPubService.PubPatientIssDelete

        Dim m_PUBPatientISSBO_E1 As PUBPatientISSBO_E1 = New PUBPatientISSBO_E1
        Try

            Return m_PUBPatientISSBO_E1.PubPatientIssDelete(Medical_Sn, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除PUBPatientIss的資料"})

        End Try

    End Function

#End Region
#End Region
#Region "20160623 入院護理評估的身高體重塞入PUB_Patient_BodyRecord"
    ''' <summary>
    ''' 入院護理評估的身高體重塞入PUB_Patient_BodyRecord
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kasim on 20160623</remarks>
    Public Function PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PubPatient_BodyRecordUpdateHBbyChartNoForMohw
        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/06/29 住院護理站基本檔維護(Pub_Station) by Hanru"

#Region "     新增護理站基本檔資料 "
    ''' <summary>
    ''' 新增護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function insertPubStation(ByVal ds As DataSet) As Integer Implements IPubService.insertPubStation

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.insertPubStation(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     修改護理站基本檔資料 "
    ''' <summary>
    ''' 修改護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function updatePubStation(ByVal ds As DataSet) As Integer Implements IPubService.updatePubStation

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.updatePubStation(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     刪除護理站基本檔資料 "
    ''' <summary>
    ''' 刪除護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function deletePubStation(ByRef pk_Station_No As String) As Integer Implements IPubService.deletePubStation

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.deletePubStation(pk_Station_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     查詢護理站基本檔資料 "
    ''' <summary>
    ''' 查詢護理站基本檔資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function queryPubStationByCond(ByVal pk_Station_No As String) As DataSet Implements IPubService.queryPubStationByCond

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubStationByCond(pk_Station_No)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2016/06/30 檢查醫令不須報到部門維護作業(PUB_Order_Exam_Nocheckin_DeptBO) by Jun"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBOrderExamNocheckinDeptinsert

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderExamNocheckinDeptinsert(ds)

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
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptdelete(ByRef pk_Order_Code As System.String) As Integer Implements IPubService.PUBOrderExamNocheckinDeptdelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderExamNocheckinDeptdelete(pk_Order_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     取得門急住個別的不需報到科別 "
    ''' <summary>
    ''' 取得門急住個別的不需報到科別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function getInitialOrderExamNoCheckinDept(ByVal orderCode As String) As System.Data.DataSet Implements IPubService.getInitialOrderExamNoCheckinDept

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.getInitialOrderExamNoCheckinDept(orderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2016/07/13 科室主管檔 add by kudy.sue"
    Function queryPubDeptLeaderByCond(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As System.Data.DataSet Implements IPubService.queryPubDeptLeaderByCond
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPubDeptLeaderByCond(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '新增
    Function insertPubDeptLeader(ByVal dsData As DataSet) As Integer Implements IPubService.insertPubDeptLeader
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.insertPubDeptLeader(dsData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
    '修改
    Function updatePubDeptLeader(ByVal dsData As DataSet) As Integer Implements IPubService.updatePubDeptLeader
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.updatePubDeptLeader(dsData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    '刪除
    Function deletePubDeptLeader(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As Integer Implements IPubService.deletePubDeptLeader
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.deletePubDeptLeader(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "2016/07/15 特殊屬性輸入元件(PUBLabIndication04) by Margaret.Tsai"

#Region "     特殊屬性輸入元件 "
    ''' <summary>
    ''' 特殊屬性輸入元件
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Margaret.Tsai on 2016-07-15</remarks>
    Public Function PUBLabIndication04QureyPUBLabIndication04() As DataSet Implements IPubService.PUBLabIndication04QureyPUBLabIndication04

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBLabIndication04QureyPUBLabIndication04()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    Public Function PUBLabIndication10QureyPUBLabIndication10(ByVal inIDNO As String, ByVal inOrderDate As String) As DataSet Implements IPubService.PUBLabIndication10QureyPUBLabIndication10

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBLabIndication10QureyPUBLabIndication10(inIDNO, inOrderDate)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2009/12/10, Add By Alan, 寫入IC卡重大傷病與藥物過敏資料"
    '' 程式說明：寫入IC卡重大傷病與藥物過敏資料
    '' 開發人員：Alan
    '' 開發日期：2009.12.10
    '' </summary>
    Public Function InsertPatientData(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet) As Integer Implements IPubService.InsertPatientData

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance

            Return pubDlg.InsertPatientData(ChartNo, UserId, CriticalIllness, Allergic)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertPatientData2(ByVal ChartNo As String, ByVal UserId As String, _
                                  ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet, ByVal Prevent As DataSet) As Integer Implements IPubService.InsertPatientData2

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance

            Return pubDlg.InsertPatientData2(ChartNo, UserId, CriticalIllness, Allergic, Prevent)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


#Region "2016/08/23 更新病人聯絡資料 Will"
    ''' <summary>
    '''更新病人聯絡資料
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePatContactInfo(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.updatePatContactInfo

        Try
            Dim pubDlg As PUBDelegate = PUBDelegate.getInstance

            Return pubDlg.updatePatContactInfo(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/08/25 成本中心設定維護(PUB_Acc_Dept) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBAccDeptinsert

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBAccDeptinsert(ds)

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
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBAccDeptupdate

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBAccDeptupdate(ds)

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
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function QueryPubAccDeptByPK(ByVal tmp As String) As System.Data.DataSet Implements IPubService.QueryPubAccDeptByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryPubAccDeptByPK(tmp)

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
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptDelete(ByVal PK As String) As Integer Implements IPubService.PUBAccDeptDelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBAccDeptDelete(PK)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region


#Region "2016/09/19 成本中心部門 查詢 by 林承毅"
    ''' <summary>
    ''' 成本中心部門 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by 林承毅 on 2016/09/19</remarks>
    Public Function QueryPubAccDeptName(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet Implements IPubService.QueryPubAccDeptName

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryPubAccDeptName(conn)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#Region " 2016/10/14 檢核規則維護(PubRuleReason) By Kaiwen "

#Region "     以ＰＫ查詢資料 "
    Public Function queryRuleReasonByRuleCode(ByVal pk_Rule_Code As System.String) As DataSet Implements IPubService.queryRuleReasonByRuleCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryRuleReasonByRuleCode(pk_Rule_Code)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2016/09/19 轉入健保醫令價格異動檔(PUBNhiCodeImportBO_E1) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1ImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer Implements IPubService.PUBNhiCodeImportBOE1ImportCase

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportBOE1ImportCase(ds, strDownload_Sn, strUserId)

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
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1importorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer Implements IPubService.PUBNhiCodeImportBOE1importorderprice

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportBOE1importorderprice(ds, struser)

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
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1query(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet Implements IPubService.PUBNhiCodeImportBOE1query

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportBOE1query(strNhi_Download_Sn, strInsu_Code, strEffect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2016/10/01 尋找停用醫令替代項目 By Will Lin"

#Region "     尋找停用醫令替代項目 "
    ''' <summary>
    ''' 尋找停用醫令替代項目
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Public Function queryOrderAlternativeForOEIOtherLack(ByVal OrderCode As String) As DataSet Implements IPubService.queryOrderAlternativeForOEIOtherLack

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryOrderAlternativeForOEIOtherLack(OrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 查詢被DC的醫令
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Public Function queryPUBOrderDC(ByVal inOrderCode As String) As DataSet Implements IPubService.queryPUBOrderDC

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPUBOrderDC(inOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

    ''' <summary>
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingPUBSheet(ByVal currentUser As String) As DataSet Implements IPubService.queryUserMappingPUBSheet

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryUserMappingPUBSheet(currentUser)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' 查詢登入使用者可用的表單對應儀器
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingApparatusCode(ByVal currentUser As String) As DataSet Implements IPubService.queryUserMappingApparatusCode

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryUserMappingApparatusCode(currentUser)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#Region "2013/04/30, Add By Alan, 自費衛材核定記錄維護"

    Public Function insertPUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer Implements IPubService.insertPUBMaterialSelfpayApply
        Try
            Return PUBDelegate.getInstance.insertPUBMaterialSelfpayApply(dsSaveData)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function updatePUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer Implements IPubService.updatePUBMaterialSelfpayApply
        Try
            Return PUBDelegate.getInstance.updatePUBMaterialSelfpayApply(dsSaveData)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function deletePUBMaterialSelfpayApply(ByVal OrderCode As String, ByVal EffectDate As Date) As Integer Implements IPubService.deletePUBMaterialSelfpayApply
        Try
            Return PUBDelegate.getInstance.deletePUBMaterialSelfpayApply(OrderCode, EffectDate)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Function queryPUBMaterialSelfpayApply(ByVal sqlString As String) As DataSet Implements IPubService.queryPUBMaterialSelfpayApply
        Try
            Return PUBDelegate.getInstance.queryPUBMaterialSelfpayApply(sqlString)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


#End Region

#Region " 2016/10/21 取得醫院資料 By Chi,Wang "
    ''' <summary>
    ''' 取得醫院資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by  Chi,Wang 2016/10/20 </remarks>
    Public Function queryHospitalInfo(ByVal HospitalCode As String, ByVal LanguageTypeId As String, ByVal EffectDate As Date) As DataSet Implements IPubService.queryHospitalInfo

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryHospitalInfo(HospitalCode, LanguageTypeId, EffectDate)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function
#End Region

#Region "20101217 add by Rich, 事前審查適應症查詢"

    Public Function queryPUBOrderByOrderCode(ByVal Order_Code As String) As System.Data.DataSet Implements IPubService.queryPUBOrderByOrderCode
        Try
            Dim oper As PUBDelegate = PUBDelegate.getInstance
            Return oper.queryPUBOrderByOrderCode(Order_Code)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region "PUBZoneRoomBO_E1  區診間維護檔"
    Public Function queryPUBZoneRoomByCond(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet Implements IPubService.queryPUBZoneRoomByCond
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.queryPUBZoneRoomByCond(strZoneId, strRoomCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function insertPUBZoneRoom(ByVal dsSaveData As DataSet) As Integer Implements IPubService.insertPUBZoneRoom
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.insertPUBZoneRoom(dsSaveData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function updatePUBZoneRoom(ByVal dsSaveData As DataSet) As Integer Implements IPubService.updatePUBZoneRoom
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.updatePUBZoneRoom(dsSaveData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

    Public Function deletePUBZoneRoomByPK(ByVal strZoneId As String, ByVal strRoomCode As String) As Integer Implements IPubService.deletePUBZoneRoomByPK
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.deletePUBZoneRoomByPK(strZoneId, strRoomCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2016/12/15 自費衛材核定記錄維護(PUBMaterialSelfpayApply) by Hsiao,Kaiwen"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBMaterialSelfpayApplyinsert

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBMaterialSelfpayApplyinsert(ds)

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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBMaterialSelfpayApplyupdate

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBMaterialSelfpayApplyupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyDelete(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As Integer Implements IPubService.PUBMaterialSelfpayApplyDelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBMaterialSelfpayApplyDelete(pk_Order_Code, pk_Effect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以ＰＫ Like 查詢資料 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function queryPubMaterialSelfpayApplyByPKLike(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet Implements IPubService.queryPubMaterialSelfpayApplyByPKLike

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubMaterialSelfpayApplyByPKLike(pk_Order_Code, pk_Effect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function queryPubMaterialSelfpayApplyByPK(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet Implements IPubService.queryPubMaterialSelfpayApplyByPK

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.queryPubMaterialSelfpayApplyByPK(pk_Order_Code, pk_Effect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2017/02/23 轉入健保醫令價格異動檔衛材(PUBNhiCodeImportMBO_E1) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function PUBNhiCodeImportMImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer Implements IPubService.PUBNhiCodeImportMImportCase

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportMImportCase(ds, strDownload_Sn, strUserId)

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
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function PUBNhiCodeImportMimportorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer Implements IPubService.PUBNhiCodeImportMimportorderprice

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportMimportorderprice(ds, struser)

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
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function PUBNhiCodeImportMquery(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet Implements IPubService.PUBNhiCodeImportMquery

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBNhiCodeImportMquery(strNhi_Download_Sn, strInsu_Code, strEffect_Date)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2017/03/21 病患傳送風險(PUBPatientTransferRiskUI) by Will,Lin"


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function InsertIntoPUBPatientTransferRisk(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.InsertIntoPUBPatientTransferRisk

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.InsertIntoPUBPatientTransferRisk(ds)

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
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function QueryPUBPatientTransferRiskLevel(ByVal strChartNo As String, ByVal strOutpatientSn As String) As String Implements IPubService.QueryPUBPatientTransferRiskLevel

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryPUBPatientTransferRiskLevel(strChartNo, strOutpatientSn)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "查詢醫令是否已存在(PUB_Sheet_Detail)"
    Public Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet Implements IPubService.queryPubSheetDetailByOrderCode
        Try
            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance
            Return tempDelegate.queryPubSheetDetailByOrderCode(OrderCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#Region "2017/04/06 看診目的排序設定(Pub_Medical_Type_Sort) by Chi,Wang"


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function InsertPubMedicalTypeSort(ByVal stremployeecode As String) As Integer Implements IPubService.InsertPubMedicalTypeSort

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.InsertPubMedicalTypeSort(stremployeecode)

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
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function QueryPubMedicalTypeSort(ByVal stremployeecode As String) As DataSet Implements IPubService.QueryPubMedicalTypeSort

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.QueryPubMedicalTypeSort(stremployeecode)

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
    ''' 刪除
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function DeletePubMedicalTypeSort(ByVal stremployeecode As String) As Integer Implements IPubService.DeletePubMedicalTypeSort

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.DeletePubMedicalTypeSort(stremployeecode)

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
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function UpdatePubMedicalTypeSort(ByVal ds As DataSet, ByVal stremployeecode As String) As Integer Implements IPubService.UpdatePubMedicalTypeSort

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.UpdatePubMedicalTypeSort(ds, stremployeecode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region

#End Region

#Region "2017/04/13 檢查醫令不須列印部門維護作業(PUB_Order_Exam_NoPrint_Dept) by Michelle"

#Region "     取得門急住個別的不需列印科別 "
    ''' <summary>
    ''' 取得門急住個別的不需列印科別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function getInitialOrderExamNoPrintDept(ByVal orderCode As String) As DataSet Implements IPubService.getInitialOrderExamNoPrintDept

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.getInitialOrderExamNoPrintDept(orderCode)

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
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptdelete(ByRef pk_Order_Code As System.String) As Integer Implements IPubService.PUBOrderExamNoPrintDeptdelete

        Try

            Dim tempDelegate As PUBDelegate = PUBDelegate.getInstance

            Return tempDelegate.PUBOrderExamNoPrintDeptdelete(pk_Order_Code)

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
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubService.PUBOrderExamNoPrintDeptinsert

        Try

            Dim tempDelegate As PubDelegate = PubDelegate.getInstance

            Return tempDelegate.PUBOrderExamNoPrintDeptinsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try

    End Function

#End Region


#End Region

#Region "2017/04/14 PubDrAddControlUI 特定醫師加成控制檔維護 by Hsu-Yuan,Yang"

#Region " 新增"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlInsert(ByVal ds As DataSet) As Integer Implements IPubService.PubDrAddControlInsert

        Try
            Return PUBDelegate.getInstance.PubDrAddControlInsert(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region " 修改"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_修改
    ''' </summary>
    ''' <param name="ds">更新資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlUpdate(ByVal ds As DataSet) As Integer Implements IPubService.PubDrAddControlUpdate

        Try
            Return PUBDelegate.getInstance.PubDrAddControlUpdate(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region " 刪除"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_以PK刪除資料
    ''' </summary>
    ''' <param name="pk_Dept_Code">院內看診科別代碼</param>
    ''' <param name="pk_Order_Code">醫令碼</param>
    ''' <param name="pk_Employee_Code">醫師代號</param>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlDelete(ByRef pk_Dept_Code As String, ByRef pk_Order_Code As String, ByRef pk_Employee_Code As String) As Integer Implements IPubService.PubDrAddControlDelete

        Try
            Return PUBDelegate.getInstance.PubDrAddControlDelete(pk_Dept_Code, pk_Order_Code, pk_Employee_Code)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function

#End Region

#Region " 查詢"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_以PK查詢資料，若查詢條件皆無，則全查
    ''' </summary>
    ''' <param name="deptCode">院內看診科別代碼 (可傳空字串)</param>
    ''' <param name="orderCode">醫令碼 (可傳空字串)</param>
    ''' <param name="employeeCode">醫師代號 (可傳空字串)</param>
    ''' <returns>查詢DataSet結果</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function QueryPubDrAddControlByPK(ByRef deptCode As String, ByRef orderCode As String, ByRef employeeCode As String) As DataSet Implements IPubService.QueryPubDrAddControlByPK

        Try
            Return PUBDelegate.getInstance.QueryPubDrAddControlByPK(deptCode, orderCode, employeeCode)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMD003", ex))
            Return Nothing
        End Try
    End Function
#End Region

#End Region

End Class
