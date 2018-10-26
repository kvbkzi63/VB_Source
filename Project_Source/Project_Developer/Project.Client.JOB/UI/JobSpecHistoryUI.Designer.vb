<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobSpecHistoryUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobSpecHistoryUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Hosp = New System.Windows.Forms.Label()
        Me.cbo_Hosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_Project = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Function = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.gb_JobList = New System.Windows.Forms.GroupBox()
        Me.dgv_JobList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_AttList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.cbo_AssignUser = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_JobList.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_AssignUser, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EndDate, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Hosp, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Hosp, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Project, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_System, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Function, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_StartDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(944, 92)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDate.Location = New System.Drawing.Point(691, 3)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_EndDate.TabIndex = 13
        Me.dtp_EndDate.uclIsFixedBackColor = False
        Me.dtp_EndDate.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 8)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "派工日期-起"
        '
        'lbl_Hosp
        '
        Me.lbl_Hosp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Hosp.AutoSize = True
        Me.lbl_Hosp.Location = New System.Drawing.Point(4, 8)
        Me.lbl_Hosp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Hosp.Name = "lbl_Hosp"
        Me.lbl_Hosp.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Hosp.TabIndex = 0
        Me.lbl_Hosp.Text = "所屬醫院"
        '
        'cbo_Hosp
        '
        Me.cbo_Hosp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Hosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Hosp.DropDownWidth = 20
        Me.cbo_Hosp.DroppedDown = False
        Me.cbo_Hosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Hosp.Location = New System.Drawing.Point(80, 4)
        Me.cbo_Hosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Hosp.Name = "cbo_Hosp"
        Me.cbo_Hosp.SelectedIndex = -1
        Me.cbo_Hosp.SelectedItem = Nothing
        Me.cbo_Hosp.SelectedText = ""
        Me.cbo_Hosp.SelectedValue = ""
        Me.cbo_Hosp.SelectionStart = 0
        Me.cbo_Hosp.Size = New System.Drawing.Size(203, 24)
        Me.cbo_Hosp.TabIndex = 5
        Me.cbo_Hosp.uclDisplayIndex = "0,1"
        Me.cbo_Hosp.uclIsAutoClear = True
        Me.cbo_Hosp.uclIsFirstItemEmpty = True
        Me.cbo_Hosp.uclIsTextMode = False
        Me.cbo_Hosp.uclShowMsg = False
        Me.cbo_Hosp.uclValueIndex = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 67)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "派工人員"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "所屬專案"
        '
        'cbo_Project
        '
        Me.cbo_Project.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Project.DropDownWidth = 20
        Me.cbo_Project.DroppedDown = False
        Me.cbo_Project.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Project.Location = New System.Drawing.Point(80, 33)
        Me.cbo_Project.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Project.Name = "cbo_Project"
        Me.cbo_Project.SelectedIndex = -1
        Me.cbo_Project.SelectedItem = Nothing
        Me.cbo_Project.SelectedText = ""
        Me.cbo_Project.SelectedValue = ""
        Me.cbo_Project.SelectionStart = 0
        Me.cbo_Project.Size = New System.Drawing.Size(203, 24)
        Me.cbo_Project.TabIndex = 6
        Me.cbo_Project.uclDisplayIndex = "0,1"
        Me.cbo_Project.uclIsAutoClear = True
        Me.cbo_Project.uclIsFirstItemEmpty = True
        Me.cbo_Project.uclIsTextMode = False
        Me.cbo_Project.uclShowMsg = False
        Me.cbo_Project.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(308, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "所屬系統"
        '
        'cbo_System
        '
        Me.cbo_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.DroppedDown = False
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(384, 33)
        Me.cbo_System.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(203, 24)
        Me.cbo_System.TabIndex = 7
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclIsFirstItemEmpty = True
        Me.cbo_System.uclIsTextMode = False
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(612, 37)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "功能名稱"
        '
        'cbo_Function
        '
        Me.cbo_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Function.DropDownWidth = 20
        Me.cbo_Function.DroppedDown = False
        Me.cbo_Function.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Function.Location = New System.Drawing.Point(688, 33)
        Me.cbo_Function.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Function.Name = "cbo_Function"
        Me.cbo_Function.SelectedIndex = -1
        Me.cbo_Function.SelectedItem = Nothing
        Me.cbo_Function.SelectedText = ""
        Me.cbo_Function.SelectedValue = ""
        Me.cbo_Function.SelectionStart = 0
        Me.cbo_Function.Size = New System.Drawing.Size(203, 24)
        Me.cbo_Function.TabIndex = 8
        Me.cbo_Function.uclDisplayIndex = "0,1"
        Me.cbo_Function.uclIsAutoClear = True
        Me.cbo_Function.uclIsFirstItemEmpty = True
        Me.cbo_Function.uclIsTextMode = False
        Me.cbo_Function.uclShowMsg = False
        Me.cbo_Function.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(591, 8)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "派工日期-迄"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_StartDate.Location = New System.Drawing.Point(387, 3)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_StartDate.TabIndex = 12
        Me.dtp_StartDate.uclIsFixedBackColor = False
        Me.dtp_StartDate.uclReadOnly = False
        '
        'FlowLayoutPanel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 4)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(286, 60)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(655, 30)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(3, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(91, 25)
        Me.btn_Query.TabIndex = 1
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(100, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(91, 25)
        Me.btn_Clear.TabIndex = 0
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'gb_JobList
        '
        Me.gb_JobList.Controls.Add(Me.dgv_JobList)
        Me.gb_JobList.Location = New System.Drawing.Point(0, 0)
        Me.gb_JobList.Name = "gb_JobList"
        Me.gb_JobList.Size = New System.Drawing.Size(457, 549)
        Me.gb_JobList.TabIndex = 1
        Me.gb_JobList.TabStop = False
        Me.gb_JobList.Text = "派工紀錄"
        '
        'dgv_JobList
        '
        Me.dgv_JobList.AllowUserToAddRows = False
        Me.dgv_JobList.AllowUserToOrderColumns = False
        Me.dgv_JobList.AllowUserToResizeColumns = True
        Me.dgv_JobList.AllowUserToResizeRows = False
        Me.dgv_JobList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_JobList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_JobList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_JobList.ColumnHeadersHeight = 4
        Me.dgv_JobList.ColumnHeadersVisible = True
        Me.dgv_JobList.CurrentCell = Nothing
        Me.dgv_JobList.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_JobList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_JobList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_JobList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_JobList.Location = New System.Drawing.Point(3, 23)
        Me.dgv_JobList.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_JobList.MultiSelect = False
        Me.dgv_JobList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_JobList.Name = "dgv_JobList"
        Me.dgv_JobList.RowHeadersWidth = 41
        Me.dgv_JobList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_JobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_JobList.Size = New System.Drawing.Size(451, 523)
        Me.dgv_JobList.TabIndex = 0
        Me.dgv_JobList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_JobList.uclBatchColIndex = ""
        Me.dgv_JobList.uclClickToCheck = False
        Me.dgv_JobList.uclColumnAlignment = ""
        Me.dgv_JobList.uclColumnCheckBox = False
        Me.dgv_JobList.uclColumnControlType = ""
        Me.dgv_JobList.uclColumnWidth = ""
        Me.dgv_JobList.uclDoCellEnter = True
        Me.dgv_JobList.uclHasNewRow = False
        Me.dgv_JobList.uclHeaderText = ""
        Me.dgv_JobList.uclIsAlternatingRowsColors = True
        Me.dgv_JobList.uclIsComboBoxGridQuery = True
        Me.dgv_JobList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_JobList.uclIsDoOrderCheck = True
        Me.dgv_JobList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_JobList.uclIsSortable = False
        Me.dgv_JobList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_JobList.uclNonVisibleColIndex = ""
        Me.dgv_JobList.uclReadOnly = False
        Me.dgv_JobList.uclShowCellBorder = False
        Me.dgv_JobList.uclSortColIndex = ""
        Me.dgv_JobList.uclTreeMode = False
        Me.dgv_JobList.uclVisibleColIndex = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 92)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gb_JobList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(944, 549)
        Me.SplitContainer1.SplitterDistance = 457
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_AttList)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 549)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "附件紀錄"
        '
        'dgv_AttList
        '
        Me.dgv_AttList.AllowUserToAddRows = False
        Me.dgv_AttList.AllowUserToOrderColumns = False
        Me.dgv_AttList.AllowUserToResizeColumns = True
        Me.dgv_AttList.AllowUserToResizeRows = False
        Me.dgv_AttList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_AttList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_AttList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_AttList.ColumnHeadersHeight = 4
        Me.dgv_AttList.ColumnHeadersVisible = True
        Me.dgv_AttList.CurrentCell = Nothing
        Me.dgv_AttList.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_AttList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_AttList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_AttList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_AttList.Location = New System.Drawing.Point(3, 23)
        Me.dgv_AttList.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_AttList.MultiSelect = False
        Me.dgv_AttList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_AttList.Name = "dgv_AttList"
        Me.dgv_AttList.RowHeadersWidth = 41
        Me.dgv_AttList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_AttList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_AttList.Size = New System.Drawing.Size(451, 523)
        Me.dgv_AttList.TabIndex = 0
        Me.dgv_AttList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_AttList.uclBatchColIndex = ""
        Me.dgv_AttList.uclClickToCheck = False
        Me.dgv_AttList.uclColumnAlignment = ""
        Me.dgv_AttList.uclColumnCheckBox = False
        Me.dgv_AttList.uclColumnControlType = ""
        Me.dgv_AttList.uclColumnWidth = ""
        Me.dgv_AttList.uclDoCellEnter = True
        Me.dgv_AttList.uclHasNewRow = False
        Me.dgv_AttList.uclHeaderText = ""
        Me.dgv_AttList.uclIsAlternatingRowsColors = True
        Me.dgv_AttList.uclIsComboBoxGridQuery = True
        Me.dgv_AttList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_AttList.uclIsDoOrderCheck = True
        Me.dgv_AttList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_AttList.uclIsSortable = False
        Me.dgv_AttList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_AttList.uclNonVisibleColIndex = ""
        Me.dgv_AttList.uclReadOnly = False
        Me.dgv_AttList.uclShowCellBorder = False
        Me.dgv_AttList.uclSortColIndex = ""
        Me.dgv_AttList.uclTreeMode = False
        Me.dgv_AttList.uclVisibleColIndex = ""
        '
        'cbo_AssignUser
        '
        Me.cbo_AssignUser.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_AssignUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_AssignUser.DropDownWidth = 20
        Me.cbo_AssignUser.DroppedDown = False
        Me.cbo_AssignUser.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_AssignUser.Location = New System.Drawing.Point(80, 63)
        Me.cbo_AssignUser.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_AssignUser.Name = "cbo_AssignUser"
        Me.cbo_AssignUser.SelectedIndex = -1
        Me.cbo_AssignUser.SelectedItem = Nothing
        Me.cbo_AssignUser.SelectedText = ""
        Me.cbo_AssignUser.SelectedValue = ""
        Me.cbo_AssignUser.SelectionStart = 0
        Me.cbo_AssignUser.Size = New System.Drawing.Size(203, 24)
        Me.cbo_AssignUser.TabIndex = 15
        Me.cbo_AssignUser.uclDisplayIndex = "0,1"
        Me.cbo_AssignUser.uclIsAutoClear = True
        Me.cbo_AssignUser.uclIsFirstItemEmpty = True
        Me.cbo_AssignUser.uclIsTextMode = False
        Me.cbo_AssignUser.uclShowMsg = False
        Me.cbo_AssignUser.uclValueIndex = "0"
        '
        'JobSpecHistoryUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "JobSpecHistoryUI"
        Me.TabText = "JobSpecHistoryUI"
        Me.Text = "JobSpecHistoryUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.gb_JobList.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lbl_Hosp As Windows.Forms.Label
    Friend WithEvents cbo_Hosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbo_Project As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbo_Function As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents btn_Clear As Windows.Forms.Button
    Friend WithEvents gb_JobList As Windows.Forms.GroupBox
    Friend WithEvents dgv_JobList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents dgv_AttList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents cbo_AssignUser As Syscom.Client.UCL.UCLComboBoxUC
End Class
