<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBExportOrderDataUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBExportOrderDataUI))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ucl_Code = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Ucl_Type = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_Time = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_OrderCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ucl_QyeryType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnGExport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvQuery = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(274, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "醫令類型"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "醫令代碼"
        '
        'Ucl_Code
        '
        Me.Ucl_Code.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ucl_Code.doFlag = True
        Me.Ucl_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Ucl_Code.Location = New System.Drawing.Point(80, 13)
        Me.Ucl_Code.Margin = New System.Windows.Forms.Padding(0)
        Me.Ucl_Code.Name = "Ucl_Code"
        Me.Ucl_Code.Size = New System.Drawing.Size(190, 26)
        Me.Ucl_Code.TabIndex = 1
        Me.Ucl_Code.uclBaseDate = "2015/05/01"
        Me.Ucl_Code.uclCboWidth = 154
        Me.Ucl_Code.uclCodeName = ""
        Me.Ucl_Code.uclCodeValue1 = ""
        Me.Ucl_Code.uclCodeValue2 = ""
        Me.Ucl_Code.uclControlFlag = True
        Me.Ucl_Code.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.Ucl_Code.uclDisplayIndex = "0,1"
        Me.Ucl_Code.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Ucl_Code.uclIsAutoAddZero = False
        Me.Ucl_Code.uclIsCheckDoctorOnDuty = False
        Me.Ucl_Code.uclIsReturnDS = False
        Me.Ucl_Code.uclIsShowMsgBox = True
        Me.Ucl_Code.uclIsTextAutoClear = True
        Me.Ucl_Code.uclMsgValue = Nothing
        Me.Ucl_Code.uclPUBEmployeeProfessalKindId = ""
        Me.Ucl_Code.uclQueryField = Nothing
        Me.Ucl_Code.uclQueryValue = Nothing
        Me.Ucl_Code.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.Ucl_Code.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.Ucl_Code.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.Ucl_Code.uclTotalWidth = 8
        Me.Ucl_Code.uclXPosition = 225
        Me.Ucl_Code.uclYPosition = 120
        '
        'Ucl_Type
        '
        Me.Ucl_Type.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ucl_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.Ucl_Type.DropDownWidth = 20
        Me.Ucl_Type.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Ucl_Type.Location = New System.Drawing.Point(356, 14)
        Me.Ucl_Type.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Ucl_Type.Name = "Ucl_Type"
        Me.Ucl_Type.SelectedIndex = -1
        Me.Ucl_Type.SelectedItem = Nothing
        Me.Ucl_Type.SelectedText = ""
        Me.Ucl_Type.SelectedValue = ""
        Me.Ucl_Type.SelectionStart = 0
        Me.Ucl_Type.Size = New System.Drawing.Size(137, 24)
        Me.Ucl_Type.TabIndex = 2
        Me.Ucl_Type.uclDisplayIndex = "0,1"
        Me.Ucl_Type.uclIsAutoClear = True
        Me.Ucl_Type.uclIsFirstItemEmpty = True
        Me.Ucl_Type.uclIsTextMode = False
        Me.Ucl_Type.uclShowMsg = False
        Me.Ucl_Type.uclValueIndex = "0"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Ucl_Code, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Ucl_Type, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExport, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_Time, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 52)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'btnExport
        '
        Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnExport.Location = New System.Drawing.Point(683, 12)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(78, 27)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "匯出"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(503, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "生效日"
        '
        'dtp_Time
        '
        Me.dtp_Time.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_Time.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Time.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Time.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_Time.Location = New System.Drawing.Point(566, 12)
        Me.dtp_Time.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Time.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Time.Name = "dtp_Time"
        Me.dtp_Time.Size = New System.Drawing.Size(110, 27)
        Me.dtp_Time.TabIndex = 9
        Me.dtp_Time.uclReadOnly = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 12
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_OrderCode, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_StartDate, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtp_EndDate, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucl_QyeryType, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnQuery, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnGExport, 9, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 52)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1008, 52)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "查詢醫令代碼"
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_OrderCode.Enabled = False
        Me.txt_OrderCode.Location = New System.Drawing.Point(115, 12)
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.Size = New System.Drawing.Size(150, 27)
        Me.txt_OrderCode.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "異動日期"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Enabled = False
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(351, 12)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(110, 27)
        Me.dtp_StartDate.TabIndex = 9
        Me.dtp_StartDate.uclReadOnly = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(468, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "~"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Enabled = False
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(491, 12)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(110, 27)
        Me.dtp_EndDate.TabIndex = 9
        Me.dtp_EndDate.uclReadOnly = False
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(608, 18)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "庫房別"
        '
        'ucl_QyeryType
        '
        Me.ucl_QyeryType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ucl_QyeryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_QyeryType.DropDownWidth = 20
        Me.ucl_QyeryType.Enabled = False
        Me.ucl_QyeryType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_QyeryType.Location = New System.Drawing.Point(674, 14)
        Me.ucl_QyeryType.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.ucl_QyeryType.Name = "ucl_QyeryType"
        Me.ucl_QyeryType.SelectedIndex = -1
        Me.ucl_QyeryType.SelectedItem = Nothing
        Me.ucl_QyeryType.SelectedText = ""
        Me.ucl_QyeryType.SelectedValue = ""
        Me.ucl_QyeryType.SelectionStart = 0
        Me.ucl_QyeryType.Size = New System.Drawing.Size(80, 24)
        Me.ucl_QyeryType.TabIndex = 11
        Me.ucl_QyeryType.uclDisplayIndex = "0,1"
        Me.ucl_QyeryType.uclIsAutoClear = True
        Me.ucl_QyeryType.uclIsFirstItemEmpty = True
        Me.ucl_QyeryType.uclIsTextMode = False
        Me.ucl_QyeryType.uclShowMsg = False
        Me.ucl_QyeryType.uclValueIndex = "0"
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnQuery.Enabled = False
        Me.btnQuery.Location = New System.Drawing.Point(764, 12)
        Me.btnQuery.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(78, 27)
        Me.btnQuery.TabIndex = 4
        Me.btnQuery.Text = "查詢"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnGExport
        '
        Me.btnGExport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGExport.Enabled = False
        Me.btnGExport.Location = New System.Drawing.Point(850, 12)
        Me.btnGExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGExport.Name = "btnGExport"
        Me.btnGExport.Size = New System.Drawing.Size(78, 27)
        Me.btnGExport.TabIndex = 12
        Me.btnGExport.Text = "G-下載"
        Me.btnGExport.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.dgvQuery, 7, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 104)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1008, 538)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'dgvQuery
        '
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQuery.Location = New System.Drawing.Point(3, 3)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowTemplate.Height = 24
        Me.dgvQuery.Size = New System.Drawing.Size(1002, 532)
        Me.dgvQuery.TabIndex = 0
        '
        'PUBExportOrderDataUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 642)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBExportOrderDataUI"
        Me.TabText = "PUBExportOrderDataUI"
        Me.Text = "匯出醫療支付公用主檔"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ucl_Type As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Ucl_Code As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_Time As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents ucl_QyeryType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvQuery As System.Windows.Forms.DataGridView
    Friend WithEvents btnGExport As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_OrderCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
