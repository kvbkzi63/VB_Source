<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobQACreateNewBugUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobQACreateNewBugUC))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_Function = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_IssueLevel = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_IssueClassify = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rtb_IssueDescription = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_FilePath = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Browse = New System.Windows.Forms.Button()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgv_AttFiles = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_IssueSubject = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_System, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Function, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_IssueLevel, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_IssueClassify, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_IssueDescription, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_FilePath, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_AttFiles, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Confirm, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_IssueSubject, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(646, 293)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "所屬子系統"
        '
        'cbo_System
        '
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.DroppedDown = False
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(94, 0)
        Me.cbo_System.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_System.MaxLength = 50
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(219, 24)
        Me.cbo_System.TabIndex = 8
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclIsFirstItemEmpty = True
        Me.cbo_System.uclIsTextMode = False
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'cbo_Function
        '
        Me.cbo_Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Function.DropDownWidth = 20
        Me.cbo_Function.DroppedDown = False
        Me.cbo_Function.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Function.Location = New System.Drawing.Point(425, 0)
        Me.cbo_Function.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Function.MaxLength = 50
        Me.cbo_Function.Name = "cbo_Function"
        Me.cbo_Function.SelectedIndex = -1
        Me.cbo_Function.SelectedItem = Nothing
        Me.cbo_Function.SelectedText = ""
        Me.cbo_Function.SelectedValue = ""
        Me.cbo_Function.SelectionStart = 0
        Me.cbo_Function.Size = New System.Drawing.Size(219, 24)
        Me.cbo_Function.TabIndex = 9
        Me.cbo_Function.uclDisplayIndex = "0,1"
        Me.cbo_Function.uclImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbo_Function.uclIsAutoClear = True
        Me.cbo_Function.uclIsFirstItemEmpty = True
        Me.cbo_Function.uclIsTextMode = False
        Me.cbo_Function.uclShowMsg = False
        Me.cbo_Function.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(350, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "所屬功能"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(35, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "嚴重性"
        '
        'cbo_IssueLevel
        '
        Me.cbo_IssueLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IssueLevel.DropDownWidth = 20
        Me.cbo_IssueLevel.DroppedDown = False
        Me.cbo_IssueLevel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IssueLevel.Location = New System.Drawing.Point(94, 24)
        Me.cbo_IssueLevel.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IssueLevel.MaxLength = 50
        Me.cbo_IssueLevel.Name = "cbo_IssueLevel"
        Me.cbo_IssueLevel.SelectedIndex = -1
        Me.cbo_IssueLevel.SelectedItem = Nothing
        Me.cbo_IssueLevel.SelectedText = ""
        Me.cbo_IssueLevel.SelectedValue = ""
        Me.cbo_IssueLevel.SelectionStart = 0
        Me.cbo_IssueLevel.Size = New System.Drawing.Size(219, 24)
        Me.cbo_IssueLevel.TabIndex = 10
        Me.cbo_IssueLevel.uclDisplayIndex = "0,1"
        Me.cbo_IssueLevel.uclImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbo_IssueLevel.uclIsAutoClear = True
        Me.cbo_IssueLevel.uclIsFirstItemEmpty = True
        Me.cbo_IssueLevel.uclIsTextMode = False
        Me.cbo_IssueLevel.uclShowMsg = False
        Me.cbo_IssueLevel.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(350, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "問題類別"
        '
        'cbo_IssueClassify
        '
        Me.cbo_IssueClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_IssueClassify.DropDownWidth = 20
        Me.cbo_IssueClassify.DroppedDown = False
        Me.cbo_IssueClassify.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_IssueClassify.Location = New System.Drawing.Point(425, 24)
        Me.cbo_IssueClassify.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_IssueClassify.MaxLength = 50
        Me.cbo_IssueClassify.Name = "cbo_IssueClassify"
        Me.cbo_IssueClassify.SelectedIndex = -1
        Me.cbo_IssueClassify.SelectedItem = Nothing
        Me.cbo_IssueClassify.SelectedText = ""
        Me.cbo_IssueClassify.SelectedValue = ""
        Me.cbo_IssueClassify.SelectionStart = 0
        Me.cbo_IssueClassify.Size = New System.Drawing.Size(219, 24)
        Me.cbo_IssueClassify.TabIndex = 11
        Me.cbo_IssueClassify.uclDisplayIndex = "0,1"
        Me.cbo_IssueClassify.uclImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbo_IssueClassify.uclIsAutoClear = True
        Me.cbo_IssueClassify.uclIsFirstItemEmpty = True
        Me.cbo_IssueClassify.uclIsTextMode = False
        Me.cbo_IssueClassify.uclShowMsg = False
        Me.cbo_IssueClassify.uclValueIndex = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(19, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "問題主述"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(19, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "問題描述"
        '
        'rtb_IssueDescription
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.rtb_IssueDescription, 2)
        Me.rtb_IssueDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_IssueDescription.Location = New System.Drawing.Point(97, 84)
        Me.rtb_IssueDescription.Name = "rtb_IssueDescription"
        Me.rtb_IssueDescription.Size = New System.Drawing.Size(325, 86)
        Me.rtb_IssueDescription.TabIndex = 7
        Me.rtb_IssueDescription.Text = ""
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "附件上傳"
        '
        'txt_FilePath
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_FilePath, 2)
        Me.txt_FilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_FilePath.Enabled = False
        Me.txt_FilePath.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_FilePath.HideSelection = True
        Me.txt_FilePath.Location = New System.Drawing.Point(97, 176)
        Me.txt_FilePath.MaxLength = 32767
        Me.txt_FilePath.Name = "txt_FilePath"
        Me.txt_FilePath.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_FilePath.SelectionStart = 0
        Me.txt_FilePath.Size = New System.Drawing.Size(325, 27)
        Me.txt_FilePath.TabIndex = 13
        Me.txt_FilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_FilePath.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_FilePath.ToolTipTag = Nothing
        Me.txt_FilePath.uclDollarSign = False
        Me.txt_FilePath.uclDotCount = 0
        Me.txt_FilePath.uclImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txt_FilePath.uclIntCount = 2
        Me.txt_FilePath.uclMinus = False
        Me.txt_FilePath.uclReadOnly = False
        Me.txt_FilePath.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_FilePath.uclTransferForFractions = False
        Me.txt_FilePath.uclTrimZero = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Browse)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Add)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(428, 176)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(198, 30)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'btn_Browse
        '
        Me.btn_Browse.Location = New System.Drawing.Point(3, 3)
        Me.btn_Browse.Name = "btn_Browse"
        Me.btn_Browse.Size = New System.Drawing.Size(61, 23)
        Me.btn_Browse.TabIndex = 0
        Me.btn_Browse.Text = "瀏覽"
        Me.btn_Browse.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(70, 3)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(61, 23)
        Me.btn_Add.TabIndex = 1
        Me.btn_Add.Text = "上傳"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(3, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "請記得存檔"
        '
        'dgv_AttFiles
        '
        Me.dgv_AttFiles.AllowUserToAddRows = False
        Me.dgv_AttFiles.AllowUserToOrderColumns = False
        Me.dgv_AttFiles.AllowUserToResizeColumns = True
        Me.dgv_AttFiles.AllowUserToResizeRows = False
        Me.dgv_AttFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_AttFiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_AttFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_AttFiles.ColumnHeadersHeight = 4
        Me.dgv_AttFiles.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv_AttFiles, 3)
        Me.dgv_AttFiles.CurrentCell = Nothing
        Me.dgv_AttFiles.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_AttFiles.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_AttFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_AttFiles.Location = New System.Drawing.Point(98, 213)
        Me.dgv_AttFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_AttFiles.MultiSelect = False
        Me.dgv_AttFiles.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_AttFiles.Name = "dgv_AttFiles"
        Me.dgv_AttFiles.RowHeadersWidth = 41
        Me.dgv_AttFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_AttFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_AttFiles.Size = New System.Drawing.Size(528, 91)
        Me.dgv_AttFiles.TabIndex = 15
        Me.dgv_AttFiles.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_AttFiles.uclBatchColIndex = ""
        Me.dgv_AttFiles.uclClickToCheck = False
        Me.dgv_AttFiles.uclColumnAlignment = ""
        Me.dgv_AttFiles.uclColumnCheckBox = False
        Me.dgv_AttFiles.uclColumnControlType = ""
        Me.dgv_AttFiles.uclColumnWidth = ""
        Me.dgv_AttFiles.uclDoCellEnter = True
        Me.dgv_AttFiles.uclHasNewRow = False
        Me.dgv_AttFiles.uclHeaderText = ""
        Me.dgv_AttFiles.uclIsAlternatingRowsColors = True
        Me.dgv_AttFiles.uclIsComboBoxGridQuery = True
        Me.dgv_AttFiles.uclIsComboxClickTriggerDropDown = False
        Me.dgv_AttFiles.uclIsDoOrderCheck = True
        Me.dgv_AttFiles.uclIsDoQueryComboBoxGrid = True
        Me.dgv_AttFiles.uclIsSortable = False
        Me.dgv_AttFiles.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_AttFiles.uclNonVisibleColIndex = ""
        Me.dgv_AttFiles.uclReadOnly = False
        Me.dgv_AttFiles.uclSelectedCellBorder = False
        Me.dgv_AttFiles.uclSelectedCellBorderColors = System.Drawing.Color.DeepSkyBlue
        Me.dgv_AttFiles.uclSelectedCellBorderSize = 4
        Me.dgv_AttFiles.uclSelectedFirstShowCol = 0
        Me.dgv_AttFiles.uclSelectedLastShowCol = -1
        Me.dgv_AttFiles.uclShowCellBorder = False
        Me.dgv_AttFiles.uclSortColIndex = ""
        Me.dgv_AttFiles.uclTreeMode = False
        Me.dgv_AttFiles.uclVisibleColIndex = ""
        '
        'btn_Confirm
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btn_Confirm, 2)
        Me.btn_Confirm.Location = New System.Drawing.Point(97, 311)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(323, 34)
        Me.btn_Confirm.TabIndex = 16
        Me.btn_Confirm.Text = "存檔"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(428, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "(限150字內)"
        '
        'txt_IssueSubject
        '
        Me.txt_IssueSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_IssueSubject.Location = New System.Drawing.Point(97, 51)
        Me.txt_IssueSubject.Name = "txt_IssueSubject"
        Me.txt_IssueSubject.Size = New System.Drawing.Size(213, 27)
        Me.txt_IssueSubject.TabIndex = 18
        '
        'JobQACreateNewBugUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "JobQACreateNewBugUC"
        Me.Size = New System.Drawing.Size(646, 293)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents rtb_IssueDescription As Windows.Forms.RichTextBox
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_Function As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_IssueLevel As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_IssueClassify As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txt_FilePath As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Browse As Windows.Forms.Button
    Friend WithEvents btn_Add As Windows.Forms.Button
    Friend WithEvents dgv_AttFiles As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents btn_Confirm As Windows.Forms.Button
    Friend WithEvents txt_IssueSubject As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
End Class
