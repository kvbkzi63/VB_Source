Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL.UCLScreenUtil

Public Class JobTextDialogUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     外部屬性設定"

    Private m_ExitWithoutInput As Boolean = False
    ''' <summary>
    ''' 是否可以不輸入任何文字就離開
    ''' </summary>
    ''' <returns></returns>
    Public Property ExitWithoutInput As Boolean
        Get
            Return m_ExitWithoutInput
        End Get
        Set(value As Boolean)
            m_ExitWithoutInput = value
        End Set
    End Property


    Private m_Text As String = ""
    ''' <summary>
    ''' 是否可以不輸入任何文字就離開
    ''' </summary>
    ''' <returns></returns>
    Public Property SetUIText As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
            Me.Text = m_Text
        End Set
    End Property

#End Region


#Region "     初始化"

    Public Overloads Function showDialog() As String

        MyBase.ShowDialog()

        Return rtb_Input.Text

    End Function

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click, btn_Confirm.Click
        Try
            Lock(Me)

            If sender.Name = "btn_Confirm" AndAlso rtb_Input.Text.Length = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "未填入原因")
                Exit Sub
            End If

            Me.Close()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"離開"})
        Finally
            UnLock(Me)
        End Try

    End Sub
#End Region

End Class