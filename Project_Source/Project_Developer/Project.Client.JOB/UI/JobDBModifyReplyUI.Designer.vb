<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobDBModifyReplyUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDBModifyReplyUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_Project = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_Finished = New System.Windows.Forms.RadioButton()
        Me.rbt_UnFinish = New System.Windows.Forms.RadioButton()
        Me.rbt_All = New System.Windows.Forms.RadioButton()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_DBModifiyList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Project, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(944, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "專案別"
        '
        'cbo_Project
        '
        Me.cbo_Project.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Project.DropDownWidth = 20
        Me.cbo_Project.DroppedDown = False
        Me.cbo_Project.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Project.Location = New System.Drawing.Point(62, 8)
        Me.cbo_Project.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Project.Name = "cbo_Project"
        Me.cbo_Project.SelectedIndex = -1
        Me.cbo_Project.SelectedItem = Nothing
        Me.cbo_Project.SelectedText = ""
        Me.cbo_Project.SelectedValue = ""
        Me.cbo_Project.SelectionStart = 0
        Me.cbo_Project.Size = New System.Drawing.Size(381, 25)
        Me.cbo_Project.TabIndex = 1
        Me.cbo_Project.uclDisplayIndex = "0,1"
        Me.cbo_Project.uclIsAutoClear = True
        Me.cbo_Project.uclIsFirstItemEmpty = True
        Me.cbo_Project.uclIsTextMode = False
        Me.cbo_Project.uclShowMsg = False
        Me.cbo_Project.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_Finished)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_UnFinish)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_All)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(446, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(498, 36)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'rbt_Finished
        '
        Me.rbt_Finished.AutoSize = True
        Me.rbt_Finished.Checked = True
        Me.rbt_Finished.Location = New System.Drawing.Point(3, 3)
        Me.rbt_Finished.Name = "rbt_Finished"
        Me.rbt_Finished.Size = New System.Drawing.Size(74, 20)
        Me.rbt_Finished.TabIndex = 0
        Me.rbt_Finished.TabStop = True
        Me.rbt_Finished.Text = "已完成"
        Me.rbt_Finished.UseVisualStyleBackColor = True
        '
        'rbt_UnFinish
        '
        Me.rbt_UnFinish.AutoSize = True
        Me.rbt_UnFinish.Location = New System.Drawing.Point(83, 3)
        Me.rbt_UnFinish.Name = "rbt_UnFinish"
        Me.rbt_UnFinish.Size = New System.Drawing.Size(74, 20)
        Me.rbt_UnFinish.TabIndex = 1
        Me.rbt_UnFinish.Text = "未完成"
        Me.rbt_UnFinish.UseVisualStyleBackColor = True
        '
        'rbt_All
        '
        Me.rbt_All.AutoSize = True
        Me.rbt_All.Location = New System.Drawing.Point(163, 3)
        Me.rbt_All.Name = "rbt_All"
        Me.rbt_All.Size = New System.Drawing.Size(58, 20)
        Me.rbt_All.TabIndex = 2
        Me.rbt_All.TabStop = True
        Me.rbt_All.Text = "全部"
        Me.rbt_All.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(227, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(118, 30)
        Me.btn_Query.TabIndex = 3
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgv_DBModifiyList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(944, 599)
        Me.Panel1.TabIndex = 1
        '
        'dgv_DBModifiyList
        '
        Me.dgv_DBModifiyList.AllowUserToAddRows = False
        Me.dgv_DBModifiyList.AllowUserToOrderColumns = False
        Me.dgv_DBModifiyList.AllowUserToResizeColumns = True
        Me.dgv_DBModifiyList.AllowUserToResizeRows = False
        Me.dgv_DBModifiyList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_DBModifiyList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_DBModifiyList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_DBModifiyList.ColumnHeadersHeight = 4
        Me.dgv_DBModifiyList.ColumnHeadersVisible = True
        Me.dgv_DBModifiyList.CurrentCell = Nothing
        Me.dgv_DBModifiyList.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_DBModifiyList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_DBModifiyList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_DBModifiyList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_DBModifiyList.Location = New System.Drawing.Point(0, 0)
        Me.dgv_DBModifiyList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_DBModifiyList.MultiSelect = False
        Me.dgv_DBModifiyList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_DBModifiyList.Name = "dgv_DBModifiyList"
        Me.dgv_DBModifiyList.RowHeadersWidth = 41
        Me.dgv_DBModifiyList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_DBModifiyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DBModifiyList.Size = New System.Drawing.Size(944, 599)
        Me.dgv_DBModifiyList.TabIndex = 0
        Me.dgv_DBModifiyList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_DBModifiyList.uclBatchColIndex = ""
        Me.dgv_DBModifiyList.uclClickToCheck = False
        Me.dgv_DBModifiyList.uclColumnAlignment = ""
        Me.dgv_DBModifiyList.uclColumnCheckBox = False
        Me.dgv_DBModifiyList.uclColumnControlType = ""
        Me.dgv_DBModifiyList.uclColumnWidth = ""
        Me.dgv_DBModifiyList.uclDoCellEnter = True
        Me.dgv_DBModifiyList.uclHasNewRow = False
        Me.dgv_DBModifiyList.uclHeaderText = ""
        Me.dgv_DBModifiyList.uclIsAlternatingRowsColors = True
        Me.dgv_DBModifiyList.uclIsComboBoxGridQuery = True
        Me.dgv_DBModifiyList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_DBModifiyList.uclIsDoOrderCheck = True
        Me.dgv_DBModifiyList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_DBModifiyList.uclIsSortable = False
        Me.dgv_DBModifiyList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_DBModifiyList.uclNonVisibleColIndex = ""
        Me.dgv_DBModifiyList.uclReadOnly = False
        Me.dgv_DBModifiyList.uclShowCellBorder = False
        Me.dgv_DBModifiyList.uclSortColIndex = ""
        Me.dgv_DBModifiyList.uclTreeMode = False
        Me.dgv_DBModifiyList.uclVisibleColIndex = ""
        '
        'JobDBModifyReplyUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.CloseButton = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "JobDBModifyReplyUI"
        Me.TabText = "DB異動申請回覆"
        Me.Text = "DB異動申請回覆"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbo_Project As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_Finished As Windows.Forms.RadioButton
    Friend WithEvents rbt_UnFinish As Windows.Forms.RadioButton
    Friend WithEvents rbt_All As Windows.Forms.RadioButton
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents dgv_DBModifiyList As Syscom.Client.UCL.UCLDataGridViewUC
End Class
