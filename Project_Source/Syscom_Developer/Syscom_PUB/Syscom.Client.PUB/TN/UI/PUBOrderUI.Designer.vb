<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBOrderUI
    'Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form
    Inherits Syscom.Client.UCL.BaseFormUI

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            '2015-04-27 Delete by Alan
            'pvtReceiveMgr = Nothing
            'If disposing AndAlso components IsNot Nothing Then
            '    components.Dispose()
            'End If
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBOrderUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grb_Condition = New System.Windows.Forms.GroupBox()
        Me.tbp_Condition = New System.Windows.Forms.TableLayoutPanel()
        Me.PUBOrderUI_ucl_txtcq_ordercode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lb_OrderCode = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lb_Name = New System.Windows.Forms.Label()
        Me.txt_NhiCode = New System.Windows.Forms.TextBox()
        Me.lb_NhiCode = New System.Windows.Forms.Label()
        Me.cb_Indication = New System.Windows.Forms.CheckBox()
        Me.cb_OrderCheck = New System.Windows.Forms.CheckBox()
        Me.btn_OrderCheck = New System.Windows.Forms.Button()
        Me.btn_Indication = New System.Windows.Forms.Button()
        Me.lb_OrderProp = New System.Windows.Forms.Label()
        Me.lb_Fee = New System.Windows.Forms.Label()
        Me.cb_NhiCureTypeId = New System.Windows.Forms.CheckBox()
        Me.uclcomb_order_treat_prop = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_fix_fee = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_NhiCureControl = New System.Windows.Forms.Button()
        Me.ucldtp_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.cb_Dc = New System.Windows.Forms.CheckBox()
        Me.lb_enddate = New System.Windows.Forms.Label()
        Me.cbo_IPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_OPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_EMG = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ucl_dtp_enddate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.memo_OrderMemo = New System.Windows.Forms.TextBox()
        Me.lb_OrderRemark = New System.Windows.Forms.Label()
        Me.lb_Mark = New System.Windows.Forms.Label()
        Me.txt_Note = New System.Windows.Forms.TextBox()
        Me.txt_Flag = New System.Windows.Forms.TextBox()
        Me.txt_EnName = New System.Windows.Forms.TextBox()
        Me.lb_SEName = New System.Windows.Forms.Label()
        Me.txt_SEName = New System.Windows.Forms.TextBox()
        Me.lb_TWName = New System.Windows.Forms.Label()
        Me.lb_Majorcare = New System.Windows.Forms.Label()
        Me.uclcomb_majorcare = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_HosFee = New System.Windows.Forms.Label()
        Me.lb_ChargeUnit = New System.Windows.Forms.Label()
        Me.uclcomb_HosItem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_OrderType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_ChargeUnit = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_EnName = New System.Windows.Forms.Label()
        Me.lb_OrderType = New System.Windows.Forms.Label()
        Me.lb_OrderPS = New System.Windows.Forms.Label()
        Me.lb_EffectDate = New System.Windows.Forms.Label()
        Me.txt_ZhName = New System.Windows.Forms.TextBox()
        Me.lb_SCName = New System.Windows.Forms.Label()
        Me.txt_SCName = New System.Windows.Forms.TextBox()
        Me.txt_IncludeOrder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_NhiSheet = New System.Windows.Forms.CheckBox()
        Me.cb_orderprice_spec = New System.Windows.Forms.CheckBox()
        Me.uclcb_classify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_Classify = New System.Windows.Forms.Label()
        Me.btn_Nhi = New System.Windows.Forms.Button()
        Me.cb_pricehistory = New System.Windows.Forms.CheckBox()
        Me.lb_Nhi_Name = New System.Windows.Forms.Label()
        Me.ucldgv_OrderPrice = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.chk_OrderHistory = New System.Windows.Forms.CheckBox()
        Me.btn_PreRecord = New System.Windows.Forms.Button()
        Me.btn_NextRecord = New System.Windows.Forms.Button()
        Me.tbp_Parent = New System.Windows.Forms.TableLayoutPanel()
        Me.tbp_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.grb_OrderPrice = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_AddQuery = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.grb_Condition.SuspendLayout()
        Me.tbp_Condition.SuspendLayout()
        Me.tbp_Parent.SuspendLayout()
        Me.tbp_1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.grb_OrderPrice.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'grb_Condition
        '
        Me.grb_Condition.Controls.Add(Me.tbp_Condition)
        Me.grb_Condition.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.grb_Condition.Location = New System.Drawing.Point(4, 4)
        Me.grb_Condition.Margin = New System.Windows.Forms.Padding(4)
        Me.grb_Condition.Name = "grb_Condition"
        Me.grb_Condition.Padding = New System.Windows.Forms.Padding(4)
        Me.grb_Condition.Size = New System.Drawing.Size(956, 61)
        Me.grb_Condition.TabIndex = 0
        Me.grb_Condition.TabStop = False
        Me.grb_Condition.Text = "查詢區"
        '
        'tbp_Condition
        '
        Me.tbp_Condition.ColumnCount = 7
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_Condition.Controls.Add(Me.PUBOrderUI_ucl_txtcq_ordercode, 1, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_OrderCode, 0, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_Name, 6, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_Name, 5, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_NhiCode, 4, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_NhiCode, 3, 0)
        Me.tbp_Condition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_Condition.Location = New System.Drawing.Point(4, 24)
        Me.tbp_Condition.Name = "tbp_Condition"
        Me.tbp_Condition.RowCount = 1
        Me.tbp_Condition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Condition.Size = New System.Drawing.Size(948, 33)
        Me.tbp_Condition.TabIndex = 0
        '
        'PUBOrderUI_ucl_txtcq_ordercode
        '
        Me.PUBOrderUI_ucl_txtcq_ordercode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PUBOrderUI_ucl_txtcq_ordercode.doFlag = True
        Me.PUBOrderUI_ucl_txtcq_ordercode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PUBOrderUI_ucl_txtcq_ordercode.Location = New System.Drawing.Point(110, 3)
        Me.PUBOrderUI_ucl_txtcq_ordercode.Margin = New System.Windows.Forms.Padding(0)
        Me.PUBOrderUI_ucl_txtcq_ordercode.Name = "PUBOrderUI_ucl_txtcq_ordercode"
        Me.PUBOrderUI_ucl_txtcq_ordercode.Size = New System.Drawing.Size(303, 27)
        Me.PUBOrderUI_ucl_txtcq_ordercode.TabIndex = 7
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclBaseDate = "2015/04/28"
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCboWidth = 264
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeName = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeName1 = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeName2 = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclControlFlag = True
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclDisplayIndex = "0,1"
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsAutoAddZero = False
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsBtnVisible = True
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsCheckDoctorOnDuty = False
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsEnglishDept = False
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsReturnDS = True
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsShowMsgBox = True
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclIsTextAutoClear = False
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclLabel = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclMsgValue = Nothing
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclPUBEmployeeProfessalKindId = ""
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclQueryField = Nothing
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclQueryValue = "D"
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_OrderForMantain
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclTotalWidth = 8
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclXPosition = 225
        Me.PUBOrderUI_ucl_txtcq_ordercode.uclYPosition = 120
        '
        'lb_OrderCode
        '
        Me.lb_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_OrderCode.AutoSize = True
        Me.lb_OrderCode.ForeColor = System.Drawing.Color.Red
        Me.lb_OrderCode.Location = New System.Drawing.Point(3, 8)
        Me.lb_OrderCode.Name = "lb_OrderCode"
        Me.lb_OrderCode.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderCode.TabIndex = 0
        Me.lb_OrderCode.Text = "醫令項目代碼"
        '
        'txt_Name
        '
        Me.txt_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Name.Enabled = False
        Me.txt_Name.Location = New System.Drawing.Point(572, 3)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(62, 27)
        Me.txt_Name.TabIndex = 3
        Me.txt_Name.Visible = False
        '
        'lb_Name
        '
        Me.lb_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Name.AutoSize = True
        Me.lb_Name.Location = New System.Drawing.Point(526, 8)
        Me.lb_Name.Name = "lb_Name"
        Me.lb_Name.Size = New System.Drawing.Size(40, 16)
        Me.lb_Name.TabIndex = 6
        Me.lb_Name.Text = "名稱"
        Me.lb_Name.Visible = False
        '
        'txt_NhiCode
        '
        Me.txt_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NhiCode.Enabled = False
        Me.txt_NhiCode.Location = New System.Drawing.Point(478, 3)
        Me.txt_NhiCode.Name = "txt_NhiCode"
        Me.txt_NhiCode.Size = New System.Drawing.Size(42, 27)
        Me.txt_NhiCode.TabIndex = 4
        Me.txt_NhiCode.Visible = False
        '
        'lb_NhiCode
        '
        Me.lb_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_NhiCode.AutoSize = True
        Me.lb_NhiCode.Location = New System.Drawing.Point(416, 8)
        Me.lb_NhiCode.Name = "lb_NhiCode"
        Me.lb_NhiCode.Size = New System.Drawing.Size(56, 16)
        Me.lb_NhiCode.TabIndex = 1
        Me.lb_NhiCode.Text = "健保碼"
        Me.lb_NhiCode.Visible = False
        '
        'cb_Indication
        '
        Me.cb_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_Indication.AutoSize = True
        Me.cb_Indication.Location = New System.Drawing.Point(93, 69)
        Me.cb_Indication.Name = "cb_Indication"
        Me.cb_Indication.Size = New System.Drawing.Size(15, 14)
        Me.cb_Indication.TabIndex = 17
        Me.cb_Indication.UseVisualStyleBackColor = True
        '
        'cb_OrderCheck
        '
        Me.cb_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_OrderCheck.AutoSize = True
        Me.cb_OrderCheck.Location = New System.Drawing.Point(30, 46)
        Me.cb_OrderCheck.Margin = New System.Windows.Forms.Padding(30, 3, 3, 3)
        Me.cb_OrderCheck.Name = "cb_OrderCheck"
        Me.cb_OrderCheck.Size = New System.Drawing.Size(15, 14)
        Me.cb_OrderCheck.TabIndex = 15
        Me.cb_OrderCheck.UseVisualStyleBackColor = True
        Me.cb_OrderCheck.Visible = False
        '
        'btn_OrderCheck
        '
        Me.btn_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_OrderCheck.Location = New System.Drawing.Point(0, 63)
        Me.btn_OrderCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_OrderCheck.Name = "btn_OrderCheck"
        Me.btn_OrderCheck.Size = New System.Drawing.Size(90, 27)
        Me.btn_OrderCheck.TabIndex = 16
        Me.btn_OrderCheck.Text = "醫令檢核"
        Me.btn_OrderCheck.UseVisualStyleBackColor = True
        Me.btn_OrderCheck.Visible = False
        '
        'btn_Indication
        '
        Me.btn_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Indication.Location = New System.Drawing.Point(0, 90)
        Me.btn_Indication.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Indication.Name = "btn_Indication"
        Me.btn_Indication.Size = New System.Drawing.Size(90, 27)
        Me.btn_Indication.TabIndex = 18
        Me.btn_Indication.Text = "適應症"
        Me.btn_Indication.UseVisualStyleBackColor = True
        Me.btn_Indication.Visible = False
        '
        'lb_OrderProp
        '
        Me.lb_OrderProp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderProp.AutoSize = True
        Me.lb_OrderProp.Location = New System.Drawing.Point(405, 118)
        Me.lb_OrderProp.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.lb_OrderProp.Name = "lb_OrderProp"
        Me.lb_OrderProp.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderProp.TabIndex = 5
        Me.lb_OrderProp.Text = "醫令治療屬性"
        '
        'lb_Fee
        '
        Me.lb_Fee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Fee.AutoSize = True
        Me.lb_Fee.ForeColor = System.Drawing.Color.Black
        Me.lb_Fee.Location = New System.Drawing.Point(3, 5)
        Me.lb_Fee.Name = "lb_Fee"
        Me.lb_Fee.Size = New System.Drawing.Size(72, 16)
        Me.lb_Fee.TabIndex = 6
        Me.lb_Fee.Text = "固定費用"
        '
        'cb_NhiCureTypeId
        '
        Me.cb_NhiCureTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiCureTypeId.AutoSize = True
        Me.cb_NhiCureTypeId.Enabled = False
        Me.cb_NhiCureTypeId.Location = New System.Drawing.Point(240, 6)
        Me.cb_NhiCureTypeId.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.cb_NhiCureTypeId.Name = "cb_NhiCureTypeId"
        Me.cb_NhiCureTypeId.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiCureTypeId.TabIndex = 22
        Me.cb_NhiCureTypeId.UseVisualStyleBackColor = True
        '
        'uclcomb_order_treat_prop
        '
        Me.uclcomb_order_treat_prop.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_order_treat_prop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_order_treat_prop.DropDownWidth = 20
        Me.uclcomb_order_treat_prop.DroppedDown = False
        Me.uclcomb_order_treat_prop.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_order_treat_prop.Location = New System.Drawing.Point(512, 114)
        Me.uclcomb_order_treat_prop.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_order_treat_prop.Name = "uclcomb_order_treat_prop"
        Me.uclcomb_order_treat_prop.SelectedIndex = -1
        Me.uclcomb_order_treat_prop.SelectedItem = Nothing
        Me.uclcomb_order_treat_prop.SelectedText = ""
        Me.uclcomb_order_treat_prop.SelectedValue = ""
        Me.uclcomb_order_treat_prop.SelectionStart = 0
        Me.uclcomb_order_treat_prop.Size = New System.Drawing.Size(172, 24)
        Me.uclcomb_order_treat_prop.TabIndex = 20
        Me.uclcomb_order_treat_prop.uclDisplayIndex = "0,1"
        Me.uclcomb_order_treat_prop.uclIsAutoClear = True
        Me.uclcomb_order_treat_prop.uclIsFirstItemEmpty = True
        Me.uclcomb_order_treat_prop.uclIsTextMode = False
        Me.uclcomb_order_treat_prop.uclShowMsg = False
        Me.uclcomb_order_treat_prop.uclValueIndex = "0"
        '
        'uclcomb_fix_fee
        '
        Me.uclcomb_fix_fee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_fix_fee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_fix_fee.DropDownWidth = 20
        Me.uclcomb_fix_fee.DroppedDown = False
        Me.uclcomb_fix_fee.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_fix_fee.Location = New System.Drawing.Point(78, 1)
        Me.uclcomb_fix_fee.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_fix_fee.Name = "uclcomb_fix_fee"
        Me.uclcomb_fix_fee.SelectedIndex = -1
        Me.uclcomb_fix_fee.SelectedItem = Nothing
        Me.uclcomb_fix_fee.SelectedText = ""
        Me.uclcomb_fix_fee.SelectedValue = ""
        Me.uclcomb_fix_fee.SelectionStart = 0
        Me.uclcomb_fix_fee.Size = New System.Drawing.Size(156, 24)
        Me.uclcomb_fix_fee.TabIndex = 21
        Me.uclcomb_fix_fee.uclDisplayIndex = "0,1"
        Me.uclcomb_fix_fee.uclIsAutoClear = True
        Me.uclcomb_fix_fee.uclIsFirstItemEmpty = True
        Me.uclcomb_fix_fee.uclIsTextMode = False
        Me.uclcomb_fix_fee.uclShowMsg = False
        Me.uclcomb_fix_fee.uclValueIndex = "0"
        '
        'btn_NhiCureControl
        '
        Me.btn_NhiCureControl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NhiCureControl.Location = New System.Drawing.Point(258, 0)
        Me.btn_NhiCureControl.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_NhiCureControl.Name = "btn_NhiCureControl"
        Me.btn_NhiCureControl.Size = New System.Drawing.Size(90, 27)
        Me.btn_NhiCureControl.TabIndex = 23
        Me.btn_NhiCureControl.Text = "健保療程"
        Me.btn_NhiCureControl.UseVisualStyleBackColor = True
        '
        'ucldtp_EffectDate
        '
        Me.ucldtp_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucldtp_EffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucldtp_EffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucldtp_EffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucldtp_EffectDate.Location = New System.Drawing.Point(0, 3)
        Me.ucldtp_EffectDate.Margin = New System.Windows.Forms.Padding(0)
        Me.ucldtp_EffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.Name = "ucldtp_EffectDate"
        Me.ucldtp_EffectDate.Size = New System.Drawing.Size(120, 27)
        Me.ucldtp_EffectDate.TabIndex = 26
        Me.ucldtp_EffectDate.uclReadOnly = False
        '
        'cb_Dc
        '
        Me.cb_Dc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_Dc.AutoSize = True
        Me.cb_Dc.Location = New System.Drawing.Point(123, 6)
        Me.cb_Dc.Name = "cb_Dc"
        Me.cb_Dc.Size = New System.Drawing.Size(59, 20)
        Me.cb_Dc.TabIndex = 19
        Me.cb_Dc.Text = "停用"
        Me.cb_Dc.UseVisualStyleBackColor = True
        '
        'lb_enddate
        '
        Me.lb_enddate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_enddate.AutoSize = True
        Me.lb_enddate.Location = New System.Drawing.Point(188, 8)
        Me.lb_enddate.Name = "lb_enddate"
        Me.lb_enddate.Size = New System.Drawing.Size(72, 16)
        Me.lb_enddate.TabIndex = 27
        Me.lb_enddate.Text = "停用日期"
        '
        'cbo_IPD
        '
        Me.cbo_IPD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IPD.DropDownWidth = 20
        Me.cbo_IPD.DroppedDown = False
        Me.cbo_IPD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IPD.Location = New System.Drawing.Point(636, 4)
        Me.cbo_IPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IPD.Name = "cbo_IPD"
        Me.cbo_IPD.SelectedIndex = -1
        Me.cbo_IPD.SelectedItem = Nothing
        Me.cbo_IPD.SelectedText = ""
        Me.cbo_IPD.SelectedValue = ""
        Me.cbo_IPD.SelectionStart = 0
        Me.cbo_IPD.Size = New System.Drawing.Size(123, 24)
        Me.cbo_IPD.TabIndex = 31
        Me.cbo_IPD.uclDisplayIndex = "0,1"
        Me.cbo_IPD.uclIsAutoClear = True
        Me.cbo_IPD.uclIsFirstItemEmpty = True
        Me.cbo_IPD.uclIsTextMode = False
        Me.cbo_IPD.uclShowMsg = False
        Me.cbo_IPD.uclValueIndex = "0"
        '
        'cbo_OPD
        '
        Me.cbo_OPD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_OPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_OPD.DropDownWidth = 20
        Me.cbo_OPD.DroppedDown = False
        Me.cbo_OPD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_OPD.Location = New System.Drawing.Point(389, 4)
        Me.cbo_OPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_OPD.Name = "cbo_OPD"
        Me.cbo_OPD.SelectedIndex = -1
        Me.cbo_OPD.SelectedItem = Nothing
        Me.cbo_OPD.SelectedText = ""
        Me.cbo_OPD.SelectedValue = ""
        Me.cbo_OPD.SelectionStart = 0
        Me.cbo_OPD.Size = New System.Drawing.Size(123, 24)
        Me.cbo_OPD.TabIndex = 29
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
        Me.cbo_EMG.Location = New System.Drawing.Point(512, 4)
        Me.cbo_EMG.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_EMG.Name = "cbo_EMG"
        Me.cbo_EMG.SelectedIndex = -1
        Me.cbo_EMG.SelectedItem = Nothing
        Me.cbo_EMG.SelectedText = ""
        Me.cbo_EMG.SelectedValue = ""
        Me.cbo_EMG.SelectionStart = 0
        Me.cbo_EMG.Size = New System.Drawing.Size(124, 24)
        Me.cbo_EMG.TabIndex = 30
        Me.cbo_EMG.uclDisplayIndex = "0,1"
        Me.cbo_EMG.uclIsAutoClear = True
        Me.cbo_EMG.uclIsFirstItemEmpty = True
        Me.cbo_EMG.uclIsTextMode = False
        Me.cbo_EMG.uclShowMsg = False
        Me.cbo_EMG.uclValueIndex = "0"
        '
        'ucl_dtp_enddate
        '
        Me.ucl_dtp_enddate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_enddate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_enddate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_enddate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_enddate.Location = New System.Drawing.Point(266, 3)
        Me.ucl_dtp_enddate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.Name = "ucl_dtp_enddate"
        Me.ucl_dtp_enddate.Size = New System.Drawing.Size(120, 27)
        Me.ucl_dtp_enddate.TabIndex = 28
        Me.ucl_dtp_enddate.uclReadOnly = False
        '
        'memo_OrderMemo
        '
        Me.memo_OrderMemo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.memo_OrderMemo.Location = New System.Drawing.Point(0, 16)
        Me.memo_OrderMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.memo_OrderMemo.Name = "memo_OrderMemo"
        Me.memo_OrderMemo.Size = New System.Drawing.Size(301, 27)
        Me.memo_OrderMemo.TabIndex = 15
        '
        'lb_OrderRemark
        '
        Me.lb_OrderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderRemark.AutoSize = True
        Me.lb_OrderRemark.Location = New System.Drawing.Point(45, 118)
        Me.lb_OrderRemark.Name = "lb_OrderRemark"
        Me.lb_OrderRemark.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderRemark.TabIndex = 1
        Me.lb_OrderRemark.Text = "醫令備註"
        '
        'lb_Mark
        '
        Me.lb_Mark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Mark.AutoSize = True
        Me.lb_Mark.Location = New System.Drawing.Point(720, 118)
        Me.lb_Mark.Name = "lb_Mark"
        Me.lb_Mark.Size = New System.Drawing.Size(40, 16)
        Me.lb_Mark.TabIndex = 2
        Me.lb_Mark.Text = "註記"
        Me.lb_Mark.Visible = False
        '
        'txt_Note
        '
        Me.txt_Note.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.txt_Note, 2)
        Me.txt_Note.Location = New System.Drawing.Point(120, 112)
        Me.txt_Note.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Note.Name = "txt_Note"
        Me.txt_Note.Size = New System.Drawing.Size(251, 27)
        Me.txt_Note.TabIndex = 13
        '
        'txt_Flag
        '
        Me.txt_Flag.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Flag.Location = New System.Drawing.Point(763, 112)
        Me.txt_Flag.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Flag.MaxLength = 2
        Me.txt_Flag.Name = "txt_Flag"
        Me.txt_Flag.Size = New System.Drawing.Size(72, 27)
        Me.txt_Flag.TabIndex = 14
        Me.txt_Flag.Visible = False
        '
        'txt_EnName
        '
        Me.txt_EnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.txt_EnName, 2)
        Me.txt_EnName.Location = New System.Drawing.Point(120, 40)
        Me.txt_EnName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_EnName.MaxLength = 100
        Me.txt_EnName.Name = "txt_EnName"
        Me.txt_EnName.Size = New System.Drawing.Size(268, 27)
        Me.txt_EnName.TabIndex = 6
        '
        'lb_SEName
        '
        Me.lb_SEName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SEName.AutoSize = True
        Me.lb_SEName.Location = New System.Drawing.Point(437, 46)
        Me.lb_SEName.Name = "lb_SEName"
        Me.lb_SEName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SEName.TabIndex = 1
        Me.lb_SEName.Text = "英文簡稱"
        '
        'txt_SEName
        '
        Me.txt_SEName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SEName.Location = New System.Drawing.Point(512, 40)
        Me.txt_SEName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SEName.MaxLength = 50
        Me.txt_SEName.Name = "txt_SEName"
        Me.txt_SEName.Size = New System.Drawing.Size(172, 27)
        Me.txt_SEName.TabIndex = 7
        '
        'lb_TWName
        '
        Me.lb_TWName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_TWName.AutoSize = True
        Me.lb_TWName.Location = New System.Drawing.Point(45, 10)
        Me.lb_TWName.Name = "lb_TWName"
        Me.lb_TWName.Size = New System.Drawing.Size(72, 16)
        Me.lb_TWName.TabIndex = 0
        Me.lb_TWName.Text = "中文名稱"
        '
        'lb_Majorcare
        '
        Me.lb_Majorcare.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_Majorcare.AutoSize = True
        Me.lb_Majorcare.Location = New System.Drawing.Point(403, 4)
        Me.lb_Majorcare.Name = "lb_Majorcare"
        Me.lb_Majorcare.Size = New System.Drawing.Size(104, 16)
        Me.lb_Majorcare.TabIndex = 2
        Me.lb_Majorcare.Text = "特定治療項目"
        '
        'uclcomb_majorcare
        '
        Me.uclcomb_majorcare.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_majorcare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_majorcare.DropDownWidth = 20
        Me.uclcomb_majorcare.DroppedDown = False
        Me.uclcomb_majorcare.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_majorcare.Location = New System.Drawing.Point(510, 0)
        Me.uclcomb_majorcare.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_majorcare.Name = "uclcomb_majorcare"
        Me.uclcomb_majorcare.SelectedIndex = -1
        Me.uclcomb_majorcare.SelectedItem = Nothing
        Me.uclcomb_majorcare.SelectedText = ""
        Me.uclcomb_majorcare.SelectedValue = ""
        Me.uclcomb_majorcare.SelectionStart = 0
        Me.uclcomb_majorcare.Size = New System.Drawing.Size(167, 24)
        Me.uclcomb_majorcare.TabIndex = 11
        Me.uclcomb_majorcare.uclDisplayIndex = "0,1"
        Me.uclcomb_majorcare.uclIsAutoClear = True
        Me.uclcomb_majorcare.uclIsFirstItemEmpty = True
        Me.uclcomb_majorcare.uclIsTextMode = False
        Me.uclcomb_majorcare.uclShowMsg = False
        Me.uclcomb_majorcare.uclValueIndex = "0"
        '
        'lb_HosFee
        '
        Me.lb_HosFee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_HosFee.AutoSize = True
        Me.lb_HosFee.ForeColor = System.Drawing.Color.Red
        Me.lb_HosFee.Location = New System.Drawing.Point(4, 4)
        Me.lb_HosFee.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.lb_HosFee.Name = "lb_HosFee"
        Me.lb_HosFee.Size = New System.Drawing.Size(104, 16)
        Me.lb_HosFee.TabIndex = 0
        Me.lb_HosFee.Text = "院內費用項目"
        '
        'lb_ChargeUnit
        '
        Me.lb_ChargeUnit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_ChargeUnit.AutoSize = True
        Me.lb_ChargeUnit.ForeColor = System.Drawing.Color.Black
        Me.lb_ChargeUnit.Location = New System.Drawing.Point(234, 4)
        Me.lb_ChargeUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_ChargeUnit.Name = "lb_ChargeUnit"
        Me.lb_ChargeUnit.Size = New System.Drawing.Size(72, 16)
        Me.lb_ChargeUnit.TabIndex = 1
        Me.lb_ChargeUnit.Text = "計價單位"
        '
        'uclcomb_HosItem
        '
        Me.uclcomb_HosItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_HosItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_HosItem.DropDownWidth = 20
        Me.uclcomb_HosItem.DroppedDown = False
        Me.uclcomb_HosItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_HosItem.Location = New System.Drawing.Point(108, 0)
        Me.uclcomb_HosItem.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_HosItem.Name = "uclcomb_HosItem"
        Me.uclcomb_HosItem.SelectedIndex = -1
        Me.uclcomb_HosItem.SelectedItem = Nothing
        Me.uclcomb_HosItem.SelectedText = ""
        Me.uclcomb_HosItem.SelectedValue = ""
        Me.uclcomb_HosItem.SelectionStart = 0
        Me.uclcomb_HosItem.Size = New System.Drawing.Size(126, 24)
        Me.uclcomb_HosItem.TabIndex = 9
        Me.uclcomb_HosItem.uclDisplayIndex = "0,1"
        Me.uclcomb_HosItem.uclIsAutoClear = True
        Me.uclcomb_HosItem.uclIsFirstItemEmpty = True
        Me.uclcomb_HosItem.uclIsTextMode = False
        Me.uclcomb_HosItem.uclShowMsg = False
        Me.uclcomb_HosItem.uclValueIndex = "0"
        '
        'uclcomb_OrderType
        '
        Me.uclcomb_OrderType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_OrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_OrderType.DropDownWidth = 20
        Me.uclcomb_OrderType.DroppedDown = False
        Me.uclcomb_OrderType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_OrderType.Location = New System.Drawing.Point(120, 78)
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
        'uclcomb_ChargeUnit
        '
        Me.uclcomb_ChargeUnit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_ChargeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_ChargeUnit.DropDownWidth = 20
        Me.uclcomb_ChargeUnit.DroppedDown = False
        Me.uclcomb_ChargeUnit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_ChargeUnit.Location = New System.Drawing.Point(306, 0)
        Me.uclcomb_ChargeUnit.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_ChargeUnit.Name = "uclcomb_ChargeUnit"
        Me.uclcomb_ChargeUnit.SelectedIndex = -1
        Me.uclcomb_ChargeUnit.SelectedItem = Nothing
        Me.uclcomb_ChargeUnit.SelectedText = ""
        Me.uclcomb_ChargeUnit.SelectedValue = ""
        Me.uclcomb_ChargeUnit.SelectionStart = 0
        Me.uclcomb_ChargeUnit.Size = New System.Drawing.Size(94, 24)
        Me.uclcomb_ChargeUnit.TabIndex = 10
        Me.uclcomb_ChargeUnit.uclDisplayIndex = "0,1"
        Me.uclcomb_ChargeUnit.uclIsAutoClear = True
        Me.uclcomb_ChargeUnit.uclIsFirstItemEmpty = True
        Me.uclcomb_ChargeUnit.uclIsTextMode = False
        Me.uclcomb_ChargeUnit.uclShowMsg = False
        Me.uclcomb_ChargeUnit.uclValueIndex = "0"
        '
        'lb_EnName
        '
        Me.lb_EnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EnName.AutoSize = True
        Me.lb_EnName.Location = New System.Drawing.Point(45, 46)
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
        Me.lb_OrderType.Location = New System.Drawing.Point(45, 82)
        Me.lb_OrderType.Name = "lb_OrderType"
        Me.lb_OrderType.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderType.TabIndex = 2
        Me.lb_OrderType.Text = "醫令類型"
        '
        'lb_OrderPS
        '
        Me.lb_OrderPS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderPS.AutoSize = True
        Me.lb_OrderPS.Location = New System.Drawing.Point(3, 0)
        Me.lb_OrderPS.Name = "lb_OrderPS"
        Me.lb_OrderPS.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderPS.TabIndex = 3
        Me.lb_OrderPS.Text = "醫令注意事項"
        '
        'lb_EffectDate
        '
        Me.lb_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EffectDate.AutoSize = True
        Me.lb_EffectDate.ForeColor = System.Drawing.Color.Red
        Me.lb_EffectDate.Location = New System.Drawing.Point(61, 193)
        Me.lb_EffectDate.Name = "lb_EffectDate"
        Me.lb_EffectDate.Size = New System.Drawing.Size(56, 16)
        Me.lb_EffectDate.TabIndex = 4
        Me.lb_EffectDate.Text = "生效日"
        '
        'txt_ZhName
        '
        Me.txt_ZhName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.txt_ZhName, 2)
        Me.txt_ZhName.Location = New System.Drawing.Point(120, 4)
        Me.txt_ZhName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_ZhName.MaxLength = 100
        Me.txt_ZhName.Name = "txt_ZhName"
        Me.txt_ZhName.Size = New System.Drawing.Size(268, 27)
        Me.txt_ZhName.TabIndex = 4
        '
        'lb_SCName
        '
        Me.lb_SCName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SCName.AutoSize = True
        Me.lb_SCName.Location = New System.Drawing.Point(437, 10)
        Me.lb_SCName.Name = "lb_SCName"
        Me.lb_SCName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SCName.TabIndex = 1
        Me.lb_SCName.Text = "中文簡稱"
        '
        'txt_SCName
        '
        Me.txt_SCName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SCName.Location = New System.Drawing.Point(512, 4)
        Me.txt_SCName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SCName.MaxLength = 50
        Me.txt_SCName.Name = "txt_SCName"
        Me.txt_SCName.Size = New System.Drawing.Size(172, 27)
        Me.txt_SCName.TabIndex = 5
        '
        'txt_IncludeOrder
        '
        Me.txt_IncludeOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_IncludeOrder.Location = New System.Drawing.Point(0, 149)
        Me.txt_IncludeOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_IncludeOrder.MaxLength = 1
        Me.txt_IncludeOrder.Name = "txt_IncludeOrder"
        Me.txt_IncludeOrder.Size = New System.Drawing.Size(108, 27)
        Me.txt_IncludeOrder.TabIndex = 35
        Me.txt_IncludeOrder.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 32)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "健保內含項註記"
        Me.Label2.Visible = False
        '
        'cb_NhiSheet
        '
        Me.cb_NhiSheet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiSheet.AutoSize = True
        Me.cb_NhiSheet.Location = New System.Drawing.Point(30, 205)
        Me.cb_NhiSheet.Margin = New System.Windows.Forms.Padding(30, 3, 3, 3)
        Me.cb_NhiSheet.Name = "cb_NhiSheet"
        Me.cb_NhiSheet.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiSheet.TabIndex = 24
        Me.cb_NhiSheet.UseVisualStyleBackColor = True
        '
        'cb_orderprice_spec
        '
        Me.cb_orderprice_spec.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_orderprice_spec.AutoSize = True
        Me.cb_orderprice_spec.Location = New System.Drawing.Point(3, 179)
        Me.cb_orderprice_spec.Name = "cb_orderprice_spec"
        Me.cb_orderprice_spec.Size = New System.Drawing.Size(91, 20)
        Me.cb_orderprice_spec.TabIndex = 28
        Me.cb_orderprice_spec.Text = "特殊收費"
        Me.cb_orderprice_spec.UseVisualStyleBackColor = True
        Me.cb_orderprice_spec.Visible = False
        '
        'uclcb_classify
        '
        Me.uclcb_classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_classify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_classify.DropDownWidth = 20
        Me.uclcb_classify.DroppedDown = False
        Me.uclcb_classify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_classify.Location = New System.Drawing.Point(0, 265)
        Me.uclcb_classify.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcb_classify.Name = "uclcb_classify"
        Me.uclcb_classify.SelectedIndex = -1
        Me.uclcb_classify.SelectedItem = Nothing
        Me.uclcb_classify.SelectedText = ""
        Me.uclcb_classify.SelectedValue = ""
        Me.uclcb_classify.SelectionStart = 0
        Me.uclcb_classify.Size = New System.Drawing.Size(120, 24)
        Me.uclcb_classify.TabIndex = 27
        Me.uclcb_classify.uclDisplayIndex = "0,1"
        Me.uclcb_classify.uclIsAutoClear = True
        Me.uclcb_classify.uclIsFirstItemEmpty = True
        Me.uclcb_classify.uclIsTextMode = False
        Me.uclcb_classify.uclShowMsg = False
        Me.uclcb_classify.uclValueIndex = "0"
        Me.uclcb_classify.Visible = False
        '
        'lb_Classify
        '
        Me.lb_Classify.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Classify.AutoSize = True
        Me.lb_Classify.Location = New System.Drawing.Point(3, 249)
        Me.lb_Classify.Name = "lb_Classify"
        Me.lb_Classify.Size = New System.Drawing.Size(72, 16)
        Me.lb_Classify.TabIndex = 1
        Me.lb_Classify.Text = "管理分類"
        Me.lb_Classify.Visible = False
        '
        'btn_Nhi
        '
        Me.btn_Nhi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Nhi.Location = New System.Drawing.Point(0, 222)
        Me.btn_Nhi.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Nhi.Name = "btn_Nhi"
        Me.btn_Nhi.Size = New System.Drawing.Size(130, 27)
        Me.btn_Nhi.TabIndex = 25
        Me.btn_Nhi.Text = "健保給付規定單"
        Me.btn_Nhi.UseVisualStyleBackColor = True
        Me.btn_Nhi.Visible = False
        '
        'cb_pricehistory
        '
        Me.cb_pricehistory.AutoSize = True
        Me.cb_pricehistory.Location = New System.Drawing.Point(113, 0)
        Me.cb_pricehistory.Name = "cb_pricehistory"
        Me.cb_pricehistory.Size = New System.Drawing.Size(107, 20)
        Me.cb_pricehistory.TabIndex = 1
        Me.cb_pricehistory.Text = "價格歷史檔"
        Me.cb_pricehistory.UseVisualStyleBackColor = True
        '
        'lb_Nhi_Name
        '
        Me.lb_Nhi_Name.AutoSize = True
        Me.lb_Nhi_Name.Location = New System.Drawing.Point(379, 0)
        Me.lb_Nhi_Name.Name = "lb_Nhi_Name"
        Me.lb_Nhi_Name.Size = New System.Drawing.Size(0, 16)
        Me.lb_Nhi_Name.TabIndex = 3
        '
        'ucldgv_OrderPrice
        '
        Me.ucldgv_OrderPrice.AllowUserToAddRows = False
        Me.ucldgv_OrderPrice.AllowUserToOrderColumns = False
        Me.ucldgv_OrderPrice.AllowUserToResizeColumns = True
        Me.ucldgv_OrderPrice.AllowUserToResizeRows = False
        Me.ucldgv_OrderPrice.AutoScroll = True
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
        Me.ucldgv_OrderPrice.Location = New System.Drawing.Point(9, 27)
        Me.ucldgv_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.ucldgv_OrderPrice.MultiSelect = False
        Me.ucldgv_OrderPrice.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucldgv_OrderPrice.Name = "ucldgv_OrderPrice"
        Me.ucldgv_OrderPrice.RowHeadersWidth = 41
        Me.ucldgv_OrderPrice.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucldgv_OrderPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucldgv_OrderPrice.Size = New System.Drawing.Size(942, 247)
        Me.ucldgv_OrderPrice.TabIndex = 0
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
        'chk_OrderHistory
        '
        Me.chk_OrderHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_OrderHistory.AutoSize = True
        Me.chk_OrderHistory.Location = New System.Drawing.Point(187, 17)
        Me.chk_OrderHistory.Name = "chk_OrderHistory"
        Me.chk_OrderHistory.Size = New System.Drawing.Size(227, 20)
        Me.chk_OrderHistory.TabIndex = 20
        Me.chk_OrderHistory.Text = "醫令歷史檔                              "
        Me.chk_OrderHistory.UseVisualStyleBackColor = True
        Me.chk_OrderHistory.Visible = False
        '
        'btn_PreRecord
        '
        Me.btn_PreRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_PreRecord.Location = New System.Drawing.Point(3, 14)
        Me.btn_PreRecord.Name = "btn_PreRecord"
        Me.btn_PreRecord.Size = New System.Drawing.Size(75, 27)
        Me.btn_PreRecord.TabIndex = 28
        Me.btn_PreRecord.Text = "上一筆"
        Me.btn_PreRecord.UseVisualStyleBackColor = True
        '
        'btn_NextRecord
        '
        Me.btn_NextRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NextRecord.Location = New System.Drawing.Point(84, 14)
        Me.btn_NextRecord.Name = "btn_NextRecord"
        Me.btn_NextRecord.Size = New System.Drawing.Size(97, 27)
        Me.btn_NextRecord.TabIndex = 29
        Me.btn_NextRecord.Text = "下一筆"
        Me.btn_NextRecord.UseVisualStyleBackColor = True
        '
        'tbp_Parent
        '
        Me.tbp_Parent.ColumnCount = 1
        Me.tbp_Parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Parent.Controls.Add(Me.grb_Condition, 0, 0)
        Me.tbp_Parent.Controls.Add(Me.tbp_1, 0, 1)
        Me.tbp_Parent.Controls.Add(Me.grb_OrderPrice, 0, 2)
        Me.tbp_Parent.Controls.Add(Me.TableLayoutPanel1, 0, 3)
        Me.tbp_Parent.Dock = System.Windows.Forms.DockStyle.Left
        Me.tbp_Parent.Location = New System.Drawing.Point(0, 0)
        Me.tbp_Parent.Name = "tbp_Parent"
        Me.tbp_Parent.RowCount = 4
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.Size = New System.Drawing.Size(964, 641)
        Me.tbp_Parent.TabIndex = 4
        '
        'tbp_1
        '
        Me.tbp_1.ColumnCount = 8
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.54095!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.54095!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.46499!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95716!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.08007!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.233653!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.548159!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.54095!))
        Me.tbp_1.Controls.Add(Me.FlowLayoutPanel6, 7, 0)
        Me.tbp_1.Controls.Add(Me.lb_SEName, 3, 1)
        Me.tbp_1.Controls.Add(Me.uclcomb_order_treat_prop, 4, 3)
        Me.tbp_1.Controls.Add(Me.lb_OrderProp, 3, 3)
        Me.tbp_1.Controls.Add(Me.txt_EnName, 1, 1)
        Me.tbp_1.Controls.Add(Me.txt_SEName, 4, 1)
        Me.tbp_1.Controls.Add(Me.uclcomb_OrderType, 1, 2)
        Me.tbp_1.Controls.Add(Me.txt_SCName, 4, 0)
        Me.tbp_1.Controls.Add(Me.lb_OrderType, 0, 2)
        Me.tbp_1.Controls.Add(Me.lb_SCName, 3, 0)
        Me.tbp_1.Controls.Add(Me.lb_TWName, 0, 0)
        Me.tbp_1.Controls.Add(Me.txt_ZhName, 1, 0)
        Me.tbp_1.Controls.Add(Me.lb_EnName, 0, 1)
        Me.tbp_1.Controls.Add(Me.FlowLayoutPanel1, 2, 2)
        Me.tbp_1.Controls.Add(Me.FlowLayoutPanel2, 0, 4)
        Me.tbp_1.Controls.Add(Me.lb_OrderRemark, 0, 3)
        Me.tbp_1.Controls.Add(Me.txt_Note, 1, 3)
        Me.tbp_1.Controls.Add(Me.lb_Mark, 5, 3)
        Me.tbp_1.Controls.Add(Me.txt_Flag, 6, 3)
        Me.tbp_1.Controls.Add(Me.lb_EffectDate, 0, 5)
        Me.tbp_1.Controls.Add(Me.FlowLayoutPanel4, 1, 5)
        Me.tbp_1.Location = New System.Drawing.Point(3, 72)
        Me.tbp_1.Name = "tbp_1"
        Me.tbp_1.RowCount = 6
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tbp_1.Size = New System.Drawing.Size(957, 222)
        Me.tbp_1.TabIndex = 3
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.FlowLayoutPanel1, 6)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_HosFee)
        Me.FlowLayoutPanel1.Controls.Add(Me.uclcomb_HosItem)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_ChargeUnit)
        Me.FlowLayoutPanel1.Controls.Add(Me.uclcomb_ChargeUnit)
        Me.FlowLayoutPanel1.Controls.Add(Me.lb_Majorcare)
        Me.FlowLayoutPanel1.Controls.Add(Me.uclcomb_majorcare)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(243, 76)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(711, 28)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.FlowLayoutPanel2, 8)
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_Fee)
        Me.FlowLayoutPanel2.Controls.Add(Me.uclcomb_fix_fee)
        Me.FlowLayoutPanel2.Controls.Add(Me.cb_NhiCureTypeId)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_NhiCureControl)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 148)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(943, 28)
        Me.FlowLayoutPanel2.TabIndex = 16
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.FlowLayoutPanel4, 7)
        Me.FlowLayoutPanel4.Controls.Add(Me.ucldtp_EffectDate)
        Me.FlowLayoutPanel4.Controls.Add(Me.cb_Dc)
        Me.FlowLayoutPanel4.Controls.Add(Me.lb_enddate)
        Me.FlowLayoutPanel4.Controls.Add(Me.ucl_dtp_enddate)
        Me.FlowLayoutPanel4.Controls.Add(Me.cbo_OPD)
        Me.FlowLayoutPanel4.Controls.Add(Me.cbo_EMG)
        Me.FlowLayoutPanel4.Controls.Add(Me.cbo_IPD)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(123, 185)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(823, 32)
        Me.FlowLayoutPanel4.TabIndex = 18
        '
        'grb_OrderPrice
        '
        Me.grb_OrderPrice.Controls.Add(Me.cb_pricehistory)
        Me.grb_OrderPrice.Controls.Add(Me.lb_Nhi_Name)
        Me.grb_OrderPrice.Controls.Add(Me.ucldgv_OrderPrice)
        Me.grb_OrderPrice.Location = New System.Drawing.Point(3, 300)
        Me.grb_OrderPrice.Name = "grb_OrderPrice"
        Me.grb_OrderPrice.Size = New System.Drawing.Size(958, 281)
        Me.grb_OrderPrice.TabIndex = 4
        Me.grb_OrderPrice.TabStop = False
        Me.grb_OrderPrice.Text = "醫令項目價格"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chk_OrderHistory, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_PreRecord, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_NextRecord, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 587)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(958, 55)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_AddQuery)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(420, 3)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(535, 49)
        Me.FlowLayoutPanel5.TabIndex = 30
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Clear.Location = New System.Drawing.Point(436, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_Clear.TabIndex = 33
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Confirm.Location = New System.Drawing.Point(345, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(85, 27)
        Me.btn_Confirm.TabIndex = 32
        Me.btn_Confirm.Text = "F12-確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Query.Location = New System.Drawing.Point(234, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(105, 27)
        Me.btn_Query.TabIndex = 31
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Delete.Location = New System.Drawing.Point(143, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(85, 27)
        Me.btn_Delete.TabIndex = 30
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_AddQuery
        '
        Me.btn_AddQuery.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_AddQuery.Location = New System.Drawing.Point(30, 3)
        Me.btn_AddQuery.Name = "btn_AddQuery"
        Me.btn_AddQuery.Size = New System.Drawing.Size(107, 27)
        Me.btn_AddQuery.TabIndex = 37
        Me.btn_AddQuery.Text = "各類加成查詢"
        Me.btn_AddQuery.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.lb_OrderPS)
        Me.FlowLayoutPanel6.Controls.Add(Me.memo_OrderMemo)
        Me.FlowLayoutPanel6.Controls.Add(Me.cb_OrderCheck)
        Me.FlowLayoutPanel6.Controls.Add(Me.btn_OrderCheck)
        Me.FlowLayoutPanel6.Controls.Add(Me.cb_Indication)
        Me.FlowLayoutPanel6.Controls.Add(Me.btn_Indication)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel6.Controls.Add(Me.txt_IncludeOrder)
        Me.FlowLayoutPanel6.Controls.Add(Me.cb_orderprice_spec)
        Me.FlowLayoutPanel6.Controls.Add(Me.cb_NhiSheet)
        Me.FlowLayoutPanel6.Controls.Add(Me.btn_Nhi)
        Me.FlowLayoutPanel6.Controls.Add(Me.lb_Classify)
        Me.FlowLayoutPanel6.Controls.Add(Me.uclcb_classify)
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(838, 3)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(116, 30)
        Me.FlowLayoutPanel6.TabIndex = 4
        Me.FlowLayoutPanel6.Visible = False
        '
        'PUBOrderUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tbp_Parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBOrderUI"
        Me.TabText = "醫療支付公用主檔-處置/其他"
        Me.Text = "醫療支付公用主檔-處置/其他"
        Me.grb_Condition.ResumeLayout(False)
        Me.tbp_Condition.ResumeLayout(False)
        Me.tbp_Condition.PerformLayout()
        Me.tbp_Parent.ResumeLayout(False)
        Me.tbp_1.ResumeLayout(False)
        Me.tbp_1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.grb_OrderPrice.ResumeLayout(False)
        Me.grb_OrderPrice.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grb_Condition As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_Condition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_NhiCode As System.Windows.Forms.Label
    Friend WithEvents lb_TWName As System.Windows.Forms.Label
    Friend WithEvents lb_EnName As System.Windows.Forms.Label
    Friend WithEvents lb_OrderType As System.Windows.Forms.Label
    Friend WithEvents lb_OrderPS As System.Windows.Forms.Label
    Friend WithEvents lb_EffectDate As System.Windows.Forms.Label
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents btn_PreRecord As System.Windows.Forms.Button
    Friend WithEvents btn_NextRecord As System.Windows.Forms.Button
    'Friend WithEvents memo_OrderMemo As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents lb_OrderRemark As System.Windows.Forms.Label
    Friend WithEvents lb_Mark As System.Windows.Forms.Label
    Friend WithEvents txt_Note As System.Windows.Forms.TextBox
    Friend WithEvents txt_Flag As System.Windows.Forms.TextBox
    Friend WithEvents ucldtp_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lb_Classify As System.Windows.Forms.Label
    Friend WithEvents uclcb_classify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cb_NhiSheet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Nhi As System.Windows.Forms.Button
    Friend WithEvents cb_OrderCheck As System.Windows.Forms.CheckBox
    Friend WithEvents cb_Indication As System.Windows.Forms.CheckBox
    Friend WithEvents btn_OrderCheck As System.Windows.Forms.Button
    Friend WithEvents btn_Indication As System.Windows.Forms.Button
    Friend WithEvents cb_Dc As System.Windows.Forms.CheckBox
    Friend WithEvents lb_OrderProp As System.Windows.Forms.Label
    Friend WithEvents lb_Fee As System.Windows.Forms.Label
    Friend WithEvents cb_NhiCureTypeId As System.Windows.Forms.CheckBox
    Friend WithEvents btn_NhiCureControl As System.Windows.Forms.Button
    Friend WithEvents txt_EnName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ZhName As System.Windows.Forms.TextBox
    Friend WithEvents lb_SEName As System.Windows.Forms.Label
    Friend WithEvents txt_SEName As System.Windows.Forms.TextBox
    Friend WithEvents lb_SCName As System.Windows.Forms.Label
    Friend WithEvents txt_SCName As System.Windows.Forms.TextBox
    Friend WithEvents lb_HosFee As System.Windows.Forms.Label
    Friend WithEvents lb_ChargeUnit As System.Windows.Forms.Label
    Friend WithEvents lb_Majorcare As System.Windows.Forms.Label
    Friend WithEvents uclcomb_order_treat_prop As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_fix_fee As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_HosItem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_OrderType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_ChargeUnit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_majorcare As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucldgv_OrderPrice As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents lb_OrderCode As System.Windows.Forms.Label
    Friend WithEvents txt_NhiCode As System.Windows.Forms.TextBox
    Friend WithEvents lb_Name As System.Windows.Forms.Label
    Friend WithEvents cb_orderprice_spec As System.Windows.Forms.CheckBox
    Friend WithEvents lb_enddate As System.Windows.Forms.Label
    Friend WithEvents ucl_dtp_enddate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cb_pricehistory As System.Windows.Forms.CheckBox
    Friend WithEvents PUBOrderUI_ucl_txtcq_ordercode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents chk_OrderHistory As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_OPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_EMG As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_IPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txt_IncludeOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents memo_OrderMemo As System.Windows.Forms.TextBox
    Friend WithEvents tbp_Parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents grb_OrderPrice As System.Windows.Forms.GroupBox
    Friend WithEvents lb_Nhi_Name As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_AddQuery As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
End Class
