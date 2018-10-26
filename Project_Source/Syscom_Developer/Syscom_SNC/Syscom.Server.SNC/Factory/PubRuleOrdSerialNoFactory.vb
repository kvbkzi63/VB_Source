
Imports System.Configuration

Public Class PubRuleOrdSerialNoFactory

    Private Shared instance As PubRuleOrdSerialNoFactory = Nothing
    Public Shared ReadOnly typeD = "D" '��MinNo�}�l�A����̤j���C

    Public vType As String '���w typeA ~ typeD
    Public vKey As String  '�Щw Label
    Public vMinNo As Integer = 1 '�̤p���Adefault �� 1
    Public vMaxNo As Integer = 99999999 '�̤j���A��ĳ��99999999�A�S������̤j���� -1
    Public vInc As Integer = 1 '�C���[���ADefault�� 1

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
