<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPartDiscountUI
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    components = New System.ComponentModel.Container
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    Me.Text = "PUBPartDiscountUI"
    'End Sub
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPartDiscountUI))
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtDiscountRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.labDiscountRatio = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.labtemp = New System.Windows.Forms.Label()
        Me.cmbPartCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblPartCode = New System.Windows.Forms.Label()
        Me.cmbDisIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.labDisIdentityCode = New System.Windows.Forms.Label()
        Me.labSubIdentityCode = New System.Windows.Forms.Label()
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
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 102)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1015, 513)
        Me.IUCLMaintainPanel.TabIndex = 5
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 37)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(1013, 475)
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
        Me.dgvShowData.Size = New System.Drawing.Size(1013, 475)
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
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(1013, 36)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(920, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(824, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 7
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(728, 3)
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
        Me.pal_Mantain.Size = New System.Drawing.Size(1027, 96)
        Me.pal_Mantain.TabIndex = 0
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 8
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 313.0!))
        Me.tlp_nonButton.Controls.Add(Me.cmbSubIdentityCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtDiscountRatio, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.labDiscountRatio, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.labtemp, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbPartCode, 7, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblPartCode, 6, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbDisIdentityCode, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.labDisIdentityCode, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.labSubIdentityCode, 2, 0)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.36709!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.63291!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1025, 79)
        Me.tlp_nonButton.TabIndex = 2
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(301, 7)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(130, 24)
        Me.cmbSubIdentityCode.TabIndex = 18
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'txtDiscountRatio
        '
        Me.txtDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDiscountRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDiscountRatio.Location = New System.Drawing.Point(74, 45)
        Me.txtDiscountRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiscountRatio.MaxLength = 6
        Me.txtDiscountRatio.Name = "txtDiscountRatio"
        Me.txtDiscountRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiscountRatio.SelectionStart = 0
        Me.txtDiscountRatio.Size = New System.Drawing.Size(117, 27)
        Me.txtDiscountRatio.TabIndex = 3
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
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(3, 11)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEffectDate.TabIndex = 0
        Me.lblEffectDate.Text = "*生效日"
        '
        'labDiscountRatio
        '
        Me.labDiscountRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labDiscountRatio.AutoSize = True
        Me.labDiscountRatio.Location = New System.Drawing.Point(11, 50)
        Me.labDiscountRatio.Name = "labDiscountRatio"
        Me.labDiscountRatio.Size = New System.Drawing.Size(56, 16)
        Me.labDiscountRatio.TabIndex = 6
        Me.labDiscountRatio.Text = "折扣率"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(73, 5)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(119, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(497, 50)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 9
        Me.lblEndDate.Text = "結束日"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(559, 45)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(131, 27)
        Me.dtpEndDate.TabIndex = 4
        Me.dtpEndDate.uclReadOnly = False
        '
        'labtemp
        '
        Me.labtemp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labtemp.AutoSize = True
        Me.tlp_nonButton.SetColumnSpan(Me.labtemp, 2)
        Me.labtemp.Location = New System.Drawing.Point(198, 50)
        Me.labtemp.Name = "labtemp"
        Me.labtemp.Size = New System.Drawing.Size(131, 16)
        Me.labtemp.TabIndex = 15
        Me.labtemp.Text = "(0.8表示折扣20%)"
        '
        'cmbPartCode
        '
        Me.cmbPartCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbPartCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbPartCode.DropDownWidth = 20
        Me.cmbPartCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbPartCode.Location = New System.Drawing.Point(816, 7)
        Me.cmbPartCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPartCode.Name = "cmbPartCode"
        Me.cmbPartCode.SelectedIndex = -1
        Me.cmbPartCode.SelectedItem = Nothing
        Me.cmbPartCode.SelectedText = ""
        Me.cmbPartCode.SelectedValue = ""
        Me.cmbPartCode.SelectionStart = 0
        Me.cmbPartCode.Size = New System.Drawing.Size(162, 24)
        Me.cmbPartCode.TabIndex = 2
        Me.cmbPartCode.uclDisplayIndex = "0,1"
        Me.cmbPartCode.uclIsAutoClear = True
        Me.cmbPartCode.uclIsFirstItemEmpty = True
        Me.cmbPartCode.uclIsTextMode = False
        Me.cmbPartCode.uclShowMsg = False
        Me.cmbPartCode.uclValueIndex = "0"
        '
        'lblPartCode
        '
        Me.lblPartCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPartCode.AutoSize = True
        Me.lblPartCode.ForeColor = System.Drawing.Color.Red
        Me.lblPartCode.Location = New System.Drawing.Point(697, 11)
        Me.lblPartCode.Name = "lblPartCode"
        Me.lblPartCode.Size = New System.Drawing.Size(112, 16)
        Me.lblPartCode.TabIndex = 2
        Me.lblPartCode.Text = "*部份負擔代碼"
        '
        'cmbDisIdentityCode
        '
        Me.cmbDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbDisIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbDisIdentityCode.DropDownWidth = 20
        Me.cmbDisIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbDisIdentityCode.Location = New System.Drawing.Point(560, 7)
        Me.cmbDisIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDisIdentityCode.Name = "cmbDisIdentityCode"
        Me.cmbDisIdentityCode.SelectedIndex = -1
        Me.cmbDisIdentityCode.SelectedItem = Nothing
        Me.cmbDisIdentityCode.SelectedText = ""
        Me.cmbDisIdentityCode.SelectedValue = ""
        Me.cmbDisIdentityCode.SelectionStart = 0
        Me.cmbDisIdentityCode.Size = New System.Drawing.Size(130, 24)
        Me.cmbDisIdentityCode.TabIndex = 1
        Me.cmbDisIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbDisIdentityCode.uclIsAutoClear = True
        Me.cmbDisIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbDisIdentityCode.uclIsTextMode = False
        Me.cmbDisIdentityCode.uclShowMsg = False
        Me.cmbDisIdentityCode.uclValueIndex = "0"
        '
        'labDisIdentityCode
        '
        Me.labDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labDisIdentityCode.AutoSize = True
        Me.labDisIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.labDisIdentityCode.Location = New System.Drawing.Point(441, 11)
        Me.labDisIdentityCode.Name = "labDisIdentityCode"
        Me.labDisIdentityCode.Size = New System.Drawing.Size(112, 16)
        Me.labDisIdentityCode.TabIndex = 12
        Me.labDisIdentityCode.Text = "*優待身份代碼"
        '
        'labSubIdentityCode
        '
        Me.labSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labSubIdentityCode.AutoSize = True
        Me.labSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.labSubIdentityCode.Location = New System.Drawing.Point(198, 11)
        Me.labSubIdentityCode.Name = "labSubIdentityCode"
        Me.labSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.labSubIdentityCode.TabIndex = 16
        Me.labSubIdentityCode.Text = "*身份二代碼"
        '
        'PUBPartDiscountUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 632)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPartDiscountUI"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.TabText = "部份負擔優待基本檔維護"
        Me.Text = "部份負擔優待基本檔維護"
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
    Friend WithEvents labDiscountRatio As System.Windows.Forms.Label
    Friend WithEvents txtDiscountRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblPartCode As System.Windows.Forms.Label
    Friend WithEvents labDisIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbDisIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbPartCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents labtemp As System.Windows.Forms.Label
    Friend WithEvents labSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
