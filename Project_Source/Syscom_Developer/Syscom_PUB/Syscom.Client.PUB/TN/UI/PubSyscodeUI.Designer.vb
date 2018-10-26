<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubSyscodeUI

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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_Type_Name = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_Type_Name = New System.Windows.Forms.Label()
        Me.txt_Type_Id = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_Type_Id = New System.Windows.Forms.Label()
        Me.dgv_Data = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.48438!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.51563!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_Data, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Delete, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Save, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Clear, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Query, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.48837!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.51163!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 555.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 6)
        Me.Panel1.Controls.Add(Me.txt_Type_Name)
        Me.Panel1.Controls.Add(Me.lbl_Type_Name)
        Me.Panel1.Controls.Add(Me.txt_Type_Id)
        Me.Panel1.Controls.Add(Me.lbl_Type_Id)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 40)
        Me.Panel1.TabIndex = 0
        '
        'txt_Type_Name
        '
        Me.txt_Type_Name.Enabled = False
        Me.txt_Type_Name.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Type_Name.Location = New System.Drawing.Point(410, 6)
        Me.txt_Type_Name.MaxLength = 50
        Me.txt_Type_Name.Name = "txt_Type_Name"
        Me.txt_Type_Name.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Type_Name.SelectionStart = 0
        Me.txt_Type_Name.Size = New System.Drawing.Size(476, 27)
        Me.txt_Type_Name.TabIndex = 3
        Me.txt_Type_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Type_Name.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Type_Name.uclDollarSign = False
        Me.txt_Type_Name.uclDotCount = 0
        Me.txt_Type_Name.uclIntCount = 10
        Me.txt_Type_Name.uclMinus = False
        Me.txt_Type_Name.uclReadOnly = False
        Me.txt_Type_Name.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_Type_Name.uclTrimZero = True
        '
        'lbl_Type_Name
        '
        Me.lbl_Type_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Type_Name.AutoSize = True
        Me.lbl_Type_Name.Location = New System.Drawing.Point(332, 11)
        Me.lbl_Type_Name.Name = "lbl_Type_Name"
        Me.lbl_Type_Name.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Type_Name.TabIndex = 2
        Me.lbl_Type_Name.Text = "類別名稱"
        '
        'txt_Type_Id
        '
        Me.txt_Type_Id.Enabled = False
        Me.txt_Type_Id.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Type_Id.Location = New System.Drawing.Point(113, 6)
        Me.txt_Type_Id.MaxLength = 20
        Me.txt_Type_Id.Name = "txt_Type_Id"
        Me.txt_Type_Id.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Type_Id.SelectionStart = 0
        Me.txt_Type_Id.Size = New System.Drawing.Size(167, 27)
        Me.txt_Type_Id.TabIndex = 1
        Me.txt_Type_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Type_Id.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Type_Id.uclDollarSign = False
        Me.txt_Type_Id.uclDotCount = 0
        Me.txt_Type_Id.uclIntCount = 10
        Me.txt_Type_Id.uclMinus = False
        Me.txt_Type_Id.uclReadOnly = False
        Me.txt_Type_Id.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_Type_Id.uclTrimZero = True
        '
        'lbl_Type_Id
        '
        Me.lbl_Type_Id.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Type_Id.AutoSize = True
        Me.lbl_Type_Id.Location = New System.Drawing.Point(1, 11)
        Me.lbl_Type_Id.Name = "lbl_Type_Id"
        Me.lbl_Type_Id.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Type_Id.TabIndex = 0
        Me.lbl_Type_Id.Text = "類別代碼"
        '
        'dgv_Data
        '
        Me.dgv_Data.AllowUserToAddRows = False
        Me.dgv_Data.AllowUserToOrderColumns = False
        Me.dgv_Data.AllowUserToResizeColumns = True
        Me.dgv_Data.AllowUserToResizeRows = False
        Me.dgv_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Data.ColumnHeadersHeight = 4
        Me.dgv_Data.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv_Data, 6)
        Me.dgv_Data.CurrentCell = Nothing
        Me.dgv_Data.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Data.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Data.Location = New System.Drawing.Point(4, 90)
        Me.dgv_Data.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Data.MultiSelect = True
        Me.dgv_Data.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.RowHeadersWidth = 41
        Me.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Data.Size = New System.Drawing.Size(956, 548)
        Me.dgv_Data.TabIndex = 5
        Me.dgv_Data.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Data.uclBatchColIndex = ""
        Me.dgv_Data.uclClickToCheck = False
        Me.dgv_Data.uclColumnAlignment = ""
        Me.dgv_Data.uclColumnCheckBox = True
        Me.dgv_Data.uclColumnControlType = ""
        Me.dgv_Data.uclColumnWidth = ""
        Me.dgv_Data.uclDoCellEnter = True
        Me.dgv_Data.uclHasNewRow = True
        Me.dgv_Data.uclHeaderText = ""
        Me.dgv_Data.uclIsAlternatingRowsColors = True
        Me.dgv_Data.uclIsComboBoxGridQuery = True
        Me.dgv_Data.uclIsDoOrderCheck = True
        Me.dgv_Data.uclIsSortable = False
        Me.dgv_Data.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Data.uclNonVisibleColIndex = ""
        Me.dgv_Data.uclReadOnly = False
        Me.dgv_Data.uclShowCellBorder = False
        Me.dgv_Data.uclSortColIndex = ""
        Me.dgv_Data.uclTreeMode = False
        Me.dgv_Data.uclVisibleColIndex = ""
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Delete.Location = New System.Drawing.Point(863, 52)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_Delete.TabIndex = 2
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Save.Location = New System.Drawing.Point(765, 52)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(89, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Location = New System.Drawing.Point(667, 52)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 4
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        Me.btn_Clear.Visible = False
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Query.Location = New System.Drawing.Point(572, 52)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(89, 28)
        Me.btn_Query.TabIndex = 3
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        Me.btn_Query.Visible = False
        '
        'PubSyscodeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PubSyscodeUI"
        Me.TabText = "公用代碼維護"
        Me.Text = "公用代碼維護"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_Type_Id As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_Type_Id As System.Windows.Forms.Label
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents dgv_Data As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents txt_Type_Name As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_Type_Name As System.Windows.Forms.Label
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
End Class
