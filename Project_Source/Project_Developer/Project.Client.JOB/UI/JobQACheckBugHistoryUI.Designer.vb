<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobQACheckBugHistoryUI
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobQACheckBugHistoryUI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Ver = New System.Windows.Forms.Label()
        Me.lbl_BugId = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.JobQACreateNewJobUC1 = New Project.Client.JOB.JobQACreateNewBugUC()
        Me.gb_SDRemark = New System.Windows.Forms.GroupBox()
        Me.dgv_SDRemark = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.gb_PGRemark = New System.Windows.Forms.GroupBox()
        Me.dgv_PGRemark = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.gb_SARemark = New System.Windows.Forms.GroupBox()
        Me.dgv_SARemark = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_RetestVer = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_RetestResult = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.dtp_RetestDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rtb_Note = New System.Windows.Forms.RichTextBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gb_SDRemark.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.gb_PGRemark.SuspendLayout()
        Me.gb_SARemark.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_Ver)
        Me.Panel1.Controls.Add(Me.lbl_BugId)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 41)
        Me.Panel1.TabIndex = 0
        '
        'lbl_Ver
        '
        Me.lbl_Ver.AutoSize = True
        Me.lbl_Ver.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_Ver.Location = New System.Drawing.Point(595, 9)
        Me.lbl_Ver.Name = "lbl_Ver"
        Me.lbl_Ver.Size = New System.Drawing.Size(57, 16)
        Me.lbl_Ver.TabIndex = 3
        Me.lbl_Ver.Text = "Label8"
        '
        'lbl_BugId
        '
        Me.lbl_BugId.AutoSize = True
        Me.lbl_BugId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_BugId.Location = New System.Drawing.Point(96, 9)
        Me.lbl_BugId.Name = "lbl_BugId"
        Me.lbl_BugId.Size = New System.Drawing.Size(57, 16)
        Me.lbl_BugId.TabIndex = 2
        Me.lbl_BugId.Text = "Label7"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(516, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "測得版次"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BUG ID"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.JobQACreateNewJobUC1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(958, 486)
        Me.Panel2.TabIndex = 1
        '
        'JobQACreateNewJobUC1
        '
        Me.JobQACreateNewJobUC1.Bug_Id = Nothing
        Me.JobQACreateNewJobUC1.BugStatus = ""
        Me.JobQACreateNewJobUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JobQACreateNewJobUC1.Location = New System.Drawing.Point(0, 0)
        Me.JobQACreateNewJobUC1.Margin = New System.Windows.Forms.Padding(4)
        Me.JobQACreateNewJobUC1.Name = "JobQACreateNewJobUC1"
        Me.JobQACreateNewJobUC1.Project_Id = Nothing
        Me.JobQACreateNewJobUC1.Size = New System.Drawing.Size(958, 486)
        Me.JobQACreateNewJobUC1.TabIndex = 0
        Me.JobQACreateNewJobUC1.Ver_Id = Nothing
        '
        'gb_SDRemark
        '
        Me.tlp_Main.SetColumnSpan(Me.gb_SDRemark, 3)
        Me.gb_SDRemark.Controls.Add(Me.dgv_SDRemark)
        Me.gb_SDRemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_SDRemark.Location = New System.Drawing.Point(3, 3)
        Me.gb_SDRemark.Name = "gb_SDRemark"
        Me.gb_SDRemark.Size = New System.Drawing.Size(475, 100)
        Me.gb_SDRemark.TabIndex = 2
        Me.gb_SDRemark.TabStop = False
        Me.gb_SDRemark.Text = "SD註記"
        '
        'dgv_SDRemark
        '
        Me.dgv_SDRemark.AllowUserToAddRows = False
        Me.dgv_SDRemark.AllowUserToOrderColumns = False
        Me.dgv_SDRemark.AllowUserToResizeColumns = True
        Me.dgv_SDRemark.AllowUserToResizeRows = False
        Me.dgv_SDRemark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_SDRemark.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SDRemark.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_SDRemark.ColumnHeadersHeight = 4
        Me.dgv_SDRemark.ColumnHeadersVisible = True
        Me.dgv_SDRemark.CurrentCell = Nothing
        Me.dgv_SDRemark.DataSource = Nothing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SDRemark.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_SDRemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SDRemark.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SDRemark.Location = New System.Drawing.Point(3, 23)
        Me.dgv_SDRemark.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_SDRemark.MultiSelect = False
        Me.dgv_SDRemark.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SDRemark.Name = "dgv_SDRemark"
        Me.dgv_SDRemark.RowHeadersWidth = 41
        Me.dgv_SDRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SDRemark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SDRemark.Size = New System.Drawing.Size(469, 74)
        Me.dgv_SDRemark.TabIndex = 0
        Me.dgv_SDRemark.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SDRemark.uclBatchColIndex = ""
        Me.dgv_SDRemark.uclClickToCheck = False
        Me.dgv_SDRemark.uclColumnAlignment = ""
        Me.dgv_SDRemark.uclColumnCheckBox = False
        Me.dgv_SDRemark.uclColumnControlType = ""
        Me.dgv_SDRemark.uclColumnWidth = ""
        Me.dgv_SDRemark.uclDoCellEnter = True
        Me.dgv_SDRemark.uclHasNewRow = False
        Me.dgv_SDRemark.uclHeaderText = ""
        Me.dgv_SDRemark.uclIsAlternatingRowsColors = True
        Me.dgv_SDRemark.uclIsComboBoxGridQuery = True
        Me.dgv_SDRemark.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SDRemark.uclIsDoOrderCheck = True
        Me.dgv_SDRemark.uclIsDoQueryComboBoxGrid = True
        Me.dgv_SDRemark.uclIsSortable = False
        Me.dgv_SDRemark.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SDRemark.uclNonVisibleColIndex = ""
        Me.dgv_SDRemark.uclReadOnly = False
        Me.dgv_SDRemark.uclShowCellBorder = False
        Me.dgv_SDRemark.uclSortColIndex = ""
        Me.dgv_SDRemark.uclTreeMode = False
        Me.dgv_SDRemark.uclVisibleColIndex = ""
        '
        'tlp_Main
        '
        Me.tlp_Main.AutoScroll = True
        Me.tlp_Main.ColumnCount = 5
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.gb_PGRemark, 0, 1)
        Me.tlp_Main.Controls.Add(Me.gb_SDRemark, 0, 0)
        Me.tlp_Main.Controls.Add(Me.gb_SARemark, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 2)
        Me.tlp_Main.Controls.Add(Me.txt_RetestVer, 1, 2)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 3)
        Me.tlp_Main.Controls.Add(Me.Label5, 2, 2)
        Me.tlp_Main.Controls.Add(Me.cbo_RetestResult, 1, 3)
        Me.tlp_Main.Controls.Add(Me.dtp_RetestDate, 3, 2)
        Me.tlp_Main.Controls.Add(Me.Label6, 0, 4)
        Me.tlp_Main.Controls.Add(Me.rtb_Note, 1, 4)
        Me.tlp_Main.Controls.Add(Me.btn_Save, 3, 4)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Main.Location = New System.Drawing.Point(0, 527)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 7
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(958, 381)
        Me.tlp_Main.TabIndex = 3
        '
        'gb_PGRemark
        '
        Me.tlp_Main.SetColumnSpan(Me.gb_PGRemark, 3)
        Me.gb_PGRemark.Controls.Add(Me.dgv_PGRemark)
        Me.gb_PGRemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_PGRemark.Location = New System.Drawing.Point(3, 109)
        Me.gb_PGRemark.Name = "gb_PGRemark"
        Me.gb_PGRemark.Size = New System.Drawing.Size(475, 100)
        Me.gb_PGRemark.TabIndex = 4
        Me.gb_PGRemark.TabStop = False
        Me.gb_PGRemark.Text = "PG註記"
        '
        'dgv_PGRemark
        '
        Me.dgv_PGRemark.AllowUserToAddRows = False
        Me.dgv_PGRemark.AllowUserToOrderColumns = False
        Me.dgv_PGRemark.AllowUserToResizeColumns = True
        Me.dgv_PGRemark.AllowUserToResizeRows = False
        Me.dgv_PGRemark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_PGRemark.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_PGRemark.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_PGRemark.ColumnHeadersHeight = 4
        Me.dgv_PGRemark.ColumnHeadersVisible = True
        Me.dgv_PGRemark.CurrentCell = Nothing
        Me.dgv_PGRemark.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_PGRemark.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_PGRemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_PGRemark.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_PGRemark.Location = New System.Drawing.Point(3, 23)
        Me.dgv_PGRemark.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_PGRemark.MultiSelect = False
        Me.dgv_PGRemark.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_PGRemark.Name = "dgv_PGRemark"
        Me.dgv_PGRemark.RowHeadersWidth = 41
        Me.dgv_PGRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_PGRemark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_PGRemark.Size = New System.Drawing.Size(469, 74)
        Me.dgv_PGRemark.TabIndex = 0
        Me.dgv_PGRemark.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_PGRemark.uclBatchColIndex = ""
        Me.dgv_PGRemark.uclClickToCheck = False
        Me.dgv_PGRemark.uclColumnAlignment = ""
        Me.dgv_PGRemark.uclColumnCheckBox = False
        Me.dgv_PGRemark.uclColumnControlType = ""
        Me.dgv_PGRemark.uclColumnWidth = ""
        Me.dgv_PGRemark.uclDoCellEnter = True
        Me.dgv_PGRemark.uclHasNewRow = False
        Me.dgv_PGRemark.uclHeaderText = ""
        Me.dgv_PGRemark.uclIsAlternatingRowsColors = True
        Me.dgv_PGRemark.uclIsComboBoxGridQuery = True
        Me.dgv_PGRemark.uclIsComboxClickTriggerDropDown = False
        Me.dgv_PGRemark.uclIsDoOrderCheck = True
        Me.dgv_PGRemark.uclIsDoQueryComboBoxGrid = True
        Me.dgv_PGRemark.uclIsSortable = False
        Me.dgv_PGRemark.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_PGRemark.uclNonVisibleColIndex = ""
        Me.dgv_PGRemark.uclReadOnly = False
        Me.dgv_PGRemark.uclShowCellBorder = False
        Me.dgv_PGRemark.uclSortColIndex = ""
        Me.dgv_PGRemark.uclTreeMode = False
        Me.dgv_PGRemark.uclVisibleColIndex = ""
        '
        'gb_SARemark
        '
        Me.tlp_Main.SetColumnSpan(Me.gb_SARemark, 2)
        Me.gb_SARemark.Controls.Add(Me.dgv_SARemark)
        Me.gb_SARemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_SARemark.Location = New System.Drawing.Point(484, 3)
        Me.gb_SARemark.Name = "gb_SARemark"
        Me.gb_SARemark.Size = New System.Drawing.Size(475, 100)
        Me.gb_SARemark.TabIndex = 3
        Me.gb_SARemark.TabStop = False
        Me.gb_SARemark.Text = "SA註記"
        '
        'dgv_SARemark
        '
        Me.dgv_SARemark.AllowUserToAddRows = False
        Me.dgv_SARemark.AllowUserToOrderColumns = False
        Me.dgv_SARemark.AllowUserToResizeColumns = True
        Me.dgv_SARemark.AllowUserToResizeRows = False
        Me.dgv_SARemark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_SARemark.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SARemark.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_SARemark.ColumnHeadersHeight = 4
        Me.dgv_SARemark.ColumnHeadersVisible = True
        Me.dgv_SARemark.CurrentCell = Nothing
        Me.dgv_SARemark.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SARemark.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_SARemark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SARemark.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SARemark.Location = New System.Drawing.Point(3, 23)
        Me.dgv_SARemark.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_SARemark.MultiSelect = False
        Me.dgv_SARemark.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SARemark.Name = "dgv_SARemark"
        Me.dgv_SARemark.RowHeadersWidth = 41
        Me.dgv_SARemark.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SARemark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SARemark.Size = New System.Drawing.Size(469, 74)
        Me.dgv_SARemark.TabIndex = 0
        Me.dgv_SARemark.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SARemark.uclBatchColIndex = ""
        Me.dgv_SARemark.uclClickToCheck = False
        Me.dgv_SARemark.uclColumnAlignment = ""
        Me.dgv_SARemark.uclColumnCheckBox = False
        Me.dgv_SARemark.uclColumnControlType = ""
        Me.dgv_SARemark.uclColumnWidth = ""
        Me.dgv_SARemark.uclDoCellEnter = True
        Me.dgv_SARemark.uclHasNewRow = False
        Me.dgv_SARemark.uclHeaderText = ""
        Me.dgv_SARemark.uclIsAlternatingRowsColors = True
        Me.dgv_SARemark.uclIsComboBoxGridQuery = True
        Me.dgv_SARemark.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SARemark.uclIsDoOrderCheck = True
        Me.dgv_SARemark.uclIsDoQueryComboBoxGrid = True
        Me.dgv_SARemark.uclIsSortable = False
        Me.dgv_SARemark.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SARemark.uclNonVisibleColIndex = ""
        Me.dgv_SARemark.uclReadOnly = False
        Me.dgv_SARemark.uclShowCellBorder = False
        Me.dgv_SARemark.uclSortColIndex = ""
        Me.dgv_SARemark.uclTreeMode = False
        Me.dgv_SARemark.uclVisibleColIndex = ""
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "複測版本"
        '
        'txt_RetestVer
        '
        Me.txt_RetestVer.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_RetestVer.Location = New System.Drawing.Point(81, 215)
        Me.txt_RetestVer.MaxLength = 10
        Me.txt_RetestVer.Name = "txt_RetestVer"
        Me.txt_RetestVer.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_RetestVer.SelectionStart = 0
        Me.txt_RetestVer.Size = New System.Drawing.Size(115, 27)
        Me.txt_RetestVer.TabIndex = 9
        Me.txt_RetestVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_RetestVer.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_RetestVer.ToolTipTag = Nothing
        Me.txt_RetestVer.uclDollarSign = False
        Me.txt_RetestVer.uclDotCount = 0
        Me.txt_RetestVer.uclIntCount = 5
        Me.txt_RetestVer.uclMinus = False
        Me.txt_RetestVer.uclReadOnly = False
        Me.txt_RetestVer.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_RetestVer.uclTrimZero = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "複測結果"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(406, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "複測日期"
        '
        'cbo_RetestResult
        '
        Me.cbo_RetestResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_RetestResult.DropDownWidth = 20
        Me.cbo_RetestResult.DroppedDown = False
        Me.cbo_RetestResult.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RetestResult.Location = New System.Drawing.Point(78, 245)
        Me.cbo_RetestResult.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RetestResult.Name = "cbo_RetestResult"
        Me.cbo_RetestResult.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.cbo_RetestResult.SelectedIndex = -1
        Me.cbo_RetestResult.SelectedItem = Nothing
        Me.cbo_RetestResult.SelectedText = ""
        Me.cbo_RetestResult.SelectedValue = ""
        Me.cbo_RetestResult.SelectionStart = 0
        Me.cbo_RetestResult.Size = New System.Drawing.Size(118, 28)
        Me.cbo_RetestResult.TabIndex = 10
        Me.cbo_RetestResult.uclDisplayIndex = "0,1"
        Me.cbo_RetestResult.uclIsAutoClear = True
        Me.cbo_RetestResult.uclIsFirstItemEmpty = True
        Me.cbo_RetestResult.uclIsTextMode = False
        Me.cbo_RetestResult.uclShowMsg = False
        Me.cbo_RetestResult.uclValueIndex = "0"
        '
        'dtp_RetestDate
        '
        Me.dtp_RetestDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_RetestDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_RetestDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_RetestDate.Location = New System.Drawing.Point(484, 215)
        Me.dtp_RetestDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_RetestDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_RetestDate.Name = "dtp_RetestDate"
        Me.dtp_RetestDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_RetestDate.TabIndex = 11
        Me.dtp_RetestDate.uclIsFixedBackColor = False
        Me.dtp_RetestDate.uclReadOnly = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "複測說明"
        '
        'rtb_Note
        '
        Me.tlp_Main.SetColumnSpan(Me.rtb_Note, 2)
        Me.rtb_Note.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Note.Location = New System.Drawing.Point(81, 276)
        Me.rtb_Note.Name = "rtb_Note"
        Me.tlp_Main.SetRowSpan(Me.rtb_Note, 2)
        Me.rtb_Note.Size = New System.Drawing.Size(397, 190)
        Me.rtb_Note.TabIndex = 12
        Me.rtb_Note.Text = ""
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(484, 276)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(124, 26)
        Me.btn_Save.TabIndex = 13
        Me.btn_Save.Text = "送出結果"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'JobQACheckBugHistoryUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 908)
        Me.Controls.Add(Me.tlp_Main)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "JobQACheckBugHistoryUI"
        Me.Text = "查看BUG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.gb_SDRemark.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.gb_PGRemark.ResumeLayout(False)
        Me.gb_SARemark.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents gb_SDRemark As Windows.Forms.GroupBox
    Friend WithEvents dgv_SDRemark As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tlp_Main As Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_PGRemark As Windows.Forms.GroupBox
    Friend WithEvents dgv_PGRemark As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents gb_SARemark As Windows.Forms.GroupBox
    Friend WithEvents dgv_SARemark As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txt_RetestVer As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents cbo_RetestResult As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dtp_RetestDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents rtb_Note As Windows.Forms.RichTextBox
    Friend WithEvents btn_Save As Windows.Forms.Button
    Friend WithEvents JobQACreateNewJobUC1 As JobQACreateNewBugUC
    Friend WithEvents lbl_Ver As Windows.Forms.Label
    Friend WithEvents lbl_BugId As Windows.Forms.Label
End Class
