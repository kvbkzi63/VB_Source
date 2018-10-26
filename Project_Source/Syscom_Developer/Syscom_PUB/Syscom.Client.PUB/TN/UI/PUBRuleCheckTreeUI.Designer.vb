<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleCheckTreeUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRuleCheckTreeUI))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gb_parent = New System.Windows.Forms.GroupBox()
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_rulecontent = New System.Windows.Forms.GroupBox()
        Me.tlp_rulecontent = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.lb_res_strength = New System.Windows.Forms.Label()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.tlp_rulesubcontent = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_msg = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_server = New System.Windows.Forms.Label()
        Me.tlp_contentinfo05_01 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_boe = New System.Windows.Forms.CheckBox()
        Me.cb_bi = New System.Windows.Forms.CheckBox()
        Me.tlp_contentmodify = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_addgrid = New System.Windows.Forms.Button()
        Me.tbc_content = New System.Windows.Forms.TabControl()
        Me.tp_exe_cond = New System.Windows.Forms.TabPage()
        Me.tl_detail = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ckbIsSortedByName = New System.Windows.Forms.CheckBox()
        Me.tp_success = New System.Windows.Forms.TabPage()
        Me.tlp_checksuccess = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_successcontinue = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_txt_success_cond = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_success_select = New System.Windows.Forms.Button()
        Me.ucl_rt_successmsg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_success_sug_msg = New System.Windows.Forms.Label()
        Me.lb_success_cond = New System.Windows.Forms.Label()
        Me.tp_fault = New System.Windows.Forms.TabPage()
        Me.tlp_fault = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_faultcontinue = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_fault_select = New System.Windows.Forms.Button()
        Me.ucl_txt_fault_cond = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_rt_faultmsg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_fault_sug_msg = New System.Windows.Forms.Label()
        Me.lb_fault_cond = New System.Windows.Forms.Label()
        Me.tp_describe = New System.Windows.Forms.TabPage()
        Me.tlp_process = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_rt_process_msg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.lb_process_msg = New System.Windows.Forms.Label()
        Me.btn_addsubgrid = New System.Windows.Forms.Button()
        Me.btn_removegrid = New System.Windows.Forms.Button()
        Me.vtn_clone_rule = New System.Windows.Forms.Button()
        Me.tlp_contentinfo02 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_comb_check_ident = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_check_ident = New System.Windows.Forms.Label()
        Me.lb_exe_type = New System.Windows.Forms.Label()
        Me.ucl_comb_exe_type = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ucl_comb_res_strength = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_rule_name = New System.Windows.Forms.Label()
        Me.ucl_txt_rule_name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.lb_item_belong = New System.Windows.Forms.Label()
        Me.tlp_contentinfo01 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_comb_item_belong = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_init_cond = New System.Windows.Forms.Label()
        Me.tlp_initcondition = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_x = New System.Windows.Forms.Label()
        Me.lb_init_belong = New System.Windows.Forms.Label()
        Me.ucl_txt_x = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_txt_belong_info = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.condition_dtl = New System.Windows.Forms.Button()
        Me.lb_eff_date = New System.Windows.Forms.Label()
        Me.tlp_contentinfo04 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_dtp_end_eff_date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_exe_location = New System.Windows.Forms.Label()
        Me.lb_to = New System.Windows.Forms.Label()
        Me.ucl_dtp_start_eff_date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_client = New System.Windows.Forms.Label()
        Me.tlp_contentinfo04_01 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_fo = New System.Windows.Forms.CheckBox()
        Me.cb_fi = New System.Windows.Forms.CheckBox()
        Me.cb_fe = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gb_settedrule = New System.Windows.Forms.GroupBox()
        Me.ucl_dgv_detail = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tv_createdrule = New System.Windows.Forms.TreeView()
        Me.cb_showduringtime = New System.Windows.Forms.CheckBox()
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
        Me.gb_rulecontent.SuspendLayout()
        Me.tlp_rulecontent.SuspendLayout()
        Me.tlp_rulesubcontent.SuspendLayout()
        Me.tlp_contentinfo05_01.SuspendLayout()
        Me.tlp_contentmodify.SuspendLayout()
        Me.tbc_content.SuspendLayout()
        Me.tp_exe_cond.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tp_success.SuspendLayout()
        Me.tlp_checksuccess.SuspendLayout()
        Me.tlp_successcontinue.SuspendLayout()
        Me.tp_fault.SuspendLayout()
        Me.tlp_fault.SuspendLayout()
        Me.tlp_faultcontinue.SuspendLayout()
        Me.tp_describe.SuspendLayout()
        Me.tlp_process.SuspendLayout()
        Me.tlp_contentinfo02.SuspendLayout()
        Me.tlp_contentinfo01.SuspendLayout()
        Me.tlp_initcondition.SuspendLayout()
        Me.tlp_contentinfo04.SuspendLayout()
        Me.tlp_contentinfo04_01.SuspendLayout()
        Me.gb_settedrule.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_frame)
        Me.gb_parent.Location = New System.Drawing.Point(0, 0)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(1016, 646)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_frame.Controls.Add(Me.gb_rulecontent, 0, 0)
        Me.tlp_frame.Controls.Add(Me.gb_settedrule, 0, 1)
        Me.tlp_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_frame.Location = New System.Drawing.Point(3, 23)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 2
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_frame.Size = New System.Drawing.Size(1010, 620)
        Me.tlp_frame.TabIndex = 0
        '
        'gb_rulecontent
        '
        Me.gb_rulecontent.Controls.Add(Me.tlp_rulecontent)
        Me.gb_rulecontent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_rulecontent.Location = New System.Drawing.Point(3, 3)
        Me.gb_rulecontent.Name = "gb_rulecontent"
        Me.gb_rulecontent.Size = New System.Drawing.Size(1004, 484)
        Me.gb_rulecontent.TabIndex = 1
        Me.gb_rulecontent.TabStop = False
        Me.gb_rulecontent.Text = "規則內容"
        '
        'tlp_rulecontent
        '
        Me.tlp_rulecontent.ColumnCount = 3
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_rulecontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.tlp_rulecontent.Controls.Add(Me.btn_clear, 2, 4)
        Me.tlp_rulecontent.Controls.Add(Me.btn_delete, 2, 3)
        Me.tlp_rulecontent.Controls.Add(Me.lb_res_strength, 0, 1)
        Me.tlp_rulecontent.Controls.Add(Me.btn_query, 2, 0)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_rulesubcontent, 1, 4)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_contentmodify, 0, 5)
        Me.tlp_rulecontent.Controls.Add(Me.vtn_clone_rule, 2, 1)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_contentinfo02, 1, 1)
        Me.tlp_rulecontent.Controls.Add(Me.lb_rule_name, 0, 2)
        Me.tlp_rulecontent.Controls.Add(Me.ucl_txt_rule_name, 1, 2)
        Me.tlp_rulecontent.Controls.Add(Me.btn_save, 2, 2)
        Me.tlp_rulecontent.Controls.Add(Me.lb_item_belong, 0, 0)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_contentinfo01, 1, 0)
        Me.tlp_rulecontent.Controls.Add(Me.lb_eff_date, 0, 3)
        Me.tlp_rulecontent.Controls.Add(Me.tlp_contentinfo04, 1, 3)
        Me.tlp_rulecontent.Controls.Add(Me.Label1, 0, 4)
        Me.tlp_rulecontent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_rulecontent.Location = New System.Drawing.Point(3, 23)
        Me.tlp_rulecontent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_rulecontent.Name = "tlp_rulecontent"
        Me.tlp_rulecontent.RowCount = 6
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_rulecontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_rulecontent.Size = New System.Drawing.Size(998, 458)
        Me.tlp_rulecontent.TabIndex = 0
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_clear.Location = New System.Drawing.Point(905, 143)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_clear.TabIndex = 7
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_delete.Location = New System.Drawing.Point(905, 108)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_delete.TabIndex = 6
        Me.btn_delete.Text = "SF12-刪除"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'lb_res_strength
        '
        Me.lb_res_strength.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_res_strength.AutoSize = True
        Me.lb_res_strength.ForeColor = System.Drawing.Color.Red
        Me.lb_res_strength.Location = New System.Drawing.Point(7, 44)
        Me.lb_res_strength.Name = "lb_res_strength"
        Me.lb_res_strength.Size = New System.Drawing.Size(120, 16)
        Me.lb_res_strength.TabIndex = 1
        Me.lb_res_strength.Text = "檢核限制強度："
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_query.Location = New System.Drawing.Point(905, 3)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(90, 28)
        Me.btn_query.TabIndex = 8
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'tlp_rulesubcontent
        '
        Me.tlp_rulesubcontent.ColumnCount = 6
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.tlp_rulesubcontent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195.0!))
        Me.tlp_rulesubcontent.Controls.Add(Me.txt_msg, 0, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.lb_server, 4, 0)
        Me.tlp_rulesubcontent.Controls.Add(Me.tlp_contentinfo05_01, 5, 0)
        Me.tlp_rulesubcontent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_rulesubcontent.Location = New System.Drawing.Point(130, 140)
        Me.tlp_rulesubcontent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_rulesubcontent.Name = "tlp_rulesubcontent"
        Me.tlp_rulesubcontent.RowCount = 1
        Me.tlp_rulesubcontent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_rulesubcontent.Size = New System.Drawing.Size(772, 35)
        Me.tlp_rulesubcontent.TabIndex = 4
        '
        'txt_msg
        '
        Me.txt_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_rulesubcontent.SetColumnSpan(Me.txt_msg, 3)
        Me.txt_msg.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.txt_msg.Location = New System.Drawing.Point(3, 4)
        Me.txt_msg.MaxLength = 100
        Me.txt_msg.Name = "txt_msg"
        Me.txt_msg.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_msg.SelectionStart = 0
        Me.txt_msg.Size = New System.Drawing.Size(296, 27)
        Me.txt_msg.TabIndex = 14
        Me.txt_msg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_msg.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_msg.uclDollarSign = False
        Me.txt_msg.uclDotCount = 0
        Me.txt_msg.uclIntCount = 2
        Me.txt_msg.uclMinus = False
        Me.txt_msg.uclReadOnly = False
        Me.txt_msg.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_msg.uclTrimZero = True
        '
        'lb_server
        '
        Me.lb_server.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_server.AutoSize = True
        Me.lb_server.Location = New System.Drawing.Point(495, 9)
        Me.lb_server.Name = "lb_server"
        Me.lb_server.Size = New System.Drawing.Size(40, 16)
        Me.lb_server.TabIndex = 12
        Me.lb_server.Text = "申報"
        '
        'tlp_contentinfo05_01
        '
        Me.tlp_contentinfo05_01.ColumnCount = 3
        Me.tlp_contentinfo05_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo05_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo05_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo05_01.Controls.Add(Me.cb_boe, 0, 0)
        Me.tlp_contentinfo05_01.Controls.Add(Me.cb_bi, 2, 0)
        Me.tlp_contentinfo05_01.Location = New System.Drawing.Point(577, 0)
        Me.tlp_contentinfo05_01.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentinfo05_01.Name = "tlp_contentinfo05_01"
        Me.tlp_contentinfo05_01.RowCount = 1
        Me.tlp_contentinfo05_01.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo05_01.Size = New System.Drawing.Size(195, 35)
        Me.tlp_contentinfo05_01.TabIndex = 13
        '
        'cb_boe
        '
        Me.cb_boe.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_boe.AutoSize = True
        Me.tlp_contentinfo05_01.SetColumnSpan(Me.cb_boe, 2)
        Me.cb_boe.Location = New System.Drawing.Point(3, 7)
        Me.cb_boe.Name = "cb_boe"
        Me.cb_boe.Size = New System.Drawing.Size(75, 20)
        Me.cb_boe.TabIndex = 9
        Me.cb_boe.Text = "門急診"
        Me.cb_boe.UseVisualStyleBackColor = True
        '
        'cb_bi
        '
        Me.cb_bi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_bi.AutoSize = True
        Me.cb_bi.Location = New System.Drawing.Point(133, 7)
        Me.cb_bi.Name = "cb_bi"
        Me.cb_bi.Size = New System.Drawing.Size(59, 20)
        Me.cb_bi.TabIndex = 10
        Me.cb_bi.Text = "住院"
        Me.cb_bi.UseVisualStyleBackColor = True
        '
        'tlp_contentmodify
        '
        Me.tlp_contentmodify.ColumnCount = 2
        Me.tlp_rulecontent.SetColumnSpan(Me.tlp_contentmodify, 3)
        Me.tlp_contentmodify.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_contentmodify.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentmodify.Controls.Add(Me.btn_addgrid, 0, 0)
        Me.tlp_contentmodify.Controls.Add(Me.tbc_content, 1, 0)
        Me.tlp_contentmodify.Controls.Add(Me.btn_addsubgrid, 0, 1)
        Me.tlp_contentmodify.Controls.Add(Me.btn_removegrid, 0, 2)
        Me.tlp_contentmodify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_contentmodify.Location = New System.Drawing.Point(0, 175)
        Me.tlp_contentmodify.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentmodify.Name = "tlp_contentmodify"
        Me.tlp_contentmodify.RowCount = 4
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_contentmodify.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentmodify.Size = New System.Drawing.Size(998, 283)
        Me.tlp_contentmodify.TabIndex = 8
        '
        'btn_addgrid
        '
        Me.btn_addgrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_addgrid.Location = New System.Drawing.Point(3, 3)
        Me.btn_addgrid.Name = "btn_addgrid"
        Me.btn_addgrid.Size = New System.Drawing.Size(54, 54)
        Me.btn_addgrid.TabIndex = 0
        Me.btn_addgrid.Text = "新增條件"
        Me.btn_addgrid.UseVisualStyleBackColor = True
        '
        'tbc_content
        '
        Me.tbc_content.Controls.Add(Me.tp_exe_cond)
        Me.tbc_content.Controls.Add(Me.tp_success)
        Me.tbc_content.Controls.Add(Me.tp_fault)
        Me.tbc_content.Controls.Add(Me.tp_describe)
        Me.tbc_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbc_content.Location = New System.Drawing.Point(60, 3)
        Me.tbc_content.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tbc_content.Name = "tbc_content"
        Me.tlp_contentmodify.SetRowSpan(Me.tbc_content, 4)
        Me.tbc_content.SelectedIndex = 0
        Me.tbc_content.Size = New System.Drawing.Size(938, 280)
        Me.tbc_content.TabIndex = 7
        '
        'tp_exe_cond
        '
        Me.tp_exe_cond.Controls.Add(Me.tl_detail)
        Me.tp_exe_cond.Controls.Add(Me.FlowLayoutPanel1)
        Me.tp_exe_cond.Location = New System.Drawing.Point(4, 26)
        Me.tp_exe_cond.Name = "tp_exe_cond"
        Me.tp_exe_cond.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_exe_cond.Size = New System.Drawing.Size(930, 250)
        Me.tp_exe_cond.TabIndex = 0
        Me.tp_exe_cond.Text = "執行條件"
        Me.tp_exe_cond.UseVisualStyleBackColor = True
        '
        'tl_detail
        '
        Me.tl_detail.AllowUserToAddRows = False
        Me.tl_detail.AllowUserToOrderColumns = False
        Me.tl_detail.AllowUserToResizeColumns = True
        Me.tl_detail.AllowUserToResizeRows = False
        Me.tl_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tl_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tl_detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tl_detail.ColumnHeadersHeight = 4
        Me.tl_detail.ColumnHeadersVisible = True
        Me.tl_detail.CurrentCell = Nothing
        Me.tl_detail.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tl_detail.DefaultCellStyle = DataGridViewCellStyle2
        Me.tl_detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tl_detail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.tl_detail.Location = New System.Drawing.Point(3, 31)
        Me.tl_detail.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.tl_detail.MultiSelect = False
        Me.tl_detail.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.tl_detail.Name = "tl_detail"
        Me.tl_detail.RowHeadersWidth = 41
        Me.tl_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tl_detail.Size = New System.Drawing.Size(924, 216)
        Me.tl_detail.TabIndex = 2
        Me.tl_detail.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.tl_detail.uclBatchColIndex = ""
        Me.tl_detail.uclClickToCheck = False
        Me.tl_detail.uclColumnAlignment = ""
        Me.tl_detail.uclColumnCheckBox = True
        Me.tl_detail.uclColumnControlType = ""
        Me.tl_detail.uclColumnWidth = ""
        Me.tl_detail.uclDoCellEnter = True
        Me.tl_detail.uclHasNewRow = False
        Me.tl_detail.uclHeaderText = ""
        Me.tl_detail.uclIsAlternatingRowsColors = True
        Me.tl_detail.uclIsComboBoxGridQuery = True
        Me.tl_detail.uclIsDoOrderCheck = True
        Me.tl_detail.uclIsSortable = False
        Me.tl_detail.uclMultiSelectShowCheckBoxHeader = True
        Me.tl_detail.uclNonVisibleColIndex = ""
        Me.tl_detail.uclReadOnly = False
        Me.tl_detail.uclShowCellBorder = False
        Me.tl_detail.uclSortColIndex = ""
        Me.tl_detail.uclTreeMode = False
        Me.tl_detail.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.ckbIsSortedByName)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(924, 28)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'ckbIsSortedByName
        '
        Me.ckbIsSortedByName.AutoSize = True
        Me.ckbIsSortedByName.Location = New System.Drawing.Point(3, 3)
        Me.ckbIsSortedByName.Name = "ckbIsSortedByName"
        Me.ckbIsSortedByName.Size = New System.Drawing.Size(299, 20)
        Me.ckbIsSortedByName.TabIndex = 0
        Me.ckbIsSortedByName.Text = "畫面顯示條件內容依項目說明文字排序"
        Me.ckbIsSortedByName.UseVisualStyleBackColor = True
        '
        'tp_success
        '
        Me.tp_success.Controls.Add(Me.tlp_checksuccess)
        Me.tp_success.Location = New System.Drawing.Point(4, 26)
        Me.tp_success.Name = "tp_success"
        Me.tp_success.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_success.Size = New System.Drawing.Size(930, 255)
        Me.tp_success.TabIndex = 1
        Me.tp_success.Text = "檢核成功處理設定"
        Me.tp_success.UseVisualStyleBackColor = True
        '
        'tlp_checksuccess
        '
        Me.tlp_checksuccess.ColumnCount = 1
        Me.tlp_checksuccess.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_checksuccess.Controls.Add(Me.tlp_successcontinue, 0, 3)
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
        Me.tlp_checksuccess.Size = New System.Drawing.Size(924, 249)
        Me.tlp_checksuccess.TabIndex = 0
        '
        'tlp_successcontinue
        '
        Me.tlp_successcontinue.ColumnCount = 3
        Me.tlp_successcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tlp_successcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_successcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_successcontinue.Controls.Add(Me.ucl_txt_success_cond, 0, 0)
        Me.tlp_successcontinue.Controls.Add(Me.btn_success_select, 1, 0)
        Me.tlp_successcontinue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_successcontinue.Location = New System.Drawing.Point(0, 198)
        Me.tlp_successcontinue.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_successcontinue.Name = "tlp_successcontinue"
        Me.tlp_successcontinue.RowCount = 1
        Me.tlp_successcontinue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_successcontinue.Size = New System.Drawing.Size(924, 51)
        Me.tlp_successcontinue.TabIndex = 2
        Me.tlp_successcontinue.Visible = False
        '
        'ucl_txt_success_cond
        '
        Me.ucl_txt_success_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_success_cond.Enabled = False
        Me.ucl_txt_success_cond.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.ucl_txt_success_cond.Location = New System.Drawing.Point(0, 12)
        Me.ucl_txt_success_cond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_success_cond.MaxLength = 100
        Me.ucl_txt_success_cond.Name = "ucl_txt_success_cond"
        Me.ucl_txt_success_cond.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_txt_success_cond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_success_cond.SelectionStart = 0
        Me.ucl_txt_success_cond.Size = New System.Drawing.Size(736, 27)
        Me.ucl_txt_success_cond.TabIndex = 0
        Me.ucl_txt_success_cond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_success_cond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_success_cond.uclDollarSign = False
        Me.ucl_txt_success_cond.uclDotCount = 0
        Me.ucl_txt_success_cond.uclIntCount = 2
        Me.ucl_txt_success_cond.uclMinus = False
        Me.ucl_txt_success_cond.uclReadOnly = False
        Me.ucl_txt_success_cond.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_success_cond.uclTrimZero = True
        '
        'btn_success_select
        '
        Me.btn_success_select.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_success_select.Location = New System.Drawing.Point(742, 12)
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
        Me.ucl_rt_successmsg.Location = New System.Drawing.Point(3, 43)
        Me.ucl_rt_successmsg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_successmsg.Name = "ucl_rt_successmsg"
        Me.ucl_rt_successmsg.Size = New System.Drawing.Size(856, 112)
        Me.ucl_rt_successmsg.TabIndex = 3
        Me.ucl_rt_successmsg.uclMaxLength = 32767
        Me.ucl_rt_successmsg.uclReadOnly = False
        Me.ucl_rt_successmsg.uclWordWrap = True
        '
        'lb_success_sug_msg
        '
        Me.lb_success_sug_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_success_sug_msg.AutoSize = True
        Me.lb_success_sug_msg.Location = New System.Drawing.Point(3, 10)
        Me.lb_success_sug_msg.Name = "lb_success_sug_msg"
        Me.lb_success_sug_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_success_sug_msg.TabIndex = 4
        Me.lb_success_sug_msg.Text = "提示使用者訊息："
        '
        'lb_success_cond
        '
        Me.lb_success_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_success_cond.AutoSize = True
        Me.lb_success_cond.Location = New System.Drawing.Point(3, 171)
        Me.lb_success_cond.Name = "lb_success_cond"
        Me.lb_success_cond.Size = New System.Drawing.Size(88, 16)
        Me.lb_success_cond.TabIndex = 5
        Me.lb_success_cond.Text = "續接條件："
        Me.lb_success_cond.Visible = False
        '
        'tp_fault
        '
        Me.tp_fault.Controls.Add(Me.tlp_fault)
        Me.tp_fault.Location = New System.Drawing.Point(4, 26)
        Me.tp_fault.Name = "tp_fault"
        Me.tp_fault.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_fault.Size = New System.Drawing.Size(930, 255)
        Me.tp_fault.TabIndex = 2
        Me.tp_fault.Text = "檢核失敗處理設定"
        Me.tp_fault.UseVisualStyleBackColor = True
        '
        'tlp_fault
        '
        Me.tlp_fault.ColumnCount = 1
        Me.tlp_fault.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_fault.Controls.Add(Me.tlp_faultcontinue, 0, 3)
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
        Me.tlp_fault.Size = New System.Drawing.Size(924, 249)
        Me.tlp_fault.TabIndex = 1
        '
        'tlp_faultcontinue
        '
        Me.tlp_faultcontinue.ColumnCount = 3
        Me.tlp_faultcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tlp_faultcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_faultcontinue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_faultcontinue.Controls.Add(Me.btn_fault_select, 1, 0)
        Me.tlp_faultcontinue.Controls.Add(Me.ucl_txt_fault_cond, 0, 0)
        Me.tlp_faultcontinue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_faultcontinue.Location = New System.Drawing.Point(0, 198)
        Me.tlp_faultcontinue.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_faultcontinue.Name = "tlp_faultcontinue"
        Me.tlp_faultcontinue.RowCount = 1
        Me.tlp_faultcontinue.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_faultcontinue.Size = New System.Drawing.Size(924, 51)
        Me.tlp_faultcontinue.TabIndex = 2
        '
        'btn_fault_select
        '
        Me.btn_fault_select.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_fault_select.Location = New System.Drawing.Point(742, 12)
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
        Me.ucl_txt_fault_cond.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.ucl_txt_fault_cond.Location = New System.Drawing.Point(0, 12)
        Me.ucl_txt_fault_cond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_fault_cond.MaxLength = 100
        Me.ucl_txt_fault_cond.Name = "ucl_txt_fault_cond"
        Me.ucl_txt_fault_cond.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_txt_fault_cond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_fault_cond.SelectionStart = 0
        Me.ucl_txt_fault_cond.Size = New System.Drawing.Size(736, 27)
        Me.ucl_txt_fault_cond.TabIndex = 0
        Me.ucl_txt_fault_cond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_fault_cond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
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
        Me.ucl_rt_faultmsg.Location = New System.Drawing.Point(3, 43)
        Me.ucl_rt_faultmsg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_faultmsg.Name = "ucl_rt_faultmsg"
        Me.ucl_rt_faultmsg.Size = New System.Drawing.Size(857, 112)
        Me.ucl_rt_faultmsg.TabIndex = 3
        Me.ucl_rt_faultmsg.uclMaxLength = 32767
        Me.ucl_rt_faultmsg.uclReadOnly = False
        Me.ucl_rt_faultmsg.uclWordWrap = True
        '
        'lb_fault_sug_msg
        '
        Me.lb_fault_sug_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_fault_sug_msg.AutoSize = True
        Me.lb_fault_sug_msg.Location = New System.Drawing.Point(3, 10)
        Me.lb_fault_sug_msg.Name = "lb_fault_sug_msg"
        Me.lb_fault_sug_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_fault_sug_msg.TabIndex = 4
        Me.lb_fault_sug_msg.Text = "提示使用者訊息："
        '
        'lb_fault_cond
        '
        Me.lb_fault_cond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_fault_cond.AutoSize = True
        Me.lb_fault_cond.Location = New System.Drawing.Point(3, 171)
        Me.lb_fault_cond.Name = "lb_fault_cond"
        Me.lb_fault_cond.Size = New System.Drawing.Size(88, 16)
        Me.lb_fault_cond.TabIndex = 5
        Me.lb_fault_cond.Text = "續接條件："
        Me.lb_fault_cond.Visible = False
        '
        'tp_describe
        '
        Me.tp_describe.Controls.Add(Me.tlp_process)
        Me.tp_describe.Location = New System.Drawing.Point(4, 26)
        Me.tp_describe.Name = "tp_describe"
        Me.tp_describe.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_describe.Size = New System.Drawing.Size(930, 255)
        Me.tp_describe.TabIndex = 3
        Me.tp_describe.Text = "檢核說明處理設定"
        Me.tp_describe.UseVisualStyleBackColor = True
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
        Me.tlp_process.Size = New System.Drawing.Size(924, 249)
        Me.tlp_process.TabIndex = 0
        '
        'ucl_rt_process_msg
        '
        Me.ucl_rt_process_msg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_rt_process_msg.Location = New System.Drawing.Point(3, 37)
        Me.ucl_rt_process_msg.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ucl_rt_process_msg.Name = "ucl_rt_process_msg"
        Me.ucl_rt_process_msg.Size = New System.Drawing.Size(921, 212)
        Me.ucl_rt_process_msg.TabIndex = 4
        Me.ucl_rt_process_msg.uclMaxLength = 32767
        Me.ucl_rt_process_msg.uclReadOnly = False
        Me.ucl_rt_process_msg.uclWordWrap = True
        '
        'lb_process_msg
        '
        Me.lb_process_msg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_process_msg.AutoSize = True
        Me.lb_process_msg.Location = New System.Drawing.Point(3, 10)
        Me.lb_process_msg.Name = "lb_process_msg"
        Me.lb_process_msg.Size = New System.Drawing.Size(136, 16)
        Me.lb_process_msg.TabIndex = 5
        Me.lb_process_msg.Text = "提示使用者訊息："
        '
        'btn_addsubgrid
        '
        Me.btn_addsubgrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_addsubgrid.Location = New System.Drawing.Point(3, 63)
        Me.btn_addsubgrid.Name = "btn_addsubgrid"
        Me.btn_addsubgrid.Size = New System.Drawing.Size(54, 54)
        Me.btn_addsubgrid.TabIndex = 8
        Me.btn_addsubgrid.Text = "新增子項"
        Me.btn_addsubgrid.UseVisualStyleBackColor = True
        '
        'btn_removegrid
        '
        Me.btn_removegrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_removegrid.Location = New System.Drawing.Point(3, 123)
        Me.btn_removegrid.Name = "btn_removegrid"
        Me.btn_removegrid.Size = New System.Drawing.Size(54, 54)
        Me.btn_removegrid.TabIndex = 1
        Me.btn_removegrid.Text = "移除條件"
        Me.btn_removegrid.UseVisualStyleBackColor = True
        '
        'vtn_clone_rule
        '
        Me.vtn_clone_rule.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.vtn_clone_rule.Location = New System.Drawing.Point(905, 38)
        Me.vtn_clone_rule.Name = "vtn_clone_rule"
        Me.vtn_clone_rule.Size = New System.Drawing.Size(90, 28)
        Me.vtn_clone_rule.TabIndex = 10
        Me.vtn_clone_rule.Text = "複製規則"
        Me.vtn_clone_rule.UseVisualStyleBackColor = True
        '
        'tlp_contentinfo02
        '
        Me.tlp_contentinfo02.ColumnCount = 5
        Me.tlp_contentinfo02.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo02.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo02.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo02.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo02.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo02.Controls.Add(Me.ucl_comb_check_ident, 4, 0)
        Me.tlp_contentinfo02.Controls.Add(Me.lb_check_ident, 3, 0)
        Me.tlp_contentinfo02.Controls.Add(Me.lb_exe_type, 1, 0)
        Me.tlp_contentinfo02.Controls.Add(Me.ucl_comb_exe_type, 2, 0)
        Me.tlp_contentinfo02.Controls.Add(Me.ucl_comb_res_strength, 0, 0)
        Me.tlp_contentinfo02.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_contentinfo02.Location = New System.Drawing.Point(130, 35)
        Me.tlp_contentinfo02.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentinfo02.Name = "tlp_contentinfo02"
        Me.tlp_contentinfo02.RowCount = 1
        Me.tlp_contentinfo02.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo02.Size = New System.Drawing.Size(772, 35)
        Me.tlp_contentinfo02.TabIndex = 12
        '
        'ucl_comb_check_ident
        '
        Me.ucl_comb_check_ident.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_check_ident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_check_ident.DropDownWidth = 20
        Me.ucl_comb_check_ident.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_check_ident.Location = New System.Drawing.Point(520, 5)
        Me.ucl_comb_check_ident.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_check_ident.Name = "ucl_comb_check_ident"
        Me.ucl_comb_check_ident.SelectedIndex = -1
        Me.ucl_comb_check_ident.SelectedItem = Nothing
        Me.ucl_comb_check_ident.SelectedText = ""
        Me.ucl_comb_check_ident.SelectedValue = ""
        Me.ucl_comb_check_ident.SelectionStart = 0
        Me.ucl_comb_check_ident.Size = New System.Drawing.Size(144, 24)
        Me.ucl_comb_check_ident.TabIndex = 9
        Me.ucl_comb_check_ident.uclDisplayIndex = "0,1"
        Me.ucl_comb_check_ident.uclIsAutoClear = True
        Me.ucl_comb_check_ident.uclIsFirstItemEmpty = True
        Me.ucl_comb_check_ident.uclIsTextMode = False
        Me.ucl_comb_check_ident.uclShowMsg = False
        Me.ucl_comb_check_ident.uclValueIndex = "0"
        '
        'lb_check_ident
        '
        Me.lb_check_ident.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_check_ident.AutoSize = True
        Me.lb_check_ident.ForeColor = System.Drawing.Color.Red
        Me.lb_check_ident.Location = New System.Drawing.Point(397, 9)
        Me.lb_check_ident.Name = "lb_check_ident"
        Me.lb_check_ident.Size = New System.Drawing.Size(120, 16)
        Me.lb_check_ident.TabIndex = 3
        Me.lb_check_ident.Text = "檢核對象身分："
        '
        'lb_exe_type
        '
        Me.lb_exe_type.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_exe_type.AutoSize = True
        Me.lb_exe_type.ForeColor = System.Drawing.Color.Red
        Me.lb_exe_type.Location = New System.Drawing.Point(137, 9)
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
        Me.ucl_comb_exe_type.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_exe_type.Location = New System.Drawing.Point(260, 5)
        Me.ucl_comb_exe_type.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_exe_type.Name = "ucl_comb_exe_type"
        Me.ucl_comb_exe_type.SelectedIndex = -1
        Me.ucl_comb_exe_type.SelectedItem = Nothing
        Me.ucl_comb_exe_type.SelectedText = ""
        Me.ucl_comb_exe_type.SelectedValue = ""
        Me.ucl_comb_exe_type.SelectionStart = 0
        Me.ucl_comb_exe_type.Size = New System.Drawing.Size(124, 24)
        Me.ucl_comb_exe_type.TabIndex = 8
        Me.ucl_comb_exe_type.uclDisplayIndex = "0,1"
        Me.ucl_comb_exe_type.uclIsAutoClear = True
        Me.ucl_comb_exe_type.uclIsFirstItemEmpty = True
        Me.ucl_comb_exe_type.uclIsTextMode = False
        Me.ucl_comb_exe_type.uclShowMsg = False
        Me.ucl_comb_exe_type.uclValueIndex = "0"
        '
        'ucl_comb_res_strength
        '
        Me.ucl_comb_res_strength.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_res_strength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_res_strength.DropDownWidth = 20
        Me.ucl_comb_res_strength.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_res_strength.Location = New System.Drawing.Point(0, 5)
        Me.ucl_comb_res_strength.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_res_strength.Name = "ucl_comb_res_strength"
        Me.ucl_comb_res_strength.SelectedIndex = -1
        Me.ucl_comb_res_strength.SelectedItem = Nothing
        Me.ucl_comb_res_strength.SelectedText = ""
        Me.ucl_comb_res_strength.SelectedValue = ""
        Me.ucl_comb_res_strength.SelectionStart = 0
        Me.ucl_comb_res_strength.Size = New System.Drawing.Size(124, 24)
        Me.ucl_comb_res_strength.TabIndex = 7
        Me.ucl_comb_res_strength.uclDisplayIndex = "0,1"
        Me.ucl_comb_res_strength.uclIsAutoClear = True
        Me.ucl_comb_res_strength.uclIsFirstItemEmpty = True
        Me.ucl_comb_res_strength.uclIsTextMode = False
        Me.ucl_comb_res_strength.uclShowMsg = False
        Me.ucl_comb_res_strength.uclValueIndex = "0"
        '
        'lb_rule_name
        '
        Me.lb_rule_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_rule_name.AutoSize = True
        Me.lb_rule_name.ForeColor = System.Drawing.Color.Red
        Me.lb_rule_name.Location = New System.Drawing.Point(39, 79)
        Me.lb_rule_name.Name = "lb_rule_name"
        Me.lb_rule_name.Size = New System.Drawing.Size(88, 16)
        Me.lb_rule_name.TabIndex = 1
        Me.lb_rule_name.Text = "規則名稱："
        '
        'ucl_txt_rule_name
        '
        Me.ucl_txt_rule_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_rule_name.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.ucl_txt_rule_name.Location = New System.Drawing.Point(133, 74)
        Me.ucl_txt_rule_name.MaxLength = 100
        Me.ucl_txt_rule_name.Name = "ucl_txt_rule_name"
        Me.ucl_txt_rule_name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_rule_name.SelectionStart = 0
        Me.ucl_txt_rule_name.Size = New System.Drawing.Size(766, 27)
        Me.ucl_txt_rule_name.TabIndex = 3
        Me.ucl_txt_rule_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_rule_name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_rule_name.uclDollarSign = False
        Me.ucl_txt_rule_name.uclDotCount = 0
        Me.ucl_txt_rule_name.uclIntCount = 2
        Me.ucl_txt_rule_name.uclMinus = False
        Me.ucl_txt_rule_name.uclReadOnly = False
        Me.ucl_txt_rule_name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_rule_name.uclTrimZero = True
        '
        'btn_save
        '
        Me.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_save.Location = New System.Drawing.Point(905, 73)
        Me.btn_save.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(90, 28)
        Me.btn_save.TabIndex = 5
        Me.btn_save.Text = "F10-儲存"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'lb_item_belong
        '
        Me.lb_item_belong.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_item_belong.AutoSize = True
        Me.lb_item_belong.ForeColor = System.Drawing.Color.Red
        Me.lb_item_belong.Location = New System.Drawing.Point(7, 9)
        Me.lb_item_belong.Name = "lb_item_belong"
        Me.lb_item_belong.Size = New System.Drawing.Size(120, 16)
        Me.lb_item_belong.TabIndex = 0
        Me.lb_item_belong.Text = "規則歸屬項目："
        '
        'tlp_contentinfo01
        '
        Me.tlp_contentinfo01.ColumnCount = 3
        Me.tlp_contentinfo01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_contentinfo01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo01.Controls.Add(Me.ucl_comb_item_belong, 0, 0)
        Me.tlp_contentinfo01.Controls.Add(Me.lb_init_cond, 1, 0)
        Me.tlp_contentinfo01.Controls.Add(Me.tlp_initcondition, 2, 0)
        Me.tlp_contentinfo01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_contentinfo01.Location = New System.Drawing.Point(130, 0)
        Me.tlp_contentinfo01.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentinfo01.Name = "tlp_contentinfo01"
        Me.tlp_contentinfo01.RowCount = 1
        Me.tlp_contentinfo01.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo01.Size = New System.Drawing.Size(772, 35)
        Me.tlp_contentinfo01.TabIndex = 11
        '
        'ucl_comb_item_belong
        '
        Me.ucl_comb_item_belong.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_item_belong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_item_belong.DropDownWidth = 20
        Me.ucl_comb_item_belong.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_item_belong.Location = New System.Drawing.Point(0, 5)
        Me.ucl_comb_item_belong.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_item_belong.Name = "ucl_comb_item_belong"
        Me.ucl_comb_item_belong.SelectedIndex = -1
        Me.ucl_comb_item_belong.SelectedItem = Nothing
        Me.ucl_comb_item_belong.SelectedText = ""
        Me.ucl_comb_item_belong.SelectedValue = ""
        Me.ucl_comb_item_belong.SelectionStart = 0
        Me.ucl_comb_item_belong.Size = New System.Drawing.Size(124, 24)
        Me.ucl_comb_item_belong.TabIndex = 6
        Me.ucl_comb_item_belong.uclDisplayIndex = "0,1"
        Me.ucl_comb_item_belong.uclIsAutoClear = True
        Me.ucl_comb_item_belong.uclIsFirstItemEmpty = True
        Me.ucl_comb_item_belong.uclIsTextMode = False
        Me.ucl_comb_item_belong.uclShowMsg = False
        Me.ucl_comb_item_belong.uclValueIndex = "0"
        '
        'lb_init_cond
        '
        Me.lb_init_cond.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_init_cond.AutoSize = True
        Me.lb_init_cond.ForeColor = System.Drawing.Color.Red
        Me.lb_init_cond.Location = New System.Drawing.Point(165, 9)
        Me.lb_init_cond.Name = "lb_init_cond"
        Me.lb_init_cond.Size = New System.Drawing.Size(92, 16)
        Me.lb_init_cond.TabIndex = 4
        Me.lb_init_cond.Text = "起始條件： "
        '
        'tlp_initcondition
        '
        Me.tlp_initcondition.ColumnCount = 5
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.tlp_initcondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_initcondition.Controls.Add(Me.lb_x, 0, 0)
        Me.tlp_initcondition.Controls.Add(Me.lb_init_belong, 2, 0)
        Me.tlp_initcondition.Controls.Add(Me.ucl_txt_x, 1, 0)
        Me.tlp_initcondition.Controls.Add(Me.ucl_txt_belong_info, 3, 0)
        Me.tlp_initcondition.Controls.Add(Me.condition_dtl, 4, 0)
        Me.tlp_initcondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_initcondition.Location = New System.Drawing.Point(260, 0)
        Me.tlp_initcondition.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_initcondition.Name = "tlp_initcondition"
        Me.tlp_initcondition.RowCount = 1
        Me.tlp_initcondition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_initcondition.Size = New System.Drawing.Size(512, 35)
        Me.tlp_initcondition.TabIndex = 11
        '
        'lb_x
        '
        Me.lb_x.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_x.AutoSize = True
        Me.lb_x.Location = New System.Drawing.Point(3, 9)
        Me.lb_x.Name = "lb_x"
        Me.lb_x.Size = New System.Drawing.Size(1, 16)
        Me.lb_x.TabIndex = 0
        Me.lb_x.Text = "X = "
        '
        'lb_init_belong
        '
        Me.lb_init_belong.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lb_init_belong.AutoSize = True
        Me.lb_init_belong.ForeColor = System.Drawing.Color.Red
        Me.lb_init_belong.Location = New System.Drawing.Point(106, 9)
        Me.lb_init_belong.Name = "lb_init_belong"
        Me.lb_init_belong.Size = New System.Drawing.Size(57, 16)
        Me.lb_init_belong.TabIndex = 11
        Me.lb_init_belong.Text = "XXX = "
        '
        'ucl_txt_x
        '
        Me.ucl_txt_x.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ucl_txt_x.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.ucl_txt_x.Location = New System.Drawing.Point(7, 4)
        Me.ucl_txt_x.MaxLength = 10
        Me.ucl_txt_x.Name = "ucl_txt_x"
        Me.ucl_txt_x.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_x.SelectionStart = 0
        Me.ucl_txt_x.Size = New System.Drawing.Size(30, 27)
        Me.ucl_txt_x.TabIndex = 1
        Me.ucl_txt_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_x.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
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
        Me.ucl_txt_belong_info.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucl_txt_belong_info.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        Me.ucl_txt_belong_info.Location = New System.Drawing.Point(232, 4)
        Me.ucl_txt_belong_info.MaxLength = 1000
        Me.ucl_txt_belong_info.Name = "ucl_txt_belong_info"
        Me.ucl_txt_belong_info.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_belong_info.SelectionStart = 0
        Me.ucl_txt_belong_info.Size = New System.Drawing.Size(244, 27)
        Me.ucl_txt_belong_info.TabIndex = 5
        Me.ucl_txt_belong_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_belong_info.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
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
        Me.condition_dtl.Location = New System.Drawing.Point(482, 5)
        Me.condition_dtl.Name = "condition_dtl"
        Me.condition_dtl.Size = New System.Drawing.Size(27, 25)
        Me.condition_dtl.TabIndex = 12
        Me.condition_dtl.Text = "..."
        Me.condition_dtl.UseVisualStyleBackColor = True
        '
        'lb_eff_date
        '
        Me.lb_eff_date.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_eff_date.AutoSize = True
        Me.lb_eff_date.ForeColor = System.Drawing.Color.Red
        Me.lb_eff_date.Location = New System.Drawing.Point(39, 114)
        Me.lb_eff_date.Name = "lb_eff_date"
        Me.lb_eff_date.Size = New System.Drawing.Size(88, 16)
        Me.lb_eff_date.TabIndex = 2
        Me.lb_eff_date.Text = "生效日期："
        '
        'tlp_contentinfo04
        '
        Me.tlp_contentinfo04.ColumnCount = 6
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.tlp_contentinfo04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195.0!))
        Me.tlp_contentinfo04.Controls.Add(Me.ucl_dtp_end_eff_date, 2, 0)
        Me.tlp_contentinfo04.Controls.Add(Me.lb_exe_location, 3, 0)
        Me.tlp_contentinfo04.Controls.Add(Me.lb_to, 1, 0)
        Me.tlp_contentinfo04.Controls.Add(Me.ucl_dtp_start_eff_date, 0, 0)
        Me.tlp_contentinfo04.Controls.Add(Me.lb_client, 4, 0)
        Me.tlp_contentinfo04.Controls.Add(Me.tlp_contentinfo04_01, 5, 0)
        Me.tlp_contentinfo04.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_contentinfo04.Location = New System.Drawing.Point(130, 105)
        Me.tlp_contentinfo04.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentinfo04.Name = "tlp_contentinfo04"
        Me.tlp_contentinfo04.RowCount = 1
        Me.tlp_contentinfo04.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo04.Size = New System.Drawing.Size(772, 35)
        Me.tlp_contentinfo04.TabIndex = 13
        '
        'ucl_dtp_end_eff_date
        '
        Me.ucl_dtp_end_eff_date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_end_eff_date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_end_eff_date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_end_eff_date.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_end_eff_date.Location = New System.Drawing.Point(169, 4)
        Me.ucl_dtp_end_eff_date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_end_eff_date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_end_eff_date.Name = "ucl_dtp_end_eff_date"
        Me.ucl_dtp_end_eff_date.Size = New System.Drawing.Size(130, 27)
        Me.ucl_dtp_end_eff_date.TabIndex = 1
        Me.ucl_dtp_end_eff_date.uclReadOnly = False
        '
        'lb_exe_location
        '
        Me.lb_exe_location.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_exe_location.AutoSize = True
        Me.lb_exe_location.Location = New System.Drawing.Point(369, 9)
        Me.lb_exe_location.Name = "lb_exe_location"
        Me.lb_exe_location.Size = New System.Drawing.Size(120, 16)
        Me.lb_exe_location.TabIndex = 3
        Me.lb_exe_location.Text = "執行檢核位置："
        '
        'lb_to
        '
        Me.lb_to.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lb_to.AutoSize = True
        Me.lb_to.Location = New System.Drawing.Point(139, 9)
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
        Me.ucl_dtp_start_eff_date.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_start_eff_date.Location = New System.Drawing.Point(3, 4)
        Me.ucl_dtp_start_eff_date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_start_eff_date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_start_eff_date.Name = "ucl_dtp_start_eff_date"
        Me.ucl_dtp_start_eff_date.Size = New System.Drawing.Size(130, 27)
        Me.ucl_dtp_start_eff_date.TabIndex = 0
        Me.ucl_dtp_start_eff_date.uclReadOnly = False
        '
        'lb_client
        '
        Me.lb_client.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_client.AutoSize = True
        Me.lb_client.Location = New System.Drawing.Point(495, 9)
        Me.lb_client.Name = "lb_client"
        Me.lb_client.Size = New System.Drawing.Size(79, 16)
        Me.lb_client.TabIndex = 11
        Me.lb_client.Text = "醫囑/批價"
        '
        'tlp_contentinfo04_01
        '
        Me.tlp_contentinfo04_01.ColumnCount = 3
        Me.tlp_contentinfo04_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo04_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo04_01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tlp_contentinfo04_01.Controls.Add(Me.cb_fo, 0, 0)
        Me.tlp_contentinfo04_01.Controls.Add(Me.cb_fi, 2, 0)
        Me.tlp_contentinfo04_01.Controls.Add(Me.cb_fe, 1, 0)
        Me.tlp_contentinfo04_01.Location = New System.Drawing.Point(577, 0)
        Me.tlp_contentinfo04_01.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_contentinfo04_01.Name = "tlp_contentinfo04_01"
        Me.tlp_contentinfo04_01.RowCount = 1
        Me.tlp_contentinfo04_01.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_contentinfo04_01.Size = New System.Drawing.Size(195, 35)
        Me.tlp_contentinfo04_01.TabIndex = 12
        '
        'cb_fo
        '
        Me.cb_fo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_fo.AutoSize = True
        Me.cb_fo.Location = New System.Drawing.Point(3, 7)
        Me.cb_fo.Name = "cb_fo"
        Me.cb_fo.Size = New System.Drawing.Size(59, 20)
        Me.cb_fo.TabIndex = 6
        Me.cb_fo.Text = "門診"
        Me.cb_fo.UseVisualStyleBackColor = True
        '
        'cb_fi
        '
        Me.cb_fi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_fi.AutoSize = True
        Me.cb_fi.Location = New System.Drawing.Point(133, 7)
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
        Me.cb_fe.Location = New System.Drawing.Point(68, 7)
        Me.cb_fe.Name = "cb_fe"
        Me.cb_fe.Size = New System.Drawing.Size(59, 20)
        Me.cb_fe.TabIndex = 7
        Me.cb_fe.Text = "急診"
        Me.cb_fe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "聯絡人訊息"
        '
        'gb_settedrule
        '
        Me.gb_settedrule.Controls.Add(Me.ucl_dgv_detail)
        Me.gb_settedrule.Controls.Add(Me.tv_createdrule)
        Me.gb_settedrule.Controls.Add(Me.cb_showduringtime)
        Me.gb_settedrule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_settedrule.Location = New System.Drawing.Point(3, 493)
        Me.gb_settedrule.Name = "gb_settedrule"
        Me.gb_settedrule.Size = New System.Drawing.Size(1004, 124)
        Me.gb_settedrule.TabIndex = 2
        Me.gb_settedrule.TabStop = False
        Me.gb_settedrule.Text = "目前已設定的規則"
        '
        'ucl_dgv_detail
        '
        Me.ucl_dgv_detail.AllowUserToAddRows = False
        Me.ucl_dgv_detail.AllowUserToOrderColumns = False
        Me.ucl_dgv_detail.AllowUserToResizeColumns = True
        Me.ucl_dgv_detail.AllowUserToResizeRows = False
        Me.ucl_dgv_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucl_dgv_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ucl_dgv_detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ucl_dgv_detail.ColumnHeadersHeight = 4
        Me.ucl_dgv_detail.ColumnHeadersVisible = True
        Me.ucl_dgv_detail.CurrentCell = Nothing
        Me.ucl_dgv_detail.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_detail.DefaultCellStyle = DataGridViewCellStyle4
        Me.ucl_dgv_detail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_detail.Location = New System.Drawing.Point(4, 27)
        Me.ucl_dgv_detail.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_detail.MultiSelect = True
        Me.ucl_dgv_detail.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_detail.Name = "ucl_dgv_detail"
        Me.ucl_dgv_detail.RowHeadersWidth = 41
        Me.ucl_dgv_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_detail.Size = New System.Drawing.Size(725, 94)
        Me.ucl_dgv_detail.TabIndex = 0
        Me.ucl_dgv_detail.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucl_dgv_detail.uclBatchColIndex = ""
        Me.ucl_dgv_detail.uclClickToCheck = False
        Me.ucl_dgv_detail.uclColumnAlignment = ""
        Me.ucl_dgv_detail.uclColumnCheckBox = True
        Me.ucl_dgv_detail.uclColumnControlType = ""
        Me.ucl_dgv_detail.uclColumnWidth = ""
        Me.ucl_dgv_detail.uclDoCellEnter = True
        Me.ucl_dgv_detail.uclHasNewRow = False
        Me.ucl_dgv_detail.uclHeaderText = ""
        Me.ucl_dgv_detail.uclIsAlternatingRowsColors = True
        Me.ucl_dgv_detail.uclIsComboBoxGridQuery = True
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
        'tv_createdrule
        '
        Me.tv_createdrule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_createdrule.Location = New System.Drawing.Point(3, 23)
        Me.tv_createdrule.Name = "tv_createdrule"
        Me.tv_createdrule.Size = New System.Drawing.Size(998, 98)
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
        'PUBRuleCheckTreeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 646)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRuleCheckTreeUI"
        Me.TabText = "適應症檢核維護"
        Me.Text = "適應症檢核維護"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.gb_rulecontent.ResumeLayout(False)
        Me.tlp_rulecontent.ResumeLayout(False)
        Me.tlp_rulecontent.PerformLayout()
        Me.tlp_rulesubcontent.ResumeLayout(False)
        Me.tlp_rulesubcontent.PerformLayout()
        Me.tlp_contentinfo05_01.ResumeLayout(False)
        Me.tlp_contentinfo05_01.PerformLayout()
        Me.tlp_contentmodify.ResumeLayout(False)
        Me.tbc_content.ResumeLayout(False)
        Me.tp_exe_cond.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tp_success.ResumeLayout(False)
        Me.tlp_checksuccess.ResumeLayout(False)
        Me.tlp_checksuccess.PerformLayout()
        Me.tlp_successcontinue.ResumeLayout(False)
        Me.tp_fault.ResumeLayout(False)
        Me.tlp_fault.ResumeLayout(False)
        Me.tlp_fault.PerformLayout()
        Me.tlp_faultcontinue.ResumeLayout(False)
        Me.tp_describe.ResumeLayout(False)
        Me.tlp_process.ResumeLayout(False)
        Me.tlp_process.PerformLayout()
        Me.tlp_contentinfo02.ResumeLayout(False)
        Me.tlp_contentinfo02.PerformLayout()
        Me.tlp_contentinfo01.ResumeLayout(False)
        Me.tlp_contentinfo01.PerformLayout()
        Me.tlp_initcondition.ResumeLayout(False)
        Me.tlp_initcondition.PerformLayout()
        Me.tlp_contentinfo04.ResumeLayout(False)
        Me.tlp_contentinfo04.PerformLayout()
        Me.tlp_contentinfo04_01.ResumeLayout(False)
        Me.tlp_contentinfo04_01.PerformLayout()
        Me.gb_settedrule.ResumeLayout(False)
        Me.gb_settedrule.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_rulecontent As System.Windows.Forms.GroupBox
    Friend WithEvents gb_settedrule As System.Windows.Forms.GroupBox
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
    Friend WithEvents tlp_contentmodify As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_removegrid As System.Windows.Forms.Button
    Friend WithEvents btn_addgrid As System.Windows.Forms.Button
    Friend WithEvents tbc_content As System.Windows.Forms.TabControl
    Friend WithEvents tp_exe_cond As System.Windows.Forms.TabPage
    Friend WithEvents ucl_dgv_detail As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tp_success As System.Windows.Forms.TabPage
    Friend WithEvents tlp_checksuccess As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_successcontinue As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_success_cond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_success_select As System.Windows.Forms.Button
    Friend WithEvents ucl_rt_successmsg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents tp_fault As System.Windows.Forms.TabPage
    Friend WithEvents tlp_fault As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_faultcontinue As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_fault_cond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_fault_select As System.Windows.Forms.Button
    Friend WithEvents ucl_rt_faultmsg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents tp_describe As System.Windows.Forms.TabPage
    Friend WithEvents tlp_process As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_rt_process_msg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents cb_boe As System.Windows.Forms.CheckBox
    Friend WithEvents cb_bi As System.Windows.Forms.CheckBox
    Friend WithEvents lb_client As System.Windows.Forms.Label
    Friend WithEvents lb_server As System.Windows.Forms.Label
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents lb_success_sug_msg As System.Windows.Forms.Label
    Friend WithEvents lb_success_cond As System.Windows.Forms.Label
    Friend WithEvents lb_fault_sug_msg As System.Windows.Forms.Label
    Friend WithEvents lb_fault_cond As System.Windows.Forms.Label
    Friend WithEvents lb_process_msg As System.Windows.Forms.Label
    Friend WithEvents btn_addsubgrid As System.Windows.Forms.Button
    Friend WithEvents tlp_contentinfo01 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_contentinfo02 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_rulesubcontent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_contentinfo04 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_contentinfo04_01 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_contentinfo05_01 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_msg As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ckbIsSortedByName As System.Windows.Forms.CheckBox
    Friend WithEvents tl_detail As Syscom.Client.UCL.UCLDataGridViewUC
End Class
