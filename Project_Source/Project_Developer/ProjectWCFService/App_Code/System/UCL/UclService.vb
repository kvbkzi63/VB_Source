Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.UCL
Imports System.Collections.Generic

' 注意: 若變更此處的類別名稱 "UclService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "UclService" 的參考。
Public Class UclService
    Implements IUclService

    Public Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, Optional ByVal OtherQueryConditionDS As DataSet = Nothing) As DataSet Implements IUclService.queryOpenWindow
        Try
            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryOpenWindow(prmQueryTable, prmCondField, prmCondValue, prmCondType, OtherQueryConditionDS)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#Region "20090409 add by James 戶籍地查詢"

    Function queryUclPostalAreaAll() As DataSet Implements IUclService.queryUclPostalAreaAll
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclPostalAreaAll()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function


    Function queryUclPostalAreaAllNew() As DataSet Implements IUclService.queryUclPostalAreaAllNew
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclPostalAreaAllNew()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

    Public Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As DataSet Implements IUclService.queryUclPUBAreaCodeGovVilCodeName
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclPUBAreaCodeGovVilCodeName(code1, code2, type)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

#End Region

#Region "20090414 add by James 病歷號查詢"
    Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet Implements IUclService.queryUclChartNoByKey
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclChartNoByKey(codeNo, codeType)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function
#End Region

#Region "20090602 add by James, 共用元件-身份別連動設定"

    Function queryUclIdentityInitial() As DataSet Implements IUclService.queryUclIdentityInitial
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclIdentityInitial()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

    Function queryUclIdentityInitial2(ByVal inSourceType As String) As DataSet Implements IUclService.queryUclIdentityInitial2
        Try


            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryUclIdentityInitial2(inSourceType)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

#End Region

    '#Region "20090511 共用元件-ComboBoxGrid  by James"

    '    Function queryOMOFavorByFavorId(ByVal favorId As String, _
    '                                        ByVal doctorDeptCode As String, _
    '                                        ByVal favorTypeId As String, _
    '                                        ByVal favorCategory As String, _
    '                                        ByVal code As String, _
    '                                        ByVal codeName As String _
    '                                      ) As DataSet Implements IUclService.queryOMOFavorByFavorId
    '        Try


    '            Dim oper As UCLDelegate = UCLDelegate.getInstance
    '            Return oper.queryOMOFavorByFavorId(favorId, doctorDeptCode, favorTypeId, favorCategory, code, codeName)
    '        Catch ex As Exception
    '              Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
    '        End Try

    '    End Function



    '隨輸隨選 醫囑診斷 PUB_Disease

    Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IUclService.queryOMOOrderDiagnosis

        Try
            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryOMOOrderDiagnosis(code, codeName, DiseaseTypeId, IsSevereDisease)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

    '隨輸隨選 藥品 OPH_Pharmacy_Base

    Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, Optional ByVal IsEqualMatch As String = "N") As DataSet Implements IUclService.queryOPHPharmacyBase
        Try
            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryOPHPharmacyBase(code, codeName, DrugType, IsEqualMatch)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function


    '隨輸隨選 醫令 PUB_Order     
    Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, Optional ByVal BasicDateStr As String = "") As DataSet Implements IUclService.queryPUBOrder

        Try

            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.queryPUBOrder(OrderCode, OrderEnName, OrderTypeId, BasicDateStr)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try

    End Function

    Function DoUclAction(ByVal ds As DataSet) As DataSet Implements IUclService.DoUclAction
        Try
            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.DoUclAction(ds)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    '#Region "控管項目維護-同類藥"
    '    ''' <summary>
    '    ''' 查詢藥名
    '    ''' </summary>
    '    ''' <param name="Pharmacy_12_code">成大十二碼藥名</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function OPHControlItemQueryDrug(ByVal Pharmacy_12_code As String) As DataSet Implements IUclService.OPHControlItemQueryDrug
    '        Try

    '            Dim oper As UCLDelegate = UCLDelegate.getInstance
    '            Return oper.OPHControlItemQueryDrug(Pharmacy_12_code)
    '        Catch ex As Exception
    '              Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
    '        End Try
    '    End Function
    '#End Region
    '#End Region

#Region "20100121 add by AlanTsai, SMTP設定查詢"

    Function querySMTPData() As DataSet Implements IUclService.querySMTPData
        Try
            Dim oper As UCLDelegate = UCLDelegate.getInstance
            Return oper.querySMTPData()
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

#End Region

    '#Region "2011/01/17, Add By 谷官, UCLIcdCode"

    '    ''' <summary>
    '    ''' 程式說明：取得前3個診斷
    '    ''' 開發人員：谷官
    '    ''' 開發日期：2011.01.17
    '    ''' </summary>
    '    ''' <param name="outpatientSn">看診號</param>
    '    ''' <returns>前3個診斷</returns>
    '    ''' <remarks></remarks>
    '    Public Function get3FrontIcdCode(ByVal outpatientSn As String, ByVal sysFlag As String) As DataTable Implements IUclService.get3FrontIcdCode
    '        Try
    '            Dim instance As UCLIcdCodeBS = UCLIcdCodeBS.getInstance
    '            Return instance.get3FrontIcdCode(outpatientSn, sysFlag)
    '        Catch ex As Exception
    '              Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
    '        End Try
    '    End Function

    '    ''' <summary>
    '    ''' 取得重病資料
    '    ''' </summary>
    '    ''' <param name="chartNo"></param>
    '    ''' <param name="outpatientSn"></param>
    '    ''' <param name="opdVisitDate"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function getIcdDataForChangeIdentityUI(ByVal chartNo As String, ByVal outpatientSn As String, ByVal opdVisitDate As Date, ByVal sysFlag As String) As DataTable Implements IUclService.getIcdDataForChangeIdentityUI
    '        Try
    '            Dim instance As UCLIcdCodeBS = UCLIcdCodeBS.getInstance
    '            Return instance.getIcdDataForChangeIdentityUI(chartNo, outpatientSn, opdVisitDate, sysFlag)
    '        Catch ex As Exception
    '              Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
    '        End Try
    '    End Function
    '#End Region


#Region "2013/02/23 給藥確認提示說明作業(UclHintDataBO) by Sean.Lin"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer Implements IUclService.UclHintDataBOinsert

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOinsert(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As System.Data.DataSet Implements IUclService.UclHintDataBOqueryByPK

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOqueryByPK(pk_UI_Name, pk_Serial)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB911", ex))
        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOdelete(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As Integer Implements IUclService.UclHintDataBOdelete

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOdelete(pk_UI_Name, pk_Serial)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB914", ex))
        End Try

    End Function

#End Region


#Region "     更新資料庫內容 "
    ''' <summary>
    ''' 更新資料庫內容
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer Implements IUclService.UclHintDataBOupdate

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOupdate(ds)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB913", ex))
        End Try

    End Function

#End Region


#Region "     查詢提示資料 "
    ''' <summary>
    ''' 查詢提示資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryData(ByVal UIName As String) As DataSet Implements IUclService.UclHintDataBOqueryData

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOqueryData(UIName)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB911", ex))
        End Try

    End Function

#End Region


#Region "     查詢提示資料全部 "
    ''' <summary>
    ''' 查詢提示資料全部
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-3-6</remarks>
    Public Function UclHintDataBOqueryDataAll() As DataSet Implements IUclService.UclHintDataBOqueryDataAll

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.UclHintDataBOqueryDataAll()

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB911", ex))
        End Try

    End Function

#End Region



#End Region

#Region "2015/04/10 共用元件-片語查詢(UCLPhraseBO_E1)  by Alan.Tsai"

#Region "     片語查詢 "
    ''' <summary>
    ''' 片語查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2015-4-10</remarks>
    Public Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As DataSet Implements IUclService.queryOMOPhraseForUCL

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOPhraseForUCL(UserTypeId, DoctorDeptCode, PhraseTypeId, PhraseKeyStr)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

#End Region

#End Region

#Region "2015/04/16 共用元件-常用醫令查詢(UCLOrderFavorDialogUI)  by Alan.Tsai"

    '1
    Public Function queryOMOOrderFavorInit(ByVal queryData As DataSet) As DataSet Implements IUclService.queryOMOOrderFavorInit

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorInit(queryData)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '2
    Public Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String,
                                              ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String,
                                              ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String,
                                              ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorByCond3

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorByCond3(SourceType, FavorId, FavorTypeId, DoctorDeptCode,
                                                          FavorCategory, OrderCode, OrderName,
                                                          DrugType, PharmacyQueryFlag, ChartNo,
                                                          OutpatientSn, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '3
    Public Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As DataSet Implements IUclService.querySTAPackageDataByCategory

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.querySTAPackageDataByCategory(inCategory, inStation, inCategoryStr, inQueryStr)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '4
    Public Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, Optional ByVal inHospCode As String = "") As DataSet Implements IUclService.queryOMOOrderFavorSheetDept2

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDept2(SourceType, FavorTypeId, inHospCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '5
    Public Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                            ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String,
                                                            ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorSheetDetailByLabGroup

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDetailByLabGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '6
    Public Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                             ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String,
                                                             ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorSheetDetailByExamGroup

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDetailByExamGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    Public Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String,
                                                                    ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String,
                                                                     ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorSheetDetailByExamGroupForKMUH

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDetailByExamGroupForKMUH(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '7
    Public Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String,
                                           ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOFavorCategory2

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOFavorCategory2(SourceType, FavorId, FavorTypeId, DoctorDeptCode, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '8
    Public Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As DataSet Implements IUclService.querySTAPackageDataCategory

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.querySTAPackageDataCategory(inCategory, inStation)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '9
    Public Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorSheetDetailByLab2

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDetailByLab2(SourceType, SheetCode, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '10
    Public Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorSheetDetailByExam2

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorSheetDetailByExam2(SourceType, SheetCode, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '11
    Public Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String,
                                                   ByVal OrderTypeId As String,
                                                   ByVal DrugType As String,
                                                   ByVal FavorId As String,
                                                   ByVal DoctorDeptCode As String,
                                                   ByVal PackageCode As String,
                                                   ByVal ChartNo As String,
                                                   ByVal OutpatientSn As String,
                                                   ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOMOOrderFavorDetailOrder3

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMOOrderFavorDetailOrder3(SourceType, OrderTypeId, DrugType, FavorId, DoctorDeptCode, PackageCode, ChartNo, OutpatientSn, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '12
    Public Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryOPHPharmacyByCond3

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOPHPharmacyByCond3(SourceType, OrderCode, OrderName, DrugType, PharmacyQueryFlag, IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '13
    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String,
                                    ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String,
                                    ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String,
                                    ByVal IsChoiceDcOrder As String) As DataSet Implements IUclService.queryPUBOrderByLanguage3

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId,
                                                         FavorCategory, Specimen, Body_Site,
                                                        Chinese_Flag, ChartNo, OutpatientSn,
                                                        IsChoiceDcOrder)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '14
    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IUclService.queryPUBDiseaseByFavor2

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '15
    Public Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As DataSet Implements IUclService.queryPUBExamItemByOrder

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryPUBExamItemByOrder(inOrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '16
    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet Implements IUclService.queryPUBOrderOwnAndNhiPrice

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryPUBOrderOwnAndNhiPrice(OrderCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '17
    Public Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String,
                                          ByVal DoctorCode As String, ByVal DeptCode As String,
                                          ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclService.queryOMODiagFavorInit

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryOMODiagFavorInit(SourceTypeId, DiagType, DoctorCode, DeptCode, DiagCode, DiagDesc)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function


    '18
    Public Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As DataSet Implements IUclService.queryPUBInsuSubDept

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryPUBInsuSubDept(SourceTypeId, DiagType, InsuDeptCode)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '19
    Public Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclService.queryDiagCategory

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryDiagCategory(DiagType, DiagCode, DiagDesc)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function

    '20
    Public Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As DataSet Implements IUclService.queryICD10Category

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryICD10Category(SourceTypeId, DiagType, IsInsu)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function


    '21
    Public Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String,
                                    ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String,
                                    ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String,
                                    ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclService.queryICDDetail

        Try

            Dim tempDelegate As UCLDelegate = UCLDelegate.getInstance

            Return tempDelegate.queryICDDetail(SelType, SourceTypeId, DiagType, FavorId, DoctorDeptCode, FavorCategory, ICDCode, ICD10ChapterId, InsuDeptCode, InsuSubDeptCode, DiagCode, DiagDesc)

        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("CMMCMMB912", ex))
        End Try

    End Function


#End Region

#Region "2012-06-06 查詢 Print Condition"

    ''' <summary>
    ''' 查詢 Print Condition
    ''' </summary>
    ''' <param name="Param">查詢參數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPrintCondition(ByVal Param As Dictionary(Of String, Object)) As DataSet Implements IUclService.QueryPrintCondition
        Try
            Dim _instance As UCLDelegate = UCLDelegate.getInstance
            Return _instance.QueryPrintCondition(Param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得登入者Term_Code所囑之Print Condition
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLoginUserPrintCond(ByVal Param As Dictionary(Of String, Object)) As DataTable Implements IUclService.GetLoginUserPrintCond
        Try
            Dim _instance As UCLDelegate = UCLDelegate.getInstance
            Return _instance.GetLoginUserPrintCond(Param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
