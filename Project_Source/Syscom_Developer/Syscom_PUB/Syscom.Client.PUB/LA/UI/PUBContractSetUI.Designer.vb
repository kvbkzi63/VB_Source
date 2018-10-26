<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBContractSetUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBContractSetUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelNoButton = New System.Windows.Forms.Panel()
        Me.tlpNoButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.tcqOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.cmbAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblAccountId = New System.Windows.Forms.Label()
        Me.cmbOrderTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblOrderTypeId = New System.Windows.Forms.Label()
        Me.lblDiscountRatio = New System.Windows.Forms.Label()
        Me.lblKeepAccountRatio = New System.Windows.Forms.Label()
        Me.txtKeepAccountRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblDiscountRatioDemo = New System.Windows.Forms.Label()
        Me.lblKeepAccountRatioDemo = New System.Windows.Forms.Label()
        Me.lblPayselfAmt = New System.Windows.Forms.Label()
        Me.txtPayselfAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblKeepAccountAmt = New System.Windows.Forms.Label()
        Me.txtKeepAccountAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDiscountRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblContractCode = New System.Windows.Forms.Label()
        Me.cmbContractCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.panelNoButton.SuspendLayout()
        Me.tlpNoButton.SuspendLayout()
        Me.btnFlowLayoutPanel.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelNoButton
        '
        Me.panelNoButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelNoButton.Controls.Add(Me.tlpNoButton)
        Me.panelNoButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelNoButton.Location = New System.Drawing.Point(0, 0)
        Me.panelNoButton.Name = "panelNoButton"
        Me.panelNoButton.Size = New System.Drawing.Size(985, 179)
        Me.panelNoButton.TabIndex = 0
        '
        'tlpNoButton
        '
        Me.tlpNoButton.ColumnCount = 6
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.80597!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.19403!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141.0!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211.0!))
        Me.tlpNoButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlpNoButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlpNoButton.Controls.Add(Me.tcqOrderCode, 5, 1)
        Me.tlpNoButton.Controls.Add(Me.lblOrderCode, 4, 1)
        Me.tlpNoButton.Controls.Add(Me.cmbAccountId, 3, 1)
        Me.tlpNoButton.Controls.Add(Me.lblAccountId, 2, 1)
        Me.tlpNoButton.Controls.Add(Me.cmbOrderTypeId, 1, 1)
        Me.tlpNoButton.Controls.Add(Me.lblOrderTypeId, 0, 1)
        Me.tlpNoButton.Controls.Add(Me.lblDiscountRatio, 0, 2)
        Me.tlpNoButton.Controls.Add(Me.lblKeepAccountRatio, 0, 3)
        Me.tlpNoButton.Controls.Add(Me.txtKeepAccountRatio, 1, 3)
        Me.tlpNoButton.Controls.Add(Me.lblEndDate, 0, 4)
        Me.tlpNoButton.Controls.Add(Me.dtpEndDate, 1, 4)
        Me.tlpNoButton.Controls.Add(Me.lblDiscountRatioDemo, 2, 2)
        Me.tlpNoButton.Controls.Add(Me.lblKeepAccountRatioDemo, 2, 3)
        Me.tlpNoButton.Controls.Add(Me.lblPayselfAmt, 4, 2)
        Me.tlpNoButton.Controls.Add(Me.txtPayselfAmt, 5, 2)
        Me.tlpNoButton.Controls.Add(Me.lblKeepAccountAmt, 4, 3)
        Me.tlpNoButton.Controls.Add(Me.txtKeepAccountAmt, 5, 3)
        Me.tlpNoButton.Controls.Add(Me.txtDiscountRatio, 1, 2)
        Me.tlpNoButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlpNoButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlpNoButton.Controls.Add(Me.lblContractCode, 4, 0)
        Me.tlpNoButton.Controls.Add(Me.cmbContractCode, 5, 0)
        Me.tlpNoButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNoButton.Location = New System.Drawing.Point(0, 0)
        Me.tlpNoButton.Name = "tlpNoButton"
        Me.tlpNoButton.RowCount = 5
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpNoButton.Size = New System.Drawing.Size(983, 177)
        Me.tlpNoButton.TabIndex = 0
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(58, 10)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEffectDate.TabIndex = 0
        Me.lblEffectDate.Text = "*生效日"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(128, 4)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(175, 27)
        Me.dtpEffectDate.TabIndex = 1
        Me.dtpEffectDate.uclReadOnly = False
        '
        'tcqOrderCode
        '
        Me.tcqOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcqOrderCode.doFlag = True
        Me.tcqOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcqOrderCode.Location = New System.Drawing.Point(771, 41)
        Me.tcqOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcqOrderCode.Name = "tcqOrderCode"
        Me.tcqOrderCode.Size = New System.Drawing.Size(179, 26)
        Me.tcqOrderCode.TabIndex = 11
        Me.tcqOrderCode.uclBaseDate = "2015/05/01"
        Me.tcqOrderCode.uclCboWidth = 143
        Me.tcqOrderCode.uclCodeName = ""
        Me.tcqOrderCode.uclCodeValue1 = ""
        Me.tcqOrderCode.uclCodeValue2 = ""
        Me.tcqOrderCode.uclControlFlag = True
        Me.tcqOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcqOrderCode.uclDisplayIndex = "0,1"
        Me.tcqOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcqOrderCode.uclIsAutoAddZero = False
        Me.tcqOrderCode.uclIsCheckDoctorOnDuty = False
        Me.tcqOrderCode.uclIsReturnDS = False
        Me.tcqOrderCode.uclIsShowMsgBox = True
        Me.tcqOrderCode.uclIsTextAutoClear = True
        Me.tcqOrderCode.uclMsgValue = Nothing
        Me.tcqOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcqOrderCode.uclQueryField = Nothing
        Me.tcqOrderCode.uclQueryValue = Nothing
        Me.tcqOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcqOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.tcqOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcqOrderCode.uclTotalWidth = 8
        Me.tcqOrderCode.uclXPosition = 225
        Me.tcqOrderCode.uclYPosition = 120
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(704, 46)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(64, 16)
        Me.lblOrderCode.TabIndex = 10
        Me.lblOrderCode.Text = "*批價碼"
        '
        'cmbAccountId
        '
        Me.cmbAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAccountId.DropDownWidth = 20
        Me.cmbAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAccountId.Location = New System.Drawing.Point(468, 42)
        Me.cmbAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAccountId.Name = "cmbAccountId"
        Me.cmbAccountId.SelectedIndex = -1
        Me.cmbAccountId.SelectedItem = Nothing
        Me.cmbAccountId.SelectedText = ""
        Me.cmbAccountId.SelectedValue = ""
        Me.cmbAccountId.SelectionStart = 0
        Me.cmbAccountId.Size = New System.Drawing.Size(175, 24)
        Me.cmbAccountId.TabIndex = 9
        Me.cmbAccountId.uclDisplayIndex = "0,1"
        Me.cmbAccountId.uclIsAutoClear = True
        Me.cmbAccountId.uclIsFirstItemEmpty = True
        Me.cmbAccountId.uclIsTextMode = False
        Me.cmbAccountId.uclShowMsg = False
        Me.cmbAccountId.uclValueIndex = "0"
        '
        'lblAccountId
        '
        Me.lblAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAccountId.AutoSize = True
        Me.lblAccountId.ForeColor = System.Drawing.Color.Red
        Me.lblAccountId.Location = New System.Drawing.Point(349, 46)
        Me.lblAccountId.Name = "lblAccountId"
        Me.lblAccountId.Size = New System.Drawing.Size(112, 16)
        Me.lblAccountId.TabIndex = 8
        Me.lblAccountId.Text = "*院內費用項目"
        '
        'cmbOrderTypeId
        '
        Me.cmbOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbOrderTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbOrderTypeId.DropDownWidth = 20
        Me.cmbOrderTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbOrderTypeId.Location = New System.Drawing.Point(129, 42)
        Me.cmbOrderTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOrderTypeId.Name = "cmbOrderTypeId"
        Me.cmbOrderTypeId.SelectedIndex = -1
        Me.cmbOrderTypeId.SelectedItem = Nothing
        Me.cmbOrderTypeId.SelectedText = ""
        Me.cmbOrderTypeId.SelectedValue = ""
        Me.cmbOrderTypeId.SelectionStart = 0
        Me.cmbOrderTypeId.Size = New System.Drawing.Size(175, 24)
        Me.cmbOrderTypeId.TabIndex = 7
        Me.cmbOrderTypeId.uclDisplayIndex = "0,1"
        Me.cmbOrderTypeId.uclIsAutoClear = True
        Me.cmbOrderTypeId.uclIsFirstItemEmpty = True
        Me.cmbOrderTypeId.uclIsTextMode = False
        Me.cmbOrderTypeId.uclShowMsg = False
        Me.cmbOrderTypeId.uclValueIndex = "0"
        '
        'lblOrderTypeId
        '
        Me.lblOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderTypeId.AutoSize = True
        Me.lblOrderTypeId.ForeColor = System.Drawing.Color.Red
        Me.lblOrderTypeId.Location = New System.Drawing.Point(42, 46)
        Me.lblOrderTypeId.Name = "lblOrderTypeId"
        Me.lblOrderTypeId.Size = New System.Drawing.Size(80, 16)
        Me.lblOrderTypeId.TabIndex = 6
        Me.lblOrderTypeId.Text = "*醫令類型"
        '
        'lblDiscountRatio
        '
        Me.lblDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDiscountRatio.AutoSize = True
        Me.lblDiscountRatio.Location = New System.Drawing.Point(66, 82)
        Me.lblDiscountRatio.Name = "lblDiscountRatio"
        Me.lblDiscountRatio.Size = New System.Drawing.Size(56, 16)
        Me.lblDiscountRatio.TabIndex = 12
        Me.lblDiscountRatio.Text = "折扣率"
        '
        'lblKeepAccountRatio
        '
        Me.lblKeepAccountRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKeepAccountRatio.AutoSize = True
        Me.lblKeepAccountRatio.Location = New System.Drawing.Point(50, 118)
        Me.lblKeepAccountRatio.Name = "lblKeepAccountRatio"
        Me.lblKeepAccountRatio.Size = New System.Drawing.Size(72, 16)
        Me.lblKeepAccountRatio.TabIndex = 17
        Me.lblKeepAccountRatio.Text = "請款比率"
        '
        'txtKeepAccountRatio
        '
        Me.txtKeepAccountRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKeepAccountRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKeepAccountRatio.Location = New System.Drawing.Point(129, 112)
        Me.txtKeepAccountRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeepAccountRatio.MaxLength = 10
        Me.txtKeepAccountRatio.Name = "txtKeepAccountRatio"
        Me.txtKeepAccountRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKeepAccountRatio.SelectionStart = 0
        Me.txtKeepAccountRatio.Size = New System.Drawing.Size(174, 27)
        Me.txtKeepAccountRatio.TabIndex = 18
        Me.txtKeepAccountRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKeepAccountRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKeepAccountRatio.uclDollarSign = False
        Me.txtKeepAccountRatio.uclDotCount = 2
        Me.txtKeepAccountRatio.uclIntCount = 1
        Me.txtKeepAccountRatio.uclMinus = False
        Me.txtKeepAccountRatio.uclReadOnly = False
        Me.txtKeepAccountRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKeepAccountRatio.uclTrimZero = True
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(66, 152)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 22
        Me.lblEndDate.Text = "停止日"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(128, 147)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(176, 27)
        Me.dtpEndDate.TabIndex = 23
        Me.dtpEndDate.uclReadOnly = False
        '
        'lblDiscountRatioDemo
        '
        Me.lblDiscountRatioDemo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDiscountRatioDemo.AutoSize = True
        Me.tlpNoButton.SetColumnSpan(Me.lblDiscountRatioDemo, 2)
        Me.lblDiscountRatioDemo.Location = New System.Drawing.Point(326, 82)
        Me.lblDiscountRatioDemo.Name = "lblDiscountRatioDemo"
        Me.lblDiscountRatioDemo.Size = New System.Drawing.Size(256, 16)
        Me.lblDiscountRatioDemo.TabIndex = 14
        Me.lblDiscountRatioDemo.Text = "(0.8表示折扣20%；0表示折扣100%)"
        '
        'lblKeepAccountRatioDemo
        '
        Me.lblKeepAccountRatioDemo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblKeepAccountRatioDemo.AutoSize = True
        Me.tlpNoButton.SetColumnSpan(Me.lblKeepAccountRatioDemo, 2)
        Me.lblKeepAccountRatioDemo.Location = New System.Drawing.Point(326, 118)
        Me.lblKeepAccountRatioDemo.Name = "lblKeepAccountRatioDemo"
        Me.lblKeepAccountRatioDemo.Size = New System.Drawing.Size(256, 16)
        Me.lblKeepAccountRatioDemo.TabIndex = 19
        Me.lblKeepAccountRatioDemo.Text = "(0.7表示請款70%；1表示請款100%)"
        '
        'lblPayselfAmt
        '
        Me.lblPayselfAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPayselfAmt.AutoSize = True
        Me.lblPayselfAmt.Location = New System.Drawing.Point(696, 82)
        Me.lblPayselfAmt.Name = "lblPayselfAmt"
        Me.lblPayselfAmt.Size = New System.Drawing.Size(72, 16)
        Me.lblPayselfAmt.TabIndex = 15
        Me.lblPayselfAmt.Text = "自付金額"
        '
        'txtPayselfAmt
        '
        Me.txtPayselfAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPayselfAmt.Enabled = False
        Me.txtPayselfAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPayselfAmt.Location = New System.Drawing.Point(775, 76)
        Me.txtPayselfAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPayselfAmt.MaxLength = 19
        Me.txtPayselfAmt.Name = "txtPayselfAmt"
        Me.txtPayselfAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPayselfAmt.SelectionStart = 0
        Me.txtPayselfAmt.Size = New System.Drawing.Size(175, 27)
        Me.txtPayselfAmt.TabIndex = 16
        Me.txtPayselfAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPayselfAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPayselfAmt.uclDollarSign = False
        Me.txtPayselfAmt.uclDotCount = 1
        Me.txtPayselfAmt.uclIntCount = 17
        Me.txtPayselfAmt.uclMinus = False
        Me.txtPayselfAmt.uclReadOnly = False
        Me.txtPayselfAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPayselfAmt.uclTrimZero = True
        '
        'lblKeepAccountAmt
        '
        Me.lblKeepAccountAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKeepAccountAmt.AutoSize = True
        Me.lblKeepAccountAmt.Location = New System.Drawing.Point(696, 118)
        Me.lblKeepAccountAmt.Name = "lblKeepAccountAmt"
        Me.lblKeepAccountAmt.Size = New System.Drawing.Size(72, 16)
        Me.lblKeepAccountAmt.TabIndex = 20
        Me.lblKeepAccountAmt.Text = "請款定額"
        '
        'txtKeepAccountAmt
        '
        Me.txtKeepAccountAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKeepAccountAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKeepAccountAmt.Location = New System.Drawing.Point(775, 112)
        Me.txtKeepAccountAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeepAccountAmt.MaxLength = 10
        Me.txtKeepAccountAmt.Name = "txtKeepAccountAmt"
        Me.txtKeepAccountAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKeepAccountAmt.SelectionStart = 0
        Me.txtKeepAccountAmt.Size = New System.Drawing.Size(175, 27)
        Me.txtKeepAccountAmt.TabIndex = 21
        Me.txtKeepAccountAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKeepAccountAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKeepAccountAmt.uclDollarSign = False
        Me.txtKeepAccountAmt.uclDotCount = 1
        Me.txtKeepAccountAmt.uclIntCount = 17
        Me.txtKeepAccountAmt.uclMinus = False
        Me.txtKeepAccountAmt.uclReadOnly = False
        Me.txtKeepAccountAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKeepAccountAmt.uclTrimZero = True
        '
        'txtDiscountRatio
        '
        Me.txtDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDiscountRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDiscountRatio.Location = New System.Drawing.Point(129, 76)
        Me.txtDiscountRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscountRatio.MaxLength = 19
        Me.txtDiscountRatio.Name = "txtDiscountRatio"
        Me.txtDiscountRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiscountRatio.SelectionStart = 0
        Me.txtDiscountRatio.Size = New System.Drawing.Size(174, 27)
        Me.txtDiscountRatio.TabIndex = 13
        Me.txtDiscountRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDiscountRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDiscountRatio.uclDollarSign = False
        Me.txtDiscountRatio.uclDotCount = 4
        Me.txtDiscountRatio.uclIntCount = 1
        Me.txtDiscountRatio.uclMinus = False
        Me.txtDiscountRatio.uclReadOnly = False
        Me.txtDiscountRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtDiscountRatio.uclTrimZero = True
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(373, 10)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(88, 16)
        Me.lblSubIdentityCode.TabIndex = 2
        Me.lblSubIdentityCode.Text = "身份二代碼"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(468, 6)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(175, 24)
        Me.cmbSubIdentityCode.TabIndex = 3
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'lblContractCode
        '
        Me.lblContractCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblContractCode.AutoSize = True
        Me.lblContractCode.ForeColor = System.Drawing.Color.Red
        Me.lblContractCode.Location = New System.Drawing.Point(656, 10)
        Me.lblContractCode.Name = "lblContractCode"
        Me.lblContractCode.Size = New System.Drawing.Size(112, 16)
        Me.lblContractCode.TabIndex = 4
        Me.lblContractCode.Text = "*合約機關代碼"
        '
        'cmbContractCode
        '
        Me.cmbContractCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbContractCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbContractCode.DropDownWidth = 20
        Me.cmbContractCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbContractCode.Location = New System.Drawing.Point(775, 6)
        Me.cmbContractCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbContractCode.Name = "cmbContractCode"
        Me.cmbContractCode.SelectedIndex = -1
        Me.cmbContractCode.SelectedItem = Nothing
        Me.cmbContractCode.SelectedText = ""
        Me.cmbContractCode.SelectedValue = ""
        Me.cmbContractCode.SelectionStart = 0
        Me.cmbContractCode.Size = New System.Drawing.Size(175, 24)
        Me.cmbContractCode.TabIndex = 5
        Me.cmbContractCode.uclDisplayIndex = "0,1"
        Me.cmbContractCode.uclIsAutoClear = True
        Me.cmbContractCode.uclIsFirstItemEmpty = True
        Me.cmbContractCode.uclIsTextMode = False
        Me.cmbContractCode.uclShowMsg = False
        Me.cmbContractCode.uclValueIndex = "0"
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnOK)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(0, 179)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(985, 35)
        Me.btnFlowLayoutPanel.TabIndex = 25
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(892, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 26
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(796, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 25
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(700, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.AllowUserToDeleteRows = False
        Me.dgvShowData.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShowData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShowData.Location = New System.Drawing.Point(0, 214)
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.ReadOnly = True
        Me.dgvShowData.RowHeadersVisible = False
        Me.dgvShowData.RowTemplate.Height = 24
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(985, 266)
        Me.dgvShowData.TabIndex = 99
        '
        'PUBContractSetUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.dgvShowData)
        Me.Controls.Add(Me.btnFlowLayoutPanel)
        Me.Controls.Add(Me.panelNoButton)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBContractSetUI"
        Me.TabText = "合約身份折扣記帳設定檔維護"
        Me.Text = "合約身份折扣記帳設定檔維護"
        Me.panelNoButton.ResumeLayout(False)
        Me.tlpNoButton.ResumeLayout(False)
        Me.tlpNoButton.PerformLayout()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelNoButton As System.Windows.Forms.Panel
    Friend WithEvents tlpNoButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblContractCode As System.Windows.Forms.Label
    Friend WithEvents cmbContractCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblOrderTypeId As System.Windows.Forms.Label
    Friend WithEvents cmbOrderTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblAccountId As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents tcqOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cmbAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblDiscountRatio As System.Windows.Forms.Label
    Friend WithEvents txtDiscountRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDiscountRatioDemo As System.Windows.Forms.Label
    Friend WithEvents lblPayselfAmt As System.Windows.Forms.Label
    Friend WithEvents txtPayselfAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblKeepAccountRatio As System.Windows.Forms.Label
    Friend WithEvents txtKeepAccountRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblKeepAccountRatioDemo As System.Windows.Forms.Label
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblKeepAccountAmt As System.Windows.Forms.Label
    Friend WithEvents txtKeepAccountAmt As Syscom.Client.UCL.UCLTextBoxUC
End Class
