<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRisFormMaintainUI
    'Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRisFormMaintainUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_info = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_sheetname = New System.Windows.Forms.Label()
        Me.lb_sheetcode = New System.Windows.Forms.Label()
        Me.ucl_comb_sheetcode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cb_emgsheet = New System.Windows.Forms.CheckBox()
        Me.btn_indication = New System.Windows.Forms.Button()
        Me.ucl_txt_sheetname = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.tlp_tel = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_txt_connecttel = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_connecttel = New System.Windows.Forms.Label()
        Me.lb_exedept = New System.Windows.Forms.Label()
        Me.ucl_comb_exedept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cb_printindication = New System.Windows.Forms.CheckBox()
        Me.ucl_dgv_detail = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_button = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_removerow = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.btn_addrow = New System.Windows.Forms.Button()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.gb_formmemo = New System.Windows.Forms.GroupBox()
        Me.ucl_rt_msg = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.tlp_parent.SuspendLayout()
        Me.tlp_info.SuspendLayout()
        Me.tlp_tel.SuspendLayout()
        Me.tlp_button.SuspendLayout()
        Me.gb_formmemo.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 1
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Controls.Add(Me.tlp_info, 0, 0)
        Me.tlp_parent.Controls.Add(Me.ucl_dgv_detail, 0, 2)
        Me.tlp_parent.Controls.Add(Me.tlp_button, 0, 3)
        Me.tlp_parent.Controls.Add(Me.gb_formmemo, 0, 1)
        Me.tlp_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_parent.Location = New System.Drawing.Point(0, 0)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 4
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(964, 641)
        Me.tlp_parent.TabIndex = 0
        '
        'tlp_info
        '
        Me.tlp_info.ColumnCount = 4
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.tlp_info.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_info.Controls.Add(Me.lb_sheetname, 2, 0)
        Me.tlp_info.Controls.Add(Me.lb_sheetcode, 0, 0)
        Me.tlp_info.Controls.Add(Me.ucl_comb_sheetcode, 1, 0)
        Me.tlp_info.Controls.Add(Me.cb_emgsheet, 0, 1)
        Me.tlp_info.Controls.Add(Me.btn_indication, 1, 1)
        Me.tlp_info.Controls.Add(Me.ucl_txt_sheetname, 3, 0)
        Me.tlp_info.Controls.Add(Me.tlp_tel, 3, 1)
        Me.tlp_info.Controls.Add(Me.cb_printindication, 2, 1)
        Me.tlp_info.Location = New System.Drawing.Point(0, 0)
        Me.tlp_info.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_info.Name = "tlp_info"
        Me.tlp_info.RowCount = 2
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_info.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_info.Size = New System.Drawing.Size(964, 64)
        Me.tlp_info.TabIndex = 0
        '
        'lb_sheetname
        '
        Me.lb_sheetname.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_sheetname.AutoSize = True
        Me.lb_sheetname.ForeColor = System.Drawing.Color.Red
        Me.lb_sheetname.Location = New System.Drawing.Point(438, 8)
        Me.lb_sheetname.Name = "lb_sheetname"
        Me.lb_sheetname.Size = New System.Drawing.Size(84, 16)
        Me.lb_sheetname.TabIndex = 3
        Me.lb_sheetname.Text = "* 表單名稱"
        '
        'lb_sheetcode
        '
        Me.lb_sheetcode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_sheetcode.AutoSize = True
        Me.lb_sheetcode.ForeColor = System.Drawing.Color.Red
        Me.lb_sheetcode.Location = New System.Drawing.Point(38, 8)
        Me.lb_sheetcode.Name = "lb_sheetcode"
        Me.lb_sheetcode.Size = New System.Drawing.Size(84, 16)
        Me.lb_sheetcode.TabIndex = 0
        Me.lb_sheetcode.Text = "* 表單代碼"
        '
        'ucl_comb_sheetcode
        '
        Me.ucl_comb_sheetcode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_sheetcode.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ucl_comb_sheetcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_sheetcode.DropDownWidth = 20
        Me.ucl_comb_sheetcode.DroppedDown = False
        Me.ucl_comb_sheetcode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_sheetcode.Location = New System.Drawing.Point(129, 4)
        Me.ucl_comb_sheetcode.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_comb_sheetcode.Name = "ucl_comb_sheetcode"
        Me.ucl_comb_sheetcode.SelectedIndex = -1
        Me.ucl_comb_sheetcode.SelectedItem = Nothing
        Me.ucl_comb_sheetcode.SelectedText = ""
        Me.ucl_comb_sheetcode.SelectedValue = ""
        Me.ucl_comb_sheetcode.SelectionStart = 0
        Me.ucl_comb_sheetcode.Size = New System.Drawing.Size(142, 24)
        Me.ucl_comb_sheetcode.TabIndex = 1
        Me.ucl_comb_sheetcode.uclDisplayIndex = "0,1"
        Me.ucl_comb_sheetcode.uclIsAutoClear = True
        Me.ucl_comb_sheetcode.uclIsFirstItemEmpty = True
        Me.ucl_comb_sheetcode.uclIsTextMode = True
        Me.ucl_comb_sheetcode.uclShowMsg = False
        Me.ucl_comb_sheetcode.uclValueIndex = "0"
        '
        'cb_emgsheet
        '
        Me.cb_emgsheet.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_emgsheet.AutoSize = True
        Me.cb_emgsheet.Location = New System.Drawing.Point(47, 38)
        Me.cb_emgsheet.Name = "cb_emgsheet"
        Me.cb_emgsheet.Size = New System.Drawing.Size(75, 20)
        Me.cb_emgsheet.TabIndex = 5
        Me.cb_emgsheet.Text = "急作單"
        Me.cb_emgsheet.UseVisualStyleBackColor = True
        '
        'btn_indication
        '
        Me.btn_indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_indication.Location = New System.Drawing.Point(128, 34)
        Me.btn_indication.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btn_indication.Name = "btn_indication"
        Me.btn_indication.Size = New System.Drawing.Size(120, 28)
        Me.btn_indication.TabIndex = 6
        Me.btn_indication.Text = "表單Indication"
        Me.btn_indication.UseVisualStyleBackColor = True
        Me.btn_indication.Visible = False
        '
        'ucl_txt_sheetname
        '
        Me.ucl_txt_sheetname.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucl_txt_sheetname.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_sheetname.Location = New System.Drawing.Point(528, 2)
        Me.ucl_txt_sheetname.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ucl_txt_sheetname.MaxLength = 100
        Me.ucl_txt_sheetname.Name = "ucl_txt_sheetname"
        Me.ucl_txt_sheetname.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_sheetname.SelectionStart = 0
        Me.ucl_txt_sheetname.Size = New System.Drawing.Size(433, 27)
        Me.ucl_txt_sheetname.TabIndex = 4
        Me.ucl_txt_sheetname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_sheetname.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_sheetname.ToolTipTag = Nothing
        Me.ucl_txt_sheetname.uclDollarSign = False
        Me.ucl_txt_sheetname.uclDotCount = 0
        Me.ucl_txt_sheetname.uclIntCount = 2
        Me.ucl_txt_sheetname.uclMinus = False
        Me.ucl_txt_sheetname.uclReadOnly = False
        Me.ucl_txt_sheetname.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_sheetname.uclTrimZero = True
        '
        'tlp_tel
        '
        Me.tlp_tel.ColumnCount = 4
        Me.tlp_tel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_tel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_tel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_tel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlp_tel.Controls.Add(Me.ucl_txt_connecttel, 1, 0)
        Me.tlp_tel.Controls.Add(Me.lb_connecttel, 0, 0)
        Me.tlp_tel.Controls.Add(Me.lb_exedept, 2, 0)
        Me.tlp_tel.Controls.Add(Me.ucl_comb_exedept, 3, 0)
        Me.tlp_tel.Location = New System.Drawing.Point(525, 32)
        Me.tlp_tel.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_tel.Name = "tlp_tel"
        Me.tlp_tel.RowCount = 1
        Me.tlp_tel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_tel.Size = New System.Drawing.Size(439, 32)
        Me.tlp_tel.TabIndex = 9
        '
        'ucl_txt_connecttel
        '
        Me.ucl_txt_connecttel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucl_txt_connecttel.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_connecttel.Location = New System.Drawing.Point(103, 2)
        Me.ucl_txt_connecttel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ucl_txt_connecttel.MaxLength = 20
        Me.ucl_txt_connecttel.Name = "ucl_txt_connecttel"
        Me.ucl_txt_connecttel.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_connecttel.SelectionStart = 0
        Me.ucl_txt_connecttel.Size = New System.Drawing.Size(83, 27)
        Me.ucl_txt_connecttel.TabIndex = 2
        Me.ucl_txt_connecttel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_connecttel.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_connecttel.ToolTipTag = Nothing
        Me.ucl_txt_connecttel.uclDollarSign = False
        Me.ucl_txt_connecttel.uclDotCount = 0
        Me.ucl_txt_connecttel.uclIntCount = 2
        Me.ucl_txt_connecttel.uclMinus = False
        Me.ucl_txt_connecttel.uclReadOnly = False
        Me.ucl_txt_connecttel.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_connecttel.uclTrimZero = True
        Me.ucl_txt_connecttel.Visible = False
        '
        'lb_connecttel
        '
        Me.lb_connecttel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_connecttel.AutoSize = True
        Me.lb_connecttel.Location = New System.Drawing.Point(25, 8)
        Me.lb_connecttel.Name = "lb_connecttel"
        Me.lb_connecttel.Size = New System.Drawing.Size(72, 16)
        Me.lb_connecttel.TabIndex = 8
        Me.lb_connecttel.Text = "連絡分機"
        Me.lb_connecttel.Visible = False
        '
        'lb_exedept
        '
        Me.lb_exedept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_exedept.AutoSize = True
        Me.lb_exedept.Location = New System.Drawing.Point(214, 8)
        Me.lb_exedept.Name = "lb_exedept"
        Me.lb_exedept.Size = New System.Drawing.Size(72, 16)
        Me.lb_exedept.TabIndex = 9
        Me.lb_exedept.Text = "執行科別"
        '
        'ucl_comb_exedept
        '
        Me.ucl_comb_exedept.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucl_comb_exedept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_exedept.DropDownWidth = 20
        Me.ucl_comb_exedept.DroppedDown = False
        Me.ucl_comb_exedept.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_exedept.Location = New System.Drawing.Point(292, 4)
        Me.ucl_comb_exedept.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ucl_comb_exedept.Name = "ucl_comb_exedept"
        Me.ucl_comb_exedept.SelectedIndex = -1
        Me.ucl_comb_exedept.SelectedItem = Nothing
        Me.ucl_comb_exedept.SelectedText = ""
        Me.ucl_comb_exedept.SelectedValue = ""
        Me.ucl_comb_exedept.SelectionStart = 0
        Me.ucl_comb_exedept.Size = New System.Drawing.Size(144, 24)
        Me.ucl_comb_exedept.TabIndex = 10
        Me.ucl_comb_exedept.uclDisplayIndex = "0,1"
        Me.ucl_comb_exedept.uclIsAutoClear = True
        Me.ucl_comb_exedept.uclIsFirstItemEmpty = True
        Me.ucl_comb_exedept.uclIsTextMode = False
        Me.ucl_comb_exedept.uclShowMsg = False
        Me.ucl_comb_exedept.uclValueIndex = "0"
        '
        'cb_printindication
        '
        Me.cb_printindication.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_printindication.AutoSize = True
        Me.cb_printindication.Location = New System.Drawing.Point(304, 38)
        Me.cb_printindication.Name = "cb_printindication"
        Me.cb_printindication.Size = New System.Drawing.Size(218, 20)
        Me.cb_printindication.TabIndex = 7
        Me.cb_printindication.Text = "列印表單Indication於申請單"
        Me.cb_printindication.UseVisualStyleBackColor = True
        Me.cb_printindication.Visible = False
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
        Me.ucl_dgv_detail.Location = New System.Drawing.Point(3, 259)
        Me.ucl_dgv_detail.MultiSelect = False
        Me.ucl_dgv_detail.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_detail.Name = "ucl_dgv_detail"
        Me.ucl_dgv_detail.RowHeadersWidth = 41
        Me.ucl_dgv_detail.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucl_dgv_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_detail.Size = New System.Drawing.Size(958, 314)
        Me.ucl_dgv_detail.TabIndex = 2
        Me.ucl_dgv_detail.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucl_dgv_detail.uclBatchColIndex = ""
        Me.ucl_dgv_detail.uclClickToCheck = False
        Me.ucl_dgv_detail.uclColumnAlignment = ""
        Me.ucl_dgv_detail.uclColumnCheckBox = False
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
        'tlp_button
        '
        Me.tlp_button.ColumnCount = 5
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_button.Controls.Add(Me.btn_removerow, 1, 0)
        Me.tlp_button.Controls.Add(Me.btn_clear, 4, 0)
        Me.tlp_button.Controls.Add(Me.btn_confirm, 3, 0)
        Me.tlp_button.Controls.Add(Me.btn_addrow, 0, 0)
        Me.tlp_button.Controls.Add(Me.btn_Insert, 2, 0)
        Me.tlp_button.Location = New System.Drawing.Point(0, 576)
        Me.tlp_button.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_button.Name = "tlp_button"
        Me.tlp_button.RowCount = 1
        Me.tlp_button.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_button.Size = New System.Drawing.Size(964, 65)
        Me.tlp_button.TabIndex = 3
        '
        'btn_removerow
        '
        Me.btn_removerow.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_removerow.Location = New System.Drawing.Point(51, 19)
        Me.btn_removerow.Name = "btn_removerow"
        Me.btn_removerow.Size = New System.Drawing.Size(27, 27)
        Me.btn_removerow.TabIndex = 3
        Me.btn_removerow.Text = "-"
        Me.btn_removerow.UseVisualStyleBackColor = True
        Me.btn_removerow.Visible = False
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_clear.Location = New System.Drawing.Point(871, 18)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_clear.TabIndex = 1
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(773, 18)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_confirm.TabIndex = 0
        Me.btn_confirm.Text = "F10-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'btn_addrow
        '
        Me.btn_addrow.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_addrow.Enabled = False
        Me.btn_addrow.Location = New System.Drawing.Point(3, 19)
        Me.btn_addrow.Name = "btn_addrow"
        Me.btn_addrow.Size = New System.Drawing.Size(27, 27)
        Me.btn_addrow.TabIndex = 2
        Me.btn_addrow.Text = "+"
        Me.btn_addrow.UseVisualStyleBackColor = True
        Me.btn_addrow.Visible = False
        '
        'btn_Insert
        '
        Me.btn_Insert.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Insert.Location = New System.Drawing.Point(677, 18)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(90, 28)
        Me.btn_Insert.TabIndex = 0
        Me.btn_Insert.Text = "新增"
        Me.btn_Insert.UseVisualStyleBackColor = True
        Me.btn_Insert.Visible = False
        '
        'gb_formmemo
        '
        Me.gb_formmemo.Controls.Add(Me.ucl_rt_msg)
        Me.gb_formmemo.Location = New System.Drawing.Point(3, 67)
        Me.gb_formmemo.Name = "gb_formmemo"
        Me.gb_formmemo.Size = New System.Drawing.Size(958, 186)
        Me.gb_formmemo.TabIndex = 4
        Me.gb_formmemo.TabStop = False
        Me.gb_formmemo.Text = "表單注意事項"
        '
        'ucl_rt_msg
        '
        Me.ucl_rt_msg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_rt_msg.Location = New System.Drawing.Point(3, 23)
        Me.ucl_rt_msg.Name = "ucl_rt_msg"
        Me.ucl_rt_msg.Size = New System.Drawing.Size(952, 160)
        Me.ucl_rt_msg.TabIndex = 1
        Me.ucl_rt_msg.uclMaxLength = 32767
        Me.ucl_rt_msg.uclReadOnly = False
        Me.ucl_rt_msg.uclWordWrap = True
        '
        'PUBRisFormMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBRisFormMaintainUI"
        Me.TabText = "檢查表單維護"
        Me.Text = "檢查表單維護"
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_info.ResumeLayout(False)
        Me.tlp_info.PerformLayout()
        Me.tlp_tel.ResumeLayout(False)
        Me.tlp_tel.PerformLayout()
        Me.tlp_button.ResumeLayout(False)
        Me.gb_formmemo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_info As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_sheetname As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_sheetname As System.Windows.Forms.Label
    Friend WithEvents lb_sheetcode As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_sheetcode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_txt_connecttel As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cb_emgsheet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_indication As System.Windows.Forms.Button
    Friend WithEvents cb_printindication As System.Windows.Forms.CheckBox
    Friend WithEvents lb_connecttel As System.Windows.Forms.Label
    Friend WithEvents ucl_rt_msg As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents ucl_dgv_detail As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tlp_button As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_removerow As System.Windows.Forms.Button
    Friend WithEvents btn_addrow As System.Windows.Forms.Button
    Friend WithEvents tlp_tel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_formmemo As System.Windows.Forms.GroupBox
    Friend WithEvents lb_exedept As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_exedept As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Insert As System.Windows.Forms.Button
End Class
