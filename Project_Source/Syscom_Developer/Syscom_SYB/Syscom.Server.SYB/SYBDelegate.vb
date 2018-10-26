
Imports Syscom.Comm.LOG


Public Class SYBDelegate
    Private Shared instance As SYBDelegate

    Private Sub New()
    End Sub
    Public Shared Function getInstance() As SYBDelegate

        Try
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            If instance Is Nothing Then
                instance = New SYBDelegate
            End If
            Return instance
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function test(ByVal sql As String) As DataSet
        Dim syb As New Syscom.Server.SYB.SybAPI
        Try
            Return syb.test(sql)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
