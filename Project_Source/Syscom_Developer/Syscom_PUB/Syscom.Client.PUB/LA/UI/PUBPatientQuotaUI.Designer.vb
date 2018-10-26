<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPatientQuotaUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPatientQuotaUI))
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblChartNo = New System.Windows.Forms.Label()
        Me.txtChartNo = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblQuotaAmt = New System.Windows.Forms.Label()
        Me.lblUsedQuotaAmt = New System.Windows.Forms.Label()
        Me.txtUsedQuotaAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.txtQuotaAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblContractCode = New System.Windows.Forms.Label()
        Me.cmbContractCode = New Syscom.Client.UCL.UCLComboBoxUC()
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
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 99)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(990, 498)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(988, 461)
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
        Me.dgvShowData.Size = New System.Drawing.Size(988, 461)
        Me.dgvShowData.TabIndex = 11
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
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(988, 35)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(895, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(799, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 9
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(703, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(992, 93)
        Me.pal_Mantain.TabIndex = 0
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 8
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblChartNo, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtChartNo, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblQuotaAmt, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblUsedQuotaAmt, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtUsedQuotaAmt, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtQuotaAmt, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblContractCode, 6, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbContractCode, 7, 0)
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.64865!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.35135!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(989, 92)
        Me.tlp_nonButton.TabIndex = 0
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(3, 14)
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
        Me.dtpEffectDate.Location = New System.Drawing.Point(73, 8)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(116, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(547, 54)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(147, 27)
        Me.dtpEndDate.TabIndex = 7
        Me.dtpEndDate.uclReadOnly = False
        '
        'lblChartNo
        '
        Me.lblChartNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblChartNo.AutoSize = True
        Me.lblChartNo.ForeColor = System.Drawing.Color.Red
        Me.lblChartNo.Location = New System.Drawing.Point(477, 14)
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Size = New System.Drawing.Size(64, 16)
        Me.lblChartNo.TabIndex = 12
        Me.lblChartNo.Text = "*病歷號"
        '
        'txtChartNo
        '
        Me.txtChartNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtChartNo.doFlag = True
        Me.txtChartNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtChartNo.Location = New System.Drawing.Point(544, 9)
        Me.txtChartNo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtChartNo.Name = "txtChartNo"
        Me.txtChartNo.Size = New System.Drawing.Size(150, 26)
        Me.txtChartNo.TabIndex = 2
        Me.txtChartNo.uclBaseDate = "2015/05/01"
        Me.txtChartNo.uclCboWidth = 114
        Me.txtChartNo.uclCodeName = ""
        Me.txtChartNo.uclCodeValue1 = ""
        Me.txtChartNo.uclCodeValue2 = ""
        Me.txtChartNo.uclControlFlag = True
        Me.txtChartNo.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtChartNo.uclDisplayIndex = "0,1"
        Me.txtChartNo.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtChartNo.uclIsAutoAddZero = False
        Me.txtChartNo.uclIsCheckDoctorOnDuty = False
        Me.txtChartNo.uclIsReturnDS = False
        Me.txtChartNo.uclIsShowMsgBox = True
        Me.txtChartNo.uclIsTextAutoClear = True
        Me.txtChartNo.uclMsgValue = Nothing
        Me.txtChartNo.uclPUBEmployeeProfessalKindId = ""
        Me.txtChartNo.uclQueryField = Nothing
        Me.txtChartNo.uclQueryValue = Nothing
        Me.txtChartNo.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtChartNo.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Patient
        Me.txtChartNo.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txtChartNo.uclTotalWidth = 8
        Me.txtChartNo.uclXPosition = 225
        Me.txtChartNo.uclYPosition = 120
        '
        'lblQuotaAmt
        '
        Me.lblQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblQuotaAmt.AutoSize = True
        Me.lblQuotaAmt.Location = New System.Drawing.Point(27, 60)
        Me.lblQuotaAmt.Name = "lblQuotaAmt"
        Me.lblQuotaAmt.Size = New System.Drawing.Size(40, 16)
        Me.lblQuotaAmt.TabIndex = 14
        Me.lblQuotaAmt.Text = "額度"
        '
        'lblUsedQuotaAmt
        '
        Me.lblUsedQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUsedQuotaAmt.AutoSize = True
        Me.lblUsedQuotaAmt.Location = New System.Drawing.Point(220, 60)
        Me.lblUsedQuotaAmt.Name = "lblUsedQuotaAmt"
        Me.lblUsedQuotaAmt.Size = New System.Drawing.Size(72, 16)
        Me.lblUsedQuotaAmt.TabIndex = 16
        Me.lblUsedQuotaAmt.Text = "已用額度"
        '
        'txtUsedQuotaAmt
        '
        Me.txtUsedQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtUsedQuotaAmt.Enabled = False
        Me.txtUsedQuotaAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtUsedQuotaAmt.Location = New System.Drawing.Point(299, 54)
        Me.txtUsedQuotaAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsedQuotaAmt.MaxLength = 19
        Me.txtUsedQuotaAmt.Name = "txtUsedQuotaAmt"
        Me.txtUsedQuotaAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsedQuotaAmt.SelectionStart = 0
        Me.txtUsedQuotaAmt.Size = New System.Drawing.Size(142, 27)
        Me.txtUsedQuotaAmt.TabIndex = 6
        Me.txtUsedQuotaAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUsedQuotaAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtUsedQuotaAmt.uclDollarSign = False
        Me.txtUsedQuotaAmt.uclDotCount = 1
        Me.txtUsedQuotaAmt.uclIntCount = 17
        Me.txtUsedQuotaAmt.uclMinus = False
        Me.txtUsedQuotaAmt.uclReadOnly = True
        Me.txtUsedQuotaAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtUsedQuotaAmt.uclTrimZero = True
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(485, 60)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 9
        Me.lblEndDate.Text = "停止日"
        '
        'txtQuotaAmt
        '
        Me.txtQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtQuotaAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtQuotaAmt.Location = New System.Drawing.Point(74, 54)
        Me.txtQuotaAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQuotaAmt.MaxLength = 19
        Me.txtQuotaAmt.Name = "txtQuotaAmt"
        Me.txtQuotaAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQuotaAmt.SelectionStart = 0
        Me.txtQuotaAmt.Size = New System.Drawing.Size(115, 27)
        Me.txtQuotaAmt.TabIndex = 5
        Me.txtQuotaAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtQuotaAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtQuotaAmt.uclDollarSign = False
        Me.txtQuotaAmt.uclDotCount = 1
        Me.txtQuotaAmt.uclIntCount = 17
        Me.txtQuotaAmt.uclMinus = False
        Me.txtQuotaAmt.uclReadOnly = False
        Me.txtQuotaAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtQuotaAmt.uclTrimZero = True
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(196, 14)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 17
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(299, 10)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(171, 24)
        Me.cmbSubIdentityCode.TabIndex = 1
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
        Me.lblContractCode.Location = New System.Drawing.Point(700, 14)
        Me.lblContractCode.Name = "lblContractCode"
        Me.lblContractCode.Size = New System.Drawing.Size(112, 16)
        Me.lblContractCode.TabIndex = 10
        Me.lblContractCode.Text = "*合約機關代碼"
        '
        'cmbContractCode
        '
        Me.cmbContractCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbContractCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbContractCode.DropDownWidth = 20
        Me.cmbContractCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbContractCode.Location = New System.Drawing.Point(819, 10)
        Me.cmbContractCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbContractCode.Name = "cmbContractCode"
        Me.cmbContractCode.SelectedIndex = -1
        Me.cmbContractCode.SelectedItem = Nothing
        Me.cmbContractCode.SelectedText = ""
        Me.cmbContractCode.SelectedValue = ""
        Me.cmbContractCode.SelectionStart = 0
        Me.cmbContractCode.Size = New System.Drawing.Size(142, 24)
        Me.cmbContractCode.TabIndex = 3
        Me.cmbContractCode.uclDisplayIndex = "0,1"
        Me.cmbContractCode.uclIsAutoClear = True
        Me.cmbContractCode.uclIsFirstItemEmpty = True
        Me.cmbContractCode.uclIsTextMode = False
        Me.cmbContractCode.uclShowMsg = False
        Me.cmbContractCode.uclValueIndex = "0"
        '
        'PUBPatientQuotaUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 632)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPatientQuotaUI"
        Me.TabText = "病患合約機構記帳累積檔維護"
        Me.Text = "病患合約機構記帳累積檔維護"
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
    Friend WithEvents lblContractCode As System.Windows.Forms.Label
    Friend WithEvents cmbContractCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblChartNo As System.Windows.Forms.Label
    Friend WithEvents lblQuotaAmt As System.Windows.Forms.Label
    Friend WithEvents txtQuotaAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblUsedQuotaAmt As System.Windows.Forms.Label
    Friend WithEvents txtUsedQuotaAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtChartNo As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
