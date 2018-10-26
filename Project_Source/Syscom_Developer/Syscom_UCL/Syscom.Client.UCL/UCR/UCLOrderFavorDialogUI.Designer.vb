<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLOrderFavorDialogUI
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("常用藥")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("【套】RIS用藥")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("【套】急救用藥")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCLOrderFavorDialogUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Pharmacy12Code = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_OwnPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_NhiPrice = New System.Windows.Forms.TextBox()
        Me.btn_QueryPrice = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_FavorId1 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId2 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId3 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId4 = New System.Windows.Forms.RadioButton()
        Me.btn_QueryAll = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_Query2 = New System.Windows.Forms.Button()
        Me.btn_SelAll = New System.Windows.Forms.Button()
        Me.lbl_OrderName = New System.Windows.Forms.Label()
        Me.chk_Diabetes = New System.Windows.Forms.CheckBox()
        Me.chk_HighBlood = New System.Windows.Forms.CheckBox()
        Me.btn_Massrefer = New System.Windows.Forms.Button()
        Me.btn_Looks = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chk_AliasName = New System.Windows.Forms.CheckBox()
        Me.chk_ScientificName = New System.Windows.Forms.CheckBox()
        Me.chk_TradenName = New System.Windows.Forms.CheckBox()
        Me.chk_ChineseName = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chk_Normal = New System.Windows.Forms.CheckBox()
        Me.chk_Chinese = New System.Windows.Forms.CheckBox()
        Me.btn_Package = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Query3 = New System.Windows.Forms.Button()
        Me.rbt_Query2 = New System.Windows.Forms.RadioButton()
        Me.rbt_Query1 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_Index5 = New System.Windows.Forms.TextBox()
        Me.txt_Index4 = New System.Windows.Forms.TextBox()
        Me.txt_Index3 = New System.Windows.Forms.TextBox()
        Me.txt_Index2 = New System.Windows.Forms.TextBox()
        Me.txt_Index1 = New System.Windows.Forms.TextBox()
        Me.lst_OrgExam = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tre_Category = New System.Windows.Forms.TreeView()
        Me.chk_SelAll = New System.Windows.Forms.CheckBox()
        Me.dgv_FavorData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.dgv_Selected = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.cbo_Dept2 = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_Station = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_OrderName2 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cbo_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_OrderName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_UclQueryAll = New Syscom.Client.UCL.UCLBtnCodeQueryUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel6, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel4, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(528, 147)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel6
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel6, 3)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel6.Controls.Add(Me.txt_Pharmacy12Code)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel6.Controls.Add(Me.txt_OwnPrice)
        Me.FlowLayoutPanel6.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel6.Controls.Add(Me.txt_NhiPrice)
        Me.FlowLayoutPanel6.Controls.Add(Me.btn_QueryPrice)
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(3, 109)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(521, 34)
        Me.FlowLayoutPanel6.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "醫令:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Pharmacy12Code
        '
        Me.txt_Pharmacy12Code.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Pharmacy12Code.Enabled = False
        Me.txt_Pharmacy12Code.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_Pharmacy12Code.Location = New System.Drawing.Point(41, 3)
        Me.txt_Pharmacy12Code.Name = "txt_Pharmacy12Code"
        Me.txt_Pharmacy12Code.Size = New System.Drawing.Size(94, 27)
        Me.txt_Pharmacy12Code.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(141, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 24)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "自費價:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_OwnPrice
        '
        Me.txt_OwnPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_OwnPrice.Enabled = False
        Me.txt_OwnPrice.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_OwnPrice.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_OwnPrice.Location = New System.Drawing.Point(198, 3)
        Me.txt_OwnPrice.Name = "txt_OwnPrice"
        Me.txt_OwnPrice.Size = New System.Drawing.Size(95, 25)
        Me.txt_OwnPrice.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(299, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "健保價:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_NhiPrice
        '
        Me.txt_NhiPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_NhiPrice.Enabled = False
        Me.txt_NhiPrice.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_NhiPrice.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_NhiPrice.Location = New System.Drawing.Point(357, 3)
        Me.txt_NhiPrice.Name = "txt_NhiPrice"
        Me.txt_NhiPrice.Size = New System.Drawing.Size(99, 25)
        Me.txt_NhiPrice.TabIndex = 12
        '
        'btn_QueryPrice
        '
        Me.btn_QueryPrice.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_QueryPrice.Location = New System.Drawing.Point(462, 3)
        Me.btn_QueryPrice.Name = "btn_QueryPrice"
        Me.btn_QueryPrice.Size = New System.Drawing.Size(56, 24)
        Me.btn_QueryPrice.TabIndex = 13
        Me.btn_QueryPrice.Text = "查價"
        Me.btn_QueryPrice.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 3)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_FavorId1)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_FavorId2)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbo_Dept2)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_FavorId3)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_FavorId4)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbo_Station)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_QueryAll)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_OrderName2)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query2)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_SelAll)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_OrderName)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_Diabetes)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_HighBlood)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Massrefer)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Looks)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(520, 27)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'rbt_FavorId1
        '
        Me.rbt_FavorId1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbt_FavorId1.AutoSize = True
        Me.rbt_FavorId1.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId1.Location = New System.Drawing.Point(3, 6)
        Me.rbt_FavorId1.Name = "rbt_FavorId1"
        Me.rbt_FavorId1.Size = New System.Drawing.Size(85, 19)
        Me.rbt_FavorId1.TabIndex = 8
        Me.rbt_FavorId1.Text = "醫師常用"
        Me.rbt_FavorId1.UseVisualStyleBackColor = True
        '
        'rbt_FavorId2
        '
        Me.rbt_FavorId2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbt_FavorId2.AutoSize = True
        Me.rbt_FavorId2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId2.Location = New System.Drawing.Point(94, 6)
        Me.rbt_FavorId2.Name = "rbt_FavorId2"
        Me.rbt_FavorId2.Size = New System.Drawing.Size(70, 19)
        Me.rbt_FavorId2.TabIndex = 9
        Me.rbt_FavorId2.Text = "科常用"
        Me.rbt_FavorId2.UseVisualStyleBackColor = True
        '
        'rbt_FavorId3
        '
        Me.rbt_FavorId3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbt_FavorId3.AutoSize = True
        Me.rbt_FavorId3.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId3.Location = New System.Drawing.Point(281, 6)
        Me.rbt_FavorId3.Name = "rbt_FavorId3"
        Me.rbt_FavorId3.Size = New System.Drawing.Size(55, 19)
        Me.rbt_FavorId3.TabIndex = 10
        Me.rbt_FavorId3.Text = "全院"
        Me.rbt_FavorId3.UseVisualStyleBackColor = True
        '
        'rbt_FavorId4
        '
        Me.rbt_FavorId4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbt_FavorId4.AutoSize = True
        Me.rbt_FavorId4.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId4.Location = New System.Drawing.Point(342, 6)
        Me.rbt_FavorId4.Name = "rbt_FavorId4"
        Me.rbt_FavorId4.Size = New System.Drawing.Size(110, 19)
        Me.rbt_FavorId4.TabIndex = 12
        Me.rbt_FavorId4.Text = "檢驗(查)科室"
        Me.rbt_FavorId4.UseVisualStyleBackColor = True
        '
        'btn_QueryAll
        '
        Me.btn_QueryAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_QueryAll.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_QueryAll.Location = New System.Drawing.Point(114, 35)
        Me.btn_QueryAll.Name = "btn_QueryAll"
        Me.btn_QueryAll.Size = New System.Drawing.Size(86, 24)
        Me.btn_QueryAll.TabIndex = 11
        Me.btn_QueryAll.Text = "不分類檢索"
        Me.btn_QueryAll.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(203, 40)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 18)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "檢索"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Query2
        '
        Me.btn_Query2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Query2.Location = New System.Drawing.Point(335, 35)
        Me.btn_Query2.Name = "btn_Query2"
        Me.btn_Query2.Size = New System.Drawing.Size(50, 25)
        Me.btn_Query2.TabIndex = 13
        Me.btn_Query2.Text = "F1-查詢"
        Me.btn_Query2.UseVisualStyleBackColor = True
        '
        'btn_SelAll
        '
        Me.btn_SelAll.Location = New System.Drawing.Point(391, 35)
        Me.btn_SelAll.Name = "btn_SelAll"
        Me.btn_SelAll.Size = New System.Drawing.Size(52, 25)
        Me.btn_SelAll.TabIndex = 17
        Me.btn_SelAll.Text = "全選"
        Me.btn_SelAll.UseVisualStyleBackColor = True
        Me.btn_SelAll.Visible = False
        '
        'lbl_OrderName
        '
        Me.lbl_OrderName.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_OrderName.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_OrderName.ForeColor = System.Drawing.Color.Blue
        Me.lbl_OrderName.Location = New System.Drawing.Point(0, 67)
        Me.lbl_OrderName.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_OrderName.Name = "lbl_OrderName"
        Me.lbl_OrderName.Size = New System.Drawing.Size(159, 31)
        Me.lbl_OrderName.TabIndex = 15
        Me.lbl_OrderName.Text = "  "
        Me.lbl_OrderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chk_Diabetes
        '
        Me.chk_Diabetes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Diabetes.AutoSize = True
        Me.chk_Diabetes.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_Diabetes.Location = New System.Drawing.Point(162, 73)
        Me.chk_Diabetes.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_Diabetes.Name = "chk_Diabetes"
        Me.chk_Diabetes.Size = New System.Drawing.Size(71, 19)
        Me.chk_Diabetes.TabIndex = 9
        Me.chk_Diabetes.Text = "糖尿病"
        Me.chk_Diabetes.UseVisualStyleBackColor = True
        Me.chk_Diabetes.Visible = False
        '
        'chk_HighBlood
        '
        Me.chk_HighBlood.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_HighBlood.AutoSize = True
        Me.chk_HighBlood.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_HighBlood.Location = New System.Drawing.Point(236, 73)
        Me.chk_HighBlood.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_HighBlood.Name = "chk_HighBlood"
        Me.chk_HighBlood.Size = New System.Drawing.Size(71, 19)
        Me.chk_HighBlood.TabIndex = 10
        Me.chk_HighBlood.Text = "高血壓"
        Me.chk_HighBlood.UseVisualStyleBackColor = True
        Me.chk_HighBlood.Visible = False
        '
        'btn_Massrefer
        '
        Me.btn_Massrefer.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Massrefer.Location = New System.Drawing.Point(310, 70)
        Me.btn_Massrefer.Name = "btn_Massrefer"
        Me.btn_Massrefer.Size = New System.Drawing.Size(69, 25)
        Me.btn_Massrefer.TabIndex = 16
        Me.btn_Massrefer.Text = "處方集"
        Me.btn_Massrefer.UseVisualStyleBackColor = True
        '
        'btn_Looks
        '
        Me.btn_Looks.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Looks.Location = New System.Drawing.Point(385, 70)
        Me.btn_Looks.Name = "btn_Looks"
        Me.btn_Looks.Size = New System.Drawing.Size(80, 25)
        Me.btn_Looks.TabIndex = 17
        Me.btn_Looks.Text = "藥品外觀"
        Me.btn_Looks.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel2, 2)
        Me.FlowLayoutPanel2.Controls.Add(Me.chk_AliasName)
        Me.FlowLayoutPanel2.Controls.Add(Me.chk_ScientificName)
        Me.FlowLayoutPanel2.Controls.Add(Me.chk_TradenName)
        Me.FlowLayoutPanel2.Controls.Add(Me.chk_ChineseName)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 69)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(267, 27)
        Me.FlowLayoutPanel2.TabIndex = 16
        Me.FlowLayoutPanel2.Visible = False
        '
        'chk_AliasName
        '
        Me.chk_AliasName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_AliasName.AutoSize = True
        Me.chk_AliasName.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_AliasName.Location = New System.Drawing.Point(3, 0)
        Me.chk_AliasName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_AliasName.Name = "chk_AliasName"
        Me.chk_AliasName.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.chk_AliasName.Size = New System.Drawing.Size(56, 25)
        Me.chk_AliasName.TabIndex = 6
        Me.chk_AliasName.Text = "俗名"
        Me.chk_AliasName.UseVisualStyleBackColor = True
        '
        'chk_ScientificName
        '
        Me.chk_ScientificName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_ScientificName.AutoSize = True
        Me.chk_ScientificName.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_ScientificName.Location = New System.Drawing.Point(62, 0)
        Me.chk_ScientificName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_ScientificName.Name = "chk_ScientificName"
        Me.chk_ScientificName.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.chk_ScientificName.Size = New System.Drawing.Size(56, 25)
        Me.chk_ScientificName.TabIndex = 4
        Me.chk_ScientificName.Text = "學名"
        Me.chk_ScientificName.UseVisualStyleBackColor = True
        '
        'chk_TradenName
        '
        Me.chk_TradenName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_TradenName.AutoSize = True
        Me.chk_TradenName.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_TradenName.Location = New System.Drawing.Point(121, 0)
        Me.chk_TradenName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_TradenName.Name = "chk_TradenName"
        Me.chk_TradenName.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.chk_TradenName.Size = New System.Drawing.Size(71, 25)
        Me.chk_TradenName.TabIndex = 5
        Me.chk_TradenName.Text = "商品名"
        Me.chk_TradenName.UseVisualStyleBackColor = True
        '
        'chk_ChineseName
        '
        Me.chk_ChineseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_ChineseName.AutoSize = True
        Me.chk_ChineseName.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_ChineseName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_ChineseName.Location = New System.Drawing.Point(195, 0)
        Me.chk_ChineseName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_ChineseName.Name = "chk_ChineseName"
        Me.chk_ChineseName.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.chk_ChineseName.Size = New System.Drawing.Size(71, 25)
        Me.chk_ChineseName.TabIndex = 7
        Me.chk_ChineseName.Text = "中文名"
        Me.chk_ChineseName.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel3, 2)
        Me.FlowLayoutPanel3.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel3.Controls.Add(Me.cbo_Dept)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 36)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(266, 27)
        Me.FlowLayoutPanel3.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "科  室"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel4.Controls.Add(Me.txt_OrderName)
        Me.FlowLayoutPanel4.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(276, 36)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(247, 27)
        Me.FlowLayoutPanel4.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "檢索"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Query
        '
        Me.btn_Query.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Query.Location = New System.Drawing.Point(146, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(71, 25)
        Me.btn_Query.TabIndex = 1
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.chk_Normal)
        Me.FlowLayoutPanel5.Controls.Add(Me.chk_Chinese)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_Package)
        Me.FlowLayoutPanel5.Controls.Add(Me.btn_UclQueryAll)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(276, 69)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(247, 34)
        Me.FlowLayoutPanel5.TabIndex = 1
        Me.FlowLayoutPanel5.Visible = False
        '
        'chk_Normal
        '
        Me.chk_Normal.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Normal.AutoSize = True
        Me.chk_Normal.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_Normal.Location = New System.Drawing.Point(3, 11)
        Me.chk_Normal.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_Normal.Name = "chk_Normal"
        Me.chk_Normal.Size = New System.Drawing.Size(56, 19)
        Me.chk_Normal.TabIndex = 8
        Me.chk_Normal.Text = "一般"
        Me.chk_Normal.UseVisualStyleBackColor = True
        '
        'chk_Chinese
        '
        Me.chk_Chinese.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Chinese.AutoSize = True
        Me.chk_Chinese.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_Chinese.ForeColor = System.Drawing.Color.Red
        Me.chk_Chinese.Location = New System.Drawing.Point(62, 11)
        Me.chk_Chinese.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.chk_Chinese.Name = "chk_Chinese"
        Me.chk_Chinese.Size = New System.Drawing.Size(56, 19)
        Me.chk_Chinese.TabIndex = 10
        Me.chk_Chinese.Text = "中文"
        Me.chk_Chinese.UseVisualStyleBackColor = True
        '
        'btn_Package
        '
        Me.btn_Package.Location = New System.Drawing.Point(121, 3)
        Me.btn_Package.Name = "btn_Package"
        Me.btn_Package.Size = New System.Drawing.Size(52, 25)
        Me.btn_Package.TabIndex = 16
        Me.btn_Package.Text = "套裝"
        Me.btn_Package.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(535, 159)
        Me.Panel1.TabIndex = 1
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(869, 132)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(89, 26)
        Me.btn_OK.TabIndex = 3
        Me.btn_OK.Text = "F12-帶入"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_FavorData, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(247, 165)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 443.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(717, 443)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Query3)
        Me.GroupBox1.Controls.Add(Me.rbt_Query2)
        Me.GroupBox1.Controls.Add(Me.rbt_Query1)
        Me.GroupBox1.Location = New System.Drawing.Point(545, -7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 33)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btn_Query3
        '
        Me.btn_Query3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Query3.Location = New System.Drawing.Point(118, 9)
        Me.btn_Query3.Name = "btn_Query3"
        Me.btn_Query3.Size = New System.Drawing.Size(71, 25)
        Me.btn_Query3.TabIndex = 8
        Me.btn_Query3.Text = "F1-查詢"
        Me.btn_Query3.UseVisualStyleBackColor = True
        '
        'rbt_Query2
        '
        Me.rbt_Query2.AutoSize = True
        Me.rbt_Query2.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.rbt_Query2.Location = New System.Drawing.Point(54, 12)
        Me.rbt_Query2.Name = "rbt_Query2"
        Me.rbt_Query2.Size = New System.Drawing.Size(53, 18)
        Me.rbt_Query2.TabIndex = 3
        Me.rbt_Query2.TabStop = True
        Me.rbt_Query2.Text = "檢索"
        Me.rbt_Query2.UseVisualStyleBackColor = True
        '
        'rbt_Query1
        '
        Me.rbt_Query1.AutoSize = True
        Me.rbt_Query1.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.rbt_Query1.Location = New System.Drawing.Point(2, 12)
        Me.rbt_Query1.Name = "rbt_Query1"
        Me.rbt_Query1.Size = New System.Drawing.Size(53, 18)
        Me.rbt_Query1.TabIndex = 0
        Me.rbt_Query1.TabStop = True
        Me.rbt_Query1.Text = "分類"
        Me.rbt_Query1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txt_Index5)
        Me.Panel3.Controls.Add(Me.txt_Index4)
        Me.Panel3.Controls.Add(Me.txt_Index3)
        Me.Panel3.Controls.Add(Me.txt_Index2)
        Me.Panel3.Controls.Add(Me.txt_Index1)
        Me.Panel3.Location = New System.Drawing.Point(544, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(186, 161)
        Me.Panel3.TabIndex = 8
        '
        'txt_Index5
        '
        Me.txt_Index5.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txt_Index5.Location = New System.Drawing.Point(3, 131)
        Me.txt_Index5.Name = "txt_Index5"
        Me.txt_Index5.Size = New System.Drawing.Size(180, 27)
        Me.txt_Index5.TabIndex = 4
        '
        'txt_Index4
        '
        Me.txt_Index4.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txt_Index4.Location = New System.Drawing.Point(3, 99)
        Me.txt_Index4.Name = "txt_Index4"
        Me.txt_Index4.Size = New System.Drawing.Size(180, 27)
        Me.txt_Index4.TabIndex = 3
        '
        'txt_Index3
        '
        Me.txt_Index3.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txt_Index3.Location = New System.Drawing.Point(3, 67)
        Me.txt_Index3.Name = "txt_Index3"
        Me.txt_Index3.Size = New System.Drawing.Size(180, 27)
        Me.txt_Index3.TabIndex = 2
        '
        'txt_Index2
        '
        Me.txt_Index2.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txt_Index2.Location = New System.Drawing.Point(3, 35)
        Me.txt_Index2.Name = "txt_Index2"
        Me.txt_Index2.Size = New System.Drawing.Size(180, 27)
        Me.txt_Index2.TabIndex = 1
        '
        'txt_Index1
        '
        Me.txt_Index1.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txt_Index1.Location = New System.Drawing.Point(3, 3)
        Me.txt_Index1.Name = "txt_Index1"
        Me.txt_Index1.Size = New System.Drawing.Size(180, 27)
        Me.txt_Index1.TabIndex = 0
        '
        'lst_OrgExam
        '
        Me.lst_OrgExam.FormattingEnabled = True
        Me.lst_OrgExam.ItemHeight = 16
        Me.lst_OrgExam.Location = New System.Drawing.Point(728, 138)
        Me.lst_OrgExam.Name = "lst_OrgExam"
        Me.lst_OrgExam.Size = New System.Drawing.Size(93, 20)
        Me.lst_OrgExam.TabIndex = 5
        Me.lst_OrgExam.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tre_Category)
        Me.Panel2.Location = New System.Drawing.Point(3, 165)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(241, 443)
        Me.Panel2.TabIndex = 9
        '
        'tre_Category
        '
        Me.tre_Category.Cursor = System.Windows.Forms.Cursors.Default
        Me.tre_Category.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tre_Category.FullRowSelect = True
        Me.tre_Category.Location = New System.Drawing.Point(3, 4)
        Me.tre_Category.Name = "tre_Category"
        TreeNode1.Name = "Node5"
        TreeNode1.Text = "常用藥"
        TreeNode2.Name = "Node6"
        TreeNode2.Text = "【套】RIS用藥"
        TreeNode3.Name = "Node7"
        TreeNode3.Text = "【套】急救用藥"
        Me.tre_Category.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.tre_Category.Size = New System.Drawing.Size(235, 435)
        Me.tre_Category.TabIndex = 1
        '
        'chk_SelAll
        '
        Me.chk_SelAll.AutoSize = True
        Me.chk_SelAll.Location = New System.Drawing.Point(784, 137)
        Me.chk_SelAll.Name = "chk_SelAll"
        Me.chk_SelAll.Size = New System.Drawing.Size(59, 20)
        Me.chk_SelAll.TabIndex = 10
        Me.chk_SelAll.Text = "全選"
        Me.chk_SelAll.UseVisualStyleBackColor = True
        '
        'dgv_FavorData
        '
        Me.dgv_FavorData.AllowUserToAddRows = False
        Me.dgv_FavorData.AllowUserToOrderColumns = False
        Me.dgv_FavorData.AllowUserToResizeColumns = True
        Me.dgv_FavorData.AllowUserToResizeRows = False
        Me.dgv_FavorData.AutoScroll = True
        Me.dgv_FavorData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_FavorData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_FavorData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_FavorData.ColumnHeadersHeight = 23
        Me.dgv_FavorData.ColumnHeadersVisible = False
        Me.dgv_FavorData.CurrentCell = Nothing
        Me.dgv_FavorData.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_FavorData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_FavorData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_FavorData.Location = New System.Drawing.Point(6, 5)
        Me.dgv_FavorData.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_FavorData.MultiSelect = False
        Me.dgv_FavorData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_FavorData.Name = "dgv_FavorData"
        Me.dgv_FavorData.RowHeadersWidth = 41
        Me.dgv_FavorData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_FavorData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_FavorData.Size = New System.Drawing.Size(705, 433)
        Me.dgv_FavorData.TabIndex = 4
        Me.dgv_FavorData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_FavorData.uclBatchColIndex = ""
        Me.dgv_FavorData.uclClickToCheck = False
        Me.dgv_FavorData.uclColumnAlignment = ""
        Me.dgv_FavorData.uclColumnCheckBox = False
        Me.dgv_FavorData.uclColumnControlType = ""
        Me.dgv_FavorData.uclColumnWidth = ""
        Me.dgv_FavorData.uclDoCellEnter = True
        Me.dgv_FavorData.uclHasNewRow = False
        Me.dgv_FavorData.uclHeaderText = ""
        Me.dgv_FavorData.uclIsAlternatingRowsColors = False
        Me.dgv_FavorData.uclIsComboBoxGridQuery = True
        Me.dgv_FavorData.uclIsComboxClickTriggerDropDown = False
        Me.dgv_FavorData.uclIsDoOrderCheck = True
        Me.dgv_FavorData.uclIsSortable = False
        Me.dgv_FavorData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_FavorData.uclNonVisibleColIndex = ""
        Me.dgv_FavorData.uclReadOnly = False
        Me.dgv_FavorData.uclShowCellBorder = False
        Me.dgv_FavorData.uclSortColIndex = ""
        Me.dgv_FavorData.uclTreeMode = False
        Me.dgv_FavorData.uclVisibleColIndex = ""
        '
        'dgv_Selected
        '
        Me.dgv_Selected.AllowUserToAddRows = False
        Me.dgv_Selected.AllowUserToOrderColumns = False
        Me.dgv_Selected.AllowUserToResizeColumns = True
        Me.dgv_Selected.AllowUserToResizeRows = False
        Me.dgv_Selected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Selected.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Selected.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_Selected.ColumnHeadersHeight = 4
        Me.dgv_Selected.ColumnHeadersVisible = True
        Me.dgv_Selected.CurrentCell = Nothing
        Me.dgv_Selected.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Selected.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_Selected.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Selected.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dgv_Selected.Location = New System.Drawing.Point(728, 3)
        Me.dgv_Selected.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Selected.MultiSelect = True
        Me.dgv_Selected.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.DeleteAll
        Me.dgv_Selected.Name = "dgv_Selected"
        Me.dgv_Selected.RowHeadersWidth = 41
        Me.dgv_Selected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Selected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Selected.Size = New System.Drawing.Size(230, 127)
        Me.dgv_Selected.TabIndex = 2
        Me.dgv_Selected.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Selected.uclBatchColIndex = ""
        Me.dgv_Selected.uclClickToCheck = False
        Me.dgv_Selected.uclColumnAlignment = ""
        Me.dgv_Selected.uclColumnCheckBox = True
        Me.dgv_Selected.uclColumnControlType = ""
        Me.dgv_Selected.uclColumnWidth = ""
        Me.dgv_Selected.uclDoCellEnter = True
        Me.dgv_Selected.uclHasNewRow = False
        Me.dgv_Selected.uclHeaderText = ""
        Me.dgv_Selected.uclIsAlternatingRowsColors = True
        Me.dgv_Selected.uclIsComboBoxGridQuery = True
        Me.dgv_Selected.uclIsComboxClickTriggerDropDown = False
        Me.dgv_Selected.uclIsDoOrderCheck = True
        Me.dgv_Selected.uclIsSortable = False
        Me.dgv_Selected.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Selected.uclNonVisibleColIndex = ""
        Me.dgv_Selected.uclReadOnly = False
        Me.dgv_Selected.uclShowCellBorder = False
        Me.dgv_Selected.uclSortColIndex = ""
        Me.dgv_Selected.uclTreeMode = False
        Me.dgv_Selected.uclVisibleColIndex = ""
        '
        'cbo_Dept2
        '
        Me.cbo_Dept2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_Dept2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Dept2.DropDownWidth = 20
        Me.cbo_Dept2.DroppedDown = False
        Me.cbo_Dept2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Dept2.Location = New System.Drawing.Point(171, 4)
        Me.cbo_Dept2.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Dept2.Name = "cbo_Dept2"
        Me.cbo_Dept2.SelectedIndex = -1
        Me.cbo_Dept2.SelectedItem = Nothing
        Me.cbo_Dept2.SelectedText = ""
        Me.cbo_Dept2.SelectedValue = ""
        Me.cbo_Dept2.SelectionStart = 0
        Me.cbo_Dept2.Size = New System.Drawing.Size(103, 24)
        Me.cbo_Dept2.TabIndex = 14
        Me.cbo_Dept2.uclDisplayIndex = "0,1"
        Me.cbo_Dept2.uclIsAutoClear = True
        Me.cbo_Dept2.uclIsFirstItemEmpty = True
        Me.cbo_Dept2.uclIsTextMode = False
        Me.cbo_Dept2.uclShowMsg = False
        Me.cbo_Dept2.uclValueIndex = "0"
        '
        'cbo_Station
        '
        Me.cbo_Station.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_Station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Station.DropDownWidth = 20
        Me.cbo_Station.DroppedDown = False
        Me.cbo_Station.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Station.Location = New System.Drawing.Point(4, 36)
        Me.cbo_Station.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Station.Name = "cbo_Station"
        Me.cbo_Station.SelectedIndex = -1
        Me.cbo_Station.SelectedItem = Nothing
        Me.cbo_Station.SelectedText = ""
        Me.cbo_Station.SelectedValue = ""
        Me.cbo_Station.SelectionStart = 0
        Me.cbo_Station.Size = New System.Drawing.Size(103, 24)
        Me.cbo_Station.TabIndex = 15
        Me.cbo_Station.uclDisplayIndex = "0,1"
        Me.cbo_Station.uclIsAutoClear = True
        Me.cbo_Station.uclIsFirstItemEmpty = True
        Me.cbo_Station.uclIsTextMode = False
        Me.cbo_Station.uclShowMsg = False
        Me.cbo_Station.uclValueIndex = "0"
        Me.cbo_Station.Visible = False
        '
        'txt_OrderName2
        '
        Me.txt_OrderName2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderName2.Location = New System.Drawing.Point(244, 36)
        Me.txt_OrderName2.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_OrderName2.MaxLength = 10
        Me.txt_OrderName2.Name = "txt_OrderName2"
        Me.txt_OrderName2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderName2.SelectionStart = 0
        Me.txt_OrderName2.Size = New System.Drawing.Size(84, 27)
        Me.txt_OrderName2.TabIndex = 15
        Me.txt_OrderName2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrderName2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrderName2.ToolTipTag = Nothing
        Me.txt_OrderName2.uclDollarSign = False
        Me.txt_OrderName2.uclDotCount = 0
        Me.txt_OrderName2.uclIntCount = 2
        Me.txt_OrderName2.uclMinus = False
        Me.txt_OrderName2.uclReadOnly = False
        Me.txt_OrderName2.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_OrderName2.uclTrimZero = True
        '
        'cbo_Dept
        '
        Me.cbo_Dept.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Dept.DropDownWidth = 20
        Me.cbo_Dept.DroppedDown = False
        Me.cbo_Dept.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Dept.Location = New System.Drawing.Point(55, 4)
        Me.cbo_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Dept.Name = "cbo_Dept"
        Me.cbo_Dept.SelectedIndex = -1
        Me.cbo_Dept.SelectedItem = Nothing
        Me.cbo_Dept.SelectedText = ""
        Me.cbo_Dept.SelectedValue = ""
        Me.cbo_Dept.SelectionStart = 0
        Me.cbo_Dept.Size = New System.Drawing.Size(205, 24)
        Me.cbo_Dept.TabIndex = 13
        Me.cbo_Dept.uclDisplayIndex = "0,1"
        Me.cbo_Dept.uclIsAutoClear = True
        Me.cbo_Dept.uclIsFirstItemEmpty = True
        Me.cbo_Dept.uclIsTextMode = False
        Me.cbo_Dept.uclShowMsg = False
        Me.cbo_Dept.uclValueIndex = "0"
        '
        'txt_OrderName
        '
        Me.txt_OrderName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderName.Location = New System.Drawing.Point(41, 4)
        Me.txt_OrderName.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_OrderName.MaxLength = 10
        Me.txt_OrderName.Name = "txt_OrderName"
        Me.txt_OrderName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderName.SelectionStart = 0
        Me.txt_OrderName.Size = New System.Drawing.Size(98, 27)
        Me.txt_OrderName.TabIndex = 5
        Me.txt_OrderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrderName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrderName.ToolTipTag = Nothing
        Me.txt_OrderName.uclDollarSign = False
        Me.txt_OrderName.uclDotCount = 0
        Me.txt_OrderName.uclIntCount = 2
        Me.txt_OrderName.uclMinus = False
        Me.txt_OrderName.uclReadOnly = False
        Me.txt_OrderName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_OrderName.uclTrimZero = True
        '
        'btn_UclQueryAll
        '
        Me.btn_UclQueryAll.Location = New System.Drawing.Point(185, 7)
        Me.btn_UclQueryAll.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.btn_UclQueryAll.Name = "btn_UclQueryAll"
        Me.btn_UclQueryAll.Size = New System.Drawing.Size(29, 27)
        Me.btn_UclQueryAll.TabIndex = 15
        Me.btn_UclQueryAll.uclAreaCode = ""
        Me.btn_UclQueryAll.uclBtnText = "..."
        Me.btn_UclQueryAll.uclEnableQueryList = True
        Me.btn_UclQueryAll.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.btn_UclQueryAll.uclIsCheckDoctorOnDuty = False
        Me.btn_UclQueryAll.uclIsReturnDS = False
        Me.btn_UclQueryAll.uclQueryField = Nothing
        Me.btn_UclQueryAll.uclQueryValue = Nothing
        Me.btn_UclQueryAll.uclRefHosp = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclRefHospData.All
        Me.btn_UclQueryAll.uclSelectType = Syscom.Client.UCL.UCLBtnCodeQueryUC.SelectType.SingleSelect
        Me.btn_UclQueryAll.uclTableName = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclQueryTable.PUB_Order
        Me.btn_UclQueryAll.uclXPosition = 225
        Me.btn_UclQueryAll.uclYPosition = 120
        Me.btn_UclQueryAll.Visible = False
        '
        'UCLOrderFavorDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 609)
        Me.Controls.Add(Me.chk_SelAll)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lst_OrgExam)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.dgv_Selected)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Location = New System.Drawing.Point(0, 30)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLOrderFavorDialogUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "常用查詢"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbt_FavorId1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_Dept As UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chk_ScientificName As System.Windows.Forms.CheckBox
    Friend WithEvents chk_TradenName As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents chk_Normal As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Chinese As System.Windows.Forms.CheckBox
    Friend WithEvents btn_QueryAll As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_ChineseName As System.Windows.Forms.CheckBox
    Friend WithEvents chk_AliasName As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Pharmacy12Code As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_OwnPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_NhiPrice As System.Windows.Forms.TextBox
    Friend WithEvents btn_QueryPrice As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv_Selected As UCLDataGridViewUC
    Friend WithEvents btn_UclQueryAll As UCLBtnCodeQueryUC
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents dgv_FavorData As UCLDataGridViewUC
    Friend WithEvents btn_Package As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_OrderName2 As UCLTextBoxUC
    Friend WithEvents btn_Query2 As System.Windows.Forms.Button
    Friend WithEvents lbl_OrderName As System.Windows.Forms.Label
    Friend WithEvents btn_Massrefer As System.Windows.Forms.Button
    Friend WithEvents btn_Looks As System.Windows.Forms.Button
    Friend WithEvents cbo_Dept2 As UCLComboBoxUC
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbt_Query2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_Query1 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Query3 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_Index5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Index4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Index3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Index2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Index1 As System.Windows.Forms.TextBox
    Friend WithEvents chk_Diabetes As System.Windows.Forms.CheckBox
    Friend WithEvents chk_HighBlood As System.Windows.Forms.CheckBox
    Friend WithEvents lst_OrgExam As System.Windows.Forms.ListBox
    Friend WithEvents txt_OrderName As UCLTextBoxUC
    Friend WithEvents cbo_Station As UCLComboBoxUC
    Friend WithEvents btn_SelAll As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tre_Category As System.Windows.Forms.TreeView
    Friend WithEvents chk_SelAll As System.Windows.Forms.CheckBox
End Class