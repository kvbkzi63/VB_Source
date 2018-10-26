
Imports System.Configuration

Public Class PubRuleOrdSerialNoFactory

    Private Shared instance As PubRuleOrdSerialNoFactory = Nothing
    Public Shared ReadOnly typeD = "D" '由MinNo開始，直到最大號。

    Public vType As String '給定 typeA ~ typeD
    Public vKey As String  '標定 Label
    Public vMinNo As Integer = 1 '最小號，default 給 1
    Public vMaxNo As Integer = 99999999 '最大號，建議給99999999，沒有限制最大號給 -1
    Public vInc As Integer = 1 '每次加號，Default給 1

    Public Sub New()
        vType = typeD
        vKey = "PUB_Rule_ORD"
        vMinNo = 1
        vMaxNo = -1
        vInc = 1
    End Sub

    Public Shared Function getInstance() As PubRuleOrdSerialNoFactory
        If instance Is Nothing Then
            instance = New PubRuleOrdSerialNoFactory
        End If
        Return instance
    End Function

    Public Function getSerialNo() As String

        Dim serialNo As Integer = SerialNoServiceClient.getInstance.getSerialNo(vType, vKey, vMinNo, vMaxNo, vInc)
        Return serialNo

    End Function

End Class
