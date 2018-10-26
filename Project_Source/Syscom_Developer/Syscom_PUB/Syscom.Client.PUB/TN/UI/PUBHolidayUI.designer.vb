<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBHolidayUI
    ' Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBHolidayUI))
        Me.palHoliday = New System.Windows.Forms.Panel()
        Me.tbpSubSystemCode = New System.Windows.Forms.TableLayoutPanel()
        Me.labHolidayYear = New System.Windows.Forms.Label()
        Me.txtHolidayYear = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.labHolidayDate = New System.Windows.Forms.Label()
        Me.dtpHolidayDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.labDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.labSubSystemCode = New System.Windows.Forms.Label()
        Me.cmbSubSystemCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rdbIsNonHoliday1 = New System.Windows.Forms.RadioButton()
        Me.rdbIsNonHoliday2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNoonCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.pal_main = New System.Windows.Forms.Panel()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.palHoliday.SuspendLayout()
        Me.tbpSubSystemCode.SuspendLayout()
        Me.pal_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 67)
        Me.IUCLMaintainPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1264, 390)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Location = New System.Drawing.Point(2, 36)
        Me.pal_1.Size = New System.Drawing.Size(1260, 353)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(1260, 353)
        '
        'palHoliday
        '
        Me.palHoliday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palHoliday.Controls.Add(Me.tbpSubSystemCode)
        Me.palHoliday.Location = New System.Drawing.Point(3, 12)
        Me.palHoliday.Name = "palHoliday"
        Me.palHoliday.Size = New System.Drawing.Size(1249, 48)
        Me.palHoliday.TabIndex = 0
        '
        'tbpSubSystemCode
        '
        Me.tbpSubSystemCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbpSubSystemCode.ColumnCount = 12
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.487103!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.29518!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.674199!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.84806!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.862191!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.805654!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.74205!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.597173!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66078!))
        Me.tbpSubSystemCode.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.84099!))
        Me.tbpSubSystemCode.Controls.Add(Me.labHolidayYear, 0, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.txtHolidayYear, 1, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.labHolidayDate, 2, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.dtpHolidayDate, 3, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.labDescription, 4, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.txtDescription, 5, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.labSubSystemCode, 6, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.cmbSubSystemCode, 7, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.rdbIsNonHoliday1, 8, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.rdbIsNonHoliday2, 9, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.Label1, 10, 0)
        Me.tbpSubSystemCode.Controls.Add(Me.cmbNoonCode, 11, 0)
        Me.tbpSubSystemCode.Location = New System.Drawing.Point(3, 0)
        Me.tbpSubSystemCode.Name = "tbpSubSystemCode"
        Me.tbpSubSystemCode.RowCount = 1
        Me.tbpSubSystemCode.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbpSubSystemCode.Size = New System.Drawing.Size(1241, 40)
        Me.tbpSubSystemCode.TabIndex = 0
        '
        'labHolidayYear
        '
        Me.labHolidayYear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labHolidayYear.AutoSize = True
        Me.labHolidayYear.ForeColor = System.Drawing.Color.Red
        Me.labHolidayYear.Location = New System.Drawing.Point(3, 12)
        Me.labHolidayYear.Name = "labHolidayYear"
        Me.labHolidayYear.Size = New System.Drawing.Size(40, 16)
        Me.labHolidayYear.TabIndex = 0
        Me.labHolidayYear.Text = "年度"
        '
        'txtHolidayYear
        '
        Me.txtHolidayYear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtHolidayYear.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtHolidayYear.Location = New System.Drawing.Point(50, 6)
        Me.txtHolidayYear.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHolidayYear.MaxLength = 3
        Me.txtHolidayYear.Name = "txtHolidayYear"
        Me.txtHolidayYear.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHolidayYear.SelectionStart = 0
        Me.txtHolidayYear.Size = New System.Drawing.Size(55, 27)
        Me.txtHolidayYear.TabIndex = 0
        Me.txtHolidayYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtHolidayYear.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtHolidayYear.ToolTipTag = Nothing
        Me.txtHolidayYear.uclDollarSign = False
        Me.txtHolidayYear.uclDotCount = 0
        Me.txtHolidayYear.uclIntCount = 4
        Me.txtHolidayYear.uclMinus = False
        Me.txtHolidayYear.uclReadOnly = False
        Me.txtHolidayYear.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txtHolidayYear.uclTrimZero = True
        '
        'labHolidayDate
        '
        Me.labHolidayDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labHolidayDate.AutoSize = True
        Me.labHolidayDate.ForeColor = System.Drawing.Color.Red
        Me.labHolidayDate.Location = New System.Drawing.Point(119, 12)
        Me.labHolidayDate.Name = "labHolidayDate"
        Me.labHolidayDate.Size = New System.Drawing.Size(48, 16)
        Me.labHolidayDate.TabIndex = 2
        Me.labHolidayDate.Text = "*日期"
        '
        'dtpHolidayDate
        '
        Me.dtpHolidayDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpHolidayDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtpHolidayDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtpHolidayDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpHolidayDate.Location = New System.Drawing.Point(173, 6)
        Me.dtpHolidayDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpHolidayDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpHolidayDate.Name = "dtpHolidayDate"
        Me.dtpHolidayDate.Size = New System.Drawing.Size(115, 27)
        Me.dtpHolidayDate.TabIndex = 1
        Me.dtpHolidayDate.uclReadOnly = False
        '
        'labDescription
        '
        Me.labDescription.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labDescription.AutoSize = True
        Me.labDescription.Location = New System.Drawing.Point(317, 12)
        Me.labDescription.Name = "labDescription"
        Me.labDescription.Size = New System.Drawing.Size(40, 16)
        Me.labDescription.TabIndex = 4
        Me.labDescription.Text = "說明"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDescription.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDescription.Location = New System.Drawing.Point(364, 6)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescription.MaxLength = 200
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDescription.SelectionStart = 0
        Me.txtDescription.Size = New System.Drawing.Size(224, 27)
        Me.txtDescription.TabIndex = 2
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDescription.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDescription.ToolTipTag = Nothing
        Me.txtDescription.uclDollarSign = False
        Me.txtDescription.uclDotCount = 0
        Me.txtDescription.uclIntCount = 2
        Me.txtDescription.uclMinus = False
        Me.txtDescription.uclReadOnly = False
        Me.txtDescription.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDescription.uclTrimZero = True
        '
        'labSubSystemCode
        '
        Me.labSubSystemCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.labSubSystemCode.AutoSize = True
        Me.labSubSystemCode.ForeColor = System.Drawing.Color.Red
        Me.labSubSystemCode.Location = New System.Drawing.Point(599, 12)
        Me.labSubSystemCode.Name = "labSubSystemCode"
        Me.labSubSystemCode.Size = New System.Drawing.Size(80, 16)
        Me.labSubSystemCode.TabIndex = 6
        Me.labSubSystemCode.Text = "*使用單位"
        '
        'cmbSubSystemCode
        '
        Me.cmbSubSystemCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubSystemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSystemCode.DropDownWidth = 20
        Me.cmbSubSystemCode.DroppedDown = False
        Me.cmbSubSystemCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubSystemCode.Location = New System.Drawing.Point(686, 8)
        Me.cmbSubSystemCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubSystemCode.Name = "cmbSubSystemCode"
        Me.cmbSubSystemCode.SelectedIndex = -1
        Me.cmbSubSystemCode.SelectedItem = Nothing
        Me.cmbSubSystemCode.SelectedText = ""
        Me.cmbSubSystemCode.SelectedValue = ""
        Me.cmbSubSystemCode.SelectionStart = 0
        Me.cmbSubSystemCode.Size = New System.Drawing.Size(95, 24)
        Me.cmbSubSystemCode.TabIndex = 3
        Me.cmbSubSystemCode.uclDisplayIndex = "0,1"
        Me.cmbSubSystemCode.uclIsAutoClear = True
        Me.cmbSubSystemCode.uclIsFirstItemEmpty = False
        Me.cmbSubSystemCode.uclIsTextMode = False
        Me.cmbSubSystemCode.uclShowMsg = False
        Me.cmbSubSystemCode.uclValueIndex = "0"
        '
        'rdbIsNonHoliday1
        '
        Me.rdbIsNonHoliday1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbIsNonHoliday1.AutoSize = True
        Me.rdbIsNonHoliday1.Location = New System.Drawing.Point(795, 10)
        Me.rdbIsNonHoliday1.Name = "rdbIsNonHoliday1"
        Me.rdbIsNonHoliday1.Size = New System.Drawing.Size(58, 20)
        Me.rdbIsNonHoliday1.TabIndex = 4
        Me.rdbIsNonHoliday1.TabStop = True
        Me.rdbIsNonHoliday1.Text = "假日"
        Me.rdbIsNonHoliday1.UseVisualStyleBackColor = True
        '
        'rdbIsNonHoliday2
        '
        Me.rdbIsNonHoliday2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbIsNonHoliday2.AutoSize = True
        Me.rdbIsNonHoliday2.Location = New System.Drawing.Point(861, 10)
        Me.rdbIsNonHoliday2.Name = "rdbIsNonHoliday2"
        Me.rdbIsNonHoliday2.Size = New System.Drawing.Size(74, 20)
        Me.rdbIsNonHoliday2.TabIndex = 5
        Me.rdbIsNonHoliday2.TabStop = True
        Me.rdbIsNonHoliday2.Text = "非假日"
        Me.rdbIsNonHoliday2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(948, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "歸屬假日之午別"
        '
        'cmbNoonCode
        '
        Me.cmbNoonCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbNoonCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNoonCode.DropDownWidth = 20
        Me.cmbNoonCode.DroppedDown = False
        Me.cmbNoonCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbNoonCode.Location = New System.Drawing.Point(1075, 8)
        Me.cmbNoonCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbNoonCode.Name = "cmbNoonCode"
        Me.cmbNoonCode.SelectedIndex = -1
        Me.cmbNoonCode.SelectedItem = Nothing
        Me.cmbNoonCode.SelectedText = ""
        Me.cmbNoonCode.SelectedValue = ""
        Me.cmbNoonCode.SelectionStart = 0
        Me.cmbNoonCode.Size = New System.Drawing.Size(95, 24)
        Me.cmbNoonCode.TabIndex = 8
        Me.cmbNoonCode.uclDisplayIndex = "0,1"
        Me.cmbNoonCode.uclIsAutoClear = True
        Me.cmbNoonCode.uclIsFirstItemEmpty = True
        Me.cmbNoonCode.uclIsTextMode = False
        Me.cmbNoonCode.uclShowMsg = False
        Me.cmbNoonCode.uclValueIndex = "0"
        '
        'pal_main
        '
        Me.pal_main.Controls.Add(Me.palHoliday)
        Me.pal_main.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_main.Location = New System.Drawing.Point(0, 0)
        Me.pal_main.Margin = New System.Windows.Forms.Padding(4)
        Me.pal_main.Name = "pal_main"
        Me.pal_main.Size = New System.Drawing.Size(1264, 67)
        Me.pal_main.TabIndex = 0
        '
        'PUBHolidayUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 457)
        Me.Controls.Add(Me.pal_main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBHolidayUI"
        Me.Text = "假日檔維護"
        Me.Controls.SetChildIndex(Me.pal_main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.palHoliday.ResumeLayout(False)
        Me.tbpSubSystemCode.ResumeLayout(False)
        Me.tbpSubSystemCode.PerformLayout()
        Me.pal_main.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents palHoliday As System.Windows.Forms.Panel
    Friend WithEvents tbpSubSystemCode As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents labHolidayYear As System.Windows.Forms.Label
    Friend WithEvents txtHolidayYear As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents labHolidayDate As System.Windows.Forms.Label
    Friend WithEvents dtpHolidayDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents labDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents labSubSystemCode As System.Windows.Forms.Label
    Friend WithEvents cmbSubSystemCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents rdbIsNonHoliday1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbIsNonHoliday2 As System.Windows.Forms.RadioButton
    Friend WithEvents pal_main As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNoonCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
