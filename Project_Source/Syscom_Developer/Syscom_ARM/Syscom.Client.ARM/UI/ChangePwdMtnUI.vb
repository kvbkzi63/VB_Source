Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility.PassWordUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL
Imports Syscom.Comm.BASE
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
 Imports System.Text.RegularExpressions

Public Class ChangePwdMtnUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Private Sub ChangePwdMtnUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If userId.Text = "" Then
                userId.Text = AppContext.userProfile.userId
            End If

            '不可更改
            userId.Enabled = False

            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese

                    '繁體中文
                    lblUserId.Text = "帳號"
                    lblOrgPassword.Text = "原密碼"
                    lblNewPassword.Text = "新密碼"
                    lblNewPasswordConfirm.Text = "新密碼再確認"
                    btn_Confirm.Text = "確定"
                Case AppConfigUtil.Language.SimplifiedChinese

                    '簡體中文
                    lblUserId.Text = "帐号"
                    lblOrgPassword.Text = "原密码"
                    lblNewPassword.Text = "新密码"
                    lblNewPasswordConfirm.Text = "新密码再确认"
                    btn_Confirm.Text = "确定"
            End Select
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 確認修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        Try
            '繁中顯示訊息
            Dim MsgStringTradtional As String() = New String() {"欄位請勿空白", "新舊密碼不可相同", "密碼長度至少7位", "新密碼輸入不一致", "舊密碼錯誤，無法更新"}

            '簡中顯示訊息
            Dim MsgStringSimple As String() = New String() {"栏位请勿空白", "新旧密码不可相同", "密码长度至少7位", "新密码输入不一致", "旧密码错误，无法更新"}

            '顯示的訊息字樣 - 預設繁中
            Dim Msgstring As String() = MsgStringTradtional

            '設定訊息字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese
                    '繁體中文
                    Msgstring = MsgStringTradtional
                Case AppConfigUtil.Language.SimplifiedChinese
                    '簡體中文
                    Msgstring = MsgStringSimple
            End Select

            '欄位請勿空白
            If userId.Text.Trim = "" Or orgPassword.Text.Trim = "" Or newPassword.Text.Trim = "" Or newPasswordConfirm.Text.Trim = "" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {Msgstring(0)}, "")
                Exit Sub
            End If

            '新舊密碼不可相同
            If orgPassword.Text = newPassword.Text Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {Msgstring(1)}, "")
                Exit Sub
            ElseIf newPassword.Text.Trim.Length < 7 Then
                '密碼長度至少7位
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {Msgstring(2)}, "")
                Exit Sub
            ElseIf newPassword.Text = newPasswordConfirm.Text Then

                Dim dset As DataSet = New DataSet
                Dim dtable As DataTable = New DataTable
                dtable.TableName = "User"
                dtable.Columns.Add("userid")
                dtable.Columns.Add("orgpass")
                dtable.Columns.Add("newpass")
                Dim valueObject() As Object = {userId.Text.Trim, Encrypt(nvl(orgPassword.Text), PassWordUtil.getPrimaryKey), Encrypt(nvl(newPassword.Text), PassWordUtil.getPrimaryKey)}

                dtable.Rows.Add(valueObject)
                dset.Tables.Add(dtable)

                '修改帳號密碼
                Dim count As Integer = ArmServiceManager.getInstance.ChangePassword(dset)

                If count > 0 Then
                    '修改成功
                    MessageHandling.ShowWarnMsg("CMMCMMB903", New String() {})
                    Me.Close()
                Else
                    '舊密碼錯誤，無法更新
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {Msgstring(4)}, "")
                End If
            Else
                '新密码输入不一致
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {Msgstring(3)}, "")
                Exit Sub
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 給外部呼叫來開啟視窗
    ''' </summary>
    ''' <param name="userid">使用者帳號</param>
    ''' <param name="owner">原呼叫表單</param>
    ''' <remarks></remarks>
    Public Sub showForm(ByVal userid As String, ByVal owner As Form)
        Try
            Using cpUi As ChangePwdMtnUI = New ChangePwdMtnUI()
                cpUi.userId.Enabled = False
                cpUi.Owner = owner
                cpUi.ShowDialog()
                If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_Kmuh Then

                Else

                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 給外部呼叫來開啟視窗
    ''' </summary>
    ''' <param name="owner">原呼叫表單</param>
    ''' <remarks></remarks>
    Public Sub showForm(ByVal owner As Form)
        Try
            showForm("", owner)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub newPasswordConfirm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newPasswordConfirm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btn_Confirm.PerformClick()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#Region " HotKey 设定 "

    ''' <summary>
    ''' HotKey 设定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Sean.Lin on 2013-5-21</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '锁定萤幕
        UCLScreenUtil.Lock(Me)
        Try
            Select Case e.KeyCode

                'Enter 模擬 Tab
                Case Keys.Enter

                    '如果 確認鍵 取得 焦點 或者 UclCbo_Section 有焦點，且有值，則判斷成 確認鍵要被按下
                    If (orgPassword.Text.ToString <> "" And newPassword.Text.ToString <> "" And newPasswordConfirm.Text.ToString <> "") Then
                        btn_Confirm.PerformClick()
                    Else
                        Me.ProcessTabKey(True)
                    End If
            End Select
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除萤幕锁定
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     檢核輸入英數字"
    ''' <summary>
    ''' 檢核Key入的字元，True=符合規範 False=非數字與英文
    ''' </summary>
    ''' <param name="KeyInChar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckKeyInChar(ByVal KeyInChar As String) As Boolean

        Try
            Dim englishRegex As Regex = New Regex("[A-Za-z0-9]")

            '檢核是否為數字
            If IsNumeric(KeyInChar) Then

                Return True

            ElseIf englishRegex.IsMatch(KeyInChar) Then

                Return True
            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '2016/04/02 Sean warning 排除
            Return False
        End Try
        Return False
    End Function
#End Region
#Region "  重設密碼"
    ''' <summary>
    ''' 重設密碼
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResetPWBtn_Click(sender As Object, e As EventArgs) Handles ResetPWBtn.Click
        Try
            Dim RestResultFlag As DialogResult = MessageBox.Show("請問是否要重設密碼為員工編號?", "重設密碼", MessageBoxButtons.OKCancel)

            If RestResultFlag = Windows.Forms.DialogResult.OK Then

                Dim dset As DataSet = New DataSet
                Dim dtable As DataTable = New DataTable
                dtable.TableName = "User"
                dtable.Columns.Add("userid")
                dtable.Columns.Add("newpass")
                Dim valueObject() As Object = {userId.Text.Trim, Encrypt(nvl(userId.Text.Trim), PassWordUtil.getPrimaryKey)}

                dtable.Rows.Add(valueObject)
                dset.Tables.Add(dtable)

                '修改帳號密碼
                Dim count As Integer = ArmServiceManager.getInstance.ResetPassword(dset)

                If count > 0 Then
                    '修改成功
                    MessageHandling.ShowWarnMsg("CMMCMMB903", New String() {})
                    Me.Close()
                Else
                    '舊密碼錯誤，無法更新
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"重設密碼失敗"}, "")
                End If
            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region
End Class
