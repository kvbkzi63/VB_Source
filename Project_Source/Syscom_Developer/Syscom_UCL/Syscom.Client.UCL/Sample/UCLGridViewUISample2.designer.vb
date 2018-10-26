<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLGridViewUISample2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.UclDataGridViewUI3 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclDataGridViewUI2 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclDataGridViewUI1 = New Syscom.Client.ucl.UCLDataGridViewUC
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(37, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(346, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(37, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 52)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Load Dataset1 By Ref"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(201, 217)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 55)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "操作Dataset1  少1Row 會影響GridView"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(439, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "UCL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "一般"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(37, 337)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 52)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Load Dataset2 By Copy"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(201, 337)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(182, 51)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "操作Dataset2  少1Row 不會影響GridView"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(37, 442)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(346, 27)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "ClearDS (請注意會把原先傳進去的DS清空)"
        Me.Button5.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI3.DefaultCellStyle = DataGridViewCellStyle1
        Me.UclDataGridViewUI3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI3.Location = New System.Drawing.Point(442, 383)
        Me.UclDataGridViewUI3.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.UclDataGridViewUI3.MultiSelect = False
        Me.UclDataGridViewUI3.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI3.Name = "UclDataGridViewUI3"
        Me.UclDataGridViewUI3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI3.Size = New System.Drawing.Size(352, 159)
        Me.UclDataGridViewUI3.TabIndex = 7
        Me.UclDataGridViewUI3.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.UclDataGridViewUI3.uclBatchColIndex = ""
        Me.UclDataGridViewUI3.uclClickToCheck = False
        Me.UclDataGridViewUI3.uclColumnAlignment = ""
        Me.UclDataGridViewUI3.uclColumnCheckBox = False
        Me.UclDataGridViewUI3.uclColumnControlType = ""
        Me.UclDataGridViewUI3.uclColumnWidth = ""
        Me.UclDataGridViewUI3.uclDoCellEnter = True
        Me.UclDataGridViewUI3.uclHasNewRow = False
        Me.UclDataGridViewUI3.uclHeaderText = ""
        Me.UclDataGridViewUI3.uclIsAlternatingRowsColors = True
        Me.UclDataGridViewUI3.uclIsComboBoxGridQuery = True
        Me.UclDataGridViewUI3.uclIsDoOrderCheck = True
        Me.UclDataGridViewUI3.uclIsSortable = False
        Me.UclDataGridViewUI3.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI3.uclReadOnly = False
        Me.UclDataGridViewUI3.uclShowCellBorder = False
        Me.UclDataGridViewUI3.uclSortColIndex = ""
        Me.UclDataGridViewUI3.uclTreeMode = False
        Me.UclDataGridViewUI3.uclVisibleColIndex = ""
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI2.DefaultCellStyle = DataGridViewCellStyle2
        Me.UclDataGridViewUI2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI2.Location = New System.Drawing.Point(442, 217)
        Me.UclDataGridViewUI2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclDataGridViewUI2.MultiSelect = True
        Me.UclDataGridViewUI2.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI2.Name = "UclDataGridViewUI2"
        Me.UclDataGridViewUI2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI2.Size = New System.Drawing.Size(352, 141)
        Me.UclDataGridViewUI2.TabIndex = 6
        Me.UclDataGridViewUI2.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.UclDataGridViewUI2.uclBatchColIndex = ""
        Me.UclDataGridViewUI2.uclClickToCheck = False
        Me.UclDataGridViewUI2.uclColumnAlignment = ""
        Me.UclDataGridViewUI2.uclColumnCheckBox = True
        Me.UclDataGridViewUI2.uclColumnControlType = ""
        Me.UclDataGridViewUI2.uclColumnWidth = ""
        Me.UclDataGridViewUI2.uclDoCellEnter = True
        Me.UclDataGridViewUI2.uclHasNewRow = False
        Me.UclDataGridViewUI2.uclHeaderText = ""
        Me.UclDataGridViewUI2.uclIsAlternatingRowsColors = True
        Me.UclDataGridViewUI2.uclIsComboBoxGridQuery = True
        Me.UclDataGridViewUI2.uclIsDoOrderCheck = True
        Me.UclDataGridViewUI2.uclIsSortable = False
        Me.UclDataGridViewUI2.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI2.uclReadOnly = False
        Me.UclDataGridViewUI2.uclShowCellBorder = False
        Me.UclDataGridViewUI2.uclSortColIndex = ""
        Me.UclDataGridViewUI2.uclTreeMode = False
        Me.UclDataGridViewUI2.uclVisibleColIndex = ""
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI1.DefaultCellStyle = DataGridViewCellStyle3
        Me.UclDataGridViewUI1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI1.Location = New System.Drawing.Point(442, 47)
        Me.UclDataGridViewUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclDataGridViewUI1.MultiSelect = False
        Me.UclDataGridViewUI1.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI1.Name = "UclDataGridViewUI1"
        Me.UclDataGridViewUI1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI1.Size = New System.Drawing.Size(352, 150)
        Me.UclDataGridViewUI1.TabIndex = 3
        Me.UclDataGridViewUI1.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.UclDataGridViewUI1.uclBatchColIndex = ""
        Me.UclDataGridViewUI1.uclClickToCheck = False
        Me.UclDataGridViewUI1.uclColumnAlignment = ""
        Me.UclDataGridViewUI1.uclColumnCheckBox = False
        Me.UclDataGridViewUI1.uclColumnControlType = ""
        Me.UclDataGridViewUI1.uclColumnWidth = ""
        Me.UclDataGridViewUI1.uclDoCellEnter = True
        Me.UclDataGridViewUI1.uclHasNewRow = False
        Me.UclDataGridViewUI1.uclHeaderText = ""
        Me.UclDataGridViewUI1.uclIsAlternatingRowsColors = True
        Me.UclDataGridViewUI1.uclIsComboBoxGridQuery = True
        Me.UclDataGridViewUI1.uclIsDoOrderCheck = True
        Me.UclDataGridViewUI1.uclIsSortable = False
        Me.UclDataGridViewUI1.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI1.uclReadOnly = False
        Me.UclDataGridViewUI1.uclShowCellBorder = False
        Me.UclDataGridViewUI1.uclSortColIndex = ""
        Me.UclDataGridViewUI1.uclTreeMode = False
        Me.UclDataGridViewUI1.uclVisibleColIndex = ""
        '
        'UCLGridViewUISample2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 569)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.UclDataGridViewUI3)
        Me.Controls.Add(Me.UclDataGridViewUI2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UclDataGridViewUI1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLGridViewUISample2"
        Me.Text = "Form5"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UclDataGridViewUI1 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UclDataGridViewUI2 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents UclDataGridViewUI3 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
