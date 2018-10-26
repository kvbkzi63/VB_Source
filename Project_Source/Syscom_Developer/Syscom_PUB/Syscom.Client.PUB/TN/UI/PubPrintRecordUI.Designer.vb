<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPrintRecordUI
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Report_ID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Print_IP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Create_User = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txt_Report_Name = New System.Windows.Forms.TextBox()
        Me.ti_Create_Time = New Syscom.Client.UCL.UclTimeIntervalUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_ExportExcel = New System.Windows.Forms.Button()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.dgv_Data = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 6
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Report_ID, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 1)
        Me.tlp_Main.Controls.Add(Me.Label5, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Print_IP, 1, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 4, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Create_User, 5, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Report_Name, 3, 0)
        Me.tlp_Main.Controls.Add(Me.ti_Create_Time, 3, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 78)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "報表代碼"
        '
        'txt_Report_ID
        '
        Me.txt_Report_ID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Report_ID.Location = New System.Drawing.Point(81, 3)
        Me.txt_Report_ID.Name = "txt_Report_ID"
        Me.txt_Report_ID.Size = New System.Drawing.Size(156, 27)
        Me.txt_Report_ID.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "查詢時間起迄"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "列印IP"
        '
        'txt_Print_IP
        '
        Me.txt_Print_IP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Print_IP.Location = New System.Drawing.Point(81, 42)
        Me.txt_Print_IP.Name = "txt_Print_IP"
        Me.txt_Print_IP.Size = New System.Drawing.Size(156, 27)
        Me.txt_Print_IP.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(515, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "列印者員工編號"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "報表名稱"
        '
        'txt_Create_User
        '
        Me.txt_Create_User.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Create_User.doFlag = True
        Me.txt_Create_User.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_Create_User.Location = New System.Drawing.Point(638, 3)
        Me.txt_Create_User.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Create_User.Name = "txt_Create_User"
        Me.txt_Create_User.Size = New System.Drawing.Size(162, 26)
        Me.txt_Create_User.TabIndex = 21
        Me.txt_Create_User.uclBaseDate = "2015/05/28"
        Me.txt_Create_User.uclCboWidth = 126
        Me.txt_Create_User.uclCodeName = ""
        Me.txt_Create_User.uclCodeName1 = ""
        Me.txt_Create_User.uclCodeName2 = ""
        Me.txt_Create_User.uclCodeValue = ""
        Me.txt_Create_User.uclCodeValue1 = ""
        Me.txt_Create_User.uclCodeValue2 = ""
        Me.txt_Create_User.uclControlFlag = True
        Me.txt_Create_User.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_Create_User.uclDisplayIndex = "0,1"
        Me.txt_Create_User.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_Create_User.uclIsAutoAddZero = False
        Me.txt_Create_User.uclIsBtnVisible = True
        Me.txt_Create_User.uclIsCheckDoctorOnDuty = False
        Me.txt_Create_User.uclIsReturnDS = False
        Me.txt_Create_User.uclIsShowMsgBox = True
        Me.txt_Create_User.uclIsTextAutoClear = True
        Me.txt_Create_User.uclMsgValue = Nothing
        Me.txt_Create_User.uclPUBEmployeeProfessalKindId = ""
        Me.txt_Create_User.uclQueryField = Nothing
        Me.txt_Create_User.uclQueryValue = Nothing
        Me.txt_Create_User.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_Create_User.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.txt_Create_User.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txt_Create_User.uclTotalWidth = 8
        Me.txt_Create_User.uclXPosition = 225
        Me.txt_Create_User.uclYPosition = 120
        '
        'txt_Report_Name
        '
        Me.txt_Report_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Report_Name.Location = New System.Drawing.Point(353, 3)
        Me.txt_Report_Name.Name = "txt_Report_Name"
        Me.txt_Report_Name.Size = New System.Drawing.Size(156, 27)
        Me.txt_Report_Name.TabIndex = 18
        '
        'ti_Create_Time
        '
        Me.tlp_Main.SetColumnSpan(Me.ti_Create_Time, 3)
        Me.ti_Create_Time.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ti_Create_Time.Location = New System.Drawing.Point(354, 37)
        Me.ti_Create_Time.Margin = New System.Windows.Forms.Padding(4)
        Me.ti_Create_Time.Name = "ti_Create_Time"
        Me.ti_Create_Time.Size = New System.Drawing.Size(358, 33)
        Me.ti_Create_Time.TabIndex = 14
        Me.ti_Create_Time.uclDisplayFormate = ""
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_ExportExcel)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 78)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(964, 37)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btn_ExportExcel
        '
        Me.btn_ExportExcel.Location = New System.Drawing.Point(871, 3)
        Me.btn_ExportExcel.Name = "btn_ExportExcel"
        Me.btn_ExportExcel.Size = New System.Drawing.Size(90, 28)
        Me.btn_ExportExcel.TabIndex = 0
        Me.btn_ExportExcel.Text = "SF-12匯出"
        Me.btn_ExportExcel.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(775, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(90, 28)
        Me.btn_Clear.TabIndex = 1
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(679, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(90, 28)
        Me.btn_Query.TabIndex = 2
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'dgv_Data
        '
        Me.dgv_Data.AllowUserToAddRows = False
        Me.dgv_Data.AllowUserToOrderColumns = False
        Me.dgv_Data.AllowUserToResizeColumns = True
        Me.dgv_Data.AllowUserToResizeRows = False
        Me.dgv_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.dgv_Data.ColumnHeadersHeight = 4
        Me.dgv_Data.ColumnHeadersVisible = True
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
        Me.dgv_Data.Location = New System.Drawing.Point(0, 115)
        Me.dgv_Data.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Data.MultiSelect = False
        Me.dgv_Data.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.RowHeadersWidth = 41
        Me.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Data.Size = New System.Drawing.Size(964, 526)
        Me.dgv_Data.TabIndex = 2
        Me.dgv_Data.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Data.uclBatchColIndex = ""
        Me.dgv_Data.uclClickToCheck = False
        Me.dgv_Data.uclColumnAlignment = ""
        Me.dgv_Data.uclColumnCheckBox = False
        Me.dgv_Data.uclColumnControlType = ""
        Me.dgv_Data.uclColumnWidth = ""
        Me.dgv_Data.uclDoCellEnter = True
        Me.dgv_Data.uclHasNewRow = False
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
        'PubPrintRecordUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.dgv_Data)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.tlp_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PubPrintRecordUI"
        Me.TabText = "報表列印記錄檔查詢作業"
        Me.Text = "報表列印記錄檔查詢作業"
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Report_ID As System.Windows.Forms.TextBox
    Friend WithEvents ti_Create_Time As Syscom.Client.UCL.UclTimeIntervalUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_ExportExcel As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents dgv_Data As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents txt_Report_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Print_IP As System.Windows.Forms.TextBox
    Friend WithEvents txt_Create_User As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
