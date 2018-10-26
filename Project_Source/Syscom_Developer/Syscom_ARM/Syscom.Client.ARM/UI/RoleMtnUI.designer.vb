<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoleMtnUI

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
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_roleID = New System.Windows.Forms.Label()
        Me.roleID = New System.Windows.Forms.TextBox()
        Me.lbl_roleName = New System.Windows.Forms.Label()
        Me.lbl_DC = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoBtnN = New System.Windows.Forms.RadioButton()
        Me.RdoBtnY = New System.Windows.Forms.RadioButton()
        Me.lbl_isAgent = New System.Windows.Forms.Label()
        Me.roleName = New System.Windows.Forms.TextBox()
        Me.lbl_Member = New System.Windows.Forms.Label()
        Me.txt_Member = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rdo_IsAgentY = New System.Windows.Forms.RadioButton()
        Me.rdo_IsAgentN = New System.Windows.Forms.RadioButton()
        Me.Chk_DeleteFlag = New System.Windows.Forms.CheckBox()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_RoleRightsMtn = New System.Windows.Forms.Button()
        Me.btnEsc = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_nonButton.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 6
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 362.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.Controls.Add(Me.lbl_roleID, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.roleID, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_roleName, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_DC, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.Panel2, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_isAgent, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.roleName, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Member, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.txt_Member, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.FlowLayoutPanel1, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.Chk_DeleteFlag, 5, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 3
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1008, 65)
        Me.tlp_nonButton.TabIndex = 0
        '
        'lbl_roleID
        '
        Me.lbl_roleID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_roleID.AutoSize = True
        Me.lbl_roleID.ForeColor = System.Drawing.Color.Red
        Me.lbl_roleID.Location = New System.Drawing.Point(22, 8)
        Me.lbl_roleID.Name = "lbl_roleID"
        Me.lbl_roleID.Size = New System.Drawing.Size(80, 16)
        Me.lbl_roleID.TabIndex = 0
        Me.lbl_roleID.Text = "*角色代碼"
        '
        'roleID
        '
        Me.roleID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.roleID.Location = New System.Drawing.Point(108, 3)
        Me.roleID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.roleID.Name = "roleID"
        Me.roleID.Size = New System.Drawing.Size(155, 27)
        Me.roleID.TabIndex = 1
        '
        'lbl_roleName
        '
        Me.lbl_roleName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_roleName.AutoSize = True
        Me.lbl_roleName.Location = New System.Drawing.Point(323, 8)
        Me.lbl_roleName.Name = "lbl_roleName"
        Me.lbl_roleName.Size = New System.Drawing.Size(80, 16)
        Me.lbl_roleName.TabIndex = 1
        Me.lbl_roleName.Text = "*角色名稱"
        '
        'lbl_DC
        '
        Me.lbl_DC.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DC.AutoSize = True
        Me.lbl_DC.Location = New System.Drawing.Point(22, 40)
        Me.lbl_DC.Name = "lbl_DC"
        Me.lbl_DC.Size = New System.Drawing.Size(80, 16)
        Me.lbl_DC.TabIndex = 2
        Me.lbl_DC.Text = "*是否有效"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoBtnN)
        Me.Panel2.Controls.Add(Me.RdoBtnY)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(109, 36)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(154, 24)
        Me.Panel2.TabIndex = 3
        '
        'RdoBtnN
        '
        Me.RdoBtnN.AutoSize = True
        Me.RdoBtnN.Location = New System.Drawing.Point(58, 3)
        Me.RdoBtnN.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnN.Name = "RdoBtnN"
        Me.RdoBtnN.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnN.TabIndex = 4
        Me.RdoBtnN.TabStop = True
        Me.RdoBtnN.UseVisualStyleBackColor = True
        '
        'RdoBtnY
        '
        Me.RdoBtnY.AutoSize = True
        Me.RdoBtnY.Location = New System.Drawing.Point(4, 3)
        Me.RdoBtnY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnY.Name = "RdoBtnY"
        Me.RdoBtnY.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnY.TabIndex = 3
        Me.RdoBtnY.TabStop = True
        Me.RdoBtnY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RdoBtnY.UseVisualStyleBackColor = True
        '
        'lbl_isAgent
        '
        Me.lbl_isAgent.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_isAgent.AutoSize = True
        Me.lbl_isAgent.Location = New System.Drawing.Point(299, 40)
        Me.lbl_isAgent.Name = "lbl_isAgent"
        Me.lbl_isAgent.Size = New System.Drawing.Size(104, 16)
        Me.lbl_isAgent.TabIndex = 4
        Me.lbl_isAgent.Text = "是否允許授權"
        '
        'roleName
        '
        Me.roleName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.roleName.Location = New System.Drawing.Point(409, 3)
        Me.roleName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.roleName.Name = "roleName"
        Me.roleName.Size = New System.Drawing.Size(156, 27)
        Me.roleName.TabIndex = 2
        '
        'lbl_Member
        '
        Me.lbl_Member.AutoSize = True
        Me.lbl_Member.Location = New System.Drawing.Point(599, 0)
        Me.lbl_Member.Name = "lbl_Member"
        Me.lbl_Member.Size = New System.Drawing.Size(51, 16)
        Me.lbl_Member.TabIndex = 7
        Me.lbl_Member.Text = "Label1"
        '
        'txt_Member
        '
        Me.txt_Member.Location = New System.Drawing.Point(689, 3)
        Me.txt_Member.Name = "txt_Member"
        Me.txt_Member.Size = New System.Drawing.Size(259, 27)
        Me.txt_Member.TabIndex = 8
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rdo_IsAgentY)
        Me.FlowLayoutPanel1.Controls.Add(Me.rdo_IsAgentN)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(406, 33)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(167, 30)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'rdo_IsAgentY
        '
        Me.rdo_IsAgentY.AutoSize = True
        Me.rdo_IsAgentY.Location = New System.Drawing.Point(3, 3)
        Me.rdo_IsAgentY.Name = "rdo_IsAgentY"
        Me.rdo_IsAgentY.Size = New System.Drawing.Size(75, 20)
        Me.rdo_IsAgentY.TabIndex = 0
        Me.rdo_IsAgentY.TabStop = True
        Me.rdo_IsAgentY.Text = "AgentY"
        Me.rdo_IsAgentY.UseVisualStyleBackColor = True
        '
        'rdo_IsAgentN
        '
        Me.rdo_IsAgentN.AutoSize = True
        Me.rdo_IsAgentN.Location = New System.Drawing.Point(84, 3)
        Me.rdo_IsAgentN.Name = "rdo_IsAgentN"
        Me.rdo_IsAgentN.Size = New System.Drawing.Size(75, 20)
        Me.rdo_IsAgentN.TabIndex = 1
        Me.rdo_IsAgentN.TabStop = True
        Me.rdo_IsAgentN.Text = "AgentN"
        Me.rdo_IsAgentN.UseVisualStyleBackColor = True
        '
        'Chk_DeleteFlag
        '
        Me.Chk_DeleteFlag.AutoSize = True
        Me.Chk_DeleteFlag.Location = New System.Drawing.Point(689, 36)
        Me.Chk_DeleteFlag.Name = "Chk_DeleteFlag"
        Me.Chk_DeleteFlag.Size = New System.Drawing.Size(91, 20)
        Me.Chk_DeleteFlag.TabIndex = 9
        Me.Chk_DeleteFlag.Text = "控制刪除"
        Me.Chk_DeleteFlag.UseVisualStyleBackColor = True
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btn_RoleRightsMtn)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnEsc)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnDelete)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnUpdate)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnInsert)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(0, 65)
        Me.btnFlowLayoutPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(1008, 34)
        Me.btnFlowLayoutPanel.TabIndex = 1
        '
        'btn_RoleRightsMtn
        '
        Me.btn_RoleRightsMtn.Location = New System.Drawing.Point(890, 3)
        Me.btn_RoleRightsMtn.Name = "btn_RoleRightsMtn"
        Me.btn_RoleRightsMtn.Size = New System.Drawing.Size(115, 25)
        Me.btn_RoleRightsMtn.TabIndex = 10
        Me.btn_RoleRightsMtn.Text = "角色權限設定"
        Me.btn_RoleRightsMtn.UseVisualStyleBackColor = True
        '
        'btnEsc
        '
        Me.btnEsc.Location = New System.Drawing.Point(799, 3)
        Me.btnEsc.Name = "btnEsc"
        Me.btnEsc.Size = New System.Drawing.Size(85, 25)
        Me.btnEsc.TabIndex = 11
        Me.btnEsc.Text = "ESC-退出"
        Me.btnEsc.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(718, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 25)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(637, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 25)
        Me.btnQuery.TabIndex = 8
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(546, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 25)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "SF12-刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(455, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(85, 25)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "F10-修改"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(364, 3)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(85, 25)
        Me.btnInsert.TabIndex = 5
        Me.btnInsert.Text = "F12-新增"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'dgv_ShowData
        '
        Me.dgv_ShowData.AllowUserToAddRows = False
        Me.dgv_ShowData.AllowUserToOrderColumns = False
        Me.dgv_ShowData.AllowUserToResizeColumns = True
        Me.dgv_ShowData.AllowUserToResizeRows = False
        Me.dgv_ShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ShowData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ShowData.ColumnHeadersHeight = 4
        Me.dgv_ShowData.ColumnHeadersVisible = True
        Me.dgv_ShowData.CurrentCell = Nothing
        Me.dgv_ShowData.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ShowData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(0, 99)
        Me.dgv_ShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(1008, 520)
        Me.dgv_ShowData.TabIndex = 2
        Me.dgv_ShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_ShowData.uclBatchColIndex = ""
        Me.dgv_ShowData.uclClickToCheck = False
        Me.dgv_ShowData.uclColumnAlignment = ""
        Me.dgv_ShowData.uclColumnCheckBox = False
        Me.dgv_ShowData.uclColumnControlType = ""
        Me.dgv_ShowData.uclColumnWidth = ""
        Me.dgv_ShowData.uclDoCellEnter = True
        Me.dgv_ShowData.uclHasNewRow = False
        Me.dgv_ShowData.uclHeaderText = ""
        Me.dgv_ShowData.uclIsAlternatingRowsColors = True
        Me.dgv_ShowData.uclIsComboBoxGridQuery = True
        Me.dgv_ShowData.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ShowData.uclIsDoOrderCheck = True
        Me.dgv_ShowData.uclIsSortable = False
        Me.dgv_ShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowData.uclNonVisibleColIndex = ""
        Me.dgv_ShowData.uclReadOnly = False
        Me.dgv_ShowData.uclShowCellBorder = False
        Me.dgv_ShowData.uclSortColIndex = ""
        Me.dgv_ShowData.uclTreeMode = False
        Me.dgv_ShowData.uclVisibleColIndex = ""
        '
        'RoleMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.dgv_ShowData)
        Me.Controls.Add(Me.btnFlowLayoutPanel)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "RoleMtnUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "角色維護"
        Me.Text = "角色維護"
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_roleID As System.Windows.Forms.Label
    Friend WithEvents lbl_roleName As System.Windows.Forms.Label
    Friend WithEvents lbl_DC As System.Windows.Forms.Label
    Friend WithEvents roleID As System.Windows.Forms.TextBox
    Friend WithEvents roleName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBtnY As System.Windows.Forms.RadioButton
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_RoleRightsMtn As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnEsc As System.Windows.Forms.Button
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents lbl_isAgent As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdo_IsAgentY As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_IsAgentN As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_Member As System.Windows.Forms.Label
    Friend WithEvents txt_Member As System.Windows.Forms.TextBox
    Friend WithEvents Chk_DeleteFlag As System.Windows.Forms.CheckBox
End Class
