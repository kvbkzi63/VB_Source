Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.UclServiceReference

Partial Class UclServiceManager

#Region "20090319 add by AlanTsai OpenWindow查詢"

    '==================================================================================================
    '=程式名稱：OpenWindow查詢
    '=程式版本：ver 1.0
    '=開發日期：20090319
    '=開發人員：AlanTsai
    '=備註：Return Data Set
    '==================================================================================================
    Function queryOpenWindow(ByVal prmQueryTable As Integer, ByVal prmCondField As String, ByVal prmCondValue As String, ByVal prmCondType As String, Optional ByVal OtherQueryConditionDS As DataSet = Nothing) As DataSet Implements IUclServiceManager.queryOpenWindow
        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryOpenWindow(prmQueryTable, prmCondField, prmCondValue, prmCondType, OtherQueryConditionDS)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "20090409 add by James 戶籍地查詢"
    '==================================================================================================
    '=程式名稱：戶籍地查詢
    '=程式版本：ver 1.0
    '=開發日期：2009409
    '=開發人員：James
    '=備註：
    '==================================================================================================

    Function queryUclPostalAreaAll() As DataSet Implements IUclServiceManager.queryUclPostalAreaAll
        Dim client As UclServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getUclService()
            ds_return = client.queryUclPostalAreaAll()
            client.Close()
        Catch ex As Exception

            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    '==================================================================================================
    '=程式名稱：戶籍地查詢
    '=程式版本：ver 1.0
    '=開發日期：2009409
    '=開發人員：James
    '=備註：
    '==================================================================================================

    Function queryUclPostalAreaAllNew() As DataSet Implements IUclServiceManager.queryUclPostalAreaAllNew
        Dim client As UclServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getUclService()
            ds_return = client.queryUclPostalAreaAllNew()
            client.Close()
        Catch ex As Exception

            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    Function queryUclPUBAreaCodeGovVilCodeName(ByVal code1 As String, ByVal code2 As String, ByVal type As String) As DataSet Implements IUclServiceManager.queryUclPUBAreaCodeGovVilCodeName
        Dim client As UclServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getUclService()
            ds_return = client.queryUclPUBAreaCodeGovVilCodeName(code1, code2, type)
            client.Close()
        Catch ex As Exception

            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

#End Region

#Region "20090414 add by James 病歷號查詢"
    '==================================================================================================
    '=程式名稱：病歷號查詢
    '=程式版本：ver 1.0
    '=開發日期：2009409
    '=開發人員：James
    '=備註：
    '==================================================================================================

    Function queryUclChartNoByKey(ByVal code As String, ByVal type As String) As DataSet Implements IUclServiceManager.queryUclChartNoByKey
        Dim client As UclServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getUclService()
            ds_return = client.queryUclChartNoByKey(code, type)
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function
#End Region

    '#Region "20090511 共用元件-ComboBoxGrid  by James"

    '    Function queryOMOFavorByFavorId(ByVal favorId As String, _
    '                                       ByVal doctorDeptCode As String, _
    '                                       ByVal favorTypeId As String, _
    '                                       ByVal favorCategory As String, _
    '                                       ByVal code As String, _
    '                                       ByVal codeName As String _
    '                                     ) As DataSet Implements IUclServiceManager.queryOMOFavorByFavorId



    '        Dim client As UclServiceClient
    '        Dim ds_return As DataSet

    '        Try
    '            client = getUclService()
    '            ds_return = client.queryOMOFavorByFavorId(favorId, doctorDeptCode, favorTypeId, favorCategory, code, codeName)
    '            client.Close()
    '        Catch ex As Exception
    '            client.Abort()
    '            Throw ex
    '        End Try

    '        Return ds_return

    '    End Function


    '隨輸隨選 醫囑診斷 PUB_Disease

    Function queryOMOOrderDiagnosis(ByVal code As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IUclServiceManager.queryOMOOrderDiagnosis
        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryOMOOrderDiagnosis(code, codeName, DiseaseTypeId, IsSevereDisease)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    '隨輸隨選 藥品 OPH_Pharmacy_Base

    Function queryOPHPharmacyBase(ByVal code As String, ByVal codeName As String, ByVal DrugType As String, Optional ByVal IsEqualMatch As String = "N") As DataSet Implements IUclServiceManager.queryOPHPharmacyBase
        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryOPHPharmacyBase(code, codeName, DrugType, IsEqualMatch)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    '隨輸隨選 醫令 PUB_Order
    Function queryPUBOrder(ByVal OrderCode As String, ByVal OrderEnName As String, ByVal OrderTypeId As String, Optional ByVal BasicDateStr As String = "") As DataSet Implements IUclServiceManager.queryPUBOrder

        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrder(OrderCode, OrderEnName, OrderTypeId, BasicDateStr)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try


    End Function


    '隨輸隨選 醫令 PUB_Order
    Function DoUclAction(ByVal ds As DataSet) As DataSet Implements IUclServiceManager.DoUclAction
        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.DoUclAction(ds)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    '#Region "控管項目維護-同類藥"
    '    ''' <summary>
    '    ''' 查詢藥名
    '    ''' </summary>
    '    ''' <param name="Pharmacy_12_code">成大十二碼藥名</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function OPHControlItemQueryDrug(ByVal Pharmacy_12_code As String) As DataSet Implements IUclServiceManager.OPHControlItemQueryDrug
    '        Dim client1 As UclServiceClient
    '        Dim return_ds As DataSet
    '        Try
    '            client1 = getUclService()
    '            return_ds = client1.OPHControlItemQueryDrug(Pharmacy_12_code)
    '            client1.Close()
    '        Catch ex As Exception
    '            client1.Abort()
    '            Throw ex
    '        End Try
    '        Return return_ds
    '    End Function
    '#End Region
    '#End Region

#Region "20090602 add by James, 共用元件-身份別連動設定"


    Function queryUclIdentityInitial() As DataSet Implements IUclServiceManager.queryUclIdentityInitial
        queryUclIdentityInitial()

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryUclIdentityInitial()
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try

    End Function

    Function queryUclIdentityInitial2(ByVal inSourceType As String) As DataSet Implements IUclServiceManager.queryUclIdentityInitial2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryUclIdentityInitial2(inSourceType)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try

    End Function

#End Region

#Region "20100122 add by AlanTsai, SMTP設定查詢"

    Function querySMTPData() As DataSet Implements IUclServiceManager.querySMTPData
        Dim instance As UclServiceClient = Nothing
        Try
            instance = getUclService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.querySMTPData()
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                Else
                    instance.Abort()
                End If
            End If
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
    '    Public Function get3FrontIcdCode(ByVal outpatientSn As String, ByVal sysFlag As String) As DataTable Implements IUclServiceManager.get3FrontIcdCode
    '        Dim client As UclServiceClient = Nothing
    '        Dim returnValue As DataTable = Nothing
    '        Try
    '            client = getUclService()
    '            returnValue = client.get3FrontIcdCode(outpatientSn, sysFlag)
    '            client.Close()
    '            Return returnValue
    '        Catch ex As Exception
    '            client.Abort()
    '            Throw ex
    '        Finally
    '            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
    '            If returnValue IsNot Nothing Then returnValue.Dispose()
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
    '    Public Function getIcdDataForChangeIdentityUI(ByVal chartNo As String, ByVal outpatientSn As String, ByVal opdVisitDate As Date, ByVal sysFlag As String) As DataTable Implements IUclServiceManager.getIcdDataForChangeIdentityUI
    '        Dim client As UclServiceClient = Nothing
    '        Dim returnValue As DataTable = Nothing
    '        Try
    '            client = getUclService()
    '            returnValue = client.getIcdDataForChangeIdentityUI(chartNo, outpatientSn, opdVisitDate, sysFlag)
    '            client.Close()
    '            Return returnValue
    '        Catch ex As Exception
    '            client.Abort()
    '            Throw ex
    '        Finally
    '            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
    '            If returnValue IsNot Nothing Then returnValue.Dispose()
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
    Public Function UclHintDataBOinsert(ByVal ds As System.Data.DataSet) As Integer Implements IUclServiceManager_T.UclHintDataBOinsert

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOinsert(ds)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryByPK(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As System.Data.DataSet Implements IUclServiceManager_T.UclHintDataBOqueryByPK

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOqueryByPK(pk_UI_Name, pk_Serial)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOdelete(ByRef pk_UI_Name As System.String, ByRef pk_Serial As System.Int32) As Integer Implements IUclServiceManager_T.UclHintDataBOdelete

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOdelete(pk_UI_Name, pk_Serial)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#Region "     更新資料庫內容 "
    ''' <summary>
    ''' 更新資料庫內容
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOupdate(ByVal ds As System.Data.DataSet) As Integer Implements IUclServiceManager_T.UclHintDataBOupdate

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOupdate(ds)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#Region "     查詢提示資料 "
    ''' <summary>
    ''' 查詢提示資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Public Function UclHintDataBOqueryData(ByVal UIName As String) As DataSet Implements IUclServiceManager_T.UclHintDataBOqueryData

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOqueryData(UIName)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region


#Region "     查詢提示資料全部 "
    ''' <summary>
    ''' 查詢提示資料全部
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-3-6</remarks>
    Public Function UclHintDataBOqueryDataAll() As DataSet Implements IUclServiceManager_T.UclHintDataBOqueryDataAll

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UclHintDataBOqueryDataAll()
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
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
    Public Function queryOMOPhraseForUCL(ByVal UserTypeId As String, ByVal DoctorDeptCode As String, ByVal PhraseTypeId As String, ByVal PhraseKeyStr As String) As DataSet Implements IUclServiceManager_T.queryOMOPhraseForUCL

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOPhraseForUCL(UserTypeId, DoctorDeptCode, PhraseTypeId, PhraseKeyStr)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#End Region

#Region "2015/04/16 共用元件-常用醫令查詢(UCLOrderFavorDialogUI)  by Alan.Tsai"

    '1
    Public Function queryOMOOrderFavorInit(ByVal queryData As DataSet) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorInit

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorInit(queryData)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '2
    Public Function queryOMOOrderFavorByCond3(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, _
                                              ByVal FavorCategory As String, ByVal OrderCode As String, ByVal OrderName As String, _
                                              ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal ChartNo As String, _
                                              ByVal OutpatientSn As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorByCond3

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorByCond3(SourceType, FavorId, FavorTypeId, DoctorDeptCode, _
                                                            FavorCategory, OrderCode, OrderName, _
                                                            DrugType, PharmacyQueryFlag, ChartNo, _
                                                            OutpatientSn, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '3
    Public Function querySTAPackageDataByCategory(ByVal inCategory As String, ByVal inStation As String, ByVal inCategoryStr As String, ByVal inQueryStr As String) As DataSet Implements IUclServiceManager_T.querySTAPackageDataByCategory

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.querySTAPackageDataByCategory(inCategory, inStation, inCategoryStr, inQueryStr)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '4
    Public Function queryOMOOrderFavorSheetDept2(ByVal SourceType As String, ByVal FavorTypeId As String, Optional ByVal inHospCode As String = "") As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDept2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDept2(SourceType, FavorTypeId, inHospCode)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '5
    Public Function queryOMOOrderFavorSheetDetailByLabGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                            ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                            ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDetailByLabGroup

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDetailByLabGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '6
    Public Function queryOMOOrderFavorSheetDetailByExamGroup(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                             ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                             ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDetailByExamGroup

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDetailByExamGroup(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryOMOOrderFavorSheetDetailByExamGroupForKMUH(ByVal SourceType As String, ByVal SheetCode As String, ByVal SheetGroup As String, _
                                                                    ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal inQueryStr As String, _
                                                                    ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDetailByExamGroupForKMUH

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDetailByExamGroupForKMUH(SourceType, SheetCode, SheetGroup, ChartNo, OutpatientSn, inQueryStr, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '7
    Public Function queryOMOFavorCategory2(ByVal SourceType As String, ByVal FavorId As String, ByVal FavorTypeId As String, ByVal DoctorDeptCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOFavorCategory2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOFavorCategory2(SourceType, FavorId, FavorTypeId, DoctorDeptCode, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '8
    Public Function querySTAPackageDataCategory(ByVal inCategory As String, ByVal inStation As String) As DataSet Implements IUclServiceManager_T.querySTAPackageDataCategory

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.querySTAPackageDataCategory(inCategory, inStation)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '9
    Public Function queryOMOOrderFavorSheetDetailByLab2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDetailByLab2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDetailByLab2(SourceType, SheetCode, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '10
    Public Function queryOMOOrderFavorSheetDetailByExam2(ByVal SourceType As String, ByVal SheetCode As String, ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorSheetDetailByExam2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorSheetDetailByExam2(SourceType, SheetCode, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
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
                                                    ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOMOOrderFavorDetailOrder3

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMOOrderFavorDetailOrder3(SourceType, OrderTypeId, DrugType, FavorId, DoctorDeptCode, PackageCode, ChartNo, OutpatientSn, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '12
    Public Function queryOPHPharmacyByCond3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal DrugType As String, ByVal PharmacyQueryFlag As String(), ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryOPHPharmacyByCond3

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOPHPharmacyByCond3(SourceType, OrderCode, OrderName, DrugType, PharmacyQueryFlag, IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '13
    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, _
                                              ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, _
                                              ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String, _
                                              ByVal IsChoiceDcOrder As String) As DataSet Implements IUclServiceManager_T.queryPUBOrderByLanguage3

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId, _
                                                           FavorCategory, Specimen, Body_Site, _
                                                           Chinese_Flag, ChartNo, OutpatientSn, _
                                                           IsChoiceDcOrder)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '14
    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IUclServiceManager_T.queryPUBDiseaseByFavor2

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '15
    Public Function queryPUBExamItemByOrder(ByVal inOrderCode As String) As DataSet Implements IUclServiceManager_T.queryPUBExamItemByOrder

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBExamItemByOrder(inOrderCode)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '16
    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet Implements IUclServiceManager_T.queryPUBOrderOwnAndNhiPrice

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBOrderOwnAndNhiPrice(OrderCode)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '17
    Public Function queryOMODiagFavorInit(ByVal SourceTypeId As String, ByVal DiagType As String, _
                                          ByVal DoctorCode As String, ByVal DeptCode As String, _
                                          ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclServiceManager_T.queryOMODiagFavorInit

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOMODiagFavorInit(SourceTypeId, DiagType, DoctorCode, DeptCode, DiagCode, DiagDesc)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '18
    Public Function queryPUBInsuSubDept(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal InsuDeptCode As String) As DataSet Implements IUclServiceManager_T.queryPUBInsuSubDept

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBInsuSubDept(SourceTypeId, DiagType, InsuDeptCode)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '19
    Public Function queryDiagCategory(ByVal DiagType As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclServiceManager_T.queryDiagCategory

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryDiagCategory(DiagType, DiagCode, DiagDesc)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '20
    Public Function queryICD10Category(ByVal SourceTypeId As String, ByVal DiagType As String, ByVal IsInsu As String) As DataSet Implements IUclServiceManager_T.queryICD10Category

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryICD10Category(SourceTypeId, DiagType, IsInsu)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    '21
    Public Function queryICDDetail(ByVal SelType As String, ByVal SourceTypeId As String, ByVal DiagType As String, _
                                   ByVal FavorId As String, ByVal DoctorDeptCode As String, ByVal FavorCategory As String, _
                                   ByVal ICDCode As String, ByVal ICD10ChapterId As String, ByVal InsuDeptCode As String, _
                                   ByVal InsuSubDeptCode As String, ByVal DiagCode As String, ByVal DiagDesc As String) As DataSet Implements IUclServiceManager_T.queryICDDetail

        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryICDDetail(SelType, SourceTypeId, DiagType, FavorId, DoctorDeptCode, FavorCategory, ICDCode, ICD10ChapterId, InsuDeptCode, InsuSubDeptCode, DiagCode, DiagDesc)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
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
    Public Function QueryPrintCondition(ByVal Param As Dictionary(Of String, Object)) As DataSet Implements IUclServiceManager_T.QueryPrintCondition
        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPrintCondition(Param)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

    ''' <summary>
    ''' 取得登入者Term_Code所囑之Print Condition
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLoginUserPrintCond(ByVal Param As Dictionary(Of String, Object)) As DataTable Implements IUclServiceManager_T.GetLoginUserPrintCond
        Dim tempclient As UclServiceClient = Nothing

        Try
            tempclient = getUclService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.GetLoginUserPrintCond(Param)
            End Using ' before close

        Catch ex As Exception
            Throw ex
        Finally
            If tempclient IsNot Nothing Then
                If tempclient.State = ServiceModel.CommunicationState.Opened Then
                    tempclient.Close()
                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
                    tempclient.Abort()
                End If
            End If
        End Try
    End Function

#End Region

End Class
