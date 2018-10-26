<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBContractUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBContractUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.txtProjectDirector = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblProjectDirector = New System.Windows.Forms.Label()
        Me.lblDrugCode = New System.Windows.Forms.Label()
        Me.lblDrugCommitteeSn = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblContactEmail = New System.Windows.Forms.Label()
        Me.txtDrugCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDrugCommitteeSn = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContactEmail = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblContactAddress = New System.Windows.Forms.Label()
        Me.UclZipCodeAddress = New Syscom.Client.UCL.UCLCensusAddrUC()
        Me.txtContactTel1 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContactTel3 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContactTel2 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContactName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblReceiptTitle = New System.Windows.Forms.Label()
        Me.txtReceiptTitle = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDrugName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDisRate = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtAddRate = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dtpProjectEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblProjectEndDate = New System.Windows.Forms.Label()
        Me.dtpProjectEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblProjectEffectDate = New System.Windows.Forms.Label()
        Me.txtMemo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chkDC = New System.Windows.Forms.CheckBox()
        Me.lblContactTelMobile = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContactTelMobile = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContactFax = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbContractTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.chbIsUseSet = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCheckQuotaId = New System.Windows.Forms.Label()
        Me.cmbCheckQuotaId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblUpperAmtTypeId = New System.Windows.Forms.Label()
        Me.cmbUpperAmtTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblUpperAmt = New System.Windows.Forms.Label()
        Me.txtUpperAmt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContractCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtContractName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.gpbInput = New System.Windows.Forms.GroupBox()
        Me.conditionsPanel1 = New System.Windows.Forms.Panel()
        Me.gpbConditions = New System.Windows.Forms.GroupBox()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.tlp_GridView = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvShowData = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gpbInput.SuspendLayout()
        Me.conditionsPanel1.SuspendLayout()
        Me.gpbConditions.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        Me.tlp_GridView.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.lblMemo, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txtProjectDirector, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblProjectDirector, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDrugCode, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDrugCommitteeSn, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPhone, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblContactEmail, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDrugCode, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDrugCommitteeSn, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactEmail, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.lblContactAddress, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.UclZipCodeAddress, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactTel1, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactTel3, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactTel2, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactName, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblReceiptTitle, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtReceiptTitle, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDrugName, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 3, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 5, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDisRate, 4, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAddRate, 6, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpProjectEndDate, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblProjectEndDate, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpProjectEffectDate, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblProjectEffectDate, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMemo, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.chkDC, 6, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lblContactTelMobile, 5, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 5, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactTelMobile, 6, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtContactFax, 6, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbContractTypeId, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.chbIsUseSet, 5, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1002, 321)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'lblMemo
        '
        Me.lblMemo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMemo.AutoSize = True
        Me.lblMemo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblMemo.Location = New System.Drawing.Point(75, 293)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(40, 16)
        Me.lblMemo.TabIndex = 656
        Me.lblMemo.Text = "備註"
        '
        'txtProjectDirector
        '
        Me.txtProjectDirector.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtProjectDirector, 2)
        Me.txtProjectDirector.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtProjectDirector.Location = New System.Drawing.Point(124, 6)
        Me.txtProjectDirector.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtProjectDirector.MaxLength = 50
        Me.txtProjectDirector.Name = "txtProjectDirector"
        Me.txtProjectDirector.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtProjectDirector.SelectionStart = 0
        Me.txtProjectDirector.Size = New System.Drawing.Size(274, 27)
        Me.txtProjectDirector.TabIndex = 5
        Me.txtProjectDirector.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtProjectDirector.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtProjectDirector.ToolTipTag = Nothing
        Me.txtProjectDirector.uclDollarSign = False
        Me.txtProjectDirector.uclDotCount = 0
        Me.txtProjectDirector.uclIntCount = 2
        Me.txtProjectDirector.uclMinus = False
        Me.txtProjectDirector.uclReadOnly = False
        Me.txtProjectDirector.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtProjectDirector.uclTrimZero = True
        '
        'lblProjectDirector
        '
        Me.lblProjectDirector.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblProjectDirector.AutoSize = True
        Me.lblProjectDirector.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblProjectDirector.Location = New System.Drawing.Point(27, 12)
        Me.lblProjectDirector.Name = "lblProjectDirector"
        Me.lblProjectDirector.Size = New System.Drawing.Size(88, 16)
        Me.lblProjectDirector.TabIndex = 34
        Me.lblProjectDirector.Text = "計畫主持人"
        '
        'lblDrugCode
        '
        Me.lblDrugCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDrugCode.AutoSize = True
        Me.lblDrugCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDrugCode.Location = New System.Drawing.Point(27, 52)
        Me.lblDrugCode.Name = "lblDrugCode"
        Me.lblDrugCode.Size = New System.Drawing.Size(88, 16)
        Me.lblDrugCode.TabIndex = 65
        Me.lblDrugCode.Text = "計畫藥品名"
        '
        'lblDrugCommitteeSn
        '
        Me.lblDrugCommitteeSn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDrugCommitteeSn.AutoSize = True
        Me.lblDrugCommitteeSn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDrugCommitteeSn.Location = New System.Drawing.Point(27, 92)
        Me.lblDrugCommitteeSn.Name = "lblDrugCommitteeSn"
        Me.lblDrugCommitteeSn.Size = New System.Drawing.Size(88, 16)
        Me.lblDrugCommitteeSn.TabIndex = 76
        Me.lblDrugCommitteeSn.Text = "藥委會編號"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(59, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 232
        Me.Label11.Text = "聯絡人"
        '
        'lblPhone
        '
        Me.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPhone.Location = New System.Drawing.Point(43, 172)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(72, 16)
        Me.lblPhone.TabIndex = 34
        Me.lblPhone.Text = "聯絡電話"
        '
        'lblContactEmail
        '
        Me.lblContactEmail.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblContactEmail.AutoSize = True
        Me.lblContactEmail.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblContactEmail.Location = New System.Drawing.Point(17, 252)
        Me.lblContactEmail.Name = "lblContactEmail"
        Me.lblContactEmail.Size = New System.Drawing.Size(98, 16)
        Me.lblContactEmail.TabIndex = 654
        Me.lblContactEmail.Text = "聯絡人E-Mail"
        '
        'txtDrugCode
        '
        Me.txtDrugCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDrugCode, 2)
        Me.txtDrugCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDrugCode.Location = New System.Drawing.Point(124, 46)
        Me.txtDrugCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtDrugCode.MaxLength = 20
        Me.txtDrugCode.Name = "txtDrugCode"
        Me.txtDrugCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDrugCode.SelectionStart = 0
        Me.txtDrugCode.Size = New System.Drawing.Size(274, 27)
        Me.txtDrugCode.TabIndex = 8
        Me.txtDrugCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDrugCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDrugCode.ToolTipTag = Nothing
        Me.txtDrugCode.uclDollarSign = False
        Me.txtDrugCode.uclDotCount = 0
        Me.txtDrugCode.uclIntCount = 2
        Me.txtDrugCode.uclMinus = False
        Me.txtDrugCode.uclReadOnly = False
        Me.txtDrugCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDrugCode.uclTrimZero = True
        '
        'txtDrugCommitteeSn
        '
        Me.txtDrugCommitteeSn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDrugCommitteeSn, 2)
        Me.txtDrugCommitteeSn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDrugCommitteeSn.Location = New System.Drawing.Point(124, 86)
        Me.txtDrugCommitteeSn.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtDrugCommitteeSn.MaxLength = 20
        Me.txtDrugCommitteeSn.Name = "txtDrugCommitteeSn"
        Me.txtDrugCommitteeSn.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDrugCommitteeSn.SelectionStart = 0
        Me.txtDrugCommitteeSn.Size = New System.Drawing.Size(274, 27)
        Me.txtDrugCommitteeSn.TabIndex = 10
        Me.txtDrugCommitteeSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDrugCommitteeSn.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDrugCommitteeSn.ToolTipTag = Nothing
        Me.txtDrugCommitteeSn.uclDollarSign = False
        Me.txtDrugCommitteeSn.uclDotCount = 0
        Me.txtDrugCommitteeSn.uclIntCount = 2
        Me.txtDrugCommitteeSn.uclMinus = False
        Me.txtDrugCommitteeSn.uclReadOnly = False
        Me.txtDrugCommitteeSn.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDrugCommitteeSn.uclTrimZero = True
        '
        'txtContactEmail
        '
        Me.txtContactEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtContactEmail, 2)
        Me.txtContactEmail.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtContactEmail.Location = New System.Drawing.Point(124, 246)
        Me.txtContactEmail.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtContactEmail.MaxLength = 50
        Me.txtContactEmail.Name = "txtContactEmail"
        Me.txtContactEmail.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactEmail.SelectionStart = 0
        Me.txtContactEmail.Size = New System.Drawing.Size(274, 27)
        Me.txtContactEmail.TabIndex = 21
        Me.txtContactEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactEmail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactEmail.ToolTipTag = Nothing
        Me.txtContactEmail.uclDollarSign = False
        Me.txtContactEmail.uclDotCount = 0
        Me.txtContactEmail.uclIntCount = 2
        Me.txtContactEmail.uclMinus = False
        Me.txtContactEmail.uclReadOnly = False
        Me.txtContactEmail.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtContactEmail.uclTrimZero = True
        '
        'lblContactAddress
        '
        Me.lblContactAddress.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblContactAddress.AutoSize = True
        Me.lblContactAddress.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblContactAddress.Location = New System.Drawing.Point(43, 212)
        Me.lblContactAddress.Name = "lblContactAddress"
        Me.lblContactAddress.Size = New System.Drawing.Size(72, 16)
        Me.lblContactAddress.TabIndex = 657
        Me.lblContactAddress.Text = "聯絡地址"
        '
        'UclZipCodeAddress
        '
        Me.UclZipCodeAddress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.UclZipCodeAddress, 4)
        Me.UclZipCodeAddress.doFlag = True
        Me.UclZipCodeAddress.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclZipCodeAddress.IsUsePUBAreaCodeN = False
        Me.UclZipCodeAddress.Location = New System.Drawing.Point(124, 207)
        Me.UclZipCodeAddress.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclZipCodeAddress.Name = "UclZipCodeAddress"
        Me.UclZipCodeAddress.SelectAreaCode = ""
        Me.UclZipCodeAddress.SelectAreaName = ""
        Me.UclZipCodeAddress.SelectedValue = ""
        Me.UclZipCodeAddress.SelectPostalCode = ""
        Me.UclZipCodeAddress.SelectPostalName = ""
        Me.UclZipCodeAddress.Size = New System.Drawing.Size(559, 26)
        Me.UclZipCodeAddress.TabIndex = 19
        Me.UclZipCodeAddress.TxtAddress = ""
        Me.UclZipCodeAddress.uclCboWidth = 150
        Me.UclZipCodeAddress.uclDisplayIndex = "0,1"
        Me.UclZipCodeAddress.uclShowType = Syscom.Client.UCL.UCLCensusAddrUC.uclShowData.showPostal
        Me.UclZipCodeAddress.uclValueIndex = "0"
        Me.UclZipCodeAddress.uclXPosition = 225
        Me.UclZipCodeAddress.uclYPosition = 120
        '
        'txtContactTel1
        '
        Me.txtContactTel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtContactTel1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtContactTel1.Location = New System.Drawing.Point(124, 166)
        Me.txtContactTel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtContactTel1.MaxLength = 3
        Me.txtContactTel1.Name = "txtContactTel1"
        Me.txtContactTel1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactTel1.SelectionStart = 0
        Me.txtContactTel1.Size = New System.Drawing.Size(66, 27)
        Me.txtContactTel1.TabIndex = 15
        Me.txtContactTel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactTel1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactTel1.ToolTipTag = Nothing
        Me.txtContactTel1.uclDollarSign = False
        Me.txtContactTel1.uclDotCount = 0
        Me.txtContactTel1.uclIntCount = 4
        Me.txtContactTel1.uclMinus = False
        Me.txtContactTel1.uclReadOnly = False
        Me.txtContactTel1.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtContactTel1.uclTrimZero = True
        '
        'txtContactTel3
        '
        Me.txtContactTel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtContactTel3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtContactTel3.Location = New System.Drawing.Point(418, 166)
        Me.txtContactTel3.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtContactTel3.MaxLength = 5
        Me.txtContactTel3.Name = "txtContactTel3"
        Me.txtContactTel3.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactTel3.SelectionStart = 0
        Me.txtContactTel3.Size = New System.Drawing.Size(84, 27)
        Me.txtContactTel3.TabIndex = 17
        Me.txtContactTel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactTel3.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactTel3.ToolTipTag = Nothing
        Me.txtContactTel3.uclDollarSign = False
        Me.txtContactTel3.uclDotCount = 0
        Me.txtContactTel3.uclIntCount = 6
        Me.txtContactTel3.uclMinus = False
        Me.txtContactTel3.uclReadOnly = False
        Me.txtContactTel3.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtContactTel3.uclTrimZero = True
        '
        'txtContactTel2
        '
        Me.txtContactTel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtContactTel2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtContactTel2.Location = New System.Drawing.Point(202, 166)
        Me.txtContactTel2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtContactTel2.MaxLength = 10
        Me.txtContactTel2.Name = "txtContactTel2"
        Me.txtContactTel2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactTel2.SelectionStart = 0
        Me.txtContactTel2.Size = New System.Drawing.Size(204, 27)
        Me.txtContactTel2.TabIndex = 16
        Me.txtContactTel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactTel2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactTel2.ToolTipTag = Nothing
        Me.txtContactTel2.uclDollarSign = False
        Me.txtContactTel2.uclDotCount = 0
        Me.txtContactTel2.uclIntCount = 10
        Me.txtContactTel2.uclMinus = False
        Me.txtContactTel2.uclReadOnly = False
        Me.txtContactTel2.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtContactTel2.uclTrimZero = True
        '
        'txtContactName
        '
        Me.txtContactName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtContactName, 2)
        Me.txtContactName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtContactName.Location = New System.Drawing.Point(124, 126)
        Me.txtContactName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtContactName.MaxLength = 50
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactName.SelectionStart = 0
        Me.txtContactName.Size = New System.Drawing.Size(274, 27)
        Me.txtContactName.TabIndex = 13
        Me.txtContactName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactName.ToolTipTag = Nothing
        Me.txtContactName.uclDollarSign = False
        Me.txtContactName.uclDotCount = 0
        Me.txtContactName.uclIntCount = 2
        Me.txtContactName.uclMinus = False
        Me.txtContactName.uclReadOnly = False
        Me.txtContactName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtContactName.uclTrimZero = True
        '
        'lblReceiptTitle
        '
        Me.lblReceiptTitle.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblReceiptTitle.AutoSize = True
        Me.lblReceiptTitle.Location = New System.Drawing.Point(479, 132)
        Me.lblReceiptTitle.Name = "lblReceiptTitle"
        Me.lblReceiptTitle.Size = New System.Drawing.Size(72, 16)
        Me.lblReceiptTitle.TabIndex = 664
        Me.lblReceiptTitle.Text = "收據抬頭"
        '
        'txtReceiptTitle
        '
        Me.txtReceiptTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtReceiptTitle, 3)
        Me.txtReceiptTitle.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtReceiptTitle.Location = New System.Drawing.Point(558, 126)
        Me.txtReceiptTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReceiptTitle.MaxLength = 50
        Me.txtReceiptTitle.Name = "txtReceiptTitle"
        Me.txtReceiptTitle.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReceiptTitle.SelectionStart = 0
        Me.txtReceiptTitle.Size = New System.Drawing.Size(472, 27)
        Me.txtReceiptTitle.TabIndex = 14
        Me.txtReceiptTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtReceiptTitle.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtReceiptTitle.ToolTipTag = Nothing
        Me.txtReceiptTitle.uclDollarSign = False
        Me.txtReceiptTitle.uclDotCount = 0
        Me.txtReceiptTitle.uclIntCount = 2
        Me.txtReceiptTitle.uclMinus = False
        Me.txtReceiptTitle.uclReadOnly = False
        Me.txtReceiptTitle.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtReceiptTitle.uclTrimZero = True
        '
        'txtDrugName
        '
        Me.txtDrugName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtDrugName, 4)
        Me.txtDrugName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDrugName.Location = New System.Drawing.Point(418, 46)
        Me.txtDrugName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtDrugName.MaxLength = 50
        Me.txtDrugName.Name = "txtDrugName"
        Me.txtDrugName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDrugName.SelectionStart = 0
        Me.txtDrugName.Size = New System.Drawing.Size(563, 27)
        Me.txtDrugName.TabIndex = 9
        Me.txtDrugName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDrugName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDrugName.ToolTipTag = Nothing
        Me.txtDrugName.uclDollarSign = False
        Me.txtDrugName.uclDotCount = 0
        Me.txtDrugName.uclIntCount = 2
        Me.txtDrugName.uclMinus = False
        Me.txtDrugName.uclReadOnly = False
        Me.txtDrugName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDrugName.uclTrimZero = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(511, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 668
        Me.Label3.Text = "折數"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(791, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 669
        Me.Label4.Text = "分成"
        '
        'txtDisRate
        '
        Me.txtDisRate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDisRate.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDisRate.Location = New System.Drawing.Point(558, 246)
        Me.txtDisRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDisRate.MaxLength = 19
        Me.txtDisRate.Name = "txtDisRate"
        Me.txtDisRate.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDisRate.SelectionStart = 0
        Me.txtDisRate.Size = New System.Drawing.Size(171, 27)
        Me.txtDisRate.TabIndex = 22
        Me.txtDisRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDisRate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDisRate.ToolTipTag = Nothing
        Me.txtDisRate.uclDollarSign = False
        Me.txtDisRate.uclDotCount = 4
        Me.txtDisRate.uclIntCount = 14
        Me.txtDisRate.uclMinus = False
        Me.txtDisRate.uclReadOnly = False
        Me.txtDisRate.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtDisRate.uclTrimZero = True
        '
        'txtAddRate
        '
        Me.txtAddRate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAddRate.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtAddRate.Location = New System.Drawing.Point(838, 246)
        Me.txtAddRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddRate.MaxLength = 19
        Me.txtAddRate.Name = "txtAddRate"
        Me.txtAddRate.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAddRate.SelectionStart = 0
        Me.txtAddRate.Size = New System.Drawing.Size(145, 27)
        Me.txtAddRate.TabIndex = 23
        Me.txtAddRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtAddRate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtAddRate.ToolTipTag = Nothing
        Me.txtAddRate.uclDollarSign = False
        Me.txtAddRate.uclDotCount = 4
        Me.txtAddRate.uclIntCount = 14
        Me.txtAddRate.uclMinus = False
        Me.txtAddRate.uclReadOnly = False
        Me.txtAddRate.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtAddRate.uclTrimZero = True
        '
        'dtpProjectEndDate
        '
        Me.dtpProjectEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpProjectEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpProjectEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpProjectEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpProjectEndDate.Location = New System.Drawing.Point(837, 86)
        Me.dtpProjectEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpProjectEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpProjectEndDate.Name = "dtpProjectEndDate"
        Me.dtpProjectEndDate.Size = New System.Drawing.Size(146, 27)
        Me.dtpProjectEndDate.TabIndex = 12
        Me.dtpProjectEndDate.uclReadOnly = False
        '
        'lblProjectEndDate
        '
        Me.lblProjectEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblProjectEndDate.AutoSize = True
        Me.lblProjectEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblProjectEndDate.Location = New System.Drawing.Point(759, 92)
        Me.lblProjectEndDate.Name = "lblProjectEndDate"
        Me.lblProjectEndDate.Size = New System.Drawing.Size(72, 16)
        Me.lblProjectEndDate.TabIndex = 75
        Me.lblProjectEndDate.Text = "計畫迄日"
        '
        'dtpProjectEffectDate
        '
        Me.dtpProjectEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpProjectEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpProjectEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpProjectEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpProjectEffectDate.Location = New System.Drawing.Point(557, 86)
        Me.dtpProjectEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpProjectEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpProjectEffectDate.Name = "dtpProjectEffectDate"
        Me.dtpProjectEffectDate.Size = New System.Drawing.Size(143, 27)
        Me.dtpProjectEffectDate.TabIndex = 11
        Me.dtpProjectEffectDate.uclReadOnly = False
        '
        'lblProjectEffectDate
        '
        Me.lblProjectEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblProjectEffectDate.AutoSize = True
        Me.lblProjectEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblProjectEffectDate.Location = New System.Drawing.Point(479, 92)
        Me.lblProjectEffectDate.Name = "lblProjectEffectDate"
        Me.lblProjectEffectDate.Size = New System.Drawing.Size(72, 16)
        Me.lblProjectEffectDate.TabIndex = 65
        Me.lblProjectEffectDate.Text = "計畫起日"
        '
        'txtMemo
        '
        Me.txtMemo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtMemo, 5)
        Me.txtMemo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMemo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMemo.Location = New System.Drawing.Point(124, 288)
        Me.txtMemo.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txtMemo.MaxLength = 50
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMemo.SelectionStart = 0
        Me.txtMemo.Size = New System.Drawing.Size(694, 27)
        Me.txtMemo.TabIndex = 24
        Me.txtMemo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMemo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtMemo.ToolTipTag = Nothing
        Me.txtMemo.uclDollarSign = False
        Me.txtMemo.uclDotCount = 0
        Me.txtMemo.uclIntCount = 2
        Me.txtMemo.uclMinus = False
        Me.txtMemo.uclReadOnly = False
        Me.txtMemo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtMemo.uclTrimZero = True
        '
        'chkDC
        '
        Me.chkDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDC.AutoSize = True
        Me.chkDC.Location = New System.Drawing.Point(838, 291)
        Me.chkDC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDC.Name = "chkDC"
        Me.chkDC.Size = New System.Drawing.Size(59, 20)
        Me.chkDC.TabIndex = 25
        Me.chkDC.Text = "停用"
        Me.chkDC.UseVisualStyleBackColor = True
        '
        'lblContactTelMobile
        '
        Me.lblContactTelMobile.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblContactTelMobile.AutoSize = True
        Me.lblContactTelMobile.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblContactTelMobile.Location = New System.Drawing.Point(736, 172)
        Me.lblContactTelMobile.Name = "lblContactTelMobile"
        Me.lblContactTelMobile.Size = New System.Drawing.Size(95, 16)
        Me.lblContactTelMobile.TabIndex = 661
        Me.lblContactTelMobile.Text = "聯絡電話(M)"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(751, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 673
        Me.Label5.Text = "傳真(FAX)"
        '
        'txtContactTelMobile
        '
        Me.txtContactTelMobile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtContactTelMobile.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtContactTelMobile.Location = New System.Drawing.Point(838, 166)
        Me.txtContactTelMobile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactTelMobile.MaxLength = 20
        Me.txtContactTelMobile.Name = "txtContactTelMobile"
        Me.txtContactTelMobile.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactTelMobile.SelectionStart = 0
        Me.txtContactTelMobile.Size = New System.Drawing.Size(145, 27)
        Me.txtContactTelMobile.TabIndex = 18
        Me.txtContactTelMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactTelMobile.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactTelMobile.ToolTipTag = Nothing
        Me.txtContactTelMobile.uclDollarSign = False
        Me.txtContactTelMobile.uclDotCount = 0
        Me.txtContactTelMobile.uclIntCount = 20
        Me.txtContactTelMobile.uclMinus = False
        Me.txtContactTelMobile.uclReadOnly = False
        Me.txtContactTelMobile.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtContactTelMobile.uclTrimZero = True
        '
        'txtContactFax
        '
        Me.txtContactFax.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtContactFax.Location = New System.Drawing.Point(838, 204)
        Me.txtContactFax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactFax.MaxLength = 20
        Me.txtContactFax.Name = "txtContactFax"
        Me.txtContactFax.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContactFax.SelectionStart = 0
        Me.txtContactFax.Size = New System.Drawing.Size(145, 27)
        Me.txtContactFax.TabIndex = 20
        Me.txtContactFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContactFax.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContactFax.ToolTipTag = Nothing
        Me.txtContactFax.uclDollarSign = False
        Me.txtContactFax.uclDotCount = 0
        Me.txtContactFax.uclIntCount = 2
        Me.txtContactFax.uclMinus = False
        Me.txtContactFax.uclReadOnly = False
        Me.txtContactFax.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtContactFax.uclTrimZero = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(415, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 674
        Me.Label6.Text = "合約機構請款類型"
        '
        'cmbContractTypeId
        '
        Me.cmbContractTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbContractTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbContractTypeId.DropDownWidth = 20
        Me.cmbContractTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbContractTypeId.Location = New System.Drawing.Point(554, 8)
        Me.cmbContractTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbContractTypeId.Name = "cmbContractTypeId"
        Me.cmbContractTypeId.SelectedIndex = -1
        Me.cmbContractTypeId.SelectedItem = Nothing
        Me.cmbContractTypeId.SelectedText = ""
        Me.cmbContractTypeId.SelectedValue = ""
        Me.cmbContractTypeId.SelectionStart = 0
        Me.cmbContractTypeId.Size = New System.Drawing.Size(172, 24)
        Me.cmbContractTypeId.TabIndex = 6
        Me.cmbContractTypeId.uclDisplayIndex = "0,1"
        Me.cmbContractTypeId.uclIsAutoClear = True
        Me.cmbContractTypeId.uclIsFirstItemEmpty = True
        Me.cmbContractTypeId.uclIsTextMode = False
        Me.cmbContractTypeId.uclShowMsg = False
        Me.cmbContractTypeId.uclValueIndex = "0"
        '
        'chbIsUseSet
        '
        Me.chbIsUseSet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbIsUseSet.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.chbIsUseSet, 2)
        Me.chbIsUseSet.Location = New System.Drawing.Point(736, 10)
        Me.chbIsUseSet.Name = "chbIsUseSet"
        Me.chbIsUseSet.Size = New System.Drawing.Size(187, 20)
        Me.chbIsUseSet.TabIndex = 7
        Me.chbIsUseSet.Text = "是否參考折扣及記帳檔"
        Me.chbIsUseSet.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "*合約機關代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(331, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "合約機關名稱"
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(690, 10)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 113
        Me.lblSubIdentityCode.Text = "*隸屬身份二"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblCheckQuotaId, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCheckQuotaId, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUpperAmtTypeId, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbUpperAmtTypeId, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubIdentityCode, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSubIdentityCode, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUpperAmt, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUpperAmt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContractCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContractName, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1002, 80)
        Me.TableLayoutPanel1.TabIndex = 58
        '
        'lblCheckQuotaId
        '
        Me.lblCheckQuotaId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCheckQuotaId.AutoSize = True
        Me.lblCheckQuotaId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblCheckQuotaId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCheckQuotaId.Location = New System.Drawing.Point(650, 50)
        Me.lblCheckQuotaId.Name = "lblCheckQuotaId"
        Me.lblCheckQuotaId.Size = New System.Drawing.Size(136, 16)
        Me.lblCheckQuotaId.TabIndex = 119
        Me.lblCheckQuotaId.Text = "檢查累積記帳額度"
        '
        'cmbCheckQuotaId
        '
        Me.cmbCheckQuotaId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbCheckQuotaId, 2)
        Me.cmbCheckQuotaId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbCheckQuotaId.DropDownWidth = 20
        Me.cmbCheckQuotaId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbCheckQuotaId.Location = New System.Drawing.Point(793, 46)
        Me.cmbCheckQuotaId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCheckQuotaId.Name = "cmbCheckQuotaId"
        Me.cmbCheckQuotaId.SelectedIndex = -1
        Me.cmbCheckQuotaId.SelectedItem = Nothing
        Me.cmbCheckQuotaId.SelectedText = ""
        Me.cmbCheckQuotaId.SelectedValue = ""
        Me.cmbCheckQuotaId.SelectionStart = 0
        Me.cmbCheckQuotaId.Size = New System.Drawing.Size(182, 24)
        Me.cmbCheckQuotaId.TabIndex = 6
        Me.cmbCheckQuotaId.uclDisplayIndex = "0,1"
        Me.cmbCheckQuotaId.uclIsAutoClear = True
        Me.cmbCheckQuotaId.uclIsFirstItemEmpty = True
        Me.cmbCheckQuotaId.uclIsTextMode = False
        Me.cmbCheckQuotaId.uclShowMsg = False
        Me.cmbCheckQuotaId.uclValueIndex = "0"
        '
        'lblUpperAmtTypeId
        '
        Me.lblUpperAmtTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUpperAmtTypeId.AutoSize = True
        Me.lblUpperAmtTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblUpperAmtTypeId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUpperAmtTypeId.Location = New System.Drawing.Point(299, 50)
        Me.lblUpperAmtTypeId.Name = "lblUpperAmtTypeId"
        Me.lblUpperAmtTypeId.Size = New System.Drawing.Size(136, 16)
        Me.lblUpperAmtTypeId.TabIndex = 117
        Me.lblUpperAmtTypeId.Text = "記帳上限處理方式"
        '
        'cmbUpperAmtTypeId
        '
        Me.cmbUpperAmtTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbUpperAmtTypeId, 2)
        Me.cmbUpperAmtTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbUpperAmtTypeId.DropDownWidth = 20
        Me.cmbUpperAmtTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbUpperAmtTypeId.Location = New System.Drawing.Point(442, 46)
        Me.cmbUpperAmtTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUpperAmtTypeId.Name = "cmbUpperAmtTypeId"
        Me.cmbUpperAmtTypeId.SelectedIndex = -1
        Me.cmbUpperAmtTypeId.SelectedItem = Nothing
        Me.cmbUpperAmtTypeId.SelectedText = ""
        Me.cmbUpperAmtTypeId.SelectedValue = ""
        Me.cmbUpperAmtTypeId.SelectionStart = 0
        Me.cmbUpperAmtTypeId.Size = New System.Drawing.Size(201, 24)
        Me.cmbUpperAmtTypeId.TabIndex = 5
        Me.cmbUpperAmtTypeId.uclDisplayIndex = "0,1"
        Me.cmbUpperAmtTypeId.uclIsAutoClear = True
        Me.cmbUpperAmtTypeId.uclIsFirstItemEmpty = True
        Me.cmbUpperAmtTypeId.uclIsTextMode = False
        Me.cmbUpperAmtTypeId.uclShowMsg = False
        Me.cmbUpperAmtTypeId.uclValueIndex = "0"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbSubIdentityCode, 2)
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(793, 6)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(182, 24)
        Me.cmbSubIdentityCode.TabIndex = 3
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'lblUpperAmt
        '
        Me.lblUpperAmt.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUpperAmt.AutoSize = True
        Me.lblUpperAmt.ForeColor = System.Drawing.Color.Black
        Me.lblUpperAmt.Location = New System.Drawing.Point(11, 50)
        Me.lblUpperAmt.Name = "lblUpperAmt"
        Me.lblUpperAmt.Size = New System.Drawing.Size(104, 16)
        Me.lblUpperAmt.TabIndex = 115
        Me.lblUpperAmt.Text = "記帳上限金額"
        '
        'txtUpperAmt
        '
        Me.txtUpperAmt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtUpperAmt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtUpperAmt.Location = New System.Drawing.Point(122, 45)
        Me.txtUpperAmt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUpperAmt.MaxLength = 19
        Me.txtUpperAmt.Name = "txtUpperAmt"
        Me.txtUpperAmt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUpperAmt.SelectionStart = 0
        Me.txtUpperAmt.Size = New System.Drawing.Size(170, 27)
        Me.txtUpperAmt.TabIndex = 4
        Me.txtUpperAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtUpperAmt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtUpperAmt.ToolTipTag = Nothing
        Me.txtUpperAmt.uclDollarSign = False
        Me.txtUpperAmt.uclDotCount = 1
        Me.txtUpperAmt.uclIntCount = 17
        Me.txtUpperAmt.uclMinus = False
        Me.txtUpperAmt.uclReadOnly = False
        Me.txtUpperAmt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtUpperAmt.uclTrimZero = True
        '
        'txtContractCode
        '
        Me.txtContractCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtContractCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtContractCode.Location = New System.Drawing.Point(122, 5)
        Me.txtContractCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContractCode.MaxLength = 10
        Me.txtContractCode.Name = "txtContractCode"
        Me.txtContractCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContractCode.SelectionStart = 0
        Me.txtContractCode.Size = New System.Drawing.Size(170, 27)
        Me.txtContractCode.TabIndex = 1
        Me.txtContractCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContractCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContractCode.ToolTipTag = Nothing
        Me.txtContractCode.uclDollarSign = False
        Me.txtContractCode.uclDotCount = 0
        Me.txtContractCode.uclIntCount = 2
        Me.txtContractCode.uclMinus = False
        Me.txtContractCode.uclReadOnly = False
        Me.txtContractCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtContractCode.uclTrimZero = True
        '
        'txtContractName
        '
        Me.txtContractName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtContractName, 2)
        Me.txtContractName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtContractName.Location = New System.Drawing.Point(442, 5)
        Me.txtContractName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContractName.MaxLength = 50
        Me.txtContractName.Name = "txtContractName"
        Me.txtContractName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtContractName.SelectionStart = 0
        Me.txtContractName.Size = New System.Drawing.Size(201, 27)
        Me.txtContractName.TabIndex = 2
        Me.txtContractName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtContractName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtContractName.ToolTipTag = Nothing
        Me.txtContractName.uclDollarSign = False
        Me.txtContractName.uclDotCount = 0
        Me.txtContractName.uclIntCount = 2
        Me.txtContractName.uclMinus = False
        Me.txtContractName.uclReadOnly = False
        Me.txtContractName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtContractName.uclTrimZero = True
        '
        'gpbInput
        '
        Me.gpbInput.Controls.Add(Me.TableLayoutPanel2)
        Me.gpbInput.Location = New System.Drawing.Point(0, 99)
        Me.gpbInput.Name = "gpbInput"
        Me.gpbInput.Size = New System.Drawing.Size(1012, 346)
        Me.gpbInput.TabIndex = 58
        Me.gpbInput.TabStop = False
        '
        'conditionsPanel1
        '
        Me.conditionsPanel1.Controls.Add(Me.gpbInput)
        Me.conditionsPanel1.Controls.Add(Me.gpbConditions)
        Me.conditionsPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.conditionsPanel1.Location = New System.Drawing.Point(0, 0)
        Me.conditionsPanel1.Name = "conditionsPanel1"
        Me.conditionsPanel1.Size = New System.Drawing.Size(1017, 451)
        Me.conditionsPanel1.TabIndex = 335
        '
        'gpbConditions
        '
        Me.gpbConditions.Controls.Add(Me.TableLayoutPanel1)
        Me.gpbConditions.ForeColor = System.Drawing.Color.RoyalBlue
        Me.gpbConditions.Location = New System.Drawing.Point(0, 0)
        Me.gpbConditions.Name = "gpbConditions"
        Me.gpbConditions.Size = New System.Drawing.Size(1012, 99)
        Me.gpbConditions.TabIndex = 57
        Me.gpbConditions.TabStop = False
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.tlp_GridView)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(0, 451)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(1017, 272)
        Me.dgvPanel.TabIndex = 336
        '
        'tlp_GridView
        '
        Me.tlp_GridView.ColumnCount = 1
        Me.tlp_GridView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_GridView.Controls.Add(Me.dgvShowData, 0, 1)
        Me.tlp_GridView.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.tlp_GridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_GridView.Location = New System.Drawing.Point(0, 0)
        Me.tlp_GridView.Name = "tlp_GridView"
        Me.tlp_GridView.RowCount = 2
        Me.tlp_GridView.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_GridView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_GridView.Size = New System.Drawing.Size(1017, 272)
        Me.tlp_GridView.TabIndex = 3
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
        Me.dgvShowData.Location = New System.Drawing.Point(0, 33)
        Me.dgvShowData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvShowData.MultiSelect = False
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.ReadOnly = True
        Me.dgvShowData.RowHeadersVisible = False
        Me.dgvShowData.RowTemplate.Height = 24
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(1009, 223)
        Me.dgvShowData.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnClear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnQuery)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUpdate)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnInsert)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1012, 33)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(919, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Location = New System.Drawing.Point(823, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 3
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(727, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(90, 28)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "F10-修改"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Location = New System.Drawing.Point(631, 3)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(90, 28)
        Me.btnInsert.TabIndex = 0
        Me.btnInsert.Text = "F12-新增"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'PUBContractUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 723)
        Me.Controls.Add(Me.dgvPanel)
        Me.Controls.Add(Me.conditionsPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Name = "PUBContractUI"
        Me.TabText = "合約機構基本檔"
        Me.Text = "合約機構基本檔"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gpbInput.ResumeLayout(False)
        Me.conditionsPanel1.ResumeLayout(False)
        Me.gpbConditions.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        Me.tlp_GridView.ResumeLayout(False)
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtProjectDirector As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblProjectDirector As System.Windows.Forms.Label
    Friend WithEvents lblDrugCode As System.Windows.Forms.Label
    Friend WithEvents lblDrugCommitteeSn As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblContactEmail As System.Windows.Forms.Label
    Friend WithEvents lblProjectEffectDate As System.Windows.Forms.Label
    Friend WithEvents lblProjectEndDate As System.Windows.Forms.Label
    Friend WithEvents txtDrugCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents UclZipCodeAddress As Syscom.Client.UCL.UCLCensusAddrUC
    Friend WithEvents txtDrugName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDrugCommitteeSn As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContactTel1 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContactEmail As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gpbInput As System.Windows.Forms.GroupBox
    Friend WithEvents conditionsPanel1 As System.Windows.Forms.Panel
    Friend WithEvents gpbConditions As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblUpperAmt As System.Windows.Forms.Label
    Friend WithEvents txtUpperAmt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblUpperAmtTypeId As System.Windows.Forms.Label
    Friend WithEvents cmbUpperAmtTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblCheckQuotaId As System.Windows.Forms.Label
    Friend WithEvents cmbCheckQuotaId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblMemo As System.Windows.Forms.Label
    Friend WithEvents txtMemo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblContactAddress As System.Windows.Forms.Label
    Friend WithEvents txtContactTel3 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContactTel2 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblContactTelMobile As System.Windows.Forms.Label
    Friend WithEvents txtContactName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblReceiptTitle As System.Windows.Forms.Label
    Friend WithEvents txtReceiptTitle As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtpProjectEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtpProjectEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDisRate As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtAddRate As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chkDC As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContactTelMobile As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContactFax As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContractCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtContractName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dgvPanel As System.Windows.Forms.Panel
    Friend WithEvents tlp_GridView As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbContractTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents chbIsUseSet As System.Windows.Forms.CheckBox
End Class
