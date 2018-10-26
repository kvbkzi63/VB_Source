<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobSAJobListUI
    Inherits Syscom.Client.UCL.BaseFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobSAJobListUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_AssignDateS = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_AssignDateE = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbo_JobMainSD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_SDName = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rbt_SD = New System.Windows.Forms.RadioButton()
        Me.rbt_PG = New System.Windows.Forms.RadioButton()
        Me.cbo_PGName = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rbt_SA = New System.Windows.Forms.RadioButton()
        Me.cbo_SAName = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_Project = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ckb_IsSDConfirm = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_QueryJobList = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_Close = New System.Windows.Forms.RadioButton()
        Me.rbt_UnConfirm = New System.Windows.Forms.RadioButton()
        Me.rbt_UnClose = New System.Windows.Forms.RadioButton()
        Me.rbt_UnProcess = New System.Windows.Forms.RadioButton()
        Me.rbt_All = New System.Windows.Forms.RadioButton()
        Me.ckb_Cancel = New System.Windows.Forms.CheckBox()
        Me.btn_AssignConfirm = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tp_JobList = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_JobList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.gb_SAJobTransfer = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_TransferReason = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_NewPG = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_SAJobTransfer = New System.Windows.Forms.Button()
        Me.tp_IssueList = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_QueryIssue = New System.Windows.Forms.Button()
        Me.btn_SetData = New System.Windows.Forms.Button()
        Me.btn_ClearAndReset = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtp_IssueDateStart = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dgv_IssueRecordList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tp_AssignJob = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtb_Desc = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbt_Presonal = New System.Windows.Forms.RadioButton()
        Me.rbt_IsPublic = New System.Windows.Forms.RadioButton()
        Me.btn_QueryPhrase = New System.Windows.Forms.Button()
        Me.dgv_Phrase = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_DeadLine = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbo_MailGroup = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_SD = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt_EstimateCost = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ckb_TempMailGroup = New System.Windows.Forms.CheckBox()
        Me.cbo_IssueClassify = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_Function = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_Hosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.ckb_NeedTestReport = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_N = New System.Windows.Forms.RadioButton()
        Me.rbt_E = New System.Windows.Forms.RadioButton()
        Me.rbt_R = New System.Windows.Forms.RadioButton()
        Me.Att_Page = New System.Windows.Forms.TabPage()
        Me.dgv_Path = New System.Windows.Forms.DataGridView()
        Me.選 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_SelectFile = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_ClearPath = New System.Windows.Forms.Button()
        Me.SD_Page = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_DeleteFile = New System.Windows.Forms.Button()
        Me.btn_SDConfirm = New System.Windows.Forms.Button()
        Me.btn_ReUploadSpec = New System.Windows.Forms.Button()
        Me.btn_DownloadSpecFile = New System.Windows.Forms.Button()
        Me.btn_AddSpecFile = New System.Windows.Forms.Button()
        Me.dgv_SDSpecPath = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rtb_SDNote = New System.Windows.Forms.RichTextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txt_SD_Cost_Time = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_SD_Estimate_Cost = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dtp_SD_Issue_Deadline = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tp_DBModified = New System.Windows.Forms.TabPage()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_DBModifiedList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel_DBModified = New System.Windows.Forms.Panel()
        Me.tp_MailSetting = New System.Windows.Forms.TabPage()
        Me.Panel_Mail = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderName = New System.Windows.Forms.FolderBrowserDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tp_JobList.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.gb_SAJobTransfer.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.tp_IssueList.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.tp_AssignJob.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.Att_Page.SuspendLayout()
        CType(Me.dgv_Path, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SD_Page.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.tp_DBModified.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tp_MailSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_System, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label22, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_JobMainSD, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Project, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1012, 119)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工作區間"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_AssignDateS, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_AssignDateE, 2, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(81, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(268, 44)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "~"
        '
        'dtp_AssignDateS
        '
        Me.dtp_AssignDateS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_AssignDateS.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_AssignDateS.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_AssignDateS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_AssignDateS.Location = New System.Drawing.Point(3, 8)
        Me.dtp_AssignDateS.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_AssignDateS.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_AssignDateS.Name = "dtp_AssignDateS"
        Me.dtp_AssignDateS.Size = New System.Drawing.Size(116, 27)
        Me.dtp_AssignDateS.TabIndex = 3
        Me.dtp_AssignDateS.uclIsFixedBackColor = False
        Me.dtp_AssignDateS.uclReadOnly = False
        '
        'dtp_AssignDateE
        '
        Me.dtp_AssignDateE.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_AssignDateE.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_AssignDateE.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_AssignDateE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_AssignDateE.Location = New System.Drawing.Point(147, 8)
        Me.dtp_AssignDateE.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_AssignDateE.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_AssignDateE.Name = "dtp_AssignDateE"
        Me.dtp_AssignDateE.Size = New System.Drawing.Size(118, 27)
        Me.dtp_AssignDateE.TabIndex = 4
        Me.dtp_AssignDateE.uclIsFixedBackColor = False
        Me.dtp_AssignDateE.uclReadOnly = False
        '
        'cbo_System
        '
        Me.cbo_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.DroppedDown = False
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(414, 50)
        Me.cbo_System.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_System.MaxLength = 50
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(268, 24)
        Me.cbo_System.TabIndex = 7
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclIsFirstItemEmpty = True
        Me.cbo_System.uclIsTextMode = False
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(355, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "系統別"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 16)
        Me.Label22.TabIndex = 9
        Me.Label22.Text = "主審SD"
        '
        'cbo_JobMainSD
        '
        Me.cbo_JobMainSD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_JobMainSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_JobMainSD.DropDownWidth = 20
        Me.cbo_JobMainSD.DroppedDown = False
        Me.cbo_JobMainSD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_JobMainSD.Location = New System.Drawing.Point(78, 84)
        Me.cbo_JobMainSD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_JobMainSD.MaxLength = 50
        Me.cbo_JobMainSD.Name = "cbo_JobMainSD"
        Me.cbo_JobMainSD.SelectedIndex = -1
        Me.cbo_JobMainSD.SelectedItem = Nothing
        Me.cbo_JobMainSD.SelectedText = ""
        Me.cbo_JobMainSD.SelectedValue = ""
        Me.cbo_JobMainSD.SelectionStart = 0
        Me.cbo_JobMainSD.Size = New System.Drawing.Size(122, 24)
        Me.cbo_JobMainSD.TabIndex = 8
        Me.cbo_JobMainSD.uclDisplayIndex = "0,1"
        Me.cbo_JobMainSD.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_JobMainSD.uclIsAutoClear = True
        Me.cbo_JobMainSD.uclIsFirstItemEmpty = True
        Me.cbo_JobMainSD.uclIsTextMode = False
        Me.cbo_JobMainSD.uclShowMsg = False
        Me.cbo_JobMainSD.uclValueIndex = "0"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel6, 2)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.cbo_SDName, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.rbt_SD, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.rbt_PG, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cbo_PGName, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.rbt_SA, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cbo_SAName, 3, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(355, 77)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(503, 37)
        Me.TableLayoutPanel6.TabIndex = 13
        '
        'cbo_SDName
        '
        Me.cbo_SDName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SDName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SDName.DropDownWidth = 20
        Me.cbo_SDName.DroppedDown = False
        Me.cbo_SDName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SDName.Location = New System.Drawing.Point(381, 6)
        Me.cbo_SDName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SDName.MaxLength = 50
        Me.cbo_SDName.Name = "cbo_SDName"
        Me.cbo_SDName.SelectedIndex = -1
        Me.cbo_SDName.SelectedItem = Nothing
        Me.cbo_SDName.SelectedText = ""
        Me.cbo_SDName.SelectedValue = ""
        Me.cbo_SDName.SelectionStart = 0
        Me.cbo_SDName.Size = New System.Drawing.Size(114, 24)
        Me.cbo_SDName.TabIndex = 14
        Me.cbo_SDName.uclDisplayIndex = "0,1"
        Me.cbo_SDName.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_SDName.uclIsAutoClear = True
        Me.cbo_SDName.uclIsFirstItemEmpty = True
        Me.cbo_SDName.uclIsTextMode = False
        Me.cbo_SDName.uclShowMsg = False
        Me.cbo_SDName.uclValueIndex = "0"
        '
        'rbt_SD
        '
        Me.rbt_SD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_SD.AutoSize = True
        Me.rbt_SD.Location = New System.Drawing.Point(333, 8)
        Me.rbt_SD.Name = "rbt_SD"
        Me.rbt_SD.Size = New System.Drawing.Size(45, 20)
        Me.rbt_SD.TabIndex = 13
        Me.rbt_SD.TabStop = True
        Me.rbt_SD.Text = "SD"
        Me.rbt_SD.UseVisualStyleBackColor = True
        '
        'rbt_PG
        '
        Me.rbt_PG.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_PG.AutoSize = True
        Me.rbt_PG.Checked = True
        Me.rbt_PG.Location = New System.Drawing.Point(3, 8)
        Me.rbt_PG.Name = "rbt_PG"
        Me.rbt_PG.Size = New System.Drawing.Size(45, 20)
        Me.rbt_PG.TabIndex = 10
        Me.rbt_PG.TabStop = True
        Me.rbt_PG.Text = "PG"
        Me.rbt_PG.UseVisualStyleBackColor = True
        '
        'cbo_PGName
        '
        Me.cbo_PGName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_PGName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_PGName.DropDownWidth = 20
        Me.cbo_PGName.DroppedDown = False
        Me.cbo_PGName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_PGName.Location = New System.Drawing.Point(51, 6)
        Me.cbo_PGName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_PGName.MaxLength = 50
        Me.cbo_PGName.Name = "cbo_PGName"
        Me.cbo_PGName.SelectedIndex = -1
        Me.cbo_PGName.SelectedItem = Nothing
        Me.cbo_PGName.SelectedText = ""
        Me.cbo_PGName.SelectedValue = ""
        Me.cbo_PGName.SelectionStart = 0
        Me.cbo_PGName.Size = New System.Drawing.Size(114, 24)
        Me.cbo_PGName.TabIndex = 3
        Me.cbo_PGName.uclDisplayIndex = "0,1"
        Me.cbo_PGName.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_PGName.uclIsAutoClear = True
        Me.cbo_PGName.uclIsFirstItemEmpty = True
        Me.cbo_PGName.uclIsTextMode = False
        Me.cbo_PGName.uclShowMsg = False
        Me.cbo_PGName.uclValueIndex = "0"
        '
        'rbt_SA
        '
        Me.rbt_SA.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_SA.AutoSize = True
        Me.rbt_SA.Location = New System.Drawing.Point(168, 8)
        Me.rbt_SA.Name = "rbt_SA"
        Me.rbt_SA.Size = New System.Drawing.Size(45, 20)
        Me.rbt_SA.TabIndex = 11
        Me.rbt_SA.TabStop = True
        Me.rbt_SA.Text = "SA"
        Me.rbt_SA.UseVisualStyleBackColor = True
        '
        'cbo_SAName
        '
        Me.cbo_SAName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SAName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SAName.DropDownWidth = 20
        Me.cbo_SAName.DroppedDown = False
        Me.cbo_SAName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SAName.Location = New System.Drawing.Point(216, 6)
        Me.cbo_SAName.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SAName.MaxLength = 50
        Me.cbo_SAName.Name = "cbo_SAName"
        Me.cbo_SAName.SelectedIndex = -1
        Me.cbo_SAName.SelectedItem = Nothing
        Me.cbo_SAName.SelectedText = ""
        Me.cbo_SAName.SelectedValue = ""
        Me.cbo_SAName.SelectionStart = 0
        Me.cbo_SAName.Size = New System.Drawing.Size(114, 24)
        Me.cbo_SAName.TabIndex = 12
        Me.cbo_SAName.uclDisplayIndex = "0,1"
        Me.cbo_SAName.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_SAName.uclIsAutoClear = True
        Me.cbo_SAName.uclIsFirstItemEmpty = True
        Me.cbo_SAName.uclIsTextMode = False
        Me.cbo_SAName.uclShowMsg = False
        Me.cbo_SAName.uclValueIndex = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "所屬專案"
        '
        'cbo_Project
        '
        Me.cbo_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Project.DropDownWidth = 20
        Me.cbo_Project.DroppedDown = False
        Me.cbo_Project.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Project.Location = New System.Drawing.Point(78, 50)
        Me.cbo_Project.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Project.MaxLength = 50
        Me.cbo_Project.Name = "cbo_Project"
        Me.cbo_Project.SelectedIndex = -1
        Me.cbo_Project.SelectedItem = Nothing
        Me.cbo_Project.SelectedText = ""
        Me.cbo_Project.SelectedValue = ""
        Me.cbo_Project.SelectionStart = 0
        Me.cbo_Project.Size = New System.Drawing.Size(268, 24)
        Me.cbo_Project.TabIndex = 14
        Me.cbo_Project.uclDisplayIndex = "0,1"
        Me.cbo_Project.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_Project.uclIsAutoClear = True
        Me.cbo_Project.uclIsFirstItemEmpty = True
        Me.cbo_Project.uclIsTextMode = False
        Me.cbo_Project.uclShowMsg = False
        Me.cbo_Project.uclValueIndex = "0"
        '
        'ckb_IsSDConfirm
        '
        Me.ckb_IsSDConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_IsSDConfirm.AutoSize = True
        Me.ckb_IsSDConfirm.Location = New System.Drawing.Point(105, 6)
        Me.ckb_IsSDConfirm.Name = "ckb_IsSDConfirm"
        Me.ckb_IsSDConfirm.Size = New System.Drawing.Size(130, 20)
        Me.ckb_IsSDConfirm.TabIndex = 8
        Me.ckb_IsSDConfirm.Text = "SD未覆核通過 "
        Me.ckb_IsSDConfirm.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_QueryJobList)
        Me.FlowLayoutPanel1.Controls.Add(Me.ckb_IsSDConfirm)
        Me.FlowLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 119)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1012, 34)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btn_QueryJobList
        '
        Me.btn_QueryJobList.Location = New System.Drawing.Point(3, 3)
        Me.btn_QueryJobList.Name = "btn_QueryJobList"
        Me.btn_QueryJobList.Size = New System.Drawing.Size(96, 27)
        Me.btn_QueryJobList.TabIndex = 0
        Me.btn_QueryJobList.Text = "查詢"
        Me.btn_QueryJobList.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_Close)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_UnConfirm)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_UnClose)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_UnProcess)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_All)
        Me.FlowLayoutPanel3.Controls.Add(Me.ckb_Cancel)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(241, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(557, 27)
        Me.FlowLayoutPanel3.TabIndex = 9
        '
        'rbt_Close
        '
        Me.rbt_Close.AutoSize = True
        Me.rbt_Close.Location = New System.Drawing.Point(3, 3)
        Me.rbt_Close.Name = "rbt_Close"
        Me.rbt_Close.Size = New System.Drawing.Size(74, 20)
        Me.rbt_Close.TabIndex = 0
        Me.rbt_Close.Text = "已結案"
        Me.rbt_Close.UseVisualStyleBackColor = True
        '
        'rbt_UnConfirm
        '
        Me.rbt_UnConfirm.AutoSize = True
        Me.rbt_UnConfirm.Location = New System.Drawing.Point(83, 3)
        Me.rbt_UnConfirm.Name = "rbt_UnConfirm"
        Me.rbt_UnConfirm.Size = New System.Drawing.Size(122, 20)
        Me.rbt_UnConfirm.TabIndex = 4
        Me.rbt_UnConfirm.Text = "已提交未確認"
        Me.rbt_UnConfirm.UseVisualStyleBackColor = True
        '
        'rbt_UnClose
        '
        Me.rbt_UnClose.AutoSize = True
        Me.rbt_UnClose.Checked = True
        Me.rbt_UnClose.Location = New System.Drawing.Point(211, 3)
        Me.rbt_UnClose.Name = "rbt_UnClose"
        Me.rbt_UnClose.Size = New System.Drawing.Size(74, 20)
        Me.rbt_UnClose.TabIndex = 1
        Me.rbt_UnClose.TabStop = True
        Me.rbt_UnClose.Text = "未結案"
        Me.rbt_UnClose.UseVisualStyleBackColor = True
        '
        'rbt_UnProcess
        '
        Me.rbt_UnProcess.AutoSize = True
        Me.rbt_UnProcess.Location = New System.Drawing.Point(291, 3)
        Me.rbt_UnProcess.Name = "rbt_UnProcess"
        Me.rbt_UnProcess.Size = New System.Drawing.Size(74, 20)
        Me.rbt_UnProcess.TabIndex = 5
        Me.rbt_UnProcess.Text = "未提交"
        Me.rbt_UnProcess.UseVisualStyleBackColor = True
        '
        'rbt_All
        '
        Me.rbt_All.AutoSize = True
        Me.rbt_All.Location = New System.Drawing.Point(371, 3)
        Me.rbt_All.Name = "rbt_All"
        Me.rbt_All.Size = New System.Drawing.Size(58, 20)
        Me.rbt_All.TabIndex = 2
        Me.rbt_All.Text = "全部"
        Me.rbt_All.UseVisualStyleBackColor = True
        '
        'ckb_Cancel
        '
        Me.ckb_Cancel.AutoSize = True
        Me.ckb_Cancel.Location = New System.Drawing.Point(435, 3)
        Me.ckb_Cancel.Name = "ckb_Cancel"
        Me.ckb_Cancel.Size = New System.Drawing.Size(75, 20)
        Me.ckb_Cancel.TabIndex = 3
        Me.ckb_Cancel.Text = "已作廢"
        Me.ckb_Cancel.UseVisualStyleBackColor = True
        '
        'btn_AssignConfirm
        '
        Me.btn_AssignConfirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_AssignConfirm.Location = New System.Drawing.Point(652, 103)
        Me.btn_AssignConfirm.Name = "btn_AssignConfirm"
        Me.btn_AssignConfirm.Size = New System.Drawing.Size(96, 27)
        Me.btn_AssignConfirm.TabIndex = 1
        Me.btn_AssignConfirm.Text = "派工送出"
        Me.btn_AssignConfirm.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tp_JobList)
        Me.TabControl1.Controls.Add(Me.tp_IssueList)
        Me.TabControl1.Controls.Add(Me.tp_AssignJob)
        Me.TabControl1.Controls.Add(Me.tp_DBModified)
        Me.TabControl1.Controls.Add(Me.tp_MailSetting)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 153)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1012, 435)
        Me.TabControl1.TabIndex = 2
        '
        'tp_JobList
        '
        Me.tp_JobList.Controls.Add(Me.TableLayoutPanel5)
        Me.tp_JobList.Location = New System.Drawing.Point(4, 26)
        Me.tp_JobList.Name = "tp_JobList"
        Me.tp_JobList.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_JobList.Size = New System.Drawing.Size(1004, 405)
        Me.tp_JobList.TabIndex = 0
        Me.tp_JobList.Text = "已派工作清單"
        Me.tp_JobList.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.dgv_JobList, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.gb_SAJobTransfer, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(998, 399)
        Me.TableLayoutPanel5.TabIndex = 4
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
        Me.dgv_JobList.Location = New System.Drawing.Point(4, 70)
        Me.dgv_JobList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_JobList.MultiSelect = False
        Me.dgv_JobList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_JobList.Name = "dgv_JobList"
        Me.dgv_JobList.RowHeadersWidth = 41
        Me.dgv_JobList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_JobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_JobList.Size = New System.Drawing.Size(990, 325)
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
        Me.dgv_JobList.uclIsSortable = True
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
        'gb_SAJobTransfer
        '
        Me.gb_SAJobTransfer.Controls.Add(Me.FlowLayoutPanel6)
        Me.gb_SAJobTransfer.Enabled = False
        Me.gb_SAJobTransfer.Location = New System.Drawing.Point(3, 3)
        Me.gb_SAJobTransfer.Name = "gb_SAJobTransfer"
        Me.gb_SAJobTransfer.Size = New System.Drawing.Size(990, 60)
        Me.gb_SAJobTransfer.TabIndex = 1
        Me.gb_SAJobTransfer.TabStop = False
        Me.gb_SAJobTransfer.Text = "工作轉派"
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.Label23)
        Me.FlowLayoutPanel6.Controls.Add(Me.txt_TransferReason)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel6.Controls.Add(Me.cbo_NewPG)
        Me.FlowLayoutPanel6.Controls.Add(Me.btn_SAJobTransfer)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(3, 23)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(984, 34)
        Me.FlowLayoutPanel6.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 16)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "原因"
        '
        'txt_TransferReason
        '
        Me.txt_TransferReason.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_TransferReason.HideSelection = True
        Me.txt_TransferReason.Location = New System.Drawing.Point(49, 3)
        Me.txt_TransferReason.MaxLength = 100
        Me.txt_TransferReason.Name = "txt_TransferReason"
        Me.txt_TransferReason.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_TransferReason.SelectionStart = 0
        Me.txt_TransferReason.Size = New System.Drawing.Size(652, 27)
        Me.txt_TransferReason.TabIndex = 4
        Me.txt_TransferReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_TransferReason.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_TransferReason.ToolTipTag = Nothing
        Me.txt_TransferReason.uclDollarSign = False
        Me.txt_TransferReason.uclDotCount = 0
        Me.txt_TransferReason.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_TransferReason.uclIntCount = 2
        Me.txt_TransferReason.uclMinus = False
        Me.txt_TransferReason.uclReadOnly = False
        Me.txt_TransferReason.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_TransferReason.uclTransferForFractions = False
        Me.txt_TransferReason.uclTrimZero = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(707, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "轉至"
        '
        'cbo_NewPG
        '
        Me.cbo_NewPG.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_NewPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_NewPG.DropDownWidth = 20
        Me.cbo_NewPG.DroppedDown = False
        Me.cbo_NewPG.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_NewPG.Location = New System.Drawing.Point(750, 4)
        Me.cbo_NewPG.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_NewPG.MaxLength = 50
        Me.cbo_NewPG.Name = "cbo_NewPG"
        Me.cbo_NewPG.SelectedIndex = -1
        Me.cbo_NewPG.SelectedItem = Nothing
        Me.cbo_NewPG.SelectedText = ""
        Me.cbo_NewPG.SelectedValue = ""
        Me.cbo_NewPG.SelectionStart = 0
        Me.cbo_NewPG.Size = New System.Drawing.Size(114, 24)
        Me.cbo_NewPG.TabIndex = 1
        Me.cbo_NewPG.uclDisplayIndex = "0,1"
        Me.cbo_NewPG.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_NewPG.uclIsAutoClear = True
        Me.cbo_NewPG.uclIsFirstItemEmpty = True
        Me.cbo_NewPG.uclIsTextMode = False
        Me.cbo_NewPG.uclShowMsg = False
        Me.cbo_NewPG.uclValueIndex = "0"
        '
        'btn_SAJobTransfer
        '
        Me.btn_SAJobTransfer.Location = New System.Drawing.Point(867, 3)
        Me.btn_SAJobTransfer.Name = "btn_SAJobTransfer"
        Me.btn_SAJobTransfer.Size = New System.Drawing.Size(91, 27)
        Me.btn_SAJobTransfer.TabIndex = 0
        Me.btn_SAJobTransfer.Text = "確定轉派"
        Me.btn_SAJobTransfer.UseVisualStyleBackColor = True
        '
        'tp_IssueList
        '
        Me.tp_IssueList.Controls.Add(Me.TableLayoutPanel7)
        Me.tp_IssueList.Location = New System.Drawing.Point(4, 26)
        Me.tp_IssueList.Name = "tp_IssueList"
        Me.tp_IssueList.Size = New System.Drawing.Size(1004, 405)
        Me.tp_IssueList.TabIndex = 4
        Me.tp_IssueList.Text = "問題清單"
        Me.tp_IssueList.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.FlowLayoutPanel5, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.dgv_IssueRecordList, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.876543!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.12346!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1004, 405)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_QueryIssue)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_SetData)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_ClearAndReset)
        Me.FlowLayoutPanel5.Controls.Add(Me.Label24)
        Me.FlowLayoutPanel5.Controls.Add(Me.dtp_IssueDateStart)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(998, 33)
        Me.FlowLayoutPanel5.TabIndex = 2
        '
        'btn_QueryIssue
        '
        Me.btn_QueryIssue.Location = New System.Drawing.Point(3, 3)
        Me.btn_QueryIssue.Name = "btn_QueryIssue"
        Me.btn_QueryIssue.Size = New System.Drawing.Size(96, 27)
        Me.btn_QueryIssue.TabIndex = 2
        Me.btn_QueryIssue.Text = "重新查詢"
        Me.btn_QueryIssue.UseVisualStyleBackColor = True
        '
        'btn_SetData
        '
        Me.btn_SetData.Location = New System.Drawing.Point(105, 3)
        Me.btn_SetData.Name = "btn_SetData"
        Me.btn_SetData.Size = New System.Drawing.Size(96, 27)
        Me.btn_SetData.TabIndex = 0
        Me.btn_SetData.Text = "帶入派工"
        Me.btn_SetData.UseVisualStyleBackColor = True
        '
        'btn_ClearAndReset
        '
        Me.btn_ClearAndReset.Location = New System.Drawing.Point(207, 3)
        Me.btn_ClearAndReset.Name = "btn_ClearAndReset"
        Me.btn_ClearAndReset.Size = New System.Drawing.Size(96, 27)
        Me.btn_ClearAndReset.TabIndex = 1
        Me.btn_ClearAndReset.Text = "清除重選"
        Me.btn_ClearAndReset.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(309, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 16)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "提出日(起~今)"
        '
        'dtp_IssueDateStart
        '
        Me.dtp_IssueDateStart.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_IssueDateStart.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_IssueDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_IssueDateStart.Location = New System.Drawing.Point(421, 3)
        Me.dtp_IssueDateStart.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_IssueDateStart.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_IssueDateStart.Name = "dtp_IssueDateStart"
        Me.dtp_IssueDateStart.Size = New System.Drawing.Size(132, 27)
        Me.dtp_IssueDateStart.TabIndex = 3
        Me.dtp_IssueDateStart.uclIsFixedBackColor = False
        Me.dtp_IssueDateStart.uclReadOnly = False
        '
        'dgv_IssueRecordList
        '
        Me.dgv_IssueRecordList.AllowUserToAddRows = False
        Me.dgv_IssueRecordList.AllowUserToOrderColumns = False
        Me.dgv_IssueRecordList.AllowUserToResizeColumns = True
        Me.dgv_IssueRecordList.AllowUserToResizeRows = False
        Me.dgv_IssueRecordList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_IssueRecordList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_IssueRecordList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_IssueRecordList.ColumnHeadersHeight = 4
        Me.dgv_IssueRecordList.ColumnHeadersVisible = True
        Me.dgv_IssueRecordList.CurrentCell = Nothing
        Me.dgv_IssueRecordList.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_IssueRecordList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_IssueRecordList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_IssueRecordList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_IssueRecordList.Location = New System.Drawing.Point(6, 44)
        Me.dgv_IssueRecordList.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_IssueRecordList.MultiSelect = True
        Me.dgv_IssueRecordList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_IssueRecordList.Name = "dgv_IssueRecordList"
        Me.dgv_IssueRecordList.RowHeadersWidth = 41
        Me.dgv_IssueRecordList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_IssueRecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_IssueRecordList.Size = New System.Drawing.Size(992, 356)
        Me.dgv_IssueRecordList.TabIndex = 1
        Me.dgv_IssueRecordList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_IssueRecordList.uclBatchColIndex = ""
        Me.dgv_IssueRecordList.uclClickToCheck = False
        Me.dgv_IssueRecordList.uclColumnAlignment = ""
        Me.dgv_IssueRecordList.uclColumnCheckBox = True
        Me.dgv_IssueRecordList.uclColumnControlType = ""
        Me.dgv_IssueRecordList.uclColumnWidth = ""
        Me.dgv_IssueRecordList.uclDoCellEnter = True
        Me.dgv_IssueRecordList.uclHasNewRow = False
        Me.dgv_IssueRecordList.uclHeaderText = ""
        Me.dgv_IssueRecordList.uclIsAlternatingRowsColors = True
        Me.dgv_IssueRecordList.uclIsComboBoxGridQuery = True
        Me.dgv_IssueRecordList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_IssueRecordList.uclIsDoOrderCheck = True
        Me.dgv_IssueRecordList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_IssueRecordList.uclIsSortable = False
        Me.dgv_IssueRecordList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_IssueRecordList.uclNonVisibleColIndex = ""
        Me.dgv_IssueRecordList.uclReadOnly = False
        Me.dgv_IssueRecordList.uclSelectedCellBorder = False
        Me.dgv_IssueRecordList.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_IssueRecordList.uclSelectedCellBorderSize = 4
        Me.dgv_IssueRecordList.uclSelectedFirstShowCol = 0
        Me.dgv_IssueRecordList.uclSelectedLastShowCol = -1
        Me.dgv_IssueRecordList.uclShowCellBorder = False
        Me.dgv_IssueRecordList.uclSortColIndex = ""
        Me.dgv_IssueRecordList.uclTreeMode = False
        Me.dgv_IssueRecordList.uclVisibleColIndex = ""
        '
        'tp_AssignJob
        '
        Me.tp_AssignJob.Controls.Add(Me.TabControl2)
        Me.tp_AssignJob.Location = New System.Drawing.Point(4, 26)
        Me.tp_AssignJob.Name = "tp_AssignJob"
        Me.tp_AssignJob.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_AssignJob.Size = New System.Drawing.Size(1004, 405)
        Me.tp_AssignJob.TabIndex = 1
        Me.tp_AssignJob.Text = "一般派工"
        Me.tp_AssignJob.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.Att_Page)
        Me.TabControl2.Controls.Add(Me.SD_Page)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(998, 399)
        Me.TabControl2.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(990, 369)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "派工明細"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 140)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 226)
        Me.SplitContainer1.SplitterDistance = 429
        Me.SplitContainer1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtb_Desc)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 226)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "備註"
        '
        'rtb_Desc
        '
        Me.rtb_Desc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Desc.Location = New System.Drawing.Point(3, 23)
        Me.rtb_Desc.Name = "rtb_Desc"
        Me.rtb_Desc.Size = New System.Drawing.Size(423, 200)
        Me.rtb_Desc.TabIndex = 0
        Me.rtb_Desc.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(551, 226)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "片語"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel9, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.dgv_Phrase, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.10526!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.89474!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(545, 200)
        Me.TableLayoutPanel8.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Controls.Add(Me.rbt_Presonal, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.rbt_IsPublic, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btn_QueryPhrase, 2, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(539, 38)
        Me.TableLayoutPanel9.TabIndex = 0
        '
        'rbt_Presonal
        '
        Me.rbt_Presonal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_Presonal.AutoSize = True
        Me.rbt_Presonal.Checked = True
        Me.rbt_Presonal.Location = New System.Drawing.Point(3, 9)
        Me.rbt_Presonal.Name = "rbt_Presonal"
        Me.rbt_Presonal.Size = New System.Drawing.Size(122, 20)
        Me.rbt_Presonal.TabIndex = 0
        Me.rbt_Presonal.TabStop = True
        Me.rbt_Presonal.Text = "個人常用片語"
        Me.rbt_Presonal.UseVisualStyleBackColor = True
        '
        'rbt_IsPublic
        '
        Me.rbt_IsPublic.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_IsPublic.AutoSize = True
        Me.rbt_IsPublic.Location = New System.Drawing.Point(131, 9)
        Me.rbt_IsPublic.Name = "rbt_IsPublic"
        Me.rbt_IsPublic.Size = New System.Drawing.Size(90, 20)
        Me.rbt_IsPublic.TabIndex = 1
        Me.rbt_IsPublic.Text = "共用片語"
        Me.rbt_IsPublic.UseVisualStyleBackColor = True
        '
        'btn_QueryPhrase
        '
        Me.btn_QueryPhrase.Location = New System.Drawing.Point(227, 3)
        Me.btn_QueryPhrase.Name = "btn_QueryPhrase"
        Me.btn_QueryPhrase.Size = New System.Drawing.Size(96, 27)
        Me.btn_QueryPhrase.TabIndex = 2
        Me.btn_QueryPhrase.Text = "查詢"
        Me.btn_QueryPhrase.UseVisualStyleBackColor = True
        '
        'dgv_Phrase
        '
        Me.dgv_Phrase.AllowUserToAddRows = False
        Me.dgv_Phrase.AllowUserToOrderColumns = False
        Me.dgv_Phrase.AllowUserToResizeColumns = True
        Me.dgv_Phrase.AllowUserToResizeRows = False
        Me.dgv_Phrase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_Phrase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Phrase.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_Phrase.ColumnHeadersHeight = 4
        Me.dgv_Phrase.ColumnHeadersVisible = True
        Me.dgv_Phrase.CurrentCell = Nothing
        Me.dgv_Phrase.DataSource = Nothing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Phrase.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_Phrase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Phrase.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Phrase.Location = New System.Drawing.Point(3, 47)
        Me.dgv_Phrase.MultiSelect = False
        Me.dgv_Phrase.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Phrase.Name = "dgv_Phrase"
        Me.dgv_Phrase.RowHeadersWidth = 41
        Me.dgv_Phrase.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Phrase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Phrase.Size = New System.Drawing.Size(539, 150)
        Me.dgv_Phrase.TabIndex = 1
        Me.dgv_Phrase.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Phrase.uclBatchColIndex = ""
        Me.dgv_Phrase.uclClickToCheck = False
        Me.dgv_Phrase.uclColumnAlignment = ""
        Me.dgv_Phrase.uclColumnCheckBox = False
        Me.dgv_Phrase.uclColumnControlType = ""
        Me.dgv_Phrase.uclColumnWidth = ""
        Me.dgv_Phrase.uclDoCellEnter = True
        Me.dgv_Phrase.uclHasNewRow = False
        Me.dgv_Phrase.uclHeaderText = ""
        Me.dgv_Phrase.uclIsAlternatingRowsColors = True
        Me.dgv_Phrase.uclIsComboBoxGridQuery = True
        Me.dgv_Phrase.uclIsComboxClickTriggerDropDown = False
        Me.dgv_Phrase.uclIsDoOrderCheck = True
        Me.dgv_Phrase.uclIsDoQueryComboBoxGrid = True
        Me.dgv_Phrase.uclIsSortable = False
        Me.dgv_Phrase.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Phrase.uclNonVisibleColIndex = ""
        Me.dgv_Phrase.uclReadOnly = False
        Me.dgv_Phrase.uclSelectedCellBorder = False
        Me.dgv_Phrase.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_Phrase.uclSelectedCellBorderSize = 4
        Me.dgv_Phrase.uclSelectedFirstShowCol = 0
        Me.dgv_Phrase.uclSelectedLastShowCol = -1
        Me.dgv_Phrase.uclShowCellBorder = False
        Me.dgv_Phrase.uclSortColIndex = ""
        Me.dgv_Phrase.uclTreeMode = False
        Me.dgv_Phrase.uclVisibleColIndex = ""
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.dtp_DeadLine, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_Subject, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cbo_MailGroup, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.cbo_SD, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_AssignConfirm, 4, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel4, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.ckb_TempMailGroup, 5, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cbo_IssueClassify, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbo_Function, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbo_Hosp, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_Clear, 5, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.ckb_NeedTestReport, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel7, 4, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.56391!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.56391!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(984, 137)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(19, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "所屬醫院"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "預計完成日"
        '
        'dtp_DeadLine
        '
        Me.dtp_DeadLine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_DeadLine.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_DeadLine.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_DeadLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_DeadLine.Location = New System.Drawing.Point(97, 31)
        Me.dtp_DeadLine.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_DeadLine.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_DeadLine.Name = "dtp_DeadLine"
        Me.dtp_DeadLine.Size = New System.Drawing.Size(151, 27)
        Me.dtp_DeadLine.TabIndex = 10
        Me.dtp_DeadLine.uclIsFixedBackColor = False
        Me.dtp_DeadLine.uclReadOnly = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(286, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "需求主旨"
        '
        'txt_Subject
        '
        Me.txt_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Subject.Location = New System.Drawing.Point(364, 31)
        Me.txt_Subject.MaxLength = 20
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.Size = New System.Drawing.Size(278, 27)
        Me.txt_Subject.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "郵件群組"
        '
        'cbo_MailGroup
        '
        Me.cbo_MailGroup.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_MailGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_MailGroup.DropDownWidth = 20
        Me.cbo_MailGroup.DroppedDown = False
        Me.cbo_MailGroup.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_MailGroup.Location = New System.Drawing.Point(94, 67)
        Me.cbo_MailGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_MailGroup.MaxLength = 50
        Me.cbo_MailGroup.Name = "cbo_MailGroup"
        Me.cbo_MailGroup.SelectedIndex = -1
        Me.cbo_MailGroup.SelectedItem = Nothing
        Me.cbo_MailGroup.SelectedText = ""
        Me.cbo_MailGroup.SelectedValue = ""
        Me.cbo_MailGroup.SelectionStart = 0
        Me.cbo_MailGroup.Size = New System.Drawing.Size(157, 24)
        Me.cbo_MailGroup.TabIndex = 15
        Me.cbo_MailGroup.uclDisplayIndex = "0,1"
        Me.cbo_MailGroup.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_MailGroup.uclIsAutoClear = True
        Me.cbo_MailGroup.uclIsFirstItemEmpty = True
        Me.cbo_MailGroup.uclIsTextMode = False
        Me.cbo_MailGroup.uclShowMsg = False
        Me.cbo_MailGroup.uclValueIndex = "0"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.Label12, 2)
        Me.Label12.ForeColor = System.Drawing.Color.Orange
        Me.Label12.Location = New System.Drawing.Point(254, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(392, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "設定郵件群組後，在派工與提交時皆會發信給相關人員"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "權責SD"
        '
        'cbo_SD
        '
        Me.cbo_SD.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SD.DropDownWidth = 20
        Me.cbo_SD.DroppedDown = False
        Me.cbo_SD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SD.Location = New System.Drawing.Point(94, 105)
        Me.cbo_SD.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SD.MaxLength = 50
        Me.cbo_SD.Name = "cbo_SD"
        Me.cbo_SD.SelectedIndex = -1
        Me.cbo_SD.SelectedItem = Nothing
        Me.cbo_SD.SelectedText = ""
        Me.cbo_SD.SelectedValue = ""
        Me.cbo_SD.SelectionStart = 0
        Me.cbo_SD.Size = New System.Drawing.Size(154, 24)
        Me.cbo_SD.TabIndex = 19
        Me.cbo_SD.uclDisplayIndex = "0,1"
        Me.cbo_SD.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_SD.uclIsAutoClear = True
        Me.cbo_SD.uclIsFirstItemEmpty = True
        Me.cbo_SD.uclIsTextMode = False
        Me.cbo_SD.uclShowMsg = False
        Me.cbo_SD.uclValueIndex = "0"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(254, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "需求評估時間"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.txt_EstimateCost)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(364, 100)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(278, 33)
        Me.FlowLayoutPanel4.TabIndex = 21
        '
        'txt_EstimateCost
        '
        Me.txt_EstimateCost.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_EstimateCost.HideSelection = True
        Me.txt_EstimateCost.Location = New System.Drawing.Point(3, 3)
        Me.txt_EstimateCost.MaxLength = 10
        Me.txt_EstimateCost.Name = "txt_EstimateCost"
        Me.txt_EstimateCost.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_EstimateCost.SelectionStart = 0
        Me.txt_EstimateCost.Size = New System.Drawing.Size(129, 27)
        Me.txt_EstimateCost.TabIndex = 2
        Me.txt_EstimateCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_EstimateCost.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_EstimateCost.ToolTipTag = Nothing
        Me.txt_EstimateCost.uclDollarSign = False
        Me.txt_EstimateCost.uclDotCount = 3
        Me.txt_EstimateCost.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_EstimateCost.uclIntCount = 5
        Me.txt_EstimateCost.uclMinus = False
        Me.txt_EstimateCost.uclReadOnly = False
        Me.txt_EstimateCost.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_EstimateCost.uclTransferForFractions = False
        Me.txt_EstimateCost.uclTrimZero = True
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(138, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "人日"
        '
        'ckb_TempMailGroup
        '
        Me.ckb_TempMailGroup.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_TempMailGroup.AutoSize = True
        Me.ckb_TempMailGroup.ForeColor = System.Drawing.Color.Red
        Me.ckb_TempMailGroup.Location = New System.Drawing.Point(781, 69)
        Me.ckb_TempMailGroup.Name = "ckb_TempMailGroup"
        Me.ckb_TempMailGroup.Size = New System.Drawing.Size(191, 20)
        Me.ckb_TempMailGroup.TabIndex = 22
        Me.ckb_TempMailGroup.Text = "臨時郵件群組(請慎用!!)"
        Me.ckb_TempMailGroup.UseVisualStyleBackColor = True
        '
        'cbo_IssueClassify
        '
        Me.cbo_IssueClassify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IssueClassify.FormattingEnabled = True
        Me.cbo_IssueClassify.Items.AddRange(New Object() {"需求", "BUG", "需求+BUG"})
        Me.cbo_IssueClassify.Location = New System.Drawing.Point(781, 3)
        Me.cbo_IssueClassify.Name = "cbo_IssueClassify"
        Me.cbo_IssueClassify.Size = New System.Drawing.Size(154, 24)
        Me.cbo_IssueClassify.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(703, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "需求類別"
        '
        'cbo_Function
        '
        Me.cbo_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Function.DropDownWidth = 20
        Me.cbo_Function.DroppedDown = False
        Me.cbo_Function.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Function.Location = New System.Drawing.Point(361, 1)
        Me.cbo_Function.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Function.MaxLength = 50
        Me.cbo_Function.Name = "cbo_Function"
        Me.cbo_Function.SelectedIndex = -1
        Me.cbo_Function.SelectedItem = Nothing
        Me.cbo_Function.SelectedText = ""
        Me.cbo_Function.SelectedValue = ""
        Me.cbo_Function.SelectionStart = 0
        Me.cbo_Function.Size = New System.Drawing.Size(157, 24)
        Me.cbo_Function.TabIndex = 9
        Me.cbo_Function.uclDisplayIndex = "0,1"
        Me.cbo_Function.uclImeMode = System.Windows.Forms.ImeMode.[On]
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
        Me.Label6.Location = New System.Drawing.Point(286, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "歸屬功能"
        '
        'cbo_Hosp
        '
        Me.cbo_Hosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Hosp.DropDownWidth = 20
        Me.cbo_Hosp.DroppedDown = False
        Me.cbo_Hosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Hosp.Location = New System.Drawing.Point(94, 0)
        Me.cbo_Hosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Hosp.MaxLength = 50
        Me.cbo_Hosp.Name = "cbo_Hosp"
        Me.cbo_Hosp.SelectedIndex = -1
        Me.cbo_Hosp.SelectedItem = Nothing
        Me.cbo_Hosp.SelectedText = ""
        Me.cbo_Hosp.SelectedValue = ""
        Me.cbo_Hosp.SelectionStart = 0
        Me.cbo_Hosp.Size = New System.Drawing.Size(157, 24)
        Me.cbo_Hosp.TabIndex = 24
        Me.cbo_Hosp.uclDisplayIndex = "0,1"
        Me.cbo_Hosp.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_Hosp.uclIsAutoClear = True
        Me.cbo_Hosp.uclIsFirstItemEmpty = True
        Me.cbo_Hosp.uclIsTextMode = False
        Me.cbo_Hosp.uclShowMsg = False
        Me.cbo_Hosp.uclValueIndex = "0"
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Location = New System.Drawing.Point(781, 103)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_Clear.TabIndex = 2
        Me.btn_Clear.Text = "清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'ckb_NeedTestReport
        '
        Me.ckb_NeedTestReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_NeedTestReport.AutoSize = True
        Me.ckb_NeedTestReport.Location = New System.Drawing.Point(652, 69)
        Me.ckb_NeedTestReport.Name = "ckb_NeedTestReport"
        Me.ckb_NeedTestReport.Size = New System.Drawing.Size(123, 20)
        Me.ckb_NeedTestReport.TabIndex = 17
        Me.ckb_NeedTestReport.Text = "需附測試報告"
        Me.ckb_NeedTestReport.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel7
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.FlowLayoutPanel7, 2)
        Me.FlowLayoutPanel7.Controls.Add(Me.rbt_N)
        Me.FlowLayoutPanel7.Controls.Add(Me.rbt_E)
        Me.FlowLayoutPanel7.Controls.Add(Me.rbt_R)
        Me.FlowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(652, 30)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(329, 29)
        Me.FlowLayoutPanel7.TabIndex = 25
        '
        'rbt_N
        '
        Me.rbt_N.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_N.AutoSize = True
        Me.rbt_N.Checked = True
        Me.rbt_N.Location = New System.Drawing.Point(3, 3)
        Me.rbt_N.Name = "rbt_N"
        Me.rbt_N.Size = New System.Drawing.Size(90, 20)
        Me.rbt_N.TabIndex = 2
        Me.rbt_N.TabStop = True
        Me.rbt_N.Text = "【一般】"
        Me.rbt_N.UseVisualStyleBackColor = True
        '
        'rbt_E
        '
        Me.rbt_E.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_E.AutoSize = True
        Me.rbt_E.Location = New System.Drawing.Point(99, 3)
        Me.rbt_E.Name = "rbt_E"
        Me.rbt_E.Size = New System.Drawing.Size(74, 20)
        Me.rbt_E.TabIndex = 0
        Me.rbt_E.Text = "【急】"
        Me.rbt_E.UseVisualStyleBackColor = True
        '
        'rbt_R
        '
        Me.rbt_R.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_R.AutoSize = True
        Me.rbt_R.Location = New System.Drawing.Point(179, 3)
        Me.rbt_R.Name = "rbt_R"
        Me.rbt_R.Size = New System.Drawing.Size(74, 20)
        Me.rbt_R.TabIndex = 1
        Me.rbt_R.Text = "【補】"
        Me.rbt_R.UseVisualStyleBackColor = True
        '
        'Att_Page
        '
        Me.Att_Page.Controls.Add(Me.dgv_Path)
        Me.Att_Page.Controls.Add(Me.FlowLayoutPanel2)
        Me.Att_Page.Location = New System.Drawing.Point(4, 26)
        Me.Att_Page.Name = "Att_Page"
        Me.Att_Page.Size = New System.Drawing.Size(990, 369)
        Me.Att_Page.TabIndex = 1
        Me.Att_Page.Text = "插入附件"
        Me.Att_Page.UseVisualStyleBackColor = True
        '
        'dgv_Path
        '
        Me.dgv_Path.AllowUserToAddRows = False
        Me.dgv_Path.AllowUserToDeleteRows = False
        Me.dgv_Path.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Path.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Path.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選, Me.FilePath})
        Me.dgv_Path.Location = New System.Drawing.Point(0, 34)
        Me.dgv_Path.Name = "dgv_Path"
        Me.dgv_Path.RowTemplate.Height = 24
        Me.dgv_Path.Size = New System.Drawing.Size(990, 354)
        Me.dgv_Path.TabIndex = 1
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
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_SelectFile)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_ClearPath)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(990, 34)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'btn_SelectFile
        '
        Me.btn_SelectFile.Location = New System.Drawing.Point(3, 3)
        Me.btn_SelectFile.Name = "btn_SelectFile"
        Me.btn_SelectFile.Size = New System.Drawing.Size(96, 27)
        Me.btn_SelectFile.TabIndex = 0
        Me.btn_SelectFile.Text = "選擇檔案"
        Me.btn_SelectFile.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(105, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(96, 27)
        Me.btn_Delete.TabIndex = 1
        Me.btn_Delete.Text = "移除所選"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_ClearPath
        '
        Me.btn_ClearPath.Location = New System.Drawing.Point(207, 3)
        Me.btn_ClearPath.Name = "btn_ClearPath"
        Me.btn_ClearPath.Size = New System.Drawing.Size(96, 27)
        Me.btn_ClearPath.TabIndex = 2
        Me.btn_ClearPath.Text = "清除"
        Me.btn_ClearPath.UseVisualStyleBackColor = True
        '
        'SD_Page
        '
        Me.SD_Page.Controls.Add(Me.TableLayoutPanel4)
        Me.SD_Page.Location = New System.Drawing.Point(4, 26)
        Me.SD_Page.Name = "SD_Page"
        Me.SD_Page.Padding = New System.Windows.Forms.Padding(3)
        Me.SD_Page.Size = New System.Drawing.Size(990, 369)
        Me.SD_Page.TabIndex = 2
        Me.SD_Page.Text = "派工覆核(SD)"
        Me.SD_Page.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.16922!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.83079!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dgv_SDSpecPath, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox2, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 1, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(6, 6)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.92593!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.07407!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(981, 376)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_DeleteFile)
        Me.Panel3.Controls.Add(Me.btn_SDConfirm)
        Me.Panel3.Controls.Add(Me.btn_ReUploadSpec)
        Me.Panel3.Controls.Add(Me.btn_DownloadSpecFile)
        Me.Panel3.Controls.Add(Me.btn_AddSpecFile)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.TableLayoutPanel4.SetRowSpan(Me.Panel3, 3)
        Me.Panel3.Size = New System.Drawing.Size(133, 370)
        Me.Panel3.TabIndex = 3
        '
        'btn_DeleteFile
        '
        Me.btn_DeleteFile.Enabled = False
        Me.btn_DeleteFile.Location = New System.Drawing.Point(4, 69)
        Me.btn_DeleteFile.Name = "btn_DeleteFile"
        Me.btn_DeleteFile.Size = New System.Drawing.Size(126, 27)
        Me.btn_DeleteFile.TabIndex = 4
        Me.btn_DeleteFile.Text = "刪除檔案"
        Me.btn_DeleteFile.UseVisualStyleBackColor = True
        '
        'btn_SDConfirm
        '
        Me.btn_SDConfirm.Location = New System.Drawing.Point(4, 339)
        Me.btn_SDConfirm.Name = "btn_SDConfirm"
        Me.btn_SDConfirm.Size = New System.Drawing.Size(126, 27)
        Me.btn_SDConfirm.TabIndex = 3
        Me.btn_SDConfirm.Text = "確認派工"
        Me.btn_SDConfirm.UseVisualStyleBackColor = True
        '
        'btn_ReUploadSpec
        '
        Me.btn_ReUploadSpec.Enabled = False
        Me.btn_ReUploadSpec.Location = New System.Drawing.Point(4, 102)
        Me.btn_ReUploadSpec.Name = "btn_ReUploadSpec"
        Me.btn_ReUploadSpec.Size = New System.Drawing.Size(126, 27)
        Me.btn_ReUploadSpec.TabIndex = 2
        Me.btn_ReUploadSpec.Text = "Spec補正上傳"
        Me.btn_ReUploadSpec.UseVisualStyleBackColor = True
        '
        'btn_DownloadSpecFile
        '
        Me.btn_DownloadSpecFile.Location = New System.Drawing.Point(4, 3)
        Me.btn_DownloadSpecFile.Name = "btn_DownloadSpecFile"
        Me.btn_DownloadSpecFile.Size = New System.Drawing.Size(126, 27)
        Me.btn_DownloadSpecFile.TabIndex = 0
        Me.btn_DownloadSpecFile.Text = "下載Spec附件"
        Me.btn_DownloadSpecFile.UseVisualStyleBackColor = True
        '
        'btn_AddSpecFile
        '
        Me.btn_AddSpecFile.Location = New System.Drawing.Point(4, 36)
        Me.btn_AddSpecFile.Name = "btn_AddSpecFile"
        Me.btn_AddSpecFile.Size = New System.Drawing.Size(126, 27)
        Me.btn_AddSpecFile.TabIndex = 1
        Me.btn_AddSpecFile.Text = "新增檔案"
        Me.btn_AddSpecFile.UseVisualStyleBackColor = True
        '
        'dgv_SDSpecPath
        '
        Me.dgv_SDSpecPath.AllowUserToAddRows = False
        Me.dgv_SDSpecPath.AllowUserToOrderColumns = False
        Me.dgv_SDSpecPath.AllowUserToResizeColumns = True
        Me.dgv_SDSpecPath.AllowUserToResizeRows = False
        Me.dgv_SDSpecPath.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_SDSpecPath.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SDSpecPath.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_SDSpecPath.ColumnHeadersHeight = 4
        Me.dgv_SDSpecPath.ColumnHeadersVisible = True
        Me.dgv_SDSpecPath.CurrentCell = Nothing
        Me.dgv_SDSpecPath.DataSource = Nothing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SDSpecPath.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_SDSpecPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SDSpecPath.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SDSpecPath.Location = New System.Drawing.Point(148, 7)
        Me.dgv_SDSpecPath.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.dgv_SDSpecPath.MultiSelect = True
        Me.dgv_SDSpecPath.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SDSpecPath.Name = "dgv_SDSpecPath"
        Me.dgv_SDSpecPath.RowHeadersWidth = 41
        Me.dgv_SDSpecPath.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SDSpecPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SDSpecPath.Size = New System.Drawing.Size(824, 75)
        Me.dgv_SDSpecPath.TabIndex = 4
        Me.dgv_SDSpecPath.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SDSpecPath.uclBatchColIndex = ""
        Me.dgv_SDSpecPath.uclClickToCheck = False
        Me.dgv_SDSpecPath.uclColumnAlignment = ""
        Me.dgv_SDSpecPath.uclColumnCheckBox = True
        Me.dgv_SDSpecPath.uclColumnControlType = ""
        Me.dgv_SDSpecPath.uclColumnWidth = ""
        Me.dgv_SDSpecPath.uclDoCellEnter = True
        Me.dgv_SDSpecPath.uclHasNewRow = False
        Me.dgv_SDSpecPath.uclHeaderText = ""
        Me.dgv_SDSpecPath.uclIsAlternatingRowsColors = True
        Me.dgv_SDSpecPath.uclIsComboBoxGridQuery = True
        Me.dgv_SDSpecPath.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SDSpecPath.uclIsDoOrderCheck = True
        Me.dgv_SDSpecPath.uclIsDoQueryComboBoxGrid = True
        Me.dgv_SDSpecPath.uclIsSortable = False
        Me.dgv_SDSpecPath.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SDSpecPath.uclNonVisibleColIndex = ""
        Me.dgv_SDSpecPath.uclReadOnly = False
        Me.dgv_SDSpecPath.uclSelectedCellBorder = False
        Me.dgv_SDSpecPath.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_SDSpecPath.uclSelectedCellBorderSize = 4
        Me.dgv_SDSpecPath.uclSelectedFirstShowCol = 0
        Me.dgv_SDSpecPath.uclSelectedLastShowCol = -1
        Me.dgv_SDSpecPath.uclShowCellBorder = False
        Me.dgv_SDSpecPath.uclSortColIndex = ""
        Me.dgv_SDSpecPath.uclTreeMode = False
        Me.dgv_SDSpecPath.uclVisibleColIndex = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Location = New System.Drawing.Point(142, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(836, 235)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SD備註"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rtb_SDNote)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(830, 209)
        Me.Panel4.TabIndex = 0
        '
        'rtb_SDNote
        '
        Me.rtb_SDNote.Location = New System.Drawing.Point(3, 3)
        Me.rtb_SDNote.Name = "rtb_SDNote"
        Me.rtb_SDNote.Size = New System.Drawing.Size(824, 203)
        Me.rtb_SDNote.TabIndex = 0
        Me.rtb_SDNote.Text = ""
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txt_SD_Cost_Time)
        Me.Panel5.Controls.Add(Me.txt_SD_Estimate_Cost)
        Me.Panel5.Controls.Add(Me.dtp_SD_Issue_Deadline)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Location = New System.Drawing.Point(142, 92)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(836, 35)
        Me.Panel5.TabIndex = 6
        '
        'txt_SD_Cost_Time
        '
        Me.txt_SD_Cost_Time.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SD_Cost_Time.HideSelection = True
        Me.txt_SD_Cost_Time.Location = New System.Drawing.Point(100, 4)
        Me.txt_SD_Cost_Time.MaxLength = 10
        Me.txt_SD_Cost_Time.Name = "txt_SD_Cost_Time"
        Me.txt_SD_Cost_Time.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SD_Cost_Time.SelectionStart = 0
        Me.txt_SD_Cost_Time.Size = New System.Drawing.Size(59, 27)
        Me.txt_SD_Cost_Time.TabIndex = 9
        Me.txt_SD_Cost_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SD_Cost_Time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SD_Cost_Time.ToolTipTag = Nothing
        Me.txt_SD_Cost_Time.uclDollarSign = False
        Me.txt_SD_Cost_Time.uclDotCount = 1
        Me.txt_SD_Cost_Time.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_SD_Cost_Time.uclIntCount = 2
        Me.txt_SD_Cost_Time.uclMinus = False
        Me.txt_SD_Cost_Time.uclReadOnly = False
        Me.txt_SD_Cost_Time.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_SD_Cost_Time.uclTransferForFractions = False
        Me.txt_SD_Cost_Time.uclTrimZero = True
        '
        'txt_SD_Estimate_Cost
        '
        Me.txt_SD_Estimate_Cost.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SD_Estimate_Cost.HideSelection = True
        Me.txt_SD_Estimate_Cost.Location = New System.Drawing.Point(348, 4)
        Me.txt_SD_Estimate_Cost.MaxLength = 10
        Me.txt_SD_Estimate_Cost.Name = "txt_SD_Estimate_Cost"
        Me.txt_SD_Estimate_Cost.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SD_Estimate_Cost.SelectionStart = 0
        Me.txt_SD_Estimate_Cost.Size = New System.Drawing.Size(58, 27)
        Me.txt_SD_Estimate_Cost.TabIndex = 8
        Me.txt_SD_Estimate_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SD_Estimate_Cost.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SD_Estimate_Cost.ToolTipTag = Nothing
        Me.txt_SD_Estimate_Cost.uclDollarSign = False
        Me.txt_SD_Estimate_Cost.uclDotCount = 3
        Me.txt_SD_Estimate_Cost.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_SD_Estimate_Cost.uclIntCount = 5
        Me.txt_SD_Estimate_Cost.uclMinus = False
        Me.txt_SD_Estimate_Cost.uclReadOnly = False
        Me.txt_SD_Estimate_Cost.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_SD_Estimate_Cost.uclTransferForFractions = False
        Me.txt_SD_Estimate_Cost.uclTrimZero = True
        '
        'dtp_SD_Issue_Deadline
        '
        Me.dtp_SD_Issue_Deadline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_SD_Issue_Deadline.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_SD_Issue_Deadline.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_SD_Issue_Deadline.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_SD_Issue_Deadline.Location = New System.Drawing.Point(572, 4)
        Me.dtp_SD_Issue_Deadline.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_SD_Issue_Deadline.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_SD_Issue_Deadline.Name = "dtp_SD_Issue_Deadline"
        Me.dtp_SD_Issue_Deadline.Size = New System.Drawing.Size(118, 27)
        Me.dtp_SD_Issue_Deadline.TabIndex = 7
        Me.dtp_SD_Issue_Deadline.uclIsFixedBackColor = False
        Me.dtp_SD_Issue_Deadline.uclReadOnly = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(459, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 16)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "SD預估完成日:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(408, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "人日"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(215, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 16)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "SD預計完成人日:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(163, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "人日"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "SD確認時間:"
        '
        'tp_DBModified
        '
        Me.tp_DBModified.Controls.Add(Me.TabControl3)
        Me.tp_DBModified.Location = New System.Drawing.Point(4, 26)
        Me.tp_DBModified.Name = "tp_DBModified"
        Me.tp_DBModified.Size = New System.Drawing.Size(1004, 405)
        Me.tp_DBModified.TabIndex = 3
        Me.tp_DBModified.Text = "DB異動申請"
        Me.tp_DBModified.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage1)
        Me.TabControl3.Controls.Add(Me.TabPage2)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(0, 0)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(1004, 405)
        Me.TabControl3.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(996, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "申請紀錄"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgv_DBModifiedList)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(987, 379)
        Me.Panel2.TabIndex = 0
        '
        'dgv_DBModifiedList
        '
        Me.dgv_DBModifiedList.AllowUserToAddRows = False
        Me.dgv_DBModifiedList.AllowUserToOrderColumns = False
        Me.dgv_DBModifiedList.AllowUserToResizeColumns = True
        Me.dgv_DBModifiedList.AllowUserToResizeRows = False
        Me.dgv_DBModifiedList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_DBModifiedList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_DBModifiedList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_DBModifiedList.ColumnHeadersHeight = 4
        Me.dgv_DBModifiedList.ColumnHeadersVisible = True
        Me.dgv_DBModifiedList.CurrentCell = Nothing
        Me.dgv_DBModifiedList.DataSource = Nothing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_DBModifiedList.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_DBModifiedList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_DBModifiedList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_DBModifiedList.Location = New System.Drawing.Point(0, 0)
        Me.dgv_DBModifiedList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_DBModifiedList.MultiSelect = False
        Me.dgv_DBModifiedList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_DBModifiedList.Name = "dgv_DBModifiedList"
        Me.dgv_DBModifiedList.RowHeadersWidth = 41
        Me.dgv_DBModifiedList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_DBModifiedList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DBModifiedList.Size = New System.Drawing.Size(987, 379)
        Me.dgv_DBModifiedList.TabIndex = 0
        Me.dgv_DBModifiedList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_DBModifiedList.uclBatchColIndex = ""
        Me.dgv_DBModifiedList.uclClickToCheck = False
        Me.dgv_DBModifiedList.uclColumnAlignment = ""
        Me.dgv_DBModifiedList.uclColumnCheckBox = False
        Me.dgv_DBModifiedList.uclColumnControlType = ""
        Me.dgv_DBModifiedList.uclColumnWidth = ""
        Me.dgv_DBModifiedList.uclDoCellEnter = True
        Me.dgv_DBModifiedList.uclHasNewRow = False
        Me.dgv_DBModifiedList.uclHeaderText = ""
        Me.dgv_DBModifiedList.uclIsAlternatingRowsColors = True
        Me.dgv_DBModifiedList.uclIsComboBoxGridQuery = True
        Me.dgv_DBModifiedList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_DBModifiedList.uclIsDoOrderCheck = True
        Me.dgv_DBModifiedList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_DBModifiedList.uclIsSortable = False
        Me.dgv_DBModifiedList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_DBModifiedList.uclNonVisibleColIndex = ""
        Me.dgv_DBModifiedList.uclReadOnly = False
        Me.dgv_DBModifiedList.uclSelectedCellBorder = False
        Me.dgv_DBModifiedList.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_DBModifiedList.uclSelectedCellBorderSize = 4
        Me.dgv_DBModifiedList.uclSelectedFirstShowCol = 0
        Me.dgv_DBModifiedList.uclSelectedLastShowCol = -1
        Me.dgv_DBModifiedList.uclShowCellBorder = False
        Me.dgv_DBModifiedList.uclSortColIndex = ""
        Me.dgv_DBModifiedList.uclTreeMode = False
        Me.dgv_DBModifiedList.uclVisibleColIndex = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel_DBModified)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(996, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "提出申請"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel_DBModified
        '
        Me.Panel_DBModified.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_DBModified.Location = New System.Drawing.Point(3, 3)
        Me.Panel_DBModified.Name = "Panel_DBModified"
        Me.Panel_DBModified.Size = New System.Drawing.Size(990, 369)
        Me.Panel_DBModified.TabIndex = 0
        '
        'tp_MailSetting
        '
        Me.tp_MailSetting.Controls.Add(Me.Panel_Mail)
        Me.tp_MailSetting.Location = New System.Drawing.Point(4, 26)
        Me.tp_MailSetting.Name = "tp_MailSetting"
        Me.tp_MailSetting.Size = New System.Drawing.Size(1004, 405)
        Me.tp_MailSetting.TabIndex = 2
        Me.tp_MailSetting.Text = "郵件群組設定"
        Me.tp_MailSetting.UseVisualStyleBackColor = True
        '
        'Panel_Mail
        '
        Me.Panel_Mail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Mail.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Mail.Name = "Panel_Mail"
        Me.Panel_Mail.Size = New System.Drawing.Size(1004, 405)
        Me.Panel_Mail.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'JobSAJobListUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 588)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Name = "JobSAJobListUI"
        Me.TabText = "JobSAJobListUI"
        Me.Text = "JobSAJobListUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tp_JobList.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.gb_SAJobTransfer.ResumeLayout(False)
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.tp_IssueList.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.tp_AssignJob.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.Att_Page.ResumeLayout(False)
        CType(Me.dgv_Path, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.SD_Page.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.tp_DBModified.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.tp_MailSetting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbo_PGName As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_QueryJobList As Windows.Forms.Button
    Friend WithEvents btn_AssignConfirm As Windows.Forms.Button
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents tp_JobList As Windows.Forms.TabPage
    Friend WithEvents tp_AssignJob As Windows.Forms.TabPage
    Friend WithEvents TabControl2 As Windows.Forms.TabControl
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents Att_Page As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents cbo_IssueClassify As Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rtb_Desc As Windows.Forms.RichTextBox
    Friend WithEvents dgv_Path As Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_SelectFile As Windows.Forms.Button
    Friend WithEvents btn_Delete As Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents btn_ClearPath As Windows.Forms.Button
    Friend WithEvents 選 As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FilePath As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tp_MailSetting As Windows.Forms.TabPage
    Friend WithEvents dtp_AssignDateS As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_AssignDateE As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cbo_Function As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dtp_DeadLine As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dgv_JobList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FolderName As Windows.Forms.FolderBrowserDialog
    Friend WithEvents tp_DBModified As Windows.Forms.TabPage
    Friend WithEvents Panel_DBModified As Windows.Forms.Panel
    Friend WithEvents TabControl3 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents dgv_DBModifiedList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txt_Subject As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents cbo_MailGroup As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Panel_Mail As Windows.Forms.Panel
    Friend WithEvents ckb_NeedTestReport As Windows.Forms.CheckBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cbo_SD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents SD_Page As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel4 As Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_DownloadSpecFile As Windows.Forms.Button
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents btn_ReUploadSpec As Windows.Forms.Button
    Friend WithEvents btn_AddSpecFile As Windows.Forms.Button
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents rtb_SDNote As Windows.Forms.RichTextBox
    Friend WithEvents btn_SDConfirm As Windows.Forms.Button
    Friend WithEvents dgv_SDSpecPath As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_DeleteFile As Windows.Forms.Button
    Friend WithEvents ckb_IsSDConfirm As Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel3 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_Close As Windows.Forms.RadioButton
    Friend WithEvents rbt_UnClose As Windows.Forms.RadioButton
    Friend WithEvents rbt_All As Windows.Forms.RadioButton
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel4 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents dtp_SD_Issue_Deadline As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents ckb_TempMailGroup As Windows.Forms.CheckBox
    Friend WithEvents ckb_Cancel As Windows.Forms.CheckBox
    Friend WithEvents rbt_UnConfirm As Windows.Forms.RadioButton
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents cbo_Hosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents cbo_JobMainSD As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents rbt_UnProcess As Windows.Forms.RadioButton
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel6 As Windows.Forms.TableLayoutPanel
    Friend WithEvents cbo_SDName As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents rbt_SD As Windows.Forms.RadioButton
    Friend WithEvents rbt_PG As Windows.Forms.RadioButton
    Friend WithEvents rbt_SA As Windows.Forms.RadioButton
    Friend WithEvents cbo_SAName As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents tp_IssueList As Windows.Forms.TabPage
    Friend WithEvents dgv_IssueRecordList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel5 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_SetData As Windows.Forms.Button
    Friend WithEvents btn_ClearAndReset As Windows.Forms.Button
    Friend WithEvents btn_QueryIssue As Windows.Forms.Button
    Friend WithEvents btn_Clear As Windows.Forms.Button
    Friend WithEvents gb_SAJobTransfer As Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel6 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbo_NewPG As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_SAJobTransfer As Windows.Forms.Button
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents txt_TransferReason As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_Project As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents dtp_IssueDateStart As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel8 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As Windows.Forms.TableLayoutPanel
    Friend WithEvents rbt_Presonal As Windows.Forms.RadioButton
    Friend WithEvents rbt_IsPublic As Windows.Forms.RadioButton
    Friend WithEvents btn_QueryPhrase As Windows.Forms.Button
    Friend WithEvents dgv_Phrase As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents txt_SD_Estimate_Cost As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_SD_Cost_Time As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_EstimateCost As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents FlowLayoutPanel7 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_N As Windows.Forms.RadioButton
    Friend WithEvents rbt_E As Windows.Forms.RadioButton
    Friend WithEvents rbt_R As Windows.Forms.RadioButton
End Class
