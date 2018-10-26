<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPreventiveCareSetupUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPreventiveCareSetupUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_CareItem = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Serialnumber = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_OrderName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_Agecontrol = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_AgeMin = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_AgeMax = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_instruction = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.rich_instruction = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_sex = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Sconditions = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Advisoryunit = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Indiagnosis = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_note = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_Packagecode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Cmb_OrderCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_OrderCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 266)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1195, 383)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(1193, 346)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(1193, 346)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 5
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.tlp_Main.Controls.Add(Me.Label9, 0, 6)
        Me.tlp_Main.Controls.Add(Me.Label7, 0, 5)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.cmb_CareItem, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Serialnumber, 1, 2)
        Me.tlp_Main.Controls.Add(Me.Label6, 0, 3)
        Me.tlp_Main.Controls.Add(Me.txt_OrderName, 1, 3)
        Me.tlp_Main.Controls.Add(Me.Label8, 0, 4)
        Me.tlp_Main.Controls.Add(Me.cmb_Agecontrol, 1, 4)
        Me.tlp_Main.Controls.Add(Me.txt_AgeMin, 1, 5)
        Me.tlp_Main.Controls.Add(Me.txt_AgeMax, 1, 6)
        Me.tlp_Main.Controls.Add(Me.Label3, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_instruction, 4, 0)
        Me.tlp_Main.Controls.Add(Me.rich_instruction, 3, 0)
        Me.tlp_Main.Controls.Add(Me.Label5, 2, 1)
        Me.tlp_Main.Controls.Add(Me.cmb_sex, 3, 1)
        Me.tlp_Main.Controls.Add(Me.Label11, 2, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Sconditions, 3, 2)
        Me.tlp_Main.Controls.Add(Me.Label14, 2, 3)
        Me.tlp_Main.Controls.Add(Me.txt_Advisoryunit, 3, 3)
        Me.tlp_Main.Controls.Add(Me.Label12, 2, 4)
        Me.tlp_Main.Controls.Add(Me.txt_Indiagnosis, 3, 4)
        Me.tlp_Main.Controls.Add(Me.Label13, 2, 5)
        Me.tlp_Main.Controls.Add(Me.txt_note, 3, 5)
        Me.tlp_Main.Controls.Add(Me.Label10, 2, 6)
        Me.tlp_Main.Controls.Add(Me.txt_Packagecode, 3, 6)
        Me.tlp_Main.Controls.Add(Me.Cmb_OrderCode, 4, 1)
        Me.tlp_Main.Controls.Add(Me.txt_OrderCode, 1, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 7
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(1195, 266)
        Me.tlp_Main.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(26, 239)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 16)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "年齡迄(<=)："
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 201)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 16)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "年齡起(>=)："
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(36, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "服務項目："
        '
        'cmb_CareItem
        '
        Me.cmb_CareItem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_CareItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_CareItem.DropDownWidth = 20
        Me.cmb_CareItem.DroppedDown = False
        Me.cmb_CareItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmb_CareItem.Location = New System.Drawing.Point(134, 7)
        Me.cmb_CareItem.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmb_CareItem.Name = "cmb_CareItem"
        Me.cmb_CareItem.SelectedIndex = -1
        Me.cmb_CareItem.SelectedItem = Nothing
        Me.cmb_CareItem.SelectedText = ""
        Me.cmb_CareItem.SelectedValue = ""
        Me.cmb_CareItem.SelectionStart = 0
        Me.cmb_CareItem.Size = New System.Drawing.Size(218, 24)
        Me.cmb_CareItem.TabIndex = 43
        Me.cmb_CareItem.uclDisplayIndex = "0,1"
        Me.cmb_CareItem.uclIsAutoClear = True
        Me.cmb_CareItem.uclIsFirstItemEmpty = True
        Me.cmb_CareItem.uclIsTextMode = False
        Me.cmb_CareItem.uclShowMsg = False
        Me.cmb_CareItem.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(4, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "服務時程代碼："
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "就醫序號："
        '
        'txt_Serialnumber
        '
        Me.txt_Serialnumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Serialnumber.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Serialnumber.Location = New System.Drawing.Point(134, 81)
        Me.txt_Serialnumber.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Serialnumber.MaxLength = 10
        Me.txt_Serialnumber.Name = "txt_Serialnumber"
        Me.txt_Serialnumber.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Serialnumber.SelectionStart = 0
        Me.txt_Serialnumber.Size = New System.Drawing.Size(268, 28)
        Me.txt_Serialnumber.TabIndex = 47
        Me.txt_Serialnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Serialnumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Serialnumber.ToolTipTag = Nothing
        Me.txt_Serialnumber.uclDollarSign = False
        Me.txt_Serialnumber.uclDotCount = 0
        Me.txt_Serialnumber.uclIntCount = 2
        Me.txt_Serialnumber.uclMinus = False
        Me.txt_Serialnumber.uclReadOnly = False
        Me.txt_Serialnumber.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Serialnumber.uclTrimZero = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 125)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "服務時程名稱："
        '
        'txt_OrderName
        '
        Me.txt_OrderName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderName.Location = New System.Drawing.Point(134, 119)
        Me.txt_OrderName.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_OrderName.MaxLength = 100
        Me.txt_OrderName.Name = "txt_OrderName"
        Me.txt_OrderName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderName.SelectionStart = 0
        Me.txt_OrderName.Size = New System.Drawing.Size(349, 28)
        Me.txt_OrderName.TabIndex = 49
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
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 163)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "年齡控制類型："
        '
        'cmb_Agecontrol
        '
        Me.cmb_Agecontrol.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_Agecontrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_Agecontrol.DropDownWidth = 20
        Me.cmb_Agecontrol.DroppedDown = False
        Me.cmb_Agecontrol.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmb_Agecontrol.Location = New System.Drawing.Point(134, 159)
        Me.cmb_Agecontrol.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmb_Agecontrol.Name = "cmb_Agecontrol"
        Me.cmb_Agecontrol.SelectedIndex = -1
        Me.cmb_Agecontrol.SelectedItem = Nothing
        Me.cmb_Agecontrol.SelectedText = ""
        Me.cmb_Agecontrol.SelectedValue = ""
        Me.cmb_Agecontrol.SelectionStart = 0
        Me.cmb_Agecontrol.Size = New System.Drawing.Size(218, 24)
        Me.cmb_Agecontrol.TabIndex = 51
        Me.cmb_Agecontrol.uclDisplayIndex = "0,1"
        Me.cmb_Agecontrol.uclIsAutoClear = True
        Me.cmb_Agecontrol.uclIsFirstItemEmpty = True
        Me.cmb_Agecontrol.uclIsTextMode = False
        Me.cmb_Agecontrol.uclShowMsg = False
        Me.cmb_Agecontrol.uclValueIndex = "0"
        '
        'txt_AgeMin
        '
        Me.txt_AgeMin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AgeMin.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_AgeMin.Location = New System.Drawing.Point(134, 195)
        Me.txt_AgeMin.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_AgeMin.MaxLength = 10
        Me.txt_AgeMin.Name = "txt_AgeMin"
        Me.txt_AgeMin.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_AgeMin.SelectionStart = 0
        Me.txt_AgeMin.Size = New System.Drawing.Size(90, 28)
        Me.txt_AgeMin.TabIndex = 53
        Me.txt_AgeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_AgeMin.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_AgeMin.ToolTipTag = Nothing
        Me.txt_AgeMin.uclDollarSign = False
        Me.txt_AgeMin.uclDotCount = 0
        Me.txt_AgeMin.uclIntCount = 3
        Me.txt_AgeMin.uclMinus = False
        Me.txt_AgeMin.uclReadOnly = False
        Me.txt_AgeMin.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_AgeMin.uclTrimZero = True
        '
        'txt_AgeMax
        '
        Me.txt_AgeMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AgeMax.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_AgeMax.Location = New System.Drawing.Point(134, 233)
        Me.txt_AgeMax.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_AgeMax.MaxLength = 10
        Me.txt_AgeMax.Name = "txt_AgeMax"
        Me.txt_AgeMax.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_AgeMax.SelectionStart = 0
        Me.txt_AgeMax.Size = New System.Drawing.Size(90, 28)
        Me.txt_AgeMax.TabIndex = 55
        Me.txt_AgeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_AgeMax.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_AgeMax.ToolTipTag = Nothing
        Me.txt_AgeMax.uclDollarSign = False
        Me.txt_AgeMax.uclDotCount = 0
        Me.txt_AgeMax.uclIntCount = 3
        Me.txt_AgeMax.uclMinus = False
        Me.txt_AgeMax.uclReadOnly = False
        Me.txt_AgeMax.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_AgeMax.uclTrimZero = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(557, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "說明："
        '
        'txt_instruction
        '
        Me.txt_instruction.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_instruction.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_instruction.Location = New System.Drawing.Point(1035, 5)
        Me.txt_instruction.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_instruction.MaxLength = 4096
        Me.txt_instruction.Name = "txt_instruction"
        Me.txt_instruction.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_instruction.SelectionStart = 0
        Me.txt_instruction.Size = New System.Drawing.Size(154, 28)
        Me.txt_instruction.TabIndex = 57
        Me.txt_instruction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_instruction.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_instruction.ToolTipTag = Nothing
        Me.txt_instruction.uclDollarSign = False
        Me.txt_instruction.uclDotCount = 0
        Me.txt_instruction.uclIntCount = 2
        Me.txt_instruction.uclMinus = False
        Me.txt_instruction.uclReadOnly = False
        Me.txt_instruction.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_instruction.uclTrimZero = True
        Me.txt_instruction.Visible = False
        '
        'rich_instruction
        '
        Me.rich_instruction.Location = New System.Drawing.Point(620, 3)
        Me.rich_instruction.MaxLength = 32767
        Me.rich_instruction.Name = "rich_instruction"
        Me.rich_instruction.Size = New System.Drawing.Size(400, 28)
        Me.rich_instruction.TabIndex = 71
        Me.rich_instruction.Text = ""
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(525, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "性別限制："
        '
        'cmb_sex
        '
        Me.cmb_sex.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_sex.DropDownWidth = 20
        Me.cmb_sex.DroppedDown = False
        Me.cmb_sex.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmb_sex.Location = New System.Drawing.Point(623, 45)
        Me.cmb_sex.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmb_sex.Name = "cmb_sex"
        Me.cmb_sex.SelectedIndex = -1
        Me.cmb_sex.SelectedItem = Nothing
        Me.cmb_sex.SelectedText = ""
        Me.cmb_sex.SelectedValue = ""
        Me.cmb_sex.SelectionStart = 0
        Me.cmb_sex.Size = New System.Drawing.Size(216, 24)
        Me.cmb_sex.TabIndex = 61
        Me.cmb_sex.uclDisplayIndex = "0,1"
        Me.cmb_sex.uclIsAutoClear = True
        Me.cmb_sex.uclIsFirstItemEmpty = True
        Me.cmb_sex.uclIsTextMode = False
        Me.cmb_sex.uclShowMsg = False
        Me.cmb_sex.uclValueIndex = "0"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(493, 87)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 16)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "篩檢條件說明："
        '
        'txt_Sconditions
        '
        Me.txt_Sconditions.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sconditions.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Sconditions.Location = New System.Drawing.Point(623, 81)
        Me.txt_Sconditions.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Sconditions.MaxLength = 50
        Me.txt_Sconditions.Name = "txt_Sconditions"
        Me.txt_Sconditions.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Sconditions.SelectionStart = 0
        Me.txt_Sconditions.Size = New System.Drawing.Size(400, 28)
        Me.txt_Sconditions.TabIndex = 63
        Me.txt_Sconditions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Sconditions.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Sconditions.ToolTipTag = Nothing
        Me.txt_Sconditions.uclDollarSign = False
        Me.txt_Sconditions.uclDotCount = 0
        Me.txt_Sconditions.uclIntCount = 2
        Me.txt_Sconditions.uclMinus = False
        Me.txt_Sconditions.uclReadOnly = False
        Me.txt_Sconditions.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Sconditions.uclTrimZero = True
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(525, 125)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "諮詢單位："
        '
        'txt_Advisoryunit
        '
        Me.txt_Advisoryunit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Advisoryunit.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Advisoryunit.Location = New System.Drawing.Point(623, 119)
        Me.txt_Advisoryunit.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Advisoryunit.MaxLength = 50
        Me.txt_Advisoryunit.Name = "txt_Advisoryunit"
        Me.txt_Advisoryunit.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Advisoryunit.SelectionStart = 0
        Me.txt_Advisoryunit.Size = New System.Drawing.Size(400, 28)
        Me.txt_Advisoryunit.TabIndex = 65
        Me.txt_Advisoryunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Advisoryunit.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Advisoryunit.ToolTipTag = Nothing
        Me.txt_Advisoryunit.uclDollarSign = False
        Me.txt_Advisoryunit.uclDotCount = 0
        Me.txt_Advisoryunit.uclIntCount = 2
        Me.txt_Advisoryunit.uclMinus = False
        Me.txt_Advisoryunit.uclReadOnly = False
        Me.txt_Advisoryunit.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Advisoryunit.uclTrimZero = True
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(493, 163)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 16)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "診間提示說明："
        '
        'txt_Indiagnosis
        '
        Me.txt_Indiagnosis.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Indiagnosis.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Indiagnosis.Location = New System.Drawing.Point(623, 157)
        Me.txt_Indiagnosis.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Indiagnosis.MaxLength = 100
        Me.txt_Indiagnosis.Name = "txt_Indiagnosis"
        Me.txt_Indiagnosis.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Indiagnosis.SelectionStart = 0
        Me.txt_Indiagnosis.Size = New System.Drawing.Size(400, 28)
        Me.txt_Indiagnosis.TabIndex = 67
        Me.txt_Indiagnosis.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Indiagnosis.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Indiagnosis.ToolTipTag = Nothing
        Me.txt_Indiagnosis.uclDollarSign = False
        Me.txt_Indiagnosis.uclDotCount = 0
        Me.txt_Indiagnosis.uclIntCount = 2
        Me.txt_Indiagnosis.uclMinus = False
        Me.txt_Indiagnosis.uclReadOnly = False
        Me.txt_Indiagnosis.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Indiagnosis.uclTrimZero = True
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(557, 201)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "備註："
        '
        'txt_note
        '
        Me.txt_note.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_note.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_note.Location = New System.Drawing.Point(623, 195)
        Me.txt_note.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_note.MaxLength = 100
        Me.txt_note.Name = "txt_note"
        Me.txt_note.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_note.SelectionStart = 0
        Me.txt_note.Size = New System.Drawing.Size(400, 28)
        Me.txt_note.TabIndex = 69
        Me.txt_note.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_note.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_note.ToolTipTag = Nothing
        Me.txt_note.uclDollarSign = False
        Me.txt_note.uclDotCount = 0
        Me.txt_note.uclIntCount = 2
        Me.txt_note.uclMinus = False
        Me.txt_note.uclReadOnly = False
        Me.txt_note.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_note.uclTrimZero = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(525, 239)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "套餐代碼："
        Me.Label10.Visible = False
        '
        'txt_Packagecode
        '
        Me.txt_Packagecode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Packagecode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Packagecode.Location = New System.Drawing.Point(623, 233)
        Me.txt_Packagecode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Packagecode.MaxLength = 10
        Me.txt_Packagecode.Name = "txt_Packagecode"
        Me.txt_Packagecode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Packagecode.SelectionStart = 0
        Me.txt_Packagecode.Size = New System.Drawing.Size(268, 28)
        Me.txt_Packagecode.TabIndex = 59
        Me.txt_Packagecode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Packagecode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Packagecode.ToolTipTag = Nothing
        Me.txt_Packagecode.uclDollarSign = False
        Me.txt_Packagecode.uclDotCount = 0
        Me.txt_Packagecode.uclIntCount = 2
        Me.txt_Packagecode.uclMinus = False
        Me.txt_Packagecode.uclReadOnly = False
        Me.txt_Packagecode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Packagecode.uclTrimZero = True
        Me.txt_Packagecode.Visible = False
        '
        'Cmb_OrderCode
        '
        Me.Cmb_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Cmb_OrderCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.Cmb_OrderCode.DropDownWidth = 20
        Me.Cmb_OrderCode.DroppedDown = False
        Me.Cmb_OrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cmb_OrderCode.Location = New System.Drawing.Point(1035, 45)
        Me.Cmb_OrderCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cmb_OrderCode.Name = "Cmb_OrderCode"
        Me.Cmb_OrderCode.SelectedIndex = -1
        Me.Cmb_OrderCode.SelectedItem = Nothing
        Me.Cmb_OrderCode.SelectedText = ""
        Me.Cmb_OrderCode.SelectedValue = ""
        Me.Cmb_OrderCode.SelectionStart = 0
        Me.Cmb_OrderCode.Size = New System.Drawing.Size(154, 24)
        Me.Cmb_OrderCode.TabIndex = 45
        Me.Cmb_OrderCode.uclDisplayIndex = "0,1"
        Me.Cmb_OrderCode.uclIsAutoClear = True
        Me.Cmb_OrderCode.uclIsFirstItemEmpty = True
        Me.Cmb_OrderCode.uclIsTextMode = False
        Me.Cmb_OrderCode.uclShowMsg = False
        Me.Cmb_OrderCode.uclValueIndex = "0"
        Me.Cmb_OrderCode.Visible = False
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderCode.Location = New System.Drawing.Point(134, 43)
        Me.txt_OrderCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_OrderCode.MaxLength = 10
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderCode.SelectionStart = 0
        Me.txt_OrderCode.Size = New System.Drawing.Size(268, 28)
        Me.txt_OrderCode.TabIndex = 72
        Me.txt_OrderCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrderCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrderCode.ToolTipTag = Nothing
        Me.txt_OrderCode.uclDollarSign = False
        Me.txt_OrderCode.uclDotCount = 0
        Me.txt_OrderCode.uclIntCount = 2
        Me.txt_OrderCode.uclMinus = False
        Me.txt_OrderCode.uclReadOnly = False
        Me.txt_OrderCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_OrderCode.uclTrimZero = True
        '
        'PUBPreventiveCareSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 649)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPreventiveCareSetupUI"
        Me.Text = "PUBPreventiveCareSetupUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_CareItem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmb_OrderCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Serialnumber As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_OrderName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmb_Agecontrol As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_AgeMin As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_AgeMax As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_instruction As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_Packagecode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_sex As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Sconditions As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_Advisoryunit As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_Indiagnosis As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_note As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents rich_instruction As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_OrderCode As Syscom.Client.UCL.UCLTextBoxUC
End Class
