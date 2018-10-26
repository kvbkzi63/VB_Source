<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubOrderExamNoPrintDeptUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_O = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.dgv_E = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.dgv_I = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "門診"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "急診"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 317)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "住院"
        '
        'dgv_O
        '
        Me.dgv_O.AllowUserToAddRows = False
        Me.dgv_O.AllowUserToOrderColumns = False
        Me.dgv_O.AllowUserToResizeColumns = True
        Me.dgv_O.AllowUserToResizeRows = False
        Me.dgv_O.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_O.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_O.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_O.ColumnHeadersHeight = 4
        Me.dgv_O.ColumnHeadersVisible = True
        Me.dgv_O.CurrentCell = Nothing
        Me.dgv_O.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_O.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_O.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_O.Location = New System.Drawing.Point(18, 34)
        Me.dgv_O.MultiSelect = True
        Me.dgv_O.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_O.Name = "dgv_O"
        Me.dgv_O.RowHeadersWidth = 41
        Me.dgv_O.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_O.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_O.Size = New System.Drawing.Size(450, 120)
        Me.dgv_O.TabIndex = 0
        Me.dgv_O.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_O.uclBatchColIndex = ""
        Me.dgv_O.uclClickToCheck = False
        Me.dgv_O.uclColumnAlignment = ""
        Me.dgv_O.uclColumnCheckBox = True
        Me.dgv_O.uclColumnControlType = ""
        Me.dgv_O.uclColumnWidth = ""
        Me.dgv_O.uclDoCellEnter = True
        Me.dgv_O.uclHasNewRow = False
        Me.dgv_O.uclHeaderText = ""
        Me.dgv_O.uclIsAlternatingRowsColors = True
        Me.dgv_O.uclIsComboBoxGridQuery = True
        Me.dgv_O.uclIsComboxClickTriggerDropDown = False
        Me.dgv_O.uclIsDoOrderCheck = True
        Me.dgv_O.uclIsSortable = False
        Me.dgv_O.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_O.uclNonVisibleColIndex = ""
        Me.dgv_O.uclReadOnly = False
        Me.dgv_O.uclShowCellBorder = False
        Me.dgv_O.uclSortColIndex = ""
        Me.dgv_O.uclTreeMode = False
        Me.dgv_O.uclVisibleColIndex = ""
        '
        'dgv_E
        '
        Me.dgv_E.AllowUserToAddRows = False
        Me.dgv_E.AllowUserToOrderColumns = False
        Me.dgv_E.AllowUserToResizeColumns = True
        Me.dgv_E.AllowUserToResizeRows = False
        Me.dgv_E.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_E.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_E.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_E.ColumnHeadersHeight = 4
        Me.dgv_E.ColumnHeadersVisible = True
        Me.dgv_E.CurrentCell = Nothing
        Me.dgv_E.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_E.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_E.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_E.Location = New System.Drawing.Point(18, 188)
        Me.dgv_E.MultiSelect = True
        Me.dgv_E.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_E.Name = "dgv_E"
        Me.dgv_E.RowHeadersWidth = 41
        Me.dgv_E.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_E.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_E.Size = New System.Drawing.Size(450, 120)
        Me.dgv_E.TabIndex = 0
        Me.dgv_E.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_E.uclBatchColIndex = ""
        Me.dgv_E.uclClickToCheck = False
        Me.dgv_E.uclColumnAlignment = ""
        Me.dgv_E.uclColumnCheckBox = True
        Me.dgv_E.uclColumnControlType = ""
        Me.dgv_E.uclColumnWidth = ""
        Me.dgv_E.uclDoCellEnter = True
        Me.dgv_E.uclHasNewRow = False
        Me.dgv_E.uclHeaderText = ""
        Me.dgv_E.uclIsAlternatingRowsColors = True
        Me.dgv_E.uclIsComboBoxGridQuery = True
        Me.dgv_E.uclIsComboxClickTriggerDropDown = False
        Me.dgv_E.uclIsDoOrderCheck = True
        Me.dgv_E.uclIsSortable = False
        Me.dgv_E.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_E.uclNonVisibleColIndex = ""
        Me.dgv_E.uclReadOnly = False
        Me.dgv_E.uclShowCellBorder = False
        Me.dgv_E.uclSortColIndex = ""
        Me.dgv_E.uclTreeMode = False
        Me.dgv_E.uclVisibleColIndex = ""
        '
        'dgv_I
        '
        Me.dgv_I.AllowUserToAddRows = False
        Me.dgv_I.AllowUserToOrderColumns = False
        Me.dgv_I.AllowUserToResizeColumns = True
        Me.dgv_I.AllowUserToResizeRows = False
        Me.dgv_I.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_I.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_I.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_I.ColumnHeadersHeight = 4
        Me.dgv_I.ColumnHeadersVisible = True
        Me.dgv_I.CurrentCell = Nothing
        Me.dgv_I.DataSource = Nothing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_I.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_I.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_I.Location = New System.Drawing.Point(18, 342)
        Me.dgv_I.MultiSelect = True
        Me.dgv_I.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_I.Name = "dgv_I"
        Me.dgv_I.RowHeadersWidth = 41
        Me.dgv_I.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_I.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_I.Size = New System.Drawing.Size(450, 120)
        Me.dgv_I.TabIndex = 0
        Me.dgv_I.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_I.uclBatchColIndex = ""
        Me.dgv_I.uclClickToCheck = False
        Me.dgv_I.uclColumnAlignment = ""
        Me.dgv_I.uclColumnCheckBox = True
        Me.dgv_I.uclColumnControlType = ""
        Me.dgv_I.uclColumnWidth = ""
        Me.dgv_I.uclDoCellEnter = True
        Me.dgv_I.uclHasNewRow = False
        Me.dgv_I.uclHeaderText = ""
        Me.dgv_I.uclIsAlternatingRowsColors = True
        Me.dgv_I.uclIsComboBoxGridQuery = True
        Me.dgv_I.uclIsComboxClickTriggerDropDown = False
        Me.dgv_I.uclIsDoOrderCheck = True
        Me.dgv_I.uclIsSortable = False
        Me.dgv_I.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_I.uclNonVisibleColIndex = ""
        Me.dgv_I.uclReadOnly = False
        Me.dgv_I.uclShowCellBorder = False
        Me.dgv_I.uclSortColIndex = ""
        Me.dgv_I.uclTreeMode = False
        Me.dgv_I.uclVisibleColIndex = ""
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(356, 475)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(112, 31)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "儲存"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'PubOrderExamNoPrintDeptUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 511)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.dgv_I)
        Me.Controls.Add(Me.dgv_E)
        Me.Controls.Add(Me.dgv_O)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PubOrderExamNoPrintDeptUI"
        Me.TabText = "檢查醫令不須列印部門維護作業"
        Me.Text = "檢查醫令不須列印部門維護作業"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_O As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents dgv_E As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents dgv_I As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_Save As System.Windows.Forms.Button
End Class
