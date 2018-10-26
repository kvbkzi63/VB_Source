<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobEmployeeMaintainUI
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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobEmployeeMaintainUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtp_Assume_End_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Employee_Name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Employee_Code = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.dtp_Assume_Effect_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_EMail = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cbo_Role = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_Tel_Mobile = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Level = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Employee_En_Name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_ShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 304.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_Assume_End_Date, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Employee_Name, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Employee_Code, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_Assume_Effect_Date, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_EMail, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Role, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Tel_Mobile, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Level, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Employee_En_Name, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 105)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtp_Assume_End_Date
        '
        Me.dtp_Assume_End_Date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_Assume_End_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Assume_End_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Assume_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_Assume_End_Date.Location = New System.Drawing.Point(294, 36)
        Me.dtp_Assume_End_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Assume_End_Date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Assume_End_Date.Name = "dtp_Assume_End_Date"
        Me.dtp_Assume_End_Date.Size = New System.Drawing.Size(129, 30)
        Me.dtp_Assume_End_Date.TabIndex = 9
        Me.dtp_Assume_End_Date.uclIsFixedBackColor = False
        Me.dtp_Assume_End_Date.uclReadOnly = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "離職日"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "到職日"
        '
        'txt_Employee_Name
        '
        Me.txt_Employee_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Employee_Name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Employee_Name.Location = New System.Drawing.Point(294, 3)
        Me.txt_Employee_Name.MaxLength = 10
        Me.txt_Employee_Name.Name = "txt_Employee_Name"
        Me.txt_Employee_Name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Employee_Name.SelectionStart = 0
        Me.txt_Employee_Name.Size = New System.Drawing.Size(129, 27)
        Me.txt_Employee_Name.TabIndex = 3
        Me.txt_Employee_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Employee_Name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Employee_Name.ToolTipTag = Nothing
        Me.txt_Employee_Name.uclDollarSign = False
        Me.txt_Employee_Name.uclDotCount = 0
        Me.txt_Employee_Name.uclIntCount = 2
        Me.txt_Employee_Name.uclMinus = False
        Me.txt_Employee_Name.uclReadOnly = False
        Me.txt_Employee_Name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Employee_Name.uclTrimZero = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "員工編號"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "員工姓名"
        '
        'txt_Employee_Code
        '
        Me.txt_Employee_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Employee_Code.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Employee_Code.Location = New System.Drawing.Point(81, 3)
        Me.txt_Employee_Code.MaxLength = 10
        Me.txt_Employee_Code.Name = "txt_Employee_Code"
        Me.txt_Employee_Code.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Employee_Code.SelectionStart = 0
        Me.txt_Employee_Code.Size = New System.Drawing.Size(129, 27)
        Me.txt_Employee_Code.TabIndex = 2
        Me.txt_Employee_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Employee_Code.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Employee_Code.ToolTipTag = Nothing
        Me.txt_Employee_Code.uclDollarSign = False
        Me.txt_Employee_Code.uclDotCount = 0
        Me.txt_Employee_Code.uclIntCount = 2
        Me.txt_Employee_Code.uclMinus = False
        Me.txt_Employee_Code.uclReadOnly = False
        Me.txt_Employee_Code.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Employee_Code.uclTrimZero = True
        '
        'dtp_Assume_Effect_Date
        '
        Me.dtp_Assume_Effect_Date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_Assume_Effect_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Assume_Effect_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Assume_Effect_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_Assume_Effect_Date.Location = New System.Drawing.Point(81, 36)
        Me.dtp_Assume_Effect_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Assume_Effect_Date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Assume_Effect_Date.Name = "dtp_Assume_Effect_Date"
        Me.dtp_Assume_Effect_Date.Size = New System.Drawing.Size(129, 30)
        Me.dtp_Assume_Effect_Date.TabIndex = 7
        Me.dtp_Assume_Effect_Date.uclIsFixedBackColor = False
        Me.dtp_Assume_Effect_Date.uclReadOnly = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(238, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "E-Mail"
        '
        'txt_EMail
        '
        Me.txt_EMail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_EMail, 3)
        Me.txt_EMail.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_EMail.Location = New System.Drawing.Point(294, 74)
        Me.txt_EMail.MaxLength = 50
        Me.txt_EMail.Name = "txt_EMail"
        Me.txt_EMail.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_EMail.SelectionStart = 0
        Me.txt_EMail.Size = New System.Drawing.Size(347, 26)
        Me.txt_EMail.TabIndex = 13
        Me.txt_EMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_EMail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_EMail.ToolTipTag = Nothing
        Me.txt_EMail.uclDollarSign = False
        Me.txt_EMail.uclDotCount = 0
        Me.txt_EMail.uclIntCount = 2
        Me.txt_EMail.uclMinus = False
        Me.txt_EMail.uclReadOnly = False
        Me.txt_EMail.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_EMail.uclTrimZero = True
        '
        'cbo_Role
        '
        Me.cbo_Role.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Role.DropDownWidth = 20
        Me.cbo_Role.DroppedDown = False
        Me.cbo_Role.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Role.Location = New System.Drawing.Point(698, 41)
        Me.cbo_Role.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Role.Name = "cbo_Role"
        Me.cbo_Role.SelectedIndex = -1
        Me.cbo_Role.SelectedItem = Nothing
        Me.cbo_Role.SelectedText = ""
        Me.cbo_Role.SelectedValue = ""
        Me.cbo_Role.SelectionStart = 0
        Me.cbo_Role.Size = New System.Drawing.Size(125, 20)
        Me.cbo_Role.TabIndex = 15
        Me.cbo_Role.uclDisplayIndex = "0,1"
        Me.cbo_Role.uclIsAutoClear = True
        Me.cbo_Role.uclIsFirstItemEmpty = True
        Me.cbo_Role.uclIsTextMode = False
        Me.cbo_Role.uclShowMsg = False
        Me.cbo_Role.uclValueIndex = "0"
        '
        'txt_Tel_Mobile
        '
        Me.txt_Tel_Mobile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Tel_Mobile.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Tel_Mobile.Location = New System.Drawing.Point(81, 74)
        Me.txt_Tel_Mobile.MaxLength = 10
        Me.txt_Tel_Mobile.Name = "txt_Tel_Mobile"
        Me.txt_Tel_Mobile.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Tel_Mobile.SelectionStart = 0
        Me.txt_Tel_Mobile.Size = New System.Drawing.Size(129, 26)
        Me.txt_Tel_Mobile.TabIndex = 12
        Me.txt_Tel_Mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Tel_Mobile.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Tel_Mobile.ToolTipTag = Nothing
        Me.txt_Tel_Mobile.uclDollarSign = False
        Me.txt_Tel_Mobile.uclDotCount = 0
        Me.txt_Tel_Mobile.uclIntCount = 2
        Me.txt_Tel_Mobile.uclMinus = False
        Me.txt_Tel_Mobile.uclReadOnly = False
        Me.txt_Tel_Mobile.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Tel_Mobile.uclTrimZero = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "手機號碼"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(655, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "角色"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(461, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "職級"
        '
        'cbo_Level
        '
        Me.cbo_Level.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Level.DropDownWidth = 20
        Me.cbo_Level.DroppedDown = False
        Me.cbo_Level.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Level.Location = New System.Drawing.Point(504, 42)
        Me.cbo_Level.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Level.Name = "cbo_Level"
        Me.cbo_Level.SelectedIndex = -1
        Me.cbo_Level.SelectedItem = Nothing
        Me.cbo_Level.SelectedText = ""
        Me.cbo_Level.SelectedValue = ""
        Me.cbo_Level.SelectionStart = 0
        Me.cbo_Level.Size = New System.Drawing.Size(125, 18)
        Me.cbo_Level.TabIndex = 5
        Me.cbo_Level.uclDisplayIndex = "0,1"
        Me.cbo_Level.uclIsAutoClear = True
        Me.cbo_Level.uclIsFirstItemEmpty = True
        Me.cbo_Level.uclIsTextMode = False
        Me.cbo_Level.uclShowMsg = False
        Me.cbo_Level.uclValueIndex = "0"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(429, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "英文名稱"
        '
        'txt_Employee_En_Name
        '
        Me.txt_Employee_En_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Employee_En_Name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Employee_En_Name.Location = New System.Drawing.Point(507, 3)
        Me.txt_Employee_En_Name.MaxLength = 10
        Me.txt_Employee_En_Name.Name = "txt_Employee_En_Name"
        Me.txt_Employee_En_Name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Employee_En_Name.SelectionStart = 0
        Me.txt_Employee_En_Name.Size = New System.Drawing.Size(129, 27)
        Me.txt_Employee_En_Name.TabIndex = 17
        Me.txt_Employee_En_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Employee_En_Name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Employee_En_Name.ToolTipTag = Nothing
        Me.txt_Employee_En_Name.uclDollarSign = False
        Me.txt_Employee_En_Name.uclDotCount = 0
        Me.txt_Employee_En_Name.uclIntCount = 2
        Me.txt_Employee_En_Name.uclMinus = False
        Me.txt_Employee_En_Name.uclReadOnly = False
        Me.txt_Employee_En_Name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Employee_En_Name.uclTrimZero = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Update)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Insert)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 105)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(964, 33)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(865, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(96, 27)
        Me.btn_Clear.TabIndex = 0
        Me.btn_Clear.Text = "清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(763, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(96, 27)
        Me.btn_Delete.TabIndex = 1
        Me.btn_Delete.Text = "刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Update
        '
        Me.btn_Update.Location = New System.Drawing.Point(661, 3)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(96, 27)
        Me.btn_Update.TabIndex = 2
        Me.btn_Update.Text = "修改"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_Insert
        '
        Me.btn_Insert.Location = New System.Drawing.Point(559, 3)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(96, 27)
        Me.btn_Insert.TabIndex = 3
        Me.btn_Insert.Text = "新增"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(457, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(96, 27)
        Me.btn_Query.TabIndex = 4
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgv_ShowData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 138)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 504)
        Me.Panel1.TabIndex = 2
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
        Me.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_ShowData.Location = New System.Drawing.Point(0, 0)
        Me.dgv_ShowData.MultiSelect = False
        Me.dgv_ShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_ShowData.Name = "dgv_ShowData"
        Me.dgv_ShowData.RowHeadersWidth = 41
        Me.dgv_ShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_ShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ShowData.Size = New System.Drawing.Size(964, 504)
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
        Me.dgv_ShowData.uclIsComboxClickTriggerDropDown = False
        Me.dgv_ShowData.uclIsDoOrderCheck = True
        Me.dgv_ShowData.uclIsDoQueryComboBoxGrid = True
        Me.dgv_ShowData.uclIsSortable = False
        Me.dgv_ShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_ShowData.uclNonVisibleColIndex = ""
        Me.dgv_ShowData.uclReadOnly = False
        Me.dgv_ShowData.uclShowCellBorder = False
        Me.dgv_ShowData.uclSortColIndex = ""
        Me.dgv_ShowData.uclTreeMode = False
        Me.dgv_ShowData.uclVisibleColIndex = ""
        '
        'JobEmployeeMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "JobEmployeeMaintainUI"
        Me.TabText = "JobEmployeeMaintainUI"
        Me.Text = "JobEmployeeMaintainUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_Assume_End_Date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txt_Employee_Name As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_Employee_Code As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_Level As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents dtp_Assume_Effect_Date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As Windows.Forms.Button
    Friend WithEvents btn_Delete As Windows.Forms.Button
    Friend WithEvents btn_Update As Windows.Forms.Button
    Friend WithEvents btn_Insert As Windows.Forms.Button
    Friend WithEvents btn_Query As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents dgv_ShowData As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents cbo_Role As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents txt_Tel_Mobile As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_EMail As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txt_Employee_En_Name As Syscom.Client.UCL.UCLTextBoxUC
End Class
