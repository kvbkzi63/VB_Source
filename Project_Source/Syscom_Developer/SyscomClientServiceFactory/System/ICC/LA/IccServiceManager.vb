Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.IccServiceLReference

Partial Class IccServiceManager

#Region "20090909 已上傳歷史資料維護  ICC_Health_Upload & ICC_Inoculation_Upload, add by  Jianhui"
    Function queryICCHealthUploadandICCInoculationUploadByCond(ByVal strUploadTypeId As String _
                                                 , ByVal strChartNo As String _
                                                 , ByVal strSourceSn As String _
                                                 , ByVal strCreateSearchTime As String _
                                                 , ByVal strA00 As String _
                                                 , ByVal strA01 As String _
                                                 , ByVal strA17 As String _
                                                 , ByVal strIsBabyStool As String _
                                                 , ByVal strA12 As String) As System.Data.DataSet Implements IIccServiceManager.queryICCHealthUploadandICCInoculationUploadByCond
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryICCHealthUploadandICCInoculationUploadByCond(strUploadTypeId _
                                                                                                  , strChartNo _
                                                                                                   , strSourceSn _
                                                                                                  , strCreateSearchTime _
                                                                                                  , strA00 _
                                                                                                  , strA01 _
                                                                                                  , strA17, strIsBabyStool, strA12)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function


    Function queryICCHealthUploadandICCInoculationUploadByCond2(ByVal strUploadTypeId As String _
                                                , ByVal strChartNo As String _
                                                , ByVal strSourceSn As String _
                                                , ByVal strCreateSearchTime As String _
                                                , ByVal strA00 As String _
                                                , ByVal strA01 As String _
                                                , ByVal strA17 As String _
                                                , ByVal strIsBabyStool As String _
                                                , ByVal strA12 As String) As System.Data.DataSet Implements IIccServiceManager.queryICCHealthUploadandICCInoculationUploadByCond2
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryICCHealthUploadandICCInoculationUploadByCond2(strUploadTypeId _
                                                                                                  , strChartNo _
                                                                                                   , strSourceSn _
                                                                                                  , strCreateSearchTime _
                                                                                                  , strA00 _
                                                                                                  , strA01 _
                                                                                                  , strA17, strIsBabyStool, strA12)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function


    Function queryICCHealthUploadandICCInoculationUploadByPage1Cond(ByVal strUploadTypeId As String _
                                                , ByVal strChartNo As String _
                                                , ByVal strSourceSn As String _
                                                , ByVal strCreateSearchTime As String _
                                                , ByVal strA00 As String _
                                                , ByVal strA01 As String _
                                                , ByVal strA17 As String _
                                                , ByVal strIsBabyStool As String _
                                                , ByVal strA12 As String) As System.Data.DataSet Implements IIccServiceManager.queryICCHealthUploadandICCInoculationUploadByPage1Cond
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryICCHealthUploadandICCInoculationUploadByPage1Cond(strUploadTypeId _
                                                                                                  , strChartNo _
                                                                                                   , strSourceSn _
                                                                                                  , strCreateSearchTime _
                                                                                                  , strA00 _
                                                                                                  , strA01 _
                                                                                                  , strA17, strIsBabyStool, strA12)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    Function updateICCHealthUpload(ByVal strCancelUser As String _
                                         , ByVal strChartNo As String _
                                         , ByVal strSourceSn As String) As Integer Implements IIccServiceManager.updateICCHealthUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCHealthUpload(strCancelUser, strChartNo, strSourceSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return flag
    End Function

    Function updateICCInoculationUpload(ByVal strCancelUser As String _
                                       , ByVal strChartNo As String _
                                       , ByVal strSourceSn As String) As Integer Implements IIccServiceManager.updateICCInoculationUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCInoculationUpload(strCancelUser, strChartNo, strSourceSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Sub deleteICCInoculationUploadBS(ByVal dsSaveData As DataSet) Implements IIccServiceManager.deleteICCInoculationUploadBS
        Dim client As New IccServiceLClient

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                client.deleteICCInoculationUploadBS(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
    End Sub
#End Region

#Region "20090911 新增預防接種資料 add by Johsn "
    Function insertICCInoculationUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.insertICCInoculationUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCInoculationUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
#End Region

#Region "20090911 新增健保就醫資料 ICCCreateHealthUploadBS   Add by Yunfei"
    Function insertICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.insertICCHealthOrderUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCHealthOrderUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
#End Region

#Region "20090914 自行檢核錯資料_檢核條件 add by  Jianhui"
    Function queryICCMustFieldVerify(ByVal strTreatmentCategoryId As String) As DataSet Implements IIccServiceManager.queryICCMustFieldVerify
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryICCMustFieldVerify(strTreatmentCategoryId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    Function queryIccFieldLengthVerify(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccFieldLengthVerify
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccFieldLengthVerify(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try

        Return ds_return
    End Function

    Function queryIccSelfVerify(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccSelfVerify
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccSelfVerify(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryIccInteractVerify1ById(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccInteractVerify1ById
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccInteractVerify1ById(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryIccInteractVerify2ById(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccInteractVerify2ById
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccInteractVerify2ById(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryIccInteractVerify3ById(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccInteractVerify3ById
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccInteractVerify3ById(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryIccInteractVerify4ById(ByVal strId As String) As DataSet Implements IIccServiceManager.queryIccInteractVerify4ById
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryIccInteractVerify4ById(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function

    Function queryICCOnlineCheckById(ByVal strId As String) As DataSet Implements IIccServiceManager.queryICCOnlineCheckById
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryICCOnlineCheckById(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
    Function insertICCMustFieldVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertICCMustFieldVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCMustFieldVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function insertICCOnlineCheckById(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertICCOnlineCheckById
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCOnlineCheckById(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateICCMustFieldVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateICCMustFieldVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCMustFieldVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateICCOnlineCheckById(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateICCOnlineCheckById
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCOnlineCheckById(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteCCMustFieldVerify(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteCCMustFieldVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteCCMustFieldVerify(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function


    Function deleteICCOnlineCheckById(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteICCOnlineCheckById
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteICCOnlineCheckById(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    Function insertIccFieldLengthVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccFieldLengthVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccFieldLengthVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccFieldLengthVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccFieldLengthVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccFieldLengthVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccFieldLengthVerify(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccFieldLengthVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccFieldLengthVerify(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function


    Function insertIccSelfVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccSelfVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccSelfVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccSelfVerify(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccSelfVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccSelfVerify(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccSelfVerify(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccSelfVerify
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccSelfVerify(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function insertIccInteractVerify1(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccInteractVerify1
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccInteractVerify1(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccInteractVerify1(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccInteractVerify1
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccInteractVerify1(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccInteractVerify1(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccInteractVerify1
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccInteractVerify1(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function


    Function insertIccInteractVerify2(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccInteractVerify2
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccInteractVerify2(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccInteractVerify2(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccInteractVerify2
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccInteractVerify2(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccInteractVerify2(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccInteractVerify2
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccInteractVerify2(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function insertIccInteractVerify3(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccInteractVerify3
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccInteractVerify3(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccInteractVerify3(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccInteractVerify3
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccInteractVerify3(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccInteractVerify3(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccInteractVerify3
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccInteractVerify3(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function insertIccInteractVerify4(ByVal ds As DataSet) As Integer Implements IIccServiceManager.insertIccInteractVerify4
        Dim client As New IccServiceLClient
        Dim flag As Integer

        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertIccInteractVerify4(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function updateIccInteractVerify4(ByVal ds As DataSet) As Integer Implements IIccServiceManager.updateIccInteractVerify4
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateIccInteractVerify4(ds)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function deleteIccInteractVerify4(ByVal pkid As String) As Integer Implements IIccServiceManager.deleteIccInteractVerify4
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteIccInteractVerify4(pkid)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function queryDeletekeystateByInoculationSn(ByVal strId As String) As DataSet Implements IIccServiceManager.queryDeletekeystateByInoculationSn
        Dim client As New IccServiceLClient
        Dim ds_return As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds_return = client.queryDeletekeystateByInoculationSn(strId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds_return
    End Function
#End Region

#Region "20090914 檢視預防接種資料 add by Johsn"
    '新增資料
    Function insertICCBacterinUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.insertICCBacterinUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCBacterinUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    '修改資料
    Function updateICCInoculationUploadBS(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.updateICCInoculationUploadBS
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCInoculationUploadBS(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    '查詢資料
    Function queryICCInoculationUploadByPK(ByVal strInoculationSn As String) As DataSet Implements IIccServiceManager.queryICCInoculationUploadByPK
        Dim client As New IccServiceLClient
        Dim ds As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryICCInoculationUploadByPK(strInoculationSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function
    '儲存資料
    Function confirmICCInoculationUploadBS(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.confirmICCInoculationUploadBS
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.confirmICCInoculationUploadBS(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
#End Region

#Region "20090916 檢視健保就醫資料 add by Yunfei"
    '新增資料
    Function insertICCOrderUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.insertICCOrderUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.insertICCOrderUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    '修改資料
    Function updateICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.updateICCHealthOrderUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCHealthOrderUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
    '查詢資料
    Function queryICCHealthOrderUpload(ByVal strHealthSn As String) As DataSet Implements IIccServiceManager.queryICCHealthOrderUpload
        Dim client As New IccServiceLClient
        Dim ds As DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryICCHealthOrderUpload(strHealthSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function
    '儲存資料
    Function confirmICCHealthOrderUpload(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.confirmICCHealthOrderUpload
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.confirmICCHealthOrderUpload(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
#End Region

#Region "20100105 查詢已上傳資料 add by Yi "
    Function queryICCInoculationUpload(ByVal strInoculationSn As String) As System.Data.DataSet Implements IIccServiceManager.queryICCInoculationUpload
        Dim client As New IccServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryICCInoculationUpload(strInoculationSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function

    Function deleteICCInoculationUploadByPk(ByVal pkId As String) As Integer Implements IIccServiceManager.deleteICCInoculationUploadByPk
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.deleteICCInoculationUploadByPk(pkId)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function

    Function queryA24ByOutpatient_Sn_L(ByVal strInoculationSn As String) As System.Data.DataSet Implements IIccServiceManager.queryA24ByOutpatient_Sn_L
        Dim client As New IccServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryA24ByOutpatient_Sn_L(strInoculationSn)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function

    Function updateICCInoculationUploadByPk_L(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.updateICCInoculationUploadByPk_L
        Dim client As New IccServiceLClient
        Dim flag As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                flag = client.updateICCInoculationUploadByPk_L(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return flag
    End Function
#End Region

#Region "20110816 疫苗批號補正 Inoculation_Sn , add by Runxia"
   
    Function queryICCInoculationSn_L(ByVal strChartNo As String) As System.Data.DataSet Implements IIccServiceManager.queryICCInoculationSn_L
        Dim client As New IccServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.queryICCInoculationSn_L(strChartNo)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function
#End Region

#Region "20150805 IccCloudDrugPatientBO 雲端藥歷轉檔同意書名單登錄  , add by Runxia"

    ''' <summary>
    ''' 依條件查詢雲端藥歷轉檔同意書名單
    ''' </summary>
    ''' <param name="strIdno">身份證</param>
    ''' <param name="dMedicalDate">就醫日</param>
    ''' <returns>ds</returns>
    ''' <remarks></remarks>
    Function QueryIccCloudDrugPatientByCond(ByVal strIdno As String, ByVal dMedicalDate As String) As DataSet Implements IIccServiceManager.QueryIccCloudDrugPatientByCond
        Dim client As New IccServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.QueryIccCloudDrugPatientByCond(strIdno, dMedicalDate)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 新增雲端藥歷轉檔同意書名單
    ''' </summary>
    ''' <param name="dsSaveData">ds新增資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function InsertIccCloudDrugPatient(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.InsertIccCloudDrugPatient
        Dim client As New IccServiceLClient
        Dim iCnt As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCnt = client.InsertIccCloudDrugPatient(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCnt
    End Function

    ''' <summary>
    ''' 依據PK刪除雲端藥歷轉檔同意書名單
    ''' </summary>
    ''' <param name="strIdno">身份證</param>
    ''' <param name="dMedicalDate">就醫日</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DeleteIccCloudDrugPatientByPK(ByVal strIdno As String, ByVal dMedicalDate As DateTime) As Integer Implements IIccServiceManager.DeleteIccCloudDrugPatientByPK
        Dim client As New IccServiceLClient
        Dim iCnt As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCnt = client.DeleteIccCloudDrugPatientByPK(strIdno, dMedicalDate)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCnt
    End Function

    ''' <summary>
    ''' 更新雲端藥歷轉檔同意書名單
    ''' </summary>
    ''' <param name="dsSaveData">更新資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateIccCloudDrugPatient(ByVal dsSaveData As DataSet) As Integer Implements IIccServiceManager.UpdateIccCloudDrugPatient
        Dim client As New IccServiceLClient
        Dim iCnt As Integer
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                iCnt = client.UpdateIccCloudDrugPatient(dsSaveData)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return iCnt
    End Function
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
    Public Function QueryIccAlertRecByCond(ByRef Query_Type As String, ByVal ST_Visit_Date As String, ByVal ED_Visit_Date As String, ByVal Chart_No As String) As DataSet Implements IIccServiceManager_L.QueryIccAlertRecByCond
        Dim tempclient As IccServiceLClient = Nothing
        Try
            tempclient = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(tempclient.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return tempclient.QueryIccAlertRecByCond(Query_Type, ST_Visit_Date, ED_Visit_Date, Chart_No)
            End Using ' before close
        Catch ex As Exception
            Throw ex
        Finally
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

#Region "20160106  雲端藥歷同意書登錄查詢 add by Brian"
    ''' <summary>
    ''' 依條件查詢雲端藥歷同意書登錄
    ''' </summary>
    ''' <param name="dCreate_Time">The d create_ time.</param>
    ''' <param name="dModified_Time">The d modified_ time.</param>
    ''' <returns> ds </returns>
    Function QueryIccCloudPatientQryByCond(ByVal strQuery_Type As String, ByVal dCreate_Time As String, ByVal dModified_Time As String, ByVal IdNo As System.String) As DataSet Implements IIccServiceManager.QueryIccCloudPatientQryByCond
        Dim client As New IccServiceLClient
        Dim ds As System.Data.DataSet
        Try
            client = getIccServiceL()
            Using scope As OperationContextScope = New OperationContextScope(client.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                ds = client.QueryIccCloudPatientQryByCond(strQuery_Type, dCreate_Time, dModified_Time, IdNo)
            End Using ' before close
            client.Close()
        Catch ex As Exception
            client.Abort()
            Throw ex
        End Try
        Return ds
    End Function
#End Region



End Class
