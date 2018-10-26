<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPostalGovAreaSetupUI
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
        Me.lbl_DistCode = New System.Windows.Forms.Label()
        Me.txt_PostalCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_DistCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 85)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(742, 264)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(740, 227)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(740, 227)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 2
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.19407!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.80593!))
        Me.tlp_Main.Controls.Add(Me.lbl_PostalCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_DistCode, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_PostalCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_DistCode, 1, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(742, 85)
        Me.tlp_Main.TabIndex = 0
        '
        'lbl_PostalCode
        '
        Me.lbl_PostalCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PostalCode.AutoSize = True
        Me.lbl_PostalCode.ForeColor = System.Drawing.Color.Red
        Me.lbl_PostalCode.Location = New System.Drawing.Point(44, 13)
        Me.lbl_PostalCode.Name = "lbl_PostalCode"
        Me.lbl_PostalCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_PostalCode.TabIndex = 0
        Me.lbl_PostalCode.Text = "郵遞區號："
        '
        'lbl_DistCode
        '
        Me.lbl_DistCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DistCode.AutoSize = True
        Me.lbl_DistCode.Location = New System.Drawing.Point(28, 55)
        Me.lbl_DistCode.Name = "lbl_DistCode"
        Me.lbl_DistCode.Size = New System.Drawing.Size(104, 16)
        Me.lbl_DistCode.TabIndex = 1
        Me.lbl_DistCode.Text = "行政區代碼："
        '
        'txt_PostalCode
        '
        Me.txt_PostalCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PostalCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_PostalCode.Location = New System.Drawing.Point(138, 7)
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
        'txt_DistCode
        '
        Me.txt_DistCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DistCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_DistCode.Location = New System.Drawing.Point(138, 50)
        Me.txt_DistCode.MaxLength = 10
        Me.txt_DistCode.Name = "txt_DistCode"
        Me.txt_DistCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_DistCode.SelectionStart = 0
        Me.txt_DistCode.Size = New System.Drawing.Size(129, 27)
        Me.txt_DistCode.TabIndex = 3
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
        'PUBPostalGovAreaSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 349)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPostalGovAreaSetupUI"
        Me.Text = "PUBPostalGovAreaSetupUI"
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
    Friend WithEvents lbl_DistCode As System.Windows.Forms.Label
    Friend WithEvents txt_PostalCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_DistCode As Syscom.Client.UCL.UCLTextBoxUC
End Class
