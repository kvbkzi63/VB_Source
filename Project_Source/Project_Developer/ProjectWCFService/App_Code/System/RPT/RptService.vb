Imports Syscom.Comm.EXP
Imports Syscom.Server.SNC
Imports Syscom.Server.CMM
Imports Syscom.Server.RPT

' 注意: 若變更此處的類別名稱 "RptService"，也必須更新 Web.config 與關聯之 .svc 檔案中 "RptService" 的參考。
Public Class RptService
    Implements IRptService

    ''' <summary>
    ''' 取得印表機名稱
    ''' Add By Jen
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="type"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String Implements IRptService.getPrinterName
        Try
            Return RPTDelegate.getInstance.getPrinterName(id, type, con)
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

    ''' <summary>
    ''' 取得報表ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getReportID() As String Implements IRptService.getReportID
        Try
            Return SNCDelegate.getInstance.getReportSerialNo
        Catch cmex As CommonException
            Throw ServerExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            Throw ServerExceptionHandler.ProccessException(New CommonException("SYSWCFA001", ex))
        End Try
    End Function

End Class
