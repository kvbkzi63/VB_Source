﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBOrderExamineUI
    Inherits Syscom.Client.UCL.BaseFormUI
    'Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBOrderExamineUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbp_Parent = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_Condition = New System.Windows.Forms.GroupBox()
        Me.tbp_Condition = New System.Windows.Forms.TableLayoutPanel()
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lb_OrderCode = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lb_Name = New System.Windows.Forms.Label()
        Me.txt_NhiCode = New System.Windows.Forms.TextBox()
        Me.lb_NhiCode = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lb_Mark = New System.Windows.Forms.Label()
        Me.txt_Flag = New System.Windows.Forms.TextBox()
        Me.cb_OrderCheck = New System.Windows.Forms.CheckBox()
        Me.btn_OrderCheck = New System.Windows.Forms.Button()
        Me.cb_Indication = New System.Windows.Forms.CheckBox()
        Me.btn_Indication = New System.Windows.Forms.Button()
        Me.lb_OrderPS = New System.Windows.Forms.Label()
        Me.memo_OrderMemo = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_IncludeOrder = New System.Windows.Forms.TextBox()
        Me.cb_NhiCureTypeId = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_NhiCureControl = New System.Windows.Forms.Button()
        Me.cb_isbodysite = New System.Windows.Forms.CheckBox()
        Me.uclcb_classify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cb_NhiSheet = New System.Windows.Forms.CheckBox()
        Me.cb_islabdiscount = New System.Windows.Forms.CheckBox()
        Me.lb_Classify = New System.Windows.Forms.Label()
        Me.btn_Nhi = New System.Windows.Forms.Button()
        Me.gb_OrderItem = New System.Windows.Forms.GroupBox()
        Me.tbp_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_OrederNote = New System.Windows.Forms.RichTextBox()
        Me.tbp_EffectDate = New System.Windows.Forms.TableLayoutPanel()
        Me.ucldtp_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.ucl_dtp_enddate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_EffectDate = New System.Windows.Forms.Label()
        Me.lb_enddate = New System.Windows.Forms.Label()
        Me.cbo_IPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_OPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_EMG = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lb_Fee = New System.Windows.Forms.Label()
        Me.uclcomb_fix_fee = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cb_NewNhiCureTypeId = New System.Windows.Forms.CheckBox()
        Me.btn_NewNhiCureControl = New System.Windows.Forms.Button()
        Me.chk_IncludeOrderMark = New System.Windows.Forms.CheckBox()
        Me.lb_OrderRemark = New System.Windows.Forms.Label()
        Me.tbp_OrderMemo = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_preview = New System.Windows.Forms.CheckBox()
        Me.txt_Note = New System.Windows.Forms.TextBox()
        Me.uclcomb_order_treat_prop = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cb_iscard = New System.Windows.Forms.CheckBox()
        Me.lb_OrderProp = New System.Windows.Forms.Label()
        Me.tbp_EnName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_EnName = New System.Windows.Forms.TextBox()
        Me.lb_SEName = New System.Windows.Forms.Label()
        Me.txt_SEName = New System.Windows.Forms.TextBox()
        Me.lb_TWName = New System.Windows.Forms.Label()
        Me.cb_Dc = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.uclcomb_majorcare = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.tbp_OrderType = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_HosFee = New System.Windows.Forms.Label()
        Me.lb_ChargeUnit = New System.Windows.Forms.Label()
        Me.uclcomb_HosItem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_OrderType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_ChargeUnit = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_Majorcare = New System.Windows.Forms.Label()
        Me.lb_EnName = New System.Windows.Forms.Label()
        Me.lb_OrderType = New System.Windows.Forms.Label()
        Me.tbp_ZhName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ZhName = New System.Windows.Forms.TextBox()
        Me.lb_SCName = New System.Windows.Forms.Label()
        Me.txt_SCName = New System.Windows.Forms.TextBox()
        Me.gb_OrderPrice = New System.Windows.Forms.GroupBox()
        Me.ucldgv_OrderPrice = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.lb_Nhi_Name = New System.Windows.Forms.Label()
        Me.cb_pricehistory = New System.Windows.Forms.CheckBox()
        Me.gb_btn = New System.Windows.Forms.GroupBox()
        Me.tbp_btn = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_AddQuery = New System.Windows.Forms.Button()
        Me.chk_OrderHistory = New System.Windows.Forms.CheckBox()
        Me.btn_NextRecord = New System.Windows.Forms.Button()
        Me.btn_PreRecord = New System.Windows.Forms.Button()
        Me.tbp_Parent.SuspendLayout()
        Me.gb_Condition.SuspendLayout()
        Me.tbp_Condition.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.gb_OrderItem.SuspendLayout()
        Me.tbp_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_EffectDate.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.tbp_OrderMemo.SuspendLayout()
        Me.tbp_EnName.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tbp_OrderType.SuspendLayout()
        Me.tbp_ZhName.SuspendLayout()
        Me.gb_OrderPrice.SuspendLayout()
        Me.gb_btn.SuspendLayout()
        Me.tbp_btn.SuspendLayout()
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
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 343.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Parent.Size = New System.Drawing.Size(962, 640)
        Me.tbp_Parent.TabIndex = 0
        '
        'gb_Condition
        '
        Me.gb_Condition.Controls.Add(Me.tbp_Condition)
        Me.gb_Condition.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_Condition.Location = New System.Drawing.Point(4, 4)
        Me.gb_Condition.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_Condition.Name = "gb_Condition"
        Me.gb_Condition.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_Condition.Size = New System.Drawing.Size(954, 56)
        Me.gb_Condition.TabIndex = 0
        Me.gb_Condition.TabStop = False
        Me.gb_Condition.Text = "查詢區"
        '
        'tbp_Condition
        '
        Me.tbp_Condition.ColumnCount = 7
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 482.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Condition.Controls.Add(Me.PUBOrderExamineUI_ucl_txtcq_ordercode, 0, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_OrderCode, 0, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_Name, 6, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_Name, 5, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_NhiCode, 4, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_NhiCode, 3, 0)
        Me.tbp_Condition.Controls.Add(Me.FlowLayoutPanel2, 2, 0)
        Me.tbp_Condition.Location = New System.Drawing.Point(3, 18)
        Me.tbp_Condition.Name = "tbp_Condition"
        Me.tbp_Condition.RowCount = 1
        Me.tbp_Condition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Condition.Size = New System.Drawing.Size(943, 37)
        Me.tbp_Condition.TabIndex = 0
        '
        'PUBOrderExamineUI_ucl_txtcq_ordercode
        '
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.doFlag = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Location = New System.Drawing.Point(120, 5)
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Margin = New System.Windows.Forms.Padding(0)
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Name = "PUBOrderExamineUI_ucl_txtcq_ordercode"
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.Size = New System.Drawing.Size(300, 26)
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.TabIndex = 8
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclBaseDate = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCboWidth = 263
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeName = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeName1 = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeName2 = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeValue = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclConditionDate = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclControlFlag = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclDeptCode = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclDisplayIndex = "0,1"
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsAutoAddZero = False
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsBtnVisible = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsCheckDoctorOnDuty = False
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsCheckDrLicense = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsCheckTime = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsEnglishDept = False
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsReturnDS = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsShowMsgBox = True
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclIsTextAutoClear = False
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclLabel = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclMsgValue = Nothing
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclNoDataOpenWindow = False
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclPUBEmployeeProfessalKindId = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclQueryField = Nothing
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclQueryValue = "H"
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclRegionKind = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclRoles = ""
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_OrderForMantain
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclTotalWidth = 8
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclXPosition = 225
        Me.PUBOrderExamineUI_ucl_txtcq_ordercode.uclYPosition = 120
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
        Me.txt_Name.Location = New System.Drawing.Point(870, 5)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(62, 27)
        Me.txt_Name.TabIndex = 3
        Me.txt_Name.Visible = False
        '
        'lb_Name
        '
        Me.lb_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Name.AutoSize = True
        Me.lb_Name.Location = New System.Drawing.Point(824, 10)
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
        Me.txt_NhiCode.Location = New System.Drawing.Point(753, 5)
        Me.txt_NhiCode.Name = "txt_NhiCode"
        Me.txt_NhiCode.Size = New System.Drawing.Size(59, 27)
        Me.txt_NhiCode.TabIndex = 4
        Me.txt_NhiCode.Visible = False
        '
        'lb_NhiCode
        '
        Me.lb_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_NhiCode.AutoSize = True
        Me.lb_NhiCode.Location = New System.Drawing.Point(691, 10)
        Me.lb_NhiCode.Name = "lb_NhiCode"
        Me.lb_NhiCode.Size = New System.Drawing.Size(56, 16)
        Me.lb_NhiCode.TabIndex = 1
        Me.lb_NhiCode.Text = "健保碼"
        Me.lb_NhiCode.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_Mark)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_Flag)
        Me.FlowLayoutPanel2.Controls.Add(Me.cb_OrderCheck)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_OrderCheck)
        Me.FlowLayoutPanel2.Controls.Add(Me.cb_Indication)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Indication)
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_OrderPS)
        Me.FlowLayoutPanel2.Controls.Add(Me.memo_OrderMemo)
        Me.FlowLayoutPanel2.Controls.Add(Me.TableLayoutPanel2)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(605, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(77, 31)
        Me.FlowLayoutPanel2.TabIndex = 4
        Me.FlowLayoutPanel2.Visible = False
        '
        'lb_Mark
        '
        Me.lb_Mark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_Mark.AutoSize = True
        Me.lb_Mark.Location = New System.Drawing.Point(3, 0)
        Me.lb_Mark.Name = "lb_Mark"
        Me.lb_Mark.Size = New System.Drawing.Size(40, 16)
        Me.lb_Mark.TabIndex = 2
        Me.lb_Mark.Text = "註記"
        '
        'txt_Flag
        '
        Me.txt_Flag.Location = New System.Drawing.Point(0, 16)
        Me.txt_Flag.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Flag.MaxLength = 2
        Me.txt_Flag.Name = "txt_Flag"
        Me.txt_Flag.Size = New System.Drawing.Size(109, 27)
        Me.txt_Flag.TabIndex = 14
        '
        'cb_OrderCheck
        '
        Me.cb_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_OrderCheck.AutoSize = True
        Me.cb_OrderCheck.Location = New System.Drawing.Point(3, 46)
        Me.cb_OrderCheck.Name = "cb_OrderCheck"
        Me.cb_OrderCheck.Size = New System.Drawing.Size(15, 14)
        Me.cb_OrderCheck.TabIndex = 15
        Me.cb_OrderCheck.UseVisualStyleBackColor = True
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
        'cb_Indication
        '
        Me.cb_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_Indication.AutoSize = True
        Me.cb_Indication.Location = New System.Drawing.Point(3, 93)
        Me.cb_Indication.Name = "cb_Indication"
        Me.cb_Indication.Size = New System.Drawing.Size(15, 14)
        Me.cb_Indication.TabIndex = 17
        Me.cb_Indication.UseVisualStyleBackColor = True
        '
        'btn_Indication
        '
        Me.btn_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Indication.Location = New System.Drawing.Point(0, 110)
        Me.btn_Indication.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Indication.Name = "btn_Indication"
        Me.btn_Indication.Size = New System.Drawing.Size(90, 27)
        Me.btn_Indication.TabIndex = 18
        Me.btn_Indication.Text = "適應症"
        Me.btn_Indication.UseVisualStyleBackColor = True
        Me.btn_Indication.Visible = False
        '
        'lb_OrderPS
        '
        Me.lb_OrderPS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderPS.AutoSize = True
        Me.lb_OrderPS.Location = New System.Drawing.Point(3, 137)
        Me.lb_OrderPS.Name = "lb_OrderPS"
        Me.lb_OrderPS.Size = New System.Drawing.Size(56, 32)
        Me.lb_OrderPS.TabIndex = 3
        Me.lb_OrderPS.Text = "醫令注意事項"
        '
        'memo_OrderMemo
        '
        Me.memo_OrderMemo.Location = New System.Drawing.Point(0, 169)
        Me.memo_OrderMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.memo_OrderMemo.Name = "memo_OrderMemo"
        Me.memo_OrderMemo.Size = New System.Drawing.Size(225, 27)
        Me.memo_OrderMemo.TabIndex = 15
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 10
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txt_IncludeOrder, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cb_NhiCureTypeId, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_NhiCureControl, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cb_isbodysite, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.uclcb_classify, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cb_NhiSheet, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cb_islabdiscount, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_Classify, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Nhi, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 196)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(942, 35)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'txt_IncludeOrder
        '
        Me.txt_IncludeOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_IncludeOrder.Location = New System.Drawing.Point(830, 4)
        Me.txt_IncludeOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_IncludeOrder.MaxLength = 1
        Me.txt_IncludeOrder.Name = "txt_IncludeOrder"
        Me.txt_IncludeOrder.Size = New System.Drawing.Size(54, 27)
        Me.txt_IncludeOrder.TabIndex = 36
        Me.txt_IncludeOrder.Visible = False
        '
        'cb_NhiCureTypeId
        '
        Me.cb_NhiCureTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiCureTypeId.AutoSize = True
        Me.cb_NhiCureTypeId.Location = New System.Drawing.Point(583, 10)
        Me.cb_NhiCureTypeId.Name = "cb_NhiCureTypeId"
        Me.cb_NhiCureTypeId.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiCureTypeId.TabIndex = 22
        Me.cb_NhiCureTypeId.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(713, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 32)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "健保內含項註記"
        Me.Label2.Visible = False
        '
        'btn_NhiCureControl
        '
        Me.btn_NhiCureControl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NhiCureControl.Location = New System.Drawing.Point(610, 4)
        Me.btn_NhiCureControl.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_NhiCureControl.Name = "btn_NhiCureControl"
        Me.btn_NhiCureControl.Size = New System.Drawing.Size(90, 27)
        Me.btn_NhiCureControl.TabIndex = 23
        Me.btn_NhiCureControl.Text = "健保療程"
        Me.btn_NhiCureControl.UseVisualStyleBackColor = True
        '
        'cb_isbodysite
        '
        Me.cb_isbodysite.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_isbodysite.AutoSize = True
        Me.cb_isbodysite.Location = New System.Drawing.Point(253, 7)
        Me.cb_isbodysite.Name = "cb_isbodysite"
        Me.cb_isbodysite.Size = New System.Drawing.Size(123, 20)
        Me.cb_isbodysite.TabIndex = 28
        Me.cb_isbodysite.Text = "是否輸入部位"
        Me.cb_isbodysite.UseVisualStyleBackColor = True
        '
        'uclcb_classify
        '
        Me.uclcb_classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_classify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_classify.DropDownWidth = 20
        Me.uclcb_classify.DroppedDown = False
        Me.uclcb_classify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_classify.Location = New System.Drawing.Point(150, 5)
        Me.uclcb_classify.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcb_classify.Name = "uclcb_classify"
        Me.uclcb_classify.SelectedIndex = -1
        Me.uclcb_classify.SelectedItem = Nothing
        Me.uclcb_classify.SelectedText = ""
        Me.uclcb_classify.SelectedValue = ""
        Me.uclcb_classify.SelectionStart = 0
        Me.uclcb_classify.Size = New System.Drawing.Size(100, 24)
        Me.uclcb_classify.TabIndex = 27
        Me.uclcb_classify.uclDisplayIndex = "0,1"
        Me.uclcb_classify.uclIsAutoClear = True
        Me.uclcb_classify.uclIsFirstItemEmpty = True
        Me.uclcb_classify.uclIsTextMode = False
        Me.uclcb_classify.uclShowMsg = False
        Me.uclcb_classify.uclValueIndex = "0"
        Me.uclcb_classify.Visible = False
        '
        'cb_NhiSheet
        '
        Me.cb_NhiSheet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiSheet.AutoSize = True
        Me.cb_NhiSheet.Location = New System.Drawing.Point(3, 10)
        Me.cb_NhiSheet.Name = "cb_NhiSheet"
        Me.cb_NhiSheet.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiSheet.TabIndex = 24
        Me.cb_NhiSheet.UseVisualStyleBackColor = True
        Me.cb_NhiSheet.Visible = False
        '
        'cb_islabdiscount
        '
        Me.cb_islabdiscount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_islabdiscount.AutoSize = True
        Me.cb_islabdiscount.Location = New System.Drawing.Point(403, 7)
        Me.cb_islabdiscount.Name = "cb_islabdiscount"
        Me.cb_islabdiscount.Size = New System.Drawing.Size(149, 20)
        Me.cb_islabdiscount.TabIndex = 24
        Me.cb_islabdiscount.Text = "檢查折扣(健保用)"
        Me.cb_islabdiscount.UseVisualStyleBackColor = True
        Me.cb_islabdiscount.Visible = False
        '
        'lb_Classify
        '
        Me.lb_Classify.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Classify.AutoSize = True
        Me.lb_Classify.Location = New System.Drawing.Point(123, 0)
        Me.lb_Classify.Name = "lb_Classify"
        Me.lb_Classify.Size = New System.Drawing.Size(24, 35)
        Me.lb_Classify.TabIndex = 1
        Me.lb_Classify.Text = "管理分類"
        Me.lb_Classify.Visible = False
        '
        'btn_Nhi
        '
        Me.btn_Nhi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Nhi.Location = New System.Drawing.Point(30, 4)
        Me.btn_Nhi.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Nhi.Name = "btn_Nhi"
        Me.btn_Nhi.Size = New System.Drawing.Size(90, 27)
        Me.btn_Nhi.TabIndex = 25
        Me.btn_Nhi.Text = "健保給付規定單"
        Me.btn_Nhi.UseVisualStyleBackColor = True
        Me.btn_Nhi.Visible = False
        '
        'gb_OrderItem
        '
        Me.gb_OrderItem.Controls.Add(Me.tbp_1)
        Me.gb_OrderItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderItem.Location = New System.Drawing.Point(4, 68)
        Me.gb_OrderItem.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Name = "gb_OrderItem"
        Me.gb_OrderItem.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Size = New System.Drawing.Size(954, 335)
        Me.gb_OrderItem.TabIndex = 1
        Me.gb_OrderItem.TabStop = False
        '
        'tbp_1
        '
        Me.tbp_1.ColumnCount = 2
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_1.Controls.Add(Me.GroupBox1, 0, 6)
        Me.tbp_1.Controls.Add(Me.tbp_EffectDate, 1, 4)
        Me.tbp_1.Controls.Add(Me.FlowLayoutPanel3, 0, 5)
        Me.tbp_1.Controls.Add(Me.lb_OrderRemark, 0, 3)
        Me.tbp_1.Controls.Add(Me.tbp_OrderMemo, 1, 3)
        Me.tbp_1.Controls.Add(Me.tbp_EnName, 1, 1)
        Me.tbp_1.Controls.Add(Me.lb_TWName, 0, 0)
        Me.tbp_1.Controls.Add(Me.cb_Dc, 0, 4)
        Me.tbp_1.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.tbp_1.Controls.Add(Me.lb_EnName, 0, 1)
        Me.tbp_1.Controls.Add(Me.lb_OrderType, 0, 2)
        Me.tbp_1.Controls.Add(Me.tbp_ZhName, 1, 0)
        Me.tbp_1.Location = New System.Drawing.Point(6, 15)
        Me.tbp_1.Name = "tbp_1"
        Me.tbp_1.RowCount = 7
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_1.Size = New System.Drawing.Size(942, 313)
        Me.tbp_1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.tbp_1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.txt_OrederNote)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 197)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(936, 116)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "健保相關規定"
        '
        'txt_OrederNote
        '
        Me.txt_OrederNote.Location = New System.Drawing.Point(6, 18)
        Me.txt_OrederNote.Name = "txt_OrederNote"
        Me.txt_OrederNote.Size = New System.Drawing.Size(922, 92)
        Me.txt_OrederNote.TabIndex = 0
        Me.txt_OrederNote.Text = ""
        '
        'tbp_EffectDate
        '
        Me.tbp_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_EffectDate.ColumnCount = 7
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.Controls.Add(Me.ucldtp_EffectDate, 4, 0)
        Me.tbp_EffectDate.Controls.Add(Me.ucl_dtp_enddate, 6, 0)
        Me.tbp_EffectDate.Controls.Add(Me.lb_EffectDate, 3, 0)
        Me.tbp_EffectDate.Controls.Add(Me.lb_enddate, 5, 0)
        Me.tbp_EffectDate.Controls.Add(Me.cbo_IPD, 2, 0)
        Me.tbp_EffectDate.Controls.Add(Me.cbo_OPD, 0, 0)
        Me.tbp_EffectDate.Controls.Add(Me.cbo_EMG, 1, 0)
        Me.tbp_EffectDate.Location = New System.Drawing.Point(123, 131)
        Me.tbp_EffectDate.Name = "tbp_EffectDate"
        Me.tbp_EffectDate.RowCount = 1
        Me.tbp_EffectDate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EffectDate.Size = New System.Drawing.Size(816, 26)
        Me.tbp_EffectDate.TabIndex = 6
        '
        'ucldtp_EffectDate
        '
        Me.ucldtp_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucldtp_EffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucldtp_EffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucldtp_EffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucldtp_EffectDate.Location = New System.Drawing.Point(410, 0)
        Me.ucldtp_EffectDate.Margin = New System.Windows.Forms.Padding(0)
        Me.ucldtp_EffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucldtp_EffectDate.Name = "ucldtp_EffectDate"
        Me.ucldtp_EffectDate.Size = New System.Drawing.Size(116, 26)
        Me.ucldtp_EffectDate.TabIndex = 26
        Me.ucldtp_EffectDate.uclIsFixedBackColor = False
        Me.ucldtp_EffectDate.uclReadOnly = False
        Me.ucldtp_EffectDate.Visible = False
        '
        'ucl_dtp_enddate
        '
        Me.ucl_dtp_enddate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_enddate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_enddate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_enddate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_enddate.Location = New System.Drawing.Point(607, 3)
        Me.ucl_dtp_enddate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.Name = "ucl_dtp_enddate"
        Me.ucl_dtp_enddate.Size = New System.Drawing.Size(114, 20)
        Me.ucl_dtp_enddate.TabIndex = 28
        Me.ucl_dtp_enddate.uclIsFixedBackColor = False
        Me.ucl_dtp_enddate.uclReadOnly = False
        Me.ucl_dtp_enddate.Visible = False
        '
        'lb_EffectDate
        '
        Me.lb_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EffectDate.AutoSize = True
        Me.lb_EffectDate.ForeColor = System.Drawing.Color.Red
        Me.lb_EffectDate.Location = New System.Drawing.Point(351, 5)
        Me.lb_EffectDate.Name = "lb_EffectDate"
        Me.lb_EffectDate.Size = New System.Drawing.Size(56, 16)
        Me.lb_EffectDate.TabIndex = 4
        Me.lb_EffectDate.Text = "生效日"
        Me.lb_EffectDate.Visible = False
        '
        'lb_enddate
        '
        Me.lb_enddate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_enddate.AutoSize = True
        Me.lb_enddate.Location = New System.Drawing.Point(529, 5)
        Me.lb_enddate.Name = "lb_enddate"
        Me.lb_enddate.Size = New System.Drawing.Size(72, 16)
        Me.lb_enddate.TabIndex = 27
        Me.lb_enddate.Text = "停用日期"
        Me.lb_enddate.Visible = False
        '
        'cbo_IPD
        '
        Me.cbo_IPD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IPD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IPD.DropDownWidth = 20
        Me.cbo_IPD.DroppedDown = False
        Me.cbo_IPD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IPD.Location = New System.Drawing.Point(232, 1)
        Me.cbo_IPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IPD.Name = "cbo_IPD"
        Me.cbo_IPD.SelectedIndex = -1
        Me.cbo_IPD.SelectedItem = Nothing
        Me.cbo_IPD.SelectedText = ""
        Me.cbo_IPD.SelectedValue = ""
        Me.cbo_IPD.SelectionStart = 0
        Me.cbo_IPD.Size = New System.Drawing.Size(116, 24)
        Me.cbo_IPD.TabIndex = 32
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
        Me.cbo_OPD.Location = New System.Drawing.Point(0, 1)
        Me.cbo_OPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_OPD.Name = "cbo_OPD"
        Me.cbo_OPD.SelectedIndex = -1
        Me.cbo_OPD.SelectedItem = Nothing
        Me.cbo_OPD.SelectedText = ""
        Me.cbo_OPD.SelectedValue = ""
        Me.cbo_OPD.SelectionStart = 0
        Me.cbo_OPD.Size = New System.Drawing.Size(116, 24)
        Me.cbo_OPD.TabIndex = 30
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
        Me.cbo_EMG.Location = New System.Drawing.Point(116, 1)
        Me.cbo_EMG.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_EMG.Name = "cbo_EMG"
        Me.cbo_EMG.SelectedIndex = -1
        Me.cbo_EMG.SelectedItem = Nothing
        Me.cbo_EMG.SelectedText = ""
        Me.cbo_EMG.SelectedValue = ""
        Me.cbo_EMG.SelectionStart = 0
        Me.cbo_EMG.Size = New System.Drawing.Size(116, 24)
        Me.cbo_EMG.TabIndex = 31
        Me.cbo_EMG.uclDisplayIndex = "0,1"
        Me.cbo_EMG.uclIsAutoClear = True
        Me.cbo_EMG.uclIsFirstItemEmpty = True
        Me.cbo_EMG.uclIsTextMode = False
        Me.cbo_EMG.uclShowMsg = False
        Me.cbo_EMG.uclValueIndex = "0"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbp_1.SetColumnSpan(Me.FlowLayoutPanel3, 8)
        Me.FlowLayoutPanel3.Controls.Add(Me.lb_Fee)
        Me.FlowLayoutPanel3.Controls.Add(Me.uclcomb_fix_fee)
        Me.FlowLayoutPanel3.Controls.Add(Me.cb_NewNhiCureTypeId)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_NewNhiCureControl)
        Me.FlowLayoutPanel3.Controls.Add(Me.chk_IncludeOrderMark)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 163)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(936, 28)
        Me.FlowLayoutPanel3.TabIndex = 17
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
        'cb_NewNhiCureTypeId
        '
        Me.cb_NewNhiCureTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NewNhiCureTypeId.AutoSize = True
        Me.cb_NewNhiCureTypeId.Enabled = False
        Me.cb_NewNhiCureTypeId.Location = New System.Drawing.Point(240, 6)
        Me.cb_NewNhiCureTypeId.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.cb_NewNhiCureTypeId.Name = "cb_NewNhiCureTypeId"
        Me.cb_NewNhiCureTypeId.Size = New System.Drawing.Size(15, 14)
        Me.cb_NewNhiCureTypeId.TabIndex = 22
        Me.cb_NewNhiCureTypeId.UseVisualStyleBackColor = True
        '
        'btn_NewNhiCureControl
        '
        Me.btn_NewNhiCureControl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NewNhiCureControl.Location = New System.Drawing.Point(258, 0)
        Me.btn_NewNhiCureControl.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_NewNhiCureControl.Name = "btn_NewNhiCureControl"
        Me.btn_NewNhiCureControl.Size = New System.Drawing.Size(90, 27)
        Me.btn_NewNhiCureControl.TabIndex = 23
        Me.btn_NewNhiCureControl.Text = "健保療程"
        Me.btn_NewNhiCureControl.UseVisualStyleBackColor = True
        '
        'chk_IncludeOrderMark
        '
        Me.chk_IncludeOrderMark.AutoSize = True
        Me.chk_IncludeOrderMark.Location = New System.Drawing.Point(354, 3)
        Me.chk_IncludeOrderMark.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.chk_IncludeOrderMark.Name = "chk_IncludeOrderMark"
        Me.chk_IncludeOrderMark.Size = New System.Drawing.Size(165, 20)
        Me.chk_IncludeOrderMark.TabIndex = 24
        Me.chk_IncludeOrderMark.Text = "健保內含項(不計價)"
        Me.chk_IncludeOrderMark.UseVisualStyleBackColor = True
        '
        'lb_OrderRemark
        '
        Me.lb_OrderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderRemark.AutoSize = True
        Me.lb_OrderRemark.Location = New System.Drawing.Point(45, 104)
        Me.lb_OrderRemark.Name = "lb_OrderRemark"
        Me.lb_OrderRemark.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderRemark.TabIndex = 1
        Me.lb_OrderRemark.Text = "醫令備註"
        '
        'tbp_OrderMemo
        '
        Me.tbp_OrderMemo.ColumnCount = 5
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.Controls.Add(Me.cb_preview, 1, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.txt_Note, 0, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.uclcomb_order_treat_prop, 4, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.cb_iscard, 2, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.lb_OrderProp, 3, 0)
        Me.tbp_OrderMemo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_OrderMemo.Location = New System.Drawing.Point(123, 99)
        Me.tbp_OrderMemo.Name = "tbp_OrderMemo"
        Me.tbp_OrderMemo.RowCount = 1
        Me.tbp_OrderMemo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_OrderMemo.Size = New System.Drawing.Size(816, 26)
        Me.tbp_OrderMemo.TabIndex = 8
        '
        'cb_preview
        '
        Me.cb_preview.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_preview.AutoSize = True
        Me.cb_preview.Location = New System.Drawing.Point(239, 3)
        Me.cb_preview.Name = "cb_preview"
        Me.cb_preview.Size = New System.Drawing.Size(123, 20)
        Me.cb_preview.TabIndex = 32
        Me.cb_preview.Text = "事前審查醫令"
        Me.cb_preview.UseVisualStyleBackColor = True
        '
        'txt_Note
        '
        Me.txt_Note.Location = New System.Drawing.Point(0, 0)
        Me.txt_Note.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Note.Name = "txt_Note"
        Me.txt_Note.Size = New System.Drawing.Size(236, 27)
        Me.txt_Note.TabIndex = 13
        '
        'uclcomb_order_treat_prop
        '
        Me.uclcomb_order_treat_prop.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_order_treat_prop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_order_treat_prop.DropDownWidth = 20
        Me.uclcomb_order_treat_prop.DroppedDown = False
        Me.uclcomb_order_treat_prop.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_order_treat_prop.Location = New System.Drawing.Point(621, 1)
        Me.uclcomb_order_treat_prop.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_order_treat_prop.Name = "uclcomb_order_treat_prop"
        Me.uclcomb_order_treat_prop.SelectedIndex = -1
        Me.uclcomb_order_treat_prop.SelectedItem = Nothing
        Me.uclcomb_order_treat_prop.SelectedText = ""
        Me.uclcomb_order_treat_prop.SelectedValue = ""
        Me.uclcomb_order_treat_prop.SelectionStart = 0
        Me.uclcomb_order_treat_prop.Size = New System.Drawing.Size(112, 24)
        Me.uclcomb_order_treat_prop.TabIndex = 20
        Me.uclcomb_order_treat_prop.uclDisplayIndex = "0,1"
        Me.uclcomb_order_treat_prop.uclIsAutoClear = True
        Me.uclcomb_order_treat_prop.uclIsFirstItemEmpty = True
        Me.uclcomb_order_treat_prop.uclIsTextMode = False
        Me.uclcomb_order_treat_prop.uclShowMsg = False
        Me.uclcomb_order_treat_prop.uclValueIndex = "0"
        '
        'cb_iscard
        '
        Me.cb_iscard.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_iscard.AutoSize = True
        Me.cb_iscard.Location = New System.Drawing.Point(368, 3)
        Me.cb_iscard.Name = "cb_iscard"
        Me.cb_iscard.Size = New System.Drawing.Size(140, 20)
        Me.cb_iscard.TabIndex = 29
        Me.cb_iscard.Text = "IC Card重要醫令"
        Me.cb_iscard.UseVisualStyleBackColor = True
        '
        'lb_OrderProp
        '
        Me.lb_OrderProp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderProp.AutoSize = True
        Me.lb_OrderProp.Location = New System.Drawing.Point(514, 5)
        Me.lb_OrderProp.Name = "lb_OrderProp"
        Me.lb_OrderProp.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderProp.TabIndex = 5
        Me.lb_OrderProp.Text = "醫令治療屬性"
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
        Me.tbp_EnName.Location = New System.Drawing.Point(123, 35)
        Me.tbp_EnName.Name = "tbp_EnName"
        Me.tbp_EnName.RowCount = 1
        Me.tbp_EnName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EnName.Size = New System.Drawing.Size(808, 26)
        Me.tbp_EnName.TabIndex = 6
        '
        'txt_EnName
        '
        Me.txt_EnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EnName.Location = New System.Drawing.Point(0, 0)
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
        Me.lb_SEName.Location = New System.Drawing.Point(545, 5)
        Me.lb_SEName.Name = "lb_SEName"
        Me.lb_SEName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SEName.TabIndex = 1
        Me.lb_SEName.Text = "英文簡稱"
        '
        'txt_SEName
        '
        Me.txt_SEName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SEName.Location = New System.Drawing.Point(620, 0)
        Me.txt_SEName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SEName.MaxLength = 50
        Me.txt_SEName.Name = "txt_SEName"
        Me.txt_SEName.Size = New System.Drawing.Size(170, 27)
        Me.txt_SEName.TabIndex = 7
        '
        'lb_TWName
        '
        Me.lb_TWName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_TWName.AutoSize = True
        Me.lb_TWName.Location = New System.Drawing.Point(45, 8)
        Me.lb_TWName.Name = "lb_TWName"
        Me.lb_TWName.Size = New System.Drawing.Size(72, 16)
        Me.lb_TWName.TabIndex = 0
        Me.lb_TWName.Text = "中文名稱"
        '
        'cb_Dc
        '
        Me.cb_Dc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_Dc.AutoSize = True
        Me.cb_Dc.Location = New System.Drawing.Point(58, 134)
        Me.cb_Dc.Name = "cb_Dc"
        Me.cb_Dc.Size = New System.Drawing.Size(59, 20)
        Me.cb_Dc.TabIndex = 19
        Me.cb_Dc.Text = "停用"
        Me.cb_Dc.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 550.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.uclcomb_majorcare, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbp_OrderType, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lb_Majorcare, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(120, 64)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(822, 32)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'uclcomb_majorcare
        '
        Me.uclcomb_majorcare.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_majorcare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_majorcare.DropDownWidth = 20
        Me.uclcomb_majorcare.DroppedDown = False
        Me.uclcomb_majorcare.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_majorcare.Location = New System.Drawing.Point(670, 4)
        Me.uclcomb_majorcare.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_majorcare.Name = "uclcomb_majorcare"
        Me.uclcomb_majorcare.SelectedIndex = -1
        Me.uclcomb_majorcare.SelectedItem = Nothing
        Me.uclcomb_majorcare.SelectedText = ""
        Me.uclcomb_majorcare.SelectedValue = ""
        Me.uclcomb_majorcare.SelectionStart = 0
        Me.uclcomb_majorcare.Size = New System.Drawing.Size(152, 24)
        Me.uclcomb_majorcare.TabIndex = 11
        Me.uclcomb_majorcare.uclDisplayIndex = "0,1"
        Me.uclcomb_majorcare.uclIsAutoClear = True
        Me.uclcomb_majorcare.uclIsFirstItemEmpty = True
        Me.uclcomb_majorcare.uclIsTextMode = False
        Me.uclcomb_majorcare.uclShowMsg = False
        Me.uclcomb_majorcare.uclValueIndex = "0"
        '
        'tbp_OrderType
        '
        Me.tbp_OrderType.ColumnCount = 5
        Me.tbp_OrderType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tbp_OrderType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_OrderType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tbp_OrderType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tbp_OrderType.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_OrderType.Controls.Add(Me.lb_HosFee, 1, 0)
        Me.tbp_OrderType.Controls.Add(Me.lb_ChargeUnit, 3, 0)
        Me.tbp_OrderType.Controls.Add(Me.uclcomb_HosItem, 2, 0)
        Me.tbp_OrderType.Controls.Add(Me.uclcomb_OrderType, 0, 0)
        Me.tbp_OrderType.Controls.Add(Me.uclcomb_ChargeUnit, 4, 0)
        Me.tbp_OrderType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_OrderType.Location = New System.Drawing.Point(3, 3)
        Me.tbp_OrderType.Name = "tbp_OrderType"
        Me.tbp_OrderType.RowCount = 1
        Me.tbp_OrderType.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_OrderType.Size = New System.Drawing.Size(544, 26)
        Me.tbp_OrderType.TabIndex = 7
        '
        'lb_HosFee
        '
        Me.lb_HosFee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_HosFee.AutoSize = True
        Me.lb_HosFee.ForeColor = System.Drawing.Color.Red
        Me.lb_HosFee.Location = New System.Drawing.Point(116, 5)
        Me.lb_HosFee.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_HosFee.Name = "lb_HosFee"
        Me.lb_HosFee.Size = New System.Drawing.Size(104, 16)
        Me.lb_HosFee.TabIndex = 0
        Me.lb_HosFee.Text = "院內費用項目"
        '
        'lb_ChargeUnit
        '
        Me.lb_ChargeUnit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_ChargeUnit.AutoSize = True
        Me.lb_ChargeUnit.ForeColor = System.Drawing.Color.Black
        Me.lb_ChargeUnit.Location = New System.Drawing.Point(348, 5)
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
        Me.uclcomb_HosItem.Location = New System.Drawing.Point(220, 1)
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
        'uclcomb_OrderType
        '
        Me.uclcomb_OrderType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_OrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_OrderType.DropDownWidth = 20
        Me.uclcomb_OrderType.DroppedDown = False
        Me.uclcomb_OrderType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_OrderType.Location = New System.Drawing.Point(0, 1)
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
        Me.uclcomb_ChargeUnit.Location = New System.Drawing.Point(420, 1)
        Me.uclcomb_ChargeUnit.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.uclcomb_ChargeUnit.Name = "uclcomb_ChargeUnit"
        Me.uclcomb_ChargeUnit.SelectedIndex = -1
        Me.uclcomb_ChargeUnit.SelectedItem = Nothing
        Me.uclcomb_ChargeUnit.SelectedText = ""
        Me.uclcomb_ChargeUnit.SelectedValue = ""
        Me.uclcomb_ChargeUnit.SelectionStart = 0
        Me.uclcomb_ChargeUnit.Size = New System.Drawing.Size(90, 24)
        Me.uclcomb_ChargeUnit.TabIndex = 10
        Me.uclcomb_ChargeUnit.uclDisplayIndex = "0,1"
        Me.uclcomb_ChargeUnit.uclIsAutoClear = True
        Me.uclcomb_ChargeUnit.uclIsFirstItemEmpty = True
        Me.uclcomb_ChargeUnit.uclIsTextMode = False
        Me.uclcomb_ChargeUnit.uclShowMsg = False
        Me.uclcomb_ChargeUnit.uclValueIndex = "0"
        '
        'lb_Majorcare
        '
        Me.lb_Majorcare.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Majorcare.AutoSize = True
        Me.lb_Majorcare.Location = New System.Drawing.Point(563, 8)
        Me.lb_Majorcare.Name = "lb_Majorcare"
        Me.lb_Majorcare.Size = New System.Drawing.Size(104, 16)
        Me.lb_Majorcare.TabIndex = 2
        Me.lb_Majorcare.Text = "特定治療項目"
        '
        'lb_EnName
        '
        Me.lb_EnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EnName.AutoSize = True
        Me.lb_EnName.Location = New System.Drawing.Point(45, 40)
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
        Me.lb_OrderType.Location = New System.Drawing.Point(45, 72)
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
        Me.tbp_ZhName.Location = New System.Drawing.Point(123, 3)
        Me.tbp_ZhName.Name = "tbp_ZhName"
        Me.tbp_ZhName.RowCount = 1
        Me.tbp_ZhName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_ZhName.Size = New System.Drawing.Size(808, 26)
        Me.tbp_ZhName.TabIndex = 5
        '
        'txt_ZhName
        '
        Me.txt_ZhName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ZhName.Location = New System.Drawing.Point(0, 0)
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
        Me.lb_SCName.Location = New System.Drawing.Point(545, 5)
        Me.lb_SCName.Name = "lb_SCName"
        Me.lb_SCName.Size = New System.Drawing.Size(72, 16)
        Me.lb_SCName.TabIndex = 1
        Me.lb_SCName.Text = "中文簡稱"
        '
        'txt_SCName
        '
        Me.txt_SCName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SCName.Location = New System.Drawing.Point(620, 0)
        Me.txt_SCName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SCName.MaxLength = 50
        Me.txt_SCName.Name = "txt_SCName"
        Me.txt_SCName.Size = New System.Drawing.Size(170, 27)
        Me.txt_SCName.TabIndex = 5
        '
        'gb_OrderPrice
        '
        Me.gb_OrderPrice.Controls.Add(Me.ucldgv_OrderPrice)
        Me.gb_OrderPrice.Controls.Add(Me.lb_Nhi_Name)
        Me.gb_OrderPrice.Controls.Add(Me.cb_pricehistory)
        Me.gb_OrderPrice.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderPrice.Location = New System.Drawing.Point(4, 411)
        Me.gb_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Name = "gb_OrderPrice"
        Me.gb_OrderPrice.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Size = New System.Drawing.Size(954, 157)
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
        Me.ucldgv_OrderPrice.Location = New System.Drawing.Point(9, 25)
        Me.ucldgv_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.ucldgv_OrderPrice.MultiSelect = False
        Me.ucldgv_OrderPrice.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucldgv_OrderPrice.Name = "ucldgv_OrderPrice"
        Me.ucldgv_OrderPrice.RowHeadersWidth = 41
        Me.ucldgv_OrderPrice.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucldgv_OrderPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucldgv_OrderPrice.Size = New System.Drawing.Size(939, 127)
        Me.ucldgv_OrderPrice.TabIndex = 3
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
        'lb_Nhi_Name
        '
        Me.lb_Nhi_Name.AutoSize = True
        Me.lb_Nhi_Name.Location = New System.Drawing.Point(420, 5)
        Me.lb_Nhi_Name.Name = "lb_Nhi_Name"
        Me.lb_Nhi_Name.Size = New System.Drawing.Size(0, 16)
        Me.lb_Nhi_Name.TabIndex = 2
        '
        'cb_pricehistory
        '
        Me.cb_pricehistory.AutoSize = True
        Me.cb_pricehistory.Location = New System.Drawing.Point(113, -1)
        Me.cb_pricehistory.Name = "cb_pricehistory"
        Me.cb_pricehistory.Size = New System.Drawing.Size(107, 20)
        Me.cb_pricehistory.TabIndex = 1
        Me.cb_pricehistory.Text = "價格歷史檔"
        Me.cb_pricehistory.UseVisualStyleBackColor = True
        '
        'gb_btn
        '
        Me.gb_btn.Controls.Add(Me.tbp_btn)
        Me.gb_btn.Location = New System.Drawing.Point(3, 575)
        Me.gb_btn.Name = "gb_btn"
        Me.gb_btn.Size = New System.Drawing.Size(956, 59)
        Me.gb_btn.TabIndex = 3
        Me.gb_btn.TabStop = False
        '
        'tbp_btn
        '
        Me.tbp_btn.ColumnCount = 4
        Me.tbp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_btn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_btn.Controls.Add(Me.FlowLayoutPanel1, 3, 0)
        Me.tbp_btn.Controls.Add(Me.chk_OrderHistory, 2, 0)
        Me.tbp_btn.Controls.Add(Me.btn_NextRecord, 1, 0)
        Me.tbp_btn.Controls.Add(Me.btn_PreRecord, 0, 0)
        Me.tbp_btn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_btn.Location = New System.Drawing.Point(3, 23)
        Me.tbp_btn.Name = "tbp_btn"
        Me.tbp_btn.RowCount = 1
        Me.tbp_btn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_btn.Size = New System.Drawing.Size(950, 33)
        Me.tbp_btn.TabIndex = 4
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_AddQuery)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(276, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(699, 27)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Clear.Location = New System.Drawing.Point(600, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_Clear.TabIndex = 33
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Confirm.Location = New System.Drawing.Point(509, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(85, 27)
        Me.btn_Confirm.TabIndex = 32
        Me.btn_Confirm.Text = "F12-確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Query.Location = New System.Drawing.Point(398, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(105, 27)
        Me.btn_Query.TabIndex = 31
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Delete.Location = New System.Drawing.Point(307, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(85, 27)
        Me.btn_Delete.TabIndex = 30
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_AddQuery
        '
        Me.btn_AddQuery.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_AddQuery.Location = New System.Drawing.Point(194, 3)
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
        Me.chk_OrderHistory.Location = New System.Drawing.Point(163, 6)
        Me.chk_OrderHistory.Name = "chk_OrderHistory"
        Me.chk_OrderHistory.Size = New System.Drawing.Size(107, 20)
        Me.chk_OrderHistory.TabIndex = 34
        Me.chk_OrderHistory.Text = "醫令歷史檔"
        Me.chk_OrderHistory.UseVisualStyleBackColor = True
        Me.chk_OrderHistory.Visible = False
        '
        'btn_NextRecord
        '
        Me.btn_NextRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_NextRecord.Location = New System.Drawing.Point(73, 4)
        Me.btn_NextRecord.Name = "btn_NextRecord"
        Me.btn_NextRecord.Size = New System.Drawing.Size(84, 25)
        Me.btn_NextRecord.TabIndex = 29
        Me.btn_NextRecord.Text = "下一筆"
        Me.btn_NextRecord.UseVisualStyleBackColor = True
        '
        'btn_PreRecord
        '
        Me.btn_PreRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_PreRecord.Location = New System.Drawing.Point(3, 4)
        Me.btn_PreRecord.Name = "btn_PreRecord"
        Me.btn_PreRecord.Size = New System.Drawing.Size(64, 25)
        Me.btn_PreRecord.TabIndex = 28
        Me.btn_PreRecord.Text = "上一筆"
        Me.btn_PreRecord.UseVisualStyleBackColor = True
        '
        'PUBOrderExamineUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 646)
        Me.Controls.Add(Me.tbp_Parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBOrderExamineUI"
        Me.TabText = "醫療支付公用主檔-檢驗查"
        Me.Text = "醫療支付公用主檔-檢驗查"
        Me.tbp_Parent.ResumeLayout(False)
        Me.gb_Condition.ResumeLayout(False)
        Me.tbp_Condition.ResumeLayout(False)
        Me.tbp_Condition.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.gb_OrderItem.ResumeLayout(False)
        Me.tbp_1.ResumeLayout(False)
        Me.tbp_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tbp_EffectDate.ResumeLayout(False)
        Me.tbp_EffectDate.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.tbp_OrderMemo.ResumeLayout(False)
        Me.tbp_OrderMemo.PerformLayout()
        Me.tbp_EnName.ResumeLayout(False)
        Me.tbp_EnName.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tbp_OrderType.ResumeLayout(False)
        Me.tbp_OrderType.PerformLayout()
        Me.tbp_ZhName.ResumeLayout(False)
        Me.tbp_ZhName.PerformLayout()
        Me.gb_OrderPrice.ResumeLayout(False)
        Me.gb_OrderPrice.PerformLayout()
        Me.gb_btn.ResumeLayout(False)
        Me.tbp_btn.ResumeLayout(False)
        Me.tbp_btn.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbp_Parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_Condition As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderItem As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderPrice As System.Windows.Forms.GroupBox
    Friend WithEvents gb_btn As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_Condition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_NhiCode As System.Windows.Forms.Label
    Friend WithEvents lb_Name As System.Windows.Forms.Label
    Friend WithEvents lb_TWName As System.Windows.Forms.Label
    Friend WithEvents lb_EnName As System.Windows.Forms.Label
    Friend WithEvents lb_OrderType As System.Windows.Forms.Label
    Friend WithEvents lb_OrderPS As System.Windows.Forms.Label
    Friend WithEvents lb_EffectDate As System.Windows.Forms.Label
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents tbp_ZhName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_EnName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_OrderMemo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_OrderType As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_OrderRemark As System.Windows.Forms.Label
    Friend WithEvents lb_Mark As System.Windows.Forms.Label
    Friend WithEvents txt_Note As System.Windows.Forms.TextBox
    Friend WithEvents txt_Flag As System.Windows.Forms.TextBox
    Friend WithEvents tbp_EffectDate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucldtp_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lb_Classify As System.Windows.Forms.Label
    Friend WithEvents uclcb_classify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cb_NhiSheet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Nhi As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_OrderCheck As System.Windows.Forms.CheckBox
    Friend WithEvents cb_Indication As System.Windows.Forms.CheckBox
    Friend WithEvents btn_OrderCheck As System.Windows.Forms.Button
    Friend WithEvents btn_Indication As System.Windows.Forms.Button
    Friend WithEvents cb_Dc As System.Windows.Forms.CheckBox
    Friend WithEvents lb_OrderProp As System.Windows.Forms.Label
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
    Friend WithEvents uclcomb_HosItem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_OrderType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_ChargeUnit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_majorcare As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lb_OrderCode As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_NhiCode As System.Windows.Forms.TextBox
    Friend WithEvents cb_islabdiscount As System.Windows.Forms.CheckBox
    Friend WithEvents cb_isbodysite As System.Windows.Forms.CheckBox
    Friend WithEvents cb_iscard As System.Windows.Forms.CheckBox
    Friend WithEvents lb_enddate As System.Windows.Forms.Label
    Friend WithEvents ucl_dtp_enddate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cb_pricehistory As System.Windows.Forms.CheckBox
    Friend WithEvents cb_preview As System.Windows.Forms.CheckBox
    Friend WithEvents PUBOrderExamineUI_ucl_txtcq_ordercode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lb_Nhi_Name As System.Windows.Forms.Label
    Friend WithEvents cbo_OPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_EMG As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_IPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_IncludeOrder As System.Windows.Forms.TextBox
    Friend WithEvents memo_OrderMemo As System.Windows.Forms.TextBox
    Friend WithEvents ucldgv_OrderPrice As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tbp_btn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_AddQuery As System.Windows.Forms.Button
    Friend WithEvents chk_OrderHistory As System.Windows.Forms.CheckBox
    Friend WithEvents btn_NextRecord As System.Windows.Forms.Button
    Friend WithEvents btn_PreRecord As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lb_Fee As System.Windows.Forms.Label
    Friend WithEvents uclcomb_fix_fee As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cb_NewNhiCureTypeId As System.Windows.Forms.CheckBox
    Friend WithEvents btn_NewNhiCureControl As System.Windows.Forms.Button
    Friend WithEvents chk_IncludeOrderMark As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_OrederNote As System.Windows.Forms.RichTextBox
End Class
