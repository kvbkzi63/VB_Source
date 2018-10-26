<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArmQueryInformationUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArmQueryInformationUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbo_Employee = New System.Windows.Forms.RadioButton()
        Me.rbo_Role = New System.Windows.Forms.RadioButton()
        Me.rbo_Function = New System.Windows.Forms.RadioButton()
        Me.cbo_RoleId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.tcq_EmployeeCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.cbo_FunctionId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_RoleGroup = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Excel = New System.Windows.Forms.Button()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_ShowData, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 477.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rbo_Employee, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbo_Role, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbo_Function, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_RoleId, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tcq_EmployeeCode, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_FunctionId, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_RoleGroup, 2, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(958, 96)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'rbo_Employee
        '
        Me.rbo_Employee.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbo_Employee.AutoSize = True
        Me.rbo_Employee.Location = New System.Drawing.Point(116, 6)
        Me.rbo_Employee.Name = "rbo_Employee"
        Me.rbo_Employee.Size = New System.Drawing.Size(58, 20)
        Me.rbo_Employee.TabIndex = 0
        Me.rbo_Employee.TabStop = True
        Me.rbo_Employee.Text = "人員"
        Me.rbo_Employee.UseVisualStyleBackColor = True
        '
        'rbo_Role
        '
        Me.rbo_Role.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbo_Role.AutoSize = True
        Me.rbo_Role.Location = New System.Drawing.Point(116, 38)
        Me.rbo_Role.Name = "rbo_Role"
        Me.rbo_Role.Size = New System.Drawing.Size(58, 20)
        Me.rbo_Role.TabIndex = 1
        Me.rbo_Role.TabStop = True
        Me.rbo_Role.Text = "角色"
        Me.rbo_Role.UseVisualStyleBackColor = True
        '
        'rbo_Function
        '
        Me.rbo_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbo_Function.AutoSize = True
        Me.rbo_Function.Location = New System.Drawing.Point(116, 70)
        Me.rbo_Function.Name = "rbo_Function"
        Me.rbo_Function.Size = New System.Drawing.Size(58, 20)
        Me.rbo_Function.TabIndex = 2
        Me.rbo_Function.TabStop = True
        Me.rbo_Function.Text = "功能"
        Me.rbo_Function.UseVisualStyleBackColor = True
        '
        'cbo_RoleId
        '
        Me.cbo_RoleId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_RoleId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_RoleId.DropDownWidth = 20
        Me.cbo_RoleId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RoleId.Location = New System.Drawing.Point(331, 36)
        Me.cbo_RoleId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RoleId.Name = "cbo_RoleId"
        Me.cbo_RoleId.SelectedIndex = -1
        Me.cbo_RoleId.SelectedItem = Nothing
        Me.cbo_RoleId.SelectedText = ""
        Me.cbo_RoleId.SelectedValue = ""
        Me.cbo_RoleId.SelectionStart = 0
        Me.cbo_RoleId.Size = New System.Drawing.Size(338, 24)
        Me.cbo_RoleId.TabIndex = 6
        Me.cbo_RoleId.uclDisplayIndex = "0,1"
        Me.cbo_RoleId.uclIsAutoClear = True
        Me.cbo_RoleId.uclIsFirstItemEmpty = True
        Me.cbo_RoleId.uclIsTextMode = False
        Me.cbo_RoleId.uclShowMsg = False
        Me.cbo_RoleId.uclValueIndex = "0"
        '
        'tcq_EmployeeCode
        '
        Me.tcq_EmployeeCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.tcq_EmployeeCode, 2)
        Me.tcq_EmployeeCode.doFlag = True
        Me.tcq_EmployeeCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_EmployeeCode.Location = New System.Drawing.Point(193, 3)
        Me.tcq_EmployeeCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_EmployeeCode.Name = "tcq_EmployeeCode"
        Me.tcq_EmployeeCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_EmployeeCode.TabIndex = 3
        Me.tcq_EmployeeCode.uclBaseDate = "2015/01/15"
        Me.tcq_EmployeeCode.uclCboWidth = 126
        Me.tcq_EmployeeCode.uclCodeName = ""
        Me.tcq_EmployeeCode.uclCodeName1 = ""
        Me.tcq_EmployeeCode.uclCodeName2 = ""
        Me.tcq_EmployeeCode.uclCodeValue = ""
        Me.tcq_EmployeeCode.uclCodeValue1 = ""
        Me.tcq_EmployeeCode.uclCodeValue2 = ""
        Me.tcq_EmployeeCode.uclControlFlag = True
        Me.tcq_EmployeeCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_EmployeeCode.uclDisplayIndex = "0,1"
        Me.tcq_EmployeeCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_EmployeeCode.uclIsAutoAddZero = False
        Me.tcq_EmployeeCode.uclIsBtnVisible = True
        Me.tcq_EmployeeCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_EmployeeCode.uclIsEnglishDept = False
        Me.tcq_EmployeeCode.uclIsReturnDS = False
        Me.tcq_EmployeeCode.uclIsShowMsgBox = True
        Me.tcq_EmployeeCode.uclIsTextAutoClear = True
        Me.tcq_EmployeeCode.uclLabel = ""
        Me.tcq_EmployeeCode.uclMsgValue = Nothing
        Me.tcq_EmployeeCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_EmployeeCode.uclQueryField = Nothing
        Me.tcq_EmployeeCode.uclQueryValue = Nothing
        Me.tcq_EmployeeCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_EmployeeCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_EmployeeCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.tcq_EmployeeCode.uclTotalWidth = 8
        Me.tcq_EmployeeCode.uclXPosition = 225
        Me.tcq_EmployeeCode.uclYPosition = 120
        '
        'cbo_FunctionId
        '
        Me.cbo_FunctionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbo_FunctionId, 2)
        Me.cbo_FunctionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_FunctionId.DropDownWidth = 20
        Me.cbo_FunctionId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_FunctionId.Location = New System.Drawing.Point(193, 68)
        Me.cbo_FunctionId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_FunctionId.Name = "cbo_FunctionId"
        Me.cbo_FunctionId.SelectedIndex = -1
        Me.cbo_FunctionId.SelectedItem = Nothing
        Me.cbo_FunctionId.SelectedText = ""
        Me.cbo_FunctionId.SelectedValue = ""
        Me.cbo_FunctionId.SelectionStart = 0
        Me.cbo_FunctionId.Size = New System.Drawing.Size(476, 24)
        Me.cbo_FunctionId.TabIndex = 7
        Me.cbo_FunctionId.uclDisplayIndex = "0,1"
        Me.cbo_FunctionId.uclIsAutoClear = True
        Me.cbo_FunctionId.uclIsFirstItemEmpty = True
        Me.cbo_FunctionId.uclIsTextMode = False
        Me.cbo_FunctionId.uclShowMsg = False
        Me.cbo_FunctionId.uclValueIndex = "0"
        '
        'cbo_RoleGroup
        '
        Me.cbo_RoleGroup.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_RoleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_RoleGroup.DropDownWidth = 20
        Me.cbo_RoleGroup.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RoleGroup.Location = New System.Drawing.Point(193, 36)
        Me.cbo_RoleGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RoleGroup.Name = "cbo_RoleGroup"
        Me.cbo_RoleGroup.SelectedIndex = -1
        Me.cbo_RoleGroup.SelectedItem = Nothing
        Me.cbo_RoleGroup.SelectedText = ""
        Me.cbo_RoleGroup.SelectedValue = ""
        Me.cbo_RoleGroup.SelectionStart = 0
        Me.cbo_RoleGroup.Size = New System.Drawing.Size(138, 24)
        Me.cbo_RoleGroup.TabIndex = 8
        Me.cbo_RoleGroup.uclDisplayIndex = "0,1"
        Me.cbo_RoleGroup.uclIsAutoClear = True
        Me.cbo_RoleGroup.uclIsFirstItemEmpty = True
        Me.cbo_RoleGroup.uclIsTextMode = False
        Me.cbo_RoleGroup.uclShowMsg = False
        Me.cbo_RoleGroup.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Excel)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 105)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(958, 38)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(3, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 0
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(99, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 1
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Excel
        '
        Me.btn_Excel.Location = New System.Drawing.Point(195, 3)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(90, 28)
        Me.btn_Excel.TabIndex = 2
        Me.btn_Excel.Text = "匯出Excel"
        Me.btn_Excel.UseVisualStyleBackColor = True
        '
        'dgv_ShowData
        '
        Me.dgv_ShowData.AllowUserToAddRows = False
        Me.dgv_ShowData.AllowUserToOrderColumns = False
        Me.dgv_ShowData.AllowUserToResizeColumns = True
        Me.dgv_ShowData.AllowUserToResizeRows = False
        Me.dgv_ShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
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
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(6, 151)
        Me.dgv_ShowData.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(952, 436)
        Me.dgv_ShowData.TabIndex = 0
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
        Me.dgv_ShowData.uclIsDoOrderCheck = True
        Me.dgv_ShowData.uclIsSortable = False
        Me.dgv_ShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowData.uclNonVisibleColIndex = ""
        Me.dgv_ShowData.uclReadOnly = False
        Me.dgv_ShowData.uclShowCellBorder = False
        Me.dgv_ShowData.uclSortColIndex = ""
        Me.dgv_ShowData.uclTreeMode = False
        Me.dgv_ShowData.uclVisibleColIndex = ""
        '
        'ArmQueryInformationUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "ArmQueryInformationUI"
        Me.TabText = "多面向查詢畫面"
        Me.Text = "多面向查詢畫面"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbo_Employee As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_Role As System.Windows.Forms.RadioButton
    Friend WithEvents rbo_Function As System.Windows.Forms.RadioButton
    Friend WithEvents tcq_EmployeeCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cbo_RoleId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_FunctionId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_RoleGroup As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Excel As System.Windows.Forms.Button
End Class
