Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory

Public Class BaseFormUI

    Protected ARM As IArmServiceManager = Nothing
    Protected dsButtonControl As DataSet = Nothing

    Private Shared gblIsRunTime As Boolean = False

    ''' <summary>
    ''' 當Autosize時，是否將Form設為隱藏(True:隱藏, False:依原UI設定)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Description("當Autosize時，是否將Form設為隱藏"), System.ComponentModel.Category("自定義屬性")> _
    Public Property InvisibleWhenAutoSize As Boolean = False

    ''' <summary>
    ''' BaseFormUI內部控制是否啟用AutoSize功能(True:預設啟用, False:不啟用)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.Description("是否啟用AutoSize功能"), System.ComponentModel.Category("自定義屬性")> _
    Public Property IsActiveAutoSize As Boolean = True

    ''' <summary>
    ''' 畫面初始化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseFormUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Me.Tag IsNot Nothing Then
                ARM = ArmServiceManager.getInstance
                dsButtonControl = ARM.queryRoleRightsByMemberOf(AppContext.userProfile.userMemberOf)
                dsButtonControl.Tables(0).PrimaryKey = New DataColumn() {dsButtonControl.Tables(0).Columns("rrs_rights_id")}
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 畫面呈現
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseFormUI_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            '判斷 Run-Time / Design Mode , 若為 Design Mode 則不進行重繪

            If Not gblIsRunTime Then
                Dim isDesignTime As Boolean = GetService(GetType(System.ComponentModel.Design.IDesignerHost)) IsNot Nothing

                If isDesignTime Then
                    Exit Sub
                Else
                    gblIsRunTime = True
                End If
            End If

            '自動依解析度調整畫面元件大小
            If IsActiveAutoSize AndAlso UCLFormUtil.isResizeable AndAlso Me.Name.Length >= 3 _
                AndAlso Me.Name.Substring(0, 3).ToUpper <> "CNC" AndAlso Not (Me.Name.Contains("JobPGJobListUI") OrElse Me.Name.Contains("JobSAJobListUI")) _
                                AndAlso Me.Name.Substring(0, 3).ToUpper <> "ENC" Then

                Dim _visible As Boolean = Me.Visible
                Try
                    Me.SuspendLayout()

                    If Me.InvisibleWhenAutoSize AndAlso Me.Visible Then Me.Visible = False

                    Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                    UCLFormUtil.ReDrawForm(Me)
                    UCLFormUtil.ReSetLocToScreenCenter(Me)
                Catch ex As Exception
                    Throw ex
                Finally
                    If Me.InvisibleWhenAutoSize AndAlso _visible Then Me.Visible = True
                    Me.ResumeLayout()
                End Try


            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class