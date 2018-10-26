<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPatientHealthCardUI
    Inherits Syscom.Client.UCL.IMaintainFormUI
    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblChartNo = New System.Windows.Forms.Label
        Me.lblIdNo = New System.Windows.Forms.Label
        Me.txtIdNo = New syscom.client.ucl.UCLTextBoxUC
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.lblHealthCardSn = New System.Windows.Forms.Label
        Me.lblHealthCardClass = New System.Windows.Forms.Label
        Me.dtpEndDate = New syscom.client.ucl.UCLDateTimePickerUC
        Me.txtHealthCardSn = New syscom.client.ucl.UCLTextBoxUC
        Me.txtHealthCardClass = New syscom.client.ucl.UCLTextBoxUC
        Me.lblEffectDate = New System.Windows.Forms.Label
        Me.dtpEffectDate = New syscom.client.ucl.UCLDateTimePickerUC
        Me.lblPatientName = New System.Windows.Forms.Label
        Me.txtPatientName = New syscom.client.ucl.UCLTextBoxUC
        Me.txtChartNo = New syscom.client.ucl.UCLChartNoUC
        Me.ChkBox_DC = New System.Windows.Forms.CheckBox
        Me.dtpSTOPtDate = New syscom.client.ucl.UCLDateTimePickerUC
        Me.IMaintainPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IMaintainPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.IMaintainPanel.Location = New System.Drawing.Point(0, 88)
        Me.IMaintainPanel.Size = New System.Drawing.Size(852, 412)
        '
        'dgvPanel
        '
        Me.dgvPanel.Size = New System.Drawing.Size(850, 375)
        Me.dgvPanel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 88)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 88)
        Me.Panel2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblChartNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHealthCardSn, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHealthCardClass, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHealthCardSn, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHealthCardClass, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEffectDate, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChartNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ChkBox_DC, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpSTOPtDate, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEffectDate, 6, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(848, 86)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblChartNo
        '
        Me.lblChartNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblChartNo.AutoSize = True
        Me.lblChartNo.ForeColor = System.Drawing.Color.Red
        Me.lblChartNo.Location = New System.Drawing.Point(13, 13)
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Size = New System.Drawing.Size(64, 16)
        Me.lblChartNo.TabIndex = 0
        Me.lblChartNo.Text = "*病歷號"
        '
        'lblIdNo
        '
        Me.lblIdNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblIdNo.Location = New System.Drawing.Point(212, 10)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(69, 23)
        Me.lblIdNo.TabIndex = 1
        Me.lblIdNo.Text = "身份證號"
        '
        'txtIdNo
        '
        Me.txtIdNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtIdNo.Enabled = False
        Me.txtIdNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtIdNo.Location = New System.Drawing.Point(287, 8)
        Me.txtIdNo.MaxLength = 10
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtIdNo.SelectionStart = 0
        Me.txtIdNo.Size = New System.Drawing.Size(110, 27)
        Me.txtIdNo.TabIndex = 3
        Me.txtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIdNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtIdNo.uclDollarSign = False
        Me.txtIdNo.uclDotCount = 0
        Me.txtIdNo.uclIntCount = 2
        Me.txtIdNo.uclMinus = False
        Me.txtIdNo.uclReadOnly = True
        Me.txtIdNo.uclTextType = syscom.client.ucl.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lblEndDate
        '
        Me.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(21, 56)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 16)
        Me.lblEndDate.TabIndex = 6
        Me.lblEndDate.Text = "結束日"
        '
        'lblHealthCardSn
        '
        Me.lblHealthCardSn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblHealthCardSn.AutoSize = True
        Me.lblHealthCardSn.Location = New System.Drawing.Point(209, 56)
        Me.lblHealthCardSn.Name = "lblHealthCardSn"
        Me.lblHealthCardSn.Size = New System.Drawing.Size(72, 16)
        Me.lblHealthCardSn.TabIndex = 7
        Me.lblHealthCardSn.Text = "電腦編號"
        '
        'lblHealthCardClass
        '
        Me.lblHealthCardClass.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblHealthCardClass.AutoSize = True
        Me.lblHealthCardClass.Location = New System.Drawing.Point(408, 56)
        Me.lblHealthCardClass.Name = "lblHealthCardClass"
        Me.lblHealthCardClass.Size = New System.Drawing.Size(40, 16)
        Me.lblHealthCardClass.TabIndex = 8
        Me.lblHealthCardClass.Text = "類別"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEndDate.DisplayLocale = syscom.client.ucl.UCLDateTimePickerUC.Locale.US
        Me.dtpEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEndDate.Location = New System.Drawing.Point(83, 51)
        Me.dtpEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(114, 27)
        Me.dtpEndDate.TabIndex = 6
        Me.dtpEndDate.uclReadOnly = False
        '
        'txtHealthCardSn
        '
        Me.txtHealthCardSn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtHealthCardSn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtHealthCardSn.Location = New System.Drawing.Point(287, 51)
        Me.txtHealthCardSn.MaxLength = 10
        Me.txtHealthCardSn.Name = "txtHealthCardSn"
        Me.txtHealthCardSn.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHealthCardSn.SelectionStart = 0
        Me.txtHealthCardSn.Size = New System.Drawing.Size(110, 27)
        Me.txtHealthCardSn.TabIndex = 7
        Me.txtHealthCardSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtHealthCardSn.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtHealthCardSn.uclDollarSign = False
        Me.txtHealthCardSn.uclDotCount = 0
        Me.txtHealthCardSn.uclIntCount = 2
        Me.txtHealthCardSn.uclMinus = False
        Me.txtHealthCardSn.uclReadOnly = False
        Me.txtHealthCardSn.uclTextType = syscom.client.ucl.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'txtHealthCardClass
        '
        Me.txtHealthCardClass.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtHealthCardClass.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtHealthCardClass.Location = New System.Drawing.Point(454, 51)
        Me.txtHealthCardClass.MaxLength = 10
        Me.txtHealthCardClass.Name = "txtHealthCardClass"
        Me.txtHealthCardClass.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHealthCardClass.SelectionStart = 0
        Me.txtHealthCardClass.Size = New System.Drawing.Size(121, 27)
        Me.txtHealthCardClass.TabIndex = 8
        Me.txtHealthCardClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtHealthCardClass.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtHealthCardClass.uclDollarSign = False
        Me.txtHealthCardClass.uclDotCount = 0
        Me.txtHealthCardClass.uclIntCount = 2
        Me.txtHealthCardClass.uclMinus = False
        Me.txtHealthCardClass.uclReadOnly = False
        Me.txtHealthCardClass.uclTextType = syscom.client.ucl.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lblEffectDate
        '
        Me.lblEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblEffectDate.AutoSize = True
        Me.lblEffectDate.ForeColor = System.Drawing.Color.Red
        Me.lblEffectDate.Location = New System.Drawing.Point(647, 13)
        Me.lblEffectDate.Name = "lblEffectDate"
        Me.lblEffectDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEffectDate.TabIndex = 12
        Me.lblEffectDate.Text = "*生效日"
        '
        'dtpEffectDate
        '
        Me.dtpEffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpEffectDate.DisplayLocale = syscom.client.ucl.UCLDateTimePickerUC.Locale.US
        Me.dtpEffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpEffectDate.Location = New System.Drawing.Point(717, 8)
        Me.dtpEffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectDate.Name = "dtpEffectDate"
        Me.dtpEffectDate.Size = New System.Drawing.Size(118, 27)
        Me.dtpEffectDate.TabIndex = 5
        Me.dtpEffectDate.uclReadOnly = False
        '
        'lblPatientName
        '
        Me.lblPatientName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Location = New System.Drawing.Point(408, 13)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(40, 16)
        Me.lblPatientName.TabIndex = 14
        Me.lblPatientName.Text = "姓名"
        '
        'txtPatientName
        '
        Me.txtPatientName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtPatientName.Enabled = False
        Me.txtPatientName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtPatientName.Location = New System.Drawing.Point(454, 8)
        Me.txtPatientName.MaxLength = 10
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPatientName.SelectionStart = 0
        Me.txtPatientName.Size = New System.Drawing.Size(121, 27)
        Me.txtPatientName.TabIndex = 4
        Me.txtPatientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPatientName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtPatientName.uclDollarSign = False
        Me.txtPatientName.uclDotCount = 0
        Me.txtPatientName.uclIntCount = 2
        Me.txtPatientName.uclMinus = False
        Me.txtPatientName.uclReadOnly = True
        Me.txtPatientName.uclTextType = syscom.client.ucl.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'txtChartNo
        '
        Me.txtChartNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtChartNo.doFlag = False
        Me.txtChartNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtChartNo.IsShowAddress = False
        Me.txtChartNo.IsShowTelHome = False
        Me.txtChartNo.Location = New System.Drawing.Point(84, 8)
        Me.txtChartNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChartNo.Name = "txtChartNo"
        Me.txtChartNo.Size = New System.Drawing.Size(112, 27)
        Me.txtChartNo.TabIndex = 2
        Me.txtChartNo.uclDigitCount = 8
        Me.txtChartNo.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.txtChartNo.uclIsDoReserveChartNo = True
        Me.txtChartNo.uclIsInteractionChartNo = True
        Me.txtChartNo.uclIsNameInputAutoPopWindow = False
        Me.txtChartNo.uclNeedCheckId = True
        Me.txtChartNo.uclNeedCheckIdByPubBP = True
        Me.txtChartNo.uclNeedSql = True
        Me.txtChartNo.uclReadOnly = False
        Me.txtChartNo.uclTextType = syscom.client.ucl.UCLChartNoUC.uclTextTypeData.ChartNo
        Me.txtChartNo.uclTxtBoxWidth = 112
        '
        'ChkBox_DC
        '
        Me.ChkBox_DC.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ChkBox_DC.AutoSize = True
        Me.ChkBox_DC.Location = New System.Drawing.Point(588, 54)
        Me.ChkBox_DC.Name = "ChkBox_DC"
        Me.ChkBox_DC.Size = New System.Drawing.Size(123, 20)
        Me.ChkBox_DC.TabIndex = 15
        Me.ChkBox_DC.Text = "暫停給付藥物"
        Me.ChkBox_DC.UseVisualStyleBackColor = True
        '
        'dtpSTOPtDate
        '
        Me.dtpSTOPtDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpSTOPtDate.DisplayLocale = syscom.client.ucl.UCLDateTimePickerUC.Locale.US
        Me.dtpSTOPtDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpSTOPtDate.Location = New System.Drawing.Point(717, 51)
        Me.dtpSTOPtDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpSTOPtDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpSTOPtDate.Name = "dtpSTOPtDate"
        Me.dtpSTOPtDate.Size = New System.Drawing.Size(118, 27)
        Me.dtpSTOPtDate.TabIndex = 16
        Me.dtpSTOPtDate.uclReadOnly = False
        '
        'PUBPatientHealthCardUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 500)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PUBPatientHealthCardUI"
        Me.Text = "全國醫療服務卡維護檔"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IMaintainPanel, 0)
        Me.IMaintainPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblChartNo As System.Windows.Forms.Label
    Friend WithEvents lblIdNo As System.Windows.Forms.Label
    Friend WithEvents txtChartNo As Syscom.Client.UCL.UCLChartNoUC
    Friend WithEvents txtIdNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblHealthCardSn As System.Windows.Forms.Label
    Friend WithEvents lblHealthCardClass As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txtHealthCardSn As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtHealthCardClass As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblEffectDate As System.Windows.Forms.Label
    Friend WithEvents dtpEffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ChkBox_DC As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSTOPtDate As Syscom.Client.UCL.UCLDateTimePickerUC
End Class
