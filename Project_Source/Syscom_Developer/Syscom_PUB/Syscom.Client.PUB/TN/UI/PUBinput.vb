Imports System.Text
Imports Syscom.Client.UCL
Public Class PUBinput
    Inherits Syscom.Client.UCL.BaseFormUI
    Dim endString As String

    'Public Sub PUBinput(ByRef str As String)
    '    rich_instruction.Text = str
    'End Sub


    'Public Sub New()

    'End Sub
    'Public Sub New(ByRef text As String)
    '    rich_instruction.Text = text
    'End Sub

    Private Sub PUBinput_show(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        endString = rich_instruction.Text
        Close()
        'End
    End Sub


    Public Function getRich() As String
        Return endString
    End Function

    Private Sub rich_instruction_TextChanged(sender As Object, e As EventArgs) Handles rich_instruction.TextChanged
        CType(Me.Owner, PUBPreventiveCareSetupUI).rich_instruction.Text = rich_instruction.Text
    End Sub
End Class