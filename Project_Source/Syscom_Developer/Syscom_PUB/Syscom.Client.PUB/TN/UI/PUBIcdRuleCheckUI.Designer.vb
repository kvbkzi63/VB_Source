<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBIcdRuleCheckUI
    Inherits Syscom.Client.UCL.BaseFormUI

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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.dg1 = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.tr1_View = New System.Windows.Forms.TreeView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnOpenOther = New System.Windows.Forms.Button()
        Me.label_Msg = New System.Windows.Forms.Label()
        Me.txt_Other = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Ok = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Force = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 42)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(909, 508)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(901, 478)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "適應症規範"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(895, 472)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.dg1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RichTextBox1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(895, 529)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToOrderColumns = False
        Me.dg1.AllowUserToResizeColumns = True
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dg1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.ColumnHeadersHeight = 4
        Me.dg1.ColumnHeadersVisible = True
        Me.dg1.CurrentCell = Nothing
        Me.dg1.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dg1.Location = New System.Drawing.Point(517, 5)
        Me.dg1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dg1.MultiSelect = False
        Me.dg1.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersWidth = 41
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(372, 295)
        Me.dg1.TabIndex = 1
        Me.dg1.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dg1.uclBatchColIndex = ""
        Me.dg1.uclClickToCheck = False
        Me.dg1.uclColumnAlignment = ""
        Me.dg1.uclColumnCheckBox = False
        Me.dg1.uclColumnControlType = ""
        Me.dg1.uclColumnWidth = ""
        Me.dg1.uclDoCellEnter = True
        Me.dg1.uclHasNewRow = False
        Me.dg1.uclHeaderText = ""
        Me.dg1.uclIsAlternatingRowsColors = True
        Me.dg1.uclIsComboBoxGridQuery = True
        Me.dg1.uclIsDoOrderCheck = True
        Me.dg1.uclIsSortable = False
        Me.dg1.uclMultiSelectShowCheckBoxHeader = True
        Me.dg1.uclNonVisibleColIndex = ""
        Me.dg1.uclReadOnly = False
        Me.dg1.uclShowCellBorder = False
        Me.dg1.uclSortColIndex = ""
        Me.dg1.uclTreeMode = False
        Me.dg1.uclVisibleColIndex = ""
        '
        'RichTextBox1
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.RichTextBox1, 2)
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 308)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(889, 167)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.51644!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(505, 299)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.tr1_View, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.32442!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.675585!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(505, 299)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'tr1_View
        '
        Me.tr1_View.CheckBoxes = True
        Me.tr1_View.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tr1_View.Location = New System.Drawing.Point(3, 3)
        Me.tr1_View.Name = "tr1_View"
        Me.tr1_View.PathSeparator = "|"
        Me.tr1_View.Size = New System.Drawing.Size(499, 285)
        Me.tr1_View.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOpenOther)
        Me.Panel2.Controls.Add(Me.label_Msg)
        Me.Panel2.Controls.Add(Me.txt_Other)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 291)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 8)
        Me.Panel2.TabIndex = 1
        '
        'btnOpenOther
        '
        Me.btnOpenOther.Location = New System.Drawing.Point(675, 60)
        Me.btnOpenOther.Name = "btnOpenOther"
        Me.btnOpenOther.Size = New System.Drawing.Size(23, 21)
        Me.btnOpenOther.TabIndex = 3
        Me.btnOpenOther.UseVisualStyleBackColor = True
        Me.btnOpenOther.Visible = False
        '
        'label_Msg
        '
        Me.label_Msg.BackColor = System.Drawing.Color.Yellow
        Me.label_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_Msg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label_Msg.ForeColor = System.Drawing.Color.Red
        Me.label_Msg.Location = New System.Drawing.Point(0, 0)
        Me.label_Msg.Name = "label_Msg"
        Me.label_Msg.Size = New System.Drawing.Size(505, 8)
        Me.label_Msg.TabIndex = 2
        Me.label_Msg.Text = "依第58次醫療健保諮商會議決議，移除適應症中使用者自行輸入的「其他」欄位，若病人不符合上列的健保適應症，請向病人說明此項目須自費使用並簽署自費同意書。(連絡分機：" & _
    "2776、2722)"
        Me.label_Msg.Visible = False
        '
        'txt_Other
        '
        Me.txt_Other.Location = New System.Drawing.Point(59, 3)
        Me.txt_Other.MaxLength = 500
        Me.txt_Other.Multiline = True
        Me.txt_Other.Name = "txt_Other"
        Me.txt_Other.Size = New System.Drawing.Size(639, 78)
        Me.txt_Other.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "其他"
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(815, 6)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(87, 33)
        Me.btn_Ok.TabIndex = 0
        Me.btn_Ok.Text = "F12-確認"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.647059!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.35294!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(909, 550)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Cancel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btn_Force)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_Ok)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(909, 42)
        Me.Panel1.TabIndex = 0
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(717, 6)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(83, 32)
        Me.btn_Cancel.TabIndex = 4
        Me.btn_Cancel.Text = "F5-取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(452, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        '
        'btn_Force
        '
        Me.btn_Force.Location = New System.Drawing.Point(587, 6)
        Me.btn_Force.Name = "btn_Force"
        Me.btn_Force.Size = New System.Drawing.Size(108, 32)
        Me.btn_Force.TabIndex = 2
        Me.btn_Force.Text = "F1-強迫自費"
        Me.btn_Force.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'PUBIcdRuleCheckUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(909, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.DockAreas = CType((((((Com.Syscom.WinFormsUI.Docking.DockAreas.Float Or Com.Syscom.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or Com.Syscom.WinFormsUI.Docking.DockAreas.DockRight) _
            Or Com.Syscom.WinFormsUI.Docking.DockAreas.DockTop) _
            Or Com.Syscom.WinFormsUI.Docking.DockAreas.DockBottom) _
            Or Com.Syscom.WinFormsUI.Docking.DockAreas.Document), Com.Syscom.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PUBIcdRuleCheckUI"
        Me.ShowHint = Com.Syscom.WinFormsUI.Docking.DockState.Unknown
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "適應症檢核"
        Me.Text = "適應症檢核"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dg1 As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tr1_View As System.Windows.Forms.TreeView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Other As System.Windows.Forms.TextBox
    Friend WithEvents btn_Force As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents label_Msg As System.Windows.Forms.Label
    Friend WithEvents btnOpenOther As System.Windows.Forms.Button
End Class
