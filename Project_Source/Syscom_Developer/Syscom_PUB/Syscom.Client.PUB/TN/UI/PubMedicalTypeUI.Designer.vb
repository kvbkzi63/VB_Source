<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubMedicalTypeUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PubMedicalTypeUI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txtEMGSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtOPDSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtIPDSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtREHSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtUROSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtENTSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtMEDSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtSURSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cboCaseTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cboICMedicalTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtCardSn = New System.Windows.Forms.TextBox()
        Me.cboPartCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtMedicalTypeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMedicalTypeId = New System.Windows.Forms.TextBox()
        Me.cboMedicalTypeCtrlId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtPEDSort = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chkIsExamine = New System.Windows.Forms.CheckBox()
        Me.chkIsRegisterFee = New System.Windows.Forms.CheckBox()
        Me.chkDc = New System.Windows.Forms.CheckBox()
        Me.chkIsPhaServices = New System.Windows.Forms.CheckBox()
        Me.cboDisidentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cboContractCode1 = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cboContractCode2 = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 242)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 499)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 462)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 462)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlp_Main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 242)
        Me.Panel1.TabIndex = 0
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 8
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.57269!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40822!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.42584!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.95007!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.13693!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86307!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.72199!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87137!))
        Me.tlp_Main.Controls.Add(Me.txtEMGSort, 7, 4)
        Me.tlp_Main.Controls.Add(Me.txtOPDSort, 5, 4)
        Me.tlp_Main.Controls.Add(Me.txtIPDSort, 3, 4)
        Me.tlp_Main.Controls.Add(Me.txtREHSort, 1, 4)
        Me.tlp_Main.Controls.Add(Me.txtUROSort, 7, 3)
        Me.tlp_Main.Controls.Add(Me.txtENTSort, 5, 3)
        Me.tlp_Main.Controls.Add(Me.txtMEDSort, 3, 3)
        Me.tlp_Main.Controls.Add(Me.txtSURSort, 1, 3)
        Me.tlp_Main.Controls.Add(Me.cboCaseTypeId, 3, 2)
        Me.tlp_Main.Controls.Add(Me.cboICMedicalTypeId, 1, 2)
        Me.tlp_Main.Controls.Add(Me.txtCardSn, 7, 1)
        Me.tlp_Main.Controls.Add(Me.cboPartCode, 5, 1)
        Me.tlp_Main.Controls.Add(Me.txtMedicalTypeName, 3, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 2)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 3)
        Me.tlp_Main.Controls.Add(Me.Label5, 0, 4)
        Me.tlp_Main.Controls.Add(Me.Label6, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label9, 2, 1)
        Me.tlp_Main.Controls.Add(Me.Label12, 2, 2)
        Me.tlp_Main.Controls.Add(Me.Label8, 2, 3)
        Me.tlp_Main.Controls.Add(Me.Label10, 2, 4)
        Me.tlp_Main.Controls.Add(Me.Label14, 4, 0)
        Me.tlp_Main.Controls.Add(Me.Label7, 4, 1)
        Me.tlp_Main.Controls.Add(Me.Label15, 4, 3)
        Me.tlp_Main.Controls.Add(Me.Label16, 4, 4)
        Me.tlp_Main.Controls.Add(Me.Label19, 6, 0)
        Me.tlp_Main.Controls.Add(Me.Label11, 6, 1)
        Me.tlp_Main.Controls.Add(Me.Label21, 6, 2)
        Me.tlp_Main.Controls.Add(Me.Label18, 6, 3)
        Me.tlp_Main.Controls.Add(Me.Label20, 6, 4)
        Me.tlp_Main.Controls.Add(Me.txtMedicalTypeId, 1, 0)
        Me.tlp_Main.Controls.Add(Me.cboMedicalTypeCtrlId, 5, 0)
        Me.tlp_Main.Controls.Add(Me.txtPEDSort, 7, 2)
        Me.tlp_Main.Controls.Add(Me.chkIsExamine, 1, 5)
        Me.tlp_Main.Controls.Add(Me.chkIsRegisterFee, 0, 5)
        Me.tlp_Main.Controls.Add(Me.chkDc, 5, 2)
        Me.tlp_Main.Controls.Add(Me.chkIsPhaServices, 2, 5)
        Me.tlp_Main.Controls.Add(Me.cboDisidentityCode, 7, 0)
        Me.tlp_Main.Controls.Add(Me.cboContractCode1, 1, 1)
        Me.tlp_Main.Controls.Add(Me.cboContractCode2, 3, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 6
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 242)
        Me.tlp_Main.TabIndex = 0
        '
        'txtEMGSort
        '
        Me.txtEMGSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtEMGSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtEMGSort.Location = New System.Drawing.Point(811, 166)
        Me.txtEMGSort.MaxLength = 10
        Me.txtEMGSort.Name = "txtEMGSort"
        Me.txtEMGSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEMGSort.SelectionStart = 0
        Me.txtEMGSort.Size = New System.Drawing.Size(150, 27)
        Me.txtEMGSort.TabIndex = 43
        Me.txtEMGSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtEMGSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtEMGSort.ToolTipTag = Nothing
        Me.txtEMGSort.uclDollarSign = False
        Me.txtEMGSort.uclDotCount = 0
        Me.txtEMGSort.uclIntCount = 2
        Me.txtEMGSort.uclMinus = False
        Me.txtEMGSort.uclReadOnly = False
        Me.txtEMGSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtEMGSort.uclTrimZero = True
        '
        'txtOPDSort
        '
        Me.txtOPDSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOPDSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtOPDSort.Location = New System.Drawing.Point(574, 166)
        Me.txtOPDSort.MaxLength = 10
        Me.txtOPDSort.Name = "txtOPDSort"
        Me.txtOPDSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOPDSort.SelectionStart = 0
        Me.txtOPDSort.Size = New System.Drawing.Size(118, 27)
        Me.txtOPDSort.TabIndex = 42
        Me.txtOPDSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtOPDSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtOPDSort.ToolTipTag = Nothing
        Me.txtOPDSort.uclDollarSign = False
        Me.txtOPDSort.uclDotCount = 0
        Me.txtOPDSort.uclIntCount = 2
        Me.txtOPDSort.uclMinus = False
        Me.txtOPDSort.uclReadOnly = False
        Me.txtOPDSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtOPDSort.uclTrimZero = True
        '
        'txtIPDSort
        '
        Me.txtIPDSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtIPDSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtIPDSort.Location = New System.Drawing.Point(323, 166)
        Me.txtIPDSort.MaxLength = 10
        Me.txtIPDSort.Name = "txtIPDSort"
        Me.txtIPDSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIPDSort.SelectionStart = 0
        Me.txtIPDSort.Size = New System.Drawing.Size(128, 27)
        Me.txtIPDSort.TabIndex = 41
        Me.txtIPDSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIPDSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtIPDSort.ToolTipTag = Nothing
        Me.txtIPDSort.uclDollarSign = False
        Me.txtIPDSort.uclDotCount = 0
        Me.txtIPDSort.uclIntCount = 2
        Me.txtIPDSort.uclMinus = False
        Me.txtIPDSort.uclReadOnly = False
        Me.txtIPDSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtIPDSort.uclTrimZero = True
        '
        'txtREHSort
        '
        Me.txtREHSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtREHSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtREHSort.Location = New System.Drawing.Point(104, 166)
        Me.txtREHSort.MaxLength = 10
        Me.txtREHSort.Name = "txtREHSort"
        Me.txtREHSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtREHSort.SelectionStart = 0
        Me.txtREHSort.Size = New System.Drawing.Size(113, 27)
        Me.txtREHSort.TabIndex = 40
        Me.txtREHSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtREHSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtREHSort.ToolTipTag = Nothing
        Me.txtREHSort.uclDollarSign = False
        Me.txtREHSort.uclDotCount = 0
        Me.txtREHSort.uclIntCount = 2
        Me.txtREHSort.uclMinus = False
        Me.txtREHSort.uclReadOnly = False
        Me.txtREHSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtREHSort.uclTrimZero = True
        '
        'txtUROSort
        '
        Me.txtUROSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtUROSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtUROSort.Location = New System.Drawing.Point(811, 126)
        Me.txtUROSort.MaxLength = 10
        Me.txtUROSort.Name = "txtUROSort"
        Me.txtUROSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUROSort.SelectionStart = 0
        Me.txtUROSort.Size = New System.Drawing.Size(150, 27)
        Me.txtUROSort.TabIndex = 39
        Me.txtUROSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUROSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtUROSort.ToolTipTag = Nothing
        Me.txtUROSort.uclDollarSign = False
        Me.txtUROSort.uclDotCount = 0
        Me.txtUROSort.uclIntCount = 2
        Me.txtUROSort.uclMinus = False
        Me.txtUROSort.uclReadOnly = False
        Me.txtUROSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtUROSort.uclTrimZero = True
        '
        'txtENTSort
        '
        Me.txtENTSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtENTSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtENTSort.Location = New System.Drawing.Point(574, 126)
        Me.txtENTSort.MaxLength = 10
        Me.txtENTSort.Name = "txtENTSort"
        Me.txtENTSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtENTSort.SelectionStart = 0
        Me.txtENTSort.Size = New System.Drawing.Size(118, 27)
        Me.txtENTSort.TabIndex = 38
        Me.txtENTSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtENTSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtENTSort.ToolTipTag = Nothing
        Me.txtENTSort.uclDollarSign = False
        Me.txtENTSort.uclDotCount = 0
        Me.txtENTSort.uclIntCount = 2
        Me.txtENTSort.uclMinus = False
        Me.txtENTSort.uclReadOnly = False
        Me.txtENTSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtENTSort.uclTrimZero = True
        '
        'txtMEDSort
        '
        Me.txtMEDSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMEDSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtMEDSort.Location = New System.Drawing.Point(323, 126)
        Me.txtMEDSort.MaxLength = 10
        Me.txtMEDSort.Name = "txtMEDSort"
        Me.txtMEDSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMEDSort.SelectionStart = 0
        Me.txtMEDSort.Size = New System.Drawing.Size(128, 27)
        Me.txtMEDSort.TabIndex = 37
        Me.txtMEDSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMEDSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtMEDSort.ToolTipTag = Nothing
        Me.txtMEDSort.uclDollarSign = False
        Me.txtMEDSort.uclDotCount = 0
        Me.txtMEDSort.uclIntCount = 2
        Me.txtMEDSort.uclMinus = False
        Me.txtMEDSort.uclReadOnly = False
        Me.txtMEDSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtMEDSort.uclTrimZero = True
        '
        'txtSURSort
        '
        Me.txtSURSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSURSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSURSort.Location = New System.Drawing.Point(104, 126)
        Me.txtSURSort.MaxLength = 10
        Me.txtSURSort.Name = "txtSURSort"
        Me.txtSURSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSURSort.SelectionStart = 0
        Me.txtSURSort.Size = New System.Drawing.Size(113, 27)
        Me.txtSURSort.TabIndex = 36
        Me.txtSURSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSURSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSURSort.ToolTipTag = Nothing
        Me.txtSURSort.uclDollarSign = False
        Me.txtSURSort.uclDotCount = 0
        Me.txtSURSort.uclIntCount = 2
        Me.txtSURSort.uclMinus = False
        Me.txtSURSort.uclReadOnly = False
        Me.txtSURSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtSURSort.uclTrimZero = True
        '
        'cboCaseTypeId
        '
        Me.cboCaseTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCaseTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboCaseTypeId.DropDownWidth = 20
        Me.cboCaseTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboCaseTypeId.Location = New System.Drawing.Point(320, 90)
        Me.cboCaseTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboCaseTypeId.Name = "cboCaseTypeId"
        Me.cboCaseTypeId.SelectedIndex = -1
        Me.cboCaseTypeId.SelectedItem = Nothing
        Me.cboCaseTypeId.SelectedText = ""
        Me.cboCaseTypeId.SelectedValue = ""
        Me.cboCaseTypeId.SelectionStart = 0
        Me.cboCaseTypeId.Size = New System.Drawing.Size(134, 20)
        Me.cboCaseTypeId.TabIndex = 32
        Me.cboCaseTypeId.uclDisplayIndex = "0,1"
        Me.cboCaseTypeId.uclIsAutoClear = True
        Me.cboCaseTypeId.uclIsFirstItemEmpty = True
        Me.cboCaseTypeId.uclIsTextMode = False
        Me.cboCaseTypeId.uclShowMsg = False
        Me.cboCaseTypeId.uclValueIndex = "0"
        '
        'cboICMedicalTypeId
        '
        Me.cboICMedicalTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboICMedicalTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboICMedicalTypeId.DropDownWidth = 20
        Me.cboICMedicalTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboICMedicalTypeId.Location = New System.Drawing.Point(101, 90)
        Me.cboICMedicalTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboICMedicalTypeId.Name = "cboICMedicalTypeId"
        Me.cboICMedicalTypeId.SelectedIndex = -1
        Me.cboICMedicalTypeId.SelectedItem = Nothing
        Me.cboICMedicalTypeId.SelectedText = ""
        Me.cboICMedicalTypeId.SelectedValue = ""
        Me.cboICMedicalTypeId.SelectionStart = 0
        Me.cboICMedicalTypeId.Size = New System.Drawing.Size(119, 20)
        Me.cboICMedicalTypeId.TabIndex = 31
        Me.cboICMedicalTypeId.uclDisplayIndex = "0,1"
        Me.cboICMedicalTypeId.uclIsAutoClear = True
        Me.cboICMedicalTypeId.uclIsFirstItemEmpty = True
        Me.cboICMedicalTypeId.uclIsTextMode = False
        Me.cboICMedicalTypeId.uclShowMsg = False
        Me.cboICMedicalTypeId.uclValueIndex = "0"
        '
        'txtCardSn
        '
        Me.txtCardSn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCardSn.Location = New System.Drawing.Point(811, 46)
        Me.txtCardSn.MaxLength = 4
        Me.txtCardSn.Name = "txtCardSn"
        Me.txtCardSn.Size = New System.Drawing.Size(150, 27)
        Me.txtCardSn.TabIndex = 30
        '
        'cboPartCode
        '
        Me.cboPartCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboPartCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboPartCode.DropDownWidth = 20
        Me.cboPartCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboPartCode.Location = New System.Drawing.Point(571, 50)
        Me.cboPartCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cboPartCode.Name = "cboPartCode"
        Me.cboPartCode.SelectedIndex = -1
        Me.cboPartCode.SelectedItem = Nothing
        Me.cboPartCode.SelectedText = ""
        Me.cboPartCode.SelectedValue = ""
        Me.cboPartCode.SelectionStart = 0
        Me.cboPartCode.Size = New System.Drawing.Size(124, 20)
        Me.cboPartCode.TabIndex = 29
        Me.cboPartCode.uclDisplayIndex = "0,1"
        Me.cboPartCode.uclIsAutoClear = True
        Me.cboPartCode.uclIsFirstItemEmpty = True
        Me.cboPartCode.uclIsTextMode = False
        Me.cboPartCode.uclShowMsg = False
        Me.cboPartCode.uclValueIndex = "0"
        '
        'txtMedicalTypeName
        '
        Me.txtMedicalTypeName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMedicalTypeName.Location = New System.Drawing.Point(323, 6)
        Me.txtMedicalTypeName.MaxLength = 50
        Me.txtMedicalTypeName.Name = "txtMedicalTypeName"
        Me.txtMedicalTypeName.Size = New System.Drawing.Size(128, 27)
        Me.txtMedicalTypeName.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "看診目的"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "預設合約機構1"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "預設IC卡就醫類別"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "外科排序"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "復健科排序"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(223, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 32)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "看診目的名稱"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(223, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 32)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "預設合約機構2"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(223, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 32)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "預設案件分類"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "內科排序"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(223, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 32)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "住院櫃台排序"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(457, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 32)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "看診目的管控分類"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(457, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "預設部分負擔"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(457, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "耳鼻喉科排序"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(457, 172)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 16)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "門診櫃台排序"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(698, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 16)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "預設優待身分"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(698, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "預設卡號"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(698, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 16)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "兒科排序"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(698, 132)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "泌尿科排序"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(698, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "急診櫃台排序"
        '
        'txtMedicalTypeId
        '
        Me.txtMedicalTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMedicalTypeId.Location = New System.Drawing.Point(104, 6)
        Me.txtMedicalTypeId.MaxLength = 5
        Me.txtMedicalTypeId.Name = "txtMedicalTypeId"
        Me.txtMedicalTypeId.Size = New System.Drawing.Size(113, 27)
        Me.txtMedicalTypeId.TabIndex = 23
        '
        'cboMedicalTypeCtrlId
        '
        Me.cboMedicalTypeCtrlId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboMedicalTypeCtrlId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboMedicalTypeCtrlId.DropDownWidth = 20
        Me.cboMedicalTypeCtrlId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboMedicalTypeCtrlId.Location = New System.Drawing.Point(571, 10)
        Me.cboMedicalTypeCtrlId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboMedicalTypeCtrlId.Name = "cboMedicalTypeCtrlId"
        Me.cboMedicalTypeCtrlId.SelectedIndex = -1
        Me.cboMedicalTypeCtrlId.SelectedItem = Nothing
        Me.cboMedicalTypeCtrlId.SelectedText = ""
        Me.cboMedicalTypeCtrlId.SelectedValue = ""
        Me.cboMedicalTypeCtrlId.SelectionStart = 0
        Me.cboMedicalTypeCtrlId.Size = New System.Drawing.Size(124, 20)
        Me.cboMedicalTypeCtrlId.TabIndex = 25
        Me.cboMedicalTypeCtrlId.uclDisplayIndex = "0,1"
        Me.cboMedicalTypeCtrlId.uclIsAutoClear = True
        Me.cboMedicalTypeCtrlId.uclIsFirstItemEmpty = True
        Me.cboMedicalTypeCtrlId.uclIsTextMode = False
        Me.cboMedicalTypeCtrlId.uclShowMsg = False
        Me.cboMedicalTypeCtrlId.uclValueIndex = "0"
        '
        'txtPEDSort
        '
        Me.txtPEDSort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPEDSort.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPEDSort.Location = New System.Drawing.Point(811, 86)
        Me.txtPEDSort.MaxLength = 10
        Me.txtPEDSort.Name = "txtPEDSort"
        Me.txtPEDSort.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPEDSort.SelectionStart = 0
        Me.txtPEDSort.Size = New System.Drawing.Size(150, 27)
        Me.txtPEDSort.TabIndex = 34
        Me.txtPEDSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPEDSort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPEDSort.ToolTipTag = Nothing
        Me.txtPEDSort.uclDollarSign = False
        Me.txtPEDSort.uclDotCount = 0
        Me.txtPEDSort.uclIntCount = 2
        Me.txtPEDSort.uclMinus = False
        Me.txtPEDSort.uclReadOnly = False
        Me.txtPEDSort.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtPEDSort.uclTrimZero = True
        '
        'chkIsExamine
        '
        Me.chkIsExamine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsExamine.AutoSize = True
        Me.tlp_Main.SetColumnSpan(Me.chkIsExamine, 2)
        Me.chkIsExamine.Location = New System.Drawing.Point(223, 211)
        Me.chkIsExamine.Name = "chkIsExamine"
        Me.chkIsExamine.Size = New System.Drawing.Size(139, 20)
        Me.chkIsExamine.TabIndex = 46
        Me.chkIsExamine.Text = "是否產生診察費"
        Me.chkIsExamine.UseVisualStyleBackColor = True
        '
        'chkIsRegisterFee
        '
        Me.chkIsRegisterFee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsRegisterFee.AutoSize = True
        Me.tlp_Main.SetColumnSpan(Me.chkIsRegisterFee, 2)
        Me.chkIsRegisterFee.Location = New System.Drawing.Point(3, 211)
        Me.chkIsRegisterFee.Name = "chkIsRegisterFee"
        Me.chkIsRegisterFee.Size = New System.Drawing.Size(139, 20)
        Me.chkIsRegisterFee.TabIndex = 45
        Me.chkIsRegisterFee.Text = "是否產生掛號費"
        Me.chkIsRegisterFee.UseVisualStyleBackColor = True
        '
        'chkDc
        '
        Me.chkDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDc.AutoSize = True
        Me.chkDc.Location = New System.Drawing.Point(574, 90)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 20)
        Me.chkDc.TabIndex = 33
        Me.chkDc.Text = "停用"
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'chkIsPhaServices
        '
        Me.chkIsPhaServices.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsPhaServices.AutoSize = True
        Me.tlp_Main.SetColumnSpan(Me.chkIsPhaServices, 2)
        Me.chkIsPhaServices.Location = New System.Drawing.Point(457, 211)
        Me.chkIsPhaServices.Name = "chkIsPhaServices"
        Me.chkIsPhaServices.Size = New System.Drawing.Size(139, 20)
        Me.chkIsPhaServices.TabIndex = 44
        Me.chkIsPhaServices.Text = "是否產生藥服費"
        Me.chkIsPhaServices.UseVisualStyleBackColor = True
        '
        'cboDisidentityCode
        '
        Me.cboDisidentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDisidentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboDisidentityCode.DropDownWidth = 20
        Me.cboDisidentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboDisidentityCode.Location = New System.Drawing.Point(808, 10)
        Me.cboDisidentityCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cboDisidentityCode.Name = "cboDisidentityCode"
        Me.cboDisidentityCode.SelectedIndex = -1
        Me.cboDisidentityCode.SelectedItem = Nothing
        Me.cboDisidentityCode.SelectedText = ""
        Me.cboDisidentityCode.SelectedValue = ""
        Me.cboDisidentityCode.SelectionStart = 0
        Me.cboDisidentityCode.Size = New System.Drawing.Size(156, 20)
        Me.cboDisidentityCode.TabIndex = 47
        Me.cboDisidentityCode.uclDisplayIndex = "0,1"
        Me.cboDisidentityCode.uclIsAutoClear = True
        Me.cboDisidentityCode.uclIsFirstItemEmpty = True
        Me.cboDisidentityCode.uclIsTextMode = False
        Me.cboDisidentityCode.uclShowMsg = False
        Me.cboDisidentityCode.uclValueIndex = "0"
        '
        'cboContractCode1
        '
        Me.cboContractCode1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboContractCode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboContractCode1.DropDownWidth = 20
        Me.cboContractCode1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboContractCode1.Location = New System.Drawing.Point(101, 50)
        Me.cboContractCode1.Margin = New System.Windows.Forms.Padding(0)
        Me.cboContractCode1.Name = "cboContractCode1"
        Me.cboContractCode1.SelectedIndex = -1
        Me.cboContractCode1.SelectedItem = Nothing
        Me.cboContractCode1.SelectedText = ""
        Me.cboContractCode1.SelectedValue = ""
        Me.cboContractCode1.SelectionStart = 0
        Me.cboContractCode1.Size = New System.Drawing.Size(119, 20)
        Me.cboContractCode1.TabIndex = 49
        Me.cboContractCode1.uclDisplayIndex = "0,1"
        Me.cboContractCode1.uclIsAutoClear = True
        Me.cboContractCode1.uclIsFirstItemEmpty = True
        Me.cboContractCode1.uclIsTextMode = False
        Me.cboContractCode1.uclShowMsg = False
        Me.cboContractCode1.uclValueIndex = "0"
        '
        'cboContractCode2
        '
        Me.cboContractCode2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboContractCode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboContractCode2.DropDownWidth = 20
        Me.cboContractCode2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboContractCode2.Location = New System.Drawing.Point(320, 50)
        Me.cboContractCode2.Margin = New System.Windows.Forms.Padding(0)
        Me.cboContractCode2.Name = "cboContractCode2"
        Me.cboContractCode2.SelectedIndex = -1
        Me.cboContractCode2.SelectedItem = Nothing
        Me.cboContractCode2.SelectedText = ""
        Me.cboContractCode2.SelectedValue = ""
        Me.cboContractCode2.SelectionStart = 0
        Me.cboContractCode2.Size = New System.Drawing.Size(134, 20)
        Me.cboContractCode2.TabIndex = 48
        Me.cboContractCode2.uclDisplayIndex = "0,1"
        Me.cboContractCode2.uclIsAutoClear = True
        Me.cboContractCode2.uclIsFirstItemEmpty = True
        Me.cboContractCode2.uclIsTextMode = False
        Me.cboContractCode2.uclShowMsg = False
        Me.cboContractCode2.uclValueIndex = "0"
        '
        'PubMedicalTypeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 741)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PubMedicalTypeUI"
        Me.Text = "PubMedicalTypeUI"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtEMGSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtOPDSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtIPDSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtREHSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtUROSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtENTSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtMEDSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtSURSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cboCaseTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cboICMedicalTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtCardSn As System.Windows.Forms.TextBox
    Friend WithEvents cboPartCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtMedicalTypeName As System.Windows.Forms.TextBox
    Friend WithEvents txtMedicalTypeId As System.Windows.Forms.TextBox
    Friend WithEvents cboMedicalTypeCtrlId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtPEDSort As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chkIsExamine As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsRegisterFee As System.Windows.Forms.CheckBox
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsPhaServices As System.Windows.Forms.CheckBox
    Friend WithEvents cboDisidentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cboContractCode1 As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cboContractCode2 As Syscom.Client.UCL.UCLComboBoxUC
End Class
