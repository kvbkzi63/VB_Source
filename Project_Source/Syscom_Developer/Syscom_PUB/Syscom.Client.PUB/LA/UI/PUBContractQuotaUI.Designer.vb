<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBContractQuotaUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBContractQuotaUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelNoButton = New System.Windows.Forms.Panel()
        Me.tlpNoButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblQuotaAmt = New System.Windows.Forms.Label()
        Me.txtQuotaAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblUsedQuotaAmt = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txtUsedQuotaAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblContractCode = New System.Windows.Forms.Label()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.cmbContractCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.panelNoButton.SuspendLayout()
        Me.tlpNoButton.SuspendLayout()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelNoButton
        '
        Me.panelNoButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelNoButton.Controls.Add(Me.tlpNoButton)
        Me.panelNoButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelNoButton.Location = New System.Drawing.Point(0, 0)
        Me.panelNoButton.Name = "panelNoButton"
        Me.panelNoButton.Size = New System.Drawing.Size(985, 96)
        Me.panelNoButton.TabIndex = 0
        '
        'tlpNoButton
        '
        Me.tlpNoButton.ColumnCount = 6
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpNoButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNoButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlpNoButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlpNoButton.Controls.Add(Me.lblQuotaAmt, 0, 1)
        Me.tlpNoButton.Controls.Add(Me.txtQuotaAmt, 1, 1)
        Me.tlpNoButton.Controls.Add(Me.lblEndDate, 4, 1)
        Me.tlpNoButton.Controls.Add(Me.lblUsedQuotaAmt, 2, 1)
        Me.tlpNoButton.Controls.Add(Me.dtpEndDate, 5, 1)
        Me.tlpNoButton.Controls.Add(Me.txtUsedQuotaAmt, 3, 1)
        Me.tlpNoButton.Controls.Add(Me.lblContractCode, 4, 0)
        Me.tlpNoButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlpNoButton.Controls.Add(Me.cmbContractCode, 5, 0)
        Me.tlpNoButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlpNoButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNoButton.Location = New System.Drawing.Point(0, 0)
        Me.tlpNoButton.Name = "tlpNoButton"
        Me.tlpNoButton.RowCount = 2
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.80899!))
        Me.tlpNoButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.19101!))
        Me.tlpNoButton.Size = New System.Drawing.Size(983, 94)
        Me.tlpNoButton.TabIndex = 0
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(3, 16)
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
        Me.dtpEffectDate.Location = New System.Drawing.Point(73, 11)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(121, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblQuotaAmt
        '
        Me.lblQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblQuotaAmt.AutoSize = True
        Me.lblQuotaAmt.Location = New System.Drawing.Point(27, 63)
        Me.lblQuotaAmt.Name = "lblQuotaAmt"
        Me.lblQuotaAmt.Size = New System.Drawing.Size(40, 16)
        Me.lblQuotaAmt.TabIndex = 6
        Me.lblQuotaAmt.Text = "額度"
        '
        'txtQuotaAmt
        '
        Me.txtQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtQuotaAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtQuotaAmt.Location = New System.Drawing.Point(74, 58)
        Me.txtQuotaAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQuotaAmt.MaxLength = 19
        Me.txtQuotaAmt.Name = "txtQuotaAmt"
        Me.txtQuotaAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQuotaAmt.SelectionStart = 0
        Me.txtQuotaAmt.Size = New System.Drawing.Size(120, 27)
        Me.txtQuotaAmt.TabIndex = 3
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
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(636, 63)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 10
        Me.lblEndDate.Text = "停止日"
        '
        'lblUsedQuotaAmt
        '
        Me.lblUsedQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUsedQuotaAmt.AutoSize = True
        Me.lblUsedQuotaAmt.Location = New System.Drawing.Point(273, 63)
        Me.lblUsedQuotaAmt.Name = "lblUsedQuotaAmt"
        Me.lblUsedQuotaAmt.Size = New System.Drawing.Size(72, 16)
        Me.lblUsedQuotaAmt.TabIndex = 8
        Me.lblUsedQuotaAmt.Text = "已用額度"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(698, 58)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(121, 27)
        Me.dtpEndDate.TabIndex = 5
        Me.dtpEndDate.uclReadOnly = False
        '
        'txtUsedQuotaAmt
        '
        Me.txtUsedQuotaAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtUsedQuotaAmt.Enabled = False
        Me.txtUsedQuotaAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtUsedQuotaAmt.Location = New System.Drawing.Point(352, 58)
        Me.txtUsedQuotaAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsedQuotaAmt.MaxLength = 19
        Me.txtUsedQuotaAmt.Name = "txtUsedQuotaAmt"
        Me.txtUsedQuotaAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsedQuotaAmt.SelectionStart = 0
        Me.txtUsedQuotaAmt.Size = New System.Drawing.Size(120, 27)
        Me.txtUsedQuotaAmt.TabIndex = 4
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
        'lblContractCode
        '
        Me.lblContractCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblContractCode.AutoSize = True
        Me.lblContractCode.ForeColor = System.Drawing.Color.Red
        Me.lblContractCode.Location = New System.Drawing.Point(580, 16)
        Me.lblContractCode.Name = "lblContractCode"
        Me.lblContractCode.Size = New System.Drawing.Size(112, 16)
        Me.lblContractCode.TabIndex = 2
        Me.lblContractCode.Text = "*合約機關代碼"
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(249, 16)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 4
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'cmbContractCode
        '
        Me.cmbContractCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbContractCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbContractCode.DropDownWidth = 20
        Me.cmbContractCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbContractCode.Location = New System.Drawing.Point(699, 12)
        Me.cmbContractCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbContractCode.Name = "cmbContractCode"
        Me.cmbContractCode.SelectedIndex = -1
        Me.cmbContractCode.SelectedItem = Nothing
        Me.cmbContractCode.SelectedText = ""
        Me.cmbContractCode.SelectedValue = ""
        Me.cmbContractCode.SelectionStart = 0
        Me.cmbContractCode.Size = New System.Drawing.Size(189, 24)
        Me.cmbContractCode.TabIndex = 2
        Me.cmbContractCode.uclDisplayIndex = "0,1"
        Me.cmbContractCode.uclIsAutoClear = True
        Me.cmbContractCode.uclIsFirstItemEmpty = True
        Me.cmbContractCode.uclIsTextMode = False
        Me.cmbContractCode.uclShowMsg = False
        Me.cmbContractCode.uclValueIndex = "0"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(352, 12)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(189, 24)
        Me.cmbSubIdentityCode.TabIndex = 1
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Controls.Add(Me.dgvPanel)
        Me.IUCLMaintainPanel.Controls.Add(Me.btnFlowLayoutPanel)
        Me.IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 96)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 384)
        Me.IUCLMaintainPanel.TabIndex = 6
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(983, 347)
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
        Me.dgvShowData.Size = New System.Drawing.Size(983, 347)
        Me.dgvShowData.TabIndex = 99
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
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(794, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 7
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(698, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'PUBContractQuotaUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.panelNoButton)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBContractQuotaUI"
        Me.TabText = "合約機構記帳累計檔維護"
        Me.Text = "合約機構記帳累計檔維護"
        Me.panelNoButton.ResumeLayout(False)
        Me.tlpNoButton.ResumeLayout(False)
        Me.tlpNoButton.PerformLayout()
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelNoButton As System.Windows.Forms.Panel
    Friend WithEvents tlpNoButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblContractCode As System.Windows.Forms.Label
    Friend WithEvents cmbContractCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtUsedQuotaAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblUsedQuotaAmt As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents IUCLMaintainPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblQuotaAmt As System.Windows.Forms.Label
    Friend WithEvents txtQuotaAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
