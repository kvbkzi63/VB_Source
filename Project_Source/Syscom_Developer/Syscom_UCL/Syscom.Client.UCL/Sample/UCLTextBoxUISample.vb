Public Class UCLTextBoxUCSample

    Private Sub UCLTExtBoxSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UCLTextBoxUC2.Text = "A123.,!=+/"
        UCLTextBoxUC3.Text = "-123.45"
        UCLTextBoxUC4.Text = "A100000001"
        UCLTextBoxUC5.Text = "23:12"
        UCLTextBoxUC6.Text = "11:34"
        UCLTextBoxUC7.Text = "17"
        UCLTextBoxUC8.Text = "09"
        UCLTextBoxUC9.Text = "57"
        UCLTextBoxUC10.Text = "50"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UCLTextBoxUC5.Text = "23:11"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(UCLTextBoxUC5.Text)
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UCLTextBoxUC6.Text)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UCLTextBoxUC3.Text.IndexOf(".")) '.SelectionStart.ToString)
        '  UCLTextBoxUC3.Text = 12.567
    End Sub
End Class