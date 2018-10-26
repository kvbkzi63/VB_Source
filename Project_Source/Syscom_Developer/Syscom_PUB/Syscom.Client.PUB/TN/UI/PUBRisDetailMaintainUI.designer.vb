<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRisDetailMaintainUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRisDetailMaintainUI))
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_ordercode = New System.Windows.Forms.Label()
        Me.lb_Zh_name = New System.Windows.Forms.Label()
        Me.lb_En_name = New System.Windows.Forms.Label()
        Me.lb_formbelong = New System.Windows.Forms.Label()
        Me.tlp_cond1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_txt_dcreason = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_txt_ordercode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_disablereason = New System.Windows.Forms.Label()
        Me.lb_enabledate = New System.Windows.Forms.Label()
        Me.lb_disabledate = New System.Windows.Forms.Label()
        Me.ucl_dtp_disabledate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.ucl_dtp_enabledate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.tlp_cond4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_sheetbelong = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ucl_comb_side = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ucl_comb_ssite = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_sidepart = New System.Windows.Forms.Label()
        Me.lb_ssite = New System.Windows.Forms.Label()
        Me.lb_bsite = New System.Windows.Forms.Label()
        Me.ucl_comb_bsite = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_OpenNoCheckinDept = New System.Windows.Forms.Button()
        Me.tlp_cond2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_canscheduleflag = New System.Windows.Forms.CheckBox()
        Me.ucl_tst_Zh_name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.tlp_cond3 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk_RegistOnOrdering = New System.Windows.Forms.CheckBox()
        Me.ucl_txt_En_name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_useCM = New System.Windows.Forms.CheckBox()
        Me.cb_transferPACS = New System.Windows.Forms.CheckBox()
        Me.cb_side_need = New System.Windows.Forms.CheckBox()
        Me.cb_ssite_need = New System.Windows.Forms.CheckBox()
        Me.btn_ordercheck = New System.Windows.Forms.Button()
        Me.btn_orderindi = New System.Windows.Forms.Button()
        Me.cb_printindi = New System.Windows.Forms.CheckBox()
        Me.cb_bsite_need = New System.Windows.Forms.CheckBox()
        Me.btn_OpenNoPrintDept = New System.Windows.Forms.Button()
        Me.tlp_cond5 = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_ihr = New System.Windows.Forms.Label()
        Me.lb_ehr = New System.Windows.Forms.Label()
        Me.ucl_txt_Orpttime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_txt_Irpttime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_ipd_rpttime = New System.Windows.Forms.Label()
        Me.ucl_txt_Erpttime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_emg_rpttime = New System.Windows.Forms.Label()
        Me.lb_ohr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_NhiBodySiteCode = New System.Windows.Forms.TextBox()
        Me.chk_IsNoPrint = New System.Windows.Forms.CheckBox()
        Me.lb_opd_rpttime = New System.Windows.Forms.Label()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.gb_detail = New System.Windows.Forms.GroupBox()
        Me.ucl_rt_notify = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.cb_printapplynotif = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_OrderEntryNote = New System.Windows.Forms.TextBox()
        Me.tlp_parent.SuspendLayout()
        Me.tlp_cond1.SuspendLayout()
        Me.tlp_cond4.SuspendLayout()
        Me.tlp_cond2.SuspendLayout()
        Me.tlp_cond3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tlp_cond5.SuspendLayout()
        Me.gb_detail.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 2
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Controls.Add(Me.lb_ordercode, 0, 0)
        Me.tlp_parent.Controls.Add(Me.lb_Zh_name, 0, 1)
        Me.tlp_parent.Controls.Add(Me.lb_En_name, 0, 2)
        Me.tlp_parent.Controls.Add(Me.lb_formbelong, 0, 3)
        Me.tlp_parent.Controls.Add(Me.tlp_cond1, 1, 0)
        Me.tlp_parent.Controls.Add(Me.tlp_cond4, 1, 3)
        Me.tlp_parent.Controls.Add(Me.tlp_cond2, 1, 1)
        Me.tlp_parent.Controls.Add(Me.tlp_cond3, 1, 2)
        Me.tlp_parent.Controls.Add(Me.TableLayoutPanel3, 0, 5)
        Me.tlp_parent.Controls.Add(Me.tlp_cond5, 1, 4)
        Me.tlp_parent.Controls.Add(Me.lb_opd_rpttime, 0, 4)
        Me.tlp_parent.Controls.Add(Me.btn_confirm, 1, 8)
        Me.tlp_parent.Controls.Add(Me.gb_detail, 0, 7)
        Me.tlp_parent.Controls.Add(Me.GroupBox1, 0, 6)
        Me.tlp_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_parent.Location = New System.Drawing.Point(0, 0)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 9
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(1001, 512)
        Me.tlp_parent.TabIndex = 0
        '
        'lb_ordercode
        '
        Me.lb_ordercode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_ordercode.AutoSize = True
        Me.lb_ordercode.Location = New System.Drawing.Point(45, 12)
        Me.lb_ordercode.Name = "lb_ordercode"
        Me.lb_ordercode.Size = New System.Drawing.Size(72, 16)
        Me.lb_ordercode.TabIndex = 0
        Me.lb_ordercode.Text = "醫令代碼"
        '
        'lb_Zh_name
        '
        Me.lb_Zh_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Zh_name.AutoSize = True
        Me.lb_Zh_name.Location = New System.Drawing.Point(45, 52)
        Me.lb_Zh_name.Name = "lb_Zh_name"
        Me.lb_Zh_name.Size = New System.Drawing.Size(72, 16)
        Me.lb_Zh_name.TabIndex = 8
        Me.lb_Zh_name.Text = "中文名稱"
        '
        'lb_En_name
        '
        Me.lb_En_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_En_name.AutoSize = True
        Me.lb_En_name.Location = New System.Drawing.Point(45, 92)
        Me.lb_En_name.Name = "lb_En_name"
        Me.lb_En_name.Size = New System.Drawing.Size(72, 16)
        Me.lb_En_name.TabIndex = 11
        Me.lb_En_name.Text = "英文名稱"
        '
        'lb_formbelong
        '
        Me.lb_formbelong.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_formbelong.AutoSize = True
        Me.lb_formbelong.Location = New System.Drawing.Point(45, 132)
        Me.lb_formbelong.Name = "lb_formbelong"
        Me.lb_formbelong.Size = New System.Drawing.Size(72, 16)
        Me.lb_formbelong.TabIndex = 12
        Me.lb_formbelong.Text = "隸屬表單"
        '
        'tlp_cond1
        '
        Me.tlp_cond1.ColumnCount = 7
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond1.Controls.Add(Me.ucl_txt_dcreason, 6, 0)
        Me.tlp_cond1.Controls.Add(Me.ucl_txt_ordercode, 0, 0)
        Me.tlp_cond1.Controls.Add(Me.lb_disablereason, 5, 0)
        Me.tlp_cond1.Controls.Add(Me.lb_enabledate, 1, 0)
        Me.tlp_cond1.Controls.Add(Me.lb_disabledate, 3, 0)
        Me.tlp_cond1.Controls.Add(Me.ucl_dtp_disabledate, 4, 0)
        Me.tlp_cond1.Controls.Add(Me.ucl_dtp_enabledate, 2, 0)
        Me.tlp_cond1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_cond1.Location = New System.Drawing.Point(123, 3)
        Me.tlp_cond1.Name = "tlp_cond1"
        Me.tlp_cond1.RowCount = 1
        Me.tlp_cond1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond1.Size = New System.Drawing.Size(875, 34)
        Me.tlp_cond1.TabIndex = 28
        '
        'ucl_txt_dcreason
        '
        Me.ucl_txt_dcreason.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_dcreason.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_dcreason.Location = New System.Drawing.Point(723, 3)
        Me.ucl_txt_dcreason.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.ucl_txt_dcreason.MaxLength = 100
        Me.ucl_txt_dcreason.Name = "ucl_txt_dcreason"
        Me.ucl_txt_dcreason.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_dcreason.SelectionStart = 0
        Me.ucl_txt_dcreason.Size = New System.Drawing.Size(152, 27)
        Me.ucl_txt_dcreason.TabIndex = 7
        Me.ucl_txt_dcreason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_dcreason.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_dcreason.ToolTipTag = Nothing
        Me.ucl_txt_dcreason.uclDollarSign = False
        Me.ucl_txt_dcreason.uclDotCount = 0
        Me.ucl_txt_dcreason.uclIntCount = 2
        Me.ucl_txt_dcreason.uclMinus = False
        Me.ucl_txt_dcreason.uclReadOnly = False
        Me.ucl_txt_dcreason.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_dcreason.uclTrimZero = True
        '
        'ucl_txt_ordercode
        '
        Me.ucl_txt_ordercode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_ordercode.Enabled = False
        Me.ucl_txt_ordercode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_ordercode.Location = New System.Drawing.Point(0, 3)
        Me.ucl_txt_ordercode.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_ordercode.MaxLength = 20
        Me.ucl_txt_ordercode.Name = "ucl_txt_ordercode"
        Me.ucl_txt_ordercode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_ordercode.SelectionStart = 0
        Me.ucl_txt_ordercode.Size = New System.Drawing.Size(120, 27)
        Me.ucl_txt_ordercode.TabIndex = 1
        Me.ucl_txt_ordercode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_ordercode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_ordercode.ToolTipTag = Nothing
        Me.ucl_txt_ordercode.uclDollarSign = False
        Me.ucl_txt_ordercode.uclDotCount = 0
        Me.ucl_txt_ordercode.uclIntCount = 2
        Me.ucl_txt_ordercode.uclMinus = False
        Me.ucl_txt_ordercode.uclReadOnly = False
        Me.ucl_txt_ordercode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_ordercode.uclTrimZero = True
        '
        'lb_disablereason
        '
        Me.lb_disablereason.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_disablereason.AutoSize = True
        Me.lb_disablereason.Location = New System.Drawing.Point(645, 9)
        Me.lb_disablereason.Name = "lb_disablereason"
        Me.lb_disablereason.Size = New System.Drawing.Size(72, 16)
        Me.lb_disablereason.TabIndex = 6
        Me.lb_disablereason.Text = "停用理由"
        '
        'lb_enabledate
        '
        Me.lb_enabledate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_enabledate.AutoSize = True
        Me.lb_enabledate.Location = New System.Drawing.Point(165, 9)
        Me.lb_enabledate.Name = "lb_enabledate"
        Me.lb_enabledate.Size = New System.Drawing.Size(72, 16)
        Me.lb_enabledate.TabIndex = 2
        Me.lb_enabledate.Text = "啟用日期"
        '
        'lb_disabledate
        '
        Me.lb_disabledate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_disabledate.AutoSize = True
        Me.lb_disabledate.Location = New System.Drawing.Point(405, 9)
        Me.lb_disabledate.Name = "lb_disabledate"
        Me.lb_disabledate.Size = New System.Drawing.Size(72, 16)
        Me.lb_disabledate.TabIndex = 5
        Me.lb_disabledate.Text = "停用日期"
        '
        'ucl_dtp_disabledate
        '
        Me.ucl_dtp_disabledate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_disabledate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_disabledate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_disabledate.Enabled = False
        Me.ucl_dtp_disabledate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_disabledate.Location = New System.Drawing.Point(483, 3)
        Me.ucl_dtp_disabledate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_disabledate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_disabledate.Name = "ucl_dtp_disabledate"
        Me.ucl_dtp_disabledate.Size = New System.Drawing.Size(114, 27)
        Me.ucl_dtp_disabledate.TabIndex = 4
        Me.ucl_dtp_disabledate.uclIsFixedBackColor = False
        Me.ucl_dtp_disabledate.uclReadOnly = False
        '
        'ucl_dtp_enabledate
        '
        Me.ucl_dtp_enabledate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_enabledate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_enabledate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_enabledate.Enabled = False
        Me.ucl_dtp_enabledate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_enabledate.Location = New System.Drawing.Point(243, 3)
        Me.ucl_dtp_enabledate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_enabledate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_enabledate.Name = "ucl_dtp_enabledate"
        Me.ucl_dtp_enabledate.Size = New System.Drawing.Size(114, 27)
        Me.ucl_dtp_enabledate.TabIndex = 3
        Me.ucl_dtp_enabledate.uclIsFixedBackColor = False
        Me.ucl_dtp_enabledate.uclReadOnly = False
        '
        'tlp_cond4
        '
        Me.tlp_cond4.ColumnCount = 8
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116.0!))
        Me.tlp_cond4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond4.Controls.Add(Me.ucl_sheetbelong, 0, 0)
        Me.tlp_cond4.Controls.Add(Me.ucl_comb_side, 6, 0)
        Me.tlp_cond4.Controls.Add(Me.ucl_comb_ssite, 4, 0)
        Me.tlp_cond4.Controls.Add(Me.lb_sidepart, 5, 0)
        Me.tlp_cond4.Controls.Add(Me.lb_ssite, 3, 0)
        Me.tlp_cond4.Controls.Add(Me.lb_bsite, 1, 0)
        Me.tlp_cond4.Controls.Add(Me.ucl_comb_bsite, 2, 0)
        Me.tlp_cond4.Controls.Add(Me.btn_OpenNoCheckinDept, 7, 0)
        Me.tlp_cond4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_cond4.Location = New System.Drawing.Point(123, 123)
        Me.tlp_cond4.Name = "tlp_cond4"
        Me.tlp_cond4.RowCount = 1
        Me.tlp_cond4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond4.Size = New System.Drawing.Size(875, 34)
        Me.tlp_cond4.TabIndex = 29
        '
        'ucl_sheetbelong
        '
        Me.ucl_sheetbelong.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_sheetbelong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_sheetbelong.DropDownWidth = 20
        Me.ucl_sheetbelong.DroppedDown = False
        Me.ucl_sheetbelong.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_sheetbelong.Location = New System.Drawing.Point(0, 5)
        Me.ucl_sheetbelong.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_sheetbelong.Name = "ucl_sheetbelong"
        Me.ucl_sheetbelong.SelectedIndex = -1
        Me.ucl_sheetbelong.SelectedItem = Nothing
        Me.ucl_sheetbelong.SelectedText = ""
        Me.ucl_sheetbelong.SelectedValue = ""
        Me.ucl_sheetbelong.SelectionStart = 0
        Me.ucl_sheetbelong.Size = New System.Drawing.Size(135, 24)
        Me.ucl_sheetbelong.TabIndex = 21
        Me.ucl_sheetbelong.uclDisplayIndex = "0,1"
        Me.ucl_sheetbelong.uclIsAutoClear = True
        Me.ucl_sheetbelong.uclIsFirstItemEmpty = True
        Me.ucl_sheetbelong.uclIsTextMode = False
        Me.ucl_sheetbelong.uclShowMsg = False
        Me.ucl_sheetbelong.uclValueIndex = "0"
        '
        'ucl_comb_side
        '
        Me.ucl_comb_side.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_side.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_side.DropDownWidth = 20
        Me.ucl_comb_side.DroppedDown = False
        Me.ucl_comb_side.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_side.Location = New System.Drawing.Point(600, 5)
        Me.ucl_comb_side.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_side.Name = "ucl_comb_side"
        Me.ucl_comb_side.SelectedIndex = -1
        Me.ucl_comb_side.SelectedItem = Nothing
        Me.ucl_comb_side.SelectedText = ""
        Me.ucl_comb_side.SelectedValue = ""
        Me.ucl_comb_side.SelectionStart = 0
        Me.ucl_comb_side.Size = New System.Drawing.Size(112, 24)
        Me.ucl_comb_side.TabIndex = 23
        Me.ucl_comb_side.uclDisplayIndex = "0,1"
        Me.ucl_comb_side.uclIsAutoClear = True
        Me.ucl_comb_side.uclIsFirstItemEmpty = True
        Me.ucl_comb_side.uclIsTextMode = False
        Me.ucl_comb_side.uclShowMsg = False
        Me.ucl_comb_side.uclValueIndex = "0"
        '
        'ucl_comb_ssite
        '
        Me.ucl_comb_ssite.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_ssite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_ssite.DropDownWidth = 20
        Me.ucl_comb_ssite.DroppedDown = False
        Me.ucl_comb_ssite.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_ssite.Location = New System.Drawing.Point(405, 5)
        Me.ucl_comb_ssite.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_ssite.Name = "ucl_comb_ssite"
        Me.ucl_comb_ssite.SelectedIndex = -1
        Me.ucl_comb_ssite.SelectedItem = Nothing
        Me.ucl_comb_ssite.SelectedText = ""
        Me.ucl_comb_ssite.SelectedValue = ""
        Me.ucl_comb_ssite.SelectionStart = 0
        Me.ucl_comb_ssite.Size = New System.Drawing.Size(112, 24)
        Me.ucl_comb_ssite.TabIndex = 27
        Me.ucl_comb_ssite.uclDisplayIndex = "0,1"
        Me.ucl_comb_ssite.uclIsAutoClear = True
        Me.ucl_comb_ssite.uclIsFirstItemEmpty = True
        Me.ucl_comb_ssite.uclIsTextMode = False
        Me.ucl_comb_ssite.uclShowMsg = False
        Me.ucl_comb_ssite.uclValueIndex = "0"
        '
        'lb_sidepart
        '
        Me.lb_sidepart.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_sidepart.AutoSize = True
        Me.lb_sidepart.Location = New System.Drawing.Point(557, 9)
        Me.lb_sidepart.Name = "lb_sidepart"
        Me.lb_sidepart.Size = New System.Drawing.Size(40, 16)
        Me.lb_sidepart.TabIndex = 25
        Me.lb_sidepart.Text = "側位"
        '
        'lb_ssite
        '
        Me.lb_ssite.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_ssite.AutoSize = True
        Me.lb_ssite.Location = New System.Drawing.Point(346, 9)
        Me.lb_ssite.Name = "lb_ssite"
        Me.lb_ssite.Size = New System.Drawing.Size(56, 16)
        Me.lb_ssite.TabIndex = 24
        Me.lb_ssite.Text = "細部位"
        '
        'lb_bsite
        '
        Me.lb_bsite.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_bsite.AutoSize = True
        Me.lb_bsite.Location = New System.Drawing.Point(151, 9)
        Me.lb_bsite.Name = "lb_bsite"
        Me.lb_bsite.Size = New System.Drawing.Size(56, 16)
        Me.lb_bsite.TabIndex = 26
        Me.lb_bsite.Text = "大部位"
        '
        'ucl_comb_bsite
        '
        Me.ucl_comb_bsite.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_bsite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_bsite.DropDownWidth = 20
        Me.ucl_comb_bsite.DroppedDown = False
        Me.ucl_comb_bsite.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_bsite.Location = New System.Drawing.Point(210, 5)
        Me.ucl_comb_bsite.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_bsite.Name = "ucl_comb_bsite"
        Me.ucl_comb_bsite.SelectedIndex = -1
        Me.ucl_comb_bsite.SelectedItem = Nothing
        Me.ucl_comb_bsite.SelectedText = ""
        Me.ucl_comb_bsite.SelectedValue = ""
        Me.ucl_comb_bsite.SelectionStart = 0
        Me.ucl_comb_bsite.Size = New System.Drawing.Size(112, 24)
        Me.ucl_comb_bsite.TabIndex = 22
        Me.ucl_comb_bsite.uclDisplayIndex = "0,1"
        Me.ucl_comb_bsite.uclIsAutoClear = True
        Me.ucl_comb_bsite.uclIsFirstItemEmpty = True
        Me.ucl_comb_bsite.uclIsTextMode = False
        Me.ucl_comb_bsite.uclShowMsg = False
        Me.ucl_comb_bsite.uclValueIndex = "0"
        '
        'btn_OpenNoCheckinDept
        '
        Me.btn_OpenNoCheckinDept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_OpenNoCheckinDept.Location = New System.Drawing.Point(716, 3)
        Me.btn_OpenNoCheckinDept.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_OpenNoCheckinDept.Name = "btn_OpenNoCheckinDept"
        Me.btn_OpenNoCheckinDept.Size = New System.Drawing.Size(159, 28)
        Me.btn_OpenNoCheckinDept.TabIndex = 18
        Me.btn_OpenNoCheckinDept.Text = "設定不須報到部門"
        Me.btn_OpenNoCheckinDept.UseVisualStyleBackColor = True
        '
        'tlp_cond2
        '
        Me.tlp_cond2.ColumnCount = 2
        Me.tlp_cond2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_cond2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
        Me.tlp_cond2.Controls.Add(Me.cb_canscheduleflag, 1, 0)
        Me.tlp_cond2.Controls.Add(Me.ucl_tst_Zh_name, 0, 0)
        Me.tlp_cond2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_cond2.Location = New System.Drawing.Point(123, 43)
        Me.tlp_cond2.Name = "tlp_cond2"
        Me.tlp_cond2.RowCount = 1
        Me.tlp_cond2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_cond2.Size = New System.Drawing.Size(875, 34)
        Me.tlp_cond2.TabIndex = 32
        '
        'cb_canscheduleflag
        '
        Me.cb_canscheduleflag.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_canscheduleflag.AutoSize = True
        Me.cb_canscheduleflag.Location = New System.Drawing.Point(723, 7)
        Me.cb_canscheduleflag.Name = "cb_canscheduleflag"
        Me.cb_canscheduleflag.Size = New System.Drawing.Size(107, 20)
        Me.cb_canscheduleflag.TabIndex = 17
        Me.cb_canscheduleflag.Text = "可排程註記"
        Me.cb_canscheduleflag.UseVisualStyleBackColor = True
        '
        'ucl_tst_Zh_name
        '
        Me.ucl_tst_Zh_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_tst_Zh_name.Enabled = False
        Me.ucl_tst_Zh_name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_tst_Zh_name.Location = New System.Drawing.Point(0, 3)
        Me.ucl_tst_Zh_name.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_tst_Zh_name.MaxLength = 100
        Me.ucl_tst_Zh_name.Name = "ucl_tst_Zh_name"
        Me.ucl_tst_Zh_name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_tst_Zh_name.SelectionStart = 0
        Me.ucl_tst_Zh_name.Size = New System.Drawing.Size(717, 27)
        Me.ucl_tst_Zh_name.TabIndex = 9
        Me.ucl_tst_Zh_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_tst_Zh_name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_tst_Zh_name.ToolTipTag = Nothing
        Me.ucl_tst_Zh_name.uclDollarSign = False
        Me.ucl_tst_Zh_name.uclDotCount = 0
        Me.ucl_tst_Zh_name.uclIntCount = 2
        Me.ucl_tst_Zh_name.uclMinus = False
        Me.ucl_tst_Zh_name.uclReadOnly = False
        Me.ucl_tst_Zh_name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_tst_Zh_name.uclTrimZero = True
        '
        'tlp_cond3
        '
        Me.tlp_cond3.ColumnCount = 2
        Me.tlp_cond3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_cond3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.tlp_cond3.Controls.Add(Me.chk_RegistOnOrdering, 1, 0)
        Me.tlp_cond3.Controls.Add(Me.ucl_txt_En_name, 0, 0)
        Me.tlp_cond3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_cond3.Location = New System.Drawing.Point(123, 83)
        Me.tlp_cond3.Name = "tlp_cond3"
        Me.tlp_cond3.RowCount = 1
        Me.tlp_cond3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_cond3.Size = New System.Drawing.Size(875, 34)
        Me.tlp_cond3.TabIndex = 33
        '
        'chk_RegistOnOrdering
        '
        Me.chk_RegistOnOrdering.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_RegistOnOrdering.AutoSize = True
        Me.chk_RegistOnOrdering.Location = New System.Drawing.Point(722, 7)
        Me.chk_RegistOnOrdering.Name = "chk_RegistOnOrdering"
        Me.chk_RegistOnOrdering.Size = New System.Drawing.Size(139, 20)
        Me.chk_RegistOnOrdering.TabIndex = 28
        Me.chk_RegistOnOrdering.Text = "開立醫令即報到"
        Me.chk_RegistOnOrdering.UseVisualStyleBackColor = True
        '
        'ucl_txt_En_name
        '
        Me.ucl_txt_En_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_En_name.Enabled = False
        Me.ucl_txt_En_name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_En_name.Location = New System.Drawing.Point(0, 3)
        Me.ucl_txt_En_name.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_En_name.MaxLength = 100
        Me.ucl_txt_En_name.Name = "ucl_txt_En_name"
        Me.ucl_txt_En_name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_En_name.SelectionStart = 0
        Me.ucl_txt_En_name.Size = New System.Drawing.Size(717, 27)
        Me.ucl_txt_En_name.TabIndex = 10
        Me.ucl_txt_En_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_En_name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_En_name.ToolTipTag = Nothing
        Me.ucl_txt_En_name.uclDollarSign = False
        Me.ucl_txt_En_name.uclDotCount = 0
        Me.ucl_txt_En_name.uclIntCount = 2
        Me.ucl_txt_En_name.uclMinus = False
        Me.ucl_txt_En_name.uclReadOnly = False
        Me.ucl_txt_En_name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_En_name.uclTrimZero = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.tlp_parent.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cb_useCM, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cb_transferPACS, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cb_side_need, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cb_ssite_need, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_ordercheck, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_orderindi, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cb_printindi, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cb_bsite_need, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_OpenNoPrintDept, 8, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 203)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(995, 34)
        Me.TableLayoutPanel3.TabIndex = 30
        '
        'cb_useCM
        '
        Me.cb_useCM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_useCM.AutoSize = True
        Me.cb_useCM.Location = New System.Drawing.Point(825, 7)
        Me.cb_useCM.Name = "cb_useCM"
        Me.cb_useCM.Size = New System.Drawing.Size(155, 20)
        Me.cb_useCM.TabIndex = 24
        Me.cb_useCM.Text = "此醫令使用顯影劑"
        Me.cb_useCM.UseVisualStyleBackColor = True
        '
        'cb_transferPACS
        '
        Me.cb_transferPACS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_transferPACS.AutoSize = True
        Me.cb_transferPACS.Location = New System.Drawing.Point(720, 7)
        Me.cb_transferPACS.Name = "cb_transferPACS"
        Me.cb_transferPACS.Size = New System.Drawing.Size(96, 20)
        Me.cb_transferPACS.TabIndex = 23
        Me.cb_transferPACS.Text = "傳到PACS"
        Me.cb_transferPACS.UseVisualStyleBackColor = True
        '
        'cb_side_need
        '
        Me.cb_side_need.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_side_need.AutoSize = True
        Me.cb_side_need.Location = New System.Drawing.Point(622, 7)
        Me.cb_side_need.Name = "cb_side_need"
        Me.cb_side_need.Size = New System.Drawing.Size(91, 20)
        Me.cb_side_need.TabIndex = 22
        Me.cb_side_need.Text = "側位必輸"
        Me.cb_side_need.UseVisualStyleBackColor = True
        '
        'cb_ssite_need
        '
        Me.cb_ssite_need.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_ssite_need.AutoSize = True
        Me.cb_ssite_need.Location = New System.Drawing.Point(508, 7)
        Me.cb_ssite_need.Name = "cb_ssite_need"
        Me.cb_ssite_need.Size = New System.Drawing.Size(107, 20)
        Me.cb_ssite_need.TabIndex = 21
        Me.cb_ssite_need.Text = "細部位必輸"
        Me.cb_ssite_need.UseVisualStyleBackColor = True
        '
        'btn_ordercheck
        '
        Me.btn_ordercheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_ordercheck.Location = New System.Drawing.Point(0, 3)
        Me.btn_ordercheck.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_ordercheck.Name = "btn_ordercheck"
        Me.btn_ordercheck.Size = New System.Drawing.Size(80, 28)
        Me.btn_ordercheck.TabIndex = 17
        Me.btn_ordercheck.Text = "醫令檢核"
        Me.btn_ordercheck.UseVisualStyleBackColor = True
        '
        'btn_orderindi
        '
        Me.btn_orderindi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_orderindi.Location = New System.Drawing.Point(84, 3)
        Me.btn_orderindi.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_orderindi.Name = "btn_orderindi"
        Me.btn_orderindi.Size = New System.Drawing.Size(115, 28)
        Me.btn_orderindi.TabIndex = 18
        Me.btn_orderindi.Text = "醫令Indication"
        Me.btn_orderindi.UseVisualStyleBackColor = True
        Me.btn_orderindi.Visible = False
        '
        'cb_printindi
        '
        Me.cb_printindi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_printindi.AutoSize = True
        Me.cb_printindi.Location = New System.Drawing.Point(202, 7)
        Me.cb_printindi.Name = "cb_printindi"
        Me.cb_printindi.Size = New System.Drawing.Size(186, 20)
        Me.cb_printindi.TabIndex = 19
        Me.cb_printindi.Text = "列印Indication於申請單"
        Me.cb_printindi.UseVisualStyleBackColor = True
        Me.cb_printindi.Visible = False
        '
        'cb_bsite_need
        '
        Me.cb_bsite_need.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_bsite_need.AutoSize = True
        Me.cb_bsite_need.Location = New System.Drawing.Point(394, 7)
        Me.cb_bsite_need.Name = "cb_bsite_need"
        Me.cb_bsite_need.Size = New System.Drawing.Size(107, 20)
        Me.cb_bsite_need.TabIndex = 20
        Me.cb_bsite_need.Text = "大部位必輸"
        Me.cb_bsite_need.UseVisualStyleBackColor = True
        '
        'btn_OpenNoPrintDept
        '
        Me.btn_OpenNoPrintDept.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OpenNoPrintDept.Location = New System.Drawing.Point(990, 3)
        Me.btn_OpenNoPrintDept.Name = "btn_OpenNoPrintDept"
        Me.btn_OpenNoPrintDept.Size = New System.Drawing.Size(154, 28)
        Me.btn_OpenNoPrintDept.TabIndex = 25
        Me.btn_OpenNoPrintDept.Text = "設定不列印部門"
        Me.btn_OpenNoPrintDept.UseVisualStyleBackColor = True
        '
        'tlp_cond5
        '
        Me.tlp_cond5.ColumnCount = 11
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_cond5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
        Me.tlp_cond5.Controls.Add(Me.lb_ihr, 7, 0)
        Me.tlp_cond5.Controls.Add(Me.lb_ehr, 4, 0)
        Me.tlp_cond5.Controls.Add(Me.ucl_txt_Orpttime, 0, 0)
        Me.tlp_cond5.Controls.Add(Me.ucl_txt_Irpttime, 6, 0)
        Me.tlp_cond5.Controls.Add(Me.lb_ipd_rpttime, 5, 0)
        Me.tlp_cond5.Controls.Add(Me.ucl_txt_Erpttime, 3, 0)
        Me.tlp_cond5.Controls.Add(Me.lb_emg_rpttime, 2, 0)
        Me.tlp_cond5.Controls.Add(Me.lb_ohr, 1, 0)
        Me.tlp_cond5.Controls.Add(Me.Label1, 8, 0)
        Me.tlp_cond5.Controls.Add(Me.txt_NhiBodySiteCode, 9, 0)
        Me.tlp_cond5.Controls.Add(Me.chk_IsNoPrint, 10, 0)
        Me.tlp_cond5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_cond5.Location = New System.Drawing.Point(123, 163)
        Me.tlp_cond5.Name = "tlp_cond5"
        Me.tlp_cond5.RowCount = 1
        Me.tlp_cond5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_cond5.Size = New System.Drawing.Size(875, 34)
        Me.tlp_cond5.TabIndex = 34
        '
        'lb_ihr
        '
        Me.lb_ihr.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_ihr.AutoSize = True
        Me.lb_ihr.Location = New System.Drawing.Point(506, 9)
        Me.lb_ihr.Name = "lb_ihr"
        Me.lb_ihr.Size = New System.Drawing.Size(24, 16)
        Me.lb_ihr.TabIndex = 43
        Me.lb_ihr.Text = "天"
        '
        'lb_ehr
        '
        Me.lb_ehr.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_ehr.AutoSize = True
        Me.lb_ehr.Location = New System.Drawing.Point(285, 9)
        Me.lb_ehr.Name = "lb_ehr"
        Me.lb_ehr.Size = New System.Drawing.Size(24, 16)
        Me.lb_ehr.TabIndex = 42
        Me.lb_ehr.Text = "天"
        '
        'ucl_txt_Orpttime
        '
        Me.ucl_txt_Orpttime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_Orpttime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_Orpttime.Location = New System.Drawing.Point(0, 3)
        Me.ucl_txt_Orpttime.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ucl_txt_Orpttime.MaxLength = 10
        Me.ucl_txt_Orpttime.Name = "ucl_txt_Orpttime"
        Me.ucl_txt_Orpttime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_Orpttime.SelectionStart = 0
        Me.ucl_txt_Orpttime.Size = New System.Drawing.Size(50, 27)
        Me.ucl_txt_Orpttime.TabIndex = 39
        Me.ucl_txt_Orpttime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ucl_txt_Orpttime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_Orpttime.ToolTipTag = Nothing
        Me.ucl_txt_Orpttime.uclDollarSign = False
        Me.ucl_txt_Orpttime.uclDotCount = 0
        Me.ucl_txt_Orpttime.uclIntCount = 2
        Me.ucl_txt_Orpttime.uclMinus = False
        Me.ucl_txt_Orpttime.uclReadOnly = False
        Me.ucl_txt_Orpttime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Money_Type
        Me.ucl_txt_Orpttime.uclTrimZero = True
        '
        'ucl_txt_Irpttime
        '
        Me.ucl_txt_Irpttime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_Irpttime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_Irpttime.Location = New System.Drawing.Point(450, 3)
        Me.ucl_txt_Irpttime.MaxLength = 10
        Me.ucl_txt_Irpttime.Name = "ucl_txt_Irpttime"
        Me.ucl_txt_Irpttime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_Irpttime.SelectionStart = 0
        Me.ucl_txt_Irpttime.Size = New System.Drawing.Size(50, 27)
        Me.ucl_txt_Irpttime.TabIndex = 40
        Me.ucl_txt_Irpttime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ucl_txt_Irpttime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_Irpttime.ToolTipTag = Nothing
        Me.ucl_txt_Irpttime.uclDollarSign = False
        Me.ucl_txt_Irpttime.uclDotCount = 0
        Me.ucl_txt_Irpttime.uclIntCount = 2
        Me.ucl_txt_Irpttime.uclMinus = False
        Me.ucl_txt_Irpttime.uclReadOnly = False
        Me.ucl_txt_Irpttime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Money_Type
        Me.ucl_txt_Irpttime.uclTrimZero = True
        '
        'lb_ipd_rpttime
        '
        Me.lb_ipd_rpttime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_ipd_rpttime.AutoSize = True
        Me.lb_ipd_rpttime.Location = New System.Drawing.Point(340, 9)
        Me.lb_ipd_rpttime.Name = "lb_ipd_rpttime"
        Me.lb_ipd_rpttime.Size = New System.Drawing.Size(104, 16)
        Me.lb_ipd_rpttime.TabIndex = 37
        Me.lb_ipd_rpttime.Text = "住院報告時間"
        '
        'ucl_txt_Erpttime
        '
        Me.ucl_txt_Erpttime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_Erpttime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_Erpttime.Location = New System.Drawing.Point(225, 3)
        Me.ucl_txt_Erpttime.MaxLength = 10
        Me.ucl_txt_Erpttime.Name = "ucl_txt_Erpttime"
        Me.ucl_txt_Erpttime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_Erpttime.SelectionStart = 0
        Me.ucl_txt_Erpttime.Size = New System.Drawing.Size(50, 27)
        Me.ucl_txt_Erpttime.TabIndex = 38
        Me.ucl_txt_Erpttime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ucl_txt_Erpttime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_Erpttime.ToolTipTag = Nothing
        Me.ucl_txt_Erpttime.uclDollarSign = False
        Me.ucl_txt_Erpttime.uclDotCount = 0
        Me.ucl_txt_Erpttime.uclIntCount = 2
        Me.ucl_txt_Erpttime.uclMinus = False
        Me.ucl_txt_Erpttime.uclReadOnly = False
        Me.ucl_txt_Erpttime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Money_Type
        Me.ucl_txt_Erpttime.uclTrimZero = True
        '
        'lb_emg_rpttime
        '
        Me.lb_emg_rpttime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_emg_rpttime.AutoSize = True
        Me.lb_emg_rpttime.Location = New System.Drawing.Point(115, 9)
        Me.lb_emg_rpttime.Name = "lb_emg_rpttime"
        Me.lb_emg_rpttime.Size = New System.Drawing.Size(104, 16)
        Me.lb_emg_rpttime.TabIndex = 36
        Me.lb_emg_rpttime.Text = "急診報告時間"
        '
        'lb_ohr
        '
        Me.lb_ohr.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_ohr.AutoSize = True
        Me.lb_ohr.Location = New System.Drawing.Point(60, 9)
        Me.lb_ohr.Name = "lb_ohr"
        Me.lb_ohr.Size = New System.Drawing.Size(24, 16)
        Me.lb_ohr.TabIndex = 41
        Me.lb_ohr.Text = "天"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(547, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "健保申報部位"
        '
        'txt_NhiBodySiteCode
        '
        Me.txt_NhiBodySiteCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NhiBodySiteCode.Location = New System.Drawing.Point(657, 3)
        Me.txt_NhiBodySiteCode.Name = "txt_NhiBodySiteCode"
        Me.txt_NhiBodySiteCode.Size = New System.Drawing.Size(56, 27)
        Me.txt_NhiBodySiteCode.TabIndex = 44
        '
        'chk_IsNoPrint
        '
        Me.chk_IsNoPrint.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_IsNoPrint.AutoSize = True
        Me.chk_IsNoPrint.Location = New System.Drawing.Point(719, 7)
        Me.chk_IsNoPrint.Name = "chk_IsNoPrint"
        Me.chk_IsNoPrint.Size = New System.Drawing.Size(123, 20)
        Me.chk_IsNoPrint.TabIndex = 45
        Me.chk_IsNoPrint.Text = "不列印檢查單"
        Me.chk_IsNoPrint.UseVisualStyleBackColor = True
        '
        'lb_opd_rpttime
        '
        Me.lb_opd_rpttime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_opd_rpttime.AutoSize = True
        Me.lb_opd_rpttime.Location = New System.Drawing.Point(13, 172)
        Me.lb_opd_rpttime.Name = "lb_opd_rpttime"
        Me.lb_opd_rpttime.Size = New System.Drawing.Size(104, 16)
        Me.lb_opd_rpttime.TabIndex = 35
        Me.lb_opd_rpttime.Text = "門診報告時間"
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(908, 480)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_confirm.TabIndex = 28
        Me.btn_confirm.Text = "F10-暫存"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'gb_detail
        '
        Me.tlp_parent.SetColumnSpan(Me.gb_detail, 2)
        Me.gb_detail.Controls.Add(Me.ucl_rt_notify)
        Me.gb_detail.Controls.Add(Me.cb_printapplynotif)
        Me.gb_detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_detail.Location = New System.Drawing.Point(3, 369)
        Me.gb_detail.Name = "gb_detail"
        Me.gb_detail.Size = New System.Drawing.Size(995, 105)
        Me.gb_detail.TabIndex = 31
        Me.gb_detail.TabStop = False
        '
        'ucl_rt_notify
        '
        Me.ucl_rt_notify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_rt_notify.Location = New System.Drawing.Point(3, 23)
        Me.ucl_rt_notify.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_rt_notify.Name = "ucl_rt_notify"
        Me.ucl_rt_notify.Size = New System.Drawing.Size(989, 79)
        Me.ucl_rt_notify.TabIndex = 27
        Me.ucl_rt_notify.uclMaxLength = 32767
        Me.ucl_rt_notify.uclReadOnly = False
        Me.ucl_rt_notify.uclWordWrap = True
        '
        'cb_printapplynotif
        '
        Me.cb_printapplynotif.AutoSize = True
        Me.cb_printapplynotif.Location = New System.Drawing.Point(13, 3)
        Me.cb_printapplynotif.Name = "cb_printapplynotif"
        Me.cb_printapplynotif.Size = New System.Drawing.Size(219, 20)
        Me.cb_printapplynotif.TabIndex = 26
        Me.cb_printapplynotif.Text = "申請單列印醫令的注意事項"
        Me.cb_printapplynotif.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.tlp_parent.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.txt_OrderEntryNote)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 243)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(995, 120)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "開立醫令注意事項"
        '
        'txt_OrderEntryNote
        '
        Me.txt_OrderEntryNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_OrderEntryNote.Location = New System.Drawing.Point(3, 23)
        Me.txt_OrderEntryNote.Multiline = True
        Me.txt_OrderEntryNote.Name = "txt_OrderEntryNote"
        Me.txt_OrderEntryNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_OrderEntryNote.Size = New System.Drawing.Size(989, 94)
        Me.txt_OrderEntryNote.TabIndex = 25
        Me.txt_OrderEntryNote.Text = " "
        '
        'PUBRisDetailMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 512)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRisDetailMaintainUI"
        Me.TabText = "檢查醫令明細維護"
        Me.Text = "檢查醫令明細維護"
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.tlp_cond1.ResumeLayout(False)
        Me.tlp_cond1.PerformLayout()
        Me.tlp_cond4.ResumeLayout(False)
        Me.tlp_cond4.PerformLayout()
        Me.tlp_cond2.ResumeLayout(False)
        Me.tlp_cond2.PerformLayout()
        Me.tlp_cond3.ResumeLayout(False)
        Me.tlp_cond3.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tlp_cond5.ResumeLayout(False)
        Me.tlp_cond5.PerformLayout()
        Me.gb_detail.ResumeLayout(False)
        Me.gb_detail.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_dcreason As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_disablereason As System.Windows.Forms.Label
    Friend WithEvents lb_disabledate As System.Windows.Forms.Label
    Friend WithEvents lb_enabledate As System.Windows.Forms.Label
    Friend WithEvents lb_ordercode As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_ordercode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_dtp_enabledate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents ucl_dtp_disabledate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lb_Zh_name As System.Windows.Forms.Label
    Friend WithEvents ucl_tst_Zh_name As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_txt_En_name As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_En_name As System.Windows.Forms.Label
    Friend WithEvents lb_formbelong As System.Windows.Forms.Label
    Friend WithEvents btn_ordercheck As System.Windows.Forms.Button
    Friend WithEvents btn_orderindi As System.Windows.Forms.Button
    Friend WithEvents cb_printindi As System.Windows.Forms.CheckBox
    Friend WithEvents cb_printapplynotif As System.Windows.Forms.CheckBox
    Friend WithEvents ucl_sheetbelong As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_bsite As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_side As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_ssite As System.Windows.Forms.Label
    Friend WithEvents lb_sidepart As System.Windows.Forms.Label
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents ucl_rt_notify As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents tlp_cond1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_cond4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_detail As System.Windows.Forms.GroupBox
    Friend WithEvents lb_bsite As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_ssite As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cb_useCM As System.Windows.Forms.CheckBox
    Friend WithEvents cb_transferPACS As System.Windows.Forms.CheckBox
    Friend WithEvents cb_side_need As System.Windows.Forms.CheckBox
    Friend WithEvents cb_ssite_need As System.Windows.Forms.CheckBox
    Friend WithEvents cb_bsite_need As System.Windows.Forms.CheckBox
    Friend WithEvents tlp_cond2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_cond3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_cond5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_Irpttime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_txt_Orpttime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_emg_rpttime As System.Windows.Forms.Label
    Friend WithEvents lb_ipd_rpttime As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_Erpttime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_opd_rpttime As System.Windows.Forms.Label
    Friend WithEvents lb_ihr As System.Windows.Forms.Label
    Friend WithEvents lb_ehr As System.Windows.Forms.Label
    Friend WithEvents lb_ohr As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_OrderEntryNote As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_NhiBodySiteCode As System.Windows.Forms.TextBox
    Friend WithEvents chk_RegistOnOrdering As System.Windows.Forms.CheckBox
    Friend WithEvents cb_canscheduleflag As System.Windows.Forms.CheckBox
    Friend WithEvents btn_OpenNoCheckinDept As System.Windows.Forms.Button
    Friend WithEvents btn_OpenNoPrintDept As System.Windows.Forms.Button
    Friend WithEvents chk_IsNoPrint As System.Windows.Forms.CheckBox
End Class
