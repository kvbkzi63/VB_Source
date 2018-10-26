<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMtnUI

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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMtnUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.IdTxtBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_userid = New System.Windows.Forms.Label()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.userid = New System.Windows.Forms.TextBox()
        Me.username = New System.Windows.Forms.TextBox()
        Me.lbl_mail = New System.Windows.Forms.Label()
        Me.mail = New System.Windows.Forms.TextBox()
        Me.lbl_Dept_Name = New System.Windows.Forms.Label()
        Me.tcq_DeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lbl_Section = New System.Windows.Forms.Label()
        Me.UclCbo_Section = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_JobTitle = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lbl_DCYN = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdoBtnN = New System.Windows.Forms.RadioButton()
        Me.RdoBtnY = New System.Windows.Forms.RadioButton()
        Me.lbl_birthday = New System.Windows.Forms.Label()
        Me.birthday = New DateTimePickerUCT.DateTimePickerUCT()
        Me.txtNrsLevelID = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblNrsLevelID = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rdo_inJobY = New System.Windows.Forms.RadioButton()
        Me.rdo_inJobN = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRoleSet = New System.Windows.Forms.Button()
        Me.btnResetPw = New System.Windows.Forms.Button()
        Me.btnEsc = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.Btn_ResetPwd = New System.Windows.Forms.Button()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_nonButton.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.btnFlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 6
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294.0!))
        Me.tlp_nonButton.Controls.Add(Me.IdTxtBox, 0, 3)
        Me.tlp_nonButton.Controls.Add(Me.Label3, 0, 3)
        Me.tlp_nonButton.Controls.Add(Me.lbl_userid, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_username, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.userid, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.username, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_mail, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.mail, 1, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Dept_Name, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.tcq_DeptCode, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Section, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.UclCbo_Section, 5, 0)
        Me.tlp_nonButton.Controls.Add(Me.Label1, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.cbo_JobTitle, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_DCYN, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.Panel2, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_birthday, 4, 2)
        Me.tlp_nonButton.Controls.Add(Me.birthday, 5, 2)
        Me.tlp_nonButton.Controls.Add(Me.txtNrsLevelID, 5, 3)
        Me.tlp_nonButton.Controls.Add(Me.lblNrsLevelID, 4, 3)
        Me.tlp_nonButton.Controls.Add(Me.FlowLayoutPanel1, 3, 3)
        Me.tlp_nonButton.Controls.Add(Me.Label2, 2, 3)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 4
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1008, 124)
        Me.tlp_nonButton.TabIndex = 0
        '
        'IdTxtBox
        '
        Me.IdTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.IdTxtBox.Location = New System.Drawing.Point(126, 94)
        Me.IdTxtBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IdTxtBox.Name = "IdTxtBox"
        Me.IdTxtBox.Size = New System.Drawing.Size(156, 27)
        Me.IdTxtBox.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "身份證字號"
        '
        'lbl_userid
        '
        Me.lbl_userid.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_userid.AutoSize = True
        Me.lbl_userid.ForeColor = System.Drawing.Color.Red
        Me.lbl_userid.Location = New System.Drawing.Point(24, 7)
        Me.lbl_userid.Name = "lbl_userid"
        Me.lbl_userid.Size = New System.Drawing.Size(96, 16)
        Me.lbl_userid.TabIndex = 0
        Me.lbl_userid.Text = "*使用者代碼"
        '
        'lbl_username
        '
        Me.lbl_username.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_username.AutoSize = True
        Me.lbl_username.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_username.Location = New System.Drawing.Point(24, 38)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(96, 16)
        Me.lbl_username.TabIndex = 1
        Me.lbl_username.Text = "*使用者姓名"
        '
        'userid
        '
        Me.userid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.userid.Location = New System.Drawing.Point(126, 2)
        Me.userid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.userid.Name = "userid"
        Me.userid.Size = New System.Drawing.Size(156, 27)
        Me.userid.TabIndex = 1
        '
        'username
        '
        Me.username.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.username.Location = New System.Drawing.Point(126, 33)
        Me.username.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(156, 27)
        Me.username.TabIndex = 3
        '
        'lbl_mail
        '
        Me.lbl_mail.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_mail.AutoSize = True
        Me.lbl_mail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_mail.Location = New System.Drawing.Point(40, 68)
        Me.lbl_mail.Name = "lbl_mail"
        Me.lbl_mail.Size = New System.Drawing.Size(80, 16)
        Me.lbl_mail.TabIndex = 6
        Me.lbl_mail.Text = "*電子郵件"
        '
        'mail
        '
        Me.mail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_nonButton.SetColumnSpan(Me.mail, 3)
        Me.mail.Location = New System.Drawing.Point(126, 63)
        Me.mail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.mail.Name = "mail"
        Me.mail.Size = New System.Drawing.Size(301, 27)
        Me.mail.TabIndex = 6
        '
        'lbl_Dept_Name
        '
        Me.lbl_Dept_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Dept_Name.AutoSize = True
        Me.lbl_Dept_Name.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Dept_Name.Location = New System.Drawing.Point(311, 7)
        Me.lbl_Dept_Name.Name = "lbl_Dept_Name"
        Me.lbl_Dept_Name.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Dept_Name.TabIndex = 4
        Me.lbl_Dept_Name.Text = "*部　　門"
        '
        'tcq_DeptCode
        '
        Me.tcq_DeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_DeptCode.doFlag = True
        Me.tcq_DeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_DeptCode.Location = New System.Drawing.Point(394, 2)
        Me.tcq_DeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_DeptCode.Name = "tcq_DeptCode"
        Me.tcq_DeptCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_DeptCode.TabIndex = 10
        Me.tcq_DeptCode.uclBaseDate = ""
        Me.tcq_DeptCode.uclCboWidth = 126
        Me.tcq_DeptCode.uclCodeName = ""
        Me.tcq_DeptCode.uclCodeName1 = ""
        Me.tcq_DeptCode.uclCodeName2 = ""
        Me.tcq_DeptCode.uclCodeValue = ""
        Me.tcq_DeptCode.uclCodeValue1 = ""
        Me.tcq_DeptCode.uclCodeValue2 = ""
        Me.tcq_DeptCode.uclConditionDate = ""
        Me.tcq_DeptCode.uclControlFlag = True
        Me.tcq_DeptCode.uclDeptCode = ""
        Me.tcq_DeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_DeptCode.uclDisplayIndex = "0,1"
        Me.tcq_DeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_DeptCode.uclIsAutoAddZero = False
        Me.tcq_DeptCode.uclIsBtnVisible = True
        Me.tcq_DeptCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_DeptCode.uclIsCheckDrLicense = True
        Me.tcq_DeptCode.uclIsCheckTime = True
        Me.tcq_DeptCode.uclIsEnglishDept = False
        Me.tcq_DeptCode.uclIsReturnDS = False
        Me.tcq_DeptCode.uclIsShowMsgBox = True
        Me.tcq_DeptCode.uclIsTextAutoClear = True
        Me.tcq_DeptCode.uclLabel = ""
        Me.tcq_DeptCode.uclMsgValue = Nothing
        Me.tcq_DeptCode.uclNoDataOpenWindow = False
        Me.tcq_DeptCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_DeptCode.uclQueryField = Nothing
        Me.tcq_DeptCode.uclQueryValue = Nothing
        Me.tcq_DeptCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_DeptCode.uclRegionKind = ""
        Me.tcq_DeptCode.uclRoles = ""
        Me.tcq_DeptCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.tcq_DeptCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.tcq_DeptCode.uclTotalWidth = 8
        Me.tcq_DeptCode.uclXPosition = 225
        Me.tcq_DeptCode.uclYPosition = 120
        '
        'lbl_Section
        '
        Me.lbl_Section.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Section.AutoSize = True
        Me.lbl_Section.ForeColor = System.Drawing.Color.Red
        Me.lbl_Section.Location = New System.Drawing.Point(631, 7)
        Me.lbl_Section.Name = "lbl_Section"
        Me.lbl_Section.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Section.TabIndex = 9
        Me.lbl_Section.Text = "*院　　區"
        Me.lbl_Section.Visible = False
        '
        'UclCbo_Section
        '
        Me.UclCbo_Section.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UclCbo_Section.DropDownWidth = 20
        Me.UclCbo_Section.DroppedDown = False
        Me.UclCbo_Section.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Section.Location = New System.Drawing.Point(714, 3)
        Me.UclCbo_Section.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Section.Name = "UclCbo_Section"
        Me.UclCbo_Section.SelectedIndex = -1
        Me.UclCbo_Section.SelectedItem = Nothing
        Me.UclCbo_Section.SelectedText = ""
        Me.UclCbo_Section.SelectedValue = ""
        Me.UclCbo_Section.SelectionStart = 1708362
        Me.UclCbo_Section.Size = New System.Drawing.Size(156, 24)
        Me.UclCbo_Section.TabIndex = 8
        Me.UclCbo_Section.uclDisplayIndex = "0,1"
        Me.UclCbo_Section.uclIsAutoClear = False
        Me.UclCbo_Section.uclIsFirstItemEmpty = True
        Me.UclCbo_Section.uclIsTextMode = False
        Me.UclCbo_Section.uclShowMsg = False
        Me.UclCbo_Section.uclValueIndex = "0"
        Me.UclCbo_Section.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "職　　稱"
        '
        'cbo_JobTitle
        '
        Me.cbo_JobTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_JobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_JobTitle.DropDownWidth = 20
        Me.cbo_JobTitle.DroppedDown = False
        Me.cbo_JobTitle.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_JobTitle.Location = New System.Drawing.Point(394, 34)
        Me.cbo_JobTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_JobTitle.Name = "cbo_JobTitle"
        Me.cbo_JobTitle.SelectedIndex = -1
        Me.cbo_JobTitle.SelectedItem = Nothing
        Me.cbo_JobTitle.SelectedText = ""
        Me.cbo_JobTitle.SelectedValue = ""
        Me.cbo_JobTitle.SelectionStart = 1052976
        Me.cbo_JobTitle.Size = New System.Drawing.Size(162, 24)
        Me.cbo_JobTitle.TabIndex = 12
        Me.cbo_JobTitle.uclDisplayIndex = "0,1"
        Me.cbo_JobTitle.uclIsAutoClear = True
        Me.cbo_JobTitle.uclIsFirstItemEmpty = True
        Me.cbo_JobTitle.uclIsTextMode = False
        Me.cbo_JobTitle.uclShowMsg = False
        Me.cbo_JobTitle.uclValueIndex = "0"
        '
        'lbl_DCYN
        '
        Me.lbl_DCYN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DCYN.AutoSize = True
        Me.lbl_DCYN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_DCYN.Location = New System.Drawing.Point(631, 38)
        Me.lbl_DCYN.Name = "lbl_DCYN"
        Me.lbl_DCYN.Size = New System.Drawing.Size(80, 16)
        Me.lbl_DCYN.TabIndex = 3
        Me.lbl_DCYN.Text = "*是否有效"
        Me.lbl_DCYN.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.Controls.Add(Me.RdoBtnN)
        Me.Panel2.Controls.Add(Me.RdoBtnY)
        Me.Panel2.Location = New System.Drawing.Point(718, 35)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(154, 22)
        Me.Panel2.TabIndex = 7
        Me.Panel2.Visible = False
        '
        'RdoBtnN
        '
        Me.RdoBtnN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RdoBtnN.AutoSize = True
        Me.RdoBtnN.Location = New System.Drawing.Point(58, 2)
        Me.RdoBtnN.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnN.Name = "RdoBtnN"
        Me.RdoBtnN.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnN.TabIndex = 8
        Me.RdoBtnN.TabStop = True
        Me.RdoBtnN.UseVisualStyleBackColor = True
        '
        'RdoBtnY
        '
        Me.RdoBtnY.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RdoBtnY.AutoSize = True
        Me.RdoBtnY.Location = New System.Drawing.Point(4, 2)
        Me.RdoBtnY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnY.Name = "RdoBtnY"
        Me.RdoBtnY.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnY.TabIndex = 7
        Me.RdoBtnY.TabStop = True
        Me.RdoBtnY.UseVisualStyleBackColor = True
        '
        'lbl_birthday
        '
        Me.lbl_birthday.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_birthday.AutoSize = True
        Me.lbl_birthday.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_birthday.Location = New System.Drawing.Point(631, 68)
        Me.lbl_birthday.Name = "lbl_birthday"
        Me.lbl_birthday.Size = New System.Drawing.Size(80, 16)
        Me.lbl_birthday.TabIndex = 2
        Me.lbl_birthday.Text = "*生　　日"
        Me.lbl_birthday.Visible = False
        '
        'birthday
        '
        Me.birthday.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.birthday.DisplayLocale = DateTimePickerUCT.Locale.TW
        Me.birthday.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.birthday.Location = New System.Drawing.Point(717, 63)
        Me.birthday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.birthday.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.birthday.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.birthday.Name = "birthday"
        Me.birthday.Size = New System.Drawing.Size(156, 27)
        Me.birthday.TabIndex = 5
        Me.birthday.Visible = False
        '
        'txtNrsLevelID
        '
        Me.txtNrsLevelID.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtNrsLevelID.Location = New System.Drawing.Point(717, 95)
        Me.txtNrsLevelID.MaxLength = 2
        Me.txtNrsLevelID.Name = "txtNrsLevelID"
        Me.txtNrsLevelID.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNrsLevelID.SelectionStart = 0
        Me.txtNrsLevelID.Size = New System.Drawing.Size(153, 26)
        Me.txtNrsLevelID.TabIndex = 15
        Me.txtNrsLevelID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNrsLevelID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtNrsLevelID.ToolTipTag = Nothing
        Me.txtNrsLevelID.uclDollarSign = False
        Me.txtNrsLevelID.uclDotCount = 0
        Me.txtNrsLevelID.uclIntCount = 2
        Me.txtNrsLevelID.uclMinus = False
        Me.txtNrsLevelID.uclReadOnly = False
        Me.txtNrsLevelID.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtNrsLevelID.uclTrimZero = True
        Me.txtNrsLevelID.Visible = False
        '
        'lblNrsLevelID
        '
        Me.lblNrsLevelID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblNrsLevelID.AutoSize = True
        Me.lblNrsLevelID.Location = New System.Drawing.Point(639, 100)
        Me.lblNrsLevelID.Name = "lblNrsLevelID"
        Me.lblNrsLevelID.Size = New System.Drawing.Size(72, 16)
        Me.lblNrsLevelID.TabIndex = 11
        Me.lblNrsLevelID.Text = "職　　級"
        Me.lblNrsLevelID.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rdo_inJobY)
        Me.FlowLayoutPanel1.Controls.Add(Me.rdo_inJobN)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(394, 92)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(163, 32)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'rdo_inJobY
        '
        Me.rdo_inJobY.AutoSize = True
        Me.rdo_inJobY.Location = New System.Drawing.Point(3, 3)
        Me.rdo_inJobY.Name = "rdo_inJobY"
        Me.rdo_inJobY.Size = New System.Drawing.Size(58, 20)
        Me.rdo_inJobY.TabIndex = 0
        Me.rdo_inJobY.TabStop = True
        Me.rdo_inJobY.Text = "在職"
        Me.rdo_inJobY.UseVisualStyleBackColor = True
        '
        'rdo_inJobN
        '
        Me.rdo_inJobN.AutoSize = True
        Me.rdo_inJobN.Location = New System.Drawing.Point(67, 3)
        Me.rdo_inJobN.Name = "rdo_inJobN"
        Me.rdo_inJobN.Size = New System.Drawing.Size(58, 20)
        Me.rdo_inJobN.TabIndex = 1
        Me.rdo_inJobN.TabStop = True
        Me.rdo_inJobN.Text = "離職"
        Me.rdo_inJobN.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "是否在職"
        '
        'btnFlowLayoutPanel
        '
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnRoleSet)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnResetPw)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnEsc)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnClear)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnQuery)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnDelete)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnUpdate)
        Me.btnFlowLayoutPanel.Controls.Add(Me.btnInsert)
        Me.btnFlowLayoutPanel.Controls.Add(Me.Btn_ResetPwd)
        Me.btnFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.btnFlowLayoutPanel.Location = New System.Drawing.Point(0, 124)
        Me.btnFlowLayoutPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFlowLayoutPanel.Name = "btnFlowLayoutPanel"
        Me.btnFlowLayoutPanel.Size = New System.Drawing.Size(1008, 35)
        Me.btnFlowLayoutPanel.TabIndex = 2
        '
        'btnRoleSet
        '
        Me.btnRoleSet.Location = New System.Drawing.Point(920, 3)
        Me.btnRoleSet.Name = "btnRoleSet"
        Me.btnRoleSet.Size = New System.Drawing.Size(85, 25)
        Me.btnRoleSet.TabIndex = 15
        Me.btnRoleSet.Text = "角色設定"
        Me.btnRoleSet.UseVisualStyleBackColor = True
        '
        'btnResetPw
        '
        Me.btnResetPw.Location = New System.Drawing.Point(829, 3)
        Me.btnResetPw.Name = "btnResetPw"
        Me.btnResetPw.Size = New System.Drawing.Size(85, 25)
        Me.btnResetPw.TabIndex = 14
        Me.btnResetPw.Text = "修改密碼"
        Me.btnResetPw.UseVisualStyleBackColor = True
        '
        'btnEsc
        '
        Me.btnEsc.Location = New System.Drawing.Point(738, 3)
        Me.btnEsc.Name = "btnEsc"
        Me.btnEsc.Size = New System.Drawing.Size(85, 25)
        Me.btnEsc.TabIndex = 16
        Me.btnEsc.Text = "ESC-退出"
        Me.btnEsc.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(657, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 25)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "F5-清除"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(576, 3)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 25)
        Me.btnQuery.TabIndex = 12
        Me.btnQuery.Text = "F1-查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(485, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(85, 25)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "SF12-刪除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(394, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(85, 25)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "F10-修改"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(303, 3)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(85, 25)
        Me.btnInsert.TabIndex = 9
        Me.btnInsert.Text = "F12-新增"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'Btn_ResetPwd
        '
        Me.Btn_ResetPwd.Location = New System.Drawing.Point(202, 3)
        Me.Btn_ResetPwd.Name = "Btn_ResetPwd"
        Me.Btn_ResetPwd.Size = New System.Drawing.Size(95, 25)
        Me.Btn_ResetPwd.TabIndex = 17
        Me.Btn_ResetPwd.Text = "重設密碼"
        Me.Btn_ResetPwd.UseVisualStyleBackColor = True
        '
        'dgv_ShowData
        '
        Me.dgv_ShowData.AllowUserToAddRows = False
        Me.dgv_ShowData.AllowUserToOrderColumns = False
        Me.dgv_ShowData.AllowUserToResizeColumns = True
        Me.dgv_ShowData.AllowUserToResizeRows = False
        Me.dgv_ShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ShowData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ShowData.ColumnHeadersHeight = 4
        Me.dgv_ShowData.ColumnHeadersVisible = True
        Me.dgv_ShowData.CurrentCell = Nothing
        Me.dgv_ShowData.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ShowData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(0, 159)
        Me.dgv_ShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(1008, 460)
        Me.dgv_ShowData.TabIndex = 3
        Me.dgv_ShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_ShowData.uclBatchColIndex = ""
        Me.dgv_ShowData.uclClickToCheck = False
        Me.dgv_ShowData.uclColumnAlignment = ""
        Me.dgv_ShowData.uclColumnCheckBox = False
        Me.dgv_ShowData.uclColumnControlType = ""
        Me.dgv_ShowData.uclColumnWidth = ""
        Me.dgv_ShowData.uclDoCellEnter = True
        Me.dgv_ShowData.uclHasNewRow = False
        Me.dgv_ShowData.uclHeaderText = ""
        Me.dgv_ShowData.uclIsAlternatingRowsColors = True
        Me.dgv_ShowData.uclIsComboBoxGridQuery = True
        Me.dgv_ShowData.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ShowData.uclIsDoOrderCheck = True
        Me.dgv_ShowData.uclIsDoQueryComboBoxGrid = True
        Me.dgv_ShowData.uclIsSortable = False
        Me.dgv_ShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowData.uclNonVisibleColIndex = ""
        Me.dgv_ShowData.uclReadOnly = False
        Me.dgv_ShowData.uclShowCellBorder = False
        Me.dgv_ShowData.uclSortColIndex = ""
        Me.dgv_ShowData.uclTreeMode = False
        Me.dgv_ShowData.uclVisibleColIndex = ""
        '
        'UserMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.dgv_ShowData)
        Me.Controls.Add(Me.btnFlowLayoutPanel)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "UserMtnUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "使用者授權維護"
        Me.Text = "使用者授權維護"
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.btnFlowLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_userid As System.Windows.Forms.Label
    Friend WithEvents lbl_username As System.Windows.Forms.Label
    Friend WithEvents lbl_birthday As System.Windows.Forms.Label
    Friend WithEvents lbl_DCYN As System.Windows.Forms.Label
    Friend WithEvents lbl_Dept_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_mail As System.Windows.Forms.Label
    Friend WithEvents userid As System.Windows.Forms.TextBox
    Friend WithEvents username As System.Windows.Forms.TextBox
    Friend WithEvents mail As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBtnY As System.Windows.Forms.RadioButton
    Friend WithEvents btnFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnResetPw As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnRoleSet As System.Windows.Forms.Button
    Friend WithEvents birthday As DateTimePickerUCT.DateTimePickerUCT
    Friend WithEvents UclCbo_Section As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lbl_Section As System.Windows.Forms.Label
    Friend WithEvents btnEsc As System.Windows.Forms.Button
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tcq_DeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_JobTitle As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rdo_inJobY As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_inJobN As System.Windows.Forms.RadioButton
    Friend WithEvents Btn_ResetPwd As System.Windows.Forms.Button
    Friend WithEvents lblNrsLevelID As System.Windows.Forms.Label
    Friend WithEvents txtNrsLevelID As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents IdTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
