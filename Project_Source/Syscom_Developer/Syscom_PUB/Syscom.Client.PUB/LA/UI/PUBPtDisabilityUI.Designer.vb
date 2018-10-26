<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPtDisabilityUI
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPtDisabilityUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtChartNo = New Syscom.Client.UCL.UCLChartNoUC()
        Me.txtPatientName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.label3 = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txtPatientDisabilityMemo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.cmbDisabilityDegreeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDisabilityTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPatientDisabilityNo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dgvShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(200, 100)
        Me.tlp_nonButton.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 587)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txtChartNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEffectDate, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatientDisabilityMemo, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMemo, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDisabilityDegreeId, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbDisabilityTypeId, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEffectDate, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatientDisabilityNo, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnFlowLayoutPanel, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(972, 113)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnFlowLayoutPanel
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnFlowLayoutPanel, 11)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnDelete)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnUpdate)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnOK)
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(3, 73)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(966, 37)
        Me.btnFlowLayoutPanel.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(873, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(777, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 2
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(681, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 28)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "SF12-刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(585, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(90, 28)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "F10-修改"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(489, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "F12-新增"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtChartNo
        '
        Me.txtChartNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtChartNo.doFlag = False
        Me.txtChartNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtChartNo.IsAutoAddZero = False
        Me.txtChartNo.IsShowAddress = False
        Me.txtChartNo.IsShowTelHome = False
        Me.txtChartNo.Location = New System.Drawing.Point(82, 4)
        Me.txtChartNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChartNo.Name = "txtChartNo"
        Me.txtChartNo.Size = New System.Drawing.Size(94, 27)
        Me.txtChartNo.TabIndex = 18
        Me.txtChartNo.uclDigitCount = 8
        Me.txtChartNo.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.txtChartNo.uclIsDoReserveChartNo = True
        Me.txtChartNo.uclIsInteractionChartNo = True
        Me.txtChartNo.uclIsNameInputAutoPopWindow = False
        Me.txtChartNo.uclIsShowReserveChartNoMsg = True
        Me.txtChartNo.uclIsShowReserveChartNoQuestionMsg = False
        Me.txtChartNo.uclNeedCheckId = True
        Me.txtChartNo.uclNeedCheckIdByPubBP = True
        Me.txtChartNo.uclNeedSql = True
        Me.txtChartNo.uclReadOnly = False
        Me.txtChartNo.uclTextType = Syscom.Client.UCL.UCLChartNoUC.uclTextTypeData.ChartNo
        Me.txtChartNo.uclTxtBoxWidth = 94
        '
        'txtPatientName
        '
        Me.txtPatientName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPatientName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPatientName.Location = New System.Drawing.Point(388, 4)
        Me.txtPatientName.MaxLength = 10
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPatientName.SelectionStart = 0
        Me.txtPatientName.Size = New System.Drawing.Size(119, 27)
        Me.txtPatientName.TabIndex = 17
        Me.txtPatientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPatientName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPatientName.ToolTipTag = Nothing
        Me.txtPatientName.uclDollarSign = False
        Me.txtPatientName.uclDotCount = 0
        Me.txtPatientName.uclIntCount = 2
        Me.txtPatientName.uclMinus = False
        Me.txtPatientName.uclReadOnly = True
        Me.txtPatientName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtPatientName.uclTrimZero = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(310, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "殘障程度"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(575, 4)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(113, 27)
        Me.dtpEffectDate.TabIndex = 1
        Me.dtpEffectDate.uclReadOnly = False
        '
        'label3
        '
        Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label3.AutoSize = True
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(11, 9)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 16)
        Me.label3.TabIndex = 12
        Me.label3.Text = "*病歷號"
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Location = New System.Drawing.Point(694, 9)
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
        Me.dtpEndDate.Location = New System.Drawing.Point(756, 4)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(118, 27)
        Me.dtpEndDate.TabIndex = 2
        Me.dtpEndDate.uclReadOnly = False
        '
        'txtPatientDisabilityMemo
        '
        Me.txtPatientDisabilityMemo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientDisabilityMemo, 3)
        Me.txtPatientDisabilityMemo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPatientDisabilityMemo.Location = New System.Drawing.Point(576, 39)
        Me.txtPatientDisabilityMemo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPatientDisabilityMemo.MaxLength = 19
        Me.txtPatientDisabilityMemo.Name = "txtPatientDisabilityMemo"
        Me.txtPatientDisabilityMemo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPatientDisabilityMemo.SelectionStart = 0
        Me.txtPatientDisabilityMemo.Size = New System.Drawing.Size(392, 27)
        Me.txtPatientDisabilityMemo.TabIndex = 5
        Me.txtPatientDisabilityMemo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPatientDisabilityMemo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPatientDisabilityMemo.ToolTipTag = Nothing
        Me.txtPatientDisabilityMemo.uclDollarSign = False
        Me.txtPatientDisabilityMemo.uclDotCount = 1
        Me.txtPatientDisabilityMemo.uclIntCount = 17
        Me.txtPatientDisabilityMemo.uclMinus = False
        Me.txtPatientDisabilityMemo.uclReadOnly = False
        Me.txtPatientDisabilityMemo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtPatientDisabilityMemo.uclTrimZero = True
        '
        'lblMemo
        '
        Me.lblMemo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMemo.AutoSize = True
        Me.lblMemo.Location = New System.Drawing.Point(529, 44)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(40, 16)
        Me.lblMemo.TabIndex = 6
        Me.lblMemo.Text = "備註"
        '
        'cmbDisabilityDegreeId
        '
        Me.cmbDisabilityDegreeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbDisabilityDegreeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbDisabilityDegreeId.DropDownWidth = 20
        Me.cmbDisabilityDegreeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbDisabilityDegreeId.Location = New System.Drawing.Point(385, 40)
        Me.cmbDisabilityDegreeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbDisabilityDegreeId.Name = "cmbDisabilityDegreeId"
        Me.cmbDisabilityDegreeId.SelectedIndex = -1
        Me.cmbDisabilityDegreeId.SelectedItem = Nothing
        Me.cmbDisabilityDegreeId.SelectedText = ""
        Me.cmbDisabilityDegreeId.SelectedValue = ""
        Me.cmbDisabilityDegreeId.SelectionStart = 0
        Me.cmbDisabilityDegreeId.Size = New System.Drawing.Size(119, 24)
        Me.cmbDisabilityDegreeId.TabIndex = 4
        Me.cmbDisabilityDegreeId.uclDisplayIndex = "0,1"
        Me.cmbDisabilityDegreeId.uclIsAutoClear = True
        Me.cmbDisabilityDegreeId.uclIsFirstItemEmpty = True
        Me.cmbDisabilityDegreeId.uclIsTextMode = False
        Me.cmbDisabilityDegreeId.uclShowMsg = False
        Me.cmbDisabilityDegreeId.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "殘障類別"
        '
        'cmbDisabilityTypeId
        '
        Me.cmbDisabilityTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbDisabilityTypeId, 2)
        Me.cmbDisabilityTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbDisabilityTypeId.DropDownWidth = 20
        Me.cmbDisabilityTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbDisabilityTypeId.Location = New System.Drawing.Point(78, 40)
        Me.cmbDisabilityTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbDisabilityTypeId.Name = "cmbDisabilityTypeId"
        Me.cmbDisabilityTypeId.SelectedIndex = -1
        Me.cmbDisabilityTypeId.SelectedItem = Nothing
        Me.cmbDisabilityTypeId.SelectedText = ""
        Me.cmbDisabilityTypeId.SelectedValue = ""
        Me.cmbDisabilityTypeId.SelectionStart = 0
        Me.cmbDisabilityTypeId.Size = New System.Drawing.Size(150, 24)
        Me.cmbDisabilityTypeId.TabIndex = 3
        Me.cmbDisabilityTypeId.uclDisplayIndex = "0,1"
        Me.cmbDisabilityTypeId.uclIsAutoClear = True
        Me.cmbDisabilityTypeId.uclIsFirstItemEmpty = True
        Me.cmbDisabilityTypeId.uclIsTextMode = False
        Me.cmbDisabilityTypeId.uclShowMsg = False
        Me.cmbDisabilityTypeId.uclValueIndex = "0"
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEffectDate.Location = New System.Drawing.Point(513, 9)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEffectDate.TabIndex = 0
        Me.lblEffectDate.Text = "生效日"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(342, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "姓名"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(183, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "*序號"
        '
        'txtPatientDisabilityNo
        '
        Me.txtPatientDisabilityNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPatientDisabilityNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPatientDisabilityNo.Location = New System.Drawing.Point(237, 4)
        Me.txtPatientDisabilityNo.MaxLength = 10
        Me.txtPatientDisabilityNo.Name = "txtPatientDisabilityNo"
        Me.txtPatientDisabilityNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPatientDisabilityNo.SelectionStart = 0
        Me.txtPatientDisabilityNo.Size = New System.Drawing.Size(67, 27)
        Me.txtPatientDisabilityNo.TabIndex = 20
        Me.txtPatientDisabilityNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPatientDisabilityNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPatientDisabilityNo.ToolTipTag = Nothing
        Me.txtPatientDisabilityNo.uclDollarSign = False
        Me.txtPatientDisabilityNo.uclDotCount = 0
        Me.txtPatientDisabilityNo.uclIntCount = 2
        Me.txtPatientDisabilityNo.uclMinus = False
        Me.txtPatientDisabilityNo.uclReadOnly = False
        Me.txtPatientDisabilityNo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPatientDisabilityNo.uclTrimZero = True
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.AllowUserToOrderColumns = False
        Me.dgvShowData.AllowUserToResizeColumns = True
        Me.dgvShowData.AllowUserToResizeRows = False
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShowData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.ColumnHeadersVisible = True
        Me.dgvShowData.CurrentCell = Nothing
        Me.dgvShowData.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShowData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvShowData.Location = New System.Drawing.Point(0, 0)
        Me.dgvShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvShowData.MultiSelect = False
        Me.dgvShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.RowHeadersWidth = 41
        Me.dgvShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(972, 474)
        Me.dgvShowData.TabIndex = 0
        Me.dgvShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvShowData.uclBatchColIndex = ""
        Me.dgvShowData.uclClickToCheck = False
        Me.dgvShowData.uclColumnAlignment = ""
        Me.dgvShowData.uclColumnCheckBox = False
        Me.dgvShowData.uclColumnControlType = ""
        Me.dgvShowData.uclColumnWidth = ""
        Me.dgvShowData.uclDoCellEnter = True
        Me.dgvShowData.uclHasNewRow = False
        Me.dgvShowData.uclHeaderText = ""
        Me.dgvShowData.uclIsAlternatingRowsColors = True
        Me.dgvShowData.uclIsComboBoxGridQuery = True
        Me.dgvShowData.uclIsDoOrderCheck = True
        Me.dgvShowData.uclIsSortable = False
        Me.dgvShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgvShowData.uclNonVisibleColIndex = ""
        Me.dgvShowData.uclReadOnly = False
        Me.dgvShowData.uclShowCellBorder = False
        Me.dgvShowData.uclSortColIndex = ""
        Me.dgvShowData.uclTreeMode = False
        Me.dgvShowData.uclVisibleColIndex = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvShowData)
        Me.Panel2.Location = New System.Drawing.Point(0, 113)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(972, 474)
        Me.Panel2.TabIndex = 3
        '
        'PUBPtDisabilityUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(972, 587)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Name = "PUBPtDisabilityUI"
        Me.TabText = "病患殘障記錄檔"
        Me.Text = "病患殘障記錄檔"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPatientDisabilityMemo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents lblMemo As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDisabilityDegreeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDisabilityTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtChartNo As Syscom.Client.UCL.UCLChartNoUC
    'Friend WithEvents txtPatientDisabilityNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Public WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtPatientDisabilityNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvShowData As Syscom.Client.UCL.UCLDataGridViewUC
End Class
