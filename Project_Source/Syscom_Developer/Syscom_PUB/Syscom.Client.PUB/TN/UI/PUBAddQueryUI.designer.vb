<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAddQueryUI
    'Inherits System.Windows.Forms.Form
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.UclTextCodeQueryUI1 = New UCL.UCLTextCodeQueryUI
        Me.txt_OrderCnName = New Syscom.Client.UCL.UCLTextBoxUC
        Me.DGV_KidAdd = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DGV_EmgAdd = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.DGV_DentalAdd = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.DGV_DeptAdd = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.38316!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.61684!))
        Me.TableLayoutPanel1.Controls.Add(Me.UclTextCodeQueryUI1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_OrderCnName, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(992, 50)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'UclTextCodeQueryUI1
        '
        Me.UclTextCodeQueryUI1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.UclTextCodeQueryUI1.doFlag = True
        Me.UclTextCodeQueryUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclTextCodeQueryUI1.Location = New System.Drawing.Point(41, 12)
        Me.UclTextCodeQueryUI1.Margin = New System.Windows.Forms.Padding(0)
        Me.UclTextCodeQueryUI1.Name = "UclTextCodeQueryUI1"
        Me.UclTextCodeQueryUI1.Size = New System.Drawing.Size(158, 26)
        Me.UclTextCodeQueryUI1.TabIndex = 0
        Me.UclTextCodeQueryUI1.uclCboWidth = 122
        Me.UclTextCodeQueryUI1.uclCodeName = ""
        Me.UclTextCodeQueryUI1.uclCodeValue1 = ""
        Me.UclTextCodeQueryUI1.uclCodeValue2 = ""
        Me.UclTextCodeQueryUI1.uclControlFlag = True
        Me.UclTextCodeQueryUI1.uclDisplayIndex = "0,1"
        Me.UclTextCodeQueryUI1.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.UclTextCodeQueryUI1.uclIsCheckDoctorOnDuty = False
        Me.UclTextCodeQueryUI1.uclIsReturnDS = False
        Me.UclTextCodeQueryUI1.uclIsShowMsgBox = True
        Me.UclTextCodeQueryUI1.uclIsTextAutoClear = True
        Me.UclTextCodeQueryUI1.uclQueryField = Nothing
        Me.UclTextCodeQueryUI1.uclQueryValue = Nothing
        Me.UclTextCodeQueryUI1.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.UclTextCodeQueryUI1.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.UclTextCodeQueryUI1.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.UclTextCodeQueryUI1.uclXPosition = 225
        Me.UclTextCodeQueryUI1.uclYPosition = 120
        '
        'txt_OrderCnName
        '
        Me.txt_OrderCnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderCnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderCnName.Location = New System.Drawing.Point(244, 11)
        Me.txt_OrderCnName.MaxLength = 10
        Me.txt_OrderCnName.Name = "txt_OrderCnName"
        Me.txt_OrderCnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderCnName.SelectionStart = 0
        Me.txt_OrderCnName.Size = New System.Drawing.Size(410, 27)
        Me.txt_OrderCnName.TabIndex = 1
        Me.txt_OrderCnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrderCnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrderCnName.uclDollarSign = False
        Me.txt_OrderCnName.uclDotCount = 0
        Me.txt_OrderCnName.uclIntCount = 2
        Me.txt_OrderCnName.uclMinus = False
        Me.txt_OrderCnName.uclReadOnly = False
        Me.txt_OrderCnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'DGV_KidAdd
        '
        Me.DGV_KidAdd.AllowUserToAddRows = False
        Me.DGV_KidAdd.AllowUserToOrderColumns = False
        Me.DGV_KidAdd.AllowUserToResizeColumns = True
        Me.DGV_KidAdd.AllowUserToResizeRows = False
        Me.DGV_KidAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_KidAdd.ColumnHeadersVisible = True
        Me.DGV_KidAdd.CurrentCell = Nothing
        Me.DGV_KidAdd.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_KidAdd.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_KidAdd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.DGV_KidAdd.Location = New System.Drawing.Point(7, 19)
        Me.DGV_KidAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_KidAdd.MultiSelect = False
        Me.DGV_KidAdd.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.DGV_KidAdd.Name = "DGV_KidAdd"
        Me.DGV_KidAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_KidAdd.Size = New System.Drawing.Size(978, 97)
        Me.DGV_KidAdd.TabIndex = 1
        Me.DGV_KidAdd.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.DGV_KidAdd.uclBatchColIndex = ""
        Me.DGV_KidAdd.uclClickToCheck = False
        Me.DGV_KidAdd.uclColumnAlignment = ""
        Me.DGV_KidAdd.uclColumnCheckBox = False
        Me.DGV_KidAdd.uclColumnControlType = ""
        Me.DGV_KidAdd.uclColumnWidth = ""
        Me.DGV_KidAdd.uclDoCellEnter = True
        Me.DGV_KidAdd.uclHasNewRow = False
        Me.DGV_KidAdd.uclHeaderText = ""
        Me.DGV_KidAdd.uclIsAlternatingRowsColors = True
        Me.DGV_KidAdd.uclIsComboBoxGridQuery = True
        Me.DGV_KidAdd.uclIsDoOrderCheck = True
        Me.DGV_KidAdd.uclIsSortable = False
        Me.DGV_KidAdd.uclMultiSelectShowCheckBoxHeader = True
        Me.DGV_KidAdd.uclNonVisibleColIndex = ""
        Me.DGV_KidAdd.uclReadOnly = False
        Me.DGV_KidAdd.uclShowCellBorder = False
        Me.DGV_KidAdd.uclSortColIndex = ""
        Me.DGV_KidAdd.uclTreeMode = False
        Me.DGV_KidAdd.uclVisibleColIndex = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGV_KidAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 129)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "兒童加成"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DGV_EmgAdd)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 213)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 142)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "急件加成"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DGV_DentalAdd)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 361)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(992, 145)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "牙科轉診加成"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DGV_DeptAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 512)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(992, 130)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "科別加成"
        '
        'DGV_EmgAdd
        '
        Me.DGV_EmgAdd.AllowUserToAddRows = False
        Me.DGV_EmgAdd.AllowUserToOrderColumns = False
        Me.DGV_EmgAdd.AllowUserToResizeColumns = True
        Me.DGV_EmgAdd.AllowUserToResizeRows = False
        Me.DGV_EmgAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_EmgAdd.ColumnHeadersVisible = True
        Me.DGV_EmgAdd.CurrentCell = Nothing
        Me.DGV_EmgAdd.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_EmgAdd.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_EmgAdd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.DGV_EmgAdd.Location = New System.Drawing.Point(7, 27)
        Me.DGV_EmgAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_EmgAdd.MultiSelect = False
        Me.DGV_EmgAdd.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.DGV_EmgAdd.Name = "DGV_EmgAdd"
        Me.DGV_EmgAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_EmgAdd.Size = New System.Drawing.Size(978, 104)
        Me.DGV_EmgAdd.TabIndex = 0
        Me.DGV_EmgAdd.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.DGV_EmgAdd.uclBatchColIndex = ""
        Me.DGV_EmgAdd.uclClickToCheck = False
        Me.DGV_EmgAdd.uclColumnAlignment = ""
        Me.DGV_EmgAdd.uclColumnCheckBox = False
        Me.DGV_EmgAdd.uclColumnControlType = ""
        Me.DGV_EmgAdd.uclColumnWidth = ""
        Me.DGV_EmgAdd.uclDoCellEnter = True
        Me.DGV_EmgAdd.uclHasNewRow = False
        Me.DGV_EmgAdd.uclHeaderText = ""
        Me.DGV_EmgAdd.uclIsAlternatingRowsColors = True
        Me.DGV_EmgAdd.uclIsComboBoxGridQuery = True
        Me.DGV_EmgAdd.uclIsDoOrderCheck = True
        Me.DGV_EmgAdd.uclIsSortable = False
        Me.DGV_EmgAdd.uclMultiSelectShowCheckBoxHeader = True
        Me.DGV_EmgAdd.uclNonVisibleColIndex = ""
        Me.DGV_EmgAdd.uclReadOnly = False
        Me.DGV_EmgAdd.uclShowCellBorder = False
        Me.DGV_EmgAdd.uclSortColIndex = ""
        Me.DGV_EmgAdd.uclTreeMode = False
        Me.DGV_EmgAdd.uclVisibleColIndex = ""
        '
        'DGV_DentalAdd
        '
        Me.DGV_DentalAdd.AllowUserToAddRows = False
        Me.DGV_DentalAdd.AllowUserToOrderColumns = False
        Me.DGV_DentalAdd.AllowUserToResizeColumns = True
        Me.DGV_DentalAdd.AllowUserToResizeRows = False
        Me.DGV_DentalAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_DentalAdd.ColumnHeadersVisible = True
        Me.DGV_DentalAdd.CurrentCell = Nothing
        Me.DGV_DentalAdd.DataSource = Nothing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_DentalAdd.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_DentalAdd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.DGV_DentalAdd.Location = New System.Drawing.Point(7, 27)
        Me.DGV_DentalAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_DentalAdd.MultiSelect = False
        Me.DGV_DentalAdd.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.DGV_DentalAdd.Name = "DGV_DentalAdd"
        Me.DGV_DentalAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_DentalAdd.Size = New System.Drawing.Size(978, 109)
        Me.DGV_DentalAdd.TabIndex = 0
        Me.DGV_DentalAdd.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.DGV_DentalAdd.uclBatchColIndex = ""
        Me.DGV_DentalAdd.uclClickToCheck = False
        Me.DGV_DentalAdd.uclColumnAlignment = ""
        Me.DGV_DentalAdd.uclColumnCheckBox = False
        Me.DGV_DentalAdd.uclColumnControlType = ""
        Me.DGV_DentalAdd.uclColumnWidth = ""
        Me.DGV_DentalAdd.uclDoCellEnter = True
        Me.DGV_DentalAdd.uclHasNewRow = False
        Me.DGV_DentalAdd.uclHeaderText = ""
        Me.DGV_DentalAdd.uclIsAlternatingRowsColors = True
        Me.DGV_DentalAdd.uclIsComboBoxGridQuery = True
        Me.DGV_DentalAdd.uclIsDoOrderCheck = True
        Me.DGV_DentalAdd.uclIsSortable = False
        Me.DGV_DentalAdd.uclMultiSelectShowCheckBoxHeader = True
        Me.DGV_DentalAdd.uclNonVisibleColIndex = ""
        Me.DGV_DentalAdd.uclReadOnly = False
        Me.DGV_DentalAdd.uclShowCellBorder = False
        Me.DGV_DentalAdd.uclSortColIndex = ""
        Me.DGV_DentalAdd.uclTreeMode = False
        Me.DGV_DentalAdd.uclVisibleColIndex = ""
        '
        'DGV_DeptAdd
        '
        Me.DGV_DeptAdd.AllowUserToAddRows = False
        Me.DGV_DeptAdd.AllowUserToOrderColumns = False
        Me.DGV_DeptAdd.AllowUserToResizeColumns = True
        Me.DGV_DeptAdd.AllowUserToResizeRows = False
        Me.DGV_DeptAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_DeptAdd.ColumnHeadersVisible = True
        Me.DGV_DeptAdd.CurrentCell = Nothing
        Me.DGV_DeptAdd.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_DeptAdd.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_DeptAdd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.DGV_DeptAdd.Location = New System.Drawing.Point(7, 20)
        Me.DGV_DeptAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV_DeptAdd.MultiSelect = False
        Me.DGV_DeptAdd.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.DGV_DeptAdd.Name = "DGV_DeptAdd"
        Me.DGV_DeptAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_DeptAdd.Size = New System.Drawing.Size(978, 103)
        Me.DGV_DeptAdd.TabIndex = 0
        Me.DGV_DeptAdd.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.DGV_DeptAdd.uclBatchColIndex = ""
        Me.DGV_DeptAdd.uclClickToCheck = False
        Me.DGV_DeptAdd.uclColumnAlignment = ""
        Me.DGV_DeptAdd.uclColumnCheckBox = False
        Me.DGV_DeptAdd.uclColumnControlType = ""
        Me.DGV_DeptAdd.uclColumnWidth = ""
        Me.DGV_DeptAdd.uclDoCellEnter = True
        Me.DGV_DeptAdd.uclHasNewRow = False
        Me.DGV_DeptAdd.uclHeaderText = ""
        Me.DGV_DeptAdd.uclIsAlternatingRowsColors = True
        Me.DGV_DeptAdd.uclIsComboBoxGridQuery = True
        Me.DGV_DeptAdd.uclIsDoOrderCheck = True
        Me.DGV_DeptAdd.uclIsSortable = False
        Me.DGV_DeptAdd.uclMultiSelectShowCheckBoxHeader = True
        Me.DGV_DeptAdd.uclNonVisibleColIndex = ""
        Me.DGV_DeptAdd.uclReadOnly = False
        Me.DGV_DeptAdd.uclShowCellBorder = False
        Me.DGV_DeptAdd.uclSortColIndex = ""
        Me.DGV_DeptAdd.uclTreeMode = False
        Me.DGV_DeptAdd.uclVisibleColIndex = ""
        '
        'PUB_AddQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 646)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUB_AddQuery"
        Me.TabText = "PUB_AddQuery"
        Me.Text = "PUB_AddQuery"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UclTextCodeQueryUI1 As UCL.UCLTextCodeQueryUI
    Friend WithEvents txt_OrderCnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents DGV_KidAdd As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV_EmgAdd As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents DGV_DentalAdd As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents DGV_DeptAdd As Syscom.Client.UCL.UCLDataGridViewUC
End Class
