Imports Syscom.Comm.EXP

Public Class UCLDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As UCLDelegate
        Get
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New UCLDelegate()
    End Class

#End Region

#Region "20090312 代碼或基本檔查詢  by AlanTsai"

    Public Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, Optional ByVal OtherQueryConditionDS As DataSet = Nothing) As DataSet
        Try
            Dim k1 As UCLQueryTextCodeBS = New UCLQueryTextCodeBS
            Return k1.queryOpenWindow(prmQueryTable, prmCondField, prmCondValue, prmCondType, OtherQueryConditionDS)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "20090511 共用元件-ComboBoxGrid  by James"

    Public Function DoUclAction(ByVal ds As DataSet) As DataSet
        Try
            Dim k1 As UCLComboBoxGridBO_E1 = New UCLComboBoxGridBO_E1
            Return k1.DoUclAction(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "20100121 SMTP設定查詢  by AlanTsai"

    Public Function querySMTPData() As DataSet
        Try
            Dim k1 As UCLMailSetupBS = New UCLMailSetupBS
            Return k1.querySMTPData()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "2013/02/23 給藥確認提示說明作業(UclHintDataBO) by Sean.Lin"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.insert(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        End Try

    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As System.Data.DataSet

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.queryByPK(pk_UI_Name, pk_Serial)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOdelete(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As Integer

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.delete(pk_UI_Name, pk_Serial)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        End Try

    End Function

#End Region


#Region "     更新資料庫內容 "
    ''' <summary>
    ''' 更新資料庫內容
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.update(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
        End Try

    End Function

#End Region


#Region "     查詢提示資料 "
    ''' <summary>
    ''' 查詢提示資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryData(ByVal UIName As String) As DataSet

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.queryData(UIName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region


#Region "     查詢提示資料全部 "
    ''' <summary>
    ''' 查詢提示資料全部
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-3-6</remarks>
    Public Function UclHintDataBOqueryDataAll() As DataSet

        Dim m_UclHintDataBO As UclHintDataBO_E1 = New UclHintDataBO_E1
        Try

            Return m_UclHintDataBO.queryDataAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region


#End Region

#Region "20090409 add by James, 戶籍地查詢"
     
    Public Function queryUclPostalAreaAll() As DataSet
        Try
            Dim k1 As UCLPostalAreaBS = New UCLPostalAreaBS
            Return k1.queryUclPostalAreaAll()
        Catch ex As Exception
              Throw ex
        End Try
    End Function

    Public Function queryUclPostalAreaAllNew() As DataSet
        Try
            Dim k1 As UCLPostalAreaBS = New UCLPostalAreaBS
            Return k1.queryUclPostalAreaAllNew()
        Catch ex As Exception
              Throw ex
        End Try
    End Function

    Public Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As DataSet
        Try
            Dim k1 As UCLPostalAreaBS = New UCLPostalAreaBS
            Return k1.queryUclPUBAreaCodeGovVilCodeName(code1, code2, type)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "20090602 add by James, 共用元件-身份別連動設定"
    Public Function queryUclIdentityInitial() As DataSet
        Try
            Dim k1 As UCLIdentityBS = New UCLIdentityBS
            Return k1.queryUclIdentityInitial()
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    Public Function queryUclIdentityInitial2(ByVal inSourceType As String) As DataSet
        Try
            Dim k1 As UCLIdentityBS = New UCLIdentityBS
            Return k1.queryUclIdentityInitial(inSourceType)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

   
#End Region


#Region "20090414 UCRChartNoBS 共用元件-病歷號查詢  by James"

    Public Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet
        Try
            Dim k1 As UCLPatientBS = New UCLPatientBS
            Return k1.queryUclChartNoByKey(codeNo, codeType)
        Catch ex As Exception

            Throw ex
        End Try
         
    End Function

#End Region

#Region "2015/04/10 共用元件-片語查詢(UCLPhraseBO_E1)  by Alan.Tsai"

    Public Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As DataSet
        Try
            Dim k1 As UCLPhraseBO_E1 = New UCLPhraseBO_E1
            Return k1.queryOMOPhraseForUCL(UserTypeId, DoctorDeptCode, PhraseTypeId, PhraseKeyStr)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

#End Region

#Region "2015/04/16 共用元件-常用醫令查詢(UCLOrderFavorDialogUI)  by Alan.Tsai"

    '1
    Public Function queryOMOOrderFavorInit(ByVal queryData As DataSet) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorInit(queryData)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '2
    Public Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, _
                                              ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                              ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String, _
                                              ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorByCond3(SourceType, FavorId, FavorTypeId, DoctorDeptCode, _
                                                FavorCategory, OrderCode, OrderName, _
                                                DrugType, PharmacyQueryFlag, ChartNo, _
                                                OutpatientSn, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '3
    Public Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.querySTAPackageDataByCategory(inCategory, inStation, inCategoryStr, inQueryStr)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '4
    Public Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, Optional ByVal inHospCode As String = "") As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDept2(SourceType, FavorTypeId, inHospCode)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '5
    Public Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                            ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                            ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDetailByLabGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '6
    Public Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                             ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                             ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDetailByExamGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    Public Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                                    ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                                    ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDetailByExamGroupForKMUH(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '7
    Public Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, _
                                           ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOFavorCategory2(SourceType, FavorId, FavorTypeId, DoctorDeptCode, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '8
    Public Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.querySTAPackageDataCategory(inCategory, inStation)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '9
    Public Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDetailByLab2(SourceType, SheetCode, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '10
    Public Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, _
                                                         ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorSheetDetailByExam2(SourceType, SheetCode, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '11
    Public Function queryOMOOrderFavorDetailOrder3(ByVal SourceType As String, _
                                                   ByVal OrderTypeId As String, _
                                                   ByVal DrugType As String, _
                                                   ByVal FavorId As String, _
                                                   ByVal DoctorDeptCode As String, _
                                                   ByVal PackageCode As String, _
                                                   ByVal ChartNo As String, _
                                                   ByVal OutpatientSn As String, _
                                                   ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMOOrderFavorDetailOrder3(SourceType, OrderTypeId, DrugType, FavorId, DoctorDeptCode, PackageCode, ChartNo, OutpatientSn, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '12
    Public Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                            ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOPHPharmacyByCond3(SourceType, OrderCode, OrderName, DrugType, PharmacyQueryFlag, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '13
    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                             ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, _
                                             ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String, _
                                             ByVal IsChoiceDcOrder As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId, _
                                               FavorCategory, Specimen, Body_Site, _
                                               Chinese_Flag, ChartNo, OutpatientSn, IsChoiceDcOrder)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '14
    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '15
    Public Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryPUBExamItemByOrder(inOrderCode)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '隨輸隨選 藥品 OPH_Pharmacy_Base
    Public Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, Optional ByVal IsEqualMatch As String = "N") As DataSet

        Try
            Dim k1 As UCLComboBoxGridBO_E1 = New UCLComboBoxGridBO_E1
            Return k1.queryOPHPharmacyBase(code, codeName, DrugType, IsEqualMatch)
        Catch ex As Exception

            Throw ex
        End Try
    End Function

    '16
    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryPUBOrderOwnAndNhiPrice(OrderCode)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '17
    Public Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String, _
                                          ByVal DoctorCode As String, ByVal DeptCode As String, _
                                          ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryOMODiagFavorInit(SourceTypeId, DiagType, DoctorCode, DeptCode, DiagCode, DiagDesc)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '18
    Public Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryPUBInsuSubDept(SourceTypeId, DiagType, InsuDeptCode)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '19
    Public Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryDiagCategory(DiagType, DiagCode, DiagDesc)
        Catch ex As Exception

            Throw ex
        End Try

    End Function


    '20
    Public Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryICD10Category(SourceTypeId, DiagType, IsInsu)
        Catch ex As Exception

            Throw ex
        End Try

    End Function


    '21
    Public Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String, _
                                   ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, _
                                   ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String, _
                                   ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet
        Try
            Dim k1 As UCLOmOFavorBO_E1 = New UCLOmOFavorBO_E1
            Return k1.queryICDDetail(SelType, SourceTypeId, DiagType, FavorId, DoctorDeptCode, FavorCategory, ICDCode, ICD10ChapterId, InsuDeptCode, InsuSubDeptCode, DiagCode, DiagDesc)
        Catch ex As Exception

            Throw ex
        End Try

    End Function



#End Region

    '隨輸隨選 醫令 PUB_Order
    Public Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, Optional ByVal BasicDateStr As String = "") As DataSet
        Try
            Dim k1 As UCLComboBoxGridBO_E1 = New UCLComboBoxGridBO_E1
            Return k1.queryPUBOrder(OrderCode, OrderEnName, OrderTypeId, BasicDateStr)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '隨輸隨選 醫囑診斷 PUB_Disease
    Public Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "")

        Try
            Dim k1 As UCLComboBoxGridBO_E1 = New UCLComboBoxGridBO_E1
            Return k1.queryOMOOrderDiagnosis(code, codeName, DiseaseTypeId, IsSevereDisease)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "2012-06-06 查詢 Print Condition"

    ''' <summary>
    ''' 查詢 Print Condition
    ''' </summary>
    ''' <param name="Param">查詢參數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPrintCondition(ByVal Param As Dictionary(Of String, Object)) As DataSet
        Try
            Return UclPrintConditionBS.GetInstance.QueryPrintCondition(Param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得登入者Term_Code所囑之Print Condition
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLoginUserPrintCond(ByVal Param As Dictionary(Of String, Object), Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Try
            Return UclPrintConditionBS.GetInstance.GetLoginUserPrintCond(Param)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


#Region "    2016/03/11 Btach Rerun Charles"

    ''' <summary>
    ''' 執行BatchRerun
    ''' </summary>
    ''' <param name="RerunData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RerunTask(ByVal RerunData As DataSet) As DataSet

        Try
            Dim m_UCLBatchBs As UCLBatchBS = New UCLBatchBS
            Return m_UCLBatchBs.RerunTask(RerunData)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"執行BatchRerun"})
        End Try
    End Function

#End Region

End Class
