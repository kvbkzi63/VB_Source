Imports Syscom.Client.UCL

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobPhraseMaintainUI
    Inherits IUCLMaintainFormUI

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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.rtb_Phrase = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_SeqNo = New System.Windows.Forms.TextBox()
        Me.ckb_IsPublic = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 136)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(944, 505)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(942, 468)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(942, 468)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 3
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.rtb_Phrase, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_SeqNo, 2, 0)
        Me.tlp_Main.Controls.Add(Me.ckb_IsPublic, 2, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(944, 136)
        Me.tlp_Main.TabIndex = 0
        '
        'rtb_Phrase
        '
        Me.rtb_Phrase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Phrase.Location = New System.Drawing.Point(81, 3)
        Me.rtb_Phrase.Name = "rtb_Phrase"
        Me.tlp_Main.SetRowSpan(Me.rtb_Phrase, 2)
        Me.rtb_Phrase.Size = New System.Drawing.Size(507, 130)
        Me.rtb_Phrase.TabIndex = 2
        Me.rtb_Phrase.Text = ""
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "片語內容"
        '
        'txt_SeqNo
        '
        Me.txt_SeqNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_SeqNo.Location = New System.Drawing.Point(841, 14)
        Me.txt_SeqNo.Name = "txt_SeqNo"
        Me.txt_SeqNo.Size = New System.Drawing.Size(100, 27)
        Me.txt_SeqNo.TabIndex = 3
        Me.txt_SeqNo.Text = "0"
        Me.txt_SeqNo.Visible = False
        '
        'ckb_IsPublic
        '
        Me.ckb_IsPublic.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_IsPublic.AutoSize = True
        Me.ckb_IsPublic.Location = New System.Drawing.Point(594, 85)
        Me.ckb_IsPublic.Name = "ckb_IsPublic"
        Me.ckb_IsPublic.Size = New System.Drawing.Size(91, 20)
        Me.ckb_IsPublic.TabIndex = 0
        Me.ckb_IsPublic.Text = "共用片語"
        Me.ckb_IsPublic.UseVisualStyleBackColor = True
        '
        'JobPhraseMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.IsActiveAutoSize = False
        Me.Name = "JobPhraseMaintainUI"
        Me.Text = "片語維護作業"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_Main As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ckb_IsPublic As Windows.Forms.CheckBox
    Friend WithEvents rtb_Phrase As Windows.Forms.RichTextBox
    Friend WithEvents txt_SeqNo As Windows.Forms.TextBox
End Class
