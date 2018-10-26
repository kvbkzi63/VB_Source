Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Client.Servicefactory.PubServiceLReference
Imports Syscom.Client.Servicefactory.PubServiceReference

Partial Class PubServiceManager
    Implements IPubServiceManager_L

#Region "   LA"

#Region "PRSPEC-262-09-460(記帳患者醫令清單) by Elly 2017/01/11"
    Function queryPUBContractsForBILRPT09460() As DataSet Implements IPubServiceManager.queryPUBContractsForBILRPT09460
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBContractsForBILRPT09460()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region


#Region " Add by Elly.Gao on 2016/12/27 for 兵檢資料轉換作業 OHMConvertMilitaryExcelUI"
    Function queryAreaCodeGovByGovADist(ByVal strGovAndDistCode As String) As DataSet Implements IPubServiceManager.queryAreaCodeGovByGovADist
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryAreaCodeGovByGovADist(strGovAndDistCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region


#Region "200901010 轉診轉出--建議轉診科別 by Add tor"
    '取得戶籍地資料來源
    Function queryPUBDeptHealthOpdDeptCodeName_L() As DataSet Implements IPubServiceManager_L.queryPUBDeptHealthOpdDeptCodeName_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBDeptHealthOpdDeptCodeName_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

        End Try
    End Function
#End Region

#Region "20091021 查詢醫令項目基本檔, Order_Type_Id(醫令類型)=’H’(檢驗檢查) Dc = 'N'，add by Tor"

    Function queryPUBOrderByDate_L(ByVal OutDate As String) As DataSet Implements IPubServiceManager_L.queryPUBOrderByDate_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBOrderByDate_L(OutDate)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20150915 PUBDeptSect 科診維護   by Will,Lin"

    ' 依條件查詢科診名稱 
    Function queryPubDeptSectByCond_L(ByVal strDeptCode As String, ByVal strSectId As String) As DataSet Implements IPubServiceManager_L.queryPubDeptSectByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubDeptSectByCond_L(strDeptCode, strSectId)
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
    ' 新增科診名稱 
    Function insertPubDeptSect_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPubDeptSect_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPubDeptSect_L(dsSaveData)
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
    '刪除科診名稱
    Function deletePubDeptSectByPK_L(ByVal strDeptCode As String, ByVal strSectId As String) As Integer Implements IPubServiceManager_L.deletePubDeptSectByPK_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePubDeptSectByPK_L(strDeptCode, strSectId)
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
    '更新科診名稱
    Function updatePubDeptSectByCond_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePubDeptSectByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePubDeptSectByCond_L(dsSaveData)
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

#Region "2015/11/11 科診屬性代碼查詢(PUB_Dept_Sect) by Eddie,Lu"

#Region "     科診屬性代碼查詢 "
    ''' <summary>
    ''' 科診屬性代碼查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function PUBDeptSectqueryCboData(ByVal typeId As Integer) As DataSet Implements IPubServiceManager.PUBDeptSectqueryCboData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDeptSectqueryCboData(typeId)
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

#Region "20150915 PUBDepartmentUI 科室檔維護   by Will,Lin"

    ' 依條件查詢科室檔資料 
    Function queryPUBDepartmentByCond(ByVal strDeptCode As String, ByVal strDeptName As String, ByVal strDeptEnName As String) As DataSet Implements IPubServiceManager_L.queryPUBDepartmentByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDepartmentByCond(strDeptCode, strDeptName, strDeptEnName)
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
    ' 新增科室檔資料 
    Function insertPUBDepartment(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBDepartment
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBDepartment(dsSaveData)
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
    '刪除科室檔資料
    Function deletePUBDepartment(ByVal strDeptCode As String) As Integer Implements IPubServiceManager_L.deletePUBDepartment
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBDepartment(strDeptCode)
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
    '更新科室檔資料
    Function updatePUBDepartment(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBDepartment
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBDepartment(dsSaveData)
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
    Function queryPubDeptSect_L(ByVal strDeptCode As String) As DataSet Implements IPubServiceManager_L.queryPubDeptSect_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubDeptSect_L(strDeptCode)
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

    '獲取Department資料
    Function queryPUBDepartmentCA() As DataSet Implements IPubServiceManager.queryPUBDepartmentCA
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBDepartmentCA()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20090814 PUBBodySiteUI 部位檔維護  by tianxie"

    ' 查詢某一部位 
    Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As DataSet Implements IPubServiceManager_L.queryPUBBodySiteByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBBodySiteByCond(strBodySiteCode)
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
    ' 查詢某一部位 
    Function queryNhiBodySiteCodeByColumnValue(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet Implements IPubServiceManager_L.queryNhiBodySiteCodeByColumnValue
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryNhiBodySiteCodeByColumnValue(columnName, columnValue)
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
    Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As DataSet Implements IPubServiceManager_L.queryMainBodySiteCodeByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryMainBodySiteCodeByCond(strBodySiteCode)
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
    '新增部位
    Function insertPUBBodySite(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.insertPUBBodySite
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBBodySite(ds)
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
    '刪除部位
    Function deletePUBBodySiteByPK(ByRef pk_Body_Site_Code As String) As Integer Implements IPubServiceManager_L.deletePUBBodySiteByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBBodySiteByPK(pk_Body_Site_Code)
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
    '更新部位
    Function updatePUBBodySite(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.updatePUBBodySite
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBBodySite(ds)
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

#Region "20150915 PUBNhiCodeUI 健保支付標準檔  Add by Runxia"

    ' 查詢特定治療項目基本檔資料 
    Function queryPUBMajorNoEquByCond_L(ByVal strMajorcareCode As String) As DataSet Implements IPubServiceManager_L.queryPUBMajorNoEquByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBMajorNoEquByCond_L(strMajorcareCode)
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
    ' 查詢健保支付標準檔,(檢驗檢查)  
    Function queryPUBNhiCodeByCond_L(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet Implements IPubServiceManager_L.queryPUBNhiCodeByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBNhiCodeByCond_L(strEffectDate, strInsuCode)
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
    '刪除健保支付標準檔
    Function deletePUBNhiCodeByInsuCode_L(ByVal strInsuCode As String) As Integer Implements IPubServiceManager_L.deletePUBNhiCodeByInsuCode_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBNhiCodeByInsuCode_L(strInsuCode)
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
    '確定儲存 健保支付標準檔
    Function confirmPUBNhiCode_L(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBNhiCode_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.confirmPUBNhiCode_L(saveData)
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

    Function queryPUBNhiCodeUpDown_L(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet Implements IPubServiceManager_L.queryPUBNhiCodeUpDown_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBNhiCodeUpDown_L(strEffectDate, strInsuCode, itype)
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

    Function queryPUBNhiDeptCode() As DataSet Implements IPubServiceManager_L.queryPUBNhiDeptCode
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBNhiDeptCode()
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

#Region "20100422 PubPatientSevereDiseaseBO 病患重大傷病記錄檔  Add by Runxia"
    '查詢病患重大傷病記錄檔
    Function queryPUBPatientSevereDiseaseByCond_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal dateEffectDate As Date) As DataSet Implements IPubServiceManager_L.queryPUBPatientSevereDiseaseByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPatientSevereDiseaseByCond_L(strChartNo, strIcdCode, dateEffectDate)
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
    '新增病患重大傷病記錄檔
    Function insertPUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.insertPUBPatientSevereDisease_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBPatientSevereDisease_L(ds)
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
    '刪除病患重大傷病記錄檔
    Function deletePUBPatientSevereDisease_L(ByVal strChartNo As String, ByVal strIcdCode As String, ByVal strEffectDate As String) As Integer Implements IPubServiceManager_L.deletePUBPatientSevereDisease_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBPatientSevereDisease_L(strChartNo, strIcdCode, strEffectDate)
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
    '修改病患重大傷病記錄檔
    Function updatePUBPatientSevereDisease_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.updatePUBPatientSevereDisease_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBPatientSevereDisease_L(ds)
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

    '由Icd_code查詢對應的診斷英文名
    Function queryPubDiseaseEnNameByIcdCode_L(ByVal strIcdCode As String) As DataSet Implements IPubServiceManager_L.queryPubDiseaseEnNameByIcdCode_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubDiseaseEnNameByIcdCode_L(strIcdCode)
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

#Region "     病歷號查詢(顯示是否) "
    ''' <summary>
    ''' 病歷號查詢(顯示是否)
    ''' </summary>
    ''' <returns>String) as DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-03</remarks>
    Public Function PUBPatientSevereDiseasequeryByPKYNShow(ByRef pk_Chart_No As String, ByRef pk_Icd_Code As String, ByRef pk_Effect_Date As Date) As DataSet Implements IPubServiceManager.PUBPatientSevereDiseasequeryByPKYNShow

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPatientSevereDiseasequeryByPKYNShow(pk_Chart_No, pk_Icd_Code, pk_Effect_Date)
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

#Region "20150914 PUBPatientHealthCardUI 全國醫療卡維護檔 Add by Will,Lin"

    Function queryPUBPatientHealthCardByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As DataSet Implements IPubServiceManager_L.queryPUBPatientHealthCardByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPatientHealthCardByCond_L(strChartNo, strEffectDate)
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

    Function queryPubPatientFlagByChartNo_L(ByVal strChartNo As String) As DataSet Implements IPubServiceManager_L.queryPubPatientFlagByChartNo_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPubPatientFlagByChartNo_L(strChartNo)
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
    '新增全國醫療服務卡維護檔
    Function insertPUBPatientHealthCard_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.insertPUBPatientHealthCard_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBPatientHealthCard_L(ds)
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
    Function insertPUBHealthAndFlag_L(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer Implements IPubServiceManager_L.insertPUBHealthAndFlag_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBHealthAndFlag_L(dsHealth, dsFlag, blFlag)
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
    Function updatePUBPatientHealthCard_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.updatePUBPatientHealthCard_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBPatientHealthCard_L(ds)
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
    Function deletePUBPatientHealthCard_L(ByVal strChartNo As String, ByVal strEffectDate As String) As Integer Implements IPubServiceManager_L.deletePUBPatientHealthCard_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBPatientHealthCard_L(strChartNo, strEffectDate)
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

#Region "20150911 PUBPhaServicesUI 藥事服務費基本檔 Add by Will,Lin"
    '依條件查詢輸入護理資訊檔資料
    Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBPhaServicesByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPhaServicesByCond(strMainIdentityId, strDeptCode, strPhaServicesTypeId, strOrderCode)
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

    '新增輸入護理資訊檔資料
    Function insertPUBPhaServices(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBPhaServices
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBPhaServices(dsSaveData)
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
    '刪除輸入護理資訊檔資料
    Function deletePUBPhaServicesByPK(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String) As Integer Implements IPubServiceManager_L.deletePUBPhaServicesByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBPhaServicesByPK(strMainIdentityId, strDeptCode, strPhaServicesTypeId)
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
    '更新輸入護理資訊檔資料
    Function updatePUBPhaServices(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBPhaServices
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBPhaServices(dsSaveData)
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

#Region "20150911 PUBDisIdentityUI 優待身份基本檔維護 Add by Will,Lin"

    '查詢優待身份基本資料
    Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As DataSet Implements IPubServiceManager_L.queryPUBDisIdentityByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDisIdentityByCond(DisIdentityCode)
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
    '新增優待身份基本檔資料
    Function insertPUBDisIdentity(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.insertPUBDisIdentity
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBDisIdentity(ds)
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
    '刪除優待身份基本檔資料
    Function deletePUBDisIdentityByPK(ByRef DisIdentityCode As String) As Integer Implements IPubServiceManager_L.deletePUBDisIdentityByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBDisIdentityByPK(DisIdentityCode)
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
    '修改優待身份基本檔資料
    Function updatePUBDisIdentity(ByVal ds As Data.DataSet) As Integer Implements IPubServiceManager_L.updatePUBDisIdentity
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBDisIdentity(ds)
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

#Region "20150911 PUBDisIdentitySetUI 優待身分折扣設定檔 add by Will,Lin"

    '依條件查詢費用項目對應檔資料
    Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBDisIdentitySetByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBDisIdentitySetByCond(dateEffectDate, strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
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

    '新增費用項目對應檔
    Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBDisIdentitySet
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.confirmPUBDisIdentitySet(saveData)
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

#Region "20150911 PUBAccountUI 項目費用對應檔 add by Will,Lin"
    '費用項目對應檔維護- 依傳入TypeID取得代碼檔資料
    Function queryPUBSysCode_L(ByVal TypeID As String) As DataSet Implements IPubServiceManager_L.queryPUBSysCode_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSysCode_L(TypeID)
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


    '刪除費用項目對應檔
    Function deletePUBAccountByPK(ByVal strAccountId As String) As Integer Implements IPubServiceManager_L.deletePUBAccountByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBAccountByPK(strAccountId)
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

    '依條件查詢費用項目對應檔資料
    Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBAccountByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBAccountByCond(strAccountId)
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

    '新增費用項目對應檔
    Function insertPUBAccount(ByVal saveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBAccount
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBAccount(saveData)
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
    '更新費用項目對應檔
    Function updatePUBAccount(ByVal saveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBAccount
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBAccount(saveData)
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


#Region "20150911 PUBExamineUI 診察費基本檔維護 add by Will,Lin"
    Function queryPUBExamineByCond_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                     ByVal strDeptCode As String, ByVal strSectionId As String, _
                                     ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                     ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBExamineByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBExamineByCond_L(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId, strOrderCode)
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

    Function insertPUBExamine_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBExamine_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBExamine_L(dsSaveData)
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

    Function deletePUBExamineByPK_L(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                  ByVal strDeptCode As String, ByVal strSectionId As String, _
                                  ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String) As Integer Implements IPubServiceManager_L.deletePUBExamineByPK_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBExamineByPK_L(strSubIdentityId, strFirstReg, strDeptCode, strSectionId, strExamineTypeId, strMedicalTypeId)
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
    Function updatePUBExamine_L(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBExamine_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBExamine_L(dsSaveData)
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

#Region "20150911 PUBPartDiscountUI 部份負擔優待基本檔維護 add by Will,Lin"

    Function queryPUBPartByAll() As DataSet Implements IPubServiceManager_L.queryPUBPartByAll
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPartByAll()
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
    Function queryPUBSubIdentityForCombo_L() As DataSet Implements IPubServiceManager_L.queryPUBSubIdentityForCombo_L

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSubIdentityForCombo_L()
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

    Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceManager_L.queryPUBPartDiscountByCond

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPartDiscountByCond(dateEffectDate, strDisIdentityCode, strPartCode, strSubIdentityCode)
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

    Function confirmPUBPartDiscount(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBPartDiscount

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.confirmPUBPartDiscount(saveData)
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

#Region "20150910 PUBPartUI 部分負擔基本檔 add by Will,Lin"

    Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String) As DataSet Implements IPubServiceManager_L.queryPUBPartByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPartByCond(dateEffectDate, strPartCode)
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
    Function confirmPUBPart(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBPart

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.confirmPUBPart(saveData)
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

#Region "20150909 PUBRegisterFeeUI 掛號費基本維護檔 add by Will,Lin"

    Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBRegisterFeeByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBRegisterFeeByCond(pk_Source_Id, strSubIdentityCode, strDeptCode, strMedicalTypeId, strOrderCode, strSectionId, strFirstReg)
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
    Function insertPUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.insertPUBRegisterFee

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBRegisterFee(ds)
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

    Function updatePUBRegisterFee(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.updatePUBRegisterFee

        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBRegisterFee(ds)
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
    Function deletePUBRegisterFeeByPK(ByVal pk_Source_Id As String, ByRef pk_Sub_Identity_Code As System.String, ByVal strFirstReg As String, ByRef pk_Dept_Code As System.String, ByRef pk_Section_Id As System.String, ByRef pk_Medical_Type_Id As System.String) As Integer Implements IPubServiceManager_L.deletePUBRegisterFeeByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBRegisterFeeByPK(pk_Source_Id, pk_Sub_Identity_Code, strFirstReg, pk_Dept_Code, pk_Section_Id, pk_Medical_Type_Id)
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

#Region "20150909 PUBPtDisabilityUI 病患殘障記錄檔 add by Will,Lin"

    Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBPtDisabilityByCond_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPtDisabilityByCond_L(pk_Chart_No, pk_Patient_Disability_No)
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

    Function insertPUBPtDisability_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.insertPUBPtDisability_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBPtDisability_L(ds)
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

    Function updatePUBPtDisabilityByPK_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.updatePUBPtDisabilityByPK_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBPtDisabilityByPK_L(ds)
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
    Function deletePUBPtDisabilityByPK_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As Integer) As Integer Implements IPubServiceManager_L.deletePUBPtDisabilityByPK_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBPtDisabilityByPK_L(pk_Chart_No, pk_Patient_Disability_No)
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
    Function queryPUBSysCodeByTypeIdForDisability_L(ByVal strTypeId As String) As DataSet Implements IPubServiceManager_L.queryPUBSysCodeByTypeIdForDisability_L
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSysCodeByTypeIdForDisability_L(strTypeId)
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

#Region "20150904 PUBSubIdentityUI 身份二代碼基本檔 add by Will,Lin"

    Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceManager_L.queryPUBPatientQuotaByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBPatientQuotaByCond(dateEffectDate, strContractCode, strChartNo, strSubIdentityCode)
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

    Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBPatientQuota
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.confirmPUBPatientQuota(saveData)
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

#Region "20150904 PUBMajorcareUI 特定治療項目基本檔維護 add by Will,Lin"

    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet Implements IPubServiceManager_L.queryPUBMajorcareByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBMajorcareByCond(strMajorcareCode)
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

    Function insertPUBMajorcare(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBMajorcare
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBMajorcare(dsSaveData)
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

    Function updatePUBMajorcare(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBMajorcare
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBMajorcare(dsSaveData)
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

    Function deletePUBMajorcareByPK(ByVal strMajorcareCode As String) As Integer Implements IPubServiceManager_L.deletePUBMajorcareByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBMajorcareByPK(strMajorcareCode)
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

#Region "20150904 PUBSubIdentityUI 身份二代碼基本檔 add by Will,Lin"

    Function queryPUBSubIdentityByCond(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBSubIdentityByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBSubIdentityByCond(strSubIdentityCode, strMainIdentityId)
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

    Function insertPUBSubIdentity(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBSubIdentity
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBSubIdentity(dsSaveData)
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

    Function updatePUBSubIdentity(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBSubIdentity
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBSubIdentity(dsSaveData)
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

    Function deletePUBSubIdentityByPK(ByVal strSubIdentityCode As String, ByVal strMainIdentityId As String) As Integer Implements IPubServiceManager_L.deletePUBSubIdentityByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBSubIdentityByPK(strSubIdentityCode, strMainIdentityId)
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

#Region "20150903 PUBContractQuotaUI 合約機構記賬累積檔維護 add by Will,Lin"

    Function confirmPUBSubIdentitySet(ByVal dsSaveData As DataSet) As DataSet Implements IPubServiceManager.confirmPUBSubIdentitySet
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.confirmPUBSubIdentitySet(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function


    Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                          ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                          ByVal strOrderCode As String) As System.Data.DataSet Implements IPubServiceManager.queryPUBSubIdentitySetByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBSubIdentitySetByCond(dateEffectDate, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20150903 PUBContractUI 合約機構基本檔 add by Will,Lin"

    Function queryPUBContractByCond(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBContractByCond
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.queryPUBContractByCond(strContractCode, strSubIdentityCode)
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

    Function deletePUBContractByPK(ByVal strContractCode As String, ByVal strSubIdentityCode As String) As Integer Implements IPubServiceManager_L.deletePUBContractByPK
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.deletePUBContractByPK(strContractCode, strSubIdentityCode)
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

    Function insertPUBContract(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBContract
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.insertPUBContract(dsSaveData)
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

    Function updatePUBContract(ByVal dsSaveData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBContract
        Dim instance As PubServiceLClient = Nothing
        Try
            instance = getPubServiceL()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.updatePUBContract(dsSaveData)
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

#Region "20150903 PUBContractQuotaUI 合約機構記賬累積檔維護 add by Will,Lin"

    Function queryPUBContractQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceManager.queryPUBContractQuotaByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBContractQuotaByCond(dateEffectDate, strContractCode, strSubIdentityCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function


    Function confirmContractQuota(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager.confirmContractQuota
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.confirmContractQuota(saveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20150903 PUBContractPartSetUI 合約身份部份負擔記帳設定檔 add by Will,Lin"

    Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager.confirmPUBContractPart
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.confirmPUBContractPart(saveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function


    Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String) As DataSet Implements IPubServiceManager.queryPUBContractPartSetByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBContractPartSetByCond(dateEffectDate, strContractCode, strSubIdentityCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
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
    ''' 
    Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean) As System.Data.DataSet Implements IPubServiceManager.queryPUBContractSetByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBContractSetByCond(dateEffectDate, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, isNullQuerySubIdentityCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function


    Function queryPUBSubIdentityByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceManager.queryPUBSubIdentityByCV
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBSubIdentityByCV(strColumnName, strColumnValue)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryPUBContractByColumnValue2_L(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceManager.queryPUBContractByColumnValue2_L
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBContractByColumnValue2_L(strColumnName, strColumnValue)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
    Function queryPUBContractByColumnValue(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceManager.queryPUBContractByColumnValue
        Dim client As New PubServiceLClient
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return client.queryPUBContractByColumnValue(strColumnName, strColumnValue)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
            If client IsNot Nothing Then
                If client.State = ServiceModel.CommunicationState.Opened Then
                    client.Close()
                ElseIf Not (client.State = ServiceModel.CommunicationState.Opened) Then
                    client.Abort()
                End If
            End If
        End Try
    End Function
    Function confirmContractSet(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager.confirmContractSet
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.confirmContractSet(saveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20150831 PUBAddPartUI 加收部分負擔維護檔 add by Will,Lin"

    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String) As DataSet Implements IPubServiceManager.queryPUBAddPartByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBAddPartByCond(dateEffectDate, strPartTypeId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function


    Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet Implements IPubServiceManager.confirmPUBAddPart
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.confirmPUBAddPart(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20090724 取得登錄人員信息   by Add Ming"
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet Implements IPubServiceManager.queryPUBEmployeeByCode
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBEmployeeByCode(EmployeeCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20100526 PUBDepartmentBO_E2  次專科基本檔所屬科別combobox資料  add by liuye"
    Function queryPUBDepartmentEffectByColumnValue_L(ByVal strColumnName As String(), ByVal strColumnValue As Object()) As DataSet Implements IPubServiceManager.queryPUBDepartmentEffectByColumnValue_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBDepartmentEffectByColumnValue_L(strColumnName, strColumnValue)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20091127 PUBConfigBO_E2 庫別查詢 add by liuye"
    Function queryConsuDept_L() As DataSet Implements IPubServiceManager_L.queryConsuDept_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryConsuDept_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20090703 PUBSysCodeBO 共用代碼檔維護 by Add Syscom Yunfei"

    ' 獲取PUBSysCodeBO資料
    Function queryPUBSysCodeByCV(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceManager_L.queryPUBSysCodeByCV
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBSysCodeByCV(strColumnName, strColumnValue)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20090708 PUBDepartmentBO_E1 取得科系資料來源 by Add Syscom Johsn"
    Function queryPUBDepartmentCode() As DataSet Implements IPubServiceManager_L.queryPUBDepartmentCode
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBDepartmentCode()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

#End Region

#Region "20091012 查詢  轉診回覆  by Add ChenYang"

    Function queryPubPatientByPK_L(ByRef pk_Chart_No As System.String) As DataSet Implements IPubServiceManager_L.queryPubPatientByPK_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubPatientByPK_L(pk_Chart_No)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

        End Try
    End Function
    'Function queryPubHospitalByKey_L(ByVal LanguageTypeId As String, ByVal EffectDate As String) As DataSet Implements IPubServiceManager_L.queryPubHospitalByKey_L
    '    Dim client As New PubServiceLClient
    '    Dim returnValue As DataSet = Nothing
    '    Try
    '        client = getPubServiceL()
    '        Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
    '            AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
    '            returnValue = client.queryPubHospitalByKey_L(LanguageTypeId, EffectDate)
    '        End Using ' before close
    '        client.Close()
    '        Return returnValue
    '    Catch ex As Exception
    '        client.Abort()
    '        Throw ex
    '    Finally
    '        If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
    '    End Try
    'End Function

#End Region

#Region "20100107 prisendInfo查詢  Add by liuye"
    Function queryprisendInfo_L() As DataSet Implements IPubServiceManager_L.queryprisendInfo_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryprisendInfo_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20111009 編輯死亡證明書 查詢資料 add by mark zhang "

    Function queryPUBPostalCodeForCountryName_L() As DataSet Implements IPubServiceManager_L.queryPUBPostalCodeForCountryName_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBPostalCodeForCountryName_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function queryPUBPostalCodeForTownName_L(ByVal strCountryName As String) As DataSet Implements IPubServiceManager_L.queryPUBPostalCodeForTownName_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBPostalCodeForTownName_L(strCountryName)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function queryPUBPatientForOMODiagnosisCertificate_L(ByVal strChartNo As String) As DataSet Implements IPubServiceManager_L.queryPUBPatientForOMODiagnosisCertificate_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBPatientForOMODiagnosisCertificate_L(strChartNo)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function


    Function queryPUBDoctorLicenseByEmployeeCode_L(ByVal EmployeeCode As String) As DataSet Implements IPubServiceManager_L.queryPUBDoctorLicenseByEmployeeCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBDoctorLicenseByEmployeeCode_L(EmployeeCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function


#End Region

#Region "200901012 以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"

    Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet Implements IPubServiceManager_L.queryPUBPatientBychartNo_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBPatientBychartNo_L(chartNo)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

        End Try
    End Function
#End Region

#Region "20100622  常用維護科別資料來源 add by coco"
    Function queryRefferalDeptOMO_L() As DataSet Implements IPubServiceManager_L.queryRefferalDeptOMO_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryRefferalDeptOMO_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20110106 營養諮詢作業使用 add by yunfei"
    ''' <summary>
    ''' 查詢所屬科室之醫師信息
    ''' </summary>
    ''' <param name="DeptCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBDoctorByDeptCode(ByVal DeptCode As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBDoctorByDeptCode
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBDoctorByDeptCode(DeptCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20090817 PubOrderOrTreatBO 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位 add by windfog"
    ''' <summary>
    ''' 醫令代碼讀取手術處置基本檔 (PubOrderOrTreatBO) 中預設部位
    ''' </summary>
    ''' <param name="strOrder_Code">令代碼</param>
    ''' <returns>手術處置基本檔 (PubOrderOrTreatBO) 中預設部位</returns>
    ''' <remarks></remarks>
    Function queryDefault_Body_Site_Code(ByVal strOrder_Code As String, ByVal strFavor_Type_Id As String) As String Implements IPubServiceManager_L.queryDefault_Body_Site_Code
        Dim client As New PubServiceLClient
        Dim strString As String
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                strString = client.queryDefault_Body_Site_Code(strOrder_Code, strFavor_Type_Id)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return strString
    End Function
    Function queryPUBOrderMappingSpecimenByOrderCode(ByVal strOrder_Code As String) As DataSet Implements IPubServiceManager_L.queryPUBOrderMappingSpecimenByOrderCode
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBOrderMappingSpecimenByOrderCode(strOrder_Code)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20100303 獲得所屬部門下的所有部門   by Add ming"

    Function queryPUBDepartmentByCode_L(ByVal code As String) As DataSet Implements IPubServiceManager_L.queryPUBDepartmentByCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBDepartmentByCode_L(code)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

        End Try
    End Function
#End Region

    ''' <summary>
    ''' 查找部位當中的所有沒有刪除的部位資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteUnDelete() As DataSet Implements IPubServiceManager_L.queryPUBBodySiteUnDelete
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBBodySiteUnDelete()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

#Region "2012/05/24 與RuleTransfer_N1關聯的切出部分(PUBRuleTransferN1BS_E2) by liuye"

#Region "     與RuleTransfer_N1關聯的切出部分 "
    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-5-24</remarks>
    Function QuerymessageDataSet_L(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult As Integer, ByRef messageDataSet As DataSet) As Integer Implements IPubServiceManager_L.QuerymessageDataSet_L

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.QuerymessageDataSet_L(dsQueryCond, OperationDS, totalRuleResult, messageDataSet)
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

#Region "20100427 查詢 PUBConfigBO_E2 ,add by Mark"

    ''' <summary>
    ''' 查詢 PUBConfigBO_E2
    ''' </summary>
    ''' <param name="pk_Config_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBConfigByPK_L(ByVal pk_Config_Name As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBConfigByPK_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBConfigByPK_L(pk_Config_Name)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20091012 PUPHospitalBO_E2 根據傳入時間查詢 by Add Tor"

    Function queryPUBHospitalBOByReferralOutDate_L(ByVal strReferralOutDate As String) As DataSet Implements IPubServiceManager_L.queryPUBHospitalBOByReferralOutDate_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBHospitalBOByReferralOutDate_L(strReferralOutDate)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()

        End Try
    End Function
#End Region

#Region "20091102 取得外國國籍名稱 , Add by tony"
    Function queryNationalName_L() As DataSet Implements IPubServiceManager_L.queryNationalName_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryNationalName_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20091102 取得居住地區欄位 , Add by tony"
    Function queryAreaCode_L() As DataSet Implements IPubServiceManager_L.queryAreaCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryAreaCode_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20091103 取得肺結核資料 , Add by tony"
    Function queryTuberculosis_L() As DataSet Implements IPubServiceManager_L.queryTuberculosis_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryTuberculosis_L()
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20090818 PUBSyscodeBO 公用代碼檔維護  by mark"
    Function queryPUBSyscodeByCond(ByVal iTypeId As Integer, ByVal strCodeId As String) As DataSet Implements IPubServiceManager.queryPUBSyscodeByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBSyscodeByCond(iTypeId, strCodeId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

#End Region

#Region "20150918 PUBPatientDisabilityUI 病患殘障紀錄檔   by Will,Lin"

    Function queryPUBPatientDisabilityByCond_L(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet Implements IPubServiceManager.queryPUBPatientDisabilityByCond_L
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBPatientDisabilityByCond_L(strChartNo, strEffectDate)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
    Function confirmPUBPatientDisability_L(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer Implements IPubServiceManager.confirmPUBPatientDisability_L
        Dim client As New PubServiceLClient
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return client.confirmPUBPatientDisability_L(strChartNo, strEffectDate, ds, blflag)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function
    Function queryMaxPatientDisabilityNo_L(ByVal strChartNo As String) As DataSet Implements IPubServiceManager.queryMaxPatientDisabilityNo_L
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryMaxPatientDisabilityNo_L(strChartNo)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

#End Region

#Region ""
    Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet Implements IPubServiceManager.queryPUBBodySiteNotMainSiteData
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBBodySiteNotMainSiteData(MainBodySiteCode, conn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    Function queryOrderMappingSpecimenByCond4(ByVal OrderCode As String) As DataSet Implements IPubServiceManager.queryOrderMappingSpecimenByCond4
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryOrderMappingSpecimenByCond4(OrderCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function
#End Region

#Region "20150915 PUBPatientBO_E2 根據病歷號查詢 ,add by Remote"
    ''' <summary>
    '''  國際疫苗申請書輸入依條件查詢
    ''' </summary>
    ''' <param name="strChart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet Implements IPubServiceManager_L.queryPUBPatientAndBasicData
        Dim client As New PubServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryPUBPatientAndBasicData(strChart_No)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function
#End Region


#Region "2015/10/20 檢核規則維護 成醫舊程式搬移 by HE,Alien"

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 查詢 "

    Public Function queryByPkRuleCode(ByVal pk_Rule_Code As System.String) As DataSet Implements IPubServiceManager.queryByPkRuleCode
        Dim client As PubServiceLClient = Nothing
        Dim ds As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryByPkRuleCode(pk_Rule_Code)
            End Using ' before close
            client.Close()
            Return ds

        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

#End Region

#Region "2016/10/11 檢核規則理由DGV(dgv_CheckReason) - 刪除 "

    Public Function deleteByPkRuleCode(ByVal pk_Rule_Code As System.String) As Integer Implements IPubServiceManager.deleteByPkRuleCode
        Dim client As PubServiceLClient = Nothing
        Dim integerTemp As Integer = -1
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                integerTemp = client.deleteByPkRuleCode(pk_Rule_Code)
            End Using ' before close
            client.Close()
            Return integerTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

#End Region

    Public Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer Implements IPubServiceManager.confirmRuleData
        Dim client As PubServiceLClient = Nothing
        Dim integerTemp As Integer = -1
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                integerTemp = client.confirmRuleData(confirmType, RuleDS)
            End Using ' before close
            client.Close()
            Return integerTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function deleteRuleData(ByVal ruleCode As String) As Boolean Implements IPubServiceManager.deleteRuleData
        Dim client As PubServiceLClient = Nothing
        Dim booleanTemp As Boolean = False
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                booleanTemp = client.deleteRuleData(ruleCode)
            End Using ' before close
            client.Close()
            Return booleanTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 改名稱
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getExprre(ByVal ds As String) As String Implements IPubServiceManager.getExprre
        Dim client As New PubServiceLClient
        Dim ds_result As String = ""
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_result = client.getExprre(ds)
            End Using ' before close
            client.Close()
            Return ds_result
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function getRuleSerialNo() As String Implements IPubServiceManager.getRuleSerialNo
        Dim client As PubServiceLClient = Nothing
        Dim strTemp As String = ""
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                strTemp = client.getRuleSerialNo()
            End Using ' before close
            client.Close()
            Return strTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function initPUBRuleCheckUIInfo() As DataSet Implements IPubServiceManager.initPUBRuleCheckUIInfo
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.initPUBRuleCheckUIInfo()
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function initPUBRuleQueryInfo() As DataSet Implements IPubServiceManager.initPUBRuleQueryInfo
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.initPUBRuleQueryInfo()
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    '記錄使用者更新或刪除檢核規則
    Public Function InsertPUB_Rule_Transaction_Log(ByVal ds As DataSet) As Integer Implements IPubServiceManager.InsertPUB_Rule_Transaction_Log
        Dim client As PubServiceLClient = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return client.InsertPUB_Rule_Transaction_Log(ds)
            End Using ' before close
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet Implements IPubServiceManager.queryRuleByCondition
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.queryRuleByCondition(itemParam, detailParam)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet Implements IPubServiceManager.queryRuleDataByRuleParam
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.queryRuleDataByRuleParam(RuleParam)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable Implements IPubServiceManager.queryRuleDoctorByEmployeeCodes
        Dim client As PubServiceLClient = Nothing
        Dim dtTemp As DataTable = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dtTemp = client.queryRuleDoctorByEmployeeCodes(employeeCodes)
            End Using ' before close
            client.Close()
            Return dtTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet Implements IPubServiceManager.queryRuleGroup
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.queryRuleGroup(itemParam)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function querySelectedRuleData(ByVal selectRuleCode As String) As DataSet Implements IPubServiceManager.querySelectedRuleData
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.querySelectedRuleData(selectRuleCode)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

#End Region


#Region "2015/10/26 檢核規則維護 成醫舊程式搬移 by HE,Alien"


    Public Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer Implements IPubServiceManager.confirmTreeRuleData
        Dim client As PubServiceLClient = Nothing
        Dim integerTemp As Integer = -1
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                integerTemp = client.confirmTreeRuleData(confirmType, RuleDS)
            End Using ' before close
            client.Close()
            Return integerTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function getRuleMaintainSerialNo() As Integer Implements IPubServiceManager.getRuleMaintainSerialNo
        Dim client As PubServiceLClient = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return client.getRuleMaintainSerialNo()
            End Using ' before close
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function


    Public Function initPUBRuleTreeQueryInfo() As DataSet Implements IPubServiceManager.initPUBRuleTreeQueryInfo
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.initPUBRuleTreeQueryInfo()
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

    Public Function querySelectedTreeRuleData(ByVal selectRuleCode As String) As DataSet Implements IPubServiceManager.querySelectedTreeRuleData
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.querySelectedTreeRuleData(selectRuleCode)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function



    Public Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet Implements IPubServiceManager.queryTreeRuleByCondition
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.queryTreeRuleByCondition(itemParam, detailParam)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function


#End Region

#Region "2015/12/16 所屬單位查詢醫師信息   by Add Charles"

    Function queryPUBDoctorByDoctorCode(ByVal DoctorCode As String) As DataSet Implements IPubServiceManager.queryPUBDoctorByDoctorCode
        Dim client As PubServiceLClient = Nothing
        Dim dsTemp As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsTemp = client.queryPUBDoctorByDoctorCode(DoctorCode)
            End Using ' before close
            client.Close()
            Return dsTemp
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Function

#End Region

#Region "20090703 PUBSheetBO 共用代碼檔維護 by Add jianhui"
    Function queryPUBSheetByCV(ByVal strLoginID As String) As DataSet Implements IPubServiceManager.queryPUBSheetByCV
        Dim client As New PubServiceLClient
        Dim dsReturn As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsReturn = client.queryPUBSheetByCV(strLoginID)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return dsReturn
    End Function

    Function queryPUBSheetByCode_L(ByVal strDeptCode As String) As DataSet Implements IPubServiceManager.queryPUBSheetByCode_L
        Dim client As New PubServiceLClient
        Dim dsReturn As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsReturn = client.queryPUBSheetByCode_L(strDeptCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return dsReturn
    End Function
#End Region
#Region "20090923 疾病分類住院資料申請--初始化科別 by Add ChenYang"
    Function queryPUBDeptCodeNameCA3() As DataSet Implements IPubServiceManager.queryPUBDeptCodeNameCA3
        Dim client As New PubServiceLClient
        Dim dsReturn As DataSet

        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsReturn = client.queryPUBDeptCodeNameCA3()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return dsReturn
    End Function
#End Region

#Region "20100112 排成醫令維護   by Add coco"
    Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String) As DataSet Implements IPubServiceManager_L.queryPUBSheetDetailByCond1
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBSheetDetailByCond1(strSheetCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20090923 PUBSysCodeBO 共用代碼檔維護 by Add Yunfei"
    ''' <summary>
    ''' 獲取Department資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBSysCodeNot0(ByRef strColumnName As String(), ByRef strColumnValue As Object()) As DataSet Implements IPubServiceManager.queryPUBSysCodeNot0
        Dim client As New PubServiceLClient
        Dim dsReturn As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsReturn = client.queryPUBSysCodeNot0(strColumnName, strColumnValue)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return dsReturn
    End Function
#End Region
#Region "20100809 PUBSheetBO 查詢表單資料for 排程清單--表單類別 by Add tor"
    Public Function querySheetCode_L(ByVal strPubSheetCode As String) As DataSet Implements IPubServiceManager.querySheetCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.querySheetCode_L(strPubSheetCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function
#End Region

#Region "20100809 病歷量審查作業 add by Johsn"

    Function queryPUBDoctorByDoctorCode2_L(ByVal DoctorCode As String) As DataSet Implements IPubServiceManager_L.queryPUBDoctorByDoctorCode2_L

        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPUBDoctorByDoctorCode2_L(DoctorCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try

    End Function

#End Region
#Region "20090724 員工編號查詢醫師信息   by Add Ming"
    Function queryPUBDoctorByEmployeeCode(ByVal EmployeeCode As String) As DataSet Implements IPubServiceManager.queryPUBDoctorByEmployeeCode
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBDoctorByEmployeeCode(EmployeeCode)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region
#Region "20120326 取得病患資料及戶籍地 , Add by Runxia"
    ''' <summary>
    ''' 取得病患資料及戶籍地
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>by Runxia on 2012-3-26</remarks>
    Public Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet Implements IPubServiceManager.queryPUBPatientAndArea

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPatientAndArea(strChartNo)
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
#Region "2012/04/02 科室/團隊查詢(PUBDepartmentBO_E2) by liuye"

#Region "     科室/團隊查詢 "
    ''' <summary>
    ''' 科室/團隊查詢
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by liuye on 2012-4-2</remarks>
    Public Function queryPUBDepartmentCodeIsIpdDeptY_L() As DataSet Implements IPubServiceManager_L.queryPUBDepartmentCodeIsIpdDeptY_L

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBDepartmentCodeIsIpdDeptY_L()
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

#Region "2016/04/22 add by Kaiwen 醫令項目代碼對應健保碼  "
    Function queryPubOrderByOrderCode2_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceManager.queryPubOrderByOrderCode2_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubOrderByOrderCode2_L(strOrderCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function queryPubNhiCode_L(ByVal strInsuCode As String) As DataSet Implements IPubServiceManager.queryPubNhiCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubNhiCode_L(strInsuCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function queryPubInsuCode_L(ByVal strEffectDate As String, ByVal strOrderCode As String) As DataSet Implements IPubServiceManager_L.queryPubInsuCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubInsuCode_L(strEffectDate, strOrderCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function deletePubInsuCode_L(ByVal ds As DataSet) As Integer Implements IPubServiceManager_L.deletePubInsuCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As Integer = 0
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.deletePubInsuCode_L(ds)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function queryPubInsuCodeBySeqNo_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceManager_L.queryPubInsuCodeBySeqNo_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubInsuCodeBySeqNo_L(strOrderCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    '取得OrderCode對應的健保碼
    Function queryPubInsuCodeByOrderCode_L(ByVal strOrderCode As String) As DataSet Implements IPubServiceManager_L.queryPubInsuCodeByOrderCode_L
        Dim client As New PubServiceLClient
        Dim returnValue As DataSet = Nothing
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                returnValue = client.queryPubInsuCodeByOrderCode_L(strOrderCode)
            End Using ' before close
            client.Close()
            Return returnValue
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function

    Function confirmPUBInsuCode_L(ByVal saveData As DataSet) As DataSet Implements IPubServiceManager_L.confirmPUBInsuCode_L
        Dim client As New PubServiceLClient
        Dim dsResult As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                dsResult = client.confirmPUBInsuCode_L(saveData)
            End Using ' before close
            client.Close()
            Return dsResult
        Catch ex As Exception
            client.Abort()
            Throw ex
        Finally
            If client IsNot Nothing AndAlso client.State <> ServiceModel.CommunicationState.Closed Then client.Close()
        End Try
    End Function


#End Region

#Region "2016/04/22 醫令項目代碼對應健保碼修改(PUBInsuCodeBO_E2) by Kaiwen"

#Region "     醫令項目代碼對應健保碼修改 "

    ''' <summary>
    ''' 醫令項目代碼對應健保碼修改
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chen Yang on 2012-5-14</remarks>
    Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.updatePUBInsuCodeByPK_L

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updatePUBInsuCodeByPK_L(ds)

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

#Region "2016/05/07 檢驗組別,IO類別(PUBSysCodeBO_E2) by Remote"
    Public Function querySpicemenType() As DataSet Implements IPubServiceManager_L.querySpicemenType
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.querySpicemenType()
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

#Region " 20160517 PUBPreventiveCare 預防保健基本檔設定維護 ,add by Remote"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PUBPreventiveCareInsert(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPreventiveCareInsert

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPreventiveCareInsert(ds)
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
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PUBPreventiveCareUpdate(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPreventiveCareUpdate

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPreventiveCareUpdate(ds)
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
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PubPreventiveCareDeleteByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As Integer Implements IPubServiceManager_L.PubPreventiveCareDeleteByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PubPreventiveCareDeleteByPK(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)
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

#Region "     以PK查詢資料 "
    ''' <summary>
    ''' 以PK查詢資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PUBPreventiveCareQueryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBPreventiveCareQueryByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPreventiveCareQueryByPK(pk_Care_Item_Code, pk_Care_Order_Code, pk_Care_Cardseq)
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
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PUBPreventiveCareQueryAll() As System.Data.DataSet Implements IPubServiceManager_L.PUBPreventiveCareQueryAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPreventiveCareQueryAll()
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
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function PUBPreventiveCareQueryByLikePK(ByRef pk_Care_Item_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBPreventiveCareQueryByLikePK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPreventiveCareQueryByLikePK(pk_Care_Item_Code)
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

#Region "     取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-17</remarks>
    Public Function queryPUBCareItemAgeSex() As System.Data.DataSet Implements IPubServiceManager_L.queryPUBCareItemAgeSex

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBCareItemAgeSex()
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

#Region "2016/05/16 健保科別設定維護(PUBInsuDeptSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBInsuDeptdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBInsuDeptdeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBInsuDeptdeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(健保科別代碼) "
    ''' <summary>
    ''' 以PK查詢資料(健保科別代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBInsuDeptQueryByPKROC(ByRef Insu_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBInsuDeptQueryByPKROC

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBInsuDeptQueryByPKROC(Insu_Dept_Code)
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
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function queryAllROC() As System.Data.DataSet Implements IPubServiceManager_L.queryAllROC

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAllROC()
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

#Region "     確認診斷碼是否存在 "
    '    ''' <summary>
    '    ''' 確認診斷碼是否存在
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    '    Public Function DRGMDC15MaintainCheckIcdCode(ByVal strIcdCode As String) As DataSet Implements IPubServiceManager_L.DRGMDC15MaintainCheckIcdCode

    '        Dim tempclient As DRGServiceLClient = Nothing

    '        Try
    '            tempclient = getDrgServiceL()

    '            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

    '                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

    '                Return tempclient.DRGMDC15MaintainCheckIcdCode(strIcdCode)
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

#End Region

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBInsuDeptInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBInsuDeptInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBInsuDeptInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-06</remarks>
    Public Function PUBInsuDeptUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBInsuDeptUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBInsuDeptUpdateByPK(ds)
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

#Region "2016/05/19 看診目的(PUBSysCodeBO_E2) by Xiaozhi"
    Public Function queryPUBSubMedicalType() As DataSet Implements IPubServiceManager_L.queryPUBSubMedicalType
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSubMedicalType()
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

#Region "2016/05/24 五都戶籍地設定維護(PUBAreaCodeNSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeNdeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeNdeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(戶籍地代碼) "
    ''' <summary>
    ''' 以PK查詢資料(戶籍地代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNQueryByPKROC(ByRef Area_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBAreaCodeNQueryByPKROC

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeNQueryByPKROC(Area_Code)
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function queryAreaCodeAll() As System.Data.DataSet Implements IPubServiceManager_L.queryAreaCodeAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAreaCodeAll()
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-24</remarks>
    Public Function PUBAreaCodeNInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeNInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeNInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-24</remarks>
    Public Function PUBAreaCodeNUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeNUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeNUpdateByPK(ds)
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

#Region "2016/05/25 行政區設定維護(PubAreaCodeGovSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovdeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeGovdeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeGovdeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(縣市代碼) "
    ''' <summary>
    ''' 以PK查詢資料(縣市代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovQueryByPKROC(ByRef Gov_County_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBAreaCodeGovQueryByPKROC

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeGovQueryByPKROC(Gov_County_Code)
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function queryAreaCodeGovAll() As System.Data.DataSet Implements IPubServiceManager_L.queryAreaCodeGovAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryAreaCodeGovAll()
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeGovInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeGovInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-25</remarks>
    Public Function PUBAreaCodeGovUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBAreaCodeGovUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBAreaCodeGovUpdateByPK(ds)
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

#Region "2016/05/26 郵遞區號對應戶籍地設定維護(PUBPostalAreaSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalAreadeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBPostalAreadeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalAreadeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(縣市代碼) "
    ''' <summary>
    ''' 以PK查詢資料(縣市代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBPostalAreaQueryByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalAreaQueryByPK(Postal_Code)
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

#Region "     以所有pk查詢"
    ''' <summary>
    ''' 以PK查詢資料(縣市代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalAreaQueryByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBPostalAreaQueryByPKAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalAreaQueryByPKAll(Postal_Code, Area_Code)
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function queryPostalAreaAll() As System.Data.DataSet Implements IPubServiceManager_L.queryPostalAreaAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPostalAreaAll()
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPostalAreaInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalAreaInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Public Function PUBPostalAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPostalAreaUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalAreaUpdateByPK(ds)
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

#Region "2016/05/27 郵遞區號對應行政區設定維護(PUBPostalGovAreaSetupUI) by Xiaozhi"

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalGovAreadeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBPostalGovAreadeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalGovAreadeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(縣市代碼) "
    ''' <summary>
    ''' 以PK查詢資料(縣市代碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalGovAreaQueryByPK(ByRef Postal_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBPostalGovAreaQueryByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalGovAreaQueryByPK(Postal_Code)
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function queryPostalGovAreaAll() As System.Data.DataSet Implements IPubServiceManager_L.queryPostalGovAreaAll

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPostalGovAreaAll()
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
    ''' <remarks>by Xiaozhi,Yu on 2016-05-26</remarks>
    Public Function PUBPostalGovAreaInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPostalGovAreaInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalGovAreaInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-26</remarks>
    Public Function PUBPostalGovAreaUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBPostalGovAreaUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBPostalGovAreaUpdateByPK(ds)
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

#Region "2016/06/01 資料來源type_id = '128'(PUBSysCodeBO_E2) by Remote"
    Public Function queryPUBSysCodeSourceId() As DataSet Implements IPubServiceManager_L.queryPUBSysCodeSourceId
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSysCodeSourceId()
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

#Region "20160606 查詢病歷關系"

    Public Function queryPUBPatientContactByCond_L(ByVal strChartNo As String) As System.Data.DataSet Implements IPubServiceManager_L.queryPUBPatientContactByCond_L
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBPatientContactByCond_L(strChartNo)
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

    Public Function queryPUBSysCodeByIcdCodingQuery_L() As System.Data.DataSet Implements IPubServiceManager_L.queryPUBSysCodeByIcdCodingQuery_L
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSysCodeByIcdCodingQuery_L()
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

#Region "2016/06/20 護理站(PUBSysCodeBO_E2) by Remote"
    Public Function queryStationNo() As DataSet Implements IPubServiceManager_L.queryStationNo
        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryStationNo()
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

#Region "   2016/06/20 取得就醫序號 by Remote   "
    ''' <summary>
    ''' 取得就醫序號
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-20</remarks>
    Public Function queryMedicalSn(ByVal inParam() As String) As System.Data.DataSet Implements IPubServiceManager_L.queryMedicalSn

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryMedicalSn(inParam)
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

#Region "  2016/06/20 取得媽媽姓名 by Remote    "
    ''' <summary>
    ''' 取得媽媽姓名
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-20</remarks>
    Public Function queryMotherName(ByVal inParam() As String) As System.Data.DataSet Implements IPubServiceManager_L.queryMotherName

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryMotherName(inParam)
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

#Region "2016/06/28 ICD9_ICD10對照檔(PUB_Disease_ICD10_Mapping) by Li,Han"

#Region "     新增 Method "
    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappinginsertData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBDiseaseICD10MappinginsertData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappinginsertData(ds)
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


#Region "     修改 Method "
    ''' <summary>
    ''' 修改 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingupdateData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBDiseaseICD10MappingupdateData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingupdateData(ds)
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


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingdeleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As Integer Implements IPubServiceManager_L.PUBDiseaseICD10MappingdeleteData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingdeleteData(pk_Disease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
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


#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBDiseaseICD10MappingqueryGridData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingqueryGridData(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
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

#Region "     取得Gird資料ByPk "
    ''' <summary>
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBDiseaseICD10MappingqueryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBDiseaseICD10MappingqueryGridDataByPk

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingqueryGridDataByPk(pkDisease_Type_Id, pk_ICD_Code, pk_ICD10_Code)
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

#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingquertCmbData() As DataSet Implements IPubServiceManager_L.PUBDiseaseICD10MappingquertCmbData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingquertCmbData()
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


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-28</remarks>
    Public Function PUBDiseaseICD10MappingfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer Implements IPubServiceManager_L.PUBDiseaseICD10MappingfCheckIcdCode

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBDiseaseICD10MappingfCheckIcdCode(strICD, strTBName)
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

#Region "2016/06/29 ICD10科別對照檔(PUB_ICD10_Dept) by Li,Han"

#Region "     新增 Method "
    ''' <summary>
    ''' 新增 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptinsertData(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager.PUBICD10DeptinsertData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptinsertData(ds)
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


#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除 Method
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptdeleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String) As Integer Implements IPubServiceManager.PUBICD10DeptdeleteData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptdeleteData(pk_Kind_Code, pk_Disease_Type_Id, pk_ICD10_Code, pk_Insu_Dept_Code, pk_Insu_Sub_Dept_Code)
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




#Region "     取得Gird資料 "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBICD10DeptqueryGridData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptqueryGridData(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)
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


#Region "     取得Gird資料ByPK "
    ''' <summary>
    ''' 取得Gird資料ByPK
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String) As System.Data.DataSet Implements IPubServiceManager.PUBICD10DeptqueryGridDataByPk

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptqueryGridDataByPk(Kind_Code, Disease_Type_Id, Icd10_Code, Insu_Dept_Code, Insu_Sub_Dept_Code)
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


#Region "     取得Combox資料 "
    ''' <summary>
    ''' 取得Combox資料
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptqueryCmbData(ByRef strTBName As String, ByRef strWhere As String) As DataSet Implements IPubServiceManager.PUBICD10DeptqueryCmbData

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptqueryCmbData(strTBName, strWhere)
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


#Region "     檢查該診斷是否存在 "
    ''' <summary>
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Li,Han on 2016-06-29</remarks>
    Public Function PUBICD10DeptfCheckIcdCode(ByVal strICD As String, ByVal strTBName As String) As Integer Implements IPubServiceManager.PUBICD10DeptfCheckIcdCode

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBICD10DeptfCheckIcdCode(strICD, strTBName)
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

#Region "  2016/06/28 取得手術法(PUBOrderBO_E2) by Remote    "
    ''' <summary>
    ''' 取得手術法
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBOrderOrderName(ByVal inParam() As String) As System.Data.DataSet Implements IPubServiceManager_L.PUBOrderOrderName

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderOrderName(inParam)
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

#Region "  2016/06/28 取得費用(PUBOrderPriceBO_E2) by Remote    "
    ''' <summary>
    ''' 取得費用
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBOrderPrice(ByVal inParam() As String) As System.Data.DataSet Implements IPubServiceManager_L.PUBOrderPrice

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderPrice(inParam)
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

#Region "     2016/06/28 傷口分類(PUBSysCodeBO_E2) by Remote "
    ''' <summary>
    ''' 傷口分類
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBSyscodeWoundType() As System.Data.DataSet Implements IPubServiceManager_L.PUBSyscodeWoundType

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBSyscodeWoundType()
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

#Region "     2016/06/28 部位(PUBBodySiteBO_E2) by Remote  "
    ''' <summary>
    ''' 部位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBBodySiteBodyparts() As System.Data.DataSet Implements IPubServiceManager_L.PUBBodySiteBodyparts

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBBodySiteBodyparts()
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

#Region "    2016/06/28 側位 by Remote(PUBSysCodeBO_E2)  "
    ''' <summary>
    ''' 側位
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-06-28</remarks>
    Public Function PUBSyscodeBodySide() As System.Data.DataSet Implements IPubServiceManager_L.PUBSyscodeBodySide

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBSyscodeBodySide()
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

#Region "    2016/07/04 急作手術分級 by Remote(PUBSysCodeBO_E2)  "
    ''' <summary>
    ''' 急作手術分級
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-07-04</remarks>
    Public Function PUBSyscodeUrgentClass() As System.Data.DataSet Implements IPubServiceManager_L.PUBSyscodeUrgentClass

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBSyscodeUrgentClass()
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

#Region "    2016/08/13 檢驗單 by Remote(PUBsheetCodeBO_E2)  "
    ''' <summary>
    ''' 檢驗單
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-08-13</remarks>
    Public Function queryPUBSheetCode() As System.Data.DataSet Implements IPubServiceManager_L.queryPUBSheetCode

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryPUBSheetCode()
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
#Region "2016/09/12 add by qun 依據健保碼內容查詢主手術碼設定下拉選單"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryICD10PCS_Code(ByVal strInsuCode As System.String) As DataSet Implements IPubServiceManager_L.queryICD10PCS_Code

        Dim tempclient As PubServiceLClient = Nothing
        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.queryICD10PCS_Code(strInsuCode)
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

#Region "2016/09/23 新增非藥品替代醫令檔(PUBOrderAlternativeUI) by Xiaozhi"

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBOrderAlternativeInsertByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBOrderAlternativeInsertByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderAlternativeInsertByPK(ds)
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
    ''' <remarks>by Xiaozhi on 2016-05-06</remarks>
    Public Function PUBOrderAlternativeUpdateByPK(ByVal ds As System.Data.DataSet) As Integer Implements IPubServiceManager_L.PUBOrderAlternativeUpdateByPK

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderAlternativeUpdateByPK(ds)
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

#Region "     刪除多筆資料 "
    ''' <summary>
    ''' 
    ''' 刪除多筆資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBOrderAlternativedeleteChoose(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.PUBOrderAlternativedeleteChoose

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderAlternativedeleteChoose(dsDelete)
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

#Region "     以PK查詢資料(醫令碼) "
    ''' <summary>
    ''' 以PK查詢資料(醫令碼)
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Xiaozhi,Yu on 2016-05-12</remarks>
    Public Function PUBOrderAlternativequeryByPKOrderCode(ByRef Order_Code As System.String) As System.Data.DataSet Implements IPubServiceManager_L.PUBOrderAlternativequeryByPKOrderCode

        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.PUBOrderAlternativequeryByPKOrderCode(Order_Code)
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

#Region "20090820 PUBOrderStandingBO 常備醫令檔 Add by william"
    '查詢
    Function queryPUBOrderStandingByCond(ByVal strDept_Code As String, ByVal strOrder_Code As String) As DataSet Implements IPubServiceManager.queryPUBOrderStandingByCond
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBOrderStandingByCond(strDept_Code, strOrder_Code)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    '新增
    Function insertPUBOrderStanding(ByVal saveData As DataSet) As Integer Implements IPubServiceManager.insertPUBOrderStanding
        Dim client As New PubServiceLClient
        Dim iCount As Integer
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCount = client.insertPUBOrderStanding(saveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCount
    End Function

    '刪除
    Function deletePUBOrderStandingByPK(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As System.String, ByVal iWeek As System.Int32, ByVal strConsumption_Dept As System.String) As Integer Implements IPubServiceManager.deletePUBOrderStandingByPK
        Dim client As New PubServiceLClient
        Dim iCount As Integer
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCount = client.deletePUBOrderStandingByPK(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek, strConsumption_Dept)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCount
    End Function

    '更新
    Function updatePUBOrderStanding(ByVal saveData As DataSet) As Integer Implements IPubServiceManager.updatePUBOrderStanding
        Dim client As New PubServiceLClient
        Dim iCount As Integer
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCount = client.updatePUBOrderStanding(saveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCount
    End Function

    Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean Implements IPubServiceManager.queryPUBOrderStandingTimeIsExist
        Dim client As New PubServiceLClient
        Dim iCount As Boolean
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCount = client.queryPUBOrderStandingTimeIsExist(strDept_Code, strOrder_Code, strStart_Time, strEnd_Time, iWeek)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCount
    End Function

    '查詢科別/護理站
    Function queryPUBOrderStandingByDept() As DataSet Implements IPubServiceManager.queryPUBOrderStandingByDept
        Dim client As New PubServiceLClient
        Dim ds_return As DataSet
        Try
            client = getPubServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryPUBOrderStandingByDept()
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

#End Region

#Region "          2017/1/16 非藥品替代醫令檔維護 add by Michelle"

    '新增
    Public Function insertPUBOrder(ByVal dsData As DataSet) As Integer Implements IPubServiceManager_L.insertPUBOrder
        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.insertPUBOrder(dsData)
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

    '修改
    Public Function updatePUBOrder(ByVal dsData As DataSet) As Integer Implements IPubServiceManager_L.updatePUBOrder
        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.updatePUBOrder(dsData)
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

    '刪除
    Public Function DeletePUBOrder(ByVal dsDelete As DataSet) As Integer Implements IPubServiceManager_L.DeletePUBOrder
        Dim tempclient As PubServiceLClient = Nothing

        Try
            tempclient = getPubServiceL()

            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)

                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做

                Return tempclient.DeletePUBOrder(dsDelete)
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
End Class
