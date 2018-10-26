<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBLisSheetUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBLisSheetUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_SheetCode = New System.Windows.Forms.TextBox()
        Me.txt_SheetName = New System.Windows.Forms.TextBox()
        Me.cbo_DeptCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_ReportTitle = New System.Windows.Forms.TextBox()
        Me.txt_SheetShortName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chk_IsEmergencySheet = New System.Windows.Forms.CheckBox()
        Me.chk_Dc = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_FinishTotalHours = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_SignHour = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_RptHour = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_IOType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_SpicemenType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtxt_ListWarning = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_SheetCollectNote = New System.Windows.Forms.TextBox()
        Me.txt_SheetNote = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 154)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 487)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 450)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 450)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_SheetCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_SheetName, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_DeptCode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_ReportTitle, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_SheetShortName, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(958, 149)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*表單代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(11, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "執行科別"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(233, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "表單名稱"
        '
        'txt_SheetCode
        '
        Me.txt_SheetCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SheetCode.Location = New System.Drawing.Point(89, 3)
        Me.txt_SheetCode.Name = "txt_SheetCode"
        Me.txt_SheetCode.Size = New System.Drawing.Size(138, 27)
        Me.txt_SheetCode.TabIndex = 0
        '
        'txt_SheetName
        '
        Me.txt_SheetName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_SheetName, 3)
        Me.txt_SheetName.Location = New System.Drawing.Point(311, 3)
        Me.txt_SheetName.Name = "txt_SheetName"
        Me.txt_SheetName.Size = New System.Drawing.Size(262, 27)
        Me.txt_SheetName.TabIndex = 1
        '
        'cbo_DeptCode
        '
        Me.cbo_DeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_DeptCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_DeptCode.DropDownWidth = 20
        Me.cbo_DeptCode.DroppedDown = False
        Me.cbo_DeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_DeptCode.Location = New System.Drawing.Point(90, 34)
        Me.cbo_DeptCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_DeptCode.Name = "cbo_DeptCode"
        Me.cbo_DeptCode.SelectedIndex = -1
        Me.cbo_DeptCode.SelectedItem = Nothing
        Me.cbo_DeptCode.SelectedText = ""
        Me.cbo_DeptCode.SelectedValue = ""
        Me.cbo_DeptCode.SelectionStart = 0
        Me.cbo_DeptCode.Size = New System.Drawing.Size(136, 22)
        Me.cbo_DeptCode.TabIndex = 2
        Me.cbo_DeptCode.uclDisplayIndex = "0,1"
        Me.cbo_DeptCode.uclIsAutoClear = True
        Me.cbo_DeptCode.uclIsFirstItemEmpty = True
        Me.cbo_DeptCode.uclIsTextMode = False
        Me.cbo_DeptCode.uclShowMsg = False
        Me.cbo_DeptCode.uclValueIndex = "0"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(233, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "表單抬頭"
        '
        'txt_ReportTitle
        '
        Me.txt_ReportTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_ReportTitle, 3)
        Me.txt_ReportTitle.Location = New System.Drawing.Point(311, 33)
        Me.txt_ReportTitle.Name = "txt_ReportTitle"
        Me.txt_ReportTitle.Size = New System.Drawing.Size(262, 27)
        Me.txt_ReportTitle.TabIndex = 0
        '
        'txt_SheetShortName
        '
        Me.txt_SheetShortName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SheetShortName.Location = New System.Drawing.Point(657, 3)
        Me.txt_SheetShortName.Name = "txt_SheetShortName"
        Me.txt_SheetShortName.Size = New System.Drawing.Size(127, 27)
        Me.txt_SheetShortName.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(579, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "表單簡稱"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_IsEmergencySheet)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_Dc)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(790, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(166, 24)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'chk_IsEmergencySheet
        '
        Me.chk_IsEmergencySheet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_IsEmergencySheet.AutoSize = True
        Me.chk_IsEmergencySheet.Location = New System.Drawing.Point(3, 3)
        Me.chk_IsEmergencySheet.Name = "chk_IsEmergencySheet"
        Me.chk_IsEmergencySheet.Size = New System.Drawing.Size(107, 20)
        Me.chk_IsEmergencySheet.TabIndex = 3
        Me.chk_IsEmergencySheet.Text = "是否急作單"
        Me.chk_IsEmergencySheet.UseVisualStyleBackColor = True
        '
        'chk_Dc
        '
        Me.chk_Dc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Dc.AutoSize = True
        Me.chk_Dc.Location = New System.Drawing.Point(116, 3)
        Me.chk_Dc.Name = "chk_Dc"
        Me.chk_Dc.Size = New System.Drawing.Size(45, 20)
        Me.chk_Dc.TabIndex = 5
        Me.chk_Dc.Text = "Dc"
        Me.chk_Dc.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 3)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_FinishTotalHours, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_SignHour, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_RptHour, 1, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(579, 33)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel1.SetRowSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(377, 111)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(3, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "簽收->確認應完成時數"
        '
        'txt_FinishTotalHours
        '
        Me.txt_FinishTotalHours.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FinishTotalHours.Enabled = False
        Me.txt_FinishTotalHours.Location = New System.Drawing.Point(174, 69)
        Me.txt_FinishTotalHours.Name = "txt_FinishTotalHours"
        Me.txt_FinishTotalHours.Size = New System.Drawing.Size(62, 27)
        Me.txt_FinishTotalHours.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(3, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "開單->確認應完成時數"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(3, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "開單->簽收應完成時數"
        '
        'txt_SignHour
        '
        Me.txt_SignHour.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SignHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txt_SignHour.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_SignHour.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SignHour.Location = New System.Drawing.Point(174, 3)
        Me.txt_SignHour.MaxLength = 32767
        Me.txt_SignHour.Name = "txt_SignHour"
        Me.txt_SignHour.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SignHour.SelectionStart = 0
        Me.txt_SignHour.Size = New System.Drawing.Size(62, 27)
        Me.txt_SignHour.TabIndex = 4
        Me.txt_SignHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SignHour.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SignHour.ToolTipTag = Nothing
        Me.txt_SignHour.uclDollarSign = False
        Me.txt_SignHour.uclDotCount = 2
        Me.txt_SignHour.uclIntCount = 4
        Me.txt_SignHour.uclMinus = False
        Me.txt_SignHour.uclReadOnly = False
        Me.txt_SignHour.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_SignHour.uclTrimZero = True
        '
        'txt_RptHour
        '
        Me.txt_RptHour.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_RptHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txt_RptHour.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_RptHour.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_RptHour.Location = New System.Drawing.Point(174, 36)
        Me.txt_RptHour.MaxLength = 32767
        Me.txt_RptHour.Name = "txt_RptHour"
        Me.txt_RptHour.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_RptHour.SelectionStart = 0
        Me.txt_RptHour.Size = New System.Drawing.Size(62, 27)
        Me.txt_RptHour.TabIndex = 5
        Me.txt_RptHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_RptHour.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_RptHour.ToolTipTag = Nothing
        Me.txt_RptHour.uclDollarSign = False
        Me.txt_RptHour.uclDotCount = 2
        Me.txt_RptHour.uclIntCount = 4
        Me.txt_RptHour.uclMinus = False
        Me.txt_RptHour.uclReadOnly = False
        Me.txt_RptHour.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_RptHour.uclTrimZero = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel4, 6)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.88525!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.11475!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_IOType, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_SpicemenType, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 63)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(570, 83)
        Me.TableLayoutPanel4.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(312, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "IO類別"
        '
        'cbo_IOType
        '
        Me.cbo_IOType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IOType.DropDownWidth = 20
        Me.cbo_IOType.DroppedDown = False
        Me.cbo_IOType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IOType.Location = New System.Drawing.Point(375, 4)
        Me.cbo_IOType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_IOType.Name = "cbo_IOType"
        Me.cbo_IOType.SelectedIndex = -1
        Me.cbo_IOType.SelectedItem = Nothing
        Me.cbo_IOType.SelectedText = ""
        Me.cbo_IOType.SelectedValue = ""
        Me.cbo_IOType.SelectionStart = 0
        Me.cbo_IOType.Size = New System.Drawing.Size(188, 22)
        Me.cbo_IOType.TabIndex = 2
        Me.cbo_IOType.uclDisplayIndex = "0,1"
        Me.cbo_IOType.uclIsAutoClear = True
        Me.cbo_IOType.uclIsFirstItemEmpty = True
        Me.cbo_IOType.uclIsTextMode = False
        Me.cbo_IOType.uclShowMsg = False
        Me.cbo_IOType.uclValueIndex = "0"
        '
        'cbo_SpicemenType
        '
        Me.cbo_SpicemenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SpicemenType.DropDownWidth = 20
        Me.cbo_SpicemenType.DroppedDown = False
        Me.cbo_SpicemenType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SpicemenType.Location = New System.Drawing.Point(85, 4)
        Me.cbo_SpicemenType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_SpicemenType.Name = "cbo_SpicemenType"
        Me.cbo_SpicemenType.SelectedIndex = -1
        Me.cbo_SpicemenType.SelectedItem = Nothing
        Me.cbo_SpicemenType.SelectedText = ""
        Me.cbo_SpicemenType.SelectedValue = ""
        Me.cbo_SpicemenType.SelectionStart = 0
        Me.cbo_SpicemenType.Size = New System.Drawing.Size(213, 22)
        Me.cbo_SpicemenType.TabIndex = 2
        Me.cbo_SpicemenType.uclDisplayIndex = "0,1"
        Me.cbo_SpicemenType.uclIsAutoClear = True
        Me.cbo_SpicemenType.uclIsFirstItemEmpty = True
        Me.cbo_SpicemenType.uclIsTextMode = False
        Me.cbo_SpicemenType.uclShowMsg = False
        Me.cbo_SpicemenType.uclValueIndex = "0"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "檢驗組別"
        '
        'FlowLayoutPanel2
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.FlowLayoutPanel2, 4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.rtxt_ListWarning)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 33)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(564, 53)
        Me.FlowLayoutPanel2.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "表單注意事項"
        '
        'rtxt_ListWarning
        '
        Me.rtxt_ListWarning.Location = New System.Drawing.Point(113, 3)
        Me.rtxt_ListWarning.Name = "rtxt_ListWarning"
        Me.rtxt_ListWarning.Size = New System.Drawing.Size(439, 47)
        Me.rtxt_ListWarning.TabIndex = 3
        Me.rtxt_ListWarning.Text = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_SheetCollectNote, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_SheetNote, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 158)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(958, 42)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "採檢人員注意事項"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(482, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "病人注意事項"
        Me.Label6.Visible = False
        '
        'txt_SheetCollectNote
        '
        Me.txt_SheetCollectNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_SheetCollectNote.Location = New System.Drawing.Point(3, 17)
        Me.txt_SheetCollectNote.Multiline = True
        Me.txt_SheetCollectNote.Name = "txt_SheetCollectNote"
        Me.txt_SheetCollectNote.Size = New System.Drawing.Size(473, 24)
        Me.txt_SheetCollectNote.TabIndex = 6
        Me.txt_SheetCollectNote.Visible = False
        '
        'txt_SheetNote
        '
        Me.txt_SheetNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_SheetNote.Location = New System.Drawing.Point(482, 17)
        Me.txt_SheetNote.Multiline = True
        Me.txt_SheetNote.Name = "txt_SheetNote"
        Me.txt_SheetNote.Size = New System.Drawing.Size(473, 24)
        Me.txt_SheetNote.TabIndex = 7
        Me.txt_SheetNote.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Sheet_Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "表單代碼"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 95
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Sheet_Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "表單名稱"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Dept_Code"
        Me.DataGridViewTextBoxColumn3.HeaderText = "執行科別"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 95
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Sheet_Contect_Tel"
        Me.DataGridViewTextBoxColumn4.HeaderText = "聯絡分機"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 95
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Is_Emergency_Sheet"
        Me.DataGridViewTextBoxColumn5.HeaderText = "是否急作單"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 115
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Sheet_Collect_Note"
        Me.DataGridViewTextBoxColumn6.HeaderText = "開單/採檢注意事項"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 165
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Sheet_Note"
        Me.DataGridViewTextBoxColumn7.HeaderText = "表單注意事項"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 1
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Main.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 154)
        Me.tlp_Main.TabIndex = 1
        '
        'PUBLisSheetUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PUBLisSheetUI"
        Me.TabText = "檢驗表單維護"
        Me.Text = "檢驗表單維護"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.tlp_Main.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_SheetCode As System.Windows.Forms.TextBox
    Friend WithEvents txt_SheetName As System.Windows.Forms.TextBox
    Friend WithEvents chk_IsEmergencySheet As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_DeptCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_SheetCollectNote As System.Windows.Forms.TextBox
    Friend WithEvents txt_SheetNote As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chk_Dc As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents cbo_IOType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txt_SheetShortName As System.Windows.Forms.TextBox
    Friend WithEvents cbo_SpicemenType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_FinishTotalHours As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_SignHour As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_RptHour As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rtxt_ListWarning As System.Windows.Forms.RichTextBox
End Class
