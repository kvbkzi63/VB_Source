<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAddOrderDetailUI
    'Inherits System.Windows.Forms.Form
    Inherits Syscom.Client.UCL.BaseFormUI

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveComboBoxGridMgr = Nothing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBAddOrderDetailUI))
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.gb_grid = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_dgv_content = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.btn_addrow = New System.Windows.Forms.Button()
        Me.gb_condition = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_group_order = New System.Windows.Forms.Label()
        Me.ucl_txt_group_order = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_combo_group_mark = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_group_mark = New System.Windows.Forms.Label()
        Me.lb_group_name = New System.Windows.Forms.Label()
        Me.txt_group_name = New System.Windows.Forms.TextBox()
        Me.tlp_parent.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_grid.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.gb_condition.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 1
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_parent.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.tlp_parent.Controls.Add(Me.gb_grid, 0, 1)
        Me.tlp_parent.Controls.Add(Me.gb_condition, 0, 0)
        Me.tlp_parent.Location = New System.Drawing.Point(3, 3)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 3
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.82552!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.17448!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(1010, 642)
        Me.tlp_parent.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_addrow)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 585)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1004, 54)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_clear.Location = New System.Drawing.Point(902, 3)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 3, 6, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_clear.TabIndex = 1
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        Me.btn_clear.Visible = False
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(891, 3)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(96, 27)
        Me.btn_confirm.TabIndex = 0
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'gb_grid
        '
        Me.gb_grid.Controls.Add(Me.TableLayoutPanel3)
        Me.gb_grid.Location = New System.Drawing.Point(3, 124)
        Me.gb_grid.Name = "gb_grid"
        Me.gb_grid.Size = New System.Drawing.Size(1004, 453)
        Me.gb_grid.TabIndex = 1
        Me.gb_grid.TabStop = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ucl_dgv_content, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 15)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.70918!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.29083!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(996, 438)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'ucl_dgv_content
        '
        Me.ucl_dgv_content.AllowUserToAddRows = False
        Me.ucl_dgv_content.AllowUserToOrderColumns = False
        Me.ucl_dgv_content.AllowUserToResizeColumns = True
        Me.ucl_dgv_content.AllowUserToResizeRows = False
        Me.ucl_dgv_content.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.ucl_dgv_content.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ucl_dgv_content.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ucl_dgv_content.ColumnHeadersHeight = 4
        Me.ucl_dgv_content.ColumnHeadersVisible = True
        Me.ucl_dgv_content.CurrentCell = Nothing
        Me.ucl_dgv_content.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_content.DefaultCellStyle = DataGridViewCellStyle2
        Me.ucl_dgv_content.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_content.Location = New System.Drawing.Point(4, 4)
        Me.ucl_dgv_content.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_content.MultiSelect = True
        Me.ucl_dgv_content.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_content.Name = "ucl_dgv_content"
        Me.ucl_dgv_content.RowHeadersWidth = 41
        Me.ucl_dgv_content.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucl_dgv_content.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_content.Size = New System.Drawing.Size(988, 384)
        Me.ucl_dgv_content.TabIndex = 0
        Me.ucl_dgv_content.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucl_dgv_content.uclBatchColIndex = ""
        Me.ucl_dgv_content.uclClickToCheck = False
        Me.ucl_dgv_content.uclColumnAlignment = ""
        Me.ucl_dgv_content.uclColumnCheckBox = True
        Me.ucl_dgv_content.uclColumnControlType = ""
        Me.ucl_dgv_content.uclColumnWidth = ""
        Me.ucl_dgv_content.uclDoCellEnter = True
        Me.ucl_dgv_content.uclHasNewRow = False
        Me.ucl_dgv_content.uclHeaderText = ""
        Me.ucl_dgv_content.uclIsAlternatingRowsColors = True
        Me.ucl_dgv_content.uclIsComboBoxGridQuery = True
        Me.ucl_dgv_content.uclIsComboxClickTriggerDropDown = False
        Me.ucl_dgv_content.uclIsDoOrderCheck = True
        Me.ucl_dgv_content.uclIsSortable = False
        Me.ucl_dgv_content.uclMultiSelectShowCheckBoxHeader = True
        Me.ucl_dgv_content.uclNonVisibleColIndex = ""
        Me.ucl_dgv_content.uclReadOnly = False
        Me.ucl_dgv_content.uclShowCellBorder = False
        Me.ucl_dgv_content.uclSortColIndex = ""
        Me.ucl_dgv_content.uclTreeMode = False
        Me.ucl_dgv_content.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_confirm)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_delete)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 395)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(990, 40)
        Me.FlowLayoutPanel2.TabIndex = 3
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_delete.Location = New System.Drawing.Point(792, 3)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(96, 27)
        Me.btn_delete.TabIndex = 5
        Me.btn_delete.Text = "刪除醫令"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_addrow
        '
        Me.btn_addrow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_addrow.Location = New System.Drawing.Point(800, 3)
        Me.btn_addrow.Name = "btn_addrow"
        Me.btn_addrow.Size = New System.Drawing.Size(96, 27)
        Me.btn_addrow.TabIndex = 6
        Me.btn_addrow.Text = "新增醫令"
        Me.btn_addrow.UseVisualStyleBackColor = True
        Me.btn_addrow.Visible = False
        '
        'gb_condition
        '
        Me.gb_condition.Controls.Add(Me.TableLayoutPanel1)
        Me.gb_condition.Location = New System.Drawing.Point(3, 3)
        Me.gb_condition.Name = "gb_condition"
        Me.gb_condition.Size = New System.Drawing.Size(1004, 104)
        Me.gb_condition.TabIndex = 0
        Me.gb_condition.TabStop = False
        Me.gb_condition.Text = "查詢條件"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 474.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lb_group_order, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_txt_group_order, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_combo_group_mark, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lb_group_mark, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lb_group_name, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_group_name, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(992, 79)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lb_group_order
        '
        Me.lb_group_order.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_group_order.AutoSize = True
        Me.lb_group_order.Location = New System.Drawing.Point(53, 11)
        Me.lb_group_order.Name = "lb_group_order"
        Me.lb_group_order.Size = New System.Drawing.Size(56, 16)
        Me.lb_group_order.TabIndex = 0
        Me.lb_group_order.Text = "群組碼"
        '
        'ucl_txt_group_order
        '
        Me.ucl_txt_group_order.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_group_order.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_group_order.Location = New System.Drawing.Point(115, 6)
        Me.ucl_txt_group_order.MaxLength = 10
        Me.ucl_txt_group_order.Name = "ucl_txt_group_order"
        Me.ucl_txt_group_order.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_group_order.SelectionStart = 0
        Me.ucl_txt_group_order.Size = New System.Drawing.Size(122, 27)
        Me.ucl_txt_group_order.TabIndex = 1
        Me.ucl_txt_group_order.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_group_order.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_group_order.ToolTipTag = Nothing
        Me.ucl_txt_group_order.uclDollarSign = False
        Me.ucl_txt_group_order.uclDotCount = 0
        Me.ucl_txt_group_order.uclIntCount = 2
        Me.ucl_txt_group_order.uclMinus = False
        Me.ucl_txt_group_order.uclReadOnly = False
        Me.ucl_txt_group_order.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_group_order.uclTrimZero = True
        '
        'ucl_combo_group_mark
        '
        Me.ucl_combo_group_mark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_combo_group_mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_combo_group_mark.DropDownWidth = 20
        Me.ucl_combo_group_mark.DroppedDown = False
        Me.ucl_combo_group_mark.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_combo_group_mark.Location = New System.Drawing.Point(329, 7)
        Me.ucl_combo_group_mark.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_combo_group_mark.Name = "ucl_combo_group_mark"
        Me.ucl_combo_group_mark.SelectedIndex = -1
        Me.ucl_combo_group_mark.SelectedItem = Nothing
        Me.ucl_combo_group_mark.SelectedText = ""
        Me.ucl_combo_group_mark.SelectedValue = ""
        Me.ucl_combo_group_mark.SelectionStart = 0
        Me.ucl_combo_group_mark.Size = New System.Drawing.Size(144, 24)
        Me.ucl_combo_group_mark.TabIndex = 2
        Me.ucl_combo_group_mark.uclDisplayIndex = "0,1"
        Me.ucl_combo_group_mark.uclIsAutoClear = True
        Me.ucl_combo_group_mark.uclIsFirstItemEmpty = True
        Me.ucl_combo_group_mark.uclIsTextMode = False
        Me.ucl_combo_group_mark.uclShowMsg = False
        Me.ucl_combo_group_mark.uclValueIndex = "0"
        '
        'lb_group_mark
        '
        Me.lb_group_mark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_group_mark.AutoSize = True
        Me.lb_group_mark.Location = New System.Drawing.Point(254, 11)
        Me.lb_group_mark.Name = "lb_group_mark"
        Me.lb_group_mark.Size = New System.Drawing.Size(72, 16)
        Me.lb_group_mark.TabIndex = 3
        Me.lb_group_mark.Text = "群組註記"
        '
        'lb_group_name
        '
        Me.lb_group_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_group_name.AutoSize = True
        Me.lb_group_name.Location = New System.Drawing.Point(37, 51)
        Me.lb_group_name.Name = "lb_group_name"
        Me.lb_group_name.Size = New System.Drawing.Size(72, 16)
        Me.lb_group_name.TabIndex = 4
        Me.lb_group_name.Text = "群組名稱"
        '
        'txt_group_name
        '
        Me.txt_group_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_group_name, 4)
        Me.txt_group_name.Location = New System.Drawing.Point(115, 45)
        Me.txt_group_name.Name = "txt_group_name"
        Me.txt_group_name.Size = New System.Drawing.Size(871, 27)
        Me.txt_group_name.TabIndex = 5
        '
        'PUBAddOrderDetailUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 646)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBAddOrderDetailUI"
        Me.TabText = "群組醫令維護"
        Me.Text = "群組醫令維護"
        Me.tlp_parent.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.gb_grid.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.gb_condition.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_condition As System.Windows.Forms.GroupBox
    Friend WithEvents gb_grid As System.Windows.Forms.GroupBox
    Friend WithEvents ucl_dgv_content As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_group_order As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_group_order As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_combo_group_mark As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_group_mark As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents lb_group_name As System.Windows.Forms.Label
    Friend WithEvents txt_group_name As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_addrow As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
End Class
