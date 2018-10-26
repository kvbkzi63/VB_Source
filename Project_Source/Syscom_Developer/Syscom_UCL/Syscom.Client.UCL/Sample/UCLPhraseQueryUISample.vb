Public Class UCLPhraseQueryUISample
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

    Private Sub UCLPhraseQueryUISample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        queryPhrase()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(UclPhraseQueryUI1.uclText)
    End Sub

    Private Sub queryPhrase()

        UclPhraseQueryUI1.uclUserTypeId = "1"

        UclPhraseQueryUI1.uclDoctor_Dept_Code = txt_Doctor_Code.Text.Trim

        If RadioButton1.Checked Then
            UclPhraseQueryUI1.uclPhraseTypeId = "S"
        ElseIf RadioButton2.Checked Then
            UclPhraseQueryUI1.uclPhraseTypeId = "O"
        ElseIf RadioButton3.Checked Then
            UclPhraseQueryUI1.uclPhraseTypeId = "A"
        ElseIf RadioButton4.Checked Then
            UclPhraseQueryUI1.uclPhraseTypeId = "AP"
        End If

        UclPhraseQueryUI1.queryPhrase()

    End Sub

    Private Sub UclPhraseQueryUI1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        TextBox1.Text = UclPhraseQueryUI1.uclQueryStr
    End Sub

    Private Sub UclPhraseQueryUI1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        MsgBox("Double Click")
    End Sub
End Class