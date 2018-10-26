<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubHospitalUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PubHospitalUI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_Data = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Language_Type_Id = New System.Windows.Forms.Label()
        Me.cbo_Language_Type_Id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lbl_Hospital_Code = New System.Windows.Forms.Label()
        Me.txt_Hospital_Code = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_Copy = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 642)
        Me.Panel1.TabIndex = 0
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
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_Data, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'dgv_Data
        '
        Me.dgv_Data.AllowUserToAddRows = False
        Me.dgv_Data.AllowUserToOrderColumns = False
        Me.dgv_Data.AllowUserToResizeColumns = True
        Me.dgv_Data.AllowUserToResizeRows = False
        Me.dgv_Data.AutoSize = True
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
        Me.dgv_Data.Location = New System.Drawing.Point(6, 84)
        Me.dgv_Data.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_Data.MultiSelect = True
        Me.dgv_Data.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.RowHeadersWidth = 41
        Me.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Data.Size = New System.Drawing.Size(952, 553)
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Language_Type_Id)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbo_Language_Type_Id)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_Hospital_Code)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_Hospital_Code)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(958, 33)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'Language_Type_Id
        '
        Me.Language_Type_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Language_Type_Id.AutoSize = True
        Me.Language_Type_Id.Location = New System.Drawing.Point(3, 8)
        Me.Language_Type_Id.Name = "Language_Type_Id"
        Me.Language_Type_Id.Size = New System.Drawing.Size(40, 16)
        Me.Language_Type_Id.TabIndex = 0
        Me.Language_Type_Id.Text = "類別"
        '
        'cbo_Language_Type_Id
        '
        Me.cbo_Language_Type_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Language_Type_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Language_Type_Id.DropDownWidth = 20
        Me.cbo_Language_Type_Id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Language_Type_Id.Location = New System.Drawing.Point(46, 4)
        Me.cbo_Language_Type_Id.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Language_Type_Id.Name = "cbo_Language_Type_Id"
        Me.cbo_Language_Type_Id.SelectedIndex = -1
        Me.cbo_Language_Type_Id.SelectedItem = Nothing
        Me.cbo_Language_Type_Id.SelectedText = ""
        Me.cbo_Language_Type_Id.SelectedValue = ""
        Me.cbo_Language_Type_Id.SelectionStart = 0
        Me.cbo_Language_Type_Id.Size = New System.Drawing.Size(125, 24)
        Me.cbo_Language_Type_Id.TabIndex = 1
        Me.cbo_Language_Type_Id.uclDisplayIndex = "0,1"
        Me.cbo_Language_Type_Id.uclIsAutoClear = True
        Me.cbo_Language_Type_Id.uclIsTextMode = False
        Me.cbo_Language_Type_Id.uclShowMsg = False
        Me.cbo_Language_Type_Id.uclValueIndex = "0"
        '
        'lbl_Hospital_Code
        '
        Me.lbl_Hospital_Code.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Hospital_Code.AutoSize = True
        Me.lbl_Hospital_Code.Location = New System.Drawing.Point(174, 8)
        Me.lbl_Hospital_Code.Name = "lbl_Hospital_Code"
        Me.lbl_Hospital_Code.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Hospital_Code.TabIndex = 3
        Me.lbl_Hospital_Code.Text = "醫院代碼"
        '
        'txt_Hospital_Code
        '
        Me.txt_Hospital_Code.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Hospital_Code.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Hospital_Code.Location = New System.Drawing.Point(252, 3)
        Me.txt_Hospital_Code.MaxLength = 20
        Me.txt_Hospital_Code.Name = "txt_Hospital_Code"
        Me.txt_Hospital_Code.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Hospital_Code.SelectionStart = 0
        Me.txt_Hospital_Code.Size = New System.Drawing.Size(281, 27)
        Me.txt_Hospital_Code.TabIndex = 2
        Me.txt_Hospital_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Hospital_Code.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Hospital_Code.uclDollarSign = False
        Me.txt_Hospital_Code.uclDotCount = 0
        Me.txt_Hospital_Code.uclIntCount = 2
        Me.txt_Hospital_Code.uclMinus = False
        Me.txt_Hospital_Code.uclReadOnly = False
        Me.txt_Hospital_Code.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Hospital_Code.uclTrimZero = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel2, 6)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Save)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Copy)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 42)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(958, 34)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Clear.Location = New System.Drawing.Point(865, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 4
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Query.Location = New System.Drawing.Point(769, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 3
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Delete.Location = New System.Drawing.Point(673, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_Delete.TabIndex = 2
        Me.btn_Delete.Text = "SF12-刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Save.Location = New System.Drawing.Point(578, 3)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(89, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_Copy
        '
        Me.btn_Copy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Copy.Location = New System.Drawing.Point(483, 3)
        Me.btn_Copy.Name = "btn_Copy"
        Me.btn_Copy.Size = New System.Drawing.Size(89, 28)
        Me.btn_Copy.TabIndex = 5
        Me.btn_Copy.Text = "F10-複製"
        Me.btn_Copy.UseVisualStyleBackColor = True
        '
        'PubHospitalUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PubHospitalUI"
        Me.TabText = "系統參數設定維護"
        Me.Text = "醫事機構維護"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv_Data As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Language_Type_Id As System.Windows.Forms.Label
    Friend WithEvents cbo_Language_Type_Id As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lbl_Hospital_Code As System.Windows.Forms.Label
    Friend WithEvents txt_Hospital_Code As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents btn_Copy As System.Windows.Forms.Button
End Class
