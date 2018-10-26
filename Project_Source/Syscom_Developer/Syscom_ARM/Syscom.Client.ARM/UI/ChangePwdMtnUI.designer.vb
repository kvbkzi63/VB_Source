<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePwdMtnUI

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNewPasswordConfirm = New System.Windows.Forms.Label()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.lblOrgPassword = New System.Windows.Forms.Label()
        Me.newPasswordConfirm = New System.Windows.Forms.TextBox()
        Me.newPassword = New System.Windows.Forms.TextBox()
        Me.orgPassword = New System.Windows.Forms.TextBox()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.userId = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ResetPWBtn = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.54045!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.45955!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblNewPasswordConfirm, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNewPassword, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOrgPassword, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.newPasswordConfirm, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.newPassword, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.orgPassword, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUserId, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.userId, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(28, 13)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(309, 186)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblNewPasswordConfirm
        '
        Me.lblNewPasswordConfirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblNewPasswordConfirm.AutoSize = True
        Me.lblNewPasswordConfirm.ForeColor = System.Drawing.Color.Red
        Me.lblNewPasswordConfirm.Location = New System.Drawing.Point(7, 125)
        Me.lblNewPasswordConfirm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNewPasswordConfirm.Name = "lblNewPasswordConfirm"
        Me.lblNewPasswordConfirm.Size = New System.Drawing.Size(104, 16)
        Me.lblNewPasswordConfirm.TabIndex = 0
        Me.lblNewPasswordConfirm.Text = "新密碼再確認"
        '
        'lblNewPassword
        '
        Me.lblNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.ForeColor = System.Drawing.Color.Red
        Me.lblNewPassword.Location = New System.Drawing.Point(55, 87)
        Me.lblNewPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(56, 16)
        Me.lblNewPassword.TabIndex = 0
        Me.lblNewPassword.Text = "新密碼"
        '
        'lblOrgPassword
        '
        Me.lblOrgPassword.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrgPassword.AutoSize = True
        Me.lblOrgPassword.ForeColor = System.Drawing.Color.Red
        Me.lblOrgPassword.Location = New System.Drawing.Point(55, 49)
        Me.lblOrgPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrgPassword.Name = "lblOrgPassword"
        Me.lblOrgPassword.Size = New System.Drawing.Size(56, 16)
        Me.lblOrgPassword.TabIndex = 0
        Me.lblOrgPassword.Text = "原密碼"
        '
        'newPasswordConfirm
        '
        Me.newPasswordConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.newPasswordConfirm.Location = New System.Drawing.Point(119, 119)
        Me.newPasswordConfirm.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.newPasswordConfirm.MaxLength = 15
        Me.newPasswordConfirm.Name = "newPasswordConfirm"
        Me.newPasswordConfirm.Size = New System.Drawing.Size(116, 27)
        Me.newPasswordConfirm.TabIndex = 4
        Me.newPasswordConfirm.UseSystemPasswordChar = True
        '
        'newPassword
        '
        Me.newPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.newPassword.Location = New System.Drawing.Point(119, 81)
        Me.newPassword.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.newPassword.MaxLength = 15
        Me.newPassword.Name = "newPassword"
        Me.newPassword.Size = New System.Drawing.Size(116, 27)
        Me.newPassword.TabIndex = 3
        Me.newPassword.UseSystemPasswordChar = True
        '
        'orgPassword
        '
        Me.orgPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.orgPassword.Location = New System.Drawing.Point(119, 43)
        Me.orgPassword.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.orgPassword.MaxLength = 15
        Me.orgPassword.Name = "orgPassword"
        Me.orgPassword.Size = New System.Drawing.Size(116, 27)
        Me.orgPassword.TabIndex = 2
        Me.orgPassword.UseSystemPasswordChar = True
        '
        'lblUserId
        '
        Me.lblUserId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUserId.AutoSize = True
        Me.lblUserId.Location = New System.Drawing.Point(71, 11)
        Me.lblUserId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(40, 16)
        Me.lblUserId.TabIndex = 0
        Me.lblUserId.Text = "帳號"
        '
        'userId
        '
        Me.userId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.userId.Location = New System.Drawing.Point(119, 5)
        Me.userId.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.userId.MaxLength = 15
        Me.userId.Name = "userId"
        Me.userId.ReadOnly = True
        Me.userId.Size = New System.Drawing.Size(116, 27)
        Me.userId.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ResetPWBtn, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Confirm, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(118, 155)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(187, 30)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'ResetPWBtn
        '
        Me.ResetPWBtn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ResetPWBtn.Location = New System.Drawing.Point(97, 3)
        Me.ResetPWBtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ResetPWBtn.Name = "ResetPWBtn"
        Me.ResetPWBtn.Size = New System.Drawing.Size(86, 24)
        Me.ResetPWBtn.TabIndex = 8
        Me.ResetPWBtn.Text = "重設密碼"
        Me.ResetPWBtn.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Confirm.Location = New System.Drawing.Point(4, 3)
        Me.btn_Confirm.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(85, 24)
        Me.btn_Confirm.TabIndex = 7
        Me.btn_Confirm.Text = "確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'ChangePwdMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 211)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ChangePwdMtnUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "ChangePasswordUI"
        Me.Text = "修改密碼"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblOrgPassword As System.Windows.Forms.Label
    Friend WithEvents lblNewPasswordConfirm As System.Windows.Forms.Label
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents userId As System.Windows.Forms.TextBox
    Friend WithEvents newPasswordConfirm As System.Windows.Forms.TextBox
    Friend WithEvents newPassword As System.Windows.Forms.TextBox
    Friend WithEvents orgPassword As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ResetPWBtn As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
End Class
