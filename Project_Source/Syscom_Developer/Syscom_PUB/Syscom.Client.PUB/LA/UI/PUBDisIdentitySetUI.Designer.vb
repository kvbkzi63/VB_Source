<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBDisIdentitySetUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBDisIdentitySetUI))
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_output = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.lblDisIdentityCode = New System.Windows.Forms.Label()
        Me.cmbDisIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblOrderTypeId = New System.Windows.Forms.Label()
        Me.lblAccountId = New System.Windows.Forms.Label()
        Me.cmbAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbOrderTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblDiscountRatio = New System.Windows.Forms.Label()
        Me.txtDiscountRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblContent = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Controls.Add(Me.dgvPanel)
        Me.IUCLMaintainPanel.Controls.Add(Me.btnFlowLayoutPanel)
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(3, 137)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1006, 384)
        Me.IUCLMaintainPanel.TabIndex = 5
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 42)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(1004, 341)
        Me.dgvPanel.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.AllowUserToDeleteRows = False
        Me.dgvShowData.AllowUserToOrderColumns = True
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
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
        Me.dgvShowData.Location = New System.Drawing.Point(0, 0)
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.ReadOnly = True
        Me.dgvShowData.RowHeadersVisible = False
        Me.dgvShowData.RowTemplate.Height = 24
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(1004, 341)
        Me.dgvShowData.TabIndex = 99
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btn_output)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnOK)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(1, 1)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(1004, 41)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btn_output
        '
        Me.btn_output.Location = New System.Drawing.Point(911, 3)
        Me.btn_output.Name = "btn_output"
        Me.btn_output.Size = New System.Drawing.Size(90, 28)
        Me.btn_output.TabIndex = 11
        Me.btn_output.Text = "F7-匯出"
        Me.btn_output.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(815, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(719, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 9
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(623, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(405, 9)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(127, 24)
        Me.cmbSubIdentityCode.TabIndex = 11
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(1009, 135)
        Me.pal_Mantain.TabIndex = 0
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 12
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDisIdentityCode, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbDisIdentityCode, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblOrderTypeId, 6, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblAccountId, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbAccountId, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbOrderTypeId, 7, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDiscountRatio, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.txtDiscountRatio, 1, 2)
        Me.tlp_nonButton.Controls.Add(Me.lblContent, 2, 2)
        Me.tlp_nonButton.Controls.Add(Me.lblOrderCode, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtOrderCode, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 5, 1)
        Me.tlp_nonButton.Location = New System.Drawing.Point(3, 3)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 3
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.43307!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.49606!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1005, 127)
        Me.tlp_nonButton.TabIndex = 2
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(51, 13)
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
        Me.dtpEffectDate.Location = New System.Drawing.Point(121, 7)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(158, 27)
        Me.dtpEffectDate.TabIndex = 1
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(302, 13)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 22
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'lblDisIdentityCode
        '
        Me.lblDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDisIdentityCode.AutoSize = True
        Me.lblDisIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblDisIdentityCode.Location = New System.Drawing.Point(539, 13)
        Me.lblDisIdentityCode.Name = "lblDisIdentityCode"
        Me.lblDisIdentityCode.Size = New System.Drawing.Size(112, 16)
        Me.lblDisIdentityCode.TabIndex = 17
        Me.lblDisIdentityCode.Text = "*優待身份代碼"
        '
        'cmbDisIdentityCode
        '
        Me.cmbDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbDisIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbDisIdentityCode.DropDownWidth = 20
        Me.cmbDisIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbDisIdentityCode.Location = New System.Drawing.Point(658, 9)
        Me.cmbDisIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDisIdentityCode.Name = "cmbDisIdentityCode"
        Me.cmbDisIdentityCode.SelectedIndex = -1
        Me.cmbDisIdentityCode.SelectedItem = Nothing
        Me.cmbDisIdentityCode.SelectedText = ""
        Me.cmbDisIdentityCode.SelectedValue = ""
        Me.cmbDisIdentityCode.SelectionStart = 0
        Me.cmbDisIdentityCode.Size = New System.Drawing.Size(127, 24)
        Me.cmbDisIdentityCode.TabIndex = 2
        Me.cmbDisIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbDisIdentityCode.uclIsAutoClear = True
        Me.cmbDisIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbDisIdentityCode.uclIsTextMode = False
        Me.cmbDisIdentityCode.uclShowMsg = False
        Me.cmbDisIdentityCode.uclValueIndex = "0"
        '
        'lblOrderTypeId
        '
        Me.lblOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderTypeId.AutoSize = True
        Me.lblOrderTypeId.ForeColor = System.Drawing.Color.Red
        Me.lblOrderTypeId.Location = New System.Drawing.Point(792, 13)
        Me.lblOrderTypeId.Name = "lblOrderTypeId"
        Me.lblOrderTypeId.Size = New System.Drawing.Size(80, 16)
        Me.lblOrderTypeId.TabIndex = 12
        Me.lblOrderTypeId.Text = "*醫令類型"
        '
        'lblAccountId
        '
        Me.lblAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAccountId.AutoSize = True
        Me.lblAccountId.ForeColor = System.Drawing.Color.Red
        Me.lblAccountId.Location = New System.Drawing.Point(3, 56)
        Me.lblAccountId.Name = "lblAccountId"
        Me.lblAccountId.Size = New System.Drawing.Size(112, 16)
        Me.lblAccountId.TabIndex = 14
        Me.lblAccountId.Text = "*院內費用項目"
        '
        'cmbAccountId
        '
        Me.cmbAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAccountId.DropDownWidth = 20
        Me.cmbAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAccountId.Location = New System.Drawing.Point(122, 52)
        Me.cmbAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAccountId.Name = "cmbAccountId"
        Me.cmbAccountId.SelectedIndex = -1
        Me.cmbAccountId.SelectedItem = Nothing
        Me.cmbAccountId.SelectedText = ""
        Me.cmbAccountId.SelectedValue = ""
        Me.cmbAccountId.SelectionStart = 0
        Me.cmbAccountId.Size = New System.Drawing.Size(157, 24)
        Me.cmbAccountId.TabIndex = 4
        Me.cmbAccountId.uclDisplayIndex = "0,1"
        Me.cmbAccountId.uclIsAutoClear = True
        Me.cmbAccountId.uclIsFirstItemEmpty = True
        Me.cmbAccountId.uclIsTextMode = False
        Me.cmbAccountId.uclShowMsg = False
        Me.cmbAccountId.uclValueIndex = "0"
        '
        'cmbOrderTypeId
        '
        Me.cmbOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbOrderTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbOrderTypeId.DropDownWidth = 20
        Me.cmbOrderTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbOrderTypeId.Location = New System.Drawing.Point(879, 9)
        Me.cmbOrderTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOrderTypeId.Name = "cmbOrderTypeId"
        Me.cmbOrderTypeId.SelectedIndex = -1
        Me.cmbOrderTypeId.SelectedItem = Nothing
        Me.cmbOrderTypeId.SelectedText = ""
        Me.cmbOrderTypeId.SelectedValue = ""
        Me.cmbOrderTypeId.SelectionStart = 0
        Me.cmbOrderTypeId.Size = New System.Drawing.Size(123, 24)
        Me.cmbOrderTypeId.TabIndex = 3
        Me.cmbOrderTypeId.uclDisplayIndex = "0,1"
        Me.cmbOrderTypeId.uclIsAutoClear = True
        Me.cmbOrderTypeId.uclIsFirstItemEmpty = True
        Me.cmbOrderTypeId.uclIsTextMode = False
        Me.cmbOrderTypeId.uclShowMsg = False
        Me.cmbOrderTypeId.uclValueIndex = "0"
        '
        'lblDiscountRatio
        '
        Me.lblDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDiscountRatio.AutoSize = True
        Me.lblDiscountRatio.Location = New System.Drawing.Point(59, 98)
        Me.lblDiscountRatio.Name = "lblDiscountRatio"
        Me.lblDiscountRatio.Size = New System.Drawing.Size(56, 16)
        Me.lblDiscountRatio.TabIndex = 9
        Me.lblDiscountRatio.Text = "折扣率"
        '
        'txtDiscountRatio
        '
        Me.txtDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDiscountRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDiscountRatio.Location = New System.Drawing.Point(122, 93)
        Me.txtDiscountRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscountRatio.MaxLength = 19
        Me.txtDiscountRatio.Name = "txtDiscountRatio"
        Me.txtDiscountRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiscountRatio.SelectionStart = 0
        Me.txtDiscountRatio.Size = New System.Drawing.Size(157, 27)
        Me.txtDiscountRatio.TabIndex = 7
        Me.txtDiscountRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDiscountRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDiscountRatio.ToolTipTag = Nothing
        Me.txtDiscountRatio.uclDollarSign = False
        Me.txtDiscountRatio.uclDotCount = 4
        Me.txtDiscountRatio.uclIntCount = 14
        Me.txtDiscountRatio.uclMinus = False
        Me.txtDiscountRatio.uclReadOnly = False
        Me.txtDiscountRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtDiscountRatio.uclTrimZero = True
        '
        'lblContent
        '
        Me.lblContent.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblContent.AutoSize = True
        Me.tlp_nonButton.SetColumnSpan(Me.lblContent, 3)
        Me.lblContent.Location = New System.Drawing.Point(286, 98)
        Me.lblContent.Name = "lblContent"
        Me.lblContent.Size = New System.Drawing.Size(326, 16)
        Me.lblContent.TabIndex = 21
        Me.lblContent.Text = "0.8表示折扣20%,0表示折扣100%,1表示不折扣"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(286, 56)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(112, 16)
        Me.lblOrderCode.TabIndex = 16
        Me.lblOrderCode.Text = "*醫令項目代碼"
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(401, 51)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(131, 26)
        Me.txtOrderCode.TabIndex = 6
        Me.txtOrderCode.uclBaseDate = "2015/05/01"
        Me.txtOrderCode.uclCboWidth = 95
        Me.txtOrderCode.uclCodeName = ""
        Me.txtOrderCode.uclCodeName1 = ""
        Me.txtOrderCode.uclCodeName2 = ""
        Me.txtOrderCode.uclCodeValue = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.uclCodeValue2 = ""
        Me.txtOrderCode.uclControlFlag = True
        Me.txtOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtOrderCode.uclDisplayIndex = "0,1"
        Me.txtOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtOrderCode.uclIsAutoAddZero = False
        Me.txtOrderCode.uclIsBtnVisible = True
        Me.txtOrderCode.uclIsCheckDoctorOnDuty = False
        Me.txtOrderCode.uclIsEnglishDept = False
        Me.txtOrderCode.uclIsReturnDS = False
        Me.txtOrderCode.uclIsShowMsgBox = True
        Me.txtOrderCode.uclIsTextAutoClear = True
        Me.txtOrderCode.uclLabel = ""
        Me.txtOrderCode.uclMsgValue = Nothing
        Me.txtOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtOrderCode.uclQueryField = Nothing
        Me.txtOrderCode.uclQueryValue = Nothing
        Me.txtOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.txtOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txtOrderCode.uclTotalWidth = 8
        Me.txtOrderCode.uclXPosition = 225
        Me.txtOrderCode.uclYPosition = 120
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(595, 56)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 9
        Me.lblEndDate.Text = "停止日"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(657, 50)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(128, 27)
        Me.dtpEndDate.TabIndex = 5
        Me.dtpEndDate.uclReadOnly = False
        '
        'PUBDisIdentitySetUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 520)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBDisIdentitySetUI"
        Me.ShowIcon = False
        Me.TabText = "優待身份折扣設定檔維護"
        Me.Text = "優待身份折扣設定檔維護"
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.pal_Mantain.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pal_Mantain As System.Windows.Forms.Panel
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents IUCLMaintainPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvPanel As System.Windows.Forms.Panel
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cmbDisIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblOrderTypeId As System.Windows.Forms.Label
    Friend WithEvents lblAccountId As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lblDisIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbOrderTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lblDiscountRatio As System.Windows.Forms.Label
    Friend WithEvents txtDiscountRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblContent As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents btn_output As System.Windows.Forms.Button
End Class
