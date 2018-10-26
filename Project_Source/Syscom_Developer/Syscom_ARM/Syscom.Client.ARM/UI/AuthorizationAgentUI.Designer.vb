<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuthorizationAgentUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AuthorizationAgentUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tree_Review = New Syscom.Client.UCL.UCLTreeViewAdvUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tcq_AgentCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tcq_AgentCodeQuery = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_EffectDateQuery = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_EndDateQuery = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_RoleIdQuery = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_RoleGroup = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_ShowData, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tree_Review, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tcq_AgentCode, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EffectDate, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EndDate, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
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
        Me.dgv_ShowData.ColumnHeadersHeight = 4
        Me.dgv_ShowData.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv_ShowData, 6)
        Me.dgv_ShowData.CurrentCell = Nothing
        Me.dgv_ShowData.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ShowData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(267, 151)
        Me.dgv_ShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(720, 487)
        Me.dgv_ShowData.TabIndex = 13
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
        'tree_Review
        '
        Me.tree_Review.AutoScroll = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.tree_Review, 2)
        Me.tree_Review.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tree_Review.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tree_Review.IsShowGroupCheckBox = False
        Me.tree_Review.Location = New System.Drawing.Point(4, 151)
        Me.tree_Review.Margin = New System.Windows.Forms.Padding(4)
        Me.tree_Review.Name = "tree_Review"
        Me.tree_Review.SelectedItemsResult = Nothing
        Me.tree_Review.SelectedResult = Nothing
        Me.tree_Review.SelectedTempItemsResult = Nothing
        Me.tree_Review.Size = New System.Drawing.Size(255, 487)
        Me.tree_Review.TabIndex = 14
        Me.tree_Review.TreeViewName = ""
        Me.tree_Review.TreeViewSource = Nothing
        '
        'FlowLayoutPanel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 5)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Insert)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Exit)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 108)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(536, 36)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'btn_Insert
        '
        Me.btn_Insert.Location = New System.Drawing.Point(3, 3)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(90, 28)
        Me.btn_Insert.TabIndex = 8
        Me.btn_Insert.Text = "F12-新增"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(99, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_Delete.TabIndex = 10
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(195, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 11
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(291, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 12
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(387, 3)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(90, 28)
        Me.btn_Exit.TabIndex = 13
        Me.btn_Exit.Text = "ESC-退出"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(94, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "授權人"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "張大然"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "代理人"
        '
        'tcq_AgentCode
        '
        Me.tcq_AgentCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_AgentCode.doFlag = True
        Me.tcq_AgentCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_AgentCode.Location = New System.Drawing.Point(369, 74)
        Me.tcq_AgentCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_AgentCode.Name = "tcq_AgentCode"
        Me.tcq_AgentCode.Size = New System.Drawing.Size(150, 26)
        Me.tcq_AgentCode.TabIndex = 15
        Me.tcq_AgentCode.uclBaseDate = "2015/01/15"
        Me.tcq_AgentCode.uclCboWidth = 114
        Me.tcq_AgentCode.uclCodeName = ""
        Me.tcq_AgentCode.uclCodeValue1 = ""
        Me.tcq_AgentCode.uclCodeValue2 = ""
        Me.tcq_AgentCode.uclControlFlag = True
        Me.tcq_AgentCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_AgentCode.uclDisplayIndex = "0,1"
        Me.tcq_AgentCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_AgentCode.uclIsAutoAddZero = False
        Me.tcq_AgentCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_AgentCode.uclIsReturnDS = False
        Me.tcq_AgentCode.uclIsShowMsgBox = True
        Me.tcq_AgentCode.uclIsTextAutoClear = True
        Me.tcq_AgentCode.uclMsgValue = Nothing
        Me.tcq_AgentCode.uclPUBEmployeeProfessalKindId = "2"
        Me.tcq_AgentCode.uclQueryField = Nothing
        Me.tcq_AgentCode.uclQueryValue = Nothing
        Me.tcq_AgentCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_AgentCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUBEmployeeProfessalKindId
        Me.tcq_AgentCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.tcq_AgentCode.uclTotalWidth = 8
        Me.tcq_AgentCode.uclXPosition = 225
        Me.tcq_AgentCode.uclYPosition = 120
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(560, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "授權有效日期"
        '
        'dtp_EffectDate
        '
        Me.dtp_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EffectDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EffectDate.Location = New System.Drawing.Point(670, 74)
        Me.dtp_EffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EffectDate.Name = "dtp_EffectDate"
        Me.dtp_EffectDate.Size = New System.Drawing.Size(117, 27)
        Me.dtp_EffectDate.TabIndex = 5
        Me.dtp_EffectDate.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(795, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "~"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDate.Location = New System.Drawing.Point(815, 74)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(117, 27)
        Me.dtp_EndDate.TabIndex = 6
        Me.dtp_EndDate.uclReadOnly = False
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 8)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(985, 64)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查詢區"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tcq_AgentCodeQuery, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_EffectDateQuery, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_EndDateQuery, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_RoleIdQuery, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_RoleGroup, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(979, 38)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "代理人"
        '
        'tcq_AgentCodeQuery
        '
        Me.tcq_AgentCodeQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_AgentCodeQuery.doFlag = True
        Me.tcq_AgentCodeQuery.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_AgentCodeQuery.Location = New System.Drawing.Point(69, 6)
        Me.tcq_AgentCodeQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_AgentCodeQuery.Name = "tcq_AgentCodeQuery"
        Me.tcq_AgentCodeQuery.Size = New System.Drawing.Size(120, 26)
        Me.tcq_AgentCodeQuery.TabIndex = 1
        Me.tcq_AgentCodeQuery.uclBaseDate = "2015/01/15"
        Me.tcq_AgentCodeQuery.uclCboWidth = 84
        Me.tcq_AgentCodeQuery.uclCodeName = ""
        Me.tcq_AgentCodeQuery.uclCodeValue1 = ""
        Me.tcq_AgentCodeQuery.uclCodeValue2 = ""
        Me.tcq_AgentCodeQuery.uclControlFlag = True
        Me.tcq_AgentCodeQuery.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_AgentCodeQuery.uclDisplayIndex = "0,1"
        Me.tcq_AgentCodeQuery.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_AgentCodeQuery.uclIsAutoAddZero = False
        Me.tcq_AgentCodeQuery.uclIsCheckDoctorOnDuty = False
        Me.tcq_AgentCodeQuery.uclIsReturnDS = False
        Me.tcq_AgentCodeQuery.uclIsShowMsgBox = True
        Me.tcq_AgentCodeQuery.uclIsTextAutoClear = True
        Me.tcq_AgentCodeQuery.uclMsgValue = Nothing
        Me.tcq_AgentCodeQuery.uclPUBEmployeeProfessalKindId = "2"
        Me.tcq_AgentCodeQuery.uclQueryField = Nothing
        Me.tcq_AgentCodeQuery.uclQueryValue = Nothing
        Me.tcq_AgentCodeQuery.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_AgentCodeQuery.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUBEmployeeProfessalKindId
        Me.tcq_AgentCodeQuery.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.tcq_AgentCodeQuery.uclTotalWidth = 8
        Me.tcq_AgentCodeQuery.uclXPosition = 225
        Me.tcq_AgentCodeQuery.uclYPosition = 120
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(577, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "授權有效日期"
        '
        'dtp_EffectDateQuery
        '
        Me.dtp_EffectDateQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EffectDateQuery.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EffectDateQuery.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EffectDateQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EffectDateQuery.Location = New System.Drawing.Point(687, 5)
        Me.dtp_EffectDateQuery.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EffectDateQuery.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EffectDateQuery.Name = "dtp_EffectDateQuery"
        Me.dtp_EffectDateQuery.Size = New System.Drawing.Size(117, 27)
        Me.dtp_EffectDateQuery.TabIndex = 5
        Me.dtp_EffectDateQuery.uclReadOnly = False
        '
        'dtp_EndDateQuery
        '
        Me.dtp_EndDateQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDateQuery.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDateQuery.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDateQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDateQuery.Location = New System.Drawing.Point(832, 5)
        Me.dtp_EndDateQuery.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDateQuery.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDateQuery.Name = "dtp_EndDateQuery"
        Me.dtp_EndDateQuery.Size = New System.Drawing.Size(117, 27)
        Me.dtp_EndDateQuery.TabIndex = 6
        Me.dtp_EndDateQuery.uclReadOnly = False
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(811, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 16)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "~"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(209, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "角色"
        '
        'cbo_RoleIdQuery
        '
        Me.cbo_RoleIdQuery.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbo_RoleIdQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_RoleIdQuery.DropDownWidth = 20
        Me.cbo_RoleIdQuery.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RoleIdQuery.Location = New System.Drawing.Point(380, 7)
        Me.cbo_RoleIdQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RoleIdQuery.Name = "cbo_RoleIdQuery"
        Me.cbo_RoleIdQuery.SelectedIndex = -1
        Me.cbo_RoleIdQuery.SelectedItem = Nothing
        Me.cbo_RoleIdQuery.SelectedText = ""
        Me.cbo_RoleIdQuery.SelectedValue = ""
        Me.cbo_RoleIdQuery.SelectionStart = 0
        Me.cbo_RoleIdQuery.Size = New System.Drawing.Size(185, 24)
        Me.cbo_RoleIdQuery.TabIndex = 2
        Me.cbo_RoleIdQuery.uclDisplayIndex = "0,1"
        Me.cbo_RoleIdQuery.uclIsAutoClear = True
        Me.cbo_RoleIdQuery.uclIsFirstItemEmpty = True
        Me.cbo_RoleIdQuery.uclIsTextMode = False
        Me.cbo_RoleIdQuery.uclShowMsg = False
        Me.cbo_RoleIdQuery.uclValueIndex = "0"
        '
        'cbo_RoleGroup
        '
        Me.cbo_RoleGroup.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_RoleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_RoleGroup.DropDownWidth = 20
        Me.cbo_RoleGroup.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RoleGroup.Location = New System.Drawing.Point(252, 7)
        Me.cbo_RoleGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RoleGroup.Name = "cbo_RoleGroup"
        Me.cbo_RoleGroup.SelectedIndex = -1
        Me.cbo_RoleGroup.SelectedItem = Nothing
        Me.cbo_RoleGroup.SelectedText = ""
        Me.cbo_RoleGroup.SelectedValue = ""
        Me.cbo_RoleGroup.SelectionStart = 0
        Me.cbo_RoleGroup.Size = New System.Drawing.Size(125, 24)
        Me.cbo_RoleGroup.TabIndex = 8
        Me.cbo_RoleGroup.uclDisplayIndex = "0,1"
        Me.cbo_RoleGroup.uclIsAutoClear = True
        Me.cbo_RoleGroup.uclIsFirstItemEmpty = True
        Me.cbo_RoleGroup.uclIsTextMode = False
        Me.cbo_RoleGroup.uclShowMsg = False
        Me.cbo_RoleGroup.uclValueIndex = "0"
        '
        'AuthorizationAgentUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AuthorizationAgentUI"
        Me.TabText = "授權功能畫面"
        Me.Text = "授權功能畫面"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Insert As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents tree_Review As Syscom.Client.UCL.UCLTreeViewAdvUC
    Friend WithEvents tcq_AgentCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tcq_AgentCodeQuery As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents cbo_RoleIdQuery As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtp_EffectDateQuery As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_EndDateQuery As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
    Friend WithEvents cbo_RoleGroup As Syscom.Client.UCL.UCLComboBoxUC
End Class
