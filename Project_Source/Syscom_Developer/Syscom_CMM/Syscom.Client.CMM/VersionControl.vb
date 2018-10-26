Imports System.Deployment.Application
Imports System.Windows.Forms

Public Class VersionControl

    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    ''' <summary>
    ''' 判斷安裝的版本，若是有新版本顯示訊息，立即更新。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            'MsgBox("Before check")
            Try
                info = AD.CheckForDetailedUpdate()
            Catch e As Exception
                MessageBox.Show("新版程式無法下載:" & e.Message)
                Return
            End Try
            'MsgBox("After check")

            If (info.UpdateAvailable) Then
                MessageBox.Show("已偵測到新版程式，需立即更新程式", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "新版程式下載中，請稍後‧‧‧")
                Try
                    AD.Update()
                    Application.Restart()
                Catch dde As DeploymentDownloadException
                    MessageBox.Show("無法更新程式:" + dde.Message)
                    Return
                Finally
                    pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
                End Try
            Else
                'MsgBox("No new")
            End If
        Else
            'MsgBox("Not ClickOnce")
        End If
    End Sub

End Class
