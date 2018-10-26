<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPrintJobQueryUI
    'Inherits Com.Syscom.WinFormsUI.Docking.DockContent
    Inherits Syscom.Client.UCL.BaseFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PubPrintJobQueryUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.btn_Query = New System.Windows.Forms.Button
        Me.btn_Clear = New System.Windows.Forms.Button
        Me.cb_notYetDownload = New System.Windows.Forms.CheckBox
        Me.dgv_data = New Syscom.Client.UCL.UCLDataGridViewUC
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC
        Me.cbo_ReportName = New Syscom.Client.UCL.UCLComboBoxUC
        Me.tcq_User = New Syscom.Client.UCL.UCLTextCodeQueryUI
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC
        Me.txt_StartTime = New Syscom.Client.UCL.UCLTextBoxUC
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC
        Me.txt_EndTime = New Syscom.Client.UCL.UCLTextBoxUC
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 407.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_System, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_ReportName, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tcq_User, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 4, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(960, 99)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "使用者"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "處理時間"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "系統"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(423, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "至"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(423, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "報表名稱"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_StartDate)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_StartTime)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(135, 26)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(187, 33)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.dtp_EndDate)
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_EndTime)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(500, 26)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(203, 33)
        Me.FlowLayoutPanel2.TabIndex = 13
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(817, 117)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(74, 35)
        Me.btn_Query.TabIndex = 1
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(898, 117)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(74, 35)
        Me.btn_Clear.TabIndex = 2
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'cb_notYetDownload
        '
        Me.cb_notYetDownload.AutoSize = True
        Me.cb_notYetDownload.Checked = True
        Me.cb_notYetDownload.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_notYetDownload.Location = New System.Drawing.Point(18, 132)
        Me.cb_notYetDownload.Name = "cb_notYetDownload"
        Me.cb_notYetDownload.Size = New System.Drawing.Size(75, 20)
        Me.cb_notYetDownload.TabIndex = 4
        Me.cb_notYetDownload.Text = "未下載"
        Me.cb_notYetDownload.UseVisualStyleBackColor = True
        '
        'dgv_data
        '
        Me.dgv_data.AllowUserToAddRows = False
        Me.dgv_data.AllowUserToOrderColumns = False
        Me.dgv_data.AllowUserToResizeColumns = True
        Me.dgv_data.AllowUserToResizeRows = False
        Me.dgv_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_data.ColumnHeadersVisible = True
        Me.dgv_data.CurrentCell = Nothing
        Me.dgv_data.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_data.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_data.Location = New System.Drawing.Point(12, 159)
        Me.dgv_data.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_data.MultiSelect = False
        Me.dgv_data.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_data.Name = "dgv_data"
        Me.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_data.Size = New System.Drawing.Size(960, 470)
        Me.dgv_data.TabIndex = 3
        Me.dgv_data.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_data.uclBatchColIndex = ""
        Me.dgv_data.uclClickToCheck = False
        Me.dgv_data.uclColumnAlignment = ""
        Me.dgv_data.uclColumnCheckBox = False
        Me.dgv_data.uclColumnControlType = ""
        Me.dgv_data.uclColumnWidth = ""
        Me.dgv_data.uclDoCellEnter = True
        Me.dgv_data.uclHasNewRow = False
        Me.dgv_data.uclHeaderText = ""
        Me.dgv_data.uclIsAlternatingRowsColors = True
        Me.dgv_data.uclIsComboBoxGridQuery = True
        Me.dgv_data.uclIsDoOrderCheck = True
        Me.dgv_data.uclIsSortable = False
        Me.dgv_data.uclNonVisibleColIndex = ""
        Me.dgv_data.uclReadOnly = False
        Me.dgv_data.uclShowCellBorder = False
        Me.dgv_data.uclSortColIndex = ""
        Me.dgv_data.uclTreeMode = False
        Me.dgv_data.uclVisibleColIndex = ""
        '
        'cbo_System
        '
        Me.cbo_System.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(138, 67)
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(120, 24)
        Me.cbo_System.TabIndex = 10
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclIsTextMode = False
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'cbo_ReportName
        '
        Me.cbo_ReportName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cbo_ReportName, 2)
        Me.cbo_ReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_ReportName.DropDownWidth = 20
        Me.cbo_ReportName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_ReportName.Location = New System.Drawing.Point(503, 67)
        Me.cbo_ReportName.Name = "cbo_ReportName"
        Me.cbo_ReportName.SelectedIndex = -1
        Me.cbo_ReportName.SelectedItem = Nothing
        Me.cbo_ReportName.SelectedText = ""
        Me.cbo_ReportName.SelectedValue = ""
        Me.cbo_ReportName.SelectionStart = 0
        Me.cbo_ReportName.Size = New System.Drawing.Size(457, 24)
        Me.cbo_ReportName.TabIndex = 11
        Me.cbo_ReportName.uclDisplayIndex = "0,1"
        Me.cbo_ReportName.uclIsAutoClear = True
        Me.cbo_ReportName.uclIsTextMode = False
        Me.cbo_ReportName.uclShowMsg = False
        Me.cbo_ReportName.uclValueIndex = "0"
        '
        'tcq_User
        '
        Me.tcq_User.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_User.doFlag = True
        Me.tcq_User.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_User.Location = New System.Drawing.Point(135, 0)
        Me.tcq_User.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_User.Name = "tcq_User"
        Me.tcq_User.Size = New System.Drawing.Size(150, 26)
        Me.tcq_User.TabIndex = 3
        Me.tcq_User.uclCboWidth = 114
        Me.tcq_User.uclCodeName = ""
        Me.tcq_User.uclCodeValue1 = ""
        Me.tcq_User.uclCodeValue2 = ""
        Me.tcq_User.uclControlFlag = True
        Me.tcq_User.uclDisplayIndex = "0,1"
        Me.tcq_User.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_User.uclIsCheckDoctorOnDuty = False
        Me.tcq_User.uclIsReturnDS = False
        Me.tcq_User.uclIsShowMsgBox = True
        Me.tcq_User.uclIsTextAutoClear = True
        Me.tcq_User.uclQueryField = Nothing
        Me.tcq_User.uclQueryValue = Nothing
        Me.tcq_User.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_User.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_User.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_User.uclXPosition = 225
        Me.tcq_User.uclYPosition = 120
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(3, 3)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(120, 27)
        Me.dtp_StartDate.TabIndex = 6
        Me.dtp_StartDate.uclReadOnly = False
        '
        'txt_StartTime
        '
        Me.txt_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_StartTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_StartTime.Location = New System.Drawing.Point(129, 3)
        Me.txt_StartTime.MaxLength = 10
        Me.txt_StartTime.Name = "txt_StartTime"
        Me.txt_StartTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_StartTime.SelectionStart = 0
        Me.txt_StartTime.Size = New System.Drawing.Size(55, 27)
        Me.txt_StartTime.TabIndex = 7
        Me.txt_StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_StartTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_StartTime.uclDollarSign = False
        Me.txt_StartTime.uclDotCount = 0
        Me.txt_StartTime.uclIntCount = 2
        Me.txt_StartTime.uclMinus = False
        Me.txt_StartTime.uclReadOnly = False
        Me.txt_StartTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(3, 3)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(120, 27)
        Me.dtp_EndDate.TabIndex = 8
        Me.dtp_EndDate.uclReadOnly = False
        '
        'txt_EndTime
        '
        Me.txt_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_EndTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_EndTime.Location = New System.Drawing.Point(129, 3)
        Me.txt_EndTime.MaxLength = 10
        Me.txt_EndTime.Name = "txt_EndTime"
        Me.txt_EndTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_EndTime.SelectionStart = 0
        Me.txt_EndTime.Size = New System.Drawing.Size(55, 27)
        Me.txt_EndTime.TabIndex = 9
        Me.txt_EndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_EndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_EndTime.uclDollarSign = False
        Me.txt_EndTime.uclDotCount = 0
        Me.txt_EndTime.uclIntCount = 2
        Me.txt_EndTime.uclMinus = False
        Me.txt_EndTime.uclReadOnly = False
        Me.txt_EndTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        '
        'PubPrintJobQueryUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 642)
        Me.Controls.Add(Me.cb_notYetDownload)
        Me.Controls.Add(Me.dgv_data)
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.btn_Query)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PubPrintJobQueryUI"
        Me.TabText = "報表執行進度查詢"
        Me.Text = "報表執行進度查詢"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tcq_User As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_StartTime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_EndTime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_ReportName As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents dgv_data As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cb_notYetDownload As System.Windows.Forms.CheckBox
End Class
