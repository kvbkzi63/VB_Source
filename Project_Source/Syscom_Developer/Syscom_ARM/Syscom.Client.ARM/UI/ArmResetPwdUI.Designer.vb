<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArmResetPwdUI
    Inherits Syscom.Client.UCL.BaseFormUI

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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Lab_pwd = New System.Windows.Forms.Label()
        Me.Txt_Pwd = New System.Windows.Forms.TextBox()
        Me.Btn_Reset = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.Txt_EmployeeCode = New System.Windows.Forms.TextBox()
        Me.Lab_EmployeeCode = New System.Windows.Forms.Label()
        Me.Lab_EmployeeName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lab_pwd
        '
        Me.Lab_pwd.AutoSize = True
        Me.Lab_pwd.Location = New System.Drawing.Point(30, 73)
        Me.Lab_pwd.Name = "Lab_pwd"
        Me.Lab_pwd.Size = New System.Drawing.Size(40, 16)
        Me.Lab_pwd.TabIndex = 0
        Me.Lab_pwd.Text = "密碼"
        '
        'Txt_Pwd
        '
        Me.Txt_Pwd.Location = New System.Drawing.Point(87, 70)
        Me.Txt_Pwd.MaxLength = 15
        Me.Txt_Pwd.Name = "Txt_Pwd"
        Me.Txt_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Pwd.Size = New System.Drawing.Size(151, 27)
        Me.Txt_Pwd.TabIndex = 1
        '
        'Btn_Reset
        '
        Me.Btn_Reset.Location = New System.Drawing.Point(61, 118)
        Me.Btn_Reset.Name = "Btn_Reset"
        Me.Btn_Reset.Size = New System.Drawing.Size(87, 23)
        Me.Btn_Reset.TabIndex = 2
        Me.Btn_Reset.Text = "重設密碼"
        Me.Btn_Reset.UseVisualStyleBackColor = True
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Location = New System.Drawing.Point(163, 118)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Exit.TabIndex = 3
        Me.Btn_Exit.Text = "離開"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'Txt_EmployeeCode
        '
        Me.Txt_EmployeeCode.Enabled = False
        Me.Txt_EmployeeCode.Location = New System.Drawing.Point(87, 22)
        Me.Txt_EmployeeCode.MaxLength = 15
        Me.Txt_EmployeeCode.Name = "Txt_EmployeeCode"
        Me.Txt_EmployeeCode.Size = New System.Drawing.Size(97, 27)
        Me.Txt_EmployeeCode.TabIndex = 5
        '
        'Lab_EmployeeCode
        '
        Me.Lab_EmployeeCode.AutoSize = True
        Me.Lab_EmployeeCode.Location = New System.Drawing.Point(30, 25)
        Me.Lab_EmployeeCode.Name = "Lab_EmployeeCode"
        Me.Lab_EmployeeCode.Size = New System.Drawing.Size(40, 16)
        Me.Lab_EmployeeCode.TabIndex = 4
        Me.Lab_EmployeeCode.Text = "帳號"
        '
        'Lab_EmployeeName
        '
        Me.Lab_EmployeeName.AutoSize = True
        Me.Lab_EmployeeName.Location = New System.Drawing.Point(187, 25)
        Me.Lab_EmployeeName.Name = "Lab_EmployeeName"
        Me.Lab_EmployeeName.Size = New System.Drawing.Size(51, 16)
        Me.Lab_EmployeeName.TabIndex = 6
        Me.Lab_EmployeeName.Text = "Label1"
        '
        'ArmResetPwdUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 173)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lab_EmployeeName)
        Me.Controls.Add(Me.Txt_EmployeeCode)
        Me.Controls.Add(Me.Lab_EmployeeCode)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_Reset)
        Me.Controls.Add(Me.Txt_Pwd)
        Me.Controls.Add(Me.Lab_pwd)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ArmResetPwdUI"
        Me.TabText = "重設密碼"
        Me.Text = "重設密碼"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lab_pwd As System.Windows.Forms.Label
    Friend WithEvents Txt_Pwd As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Reset As System.Windows.Forms.Button
    Friend WithEvents Btn_Exit As System.Windows.Forms.Button
    Friend WithEvents Lab_EmployeeCode As System.Windows.Forms.Label
    Public WithEvents Txt_EmployeeCode As System.Windows.Forms.TextBox
    Friend WithEvents Lab_EmployeeName As System.Windows.Forms.Label
End Class
