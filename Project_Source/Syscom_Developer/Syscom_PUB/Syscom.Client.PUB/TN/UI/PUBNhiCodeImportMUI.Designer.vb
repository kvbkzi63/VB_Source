<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBNhiCodeImportMUI
    Inherits Syscom.Client.UCL.BaseFormUI

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveMgr = Nothing '清除Event
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvLog = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_version = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ucldtp_effectdate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_insucode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Dtp_ExcelStart = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtp_ExcelEnd = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.UclExcelImportMUC1 = New Syscom.Client.UCL.UCLExcelImportUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_priceimport = New System.Windows.Forms.Button()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.lbl_UIMControl = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 383.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvLog, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_version, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Ucldtp_effectdate, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_insucode, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UclExcelImportMUC1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_UIMControl, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 621)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToOrderColumns = False
        Me.dgvLog.AllowUserToResizeColumns = True
        Me.dgvLog.AllowUserToResizeRows = False
        Me.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLog.ColumnHeadersHeight = 4
        Me.dgvLog.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvLog, 7)
        Me.dgvLog.CurrentCell = Nothing
        Me.dgvLog.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLog.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvLog.Location = New System.Drawing.Point(4, 84)
        Me.dgvLog.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvLog.MultiSelect = True
        Me.dgvLog.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.RowHeadersWidth = 41
        Me.dgvLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(960, 488)
        Me.dgvLog.TabIndex = 7
        Me.dgvLog.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvLog.uclBatchColIndex = ""
        Me.dgvLog.uclClickToCheck = False
        Me.dgvLog.uclColumnAlignment = ""
        Me.dgvLog.uclColumnCheckBox = True
        Me.dgvLog.uclColumnControlType = ""
        Me.dgvLog.uclColumnWidth = ""
        Me.dgvLog.uclDoCellEnter = True
        Me.dgvLog.uclHasNewRow = False
        Me.dgvLog.uclHeaderText = ""
        Me.dgvLog.uclIsAlternatingRowsColors = True
        Me.dgvLog.uclIsComboBoxGridQuery = True
        Me.dgvLog.uclIsComboxClickTriggerDropDown = False
        Me.dgvLog.uclIsDoOrderCheck = True
        Me.dgvLog.uclIsSortable = False
        Me.dgvLog.uclMultiSelectShowCheckBoxHeader = True
        Me.dgvLog.uclNonVisibleColIndex = ""
        Me.dgvLog.uclReadOnly = False
        Me.dgvLog.uclShowCellBorder = False
        Me.dgvLog.uclSortColIndex = ""
        Me.dgvLog.uclTreeMode = False
        Me.dgvLog.uclVisibleColIndex = ""
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "下載版本號"
        '
        'txt_version
        '
        Me.txt_version.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_version.Location = New System.Drawing.Point(100, 6)
        Me.txt_version.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_version.Name = "txt_version"
        Me.txt_version.Size = New System.Drawing.Size(120, 27)
        Me.txt_version.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(36, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "生效日"
        '
        'Ucldtp_effectdate
        '
        Me.Ucldtp_effectdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ucldtp_effectdate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.Ucldtp_effectdate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.Ucldtp_effectdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Ucldtp_effectdate.Location = New System.Drawing.Point(99, 46)
        Me.Ucldtp_effectdate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.Ucldtp_effectdate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.Ucldtp_effectdate.Name = "Ucldtp_effectdate"
        Me.Ucldtp_effectdate.Size = New System.Drawing.Size(122, 27)
        Me.Ucldtp_effectdate.TabIndex = 10
        Me.Ucldtp_effectdate.uclReadOnly = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(270, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "健保碼"
        '
        'txt_insucode
        '
        Me.txt_insucode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_insucode.Location = New System.Drawing.Point(334, 46)
        Me.txt_insucode.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_insucode.Name = "txt_insucode"
        Me.txt_insucode.Size = New System.Drawing.Size(206, 27)
        Me.txt_insucode.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Excel起訖日"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Dtp_ExcelStart)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Dtp_ExcelEnd)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(333, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(314, 34)
        Me.FlowLayoutPanel2.TabIndex = 12
        '
        'Dtp_ExcelStart
        '
        Me.Dtp_ExcelStart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Dtp_ExcelStart.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.Dtp_ExcelStart.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.Dtp_ExcelStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Dtp_ExcelStart.Location = New System.Drawing.Point(3, 3)
        Me.Dtp_ExcelStart.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.Dtp_ExcelStart.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.Dtp_ExcelStart.Name = "Dtp_ExcelStart"
        Me.Dtp_ExcelStart.Size = New System.Drawing.Size(132, 27)
        Me.Dtp_ExcelStart.TabIndex = 0
        Me.Dtp_ExcelStart.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "~"
        '
        'Dtp_ExcelEnd
        '
        Me.Dtp_ExcelEnd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Dtp_ExcelEnd.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.Dtp_ExcelEnd.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.Dtp_ExcelEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Dtp_ExcelEnd.Location = New System.Drawing.Point(163, 3)
        Me.Dtp_ExcelEnd.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.Dtp_ExcelEnd.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.Dtp_ExcelEnd.Name = "Dtp_ExcelEnd"
        Me.Dtp_ExcelEnd.Size = New System.Drawing.Size(132, 27)
        Me.Dtp_ExcelEnd.TabIndex = 2
        Me.Dtp_ExcelEnd.uclReadOnly = False
        '
        'UclExcelImportMUC1
        '
        Me.UclExcelImportMUC1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.UclExcelImportMUC1.GetincludeColumnHeaderBool = True
        Me.UclExcelImportMUC1.GetOutTableName = "excelData"
        Me.UclExcelImportMUC1.GetSheetIndex = "1"
        Me.UclExcelImportMUC1.Location = New System.Drawing.Point(717, 4)
        Me.UclExcelImportMUC1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclExcelImportMUC1.Name = "UclExcelImportMUC1"
        Me.UclExcelImportMUC1.Size = New System.Drawing.Size(95, 28)
        Me.UclExcelImportMUC1.TabIndex = 9
        '
        'FlowLayoutPanel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 3)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_export)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_priceimport)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_query)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(334, 580)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(455, 37)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'btn_clear
        '
        Me.btn_clear.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_clear.Location = New System.Drawing.Point(360, 4)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_clear.Size = New System.Drawing.Size(91, 30)
        Me.btn_clear.TabIndex = 3
        Me.btn_clear.Text = "清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_export.Location = New System.Drawing.Point(268, 4)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(84, 30)
        Me.btn_export.TabIndex = 2
        Me.btn_export.Text = "列印"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'btn_priceimport
        '
        Me.btn_priceimport.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_priceimport.Location = New System.Drawing.Point(108, 4)
        Me.btn_priceimport.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_priceimport.Name = "btn_priceimport"
        Me.btn_priceimport.Size = New System.Drawing.Size(152, 30)
        Me.btn_priceimport.TabIndex = 1
        Me.btn_priceimport.Text = "轉入衛材醫令價格檔"
        Me.btn_priceimport.UseVisualStyleBackColor = True
        '
        'btn_query
        '
        Me.btn_query.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_query.Location = New System.Drawing.Point(10, 4)
        Me.btn_query.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(90, 30)
        Me.btn_query.TabIndex = 0
        Me.btn_query.Text = "查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'lbl_UIMControl
        '
        Me.lbl_UIMControl.AutoSize = True
        Me.lbl_UIMControl.Location = New System.Drawing.Point(716, 40)
        Me.lbl_UIMControl.Name = "lbl_UIMControl"
        Me.lbl_UIMControl.Size = New System.Drawing.Size(118, 32)
        Me.lbl_UIMControl.TabIndex = 13
        Me.lbl_UIMControl.Text = "PUBNhiCodeImportMUI"
        Me.lbl_UIMControl.Visible = False
        '
        'PUBNhiCodeImportMUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 621)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBNhiCodeImportMUI"
        Me.TabText = "PUBNhiCodeImportMUI"
        Me.Text = "PUBNhiCodeImportMUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_version As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_insucode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvLog As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_priceimport As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents UclExcelImportMUC1 As Syscom.Client.UCL.UCLExcelImportUC
    Friend WithEvents Ucldtp_effectdate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Dtp_ExcelStart As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Dtp_ExcelEnd As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_UIMControl As System.Windows.Forms.Label
End Class
