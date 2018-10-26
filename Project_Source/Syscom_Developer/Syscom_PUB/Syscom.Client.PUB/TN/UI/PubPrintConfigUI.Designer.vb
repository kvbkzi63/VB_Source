<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPrintConfigUI
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
        Me.lbl_ReportId = New System.Windows.Forms.Label()
        Me.txt_ReportId = New System.Windows.Forms.TextBox()
        Me.lbl_PrintCond = New System.Windows.Forms.Label()
        Me.txt_PrintCond = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbt_PrintType2 = New System.Windows.Forms.RadioButton()
        Me.rbt_PrintType1 = New System.Windows.Forms.RadioButton()
        Me.lbl_PrintType = New System.Windows.Forms.Label()
        Me.lbl_PrintName = New System.Windows.Forms.Label()
        Me.txt_PrintName = New System.Windows.Forms.TextBox()
        Me.lbl_ReportName = New System.Windows.Forms.Label()
        Me.lbl_PaperSize = New System.Windows.Forms.Label()
        Me.txt_PaperSize = New System.Windows.Forms.TextBox()
        Me.txt_ReportName = New System.Windows.Forms.TextBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 96)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 545)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 508)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 508)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 6
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.lbl_ReportId, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_ReportId, 1, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_PrintCond, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_PrintCond, 1, 1)
        Me.tlp_Main.Controls.Add(Me.Panel1, 3, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_PrintType, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_PrintName, 2, 1)
        Me.tlp_Main.Controls.Add(Me.txt_PrintName, 3, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_ReportName, 4, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_PaperSize, 4, 1)
        Me.tlp_Main.Controls.Add(Me.txt_PaperSize, 5, 1)
        Me.tlp_Main.Controls.Add(Me.txt_ReportName, 5, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 96)
        Me.tlp_Main.TabIndex = 0
        '
        'lbl_ReportId
        '
        Me.lbl_ReportId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_ReportId.AutoSize = True
        Me.lbl_ReportId.ForeColor = System.Drawing.Color.Red
        Me.lbl_ReportId.Location = New System.Drawing.Point(3, 16)
        Me.lbl_ReportId.Name = "lbl_ReportId"
        Me.lbl_ReportId.Size = New System.Drawing.Size(80, 16)
        Me.lbl_ReportId.TabIndex = 0
        Me.lbl_ReportId.Text = "*報表代碼"
        '
        'txt_ReportId
        '
        Me.txt_ReportId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportId.Location = New System.Drawing.Point(89, 10)
        Me.txt_ReportId.Name = "txt_ReportId"
        Me.txt_ReportId.Size = New System.Drawing.Size(146, 27)
        Me.txt_ReportId.TabIndex = 1
        '
        'lbl_PrintCond
        '
        Me.lbl_PrintCond.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PrintCond.AutoSize = True
        Me.lbl_PrintCond.ForeColor = System.Drawing.Color.Red
        Me.lbl_PrintCond.Location = New System.Drawing.Point(3, 64)
        Me.lbl_PrintCond.Name = "lbl_PrintCond"
        Me.lbl_PrintCond.Size = New System.Drawing.Size(80, 16)
        Me.lbl_PrintCond.TabIndex = 6
        Me.lbl_PrintCond.Text = "*列印條件"
        '
        'txt_PrintCond
        '
        Me.txt_PrintCond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PrintCond.Location = New System.Drawing.Point(89, 58)
        Me.txt_PrintCond.Name = "txt_PrintCond"
        Me.txt_PrintCond.Size = New System.Drawing.Size(119, 27)
        Me.txt_PrintCond.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbt_PrintType2)
        Me.Panel1.Controls.Add(Me.rbt_PrintType1)
        Me.Panel1.Location = New System.Drawing.Point(335, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(165, 42)
        Me.Panel1.TabIndex = 2
        '
        'rbt_PrintType2
        '
        Me.rbt_PrintType2.AutoSize = True
        Me.rbt_PrintType2.Location = New System.Drawing.Point(80, 11)
        Me.rbt_PrintType2.Name = "rbt_PrintType2"
        Me.rbt_PrintType2.Size = New System.Drawing.Size(58, 20)
        Me.rbt_PrintType2.TabIndex = 3
        Me.rbt_PrintType2.TabStop = True
        Me.rbt_PrintType2.Text = "遠端"
        Me.rbt_PrintType2.UseVisualStyleBackColor = True
        '
        'rbt_PrintType1
        '
        Me.rbt_PrintType1.AutoSize = True
        Me.rbt_PrintType1.Location = New System.Drawing.Point(12, 11)
        Me.rbt_PrintType1.Name = "rbt_PrintType1"
        Me.rbt_PrintType1.Size = New System.Drawing.Size(58, 20)
        Me.rbt_PrintType1.TabIndex = 2
        Me.rbt_PrintType1.TabStop = True
        Me.rbt_PrintType1.Text = "本機"
        Me.rbt_PrintType1.UseVisualStyleBackColor = True
        '
        'lbl_PrintType
        '
        Me.lbl_PrintType.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PrintType.AutoSize = True
        Me.lbl_PrintType.ForeColor = System.Drawing.Color.Red
        Me.lbl_PrintType.Location = New System.Drawing.Point(249, 16)
        Me.lbl_PrintType.Name = "lbl_PrintType"
        Me.lbl_PrintType.Size = New System.Drawing.Size(80, 16)
        Me.lbl_PrintType.TabIndex = 4
        Me.lbl_PrintType.Text = "*報表類型"
        '
        'lbl_PrintName
        '
        Me.lbl_PrintName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PrintName.AutoSize = True
        Me.lbl_PrintName.Location = New System.Drawing.Point(241, 64)
        Me.lbl_PrintName.Name = "lbl_PrintName"
        Me.lbl_PrintName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_PrintName.TabIndex = 2
        Me.lbl_PrintName.Text = "印表機名稱"
        '
        'txt_PrintName
        '
        Me.txt_PrintName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PrintName.Location = New System.Drawing.Point(335, 58)
        Me.txt_PrintName.Name = "txt_PrintName"
        Me.txt_PrintName.Size = New System.Drawing.Size(195, 27)
        Me.txt_PrintName.TabIndex = 5
        '
        'lbl_ReportName
        '
        Me.lbl_ReportName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_ReportName.AutoSize = True
        Me.lbl_ReportName.Location = New System.Drawing.Point(536, 16)
        Me.lbl_ReportName.Name = "lbl_ReportName"
        Me.lbl_ReportName.Size = New System.Drawing.Size(72, 16)
        Me.lbl_ReportName.TabIndex = 9
        Me.lbl_ReportName.Text = "報表抬頭"
        '
        'lbl_PaperSize
        '
        Me.lbl_PaperSize.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_PaperSize.AutoSize = True
        Me.lbl_PaperSize.Location = New System.Drawing.Point(568, 64)
        Me.lbl_PaperSize.Name = "lbl_PaperSize"
        Me.lbl_PaperSize.Size = New System.Drawing.Size(40, 16)
        Me.lbl_PaperSize.TabIndex = 8
        Me.lbl_PaperSize.Text = "備註"
        '
        'txt_PaperSize
        '
        Me.txt_PaperSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PaperSize.Location = New System.Drawing.Point(614, 58)
        Me.txt_PaperSize.Name = "txt_PaperSize"
        Me.txt_PaperSize.Size = New System.Drawing.Size(338, 27)
        Me.txt_PaperSize.TabIndex = 6
        '
        'txt_ReportName
        '
        Me.txt_ReportName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportName.Location = New System.Drawing.Point(614, 10)
        Me.txt_ReportName.Name = "txt_ReportName"
        Me.txt_ReportName.Size = New System.Drawing.Size(338, 27)
        Me.txt_ReportName.TabIndex = 3
        '
        'PubPrintConfigUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Name = "PubPrintConfigUI"
        Me.Text = "報表維護資料"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_ReportId As System.Windows.Forms.Label
    Friend WithEvents txt_ReportId As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PrintName As System.Windows.Forms.Label
    Friend WithEvents txt_PrintName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PrintType As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbt_PrintType2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_PrintType1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_PrintCond As System.Windows.Forms.Label
    Friend WithEvents txt_PrintCond As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PaperSize As System.Windows.Forms.Label
    Friend WithEvents txt_PaperSize As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ReportName As System.Windows.Forms.Label
    Friend WithEvents txt_ReportName As System.Windows.Forms.TextBox
End Class
