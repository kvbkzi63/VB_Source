<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSubIdentityUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSubIdentityUI))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSubIdentityName = New System.Windows.Forms.Label()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.txtSubIdentityName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtSubIdentityCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblMainIdentityId = New System.Windows.Forms.Label()
        Me.cmbMainIdentityId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ckbIsOpd = New System.Windows.Forms.CheckBox()
        Me.ckbIsIpd = New System.Windows.Forms.CheckBox()
        Me.ckbIsBillClose = New System.Windows.Forms.CheckBox()
        Me.ckbIsEmg = New System.Windows.Forms.CheckBox()
        Me.ckbDC = New System.Windows.Forms.CheckBox()
        Me.ckbIsOhm = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 110)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(925, 357)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(923, 320)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(923, 320)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pal_Mantain)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(925, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'pal_Mantain
        '
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(3, 23)
        Me.pal_Mantain.Margin = New System.Windows.Forms.Padding(4)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(919, 80)
        Me.pal_Mantain.TabIndex = 7
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.BackColor = System.Drawing.SystemColors.Control
        Me.tlp_nonButton.ColumnCount = 7
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityName, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblSubIdentityCode, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtSubIdentityName, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtSubIdentityCode, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblMainIdentityId, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.cmbMainIdentityId, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.ckbIsOpd, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.ckbIsIpd, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.ckbIsBillClose, 6, 0)
        Me.tlp_nonButton.Controls.Add(Me.ckbIsEmg, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.ckbDC, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.ckbIsOhm, 6, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(919, 80)
        Me.tlp_nonButton.TabIndex = 10
        '
        'lblSubIdentityName
        '
        Me.lblSubIdentityName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityName.AutoSize = True
        Me.lblSubIdentityName.ForeColor = System.Drawing.Color.Black
        Me.lblSubIdentityName.Location = New System.Drawing.Point(11, 52)
        Me.lblSubIdentityName.Name = "lblSubIdentityName"
        Me.lblSubIdentityName.Size = New System.Drawing.Size(88, 16)
        Me.lblSubIdentityName.TabIndex = 7
        Me.lblSubIdentityName.Text = "身份二名稱"
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(3, 12)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 0
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'txtSubIdentityName
        '
        Me.txtSubIdentityName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_nonButton.SetColumnSpan(Me.txtSubIdentityName, 3)
        Me.txtSubIdentityName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSubIdentityName.Location = New System.Drawing.Point(106, 46)
        Me.txtSubIdentityName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubIdentityName.MaxLength = 50
        Me.txtSubIdentityName.Name = "txtSubIdentityName"
        Me.txtSubIdentityName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSubIdentityName.SelectionStart = 0
        Me.txtSubIdentityName.Size = New System.Drawing.Size(404, 27)
        Me.txtSubIdentityName.TabIndex = 8
        Me.txtSubIdentityName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSubIdentityName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSubIdentityName.ToolTipTag = Nothing
        Me.txtSubIdentityName.uclDollarSign = False
        Me.txtSubIdentityName.uclDotCount = 0
        Me.txtSubIdentityName.uclIntCount = 2
        Me.txtSubIdentityName.uclMinus = False
        Me.txtSubIdentityName.uclReadOnly = False
        Me.txtSubIdentityName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSubIdentityName.uclTrimZero = True
        '
        'txtSubIdentityCode
        '
        Me.txtSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSubIdentityCode.Location = New System.Drawing.Point(106, 6)
        Me.txtSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubIdentityCode.MaxLength = 2
        Me.txtSubIdentityCode.Name = "txtSubIdentityCode"
        Me.txtSubIdentityCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSubIdentityCode.SelectionStart = 0
        Me.txtSubIdentityCode.Size = New System.Drawing.Size(105, 27)
        Me.txtSubIdentityCode.TabIndex = 1
        Me.txtSubIdentityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSubIdentityCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSubIdentityCode.ToolTipTag = Nothing
        Me.txtSubIdentityCode.uclDollarSign = False
        Me.txtSubIdentityCode.uclDotCount = 0
        Me.txtSubIdentityCode.uclIntCount = 2
        Me.txtSubIdentityCode.uclMinus = False
        Me.txtSubIdentityCode.uclReadOnly = False
        Me.txtSubIdentityCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSubIdentityCode.uclTrimZero = True
        '
        'lblMainIdentityId
        '
        Me.lblMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMainIdentityId.AutoSize = True
        Me.lblMainIdentityId.ForeColor = System.Drawing.Color.Red
        Me.lblMainIdentityId.Location = New System.Drawing.Point(218, 12)
        Me.lblMainIdentityId.Name = "lblMainIdentityId"
        Me.lblMainIdentityId.Size = New System.Drawing.Size(96, 16)
        Me.lblMainIdentityId.TabIndex = 2
        Me.lblMainIdentityId.Text = "*隸屬主身份"
        '
        'cmbMainIdentityId
        '
        Me.cmbMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMainIdentityId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMainIdentityId.DropDownWidth = 20
        Me.cmbMainIdentityId.DroppedDown = False
        Me.cmbMainIdentityId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMainIdentityId.Location = New System.Drawing.Point(321, 8)
        Me.cmbMainIdentityId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMainIdentityId.Name = "cmbMainIdentityId"
        Me.cmbMainIdentityId.SelectedIndex = -1
        Me.cmbMainIdentityId.SelectedItem = Nothing
        Me.cmbMainIdentityId.SelectedText = ""
        Me.cmbMainIdentityId.SelectedValue = ""
        Me.cmbMainIdentityId.SelectionStart = 0
        Me.cmbMainIdentityId.Size = New System.Drawing.Size(189, 24)
        Me.cmbMainIdentityId.TabIndex = 3
        Me.cmbMainIdentityId.uclDisplayIndex = "0,1"
        Me.cmbMainIdentityId.uclIsAutoClear = True
        Me.cmbMainIdentityId.uclIsFirstItemEmpty = True
        Me.cmbMainIdentityId.uclIsTextMode = False
        Me.cmbMainIdentityId.uclShowMsg = False
        Me.cmbMainIdentityId.uclValueIndex = "0"
        '
        'ckbIsOpd
        '
        Me.ckbIsOpd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsOpd.AutoSize = True
        Me.ckbIsOpd.ForeColor = System.Drawing.Color.Black
        Me.ckbIsOpd.Location = New System.Drawing.Point(517, 10)
        Me.ckbIsOpd.Name = "ckbIsOpd"
        Me.ckbIsOpd.Size = New System.Drawing.Size(91, 20)
        Me.ckbIsOpd.TabIndex = 5
        Me.ckbIsOpd.Text = "門診使用"
        Me.ckbIsOpd.UseVisualStyleBackColor = True
        '
        'ckbIsIpd
        '
        Me.ckbIsIpd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsIpd.AutoSize = True
        Me.ckbIsIpd.ForeColor = System.Drawing.Color.Black
        Me.ckbIsIpd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ckbIsIpd.Location = New System.Drawing.Point(517, 50)
        Me.ckbIsIpd.Name = "ckbIsIpd"
        Me.ckbIsIpd.Size = New System.Drawing.Size(91, 20)
        Me.ckbIsIpd.TabIndex = 9
        Me.ckbIsIpd.Text = "住診使用"
        Me.ckbIsIpd.UseVisualStyleBackColor = True
        '
        'ckbIsBillClose
        '
        Me.ckbIsBillClose.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsBillClose.AutoSize = True
        Me.ckbIsBillClose.ForeColor = System.Drawing.Color.Black
        Me.ckbIsBillClose.Location = New System.Drawing.Point(711, 10)
        Me.ckbIsBillClose.Name = "ckbIsBillClose"
        Me.ckbIsBillClose.Size = New System.Drawing.Size(155, 20)
        Me.ckbIsBillClose.TabIndex = 10
        Me.ckbIsBillClose.Text = "是否直接自動結清"
        Me.ckbIsBillClose.UseVisualStyleBackColor = True
        '
        'ckbIsEmg
        '
        Me.ckbIsEmg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsEmg.AutoSize = True
        Me.ckbIsEmg.ForeColor = System.Drawing.Color.Black
        Me.ckbIsEmg.Location = New System.Drawing.Point(614, 10)
        Me.ckbIsEmg.Name = "ckbIsEmg"
        Me.ckbIsEmg.Size = New System.Drawing.Size(91, 20)
        Me.ckbIsEmg.TabIndex = 6
        Me.ckbIsEmg.Text = "急診使用"
        Me.ckbIsEmg.UseVisualStyleBackColor = True
        '
        'ckbDC
        '
        Me.ckbDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDC.AutoSize = True
        Me.ckbDC.ForeColor = System.Drawing.Color.Black
        Me.ckbDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ckbDC.Location = New System.Drawing.Point(614, 50)
        Me.ckbDC.Name = "ckbDC"
        Me.ckbDC.Size = New System.Drawing.Size(59, 20)
        Me.ckbDC.TabIndex = 11
        Me.ckbDC.Text = "停用"
        Me.ckbDC.UseVisualStyleBackColor = True
        '
        'ckbIsOhm
        '
        Me.ckbIsOhm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbIsOhm.AutoSize = True
        Me.ckbIsOhm.ForeColor = System.Drawing.Color.Black
        Me.ckbIsOhm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ckbIsOhm.Location = New System.Drawing.Point(711, 50)
        Me.ckbIsOhm.Name = "ckbIsOhm"
        Me.ckbIsOhm.Size = New System.Drawing.Size(91, 20)
        Me.ckbIsOhm.TabIndex = 12
        Me.ckbIsOhm.Text = "健檢使用"
        Me.ckbIsOhm.UseVisualStyleBackColor = True
        '
        'PUBSubIdentityUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 467)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PUBSubIdentityUI"
        Me.TabText = "身份二代碼基本檔維護"
        Me.Text = "身份二代碼基本檔維護"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pal_Mantain.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pal_Mantain As System.Windows.Forms.Panel
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents lblMainIdentityId As System.Windows.Forms.Label
    Friend WithEvents txtSubIdentityName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ckbDC As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMainIdentityId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblSubIdentityName As System.Windows.Forms.Label
    Friend WithEvents txtSubIdentityCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ckbIsEmg As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIsOpd As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIsIpd As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIsBillClose As System.Windows.Forms.CheckBox
    Friend WithEvents ckbIsOhm As System.Windows.Forms.CheckBox
End Class
