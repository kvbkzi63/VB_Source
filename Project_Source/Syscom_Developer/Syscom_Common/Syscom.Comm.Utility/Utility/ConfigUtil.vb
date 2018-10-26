Imports System.Configuration

Public Class ConfigUtil

    Public Shared Function GetConfigValue(ByVal configName As String) As String

        Dim result As String = ""
        If ConfigurationManager.AppSettings.Item(configName) IsNot Nothing Then
            result = ConfigurationManager.AppSettings.Item(configName)
        End If

        Return result

    End Function


End Class
