<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubConfigMaintainMultichoiceUI
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
        Me.tlp_Maintain = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ConfigName = New System.Windows.Forms.TextBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        Me.tlp_Maintain.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 37)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 604)
        '
        'dgvPanel
        '
        Me.dgvPanel.Size = New System.Drawing.Size(962, 567)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 567)
        '
        'tlp_Maintain
        '
        Me.tlp_Maintain.ColumnCount = 2
        Me.tlp_Maintain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82573!))
        Me.tlp_Maintain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.17427!))
        Me.tlp_Maintain.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Maintain.Controls.Add(Me.txt_ConfigName, 1, 0)
        Me.tlp_Maintain.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Maintain.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Maintain.Name = "tlp_Maintain"
        Me.tlp_Maintain.RowCount = 1
        Me.tlp_Maintain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Maintain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tlp_Maintain.Size = New System.Drawing.Size(964, 37)
        Me.tlp_Maintain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "系統參數名稱"
        '
        'txt_ConfigName
        '
        Me.txt_ConfigName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ConfigName.Location = New System.Drawing.Point(117, 5)
        Me.txt_ConfigName.MaxLength = 100
        Me.txt_ConfigName.Name = "txt_ConfigName"
        Me.txt_ConfigName.Size = New System.Drawing.Size(577, 27)
        Me.txt_ConfigName.TabIndex = 1
        '
        'PubConfigMaintainMultichoiceUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Maintain)
        Me.Name = "PubConfigMaintainMultichoiceUI"
        Me.Text = "PubConfigMaintainMultichoiceUI"
        Me.Controls.SetChildIndex(Me.tlp_Maintain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        Me.tlp_Maintain.ResumeLayout(False)
        Me.tlp_Maintain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Maintain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ConfigName As System.Windows.Forms.TextBox
End Class
