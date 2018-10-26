Public Interface IRptServiceManager_T

    ''' <summary>
    ''' 取得印表機名稱
    ''' Add By Jen
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="type"></param>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getPrinterName(ByVal id As String, ByVal type As Integer, ByVal con As Object) As String

    ''' <summary>
    ''' 取得報表ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getReportID() As String

End Interface
