<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoleRightsMtnUI
    Inherits System.Windows.Forms.Form

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_roleID = New System.Windows.Forms.Label()
        Me.lbl_roleName = New System.Windows.Forms.Label()
        Me.txt_RoleID = New System.Windows.Forms.TextBox()
        Me.txt_roleName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chk_opdflag = New System.Windows.Forms.CheckBox()
        Me.chk_eisflag = New System.Windows.Forms.CheckBox()
        Me.chk_pcsflag = New System.Windows.Forms.CheckBox()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.tree_Review = New Syscom.Client.UCL.UCLTreeViewAdvUC()
        Me.UclDgv_Show = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_roleID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_roleName, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_RoleID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_roleName, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Confirm, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Cancel, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tree_Review, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.UclDgv_Show, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 641)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbl_roleID
        '
        Me.lbl_roleID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_roleID.AutoSize = True
        Me.lbl_roleID.Location = New System.Drawing.Point(19, 8)
        Me.lbl_roleID.Name = "lbl_roleID"
        Me.lbl_roleID.Size = New System.Drawing.Size(72, 16)
        Me.lbl_roleID.TabIndex = 0
        Me.lbl_roleID.Text = "角色代碼"
        '
        'lbl_roleName
        '
        Me.lbl_roleName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_roleName.AutoSize = True
        Me.lbl_roleName.Location = New System.Drawing.Point(251, 8)
        Me.lbl_roleName.Name = "lbl_roleName"
        Me.lbl_roleName.Size = New System.Drawing.Size(72, 16)
        Me.lbl_roleName.TabIndex = 1
        Me.lbl_roleName.Text = "角色名稱"
        '
        'txt_RoleID
        '
        Me.txt_RoleID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_RoleID.Location = New System.Drawing.Point(97, 2)
        Me.txt_RoleID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_RoleID.Name = "txt_RoleID"
        Me.txt_RoleID.ReadOnly = True
        Me.txt_RoleID.Size = New System.Drawing.Size(130, 27)
        Me.txt_RoleID.TabIndex = 2
        '
        'txt_roleName
        '
        Me.txt_roleName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_roleName.Location = New System.Drawing.Point(329, 2)
        Me.txt_roleName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_roleName.Name = "txt_roleName"
        Me.txt_roleName.ReadOnly = True
        Me.txt_roleName.Size = New System.Drawing.Size(135, 27)
        Me.txt_roleName.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(489, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "系統歸屬"
        Me.Label8.Visible = False
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.chk_opdflag)
        Me.FlowLayoutPanel3.Controls.Add(Me.chk_eisflag)
        Me.FlowLayoutPanel3.Controls.Add(Me.chk_pcsflag)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(567, 2)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(195, 24)
        Me.FlowLayoutPanel3.TabIndex = 8
        Me.FlowLayoutPanel3.Visible = False
        '
        'chk_opdflag
        '
        Me.chk_opdflag.AutoSize = True
        Me.chk_opdflag.Location = New System.Drawing.Point(3, 2)
        Me.chk_opdflag.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_opdflag.Name = "chk_opdflag"
        Me.chk_opdflag.Size = New System.Drawing.Size(59, 20)
        Me.chk_opdflag.TabIndex = 0
        Me.chk_opdflag.Text = "門診"
        Me.chk_opdflag.UseVisualStyleBackColor = True
        '
        'chk_eisflag
        '
        Me.chk_eisflag.AutoSize = True
        Me.chk_eisflag.Location = New System.Drawing.Point(68, 2)
        Me.chk_eisflag.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_eisflag.Name = "chk_eisflag"
        Me.chk_eisflag.Size = New System.Drawing.Size(59, 20)
        Me.chk_eisflag.TabIndex = 1
        Me.chk_eisflag.Text = "急診"
        Me.chk_eisflag.UseVisualStyleBackColor = True
        '
        'chk_pcsflag
        '
        Me.chk_pcsflag.AutoSize = True
        Me.chk_pcsflag.Location = New System.Drawing.Point(133, 2)
        Me.chk_pcsflag.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chk_pcsflag.Name = "chk_pcsflag"
        Me.chk_pcsflag.Size = New System.Drawing.Size(59, 20)
        Me.chk_pcsflag.TabIndex = 2
        Me.chk_pcsflag.Text = "住院"
        Me.chk_pcsflag.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(235, 611)
        Me.btn_Confirm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(70, 27)
        Me.btn_Confirm.TabIndex = 8
        Me.btn_Confirm.Text = "確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(329, 611)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(70, 27)
        Me.btn_Cancel.TabIndex = 9
        Me.btn_Cancel.Text = "取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'tree_Review
        '
        Me.tree_Review.AutoScroll = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.tree_Review, 3)
        Me.tree_Review.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tree_Review.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tree_Review.IsShowGroupCheckBox = False
        Me.tree_Review.Location = New System.Drawing.Point(4, 36)
        Me.tree_Review.Margin = New System.Windows.Forms.Padding(4)
        Me.tree_Review.Name = "tree_Review"
        Me.tree_Review.SelectedItemsResult = Nothing
        Me.tree_Review.SelectedResult = Nothing
        Me.tree_Review.SelectedTempItemsResult = Nothing
        Me.tree_Review.Size = New System.Drawing.Size(318, 569)
        Me.tree_Review.TabIndex = 10
        Me.tree_Review.TreeViewName = ""
        Me.tree_Review.TreeViewSource = Nothing
        '
        'UclDgv_Show
        '
        Me.UclDgv_Show.AllowUserToAddRows = False
        Me.UclDgv_Show.AllowUserToOrderColumns = False
        Me.UclDgv_Show.AllowUserToResizeColumns = True
        Me.UclDgv_Show.AllowUserToResizeRows = False
        Me.UclDgv_Show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDgv_Show.ColumnHeadersHeight = 4
        Me.UclDgv_Show.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.UclDgv_Show, 3)
        Me.UclDgv_Show.CurrentCell = Nothing
        Me.UclDgv_Show.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDgv_Show.DefaultCellStyle = DataGridViewCellStyle1
        Me.UclDgv_Show.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UclDgv_Show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDgv_Show.Location = New System.Drawing.Point(330, 36)
        Me.UclDgv_Show.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UclDgv_Show.MultiSelect = False
        Me.UclDgv_Show.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDgv_Show.Name = "UclDgv_Show"
        Me.UclDgv_Show.RowHeadersWidth = 41
        Me.UclDgv_Show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDgv_Show.Size = New System.Drawing.Size(630, 569)
        Me.UclDgv_Show.TabIndex = 11
        Me.UclDgv_Show.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.UclDgv_Show.uclBatchColIndex = ""
        Me.UclDgv_Show.uclClickToCheck = False
        Me.UclDgv_Show.uclColumnAlignment = ""
        Me.UclDgv_Show.uclColumnCheckBox = False
        Me.UclDgv_Show.uclColumnControlType = ""
        Me.UclDgv_Show.uclColumnWidth = ""
        Me.UclDgv_Show.uclDoCellEnter = True
        Me.UclDgv_Show.uclHasNewRow = False
        Me.UclDgv_Show.uclHeaderText = ""
        Me.UclDgv_Show.uclIsAlternatingRowsColors = True
        Me.UclDgv_Show.uclIsComboBoxGridQuery = True
        Me.UclDgv_Show.uclIsDoOrderCheck = True
        Me.UclDgv_Show.uclIsSortable = False
        Me.UclDgv_Show.uclMultiSelectShowCheckBoxHeader = True
        Me.UclDgv_Show.uclNonVisibleColIndex = ""
        Me.UclDgv_Show.uclReadOnly = False
        Me.UclDgv_Show.uclShowCellBorder = False
        Me.UclDgv_Show.uclSortColIndex = ""
        Me.UclDgv_Show.uclTreeMode = False
        Me.UclDgv_Show.uclVisibleColIndex = ""
        '
        'RoleRightsMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "RoleRightsMtnUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "角色權限維護"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_roleID As System.Windows.Forms.Label
    Friend WithEvents lbl_roleName As System.Windows.Forms.Label
    Friend WithEvents txt_RoleID As System.Windows.Forms.TextBox
    Friend WithEvents txt_roleName As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chk_opdflag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_eisflag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pcsflag As System.Windows.Forms.CheckBox
    Friend WithEvents tree_Review As Syscom.Client.UCL.UCLTreeViewAdvUC
    Friend WithEvents UclDgv_Show As Syscom.Client.UCL.UCLDataGridViewUC
End Class
