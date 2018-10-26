<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSubIdentitySetUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSubIdentitySetUI))
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rboOrderTypeId = New System.Windows.Forms.RadioButton()
        Me.cmbOrderTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rboAccountId = New System.Windows.Forms.RadioButton()
        Me.rboOrderCode = New System.Windows.Forms.RadioButton()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblMainIdentityId = New System.Windows.Forms.Label()
        Me.cmbMainIdentityId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.btnFlowLayoutPanel.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dgvPanel.SuspendLayout()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(363, 10)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 2
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnOK)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(1, 1)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(983, 35)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(890, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(794, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 11
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(698, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(47, 10)
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
        Me.dtpEffectDate.Location = New System.Drawing.Point(118, 5)
        Me.dtpEffectDate.Margin = New System.Windows.Forms.Padding(4, 3, 3, 3)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(146, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(403, 84)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 9
        Me.lblEndDate.Text = "結束日"
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
        Me.dgvShowData.Size = New System.Drawing.Size(983, 331)
        Me.dgvShowData.TabIndex = 99
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(466, 79)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(4, 3, 3, 3)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(152, 27)
        Me.dtpEndDate.TabIndex = 9
        Me.dtpEndDate.uclReadOnly = False
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(983, 331)
        Me.dgvPanel.TabIndex = 99
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Controls.Add(Me.dgvPanel)
        Me.IUCLMaintainPanel.Controls.Add(Me.btnFlowLayoutPanel)
        Me.IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 112)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 368)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 6
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.rboOrderTypeId, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbOrderTypeId, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbAccountId, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.rboAccountId, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.rboOrderCode, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtOrderCode, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 2, 2)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 3, 2)
        Me.tlp_nonButton.Controls.Add(Me.lblMainIdentityId, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.cmbMainIdentityId, 1, 2)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 3
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(983, 111)
        Me.tlp_nonButton.TabIndex = 0
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(466, 6)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(200, 24)
        Me.cmbSubIdentityCode.TabIndex = 1
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'rboOrderTypeId
        '
        Me.rboOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rboOrderTypeId.AutoSize = True
        Me.rboOrderTypeId.ForeColor = System.Drawing.Color.Red
        Me.rboOrderTypeId.Location = New System.Drawing.Point(13, 45)
        Me.rboOrderTypeId.Name = "rboOrderTypeId"
        Me.rboOrderTypeId.Size = New System.Drawing.Size(98, 20)
        Me.rboOrderTypeId.TabIndex = 2
        Me.rboOrderTypeId.TabStop = True
        Me.rboOrderTypeId.Text = "*醫令類型"
        Me.rboOrderTypeId.UseVisualStyleBackColor = True
        '
        'cmbOrderTypeId
        '
        Me.cmbOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbOrderTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbOrderTypeId.DropDownWidth = 20
        Me.cmbOrderTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbOrderTypeId.Location = New System.Drawing.Point(118, 43)
        Me.cmbOrderTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOrderTypeId.Name = "cmbOrderTypeId"
        Me.cmbOrderTypeId.SelectedIndex = -1
        Me.cmbOrderTypeId.SelectedItem = Nothing
        Me.cmbOrderTypeId.SelectedText = ""
        Me.cmbOrderTypeId.SelectedValue = ""
        Me.cmbOrderTypeId.SelectionStart = 0
        Me.cmbOrderTypeId.Size = New System.Drawing.Size(200, 24)
        Me.cmbOrderTypeId.TabIndex = 3
        Me.cmbOrderTypeId.uclDisplayIndex = "0,1"
        Me.cmbOrderTypeId.uclIsAutoClear = True
        Me.cmbOrderTypeId.uclIsFirstItemEmpty = True
        Me.cmbOrderTypeId.uclIsTextMode = False
        Me.cmbOrderTypeId.uclShowMsg = False
        Me.cmbOrderTypeId.uclValueIndex = "0"
        '
        'cmbAccountId
        '
        Me.cmbAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAccountId.DropDownWidth = 20
        Me.cmbAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAccountId.Location = New System.Drawing.Point(466, 43)
        Me.cmbAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAccountId.Name = "cmbAccountId"
        Me.cmbAccountId.SelectedIndex = -1
        Me.cmbAccountId.SelectedItem = Nothing
        Me.cmbAccountId.SelectedText = ""
        Me.cmbAccountId.SelectedValue = ""
        Me.cmbAccountId.SelectionStart = 0
        Me.cmbAccountId.Size = New System.Drawing.Size(200, 24)
        Me.cmbAccountId.TabIndex = 5
        Me.cmbAccountId.uclDisplayIndex = "0,1"
        Me.cmbAccountId.uclIsAutoClear = True
        Me.cmbAccountId.uclIsFirstItemEmpty = True
        Me.cmbAccountId.uclIsTextMode = False
        Me.cmbAccountId.uclShowMsg = False
        Me.cmbAccountId.uclValueIndex = "0"
        '
        'rboAccountId
        '
        Me.rboAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rboAccountId.AutoSize = True
        Me.rboAccountId.ForeColor = System.Drawing.Color.Red
        Me.rboAccountId.Location = New System.Drawing.Point(329, 45)
        Me.rboAccountId.Name = "rboAccountId"
        Me.rboAccountId.Size = New System.Drawing.Size(130, 20)
        Me.rboAccountId.TabIndex = 4
        Me.rboAccountId.TabStop = True
        Me.rboAccountId.Text = "*院內費用項目"
        Me.rboAccountId.UseVisualStyleBackColor = True
        '
        'rboOrderCode
        '
        Me.rboOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rboOrderCode.AutoSize = True
        Me.rboOrderCode.ForeColor = System.Drawing.Color.Red
        Me.rboOrderCode.Location = New System.Drawing.Point(675, 45)
        Me.rboOrderCode.Name = "rboOrderCode"
        Me.rboOrderCode.Size = New System.Drawing.Size(130, 20)
        Me.rboOrderCode.TabIndex = 6
        Me.rboOrderCode.TabStop = True
        Me.rboOrderCode.Text = "*醫令項目代碼"
        Me.rboOrderCode.UseVisualStyleBackColor = True
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(812, 42)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(162, 26)
        Me.txtOrderCode.TabIndex = 7
        Me.txtOrderCode.uclBaseDate = "2015/05/01"
        Me.txtOrderCode.uclCboWidth = 126
        Me.txtOrderCode.uclCodeName = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.uclCodeValue2 = ""
        Me.txtOrderCode.uclControlFlag = True
        Me.txtOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtOrderCode.uclDisplayIndex = "0,1"
        Me.txtOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtOrderCode.uclIsAutoAddZero = False
        Me.txtOrderCode.uclIsCheckDoctorOnDuty = False
        Me.txtOrderCode.uclIsReturnDS = False
        Me.txtOrderCode.uclIsShowMsgBox = True
        Me.txtOrderCode.uclIsTextAutoClear = True
        Me.txtOrderCode.uclMsgValue = Nothing
        Me.txtOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtOrderCode.uclQueryField = Nothing
        Me.txtOrderCode.uclQueryValue = Nothing
        Me.txtOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.txtOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.txtOrderCode.uclTotalWidth = 8
        Me.txtOrderCode.uclXPosition = 225
        Me.txtOrderCode.uclYPosition = 120
        '
        'lblMainIdentityId
        '
        Me.lblMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMainIdentityId.AutoSize = True
        Me.lblMainIdentityId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMainIdentityId.Location = New System.Drawing.Point(20, 76)
        Me.lblMainIdentityId.Name = "lblMainIdentityId"
        Me.lblMainIdentityId.Size = New System.Drawing.Size(91, 32)
        Me.lblMainIdentityId.TabIndex = 27
        Me.lblMainIdentityId.Text = "   計價原則(For自費項) "
        '
        'cmbMainIdentityId
        '
        Me.cmbMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMainIdentityId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMainIdentityId.DropDownWidth = 20
        Me.cmbMainIdentityId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMainIdentityId.Location = New System.Drawing.Point(118, 80)
        Me.cmbMainIdentityId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMainIdentityId.Name = "cmbMainIdentityId"
        Me.cmbMainIdentityId.SelectedIndex = -1
        Me.cmbMainIdentityId.SelectedItem = Nothing
        Me.cmbMainIdentityId.SelectedText = ""
        Me.cmbMainIdentityId.SelectedValue = ""
        Me.cmbMainIdentityId.SelectionStart = 0
        Me.cmbMainIdentityId.Size = New System.Drawing.Size(200, 24)
        Me.cmbMainIdentityId.TabIndex = 8
        Me.cmbMainIdentityId.uclDisplayIndex = "0,1"
        Me.cmbMainIdentityId.uclIsAutoClear = True
        Me.cmbMainIdentityId.uclIsFirstItemEmpty = True
        Me.cmbMainIdentityId.uclIsTextMode = False
        Me.cmbMainIdentityId.uclShowMsg = False
        Me.cmbMainIdentityId.uclValueIndex = "0"
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(985, 112)
        Me.pal_Mantain.TabIndex = 20
        '
        'PUBSubIdentitySetUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBSubIdentitySetUI"
        Me.ShowInTaskbar = False
        Me.TabText = "身份二代碼計價設定檔維護"
        Me.Text = "身份二代碼計價設定檔維護"
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dgvPanel.ResumeLayout(False)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.pal_Mantain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dgvPanel As System.Windows.Forms.Panel
    Friend WithEvents IUCLMaintainPanel As System.Windows.Forms.Panel
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pal_Mantain As System.Windows.Forms.Panel
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents rboOrderCode As System.Windows.Forms.RadioButton
    Friend WithEvents rboAccountId As System.Windows.Forms.RadioButton
    Friend WithEvents rboOrderTypeId As System.Windows.Forms.RadioButton
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cmbAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbOrderTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblMainIdentityId As System.Windows.Forms.Label
    Friend WithEvents cmbMainIdentityId As Syscom.Client.UCL.UCLComboBoxUC
End Class
