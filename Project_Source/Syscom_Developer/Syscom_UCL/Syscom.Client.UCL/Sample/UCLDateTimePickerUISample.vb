Public Class UCLDateTimePickerUISample

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Text += "設定日期SetValue 請使用西元年(ex:2009/12/12)。 " + vbCrLf + vbCrLf
        RichTextBox1.Text += "屬性與方法設定請參考UCL共用元件使用說明.doc 第2與3項元件 " + vbCrLf

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UclDateTimePickerUI1.SetValue("2009/12/12")
        UclDateTimePickerUI2.SetValue("2009/12/12")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        UclDateTimePickerUI1.SetValue(Now.ToShortDateString)
        UclDateTimePickerUI2.SetValue(Now.ToShortDateString)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UclDateTimePickerUI1.Clear()
        UclDateTimePickerUI2.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MessageBox.Show(UclDateTimePickerUI1.GetTwDateStr)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MessageBox.Show(UclDateTimePickerUI1.GetUsDateStr)
    End Sub

    Private Sub UclDateTimePickerUI2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclDateTimePickerUI2.ValueChanged
        Console.WriteLine("changed")
    End Sub
End Class