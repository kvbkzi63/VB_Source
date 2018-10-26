Imports System.Configuration
Imports Syscom.Client.Servicefactory.ArmServiceReference

Public Class ArmServiceManager
    Implements IArmServiceManager

    Private Domain As String = ConfigurationManager.AppSettings.Item("wcfdomain")
    Private UserName As String = ConfigurationManager.AppSettings.Item("wcfusername")
    Private Password As String = ConfigurationManager.AppSettings.Item("wcfpassword")

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As ArmServiceManager
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New ArmServiceManager()
    End Class

#End Region

    Private Function getArmService() As ArmServiceClient
        Dim client As New ArmServiceClient
        client.ClientCredentials.Windows.ClientCredential.Domain = Domain
        client.ClientCredentials.Windows.ClientCredential.UserName = UserName
        client.ClientCredentials.Windows.ClientCredential.Password = Password
        Return client
    End Function

End Class
