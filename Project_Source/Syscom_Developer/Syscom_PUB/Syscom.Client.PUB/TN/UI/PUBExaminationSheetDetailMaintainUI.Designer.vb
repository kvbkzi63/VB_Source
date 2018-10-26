<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBExaminationSheetDetailMaintainUI
    Inherits Syscom.Client.UCL.BaseFormUI
    'Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBExaminationSheetDetailMaintainUI))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FlowLayoutPanelButton = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.dgv_OrderList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_DeleteOrder = New System.Windows.Forms.Button()
        Me.Btn_UpdateSheetDetail = New System.Windows.Forms.Button()
        Me.tb_Gridsort = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanelLeftBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_SheetIndication = New System.Windows.Forms.Button()
        Me.chk_PrintSheetIndication = New System.Windows.Forms.CheckBox()
        Me.txt_SheetLimitCnt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_SheetNameList = New System.Windows.Forms.Label()
        Me.cbo_SheetList = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.btn_OrderCheck = New System.Windows.Forms.TabPage()
        Me.gbx_SpecimenAndReceptacle = New System.Windows.Forms.GroupBox()
        Me.dgv_SpecimenVessel = New System.Windows.Forms.DataGridView()
        Me.ColumnSpecimenId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColumnVesselId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColumnAsAddToSpecimen = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColumnControlValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTimeControlId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColumnIsDefault = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColumnIsDefaultVessel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gbx_NoteForOrdering = New System.Windows.Forms.GroupBox()
        Me.txt_NoteForOrdering = New System.Windows.Forms.TextBox()
        Me.gbx_NoteForPrinting = New System.Windows.Forms.GroupBox()
        Me.txt_NoteForPrinting = New System.Windows.Forms.TextBox()
        Me.chk_NoteForPrinting = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_OrderIndication = New System.Windows.Forms.Button()
        Me.chk_PrintOrderIndication = New System.Windows.Forms.CheckBox()
        Me.Chk_IsScheduled = New System.Windows.Forms.CheckBox()
        Me.Chk_IsSeeReport = New System.Windows.Forms.CheckBox()
        Me.Chk_IsLimitHealth = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_StartDate = New System.Windows.Forms.Label()
        Me.lbl_EndDate = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.TabSetting = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.gbx_SeperateSheet = New System.Windows.Forms.GroupBox()
        Me.dgv_SeparateOrder = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_AddToSeparateOrder = New System.Windows.Forms.Button()
        Me.btn_RemoveFromSeparateOrder = New System.Windows.Forms.Button()
        Me.chk_AloneOrderFlag = New System.Windows.Forms.CheckBox()
        Me.gbx_ExclusiveOrder = New System.Windows.Forms.GroupBox()
        Me.dgv_ExclusiveOrder = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_AddToExclusiveOrder = New System.Windows.Forms.Button()
        Me.btn_RemoveFromExclusiveOrder = New System.Windows.Forms.Button()
        Me.gbx_SelectoryOrderList = New System.Windows.Forms.GroupBox()
        Me.dgv_SelectoryOrderList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TabDuplidatedOrder = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_DuplicatedOrder = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_AddToDuplicatedOrder = New System.Windows.Forms.Button()
        Me.btn_RemoveFromDuplicatedOrder = New System.Windows.Forms.Button()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_SexLimit = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_DeptLimit = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tcq_DoctLimit = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txt_DoctLimit = New System.Windows.Forms.TextBox()
        Me.txt_DeptLimit = New System.Windows.Forms.TextBox()
        Me.btn_DeptLimitClear = New System.Windows.Forms.Button()
        Me.btn_DoctLimit = New System.Windows.Forms.Button()
        Me.btn_DoctLimitClear = New System.Windows.Forms.Button()
        Me.cbo_DeptLimit = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_PhoneNumber = New System.Windows.Forms.TextBox()
        Me.gbx_Selectgory2 = New System.Windows.Forms.GroupBox()
        Me.dgv_SelectoryOrderList2 = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_OrderCode = New System.Windows.Forms.Label()
        Me.txt_ORderCode = New System.Windows.Forms.TextBox()
        Me.lbl_OrderName = New System.Windows.Forms.Label()
        Me.txt_OrderEnName = New System.Windows.Forms.TextBox()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanelButton.SuspendLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanelLeftBottom.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.btn_OrderCheck.SuspendLayout()
        Me.gbx_SpecimenAndReceptacle.SuspendLayout()
        CType(Me.dgv_SpecimenVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbx_NoteForOrdering.SuspendLayout()
        Me.gbx_NoteForPrinting.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabSetting.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.gbx_SeperateSheet.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.gbx_ExclusiveOrder.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.gbx_SelectoryOrderList.SuspendLayout()
        Me.TabDuplidatedOrder.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.gbx_Selectgory2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanelButton
        '
        Me.FlowLayoutPanelButton.Controls.Add(Me.btn_Confirm)
        Me.FlowLayoutPanelButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanelButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanelButton.Location = New System.Drawing.Point(0, 538)
        Me.FlowLayoutPanelButton.Name = "FlowLayoutPanelButton"
        Me.FlowLayoutPanelButton.Size = New System.Drawing.Size(1186, 35)
        Me.FlowLayoutPanelButton.TabIndex = 0
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(1093, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_Confirm.TabIndex = 99
        Me.btn_Confirm.Text = "F12-確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.dgv_OrderList)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelLeftBottom)
        Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.TabControlMain)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1186, 538)
        Me.SplitContainerMain.SplitterDistance = 385
        Me.SplitContainerMain.TabIndex = 1
        '
        'dgv_OrderList
        '
        Me.dgv_OrderList.AllowUserToAddRows = False
        Me.dgv_OrderList.AllowUserToOrderColumns = False
        Me.dgv_OrderList.AllowUserToResizeColumns = True
        Me.dgv_OrderList.AllowUserToResizeRows = False
        Me.dgv_OrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_OrderList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_OrderList.ColumnHeadersHeight = 4
        Me.dgv_OrderList.ColumnHeadersVisible = True
        Me.dgv_OrderList.CurrentCell = Nothing
        Me.dgv_OrderList.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_OrderList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_OrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_OrderList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_OrderList.Location = New System.Drawing.Point(0, 35)
        Me.dgv_OrderList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_OrderList.MultiSelect = True
        Me.dgv_OrderList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_OrderList.Name = "dgv_OrderList"
        Me.dgv_OrderList.RowHeadersWidth = 41
        Me.dgv_OrderList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_OrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_OrderList.Size = New System.Drawing.Size(385, 398)
        Me.dgv_OrderList.TabIndex = 3
        Me.dgv_OrderList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_OrderList.uclBatchColIndex = ""
        Me.dgv_OrderList.uclClickToCheck = False
        Me.dgv_OrderList.uclColumnAlignment = ""
        Me.dgv_OrderList.uclColumnCheckBox = True
        Me.dgv_OrderList.uclColumnControlType = ""
        Me.dgv_OrderList.uclColumnWidth = ""
        Me.dgv_OrderList.uclDoCellEnter = True
        Me.dgv_OrderList.uclHasNewRow = False
        Me.dgv_OrderList.uclHeaderText = ""
        Me.dgv_OrderList.uclIsAlternatingRowsColors = True
        Me.dgv_OrderList.uclIsComboBoxGridQuery = True
        Me.dgv_OrderList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_OrderList.uclIsDoOrderCheck = True
        Me.dgv_OrderList.uclIsSortable = False
        Me.dgv_OrderList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_OrderList.uclNonVisibleColIndex = ""
        Me.dgv_OrderList.uclReadOnly = False
        Me.dgv_OrderList.uclShowCellBorder = False
        Me.dgv_OrderList.uclSortColIndex = ""
        Me.dgv_OrderList.uclTreeMode = False
        Me.dgv_OrderList.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_DeleteOrder)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn_UpdateSheetDetail)
        Me.FlowLayoutPanel2.Controls.Add(Me.tb_Gridsort)
        Me.FlowLayoutPanel2.Controls.Add(Me.CheckBox1)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 433)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(385, 35)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'btn_DeleteOrder
        '
        Me.btn_DeleteOrder.Location = New System.Drawing.Point(242, 3)
        Me.btn_DeleteOrder.Name = "btn_DeleteOrder"
        Me.btn_DeleteOrder.Size = New System.Drawing.Size(140, 28)
        Me.btn_DeleteOrder.TabIndex = 0
        Me.btn_DeleteOrder.Text = "移除表單醫令"
        Me.btn_DeleteOrder.UseVisualStyleBackColor = True
        '
        'Btn_UpdateSheetDetail
        '
        Me.Btn_UpdateSheetDetail.Location = New System.Drawing.Point(96, 3)
        Me.Btn_UpdateSheetDetail.Name = "Btn_UpdateSheetDetail"
        Me.Btn_UpdateSheetDetail.Size = New System.Drawing.Size(140, 28)
        Me.Btn_UpdateSheetDetail.TabIndex = 1
        Me.Btn_UpdateSheetDetail.Text = "修改醫令明細"
        Me.Btn_UpdateSheetDetail.UseVisualStyleBackColor = True
        '
        'tb_Gridsort
        '
        Me.tb_Gridsort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tb_Gridsort.Location = New System.Drawing.Point(53, 3)
        Me.tb_Gridsort.Name = "tb_Gridsort"
        Me.tb_Gridsort.ReadOnly = True
        Me.tb_Gridsort.Size = New System.Drawing.Size(37, 27)
        Me.tb_Gridsort.TabIndex = 6
        Me.tb_Gridsort.TabStop = False
        Me.tb_Gridsort.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(259, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(123, 20)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "列印於申請單"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox1.Location = New System.Drawing.Point(153, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 27)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        '
        'TableLayoutPanelLeftBottom
        '
        Me.TableLayoutPanelLeftBottom.ColumnCount = 3
        Me.TableLayoutPanelLeftBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelLeftBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelLeftBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelLeftBottom.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanelLeftBottom.Controls.Add(Me.btn_SheetIndication, 0, 0)
        Me.TableLayoutPanelLeftBottom.Controls.Add(Me.chk_PrintSheetIndication, 1, 0)
        Me.TableLayoutPanelLeftBottom.Controls.Add(Me.txt_SheetLimitCnt, 1, 1)
        Me.TableLayoutPanelLeftBottom.Controls.Add(Me.Label2, 2, 1)
        Me.TableLayoutPanelLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanelLeftBottom.Location = New System.Drawing.Point(0, 468)
        Me.TableLayoutPanelLeftBottom.Name = "TableLayoutPanelLeftBottom"
        Me.TableLayoutPanelLeftBottom.RowCount = 2
        Me.TableLayoutPanelLeftBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelLeftBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelLeftBottom.Size = New System.Drawing.Size(385, 70)
        Me.TableLayoutPanelLeftBottom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "申請單醫令限制"
        Me.Label1.Visible = False
        '
        'btn_SheetIndication
        '
        Me.btn_SheetIndication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_SheetIndication.Location = New System.Drawing.Point(3, 3)
        Me.btn_SheetIndication.Name = "btn_SheetIndication"
        Me.btn_SheetIndication.Size = New System.Drawing.Size(120, 28)
        Me.btn_SheetIndication.TabIndex = 2
        Me.btn_SheetIndication.Text = "表單Indication"
        Me.btn_SheetIndication.UseVisualStyleBackColor = True
        Me.btn_SheetIndication.Visible = False
        '
        'chk_PrintSheetIndication
        '
        Me.chk_PrintSheetIndication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_PrintSheetIndication.AutoSize = True
        Me.TableLayoutPanelLeftBottom.SetColumnSpan(Me.chk_PrintSheetIndication, 2)
        Me.chk_PrintSheetIndication.Location = New System.Drawing.Point(129, 7)
        Me.chk_PrintSheetIndication.Name = "chk_PrintSheetIndication"
        Me.chk_PrintSheetIndication.Size = New System.Drawing.Size(123, 20)
        Me.chk_PrintSheetIndication.TabIndex = 3
        Me.chk_PrintSheetIndication.Text = "列印於申請單"
        Me.chk_PrintSheetIndication.UseVisualStyleBackColor = True
        Me.chk_PrintSheetIndication.Visible = False
        '
        'txt_SheetLimitCnt
        '
        Me.txt_SheetLimitCnt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SheetLimitCnt.Location = New System.Drawing.Point(129, 39)
        Me.txt_SheetLimitCnt.Name = "txt_SheetLimitCnt"
        Me.txt_SheetLimitCnt.Size = New System.Drawing.Size(50, 27)
        Me.txt_SheetLimitCnt.TabIndex = 4
        Me.txt_SheetLimitCnt.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "筆"
        Me.Label2.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_SheetNameList, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_SheetList, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(385, 35)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbl_SheetNameList
        '
        Me.lbl_SheetNameList.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SheetNameList.AutoSize = True
        Me.lbl_SheetNameList.Location = New System.Drawing.Point(3, 9)
        Me.lbl_SheetNameList.Name = "lbl_SheetNameList"
        Me.lbl_SheetNameList.Size = New System.Drawing.Size(40, 16)
        Me.lbl_SheetNameList.TabIndex = 0
        Me.lbl_SheetNameList.Text = "表單"
        '
        'cbo_SheetList
        '
        Me.cbo_SheetList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SheetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SheetList.DropDownWidth = 20
        Me.cbo_SheetList.DroppedDown = False
        Me.cbo_SheetList.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SheetList.Location = New System.Drawing.Point(50, 5)
        Me.cbo_SheetList.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_SheetList.Name = "cbo_SheetList"
        Me.cbo_SheetList.SelectedIndex = -1
        Me.cbo_SheetList.SelectedItem = Nothing
        Me.cbo_SheetList.SelectedText = ""
        Me.cbo_SheetList.SelectedValue = ""
        Me.cbo_SheetList.SelectionStart = 0
        Me.cbo_SheetList.Size = New System.Drawing.Size(200, 24)
        Me.cbo_SheetList.TabIndex = 0
        Me.cbo_SheetList.uclDisplayIndex = "0,1"
        Me.cbo_SheetList.uclIsAutoClear = True
        Me.cbo_SheetList.uclIsFirstItemEmpty = True
        Me.cbo_SheetList.uclIsTextMode = False
        Me.cbo_SheetList.uclShowMsg = False
        Me.cbo_SheetList.uclValueIndex = "0"
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.btn_OrderCheck)
        Me.TabControlMain.Controls.Add(Me.TabSetting)
        Me.TabControlMain.Controls.Add(Me.TabDuplidatedOrder)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(0, 35)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(797, 503)
        Me.TabControlMain.TabIndex = 5
        '
        'btn_OrderCheck
        '
        Me.btn_OrderCheck.Controls.Add(Me.gbx_SpecimenAndReceptacle)
        Me.btn_OrderCheck.Controls.Add(Me.gbx_NoteForOrdering)
        Me.btn_OrderCheck.Controls.Add(Me.gbx_NoteForPrinting)
        Me.btn_OrderCheck.Controls.Add(Me.FlowLayoutPanel1)
        Me.btn_OrderCheck.Controls.Add(Me.TableLayoutPanel3)
        Me.btn_OrderCheck.Location = New System.Drawing.Point(4, 26)
        Me.btn_OrderCheck.Name = "btn_OrderCheck"
        Me.btn_OrderCheck.Padding = New System.Windows.Forms.Padding(3)
        Me.btn_OrderCheck.Size = New System.Drawing.Size(789, 473)
        Me.btn_OrderCheck.TabIndex = 0
        Me.btn_OrderCheck.Text = "基本資料"
        Me.btn_OrderCheck.UseVisualStyleBackColor = True
        '
        'gbx_SpecimenAndReceptacle
        '
        Me.gbx_SpecimenAndReceptacle.Controls.Add(Me.dgv_SpecimenVessel)
        Me.gbx_SpecimenAndReceptacle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_SpecimenAndReceptacle.Location = New System.Drawing.Point(3, 73)
        Me.gbx_SpecimenAndReceptacle.Name = "gbx_SpecimenAndReceptacle"
        Me.gbx_SpecimenAndReceptacle.Size = New System.Drawing.Size(783, 177)
        Me.gbx_SpecimenAndReceptacle.TabIndex = 3
        Me.gbx_SpecimenAndReceptacle.TabStop = False
        Me.gbx_SpecimenAndReceptacle.Text = "檢體 / 容器"
        '
        'dgv_SpecimenVessel
        '
        Me.dgv_SpecimenVessel.AllowUserToOrderColumns = True
        Me.dgv_SpecimenVessel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SpecimenVessel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnSpecimenId, Me.ColumnVesselId, Me.ColumnAsAddToSpecimen, Me.ColumnControlValue, Me.ColumnTimeControlId, Me.ColumnIsDefault, Me.ColumnIsDefaultVessel})
        Me.dgv_SpecimenVessel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SpecimenVessel.Location = New System.Drawing.Point(3, 23)
        Me.dgv_SpecimenVessel.Name = "dgv_SpecimenVessel"
        Me.dgv_SpecimenVessel.RowHeadersWidth = 30
        Me.dgv_SpecimenVessel.RowTemplate.Height = 24
        Me.dgv_SpecimenVessel.Size = New System.Drawing.Size(777, 151)
        Me.dgv_SpecimenVessel.TabIndex = 11
        '
        'ColumnSpecimenId
        '
        Me.ColumnSpecimenId.DataPropertyName = "Specimen_Id"
        Me.ColumnSpecimenId.HeaderText = "檢體"
        Me.ColumnSpecimenId.MinimumWidth = 100
        Me.ColumnSpecimenId.Name = "ColumnSpecimenId"
        Me.ColumnSpecimenId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnSpecimenId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnSpecimenId.Width = 120
        '
        'ColumnVesselId
        '
        Me.ColumnVesselId.DataPropertyName = "Vessel_Id"
        Me.ColumnVesselId.HeaderText = "容器"
        Me.ColumnVesselId.MinimumWidth = 100
        Me.ColumnVesselId.Name = "ColumnVesselId"
        Me.ColumnVesselId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnVesselId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnVesselId.Width = 120
        '
        'ColumnAsAddToSpecimen
        '
        Me.ColumnAsAddToSpecimen.DataPropertyName = "As_AddTo_Specimen"
        Me.ColumnAsAddToSpecimen.FalseValue = "N"
        Me.ColumnAsAddToSpecimen.HeaderText = "同檢體加作"
        Me.ColumnAsAddToSpecimen.MinimumWidth = 35
        Me.ColumnAsAddToSpecimen.Name = "ColumnAsAddToSpecimen"
        Me.ColumnAsAddToSpecimen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnAsAddToSpecimen.TrueValue = "Y"
        Me.ColumnAsAddToSpecimen.Visible = False
        Me.ColumnAsAddToSpecimen.Width = 75
        '
        'ColumnControlValue
        '
        Me.ColumnControlValue.DataPropertyName = "Control_Value"
        Me.ColumnControlValue.HeaderText = "時間範圍"
        Me.ColumnControlValue.MinimumWidth = 50
        Me.ColumnControlValue.Name = "ColumnControlValue"
        Me.ColumnControlValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnControlValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColumnControlValue.Width = 55
        '
        'ColumnTimeControlId
        '
        Me.ColumnTimeControlId.DataPropertyName = "Time_Control_Id"
        Me.ColumnTimeControlId.HeaderText = "時間單位"
        Me.ColumnTimeControlId.MinimumWidth = 80
        Me.ColumnTimeControlId.Name = "ColumnTimeControlId"
        Me.ColumnTimeControlId.Width = 120
        '
        'ColumnIsDefault
        '
        Me.ColumnIsDefault.DataPropertyName = "Is_Default"
        Me.ColumnIsDefault.FalseValue = "N"
        Me.ColumnIsDefault.HeaderText = "預設檢體"
        Me.ColumnIsDefault.IndeterminateValue = "N"
        Me.ColumnIsDefault.MinimumWidth = 60
        Me.ColumnIsDefault.Name = "ColumnIsDefault"
        Me.ColumnIsDefault.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnIsDefault.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnIsDefault.TrueValue = "Y"
        Me.ColumnIsDefault.Width = 70
        '
        'ColumnIsDefaultVessel
        '
        Me.ColumnIsDefaultVessel.DataPropertyName = "Is_Default_Vessel"
        Me.ColumnIsDefaultVessel.FalseValue = "N"
        Me.ColumnIsDefaultVessel.HeaderText = "預設容器"
        Me.ColumnIsDefaultVessel.IndeterminateValue = "N"
        Me.ColumnIsDefaultVessel.MinimumWidth = 35
        Me.ColumnIsDefaultVessel.Name = "ColumnIsDefaultVessel"
        Me.ColumnIsDefaultVessel.TrueValue = "Y"
        Me.ColumnIsDefaultVessel.Width = 60
        '
        'gbx_NoteForOrdering
        '
        Me.gbx_NoteForOrdering.Controls.Add(Me.txt_NoteForOrdering)
        Me.gbx_NoteForOrdering.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbx_NoteForOrdering.Location = New System.Drawing.Point(3, 250)
        Me.gbx_NoteForOrdering.Name = "gbx_NoteForOrdering"
        Me.gbx_NoteForOrdering.Size = New System.Drawing.Size(783, 110)
        Me.gbx_NoteForOrdering.TabIndex = 4
        Me.gbx_NoteForOrdering.TabStop = False
        Me.gbx_NoteForOrdering.Text = "開立醫令的注意事項"
        '
        'txt_NoteForOrdering
        '
        Me.txt_NoteForOrdering.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_NoteForOrdering.Location = New System.Drawing.Point(3, 23)
        Me.txt_NoteForOrdering.Multiline = True
        Me.txt_NoteForOrdering.Name = "txt_NoteForOrdering"
        Me.txt_NoteForOrdering.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_NoteForOrdering.Size = New System.Drawing.Size(777, 84)
        Me.txt_NoteForOrdering.TabIndex = 0
        Me.txt_NoteForOrdering.WordWrap = False
        '
        'gbx_NoteForPrinting
        '
        Me.gbx_NoteForPrinting.Controls.Add(Me.txt_NoteForPrinting)
        Me.gbx_NoteForPrinting.Controls.Add(Me.chk_NoteForPrinting)
        Me.gbx_NoteForPrinting.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbx_NoteForPrinting.Location = New System.Drawing.Point(3, 360)
        Me.gbx_NoteForPrinting.Name = "gbx_NoteForPrinting"
        Me.gbx_NoteForPrinting.Size = New System.Drawing.Size(783, 110)
        Me.gbx_NoteForPrinting.TabIndex = 2
        Me.gbx_NoteForPrinting.TabStop = False
        '
        'txt_NoteForPrinting
        '
        Me.txt_NoteForPrinting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_NoteForPrinting.Location = New System.Drawing.Point(3, 23)
        Me.txt_NoteForPrinting.Multiline = True
        Me.txt_NoteForPrinting.Name = "txt_NoteForPrinting"
        Me.txt_NoteForPrinting.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_NoteForPrinting.Size = New System.Drawing.Size(777, 84)
        Me.txt_NoteForPrinting.TabIndex = 13
        Me.txt_NoteForPrinting.WordWrap = False
        '
        'chk_NoteForPrinting
        '
        Me.chk_NoteForPrinting.AutoSize = True
        Me.chk_NoteForPrinting.Location = New System.Drawing.Point(6, 0)
        Me.chk_NoteForPrinting.Name = "chk_NoteForPrinting"
        Me.chk_NoteForPrinting.Size = New System.Drawing.Size(219, 20)
        Me.chk_NoteForPrinting.TabIndex = 12
        Me.chk_NoteForPrinting.Text = "申請單列印醫令的注意事項"
        Me.chk_NoteForPrinting.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_OrderIndication)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_PrintOrderIndication)
        Me.FlowLayoutPanel1.Controls.Add(Me.Chk_IsScheduled)
        Me.FlowLayoutPanel1.Controls.Add(Me.Chk_IsSeeReport)
        Me.FlowLayoutPanel1.Controls.Add(Me.Chk_IsLimitHealth)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 38)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(783, 35)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 28)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "醫令檢核"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'btn_OrderIndication
        '
        Me.btn_OrderIndication.Location = New System.Drawing.Point(99, 3)
        Me.btn_OrderIndication.Name = "btn_OrderIndication"
        Me.btn_OrderIndication.Size = New System.Drawing.Size(120, 28)
        Me.btn_OrderIndication.TabIndex = 9
        Me.btn_OrderIndication.Text = "醫令 Indication"
        Me.btn_OrderIndication.UseVisualStyleBackColor = True
        Me.btn_OrderIndication.Visible = False
        '
        'chk_PrintOrderIndication
        '
        Me.chk_PrintOrderIndication.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_PrintOrderIndication.AutoSize = True
        Me.chk_PrintOrderIndication.Location = New System.Drawing.Point(225, 7)
        Me.chk_PrintOrderIndication.Name = "chk_PrintOrderIndication"
        Me.chk_PrintOrderIndication.Size = New System.Drawing.Size(190, 20)
        Me.chk_PrintOrderIndication.TabIndex = 10
        Me.chk_PrintOrderIndication.Text = "列印 Indication於申請單"
        Me.chk_PrintOrderIndication.UseVisualStyleBackColor = True
        Me.chk_PrintOrderIndication.Visible = False
        '
        'Chk_IsScheduled
        '
        Me.Chk_IsScheduled.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Chk_IsScheduled.AutoSize = True
        Me.Chk_IsScheduled.Location = New System.Drawing.Point(421, 7)
        Me.Chk_IsScheduled.Name = "Chk_IsScheduled"
        Me.Chk_IsScheduled.Size = New System.Drawing.Size(107, 20)
        Me.Chk_IsScheduled.TabIndex = 11
        Me.Chk_IsScheduled.Text = "可排程註記"
        Me.Chk_IsScheduled.UseVisualStyleBackColor = True
        Me.Chk_IsScheduled.Visible = False
        '
        'Chk_IsSeeReport
        '
        Me.Chk_IsSeeReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Chk_IsSeeReport.AutoSize = True
        Me.Chk_IsSeeReport.Location = New System.Drawing.Point(534, 7)
        Me.Chk_IsSeeReport.Name = "Chk_IsSeeReport"
        Me.Chk_IsSeeReport.Size = New System.Drawing.Size(107, 20)
        Me.Chk_IsSeeReport.TabIndex = 11
        Me.Chk_IsSeeReport.Text = "立即看報告"
        Me.Chk_IsSeeReport.UseVisualStyleBackColor = True
        '
        'Chk_IsLimitHealth
        '
        Me.Chk_IsLimitHealth.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Chk_IsLimitHealth.AutoSize = True
        Me.Chk_IsLimitHealth.Location = New System.Drawing.Point(647, 7)
        Me.Chk_IsLimitHealth.Name = "Chk_IsLimitHealth"
        Me.Chk_IsLimitHealth.Size = New System.Drawing.Size(91, 20)
        Me.Chk_IsLimitHealth.TabIndex = 12
        Me.Chk_IsLimitHealth.Text = "限健檢用"
        Me.Chk_IsLimitHealth.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.lbl_StartDate, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lbl_EndDate, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtp_StartDate, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtp_EndDate, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(783, 35)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lbl_StartDate
        '
        Me.lbl_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartDate.AutoSize = True
        Me.lbl_StartDate.Location = New System.Drawing.Point(3, 9)
        Me.lbl_StartDate.Name = "lbl_StartDate"
        Me.lbl_StartDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartDate.TabIndex = 0
        Me.lbl_StartDate.Text = "啟用日期"
        Me.lbl_StartDate.Visible = False
        '
        'lbl_EndDate
        '
        Me.lbl_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndDate.AutoSize = True
        Me.lbl_EndDate.Location = New System.Drawing.Point(197, 9)
        Me.lbl_EndDate.Name = "lbl_EndDate"
        Me.lbl_EndDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndDate.TabIndex = 0
        Me.lbl_EndDate.Text = "停用日期"
        Me.lbl_EndDate.Visible = False
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(81, 3)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(110, 27)
        Me.dtp_StartDate.TabIndex = 6
        Me.dtp_StartDate.uclReadOnly = False
        Me.dtp_StartDate.Visible = False
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(275, 3)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(110, 27)
        Me.dtp_EndDate.TabIndex = 7
        Me.dtp_EndDate.uclReadOnly = False
        Me.dtp_EndDate.Visible = False
        '
        'TabSetting
        '
        Me.TabSetting.Controls.Add(Me.TableLayoutPanel4)
        Me.TabSetting.Controls.Add(Me.gbx_SelectoryOrderList)
        Me.TabSetting.Location = New System.Drawing.Point(4, 26)
        Me.TabSetting.Name = "TabSetting"
        Me.TabSetting.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSetting.Size = New System.Drawing.Size(789, 473)
        Me.TabSetting.TabIndex = 1
        Me.TabSetting.Text = "開單拆單設定"
        Me.TabSetting.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.gbx_SeperateSheet, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.gbx_ExclusiveOrder, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(293, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(493, 467)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'gbx_SeperateSheet
        '
        Me.gbx_SeperateSheet.Controls.Add(Me.dgv_SeparateOrder)
        Me.gbx_SeperateSheet.Controls.Add(Me.TableLayoutPanel7)
        Me.gbx_SeperateSheet.Controls.Add(Me.chk_AloneOrderFlag)
        Me.gbx_SeperateSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_SeperateSheet.Location = New System.Drawing.Point(3, 3)
        Me.gbx_SeperateSheet.Name = "gbx_SeperateSheet"
        Me.gbx_SeperateSheet.Size = New System.Drawing.Size(487, 227)
        Me.gbx_SeperateSheet.TabIndex = 0
        Me.gbx_SeperateSheet.TabStop = False
        Me.gbx_SeperateSheet.Text = "拆單群組設定"
        '
        'dgv_SeparateOrder
        '
        Me.dgv_SeparateOrder.AllowUserToAddRows = False
        Me.dgv_SeparateOrder.AllowUserToOrderColumns = False
        Me.dgv_SeparateOrder.AllowUserToResizeColumns = True
        Me.dgv_SeparateOrder.AllowUserToResizeRows = False
        Me.dgv_SeparateOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_SeparateOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SeparateOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_SeparateOrder.ColumnHeadersHeight = 4
        Me.dgv_SeparateOrder.ColumnHeadersVisible = True
        Me.dgv_SeparateOrder.CurrentCell = Nothing
        Me.dgv_SeparateOrder.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SeparateOrder.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_SeparateOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SeparateOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SeparateOrder.Location = New System.Drawing.Point(59, 23)
        Me.dgv_SeparateOrder.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_SeparateOrder.MultiSelect = True
        Me.dgv_SeparateOrder.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SeparateOrder.Name = "dgv_SeparateOrder"
        Me.dgv_SeparateOrder.RowHeadersWidth = 41
        Me.dgv_SeparateOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SeparateOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SeparateOrder.Size = New System.Drawing.Size(425, 201)
        Me.dgv_SeparateOrder.TabIndex = 2
        Me.dgv_SeparateOrder.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SeparateOrder.uclBatchColIndex = ""
        Me.dgv_SeparateOrder.uclClickToCheck = False
        Me.dgv_SeparateOrder.uclColumnAlignment = ""
        Me.dgv_SeparateOrder.uclColumnCheckBox = True
        Me.dgv_SeparateOrder.uclColumnControlType = ""
        Me.dgv_SeparateOrder.uclColumnWidth = ""
        Me.dgv_SeparateOrder.uclDoCellEnter = True
        Me.dgv_SeparateOrder.uclHasNewRow = False
        Me.dgv_SeparateOrder.uclHeaderText = ""
        Me.dgv_SeparateOrder.uclIsAlternatingRowsColors = True
        Me.dgv_SeparateOrder.uclIsComboBoxGridQuery = True
        Me.dgv_SeparateOrder.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SeparateOrder.uclIsDoOrderCheck = True
        Me.dgv_SeparateOrder.uclIsSortable = False
        Me.dgv_SeparateOrder.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SeparateOrder.uclNonVisibleColIndex = ""
        Me.dgv_SeparateOrder.uclReadOnly = False
        Me.dgv_SeparateOrder.uclShowCellBorder = False
        Me.dgv_SeparateOrder.uclSortColIndex = ""
        Me.dgv_SeparateOrder.uclTreeMode = False
        Me.dgv_SeparateOrder.uclVisibleColIndex = ""
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.AutoSize = True
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btn_AddToSeparateOrder, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btn_RemoveFromSeparateOrder, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(56, 201)
        Me.TableLayoutPanel7.TabIndex = 3
        '
        'btn_AddToSeparateOrder
        '
        Me.btn_AddToSeparateOrder.Location = New System.Drawing.Point(3, 3)
        Me.btn_AddToSeparateOrder.Name = "btn_AddToSeparateOrder"
        Me.btn_AddToSeparateOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_AddToSeparateOrder.TabIndex = 0
        Me.btn_AddToSeparateOrder.Text = "＞"
        Me.btn_AddToSeparateOrder.UseVisualStyleBackColor = True
        '
        'btn_RemoveFromSeparateOrder
        '
        Me.btn_RemoveFromSeparateOrder.Location = New System.Drawing.Point(3, 39)
        Me.btn_RemoveFromSeparateOrder.Name = "btn_RemoveFromSeparateOrder"
        Me.btn_RemoveFromSeparateOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_RemoveFromSeparateOrder.TabIndex = 0
        Me.btn_RemoveFromSeparateOrder.Text = "＜"
        Me.btn_RemoveFromSeparateOrder.UseVisualStyleBackColor = True
        '
        'chk_AloneOrderFlag
        '
        Me.chk_AloneOrderFlag.AutoSize = True
        Me.chk_AloneOrderFlag.Location = New System.Drawing.Point(124, 0)
        Me.chk_AloneOrderFlag.Name = "chk_AloneOrderFlag"
        Me.chk_AloneOrderFlag.Size = New System.Drawing.Size(123, 20)
        Me.chk_AloneOrderFlag.TabIndex = 0
        Me.chk_AloneOrderFlag.Text = "單獨拆單註記"
        Me.chk_AloneOrderFlag.UseVisualStyleBackColor = True
        '
        'gbx_ExclusiveOrder
        '
        Me.gbx_ExclusiveOrder.Controls.Add(Me.dgv_ExclusiveOrder)
        Me.gbx_ExclusiveOrder.Controls.Add(Me.TableLayoutPanel8)
        Me.gbx_ExclusiveOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_ExclusiveOrder.Location = New System.Drawing.Point(3, 236)
        Me.gbx_ExclusiveOrder.Name = "gbx_ExclusiveOrder"
        Me.gbx_ExclusiveOrder.Size = New System.Drawing.Size(487, 228)
        Me.gbx_ExclusiveOrder.TabIndex = 0
        Me.gbx_ExclusiveOrder.TabStop = False
        Me.gbx_ExclusiveOrder.Text = "互斥拆單醫令設定"
        '
        'dgv_ExclusiveOrder
        '
        Me.dgv_ExclusiveOrder.AllowUserToAddRows = False
        Me.dgv_ExclusiveOrder.AllowUserToOrderColumns = False
        Me.dgv_ExclusiveOrder.AllowUserToResizeColumns = True
        Me.dgv_ExclusiveOrder.AllowUserToResizeRows = False
        Me.dgv_ExclusiveOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_ExclusiveOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ExclusiveOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_ExclusiveOrder.ColumnHeadersHeight = 4
        Me.dgv_ExclusiveOrder.ColumnHeadersVisible = True
        Me.dgv_ExclusiveOrder.CurrentCell = Nothing
        Me.dgv_ExclusiveOrder.DataSource = Nothing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ExclusiveOrder.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_ExclusiveOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ExclusiveOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ExclusiveOrder.Location = New System.Drawing.Point(59, 23)
        Me.dgv_ExclusiveOrder.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.dgv_ExclusiveOrder.MultiSelect = True
        Me.dgv_ExclusiveOrder.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ExclusiveOrder.Name = "dgv_ExclusiveOrder"
        Me.dgv_ExclusiveOrder.RowHeadersWidth = 41
        Me.dgv_ExclusiveOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ExclusiveOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ExclusiveOrder.Size = New System.Drawing.Size(425, 202)
        Me.dgv_ExclusiveOrder.TabIndex = 2
        Me.dgv_ExclusiveOrder.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_ExclusiveOrder.uclBatchColIndex = ""
        Me.dgv_ExclusiveOrder.uclClickToCheck = False
        Me.dgv_ExclusiveOrder.uclColumnAlignment = ""
        Me.dgv_ExclusiveOrder.uclColumnCheckBox = True
        Me.dgv_ExclusiveOrder.uclColumnControlType = ""
        Me.dgv_ExclusiveOrder.uclColumnWidth = ""
        Me.dgv_ExclusiveOrder.uclDoCellEnter = True
        Me.dgv_ExclusiveOrder.uclHasNewRow = False
        Me.dgv_ExclusiveOrder.uclHeaderText = ""
        Me.dgv_ExclusiveOrder.uclIsAlternatingRowsColors = True
        Me.dgv_ExclusiveOrder.uclIsComboBoxGridQuery = True
        Me.dgv_ExclusiveOrder.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ExclusiveOrder.uclIsDoOrderCheck = True
        Me.dgv_ExclusiveOrder.uclIsSortable = False
        Me.dgv_ExclusiveOrder.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ExclusiveOrder.uclNonVisibleColIndex = ""
        Me.dgv_ExclusiveOrder.uclReadOnly = False
        Me.dgv_ExclusiveOrder.uclShowCellBorder = False
        Me.dgv_ExclusiveOrder.uclSortColIndex = ""
        Me.dgv_ExclusiveOrder.uclTreeMode = False
        Me.dgv_ExclusiveOrder.uclVisibleColIndex = ""
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.AutoSize = True
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.btn_AddToExclusiveOrder, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.btn_RemoveFromExclusiveOrder, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(56, 202)
        Me.TableLayoutPanel8.TabIndex = 3
        '
        'btn_AddToExclusiveOrder
        '
        Me.btn_AddToExclusiveOrder.Location = New System.Drawing.Point(3, 3)
        Me.btn_AddToExclusiveOrder.Name = "btn_AddToExclusiveOrder"
        Me.btn_AddToExclusiveOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_AddToExclusiveOrder.TabIndex = 0
        Me.btn_AddToExclusiveOrder.Text = "＞"
        Me.btn_AddToExclusiveOrder.UseVisualStyleBackColor = True
        '
        'btn_RemoveFromExclusiveOrder
        '
        Me.btn_RemoveFromExclusiveOrder.Location = New System.Drawing.Point(3, 39)
        Me.btn_RemoveFromExclusiveOrder.Name = "btn_RemoveFromExclusiveOrder"
        Me.btn_RemoveFromExclusiveOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_RemoveFromExclusiveOrder.TabIndex = 0
        Me.btn_RemoveFromExclusiveOrder.Text = "＜"
        Me.btn_RemoveFromExclusiveOrder.UseVisualStyleBackColor = True
        '
        'gbx_SelectoryOrderList
        '
        Me.gbx_SelectoryOrderList.Controls.Add(Me.dgv_SelectoryOrderList)
        Me.gbx_SelectoryOrderList.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbx_SelectoryOrderList.Location = New System.Drawing.Point(3, 3)
        Me.gbx_SelectoryOrderList.Name = "gbx_SelectoryOrderList"
        Me.gbx_SelectoryOrderList.Size = New System.Drawing.Size(290, 467)
        Me.gbx_SelectoryOrderList.TabIndex = 0
        Me.gbx_SelectoryOrderList.TabStop = False
        Me.gbx_SelectoryOrderList.Text = "可選擇醫令"
        '
        'dgv_SelectoryOrderList
        '
        Me.dgv_SelectoryOrderList.AllowUserToAddRows = False
        Me.dgv_SelectoryOrderList.AllowUserToOrderColumns = False
        Me.dgv_SelectoryOrderList.AllowUserToResizeColumns = True
        Me.dgv_SelectoryOrderList.AllowUserToResizeRows = False
        Me.dgv_SelectoryOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_SelectoryOrderList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SelectoryOrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_SelectoryOrderList.ColumnHeadersHeight = 4
        Me.dgv_SelectoryOrderList.ColumnHeadersVisible = True
        Me.dgv_SelectoryOrderList.CurrentCell = Nothing
        Me.dgv_SelectoryOrderList.DataSource = Nothing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SelectoryOrderList.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_SelectoryOrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SelectoryOrderList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SelectoryOrderList.Location = New System.Drawing.Point(3, 23)
        Me.dgv_SelectoryOrderList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_SelectoryOrderList.MultiSelect = True
        Me.dgv_SelectoryOrderList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SelectoryOrderList.Name = "dgv_SelectoryOrderList"
        Me.dgv_SelectoryOrderList.RowHeadersWidth = 41
        Me.dgv_SelectoryOrderList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SelectoryOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SelectoryOrderList.Size = New System.Drawing.Size(284, 441)
        Me.dgv_SelectoryOrderList.TabIndex = 14
        Me.dgv_SelectoryOrderList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SelectoryOrderList.uclBatchColIndex = ""
        Me.dgv_SelectoryOrderList.uclClickToCheck = False
        Me.dgv_SelectoryOrderList.uclColumnAlignment = ""
        Me.dgv_SelectoryOrderList.uclColumnCheckBox = True
        Me.dgv_SelectoryOrderList.uclColumnControlType = ""
        Me.dgv_SelectoryOrderList.uclColumnWidth = ""
        Me.dgv_SelectoryOrderList.uclDoCellEnter = True
        Me.dgv_SelectoryOrderList.uclHasNewRow = False
        Me.dgv_SelectoryOrderList.uclHeaderText = ""
        Me.dgv_SelectoryOrderList.uclIsAlternatingRowsColors = True
        Me.dgv_SelectoryOrderList.uclIsComboBoxGridQuery = True
        Me.dgv_SelectoryOrderList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SelectoryOrderList.uclIsDoOrderCheck = True
        Me.dgv_SelectoryOrderList.uclIsSortable = False
        Me.dgv_SelectoryOrderList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SelectoryOrderList.uclNonVisibleColIndex = ""
        Me.dgv_SelectoryOrderList.uclReadOnly = False
        Me.dgv_SelectoryOrderList.uclShowCellBorder = False
        Me.dgv_SelectoryOrderList.uclSortColIndex = ""
        Me.dgv_SelectoryOrderList.uclTreeMode = False
        Me.dgv_SelectoryOrderList.uclVisibleColIndex = ""
        '
        'TabDuplidatedOrder
        '
        Me.TabDuplidatedOrder.Controls.Add(Me.GroupBox1)
        Me.TabDuplidatedOrder.Controls.Add(Me.TableLayoutPanel6)
        Me.TabDuplidatedOrder.Controls.Add(Me.gbx_Selectgory2)
        Me.TabDuplidatedOrder.Location = New System.Drawing.Point(4, 26)
        Me.TabDuplidatedOrder.Name = "TabDuplidatedOrder"
        Me.TabDuplidatedOrder.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDuplidatedOrder.Size = New System.Drawing.Size(789, 473)
        Me.TabDuplidatedOrder.TabIndex = 2
        Me.TabDuplidatedOrder.Text = "重覆醫令設定"
        Me.TabDuplidatedOrder.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_DuplicatedOrder)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel9)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(293, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 274)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "重覆醫令設定"
        '
        'dgv_DuplicatedOrder
        '
        Me.dgv_DuplicatedOrder.AllowUserToAddRows = False
        Me.dgv_DuplicatedOrder.AllowUserToOrderColumns = False
        Me.dgv_DuplicatedOrder.AllowUserToResizeColumns = True
        Me.dgv_DuplicatedOrder.AllowUserToResizeRows = False
        Me.dgv_DuplicatedOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_DuplicatedOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_DuplicatedOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_DuplicatedOrder.ColumnHeadersHeight = 4
        Me.dgv_DuplicatedOrder.ColumnHeadersVisible = True
        Me.dgv_DuplicatedOrder.CurrentCell = Nothing
        Me.dgv_DuplicatedOrder.DataSource = Nothing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_DuplicatedOrder.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_DuplicatedOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_DuplicatedOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_DuplicatedOrder.Location = New System.Drawing.Point(59, 23)
        Me.dgv_DuplicatedOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_DuplicatedOrder.MultiSelect = True
        Me.dgv_DuplicatedOrder.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_DuplicatedOrder.Name = "dgv_DuplicatedOrder"
        Me.dgv_DuplicatedOrder.RowHeadersWidth = 41
        Me.dgv_DuplicatedOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_DuplicatedOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DuplicatedOrder.Size = New System.Drawing.Size(431, 248)
        Me.dgv_DuplicatedOrder.TabIndex = 17
        Me.dgv_DuplicatedOrder.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_DuplicatedOrder.uclBatchColIndex = ""
        Me.dgv_DuplicatedOrder.uclClickToCheck = False
        Me.dgv_DuplicatedOrder.uclColumnAlignment = ""
        Me.dgv_DuplicatedOrder.uclColumnCheckBox = True
        Me.dgv_DuplicatedOrder.uclColumnControlType = ""
        Me.dgv_DuplicatedOrder.uclColumnWidth = ""
        Me.dgv_DuplicatedOrder.uclDoCellEnter = True
        Me.dgv_DuplicatedOrder.uclHasNewRow = False
        Me.dgv_DuplicatedOrder.uclHeaderText = ""
        Me.dgv_DuplicatedOrder.uclIsAlternatingRowsColors = True
        Me.dgv_DuplicatedOrder.uclIsComboBoxGridQuery = True
        Me.dgv_DuplicatedOrder.uclIsComboxClickTriggerDropDown = False
        Me.dgv_DuplicatedOrder.uclIsDoOrderCheck = True
        Me.dgv_DuplicatedOrder.uclIsSortable = False
        Me.dgv_DuplicatedOrder.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_DuplicatedOrder.uclNonVisibleColIndex = ""
        Me.dgv_DuplicatedOrder.uclReadOnly = False
        Me.dgv_DuplicatedOrder.uclShowCellBorder = False
        Me.dgv_DuplicatedOrder.uclSortColIndex = ""
        Me.dgv_DuplicatedOrder.uclTreeMode = False
        Me.dgv_DuplicatedOrder.uclVisibleColIndex = ""
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.AutoSize = True
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.btn_AddToDuplicatedOrder, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btn_RemoveFromDuplicatedOrder, 0, 1)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 2
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(56, 248)
        Me.TableLayoutPanel9.TabIndex = 3
        '
        'btn_AddToDuplicatedOrder
        '
        Me.btn_AddToDuplicatedOrder.Location = New System.Drawing.Point(3, 3)
        Me.btn_AddToDuplicatedOrder.Name = "btn_AddToDuplicatedOrder"
        Me.btn_AddToDuplicatedOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_AddToDuplicatedOrder.TabIndex = 15
        Me.btn_AddToDuplicatedOrder.Text = "＞"
        Me.btn_AddToDuplicatedOrder.UseVisualStyleBackColor = True
        '
        'btn_RemoveFromDuplicatedOrder
        '
        Me.btn_RemoveFromDuplicatedOrder.Location = New System.Drawing.Point(3, 39)
        Me.btn_RemoveFromDuplicatedOrder.Name = "btn_RemoveFromDuplicatedOrder"
        Me.btn_RemoveFromDuplicatedOrder.Size = New System.Drawing.Size(50, 30)
        Me.btn_RemoveFromDuplicatedOrder.TabIndex = 16
        Me.btn_RemoveFromDuplicatedOrder.Text = "＜"
        Me.btn_RemoveFromDuplicatedOrder.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Txt_PhoneNumber, 1, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(293, 277)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(493, 193)
        Me.TableLayoutPanel6.TabIndex = 30
        Me.TableLayoutPanel6.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.TableLayoutPanel6.SetRowSpan(Me.GroupBox2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(229, 187)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "其他限制"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cbo_SexLimit, 1, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.btn_DeptLimit, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.tcq_DoctLimit, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txt_DoctLimit, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txt_DeptLimit, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.btn_DeptLimitClear, 2, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.btn_DoctLimit, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btn_DoctLimitClear, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.cbo_DeptLimit, 1, 2)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(7, 21)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 5
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(206, 155)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "醫師"
        '
        'cbo_SexLimit
        '
        Me.cbo_SexLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SexLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SexLimit.DropDownWidth = 20
        Me.cbo_SexLimit.DroppedDown = False
        Me.cbo_SexLimit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SexLimit.Location = New System.Drawing.Point(52, 128)
        Me.cbo_SexLimit.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_SexLimit.Name = "cbo_SexLimit"
        Me.cbo_SexLimit.SelectedIndex = -1
        Me.cbo_SexLimit.SelectedItem = Nothing
        Me.cbo_SexLimit.SelectedText = ""
        Me.cbo_SexLimit.SelectedValue = ""
        Me.cbo_SexLimit.SelectionStart = 0
        Me.cbo_SexLimit.Size = New System.Drawing.Size(115, 23)
        Me.cbo_SexLimit.TabIndex = 26
        Me.cbo_SexLimit.uclDisplayIndex = "0,1"
        Me.cbo_SexLimit.uclIsAutoClear = True
        Me.cbo_SexLimit.uclIsFirstItemEmpty = True
        Me.cbo_SexLimit.uclIsTextMode = False
        Me.cbo_SexLimit.uclShowMsg = False
        Me.cbo_SexLimit.uclValueIndex = "0"
        '
        'btn_DeptLimit
        '
        Me.btn_DeptLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_DeptLimit.Location = New System.Drawing.Point(174, 65)
        Me.btn_DeptLimit.Name = "btn_DeptLimit"
        Me.btn_DeptLimit.Size = New System.Drawing.Size(28, 25)
        Me.btn_DeptLimit.TabIndex = 23
        Me.btn_DeptLimit.Text = "↓"
        Me.btn_DeptLimit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "科別"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "性別"
        '
        'tcq_DoctLimit
        '
        Me.tcq_DoctLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_DoctLimit.doFlag = True
        Me.tcq_DoctLimit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_DoctLimit.Location = New System.Drawing.Point(48, 2)
        Me.tcq_DoctLimit.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_DoctLimit.Name = "tcq_DoctLimit"
        Me.tcq_DoctLimit.Size = New System.Drawing.Size(119, 26)
        Me.tcq_DoctLimit.TabIndex = 18
        Me.tcq_DoctLimit.uclBaseDate = "2016/02/23"
        Me.tcq_DoctLimit.uclCboWidth = 82
        Me.tcq_DoctLimit.uclCodeName = ""
        Me.tcq_DoctLimit.uclCodeName1 = ""
        Me.tcq_DoctLimit.uclCodeName2 = ""
        Me.tcq_DoctLimit.uclCodeValue = ""
        Me.tcq_DoctLimit.uclCodeValue1 = ""
        Me.tcq_DoctLimit.uclCodeValue2 = ""
        Me.tcq_DoctLimit.uclControlFlag = True
        Me.tcq_DoctLimit.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_DoctLimit.uclDisplayIndex = "0,1"
        Me.tcq_DoctLimit.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_DoctLimit.uclIsAutoAddZero = False
        Me.tcq_DoctLimit.uclIsBtnVisible = True
        Me.tcq_DoctLimit.uclIsCheckDoctorOnDuty = False
        Me.tcq_DoctLimit.uclIsCheckTime = True
        Me.tcq_DoctLimit.uclIsEnglishDept = False
        Me.tcq_DoctLimit.uclIsReturnDS = False
        Me.tcq_DoctLimit.uclIsShowMsgBox = True
        Me.tcq_DoctLimit.uclIsTextAutoClear = True
        Me.tcq_DoctLimit.uclLabel = ""
        Me.tcq_DoctLimit.uclMsgValue = Nothing
        Me.tcq_DoctLimit.uclNoDataOpenWindow = False
        Me.tcq_DoctLimit.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_DoctLimit.uclQueryField = Nothing
        Me.tcq_DoctLimit.uclQueryValue = Nothing
        Me.tcq_DoctLimit.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_DoctLimit.uclRegionKind = ""
        Me.tcq_DoctLimit.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.tcq_DoctLimit.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Name
        Me.tcq_DoctLimit.uclTotalWidth = 8
        Me.tcq_DoctLimit.uclXPosition = 225
        Me.tcq_DoctLimit.uclYPosition = 120
        '
        'txt_DoctLimit
        '
        Me.txt_DoctLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DoctLimit.BackColor = System.Drawing.SystemColors.Window
        Me.txt_DoctLimit.Location = New System.Drawing.Point(51, 34)
        Me.txt_DoctLimit.Name = "txt_DoctLimit"
        Me.txt_DoctLimit.ReadOnly = True
        Me.txt_DoctLimit.Size = New System.Drawing.Size(116, 27)
        Me.txt_DoctLimit.TabIndex = 20
        Me.txt_DoctLimit.TabStop = False
        '
        'txt_DeptLimit
        '
        Me.txt_DeptLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DeptLimit.BackColor = System.Drawing.SystemColors.Window
        Me.txt_DeptLimit.Location = New System.Drawing.Point(51, 96)
        Me.txt_DeptLimit.Name = "txt_DeptLimit"
        Me.txt_DeptLimit.ReadOnly = True
        Me.txt_DeptLimit.Size = New System.Drawing.Size(116, 27)
        Me.txt_DeptLimit.TabIndex = 24
        Me.txt_DeptLimit.TabStop = False
        '
        'btn_DeptLimitClear
        '
        Me.btn_DeptLimitClear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_DeptLimitClear.Location = New System.Drawing.Point(174, 96)
        Me.btn_DeptLimitClear.Name = "btn_DeptLimitClear"
        Me.btn_DeptLimitClear.Size = New System.Drawing.Size(28, 25)
        Me.btn_DeptLimitClear.TabIndex = 25
        Me.btn_DeptLimitClear.Text = "清除"
        Me.btn_DeptLimitClear.UseVisualStyleBackColor = True
        '
        'btn_DoctLimit
        '
        Me.btn_DoctLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_DoctLimit.Location = New System.Drawing.Point(174, 3)
        Me.btn_DoctLimit.Name = "btn_DoctLimit"
        Me.btn_DoctLimit.Size = New System.Drawing.Size(28, 25)
        Me.btn_DoctLimit.TabIndex = 19
        Me.btn_DoctLimit.Text = "↓"
        Me.btn_DoctLimit.UseVisualStyleBackColor = True
        '
        'btn_DoctLimitClear
        '
        Me.btn_DoctLimitClear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_DoctLimitClear.Location = New System.Drawing.Point(174, 34)
        Me.btn_DoctLimitClear.Name = "btn_DoctLimitClear"
        Me.btn_DoctLimitClear.Size = New System.Drawing.Size(28, 25)
        Me.btn_DoctLimitClear.TabIndex = 21
        Me.btn_DoctLimitClear.Text = "清除"
        Me.btn_DoctLimitClear.UseVisualStyleBackColor = True
        '
        'cbo_DeptLimit
        '
        Me.cbo_DeptLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_DeptLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_DeptLimit.DropDownWidth = 20
        Me.cbo_DeptLimit.DroppedDown = False
        Me.cbo_DeptLimit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_DeptLimit.Location = New System.Drawing.Point(52, 66)
        Me.cbo_DeptLimit.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_DeptLimit.Name = "cbo_DeptLimit"
        Me.cbo_DeptLimit.SelectedIndex = -1
        Me.cbo_DeptLimit.SelectedItem = Nothing
        Me.cbo_DeptLimit.SelectedText = ""
        Me.cbo_DeptLimit.SelectedValue = ""
        Me.cbo_DeptLimit.SelectionStart = 0
        Me.cbo_DeptLimit.Size = New System.Drawing.Size(115, 23)
        Me.cbo_DeptLimit.TabIndex = 22
        Me.cbo_DeptLimit.uclDisplayIndex = "0,1"
        Me.cbo_DeptLimit.uclIsAutoClear = True
        Me.cbo_DeptLimit.uclIsFirstItemEmpty = True
        Me.cbo_DeptLimit.uclIsTextMode = False
        Me.cbo_DeptLimit.uclShowMsg = False
        Me.cbo_DeptLimit.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(238, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "聯絡電話"
        '
        'Txt_PhoneNumber
        '
        Me.Txt_PhoneNumber.Enabled = False
        Me.Txt_PhoneNumber.Location = New System.Drawing.Point(238, 38)
        Me.Txt_PhoneNumber.Name = "Txt_PhoneNumber"
        Me.Txt_PhoneNumber.Size = New System.Drawing.Size(94, 27)
        Me.Txt_PhoneNumber.TabIndex = 28
        '
        'gbx_Selectgory2
        '
        Me.gbx_Selectgory2.Controls.Add(Me.dgv_SelectoryOrderList2)
        Me.gbx_Selectgory2.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbx_Selectgory2.Location = New System.Drawing.Point(3, 3)
        Me.gbx_Selectgory2.Name = "gbx_Selectgory2"
        Me.gbx_Selectgory2.Size = New System.Drawing.Size(290, 467)
        Me.gbx_Selectgory2.TabIndex = 1
        Me.gbx_Selectgory2.TabStop = False
        Me.gbx_Selectgory2.Text = "可選擇醫令"
        '
        'dgv_SelectoryOrderList2
        '
        Me.dgv_SelectoryOrderList2.AllowUserToAddRows = False
        Me.dgv_SelectoryOrderList2.AllowUserToOrderColumns = False
        Me.dgv_SelectoryOrderList2.AllowUserToResizeColumns = True
        Me.dgv_SelectoryOrderList2.AllowUserToResizeRows = False
        Me.dgv_SelectoryOrderList2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_SelectoryOrderList2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SelectoryOrderList2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgv_SelectoryOrderList2.ColumnHeadersHeight = 4
        Me.dgv_SelectoryOrderList2.ColumnHeadersVisible = True
        Me.dgv_SelectoryOrderList2.CurrentCell = Nothing
        Me.dgv_SelectoryOrderList2.DataSource = Nothing
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SelectoryOrderList2.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgv_SelectoryOrderList2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SelectoryOrderList2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_SelectoryOrderList2.Location = New System.Drawing.Point(3, 23)
        Me.dgv_SelectoryOrderList2.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_SelectoryOrderList2.MultiSelect = True
        Me.dgv_SelectoryOrderList2.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_SelectoryOrderList2.Name = "dgv_SelectoryOrderList2"
        Me.dgv_SelectoryOrderList2.RowHeadersWidth = 41
        Me.dgv_SelectoryOrderList2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_SelectoryOrderList2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SelectoryOrderList2.Size = New System.Drawing.Size(284, 441)
        Me.dgv_SelectoryOrderList2.TabIndex = 14
        Me.dgv_SelectoryOrderList2.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_SelectoryOrderList2.uclBatchColIndex = ""
        Me.dgv_SelectoryOrderList2.uclClickToCheck = False
        Me.dgv_SelectoryOrderList2.uclColumnAlignment = ""
        Me.dgv_SelectoryOrderList2.uclColumnCheckBox = True
        Me.dgv_SelectoryOrderList2.uclColumnControlType = ""
        Me.dgv_SelectoryOrderList2.uclColumnWidth = ""
        Me.dgv_SelectoryOrderList2.uclDoCellEnter = True
        Me.dgv_SelectoryOrderList2.uclHasNewRow = False
        Me.dgv_SelectoryOrderList2.uclHeaderText = ""
        Me.dgv_SelectoryOrderList2.uclIsAlternatingRowsColors = True
        Me.dgv_SelectoryOrderList2.uclIsComboBoxGridQuery = True
        Me.dgv_SelectoryOrderList2.uclIsComboxClickTriggerDropDown = False
        Me.dgv_SelectoryOrderList2.uclIsDoOrderCheck = True
        Me.dgv_SelectoryOrderList2.uclIsSortable = False
        Me.dgv_SelectoryOrderList2.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_SelectoryOrderList2.uclNonVisibleColIndex = ""
        Me.dgv_SelectoryOrderList2.uclReadOnly = False
        Me.dgv_SelectoryOrderList2.uclShowCellBorder = False
        Me.dgv_SelectoryOrderList2.uclSortColIndex = ""
        Me.dgv_SelectoryOrderList2.uclTreeMode = False
        Me.dgv_SelectoryOrderList2.uclVisibleColIndex = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_OrderCode, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_ORderCode, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_OrderName, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_OrderEnName, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(797, 35)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lbl_OrderCode
        '
        Me.lbl_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_OrderCode.AutoSize = True
        Me.lbl_OrderCode.Location = New System.Drawing.Point(3, 9)
        Me.lbl_OrderCode.Name = "lbl_OrderCode"
        Me.lbl_OrderCode.Size = New System.Drawing.Size(72, 16)
        Me.lbl_OrderCode.TabIndex = 0
        Me.lbl_OrderCode.Text = "醫令代碼"
        '
        'txt_ORderCode
        '
        Me.txt_ORderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ORderCode.Location = New System.Drawing.Point(81, 4)
        Me.txt_ORderCode.Name = "txt_ORderCode"
        Me.txt_ORderCode.ReadOnly = True
        Me.txt_ORderCode.Size = New System.Drawing.Size(100, 27)
        Me.txt_ORderCode.TabIndex = 4
        Me.txt_ORderCode.TabStop = False
        '
        'lbl_OrderName
        '
        Me.lbl_OrderName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_OrderName.AutoSize = True
        Me.lbl_OrderName.Location = New System.Drawing.Point(187, 9)
        Me.lbl_OrderName.Name = "lbl_OrderName"
        Me.lbl_OrderName.Size = New System.Drawing.Size(72, 16)
        Me.lbl_OrderName.TabIndex = 0
        Me.lbl_OrderName.Text = "醫令名稱"
        '
        'txt_OrderEnName
        '
        Me.txt_OrderEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderEnName.Location = New System.Drawing.Point(265, 4)
        Me.txt_OrderEnName.Name = "txt_OrderEnName"
        Me.txt_OrderEnName.ReadOnly = True
        Me.txt_OrderEnName.Size = New System.Drawing.Size(200, 27)
        Me.txt_OrderEnName.TabIndex = 4
        Me.txt_OrderEnName.TabStop = False
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "Time_Control_Id"
        Me.DataGridViewComboBoxColumn1.HeaderText = "時間"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 80
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 160
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "Vessel_Id"
        Me.DataGridViewComboBoxColumn2.HeaderText = "容器"
        Me.DataGridViewComboBoxColumn2.MinimumWidth = 100
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.Width = 120
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "As_AddTo_Specimen"
        Me.DataGridViewCheckBoxColumn1.FalseValue = "N"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "同檢體加作"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 80
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.TrueValue = "Y"
        Me.DataGridViewCheckBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Sheet_Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "表單代碼"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 55
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.DataPropertyName = "Time_Control_Id"
        Me.DataGridViewComboBoxColumn3.HeaderText = "時間單位"
        Me.DataGridViewComboBoxColumn3.MinimumWidth = 80
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.Width = 120
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Is_Default"
        Me.DataGridViewCheckBoxColumn2.FalseValue = "N"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "預設檢體"
        Me.DataGridViewCheckBoxColumn2.IndeterminateValue = "N"
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 60
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn2.TrueValue = "Y"
        Me.DataGridViewCheckBoxColumn2.Width = 70
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Is_Default_Vessel"
        Me.DataGridViewCheckBoxColumn3.FalseValue = "N"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "預設容器"
        Me.DataGridViewCheckBoxColumn3.IndeterminateValue = "N"
        Me.DataGridViewCheckBoxColumn3.MinimumWidth = 35
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.TrueValue = "Y"
        Me.DataGridViewCheckBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Order_Code"
        Me.DataGridViewTextBoxColumn2.HeaderText = "醫令代碼"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Order_Name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "名稱"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Separate_Mark"
        Me.DataGridViewTextBoxColumn4.HeaderText = "拆單註記"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Exclusive_Order_Code"
        Me.DataGridViewTextBoxColumn5.HeaderText = "互斥拆單醫令設定"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Is_Indication"
        Me.DataGridViewTextBoxColumn6.HeaderText = "檢體ID"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Is_Print_Order_Note"
        Me.DataGridViewTextBoxColumn7.HeaderText = "檢體"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 140
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Order_Note"
        Me.DataGridViewTextBoxColumn8.HeaderText = "容器ID"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Specimen_Id"
        Me.DataGridViewTextBoxColumn9.HeaderText = "容器"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 140
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Control_Value"
        Me.DataGridViewTextBoxColumn10.HeaderText = "時間"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 75
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Vessel_Id"
        Me.DataGridViewTextBoxColumn11.HeaderText = "容器ID"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Vessel_Name"
        Me.DataGridViewTextBoxColumn12.HeaderText = "容器"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 140
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Control_Value"
        Me.DataGridViewTextBoxColumn13.HeaderText = "時間"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Width = 75
        '
        'PUBExaminationSheetDetailMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 573)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.FlowLayoutPanelButton)
        Me.KeyPreview = True
        Me.Name = "PUBExaminationSheetDetailMaintainUI"
        Me.TabText = "檢驗醫令明細維護"
        Me.Text = "檢驗醫令明細維護"
        Me.FlowLayoutPanelButton.ResumeLayout(False)
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanelLeftBottom.ResumeLayout(False)
        Me.TableLayoutPanelLeftBottom.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.btn_OrderCheck.ResumeLayout(False)
        Me.gbx_SpecimenAndReceptacle.ResumeLayout(False)
        CType(Me.dgv_SpecimenVessel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbx_NoteForOrdering.ResumeLayout(False)
        Me.gbx_NoteForOrdering.PerformLayout()
        Me.gbx_NoteForPrinting.ResumeLayout(False)
        Me.gbx_NoteForPrinting.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TabSetting.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.gbx_SeperateSheet.ResumeLayout(False)
        Me.gbx_SeperateSheet.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.gbx_ExclusiveOrder.ResumeLayout(False)
        Me.gbx_ExclusiveOrder.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.gbx_SelectoryOrderList.ResumeLayout(False)
        Me.TabDuplidatedOrder.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.gbx_Selectgory2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanelButton As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_SheetNameList As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanelLeftBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_SheetIndication As System.Windows.Forms.Button
    Friend WithEvents chk_PrintSheetIndication As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_SheetList As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_SheetLimitCnt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_OrderCode As System.Windows.Forms.Label
    Friend WithEvents txt_ORderCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_OrderName As System.Windows.Forms.Label
    Friend WithEvents txt_OrderEnName As System.Windows.Forms.TextBox
    Friend WithEvents TabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents btn_OrderCheck As System.Windows.Forms.TabPage
    Friend WithEvents TabSetting As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_StartDate As System.Windows.Forms.Label
    Friend WithEvents lbl_EndDate As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_OrderIndication As System.Windows.Forms.Button
    Friend WithEvents chk_PrintOrderIndication As System.Windows.Forms.CheckBox
    Friend WithEvents gbx_SpecimenAndReceptacle As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_SpecimenVessel As System.Windows.Forms.DataGridView
    Friend WithEvents gbx_NoteForPrinting As System.Windows.Forms.GroupBox
    Friend WithEvents chk_NoteForPrinting As System.Windows.Forms.CheckBox
    Friend WithEvents txt_NoteForPrinting As System.Windows.Forms.TextBox
    Friend WithEvents gbx_SelectoryOrderList As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_SelectoryOrderList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbx_SeperateSheet As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_ExclusiveOrder As System.Windows.Forms.GroupBox
    Friend WithEvents chk_AloneOrderFlag As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_SeparateOrder As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents dgv_ExclusiveOrder As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_AddToSeparateOrder As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromSeparateOrder As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_AddToExclusiveOrder As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromExclusiveOrder As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabDuplidatedOrder As System.Windows.Forms.TabPage
    Friend WithEvents gbx_Selectgory2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_SelectoryOrderList2 As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_DuplicatedOrder As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_AddToDuplicatedOrder As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromDuplicatedOrder As System.Windows.Forms.Button
    Friend WithEvents cbo_SexLimit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_DeptLimit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dgv_OrderList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_DeleteOrder As System.Windows.Forms.Button
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gbx_NoteForOrdering As System.Windows.Forms.GroupBox
    Friend WithEvents txt_NoteForOrdering As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_DoctLimit As System.Windows.Forms.TextBox
    Friend WithEvents txt_DeptLimit As System.Windows.Forms.TextBox
    Friend WithEvents btn_DoctLimit As System.Windows.Forms.Button
    Friend WithEvents btn_DeptLimit As System.Windows.Forms.Button
    Friend WithEvents btn_DoctLimitClear As System.Windows.Forms.Button
    Friend WithEvents btn_DeptLimitClear As System.Windows.Forms.Button
    Friend WithEvents tcq_DoctLimit As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Btn_UpdateSheetDetail As System.Windows.Forms.Button
    Friend WithEvents Chk_IsScheduled As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_PhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chk_IsSeeReport As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnSpecimenId As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColumnVesselId As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColumnAsAddToSpecimen As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColumnControlValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnTimeControlId As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColumnIsDefault As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColumnIsDefaultVessel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Chk_IsLimitHealth As System.Windows.Forms.CheckBox
    Friend WithEvents tb_Gridsort As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
