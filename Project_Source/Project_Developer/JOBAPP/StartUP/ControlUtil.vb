Imports System.ServiceModel.Configuration
Imports System.Configuration
Imports System.IO
Imports System.Windows.Forms

Public Class ControlUtil
    Private Shared ControlUtil As New ControlUtil
#Region "   變數宣告"

    Private Shared _AppBackImage As String
    Private Shared _AppLoginFormTitle As String
    Private kmuh_env As String = System.Configuration.ConfigurationSettings.AppSettings("kmuh_env")
#End Region

#Region "阻止外部直接宣告"
    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
        getWebServiceEvn()
    End Sub
#End Region

#Region "功能"
    ''' <summary>
    ''' 根據連接的WCF 來取得底圖
    ''' </summary>
    ''' <remarks>自動取得Login畫面的底圖</remarks>
    Private Sub getWebServiceEvn()
        'Dim clientSettings As ClientSection = TryCast(ConfigurationManager.GetSection("system.serviceModel/client"), ClientSection)
        'Dim address As String = Nothing

        'For Each endpoint As ChannelEndpointElement In clientSettings.Endpoints
        '    Dim strEndPoint As String = (endpoint.Name).ToUpper
        '    If strEndPoint = "WSHTTPBINDING_IUCLSERVICE" Then
        '        address = endpoint.Address.ToString()
        '        Exit For
        '    End If
        'Next
        Dim appPath As String = Application.StartupPath
        Dim strBmp As String = ""
        Dim APPTitle As String = ""

        Select Case kmuh_env
            Case "0"
                '正式機
                strBmp = appPath & "\Images\高雄市聯合醫院.jpg"
                APPTitle = ""
            Case "1"
                '測試機
                strBmp = appPath & "\Images\高雄市聯合醫院(測試機).jpg"
                APPTitle = "(測試機)"
            Case "2"
                '開發機
                strBmp = appPath & "\Images\高雄市聯合醫院(開發機).jpg"
                APPTitle = "(開發機)"
            Case "3"
                '建檔機
                strBmp = appPath & "\Images\高雄市聯合醫院(建檔機).jpg"
                APPTitle = "(建檔機)"
            Case "4"
                '模擬正式機
                strBmp = appPath & "\Images\高雄市聯合醫院(模擬正式機).jpg"
                APPTitle = "(模擬正式機)"
            Case "5"
                '專案管理系統
                strBmp = appPath & "\Images\專案管理系統.jpg"
                APPTitle = "(專案管理系統)"
        End Select

        If strBmp <> "" AndAlso File.Exists(strBmp) Then

        Else
            strBmp = appPath & "\Images\高雄市聯合醫院(開發機).jpg"
        End If

        _AppBackImage = strBmp
        _AppLoginFormTitle = APPTitle
    End Sub
#End Region


#Region "屬性"
    ''' <summary>
    ''' 設定或取得LoginForm背景圖
    ''' </summary>
    ''' <value></value>
    ''' <returns>LoginForm背景圖</returns>
    ''' <remarks>LoginForm背景圖</remarks>
    Public Shared Property AppBackImage() As String
        Get
            Return _AppBackImage
        End Get
        Set(ByVal value As String)
            _AppBackImage = value
        End Set
    End Property
    ''' <summary>
    '''  設定或取得LoginForm APP Title
    ''' </summary>
    ''' <value></value>
    ''' <returns>LoginForm APP 抬頭</returns>
    ''' <remarks>LoginForm APP 抬頭</remarks>
    Public Shared Property AppLoginFormTitle() As String
        Get
            Return _AppLoginFormTitle
        End Get
        Set(ByVal value As String)
            _AppLoginFormTitle = value
        End Set
    End Property
#End Region

End Class
