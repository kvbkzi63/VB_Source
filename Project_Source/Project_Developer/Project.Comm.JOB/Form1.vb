Imports System.IO

Public Class Form1

    Private Sub btnSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSource.Click
        If FolderBrowserDialog1.ShowDialog Then
            tbxSource.Text = FolderBrowserDialog1.SelectedPath
            Dim source As New DirectoryInfo(tbxSource.Text)
            lbxSource.DisplayMember = "FullName"
            lbxSource.Items.AddRange(source.GetFiles())
        End If
    End Sub

    Private Sub btnTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarget.Click
        If FolderBrowserDialog1.ShowDialog Then
            tbxTarget.Text = FolderBrowserDialog1.SelectedPath
            Dim target As New DirectoryInfo(tbxTarget.Text)
            lbxTarget.DisplayMember = "FullName"
            lbxTarget.Items.AddRange(target.GetFiles())
        End If
    End Sub

    Private Sub btnGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGO.Click
        Dim source As New DirectoryInfo(tbxSource.Text)
        Dim target As New DirectoryInfo(tbxTarget.Text)
        lbxDifferent.DisplayMember = "FullName"
        lbxDifferent.Items.AddRange(source.GetDifferentFileList(target))
    End Sub
End Class