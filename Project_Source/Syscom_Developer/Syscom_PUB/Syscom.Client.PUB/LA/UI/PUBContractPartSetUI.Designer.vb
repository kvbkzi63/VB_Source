<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBContractPartSetUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBContractPartSetUI))
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
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.cmbContractCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblKeepAccountAmt = New System.Windows.Forms.Label()
        Me.txtKeepAccountAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lable1 = New System.Windows.Forms.Label()
        Me.txtKeepAccountRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblContractCode = New System.Windows.Forms.Label()
        Me.lblKeepAccountRatio = New System.Windows.Forms.Label()
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
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 117)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1000, 498)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(998, 461)
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
        Me.dgvShowData.Size = New System.Drawing.Size(998, 461)
        Me.dgvShowData.TabIndex = 10
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
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(998, 35)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(905, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(809, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 7
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(713, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 6
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
        Me.pal_Mantain.Size = New System.Drawing.Size(1002, 112)
        Me.pal_Mantain.TabIndex = 18
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 7
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbContractCode, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityCode, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblKeepAccountAmt, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtKeepAccountAmt, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lable1, 6, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtKeepAccountRatio, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblContractCode, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblKeepAccountRatio, 4, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.64865!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.35135!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1000, 111)
        Me.tlp_nonButton.TabIndex = 0
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(3, 19)
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
        Me.dtpEffectDate.Location = New System.Drawing.Point(73, 13)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(123, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(11, 74)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 9
        Me.lblEndDate.Text = "停止日"
        '
        'cmbContractCode
        '
        Me.cmbContractCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_nonButton.SetColumnSpan(Me.cmbContractCode, 2)
        Me.cmbContractCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbContractCode.DropDownWidth = 20
        Me.cmbContractCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbContractCode.Location = New System.Drawing.Point(652, 15)
        Me.cmbContractCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbContractCode.Name = "cmbContractCode"
        Me.cmbContractCode.SelectedIndex = -1
        Me.cmbContractCode.SelectedItem = Nothing
        Me.cmbContractCode.SelectedText = ""
        Me.cmbContractCode.SelectedValue = ""
        Me.cmbContractCode.SelectionStart = 0
        Me.cmbContractCode.Size = New System.Drawing.Size(247, 24)
        Me.cmbContractCode.TabIndex = 2
        Me.cmbContractCode.uclDisplayIndex = "0,1"
        Me.cmbContractCode.uclIsAutoClear = True
        Me.cmbContractCode.uclIsFirstItemEmpty = True
        Me.cmbContractCode.uclIsTextMode = False
        Me.cmbContractCode.uclShowMsg = False
        Me.cmbContractCode.uclValueIndex = "0"
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Black
        Me.lblSubIdentityCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(237, 19)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(88, 16)
        Me.lblSubIdentityCode.TabIndex = 4
        Me.lblSubIdentityCode.Text = "身份二代碼"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(73, 69)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(123, 27)
        Me.dtpEndDate.TabIndex = 3
        Me.dtpEndDate.uclReadOnly = False
        '
        'lblKeepAccountAmt
        '
        Me.lblKeepAccountAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKeepAccountAmt.AutoSize = True
        Me.lblKeepAccountAmt.Location = New System.Drawing.Point(211, 74)
        Me.lblKeepAccountAmt.Name = "lblKeepAccountAmt"
        Me.lblKeepAccountAmt.Size = New System.Drawing.Size(114, 16)
        Me.lblKeepAccountAmt.TabIndex = 11
        Me.lblKeepAccountAmt.Text = "記帳(請款)定額"
        '
        'txtKeepAccountAmt
        '
        Me.txtKeepAccountAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKeepAccountAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKeepAccountAmt.Location = New System.Drawing.Point(332, 69)
        Me.txtKeepAccountAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeepAccountAmt.MaxLength = 19
        Me.txtKeepAccountAmt.Name = "txtKeepAccountAmt"
        Me.txtKeepAccountAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKeepAccountAmt.SelectionStart = 0
        Me.txtKeepAccountAmt.Size = New System.Drawing.Size(161, 27)
        Me.txtKeepAccountAmt.TabIndex = 4
        Me.txtKeepAccountAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKeepAccountAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKeepAccountAmt.uclDollarSign = False
        Me.txtKeepAccountAmt.uclDotCount = 4
        Me.txtKeepAccountAmt.uclIntCount = 14
        Me.txtKeepAccountAmt.uclMinus = False
        Me.txtKeepAccountAmt.uclReadOnly = False
        Me.txtKeepAccountAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKeepAccountAmt.uclTrimZero = True
        '
        'lable1
        '
        Me.lable1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lable1.AutoSize = True
        Me.lable1.Location = New System.Drawing.Point(804, 74)
        Me.lable1.Name = "lable1"
        Me.lable1.Size = New System.Drawing.Size(195, 16)
        Me.lable1.TabIndex = 6
        Me.lable1.Text = "(0.7 表記帳70%,0表不記帳)"
        '
        'txtKeepAccountRatio
        '
        Me.txtKeepAccountRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKeepAccountRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKeepAccountRatio.Location = New System.Drawing.Point(652, 69)
        Me.txtKeepAccountRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeepAccountRatio.MaxLength = 19
        Me.txtKeepAccountRatio.Name = "txtKeepAccountRatio"
        Me.txtKeepAccountRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKeepAccountRatio.SelectionStart = 0
        Me.txtKeepAccountRatio.Size = New System.Drawing.Size(145, 27)
        Me.txtKeepAccountRatio.TabIndex = 5
        Me.txtKeepAccountRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKeepAccountRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKeepAccountRatio.uclDollarSign = False
        Me.txtKeepAccountRatio.uclDotCount = 17
        Me.txtKeepAccountRatio.uclIntCount = 1
        Me.txtKeepAccountRatio.uclMinus = False
        Me.txtKeepAccountRatio.uclReadOnly = False
        Me.txtKeepAccountRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKeepAccountRatio.uclTrimZero = True
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(332, 15)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(161, 24)
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
        Me.lblContractCode.Location = New System.Drawing.Point(533, 19)
        Me.lblContractCode.Name = "lblContractCode"
        Me.lblContractCode.Size = New System.Drawing.Size(112, 16)
        Me.lblContractCode.TabIndex = 2
        Me.lblContractCode.Text = "*合約機關代碼"
        '
        'lblKeepAccountRatio
        '
        Me.lblKeepAccountRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKeepAccountRatio.AutoSize = True
        Me.lblKeepAccountRatio.Location = New System.Drawing.Point(531, 74)
        Me.lblKeepAccountRatio.Name = "lblKeepAccountRatio"
        Me.lblKeepAccountRatio.Size = New System.Drawing.Size(114, 16)
        Me.lblKeepAccountRatio.TabIndex = 12
        Me.lblKeepAccountRatio.Text = "記帳(請款)比率"
        '
        'PUBContractPartSetUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 632)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBContractPartSetUI"
        Me.TabText = "合約身份部份負擔記帳設定檔"
        Me.Text = "合約身份部份負擔記帳設定檔"
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
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents lblContractCode As System.Windows.Forms.Label
    Friend WithEvents lable1 As System.Windows.Forms.Label
    Friend WithEvents txtKeepAccountRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtKeepAccountAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblKeepAccountAmt As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cmbContractCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblKeepAccountRatio As System.Windows.Forms.Label
End Class

