<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLExportListUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbl_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_exportData = New System.Windows.Forms.Button()
        Me.btn_printData = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_ShowReport = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbl_Main
        '
        Me.tbl_Main.AutoSize = True
        Me.tbl_Main.ColumnCount = 1
        Me.tbl_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbl_Main.Location = New System.Drawing.Point(3, 3)
        Me.tbl_Main.MinimumSize = New System.Drawing.Size(0, 10)
        Me.tbl_Main.Name = "tbl_Main"
        Me.tbl_Main.RowCount = 1
        Me.tbl_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbl_Main.Size = New System.Drawing.Size(494, 10)
        Me.tbl_Main.TabIndex = 14
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_query)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_export)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_exportData)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_printData)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_clear)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 19)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(494, 42)
        Me.FlowLayoutPanel2.TabIndex = 15
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_query.Location = New System.Drawing.Point(3, 3)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(85, 35)
        Me.btn_query.TabIndex = 3
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_export.Location = New System.Drawing.Point(94, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(85, 35)
        Me.btn_export.TabIndex = 2
        Me.btn_export.Text = "F7-匯出"
        Me.btn_export.UseVisualStyleBackColor = True
        Me.btn_export.Visible = False
        '
        'btn_exportData
        '
        Me.btn_exportData.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_exportData.Location = New System.Drawing.Point(185, 3)
        Me.btn_exportData.Name = "btn_exportData"
        Me.btn_exportData.Size = New System.Drawing.Size(85, 35)
        Me.btn_exportData.TabIndex = 1
        Me.btn_exportData.Text = "匯出Calc"
        Me.btn_exportData.UseVisualStyleBackColor = True
        Me.btn_exportData.Visible = False
        '
        'btn_printData
        '
        Me.btn_printData.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_printData.Location = New System.Drawing.Point(276, 3)
        Me.btn_printData.Name = "btn_printData"
        Me.btn_printData.Size = New System.Drawing.Size(85, 35)
        Me.btn_printData.TabIndex = 0
        Me.btn_printData.Text = "列印"
        Me.btn_printData.UseVisualStyleBackColor = True
        Me.btn_printData.Visible = False
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(367, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(85, 35)
        Me.btn_clear.TabIndex = 4
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbl_Main, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_ShowReport, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(500, 300)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'dgv_ShowReport
        '
        Me.dgv_ShowReport.AllowUserToAddRows = False
        Me.dgv_ShowReport.AllowUserToOrderColumns = False
        Me.dgv_ShowReport.AllowUserToResizeColumns = True
        Me.dgv_ShowReport.AllowUserToResizeRows = False
        Me.dgv_ShowReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ShowReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ShowReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ShowReport.ColumnHeadersHeight = 4
        Me.dgv_ShowReport.ColumnHeadersVisible = True
        Me.dgv_ShowReport.CurrentCell = Nothing
        Me.dgv_ShowReport.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ShowReport.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ShowReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowReport.Location = New System.Drawing.Point(0, 64)
        Me.dgv_ShowReport.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_ShowReport.MultiSelect = False
        Me.dgv_ShowReport.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowReport.Name = "dgv_ShowReport"
        Me.dgv_ShowReport.RowHeadersWidth = 41
        Me.dgv_ShowReport.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ShowReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowReport.Size = New System.Drawing.Size(500, 236)
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
        Me.dgv_ShowReport.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ShowReport.uclIsDoOrderCheck = True
        Me.dgv_ShowReport.uclIsDoQueryComboBoxGrid = True
        Me.dgv_ShowReport.uclIsSortable = False
        Me.dgv_ShowReport.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowReport.uclNonVisibleColIndex = ""
        Me.dgv_ShowReport.uclReadOnly = False
        Me.dgv_ShowReport.uclSelectedCellBorder = False
        Me.dgv_ShowReport.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_ShowReport.uclSelectedCellBorderSize = 4
        Me.dgv_ShowReport.uclSelectedFirstShowCol = 0
        Me.dgv_ShowReport.uclSelectedLastShowCol = -1
        Me.dgv_ShowReport.uclShowCellBorder = False
        Me.dgv_ShowReport.uclSortColIndex = ""
        Me.dgv_ShowReport.uclTreeMode = False
        Me.dgv_ShowReport.uclVisibleColIndex = ""
        Me.dgv_ShowReport.Visible = False
        '
        'UCLExportListUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLExportListUC"
        Me.Size = New System.Drawing.Size(500, 300)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_exportData As System.Windows.Forms.Button
    Friend WithEvents btn_printData As System.Windows.Forms.Button
    Friend WithEvents dgv_ShowReport As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
