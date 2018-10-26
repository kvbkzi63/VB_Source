Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Reflection
Imports System.Data.SqlClient
Imports Syscom.Server.SQL

Partial Public Class PUBDelegate

#Region "20150811 PUBExportList 查詢平台　by Will,Lin"
    '報表查詢功能
    Public Function PubExportQueryData(ByVal sql As String, ByVal getConnection As String) As System.Data.DataSet

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PubExportQueryData(sql, getConnection)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    '報表相關資訊查詢
    Public Function PubExportListDataQuery(ByVal Report_id As String) As System.Data.DataSet

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PubExportListDataQuery(Report_id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20150810 PUBExportSet 查詢設定作業 by Will,Lin"
    Public Function PUBExportSetInsertData(ByVal ds As DataSet) As Integer

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportInsertData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function PUBExportSetDeleteData(ByVal Report_Id As String) As Integer

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportDeleteData(Report_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function PUBExportSetUpdateData(ByVal Report_Id As String, ByVal ds As DataSet) As Integer

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportUpdateDataByPk(Report_Id, ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function PUBExportSetQueryExportData(ByVal Report_Id As String) As DataSet

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportExportDataQuery(Report_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function PUBExportSetQueryExportDetailData(ByVal Report_Id As String) As DataSet

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportExportDetailDataQuery(Report_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function PUBExportQueryForInsert(ByVal Report_Id As String) As DataSet

        Try
            Dim p1 As PubExportSetupBS = New PubExportSetupBS
            Return p1.PUBExportQueryForInsert(Report_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region


#Region "20090606 add by Alan 取得印表機名稱與列印紙張大小"
    Public Function PUBPrintConfigQueryByPK(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As DataSet

        Try
            Dim k1 As PUBPrintConfigBO_E1 = New PUBPrintConfigBO_E1
            Return k1.PrintConfigQueryByPK(pk_Report_Id, pk_Print_Type, pk_Print_Cond)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20090612 PUBBackupTempBO 備份處理  , add by James"

    Public Function insertPUBBackupTemp(ByVal changeFlag As String, ByVal changeData As DataSet) As Integer
        Try
            Dim k1 As PUBBackupTempBO_E1 = New PUBBackupTempBO_E1
            Return k1.insertPUBBackupTemp(changeFlag, changeData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "20090618 取得系統時間  , add by James"

    Public Function GetSystemNowTime() As Date
        Try
            Dim k1 As PUBSysTimeBS = New PUBSysTimeBS
            Return k1.GetSystemNowTime()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "20090720 PUBConfig , Added by James"

    Public Function queryPubConfigWhereConfigNameEquals(ByVal ConfigName As String, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet
        Dim PUBConfigBO As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try
            Return PUBConfigBO.queryPubConfigWhereConfigNameEquals(ConfigName, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryAllPUBConfig() As System.Data.DataSet
        Dim PUBConfigBO As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try
            Return PUBConfigBO.queryAll
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function updatePUBConfig(ByVal ds As System.Data.DataSet) As Integer
        Dim PUBConfigBO As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try
            Return PUBConfigBO.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryPUBConfigWhereConfigNameIn(ByVal configName As String) As DataSet
        Dim PUBConfigBO As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try
            Return PUBConfigBO.queryPUBConfigWhereConfigNameIn(configName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' query consumption
    ''' </summary>
    ''' <param name="configName">Config</param>
    ''' <returns></returns>
    ''' <remarks>Added By Ken</remarks>
    Public Function queryPUBConfigConsumptionDept(ByVal configName As String) As DataSet
        Try
            Return PubConfigBO_E1.getInstance.queryPUBConfigConsumptionDept(configName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryPubConfigDepDentalExtDays() As Int32
        Try
            Return PubConfigBO_E1.getInstance.GetDentalExtendDays
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2009/10/13 Add By James 檢驗檢查拆單用 "


    Public Function queryPUBSheetDetailByCond(ByVal OrderCode As String) As DataSet

        Dim instance As PubSheetDetailBO_E1 = PubSheetDetailBO_E1.getInstance
        Try
            Return instance.queryPUBSheetDetailByCond(OrderCode)
        Catch ex As Exception

            Throw ex
        End Try

    End Function


    '檢驗檢查 容器
    Public Function queryOrderMappingSpecimenByCond3(ByVal OrderCode As String, ByVal SpecimenId As String) As DataSet

        Dim instance As PUBOrderMappingSpecimenBO_E1 = PUBOrderMappingSpecimenBO_E1.GetInstance
        Try
            Return instance.queryOrderMappingSpecimenByCond3(OrderCode, SpecimenId)
        Catch ex As Exception

            Throw ex
        End Try

    End Function


#End Region


#Region "2013/09/25 醫師檔相關作業(PUBDOCTORBO_E1) by Sean.Lin"

#Region "     查詢醫師檔作為CBO 資料 "

    ''' <summary>
    ''' 查詢醫師檔作為CBO 資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function PUBDOCTORBOE1queryForCbo(ByVal SectionCode As String) As DataSet
        Try
            Dim m_PUBDOCTORBOE1 As PUBDOCTORBO_E1 = New PUBDOCTORBO_E1
            Return m_PUBDOCTORBOE1.queryForCbo(SectionCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 進行醫師驗證
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryDoctorFromEmployee(ByVal Employee_Code As String, ByVal Doctor_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As PUBDOCTORBO_E1 = New PUBDOCTORBO_E1
            Return instance.queryDoctorFromEmployee(Employee_Code, Doctor_Code, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#End Region

#Region "20100528 PUBSystemVersionBO , Added by Alan"

    ''' <summary>
    ''' 查詢系統版本更新記錄檔資料
    ''' </summary>
    Public Function DynamicQueryByColumn(ByRef queryData As DataSet) As System.Data.DataSet
        Try
            Dim instance As PUBSystemVersionBO_E1 = PUBSystemVersionBO_E1.getInstance
            Return instance.DynamicQueryByColumn(queryData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 新增系統版本更新記錄檔資料
    ''' </summary>
    Public Function insertPUBSystermVersion(ByVal queryData As System.Data.DataSet) As Integer
        Try
            Dim instance As PUBSystemVersionBO_E1 = PUBSystemVersionBO_E1.getInstance
            Return instance.insertPUBSystermVersion(queryData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2016/06/10 add by Lits Pub_IP_Config 維護"
    Public Function insertPubIPConfig(ByVal ds As System.Data.DataSet) As Integer
        Dim bo As New PUBIpConfigBO_E1
        Try
            Return bo.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function updatePubIPConfig(ByVal ds As System.Data.DataSet) As Integer
        Dim bo As New PUBIpConfigBO_E1
        Try
            Return bo.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function deletePubIPConfig(ByVal ip As System.String) As Integer
        Dim bo As New PUBIpConfigBO_E1
        Try
            Return bo.delete(ip)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function queryPubIPConfig(ByVal ip As System.String) As DataSet
        Dim bo As New PUBIpConfigBO_E1
        Try
            Return bo.queryByPK(ip)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function queryStationByIP(ByVal ip As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim bo As New PUBIpConfigBO_E1
        Try
            Return bo.queryStationByIP(ip)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "2014/09/01 員工資料相關查詢(PUBEmployee) by James"

#Region "     根據員工編號取得員工資料 "
    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function queryEmployeeByDate(ByVal EmployeeCode As String, ByVal JudgeDate As String) As DataSet

        Dim m_PUBEmployee As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try

            Return m_PUBEmployee.queryEmployeeByDate(EmployeeCode, JudgeDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#End Region

#Region "20110305 add by James, PUBPatientSevereDiseaseBO_E1"
    Public Function queryPubPatientSevereDiseaseByKey(ByVal Chart_No As String) As DataSet
        Dim instance As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance

        Try
            Return instance.queryPubPatientSevereDiseaseByKey(Chart_No)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20110305 add by James, PUBPatientDisabilityBO_E1"
    Public Function queryPubPatientDisabilityByKey(ByVal Chart_No As String) As DataSet
        Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance

        Try
            Return instance.queryPubPatientDisabilityByKey(Chart_No)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20110305 add by Rich, PUBPatientFlagBO_E1"

    Public Function queryPubPatientFlagByKey(ByVal Chart_No As String) As DataSet
        Dim instance As PUBPatientFlagBO_E1 = PUBPatientFlagBO_E1.getInstance

        Try
            Return instance.queryPubPatientFlagByKey(Chart_No)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function getSpecialFlagPlusA(ByVal Chart_No As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim instance As PUBPatientFlagBO_E1 = PUBPatientFlagBO_E1.getInstance

        Try
            Return instance.getSpecialFlagPlusA(Chart_No, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function getPatientFlagByFlagId(ByVal Chart_No As String, ByVal Flag_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim instance As PUBPatientFlagBO_E1 = PUBPatientFlagBO_E1.getInstance

        Try
            Return instance.getPatientFlagByFlagId(Chart_No, Flag_Id, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
    Public Function getPatientFlagByFlagIdList(ByVal Chart_No As String, ByVal Flag_IdList As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim instance As PUBPatientFlagBO_E1 = PUBPatientFlagBO_E1.getInstance

        Try
            Return instance.getPatientFlagByFlagIdList(Chart_No, Flag_IdList, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20090820 add by James 預防保健記錄"

    Public Function queryPUBPreventiveCareByPK(ByVal CareItemCode As String, ByVal CareOrderCode As String, ByVal CareCardseq As String) As DataSet
        Try
            Dim instance As PUBPreventiveCareBO_E1 = New PUBPreventiveCareBO_E1
            Return instance.queryByPK(CareItemCode, CareOrderCode, CareCardseq)
        Catch ex As Exception

            Throw ex
        End Try
    End Function


    Public Function queryPUBPreventiveCareNext(ByVal CareItemCode As String, ByVal CareOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As PUBPreventiveCareBO_E1 = New PUBPreventiveCareBO_E1
            Return instance.queryPUBPreventiveCareNext(CareItemCode, CareOrderCode, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBPreventiveCareByCond2(ByVal CareItemCode As String, ByVal CareOrderCode As String, ByVal CareCardseq As String) As DataSet
        Try
            Dim instance As PUBPreventiveCareBO_E1 = New PUBPreventiveCareBO_E1
            Return instance.queryPUBPreventiveCareByCond2(CareItemCode, CareOrderCode, CareCardseq)
        Catch ex As Exception

            Throw ex
        End Try
    End Function



    Public Function queryPUBPreventiveCareExeNext(ByVal PreCareOrderCode As String) As DataSet
        Try
            Dim instance As PUBPreventiveCareExeBO_E1 = New PUBPreventiveCareExeBO_E1
            Return instance.queryPUBPreventiveCareExeNext(PreCareOrderCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function


#End Region

#Region "2009/12/10 Added By Alan 寫入IC卡重大傷病與藥物過敏資料"

    ''' <summary>
    ''' 寫入IC卡重大傷病與藥物過敏資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertPatientData(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet) As Integer
        Try
            Dim instance As PUBAPI = PUBAPI.getInstance
            Return instance.InsertPatientData(ChartNo, UserId, CriticalIllness, Allergic)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function InsertPatientData2(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet, ByVal Prevent As DataSet) As Integer
        Try
            Dim instance As PUBAPI = PUBAPI.getInstance
            Return instance.InsertPatientData2(ChartNo, UserId, CriticalIllness, Allergic, Prevent)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


#Region "20090317 add by James OMO候診清單 - 依傳入員工代碼取得有效醫師相關資料 註:醫師是否有效以Announce_Effect_Date與Announce_End_Date判斷"

    Public Function queryPUBDoctorByKey(ByVal EmployeeCode As String) As DataSet
        Try
            Dim k1 As PUBDOCTORBO_E1 = PUBDOCTORBO_E1.getInstance
            Return k1.queryPUBDoctorByKey(EmployeeCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <param name="SQLStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function dynamicQuery(ByVal SQLStr As String) As DataSet
        Try
            Dim instance As PUBDynamicBS = PUBDynamicBS.getInstance
            Return instance.dynamicQuery(SQLStr)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbDebugMsg(SQLStr, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbDebugMsg(SQLStr, ex)
            Throw ex
        End Try
    End Function

    '清空病歷主檔爽約欄位資料
    Public Function ClearPatientMisRegister(ByVal chartNo As String) As Integer
        Try
            Dim pubApi As New PUBAPI
            Return pubApi.ClearPatientMisRegister(chartNo)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#Region "20100426 PUBOrderPriceBO , Added by Alan"
    ''' <summary>
    ''' 醫令自費與健保價格查詢
    ''' </summary>
    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet
        Try
            Return PUBOrderPriceBO_E1.getInstance.queryPUBOrderOwnAndNhiPrice(OrderCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
#Region "PUBOrderStandingBO_E1"

    Public Function queryPUBOrderStandingConsumptionDept(ByVal orderCode As String, ByVal deptCode As String) As DataSet
        Try
            Return PUBOrderStandingBO_E1.Instance.queryPUBOrderStandingConsumptionDept(orderCode, deptCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20100420 PUBDiseaseBO , Added by Alan"
    ''' <summary>
    ''' 常用一般診斷查詢
    ''' </summary>
    Public Function queryPUBDiseaseByFavor(ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet
        Try
            Return PUBDiseaseBO_E1.getInstance.queryPUBDiseaseByFavor(code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet
        Try
            Return PUBDiseaseBO_E1.getInstance.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20091026 查詢 PUBConfigBO_E2 ,add by ChenYang"
    Function queryPUBConfigByPK(ByVal pk_Config_Name As String) As System.Data.DataSet
        Try
            Return PubConfigBO_E1.getInstance.queryByPK(pk_Config_Name)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region


#Region "20100622 add by James, PUBPartBO_E1"
    Function queryPubPartByKey(ByVal regDate As String) As DataSet
        Try
            Dim instance As PUBPartBO_E1 = PUBPartBO_E1.getInstance
            Return instance.queryPubPartByKey(regDate)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region


#Region "20100622 add by Rich, PUBPatientBO_E1"

    Function queryPubPatientByIdno(ByVal Idno As String) As DataSet
        Try
            Dim instance As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return instance.queryPubPatientByIdno(Idno)
        Catch ex As Exception

            Throw ex
        End Try
    End Function


    Function queryPubPatientByPK(ByRef pk_Chart_No As System.String) As DataSet
        Try
            Dim instance As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return instance.queryByPK(pk_Chart_No)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBPatientByName(ByVal Chart_No As String, ByRef Patient_Name As System.String, ByVal Idno As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim instance As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance

        Try
            Return instance.queryPUBPatientByName(Chart_No, Patient_Name, Idno, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBPatientByNameBirthday(ByRef Patient_Name As String, ByVal Birth_Date As String) As System.Data.DataSet
        Dim instance As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance

        Try
            Return instance.queryPUBPatientByNameBirthday(Patient_Name, Birth_Date)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20090511 add by James 掛號 - 根據Key值取得細分科 "
    Public Function queryPUBDepartmentByKey(ByVal deptCode As String) As DataSet
        Try
            Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return k1.queryPUBDepartmentByKey(deptCode)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20090414 PUBQueryAreaBO 共用元件-地址(戶籍地,郵遞區號)查詢  by James"
    Function queryPubPostalAreaAll() As DataSet

        Try
            Dim k1 As PUBPostalAreaBO_E1 = New PUBPostalAreaBO_E1
            Return k1.queryPubPostalAreaAll()
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "20090414 PUBQueryChartNoBO 共用元件-病歷號查詢  by James"
    Public Function queryPubChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet

        Try
            Dim k1 As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return k1.queryPubChartNoByKey(codeNo, codeType)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "2014/12/02 by James 身份別連動資料"
    Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet

        Dim instance As PUBSubIdentityBO_E1 = PUBSubIdentityBO_E1.getInstance

        Try
            Return instance.queryPUBSubIdentityAll(inSourceType)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    Function queryPUBSubIdentityBySourceType(ByVal inSourceType As String) As DataSet

        Dim instance As PUBSubIdentityBO_E1 = PUBSubIdentityBO_E1.getInstance

        Try
            Return instance.queryPUBSubIdentityAll(inSourceType)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    Function queryPUBDisIdentityAll() As DataSet
        Dim instance As PUBDisIdentityBO_E1 = PUBDisIdentityBO_E1.getInstance

        Try
            Return instance.queryPUBDisIdentityAll()
        Catch ex As Exception

            Throw ex
        End Try
    End Function


    Function queryPUBContractAll() As DataSet
        Dim instance As PUBContractBO_E1 = PUBContractBO_E1.getInstance

        Try
            Return instance.queryPUBContractAll()
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "2012/04/06 add by Alan 取得Term_Code設定資料"
    Public Function queryStationByTermCode(ByVal inTermCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim bo As New PCSIpConfigBO_E1
        Try
            Return bo.queryStationByTermCode(inTermCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "2014/09/01 員工資料相關查詢(PUBEmployee) by Sean.Lin"

#Region "     根據員工編號取得員工資料 "
    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCode(ByVal EmployeeCode As String) As DataSet

        Dim m_PUBEmployee As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try

            Return m_PUBEmployee.queryEmployeeByEmpCode(EmployeeCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     根據員工編號和日期取得有效期限的員工資料 "
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCodeAndDate(ByVal EmployeeCode As String, ByVal JudgeDate As Date) As DataSet

        Dim m_PUBEmployee As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try

            Return m_PUBEmployee.queryEmployeeByEmpCodeAndDate(EmployeeCode, JudgeDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

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
    Public Function PubConfigQueryByConfigName(ByVal configName As String) As DataSet

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.QueryByConfigName(configName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryByPK(ByRef pk_Config_Name As System.String) As DataSet

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.queryByPK(pk_Config_Name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdelete(ByRef pk_Config_Name As System.String) As Integer

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.delete(pk_Config_Name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfiginsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryAll() As System.Data.DataSet

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

        Dim m_PubConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PubConfig.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region


#End Region

#Region "2014/11/04 系統參數設定維護 by Alan.Tsai"

#Region "     資料查詢 "

    ''' <summary>
    ''' 根據系統參數名稱查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function queryPUBConfigLikePKey(ByVal inConfigName As String) As DataSet

        Dim m_PubConfig As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try

            Return m_PubConfig.queryPUBConfigLikePKey(inConfigName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function qureyPUBConfigAll() As DataSet

        Dim m_PubConfig As PubConfigBO_E1 = PubConfigBO_E1.getInstance
        Try

            Return m_PubConfig.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     資料存檔 "

    ''' <summary>
    ''' 將傳入新增與修改資料進行存檔
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function savePUBConfig(ByVal inSaveDs As DataSet) As DataSet

        Dim m_PubConfig As PubConfigBS = New PubConfigBS
        Try
            Return m_PubConfig.getInstance.savePubConfig(inSaveDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#Region "     資料刪除 "

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function deletePUBConfig(ByVal inDeleteDs As DataSet) As DataSet

        Dim m_PubConfig As PubConfigBS = New PubConfigBS
        Try
            Return m_PubConfig.getInstance.deletePubConfig(inDeleteDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region


#End Region

#Region "2014/11/08 公用類別代碼維護 by Alan.Tsai"

#Region "     資料查詢 "

    ''' <summary>
    ''' 根據類別代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function queryPUBSyscodeTypeLikePKey(ByVal inTypeId As String) As DataSet

        Dim m_PubSyscodeType As PubSyscodeTypeBO_E1 = PubSyscodeTypeBO_E1.getInstance
        Try

            Return m_PubSyscodeType.queryPUBSyscodeTypeLikePKey(inTypeId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function qureyPUBSyscodeTypeAll() As DataSet

        Dim m_PubSyscodeType As PubSyscodeTypeBO_E1 = PubSyscodeTypeBO_E1.getInstance
        Try

            Return m_PubSyscodeType.queryPUBSyscodeTypeAll
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     資料存檔 "

    ''' <summary>
    ''' 將傳入新增與修改資料進行存檔
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function savePUBSyscodeType(ByVal inSaveDs As DataSet) As DataSet

        Dim m_PubSyscodeType As PubSyscodeTypeBS = New PubSyscodeTypeBS
        Try
            Return m_PubSyscodeType.getInstance.savePubSyscodeType(inSaveDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#Region "     資料刪除 "

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function deletePUBSyscodeType(ByVal inDeleteDs As DataSet) As DataSet

        Dim m_PubSyscodeType As PubSyscodeTypeBS = New PubSyscodeTypeBS
        Try
            Return m_PubSyscodeType.getInstance.deletePubSyscodeType(inDeleteDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#End Region

#Region "2014/11/09 公用代碼維護 by Alan.Tsai"

#Region "     資料查詢 "

    ''' <summary>
    ''' 根據類別代碼、公用代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBSyscodeLikePKey(ByVal inTypeId As String, ByVal inCodeId As String) As DataSet

        Dim m_PubSyscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Try

            Return m_PubSyscode.queryPUBSyscodeLikePKey(inTypeId, inCodeId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    ''' <summary>
    ''' 根據類別代碼、公用代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBSyscodePKey(ByVal inTypeId As String, ByVal inCodeId As String) As DataSet

        Dim m_PubSyscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Try

            Return m_PubSyscode.queryPUBSyscodePKey(inTypeId, inCodeId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    Public Function queryPUBSysCodebyTypeId(ByVal TypeId As Integer) As DataSet
        Dim m_PubSyscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Try

            Return m_PubSyscode.queryPUBSysCodebyTypeId(TypeId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function qureyPUBSyscodeAll() As DataSet

        Dim m_PubSyscode As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Try

            Return m_PubSyscode.queryPUBSyscodeAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     資料存檔 "

    ''' <summary>
    ''' 將傳入新增與修改資料進行存檔
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBSyscode(ByVal inSaveDs As DataSet) As DataSet

        Dim m_PubSyscode As PubSyscodeBS = New PubSyscodeBS
        Try
            Return m_PubSyscode.getInstance.savePubSyscode(inSaveDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#Region "     資料刪除 "

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBSyscode(ByVal inDeleteDs As DataSet) As DataSet

        Dim m_PubSyscode As PubSyscodeBS = New PubSyscodeBS
        Try
            Return m_PubSyscode.getInstance.deletePubSyscode(inDeleteDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#End Region

#Region "2014/11/09 醫事機構維護 by Alan.Tsai"

#Region "     資料查詢 "

    ''' <summary>
    ''' 根據類別、生效日期與醫院代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBHospitalLikePKey(ByVal inLanguageTypeId As String, _
                                             ByVal inEffectDate As String, _
                                             ByVal inHospitalCode As String) As DataSet

        Dim m_PubHospital As PubHospitalBO_E1 = PubHospitalBO_E1.getInstance
        Try

            Return m_PubHospital.queryPubHospitalLikePKey(inLanguageTypeId, inEffectDate, inHospitalCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    ''' <summary>
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function qureyPUBHospitalAll() As DataSet

        Dim m_PubHospital As PubHospitalBO_E1 = PubHospitalBO_E1.getInstance
        Try

            Return m_PubHospital.queryPubHospitalAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

    ''' <summary>
    ''' 畫面初始化資料查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-10</remarks>
    Public Function initPubHospital() As DataSet

        Dim m_PubHospital As PubHospitalBS = New PubHospitalBS
        Try
            Return m_PubHospital.initPubHospital()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function

#End Region

#Region "     資料存檔 "

    ''' <summary>
    ''' 將傳入新增與修改資料進行存檔
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBHospital(ByVal inSaveDs As DataSet) As DataSet

        Dim m_PubHospital As PubHospitalBS = New PubHospitalBS
        Try
            Return m_PubHospital.getInstance.savePubHospital(inSaveDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#Region "     資料刪除 "

    ''' <summary>
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBHospital(ByVal inDeleteDs As DataSet) As DataSet

        Dim m_PubHospital As PubHospitalBS = New PubHospitalBS
        Try
            Return m_PubHospital.getInstance.deletePubHospital(inDeleteDs)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function


#End Region

#End Region

#Region "2014/12/02 by Lits 取得員工全部資料"
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Lits on 2014-12-02</remarks>
    Public Function queryEmployeeALL() As DataSet

        Dim m_PUBEmployee As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try
            Return m_PUBEmployee.queryEmployeeALL()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Lits on 2014-12-02</remarks>
    Public Function queryEmployeeByDept(ByVal dept As String) As DataSet

        Dim m_PUBEmployee As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try
            Return m_PUBEmployee.queryEmployeeByDept(dept)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function
#End Region

    ''' <summary>
    ''' 程式說明：取得所有員工
    ''' 開發人員：Jen
    ''' 開發日期：2009.07.31
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Employee
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/31, XXX
    ''' </修改註記>
    Public Function queryAllEmployeeForComboBox() As DataTable
        Dim instance As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
        Try
            Return instance.queryAllEmployeeForComboBox()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#Region "2010/01/20, Add By 谷官, 健保資料設定(OPCSetHealthInsuData)"

    ''' <summary>
    ''' 藥品加收部負
    ''' </summary>
    ''' <param name="OpdChargeDate">門診批價日</param>
    ''' <param name="MedicalAmt">藥品金額</param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getMedicalPartAmt(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal) As DataTable
        Try
            Dim instance As PUBAddPartBO_E1 = PUBAddPartBO_E1.getInstance
            Return instance.getMedicalPartAmt(OpdChargeDate, MedicalAmt)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
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
    Public Function getEndDateForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String) As DataTable
        Try
            Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return instance.getEndDateForReceiptUI(ChartNo, OpdVisitDate)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function getPatientDisabilityRecordForReceiptUI(ByVal ChartNo As String) As DataTable
        Try
            Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return instance.getPatientDisabilityRecordForReceiptUI(ChartNo)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function getIcdCodeForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String, ByVal IcdCodeDT As DataTable) As DataTable
        Try
            Dim instance As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
            Return instance.getIcdCodeForReceiptUI(ChartNo, OpdVisitDate, IcdCodeDT)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：新增有效的殘障紀錄 
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function insertPatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer
        Try
            Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return instance.insert(ds)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：修改有效的殘障紀錄 
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function updatePatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer
        Try
            Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return instance.update(ds)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function getMaxPatientDisabilityNoForReceiptUI(ByVal ChartNo As String) As Integer
        Try
            Dim instance As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return instance.getMaxPatientDisabilityNoForReceiptUI(ChartNo)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/07/20, Add By 谷官, OPCAPI"

    ''' <summary>
    ''' 將Examine_Type_Id(診察費類別)代入如下求得Order_Code
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Main_Identity_Id, Dept_Code,Examine_Type_Id, Order_Code 
    ''' FROM PUB_Examine 
    ''' WHERE Main_Identity_Id=medicalRecordValue.Sub_Identity_Code 
    ''' AND (Dept_Code=medicalRecordValue.Dept_Code OR Dept_Code='')
    ''' AND Examine_Type_Id = 診察費類別 
    ''' ORDER BY Main_Identity_Id,Dept_Code,Medical_Type_Id DSEC
    ''' </summary>
    ''' <param name="keyValue">
    ''' KEY = Dept_Code(院內科別代碼)
    ''' KEY = Sub_Identity_Code：保險別(身份1)
    ''' KEY = Examine_Type_Id：診察費類別
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getOrderCodeFromPubExamineForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBExamineBO_E1 = PUBExamineBO_E1.getInstance
            Return instance.getOrderCodeForOPCAPI(keyValue, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 規則2：
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Main_Identity_Id,Dept_Code,Medical_Type_Id, Order_Code 
    ''' FROM PUB_Register_Fee 
    ''' WHERE Main_Identity_Id=保險別(身份1) 
    ''' AND (Dept_Code=院內科別代碼 OR Dept_Code=' ') 
    ''' AND (Medical_Type_Id = 就醫類型 OR Medical_Type_Id = ' ') 
    ''' AND Dc=N
    ''' ORDER BY Main_Identity_Id,Dept_Code,Medical_Type_Id DESC
    ''' 
    ''' 再把Order_Code值代入如下：
    ''' Order_Type_Id值為O.Order_Type_Id
    ''' Account_Id值為O.Account_Id
    ''' SELECT O.Order_Type_Id,O.Account_Id 
    ''' FROM PUB_Order O 
    ''' WHERE O.Dc=N
    ''' AND O.Order_Code = Order_Code
    ''' AND O.Effect_Date ＜＝ 掛號日期
    ''' AND O.End_Date ＞ 掛號日期
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Main_Identity_Id：保險別(身份1)
    ''' Key = Dept_Code：院內科別代碼
    ''' Key = Medical_Type_Id：就醫類型
    ''' Key = REG_DATE：掛號日
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getOrderCodeFromPubRegisterFeeForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBRegisterFeeBO_E1 = PUBRegisterFeeBO_E1.getInstance
            Return instance.getOrderCodeForOPCAPI(keyValue, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 規則2：
    ''' Order_Code為下列結果中第一筆的資料
    ''' SELECT Main_Identity_Id,Dept_Code,Medical_Type_Id, Order_Code 
    ''' FROM PUB_Register_Fee 
    ''' WHERE Main_Identity_Id=保險別(身份1) 
    ''' AND (Dept_Code=院內科別代碼 OR Dept_Code=' ') 
    ''' AND (Medical_Type_Id = 就醫類型 OR Medical_Type_Id = ' ') 
    ''' AND Dc=N
    ''' ORDER BY Main_Identity_Id,Dept_Code,Medical_Type_Id DESC
    ''' 
    ''' 再把Order_Code值代入如下：
    ''' Order_Type_Id值為O.Order_Type_Id
    ''' Account_Id值為O.Account_Id
    ''' SELECT O.Order_Type_Id,O.Account_Id 
    ''' FROM PUB_Order O 
    ''' WHERE O.Dc=N
    ''' AND O.Order_Code = Order_Code
    ''' AND O.Effect_Date ＜＝ 掛號日期、就醫日
    ''' AND O.End_Date ＞ 掛號日期、就醫日
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Order_Code
    ''' Key = DATE：REG_DATE(掛號日)、OPD_VISIT_DATE(就醫日)
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getPubOrderDataForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
            Return instance.getPubOrderDataForOPCAPI(keyValue, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 規則3：
    ''' 再把規則2的Order_Code值代入如下
    ''' Insu_Account_Id值為OP.Insu_Account_Id
    ''' Price值為OP.Price
    ''' Add_Price值為OP. Add_Price
    ''' Material_Account_Id值為OP. Material_Account_Id
    ''' Material_Ratio值為OP. Material_Ratio
    ''' SELECT OP.Insu_Account_Id, OP.Price, OP.Add_Price, 
    ''' OP.Material_Account_Id, OP.Material_Ratio 
    ''' FROM PUB_Order_Price OP 
    ''' WHERE OP.Dc=N
    ''' AND OP.Order_Code = Order_Code 
    ''' AND OP.Main_Identity_Id = 保險別(身份1)
    ''' AND OP.Effect_Date ＜＝ 掛號日期、就醫日
    ''' AND OP.End_Date ＞ 掛號日期、就醫日
    ''' </summary>
    ''' <param name="keyValue">
    ''' Key = Order_Code
    ''' Key = Main_Identity_Id：保險別(身份1)
    ''' Key = DATE：REG_DATE(掛號日)、OPD_VISIT_DATE(就醫日)
    ''' </param>
    ''' <returns></returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function getPubOrderPriceDataForOPCAPI(ByVal keyValue As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance
            Return instance.getPubOrderPriceDataForOPCAPI(keyValue, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 檢查是否要收掛號費
    ''' </summary>
    ''' <param name="outpatientSn">門診號</param>
    ''' <param name="chargeDate">門診批價日</param>
    ''' <returns>是否要收掛號費</returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function checkNeedPayRegFeeOrNotForOPCAPI(ByVal outpatientSn As String, ByVal chargeDate As String) As String
        Try
            Dim instance As PubPatientScheduleBO_E1 = PubPatientScheduleBO_E1.getInstance
            Return instance.checkNeedPayRegFeeOrNotForOPCAPI(outpatientSn, chargeDate)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBSubIdentityByPK(ByVal mainIdentityId As String, ByVal subIdentityCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBSubIdentityBO_E1 = PUBSubIdentityBO_E1.getInstance
            Return instance.queryPUBSubIdentityByPK(mainIdentityId, subIdentityCode, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBSubIdentityByPKAndSourceType(ByVal mainIdentityId As String, ByVal subIdentityCode As String, ByVal inSourceType As String, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBSubIdentityBO_E1 = PUBSubIdentityBO_E1.getInstance
            Return instance.queryPUBSubIdentityByPK(mainIdentityId, subIdentityCode, conn, inSourceType)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/08/22, Add By 谷官, 收費員結算(OPCCloseAccountsByEmpUI)"

    ''' <summary>
    ''' 程式說明：取得員工姓名
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.22
    ''' </summary>
    ''' <param name="empCode">員工編號</param>
    ''' <returns>Employee_Name</returns>
    Public Function getEmpName(ByVal empCode As String) As String
        Try
            Dim instance As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
            Return instance.getEmpName(empCode)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/09/10, Add By 谷官, 復健部分負擔作業(OPCRecoverPartPayUI)"

    ''' <summary>
    ''' 程式說明：取得加收部分負擔金額
    ''' 開發人員：谷官
    ''' 開發日期：2009.09.10
    ''' </summary>
    ''' <param name="outpatientSn">看診號</param>
    ''' <param name="cureCardSn">治療卡號</param>
    ''' <returns>加收部分負擔金額</returns>
    Public Function getAddPartAmt(ByVal outpatientSn As String, ByVal cureCardSn As String) As Integer
        Try
            Dim instance As PUBAddPartBO_E1 = PUBAddPartBO_E1.getInstance
            Return instance.getAddPartAmt(outpatientSn, cureCardSn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得加收部分負擔金額
    ''' 開發人員：谷官
    ''' 開發日期：2009.09.10
    ''' </summary>
    ''' <returns>加收部分負擔折扣率</returns>
    Public Function getAddPartDiscountRatio(ByVal opdChargeDate As Date, ByVal partCode As String, ByVal disIdentityCode As String) As Decimal
        Try
            Dim instance As PUBPartDiscountBO_E1 = PUBPartDiscountBO_E1.getInstance
            Return instance.getAddPartDiscountRatio(opdChargeDate, partCode, disIdentityCode)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/09/07, Add By 谷官, 慢箋醫令處理(OPCChronicDetailOperationUI)"

    ''' <summary>
    ''' 取得Order_En_Name by Order_Code
    ''' </summary>
    ''' <param name="orderCode">批價碼</param>
    ''' <returns>Order_En_Name</returns>
    ''' <remarks></remarks>
    Public Function getOrderEnNameByOrderCode(ByVal orderCode As String) As String
        Try
            Dim instance As PUBOrderBO_E1 = New PUBOrderBO_E1
            Return instance.getOrderEnNameByOrderCode(orderCode)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2010/03/25, Add By 谷官, 櫃台批價(OPCAddMedicalRecordUI)"

    ''' <summary>
    ''' 程式說明：取得Pub_Sheet的ComboBox Value For櫃台批價
    ''' 開發人員：谷官
    ''' 開發日期：2010.03.25
    ''' </summary>
    ''' <returns>Pub_Sheet的ComboBox Value For櫃台批價</returns>
    ''' <remarks></remarks>
    Public Function queryPubSheetComboValueForAddMedicalRecord(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
            Return instance.queryPubSheetComboValueForAddMedicalRecord(conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    ' ''' <summary>
    ' ''' 取得PubIcCardRecord By PK
    ' ''' </summary>
    ' ''' <param name="medicalSn"></param>
    ' ''' <param name="iCMedicalTypeId"></param>
    ' ''' <param name="chargeDate"></param>
    ' ''' <param name="conn"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function queryPubIcCardRecordByPK(ByVal medicalSn As String, ByVal iCMedicalTypeId As String, ByVal chargeDate As Date, Optional ByRef conn As IDbConnection = Nothing) As DataTable
    '    Try
    '        Dim instance As PUBIcCardRecordBO_E1 = PUBIcCardRecordBO_E1.getInstance
    '        Return instance.queryByPK(medicalSn, iCMedicalTypeId, chargeDate, conn).Tables(0)
    '    Catch ex As Exception
    '        Throw New CommonException("CMMCMMD001", ex)
    '        Throw ex
    '    End Try
    'End Function

    ''' <summary>
    ''' 取得精神科的Icd_Code
    ''' </summary>
    ''' <param name="opdVisitDate"></param>
    ''' <param name="icdCode"></param>
    ''' <returns>精神科的Icd_Code</returns>
    ''' <remarks></remarks>
    Public Function getPsyIcdCodeData(ByVal opdVisitDate As Date, ByVal icdCode As String) As String
        Try
            Dim instance As PUBDiseaseBO_E1 = PUBDiseaseBO_E1.getInstance
            Return instance.getPsyIcdCodeData(opdVisitDate, icdCode)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

#End Region

#Region "2009/08/22, Add By 谷官, 欠款繳回(OPCPayArrearUI)"

    ''' <summary>
    ''' 更新欠款記錄
    ''' </summary>
    ''' <param name="chartNo"></param>
    ''' <param name="opdArrearsAmt"></param>
    ''' <param name="modifiedUser"></param>
    ''' <param name="modifiedTime"></param>
    ''' <param name="conn"></param>
    ''' <param name="source" >來源</param>
    ''' <returns></returns>
    ''' <remarks>2011.08.24 Bella, 改為門急住(O/E/I)共用</remarks>
    Public Function updateOpdArrearsAmt(ByVal chartNo As String, ByVal opdArrearsAmt As Integer, ByVal modifiedUser As String, ByVal modifiedTime As Date, Optional ByRef conn As IDbConnection = Nothing, Optional ByVal source As String = "") As Integer
        Try
            Dim instance As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return instance.updateOpdArrearsAmt(chartNo, opdArrearsAmt, modifiedUser, modifiedTime, conn, source)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function
#End Region

#Region "2009/08/11, Add By 谷官, ComboBox的Data Source"

    ''' <summary>
    ''' 程式說明：取得部份負擔ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.07.24
    ''' </summary>
    ''' <returns>cboValue:Part_Code, Part_Name</returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function getPubPartComboBoxValueTable(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBPartBO_E1 = PUBPartBO_E1.getInstance
            Return instance.getComboBoxValueTable(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得就醫科別ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.11
    ''' </summary>
    ''' <returns>Dept_Code, Dept_Name</returns>
    Public Function getDeptComboBoxValueTable(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return instance.getComboBoxValueTable(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得看診醫師ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.11
    ''' </summary>
    ''' <param name="professalKindFlag">
    ''' 職務類別
    ''' 
    ''' "0"：主治醫師
    ''' "1"：住院醫師
    ''' "2"：藥師
    ''' "0,1..."：組合條件(ex：主治醫師+住院醫師...)
    ''' </param>
    ''' <returns>Employee_Code, Employee_Name</returns>
    Public Function getDoctorComboBoxValueTable(ByVal professalKindFlag As String, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Dim instance As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance
            Return instance.getComboBoxValueTable(professalKindFlag, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function
#End Region


#Region "20090407 PUBHolidayBO 假日檔維護  by James"
    '查詢某一假日
    Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal datestrHolidayYear As Date, ByVal strSubSystemCode As String) As DataSet
        Dim instance As New PUBHolidayBO_E1
        Try
            Return instance.queryPUBHolidayByCond(strHolidayYear, datestrHolidayYear, strSubSystemCode)
        Catch ex As Exception
            'log.Error(ex.ToString)
            Throw ex
        End Try

    End Function

    '查詢所有假日
    Function queryPUBHolidayAll() As DataSet
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance

        Try
            Return instance.queryPubHolidayAll()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function


    ''查詢某一假日
    Function queryPUBHolidayByKey(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance
        Try
            Return instance.queryPubHolidayByKey(holidayDate, subSysCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    Function queryPUBHolidayByKey2(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance
        Try
            Return instance.queryPubHolidayByKey2(holidayDate, subSysCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    '新增假日
    Function insertPUBHoliday(ByVal dsParam As DataSet) As Integer
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance

        Try
            Return instance.insertPubHoliday(dsParam)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    '刪除假日
    Function deletePUBHoliday(ByVal holidayDate As String, ByVal subSysCode As String) As Integer
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance

        Try
            Return instance.deletePubHoliday(holidayDate, subSysCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    '更新假日
    Function updatePUBHoliday(ByVal dsParam As DataSet) As Integer
        Dim instance As PUBHolidayBO_E1 = PUBHolidayBO_E1.getInstance

        Try
            Return instance.updatePubHoliday(dsParam)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

#Region "適應症檢核"

    Function DoPubAction(ByVal ds As DataSet) As DataSet
        Try
            Dim k1 As PUBAPI = New PUBAPI
            Return k1.DoPubAction(ds)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "20090803 add by Rich, PUBSysCodeBO_E1"

    Public Function queryPUBSysCodeInCond(ByVal TypeId As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim instance As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance
        Try
            Return instance.queryPUBSysCodeInCond(TypeId, multiCodeIdFlag, conn)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

#End Region

#Region "20090317 add by Alan 掛號 - 依傳入TypeID取得代碼檔資料"
    Public Function queryPUBSysCode(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim k1 As PUBSysCodeBO_E1 = New PUBSysCodeBO_E1
            Return k1.queryPUBSyscodeAll(TypeID, multiCodeIdFlag, conn)
        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

    Public Function queryPUBSysCode2(ByVal SourceType As String, ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim k1 As PUBSysCodeBO_E1 = New PUBSysCodeBO_E1
            Return k1.queryPUBSysCodeAll2(SourceType, TypeID, multiCodeIdFlag, conn)
        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)
            Throw ex
        End Try
    End Function

#End Region

#Region "20100128 add by Rich, PUBOrderPriceBO_E1"

    Public Function queryOrderPriceDataByOrder(ByVal OrderCode As String) As DataTable
        Try
            Dim instance As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance
            Return instance.queryOrderPriceDataByOrder(OrderCode)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

#End Region

#Region "20090317 add by Alan 掛號 - 取得所有細分科 "

    Public Function queryPUBDepartmentAll_B() As DataSet
        Try
            Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return k1.queryPUBDepartmentAll_B()
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
    End Function

    Public Function queryPUBDepartmentAll_D(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return k1.queryPUBDepartmentAll_D(conn)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try


        'Try
        '    Dim k1 As PUBDepartmentBO_E1 = New PUBDepartmentBO_E1
        '    Return k1.queryAll
        'Catch ex As Exception
        '    log.Error(ex.Message)
        '    Throw ex
        'End Try


    End Function

    ''' <summary>
    ''' 程式說明：依據來源別O、E、I，取得對應的門診、急診、住院 科別
    ''' 開發人員：Charles
    ''' 調整日期：2015/12/16
    ''' </summary>
    ''' <param name="SourceType">O：門診、E：急診、I：住院</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As System.Data.DataSet
        Try
            Dim k1 As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Return k1.queryPUBDepartmentAll_D2(SourceType)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try

    End Function

#End Region

#Region "20091112 add by Rich, 醫師代碼Combobox"

    ''' <summary>
    ''' Combobox所有醫師
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryComboboxAllDoctor(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim instance As PUBDOCTORBO_E1 = PUBDOCTORBO_E1.getInstance
            Return instance.queryComboboxAllDoctor(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

#End Region

#Region "20090803 add by Rich, PUBBodySiteBO_E1"

    Public Function queryPUBBodySiteMainSiteData(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim instance As PUBBodySiteBO_E1 = PUBBodySiteBO_E1.getInstance
        Try
            Return instance.queryPUBBodySiteMainSiteData(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    Public Function queryPUBBodySiteMainSiteDataForApplyFlagREH(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim instance As PUBBodySiteBO_E1 = PUBBodySiteBO_E1.getInstance
        Try
            Return instance.queryPUBBodySiteMainSiteDataForApplyFlagREH(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

    Public Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim instance As PUBBodySiteBO_E1 = PUBBodySiteBO_E1.getInstance
        Try
            Return instance.queryPUBBodySiteNotMainSiteData(MainBodySiteCode, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2009/10/31 Added by Jen, 取得醫院資料"

    ''' <summary>
    ''' 取得醫院資料
    ''' </summary>
    ''' <date>2009-10-31</date>
    ''' <remarks></remarks>
    Public Function queryHospitalInfo(ByVal HospitalCode As String, ByVal LanguageTypeId As String, ByVal EffectDate As Date) As DataSet
        Try
            Return PubHospitalBO_E1.getInstance.queryHospitalInfo(HospitalCode, LanguageTypeId, EffectDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "PatientSevereDisease"
    Public Function InsertPatientSevereDisease(ByVal ds As DataSet) As Integer
        Dim instance As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
        Try
            Return instance.insert(ds)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function UpdatePatientSevereDisease(ByVal ds As DataSet) As Integer
        Dim instance As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
        Try
            Return instance.update(ds)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region
#Region "20090710 PUBOrderPrice , Added by Jen"

    Dim m_pubOrderPriceBO As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance
    ''' <summary>
    ''' query price data by order code
    ''' </summary>
    ''' <param name="orderNo">Order Code</param>
    ''' <returns>the result of query</returns>
    ''' <remarks>20090710 By Jen</remarks>
    Public Function queryPriceByOrders(ByVal orderNo() As String) As DataSet
        Try
            Return m_pubOrderPriceBO.queryPriceByOrders(orderNo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20090317 add by Alan 掛號 - 依傳入醫師代碼取得有效醫師相關資料 註:醫師是否有效以Announce_Effect_Date與Announce_End_Date判斷"
    Public Function queryPUBDoctor(ByVal DoctorCode As String) As DataSet
        Try
            Dim k1 As PUBDOCTORBO_E1 = PUBDOCTORBO_E1.getInstance
            Return k1.queryPUBDoctor(DoctorCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "2012-02-14 PUBPatientAllergyNew相關程式"
    Public Function InitUI() As DataSet
        Dim instance As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try
            Return instance.InitUI
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function Find_AllergyRecord(ByVal Chart_No As String) As DataTable
        Dim instance As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try
            Return instance.Find_AllergyRecord(Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function Find_PatientData(ByVal Chart_No As String) As DataTable
        Dim instance As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try
            Return instance.Find_PatientData(Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function Find_AllergyHistory(ByVal Chart_No As String) As DataTable
        Dim instance As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try
            Return instance.Find_AllergyHistory(Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Sub AddNew_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Create_Time As String, ByVal Create_User As String)
        Try
            PUBPatientAllergyBO_E1.getInstance.AddNew_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Create_User, Create_Time)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Function AddNew_AllergyRecord_NKDA(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String
        Try
            Return PUBPatientAllergyBO_E1.getInstance.AddNew_AllergyRecord_NKDA(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Severity, _
                              Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Pharmacy_12_Code, ADRNotification_No, Cancel, _
                              Create_User, Create_Time, Modified_User, _
                              Modified_Time, Drug_Allergy_Id, Limit_Strength, order_name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function AddNew_AllergyRecord_OTHER(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String
        Try
            Return PUBPatientAllergyBO_E1.getInstance.AddNew_AllergyRecord_OTHER(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Severity, _
                              Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Pharmacy_12_Code, ADRNotification_No, Cancel, _
                              Create_User, Create_Time, Modified_User, _
                              Modified_Time, Drug_Allergy_Id, Limit_Strength, order_name)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Sub Modify_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Modified_User As String, ByVal Modified_Time As String)
        Try
            PUBPatientAllergyBO_E1.getInstance.Modify_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Modified_User, Modified_Time)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub Delete_AllergyRecord(ByVal Chart_No As String, ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Cancel As String, ByVal Modified_User As String, ByVal Modified_Time As String, ByVal Allergy_no As String)
        Try
            PUBPatientAllergyBO_E1.getInstance.Delete_AllergyRecord(Chart_No, Allergy_Code, Allergy_Item, Cancel, Modified_User, Modified_Time, Allergy_no)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub Reset_IsFromICCard(ByVal Chart_No As String, ByVal Drug1 As String, ByVal Drug2 As String, ByVal Drug3 As String)
        Try
            PUBPatientAllergyBO_E1.getInstance.Reset_IsFromICCard(Chart_No, Drug1, Drug2, Drug3)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
#End Region

#Region "2009/09/26 取得所有PUB Sheet資料 By James"


    ''' <summary>
    ''' 程式說明：取得所有PUB Sheet資料
    ''' 開發人員：James
    ''' 開發日期：2009.09.26
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <使用表單>
    ''' 1.James-PUB_Sheet
    ''' </使用表單>
    ''' <修改註記>
    ''' </修改註記>
    Public Function queryPUBSheet() As DataSet
        Dim instance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
        Try
            Return instance.queryPUBSheet()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function


#End Region

#Region "20090724 add by Rich, 過敏藥品查詢"

    Public Function queryPUBPatientAllergyByCond(ByRef pk_Chart_No As System.String) As System.Data.DataSet
        Dim instance As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try
            Return instance.queryPUBPatientAllergyByCond(pk_Chart_No)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20090918 一般醫令查詢 by Alan"


    ''' <summary>
    ''' 程式說明：取得一般醫令 
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.18
    ''' </summary> 
    Public Function queryPUBOrderByCond(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal Specimen As String, ByVal Body_Site As String) As DataSet
        Try
            Dim instance As PUBOrderBO_E1 = New PUBOrderBO_E1
            Return instance.queryPUBOrderAllTypeByCond(OrderCode, OrderName, OrderTypeId, Specimen, Body_Site)

        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderByLanguage(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String) As DataSet
        Try
            Dim instance As PUBOrderBO_E1 = New PUBOrderBO_E1
            Return instance.queryPUBOrderAllTypeByCond2(OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag)

        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String) As DataSet
        Try
            Dim instance As PUBOrderBO_E1 = New PUBOrderBO_E1
            Return instance.queryPUBOrderAllTypeByCond3(SourceType, OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag, ChartNo, OutpatientSn)

        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryPUBOrderIsDC(ByVal inOrderCode As String) As DataSet
        Try
            Dim instance As PUBOrderBO_E1 = New PUBOrderBO_E1
            Return instance.queryPUBOrderIsDC(inOrderCode)

        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#Region "20100730 add by Rich, OPHPhraseBO_E1"

    ''' <summary>
    ''' queryPhraseNameByOPHRuleReason
    ''' </summary>
    ''' <param name="OPH_Rule_Reason"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As OPHPhraseBO_E1 = OPHPhraseBO_E1.getInstance
            Return instance.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason, conn)
        Catch ex As Exception
            Throw ex
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
    Public Function RuleDynamicQueryNotPub(ByRef sqlString As String) As System.Data.DataSet
        Try
            Dim instance As OPHPhraseBO_E1 = OPHPhraseBO_E1.getInstance
            Return instance.dynamicQuery(sqlString)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbErrorMsg(FunctName & ex.Message, ex)
            Throw ex
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
    Public Function PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(ByVal Chart_No As String, ByVal Outpatient_Sn As String) As DataSet
        Try
            Dim _instance As OMOMedicalRecordBO_E1 = OMOMedicalRecordBO_E1.getInstance
            Return _instance.PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(Chart_No, Outpatient_Sn)
        Catch ex As Exception
            Throw ex
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
    Public Function QuerySameKineMedicine(ByVal Phamarcy12code As String) As DataSet
        Try
            Dim instance As OPHRuleItemBO_E1 = OPHRuleItemBO_E1.getInstance
            Return instance.QuerySameKineMedicine(Phamarcy12code)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:" & ex.Message, Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbErrorMsg(FunctName & ex.Message, ex)
            Throw ex
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
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String, ByVal end_date As String) As DataSet
        Try
            Try
                Dim ds As New DataSet
                Dim pub As EMRMedicineRecordBO_E1 = EMRMedicineRecordBO_E1.getInstance
                Return pub.EMRMedicineRecordRuleQuery(Chart_no, orderCode, Start_Date, end_date)
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "麻醉成癮藥品檢核"
    ''' <summary>
    ''' 程式功能：麻醉成癮藥品與相關檢核
    ''' 開發人員：markwu
    ''' 開發時間：2009/11
    ''' </summary>
    ''' <param name="Chart_no">病歷號</param>
    ''' <param name="orderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal EndDate As Date) As DataSet
        Try
            Try
                Dim ds As New DataSet
                Dim pub As EMRMedicineRecordBO_E1 = EMRMedicineRecordBO_E1.getInstance
                Return pub.EMRMedicineRecordRuleQuery(Chart_no, orderCode, EndDate)
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
    Public Function InsertOPH_Alert_Record(ByVal InputDs As DataSet) As Int32
        Try
            Return PUBRuleEngineAPI.getInstance.InsertOPH_Alert_Record(InputDs)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "20090819 add by Rich 檢核規則 PUBRuleBO_E1"

    Public Function RuleQueryAll() As System.Data.DataSet
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.queryAll
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleInsert(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.insert(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDynamicQuery(ByRef sqlString As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.dynamicQuery(sqlString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDynamicQueryPCS(ByRef sqlString As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleEngineAPI = PUBRuleEngineAPI.getInstance
            Return instance.dynamicQueryForPCS(sqlString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDynamicQueryEmr(ByRef sqlString As String) As System.Data.DataSet
        Try
            Dim instance As PUBDynamicBS = PUBDynamicBS.getInstance
            Return instance.dynamicQueryEmr(sqlString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleQueryByPK(ByRef pk_Rule_Code As System.String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.queryByPK(pk_Rule_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDelete(ByRef pk_Rule_Code As System.String) As Integer
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.delete(pk_Rule_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleUpdate(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Return instance.update(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function dynamicQueryForEis(ByRef SQLStr As String) As DataSet
        Try
            Dim instance As PUBDynamicBS = PUBDynamicBS.getInstance
            Return instance.dynamicQueryForEis(SQLStr)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20090819 add by Rich 檢核規則 PUBRuleDetailBO_E1"

    Public Function RuleDetailQueryAll() As System.Data.DataSet
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.queryAll
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailInsert(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.insert(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailDynamicQuery(ByRef sqlString As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.dynamicQuery(sqlString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailQueryByPK(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.queryByPK(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailDelete(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As Integer
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.delete(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailUpdate(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim instance As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Return instance.update(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20091216 add by Rich, PUBRuleBS"

    Public Function getCallFormDS(ByVal RuleCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.getCallFormDS(RuleCode, conn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleExpressionStrQuery(ByVal RuleCode As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleExpressionStrQuery(RuleCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleDetailQuery(ByVal RuleCode As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleDetailQuery(RuleCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCheckRuleDS(ByVal RuleCode As String, ByVal ValueData As String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.getCheckRuleDS(RuleCode, ValueData, Source, Main_Identity_Id, Base_Date, conn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleClassQuery(ByVal RuleCode As String, ByVal ValueData As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleClassQuery(RuleCode, ValueData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleQueryByCond(ByRef pk_Rule_Code As System.String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleQueryByCond(pk_Rule_Code, Source, Main_Identity_Id, Base_Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleCodeTransfer1(ByVal OrderCode As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleCodeTransfer1(OrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RuleCodeTransfer2(ByVal Insu_Code As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.RuleCodeTransfer2(Insu_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryItemName(ByVal Item_Code As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.queryItemName(Item_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryRuleValueData(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.queryRuleValueData(Item_Code, Value_Data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryClassAndField(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.queryClassAndField(Item_Code, Value_Data)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryRuleCode(ByVal Item_Code As String, ByVal Value_Data As String, ByVal Base_Date As String) As System.Data.DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.queryRuleCode(Item_Code, Value_Data, Base_Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 搜尋歷史醫令
    ''' </summary>
    ''' <param name="Medical_Sn">就醫序號</param>
    ''' <param name="SystemType">系統歸屬 {O}門診 or {E}急診 or {I}住院</param>
    ''' <param name="Location">C , P  , S</param>
    ''' <returns>所有歷史醫令的資料集</returns>
    ''' <remarks>by Rich on 2012-05-30</remarks>
    Public Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet
        Try
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            Return instance.GetCurrentOrderset(Medical_Sn, SystemType, Location)
        Catch ex As Exception
            Throw ex
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
    Public Function queryInsuCodeByOrderCode(ByVal OrderCodeDS As DataSet, Optional ByVal BasicDate As String = "") As DataSet
        Try
            Dim instance As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
            Return instance.queryInsuCodeByOrderCode(OrderCodeDS, BasicDate)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "將健保碼轉換為成大碼資料集"

    ''' <summary>
    ''' 將健保碼轉換為成大碼資料集
    ''' </summary>
    ''' <param name="InsuCode"></param>
    ''' <param name="OrderDate"></param>
    ''' <param name="DistinctInsuCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Ext_InsuCode_To_OrderCodeDs(ByVal InsuCode As String, _
                                                ByVal OrderDate As Date, _
                                                ByVal DistinctInsuCode As Boolean) As DataSet
        Try
            Dim PUBRuleEngineAPI As PUBRuleEngineAPI = New PUBRuleEngineAPI

            Return PUBRuleEngineAPI.Ext_InsuCode_To_OrderCodeDs(InsuCode, OrderDate, DistinctInsuCode)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "2015/06/01 單張報表描述檔維護(Pub_Report_Desc) by ChenYu.Guo"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescdelete(ByRef pk_Report_ID As System.String) As Integer

        Dim m_PubReportDesc As PubReportDescBO_E1 = New PubReportDescBO_E1
        Try

            Return m_PubReportDesc.delete(pk_Report_ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region


#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByLikeColumn(ByRef reportID As String, ByRef reportName As String, ByRef SystemCode As String) As DataSet

        Dim m_PubReportDesc As PubReportDescBO_E1 = New PubReportDescBO_E1
        Try

            Return m_PubReportDesc.QueryByLikeColumn(reportID, reportName, SystemCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region


#Region "     QueryByPK "
    ''' <summary>
    ''' QueryByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByPK(ByRef pk_Report_ID As System.String) As System.Data.DataSet

        Dim m_PubReportDesc As PubReportDescBO_E1 = New PubReportDescBO_E1
        Try

            Return m_PubReportDesc.queryByPK(pk_Report_ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"QueryByPK"})

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubReportDesc As PubReportDescBO_E1 = New PubReportDescBO_E1
        Try

            Return m_PubReportDesc.insert(ds)
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
    ''' <returns>Integer</returns>    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubReportDesc As PubReportDescBO_E1 = New PubReportDescBO_E1
        Try

            Return m_PubReportDesc.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

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
    Public Function PubPrintRecordQueryPrintRecord(ByRef reportID As String, ByRef reportName As String, ByRef createUse As String, ByRef createTime As String, ByRef endTime As String, ByRef printIP As String) As DataSet

        Dim m_PubPrintRecord As PubPrintRecordBO_E1 = New PubPrintRecordBO_E1
        Try

            Return m_PubPrintRecord.QueryPrintRecord(reportID, reportName, createUse, createTime, endTime, printIP)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region

#Region "     將列印報表、預覽報表的資料 新增至 PUB_Print_Record "
    ''' <summary>
    ''' 將列印報表、預覽報表的資料 新增至 PUB_Print_Record
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function insertRPTPrintClient(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubPrintRecord As PubPrintRecordBO_E1 = New PubPrintRecordBO_E1
        Try

            Return m_PubPrintRecord.insertRPTPrintClient(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

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
    Public Function PubPatientBodyRecorddelete(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As Integer

        Dim m_PubPatientBodyRecord As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatientBodyRecord.delete(pk_Chart_No, pk_Measure_Time)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region


#Region "     以PK查詢 "
    ''' <summary>
    ''' 以PK查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordQueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As System.Data.DataSet

        Dim m_PubPatientBodyRecord As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatientBodyRecord.queryByPK(pk_Chart_No, pk_Measure_Time)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以PK查詢"})

        End Try

    End Function

#End Region


#Region "     以病歷號、來源別、登錄單位查詢 "
    ''' <summary>
    ''' 以病歷號、來源別、登錄單位查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Overloads Function PubPatientBodyRecordqueryPubPatientBodyrecordByCond(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, ByVal ChartNo As String) As System.Data.DataSet

        Dim m_PubPatientBodyRecord As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatientBodyRecord.queryPubPatientBodyrecordByCond(gblSourceTypeId, gblKeyinUnit, ChartNo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以病歷號、來源別、登錄單位查詢"})

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubPatientBodyRecord As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatientBodyRecord.insert(ds)
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
    ''' <returns>Integer</returns>    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubPatientBodyRecord As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatientBodyRecord.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#End Region

#Region "2013-03-21 add by 嚴崑銘"
    ''' <summary>
    ''' 取得 Pub_Config 設定值
    ''' </summary>
    ''' <param name="configName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPubConfigValue(ByVal configName As String) As String
        Dim ds = Me.queryPubConfigWhereConfigNameEquals(configName)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            If IsDBNull(ds.Tables(0).Rows(0)("Config_Value")) Then
                Return ""
            Else
                Return ds.Tables(0).Rows(0)("Config_Value").ToString.Trim
            End If
        End If

        Return ""
    End Function

    ''' <summary>
    ''' 取得 Pub_Config 設定值是否代表已生效
    ''' </summary>
    ''' <param name="configName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPubConfigActive(ByVal configName As String) As Boolean
        Dim check() As String = {"True", "Yes", "Y", "ON", "1"}
        Dim config = Me.GetPubConfigValue(configName)
        If IsDate(config) Then
            Return IIf(Now.CompareTo(CDate(config)) >= 0, True, False)
        Else
            Return check.Any(Function(a) a.Equals(config, StringComparison.CurrentCultureIgnoreCase))
        End If
    End Function

    Public Function CheckIdNo(ByVal strIdNo As String, ByRef outputIdNo As String, Optional ByVal chkFlag As Integer = 0) As Integer

        Try
            Dim PubApi As New PUBAPI
            Return PubApi.CheckIdNo(strIdNo, outputIdNo, chkFlag)
        Catch ex As Exception

            Throw ex
        End Try


    End Function

#End Region

#Region "2015-06-29 遠端報表列印 by Lits ADD"
    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportConfigByReportId(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim bo As New PCSIpConfigBO_E1
        Try
            Return bo.queryReportConfigByReportId(inReportId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportMode(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim bo As New PCSIpConfigBO_E1
        Try
            Return bo.queryReportMode(inReportId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' ''' <summary>
    ' ''' 取得報表列印資訊
    ' ''' </summary>
    ' ''' <param name="repprtID"></param>
    ' ''' <param name="conn"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function getReportInfo(ByVal repprtID As String, ByVal printerType As String, ByVal printerCond As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
    '    Dim bo As New PUBPrintConfigBO_E1
    '    Try
    '        Return bo.getReportInfo(repprtID, printerType, printerCond)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    ''' <summary>
    ''' 取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="inStationNo"></param>
    ''' <param name="inTermCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportAllConfig(ByVal inReportId As String, ByVal inStationNo As String, ByVal inTermCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim bo As New PCSIpConfigBO_E1
        Dim PrintCondDS1, PrintCondDS2, PrintConfigDS1, PrintConfigDS2 As New DataSet
        Dim pvtReportMode As String
        Try
            PrintCondDS1 = bo.queryStationByTermCode(inTermCode)
            PrintCondDS2 = bo.queryPrintCondByStation(inStationNo)
            PrintConfigDS1 = bo.queryReportConfigByReportId(inReportId)
            pvtReportMode = bo.queryReportMode(inReportId)

            PrintConfigDS2.Tables.Add("PUB_Print_Config2")
            PrintConfigDS2.Tables(0).Columns.Add("Print_Type")
            PrintConfigDS2.Tables(0).Rows.Add()
            PrintConfigDS2.Tables(0).NewRow()
            PrintConfigDS2.Tables(0).Rows(0).Item("Print_Type") = pvtReportMode


            Using ds As DataSet = New DataSet
                ds.Merge(PrintCondDS1)
                ds.Merge(PrintCondDS2)
                ds.Merge(PrintConfigDS1)
                ds.Merge(PrintConfigDS2)
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If (PrintCondDS1 IsNot Nothing) Then PrintCondDS1.Dispose()
            If (PrintCondDS2 IsNot Nothing) Then PrintCondDS2.Dispose()
            If (PrintConfigDS1 IsNot Nothing) Then PrintConfigDS1.Dispose()
            If (PrintConfigDS2 IsNot Nothing) Then PrintConfigDS2.Dispose()

        End Try
    End Function

#End Region

#Region "2015/07/10 報表維護資料(PUB_Print_Config 與 PUB_Report_Desc) by Kaiwen,Hsiao"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfiginsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPrintConfig As PUBPrintConfigBO_E1 = New PUBPrintConfigBO_E1
        Try

            Return m_PUBPrintConfig.insert(ds)
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
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigupdate(ByVal dsPubPrintConfig As System.Data.DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer

        Dim m_PUBPrintConfig As PUBPrintConfigBS = New PUBPrintConfigBS
        Try

            Return m_PUBPrintConfig.PUBPrintConfigBSUpdate(dsPubPrintConfig, dsPubReportDesc)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "

    Public Function PUBPrintConfigdelete(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As Integer

        Dim m_PUBPrintConfig As PUBPrintConfigBS = New PUBPrintConfigBS

        Try
            Return m_PUBPrintConfig.PUBPrintConfigBSDelete(pk_Report_Id, pk_Print_Type, pk_Print_Cond)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigqueryAll() As System.Data.DataSet

        Dim m_PUBPrintConfig As PUBPrintConfigBO_E1 = New PUBPrintConfigBO_E1
        Try

            Return m_PUBPrintConfig.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region

#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet

        Dim m_PUBPrintConfig As PUBPrintConfigBO_E1 = New PUBPrintConfigBO_E1
        Try

            Return m_PUBPrintConfig.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"動態查詢"})

        End Try

    End Function

#End Region

#Region "     報表列印記錄檔查詢 "
    ''' <summary>
    ''' 報表列印記錄檔查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigQueryByLikeColumn(ByVal Report_Id As String, ByVal Print_Type As String, ByVal Print_Cond As String, ByVal Printer_Name As String, ByVal Paper_Size As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_PUBPrintConfig As PUBPrintConfigBO_E1 = New PUBPrintConfigBO_E1
        Try

            Return m_PUBPrintConfig.PrintConfigQueryByLikeColumn(Report_Id, Print_Type, Print_Cond, Printer_Name, Paper_Size)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"報表列印記錄檔查詢"})

        End Try

    End Function

#End Region

#Region "     新增 PUB_Print_Config、PUB_Report_Desc 資料 "

    ''' <summary>
    ''' 新增 PUB_Print_Config、PUB_Report_Desc 資料
    ''' </summary>

    Public Function PUBPrintConfigBSInsert(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer

        Dim m_PUBPrintConfig As PUBPrintConfigBS = New PUBPrintConfigBS
        Try

            Return m_PUBPrintConfig.PUBPrintConfigBSInsert(dsPubPrintConfig, dsPubReportDesc)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function

#End Region


#End Region

#Region "     大分科所屬細分科統計 "
    ''' <summary>
    ''' 大分科所屬細分科統計
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-07-15</remarks>
    Public Function queryPUBDepartmentCount() As DataSet

        Dim m_PUBDepartment As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
        Try

            Return m_PUBDepartment.queryPUBDepartmentCount()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"大分科所屬細分科統計"})

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
    Public Function PubOrderqueryByOrderCode(ByVal strOrderCode As String, ByVal dc As String, ByVal judgeDate As String) As DataSet

        Dim m_PubOrder As PUBOrderBO_E1 = New PUBOrderBO_E1
        Try

            Return m_PubOrder.queryByOrderCode(strOrderCode, dc, judgeDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢醫令項目基本檔"})

        End Try

    End Function

#End Region


#End Region

#Region "2015/08/02 病患註記(PUB_Patient_Flag) by Alan.Tsai"

#Region "     病患註記維護 "

    ''' <summary>
    ''' 資料新增
    ''' </summary>
    ''' <param name="inSource_Type">來源別(O：門診、E：急診、I：住院、空白：僅寫入PUB_Patient_Flag)</param>
    ''' <param name="inChart_No">病歷號</param>
    ''' <param name="inMedical_Sn">就醫號</param>
    ''' <param name="inFlag_Id">特殊註記代碼(需驗證是否存在PUB_SysCode.Type_Id='30')</param>
    ''' <param name="inCreate_Uer">建立人員</param>
    ''' <param name="inIs_SyncToPUB">是否同步至PUB_Patient_Flag</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function insertPatientFlag(ByVal inSource_Type As String, ByVal inChart_No As String, _
                                      ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                                      ByVal inCreate_Uer As String, ByVal inIs_SyncToPUB As String) As DataSet

        Dim m_PubPatientFlagBS As PubPatientFlagBS = New PubPatientFlagBS

        Try
            Return m_PubPatientFlagBS.insertPatientFlag(inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, inCreate_Uer, inIs_SyncToPUB)

        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增病患註記"})

        End Try

    End Function

    ''' <summary>
    ''' 資料刪除 
    ''' </summary>
    ''' <param name="inSource_Type">來源別(O：門診、E：急診、I：住院、空白：僅刪除PUB_Patient_Flag)</param>
    ''' <param name="inChart_No">病歷號</param>
    ''' <param name="inMedical_Sn">就醫號</param>
    ''' <param name="inFlag_Id">特殊註記代碼(需驗證是否存在PUB_SysCode.Type_Id='30')</param>
    ''' <param name="inCancel_User">刪除人員</param>
    ''' <param name="inIs_SyncToPUB">是否同步刪除PUB_Patient_Flag</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function deletePatientFlag(ByVal inSource_Type As String, ByVal inChart_No As String, _
                                      ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                                      ByVal inCancel_User As String, ByVal inIs_SyncToPUB As String) As DataSet

        Dim m_PubPatientFlagBS As PubPatientFlagBS = New PubPatientFlagBS

        Try
            Return m_PubPatientFlagBS.deletePatientFlag(inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, inCancel_User, inIs_SyncToPUB)

        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增病患註記"})

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
    Public Function PUBReportAlarminsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.insert(ds)
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
    ''' <returns>Integer</returns>    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function PUBReportAlarmupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "

    Public Function PUBReportAlarmdelete(ByRef pk_Report_ID As System.String) As Integer

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1

        Try
            Return m_PUBReportAlarm.delete(pk_Report_ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region "     查詢報表警示設定維護檔 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByLikeColumn(ByVal Report_ID As String, ByVal Report_Name As String, ByVal Rpt_Alarm_Count As String, ByVal Rpt_Is_Active As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.PUBReportAlarmQueryByLikeColumn(Report_ID, Report_Name, Rpt_Alarm_Count, Rpt_Is_Active)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"報表列印記錄檔查詢"})

        End Try

    End Function

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢PK資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByPK(ByVal Report_ID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.queryByPK(Report_ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"報表列印記錄檔查詢"})

        End Try

    End Function

#End Region

#Region "     查詢報表ID-初始化Combobox "

    ''' <summary>
    ''' 查詢報表ID-初始化Combobox
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryReportId() As DataSet

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.PUBReportAlarmQueryReportId()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢系統縮寫名稱"})

        End Try

    End Function

#End Region

#Region "     查詢 Alarm Count "

    ''' <summary>
    ''' 查詢 Alarm Count
    ''' </summary>
    ''' <returns>Integer</returns>    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmCountQuery(ByVal Report_ID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PUBReportAlarm As PUBReportAlarmBO_E1 = New PUBReportAlarmBO_E1
        Try

            Return m_PUBReportAlarm.PUBReportAlarmCountQuery(Report_ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢 Alarm Count"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/08/07 科診查詢 by Alan.Tsai"

#Region "     科診查詢 "
    Public Function queryPubDeptSectByCond(ByVal strDeptCode As String, ByVal strSectId As String) As System.Data.DataSet

        Dim m_PubDeptSectBO_E1 As PUBDeptSectBO_E1 = PUBDeptSectBO_E1.getInstance

        Try
            Return m_PubDeptSectBO_E1.queryPubDeptSectByCond(strDeptCode, strSectId)

        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#End Region

#Region "     科別查詢 "
    Public Function queryByBelongDeptCode(ByRef Belong_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim instance As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

        Try
            Return instance.queryByBelongDeptCode(Belong_Dept_Code, conn)
        Catch ex As Exception
            Throw ex
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
    Public Function QueryInOneYearAdmonishRecord(ByRef ChartNo As String) As DataSet

        Dim m_PUBPatientPersonalHabits As PubPatientPersonalHabitsBO_E1 = New PubPatientPersonalHabitsBO_E1
        Try

            Return m_PUBPatientPersonalHabits.QueryInOneYearAdmonishRecord(ChartNo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢該病患最近一年內的勸戒之記錄"})

        End Try

    End Function

#End Region

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientPersonalHabits As PubPatientPersonalHabitsBO_E1 = New PubPatientPersonalHabitsBO_E1
        Try
            CheckAndUpdateOmoPreventationHealthCare(ds)
            Return m_PUBPatientPersonalHabits.insert(ds)
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
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientPersonalHabits As PubPatientPersonalHabitsBO_E1 = New PubPatientPersonalHabitsBO_E1
        Try
            CheckAndUpdateOmoPreventationHealthCare(ds)
            Return m_PUBPatientPersonalHabits.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsqueryByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet

        Dim m_PUBPatientPersonalHabits As PubPatientPersonalHabitsBO_E1 = New PubPatientPersonalHabitsBO_E1
        Try

            Return m_PUBPatientPersonalHabits.queryByPK(pk_Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region

#Region "吸菸嚼檳榔更新OMO_Preventation_Health_Care IC95"

    Public Sub CheckAndUpdateOmoPreventationHealthCare(ByVal ds As DataSet)
        Try

            Dim Chart_No As String = ds.Tables(0).Rows(0).Item("Chart_No").ToString.Trim
            Dim Outpatient_Sn As String = ds.Tables(0).Rows(0).Item("Outpatient_Sn").ToString.Trim
            Dim Is_Will As String = "Y"

            If Not (ds.Tables(0).Rows(0).Item("Smoke_Id").ToString.Trim = "1" OrElse ds.Tables(0).Rows(0).Item("Eat_Nut_Id").ToString.Trim = "1" OrElse ds.Tables(0).Rows(0).Item("Eat_Nut_Id").ToString.Trim = "3") Then
                Is_Will = "N"
            End If
            Dim UpdateString As String = "Update  OMO_Preventation_Health_Care Set Is_Will ='" & Is_Will & "' , Outpatient_Sn='" & Outpatient_Sn & "' , Remind_Cnt='1' where Chart_No ='" & Chart_No & "' and Care_Order_Code ='95' And Care_Cardseq ='IC95' and Effect_Date <='" & Now.ToShortDateString & "' And '" & Now.ToShortDateString & "'<=End_Date "
            DynamicSQL(False, UpdateString)
        Catch ex As Exception
        End Try

    End Sub


    '動態查詢---2012-10-23 高秀玲
    Public Function DynamicSQL(ByVal blnQuery As Boolean, ByVal strSQL As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim dsReturn As DataSet = New DataSet

        Dim connFlag As Boolean = conn Is Nothing

        If connFlag Then
            conn = getConnection()
        End If

        Try

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = strSQL
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                If blnQuery Then
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(dsReturn)
                    End Using
                Else
                    If conn.State <> ConnectionState.Open Then conn.Open()
                    Dim dtResult As DataTable = New DataTable
                    dtResult.Columns.Add()
                    Dim drResult As DataRow = dtResult.NewRow
                    drResult(0) = command.ExecuteNonQuery
                    dtResult.Rows.Add(drResult)
                    dsReturn.Tables.Add(dtResult)
                End If
            End Using

        Catch ex As SqlException
            Throw ex
        Finally
            If connFlag Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If

        End Try

        Return dsReturn

    End Function

    ''' <summary>
    '''取得資料庫連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region

#End Region

#Region "2015/08/12 TOCC問卷(PUB_Patient_TOCC) by ChenYu.Guo"

#Region "     查詢是否存在該患當日之記錄 "
    ''' <summary>
    ''' 查詢是否存在該患當日之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function QueryTodayPatientTOCCRecord(ByRef ChartNo As String) As DataSet

        Dim m_PUBPatientTOCC As PubPatientToccBO_E1 = New PubPatientToccBO_E1
        Try

            Return m_PUBPatientTOCC.QueryTodayPatientTOCCRecord(ChartNo)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢是否存在該患當日之記錄"})

        End Try

    End Function

#End Region

#Region "     新增TOCC問卷結果 "
    ''' <summary>
    ''' 新增TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen.Yu on 2015-08-14</remarks>
    Public Function PUBPatientTOCCinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientTOCC As PubPatientToccBO_E1 = New PubPatientToccBO_E1
        Try

            Return m_PUBPatientTOCC.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增TOCC問卷結果"})

        End Try

    End Function

#End Region

#Region "     修改TOCC問卷結果 "
    ''' <summary>
    ''' 修改TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Public Function PUBPatientTOCCupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientTOCC As PubPatientToccBO_E1 = New PubPatientToccBO_E1
        Try

            Return m_PUBPatientTOCC.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/08/21 診間查詢form診間誤餐登記(PUB_Zone_Room) by ChenYu.Guo"

#Region "     queryPUBZoneRoomForMissMeal "
    ''' <summary>
    ''' queryPUBZoneRoomForMissMeal
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-21</remarks>
    Public Function queryPUBZoneRoomForMissMeal(ByVal Room_Code As String) As DataSet

        Dim m_PUBZoneRoom As PUBZoneRoomBO_E1 = New PUBZoneRoomBO_E1
        Try

            Return m_PUBZoneRoom.queryPUBZoneRoomForMissMeal(Room_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"queryPUBZoneRoomForMissMeal"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/09/02 報表列印工作 Add By Charles"

    ''' <summary>
    ''' 報表列印工作檔新增並且檔案上傳
    ''' </summary>
    ''' <param name="ds">存檔資料</param>
    ''' <returns>無</returns>
    ''' <author>Alan</author>
    ''' <date>2015-09-02</date>    
    ''' <remarks></remarks>
    Public Function insertPrintJobData(ByVal ds As System.Data.DataSet) As Integer
        Try
            Return PUBPrintJobBS.GetInstance.insertPrintJobData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"insertPrintJobData"})

        End Try
    End Function

    ''' <summary>
    ''' 列印報表並更新報表狀態(For Batch)
    ''' </summary>
    ''' <param name="JobID">JobID</param>
    ''' <param name="UserID">使用者ID</param>
    ''' <author>Charles</author>
    ''' <date>2015-09-02</date>    
    ''' <remarks></remarks>
    Public Sub PUBReportJobProcess(ByVal JobID As String, ByVal UserID As String)
        Try
            PUBPrintJobThreadBS.GetInstance.PUBReportJobProcess(JobID, UserID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PUBReportJobProcess"})
        End Try
    End Sub

#End Region


#Region "2015/09/02 PUBPrintJobQueryUI(報表執行進度查詢) Add By Charles "

    Public Function queryPUBPrintJobByCond(ByVal cond As DataTable) As DataSet
        Try
            Return PUBPrintJobBO_E1.getInstance.queryPUBPrintJobByCond(cond)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"queryPUBPrintJobByCond"})
        End Try
    End Function
    Public Function queryPUBPrintJobReportType() As DataSet
        Try
            Return PUBPrintJobBO_E1.getInstance.queryPUBPrintJobReportType()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"queryPUBPrintJobReportType"})
        End Try
    End Function
    Public Function queryPUBPrintJobReportByType(ByVal reportType As String, ByVal userId As String) As DataSet
        Try
            Return PUBPrintJobBO_E1.getInstance.queryPUBPrintJobReportByType(reportType, userId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"queryPUBPrintJobReportByType"})
        End Try
    End Function

    Public Function increaseDownloadCnt(ByVal JobID As String) As Integer
        Try
            Return PUBPrintJobBO_E1.getInstance.increaseDownloadCnt(JobID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"increaseDownloadCnt"})
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
    Public Function PUBConfigQueryExpandWeek() As DataSet

        Dim m_PUBConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PUBConfig.QueryExpandWeek()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查診展班週數"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/09/28 查詢看診目的(PUB_Medical_Type_Id) by Will,Lin"

#Region "     查詢看診目的 "
    ''' <summary>
    ''' 查詢看診目的
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Will,Lin</remarks>
    Public Function getPUBMedicalTypeId() As DataSet

        Dim k9 As PUBAPI = New PUBAPI
        Try

            Return k9.getPUBMedicalTypeId()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢看診目的"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/09/29 取得藥品名稱自動搜尋視窗的藥品資料 by ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品名稱自動搜尋視窗的藥品資料
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyBase(ByRef orderName As String) As DataTable

        Dim m_PUBPatientAllergyBO As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
        Try

            Return m_PUBPatientAllergyBO.Get_PharmacyBase(orderName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得藥品名稱自動搜尋視窗的藥品資料"})

        End Try

    End Function

#End Region

#Region "2015/09/29 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料 by ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料(原Get_PharmacyClass)
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyClassAndCompositionAndATC(ByVal orderName As String, ByVal NameType As String) As DataTable

        Dim m_PUBPatientAllergyBO As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance

        Try

            Return m_PUBPatientAllergyBO.Get_PharmacyClassAndCompositionAndATC(orderName, NameType)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得藥品分類自動搜尋視窗的藥品資料"})

        End Try

    End Function

#End Region

#Region "2015/09/10 查詢TOCC關閉視窗之控制(PUB_Config) by ChenYu.Guo"

#Region "     查詢TOCC關閉視窗之控制 "
    ''' <summary>
    ''' 查詢TOCC關閉視窗之控制
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Public Function PUBConfigQueryTOCCCloseWindows() As String

        Dim m_PUBConfig As PubConfigBO_E1 = New PubConfigBO_E1
        Try

            Return m_PUBConfig.QueryTOCCCloseWindows()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢TOCC關閉視窗之控制"})

        End Try

    End Function

#End Region

#End Region

#Region "2015/10/07 藥師查詢 By Lits"
    Public Function QueryPharinfo(ByVal dutyid As String) As DataSet
        Return PUBSysCodeBO_E1.getInstance.QueryPharmacy(dutyid)
    End Function

#End Region

#Region "2015/11/11 看診目的基本檔維護作業(PUB_Medical_Type) by Eddie,Lu"

#Region "     一般查詢 "
    ''' <summary>
    ''' 一般查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequery(ByRef medicalTypeId As String, ByRef medicalTypeName As String, ByRef medicalTypeCtrlId As String, ByRef disIdentityCode As String, ByRef Contract_Code1 As String, ByRef Contract_Code2 As String, ByRef partCode As String, ByRef cardSn As String, ByRef icMedicalTypeId As String, ByRef caseTypeId As String, ByVal pedSort As Integer, ByVal surSort As Integer, ByVal medSort As Integer, ByVal entSort As Integer, ByVal uroSort As Integer, ByRef rehSort As Integer, ByVal ipdSort As Integer, ByVal opdSort As Integer, ByVal emgSort As Integer) As DataSet

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.query(medicalTypeId, medicalTypeName, medicalTypeCtrlId, disIdentityCode, Contract_Code1, Contract_Code2, partCode, cardSn, icMedicalTypeId, caseTypeId, pedSort, surSort, medSort, entSort, uroSort, rehSort, ipdSort, opdSort, emgSort)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"一般查詢"})

        End Try

    End Function

#End Region


#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypedelete(ByRef pk_Medical_Type_Id As System.String) As Integer

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.delete(pk_Medical_Type_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.insert(ds)
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
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryAll() As System.Data.DataSet

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region

#Region "     取得Cbo資料 "
    ''' <summary>
    ''' 取得Cbo資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryCboData() As DataSet

        Dim m_PUBMedicalType As PubMedicalTypeBO_E1 = New PubMedicalTypeBO_E1
        Try

            Return m_PUBMedicalType.queryCboData()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Cbo資料"})

        End Try

    End Function

#End Region

#End Region

#Region "Patient Schedule BO"
    Dim m_pubPatientScheduleBO As PubPatientScheduleBO_E1 = PubPatientScheduleBO_E1.getInstance

    Public Function PubPatientScheduleQueryByKeys(ByVal _chartNo As String, ByVal _bookDateBegin As Date) As DataSet
        Try
            Return m_pubPatientScheduleBO.QueryByKeys(_chartNo, _bookDateBegin)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function PubPatientScheduleDeleteByKeys(ByRef pk_Chart_No As System.String, ByRef pk_Book_Date As System.DateTime, ByRef pk_Book_Time As System.String, ByRef pk_CheckIn_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Return m_pubPatientScheduleBO.DeleteByKeys(pk_Chart_No, pk_Book_Date, pk_Book_Time, pk_CheckIn_Dept_Code, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function PubPatientScheduleQueryByPK2(ByRef pk_Chart_No As System.String, ByRef pk_Book_Date As System.DateTime, ByRef pk_Book_Time As System.String, ByRef pk_CheckIn_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Try
            Return m_pubPatientScheduleBO.QueryByPK2(pk_Chart_No, pk_Book_Date, pk_Book_Time, pk_CheckIn_Dept_Code, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "2010-05-29 Pub_Patient_ScheduleBO_E1, Added by Ken"

    ''' <summary>
    ''' 刪除一筆Schedule, For醫令排程
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="BookDate">預約日期</param>
    ''' <param name="BookTime">預約時間</param>
    ''' <param name="CheckInDeptCode">報到科別</param>
    ''' <param name="CheckInSectionId">報到診別</param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <remarks></remarks>
    Public Function PubPatientScheduleDeleteByKeysForOrderSchedule(ByVal ChartNo As String, ByVal BookDate As Date, ByVal BookTime As String, ByVal CheckInDeptCode As String, ByVal CheckInSectionId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Try
            Return PubPatientScheduleBO_E1.getInstance.DeleteByKeysForOrderSchedule(ChartNo, BookDate, BookTime, CheckInDeptCode, CheckInSectionId, conn)
        Catch ex As Exception

            Throw ex
        End Try
    End Function
#End Region

#Region "2016/04/19 Add by Kaiwen, 排除藥費(PUBExcludeDrugSetBO_E1) "

    ' ''' <summary>
    ' ''' 初始排除藥費資料
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks>Add By Jen</remarks>
    'Public Function initPUBExclusiveDrugSetUIInfo() As DataSet
    '    Dim instance As PUBExclusiveDrugSetBS = PUBExclusiveDrugSetBS.getInstance
    '    Try
    '        Return instance.initPUBExclusiveDrugSetUIInfo()
    '    Catch ex As Exception
    '        log.Error(ex.Message)
    '        Throw ex
    '    End Try
    'End Function

    ''' <summary>
    ''' 查詢排除藥費
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryExclusiveDrugSetData(ByVal OrderCode As String) As DataTable
        Dim instance As PUBExclusiveDrugSetBS = PUBExclusiveDrugSetBS.getInstance
        Try
            Return instance.queryExclusiveDrugSetData(OrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryExclusiveDrugSetData2(ByVal OrderCode As String) As DataTable
        Dim instance As PUBExcludeDrugSetBO_E1 = PUBExcludeDrugSetBO_E1.getInstance
        Try
            Return instance.queryExclusiveDrugSetData2(OrderCode)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 新增排除藥費
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function insertExclusiveDrugSetByOrderCode(ByVal OrderCode As String, ByVal insertData As DataSet) As Integer
        Dim instance As PUBExcludeDrugSetBO_E1 = PUBExcludeDrugSetBO_E1.getInstance
        Try
            Return instance.insertExclusiveDrugSetByOrderCode(OrderCode, insertData)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "2016/04/19 Add by Kaiwen, 找多個TypeId的syscode (PUBNhiIndexSetUI)【查詢Syscode(多筆)】 "

    ''' <summary>
    ''' 找多個TypeId的syscode
    ''' </summary>
    ''' <param name="TypeIds"></param>
    ''' <returns></returns>
    ''' <remarks>Add by Kaiwen</remarks>
    Public Function querySyscodeByTypeIds(ByVal TypeIds() As Integer) As DataTable

        Try
            Return PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "2016/04/19 查詢健保支付標準檔資料(PUBNhiCodeBO) , Added by Kaiwen"

    ''' <summary>
    ''' 查詢健保支付標準檔資料
    ''' </summary>
    Public Function queryPubNhiCodeEffectData(ByVal inEffectDate As String, ByVal inInsuCode As String, ByVal inOrderCode As String) As DataTable
        Try

            Dim instance As PUBNhiCodeBO_E1 = PUBNhiCodeBO_E1.getInstance
            Return instance.queryPubNhiCodeEffectData(inEffectDate, inInsuCode, inOrderCode)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "2016/04/19 醫療支付公用主檔 (醫令控制畫面) , Added by Kaiwen"


    ''' <summary>
    ''' 初始醫令控制資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBOrderInfo(ByVal initType As String) As DataSet
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.initPUBOrderInfo(initType)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 醫令資料查詢(含醫令，醫令價格)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.queryOrderData(OrderCode, EffectDate)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 檢查醫令的特殊處理狀態
    ''' </summary>
    ''' <param name="OldOrderDT"></param>
    ''' <param name="NewOrderDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function checkProcessStatus(ByVal OldOrderDT As DataTable, ByVal NewOrderDT As DataTable) As DataSet
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.checkProcessStatus(OldOrderDT, NewOrderDT)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 確認醫令相關資料
    ''' </summary>
    ''' <param name="OrderRelatedData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function commitOrderRelatedData(ByVal OrderRelatedData As DataSet) As Integer
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.commitOrderRelatedData(OrderRelatedData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：查詢醫令上一筆(下一筆)資料
    ''' 開發人員：Jen
    ''' 開發日期：2010.03.01
    ''' </summary>
    ''' <param name="partialOrderCode">部分醫令碼</param>
    ''' <param name="orderTypeId">醫令分類碼</param>
    ''' <param name="isPre">找上一筆?</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2010/03/10, XXX
    ''' </修改註記>
    Public Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataSet
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.queryPreOrNextRecordOrder(partialOrderCode, orderTypeId, isPre)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataSet
        Dim instance As PUBOrderBS = PUBOrderBS.getInstance
        Try
            Return instance.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "2016/04/19 舊程式OPHPB_BS、PRI_PBC , Added by Kaiwen"

#Region "2016/04/19 由Order_Code查詢藥品碼資料(舊程式OPHPB_queryPharmacyBaseByOrderCode(OrderCode)), Added by Kaiwen"

    ''' <summary>
    ''' 由Order_Code查詢藥品碼資料
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPharmacyBaseByOrderCode(ByVal OrderCode As String) As DataTable
        Try
            Dim instance As PUBMedicineBO_E1 = PUBMedicineBO_E1.GetInstance
            Return instance.queryPharmacyBaseByOrderCode(OrderCode)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

#End Region

#Region "2016/04/19 更新前審查項目基本資料 , Added by Kaiwen"

    ''' <summary>
    ''' 更新前審查項目基本資料
    ''' </summary>
    ''' <param name="updateData">傳入更新資料</param>
    ''' <returns>0：無任何錯誤，其它則為更新錯誤</returns>
    ''' <remarks></remarks>
    Public Function UpdateReviewOrder(ByVal updateData As DataSet) As Integer
        Try
            Dim instance As PUBMedicineBO_E1 = PUBMedicineBO_E1.GetInstance
            Return instance.UpdateReviewOrder(updateData)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

#End Region

#End Region

#Region "2016/04/19  依醫令刪除所有相關表格資料 Log ,add by Kaiwen "

    Public Function deletePUBOrderLog(ByVal inOrderCode As String, ByVal inOrderName As String, ByVal inOrderTypeId As String, ByVal inOrderMode As String, ByVal inExecutionUser As String) As Integer
        Try
            Dim instance As PUBOrderBS = PUBOrderBS.getInstance
            Return instance.deletePUBOrderLog(inOrderCode, inOrderName, inOrderTypeId, inOrderMode, inExecutionUser)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function deletePUBOrderByOrderCode(ByVal inOrderCode As String) As Integer
        Try
            Dim instance As PUBOrderBS = PUBOrderBS.getInstance
            Return instance.deletePUBOrderByOrderCode(inOrderCode)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "2016/04/19  PUBAddQueryUI ,add by Kaiwen"

    ''' <summary>
    ''' 程式說明：孩童加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd(ByVal Order_Code As String) As DataTable
        Try
            Dim KidAddQUERYDS As DataTable = PUBKidAddBS.getInstance.QueryAdd(Order_Code)
            Return KidAddQUERYDS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：急件加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_EMG(ByVal Order_Code As String) As DataTable
        Try
            Dim EMGAddQUERYDS As DataTable = PUBKidAddBS.getInstance.QueryAdd_EMG(Order_Code)
            Return EMGAddQUERYDS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：牙科轉診加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_Dental(ByVal Order_Code As String) As DataTable
        Try
            Dim DentalAddQUERYDS As DataTable = PUBKidAddBS.getInstance.QueryAdd_Dental(Order_Code)
            Return DentalAddQUERYDS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：科別加成查詢
    ''' </summary>
    ''' <param name="Order_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable
        Try
            Dim DeptAddQUERYDS As DataTable = PUBKidAddBS.getInstance.QueryAdd_Dept(Order_Code)
            Return DeptAddQUERYDS

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "2016/04/19  PUBInsuCodeBO , Added by Kaiwen"
    ''' <summary>
    ''' 查詢資料
    ''' </summary>
    Public Function queryPubInsuCodeEffectData(ByVal inEffectDate As String, ByVal inOrderTypeId As String, ByVal inOrderCode As String) As DataTable
        Try
            Dim instance As PUBInsuCodeBO_E1 = PUBInsuCodeBO_E1.getInstance
            Return instance.queryPubInsuCodeEffectData(inEffectDate, inOrderTypeId, inOrderCode)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/04/22   取得群組醫令, Added by Kaiwen "

    ''' <summary>
    ''' 取得群組醫令
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryAddOrderData(ByVal AddOrderCode As String) As DataTable

        Try
            Return PUBAddOrderBO_E1.getInstance.queryAddOrderData(AddOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 移除群組醫令
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function removeAddOrderData(ByVal AddOrderCode As String) As Integer
        Try
            Return PUBAddOrderBO_E1.getInstance.removeAddOrderData(AddOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得群組醫令細目
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryAddOrderDetailData(ByVal AddOrderCode As String) As DataTable
        Try
            Return PUBAddOrderDetailBO_E1.getInstance.queryAddOrderDetailData(AddOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：移除群組醫令明細
    ''' 開發人員：Jen
    ''' 開發日期：2009.10.31
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Add_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/10/31, XXX
    ''' </修改註記>
    Public Function removeAddOrderDetailData(ByVal AddOrderCode As String) As Integer
        Try
            Return PUBAddOrderDetailBO_E1.getInstance.removeAddOrderDetailData(AddOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：查詢群組醫令替代
    ''' 開發人員：Jen
    ''' 開發日期：2009.10.31
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Add_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/10/31, XXX
    ''' </修改註記>
    Public Function queryAddOptionOrderData(ByVal AddOrderCode As String, ByVal AddOrderDetailNo As Integer) As DataTable
        Try
            Return PUBAddOptionOrderBO_E1.getInstance.queryAddOptionOrderData(AddOrderCode, AddOrderDetailNo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：移除群組醫令替代
    ''' 開發人員：Jen
    ''' 開發日期：2009.10.31
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <param name="AddOrderDetailNo">群組醫令序號</param>
    ''' <param name="OptionOrderCode">替代醫令碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Add_Option_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/10/31, XXX
    ''' </修改註記>
    Public Function removeAddOptionOrderData(ByVal AddOrderCode As String, ByVal AddOrderDetailNo As Integer, ByVal OptionOrderCode As String) As Integer

        Try
            Return PUBAddOptionOrderBO_E1.getInstance.removeAddOptionOrderData(AddOrderCode, AddOrderDetailNo, OptionOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' InsertTo AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAddOrder(ByVal ds As DataSet) As Integer
        Try
            Return PUBOrderBS.getInstance.UpdateAddOrder(ds)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Delete AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="addOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteAddOrder(ByVal addOrderCode As String) As Integer
        Try
            Return PUBOrderBS.getInstance.deleteAddOrder(addOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/04/25 檢驗表單維護 PubLisSheet by Kaiwen"

    Public Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32
        Try
            Return PUBSheetBO_E1.getInstance.insert(InputData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PubLisSheetUpdate(ByVal UpdateData As DataSet) As Int32
        Try
            Return PUBSheetBO_E1.getInstance.update(UpdateData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PubLisSheetDelete(ByVal SheetCode As String) As Int32

        Return PUBSheetBO_E1.getInstance.delete(SheetCode)
    End Function

    Public Function PubLisSheetQuery(ByVal SheetCode As String, _
                                     ByVal SheetName As String, _
                                     ByVal DeptCode As String, _
                                     ByVal SheetContactTel As String) As DataSet

        Return PUBLisSheetBS.GetInstance.Query(SheetCode, _
                                               SheetName, _
                                               DeptCode, _
                                               SheetContactTel)
    End Function

#Region "     以ＰＫ查詢資料 "

    Public Function PubSheetQueryByPK(ByVal pk_Sheet_Code As String, ByVal pk_Sheet_Name As System.String, ByVal pk_Dept_Code As System.String) As DataSet

        Try
            Return PUBSheetBO_E1.getInstance.PubSheetQueryByPK(pk_Sheet_Code, pk_Sheet_Name, pk_Dept_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "     以ＰＫ Like 的方式查詢資料 "

    Public Function PubSheetQueryByLikePK(ByVal pk_Sheet_Code As String) As DataSet

        Try
            Return PUBSheetBO_E1.getInstance.PubSheetQueryByLikePK(pk_Sheet_Code)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#End Region

#Region "2016/04/25  PubDepartment by Kaiwen"
    ''' <summary>
    ''' 取得小分科(k)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentBySmallDept() As DataSet
        Dim m_pubDepartment As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

        Try
            Return m_pubDepartment.queryPUBDepartmentBySmallDept()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '依來源別(O,E,I)取得小分科
    Public Function queryPUBDepartmentBySourceType(ByVal inSourceType As String) As DataSet
        Dim m_pubDepartment As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

        Try
            Return m_pubDepartment.queryPUBDepartmentBySourceType(inSourceType)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得所有科室代碼與名稱(不分大小分科)(k)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentAllDept() As DataSet
        Dim m_pubDepartment As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance

        Try
            Return m_pubDepartment.queryPUBDepartmentAllDept()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/04/26  PUBExaminationSheetDetailMaintainBS 檢驗醫令明細維護, Added by Kaiwen"

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainGetInitInfo(ByVal User As String) As DataSet
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.GetInitInfo(User)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 依據輸入之Sheet Code, 找出此Sheet中所包含之Order.
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainGetOrderList(ByVal SheetCode As String) As DataSet
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.GetOrderListBySheetCode(SheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得Order之詳細資料
    ''' </summary>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainGetOrderInfo(ByVal OrderCode As String) As DataSet
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.GetOrderInfo(OrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 將修改過的資訊寫回資料庫
    ''' </summary>
    ''' <param name="InputData">欲寫入之資料庫</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainWriteBackEditedInfo(ByVal InputData As DataSet, ByVal User As String) As Int32
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.WriteBackEditedInfo(InputData, User)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢Pub_Sheet_Detail中符合輸入條件之資料
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainQuerySheetDetail(ByVal SheetCode As String, ByVal OrderCode As String) As DataSet
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.QuerySheetDetailBySheetAndOrderCode(SheetCode, OrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 新增一筆Order至Pub_Sheet_Detail
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(ByVal InputData As DataSet) As Int32
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.InsertIntoPubSheetDetail(InputData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 將Pub_Sheet_Code中符合條件的資料Dc掉
    ''' </summary>
    ''' <param name="InputData">欲Dc之資料</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(ByVal InputData As DataSet, ByVal User As String) As Int32
        Try
            Return PUBExaminationSheetDetailMaintainBS.GetInstance.UpdateDcOfPubSheetDetail(InputData, User)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/04/26  檢查表單維護, Added by Kaiwen"

    ''' <summary>
    ''' 表單代碼下拉選單與資訊
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function initSheetData() As DataSet
        Try
            Dim instance As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance
            Return instance.initSheetData
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 表單明細資訊
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function querySheetDetailData(ByVal SheetCode As String) As DataTable
        Try
            Dim instance As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance
            Return instance.querySheetDetailData(SheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 確認資料
    ''' </summary>
    ''' <param name="sheetDS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function confirmSheetData(ByVal sheetDS As DataSet) As Boolean
        Try
            Dim instance As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance
            Return instance.confirmSheetData(sheetDS)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢符合開頭字串醫令
    ''' </summary>
    ''' <param name="LikeOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable
        Try
            Dim instance As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance
            Return instance.queryLikeOrderData(LikeOrderCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "2016/04/28 PUBRisFormMaintainSheetDetailUI, Added by Kaiwen"

    ''' <summary>
    ''' 新增一筆資料至Pub_Sheet_Detail與Pub_Order_Examination
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32
        Try
            Dim _bs As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance

            Return _bs.InsertIntoPubSheetDetailAndPubOrderExamination(InputData, User)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 自Pub_Sheet_Detail與Pub_Order_Examination刪除一筆資料
    ''' </summary>
    ''' <param name="InputData">欲刪除之資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteFromPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32
        Try
            Dim _bs As PUBRisFormMaintainBS = PUBRisFormMaintainBS.getInstance

            Return _bs.DeleteFromPubSheetDetailAndPubOrderExamination(InputData, User)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得可用之表單
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBRisFormMaintainGetAvalibleSheet(ByVal User As String) As DataSet
        Try
            Return PUBRisFormMaintainBS.getInstance.GetAvalibleSheet(User)
        Catch ex As Exception
            Throw ex
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

    Public Function PUBSheetDisplayInsert(ByVal ds As DataSet) As Integer
        Try
            Dim p1 As PubSheetDisplayBO_E1 = New PubSheetDisplayBO_E1
            Return p1.insert(ds)
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
    ''' <remarks>by Eddie,Lu on 2016-01-22</remarks>
    Public Function PUBSheetDisplayUpdate(ByVal ds As DataSet) As Integer

        Dim p1 As PubSheetDisplayBO_E1 = New PubSheetDisplayBO_E1

        Try

            Return p1.update(ds)

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
    Public Function PUBSheetDisplayDelete(ByRef pk_Sheet_Type_Id As System.String, ByRef pk_Sheet_Main_Display As System.String, ByRef pk_Sheet_Sub_Display As System.String) As Integer

        Dim p1 As PubSheetDisplayBO_E1 = New PubSheetDisplayBO_E1

        Try

            Return p1.delete(pk_Sheet_Type_Id, pk_Sheet_Main_Display, pk_Sheet_Sub_Display)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region " 查詢"

    Public Function QueryPubSheetDisplayByCond(ByVal Sheet_Type_Id As String, ByVal Sheet_Main_Display As String, ByVal Sheet_Sub_Display As String) As DataSet
        Try
            Dim p1 As PubSheetDisplayBO_E1 = New PubSheetDisplayBO_E1
            Return p1.QueryPubSheetDisplayByCond(Sheet_Type_Id, Sheet_Main_Display, Sheet_Sub_Display)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region


#End Region

#Region "2016/05/20 表單開單顯示醫令檔基本資料維護 added by Roger "

#Region " 新增"

    ''' <summary>
    ''' 表單開單顯示醫令檔基本資料維護_新增
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function PUBSheetDisplayOrderInsert(ByVal ds As DataSet) As Integer
        Try
            Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1
            Return p1.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region " 修改"
    ''' <summary>
    ''' 表單開單顯示醫令檔基本資料維護_修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-01-22</remarks>
    Public Function PUBSheetDisplayOrderUpdate(ByVal ds As DataSet) As Integer

        Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1

        Try

            Return p1.update(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function
#End Region

#Region " 刪除"

    ''' <summary>
    '''表單開單顯示醫令檔基本資料維護_刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayOrderDelete(ByRef pk_Sheet_Sub_Display As System.String, ByRef pk_Order_Display_Code As System.String) As Integer

        Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1

        Try

            Return p1.delete(pk_Sheet_Sub_Display, pk_Order_Display_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region " 查詢"

    Public Function QueryPubSheetDisplayOrderByCond(ByVal Sheet_Sub_Display As String, ByVal Order_Code As String, ByVal Order_Display_Code As String, ByVal Order_Display_Name As String) As DataSet
        Try
            Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1
            Return p1.QueryPubSheetDisplayOrderByCond(Sheet_Sub_Display, Order_Code, Order_Display_Code, Order_Display_Name)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region

#Region "查詢全部"
    Public Function QuerySheetDisplayOrderAll() As System.Data.DataSet
        Try
            Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1
            Return p1.QuerySheetDisplayOrderAll()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "取得ComboBox資料"
    Public Function QueryPubSheetDisplayOrderCombodata(ByVal MainBodySite As String) As DataSet
        Try
            Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1
            Return p1.QueryPubSheetDisplayOrderCombodata(MainBodySite)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#End Region

#Region "          是否重複資料查詢"
    Public Function QuerySheetDisplayOrderCheckDS(ByVal strOrderCode As String, ByVal strMainBodySite As String, ByVal strBodySite As String, ByVal strSiteID As String) As System.Data.DataSet
        Try
            Dim p1 As PubSheetDisplayOrderBO_E1 = New PubSheetDisplayOrderBO_E1
            Return p1.QuerySheetDisplayOrderCheckDS(strOrderCode, strMainBodySite, strBodySite, strSiteID)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region


#End Region

#Region "2016/05/12 PUBPostalCodeSetupUI 郵遞區號設定維護"

#Region " 新增"
    ''' <summary>
    ''' 郵遞區號設定維護新增
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBPostalCodeInsert(ByVal ds As DataSet) As Integer

        Try
            Dim p1 As PUBPostalCodeBO_E1 = PUBPostalCodeBO_E1.getInstance
            Return p1.insert(ds)



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region " 修改"
    ''' <summary>
    ''' 郵遞區號設定維護修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-01-22</remarks>
    Public Function PUBPostalCodeupdate(ByVal ds As DataSet) As Integer



        Try
            Dim m_PUBPostalCode As PUBPostalCodeBO_E1 = PUBPostalCodeBO_E1.getInstance
            Return m_PUBPostalCode.update(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function
#End Region

#Region " 刪除"

    ''' <summary>
    '''郵遞區號設定維護以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBPostalCodedelete(ByVal Postal_Code As String) As Integer


        Try
            Dim m_PostalCode As PUBPostalCodeBO_E1 = PUBPostalCodeBO_E1.getInstance
            Return m_PostalCode.delete(Postal_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try
    End Function


#End Region

#Region " 查詢"


    ''' <summary>
    ''' 郵遞區號設定維護查詢
    ''' </summary>
    ''' <param name="Postal_Code">郵遞區號</param>
    ''' <param name="Postal_Name">郵遞區號名稱</param>
    ''' <param name="County_Name">縣市名稱</param>
    ''' <param name="Town_Name">鄉鎮區</param>
    ''' <returns></returns>
    ''' <exception cref="Syscom.Comm.EXP.CommonException">CMMCMMB302</exception>
    Public Function PUBPostalCodequery(ByVal Postal_Code As String, ByVal Postal_Name As String, ByVal County_Name As String, ByVal Town_Name As String) As System.Data.DataSet


        Try
            Dim m_PostalCode As PUBPostalCodeBO_E1 = PUBPostalCodeBO_E1.getInstance
            Return m_PostalCode.QueryPubPostalCode(Postal_Code, Postal_Name, County_Name, Town_Name)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
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
    Public Function PUBPatientDNRinsertWithDNRNo(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientDNR As PubPatientDnrBO_E1 = New PubPatientDnrBO_E1
        Try

            Return m_PUBPatientDNR.insertWithDNRNo(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增With DNR流水號"})

        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryByPKROC(ByRef pk_Chart_No As System.String, ByRef strDNRKindId As System.String) As System.Data.DataSet

        Dim m_PUBPatientDNR As PubPatientDnrBO_E1 = New PubPatientDnrBO_E1
        Try

            Return m_PUBPatientDNR.queryByPKROC(pk_Chart_No, strDNRKindId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ查詢資料"})

        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRdelete(ByRef pk_Chart_No As System.String, ByRef pk_Source_Kind As System.String, ByRef pk_DNR_No As System.Int32) As Integer

        Dim m_PUBPatientDNR As PubPatientDnrBO_E1 = New PubPatientDnrBO_E1
        Try

            Return m_PUBPatientDNR.delete(pk_Chart_No, pk_Source_Kind, pk_DNR_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ刪除資料"})

        End Try

    End Function

#End Region


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryCboDs() As DataSet

        Dim m_PUBPatientDNR As PubPatientDnrBO_E1 = New PubPatientDnrBO_E1
        Try

            Return m_PUBPatientDNR.queryCboDs()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得ComboBox資料"})

        End Try

    End Function

#End Region


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientDNR As PubPatientDnrBO_E1 = New PubPatientDnrBO_E1
        Try

            Return m_PUBPatientDNR.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

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
    Public Function PUBPatFlagSortdelete(ByRef pk_Flag_Id As System.String) As Integer

        Dim m_PUBPatFlagSort As PubPatFlagSortBO_E1 = New PubPatFlagSortBO_E1
        Try

            Return m_PUBPatFlagSort.delete(pk_Flag_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ刪除資料"})

        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryByPKROC(ByRef pk_Flag_Id As System.String, ByRef strFlagSortId As System.String) As System.Data.DataSet

        Dim m_PUBPatFlagSort As PubPatFlagSortBO_E1 = New PubPatFlagSortBO_E1
        Try

            Return m_PUBPatFlagSort.queryByPKROC(pk_Flag_Id, strFlagSortId)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ查詢資料"})

        End Try

    End Function

#End Region


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryCboDs() As DataSet

        Dim m_PUBPatFlagSort As PubPatFlagSortBO_E1 = New PubPatFlagSortBO_E1
        Try

            Return m_PUBPatFlagSort.queryCboDs()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得ComboBox資料"})

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatFlagSort As PubPatFlagSortBO_E1 = New PubPatFlagSortBO_E1
        Try

            Return m_PUBPatFlagSort.insert(ds)
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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatFlagSort As PubPatFlagSortBO_E1 = New PubPatFlagSortBO_E1
        Try

            Return m_PUBPatFlagSort.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#End Region

#Region "20090902 add by Alan 表單主檔(PUB_Sheet)"
    Dim m_PUBSheetBOE1 As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance

    Public Function queryPUBSheetDeptData() As DataSet
        Try
            Dim instance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
            Return instance.queryPUBSheetDeptData()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPUBSheetDeptSheetData() As DataSet
        Try
            Dim instance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
            Return instance.queryPUBSheetDeptSheetData()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPUBSheetSheetData(ByVal DeptCode As String) As DataSet
        Try
            Dim instance As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
            Return instance.queryPUBSheetSheetData(DeptCode)
        Catch ex As Exception
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
    Public Function queryPUBSheetSheetSheetCodeByDeptCode(ByVal DeptCode As String) As DataSet
        Try
            Return m_PUBSheetBOE1.querySheetCodeByDeptCode(DeptCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "由表單代碼 Sheet_Code取得表單資訊"

    Public Function queryPubSheetBySheetCode(ByVal SheetCode As String) As DataSet
        Try
            Return Syscom.Server.BO.PubSheetBO.GetInstance.queryByPK(SheetCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱)  By Li.Han"
    ''' <summary>
    ''' 取得中文名稱
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBRulequeryRuleNameByCode(ByVal strSQL As String) As String

        Dim instance As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
        Try

            Return instance.queryRuleNameByCode(strSQL)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得中文名稱"})

        End Try

    End Function
#End Region

#Region "預防保健執行設定維護 BY Roger "
#Region "新增"
    Public Function insertPUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim p1 As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Return p1.insert(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function

#End Region

#Region "修改"
    Public Function updatePUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim p1 As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Return p1.update(ds)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function
#End Region

#Region "刪除"
    Public Function deletePUBPreventiveCareExe(ByRef CareOrderCode As System.String, ByRef PreCareOrderCode As System.String) As Integer
        Try
            Dim p1 As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Return p1.delete(CareOrderCode, PreCareOrderCode)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function
#End Region

#Region "查詢"
    Public Function queryPUBPreventiveCareExeByCond(ByVal PreCareOrderCode As String, ByVal CareOrderCode As String, ByVal AgeControlId As String) As System.Data.DataSet

        Try
            Dim p1 As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Return p1.queryPUBPreventiveCareExeByCond(PreCareOrderCode, CareOrderCode, AgeControlId)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try

    End Function
#End Region

#Region "取得combobox資料"
    Public Function getPUBPreventiveCareExeCombodata() As DataSet
        Try
            Dim p1 As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Return p1.getPUBPreventiveCareExeCombodata()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function
#End Region
#End Region

#Region "2016/06/07 查詢透析院所代號 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 查詢透析院所代號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubHospitalqueryByNow() As System.Data.DataSet

        Dim m_PubHospital As PubHospitalBO_E1 = PubHospitalBO_E1.getInstance
        Try

            Return m_PubHospital.queryByNow()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ查詢資料"})

        End Try

    End Function

#End Region

#Region "2016/06/07 以病歷號查詢關聯表的資料 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 以病歷號查詢關聯表的資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubPatientqueryRelationInfoByPK(ByRef pk_Chart_No As System.String, ByRef pk_Pip_Type As System.String) As System.Data.DataSet

        Dim m_PubPatientqueryRelationInfoByPK As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
        Try

            Return m_PubPatientqueryRelationInfoByPK.queryRelationInfoByPK(pk_Chart_No, pk_Pip_Type)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以病歷號查詢關聯表的資料"})

        End Try

    End Function

#End Region

#Region "2016/06/07 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubPatientBodyrecordQueryByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet

        Dim m_PubPatientBodyrecord As PubPatientBodyrecordBO_E1 = PubPatientBodyrecordBO_E1.getInstance
        Try

            Return m_PubPatientBodyrecord.queryByChartNo(pk_Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ查詢資料"})

        End Try

    End Function

#End Region



#Region "2016/06/13 以 Type_Id 查詢資料 by Gary.Chiang"
    ''' <summary>
    ''' 以 Type_Id 查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Gary on 2016-06-13</remarks>
    Public Function PubSyscodeQueryByTypeId(ByRef pk_Type_Id As System.Int32) As System.Data.DataSet

        Dim m_PubSyscode As PUBSysCodeBO_E1 = New PUBSysCodeBO_E1
        Try

            Return m_PubSyscode.queryByTypeId(pk_Type_Id)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以 Type_Id 查詢資料"})

        End Try
    End Function
#End Region

#Region "2016/06/13 通過Chart_No查詢PUB_Patient_Allergy的資料 by Gary.Chiang"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_Allergy的資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PubPatientAllergyqueryTopByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet

        Dim m_PubPatientAllergy As PUBPatientAllergyBO_E1 = New PUBPatientAllergyBO_E1
        Try

            Return m_PubPatientAllergy.queryByChartNo(pk_Chart_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"通過Chart_No查詢PUB_Patient_Allergy的資料"})

        End Try

    End Function
#End Region

#Region "2016/06/17 病患ISS評估作業(PUBIssItem) By Will"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Public Function PubIssItemInsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientISSBO_E1 As PUBPatientISSBO_E1 = New PUBPatientISSBO_E1
        Try

            Return m_PUBPatientISSBO_E1.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增PUBIssItem的資料"})

        End Try

    End Function

#End Region

#Region "     更新 "
    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Public Function PubIssItemupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientISSBO_E1 As PUBPatientISSBO_E1 = New PUBPatientISSBO_E1
        Try

            Return m_PUBPatientISSBO_E1.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新PUBIssItem的資料"})

        End Try

    End Function

#End Region

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>    ''' <remarks>by Kasim.Jiang on 2015-08-17</remarks>
    Public Function PubIssItemQueryAll() As System.Data.DataSet

        Dim m_PUBIssItemBO_E1 As PUBIssItemBO_E1 = New PUBIssItemBO_E1
        Try

            Return m_PUBIssItemBO_E1.queryAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

    ''' <summary>
    ''' 查詢最近一筆評分資料
    ''' </summary>
    ''' <param name="pk_Chart_No"></param>
    ''' <param name="pk_Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBPatientISSBOqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Medical_Sn As System.String) As DataSet

        Dim m_PUBPatientISSBO_E1 As PUBPatientISSBO_E1 = New PUBPatientISSBO_E1
        Try

            Return m_PUBPatientISSBO_E1.PUBPatientISSBOqueryByPK(pk_Chart_No, pk_Medical_Sn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Medical_Sn"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-01-17</remarks>
    Public Function PubPatientIssDelete(ByVal Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

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
    Public Function PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PubPatient_BodyRecordUpdateHBbyChartNoForMohw As PubPatientBodyrecordBO_E1 = New PubPatientBodyrecordBO_E1
        Try

            Return m_PubPatient_BodyRecordUpdateHBbyChartNoForMohw.UpdateHBbyChartNoForMohw(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新PUBIssItem的資料"})

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
    Public Function insertPubStation(ByVal ds As DataSet) As Integer

        Dim m_PubStation As PubStationBO_E1 = New PubStationBO_E1
        Try

            Return m_PubStation.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增護理站基本檔資料"})

        End Try

    End Function

#End Region

#Region "     修改護理站資料 "
    ''' <summary>
    ''' 修改護理站資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-30</remarks>
    Public Function updatePUBStation(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBStation As PubStationBO_E1 = New PubStationBO_E1
        Try

            Return m_PUBStation.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改護理站資料"})

        End Try

    End Function

#End Region

#Region "     刪除護理站資料 "
    ''' <summary>
    ''' 刪除護理站資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-30</remarks>
    Public Function deletePUBStation(ByRef pk_Station_No As System.String) As Integer

        Dim m_PUBStation As PubStationBO_E1 = New PubStationBO_E1
        Try

            Return m_PUBStation.delete(pk_Station_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除護理站資料"})

        End Try

    End Function

#End Region

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Hanru on 2016-06-30</remarks>
    Public Function queryPUBStationByCond(ByVal pk_Station_No As String) As DataSet

        Dim m_PUBStation As PubStationBO_E1 = New PubStationBO_E1
        Try

            Return m_PUBStation.queryByCond(pk_Station_No)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})

        End Try

    End Function

#End Region


#End Region

#Region "2016/06/30 檢查醫令不須報到部門維護作業(PUB_Order_Exam_Nocheckin_Dept) by Jun"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBOrderExamNocheckinDeptBO As PubOrderExamNocheckinDeptBO_E1 = New PubOrderExamNocheckinDeptBO_E1
        Try

            Return m_PUBOrderExamNocheckinDeptBO.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptdelete(ByRef pk_Order_Code As System.String) As Integer

        Dim m_PUBOrderExamNocheckinDept As PubOrderExamNocheckinDeptBO_E1 = New PubOrderExamNocheckinDeptBO_E1
        Try

            Return m_PUBOrderExamNocheckinDept.PUBOrderExamNocheckinDeptdelete(pk_Order_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region "     取得門急住個別的不需報到科別 "
    ''' <summary>
    ''' 取得門急住個別的不需報到科別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function getInitialOrderExamNoCheckinDept(ByVal orderCode As String) As System.Data.DataSet

        Dim m_PUBOrderExamNocheckinDept As PubOrderExamNocheckinDeptBS = PubOrderExamNocheckinDeptBS.GetInstance()
        Try

            Return m_PUBOrderExamNocheckinDept.getInitialOrderExamNoCheckinDept(orderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得門急住個別的不需報到科別"})

        End Try

    End Function

#End Region

#End Region

#Region "2016/07/13 科室主管檔 add by kudy.sue"
    Public Function queryPubDeptLeaderByCond(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As System.Data.DataSet
        Try
            Return PubDeptLeaderBO_E1.GetInstance.queryPubDeptLeaderByCond(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    '新增
    Public Function insertPubDeptLeader(ByVal dsData As DataSet) As Integer
        Try
            Return PubDeptLeaderBO_E1.GetInstance.insert(dsData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function
    '修改
    Public Function updatePubDeptLeader(ByVal dsData As DataSet) As Integer
        Try
            Return PubDeptLeaderBO_E1.GetInstance.update(dsData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    '刪除
    Public Function deletePubDeptLeader(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As Integer
        Try
            Return PubDeptLeaderBO_E1.GetInstance.delete(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function


#End Region

#Region "20160720  取得ChargeFlag add by James "

    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal dt As DataTable) As System.Data.DataSet
        Try
            Return PUBAPI.getChargeFlag(Source_Id, Main_Identity_Id, Dept_Code, Section_id, dt)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function


    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    ''' <param name="Self_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '1')</param>
    ''' <param name="Nhi_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '2')</param>
    ''' <param name="Is_No_Check_In">PUB_Order_Examination.Is_No_Check_In</param>
    ''' <param name="Include_Order_Mark">PUB_Order.Include_Order_Mark</param>
    ''' <param name="Is_Cure">PUB_Order.Is_Cure</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByVal Self_Charge_Flag As String = "", Optional ByVal Nhi_Charge_Flag As String = "", Optional ByVal Is_No_Check_In As String = "", Optional ByVal Include_Order_Mark As String = "", Optional ByVal Is_Cure As String = "", Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Try
            Return PUBAPI.getChargeFlag(Source_Id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, Self_Charge_Flag, Nhi_Charge_Flag, Is_No_Check_In, Include_Order_Mark, Is_Cure, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Need_Execute屬性(針對檢驗檢查醫令是否需科室執行 (True:需執行 ;False:不用執行))
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    Public Function GetIsNeedExecute(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        Try
            Return PUBAPI.getInstance.GetIsNeedExecute(Source_Id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Function getIsForce(ByVal dt As DataTable) As DataSet
        Try
            Return PUBAPI.getIsForce(dt)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Function getIsForce(ByVal Charge_Flag As String) As String
        Try
            Return PUBAPI.getIsForce(Charge_Flag)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Function getIsCharge(ByVal dt As DataTable) As DataSet
        Try
            Return PUBAPI.getIsCharge(dt)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
        End Try
    End Function


    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Function getIsCharge(ByVal Charge_Flag As String) As String
        Try
            Return PUBAPI.getIsCharge(Charge_Flag)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {""})
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
    Public Function PUBLabIndication04QureyPUBLabIndication04() As DataSet

        Dim m_PUBLabIndication04 As PUBLabIndication04BO = New PUBLabIndication04BO
        Try

            Return m_PUBLabIndication04.QureyPUBLabIndication04()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"特殊屬性輸入元件"})

        End Try

    End Function

    Public Function PUBLabIndication10QureyPUBLabIndication10(ByVal inIDNO As String, ByVal inOrderDate As String) As DataSet

        Dim m_PUBLabIndication10 As PUBLabIndication04BO = New PUBLabIndication04BO
        Try

            Return m_PUBLabIndication10.QureyPUBLabIndication10(inIDNO, inOrderDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"特殊屬性輸入元件"})

        End Try

    End Function

#End Region


#End Region

#Region "2016/08/23 更新病人聯絡資料 Will"
    ''' <summary>
    '''更新病人聯絡資料
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePatContactInfo(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
        Try

            Return m_PUBPatientBO.updatePatContactInfo(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新病人聯絡資料"})

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
    Public Function PUBAccDeptinsert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubAccDeptBO_E1 As PubAccDeptBO_E1 = New PubAccDeptBO_E1
        Try

            Return m_PubAccDeptBO_E1.InsertPubAccDeptData(ds)
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
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptupdate(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubAccDeptBO_E1 As PubAccDeptBO_E1 = New PubAccDeptBO_E1
        Try

            Return m_PubAccDeptBO_E1.UpdatePubAccDeptData(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function QueryPubAccDeptByPK(ByVal tmp As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet

        Dim m_PubAccDeptBO_E1 As PubAccDeptBO_E1 = New PubAccDeptBO_E1
        Try

            Return m_PubAccDeptBO_E1.QueryPubAccDeptByPK(tmp)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region


#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptDelete(ByVal PK As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubAccDeptBO_E1 As PubAccDeptBO_E1 = New PubAccDeptBO_E1
        Try

            Return m_PubAccDeptBO_E1.DeletePubAccDeptData(PK)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region " 2016/10/14 檢核規則維護(PubRuleReason) By Kaiwen "

#Region "     以ＰＫ查詢資料 "

    Public Function queryRuleReasonByRuleCode(ByVal pk_Rule_Code As System.String) As System.Data.DataSet

        Dim m_PubRuleReasonBO_E1 As PubRuleReasonBO_E1 = New PubRuleReasonBO_E1
        Try

            Return m_PubRuleReasonBO_E1.queryRuleReasonByRuleCode(pk_Rule_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢核規則維護"})

        End Try

    End Function

#End Region

#End Region

#Region "     成本中心部門查詢 2016-09-19 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by 承毅 on 2016-09-19</remarks>
    Public Function QueryPubAccDeptName(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet

        Dim m_PubAccDeptBO_E1 As PubAccDeptBO_E1 = New PubAccDeptBO_E1
        Try

            Return m_PubAccDeptBO_E1.QueryPubAccDeptName(conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region


#Region "2016/09/19 轉入健保醫令價格異動檔(PUBNhiCodeImportBO_E1) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1ImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportBO_E1 = New PUBNhiCodeImportBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.ImportCase(ds, strDownload_Sn, strUserId)
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
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1importorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportBO_E1 = New PUBNhiCodeImportBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.importorderprice(ds, struser)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Function PUBNhiCodeImportBOE1query(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportBO_E1 = New PUBNhiCodeImportBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.querydata(strNhi_Download_Sn, strInsu_Code, strEffect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

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
    Public Function queryOrderAlternativeForOEIOtherLack(ByVal OrderCode As String) As DataSet

        Dim m_PUBOrderBS As PUBOrderBS = PUBOrderBS.getInstance
        Try

            Return m_PUBOrderBS.queryOrderAlternativeForOEIOtherLack(OrderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"尋找停用醫令替代項目"})

        End Try

    End Function


    ''' <summary>
    ''' 查詢被DC的醫令
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Public Function queryPUBOrderDC(ByVal inOrderCode As String) As DataSet

        Dim m_PUBOrderBO_E1 As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
        Try

            Return m_PUBOrderBO_E1.queryPUBOrderDC(inOrderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢被DC的醫令"})

        End Try

    End Function
#End Region

#End Region

    ''' <summary>
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingPUBSheet(ByVal currentUser As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet

        Dim m_PUBSheetBO_E1 As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
        Try

            Return m_PUBSheetBO_E1.queryUserMappingPUBSheet(currentUser, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"使用者可用的表單"})

        End Try

    End Function

    ''' <summary>
    ''' 查詢登入使用者可用的表單對應儀器
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingApparatusCode(ByVal currentUser As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet

        Dim m_PUBSheetBO_E1 As PUBSheetBO_E1 = PUBSheetBO_E1.getInstance
        Try

            Return m_PUBSheetBO_E1.queryUserMappingApparatusCode(currentUser, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"使用者可用的表單對應儀器"})

        End Try

    End Function

#Region "20130430 add by Alan, PUBMaterialSelfpayApplyBO"

    Public Function insertPUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer
        Try
            Dim k1 As PUBMaterialSelfpayApplyBO_E1 = PUBMaterialSelfpayApplyBO_E1.GetInstance
            Return k1.insert(dsSaveData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updatePUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer
        Try
            Dim k1 As PUBMaterialSelfpayApplyBO_E1 = PUBMaterialSelfpayApplyBO_E1.GetInstance
            Return k1.update(dsSaveData)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function deletePUBMaterialSelfpayApply(ByVal OrderCode As String, ByVal EffectDate As Date) As Integer
        Try
            Dim k1 As PUBMaterialSelfpayApplyBO_E1 = PUBMaterialSelfpayApplyBO_E1.GetInstance
            Return k1.delete(OrderCode, EffectDate)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPUBMaterialSelfpayApply(ByVal sqlString As String) As DataSet
        Try
            Dim k1 As PUBMaterialSelfpayApplyBO_E1 = PUBMaterialSelfpayApplyBO_E1.GetInstance
            Return k1.dynamicQuery2(sqlString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "20101217 add by Rich, 事前審查適應症查詢"

    Public Function queryPUBOrderByOrderCode(ByVal Order_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim instance As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance

        Try
            Return instance.queryPUBOrderByOrderCode(Order_Code, conn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "PUBZoneRoomBO_E1  區診間維護檔"
    Function queryPUBZoneRoomByCond(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet
        Try
            Return PUBZoneRoomBO_E1.getInstance.queryPUBZoneRoomByCond(strZoneId, strRoomCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢區診間維護檔"})
        End Try
    End Function
    Function insertPUBZoneRoom(ByVal dsSaveData As DataSet) As Integer
        Try
            Return PUBZoneRoomBO_E1.getInstance.insert(dsSaveData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增區診間維護檔"})
        End Try
    End Function
    Function updatePUBZoneRoom(ByVal dsSaveData As DataSet) As Integer
        Try
            Return PUBZoneRoomBO_E1.getInstance.update(dsSaveData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新區診間維護檔"})
        End Try
    End Function
    Function deletePUBZoneRoomByPK(ByVal strZoneId As String, ByVal strRoomCode As String) As Integer
        Try
            Return PUBZoneRoomBO_E1.getInstance.delete(strZoneId, strRoomCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除區診間維護檔"})
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
    Public Function PUBMaterialSelfpayApplyinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBMaterialSelfpayApply As PUBMaterialSelfpayApplyBO_E1 = New PUBMaterialSelfpayApplyBO_E1
        Try

            Return m_PUBMaterialSelfpayApply.insert(ds)
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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBMaterialSelfpayApply As PUBMaterialSelfpayApplyBO_E1 = New PUBMaterialSelfpayApplyBO_E1
        Try

            Return m_PUBMaterialSelfpayApply.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBMaterialSelfpayApplyDelete(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As Integer

        Dim m_PUBMaterialSelfpayApply As PUBMaterialSelfpayApplyBO_E1 = New PUBMaterialSelfpayApplyBO_E1
        Try

            Return m_PUBMaterialSelfpayApply.PUBMaterialSelfpayApplyDelete(pk_Order_Code, pk_Effect_Date)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region

#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <param name="pk_Order_Code"></param>
    ''' <param name="pk_Effect_Date"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubMaterialSelfpayApplyByPK(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet

        Dim m_PUBMaterialSelfpayApply As PUBMaterialSelfpayApplyBO_E1 = New PUBMaterialSelfpayApplyBO_E1
        Try

            Return m_PUBMaterialSelfpayApply.queryPubMaterialSelfpayApplyByPK(pk_Order_Code, pk_Effect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ查詢資料"})

        End Try

    End Function

#End Region

#Region "     以ＰＫ Like 查詢資料 "
    ''' <summary>
    ''' 以ＰＫ Like 查詢資料
    ''' </summary>
    ''' <param name="pk_Order_Code"></param>
    ''' <param name="pk_Effect_Date"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubMaterialSelfpayApplyByPKLike(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet

        Dim m_PUBMaterialSelfpayApply As PUBMaterialSelfpayApplyBO_E1 = New PUBMaterialSelfpayApplyBO_E1
        Try

            Return m_PUBMaterialSelfpayApply.queryPubMaterialSelfpayApplyByPKLike(pk_Order_Code, pk_Effect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以ＰＫ Like 查詢資料"})

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
    Public Function PUBNhiCodeImportMImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportMBO_E1 = New PUBNhiCodeImportMBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.ImportCase(ds, strDownload_Sn, strUserId)
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
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function PUBNhiCodeImportMimportorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportMBO_E1 = New PUBNhiCodeImportMBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.importorderprice(ds, struser)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})

        End Try

    End Function

#End Region


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23</remarks>
    Public Function PUBNhiCodeImportMquery(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet

        Dim m_PUBNhiCodeImportBOE1 As PUBNhiCodeImportMBO_E1 = New PUBNhiCodeImportMBO_E1
        Try

            Return m_PUBNhiCodeImportBOE1.querydata(strNhi_Download_Sn, strInsu_Code, strEffect_Date)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region


#End Region

#Region "2017/03/21 病患傳送風險(PUBPatientTransferRiskUI) by Will,Lin"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function QueryPUBPatientTransferRiskLevel(ByVal strChartNo As String, ByVal strOutpatientSn As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim m_PUBPatientTransferRiskBOE1 As PUBPatientTransferRiskBO_E1 = New PUBPatientTransferRiskBO_E1
        Try

            Return m_PUBPatientTransferRiskBOE1.GetPatientRiskLevel(strChartNo, strOutpatientSn, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function InsertIntoPUBPatientTransferRisk(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PUBPatientTransferRiskBOE1 As PUBPatientTransferRiskBO_E1 = New PUBPatientTransferRiskBO_E1
        Try

            Return m_PUBPatientTransferRiskBOE1.InsertIntoPUBPatientTransferRisk(ds, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function
#End Region

#Region "查詢醫令是否已存在(PUB_Sheet_Detail)"
    Public Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet
        Try
            Return PubSheetDetailBO_E1.getInstance.queryPubSheetDetailByOrderCode(OrderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢醫令"})
        End Try
    End Function
#End Region

#Region "2017/04/06 看診目的排序設定(Pub_Medical_Type_Sort) by Chi,Wang"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function QueryPubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim m_PubMedicalTypeSortBOE1 As PubMedicalTypeSortBO_E1 = New PubMedicalTypeSortBO_E1
        Try

            Return m_PubMedicalTypeSortBOE1.QueryPubMedicalTypeSort(stremployeecode, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function


    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function InsertPubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubMedicalTypeSortBOE1 As PubMedicalTypeSortBO_E1 = New PubMedicalTypeSortBO_E1
        Try

            Return m_PubMedicalTypeSortBOE1.InsertPubMedicalTypeSort(stremployeecode, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function DeletePubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubMedicalTypeSortBOE1 As PubMedicalTypeSortBO_E1 = New PubMedicalTypeSortBO_E1
        Try

            Return m_PubMedicalTypeSortBOE1.DeletePubMedicalTypeSort(stremployeecode, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function UpdatePubMedicalTypeSort(ByVal ds As DataSet, ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim m_PubMedicalTypeSortBOE1 As PubMedicalTypeSortBO_E1 = New PubMedicalTypeSortBO_E1
        Try

            Return m_PubMedicalTypeSortBOE1.UpdatePubMedicalTypeSort(ds, stremployeecode, conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢全部"})

        End Try

    End Function

#End Region

#Region "2017/04/13 檢查醫令不須列印部門維護作業(PUB_Order_Exam_NoPrint_Dept) by Michelle"

#Region "     取得門急住個別的不需列印科別 "
    ''' <summary>
    ''' 取得門急住個別的不需列印科別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function getInitialOrderExamNoPrintDept(ByVal orderCode As String) As DataSet

        Dim m_PUBOrderExamNoPrintDept As PubOrderExamNoPrintDeptBS = New PubOrderExamNoPrintDeptBS
        Try

            Return m_PUBOrderExamNoPrintDept.getInitialOrderExamNoPrintDept(orderCode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得門急住個別的不需列印科別"})

        End Try

    End Function

#End Region


#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptdelete(ByRef pk_Order_Code As System.String) As Integer

        Dim m_PUBOrderExamNoPrintDept As PubOrderExamNoPrintDeptBO_E1 = New PubOrderExamNoPrintDeptBO_E1
        Try

            Return m_PUBOrderExamNoPrintDept.PUBOrderExamNoPrintDeptdelete(pk_Order_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})

        End Try

    End Function

#End Region


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_PUBOrderExamNoPrintDept As PubOrderExamNoPrintDeptBO_E1 = New PubOrderExamNoPrintDeptBO_E1
        Try

            Return m_PUBOrderExamNoPrintDept.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})

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

    Public Function PubDrAddControlInsert(ByVal ds As DataSet) As Integer
        Dim p1 As PubDrAddControlBO_E1 = New PubDrAddControlBO_E1

        Try
            Return p1.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region " 修改"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_修改
    ''' </summary>
    ''' <param name="ds">修改資料</param>
    ''' <returns>更新筆數</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>

    Public Function PubDrAddControlUpdate(ByVal ds As DataSet) As Integer
        Dim p1 As PubDrAddControlBO_E1 = New PubDrAddControlBO_E1

        Try
            Return p1.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
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
    ''' <returns>刪除筆數</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>

    Public Function PubDrAddControlDelete(ByRef pk_Dept_Code As String, ByRef pk_Order_Code As String, ByRef pk_Employee_Code As String) As Integer
        Dim p1 As PubDrAddControlBO_E1 = New PubDrAddControlBO_E1

        Try
            Return p1.delete(pk_Dept_Code, pk_Order_Code, pk_Employee_Code)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
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
    Public Function QueryPubDrAddControlByPK(ByRef deptCode As String, ByRef orderCode As String, ByRef employeeCode As String) As DataSet
        Try
            Dim p1 As PubDrAddControlBO_E1 = New PubDrAddControlBO_E1
            Return p1.QueryPubDrAddControlByPK(deptCode, orderCode, employeeCode)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#End Region

End Class