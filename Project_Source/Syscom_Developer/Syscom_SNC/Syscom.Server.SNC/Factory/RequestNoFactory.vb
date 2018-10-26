Public Class RequestNoFactory
    Private Shared instance As RequestNoFactory
    Public Shared Function getInstance() As RequestNoFactory
        If instance Is Nothing Then
            instance = New RequestNoFactory()
        End If
        Return instance
    End Function


    Public Function getSerialNo(ByVal vSection As String, ByVal vSourceKind As String) As String
        Dim serialNo As String = SerialNoServiceClient.getInstance.getRequestNo(vSection, vSourceKind)
        Return serialNo
    End Function
End Class
