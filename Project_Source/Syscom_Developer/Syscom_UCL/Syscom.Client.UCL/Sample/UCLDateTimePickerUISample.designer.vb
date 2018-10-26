<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLDateTimePickerUISample
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.UclDateTimePickerUI2 = New Syscom.Client.ucl.UCLDateTimePickerUC
        Me.UclDateTimePickerUI1 = New Syscom.Client.ucl.UCLDateTimePickerUC
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(235, 171)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(246, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "以字串格式設定日期"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(36, 228)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 31)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "取得元件民國年日期"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(36, 51)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(488, 106)
        Me.RichTextBox1.TabIndex = 28
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "日期元件注意事項"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(235, 218)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(246, 31)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "以日期Date型態輸入設定日期"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "西元年"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(502, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "民國年"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(235, 267)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(246, 28)
        Me.Button4.TabIndex = 33
        Me.Button4.Text = "Clear Date"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(36, 267)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(150, 31)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "取得元件西元年日期"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'UclDateTimePickerUI2
        '
        Me.UclDateTimePickerUI2.DisplayLocale = Syscom.Client.ucl.UCLDateTimePickerUC.Locale.TW
        Me.UclDateTimePickerUI2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclDateTimePickerUI2.Location = New System.Drawing.Point(505, 190)
        Me.UclDateTimePickerUI2.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.UclDateTimePickerUI2.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UclDateTimePickerUI2.Name = "UclDateTimePickerUI2"
        Me.UclDateTimePickerUI2.Size = New System.Drawing.Size(101, 27)
        Me.UclDateTimePickerUI2.TabIndex = 30
        Me.UclDateTimePickerUI2.uclReadOnly = False
        '
        'UclDateTimePickerUI1
        '
        Me.UclDateTimePickerUI1.DisplayLocale = Syscom.Client.ucl.UCLDateTimePickerUC.Locale.US
        Me.UclDateTimePickerUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclDateTimePickerUI1.Location = New System.Drawing.Point(36, 193)
        Me.UclDateTimePickerUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclDateTimePickerUI1.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.UclDateTimePickerUI1.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UclDateTimePickerUI1.Name = "UclDateTimePickerUI1"
        Me.UclDateTimePickerUI1.Size = New System.Drawing.Size(109, 27)
        Me.UclDateTimePickerUI1.TabIndex = 0
        Me.UclDateTimePickerUI1.uclReadOnly = False
        '
        'UCLDateTimePickerUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 305)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UclDateTimePickerUI2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UclDateTimePickerUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLDateTimePickerUISample"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclDateTimePickerUI1 As Syscom.Client.ucl.UCLDateTimePickerUC
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents UclDateTimePickerUI2 As Syscom.Client.ucl.UCLDateTimePickerUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
