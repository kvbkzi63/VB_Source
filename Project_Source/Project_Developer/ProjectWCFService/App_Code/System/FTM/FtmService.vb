' 注意: 若變更此處的類別名稱 "FtmService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "FtmService" 的參考。
Imports System.Data
Imports Syscom.Server.FTM
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class FtmService
    Implements IFtmService

    Private Shared ReadOnly rptUserID As String = ConfigurationManager.AppSettings.Item("rptUserID")
    Private Shared ReadOnly rptUserDomain As String = ConfigurationManager.AppSettings.Item("rptUserDomain")
    Private Shared ReadOnly rptUserPW As String = ConfigurationManager.AppSettings.Item("rptUserPW")

    ''' <summary>
    ''' 上傳檔案
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>   
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Function uploadNewFile(ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String() Implements IFtmService.uploadNewFile
        Try
            Return FTMDelegate.getInstance.uploadNewFile(data, fileVersionData)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 取得縮圖
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>縮圖的byte array</returns>
    ''' <remarks></remarks>
    Function getImageThumb(ByRef FID As String) As Byte() Implements IFtmService.getImageThumb
        Try
            Return FTMDelegate.getInstance.getImageThumb(FID)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 下載檔案
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Function downloadFile(ByRef FID As String, Optional ByRef old_file_name As Boolean = False) As Object() Implements IFtmService.downloadFile
        Try
            Return FTMDelegate.getInstance.downloadFile(FID, old_file_name)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 一次下載多個檔案
    ''' </summary>
    ''' <param name="FIDs">FIDs</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>Hashtable 以 FID 當 key </returns>
    ''' <remarks></remarks>
    Public Function downloadFiles(ByRef FIDs As String(), Optional ByRef old_file_name As Boolean = False) As Hashtable Implements IFtmService.downloadFiles
        Try
            Return FTMDelegate.getInstance.downloadFiles(FIDs, old_file_name)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function
    ''' <summary>
    ''' 無註解
    ''' </summary>
    ''' <param name="FID"></param>
    ''' <remarks></remarks>
    Sub doMyReport(ByRef FID As Integer) Implements IFtmService.doMyReport
        'Dim loger As log4net.ILog = Syscom.common.log.LOGDelegate.GetInstance.getFileLogger(Me)
        'Try
        '    If FID = 1 Then
        '        ImpersonateUtil.ImpersonateValidUser(rptUserID, rptUserDomain, rptUserPW)
        '        Dim s0 As TestExcelRPT = New TestExcelRPT()
        '        s0.print(New Object() {"1"})
        '        ImpersonateUtil.UndoImpersonation()
        '    ElseIf FID = 2 Then
        '        ImpersonateUtil.ImpersonateValidUser(rptUserID, rptUserDomain, rptUserPW)
        '        Dim s1 As TestWordRPT = New TestWordRPT()
        '        s1.print(New Object() {"1"})
        '        ImpersonateUtil.UndoImpersonation()
        '    ElseIf FID = 3 Then
        '        Dim s2 As TestTxtRPT = New TestTxtRPT()
        '        s2.print(New Object() {"1"})
        '    End If
        'Catch ex As Exception
        '    loger.Error(ex)
        '      Throw Syscom.Server.CMM.ServerExceptionHandler.ProccessException(ex)
        'End Try
    End Sub

    ''' <summary>
    ''' 上傳檔案(可透過AppSetting.config的Tag設定來指定下載路徑)
    ''' </summary>
    ''' <param name="data">上傳檔案資料</param>
    ''' <param name="fileVersionData">檔案版本資訊</param>
    ''' <returns>FID</returns>
    ''' <remarks></remarks>
    Public Function uploadNewFilePath(ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, ByVal inAccessPWTag As String, _
                                  ByRef data As DataSet, Optional ByRef fileVersionData As DataSet = Nothing) As String() Implements IFtmService.uploadNewFilePath
        Dim retString() As String = Nothing
        Try

            inUNCPathTag = IIf(inUNCPathTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsPath"), inUNCPathTag)
            inAccessIDTag = IIf(inAccessIDTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsUserID"), inAccessIDTag)
            inAccessPWTag = IIf(inAccessPWTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsUserPW"), inAccessPWTag)
            retString = FTMDelegate.getInstance.uploadNewFile(inUNCPathTag, inAccessIDTag, inAccessPWTag, data, fileVersionData)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
        End Try
        Return retString
    End Function

    ''' <summary>
    ''' 下載檔案(可透過AppSetting.config的Tag設定來指定下載路徑)
    ''' </summary>
    ''' <param name="FID">FID</param>
    ''' <param name="inUNCPathTag">UNCPath Tag</param>
    ''' <param name="inAccessIDTag">AccessID Tag</param>
    ''' <param name="inAccessPWTag">AccessPW Tag</param>
    ''' <param name="inExtensionName">副檔名，例:txt或xml</param>
    ''' <param name="old_file_name">是否使用上傳時的原擋名</param>
    ''' <returns>(0) 檔案資料byte() , (1) client端的預設檔名</returns>
    ''' <remarks></remarks>
    Public Function downloadFilePath(ByRef FID As String, ByVal inUNCPathTag As String, ByVal inAccessIDTag As String, _
                                 ByVal inAccessPWTag As String, ByVal inExtensionName As String, Optional ByRef old_file_name As Boolean = False) As Object() Implements IFtmService.downloadFilePath

        Dim retObj() As Object = Nothing
        Try

            inUNCPathTag = IIf(inUNCPathTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsPath"), inUNCPathTag)
            inAccessIDTag = IIf(inAccessIDTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsUserID"), inAccessIDTag)
            inAccessPWTag = IIf(inAccessPWTag.ToString.Trim.Length = 0, ConfigurationManager.AppSettings.Item("efsUserPW"), inAccessPWTag)

            retObj = FileTransfer.downloadFile(FID, inUNCPathTag, inAccessIDTag, inAccessPWTag, inExtensionName, old_file_name)
        Catch ex As Exception
            ServerExceptionHandler.ProccessException(ex)
        End Try
        Return retObj
    End Function


End Class
