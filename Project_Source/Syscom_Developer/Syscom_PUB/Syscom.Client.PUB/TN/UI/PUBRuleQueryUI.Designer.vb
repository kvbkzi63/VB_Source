<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleQueryUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRuleQueryUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_corr_rule = New System.Windows.Forms.GroupBox()
        Me.tv_corr_condition = New System.Windows.Forms.TreeView()
        Me.lb_rulebelong_item = New System.Windows.Forms.Label()
        Me.ucl_comb_belongitem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_initcondition = New System.Windows.Forms.Label()
        Me.lb_selectednode = New System.Windows.Forms.Label()
        Me.ucl_txt_clickmsg = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.tlp_condvalue = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_txt_initcond = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_doctor = New System.Windows.Forms.Button()
        Me.tlp_condcheck = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_showinperiod = New System.Windows.Forms.CheckBox()
        Me.cb_showrelated = New System.Windows.Forms.CheckBox()
        Me.tlp_grid = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_dgv_checkcond = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_addremove = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_remove = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.tlp_btn = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tlp_parent.SuspendLayout()
        Me.gb_corr_rule.SuspendLayout()
        Me.tlp_condvalue.SuspendLayout()
        Me.tlp_condcheck.SuspendLayout()
        Me.tlp_grid.SuspendLayout()
        Me.tlp_addremove.SuspendLayout()
        Me.tlp_btn.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 2
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Controls.Add(Me.gb_corr_rule, 0, 6)
        Me.tlp_parent.Controls.Add(Me.lb_rulebelong_item, 0, 0)
        Me.tlp_parent.Controls.Add(Me.ucl_comb_belongitem, 1, 0)
        Me.tlp_parent.Controls.Add(Me.lb_initcondition, 0, 1)
        Me.tlp_parent.Controls.Add(Me.lb_selectednode, 0, 2)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_clickmsg, 1, 2)
        Me.tlp_parent.Controls.Add(Me.tlp_condvalue, 1, 1)
        Me.tlp_parent.Controls.Add(Me.tlp_condcheck, 0, 3)
        Me.tlp_parent.Controls.Add(Me.tlp_grid, 0, 4)
        Me.tlp_parent.Controls.Add(Me.tlp_btn, 0, 5)
        Me.tlp_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_parent.Location = New System.Drawing.Point(0, 0)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 7
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(367, 427)
        Me.tlp_parent.TabIndex = 0
        '
        'gb_corr_rule
        '
        Me.tlp_parent.SetColumnSpan(Me.gb_corr_rule, 2)
        Me.gb_corr_rule.Controls.Add(Me.tv_corr_condition)
        Me.gb_corr_rule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_corr_rule.Location = New System.Drawing.Point(0, 200)
        Me.gb_corr_rule.Margin = New System.Windows.Forms.Padding(0)
        Me.gb_corr_rule.Name = "gb_corr_rule"
        Me.gb_corr_rule.Size = New System.Drawing.Size(367, 227)
        Me.gb_corr_rule.TabIndex = 0
        Me.gb_corr_rule.TabStop = False
        Me.gb_corr_rule.Text = "符合查詢條件規則"
        '
        'tv_corr_condition
        '
        Me.tv_corr_condition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_corr_condition.Location = New System.Drawing.Point(3, 23)
        Me.tv_corr_condition.Margin = New System.Windows.Forms.Padding(0)
        Me.tv_corr_condition.Name = "tv_corr_condition"
        Me.tv_corr_condition.Size = New System.Drawing.Size(361, 201)
        Me.tv_corr_condition.TabIndex = 0
        '
        'lb_rulebelong_item
        '
        Me.lb_rulebelong_item.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_rulebelong_item.AutoSize = True
        Me.lb_rulebelong_item.ForeColor = System.Drawing.Color.Red
        Me.lb_rulebelong_item.Location = New System.Drawing.Point(3, 9)
        Me.lb_rulebelong_item.Name = "lb_rulebelong_item"
        Me.lb_rulebelong_item.Size = New System.Drawing.Size(72, 16)
        Me.lb_rulebelong_item.TabIndex = 2
        Me.lb_rulebelong_item.Text = "觸發規則"
        '
        'ucl_comb_belongitem
        '
        Me.ucl_comb_belongitem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_belongitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_belongitem.DropDownWidth = 20
        Me.ucl_comb_belongitem.DroppedDown = False
        Me.ucl_comb_belongitem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_belongitem.Location = New System.Drawing.Point(100, 5)
        Me.ucl_comb_belongitem.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_belongitem.Name = "ucl_comb_belongitem"
        Me.ucl_comb_belongitem.SelectedIndex = -1
        Me.ucl_comb_belongitem.SelectedItem = Nothing
        Me.ucl_comb_belongitem.SelectedText = ""
        Me.ucl_comb_belongitem.SelectedValue = ""
        Me.ucl_comb_belongitem.SelectionStart = 0
        Me.ucl_comb_belongitem.Size = New System.Drawing.Size(160, 24)
        Me.ucl_comb_belongitem.TabIndex = 6
        Me.ucl_comb_belongitem.uclDisplayIndex = "0,1"
        Me.ucl_comb_belongitem.uclIsAutoClear = True
        Me.ucl_comb_belongitem.uclIsFirstItemEmpty = True
        Me.ucl_comb_belongitem.uclIsTextMode = False
        Me.ucl_comb_belongitem.uclShowMsg = False
        Me.ucl_comb_belongitem.uclValueIndex = "0"
        '
        'lb_initcondition
        '
        Me.lb_initcondition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_initcondition.AutoSize = True
        Me.lb_initcondition.Location = New System.Drawing.Point(3, 57)
        Me.lb_initcondition.Name = "lb_initcondition"
        Me.lb_initcondition.Size = New System.Drawing.Size(88, 16)
        Me.lb_initcondition.TabIndex = 3
        Me.lb_initcondition.Text = "起始條件值"
        '
        'lb_selectednode
        '
        Me.lb_selectednode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_selectednode.AutoSize = True
        Me.lb_selectednode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lb_selectednode.Location = New System.Drawing.Point(3, 104)
        Me.lb_selectednode.Name = "lb_selectednode"
        Me.lb_selectednode.Size = New System.Drawing.Size(85, 16)
        Me.lb_selectednode.TabIndex = 16
        Me.lb_selectednode.Text = "*點選規則"
        '
        'ucl_txt_clickmsg
        '
        Me.ucl_txt_clickmsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_clickmsg.Enabled = False
        Me.ucl_txt_clickmsg.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_txt_clickmsg.Location = New System.Drawing.Point(100, 99)
        Me.ucl_txt_clickmsg.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_clickmsg.MaxLength = 100
        Me.ucl_txt_clickmsg.Name = "ucl_txt_clickmsg"
        Me.ucl_txt_clickmsg.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_clickmsg.SelectionStart = 0
        Me.ucl_txt_clickmsg.Size = New System.Drawing.Size(264, 27)
        Me.ucl_txt_clickmsg.TabIndex = 15
        Me.ucl_txt_clickmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_clickmsg.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_clickmsg.ToolTipTag = Nothing
        Me.ucl_txt_clickmsg.uclDollarSign = False
        Me.ucl_txt_clickmsg.uclDotCount = 0
        Me.ucl_txt_clickmsg.uclIntCount = 2
        Me.ucl_txt_clickmsg.uclMinus = False
        Me.ucl_txt_clickmsg.uclReadOnly = False
        Me.ucl_txt_clickmsg.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_clickmsg.uclTrimZero = True
        '
        'tlp_condvalue
        '
        Me.tlp_condvalue.ColumnCount = 2
        Me.tlp_condvalue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212.0!))
        Me.tlp_condvalue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.tlp_condvalue.Controls.Add(Me.ucl_txt_initcond, 0, 0)
        Me.tlp_condvalue.Controls.Add(Me.btn_doctor, 1, 0)
        Me.tlp_condvalue.Controls.Add(Me.lblName, 0, 1)
        Me.tlp_condvalue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_condvalue.Location = New System.Drawing.Point(100, 35)
        Me.tlp_condvalue.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_condvalue.Name = "tlp_condvalue"
        Me.tlp_condvalue.RowCount = 2
        Me.tlp_condvalue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_condvalue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_condvalue.Size = New System.Drawing.Size(267, 60)
        Me.tlp_condvalue.TabIndex = 19
        '
        'ucl_txt_initcond
        '
        Me.ucl_txt_initcond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_initcond.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_initcond.Location = New System.Drawing.Point(0, 1)
        Me.ucl_txt_initcond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_initcond.MaxLength = 500
        Me.ucl_txt_initcond.Name = "ucl_txt_initcond"
        Me.ucl_txt_initcond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_initcond.SelectionStart = 0
        Me.ucl_txt_initcond.Size = New System.Drawing.Size(212, 28)
        Me.ucl_txt_initcond.TabIndex = 7
        Me.ucl_txt_initcond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_initcond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_initcond.ToolTipTag = Nothing
        Me.ucl_txt_initcond.uclDollarSign = False
        Me.ucl_txt_initcond.uclDotCount = 0
        Me.ucl_txt_initcond.uclIntCount = 2
        Me.ucl_txt_initcond.uclMinus = False
        Me.ucl_txt_initcond.uclReadOnly = False
        Me.ucl_txt_initcond.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_initcond.uclTrimZero = True
        '
        'btn_doctor
        '
        Me.btn_doctor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_doctor.Location = New System.Drawing.Point(212, 1)
        Me.btn_doctor.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_doctor.Name = "btn_doctor"
        Me.btn_doctor.Size = New System.Drawing.Size(31, 28)
        Me.btn_doctor.TabIndex = 8
        Me.btn_doctor.Text = "..."
        Me.btn_doctor.UseVisualStyleBackColor = True
        '
        'tlp_condcheck
        '
        Me.tlp_condcheck.ColumnCount = 2
        Me.tlp_parent.SetColumnSpan(Me.tlp_condcheck, 2)
        Me.tlp_condcheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.tlp_condcheck.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_condcheck.Controls.Add(Me.cb_showinperiod, 0, 0)
        Me.tlp_condcheck.Controls.Add(Me.cb_showrelated, 1, 0)
        Me.tlp_condcheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_condcheck.Location = New System.Drawing.Point(0, 130)
        Me.tlp_condcheck.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_condcheck.Name = "tlp_condcheck"
        Me.tlp_condcheck.RowCount = 1
        Me.tlp_condcheck.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_condcheck.Size = New System.Drawing.Size(367, 35)
        Me.tlp_condcheck.TabIndex = 21
        '
        'cb_showinperiod
        '
        Me.cb_showinperiod.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_showinperiod.AutoSize = True
        Me.cb_showinperiod.Location = New System.Drawing.Point(3, 7)
        Me.cb_showinperiod.Name = "cb_showinperiod"
        Me.cb_showinperiod.Size = New System.Drawing.Size(107, 20)
        Me.cb_showinperiod.TabIndex = 10
        Me.cb_showinperiod.Text = "只看未過期"
        Me.cb_showinperiod.UseVisualStyleBackColor = True
        '
        'cb_showrelated
        '
        Me.cb_showrelated.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_showrelated.AutoSize = True
        Me.cb_showrelated.Location = New System.Drawing.Point(114, 7)
        Me.cb_showrelated.Margin = New System.Windows.Forms.Padding(0)
        Me.cb_showrelated.Name = "cb_showrelated"
        Me.cb_showrelated.Size = New System.Drawing.Size(159, 20)
        Me.cb_showrelated.TabIndex = 9
        Me.cb_showrelated.Text = "顯示健保碼/成大碼"
        Me.cb_showrelated.UseVisualStyleBackColor = True
        Me.cb_showrelated.Visible = False
        '
        'tlp_grid
        '
        Me.tlp_grid.AutoSize = True
        Me.tlp_grid.ColumnCount = 2
        Me.tlp_parent.SetColumnSpan(Me.tlp_grid, 2)
        Me.tlp_grid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_grid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_grid.Controls.Add(Me.ucl_dgv_checkcond, 1, 0)
        Me.tlp_grid.Controls.Add(Me.tlp_addremove, 0, 0)
        Me.tlp_grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_grid.Location = New System.Drawing.Point(0, 165)
        Me.tlp_grid.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_grid.Name = "tlp_grid"
        Me.tlp_grid.RowCount = 1
        Me.tlp_grid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_grid.Size = New System.Drawing.Size(367, 1)
        Me.tlp_grid.TabIndex = 18
        Me.tlp_grid.Visible = False
        '
        'ucl_dgv_checkcond
        '
        Me.ucl_dgv_checkcond.AllowUserToAddRows = False
        Me.ucl_dgv_checkcond.AllowUserToOrderColumns = False
        Me.ucl_dgv_checkcond.AllowUserToResizeColumns = True
        Me.ucl_dgv_checkcond.AllowUserToResizeRows = False
        Me.ucl_dgv_checkcond.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucl_dgv_checkcond.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ucl_dgv_checkcond.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ucl_dgv_checkcond.ColumnHeadersHeight = 4
        Me.ucl_dgv_checkcond.ColumnHeadersVisible = True
        Me.ucl_dgv_checkcond.CurrentCell = Nothing
        Me.ucl_dgv_checkcond.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_checkcond.DefaultCellStyle = DataGridViewCellStyle2
        Me.ucl_dgv_checkcond.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_checkcond.Location = New System.Drawing.Point(30, 0)
        Me.ucl_dgv_checkcond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_dgv_checkcond.MultiSelect = False
        Me.ucl_dgv_checkcond.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_checkcond.Name = "ucl_dgv_checkcond"
        Me.ucl_dgv_checkcond.RowHeadersWidth = 41
        Me.ucl_dgv_checkcond.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucl_dgv_checkcond.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_checkcond.Size = New System.Drawing.Size(337, 1)
        Me.ucl_dgv_checkcond.TabIndex = 17
        Me.ucl_dgv_checkcond.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucl_dgv_checkcond.uclBatchColIndex = ""
        Me.ucl_dgv_checkcond.uclClickToCheck = False
        Me.ucl_dgv_checkcond.uclColumnAlignment = ""
        Me.ucl_dgv_checkcond.uclColumnCheckBox = False
        Me.ucl_dgv_checkcond.uclColumnControlType = ""
        Me.ucl_dgv_checkcond.uclColumnWidth = ""
        Me.ucl_dgv_checkcond.uclDoCellEnter = True
        Me.ucl_dgv_checkcond.uclHasNewRow = False
        Me.ucl_dgv_checkcond.uclHeaderText = ""
        Me.ucl_dgv_checkcond.uclIsAlternatingRowsColors = True
        Me.ucl_dgv_checkcond.uclIsComboBoxGridQuery = True
        Me.ucl_dgv_checkcond.uclIsComboxClickTriggerDropDown = False
        Me.ucl_dgv_checkcond.uclIsDoOrderCheck = True
        Me.ucl_dgv_checkcond.uclIsSortable = False
        Me.ucl_dgv_checkcond.uclMultiSelectShowCheckBoxHeader = True
        Me.ucl_dgv_checkcond.uclNonVisibleColIndex = ""
        Me.ucl_dgv_checkcond.uclReadOnly = False
        Me.ucl_dgv_checkcond.uclShowCellBorder = False
        Me.ucl_dgv_checkcond.uclSortColIndex = ""
        Me.ucl_dgv_checkcond.uclTreeMode = False
        Me.ucl_dgv_checkcond.uclVisibleColIndex = ""
        Me.ucl_dgv_checkcond.Visible = False
        '
        'tlp_addremove
        '
        Me.tlp_addremove.ColumnCount = 1
        Me.tlp_addremove.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_addremove.Controls.Add(Me.btn_remove, 0, 1)
        Me.tlp_addremove.Controls.Add(Me.btn_add, 0, 0)
        Me.tlp_addremove.Location = New System.Drawing.Point(0, 0)
        Me.tlp_addremove.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_addremove.Name = "tlp_addremove"
        Me.tlp_addremove.RowCount = 2
        Me.tlp_addremove.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_addremove.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_addremove.Size = New System.Drawing.Size(30, 1)
        Me.tlp_addremove.TabIndex = 18
        Me.tlp_addremove.Visible = False
        '
        'btn_remove
        '
        Me.btn_remove.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_remove.Location = New System.Drawing.Point(1, 3)
        Me.btn_remove.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(28, 1)
        Me.btn_remove.TabIndex = 1
        Me.btn_remove.Text = "-"
        Me.btn_remove.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_add.Location = New System.Drawing.Point(1, 0)
        Me.btn_add.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(28, 1)
        Me.btn_add.TabIndex = 0
        Me.btn_add.Text = "+"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'tlp_btn
        '
        Me.tlp_btn.ColumnCount = 3
        Me.tlp_parent.SetColumnSpan(Me.tlp_btn, 2)
        Me.tlp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.tlp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.tlp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_btn.Controls.Add(Me.btn_confirm, 0, 0)
        Me.tlp_btn.Controls.Add(Me.btn_clear, 1, 0)
        Me.tlp_btn.Controls.Add(Me.btn_query, 2, 0)
        Me.tlp_btn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_btn.Location = New System.Drawing.Point(0, 165)
        Me.tlp_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_btn.Name = "tlp_btn"
        Me.tlp_btn.RowCount = 1
        Me.tlp_btn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_btn.Size = New System.Drawing.Size(367, 35)
        Me.tlp_btn.TabIndex = 22
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_confirm.Location = New System.Drawing.Point(0, 3)
        Me.btn_confirm.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_confirm.TabIndex = 13
        Me.btn_confirm.Text = "F10-連結"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_clear.Location = New System.Drawing.Point(93, 3)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_clear.TabIndex = 14
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_query.Location = New System.Drawing.Point(186, 3)
        Me.btn_query.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(90, 28)
        Me.btn_query.TabIndex = 11
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.tlp_condvalue.SetColumnSpan(Me.lblName, 2)
        Me.lblName.Location = New System.Drawing.Point(3, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(0, 16)
        Me.lblName.TabIndex = 9
        '
        'PUBRuleQueryUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 427)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRuleQueryUI"
        Me.TabText = "查詢規則"
        Me.Text = "查詢規則"
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.gb_corr_rule.ResumeLayout(False)
        Me.tlp_condvalue.ResumeLayout(False)
        Me.tlp_condvalue.PerformLayout()
        Me.tlp_condcheck.ResumeLayout(False)
        Me.tlp_condcheck.PerformLayout()
        Me.tlp_grid.ResumeLayout(False)
        Me.tlp_addremove.ResumeLayout(False)
        Me.tlp_btn.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_corr_rule As System.Windows.Forms.GroupBox
    Friend WithEvents lb_rulebelong_item As System.Windows.Forms.Label
    Friend WithEvents lb_initcondition As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_belongitem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_txt_initcond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cb_showrelated As System.Windows.Forms.CheckBox
    Friend WithEvents cb_showinperiod As System.Windows.Forms.CheckBox
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents tv_corr_condition As System.Windows.Forms.TreeView
    Friend WithEvents ucl_txt_clickmsg As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_selectednode As System.Windows.Forms.Label
    Friend WithEvents ucl_dgv_checkcond As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tlp_grid As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_addremove As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_remove As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents tlp_condvalue As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_doctor As System.Windows.Forms.Button
    Friend WithEvents tlp_condcheck As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_btn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblName As System.Windows.Forms.Label
End Class
