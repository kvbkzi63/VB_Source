<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBDisIdentityUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBDisIdentityUI))
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDisIdentityCode = New System.Windows.Forms.Label()
        Me.txtDisIdentityCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblDisIdentityName = New System.Windows.Forms.Label()
        Me.txtDisIdentityName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblDisIdentityTypeId = New System.Windows.Forms.Label()
        Me.cmbDisIdentityTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.chkDc = New System.Windows.Forms.CheckBox()
        Me.chkIsOnlineChoice = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 100)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 380)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(983, 343)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(983, 343)
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(985, 100)
        Me.pal_Mantain.TabIndex = 2
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 5
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.lblDisIdentityCode, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtDisIdentityCode, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDisIdentityName, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtDisIdentityName, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDisIdentityTypeId, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbDisIdentityTypeId, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.chkIsOnlineChoice, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.chkDc, 2, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(983, 98)
        Me.tlp_nonButton.TabIndex = 0
        '
        'lblDisIdentityCode
        '
        Me.lblDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDisIdentityCode.AutoSize = True
        Me.lblDisIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblDisIdentityCode.Location = New System.Drawing.Point(3, 16)
        Me.lblDisIdentityCode.Name = "lblDisIdentityCode"
        Me.lblDisIdentityCode.Size = New System.Drawing.Size(80, 16)
        Me.lblDisIdentityCode.TabIndex = 0
        Me.lblDisIdentityCode.Text = "*優待身份"
        '
        'txtDisIdentityCode
        '
        Me.txtDisIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDisIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDisIdentityCode.Location = New System.Drawing.Point(90, 11)
        Me.txtDisIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDisIdentityCode.MaxLength = 10
        Me.txtDisIdentityCode.Name = "txtDisIdentityCode"
        Me.txtDisIdentityCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDisIdentityCode.SelectionStart = 0
        Me.txtDisIdentityCode.Size = New System.Drawing.Size(150, 27)
        Me.txtDisIdentityCode.TabIndex = 1
        Me.txtDisIdentityCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDisIdentityCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDisIdentityCode.ToolTipTag = Nothing
        Me.txtDisIdentityCode.uclDollarSign = False
        Me.txtDisIdentityCode.uclDotCount = 0
        Me.txtDisIdentityCode.uclIntCount = 2
        Me.txtDisIdentityCode.uclMinus = False
        Me.txtDisIdentityCode.uclReadOnly = False
        Me.txtDisIdentityCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDisIdentityCode.uclTrimZero = True
        '
        'lblDisIdentityName
        '
        Me.lblDisIdentityName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDisIdentityName.AutoSize = True
        Me.lblDisIdentityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDisIdentityName.Location = New System.Drawing.Point(247, 16)
        Me.lblDisIdentityName.Name = "lblDisIdentityName"
        Me.lblDisIdentityName.Size = New System.Drawing.Size(104, 16)
        Me.lblDisIdentityName.TabIndex = 2
        Me.lblDisIdentityName.Text = "優待身份名稱"
        '
        'txtDisIdentityName
        '
        Me.txtDisIdentityName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_nonButton.SetColumnSpan(Me.txtDisIdentityName, 2)
        Me.txtDisIdentityName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDisIdentityName.Location = New System.Drawing.Point(358, 11)
        Me.txtDisIdentityName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDisIdentityName.MaxLength = 10
        Me.txtDisIdentityName.Name = "txtDisIdentityName"
        Me.txtDisIdentityName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDisIdentityName.SelectionStart = 0
        Me.txtDisIdentityName.Size = New System.Drawing.Size(596, 27)
        Me.txtDisIdentityName.TabIndex = 2
        Me.txtDisIdentityName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDisIdentityName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDisIdentityName.ToolTipTag = Nothing
        Me.txtDisIdentityName.uclDollarSign = False
        Me.txtDisIdentityName.uclDotCount = 0
        Me.txtDisIdentityName.uclIntCount = 2
        Me.txtDisIdentityName.uclMinus = False
        Me.txtDisIdentityName.uclReadOnly = False
        Me.txtDisIdentityName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDisIdentityName.uclTrimZero = True
        '
        'lblDisIdentityTypeId
        '
        Me.lblDisIdentityTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDisIdentityTypeId.AutoSize = True
        Me.lblDisIdentityTypeId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDisIdentityTypeId.Location = New System.Drawing.Point(11, 65)
        Me.lblDisIdentityTypeId.Name = "lblDisIdentityTypeId"
        Me.lblDisIdentityTypeId.Size = New System.Drawing.Size(72, 16)
        Me.lblDisIdentityTypeId.TabIndex = 4
        Me.lblDisIdentityTypeId.Text = "優待類別"
        Me.lblDisIdentityTypeId.Visible = False
        '
        'cmbDisIdentityTypeId
        '
        Me.cmbDisIdentityTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbDisIdentityTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbDisIdentityTypeId.DropDownWidth = 20
        Me.cmbDisIdentityTypeId.DroppedDown = False
        Me.cmbDisIdentityTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbDisIdentityTypeId.Location = New System.Drawing.Point(90, 61)
        Me.cmbDisIdentityTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDisIdentityTypeId.Name = "cmbDisIdentityTypeId"
        Me.cmbDisIdentityTypeId.SelectedIndex = -1
        Me.cmbDisIdentityTypeId.SelectedItem = Nothing
        Me.cmbDisIdentityTypeId.SelectedText = ""
        Me.cmbDisIdentityTypeId.SelectedValue = ""
        Me.cmbDisIdentityTypeId.SelectionStart = 0
        Me.cmbDisIdentityTypeId.Size = New System.Drawing.Size(150, 24)
        Me.cmbDisIdentityTypeId.TabIndex = 3
        Me.cmbDisIdentityTypeId.uclDisplayIndex = "0,1"
        Me.cmbDisIdentityTypeId.uclIsAutoClear = True
        Me.cmbDisIdentityTypeId.uclIsFirstItemEmpty = True
        Me.cmbDisIdentityTypeId.uclIsTextMode = False
        Me.cmbDisIdentityTypeId.uclShowMsg = False
        Me.cmbDisIdentityTypeId.uclValueIndex = "0"
        Me.cmbDisIdentityTypeId.Visible = False
        '
        'chkDc
        '
        Me.chkDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDc.AutoSize = True
        Me.chkDc.Location = New System.Drawing.Point(247, 63)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 20)
        Me.chkDc.TabIndex = 5
        Me.chkDc.Text = "停用"
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'chkIsOnlineChoice
        '
        Me.chkIsOnlineChoice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkIsOnlineChoice.AutoSize = True
        Me.chkIsOnlineChoice.Location = New System.Drawing.Point(357, 63)
        Me.chkIsOnlineChoice.Name = "chkIsOnlineChoice"
        Me.chkIsOnlineChoice.Size = New System.Drawing.Size(219, 20)
        Me.chkIsOnlineChoice.TabIndex = 4
        Me.chkIsOnlineChoice.Text = "是否開放線上選擇優免類別"
        Me.chkIsOnlineChoice.UseVisualStyleBackColor = True
        Me.chkIsOnlineChoice.Visible = False
        '
        'PUBDisIdentityUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Name = "PUBDisIdentityUI"
        Me.Text = "優待身份基本檔"
        Me.Controls.SetChildIndex(Me.pal_Mantain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.pal_Mantain.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pal_Mantain As System.Windows.Forms.Panel
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDisIdentityCode As System.Windows.Forms.Label
    Friend WithEvents txtDisIdentityCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDisIdentityName As System.Windows.Forms.Label
    Friend WithEvents txtDisIdentityName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDisIdentityTypeId As System.Windows.Forms.Label
    Friend WithEvents chkIsOnlineChoice As System.Windows.Forms.CheckBox
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDisIdentityTypeId As Syscom.Client.UCL.UCLComboBoxUC
End Class
