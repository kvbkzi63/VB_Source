Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection
Imports Com.Syscom.WinFormsUI.Docking

Public Partial Class AboutDialog
	Inherits Form
	Public Sub New()
		InitializeComponent()
	End Sub

    Private Sub AboutDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        labelAppVersion.Text = GetType(MainForm).Assembly.GetName().Version.ToString()
        labelLibVersion.Text = GetType(DockPanel).Assembly.GetName().Version.ToString()
    End Sub
End Class
