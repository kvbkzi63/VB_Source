<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobTextDialogUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtb_Input = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtb_Input
        '
        Me.rtb_Input.Location = New System.Drawing.Point(4, 4)
        Me.rtb_Input.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.rtb_Input.Name = "rtb_Input"
        Me.rtb_Input.Size = New System.Drawing.Size(200, 240)
        Me.rtb_Input.TabIndex = 0
        Me.rtb_Input.uclMaxLength = 32767
        Me.rtb_Input.uclReadOnly = False
        Me.rtb_Input.uclWordWrap = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Exit)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 249)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(209, 36)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(4, 4)
        Me.btn_Confirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(96, 27)
        Me.btn_Confirm.TabIndex = 0
        Me.btn_Confirm.Text = "送出"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(108, 4)
        Me.btn_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(96, 27)
        Me.btn_Exit.TabIndex = 1
        Me.btn_Exit.Text = "離開"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'JobTextDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.rtb_Input)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "JobTextDialogUI"
        Me.TabText = "JobTextDialogUI"
        Me.Text = "JobTextDialogUI"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtb_Input As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Confirm As Windows.Forms.Button
    Friend WithEvents btn_Exit As Windows.Forms.Button
End Class
