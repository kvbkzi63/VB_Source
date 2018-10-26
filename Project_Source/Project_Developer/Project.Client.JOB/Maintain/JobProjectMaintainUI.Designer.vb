<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobProjectMaintainUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobProjectMaintainUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_ProjectName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_ProjectID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.cbo_PM = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_ImportFunctionList = New System.Windows.Forms.Button()
        Me.ckb_IsClose = New System.Windows.Forms.CheckBox()
        Me.cbo_ProjectStatus = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgv_ProjectList = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_System = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_SystemName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_SystemCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_InsertNewProjectSystem = New System.Windows.Forms.Button()
        Me.btn_UpdateProjectSystem = New System.Windows.Forms.Button()
        Me.btn_DeleteProjectSystem = New System.Windows.Forms.Button()
        Me.cbo_SA = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_Function = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_FunctionCode = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_InsertNewSystemFunction = New System.Windows.Forms.Button()
        Me.btn_UpdateSystemFunction = New System.Windows.Forms.Button()
        Me.btn_DeleteSystemFunction = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_FunctionName = New System.Windows.Forms.TextBox()
        Me.ckb_Dc = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_QueryProject = New System.Windows.Forms.Button()
        Me.btn_InsertNewProject = New System.Windows.Forms.Button()
        Me.btn_UpdateProject = New System.Windows.Forms.Button()
        Me.btn_DeleteProject = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv_ProjectList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_System, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_Function, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 431.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txt_ProjectName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_ProjectID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_StartDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_PM, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_ImportFunctionList, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ckb_IsClose, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_ProjectStatus, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(944, 72)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txt_ProjectName
        '
        Me.txt_ProjectName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ProjectName.Location = New System.Drawing.Point(81, 40)
        Me.txt_ProjectName.MaxLength = 20
        Me.txt_ProjectName.Name = "txt_ProjectName"
        Me.txt_ProjectName.Size = New System.Drawing.Size(100, 27)
        Me.txt_ProjectName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "專案代號"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "專案名稱"
        '
        'txt_ProjectID
        '
        Me.txt_ProjectID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ProjectID.Location = New System.Drawing.Point(81, 4)
        Me.txt_ProjectID.Name = "txt_ProjectID"
        Me.txt_ProjectID.Size = New System.Drawing.Size(100, 27)
        Me.txt_ProjectID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(187, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "專案起日"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(198, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "專案PM"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.Location = New System.Drawing.Point(265, 4)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(156, 27)
        Me.dtp_StartDate.TabIndex = 6
        '
        'cbo_PM
        '
        Me.cbo_PM.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_PM.FormattingEnabled = True
        Me.cbo_PM.Location = New System.Drawing.Point(265, 44)
        Me.cbo_PM.Name = "cbo_PM"
        Me.cbo_PM.Size = New System.Drawing.Size(156, 24)
        Me.cbo_PM.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(476, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "專案狀態"
        '
        'btn_ImportFunctionList
        '
        Me.btn_ImportFunctionList.Location = New System.Drawing.Point(427, 39)
        Me.btn_ImportFunctionList.Name = "btn_ImportFunctionList"
        Me.btn_ImportFunctionList.Size = New System.Drawing.Size(121, 29)
        Me.btn_ImportFunctionList.TabIndex = 9
        Me.btn_ImportFunctionList.Text = "匯入功能清單"
        Me.btn_ImportFunctionList.UseVisualStyleBackColor = True
        '
        'ckb_IsClose
        '
        Me.ckb_IsClose.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_IsClose.AutoSize = True
        Me.ckb_IsClose.Location = New System.Drawing.Point(554, 44)
        Me.ckb_IsClose.Name = "ckb_IsClose"
        Me.ckb_IsClose.Size = New System.Drawing.Size(137, 20)
        Me.ckb_IsClose.TabIndex = 8
        Me.ckb_IsClose.Text = "專案(中止/結束)"
        Me.ckb_IsClose.UseVisualStyleBackColor = True
        '
        'cbo_ProjectStatus
        '
        Me.cbo_ProjectStatus.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_ProjectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_ProjectStatus.DropDownWidth = 20
        Me.cbo_ProjectStatus.DroppedDown = False
        Me.cbo_ProjectStatus.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_ProjectStatus.Location = New System.Drawing.Point(551, 6)
        Me.cbo_ProjectStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_ProjectStatus.MaxLength = 50
        Me.cbo_ProjectStatus.Name = "cbo_ProjectStatus"
        Me.cbo_ProjectStatus.SelectedIndex = -1
        Me.cbo_ProjectStatus.SelectedItem = Nothing
        Me.cbo_ProjectStatus.SelectedText = ""
        Me.cbo_ProjectStatus.SelectedValue = ""
        Me.cbo_ProjectStatus.SelectionStart = 0
        Me.cbo_ProjectStatus.Size = New System.Drawing.Size(156, 24)
        Me.cbo_ProjectStatus.TabIndex = 11
        Me.cbo_ProjectStatus.uclDisplayIndex = "0,1"
        Me.cbo_ProjectStatus.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_ProjectStatus.uclIsAutoClear = True
        Me.cbo_ProjectStatus.uclIsFirstItemEmpty = True
        Me.cbo_ProjectStatus.uclIsTextMode = False
        Me.cbo_ProjectStatus.uclShowMsg = False
        Me.cbo_ProjectStatus.uclValueIndex = "0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 115)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(944, 526)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(936, 496)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "專案列表"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgv_ProjectList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(936, 496)
        Me.Panel3.TabIndex = 0
        '
        'dgv_ProjectList
        '
        Me.dgv_ProjectList.AllowUserToAddRows = False
        Me.dgv_ProjectList.AllowUserToDeleteRows = False
        Me.dgv_ProjectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ProjectList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ProjectList.Location = New System.Drawing.Point(0, 0)
        Me.dgv_ProjectList.Name = "dgv_ProjectList"
        Me.dgv_ProjectList.ReadOnly = True
        Me.dgv_ProjectList.RowTemplate.Height = 24
        Me.dgv_ProjectList.Size = New System.Drawing.Size(936, 496)
        Me.dgv_ProjectList.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(936, 496)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "所屬系統"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgv_System)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(930, 412)
        Me.Panel1.TabIndex = 1
        '
        'dgv_System
        '
        Me.dgv_System.AllowUserToAddRows = False
        Me.dgv_System.AllowUserToDeleteRows = False
        Me.dgv_System.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_System.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_System.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_System.Location = New System.Drawing.Point(0, 0)
        Me.dgv_System.Name = "dgv_System"
        Me.dgv_System.ReadOnly = True
        Me.dgv_System.RowTemplate.Height = 24
        Me.dgv_System.Size = New System.Drawing.Size(930, 412)
        Me.dgv_System.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.txt_SystemName, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_SystemCode, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_SA, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(930, 78)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'txt_SystemName
        '
        Me.txt_SystemName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SystemName.Location = New System.Drawing.Point(81, 45)
        Me.txt_SystemName.MaxLength = 200
        Me.txt_SystemName.Name = "txt_SystemName"
        Me.txt_SystemName.Size = New System.Drawing.Size(242, 27)
        Me.txt_SystemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "系統代碼"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "系統名稱"
        '
        'txt_SystemCode
        '
        Me.txt_SystemCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SystemCode.Location = New System.Drawing.Point(81, 6)
        Me.txt_SystemCode.MaxLength = 10
        Me.txt_SystemCode.Name = "txt_SystemCode"
        Me.txt_SystemCode.Size = New System.Drawing.Size(242, 27)
        Me.txt_SystemCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(329, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "權責SA"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_InsertNewProjectSystem)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_UpdateProjectSystem)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_DeleteProjectSystem)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(394, 42)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(533, 33)
        Me.FlowLayoutPanel2.TabIndex = 6
        '
        'btn_InsertNewProjectSystem
        '
        Me.btn_InsertNewProjectSystem.Location = New System.Drawing.Point(3, 3)
        Me.btn_InsertNewProjectSystem.Name = "btn_InsertNewProjectSystem"
        Me.btn_InsertNewProjectSystem.Size = New System.Drawing.Size(96, 27)
        Me.btn_InsertNewProjectSystem.TabIndex = 0
        Me.btn_InsertNewProjectSystem.Text = "新增"
        Me.btn_InsertNewProjectSystem.UseVisualStyleBackColor = True
        '
        'btn_UpdateProjectSystem
        '
        Me.btn_UpdateProjectSystem.Location = New System.Drawing.Point(105, 3)
        Me.btn_UpdateProjectSystem.Name = "btn_UpdateProjectSystem"
        Me.btn_UpdateProjectSystem.Size = New System.Drawing.Size(96, 27)
        Me.btn_UpdateProjectSystem.TabIndex = 1
        Me.btn_UpdateProjectSystem.Text = "修改"
        Me.btn_UpdateProjectSystem.UseVisualStyleBackColor = True
        '
        'btn_DeleteProjectSystem
        '
        Me.btn_DeleteProjectSystem.Location = New System.Drawing.Point(207, 3)
        Me.btn_DeleteProjectSystem.Name = "btn_DeleteProjectSystem"
        Me.btn_DeleteProjectSystem.Size = New System.Drawing.Size(96, 27)
        Me.btn_DeleteProjectSystem.TabIndex = 2
        Me.btn_DeleteProjectSystem.Text = "刪除"
        Me.btn_DeleteProjectSystem.UseVisualStyleBackColor = True
        '
        'cbo_SA
        '
        Me.cbo_SA.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SA.DropDownWidth = 20
        Me.cbo_SA.DroppedDown = False
        Me.cbo_SA.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SA.Location = New System.Drawing.Point(391, 7)
        Me.cbo_SA.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SA.MaxLength = 50
        Me.cbo_SA.Name = "cbo_SA"
        Me.cbo_SA.SelectedIndex = -1
        Me.cbo_SA.SelectedItem = Nothing
        Me.cbo_SA.SelectedText = ""
        Me.cbo_SA.SelectedValue = ""
        Me.cbo_SA.SelectionStart = 0
        Me.cbo_SA.Size = New System.Drawing.Size(150, 24)
        Me.cbo_SA.TabIndex = 7
        Me.cbo_SA.uclDisplayIndex = "0,1"
        Me.cbo_SA.uclImeMode = System.Windows.Forms.ImeMode.[On]
        Me.cbo_SA.uclIsAutoClear = True
        Me.cbo_SA.uclIsFirstItemEmpty = True
        Me.cbo_SA.uclIsTextMode = False
        Me.cbo_SA.uclShowMsg = False
        Me.cbo_SA.uclValueIndex = "0"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(936, 496)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "所屬功能"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgv_Function)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(930, 411)
        Me.Panel2.TabIndex = 1
        '
        'dgv_Function
        '
        Me.dgv_Function.AllowUserToAddRows = False
        Me.dgv_Function.AllowUserToDeleteRows = False
        Me.dgv_Function.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv_Function.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Function.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Function.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Function.Name = "dgv_Function"
        Me.dgv_Function.ReadOnly = True
        Me.dgv_Function.RowTemplate.Height = 24
        Me.dgv_Function.Size = New System.Drawing.Size(930, 411)
        Me.dgv_Function.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_FunctionCode, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel3, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txt_FunctionName, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ckb_Dc, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(930, 79)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "功能代碼"
        '
        'txt_FunctionCode
        '
        Me.txt_FunctionCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FunctionCode.Location = New System.Drawing.Point(81, 6)
        Me.txt_FunctionCode.Name = "txt_FunctionCode"
        Me.txt_FunctionCode.Size = New System.Drawing.Size(225, 27)
        Me.txt_FunctionCode.TabIndex = 5
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_InsertNewSystemFunction)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_UpdateSystemFunction)
        Me.FlowLayoutPanel3.Controls.Add(Me.btn_DeleteSystemFunction)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(312, 42)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(740, 34)
        Me.FlowLayoutPanel3.TabIndex = 6
        '
        'btn_InsertNewSystemFunction
        '
        Me.btn_InsertNewSystemFunction.Location = New System.Drawing.Point(3, 3)
        Me.btn_InsertNewSystemFunction.Name = "btn_InsertNewSystemFunction"
        Me.btn_InsertNewSystemFunction.Size = New System.Drawing.Size(96, 27)
        Me.btn_InsertNewSystemFunction.TabIndex = 1
        Me.btn_InsertNewSystemFunction.Text = "新增"
        Me.btn_InsertNewSystemFunction.UseVisualStyleBackColor = True
        '
        'btn_UpdateSystemFunction
        '
        Me.btn_UpdateSystemFunction.Location = New System.Drawing.Point(105, 3)
        Me.btn_UpdateSystemFunction.Name = "btn_UpdateSystemFunction"
        Me.btn_UpdateSystemFunction.Size = New System.Drawing.Size(96, 27)
        Me.btn_UpdateSystemFunction.TabIndex = 2
        Me.btn_UpdateSystemFunction.Text = "修改"
        Me.btn_UpdateSystemFunction.UseVisualStyleBackColor = True
        '
        'btn_DeleteSystemFunction
        '
        Me.btn_DeleteSystemFunction.Location = New System.Drawing.Point(207, 3)
        Me.btn_DeleteSystemFunction.Name = "btn_DeleteSystemFunction"
        Me.btn_DeleteSystemFunction.Size = New System.Drawing.Size(96, 27)
        Me.btn_DeleteSystemFunction.TabIndex = 3
        Me.btn_DeleteSystemFunction.Text = "刪除"
        Me.btn_DeleteSystemFunction.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "功能名稱"
        '
        'txt_FunctionName
        '
        Me.txt_FunctionName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_FunctionName.Location = New System.Drawing.Point(81, 45)
        Me.txt_FunctionName.Name = "txt_FunctionName"
        Me.txt_FunctionName.Size = New System.Drawing.Size(225, 27)
        Me.txt_FunctionName.TabIndex = 3
        '
        'ckb_Dc
        '
        Me.ckb_Dc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckb_Dc.AutoSize = True
        Me.ckb_Dc.Location = New System.Drawing.Point(312, 9)
        Me.ckb_Dc.Name = "ckb_Dc"
        Me.ckb_Dc.Size = New System.Drawing.Size(59, 20)
        Me.ckb_Dc.TabIndex = 7
        Me.ckb_Dc.Text = "停用"
        Me.ckb_Dc.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_QueryProject)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_InsertNewProject)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_UpdateProject)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_DeleteProject)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 72)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(944, 43)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'btn_QueryProject
        '
        Me.btn_QueryProject.Location = New System.Drawing.Point(3, 3)
        Me.btn_QueryProject.Name = "btn_QueryProject"
        Me.btn_QueryProject.Size = New System.Drawing.Size(96, 27)
        Me.btn_QueryProject.TabIndex = 0
        Me.btn_QueryProject.Text = "查詢"
        Me.btn_QueryProject.UseVisualStyleBackColor = True
        '
        'btn_InsertNewProject
        '
        Me.btn_InsertNewProject.Location = New System.Drawing.Point(105, 3)
        Me.btn_InsertNewProject.Name = "btn_InsertNewProject"
        Me.btn_InsertNewProject.Size = New System.Drawing.Size(96, 27)
        Me.btn_InsertNewProject.TabIndex = 1
        Me.btn_InsertNewProject.Text = "新增"
        Me.btn_InsertNewProject.UseVisualStyleBackColor = True
        '
        'btn_UpdateProject
        '
        Me.btn_UpdateProject.Location = New System.Drawing.Point(207, 3)
        Me.btn_UpdateProject.Name = "btn_UpdateProject"
        Me.btn_UpdateProject.Size = New System.Drawing.Size(96, 27)
        Me.btn_UpdateProject.TabIndex = 2
        Me.btn_UpdateProject.Text = "修改"
        Me.btn_UpdateProject.UseVisualStyleBackColor = True
        '
        'btn_DeleteProject
        '
        Me.btn_DeleteProject.Location = New System.Drawing.Point(309, 3)
        Me.btn_DeleteProject.Name = "btn_DeleteProject"
        Me.btn_DeleteProject.Size = New System.Drawing.Size(96, 27)
        Me.btn_DeleteProject.TabIndex = 3
        Me.btn_DeleteProject.Text = "刪除"
        Me.btn_DeleteProject.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = """Excel Files|*.xls;*.xlsx;*.xlsm"""
        '
        'JobProjectMaintainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "JobProjectMaintainUI"
        Me.TabText = "專案維護"
        Me.Text = "專案維護"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgv_ProjectList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgv_System, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv_Function, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_ProjectName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_ProjectID As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Windows.Forms.DateTimePicker
    Friend WithEvents cbo_PM As Windows.Forms.ComboBox
    Friend WithEvents ckb_IsClose As Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents dgv_System As Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_SystemName As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txt_SystemCode As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_InsertNewProjectSystem As Windows.Forms.Button
    Friend WithEvents btn_UpdateProjectSystem As Windows.Forms.Button
    Friend WithEvents btn_DeleteProjectSystem As Windows.Forms.Button
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents dgv_Function As Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel3 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txt_FunctionCode As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents txt_FunctionName As Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel3 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_InsertNewSystemFunction As Windows.Forms.Button
    Friend WithEvents btn_UpdateSystemFunction As Windows.Forms.Button
    Friend WithEvents btn_DeleteSystemFunction As Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_QueryProject As Windows.Forms.Button
    Friend WithEvents btn_InsertNewProject As Windows.Forms.Button
    Friend WithEvents btn_UpdateProject As Windows.Forms.Button
    Friend WithEvents btn_DeleteProject As Windows.Forms.Button
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents dgv_ProjectList As Windows.Forms.DataGridView
    Friend WithEvents btn_ImportFunctionList As Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents ckb_Dc As Windows.Forms.CheckBox
    Friend WithEvents cbo_SA As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cbo_ProjectStatus As Syscom.Client.UCL.UCLComboBoxUC
End Class
