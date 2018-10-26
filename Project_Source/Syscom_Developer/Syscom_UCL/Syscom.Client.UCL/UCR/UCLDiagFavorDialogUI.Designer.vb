<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLDiagFavorDialogUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCLDiagFavorDialogUI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("常用藥")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("【套】RIS用藥")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("【套】急救用藥")
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk_NoCatag = New System.Windows.Forms.CheckBox()
        Me.rbt_FavorId1 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId2 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId3 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId4 = New System.Windows.Forms.RadioButton()
        Me.rbt_FavorId5 = New System.Windows.Forms.RadioButton()
        Me.cbo_Insu_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_ICD10_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_Diag_Code = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.txt_Diag_Desc = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_FavorData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tre_Category = New System.Windows.Forms.TreeView()
        Me.dgv_Selected = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(583, 111)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.chk_NoCatag, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.rbt_FavorId1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbt_FavorId2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbt_FavorId3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbt_FavorId4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbt_FavorId5, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Insu_Dept, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_ICD10_Dept, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Dept, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Diag_Code, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Query, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Diag_Desc, 3, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(589, 101)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'chk_NoCatag
        '
        Me.chk_NoCatag.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_NoCatag.AutoSize = True
        Me.chk_NoCatag.Checked = True
        Me.chk_NoCatag.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_NoCatag.Location = New System.Drawing.Point(409, 72)
        Me.chk_NoCatag.Name = "chk_NoCatag"
        Me.chk_NoCatag.Size = New System.Drawing.Size(75, 20)
        Me.chk_NoCatag.TabIndex = 10
        Me.chk_NoCatag.Text = "不分類"
        Me.chk_NoCatag.UseVisualStyleBackColor = True
        Me.chk_NoCatag.Visible = False
        '
        'rbt_FavorId1
        '
        Me.rbt_FavorId1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_FavorId1.AutoSize = True
        Me.rbt_FavorId1.Checked = True
        Me.rbt_FavorId1.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId1.Location = New System.Drawing.Point(3, 6)
        Me.rbt_FavorId1.Name = "rbt_FavorId1"
        Me.rbt_FavorId1.Size = New System.Drawing.Size(85, 19)
        Me.rbt_FavorId1.TabIndex = 15
        Me.rbt_FavorId1.TabStop = True
        Me.rbt_FavorId1.Text = "醫師常用"
        Me.rbt_FavorId1.UseVisualStyleBackColor = True
        '
        'rbt_FavorId2
        '
        Me.rbt_FavorId2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.rbt_FavorId2.AutoSize = True
        Me.rbt_FavorId2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId2.Location = New System.Drawing.Point(94, 6)
        Me.rbt_FavorId2.Name = "rbt_FavorId2"
        Me.rbt_FavorId2.Size = New System.Drawing.Size(70, 19)
        Me.rbt_FavorId2.TabIndex = 16
        Me.rbt_FavorId2.Text = "科常用"
        Me.rbt_FavorId2.UseVisualStyleBackColor = True
        '
        'rbt_FavorId3
        '
        Me.rbt_FavorId3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_FavorId3.AutoSize = True
        Me.rbt_FavorId3.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId3.Location = New System.Drawing.Point(3, 38)
        Me.rbt_FavorId3.Name = "rbt_FavorId3"
        Me.rbt_FavorId3.Size = New System.Drawing.Size(56, 19)
        Me.rbt_FavorId3.TabIndex = 18
        Me.rbt_FavorId3.Text = "ICD9"
        Me.rbt_FavorId3.UseVisualStyleBackColor = True
        '
        'rbt_FavorId4
        '
        Me.rbt_FavorId4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_FavorId4.AutoSize = True
        Me.rbt_FavorId4.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId4.Location = New System.Drawing.Point(94, 38)
        Me.rbt_FavorId4.Name = "rbt_FavorId4"
        Me.rbt_FavorId4.Size = New System.Drawing.Size(63, 19)
        Me.rbt_FavorId4.TabIndex = 19
        Me.rbt_FavorId4.Text = "ICD10"
        Me.rbt_FavorId4.UseVisualStyleBackColor = True
        '
        'rbt_FavorId5
        '
        Me.rbt_FavorId5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_FavorId5.AutoSize = True
        Me.rbt_FavorId5.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbt_FavorId5.Location = New System.Drawing.Point(170, 38)
        Me.rbt_FavorId5.Name = "rbt_FavorId5"
        Me.rbt_FavorId5.Size = New System.Drawing.Size(108, 19)
        Me.rbt_FavorId5.TabIndex = 20
        Me.rbt_FavorId5.Text = "ICD10健保科"
        Me.rbt_FavorId5.UseVisualStyleBackColor = True
        '
        'cbo_Insu_Dept
        '
        Me.cbo_Insu_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Insu_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Insu_Dept.DropDownWidth = 20
        Me.cbo_Insu_Dept.DroppedDown = False
        Me.cbo_Insu_Dept.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Insu_Dept.Location = New System.Drawing.Point(285, 36)
        Me.cbo_Insu_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Insu_Dept.Name = "cbo_Insu_Dept"
        Me.cbo_Insu_Dept.SelectedIndex = -1
        Me.cbo_Insu_Dept.SelectedItem = Nothing
        Me.cbo_Insu_Dept.SelectedText = ""
        Me.cbo_Insu_Dept.SelectedValue = ""
        Me.cbo_Insu_Dept.SelectionStart = 0
        Me.cbo_Insu_Dept.Size = New System.Drawing.Size(117, 24)
        Me.cbo_Insu_Dept.TabIndex = 21
        Me.cbo_Insu_Dept.uclDisplayIndex = "0,1"
        Me.cbo_Insu_Dept.uclIsAutoClear = True
        Me.cbo_Insu_Dept.uclIsFirstItemEmpty = True
        Me.cbo_Insu_Dept.uclIsTextMode = False
        Me.cbo_Insu_Dept.uclShowMsg = False
        Me.cbo_Insu_Dept.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(428, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "次分科"
        '
        'cbo_ICD10_Dept
        '
        Me.cbo_ICD10_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_ICD10_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_ICD10_Dept.DropDownWidth = 20
        Me.cbo_ICD10_Dept.DroppedDown = False
        Me.cbo_ICD10_Dept.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_ICD10_Dept.Location = New System.Drawing.Point(491, 36)
        Me.cbo_ICD10_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_ICD10_Dept.Name = "cbo_ICD10_Dept"
        Me.cbo_ICD10_Dept.SelectedIndex = -1
        Me.cbo_ICD10_Dept.SelectedItem = Nothing
        Me.cbo_ICD10_Dept.SelectedText = ""
        Me.cbo_ICD10_Dept.SelectedValue = ""
        Me.cbo_ICD10_Dept.SelectionStart = 0
        Me.cbo_ICD10_Dept.Size = New System.Drawing.Size(83, 24)
        Me.cbo_ICD10_Dept.TabIndex = 23
        Me.cbo_ICD10_Dept.uclDisplayIndex = "0,1"
        Me.cbo_ICD10_Dept.uclIsAutoClear = True
        Me.cbo_ICD10_Dept.uclIsFirstItemEmpty = True
        Me.cbo_ICD10_Dept.uclIsTextMode = False
        Me.cbo_ICD10_Dept.uclShowMsg = False
        Me.cbo_ICD10_Dept.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "診斷代碼"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(206, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "診斷名稱"
        '
        'cbo_Dept
        '
        Me.cbo_Dept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbo_Dept, 2)
        Me.cbo_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Dept.DropDownWidth = 20
        Me.cbo_Dept.DroppedDown = False
        Me.cbo_Dept.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Dept.Location = New System.Drawing.Point(171, 4)
        Me.cbo_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_Dept.Name = "cbo_Dept"
        Me.cbo_Dept.SelectedIndex = -1
        Me.cbo_Dept.SelectedItem = Nothing
        Me.cbo_Dept.SelectedText = ""
        Me.cbo_Dept.SelectedValue = ""
        Me.cbo_Dept.SelectionStart = 0
        Me.cbo_Dept.Size = New System.Drawing.Size(231, 24)
        Me.cbo_Dept.TabIndex = 17
        Me.cbo_Dept.uclDisplayIndex = "0,1"
        Me.cbo_Dept.uclIsAutoClear = True
        Me.cbo_Dept.uclIsFirstItemEmpty = True
        Me.cbo_Dept.uclIsTextMode = False
        Me.cbo_Dept.uclShowMsg = False
        Me.cbo_Dept.uclValueIndex = "0"
        '
        'txt_Diag_Code
        '
        Me.txt_Diag_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Diag_Code.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Diag_Code.Location = New System.Drawing.Point(94, 69)
        Me.txt_Diag_Code.MaxLength = 10
        Me.txt_Diag_Code.Name = "txt_Diag_Code"
        Me.txt_Diag_Code.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Diag_Code.SelectionStart = 0
        Me.txt_Diag_Code.Size = New System.Drawing.Size(70, 27)
        Me.txt_Diag_Code.TabIndex = 27
        Me.txt_Diag_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Diag_Code.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Diag_Code.ToolTipTag = Nothing
        Me.txt_Diag_Code.uclDollarSign = False
        Me.txt_Diag_Code.uclDotCount = 0
        Me.txt_Diag_Code.uclIntCount = 2
        Me.txt_Diag_Code.uclMinus = False
        Me.txt_Diag_Code.uclReadOnly = False
        Me.txt_Diag_Code.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Diag_Code.uclTrimZero = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Query.Location = New System.Drawing.Point(490, 69)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(81, 27)
        Me.btn_Query.TabIndex = 28
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'txt_Diag_Desc
        '
        Me.txt_Diag_Desc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Diag_Desc.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Diag_Desc.Location = New System.Drawing.Point(284, 69)
        Me.txt_Diag_Desc.MaxLength = 10
        Me.txt_Diag_Desc.Name = "txt_Diag_Desc"
        Me.txt_Diag_Desc.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Diag_Desc.SelectionStart = 0
        Me.txt_Diag_Desc.Size = New System.Drawing.Size(118, 27)
        Me.txt_Diag_Desc.TabIndex = 26
        Me.txt_Diag_Desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Diag_Desc.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Diag_Desc.ToolTipTag = Nothing
        Me.txt_Diag_Desc.uclDollarSign = False
        Me.txt_Diag_Desc.uclDotCount = 0
        Me.txt_Diag_Desc.uclIntCount = 2
        Me.txt_Diag_Desc.uclMinus = False
        Me.txt_Diag_Desc.uclReadOnly = False
        Me.txt_Diag_Desc.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Diag_Desc.uclTrimZero = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(873, 132)
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
        Me.dgv_FavorData.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.dgv_Selected.Location = New System.Drawing.Point(589, 3)
        Me.dgv_Selected.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_Selected.MultiSelect = True
        Me.dgv_Selected.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.DeleteAll
        Me.dgv_Selected.Name = "dgv_Selected"
        Me.dgv_Selected.RowHeadersWidth = 41
        Me.dgv_Selected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Selected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Selected.Size = New System.Drawing.Size(375, 127)
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
        'UCLDiagFavorDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 609)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.dgv_Selected)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLDiagFavorDialogUI"
        Me.Text = "常用查詢"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv_Selected As UCLDataGridViewUC
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents dgv_FavorData As UCLDataGridViewUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tre_Category As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbt_FavorId1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId2 As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_Dept As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents rbt_FavorId3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_FavorId5 As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_Insu_Dept As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_ICD10_Dept As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Diag_Desc As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_Diag_Code As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents chk_NoCatag As System.Windows.Forms.CheckBox
End Class