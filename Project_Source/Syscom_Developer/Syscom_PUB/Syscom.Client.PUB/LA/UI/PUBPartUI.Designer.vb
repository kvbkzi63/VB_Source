<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPartUI
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
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPartRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblPartRatio = New System.Windows.Forms.Label()
        Me.txtPartName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtPartAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblPartName = New System.Windows.Forms.Label()
        Me.lblPartCode = New System.Windows.Forms.Label()
        Me.txtPartCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.lblPartAmt = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
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
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 117)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1000, 498)
        Me.IUCLMaintainPanel.TabIndex = 5
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
        Me.dgvShowData.TabIndex = 9
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
        Me.tlp_nonButton.ColumnCount = 6
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.12766!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.87234!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 432.0!))
        Me.tlp_nonButton.Controls.Add(Me.txtPartRatio, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblPartRatio, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtPartName, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtPartAmt, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblPartName, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblPartCode, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtPartCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblEffectDate, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblPartAmt, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblEndDate, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.dtpEndDate, 5, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.64865!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.35135!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1000, 111)
        Me.tlp_nonButton.TabIndex = 0
        '
        'txtPartRatio
        '
        Me.txtPartRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPartRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPartRatio.Location = New System.Drawing.Point(363, 69)
        Me.txtPartRatio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartRatio.MaxLength = 19
        Me.txtPartRatio.Name = "txtPartRatio"
        Me.txtPartRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartRatio.SelectionStart = 0
        Me.txtPartRatio.Size = New System.Drawing.Size(102, 27)
        Me.txtPartRatio.TabIndex = 4
        Me.txtPartRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPartRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPartRatio.uclDollarSign = False
        Me.txtPartRatio.uclDotCount = 4
        Me.txtPartRatio.uclIntCount = 14
        Me.txtPartRatio.uclMinus = False
        Me.txtPartRatio.uclReadOnly = False
        Me.txtPartRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPartRatio.uclTrimZero = True
        '
        'lblPartRatio
        '
        Me.lblPartRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPartRatio.AutoSize = True
        Me.lblPartRatio.Location = New System.Drawing.Point(284, 74)
        Me.lblPartRatio.Name = "lblPartRatio"
        Me.lblPartRatio.Size = New System.Drawing.Size(72, 16)
        Me.lblPartRatio.TabIndex = 11
        Me.lblPartRatio.Text = "負擔比率"
        '
        'txtPartName
        '
        Me.txtPartName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPartName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPartName.Location = New System.Drawing.Point(571, 13)
        Me.txtPartName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartName.MaxLength = 10
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartName.SelectionStart = 0
        Me.txtPartName.Size = New System.Drawing.Size(363, 27)
        Me.txtPartName.TabIndex = 2
        Me.txtPartName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPartName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPartName.uclDollarSign = False
        Me.txtPartName.uclDotCount = 0
        Me.txtPartName.uclIntCount = 2
        Me.txtPartName.uclMinus = False
        Me.txtPartName.uclReadOnly = False
        Me.txtPartName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtPartName.uclTrimZero = True
        '
        'txtPartAmt
        '
        Me.txtPartAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPartAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPartAmt.Location = New System.Drawing.Point(91, 69)
        Me.txtPartAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartAmt.MaxLength = 19
        Me.txtPartAmt.Name = "txtPartAmt"
        Me.txtPartAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartAmt.SelectionStart = 0
        Me.txtPartAmt.Size = New System.Drawing.Size(111, 27)
        Me.txtPartAmt.TabIndex = 3
        Me.txtPartAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPartAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPartAmt.uclDollarSign = False
        Me.txtPartAmt.uclDotCount = 1
        Me.txtPartAmt.uclIntCount = 17
        Me.txtPartAmt.uclMinus = False
        Me.txtPartAmt.uclReadOnly = False
        Me.txtPartAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPartAmt.uclTrimZero = True
        '
        'lblPartName
        '
        Me.lblPartName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPartName.AutoSize = True
        Me.lblPartName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPartName.Location = New System.Drawing.Point(524, 19)
        Me.lblPartName.Name = "lblPartName"
        Me.lblPartName.Size = New System.Drawing.Size(40, 16)
        Me.lblPartName.TabIndex = 4
        Me.lblPartName.Text = "名稱"
        '
        'lblPartCode
        '
        Me.lblPartCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPartCode.AutoSize = True
        Me.lblPartCode.ForeColor = System.Drawing.Color.Red
        Me.lblPartCode.Location = New System.Drawing.Point(244, 19)
        Me.lblPartCode.Name = "lblPartCode"
        Me.lblPartCode.Size = New System.Drawing.Size(112, 16)
        Me.lblPartCode.TabIndex = 2
        Me.lblPartCode.Text = "*部份負擔代碼"
        '
        'txtPartCode
        '
        Me.txtPartCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPartCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPartCode.Location = New System.Drawing.Point(363, 13)
        Me.txtPartCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPartCode.MaxLength = 10
        Me.txtPartCode.Name = "txtPartCode"
        Me.txtPartCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartCode.SelectionStart = 0
        Me.txtPartCode.Size = New System.Drawing.Size(102, 27)
        Me.txtPartCode.TabIndex = 1
        Me.txtPartCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPartCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPartCode.uclDollarSign = False
        Me.txtPartCode.uclDotCount = 0
        Me.txtPartCode.uclIntCount = 2
        Me.txtPartCode.uclMinus = False
        Me.txtPartCode.uclReadOnly = False
        Me.txtPartCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtPartCode.uclTrimZero = True
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(20, 19)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEffectDate.TabIndex = 0
        Me.lblEffectDate.Text = "*生效日"
        '
        'lblPartAmt
        '
        Me.lblPartAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPartAmt.AutoSize = True
        Me.lblPartAmt.Location = New System.Drawing.Point(12, 74)
        Me.lblPartAmt.Name = "lblPartAmt"
        Me.lblPartAmt.Size = New System.Drawing.Size(72, 16)
        Me.lblPartAmt.TabIndex = 6
        Me.lblPartAmt.Text = "負擔金額"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(90, 13)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(113, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(508, 74)
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
        Me.dtpEndDate.Location = New System.Drawing.Point(570, 69)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(152, 27)
        Me.dtpEndDate.TabIndex = 5
        Me.dtpEndDate.uclReadOnly = False
        '
        'PUBPartUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 632)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPartUI"
        Me.TabText = "部份負擔基本檔維護"
        Me.Text = "部份負擔基本檔維護"
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
    Friend WithEvents lblPartName As System.Windows.Forms.Label
    Friend WithEvents lblPartCode As System.Windows.Forms.Label
    Friend WithEvents txtPartCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblPartAmt As System.Windows.Forms.Label
    Friend WithEvents txtPartAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtPartName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtPartRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblPartRatio As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
End Class
