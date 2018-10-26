Public Class SamplePDFUI

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim param As Object
            param = {"*", "SamplePDF", ""}
            Dim printData As SamplePDFClient = New SamplePDFClient(param)
            printData.preview(param)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class