<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NfcQueryExportUI
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tcq_Send_user = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Recipient = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_Level = New System.Windows.Forms.ComboBox()
        Me.cbo_Status = New System.Windows.Forms.ComboBox()
        Me.cbo_Task = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chk_SMS = New System.Windows.Forms.CheckBox()
        Me.chk_Mail = New System.Windows.Forms.CheckBox()
        Me.chk_Window = New System.Windows.Forms.CheckBox()
        Me.dgv = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.cbo_Recipient = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tcq_Employee = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.tcq_Department = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lbl_Recipient2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_ExportExcel = New System.Windows.Forms.Button()
        Me.lbl_totalCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tcq_Send_user, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Recipient, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_StartDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EndDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Level, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Status, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Task, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Recipient, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Recipient2, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_totalCount, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 641)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tcq_Send_user
        '
        Me.tcq_Send_user.doFlag = True
        Me.tcq_Send_user.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_Send_user.Location = New System.Drawing.Point(126, 161)
        Me.tcq_Send_user.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_Send_user.Name = "tcq_Send_user"
        Me.tcq_Send_user.Size = New System.Drawing.Size(133, 26)
        Me.tcq_Send_user.TabIndex = 3
        Me.tcq_Send_user.uclCboWidth = 97
        Me.tcq_Send_user.uclCodeName = ""
        Me.tcq_Send_user.uclCodeValue1 = ""
        Me.tcq_Send_user.uclCodeValue2 = ""
        Me.tcq_Send_user.uclControlFlag = True
        Me.tcq_Send_user.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_Send_user.uclDisplayIndex = "0,1"
        Me.tcq_Send_user.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_Send_user.uclIsAutoAddZero = False
        Me.tcq_Send_user.uclIsCheckDoctorOnDuty = False
        Me.tcq_Send_user.uclIsReturnDS = False
        Me.tcq_Send_user.uclIsShowMsgBox = True
        Me.tcq_Send_user.uclIsTextAutoClear = True
        Me.tcq_Send_user.uclMsgValue = Nothing
        Me.tcq_Send_user.uclQueryField = Nothing
        Me.tcq_Send_user.uclQueryValue = Nothing
        Me.tcq_Send_user.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_Send_user.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_Send_user.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_Send_user.uclTotalWidth = 8
        Me.tcq_Send_user.uclXPosition = 225
        Me.tcq_Send_user.uclYPosition = 120
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "發送日期"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "通知層級"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "狀態"
        '
        'lbl_Recipient
        '
        Me.lbl_Recipient.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Recipient.AutoSize = True
        Me.lbl_Recipient.Location = New System.Drawing.Point(51, 134)
        Me.lbl_Recipient.Name = "lbl_Recipient"
        Me.lbl_Recipient.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Recipient.TabIndex = 0
        Me.lbl_Recipient.Text = "發送對象"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_StartDate.Location = New System.Drawing.Point(129, 9)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(120, 27)
        Me.dtp_StartDate.TabIndex = 1
        Me.dtp_StartDate.uclReadOnly = False
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDate.Location = New System.Drawing.Point(284, 9)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(120, 27)
        Me.dtp_EndDate.TabIndex = 1
        Me.dtp_EndDate.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "~"
        '
        'cbo_Level
        '
        Me.cbo_Level.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Level.FormattingEnabled = True
        Me.cbo_Level.Location = New System.Drawing.Point(129, 54)
        Me.cbo_Level.Name = "cbo_Level"
        Me.cbo_Level.Size = New System.Drawing.Size(121, 24)
        Me.cbo_Level.TabIndex = 4
        '
        'cbo_Status
        '
        Me.cbo_Status.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Status.FormattingEnabled = True
        Me.cbo_Status.Location = New System.Drawing.Point(129, 95)
        Me.cbo_Status.Name = "cbo_Status"
        Me.cbo_Status.Size = New System.Drawing.Size(121, 24)
        Me.cbo_Status.TabIndex = 4
        '
        'cbo_Task
        '
        Me.cbo_Task.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Task.FormattingEnabled = True
        Me.cbo_Task.Location = New System.Drawing.Point(473, 13)
        Me.cbo_Task.Name = "cbo_Task"
        Me.cbo_Task.Size = New System.Drawing.Size(344, 24)
        Me.cbo_Task.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(427, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "作業"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(427, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "型態"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chk_SMS)
        Me.Panel2.Controls.Add(Me.chk_Mail)
        Me.Panel2.Controls.Add(Me.chk_Window)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(473, 49)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(383, 34)
        Me.Panel2.TabIndex = 5
        '
        'chk_SMS
        '
        Me.chk_SMS.AutoSize = True
        Me.chk_SMS.Checked = True
        Me.chk_SMS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_SMS.Location = New System.Drawing.Point(197, 7)
        Me.chk_SMS.Name = "chk_SMS"
        Me.chk_SMS.Size = New System.Drawing.Size(59, 20)
        Me.chk_SMS.TabIndex = 2
        Me.chk_SMS.Text = "簡訊"
        Me.chk_SMS.UseVisualStyleBackColor = True
        '
        'chk_Mail
        '
        Me.chk_Mail.AutoSize = True
        Me.chk_Mail.Checked = True
        Me.chk_Mail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Mail.Location = New System.Drawing.Point(100, 7)
        Me.chk_Mail.Name = "chk_Mail"
        Me.chk_Mail.Size = New System.Drawing.Size(91, 20)
        Me.chk_Mail.TabIndex = 1
        Me.chk_Mail.Text = "電子郵件"
        Me.chk_Mail.UseVisualStyleBackColor = True
        '
        'chk_Window
        '
        Me.chk_Window.AutoSize = True
        Me.chk_Window.Checked = True
        Me.chk_Window.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Window.Location = New System.Drawing.Point(3, 7)
        Me.chk_Window.Name = "chk_Window"
        Me.chk_Window.Size = New System.Drawing.Size(91, 20)
        Me.chk_Window.TabIndex = 0
        Me.chk_Window.Text = "浮動視窗"
        Me.chk_Window.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToOrderColumns = False
        Me.dgv.AllowUserToResizeColumns = True
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv.ColumnHeadersHeight = 4
        Me.dgv.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv, 7)
        Me.dgv.CurrentCell = Nothing
        Me.dgv.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv.Location = New System.Drawing.Point(4, 199)
        Me.dgv.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv.MultiSelect = False
        Me.dgv.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 41
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(956, 438)
        Me.dgv.TabIndex = 8
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
        'cbo_Recipient
        '
        Me.cbo_Recipient.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Recipient.FormattingEnabled = True
        Me.cbo_Recipient.Location = New System.Drawing.Point(129, 130)
        Me.cbo_Recipient.Name = "cbo_Recipient"
        Me.cbo_Recipient.Size = New System.Drawing.Size(121, 24)
        Me.cbo_Recipient.TabIndex = 4
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.tcq_Employee)
        Me.Panel1.Controls.Add(Me.tcq_Department)
        Me.Panel1.Location = New System.Drawing.Point(414, 127)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 31)
        Me.Panel1.TabIndex = 3
        '
        'tcq_Employee
        '
        Me.tcq_Employee.doFlag = True
        Me.tcq_Employee.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_Employee.Location = New System.Drawing.Point(0, 3)
        Me.tcq_Employee.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_Employee.Name = "tcq_Employee"
        Me.tcq_Employee.Size = New System.Drawing.Size(183, 26)
        Me.tcq_Employee.TabIndex = 0
        Me.tcq_Employee.uclCboWidth = 147
        Me.tcq_Employee.uclCodeName = ""
        Me.tcq_Employee.uclCodeValue1 = ""
        Me.tcq_Employee.uclCodeValue2 = ""
        Me.tcq_Employee.uclControlFlag = True
        Me.tcq_Employee.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_Employee.uclDisplayIndex = "0,1"
        Me.tcq_Employee.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_Employee.uclIsAutoAddZero = False
        Me.tcq_Employee.uclIsCheckDoctorOnDuty = False
        Me.tcq_Employee.uclIsReturnDS = False
        Me.tcq_Employee.uclIsShowMsgBox = True
        Me.tcq_Employee.uclIsTextAutoClear = True
        Me.tcq_Employee.uclMsgValue = Nothing
        Me.tcq_Employee.uclQueryField = Nothing
        Me.tcq_Employee.uclQueryValue = Nothing
        Me.tcq_Employee.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_Employee.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_Employee.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_Employee.uclTotalWidth = 8
        Me.tcq_Employee.uclXPosition = 225
        Me.tcq_Employee.uclYPosition = 120
        '
        'tcq_Department
        '
        Me.tcq_Department.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_Department.doFlag = True
        Me.tcq_Department.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_Department.Location = New System.Drawing.Point(0, 3)
        Me.tcq_Department.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_Department.Name = "tcq_Department"
        Me.tcq_Department.Size = New System.Drawing.Size(183, 26)
        Me.tcq_Department.TabIndex = 2
        Me.tcq_Department.uclCboWidth = 147
        Me.tcq_Department.uclCodeName = ""
        Me.tcq_Department.uclCodeValue1 = ""
        Me.tcq_Department.uclCodeValue2 = ""
        Me.tcq_Department.uclControlFlag = True
        Me.tcq_Department.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_Department.uclDisplayIndex = "0,1"
        Me.tcq_Department.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_Department.uclIsAutoAddZero = False
        Me.tcq_Department.uclIsCheckDoctorOnDuty = False
        Me.tcq_Department.uclIsReturnDS = False
        Me.tcq_Department.uclIsShowMsgBox = True
        Me.tcq_Department.uclIsTextAutoClear = True
        Me.tcq_Department.uclMsgValue = Nothing
        Me.tcq_Department.uclQueryField = Nothing
        Me.tcq_Department.uclQueryValue = Nothing
        Me.tcq_Department.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_Department.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.tcq_Department.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_Department.uclTotalWidth = 8
        Me.tcq_Department.uclXPosition = 225
        Me.tcq_Department.uclYPosition = 120
        '
        'lbl_Recipient2
        '
        Me.lbl_Recipient2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Recipient2.AutoSize = True
        Me.lbl_Recipient2.Location = New System.Drawing.Point(336, 134)
        Me.lbl_Recipient2.Name = "lbl_Recipient2"
        Me.lbl_Recipient2.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Recipient2.TabIndex = 0
        Me.lbl_Recipient2.Text = "單位代碼"
        '
        'Panel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel3, 2)
        Me.Panel3.Controls.Add(Me.btn_Query)
        Me.Panel3.Controls.Add(Me.btn_ExportExcel)
        Me.Panel3.Location = New System.Drawing.Point(473, 164)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(461, 28)
        Me.Panel3.TabIndex = 9
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(0, 0)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(78, 28)
        Me.btn_Query.TabIndex = 7
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_ExportExcel
        '
        Me.btn_ExportExcel.Location = New System.Drawing.Point(87, 0)
        Me.btn_ExportExcel.Name = "btn_ExportExcel"
        Me.btn_ExportExcel.Size = New System.Drawing.Size(107, 28)
        Me.btn_ExportExcel.TabIndex = 6
        Me.btn_ExportExcel.Text = "F7-匯出Excel"
        Me.btn_ExportExcel.UseVisualStyleBackColor = True
        '
        'lbl_totalCount
        '
        Me.lbl_totalCount.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_totalCount.AutoSize = True
        Me.lbl_totalCount.Location = New System.Drawing.Point(324, 170)
        Me.lbl_totalCount.Name = "lbl_totalCount"
        Me.lbl_totalCount.Size = New System.Drawing.Size(84, 16)
        Me.lbl_totalCount.TabIndex = 0
        Me.lbl_totalCount.Text = "總計：0 筆"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "發送人員"
        '
        'NfcQueryExportUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NfcQueryExportUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "訊息系統查詢作業"
        Me.Text = "訊息系統查詢作業"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Recipient As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tcq_Department As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cbo_Level As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Status As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Task As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chk_SMS As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Mail As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Window As System.Windows.Forms.CheckBox
    Friend WithEvents btn_ExportExcel As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents lbl_totalCount As System.Windows.Forms.Label
    Friend WithEvents dgv As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tcq_Employee As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cbo_Recipient As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Recipient2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tcq_Send_user As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
