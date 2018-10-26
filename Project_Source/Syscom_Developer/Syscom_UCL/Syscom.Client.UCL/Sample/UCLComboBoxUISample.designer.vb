<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLComboBoxUISample
    ' Inherits System.Windows.Forms.Form
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCLComboBoxUISample))
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.UclComboBoxUI1 = New Syscom.Client.ucl.UCLComboBoxUC
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(293, 71)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "設定ＣomboBox 資料"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ComboBox 使用說明"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(429, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "屬性與方法設定請參考UCL共用元件使用說明.doc 第7項元件"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(29, 120)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(637, 139)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(520, 71)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 27)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Get Selected Code"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UclComboBoxUI1
        '
        Me.UclComboBoxUI1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclComboBoxUI1.DropDownWidth = 20
        Me.UclComboBoxUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclComboBoxUI1.Location = New System.Drawing.Point(29, 78)
        Me.UclComboBoxUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclComboBoxUI1.Name = "UclComboBoxUI1"
        Me.UclComboBoxUI1.SelectedIndex = -1
        Me.UclComboBoxUI1.SelectedItem = Nothing
        Me.UclComboBoxUI1.SelectedText = ""
        Me.UclComboBoxUI1.SelectedValue = ""
        Me.UclComboBoxUI1.SelectionStart = 0
        Me.UclComboBoxUI1.Size = New System.Drawing.Size(230, 24)
        Me.UclComboBoxUI1.TabIndex = 0
        Me.UclComboBoxUI1.uclDisplayIndex = "0,1"
        Me.UclComboBoxUI1.uclShowMsg = False
        Me.UclComboBoxUI1.uclValueIndex = "0"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(520, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(147, 30)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'UCLComboBoxUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 280)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UclComboBoxUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLComboBoxUISample"
        Me.TabText = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclComboBoxUI1 As Syscom.Client.ucl.UCLComboBoxUC
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
