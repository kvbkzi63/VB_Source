<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBExcludeDrugSetUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gb_parent = New System.Windows.Forms.GroupBox
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_dgv_list = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
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
        Me.tlp_frame.Controls.Add(Me.ucl_dgv_list, 0, 0)
        Me.tlp_frame.Controls.Add(Me.btn_confirm, 0, 1)
        Me.tlp_frame.Location = New System.Drawing.Point(4, 14)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 2
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.76384!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23616!))
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
        Me.ucl_dgv_list.Location = New System.Drawing.Point(4, 4)
        Me.ucl_dgv_list.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_list.MultiSelect = True
        Me.ucl_dgv_list.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_list.Name = "ucl_dgv_list"
        Me.ucl_dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ucl_dgv_list.Size = New System.Drawing.Size(423, 253)
        Me.ucl_dgv_list.TabIndex = 0
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
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(338, 273)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 2
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'PUBExclusiveDrugUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 326)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBExclusiveDrugUI"
        Me.TabText = "排除藥費-不算入計算總額或醫師藥費"
        Me.Text = "排除藥費-不算入計算總額或醫師藥費"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_dgv_list As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
End Class
