<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLOptionOrderUI
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
        Me.txt_Msg = New System.Windows.Forms.Label
        Me.lst_Option = New System.Windows.Forms.ListBox
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txt_Msg
        '
        Me.txt_Msg.AutoSize = True
        Me.txt_Msg.Location = New System.Drawing.Point(12, 18)
        Me.txt_Msg.Name = "txt_Msg"
        Me.txt_Msg.Size = New System.Drawing.Size(82, 15)
        Me.txt_Msg.TabIndex = 0
        Me.txt_Msg.Text = "請選取部位"
        '
        'lst_Option
        '
        Me.lst_Option.FormattingEnabled = True
        Me.lst_Option.ItemHeight = 15
        Me.lst_Option.Location = New System.Drawing.Point(12, 46)
        Me.lst_Option.Name = "lst_Option"
        Me.lst_Option.Size = New System.Drawing.Size(303, 199)
        Me.lst_Option.TabIndex = 1
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(240, 252)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 33)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.Text = "取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'UCLOptionOrderUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 290)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.lst_Option)
        Me.Controls.Add(Me.txt_Msg)
        Me.Font = New System.Drawing.Font("新細明體", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UCLOptionOrderUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Msg As System.Windows.Forms.Label
    Friend WithEvents lst_Option As System.Windows.Forms.ListBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
