<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMaintainMultichoiceFormUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.IUCLMaintainPanel = New System.Windows.Forms.Panel()
        Me.dgvPanel = New System.Windows.Forms.Panel()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.dgvPanel.SuspendLayout()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Controls.Add(Me.dgvPanel)
        Me.IUCLMaintainPanel.Controls.Add(Me.btnFlowLayoutPanel)
        Me.IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 0)
        Me.IUCLMaintainPanel.Name = "IUCLMaintainPanel"
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(531, 286)
        Me.IUCLMaintainPanel.TabIndex = 6
        '
        'dgvPanel
        '
        Me.dgvPanel.Controls.Add(Me.dgvShowData)
        Me.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPanel.Location = New System.Drawing.Point(1, 36)
        Me.dgvPanel.Name = "dgvPanel"
        Me.dgvPanel.Size = New System.Drawing.Size(529, 249)
        Me.dgvPanel.TabIndex = 1
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnDelete)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnSave)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(1, 1)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(529, 35)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(436, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 28)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(340, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(90, 28)
        Me.btnQuery.TabIndex = 3
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(244, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 28)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "SF12-刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(148, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 28)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "F12-確認"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = True
        Me.dgvShowData.AllowUserToOrderColumns = False
        Me.dgvShowData.AllowUserToResizeColumns = True
        Me.dgvShowData.AllowUserToResizeRows = False
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.ColumnHeadersVisible = True
        Me.dgvShowData.CurrentCell = Nothing
        Me.dgvShowData.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShowData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvShowData.Location = New System.Drawing.Point(0, 0)
        Me.dgvShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvShowData.MultiSelect = True
        Me.dgvShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.RowHeadersWidth = 41
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvShowData.Size = New System.Drawing.Size(529, 249)
        Me.dgvShowData.TabIndex = 0
        Me.dgvShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvShowData.uclBatchColIndex = ""
        Me.dgvShowData.uclClickToCheck = True
        Me.dgvShowData.uclColumnAlignment = ""
        Me.dgvShowData.uclColumnCheckBox = True
        Me.dgvShowData.uclColumnControlType = ""
        Me.dgvShowData.uclColumnWidth = ""
        Me.dgvShowData.uclDoCellEnter = True
        Me.dgvShowData.uclHasNewRow = True
        Me.dgvShowData.uclHeaderText = ""
        Me.dgvShowData.uclIsAlternatingRowsColors = True
        Me.dgvShowData.uclIsComboBoxGridQuery = True
        Me.dgvShowData.uclIsDoOrderCheck = True
        Me.dgvShowData.uclIsSortable = False
        Me.dgvShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgvShowData.uclNonVisibleColIndex = ""
        Me.dgvShowData.uclReadOnly = False
        Me.dgvShowData.uclShowCellBorder = False
        Me.dgvShowData.uclSortColIndex = ""
        Me.dgvShowData.uclTreeMode = False
        Me.dgvShowData.uclVisibleColIndex = ""
        '
        'IMaintainMultichoiceFormUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 286)
        Me.Controls.Add(Me.IUCLMaintainPanel)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "IMaintainMultichoiceFormUI"
        Me.TabText = "IMaintainMultichoiceFormUI"
        Me.Text = "IMaintainMultichoiceFormUI"
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.dgvPanel.ResumeLayout(False)
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents IUCLMaintainPanel As System.Windows.Forms.Panel
    Public WithEvents dgvPanel As System.Windows.Forms.Panel
    Public WithEvents dgvShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Public WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnQuery As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Public WithEvents btnSave As System.Windows.Forms.Button
End Class
