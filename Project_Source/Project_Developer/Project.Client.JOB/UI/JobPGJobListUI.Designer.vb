Imports Syscom.Client.UCL

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobPGJobListUI
    Inherits BaseFormUI

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobPGJobListUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_All = New System.Windows.Forms.RadioButton()
        Me.rbt_UnFinish = New System.Windows.Forms.RadioButton()
        Me.rbt_Finish = New System.Windows.Forms.RadioButton()
        Me.rbt_Reply = New System.Windows.Forms.RadioButton()
        Me.rbt_UnProcess = New System.Windows.Forms.RadioButton()
        Me.ucl_AssignDate = New Syscom.Client.UCL.UclTimeIntervalUC()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tp_JobList = New System.Windows.Forms.TabPage()
        Me.dgv_JobList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grb_Note = New System.Windows.Forms.GroupBox()
        Me.rtb_SANote = New System.Windows.Forms.RichTextBox()
        Me.gb_SDNote = New System.Windows.Forms.GroupBox()
        Me.rtb_SDNote = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_SD_Cost = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_SA_DeadLine = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_SD_DeadLine = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_SA_Cost = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rtb_PGNote = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_DownLoadFile = New System.Windows.Forms.Button()
        Me.btn_UploadTestReport = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_ClearPath = New System.Windows.Forms.Button()
        Me.btn_UploadFiles = New System.Windows.Forms.Button()
        Me.dgv_ToDoList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.dgv_ReportPath = New System.Windows.Forms.DataGridView()
        Me.選 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_IssueLevel = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ckb_LinkToTFS = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckb_Upload = New System.Windows.Forms.CheckBox()
        Me.btn_LinkTfs = New System.Windows.Forms.Button()
        Me.ulb_WorkSpaces = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_TFSAddress = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_TfsPassword = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_TfsUserId = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt_CostTime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tva_PendingChanges = New Syscom.Client.UCL.UCLTreeViewAdvUC()
        Me.tp_DBModifiy = New System.Windows.Forms.TabPage()
        Me.Panel_DBModifiy = New System.Windows.Forms.Panel()
        Me.tp_ToDoList = New System.Windows.Forms.TabPage()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.rbt_Cancel = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tp_JobList.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grb_Note.SuspendLayout()
        Me.gb_SDNote.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        CType(Me.dgv_ReportPath, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.tp_DBModifiy.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.39407!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.60593!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1182, 53)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "登錄者"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_All)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_UnFinish)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_Finish)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_Reply)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_UnProcess)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_Cancel)
        Me.FlowLayoutPanel1.Controls.Add(Me.ucl_AssignDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(149, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1023, 47)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'rbt_All
        '
        Me.rbt_All.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_All.AutoSize = True
        Me.rbt_All.Location = New System.Drawing.Point(3, 6)
        Me.rbt_All.Name = "rbt_All"
        Me.rbt_All.Size = New System.Drawing.Size(58, 20)
        Me.rbt_All.TabIndex = 0
        Me.rbt_All.Text = "全部"
        Me.rbt_All.UseVisualStyleBackColor = True
        '
        'rbt_UnFinish
        '
        Me.rbt_UnFinish.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_UnFinish.AutoSize = True
        Me.rbt_UnFinish.Location = New System.Drawing.Point(67, 6)
        Me.rbt_UnFinish.Name = "rbt_UnFinish"
        Me.rbt_UnFinish.Size = New System.Drawing.Size(74, 20)
        Me.rbt_UnFinish.TabIndex = 1
        Me.rbt_UnFinish.Text = "未完成"
        Me.rbt_UnFinish.UseVisualStyleBackColor = True
        '
        'rbt_Finish
        '
        Me.rbt_Finish.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_Finish.AutoSize = True
        Me.rbt_Finish.Location = New System.Drawing.Point(147, 6)
        Me.rbt_Finish.Name = "rbt_Finish"
        Me.rbt_Finish.Size = New System.Drawing.Size(74, 20)
        Me.rbt_Finish.TabIndex = 3
        Me.rbt_Finish.Text = "已完成"
        Me.rbt_Finish.UseVisualStyleBackColor = True
        '
        'rbt_Reply
        '
        Me.rbt_Reply.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_Reply.AutoSize = True
        Me.rbt_Reply.Location = New System.Drawing.Point(227, 6)
        Me.rbt_Reply.Name = "rbt_Reply"
        Me.rbt_Reply.Size = New System.Drawing.Size(74, 20)
        Me.rbt_Reply.TabIndex = 2
        Me.rbt_Reply.Text = "已提交"
        Me.rbt_Reply.UseVisualStyleBackColor = True
        '
        'rbt_UnProcess
        '
        Me.rbt_UnProcess.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_UnProcess.AutoSize = True
        Me.rbt_UnProcess.Checked = True
        Me.rbt_UnProcess.Location = New System.Drawing.Point(307, 6)
        Me.rbt_UnProcess.Name = "rbt_UnProcess"
        Me.rbt_UnProcess.Size = New System.Drawing.Size(74, 20)
        Me.rbt_UnProcess.TabIndex = 6
        Me.rbt_UnProcess.TabStop = True
        Me.rbt_UnProcess.Text = "未提交"
        Me.rbt_UnProcess.UseVisualStyleBackColor = True
        '
        'ucl_AssignDate
        '
        Me.ucl_AssignDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_AssignDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_AssignDate.Location = New System.Drawing.Point(464, 0)
        Me.ucl_AssignDate.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_AssignDate.Name = "ucl_AssignDate"
        Me.ucl_AssignDate.Size = New System.Drawing.Size(358, 33)
        Me.ucl_AssignDate.TabIndex = 4
        Me.ucl_AssignDate.uclDisplayFormate = ""
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(825, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(96, 27)
        Me.btn_Query.TabIndex = 5
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 53)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1182, 588)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tp_JobList)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.tp_DBModifiy)
        Me.TabControl1.Controls.Add(Me.tp_ToDoList)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1176, 582)
        Me.TabControl1.TabIndex = 1
        '
        'tp_JobList
        '
        Me.tp_JobList.Controls.Add(Me.dgv_JobList)
        Me.tp_JobList.Location = New System.Drawing.Point(4, 26)
        Me.tp_JobList.Name = "tp_JobList"
        Me.tp_JobList.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_JobList.Size = New System.Drawing.Size(1168, 552)
        Me.tp_JobList.TabIndex = 0
        Me.tp_JobList.Text = "工作清單"
        Me.tp_JobList.UseVisualStyleBackColor = True
        '
        'dgv_JobList
        '
        Me.dgv_JobList.AllowUserToAddRows = False
        Me.dgv_JobList.AllowUserToOrderColumns = False
        Me.dgv_JobList.AllowUserToResizeColumns = True
        Me.dgv_JobList.AllowUserToResizeRows = False
        Me.dgv_JobList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
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
        Me.dgv_JobList.Location = New System.Drawing.Point(3, 3)
        Me.dgv_JobList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_JobList.MultiSelect = False
        Me.dgv_JobList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_JobList.Name = "dgv_JobList"
        Me.dgv_JobList.RowHeadersWidth = 41
        Me.dgv_JobList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_JobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_JobList.Size = New System.Drawing.Size(1162, 546)
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
        Me.dgv_JobList.uclSelectedCellBorder = False
        Me.dgv_JobList.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_JobList.uclSelectedCellBorderSize = 4
        Me.dgv_JobList.uclSelectedFirstShowCol = 0
        Me.dgv_JobList.uclSelectedLastShowCol = -1
        Me.dgv_JobList.uclShowCellBorder = False
        Me.dgv_JobList.uclSortColIndex = ""
        Me.dgv_JobList.uclTreeMode = False
        Me.dgv_JobList.uclVisibleColIndex = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1168, 552)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "需求備註"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.SplitContainer1, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.241758!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.75824!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1162, 546)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 48)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grb_Note)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gb_SDNote)
        Me.SplitContainer1.Size = New System.Drawing.Size(1156, 495)
        Me.SplitContainer1.SplitterDistance = 385
        Me.SplitContainer1.TabIndex = 1
        '
        'grb_Note
        '
        Me.grb_Note.Controls.Add(Me.rtb_SANote)
        Me.grb_Note.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grb_Note.Location = New System.Drawing.Point(0, 0)
        Me.grb_Note.Name = "grb_Note"
        Me.grb_Note.Size = New System.Drawing.Size(385, 495)
        Me.grb_Note.TabIndex = 1
        Me.grb_Note.TabStop = False
        Me.grb_Note.Text = "SA備註"
        '
        'rtb_SANote
        '
        Me.rtb_SANote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_SANote.Location = New System.Drawing.Point(3, 23)
        Me.rtb_SANote.Name = "rtb_SANote"
        Me.rtb_SANote.Size = New System.Drawing.Size(379, 469)
        Me.rtb_SANote.TabIndex = 0
        Me.rtb_SANote.Text = ""
        '
        'gb_SDNote
        '
        Me.gb_SDNote.Controls.Add(Me.rtb_SDNote)
        Me.gb_SDNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_SDNote.Location = New System.Drawing.Point(0, 0)
        Me.gb_SDNote.Name = "gb_SDNote"
        Me.gb_SDNote.Size = New System.Drawing.Size(767, 495)
        Me.gb_SDNote.TabIndex = 0
        Me.gb_SDNote.TabStop = False
        Me.gb_SDNote.Text = "SD備註"
        '
        'rtb_SDNote
        '
        Me.rtb_SDNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_SDNote.Location = New System.Drawing.Point(3, 23)
        Me.rtb_SDNote.Name = "rtb_SDNote"
        Me.rtb_SDNote.Size = New System.Drawing.Size(761, 469)
        Me.rtb_SDNote.TabIndex = 1
        Me.rtb_SDNote.Text = ""
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 8
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.txt_SD_Cost, 7, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label9, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label10, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label11, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.dtp_SA_DeadLine, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.dtp_SD_DeadLine, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.txt_SA_Cost, 3, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Enabled = False
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1156, 39)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'txt_SD_Cost
        '
        Me.txt_SD_Cost.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SD_Cost.Location = New System.Drawing.Point(805, 6)
        Me.txt_SD_Cost.Name = "txt_SD_Cost"
        Me.txt_SD_Cost.Size = New System.Drawing.Size(100, 27)
        Me.txt_SD_Cost.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SA預計完成日"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(254, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "SA評估時間"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(457, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "SD預計完成日"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(708, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "SD評估時間"
        '
        'dtp_SA_DeadLine
        '
        Me.dtp_SA_DeadLine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_SA_DeadLine.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_SA_DeadLine.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_SA_DeadLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_SA_DeadLine.Location = New System.Drawing.Point(116, 6)
        Me.dtp_SA_DeadLine.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_SA_DeadLine.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_SA_DeadLine.Name = "dtp_SA_DeadLine"
        Me.dtp_SA_DeadLine.Size = New System.Drawing.Size(132, 27)
        Me.dtp_SA_DeadLine.TabIndex = 4
        Me.dtp_SA_DeadLine.uclIsFixedBackColor = False
        Me.dtp_SA_DeadLine.uclReadOnly = False
        '
        'dtp_SD_DeadLine
        '
        Me.dtp_SD_DeadLine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_SD_DeadLine.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_SD_DeadLine.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_SD_DeadLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_SD_DeadLine.Location = New System.Drawing.Point(570, 6)
        Me.dtp_SD_DeadLine.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_SD_DeadLine.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_SD_DeadLine.Name = "dtp_SD_DeadLine"
        Me.dtp_SD_DeadLine.Size = New System.Drawing.Size(132, 27)
        Me.dtp_SD_DeadLine.TabIndex = 5
        Me.dtp_SD_DeadLine.uclIsFixedBackColor = False
        Me.dtp_SD_DeadLine.uclReadOnly = False
        '
        'txt_SA_Cost
        '
        Me.txt_SA_Cost.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SA_Cost.Location = New System.Drawing.Point(351, 6)
        Me.txt_SA_Cost.Name = "txt_SA_Cost"
        Me.txt_SA_Cost.Size = New System.Drawing.Size(100, 27)
        Me.txt_SA_Cost.TabIndex = 6
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1168, 552)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "其他作業"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.97947!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.97947!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.2911!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.81165!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox3, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.tva_PendingChanges, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.89855!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.95652!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1168, 552)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'GroupBox2
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox2, 3)
        Me.GroupBox2.Controls.Add(Me.rtb_PGNote)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(696, 104)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "提交內容/變更集備註"
        '
        'rtb_PGNote
        '
        Me.rtb_PGNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_PGNote.Location = New System.Drawing.Point(3, 23)
        Me.rtb_PGNote.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.rtb_PGNote.Name = "rtb_PGNote"
        Me.rtb_PGNote.Size = New System.Drawing.Size(690, 78)
        Me.rtb_PGNote.TabIndex = 1
        Me.rtb_PGNote.uclMaxLength = 32767
        Me.rtb_PGNote.uclReadOnly = False
        Me.rtb_PGNote.uclWordWrap = True
        '
        'GroupBox3
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox3, 3)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel7)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(696, 148)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "提交"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.11688!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.88312!))
        Me.TableLayoutPanel7.Controls.Add(Me.FlowLayoutPanel3, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.dgv_ToDoList, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.dgv_ReportPath, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.78688!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.21311!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(690, 122)
        Me.TableLayoutPanel7.TabIndex = 2
        '
        'FlowLayoutPanel3
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.FlowLayoutPanel3, 2)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_DownLoadFile)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_UploadTestReport)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_ClearPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_UploadFiles)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(684, 33)
        Me.FlowLayoutPanel3.TabIndex = 0
        '
        'btn_DownLoadFile
        '
        Me.btn_DownLoadFile.Enabled = False
        Me.btn_DownLoadFile.Location = New System.Drawing.Point(3, 3)
        Me.btn_DownLoadFile.Name = "btn_DownLoadFile"
        Me.btn_DownLoadFile.Size = New System.Drawing.Size(88, 27)
        Me.btn_DownLoadFile.TabIndex = 0
        Me.btn_DownLoadFile.Text = "下載附件"
        Me.btn_DownLoadFile.UseVisualStyleBackColor = True
        '
        'btn_UploadTestReport
        '
        Me.btn_UploadTestReport.Location = New System.Drawing.Point(97, 3)
        Me.btn_UploadTestReport.Name = "btn_UploadTestReport"
        Me.btn_UploadTestReport.Size = New System.Drawing.Size(124, 27)
        Me.btn_UploadTestReport.TabIndex = 3
        Me.btn_UploadTestReport.Text = "上傳測試報告"
        Me.btn_UploadTestReport.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(227, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(89, 27)
        Me.btn_Delete.TabIndex = 4
        Me.btn_Delete.Text = "移除所選"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_ClearPath
        '
        Me.btn_ClearPath.Location = New System.Drawing.Point(322, 3)
        Me.btn_ClearPath.Name = "btn_ClearPath"
        Me.btn_ClearPath.Size = New System.Drawing.Size(64, 27)
        Me.btn_ClearPath.TabIndex = 5
        Me.btn_ClearPath.Text = "清除"
        Me.btn_ClearPath.UseVisualStyleBackColor = True
        '
        'btn_UploadFiles
        '
        Me.btn_UploadFiles.Location = New System.Drawing.Point(392, 3)
        Me.btn_UploadFiles.Name = "btn_UploadFiles"
        Me.btn_UploadFiles.Size = New System.Drawing.Size(64, 27)
        Me.btn_UploadFiles.TabIndex = 3
        Me.btn_UploadFiles.Text = "提交"
        Me.btn_UploadFiles.UseVisualStyleBackColor = True
        '
        'dgv_ToDoList
        '
        Me.dgv_ToDoList.AllowUserToAddRows = False
        Me.dgv_ToDoList.AllowUserToOrderColumns = False
        Me.dgv_ToDoList.AllowUserToResizeColumns = True
        Me.dgv_ToDoList.AllowUserToResizeRows = False
        Me.dgv_ToDoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ToDoList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ToDoList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_ToDoList.ColumnHeadersHeight = 4
        Me.dgv_ToDoList.ColumnHeadersVisible = True
        Me.dgv_ToDoList.CurrentCell = Nothing
        Me.dgv_ToDoList.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ToDoList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_ToDoList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ToDoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ToDoList.Location = New System.Drawing.Point(232, 43)
        Me.dgv_ToDoList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_ToDoList.MultiSelect = True
        Me.dgv_ToDoList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ToDoList.Name = "dgv_ToDoList"
        Me.dgv_ToDoList.RowHeadersWidth = 41
        Me.dgv_ToDoList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ToDoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ToDoList.Size = New System.Drawing.Size(454, 75)
        Me.dgv_ToDoList.TabIndex = 2
        Me.dgv_ToDoList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_ToDoList.uclBatchColIndex = ""
        Me.dgv_ToDoList.uclClickToCheck = False
        Me.dgv_ToDoList.uclColumnAlignment = ""
        Me.dgv_ToDoList.uclColumnCheckBox = True
        Me.dgv_ToDoList.uclColumnControlType = ""
        Me.dgv_ToDoList.uclColumnWidth = ""
        Me.dgv_ToDoList.uclDoCellEnter = True
        Me.dgv_ToDoList.uclHasNewRow = False
        Me.dgv_ToDoList.uclHeaderText = ""
        Me.dgv_ToDoList.uclIsAlternatingRowsColors = True
        Me.dgv_ToDoList.uclIsComboBoxGridQuery = True
        Me.dgv_ToDoList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ToDoList.uclIsDoOrderCheck = True
        Me.dgv_ToDoList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_ToDoList.uclIsSortable = False
        Me.dgv_ToDoList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ToDoList.uclNonVisibleColIndex = ""
        Me.dgv_ToDoList.uclReadOnly = False
        Me.dgv_ToDoList.uclSelectedCellBorder = False
        Me.dgv_ToDoList.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_ToDoList.uclSelectedCellBorderSize = 4
        Me.dgv_ToDoList.uclSelectedFirstShowCol = 0
        Me.dgv_ToDoList.uclSelectedLastShowCol = -1
        Me.dgv_ToDoList.uclShowCellBorder = False
        Me.dgv_ToDoList.uclSortColIndex = ""
        Me.dgv_ToDoList.uclTreeMode = False
        Me.dgv_ToDoList.uclVisibleColIndex = ""
        '
        'dgv_ReportPath
        '
        Me.dgv_ReportPath.AllowUserToAddRows = False
        Me.dgv_ReportPath.AllowUserToDeleteRows = False
        Me.dgv_ReportPath.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_ReportPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ReportPath.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選, Me.FilePath})
        Me.dgv_ReportPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ReportPath.Location = New System.Drawing.Point(3, 42)
        Me.dgv_ReportPath.Name = "dgv_ReportPath"
        Me.dgv_ReportPath.RowTemplate.Height = 24
        Me.dgv_ReportPath.Size = New System.Drawing.Size(222, 77)
        Me.dgv_ReportPath.TabIndex = 2
        '
        '選
        '
        Me.選.HeaderText = "選"
        Me.選.Name = "選"
        Me.選.Width = 30
        '
        'FilePath
        '
        Me.FilePath.HeaderText = "路徑"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FilePath.Width = 46
        '
        'GroupBox1
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox1, 3)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 267)
        Me.GroupBox1.Name = "GroupBox1"
        Me.TableLayoutPanel3.SetRowSpan(Me.GroupBox1, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(696, 282)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "提交設定"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_IssueLevel, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btn_LinkTfs, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.ulb_WorkSpaces, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_TFSAddress, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_TfsPassword, 3, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label6, 2, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_TfsUserId, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel4, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 6
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(690, 256)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "完成時間"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "需求難易度"
        '
        'cbo_IssueLevel
        '
        Me.cbo_IssueLevel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IssueLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IssueLevel.DropDownWidth = 20
        Me.cbo_IssueLevel.DroppedDown = False
        Me.cbo_IssueLevel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IssueLevel.Location = New System.Drawing.Point(463, 7)
        Me.cbo_IssueLevel.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IssueLevel.MaxLength = 50
        Me.cbo_IssueLevel.Name = "cbo_IssueLevel"
        Me.cbo_IssueLevel.SelectedIndex = -1
        Me.cbo_IssueLevel.SelectedItem = Nothing
        Me.cbo_IssueLevel.SelectedText = ""
        Me.cbo_IssueLevel.SelectedValue = ""
        Me.cbo_IssueLevel.SelectionStart = 0
        Me.cbo_IssueLevel.Size = New System.Drawing.Size(135, 24)
        Me.cbo_IssueLevel.TabIndex = 2
        Me.cbo_IssueLevel.uclDisplayIndex = "0,1"
        Me.cbo_IssueLevel.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_IssueLevel.uclIsAutoClear = True
        Me.cbo_IssueLevel.uclIsFirstItemEmpty = True
        Me.cbo_IssueLevel.uclIsTextMode = False
        Me.cbo_IssueLevel.uclShowMsg = False
        Me.cbo_IssueLevel.uclValueIndex = "0"
        '
        'FlowLayoutPanel2
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.FlowLayoutPanel2, 4)
        Me.FlowLayoutPanel2.Controls.Add(Me.ckb_LinkToTFS)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.ckb_Upload)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 42)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(681, 28)
        Me.FlowLayoutPanel2.TabIndex = 11
        '
        'ckb_LinkToTFS
        '
        Me.ckb_LinkToTFS.AutoSize = True
        Me.ckb_LinkToTFS.Location = New System.Drawing.Point(3, 3)
        Me.ckb_LinkToTFS.Name = "ckb_LinkToTFS"
        Me.ckb_LinkToTFS.Size = New System.Drawing.Size(116, 20)
        Me.ckb_LinkToTFS.TabIndex = 0
        Me.ckb_LinkToTFS.Text = "啟用TFS設定"
        Me.ckb_LinkToTFS.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(125, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(290, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "(勾選將於提交時一併簽入相關異動檔案)"
        '
        'ckb_Upload
        '
        Me.ckb_Upload.AutoSize = True
        Me.ckb_Upload.Location = New System.Drawing.Point(421, 3)
        Me.ckb_Upload.Name = "ckb_Upload"
        Me.ckb_Upload.Size = New System.Drawing.Size(174, 20)
        Me.ckb_Upload.TabIndex = 2
        Me.ckb_Upload.Text = "上傳FTP(高聯醫專用)"
        Me.ckb_Upload.UseVisualStyleBackColor = True
        '
        'btn_LinkTfs
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.btn_LinkTfs, 4)
        Me.btn_LinkTfs.Enabled = False
        Me.btn_LinkTfs.Location = New System.Drawing.Point(3, 133)
        Me.btn_LinkTfs.Name = "btn_LinkTfs"
        Me.btn_LinkTfs.Size = New System.Drawing.Size(681, 29)
        Me.btn_LinkTfs.TabIndex = 10
        Me.btn_LinkTfs.Text = "連結-取得本機工作區"
        Me.btn_LinkTfs.UseVisualStyleBackColor = True
        '
        'ulb_WorkSpaces
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.ulb_WorkSpaces, 4)
        Me.ulb_WorkSpaces.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ulb_WorkSpaces.Enabled = False
        Me.ulb_WorkSpaces.ItemHeight = 16
        Me.ulb_WorkSpaces.Location = New System.Drawing.Point(4, 169)
        Me.ulb_WorkSpaces.Margin = New System.Windows.Forms.Padding(4)
        Me.ulb_WorkSpaces.Name = "ulb_WorkSpaces"
        Me.ulb_WorkSpaces.Size = New System.Drawing.Size(682, 98)
        Me.ulb_WorkSpaces.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "版控位置"
        '
        'cbo_TFSAddress
        '
        Me.cbo_TFSAddress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel4.SetColumnSpan(Me.cbo_TFSAddress, 3)
        Me.cbo_TFSAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_TFSAddress.DropDownWidth = 20
        Me.cbo_TFSAddress.DroppedDown = False
        Me.cbo_TFSAddress.Enabled = False
        Me.cbo_TFSAddress.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_TFSAddress.Location = New System.Drawing.Point(94, 73)
        Me.cbo_TFSAddress.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_TFSAddress.MaxLength = 50
        Me.cbo_TFSAddress.Name = "cbo_TFSAddress"
        Me.cbo_TFSAddress.SelectedIndex = -1
        Me.cbo_TFSAddress.SelectedItem = Nothing
        Me.cbo_TFSAddress.SelectedText = ""
        Me.cbo_TFSAddress.SelectedValue = ""
        Me.cbo_TFSAddress.SelectionStart = 0
        Me.cbo_TFSAddress.Size = New System.Drawing.Size(367, 24)
        Me.cbo_TFSAddress.TabIndex = 5
        Me.cbo_TFSAddress.uclDisplayIndex = "0,1"
        Me.cbo_TFSAddress.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_TFSAddress.uclIsAutoClear = True
        Me.cbo_TFSAddress.uclIsFirstItemEmpty = True
        Me.cbo_TFSAddress.uclIsTextMode = False
        Me.cbo_TFSAddress.uclShowMsg = False
        Me.cbo_TFSAddress.uclValueIndex = "0"
        '
        'txt_TfsPassword
        '
        Me.txt_TfsPassword.Enabled = False
        Me.txt_TfsPassword.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_TfsPassword.HideSelection = True
        Me.txt_TfsPassword.Location = New System.Drawing.Point(466, 100)
        Me.txt_TfsPassword.MaxLength = 30
        Me.txt_TfsPassword.Name = "txt_TfsPassword"
        Me.txt_TfsPassword.PasswordChar = "*"
        Me.txt_TfsPassword.SelectionStart = 0
        Me.txt_TfsPassword.Size = New System.Drawing.Size(132, 27)
        Me.txt_TfsPassword.TabIndex = 9
        Me.txt_TfsPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_TfsPassword.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_TfsPassword.ToolTipTag = Nothing
        Me.txt_TfsPassword.uclDollarSign = False
        Me.txt_TfsPassword.uclDotCount = 0
        Me.txt_TfsPassword.uclImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_TfsPassword.uclIntCount = 2
        Me.txt_TfsPassword.uclMinus = False
        Me.txt_TfsPassword.uclReadOnly = False
        Me.txt_TfsPassword.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_TfsPassword.uclTransferForFractions = False
        Me.txt_TfsPassword.uclTrimZero = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "使用者帳號"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(372, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "使用者密碼"
        '
        'txt_TfsUserId
        '
        Me.txt_TfsUserId.Enabled = False
        Me.txt_TfsUserId.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_TfsUserId.HideSelection = True
        Me.txt_TfsUserId.Location = New System.Drawing.Point(97, 100)
        Me.txt_TfsUserId.MaxLength = 30
        Me.txt_TfsUserId.Name = "txt_TfsUserId"
        Me.txt_TfsUserId.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_TfsUserId.SelectionStart = 0
        Me.txt_TfsUserId.Size = New System.Drawing.Size(132, 27)
        Me.txt_TfsUserId.TabIndex = 8
        Me.txt_TfsUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_TfsUserId.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_TfsUserId.ToolTipTag = Nothing
        Me.txt_TfsUserId.uclDollarSign = False
        Me.txt_TfsUserId.uclDotCount = 0
        Me.txt_TfsUserId.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_TfsUserId.uclIntCount = 2
        Me.txt_TfsUserId.uclMinus = False
        Me.txt_TfsUserId.uclReadOnly = False
        Me.txt_TfsUserId.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_TfsUserId.uclTransferForFractions = False
        Me.txt_TfsUserId.uclTrimZero = True
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.txt_CostTime)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(97, 3)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(269, 33)
        Me.FlowLayoutPanel4.TabIndex = 13
        '
        'txt_CostTime
        '
        Me.txt_CostTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_CostTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_CostTime.HideSelection = True
        Me.txt_CostTime.Location = New System.Drawing.Point(3, 3)
        Me.txt_CostTime.MaxLength = 10
        Me.txt_CostTime.Name = "txt_CostTime"
        Me.txt_CostTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_CostTime.SelectionStart = 0
        Me.txt_CostTime.Size = New System.Drawing.Size(129, 27)
        Me.txt_CostTime.TabIndex = 0
        Me.txt_CostTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_CostTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_CostTime.ToolTipTag = Nothing
        Me.txt_CostTime.uclDollarSign = False
        Me.txt_CostTime.uclDotCount = 3
        Me.txt_CostTime.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_CostTime.uclIntCount = 5
        Me.txt_CostTime.uclMinus = False
        Me.txt_CostTime.uclReadOnly = False
        Me.txt_CostTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_CostTime.uclTransferForFractions = False
        Me.txt_CostTime.uclTrimZero = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(138, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "人日(1日=8小時)"
        '
        'tva_PendingChanges
        '
        Me.tva_PendingChanges.AutoScroll = True
        Me.tva_PendingChanges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tva_PendingChanges.Enabled = False
        Me.tva_PendingChanges.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tva_PendingChanges.IsShowGroupCheckBox = False
        Me.tva_PendingChanges.Location = New System.Drawing.Point(706, 4)
        Me.tva_PendingChanges.Margin = New System.Windows.Forms.Padding(4)
        Me.tva_PendingChanges.Name = "tva_PendingChanges"
        Me.TableLayoutPanel3.SetRowSpan(Me.tva_PendingChanges, 5)
        Me.tva_PendingChanges.SelectedItemsResult = Nothing
        Me.tva_PendingChanges.SelectedResult = Nothing
        Me.tva_PendingChanges.SelectedTempItemsResult = Nothing
        Me.tva_PendingChanges.Size = New System.Drawing.Size(458, 544)
        Me.tva_PendingChanges.TabIndex = 4
        Me.tva_PendingChanges.TreeViewName = ""
        Me.tva_PendingChanges.TreeViewSource = Nothing
        '
        'tp_DBModifiy
        '
        Me.tp_DBModifiy.Controls.Add(Me.Panel_DBModifiy)
        Me.tp_DBModifiy.Location = New System.Drawing.Point(4, 26)
        Me.tp_DBModifiy.Name = "tp_DBModifiy"
        Me.tp_DBModifiy.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_DBModifiy.Size = New System.Drawing.Size(1168, 552)
        Me.tp_DBModifiy.TabIndex = 3
        Me.tp_DBModifiy.Text = "DB異動申請"
        Me.tp_DBModifiy.UseVisualStyleBackColor = True
        '
        'Panel_DBModifiy
        '
        Me.Panel_DBModifiy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_DBModifiy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_DBModifiy.Location = New System.Drawing.Point(3, 3)
        Me.Panel_DBModifiy.Name = "Panel_DBModifiy"
        Me.Panel_DBModifiy.Size = New System.Drawing.Size(1162, 546)
        Me.Panel_DBModifiy.TabIndex = 0
        '
        'tp_ToDoList
        '
        Me.tp_ToDoList.Location = New System.Drawing.Point(4, 26)
        Me.tp_ToDoList.Name = "tp_ToDoList"
        Me.tp_ToDoList.Size = New System.Drawing.Size(1168, 552)
        Me.tp_ToDoList.TabIndex = 4
        Me.tp_ToDoList.Text = "待辦事項"
        Me.tp_ToDoList.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'rbt_Cancel
        '
        Me.rbt_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_Cancel.AutoSize = True
        Me.rbt_Cancel.Location = New System.Drawing.Point(387, 6)
        Me.rbt_Cancel.Name = "rbt_Cancel"
        Me.rbt_Cancel.Size = New System.Drawing.Size(74, 20)
        Me.rbt_Cancel.TabIndex = 7
        Me.rbt_Cancel.TabStop = True
        Me.rbt_Cancel.Text = "已作廢"
        Me.rbt_Cancel.UseVisualStyleBackColor = True
        '
        'JobPGJobListUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 641)
        Me.CloseButton = False
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "JobPGJobListUI"
        Me.TabText = "JobPGJobListUI"
        Me.Text = "JobPGJobListUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tp_JobList.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grb_Note.ResumeLayout(False)
        Me.gb_SDNote.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        CType(Me.dgv_ReportPath, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.tp_DBModifiy.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_JobList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_All As Windows.Forms.RadioButton
    Friend WithEvents rbt_UnFinish As Windows.Forms.RadioButton
    Friend WithEvents rbt_Finish As Windows.Forms.RadioButton
    Friend WithEvents rbt_Reply As Windows.Forms.RadioButton
    Friend WithEvents ucl_AssignDate As UclTimeIntervalUC
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents tp_JobList As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents btn_DownLoadFile As Windows.Forms.Button
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents rtb_PGNote As UCLRichTextBoxUC
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents btn_UploadTestReport As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel3 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents dgv_ReportPath As Windows.Forms.DataGridView
    Friend WithEvents 選 As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FilePath As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_Delete As Windows.Forms.Button
    Friend WithEvents btn_ClearPath As Windows.Forms.Button
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents tp_DBModifiy As Windows.Forms.TabPage
    Friend WithEvents Panel_DBModifiy As Windows.Forms.Panel
    Friend WithEvents btn_UploadFiles As Windows.Forms.Button
    Friend WithEvents tp_ToDoList As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbo_IssueLevel As UCLComboBoxUC
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents tva_PendingChanges As UCLTreeViewAdvUC
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbo_TFSAddress As UCLComboBoxUC
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txt_TfsUserId As UCLTextBoxUC
    Friend WithEvents txt_TfsPassword As UCLTextBoxUC
    Friend WithEvents btn_LinkTfs As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents ckb_LinkToTFS As Windows.Forms.CheckBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents ulb_WorkSpaces As New Windows.Forms.ListBox()
    Friend WithEvents ckb_Upload As Windows.Forms.CheckBox
    Friend WithEvents rbt_UnProcess As Windows.Forms.RadioButton
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents grb_Note As Windows.Forms.GroupBox
    Friend WithEvents rtb_SANote As Windows.Forms.RichTextBox
    Friend WithEvents gb_SDNote As Windows.Forms.GroupBox
    Friend WithEvents rtb_SDNote As Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel5 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_SD_Cost As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents dtp_SA_DeadLine As UCLDateTimePickerUC
    Friend WithEvents dtp_SD_DeadLine As UCLDateTimePickerUC
    Friend WithEvents txt_SA_Cost As Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_ToDoList As UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel4 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_CostTime As UCLTextBoxUC
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents rbt_Cancel As Windows.Forms.RadioButton
End Class
