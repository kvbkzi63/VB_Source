Imports Syscom.Comm.BASE

Public Class ResourceUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    Public Shared ReadOnly CMMCLIENT As String = "Comm.CMN.dll,nckuh.common.cmn.Resources"
    Public Shared ReadOnly RPT As String = "RPT.DLL,nckuh.common.rpt.Resources"
    Public Shared Function getString(ByVal key As String) As String
        Return getString(ResourceUtil.CMMCLIENT, key)
    End Function
    Public Shared Function getReportTitle(ByVal key As String) As String
        Return getString(ResourceUtil.RPT, key)
    End Function

    ''' <summary>
    '''取得對應字串
    ''' </summary>
    ''' <param name="res"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function getString(ByVal res As String, ByVal key As String) As String
        If RPT.Equals(res) Then
            Return MessageValueObject.getReportTitle(key)
        Else
            Return MessageValueObject.getMessageValue(key)
        End If
    End Function

    Friend Shared Function getString(ByVal res As String, ByVal key As String, ByVal opt() As String) As String
        If RPT.Equals(res) Then
            Return MessageValueObject.getReportTitle(key, opt)
        Else
            Return MessageValueObject.getMessageValue(key, opt)
        End If
    End Function

    Public Shared Function getResourceString(ByVal res As String, ByVal key As String) As String
        Return getString(res, key)
    End Function

    Public Shared Function getString(ByVal key As String, ByVal opt() As String) As String
        Return getString(ResourceUtil.CMMCLIENT, key, opt)
    End Function

End Class
