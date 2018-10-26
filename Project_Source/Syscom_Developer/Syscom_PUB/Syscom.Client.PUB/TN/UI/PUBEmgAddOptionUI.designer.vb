<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBEmgAddOptionUI
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
        Me.chk_O = New System.Windows.Forms.CheckBox
        Me.chk_E = New System.Windows.Forms.CheckBox
        Me.chk_I = New System.Windows.Forms.CheckBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chk_O
        '
        Me.chk_O.AutoSize = True
        Me.chk_O.Location = New System.Drawing.Point(13, 26)
        Me.chk_O.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_O.Name = "chk_O"
        Me.chk_O.Size = New System.Drawing.Size(59, 20)
        Me.chk_O.TabIndex = 0
        Me.chk_O.Text = "門診"
        Me.chk_O.UseVisualStyleBackColor = True
        '
        'chk_E
        '
        Me.chk_E.AutoSize = True
        Me.chk_E.Location = New System.Drawing.Point(109, 26)
        Me.chk_E.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_E.Name = "chk_E"
        Me.chk_E.Size = New System.Drawing.Size(59, 20)
        Me.chk_E.TabIndex = 1
        Me.chk_E.Text = "急診"
        Me.chk_E.UseVisualStyleBackColor = True
        '
        'chk_I
        '
        Me.chk_I.AutoSize = True
        Me.chk_I.Location = New System.Drawing.Point(201, 26)
        Me.chk_I.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_I.Name = "chk_I"
        Me.chk_I.Size = New System.Drawing.Size(59, 20)
        Me.chk_I.TabIndex = 2
        Me.chk_I.Text = "住院"
        Me.chk_I.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(100, 72)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 31)
        Me.btn_OK.TabIndex = 3
        Me.btn_OK.Text = "確定"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'PUBEmgAddOptionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 105)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.chk_I)
        Me.Controls.Add(Me.chk_E)
        Me.Controls.Add(Me.chk_O)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBEmgAddOptionUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "急作加成"
        Me.Text = "急作加成"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_O As System.Windows.Forms.CheckBox
    Friend WithEvents chk_E As System.Windows.Forms.CheckBox
    Friend WithEvents chk_I As System.Windows.Forms.CheckBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
End Class
