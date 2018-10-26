<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobQAJobListUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobQAJobListUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_Project = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_DeployKind = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_CreateNew = New System.Windows.Forms.Button()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tlp_VerInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_NewVerDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_NewVer = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_CurrentVer = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_CurrentVerDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.ckb_IsClose = New System.Windows.Forms.CheckBox()
        Me.rtb_VerDescription = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_BugRecord = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_CurrVer = New System.Windows.Forms.RadioButton()
        Me.rbt_AllVer = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_StillWaitting = New System.Windows.Forms.RadioButton()
        Me.rbt_UnClose = New System.Windows.Forms.RadioButton()
        Me.rbt_QueryAll = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_OnlyMe = New System.Windows.Forms.RadioButton()
        Me.rbt_All = New System.Windows.Forms.RadioButton()
        Me.btn_QueryBugRecord = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_QueryCurrVer = New System.Windows.Forms.RadioButton()
        Me.rbt_QueryAllVer = New System.Windows.Forms.RadioButton()
        Me.btn_Export = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.ckb_Status = New System.Windows.Forms.CheckBox()
        Me.ckb_Function = New System.Windows.Forms.CheckBox()
        Me.ckb_System = New System.Windows.Forms.CheckBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.ckb_TestVer = New System.Windows.Forms.CheckBox()
        Me.ckb_Subject = New System.Windows.Forms.CheckBox()
        Me.ckb_Desc = New System.Windows.Forms.CheckBox()
        Me.ckb_Classify = New System.Windows.Forms.CheckBox()
        Me.ckb_Severity = New System.Windows.Forms.CheckBox()
        Me.ckb_TestUser = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.JobQABugListGridviewUC1 = New Project.Client.JOB.JobQABugListGridviewUC()
        Me.CreateNewBugUC = New Project.Client.JOB.JobQACreateNewBugUC()
        Me.cbo_Hosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tlp_VerInfo.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Project, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_DeployKind, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Hosp, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 191)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "選擇專案"
        '
        'cbo_Project
        '
        Me.cbo_Project.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Project.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Project.DropDownWidth = 20
        Me.cbo_Project.DroppedDown = False
        Me.cbo_Project.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Project.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_Project.Location = New System.Drawing.Point(78, 7)
        Me.cbo_Project.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Project.Name = "cbo_Project"
        Me.cbo_Project.SelectedIndex = -1
        Me.cbo_Project.SelectedItem = Nothing
        Me.cbo_Project.SelectedText = ""
        Me.cbo_Project.SelectedValue = ""
        Me.cbo_Project.SelectionStart = 0
        Me.cbo_Project.Size = New System.Drawing.Size(173, 24)
        Me.cbo_Project.TabIndex = 1
        Me.cbo_Project.uclDisplayIndex = "0,1"
        Me.cbo_Project.uclIsAutoClear = True
        Me.cbo_Project.uclIsFirstItemEmpty = True
        Me.cbo_Project.uclIsTextMode = False
        Me.cbo_Project.uclShowMsg = False
        Me.cbo_Project.uclValueIndex = "0"
        '
        'cbo_DeployKind
        '
        Me.cbo_DeployKind.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_DeployKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_DeployKind.DropDownWidth = 20
        Me.cbo_DeployKind.DroppedDown = False
        Me.cbo_DeployKind.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_DeployKind.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_DeployKind.Location = New System.Drawing.Point(499, 7)
        Me.cbo_DeployKind.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_DeployKind.Name = "cbo_DeployKind"
        Me.cbo_DeployKind.SelectedIndex = -1
        Me.cbo_DeployKind.SelectedItem = Nothing
        Me.cbo_DeployKind.SelectedText = ""
        Me.cbo_DeployKind.SelectedValue = ""
        Me.cbo_DeployKind.SelectionStart = 0
        Me.cbo_DeployKind.Size = New System.Drawing.Size(125, 24)
        Me.cbo_DeployKind.TabIndex = 2
        Me.cbo_DeployKind.uclDisplayIndex = "0,1"
        Me.cbo_DeployKind.uclIsAutoClear = True
        Me.cbo_DeployKind.uclIsFirstItemEmpty = True
        Me.cbo_DeployKind.uclIsTextMode = False
        Me.cbo_DeployKind.uclShowMsg = False
        Me.cbo_DeployKind.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_CreateNew)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Update)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Close)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(630, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(349, 32)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(3, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(75, 27)
        Me.btn_Query.TabIndex = 0
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_CreateNew
        '
        Me.btn_CreateNew.Location = New System.Drawing.Point(84, 3)
        Me.btn_CreateNew.Name = "btn_CreateNew"
        Me.btn_CreateNew.Size = New System.Drawing.Size(75, 27)
        Me.btn_CreateNew.TabIndex = 3
        Me.btn_CreateNew.Text = "新增"
        Me.btn_CreateNew.UseVisualStyleBackColor = True
        '
        'btn_Update
        '
        Me.btn_Update.Enabled = False
        Me.btn_Update.Location = New System.Drawing.Point(165, 3)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(75, 27)
        Me.btn_Update.TabIndex = 1
        Me.btn_Update.Text = "修改"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_Close
        '
        Me.btn_Close.Enabled = False
        Me.btn_Close.Location = New System.Drawing.Point(246, 3)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(75, 27)
        Me.btn_Close.TabIndex = 2
        Me.btn_Close.Text = "關帳"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 5)
        Me.GroupBox1.Controls.Add(Me.tlp_VerInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(621, 146)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "版次資訊"
        '
        'tlp_VerInfo
        '
        Me.tlp_VerInfo.ColumnCount = 5
        Me.tlp_VerInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_VerInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_VerInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_VerInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_VerInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_VerInfo.Controls.Add(Me.Label6, 0, 2)
        Me.tlp_VerInfo.Controls.Add(Me.Label5, 2, 1)
        Me.tlp_VerInfo.Controls.Add(Me.dtp_NewVerDate, 3, 1)
        Me.tlp_VerInfo.Controls.Add(Me.txt_NewVer, 1, 1)
        Me.tlp_VerInfo.Controls.Add(Me.Label4, 0, 1)
        Me.tlp_VerInfo.Controls.Add(Me.Label2, 0, 0)
        Me.tlp_VerInfo.Controls.Add(Me.Label3, 2, 0)
        Me.tlp_VerInfo.Controls.Add(Me.txt_CurrentVer, 1, 0)
        Me.tlp_VerInfo.Controls.Add(Me.Label7, 4, 0)
        Me.tlp_VerInfo.Controls.Add(Me.dtp_CurrentVerDate, 3, 0)
        Me.tlp_VerInfo.Controls.Add(Me.ckb_IsClose, 4, 1)
        Me.tlp_VerInfo.Controls.Add(Me.rtb_VerDescription, 1, 2)
        Me.tlp_VerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_VerInfo.Location = New System.Drawing.Point(3, 23)
        Me.tlp_VerInfo.Name = "tlp_VerInfo"
        Me.tlp_VerInfo.RowCount = 3
        Me.tlp_VerInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_VerInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_VerInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_VerInfo.Size = New System.Drawing.Size(615, 120)
        Me.tlp_VerInfo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(3, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "版次說明"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(161, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "上版日期"
        '
        'dtp_NewVerDate
        '
        Me.dtp_NewVerDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_NewVerDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_NewVerDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_NewVerDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_NewVerDate.Location = New System.Drawing.Point(239, 36)
        Me.dtp_NewVerDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_NewVerDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_NewVerDate.Name = "dtp_NewVerDate"
        Me.dtp_NewVerDate.Size = New System.Drawing.Size(132, 24)
        Me.dtp_NewVerDate.TabIndex = 7
        Me.dtp_NewVerDate.uclIsFixedBackColor = False
        Me.dtp_NewVerDate.uclReadOnly = False
        '
        'txt_NewVer
        '
        Me.txt_NewVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NewVer.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_NewVer.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_NewVer.Location = New System.Drawing.Point(81, 36)
        Me.txt_NewVer.MaxLength = 10
        Me.txt_NewVer.Name = "txt_NewVer"
        Me.txt_NewVer.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_NewVer.SelectionStart = 0
        Me.txt_NewVer.Size = New System.Drawing.Size(74, 24)
        Me.txt_NewVer.TabIndex = 5
        Me.txt_NewVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_NewVer.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_NewVer.ToolTipTag = Nothing
        Me.txt_NewVer.uclDollarSign = False
        Me.txt_NewVer.uclDotCount = 0
        Me.txt_NewVer.uclIntCount = 3
        Me.txt_NewVer.uclMinus = False
        Me.txt_NewVer.uclReadOnly = False
        Me.txt_NewVer.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_NewVer.uclTrimZero = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "新增版次"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "目前版次"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(161, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "上版日期"
        '
        'txt_CurrentVer
        '
        Me.txt_CurrentVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_CurrentVer.Enabled = False
        Me.txt_CurrentVer.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_CurrentVer.Location = New System.Drawing.Point(81, 3)
        Me.txt_CurrentVer.MaxLength = 10
        Me.txt_CurrentVer.Name = "txt_CurrentVer"
        Me.txt_CurrentVer.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_CurrentVer.SelectionStart = 0
        Me.txt_CurrentVer.Size = New System.Drawing.Size(74, 27)
        Me.txt_CurrentVer.TabIndex = 2
        Me.txt_CurrentVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_CurrentVer.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_CurrentVer.ToolTipTag = Nothing
        Me.txt_CurrentVer.uclDollarSign = False
        Me.txt_CurrentVer.uclDotCount = 0
        Me.txt_CurrentVer.uclIntCount = 2
        Me.txt_CurrentVer.uclMinus = False
        Me.txt_CurrentVer.uclReadOnly = False
        Me.txt_CurrentVer.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_CurrentVer.uclTrimZero = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(377, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(232, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "※關帳後不可再修改版次說明。"
        '
        'dtp_CurrentVerDate
        '
        Me.dtp_CurrentVerDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_CurrentVerDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_CurrentVerDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_CurrentVerDate.Enabled = False
        Me.dtp_CurrentVerDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_CurrentVerDate.Location = New System.Drawing.Point(239, 3)
        Me.dtp_CurrentVerDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_CurrentVerDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_CurrentVerDate.Name = "dtp_CurrentVerDate"
        Me.dtp_CurrentVerDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_CurrentVerDate.TabIndex = 3
        Me.dtp_CurrentVerDate.uclIsFixedBackColor = False
        Me.dtp_CurrentVerDate.uclReadOnly = False
        '
        'ckb_IsClose
        '
        Me.ckb_IsClose.AutoSize = True
        Me.ckb_IsClose.Location = New System.Drawing.Point(377, 36)
        Me.ckb_IsClose.Name = "ckb_IsClose"
        Me.ckb_IsClose.Size = New System.Drawing.Size(91, 20)
        Me.ckb_IsClose.TabIndex = 11
        Me.ckb_IsClose.Text = "是否關帳"
        Me.ckb_IsClose.UseVisualStyleBackColor = True
        Me.ckb_IsClose.Visible = False
        '
        'rtb_VerDescription
        '
        Me.tlp_VerInfo.SetColumnSpan(Me.rtb_VerDescription, 4)
        Me.rtb_VerDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_VerDescription.Location = New System.Drawing.Point(82, 67)
        Me.rtb_VerDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.rtb_VerDescription.Name = "rtb_VerDescription"
        Me.rtb_VerDescription.Size = New System.Drawing.Size(529, 49)
        Me.rtb_VerDescription.TabIndex = 12
        Me.rtb_VerDescription.uclMaxLength = 32767
        Me.rtb_VerDescription.uclReadOnly = False
        Me.rtb_VerDescription.uclWordWrap = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 191)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(983, 495)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(975, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "版次現況"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.JobQABugListGridviewUC1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(969, 459)
        Me.Panel3.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(975, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "新增BUG"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.CreateNewBugUC)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 459)
        Me.Panel2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(975, 465)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "查看BUG"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 465)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(975, 465)
        Me.Panel4.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_BugRecord, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.35484!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.64516!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(975, 465)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'dgv_BugRecord
        '
        Me.dgv_BugRecord.AllowUserToAddRows = False
        Me.dgv_BugRecord.AllowUserToOrderColumns = False
        Me.dgv_BugRecord.AllowUserToResizeColumns = True
        Me.dgv_BugRecord.AllowUserToResizeRows = False
        Me.dgv_BugRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_BugRecord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_BugRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_BugRecord.ColumnHeadersHeight = 4
        Me.dgv_BugRecord.ColumnHeadersVisible = True
        Me.dgv_BugRecord.CurrentCell = Nothing
        Me.dgv_BugRecord.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_BugRecord.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_BugRecord.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_BugRecord.Location = New System.Drawing.Point(4, 94)
        Me.dgv_BugRecord.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_BugRecord.MultiSelect = False
        Me.dgv_BugRecord.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_BugRecord.Name = "dgv_BugRecord"
        Me.dgv_BugRecord.RowHeadersWidth = 41
        Me.dgv_BugRecord.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_BugRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_BugRecord.Size = New System.Drawing.Size(967, 308)
        Me.dgv_BugRecord.TabIndex = 0
        Me.dgv_BugRecord.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_BugRecord.uclBatchColIndex = ""
        Me.dgv_BugRecord.uclClickToCheck = False
        Me.dgv_BugRecord.uclColumnAlignment = ""
        Me.dgv_BugRecord.uclColumnCheckBox = False
        Me.dgv_BugRecord.uclColumnControlType = ""
        Me.dgv_BugRecord.uclColumnWidth = ""
        Me.dgv_BugRecord.uclDoCellEnter = True
        Me.dgv_BugRecord.uclHasNewRow = False
        Me.dgv_BugRecord.uclHeaderText = ""
        Me.dgv_BugRecord.uclIsAlternatingRowsColors = True
        Me.dgv_BugRecord.uclIsComboBoxGridQuery = True
        Me.dgv_BugRecord.uclIsComboxClickTriggerDropDown = False
        Me.dgv_BugRecord.uclIsDoOrderCheck = True
        Me.dgv_BugRecord.uclIsDoQueryComboBoxGrid = True
        Me.dgv_BugRecord.uclIsSortable = False
        Me.dgv_BugRecord.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_BugRecord.uclNonVisibleColIndex = ""
        Me.dgv_BugRecord.uclReadOnly = False
        Me.dgv_BugRecord.uclShowCellBorder = False
        Me.dgv_BugRecord.uclSortColIndex = ""
        Me.dgv_BugRecord.uclTreeMode = False
        Me.dgv_BugRecord.uclVisibleColIndex = ""
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel3, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel2, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_QueryBugRecord, 3, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(969, 84)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "所屬版次"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.rbt_CurrVer)
        Me.FlowLayoutPanel4.Controls.Add(Me.rbt_AllVer)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(86, 4)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(314, 34)
        Me.FlowLayoutPanel4.TabIndex = 5
        '
        'rbt_CurrVer
        '
        Me.rbt_CurrVer.AutoSize = True
        Me.rbt_CurrVer.Location = New System.Drawing.Point(3, 7)
        Me.rbt_CurrVer.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_CurrVer.Name = "rbt_CurrVer"
        Me.rbt_CurrVer.Size = New System.Drawing.Size(90, 20)
        Me.rbt_CurrVer.TabIndex = 0
        Me.rbt_CurrVer.Text = "當前版次"
        Me.rbt_CurrVer.UseVisualStyleBackColor = True
        '
        'rbt_AllVer
        '
        Me.rbt_AllVer.AutoSize = True
        Me.rbt_AllVer.Checked = True
        Me.rbt_AllVer.Location = New System.Drawing.Point(99, 7)
        Me.rbt_AllVer.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_AllVer.Name = "rbt_AllVer"
        Me.rbt_AllVer.Size = New System.Drawing.Size(90, 20)
        Me.rbt_AllVer.TabIndex = 1
        Me.rbt_AllVer.TabStop = True
        Me.rbt_AllVer.Text = "所有版次"
        Me.rbt_AllVer.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(407, 15)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "測試人員"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 56)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Bug Status"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_StillWaitting)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_UnClose)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_QueryAll)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(86, 45)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(314, 35)
        Me.FlowLayoutPanel3.TabIndex = 3
        '
        'rbt_StillWaitting
        '
        Me.rbt_StillWaitting.AutoSize = True
        Me.rbt_StillWaitting.Location = New System.Drawing.Point(3, 7)
        Me.rbt_StillWaitting.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_StillWaitting.Name = "rbt_StillWaitting"
        Me.rbt_StillWaitting.Size = New System.Drawing.Size(74, 20)
        Me.rbt_StillWaitting.TabIndex = 0
        Me.rbt_StillWaitting.Text = "待複測"
        Me.rbt_StillWaitting.UseVisualStyleBackColor = True
        '
        'rbt_UnClose
        '
        Me.rbt_UnClose.AutoSize = True
        Me.rbt_UnClose.Location = New System.Drawing.Point(83, 7)
        Me.rbt_UnClose.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_UnClose.Name = "rbt_UnClose"
        Me.rbt_UnClose.Size = New System.Drawing.Size(90, 20)
        Me.rbt_UnClose.TabIndex = 1
        Me.rbt_UnClose.Text = "未結案的"
        Me.rbt_UnClose.UseVisualStyleBackColor = True
        '
        'rbt_QueryAll
        '
        Me.rbt_QueryAll.AutoSize = True
        Me.rbt_QueryAll.Checked = True
        Me.rbt_QueryAll.Location = New System.Drawing.Point(179, 7)
        Me.rbt_QueryAll.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_QueryAll.Name = "rbt_QueryAll"
        Me.rbt_QueryAll.Size = New System.Drawing.Size(90, 20)
        Me.rbt_QueryAll.TabIndex = 2
        Me.rbt_QueryAll.TabStop = True
        Me.rbt_QueryAll.Text = "所有狀態"
        Me.rbt_QueryAll.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_OnlyMe)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_All)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(486, 4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(479, 34)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'rbt_OnlyMe
        '
        Me.rbt_OnlyMe.AutoSize = True
        Me.rbt_OnlyMe.Checked = True
        Me.rbt_OnlyMe.Location = New System.Drawing.Point(3, 7)
        Me.rbt_OnlyMe.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_OnlyMe.Name = "rbt_OnlyMe"
        Me.rbt_OnlyMe.Size = New System.Drawing.Size(90, 20)
        Me.rbt_OnlyMe.TabIndex = 0
        Me.rbt_OnlyMe.TabStop = True
        Me.rbt_OnlyMe.Text = "屬於我的"
        Me.rbt_OnlyMe.UseVisualStyleBackColor = True
        '
        'rbt_All
        '
        Me.rbt_All.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_All.AutoSize = True
        Me.rbt_All.Location = New System.Drawing.Point(99, 7)
        Me.rbt_All.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.rbt_All.Name = "rbt_All"
        Me.rbt_All.Size = New System.Drawing.Size(90, 20)
        Me.rbt_All.TabIndex = 1
        Me.rbt_All.Text = "全部人員"
        Me.rbt_All.UseVisualStyleBackColor = True
        '
        'btn_QueryBugRecord
        '
        Me.btn_QueryBugRecord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_QueryBugRecord.Location = New System.Drawing.Point(486, 49)
        Me.btn_QueryBugRecord.Name = "btn_QueryBugRecord"
        Me.btn_QueryBugRecord.Size = New System.Drawing.Size(96, 27)
        Me.btn_QueryBugRecord.TabIndex = 4
        Me.btn_QueryBugRecord.Text = "查看"
        Me.btn_QueryBugRecord.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(975, 465)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "匯出報表"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.28205!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.71795!))
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel5, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.602151!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.39785!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(975, 465)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.rbt_QueryCurrVer)
        Me.FlowLayoutPanel5.Controls.Add(Me.rbt_QueryAllVer)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Export)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(343, 34)
        Me.FlowLayoutPanel5.TabIndex = 2
        '
        'rbt_QueryCurrVer
        '
        Me.rbt_QueryCurrVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_QueryCurrVer.AutoSize = True
        Me.rbt_QueryCurrVer.Checked = True
        Me.rbt_QueryCurrVer.Location = New System.Drawing.Point(3, 6)
        Me.rbt_QueryCurrVer.Name = "rbt_QueryCurrVer"
        Me.rbt_QueryCurrVer.Size = New System.Drawing.Size(90, 20)
        Me.rbt_QueryCurrVer.TabIndex = 1
        Me.rbt_QueryCurrVer.TabStop = True
        Me.rbt_QueryCurrVer.Text = "目前版次"
        Me.rbt_QueryCurrVer.UseVisualStyleBackColor = True
        '
        'rbt_QueryAllVer
        '
        Me.rbt_QueryAllVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_QueryAllVer.AutoSize = True
        Me.rbt_QueryAllVer.Location = New System.Drawing.Point(99, 6)
        Me.rbt_QueryAllVer.Name = "rbt_QueryAllVer"
        Me.rbt_QueryAllVer.Size = New System.Drawing.Size(90, 20)
        Me.rbt_QueryAllVer.TabIndex = 2
        Me.rbt_QueryAllVer.Text = "所有版次"
        Me.rbt_QueryAllVer.UseVisualStyleBackColor = True
        '
        'btn_Export
        '
        Me.btn_Export.Location = New System.Drawing.Point(195, 3)
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(96, 26)
        Me.btn_Export.TabIndex = 3
        Me.btn_Export.Text = "匯出報表"
        Me.btn_Export.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(493, 419)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "查詢條件"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Status, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Function, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_System, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.RadioButton3, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_TestVer, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Subject, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Desc, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Classify, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_Severity, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.ckb_TestUser, 4, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(487, 84)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'ckb_Status
        '
        Me.ckb_Status.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Status.AutoSize = True
        Me.ckb_Status.Location = New System.Drawing.Point(407, 11)
        Me.ckb_Status.Name = "ckb_Status"
        Me.ckb_Status.Size = New System.Drawing.Size(64, 20)
        Me.ckb_Status.TabIndex = 13
        Me.ckb_Status.Text = "Status"
        Me.ckb_Status.UseVisualStyleBackColor = True
        '
        'ckb_Function
        '
        Me.ckb_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Function.AutoSize = True
        Me.ckb_Function.Location = New System.Drawing.Point(310, 11)
        Me.ckb_Function.Name = "ckb_Function"
        Me.ckb_Function.Size = New System.Drawing.Size(91, 20)
        Me.ckb_Function.TabIndex = 12
        Me.ckb_Function.Text = "所屬功能"
        Me.ckb_Function.UseVisualStyleBackColor = True
        '
        'ckb_System
        '
        Me.ckb_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_System.AutoSize = True
        Me.ckb_System.Location = New System.Drawing.Point(197, 11)
        Me.ckb_System.Name = "ckb_System"
        Me.ckb_System.Size = New System.Drawing.Size(107, 20)
        Me.ckb_System.TabIndex = 11
        Me.ckb_System.Text = "所屬子系統"
        Me.ckb_System.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(12, 11)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(82, 20)
        Me.RadioButton3.TabIndex = 0
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "BUG_ID"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'ckb_TestVer
        '
        Me.ckb_TestVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_TestVer.AutoSize = True
        Me.ckb_TestVer.Location = New System.Drawing.Point(100, 11)
        Me.ckb_TestVer.Name = "ckb_TestVer"
        Me.ckb_TestVer.Size = New System.Drawing.Size(91, 20)
        Me.ckb_TestVer.TabIndex = 10
        Me.ckb_TestVer.Text = "測得版次"
        Me.ckb_TestVer.UseVisualStyleBackColor = True
        '
        'ckb_Subject
        '
        Me.ckb_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Subject.AutoSize = True
        Me.ckb_Subject.Location = New System.Drawing.Point(3, 53)
        Me.ckb_Subject.Name = "ckb_Subject"
        Me.ckb_Subject.Size = New System.Drawing.Size(91, 20)
        Me.ckb_Subject.TabIndex = 14
        Me.ckb_Subject.Text = "問題主述"
        Me.ckb_Subject.UseVisualStyleBackColor = True
        '
        'ckb_Desc
        '
        Me.ckb_Desc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Desc.AutoSize = True
        Me.ckb_Desc.Location = New System.Drawing.Point(100, 53)
        Me.ckb_Desc.Name = "ckb_Desc"
        Me.ckb_Desc.Size = New System.Drawing.Size(91, 20)
        Me.ckb_Desc.TabIndex = 15
        Me.ckb_Desc.Text = "問題描述"
        Me.ckb_Desc.UseVisualStyleBackColor = True
        '
        'ckb_Classify
        '
        Me.ckb_Classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Classify.AutoSize = True
        Me.ckb_Classify.Location = New System.Drawing.Point(310, 53)
        Me.ckb_Classify.Name = "ckb_Classify"
        Me.ckb_Classify.Size = New System.Drawing.Size(91, 20)
        Me.ckb_Classify.TabIndex = 16
        Me.ckb_Classify.Text = "問題類型"
        Me.ckb_Classify.UseVisualStyleBackColor = True
        '
        'ckb_Severity
        '
        Me.ckb_Severity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Severity.AutoSize = True
        Me.ckb_Severity.Location = New System.Drawing.Point(197, 53)
        Me.ckb_Severity.Name = "ckb_Severity"
        Me.ckb_Severity.Size = New System.Drawing.Size(75, 20)
        Me.ckb_Severity.TabIndex = 17
        Me.ckb_Severity.Text = "嚴重性"
        Me.ckb_Severity.UseVisualStyleBackColor = True
        '
        'ckb_TestUser
        '
        Me.ckb_TestUser.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_TestUser.AutoSize = True
        Me.ckb_TestUser.Location = New System.Drawing.Point(407, 53)
        Me.ckb_TestUser.Name = "ckb_TestUser"
        Me.ckb_TestUser.Size = New System.Drawing.Size(75, 20)
        Me.ckb_TestUser.TabIndex = 19
        Me.ckb_TestUser.Text = "測試者"
        Me.ckb_TestUser.UseVisualStyleBackColor = True
        '
        'JobQABugListGridviewUC1
        '
        Me.JobQABugListGridviewUC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JobQABugListGridviewUC1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.JobQABugListGridviewUC1.Location = New System.Drawing.Point(0, 0)
        Me.JobQABugListGridviewUC1.Margin = New System.Windows.Forms.Padding(4)
        Me.JobQABugListGridviewUC1.Name = "JobQABugListGridviewUC1"
        Me.JobQABugListGridviewUC1.Size = New System.Drawing.Size(969, 459)
        Me.JobQABugListGridviewUC1.TabIndex = 0
        '
        'CreateNewBugUC
        '
        Me.CreateNewBugUC.Bug_Id = Nothing
        Me.CreateNewBugUC.BugStatus = ""
        Me.CreateNewBugUC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreateNewBugUC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CreateNewBugUC.Location = New System.Drawing.Point(0, 0)
        Me.CreateNewBugUC.Margin = New System.Windows.Forms.Padding(4)
        Me.CreateNewBugUC.Name = "CreateNewBugUC"
        Me.CreateNewBugUC.Project_Id = Nothing
        Me.CreateNewBugUC.Size = New System.Drawing.Size(969, 459)
        Me.CreateNewBugUC.TabIndex = 0
        Me.CreateNewBugUC.Ver_Id = Nothing
        '
        'cbo_Hosp
        '
        Me.cbo_Hosp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Hosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Hosp.DropDownWidth = 20
        Me.cbo_Hosp.DroppedDown = False
        Me.cbo_Hosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Hosp.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_Hosp.Location = New System.Drawing.Point(329, 7)
        Me.cbo_Hosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Hosp.Name = "cbo_Hosp"
        Me.cbo_Hosp.SelectedIndex = -1
        Me.cbo_Hosp.SelectedItem = Nothing
        Me.cbo_Hosp.SelectedText = ""
        Me.cbo_Hosp.SelectedValue = ""
        Me.cbo_Hosp.SelectionStart = 0
        Me.cbo_Hosp.Size = New System.Drawing.Size(170, 24)
        Me.cbo_Hosp.TabIndex = 5
        Me.cbo_Hosp.uclDisplayIndex = "0,1"
        Me.cbo_Hosp.uclIsAutoClear = True
        Me.cbo_Hosp.uclIsFirstItemEmpty = True
        Me.cbo_Hosp.uclIsTextMode = False
        Me.cbo_Hosp.uclShowMsg = False
        Me.cbo_Hosp.uclValueIndex = "0"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(254, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "所屬醫院"
        '
        'JobQAJobListUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(983, 686)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.IsActiveAutoSize = False
        Me.KeyPreview = True
        Me.Name = "JobQAJobListUI"
        Me.TabText = "JobQAJobListUI"
        Me.Text = "JobQAJobListUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tlp_VerInfo.ResumeLayout(False)
        Me.tlp_VerInfo.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbo_Project As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_DeployKind As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents btn_Update As Windows.Forms.Button
    Friend WithEvents btn_Close As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents tlp_VerInfo As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents dtp_NewVerDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_NewVer As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txt_CurrentVer As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtp_CurrentVerDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents JobQABugListGridviewUC1 As JobQABugListGridviewUC
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents dgv_BugRecord As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents CreateNewBugUC As JobQACreateNewBugUC
    Friend WithEvents btn_CreateNew As Windows.Forms.Button
    Friend WithEvents ckb_IsClose As Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_StillWaitting As Windows.Forms.RadioButton
    Friend WithEvents rbt_UnClose As Windows.Forms.RadioButton
    Friend WithEvents rbt_QueryAll As Windows.Forms.RadioButton
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents btn_QueryBugRecord As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel4 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_CurrVer As Windows.Forms.RadioButton
    Friend WithEvents rbt_AllVer As Windows.Forms.RadioButton
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents rtb_VerDescription As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_OnlyMe As Windows.Forms.RadioButton
    Friend WithEvents rbt_All As Windows.Forms.RadioButton
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel4 As Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_QueryCurrVer As Windows.Forms.RadioButton
    Friend WithEvents rbt_QueryAllVer As Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel5 As Windows.Forms.TableLayoutPanel
    Friend WithEvents RadioButton3 As Windows.Forms.RadioButton
    Friend WithEvents btn_Export As Windows.Forms.Button
    Friend WithEvents ckb_Status As Windows.Forms.CheckBox
    Friend WithEvents ckb_Function As Windows.Forms.CheckBox
    Friend WithEvents ckb_System As Windows.Forms.CheckBox
    Friend WithEvents ckb_TestVer As Windows.Forms.CheckBox
    Friend WithEvents ckb_Subject As Windows.Forms.CheckBox
    Friend WithEvents ckb_Desc As Windows.Forms.CheckBox
    Friend WithEvents ckb_Classify As Windows.Forms.CheckBox
    Friend WithEvents ckb_Severity As Windows.Forms.CheckBox
    Friend WithEvents ckb_TestUser As Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents cbo_Hosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label11 As Windows.Forms.Label
End Class
