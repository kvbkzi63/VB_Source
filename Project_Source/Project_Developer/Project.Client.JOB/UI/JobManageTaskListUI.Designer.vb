<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobManageTaskListUI
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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.UclDataGridViewUC1 = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UclDataGridViewUC1
        '
        Me.UclDataGridViewUC1.AllowUserToAddRows = False
        Me.UclDataGridViewUC1.AllowUserToOrderColumns = False
        Me.UclDataGridViewUC1.AllowUserToResizeColumns = True
        Me.UclDataGridViewUC1.AllowUserToResizeRows = False
        Me.UclDataGridViewUC1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUC1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UclDataGridViewUC1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.UclDataGridViewUC1.ColumnHeadersHeight = 4
        Me.UclDataGridViewUC1.ColumnHeadersVisible = True
        Me.UclDataGridViewUC1.CurrentCell = Nothing
        Me.UclDataGridViewUC1.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUC1.DefaultCellStyle = DataGridViewCellStyle2
        Me.UclDataGridViewUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UclDataGridViewUC1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUC1.Location = New System.Drawing.Point(0, 128)
        Me.UclDataGridViewUC1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UclDataGridViewUC1.MultiSelect = False
        Me.UclDataGridViewUC1.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUC1.Name = "UclDataGridViewUC1"
        Me.UclDataGridViewUC1.RowHeadersWidth = 41
        Me.UclDataGridViewUC1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.UclDataGridViewUC1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUC1.Size = New System.Drawing.Size(964, 513)
        Me.UclDataGridViewUC1.TabIndex = 0
        Me.UclDataGridViewUC1.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.UclDataGridViewUC1.uclBatchColIndex = ""
        Me.UclDataGridViewUC1.uclClickToCheck = False
        Me.UclDataGridViewUC1.uclColumnAlignment = ""
        Me.UclDataGridViewUC1.uclColumnCheckBox = False
        Me.UclDataGridViewUC1.uclColumnControlType = ""
        Me.UclDataGridViewUC1.uclColumnWidth = ""
        Me.UclDataGridViewUC1.uclDoCellEnter = True
        Me.UclDataGridViewUC1.uclHasNewRow = False
        Me.UclDataGridViewUC1.uclHeaderText = ""
        Me.UclDataGridViewUC1.uclIsAlternatingRowsColors = True
        Me.UclDataGridViewUC1.uclIsComboBoxGridQuery = True
        Me.UclDataGridViewUC1.uclIsComboxClickTriggerDropDown = False
        Me.UclDataGridViewUC1.uclIsDoOrderCheck = True
        Me.UclDataGridViewUC1.uclIsDoQueryComboBoxGrid = True
        Me.UclDataGridViewUC1.uclIsSortable = False
        Me.UclDataGridViewUC1.uclMultiSelectShowCheckBoxHeader = True
        Me.UclDataGridViewUC1.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUC1.uclReadOnly = False
        Me.UclDataGridViewUC1.uclShowCellBorder = False
        Me.UclDataGridViewUC1.uclSortColIndex = ""
        Me.UclDataGridViewUC1.uclTreeMode = False
        Me.UclDataGridViewUC1.uclVisibleColIndex = ""
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 82)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 82)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(964, 46)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(3, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 0
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'JobManageTaskListUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.UclDataGridViewUC1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "JobManageTaskListUI"
        Me.Text = "JobManageTaskListUI"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UclDataGridViewUC1 As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Query As Windows.Forms.Button
End Class
