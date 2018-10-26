<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubExportSetupUI
    Inherits Syscom.Client.UCL.BaseFormUI

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbt_dcY = New System.Windows.Forms.RadioButton()
        Me.rbt_dcN = New System.Windows.Forms.RadioButton()
        Me.ucl_reportId = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_reportName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_connectionName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucl_reportSql = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.dgv_Export_detail = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.dgv_Export = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Footer1 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_Footer2 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tlp_Main.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 10
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label5, 0, 4)
        Me.tlp_Main.Controls.Add(Me.ucl_reportSql, 1, 4)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 4, 7)
        Me.tlp_Main.Controls.Add(Me.txt_Footer2, 4, 6)
        Me.tlp_Main.Controls.Add(Me.Label4, 5, 6)
        Me.tlp_Main.Controls.Add(Me.TableLayoutPanel2, 6, 6)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.ucl_reportId, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 2)
        Me.tlp_Main.Controls.Add(Me.ucl_reportName, 1, 1)
        Me.tlp_Main.Controls.Add(Me.ucl_connectionName, 1, 2)
        Me.tlp_Main.Controls.Add(Me.Label8, 3, 6)
        Me.tlp_Main.Controls.Add(Me.txt_Footer1, 1, 6)
        Me.tlp_Main.Controls.Add(Me.Label7, 0, 6)
        Me.tlp_Main.Controls.Add(Me.GroupBox1, 4, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 8
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.66929!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.80315!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.55716!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 432)
        Me.tlp_Main.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "報表SQL"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "* 報表代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "報表名稱"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "資料庫連線"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(491, 361)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "停用"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbt_dcY, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbt_dcN, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(537, 356)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(81, 27)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'rbt_dcY
        '
        Me.rbt_dcY.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_dcY.AutoSize = True
        Me.rbt_dcY.Location = New System.Drawing.Point(3, 3)
        Me.rbt_dcY.Name = "rbt_dcY"
        Me.rbt_dcY.Size = New System.Drawing.Size(34, 20)
        Me.rbt_dcY.TabIndex = 0
        Me.rbt_dcY.TabStop = True
        Me.rbt_dcY.Text = "是"
        Me.rbt_dcY.UseVisualStyleBackColor = True
        '
        'rbt_dcN
        '
        Me.rbt_dcN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_dcN.AutoSize = True
        Me.rbt_dcN.Location = New System.Drawing.Point(43, 3)
        Me.rbt_dcN.Name = "rbt_dcN"
        Me.rbt_dcN.Size = New System.Drawing.Size(35, 20)
        Me.rbt_dcN.TabIndex = 1
        Me.rbt_dcN.TabStop = True
        Me.rbt_dcN.Text = "否"
        Me.rbt_dcN.UseVisualStyleBackColor = True
        '
        'ucl_reportId
        '
        Me.ucl_reportId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.ucl_reportId, 3)
        Me.ucl_reportId.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_reportId.Location = New System.Drawing.Point(97, 3)
        Me.ucl_reportId.MaxLength = 50
        Me.ucl_reportId.Name = "ucl_reportId"
        Me.ucl_reportId.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_reportId.SelectionStart = 0
        Me.ucl_reportId.Size = New System.Drawing.Size(253, 27)
        Me.ucl_reportId.TabIndex = 5
        Me.ucl_reportId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_reportId.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_reportId.ToolTipTag = Nothing
        Me.ucl_reportId.uclDollarSign = False
        Me.ucl_reportId.uclDotCount = 0
        Me.ucl_reportId.uclIntCount = 2
        Me.ucl_reportId.uclMinus = False
        Me.ucl_reportId.uclReadOnly = False
        Me.ucl_reportId.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_reportId.uclTrimZero = True
        '
        'ucl_reportName
        '
        Me.ucl_reportName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.ucl_reportName, 3)
        Me.ucl_reportName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_reportName.Location = New System.Drawing.Point(97, 36)
        Me.ucl_reportName.MaxLength = 100
        Me.ucl_reportName.Name = "ucl_reportName"
        Me.ucl_reportName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_reportName.SelectionStart = 0
        Me.ucl_reportName.Size = New System.Drawing.Size(253, 27)
        Me.ucl_reportName.TabIndex = 6
        Me.ucl_reportName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_reportName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_reportName.ToolTipTag = Nothing
        Me.ucl_reportName.uclDollarSign = False
        Me.ucl_reportName.uclDotCount = 0
        Me.ucl_reportName.uclIntCount = 2
        Me.ucl_reportName.uclMinus = False
        Me.ucl_reportName.uclReadOnly = False
        Me.ucl_reportName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_reportName.uclTrimZero = True
        '
        'ucl_connectionName
        '
        Me.ucl_connectionName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.ucl_connectionName, 3)
        Me.ucl_connectionName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_connectionName.Location = New System.Drawing.Point(97, 69)
        Me.ucl_connectionName.MaxLength = 20
        Me.ucl_connectionName.Name = "ucl_connectionName"
        Me.ucl_connectionName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_connectionName.SelectionStart = 0
        Me.ucl_connectionName.Size = New System.Drawing.Size(253, 27)
        Me.ucl_connectionName.TabIndex = 7
        Me.ucl_connectionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_connectionName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_connectionName.ToolTipTag = Nothing
        Me.ucl_connectionName.uclDollarSign = False
        Me.ucl_connectionName.uclDotCount = 0
        Me.ucl_connectionName.uclIntCount = 2
        Me.ucl_connectionName.uclMinus = False
        Me.ucl_connectionName.uclReadOnly = False
        Me.ucl_connectionName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.ucl_connectionName.uclTrimZero = True
        '
        'ucl_reportSql
        '
        Me.tlp_Main.SetColumnSpan(Me.ucl_reportSql, 9)
        Me.ucl_reportSql.Location = New System.Drawing.Point(98, 219)
        Me.ucl_reportSql.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ucl_reportSql.Name = "ucl_reportSql"
        Me.tlp_Main.SetRowSpan(Me.ucl_reportSql, 2)
        Me.ucl_reportSql.Size = New System.Drawing.Size(862, 130)
        Me.ucl_reportSql.TabIndex = 11
        Me.ucl_reportSql.uclMaxLength = 4000
        Me.ucl_reportSql.uclReadOnly = False
        Me.ucl_reportSql.uclWordWrap = True
        '
        'dgv_Export_detail
        '
        Me.dgv_Export_detail.AllowUserToAddRows = True
        Me.dgv_Export_detail.AllowUserToOrderColumns = False
        Me.dgv_Export_detail.AllowUserToResizeColumns = True
        Me.dgv_Export_detail.AllowUserToResizeRows = False
        Me.dgv_Export_detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Export_detail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Export_detail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Export_detail.ColumnHeadersHeight = 4
        Me.dgv_Export_detail.ColumnHeadersVisible = True
        Me.dgv_Export_detail.CurrentCell = Nothing
        Me.dgv_Export_detail.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Export_detail.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Export_detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Export_detail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Export_detail.Location = New System.Drawing.Point(3, 23)
        Me.dgv_Export_detail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Export_detail.MultiSelect = False
        Me.dgv_Export_detail.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Export_detail.Name = "dgv_Export_detail"
        Me.dgv_Export_detail.RowHeadersWidth = 41
        Me.dgv_Export_detail.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Export_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Export_detail.Size = New System.Drawing.Size(599, 183)
        Me.dgv_Export_detail.TabIndex = 10
        Me.dgv_Export_detail.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Export_detail.uclBatchColIndex = ""
        Me.dgv_Export_detail.uclClickToCheck = False
        Me.dgv_Export_detail.uclColumnAlignment = ""
        Me.dgv_Export_detail.uclColumnCheckBox = True
        Me.dgv_Export_detail.uclColumnControlType = ""
        Me.dgv_Export_detail.uclColumnWidth = ""
        Me.dgv_Export_detail.uclDoCellEnter = True
        Me.dgv_Export_detail.uclHasNewRow = True
        Me.dgv_Export_detail.uclHeaderText = ""
        Me.dgv_Export_detail.uclIsAlternatingRowsColors = True
        Me.dgv_Export_detail.uclIsComboBoxGridQuery = True
        Me.dgv_Export_detail.uclIsComboxClickTriggerDropDown = False
        Me.dgv_Export_detail.uclIsDoOrderCheck = True
        Me.dgv_Export_detail.uclIsDoQueryComboBoxGrid = True
        Me.dgv_Export_detail.uclIsSortable = False
        Me.dgv_Export_detail.uclMultiSelectShowCheckBoxHeader = False
        Me.dgv_Export_detail.uclNonVisibleColIndex = ""
        Me.dgv_Export_detail.uclReadOnly = False
        Me.dgv_Export_detail.uclShowCellBorder = False
        Me.dgv_Export_detail.uclSortColIndex = ""
        Me.dgv_Export_detail.uclTreeMode = False
        Me.dgv_Export_detail.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel1
        '
        Me.tlp_Main.SetColumnSpan(Me.FlowLayoutPanel1, 6)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Update)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Insert)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(356, 389)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(604, 40)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Clear.Location = New System.Drawing.Point(526, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(75, 35)
        Me.btn_Clear.TabIndex = 12
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Query.Location = New System.Drawing.Point(445, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(75, 35)
        Me.btn_Query.TabIndex = 13
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Delete.Location = New System.Drawing.Point(351, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(88, 35)
        Me.btn_Delete.TabIndex = 14
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Update
        '
        Me.btn_Update.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Update.Location = New System.Drawing.Point(257, 3)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(88, 35)
        Me.btn_Update.TabIndex = 15
        Me.btn_Update.Text = "F10-修改"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_Insert
        '
        Me.btn_Insert.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Insert.Location = New System.Drawing.Point(170, 3)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(81, 35)
        Me.btn_Insert.TabIndex = 16
        Me.btn_Insert.Text = "F12-新增"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'dgv_Export
        '
        Me.dgv_Export.AllowUserToAddRows = False
        Me.dgv_Export.AllowUserToOrderColumns = False
        Me.dgv_Export.AllowUserToResizeColumns = True
        Me.dgv_Export.AllowUserToResizeRows = False
        Me.dgv_Export.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Export.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Export.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_Export.ColumnHeadersHeight = 4
        Me.dgv_Export.ColumnHeadersVisible = True
        Me.dgv_Export.CurrentCell = Nothing
        Me.dgv_Export.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Export.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_Export.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Export.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Export.Location = New System.Drawing.Point(0, 432)
        Me.dgv_Export.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Export.MultiSelect = False
        Me.dgv_Export.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Export.Name = "dgv_Export"
        Me.dgv_Export.RowHeadersWidth = 41
        Me.dgv_Export.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Export.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Export.Size = New System.Drawing.Size(964, 210)
        Me.dgv_Export.TabIndex = 1
        Me.dgv_Export.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Export.uclBatchColIndex = ""
        Me.dgv_Export.uclClickToCheck = False
        Me.dgv_Export.uclColumnAlignment = ""
        Me.dgv_Export.uclColumnCheckBox = False
        Me.dgv_Export.uclColumnControlType = ""
        Me.dgv_Export.uclColumnWidth = ""
        Me.dgv_Export.uclDoCellEnter = True
        Me.dgv_Export.uclHasNewRow = False
        Me.dgv_Export.uclHeaderText = ""
        Me.dgv_Export.uclIsAlternatingRowsColors = True
        Me.dgv_Export.uclIsComboBoxGridQuery = True
        Me.dgv_Export.uclIsComboxClickTriggerDropDown = False
        Me.dgv_Export.uclIsDoOrderCheck = True
        Me.dgv_Export.uclIsDoQueryComboBoxGrid = True
        Me.dgv_Export.uclIsSortable = False
        Me.dgv_Export.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Export.uclNonVisibleColIndex = ""
        Me.dgv_Export.uclReadOnly = False
        Me.dgv_Export.uclShowCellBorder = False
        Me.dgv_Export.uclSortColIndex = ""
        Me.dgv_Export.uclTreeMode = False
        Me.dgv_Export.uclVisibleColIndex = ""
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 361)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "表尾第一行"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(262, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "表尾第二行"
        '
        'txt_Footer1
        '
        Me.txt_Footer1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Footer1.Location = New System.Drawing.Point(97, 356)
        Me.txt_Footer1.MaxLength = 10
        Me.txt_Footer1.Name = "txt_Footer1"
        Me.txt_Footer1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Footer1.SelectionStart = 0
        Me.txt_Footer1.Size = New System.Drawing.Size(129, 27)
        Me.txt_Footer1.TabIndex = 14
        Me.txt_Footer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Footer1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Footer1.ToolTipTag = Nothing
        Me.txt_Footer1.uclDollarSign = False
        Me.txt_Footer1.uclDotCount = 0
        Me.txt_Footer1.uclIntCount = 2
        Me.txt_Footer1.uclMinus = False
        Me.txt_Footer1.uclReadOnly = False
        Me.txt_Footer1.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Footer1.uclTrimZero = True
        '
        'txt_Footer2
        '
        Me.txt_Footer2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Footer2.Location = New System.Drawing.Point(356, 356)
        Me.txt_Footer2.MaxLength = 10
        Me.txt_Footer2.Name = "txt_Footer2"
        Me.txt_Footer2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Footer2.SelectionStart = 0
        Me.txt_Footer2.Size = New System.Drawing.Size(129, 27)
        Me.txt_Footer2.TabIndex = 15
        Me.txt_Footer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Footer2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Footer2.ToolTipTag = Nothing
        Me.txt_Footer2.uclDollarSign = False
        Me.txt_Footer2.uclDotCount = 0
        Me.txt_Footer2.uclIntCount = 2
        Me.txt_Footer2.uclMinus = False
        Me.txt_Footer2.uclReadOnly = False
        Me.txt_Footer2.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Footer2.uclTrimZero = True
        '
        'GroupBox1
        '
        Me.tlp_Main.SetColumnSpan(Me.GroupBox1, 6)
        Me.GroupBox1.Controls.Add(Me.dgv_Export_detail)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(356, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.tlp_Main.SetRowSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(605, 209)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查詢條件與元件類型"
        '
        'PubExportSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.dgv_Export)
        Me.Controls.Add(Me.tlp_Main)
        Me.IsActiveAutoSize = False
        Me.Name = "PubExportSetupUI"
        Me.TabText = "PubExportSetupUI"
        Me.Text = "PubExportSetupUI"
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ucl_reportId As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_reportName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucl_connectionName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgv_Export_detail As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents ucl_reportSql As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents dgv_Export As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Update As System.Windows.Forms.Button
    Friend WithEvents btn_Insert As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbt_dcY As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_dcN As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_Footer2 As UCL.UCLTextBoxUC
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_Footer1 As UCL.UCLTextBoxUC
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
