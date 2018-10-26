<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAreaCodeNSetupUI
    'Inherits System.Windows.Forms.Form
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
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_AreaCode = New System.Windows.Forms.Label()
        Me.lbl_CountyCode = New System.Windows.Forms.Label()
        Me.lbl_OrigAreaCode = New System.Windows.Forms.Label()
        Me.lbl_SortValue = New System.Windows.Forms.Label()
        Me.lbl_AreaName = New System.Windows.Forms.Label()
        Me.txt_AreaCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_CountyCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_OrigAreaCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_SortValue = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txt_AreaName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 116)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(748, 233)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(746, 196)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(746, 196)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.30079!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.69921!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260.0!))
        Me.tlp_Main.Controls.Add(Me.lbl_AreaCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_CountyCode, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_OrigAreaCode, 0, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_SortValue, 2, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_AreaName, 0, 2)
        Me.tlp_Main.Controls.Add(Me.txt_AreaCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_CountyCode, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_OrigAreaCode, 1, 1)
        Me.tlp_Main.Controls.Add(Me.txt_SortValue, 3, 1)
        Me.tlp_Main.Controls.Add(Me.txt_AreaName, 1, 2)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 3
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(748, 116)
        Me.tlp_Main.TabIndex = 0
        '
        'lbl_AreaCode
        '
        Me.lbl_AreaCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AreaCode.AutoSize = True
        Me.lbl_AreaCode.Location = New System.Drawing.Point(22, 11)
        Me.lbl_AreaCode.Name = "lbl_AreaCode"
        Me.lbl_AreaCode.Size = New System.Drawing.Size(104, 16)
        Me.lbl_AreaCode.TabIndex = 0
        Me.lbl_AreaCode.Text = "戶籍地代碼："
        '
        'lbl_CountyCode
        '
        Me.lbl_CountyCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_CountyCode.AutoSize = True
        Me.lbl_CountyCode.Location = New System.Drawing.Point(396, 11)
        Me.lbl_CountyCode.Name = "lbl_CountyCode"
        Me.lbl_CountyCode.Size = New System.Drawing.Size(88, 16)
        Me.lbl_CountyCode.TabIndex = 1
        Me.lbl_CountyCode.Text = "縣市代碼："
        '
        'lbl_OrigAreaCode
        '
        Me.lbl_OrigAreaCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_OrigAreaCode.AutoSize = True
        Me.lbl_OrigAreaCode.Location = New System.Drawing.Point(6, 49)
        Me.lbl_OrigAreaCode.Name = "lbl_OrigAreaCode"
        Me.lbl_OrigAreaCode.Size = New System.Drawing.Size(120, 16)
        Me.lbl_OrigAreaCode.TabIndex = 2
        Me.lbl_OrigAreaCode.Text = "原戶籍地代碼："
        '
        'lbl_SortValue
        '
        Me.lbl_SortValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SortValue.AutoSize = True
        Me.lbl_SortValue.Location = New System.Drawing.Point(428, 49)
        Me.lbl_SortValue.Name = "lbl_SortValue"
        Me.lbl_SortValue.Size = New System.Drawing.Size(56, 16)
        Me.lbl_SortValue.TabIndex = 3
        Me.lbl_SortValue.Text = "排序："
        '
        'lbl_AreaName
        '
        Me.lbl_AreaName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AreaName.AutoSize = True
        Me.lbl_AreaName.Location = New System.Drawing.Point(22, 88)
        Me.lbl_AreaName.Name = "lbl_AreaName"
        Me.lbl_AreaName.Size = New System.Drawing.Size(104, 16)
        Me.lbl_AreaName.TabIndex = 4
        Me.lbl_AreaName.Text = "戶籍地名稱："
        '
        'txt_AreaCode
        '
        Me.txt_AreaCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AreaCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_AreaCode.Location = New System.Drawing.Point(132, 8)
        Me.txt_AreaCode.MaxLength = 10
        Me.txt_AreaCode.Name = "txt_AreaCode"
        Me.txt_AreaCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_AreaCode.SelectionStart = 0
        Me.txt_AreaCode.Size = New System.Drawing.Size(129, 22)
        Me.txt_AreaCode.TabIndex = 5
        Me.txt_AreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_AreaCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_AreaCode.ToolTipTag = Nothing
        Me.txt_AreaCode.uclDollarSign = False
        Me.txt_AreaCode.uclDotCount = 0
        Me.txt_AreaCode.uclIntCount = 2
        Me.txt_AreaCode.uclMinus = False
        Me.txt_AreaCode.uclReadOnly = False
        Me.txt_AreaCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_AreaCode.uclTrimZero = True
        '
        'txt_CountyCode
        '
        Me.txt_CountyCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_CountyCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_CountyCode.Location = New System.Drawing.Point(490, 7)
        Me.txt_CountyCode.MaxLength = 10
        Me.txt_CountyCode.Name = "txt_CountyCode"
        Me.txt_CountyCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_CountyCode.SelectionStart = 0
        Me.txt_CountyCode.Size = New System.Drawing.Size(129, 24)
        Me.txt_CountyCode.TabIndex = 6
        Me.txt_CountyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_CountyCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_CountyCode.ToolTipTag = Nothing
        Me.txt_CountyCode.uclDollarSign = False
        Me.txt_CountyCode.uclDotCount = 0
        Me.txt_CountyCode.uclIntCount = 2
        Me.txt_CountyCode.uclMinus = False
        Me.txt_CountyCode.uclReadOnly = False
        Me.txt_CountyCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_CountyCode.uclTrimZero = True
        '
        'txt_OrigAreaCode
        '
        Me.txt_OrigAreaCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrigAreaCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrigAreaCode.Location = New System.Drawing.Point(132, 46)
        Me.txt_OrigAreaCode.MaxLength = 10
        Me.txt_OrigAreaCode.Name = "txt_OrigAreaCode"
        Me.txt_OrigAreaCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrigAreaCode.SelectionStart = 0
        Me.txt_OrigAreaCode.Size = New System.Drawing.Size(129, 22)
        Me.txt_OrigAreaCode.TabIndex = 7
        Me.txt_OrigAreaCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrigAreaCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrigAreaCode.ToolTipTag = Nothing
        Me.txt_OrigAreaCode.uclDollarSign = False
        Me.txt_OrigAreaCode.uclDotCount = 0
        Me.txt_OrigAreaCode.uclIntCount = 2
        Me.txt_OrigAreaCode.uclMinus = False
        Me.txt_OrigAreaCode.uclReadOnly = False
        Me.txt_OrigAreaCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_OrigAreaCode.uclTrimZero = True
        '
        'txt_SortValue
        '
        Me.txt_SortValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_SortValue.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_SortValue.Location = New System.Drawing.Point(490, 45)
        Me.txt_SortValue.MaxLength = 10
        Me.txt_SortValue.Name = "txt_SortValue"
        Me.txt_SortValue.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_SortValue.SelectionStart = 0
        Me.txt_SortValue.Size = New System.Drawing.Size(129, 24)
        Me.txt_SortValue.TabIndex = 8
        Me.txt_SortValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_SortValue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_SortValue.ToolTipTag = Nothing
        Me.txt_SortValue.uclDollarSign = False
        Me.txt_SortValue.uclDotCount = 0
        Me.txt_SortValue.uclIntCount = 2
        Me.txt_SortValue.uclMinus = False
        Me.txt_SortValue.uclReadOnly = False
        Me.txt_SortValue.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_SortValue.uclTrimZero = True
        '
        'txt_AreaName
        '
        Me.txt_AreaName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AreaName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_AreaName.Location = New System.Drawing.Point(132, 85)
        Me.txt_AreaName.MaxLength = 10
        Me.txt_AreaName.Name = "txt_AreaName"
        Me.txt_AreaName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_AreaName.SelectionStart = 0
        Me.txt_AreaName.Size = New System.Drawing.Size(129, 21)
        Me.txt_AreaName.TabIndex = 9
        Me.txt_AreaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_AreaName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_AreaName.ToolTipTag = Nothing
        Me.txt_AreaName.uclDollarSign = False
        Me.txt_AreaName.uclDotCount = 0
        Me.txt_AreaName.uclIntCount = 2
        Me.txt_AreaName.uclMinus = False
        Me.txt_AreaName.uclReadOnly = False
        Me.txt_AreaName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_AreaName.uclTrimZero = True
        '
        'PUBAreaCodeNSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 349)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBAreaCodeNSetupUI"
        Me.Text = "PUBAreaCodeNSetupUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_AreaCode As System.Windows.Forms.Label
    Friend WithEvents lbl_CountyCode As System.Windows.Forms.Label
    Friend WithEvents lbl_OrigAreaCode As System.Windows.Forms.Label
    Friend WithEvents lbl_SortValue As System.Windows.Forms.Label
    Friend WithEvents lbl_AreaName As System.Windows.Forms.Label
    Friend WithEvents txt_AreaCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_CountyCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_OrigAreaCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_SortValue As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txt_AreaName As Syscom.Client.UCL.UCLTextBoxUC
End Class
