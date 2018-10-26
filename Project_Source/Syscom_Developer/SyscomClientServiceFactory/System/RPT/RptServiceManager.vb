Imports Syscom.Client.Servicefactory.RptServiceReference

Partial Public Class RptServiceManager

    ''' <summary>
    ''' 取得印表機名稱
    ''' Add By Jen
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="type"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String Implements IRptServiceManager.getPrinterName
        Try
            Using service As RptServiceClient = getRptServiceClient()
                Return service.getPrinterName(id, type, con)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得報表 ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportID() As String Implements IRptServiceManager.getReportID
        Try
            Using service As RptServiceClient = getRptServiceClient()
                Return service.getReportID
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
