Imports Syscom.Client.CMM


Public Class PUBEmgAddOptionUI

    Private Sub PUBEmgAddOptionUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chk_O.Checked = True
        chk_E.Checked = True
        chk_I.Checked = True
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        If chk_O.Checked = False AndAlso chk_E.Checked = False AndAlso chk_I.Checked = False Then
            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"門急住至少要勾選一項!"})
        Else

            Me.Dispose()

        End If
    End Sub

End Class
