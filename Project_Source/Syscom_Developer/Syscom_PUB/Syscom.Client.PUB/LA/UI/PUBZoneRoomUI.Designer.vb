<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBZoneRoomUI
    'Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBZoneRoomUI))
        Me.palMaintain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtTelExtNo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cmbZoneId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblAccountId = New System.Windows.Forms.Label()
        Me.lblReceiptAccountId = New System.Windows.Forms.Label()
        Me.lblInsuAccountId = New System.Windows.Forms.Label()
        Me.lblAcc1AccountId = New System.Windows.Forms.Label()
        Me.lblAcc2AccountId = New System.Windows.Forms.Label()
        Me.txtRoomCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtRoomName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtRoomEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ckbDc = New System.Windows.Forms.CheckBox()
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.txtFloor = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.palMaintain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 92)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(931, 246)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(929, 209)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(929, 209)
        '
        'palMaintain
        '
        Me.palMaintain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palMaintain.Controls.Add(Me.TableLayoutPanel1)
        Me.palMaintain.Dock = System.Windows.Forms.DockStyle.Top
        Me.palMaintain.Location = New System.Drawing.Point(0, 0)
        Me.palMaintain.Name = "palMaintain"
        Me.palMaintain.Size = New System.Drawing.Size(931, 92)
        Me.palMaintain.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTelExtNo, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbZoneId, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAccountId, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblReceiptAccountId, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInsuAccountId, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcc1AccountId, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcc2AccountId, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRoomCode, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRoomName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRoomEnName, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbDc, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFloor, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFloor, 5, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(929, 89)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtTelExtNo
        '
        Me.txtTelExtNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTelExtNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtTelExtNo.Location = New System.Drawing.Point(553, 8)
        Me.txtTelExtNo.MaxLength = 4
        Me.txtTelExtNo.Name = "txtTelExtNo"
        Me.txtTelExtNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTelExtNo.SelectionStart = 0
        Me.txtTelExtNo.Size = New System.Drawing.Size(121, 27)
        Me.txtTelExtNo.TabIndex = 2
        Me.txtTelExtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTelExtNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtTelExtNo.ToolTipTag = Nothing
        Me.txtTelExtNo.uclDollarSign = False
        Me.txtTelExtNo.uclDotCount = 0
        Me.txtTelExtNo.uclIntCount = 4
        Me.txtTelExtNo.uclMinus = False
        Me.txtTelExtNo.uclReadOnly = False
        Me.txtTelExtNo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtTelExtNo.uclTrimZero = True
        '
        'cmbZoneId
        '
        Me.cmbZoneId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbZoneId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbZoneId.DropDownWidth = 20
        Me.cmbZoneId.DroppedDown = False
        Me.cmbZoneId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbZoneId.Location = New System.Drawing.Point(90, 10)
        Me.cmbZoneId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbZoneId.Name = "cmbZoneId"
        Me.cmbZoneId.SelectedIndex = -1
        Me.cmbZoneId.SelectedItem = Nothing
        Me.cmbZoneId.SelectedText = ""
        Me.cmbZoneId.SelectedValue = ""
        Me.cmbZoneId.SelectionStart = 0
        Me.cmbZoneId.Size = New System.Drawing.Size(133, 24)
        Me.cmbZoneId.TabIndex = 0
        Me.cmbZoneId.uclDisplayIndex = "0,1"
        Me.cmbZoneId.uclIsAutoClear = True
        Me.cmbZoneId.uclIsFirstItemEmpty = True
        Me.cmbZoneId.uclIsTextMode = False
        Me.cmbZoneId.uclShowMsg = False
        Me.cmbZoneId.uclValueIndex = "0"
        '
        'lblAccountId
        '
        Me.lblAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAccountId.AutoSize = True
        Me.lblAccountId.ForeColor = System.Drawing.Color.Red
        Me.lblAccountId.Location = New System.Drawing.Point(3, 14)
        Me.lblAccountId.Name = "lblAccountId"
        Me.lblAccountId.Size = New System.Drawing.Size(80, 16)
        Me.lblAccountId.TabIndex = 1
        Me.lblAccountId.Text = "*診區代碼"
        '
        'lblReceiptAccountId
        '
        Me.lblReceiptAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblReceiptAccountId.AutoSize = True
        Me.lblReceiptAccountId.ForeColor = System.Drawing.Color.Red
        Me.lblReceiptAccountId.Location = New System.Drawing.Point(270, 14)
        Me.lblReceiptAccountId.Name = "lblReceiptAccountId"
        Me.lblReceiptAccountId.Size = New System.Drawing.Size(64, 16)
        Me.lblReceiptAccountId.TabIndex = 2
        Me.lblReceiptAccountId.Text = "*診間號"
        '
        'lblInsuAccountId
        '
        Me.lblInsuAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblInsuAccountId.AutoSize = True
        Me.lblInsuAccountId.Location = New System.Drawing.Point(475, 14)
        Me.lblInsuAccountId.Name = "lblInsuAccountId"
        Me.lblInsuAccountId.Size = New System.Drawing.Size(72, 16)
        Me.lblInsuAccountId.TabIndex = 4
        Me.lblInsuAccountId.Text = "分機號碼"
        '
        'lblAcc1AccountId
        '
        Me.lblAcc1AccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAcc1AccountId.AutoSize = True
        Me.lblAcc1AccountId.Location = New System.Drawing.Point(11, 58)
        Me.lblAcc1AccountId.Name = "lblAcc1AccountId"
        Me.lblAcc1AccountId.Size = New System.Drawing.Size(72, 16)
        Me.lblAcc1AccountId.TabIndex = 5
        Me.lblAcc1AccountId.Text = "診間名稱"
        '
        'lblAcc2AccountId
        '
        Me.lblAcc2AccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAcc2AccountId.AutoSize = True
        Me.lblAcc2AccountId.Location = New System.Drawing.Point(230, 58)
        Me.lblAcc2AccountId.Name = "lblAcc2AccountId"
        Me.lblAcc2AccountId.Size = New System.Drawing.Size(104, 16)
        Me.lblAcc2AccountId.TabIndex = 8
        Me.lblAcc2AccountId.Text = "診間英文名稱"
        '
        'txtRoomCode
        '
        Me.txtRoomCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRoomCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtRoomCode.Location = New System.Drawing.Point(340, 8)
        Me.txtRoomCode.MaxLength = 5
        Me.txtRoomCode.Name = "txtRoomCode"
        Me.txtRoomCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRoomCode.SelectionStart = 0
        Me.txtRoomCode.Size = New System.Drawing.Size(129, 27)
        Me.txtRoomCode.TabIndex = 1
        Me.txtRoomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtRoomCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtRoomCode.ToolTipTag = Nothing
        Me.txtRoomCode.uclDollarSign = False
        Me.txtRoomCode.uclDotCount = 0
        Me.txtRoomCode.uclIntCount = 5
        Me.txtRoomCode.uclMinus = True
        Me.txtRoomCode.uclReadOnly = False
        Me.txtRoomCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtRoomCode.uclTrimZero = True
        '
        'txtRoomName
        '
        Me.txtRoomName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRoomName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtRoomName.Location = New System.Drawing.Point(89, 53)
        Me.txtRoomName.MaxLength = 100
        Me.txtRoomName.Name = "txtRoomName"
        Me.txtRoomName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRoomName.SelectionStart = 0
        Me.txtRoomName.Size = New System.Drawing.Size(135, 27)
        Me.txtRoomName.TabIndex = 3
        Me.txtRoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtRoomName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtRoomName.ToolTipTag = Nothing
        Me.txtRoomName.uclDollarSign = False
        Me.txtRoomName.uclDotCount = 0
        Me.txtRoomName.uclIntCount = 2
        Me.txtRoomName.uclMinus = False
        Me.txtRoomName.uclReadOnly = False
        Me.txtRoomName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtRoomName.uclTrimZero = True
        '
        'txtRoomEnName
        '
        Me.txtRoomEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRoomEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtRoomEnName.Location = New System.Drawing.Point(340, 53)
        Me.txtRoomEnName.MaxLength = 100
        Me.txtRoomEnName.Name = "txtRoomEnName"
        Me.txtRoomEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRoomEnName.SelectionStart = 0
        Me.txtRoomEnName.Size = New System.Drawing.Size(129, 27)
        Me.txtRoomEnName.TabIndex = 4
        Me.txtRoomEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtRoomEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtRoomEnName.ToolTipTag = Nothing
        Me.txtRoomEnName.uclDollarSign = False
        Me.txtRoomEnName.uclDotCount = 0
        Me.txtRoomEnName.uclIntCount = 2
        Me.txtRoomEnName.uclMinus = False
        Me.txtRoomEnName.uclReadOnly = False
        Me.txtRoomEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtRoomEnName.uclTrimZero = True
        '
        'ckbDc
        '
        Me.ckbDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDc.AutoSize = True
        Me.ckbDc.Location = New System.Drawing.Point(680, 56)
        Me.ckbDc.Name = "ckbDc"
        Me.ckbDc.Size = New System.Drawing.Size(59, 20)
        Me.ckbDc.TabIndex = 5
        Me.ckbDc.Text = "停用"
        Me.ckbDc.UseVisualStyleBackColor = True
        '
        'lblFloor
        '
        Me.lblFloor.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblFloor.AutoSize = True
        Me.lblFloor.Location = New System.Drawing.Point(507, 58)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Size = New System.Drawing.Size(40, 16)
        Me.lblFloor.TabIndex = 9
        Me.lblFloor.Text = "樓層"
        '
        'txtFloor
        '
        Me.txtFloor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFloor.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtFloor.Location = New System.Drawing.Point(553, 53)
        Me.txtFloor.MaxLength = 10
        Me.txtFloor.Name = "txtFloor"
        Me.txtFloor.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFloor.SelectionStart = 0
        Me.txtFloor.Size = New System.Drawing.Size(121, 27)
        Me.txtFloor.TabIndex = 10
        Me.txtFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFloor.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtFloor.ToolTipTag = Nothing
        Me.txtFloor.uclDollarSign = False
        Me.txtFloor.uclDotCount = 0
        Me.txtFloor.uclIntCount = 10
        Me.txtFloor.uclMinus = False
        Me.txtFloor.uclReadOnly = False
        Me.txtFloor.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtFloor.uclTrimZero = True
        '
        'PUBZoneRoomUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 338)
        Me.Controls.Add(Me.palMaintain)
        Me.Name = "PUBZoneRoomUI"
        Me.Text = "PUBAccountUI"
        Me.Controls.SetChildIndex(Me.palMaintain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.palMaintain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents palMaintain As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbZoneId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblAccountId As System.Windows.Forms.Label
    Friend WithEvents lblReceiptAccountId As System.Windows.Forms.Label
    Friend WithEvents lblInsuAccountId As System.Windows.Forms.Label
    Friend WithEvents lblAcc1AccountId As System.Windows.Forms.Label
    Friend WithEvents lblAcc2AccountId As System.Windows.Forms.Label
    Friend WithEvents ckbDc As System.Windows.Forms.CheckBox
    Friend WithEvents txtTelExtNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtRoomCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtRoomName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtRoomEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblFloor As System.Windows.Forms.Label
    Friend WithEvents txtFloor As Syscom.Client.UCL.UCLTextBoxUC
End Class

