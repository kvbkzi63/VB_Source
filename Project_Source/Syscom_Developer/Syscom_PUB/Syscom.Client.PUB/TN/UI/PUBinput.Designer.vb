<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBinput
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
        Me.rich_instruction = New System.Windows.Forms.RichTextBox()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rich_instruction
        '
        Me.rich_instruction.Location = New System.Drawing.Point(12, 14)
        Me.rich_instruction.MaxLength = 32767
        Me.rich_instruction.Name = "rich_instruction"
        Me.rich_instruction.Size = New System.Drawing.Size(460, 300)
        Me.rich_instruction.TabIndex = 72
        Me.rich_instruction.Text = ""
        '
        'btn_Print
        '
        Me.btn_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Print.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Print.Location = New System.Drawing.Point(13, 321)
        Me.btn_Print.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(90, 28)
        Me.btn_Print.TabIndex = 231
        Me.btn_Print.Text = "確定"
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'PUBinput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 362)
        Me.Controls.Add(Me.btn_Print)
        Me.Controls.Add(Me.rich_instruction)
        Me.Name = "PUBinput"
        Me.TabText = "說明"
        Me.Text = "說明"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rich_instruction As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_Print As System.Windows.Forms.Button
End Class
