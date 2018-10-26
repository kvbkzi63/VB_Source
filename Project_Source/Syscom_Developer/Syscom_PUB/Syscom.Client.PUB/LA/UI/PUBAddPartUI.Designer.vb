<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAddPartUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBAddPartUI))
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txtAddPartAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPartTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStartValue = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtEndValue = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Controls.Add(Me.dgvPanel)
        Me.IUCLMaintainPanel.Controls.Add(Me.btnFlowLayoutPanel)
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 117)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(990, 507)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(988, 470)
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
        Me.dgvShowData.Size = New System.Drawing.Size(988, 470)
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
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(799, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 8
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(703, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "F12-確定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1002, 108)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEffectDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAddPartAmt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbPartTypeId, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtStartValue, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEndValue, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOrderCode, 9, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1000, 90)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*生效日"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "加收金額"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(83, 9)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(112, 27)
        Me.dtpEffectDate.TabIndex = 0
        Me.dtpEffectDate.uclReadOnly = False
        '
        'txtAddPartAmt
        '
        Me.txtAddPartAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAddPartAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtAddPartAmt.Location = New System.Drawing.Point(84, 54)
        Me.txtAddPartAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddPartAmt.MaxLength = 19
        Me.txtAddPartAmt.Name = "txtAddPartAmt"
        Me.txtAddPartAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAddPartAmt.SelectionStart = 0
        Me.txtAddPartAmt.Size = New System.Drawing.Size(109, 27)
        Me.txtAddPartAmt.TabIndex = 5
        Me.txtAddPartAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtAddPartAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtAddPartAmt.uclDollarSign = False
        Me.txtAddPartAmt.uclDotCount = 1
        Me.txtAddPartAmt.uclIntCount = 17
        Me.txtAddPartAmt.uclMinus = False
        Me.txtAddPartAmt.uclReadOnly = False
        Me.txtAddPartAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtAddPartAmt.uclTrimZero = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(203, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "*加收類別"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "結束日"
        '
        'cmbPartTypeId
        '
        Me.cmbPartTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbPartTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbPartTypeId.DropDownWidth = 20
        Me.cmbPartTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbPartTypeId.Location = New System.Drawing.Point(290, 10)
        Me.cmbPartTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPartTypeId.Name = "cmbPartTypeId"
        Me.cmbPartTypeId.SelectedIndex = -1
        Me.cmbPartTypeId.SelectedItem = Nothing
        Me.cmbPartTypeId.SelectedText = ""
        Me.cmbPartTypeId.SelectedValue = ""
        Me.cmbPartTypeId.SelectionStart = 0
        Me.cmbPartTypeId.Size = New System.Drawing.Size(111, 24)
        Me.cmbPartTypeId.TabIndex = 1
        Me.cmbPartTypeId.uclDisplayIndex = "0,1"
        Me.cmbPartTypeId.uclIsAutoClear = True
        Me.cmbPartTypeId.uclIsFirstItemEmpty = True
        Me.cmbPartTypeId.uclIsTextMode = False
        Me.cmbPartTypeId.uclShowMsg = False
        Me.cmbPartTypeId.uclValueIndex = "0"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(289, 54)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(112, 27)
        Me.dtpEndDate.TabIndex = 6
        Me.dtpEndDate.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(413, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "起"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(562, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "迄"
        '
        'txtStartValue
        '
        Me.txtStartValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtStartValue.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtStartValue.Location = New System.Drawing.Point(444, 9)
        Me.txtStartValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStartValue.MaxLength = 10
        Me.txtStartValue.Name = "txtStartValue"
        Me.txtStartValue.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtStartValue.SelectionStart = 0
        Me.txtStartValue.Size = New System.Drawing.Size(109, 27)
        Me.txtStartValue.TabIndex = 2
        Me.txtStartValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtStartValue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtStartValue.uclDollarSign = False
        Me.txtStartValue.uclDotCount = 0
        Me.txtStartValue.uclIntCount = 10
        Me.txtStartValue.uclMinus = False
        Me.txtStartValue.uclReadOnly = False
        Me.txtStartValue.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtStartValue.uclTrimZero = True
        '
        'txtEndValue
        '
        Me.txtEndValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtEndValue.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtEndValue.Location = New System.Drawing.Point(593, 9)
        Me.txtEndValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEndValue.MaxLength = 10
        Me.txtEndValue.Name = "txtEndValue"
        Me.txtEndValue.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEndValue.SelectionStart = 0
        Me.txtEndValue.Size = New System.Drawing.Size(109, 27)
        Me.txtEndValue.TabIndex = 3
        Me.txtEndValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtEndValue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtEndValue.uclDollarSign = False
        Me.txtEndValue.uclDotCount = 0
        Me.txtEndValue.uclIntCount = 10
        Me.txtEndValue.uclMinus = False
        Me.txtEndValue.uclReadOnly = False
        Me.txtEndValue.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtEndValue.uclTrimZero = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(712, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "批價碼"
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(771, 9)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(162, 26)
        Me.txtOrderCode.TabIndex = 4
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
        Me.txtOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txtOrderCode.uclTotalWidth = 8
        Me.txtOrderCode.uclXPosition = 225
        Me.txtOrderCode.uclYPosition = 120
        '
        'PUBAddPartUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 480)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBAddPartUI"
        Me.TabText = "加收部份負擔基本檔維護"
        Me.Text = "加收部份負擔基本檔維護"
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents IUCLMaintainPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtAddPartAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPartTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStartValue As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtEndValue As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
