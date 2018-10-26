<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBConsultDoctorUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveMgr = Nothing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.lb_rulebelong_item = New System.Windows.Forms.Label
        Me.ucl_txt_drname = New Syscom.Client.UCL.UCLTextBoxUC
        Me.lb_drname = New System.Windows.Forms.Label
        Me.lb_employeecode = New System.Windows.Forms.Label
        Me.ucl_txt_employeecode = New Syscom.Client.UCL.UCLTextBoxUC
        Me.btn_add = New System.Windows.Forms.Button
        Me.gb_corr_rule = New System.Windows.Forms.GroupBox
        Me.ucl_dgv_doctor = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.ucl_tcq_doctor = New Syscom.Client.UCL.UCLTextCodeQueryUI
        Me.lb_dept = New System.Windows.Forms.Label
        Me.ucl_txt_dept = New Syscom.Client.UCL.UCLTextBoxUC
        Me.btn_clear = New System.Windows.Forms.Button
        Me.tlp_parent.SuspendLayout()
        Me.gb_corr_rule.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 3
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Controls.Add(Me.lb_rulebelong_item, 0, 0)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_drname, 1, 1)
        Me.tlp_parent.Controls.Add(Me.lb_drname, 0, 1)
        Me.tlp_parent.Controls.Add(Me.lb_employeecode, 0, 3)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_employeecode, 1, 3)
        Me.tlp_parent.Controls.Add(Me.gb_corr_rule, 0, 4)
        Me.tlp_parent.Controls.Add(Me.ucl_tcq_doctor, 1, 0)
        Me.tlp_parent.Controls.Add(Me.lb_dept, 0, 2)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_dept, 1, 2)
        Me.tlp_parent.Controls.Add(Me.btn_clear, 2, 2)
        Me.tlp_parent.Controls.Add(Me.btn_confirm, 2, 1)
        Me.tlp_parent.Controls.Add(Me.btn_add, 2, 0)
        Me.tlp_parent.Location = New System.Drawing.Point(2, 3)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 5
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(510, 422)
        Me.tlp_parent.TabIndex = 0
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_confirm.Location = New System.Drawing.Point(340, 31)
        Me.btn_confirm.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 13
        Me.btn_confirm.Text = "F10-確定"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'lb_rulebelong_item
        '
        Me.lb_rulebelong_item.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_rulebelong_item.AutoSize = True
        Me.lb_rulebelong_item.ForeColor = System.Drawing.Color.Red
        Me.lb_rulebelong_item.Location = New System.Drawing.Point(45, 7)
        Me.lb_rulebelong_item.Name = "lb_rulebelong_item"
        Me.lb_rulebelong_item.Size = New System.Drawing.Size(72, 16)
        Me.lb_rulebelong_item.TabIndex = 2
        Me.lb_rulebelong_item.Text = "選擇醫師"
        '
        'ucl_txt_drname
        '
        Me.ucl_txt_drname.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_drname.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_drname.Location = New System.Drawing.Point(120, 31)
        Me.ucl_txt_drname.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_drname.MaxLength = 10
        Me.ucl_txt_drname.Name = "ucl_txt_drname"
        Me.ucl_txt_drname.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_drname.SelectionStart = 0
        Me.ucl_txt_drname.Size = New System.Drawing.Size(160, 27)
        Me.ucl_txt_drname.TabIndex = 7
        Me.ucl_txt_drname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_drname.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_drname.uclDollarSign = False
        Me.ucl_txt_drname.uclDotCount = 0
        Me.ucl_txt_drname.uclIntCount = 2
        Me.ucl_txt_drname.uclMinus = False
        Me.ucl_txt_drname.uclReadOnly = False
        Me.ucl_txt_drname.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lb_drname
        '
        Me.lb_drname.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_drname.AutoSize = True
        Me.lb_drname.Location = New System.Drawing.Point(45, 37)
        Me.lb_drname.Name = "lb_drname"
        Me.lb_drname.Size = New System.Drawing.Size(72, 16)
        Me.lb_drname.TabIndex = 3
        Me.lb_drname.Text = "醫師姓名"
        '
        'lb_employeecode
        '
        Me.lb_employeecode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_employeecode.AutoSize = True
        Me.lb_employeecode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lb_employeecode.Location = New System.Drawing.Point(45, 97)
        Me.lb_employeecode.Name = "lb_employeecode"
        Me.lb_employeecode.Size = New System.Drawing.Size(72, 16)
        Me.lb_employeecode.TabIndex = 16
        Me.lb_employeecode.Text = "醫師員編"
        '
        'ucl_txt_employeecode
        '
        Me.ucl_txt_employeecode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_employeecode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_txt_employeecode.Location = New System.Drawing.Point(120, 91)
        Me.ucl_txt_employeecode.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_employeecode.MaxLength = 100
        Me.ucl_txt_employeecode.Name = "ucl_txt_employeecode"
        Me.ucl_txt_employeecode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_employeecode.SelectionStart = 0
        Me.ucl_txt_employeecode.Size = New System.Drawing.Size(160, 27)
        Me.ucl_txt_employeecode.TabIndex = 15
        Me.ucl_txt_employeecode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_employeecode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_employeecode.uclDollarSign = False
        Me.ucl_txt_employeecode.uclDotCount = 0
        Me.ucl_txt_employeecode.uclIntCount = 2
        Me.ucl_txt_employeecode.uclMinus = False
        Me.ucl_txt_employeecode.uclReadOnly = False
        Me.ucl_txt_employeecode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(340, 0)
        Me.btn_add.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(90, 27)
        Me.btn_add.TabIndex = 11
        Me.btn_add.Text = "加入醫師"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'gb_corr_rule
        '
        Me.tlp_parent.SetColumnSpan(Me.gb_corr_rule, 3)
        Me.gb_corr_rule.Controls.Add(Me.ucl_dgv_doctor)
        Me.gb_corr_rule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_corr_rule.Location = New System.Drawing.Point(3, 123)
        Me.gb_corr_rule.Name = "gb_corr_rule"
        Me.gb_corr_rule.Size = New System.Drawing.Size(504, 296)
        Me.gb_corr_rule.TabIndex = 0
        Me.gb_corr_rule.TabStop = False
        Me.gb_corr_rule.Text = "查詢醫師資料"
        '
        'ucl_dgv_doctor
        '
        Me.ucl_dgv_doctor.AllowUserToAddRows = False
        Me.ucl_dgv_doctor.AllowUserToOrderColumns = False
        Me.ucl_dgv_doctor.AllowUserToResizeColumns = True
        Me.ucl_dgv_doctor.AllowUserToResizeRows = False
        Me.ucl_dgv_doctor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucl_dgv_doctor.ColumnHeadersVisible = True
        Me.ucl_dgv_doctor.CurrentCell = Nothing
        Me.ucl_dgv_doctor.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucl_dgv_doctor.DefaultCellStyle = DataGridViewCellStyle1
        Me.ucl_dgv_doctor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_dgv_doctor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.ucl_dgv_doctor.Location = New System.Drawing.Point(3, 23)
        Me.ucl_dgv_doctor.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_dgv_doctor.MultiSelect = False
        Me.ucl_dgv_doctor.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.ucl_dgv_doctor.Name = "ucl_dgv_doctor"
        Me.ucl_dgv_doctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucl_dgv_doctor.Size = New System.Drawing.Size(498, 270)
        Me.ucl_dgv_doctor.TabIndex = 17
        Me.ucl_dgv_doctor.uclClickToCheck = False
        Me.ucl_dgv_doctor.uclColumnAlignment = ""
        Me.ucl_dgv_doctor.uclColumnCheckBox = False
        Me.ucl_dgv_doctor.uclColumnControlType = ""
        Me.ucl_dgv_doctor.uclColumnWidth = ""
        Me.ucl_dgv_doctor.uclDoCellEnter = True
        Me.ucl_dgv_doctor.uclHasNewRow = False
        Me.ucl_dgv_doctor.uclHeaderText = ""
        Me.ucl_dgv_doctor.uclIsComboBoxGridQuery = True
        Me.ucl_dgv_doctor.uclIsSortable = False
        Me.ucl_dgv_doctor.uclNonVisibleColIndex = ""
        Me.ucl_dgv_doctor.uclReadOnly = False
        Me.ucl_dgv_doctor.uclShowCellBorder = False
        Me.ucl_dgv_doctor.uclSortColIndex = ""
        Me.ucl_dgv_doctor.uclTreeMode = False
        Me.ucl_dgv_doctor.uclVisibleColIndex = ""
        '
        'ucl_tcq_doctor
        '
        Me.ucl_tcq_doctor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_tcq_doctor.doFlag = True
        Me.ucl_tcq_doctor.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_tcq_doctor.Location = New System.Drawing.Point(120, 2)
        Me.ucl_tcq_doctor.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_tcq_doctor.Name = "ucl_tcq_doctor"
        Me.ucl_tcq_doctor.Size = New System.Drawing.Size(160, 26)
        Me.ucl_tcq_doctor.TabIndex = 17
        Me.ucl_tcq_doctor.uclCboWidth = 124
        Me.ucl_tcq_doctor.uclCodeName = ""
        Me.ucl_tcq_doctor.uclCodeValue1 = ""
        Me.ucl_tcq_doctor.uclCodeValue2 = ""
        Me.ucl_tcq_doctor.uclControlFlag = True
        Me.ucl_tcq_doctor.uclDisplayIndex = "0,1"
        Me.ucl_tcq_doctor.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ucl_tcq_doctor.uclIsReturnDS = False
        Me.ucl_tcq_doctor.uclIsShowMsgBox = True
        Me.ucl_tcq_doctor.uclIsTextAutoClear = True
        Me.ucl_tcq_doctor.uclQueryValue = Nothing
        Me.ucl_tcq_doctor.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.ucl_tcq_doctor.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.ucl_tcq_doctor.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.ucl_tcq_doctor.uclXPosition = 225
        Me.ucl_tcq_doctor.uclYPosition = 120
        '
        'lb_dept
        '
        Me.lb_dept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_dept.AutoSize = True
        Me.lb_dept.Location = New System.Drawing.Point(77, 67)
        Me.lb_dept.Name = "lb_dept"
        Me.lb_dept.Size = New System.Drawing.Size(40, 16)
        Me.lb_dept.TabIndex = 18
        Me.lb_dept.Text = "科別"
        '
        'ucl_txt_dept
        '
        Me.ucl_txt_dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_dept.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_dept.Location = New System.Drawing.Point(120, 61)
        Me.ucl_txt_dept.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_dept.MaxLength = 10
        Me.ucl_txt_dept.Name = "ucl_txt_dept"
        Me.ucl_txt_dept.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_dept.SelectionStart = 0
        Me.ucl_txt_dept.Size = New System.Drawing.Size(160, 27)
        Me.ucl_txt_dept.TabIndex = 19
        Me.ucl_txt_dept.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_dept.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_dept.uclDollarSign = False
        Me.ucl_txt_dept.uclDotCount = 0
        Me.ucl_txt_dept.uclIntCount = 2
        Me.ucl_txt_dept.uclMinus = False
        Me.ucl_txt_dept.uclReadOnly = False
        Me.ucl_txt_dept.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_clear.Location = New System.Drawing.Point(340, 61)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 27)
        Me.btn_clear.TabIndex = 14
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'PUBConsultDoctorUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 427)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBConsultDoctorUI"
        Me.TabText = "醫師查詢"
        Me.Text = "醫師查詢"
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.gb_corr_rule.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_corr_rule As System.Windows.Forms.GroupBox
    Friend WithEvents lb_rulebelong_item As System.Windows.Forms.Label
    Friend WithEvents lb_drname As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_drname As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents ucl_txt_employeecode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_employeecode As System.Windows.Forms.Label
    Friend WithEvents ucl_dgv_doctor As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents ucl_tcq_doctor As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lb_dept As System.Windows.Forms.Label
    Friend WithEvents ucl_txt_dept As Syscom.Client.UCL.UCLTextBoxUC
End Class
