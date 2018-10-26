<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobServiceRecordUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobServiceRecordUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_Issue = New System.Windows.Forms.TableLayoutPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_Issue_Source = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbo_IssueClassify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_ReceiveDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_ReceiveTime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cbo_Contact_Way = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Contact_Note = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_Note = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_Processing_Approach = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_Issue_Description = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbo_Processing_Employee_Code = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbo_Issue_Status = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_Processing_Cost = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_Contact_User = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtp_Estimated_Finish_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Function = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbo_Project = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_Hosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_IssueList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_CreateIssueRecord = New System.Windows.Forms.Button()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.btn_ClearIssue = New System.Windows.Forms.Button()
        Me.btn_UploadAtt = New System.Windows.Forms.Button()
        Me.txt_UploadPath = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tlp_RejectMain = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rdb_Close = New System.Windows.Forms.RadioButton()
        Me.rdb_Reject = New System.Windows.Forms.RadioButton()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.btn_ClearReject = New System.Windows.Forms.Button()
        Me.grb_Reason = New System.Windows.Forms.GroupBox()
        Me.rtb_Reason = New System.Windows.Forms.RichTextBox()
        Me.dgv_RejectRecord = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tlp_Query = New System.Windows.Forms.TableLayoutPanel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_QueryProjectId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_QuerySystemCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_QueryFunctionCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.dtp_SDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_EDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.cbo_QueryIssueStatus = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbo_QueryHosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbo_QueryProcessingEmployee = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Export = New System.Windows.Forms.Button()
        Me.txt_JobCode = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tlp_Issue.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlp_RejectMain.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.grb_Reason.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tlp_Query.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_Issue
        '
        Me.tlp_Issue.ColumnCount = 8
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Issue.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217.0!))
        Me.tlp_Issue.Controls.Add(Me.Label15, 0, 3)
        Me.tlp_Issue.Controls.Add(Me.Label6, 0, 1)
        Me.tlp_Issue.Controls.Add(Me.cbo_Issue_Source, 1, 1)
        Me.tlp_Issue.Controls.Add(Me.Label13, 2, 1)
        Me.tlp_Issue.Controls.Add(Me.cbo_IssueClassify, 3, 1)
        Me.tlp_Issue.Controls.Add(Me.Label5, 0, 2)
        Me.tlp_Issue.Controls.Add(Me.dtp_ReceiveDate, 1, 2)
        Me.tlp_Issue.Controls.Add(Me.Label4, 2, 2)
        Me.tlp_Issue.Controls.Add(Me.txt_ReceiveTime, 3, 2)
        Me.tlp_Issue.Controls.Add(Me.cbo_Contact_Way, 1, 3)
        Me.tlp_Issue.Controls.Add(Me.Label14, 2, 3)
        Me.tlp_Issue.Controls.Add(Me.txt_Contact_Note, 3, 3)
        Me.tlp_Issue.Controls.Add(Me.Label17, 0, 7)
        Me.tlp_Issue.Controls.Add(Me.txt_Note, 1, 7)
        Me.tlp_Issue.Controls.Add(Me.Label16, 0, 6)
        Me.tlp_Issue.Controls.Add(Me.txt_Processing_Approach, 1, 6)
        Me.tlp_Issue.Controls.Add(Me.Label21, 0, 5)
        Me.tlp_Issue.Controls.Add(Me.txt_Issue_Description, 1, 5)
        Me.tlp_Issue.Controls.Add(Me.Label19, 0, 4)
        Me.tlp_Issue.Controls.Add(Me.cbo_Processing_Employee_Code, 1, 4)
        Me.tlp_Issue.Controls.Add(Me.Label22, 2, 4)
        Me.tlp_Issue.Controls.Add(Me.cbo_Issue_Status, 3, 4)
        Me.tlp_Issue.Controls.Add(Me.Label23, 4, 4)
        Me.tlp_Issue.Controls.Add(Me.txt_Processing_Cost, 5, 4)
        Me.tlp_Issue.Controls.Add(Me.Label20, 4, 3)
        Me.tlp_Issue.Controls.Add(Me.txt_Contact_User, 5, 3)
        Me.tlp_Issue.Controls.Add(Me.Label18, 4, 2)
        Me.tlp_Issue.Controls.Add(Me.dtp_Estimated_Finish_Date, 5, 2)
        Me.tlp_Issue.Controls.Add(Me.Label3, 4, 1)
        Me.tlp_Issue.Controls.Add(Me.cbo_Function, 5, 1)
        Me.tlp_Issue.Controls.Add(Me.cbo_System, 5, 0)
        Me.tlp_Issue.Controls.Add(Me.Label2, 4, 0)
        Me.tlp_Issue.Controls.Add(Me.Label1, 2, 0)
        Me.tlp_Issue.Controls.Add(Me.Label24, 0, 0)
        Me.tlp_Issue.Controls.Add(Me.cbo_Project, 3, 0)
        Me.tlp_Issue.Controls.Add(Me.cbo_Hosp, 1, 0)
        Me.tlp_Issue.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Issue.Location = New System.Drawing.Point(3, 3)
        Me.tlp_Issue.Name = "tlp_Issue"
        Me.tlp_Issue.RowCount = 8
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Issue.Size = New System.Drawing.Size(950, 415)
        Me.tlp_Issue.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "聯絡方式"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(3, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "需求來源"
        '
        'cbo_Issue_Source
        '
        Me.cbo_Issue_Source.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Issue_Source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Issue_Source.DropDownWidth = 20
        Me.cbo_Issue_Source.DroppedDown = False
        Me.cbo_Issue_Source.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Issue_Source.Location = New System.Drawing.Point(78, 27)
        Me.cbo_Issue_Source.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Issue_Source.Name = "cbo_Issue_Source"
        Me.cbo_Issue_Source.SelectedIndex = -1
        Me.cbo_Issue_Source.SelectedItem = Nothing
        Me.cbo_Issue_Source.SelectedText = ""
        Me.cbo_Issue_Source.SelectedValue = ""
        Me.cbo_Issue_Source.SelectionStart = 0
        Me.cbo_Issue_Source.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Issue_Source.TabIndex = 14
        Me.cbo_Issue_Source.uclDisplayIndex = "0,1"
        Me.cbo_Issue_Source.uclIsAutoClear = True
        Me.cbo_Issue_Source.uclIsFirstItemEmpty = True
        Me.cbo_Issue_Source.uclIsTextMode = False
        Me.cbo_Issue_Source.uclShowMsg = False
        Me.cbo_Issue_Source.uclValueIndex = "0"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(228, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "需求類別"
        '
        'cbo_IssueClassify
        '
        Me.cbo_IssueClassify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IssueClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IssueClassify.DropDownWidth = 20
        Me.cbo_IssueClassify.DroppedDown = False
        Me.cbo_IssueClassify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IssueClassify.ForeColor = System.Drawing.Color.Red
        Me.cbo_IssueClassify.Location = New System.Drawing.Point(303, 27)
        Me.cbo_IssueClassify.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IssueClassify.Name = "cbo_IssueClassify"
        Me.cbo_IssueClassify.SelectedIndex = -1
        Me.cbo_IssueClassify.SelectedItem = Nothing
        Me.cbo_IssueClassify.SelectedText = ""
        Me.cbo_IssueClassify.SelectedValue = ""
        Me.cbo_IssueClassify.SelectionStart = 0
        Me.cbo_IssueClassify.Size = New System.Drawing.Size(132, 27)
        Me.cbo_IssueClassify.TabIndex = 11
        Me.cbo_IssueClassify.uclDisplayIndex = "0,1"
        Me.cbo_IssueClassify.uclIsAutoClear = True
        Me.cbo_IssueClassify.uclIsFirstItemEmpty = True
        Me.cbo_IssueClassify.uclIsTextMode = False
        Me.cbo_IssueClassify.uclShowMsg = False
        Me.cbo_IssueClassify.uclValueIndex = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(3, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "提出日期"
        '
        'dtp_ReceiveDate
        '
        Me.dtp_ReceiveDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_ReceiveDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_ReceiveDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_ReceiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_ReceiveDate.Location = New System.Drawing.Point(81, 57)
        Me.dtp_ReceiveDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_ReceiveDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_ReceiveDate.Name = "dtp_ReceiveDate"
        Me.dtp_ReceiveDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_ReceiveDate.TabIndex = 8
        Me.dtp_ReceiveDate.uclIsFixedBackColor = False
        Me.dtp_ReceiveDate.uclReadOnly = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(228, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "提出時間"
        '
        'txt_ReceiveTime
        '
        Me.txt_ReceiveTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReceiveTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ReceiveTime.Location = New System.Drawing.Point(306, 57)
        Me.txt_ReceiveTime.MaxLength = 10
        Me.txt_ReceiveTime.Name = "txt_ReceiveTime"
        Me.txt_ReceiveTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ReceiveTime.SelectionStart = 0
        Me.txt_ReceiveTime.Size = New System.Drawing.Size(67, 27)
        Me.txt_ReceiveTime.TabIndex = 9
        Me.txt_ReceiveTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ReceiveTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ReceiveTime.ToolTipTag = Nothing
        Me.txt_ReceiveTime.uclDollarSign = False
        Me.txt_ReceiveTime.uclDotCount = 0
        Me.txt_ReceiveTime.uclIntCount = 2
        Me.txt_ReceiveTime.uclMinus = False
        Me.txt_ReceiveTime.uclReadOnly = False
        Me.txt_ReceiveTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        Me.txt_ReceiveTime.uclTrimZero = True
        '
        'cbo_Contact_Way
        '
        Me.cbo_Contact_Way.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Contact_Way.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Contact_Way.DropDownWidth = 20
        Me.cbo_Contact_Way.DroppedDown = False
        Me.cbo_Contact_Way.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Contact_Way.Location = New System.Drawing.Point(78, 90)
        Me.cbo_Contact_Way.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Contact_Way.Name = "cbo_Contact_Way"
        Me.cbo_Contact_Way.SelectedIndex = -1
        Me.cbo_Contact_Way.SelectedItem = Nothing
        Me.cbo_Contact_Way.SelectedText = ""
        Me.cbo_Contact_Way.SelectedValue = ""
        Me.cbo_Contact_Way.SelectionStart = 0
        Me.cbo_Contact_Way.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Contact_Way.TabIndex = 18
        Me.cbo_Contact_Way.uclDisplayIndex = "0,1"
        Me.cbo_Contact_Way.uclIsAutoClear = True
        Me.cbo_Contact_Way.uclIsFirstItemEmpty = True
        Me.cbo_Contact_Way.uclIsTextMode = False
        Me.cbo_Contact_Way.uclShowMsg = False
        Me.cbo_Contact_Way.uclValueIndex = "0"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(219, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 16)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "電話/EMail"
        '
        'txt_Contact_Note
        '
        Me.txt_Contact_Note.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Contact_Note.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Contact_Note.Location = New System.Drawing.Point(306, 90)
        Me.txt_Contact_Note.MaxLength = 100
        Me.txt_Contact_Note.Name = "txt_Contact_Note"
        Me.txt_Contact_Note.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Contact_Note.SelectionStart = 0
        Me.txt_Contact_Note.Size = New System.Drawing.Size(207, 27)
        Me.txt_Contact_Note.TabIndex = 17
        Me.txt_Contact_Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Contact_Note.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Contact_Note.ToolTipTag = Nothing
        Me.txt_Contact_Note.uclDollarSign = False
        Me.txt_Contact_Note.uclDotCount = 0
        Me.txt_Contact_Note.uclIntCount = 2
        Me.txt_Contact_Note.uclMinus = False
        Me.txt_Contact_Note.uclReadOnly = False
        Me.txt_Contact_Note.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Contact_Note.uclTrimZero = True
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 366)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "備註"
        '
        'txt_Note
        '
        Me.tlp_Issue.SetColumnSpan(Me.txt_Note, 3)
        Me.txt_Note.Location = New System.Drawing.Point(84, 339)
        Me.txt_Note.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Note.Name = "txt_Note"
        Me.txt_Note.Size = New System.Drawing.Size(429, 65)
        Me.txt_Note.TabIndex = 22
        Me.txt_Note.uclMaxLength = 1000
        Me.txt_Note.uclReadOnly = False
        Me.txt_Note.uclWordWrap = True
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 284)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "處理過程"
        '
        'txt_Processing_Approach
        '
        Me.tlp_Issue.SetColumnSpan(Me.txt_Processing_Approach, 3)
        Me.txt_Processing_Approach.Location = New System.Drawing.Point(82, 255)
        Me.txt_Processing_Approach.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Processing_Approach.Name = "txt_Processing_Approach"
        Me.txt_Processing_Approach.Size = New System.Drawing.Size(434, 75)
        Me.txt_Processing_Approach.TabIndex = 21
        Me.txt_Processing_Approach.uclMaxLength = 1000
        Me.txt_Processing_Approach.uclReadOnly = False
        Me.txt_Processing_Approach.uclWordWrap = True
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(3, 194)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 16)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "問題描述"
        '
        'txt_Issue_Description
        '
        Me.tlp_Issue.SetColumnSpan(Me.txt_Issue_Description, 3)
        Me.txt_Issue_Description.Location = New System.Drawing.Point(84, 158)
        Me.txt_Issue_Description.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Issue_Description.Name = "txt_Issue_Description"
        Me.txt_Issue_Description.Size = New System.Drawing.Size(429, 88)
        Me.txt_Issue_Description.TabIndex = 30
        Me.txt_Issue_Description.uclMaxLength = 1000
        Me.txt_Issue_Description.uclReadOnly = False
        Me.txt_Issue_Description.uclWordWrap = True
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(3, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "處理人員"
        '
        'cbo_Processing_Employee_Code
        '
        Me.cbo_Processing_Employee_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Processing_Employee_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Processing_Employee_Code.DropDownWidth = 20
        Me.cbo_Processing_Employee_Code.DroppedDown = False
        Me.cbo_Processing_Employee_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Processing_Employee_Code.Location = New System.Drawing.Point(78, 123)
        Me.cbo_Processing_Employee_Code.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Processing_Employee_Code.Name = "cbo_Processing_Employee_Code"
        Me.cbo_Processing_Employee_Code.SelectedIndex = -1
        Me.cbo_Processing_Employee_Code.SelectedItem = Nothing
        Me.cbo_Processing_Employee_Code.SelectedText = ""
        Me.cbo_Processing_Employee_Code.SelectedValue = ""
        Me.cbo_Processing_Employee_Code.SelectionStart = 0
        Me.cbo_Processing_Employee_Code.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Processing_Employee_Code.TabIndex = 27
        Me.cbo_Processing_Employee_Code.uclDisplayIndex = "0,1"
        Me.cbo_Processing_Employee_Code.uclIsAutoClear = True
        Me.cbo_Processing_Employee_Code.uclIsFirstItemEmpty = True
        Me.cbo_Processing_Employee_Code.uclIsTextMode = False
        Me.cbo_Processing_Employee_Code.uclShowMsg = False
        Me.cbo_Processing_Employee_Code.uclValueIndex = "0"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(228, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 16)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "處理狀況"
        '
        'cbo_Issue_Status
        '
        Me.cbo_Issue_Status.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Issue_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Issue_Status.DropDownWidth = 20
        Me.cbo_Issue_Status.DroppedDown = False
        Me.cbo_Issue_Status.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Issue_Status.Location = New System.Drawing.Point(303, 123)
        Me.cbo_Issue_Status.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Issue_Status.Name = "cbo_Issue_Status"
        Me.cbo_Issue_Status.SelectedIndex = -1
        Me.cbo_Issue_Status.SelectedItem = Nothing
        Me.cbo_Issue_Status.SelectedText = ""
        Me.cbo_Issue_Status.SelectedValue = ""
        Me.cbo_Issue_Status.SelectionStart = 0
        Me.cbo_Issue_Status.Size = New System.Drawing.Size(212, 27)
        Me.cbo_Issue_Status.TabIndex = 32
        Me.cbo_Issue_Status.uclDisplayIndex = "0,1"
        Me.cbo_Issue_Status.uclIsAutoClear = True
        Me.cbo_Issue_Status.uclIsFirstItemEmpty = True
        Me.cbo_Issue_Status.uclIsTextMode = False
        Me.cbo_Issue_Status.uclShowMsg = False
        Me.cbo_Issue_Status.uclValueIndex = "0"
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(552, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(95, 16)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "處理工時(hr)"
        '
        'txt_Processing_Cost
        '
        Me.txt_Processing_Cost.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Processing_Cost.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Processing_Cost.Location = New System.Drawing.Point(653, 123)
        Me.txt_Processing_Cost.MaxLength = 100
        Me.txt_Processing_Cost.Name = "txt_Processing_Cost"
        Me.txt_Processing_Cost.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Processing_Cost.SelectionStart = 0
        Me.txt_Processing_Cost.Size = New System.Drawing.Size(129, 27)
        Me.txt_Processing_Cost.TabIndex = 34
        Me.txt_Processing_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Processing_Cost.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Processing_Cost.ToolTipTag = Nothing
        Me.txt_Processing_Cost.uclDollarSign = False
        Me.txt_Processing_Cost.uclDotCount = 1
        Me.txt_Processing_Cost.uclIntCount = 2
        Me.txt_Processing_Cost.uclMinus = False
        Me.txt_Processing_Cost.uclReadOnly = False
        Me.txt_Processing_Cost.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_Processing_Cost.uclTrimZero = True
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(523, 95)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 16)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "提出單位/使用者"
        '
        'txt_Contact_User
        '
        Me.txt_Contact_User.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Contact_User.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Contact_User.Location = New System.Drawing.Point(653, 90)
        Me.txt_Contact_User.MaxLength = 50
        Me.txt_Contact_User.Name = "txt_Contact_User"
        Me.txt_Contact_User.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Contact_User.SelectionStart = 0
        Me.txt_Contact_User.Size = New System.Drawing.Size(129, 27)
        Me.txt_Contact_User.TabIndex = 26
        Me.txt_Contact_User.TabStop = False
        Me.txt_Contact_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Contact_User.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Contact_User.ToolTipTag = Nothing
        Me.txt_Contact_User.uclDollarSign = False
        Me.txt_Contact_User.uclDotCount = 0
        Me.txt_Contact_User.uclIntCount = 2
        Me.txt_Contact_User.uclMinus = False
        Me.txt_Contact_User.uclReadOnly = False
        Me.txt_Contact_User.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Contact_User.uclTrimZero = True
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(523, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 16)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "預計/處理完成日"
        '
        'dtp_Estimated_Finish_Date
        '
        Me.dtp_Estimated_Finish_Date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_Estimated_Finish_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Estimated_Finish_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Estimated_Finish_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_Estimated_Finish_Date.Location = New System.Drawing.Point(653, 57)
        Me.dtp_Estimated_Finish_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Estimated_Finish_Date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Estimated_Finish_Date.Name = "dtp_Estimated_Finish_Date"
        Me.dtp_Estimated_Finish_Date.Size = New System.Drawing.Size(129, 27)
        Me.dtp_Estimated_Finish_Date.TabIndex = 28
        Me.dtp_Estimated_Finish_Date.uclIsFixedBackColor = False
        Me.dtp_Estimated_Finish_Date.uclReadOnly = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(575, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "功能代碼"
        '
        'cbo_Function
        '
        Me.cbo_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Function.DropDownWidth = 20
        Me.cbo_Function.DroppedDown = False
        Me.cbo_Function.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Function.Location = New System.Drawing.Point(650, 27)
        Me.cbo_Function.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Function.Name = "cbo_Function"
        Me.cbo_Function.SelectedIndex = -1
        Me.cbo_Function.SelectedItem = Nothing
        Me.cbo_Function.SelectedText = ""
        Me.cbo_Function.SelectedValue = ""
        Me.cbo_Function.SelectionStart = 0
        Me.cbo_Function.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Function.TabIndex = 5
        Me.cbo_Function.uclDisplayIndex = "0,1"
        Me.cbo_Function.uclIsAutoClear = True
        Me.cbo_Function.uclIsFirstItemEmpty = True
        Me.cbo_Function.uclIsTextMode = False
        Me.cbo_Function.uclShowMsg = False
        Me.cbo_Function.uclValueIndex = "0"
        '
        'cbo_System
        '
        Me.cbo_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.DroppedDown = False
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(650, 0)
        Me.cbo_System.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(132, 27)
        Me.cbo_System.TabIndex = 3
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclIsFirstItemEmpty = True
        Me.cbo_System.uclIsTextMode = False
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(591, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "系統別"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(228, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "所屬專案"
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(3, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 16)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "所屬醫院"
        '
        'cbo_Project
        '
        Me.cbo_Project.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Project.DropDownWidth = 20
        Me.cbo_Project.DroppedDown = False
        Me.cbo_Project.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Project.Location = New System.Drawing.Point(303, 0)
        Me.cbo_Project.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Project.Name = "cbo_Project"
        Me.cbo_Project.SelectedIndex = -1
        Me.cbo_Project.SelectedItem = Nothing
        Me.cbo_Project.SelectedText = ""
        Me.cbo_Project.SelectedValue = ""
        Me.cbo_Project.SelectionStart = 0
        Me.cbo_Project.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Project.TabIndex = 1
        Me.cbo_Project.uclDisplayIndex = "0,1"
        Me.cbo_Project.uclIsAutoClear = True
        Me.cbo_Project.uclIsFirstItemEmpty = True
        Me.cbo_Project.uclIsTextMode = False
        Me.cbo_Project.uclShowMsg = False
        Me.cbo_Project.uclValueIndex = "0"
        '
        'cbo_Hosp
        '
        Me.cbo_Hosp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Hosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Hosp.DropDownWidth = 20
        Me.cbo_Hosp.DroppedDown = False
        Me.cbo_Hosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Hosp.Location = New System.Drawing.Point(78, 0)
        Me.cbo_Hosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Hosp.Name = "cbo_Hosp"
        Me.cbo_Hosp.SelectedIndex = -1
        Me.cbo_Hosp.SelectedItem = Nothing
        Me.cbo_Hosp.SelectedText = ""
        Me.cbo_Hosp.SelectedValue = ""
        Me.cbo_Hosp.SelectionStart = 0
        Me.cbo_Hosp.Size = New System.Drawing.Size(132, 27)
        Me.cbo_Hosp.TabIndex = 36
        Me.cbo_Hosp.uclDisplayIndex = "0,1"
        Me.cbo_Hosp.uclIsAutoClear = True
        Me.cbo_Hosp.uclIsFirstItemEmpty = True
        Me.cbo_Hosp.uclIsTextMode = False
        Me.cbo_Hosp.uclShowMsg = False
        Me.cbo_Hosp.uclValueIndex = "0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 126)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(964, 462)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 432)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "需求列表"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgv_IssueList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(950, 426)
        Me.Panel1.TabIndex = 0
        '
        'dgv_IssueList
        '
        Me.dgv_IssueList.AllowUserToAddRows = False
        Me.dgv_IssueList.AllowUserToOrderColumns = False
        Me.dgv_IssueList.AllowUserToResizeColumns = True
        Me.dgv_IssueList.AllowUserToResizeRows = False
        Me.dgv_IssueList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_IssueList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_IssueList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_IssueList.ColumnHeadersHeight = 4
        Me.dgv_IssueList.ColumnHeadersVisible = True
        Me.dgv_IssueList.CurrentCell = Nothing
        Me.dgv_IssueList.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_IssueList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_IssueList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_IssueList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_IssueList.Location = New System.Drawing.Point(0, 0)
        Me.dgv_IssueList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_IssueList.MultiSelect = False
        Me.dgv_IssueList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_IssueList.Name = "dgv_IssueList"
        Me.dgv_IssueList.RowHeadersWidth = 41
        Me.dgv_IssueList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_IssueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_IssueList.Size = New System.Drawing.Size(950, 426)
        Me.dgv_IssueList.TabIndex = 0
        Me.dgv_IssueList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_IssueList.uclBatchColIndex = ""
        Me.dgv_IssueList.uclClickToCheck = False
        Me.dgv_IssueList.uclColumnAlignment = ""
        Me.dgv_IssueList.uclColumnCheckBox = False
        Me.dgv_IssueList.uclColumnControlType = ""
        Me.dgv_IssueList.uclColumnWidth = ""
        Me.dgv_IssueList.uclDoCellEnter = True
        Me.dgv_IssueList.uclHasNewRow = False
        Me.dgv_IssueList.uclHeaderText = ""
        Me.dgv_IssueList.uclIsAlternatingRowsColors = True
        Me.dgv_IssueList.uclIsComboBoxGridQuery = True
        Me.dgv_IssueList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_IssueList.uclIsDoOrderCheck = True
        Me.dgv_IssueList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_IssueList.uclIsSortable = False
        Me.dgv_IssueList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_IssueList.uclNonVisibleColIndex = ""
        Me.dgv_IssueList.uclReadOnly = False
        Me.dgv_IssueList.uclShowCellBorder = False
        Me.dgv_IssueList.uclSortColIndex = ""
        Me.dgv_IssueList.uclTreeMode = False
        Me.dgv_IssueList.uclVisibleColIndex = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPage2.Controls.Add(Me.tlp_Issue)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(956, 432)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "需求紀錄"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_CreateIssueRecord)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Update)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_ClearIssue)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_UploadAtt)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_UploadPath)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 395)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(950, 34)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'btn_CreateIssueRecord
        '
        Me.btn_CreateIssueRecord.Location = New System.Drawing.Point(3, 3)
        Me.btn_CreateIssueRecord.Name = "btn_CreateIssueRecord"
        Me.btn_CreateIssueRecord.Size = New System.Drawing.Size(96, 27)
        Me.btn_CreateIssueRecord.TabIndex = 19
        Me.btn_CreateIssueRecord.Text = "新增"
        Me.btn_CreateIssueRecord.UseVisualStyleBackColor = True
        '
        'btn_Update
        '
        Me.btn_Update.Location = New System.Drawing.Point(105, 3)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(96, 27)
        Me.btn_Update.TabIndex = 23
        Me.btn_Update.Text = "儲存"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_ClearIssue
        '
        Me.btn_ClearIssue.Location = New System.Drawing.Point(207, 3)
        Me.btn_ClearIssue.Name = "btn_ClearIssue"
        Me.btn_ClearIssue.Size = New System.Drawing.Size(96, 27)
        Me.btn_ClearIssue.TabIndex = 20
        Me.btn_ClearIssue.Text = "清除"
        Me.btn_ClearIssue.UseVisualStyleBackColor = True
        '
        'btn_UploadAtt
        '
        Me.btn_UploadAtt.Location = New System.Drawing.Point(309, 3)
        Me.btn_UploadAtt.Name = "btn_UploadAtt"
        Me.btn_UploadAtt.Size = New System.Drawing.Size(96, 27)
        Me.btn_UploadAtt.TabIndex = 21
        Me.btn_UploadAtt.Text = "附加檔案"
        Me.btn_UploadAtt.UseVisualStyleBackColor = True
        '
        'txt_UploadPath
        '
        Me.txt_UploadPath.Enabled = False
        Me.txt_UploadPath.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_UploadPath.Location = New System.Drawing.Point(411, 3)
        Me.txt_UploadPath.MaxLength = 32767
        Me.txt_UploadPath.Name = "txt_UploadPath"
        Me.txt_UploadPath.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_UploadPath.SelectionStart = 0
        Me.txt_UploadPath.Size = New System.Drawing.Size(534, 27)
        Me.txt_UploadPath.TabIndex = 22
        Me.txt_UploadPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_UploadPath.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_UploadPath.ToolTipTag = Nothing
        Me.txt_UploadPath.uclDollarSign = False
        Me.txt_UploadPath.uclDotCount = 0
        Me.txt_UploadPath.uclIntCount = 2
        Me.txt_UploadPath.uclMinus = False
        Me.txt_UploadPath.uclReadOnly = False
        Me.txt_UploadPath.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_UploadPath.uclTrimZero = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(956, 432)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "進度追蹤"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tlp_RejectMain)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_RejectRecord)
        Me.SplitContainer1.Size = New System.Drawing.Size(950, 426)
        Me.SplitContainer1.SplitterDistance = 665
        Me.SplitContainer1.TabIndex = 0
        '
        'tlp_RejectMain
        '
        Me.tlp_RejectMain.ColumnCount = 1
        Me.tlp_RejectMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_RejectMain.Controls.Add(Me.FlowLayoutPanel3, 0, 0)
        Me.tlp_RejectMain.Controls.Add(Me.grb_Reason, 0, 1)
        Me.tlp_RejectMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_RejectMain.Location = New System.Drawing.Point(0, 0)
        Me.tlp_RejectMain.Name = "tlp_RejectMain"
        Me.tlp_RejectMain.RowCount = 2
        Me.tlp_RejectMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.240535!))
        Me.tlp_RejectMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.75947!))
        Me.tlp_RejectMain.Size = New System.Drawing.Size(665, 426)
        Me.tlp_RejectMain.TabIndex = 0
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.rdb_Close)
        Me.FlowLayoutPanel3.Controls.Add(Me.rdb_Reject)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_ClearReject)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(659, 29)
        Me.FlowLayoutPanel3.TabIndex = 0
        '
        'rdb_Close
        '
        Me.rdb_Close.AutoSize = True
        Me.rdb_Close.Checked = True
        Me.rdb_Close.Location = New System.Drawing.Point(3, 3)
        Me.rdb_Close.Name = "rdb_Close"
        Me.rdb_Close.Size = New System.Drawing.Size(58, 20)
        Me.rdb_Close.TabIndex = 0
        Me.rdb_Close.TabStop = True
        Me.rdb_Close.Text = "完成"
        Me.rdb_Close.UseVisualStyleBackColor = True
        '
        'rdb_Reject
        '
        Me.rdb_Reject.AutoSize = True
        Me.rdb_Reject.Location = New System.Drawing.Point(67, 3)
        Me.rdb_Reject.Name = "rdb_Reject"
        Me.rdb_Reject.Size = New System.Drawing.Size(58, 20)
        Me.rdb_Reject.TabIndex = 1
        Me.rdb_Reject.Text = "退件"
        Me.rdb_Reject.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(131, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(75, 28)
        Me.btn_Confirm.TabIndex = 2
        Me.btn_Confirm.Text = "送出"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'btn_ClearReject
        '
        Me.btn_ClearReject.Location = New System.Drawing.Point(212, 3)
        Me.btn_ClearReject.Name = "btn_ClearReject"
        Me.btn_ClearReject.Size = New System.Drawing.Size(75, 28)
        Me.btn_ClearReject.TabIndex = 4
        Me.btn_ClearReject.Text = "清除"
        Me.btn_ClearReject.UseVisualStyleBackColor = True
        '
        'grb_Reason
        '
        Me.grb_Reason.Controls.Add(Me.rtb_Reason)
        Me.grb_Reason.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grb_Reason.ForeColor = System.Drawing.Color.Red
        Me.grb_Reason.Location = New System.Drawing.Point(3, 38)
        Me.grb_Reason.Name = "grb_Reason"
        Me.grb_Reason.Size = New System.Drawing.Size(659, 385)
        Me.grb_Reason.TabIndex = 4
        Me.grb_Reason.TabStop = False
        Me.grb_Reason.Text = "理由(可附圖)"
        '
        'rtb_Reason
        '
        Me.rtb_Reason.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Reason.Location = New System.Drawing.Point(3, 23)
        Me.rtb_Reason.Name = "rtb_Reason"
        Me.rtb_Reason.Size = New System.Drawing.Size(653, 359)
        Me.rtb_Reason.TabIndex = 1
        Me.rtb_Reason.Text = ""
        '
        'dgv_RejectRecord
        '
        Me.dgv_RejectRecord.AllowUserToAddRows = False
        Me.dgv_RejectRecord.AllowUserToOrderColumns = False
        Me.dgv_RejectRecord.AllowUserToResizeColumns = True
        Me.dgv_RejectRecord.AllowUserToResizeRows = False
        Me.dgv_RejectRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgv_RejectRecord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_RejectRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_RejectRecord.ColumnHeadersHeight = 4
        Me.dgv_RejectRecord.ColumnHeadersVisible = True
        Me.dgv_RejectRecord.CurrentCell = Nothing
        Me.dgv_RejectRecord.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_RejectRecord.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_RejectRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_RejectRecord.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_RejectRecord.Location = New System.Drawing.Point(0, 0)
        Me.dgv_RejectRecord.MultiSelect = False
        Me.dgv_RejectRecord.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_RejectRecord.Name = "dgv_RejectRecord"
        Me.dgv_RejectRecord.RowHeadersWidth = 41
        Me.dgv_RejectRecord.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_RejectRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_RejectRecord.Size = New System.Drawing.Size(281, 426)
        Me.dgv_RejectRecord.TabIndex = 0
        Me.dgv_RejectRecord.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_RejectRecord.uclBatchColIndex = ""
        Me.dgv_RejectRecord.uclClickToCheck = False
        Me.dgv_RejectRecord.uclColumnAlignment = ""
        Me.dgv_RejectRecord.uclColumnCheckBox = False
        Me.dgv_RejectRecord.uclColumnControlType = ""
        Me.dgv_RejectRecord.uclColumnWidth = ""
        Me.dgv_RejectRecord.uclDoCellEnter = True
        Me.dgv_RejectRecord.uclHasNewRow = False
        Me.dgv_RejectRecord.uclHeaderText = ""
        Me.dgv_RejectRecord.uclIsAlternatingRowsColors = True
        Me.dgv_RejectRecord.uclIsComboBoxGridQuery = True
        Me.dgv_RejectRecord.uclIsComboxClickTriggerDropDown = False
        Me.dgv_RejectRecord.uclIsDoOrderCheck = True
        Me.dgv_RejectRecord.uclIsDoQueryComboBoxGrid = True
        Me.dgv_RejectRecord.uclIsSortable = False
        Me.dgv_RejectRecord.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_RejectRecord.uclNonVisibleColIndex = ""
        Me.dgv_RejectRecord.uclReadOnly = False
        Me.dgv_RejectRecord.uclShowCellBorder = False
        Me.dgv_RejectRecord.uclSortColIndex = ""
        Me.dgv_RejectRecord.uclTreeMode = False
        Me.dgv_RejectRecord.uclVisibleColIndex = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tlp_Query)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(964, 126)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查詢"
        '
        'tlp_Query
        '
        Me.tlp_Query.ColumnCount = 11
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Query.Controls.Add(Me.Label27, 0, 2)
        Me.tlp_Query.Controls.Add(Me.Label12, 4, 1)
        Me.tlp_Query.Controls.Add(Me.Label10, 0, 1)
        Me.tlp_Query.Controls.Add(Me.Label7, 0, 0)
        Me.tlp_Query.Controls.Add(Me.cbo_QueryProjectId, 1, 0)
        Me.tlp_Query.Controls.Add(Me.cbo_QuerySystemCode, 3, 0)
        Me.tlp_Query.Controls.Add(Me.cbo_QueryFunctionCode, 5, 0)
        Me.tlp_Query.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.tlp_Query.Controls.Add(Me.cbo_QueryIssueStatus, 5, 1)
        Me.tlp_Query.Controls.Add(Me.Label9, 4, 0)
        Me.tlp_Query.Controls.Add(Me.Label8, 2, 0)
        Me.tlp_Query.Controls.Add(Me.Label25, 6, 0)
        Me.tlp_Query.Controls.Add(Me.cbo_QueryHosp, 7, 0)
        Me.tlp_Query.Controls.Add(Me.Label26, 6, 1)
        Me.tlp_Query.Controls.Add(Me.cbo_QueryProcessingEmployee, 7, 1)
        Me.tlp_Query.Controls.Add(Me.btn_Clear, 8, 2)
        Me.tlp_Query.Controls.Add(Me.btn_Query, 9, 2)
        Me.tlp_Query.Controls.Add(Me.btn_Export, 10, 2)
        Me.tlp_Query.Controls.Add(Me.txt_JobCode, 1, 2)
        Me.tlp_Query.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Query.Location = New System.Drawing.Point(3, 23)
        Me.tlp_Query.Name = "tlp_Query"
        Me.tlp_Query.RowCount = 3
        Me.tlp_Query.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Query.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Query.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_Query.Size = New System.Drawing.Size(958, 100)
        Me.tlp_Query.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 16)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "派工單號"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(377, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "處理狀態"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "日期區間"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "所屬專案"
        '
        'cbo_QueryProjectId
        '
        Me.cbo_QueryProjectId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QueryProjectId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QueryProjectId.DropDownWidth = 20
        Me.cbo_QueryProjectId.DroppedDown = False
        Me.cbo_QueryProjectId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QueryProjectId.Location = New System.Drawing.Point(78, 4)
        Me.cbo_QueryProjectId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QueryProjectId.Name = "cbo_QueryProjectId"
        Me.cbo_QueryProjectId.SelectedIndex = -1
        Me.cbo_QueryProjectId.SelectedItem = Nothing
        Me.cbo_QueryProjectId.SelectedText = ""
        Me.cbo_QueryProjectId.SelectedValue = ""
        Me.cbo_QueryProjectId.SelectionStart = 0
        Me.cbo_QueryProjectId.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QueryProjectId.TabIndex = 7
        Me.cbo_QueryProjectId.uclDisplayIndex = "0,1"
        Me.cbo_QueryProjectId.uclIsAutoClear = True
        Me.cbo_QueryProjectId.uclIsFirstItemEmpty = True
        Me.cbo_QueryProjectId.uclIsTextMode = False
        Me.cbo_QueryProjectId.uclShowMsg = False
        Me.cbo_QueryProjectId.uclValueIndex = "0"
        '
        'cbo_QuerySystemCode
        '
        Me.cbo_QuerySystemCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QuerySystemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QuerySystemCode.DropDownWidth = 20
        Me.cbo_QuerySystemCode.DroppedDown = False
        Me.cbo_QuerySystemCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QuerySystemCode.Location = New System.Drawing.Point(257, 4)
        Me.cbo_QuerySystemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QuerySystemCode.Name = "cbo_QuerySystemCode"
        Me.cbo_QuerySystemCode.SelectedIndex = -1
        Me.cbo_QuerySystemCode.SelectedItem = Nothing
        Me.cbo_QuerySystemCode.SelectedText = ""
        Me.cbo_QuerySystemCode.SelectedValue = ""
        Me.cbo_QuerySystemCode.SelectionStart = 0
        Me.cbo_QuerySystemCode.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QuerySystemCode.TabIndex = 11
        Me.cbo_QuerySystemCode.uclDisplayIndex = "0,1"
        Me.cbo_QuerySystemCode.uclIsAutoClear = True
        Me.cbo_QuerySystemCode.uclIsFirstItemEmpty = True
        Me.cbo_QuerySystemCode.uclIsTextMode = False
        Me.cbo_QuerySystemCode.uclShowMsg = False
        Me.cbo_QuerySystemCode.uclValueIndex = "0"
        '
        'cbo_QueryFunctionCode
        '
        Me.cbo_QueryFunctionCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QueryFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QueryFunctionCode.DropDownWidth = 20
        Me.cbo_QueryFunctionCode.DroppedDown = False
        Me.cbo_QueryFunctionCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QueryFunctionCode.Location = New System.Drawing.Point(452, 4)
        Me.cbo_QueryFunctionCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QueryFunctionCode.Name = "cbo_QueryFunctionCode"
        Me.cbo_QueryFunctionCode.SelectedIndex = -1
        Me.cbo_QueryFunctionCode.SelectedItem = Nothing
        Me.cbo_QueryFunctionCode.SelectedText = ""
        Me.cbo_QueryFunctionCode.SelectedValue = ""
        Me.cbo_QueryFunctionCode.SelectionStart = 0
        Me.cbo_QueryFunctionCode.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QueryFunctionCode.TabIndex = 9
        Me.cbo_QueryFunctionCode.uclDisplayIndex = "0,1"
        Me.cbo_QueryFunctionCode.uclIsAutoClear = True
        Me.cbo_QueryFunctionCode.uclIsFirstItemEmpty = True
        Me.cbo_QueryFunctionCode.uclIsTextMode = False
        Me.cbo_QueryFunctionCode.uclShowMsg = False
        Me.cbo_QueryFunctionCode.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.tlp_Query.SetColumnSpan(Me.FlowLayoutPanel1, 3)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_SDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_EDate)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(81, 35)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(267, 26)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'dtp_SDate
        '
        Me.dtp_SDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_SDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_SDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_SDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_SDate.Location = New System.Drawing.Point(3, 3)
        Me.dtp_SDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_SDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_SDate.Name = "dtp_SDate"
        Me.dtp_SDate.Size = New System.Drawing.Size(111, 27)
        Me.dtp_SDate.TabIndex = 9
        Me.dtp_SDate.uclIsFixedBackColor = False
        Me.dtp_SDate.uclReadOnly = False
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(120, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "~"
        '
        'dtp_EDate
        '
        Me.dtp_EDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EDate.Location = New System.Drawing.Point(142, 3)
        Me.dtp_EDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EDate.Name = "dtp_EDate"
        Me.dtp_EDate.Size = New System.Drawing.Size(111, 27)
        Me.dtp_EDate.TabIndex = 15
        Me.dtp_EDate.uclIsFixedBackColor = False
        Me.dtp_EDate.uclReadOnly = False
        '
        'cbo_QueryIssueStatus
        '
        Me.cbo_QueryIssueStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QueryIssueStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QueryIssueStatus.DropDownWidth = 20
        Me.cbo_QueryIssueStatus.DroppedDown = False
        Me.cbo_QueryIssueStatus.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QueryIssueStatus.Location = New System.Drawing.Point(452, 36)
        Me.cbo_QueryIssueStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QueryIssueStatus.Name = "cbo_QueryIssueStatus"
        Me.cbo_QueryIssueStatus.SelectedIndex = -1
        Me.cbo_QueryIssueStatus.SelectedItem = Nothing
        Me.cbo_QueryIssueStatus.SelectedText = ""
        Me.cbo_QueryIssueStatus.SelectedValue = ""
        Me.cbo_QueryIssueStatus.SelectionStart = 0
        Me.cbo_QueryIssueStatus.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QueryIssueStatus.TabIndex = 16
        Me.cbo_QueryIssueStatus.uclDisplayIndex = "0,1"
        Me.cbo_QueryIssueStatus.uclIsAutoClear = True
        Me.cbo_QueryIssueStatus.uclIsFirstItemEmpty = True
        Me.cbo_QueryIssueStatus.uclIsTextMode = False
        Me.cbo_QueryIssueStatus.uclShowMsg = False
        Me.cbo_QueryIssueStatus.uclValueIndex = "0"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(377, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "功能代碼"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(198, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "系統別"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(588, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 16)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "醫院別"
        '
        'cbo_QueryHosp
        '
        Me.cbo_QueryHosp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QueryHosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QueryHosp.DropDownWidth = 20
        Me.cbo_QueryHosp.DroppedDown = False
        Me.cbo_QueryHosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QueryHosp.Location = New System.Drawing.Point(647, 4)
        Me.cbo_QueryHosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QueryHosp.Name = "cbo_QueryHosp"
        Me.cbo_QueryHosp.SelectedIndex = -1
        Me.cbo_QueryHosp.SelectedItem = Nothing
        Me.cbo_QueryHosp.SelectedText = ""
        Me.cbo_QueryHosp.SelectedValue = ""
        Me.cbo_QueryHosp.SelectionStart = 0
        Me.cbo_QueryHosp.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QueryHosp.TabIndex = 20
        Me.cbo_QueryHosp.uclDisplayIndex = "0,1"
        Me.cbo_QueryHosp.uclIsAutoClear = True
        Me.cbo_QueryHosp.uclIsFirstItemEmpty = True
        Me.cbo_QueryHosp.uclIsTextMode = False
        Me.cbo_QueryHosp.uclShowMsg = False
        Me.cbo_QueryHosp.uclValueIndex = "0"
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(572, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "處理人員"
        '
        'cbo_QueryProcessingEmployee
        '
        Me.cbo_QueryProcessingEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_QueryProcessingEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_QueryProcessingEmployee.DropDownWidth = 20
        Me.cbo_QueryProcessingEmployee.DroppedDown = False
        Me.cbo_QueryProcessingEmployee.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_QueryProcessingEmployee.Location = New System.Drawing.Point(647, 36)
        Me.cbo_QueryProcessingEmployee.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_QueryProcessingEmployee.Name = "cbo_QueryProcessingEmployee"
        Me.cbo_QueryProcessingEmployee.SelectedIndex = -1
        Me.cbo_QueryProcessingEmployee.SelectedItem = Nothing
        Me.cbo_QueryProcessingEmployee.SelectedText = ""
        Me.cbo_QueryProcessingEmployee.SelectedValue = ""
        Me.cbo_QueryProcessingEmployee.SelectionStart = 0
        Me.cbo_QueryProcessingEmployee.Size = New System.Drawing.Size(117, 24)
        Me.cbo_QueryProcessingEmployee.TabIndex = 22
        Me.cbo_QueryProcessingEmployee.uclDisplayIndex = "0,1"
        Me.cbo_QueryProcessingEmployee.uclIsAutoClear = True
        Me.cbo_QueryProcessingEmployee.uclIsFirstItemEmpty = True
        Me.cbo_QueryProcessingEmployee.uclIsTextMode = False
        Me.cbo_QueryProcessingEmployee.uclShowMsg = False
        Me.cbo_QueryProcessingEmployee.uclValueIndex = "0"
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Location = New System.Drawing.Point(767, 68)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(59, 27)
        Me.btn_Clear.TabIndex = 17
        Me.btn_Clear.Text = "清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Query.Location = New System.Drawing.Point(832, 68)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(59, 27)
        Me.btn_Query.TabIndex = 18
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Export
        '
        Me.btn_Export.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Export.Location = New System.Drawing.Point(897, 68)
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(59, 27)
        Me.btn_Export.TabIndex = 23
        Me.btn_Export.Text = "匯出"
        Me.btn_Export.UseVisualStyleBackColor = True
        '
        'txt_JobCode
        '
        Me.tlp_Query.SetColumnSpan(Me.txt_JobCode, 2)
        Me.txt_JobCode.Location = New System.Drawing.Point(81, 67)
        Me.txt_JobCode.Name = "txt_JobCode"
        Me.txt_JobCode.Size = New System.Drawing.Size(173, 27)
        Me.txt_JobCode.TabIndex = 25
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'JobServiceRecordUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 588)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.IsActiveAutoSize = False
        Me.Name = "JobServiceRecordUI"
        Me.TabText = "需求管理作業"
        Me.Text = "需求管理作業"
        Me.tlp_Issue.ResumeLayout(False)
        Me.tlp_Issue.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlp_RejectMain.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.grb_Reason.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tlp_Query.ResumeLayout(False)
        Me.tlp_Query.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_Issue As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbo_Project As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbo_Function As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents dtp_ReceiveDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_ReceiveTime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents dgv_IssueList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents tlp_Query As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cbo_QueryIssueStatus As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Clear As Windows.Forms.Button
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents cbo_Issue_Source As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents cbo_IssueClassify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_Contact_Way As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents txt_Contact_Note As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents txt_Processing_Approach As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents txt_Note As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents txt_Contact_User As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_Processing_Employee_Code As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents dtp_Estimated_Finish_Date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_CreateIssueRecord As Windows.Forms.Button
    Friend WithEvents btn_ClearIssue As Windows.Forms.Button
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents txt_Issue_Description As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents cbo_Issue_Status As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents txt_Processing_Cost As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_UploadAtt As Windows.Forms.Button
    Friend WithEvents txt_UploadPath As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cbo_QueryProjectId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_QuerySystemCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_QueryFunctionCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents dtp_SDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents dtp_EDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents cbo_Hosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As Windows.Forms.SplitContainer
    Friend WithEvents tlp_RejectMain As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdb_Close As Windows.Forms.RadioButton
    Friend WithEvents rdb_Reject As Windows.Forms.RadioButton
    Friend WithEvents btn_Confirm As Windows.Forms.Button
    Friend WithEvents dgv_RejectRecord As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents rtb_Reason As Windows.Forms.RichTextBox
    Friend WithEvents btn_ClearReject As Windows.Forms.Button
    Friend WithEvents grb_Reason As Windows.Forms.GroupBox
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents cbo_QueryHosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label26 As Windows.Forms.Label
    Friend WithEvents cbo_QueryProcessingEmployee As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Export As Windows.Forms.Button
    Friend WithEvents btn_Update As Windows.Forms.Button
    Friend WithEvents Label27 As Windows.Forms.Label
    Friend WithEvents txt_JobCode As Windows.Forms.TextBox
End Class
