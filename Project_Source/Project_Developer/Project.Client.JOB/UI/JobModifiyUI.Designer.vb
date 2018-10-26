<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobModifiyUI
    Inherits System.Windows.Forms.Form

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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobModifiyUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gup_SA = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtb_Desc = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_DeadLine = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.cbo_IssueClassify = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_Function = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_Hosp = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt_EstimateCost = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gup_SD = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rtb_SDNote = New System.Windows.Forms.RichTextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dtp_SD_Issue_Deadline = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_SD_Estimate_Cost = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_SD_Cost_Time = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gup_SA.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.gup_SD.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gup_SA, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gup_SD, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.33223!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.66777!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(944, 641)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gup_SA
        '
        Me.gup_SA.Controls.Add(Me.TableLayoutPanel2)
        Me.gup_SA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gup_SA.Location = New System.Drawing.Point(3, 3)
        Me.gup_SA.Name = "gup_SA"
        Me.gup_SA.Size = New System.Drawing.Size(938, 297)
        Me.gup_SA.TabIndex = 0
        Me.gup_SA.TabStop = False
        Me.gup_SA.Text = "SA修改"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rtb_Desc, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.05166!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.94834!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(932, 271)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'rtb_Desc
        '
        Me.rtb_Desc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Desc.Enabled = False
        Me.rtb_Desc.Location = New System.Drawing.Point(3, 3)
        Me.rtb_Desc.Name = "rtb_Desc"
        Me.rtb_Desc.Size = New System.Drawing.Size(926, 172)
        Me.rtb_Desc.TabIndex = 2
        Me.rtb_Desc.Text = ""
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.dtp_DeadLine, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_Subject, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_IssueClassify, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_Function, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_Hosp, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.FlowLayoutPanel4, 5, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 182)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.56391!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(924, 85)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(19, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "所屬醫院"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "預計完成日"
        '
        'dtp_DeadLine
        '
        Me.dtp_DeadLine.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_DeadLine.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_DeadLine.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_DeadLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_DeadLine.Location = New System.Drawing.Point(97, 47)
        Me.dtp_DeadLine.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_DeadLine.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_DeadLine.Name = "dtp_DeadLine"
        Me.dtp_DeadLine.Size = New System.Drawing.Size(151, 27)
        Me.dtp_DeadLine.TabIndex = 10
        Me.dtp_DeadLine.uclIsFixedBackColor = False
        Me.dtp_DeadLine.uclReadOnly = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(254, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "需求主旨"
        '
        'txt_Subject
        '
        Me.txt_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Subject.Location = New System.Drawing.Point(332, 47)
        Me.txt_Subject.MaxLength = 20
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.Size = New System.Drawing.Size(278, 27)
        Me.txt_Subject.TabIndex = 12
        '
        'cbo_IssueClassify
        '
        Me.cbo_IssueClassify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_IssueClassify.FormattingEnabled = True
        Me.cbo_IssueClassify.Items.AddRange(New Object() {"需求", "BUG", "需求+BUG"})
        Me.cbo_IssueClassify.Location = New System.Drawing.Point(726, 6)
        Me.cbo_IssueClassify.Name = "cbo_IssueClassify"
        Me.cbo_IssueClassify.Size = New System.Drawing.Size(154, 24)
        Me.cbo_IssueClassify.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(648, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "需求類別"
        '
        'cbo_Function
        '
        Me.cbo_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Function.DropDownWidth = 20
        Me.cbo_Function.DroppedDown = False
        Me.cbo_Function.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Function.Location = New System.Drawing.Point(329, 6)
        Me.cbo_Function.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Function.MaxLength = 50
        Me.cbo_Function.Name = "cbo_Function"
        Me.cbo_Function.SelectedIndex = -1
        Me.cbo_Function.SelectedItem = Nothing
        Me.cbo_Function.SelectedText = ""
        Me.cbo_Function.SelectedValue = ""
        Me.cbo_Function.SelectionStart = 0
        Me.cbo_Function.Size = New System.Drawing.Size(157, 24)
        Me.cbo_Function.TabIndex = 9
        Me.cbo_Function.uclDisplayIndex = "0,1"
        Me.cbo_Function.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_Function.uclIsAutoClear = True
        Me.cbo_Function.uclIsFirstItemEmpty = True
        Me.cbo_Function.uclIsTextMode = False
        Me.cbo_Function.uclShowMsg = False
        Me.cbo_Function.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(254, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "歸屬功能"
        '
        'cbo_Hosp
        '
        Me.cbo_Hosp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Hosp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Hosp.DropDownWidth = 20
        Me.cbo_Hosp.DroppedDown = False
        Me.cbo_Hosp.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Hosp.Location = New System.Drawing.Point(94, 6)
        Me.cbo_Hosp.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Hosp.MaxLength = 50
        Me.cbo_Hosp.Name = "cbo_Hosp"
        Me.cbo_Hosp.SelectedIndex = -1
        Me.cbo_Hosp.SelectedItem = Nothing
        Me.cbo_Hosp.SelectedText = ""
        Me.cbo_Hosp.SelectedValue = ""
        Me.cbo_Hosp.SelectionStart = 0
        Me.cbo_Hosp.Size = New System.Drawing.Size(157, 24)
        Me.cbo_Hosp.TabIndex = 24
        Me.cbo_Hosp.uclDisplayIndex = "0,1"
        Me.cbo_Hosp.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_Hosp.uclIsAutoClear = True
        Me.cbo_Hosp.uclIsFirstItemEmpty = True
        Me.cbo_Hosp.uclIsTextMode = False
        Me.cbo_Hosp.uclShowMsg = False
        Me.cbo_Hosp.uclValueIndex = "0"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(616, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "需求評估時間"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel4.Controls.Add(Me.txt_EstimateCost)
        Me.FlowLayoutPanel4.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(726, 44)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(196, 33)
        Me.FlowLayoutPanel4.TabIndex = 21
        '
        'txt_EstimateCost
        '
        Me.txt_EstimateCost.Location = New System.Drawing.Point(3, 3)
        Me.txt_EstimateCost.MaxLength = 10
        Me.txt_EstimateCost.Name = "txt_EstimateCost"
        Me.txt_EstimateCost.Size = New System.Drawing.Size(93, 27)
        Me.txt_EstimateCost.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(102, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "人日"
        '
        'gup_SD
        '
        Me.gup_SD.Controls.Add(Me.TableLayoutPanel3)
        Me.gup_SD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gup_SD.Location = New System.Drawing.Point(3, 306)
        Me.gup_SD.Name = "gup_SD"
        Me.gup_SD.Size = New System.Drawing.Size(938, 293)
        Me.gup_SD.TabIndex = 1
        Me.gup_SD.TabStop = False
        Me.gup_SD.Text = "SD修改"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox3, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(932, 267)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(926, 220)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SD備註"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rtb_SDNote)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(920, 194)
        Me.Panel4.TabIndex = 0
        '
        'rtb_SDNote
        '
        Me.rtb_SDNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_SDNote.Location = New System.Drawing.Point(0, 0)
        Me.rtb_SDNote.Name = "rtb_SDNote"
        Me.rtb_SDNote.Size = New System.Drawing.Size(920, 194)
        Me.rtb_SDNote.TabIndex = 0
        Me.rtb_SDNote.Text = ""
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dtp_SD_Issue_Deadline)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.txt_SD_Estimate_Cost)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.txt_SD_Cost_Time)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(926, 35)
        Me.Panel5.TabIndex = 7
        '
        'dtp_SD_Issue_Deadline
        '
        Me.dtp_SD_Issue_Deadline.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_SD_Issue_Deadline.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_SD_Issue_Deadline.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_SD_Issue_Deadline.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_SD_Issue_Deadline.Location = New System.Drawing.Point(572, 4)
        Me.dtp_SD_Issue_Deadline.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_SD_Issue_Deadline.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_SD_Issue_Deadline.Name = "dtp_SD_Issue_Deadline"
        Me.dtp_SD_Issue_Deadline.Size = New System.Drawing.Size(118, 27)
        Me.dtp_SD_Issue_Deadline.TabIndex = 7
        Me.dtp_SD_Issue_Deadline.uclIsFixedBackColor = False
        Me.dtp_SD_Issue_Deadline.uclReadOnly = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(459, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 16)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "SD預估完成日:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(408, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 16)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "人/日"
        '
        'txt_SD_Estimate_Cost
        '
        Me.txt_SD_Estimate_Cost.Location = New System.Drawing.Point(343, 4)
        Me.txt_SD_Estimate_Cost.Name = "txt_SD_Estimate_Cost"
        Me.txt_SD_Estimate_Cost.Size = New System.Drawing.Size(59, 27)
        Me.txt_SD_Estimate_Cost.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(215, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 16)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "SD預計完成人日:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(163, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "人/日"
        '
        'txt_SD_Cost_Time
        '
        Me.txt_SD_Cost_Time.Location = New System.Drawing.Point(98, 4)
        Me.txt_SD_Cost_Time.Name = "txt_SD_Cost_Time"
        Me.txt_SD_Cost_Time.Size = New System.Drawing.Size(59, 27)
        Me.txt_SD_Cost_Time.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "SD確認時間:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Update)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 605)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(938, 33)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btn_Update
        '
        Me.btn_Update.Location = New System.Drawing.Point(3, 3)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(96, 27)
        Me.btn_Update.TabIndex = 0
        Me.btn_Update.Text = "確認"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(105, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 27)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(207, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 27)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "清除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'JobModifiyUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "JobModifiyUI"
        Me.Text = "派工異動作業"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.gup_SA.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.gup_SD.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents gup_SA As Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents gup_SD As Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents dtp_SD_Issue_Deadline As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents txt_SD_Estimate_Cost As Windows.Forms.TextBox
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents txt_SD_Cost_Time As Windows.Forms.TextBox
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents rtb_SDNote As Windows.Forms.RichTextBox
    Friend WithEvents rtb_Desc As Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel4 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents dtp_DeadLine As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txt_Subject As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel4 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_EstimateCost As Windows.Forms.TextBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents cbo_Function As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cbo_Hosp As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Update As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents cbo_IssueClassify As Windows.Forms.ComboBox
End Class
