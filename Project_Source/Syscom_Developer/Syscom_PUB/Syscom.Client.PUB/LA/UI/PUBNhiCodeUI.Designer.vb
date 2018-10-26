<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBNhiCodeUI
    Inherits Syscom.Client.UCL.BaseFormUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBNhiCodeUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Tlp = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMajorcareCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txtInsuEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtInsuName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtPrice = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInsuCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dtEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkIsLabdiscount = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbInsuAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbInsuOrderTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtDeptAddRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblDeptAddRatio = New System.Windows.Forms.Label()
        Me.lblKidAddRatio1 = New System.Windows.Forms.Label()
        Me.txtKidAddRatio1 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblKidAddRatio2 = New System.Windows.Forms.Label()
        Me.txtKidAddRatio2 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblKidAddRatio3 = New System.Windows.Forms.Label()
        Me.txtKidAddRatio3 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblKidAddRatio4 = New System.Windows.Forms.Label()
        Me.txtKidAddRatio4 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblKidAddRatio5 = New System.Windows.Forms.Label()
        Me.txtKidAddRatio5 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDentalAddRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblDentalAddRatio = New System.Windows.Forms.Label()
        Me.txtEmgAddRatio = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblEmgAddRatio = New System.Windows.Forms.Label()
        Me.cbIsEmgAdd = New System.Windows.Forms.CheckBox()
        Me.cbIsKidAdd = New System.Windows.Forms.CheckBox()
        Me.cbIsDentalAdd = New System.Windows.Forms.CheckBox()
        Me.cbIsHolidayAdd = New System.Windows.Forms.CheckBox()
        Me.ckbIsDeptAdd = New System.Windows.Forms.CheckBox()
        Me.txtDeptCodeset = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_QueryDept = New System.Windows.Forms.Button()
        Me.panelButton = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.dgvData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.panelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Tlp.SuspendLayout()
        Me.panelButton.SuspendLayout()
        Me.panelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelTop
        '
        Me.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelTop.Controls.Add(Me.Panel1)
        Me.panelTop.Controls.Add(Me.panelButton)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(1028, 336)
        Me.panelTop.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Tlp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 296)
        Me.Panel1.TabIndex = 2
        '
        'Tlp
        '
        Me.Tlp.ColumnCount = 9
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp.Controls.Add(Me.Label1, 0, 0)
        Me.Tlp.Controls.Add(Me.Label2, 0, 1)
        Me.Tlp.Controls.Add(Me.Label3, 0, 2)
        Me.Tlp.Controls.Add(Me.cmbMajorcareCode, 7, 3)
        Me.Tlp.Controls.Add(Me.Label4, 0, 3)
        Me.Tlp.Controls.Add(Me.dtEffectDate, 1, 0)
        Me.Tlp.Controls.Add(Me.txtInsuEnName, 1, 1)
        Me.Tlp.Controls.Add(Me.txtInsuName, 1, 2)
        Me.Tlp.Controls.Add(Me.txtPrice, 1, 3)
        Me.Tlp.Controls.Add(Me.Label5, 2, 0)
        Me.Tlp.Controls.Add(Me.txtInsuCode, 3, 0)
        Me.Tlp.Controls.Add(Me.dtEndDate, 5, 0)
        Me.Tlp.Controls.Add(Me.Label7, 6, 1)
        Me.Tlp.Controls.Add(Me.Label9, 6, 3)
        Me.Tlp.Controls.Add(Me.chkIsLabdiscount, 6, 0)
        Me.Tlp.Controls.Add(Me.Label6, 4, 0)
        Me.Tlp.Controls.Add(Me.cmbInsuAccountId, 7, 1)
        Me.Tlp.Controls.Add(Me.Label8, 6, 2)
        Me.Tlp.Controls.Add(Me.cmbInsuOrderTypeId, 7, 2)
        Me.Tlp.Controls.Add(Me.txtDeptAddRatio, 7, 6)
        Me.Tlp.Controls.Add(Me.lblDeptAddRatio, 6, 6)
        Me.Tlp.Controls.Add(Me.lblKidAddRatio1, 0, 7)
        Me.Tlp.Controls.Add(Me.txtKidAddRatio1, 2, 7)
        Me.Tlp.Controls.Add(Me.lblKidAddRatio2, 3, 7)
        Me.Tlp.Controls.Add(Me.txtKidAddRatio2, 4, 7)
        Me.Tlp.Controls.Add(Me.lblKidAddRatio3, 5, 7)
        Me.Tlp.Controls.Add(Me.txtKidAddRatio3, 7, 7)
        Me.Tlp.Controls.Add(Me.lblKidAddRatio4, 0, 8)
        Me.Tlp.Controls.Add(Me.txtKidAddRatio4, 2, 8)
        Me.Tlp.Controls.Add(Me.lblKidAddRatio5, 3, 8)
        Me.Tlp.Controls.Add(Me.txtKidAddRatio5, 4, 8)
        Me.Tlp.Controls.Add(Me.txtDentalAddRatio, 4, 6)
        Me.Tlp.Controls.Add(Me.lblDentalAddRatio, 3, 6)
        Me.Tlp.Controls.Add(Me.txtEmgAddRatio, 2, 6)
        Me.Tlp.Controls.Add(Me.lblEmgAddRatio, 1, 6)
        Me.Tlp.Controls.Add(Me.cbIsEmgAdd, 1, 4)
        Me.Tlp.Controls.Add(Me.cbIsKidAdd, 2, 4)
        Me.Tlp.Controls.Add(Me.cbIsDentalAdd, 3, 4)
        Me.Tlp.Controls.Add(Me.cbIsHolidayAdd, 4, 4)
        Me.Tlp.Controls.Add(Me.ckbIsDeptAdd, 5, 4)
        Me.Tlp.Controls.Add(Me.txtDeptCodeset, 2, 5)
        Me.Tlp.Controls.Add(Me.btn_QueryDept, 0, 5)
        Me.Tlp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tlp.Location = New System.Drawing.Point(0, 0)
        Me.Tlp.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Tlp.Name = "Tlp"
        Me.Tlp.RowCount = 9
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.71875!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1673!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1673!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.92776!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.06844!))
        Me.Tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.Tlp.Size = New System.Drawing.Size(1024, 296)
        Me.Tlp.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*生效日"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "英文名稱"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "中文名稱"
        '
        'cmbMajorcareCode
        '
        Me.cmbMajorcareCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMajorcareCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMajorcareCode.DropDownWidth = 20
        Me.cmbMajorcareCode.DroppedDown = False
        Me.cmbMajorcareCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMajorcareCode.Location = New System.Drawing.Point(908, 100)
        Me.cmbMajorcareCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbMajorcareCode.Name = "cmbMajorcareCode"
        Me.cmbMajorcareCode.SelectedIndex = -1
        Me.cmbMajorcareCode.SelectedItem = Nothing
        Me.cmbMajorcareCode.SelectedText = ""
        Me.cmbMajorcareCode.SelectedValue = ""
        Me.cmbMajorcareCode.SelectionStart = 0
        Me.cmbMajorcareCode.Size = New System.Drawing.Size(100, 24)
        Me.cmbMajorcareCode.TabIndex = 10
        Me.cmbMajorcareCode.uclDisplayIndex = "0,1"
        Me.cmbMajorcareCode.uclIsAutoClear = True
        Me.cmbMajorcareCode.uclIsFirstItemEmpty = True
        Me.cmbMajorcareCode.uclIsTextMode = False
        Me.cmbMajorcareCode.uclShowMsg = False
        Me.cmbMajorcareCode.uclValueIndex = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 104)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "單價"
        '
        'dtEffectDate
        '
        Me.dtEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtEffectDate.Location = New System.Drawing.Point(83, 3)
        Me.dtEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtEffectDate.Name = "dtEffectDate"
        Me.dtEffectDate.Size = New System.Drawing.Size(109, 25)
        Me.dtEffectDate.TabIndex = 1
        Me.dtEffectDate.uclReadOnly = False
        '
        'txtInsuEnName
        '
        Me.txtInsuEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp.SetColumnSpan(Me.txtInsuEnName, 5)
        Me.txtInsuEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtInsuEnName.Location = New System.Drawing.Point(83, 34)
        Me.txtInsuEnName.MaxLength = 10
        Me.txtInsuEnName.Name = "txtInsuEnName"
        Me.txtInsuEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInsuEnName.SelectionStart = 0
        Me.txtInsuEnName.Size = New System.Drawing.Size(640, 27)
        Me.txtInsuEnName.TabIndex = 5
        Me.txtInsuEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtInsuEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtInsuEnName.ToolTipTag = Nothing
        Me.txtInsuEnName.uclDollarSign = False
        Me.txtInsuEnName.uclDotCount = 0
        Me.txtInsuEnName.uclIntCount = 2
        Me.txtInsuEnName.uclMinus = False
        Me.txtInsuEnName.uclReadOnly = False
        Me.txtInsuEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtInsuEnName.uclTrimZero = True
        '
        'txtInsuName
        '
        Me.txtInsuName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp.SetColumnSpan(Me.txtInsuName, 5)
        Me.txtInsuName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtInsuName.Location = New System.Drawing.Point(83, 67)
        Me.txtInsuName.MaxLength = 10
        Me.txtInsuName.Name = "txtInsuName"
        Me.txtInsuName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInsuName.SelectionStart = 0
        Me.txtInsuName.Size = New System.Drawing.Size(640, 27)
        Me.txtInsuName.TabIndex = 7
        Me.txtInsuName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtInsuName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtInsuName.ToolTipTag = Nothing
        Me.txtInsuName.uclDollarSign = False
        Me.txtInsuName.uclDotCount = 0
        Me.txtInsuName.uclIntCount = 2
        Me.txtInsuName.uclMinus = False
        Me.txtInsuName.uclReadOnly = False
        Me.txtInsuName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtInsuName.uclTrimZero = True
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPrice.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPrice.Location = New System.Drawing.Point(83, 100)
        Me.txtPrice.MaxLength = 10
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPrice.SelectionStart = 0
        Me.txtPrice.Size = New System.Drawing.Size(109, 25)
        Me.txtPrice.TabIndex = 9
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPrice.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPrice.ToolTipTag = Nothing
        Me.txtPrice.uclDollarSign = False
        Me.txtPrice.uclDotCount = 4
        Me.txtPrice.uclIntCount = 14
        Me.txtPrice.uclMinus = False
        Me.txtPrice.uclReadOnly = False
        Me.txtPrice.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPrice.uclTrimZero = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(266, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "*健保碼"
        '
        'txtInsuCode
        '
        Me.txtInsuCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtInsuCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtInsuCode.Location = New System.Drawing.Point(336, 3)
        Me.txtInsuCode.MaxLength = 10
        Me.txtInsuCode.Name = "txtInsuCode"
        Me.txtInsuCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInsuCode.SelectionStart = 0
        Me.txtInsuCode.Size = New System.Drawing.Size(97, 25)
        Me.txtInsuCode.TabIndex = 2
        Me.txtInsuCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtInsuCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtInsuCode.ToolTipTag = Nothing
        Me.txtInsuCode.uclDollarSign = False
        Me.txtInsuCode.uclDotCount = 0
        Me.txtInsuCode.uclIntCount = 2
        Me.txtInsuCode.uclMinus = False
        Me.txtInsuCode.uclReadOnly = False
        Me.txtInsuCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtInsuCode.uclTrimZero = True
        '
        'dtEndDate
        '
        Me.dtEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtEndDate.Location = New System.Drawing.Point(685, 3)
        Me.dtEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(110, 25)
        Me.dtEndDate.TabIndex = 3
        Me.dtEndDate.uclReadOnly = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(801, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "保險費用項目"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(801, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "特定治療項目"
        '
        'chkIsLabdiscount
        '
        Me.chkIsLabdiscount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsLabdiscount.AutoSize = True
        Me.Tlp.SetColumnSpan(Me.chkIsLabdiscount, 2)
        Me.chkIsLabdiscount.Location = New System.Drawing.Point(801, 5)
        Me.chkIsLabdiscount.Name = "chkIsLabdiscount"
        Me.chkIsLabdiscount.Size = New System.Drawing.Size(149, 20)
        Me.chkIsLabdiscount.TabIndex = 4
        Me.chkIsLabdiscount.Text = "檢查折扣(健保用)"
        Me.chkIsLabdiscount.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(623, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "停止日"
        '
        'cmbInsuAccountId
        '
        Me.cmbInsuAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbInsuAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbInsuAccountId.DropDownWidth = 20
        Me.cmbInsuAccountId.DroppedDown = False
        Me.cmbInsuAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbInsuAccountId.Location = New System.Drawing.Point(908, 35)
        Me.cmbInsuAccountId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbInsuAccountId.Name = "cmbInsuAccountId"
        Me.cmbInsuAccountId.SelectedIndex = -1
        Me.cmbInsuAccountId.SelectedItem = Nothing
        Me.cmbInsuAccountId.SelectedText = ""
        Me.cmbInsuAccountId.SelectedValue = ""
        Me.cmbInsuAccountId.SelectionStart = 0
        Me.cmbInsuAccountId.Size = New System.Drawing.Size(100, 24)
        Me.cmbInsuAccountId.TabIndex = 6
        Me.cmbInsuAccountId.uclDisplayIndex = "0,1"
        Me.cmbInsuAccountId.uclIsAutoClear = True
        Me.cmbInsuAccountId.uclIsFirstItemEmpty = True
        Me.cmbInsuAccountId.uclIsTextMode = False
        Me.cmbInsuAccountId.uclShowMsg = False
        Me.cmbInsuAccountId.uclValueIndex = "0"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(801, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "保險醫令類別"
        '
        'cmbInsuOrderTypeId
        '
        Me.cmbInsuOrderTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbInsuOrderTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbInsuOrderTypeId.DropDownWidth = 20
        Me.cmbInsuOrderTypeId.DroppedDown = False
        Me.cmbInsuOrderTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbInsuOrderTypeId.Location = New System.Drawing.Point(908, 68)
        Me.cmbInsuOrderTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbInsuOrderTypeId.Name = "cmbInsuOrderTypeId"
        Me.cmbInsuOrderTypeId.SelectedIndex = -1
        Me.cmbInsuOrderTypeId.SelectedItem = Nothing
        Me.cmbInsuOrderTypeId.SelectedText = ""
        Me.cmbInsuOrderTypeId.SelectedValue = ""
        Me.cmbInsuOrderTypeId.SelectionStart = 0
        Me.cmbInsuOrderTypeId.Size = New System.Drawing.Size(100, 24)
        Me.cmbInsuOrderTypeId.TabIndex = 8
        Me.cmbInsuOrderTypeId.uclDisplayIndex = "0,1"
        Me.cmbInsuOrderTypeId.uclIsAutoClear = True
        Me.cmbInsuOrderTypeId.uclIsFirstItemEmpty = True
        Me.cmbInsuOrderTypeId.uclIsTextMode = False
        Me.cmbInsuOrderTypeId.uclShowMsg = False
        Me.cmbInsuOrderTypeId.uclValueIndex = "0"
        '
        'txtDeptAddRatio
        '
        Me.txtDeptAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptAddRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptAddRatio.Location = New System.Drawing.Point(911, 195)
        Me.txtDeptAddRatio.MaxLength = 10
        Me.txtDeptAddRatio.Name = "txtDeptAddRatio"
        Me.txtDeptAddRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptAddRatio.SelectionStart = 0
        Me.txtDeptAddRatio.Size = New System.Drawing.Size(103, 27)
        Me.txtDeptAddRatio.TabIndex = 19
        Me.txtDeptAddRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptAddRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptAddRatio.ToolTipTag = Nothing
        Me.txtDeptAddRatio.uclDollarSign = False
        Me.txtDeptAddRatio.uclDotCount = 4
        Me.txtDeptAddRatio.uclIntCount = 14
        Me.txtDeptAddRatio.uclMinus = False
        Me.txtDeptAddRatio.uclReadOnly = False
        Me.txtDeptAddRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtDeptAddRatio.uclTrimZero = True
        '
        'lblDeptAddRatio
        '
        Me.lblDeptAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptAddRatio.AutoSize = True
        Me.lblDeptAddRatio.Location = New System.Drawing.Point(816, 201)
        Me.lblDeptAddRatio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeptAddRatio.Name = "lblDeptAddRatio"
        Me.lblDeptAddRatio.Size = New System.Drawing.Size(88, 16)
        Me.lblDeptAddRatio.TabIndex = 25
        Me.lblDeptAddRatio.Text = "科別加成率"
        '
        'lblKidAddRatio1
        '
        Me.lblKidAddRatio1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKidAddRatio1.AutoSize = True
        Me.Tlp.SetColumnSpan(Me.lblKidAddRatio1, 2)
        Me.lblKidAddRatio1.Location = New System.Drawing.Point(44, 236)
        Me.lblKidAddRatio1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKidAddRatio1.Name = "lblKidAddRatio1"
        Me.lblKidAddRatio1.Size = New System.Drawing.Size(170, 16)
        Me.lblKidAddRatio1.TabIndex = 27
        Me.lblKidAddRatio1.Text = "兒童加成率(未滿6個月)"
        '
        'txtKidAddRatio1
        '
        Me.txtKidAddRatio1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKidAddRatio1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKidAddRatio1.Location = New System.Drawing.Point(221, 231)
        Me.txtKidAddRatio1.MaxLength = 10
        Me.txtKidAddRatio1.Name = "txtKidAddRatio1"
        Me.txtKidAddRatio1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKidAddRatio1.SelectionStart = 0
        Me.txtKidAddRatio1.Size = New System.Drawing.Size(108, 27)
        Me.txtKidAddRatio1.TabIndex = 20
        Me.txtKidAddRatio1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKidAddRatio1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKidAddRatio1.ToolTipTag = Nothing
        Me.txtKidAddRatio1.uclDollarSign = False
        Me.txtKidAddRatio1.uclDotCount = 4
        Me.txtKidAddRatio1.uclIntCount = 14
        Me.txtKidAddRatio1.uclMinus = False
        Me.txtKidAddRatio1.uclReadOnly = False
        Me.txtKidAddRatio1.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKidAddRatio1.uclTrimZero = True
        '
        'lblKidAddRatio2
        '
        Me.lblKidAddRatio2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKidAddRatio2.AutoSize = True
        Me.lblKidAddRatio2.Location = New System.Drawing.Point(337, 236)
        Me.lblKidAddRatio2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKidAddRatio2.Name = "lblKidAddRatio2"
        Me.lblKidAddRatio2.Size = New System.Drawing.Size(226, 16)
        Me.lblKidAddRatio2.TabIndex = 29
        Me.lblKidAddRatio2.Text = "兒童加成率(滿6個月且小於2歲)"
        '
        'txtKidAddRatio2
        '
        Me.txtKidAddRatio2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKidAddRatio2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKidAddRatio2.Location = New System.Drawing.Point(570, 231)
        Me.txtKidAddRatio2.MaxLength = 10
        Me.txtKidAddRatio2.Name = "txtKidAddRatio2"
        Me.txtKidAddRatio2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKidAddRatio2.SelectionStart = 0
        Me.txtKidAddRatio2.Size = New System.Drawing.Size(109, 27)
        Me.txtKidAddRatio2.TabIndex = 21
        Me.txtKidAddRatio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKidAddRatio2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKidAddRatio2.ToolTipTag = Nothing
        Me.txtKidAddRatio2.uclDollarSign = False
        Me.txtKidAddRatio2.uclDotCount = 4
        Me.txtKidAddRatio2.uclIntCount = 14
        Me.txtKidAddRatio2.uclMinus = False
        Me.txtKidAddRatio2.uclReadOnly = False
        Me.txtKidAddRatio2.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKidAddRatio2.uclTrimZero = True
        '
        'lblKidAddRatio3
        '
        Me.lblKidAddRatio3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKidAddRatio3.AutoSize = True
        Me.Tlp.SetColumnSpan(Me.lblKidAddRatio3, 2)
        Me.lblKidAddRatio3.Location = New System.Drawing.Point(753, 236)
        Me.lblKidAddRatio3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKidAddRatio3.Name = "lblKidAddRatio3"
        Me.lblKidAddRatio3.Size = New System.Drawing.Size(151, 16)
        Me.lblKidAddRatio3.TabIndex = 31
        Me.lblKidAddRatio3.Text = "兒童加成率(2歲-6歲)"
        '
        'txtKidAddRatio3
        '
        Me.txtKidAddRatio3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKidAddRatio3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKidAddRatio3.Location = New System.Drawing.Point(911, 231)
        Me.txtKidAddRatio3.MaxLength = 10
        Me.txtKidAddRatio3.Name = "txtKidAddRatio3"
        Me.txtKidAddRatio3.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKidAddRatio3.SelectionStart = 0
        Me.txtKidAddRatio3.Size = New System.Drawing.Size(103, 27)
        Me.txtKidAddRatio3.TabIndex = 22
        Me.txtKidAddRatio3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKidAddRatio3.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKidAddRatio3.ToolTipTag = Nothing
        Me.txtKidAddRatio3.uclDollarSign = False
        Me.txtKidAddRatio3.uclDotCount = 4
        Me.txtKidAddRatio3.uclIntCount = 14
        Me.txtKidAddRatio3.uclMinus = False
        Me.txtKidAddRatio3.uclReadOnly = False
        Me.txtKidAddRatio3.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKidAddRatio3.uclTrimZero = True
        '
        'lblKidAddRatio4
        '
        Me.lblKidAddRatio4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKidAddRatio4.AutoSize = True
        Me.Tlp.SetColumnSpan(Me.lblKidAddRatio4, 2)
        Me.lblKidAddRatio4.Location = New System.Drawing.Point(4, 271)
        Me.lblKidAddRatio4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKidAddRatio4.Name = "lblKidAddRatio4"
        Me.lblKidAddRatio4.Size = New System.Drawing.Size(210, 16)
        Me.lblKidAddRatio4.TabIndex = 33
        Me.lblKidAddRatio4.Text = "兒童加成率(小於等於48個月)"
        '
        'txtKidAddRatio4
        '
        Me.txtKidAddRatio4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKidAddRatio4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKidAddRatio4.Location = New System.Drawing.Point(221, 266)
        Me.txtKidAddRatio4.MaxLength = 10
        Me.txtKidAddRatio4.Name = "txtKidAddRatio4"
        Me.txtKidAddRatio4.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKidAddRatio4.SelectionStart = 0
        Me.txtKidAddRatio4.Size = New System.Drawing.Size(108, 27)
        Me.txtKidAddRatio4.TabIndex = 23
        Me.txtKidAddRatio4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKidAddRatio4.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKidAddRatio4.ToolTipTag = Nothing
        Me.txtKidAddRatio4.uclDollarSign = False
        Me.txtKidAddRatio4.uclDotCount = 4
        Me.txtKidAddRatio4.uclIntCount = 14
        Me.txtKidAddRatio4.uclMinus = False
        Me.txtKidAddRatio4.uclReadOnly = False
        Me.txtKidAddRatio4.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKidAddRatio4.uclTrimZero = True
        '
        'lblKidAddRatio5
        '
        Me.lblKidAddRatio5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblKidAddRatio5.AutoSize = True
        Me.lblKidAddRatio5.Location = New System.Drawing.Point(409, 271)
        Me.lblKidAddRatio5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKidAddRatio5.Name = "lblKidAddRatio5"
        Me.lblKidAddRatio5.Size = New System.Drawing.Size(154, 16)
        Me.lblKidAddRatio5.TabIndex = 35
        Me.lblKidAddRatio5.Text = "兒童加成率(4歲以下)"
        '
        'txtKidAddRatio5
        '
        Me.txtKidAddRatio5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtKidAddRatio5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtKidAddRatio5.Location = New System.Drawing.Point(570, 266)
        Me.txtKidAddRatio5.MaxLength = 10
        Me.txtKidAddRatio5.Name = "txtKidAddRatio5"
        Me.txtKidAddRatio5.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtKidAddRatio5.SelectionStart = 0
        Me.txtKidAddRatio5.Size = New System.Drawing.Size(108, 27)
        Me.txtKidAddRatio5.TabIndex = 24
        Me.txtKidAddRatio5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtKidAddRatio5.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtKidAddRatio5.ToolTipTag = Nothing
        Me.txtKidAddRatio5.uclDollarSign = False
        Me.txtKidAddRatio5.uclDotCount = 4
        Me.txtKidAddRatio5.uclIntCount = 14
        Me.txtKidAddRatio5.uclMinus = False
        Me.txtKidAddRatio5.uclReadOnly = False
        Me.txtKidAddRatio5.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtKidAddRatio5.uclTrimZero = True
        '
        'txtDentalAddRatio
        '
        Me.txtDentalAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDentalAddRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDentalAddRatio.Location = New System.Drawing.Point(570, 195)
        Me.txtDentalAddRatio.MaxLength = 10
        Me.txtDentalAddRatio.Name = "txtDentalAddRatio"
        Me.txtDentalAddRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDentalAddRatio.SelectionStart = 0
        Me.txtDentalAddRatio.Size = New System.Drawing.Size(109, 27)
        Me.txtDentalAddRatio.TabIndex = 18
        Me.txtDentalAddRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDentalAddRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDentalAddRatio.ToolTipTag = Nothing
        Me.txtDentalAddRatio.uclDollarSign = False
        Me.txtDentalAddRatio.uclDotCount = 4
        Me.txtDentalAddRatio.uclIntCount = 14
        Me.txtDentalAddRatio.uclMinus = False
        Me.txtDentalAddRatio.uclReadOnly = False
        Me.txtDentalAddRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtDentalAddRatio.uclTrimZero = True
        '
        'lblDentalAddRatio
        '
        Me.lblDentalAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDentalAddRatio.AutoSize = True
        Me.lblDentalAddRatio.Location = New System.Drawing.Point(443, 201)
        Me.lblDentalAddRatio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDentalAddRatio.Name = "lblDentalAddRatio"
        Me.lblDentalAddRatio.Size = New System.Drawing.Size(120, 16)
        Me.lblDentalAddRatio.TabIndex = 23
        Me.lblDentalAddRatio.Text = "牙科轉診加成率"
        '
        'txtEmgAddRatio
        '
        Me.txtEmgAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtEmgAddRatio.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtEmgAddRatio.Location = New System.Drawing.Point(221, 195)
        Me.txtEmgAddRatio.MaxLength = 10
        Me.txtEmgAddRatio.Name = "txtEmgAddRatio"
        Me.txtEmgAddRatio.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmgAddRatio.SelectionStart = 0
        Me.txtEmgAddRatio.Size = New System.Drawing.Size(109, 27)
        Me.txtEmgAddRatio.TabIndex = 17
        Me.txtEmgAddRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtEmgAddRatio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtEmgAddRatio.ToolTipTag = Nothing
        Me.txtEmgAddRatio.uclDollarSign = False
        Me.txtEmgAddRatio.uclDotCount = 4
        Me.txtEmgAddRatio.uclIntCount = 14
        Me.txtEmgAddRatio.uclMinus = False
        Me.txtEmgAddRatio.uclReadOnly = False
        Me.txtEmgAddRatio.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtEmgAddRatio.uclTrimZero = True
        '
        'lblEmgAddRatio
        '
        Me.lblEmgAddRatio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEmgAddRatio.AutoSize = True
        Me.lblEmgAddRatio.Location = New System.Drawing.Point(126, 201)
        Me.lblEmgAddRatio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmgAddRatio.Name = "lblEmgAddRatio"
        Me.lblEmgAddRatio.Size = New System.Drawing.Size(88, 16)
        Me.lblEmgAddRatio.TabIndex = 21
        Me.lblEmgAddRatio.Text = "急件加成率"
        '
        'cbIsEmgAdd
        '
        Me.cbIsEmgAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbIsEmgAdd.AutoSize = True
        Me.cbIsEmgAdd.Location = New System.Drawing.Point(124, 134)
        Me.cbIsEmgAdd.Name = "cbIsEmgAdd"
        Me.cbIsEmgAdd.Size = New System.Drawing.Size(91, 20)
        Me.cbIsEmgAdd.TabIndex = 11
        Me.cbIsEmgAdd.Text = "急診加成"
        Me.cbIsEmgAdd.UseVisualStyleBackColor = True
        Me.cbIsEmgAdd.Visible = False
        '
        'cbIsKidAdd
        '
        Me.cbIsKidAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbIsKidAdd.AutoSize = True
        Me.cbIsKidAdd.Location = New System.Drawing.Point(221, 134)
        Me.cbIsKidAdd.Name = "cbIsKidAdd"
        Me.cbIsKidAdd.Size = New System.Drawing.Size(91, 20)
        Me.cbIsKidAdd.TabIndex = 12
        Me.cbIsKidAdd.Text = "兒童加成"
        Me.cbIsKidAdd.UseVisualStyleBackColor = True
        Me.cbIsKidAdd.Visible = False
        '
        'cbIsDentalAdd
        '
        Me.cbIsDentalAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbIsDentalAdd.AutoSize = True
        Me.cbIsDentalAdd.Location = New System.Drawing.Point(336, 134)
        Me.cbIsDentalAdd.Name = "cbIsDentalAdd"
        Me.cbIsDentalAdd.Size = New System.Drawing.Size(123, 20)
        Me.cbIsDentalAdd.TabIndex = 13
        Me.cbIsDentalAdd.Text = "牙科轉診加成"
        Me.cbIsDentalAdd.UseVisualStyleBackColor = True
        Me.cbIsDentalAdd.Visible = False
        '
        'cbIsHolidayAdd
        '
        Me.cbIsHolidayAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbIsHolidayAdd.AutoSize = True
        Me.cbIsHolidayAdd.Location = New System.Drawing.Point(570, 134)
        Me.cbIsHolidayAdd.Name = "cbIsHolidayAdd"
        Me.cbIsHolidayAdd.Size = New System.Drawing.Size(91, 20)
        Me.cbIsHolidayAdd.TabIndex = 14
        Me.cbIsHolidayAdd.Text = "假日加成"
        Me.cbIsHolidayAdd.UseVisualStyleBackColor = True
        Me.cbIsHolidayAdd.Visible = False
        '
        'ckbIsDeptAdd
        '
        Me.ckbIsDeptAdd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsDeptAdd.AutoSize = True
        Me.ckbIsDeptAdd.Location = New System.Drawing.Point(685, 134)
        Me.ckbIsDeptAdd.Name = "ckbIsDeptAdd"
        Me.ckbIsDeptAdd.Size = New System.Drawing.Size(91, 20)
        Me.ckbIsDeptAdd.TabIndex = 15
        Me.ckbIsDeptAdd.Text = "科別加成"
        Me.ckbIsDeptAdd.UseVisualStyleBackColor = True
        Me.ckbIsDeptAdd.Visible = False
        '
        'txtDeptCodeset
        '
        Me.txtDeptCodeset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp.SetColumnSpan(Me.txtDeptCodeset, 5)
        Me.txtDeptCodeset.Enabled = False
        Me.txtDeptCodeset.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptCodeset.Location = New System.Drawing.Point(221, 163)
        Me.txtDeptCodeset.MaxLength = 10
        Me.txtDeptCodeset.Name = "txtDeptCodeset"
        Me.txtDeptCodeset.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptCodeset.SelectionStart = 0
        Me.txtDeptCodeset.Size = New System.Drawing.Size(611, 26)
        Me.txtDeptCodeset.TabIndex = 16
        Me.txtDeptCodeset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptCodeset.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptCodeset.ToolTipTag = Nothing
        Me.txtDeptCodeset.uclDollarSign = False
        Me.txtDeptCodeset.uclDotCount = 0
        Me.txtDeptCodeset.uclIntCount = 2
        Me.txtDeptCodeset.uclMinus = False
        Me.txtDeptCodeset.uclReadOnly = False
        Me.txtDeptCodeset.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptCodeset.uclTrimZero = True
        '
        'btn_QueryDept
        '
        Me.btn_QueryDept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Tlp.SetColumnSpan(Me.btn_QueryDept, 2)
        Me.btn_QueryDept.Location = New System.Drawing.Point(47, 163)
        Me.btn_QueryDept.Name = "btn_QueryDept"
        Me.btn_QueryDept.Size = New System.Drawing.Size(168, 25)
        Me.btn_QueryDept.TabIndex = 1
        Me.btn_QueryDept.Text = "科別加成的健保科別"
        Me.btn_QueryDept.UseVisualStyleBackColor = True
        '
        'panelButton
        '
        Me.panelButton.Controls.Add(Me.btnDown)
        Me.panelButton.Controls.Add(Me.btnUp)
        Me.panelButton.Controls.Add(Me.btnDelete)
        Me.panelButton.Controls.Add(Me.btn_Clear)
        Me.panelButton.Controls.Add(Me.btn_OK)
        Me.panelButton.Controls.Add(Me.btn_Query)
        Me.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelButton.Location = New System.Drawing.Point(0, 296)
        Me.panelButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.panelButton.Name = "panelButton"
        Me.panelButton.Size = New System.Drawing.Size(1024, 36)
        Me.panelButton.TabIndex = 1
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(114, 6)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(90, 28)
        Me.btnDown.TabIndex = 20
        Me.btnDown.Text = "下一筆"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(10, 6)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(90, 28)
        Me.btnUp.TabIndex = 19
        Me.btnUp.Text = "上一筆"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(521, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 28)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "SF12-刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(921, 6)
        Me.btn_Clear.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 17
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(821, 6)
        Me.btn_OK.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(90, 28)
        Me.btn_OK.TabIndex = 16
        Me.btn_OK.Text = "F12-確定"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(721, 6)
        Me.btn_Query.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 15
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'panelBottom
        '
        Me.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelBottom.Controls.Add(Me.dgvData)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBottom.Location = New System.Drawing.Point(0, 336)
        Me.panelBottom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1028, 397)
        Me.panelBottom.TabIndex = 1
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToOrderColumns = False
        Me.dgvData.AllowUserToResizeColumns = True
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.AutoScroll = True
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeight = 4
        Me.dgvData.ColumnHeadersVisible = True
        Me.dgvData.CurrentCell = Nothing
        Me.dgvData.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvData.MultiSelect = False
        Me.dgvData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersWidth = 41
        Me.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1026, 395)
        Me.dgvData.TabIndex = 0
        Me.dgvData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvData.uclBatchColIndex = ""
        Me.dgvData.uclClickToCheck = False
        Me.dgvData.uclColumnAlignment = ""
        Me.dgvData.uclColumnCheckBox = False
        Me.dgvData.uclColumnControlType = ""
        Me.dgvData.uclColumnWidth = ""
        Me.dgvData.uclDoCellEnter = True
        Me.dgvData.uclHasNewRow = False
        Me.dgvData.uclHeaderText = ""
        Me.dgvData.uclIsAlternatingRowsColors = True
        Me.dgvData.uclIsComboBoxGridQuery = True
        Me.dgvData.uclIsComboxClickTriggerDropDown = False
        Me.dgvData.uclIsDoOrderCheck = True
        Me.dgvData.uclIsSortable = False
        Me.dgvData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgvData.uclNonVisibleColIndex = ""
        Me.dgvData.uclReadOnly = False
        Me.dgvData.uclShowCellBorder = False
        Me.dgvData.uclSortColIndex = ""
        Me.dgvData.uclTreeMode = False
        Me.dgvData.uclVisibleColIndex = ""
        '
        'PUBNhiCodeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 733)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelTop)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "PUBNhiCodeUI"
        Me.TabText = "PUBNhiCodeUI"
        Me.Text = "PUBNhiCodeUI"
        Me.panelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Tlp.ResumeLayout(False)
        Me.Tlp.PerformLayout()
        Me.panelButton.ResumeLayout(False)
        Me.panelBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelTop As System.Windows.Forms.Panel
    Friend WithEvents panelButton As System.Windows.Forms.Panel
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents Tlp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents panelBottom As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtInsuEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtInsuName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtPrice As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtInsuCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cbIsEmgAdd As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsKidAdd As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsDentalAdd As System.Windows.Forms.CheckBox
    Friend WithEvents cbIsHolidayAdd As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbInsuAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbInsuOrderTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbMajorcareCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dgvData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents chkIsLabdiscount As System.Windows.Forms.CheckBox
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ckbIsDeptAdd As System.Windows.Forms.CheckBox
    Friend WithEvents lblEmgAddRatio As System.Windows.Forms.Label
    Friend WithEvents lblDentalAddRatio As System.Windows.Forms.Label
    Friend WithEvents txtEmgAddRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDentalAddRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtKidAddRatio1 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDeptAddRatio As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDeptAddRatio As System.Windows.Forms.Label
    Friend WithEvents lblKidAddRatio1 As System.Windows.Forms.Label
    Friend WithEvents lblKidAddRatio4 As System.Windows.Forms.Label
    Friend WithEvents lblKidAddRatio3 As System.Windows.Forms.Label
    Friend WithEvents txtKidAddRatio2 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblKidAddRatio2 As System.Windows.Forms.Label
    Friend WithEvents txtKidAddRatio3 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtKidAddRatio4 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblKidAddRatio5 As System.Windows.Forms.Label
    Friend WithEvents txtKidAddRatio5 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDeptCodeset As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_QueryDept As System.Windows.Forms.Button
End Class
