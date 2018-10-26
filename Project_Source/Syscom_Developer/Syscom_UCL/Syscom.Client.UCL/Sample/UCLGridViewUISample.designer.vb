<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLGridViewUISample
    '  Inherits System.Windows.Forms.Form
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.UclDataGridViewUI4 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclDataGridViewUI3 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclDataGridViewUI2 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclDataGridViewUI1 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1.  給一Dataset 並在GridView中顯示其內容", "2.  拖拉列交換", "3.  設定Column Header Text", "4.  設定Column Header Width", "5.  設定要隱藏的Column  ", "6.  固定顯示某些Column", "7.  設定可進行排序的Column", "8.  GridView Cell中加入UCL元件(單選)", "9.  GridView Cell中加入UCL元件(多選)", "10.  GridView多選設定"})
        Me.ComboBox1.Location = New System.Drawing.Point(18, 13)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(404, 24)
        Me.ComboBox1.TabIndex = 9
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 85)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(726, 180)
        Me.RichTextBox1.TabIndex = 10
        Me.RichTextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "程式碼參考"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(463, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(218, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "設另一個DataSet 到GridView"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'UclDataGridViewUI4
        '
        Me.UclDataGridViewUI4.AllowDrop = True
        Me.UclDataGridViewUI4.AllowUserToAddRows = False
        Me.UclDataGridViewUI4.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI4.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI4.AllowUserToResizeRows = True
        Me.UclDataGridViewUI4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI4.ColumnHeadersVisible = True
        Me.UclDataGridViewUI4.CurrentCell = Nothing
        Me.UclDataGridViewUI4.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI4.DefaultCellStyle = DataGridViewCellStyle1
        Me.UclDataGridViewUI4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI4.Location = New System.Drawing.Point(16, 268)
        Me.UclDataGridViewUI4.Margin = New System.Windows.Forms.Padding(32, 16, 32, 16)
        Me.UclDataGridViewUI4.MultiSelect = False
        Me.UclDataGridViewUI4.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI4.Name = "UclDataGridViewUI4"
        Me.UclDataGridViewUI4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI4.Size = New System.Drawing.Size(726, 185)
        Me.UclDataGridViewUI4.TabIndex = 14
        Me.UclDataGridViewUI4.uclColumnAlignment = ""
        Me.UclDataGridViewUI4.uclColumnCheckBox = False
        Me.UclDataGridViewUI4.uclColumnControlType = ""
        Me.UclDataGridViewUI4.uclColumnWidth = ""
        Me.UclDataGridViewUI4.uclHeaderText = ""
        Me.UclDataGridViewUI4.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI4.uclReadOnly = False
        Me.UclDataGridViewUI4.uclSortColIndex = ""
        Me.UclDataGridViewUI4.Visible = False
        '
        'UclDataGridViewUI3
        '
        Me.UclDataGridViewUI3.AllowDrop = True
        Me.UclDataGridViewUI3.AllowUserToAddRows = False
        Me.UclDataGridViewUI3.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI3.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI3.AllowUserToResizeRows = True
        Me.UclDataGridViewUI3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI3.ColumnHeadersVisible = True
        Me.UclDataGridViewUI3.CurrentCell = Nothing
        Me.UclDataGridViewUI3.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI3.DefaultCellStyle = DataGridViewCellStyle2
        Me.UclDataGridViewUI3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI3.Location = New System.Drawing.Point(18, 271)
        Me.UclDataGridViewUI3.Margin = New System.Windows.Forms.Padding(21, 12, 21, 12)
        Me.UclDataGridViewUI3.MultiSelect = False
        Me.UclDataGridViewUI3.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI3.Name = "UclDataGridViewUI3"
        Me.UclDataGridViewUI3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI3.Size = New System.Drawing.Size(726, 185)
        Me.UclDataGridViewUI3.TabIndex = 13
        Me.UclDataGridViewUI3.uclColumnAlignment = ""
        Me.UclDataGridViewUI3.uclColumnCheckBox = False
        Me.UclDataGridViewUI3.uclColumnControlType = ""
        Me.UclDataGridViewUI3.uclColumnWidth = ""
        Me.UclDataGridViewUI3.uclHeaderText = ""
        Me.UclDataGridViewUI3.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI3.uclReadOnly = False
        Me.UclDataGridViewUI3.uclSortColIndex = ""
        Me.UclDataGridViewUI3.Visible = False
        '
        'UclDataGridViewUI2
        '
        Me.UclDataGridViewUI2.AllowDrop = True
        Me.UclDataGridViewUI2.AllowUserToAddRows = False
        Me.UclDataGridViewUI2.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI2.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI2.AllowUserToResizeRows = True
        Me.UclDataGridViewUI2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI2.ColumnHeadersVisible = True
        Me.UclDataGridViewUI2.CurrentCell = Nothing
        Me.UclDataGridViewUI2.DataSource = Nothing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI2.DefaultCellStyle = DataGridViewCellStyle3
        Me.UclDataGridViewUI2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI2.Location = New System.Drawing.Point(13, 274)
        Me.UclDataGridViewUI2.Margin = New System.Windows.Forms.Padding(14, 9, 14, 9)
        Me.UclDataGridViewUI2.MultiSelect = False
        Me.UclDataGridViewUI2.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI2.Name = "UclDataGridViewUI2"
        Me.UclDataGridViewUI2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI2.Size = New System.Drawing.Size(726, 185)
        Me.UclDataGridViewUI2.TabIndex = 12
        Me.UclDataGridViewUI2.uclColumnAlignment = ""
        Me.UclDataGridViewUI2.uclColumnCheckBox = False
        Me.UclDataGridViewUI2.uclColumnControlType = ""
        Me.UclDataGridViewUI2.uclColumnWidth = ""
        Me.UclDataGridViewUI2.uclHeaderText = ""
        Me.UclDataGridViewUI2.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI2.uclReadOnly = False
        Me.UclDataGridViewUI2.uclSortColIndex = ""
        Me.UclDataGridViewUI2.Visible = False
        '
        'UclDataGridViewUI1
        '
        Me.UclDataGridViewUI1.AllowDrop = True
        Me.UclDataGridViewUI1.AllowUserToAddRows = False
        Me.UclDataGridViewUI1.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeRows = True
        Me.UclDataGridViewUI1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI1.ColumnHeadersVisible = True
        Me.UclDataGridViewUI1.CurrentCell = Nothing
        Me.UclDataGridViewUI1.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI1.DefaultCellStyle = DataGridViewCellStyle4
        Me.UclDataGridViewUI1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI1.Location = New System.Drawing.Point(18, 275)
        Me.UclDataGridViewUI1.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.UclDataGridViewUI1.MultiSelect = False
        Me.UclDataGridViewUI1.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI1.Name = "UclDataGridViewUI1"
        Me.UclDataGridViewUI1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI1.Size = New System.Drawing.Size(726, 185)
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
        'UCLGridViewUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 473)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UclDataGridViewUI4)
        Me.Controls.Add(Me.UclDataGridViewUI3)
        Me.Controls.Add(Me.UclDataGridViewUI2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.UclDataGridViewUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLGridViewUISample"
        Me.TabText = "UCLDataGridView使用範例"
        Me.Text = "UCLDataGridView使用範例"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclDataGridViewUI1 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UclDataGridViewUI2 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents UclDataGridViewUI3 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents UclDataGridViewUI4 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
