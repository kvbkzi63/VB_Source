<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBMaterialSelfpayApplyUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBMaterialSelfpayApplyUI))
        Me.pal_Mantain = New System.Windows.Forms.Panel()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_ApplyStatusId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Classify = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_EffectDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lbl_EffectDate = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.txt_OrderCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_License = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_SelfInsuCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_LicenseNo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_EfficacyComparison = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_RichText5 = New System.Windows.Forms.Button()
        Me.btn_RichText1 = New System.Windows.Forms.Button()
        Me.btn_RichText3 = New System.Windows.Forms.Button()
        Me.txt_ProductFeatures = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_Precautions = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_InsuCode1 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_InsuCode2 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_InsuCode6 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_InsuCode10 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_InsuCode5 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_InsuCode9 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_SideEffect = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.btn_RichText4 = New System.Windows.Forms.Button()
        Me.btn_RichText2 = New System.Windows.Forms.Button()
        Me.txt_UseReason = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txt_InsuOrderType = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chk_IsAlter = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_InsuCode4 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_InsuCode8 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_InsuCode3 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_InsuCode7 = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chk_Agreement = New System.Windows.Forms.CheckBox()
        Me.chk_Instruction = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.pal_Mantain.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 373)
        Me.IUCLMaintainPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 269)
        '
        'pal_1
        '
        Me.pal_1.Location = New System.Drawing.Point(2, 36)
        Me.pal_1.Size = New System.Drawing.Size(981, 232)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(981, 232)
        '
        'pal_Mantain
        '
        Me.pal_Mantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Mantain.Controls.Add(Me.tlp_Main)
        Me.pal_Mantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Mantain.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.pal_Mantain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Mantain.Margin = New System.Windows.Forms.Padding(4)
        Me.pal_Mantain.Name = "pal_Mantain"
        Me.pal_Mantain.Size = New System.Drawing.Size(985, 373)
        Me.pal_Mantain.TabIndex = 0
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 11
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.cbo_ApplyStatusId, 8, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 7, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Classify, 6, 0)
        Me.tlp_Main.Controls.Add(Me.txt_EffectDate, 3, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_EffectDate, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lblOrderCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_OrderCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_License, 1, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label7, 7, 1)
        Me.tlp_Main.Controls.Add(Me.Label1, 5, 1)
        Me.tlp_Main.Controls.Add(Me.txt_SelfInsuCode, 6, 1)
        Me.tlp_Main.Controls.Add(Me.txt_LicenseNo, 8, 1)
        Me.tlp_Main.Controls.Add(Me.Label26, 5, 0)
        Me.tlp_Main.Controls.Add(Me.Label14, 0, 2)
        Me.tlp_Main.Controls.Add(Me.txt_EfficacyComparison, 1, 2)
        Me.tlp_Main.Controls.Add(Me.btn_RichText5, 4, 2)
        Me.tlp_Main.Controls.Add(Me.btn_RichText1, 4, 3)
        Me.tlp_Main.Controls.Add(Me.btn_RichText3, 4, 4)
        Me.tlp_Main.Controls.Add(Me.txt_ProductFeatures, 1, 3)
        Me.tlp_Main.Controls.Add(Me.Label10, 0, 3)
        Me.tlp_Main.Controls.Add(Me.Label12, 0, 4)
        Me.tlp_Main.Controls.Add(Me.Label15, 0, 5)
        Me.tlp_Main.Controls.Add(Me.txt_Precautions, 1, 4)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode1, 1, 5)
        Me.tlp_Main.Controls.Add(Me.Label16, 2, 5)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode2, 3, 5)
        Me.tlp_Main.Controls.Add(Me.Label20, 2, 6)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode6, 3, 6)
        Me.tlp_Main.Controls.Add(Me.Label23, 2, 7)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode10, 3, 7)
        Me.tlp_Main.Controls.Add(Me.Label19, 0, 6)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode5, 1, 6)
        Me.tlp_Main.Controls.Add(Me.Label24, 0, 7)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode9, 1, 7)
        Me.tlp_Main.Controls.Add(Me.Label13, 5, 2)
        Me.tlp_Main.Controls.Add(Me.txt_SideEffect, 6, 2)
        Me.tlp_Main.Controls.Add(Me.btn_RichText4, 9, 2)
        Me.tlp_Main.Controls.Add(Me.btn_RichText2, 9, 3)
        Me.tlp_Main.Controls.Add(Me.txt_UseReason, 6, 3)
        Me.tlp_Main.Controls.Add(Me.Label11, 5, 3)
        Me.tlp_Main.Controls.Add(Me.Label25, 5, 4)
        Me.tlp_Main.Controls.Add(Me.txt_InsuOrderType, 6, 4)
        Me.tlp_Main.Controls.Add(Me.chk_IsAlter, 7, 4)
        Me.tlp_Main.Controls.Add(Me.Label18, 7, 5)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode4, 8, 5)
        Me.tlp_Main.Controls.Add(Me.Label22, 7, 6)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode8, 8, 6)
        Me.tlp_Main.Controls.Add(Me.Label17, 5, 5)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode3, 6, 5)
        Me.tlp_Main.Controls.Add(Me.Label21, 5, 6)
        Me.tlp_Main.Controls.Add(Me.txt_InsuCode7, 6, 6)
        Me.tlp_Main.Controls.Add(Me.chk_Agreement, 5, 7)
        Me.tlp_Main.Controls.Add(Me.chk_Instruction, 6, 7)
        Me.tlp_Main.Controls.Add(Me.Label4, 7, 7)
        Me.tlp_Main.Controls.Add(Me.txt_EndDate, 8, 7)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 8
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.tlp_Main.Size = New System.Drawing.Size(983, 335)
        Me.tlp_Main.TabIndex = 19
        '
        'cbo_ApplyStatusId
        '
        Me.cbo_ApplyStatusId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.cbo_ApplyStatusId, 2)
        Me.cbo_ApplyStatusId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_ApplyStatusId.DropDownWidth = 20
        Me.cbo_ApplyStatusId.DroppedDown = False
        Me.cbo_ApplyStatusId.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_ApplyStatusId.Location = New System.Drawing.Point(825, 8)
        Me.cbo_ApplyStatusId.Margin = New System.Windows.Forms.Padding(2)
        Me.cbo_ApplyStatusId.Name = "cbo_ApplyStatusId"
        Me.cbo_ApplyStatusId.SelectedIndex = -1
        Me.cbo_ApplyStatusId.SelectedItem = Nothing
        Me.cbo_ApplyStatusId.SelectedText = ""
        Me.cbo_ApplyStatusId.SelectedValue = ""
        Me.cbo_ApplyStatusId.SelectionStart = 0
        Me.cbo_ApplyStatusId.Size = New System.Drawing.Size(139, 24)
        Me.cbo_ApplyStatusId.TabIndex = 4
        Me.cbo_ApplyStatusId.uclDisplayIndex = "1"
        Me.cbo_ApplyStatusId.uclIsAutoClear = True
        Me.cbo_ApplyStatusId.uclIsFirstItemEmpty = True
        Me.cbo_ApplyStatusId.uclIsTextMode = False
        Me.cbo_ApplyStatusId.uclShowMsg = False
        Me.cbo_ApplyStatusId.uclValueIndex = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(747, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "申請狀況"
        '
        'txt_Classify
        '
        Me.txt_Classify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Classify.Enabled = False
        Me.txt_Classify.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_Classify.Location = New System.Drawing.Point(611, 7)
        Me.txt_Classify.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txt_Classify.MaxLength = 20
        Me.txt_Classify.Name = "txt_Classify"
        Me.txt_Classify.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Classify.SelectionStart = 0
        Me.txt_Classify.Size = New System.Drawing.Size(91, 27)
        Me.txt_Classify.TabIndex = 79
        Me.txt_Classify.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Classify.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Classify.ToolTipTag = Nothing
        Me.txt_Classify.uclDollarSign = False
        Me.txt_Classify.uclDotCount = 0
        Me.txt_Classify.uclIntCount = 2
        Me.txt_Classify.uclMinus = False
        Me.txt_Classify.uclReadOnly = False
        Me.txt_Classify.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Classify.uclTrimZero = True
        '
        'txt_EffectDate
        '
        Me.txt_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EffectDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.txt_EffectDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.txt_EffectDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_EffectDate.Location = New System.Drawing.Point(345, 7)
        Me.txt_EffectDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.txt_EffectDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txt_EffectDate.Name = "txt_EffectDate"
        Me.txt_EffectDate.Size = New System.Drawing.Size(108, 27)
        Me.txt_EffectDate.TabIndex = 2
        Me.txt_EffectDate.uclReadOnly = False
        '
        'lbl_EffectDate
        '
        Me.lbl_EffectDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EffectDate.AutoSize = True
        Me.lbl_EffectDate.ForeColor = System.Drawing.Color.Red
        Me.lbl_EffectDate.Location = New System.Drawing.Point(258, 12)
        Me.lbl_EffectDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_EffectDate.Name = "lbl_EffectDate"
        Me.lbl_EffectDate.Size = New System.Drawing.Size(80, 16)
        Me.lbl_EffectDate.TabIndex = 2
        Me.lbl_EffectDate.Text = "*生效日期"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(60, 12)
        Me.lblOrderCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(64, 16)
        Me.lblOrderCode.TabIndex = 0
        Me.lblOrderCode.Text = "*醫令碼"
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderCode.Enabled = False
        Me.txt_OrderCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderCode.Location = New System.Drawing.Point(134, 7)
        Me.txt_OrderCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_OrderCode.MaxLength = 20
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderCode.SelectionStart = 0
        Me.txt_OrderCode.Size = New System.Drawing.Size(90, 27)
        Me.txt_OrderCode.TabIndex = 1
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
        'txt_License
        '
        Me.txt_License.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_License, 3)
        Me.txt_License.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_License.Location = New System.Drawing.Point(134, 48)
        Me.txt_License.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_License.MaxLength = 100
        Me.txt_License.Name = "txt_License"
        Me.txt_License.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_License.SelectionStart = 0
        Me.txt_License.Size = New System.Drawing.Size(319, 27)
        Me.txt_License.TabIndex = 5
        Me.txt_License.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_License.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_License.ToolTipTag = Nothing
        Me.txt_License.uclDollarSign = False
        Me.txt_License.uclDotCount = 0
        Me.txt_License.uclIntCount = 2
        Me.txt_License.uclMinus = False
        Me.txt_License.uclReadOnly = False
        Me.txt_License.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_License.uclTrimZero = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(4, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "器材許可證字第"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(747, 53)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "許可證號"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(514, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "虛擬健保碼"
        '
        'txt_SelfInsuCode
        '
        Me.txt_SelfInsuCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SelfInsuCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SelfInsuCode.Location = New System.Drawing.Point(612, 48)
        Me.txt_SelfInsuCode.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_SelfInsuCode.MaxLength = 20
        Me.txt_SelfInsuCode.Name = "txt_SelfInsuCode"
        Me.txt_SelfInsuCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SelfInsuCode.SelectionStart = 0
        Me.txt_SelfInsuCode.Size = New System.Drawing.Size(90, 27)
        Me.txt_SelfInsuCode.TabIndex = 7
        Me.txt_SelfInsuCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SelfInsuCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SelfInsuCode.ToolTipTag = Nothing
        Me.txt_SelfInsuCode.uclDollarSign = False
        Me.txt_SelfInsuCode.uclDotCount = 0
        Me.txt_SelfInsuCode.uclIntCount = 2
        Me.txt_SelfInsuCode.uclMinus = False
        Me.txt_SelfInsuCode.uclReadOnly = False
        Me.txt_SelfInsuCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_SelfInsuCode.uclTrimZero = True
        '
        'txt_LicenseNo
        '
        Me.txt_LicenseNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_LicenseNo, 2)
        Me.txt_LicenseNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_LicenseNo.Location = New System.Drawing.Point(829, 48)
        Me.txt_LicenseNo.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_LicenseNo.MaxLength = 20
        Me.txt_LicenseNo.Name = "txt_LicenseNo"
        Me.txt_LicenseNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_LicenseNo.SelectionStart = 0
        Me.txt_LicenseNo.Size = New System.Drawing.Size(135, 27)
        Me.txt_LicenseNo.TabIndex = 6
        Me.txt_LicenseNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_LicenseNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_LicenseNo.ToolTipTag = Nothing
        Me.txt_LicenseNo.uclDollarSign = False
        Me.txt_LicenseNo.uclDotCount = 0
        Me.txt_LicenseNo.uclIntCount = 2
        Me.txt_LicenseNo.uclMinus = False
        Me.txt_LicenseNo.uclReadOnly = False
        Me.txt_LicenseNo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_LicenseNo.uclTrimZero = True
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(530, 12)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 78
        Me.Label26.Text = "給付註記"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(52, 94)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "療效比較"
        '
        'txt_EfficacyComparison
        '
        Me.txt_EfficacyComparison.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_EfficacyComparison, 3)
        Me.txt_EfficacyComparison.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_EfficacyComparison.Location = New System.Drawing.Point(134, 90)
        Me.txt_EfficacyComparison.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_EfficacyComparison.MaxLength = 4000
        Me.txt_EfficacyComparison.Name = "txt_EfficacyComparison"
        Me.txt_EfficacyComparison.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_EfficacyComparison.SelectionStart = 0
        Me.txt_EfficacyComparison.Size = New System.Drawing.Size(319, 24)
        Me.txt_EfficacyComparison.TabIndex = 16
        Me.txt_EfficacyComparison.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_EfficacyComparison.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_EfficacyComparison.ToolTipTag = Nothing
        Me.txt_EfficacyComparison.uclDollarSign = False
        Me.txt_EfficacyComparison.uclDotCount = 0
        Me.txt_EfficacyComparison.uclIntCount = 2
        Me.txt_EfficacyComparison.uclMinus = False
        Me.txt_EfficacyComparison.uclReadOnly = False
        Me.txt_EfficacyComparison.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_EfficacyComparison.uclTrimZero = True
        '
        'btn_RichText5
        '
        Me.btn_RichText5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_RichText5.Location = New System.Drawing.Point(462, 91)
        Me.btn_RichText5.Name = "btn_RichText5"
        Me.btn_RichText5.Size = New System.Drawing.Size(28, 23)
        Me.btn_RichText5.TabIndex = 77
        Me.btn_RichText5.Text = "..."
        Me.btn_RichText5.UseVisualStyleBackColor = True
        '
        'btn_RichText1
        '
        Me.btn_RichText1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_RichText1.Location = New System.Drawing.Point(462, 132)
        Me.btn_RichText1.Name = "btn_RichText1"
        Me.btn_RichText1.Size = New System.Drawing.Size(28, 23)
        Me.btn_RichText1.TabIndex = 73
        Me.btn_RichText1.Text = "..."
        Me.btn_RichText1.UseVisualStyleBackColor = True
        '
        'btn_RichText3
        '
        Me.btn_RichText3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_RichText3.Location = New System.Drawing.Point(462, 173)
        Me.btn_RichText3.Name = "btn_RichText3"
        Me.btn_RichText3.Size = New System.Drawing.Size(28, 23)
        Me.btn_RichText3.TabIndex = 75
        Me.btn_RichText3.Text = "..."
        Me.btn_RichText3.UseVisualStyleBackColor = True
        '
        'txt_ProductFeatures
        '
        Me.txt_ProductFeatures.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_ProductFeatures, 3)
        Me.txt_ProductFeatures.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ProductFeatures.Location = New System.Drawing.Point(134, 132)
        Me.txt_ProductFeatures.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_ProductFeatures.MaxLength = 4000
        Me.txt_ProductFeatures.Name = "txt_ProductFeatures"
        Me.txt_ProductFeatures.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ProductFeatures.SelectionStart = 0
        Me.txt_ProductFeatures.Size = New System.Drawing.Size(319, 22)
        Me.txt_ProductFeatures.TabIndex = 12
        Me.txt_ProductFeatures.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ProductFeatures.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ProductFeatures.ToolTipTag = Nothing
        Me.txt_ProductFeatures.uclDollarSign = False
        Me.txt_ProductFeatures.uclDotCount = 0
        Me.txt_ProductFeatures.uclIntCount = 2
        Me.txt_ProductFeatures.uclMinus = False
        Me.txt_ProductFeatures.uclReadOnly = False
        Me.txt_ProductFeatures.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ProductFeatures.uclTrimZero = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(52, 135)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "產品特性"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(52, 176)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "注意事項"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(28, 217)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 16)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "替代健保碼1"
        '
        'txt_Precautions
        '
        Me.txt_Precautions.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_Precautions, 3)
        Me.txt_Precautions.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Precautions.Location = New System.Drawing.Point(134, 172)
        Me.txt_Precautions.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_Precautions.MaxLength = 4000
        Me.txt_Precautions.Name = "txt_Precautions"
        Me.txt_Precautions.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Precautions.SelectionStart = 0
        Me.txt_Precautions.Size = New System.Drawing.Size(319, 24)
        Me.txt_Precautions.TabIndex = 14
        Me.txt_Precautions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Precautions.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Precautions.ToolTipTag = Nothing
        Me.txt_Precautions.uclDollarSign = False
        Me.txt_Precautions.uclDotCount = 0
        Me.txt_Precautions.uclIntCount = 2
        Me.txt_Precautions.uclMinus = False
        Me.txt_Precautions.uclReadOnly = False
        Me.txt_Precautions.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Precautions.uclTrimZero = True
        '
        'txt_InsuCode1
        '
        Me.txt_InsuCode1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode1.Location = New System.Drawing.Point(134, 212)
        Me.txt_InsuCode1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode1.MaxLength = 20
        Me.txt_InsuCode1.Name = "txt_InsuCode1"
        Me.txt_InsuCode1.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode1.SelectionStart = 0
        Me.txt_InsuCode1.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode1.TabIndex = 19
        Me.txt_InsuCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode1.ToolTipTag = Nothing
        Me.txt_InsuCode1.uclDollarSign = False
        Me.txt_InsuCode1.uclDotCount = 0
        Me.txt_InsuCode1.uclIntCount = 2
        Me.txt_InsuCode1.uclMinus = False
        Me.txt_InsuCode1.uclReadOnly = False
        Me.txt_InsuCode1.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode1.uclTrimZero = True
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(242, 217)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 16)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "替代健保碼2"
        '
        'txt_InsuCode2
        '
        Me.txt_InsuCode2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode2.Location = New System.Drawing.Point(348, 212)
        Me.txt_InsuCode2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode2.MaxLength = 20
        Me.txt_InsuCode2.Name = "txt_InsuCode2"
        Me.txt_InsuCode2.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode2.SelectionStart = 0
        Me.txt_InsuCode2.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode2.TabIndex = 20
        Me.txt_InsuCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode2.ToolTipTag = Nothing
        Me.txt_InsuCode2.uclDollarSign = False
        Me.txt_InsuCode2.uclDotCount = 0
        Me.txt_InsuCode2.uclIntCount = 2
        Me.txt_InsuCode2.uclMinus = False
        Me.txt_InsuCode2.uclReadOnly = False
        Me.txt_InsuCode2.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode2.uclTrimZero = True
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(242, 258)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 16)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "替代健保碼6"
        '
        'txt_InsuCode6
        '
        Me.txt_InsuCode6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode6.Location = New System.Drawing.Point(348, 253)
        Me.txt_InsuCode6.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode6.MaxLength = 20
        Me.txt_InsuCode6.Name = "txt_InsuCode6"
        Me.txt_InsuCode6.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode6.SelectionStart = 0
        Me.txt_InsuCode6.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode6.TabIndex = 24
        Me.txt_InsuCode6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode6.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode6.ToolTipTag = Nothing
        Me.txt_InsuCode6.uclDollarSign = False
        Me.txt_InsuCode6.uclDotCount = 0
        Me.txt_InsuCode6.uclIntCount = 2
        Me.txt_InsuCode6.uclMinus = False
        Me.txt_InsuCode6.uclReadOnly = False
        Me.txt_InsuCode6.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode6.uclTrimZero = True
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(234, 303)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 16)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "替代健保碼10"
        '
        'txt_InsuCode10
        '
        Me.txt_InsuCode10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode10.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode10.Location = New System.Drawing.Point(348, 297)
        Me.txt_InsuCode10.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode10.MaxLength = 20
        Me.txt_InsuCode10.Name = "txt_InsuCode10"
        Me.txt_InsuCode10.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode10.SelectionStart = 0
        Me.txt_InsuCode10.Size = New System.Drawing.Size(90, 27)
        Me.txt_InsuCode10.TabIndex = 28
        Me.txt_InsuCode10.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode10.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode10.ToolTipTag = Nothing
        Me.txt_InsuCode10.uclDollarSign = False
        Me.txt_InsuCode10.uclDotCount = 0
        Me.txt_InsuCode10.uclIntCount = 2
        Me.txt_InsuCode10.uclMinus = False
        Me.txt_InsuCode10.uclReadOnly = False
        Me.txt_InsuCode10.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode10.uclTrimZero = True
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(28, 258)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 16)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "替代健保碼5"
        '
        'txt_InsuCode5
        '
        Me.txt_InsuCode5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode5.Location = New System.Drawing.Point(134, 253)
        Me.txt_InsuCode5.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode5.MaxLength = 20
        Me.txt_InsuCode5.Name = "txt_InsuCode5"
        Me.txt_InsuCode5.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode5.SelectionStart = 0
        Me.txt_InsuCode5.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode5.TabIndex = 23
        Me.txt_InsuCode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode5.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode5.ToolTipTag = Nothing
        Me.txt_InsuCode5.uclDollarSign = False
        Me.txt_InsuCode5.uclDotCount = 0
        Me.txt_InsuCode5.uclIntCount = 2
        Me.txt_InsuCode5.uclMinus = False
        Me.txt_InsuCode5.uclReadOnly = False
        Me.txt_InsuCode5.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode5.uclTrimZero = True
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(28, 303)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 16)
        Me.Label24.TabIndex = 63
        Me.Label24.Text = "替代健保碼9"
        '
        'txt_InsuCode9
        '
        Me.txt_InsuCode9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode9.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode9.Location = New System.Drawing.Point(134, 297)
        Me.txt_InsuCode9.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode9.MaxLength = 20
        Me.txt_InsuCode9.Name = "txt_InsuCode9"
        Me.txt_InsuCode9.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode9.SelectionStart = 0
        Me.txt_InsuCode9.Size = New System.Drawing.Size(90, 27)
        Me.txt_InsuCode9.TabIndex = 27
        Me.txt_InsuCode9.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode9.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode9.ToolTipTag = Nothing
        Me.txt_InsuCode9.uclDollarSign = False
        Me.txt_InsuCode9.uclDotCount = 0
        Me.txt_InsuCode9.uclIntCount = 2
        Me.txt_InsuCode9.uclMinus = False
        Me.txt_InsuCode9.uclReadOnly = False
        Me.txt_InsuCode9.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode9.uclTrimZero = True
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(546, 94)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "副作用"
        '
        'txt_SideEffect
        '
        Me.txt_SideEffect.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_SideEffect, 3)
        Me.txt_SideEffect.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SideEffect.Location = New System.Drawing.Point(612, 90)
        Me.txt_SideEffect.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_SideEffect.MaxLength = 4000
        Me.txt_SideEffect.Name = "txt_SideEffect"
        Me.txt_SideEffect.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SideEffect.SelectionStart = 0
        Me.txt_SideEffect.Size = New System.Drawing.Size(327, 24)
        Me.txt_SideEffect.TabIndex = 15
        Me.txt_SideEffect.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SideEffect.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SideEffect.ToolTipTag = Nothing
        Me.txt_SideEffect.uclDollarSign = False
        Me.txt_SideEffect.uclDotCount = 0
        Me.txt_SideEffect.uclIntCount = 2
        Me.txt_SideEffect.uclMinus = False
        Me.txt_SideEffect.uclReadOnly = False
        Me.txt_SideEffect.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_SideEffect.uclTrimZero = True
        '
        'btn_RichText4
        '
        Me.btn_RichText4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_RichText4.Location = New System.Drawing.Point(948, 91)
        Me.btn_RichText4.Name = "btn_RichText4"
        Me.btn_RichText4.Size = New System.Drawing.Size(28, 23)
        Me.btn_RichText4.TabIndex = 76
        Me.btn_RichText4.Text = "..."
        Me.btn_RichText4.UseVisualStyleBackColor = True
        '
        'btn_RichText2
        '
        Me.btn_RichText2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_RichText2.Location = New System.Drawing.Point(948, 132)
        Me.btn_RichText2.Name = "btn_RichText2"
        Me.btn_RichText2.Size = New System.Drawing.Size(28, 23)
        Me.btn_RichText2.TabIndex = 74
        Me.btn_RichText2.Text = "..."
        Me.btn_RichText2.UseVisualStyleBackColor = True
        '
        'txt_UseReason
        '
        Me.txt_UseReason.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_UseReason, 3)
        Me.txt_UseReason.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_UseReason.Location = New System.Drawing.Point(612, 132)
        Me.txt_UseReason.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_UseReason.MaxLength = 4000
        Me.txt_UseReason.Name = "txt_UseReason"
        Me.txt_UseReason.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_UseReason.SelectionStart = 0
        Me.txt_UseReason.Size = New System.Drawing.Size(327, 22)
        Me.txt_UseReason.TabIndex = 13
        Me.txt_UseReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_UseReason.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_UseReason.ToolTipTag = Nothing
        Me.txt_UseReason.uclDollarSign = False
        Me.txt_UseReason.uclDotCount = 0
        Me.txt_UseReason.uclIntCount = 2
        Me.txt_UseReason.uclMinus = False
        Me.txt_UseReason.uclReadOnly = False
        Me.txt_UseReason.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_UseReason.uclTrimZero = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(530, 135)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "使用原因"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(514, 176)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 16)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "申報醫令別"
        '
        'txt_InsuOrderType
        '
        Me.txt_InsuOrderType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuOrderType.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuOrderType.Location = New System.Drawing.Point(612, 172)
        Me.txt_InsuOrderType.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuOrderType.MaxLength = 1
        Me.txt_InsuOrderType.Name = "txt_InsuOrderType"
        Me.txt_InsuOrderType.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuOrderType.SelectionStart = 0
        Me.txt_InsuOrderType.Size = New System.Drawing.Size(90, 24)
        Me.txt_InsuOrderType.TabIndex = 17
        Me.txt_InsuOrderType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuOrderType.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuOrderType.ToolTipTag = Nothing
        Me.txt_InsuOrderType.uclDollarSign = False
        Me.txt_InsuOrderType.uclDotCount = 0
        Me.txt_InsuOrderType.uclIntCount = 2
        Me.txt_InsuOrderType.uclMinus = False
        Me.txt_InsuOrderType.uclReadOnly = False
        Me.txt_InsuOrderType.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuOrderType.uclTrimZero = True
        '
        'chk_IsAlter
        '
        Me.chk_IsAlter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.chk_IsAlter.AutoSize = True
        Me.chk_IsAlter.Location = New System.Drawing.Point(729, 174)
        Me.chk_IsAlter.Name = "chk_IsAlter"
        Me.chk_IsAlter.Size = New System.Drawing.Size(91, 20)
        Me.chk_IsAlter.TabIndex = 18
        Me.chk_IsAlter.Text = "申請註記"
        Me.chk_IsAlter.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(723, 217)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 16)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "替代健保碼4"
        '
        'txt_InsuCode4
        '
        Me.txt_InsuCode4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode4.Location = New System.Drawing.Point(829, 212)
        Me.txt_InsuCode4.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode4.MaxLength = 20
        Me.txt_InsuCode4.Name = "txt_InsuCode4"
        Me.txt_InsuCode4.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode4.SelectionStart = 0
        Me.txt_InsuCode4.Size = New System.Drawing.Size(96, 26)
        Me.txt_InsuCode4.TabIndex = 22
        Me.txt_InsuCode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode4.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode4.ToolTipTag = Nothing
        Me.txt_InsuCode4.uclDollarSign = False
        Me.txt_InsuCode4.uclDotCount = 0
        Me.txt_InsuCode4.uclIntCount = 2
        Me.txt_InsuCode4.uclMinus = False
        Me.txt_InsuCode4.uclReadOnly = False
        Me.txt_InsuCode4.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode4.uclTrimZero = True
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(723, 258)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 16)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "替代健保碼8"
        '
        'txt_InsuCode8
        '
        Me.txt_InsuCode8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode8.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode8.Location = New System.Drawing.Point(829, 253)
        Me.txt_InsuCode8.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode8.MaxLength = 20
        Me.txt_InsuCode8.Name = "txt_InsuCode8"
        Me.txt_InsuCode8.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode8.SelectionStart = 0
        Me.txt_InsuCode8.Size = New System.Drawing.Size(96, 26)
        Me.txt_InsuCode8.TabIndex = 26
        Me.txt_InsuCode8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode8.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode8.ToolTipTag = Nothing
        Me.txt_InsuCode8.uclDollarSign = False
        Me.txt_InsuCode8.uclDotCount = 0
        Me.txt_InsuCode8.uclIntCount = 2
        Me.txt_InsuCode8.uclMinus = False
        Me.txt_InsuCode8.uclReadOnly = False
        Me.txt_InsuCode8.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode8.uclTrimZero = True
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(506, 217)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 16)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "替代健保碼3"
        '
        'txt_InsuCode3
        '
        Me.txt_InsuCode3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode3.Location = New System.Drawing.Point(612, 212)
        Me.txt_InsuCode3.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode3.MaxLength = 20
        Me.txt_InsuCode3.Name = "txt_InsuCode3"
        Me.txt_InsuCode3.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode3.SelectionStart = 0
        Me.txt_InsuCode3.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode3.TabIndex = 21
        Me.txt_InsuCode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode3.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode3.ToolTipTag = Nothing
        Me.txt_InsuCode3.uclDollarSign = False
        Me.txt_InsuCode3.uclDotCount = 0
        Me.txt_InsuCode3.uclIntCount = 2
        Me.txt_InsuCode3.uclMinus = False
        Me.txt_InsuCode3.uclReadOnly = False
        Me.txt_InsuCode3.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode3.uclTrimZero = True
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(506, 258)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 16)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "替代健保碼7"
        '
        'txt_InsuCode7
        '
        Me.txt_InsuCode7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_InsuCode7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_InsuCode7.Location = New System.Drawing.Point(612, 253)
        Me.txt_InsuCode7.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.txt_InsuCode7.MaxLength = 20
        Me.txt_InsuCode7.Name = "txt_InsuCode7"
        Me.txt_InsuCode7.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_InsuCode7.SelectionStart = 0
        Me.txt_InsuCode7.Size = New System.Drawing.Size(90, 26)
        Me.txt_InsuCode7.TabIndex = 25
        Me.txt_InsuCode7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_InsuCode7.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_InsuCode7.ToolTipTag = Nothing
        Me.txt_InsuCode7.uclDollarSign = False
        Me.txt_InsuCode7.uclDotCount = 0
        Me.txt_InsuCode7.uclIntCount = 2
        Me.txt_InsuCode7.uclMinus = False
        Me.txt_InsuCode7.uclReadOnly = False
        Me.txt_InsuCode7.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_InsuCode7.uclTrimZero = True
        '
        'chk_Agreement
        '
        Me.chk_Agreement.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Agreement.AutoSize = True
        Me.chk_Agreement.Location = New System.Drawing.Point(496, 301)
        Me.chk_Agreement.Name = "chk_Agreement"
        Me.chk_Agreement.Size = New System.Drawing.Size(107, 20)
        Me.chk_Agreement.TabIndex = 29
        Me.chk_Agreement.Text = "列印同意書"
        Me.chk_Agreement.UseVisualStyleBackColor = True
        '
        'chk_Instruction
        '
        Me.chk_Instruction.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Instruction.AutoSize = True
        Me.chk_Instruction.Location = New System.Drawing.Point(609, 301)
        Me.chk_Instruction.Name = "chk_Instruction"
        Me.chk_Instruction.Size = New System.Drawing.Size(107, 20)
        Me.chk_Instruction.TabIndex = 30
        Me.chk_Instruction.Text = "列印說明書"
        Me.chk_Instruction.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(747, 303)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "結束日期"
        '
        'txt_EndDate
        '
        Me.txt_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.txt_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.txt_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_EndDate.Location = New System.Drawing.Point(826, 297)
        Me.txt_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.txt_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txt_EndDate.Name = "txt_EndDate"
        Me.txt_EndDate.Size = New System.Drawing.Size(105, 27)
        Me.txt_EndDate.TabIndex = 3
        Me.txt_EndDate.uclReadOnly = False
        '
        'PUBMaterialSelfpayApplyUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.pal_Mantain)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBMaterialSelfpayApplyUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "自費衛材核定記錄維護"
        Me.Text = "自費衛材核定記錄維護"
        Me.Controls.SetChildIndex(Me.pal_Mantain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.pal_Mantain.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pal_Mantain As System.Windows.Forms.Panel
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lbl_EffectDate As System.Windows.Forms.Label
    Friend WithEvents txt_OrderCode As Client.UCL.UCLTextBoxUC
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_EffectDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_SelfInsuCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_ApplyStatusId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txt_License As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ProductFeatures As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_UseReason As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_Precautions As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_SideEffect As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_EfficacyComparison As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuCode1 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuCode2 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuCode3 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuCode4 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuCode5 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuCode6 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuCode7 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuCode8 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuCode10 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_InsuCode9 As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_LicenseNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_InsuOrderType As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chk_IsAlter As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Agreement As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Instruction As System.Windows.Forms.CheckBox
    Friend WithEvents btn_RichText1 As System.Windows.Forms.Button
    Friend WithEvents btn_RichText3 As System.Windows.Forms.Button
    Friend WithEvents btn_RichText2 As System.Windows.Forms.Button
    Friend WithEvents btn_RichText4 As System.Windows.Forms.Button
    Friend WithEvents btn_RichText5 As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_Classify As Syscom.Client.UCL.UCLTextBoxUC
End Class
