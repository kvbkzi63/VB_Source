<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLQuestionDialogUI
    Inherits System.Windows.Forms.Form

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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.BTN_Cancel = New System.Windows.Forms.Button
        Me.btn_Confirm = New System.Windows.Forms.Button
        Me.Rtb_Data = New System.Windows.Forms.RichTextBox
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.BTN_Cancel)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 330)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(438, 34)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'BTN_Cancel
        '
        Me.BTN_Cancel.Location = New System.Drawing.Point(345, 3)
        Me.BTN_Cancel.Name = "BTN_Cancel"
        Me.BTN_Cancel.Size = New System.Drawing.Size(90, 28)
        Me.BTN_Cancel.TabIndex = 1
        Me.BTN_Cancel.Text = "取消"
        Me.BTN_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(249, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_Confirm.TabIndex = 0
        Me.btn_Confirm.Text = "確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'Rtb_Data
        '
        Me.Rtb_Data.BackColor = System.Drawing.SystemColors.Window
        Me.Rtb_Data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rtb_Data.Location = New System.Drawing.Point(0, 0)
        Me.Rtb_Data.Name = "Rtb_Data"
        Me.Rtb_Data.ReadOnly = True
        Me.Rtb_Data.Size = New System.Drawing.Size(438, 330)
        Me.Rtb_Data.TabIndex = 1
        Me.Rtb_Data.Text = "確認視窗"
        '
        'PcsUclQuestionDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 364)
        Me.Controls.Add(Me.Rtb_Data)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLQuestionDialogUI.vb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UCLQuestionDialogUI.vb"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents BTN_Cancel As System.Windows.Forms.Button
    Friend WithEvents Rtb_Data As System.Windows.Forms.RichTextBox
End Class
