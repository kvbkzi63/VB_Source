Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.LOG
Imports Syscom.Client.CMM
Imports System.Windows.Forms
Imports Syscom.Client.UCL
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Timers
Imports System.Text

Public Class PUBExportOrderDataUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent



    Private Sub PUBExportOrderDataUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UCLFormUtil.isResizeable = True Then
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            UCLFormUtil.ReDrawForm(Me)
        End If
    End Sub
End Class