<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBInsuDeptSetupUI
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
        Me.lbl_InsuDeptCodeName = New System.Windows.Forms.Label()
        Me.lbl_InsuDeptCodeEnName = New System.Windows.Forms.Label()
        Me.txt_InsuDeptCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_InsuDeptCodeEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_InsuDeptCodeName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_InsuDeptCode = New System.Windows.Forms.Label()
        Me.ckbDc = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 82)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(773, 267)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(771, 230)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(771, 230)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.66667!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 392.0!))
        Me.tlp_Main.Controls.Add(Me.lbl_InsuDeptCodeName, 0, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_InsuDeptCodeEnName, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_InsuDeptCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_InsuDeptCodeEnName, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_InsuDeptCodeName, 1, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_InsuDeptCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.ckbDc, 2, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.78049!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.21951!))
        Me.tlp_Main.Size = New System.Drawing.Size(773, 82)
        Me.tlp_Main.TabIndex = 0
        '
        'lbl_InsuDeptCodeName
        '
        Me.lbl_InsuDeptCodeName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_InsuDeptCodeName.AutoSize = True
        Me.lbl_InsuDeptCodeName.Location = New System.Drawing.Point(13, 53)
        Me.lbl_InsuDeptCodeName.Name = "lbl_InsuDeptCodeName"
        Me.lbl_InsuDeptCodeName.Size = New System.Drawing.Size(120, 16)
        Me.lbl_InsuDeptCodeName.TabIndex = 14
        Me.lbl_InsuDeptCodeName.Text = "健保科別名稱："
        '
        'lbl_InsuDeptCodeEnName
        '
        Me.lbl_InsuDeptCodeEnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_InsuDeptCodeEnName.AutoSize = True
        Me.lbl_InsuDeptCodeEnName.Location = New System.Drawing.Point(289, 12)
        Me.lbl_InsuDeptCodeEnName.Name = "lbl_InsuDeptCodeEnName"
        Me.lbl_InsuDeptCodeEnName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_InsuDeptCodeEnName.TabIndex = 13
        Me.lbl_InsuDeptCodeEnName.Text = "英文名稱："
        '
        'txt_InsuDeptCode
        '
        Me.txt_InsuDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuDeptCode.Location = New System.Drawing.Point(139, 3)
        Me.txt_InsuDeptCode.MaxLength = 10
        Me.txt_InsuDeptCode.Name = "txt_InsuDeptCode"
        Me.txt_InsuDeptCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuDeptCode.SelectionStart = 0
        Me.txt_InsuDeptCode.Size = New System.Drawing.Size(113, 25)
        Me.txt_InsuDeptCode.TabIndex = 0
        Me.txt_InsuDeptCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuDeptCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuDeptCode.ToolTipTag = Nothing
        Me.txt_InsuDeptCode.uclDollarSign = False
        Me.txt_InsuDeptCode.uclDotCount = 0
        Me.txt_InsuDeptCode.uclIntCount = 2
        Me.txt_InsuDeptCode.uclMinus = False
        Me.txt_InsuDeptCode.uclReadOnly = False
        Me.txt_InsuDeptCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuDeptCode.uclTrimZero = True
        '
        'txt_InsuDeptCodeEnName
        '
        Me.txt_InsuDeptCodeEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuDeptCodeEnName.Location = New System.Drawing.Point(383, 3)
        Me.txt_InsuDeptCodeEnName.MaxLength = 10
        Me.txt_InsuDeptCodeEnName.Name = "txt_InsuDeptCodeEnName"
        Me.txt_InsuDeptCodeEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuDeptCodeEnName.SelectionStart = 0
        Me.txt_InsuDeptCodeEnName.Size = New System.Drawing.Size(129, 27)
        Me.txt_InsuDeptCodeEnName.TabIndex = 1
        Me.txt_InsuDeptCodeEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuDeptCodeEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuDeptCodeEnName.ToolTipTag = Nothing
        Me.txt_InsuDeptCodeEnName.uclDollarSign = False
        Me.txt_InsuDeptCodeEnName.uclDotCount = 0
        Me.txt_InsuDeptCodeEnName.uclIntCount = 2
        Me.txt_InsuDeptCodeEnName.uclMinus = False
        Me.txt_InsuDeptCodeEnName.uclReadOnly = False
        Me.txt_InsuDeptCodeEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuDeptCodeEnName.uclTrimZero = True
        '
        'txt_InsuDeptCodeName
        '
        Me.txt_InsuDeptCodeName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuDeptCodeName.Location = New System.Drawing.Point(139, 43)
        Me.txt_InsuDeptCodeName.MaxLength = 10
        Me.txt_InsuDeptCodeName.Name = "txt_InsuDeptCodeName"
        Me.txt_InsuDeptCodeName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuDeptCodeName.SelectionStart = 0
        Me.txt_InsuDeptCodeName.Size = New System.Drawing.Size(113, 26)
        Me.txt_InsuDeptCodeName.TabIndex = 2
        Me.txt_InsuDeptCodeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuDeptCodeName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuDeptCodeName.ToolTipTag = Nothing
        Me.txt_InsuDeptCodeName.uclDollarSign = False
        Me.txt_InsuDeptCodeName.uclDotCount = 0
        Me.txt_InsuDeptCodeName.uclIntCount = 2
        Me.txt_InsuDeptCodeName.uclMinus = False
        Me.txt_InsuDeptCodeName.uclReadOnly = False
        Me.txt_InsuDeptCodeName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuDeptCodeName.uclTrimZero = True
        '
        'lbl_InsuDeptCode
        '
        Me.lbl_InsuDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_InsuDeptCode.AutoSize = True
        Me.lbl_InsuDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lbl_InsuDeptCode.Location = New System.Drawing.Point(13, 12)
        Me.lbl_InsuDeptCode.Name = "lbl_InsuDeptCode"
        Me.lbl_InsuDeptCode.Size = New System.Drawing.Size(120, 16)
        Me.lbl_InsuDeptCode.TabIndex = 12
        Me.lbl_InsuDeptCode.Text = "健保科別代號："
        '
        'ckbDc
        '
        Me.ckbDc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ckbDc.AutoSize = True
        Me.ckbDc.Location = New System.Drawing.Point(318, 51)
        Me.ckbDc.Name = "ckbDc"
        Me.ckbDc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ckbDc.Size = New System.Drawing.Size(59, 20)
        Me.ckbDc.TabIndex = 11
        Me.ckbDc.Text = "停用"
        Me.ckbDc.UseVisualStyleBackColor = True
        '
        'PUBInsuDeptSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 349)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBInsuDeptSetupUI"
        Me.Text = "PUBInsuDeptSetupUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_InsuDeptCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuDeptCodeEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuDeptCodeName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_InsuDeptCodeName As System.Windows.Forms.Label
    Friend WithEvents lbl_InsuDeptCodeEnName As System.Windows.Forms.Label
    Friend WithEvents lbl_InsuDeptCode As System.Windows.Forms.Label
    Friend WithEvents ckbDc As System.Windows.Forms.CheckBox
End Class
