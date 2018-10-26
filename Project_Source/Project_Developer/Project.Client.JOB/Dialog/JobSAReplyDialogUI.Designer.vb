<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobSAReplyDialogUI
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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_OK = New System.Windows.Forms.RadioButton()
        Me.rbt_Reject = New System.Windows.Forms.RadioButton()
        Me.btn_Confrim = New System.Windows.Forms.Button()
        Me.rtb_Reply = New System.Windows.Forms.RichTextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.dgv_FilePath = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.btn_Remove = New System.Windows.Forms.Button()
        Me.btn_DownLoad = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(909, 39)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_OK)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_Reject)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Confrim)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(232, 33)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'rbt_OK
        '
        Me.rbt_OK.AutoSize = True
        Me.rbt_OK.Checked = True
        Me.rbt_OK.Location = New System.Drawing.Point(3, 3)
        Me.rbt_OK.Name = "rbt_OK"
        Me.rbt_OK.Size = New System.Drawing.Size(58, 20)
        Me.rbt_OK.TabIndex = 0
        Me.rbt_OK.TabStop = True
        Me.rbt_OK.Text = "完成"
        Me.rbt_OK.UseVisualStyleBackColor = True
        '
        'rbt_Reject
        '
        Me.rbt_Reject.AutoSize = True
        Me.rbt_Reject.Location = New System.Drawing.Point(67, 3)
        Me.rbt_Reject.Name = "rbt_Reject"
        Me.rbt_Reject.Size = New System.Drawing.Size(58, 20)
        Me.rbt_Reject.TabIndex = 1
        Me.rbt_Reject.Text = "退件"
        Me.rbt_Reject.UseVisualStyleBackColor = True
        '
        'btn_Confrim
        '
        Me.btn_Confrim.Location = New System.Drawing.Point(131, 3)
        Me.btn_Confrim.Name = "btn_Confrim"
        Me.btn_Confrim.Size = New System.Drawing.Size(96, 27)
        Me.btn_Confrim.TabIndex = 2
        Me.btn_Confrim.Text = "送出"
        Me.btn_Confrim.UseVisualStyleBackColor = True
        '
        'rtb_Reply
        '
        Me.rtb_Reply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Reply.Location = New System.Drawing.Point(3, 3)
        Me.rtb_Reply.Name = "rtb_Reply"
        Me.rtb_Reply.Size = New System.Drawing.Size(889, 361)
        Me.rtb_Reply.TabIndex = 0
        Me.rtb_Reply.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(903, 397)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rtb_Reply)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(895, 367)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "退件理由"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(895, 367)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "附件檔案"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.83577!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.16423!))
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_FilePath, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(889, 361)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_DownLoad)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Insert)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Remove)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(117, 355)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'dgv_FilePath
        '
        Me.dgv_FilePath.AllowUserToAddRows = False
        Me.dgv_FilePath.AllowUserToOrderColumns = False
        Me.dgv_FilePath.AllowUserToResizeColumns = True
        Me.dgv_FilePath.AllowUserToResizeRows = False
        Me.dgv_FilePath.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_FilePath.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_FilePath.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_FilePath.ColumnHeadersHeight = 4
        Me.dgv_FilePath.ColumnHeadersVisible = True
        Me.dgv_FilePath.CurrentCell = Nothing
        Me.dgv_FilePath.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_FilePath.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_FilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_FilePath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_FilePath.Location = New System.Drawing.Point(127, 4)
        Me.dgv_FilePath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_FilePath.MultiSelect = True
        Me.dgv_FilePath.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_FilePath.Name = "dgv_FilePath"
        Me.dgv_FilePath.RowHeadersWidth = 41
        Me.dgv_FilePath.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_FilePath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_FilePath.Size = New System.Drawing.Size(758, 353)
        Me.dgv_FilePath.TabIndex = 1
        Me.dgv_FilePath.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_FilePath.uclBatchColIndex = ""
        Me.dgv_FilePath.uclClickToCheck = False
        Me.dgv_FilePath.uclColumnAlignment = ""
        Me.dgv_FilePath.uclColumnCheckBox = True
        Me.dgv_FilePath.uclColumnControlType = ""
        Me.dgv_FilePath.uclColumnWidth = ""
        Me.dgv_FilePath.uclDoCellEnter = True
        Me.dgv_FilePath.uclHasNewRow = False
        Me.dgv_FilePath.uclHeaderText = ""
        Me.dgv_FilePath.uclIsAlternatingRowsColors = True
        Me.dgv_FilePath.uclIsComboBoxGridQuery = True
        Me.dgv_FilePath.uclIsComboxClickTriggerDropDown = False
        Me.dgv_FilePath.uclIsDoOrderCheck = True
        Me.dgv_FilePath.uclIsDoQueryComboBoxGrid = True
        Me.dgv_FilePath.uclIsSortable = False
        Me.dgv_FilePath.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_FilePath.uclNonVisibleColIndex = ""
        Me.dgv_FilePath.uclReadOnly = False
        Me.dgv_FilePath.uclShowCellBorder = False
        Me.dgv_FilePath.uclSortColIndex = ""
        Me.dgv_FilePath.uclTreeMode = False
        Me.dgv_FilePath.uclVisibleColIndex = ""
        '
        'btn_Insert
        '
        Me.btn_Insert.Location = New System.Drawing.Point(3, 37)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(114, 28)
        Me.btn_Insert.TabIndex = 0
        Me.btn_Insert.Text = "加入"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'btn_Remove
        '
        Me.btn_Remove.Location = New System.Drawing.Point(3, 71)
        Me.btn_Remove.Name = "btn_Remove"
        Me.btn_Remove.Size = New System.Drawing.Size(114, 28)
        Me.btn_Remove.TabIndex = 1
        Me.btn_Remove.Text = "移除"
        Me.btn_Remove.UseVisualStyleBackColor = True
        '
        'btn_DownLoad
        '
        Me.btn_DownLoad.Location = New System.Drawing.Point(3, 3)
        Me.btn_DownLoad.Name = "btn_DownLoad"
        Me.btn_DownLoad.Size = New System.Drawing.Size(114, 28)
        Me.btn_DownLoad.TabIndex = 2
        Me.btn_DownLoad.Text = "下載附件"
        Me.btn_DownLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'JobSAReplyDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 447)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "JobSAReplyDialogUI"
        Me.TabText = "派工結果回覆"
        Me.Text = "派工回覆作業"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_OK As Windows.Forms.RadioButton
    Friend WithEvents rbt_Reject As Windows.Forms.RadioButton
    Friend WithEvents rtb_Reply As Windows.Forms.RichTextBox
    Friend WithEvents btn_Confrim As Windows.Forms.Button
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Insert As Windows.Forms.Button
    Friend WithEvents btn_Remove As Windows.Forms.Button
    Friend WithEvents dgv_FilePath As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_DownLoad As Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
End Class
