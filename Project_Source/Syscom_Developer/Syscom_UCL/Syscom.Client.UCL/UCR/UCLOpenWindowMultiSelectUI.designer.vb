<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLOpenWindowMultiSelectUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        mgr = Nothing
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Txt_QueryValue = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cbo_QueryField = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btn_Query = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_Ok = New System.Windows.Forms.Button
        Me.dgv1 = New UCLDataGridViewUC
        Me.dgv2 = New UCLDataGridViewUC
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_QueryValue
        '
        Me.Txt_QueryValue.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Txt_QueryValue.Location = New System.Drawing.Point(297, 7)
        Me.Txt_QueryValue.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_QueryValue.Name = "Txt_QueryValue"
        Me.Txt_QueryValue.Size = New System.Drawing.Size(206, 27)
        Me.Txt_QueryValue.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(26, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = " 查詢欄位"
        '
        'Cbo_QueryField
        '
        Me.Cbo_QueryField.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cbo_QueryField.FormattingEnabled = True
        Me.Cbo_QueryField.Location = New System.Drawing.Point(110, 7)
        Me.Cbo_QueryField.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbo_QueryField.Name = "Cbo_QueryField"
        Me.Cbo_QueryField.Size = New System.Drawing.Size(169, 24)
        Me.Cbo_QueryField.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 255)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(626, 245)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "已選項目"
        '
        'Btn_Query
        '
        Me.Btn_Query.Location = New System.Drawing.Point(520, 7)
        Me.Btn_Query.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Query.Name = "Btn_Query"
        Me.Btn_Query.Size = New System.Drawing.Size(100, 30)
        Me.Btn_Query.TabIndex = 3
        Me.Btn_Query.Text = "F1-查詢"
        Me.Btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(539, 508)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(100, 30)
        Me.btn_Cancel.TabIndex = 6
        Me.btn_Cancel.Text = "F5-取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(431, 508)
        Me.btn_Ok.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(100, 30)
        Me.btn_Ok.TabIndex = 7
        Me.btn_Ok.Text = "F12-確定"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToOrderColumns = True
        Me.dgv1.AllowUserToResizeColumns = True
        Me.dgv1.AllowUserToResizeRows = False
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv1.ColumnHeadersVisible = True
        Me.dgv1.CurrentCell = Nothing
        Me.dgv1.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv1.Location = New System.Drawing.Point(29, 45)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv1.MultiSelect = False
        Me.dgv1.MultiSelectType = UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv1.Name = "dgv1"
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(604, 202)
        Me.dgv1.TabIndex = 12
        Me.dgv1.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv1.uclBatchColIndex = ""
        Me.dgv1.uclClickToCheck = False
        Me.dgv1.uclColumnAlignment = ""
        Me.dgv1.uclColumnCheckBox = False
        Me.dgv1.uclColumnControlType = ""
        Me.dgv1.uclColumnWidth = ""
        Me.dgv1.uclDoCellEnter = True
        Me.dgv1.uclHasNewRow = False
        Me.dgv1.uclHeaderText = ""
        Me.dgv1.uclIsAlternatingRowsColors = True
        Me.dgv1.uclIsComboBoxGridQuery = True
        Me.dgv1.uclIsDoOrderCheck = True
        Me.dgv1.uclIsSortable = False
        Me.dgv1.uclNonVisibleColIndex = ""
        Me.dgv1.uclReadOnly = False
        Me.dgv1.uclShowCellBorder = False
        Me.dgv1.uclSortColIndex = ""
        Me.dgv1.uclTreeMode = False
        Me.dgv1.uclVisibleColIndex = ""
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToOrderColumns = True
        Me.dgv2.AllowUserToResizeColumns = True
        Me.dgv2.AllowUserToResizeRows = False
        Me.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv2.ColumnHeadersVisible = True
        Me.dgv2.CurrentCell = Nothing
        Me.dgv2.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv2.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv2.Location = New System.Drawing.Point(14, 25)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgv2.MultiSelect = True
        Me.dgv2.MultiSelectType = UCLDataGridViewUC.SelectType.DeleteAll
        Me.dgv2.Name = "dgv2"
        Me.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv2.Size = New System.Drawing.Size(604, 211)
        Me.dgv2.TabIndex = 5
        Me.dgv2.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv2.uclBatchColIndex = ""
        Me.dgv2.uclClickToCheck = False
        Me.dgv2.uclColumnAlignment = ""
        Me.dgv2.uclColumnCheckBox = True
        Me.dgv2.uclColumnControlType = ""
        Me.dgv2.uclColumnWidth = ""
        Me.dgv2.uclDoCellEnter = True
        Me.dgv2.uclHasNewRow = False
        Me.dgv2.uclHeaderText = ""
        Me.dgv2.uclIsAlternatingRowsColors = True
        Me.dgv2.uclIsComboBoxGridQuery = True
        Me.dgv2.uclIsDoOrderCheck = True
        Me.dgv2.uclIsSortable = False
        Me.dgv2.uclNonVisibleColIndex = ""
        Me.dgv2.uclReadOnly = False
        Me.dgv2.uclShowCellBorder = False
        Me.dgv2.uclSortColIndex = ""
        Me.dgv2.uclTreeMode = False
        Me.dgv2.uclVisibleColIndex = ""
        '
        'UCLOpenWindowMultiSelectUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 544)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Btn_Query)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Txt_QueryValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbo_QueryField)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "UCLOpenWindowMultiSelectUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "代碼檔查詢"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txt_QueryValue As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbo_QueryField As System.Windows.Forms.ComboBox
    Friend WithEvents dgv2 As UCLDataGridViewUC
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents dgv1 As UCLDataGridViewUC
End Class
