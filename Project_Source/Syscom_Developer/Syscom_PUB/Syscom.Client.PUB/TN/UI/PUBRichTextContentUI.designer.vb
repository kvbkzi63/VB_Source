<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRichTextContentUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

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
        Me.txt_Content = New System.Windows.Forms.RichTextBox()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_Content
        '
        Me.txt_Content.Location = New System.Drawing.Point(7, 2)
        Me.txt_Content.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Content.Name = "txt_Content"
        Me.txt_Content.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txt_Content.Size = New System.Drawing.Size(552, 225)
        Me.txt_Content.TabIndex = 0
        Me.txt_Content.Text = ""
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(484, 234)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "傳回"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'PUBRichTextContentUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.txt_Content)
        Me.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PUBRichTextContentUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "內容編輯"
        Me.Text = "內容編輯"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_Content As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
End Class
