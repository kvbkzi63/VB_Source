<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FunSystemMtnUIMult

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FunSystemMtnUIMult))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_Data = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_AppSystem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cbo_SubSystem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_TskSystem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 642)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_Data, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'dgv_Data
        '
        Me.dgv_Data.AllowUserToAddRows = False
        Me.dgv_Data.AllowUserToOrderColumns = False
        Me.dgv_Data.AllowUserToResizeColumns = True
        Me.dgv_Data.AllowUserToResizeRows = False
        Me.dgv_Data.AutoSize = True
        Me.dgv_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Data.ColumnHeadersHeight = 4
        Me.dgv_Data.ColumnHeadersVisible = True
        Me.dgv_Data.CurrentCell = Nothing
        Me.dgv_Data.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Data.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Data.Location = New System.Drawing.Point(9, 117)
        Me.dgv_Data.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.dgv_Data.MultiSelect = True
        Me.dgv_Data.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.RowHeadersWidth = 41
        Me.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Data.Size = New System.Drawing.Size(946, 518)
        Me.dgv_Data.TabIndex = 5
        Me.dgv_Data.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Data.uclBatchColIndex = ""
        Me.dgv_Data.uclClickToCheck = False
        Me.dgv_Data.uclColumnAlignment = ""
        Me.dgv_Data.uclColumnCheckBox = True
        Me.dgv_Data.uclColumnControlType = ""
        Me.dgv_Data.uclColumnWidth = ""
        Me.dgv_Data.uclDoCellEnter = True
        Me.dgv_Data.uclHasNewRow = True
        Me.dgv_Data.uclHeaderText = ""
        Me.dgv_Data.uclIsAlternatingRowsColors = True
        Me.dgv_Data.uclIsComboBoxGridQuery = True
        Me.dgv_Data.uclIsDoOrderCheck = True
        Me.dgv_Data.uclIsSortable = False
        Me.dgv_Data.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Data.uclNonVisibleColIndex = ""
        Me.dgv_Data.uclReadOnly = False
        Me.dgv_Data.uclShowCellBorder = False
        Me.dgv_Data.uclSortColIndex = ""
        Me.dgv_Data.uclTreeMode = False
        Me.dgv_Data.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Save)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 73)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(958, 34)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Location = New System.Drawing.Point(865, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 4
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Query.Location = New System.Drawing.Point(769, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 3
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Delete.Location = New System.Drawing.Point(673, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_Delete.TabIndex = 2
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Save.Location = New System.Drawing.Point(578, 3)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(89, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 471.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_AppSystem, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_SubSystem, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_TskSystem, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(958, 64)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'cbo_AppSystem
        '
        Me.cbo_AppSystem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_AppSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_AppSystem.DropDownWidth = 20
        Me.cbo_AppSystem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_AppSystem.Location = New System.Drawing.Point(107, 4)
        Me.cbo_AppSystem.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_AppSystem.Name = "cbo_AppSystem"
        Me.cbo_AppSystem.SelectedIndex = -1
        Me.cbo_AppSystem.SelectedItem = Nothing
        Me.cbo_AppSystem.SelectedText = ""
        Me.cbo_AppSystem.SelectedValue = ""
        Me.cbo_AppSystem.SelectionStart = 0
        Me.cbo_AppSystem.Size = New System.Drawing.Size(247, 24)
        Me.cbo_AppSystem.TabIndex = 0
        Me.cbo_AppSystem.uclDisplayIndex = "0,1"
        Me.cbo_AppSystem.uclIsAutoClear = True
        Me.cbo_AppSystem.uclIsFirstItemEmpty = True
        Me.cbo_AppSystem.uclIsTextMode = False
        Me.cbo_AppSystem.uclShowMsg = False
        Me.cbo_AppSystem.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "系統代碼"
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(396, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(88, 16)
        Me.label2.TabIndex = 2
        Me.label2.Text = "子系統代碼"
        '
        'cbo_SubSystem
        '
        Me.cbo_SubSystem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SubSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SubSystem.DropDownWidth = 20
        Me.cbo_SubSystem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SubSystem.Location = New System.Drawing.Point(487, 4)
        Me.cbo_SubSystem.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SubSystem.Name = "cbo_SubSystem"
        Me.cbo_SubSystem.SelectedIndex = -1
        Me.cbo_SubSystem.SelectedItem = Nothing
        Me.cbo_SubSystem.SelectedText = ""
        Me.cbo_SubSystem.SelectedValue = ""
        Me.cbo_SubSystem.SelectionStart = 0
        Me.cbo_SubSystem.Size = New System.Drawing.Size(288, 24)
        Me.cbo_SubSystem.TabIndex = 3
        Me.cbo_SubSystem.uclDisplayIndex = "0,1"
        Me.cbo_SubSystem.uclIsAutoClear = True
        Me.cbo_SubSystem.uclIsFirstItemEmpty = True
        Me.cbo_SubSystem.uclIsTextMode = False
        Me.cbo_SubSystem.uclShowMsg = False
        Me.cbo_SubSystem.uclValueIndex = "0"
        '
        'cbo_TskSystem
        '
        Me.cbo_TskSystem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_TskSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_TskSystem.DropDownWidth = 20
        Me.cbo_TskSystem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_TskSystem.Location = New System.Drawing.Point(107, 36)
        Me.cbo_TskSystem.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_TskSystem.Name = "cbo_TskSystem"
        Me.cbo_TskSystem.SelectedIndex = -1
        Me.cbo_TskSystem.SelectedItem = Nothing
        Me.cbo_TskSystem.SelectedText = ""
        Me.cbo_TskSystem.SelectedValue = ""
        Me.cbo_TskSystem.SelectionStart = 0
        Me.cbo_TskSystem.Size = New System.Drawing.Size(247, 24)
        Me.cbo_TskSystem.TabIndex = 4
        Me.cbo_TskSystem.uclDisplayIndex = "0,1"
        Me.cbo_TskSystem.uclIsAutoClear = True
        Me.cbo_TskSystem.uclIsFirstItemEmpty = True
        Me.cbo_TskSystem.uclIsTextMode = False
        Me.cbo_TskSystem.uclShowMsg = False
        Me.cbo_TskSystem.uclValueIndex = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "作業代碼"
        '
        'FunSystemMtnUIMult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "FunSystemMtnUIMult"
        Me.TabText = "作業維護"
        Me.Text = "作業維護"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_Data As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbo_AppSystem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_SubSystem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_TskSystem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
