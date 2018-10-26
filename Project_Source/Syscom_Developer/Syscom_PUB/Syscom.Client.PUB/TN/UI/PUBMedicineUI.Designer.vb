<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBMedicineUI
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBMedicineUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbp_Parent = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_Condition = New System.Windows.Forms.GroupBox()
        Me.tbp_Condition = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_Indication = New System.Windows.Forms.CheckBox()
        Me.cb_OrderCheck = New System.Windows.Forms.CheckBox()
        Me.btn_OrderCheck = New System.Windows.Forms.Button()
        Me.btn_Indication = New System.Windows.Forms.Button()
        Me.tbp_EffectDate = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_IncludeOrder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_Classify = New System.Windows.Forms.Label()
        Me.uclcb_classify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_Nhi = New System.Windows.Forms.Button()
        Me.cb_NhiSheet = New System.Windows.Forms.CheckBox()
        Me.cb_exclusivedrug = New System.Windows.Forms.CheckBox()
        Me.btn_excludecharge = New System.Windows.Forms.Button()
        Me.cb_nhiindex = New System.Windows.Forms.CheckBox()
        Me.btn_nhiindex = New System.Windows.Forms.Button()
        Me.PUBMedicineUI_ucl_txtcq_ordercode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lb_OrderCode = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lb_Name = New System.Windows.Forms.Label()
        Me.txt_NhiCode = New System.Windows.Forms.TextBox()
        Me.lb_NhiCode = New System.Windows.Forms.Label()
        Me.gb_OrderItem = New System.Windows.Forms.GroupBox()
        Me.tbp_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_OrderRemark = New System.Windows.Forms.Label()
        Me.tbp_OrderMemo = New System.Windows.Forms.TableLayoutPanel()
        Me.memo_OrderMemo = New System.Windows.Forms.TextBox()
        Me.txt_Note = New System.Windows.Forms.TextBox()
        Me.lb_Mark = New System.Windows.Forms.Label()
        Me.lb_OrderPS = New System.Windows.Forms.Label()
        Me.txt_Flag = New System.Windows.Forms.TextBox()
        Me.cb_preview = New System.Windows.Forms.CheckBox()
        Me.tbp_EnName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_EnName = New System.Windows.Forms.TextBox()
        Me.lb_SEName = New System.Windows.Forms.Label()
        Me.txt_SEName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_atccode = New System.Windows.Forms.TextBox()
        Me.cb_Dc = New System.Windows.Forms.CheckBox()
        Me.lb_TWName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_HosFee = New System.Windows.Forms.Label()
        Me.uclcomb_OrderType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcomb_HosItem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lb_specification = New System.Windows.Forms.Label()
        Me.txt_specification = New System.Windows.Forms.TextBox()
        Me.lb_class = New System.Windows.Forms.Label()
        Me.txt_class = New System.Windows.Forms.TextBox()
        Me.lb_lastpurchase = New System.Windows.Forms.Label()
        Me.txt_lastpurchase = New System.Windows.Forms.TextBox()
        Me.lb_EnName = New System.Windows.Forms.Label()
        Me.lb_OrderType = New System.Windows.Forms.Label()
        Me.tbp_ZhName = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ZhName = New System.Windows.Forms.TextBox()
        Me.lb_SCName = New System.Windows.Forms.Label()
        Me.txt_SCName = New System.Windows.Forms.TextBox()
        Me.tlp_checkandunit = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_unittransfer = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_chargeunit = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_chargeunit = New System.Windows.Forms.TextBox()
        Me.lb_transunit = New System.Windows.Forms.Label()
        Me.lb_claimunit = New System.Windows.Forms.Label()
        Me.ucl_txt_chargetransclainunit = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_nhiunit = New System.Windows.Forms.TextBox()
        Me.tlp_orderunit = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_orderunit1 = New System.Windows.Forms.TextBox()
        Me.txt_orderunit2 = New System.Windows.Forms.TextBox()
        Me.txt_orderunit3 = New System.Windows.Forms.TextBox()
        Me.txt_orderunit4 = New System.Windows.Forms.TextBox()
        Me.txt_orderunit5 = New System.Windows.Forms.TextBox()
        Me.lb_transferfactor = New System.Windows.Forms.Label()
        Me.lb_orderunit = New System.Windows.Forms.Label()
        Me.lb_chargeunit = New System.Windows.Forms.Label()
        Me.tlp_transfactor = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_factor1 = New System.Windows.Forms.TextBox()
        Me.txt_factor2 = New System.Windows.Forms.TextBox()
        Me.txt_factor3 = New System.Windows.Forms.TextBox()
        Me.txt_factor4 = New System.Windows.Forms.TextBox()
        Me.txt_factor5 = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lb_Majorcare = New System.Windows.Forms.Label()
        Me.uclcomb_majorcare = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.chk_IncludeOrderMark = New System.Windows.Forms.CheckBox()
        Me.tlp_date = New System.Windows.Forms.TableLayoutPanel()
        Me.ucl_dtp_enddate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_enddate = New System.Windows.Forms.Label()
        Me.ucldtp_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lb_EffectDate = New System.Windows.Forms.Label()
        Me.cbo_OPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_EMG = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_IPD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.gb_OrderPrice = New System.Windows.Forms.GroupBox()
        Me.ucldgv_OrderPrice = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.lb_Nhi_Name = New System.Windows.Forms.Label()
        Me.cb_pricehistory = New System.Windows.Forms.CheckBox()
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_OrederNote = New System.Windows.Forms.RichTextBox()
        Me.tbp_Parent.SuspendLayout()
        Me.gb_Condition.SuspendLayout()
        Me.tbp_Condition.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tbp_EffectDate.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gb_OrderItem.SuspendLayout()
        Me.tbp_1.SuspendLayout()
        Me.tbp_OrderMemo.SuspendLayout()
        Me.tbp_EnName.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tbp_ZhName.SuspendLayout()
        Me.tlp_checkandunit.SuspendLayout()
        Me.gb_unittransfer.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.tlp_chargeunit.SuspendLayout()
        Me.tlp_orderunit.SuspendLayout()
        Me.tlp_transfactor.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.tlp_date.SuspendLayout()
        Me.gb_OrderPrice.SuspendLayout()
        Me.tbp_btn.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbp_Parent
        '
        Me.tbp_Parent.ColumnCount = 1
        Me.tbp_Parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Parent.Controls.Add(Me.gb_Condition, 0, 0)
        Me.tbp_Parent.Controls.Add(Me.gb_OrderItem, 0, 1)
        Me.tbp_Parent.Controls.Add(Me.gb_OrderPrice, 0, 2)
        Me.tbp_Parent.Controls.Add(Me.tbp_btn, 0, 3)
        Me.tbp_Parent.Location = New System.Drawing.Point(2, 1)
        Me.tbp_Parent.Margin = New System.Windows.Forms.Padding(4)
        Me.tbp_Parent.Name = "tbp_Parent"
        Me.tbp_Parent.RowCount = 4
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tbp_Parent.Size = New System.Drawing.Size(984, 643)
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
        Me.gb_Condition.Size = New System.Drawing.Size(976, 57)
        Me.gb_Condition.TabIndex = 0
        Me.gb_Condition.TabStop = False
        Me.gb_Condition.Text = "查詢區"
        '
        'tbp_Condition
        '
        Me.tbp_Condition.ColumnCount = 7
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 539.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.tbp_Condition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Condition.Controls.Add(Me.Panel1, 2, 0)
        Me.tbp_Condition.Controls.Add(Me.PUBMedicineUI_ucl_txtcq_ordercode, 0, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_OrderCode, 0, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_Name, 6, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_Name, 5, 0)
        Me.tbp_Condition.Controls.Add(Me.txt_NhiCode, 4, 0)
        Me.tbp_Condition.Controls.Add(Me.lb_NhiCode, 3, 0)
        Me.tbp_Condition.Location = New System.Drawing.Point(3, 18)
        Me.tbp_Condition.Name = "tbp_Condition"
        Me.tbp_Condition.RowCount = 1
        Me.tbp_Condition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_Condition.Size = New System.Drawing.Size(968, 37)
        Me.tbp_Condition.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.tbp_EffectDate)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(662, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(30, 31)
        Me.Panel1.TabIndex = 4
        Me.Panel1.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cb_Indication, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cb_OrderCheck, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_OrderCheck, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Indication, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(21, 14)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(435, 45)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'cb_Indication
        '
        Me.cb_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_Indication.AutoSize = True
        Me.cb_Indication.Location = New System.Drawing.Point(123, 15)
        Me.cb_Indication.Name = "cb_Indication"
        Me.cb_Indication.Size = New System.Drawing.Size(15, 14)
        Me.cb_Indication.TabIndex = 17
        Me.cb_Indication.UseVisualStyleBackColor = True
        '
        'cb_OrderCheck
        '
        Me.cb_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_OrderCheck.AutoSize = True
        Me.cb_OrderCheck.Location = New System.Drawing.Point(3, 15)
        Me.cb_OrderCheck.Name = "cb_OrderCheck"
        Me.cb_OrderCheck.Size = New System.Drawing.Size(15, 14)
        Me.cb_OrderCheck.TabIndex = 15
        Me.cb_OrderCheck.UseVisualStyleBackColor = True
        '
        'btn_OrderCheck
        '
        Me.btn_OrderCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_OrderCheck.Location = New System.Drawing.Point(30, 9)
        Me.btn_OrderCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_OrderCheck.Name = "btn_OrderCheck"
        Me.btn_OrderCheck.Size = New System.Drawing.Size(84, 27)
        Me.btn_OrderCheck.TabIndex = 16
        Me.btn_OrderCheck.Text = "醫令檢核"
        Me.btn_OrderCheck.UseVisualStyleBackColor = True
        Me.btn_OrderCheck.Visible = False
        '
        'btn_Indication
        '
        Me.btn_Indication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Indication.Location = New System.Drawing.Point(150, 9)
        Me.btn_Indication.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Indication.Name = "btn_Indication"
        Me.btn_Indication.Size = New System.Drawing.Size(90, 27)
        Me.btn_Indication.TabIndex = 18
        Me.btn_Indication.Text = "適應症"
        Me.btn_Indication.UseVisualStyleBackColor = True
        Me.btn_Indication.Visible = False
        '
        'tbp_EffectDate
        '
        Me.tbp_EffectDate.ColumnCount = 4
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_EffectDate.Controls.Add(Me.txt_IncludeOrder, 3, 0)
        Me.tbp_EffectDate.Controls.Add(Me.Label2, 2, 0)
        Me.tbp_EffectDate.Controls.Add(Me.lb_Classify, 0, 0)
        Me.tbp_EffectDate.Controls.Add(Me.uclcb_classify, 1, 0)
        Me.tbp_EffectDate.Location = New System.Drawing.Point(31, 126)
        Me.tbp_EffectDate.Margin = New System.Windows.Forms.Padding(0)
        Me.tbp_EffectDate.Name = "tbp_EffectDate"
        Me.tbp_EffectDate.RowCount = 1
        Me.tbp_EffectDate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EffectDate.Size = New System.Drawing.Size(435, 45)
        Me.tbp_EffectDate.TabIndex = 6
        '
        'txt_IncludeOrder
        '
        Me.txt_IncludeOrder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_IncludeOrder.Location = New System.Drawing.Point(358, 9)
        Me.txt_IncludeOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_IncludeOrder.MaxLength = 1
        Me.txt_IncludeOrder.Name = "txt_IncludeOrder"
        Me.txt_IncludeOrder.Size = New System.Drawing.Size(54, 27)
        Me.txt_IncludeOrder.TabIndex = 36
        Me.txt_IncludeOrder.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(235, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "健保內含項註記"
        Me.Label2.Visible = False
        '
        'lb_Classify
        '
        Me.lb_Classify.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Classify.AutoSize = True
        Me.lb_Classify.Location = New System.Drawing.Point(45, 14)
        Me.lb_Classify.Name = "lb_Classify"
        Me.lb_Classify.Size = New System.Drawing.Size(72, 16)
        Me.lb_Classify.TabIndex = 1
        Me.lb_Classify.Text = "管理分類"
        Me.lb_Classify.Visible = False
        '
        'uclcb_classify
        '
        Me.uclcb_classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_classify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_classify.DropDownWidth = 20
        Me.uclcb_classify.DroppedDown = False
        Me.uclcb_classify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_classify.Location = New System.Drawing.Point(120, 10)
        Me.uclcb_classify.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcb_classify.Name = "uclcb_classify"
        Me.uclcb_classify.SelectedIndex = -1
        Me.uclcb_classify.SelectedItem = Nothing
        Me.uclcb_classify.SelectedText = ""
        Me.uclcb_classify.SelectedValue = ""
        Me.uclcb_classify.SelectionStart = 0
        Me.uclcb_classify.Size = New System.Drawing.Size(112, 24)
        Me.uclcb_classify.TabIndex = 27
        Me.uclcb_classify.uclDisplayIndex = "0,1"
        Me.uclcb_classify.uclIsAutoClear = True
        Me.uclcb_classify.uclIsFirstItemEmpty = True
        Me.uclcb_classify.uclIsTextMode = False
        Me.uclcb_classify.uclShowMsg = False
        Me.uclcb_classify.uclValueIndex = "0"
        Me.uclcb_classify.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Nhi, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_NhiSheet, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_exclusivedrug, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_excludecharge, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_nhiindex, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_nhiindex, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(24, 69)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(435, 45)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'btn_Nhi
        '
        Me.btn_Nhi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Nhi.Location = New System.Drawing.Point(270, 9)
        Me.btn_Nhi.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Nhi.Name = "btn_Nhi"
        Me.btn_Nhi.Size = New System.Drawing.Size(130, 27)
        Me.btn_Nhi.TabIndex = 25
        Me.btn_Nhi.Text = "健保給付規定單"
        Me.btn_Nhi.UseVisualStyleBackColor = True
        '
        'cb_NhiSheet
        '
        Me.cb_NhiSheet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_NhiSheet.AutoSize = True
        Me.cb_NhiSheet.Location = New System.Drawing.Point(243, 15)
        Me.cb_NhiSheet.Name = "cb_NhiSheet"
        Me.cb_NhiSheet.Size = New System.Drawing.Size(15, 14)
        Me.cb_NhiSheet.TabIndex = 24
        Me.cb_NhiSheet.UseVisualStyleBackColor = True
        '
        'cb_exclusivedrug
        '
        Me.cb_exclusivedrug.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_exclusivedrug.AutoSize = True
        Me.cb_exclusivedrug.Location = New System.Drawing.Point(3, 15)
        Me.cb_exclusivedrug.Name = "cb_exclusivedrug"
        Me.cb_exclusivedrug.Size = New System.Drawing.Size(15, 14)
        Me.cb_exclusivedrug.TabIndex = 26
        Me.cb_exclusivedrug.UseVisualStyleBackColor = True
        '
        'btn_excludecharge
        '
        Me.btn_excludecharge.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_excludecharge.Location = New System.Drawing.Point(30, 9)
        Me.btn_excludecharge.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_excludecharge.Name = "btn_excludecharge"
        Me.btn_excludecharge.Size = New System.Drawing.Size(90, 27)
        Me.btn_excludecharge.TabIndex = 27
        Me.btn_excludecharge.Text = "排除藥費-HIV"
        Me.btn_excludecharge.UseVisualStyleBackColor = True
        Me.btn_excludecharge.Visible = False
        '
        'cb_nhiindex
        '
        Me.cb_nhiindex.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_nhiindex.AutoSize = True
        Me.cb_nhiindex.Location = New System.Drawing.Point(123, 15)
        Me.cb_nhiindex.Name = "cb_nhiindex"
        Me.cb_nhiindex.Size = New System.Drawing.Size(15, 14)
        Me.cb_nhiindex.TabIndex = 28
        Me.cb_nhiindex.UseVisualStyleBackColor = True
        '
        'btn_nhiindex
        '
        Me.btn_nhiindex.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_nhiindex.Location = New System.Drawing.Point(150, 9)
        Me.btn_nhiindex.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_nhiindex.Name = "btn_nhiindex"
        Me.btn_nhiindex.Size = New System.Drawing.Size(90, 27)
        Me.btn_nhiindex.TabIndex = 29
        Me.btn_nhiindex.Text = "健保指標"
        Me.btn_nhiindex.UseVisualStyleBackColor = True
        Me.btn_nhiindex.Visible = False
        '
        'PUBMedicineUI_ucl_txtcq_ordercode
        '
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PUBMedicineUI_ucl_txtcq_ordercode.doFlag = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Location = New System.Drawing.Point(120, 5)
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Margin = New System.Windows.Forms.Padding(0)
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Name = "PUBMedicineUI_ucl_txtcq_ordercode"
        Me.PUBMedicineUI_ucl_txtcq_ordercode.Size = New System.Drawing.Size(300, 26)
        Me.PUBMedicineUI_ucl_txtcq_ordercode.TabIndex = 8
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclBaseDate = "2016/04/21"
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCboWidth = 264
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeName = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeName1 = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeName2 = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeValue = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclControlFlag = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclDisplayIndex = "0,1"
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsAutoAddZero = False
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsBtnVisible = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsCheckDoctorOnDuty = False
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsCheckTime = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsEnglishDept = False
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsReturnDS = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsShowMsgBox = True
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclIsTextAutoClear = False
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclLabel = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclMsgValue = Nothing
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclNoDataOpenWindow = False
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclPUBEmployeeProfessalKindId = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclQueryField = Nothing
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclQueryValue = "D"
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclRegionKind = ""
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_OrderForDrugMantain
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclTotalWidth = 8
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclXPosition = 225
        Me.PUBMedicineUI_ucl_txtcq_ordercode.uclYPosition = 120
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
        Me.txt_Name.Location = New System.Drawing.Point(879, 5)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(85, 27)
        Me.txt_Name.TabIndex = 3
        '
        'lb_Name
        '
        Me.lb_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Name.AutoSize = True
        Me.lb_Name.Location = New System.Drawing.Point(833, 10)
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
        Me.txt_NhiCode.Location = New System.Drawing.Point(762, 5)
        Me.txt_NhiCode.Name = "txt_NhiCode"
        Me.txt_NhiCode.Size = New System.Drawing.Size(59, 27)
        Me.txt_NhiCode.TabIndex = 4
        '
        'lb_NhiCode
        '
        Me.lb_NhiCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_NhiCode.AutoSize = True
        Me.lb_NhiCode.Location = New System.Drawing.Point(700, 10)
        Me.lb_NhiCode.Name = "lb_NhiCode"
        Me.lb_NhiCode.Size = New System.Drawing.Size(56, 16)
        Me.lb_NhiCode.TabIndex = 1
        Me.lb_NhiCode.Text = "健保碼"
        '
        'gb_OrderItem
        '
        Me.gb_OrderItem.Controls.Add(Me.tbp_1)
        Me.gb_OrderItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_OrderItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderItem.Location = New System.Drawing.Point(4, 69)
        Me.gb_OrderItem.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Name = "gb_OrderItem"
        Me.gb_OrderItem.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderItem.Size = New System.Drawing.Size(976, 342)
        Me.gb_OrderItem.TabIndex = 1
        Me.gb_OrderItem.TabStop = False
        '
        'tbp_1
        '
        Me.tbp_1.ColumnCount = 2
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tbp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_1.Controls.Add(Me.lb_OrderRemark, 0, 3)
        Me.tbp_1.Controls.Add(Me.tbp_OrderMemo, 1, 3)
        Me.tbp_1.Controls.Add(Me.tbp_EnName, 1, 1)
        Me.tbp_1.Controls.Add(Me.cb_Dc, 0, 6)
        Me.tbp_1.Controls.Add(Me.lb_TWName, 0, 0)
        Me.tbp_1.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.tbp_1.Controls.Add(Me.lb_EnName, 0, 1)
        Me.tbp_1.Controls.Add(Me.lb_OrderType, 0, 2)
        Me.tbp_1.Controls.Add(Me.tbp_ZhName, 1, 0)
        Me.tbp_1.Controls.Add(Me.tlp_checkandunit, 0, 4)
        Me.tbp_1.Controls.Add(Me.tlp_date, 1, 6)
        Me.tbp_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_1.Location = New System.Drawing.Point(4, 24)
        Me.tbp_1.Name = "tbp_1"
        Me.tbp_1.RowCount = 7
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.tbp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_1.Size = New System.Drawing.Size(968, 314)
        Me.tbp_1.TabIndex = 0
        '
        'lb_OrderRemark
        '
        Me.lb_OrderRemark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderRemark.AutoSize = True
        Me.lb_OrderRemark.Location = New System.Drawing.Point(45, 114)
        Me.lb_OrderRemark.Name = "lb_OrderRemark"
        Me.lb_OrderRemark.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderRemark.TabIndex = 1
        Me.lb_OrderRemark.Text = "醫令備註"
        '
        'tbp_OrderMemo
        '
        Me.tbp_OrderMemo.ColumnCount = 6
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbp_OrderMemo.Controls.Add(Me.memo_OrderMemo, 5, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.txt_Note, 0, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.lb_Mark, 1, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.lb_OrderPS, 4, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.txt_Flag, 2, 0)
        Me.tbp_OrderMemo.Controls.Add(Me.cb_preview, 3, 0)
        Me.tbp_OrderMemo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_OrderMemo.Location = New System.Drawing.Point(123, 108)
        Me.tbp_OrderMemo.Name = "tbp_OrderMemo"
        Me.tbp_OrderMemo.RowCount = 1
        Me.tbp_OrderMemo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_OrderMemo.Size = New System.Drawing.Size(842, 29)
        Me.tbp_OrderMemo.TabIndex = 8
        '
        'memo_OrderMemo
        '
        Me.memo_OrderMemo.Location = New System.Drawing.Point(763, 0)
        Me.memo_OrderMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.memo_OrderMemo.Name = "memo_OrderMemo"
        Me.memo_OrderMemo.Size = New System.Drawing.Size(75, 27)
        Me.memo_OrderMemo.TabIndex = 12
        Me.memo_OrderMemo.Visible = False
        '
        'txt_Note
        '
        Me.txt_Note.Location = New System.Drawing.Point(0, 0)
        Me.txt_Note.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Note.Name = "txt_Note"
        Me.txt_Note.Size = New System.Drawing.Size(375, 27)
        Me.txt_Note.TabIndex = 13
        '
        'lb_Mark
        '
        Me.lb_Mark.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_Mark.AutoSize = True
        Me.lb_Mark.Location = New System.Drawing.Point(378, 6)
        Me.lb_Mark.Name = "lb_Mark"
        Me.lb_Mark.Size = New System.Drawing.Size(40, 16)
        Me.lb_Mark.TabIndex = 2
        Me.lb_Mark.Text = "註記"
        Me.lb_Mark.Visible = False
        '
        'lb_OrderPS
        '
        Me.lb_OrderPS.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderPS.AutoSize = True
        Me.lb_OrderPS.Location = New System.Drawing.Point(656, 6)
        Me.lb_OrderPS.Name = "lb_OrderPS"
        Me.lb_OrderPS.Size = New System.Drawing.Size(104, 16)
        Me.lb_OrderPS.TabIndex = 3
        Me.lb_OrderPS.Text = "醫令注意事項"
        Me.lb_OrderPS.Visible = False
        '
        'txt_Flag
        '
        Me.txt_Flag.Location = New System.Drawing.Point(421, 0)
        Me.txt_Flag.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Flag.MaxLength = 2
        Me.txt_Flag.Name = "txt_Flag"
        Me.txt_Flag.Size = New System.Drawing.Size(103, 27)
        Me.txt_Flag.TabIndex = 14
        Me.txt_Flag.Visible = False
        '
        'cb_preview
        '
        Me.cb_preview.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_preview.AutoSize = True
        Me.cb_preview.Location = New System.Drawing.Point(527, 4)
        Me.cb_preview.Name = "cb_preview"
        Me.cb_preview.Size = New System.Drawing.Size(123, 20)
        Me.cb_preview.TabIndex = 20
        Me.cb_preview.Text = "事前審查醫令"
        Me.cb_preview.UseVisualStyleBackColor = True
        '
        'tbp_EnName
        '
        Me.tbp_EnName.ColumnCount = 5
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.tbp_EnName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.tbp_EnName.Controls.Add(Me.txt_EnName, 0, 0)
        Me.tbp_EnName.Controls.Add(Me.lb_SEName, 1, 0)
        Me.tbp_EnName.Controls.Add(Me.txt_SEName, 2, 0)
        Me.tbp_EnName.Controls.Add(Me.Label1, 3, 0)
        Me.tbp_EnName.Controls.Add(Me.txt_atccode, 4, 0)
        Me.tbp_EnName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_EnName.Location = New System.Drawing.Point(123, 38)
        Me.tbp_EnName.Name = "tbp_EnName"
        Me.tbp_EnName.RowCount = 1
        Me.tbp_EnName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_EnName.Size = New System.Drawing.Size(842, 29)
        Me.tbp_EnName.TabIndex = 6
        '
        'txt_EnName
        '
        Me.txt_EnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EnName.Enabled = False
        Me.txt_EnName.Location = New System.Drawing.Point(0, 1)
        Me.txt_EnName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_EnName.MaxLength = 100
        Me.txt_EnName.Name = "txt_EnName"
        Me.txt_EnName.Size = New System.Drawing.Size(407, 27)
        Me.txt_EnName.TabIndex = 6
        '
        'lb_SEName
        '
        Me.lb_SEName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SEName.AutoSize = True
        Me.lb_SEName.Location = New System.Drawing.Point(415, 6)
        Me.lb_SEName.Name = "lb_SEName"
        Me.lb_SEName.Size = New System.Drawing.Size(56, 16)
        Me.lb_SEName.TabIndex = 1
        Me.lb_SEName.Text = "中文名"
        '
        'txt_SEName
        '
        Me.txt_SEName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SEName.Enabled = False
        Me.txt_SEName.Location = New System.Drawing.Point(474, 1)
        Me.txt_SEName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SEName.MaxLength = 50
        Me.txt_SEName.Name = "txt_SEName"
        Me.txt_SEName.Size = New System.Drawing.Size(142, 27)
        Me.txt_SEName.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(619, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ATC code"
        '
        'txt_atccode
        '
        Me.txt_atccode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_atccode.Location = New System.Drawing.Point(695, 1)
        Me.txt_atccode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_atccode.MaxLength = 30
        Me.txt_atccode.Name = "txt_atccode"
        Me.txt_atccode.ReadOnly = True
        Me.txt_atccode.Size = New System.Drawing.Size(120, 27)
        Me.txt_atccode.TabIndex = 9
        '
        'cb_Dc
        '
        Me.cb_Dc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_Dc.AutoSize = True
        Me.cb_Dc.Location = New System.Drawing.Point(58, 285)
        Me.cb_Dc.Name = "cb_Dc"
        Me.cb_Dc.Size = New System.Drawing.Size(59, 20)
        Me.cb_Dc.TabIndex = 19
        Me.cb_Dc.Text = "停用"
        Me.cb_Dc.UseVisualStyleBackColor = True
        '
        'lb_TWName
        '
        Me.lb_TWName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_TWName.AutoSize = True
        Me.lb_TWName.Location = New System.Drawing.Point(77, 9)
        Me.lb_TWName.Name = "lb_TWName"
        Me.lb_TWName.Size = New System.Drawing.Size(40, 16)
        Me.lb_TWName.TabIndex = 0
        Me.lb_TWName.Text = "學名"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lb_HosFee, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.uclcomb_OrderType, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.uclcomb_HosItem, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lb_specification, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_specification, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lb_class, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_class, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lb_lastpurchase, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_lastpurchase, 8, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(123, 73)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(842, 29)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'lb_HosFee
        '
        Me.lb_HosFee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_HosFee.AutoSize = True
        Me.lb_HosFee.ForeColor = System.Drawing.Color.Red
        Me.lb_HosFee.Location = New System.Drawing.Point(116, 6)
        Me.lb_HosFee.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_HosFee.Name = "lb_HosFee"
        Me.lb_HosFee.Size = New System.Drawing.Size(104, 16)
        Me.lb_HosFee.TabIndex = 0
        Me.lb_HosFee.Text = "院內費用項目"
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
        'uclcomb_HosItem
        '
        Me.uclcomb_HosItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_HosItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_HosItem.DropDownWidth = 20
        Me.uclcomb_HosItem.DroppedDown = False
        Me.uclcomb_HosItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_HosItem.Location = New System.Drawing.Point(220, 2)
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
        'lb_specification
        '
        Me.lb_specification.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_specification.AutoSize = True
        Me.lb_specification.Location = New System.Drawing.Point(326, 6)
        Me.lb_specification.Name = "lb_specification"
        Me.lb_specification.Size = New System.Drawing.Size(72, 16)
        Me.lb_specification.TabIndex = 10
        Me.lb_specification.Text = "規格含量"
        '
        'txt_specification
        '
        Me.txt_specification.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_specification.Enabled = False
        Me.txt_specification.Location = New System.Drawing.Point(401, 1)
        Me.txt_specification.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_specification.Name = "txt_specification"
        Me.txt_specification.Size = New System.Drawing.Size(77, 27)
        Me.txt_specification.TabIndex = 11
        '
        'lb_class
        '
        Me.lb_class.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_class.AutoSize = True
        Me.lb_class.Location = New System.Drawing.Point(484, 6)
        Me.lb_class.Name = "lb_class"
        Me.lb_class.Size = New System.Drawing.Size(72, 16)
        Me.lb_class.TabIndex = 12
        Me.lb_class.Text = "藥理分類"
        '
        'txt_class
        '
        Me.txt_class.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_class.Enabled = False
        Me.txt_class.Location = New System.Drawing.Point(559, 1)
        Me.txt_class.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_class.Name = "txt_class"
        Me.txt_class.Size = New System.Drawing.Size(69, 27)
        Me.txt_class.TabIndex = 13
        '
        'lb_lastpurchase
        '
        Me.lb_lastpurchase.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_lastpurchase.AutoSize = True
        Me.lb_lastpurchase.Location = New System.Drawing.Point(631, 6)
        Me.lb_lastpurchase.Name = "lb_lastpurchase"
        Me.lb_lastpurchase.Size = New System.Drawing.Size(104, 16)
        Me.lb_lastpurchase.TabIndex = 14
        Me.lb_lastpurchase.Text = "最後採購單價"
        Me.lb_lastpurchase.Visible = False
        '
        'txt_lastpurchase
        '
        Me.txt_lastpurchase.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_lastpurchase.Enabled = False
        Me.txt_lastpurchase.Location = New System.Drawing.Point(746, 1)
        Me.txt_lastpurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_lastpurchase.Name = "txt_lastpurchase"
        Me.txt_lastpurchase.Size = New System.Drawing.Size(72, 27)
        Me.txt_lastpurchase.TabIndex = 15
        Me.txt_lastpurchase.Visible = False
        '
        'lb_EnName
        '
        Me.lb_EnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_EnName.AutoSize = True
        Me.lb_EnName.Location = New System.Drawing.Point(45, 44)
        Me.lb_EnName.Name = "lb_EnName"
        Me.lb_EnName.Size = New System.Drawing.Size(72, 16)
        Me.lb_EnName.TabIndex = 1
        Me.lb_EnName.Text = "藥囑藥名"
        '
        'lb_OrderType
        '
        Me.lb_OrderType.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_OrderType.AutoSize = True
        Me.lb_OrderType.ForeColor = System.Drawing.Color.Red
        Me.lb_OrderType.Location = New System.Drawing.Point(45, 79)
        Me.lb_OrderType.Name = "lb_OrderType"
        Me.lb_OrderType.Size = New System.Drawing.Size(72, 16)
        Me.lb_OrderType.TabIndex = 2
        Me.lb_OrderType.Text = "醫令類型"
        '
        'tbp_ZhName
        '
        Me.tbp_ZhName.ColumnCount = 4
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410.0!))
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_ZhName.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226.0!))
        Me.tbp_ZhName.Controls.Add(Me.txt_ZhName, 0, 0)
        Me.tbp_ZhName.Controls.Add(Me.lb_SCName, 1, 0)
        Me.tbp_ZhName.Controls.Add(Me.txt_SCName, 2, 0)
        Me.tbp_ZhName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbp_ZhName.Location = New System.Drawing.Point(123, 3)
        Me.tbp_ZhName.Name = "tbp_ZhName"
        Me.tbp_ZhName.RowCount = 1
        Me.tbp_ZhName.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_ZhName.Size = New System.Drawing.Size(842, 29)
        Me.tbp_ZhName.TabIndex = 5
        '
        'txt_ZhName
        '
        Me.txt_ZhName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ZhName.Enabled = False
        Me.txt_ZhName.Location = New System.Drawing.Point(0, 1)
        Me.txt_ZhName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_ZhName.MaxLength = 100
        Me.txt_ZhName.Name = "txt_ZhName"
        Me.txt_ZhName.Size = New System.Drawing.Size(407, 27)
        Me.txt_ZhName.TabIndex = 4
        '
        'lb_SCName
        '
        Me.lb_SCName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_SCName.AutoSize = True
        Me.lb_SCName.Location = New System.Drawing.Point(414, 6)
        Me.lb_SCName.Name = "lb_SCName"
        Me.lb_SCName.Size = New System.Drawing.Size(56, 16)
        Me.lb_SCName.TabIndex = 1
        Me.lb_SCName.Text = "商品名"
        '
        'txt_SCName
        '
        Me.txt_SCName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SCName.Enabled = False
        Me.txt_SCName.Location = New System.Drawing.Point(473, 1)
        Me.txt_SCName.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_SCName.MaxLength = 50
        Me.txt_SCName.Name = "txt_SCName"
        Me.txt_SCName.Size = New System.Drawing.Size(143, 27)
        Me.txt_SCName.TabIndex = 5
        '
        'tlp_checkandunit
        '
        Me.tlp_checkandunit.ColumnCount = 2
        Me.tbp_1.SetColumnSpan(Me.tlp_checkandunit, 2)
        Me.tlp_checkandunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.33884!))
        Me.tlp_checkandunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.66116!))
        Me.tlp_checkandunit.Controls.Add(Me.gb_unittransfer, 0, 0)
        Me.tlp_checkandunit.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.tlp_checkandunit.Controls.Add(Me.GroupBox1, 1, 1)
        Me.tlp_checkandunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_checkandunit.Location = New System.Drawing.Point(0, 140)
        Me.tlp_checkandunit.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_checkandunit.Name = "tlp_checkandunit"
        Me.tlp_checkandunit.RowCount = 4
        Me.tbp_1.SetRowSpan(Me.tlp_checkandunit, 2)
        Me.tlp_checkandunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tlp_checkandunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.tlp_checkandunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlp_checkandunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_checkandunit.Size = New System.Drawing.Size(968, 136)
        Me.tlp_checkandunit.TabIndex = 9
        '
        'gb_unittransfer
        '
        Me.gb_unittransfer.Controls.Add(Me.TableLayoutPanel4)
        Me.gb_unittransfer.Location = New System.Drawing.Point(3, 3)
        Me.gb_unittransfer.Name = "gb_unittransfer"
        Me.tlp_checkandunit.SetRowSpan(Me.gb_unittransfer, 3)
        Me.gb_unittransfer.Size = New System.Drawing.Size(518, 129)
        Me.gb_unittransfer.TabIndex = 0
        Me.gb_unittransfer.TabStop = False
        Me.gb_unittransfer.Text = "單位轉換"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.tlp_chargeunit, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.tlp_orderunit, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lb_transferfactor, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lb_orderunit, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lb_chargeunit, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.tlp_transfactor, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(505, 103)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'tlp_chargeunit
        '
        Me.tlp_chargeunit.ColumnCount = 5
        Me.tlp_chargeunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_chargeunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.tlp_chargeunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlp_chargeunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.tlp_chargeunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_chargeunit.Controls.Add(Me.txt_chargeunit, 0, 0)
        Me.tlp_chargeunit.Controls.Add(Me.lb_transunit, 1, 0)
        Me.tlp_chargeunit.Controls.Add(Me.lb_claimunit, 3, 0)
        Me.tlp_chargeunit.Controls.Add(Me.ucl_txt_chargetransclainunit, 2, 0)
        Me.tlp_chargeunit.Controls.Add(Me.txt_nhiunit, 4, 0)
        Me.tlp_chargeunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_chargeunit.Location = New System.Drawing.Point(100, 66)
        Me.tlp_chargeunit.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_chargeunit.Name = "tlp_chargeunit"
        Me.tlp_chargeunit.RowCount = 1
        Me.tlp_chargeunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_chargeunit.Size = New System.Drawing.Size(405, 37)
        Me.tlp_chargeunit.TabIndex = 33
        '
        'txt_chargeunit
        '
        Me.txt_chargeunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_chargeunit.Enabled = False
        Me.txt_chargeunit.Location = New System.Drawing.Point(0, 5)
        Me.txt_chargeunit.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_chargeunit.Name = "txt_chargeunit"
        Me.txt_chargeunit.Size = New System.Drawing.Size(60, 27)
        Me.txt_chargeunit.TabIndex = 36
        '
        'lb_transunit
        '
        Me.lb_transunit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_transunit.AutoSize = True
        Me.lb_transunit.ForeColor = System.Drawing.Color.Red
        Me.lb_transunit.Location = New System.Drawing.Point(67, 10)
        Me.lb_transunit.Name = "lb_transunit"
        Me.lb_transunit.Size = New System.Drawing.Size(120, 16)
        Me.lb_transunit.TabIndex = 29
        Me.lb_transunit.Text = "計價轉申報單位"
        '
        'lb_claimunit
        '
        Me.lb_claimunit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_claimunit.AutoSize = True
        Me.lb_claimunit.ForeColor = System.Drawing.Color.Red
        Me.lb_claimunit.Location = New System.Drawing.Point(257, 10)
        Me.lb_claimunit.Name = "lb_claimunit"
        Me.lb_claimunit.Size = New System.Drawing.Size(72, 16)
        Me.lb_claimunit.TabIndex = 38
        Me.lb_claimunit.Text = "申報單位"
        '
        'ucl_txt_chargetransclainunit
        '
        Me.ucl_txt_chargetransclainunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_chargetransclainunit.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_chargetransclainunit.Location = New System.Drawing.Point(190, 5)
        Me.ucl_txt_chargetransclainunit.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_chargetransclainunit.MaxLength = 10
        Me.ucl_txt_chargetransclainunit.Name = "ucl_txt_chargetransclainunit"
        Me.ucl_txt_chargetransclainunit.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_chargetransclainunit.SelectionStart = 0
        Me.ucl_txt_chargetransclainunit.Size = New System.Drawing.Size(60, 27)
        Me.ucl_txt_chargetransclainunit.TabIndex = 40
        Me.ucl_txt_chargetransclainunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ucl_txt_chargetransclainunit.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_chargetransclainunit.ToolTipTag = Nothing
        Me.ucl_txt_chargetransclainunit.uclDollarSign = False
        Me.ucl_txt_chargetransclainunit.uclDotCount = 0
        Me.ucl_txt_chargetransclainunit.uclIntCount = 2
        Me.ucl_txt_chargetransclainunit.uclMinus = False
        Me.ucl_txt_chargetransclainunit.uclReadOnly = False
        Me.ucl_txt_chargetransclainunit.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_txt_chargetransclainunit.uclTrimZero = True
        '
        'txt_nhiunit
        '
        Me.txt_nhiunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_nhiunit.Location = New System.Drawing.Point(332, 5)
        Me.txt_nhiunit.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_nhiunit.Name = "txt_nhiunit"
        Me.txt_nhiunit.Size = New System.Drawing.Size(60, 27)
        Me.txt_nhiunit.TabIndex = 41
        '
        'tlp_orderunit
        '
        Me.tlp_orderunit.ColumnCount = 5
        Me.tlp_orderunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_orderunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_orderunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_orderunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_orderunit.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_orderunit.Controls.Add(Me.txt_orderunit1, 0, 0)
        Me.tlp_orderunit.Controls.Add(Me.txt_orderunit2, 1, 0)
        Me.tlp_orderunit.Controls.Add(Me.txt_orderunit3, 2, 0)
        Me.tlp_orderunit.Controls.Add(Me.txt_orderunit4, 3, 0)
        Me.tlp_orderunit.Controls.Add(Me.txt_orderunit5, 4, 0)
        Me.tlp_orderunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_orderunit.Location = New System.Drawing.Point(100, 33)
        Me.tlp_orderunit.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_orderunit.Name = "tlp_orderunit"
        Me.tlp_orderunit.RowCount = 1
        Me.tlp_orderunit.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_orderunit.Size = New System.Drawing.Size(405, 33)
        Me.tlp_orderunit.TabIndex = 32
        '
        'txt_orderunit1
        '
        Me.txt_orderunit1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_orderunit1.Enabled = False
        Me.txt_orderunit1.Location = New System.Drawing.Point(0, 3)
        Me.txt_orderunit1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_orderunit1.Name = "txt_orderunit1"
        Me.txt_orderunit1.Size = New System.Drawing.Size(72, 27)
        Me.txt_orderunit1.TabIndex = 31
        '
        'txt_orderunit2
        '
        Me.txt_orderunit2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_orderunit2.Enabled = False
        Me.txt_orderunit2.Location = New System.Drawing.Point(80, 3)
        Me.txt_orderunit2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_orderunit2.Name = "txt_orderunit2"
        Me.txt_orderunit2.Size = New System.Drawing.Size(72, 27)
        Me.txt_orderunit2.TabIndex = 32
        '
        'txt_orderunit3
        '
        Me.txt_orderunit3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_orderunit3.Enabled = False
        Me.txt_orderunit3.Location = New System.Drawing.Point(160, 3)
        Me.txt_orderunit3.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_orderunit3.Name = "txt_orderunit3"
        Me.txt_orderunit3.Size = New System.Drawing.Size(72, 27)
        Me.txt_orderunit3.TabIndex = 33
        '
        'txt_orderunit4
        '
        Me.txt_orderunit4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_orderunit4.Enabled = False
        Me.txt_orderunit4.Location = New System.Drawing.Point(240, 3)
        Me.txt_orderunit4.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_orderunit4.Name = "txt_orderunit4"
        Me.txt_orderunit4.Size = New System.Drawing.Size(72, 27)
        Me.txt_orderunit4.TabIndex = 34
        '
        'txt_orderunit5
        '
        Me.txt_orderunit5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_orderunit5.Enabled = False
        Me.txt_orderunit5.Location = New System.Drawing.Point(320, 3)
        Me.txt_orderunit5.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_orderunit5.Name = "txt_orderunit5"
        Me.txt_orderunit5.Size = New System.Drawing.Size(72, 27)
        Me.txt_orderunit5.TabIndex = 35
        '
        'lb_transferfactor
        '
        Me.lb_transferfactor.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_transferfactor.AutoSize = True
        Me.lb_transferfactor.Location = New System.Drawing.Point(9, 8)
        Me.lb_transferfactor.Name = "lb_transferfactor"
        Me.lb_transferfactor.Size = New System.Drawing.Size(88, 16)
        Me.lb_transferfactor.TabIndex = 21
        Me.lb_transferfactor.Text = "劑量轉換係"
        '
        'lb_orderunit
        '
        Me.lb_orderunit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_orderunit.AutoSize = True
        Me.lb_orderunit.Location = New System.Drawing.Point(25, 41)
        Me.lb_orderunit.Name = "lb_orderunit"
        Me.lb_orderunit.Size = New System.Drawing.Size(72, 16)
        Me.lb_orderunit.TabIndex = 30
        Me.lb_orderunit.Text = "醫囑單位"
        '
        'lb_chargeunit
        '
        Me.lb_chargeunit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_chargeunit.AutoSize = True
        Me.lb_chargeunit.ForeColor = System.Drawing.Color.Black
        Me.lb_chargeunit.Location = New System.Drawing.Point(25, 76)
        Me.lb_chargeunit.Name = "lb_chargeunit"
        Me.lb_chargeunit.Size = New System.Drawing.Size(72, 16)
        Me.lb_chargeunit.TabIndex = 28
        Me.lb_chargeunit.Text = "計價單位"
        '
        'tlp_transfactor
        '
        Me.tlp_transfactor.ColumnCount = 5
        Me.tlp_transfactor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_transfactor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_transfactor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_transfactor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlp_transfactor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_transfactor.Controls.Add(Me.txt_factor1, 0, 0)
        Me.tlp_transfactor.Controls.Add(Me.txt_factor2, 1, 0)
        Me.tlp_transfactor.Controls.Add(Me.txt_factor3, 2, 0)
        Me.tlp_transfactor.Controls.Add(Me.txt_factor4, 3, 0)
        Me.tlp_transfactor.Controls.Add(Me.txt_factor5, 4, 0)
        Me.tlp_transfactor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_transfactor.Location = New System.Drawing.Point(100, 0)
        Me.tlp_transfactor.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_transfactor.Name = "tlp_transfactor"
        Me.tlp_transfactor.RowCount = 1
        Me.tlp_transfactor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_transfactor.Size = New System.Drawing.Size(405, 33)
        Me.tlp_transfactor.TabIndex = 31
        '
        'txt_factor1
        '
        Me.txt_factor1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_factor1.Enabled = False
        Me.txt_factor1.Location = New System.Drawing.Point(0, 3)
        Me.txt_factor1.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_factor1.Name = "txt_factor1"
        Me.txt_factor1.Size = New System.Drawing.Size(72, 27)
        Me.txt_factor1.TabIndex = 22
        '
        'txt_factor2
        '
        Me.txt_factor2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_factor2.Enabled = False
        Me.txt_factor2.Location = New System.Drawing.Point(80, 3)
        Me.txt_factor2.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_factor2.Name = "txt_factor2"
        Me.txt_factor2.Size = New System.Drawing.Size(72, 27)
        Me.txt_factor2.TabIndex = 23
        '
        'txt_factor3
        '
        Me.txt_factor3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_factor3.Enabled = False
        Me.txt_factor3.Location = New System.Drawing.Point(160, 3)
        Me.txt_factor3.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_factor3.Name = "txt_factor3"
        Me.txt_factor3.Size = New System.Drawing.Size(72, 27)
        Me.txt_factor3.TabIndex = 24
        '
        'txt_factor4
        '
        Me.txt_factor4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_factor4.Enabled = False
        Me.txt_factor4.Location = New System.Drawing.Point(240, 3)
        Me.txt_factor4.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_factor4.Name = "txt_factor4"
        Me.txt_factor4.Size = New System.Drawing.Size(72, 27)
        Me.txt_factor4.TabIndex = 25
        '
        'txt_factor5
        '
        Me.txt_factor5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_factor5.Enabled = False
        Me.txt_factor5.Location = New System.Drawing.Point(320, 3)
        Me.txt_factor5.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_factor5.Name = "txt_factor5"
        Me.txt_factor5.Size = New System.Drawing.Size(72, 27)
        Me.txt_factor5.TabIndex = 26
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel2.Controls.Add(Me.lb_Majorcare)
        Me.FlowLayoutPanel2.Controls.Add(Me.uclcomb_majorcare)
        Me.FlowLayoutPanel2.Controls.Add(Me.chk_IncludeOrderMark)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(529, 4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(433, 28)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'lb_Majorcare
        '
        Me.lb_Majorcare.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_Majorcare.AutoSize = True
        Me.lb_Majorcare.Location = New System.Drawing.Point(3, 5)
        Me.lb_Majorcare.Name = "lb_Majorcare"
        Me.lb_Majorcare.Size = New System.Drawing.Size(104, 16)
        Me.lb_Majorcare.TabIndex = 12
        Me.lb_Majorcare.Text = "特定治療項目"
        '
        'uclcomb_majorcare
        '
        Me.uclcomb_majorcare.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcomb_majorcare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcomb_majorcare.DropDownWidth = 20
        Me.uclcomb_majorcare.DroppedDown = False
        Me.uclcomb_majorcare.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcomb_majorcare.Location = New System.Drawing.Point(110, 1)
        Me.uclcomb_majorcare.Margin = New System.Windows.Forms.Padding(0)
        Me.uclcomb_majorcare.Name = "uclcomb_majorcare"
        Me.uclcomb_majorcare.SelectedIndex = -1
        Me.uclcomb_majorcare.SelectedItem = Nothing
        Me.uclcomb_majorcare.SelectedText = ""
        Me.uclcomb_majorcare.SelectedValue = ""
        Me.uclcomb_majorcare.SelectionStart = 0
        Me.uclcomb_majorcare.Size = New System.Drawing.Size(134, 24)
        Me.uclcomb_majorcare.TabIndex = 13
        Me.uclcomb_majorcare.uclDisplayIndex = "0,1"
        Me.uclcomb_majorcare.uclIsAutoClear = True
        Me.uclcomb_majorcare.uclIsFirstItemEmpty = True
        Me.uclcomb_majorcare.uclIsTextMode = False
        Me.uclcomb_majorcare.uclShowMsg = False
        Me.uclcomb_majorcare.uclValueIndex = "0"
        '
        'chk_IncludeOrderMark
        '
        Me.chk_IncludeOrderMark.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_IncludeOrderMark.AutoSize = True
        Me.chk_IncludeOrderMark.Location = New System.Drawing.Point(254, 3)
        Me.chk_IncludeOrderMark.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.chk_IncludeOrderMark.Name = "chk_IncludeOrderMark"
        Me.chk_IncludeOrderMark.Size = New System.Drawing.Size(165, 20)
        Me.chk_IncludeOrderMark.TabIndex = 2
        Me.chk_IncludeOrderMark.Text = "健保內含項(不計價)"
        Me.chk_IncludeOrderMark.UseVisualStyleBackColor = True
        '
        'tlp_date
        '
        Me.tlp_date.ColumnCount = 7
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_date.Controls.Add(Me.ucl_dtp_enddate, 6, 0)
        Me.tlp_date.Controls.Add(Me.lb_enddate, 5, 0)
        Me.tlp_date.Controls.Add(Me.ucldtp_EffectDate, 4, 0)
        Me.tlp_date.Controls.Add(Me.lb_EffectDate, 3, 0)
        Me.tlp_date.Controls.Add(Me.cbo_OPD, 0, 0)
        Me.tlp_date.Controls.Add(Me.cbo_EMG, 1, 0)
        Me.tlp_date.Controls.Add(Me.cbo_IPD, 2, 0)
        Me.tlp_date.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_date.Location = New System.Drawing.Point(123, 279)
        Me.tlp_date.Name = "tlp_date"
        Me.tlp_date.RowCount = 1
        Me.tlp_date.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_date.Size = New System.Drawing.Size(842, 32)
        Me.tlp_date.TabIndex = 8
        '
        'ucl_dtp_enddate
        '
        Me.ucl_dtp_enddate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_enddate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.ucl_dtp_enddate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ucl_dtp_enddate.Location = New System.Drawing.Point(621, 3)
        Me.ucl_dtp_enddate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_enddate.Name = "ucl_dtp_enddate"
        Me.ucl_dtp_enddate.Size = New System.Drawing.Size(132, 26)
        Me.ucl_dtp_enddate.TabIndex = 33
        Me.ucl_dtp_enddate.uclReadOnly = False
        Me.ucl_dtp_enddate.Visible = False
        '
        'lb_enddate
        '
        Me.lb_enddate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_enddate.AutoSize = True
        Me.lb_enddate.Location = New System.Drawing.Point(543, 8)
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
        Me.ucldtp_EffectDate.Location = New System.Drawing.Point(420, 2)
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
        Me.lb_EffectDate.Location = New System.Drawing.Point(361, 8)
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
        Me.cbo_OPD.Location = New System.Drawing.Point(0, 4)
        Me.cbo_OPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_OPD.Name = "cbo_OPD"
        Me.cbo_OPD.SelectedIndex = -1
        Me.cbo_OPD.SelectedItem = Nothing
        Me.cbo_OPD.SelectedText = ""
        Me.cbo_OPD.SelectedValue = ""
        Me.cbo_OPD.SelectionStart = 0
        Me.cbo_OPD.Size = New System.Drawing.Size(123, 24)
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
        Me.cbo_EMG.Location = New System.Drawing.Point(123, 4)
        Me.cbo_EMG.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_EMG.Name = "cbo_EMG"
        Me.cbo_EMG.SelectedIndex = -1
        Me.cbo_EMG.SelectedItem = Nothing
        Me.cbo_EMG.SelectedText = ""
        Me.cbo_EMG.SelectedValue = ""
        Me.cbo_EMG.SelectionStart = 0
        Me.cbo_EMG.Size = New System.Drawing.Size(124, 24)
        Me.cbo_EMG.TabIndex = 31
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
        Me.cbo_IPD.Location = New System.Drawing.Point(247, 4)
        Me.cbo_IPD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IPD.Name = "cbo_IPD"
        Me.cbo_IPD.SelectedIndex = -1
        Me.cbo_IPD.SelectedItem = Nothing
        Me.cbo_IPD.SelectedText = ""
        Me.cbo_IPD.SelectedValue = ""
        Me.cbo_IPD.SelectionStart = 0
        Me.cbo_IPD.Size = New System.Drawing.Size(111, 24)
        Me.cbo_IPD.TabIndex = 32
        Me.cbo_IPD.uclDisplayIndex = "0,1"
        Me.cbo_IPD.uclIsAutoClear = True
        Me.cbo_IPD.uclIsFirstItemEmpty = True
        Me.cbo_IPD.uclIsTextMode = False
        Me.cbo_IPD.uclShowMsg = False
        Me.cbo_IPD.uclValueIndex = "0"
        '
        'gb_OrderPrice
        '
        Me.gb_OrderPrice.Controls.Add(Me.ucldgv_OrderPrice)
        Me.gb_OrderPrice.Controls.Add(Me.lb_Nhi_Name)
        Me.gb_OrderPrice.Controls.Add(Me.cb_pricehistory)
        Me.gb_OrderPrice.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.gb_OrderPrice.Location = New System.Drawing.Point(4, 419)
        Me.gb_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Name = "gb_OrderPrice"
        Me.gb_OrderPrice.Padding = New System.Windows.Forms.Padding(4)
        Me.gb_OrderPrice.Size = New System.Drawing.Size(976, 179)
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
        Me.ucldgv_OrderPrice.Location = New System.Drawing.Point(7, 27)
        Me.ucldgv_OrderPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.ucldgv_OrderPrice.MultiSelect = False
        Me.ucldgv_OrderPrice.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucldgv_OrderPrice.Name = "ucldgv_OrderPrice"
        Me.ucldgv_OrderPrice.RowHeadersWidth = 41
        Me.ucldgv_OrderPrice.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ucldgv_OrderPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucldgv_OrderPrice.Size = New System.Drawing.Size(959, 144)
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
        Me.ucldgv_OrderPrice.Visible = False
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
        Me.cb_pricehistory.Location = New System.Drawing.Point(113, 0)
        Me.cb_pricehistory.Name = "cb_pricehistory"
        Me.cb_pricehistory.Size = New System.Drawing.Size(107, 20)
        Me.cb_pricehistory.TabIndex = 1
        Me.cb_pricehistory.Text = "價格歷史檔"
        Me.cb_pricehistory.UseVisualStyleBackColor = True
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
        Me.tbp_btn.Location = New System.Drawing.Point(3, 605)
        Me.tbp_btn.Name = "tbp_btn"
        Me.tbp_btn.RowCount = 1
        Me.tbp_btn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbp_btn.Size = New System.Drawing.Size(978, 35)
        Me.tbp_btn.TabIndex = 3
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
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(699, 29)
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
        Me.chk_OrderHistory.Location = New System.Drawing.Point(163, 7)
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
        Me.btn_NextRecord.Location = New System.Drawing.Point(73, 5)
        Me.btn_NextRecord.Name = "btn_NextRecord"
        Me.btn_NextRecord.Size = New System.Drawing.Size(84, 25)
        Me.btn_NextRecord.TabIndex = 29
        Me.btn_NextRecord.Text = "下一筆"
        Me.btn_NextRecord.UseVisualStyleBackColor = True
        '
        'btn_PreRecord
        '
        Me.btn_PreRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_PreRecord.Location = New System.Drawing.Point(3, 5)
        Me.btn_PreRecord.Name = "btn_PreRecord"
        Me.btn_PreRecord.Size = New System.Drawing.Size(64, 25)
        Me.btn_PreRecord.TabIndex = 28
        Me.btn_PreRecord.Text = "上一筆"
        Me.btn_PreRecord.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_OrederNote)
        Me.GroupBox1.Location = New System.Drawing.Point(529, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.tlp_checkandunit.SetRowSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(436, 93)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "健保相關規定"
        '
        'txt_OrederNote
        '
        Me.txt_OrederNote.Location = New System.Drawing.Point(6, 18)
        Me.txt_OrederNote.Name = "txt_OrederNote"
        Me.txt_OrederNote.Size = New System.Drawing.Size(424, 69)
        Me.txt_OrederNote.TabIndex = 0
        Me.txt_OrederNote.Text = ""
        '
        'PUBMedicineUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 646)
        Me.Controls.Add(Me.tbp_Parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PUBMedicineUI"
        Me.TabText = "醫療支付公用主檔-藥品"
        Me.Text = "醫療支付公用主檔-藥品"
        Me.tbp_Parent.ResumeLayout(False)
        Me.gb_Condition.ResumeLayout(False)
        Me.tbp_Condition.ResumeLayout(False)
        Me.tbp_Condition.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.tbp_EffectDate.ResumeLayout(False)
        Me.tbp_EffectDate.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gb_OrderItem.ResumeLayout(False)
        Me.tbp_1.ResumeLayout(False)
        Me.tbp_1.PerformLayout()
        Me.tbp_OrderMemo.ResumeLayout(False)
        Me.tbp_OrderMemo.PerformLayout()
        Me.tbp_EnName.ResumeLayout(False)
        Me.tbp_EnName.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tbp_ZhName.ResumeLayout(False)
        Me.tbp_ZhName.PerformLayout()
        Me.tlp_checkandunit.ResumeLayout(False)
        Me.gb_unittransfer.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.tlp_chargeunit.ResumeLayout(False)
        Me.tlp_chargeunit.PerformLayout()
        Me.tlp_orderunit.ResumeLayout(False)
        Me.tlp_orderunit.PerformLayout()
        Me.tlp_transfactor.ResumeLayout(False)
        Me.tlp_transfactor.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.tlp_date.ResumeLayout(False)
        Me.tlp_date.PerformLayout()
        Me.gb_OrderPrice.ResumeLayout(False)
        Me.gb_OrderPrice.PerformLayout()
        Me.tbp_btn.ResumeLayout(False)
        Me.tbp_btn.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbp_Parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_Condition As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderItem As System.Windows.Forms.GroupBox
    Friend WithEvents gb_OrderPrice As System.Windows.Forms.GroupBox
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
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents tbp_ZhName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_EnName As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbp_OrderMemo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_OrderRemark As System.Windows.Forms.Label
    Friend WithEvents lb_Mark As System.Windows.Forms.Label
    Friend WithEvents txt_Note As System.Windows.Forms.TextBox
    Friend WithEvents txt_Flag As System.Windows.Forms.TextBox
    Friend WithEvents ucldtp_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_NhiSheet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Nhi As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
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
    Friend WithEvents uclcomb_HosItem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcomb_OrderType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents lb_OrderCode As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_NhiCode As System.Windows.Forms.TextBox
    Friend WithEvents cb_exclusivedrug As System.Windows.Forms.CheckBox
    Friend WithEvents btn_excludecharge As System.Windows.Forms.Button
    Friend WithEvents cb_nhiindex As System.Windows.Forms.CheckBox
    Friend WithEvents btn_nhiindex As System.Windows.Forms.Button
    Friend WithEvents cb_preview As System.Windows.Forms.CheckBox
    Friend WithEvents lb_specification As System.Windows.Forms.Label
    Friend WithEvents txt_specification As System.Windows.Forms.TextBox
    Friend WithEvents lb_class As System.Windows.Forms.Label
    Friend WithEvents txt_class As System.Windows.Forms.TextBox
    Friend WithEvents lb_lastpurchase As System.Windows.Forms.Label
    Friend WithEvents txt_lastpurchase As System.Windows.Forms.TextBox
    Friend WithEvents btn_PreRecord As System.Windows.Forms.Button
    Friend WithEvents btn_NextRecord As System.Windows.Forms.Button
    Friend WithEvents lb_transferfactor As System.Windows.Forms.Label
    Friend WithEvents txt_factor1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_factor5 As System.Windows.Forms.TextBox
    Friend WithEvents lb_chargeunit As System.Windows.Forms.Label
    Friend WithEvents lb_orderunit As System.Windows.Forms.Label
    Friend WithEvents txt_orderunit1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_orderunit2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_chargeunit As System.Windows.Forms.TextBox
    Friend WithEvents lb_transunit As System.Windows.Forms.Label
    Friend WithEvents lb_claimunit As System.Windows.Forms.Label
    Friend WithEvents txt_orderunit3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_orderunit4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_orderunit5 As System.Windows.Forms.TextBox
    Friend WithEvents tlp_checkandunit As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_unittransfer As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_orderunit As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_transfactor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_chargeunit As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_chargetransclainunit As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents tlp_date As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_enddate As System.Windows.Forms.Label
    Friend WithEvents cb_pricehistory As System.Windows.Forms.CheckBox
    Friend WithEvents tbp_EffectDate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_Classify As System.Windows.Forms.Label
    Friend WithEvents uclcb_classify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents PUBMedicineUI_ucl_txtcq_ordercode As UCL.UCLTextCodeQueryUI
    Friend WithEvents txt_nhiunit As System.Windows.Forms.TextBox
    Friend WithEvents lb_Nhi_Name As System.Windows.Forms.Label
    Friend WithEvents chk_OrderHistory As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_OPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_EMG As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_IPD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_IncludeOrder As System.Windows.Forms.TextBox
    Friend WithEvents btn_AddQuery As System.Windows.Forms.Button
    Private WithEvents memo_OrderMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_atccode As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tbp_btn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucldgv_OrderPrice As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lb_Majorcare As System.Windows.Forms.Label
    Friend WithEvents uclcomb_majorcare As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_dtp_enddate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents chk_IncludeOrderMark As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_OrederNote As System.Windows.Forms.RichTextBox
End Class
