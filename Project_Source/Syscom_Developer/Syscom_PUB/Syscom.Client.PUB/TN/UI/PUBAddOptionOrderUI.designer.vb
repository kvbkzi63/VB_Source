<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAddOptionOrderUI
    Inherits Syscom.Client.UCL.BaseFormUI
    'Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveComboBoxGridMgr = Nothing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gb_parent = New System.Windows.Forms.GroupBox
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_dgv_list = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.tlp_cond = New System.Windows.Forms.TableLayoutPanel
        Me.lb_original_order = New System.Windows.Forms.Label
        Me.ucl_txt_original_order = New System.Windows.Forms.TextBox
        Me.tlp_button = New System.Windows.Forms.TableLayoutPanel
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_newrow = New System.Windows.Forms.Button
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
        Me.tlp_cond.SuspendLayout()
        Me.tlp_button.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_frame)
        Me.gb_parent.Location = New System.Drawing.Point(2, -6)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(438, 330)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_frame.Controls.Add(Me.ucl_dgv_list, 0, 1)
        Me.tlp_frame.Controls.Add(Me.tlp_cond, 0, 0)
        Me.tlp_frame.Controls.Add(Me.tlp_button, 0, 2)
        Me.tlp_frame.Location = New System.Drawing.Point(4, 14)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 3
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.1512!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.8488!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_frame.Size = New System.Drawing.Size(431, 312)
        Me.tlp_frame.TabIndex = 0
        '
        'ucl_dgv_list
        '
        Me.ucl_dgv_list.AllowUserToAddRows = False
        Me.ucl_dgv_list.AllowUserToOrderColumns = False
        Me.ucl_dgv_list.AllowUserToResizeColumns = True
        Me.ucl_dgv_list.AllowUserToResizeRows = False
        Me.ucl_dgv_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucl_dgv_list.ColumnHeadersVisible = True
        Me.ucl_dgv_list.CurrentCell = Nothing
        Me.ucl_dgv_list.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_list.DefaultCellStyle = DataGridViewCellStyle1
        Me.ucl_dgv_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_list.Location = New System.Drawing.Point(4, 47)
        Me.ucl_dgv_list.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_list.MultiSelect = True
        Me.ucl_dgv_list.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_list.Name = "ucl_dgv_list"
        Me.ucl_dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ucl_dgv_list.Size = New System.Drawing.Size(423, 219)
        Me.ucl_dgv_list.TabIndex = 999
        Me.ucl_dgv_list.uclColumnAlignment = ""
        Me.ucl_dgv_list.uclColumnCheckBox = True
        Me.ucl_dgv_list.uclColumnControlType = ""
        Me.ucl_dgv_list.uclColumnWidth = ""
        Me.ucl_dgv_list.uclHasNewRow = False
        Me.ucl_dgv_list.uclHeaderText = ""
        Me.ucl_dgv_list.uclNonVisibleColIndex = ""
        Me.ucl_dgv_list.uclReadOnly = False
        Me.ucl_dgv_list.uclShowCellBorder = False
        Me.ucl_dgv_list.uclSortColIndex = ""
        Me.ucl_dgv_list.uclTreeMode = False
        Me.ucl_dgv_list.uclVisibleColIndex = ""
        '
        'tlp_cond
        '
        Me.tlp_cond.ColumnCount = 2
        Me.tlp_cond.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.29412!))
        Me.tlp_cond.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.70588!))
        Me.tlp_cond.Controls.Add(Me.lb_original_order, 0, 0)
        Me.tlp_cond.Controls.Add(Me.ucl_txt_original_order, 1, 0)
        Me.tlp_cond.Location = New System.Drawing.Point(3, 3)
        Me.tlp_cond.Name = "tlp_cond"
        Me.tlp_cond.RowCount = 1
        Me.tlp_cond.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_cond.Size = New System.Drawing.Size(425, 37)
        Me.tlp_cond.TabIndex = 3
        '
        'lb_original_order
        '
        Me.lb_original_order.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_original_order.AutoSize = True
        Me.lb_original_order.Location = New System.Drawing.Point(24, 10)
        Me.lb_original_order.Name = "lb_original_order"
        Me.lb_original_order.Size = New System.Drawing.Size(72, 16)
        Me.lb_original_order.TabIndex = 998
        Me.lb_original_order.Text = "原醫令碼"
        '
        'ucl_txt_original_order
        '
        Me.ucl_txt_original_order.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_original_order.Location = New System.Drawing.Point(102, 5)
        Me.ucl_txt_original_order.Name = "ucl_txt_original_order"
        Me.ucl_txt_original_order.Size = New System.Drawing.Size(120, 27)
        Me.ucl_txt_original_order.TabIndex = 0
        '
        'tlp_button
        '
        Me.tlp_button.ColumnCount = 3
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.94846!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.05155!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.tlp_button.Controls.Add(Me.btn_delete, 2, 0)
        Me.tlp_button.Controls.Add(Me.btn_confirm, 1, 0)
        Me.tlp_button.Controls.Add(Me.btn_newrow, 0, 0)
        Me.tlp_button.Location = New System.Drawing.Point(3, 274)
        Me.tlp_button.Name = "tlp_button"
        Me.tlp_button.RowCount = 1
        Me.tlp_button.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_button.Size = New System.Drawing.Size(425, 35)
        Me.tlp_button.TabIndex = 4
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(200, 4)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 1
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_delete.Location = New System.Drawing.Point(303, 4)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(119, 27)
        Me.btn_delete.TabIndex = 2
        Me.btn_delete.Text = "SF-12刪除醫令"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_newrow
        '
        Me.btn_newrow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_newrow.Location = New System.Drawing.Point(97, 4)
        Me.btn_newrow.Name = "btn_newrow"
        Me.btn_newrow.Size = New System.Drawing.Size(90, 27)
        Me.btn_newrow.TabIndex = 3
        Me.btn_newrow.Text = "新增表列"
        Me.btn_newrow.UseVisualStyleBackColor = True
        '
        'PUBGroupOrderAlterUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 326)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBGroupOrderAlterUI"
        Me.TabText = "群組醫令明細替代檔"
        Me.Text = "群組醫令明細替代檔"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.tlp_cond.ResumeLayout(False)
        Me.tlp_cond.PerformLayout()
        Me.tlp_button.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_dgv_list As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents tlp_cond As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_original_order As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_original_order As System.Windows.Forms.TextBox
    Friend WithEvents tlp_button As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_newrow As System.Windows.Forms.Button
End Class
