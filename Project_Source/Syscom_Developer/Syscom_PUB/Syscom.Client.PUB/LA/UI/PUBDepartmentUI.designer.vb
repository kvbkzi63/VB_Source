<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBDepartmentUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBDepartmentUI))
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.txtDeptCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblShortName = New System.Windows.Forms.Label()
        Me.txtShortName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chkDC = New System.Windows.Forms.CheckBox()
        Me.lblDeptName = New System.Windows.Forms.Label()
        Me.txtDeptName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblDeptEnName = New System.Windows.Forms.Label()
        Me.txtDeptEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chk_Is_Reg_Dept = New System.Windows.Forms.CheckBox()
        Me.lbl_Sort_Value = New System.Windows.Forms.Label()
        Me.txt_Sort_Value = New System.Windows.Forms.TextBox()
        Me.lbl_Emg_Dept_Name = New System.Windows.Forms.Label()
        Me.lbl_Emg_Dept_En_Name = New System.Windows.Forms.Label()
        Me.txt_Emg_Dept_Name = New System.Windows.Forms.TextBox()
        Me.txt_Emg_Dept_En_Name = New System.Windows.Forms.TextBox()
        Me.chk_Is_Emg_Dept = New System.Windows.Forms.CheckBox()
        Me.lbl_Emg_Sort_Value = New System.Windows.Forms.Label()
        Me.txt_Emg_Sort_Value = New System.Windows.Forms.TextBox()
        Me.lbl_Upper_Dept_Code = New System.Windows.Forms.Label()
        Me.txt_Upper_Dept_Code = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_Dept_Level_Id = New System.Windows.Forms.Label()
        Me.lbl_NHI_Opd_Dept_Code = New System.Windows.Forms.Label()
        Me.txt_NHI_Opd_Dept_Code = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lbl_NHI_Ipd_Dept_Code = New System.Windows.Forms.Label()
        Me.txt_NHI_Ipd_Dept_Code = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.chk_Is_Nrs_Station = New System.Windows.Forms.CheckBox()
        Me.lbl_Belong_Dept_Code = New System.Windows.Forms.Label()
        Me.txt_Belong_Dept_Code = New System.Windows.Forms.TextBox()
        Me.lbl_Ipd_Dept_Name = New System.Windows.Forms.Label()
        Me.txt_Ipd_Dept_Name = New System.Windows.Forms.TextBox()
        Me.lbl_Ipd_Dept_En_Name = New System.Windows.Forms.Label()
        Me.txt_Ipd_Dept_En_Name = New System.Windows.Forms.TextBox()
        Me.chk_Is_Ipd_Dept = New System.Windows.Forms.CheckBox()
        Me.lbl_Ipd_Sort_Value = New System.Windows.Forms.Label()
        Me.txt_Ipd_Sort_Value = New System.Windows.Forms.TextBox()
        Me.cbo_Dept_Level_Id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_Acc_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 248)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(944, 393)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(942, 356)
        '
        'dgvShowData
        '
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(942, 356)
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 7
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.lblDeptCode, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtDeptCode, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblShortName, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.txtShortName, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.chkDC, 4, 0)
        Me.tlp_nonButton.Controls.Add(Me.lblDeptName, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtDeptName, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lblDeptEnName, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.txtDeptEnName, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.chk_Is_Reg_Dept, 4, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Sort_Value, 5, 1)
        Me.tlp_nonButton.Controls.Add(Me.txt_Sort_Value, 6, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Emg_Dept_Name, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Emg_Dept_En_Name, 2, 2)
        Me.tlp_nonButton.Controls.Add(Me.txt_Emg_Dept_Name, 1, 2)
        Me.tlp_nonButton.Controls.Add(Me.txt_Emg_Dept_En_Name, 3, 2)
        Me.tlp_nonButton.Controls.Add(Me.chk_Is_Emg_Dept, 4, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Emg_Sort_Value, 5, 2)
        Me.tlp_nonButton.Controls.Add(Me.txt_Emg_Sort_Value, 6, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Upper_Dept_Code, 0, 5)
        Me.tlp_nonButton.Controls.Add(Me.txt_Upper_Dept_Code, 1, 5)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Dept_Level_Id, 2, 5)
        Me.tlp_nonButton.Controls.Add(Me.lbl_NHI_Opd_Dept_Code, 0, 4)
        Me.tlp_nonButton.Controls.Add(Me.txt_NHI_Opd_Dept_Code, 1, 4)
        Me.tlp_nonButton.Controls.Add(Me.lbl_NHI_Ipd_Dept_Code, 2, 4)
        Me.tlp_nonButton.Controls.Add(Me.txt_NHI_Ipd_Dept_Code, 3, 4)
        Me.tlp_nonButton.Controls.Add(Me.chk_Is_Nrs_Station, 4, 4)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Belong_Dept_Code, 5, 4)
        Me.tlp_nonButton.Controls.Add(Me.txt_Belong_Dept_Code, 6, 4)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Ipd_Dept_Name, 0, 3)
        Me.tlp_nonButton.Controls.Add(Me.txt_Ipd_Dept_Name, 1, 3)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Ipd_Dept_En_Name, 2, 3)
        Me.tlp_nonButton.Controls.Add(Me.txt_Ipd_Dept_En_Name, 3, 3)
        Me.tlp_nonButton.Controls.Add(Me.chk_Is_Ipd_Dept, 4, 3)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Ipd_Sort_Value, 5, 3)
        Me.tlp_nonButton.Controls.Add(Me.txt_Ipd_Sort_Value, 6, 3)
        Me.tlp_nonButton.Controls.Add(Me.cbo_Dept_Level_Id, 3, 5)
        Me.tlp_nonButton.Controls.Add(Me.Label1, 2, 6)
        Me.tlp_nonButton.Controls.Add(Me.cbo_Acc_Dept, 3, 6)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 7
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(944, 248)
        Me.tlp_nonButton.TabIndex = 20
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(28, 10)
        Me.lblDeptCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(80, 16)
        Me.lblDeptCode.TabIndex = 0
        Me.lblDeptCode.Text = "*科室代碼"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptCode.Location = New System.Drawing.Point(114, 5)
        Me.txtDeptCode.Margin = New System.Windows.Forms.Padding(2, 5, 6, 5)
        Me.txtDeptCode.MaxLength = 5
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptCode.SelectionStart = 0
        Me.txtDeptCode.Size = New System.Drawing.Size(156, 27)
        Me.txtDeptCode.TabIndex = 1
        Me.txtDeptCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptCode.ToolTipTag = Nothing
        Me.txtDeptCode.uclDollarSign = False
        Me.txtDeptCode.uclDotCount = 0
        Me.txtDeptCode.uclIntCount = 2
        Me.txtDeptCode.uclMinus = False
        Me.txtDeptCode.uclReadOnly = False
        Me.txtDeptCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptCode.uclTrimZero = True
        '
        'lblShortName
        '
        Me.lblShortName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblShortName.AutoSize = True
        Me.lblShortName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShortName.Location = New System.Drawing.Point(390, 10)
        Me.lblShortName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShortName.Name = "lblShortName"
        Me.lblShortName.Size = New System.Drawing.Size(40, 16)
        Me.lblShortName.TabIndex = 12
        Me.lblShortName.Text = "簡稱"
        '
        'txtShortName
        '
        Me.txtShortName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtShortName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtShortName.Location = New System.Drawing.Point(436, 5)
        Me.txtShortName.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.txtShortName.MaxLength = 20
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtShortName.SelectionStart = 0
        Me.txtShortName.Size = New System.Drawing.Size(204, 27)
        Me.txtShortName.TabIndex = 7
        Me.txtShortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtShortName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtShortName.ToolTipTag = Nothing
        Me.txtShortName.uclDollarSign = False
        Me.txtShortName.uclDotCount = 0
        Me.txtShortName.uclIntCount = 2
        Me.txtShortName.uclMinus = False
        Me.txtShortName.uclReadOnly = False
        Me.txtShortName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtShortName.uclTrimZero = True
        '
        'chkDC
        '
        Me.chkDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDC.AutoSize = True
        Me.chkDC.Location = New System.Drawing.Point(647, 8)
        Me.chkDC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDC.Name = "chkDC"
        Me.chkDC.Size = New System.Drawing.Size(59, 20)
        Me.chkDC.TabIndex = 10
        Me.chkDC.Text = "停用"
        Me.chkDC.UseVisualStyleBackColor = True
        '
        'lblDeptName
        '
        Me.lblDeptName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptName.AutoSize = True
        Me.lblDeptName.ForeColor = System.Drawing.Color.Red
        Me.lblDeptName.Location = New System.Drawing.Point(36, 46)
        Me.lblDeptName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeptName.Name = "lblDeptName"
        Me.lblDeptName.Size = New System.Drawing.Size(72, 16)
        Me.lblDeptName.TabIndex = 2
        Me.lblDeptName.Text = "科室名稱"
        '
        'txtDeptName
        '
        Me.txtDeptName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptName.Location = New System.Drawing.Point(114, 41)
        Me.txtDeptName.Margin = New System.Windows.Forms.Padding(2, 4, 4, 4)
        Me.txtDeptName.MaxLength = 100
        Me.txtDeptName.Name = "txtDeptName"
        Me.txtDeptName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptName.SelectionStart = 0
        Me.txtDeptName.Size = New System.Drawing.Size(204, 27)
        Me.txtDeptName.TabIndex = 2
        Me.txtDeptName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptName.ToolTipTag = Nothing
        Me.txtDeptName.uclDollarSign = False
        Me.txtDeptName.uclDotCount = 0
        Me.txtDeptName.uclIntCount = 2
        Me.txtDeptName.uclMinus = False
        Me.txtDeptName.uclReadOnly = False
        Me.txtDeptName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptName.uclTrimZero = True
        '
        'lblDeptEnName
        '
        Me.lblDeptEnName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptEnName.AutoSize = True
        Me.lblDeptEnName.ForeColor = System.Drawing.Color.Black
        Me.lblDeptEnName.Location = New System.Drawing.Point(358, 46)
        Me.lblDeptEnName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeptEnName.Name = "lblDeptEnName"
        Me.lblDeptEnName.Size = New System.Drawing.Size(72, 16)
        Me.lblDeptEnName.TabIndex = 4
        Me.lblDeptEnName.Text = "英文名稱"
        '
        'txtDeptEnName
        '
        Me.txtDeptEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptEnName.Location = New System.Drawing.Point(436, 40)
        Me.txtDeptEnName.Margin = New System.Windows.Forms.Padding(2, 3, 3, 5)
        Me.txtDeptEnName.MaxLength = 100
        Me.txtDeptEnName.Name = "txtDeptEnName"
        Me.txtDeptEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptEnName.SelectionStart = 0
        Me.txtDeptEnName.Size = New System.Drawing.Size(204, 27)
        Me.txtDeptEnName.TabIndex = 3
        Me.txtDeptEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptEnName.ToolTipTag = Nothing
        Me.txtDeptEnName.uclDollarSign = False
        Me.txtDeptEnName.uclDotCount = 0
        Me.txtDeptEnName.uclIntCount = 2
        Me.txtDeptEnName.uclMinus = False
        Me.txtDeptEnName.uclReadOnly = False
        Me.txtDeptEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptEnName.uclTrimZero = True
        '
        'chk_Is_Reg_Dept
        '
        Me.chk_Is_Reg_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Is_Reg_Dept.AutoSize = True
        Me.chk_Is_Reg_Dept.Location = New System.Drawing.Point(647, 44)
        Me.chk_Is_Reg_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.chk_Is_Reg_Dept.Name = "chk_Is_Reg_Dept"
        Me.chk_Is_Reg_Dept.Size = New System.Drawing.Size(123, 20)
        Me.chk_Is_Reg_Dept.TabIndex = 17
        Me.chk_Is_Reg_Dept.Text = "班表使用科別"
        Me.chk_Is_Reg_Dept.UseVisualStyleBackColor = True
        '
        'lbl_Sort_Value
        '
        Me.lbl_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sort_Value.AutoSize = True
        Me.lbl_Sort_Value.Location = New System.Drawing.Point(809, 46)
        Me.lbl_Sort_Value.Name = "lbl_Sort_Value"
        Me.lbl_Sort_Value.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Sort_Value.TabIndex = 18
        Me.lbl_Sort_Value.Text = "排序"
        '
        'txt_Sort_Value
        '
        Me.txt_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sort_Value.Location = New System.Drawing.Point(855, 41)
        Me.txt_Sort_Value.Name = "txt_Sort_Value"
        Me.txt_Sort_Value.Size = New System.Drawing.Size(63, 27)
        Me.txt_Sort_Value.TabIndex = 19
        '
        'lbl_Emg_Dept_Name
        '
        Me.lbl_Emg_Dept_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Emg_Dept_Name.AutoSize = True
        Me.lbl_Emg_Dept_Name.Location = New System.Drawing.Point(11, 80)
        Me.lbl_Emg_Dept_Name.Name = "lbl_Emg_Dept_Name"
        Me.lbl_Emg_Dept_Name.Size = New System.Drawing.Size(98, 16)
        Me.lbl_Emg_Dept_Name.TabIndex = 20
        Me.lbl_Emg_Dept_Name.Text = "科室名稱(急)"
        '
        'lbl_Emg_Dept_En_Name
        '
        Me.lbl_Emg_Dept_En_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Emg_Dept_En_Name.AutoSize = True
        Me.lbl_Emg_Dept_En_Name.Location = New System.Drawing.Point(333, 80)
        Me.lbl_Emg_Dept_En_Name.Name = "lbl_Emg_Dept_En_Name"
        Me.lbl_Emg_Dept_En_Name.Size = New System.Drawing.Size(98, 16)
        Me.lbl_Emg_Dept_En_Name.TabIndex = 21
        Me.lbl_Emg_Dept_En_Name.Text = "英文名稱(急)"
        '
        'txt_Emg_Dept_Name
        '
        Me.txt_Emg_Dept_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Emg_Dept_Name.Location = New System.Drawing.Point(114, 75)
        Me.txt_Emg_Dept_Name.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.txt_Emg_Dept_Name.Name = "txt_Emg_Dept_Name"
        Me.txt_Emg_Dept_Name.Size = New System.Drawing.Size(204, 27)
        Me.txt_Emg_Dept_Name.TabIndex = 22
        '
        'txt_Emg_Dept_En_Name
        '
        Me.txt_Emg_Dept_En_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Emg_Dept_En_Name.Location = New System.Drawing.Point(436, 75)
        Me.txt_Emg_Dept_En_Name.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.txt_Emg_Dept_En_Name.Name = "txt_Emg_Dept_En_Name"
        Me.txt_Emg_Dept_En_Name.Size = New System.Drawing.Size(204, 27)
        Me.txt_Emg_Dept_En_Name.TabIndex = 23
        '
        'chk_Is_Emg_Dept
        '
        Me.chk_Is_Emg_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Is_Emg_Dept.AutoSize = True
        Me.chk_Is_Emg_Dept.Location = New System.Drawing.Point(646, 78)
        Me.chk_Is_Emg_Dept.Name = "chk_Is_Emg_Dept"
        Me.chk_Is_Emg_Dept.Size = New System.Drawing.Size(91, 20)
        Me.chk_Is_Emg_Dept.TabIndex = 24
        Me.chk_Is_Emg_Dept.Text = "急診科別"
        Me.chk_Is_Emg_Dept.UseVisualStyleBackColor = True
        '
        'lbl_Emg_Sort_Value
        '
        Me.lbl_Emg_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Emg_Sort_Value.AutoSize = True
        Me.lbl_Emg_Sort_Value.Location = New System.Drawing.Point(783, 80)
        Me.lbl_Emg_Sort_Value.Name = "lbl_Emg_Sort_Value"
        Me.lbl_Emg_Sort_Value.Size = New System.Drawing.Size(66, 16)
        Me.lbl_Emg_Sort_Value.TabIndex = 25
        Me.lbl_Emg_Sort_Value.Text = "排序(急)"
        '
        'txt_Emg_Sort_Value
        '
        Me.txt_Emg_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Emg_Sort_Value.Location = New System.Drawing.Point(855, 75)
        Me.txt_Emg_Sort_Value.Name = "txt_Emg_Sort_Value"
        Me.txt_Emg_Sort_Value.Size = New System.Drawing.Size(63, 27)
        Me.txt_Emg_Sort_Value.TabIndex = 26
        '
        'lbl_Upper_Dept_Code
        '
        Me.lbl_Upper_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Upper_Dept_Code.AutoSize = True
        Me.lbl_Upper_Dept_Code.Location = New System.Drawing.Point(36, 181)
        Me.lbl_Upper_Dept_Code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Upper_Dept_Code.Name = "lbl_Upper_Dept_Code"
        Me.lbl_Upper_Dept_Code.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Upper_Dept_Code.TabIndex = 6
        Me.lbl_Upper_Dept_Code.Text = "上層科室"
        '
        'txt_Upper_Dept_Code
        '
        Me.txt_Upper_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Upper_Dept_Code.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Upper_Dept_Code.Location = New System.Drawing.Point(114, 176)
        Me.txt_Upper_Dept_Code.Margin = New System.Windows.Forms.Padding(2, 5, 6, 5)
        Me.txt_Upper_Dept_Code.MaxLength = 5
        Me.txt_Upper_Dept_Code.Name = "txt_Upper_Dept_Code"
        Me.txt_Upper_Dept_Code.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Upper_Dept_Code.SelectionStart = 0
        Me.txt_Upper_Dept_Code.Size = New System.Drawing.Size(156, 27)
        Me.txt_Upper_Dept_Code.TabIndex = 4
        Me.txt_Upper_Dept_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Upper_Dept_Code.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Upper_Dept_Code.ToolTipTag = Nothing
        Me.txt_Upper_Dept_Code.uclDollarSign = False
        Me.txt_Upper_Dept_Code.uclDotCount = 0
        Me.txt_Upper_Dept_Code.uclIntCount = 2
        Me.txt_Upper_Dept_Code.uclMinus = False
        Me.txt_Upper_Dept_Code.uclReadOnly = False
        Me.txt_Upper_Dept_Code.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Upper_Dept_Code.uclTrimZero = True
        '
        'lbl_Dept_Level_Id
        '
        Me.lbl_Dept_Level_Id.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Dept_Level_Id.AutoSize = True
        Me.lbl_Dept_Level_Id.ForeColor = System.Drawing.Color.Black
        Me.lbl_Dept_Level_Id.Location = New System.Drawing.Point(359, 181)
        Me.lbl_Dept_Level_Id.Name = "lbl_Dept_Level_Id"
        Me.lbl_Dept_Level_Id.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Dept_Level_Id.TabIndex = 29
        Me.lbl_Dept_Level_Id.Text = "科室層級"
        '
        'lbl_NHI_Opd_Dept_Code
        '
        Me.lbl_NHI_Opd_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_NHI_Opd_Dept_Code.AutoSize = True
        Me.lbl_NHI_Opd_Dept_Code.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_NHI_Opd_Dept_Code.Location = New System.Drawing.Point(4, 146)
        Me.lbl_NHI_Opd_Dept_Code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_NHI_Opd_Dept_Code.Name = "lbl_NHI_Opd_Dept_Code"
        Me.lbl_NHI_Opd_Dept_Code.Size = New System.Drawing.Size(104, 16)
        Me.lbl_NHI_Opd_Dept_Code.TabIndex = 14
        Me.lbl_NHI_Opd_Dept_Code.Text = "健保門診科別"
        '
        'txt_NHI_Opd_Dept_Code
        '
        Me.txt_NHI_Opd_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NHI_Opd_Dept_Code.doFlag = True
        Me.txt_NHI_Opd_Dept_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_NHI_Opd_Dept_Code.Location = New System.Drawing.Point(113, 141)
        Me.txt_NHI_Opd_Dept_Code.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.txt_NHI_Opd_Dept_Code.Name = "txt_NHI_Opd_Dept_Code"
        Me.txt_NHI_Opd_Dept_Code.Size = New System.Drawing.Size(163, 26)
        Me.txt_NHI_Opd_Dept_Code.TabIndex = 27
        Me.txt_NHI_Opd_Dept_Code.uclBaseDate = "2015/09/17"
        Me.txt_NHI_Opd_Dept_Code.uclCboWidth = 125
        Me.txt_NHI_Opd_Dept_Code.uclCodeName = ""
        Me.txt_NHI_Opd_Dept_Code.uclCodeName1 = ""
        Me.txt_NHI_Opd_Dept_Code.uclCodeName2 = ""
        Me.txt_NHI_Opd_Dept_Code.uclCodeValue = ""
        Me.txt_NHI_Opd_Dept_Code.uclCodeValue1 = ""
        Me.txt_NHI_Opd_Dept_Code.uclCodeValue2 = ""
        Me.txt_NHI_Opd_Dept_Code.uclControlFlag = True
        Me.txt_NHI_Opd_Dept_Code.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_NHI_Opd_Dept_Code.uclDisplayIndex = "0,1"
        Me.txt_NHI_Opd_Dept_Code.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_NHI_Opd_Dept_Code.uclIsAutoAddZero = False
        Me.txt_NHI_Opd_Dept_Code.uclIsBtnVisible = True
        Me.txt_NHI_Opd_Dept_Code.uclIsCheckDoctorOnDuty = False
        Me.txt_NHI_Opd_Dept_Code.uclIsCheckTime = True
        Me.txt_NHI_Opd_Dept_Code.uclIsEnglishDept = False
        Me.txt_NHI_Opd_Dept_Code.uclIsReturnDS = False
        Me.txt_NHI_Opd_Dept_Code.uclIsShowMsgBox = True
        Me.txt_NHI_Opd_Dept_Code.uclIsTextAutoClear = True
        Me.txt_NHI_Opd_Dept_Code.uclLabel = ""
        Me.txt_NHI_Opd_Dept_Code.uclMsgValue = Nothing
        Me.txt_NHI_Opd_Dept_Code.uclNoDataOpenWindow = False
        Me.txt_NHI_Opd_Dept_Code.uclPUBEmployeeProfessalKindId = ""
        Me.txt_NHI_Opd_Dept_Code.uclQueryField = Nothing
        Me.txt_NHI_Opd_Dept_Code.uclQueryValue = Nothing
        Me.txt_NHI_Opd_Dept_Code.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_NHI_Opd_Dept_Code.uclRegionKind = ""
        Me.txt_NHI_Opd_Dept_Code.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Insu_Dept
        Me.txt_NHI_Opd_Dept_Code.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txt_NHI_Opd_Dept_Code.uclTotalWidth = 8
        Me.txt_NHI_Opd_Dept_Code.uclXPosition = 225
        Me.txt_NHI_Opd_Dept_Code.uclYPosition = 120
        '
        'lbl_NHI_Ipd_Dept_Code
        '
        Me.lbl_NHI_Ipd_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_NHI_Ipd_Dept_Code.AutoSize = True
        Me.lbl_NHI_Ipd_Dept_Code.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_NHI_Ipd_Dept_Code.Location = New System.Drawing.Point(326, 146)
        Me.lbl_NHI_Ipd_Dept_Code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_NHI_Ipd_Dept_Code.Name = "lbl_NHI_Ipd_Dept_Code"
        Me.lbl_NHI_Ipd_Dept_Code.Size = New System.Drawing.Size(104, 16)
        Me.lbl_NHI_Ipd_Dept_Code.TabIndex = 16
        Me.lbl_NHI_Ipd_Dept_Code.Text = "健保住院科別"
        '
        'txt_NHI_Ipd_Dept_Code
        '
        Me.txt_NHI_Ipd_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_NHI_Ipd_Dept_Code.doFlag = True
        Me.txt_NHI_Ipd_Dept_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_NHI_Ipd_Dept_Code.Location = New System.Drawing.Point(436, 141)
        Me.txt_NHI_Ipd_Dept_Code.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txt_NHI_Ipd_Dept_Code.Name = "txt_NHI_Ipd_Dept_Code"
        Me.txt_NHI_Ipd_Dept_Code.Size = New System.Drawing.Size(162, 26)
        Me.txt_NHI_Ipd_Dept_Code.TabIndex = 28
        Me.txt_NHI_Ipd_Dept_Code.uclBaseDate = "2015/09/17"
        Me.txt_NHI_Ipd_Dept_Code.uclCboWidth = 125
        Me.txt_NHI_Ipd_Dept_Code.uclCodeName = ""
        Me.txt_NHI_Ipd_Dept_Code.uclCodeName1 = ""
        Me.txt_NHI_Ipd_Dept_Code.uclCodeName2 = ""
        Me.txt_NHI_Ipd_Dept_Code.uclCodeValue = ""
        Me.txt_NHI_Ipd_Dept_Code.uclCodeValue1 = ""
        Me.txt_NHI_Ipd_Dept_Code.uclCodeValue2 = ""
        Me.txt_NHI_Ipd_Dept_Code.uclControlFlag = True
        Me.txt_NHI_Ipd_Dept_Code.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_NHI_Ipd_Dept_Code.uclDisplayIndex = "0,1"
        Me.txt_NHI_Ipd_Dept_Code.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_NHI_Ipd_Dept_Code.uclIsAutoAddZero = False
        Me.txt_NHI_Ipd_Dept_Code.uclIsBtnVisible = True
        Me.txt_NHI_Ipd_Dept_Code.uclIsCheckDoctorOnDuty = False
        Me.txt_NHI_Ipd_Dept_Code.uclIsCheckTime = True
        Me.txt_NHI_Ipd_Dept_Code.uclIsEnglishDept = False
        Me.txt_NHI_Ipd_Dept_Code.uclIsReturnDS = False
        Me.txt_NHI_Ipd_Dept_Code.uclIsShowMsgBox = True
        Me.txt_NHI_Ipd_Dept_Code.uclIsTextAutoClear = True
        Me.txt_NHI_Ipd_Dept_Code.uclLabel = ""
        Me.txt_NHI_Ipd_Dept_Code.uclMsgValue = Nothing
        Me.txt_NHI_Ipd_Dept_Code.uclNoDataOpenWindow = False
        Me.txt_NHI_Ipd_Dept_Code.uclPUBEmployeeProfessalKindId = ""
        Me.txt_NHI_Ipd_Dept_Code.uclQueryField = Nothing
        Me.txt_NHI_Ipd_Dept_Code.uclQueryValue = Nothing
        Me.txt_NHI_Ipd_Dept_Code.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_NHI_Ipd_Dept_Code.uclRegionKind = ""
        Me.txt_NHI_Ipd_Dept_Code.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Insu_Dept
        Me.txt_NHI_Ipd_Dept_Code.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txt_NHI_Ipd_Dept_Code.uclTotalWidth = 8
        Me.txt_NHI_Ipd_Dept_Code.uclXPosition = 225
        Me.txt_NHI_Ipd_Dept_Code.uclYPosition = 120
        '
        'chk_Is_Nrs_Station
        '
        Me.chk_Is_Nrs_Station.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Is_Nrs_Station.AutoSize = True
        Me.chk_Is_Nrs_Station.ForeColor = System.Drawing.Color.Black
        Me.chk_Is_Nrs_Station.Location = New System.Drawing.Point(646, 144)
        Me.chk_Is_Nrs_Station.Name = "chk_Is_Nrs_Station"
        Me.chk_Is_Nrs_Station.Size = New System.Drawing.Size(123, 20)
        Me.chk_Is_Nrs_Station.TabIndex = 33
        Me.chk_Is_Nrs_Station.Text = "是否為護理站"
        Me.chk_Is_Nrs_Station.UseVisualStyleBackColor = True
        '
        'lbl_Belong_Dept_Code
        '
        Me.lbl_Belong_Dept_Code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Belong_Dept_Code.AutoSize = True
        Me.lbl_Belong_Dept_Code.Location = New System.Drawing.Point(777, 146)
        Me.lbl_Belong_Dept_Code.Name = "lbl_Belong_Dept_Code"
        Me.lbl_Belong_Dept_Code.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Belong_Dept_Code.TabIndex = 31
        Me.lbl_Belong_Dept_Code.Text = "歸屬科別"
        '
        'txt_Belong_Dept_Code
        '
        Me.txt_Belong_Dept_Code.Location = New System.Drawing.Point(855, 141)
        Me.txt_Belong_Dept_Code.Name = "txt_Belong_Dept_Code"
        Me.txt_Belong_Dept_Code.Size = New System.Drawing.Size(63, 27)
        Me.txt_Belong_Dept_Code.TabIndex = 32
        '
        'lbl_Ipd_Dept_Name
        '
        Me.lbl_Ipd_Dept_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Ipd_Dept_Name.AutoSize = True
        Me.lbl_Ipd_Dept_Name.Location = New System.Drawing.Point(11, 113)
        Me.lbl_Ipd_Dept_Name.Name = "lbl_Ipd_Dept_Name"
        Me.lbl_Ipd_Dept_Name.Size = New System.Drawing.Size(98, 16)
        Me.lbl_Ipd_Dept_Name.TabIndex = 34
        Me.lbl_Ipd_Dept_Name.Text = "科室名稱(住)"
        '
        'txt_Ipd_Dept_Name
        '
        Me.txt_Ipd_Dept_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Ipd_Dept_Name.Location = New System.Drawing.Point(114, 108)
        Me.txt_Ipd_Dept_Name.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.txt_Ipd_Dept_Name.Name = "txt_Ipd_Dept_Name"
        Me.txt_Ipd_Dept_Name.Size = New System.Drawing.Size(204, 27)
        Me.txt_Ipd_Dept_Name.TabIndex = 35
        '
        'lbl_Ipd_Dept_En_Name
        '
        Me.lbl_Ipd_Dept_En_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Ipd_Dept_En_Name.AutoSize = True
        Me.lbl_Ipd_Dept_En_Name.Location = New System.Drawing.Point(333, 113)
        Me.lbl_Ipd_Dept_En_Name.Name = "lbl_Ipd_Dept_En_Name"
        Me.lbl_Ipd_Dept_En_Name.Size = New System.Drawing.Size(98, 16)
        Me.lbl_Ipd_Dept_En_Name.TabIndex = 36
        Me.lbl_Ipd_Dept_En_Name.Text = "英文名稱(住)"
        '
        'txt_Ipd_Dept_En_Name
        '
        Me.txt_Ipd_Dept_En_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Ipd_Dept_En_Name.Location = New System.Drawing.Point(436, 108)
        Me.txt_Ipd_Dept_En_Name.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.txt_Ipd_Dept_En_Name.Name = "txt_Ipd_Dept_En_Name"
        Me.txt_Ipd_Dept_En_Name.Size = New System.Drawing.Size(204, 27)
        Me.txt_Ipd_Dept_En_Name.TabIndex = 37
        '
        'chk_Is_Ipd_Dept
        '
        Me.chk_Is_Ipd_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Is_Ipd_Dept.AutoSize = True
        Me.chk_Is_Ipd_Dept.Location = New System.Drawing.Point(646, 111)
        Me.chk_Is_Ipd_Dept.Name = "chk_Is_Ipd_Dept"
        Me.chk_Is_Ipd_Dept.Size = New System.Drawing.Size(91, 20)
        Me.chk_Is_Ipd_Dept.TabIndex = 38
        Me.chk_Is_Ipd_Dept.Text = "住院科別"
        Me.chk_Is_Ipd_Dept.UseVisualStyleBackColor = True
        '
        'lbl_Ipd_Sort_Value
        '
        Me.lbl_Ipd_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Ipd_Sort_Value.AutoSize = True
        Me.lbl_Ipd_Sort_Value.Location = New System.Drawing.Point(783, 113)
        Me.lbl_Ipd_Sort_Value.Name = "lbl_Ipd_Sort_Value"
        Me.lbl_Ipd_Sort_Value.Size = New System.Drawing.Size(66, 16)
        Me.lbl_Ipd_Sort_Value.TabIndex = 39
        Me.lbl_Ipd_Sort_Value.Text = "排序(住)"
        '
        'txt_Ipd_Sort_Value
        '
        Me.txt_Ipd_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Ipd_Sort_Value.Location = New System.Drawing.Point(855, 108)
        Me.txt_Ipd_Sort_Value.Name = "txt_Ipd_Sort_Value"
        Me.txt_Ipd_Sort_Value.Size = New System.Drawing.Size(63, 27)
        Me.txt_Ipd_Sort_Value.TabIndex = 40
        '
        'cbo_Dept_Level_Id
        '
        Me.cbo_Dept_Level_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Dept_Level_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Dept_Level_Id.DropDownWidth = 20
        Me.cbo_Dept_Level_Id.DroppedDown = False
        Me.cbo_Dept_Level_Id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Dept_Level_Id.Location = New System.Drawing.Point(436, 176)
        Me.cbo_Dept_Level_Id.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cbo_Dept_Level_Id.Name = "cbo_Dept_Level_Id"
        Me.cbo_Dept_Level_Id.SelectedIndex = -1
        Me.cbo_Dept_Level_Id.SelectedItem = Nothing
        Me.cbo_Dept_Level_Id.SelectedText = ""
        Me.cbo_Dept_Level_Id.SelectedValue = ""
        Me.cbo_Dept_Level_Id.SelectionStart = 0
        Me.cbo_Dept_Level_Id.Size = New System.Drawing.Size(156, 27)
        Me.cbo_Dept_Level_Id.TabIndex = 41
        Me.cbo_Dept_Level_Id.uclDisplayIndex = "0,1"
        Me.cbo_Dept_Level_Id.uclIsAutoClear = True
        Me.cbo_Dept_Level_Id.uclIsFirstItemEmpty = True
        Me.cbo_Dept_Level_Id.uclIsTextMode = False
        Me.cbo_Dept_Level_Id.uclShowMsg = False
        Me.cbo_Dept_Level_Id.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(359, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "成本中心"
        '
        'cbo_Acc_Dept
        '
        Me.cbo_Acc_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Acc_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Acc_Dept.DropDownWidth = 20
        Me.cbo_Acc_Dept.DroppedDown = False
        Me.cbo_Acc_Dept.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Acc_Dept.Location = New System.Drawing.Point(436, 214)
        Me.cbo_Acc_Dept.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cbo_Acc_Dept.Name = "cbo_Acc_Dept"
        Me.cbo_Acc_Dept.SelectedIndex = -1
        Me.cbo_Acc_Dept.SelectedItem = Nothing
        Me.cbo_Acc_Dept.SelectedText = ""
        Me.cbo_Acc_Dept.SelectedValue = ""
        Me.cbo_Acc_Dept.SelectionStart = 0
        Me.cbo_Acc_Dept.Size = New System.Drawing.Size(156, 27)
        Me.cbo_Acc_Dept.TabIndex = 43
        Me.cbo_Acc_Dept.uclDisplayIndex = "0,1"
        Me.cbo_Acc_Dept.uclIsAutoClear = True
        Me.cbo_Acc_Dept.uclIsFirstItemEmpty = True
        Me.cbo_Acc_Dept.uclIsTextMode = False
        Me.cbo_Acc_Dept.uclShowMsg = False
        Me.cbo_Acc_Dept.uclValueIndex = "0"
        '
        'PUBDepartmentUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.Name = "PUBDepartmentUI"
        Me.Text = "PUBDepartmentUI"
        Me.Controls.SetChildIndex(Me.tlp_nonButton, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents txtDeptCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblShortName As System.Windows.Forms.Label
    Friend WithEvents txtShortName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chkDC As System.Windows.Forms.CheckBox
    Friend WithEvents lblDeptName As System.Windows.Forms.Label
    Friend WithEvents txtDeptName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDeptEnName As System.Windows.Forms.Label
    Friend WithEvents txtDeptEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chk_Is_Reg_Dept As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Sort_Value As System.Windows.Forms.Label
    Friend WithEvents txt_Sort_Value As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Emg_Dept_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Emg_Dept_En_Name As System.Windows.Forms.Label
    Friend WithEvents txt_Emg_Dept_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Emg_Dept_En_Name As System.Windows.Forms.TextBox
    Friend WithEvents chk_Is_Emg_Dept As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Emg_Sort_Value As System.Windows.Forms.Label
    Friend WithEvents txt_Emg_Sort_Value As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Upper_Dept_Code As System.Windows.Forms.Label
    Friend WithEvents txt_Upper_Dept_Code As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_Dept_Level_Id As System.Windows.Forms.Label
    Friend WithEvents lbl_NHI_Opd_Dept_Code As System.Windows.Forms.Label
    Friend WithEvents txt_NHI_Opd_Dept_Code As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lbl_NHI_Ipd_Dept_Code As System.Windows.Forms.Label
    Friend WithEvents txt_NHI_Ipd_Dept_Code As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents chk_Is_Nrs_Station As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Belong_Dept_Code As System.Windows.Forms.Label
    Friend WithEvents txt_Belong_Dept_Code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Ipd_Dept_Name As System.Windows.Forms.Label
    Friend WithEvents txt_Ipd_Dept_Name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Ipd_Dept_En_Name As System.Windows.Forms.Label
    Friend WithEvents txt_Ipd_Dept_En_Name As System.Windows.Forms.TextBox
    Friend WithEvents chk_Is_Ipd_Dept As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Ipd_Sort_Value As System.Windows.Forms.Label
    Friend WithEvents txt_Ipd_Sort_Value As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Dept_Level_Id As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_Acc_Dept As Syscom.Client.UCL.UCLComboBoxUC
End Class
