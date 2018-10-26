<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateNFCReplyMsgUI
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
        Me.Tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ReplyMsg = New System.Windows.Forms.TextBox()
        Me.Txt_DateTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tcq_Recipient = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Enter = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.cbo_Status = New System.Windows.Forms.ComboBox()
        Me.Txt_EmployeeName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cbo_Phrase = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tlp_Main
        '
        Me.Tlp_Main.ColumnCount = 10
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.Tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.Tlp_Main.Controls.Add(Me.txt_ReplyMsg, 1, 4)
        Me.Tlp_Main.Controls.Add(Me.Txt_DateTime, 1, 2)
        Me.Tlp_Main.Controls.Add(Me.Label6, 0, 2)
        Me.Tlp_Main.Controls.Add(Me.Label4, 0, 1)
        Me.Tlp_Main.Controls.Add(Me.txt_Subject, 1, 1)
        Me.Tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.Tlp_Main.Controls.Add(Me.tcq_Recipient, 1, 0)
        Me.Tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.Tlp_Main.Controls.Add(Me.dtp_StartDate, 3, 0)
        Me.Tlp_Main.Controls.Add(Me.Label5, 4, 0)
        Me.Tlp_Main.Controls.Add(Me.dtp_EndDate, 5, 0)
        Me.Tlp_Main.Controls.Add(Me.Label3, 6, 0)
        Me.Tlp_Main.Controls.Add(Me.dgv, 0, 7)
        Me.Tlp_Main.Controls.Add(Me.btn_Clear, 8, 6)
        Me.Tlp_Main.Controls.Add(Me.btn_Enter, 7, 6)
        Me.Tlp_Main.Controls.Add(Me.btn_Query, 6, 6)
        Me.Tlp_Main.Controls.Add(Me.cbo_Status, 7, 0)
        Me.Tlp_Main.Controls.Add(Me.Txt_EmployeeName, 6, 2)
        Me.Tlp_Main.Controls.Add(Me.Label7, 5, 2)
        Me.Tlp_Main.Controls.Add(Me.Cbo_Phrase, 1, 3)
        Me.Tlp_Main.Controls.Add(Me.Label8, 0, 3)
        Me.Tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.Tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.Tlp_Main.Name = "Tlp_Main"
        Me.Tlp_Main.RowCount = 9
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.Tlp_Main.Size = New System.Drawing.Size(945, 641)
        Me.Tlp_Main.TabIndex = 0
        '
        'txt_ReplyMsg
        '
        Me.txt_ReplyMsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp_Main.SetColumnSpan(Me.txt_ReplyMsg, 8)
        Me.txt_ReplyMsg.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ReplyMsg.Location = New System.Drawing.Point(84, 137)
        Me.txt_ReplyMsg.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ReplyMsg.Multiline = True
        Me.txt_ReplyMsg.Name = "txt_ReplyMsg"
        Me.Tlp_Main.SetRowSpan(Me.txt_ReplyMsg, 2)
        Me.txt_ReplyMsg.Size = New System.Drawing.Size(827, 99)
        Me.txt_ReplyMsg.TabIndex = 23
        '
        'Txt_DateTime
        '
        Me.Txt_DateTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp_Main.SetColumnSpan(Me.Txt_DateTime, 2)
        Me.Txt_DateTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Txt_DateTime.Location = New System.Drawing.Point(84, 76)
        Me.Txt_DateTime.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_DateTime.Name = "Txt_DateTime"
        Me.Txt_DateTime.ReadOnly = True
        Me.Txt_DateTime.Size = New System.Drawing.Size(277, 27)
        Me.Txt_DateTime.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 81)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "發送日期"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(4, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "簡訊內容"
        '
        'txt_Subject
        '
        Me.Tlp_Main.SetColumnSpan(Me.txt_Subject, 8)
        Me.txt_Subject.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Subject.Location = New System.Drawing.Point(84, 41)
        Me.txt_Subject.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.ReadOnly = True
        Me.txt_Subject.Size = New System.Drawing.Size(827, 27)
        Me.txt_Subject.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "接收人員"
        '
        'tcq_Recipient
        '
        Me.tcq_Recipient.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tcq_Recipient.doFlag = True
        Me.tcq_Recipient.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_Recipient.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tcq_Recipient.Location = New System.Drawing.Point(80, 6)
        Me.tcq_Recipient.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_Recipient.Name = "tcq_Recipient"
        Me.tcq_Recipient.Size = New System.Drawing.Size(165, 24)
        Me.tcq_Recipient.TabIndex = 12
        Me.tcq_Recipient.uclBaseDate = ""
        Me.tcq_Recipient.uclCboWidth = 132
        Me.tcq_Recipient.uclCodeName = ""
        Me.tcq_Recipient.uclCodeName1 = ""
        Me.tcq_Recipient.uclCodeName2 = ""
        Me.tcq_Recipient.uclCodeValue = ""
        Me.tcq_Recipient.uclCodeValue1 = ""
        Me.tcq_Recipient.uclCodeValue2 = ""
        Me.tcq_Recipient.uclConditionDate = ""
        Me.tcq_Recipient.uclControlFlag = True
        Me.tcq_Recipient.uclDeptCode = ""
        Me.tcq_Recipient.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_Recipient.uclDisplayIndex = "0,1"
        Me.tcq_Recipient.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_Recipient.uclIsAutoAddZero = False
        Me.tcq_Recipient.uclIsBtnVisible = True
        Me.tcq_Recipient.uclIsCheckDoctorOnDuty = False
        Me.tcq_Recipient.uclIsCheckDrLicense = True
        Me.tcq_Recipient.uclIsCheckTime = True
        Me.tcq_Recipient.uclIsEnglishDept = False
        Me.tcq_Recipient.uclIsReturnDS = False
        Me.tcq_Recipient.uclIsShowMsgBox = True
        Me.tcq_Recipient.uclIsTextAutoClear = True
        Me.tcq_Recipient.uclLabel = ""
        Me.tcq_Recipient.uclMsgValue = Nothing
        Me.tcq_Recipient.uclNoDataOpenWindow = False
        Me.tcq_Recipient.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_Recipient.uclQueryField = Nothing
        Me.tcq_Recipient.uclQueryValue = Nothing
        Me.tcq_Recipient.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_Recipient.uclRegionKind = ""
        Me.tcq_Recipient.uclRoles = ""
        Me.tcq_Recipient.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_Recipient.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcq_Recipient.uclTotalWidth = 8
        Me.tcq_Recipient.uclXPosition = 225
        Me.tcq_Recipient.uclYPosition = 120
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(257, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "發送日期起迄"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_StartDate.Location = New System.Drawing.Point(369, 5)
        Me.dtp_StartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(113, 27)
        Me.dtp_StartDate.TabIndex = 2
        Me.dtp_StartDate.uclIsFixedBackColor = False
        Me.dtp_StartDate.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(490, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "~"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDate.Location = New System.Drawing.Point(514, 4)
        Me.dtp_EndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(112, 29)
        Me.dtp_EndDate.TabIndex = 4
        Me.dtp_EndDate.uclIsFixedBackColor = False
        Me.dtp_EndDate.uclReadOnly = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(681, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "類別"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToOrderColumns = False
        Me.dgv.AllowUserToResizeColumns = True
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 4
        Me.dgv.ColumnHeadersVisible = True
        Me.Tlp_Main.SetColumnSpan(Me.dgv, 9)
        Me.dgv.CurrentCell = Nothing
        Me.dgv.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv.Location = New System.Drawing.Point(4, 279)
        Me.dgv.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv.MultiSelect = False
        Me.dgv.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 41
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(927, 353)
        Me.dgv.TabIndex = 24
        Me.dgv.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv.uclBatchColIndex = ""
        Me.dgv.uclClickToCheck = False
        Me.dgv.uclColumnAlignment = ""
        Me.dgv.uclColumnCheckBox = False
        Me.dgv.uclColumnControlType = ""
        Me.dgv.uclColumnWidth = ""
        Me.dgv.uclDoCellEnter = True
        Me.dgv.uclHasNewRow = False
        Me.dgv.uclHeaderText = ""
        Me.dgv.uclIsAlternatingRowsColors = True
        Me.dgv.uclIsComboBoxGridQuery = True
        Me.dgv.uclIsComboxClickTriggerDropDown = False
        Me.dgv.uclIsDoOrderCheck = True
        Me.dgv.uclIsSortable = False
        Me.dgv.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv.uclNonVisibleColIndex = ""
        Me.dgv.uclReadOnly = False
        Me.dgv.uclShowCellBorder = False
        Me.dgv.uclSortColIndex = ""
        Me.dgv.uclTreeMode = False
        Me.dgv.uclVisibleColIndex = ""
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_Clear.Location = New System.Drawing.Point(824, 244)
        Me.btn_Clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(86, 27)
        Me.btn_Clear.TabIndex = 25
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Enter
        '
        Me.btn_Enter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Enter.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_Enter.Location = New System.Drawing.Point(729, 244)
        Me.btn_Enter.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Enter.Name = "btn_Enter"
        Me.btn_Enter.Size = New System.Drawing.Size(87, 27)
        Me.btn_Enter.TabIndex = 26
        Me.btn_Enter.Text = "F10-確認"
        Me.btn_Enter.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Query.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_Query.Location = New System.Drawing.Point(634, 244)
        Me.btn_Query.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(87, 27)
        Me.btn_Query.TabIndex = 15
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'cbo_Status
        '
        Me.Tlp_Main.SetColumnSpan(Me.cbo_Status, 2)
        Me.cbo_Status.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cbo_Status.FormattingEnabled = True
        Me.cbo_Status.Location = New System.Drawing.Point(729, 4)
        Me.cbo_Status.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Status.Name = "cbo_Status"
        Me.cbo_Status.Size = New System.Drawing.Size(182, 24)
        Me.cbo_Status.TabIndex = 14
        '
        'Txt_EmployeeName
        '
        Me.Tlp_Main.SetColumnSpan(Me.Txt_EmployeeName, 2)
        Me.Txt_EmployeeName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Txt_EmployeeName.Location = New System.Drawing.Point(729, 76)
        Me.Txt_EmployeeName.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_EmployeeName.Name = "Txt_EmployeeName"
        Me.Txt_EmployeeName.ReadOnly = True
        Me.Txt_EmployeeName.Size = New System.Drawing.Size(182, 27)
        Me.Txt_EmployeeName.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Tlp_Main.SetColumnSpan(Me.Label7, 2)
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(649, 81)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "開單醫師"
        '
        'Cbo_Phrase
        '
        Me.Cbo_Phrase.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Tlp_Main.SetColumnSpan(Me.Cbo_Phrase, 2)
        Me.Cbo_Phrase.FormattingEnabled = True
        Me.Cbo_Phrase.Location = New System.Drawing.Point(84, 110)
        Me.Cbo_Phrase.Name = "Cbo_Phrase"
        Me.Cbo_Phrase.Size = New System.Drawing.Size(277, 24)
        Me.Cbo_Phrase.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(4, 138)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Tlp_Main.SetRowSpan(Me.Label8, 2)
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "處理情形"
        '
        'UpdateNFCReplyMsgUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.Tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "UpdateNFCReplyMsgUI"
        Me.TabText = "危險值通報處理情形回覆"
        Me.Text = "危險值通報處理情形回覆"
        Me.Tlp_Main.ResumeLayout(False)
        Me.Tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tcq_Recipient As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_Status As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Subject As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_EmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ReplyMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgv As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Enter As System.Windows.Forms.Button
    Friend WithEvents Cbo_Phrase As System.Windows.Forms.ComboBox
End Class
