<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBStationUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBStationUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_StationNo = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_StationName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Floor = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_RegionKind = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_ConsumptionUnit = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_ConsumptionName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_StationEmail = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_StationExtTel = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chk_Dc = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 93)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1354, 640)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(1352, 603)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(1352, 603)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 1
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1354.0!))
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(1354, 84)
        Me.tlp_Main.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_StationNo)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_StationName)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_Floor)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel2.Controls.Add(Me.cbo_RegionKind)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 5)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(1347, 31)
        Me.FlowLayoutPanel2.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "護理站代碼"
        '
        'txt_StationNo
        '
        Me.txt_StationNo.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_StationNo.Location = New System.Drawing.Point(97, 3)
        Me.txt_StationNo.MaxLength = 6
        Me.txt_StationNo.Name = "txt_StationNo"
        Me.txt_StationNo.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_StationNo.SelectionStart = 0
        Me.txt_StationNo.Size = New System.Drawing.Size(68, 27)
        Me.txt_StationNo.TabIndex = 2
        Me.txt_StationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_StationNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_StationNo.ToolTipTag = Nothing
        Me.txt_StationNo.uclDollarSign = False
        Me.txt_StationNo.uclDotCount = 0
        Me.txt_StationNo.uclIntCount = 2
        Me.txt_StationNo.uclMinus = False
        Me.txt_StationNo.uclReadOnly = False
        Me.txt_StationNo.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_StationNo.uclTrimZero = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "護理站名稱"
        '
        'txt_StationName
        '
        Me.txt_StationName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_StationName.Location = New System.Drawing.Point(265, 3)
        Me.txt_StationName.MaxLength = 20
        Me.txt_StationName.Name = "txt_StationName"
        Me.txt_StationName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_StationName.SelectionStart = 0
        Me.txt_StationName.Size = New System.Drawing.Size(340, 27)
        Me.txt_StationName.TabIndex = 3
        Me.txt_StationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_StationName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_StationName.ToolTipTag = Nothing
        Me.txt_StationName.uclDollarSign = False
        Me.txt_StationName.uclDotCount = 0
        Me.txt_StationName.uclIntCount = 2
        Me.txt_StationName.uclMinus = False
        Me.txt_StationName.uclReadOnly = False
        Me.txt_StationName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_StationName.uclTrimZero = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(611, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "樓層位置"
        '
        'txt_Floor
        '
        Me.txt_Floor.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Floor.Location = New System.Drawing.Point(689, 3)
        Me.txt_Floor.MaxLength = 2
        Me.txt_Floor.Name = "txt_Floor"
        Me.txt_Floor.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Floor.SelectionStart = 0
        Me.txt_Floor.Size = New System.Drawing.Size(47, 27)
        Me.txt_Floor.TabIndex = 5
        Me.txt_Floor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Floor.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Floor.ToolTipTag = Nothing
        Me.txt_Floor.uclDollarSign = False
        Me.txt_Floor.uclDotCount = 0
        Me.txt_Floor.uclIntCount = 2
        Me.txt_Floor.uclMinus = False
        Me.txt_Floor.uclReadOnly = False
        Me.txt_Floor.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Floor.uclTrimZero = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(742, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "區域種類"
        '
        'cbo_RegionKind
        '
        Me.cbo_RegionKind.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_RegionKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_RegionKind.DropDownWidth = 20
        Me.cbo_RegionKind.DroppedDown = False
        Me.cbo_RegionKind.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_RegionKind.Location = New System.Drawing.Point(817, 6)
        Me.cbo_RegionKind.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_RegionKind.Name = "cbo_RegionKind"
        Me.cbo_RegionKind.SelectedIndex = -1
        Me.cbo_RegionKind.SelectedItem = Nothing
        Me.cbo_RegionKind.SelectedText = ""
        Me.cbo_RegionKind.SelectedValue = ""
        Me.cbo_RegionKind.SelectionStart = 0
        Me.cbo_RegionKind.Size = New System.Drawing.Size(125, 20)
        Me.cbo_RegionKind.TabIndex = 6
        Me.cbo_RegionKind.uclDisplayIndex = "0,1"
        Me.cbo_RegionKind.uclIsAutoClear = True
        Me.cbo_RegionKind.uclIsFirstItemEmpty = True
        Me.cbo_RegionKind.uclIsTextMode = False
        Me.cbo_RegionKind.uclShowMsg = False
        Me.cbo_RegionKind.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_ConsumptionUnit)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_ConsumptionName)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_StationEmail)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_StationExtTel)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_Dc)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 47)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1348, 31)
        Me.FlowLayoutPanel1.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "    消耗單位"
        '
        'txt_ConsumptionUnit
        '
        Me.txt_ConsumptionUnit.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ConsumptionUnit.Location = New System.Drawing.Point(97, 3)
        Me.txt_ConsumptionUnit.MaxLength = 10
        Me.txt_ConsumptionUnit.Name = "txt_ConsumptionUnit"
        Me.txt_ConsumptionUnit.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ConsumptionUnit.SelectionStart = 0
        Me.txt_ConsumptionUnit.Size = New System.Drawing.Size(68, 27)
        Me.txt_ConsumptionUnit.TabIndex = 7
        Me.txt_ConsumptionUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ConsumptionUnit.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ConsumptionUnit.ToolTipTag = Nothing
        Me.txt_ConsumptionUnit.uclDollarSign = False
        Me.txt_ConsumptionUnit.uclDotCount = 0
        Me.txt_ConsumptionUnit.uclIntCount = 2
        Me.txt_ConsumptionUnit.uclMinus = False
        Me.txt_ConsumptionUnit.uclReadOnly = False
        Me.txt_ConsumptionUnit.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ConsumptionUnit.uclTrimZero = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(171, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "消耗單位名稱"
        '
        'txt_ConsumptionName
        '
        Me.txt_ConsumptionName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ConsumptionName.Location = New System.Drawing.Point(281, 3)
        Me.txt_ConsumptionName.MaxLength = 50
        Me.txt_ConsumptionName.Name = "txt_ConsumptionName"
        Me.txt_ConsumptionName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ConsumptionName.SelectionStart = 0
        Me.txt_ConsumptionName.Size = New System.Drawing.Size(145, 27)
        Me.txt_ConsumptionName.TabIndex = 8
        Me.txt_ConsumptionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ConsumptionName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ConsumptionName.ToolTipTag = Nothing
        Me.txt_ConsumptionName.uclDollarSign = False
        Me.txt_ConsumptionName.uclDotCount = 0
        Me.txt_ConsumptionName.uclIntCount = 2
        Me.txt_ConsumptionName.uclMinus = False
        Me.txt_ConsumptionName.uclReadOnly = False
        Me.txt_ConsumptionName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ConsumptionName.uclTrimZero = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(432, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "護理站Email"
        '
        'txt_StationEmail
        '
        Me.txt_StationEmail.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_StationEmail.Location = New System.Drawing.Point(530, 3)
        Me.txt_StationEmail.MaxLength = 100
        Me.txt_StationEmail.Name = "txt_StationEmail"
        Me.txt_StationEmail.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_StationEmail.SelectionStart = 0
        Me.txt_StationEmail.Size = New System.Drawing.Size(178, 27)
        Me.txt_StationEmail.TabIndex = 9
        Me.txt_StationEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_StationEmail.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_StationEmail.ToolTipTag = Nothing
        Me.txt_StationEmail.uclDollarSign = False
        Me.txt_StationEmail.uclDotCount = 0
        Me.txt_StationEmail.uclIntCount = 2
        Me.txt_StationEmail.uclMinus = False
        Me.txt_StationEmail.uclReadOnly = False
        Me.txt_StationEmail.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_StationEmail.uclTrimZero = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(714, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "護理站分機"
        '
        'txt_StationExtTel
        '
        Me.txt_StationExtTel.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_StationExtTel.Location = New System.Drawing.Point(808, 3)
        Me.txt_StationExtTel.MaxLength = 10
        Me.txt_StationExtTel.Name = "txt_StationExtTel"
        Me.txt_StationExtTel.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_StationExtTel.SelectionStart = 0
        Me.txt_StationExtTel.Size = New System.Drawing.Size(92, 27)
        Me.txt_StationExtTel.TabIndex = 10
        Me.txt_StationExtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_StationExtTel.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_StationExtTel.ToolTipTag = Nothing
        Me.txt_StationExtTel.uclDollarSign = False
        Me.txt_StationExtTel.uclDotCount = 0
        Me.txt_StationExtTel.uclIntCount = 2
        Me.txt_StationExtTel.uclMinus = False
        Me.txt_StationExtTel.uclReadOnly = False
        Me.txt_StationExtTel.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_StationExtTel.uclTrimZero = True
        '
        'chk_Dc
        '
        Me.chk_Dc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chk_Dc.AutoSize = True
        Me.chk_Dc.Location = New System.Drawing.Point(906, 6)
        Me.chk_Dc.Name = "chk_Dc"
        Me.chk_Dc.Size = New System.Drawing.Size(59, 20)
        Me.chk_Dc.TabIndex = 15
        Me.chk_Dc.Text = "停用"
        Me.chk_Dc.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlp_Main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1354, 93)
        Me.Panel1.TabIndex = 0
        '
        'PUBStationUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBStationUI"
        Me.Text = "PUBStation"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_StationNo As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_StationName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_Floor As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_RegionKind As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ConsumptionUnit As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ConsumptionName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_StationEmail As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_StationExtTel As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chk_Dc As System.Windows.Forms.CheckBox
End Class
