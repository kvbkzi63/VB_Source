Public Class UCLCensusUISample

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Text += "UCLCensusUI 與 UCLCensusAddrUI元件 ，使用前請一定要先呼叫Initial方法進行初始化動作。 " + vbCrLf + vbCrLf
        RichTextBox1.Text += "UclCensusUI1.Initial()。 " + vbCrLf
        RichTextBox1.Text += "UclCensusAddrUI1.Initial()。 " + vbCrLf + vbCrLf



        RichTextBox1.Text += "屬性與方法設定請參考UCL共用元件使用說明.doc 第2與3項元件 " + vbCrLf

        UclCensusUI1.Initial()
        UclCensusAddrUI1.Initial()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UclCensusUI1.SelectedValue = "0101"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UclCensusAddrUI1.SelectedValue = "105"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("戶籍地代碼:" + UclCensusUI1.SelectAreaCode)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MessageBox.Show("戶籍地名稱:" + UclCensusUI1.SelectAreaName)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MessageBox.Show("郵遞區號代碼:" + UclCensusUI1.SelectPostalCode)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        MessageBox.Show("郵遞區號名稱:" + UclCensusUI1.SelectPostalName)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        MessageBox.Show("戶籍地代碼:" + UclCensusAddrUI1.SelectAreaCode)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MessageBox.Show("戶籍地名稱:" + UclCensusAddrUI1.SelectAreaName)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MessageBox.Show("郵遞區號代碼:" + UclCensusAddrUI1.SelectPostalCode)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MessageBox.Show("郵遞區號名稱:" + UclCensusAddrUI1.SelectPostalName)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        MessageBox.Show("地址:" + UclCensusAddrUI1.TxtAddress)
    End Sub
End Class