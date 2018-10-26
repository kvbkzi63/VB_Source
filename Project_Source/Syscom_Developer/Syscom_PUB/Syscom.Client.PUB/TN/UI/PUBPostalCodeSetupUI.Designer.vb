Imports Syscom.Client.UCL

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPostalCodeSetupUI
    'Inherits System.Windows.Forms.Form
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_Postal_Code = New System.Windows.Forms.Label()
        Me.lbl_County_Name = New System.Windows.Forms.Label()
        Me.lbl_Postal_Name = New System.Windows.Forms.Label()
        Me.lbl_Town_Name = New System.Windows.Forms.Label()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_Postal_Code = New System.Windows.Forms.TextBox()
        Me.txt_County_Name = New System.Windows.Forms.TextBox()
        Me.txt_Postal_Name = New System.Windows.Forms.TextBox()
        Me.txt_Town_Name = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 119)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 522)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 485)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 485)
        '
        'lbl_Postal_Code
        '
        Me.lbl_Postal_Code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Postal_Code.AutoSize = True
        Me.lbl_Postal_Code.ForeColor = System.Drawing.Color.Red
        Me.lbl_Postal_Code.Location = New System.Drawing.Point(28, 9)
        Me.lbl_Postal_Code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Postal_Code.Name = "lbl_Postal_Code"
        Me.lbl_Postal_Code.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Postal_Code.TabIndex = 0
        Me.lbl_Postal_Code.Text = "*郵遞區號"
        '
        'lbl_County_Name
        '
        Me.lbl_County_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_County_Name.AutoSize = True
        Me.lbl_County_Name.Location = New System.Drawing.Point(272, 9)
        Me.lbl_County_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_County_Name.Name = "lbl_County_Name"
        Me.lbl_County_Name.Size = New System.Drawing.Size(72, 16)
        Me.lbl_County_Name.TabIndex = 1
        Me.lbl_County_Name.Text = "縣市名稱"
        '
        'lbl_Postal_Name
        '
        Me.lbl_Postal_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Postal_Name.AutoSize = True
        Me.lbl_Postal_Name.Location = New System.Drawing.Point(4, 69)
        Me.lbl_Postal_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Postal_Name.Name = "lbl_Postal_Name"
        Me.lbl_Postal_Name.Size = New System.Drawing.Size(104, 16)
        Me.lbl_Postal_Name.TabIndex = 2
        Me.lbl_Postal_Name.Text = "郵遞區號名稱"
        '
        'lbl_Town_Name
        '
        Me.lbl_Town_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Town_Name.AutoSize = True
        Me.lbl_Town_Name.Location = New System.Drawing.Point(288, 69)
        Me.lbl_Town_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Town_Name.Name = "lbl_Town_Name"
        Me.lbl_Town_Name.Size = New System.Drawing.Size(56, 16)
        Me.lbl_Town_Name.TabIndex = 3
        Me.lbl_Town_Name.Text = "鄉鎮區"
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.lbl_Postal_Code, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_County_Name, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Postal_Code, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_County_Name, 3, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_Postal_Name, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Postal_Name, 1, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_Town_Name, 2, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Town_Name, 3, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 119)
        Me.tlp_Main.TabIndex = 4
        '
        'txt_Postal_Code
        '
        Me.txt_Postal_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Postal_Code.Location = New System.Drawing.Point(116, 4)
        Me.txt_Postal_Code.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Postal_Code.MaxLength = 10
        Me.txt_Postal_Code.Name = "txt_Postal_Code"
        Me.txt_Postal_Code.Size = New System.Drawing.Size(148, 27)
        Me.txt_Postal_Code.TabIndex = 4
        '
        'txt_County_Name
        '
        Me.txt_County_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_County_Name.Location = New System.Drawing.Point(352, 4)
        Me.txt_County_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_County_Name.MaxLength = 10
        Me.txt_County_Name.Name = "txt_County_Name"
        Me.txt_County_Name.Size = New System.Drawing.Size(148, 27)
        Me.txt_County_Name.TabIndex = 5
        '
        'txt_Postal_Name
        '
        Me.txt_Postal_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Postal_Name.Location = New System.Drawing.Point(116, 63)
        Me.txt_Postal_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Postal_Name.MaxLength = 20
        Me.txt_Postal_Name.Name = "txt_Postal_Name"
        Me.txt_Postal_Name.Size = New System.Drawing.Size(148, 27)
        Me.txt_Postal_Name.TabIndex = 6
        '
        'txt_Town_Name
        '
        Me.txt_Town_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Town_Name.Location = New System.Drawing.Point(352, 63)
        Me.txt_Town_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Town_Name.MaxLength = 10
        Me.txt_Town_Name.Name = "txt_Town_Name"
        Me.txt_Town_Name.Size = New System.Drawing.Size(148, 27)
        Me.txt_Town_Name.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlp_Main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 119)
        Me.Panel1.TabIndex = 5
        '
        'PUBPostalCodeSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPostalCodeSetupUI"
        Me.Text = "郵遞區號設定維護"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Postal_Code As System.Windows.Forms.Label
    Friend WithEvents lbl_County_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Postal_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Town_Name As System.Windows.Forms.Label
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_Postal_Code As System.Windows.Forms.TextBox
    Friend WithEvents txt_County_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Postal_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Town_Name As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
