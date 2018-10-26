<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBBodySiteUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBBodySiteUI))
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbMainBodySiteCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.chkDc = New System.Windows.Forms.CheckBox()
        Me.lblPharmacistDutyName = New System.Windows.Forms.Label()
        Me.lblDutyMemo = New System.Windows.Forms.Label()
        Me.txtBodySiteCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtBodySiteName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblPharmacistGroupName = New System.Windows.Forms.Label()
        Me.cmbNhiBodySiteCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblPharmacistDutyId = New System.Windows.Forms.Label()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 112)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 368)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(983, 331)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(983, 331)
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_nonButton)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(985, 112)
        Me.pal_Mantain.TabIndex = 6
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 6
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.cmbMainBodySiteCode, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.chkDc, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblPharmacistDutyName, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDutyMemo, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtBodySiteCode, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtBodySiteName, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblPharmacistGroupName, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.cmbNhiBodySiteCode, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblPharmacistDutyId, 0, 0)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(983, 106)
        Me.tlp_nonButton.TabIndex = 0
        '
        'cmbMainBodySiteCode
        '
        Me.cmbMainBodySiteCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMainBodySiteCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMainBodySiteCode.DropDownWidth = 20
        Me.cmbMainBodySiteCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMainBodySiteCode.Location = New System.Drawing.Point(98, 67)
        Me.cmbMainBodySiteCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMainBodySiteCode.Name = "cmbMainBodySiteCode"
        Me.cmbMainBodySiteCode.SelectedIndex = -1
        Me.cmbMainBodySiteCode.SelectedItem = Nothing
        Me.cmbMainBodySiteCode.SelectedText = ""
        Me.cmbMainBodySiteCode.SelectedValue = ""
        Me.cmbMainBodySiteCode.SelectionStart = 0
        Me.cmbMainBodySiteCode.Size = New System.Drawing.Size(166, 24)
        Me.cmbMainBodySiteCode.TabIndex = 3
        Me.cmbMainBodySiteCode.uclDisplayIndex = "0,1"
        Me.cmbMainBodySiteCode.uclIsAutoClear = True
        Me.cmbMainBodySiteCode.uclIsFirstItemEmpty = True
        Me.cmbMainBodySiteCode.uclIsTextMode = False
        Me.cmbMainBodySiteCode.uclShowMsg = False
        Me.cmbMainBodySiteCode.uclValueIndex = "0"
        '
        'chkDc
        '
        Me.chkDc.AutoSize = True
        Me.chkDc.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkDc.Location = New System.Drawing.Point(742, 56)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 47)
        Me.chkDc.TabIndex = 5
        Me.chkDc.Text = "停用"
        Me.chkDc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDc.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'lblPharmacistDutyName
        '
        Me.lblPharmacistDutyName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPharmacistDutyName.AutoSize = True
        Me.lblPharmacistDutyName.Location = New System.Drawing.Point(335, 18)
        Me.lblPharmacistDutyName.Name = "lblPharmacistDutyName"
        Me.lblPharmacistDutyName.Size = New System.Drawing.Size(72, 16)
        Me.lblPharmacistDutyName.TabIndex = 6
        Me.lblPharmacistDutyName.Text = "部位名稱"
        '
        'lblDutyMemo
        '
        Me.lblDutyMemo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDutyMemo.AutoSize = True
        Me.lblDutyMemo.Location = New System.Drawing.Point(3, 71)
        Me.lblDutyMemo.Name = "lblDutyMemo"
        Me.lblDutyMemo.Size = New System.Drawing.Size(88, 16)
        Me.lblDutyMemo.TabIndex = 8
        Me.lblDutyMemo.Text = "部位大分類"
        '
        'txtBodySiteCode
        '
        Me.txtBodySiteCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtBodySiteCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtBodySiteCode.Location = New System.Drawing.Point(98, 13)
        Me.txtBodySiteCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBodySiteCode.MaxLength = 10
        Me.txtBodySiteCode.Name = "txtBodySiteCode"
        Me.txtBodySiteCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBodySiteCode.SelectionStart = 0
        Me.txtBodySiteCode.Size = New System.Drawing.Size(151, 27)
        Me.txtBodySiteCode.TabIndex = 1
        Me.txtBodySiteCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBodySiteCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtBodySiteCode.uclDollarSign = False
        Me.txtBodySiteCode.uclDotCount = 0
        Me.txtBodySiteCode.uclIntCount = 2
        Me.txtBodySiteCode.uclMinus = False
        Me.txtBodySiteCode.uclReadOnly = False
        Me.txtBodySiteCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtBodySiteCode.uclTrimZero = True
        '
        'txtBodySiteName
        '
        Me.txtBodySiteName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtBodySiteName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtBodySiteName.Location = New System.Drawing.Point(414, 13)
        Me.txtBodySiteName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBodySiteName.MaxLength = 10
        Me.txtBodySiteName.Name = "txtBodySiteName"
        Me.txtBodySiteName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBodySiteName.SelectionStart = 0
        Me.txtBodySiteName.Size = New System.Drawing.Size(286, 27)
        Me.txtBodySiteName.TabIndex = 2
        Me.txtBodySiteName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBodySiteName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtBodySiteName.uclDollarSign = False
        Me.txtBodySiteName.uclDotCount = 0
        Me.txtBodySiteName.uclIntCount = 2
        Me.txtBodySiteName.uclMinus = False
        Me.txtBodySiteName.uclReadOnly = False
        Me.txtBodySiteName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtBodySiteName.uclTrimZero = True
        '
        'lblPharmacistGroupName
        '
        Me.lblPharmacistGroupName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPharmacistGroupName.AutoSize = True
        Me.lblPharmacistGroupName.Location = New System.Drawing.Point(271, 71)
        Me.lblPharmacistGroupName.Name = "lblPharmacistGroupName"
        Me.lblPharmacistGroupName.Size = New System.Drawing.Size(136, 16)
        Me.lblPharmacistGroupName.TabIndex = 7
        Me.lblPharmacistGroupName.Text = "健保申報部位代碼"
        '
        'cmbNhiBodySiteCode
        '
        Me.cmbNhiBodySiteCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbNhiBodySiteCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbNhiBodySiteCode.DropDownWidth = 20
        Me.cmbNhiBodySiteCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbNhiBodySiteCode.Location = New System.Drawing.Point(414, 67)
        Me.cmbNhiBodySiteCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbNhiBodySiteCode.Name = "cmbNhiBodySiteCode"
        Me.cmbNhiBodySiteCode.SelectedIndex = -1
        Me.cmbNhiBodySiteCode.SelectedItem = Nothing
        Me.cmbNhiBodySiteCode.SelectedText = ""
        Me.cmbNhiBodySiteCode.SelectedValue = ""
        Me.cmbNhiBodySiteCode.SelectionStart = 0
        Me.cmbNhiBodySiteCode.Size = New System.Drawing.Size(286, 24)
        Me.cmbNhiBodySiteCode.TabIndex = 4
        Me.cmbNhiBodySiteCode.uclDisplayIndex = "0,1"
        Me.cmbNhiBodySiteCode.uclIsAutoClear = True
        Me.cmbNhiBodySiteCode.uclIsFirstItemEmpty = True
        Me.cmbNhiBodySiteCode.uclIsTextMode = False
        Me.cmbNhiBodySiteCode.uclShowMsg = False
        Me.cmbNhiBodySiteCode.uclValueIndex = "0"
        '
        'lblPharmacistDutyId
        '
        Me.lblPharmacistDutyId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPharmacistDutyId.AutoSize = True
        Me.lblPharmacistDutyId.ForeColor = System.Drawing.Color.Red
        Me.lblPharmacistDutyId.Location = New System.Drawing.Point(11, 18)
        Me.lblPharmacistDutyId.Name = "lblPharmacistDutyId"
        Me.lblPharmacistDutyId.Size = New System.Drawing.Size(80, 16)
        Me.lblPharmacistDutyId.TabIndex = 0
        Me.lblPharmacistDutyId.Text = "*部位代碼"
        '
        'PUBBodySiteUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Name = "PUBBodySiteUI"
        Me.TabText = "部位檔維護"
        Me.Text = "部位檔維護"
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
    Friend WithEvents lblPharmacistDutyId As System.Windows.Forms.Label
    Friend WithEvents lblPharmacistDutyName As System.Windows.Forms.Label
    Friend WithEvents lblPharmacistGroupName As System.Windows.Forms.Label
    Friend WithEvents lblDutyMemo As System.Windows.Forms.Label
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
    Friend WithEvents txtBodySiteCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cmbNhiBodySiteCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtBodySiteName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cmbMainBodySiteCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
