<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleCheckTreeDetailUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRuleCheckTreeDetailUI))
        Me.gb_parent = New System.Windows.Forms.GroupBox
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.lb_itemdescribe = New System.Windows.Forms.Label
        Me.tlp_line01 = New System.Windows.Forms.TableLayoutPanel
        Me.cb_passcheck = New System.Windows.Forms.CheckBox
        Me.rb_faultcond = New System.Windows.Forms.RadioButton
        Me.rb_successcond = New System.Windows.Forms.RadioButton
        Me.Chk_before = New System.Windows.Forms.CheckBox
        Me.cb_inputnotice = New System.Windows.Forms.CheckBox
        Me.lb_x = New System.Windows.Forms.Label
        Me.lb_type = New System.Windows.Forms.Label
        Me.ucl_txt_itemdescrib = New Syscom.Client.UCL.UCLTextBoxUC
        Me.tlp_line04 = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_txt_z = New Syscom.Client.UCL.UCLTextBoxUC
        Me.tlp_valuerange = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_txt_y = New Syscom.Client.UCL.UCLTextBoxUC
        Me.lb_y = New System.Windows.Forms.Label
        Me.ucl_txt_x = New Syscom.Client.UCL.UCLTextBoxUC
        Me.lb_z = New System.Windows.Forms.Label
        Me.tlp_line05 = New System.Windows.Forms.TableLayoutPanel
        Me.condition_dtl = New System.Windows.Forms.Button
        Me.ucl_comb_oper = New Syscom.Client.UCL.UCLComboBoxUC
        Me.lb_valuerange = New System.Windows.Forms.Label
        Me.ucl_txt_belong_info = New Syscom.Client.UCL.UCLTextBoxUC
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.lb_unit = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cb_e = New System.Windows.Forms.CheckBox
        Me.cb_o = New System.Windows.Forms.CheckBox
        Me.ucl_comb_condrelation = New Syscom.Client.UCL.UCLComboBoxUC
        Me.lb_condrelation = New System.Windows.Forms.Label
        Me.ucl_comb_unit = New Syscom.Client.UCL.UCLComboBoxUC
        Me.cb_i = New System.Windows.Forms.CheckBox
        Me.lb_oper = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_comb_type = New Syscom.Client.UCL.UCLComboBoxUC
        Me.lb_item = New System.Windows.Forms.Label
        Me.ucl_comb_item = New Syscom.Client.UCL.UCLComboBoxUC
        Me.gb_parent.SuspendLayout()
        Me.tlp_parent.SuspendLayout()
        Me.tlp_line01.SuspendLayout()
        Me.tlp_line04.SuspendLayout()
        Me.tlp_valuerange.SuspendLayout()
        Me.tlp_line05.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_parent)
        Me.gb_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_parent.Location = New System.Drawing.Point(0, 0)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(748, 243)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 3
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_parent.Controls.Add(Me.btn_cancel, 2, 2)
        Me.tlp_parent.Controls.Add(Me.lb_itemdescribe, 0, 1)
        Me.tlp_parent.Controls.Add(Me.tlp_line01, 0, 0)
        Me.tlp_parent.Controls.Add(Me.lb_x, 0, 3)
        Me.tlp_parent.Controls.Add(Me.lb_type, 0, 2)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_itemdescrib, 1, 1)
        Me.tlp_parent.Controls.Add(Me.tlp_line04, 1, 3)
        Me.tlp_parent.Controls.Add(Me.tlp_line05, 1, 4)
        Me.tlp_parent.Controls.Add(Me.btn_confirm, 2, 1)
        Me.tlp_parent.Controls.Add(Me.lb_unit, 0, 5)
        Me.tlp_parent.Controls.Add(Me.TableLayoutPanel1, 1, 5)
        Me.tlp_parent.Controls.Add(Me.cb_i, 2, 5)
        Me.tlp_parent.Controls.Add(Me.lb_oper, 0, 4)
        Me.tlp_parent.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.tlp_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_parent.Location = New System.Drawing.Point(3, 23)
        Me.tlp_parent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 6
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(742, 217)
        Me.tlp_parent.TabIndex = 0
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_cancel.Location = New System.Drawing.Point(645, 73)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(90, 28)
        Me.btn_cancel.TabIndex = 9
        Me.btn_cancel.Text = "F5-取消"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'lb_itemdescribe
        '
        Me.lb_itemdescribe.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_itemdescribe.AutoSize = True
        Me.lb_itemdescribe.Location = New System.Drawing.Point(25, 44)
        Me.lb_itemdescribe.Name = "lb_itemdescribe"
        Me.lb_itemdescribe.Size = New System.Drawing.Size(72, 16)
        Me.lb_itemdescribe.TabIndex = 0
        Me.lb_itemdescribe.Text = "項目說明"
        '
        'tlp_line01
        '
        Me.tlp_line01.ColumnCount = 5
        Me.tlp_parent.SetColumnSpan(Me.tlp_line01, 3)
        Me.tlp_line01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_line01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_line01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.tlp_line01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line01.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.tlp_line01.Controls.Add(Me.cb_passcheck, 0, 0)
        Me.tlp_line01.Controls.Add(Me.rb_faultcond, 4, 0)
        Me.tlp_line01.Controls.Add(Me.rb_successcond, 3, 0)
        Me.tlp_line01.Controls.Add(Me.Chk_before, 2, 0)
        Me.tlp_line01.Controls.Add(Me.cb_inputnotice, 1, 0)
        Me.tlp_line01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_line01.Location = New System.Drawing.Point(0, 0)
        Me.tlp_line01.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_line01.Name = "tlp_line01"
        Me.tlp_line01.RowCount = 1
        Me.tlp_line01.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line01.Size = New System.Drawing.Size(742, 35)
        Me.tlp_line01.TabIndex = 0
        '
        'cb_passcheck
        '
        Me.cb_passcheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_passcheck.AutoSize = True
        Me.cb_passcheck.Location = New System.Drawing.Point(3, 7)
        Me.cb_passcheck.Name = "cb_passcheck"
        Me.cb_passcheck.Size = New System.Drawing.Size(91, 20)
        Me.cb_passcheck.TabIndex = 0
        Me.cb_passcheck.Text = "忽略檢核"
        Me.cb_passcheck.UseVisualStyleBackColor = True
        '
        'rb_faultcond
        '
        Me.rb_faultcond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rb_faultcond.AutoSize = True
        Me.rb_faultcond.Location = New System.Drawing.Point(581, 7)
        Me.rb_faultcond.Name = "rb_faultcond"
        Me.rb_faultcond.Size = New System.Drawing.Size(154, 20)
        Me.rb_faultcond.TabIndex = 3
        Me.rb_faultcond.TabStop = True
        Me.rb_faultcond.Text = "失敗接續條件項目"
        Me.rb_faultcond.UseVisualStyleBackColor = True
        Me.rb_faultcond.Visible = False
        '
        'rb_successcond
        '
        Me.rb_successcond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rb_successcond.AutoSize = True
        Me.rb_successcond.Location = New System.Drawing.Point(374, 7)
        Me.rb_successcond.Name = "rb_successcond"
        Me.rb_successcond.Size = New System.Drawing.Size(154, 20)
        Me.rb_successcond.TabIndex = 2
        Me.rb_successcond.TabStop = True
        Me.rb_successcond.Text = "成功接續條件項目"
        Me.rb_successcond.UseVisualStyleBackColor = True
        Me.rb_successcond.Visible = False
        '
        'Chk_before
        '
        Me.Chk_before.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Chk_before.AutoSize = True
        Me.Chk_before.Location = New System.Drawing.Point(223, 7)
        Me.Chk_before.Name = "Chk_before"
        Me.Chk_before.Size = New System.Drawing.Size(107, 20)
        Me.Chk_before.TabIndex = 4
        Me.Chk_before.Text = "需事前審查"
        Me.Chk_before.UseVisualStyleBackColor = True
        '
        'cb_inputnotice
        '
        Me.cb_inputnotice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_inputnotice.AutoSize = True
        Me.cb_inputnotice.Location = New System.Drawing.Point(103, 7)
        Me.cb_inputnotice.Name = "cb_inputnotice"
        Me.cb_inputnotice.Size = New System.Drawing.Size(107, 20)
        Me.cb_inputnotice.TabIndex = 1
        Me.cb_inputnotice.Text = "需輸入資料"
        Me.cb_inputnotice.UseVisualStyleBackColor = True
        '
        'lb_x
        '
        Me.lb_x.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_x.AutoSize = True
        Me.lb_x.Location = New System.Drawing.Point(65, 114)
        Me.lb_x.Name = "lb_x"
        Me.lb_x.Size = New System.Drawing.Size(32, 16)
        Me.lb_x.TabIndex = 7
        Me.lb_x.Text = "Ｘ="
        '
        'lb_type
        '
        Me.lb_type.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_type.AutoSize = True
        Me.lb_type.Location = New System.Drawing.Point(25, 79)
        Me.lb_type.Name = "lb_type"
        Me.lb_type.Size = New System.Drawing.Size(72, 16)
        Me.lb_type.TabIndex = 1
        Me.lb_type.Text = "檢查類別"
        '
        'ucl_txt_itemdescrib
        '
        Me.ucl_txt_itemdescrib.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucl_txt_itemdescrib.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_itemdescrib.Location = New System.Drawing.Point(103, 39)
        Me.ucl_txt_itemdescrib.MaxLength = 1000
        Me.ucl_txt_itemdescrib.Name = "ucl_txt_itemdescrib"
        Me.ucl_txt_itemdescrib.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_itemdescrib.SelectionStart = 0
        Me.ucl_txt_itemdescrib.Size = New System.Drawing.Size(536, 27)
        Me.ucl_txt_itemdescrib.TabIndex = 4
        Me.ucl_txt_itemdescrib.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_itemdescrib.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_itemdescrib.uclDollarSign = False
        Me.ucl_txt_itemdescrib.uclDotCount = 0
        Me.ucl_txt_itemdescrib.uclIntCount = 2
        Me.ucl_txt_itemdescrib.uclMinus = False
        Me.ucl_txt_itemdescrib.uclReadOnly = False
        Me.ucl_txt_itemdescrib.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'tlp_line04
        '
        Me.tlp_line04.ColumnCount = 5
        Me.tlp_line04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_line04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlp_line04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlp_line04.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlp_line04.Controls.Add(Me.ucl_txt_z, 4, 0)
        Me.tlp_line04.Controls.Add(Me.tlp_valuerange, 2, 0)
        Me.tlp_line04.Controls.Add(Me.ucl_txt_x, 0, 0)
        Me.tlp_line04.Controls.Add(Me.lb_z, 3, 0)
        Me.tlp_line04.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_line04.Location = New System.Drawing.Point(100, 105)
        Me.tlp_line04.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_line04.Name = "tlp_line04"
        Me.tlp_line04.RowCount = 1
        Me.tlp_line04.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line04.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_line04.Size = New System.Drawing.Size(542, 35)
        Me.tlp_line04.TabIndex = 6
        '
        'ucl_txt_z
        '
        Me.ucl_txt_z.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_z.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_z.Location = New System.Drawing.Point(475, 4)
        Me.ucl_txt_z.MaxLength = 10
        Me.ucl_txt_z.Name = "ucl_txt_z"
        Me.ucl_txt_z.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_z.SelectionStart = 0
        Me.ucl_txt_z.Size = New System.Drawing.Size(50, 27)
        Me.ucl_txt_z.TabIndex = 14
        Me.ucl_txt_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_z.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_z.uclDollarSign = False
        Me.ucl_txt_z.uclDotCount = 0
        Me.ucl_txt_z.uclIntCount = 6
        Me.ucl_txt_z.uclMinus = False
        Me.ucl_txt_z.uclReadOnly = False
        Me.ucl_txt_z.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'tlp_valuerange
        '
        Me.tlp_valuerange.ColumnCount = 2
        Me.tlp_valuerange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tlp_valuerange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_valuerange.Controls.Add(Me.ucl_txt_y, 1, 0)
        Me.tlp_valuerange.Controls.Add(Me.lb_y, 0, 0)
        Me.tlp_valuerange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_valuerange.Location = New System.Drawing.Point(170, 0)
        Me.tlp_valuerange.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_valuerange.Name = "tlp_valuerange"
        Me.tlp_valuerange.RowCount = 1
        Me.tlp_valuerange.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_valuerange.Size = New System.Drawing.Size(232, 35)
        Me.tlp_valuerange.TabIndex = 13
        '
        'ucl_txt_y
        '
        Me.ucl_txt_y.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_y.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_y.Location = New System.Drawing.Point(49, 4)
        Me.ucl_txt_y.MaxLength = 10
        Me.ucl_txt_y.Name = "ucl_txt_y"
        Me.ucl_txt_y.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_y.SelectionStart = 0
        Me.ucl_txt_y.Size = New System.Drawing.Size(180, 27)
        Me.ucl_txt_y.TabIndex = 13
        Me.ucl_txt_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_y.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_y.uclDollarSign = False
        Me.ucl_txt_y.uclDotCount = 0
        Me.ucl_txt_y.uclIntCount = 6
        Me.ucl_txt_y.uclMinus = False
        Me.ucl_txt_y.uclReadOnly = False
        Me.ucl_txt_y.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lb_y
        '
        Me.lb_y.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_y.AutoSize = True
        Me.lb_y.Location = New System.Drawing.Point(11, 9)
        Me.lb_y.Name = "lb_y"
        Me.lb_y.Size = New System.Drawing.Size(32, 16)
        Me.lb_y.TabIndex = 8
        Me.lb_y.Text = "Ｙ="
        '
        'ucl_txt_x
        '
        Me.ucl_txt_x.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_line04.SetColumnSpan(Me.ucl_txt_x, 2)
        Me.ucl_txt_x.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_x.Location = New System.Drawing.Point(3, 4)
        Me.ucl_txt_x.MaxLength = 10
        Me.ucl_txt_x.Name = "ucl_txt_x"
        Me.ucl_txt_x.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_x.SelectionStart = 0
        Me.ucl_txt_x.Size = New System.Drawing.Size(164, 27)
        Me.ucl_txt_x.TabIndex = 12
        Me.ucl_txt_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_x.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_x.uclDollarSign = False
        Me.ucl_txt_x.uclDotCount = 0
        Me.ucl_txt_x.uclIntCount = 6
        Me.ucl_txt_x.uclMinus = False
        Me.ucl_txt_x.uclReadOnly = False
        Me.ucl_txt_x.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lb_z
        '
        Me.lb_z.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_z.AutoSize = True
        Me.lb_z.Location = New System.Drawing.Point(437, 9)
        Me.lb_z.Name = "lb_z"
        Me.lb_z.Size = New System.Drawing.Size(32, 16)
        Me.lb_z.TabIndex = 9
        Me.lb_z.Text = "Ｚ="
        '
        'tlp_line05
        '
        Me.tlp_line05.ColumnCount = 5
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.tlp_line05.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_line05.Controls.Add(Me.condition_dtl, 4, 0)
        Me.tlp_line05.Controls.Add(Me.ucl_comb_oper, 0, 0)
        Me.tlp_line05.Controls.Add(Me.lb_valuerange, 1, 0)
        Me.tlp_line05.Controls.Add(Me.ucl_txt_belong_info, 2, 0)
        Me.tlp_line05.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_line05.Location = New System.Drawing.Point(100, 140)
        Me.tlp_line05.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_line05.Name = "tlp_line05"
        Me.tlp_line05.RowCount = 1
        Me.tlp_line05.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_line05.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.tlp_line05.Size = New System.Drawing.Size(542, 43)
        Me.tlp_line05.TabIndex = 7
        '
        'condition_dtl
        '
        Me.condition_dtl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.condition_dtl.Location = New System.Drawing.Point(447, 8)
        Me.condition_dtl.Name = "condition_dtl"
        Me.condition_dtl.Size = New System.Drawing.Size(27, 27)
        Me.condition_dtl.TabIndex = 13
        Me.condition_dtl.Text = "..."
        Me.condition_dtl.UseVisualStyleBackColor = True
        '
        'ucl_comb_oper
        '
        Me.ucl_comb_oper.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_oper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_oper.DropDownWidth = 20
        Me.ucl_comb_oper.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_oper.Location = New System.Drawing.Point(3, 9)
        Me.ucl_comb_oper.Name = "ucl_comb_oper"
        Me.ucl_comb_oper.SelectedIndex = -1
        Me.ucl_comb_oper.SelectedItem = Nothing
        Me.ucl_comb_oper.SelectedText = ""
        Me.ucl_comb_oper.SelectedValue = ""
        Me.ucl_comb_oper.SelectionStart = 0
        Me.ucl_comb_oper.Size = New System.Drawing.Size(114, 24)
        Me.ucl_comb_oper.TabIndex = 11
        Me.ucl_comb_oper.uclDisplayIndex = "0,1"
        Me.ucl_comb_oper.uclIsAutoClear = True
        Me.ucl_comb_oper.uclIsTextMode = False
        Me.ucl_comb_oper.uclShowMsg = False
        Me.ucl_comb_oper.uclValueIndex = "0"
        '
        'lb_valuerange
        '
        Me.lb_valuerange.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_valuerange.AutoSize = True
        Me.lb_valuerange.Location = New System.Drawing.Point(169, 13)
        Me.lb_valuerange.Name = "lb_valuerange"
        Me.lb_valuerange.Size = New System.Drawing.Size(48, 16)
        Me.lb_valuerange.TabIndex = 7
        Me.lb_valuerange.Text = "值域="
        '
        'ucl_txt_belong_info
        '
        Me.ucl_txt_belong_info.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_line05.SetColumnSpan(Me.ucl_txt_belong_info, 2)
        Me.ucl_txt_belong_info.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_belong_info.Location = New System.Drawing.Point(223, 8)
        Me.ucl_txt_belong_info.MaxLength = 1000
        Me.ucl_txt_belong_info.Name = "ucl_txt_belong_info"
        Me.ucl_txt_belong_info.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_belong_info.SelectionStart = 0
        Me.ucl_txt_belong_info.Size = New System.Drawing.Size(218, 27)
        Me.ucl_txt_belong_info.TabIndex = 6
        Me.ucl_txt_belong_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_belong_info.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_belong_info.uclDollarSign = False
        Me.ucl_txt_belong_info.uclDotCount = 0
        Me.ucl_txt_belong_info.uclIntCount = 2
        Me.ucl_txt_belong_info.uclMinus = False
        Me.ucl_txt_belong_info.uclReadOnly = False
        Me.ucl_txt_belong_info.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_confirm.Location = New System.Drawing.Point(645, 38)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_confirm.TabIndex = 8
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'lb_unit
        '
        Me.lb_unit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_unit.AutoSize = True
        Me.lb_unit.Location = New System.Drawing.Point(49, 192)
        Me.lb_unit.Name = "lb_unit"
        Me.lb_unit.Size = New System.Drawing.Size(48, 16)
        Me.lb_unit.TabIndex = 8
        Me.lb_unit.Text = "單位="
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cb_e, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_o, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_comb_condrelation, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lb_condrelation, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_comb_unit, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(103, 186)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(536, 28)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'cb_e
        '
        Me.cb_e.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_e.AutoSize = True
        Me.cb_e.Location = New System.Drawing.Point(429, 4)
        Me.cb_e.Name = "cb_e"
        Me.cb_e.Size = New System.Drawing.Size(91, 20)
        Me.cb_e.TabIndex = 14
        Me.cb_e.Text = "合計急診"
        Me.cb_e.UseVisualStyleBackColor = True
        '
        'cb_o
        '
        Me.cb_o.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_o.AutoSize = True
        Me.cb_o.Location = New System.Drawing.Point(328, 4)
        Me.cb_o.Name = "cb_o"
        Me.cb_o.Size = New System.Drawing.Size(91, 20)
        Me.cb_o.TabIndex = 13
        Me.cb_o.Text = "合計門診"
        Me.cb_o.UseVisualStyleBackColor = True
        '
        'ucl_comb_condrelation
        '
        Me.ucl_comb_condrelation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_condrelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_condrelation.DropDownWidth = 20
        Me.ucl_comb_condrelation.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_condrelation.Location = New System.Drawing.Point(219, 3)
        Me.ucl_comb_condrelation.Name = "ucl_comb_condrelation"
        Me.ucl_comb_condrelation.SelectedIndex = -1
        Me.ucl_comb_condrelation.SelectedItem = Nothing
        Me.ucl_comb_condrelation.SelectedText = ""
        Me.ucl_comb_condrelation.SelectedValue = ""
        Me.ucl_comb_condrelation.SelectionStart = 0
        Me.ucl_comb_condrelation.Size = New System.Drawing.Size(103, 24)
        Me.ucl_comb_condrelation.TabIndex = 12
        Me.ucl_comb_condrelation.uclDisplayIndex = "0,1"
        Me.ucl_comb_condrelation.uclIsAutoClear = True
        Me.ucl_comb_condrelation.uclIsTextMode = False
        Me.ucl_comb_condrelation.uclShowMsg = False
        Me.ucl_comb_condrelation.uclValueIndex = "0"
        '
        'lb_condrelation
        '
        Me.lb_condrelation.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_condrelation.AutoSize = True
        Me.lb_condrelation.Location = New System.Drawing.Point(141, 6)
        Me.lb_condrelation.Name = "lb_condrelation"
        Me.lb_condrelation.Size = New System.Drawing.Size(72, 16)
        Me.lb_condrelation.TabIndex = 3
        Me.lb_condrelation.Text = "條件關係"
        '
        'ucl_comb_unit
        '
        Me.ucl_comb_unit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_unit.DropDownWidth = 20
        Me.ucl_comb_unit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_unit.Location = New System.Drawing.Point(3, 3)
        Me.ucl_comb_unit.Name = "ucl_comb_unit"
        Me.ucl_comb_unit.SelectedIndex = -1
        Me.ucl_comb_unit.SelectedItem = Nothing
        Me.ucl_comb_unit.SelectedText = ""
        Me.ucl_comb_unit.SelectedValue = ""
        Me.ucl_comb_unit.SelectionStart = 0
        Me.ucl_comb_unit.Size = New System.Drawing.Size(112, 24)
        Me.ucl_comb_unit.TabIndex = 12
        Me.ucl_comb_unit.uclDisplayIndex = "0,1"
        Me.ucl_comb_unit.uclIsAutoClear = True
        Me.ucl_comb_unit.uclIsTextMode = False
        Me.ucl_comb_unit.uclShowMsg = False
        Me.ucl_comb_unit.uclValueIndex = "0"
        '
        'cb_i
        '
        Me.cb_i.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_i.AutoSize = True
        Me.cb_i.Location = New System.Drawing.Point(645, 190)
        Me.cb_i.Name = "cb_i"
        Me.cb_i.Size = New System.Drawing.Size(91, 20)
        Me.cb_i.TabIndex = 15
        Me.cb_i.Text = "合計住院"
        Me.cb_i.UseVisualStyleBackColor = True
        '
        'lb_oper
        '
        Me.lb_oper.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_oper.AutoSize = True
        Me.lb_oper.Location = New System.Drawing.Point(25, 153)
        Me.lb_oper.Name = "lb_oper"
        Me.lb_oper.Size = New System.Drawing.Size(72, 16)
        Me.lb_oper.TabIndex = 2
        Me.lb_oper.Text = "運算項目"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ucl_comb_type, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_item, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucl_comb_item, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(103, 73)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(536, 29)
        Me.TableLayoutPanel2.TabIndex = 17
        '
        'ucl_comb_type
        '
        Me.ucl_comb_type.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_type.DropDownWidth = 20
        Me.ucl_comb_type.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_type.Location = New System.Drawing.Point(3, 3)
        Me.ucl_comb_type.Name = "ucl_comb_type"
        Me.ucl_comb_type.SelectedIndex = -1
        Me.ucl_comb_type.SelectedItem = Nothing
        Me.ucl_comb_type.SelectedText = ""
        Me.ucl_comb_type.SelectedValue = ""
        Me.ucl_comb_type.SelectionStart = 0
        Me.ucl_comb_type.Size = New System.Drawing.Size(207, 24)
        Me.ucl_comb_type.TabIndex = 11
        Me.ucl_comb_type.uclDisplayIndex = "0,1"
        Me.ucl_comb_type.uclIsAutoClear = True
        Me.ucl_comb_type.uclIsTextMode = False
        Me.ucl_comb_type.uclShowMsg = False
        Me.ucl_comb_type.uclValueIndex = "0"
        '
        'lb_item
        '
        Me.lb_item.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_item.AutoSize = True
        Me.lb_item.Location = New System.Drawing.Point(225, 6)
        Me.lb_item.Name = "lb_item"
        Me.lb_item.Size = New System.Drawing.Size(72, 16)
        Me.lb_item.TabIndex = 6
        Me.lb_item.Text = "檢查項目"
        '
        'ucl_comb_item
        '
        Me.ucl_comb_item.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_item.DropDownWidth = 20
        Me.ucl_comb_item.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_item.Location = New System.Drawing.Point(303, 3)
        Me.ucl_comb_item.Name = "ucl_comb_item"
        Me.ucl_comb_item.SelectedIndex = -1
        Me.ucl_comb_item.SelectedItem = Nothing
        Me.ucl_comb_item.SelectedText = ""
        Me.ucl_comb_item.SelectedValue = ""
        Me.ucl_comb_item.SelectionStart = 0
        Me.ucl_comb_item.Size = New System.Drawing.Size(219, 24)
        Me.ucl_comb_item.TabIndex = 10
        Me.ucl_comb_item.uclDisplayIndex = "0,1"
        Me.ucl_comb_item.uclIsAutoClear = True
        Me.ucl_comb_item.uclIsTextMode = False
        Me.ucl_comb_item.uclShowMsg = False
        Me.ucl_comb_item.uclValueIndex = "0"
        '
        'PUBRuleCheckTreeDetailUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 243)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRuleCheckTreeDetailUI"
        Me.TabText = "執行條件維護"
        Me.Text = "執行條件維護"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.tlp_line01.ResumeLayout(False)
        Me.tlp_line01.PerformLayout()
        Me.tlp_line04.ResumeLayout(False)
        Me.tlp_line04.PerformLayout()
        Me.tlp_valuerange.ResumeLayout(False)
        Me.tlp_valuerange.PerformLayout()
        Me.tlp_line05.ResumeLayout(False)
        Me.tlp_line05.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_itemdescribe As System.Windows.Forms.Label
    Friend WithEvents tlp_line01 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rb_faultcond As System.Windows.Forms.RadioButton
    Friend WithEvents cb_inputnotice As System.Windows.Forms.CheckBox
    Friend WithEvents cb_passcheck As System.Windows.Forms.CheckBox
    Friend WithEvents rb_successcond As System.Windows.Forms.RadioButton
    Friend WithEvents lb_type As System.Windows.Forms.Label
    Friend WithEvents lb_oper As System.Windows.Forms.Label
    Friend WithEvents lb_condrelation As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_itemdescrib As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_x As System.Windows.Forms.Label
    Friend WithEvents lb_y As System.Windows.Forms.Label
    Friend WithEvents lb_z As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_z As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_txt_y As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_txt_x As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents tlp_line04 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_comb_oper As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_valuerange As System.Windows.Forms.Label
    Friend WithEvents lb_unit As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_unit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents tlp_line05 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_comb_condrelation As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cb_i As System.Windows.Forms.CheckBox
    Friend WithEvents cb_e As System.Windows.Forms.CheckBox
    Friend WithEvents cb_o As System.Windows.Forms.CheckBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents tlp_valuerange As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_belong_info As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents condition_dtl As System.Windows.Forms.Button
    Friend WithEvents Chk_before As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_comb_type As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_comb_item As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_item As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
End Class
