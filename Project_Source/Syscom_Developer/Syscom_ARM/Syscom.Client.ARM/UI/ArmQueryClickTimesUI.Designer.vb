<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArmQueryClickTimesUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArmQueryClickTimesUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tcq_EmployeeCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_FunctionId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Excel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_ShowData, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(4, 128)
        Me.dgv_ShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(956, 501)
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 358.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tcq_EmployeeCode, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_StartDate, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_EndDate, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_FunctionId, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(958, 72)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "使用者"
        '
        'tcq_EmployeeCode
        '
        Me.tcq_EmployeeCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_EmployeeCode.doFlag = True
        Me.tcq_EmployeeCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_EmployeeCode.Location = New System.Drawing.Point(133, 5)
        Me.tcq_EmployeeCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_EmployeeCode.Name = "tcq_EmployeeCode"
        Me.tcq_EmployeeCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_EmployeeCode.TabIndex = 1
        Me.tcq_EmployeeCode.uclBaseDate = "2015/10/26"
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
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(373, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "統計範圍"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_StartDate.Location = New System.Drawing.Point(451, 4)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(117, 27)
        Me.dtp_StartDate.TabIndex = 3
        Me.dtp_StartDate.uclReadOnly = False
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDate.Location = New System.Drawing.Point(603, 4)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(117, 27)
        Me.dtp_EndDate.TabIndex = 4
        Me.dtp_EndDate.uclReadOnly = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(578, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "~"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "功能名稱"
        '
        'cbo_FunctionId
        '
        Me.cbo_FunctionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbo_FunctionId, 2)
        Me.cbo_FunctionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_FunctionId.DropDownWidth = 20
        Me.cbo_FunctionId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_FunctionId.Location = New System.Drawing.Point(133, 42)
        Me.cbo_FunctionId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_FunctionId.Name = "cbo_FunctionId"
        Me.cbo_FunctionId.SelectedIndex = -1
        Me.cbo_FunctionId.SelectedItem = Nothing
        Me.cbo_FunctionId.SelectedText = ""
        Me.cbo_FunctionId.SelectedValue = ""
        Me.cbo_FunctionId.SelectionStart = 0
        Me.cbo_FunctionId.Size = New System.Drawing.Size(312, 24)
        Me.cbo_FunctionId.TabIndex = 7
        Me.cbo_FunctionId.uclDisplayIndex = "0,1"
        Me.cbo_FunctionId.uclIsAutoClear = True
        Me.cbo_FunctionId.uclIsFirstItemEmpty = True
        Me.cbo_FunctionId.uclIsTextMode = False
        Me.cbo_FunctionId.uclShowMsg = False
        Me.cbo_FunctionId.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Excel)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 81)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(958, 40)
        Me.FlowLayoutPanel1.TabIndex = 1
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
        'btn_Excel
        '
        Me.btn_Excel.Location = New System.Drawing.Point(99, 3)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(90, 28)
        Me.btn_Excel.TabIndex = 1
        Me.btn_Excel.Text = "匯出 Excel"
        Me.btn_Excel.UseVisualStyleBackColor = True
        '
        'ArmQueryClickTimesUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "ArmQueryClickTimesUI"
        Me.TabText = "功能使用次數查詢"
        Me.Text = "功能使用次數查詢"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tcq_EmployeeCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_FunctionId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Excel As System.Windows.Forms.Button
End Class
