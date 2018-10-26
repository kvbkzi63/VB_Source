Imports Syscom.Client.UCL

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobMailGroupDetailUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobMailGroupDetailUI))
        Me.tlp_Main1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_GroupId = New System.Windows.Forms.TextBox()
        Me.txt_GroupName = New System.Windows.Forms.TextBox()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Receiver = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_EMail = New System.Windows.Forms.TextBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 84)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(944, 557)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(942, 520)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(942, 520)
        '
        'tlp_Main1
        '
        Me.tlp_Main1.ColumnCount = 7
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlp_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 472.0!))
        Me.tlp_Main1.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main1.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main1.Controls.Add(Me.txt_GroupId, 1, 0)
        Me.tlp_Main1.Controls.Add(Me.txt_GroupName, 3, 0)
        Me.tlp_Main1.Controls.Add(Me.tlp_Main, 0, 1)
        Me.tlp_Main1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main1.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main1.Name = "tlp_Main1"
        Me.tlp_Main1.RowCount = 2
        Me.tlp_Main1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlp_Main1.Size = New System.Drawing.Size(944, 84)
        Me.tlp_Main1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "群組代號"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "群組名稱"
        '
        'txt_GroupId
        '
        Me.txt_GroupId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_GroupId.Enabled = False
        Me.txt_GroupId.Location = New System.Drawing.Point(81, 6)
        Me.txt_GroupId.Name = "txt_GroupId"
        Me.txt_GroupId.Size = New System.Drawing.Size(117, 27)
        Me.txt_GroupId.TabIndex = 3
        '
        'txt_GroupName
        '
        Me.txt_GroupName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_GroupName.Enabled = False
        Me.txt_GroupName.Location = New System.Drawing.Point(282, 6)
        Me.txt_GroupName.Name = "txt_GroupName"
        Me.txt_GroupName.Size = New System.Drawing.Size(172, 27)
        Me.txt_GroupName.TabIndex = 4
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main1.SetColumnSpan(Me.tlp_Main, 7)
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 0)
        Me.tlp_Main.Controls.Add(Me.cbo_Receiver, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_EMail, 3, 0)
        Me.tlp_Main.Location = New System.Drawing.Point(3, 43)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 1
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(940, 38)
        Me.tlp_Main.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "收件者"
        '
        'cbo_Receiver
        '
        Me.cbo_Receiver.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Receiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Receiver.DropDownWidth = 20
        Me.cbo_Receiver.DroppedDown = False
        Me.cbo_Receiver.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Receiver.Location = New System.Drawing.Point(62, 9)
        Me.cbo_Receiver.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Receiver.Name = "cbo_Receiver"
        Me.cbo_Receiver.SelectedIndex = -1
        Me.cbo_Receiver.SelectedItem = Nothing
        Me.cbo_Receiver.SelectedText = ""
        Me.cbo_Receiver.SelectedValue = ""
        Me.cbo_Receiver.SelectionStart = 0
        Me.cbo_Receiver.Size = New System.Drawing.Size(135, 20)
        Me.cbo_Receiver.TabIndex = 9
        Me.cbo_Receiver.uclDisplayIndex = "0,1"
        Me.cbo_Receiver.uclIsAutoClear = True
        Me.cbo_Receiver.uclIsFirstItemEmpty = True
        Me.cbo_Receiver.uclIsTextMode = False
        Me.cbo_Receiver.uclShowMsg = False
        Me.cbo_Receiver.uclValueIndex = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "電子郵件"
        '
        'txt_EMail
        '
        Me.txt_EMail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EMail.Location = New System.Drawing.Point(278, 5)
        Me.txt_EMail.Name = "txt_EMail"
        Me.txt_EMail.Size = New System.Drawing.Size(172, 27)
        Me.txt_EMail.TabIndex = 11
        '
        'JobMailGroupDetailUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.tlp_Main1)
        Me.Name = "JobMailGroupDetailUI"
        Me.Text = "郵件信箱設定"
        Me.Controls.SetChildIndex(Me.tlp_Main1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main1.ResumeLayout(False)
        Me.tlp_Main1.PerformLayout()
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_Main1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_GroupId As Windows.Forms.TextBox
    Friend WithEvents txt_GroupName As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbo_Receiver As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txt_EMail As Windows.Forms.TextBox
    Friend WithEvents tlp_Main As Windows.Forms.TableLayoutPanel
End Class
