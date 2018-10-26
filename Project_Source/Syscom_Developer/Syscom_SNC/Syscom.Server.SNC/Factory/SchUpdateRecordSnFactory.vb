
Imports System.Text

Public Class SchUpdateRecordSnFactory
    Private Shared instance As SchUpdateRecordSnFactory = Nothing
    Public Shared ReadOnly typeD = "D" '由MinNo開始，直到最大號。

    Public vType As String '給定 typeA ~ typeD
    Public vKey As String  '標定 Label
    Public vMinNo As Integer = 1 '最小號，default 給 1
    Public vMaxNo As Integer = 99999999 '最大號，建議給99999999，沒有限制最大號給 -1
    Public vInc As Integer = 1 '每次加號，Default給 1
    Public Shared Function getInstance() As SchUpdateRecordSnFactory
        If instance Is Nothing Then
            instance = New SchUpdateRecordSnFactory()
        End If
        Return instance
    End Function

    Public Sub New()
        vType = "D"
        vKey = "SchUpdateRecordSn"
        vMinNo = 1
        vMaxNo = -1
    End Sub

    ''' <summary>
    ''' 取得Sch_Update_Record序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSerialNo() As String
        Dim serialNo As Integer = SerialNoServiceClient.getInstance.getSerialNo(AbstractFactory.SncType.typeD, vKey, vMinNo, vMaxNo, vInc)
        Return serialNo
    End Function

End Class
