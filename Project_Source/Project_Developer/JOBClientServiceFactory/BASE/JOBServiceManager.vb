Imports System.Configuration
Imports JOBClientServiceFactory.JOBServiceReference

Public Class JOBServiceManager
    Implements IJOBServiceManager
    Private Shared instance As JOBServiceManager
    Private Shared Domain As String = ConfigurationManager.AppSettings.Item("wcfdomain")
    Private Shared UserName As String = ConfigurationManager.AppSettings.Item("wcfusername")
    Private Shared Password As String = ConfigurationManager.AppSettings.Item("wcfpassword")

    Private Sub New()

    End Sub
    Public Shared Function getInstance() As JOBServiceManager
        Try
            If (instance Is Nothing) Then
                instance = New JOBServiceManager
            End If
            Return instance
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function getJOBService() As JOBServiceClient
        Dim client As JOBServiceClient = New JOBServiceClient

        client.ClientCredentials.Windows.ClientCredential.Domain = Domain
        client.ClientCredentials.Windows.ClientCredential.UserName = UserName
        client.ClientCredentials.Windows.ClientCredential.Password = Password
        Return client
    End Function
End Class
