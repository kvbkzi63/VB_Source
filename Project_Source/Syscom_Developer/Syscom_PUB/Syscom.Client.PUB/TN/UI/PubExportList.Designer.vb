<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubExportList
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbl_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.dgv_ShowReport = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbl_Main
        '
        Me.tbl_Main.AutoSize = True
        Me.tbl_Main.ColumnCount = 1
        Me.tbl_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbl_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbl_Main.Location = New System.Drawing.Point(0, 0)
        Me.tbl_Main.MinimumSize = New System.Drawing.Size(0, 10)
        Me.tbl_Main.Name = "tbl_Main"
        Me.tbl_Main.RowCount = 1
        Me.tbl_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbl_Main.Size = New System.Drawing.Size(964, 10)
        Me.tbl_Main.TabIndex = 14
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_query)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_export)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn4)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 10)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(964, 43)
        Me.FlowLayoutPanel2.TabIndex = 15
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_query.Location = New System.Drawing.Point(3, 3)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(85, 35)
        Me.btn_query.TabIndex = 3
        Me.btn_query.Text = "查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_export.Location = New System.Drawing.Point(94, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(85, 35)
        Me.btn_export.TabIndex = 2
        Me.btn_export.Text = "匯出Excel"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button2.Location = New System.Drawing.Point(185, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "匯出Calc"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btn4
        '
        Me.btn4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn4.Location = New System.Drawing.Point(276, 3)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(85, 35)
        Me.btn4.TabIndex = 0
        Me.btn4.Text = "列印"
        Me.btn4.UseVisualStyleBackColor = True
        Me.btn4.Visible = False
        '
        'dgv_ShowReport
        '
        Me.dgv_ShowReport.AllowUserToAddRows = False
        Me.dgv_ShowReport.AllowUserToOrderColumns = False
        Me.dgv_ShowReport.AllowUserToResizeColumns = True
        Me.dgv_ShowReport.AllowUserToResizeRows = False
        Me.dgv_ShowReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ShowReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.dgv_ShowReport.ColumnHeadersHeight = 4
        Me.dgv_ShowReport.ColumnHeadersVisible = True
        Me.dgv_ShowReport.CurrentCell = Nothing
        Me.dgv_ShowReport.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ShowReport.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ShowReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowReport.Location = New System.Drawing.Point(0, 53)
        Me.dgv_ShowReport.Margin = New System.Windows.Forms.Padding(21, 12, 21, 12)
        Me.dgv_ShowReport.MultiSelect = False
        Me.dgv_ShowReport.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowReport.Name = "dgv_ShowReport"
        Me.dgv_ShowReport.RowHeadersWidth = 41
        Me.dgv_ShowReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowReport.Size = New System.Drawing.Size(964, 589)
        Me.dgv_ShowReport.TabIndex = 16
        Me.dgv_ShowReport.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_ShowReport.uclBatchColIndex = ""
        Me.dgv_ShowReport.uclClickToCheck = False
        Me.dgv_ShowReport.uclColumnAlignment = ""
        Me.dgv_ShowReport.uclColumnCheckBox = False
        Me.dgv_ShowReport.uclColumnControlType = ""
        Me.dgv_ShowReport.uclColumnWidth = ""
        Me.dgv_ShowReport.uclDoCellEnter = True
        Me.dgv_ShowReport.uclHasNewRow = False
        Me.dgv_ShowReport.uclHeaderText = ""
        Me.dgv_ShowReport.uclIsAlternatingRowsColors = True
        Me.dgv_ShowReport.uclIsComboBoxGridQuery = True
        Me.dgv_ShowReport.uclIsDoOrderCheck = True
        Me.dgv_ShowReport.uclIsSortable = False
        Me.dgv_ShowReport.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowReport.uclNonVisibleColIndex = ""
        Me.dgv_ShowReport.uclReadOnly = False
        Me.dgv_ShowReport.uclShowCellBorder = False
        Me.dgv_ShowReport.uclSortColIndex = ""
        Me.dgv_ShowReport.uclTreeMode = False
        Me.dgv_ShowReport.uclVisibleColIndex = ""
        Me.dgv_ShowReport.Visible = False
        '
        'PubExportList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.dgv_ShowReport)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.tbl_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PubExportList"
        Me.Text = "PubExportList"
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbl_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents dgv_ShowReport As Syscom.Client.UCL.UCLDataGridViewUC
End Class
