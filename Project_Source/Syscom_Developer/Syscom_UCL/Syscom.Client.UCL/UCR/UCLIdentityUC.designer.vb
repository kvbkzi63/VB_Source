<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLIdentityUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
    Public Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCLIdentityUC))
        Me.lbl_SubId = New System.Windows.Forms.Label()
        Me.lbl_DisId = New System.Windows.Forms.Label()
        Me.lbl_Contract = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_SubId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lbl_part_code = New System.Windows.Forms.Label()
        Me.lbl_medical_type_id = New System.Windows.Forms.Label()
        Me.cbo_medical_type_id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_DisId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_part_code = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_Contract1 = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lbl_card_sn = New System.Windows.Forms.Label()
        Me.txt_card_sn = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cbo_Contract2 = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_MainId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_caseTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_SubId
        '
        Me.lbl_SubId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SubId.AutoSize = True
        Me.lbl_SubId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_SubId.Location = New System.Drawing.Point(4, 14)
        Me.lbl_SubId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_SubId.Name = "lbl_SubId"
        Me.lbl_SubId.Size = New System.Drawing.Size(40, 16)
        Me.lbl_SubId.TabIndex = 2
        Me.lbl_SubId.Text = "身份"
        '
        'lbl_DisId
        '
        Me.lbl_DisId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DisId.AutoSize = True
        Me.lbl_DisId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_DisId.Location = New System.Drawing.Point(129, 14)
        Me.lbl_DisId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_DisId.Name = "lbl_DisId"
        Me.lbl_DisId.Size = New System.Drawing.Size(40, 16)
        Me.lbl_DisId.TabIndex = 4
        Me.lbl_DisId.Text = "優免"
        '
        'lbl_Contract
        '
        Me.lbl_Contract.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Contract.AutoSize = True
        Me.lbl_Contract.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_Contract.Location = New System.Drawing.Point(768, 14)
        Me.lbl_Contract.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Contract.Name = "lbl_Contract"
        Me.lbl_Contract.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Contract.TabIndex = 6
        Me.lbl_Contract.Text = "合約"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 19
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_SubId, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_SubId, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_part_code, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_medical_type_id, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_DisId, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_medical_type_id, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_DisId, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_part_code, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Contract1, 13, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_card_sn, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_card_sn, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 15, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Contract, 12, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 16, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Contract2, 14, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_MainId, 17, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_caseTypeId, 18, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1065, 44)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'cbo_SubId
        '
        Me.cbo_SubId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SubId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SubId.DropDownWidth = 20
        Me.cbo_SubId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SubId.Location = New System.Drawing.Point(48, 10)
        Me.cbo_SubId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SubId.Name = "cbo_SubId"
        Me.cbo_SubId.SelectedIndex = -1
        Me.cbo_SubId.SelectedItem = Nothing
        Me.cbo_SubId.SelectedText = ""
        Me.cbo_SubId.SelectedValue = ""
        Me.cbo_SubId.SelectionStart = 0
        Me.cbo_SubId.Size = New System.Drawing.Size(77, 24)
        Me.cbo_SubId.TabIndex = 3
        Me.cbo_SubId.uclDisplayIndex = "0,1"
        Me.cbo_SubId.uclIsAutoClear = True
        Me.cbo_SubId.uclIsFirstItemEmpty = True
        Me.cbo_SubId.uclIsTextMode = False
        Me.cbo_SubId.uclShowMsg = False
        Me.cbo_SubId.uclValueIndex = "0"
        '
        'lbl_part_code
        '
        Me.lbl_part_code.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_part_code.AutoSize = True
        Me.lbl_part_code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_part_code.Location = New System.Drawing.Point(534, 14)
        Me.lbl_part_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_part_code.Name = "lbl_part_code"
        Me.lbl_part_code.Size = New System.Drawing.Size(40, 16)
        Me.lbl_part_code.TabIndex = 13
        Me.lbl_part_code.Text = "部負"
        '
        'lbl_medical_type_id
        '
        Me.lbl_medical_type_id.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_medical_type_id.AutoSize = True
        Me.lbl_medical_type_id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_medical_type_id.Location = New System.Drawing.Point(310, 14)
        Me.lbl_medical_type_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_medical_type_id.Name = "lbl_medical_type_id"
        Me.lbl_medical_type_id.Size = New System.Drawing.Size(72, 16)
        Me.lbl_medical_type_id.TabIndex = 11
        Me.lbl_medical_type_id.Text = "看診目的"
        '
        'cbo_medical_type_id
        '
        Me.cbo_medical_type_id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_medical_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_medical_type_id.DropDownWidth = 20
        Me.cbo_medical_type_id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_medical_type_id.Location = New System.Drawing.Point(386, 10)
        Me.cbo_medical_type_id.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_medical_type_id.Name = "cbo_medical_type_id"
        Me.cbo_medical_type_id.SelectedIndex = -1
        Me.cbo_medical_type_id.SelectedItem = Nothing
        Me.cbo_medical_type_id.SelectedText = ""
        Me.cbo_medical_type_id.SelectedValue = ""
        Me.cbo_medical_type_id.SelectionStart = 0
        Me.cbo_medical_type_id.Size = New System.Drawing.Size(144, 24)
        Me.cbo_medical_type_id.TabIndex = 12
        Me.cbo_medical_type_id.uclDisplayIndex = "0,1"
        Me.cbo_medical_type_id.uclIsAutoClear = True
        Me.cbo_medical_type_id.uclIsFirstItemEmpty = True
        Me.cbo_medical_type_id.uclIsTextMode = False
        Me.cbo_medical_type_id.uclShowMsg = False
        Me.cbo_medical_type_id.uclValueIndex = "0"
        '
        'cbo_DisId
        '
        Me.cbo_DisId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_DisId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_DisId.DropDownWidth = 20
        Me.cbo_DisId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_DisId.Location = New System.Drawing.Point(173, 10)
        Me.cbo_DisId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_DisId.Name = "cbo_DisId"
        Me.cbo_DisId.SelectedIndex = -1
        Me.cbo_DisId.SelectedItem = Nothing
        Me.cbo_DisId.SelectedText = ""
        Me.cbo_DisId.SelectedValue = ""
        Me.cbo_DisId.SelectionStart = 0
        Me.cbo_DisId.Size = New System.Drawing.Size(133, 24)
        Me.cbo_DisId.TabIndex = 5
        Me.cbo_DisId.uclDisplayIndex = "0,1"
        Me.cbo_DisId.uclIsAutoClear = True
        Me.cbo_DisId.uclIsFirstItemEmpty = True
        Me.cbo_DisId.uclIsTextMode = False
        Me.cbo_DisId.uclShowMsg = False
        Me.cbo_DisId.uclValueIndex = "0"
        '
        'cbo_part_code
        '
        Me.cbo_part_code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_part_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_part_code.DropDownWidth = 20
        Me.cbo_part_code.Enabled = False
        Me.cbo_part_code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_part_code.Location = New System.Drawing.Point(578, 10)
        Me.cbo_part_code.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_part_code.Name = "cbo_part_code"
        Me.cbo_part_code.SelectedIndex = -1
        Me.cbo_part_code.SelectedItem = Nothing
        Me.cbo_part_code.SelectedText = ""
        Me.cbo_part_code.SelectedValue = ""
        Me.cbo_part_code.SelectionStart = 0
        Me.cbo_part_code.Size = New System.Drawing.Size(77, 24)
        Me.cbo_part_code.TabIndex = 14
        Me.cbo_part_code.uclDisplayIndex = "0,1"
        Me.cbo_part_code.uclIsAutoClear = True
        Me.cbo_part_code.uclIsFirstItemEmpty = True
        Me.cbo_part_code.uclIsTextMode = False
        Me.cbo_part_code.uclShowMsg = False
        Me.cbo_part_code.uclValueIndex = "0"
        '
        'cbo_Contract1
        '
        Me.cbo_Contract1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Contract1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Contract1.DropDownWidth = 20
        Me.cbo_Contract1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Contract1.Location = New System.Drawing.Point(812, 10)
        Me.cbo_Contract1.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.cbo_Contract1.Name = "cbo_Contract1"
        Me.cbo_Contract1.SelectedIndex = -1
        Me.cbo_Contract1.SelectedItem = Nothing
        Me.cbo_Contract1.SelectedText = ""
        Me.cbo_Contract1.SelectedValue = ""
        Me.cbo_Contract1.SelectionStart = 0
        Me.cbo_Contract1.Size = New System.Drawing.Size(124, 24)
        Me.cbo_Contract1.TabIndex = 7
        Me.cbo_Contract1.uclDisplayIndex = "0,1"
        Me.cbo_Contract1.uclIsAutoClear = True
        Me.cbo_Contract1.uclIsFirstItemEmpty = True
        Me.cbo_Contract1.uclIsTextMode = False
        Me.cbo_Contract1.uclShowMsg = False
        Me.cbo_Contract1.uclValueIndex = "0"
        '
        'lbl_card_sn
        '
        Me.lbl_card_sn.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_card_sn.AutoSize = True
        Me.lbl_card_sn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_card_sn.Location = New System.Drawing.Point(659, 14)
        Me.lbl_card_sn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_card_sn.Name = "lbl_card_sn"
        Me.lbl_card_sn.Size = New System.Drawing.Size(40, 16)
        Me.lbl_card_sn.TabIndex = 15
        Me.lbl_card_sn.Text = "卡序"
        '
        'txt_card_sn
        '
        Me.txt_card_sn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_card_sn.Enabled = False
        Me.txt_card_sn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_card_sn.Location = New System.Drawing.Point(706, 8)
        Me.txt_card_sn.MaxLength = 10
        Me.txt_card_sn.Name = "txt_card_sn"
        Me.txt_card_sn.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_card_sn.SelectionStart = 0
        Me.txt_card_sn.Size = New System.Drawing.Size(55, 27)
        Me.txt_card_sn.TabIndex = 16
        Me.txt_card_sn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_card_sn.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_card_sn.uclDollarSign = False
        Me.txt_card_sn.uclDotCount = 0
        Me.txt_card_sn.uclIntCount = 2
        Me.txt_card_sn.uclMinus = False
        Me.txt_card_sn.uclReadOnly = False
        Me.txt_card_sn.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_card_sn.uclTrimZero = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1066, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "1"
        Me.Label1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBox1.Location = New System.Drawing.Point(1088, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(20, 27)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Visible = False
        '
        'cbo_Contract2
        '
        Me.cbo_Contract2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Contract2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Contract2.DropDownWidth = 20
        Me.cbo_Contract2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Contract2.Location = New System.Drawing.Point(939, 10)
        Me.cbo_Contract2.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Contract2.Name = "cbo_Contract2"
        Me.cbo_Contract2.SelectedIndex = -1
        Me.cbo_Contract2.SelectedItem = Nothing
        Me.cbo_Contract2.SelectedText = ""
        Me.cbo_Contract2.SelectedValue = ""
        Me.cbo_Contract2.SelectionStart = 0
        Me.cbo_Contract2.Size = New System.Drawing.Size(124, 24)
        Me.cbo_Contract2.TabIndex = 8
        Me.cbo_Contract2.uclDisplayIndex = "0,1"
        Me.cbo_Contract2.uclIsAutoClear = True
        Me.cbo_Contract2.uclIsFirstItemEmpty = True
        Me.cbo_Contract2.uclIsTextMode = False
        Me.cbo_Contract2.uclShowMsg = False
        Me.cbo_Contract2.uclValueIndex = "0"
        '
        'cbo_MainId
        '
        Me.cbo_MainId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_MainId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_MainId.DropDownWidth = 20
        Me.cbo_MainId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_MainId.Location = New System.Drawing.Point(1111, 10)
        Me.cbo_MainId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_MainId.Name = "cbo_MainId"
        Me.cbo_MainId.SelectedIndex = -1
        Me.cbo_MainId.SelectedItem = Nothing
        Me.cbo_MainId.SelectedText = ""
        Me.cbo_MainId.SelectedValue = ""
        Me.cbo_MainId.SelectionStart = 0
        Me.cbo_MainId.Size = New System.Drawing.Size(20, 24)
        Me.cbo_MainId.TabIndex = 1
        Me.cbo_MainId.uclDisplayIndex = "0,1"
        Me.cbo_MainId.uclIsAutoClear = True
        Me.cbo_MainId.uclIsFirstItemEmpty = True
        Me.cbo_MainId.uclIsTextMode = False
        Me.cbo_MainId.uclShowMsg = False
        Me.cbo_MainId.uclValueIndex = "0"
        Me.cbo_MainId.Visible = False
        '
        'cbo_caseTypeId
        '
        Me.cbo_caseTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_caseTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_caseTypeId.DropDownWidth = 20
        Me.cbo_caseTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_caseTypeId.Location = New System.Drawing.Point(1131, 10)
        Me.cbo_caseTypeId.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_caseTypeId.Name = "cbo_caseTypeId"
        Me.cbo_caseTypeId.SelectedIndex = -1
        Me.cbo_caseTypeId.SelectedItem = Nothing
        Me.cbo_caseTypeId.SelectedText = ""
        Me.cbo_caseTypeId.SelectedValue = ""
        Me.cbo_caseTypeId.SelectionStart = 0
        Me.cbo_caseTypeId.Size = New System.Drawing.Size(32, 24)
        Me.cbo_caseTypeId.TabIndex = 17
        Me.cbo_caseTypeId.uclDisplayIndex = "0,1"
        Me.cbo_caseTypeId.uclIsAutoClear = True
        Me.cbo_caseTypeId.uclIsFirstItemEmpty = True
        Me.cbo_caseTypeId.uclIsTextMode = False
        Me.cbo_caseTypeId.uclShowMsg = False
        Me.cbo_caseTypeId.uclValueIndex = "0"
        Me.cbo_caseTypeId.Visible = False
        '
        'UCLIdentityUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLIdentityUC"
        Me.Size = New System.Drawing.Size(1065, 44)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_SubId As System.Windows.Forms.Label
    Friend WithEvents lbl_DisId As System.Windows.Forms.Label
    Friend WithEvents lbl_Contract As System.Windows.Forms.Label
    Friend WithEvents cbo_SubId As Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_DisId As Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_Contract1 As Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_Contract2 As Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_medical_type_id As System.Windows.Forms.Label
    Friend WithEvents cbo_medical_type_id As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lbl_part_code As System.Windows.Forms.Label
    Friend WithEvents cbo_part_code As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lbl_card_sn As System.Windows.Forms.Label
    Friend WithEvents txt_card_sn As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_MainId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_caseTypeId As Syscom.Client.UCL.UCLComboBoxUC

End Class
