<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFCDataSender
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk_Spec_Flag = New System.Windows.Forms.CheckBox()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lbl_StartDate = New System.Windows.Forms.Label()
        Me.lbl_StartTime = New System.Windows.Forms.Label()
        Me.lbl_EndDate = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lbl_EndTime = New System.Windows.Forms.Label()
        Me.lbl_Subject = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.lbl_Msg = New System.Windows.Forms.Label()
        Me.rtb_Msg = New System.Windows.Forms.RichTextBox()
        Me.mtb_StartTime = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_EndTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_Mail = New System.Windows.Forms.CheckBox()
        Me.chk_SMS = New System.Windows.Forms.CheckBox()
        Me.chk_windows = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grp_Query = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_QryEndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.mtb_EndTimeQ = New System.Windows.Forms.MaskedTextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_QryStartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.mtb_StartTimeQ = New System.Windows.Forms.MaskedTextBox()
        Me.Btn_Query = New System.Windows.Forms.Button()
        Me.tcq_Employee = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_QueryNsg = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Rdo_After = New System.Windows.Forms.RadioButton()
        Me.Rdo_Now = New System.Windows.Forms.RadioButton()
        Me.Rdo_Before = New System.Windows.Forms.RadioButton()
        Me.btn_Send = New System.Windows.Forms.Button()
        Me.btn_SearchNodeText = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UclTreeViewAdvUC1 = New Syscom.Client.UCL.UCLTreeViewAdvUC()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rdo_H = New System.Windows.Forms.RadioButton()
        Me.rdo_G = New System.Windows.Forms.RadioButton()
        Me.rdo_D = New System.Windows.Forms.RadioButton()
        Me.rdo_P = New System.Windows.Forms.RadioButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Query.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.chk_Spec_Flag, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_StartDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_StartDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_StartTime, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_EndDate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EndDate, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_EndTime, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Subject, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Subject, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Msg, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_Msg, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtb_StartTime, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtb_EndTime, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chk_Mail, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chk_SMS, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chk_windows, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Grp_Query, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Send, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_SearchNodeText, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UclTreeViewAdvUC1, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 7, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 221.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 641)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'chk_Spec_Flag
        '
        Me.chk_Spec_Flag.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Spec_Flag.AutoSize = True
        Me.chk_Spec_Flag.Location = New System.Drawing.Point(397, 279)
        Me.chk_Spec_Flag.Name = "chk_Spec_Flag"
        Me.chk_Spec_Flag.Size = New System.Drawing.Size(123, 20)
        Me.chk_Spec_Flag.TabIndex = 28
        Me.chk_Spec_Flag.Text = "浮動訊息確認"
        Me.chk_Spec_Flag.UseVisualStyleBackColor = True
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(81, 5)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(126, 27)
        Me.dtp_StartDate.TabIndex = 0
        Me.dtp_StartDate.uclReadOnly = False
        '
        'lbl_StartDate
        '
        Me.lbl_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartDate.AutoSize = True
        Me.lbl_StartDate.Location = New System.Drawing.Point(3, 11)
        Me.lbl_StartDate.Name = "lbl_StartDate"
        Me.lbl_StartDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartDate.TabIndex = 1
        Me.lbl_StartDate.Text = "開始日期"
        '
        'lbl_StartTime
        '
        Me.lbl_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartTime.AutoSize = True
        Me.lbl_StartTime.Location = New System.Drawing.Point(213, 11)
        Me.lbl_StartTime.Name = "lbl_StartTime"
        Me.lbl_StartTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartTime.TabIndex = 2
        Me.lbl_StartTime.Text = "開始時間"
        '
        'lbl_EndDate
        '
        Me.lbl_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndDate.AutoSize = True
        Me.lbl_EndDate.Location = New System.Drawing.Point(3, 53)
        Me.lbl_EndDate.Name = "lbl_EndDate"
        Me.lbl_EndDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndDate.TabIndex = 4
        Me.lbl_EndDate.Text = "結束日期"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(81, 47)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(126, 27)
        Me.dtp_EndDate.TabIndex = 5
        Me.dtp_EndDate.uclReadOnly = False
        '
        'lbl_EndTime
        '
        Me.lbl_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndTime.AutoSize = True
        Me.lbl_EndTime.Location = New System.Drawing.Point(213, 53)
        Me.lbl_EndTime.Name = "lbl_EndTime"
        Me.lbl_EndTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndTime.TabIndex = 6
        Me.lbl_EndTime.Text = "結束時間"
        '
        'lbl_Subject
        '
        Me.lbl_Subject.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Subject.AutoSize = True
        Me.lbl_Subject.Location = New System.Drawing.Point(35, 91)
        Me.lbl_Subject.Name = "lbl_Subject"
        Me.lbl_Subject.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Subject.TabIndex = 8
        Me.lbl_Subject.Text = "主旨"
        '
        'txt_Subject
        '
        Me.txt_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Subject.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_Subject, 6)
        Me.txt_Subject.Location = New System.Drawing.Point(81, 87)
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.Size = New System.Drawing.Size(617, 27)
        Me.txt_Subject.TabIndex = 9
        '
        'lbl_Msg
        '
        Me.lbl_Msg.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Msg.AutoSize = True
        Me.lbl_Msg.Location = New System.Drawing.Point(35, 185)
        Me.lbl_Msg.Name = "lbl_Msg"
        Me.lbl_Msg.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Msg.TabIndex = 10
        Me.lbl_Msg.Text = "訊息"
        '
        'rtb_Msg
        '
        Me.rtb_Msg.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.rtb_Msg, 6)
        Me.rtb_Msg.Dock = System.Windows.Forms.DockStyle.Left
        Me.rtb_Msg.Location = New System.Drawing.Point(81, 117)
        Me.rtb_Msg.Name = "rtb_Msg"
        Me.rtb_Msg.Size = New System.Drawing.Size(617, 153)
        Me.rtb_Msg.TabIndex = 11
        Me.rtb_Msg.Text = ""
        '
        'mtb_StartTime
        '
        Me.mtb_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_StartTime.BackColor = System.Drawing.Color.White
        Me.mtb_StartTime.Location = New System.Drawing.Point(291, 5)
        Me.mtb_StartTime.Mask = "90:00"
        Me.mtb_StartTime.Name = "mtb_StartTime"
        Me.mtb_StartTime.Size = New System.Drawing.Size(100, 27)
        Me.mtb_StartTime.TabIndex = 3
        Me.mtb_StartTime.ValidatingType = GetType(Date)
        '
        'mtb_EndTime
        '
        Me.mtb_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_EndTime.BackColor = System.Drawing.Color.White
        Me.mtb_EndTime.Location = New System.Drawing.Point(291, 47)
        Me.mtb_EndTime.Mask = "90:00"
        Me.mtb_EndTime.Name = "mtb_EndTime"
        Me.mtb_EndTime.Size = New System.Drawing.Size(100, 27)
        Me.mtb_EndTime.TabIndex = 7
        Me.mtb_EndTime.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(397, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "(請輸入00:00~23:59)"
        '
        'chk_Mail
        '
        Me.chk_Mail.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chk_Mail.AutoSize = True
        Me.chk_Mail.Location = New System.Drawing.Point(108, 279)
        Me.chk_Mail.Name = "chk_Mail"
        Me.chk_Mail.Size = New System.Drawing.Size(99, 20)
        Me.chk_Mail.TabIndex = 17
        Me.chk_Mail.Text = "電子郵件  "
        Me.chk_Mail.UseVisualStyleBackColor = True
        '
        'chk_SMS
        '
        Me.chk_SMS.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_SMS.AutoSize = True
        Me.chk_SMS.Location = New System.Drawing.Point(213, 279)
        Me.chk_SMS.Name = "chk_SMS"
        Me.chk_SMS.Size = New System.Drawing.Size(72, 20)
        Me.chk_SMS.TabIndex = 16
        Me.chk_SMS.Text = "簡訊"
        Me.chk_SMS.UseVisualStyleBackColor = True
        '
        'chk_windows
        '
        Me.chk_windows.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_windows.AutoSize = True
        Me.chk_windows.Location = New System.Drawing.Point(291, 279)
        Me.chk_windows.Name = "chk_windows"
        Me.chk_windows.Size = New System.Drawing.Size(100, 20)
        Me.chk_windows.TabIndex = 18
        Me.chk_windows.Text = "浮動視窗"
        Me.chk_windows.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(397, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "(請輸入00:00~23:59)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 496)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "訊息清單"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column9})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridView1, 8)
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView1.Location = New System.Drawing.Point(81, 397)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(879, 215)
        Me.DataGridView1.TabIndex = 20
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column7.HeaderText = "訊息狀態"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 73
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column8.HeaderText = "訊息種類"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 73
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column1.HeaderText = "開始日期時間"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 87
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column2.HeaderText = "結束日期時間"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 87
        '
        'Column3
        '
        Me.Column3.HeaderText = "主旨"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 130
        '
        'Column4
        '
        Me.Column4.HeaderText = "訊息內容"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 300
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column5.HeaderText = "發送日期時間"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 87
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column6.HeaderText = "發送對象"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 73
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column9.HeaderText = "識別碼"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 73
        '
        'Grp_Query
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Grp_Query, 8)
        Me.Grp_Query.Controls.Add(Me.FlowLayoutPanel2)
        Me.Grp_Query.Controls.Add(Me.FlowLayoutPanel1)
        Me.Grp_Query.Controls.Add(Me.Btn_Query)
        Me.Grp_Query.Controls.Add(Me.tcq_Employee)
        Me.Grp_Query.Controls.Add(Me.Label9)
        Me.Grp_Query.Controls.Add(Me.Txt_QueryNsg)
        Me.Grp_Query.Controls.Add(Me.Label8)
        Me.Grp_Query.Controls.Add(Me.Label7)
        Me.Grp_Query.Controls.Add(Me.Rdo_After)
        Me.Grp_Query.Controls.Add(Me.Rdo_Now)
        Me.Grp_Query.Controls.Add(Me.Rdo_Before)
        Me.Grp_Query.Location = New System.Drawing.Point(81, 308)
        Me.Grp_Query.Name = "Grp_Query"
        Me.Grp_Query.Size = New System.Drawing.Size(879, 83)
        Me.Grp_Query.TabIndex = 27
        Me.Grp_Query.TabStop = False
        Me.Grp_Query.Text = "查詢區"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel2.Controls.Add(Me.dtp_QryEndDate)
        Me.FlowLayoutPanel2.Controls.Add(Me.mtb_EndTimeQ)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(60, 50)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(290, 33)
        Me.FlowLayoutPanel2.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "結束日期時間"
        '
        'dtp_QryEndDate
        '
        Me.dtp_QryEndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_QryEndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_QryEndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_QryEndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_QryEndDate.Location = New System.Drawing.Point(113, 3)
        Me.dtp_QryEndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_QryEndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_QryEndDate.Name = "dtp_QryEndDate"
        Me.dtp_QryEndDate.Size = New System.Drawing.Size(113, 27)
        Me.dtp_QryEndDate.TabIndex = 20
        Me.dtp_QryEndDate.uclReadOnly = False
        '
        'mtb_EndTimeQ
        '
        Me.mtb_EndTimeQ.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_EndTimeQ.BackColor = System.Drawing.Color.White
        Me.mtb_EndTimeQ.Location = New System.Drawing.Point(232, 3)
        Me.mtb_EndTimeQ.Mask = "90:00"
        Me.mtb_EndTimeQ.Name = "mtb_EndTimeQ"
        Me.mtb_EndTimeQ.Size = New System.Drawing.Size(47, 27)
        Me.mtb_EndTimeQ.TabIndex = 21
        Me.mtb_EndTimeQ.ValidatingType = GetType(Date)
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_QryStartDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.mtb_StartTimeQ)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(60, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(290, 33)
        Me.FlowLayoutPanel1.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "開始日期時間"
        '
        'dtp_QryStartDate
        '
        Me.dtp_QryStartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_QryStartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_QryStartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_QryStartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_QryStartDate.Location = New System.Drawing.Point(113, 3)
        Me.dtp_QryStartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_QryStartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_QryStartDate.Name = "dtp_QryStartDate"
        Me.dtp_QryStartDate.Size = New System.Drawing.Size(113, 27)
        Me.dtp_QryStartDate.TabIndex = 18
        Me.dtp_QryStartDate.uclReadOnly = False
        '
        'mtb_StartTimeQ
        '
        Me.mtb_StartTimeQ.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_StartTimeQ.BackColor = System.Drawing.Color.White
        Me.mtb_StartTimeQ.Location = New System.Drawing.Point(232, 3)
        Me.mtb_StartTimeQ.Mask = "90:00"
        Me.mtb_StartTimeQ.Name = "mtb_StartTimeQ"
        Me.mtb_StartTimeQ.Size = New System.Drawing.Size(47, 27)
        Me.mtb_StartTimeQ.TabIndex = 20
        Me.mtb_StartTimeQ.ValidatingType = GetType(Date)
        '
        'Btn_Query
        '
        Me.Btn_Query.Location = New System.Drawing.Point(783, 49)
        Me.Btn_Query.Name = "Btn_Query"
        Me.Btn_Query.Size = New System.Drawing.Size(75, 31)
        Me.Btn_Query.TabIndex = 16
        Me.Btn_Query.Text = "查詢"
        Me.Btn_Query.UseVisualStyleBackColor = True
        '
        'tcq_Employee
        '
        Me.tcq_Employee.doFlag = True
        Me.tcq_Employee.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_Employee.Location = New System.Drawing.Point(454, 50)
        Me.tcq_Employee.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_Employee.Name = "tcq_Employee"
        Me.tcq_Employee.Size = New System.Drawing.Size(183, 26)
        Me.tcq_Employee.TabIndex = 15
        Me.tcq_Employee.uclBaseDate = ""
        Me.tcq_Employee.uclCboWidth = 147
        Me.tcq_Employee.uclCodeName = ""
        Me.tcq_Employee.uclCodeName1 = ""
        Me.tcq_Employee.uclCodeName2 = ""
        Me.tcq_Employee.uclCodeValue = ""
        Me.tcq_Employee.uclCodeValue1 = ""
        Me.tcq_Employee.uclCodeValue2 = ""
        Me.tcq_Employee.uclConditionDate = ""
        Me.tcq_Employee.uclControlFlag = True
        Me.tcq_Employee.uclDeptCode = ""
        Me.tcq_Employee.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_Employee.uclDisplayIndex = "0,1"
        Me.tcq_Employee.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_Employee.uclIsAutoAddZero = False
        Me.tcq_Employee.uclIsBtnVisible = True
        Me.tcq_Employee.uclIsCheckDoctorOnDuty = False
        Me.tcq_Employee.uclIsCheckDrLicense = True
        Me.tcq_Employee.uclIsCheckTime = True
        Me.tcq_Employee.uclIsEnglishDept = False
        Me.tcq_Employee.uclIsReturnDS = False
        Me.tcq_Employee.uclIsShowMsgBox = True
        Me.tcq_Employee.uclIsTextAutoClear = True
        Me.tcq_Employee.uclLabel = ""
        Me.tcq_Employee.uclMsgValue = Nothing
        Me.tcq_Employee.uclNoDataOpenWindow = False
        Me.tcq_Employee.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_Employee.uclQueryField = Nothing
        Me.tcq_Employee.uclQueryValue = Nothing
        Me.tcq_Employee.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_Employee.uclRegionKind = ""
        Me.tcq_Employee.uclRoles = ""
        Me.tcq_Employee.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_Employee.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_Employee.uclTotalWidth = 8
        Me.tcq_Employee.uclXPosition = 225
        Me.tcq_Employee.uclYPosition = 120
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(367, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "發送對象："
        '
        'Txt_QueryNsg
        '
        Me.Txt_QueryNsg.Location = New System.Drawing.Point(709, 13)
        Me.Txt_QueryNsg.Name = "Txt_QueryNsg"
        Me.Txt_QueryNsg.Size = New System.Drawing.Size(151, 27)
        Me.Txt_QueryNsg.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(652, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "主旨："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "訊息狀態："
        '
        'Rdo_After
        '
        Me.Rdo_After.AutoSize = True
        Me.Rdo_After.Location = New System.Drawing.Point(590, 15)
        Me.Rdo_After.Name = "Rdo_After"
        Me.Rdo_After.Size = New System.Drawing.Size(58, 20)
        Me.Rdo_After.TabIndex = 10
        Me.Rdo_After.TabStop = True
        Me.Rdo_After.Text = "未來"
        Me.Rdo_After.UseVisualStyleBackColor = True
        '
        'Rdo_Now
        '
        Me.Rdo_Now.AutoSize = True
        Me.Rdo_Now.Location = New System.Drawing.Point(511, 15)
        Me.Rdo_Now.Name = "Rdo_Now"
        Me.Rdo_Now.Size = New System.Drawing.Size(74, 20)
        Me.Rdo_Now.TabIndex = 9
        Me.Rdo_Now.TabStop = True
        Me.Rdo_Now.Text = "效期內"
        Me.Rdo_Now.UseVisualStyleBackColor = True
        '
        'Rdo_Before
        '
        Me.Rdo_Before.AutoSize = True
        Me.Rdo_Before.Location = New System.Drawing.Point(456, 15)
        Me.Rdo_Before.Name = "Rdo_Before"
        Me.Rdo_Before.Size = New System.Drawing.Size(58, 20)
        Me.Rdo_Before.TabIndex = 8
        Me.Rdo_Before.TabStop = True
        Me.Rdo_Before.Text = "歷史"
        Me.Rdo_Before.UseVisualStyleBackColor = True
        '
        'btn_Send
        '
        Me.btn_Send.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Send.Location = New System.Drawing.Point(549, 276)
        Me.btn_Send.Name = "btn_Send"
        Me.btn_Send.Size = New System.Drawing.Size(67, 26)
        Me.btn_Send.TabIndex = 12
        Me.btn_Send.Text = "發送"
        Me.btn_Send.UseVisualStyleBackColor = True
        '
        'btn_SearchNodeText
        '
        Me.btn_SearchNodeText.Location = New System.Drawing.Point(880, 3)
        Me.btn_SearchNodeText.Name = "btn_SearchNodeText"
        Me.btn_SearchNodeText.Size = New System.Drawing.Size(56, 32)
        Me.btn_SearchNodeText.TabIndex = 23
        Me.btn_SearchNodeText.Text = "查詢"
        Me.btn_SearchNodeText.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(704, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 27)
        Me.TextBox1.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(658, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Tag = ""
        Me.Label4.Text = "姓名"
        '
        'UclTreeViewAdvUC1
        '
        Me.UclTreeViewAdvUC1.AutoScroll = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.UclTreeViewAdvUC1, 2)
        Me.UclTreeViewAdvUC1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclTreeViewAdvUC1.IsShowGroupCheckBox = False
        Me.UclTreeViewAdvUC1.Location = New System.Drawing.Point(705, 88)
        Me.UclTreeViewAdvUC1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclTreeViewAdvUC1.Name = "UclTreeViewAdvUC1"
        Me.TableLayoutPanel1.SetRowSpan(Me.UclTreeViewAdvUC1, 3)
        Me.UclTreeViewAdvUC1.SelectedItemsResult = Nothing
        Me.UclTreeViewAdvUC1.SelectedResult = Nothing
        Me.UclTreeViewAdvUC1.SelectedTempItemsResult = Nothing
        Me.UclTreeViewAdvUC1.Size = New System.Drawing.Size(255, 213)
        Me.UclTreeViewAdvUC1.TabIndex = 22
        Me.UclTreeViewAdvUC1.TreeViewName = ""
        Me.UclTreeViewAdvUC1.TreeViewSource = Nothing
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.Rdo_H)
        Me.GroupBox1.Controls.Add(Me.rdo_G)
        Me.GroupBox1.Controls.Add(Me.rdo_D)
        Me.GroupBox1.Controls.Add(Me.rdo_P)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(704, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 40)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'Rdo_H
        '
        Me.Rdo_H.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Rdo_H.AutoSize = True
        Me.Rdo_H.Location = New System.Drawing.Point(193, 14)
        Me.Rdo_H.Name = "Rdo_H"
        Me.Rdo_H.Size = New System.Drawing.Size(58, 20)
        Me.Rdo_H.TabIndex = 3
        Me.Rdo_H.TabStop = True
        Me.Rdo_H.Text = "全院"
        Me.Rdo_H.UseVisualStyleBackColor = True
        '
        'rdo_G
        '
        Me.rdo_G.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_G.AutoSize = True
        Me.rdo_G.Location = New System.Drawing.Point(130, 14)
        Me.rdo_G.Name = "rdo_G"
        Me.rdo_G.Size = New System.Drawing.Size(58, 20)
        Me.rdo_G.TabIndex = 2
        Me.rdo_G.TabStop = True
        Me.rdo_G.Text = "群組"
        Me.rdo_G.UseVisualStyleBackColor = True
        '
        'rdo_D
        '
        Me.rdo_D.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_D.AutoSize = True
        Me.rdo_D.Location = New System.Drawing.Point(67, 14)
        Me.rdo_D.Name = "rdo_D"
        Me.rdo_D.Size = New System.Drawing.Size(58, 20)
        Me.rdo_D.TabIndex = 1
        Me.rdo_D.TabStop = True
        Me.rdo_D.Text = "科室"
        Me.rdo_D.UseVisualStyleBackColor = True
        '
        'rdo_P
        '
        Me.rdo_P.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_P.AutoSize = True
        Me.rdo_P.Location = New System.Drawing.Point(6, 14)
        Me.rdo_P.Name = "rdo_P"
        Me.rdo_P.Size = New System.Drawing.Size(58, 20)
        Me.rdo_P.TabIndex = 0
        Me.rdo_P.TabStop = True
        Me.rdo_P.Text = "個人"
        Me.rdo_P.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "開始日期時間"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "結束日期時間"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 130
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "主旨"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 140
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "訊息內容"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 240
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "發送日期"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 140
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "發送對象"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 380
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "發送日期時間"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "發送對象"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'NFCDataSender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "NFCDataSender"
        Me.TabText = "NFCDataSender"
        Me.Text = "NFCDataSender"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Query.ResumeLayout(False)
        Me.Grp_Query.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_StartDate As System.Windows.Forms.Label
    Friend WithEvents lbl_StartTime As System.Windows.Forms.Label
    Friend WithEvents mtb_StartTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_EndDate As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_EndTime As System.Windows.Forms.Label
    Friend WithEvents mtb_EndTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_Subject As System.Windows.Forms.Label
    Friend WithEvents txt_Subject As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Msg As System.Windows.Forms.Label
    Friend WithEvents rtb_Msg As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_Send As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chk_Mail As System.Windows.Forms.CheckBox
    Friend WithEvents chk_SMS As System.Windows.Forms.CheckBox
    Friend WithEvents chk_windows As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UclTreeViewAdvUC1 As Syscom.Client.UCL.UCLTreeViewAdvUC
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_SearchNodeText As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_G As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_D As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_P As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_H As System.Windows.Forms.RadioButton
    Friend WithEvents Grp_Query As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_QueryNsg As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Rdo_After As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_Now As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_Before As System.Windows.Forms.RadioButton
    Friend WithEvents tcq_Employee As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Btn_Query As System.Windows.Forms.Button
    Friend WithEvents chk_Spec_Flag As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_QryEndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents mtb_EndTimeQ As System.Windows.Forms.MaskedTextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_QryStartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents mtb_StartTimeQ As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
