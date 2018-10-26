Imports System.Deployment.Application
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class UpdateVersionUI
    Dim v1 As String = ""
    Dim v2 As String = ""
    Private Sub UpdateVersionUI_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'lab_v1.Text = v1
        'lab_v2.Text = v2

        Try
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            AD.Update()

        Catch ex As Exception
            Throw ex
        Finally
            Me.Dispose()
        End Try
    End Sub

    Private Sub UpdateVersionUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        v1 = "目前版本: " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        v2 = "新的版本: " & ApplicationDeployment.CurrentDeployment.CheckForDetailedUpdate().AvailableVersion.ToString
        lab_v1.Text = v1
        lab_v2.Text = v2
        Threading.Thread.Sleep(2000)
    End Sub

End Class