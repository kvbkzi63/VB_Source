Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Client.Servicefactory.PubServiceReference


Partial Class PubServiceManager
    Implements IPubServiceManager_T

#Region "   TN"

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"

    Function queryPUBDisIdentityAll() As DataSet Implements IPubServiceManager_T.queryPUBDisIdentityAll
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDisIdentityAll()
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

#Region "20150903 PUBContractUI 合約機構基本檔 add by Will,Lin"

    Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet Implements IPubServiceManager_T.queryPUBSubIdentityAll
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSubIdentityAll(inSourceType)
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

#Region "20150812 【ExportList】 add by Will,Lin"

    ''' <summary>
    ''' 程式說明：報表資料查詢
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/12
    ''' </summary> 
    ''' <returns>資料新增</returns>
    Function PubExportQueryData(ByVal sql As String, ByVal getConnection As String) As DataSet Implements IPubServiceManager_T.PubExportQueryData
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PubExportQueryData(sql, getConnection)
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
    ''' <summary>
    ''' 程式說明：初始化欄位查詢資訊
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/13
    ''' </summary> 
    ''' <returns>資料新增</returns>
    Public Function PubExportListDataQuery(ByVal Report_id As String) As DataSet Implements IPubServiceManager_T.PubExportListDataQuery
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PubExportListDataQuery(Report_id)
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

#Region "20150810 【共用查詢平台】相關method , add by Will,Lin"

    ''' <summary>
    ''' 程式說明：資料新增
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料新增</returns>
    Public Function PUBExportInsertData(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBExportInsertData
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportInsertData(ds)
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

    ''' <summary>
    ''' 程式說明：資料修改
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料修改</returns>
    Public Function PUBExportUpdateData(ByVal Report_Id As String, ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBExportUpdateData
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportUpdateData(Report_Id, ds)
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

    ''' <summary>
    ''' 程式說明：資料刪除
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料刪除</returns>
    Public Function PUBExportDeleteData(ByVal Report_Id As String) As Integer Implements IPubServiceManager_T.PUBExportDeleteData
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportDeleteData(Report_Id)
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


    ''' <summary>
    ''' 程式說明：資料查詢
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料查詢-主表單</returns>
    Public Function PUBExportMasterDataQuery(ByVal Report_id As String) As DataSet Implements IPubServiceManager_T.PUBExportMasterDataQuery
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportMasterDataQuery(Report_id)
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
    ''' <summary>
    ''' 程式說明：資料查詢
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料查詢-表身</returns>
    Public Function PUBExportDetailDataQuery(ByVal Report_id As String) As DataSet Implements IPubServiceManager_T.PUBExportDetailDataQuery
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportDetailDataQuery(Report_id)
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

    ''' <summary>
    ''' 程式說明：資料查詢
    ''' 開發人員：Will,Lin
    ''' 開發日期：2015/08/10
    ''' </summary> 
    ''' <returns>資料查詢-新增後查詢</returns>
    Public Function PUBExportQueryForInsert(ByVal Report_id As String) As DataSet Implements IPubServiceManager_T.PUBExportQueryForInsert
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBExportQueryForInsert(Report_id)
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

#Region "2009/09/18, Add By Alan, 一般醫令查詢"

    ''' <summary>
    ''' 程式說明：一般醫令查詢
    ''' 開發人員：Alan
    ''' 開發日期：2009.09.18
    ''' </summary> 
    ''' <returns>一般醫令查詢結果</returns>
    Public Function queryPUBOrderByCond(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal Specimen As String, ByVal Body_Site As String) As DataSet Implements IPubServiceManager_T.queryPUBOrderByCond
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrderByCond(OrderCode, OrderName, OrderTypeId, Specimen, Body_Site)
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

    Public Function queryPUBOrderByLanguage(ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String) As DataSet Implements IPubServiceManager_T.queryPUBOrderByLanguage
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrderByLanguage(OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag)
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

    Public Function queryPUBOrderByLanguage3(ByVal SourceType As String, ByVal OrderCode As String, ByVal OrderName As String, ByVal OrderTypeId As String, ByVal FavorCategory As String, ByVal Specimen As String, ByVal Body_Site As String, ByVal Chinese_Flag As String, ByVal ChartNo As String, ByVal OutpatientSn As String) As DataSet Implements IPubServiceManager_T.queryPUBOrderByLanguage3
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrderByLanguage3(SourceType, OrderCode, OrderName, OrderTypeId, FavorCategory, Specimen, Body_Site, Chinese_Flag, ChartNo, OutpatientSn)
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

    Public Function queryPUBOrderIsDC(ByVal inOrderCode As String) As DataSet Implements IPubServiceManager_T.queryPUBOrderIsDC
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrderIsDC(inOrderCode)
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

#Region "20100226 動態查詢 by Jen"

    Public Function dynamicQuery(ByVal sqlStr As String) As DataSet Implements IPubServiceManager_T.dynamicQuery
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.dynamicQuery(sqlStr)
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


#Region "2013-03-21 add by 嚴崑銘"
    Public Function GetPubConfigValue(ByVal configName As String) As String Implements IPubServiceManager_T.GetPubConfigValue
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.GetPubConfigValue(configName)
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

    Public Function IsPubConfigActive(ByVal configName As String) As Boolean Implements IPubServiceManager_T.IsPubConfigActive
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.IsPubConfigActive(configName)
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

    Public Function CheckIdNo(ByVal strIdNo As String) As Integer Implements IPubServiceManager_T.CheckIdNo
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.CheckIdNo(strIdNo)
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


#Region "常用一般診斷查詢"

    Public Function queryPUBDiseaseByFavor(ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IPubServiceManager_T.queryPUBDiseaseByFavor

        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDiseaseByFavor(code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
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

    Public Function queryPUBDiseaseByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet Implements IPubServiceManager_T.queryPUBDiseaseByFavor2

        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDiseaseByFavor2(SourceType, code, codeEnName, codeName, DiseaseTypeId, IsSevereDisease)
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


#Region "醫令自費與健保價格查詢"

    Public Function queryPUBOrderOwnAndNhiPrice(ByVal OrderCode As String) As DataSet Implements IPubServiceManager_T.queryPUBOrderOwnAndNhiPrice

        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBOrderOwnAndNhiPrice(OrderCode)
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

#Region "20090618 取得系統時間  , add by James"

    Public Function GetSystemNowTime() As Date Implements IPubServiceManager.GetSystemNowTime
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.GetSystemNowTime()
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

#Region "20090720 PUBConfig , Added by James"

    Public Function queryPubConfigWhereConfigNameEquals(ByVal ConfigName As String) As System.Data.DataSet Implements IPubServiceManager.queryPubConfigWhereConfigNameEquals
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubConfigWhereConfigNameEquals(ConfigName)
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

    Public Function queryAllPUBConfig() As System.Data.DataSet Implements IPubServiceManager.queryAllPUBConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryAllPUBConfig
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

    Public Function updatePUBConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.updatePUBConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBConfig(ds)
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

    Public Function queryPUBConfigWhereConfigNameIn(ByVal configName As String) As DataSet Implements IPubServiceManager.queryPUBConfigWhereConfigNameIn
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBConfigWhereConfigNameIn(configName)
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

#Region "系統版本更新記錄檔"

    Public Function DynamicQueryByColumn(ByRef queryData As DataSet) As System.Data.DataSet Implements IPubServiceManager_T.DynamicQueryByColumn
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.DynamicQueryByColumn(queryData)
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

    Public Function insertPUBSystermVersion(ByVal queryData As System.Data.DataSet) As Integer Implements IPubServiceManager_T.insertPUBSystermVersion
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBSystermVersion(queryData)
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

#Region "20090820 add by James, PUBSysCodeBO_E1"

    Public Function queryPUBSyscodePKey(ByVal inTypeId As String, ByVal inCodeId As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPUBSyscodePKey
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSyscodePKey(inTypeId, inCodeId)

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

    Public Function queryPUBSysCodebyTypeId(ByVal TypeId As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPUBSysCodebyTypeId
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSysCodebyTypeId(TypeId)

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

#Region "20090820 add by Rich, PUBPartBO_E1"

    Public Function queryPubPartByKey(ByVal regDate As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubPartByKey

        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPartByKey(regDate)

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

#Region "20090820 add by James, 員工資料相關查詢(PUBEmployee)"

    Public Function queryEmployeeByDate(ByVal EmployeeCode As String, ByVal JudgeDate As String) As DataSet Implements IPubServiceManager_T.queryEmployeeByDate
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryEmployeeByDate(EmployeeCode, JudgeDate)

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

    Public Function DoPubAction(ByVal ds As DataSet) As DataSet Implements IPubServiceManager_T.DoPubAction
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.DoPubAction(ds)

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

#Region "20090820 add by Rich, PubPatientBO_E1"

    Public Function queryPubPatientByIdno(ByVal Idno As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubPatientByIdno
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPatientByIdno(Idno)

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

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-09</remarks>
    Public Function queryPubPatientByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubServiceManager.queryPubPatientByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubPatientByPK(pk_Chart_No)
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

#Region "20090820 add by James, PUBPatientSevereDiseaseBO_E1"

    Public Function queryPubPatientSevereDiseaseByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubPatientSevereDiseaseByKey
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPatientSevereDiseaseByKey(Chart_No)

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

#Region "20090820 add by James, PUBPatientDisabilityBO_E1"

    Public Function queryPubPatientDisabilityByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubPatientDisabilityByKey
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPatientDisabilityByKey(Chart_No)

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

#Region "20090820 add by James, PUBPatientFlagBO_E1"

    Public Function queryPubPatientFlagByKey(ByVal Chart_No As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubPatientFlagByKey
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPatientFlagByKey(Chart_No)

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

#Region "2013/09/25 醫師檔相關作業(PUBDOCTORBO_E1) by Sean.Lin"

#Region "     查詢醫師檔作為CBO 資料 "

    ''' <summary>
    ''' 查詢醫師檔作為CBO 資料
    ''' </summary>
    ''' <returns>DataSet</returns>    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function PUBDOCTORBOE1queryForCbo(ByVal SectionCode As String) As DataSet Implements IPubServiceManager.PUBDOCTORBOE1queryForCbo
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.PUBDOCTORBOE1queryForCbo(SectionCode)
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

    ''' <summary>
    ''' 進行醫師驗證
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryDoctorFromEmployee(ByVal Employee_Code As String, ByVal Doctor_Code As String) As DataSet Implements IPubServiceManager.queryDoctorFromEmployee
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryDoctorFromEmployee(Employee_Code, Doctor_Code)
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

#Region "2016/06/10 add by Lits Pub_IP_Config 維護"

    Public Function insertPubIPConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_T.insertPubIPConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPubIPConfig(ds)
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
    Public Function updatePubIPConfig(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_T.updatePubIPConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePubIPConfig(ds)
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
    Public Function deletePubIPConfig(ByVal ip As System.String) As Integer Implements IPubServiceManager_T.deletePubIPConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePubIPConfig(ip)
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
    Public Function queryPubIPConfig(ByVal ip As System.String) As DataSet Implements IPubServiceManager_T.queryPubIPConfig
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubIPConfig(ip)
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


    Public Function queryStationByIP(ByVal ip As String) As DataSet Implements IPubServiceManager_T.queryStationByIP
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryStationByIP(ip)
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

#Region "2012/04/06 add by Alan 取得Term_Code設定資料"

    Public Function queryStationByTermCode(ByVal inTermCode As String) As DataSet Implements IPubServiceManager_T.queryStationByTermCode
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryStationByTermCode(inTermCode)
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

#Region " 負責寫前端程式所有 log 紀錄"

    Public Sub doClientLog(ByVal level As LOGDelegate.LogLevel, ByVal callerType As String, ByVal methodName As String, ByVal message As String) Implements IPubServiceManager.doClientLog
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                instance.doClientLog(level, callerType, methodName, message)
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
    End Sub

#End Region

#Region "2014/09/01 員工資料相關查詢(PUBEmployee) by Sean.Lin"

#Region "     根據員工編號取得員工資料 "
    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCode(ByVal EmployeeCode As String) As DataSet Implements IPubServiceManager.PUBEmployeequeryEmployeeByEmpCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBEmployeequeryEmployeeByEmpCode(EmployeeCode)
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


#Region "     根據員工編號和日期取得有效期限的員工資料 "
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function PUBEmployeequeryEmployeeByEmpCodeAndDate(ByVal EmployeeCode As String, ByVal JudgeDate As Date) As DataSet Implements IPubServiceManager.PUBEmployeequeryEmployeeByEmpCodeAndDate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBEmployeequeryEmployeeByEmpCodeAndDate(EmployeeCode, JudgeDate)
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

#Region "2014/11/04 參數設定(PubConfig) by Sean.Lin"

#Region "     查詢By參數設定名稱 "
    ''' <summary>
    ''' 查詢By參數設定名稱
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigQueryByConfigName(ByVal configName As String) As DataSet Implements IPubServiceManager.PubConfigQueryByConfigName

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigQueryByConfigName(configName)
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
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryByPK(ByRef pk_Config_Name As System.String) As DataSet Implements IPubServiceManager.PubConfigqueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigqueryByPK(pk_Config_Name)
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
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdelete(ByRef pk_Config_Name As System.String) As Integer Implements IPubServiceManager.PubConfigdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigdelete(pk_Config_Name)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfiginsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubConfiginsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfiginsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubConfigupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigqueryAll() As System.Data.DataSet Implements IPubServiceManager.PubConfigqueryAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigqueryAll()
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


#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function PubConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements IPubServiceManager.PubConfigdynamicQueryWithColumnValue

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubConfigdynamicQueryWithColumnValue(columnName, columnValue)
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

#Region "2014/11/04 系統參數設定維護(PubConfig) by Alan.Tsai"

    ''' <summary>
    ''' 根據系統參數名稱查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function queryPUBConfigLikePKey(ByVal inConfigName As String) As DataSet Implements IPubServiceManager.queryPUBConfigLikePKey

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBConfigLikePKey(inConfigName)
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
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function qureyPUBConfigAll() As DataSet Implements IPubServiceManager.qureyPUBConfigAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.qureyPUBConfigAll()
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
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function savePUBConfig(ByVal inSaveDs As DataSet) As DataSet Implements IPubServiceManager.savePUBConfig

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.savePUBConfig(inSaveDs)
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
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Function deletePUBConfig(ByVal inDeleteDs As DataSet) As DataSet Implements IPubServiceManager.deletePUBConfig

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBConfig(inDeleteDs)
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

#Region "2014/11/08 公用類別代碼維護(PubSyscodeType) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function queryPUBSyscodeTypeLikePKey(ByVal inConfigName As String) As DataSet Implements IPubServiceManager.queryPUBSyscodeTypeLikePKey

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSyscodeTypeLikePKey(inConfigName)
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
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function qureyPUBSyscodeTypeAll() As DataSet Implements IPubServiceManager.qureyPUBSyscodeTypeAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.qureyPUBSyscodeTypeAll()
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
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function savePUBSyscodeType(ByVal inSaveDs As DataSet) As DataSet Implements IPubServiceManager.savePUBSyscodeType

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.savePUBSyscodeType(inSaveDs)
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
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-08</remarks>
    Public Function deletePUBSyscodeType(ByVal inDeleteDs As DataSet) As DataSet Implements IPubServiceManager.deletePUBSyscodeType

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBSyscodeType(inDeleteDs)
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

#Region "2014/11/09 公用代碼維護(PubSyscode) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別代碼、公用代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBSyscodeLikePKey(ByVal inTypeId As String, ByVal inCodeId As String) As DataSet Implements IPubServiceManager.queryPUBSyscodeLikePKey

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSyscodeLikePKey(inTypeId, inCodeId)
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
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function qureyPUBSyscodeAll() As DataSet Implements IPubServiceManager.qureyPUBSyscodeAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.qureyPUBSyscodeAll()
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
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBSyscode(ByVal inSaveDs As DataSet) As DataSet Implements IPubServiceManager.savePUBSyscode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.savePUBSyscode(inSaveDs)
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
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBSyscode(ByVal inDeleteDs As DataSet) As DataSet Implements IPubServiceManager.deletePUBSyscode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBSyscode(inDeleteDs)
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

#Region "2014/11/09 醫事機構維護(PubSyscode) by Alan.Tsai"

    ''' <summary>
    ''' 根據類別、生效日期與醫院代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function queryPUBHospitalLikePKey(ByVal inLanguageTypeId As String, ByVal inEffectDate As String, ByVal inHospitalCode As String) As DataSet Implements IPubServiceManager.queryPUBHospitalLikePKey

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBHospitalLikePKey(inLanguageTypeId, inEffectDate, inHospitalCode)
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
    ''' 查詢全部資料
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function qureyPUBHospitalAll() As DataSet Implements IPubServiceManager.qureyPUBHospitalAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.qureyPUBHospitalAll()
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
    ''' 畫面初始化資料查詢
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-10</remarks>
    Public Function initPubHospital() As DataSet Implements IPubServiceManager.initPubHospital

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.initPubHospital()
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
    ''' 存檔
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function savePUBHospital(ByVal inSaveDs As DataSet) As DataSet Implements IPubServiceManager.savePUBHospital

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.savePUBHospital(inSaveDs)
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
    ''' 將傳入資料進行刪除
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Function deletePUBHospital(ByVal inDeleteDs As DataSet) As DataSet Implements IPubServiceManager.deletePUBHospital

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBHospital(inDeleteDs)
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

#Region "2014/12/02 by Lits 取得員工全部資料"
    ''' <summary>
    ''' 取得員工全部資料 By Dept
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    ''' 
    Public Function queryEmployeeALL(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet Implements IPubServiceManager.queryEmployeeALL
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryEmployeeALL()
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
    ''' 取得員工全部資料 By Dept
    ''' </summary>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Lits on 2014-11-09</remarks>
    ''' 
    Function queryEmployeeByDept(ByVal dept As String) As DataSet Implements IPubServiceManager.queryEmployeeByDept
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryEmployeeByDept(dept)
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

#Region "20090415 假日檔維護 add by James"

    Function queryPubHolidayAll() As DataSet Implements IPubServiceManager.queryPubHolidayAll
        Dim client As PubServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getPubService()
            ds_return = client.queryPubHolidayAll()
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function
    Public Function queryPubHolidayByKey(ByVal holidayDate As String, ByVal subSysCode As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubHolidayByKey
        Dim instance As PubServiceClient = Nothing
        Try
            instance = getPubService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubHolidayByKey(holidayDate, subSysCode)

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

    Function insertPubHoliday(ByVal dsParam As DataSet) As Integer Implements IPubServiceManager.insertPubHoliday
        Dim client As New PubServiceClient
        Dim flag As Integer

        Try
            client = getPubService()
            flag = client.insertPubHoliday(dsParam)
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return flag
    End Function

    Function deletePubHoliday(ByVal holidayDate As String, ByVal subSysCode As String) As Integer Implements IPubServiceManager.deletePubHoliday
        Dim client As New PubServiceClient
        Dim flag As Integer

        Try
            client = getPubService()
            flag = client.deletePubHoliday(holidayDate, subSysCode)
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return flag


    End Function
    Function updatePubHoliday(ByVal dsParam As DataSet) As Integer Implements IPubServiceManager.updatePubHoliday
        Dim client As New PubServiceClient
        Dim flag As Integer

        Try
            client = getPubService()
            flag = client.updatePubHoliday(dsParam)
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return flag
    End Function

    Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal datestrHolidayYear As Date, ByVal strSubSystemCode As String) As DataSet Implements IPubServiceManager.queryPUBHolidayByCond
        Dim client As New PubServiceClient
        Dim ds_return As DataSet

        Try
            client = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBHolidayByCond(strHolidayYear, datestrHolidayYear, strSubSystemCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function



#End Region

#Region "20090803 add by Rich, PUBSysCodeBO_E1"

    Public Function queryPUBSysCodeInCond(ByVal TypeId As String) As DataSet Implements IPubServiceManager.queryPUBSysCodeInCond
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.queryPUBSysCodeInCond(TypeId)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
        End Try
    End Function

#End Region

#Region "20090602 add by James 身份別連動設定"

    Function queryPUBSysCode(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False) As DataSet Implements IPubServiceManager.queryPUBSysCode
        Dim client As PubServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getPubService()
            ds_return = client.queryPUBSysCode(TypeID, multiCodeIdFlag)
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function
    'Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As DataSet Implements IPubServiceManager.queryPUBSubIdentityAll
    '    Dim client As PubServiceClient
    '    Dim ds_return As DataSet

    '    Try
    '        client = getPubService()
    '        ds_return = client.queryPUBSubIdentityAll(inSourceType)
    '        client.Close()
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    End Try

    '    Return ds_return
    'End Function
    'Function queryPUBDisIdentityAll() As DataSet Implements IPubServiceManager.queryPUBDisIdentityAll
    '    Dim client As PubServiceClient
    '    Dim ds_return As DataSet

    '    Try
    '        client = getPubService()
    '        ds_return = client.queryPUBDisIdentityAll
    '        client.Close()
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    End Try

    '    Return ds_return
    'End Function
    'Function queryPUBContractAll() As DataSet Implements IPubServiceManager.queryPUBContractAll
    '    Dim client As PubServiceClient
    '    Dim ds_return As DataSet

    '    Try
    '        client = getPubService()
    '        ds_return = client.queryPUBContractAll
    '        client.Close()
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    End Try

    '    Return ds_return
    'End Function
#End Region

#Region "20090511 科室資料維護 add by James"
    'Function queryPUBDepartmentByKey(ByVal deptCode As String) As DataSet Implements IPubServiceManager.queryPUBDepartmentByKey
    '    Dim client As PubServiceClient
    '    Dim ds_return As DataSet

    '    Try
    '        client = getPubService()
    '        ds_return = client.queryPUBDepartmentByKey(deptCode)
    '        client.Close()
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    End Try

    '    Return ds_return
    'End Function

    'Function queryPUBDepartmentAll_B() As DataSet Implements IPubServiceManager.queryPUBDepartmentAll_B

    '    Dim client As PubServiceClient
    '    Dim ds_return As DataSet

    '    Try
    '        client = getPubService()
    '        ds_return = client.queryPUBDepartmentAll_B()
    '        client.Close()
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    End Try
    '    Return ds_return
    'End Function

    Function queryPUBDepartmentAll_D() As DataSet Implements IPubServiceManager.queryPUBDepartmentAll_D

        Dim client As PubServiceClient = Nothing
        Dim ds_return As DataSet

        Try
            client = getPubService()
            ds_return = client.queryPUBDepartmentAll_D()
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    ''' <summary>
    ''' 取得小分科資料 (k)
    ''' </summary>
    ''' <returns>科室資料</returns>
    ''' <author>Ken</author>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentBySmallDept() As DataSet Implements IPubServiceManager.queryPUBDepartmentBySmallDept
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.queryPUBDepartmentBySmallDept()
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                If _client.State = ServiceModel.CommunicationState.Opened Then
                    _client.Close()
                ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
                    _client.Abort()
                End If
            End If
        End Try
    End Function

    ' ''' <summary>
    ' ''' 取得所有大小分科資訊 
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function queryPUBDepartmentAllDept() As DataSet Implements IPubServiceManager_T.queryPUBDepartmentAllDept
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.queryPUBDepartmentAllDept
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            If _client.State = ServiceModel.CommunicationState.Opened Then
    '                _client.Close()
    '            ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
    '                _client.Abort()
    '            End If
    '        End If
    '    End Try
    'End Function

    ''' <summary>
    ''' 程式說明：依據來源別O、E、I，取得對應的門診、急診、住院 科別
    ''' 開發人員：Charles
    ''' 調整日期：2015/12/16
    ''' </summary>
    ''' <param name="SourceType">O：門診、E：急診、I：住院</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBDepartmentAll_D2(ByVal SourceType As String) As DataSet Implements IPubServiceManager.queryPUBDepartmentAll_D2
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.queryPUBDepartmentAll_D2(SourceType)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                If _client.State = ServiceModel.CommunicationState.Opened Then
                    _client.Close()
                ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
                    _client.Abort()
                End If
            End If
        End Try
    End Function
#End Region

#Region "2009/08/11 add by markwu,病患基本檔"
    'Public Function PPatientInit() As DataSet Implements IPubServiceManager.PPatientUIInit
    '    Dim client As PubServiceClient = Nothing
    '    Dim returnValue As DataSet = Nothing
    '    Try
    '        client = getPubService()
    '        returnValue = client.PPatientUIInit

    '        client.Close()
    '        Return returnValue

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
    '        If returnValue IsNot Nothing Then returnValue.Dispose()
    '    End Try
    'End Function


    Public Function queryPubChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet Implements IPubServiceManager.queryPubChartNoByKey
        Dim client As PubServiceClient = Nothing
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubService()
            returnValue = client.queryPubChartNoByKey(codeNo, codeType)

            client.Close()
            Return returnValue

        Catch ex As Exception
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
            If returnValue IsNot Nothing Then returnValue.Dispose()
        End Try


    End Function
    'Public Function PubPatientInsert(ByVal ds As DataSet) As Integer Implements IPubServiceManager.PubPatientInsert
    '    Dim client As PubServiceClient = Nothing
    '    Dim returnValue As Integer = Nothing
    '    Try
    '        client = getPubService()
    '        returnValue = client.PubPatientInsert(ds)


    '        client.Close()
    '        Return returnValue
    '    Catch ex As Exception
    '        If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

    '    End Try

    'End Function
    'Public Function PubPatientUpdate(ByVal ds As DataSet) As Integer Implements IPubServiceManager.PubPatientUpdate
    '    Dim client As PubServiceClient = Nothing
    '    Dim returnValue As Integer = Nothing
    '    Try
    '        client = getPubService()
    '        returnValue = client.PubPatientUpdate(ds)


    '        client.Close()
    '        Return returnValue
    '    Catch ex As Exception
    '        If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

    '    End Try

    'End Function

#End Region

#Region "20100128 add by Rich, PUBOrderPriceBO_E1"

    Public Function queryOrderPriceDataByOrder(ByVal OrderCode As String) As DataTable Implements IPubServiceManager.queryOrderPriceDataByOrder
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataTable
        Try
            instance = getPubService()
            dsTemp = instance.queryOrderPriceDataByOrder(OrderCode)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
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
    Public Function getMedicalPartAmt(ByVal OpdChargeDate As Date, ByVal MedicalAmt As Decimal) As DataTable Implements IPubServiceManager.getMedicalPartAmt
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataTable
        Try
            instance = getPubService()
            dsTemp = instance.getMedicalPartAmt(OpdChargeDate, MedicalAmt)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
        End Try
    End Function

    Public Function getPubOrderPriceDataForOPCAPI(ByVal keyValue As DataSet) As DataTable Implements IPubServiceManager.getPubOrderPriceDataForOPCAPI
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataTable
        Try
            instance = getPubService()
            dsTemp = instance.getPubOrderPriceDataForOPCAPI(keyValue)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
        End Try
    End Function
#End Region

#Region "2012-02-14 PUBPatientAllergyNew相關程式"

    Public Function InitUI() As DataSet Implements IPubServiceManager_T.InitUI
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InitUI()
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

    Public Function Find_AllergyRecord(ByVal Chart_No As String) As DataTable Implements IPubServiceManager_T.Find_AllergyRecord
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Find_AllergyRecord(Chart_No)
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

    Public Function Find_PatientData(ByVal Chart_No As String) As DataTable Implements IPubServiceManager_T.Find_PatientData
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Find_PatientData(Chart_No)
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

    Public Function Find_AllergyHistory(ByVal Chart_No As String) As DataTable Implements IPubServiceManager_T.Find_AllergyHistory
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Find_AllergyHistory(Chart_No)
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
    Public Sub AddNew_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Create_Time As String, ByVal Create_User As String) Implements IPubServiceManager_T.AddNew_AllergyRecord
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                tempclient.AddNew_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Create_User, Create_Time)
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
    End Sub
    Public Function AddNew_AllergyRecord_NKDA(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                            ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                            ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                            ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                            ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                            ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String Implements IPubServiceManager_T.AddNew_AllergyRecord_NKDA
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.AddNew_AllergyRecord_NKDA(Chart_No, _
                                                            Patient_Allergy_No, _
                                                            Allergy_Kind_Id, _
                                                            Allergy_Code, _
                                                            Allergy_Item, _
                                                            Allergy_Severity, _
                                                            Allergy_Reaction, _
                                                            Allergy_Date, _
                                                            Is_From_Iccard, _
                                                            Pharmacy_12_Code, _
                                                            ADRNotification_No, _
                                                            Cancel, _
                                                            Create_User, _
                                                            Create_Time, _
                                                            Modified_User, _
                                                            Modified_Time, _
                                                            Drug_Allergy_Id, _
                                                            Limit_Strength, _
                                                            order_name)
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
    Public Function AddNew_AllergyRecord_OTHER(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                            ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                            ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                            ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                            ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                            ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String Implements IPubServiceManager_T.AddNew_AllergyRecord_OTHER
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.AddNew_AllergyRecord_OTHER(Chart_No, _
                                                             Patient_Allergy_No, _
                                                             Allergy_Kind_Id, _
                                                             Allergy_Code, _
                                                             Allergy_Item, _
                                                             Allergy_Severity, _
                                                             Allergy_Reaction, _
                                                             Allergy_Date, _
                                                             Is_From_Iccard, _
                                                             Pharmacy_12_Code, _
                                                             ADRNotification_No, _
                                                             Cancel, _
                                                             Create_User, _
                                                             Create_Time, _
                                                             Modified_User, _
                                                             Modified_Time, _
                                                             Drug_Allergy_Id, _
                                                             Limit_Strength, _
                                                             order_name)
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
    Public Sub Modify_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Modified_User As String, ByVal Modified_Time As String) Implements IPubServiceManager_T.Modify_AllergyRecord
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                tempclient.Modify_AllergyRecord(Chart_No, Patient_Allergy_No, Allergy_Kind_Id, _
                              Allergy_Code, Allergy_Item, Allergy_Reaction, Allergy_Date, Is_From_Iccard, _
                              Drug_Allergy_Id, Limit_Strength, Cancel, Order_Code, Modified_User, Modified_Time)
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
    End Sub
    Public Sub Delete_AllergyRecord(ByVal Chart_No As String, ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Cancel As String, ByVal Modified_User As String, ByVal Modified_Time As String, ByVal Allergy_no As String) Implements IPubServiceManager_T.Delete_AllergyRecord
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                tempclient.Delete_AllergyRecord(Chart_No, Allergy_Code, Allergy_Item, Cancel, Modified_User, Modified_Time, Allergy_no)
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
    End Sub

    Public Sub Reset_IsFromICCard(ByVal Chart_No As String, ByVal Drug1 As String, ByVal Drug2 As String, ByVal Drug3 As String) Implements IPubServiceManager_T.Reset_IsFromICCard
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                tempclient.Reset_IsFromICCard(Chart_No, Drug1, Drug2, Drug3)
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
    Public Function getEndDateForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String) As DataTable Implements IPubServiceManager.getEndDateForReceiptUI
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataTable
        Try
            instance = getPubService()
            dsTemp = instance.getEndDateForReceiptUI(ChartNo, OpdVisitDate)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
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
    Public Function getPatientDisabilityRecordForReceiptUI(ByVal ChartNo As String) As DataTable Implements IPubServiceManager.getPatientDisabilityRecordForReceiptUI
        Dim instance As New PubServiceClient
        Try
            instance = getPubService()
            Return instance.getPatientDisabilityRecordForReceiptUI(ChartNo)
            instance.Close()
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
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
    Public Function insertPatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer Implements IPubServiceManager.insertPatientDisabilityRecordForReceiptUI
        Dim instance As New PubServiceClient
        Try
            instance = getPubService()
            Return instance.insertPatientDisabilityRecordForReceiptUI(ds)
            instance.Close()
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：修改有效的殘障紀錄 by Chart_No
    ''' 開發人員：Will
    ''' 開發日期：20151014
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks>For OPC收退費用</remarks>
    Public Function updatePatientDisabilityRecordForReceiptUI(ByVal ds As DataSet) As Integer Implements IPubServiceManager.updatePatientDisabilityRecordForReceiptUI
        Dim instance As New PubServiceClient
        Try
            instance = getPubService()
            Return instance.updatePatientDisabilityRecordForReceiptUI(ds)
            instance.Close()
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
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
    Public Function getMaxPatientDisabilityNoForReceiptUI(ByVal ChartNo As String) As Integer Implements IPubServiceManager.getMaxPatientDisabilityNoForReceiptUI
        Dim instance As New PubServiceClient
        Try
            instance = getPubService()
            Return instance.getMaxPatientDisabilityNoForReceiptUI(ChartNo)
            instance.Close()
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
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
    Public Function getIcdCodeForReceiptUI(ByVal ChartNo As String, ByVal OpdVisitDate As String, ByVal IcdCodeDT As DataTable) As DataTable Implements IPubServiceManager.getIcdCodeForReceiptUI
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataTable
        Try
            instance = getPubService()
            dsTemp = instance.getIcdCodeForReceiptUI(ChartNo, OpdVisitDate, IcdCodeDT)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            instance.Abort()
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
        End Try
    End Function

#Region "2009/09/26 取得所有PUB Sheet資料 By James"

    Public Function queryPUBSheet() As DataSet Implements IPubServiceManager.queryPUBSheet
        Dim client As PubServiceClient = Nothing
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubService()
            returnValue = client.queryPUBSheet()
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

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
    Public Function queryPUBSheetSheetSheetCodeByDeptCode(ByVal DeptCode As String) As DataSet Implements IPubServiceManager.queryPUBSheetSheetSheetCodeByDeptCode
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.queryPUBSheetSheetSheetCodeByDeptCode(DeptCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#End Region

#Region "由表單代碼 Sheet_Code取得表單資訊"

    Public Function queryPubSheetBySheetCode(ByVal SheetCode As String) As DataSet Implements IPubServiceManager_T.queryPubSheetBySheetCode

        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.queryPubSheetBySheetCode(SheetCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region "20100730 add by Rich, OPHPhraseBO_E1"

    Public Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String) As DataSet Implements IPubServiceManager_T.queryPhraseNameByOPHRuleReason
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function RuleDynamicQueryNotPub(ByRef sqlString As String) As System.Data.DataSet Implements IPubServiceManager_T.RuleDynamicQueryNotPub
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.RuleDynamicQueryNotPub(sqlString)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(ByVal Chart_No As String, ByVal Outpatient_Sn As String) As DataSet Implements IPubServiceManager_T.PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.PUBRuleEngineAPI_H50_ChkInteraction_qryOMOTypeE(Chart_No, Outpatient_Sn)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function QuerySameKineMedicine(ByVal Phamarcy12code As String) As DataSet Implements IPubServiceManager_T.QuerySameKineMedicine
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.QuerySameKineMedicine(Phamarcy12code)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function EMRMedicineRecordRuleQuery(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String) As DataSet Implements IPubServiceManager_T.EMRMedicineRecordRuleQuery
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.EMRMedicineRecordRuleQuery(Chart_no, orderCode, Start_Date)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function EMRMedicineRecordRuleQuery2(ByVal Chart_no As String, ByVal orderCode As String, ByVal Start_Date As String, ByVal end_Date As String) As DataSet Implements IPubServiceManager_T.EMRMedicineRecordRuleQuery2
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.EMRMedicineRecordRuleQuery2(Chart_no, orderCode, Start_Date, end_Date)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

    Public Function InsertOPH_Alert_Record(ByVal InputDs As DataSet) As Int32 Implements IPubServiceManager_T.InsertOPH_Alert_Record
        Dim instance As New PubServiceClient
        Dim returnValue As DataTable = New DataTable
        Try
            instance = getPubService()
            Return instance.InsertOPH_Alert_Record(InputDs)

        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function


#Region "20090819 add by Rich, 檢核規則 PUBRuleBO_E1"

    Public Function RuleQueryAll() As System.Data.DataSet Implements IPubServiceManager.RuleQueryAll
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleQueryAll
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.RuleInsert
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleInsert(ds)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDynamicQuery(ByRef sqlString As String) As System.Data.DataSet Implements IPubServiceManager.RuleDynamicQuery
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDynamicQuery(sqlString)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Function RuleDynamicQueryPCS(ByRef sqlString As String) As System.Data.DataSet Implements IPubServiceManager.RuleDynamicQueryPCS
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDynamicQueryPCS(sqlString)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDynamicQueryForEis(ByRef sqlString As String) As System.Data.DataSet Implements IPubServiceManager_T.RuleDynamicQueryForEis
        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.dynamicQueryForEis(sqlString)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDynamicQueryEmr(ByVal sqlStr As String) As DataSet Implements IPubServiceManager.RuleDynamicQueryEmr
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.RuleDynamicQueryEmr(sqlStr)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function RuleDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet Implements IPubServiceManager.RuleDynamicQueryWithColumnValue
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDynamicQueryWithColumnValue(columnName, columnValue)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleQueryByPK(ByRef pk_Rule_Code As System.String) As System.Data.DataSet Implements IPubServiceManager.RuleQueryByPK
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleQueryByPK(pk_Rule_Code)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDelete(ByRef pk_Rule_Code As System.String) As Integer Implements IPubServiceManager.RuleDelete
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleDelete(pk_Rule_Code)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.RuleUpdate
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleUpdate(ds)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "20090819 add by Rich, 檢核規則 PUBRuleDetailBO_E1"

    Public Function RuleDetailQueryAll() As System.Data.DataSet Implements IPubServiceManager.RuleDetailQueryAll
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDetailQueryAll
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.RuleDetailInsert
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleDetailInsert(ds)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailDynamicQuery(ByRef sqlString As String) As System.Data.DataSet Implements IPubServiceManager.RuleDetailDynamicQuery
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDetailDynamicQuery(sqlString)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailDynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet Implements IPubServiceManager.RuleDetailDynamicQueryWithColumnValue
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDetailDynamicQueryWithColumnValue(columnName, columnValue)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailQueryByPK(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As System.Data.DataSet Implements IPubServiceManager.RuleDetailQueryByPK
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDetailQueryByPK(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailDelete(ByRef pk_Rule_Code As System.String, ByRef pk_Seq_No As System.Int32, ByRef pk_Item_Code As System.String) As Integer Implements IPubServiceManager.RuleDetailDelete
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleDetailDelete(pk_Rule_Code, pk_Seq_No, pk_Item_Code)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.RuleDetailUpdate
        Dim instance As New PubServiceClient
        Dim count As Integer
        Try
            instance = getPubService()
            count = instance.RuleDetailUpdate(ds)
            instance.Close()
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

#End Region

#Region "20091216 add by Rich, PUBRuleBS"

    Public Function getCallFormDS(ByVal RuleCode As String) As DataSet Implements IPubServiceManager.getCallFormDS
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.getCallFormDS(RuleCode)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleExpressionStrQuery(ByVal RuleCode As String) As System.Data.DataSet Implements IPubServiceManager.RuleExpressionStrQuery
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleExpressionStrQuery(RuleCode)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleDetailQuery(ByVal RuleCode As String) As System.Data.DataSet Implements IPubServiceManager.RuleDetailQuery
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleDetailQuery(RuleCode)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function getCheckRuleDS(ByVal RuleCode As String, ByVal ValueData As String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String) As DataSet Implements IPubServiceManager.getCheckRuleDS
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.getCheckRuleDS(RuleCode, ValueData, Source, Main_Identity_Id, Base_Date)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleClassQuery(ByVal RuleCode As String, ByVal ValueData As String) As System.Data.DataSet Implements IPubServiceManager.RuleClassQuery
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleClassQuery(RuleCode, ValueData)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleQueryByCond(ByRef pk_Rule_Code As System.String, ByVal Source As String, ByVal Medical_Identity_Id As String, ByVal Base_Date As String) As System.Data.DataSet Implements IPubServiceManager.RuleQueryByCond
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleQueryByCond(pk_Rule_Code, Source, Medical_Identity_Id, Base_Date)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleCodeTransfer1(ByVal OrderCode As String) As System.Data.DataSet Implements IPubServiceManager.RuleCodeTransfer1
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleCodeTransfer1(OrderCode)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function RuleCodeTransfer2(ByVal Insu_Code As String) As System.Data.DataSet Implements IPubServiceManager.RuleCodeTransfer2
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.RuleCodeTransfer2(Insu_Code)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryItemName(ByVal Item_Code As String) As System.Data.DataSet Implements IPubServiceManager.queryItemName
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.queryItemName(Item_Code)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryRuleValueData(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet Implements IPubServiceManager.queryRuleValueData
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.queryRuleValueData(Item_Code, Value_Data)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryClassAndField(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet Implements IPubServiceManager.queryClassAndField
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.queryClassAndField(Item_Code, Value_Data)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try
    End Function

    Public Function queryRuleCode(ByVal Item_Code As String, ByVal Value_Data As String, ByVal Base_Date As String) As System.Data.DataSet Implements IPubServiceManager.queryRuleCode
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.queryRuleCode(Item_Code, Value_Data, Base_Date)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet Implements IPubServiceManager.GetCurrentOrderset
        Dim instance As New PubServiceClient
        Dim dsTemp As New DataSet
        Try
            instance = getPubService()
            dsTemp = instance.GetCurrentOrderset(Medical_Sn, SystemType, Location)
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
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
    Public Function queryInsuCodeByOrderCode(ByVal OrderCodeDS As DataSet, Optional ByVal BasicDate As String = "") As DataSet Implements IPubServiceManager_T.queryInsuCodeByOrderCode

        Dim instance As PubServiceClient = Nothing

        Try
            instance = getPubService()
            Return instance.queryInsuCodeByOrderCode(OrderCodeDS, BasicDate)
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing Then
                If instance.State = ServiceModel.CommunicationState.Opened Then
                    instance.Close()
                ElseIf Not (instance.State = ServiceModel.CommunicationState.Opened) Then
                    instance.Abort()
                End If
            End If
        End Try

    End Function


#End Region

#Region "2015/06/01 單張報表描述檔維護(Pub_Report_Desc) by ChenYu.Guo"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescdelete(ByRef pk_Report_ID As System.String) As Integer Implements IPubServiceManager.PubReportDescdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubReportDescdelete(pk_Report_ID)
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


#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByLikeColumn(ByRef reportID As String, ByRef reportName As String, ByRef SystemCode As String) As DataSet Implements IPubServiceManager.PubReportDescQueryByLikeColumn

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubReportDescQueryByLikeColumn(reportID, reportName, SystemCode)
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


#Region "     QueryByPK "
    ''' <summary>
    ''' QueryByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescQueryByPK(ByRef pk_Report_ID As System.String) As System.Data.DataSet Implements IPubServiceManager.PubReportDescQueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubReportDescQueryByPK(pk_Report_ID)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubReportDescinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubReportDescinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubReportDescupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubReportDescupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubReportDescupdate(ds)
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

#Region "2015/06/01 報表列印記錄檔查詢作業(Pub_Print_Record) by ChenYu.Guo"

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function PubPrintRecordQueryPrintRecord(ByRef reportID As String, ByRef reportName As String, ByRef createUse As String, ByRef createTime As String, ByRef endTime As String, ByRef printIP As String) As DataSet Implements IPubServiceManager.PubPrintRecordQueryPrintRecord

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPrintRecordQueryPrintRecord(reportID, reportName, createUse, createTime, endTime, printIP)
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

#Region "     將列印報表、預覽報表的資料 新增至 PUB_Print_Record "
    ''' <summary>
    ''' 將列印報表、預覽報表的資料 新增至 PUB_Print_Record
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function insertRPTPrintClient(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.insertRPTPrintClient

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertRPTPrintClient(ds)
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

#Region "2015-06-29 遠端報表列印 by Lits ADD"
    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportConfigByReportId(ByVal inReportId As String) As DataSet Implements IPubServiceManager_T.queryReportConfigByReportId
        Dim instance As New PubServiceClient
        Dim ds_result As DataSet
        Try
            instance = getPubService()
            ds_result = instance.queryReportConfigByReportId(inReportId)
            instance.Close()
            Return ds_result
        Catch ex As Exception
            instance.Abort()
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.Message)
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function


    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportMode(ByVal inReportId As String) As String Implements IPubServiceManager_T.queryReportMode
        Dim instance As New PubServiceClient
        Dim result As String
        Try
            instance = getPubService()
            result = instance.queryReportMode(inReportId)
            instance.Close()
            Return result
        Catch ex As Exception
            instance.Abort()
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.Message)
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function
    ''' <summary>
    ''' 取得報表列印資訊
    ''' </summary>
    ''' <param name="repprtID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function getReportInfo(ByVal repprtID As String, ByVal printerType As String, ByVal printerCond As String) As DataSet Implements IPubServiceManager_T.getReportInfo
        Dim instance As New PubServiceClient
        Dim result As DataSet
        Try
            instance = getPubService()
            result = instance.getReportInfo(repprtID, printerType, printerCond)
            instance.Close()
            Return result
        Catch ex As Exception
            instance.Abort()
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.Message)
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function

    ''' <summary>
    ''' 依Report_ID取得報表設定資料
    ''' </summary>
    ''' <param name="inReportId"></param>
    ''' <param name="inStationNo"></param>
    ''' <param name="inTermCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryReportAllConfig(ByVal inReportId As String, ByVal inStationNo As String, ByVal inTermCode As String) As DataSet Implements IPubServiceManager_T.queryReportAllConfig
        Dim instance As New PubServiceClient
        Dim ds_result As DataSet
        Try
            instance = getPubService()
            ds_result = instance.queryReportAllConfig(inReportId, inStationNo, inTermCode)
            instance.Close()
            Return ds_result
        Catch ex As Exception
            instance.Abort()
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.Message)
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function

#End Region

#Region "2015/07/10 報表維護資料(PUB_Print_Config 與 PUB_Report_Desc) by Kaiwen,Hsiao"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfiginsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPrintConfiginsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfiginsert(ds)
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

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigupdate(ByVal dsPubPrintConfig As System.Data.DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPrintConfigupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigupdate(dsPubPrintConfig, dsPubReportDesc)
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

#Region "     刪除"

    Public Function PUBPrintConfigdelete(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As Integer Implements IPubServiceManager.PUBPrintConfigdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigdelete(pk_Report_Id, pk_Print_Type, pk_Print_Cond)
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

#Region "     QueryByPK "
    Public Function PUBPrintConfigQueryByPK(ByRef pk_Report_Id As System.String, ByRef pk_Print_Type As System.String, ByRef pk_Print_Cond As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBPrintConfigQueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigQueryByPK(pk_Report_Id, pk_Print_Type, pk_Print_Cond)
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

#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigqueryAll() As System.Data.DataSet Implements IPubServiceManager.PUBPrintConfigqueryAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigqueryAll()
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

#Region "     動態查詢 "
    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigdynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As System.Data.DataSet Implements IPubServiceManager.PUBPrintConfigdynamicQueryWithColumnValue

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigdynamicQueryWithColumnValue(columnName, columnValue)
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

#Region "     報表列印記錄檔查詢 "
    ''' <summary>
    ''' 報表列印記錄檔查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigQueryByLikeColumn(ByVal Report_Id As String, ByVal Print_Type As String, ByVal Print_Cond As String, ByVal Printer_Name As String, ByVal Paper_Size As String) As DataSet Implements IPubServiceManager.PUBPrintConfigQueryByLikeColumn

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigQueryByLikeColumn(Report_Id, Print_Type, Print_Cond, Printer_Name, Paper_Size)
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

#Region "     新增 PUB_Print_Config、PUB_Report_Desc 資料 "

    ''' <summary>
    ''' 新增 PUB_Print_Config、PUB_Report_Desc 資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBPrintConfigBSInsert(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPrintConfigBSInsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPrintConfigBSInsert(dsPubPrintConfig, dsPubReportDesc)
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

#Region "2015/07/15 大分科所屬細分科統計(PUB_Department) by ChenYu.Guo"

    ''' <summary>
    ''' 大分科所屬細分科統計
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-07-15</remarks>
    Public Function queryPUBDepartmentCount() As DataSet Implements IPubServiceManager.queryPUBDepartmentCount

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBDepartmentCount()
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

#Region "2015/07/14 病人身高體重登記作業(Pub_Patient_BodyRecord) by Sharon.Du"

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecorddelete(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As Integer Implements IPubServiceManager.PubPatientBodyRecorddelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyRecorddelete(pk_Chart_No, pk_Measure_Time)
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


#Region "     以PK查詢 "
    ''' <summary>
    ''' 以PK查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime) As System.Data.DataSet Implements IPubServiceManager.PubPatientBodyRecordqueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyRecordQueryByPK(pk_Chart_No, pk_Measure_Time)
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


#Region "     以病歷號、來源別、登錄單位查詢 "
    ''' <summary>
    ''' 以病歷號、來源別、登錄單位查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Overloads Function PubPatientBodyRecordqueryPubPatientBodyrecordByCond(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, ByVal ChartNo As String) As System.Data.DataSet Implements IPubServiceManager.PubPatientBodyRecordqueryPubPatientBodyrecordByCond

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyRecordqueryPubPatientBodyrecordByCond(gblSourceTypeId, gblKeyinUnit, ChartNo)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubPatientBodyRecordinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyRecordinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Sharon.Du on 2015-07-14</remarks>
    Public Function PubPatientBodyRecordupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubPatientBodyRecordupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyRecordupdate(ds)
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

#Region "2015/07/27 醫令主檔(PubOrder) by Sean.Lin"

#Region "     查詢醫令項目基本檔 "
    ''' <summary>
    ''' 查詢醫令項目基本檔   
    ''' </summary>
    ''' <param name="strOrderCode">醫令項目碼</param>
    ''' <param name="dc">Y、N，空字串表示不判斷</param>
    ''' <param name="judgeDate" >yyyy/MM/dd，空字串表示不判斷，判斷日當天仍有效的Order</param>
    ''' <remarks>by Sean.Lin on 2015-07-27</remarks>
    Public Function PubOrderqueryByOrderCode(ByVal strOrderCode As String, ByVal dc As String, ByVal judgeDate As String) As DataSet Implements IPubServiceManager.PubOrderqueryByOrderCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubOrderqueryByOrderCode(strOrderCode, dc, judgeDate)
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

#Region "2015/08/07 報表警示設定維護檔(PUB_Report_Alarm) by Hsiao.Kaiwen"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function PUBReportAlarminsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBReportAlarminsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarminsert(ds)
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

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao.Kaiwen on 2015-08-07</remarks>
    Public Function PUBReportAlarmupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBReportAlarmupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmupdate(ds)
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

#Region "     刪除 "

    Public Function PUBReportAlarmdelete(ByRef pk_Report_ID As System.String) As Integer Implements IPubServiceManager.PUBReportAlarmdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmdelete(pk_Report_ID)
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

#Region "     查詢報表警示設定維護檔 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByLikeColumn(ByVal Report_ID As String, ByVal Report_Name As String, ByVal Rpt_Alarm_Count As String, ByVal Rpt_Is_Active As String) As DataSet Implements IPubServiceManager.PUBReportAlarmQueryByLikeColumn

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmQueryByLikeColumn(Report_ID, Report_Name, Rpt_Alarm_Count, Rpt_Is_Active)
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

#Region "     查詢 "
    ''' <summary>
    ''' 查詢PK資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryByPK(ByVal Report_ID As String) As DataSet Implements IPubServiceManager.PUBReportAlarmQueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmQueryByPK(Report_ID)
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

#Region "     查詢報表ID-初始化Combobox "

    ''' <summary>
    ''' 查詢報表ID-初始化Combobox
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmQueryReportId() As DataSet Implements IPubServiceManager.PUBReportAlarmQueryReportId

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmQueryReportId()
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

#Region "     查詢 Alarm Count "

    ''' <summary>
    ''' 查詢 Alarm Count
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2015-07-10</remarks>
    Public Function PUBReportAlarmCountQuery(ByVal Report_ID As String) As Integer Implements IPubServiceManager.PUBReportAlarmCountQuery

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBReportAlarmCountQuery(Report_ID)
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

#Region "2015/08/12 吸菸嚼檳榔問卷(PUB_Patient_Personal_Habits) by ChenYu.Guo"

#Region "     查詢該病患最近一年內的勸戒之記錄 "
    ''' <summary>
    ''' 查詢該病患最近一年內的勸戒之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function QueryInOneYearAdmonishRecord(ByRef ChartNo As String) As DataSet Implements IPubServiceManager.QueryInOneYearAdmonishRecord

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryInOneYearAdmonishRecord(ChartNo)
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

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientPersonalHabitsinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientPersonalHabitsinsert(ds)
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

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientPersonalHabitsupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientPersonalHabitsupdate(ds)
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

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-11</remarks>
    Public Function PUBPatientPersonalHabitsqueryByPK(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBPatientPersonalHabitsqueryByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientPersonalHabitsqueryByPK(pk_Chart_No)
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

#Region "2015/08/12 TOCC問卷(PUB_Patient_TOCC) by ChenYu.Guo"

#Region "     查詢是否存在該患當日之記錄 "
    ''' <summary>
    ''' 查詢是否存在該患當日之記錄
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function PUBPatientTOCCQueryTodayPatientTOCCRecord(ByRef ChartNo As String) As DataSet Implements IPubServiceManager.QueryTodayPatientTOCCRecord

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryTodayPatientTOCCRecord(ChartNo)
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

#Region "     新增TOCC問卷結果 "
    ''' <summary>
    ''' 新增TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen.Yu on 2015-08-14</remarks>
    Public Function PUBPatientTOCCinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientTOCCinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientTOCCinsert(ds)
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

#Region "     修改TOCC問卷結果 "
    ''' <summary>
    ''' 修改TOCC問卷結果
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by ChenYu.Guo on 2015-10-05</remarks>
    Public Function PUBPatientTOCCupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientTOCCupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientTOCCupdate(ds)
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


#Region "2015/08/18 取得APP 伺服器系統日期時間 By Lits"

    Public Function getApServerSystemDateTime() As DateTime Implements IPubServiceManager.getApServerSystemDateTime

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.getApServerSystemDateTime
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

#Region "2015/08/21 診間查詢form診間誤餐登記(PUB_Zone_Room) by ChenYu.Guo"

#Region "     queryPUBZoneRoomForMissMeal "
    ''' <summary>
    ''' queryPUBZoneRoomForMissMeal
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-21</remarks>
    Public Function queryPUBZoneRoomForMissMeal(ByVal Room_Code As String) As DataSet Implements IPubServiceManager.queryPUBZoneRoomForMissMeal

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBZoneRoomForMissMeal(Room_Code)
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


#Region "2015/09/02 報表列印工作 Add By Charles"

    Public Function insertPrintJobData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.insertPrintJobData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertPrintJobData(ds)
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

#Region "2015/09/02 PUBPrintJobQueryUI(報表執行進度查詢) Add By Charles "
    Public Function queryPUBPrintJobByCond(ByVal cond As DataTable) As DataSet Implements IPubServiceManager.queryPUBPrintJobByCond

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPrintJobByCond(cond)
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
    Public Function queryPUBPrintJobReportType() As DataSet Implements IPubServiceManager.queryPUBPrintJobReportType

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPrintJobReportType
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
    Public Function queryPUBPrintJobReportByType(ByVal reportType As String, ByVal userId As String) As DataSet Implements IPubServiceManager.queryPUBPrintJobReportByType

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPrintJobReportByType(reportType, userId)
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

    Public Function increaseDownloadCnt(ByVal JobID As String) As Integer Implements IPubServiceManager.increaseDownloadCnt
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.increaseDownloadCnt(JobID)
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

#Region "2015/09/10 查診展班週數(PUB_Config) by ChenYu.Guo"

#Region "     查診展班週數 "
    ''' <summary>
    ''' 查診展班週數
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-10</remarks>
    Public Function PUBConfigQueryExpandWeek() As DataSet Implements IPubServiceManager.PUBConfigQueryExpandWeek

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBConfigQueryExpandWeek()
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

#Region "2015/09/28 查詢看診目的(PUB_Medical_Type_Id) by Will,Lin"

#Region "     查詢看診目的 "
    ''' <summary>
    ''' 查詢看診目的
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Will,Lin on 2015-09-28</remarks>
    Public Function getPUBMedicalTypeId() As DataSet Implements IPubServiceManager.getPUBMedicalTypeId

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.getPUBMedicalTypeId()
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

#Region "2015/09/29 取得藥品名稱自動搜尋視窗的藥品資料 ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品名稱自動搜尋視窗的藥品資料
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyBase(ByRef orderName As String) As DataTable Implements IPubServiceManager.Get_PharmacyBase

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Get_PharmacyBase(orderName)
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

#Region "2015/09/29 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料 ChenYu.Guo"
    ''' <summary>
    ''' 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料(原Get_PharmacyClass)
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-29</remarks>
    Public Function Get_PharmacyClassAndCompositionAndATC(ByVal orderName As String, ByVal NameType As String) As DataTable Implements IPubServiceManager.Get_PharmacyClassAndCompositionAndATC

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.Get_PharmacyClassAndCompositionAndATC(orderName, NameType)
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

#Region "2015/10/05 查詢TOCC關閉視窗之控制(PUB_Config) by ChenYu.Guo"

#Region "     查詢TOCC關閉視窗之控制 "
    ''' <summary>
    ''' 查詢TOCC關閉視窗之控制
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2015-09-10</remarks>
    Public Function PUBConfigQueryTOCCCloseWindows() As String Implements IPubServiceManager.PUBConfigQueryTOCCCloseWindows

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBConfigQueryTOCCCloseWindows()
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

#Region "2015/10/30 過敏藥品查詢(PUB_Patient_Allergy) by Eddie,Lu"

#Region "     過敏藥品查詢 "
    ''' <summary>
    ''' 過敏藥品查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-10-30</remarks>
    Public Function queryPUBPatientAllergyByCond(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubServiceManager.queryPUBPatientAllergyByCond

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPatientAllergyByCond(pk_Chart_No)
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

#Region "2015/11/11 看診目的基本檔維護作業(PUB_Medical_Type) by Eddie,Lu"

#Region "     一般查詢 "
    ''' <summary>
    ''' 一般查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequery(ByRef medicalTypeId As String, ByRef medicalTypeName As String, ByRef medicalTypeCtrlId As String, ByRef disIdentityCode As String, ByRef Contract_Code1 As String, ByRef Contract_Code2 As String, ByRef partCode As String, ByRef cardSn As String, ByRef icMedicalTypeId As String, ByRef caseTypeId As String, ByVal pedSort As Integer, ByVal surSort As Integer, ByVal medSort As Integer, ByVal entSort As Integer, ByVal uroSort As Integer, ByRef rehSort As Integer, ByVal ipdSort As Integer, ByVal opdSort As Integer, ByVal emgSort As Integer) As DataSet Implements IPubServiceManager.PUBMedicalTypequery

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypequery(medicalTypeId, medicalTypeName, medicalTypeCtrlId, disIdentityCode, Contract_Code1, Contract_Code2, partCode, cardSn, icMedicalTypeId, caseTypeId, pedSort, surSort, medSort, entSort, uroSort, rehSort, ipdSort, opdSort, emgSort)
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


#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypedelete(ByRef pk_Medical_Type_Id As System.String) As Integer Implements IPubServiceManager.PUBMedicalTypedelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypedelete(pk_Medical_Type_Id)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBMedicalTypeinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypeinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypeupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBMedicalTypeupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypeupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryAll() As System.Data.DataSet Implements IPubServiceManager.PUBMedicalTypequeryAll

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypequeryAll()
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

#Region "     取得Cbo資料 "
    ''' <summary>
    ''' 取得Cbo資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBMedicalTypequeryCboData() As DataSet Implements IPubServiceManager.PUBMedicalTypequeryCboData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMedicalTypequeryCboData()
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

#Region "檢驗表單維護 PubLisSheet"

    'Public Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32 Implements IPubServiceManager_T.PubLisSheetInsert
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.PubLisSheetInsert(InputData)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            _client.Close()
    '        End If
    '    End Try
    'End Function

    'Public Function PubLisSheetUpdate(ByVal SheetCode As String, _
    '                                  ByVal SheetName As String, _
    '                                  ByVal DeptCode As String, _
    '                                  ByVal IsEmergencySheet As String, _
    '                                  ByVal SheetCollectNote As String, _
    '                                  ByVal SheetNote As String, _
    '                                  ByVal SheetContactTel As String, _
    '                                  ByVal Dc As String, _
    '                                  ByVal User As String) As Int32 Implements IPubServiceManager_T.PubLisSheetUpdate
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.PubLisSheetUpdate(SheetCode, _
    '                                         SheetName, _
    '                                         DeptCode, _
    '                                         IsEmergencySheet, _
    '                                         SheetCollectNote, _
    '                                         SheetNote, _
    '                                         SheetContactTel, _
    '                                         Dc, _
    '                                         User)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            _client.Close()
    '        End If
    '    End Try
    'End Function

    'Public Function PubLisSheetDelete(ByVal SheetCode As String) As Int32 Implements IPubServiceManager_T.PubLisSheetDelete
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.PubLisSheetDelete(SheetCode)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            _client.Close()
    '        End If
    '    End Try
    'End Function

    'Public Function PubLisSheetQuery(ByVal SheetCode As String, _
    '                                 ByVal SheetName As String, _
    '                                 ByVal DeptCode As String, _
    '                                 ByVal SheetContactTel As String) As DataSet Implements IPubServiceManager_T.PubLisSheetQuery
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.PubLisSheetQuery(SheetCode, _
    '                                        SheetName, _
    '                                        DeptCode, _
    '                                        SheetContactTel)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            _client.Close()
    '        End If
    '    End Try
    'End Function
    ' ''' <summary>
    ' ''' 取得所有大小分科資訊 
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function queryPUBDepartmentAllDept() As DataSet Implements IPubServiceManager_T.queryPUBDepartmentAllDept
    '    Dim _client As PubServiceClient = Nothing

    '    Try
    '        _client = getPubService()
    '        Return _client.queryPUBDepartmentAllDept
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If _client IsNot Nothing Then
    '            If _client.State = ServiceModel.CommunicationState.Opened Then
    '                _client.Close()
    '            ElseIf Not (_client.State = ServiceModel.CommunicationState.Opened) Then
    '                _client.Abort()
    '            End If
    '        End If
    '    End Try
    'End Function
#End Region

#Region "2016/04/19 add by Kaiwen, 排除藥費(PUBExcludeDrugSetBO_E1) "

    Public Function queryExclusiveDrugSetData2(ByVal OrderCode As String) As DataTable Implements IPubServiceManager.queryExclusiveDrugSetData2

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryExclusiveDrugSetData2(OrderCode)
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

    Public Function insertExclusiveDrugSetByOrderCode(ByVal OrderCode As String, ByVal insertData As DataSet) As Integer Implements IPubServiceManager.insertExclusiveDrugSetByOrderCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertExclusiveDrugSetByOrderCode(OrderCode, insertData)
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

#Region "2016/04/19 Add by Kaiwen, 找多個TypeId的syscode (PUBNhiIndexSetUI)【查詢Syscode(多筆)】 "

    ''' <summary>
    ''' 找多個TypeId的syscode
    ''' </summary>
    ''' <param name="TypeIds"></param>
    ''' <returns></returns>
    ''' <remarks>Add by Jen</remarks>
    Public Function querySyscodeByTypeIds(ByVal TypeIds() As Integer) As DataTable Implements IPubServiceManager.querySyscodeByTypeIds

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.querySyscodeByTypeIds(TypeIds)
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

#Region "2016/04/19 查詢健保支付標準檔資料(PUBNhiCodeBO) , Added by Kaiwen "

    Public Function queryPubNhiCodeEffectData(ByVal inEffectDate As String, ByVal inInsuCode As String, ByVal inOrderCode As String) As DataTable Implements IPubServiceManager.queryPubNhiCodeEffectData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubNhiCodeEffectData(inEffectDate, inInsuCode, inOrderCode)
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

#Region "2016/04/19 醫療支付公用主檔 (醫令控制畫面) , Added by Kaiwen"

    'Public Function initPUBOrderUIInfo() As DataSet Implements IPubPartialService.initPUBOrderUIInfo
    '    Try
    '        Dim pubDlg As PUBDelegate = PUBDelegate.getInstance
    '        Return pubDlg.initPUBOrderUIInfo()
    '    Catch ex As Exception
    '        nckuh.server.cmm.ServerExceptionHandler.ProccessException(ex)
    '    End Try
    'End Function

    Public Function initPUBOrderInfo(ByVal initType As String) As DataSet Implements IPubServiceManager.initPUBOrderInfo

        Dim tempclient As PubServiceClient = Nothing

        Try

            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.initPUBOrderInfo(initType)
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

    Public Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet Implements IPubServiceManager.queryOrderData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOrderData(OrderCode, EffectDate)
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

    Public Function checkProcessStatus(ByVal OldOrderDT As DataTable, ByVal NewOrderDT As DataTable) As DataSet Implements IPubServiceManager.checkProcessStatus

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.checkProcessStatus(OldOrderDT, NewOrderDT)
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

    Public Function commitOrderRelatedData(ByVal OrderRelatedData As DataSet) As Integer Implements IPubServiceManager.commitOrderRelatedData


        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.commitOrderRelatedData(OrderRelatedData)
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

    Public Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataSet Implements IPubServiceManager.queryPreOrNextRecordOrder

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPreOrNextRecordOrder(partialOrderCode, orderTypeId, isPre)
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

    Public Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataSet Implements IPubServiceManager.queryPreOrNextRecordOrder2

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)
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

#Region "2016/04/19 舊程式OPHPB_BS , Added by Kaiwen"

#Region "2016/04/19 由Order_Code查詢藥品碼資料(舊程式OPHPB_queryPharmacyBaseByOrderCode(OrderCode)), Added by Kaiwen"


    Public Function queryPharmacyBaseByOrderCode(ByVal OrderCode As String) As DataTable Implements IPubServiceManager.queryPharmacyBaseByOrderCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPharmacyBaseByOrderCode(OrderCode)
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

#Region "2016/04/19  依醫令刪除所有相關表格資料 Log ,  add by Kaiwen "

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
    Public Function deletePUBOrderLog(ByVal inOrderCode As String, ByVal inOrderName As String, ByVal inOrderTypeId As String, ByVal inOrderMode As String, ByVal inExecutionUser As String) As Integer Implements IPubServiceManager.deletePUBOrderLog

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBOrderLog(inOrderCode, inOrderName, inOrderTypeId, inOrderMode, inExecutionUser)
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

    Public Function deletePUBOrderByOrderCode(ByVal inOrderCode As String) As Integer Implements IPubServiceManager.deletePUBOrderByOrderCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBOrderByOrderCode(inOrderCode)
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

#Region "2016/04/19  PUBAddQueryUI ,add by Kaiwen"

    ' "2011/09/07 Add By Immy 兒童加成查詢"
    Public Function QueryAdd(ByVal Order_Code As String) As DataTable Implements IPubServiceManager.QueryAdd

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryAdd(Order_Code)
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

    ' "2011/09/07 Add By Immy 急件加成查詢"
    Public Function QueryAdd_EMG(ByVal Order_Code As String) As DataTable Implements IPubServiceManager.QueryAdd_EMG

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryAdd_EMG(Order_Code)
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

    ' "2011/09/07 Add By Immy 牙科轉診加成查詢"
    Public Function QueryAdd_Dental(ByVal Order_Code As String) As DataTable Implements IPubServiceManager.QueryAdd_Dental

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryAdd_Dental(Order_Code)
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

    ' "2011/09/07 Add By Immy 科別加成查詢"
    Public Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable Implements IPubServiceManager.QueryAdd_Dept

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryAdd_Dept(Order_Code)
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

#Region "2016/04/19 PUBInsuCodeBO , Added by Kaiwen"

#Region " 查詢資料"

    Public Function queryPubInsuCodeEffectData(ByVal inEffectDate As String, ByVal inOrderTypeId As String, ByVal inOrderCode As String) As DataTable Implements IPubServiceManager.queryPubInsuCodeEffectData
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubInsuCodeEffectData(inEffectDate, inOrderTypeId, inOrderCode)
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

#Region "2016/04/22   取得群組醫令, Added by Kaiwen "

    Public Function queryAddOrderData(ByVal AddOrderCode As String) As DataTable Implements IPubServiceManager.queryAddOrderData
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAddOrderData(AddOrderCode)
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

    Public Function queryAddOrderDetailData(ByVal AddOrderCode As String) As DataTable Implements IPubServiceManager.queryAddOrderDetailData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAddOrderDetailData(AddOrderCode)
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

    Public Function queryAddOptionOrderData(ByVal AddOrderCode As String, ByVal AddOrderDetailNo As Integer) As DataTable Implements IPubServiceManager.queryAddOptionOrderData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAddOptionOrderData(AddOrderCode, AddOrderDetailNo)
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


#Region "2016/05/10 更新群組醫令維護檔 By Will"
    ''' <summary>
    ''' InsertTo AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAddOrder(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.UpdateAddOrder
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.UpdateAddOrder(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
    ''' <summary>
    ''' delete AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="addOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteAddOrder(ByVal addOrderCode As String) As Integer Implements IPubServiceManager_T.deleteAddOrder
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.deleteAddOrder(addOrderCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region
#End Region

#Region "2016/04/25 檢驗表單維護 PubLisSheet by Kaiwen"

    Public Function PubLisSheetInsert(ByVal InputData As DataSet) As Int32 Implements IPubServiceManager_T.PubLisSheetInsert
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubLisSheetInsert(InputData)

        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PubLisSheetUpdate(ByVal UpdateData As DataSet) As Int32 Implements IPubServiceManager_T.PubLisSheetUpdate

        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubLisSheetUpdate(UpdateData)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PubLisSheetDelete(ByVal SheetCode As String) As Int32 Implements IPubServiceManager_T.PubLisSheetDelete
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubLisSheetDelete(SheetCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PubLisSheetQuery(ByVal SheetCode As String, _
                                     ByVal SheetName As String, _
                                     ByVal DeptCode As String, _
                                     ByVal SheetContactTel As String) As DataSet Implements IPubServiceManager_T.PubLisSheetQuery

        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubLisSheetQuery(SheetCode, _
                                            SheetName, _
                                            DeptCode, _
                                            SheetContactTel)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#Region "     以ＰＫ查詢資料 "
    Public Function PubSheetQueryByPK(ByVal pk_Sheet_Code As String, ByVal pk_Sheet_Name As System.String, ByVal pk_Dept_Code As System.String) As DataSet Implements IPubServiceManager_T.PubSheetQueryByPK
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubSheetQueryByPK(pk_Sheet_Code, pk_Sheet_Name, pk_Dept_Code)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "     以ＰＫ Like 的方式查詢資料 "
    Public Function PubSheetQueryByLikePK(ByVal pk_Sheet_Code As String) As DataSet Implements IPubServiceManager_T.PubSheetQueryByLikePK
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PubSheetQueryByLikePK(pk_Sheet_Code)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
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
    Public Function queryPUBDepartmentBySourceType(ByVal inSourceType As String) As DataSet Implements IPubServiceManager.queryPUBDepartmentBySourceType

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBDepartmentBySourceType(inSourceType)
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

    Public Function queryPUBDepartmentAllDept() As DataSet Implements IPubServiceManager.queryPUBDepartmentAllDept

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBDepartmentAllDept()
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

#Region "2016/04/26  PUBExaminationSheetDetailMaintainBS 檢驗醫令明細維護, Added by Kaiwen"

    Public Function PUBExaminationSheetDetailMaintainGetInitInfo(ByVal User As String) As DataSet Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainGetInitInfo
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainGetInitInfo(User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainGetOrderList(ByVal SheetCode As String) As DataSet Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainGetOrderList
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainGetOrderList(SheetCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainGetOrderInfo(ByVal OrderCode As String) As DataSet Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainGetOrderInfo
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainGetOrderInfo(OrderCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' 將修改過的資訊寫回資料庫
    ''' </summary>
    ''' <param name="InputData">欲寫入之資料庫</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainWriteBackEditedInfo(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainWriteBackEditedInfo
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainWriteBackEditedInfo(InputData, User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢Pub_Sheet_Detail中符合輸入條件之資料
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <param name="OrderCode">醫令代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainQuerySheetDetail(ByVal SheetCode As String, ByVal OrderCode As String) As DataSet Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainQuerySheetDetail
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainQuerySheetDetail(SheetCode, OrderCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' 新增一筆Order至Pub_Sheet_Detail
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(ByVal InputData As DataSet) As Int32 Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(InputData)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubServiceManager_T.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(InputData, User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "2016/04/26 檢查表單維護,  Added By Kaiwen"

    Public Function initSheetData() As DataSet Implements IPubServiceManager_T.initSheetData
        Dim instance As PubServiceClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            instance = getPubService()
            dsTemp = instance.initSheetData
            instance.Close()
            Return dsTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dsTemp IsNot Nothing Then dsTemp.Dispose()
        End Try
    End Function

    Public Function querySheetDetailData(ByVal SheetCode As String) As DataTable Implements IPubServiceManager_T.querySheetDetailData
        Dim instance As PubServiceClient = Nothing
        Dim dtTemp As DataTable = Nothing
        Try
            instance = getPubService()
            dtTemp = instance.querySheetDetailData(SheetCode)
            instance.Close()
            Return dtTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dtTemp IsNot Nothing Then dtTemp.Dispose()
        End Try
    End Function

    Public Function confirmSheetData(ByVal sheetDS As DataSet) As Boolean Implements IPubServiceManager_T.confirmSheetData
        Dim instance As PubServiceClient = Nothing
        Dim blTemp As Boolean = False
        Try
            instance = getPubService()
            blTemp = instance.confirmSheetData(sheetDS)
            instance.Close()
            Return blTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
        End Try
    End Function

    Public Function queryLikeOrderData(ByVal LikeOrderCode As String) As DataTable Implements IPubServiceManager_T.queryLikeOrderData
        Dim instance As PubServiceClient = Nothing
        Dim dtTemp As DataTable = Nothing
        Try
            instance = getPubService()
            dtTemp = instance.queryLikeOrderData(LikeOrderCode)
            instance.Close()
            Return dtTemp
        Catch ex As Exception
            Throw ex
        Finally
            If instance IsNot Nothing AndAlso instance.State <> ServiceModel.CommunicationState.Closed Then instance.Close()
            If dtTemp IsNot Nothing Then dtTemp.Dispose()
        End Try
    End Function

#End Region

#Region "2016/04/28 PUBRisFormMaintainSheetDetailUI, Added by Kaiwen"

    ''' <summary>
    ''' 新增一筆資料至Pub_Sheet_Detail與Pub_Order_Examination
    ''' </summary>
    ''' <param name="InputData">欲新增之資料</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubServiceManager_T.InsertIntoPubSheetDetailAndPubOrderExamination
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.InsertIntoPubSheetDetailAndPubOrderExamination(InputData, User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' 自Pub_Sheet_Detail與Pub_Order_Examination刪除一筆資料
    ''' </summary>
    ''' <param name="InputData">欲刪除之資料</param>
    ''' <param name="User">操作者</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteFromPubSheetDetailAndPubOrderExamination(ByVal InputData As DataSet, ByVal User As String) As Int32 Implements IPubServiceManager_T.DeleteFromPubSheetDetailAndPubOrderExamination
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.DeleteFromPubSheetDetailAndPubOrderExamination(InputData, User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

    Public Function PUBRisFormMaintainGetAvalibleSheet(ByVal User As String) As DataSet Implements IPubServiceManager_T.PUBRisFormMaintainGetAvalibleSheet
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBRisFormMaintainGetAvalibleSheet(User)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region


#Region "2016/04/28 PUBSheetDisplayUI 表單開單顯示檔維護"

#Region " 查詢"
    ''' <summary>
    ''' 表單開單顯示維護查詢
    ''' </summary>
    ''' <param name="Sheet_Type_Id">表單類別</param>
    ''' <param name="Sheet_Main_Display">表單顯示主分類</param>
    ''' <param name="Sheet_Sub_Display">表單顯示次分類</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function QueryPubSheetDisplayByCond(ByVal Sheet_Type_Id As String, ByVal Sheet_Main_Display As String, ByVal Sheet_Sub_Display As String) As System.Data.DataSet Implements IPubServiceManager_T.QueryPubSheetDisplayByCond
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.QueryPubSheetDisplayByCond(Sheet_Type_Id, Sheet_Main_Display, Sheet_Sub_Display)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region " 新增"
    ''' <summary>
    ''' 表單開單顯示維護Insert
    ''' </summary>
    ''' <param name="InputData">表單類別</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayInsert(ByVal InputData As DataSet) As Int32 Implements IPubServiceManager_T.PUBSheetDisplayInsert
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayInsert(InputData)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "修改"
    ''' <summary>
    ''' 表單開單顯示維護修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayUpdate(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBSheetDisplayUpdate

        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayUpdate(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region "刪除"
    ''' <summary>
    '''表單開單顯示維護以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayDelete(ByRef pk_Sheet_Type_Id As System.String, ByRef pk_Sheet_Main_Display As System.String, ByRef pk_Sheet_Sub_Display As System.String) As Integer Implements IPubServiceManager_T.PUBSheetDisplayDelete
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayDelete(pk_Sheet_Type_Id, pk_Sheet_Main_Display, pk_Sheet_Sub_Display)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#End Region


#Region "2016/05/24  表單開單顯示醫令檔檔基本資料維護, added by Roger"

#Region " 查詢"
    ''' <summary>
    ''' 表單開單顯示醫令檔維護查詢
    ''' </summary>
    ''' <param name="Sheet_Sub_Display">表單顯示次分類</param>
    ''' <param name="Order_Code">醫令代碼</param>
    ''' <param name="Order_Display_Code">醫令顯示代碼</param>
    '''  <param name="Order_Display_Name">醫令顯示名稱</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function QueryPubSheetDisplayOrderByCond(ByVal Sheet_Sub_Display As String, ByVal Order_Code As String, ByVal Order_Display_Code As String, ByVal Order_Display_Name As String) As System.Data.DataSet Implements IPubServiceManager_T.QueryPubSheetDisplayOrderByCond
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.QueryPubSheetDisplayOrderByCond(Sheet_Sub_Display, Order_Code, Order_Display_Code, Order_Display_Name)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region " 新增"
    ''' <summary>
    ''' 表單開單顯示維護Insert
    ''' </summary>
    ''' <param name="InputData">表單類別</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayOrderInsert(ByVal InputData As DataSet) As Int32 Implements IPubServiceManager_T.PUBSheetDisplayOrderInsert
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayOrderInsert(InputData)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "修改"
    ''' <summary>
    ''' 表單開單顯示維護修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayOrderUpdate(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBSheetDisplayOrderUpdate

        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayOrderUpdate(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region "刪除"
    ''' <summary>
    '''表單開單顯示維護以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBSheetDisplayOrderDelete(ByRef pk_Sheet_Sub_Display As System.String, ByRef pk_Order_Display_Code As System.String) As Integer Implements IPubServiceManager_T.PUBSheetDisplayOrderDelete
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBSheetDisplayOrderDelete(pk_Sheet_Sub_Display, pk_Order_Display_Code)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region "20090803 add by Rich, PUBBodySiteBO_E1"
    ''' <summary>
    ''' 部位資料
    ''' </summary>
    ''' <returns>datatable</returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteMainSiteData() As DataSet Implements IPubServiceManager_T.queryPUBBodySiteMainSiteData
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.queryPUBBodySiteMainSiteData()
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "取得ComboBox資料"
    ''' <summary>
    ''' 表單開單顯示醫令檔維護_取得ComboBox資料
    ''' </summary>
    ''' <returns>datatable</returns>
    ''' <remarks></remarks>
    Public Function QueryPubSheetDisplayOrderCombodata(ByVal MainBodySite As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet Implements IPubServiceManager_T.QueryPubSheetDisplayOrderCombodata
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.QueryPubSheetDisplayOrderCombodata(MainBodySite)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "查詢全部"
    Public Function QuerySheetDisplayOrderAll() As System.Data.DataSet Implements IPubServiceManager_T.QuerySheetDisplayOrderAll
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.QuerySheetDisplayOrderAll()
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region "          是否重複資料查詢"
    Public Function QuerySheetDisplayOrderCheckDS(ByVal strOrderCode As String, ByVal strMainBodySite As String, ByVal strBodySite As String, ByVal strSiteID As String) As System.Data.DataSet Implements IPubServiceManager_T.QuerySheetDisplayOrderCheckDS
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.QuerySheetDisplayOrderCheckDS(strOrderCode, strMainBodySite, strBodySite, strSiteID)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
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
    Public Function PostalCodeInsert(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBPostalCodeInsert
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBPostalCodeInsert(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region


#Region " 修改"
    ''' <summary>
    ''' 郵遞區號設定維護修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function PostalCodeupdate(ByVal ds As DataSet) As Integer Implements IPubServiceManager_T.PUBPostalCodeupdate
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBPostalCodeupdate(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region " 刪除"

    ''' <summary>
    '''郵遞區號設定維護以ＰＫ刪除資料
    ''' </summary>
    ''' <param name="Postal_Code"></param>
    ''' <remarks></remarks>
    Public Function PostalCodedelete(ByVal Postal_Code As String) As Integer Implements IPubServiceManager_T.PUBPostalCodedelete
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBPostalCodedelete(Postal_Code)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function
#End Region

#Region " 查詢"
    ''' <summary>
    ''' 郵遞區號設定維護查詢
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>b</remarks>

    Public Function PostalCodequery(ByVal Postal_Code As String, ByVal Postal_Name As String, ByVal County_Name As String, ByVal Town_Name As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet Implements IPubServiceManager_T.PUBPostalCodequery
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.PUBPostalCodequery(Postal_Code, Postal_Name, County_Name, Town_Name)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function



#End Region

#End Region

#Region "預防保健執行設定維護 BY Roger "

#Region "新增"
    Public Function insertPUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_T.insertPUBPreventiveCareExe
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.insertPUBPreventiveCareExe(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try

    End Function
#End Region

#Region "修改"
    Public Function updatePUBPreventiveCareExe(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_T.updatePUBPreventiveCareExe
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.updatePUBPreventiveCareExe(ds)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try

    End Function
#End Region

#Region "刪除"
    Public Function deletePUBPreventiveCareExe(ByRef CareOrderCode As System.String, ByRef PreCareOrderCode As System.String) As Integer Implements IPubServiceManager_T.deletePUBPreventiveCareExe
        Dim _client As PubServiceClient = Nothing

        Try
            _client = getPubService()
            Return _client.deletePUBPreventiveCareExe(CareOrderCode, PreCareOrderCode)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try

    End Function
#End Region

#Region "查詢"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>by Roger</remarks>
    Public Function queryPUBPreventiveCareExeByCond(ByVal PreCareOrderCode As String, ByVal CareOrderCode As String, ByVal AgeControlId As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPUBPreventiveCareExeByCond
        Dim _client As PubServiceClient = Nothing
        Try
            _client = getPubService()
            Return _client.queryPUBPreventiveCareExeByCond(PreCareOrderCode, CareOrderCode, AgeControlId)
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
        End Try
    End Function

#End Region

#Region "取得combobox資料"
    Public Function getPUBPreventiveCareExeCombodata() As DataSet Implements IPubServiceManager_T.getPUBPreventiveCareExeCombodata
        Dim _client As PubServiceClient = Nothing
        Try
            _client = getPubService()
            Return _client.getPUBPreventiveCareExeCombodata()
        Catch ex As Exception
            Throw ex
        Finally
            If _client IsNot Nothing Then
                _client.Close()
            End If
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
    Public Function PUBPatientDNRinsertWithDNRNo(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientDNRinsertWithDNRNo

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientDNRinsertWithDNRNo(ds)
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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryByPKROC(ByRef pk_Chart_No As System.String, ByRef strDNRKindId As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBPatientDNRqueryByPKROC

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientDNRqueryByPKROC(pk_Chart_No, strDNRKindId)
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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRdelete(ByRef pk_Chart_No As System.String, ByRef pk_Source_Kind As System.String, ByRef pk_DNR_No As System.Int32) As Integer Implements IPubServiceManager.PUBPatientDNRdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientDNRdelete(pk_Chart_No, pk_Source_Kind, pk_DNR_No)
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


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRqueryCboDs() As DataSet Implements IPubServiceManager.PUBPatientDNRqueryCboDs

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientDNRqueryCboDs()
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatientDNRupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatientDNRupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientDNRupdate(ds)
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

#Region "2016/06/29 住院護理站基本檔維護(Pub_Station) by Hanru"

#Region "     新增護理站基本檔資料 "
    ''' <summary>
    ''' 新增護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function insertPubStation(ByVal ds As DataSet) As Integer Implements IPubServiceManager.insertPubStation

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertPubStation(ds)
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

#Region "     修改護理站基本檔資料 "
    ''' <summary>
    ''' 修改護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function updatePubStation(ByVal ds As DataSet) As Integer Implements IPubServiceManager.updatePubStation

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updatePubStation(ds)
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

#Region "     刪除護理站基本檔資料 "
    ''' <summary>
    ''' 刪除護理站基本檔資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function deletePubStation(ByRef pk_Station_No As String) As Integer Implements IPubServiceManager.deletePubStation

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePubStation(pk_Station_No)
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

#Region "     查詢護理站基本檔資料 "
    ''' <summary>
    ''' 查詢護理站基本檔資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Hanru on 2016-06-29</remarks>
    Public Function queryPubStationByCond(ByVal pk_Station_No As String) As DataSet Implements IPubServiceManager.queryPubStationByCond

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubStationByCond(pk_Station_No)
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

#Region "2016/08/23 更新病人聯絡資料 Will"

#Region "2016/08/23 更新病人聯絡資料 Will"
    ''' <summary>
    '''更新病人聯絡資料
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePatContactInfo(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.updatePatContactInfo

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updatePatContactInfo(ds)
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

#End Region

#Region "2016/05/20 病患特殊註記顯示排序檔(PUB_Pat_Flag_Sort) by Eddie,Lu"

#Region "     以ＰＫ刪除資料 "
    ''' <summary>
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortdelete(ByRef pk_Flag_Id As System.String) As Integer Implements IPubServiceManager.PUBPatFlagSortdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatFlagSortdelete(pk_Flag_Id)
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
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryByPKROC(ByRef pk_Flag_Id As System.String, ByRef strFlagSortId As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBPatFlagSortqueryByPKROC

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatFlagSortqueryByPKROC(pk_Flag_Id, strFlagSortId)
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


#Region "     取得ComboBox資料 "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortqueryCboDs() As DataSet Implements IPubServiceManager.PUBPatFlagSortqueryCboDs

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatFlagSortqueryCboDs()
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatFlagSortinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatFlagSortinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function PUBPatFlagSortupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBPatFlagSortupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatFlagSortupdate(ds)
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

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱)  By Li.Han"
    Public Function PUBRulequeryRuleNameByCode(ByVal strSQL As String) As String Implements IPubServiceManager.PUBRulequeryRuleNameByCode
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBRulequeryRuleNameByCode(strSQL)
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

#Region "2016/06/07 查詢透析院所代號 (For KLH 用) by ChenYu.Guo"
    ''' <summary>
    ''' 查詢透析院所代號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubHospitalqueryByNow() As System.Data.DataSet Implements IPubServiceManager.PubHospitalqueryByNow
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubHospitalqueryByNow()
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

    '#Region "2016/06/07 以病歷號查詢關聯表的資料 (For KLH 用) by ChenYu.Guo"

    '    ''' <summary>
    '    ''' 以病歷號查詢關聯表的資料
    '    ''' </summary>
    '    ''' <returns>System.Data.DataSet</returns>
    '    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    '    Public Function PubPatientqueryRelationInfoByPK(ByRef pk_Chart_No As System.String, ByRef pk_Pip_Type As System.String) As System.Data.DataSet Implements IPubServiceManager.PubPatientqueryRelationInfoByPK

    '        Dim tempclient As PubServiceClient = Nothing
    '        Try
    '            tempclient = getPubService()

    '            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

    '                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

    '                Return tempclient.PubPatientqueryRelationInfoByPK(pk_Chart_No, pk_Pip_Type)
    '            End Using ' before close

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If tempclient IsNot Nothing Then
    '                If tempclient.State = ServiceModel.CommunicationState.Opened Then
    '                    tempclient.Close()
    '                ElseIf Not (tempclient.State = ServiceModel.CommunicationState.Opened) Then
    '                    tempclient.Abort()
    '                End If
    '            End If
    '        End Try
    '    End Function

    '#End Region

#Region "2009-12-10 Added by Alan,寫入IC卡重大傷病與藥物過敏資料 "

    Public Function InsertPatientData(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet) As Integer Implements IPubServiceManager_T.InsertPatientData

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InsertPatientData(ChartNo, UserId, CriticalIllness, Allergic)
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

    Public Function InsertPatientData2(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet, ByVal Prevent As DataSet) As Integer Implements IPubServiceManager_T.InsertPatientData2

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InsertPatientData2(ChartNo, UserId, CriticalIllness, Allergic, Prevent)
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

#Region "2016/06/07 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄 (For KLH 用) by ChenYu.Guo"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function PubPatientBodyrecordQueryByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubServiceManager.PubPatientBodyrecordQueryByChartNo

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientBodyrecordQueryByChartNo(pk_Chart_No)
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

#Region "2016/06/13 以 Type_Id 查詢資料 by Gary.Chiang"
    ''' <summary>
    ''' 以 Type_Id 查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Kira on 2016-06-13</remarks>
    Public Function PubSyscodeQueryByTypeId(ByRef pk_Type_Id As System.Int32) As System.Data.DataSet Implements IPubServiceManager.PubSyscodeQueryByTypeId
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubSyscodeQueryByTypeId(pk_Type_Id)
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

#Region "2016/06/13 通過Chart_No查詢PUB_Patient_Allergy的資料 by Gary.Chiang"

    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_Allergy的資料
    ''' </summary>
    ''' <remarks></remarks>
    Function PubPatientAllergyqueryTopByChartNo(ByRef pk_Chart_No As System.String) As System.Data.DataSet Implements IPubServiceManager.PubPatientAllergyqueryTopByChartNo

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientAllergyqueryTopByChartNo(pk_Chart_No)
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

#Region "2016/06/17 寫入ISS_Item By Will"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemInsert(ByRef ds As DataSet) As Integer Implements IPubServiceManager.PubIssItemInsert

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubIssItemInsert(ds)
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
    ''' 更新
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemUpdate(ByRef ds As DataSet) As Integer Implements IPubServiceManager.PubIssItemUpdate

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubIssItemUpdate(ds)
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
    ''' 查詢全部
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will on 2016-06-17</remarks>
    Function PubIssItemQueryAll() As DataSet Implements IPubServiceManager.PubIssItemQueryAll

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubIssItemQueryAll()
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
    ''' 查詢最近一筆評分資料
    ''' </summary>
    ''' <param name="pk_Chart_No"></param>
    ''' <param name="pk_Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBPatientISSBOqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Medical_Sn As System.String) As DataSet Implements IPubServiceManager.PUBPatientISSBOqueryByPK

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientISSBOqueryByPK(pk_Chart_No, pk_Medical_Sn)
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
    ''' 刪除
    ''' </summary>
    ''' <param name="Medical_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBPatientISSDelete(ByVal Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer Implements IPubServiceManager.PUBPatientISSDelete

        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatientIssDelete(Medical_Sn, conn)
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
#Region "20160623 入院護理評估的身高體重塞入PUB_Patient_BodyRecord"
    ''' <summary>
    ''' 入院護理評估的身高體重塞入PUB_Patient_BodyRecord
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Kasim on 20160623</remarks>
    Public Function PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PubPatient_BodyRecordUpdateHBbyChartNoForMohw
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPatient_BodyRecordUpdateHBbyChartNoForMohw(ds)
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

#Region "2016/06/30 檢查醫令不須報到部門維護作業(PUB_Order_Exam_Nocheckin_Dept) by Jun"

#Region "     取得門急住個別的不需報到科別 "
    ''' <summary>
    ''' 取得門急住個別的不需報到科別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function getInitialOrderExamNoCheckinDept(ByVal chartNo As String) As System.Data.DataSet Implements IPubServiceManager.getInitialOrderExamNoCheckinDept

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.getInitialOrderExamNoCheckinDept(chartNo)
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

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBOrderExamNocheckinDeptinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderExamNocheckinDeptinsert(ds)
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


#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function PUBOrderExamNocheckinDeptdelete(ByRef pk_Order_Code As System.String) As Integer Implements IPubServiceManager.PUBOrderExamNocheckinDeptdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderExamNocheckinDeptdelete(pk_Order_Code)
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

#Region "2016/07/07 病床資料檔維護 add by kudy.sue"
    Public Function queryPubDeptLeaderByCond(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As System.Data.DataSet Implements IPubServiceManager_T.queryPubDeptLeaderByCond
        Dim client As New PubServiceClient
        Dim ds_return As DataSet

        Try
            client = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPubDeptLeaderByCond(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    '新增
    Public Function insertPubDeptLeader(ByVal dsData As DataSet) As Integer Implements IPubServiceManager_T.insertPubDeptLeader
        Dim client As New PubServiceClient
        Dim flag As Integer
        Try
            client = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertPubDeptLeader(dsData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    '修改
    Public Function updatePubDeptLeader(ByVal dsData As DataSet) As Integer Implements IPubServiceManager_T.updatePubDeptLeader
        Dim client As New PubServiceClient
        Dim flag As Integer
        Try
            client = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updatePubDeptLeader(dsData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    '刪除
    Public Function deletePubDeptLeader(ByVal _Dept_Code As String, ByVal _Leader_Employee_Code As String, ByVal _Effect_Date As String) As Integer Implements IPubServiceManager_T.deletePubDeptLeader
        Dim client As New PubServiceClient
        Dim flag As Integer
        Try
            client = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deletePubDeptLeader(_Dept_Code, _Leader_Employee_Code, _Effect_Date)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

#End Region

#Region "2016/07/15 特殊屬性輸入元件(PUBLabIndication04) by Margaret.Tsai"

#Region "     特殊屬性輸入元件 "
    ''' <summary>
    ''' 特殊屬性輸入元件
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Margaret.Tsai on 2016-07-15</remarks>
    Public Function PUBLabIndication04QureyPUBLabIndication04() As DataSet Implements IPubServiceManager.PUBLabIndication04QureyPUBLabIndication04

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBLabIndication04QureyPUBLabIndication04()
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

    Public Function PUBLabIndication10QureyPUBLabIndication10(ByVal inIDNO As String, ByVal inOrderDate As String) As DataSet Implements IPubServiceManager.PUBLabIndication10QureyPUBLabIndication10

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBLabIndication10QureyPUBLabIndication10(inIDNO, inOrderDate)
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

#Region "2016/08/25 成本中心設定維護(PUB_Acc_Dept) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBAccDeptinsert

        Dim tempclient As PUBServiceClient = Nothing

        Try
            tempclient = getPUBService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAccDeptinsert(ds)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBAccDeptupdate

        Dim tempclient As PUBServiceClient = Nothing

        Try
            tempclient = getPUBService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAccDeptupdate(ds)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function QueryPubAccDeptByPK(ByVal tmp As String) As System.Data.DataSet Implements IPubServiceManager.QueryPubAccDeptByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPubAccDeptByPK(tmp)
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

#Region "     刪除 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function PUBAccDeptDelete(ByVal PK As String) As Integer Implements IPubServiceManager.PUBAccDeptDelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAccDeptDelete(PK)
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


#Region "     成本中心部門查詢 2016-09-19"
    ''' <summary>
    ''' 成本中心部門查詢
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by 林承毅 on 2016-09-19</remarks>
    Public Function QueryPubAccDeptName(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet Implements IPubServiceManager.QueryPubAccDeptName

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPubAccDeptName(conn)
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


#Region "2016/09/19 轉入健保醫令價格異動檔(PUBNhiCodeImportBO_E1) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016/09/19 </remarks>
    Public Function PUBNhiCodeImportBOE1ImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer Implements IPubServiceManager.PUBNhiCodeImportBOE1ImportCase

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportBOE1ImportCase(ds, strDownload_Sn, strUserId)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016/09/19 </remarks>
    Public Function PUBNhiCodeImportBOE1importorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer Implements IPubServiceManager.PUBNhiCodeImportBOE1importorderprice

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportBOE1importorderprice(ds, struser)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2016/09/19 </remarks>
    Public Function PUBNhiCodeImportBOE1query(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet Implements IPubServiceManager.PUBNhiCodeImportBOE1query

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportBOE1query(strNhi_Download_Sn, strInsu_Code, strEffect_Date)
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


#Region "2016/10/01 尋找停用醫令替代項目 By Will Lin"

#Region "     尋找停用醫令替代項目 "
    ''' <summary>
    ''' 尋找停用醫令替代項目
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Public Function queryOrderAlternativeForOEIOtherLack(ByVal OrderCode As String) As DataSet Implements IPubServiceManager.queryOrderAlternativeForOEIOtherLack

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryOrderAlternativeForOEIOtherLack(OrderCode)
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
    ''' 查詢被停用的醫令
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Will Lin 2016/10/01 </remarks>
    Public Function queryPUBOrderDC(ByVal inOrderCode As String) As DataSet Implements IPubServiceManager.queryPUBOrderDC

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBOrderDC(inOrderCode)
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


    ''' <summary>
    ''' 查詢登入使用者可用的表單類別
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingPUBSheet(ByVal currentUser As String) As DataSet Implements IPubServiceManager.queryUserMappingPUBSheet

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryUserMappingPUBSheet(currentUser)
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
    ''' 查詢登入使用者可用的表單對應儀器
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun 2016/10/04 </remarks>
    Public Function queryUserMappingApparatusCode(ByVal currentUser As String) As DataSet Implements IPubServiceManager.queryUserMappingApparatusCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryUserMappingApparatusCode(currentUser)
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

#Region " 2016/10/14 檢核規則維護(PubRuleReason) By Kaiwen "

#Region "     以ＰＫ查詢資料 "
    Public Function queryRuleReasonByRuleCode(ByVal pk_Rule_Code As String) As DataSet Implements IPubServiceManager.queryRuleReasonByRuleCode

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryRuleReasonByRuleCode(pk_Rule_Code)
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

#Region "20130430 add by Alan,自費衛材核定記錄維護"

    Public Function insertPUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager.insertPUBMaterialSelfpayApply
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertPUBMaterialSelfpayApply(dsSaveData)
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

    Public Function updatePUBMaterialSelfpayApply(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager.updatePUBMaterialSelfpayApply
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updatePUBMaterialSelfpayApply(dsSaveData)
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

    Public Function deletePUBMaterialSelfpayApply(ByVal OrderCode As String, ByVal EffectDate As Date) Implements IPubServiceManager.deletePUBMaterialSelfpayApply
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.deletePUBMaterialSelfpayApply(OrderCode, EffectDate)
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

    Public Function queryPUBMaterialSelfpayApply(ByVal sqlString As String) As DataSet Implements IPubServiceManager.queryPUBMaterialSelfpayApply
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBMaterialSelfpayApply(sqlString)
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

#Region "2016/10/20 取得醫院資料 By Chi,Wang "


    Public Function queryHospitalInfo(ByVal HospitalCode As String, ByVal LanguageTypeId As String, ByVal EffectDate As Date) As DataSet Implements IPubServiceManager.queryHospitalInfo

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryHospitalInfo(HospitalCode, LanguageTypeId, EffectDate)
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

#Region "20101217 add by Rich, 事前審查適應症查詢"

    Public Function queryPUBOrderByOrderCode(ByVal Order_Code As String) As System.Data.DataSet Implements IPubServiceManager.queryPUBOrderByOrderCode
        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBOrderByOrderCode(Order_Code)
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

#Region "PUBZoneRoomBO_E1  區診間維護檔"
    Public Function queryPUBZoneRoomByCond(ByVal strZoneId As String, ByVal strRoomCode As String) As DataSet Implements IPubServiceManager.queryPUBZoneRoomByCond
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.queryPUBZoneRoomByCond(strZoneId, strRoomCode)
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

    Public Function insertPUBZoneRoom(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager.insertPUBZoneRoom
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.insertPUBZoneRoom(dsSaveData)
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

    Public Function updatePUBZoneRoom(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager.updatePUBZoneRoom
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.updatePUBZoneRoom(dsSaveData)
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

    Public Function deletePUBZoneRoomByPK(ByVal strZoneId As String, ByVal strRoomCode As String) As Integer Implements IPubServiceManager.deletePUBZoneRoomByPK
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.deletePUBZoneRoomByPK(strZoneId, strRoomCode)
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

#Region "2016/12/15 自費衛材核定記錄維護(PUBMaterialSelfpayApply) by Hsiao,Kaiwen"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBMaterialSelfpayApplyinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMaterialSelfpayApplyinsert(ds)
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

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyupdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBMaterialSelfpayApplyupdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMaterialSelfpayApplyupdate(ds)
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

#Region "     刪除 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function PUBMaterialSelfpayApplyDelete(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As Integer Implements IPubServiceManager.PUBMaterialSelfpayApplyDelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBMaterialSelfpayApplyDelete(pk_Order_Code, pk_Effect_Date)
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
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function queryPubMaterialSelfpayApplyByPK(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet Implements IPubServiceManager.queryPubMaterialSelfpayApplyByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubMaterialSelfpayApplyByPK(pk_Order_Code, pk_Effect_Date)
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

#Region "     以ＰＫ Like 查詢資料 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-15</remarks>
    Public Function queryPubMaterialSelfpayApplyByPKLike(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String) As DataSet Implements IPubServiceManager.queryPubMaterialSelfpayApplyByPKLike

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPubMaterialSelfpayApplyByPKLike(pk_Order_Code, pk_Effect_Date)
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


#Region "2017/02/23 轉入健保醫令價格異動檔(PUBNhiCodeImportMBO) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Public Function PUBNhiCodeImportMImportCase(ByVal ds As System.Data.DataSet, ByVal strDownload_Sn As String, ByVal strUserId As String) As Integer Implements IPubServiceManager.PUBNhiCodeImportMImportCase

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportMImportCase(ds, strDownload_Sn, strUserId)
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


#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Public Function PUBNhiCodeImportMimportorderprice(ByVal ds As System.Data.DataSet, ByVal struser As String) As Integer Implements IPubServiceManager.PUBNhiCodeImportMimportorderprice

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportMimportorderprice(ds, struser)
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


#Region "     查詢全部 "
    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Chi,Wang on 2017-02-23 </remarks>
    Public Function PUBNhiCodeImportMquery(ByVal strNhi_Download_Sn As String, ByVal strInsu_Code As String, ByVal strEffect_Date As String) As System.Data.DataSet Implements IPubServiceManager.PUBNhiCodeImportMquery

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBNhiCodeImportMquery(strNhi_Download_Sn, strInsu_Code, strEffect_Date)
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

#Region "2017/03/21 病患傳送風險(PUBPatientTransferRiskUI) by Will,Lin"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function InsertIntoPUBPatientTransferRisk(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.InsertIntoPUBPatientTransferRisk

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InsertIntoPUBPatientTransferRisk(ds)
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

#Region "     查詢 "
    ''' <summary>
    ''' 查詢病患風險層級
    ''' </summary>
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Will,Lin on 2017-03-21</remarks>
    Public Function QueryPUBPatientTransferRiskLevel(ByVal strChartNo As String, ByVal strOutpatientSn As String) As String Implements IPubServiceManager.QueryPUBPatientTransferRiskLevel

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPUBPatientTransferRiskLevel(strChartNo, strOutpatientSn)
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

#Region "查詢醫令是否已存在(PUB_Sheet_Detail)"
    Public Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet Implements IPubServiceManager.queryPubSheetDetailByOrderCode
        Dim tempclient As PubServiceClient = Nothing
        Try
            tempclient = getPubService()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.queryPubSheetDetailByOrderCode(OrderCode)
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

#Region "2017/04/06 看診目的排序設定(Pub_Medical_Type_Sort) by Chi,Wang"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function InsertPubMedicalTypeSort(ByVal stremployeecode As String) As Integer Implements IPubServiceManager.InsertPubMedicalTypeSort

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.InsertPubMedicalTypeSort(stremployeecode)
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

#Region "     查詢 "
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>System.Data.String</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function QueryPubMedicalTypeSort(ByVal stremployeecode As String) As DataSet Implements IPubServiceManager.QueryPubMedicalTypeSort

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPubMedicalTypeSort(stremployeecode)
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

#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function DeletePubMedicalTypeSort(ByVal stremployeecode As String) As Integer Implements IPubServiceManager.DeletePubMedicalTypeSort

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.DeletePubMedicalTypeSort(stremployeecode)
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

#Region "     修改 "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>System.Data.Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function UpdatePubMedicalTypeSort(ByVal ds As DataSet, ByVal stremployeecode As String) As Integer Implements IPubServiceManager.UpdatePubMedicalTypeSort

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.UpdatePubMedicalTypeSort(ds, stremployeecode)
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

#Region "2017/04/13 檢查醫令不須列印部門維護作業(PUB_Order_Exam_NoPrint_Dept) by Michelle"

#Region "     取得門急住個別的不需列印科別 "
    ''' <summary>
    ''' 取得門急住個別的不需列印科別
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function getInitialOrderExamNoPrintDept(ByVal orderCode As String) As DataSet Implements IPubServiceManager.getInitialOrderExamNoPrintDept

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.getInitialOrderExamNoPrintDept(orderCode)
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


#Region "     刪除 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptdelete(ByRef pk_Order_Code As System.String) As Integer Implements IPubServiceManager.PUBOrderExamNoPrintDeptdelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderExamNoPrintDeptdelete(pk_Order_Code)
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


#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Michelle on 2017-04-13</remarks>
    Public Function PUBOrderExamNoPrintDeptinsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBOrderExamNoPrintDeptinsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderExamNoPrintDeptinsert(ds)
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

#Region "2017/04/14 PubDrAddControlUI 特定醫師加成控制檔維護 by Hsu-Yuan,Yang"

#Region " 新增"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlInsert(ByVal ds As DataSet) As Integer Implements IPubServiceManager.PubDrAddControlInsert

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubDrAddControlInsert(ds)
            End Using

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

#Region " 修改"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_修改
    ''' </summary>
    ''' <param name="ds">更新資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlUpdate(ByVal ds As DataSet) As Integer Implements IPubServiceManager.PubDrAddControlUpdate

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubDrAddControlUpdate(ds)
            End Using

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

#Region " 刪除"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_以PK刪除資料
    ''' </summary>
    ''' <param name="pk_Dept_Code">院內看診科別代碼</param>
    ''' <param name="pk_Employee_Code">醫令碼</param>
    ''' <param name="pk_Order_Code">醫師代號</param>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function PubDrAddControlDelete(ByRef pk_Dept_Code As String, ByRef pk_Order_Code As String, ByRef pk_Employee_Code As String) As Integer Implements IPubServiceManager.PubDrAddControlDelete

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubDrAddControlDelete(pk_Dept_Code, pk_Order_Code, pk_Employee_Code)
            End Using

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

#Region " 查詢"
    ''' <summary>
    ''' 特定醫師加成控制檔維護_以PK查詢資料，若查詢條件皆無，則全查
    ''' </summary>
    ''' <param name="deptCode">院內看診科別代碼 (可傳空字串)</param>
    ''' <param name="orderCode">醫令碼 (可傳空字串)</param>
    ''' <param name="employeeCode">醫師代號 (可傳空字串)</param>
    ''' <returns>查詢DataSet結果</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function QueryPubDrAddControlByPK(ByRef deptCode As String, ByRef orderCode As String, ByRef employeeCode As String) As DataSet Implements IPubServiceManager.QueryPubDrAddControlByPK

        Dim tempclient As PubServiceClient = Nothing

        Try
            tempclient = getPubService()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QueryPubDrAddControlByPK(deptCode, orderCode, employeeCode)
            End Using

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

End Class




