<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPatientSevereDiseaseUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI


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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblChartNo = New System.Windows.Forms.Label()
        Me.lblIdNo = New System.Windows.Forms.Label()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.lblEffectDate = New System.Windows.Forms.Label()
        Me.lblIcdCode = New System.Windows.Forms.Label()
        Me.lblEnName = New System.Windows.Forms.Label()
        Me.txtIdNo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtPatientName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dtpEffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txtEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btnQueryModifyLog = New System.Windows.Forms.Button()
        Me.txtChartNo = New System.Windows.Forms.TextBox()
        Me.txtIcdCode = New System.Windows.Forms.TextBox()
        Me.chkIsFromIcCard = New System.Windows.Forms.CheckBox()
        Me.dtpEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblCertificateSn = New System.Windows.Forms.Label()
        Me.txtCertificateSn = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtCnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblCnName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 112)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(992, 401)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(990, 364)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(990, 364)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 112)
        Me.Panel1.TabIndex = 0
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblChartNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEffectDate, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIcdCode, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEnName, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEffectDate, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEnName, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnQueryModifyLog, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChartNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIcdCode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkIsFromIcCard, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCertificateSn, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCertificateSn, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCnName, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCnName, 6, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(990, 110)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblChartNo
        '
        Me.lblChartNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblChartNo.AutoSize = True
        Me.lblChartNo.ForeColor = System.Drawing.Color.Red
        Me.lblChartNo.Location = New System.Drawing.Point(22, 10)
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Size = New System.Drawing.Size(64, 16)
        Me.lblChartNo.TabIndex = 0
        Me.lblChartNo.Text = "*病歷號"
        '
        'lblIdNo
        '
        Me.lblIdNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblIdNo.AutoSize = True
        Me.lblIdNo.Location = New System.Drawing.Point(249, 10)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(72, 16)
        Me.lblIdNo.TabIndex = 1
        Me.lblIdNo.Text = "身份證號"
        '
        'lblPatientName
        '
        Me.lblPatientName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Location = New System.Drawing.Point(486, 10)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(40, 16)
        Me.lblPatientName.TabIndex = 2
        Me.lblPatientName.Text = "姓名"
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(726, 10)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEffectDate.TabIndex = 3
        Me.lblEffectDate.Text = "*生效日"
        '
        'lblIcdCode
        '
        Me.lblIcdCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblIcdCode.AutoSize = True
        Me.lblIcdCode.ForeColor = System.Drawing.Color.Red
        Me.lblIcdCode.Location = New System.Drawing.Point(3, 47)
        Me.lblIcdCode.Name = "lblIcdCode"
        Me.lblIcdCode.Size = New System.Drawing.Size(83, 16)
        Me.lblIcdCode.TabIndex = 4
        Me.lblIcdCode.Text = "*ICD_Code"
        '
        'lblEnName
        '
        Me.lblEnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEnName.AutoSize = True
        Me.lblEnName.Location = New System.Drawing.Point(233, 47)
        Me.lblEnName.Name = "lblEnName"
        Me.lblEnName.Size = New System.Drawing.Size(88, 16)
        Me.lblEnName.TabIndex = 5
        Me.lblEnName.Text = "診斷英文名"
        '
        'txtIdNo
        '
        Me.txtIdNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtIdNo.Enabled = False
        Me.txtIdNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtIdNo.Location = New System.Drawing.Point(327, 5)
        Me.txtIdNo.MaxLength = 10
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdNo.SelectionStart = 0
        Me.txtIdNo.Size = New System.Drawing.Size(153, 27)
        Me.txtIdNo.TabIndex = 2
        Me.txtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIdNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtIdNo.ToolTipTag = Nothing
        Me.txtIdNo.uclDollarSign = False
        Me.txtIdNo.uclDotCount = 0
        Me.txtIdNo.uclIntCount = 2
        Me.txtIdNo.uclMinus = False
        Me.txtIdNo.uclReadOnly = True
        Me.txtIdNo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtIdNo.uclTrimZero = True
        '
        'txtPatientName
        '
        Me.txtPatientName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPatientName.Enabled = False
        Me.txtPatientName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPatientName.Location = New System.Drawing.Point(532, 5)
        Me.txtPatientName.MaxLength = 10
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPatientName.SelectionStart = 0
        Me.txtPatientName.Size = New System.Drawing.Size(164, 27)
        Me.txtPatientName.TabIndex = 3
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
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(796, 5)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(135, 27)
        Me.dtpEffectDate.TabIndex = 4
        Me.dtpEffectDate.uclReadOnly = False
        '
        'txtEnName
        '
        Me.txtEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtEnName, 3)
        Me.txtEnName.Enabled = False
        Me.txtEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtEnName.Location = New System.Drawing.Point(327, 42)
        Me.txtEnName.MaxLength = 300
        Me.txtEnName.Name = "txtEnName"
        Me.txtEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEnName.SelectionStart = 0
        Me.txtEnName.Size = New System.Drawing.Size(369, 27)
        Me.txtEnName.TabIndex = 6
        Me.txtEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtEnName.ToolTipTag = Nothing
        Me.txtEnName.uclDollarSign = False
        Me.txtEnName.uclDotCount = 0
        Me.txtEnName.uclIntCount = 2
        Me.txtEnName.uclMinus = False
        Me.txtEnName.uclReadOnly = True
        Me.txtEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtEnName.uclTrimZero = True
        '
        'btnQueryModifyLog
        '
        Me.btnQueryModifyLog.AutoSize = True
        Me.btnQueryModifyLog.Location = New System.Drawing.Point(796, 77)
        Me.btnQueryModifyLog.Name = "btnQueryModifyLog"
        Me.btnQueryModifyLog.Size = New System.Drawing.Size(122, 26)
        Me.btnQueryModifyLog.TabIndex = 16
        Me.btnQueryModifyLog.Text = "異動記錄查詢"
        Me.btnQueryModifyLog.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnQueryModifyLog.UseVisualStyleBackColor = True
        Me.btnQueryModifyLog.Visible = False
        '
        'txtChartNo
        '
        Me.txtChartNo.Location = New System.Drawing.Point(92, 3)
        Me.txtChartNo.MaxLength = 10
        Me.txtChartNo.Name = "txtChartNo"
        Me.txtChartNo.Size = New System.Drawing.Size(127, 27)
        Me.txtChartNo.TabIndex = 17
        '
        'txtIcdCode
        '
        Me.txtIcdCode.Location = New System.Drawing.Point(92, 40)
        Me.txtIcdCode.Name = "txtIcdCode"
        Me.txtIcdCode.Size = New System.Drawing.Size(127, 27)
        Me.txtIcdCode.TabIndex = 18
        '
        'chkIsFromIcCard
        '
        Me.chkIsFromIcCard.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsFromIcCard.AutoSize = True
        Me.chkIsFromIcCard.Location = New System.Drawing.Point(532, 82)
        Me.chkIsFromIcCard.Name = "chkIsFromIcCard"
        Me.chkIsFromIcCard.Size = New System.Drawing.Size(129, 20)
        Me.chkIsFromIcCard.TabIndex = 15
        Me.chkIsFromIcCard.Text = "Is_From_IcCard"
        Me.chkIsFromIcCard.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(327, 78)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(127, 27)
        Me.dtpEndDate.TabIndex = 8
        Me.dtpEndDate.uclReadOnly = False
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(265, 84)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 14
        Me.lblEndDate.Text = "結束日"
        '
        'lblCertificateSn
        '
        Me.lblCertificateSn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCertificateSn.AutoSize = True
        Me.lblCertificateSn.Location = New System.Drawing.Point(14, 84)
        Me.lblCertificateSn.Name = "lblCertificateSn"
        Me.lblCertificateSn.Size = New System.Drawing.Size(72, 16)
        Me.lblCertificateSn.TabIndex = 6
        Me.lblCertificateSn.Text = "證明文號"
        '
        'txtCertificateSn
        '
        Me.txtCertificateSn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCertificateSn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtCertificateSn.Location = New System.Drawing.Point(92, 78)
        Me.txtCertificateSn.MaxLength = 10
        Me.txtCertificateSn.Name = "txtCertificateSn"
        Me.txtCertificateSn.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCertificateSn.SelectionStart = 0
        Me.txtCertificateSn.Size = New System.Drawing.Size(135, 27)
        Me.txtCertificateSn.TabIndex = 7
        Me.txtCertificateSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCertificateSn.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtCertificateSn.ToolTipTag = Nothing
        Me.txtCertificateSn.uclDollarSign = False
        Me.txtCertificateSn.uclDotCount = 0
        Me.txtCertificateSn.uclIntCount = 2
        Me.txtCertificateSn.uclMinus = False
        Me.txtCertificateSn.uclReadOnly = False
        Me.txtCertificateSn.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtCertificateSn.uclTrimZero = True
        '
        'txtCnName
        '
        Me.txtCnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCnName.Enabled = False
        Me.txtCnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtCnName.Location = New System.Drawing.Point(796, 42)
        Me.txtCnName.MaxLength = 10
        Me.txtCnName.Name = "txtCnName"
        Me.txtCnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCnName.SelectionStart = 0
        Me.txtCnName.Size = New System.Drawing.Size(191, 27)
        Me.txtCnName.TabIndex = 19
        Me.txtCnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtCnName.ToolTipTag = Nothing
        Me.txtCnName.uclDollarSign = False
        Me.txtCnName.uclDotCount = 0
        Me.txtCnName.uclIntCount = 2
        Me.txtCnName.uclMinus = False
        Me.txtCnName.uclReadOnly = False
        Me.txtCnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtCnName.uclTrimZero = True
        '
        'lblCnName
        '
        Me.lblCnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCnName.AutoSize = True
        Me.lblCnName.Location = New System.Drawing.Point(702, 47)
        Me.lblCnName.Name = "lblCnName"
        Me.lblCnName.Size = New System.Drawing.Size(88, 16)
        Me.lblCnName.TabIndex = 20
        Me.lblCnName.Text = "診斷中文名"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(233, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 16)
        Me.Label8.TabIndex = 1
        '
        'PUBPatientSevereDiseaseUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 513)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PUBPatientSevereDiseaseUI"
        Me.Text = "病患重大傷病記錄檔"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblChartNo As System.Windows.Forms.Label
    Friend WithEvents lblIdNo As System.Windows.Forms.Label
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents lblIcdCode As System.Windows.Forms.Label
    Friend WithEvents lblEnName As System.Windows.Forms.Label
    Friend WithEvents lblCertificateSn As System.Windows.Forms.Label
    Friend WithEvents txtIdNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtPatientName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtCertificateSn As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents chkIsFromIcCard As System.Windows.Forms.CheckBox
    Friend WithEvents btnQueryModifyLog As System.Windows.Forms.Button
    Friend WithEvents txtChartNo As System.Windows.Forms.TextBox
    Friend WithEvents txtIcdCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblCnName As System.Windows.Forms.Label
End Class
