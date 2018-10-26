<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBOrderMaterialUI
    'Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    Inherits Syscom.Client.UCL.BaseFormUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBOrderMaterialUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbp_Parent = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_Condition = New System.Windows.Forms.GroupBox()
        Me.tlp_Condition = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.gb_transunit = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_chargetransferclaim = New System.Windows.Forms.Label()
        Me.txt_chargetransclaim = New System.Windows.Forms.TextBox()
        Me.lb_format = New System.Windows.Forms.Label()
        Me.txt_format = New System.Windows.Forms.TextBox()
        Me.lb_claimunit = New System.Windows.Forms.Label()
        Me.txt_ClaimUnit = New System.Windows.Forms.TextBox()
        Me.tlp_check = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_Indication = New System.Windows.Forms.CheckBox()
        Me.cb_OrderCheck = New System.Windows.Forms.CheckBox()
        Me.btn_OrderCheck = New System.Windows.Forms.Button()
        Me.ucl_Flag = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_Mark = New System.Windows.Forms.Label()
        Me.btn_Indication = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_Brand = New System.Windows.Forms.TextBox()
        Me.cb_NhiSheet = New System.Windows.Forms.CheckBox()
        Me.btn_Nhi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_Classify = New System.Windows.Forms.Label()
        Me.tbp_EffectDate = New System.Windows.Forms.TableLayoutPanel()
        Me.uclcb_classify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_material_use_cnt = New System.Windows.Forms.Label()
        Me.ucl_mat_use_cnt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_IncludeOrder = New System.Windows.Forms.TextBox()
        Me.lb_PriceAdjustment = New System.Windows.Forms.Label()
        Me.ucl_PriceAdjustment = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_OrderPS = New System.Windows.Forms.Label()
        Me.memo_OrderMemo = New System.Windows.Forms.TextBox()
        Me.btn_OrderRemark = New System.Windows.Forms.Button()
        Me.lb_OrderCode = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lb_Name = New System.Windows.Forms.Label()
        Me.txt_NhiCode = New System.Windows.Forms.TextBox()
        Me.lb_NhiCode = New System.Windows.Forms.Label()
        Me.PUBMaterialUI_ucl_txtcq_ordercode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.gb_OrderItem = New System.Windows.Forms.GroupBox()
        Me.tbp_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_OrederNote = New System.Windows.Forms.RichTextBox()
        Me.lb_OrderRemark = New System.Windows.Forms.Label()
        Me.tbp_OrderMemo = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_Note = New System.Windows.Forms.TextBox()
        Me.cb_preview = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_CostPrice = New System.Windows.Forms.TextBox()
        Me.chk_IncludeOrderMark = New System.Windows.Forms.CheckBox()
        Me.tbp_EnName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_EnName = New System.Windows.Forms.TextBox()
        Me.lb_SEName = New System.Windows.Forms.Label()
        Me.txt_SEName = New System.Windows.Forms.TextBox()
        Me.cb_Dc = New System.Windows.Forms.CheckBox()
        Me.tp_date = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_dtp_enddate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_enddate = New System.Windows.Forms.Label()
        Me.ucldtp_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_EffectDate = New System.Windows.Forms.Label()
        Me.cbo_OPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_EMG = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_IPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_TWName = New System.Windows.Forms.Label()
        Me.lb_EnName = New System.Windows.Forms.Label()
        Me.lb_OrderType = New System.Windows.Forms.Label()
        Me.tbp_ZhName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ZhName = New System.Windows.Forms.TextBox()
        Me.lb_SCName = New System.Windows.Forms.Label()
        Me.txt_SCName = New System.Windows.Forms.TextBox()
        Me.tlp_content2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ChargeUnit = New System.Windows.Forms.TextBox()
        Me.uclcomb_HosItem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_ChargeUnit = New System.Windows.Forms.Label()
        Me.lb_HosFee = New System.Windows.Forms.Label()
        Me.lb_last_purchase = New System.Windows.Forms.Label()
        Me.txt_purchaseprice = New System.Windows.Forms.TextBox()
        Me.txt_purchaseunit = New System.Windows.Forms.TextBox()
        Me.lb_storagetype = New System.Windows.Forms.Label()
        Me.uclcomb_OrderType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_storagetype = New System.Windows.Forms.TextBox()
        Me.gb_OrderPrice = New System.Windows.Forms.GroupBox()
        Me.ucldgv_OrderPrice = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.cb_pricehistory = New System.Windows.Forms.CheckBox()
        Me.lb_Nhi_Name = New System.Windows.Forms.Label()
        Me.gb_btn = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_AddQuery = New System.Windows.Forms.Button()
        Me.chk_OrderHistory = New System.Windows.Forms.CheckBox()
        Me.btn_SelfpayApply = New System.Windows.Forms.Button()
        Me.btn_NextRecord = New System.Windows.Forms.Button()
        Me.btn_PreRecord = New System.Windows.Forms.Button()
        Me.tbp_Parent.SuspendLayout()
        Me.gb_Condition.SuspendLayout()
        Me.tlp_Condition.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.gb_transunit.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.tlp_check.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tbp_EffectDate.SuspendLayout()
        Me.gb_OrderItem.SuspendLayout()
        Me.tbp_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_OrderMemo.SuspendLayout()
        Me.tbp_EnName.SuspendLayout()
        Me.tp_date.SuspendLayout()
        Me.tbp_ZhName.SuspendLayout()
        Me.tlp_content2.SuspendLayout()
        Me.gb_OrderPrice.SuspendLayout()
        Me.gb_btn.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbp_Parent
        '
        Me.tbp_Parent.ColumnCount = 1
        Me.tbp_Parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Parent.Controls.Add(Me.gb_Condition, 0, 0)
        Me.tbp_Parent.Controls.Add(Me.gb_OrderItem, 0, 1)
        Me.tbp_Parent.Controls.Add(Me.gb_OrderPrice, 0, 2)
        Me.tbp_Parent.Controls.Add(Me.gb_btn, 0, 3)
        Me.tbp_Parent.Location = New System.Drawing.Point(2, 1)
        Me.tbp_Parent.Margin = New System.Windows.Forms.Padding(4)
        Me.tbp_Parent.Name = "tbp_Parent"
        Me.tbp_Parent.RowCount = 4
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 342.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Parent.Size = New System.Drawing.Size(963, 640)
        Me.tbp_Parent.TabIndex = 0
        '
        'gb_Condition
        '
        Me.gb_Condition.Controls.Add(Me.tlp_Condition)
        Me.gb_Condition.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_Condition.Location = New System.Drawing.Point(4, 4)
        Me.gb_Condition.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_Condition.Name = "gb_Condition"
        Me.gb_Condition.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_Condition.Size = New System.Drawing.Size(955, 59)
        Me.gb_Condition.TabIndex = 0
        Me.gb_Condition.TabStop = False
        Me.gb_Condition.Text = "查詢區"
        '
        'tlp_Condition
        '
        Me.tlp_Condition.ColumnCount = 7
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 526.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.tlp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Condition.Controls.Add(Me.FlowLayoutPanel2, 2, 0)
        Me.tlp_Condition.Controls.Add(Me.lb_OrderCode, 0, 0)
        Me.tlp_Condition.Controls.Add(Me.txt_Name, 6, 0)
        Me.tlp_Condition.Controls.Add(Me.lb_Name, 5, 0)
        Me.tlp_Condition.Controls.Add(Me.txt_NhiCode, 4, 0)
        Me.tlp_Condition.Controls.Add(Me.lb_NhiCode, 3, 0)
        Me.tlp_Condition.Controls.Add(Me.PUBMaterialUI_ucl_txtcq_ordercode, 1, 0)
        Me.tlp_Condition.Location = New System.Drawing.Point(3, 18)
        Me.tlp_Condition.Name = "tlp_Condition"
        Me.tlp_Condition.RowCount = 1
        Me.tlp_Condition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Condition.Size = New System.Drawing.Size(943, 37)
        Me.tlp_Condition.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.gb_transunit)
        Me.FlowLayoutPanel2.Controls.Add(Me.tlp_check)
        Me.FlowLayoutPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_Classify)
        Me.FlowLayoutPanel2.Controls.Add(Me.tbp_EffectDate)
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_OrderPS)
        Me.FlowLayoutPanel2.Controls.Add(Me.memo_OrderMemo)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_OrderRemark)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(649, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(28, 31)
        Me.FlowLayoutPanel2.TabIndex = 7
        Me.FlowLayoutPanel2.Visible = False
        '
        'gb_transunit
        '
        Me.gb_transunit.Controls.Add(Me.TableLayoutPanel4)
        Me.gb_transunit.Location = New System.Drawing.Point(0, 0)
        Me.gb_transunit.Margin = New System.Windows.Forms.Padding(0)
        Me.gb_transunit.Name = "gb_transunit"
        Me.gb_transunit.Padding = New System.Windows.Forms.Padding(0)
        Me.gb_transunit.Size = New System.Drawing.Size(510, 60)
        Me.gb_transunit.TabIndex = 8
        Me.gb_transunit.TabStop = False
        Me.gb_transunit.Text = "單位轉換"
        Me.gb_transunit.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lb_chargetransferclaim, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_chargetransclaim, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lb_format, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_format, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lb_claimunit, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_ClaimUnit, 5, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 20)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(507, 36)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'lb_chargetransferclaim
        '
        Me.lb_chargetransferclaim.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_chargetransferclaim.AutoSize = True
        Me.lb_chargetransferclaim.ForeColor = System.Drawing.Color.Red
        Me.lb_chargetransferclaim.Location = New System.Drawing.Point(163, 10)
        Me.lb_chargetransferclaim.Name = "lb_chargetransferclaim"
        Me.lb_chargetransferclaim.Size = New System.Drawing.Size(136, 16)
        Me.lb_chargetransferclaim.TabIndex = 11
        Me.lb_chargetransferclaim.Text = "計價轉換申報單位"
        '
        'txt_chargetransclaim
        '
        Me.txt_chargetransclaim.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_chargetransclaim.Location = New System.Drawing.Point(305, 4)
        Me.txt_chargetransclaim.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_chargetransclaim.Name = "txt_chargetransclaim"
        Me.txt_chargetransclaim.Size = New System.Drawing.Size(54, 27)
        Me.txt_chargetransclaim.TabIndex = 12
        Me.txt_chargetransclaim.Text = "1"
        '
        'lb_format
        '
        Me.lb_format.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_format.AutoSize = True
        Me.lb_format.Location = New System.Drawing.Point(3, 10)
        Me.lb_format.Name = "lb_format"
        Me.lb_format.Size = New System.Drawing.Size(40, 16)
        Me.lb_format.TabIndex = 10
        Me.lb_format.Text = "規格"
        Me.lb_format.Visible = False
        '
        'txt_format
        '
        Me.txt_format.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_format.Enabled = False
        Me.txt_format.Location = New System.Drawing.Point(80, 4)
        Me.txt_format.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_format.Name = "txt_format"
        Me.txt_format.Size = New System.Drawing.Size(60, 27)
        Me.txt_format.TabIndex = 11
        Me.txt_format.Visible = False
        '
        'lb_claimunit
        '
        Me.lb_claimunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_claimunit.AutoSize = True
        Me.lb_claimunit.ForeColor = System.Drawing.Color.Red
        Me.lb_claimunit.Location = New System.Drawing.Point(368, 10)
        Me.lb_claimunit.Name = "lb_claimunit"
        Me.lb_claimunit.Size = New System.Drawing.Size(72, 16)
        Me.lb_claimunit.TabIndex = 13
        Me.lb_claimunit.Text = "申報單位"
        '
        'txt_ClaimUnit
        '
        Me.txt_ClaimUnit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ClaimUnit.Location = New System.Drawing.Point(445, 4)
        Me.txt_ClaimUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_ClaimUnit.MaxLength = 8
        Me.txt_ClaimUnit.Name = "txt_ClaimUnit"
        Me.txt_ClaimUnit.Size = New System.Drawing.Size(54, 27)
        Me.txt_ClaimUnit.TabIndex = 16
        '
        'tlp_check
        '
        Me.tlp_check.ColumnCount = 6
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_check.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_check.Controls.Add(Me.cb_Indication, 2, 0)
        Me.tlp_check.Controls.Add(Me.cb_OrderCheck, 0, 0)
        Me.tlp_check.Controls.Add(Me.btn_OrderCheck, 1, 0)
        Me.tlp_check.Controls.Add(Me.ucl_Flag, 5, 0)
        Me.tlp_check.Controls.Add(Me.lb_Mark, 4, 0)
        Me.tlp_check.Controls.Add(Me.btn_Indication, 3, 0)
        Me.tlp_check.Location = New System.Drawing.Point(0, 60)
        Me.tlp_check.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_check.Name = "tlp_check"
        Me.tlp_check.RowCount = 1
        Me.tlp_check.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_check.Size = New System.Drawing.Size(434, 33)
        Me.tlp_check.TabIndex = 7
        '
        'cb_Indication
        '
        Me.cb_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_Indication.AutoSize = True
        Me.cb_Indication.Location = New System.Drawing.Point(123, 9)
        Me.cb_Indication.Name = "cb_Indication"
        Me.cb_Indication.Size = New System.Drawing.Size(15, 14)
        Me.cb_Indication.TabIndex = 17
        Me.cb_Indication.UseVisualStyleBackColor = True
        '
        'cb_OrderCheck
        '
        Me.cb_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_OrderCheck.AutoSize = True
        Me.cb_OrderCheck.Location = New System.Drawing.Point(3, 9)
        Me.cb_OrderCheck.Name = "cb_OrderCheck"
        Me.cb_OrderCheck.Size = New System.Drawing.Size(15, 14)
        Me.cb_OrderCheck.TabIndex = 15
        Me.cb_OrderCheck.UseVisualStyleBackColor = True
        '
        'btn_OrderCheck
        '
        Me.btn_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_OrderCheck.Location = New System.Drawing.Point(30, 3)
        Me.btn_OrderCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_OrderCheck.Name = "btn_OrderCheck"
        Me.btn_OrderCheck.Size = New System.Drawing.Size(90, 27)
        Me.btn_OrderCheck.TabIndex = 16
        Me.btn_OrderCheck.Text = "醫令檢核"
        Me.btn_OrderCheck.UseVisualStyleBackColor = True
        Me.btn_OrderCheck.Visible = False
        '
        'ucl_Flag
        '
        Me.ucl_Flag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_Flag.DropDownWidth = 20
        Me.ucl_Flag.DroppedDown = False
        Me.ucl_Flag.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_Flag.Location = New System.Drawing.Point(270, 0)
        Me.ucl_Flag.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_Flag.Name = "ucl_Flag"
        Me.ucl_Flag.SelectedIndex = -1
        Me.ucl_Flag.SelectedItem = Nothing
        Me.ucl_Flag.SelectedText = ""
        Me.ucl_Flag.SelectedValue = ""
        Me.ucl_Flag.SelectionStart = 0
        Me.ucl_Flag.Size = New System.Drawing.Size(98, 24)
        Me.ucl_Flag.TabIndex = 14
        Me.ucl_Flag.uclDisplayIndex = "0,1"
        Me.ucl_Flag.uclIsAutoClear = True
        Me.ucl_Flag.uclIsFirstItemEmpty = True
        Me.ucl_Flag.uclIsTextMode = False
        Me.ucl_Flag.uclShowMsg = False
        Me.ucl_Flag.uclValueIndex = "0"
        Me.ucl_Flag.Visible = False
        '
        'lb_Mark
        '
        Me.lb_Mark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_Mark.AutoSize = True
        Me.lb_Mark.Location = New System.Drawing.Point(243, 0)
        Me.lb_Mark.Name = "lb_Mark"
        Me.lb_Mark.Size = New System.Drawing.Size(24, 33)
        Me.lb_Mark.TabIndex = 2
        Me.lb_Mark.Text = "訂價原則"
        Me.lb_Mark.Visible = False
        '
        'btn_Indication
        '
        Me.btn_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Indication.Location = New System.Drawing.Point(150, 3)
        Me.btn_Indication.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Indication.Name = "btn_Indication"
        Me.btn_Indication.Size = New System.Drawing.Size(90, 27)
        Me.btn_Indication.TabIndex = 18
        Me.btn_Indication.Text = "適應症"
        Me.btn_Indication.UseVisualStyleBackColor = True
        Me.btn_Indication.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Brand, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_NhiSheet, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Nhi, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 93)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(434, 33)
        Me.TableLayoutPanel1.TabIndex = 7
        Me.TableLayoutPanel1.Visible = False
        '
        'txt_Brand
        '
        Me.txt_Brand.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Brand.Location = New System.Drawing.Point(310, 3)
        Me.txt_Brand.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Brand.MaxLength = 50
        Me.txt_Brand.Name = "txt_Brand"
        Me.txt_Brand.Size = New System.Drawing.Size(120, 27)
        Me.txt_Brand.TabIndex = 22
        '
        'cb_NhiSheet
        '
        Me.cb_NhiSheet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiSheet.AutoSize = True
        Me.cb_NhiSheet.Location = New System.Drawing.Point(3, 9)
        Me.cb_NhiSheet.Name = "cb_NhiSheet"
        Me.cb_NhiSheet.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiSheet.TabIndex = 24
        Me.cb_NhiSheet.UseVisualStyleBackColor = True
        '
        'btn_Nhi
        '
        Me.btn_Nhi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Nhi.Location = New System.Drawing.Point(30, 3)
        Me.btn_Nhi.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Nhi.Name = "btn_Nhi"
        Me.btn_Nhi.Size = New System.Drawing.Size(120, 27)
        Me.btn_Nhi.TabIndex = 25
        Me.btn_Nhi.Text = "健保給付規定單"
        Me.btn_Nhi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(267, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "廠牌"
        '
        'lb_Classify
        '
        Me.lb_Classify.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Classify.AutoSize = True
        Me.lb_Classify.ForeColor = System.Drawing.Color.Red
        Me.lb_Classify.Location = New System.Drawing.Point(3, 126)
        Me.lb_Classify.Name = "lb_Classify"
        Me.lb_Classify.Size = New System.Drawing.Size(24, 64)
        Me.lb_Classify.TabIndex = 1
        Me.lb_Classify.Text = "給付註記"
        Me.lb_Classify.Visible = False
        '
        'tbp_EffectDate
        '
        Me.tbp_EffectDate.ColumnCount = 9
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.Controls.Add(Me.uclcb_classify, 0, 0)
        Me.tbp_EffectDate.Controls.Add(Me.lb_material_use_cnt, 1, 0)
        Me.tbp_EffectDate.Controls.Add(Me.ucl_mat_use_cnt, 2, 0)
        Me.tbp_EffectDate.Controls.Add(Me.Label2, 3, 0)
        Me.tbp_EffectDate.Controls.Add(Me.txt_IncludeOrder, 4, 0)
        Me.tbp_EffectDate.Controls.Add(Me.lb_PriceAdjustment, 5, 0)
        Me.tbp_EffectDate.Controls.Add(Me.ucl_PriceAdjustment, 6, 0)
        Me.tbp_EffectDate.Location = New System.Drawing.Point(3, 193)
        Me.tbp_EffectDate.Name = "tbp_EffectDate"
        Me.tbp_EffectDate.RowCount = 1
        Me.tbp_EffectDate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EffectDate.Size = New System.Drawing.Size(828, 29)
        Me.tbp_EffectDate.TabIndex = 6
        Me.tbp_EffectDate.Visible = False
        '
        'uclcb_classify
        '
        Me.uclcb_classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_classify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_classify.DropDownWidth = 20
        Me.uclcb_classify.DroppedDown = False
        Me.uclcb_classify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_classify.Location = New System.Drawing.Point(0, 2)
        Me.uclcb_classify.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcb_classify.Name = "uclcb_classify"
        Me.uclcb_classify.SelectedIndex = -1
        Me.uclcb_classify.SelectedItem = Nothing
        Me.uclcb_classify.SelectedText = ""
        Me.uclcb_classify.SelectedValue = ""
        Me.uclcb_classify.SelectionStart = 0
        Me.uclcb_classify.Size = New System.Drawing.Size(221, 24)
        Me.uclcb_classify.TabIndex = 27
        Me.uclcb_classify.uclDisplayIndex = "0,1"
        Me.uclcb_classify.uclIsAutoClear = True
        Me.uclcb_classify.uclIsFirstItemEmpty = True
        Me.uclcb_classify.uclIsTextMode = False
        Me.uclcb_classify.uclShowMsg = False
        Me.uclcb_classify.uclValueIndex = "0"
        '
        'lb_material_use_cnt
        '
        Me.lb_material_use_cnt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_material_use_cnt.AutoSize = True
        Me.lb_material_use_cnt.Location = New System.Drawing.Point(224, 6)
        Me.lb_material_use_cnt.Name = "lb_material_use_cnt"
        Me.lb_material_use_cnt.Size = New System.Drawing.Size(104, 16)
        Me.lb_material_use_cnt.TabIndex = 28
        Me.lb_material_use_cnt.Text = "核給使用次數"
        '
        'ucl_mat_use_cnt
        '
        Me.ucl_mat_use_cnt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_mat_use_cnt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_mat_use_cnt.Location = New System.Drawing.Point(331, 1)
        Me.ucl_mat_use_cnt.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_mat_use_cnt.MaxLength = 10
        Me.ucl_mat_use_cnt.Name = "ucl_mat_use_cnt"
        Me.ucl_mat_use_cnt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_mat_use_cnt.SelectionStart = 0
        Me.ucl_mat_use_cnt.Size = New System.Drawing.Size(79, 27)
        Me.ucl_mat_use_cnt.TabIndex = 31
        Me.ucl_mat_use_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_mat_use_cnt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_mat_use_cnt.ToolTipTag = Nothing
        Me.ucl_mat_use_cnt.uclDollarSign = False
        Me.ucl_mat_use_cnt.uclDotCount = 0
        Me.ucl_mat_use_cnt.uclIntCount = 2
        Me.ucl_mat_use_cnt.uclMinus = False
        Me.ucl_mat_use_cnt.uclReadOnly = False
        Me.ucl_mat_use_cnt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.ucl_mat_use_cnt.uclTrimZero = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(413, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "健保內含項註記"
        Me.Label2.Visible = False
        '
        'txt_IncludeOrder
        '
        Me.txt_IncludeOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_IncludeOrder.Location = New System.Drawing.Point(536, 1)
        Me.txt_IncludeOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_IncludeOrder.MaxLength = 1
        Me.txt_IncludeOrder.Name = "txt_IncludeOrder"
        Me.txt_IncludeOrder.Size = New System.Drawing.Size(82, 27)
        Me.txt_IncludeOrder.TabIndex = 33
        '
        'lb_PriceAdjustment
        '
        Me.lb_PriceAdjustment.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_PriceAdjustment.AutoSize = True
        Me.lb_PriceAdjustment.Location = New System.Drawing.Point(621, 6)
        Me.lb_PriceAdjustment.Name = "lb_PriceAdjustment"
        Me.lb_PriceAdjustment.Size = New System.Drawing.Size(104, 16)
        Me.lb_PriceAdjustment.TabIndex = 37
        Me.lb_PriceAdjustment.Text = "單價調整紀錄"
        '
        'ucl_PriceAdjustment
        '
        Me.ucl_PriceAdjustment.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_PriceAdjustment.Enabled = False
        Me.ucl_PriceAdjustment.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_PriceAdjustment.Location = New System.Drawing.Point(728, 1)
        Me.ucl_PriceAdjustment.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_PriceAdjustment.MaxLength = 10
        Me.ucl_PriceAdjustment.Name = "ucl_PriceAdjustment"
        Me.ucl_PriceAdjustment.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_PriceAdjustment.SelectionStart = 0
        Me.ucl_PriceAdjustment.Size = New System.Drawing.Size(90, 27)
        Me.ucl_PriceAdjustment.TabIndex = 38
        Me.ucl_PriceAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_PriceAdjustment.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_PriceAdjustment.ToolTipTag = Nothing
        Me.ucl_PriceAdjustment.uclDollarSign = False
        Me.ucl_PriceAdjustment.uclDotCount = 0
        Me.ucl_PriceAdjustment.uclIntCount = 2
        Me.ucl_PriceAdjustment.uclMinus = False
        Me.ucl_PriceAdjustment.uclReadOnly = False
        Me.ucl_PriceAdjustment.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_PriceAdjustment.uclTrimZero = True
        '
        'lb_OrderPS
        '
        Me.lb_OrderPS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderPS.AutoSize = True
        Me.lb_OrderPS.Location = New System.Drawing.Point(3, 225)
        Me.lb_OrderPS.Name = "lb_OrderPS"
        Me.lb_OrderPS.Size = New System.Drawing.Size(24, 96)
        Me.lb_OrderPS.TabIndex = 3
        Me.lb_OrderPS.Text = "醫令注意事項"
        '
        'memo_OrderMemo
        '
        Me.memo_OrderMemo.Location = New System.Drawing.Point(0, 321)
        Me.memo_OrderMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.memo_OrderMemo.Name = "memo_OrderMemo"
        Me.memo_OrderMemo.Size = New System.Drawing.Size(290, 27)
        Me.memo_OrderMemo.TabIndex = 15
        '
        'btn_OrderRemark
        '
        Me.btn_OrderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_OrderRemark.AutoSize = True
        Me.btn_OrderRemark.Location = New System.Drawing.Point(3, 351)
        Me.btn_OrderRemark.Name = "btn_OrderRemark"
        Me.btn_OrderRemark.Size = New System.Drawing.Size(82, 26)
        Me.btn_OrderRemark.TabIndex = 1
        Me.btn_OrderRemark.Text = "醫令備註"
        '
        'lb_OrderCode
        '
        Me.lb_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderCode.AutoSize = True
        Me.lb_OrderCode.ForeColor = System.Drawing.Color.Red
        Me.lb_OrderCode.Location = New System.Drawing.Point(13, 10)
        Me.lb_OrderCode.Name = "lb_OrderCode"
        Me.lb_OrderCode.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderCode.TabIndex = 0
        Me.lb_OrderCode.Text = "醫令項目代碼"
        '
        'txt_Name
        '
        Me.txt_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Name.Enabled = False
        Me.txt_Name.Location = New System.Drawing.Point(875, 5)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(62, 27)
        Me.txt_Name.TabIndex = 3
        Me.txt_Name.Visible = False
        '
        'lb_Name
        '
        Me.lb_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Name.AutoSize = True
        Me.lb_Name.Location = New System.Drawing.Point(829, 10)
        Me.lb_Name.Name = "lb_Name"
        Me.lb_Name.Size = New System.Drawing.Size(40, 16)
        Me.lb_Name.TabIndex = 2
        Me.lb_Name.Text = "名稱"
        Me.lb_Name.Visible = False
        '
        'txt_NhiCode
        '
        Me.txt_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NhiCode.Enabled = False
        Me.txt_NhiCode.Location = New System.Drawing.Point(756, 5)
        Me.txt_NhiCode.Name = "txt_NhiCode"
        Me.txt_NhiCode.Size = New System.Drawing.Size(62, 27)
        Me.txt_NhiCode.TabIndex = 4
        Me.txt_NhiCode.Visible = False
        '
        'lb_NhiCode
        '
        Me.lb_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_NhiCode.AutoSize = True
        Me.lb_NhiCode.Location = New System.Drawing.Point(694, 10)
        Me.lb_NhiCode.Name = "lb_NhiCode"
        Me.lb_NhiCode.Size = New System.Drawing.Size(56, 16)
        Me.lb_NhiCode.TabIndex = 1
        Me.lb_NhiCode.Text = "健保碼"
        Me.lb_NhiCode.Visible = False
        '
        'PUBMaterialUI_ucl_txtcq_ordercode
        '
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PUBMaterialUI_ucl_txtcq_ordercode.doFlag = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Location = New System.Drawing.Point(120, 5)
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Margin = New System.Windows.Forms.Padding(0)
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Name = "PUBMaterialUI_ucl_txtcq_ordercode"
        Me.PUBMaterialUI_ucl_txtcq_ordercode.Size = New System.Drawing.Size(163, 26)
        Me.PUBMaterialUI_ucl_txtcq_ordercode.TabIndex = 5
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclBaseDate = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCboWidth = 126
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName1 = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName2 = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclConditionDate = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclControlFlag = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclDisplayIndex = "0,1"
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsAutoAddZero = False
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsBtnVisible = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsCheckDoctorOnDuty = False
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsCheckDrLicense = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsCheckTime = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsEnglishDept = False
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsReturnDS = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsShowMsgBox = True
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclIsTextAutoClear = False
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclLabel = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclMsgValue = Nothing
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclNoDataOpenWindow = False
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclPUBEmployeeProfessalKindId = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclQueryField = Nothing
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclQueryValue = Nothing
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclRegionKind = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclRoles = ""
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_OrderForMantain
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclTotalWidth = 8
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclXPosition = 225
        Me.PUBMaterialUI_ucl_txtcq_ordercode.uclYPosition = 120
        '
        'gb_OrderItem
        '
        Me.gb_OrderItem.Controls.Add(Me.tbp_1)
        Me.gb_OrderItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderItem.Location = New System.Drawing.Point(4, 79)
        Me.gb_OrderItem.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Name = "gb_OrderItem"
        Me.gb_OrderItem.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Size = New System.Drawing.Size(955, 334)
        Me.gb_OrderItem.TabIndex = 1
        Me.gb_OrderItem.TabStop = False
        '
        'tbp_1
        '
        Me.tbp_1.ColumnCount = 2
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_1.Controls.Add(Me.GroupBox1, 0, 5)
        Me.tbp_1.Controls.Add(Me.lb_OrderRemark, 0, 3)
        Me.tbp_1.Controls.Add(Me.tbp_OrderMemo, 1, 3)
        Me.tbp_1.Controls.Add(Me.tbp_EnName, 1, 1)
        Me.tbp_1.Controls.Add(Me.cb_Dc, 0, 4)
        Me.tbp_1.Controls.Add(Me.tp_date, 1, 4)
        Me.tbp_1.Controls.Add(Me.lb_TWName, 0, 0)
        Me.tbp_1.Controls.Add(Me.lb_EnName, 0, 1)
        Me.tbp_1.Controls.Add(Me.lb_OrderType, 0, 2)
        Me.tbp_1.Controls.Add(Me.tbp_ZhName, 1, 0)
        Me.tbp_1.Controls.Add(Me.tlp_content2, 1, 2)
        Me.tbp_1.Location = New System.Drawing.Point(4, 24)
        Me.tbp_1.Name = "tbp_1"
        Me.tbp_1.RowCount = 6
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.Size = New System.Drawing.Size(944, 303)
        Me.tbp_1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.tbp_1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.txt_OrederNote)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 201)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(936, 101)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "健保相關規定"
        '
        'txt_OrederNote
        '
        Me.txt_OrederNote.Location = New System.Drawing.Point(6, 18)
        Me.txt_OrederNote.Name = "txt_OrederNote"
        Me.txt_OrederNote.Size = New System.Drawing.Size(922, 77)
        Me.txt_OrederNote.TabIndex = 0
        Me.txt_OrederNote.Text = ""
        '
        'lb_OrderRemark
        '
        Me.lb_OrderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderRemark.AutoSize = True
        Me.lb_OrderRemark.Location = New System.Drawing.Point(3, 114)
        Me.lb_OrderRemark.Name = "lb_OrderRemark"
        Me.lb_OrderRemark.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderRemark.TabIndex = 10
        Me.lb_OrderRemark.Text = "醫令備註"
        '
        'tbp_OrderMemo
        '
        Me.tbp_OrderMemo.ColumnCount = 7
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275.0!))
        Me.tbp_OrderMemo.Controls.Add(Me.txt_Note, 0, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.cb_preview, 1, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.Label3, 4, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.txt_CostPrice, 5, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.chk_IncludeOrderMark, 6, 0)
        Me.tbp_OrderMemo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_OrderMemo.Location = New System.Drawing.Point(81, 108)
        Me.tbp_OrderMemo.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.tbp_OrderMemo.Name = "tbp_OrderMemo"
        Me.tbp_OrderMemo.RowCount = 1
        Me.tbp_OrderMemo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_OrderMemo.Size = New System.Drawing.Size(863, 29)
        Me.tbp_OrderMemo.TabIndex = 8
        '
        'txt_Note
        '
        Me.txt_Note.Location = New System.Drawing.Point(0, 0)
        Me.txt_Note.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Note.Name = "txt_Note"
        Me.txt_Note.Size = New System.Drawing.Size(237, 27)
        Me.txt_Note.TabIndex = 13
        '
        'cb_preview
        '
        Me.cb_preview.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_preview.AutoSize = True
        Me.cb_preview.Location = New System.Drawing.Point(240, 4)
        Me.cb_preview.Name = "cb_preview"
        Me.cb_preview.Size = New System.Drawing.Size(123, 20)
        Me.cb_preview.TabIndex = 21
        Me.cb_preview.Text = "事前審查醫令"
        Me.cb_preview.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(369, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "成本價格"
        '
        'txt_CostPrice
        '
        Me.txt_CostPrice.Location = New System.Drawing.Point(447, 3)
        Me.txt_CostPrice.Name = "txt_CostPrice"
        Me.txt_CostPrice.Size = New System.Drawing.Size(138, 27)
        Me.txt_CostPrice.TabIndex = 23
        '
        'chk_IncludeOrderMark
        '
        Me.chk_IncludeOrderMark.AutoSize = True
        Me.chk_IncludeOrderMark.Location = New System.Drawing.Point(591, 3)
        Me.chk_IncludeOrderMark.Name = "chk_IncludeOrderMark"
        Me.chk_IncludeOrderMark.Size = New System.Drawing.Size(165, 20)
        Me.chk_IncludeOrderMark.TabIndex = 24
        Me.chk_IncludeOrderMark.Text = "健保內含項(不計價)"
        Me.chk_IncludeOrderMark.UseVisualStyleBackColor = True
        '
        'tbp_EnName
        '
        Me.tbp_EnName.ColumnCount = 3
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EnName.Controls.Add(Me.txt_EnName, 0, 0)
        Me.tbp_EnName.Controls.Add(Me.lb_SEName, 1, 0)
        Me.tbp_EnName.Controls.Add(Me.txt_SEName, 2, 0)
        Me.tbp_EnName.Location = New System.Drawing.Point(81, 38)
        Me.tbp_EnName.Name = "tbp_EnName"
        Me.tbp_EnName.RowCount = 1
        Me.tbp_EnName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EnName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tbp_EnName.Size = New System.Drawing.Size(821, 29)
        Me.tbp_EnName.TabIndex = 6
        '
        'txt_EnName
        '
        Me.txt_EnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EnName.Location = New System.Drawing.Point(0, 1)
        Me.txt_EnName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_EnName.MaxLength = 100
        Me.txt_EnName.Name = "txt_EnName"
        Me.txt_EnName.Size = New System.Drawing.Size(490, 27)
        Me.txt_EnName.TabIndex = 6
        '
        'lb_SEName
        '
        Me.lb_SEName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SEName.AutoSize = True
        Me.lb_SEName.Location = New System.Drawing.Point(545, 6)
        Me.lb_SEName.Name = "lb_SEName"
        Me.lb_SEName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SEName.TabIndex = 1
        Me.lb_SEName.Text = "英文簡稱"
        '
        'txt_SEName
        '
        Me.txt_SEName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SEName.Location = New System.Drawing.Point(620, 1)
        Me.txt_SEName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SEName.MaxLength = 50
        Me.txt_SEName.Name = "txt_SEName"
        Me.txt_SEName.Size = New System.Drawing.Size(170, 27)
        Me.txt_SEName.TabIndex = 7
        '
        'cb_Dc
        '
        Me.cb_Dc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_Dc.AutoSize = True
        Me.cb_Dc.Location = New System.Drawing.Point(16, 159)
        Me.cb_Dc.Name = "cb_Dc"
        Me.cb_Dc.Size = New System.Drawing.Size(59, 20)
        Me.cb_Dc.TabIndex = 19
        Me.cb_Dc.Text = "停用"
        Me.cb_Dc.UseVisualStyleBackColor = True
        '
        'tp_date
        '
        Me.tp_date.ColumnCount = 7
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tp_date.Controls.Add(Me.ucl_dtp_enddate, 6, 0)
        Me.tp_date.Controls.Add(Me.lb_enddate, 5, 0)
        Me.tp_date.Controls.Add(Me.ucldtp_EffectDate, 4, 0)
        Me.tp_date.Controls.Add(Me.lb_EffectDate, 3, 0)
        Me.tp_date.Controls.Add(Me.cbo_OPD, 0, 0)
        Me.tp_date.Controls.Add(Me.cbo_EMG, 1, 0)
        Me.tp_date.Controls.Add(Me.cbo_IPD, 2, 0)
        Me.tp_date.Location = New System.Drawing.Point(81, 143)
        Me.tp_date.Name = "tp_date"
        Me.tp_date.RowCount = 1
        Me.tp_date.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tp_date.Size = New System.Drawing.Size(828, 52)
        Me.tp_date.TabIndex = 9
        '
        'ucl_dtp_enddate
        '
        Me.ucl_dtp_enddate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_enddate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_enddate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_enddate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_enddate.Location = New System.Drawing.Point(626, 12)
        Me.ucl_dtp_enddate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.Name = "ucl_dtp_enddate"
        Me.ucl_dtp_enddate.Size = New System.Drawing.Size(120, 27)
        Me.ucl_dtp_enddate.TabIndex = 28
        Me.ucl_dtp_enddate.uclReadOnly = False
        Me.ucl_dtp_enddate.Visible = False
        '
        'lb_enddate
        '
        Me.lb_enddate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_enddate.AutoSize = True
        Me.lb_enddate.Location = New System.Drawing.Point(548, 18)
        Me.lb_enddate.Name = "lb_enddate"
        Me.lb_enddate.Size = New System.Drawing.Size(72, 16)
        Me.lb_enddate.TabIndex = 27
        Me.lb_enddate.Text = "停用日期"
        Me.lb_enddate.Visible = False
        '
        'ucldtp_EffectDate
        '
        Me.ucldtp_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucldtp_EffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucldtp_EffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucldtp_EffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucldtp_EffectDate.Location = New System.Drawing.Point(425, 12)
        Me.ucldtp_EffectDate.Margin = New System.Windows.Forms.Padding(0)
        Me.ucldtp_EffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.Name = "ucldtp_EffectDate"
        Me.ucldtp_EffectDate.Size = New System.Drawing.Size(120, 27)
        Me.ucldtp_EffectDate.TabIndex = 26
        Me.ucldtp_EffectDate.uclReadOnly = False
        Me.ucldtp_EffectDate.Visible = False
        '
        'lb_EffectDate
        '
        Me.lb_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EffectDate.AutoSize = True
        Me.lb_EffectDate.ForeColor = System.Drawing.Color.Red
        Me.lb_EffectDate.Location = New System.Drawing.Point(366, 18)
        Me.lb_EffectDate.Name = "lb_EffectDate"
        Me.lb_EffectDate.Size = New System.Drawing.Size(56, 16)
        Me.lb_EffectDate.TabIndex = 4
        Me.lb_EffectDate.Text = "生效日"
        Me.lb_EffectDate.Visible = False
        '
        'cbo_OPD
        '
        Me.cbo_OPD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_OPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_OPD.DropDownWidth = 20
        Me.cbo_OPD.DroppedDown = False
        Me.cbo_OPD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_OPD.Location = New System.Drawing.Point(0, 14)
        Me.cbo_OPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_OPD.Name = "cbo_OPD"
        Me.cbo_OPD.SelectedIndex = -1
        Me.cbo_OPD.SelectedItem = Nothing
        Me.cbo_OPD.SelectedText = ""
        Me.cbo_OPD.SelectedValue = ""
        Me.cbo_OPD.SelectionStart = 0
        Me.cbo_OPD.Size = New System.Drawing.Size(121, 24)
        Me.cbo_OPD.TabIndex = 9
        Me.cbo_OPD.uclDisplayIndex = "0,1"
        Me.cbo_OPD.uclIsAutoClear = True
        Me.cbo_OPD.uclIsFirstItemEmpty = True
        Me.cbo_OPD.uclIsTextMode = False
        Me.cbo_OPD.uclShowMsg = False
        Me.cbo_OPD.uclValueIndex = "0"
        '
        'cbo_EMG
        '
        Me.cbo_EMG.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_EMG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_EMG.DropDownWidth = 20
        Me.cbo_EMG.DroppedDown = False
        Me.cbo_EMG.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_EMG.Location = New System.Drawing.Point(121, 14)
        Me.cbo_EMG.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_EMG.Name = "cbo_EMG"
        Me.cbo_EMG.SelectedIndex = -1
        Me.cbo_EMG.SelectedItem = Nothing
        Me.cbo_EMG.SelectedText = ""
        Me.cbo_EMG.SelectedValue = ""
        Me.cbo_EMG.SelectionStart = 0
        Me.cbo_EMG.Size = New System.Drawing.Size(124, 24)
        Me.cbo_EMG.TabIndex = 29
        Me.cbo_EMG.uclDisplayIndex = "0,1"
        Me.cbo_EMG.uclIsAutoClear = True
        Me.cbo_EMG.uclIsFirstItemEmpty = True
        Me.cbo_EMG.uclIsTextMode = False
        Me.cbo_EMG.uclShowMsg = False
        Me.cbo_EMG.uclValueIndex = "0"
        '
        'cbo_IPD
        '
        Me.cbo_IPD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IPD.DropDownWidth = 20
        Me.cbo_IPD.DroppedDown = False
        Me.cbo_IPD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IPD.Location = New System.Drawing.Point(245, 14)
        Me.cbo_IPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IPD.Name = "cbo_IPD"
        Me.cbo_IPD.SelectedIndex = -1
        Me.cbo_IPD.SelectedItem = Nothing
        Me.cbo_IPD.SelectedText = ""
        Me.cbo_IPD.SelectedValue = ""
        Me.cbo_IPD.SelectionStart = 0
        Me.cbo_IPD.Size = New System.Drawing.Size(118, 24)
        Me.cbo_IPD.TabIndex = 30
        Me.cbo_IPD.uclDisplayIndex = "0,1"
        Me.cbo_IPD.uclIsAutoClear = True
        Me.cbo_IPD.uclIsFirstItemEmpty = True
        Me.cbo_IPD.uclIsTextMode = False
        Me.cbo_IPD.uclShowMsg = False
        Me.cbo_IPD.uclValueIndex = "0"
        '
        'lb_TWName
        '
        Me.lb_TWName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_TWName.AutoSize = True
        Me.lb_TWName.Location = New System.Drawing.Point(3, 9)
        Me.lb_TWName.Name = "lb_TWName"
        Me.lb_TWName.Size = New System.Drawing.Size(72, 16)
        Me.lb_TWName.TabIndex = 0
        Me.lb_TWName.Text = "中文名稱"
        '
        'lb_EnName
        '
        Me.lb_EnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EnName.AutoSize = True
        Me.lb_EnName.Location = New System.Drawing.Point(3, 44)
        Me.lb_EnName.Name = "lb_EnName"
        Me.lb_EnName.Size = New System.Drawing.Size(72, 16)
        Me.lb_EnName.TabIndex = 1
        Me.lb_EnName.Text = "英文名稱"
        '
        'lb_OrderType
        '
        Me.lb_OrderType.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderType.AutoSize = True
        Me.lb_OrderType.ForeColor = System.Drawing.Color.Red
        Me.lb_OrderType.Location = New System.Drawing.Point(3, 79)
        Me.lb_OrderType.Name = "lb_OrderType"
        Me.lb_OrderType.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderType.TabIndex = 2
        Me.lb_OrderType.Text = "醫令類型"
        '
        'tbp_ZhName
        '
        Me.tbp_ZhName.ColumnCount = 3
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500.0!))
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_ZhName.Controls.Add(Me.txt_ZhName, 0, 0)
        Me.tbp_ZhName.Controls.Add(Me.lb_SCName, 1, 0)
        Me.tbp_ZhName.Controls.Add(Me.txt_SCName, 2, 0)
        Me.tbp_ZhName.Location = New System.Drawing.Point(81, 3)
        Me.tbp_ZhName.Name = "tbp_ZhName"
        Me.tbp_ZhName.RowCount = 1
        Me.tbp_ZhName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_ZhName.Size = New System.Drawing.Size(821, 29)
        Me.tbp_ZhName.TabIndex = 5
        '
        'txt_ZhName
        '
        Me.txt_ZhName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ZhName.Location = New System.Drawing.Point(0, 1)
        Me.txt_ZhName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_ZhName.MaxLength = 100
        Me.txt_ZhName.Name = "txt_ZhName"
        Me.txt_ZhName.Size = New System.Drawing.Size(490, 27)
        Me.txt_ZhName.TabIndex = 4
        '
        'lb_SCName
        '
        Me.lb_SCName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SCName.AutoSize = True
        Me.lb_SCName.Location = New System.Drawing.Point(545, 6)
        Me.lb_SCName.Name = "lb_SCName"
        Me.lb_SCName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SCName.TabIndex = 1
        Me.lb_SCName.Text = "中文簡稱"
        '
        'txt_SCName
        '
        Me.txt_SCName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SCName.Location = New System.Drawing.Point(620, 2)
        Me.txt_SCName.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.txt_SCName.MaxLength = 50
        Me.txt_SCName.Name = "txt_SCName"
        Me.txt_SCName.Size = New System.Drawing.Size(170, 27)
        Me.txt_SCName.TabIndex = 5
        '
        'tlp_content2
        '
        Me.tlp_content2.ColumnCount = 10
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_content2.Controls.Add(Me.txt_ChargeUnit, 4, 0)
        Me.tlp_content2.Controls.Add(Me.uclcomb_HosItem, 2, 0)
        Me.tlp_content2.Controls.Add(Me.lb_ChargeUnit, 3, 0)
        Me.tlp_content2.Controls.Add(Me.lb_HosFee, 1, 0)
        Me.tlp_content2.Controls.Add(Me.lb_last_purchase, 5, 0)
        Me.tlp_content2.Controls.Add(Me.txt_purchaseprice, 6, 0)
        Me.tlp_content2.Controls.Add(Me.txt_purchaseunit, 7, 0)
        Me.tlp_content2.Controls.Add(Me.lb_storagetype, 8, 0)
        Me.tlp_content2.Controls.Add(Me.uclcomb_OrderType, 0, 0)
        Me.tlp_content2.Controls.Add(Me.txt_storagetype, 9, 0)
        Me.tlp_content2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_content2.Location = New System.Drawing.Point(81, 73)
        Me.tlp_content2.Name = "tlp_content2"
        Me.tlp_content2.RowCount = 1
        Me.tlp_content2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_content2.Size = New System.Drawing.Size(860, 29)
        Me.tlp_content2.TabIndex = 4
        '
        'txt_ChargeUnit
        '
        Me.txt_ChargeUnit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ChargeUnit.Location = New System.Drawing.Point(382, 1)
        Me.txt_ChargeUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_ChargeUnit.MaxLength = 8
        Me.txt_ChargeUnit.Name = "txt_ChargeUnit"
        Me.txt_ChargeUnit.Size = New System.Drawing.Size(54, 27)
        Me.txt_ChargeUnit.TabIndex = 15
        '
        'uclcomb_HosItem
        '
        Me.uclcomb_HosItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_HosItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_HosItem.DropDownWidth = 20
        Me.uclcomb_HosItem.DroppedDown = False
        Me.uclcomb_HosItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_HosItem.Location = New System.Drawing.Point(204, 2)
        Me.uclcomb_HosItem.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_HosItem.Name = "uclcomb_HosItem"
        Me.uclcomb_HosItem.SelectedIndex = -1
        Me.uclcomb_HosItem.SelectedItem = Nothing
        Me.uclcomb_HosItem.SelectedText = ""
        Me.uclcomb_HosItem.SelectedValue = ""
        Me.uclcomb_HosItem.SelectionStart = 0
        Me.uclcomb_HosItem.Size = New System.Drawing.Size(100, 24)
        Me.uclcomb_HosItem.TabIndex = 9
        Me.uclcomb_HosItem.uclDisplayIndex = "0,1"
        Me.uclcomb_HosItem.uclIsAutoClear = True
        Me.uclcomb_HosItem.uclIsFirstItemEmpty = True
        Me.uclcomb_HosItem.uclIsTextMode = False
        Me.uclcomb_HosItem.uclShowMsg = False
        Me.uclcomb_HosItem.uclValueIndex = "0"
        '
        'lb_ChargeUnit
        '
        Me.lb_ChargeUnit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_ChargeUnit.AutoSize = True
        Me.lb_ChargeUnit.ForeColor = System.Drawing.Color.Red
        Me.lb_ChargeUnit.Location = New System.Drawing.Point(307, 6)
        Me.lb_ChargeUnit.Margin = New System.Windows.Forms.Padding(3)
        Me.lb_ChargeUnit.Name = "lb_ChargeUnit"
        Me.lb_ChargeUnit.Size = New System.Drawing.Size(72, 16)
        Me.lb_ChargeUnit.TabIndex = 1
        Me.lb_ChargeUnit.Text = "計價單位"
        '
        'lb_HosFee
        '
        Me.lb_HosFee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_HosFee.AutoSize = True
        Me.lb_HosFee.ForeColor = System.Drawing.Color.Red
        Me.lb_HosFee.Location = New System.Drawing.Point(100, 6)
        Me.lb_HosFee.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_HosFee.Name = "lb_HosFee"
        Me.lb_HosFee.Size = New System.Drawing.Size(104, 16)
        Me.lb_HosFee.TabIndex = 0
        Me.lb_HosFee.Text = "院內費用項目"
        '
        'lb_last_purchase
        '
        Me.lb_last_purchase.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_last_purchase.AutoSize = True
        Me.lb_last_purchase.Location = New System.Drawing.Point(439, 6)
        Me.lb_last_purchase.Name = "lb_last_purchase"
        Me.lb_last_purchase.Size = New System.Drawing.Size(104, 16)
        Me.lb_last_purchase.TabIndex = 12
        Me.lb_last_purchase.Text = "最後採購單價"
        Me.lb_last_purchase.Visible = False
        '
        'txt_purchaseprice
        '
        Me.txt_purchaseprice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_purchaseprice.Enabled = False
        Me.txt_purchaseprice.Location = New System.Drawing.Point(546, 1)
        Me.txt_purchaseprice.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_purchaseprice.Name = "txt_purchaseprice"
        Me.txt_purchaseprice.Size = New System.Drawing.Size(74, 27)
        Me.txt_purchaseprice.TabIndex = 13
        Me.txt_purchaseprice.Visible = False
        '
        'txt_purchaseunit
        '
        Me.txt_purchaseunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_purchaseunit.Enabled = False
        Me.txt_purchaseunit.Location = New System.Drawing.Point(620, 1)
        Me.txt_purchaseunit.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_purchaseunit.Name = "txt_purchaseunit"
        Me.txt_purchaseunit.Size = New System.Drawing.Size(44, 27)
        Me.txt_purchaseunit.TabIndex = 14
        Me.txt_purchaseunit.Visible = False
        '
        'lb_storagetype
        '
        Me.lb_storagetype.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_storagetype.AutoSize = True
        Me.lb_storagetype.Location = New System.Drawing.Point(667, 6)
        Me.lb_storagetype.Name = "lb_storagetype"
        Me.lb_storagetype.Size = New System.Drawing.Size(88, 16)
        Me.lb_storagetype.TabIndex = 15
        Me.lb_storagetype.Text = "使用庫房別"
        Me.lb_storagetype.Visible = False
        '
        'uclcomb_OrderType
        '
        Me.uclcomb_OrderType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_OrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_OrderType.DropDownWidth = 20
        Me.uclcomb_OrderType.DroppedDown = False
        Me.uclcomb_OrderType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_OrderType.Location = New System.Drawing.Point(0, 2)
        Me.uclcomb_OrderType.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_OrderType.Name = "uclcomb_OrderType"
        Me.uclcomb_OrderType.SelectedIndex = -1
        Me.uclcomb_OrderType.SelectedItem = Nothing
        Me.uclcomb_OrderType.SelectedText = ""
        Me.uclcomb_OrderType.SelectedValue = ""
        Me.uclcomb_OrderType.SelectionStart = 0
        Me.uclcomb_OrderType.Size = New System.Drawing.Size(100, 24)
        Me.uclcomb_OrderType.TabIndex = 8
        Me.uclcomb_OrderType.uclDisplayIndex = "0,1"
        Me.uclcomb_OrderType.uclIsAutoClear = True
        Me.uclcomb_OrderType.uclIsFirstItemEmpty = True
        Me.uclcomb_OrderType.uclIsTextMode = False
        Me.uclcomb_OrderType.uclShowMsg = False
        Me.uclcomb_OrderType.uclValueIndex = "0"
        '
        'txt_storagetype
        '
        Me.txt_storagetype.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_storagetype.Enabled = False
        Me.txt_storagetype.Location = New System.Drawing.Point(761, 3)
        Me.txt_storagetype.Name = "txt_storagetype"
        Me.txt_storagetype.Size = New System.Drawing.Size(62, 27)
        Me.txt_storagetype.TabIndex = 16
        Me.txt_storagetype.Visible = False
        '
        'gb_OrderPrice
        '
        Me.gb_OrderPrice.Controls.Add(Me.ucldgv_OrderPrice)
        Me.gb_OrderPrice.Controls.Add(Me.cb_pricehistory)
        Me.gb_OrderPrice.Controls.Add(Me.lb_Nhi_Name)
        Me.gb_OrderPrice.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderPrice.Location = New System.Drawing.Point(4, 421)
        Me.gb_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Name = "gb_OrderPrice"
        Me.gb_OrderPrice.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Size = New System.Drawing.Size(955, 150)
        Me.gb_OrderPrice.TabIndex = 2
        Me.gb_OrderPrice.TabStop = False
        Me.gb_OrderPrice.Text = "醫令項目價格"
        '
        'ucldgv_OrderPrice
        '
        Me.ucldgv_OrderPrice.AllowUserToAddRows = False
        Me.ucldgv_OrderPrice.AllowUserToOrderColumns = False
        Me.ucldgv_OrderPrice.AllowUserToResizeColumns = True
        Me.ucldgv_OrderPrice.AllowUserToResizeRows = False
        Me.ucldgv_OrderPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucldgv_OrderPrice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ucldgv_OrderPrice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ucldgv_OrderPrice.ColumnHeadersHeight = 4
        Me.ucldgv_OrderPrice.ColumnHeadersVisible = True
        Me.ucldgv_OrderPrice.CurrentCell = Nothing
        Me.ucldgv_OrderPrice.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucldgv_OrderPrice.DefaultCellStyle = DataGridViewCellStyle2
        Me.ucldgv_OrderPrice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucldgv_OrderPrice.Location = New System.Drawing.Point(5, 28)
        Me.ucldgv_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.ucldgv_OrderPrice.MultiSelect = False
        Me.ucldgv_OrderPrice.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucldgv_OrderPrice.Name = "ucldgv_OrderPrice"
        Me.ucldgv_OrderPrice.RowHeadersWidth = 41
        Me.ucldgv_OrderPrice.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucldgv_OrderPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucldgv_OrderPrice.Size = New System.Drawing.Size(938, 114)
        Me.ucldgv_OrderPrice.TabIndex = 7
        Me.ucldgv_OrderPrice.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.ucldgv_OrderPrice.uclBatchColIndex = ""
        Me.ucldgv_OrderPrice.uclClickToCheck = False
        Me.ucldgv_OrderPrice.uclColumnAlignment = ""
        Me.ucldgv_OrderPrice.uclColumnCheckBox = False
        Me.ucldgv_OrderPrice.uclColumnControlType = ""
        Me.ucldgv_OrderPrice.uclColumnWidth = ""
        Me.ucldgv_OrderPrice.uclDoCellEnter = True
        Me.ucldgv_OrderPrice.uclHasNewRow = False
        Me.ucldgv_OrderPrice.uclHeaderText = ""
        Me.ucldgv_OrderPrice.uclIsAlternatingRowsColors = True
        Me.ucldgv_OrderPrice.uclIsComboBoxGridQuery = True
        Me.ucldgv_OrderPrice.uclIsComboxClickTriggerDropDown = False
        Me.ucldgv_OrderPrice.uclIsDoOrderCheck = True
        Me.ucldgv_OrderPrice.uclIsSortable = False
        Me.ucldgv_OrderPrice.uclMultiSelectShowCheckBoxHeader = True
        Me.ucldgv_OrderPrice.uclNonVisibleColIndex = ""
        Me.ucldgv_OrderPrice.uclReadOnly = False
        Me.ucldgv_OrderPrice.uclShowCellBorder = False
        Me.ucldgv_OrderPrice.uclSortColIndex = ""
        Me.ucldgv_OrderPrice.uclTreeMode = False
        Me.ucldgv_OrderPrice.uclVisibleColIndex = ""
        '
        'cb_pricehistory
        '
        Me.cb_pricehistory.AutoSize = True
        Me.cb_pricehistory.Location = New System.Drawing.Point(113, 1)
        Me.cb_pricehistory.Name = "cb_pricehistory"
        Me.cb_pricehistory.Size = New System.Drawing.Size(107, 20)
        Me.cb_pricehistory.TabIndex = 6
        Me.cb_pricehistory.Text = "價格歷史檔"
        Me.cb_pricehistory.UseVisualStyleBackColor = True
        '
        'lb_Nhi_Name
        '
        Me.lb_Nhi_Name.AutoSize = True
        Me.lb_Nhi_Name.Location = New System.Drawing.Point(420, 5)
        Me.lb_Nhi_Name.Name = "lb_Nhi_Name"
        Me.lb_Nhi_Name.Size = New System.Drawing.Size(0, 16)
        Me.lb_Nhi_Name.TabIndex = 3
        '
        'gb_btn
        '
        Me.gb_btn.Controls.Add(Me.TableLayoutPanel3)
        Me.gb_btn.Location = New System.Drawing.Point(3, 578)
        Me.gb_btn.Name = "gb_btn"
        Me.gb_btn.Size = New System.Drawing.Size(957, 59)
        Me.gb_btn.TabIndex = 3
        Me.gb_btn.TabStop = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel1, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.chk_OrderHistory, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_SelfpayApply, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_NextRecord, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_PreRecord, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(951, 33)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_AddQuery)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(443, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(505, 27)
        Me.FlowLayoutPanel1.TabIndex = 37
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Clear.Location = New System.Drawing.Point(406, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_Clear.TabIndex = 33
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Confirm.Location = New System.Drawing.Point(315, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(85, 27)
        Me.btn_Confirm.TabIndex = 32
        Me.btn_Confirm.Text = "F12-確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Query.Location = New System.Drawing.Point(233, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(76, 27)
        Me.btn_Query.TabIndex = 31
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Delete.Location = New System.Drawing.Point(142, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(85, 27)
        Me.btn_Delete.TabIndex = 30
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_AddQuery
        '
        Me.btn_AddQuery.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_AddQuery.Location = New System.Drawing.Point(29, 3)
        Me.btn_AddQuery.Name = "btn_AddQuery"
        Me.btn_AddQuery.Size = New System.Drawing.Size(107, 27)
        Me.btn_AddQuery.TabIndex = 37
        Me.btn_AddQuery.Text = "各類加成查詢"
        Me.btn_AddQuery.UseVisualStyleBackColor = True
        '
        'chk_OrderHistory
        '
        Me.chk_OrderHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_OrderHistory.AutoSize = True
        Me.chk_OrderHistory.Location = New System.Drawing.Point(146, 6)
        Me.chk_OrderHistory.Name = "chk_OrderHistory"
        Me.chk_OrderHistory.Size = New System.Drawing.Size(107, 20)
        Me.chk_OrderHistory.TabIndex = 34
        Me.chk_OrderHistory.Text = "醫令歷史檔"
        Me.chk_OrderHistory.UseVisualStyleBackColor = True
        Me.chk_OrderHistory.Visible = False
        '
        'btn_SelfpayApply
        '
        Me.btn_SelfpayApply.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_SelfpayApply.Location = New System.Drawing.Point(259, 3)
        Me.btn_SelfpayApply.Name = "btn_SelfpayApply"
        Me.btn_SelfpayApply.Size = New System.Drawing.Size(178, 27)
        Me.btn_SelfpayApply.TabIndex = 36
        Me.btn_SelfpayApply.Text = "自費衛材核定記錄維護"
        Me.btn_SelfpayApply.UseVisualStyleBackColor = True
        '
        'btn_NextRecord
        '
        Me.btn_NextRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NextRecord.Location = New System.Drawing.Point(76, 3)
        Me.btn_NextRecord.Name = "btn_NextRecord"
        Me.btn_NextRecord.Size = New System.Drawing.Size(64, 27)
        Me.btn_NextRecord.TabIndex = 29
        Me.btn_NextRecord.Text = "下一筆"
        Me.btn_NextRecord.UseVisualStyleBackColor = True
        '
        'btn_PreRecord
        '
        Me.btn_PreRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_PreRecord.Location = New System.Drawing.Point(3, 3)
        Me.btn_PreRecord.Name = "btn_PreRecord"
        Me.btn_PreRecord.Size = New System.Drawing.Size(67, 27)
        Me.btn_PreRecord.TabIndex = 28
        Me.btn_PreRecord.Text = "上一筆"
        Me.btn_PreRecord.UseVisualStyleBackColor = True
        '
        'PUBOrderMaterialUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 646)
        Me.Controls.Add(Me.tbp_Parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBOrderMaterialUI"
        Me.TabText = "醫療支付公用主檔-衛材"
        Me.Text = "醫療支付公用主檔-衛材"
        Me.tbp_Parent.ResumeLayout(False)
        Me.gb_Condition.ResumeLayout(False)
        Me.tlp_Condition.ResumeLayout(False)
        Me.tlp_Condition.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.gb_transunit.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.tlp_check.ResumeLayout(False)
        Me.tlp_check.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tbp_EffectDate.ResumeLayout(False)
        Me.tbp_EffectDate.PerformLayout()
        Me.gb_OrderItem.ResumeLayout(False)
        Me.tbp_1.ResumeLayout(False)
        Me.tbp_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tbp_OrderMemo.ResumeLayout(False)
        Me.tbp_OrderMemo.PerformLayout()
        Me.tbp_EnName.ResumeLayout(False)
        Me.tbp_EnName.PerformLayout()
        Me.tp_date.ResumeLayout(False)
        Me.tp_date.PerformLayout()
        Me.tbp_ZhName.ResumeLayout(False)
        Me.tbp_ZhName.PerformLayout()
        Me.tlp_content2.ResumeLayout(False)
        Me.tlp_content2.PerformLayout()
        Me.gb_OrderPrice.ResumeLayout(False)
        Me.gb_OrderPrice.PerformLayout()
        Me.gb_btn.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbp_Parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_Condition As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderItem As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderPrice As System.Windows.Forms.GroupBox
    Friend WithEvents gb_btn As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_Condition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_NhiCode As System.Windows.Forms.Label
    Friend WithEvents lb_Name As System.Windows.Forms.Label
    Friend WithEvents lb_TWName As System.Windows.Forms.Label
    Friend WithEvents lb_EnName As System.Windows.Forms.Label
    Friend WithEvents lb_OrderType As System.Windows.Forms.Label
    Friend WithEvents lb_OrderPS As System.Windows.Forms.Label
    Friend WithEvents lb_EffectDate As System.Windows.Forms.Label
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents btn_PreRecord As System.Windows.Forms.Button
    Friend WithEvents btn_NextRecord As System.Windows.Forms.Button
    Friend WithEvents tbp_ZhName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_EnName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_OrderMemo As System.Windows.Forms.TableLayoutPanel
    ' modify by 唐子晴 2013.11.25======================================
    ''Friend WithEvents lb_OrderRemark As System.Windows.Forms.Label
    Friend WithEvents btn_OrderRemark As System.Windows.Forms.Button
    '==================================================================
    Friend WithEvents lb_Mark As System.Windows.Forms.Label
    Friend WithEvents txt_Note As System.Windows.Forms.TextBox
    'modify by 唐子晴 2013.11.25=======================================
    ''Friend WithEvents txt_Flag As System.Windows.Forms.TextBox
    Friend WithEvents ucl_Flag As Syscom.Client.UCL.UCLComboBoxUC
    '==================================================================
    Friend WithEvents tbp_EffectDate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucldtp_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lb_Classify As System.Windows.Forms.Label
    Friend WithEvents uclcb_classify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_NhiSheet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Nhi As System.Windows.Forms.Button
    Friend WithEvents tlp_check As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_OrderCheck As System.Windows.Forms.CheckBox
    Friend WithEvents cb_Indication As System.Windows.Forms.CheckBox
    Friend WithEvents btn_OrderCheck As System.Windows.Forms.Button
    Friend WithEvents btn_Indication As System.Windows.Forms.Button
    Friend WithEvents cb_Dc As System.Windows.Forms.CheckBox
    Friend WithEvents txt_EnName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ZhName As System.Windows.Forms.TextBox
    Friend WithEvents lb_SEName As System.Windows.Forms.Label
    Friend WithEvents txt_SEName As System.Windows.Forms.TextBox
    Friend WithEvents lb_SCName As System.Windows.Forms.Label
    Friend WithEvents txt_SCName As System.Windows.Forms.TextBox
    Friend WithEvents lb_HosFee As System.Windows.Forms.Label
    Friend WithEvents lb_ChargeUnit As System.Windows.Forms.Label
    Friend WithEvents uclcomb_HosItem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_OrderType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_OrderCode As System.Windows.Forms.Label
    Friend WithEvents tlp_content2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_NhiCode As System.Windows.Forms.TextBox
    Friend WithEvents gb_transunit As System.Windows.Forms.GroupBox
    Friend WithEvents cb_preview As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_format As System.Windows.Forms.Label
    Friend WithEvents txt_format As System.Windows.Forms.TextBox
    Friend WithEvents lb_last_purchase As System.Windows.Forms.Label
    Friend WithEvents txt_purchaseprice As System.Windows.Forms.TextBox
    Friend WithEvents txt_purchaseunit As System.Windows.Forms.TextBox
    Friend WithEvents lb_storagetype As System.Windows.Forms.Label
    Friend WithEvents lb_chargetransferclaim As System.Windows.Forms.Label
    Friend WithEvents lb_claimunit As System.Windows.Forms.Label
    Friend WithEvents lb_material_use_cnt As System.Windows.Forms.Label
    Friend WithEvents ucl_mat_use_cnt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents tp_date As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_enddate As System.Windows.Forms.Label
    Friend WithEvents ucl_dtp_enddate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Brand As System.Windows.Forms.TextBox
    Friend WithEvents lb_Nhi_Name As System.Windows.Forms.Label
    Friend WithEvents chk_OrderHistory As System.Windows.Forms.CheckBox
    Friend WithEvents txt_ChargeUnit As System.Windows.Forms.TextBox
    Friend WithEvents txt_ClaimUnit As System.Windows.Forms.TextBox
    Friend WithEvents txt_storagetype As System.Windows.Forms.TextBox
    Friend WithEvents cbo_OPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_IncludeOrder As System.Windows.Forms.TextBox
    Friend WithEvents cbo_IPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_EMG As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_SelfpayApply As System.Windows.Forms.Button
    'add by 唐子晴 2013.12.11 --------------------------------------------
    Friend WithEvents lb_PriceAdjustment As System.Windows.Forms.Label
    Friend WithEvents ucl_PriceAdjustment As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents memo_OrderMemo As System.Windows.Forms.TextBox
    Friend WithEvents cb_pricehistory As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_AddQuery As System.Windows.Forms.Button
    Friend WithEvents PUBMaterialUI_ucl_txtcq_ordercode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lb_OrderRemark As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_CostPrice As System.Windows.Forms.TextBox
    Friend WithEvents txt_chargetransclaim As System.Windows.Forms.TextBox
    Friend WithEvents chk_IncludeOrderMark As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_OrederNote As System.Windows.Forms.RichTextBox
    Friend WithEvents ucldgv_OrderPrice As Syscom.Client.UCL.UCLDataGridViewUC
    '---------------------------------------------------------------------
End Class
