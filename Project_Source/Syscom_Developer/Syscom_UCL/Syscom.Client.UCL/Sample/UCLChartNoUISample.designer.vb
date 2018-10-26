<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLChartNoUISample
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.UclChartNoUI2 = New Syscom.Client.ucl.UCLChartNoUI
        Me.UclChartNoUI1 = New Syscom.Client.ucl.UCLChartNoUI
        Me.UclDataGridViewUI1 = New Syscom.Client.ucl.UCLDataGridViewUI
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 73)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "chartNo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(321, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "UclDataGridViewUI1.Initial(pvtPatient.PatientDS)"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(15, 268)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(905, 192)
        Me.RichTextBox1.TabIndex = 12
        Me.RichTextBox1.Text = "     "
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(358, 55)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 42)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "設定ChartNo 進行Query"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(245, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(236, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "顯示查詢到的病患相關資料"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(292, 103)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "取得ChartNo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(245, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 41)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "設定ChartNo 但不進行 Query"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "病歷號元件使用說明"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(242, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(429, 16)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "屬性與方法設定請參考UCL共用元件使用說明.doc 第4項元件"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "IdNo"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(710, 56)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 41)
        Me.Button5.TabIndex = 29
        Me.Button5.Text = "設定IdNo 但不進行 Query"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(823, 55)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 42)
        Me.Button6.TabIndex = 28
        Me.Button6.Text = "設定IdNo 進行Query"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(697, 132)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(236, 23)
        Me.Button7.TabIndex = 30
        Me.Button7.Text = "顯示查詢到的病患相關資料"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(743, 103)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(138, 23)
        Me.Button8.TabIndex = 31
        Me.Button8.Text = "取得IdNo"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(289, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(336, 16)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "只要TextChanged And Leave 元件就會進行Query"
        '
        'UclChartNoUI2
        '
        Me.UclChartNoUI2.doFlag = False
        Me.UclChartNoUI2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclChartNoUI2.Location = New System.Drawing.Point(562, 70)
        Me.UclChartNoUI2.Margin = New System.Windows.Forms.Padding(4)
        Me.UclChartNoUI2.Name = "UclChartNoUI2"
        Me.UclChartNoUI2.Size = New System.Drawing.Size(140, 27)
        Me.UclChartNoUI2.TabIndex = 25
        Me.UclChartNoUI2.uclDigitCount = 8
        Me.UclChartNoUI2.uclNeedCheckId = True
        Me.UclChartNoUI2.uclNeedSql = True
        Me.UclChartNoUI2.uclReadOnly = False
        Me.UclChartNoUI2.uclTextType = Syscom.Client.ucl.UCLChartNoUI.uclTextTypeData.IdNo
        Me.UclChartNoUI2.uclTxtBoxWidth = 140
        '
        'UclChartNoUI1
        '
        Me.UclChartNoUI1.doFlag = False
        Me.UclChartNoUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclChartNoUI1.Location = New System.Drawing.Point(96, 70)
        Me.UclChartNoUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclChartNoUI1.Name = "UclChartNoUI1"
        Me.UclChartNoUI1.Size = New System.Drawing.Size(140, 27)
        Me.UclChartNoUI1.TabIndex = 15
        Me.UclChartNoUI1.uclDigitCount = 8
        Me.UclChartNoUI1.uclNeedCheckId = True
        Me.UclChartNoUI1.uclNeedSql = True
        Me.UclChartNoUI1.uclReadOnly = False
        Me.UclChartNoUI1.uclTextType = Syscom.Client.ucl.UCLChartNoUI.uclTextTypeData.ChartNo
        Me.UclChartNoUI1.uclTxtBoxWidth = 140
        '
        'UclDataGridViewUI1
        '
        Me.UclDataGridViewUI1.AllowDrop = True
        Me.UclDataGridViewUI1.AllowUserToAddRows = False
        Me.UclDataGridViewUI1.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeRows = True
        Me.UclDataGridViewUI1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI1.CurrentCell = Nothing
        Me.UclDataGridViewUI1.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI1.DefaultCellStyle = DataGridViewCellStyle1
        Me.UclDataGridViewUI1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI1.Location = New System.Drawing.Point(15, 192)
        Me.UclDataGridViewUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclDataGridViewUI1.MultiSelect = False
        Me.UclDataGridViewUI1.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUI.SelectType.SelectAll
        Me.UclDataGridViewUI1.Name = "UclDataGridViewUI1"
        Me.UclDataGridViewUI1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI1.Size = New System.Drawing.Size(905, 68)
        Me.UclDataGridViewUI1.TabIndex = 8
        Me.UclDataGridViewUI1.uclColumnAlignment = ""
        Me.UclDataGridViewUI1.uclColumnCheckBox = False
        Me.UclDataGridViewUI1.uclColumnControlType = ""
        Me.UclDataGridViewUI1.uclColumnWidth = ""
        Me.UclDataGridViewUI1.uclHeaderText = ""
        Me.UclDataGridViewUI1.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI1.uclReadOnly = False
        Me.UclDataGridViewUI1.uclSortColIndex = ""
        '
        'UCLChartNoUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 474)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UclChartNoUI2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.UclChartNoUI1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UclDataGridViewUI1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLChartNoUISample"
        Me.Text = "Form7"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UclDataGridViewUI1 As Syscom.Client.ucl.UCLDataGridViewUI
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UclChartNoUI1 As Syscom.Client.ucl.UCLChartNoUI
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UclChartNoUI2 As Syscom.Client.ucl.UCLChartNoUI
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
