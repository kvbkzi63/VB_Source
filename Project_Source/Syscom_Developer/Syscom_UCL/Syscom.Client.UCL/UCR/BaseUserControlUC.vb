Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class BaseUserControlUC

    Private Shared gblIsRunTime As Boolean = False

    ''' <summary>
    ''' 畫面載入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseUserControlUC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ''判斷 Run-Time / Design Mode , 若為 Design Mode 則不進行重繪

            'If Not gblIsRunTime Then
            '    Dim isDesignTime As Boolean = GetService(GetType(System.ComponentModel.Design.IDesignerHost)) IsNot Nothing

            '    If isDesignTime Then
            '        Exit Sub
            '    Else
            '        gblIsRunTime = True
            '    End If
            'End If



            ''自動依解析度調整畫面元件大小
            'If UCLFormUtil.isResizeable Then
            '    Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            '    UCLFormUtil.ReDrawForm(Me)
            'End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class
