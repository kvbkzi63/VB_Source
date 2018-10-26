<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobPGSubmitUI
    Inherits Syscom.Client.UCL.BaseFormUI


    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobPGSubmitUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbk_UploadFTP = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_System = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_PGName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Level = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtb_desc = New System.Windows.Forms.RichTextBox()
        Me.btn_Folder = New System.Windows.Forms.Button()
        Me.txt_Folder = New System.Windows.Forms.TextBox()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.txt_Function = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Ver = New System.Windows.Forms.TextBox()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Upload = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtp_AssignDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.cbo_Classify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.SelectFile = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_Path = New System.Windows.Forms.DataGridView()
        Me.SelectColumns = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_Excel = New System.Windows.Forms.DataGridView()
        Me.選 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.系統別 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.提出日 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.歸屬功能 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.問題類別 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.優先等級 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.問題描述 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_SelectPic = New System.Windows.Forms.Button()
        Me.btn_ClearPic = New System.Windows.Forms.Button()
        Me.dgv_SelectPic = New System.Windows.Forms.DataGridView()
        Me.D = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PicPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_FTPAddress = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_FTPLoginUser = New System.Windows.Forms.TextBox()
        Me.txt_FTPLoginPassWord = New System.Windows.Forms.TextBox()
        Me.cbo_FTPFolder = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgv_Path, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.dgv_SelectPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_System, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_PGName, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Level, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_desc, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Folder, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Folder, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Add, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Insert, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Function, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Ver, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Delete, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Upload, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_AssignDate, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Classify, 3, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(994, 144)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.cbk_UploadFTP)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(676, 108)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(183, 32)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'cbk_UploadFTP
        '
        Me.cbk_UploadFTP.AutoSize = True
        Me.cbk_UploadFTP.Checked = True
        Me.cbk_UploadFTP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbk_UploadFTP.Location = New System.Drawing.Point(3, 3)
        Me.cbk_UploadFTP.Name = "cbk_UploadFTP"
        Me.cbk_UploadFTP.Size = New System.Drawing.Size(84, 20)
        Me.cbk_UploadFTP.TabIndex = 25
        Me.cbk_UploadFTP.Text = "上傳FTP"
        Me.cbk_UploadFTP.UseVisualStyleBackColor = True
        Me.cbk_UploadFTP.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "提出日"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "系統別"
        '
        'txt_System
        '
        Me.txt_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_System.Enabled = False
        Me.txt_System.Location = New System.Drawing.Point(81, 11)
        Me.txt_System.Name = "txt_System"
        Me.txt_System.Size = New System.Drawing.Size(130, 27)
        Me.txt_System.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(235, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "提交者"
        '
        'txt_PGName
        '
        Me.txt_PGName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_PGName.Enabled = False
        Me.txt_PGName.Location = New System.Drawing.Point(297, 11)
        Me.txt_PGName.Name = "txt_PGName"
        Me.txt_PGName.Size = New System.Drawing.Size(122, 27)
        Me.txt_PGName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "歸屬功能"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "優先等級"
        '
        'txt_Level
        '
        Me.txt_Level.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Level.Location = New System.Drawing.Point(297, 64)
        Me.txt_Level.Name = "txt_Level"
        Me.txt_Level.Size = New System.Drawing.Size(122, 27)
        Me.txt_Level.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(219, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "問題類別"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(425, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "問題描述"
        '
        'rtb_desc
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.rtb_desc, 2)
        Me.rtb_desc.Location = New System.Drawing.Point(503, 3)
        Me.rtb_desc.Name = "rtb_desc"
        Me.TableLayoutPanel1.SetRowSpan(Me.rtb_desc, 2)
        Me.rtb_desc.Size = New System.Drawing.Size(167, 99)
        Me.rtb_desc.TabIndex = 16
        Me.rtb_desc.Text = ""
        '
        'btn_Folder
        '
        Me.btn_Folder.Location = New System.Drawing.Point(676, 3)
        Me.btn_Folder.Name = "btn_Folder"
        Me.btn_Folder.Size = New System.Drawing.Size(130, 44)
        Me.btn_Folder.TabIndex = 19
        Me.btn_Folder.Text = "選擇存放路徑"
        Me.btn_Folder.UseVisualStyleBackColor = True
        '
        'txt_Folder
        '
        Me.txt_Folder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Folder.Enabled = False
        Me.txt_Folder.Location = New System.Drawing.Point(676, 64)
        Me.txt_Folder.Name = "txt_Folder"
        Me.txt_Folder.Size = New System.Drawing.Size(183, 27)
        Me.txt_Folder.TabIndex = 20
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(865, 3)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(48, 44)
        Me.btn_Add.TabIndex = 5
        Me.btn_Add.Text = "選擇檔案"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'btn_Insert
        '
        Me.btn_Insert.Location = New System.Drawing.Point(865, 53)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(48, 44)
        Me.btn_Insert.TabIndex = 18
        Me.btn_Insert.Text = "新增描述"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'txt_Function
        '
        Me.txt_Function.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Function.Enabled = False
        Me.txt_Function.Location = New System.Drawing.Point(81, 112)
        Me.txt_Function.Name = "txt_Function"
        Me.txt_Function.Size = New System.Drawing.Size(130, 27)
        Me.txt_Function.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(457, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "版次"
        '
        'txt_Ver
        '
        Me.txt_Ver.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Ver.Location = New System.Drawing.Point(503, 112)
        Me.txt_Ver.Name = "txt_Ver"
        Me.txt_Ver.Size = New System.Drawing.Size(130, 27)
        Me.txt_Ver.TabIndex = 23
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(919, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(48, 44)
        Me.btn_Delete.TabIndex = 4
        Me.btn_Delete.Text = "刪除選取"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Upload
        '
        Me.btn_Upload.Enabled = False
        Me.btn_Upload.Location = New System.Drawing.Point(919, 53)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(48, 44)
        Me.btn_Upload.TabIndex = 6
        Me.btn_Upload.Text = "提交"
        Me.btn_Upload.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(865, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 35)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "清除"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtp_AssignDate
        '
        Me.dtp_AssignDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_AssignDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_AssignDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_AssignDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_AssignDate.Location = New System.Drawing.Point(81, 64)
        Me.dtp_AssignDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_AssignDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_AssignDate.Name = "dtp_AssignDate"
        Me.dtp_AssignDate.Size = New System.Drawing.Size(132, 27)
        Me.dtp_AssignDate.TabIndex = 25
        Me.dtp_AssignDate.uclIsFixedBackColor = False
        Me.dtp_AssignDate.uclReadOnly = False
        '
        'cbo_Classify
        '
        Me.cbo_Classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Classify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Classify.DropDownWidth = 20
        Me.cbo_Classify.DroppedDown = False
        Me.cbo_Classify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Classify.Location = New System.Drawing.Point(294, 115)
        Me.cbo_Classify.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Classify.Name = "cbo_Classify"
        Me.cbo_Classify.SelectedIndex = -1
        Me.cbo_Classify.SelectedItem = Nothing
        Me.cbo_Classify.SelectedText = ""
        Me.cbo_Classify.SelectedValue = ""
        Me.cbo_Classify.SelectionStart = 0
        Me.cbo_Classify.Size = New System.Drawing.Size(125, 20)
        Me.cbo_Classify.TabIndex = 26
        Me.cbo_Classify.uclDisplayIndex = "0,1"
        Me.cbo_Classify.uclIsAutoClear = True
        Me.cbo_Classify.uclIsFirstItemEmpty = True
        Me.cbo_Classify.uclIsTextMode = False
        Me.cbo_Classify.uclShowMsg = False
        Me.cbo_Classify.uclValueIndex = "0"
        '
        'SelectFile
        '
        Me.SelectFile.FileName = "OpenFileDialog1"
        Me.SelectFile.Multiselect = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 150)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(991, 412)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(983, 382)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "提交明細"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.53061!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.46939!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_Path, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_Excel, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(980, 377)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'dgv_Path
        '
        Me.dgv_Path.AllowUserToAddRows = False
        Me.dgv_Path.AllowUserToDeleteRows = False
        Me.dgv_Path.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Path.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Path.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectColumns, Me.FilePath})
        Me.dgv_Path.Location = New System.Drawing.Point(458, 3)
        Me.dgv_Path.Name = "dgv_Path"
        Me.dgv_Path.RowTemplate.Height = 24
        Me.dgv_Path.Size = New System.Drawing.Size(518, 371)
        Me.dgv_Path.TabIndex = 3
        '
        'SelectColumns
        '
        Me.SelectColumns.HeaderText = "選"
        Me.SelectColumns.Name = "SelectColumns"
        Me.SelectColumns.Width = 30
        '
        'FilePath
        '
        Me.FilePath.HeaderText = "路徑"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.Width = 65
        '
        'dgv_Excel
        '
        Me.dgv_Excel.AllowUserToAddRows = False
        Me.dgv_Excel.AllowUserToDeleteRows = False
        Me.dgv_Excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Excel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.選, Me.系統別, Me.提出日, Me.歸屬功能, Me.問題類別, Me.優先等級, Me.問題描述})
        Me.dgv_Excel.Location = New System.Drawing.Point(3, 3)
        Me.dgv_Excel.Name = "dgv_Excel"
        Me.dgv_Excel.ReadOnly = True
        Me.dgv_Excel.RowTemplate.Height = 24
        Me.dgv_Excel.Size = New System.Drawing.Size(449, 369)
        Me.dgv_Excel.TabIndex = 2
        '
        '選
        '
        Me.選.HeaderText = "選"
        Me.選.Name = "選"
        Me.選.ReadOnly = True
        Me.選.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.選.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.選.Width = 49
        '
        '系統別
        '
        Me.系統別.HeaderText = "系統別"
        Me.系統別.Name = "系統別"
        Me.系統別.ReadOnly = True
        Me.系統別.Width = 81
        '
        '提出日
        '
        Me.提出日.HeaderText = "提出日"
        Me.提出日.Name = "提出日"
        Me.提出日.ReadOnly = True
        Me.提出日.Width = 81
        '
        '歸屬功能
        '
        Me.歸屬功能.HeaderText = "歸屬功能"
        Me.歸屬功能.Name = "歸屬功能"
        Me.歸屬功能.ReadOnly = True
        Me.歸屬功能.Width = 97
        '
        '問題類別
        '
        Me.問題類別.HeaderText = "問題類別"
        Me.問題類別.Name = "問題類別"
        Me.問題類別.ReadOnly = True
        Me.問題類別.Width = 97
        '
        '優先等級
        '
        Me.優先等級.HeaderText = "優先等級"
        Me.優先等級.Name = "優先等級"
        Me.優先等級.ReadOnly = True
        Me.優先等級.Width = 97
        '
        '問題描述
        '
        Me.問題描述.HeaderText = "問題描述"
        Me.問題描述.Name = "問題描述"
        Me.問題描述.ReadOnly = True
        Me.問題描述.Width = 97
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPage2.Controls.Add(Me.dgv_SelectPic)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(983, 382)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "夾帶圖片"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_SelectPic)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_ClearPic)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(983, 40)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'btn_SelectPic
        '
        Me.btn_SelectPic.Location = New System.Drawing.Point(3, 3)
        Me.btn_SelectPic.Name = "btn_SelectPic"
        Me.btn_SelectPic.Size = New System.Drawing.Size(100, 30)
        Me.btn_SelectPic.TabIndex = 6
        Me.btn_SelectPic.Text = "插入圖片"
        Me.btn_SelectPic.UseVisualStyleBackColor = True
        '
        'btn_ClearPic
        '
        Me.btn_ClearPic.Location = New System.Drawing.Point(109, 3)
        Me.btn_ClearPic.Name = "btn_ClearPic"
        Me.btn_ClearPic.Size = New System.Drawing.Size(100, 30)
        Me.btn_ClearPic.TabIndex = 25
        Me.btn_ClearPic.Text = "清除圖片"
        Me.btn_ClearPic.UseVisualStyleBackColor = True
        '
        'dgv_SelectPic
        '
        Me.dgv_SelectPic.AllowUserToAddRows = False
        Me.dgv_SelectPic.AllowUserToDeleteRows = False
        Me.dgv_SelectPic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_SelectPic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SelectPic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.D, Me.PicPath})
        Me.dgv_SelectPic.Location = New System.Drawing.Point(0, 39)
        Me.dgv_SelectPic.Name = "dgv_SelectPic"
        Me.dgv_SelectPic.RowTemplate.Height = 24
        Me.dgv_SelectPic.Size = New System.Drawing.Size(980, 340)
        Me.dgv_SelectPic.TabIndex = 26
        '
        'D
        '
        Me.D.HeaderText = "選"
        Me.D.Name = "D"
        Me.D.Width = 30
        '
        'PicPath
        '
        Me.PicPath.HeaderText = "路徑"
        Me.PicPath.Name = "PicPath"
        Me.PicPath.Width = 65
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(983, 382)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "FTP設定"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.txt_FTPAddress, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label14, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_FTPLoginUser, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txt_FTPLoginPassWord, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_FTPFolder, 1, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(983, 85)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'txt_FTPAddress
        '
        Me.txt_FTPAddress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FTPAddress.Location = New System.Drawing.Point(203, 7)
        Me.txt_FTPAddress.Name = "txt_FTPAddress"
        Me.txt_FTPAddress.Size = New System.Drawing.Size(267, 27)
        Me.txt_FTPAddress.TabIndex = 3
        Me.txt_FTPAddress.Text = "ftp://192.168.20.3/"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(109, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "伺服器位置"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(194, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "上傳目錄名稱(預設根目錄)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(476, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "登錄帳號"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(476, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "登陸密碼"
        '
        'txt_FTPLoginUser
        '
        Me.txt_FTPLoginUser.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FTPLoginUser.Location = New System.Drawing.Point(554, 7)
        Me.txt_FTPLoginUser.Name = "txt_FTPLoginUser"
        Me.txt_FTPLoginUser.Size = New System.Drawing.Size(130, 27)
        Me.txt_FTPLoginUser.TabIndex = 7
        Me.txt_FTPLoginUser.Text = "deploy"
        '
        'txt_FTPLoginPassWord
        '
        Me.txt_FTPLoginPassWord.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FTPLoginPassWord.Location = New System.Drawing.Point(554, 50)
        Me.txt_FTPLoginPassWord.Name = "txt_FTPLoginPassWord"
        Me.txt_FTPLoginPassWord.Size = New System.Drawing.Size(130, 27)
        Me.txt_FTPLoginPassWord.TabIndex = 8
        Me.txt_FTPLoginPassWord.Text = "syscom@123"
        '
        'cbo_FTPFolder
        '
        Me.cbo_FTPFolder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_FTPFolder.FormattingEnabled = True
        Me.cbo_FTPFolder.Location = New System.Drawing.Point(203, 51)
        Me.cbo_FTPFolder.Name = "cbo_FTPFolder"
        Me.cbo_FTPFolder.Size = New System.Drawing.Size(267, 24)
        Me.cbo_FTPFolder.TabIndex = 9
        '
        'JobPGSubmitUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 573)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "JobPGSubmitUI"
        Me.TabText = "PG提交小工具"
        Me.Text = "程式上傳作業"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgv_Path, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.dgv_SelectPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_PGName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_System As Windows.Forms.TextBox
    Friend WithEvents SelectFile As Windows.Forms.OpenFileDialog
    Friend WithEvents btn_Add As Windows.Forms.Button
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txt_Level As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txt_Function As Windows.Forms.TextBox
    Friend WithEvents rtb_desc As Windows.Forms.RichTextBox
    Friend WithEvents btn_Insert As Windows.Forms.Button
    Friend WithEvents btn_Folder As Windows.Forms.Button
    Friend WithEvents txt_Folder As Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents txt_Ver As Windows.Forms.TextBox
    Friend WithEvents btn_Delete As Windows.Forms.Button
    Friend WithEvents btn_Upload As Windows.Forms.Button
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_Path As Windows.Forms.DataGridView
    Friend WithEvents SelectColumns As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FilePath As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_Excel As Windows.Forms.DataGridView
    Friend WithEvents 選 As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents 系統別 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 提出日 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 歸屬功能 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 問題類別 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 優先等級 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 問題描述 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel4 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents txt_FTPAddress As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents txt_FTPLoginUser As Windows.Forms.TextBox
    Friend WithEvents txt_FTPLoginPassWord As Windows.Forms.TextBox
    Friend WithEvents cbk_UploadFTP As Windows.Forms.CheckBox
    Friend WithEvents cbo_FTPFolder As Windows.Forms.ComboBox
    Friend WithEvents dtp_AssignDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cbo_Classify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_SelectPic As Windows.Forms.Button
    Friend WithEvents btn_ClearPic As Windows.Forms.Button
    Friend WithEvents dgv_SelectPic As Windows.Forms.DataGridView
    Friend WithEvents D As Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PicPath As Windows.Forms.DataGridViewTextBoxColumn
End Class
