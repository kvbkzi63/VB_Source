Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory.FtmServiceReference

Partial Public Class FtmServiceManager

    ''' <summary>
    ''' 上傳檔案
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Function uploadNewFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String() Implements IFtmServiceManager.uploadNewFile
        Dim instance As FtmServiceClient = Nothing
        Try
            instance = getFtmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.uploadNewFile(data, fileVersionData)
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
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>縮圖的byte array</returns>
    ''' <remarks></remarks>
    Function getImageThumb(ByRef FID As String) As Byte() Implements IFtmServiceManager.getImageThumb
        Dim instance As FtmServiceClient = Nothing
        Try
            instance = getFtmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.getImageThumb(FID)
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
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Public Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False) As Object() Implements IFtmServiceManager.downloadFile
        Dim instance As FtmServiceClient = Nothing
        Try
            instance = getFtmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.downloadFile(FID, old_file_name)
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
    ''' 上傳檔案BY PATH
    ''' </summary>
    ''' <param name="inUNCPathTag"></param>
    ''' <param name="inAccessIDTag"></param>
    ''' <param name="inAccessPWTag"></param>
    ''' <param name="data"></param>
    ''' <param name="fileVersionData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function uploadNewFilePath(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                  ByRef data As System.Data.DataSet, Optional ByRef fileVersionData As System.Data.DataSet = Nothing) As String() Implements IFtmServiceManager.uploadNewFilePath
        Dim instance As FtmServiceClient = Nothing
        Try
            instance = getFtmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.uploadNewFilePath(inUNCPathTag, inAccessIDTag, inAccessPWTag, data, fileVersionData)
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
    ''' 下載檔案 By PATH
    ''' </summary>
    ''' <param name="FID"></param>
    ''' <param name="inUNCPathTag"></param>
    ''' <param name="inAccessIDTag"></param>
    ''' <param name="inAccessPWTag"></param>
    ''' <param name="inExtensionName"></param>
    ''' <param name="old_file_name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function downloadFilePath(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, _
                                 ByVal inAccessPWTag As String, ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object() Implements IFtmServiceManager.downloadFilePath
        Dim instance As FtmServiceClient = Nothing
        Try
            instance = getFtmService()
            Using scope As New OperationContextScope(instance.InnerChannel)
                AppContext.setUserProfiletoServer() ' 在呼叫任何 wcf client 方法之前做
                Return instance.downloadFilePath(FID, inUNCPathTag, inAccessIDTag, inAccessPWTag, inExtensionName, old_file_name)
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

End Class
