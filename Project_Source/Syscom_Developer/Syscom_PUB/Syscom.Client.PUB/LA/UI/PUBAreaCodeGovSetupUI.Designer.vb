<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAreaCodeGovSetupUI
    'Inherits System.Windows.Forms.Form
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
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_DistCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_VillName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_GovCountyName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_VillCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_GovCountyCode = New System.Windows.Forms.Label()
        Me.lbl_GovCountyName = New System.Windows.Forms.Label()
        Me.lbl_DistCode = New System.Windows.Forms.Label()
        Me.lbl_DistName = New System.Windows.Forms.Label()
        Me.lbl_VillCode = New System.Windows.Forms.Label()
        Me.lbl_VillName = New System.Windows.Forms.Label()
        Me.txt_GovCountyCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_DistName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 123)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(695, 325)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(693, 288)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(693, 288)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04336!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.95664!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 306.0!))
        Me.tlp_Main.Controls.Add(Me.txt_DistCode, 1, 2)
        Me.tlp_Main.Controls.Add(Me.txt_VillName, 3, 1)
        Me.tlp_Main.Controls.Add(Me.txt_GovCountyName, 1, 1)
        Me.tlp_Main.Controls.Add(Me.txt_VillCode, 3, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_GovCountyCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_GovCountyName, 0, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_DistCode, 0, 2)
        Me.tlp_Main.Controls.Add(Me.lbl_DistName, 0, 3)
        Me.tlp_Main.Controls.Add(Me.lbl_VillCode, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_VillName, 2, 1)
        Me.tlp_Main.Controls.Add(Me.txt_GovCountyCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_DistName, 1, 3)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 4
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(695, 123)
        Me.tlp_Main.TabIndex = 0
        '
        'txt_DistCode
        '
        Me.txt_DistCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DistCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_DistCode.Location = New System.Drawing.Point(108, 65)
        Me.txt_DistCode.MaxLength = 10
        Me.txt_DistCode.Name = "txt_DistCode"
        Me.txt_DistCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_DistCode.SelectionStart = 0
        Me.txt_DistCode.Size = New System.Drawing.Size(129, 24)
        Me.txt_DistCode.TabIndex = 10
        Me.txt_DistCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_DistCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_DistCode.ToolTipTag = Nothing
        Me.txt_DistCode.uclDollarSign = False
        Me.txt_DistCode.uclDotCount = 0
        Me.txt_DistCode.uclIntCount = 2
        Me.txt_DistCode.uclMinus = False
        Me.txt_DistCode.uclReadOnly = False
        Me.txt_DistCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_DistCode.uclTrimZero = True
        '
        'txt_VillName
        '
        Me.txt_VillName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_VillName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_VillName.Location = New System.Drawing.Point(391, 34)
        Me.txt_VillName.MaxLength = 10
        Me.txt_VillName.Name = "txt_VillName"
        Me.txt_VillName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_VillName.SelectionStart = 0
        Me.txt_VillName.Size = New System.Drawing.Size(129, 25)
        Me.txt_VillName.TabIndex = 9
        Me.txt_VillName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_VillName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_VillName.ToolTipTag = Nothing
        Me.txt_VillName.uclDollarSign = False
        Me.txt_VillName.uclDotCount = 0
        Me.txt_VillName.uclIntCount = 2
        Me.txt_VillName.uclMinus = False
        Me.txt_VillName.uclReadOnly = False
        Me.txt_VillName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_VillName.uclTrimZero = True
        '
        'txt_GovCountyName
        '
        Me.txt_GovCountyName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_GovCountyName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_GovCountyName.Location = New System.Drawing.Point(108, 34)
        Me.txt_GovCountyName.MaxLength = 10
        Me.txt_GovCountyName.Name = "txt_GovCountyName"
        Me.txt_GovCountyName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_GovCountyName.SelectionStart = 0
        Me.txt_GovCountyName.Size = New System.Drawing.Size(129, 25)
        Me.txt_GovCountyName.TabIndex = 8
        Me.txt_GovCountyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_GovCountyName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_GovCountyName.ToolTipTag = Nothing
        Me.txt_GovCountyName.uclDollarSign = False
        Me.txt_GovCountyName.uclDotCount = 0
        Me.txt_GovCountyName.uclIntCount = 2
        Me.txt_GovCountyName.uclMinus = False
        Me.txt_GovCountyName.uclReadOnly = False
        Me.txt_GovCountyName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_GovCountyName.uclTrimZero = True
        '
        'txt_VillCode
        '
        Me.txt_VillCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_VillCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_VillCode.Location = New System.Drawing.Point(391, 3)
        Me.txt_VillCode.MaxLength = 15
        Me.txt_VillCode.Name = "txt_VillCode"
        Me.txt_VillCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_VillCode.SelectionStart = 0
        Me.txt_VillCode.Size = New System.Drawing.Size(129, 25)
        Me.txt_VillCode.TabIndex = 7
        Me.txt_VillCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_VillCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_VillCode.ToolTipTag = Nothing
        Me.txt_VillCode.uclDollarSign = False
        Me.txt_VillCode.uclDotCount = 0
        Me.txt_VillCode.uclIntCount = 2
        Me.txt_VillCode.uclMinus = False
        Me.txt_VillCode.uclReadOnly = False
        Me.txt_VillCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_VillCode.uclTrimZero = True
        '
        'lbl_GovCountyCode
        '
        Me.lbl_GovCountyCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_GovCountyCode.AutoSize = True
        Me.lbl_GovCountyCode.ForeColor = System.Drawing.Color.Red
        Me.lbl_GovCountyCode.Location = New System.Drawing.Point(14, 7)
        Me.lbl_GovCountyCode.Name = "lbl_GovCountyCode"
        Me.lbl_GovCountyCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_GovCountyCode.TabIndex = 0
        Me.lbl_GovCountyCode.Text = "縣市代碼："
        '
        'lbl_GovCountyName
        '
        Me.lbl_GovCountyName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_GovCountyName.AutoSize = True
        Me.lbl_GovCountyName.Location = New System.Drawing.Point(14, 38)
        Me.lbl_GovCountyName.Name = "lbl_GovCountyName"
        Me.lbl_GovCountyName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_GovCountyName.TabIndex = 1
        Me.lbl_GovCountyName.Text = "縣市名稱："
        '
        'lbl_DistCode
        '
        Me.lbl_DistCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DistCode.AutoSize = True
        Me.lbl_DistCode.Location = New System.Drawing.Point(14, 69)
        Me.lbl_DistCode.Name = "lbl_DistCode"
        Me.lbl_DistCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_DistCode.TabIndex = 2
        Me.lbl_DistCode.Text = "區裡代碼："
        '
        'lbl_DistName
        '
        Me.lbl_DistName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DistName.AutoSize = True
        Me.lbl_DistName.Location = New System.Drawing.Point(14, 99)
        Me.lbl_DistName.Name = "lbl_DistName"
        Me.lbl_DistName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_DistName.TabIndex = 3
        Me.lbl_DistName.Text = "區裡名稱："
        '
        'lbl_VillCode
        '
        Me.lbl_VillCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_VillCode.AutoSize = True
        Me.lbl_VillCode.Location = New System.Drawing.Point(297, 7)
        Me.lbl_VillCode.Name = "lbl_VillCode"
        Me.lbl_VillCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_VillCode.TabIndex = 4
        Me.lbl_VillCode.Text = "村裡代碼："
        '
        'lbl_VillName
        '
        Me.lbl_VillName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_VillName.AutoSize = True
        Me.lbl_VillName.Location = New System.Drawing.Point(297, 38)
        Me.lbl_VillName.Name = "lbl_VillName"
        Me.lbl_VillName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_VillName.TabIndex = 5
        Me.lbl_VillName.Text = "村裡名稱："
        '
        'txt_GovCountyCode
        '
        Me.txt_GovCountyCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_GovCountyCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_GovCountyCode.Location = New System.Drawing.Point(108, 3)
        Me.txt_GovCountyCode.MaxLength = 10
        Me.txt_GovCountyCode.Name = "txt_GovCountyCode"
        Me.txt_GovCountyCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_GovCountyCode.SelectionStart = 0
        Me.txt_GovCountyCode.Size = New System.Drawing.Size(129, 25)
        Me.txt_GovCountyCode.TabIndex = 6
        Me.txt_GovCountyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_GovCountyCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_GovCountyCode.ToolTipTag = Nothing
        Me.txt_GovCountyCode.uclDollarSign = False
        Me.txt_GovCountyCode.uclDotCount = 0
        Me.txt_GovCountyCode.uclIntCount = 2
        Me.txt_GovCountyCode.uclMinus = False
        Me.txt_GovCountyCode.uclReadOnly = False
        Me.txt_GovCountyCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_GovCountyCode.uclTrimZero = True
        '
        'txt_DistName
        '
        Me.txt_DistName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DistName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_DistName.Location = New System.Drawing.Point(108, 95)
        Me.txt_DistName.MaxLength = 10
        Me.txt_DistName.Name = "txt_DistName"
        Me.txt_DistName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_DistName.SelectionStart = 0
        Me.txt_DistName.Size = New System.Drawing.Size(129, 25)
        Me.txt_DistName.TabIndex = 11
        Me.txt_DistName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_DistName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_DistName.ToolTipTag = Nothing
        Me.txt_DistName.uclDollarSign = False
        Me.txt_DistName.uclDotCount = 0
        Me.txt_DistName.uclIntCount = 2
        Me.txt_DistName.uclMinus = False
        Me.txt_DistName.uclReadOnly = False
        Me.txt_DistName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_DistName.uclTrimZero = True
        '
        'PUBAreaCodeGovSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 448)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBAreaCodeGovSetupUI"
        Me.Text = "PubAreaCodeGovSetupUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_DistCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_VillName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_GovCountyName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_VillCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_GovCountyCode As System.Windows.Forms.Label
    Friend WithEvents lbl_GovCountyName As System.Windows.Forms.Label
    Friend WithEvents lbl_DistCode As System.Windows.Forms.Label
    Friend WithEvents lbl_DistName As System.Windows.Forms.Label
    Friend WithEvents lbl_VillCode As System.Windows.Forms.Label
    Friend WithEvents lbl_VillName As System.Windows.Forms.Label
    Friend WithEvents txt_GovCountyCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_DistName As Syscom.Client.UCL.UCLTextBoxUC
End Class
