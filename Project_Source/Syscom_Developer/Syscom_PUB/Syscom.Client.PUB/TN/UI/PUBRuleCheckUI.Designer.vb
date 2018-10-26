<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleCheckUI
    Inherits Syscom.Client.UCL.BaseFormUI
    ' Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRuleCheckUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gb_parent = New System.Windows.Forms.GroupBox()
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_info = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.lb_item_belong = New System.Windows.Forms.Label()
        Me.lb_init_cond = New System.Windows.Forms.Label()
        Me.ucl_comb_item_belong = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.tlp_initcondition = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_x = New System.Windows.Forms.Label()
        Me.lb_init_belong = New System.Windows.Forms.Label()
        Me.ucl_txt_x = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_txt_belong_info = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.condition_dtl = New System.Windows.Forms.Button()
        Me.lb_res_strength = New System.Windows.Forms.Label()
        Me.ucl_comb_res_strength = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_exe_type = New System.Windows.Forms.Label()
        Me.ucl_comb_exe_type = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_check_ident = New System.Windows.Forms.Label()
        Me.ucl_comb_check_ident = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.vtn_clone_rule = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.gb_rulecontent = New System.Windows.Forms.GroupBox()
        Me.tlp_rulecontent = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_rule_name = New System.Windows.Forms.Label()
        Me.lb_eff_date = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.ucl_txt_rule_name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.tlp_rulesubcontent = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_to = New System.Windows.Forms.Label()
        Me.ucl_dtp_start_eff_date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.tlp_checkposition = New System.Windows.Forms.TableLayoutPanel()
        Me.rdo_isPrN = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_boe = New System.Windows.Forms.CheckBox()
        Me.cb_fi = New System.Windows.Forms.CheckBox()
        Me.cb_fe = New System.Windows.Forms.CheckBox()
        Me.cb_fo = New System.Windows.Forms.CheckBox()
        Me.cb_bi = New System.Windows.Forms.CheckBox()
        Me.lb_client = New System.Windows.Forms.Label()
        Me.lb_server = New System.Windows.Forms.Label()
        Me.rdo_isPrY = New System.Windows.Forms.RadioButton()
        Me.lb_exe_location = New System.Windows.Forms.Label()
        Me.txt_message = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ucl_dtp_end_eff_date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.tlp_contentmodify = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_removegrid = New System.Windows.Forms.Button()
        Me.btn_addgrid = New System.Windows.Forms.Button()
        Me.tbc_content = New System.Windows.Forms.TabControl()
        Me.tp_exe_cond = New System.Windows.Forms.TabPage()
        Me.ucl_dgv_detail = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tlp_checksuccess = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_txt_success_cond = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_success_select = New System.Windows.Forms.Button()
        Me.ucl_rt_successmsg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_success_sug_msg = New System.Windows.Forms.Label()
        Me.lb_success_cond = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tlp_fault = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_fault_select = New System.Windows.Forms.Button()
        Me.ucl_txt_fault_cond = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_rt_faultmsg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_fault_sug_msg = New System.Windows.Forms.Label()
        Me.lb_fault_cond = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.tlp_process = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_rt_process_msg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_process_msg = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgv_CheckReason = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_cond = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.gb_createdrule = New System.Windows.Forms.GroupBox()
        Me.tv_createdrule = New System.Windows.Forms.TreeView()
        Me.cb_showduringtime = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
        Me.tlp_info.SuspendLayout()
        Me.tlp_initcondition.SuspendLayout()
        Me.gb_rulecontent.SuspendLayout()
        Me.tlp_rulecontent.SuspendLayout()
        Me.tlp_rulesubcontent.SuspendLayout()
        Me.tlp_checkposition.SuspendLayout()
        Me.tlp_contentmodify.SuspendLayout()
        Me.tbc_content.SuspendLayout()
        Me.tp_exe_cond.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tlp_checksuccess.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.tlp_fault.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.tlp_process.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tlp_cond.SuspendLayout()
        Me.gb_createdrule.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_frame)
        Me.gb_parent.Location = New System.Drawing.Point(0, 0)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(1013, 646)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_frame.Controls.Add(Me.tlp_info, 0, 0)
        Me.tlp_frame.Controls.Add(Me.gb_rulecontent, 0, 1)
        Me.tlp_frame.Controls.Add(Me.gb_createdrule, 0, 2)
        Me.tlp_frame.Location = New System.Drawing.Point(3, 23)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 3
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.Size = New System.Drawing.Size(1004, 620)
        Me.tlp_frame.TabIndex = 0
        '
        'tlp_info
        '
        Me.tlp_info.ColumnCount = 7
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_info.Controls.Add(Me.btn_query, 6, 0)
        Me.tlp_info.Controls.Add(Me.lb_item_belong, 0, 0)
        Me.tlp_info.Controls.Add(Me.lb_init_cond, 2, 0)
        Me.tlp_info.Controls.Add(Me.ucl_comb_item_belong, 1, 0)
        Me.tlp_info.Controls.Add(Me.tlp_initcondition, 3, 0)
        Me.tlp_info.Controls.Add(Me.lb_res_strength, 0, 1)
        Me.tlp_info.Controls.Add(Me.ucl_comb_res_strength, 1, 1)
        Me.tlp_info.Controls.Add(Me.lb_exe_type, 2, 1)
        Me.tlp_info.Controls.Add(Me.ucl_comb_exe_type, 3, 1)
        Me.tlp_info.Controls.Add(Me.lb_check_ident, 4, 1)
        Me.tlp_info.Controls.Add(Me.ucl_comb_check_ident, 5, 1)
        Me.tlp_info.Controls.Add(Me.vtn_clone_rule, 6, 1)
        Me.tlp_info.Controls.Add(Me.lblName, 0, 2)
        Me.tlp_info.Location = New System.Drawing.Point(3, 3)
        Me.tlp_info.Name = "tlp_info"
        Me.tlp_info.RowCount = 3
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_info.Size = New System.Drawing.Size(992, 97)
        Me.tlp_info.TabIndex = 0
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_query.Location = New System.Drawing.Point(860, 5)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(90, 27)
        Me.btn_query.TabIndex = 8
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'lb_item_belong
        '
        Me.lb_item_belong.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_item_belong.AutoSize = True
        Me.lb_item_belong.ForeColor = System.Drawing.Color.Red
        Me.lb_item_belong.Location = New System.Drawing.Point(3, 10)
        Me.lb_item_belong.Name = "lb_item_belong"
        Me.lb_item_belong.Size = New System.Drawing.Size(120, 16)
        Me.lb_item_belong.TabIndex = 0
        Me.lb_item_belong.Text = "規則歸屬項目："
        '
        'lb_init_cond
        '
        Me.lb_init_cond.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_init_cond.AutoSize = True
        Me.lb_init_cond.ForeColor = System.Drawing.Color.Red
        Me.lb_init_cond.Location = New System.Drawing.Point(299, 10)
        Me.lb_init_cond.Name = "lb_init_cond"
        Me.lb_init_cond.Size = New System.Drawing.Size(92, 16)
        Me.lb_init_cond.TabIndex = 4
        Me.lb_init_cond.Text = "起始條件： "
        '
        'ucl_comb_item_belong
        '
        Me.ucl_comb_item_belong.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_item_belong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_item_belong.DropDownWidth = 20
        Me.ucl_comb_item_belong.DroppedDown = False
        Me.ucl_comb_item_belong.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_item_belong.Location = New System.Drawing.Point(126, 6)
        Me.ucl_comb_item_belong.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_item_belong.Name = "ucl_comb_item_belong"
        Me.ucl_comb_item_belong.SelectedIndex = -1
        Me.ucl_comb_item_belong.SelectedItem = Nothing
        Me.ucl_comb_item_belong.SelectedText = ""
        Me.ucl_comb_item_belong.SelectedValue = ""
        Me.ucl_comb_item_belong.SelectionStart = 0
        Me.ucl_comb_item_belong.Size = New System.Drawing.Size(142, 24)
        Me.ucl_comb_item_belong.TabIndex = 6
        Me.ucl_comb_item_belong.uclDisplayIndex = "0,1"
        Me.ucl_comb_item_belong.uclIsAutoClear = True
        Me.ucl_comb_item_belong.uclIsFirstItemEmpty = True
        Me.ucl_comb_item_belong.uclIsTextMode = False
        Me.ucl_comb_item_belong.uclShowMsg = False
        Me.ucl_comb_item_belong.uclValueIndex = "0"
        '
        'tlp_initcondition
        '
        Me.tlp_initcondition.ColumnCount = 5
        Me.tlp_info.SetColumnSpan(Me.tlp_initcondition, 3)
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_initcondition.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.tlp_initcondition.Location = New System.Drawing.Point(394, 0)
        Me.tlp_initcondition.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_initcondition.Name = "tlp_initcondition"
        Me.tlp_initcondition.RowCount = 1
        Me.tlp_initcondition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_initcondition.Size = New System.Drawing.Size(463, 37)
        Me.tlp_initcondition.TabIndex = 11
        '
        'lb_x
        '
        Me.lb_x.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_x.AutoSize = True
        Me.lb_x.Location = New System.Drawing.Point(3, 8)
        Me.lb_x.Name = "lb_x"
        Me.lb_x.Size = New System.Drawing.Size(35, 16)
        Me.lb_x.TabIndex = 0
        Me.lb_x.Text = "X = "
        '
        'lb_init_belong
        '
        Me.lb_init_belong.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lb_init_belong.AutoSize = True
        Me.lb_init_belong.ForeColor = System.Drawing.Color.Red
        Me.lb_init_belong.Location = New System.Drawing.Point(164, 8)
        Me.lb_init_belong.Name = "lb_init_belong"
        Me.lb_init_belong.Size = New System.Drawing.Size(57, 16)
        Me.lb_init_belong.TabIndex = 11
        Me.lb_init_belong.Text = "XXX = "
        '
        'ucl_txt_x
        '
        Me.ucl_txt_x.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_x.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_x.Location = New System.Drawing.Point(44, 3)
        Me.ucl_txt_x.MaxLength = 10
        Me.ucl_txt_x.Name = "ucl_txt_x"
        Me.ucl_txt_x.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_x.SelectionStart = 0
        Me.ucl_txt_x.Size = New System.Drawing.Size(114, 27)
        Me.ucl_txt_x.TabIndex = 1
        Me.ucl_txt_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_x.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_x.ToolTipTag = Nothing
        Me.ucl_txt_x.uclDollarSign = False
        Me.ucl_txt_x.uclDotCount = 0
        Me.ucl_txt_x.uclIntCount = 2
        Me.ucl_txt_x.uclMinus = False
        Me.ucl_txt_x.uclReadOnly = False
        Me.ucl_txt_x.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_x.uclTrimZero = True
        '
        'ucl_txt_belong_info
        '
        Me.ucl_txt_belong_info.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_belong_info.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_belong_info.Location = New System.Drawing.Point(227, 3)
        Me.ucl_txt_belong_info.MaxLength = 30
        Me.ucl_txt_belong_info.Name = "ucl_txt_belong_info"
        Me.ucl_txt_belong_info.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_belong_info.SelectionStart = 0
        Me.ucl_txt_belong_info.Size = New System.Drawing.Size(178, 27)
        Me.ucl_txt_belong_info.TabIndex = 5
        Me.ucl_txt_belong_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_belong_info.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_belong_info.ToolTipTag = Nothing
        Me.ucl_txt_belong_info.uclDollarSign = False
        Me.ucl_txt_belong_info.uclDotCount = 0
        Me.ucl_txt_belong_info.uclIntCount = 2
        Me.ucl_txt_belong_info.uclMinus = False
        Me.ucl_txt_belong_info.uclReadOnly = False
        Me.ucl_txt_belong_info.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_belong_info.uclTrimZero = True
        '
        'condition_dtl
        '
        Me.condition_dtl.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.condition_dtl.Location = New System.Drawing.Point(411, 3)
        Me.condition_dtl.Name = "condition_dtl"
        Me.condition_dtl.Size = New System.Drawing.Size(33, 27)
        Me.condition_dtl.TabIndex = 12
        Me.condition_dtl.Text = "..."
        Me.condition_dtl.UseVisualStyleBackColor = True
        '
        'lb_res_strength
        '
        Me.lb_res_strength.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_res_strength.AutoSize = True
        Me.lb_res_strength.ForeColor = System.Drawing.Color.Red
        Me.lb_res_strength.Location = New System.Drawing.Point(3, 44)
        Me.lb_res_strength.Name = "lb_res_strength"
        Me.lb_res_strength.Size = New System.Drawing.Size(120, 16)
        Me.lb_res_strength.TabIndex = 1
        Me.lb_res_strength.Text = "檢核限制強度："
        '
        'ucl_comb_res_strength
        '
        Me.ucl_comb_res_strength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_res_strength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_res_strength.DropDownWidth = 20
        Me.ucl_comb_res_strength.DroppedDown = False
        Me.ucl_comb_res_strength.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_res_strength.Location = New System.Drawing.Point(126, 40)
        Me.ucl_comb_res_strength.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_res_strength.Name = "ucl_comb_res_strength"
        Me.ucl_comb_res_strength.SelectedIndex = -1
        Me.ucl_comb_res_strength.SelectedItem = Nothing
        Me.ucl_comb_res_strength.SelectedText = ""
        Me.ucl_comb_res_strength.SelectedValue = ""
        Me.ucl_comb_res_strength.SelectionStart = 0
        Me.ucl_comb_res_strength.Size = New System.Drawing.Size(142, 24)
        Me.ucl_comb_res_strength.TabIndex = 7
        Me.ucl_comb_res_strength.uclDisplayIndex = "0,1"
        Me.ucl_comb_res_strength.uclIsAutoClear = True
        Me.ucl_comb_res_strength.uclIsFirstItemEmpty = True
        Me.ucl_comb_res_strength.uclIsTextMode = False
        Me.ucl_comb_res_strength.uclShowMsg = False
        Me.ucl_comb_res_strength.uclValueIndex = "0"
        '
        'lb_exe_type
        '
        Me.lb_exe_type.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_exe_type.AutoSize = True
        Me.lb_exe_type.ForeColor = System.Drawing.Color.Red
        Me.lb_exe_type.Location = New System.Drawing.Point(271, 44)
        Me.lb_exe_type.Name = "lb_exe_type"
        Me.lb_exe_type.Size = New System.Drawing.Size(120, 16)
        Me.lb_exe_type.TabIndex = 2
        Me.lb_exe_type.Text = "檢核執行類別："
        '
        'ucl_comb_exe_type
        '
        Me.ucl_comb_exe_type.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_exe_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_exe_type.DropDownWidth = 20
        Me.ucl_comb_exe_type.DroppedDown = False
        Me.ucl_comb_exe_type.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_exe_type.Location = New System.Drawing.Point(394, 40)
        Me.ucl_comb_exe_type.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_exe_type.Name = "ucl_comb_exe_type"
        Me.ucl_comb_exe_type.SelectedIndex = -1
        Me.ucl_comb_exe_type.SelectedItem = Nothing
        Me.ucl_comb_exe_type.SelectedText = ""
        Me.ucl_comb_exe_type.SelectedValue = ""
        Me.ucl_comb_exe_type.SelectionStart = 0
        Me.ucl_comb_exe_type.Size = New System.Drawing.Size(150, 24)
        Me.ucl_comb_exe_type.TabIndex = 8
        Me.ucl_comb_exe_type.uclDisplayIndex = "0,1"
        Me.ucl_comb_exe_type.uclIsAutoClear = True
        Me.ucl_comb_exe_type.uclIsFirstItemEmpty = True
        Me.ucl_comb_exe_type.uclIsTextMode = False
        Me.ucl_comb_exe_type.uclShowMsg = False
        Me.ucl_comb_exe_type.uclValueIndex = "1"
        '
        'lb_check_ident
        '
        Me.lb_check_ident.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_check_ident.AutoSize = True
        Me.lb_check_ident.ForeColor = System.Drawing.Color.Red
        Me.lb_check_ident.Location = New System.Drawing.Point(547, 44)
        Me.lb_check_ident.Name = "lb_check_ident"
        Me.lb_check_ident.Size = New System.Drawing.Size(120, 16)
        Me.lb_check_ident.TabIndex = 3
        Me.lb_check_ident.Text = "檢核對象身分："
        '
        'ucl_comb_check_ident
        '
        Me.ucl_comb_check_ident.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_check_ident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_check_ident.DropDownWidth = 20
        Me.ucl_comb_check_ident.DroppedDown = False
        Me.ucl_comb_check_ident.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_check_ident.Location = New System.Drawing.Point(670, 40)
        Me.ucl_comb_check_ident.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_check_ident.Name = "ucl_comb_check_ident"
        Me.ucl_comb_check_ident.SelectedIndex = -1
        Me.ucl_comb_check_ident.SelectedItem = Nothing
        Me.ucl_comb_check_ident.SelectedText = ""
        Me.ucl_comb_check_ident.SelectedValue = ""
        Me.ucl_comb_check_ident.SelectionStart = 0
        Me.ucl_comb_check_ident.Size = New System.Drawing.Size(184, 24)
        Me.ucl_comb_check_ident.TabIndex = 9
        Me.ucl_comb_check_ident.uclDisplayIndex = "0,1"
        Me.ucl_comb_check_ident.uclIsAutoClear = True
        Me.ucl_comb_check_ident.uclIsFirstItemEmpty = True
        Me.ucl_comb_check_ident.uclIsTextMode = False
        Me.ucl_comb_check_ident.uclShowMsg = False
        Me.ucl_comb_check_ident.uclValueIndex = "0"
        '
        'vtn_clone_rule
        '
        Me.vtn_clone_rule.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.vtn_clone_rule.Location = New System.Drawing.Point(860, 40)
        Me.vtn_clone_rule.Name = "vtn_clone_rule"
        Me.vtn_clone_rule.Size = New System.Drawing.Size(90, 24)
        Me.vtn_clone_rule.TabIndex = 10
        Me.vtn_clone_rule.Text = "複製規則"
        Me.vtn_clone_rule.UseVisualStyleBackColor = True
        Me.vtn_clone_rule.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.tlp_info.SetColumnSpan(Me.lblName, 3)
        Me.lblName.Location = New System.Drawing.Point(3, 67)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(0, 16)
        Me.lblName.TabIndex = 12
        '
        'gb_rulecontent
        '
        Me.gb_rulecontent.Controls.Add(Me.tlp_rulecontent)
        Me.gb_rulecontent.Location = New System.Drawing.Point(3, 106)
        Me.gb_rulecontent.Name = "gb_rulecontent"
        Me.gb_rulecontent.Size = New System.Drawing.Size(998, 420)
        Me.gb_rulecontent.TabIndex = 1
        Me.gb_rulecontent.TabStop = False
        Me.gb_rulecontent.Text = "規則內容"
        '
        'tlp_rulecontent
        '
        Me.tlp_rulecontent.ColumnCount = 3
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulecontent.Controls.Add(Me.lb_rule_name, 0, 0)
        Me.tlp_rulecontent.Controls.Add(Me.lb_eff_date, 0, 1)
        Me.tlp_rulecontent.Controls.Add(Me.btn_save, 2, 0)
        Me.tlp_rulecontent.Controls.Add(Me.ucl_txt_rule_name, 1, 0)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_rulesubcontent, 1, 1)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_contentmodify, 0, 2)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_cond, 2, 1)
        Me.tlp_rulecontent.Location = New System.Drawing.Point(3, 23)
        Me.tlp_rulecontent.Name = "tlp_rulecontent"
        Me.tlp_rulecontent.RowCount = 3
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_rulecontent.Size = New System.Drawing.Size(989, 394)
        Me.tlp_rulecontent.TabIndex = 0
        '
        'lb_rule_name
        '
        Me.lb_rule_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_rule_name.AutoSize = True
        Me.lb_rule_name.ForeColor = System.Drawing.Color.Red
        Me.lb_rule_name.Location = New System.Drawing.Point(3, 8)
        Me.lb_rule_name.Name = "lb_rule_name"
        Me.lb_rule_name.Size = New System.Drawing.Size(88, 16)
        Me.lb_rule_name.TabIndex = 1
        Me.lb_rule_name.Text = "規則名稱："
        '
        'lb_eff_date
        '
        Me.lb_eff_date.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_eff_date.AutoSize = True
        Me.lb_eff_date.ForeColor = System.Drawing.Color.Red
        Me.lb_eff_date.Location = New System.Drawing.Point(3, 81)
        Me.lb_eff_date.Name = "lb_eff_date"
        Me.lb_eff_date.Size = New System.Drawing.Size(88, 16)
        Me.lb_eff_date.TabIndex = 2
        Me.lb_eff_date.Text = "生效日期："
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(833, 0)
        Me.btn_save.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(90, 27)
        Me.btn_save.TabIndex = 5
        Me.btn_save.Text = "F10-儲存"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'ucl_txt_rule_name
        '
        Me.ucl_txt_rule_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_rule_name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_rule_name.Location = New System.Drawing.Point(97, 3)
        Me.ucl_txt_rule_name.MaxLength = 40
        Me.ucl_txt_rule_name.Name = "ucl_txt_rule_name"
        Me.ucl_txt_rule_name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_rule_name.SelectionStart = 0
        Me.ucl_txt_rule_name.Size = New System.Drawing.Size(519, 27)
        Me.ucl_txt_rule_name.TabIndex = 3
        Me.ucl_txt_rule_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_rule_name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_rule_name.ToolTipTag = Nothing
        Me.ucl_txt_rule_name.uclDollarSign = False
        Me.ucl_txt_rule_name.uclDotCount = 0
        Me.ucl_txt_rule_name.uclIntCount = 2
        Me.ucl_txt_rule_name.uclMinus = False
        Me.ucl_txt_rule_name.uclReadOnly = False
        Me.ucl_txt_rule_name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_rule_name.uclTrimZero = True
        '
        'tlp_rulesubcontent
        '
        Me.tlp_rulesubcontent.ColumnCount = 5
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_rulesubcontent.Controls.Add(Me.lb_to, 1, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.ucl_dtp_start_eff_date, 0, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.tlp_checkposition, 4, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.lb_exe_location, 3, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.txt_message, 1, 1)
        Me.tlp_rulesubcontent.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_rulesubcontent.Controls.Add(Me.ucl_dtp_end_eff_date, 2, 0)
        Me.tlp_rulesubcontent.Location = New System.Drawing.Point(94, 33)
        Me.tlp_rulesubcontent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_rulesubcontent.Name = "tlp_rulesubcontent"
        Me.tlp_rulesubcontent.RowCount = 2
        Me.tlp_rulesubcontent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_rulesubcontent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_rulesubcontent.Size = New System.Drawing.Size(736, 112)
        Me.tlp_rulesubcontent.TabIndex = 4
        '
        'lb_to
        '
        Me.lb_to.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lb_to.AutoSize = True
        Me.lb_to.Location = New System.Drawing.Point(142, 29)
        Me.lb_to.Name = "lb_to"
        Me.lb_to.Size = New System.Drawing.Size(24, 16)
        Me.lb_to.TabIndex = 2
        Me.lb_to.Text = "至"
        '
        'ucl_dtp_start_eff_date
        '
        Me.ucl_dtp_start_eff_date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_start_eff_date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_start_eff_date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_start_eff_date.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_start_eff_date.Location = New System.Drawing.Point(3, 24)
        Me.ucl_dtp_start_eff_date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_start_eff_date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_start_eff_date.Name = "ucl_dtp_start_eff_date"
        Me.ucl_dtp_start_eff_date.Size = New System.Drawing.Size(133, 27)
        Me.ucl_dtp_start_eff_date.TabIndex = 0
        Me.ucl_dtp_start_eff_date.uclReadOnly = False
        '
        'tlp_checkposition
        '
        Me.tlp_checkposition.ColumnCount = 4
        Me.tlp_checkposition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_checkposition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_checkposition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_checkposition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_checkposition.Controls.Add(Me.rdo_isPrN, 3, 2)
        Me.tlp_checkposition.Controls.Add(Me.Label1, 0, 2)
        Me.tlp_checkposition.Controls.Add(Me.cb_boe, 1, 1)
        Me.tlp_checkposition.Controls.Add(Me.cb_fi, 3, 0)
        Me.tlp_checkposition.Controls.Add(Me.cb_fe, 2, 0)
        Me.tlp_checkposition.Controls.Add(Me.cb_fo, 1, 0)
        Me.tlp_checkposition.Controls.Add(Me.cb_bi, 3, 1)
        Me.tlp_checkposition.Controls.Add(Me.lb_client, 0, 0)
        Me.tlp_checkposition.Controls.Add(Me.lb_server, 0, 1)
        Me.tlp_checkposition.Controls.Add(Me.rdo_isPrY, 2, 2)
        Me.tlp_checkposition.Location = New System.Drawing.Point(433, 0)
        Me.tlp_checkposition.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_checkposition.Name = "tlp_checkposition"
        Me.tlp_checkposition.RowCount = 3
        Me.tlp_checkposition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_checkposition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_checkposition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_checkposition.Size = New System.Drawing.Size(303, 75)
        Me.tlp_checkposition.TabIndex = 9
        '
        'rdo_isPrN
        '
        Me.rdo_isPrN.AutoSize = True
        Me.rdo_isPrN.Location = New System.Drawing.Point(215, 55)
        Me.rdo_isPrN.Name = "rdo_isPrN"
        Me.rdo_isPrN.Size = New System.Drawing.Size(42, 20)
        Me.rdo_isPrN.TabIndex = 15
        Me.rdo_isPrN.Text = "否"
        Me.rdo_isPrN.UseVisualStyleBackColor = True
        Me.rdo_isPrN.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.tlp_checkposition.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Location = New System.Drawing.Point(24, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "是否事前審查："
        Me.Label1.Visible = False
        '
        'cb_boe
        '
        Me.cb_boe.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_boe.AutoSize = True
        Me.tlp_checkposition.SetColumnSpan(Me.cb_boe, 2)
        Me.cb_boe.Location = New System.Drawing.Point(85, 29)
        Me.cb_boe.Name = "cb_boe"
        Me.cb_boe.Size = New System.Drawing.Size(75, 20)
        Me.cb_boe.TabIndex = 9
        Me.cb_boe.Text = "門急診"
        Me.cb_boe.UseVisualStyleBackColor = True
        '
        'cb_fi
        '
        Me.cb_fi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_fi.AutoSize = True
        Me.cb_fi.Location = New System.Drawing.Point(215, 3)
        Me.cb_fi.Name = "cb_fi"
        Me.cb_fi.Size = New System.Drawing.Size(59, 20)
        Me.cb_fi.TabIndex = 8
        Me.cb_fi.Text = "住院"
        Me.cb_fi.UseVisualStyleBackColor = True
        '
        'cb_fe
        '
        Me.cb_fe.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_fe.AutoSize = True
        Me.cb_fe.Location = New System.Drawing.Point(150, 3)
        Me.cb_fe.Name = "cb_fe"
        Me.cb_fe.Size = New System.Drawing.Size(59, 20)
        Me.cb_fe.TabIndex = 7
        Me.cb_fe.Text = "急診"
        Me.cb_fe.UseVisualStyleBackColor = True
        '
        'cb_fo
        '
        Me.cb_fo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_fo.AutoSize = True
        Me.cb_fo.Location = New System.Drawing.Point(85, 3)
        Me.cb_fo.Name = "cb_fo"
        Me.cb_fo.Size = New System.Drawing.Size(59, 20)
        Me.cb_fo.TabIndex = 6
        Me.cb_fo.Text = "門診"
        Me.cb_fo.UseVisualStyleBackColor = True
        '
        'cb_bi
        '
        Me.cb_bi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_bi.AutoSize = True
        Me.cb_bi.Location = New System.Drawing.Point(215, 29)
        Me.cb_bi.Name = "cb_bi"
        Me.cb_bi.Size = New System.Drawing.Size(59, 20)
        Me.cb_bi.TabIndex = 10
        Me.cb_bi.Text = "住院"
        Me.cb_bi.UseVisualStyleBackColor = True
        '
        'lb_client
        '
        Me.lb_client.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_client.AutoSize = True
        Me.lb_client.Location = New System.Drawing.Point(3, 5)
        Me.lb_client.Name = "lb_client"
        Me.lb_client.Size = New System.Drawing.Size(76, 16)
        Me.lb_client.TabIndex = 11
        Me.lb_client.Text = "醫囑/批價"
        '
        'lb_server
        '
        Me.lb_server.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_server.AutoSize = True
        Me.lb_server.Location = New System.Drawing.Point(3, 31)
        Me.lb_server.Name = "lb_server"
        Me.lb_server.Size = New System.Drawing.Size(40, 16)
        Me.lb_server.TabIndex = 12
        Me.lb_server.Text = "申報"
        '
        'rdo_isPrY
        '
        Me.rdo_isPrY.AutoSize = True
        Me.rdo_isPrY.Checked = True
        Me.rdo_isPrY.Location = New System.Drawing.Point(150, 55)
        Me.rdo_isPrY.Name = "rdo_isPrY"
        Me.rdo_isPrY.Size = New System.Drawing.Size(42, 20)
        Me.rdo_isPrY.TabIndex = 14
        Me.rdo_isPrY.TabStop = True
        Me.rdo_isPrY.Text = "是"
        Me.rdo_isPrY.UseVisualStyleBackColor = True
        Me.rdo_isPrY.Visible = False
        '
        'lb_exe_location
        '
        Me.lb_exe_location.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_exe_location.AutoSize = True
        Me.lb_exe_location.Location = New System.Drawing.Point(310, 29)
        Me.lb_exe_location.Name = "lb_exe_location"
        Me.lb_exe_location.Size = New System.Drawing.Size(120, 16)
        Me.lb_exe_location.TabIndex = 3
        Me.lb_exe_location.Text = "執行檢核位置："
        '
        'txt_message
        '
        Me.txt_message.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_rulesubcontent.SetColumnSpan(Me.txt_message, 3)
        Me.txt_message.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_message.Location = New System.Drawing.Point(142, 78)
        Me.txt_message.MaxLength = 100
        Me.txt_message.Name = "txt_message"
        Me.txt_message.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_message.SelectionStart = 0
        Me.txt_message.Size = New System.Drawing.Size(288, 31)
        Me.txt_message.TabIndex = 14
        Me.txt_message.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_message.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_message.ToolTipTag = Nothing
        Me.txt_message.uclDollarSign = False
        Me.txt_message.uclDotCount = 0
        Me.txt_message.uclIntCount = 2
        Me.txt_message.uclMinus = False
        Me.txt_message.uclReadOnly = False
        Me.txt_message.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_message.uclTrimZero = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "聯絡人訊息"
        '
        'ucl_dtp_end_eff_date
        '
        Me.ucl_dtp_end_eff_date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_end_eff_date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_end_eff_date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_end_eff_date.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_end_eff_date.Location = New System.Drawing.Point(172, 24)
        Me.ucl_dtp_end_eff_date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_end_eff_date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_end_eff_date.Name = "ucl_dtp_end_eff_date"
        Me.ucl_dtp_end_eff_date.Size = New System.Drawing.Size(124, 27)
        Me.ucl_dtp_end_eff_date.TabIndex = 1
        Me.ucl_dtp_end_eff_date.uclReadOnly = False
        '
        'tlp_contentmodify
        '
        Me.tlp_contentmodify.ColumnCount = 2
        Me.tlp_rulecontent.SetColumnSpan(Me.tlp_contentmodify, 3)
        Me.tlp_contentmodify.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_contentmodify.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_contentmodify.Controls.Add(Me.btn_removegrid, 0, 1)
        Me.tlp_contentmodify.Controls.Add(Me.btn_addgrid, 0, 0)
        Me.tlp_contentmodify.Controls.Add(Me.tbc_content, 1, 0)
        Me.tlp_contentmodify.Location = New System.Drawing.Point(0, 145)
        Me.tlp_contentmodify.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentmodify.Name = "tlp_contentmodify"
        Me.tlp_contentmodify.RowCount = 3
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.39189!))
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.63513!))
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.97298!))
        Me.tlp_contentmodify.Size = New System.Drawing.Size(998, 246)
        Me.tlp_contentmodify.TabIndex = 8
        '
        'btn_removegrid
        '
        Me.btn_removegrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_removegrid.Location = New System.Drawing.Point(3, 75)
        Me.btn_removegrid.Name = "btn_removegrid"
        Me.btn_removegrid.Size = New System.Drawing.Size(81, 49)
        Me.btn_removegrid.TabIndex = 1
        Me.btn_removegrid.Text = "移除條件"
        Me.btn_removegrid.UseVisualStyleBackColor = True
        '
        'btn_addgrid
        '
        Me.btn_addgrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_addgrid.Location = New System.Drawing.Point(3, 15)
        Me.btn_addgrid.Name = "btn_addgrid"
        Me.btn_addgrid.Size = New System.Drawing.Size(81, 54)
        Me.btn_addgrid.TabIndex = 0
        Me.btn_addgrid.Text = "新增條件"
        Me.btn_addgrid.UseVisualStyleBackColor = True
        '
        'tbc_content
        '
        Me.tbc_content.Controls.Add(Me.tp_exe_cond)
        Me.tbc_content.Controls.Add(Me.TabPage2)
        Me.tbc_content.Controls.Add(Me.TabPage3)
        Me.tbc_content.Controls.Add(Me.TabPage4)
        Me.tbc_content.Controls.Add(Me.TabPage1)
        Me.tbc_content.Location = New System.Drawing.Point(87, 3)
        Me.tbc_content.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tbc_content.Name = "tbc_content"
        Me.tlp_contentmodify.SetRowSpan(Me.tbc_content, 3)
        Me.tbc_content.SelectedIndex = 0
        Me.tbc_content.Size = New System.Drawing.Size(902, 241)
        Me.tbc_content.TabIndex = 7
        '
        'tp_exe_cond
        '
        Me.tp_exe_cond.Controls.Add(Me.ucl_dgv_detail)
        Me.tp_exe_cond.Location = New System.Drawing.Point(4, 26)
        Me.tp_exe_cond.Name = "tp_exe_cond"
        Me.tp_exe_cond.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_exe_cond.Size = New System.Drawing.Size(894, 211)
        Me.tp_exe_cond.TabIndex = 0
        Me.tp_exe_cond.Text = "檢查條件"
        Me.tp_exe_cond.UseVisualStyleBackColor = True
        '
        'ucl_dgv_detail
        '
        Me.ucl_dgv_detail.AllowUserToAddRows = False
        Me.ucl_dgv_detail.AllowUserToOrderColumns = False
        Me.ucl_dgv_detail.AllowUserToResizeColumns = True
        Me.ucl_dgv_detail.AllowUserToResizeRows = False
        Me.ucl_dgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucl_dgv_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ucl_dgv_detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ucl_dgv_detail.ColumnHeadersHeight = 4
        Me.ucl_dgv_detail.ColumnHeadersVisible = True
        Me.ucl_dgv_detail.CurrentCell = Nothing
        Me.ucl_dgv_detail.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_detail.DefaultCellStyle = DataGridViewCellStyle2
        Me.ucl_dgv_detail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_detail.Location = New System.Drawing.Point(3, 3)
        Me.ucl_dgv_detail.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_detail.MultiSelect = True
        Me.ucl_dgv_detail.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_detail.Name = "ucl_dgv_detail"
        Me.ucl_dgv_detail.RowHeadersWidth = 41
        Me.ucl_dgv_detail.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucl_dgv_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_detail.Size = New System.Drawing.Size(887, 212)
        Me.ucl_dgv_detail.TabIndex = 0
        Me.ucl_dgv_detail.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucl_dgv_detail.uclBatchColIndex = ""
        Me.ucl_dgv_detail.uclClickToCheck = True
        Me.ucl_dgv_detail.uclColumnAlignment = ""
        Me.ucl_dgv_detail.uclColumnCheckBox = True
        Me.ucl_dgv_detail.uclColumnControlType = ""
        Me.ucl_dgv_detail.uclColumnWidth = ""
        Me.ucl_dgv_detail.uclDoCellEnter = True
        Me.ucl_dgv_detail.uclHasNewRow = False
        Me.ucl_dgv_detail.uclHeaderText = ""
        Me.ucl_dgv_detail.uclIsAlternatingRowsColors = True
        Me.ucl_dgv_detail.uclIsComboBoxGridQuery = True
        Me.ucl_dgv_detail.uclIsComboxClickTriggerDropDown = False
        Me.ucl_dgv_detail.uclIsDoOrderCheck = True
        Me.ucl_dgv_detail.uclIsSortable = False
        Me.ucl_dgv_detail.uclMultiSelectShowCheckBoxHeader = True
        Me.ucl_dgv_detail.uclNonVisibleColIndex = ""
        Me.ucl_dgv_detail.uclReadOnly = False
        Me.ucl_dgv_detail.uclShowCellBorder = False
        Me.ucl_dgv_detail.uclSortColIndex = ""
        Me.ucl_dgv_detail.uclTreeMode = False
        Me.ucl_dgv_detail.uclVisibleColIndex = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tlp_checksuccess)
        Me.TabPage2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(894, 211)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "檢核成功處理設定"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tlp_checksuccess
        '
        Me.tlp_checksuccess.ColumnCount = 1
        Me.tlp_checksuccess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_checksuccess.Controls.Add(Me.TableLayoutPanel3, 0, 3)
        Me.tlp_checksuccess.Controls.Add(Me.ucl_rt_successmsg, 0, 1)
        Me.tlp_checksuccess.Controls.Add(Me.lb_success_sug_msg, 0, 0)
        Me.tlp_checksuccess.Controls.Add(Me.lb_success_cond, 0, 2)
        Me.tlp_checksuccess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_checksuccess.Location = New System.Drawing.Point(3, 3)
        Me.tlp_checksuccess.Name = "tlp_checksuccess"
        Me.tlp_checksuccess.RowCount = 4
        Me.tlp_checksuccess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_checksuccess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_checksuccess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_checksuccess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_checksuccess.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_checksuccess.Size = New System.Drawing.Size(888, 205)
        Me.tlp_checksuccess.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ucl_txt_success_cond, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_success_select, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 162)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(888, 43)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'ucl_txt_success_cond
        '
        Me.ucl_txt_success_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_success_cond.Enabled = False
        Me.ucl_txt_success_cond.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_success_cond.Location = New System.Drawing.Point(0, 8)
        Me.ucl_txt_success_cond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_success_cond.MaxLength = 100
        Me.ucl_txt_success_cond.Name = "ucl_txt_success_cond"
        Me.ucl_txt_success_cond.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_txt_success_cond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_success_cond.SelectionStart = 0
        Me.ucl_txt_success_cond.Size = New System.Drawing.Size(710, 27)
        Me.ucl_txt_success_cond.TabIndex = 0
        Me.ucl_txt_success_cond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_success_cond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_success_cond.ToolTipTag = Nothing
        Me.ucl_txt_success_cond.uclDollarSign = False
        Me.ucl_txt_success_cond.uclDotCount = 0
        Me.ucl_txt_success_cond.uclIntCount = 2
        Me.ucl_txt_success_cond.uclMinus = False
        Me.ucl_txt_success_cond.uclReadOnly = False
        Me.ucl_txt_success_cond.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_success_cond.uclTrimZero = True
        Me.ucl_txt_success_cond.Visible = False
        '
        'btn_success_select
        '
        Me.btn_success_select.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_success_select.Location = New System.Drawing.Point(713, 8)
        Me.btn_success_select.Name = "btn_success_select"
        Me.btn_success_select.Size = New System.Drawing.Size(75, 27)
        Me.btn_success_select.TabIndex = 1
        Me.btn_success_select.Text = "選擇"
        Me.btn_success_select.UseVisualStyleBackColor = True
        Me.btn_success_select.Visible = False
        '
        'ucl_rt_successmsg
        '
        Me.ucl_rt_successmsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_rt_successmsg.Location = New System.Drawing.Point(3, 30)
        Me.ucl_rt_successmsg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_successmsg.Name = "ucl_rt_successmsg"
        Me.ucl_rt_successmsg.Size = New System.Drawing.Size(856, 102)
        Me.ucl_rt_successmsg.TabIndex = 3
        Me.ucl_rt_successmsg.uclMaxLength = 32767
        Me.ucl_rt_successmsg.uclReadOnly = False
        Me.ucl_rt_successmsg.uclWordWrap = True
        '
        'lb_success_sug_msg
        '
        Me.lb_success_sug_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_success_sug_msg.AutoSize = True
        Me.lb_success_sug_msg.Location = New System.Drawing.Point(3, 7)
        Me.lb_success_sug_msg.Name = "lb_success_sug_msg"
        Me.lb_success_sug_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_success_sug_msg.TabIndex = 4
        Me.lb_success_sug_msg.Text = "提示使用者訊息："
        '
        'lb_success_cond
        '
        Me.lb_success_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_success_cond.AutoSize = True
        Me.lb_success_cond.Location = New System.Drawing.Point(3, 139)
        Me.lb_success_cond.Name = "lb_success_cond"
        Me.lb_success_cond.Size = New System.Drawing.Size(88, 16)
        Me.lb_success_cond.TabIndex = 5
        Me.lb_success_cond.Text = "續接條件："
        Me.lb_success_cond.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tlp_fault)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(894, 211)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "提示使用者訊息"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tlp_fault
        '
        Me.tlp_fault.ColumnCount = 1
        Me.tlp_fault.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_fault.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.tlp_fault.Controls.Add(Me.ucl_rt_faultmsg, 0, 1)
        Me.tlp_fault.Controls.Add(Me.lb_fault_sug_msg, 0, 0)
        Me.tlp_fault.Controls.Add(Me.lb_fault_cond, 0, 2)
        Me.tlp_fault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_fault.Location = New System.Drawing.Point(3, 3)
        Me.tlp_fault.Name = "tlp_fault"
        Me.tlp_fault.RowCount = 4
        Me.tlp_fault.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_fault.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_fault.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_fault.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlp_fault.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_fault.Size = New System.Drawing.Size(888, 205)
        Me.tlp_fault.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btn_fault_select, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ucl_txt_fault_cond, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 162)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(888, 43)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'btn_fault_select
        '
        Me.btn_fault_select.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_fault_select.Location = New System.Drawing.Point(713, 8)
        Me.btn_fault_select.Name = "btn_fault_select"
        Me.btn_fault_select.Size = New System.Drawing.Size(75, 27)
        Me.btn_fault_select.TabIndex = 1
        Me.btn_fault_select.Text = "選擇"
        Me.btn_fault_select.UseVisualStyleBackColor = True
        Me.btn_fault_select.Visible = False
        '
        'ucl_txt_fault_cond
        '
        Me.ucl_txt_fault_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_fault_cond.Enabled = False
        Me.ucl_txt_fault_cond.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_fault_cond.Location = New System.Drawing.Point(0, 8)
        Me.ucl_txt_fault_cond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_fault_cond.MaxLength = 100
        Me.ucl_txt_fault_cond.Name = "ucl_txt_fault_cond"
        Me.ucl_txt_fault_cond.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_txt_fault_cond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_fault_cond.SelectionStart = 0
        Me.ucl_txt_fault_cond.Size = New System.Drawing.Size(710, 27)
        Me.ucl_txt_fault_cond.TabIndex = 0
        Me.ucl_txt_fault_cond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_fault_cond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_fault_cond.ToolTipTag = Nothing
        Me.ucl_txt_fault_cond.uclDollarSign = False
        Me.ucl_txt_fault_cond.uclDotCount = 0
        Me.ucl_txt_fault_cond.uclIntCount = 2
        Me.ucl_txt_fault_cond.uclMinus = False
        Me.ucl_txt_fault_cond.uclReadOnly = False
        Me.ucl_txt_fault_cond.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_fault_cond.uclTrimZero = True
        Me.ucl_txt_fault_cond.Visible = False
        '
        'ucl_rt_faultmsg
        '
        Me.ucl_rt_faultmsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_rt_faultmsg.Location = New System.Drawing.Point(3, 30)
        Me.ucl_rt_faultmsg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_faultmsg.Name = "ucl_rt_faultmsg"
        Me.ucl_rt_faultmsg.Size = New System.Drawing.Size(857, 102)
        Me.ucl_rt_faultmsg.TabIndex = 3
        Me.ucl_rt_faultmsg.uclMaxLength = 32767
        Me.ucl_rt_faultmsg.uclReadOnly = False
        Me.ucl_rt_faultmsg.uclWordWrap = True
        '
        'lb_fault_sug_msg
        '
        Me.lb_fault_sug_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_fault_sug_msg.AutoSize = True
        Me.lb_fault_sug_msg.Location = New System.Drawing.Point(3, 7)
        Me.lb_fault_sug_msg.Name = "lb_fault_sug_msg"
        Me.lb_fault_sug_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_fault_sug_msg.TabIndex = 4
        Me.lb_fault_sug_msg.Text = "提示使用者訊息："
        '
        'lb_fault_cond
        '
        Me.lb_fault_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_fault_cond.AutoSize = True
        Me.lb_fault_cond.Location = New System.Drawing.Point(3, 139)
        Me.lb_fault_cond.Name = "lb_fault_cond"
        Me.lb_fault_cond.Size = New System.Drawing.Size(88, 16)
        Me.lb_fault_cond.TabIndex = 5
        Me.lb_fault_cond.Text = "續接條件："
        Me.lb_fault_cond.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.tlp_process)
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(894, 211)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "檢核說明處理設定"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'tlp_process
        '
        Me.tlp_process.ColumnCount = 1
        Me.tlp_process.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_process.Controls.Add(Me.ucl_rt_process_msg, 0, 1)
        Me.tlp_process.Controls.Add(Me.lb_process_msg, 0, 0)
        Me.tlp_process.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_process.Location = New System.Drawing.Point(3, 3)
        Me.tlp_process.Name = "tlp_process"
        Me.tlp_process.RowCount = 2
        Me.tlp_process.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlp_process.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.tlp_process.Size = New System.Drawing.Size(888, 205)
        Me.tlp_process.TabIndex = 0
        '
        'ucl_rt_process_msg
        '
        Me.ucl_rt_process_msg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_rt_process_msg.Location = New System.Drawing.Point(3, 30)
        Me.ucl_rt_process_msg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_process_msg.Name = "ucl_rt_process_msg"
        Me.ucl_rt_process_msg.Size = New System.Drawing.Size(885, 175)
        Me.ucl_rt_process_msg.TabIndex = 4
        Me.ucl_rt_process_msg.uclMaxLength = 32767
        Me.ucl_rt_process_msg.uclReadOnly = False
        Me.ucl_rt_process_msg.uclWordWrap = True
        '
        'lb_process_msg
        '
        Me.lb_process_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_process_msg.AutoSize = True
        Me.lb_process_msg.Location = New System.Drawing.Point(3, 7)
        Me.lb_process_msg.Name = "lb_process_msg"
        Me.lb_process_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_process_msg.TabIndex = 5
        Me.lb_process_msg.Text = "提示使用者訊息："
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv_CheckReason)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(894, 211)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "檢核規則理由"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv_CheckReason
        '
        Me.dgv_CheckReason.AllowUserToAddRows = False
        Me.dgv_CheckReason.AllowUserToOrderColumns = False
        Me.dgv_CheckReason.AllowUserToResizeColumns = True
        Me.dgv_CheckReason.AllowUserToResizeRows = False
        Me.dgv_CheckReason.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_CheckReason.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_CheckReason.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_CheckReason.ColumnHeadersHeight = 4
        Me.dgv_CheckReason.ColumnHeadersVisible = True
        Me.dgv_CheckReason.CurrentCell = Nothing
        Me.dgv_CheckReason.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_CheckReason.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_CheckReason.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_CheckReason.Location = New System.Drawing.Point(3, 3)
        Me.dgv_CheckReason.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_CheckReason.MultiSelect = False
        Me.dgv_CheckReason.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_CheckReason.Name = "dgv_CheckReason"
        Me.dgv_CheckReason.RowHeadersWidth = 41
        Me.dgv_CheckReason.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_CheckReason.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_CheckReason.Size = New System.Drawing.Size(887, 205)
        Me.dgv_CheckReason.TabIndex = 0
        Me.dgv_CheckReason.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_CheckReason.uclBatchColIndex = ""
        Me.dgv_CheckReason.uclClickToCheck = False
        Me.dgv_CheckReason.uclColumnAlignment = ""
        Me.dgv_CheckReason.uclColumnCheckBox = False
        Me.dgv_CheckReason.uclColumnControlType = ""
        Me.dgv_CheckReason.uclColumnWidth = ""
        Me.dgv_CheckReason.uclDoCellEnter = True
        Me.dgv_CheckReason.uclHasNewRow = False
        Me.dgv_CheckReason.uclHeaderText = ""
        Me.dgv_CheckReason.uclIsAlternatingRowsColors = True
        Me.dgv_CheckReason.uclIsComboBoxGridQuery = True
        Me.dgv_CheckReason.uclIsComboxClickTriggerDropDown = False
        Me.dgv_CheckReason.uclIsDoOrderCheck = True
        Me.dgv_CheckReason.uclIsSortable = False
        Me.dgv_CheckReason.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_CheckReason.uclNonVisibleColIndex = ""
        Me.dgv_CheckReason.uclReadOnly = False
        Me.dgv_CheckReason.uclShowCellBorder = False
        Me.dgv_CheckReason.uclSortColIndex = ""
        Me.dgv_CheckReason.uclTreeMode = False
        Me.dgv_CheckReason.uclVisibleColIndex = ""
        '
        'tlp_cond
        '
        Me.tlp_cond.ColumnCount = 1
        Me.tlp_cond.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond.Controls.Add(Me.btn_delete, 0, 0)
        Me.tlp_cond.Controls.Add(Me.btn_clear, 0, 1)
        Me.tlp_cond.Location = New System.Drawing.Point(830, 33)
        Me.tlp_cond.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_cond.Name = "tlp_cond"
        Me.tlp_cond.RowCount = 2
        Me.tlp_cond.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.tlp_cond.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.tlp_cond.Size = New System.Drawing.Size(116, 83)
        Me.tlp_cond.TabIndex = 9
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_delete.Location = New System.Drawing.Point(3, 7)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(90, 27)
        Me.btn_delete.TabIndex = 6
        Me.btn_delete.Text = "SF12-刪除"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_clear.Location = New System.Drawing.Point(3, 48)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 27)
        Me.btn_clear.TabIndex = 7
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'gb_createdrule
        '
        Me.gb_createdrule.Controls.Add(Me.tv_createdrule)
        Me.gb_createdrule.Controls.Add(Me.cb_showduringtime)
        Me.gb_createdrule.Location = New System.Drawing.Point(3, 532)
        Me.gb_createdrule.Name = "gb_createdrule"
        Me.gb_createdrule.Size = New System.Drawing.Size(998, 85)
        Me.gb_createdrule.TabIndex = 2
        Me.gb_createdrule.TabStop = False
        Me.gb_createdrule.Text = "目前已設定的規則"
        '
        'tv_createdrule
        '
        Me.tv_createdrule.Location = New System.Drawing.Point(3, 23)
        Me.tv_createdrule.Name = "tv_createdrule"
        Me.tv_createdrule.Size = New System.Drawing.Size(981, 56)
        Me.tv_createdrule.TabIndex = 1
        '
        'cb_showduringtime
        '
        Me.cb_showduringtime.AutoSize = True
        Me.cb_showduringtime.Location = New System.Drawing.Point(148, -2)
        Me.cb_showduringtime.Name = "cb_showduringtime"
        Me.cb_showduringtime.Size = New System.Drawing.Size(203, 20)
        Me.cb_showduringtime.TabIndex = 0
        Me.cb_showduringtime.Text = "只顯示未過期的條件規則"
        Me.cb_showduringtime.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.tlp_initcondition.SetColumnSpan(Me.FlowLayoutPanel1, 5)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_x)
        Me.FlowLayoutPanel1.Controls.Add(Me.ucl_txt_x)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_init_belong)
        Me.FlowLayoutPanel1.Controls.Add(Me.ucl_txt_belong_info)
        Me.FlowLayoutPanel1.Controls.Add(Me.condition_dtl)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(457, 31)
        Me.FlowLayoutPanel1.TabIndex = 13
        '
        'PUBRuleCheckUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 646)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBRuleCheckUI"
        Me.TabText = "檢核規則維護"
        Me.Text = "檢核規則維護"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.tlp_info.ResumeLayout(False)
        Me.tlp_info.PerformLayout()
        Me.tlp_initcondition.ResumeLayout(False)
        Me.gb_rulecontent.ResumeLayout(False)
        Me.tlp_rulecontent.ResumeLayout(False)
        Me.tlp_rulecontent.PerformLayout()
        Me.tlp_rulesubcontent.ResumeLayout(False)
        Me.tlp_rulesubcontent.PerformLayout()
        Me.tlp_checkposition.ResumeLayout(False)
        Me.tlp_checkposition.PerformLayout()
        Me.tlp_contentmodify.ResumeLayout(False)
        Me.tbc_content.ResumeLayout(False)
        Me.tp_exe_cond.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.tlp_checksuccess.ResumeLayout(False)
        Me.tlp_checksuccess.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.tlp_fault.ResumeLayout(False)
        Me.tlp_fault.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.tlp_process.ResumeLayout(False)
        Me.tlp_process.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.tlp_cond.ResumeLayout(False)
        Me.gb_createdrule.ResumeLayout(False)
        Me.gb_createdrule.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_info As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_rulecontent As System.Windows.Forms.GroupBox
    Friend WithEvents gb_createdrule As System.Windows.Forms.GroupBox
    Friend WithEvents lb_item_belong As System.Windows.Forms.Label
    Friend WithEvents lb_res_strength As System.Windows.Forms.Label
    Friend WithEvents lb_exe_type As System.Windows.Forms.Label
    Friend WithEvents lb_check_ident As System.Windows.Forms.Label
    Friend WithEvents lb_init_cond As System.Windows.Forms.Label
    Friend WithEvents tv_createdrule As System.Windows.Forms.TreeView
    Friend WithEvents cb_showduringtime As System.Windows.Forms.CheckBox
    Friend WithEvents ucl_txt_belong_info As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_comb_item_belong As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_res_strength As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_exe_type As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_check_ident As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents tlp_rulecontent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_rule_name As System.Windows.Forms.Label
    Friend WithEvents lb_eff_date As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_rule_name As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents tlp_rulesubcontent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents lb_to As System.Windows.Forms.Label
    Friend WithEvents ucl_dtp_start_eff_date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents ucl_dtp_end_eff_date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lb_exe_location As System.Windows.Forms.Label
    Friend WithEvents vtn_clone_rule As System.Windows.Forms.Button
    Friend WithEvents lb_init_belong As System.Windows.Forms.Label
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents cb_fi As System.Windows.Forms.CheckBox
    Friend WithEvents cb_fe As System.Windows.Forms.CheckBox
    Friend WithEvents cb_fo As System.Windows.Forms.CheckBox
    Friend WithEvents tlp_initcondition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_x As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_x As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents condition_dtl As System.Windows.Forms.Button
    Friend WithEvents tlp_checkposition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_contentmodify As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_removegrid As System.Windows.Forms.Button
    Friend WithEvents btn_addgrid As System.Windows.Forms.Button
    Friend WithEvents tbc_content As System.Windows.Forms.TabControl
    Friend WithEvents tp_exe_cond As System.Windows.Forms.TabPage
    Friend WithEvents ucl_dgv_detail As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tlp_checksuccess As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_success_cond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_success_select As System.Windows.Forms.Button
    Friend WithEvents ucl_rt_successmsg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tlp_fault As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_fault_cond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_fault_select As System.Windows.Forms.Button
    Friend WithEvents ucl_rt_faultmsg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents tlp_process As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_rt_process_msg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents cb_boe As System.Windows.Forms.CheckBox
    Friend WithEvents cb_bi As System.Windows.Forms.CheckBox
    Friend WithEvents lb_client As System.Windows.Forms.Label
    Friend WithEvents lb_server As System.Windows.Forms.Label
    Friend WithEvents tlp_cond As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents lb_success_sug_msg As System.Windows.Forms.Label
    Friend WithEvents lb_success_cond As System.Windows.Forms.Label
    Friend WithEvents lb_fault_sug_msg As System.Windows.Forms.Label
    Friend WithEvents lb_fault_cond As System.Windows.Forms.Label
    Friend WithEvents lb_process_msg As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdo_isPrY As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_isPrN As System.Windows.Forms.RadioButton
    Friend WithEvents txt_message As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_CheckReason As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
End Class
