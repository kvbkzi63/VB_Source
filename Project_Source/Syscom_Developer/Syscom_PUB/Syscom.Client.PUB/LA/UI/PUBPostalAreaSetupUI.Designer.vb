<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPostalAreaSetupUI
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
        Me.lbl_PostalCode = New System.Windows.Forms.Label()
        Me.lbl_AreaCode = New System.Windows.Forms.Label()
        Me.txt_PostalCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_AreaCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 83)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(748, 266)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(746, 229)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(746, 229)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 2
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.7861!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.21391!))
        Me.tlp_Main.Controls.Add(Me.lbl_PostalCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_AreaCode, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_PostalCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_AreaCode, 1, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(748, 83)
        Me.tlp_Main.TabIndex = 0
        '
        'lbl_PostalCode
        '
        Me.lbl_PostalCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PostalCode.AutoSize = True
        Me.lbl_PostalCode.ForeColor = System.Drawing.Color.Red
        Me.lbl_PostalCode.Location = New System.Drawing.Point(57, 12)
        Me.lbl_PostalCode.Name = "lbl_PostalCode"
        Me.lbl_PostalCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_PostalCode.TabIndex = 0
        Me.lbl_PostalCode.Text = "郵遞區號："
        '
        'lbl_AreaCode
        '
        Me.lbl_AreaCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AreaCode.AutoSize = True
        Me.lbl_AreaCode.Location = New System.Drawing.Point(41, 54)
        Me.lbl_AreaCode.Name = "lbl_AreaCode"
        Me.lbl_AreaCode.Size = New System.Drawing.Size(104, 16)
        Me.lbl_AreaCode.TabIndex = 1
        Me.lbl_AreaCode.Text = "戶籍地代碼："
        '
        'txt_PostalCode
        '
        Me.txt_PostalCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PostalCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_PostalCode.Location = New System.Drawing.Point(151, 7)
        Me.txt_PostalCode.MaxLength = 10
        Me.txt_PostalCode.Name = "txt_PostalCode"
        Me.txt_PostalCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_PostalCode.SelectionStart = 0
        Me.txt_PostalCode.Size = New System.Drawing.Size(129, 27)
        Me.txt_PostalCode.TabIndex = 2
        Me.txt_PostalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_PostalCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_PostalCode.ToolTipTag = Nothing
        Me.txt_PostalCode.uclDollarSign = False
        Me.txt_PostalCode.uclDotCount = 0
        Me.txt_PostalCode.uclIntCount = 2
        Me.txt_PostalCode.uclMinus = False
        Me.txt_PostalCode.uclReadOnly = False
        Me.txt_PostalCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_PostalCode.uclTrimZero = True
        '
        'txt_AreaCode
        '
        Me.txt_AreaCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AreaCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_AreaCode.Location = New System.Drawing.Point(151, 48)
        Me.txt_AreaCode.MaxLength = 10
        Me.txt_AreaCode.Name = "txt_AreaCode"
        Me.txt_AreaCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_AreaCode.SelectionStart = 0
        Me.txt_AreaCode.Size = New System.Drawing.Size(129, 27)
        Me.txt_AreaCode.TabIndex = 3
        Me.txt_AreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_AreaCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_AreaCode.ToolTipTag = Nothing
        Me.txt_AreaCode.uclDollarSign = False
        Me.txt_AreaCode.uclDotCount = 0
        Me.txt_AreaCode.uclIntCount = 2
        Me.txt_AreaCode.uclMinus = False
        Me.txt_AreaCode.uclReadOnly = False
        Me.txt_AreaCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_AreaCode.uclTrimZero = True
        '
        'PUBPostalAreaSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 349)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPostalAreaSetupUI"
        Me.Text = "PUBPostalAreaSetupUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_PostalCode As System.Windows.Forms.Label
    Friend WithEvents lbl_AreaCode As System.Windows.Forms.Label
    Friend WithEvents txt_PostalCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_AreaCode As Syscom.Client.UCL.UCLTextBoxUC
End Class
