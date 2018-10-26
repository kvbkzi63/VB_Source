<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubReportDescUI
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ReportName = New System.Windows.Forms.TextBox()
        Me.txt_ReportID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_SystemCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_ReportDesc = New System.Windows.Forms.RichTextBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 162)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 479)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 442)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 442)
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
        Me.tlp_Main.Controls.Add(Me.txt_ReportName, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_ReportID, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label3, 4, 0)
        Me.tlp_Main.Controls.Add(Me.txt_SystemCode, 5, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_ReportDesc, 1, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.30864!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.69136!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 162)
        Me.tlp_Main.TabIndex = 0
        '
        'txt_ReportName
        '
        Me.txt_ReportName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportName.Location = New System.Drawing.Point(321, 6)
        Me.txt_ReportName.Name = "txt_ReportName"
        Me.txt_ReportName.Size = New System.Drawing.Size(156, 27)
        Me.txt_ReportName.TabIndex = 13
        '
        'txt_ReportID
        '
        Me.txt_ReportID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportID.Location = New System.Drawing.Point(81, 6)
        Me.txt_ReportID.Name = "txt_ReportID"
        Me.txt_ReportID.Size = New System.Drawing.Size(156, 27)
        Me.txt_ReportID.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "報表名稱"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "報表代碼"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(483, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "系統別"
        '
        'txt_SystemCode
        '
        Me.txt_SystemCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SystemCode.Location = New System.Drawing.Point(545, 6)
        Me.txt_SystemCode.Name = "txt_SystemCode"
        Me.txt_SystemCode.Size = New System.Drawing.Size(156, 27)
        Me.txt_SystemCode.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "備註描述"
        '
        'txt_ReportDesc
        '
        Me.tlp_Main.SetColumnSpan(Me.txt_ReportDesc, 5)
        Me.txt_ReportDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_ReportDesc.Location = New System.Drawing.Point(81, 43)
        Me.txt_ReportDesc.Name = "txt_ReportDesc"
        Me.txt_ReportDesc.Size = New System.Drawing.Size(880, 116)
        Me.txt_ReportDesc.TabIndex = 15
        Me.txt_ReportDesc.Text = ""
        '
        'PubReportDescUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PubReportDescUI"
        Me.Text = "單張報表描述檔維護作業"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_ReportName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ReportID As System.Windows.Forms.TextBox
    Friend WithEvents txt_SystemCode As System.Windows.Forms.TextBox
    Friend WithEvents txt_ReportDesc As System.Windows.Forms.RichTextBox
End Class
