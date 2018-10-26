<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBMedicalTypeSortSetupUI
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_query = New System.Windows.Forms.Button()
        Me.tcq_employeecode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.dgv_show = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 228.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_query, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tcq_employeecode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_show, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.644306!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.3557!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(944, 641)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "人事代號"
        '
        'btn_query
        '
        Me.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_query.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_query.Location = New System.Drawing.Point(303, 6)
        Me.btn_query.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(100, 36)
        Me.btn_query.TabIndex = 1
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'tcq_employeecode
        '
        Me.tcq_employeecode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_employeecode.doFlag = True
        Me.tcq_employeecode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_employeecode.Location = New System.Drawing.Point(86, 7)
        Me.tcq_employeecode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_employeecode.Name = "tcq_employeecode"
        Me.tcq_employeecode.Size = New System.Drawing.Size(213, 35)
        Me.tcq_employeecode.TabIndex = 6
        Me.tcq_employeecode.uclBaseDate = ""
        Me.tcq_employeecode.uclCboWidth = 167
        Me.tcq_employeecode.uclCodeName = ""
        Me.tcq_employeecode.uclCodeName1 = ""
        Me.tcq_employeecode.uclCodeName2 = ""
        Me.tcq_employeecode.uclCodeValue = ""
        Me.tcq_employeecode.uclCodeValue1 = ""
        Me.tcq_employeecode.uclCodeValue2 = ""
        Me.tcq_employeecode.uclConditionDate = ""
        Me.tcq_employeecode.uclControlFlag = True
        Me.tcq_employeecode.uclDeptCode = ""
        Me.tcq_employeecode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_employeecode.uclDisplayIndex = "0,1"
        Me.tcq_employeecode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_employeecode.uclIsAutoAddZero = False
        Me.tcq_employeecode.uclIsBtnVisible = True
        Me.tcq_employeecode.uclIsCheckDoctorOnDuty = False
        Me.tcq_employeecode.uclIsCheckDrLicense = True
        Me.tcq_employeecode.uclIsCheckTime = True
        Me.tcq_employeecode.uclIsEnglishDept = False
        Me.tcq_employeecode.uclIsReturnDS = False
        Me.tcq_employeecode.uclIsShowMsgBox = True
        Me.tcq_employeecode.uclIsTextAutoClear = True
        Me.tcq_employeecode.uclLabel = ""
        Me.tcq_employeecode.uclMsgValue = Nothing
        Me.tcq_employeecode.uclNoDataOpenWindow = False
        Me.tcq_employeecode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_employeecode.uclQueryField = Nothing
        Me.tcq_employeecode.uclQueryValue = Nothing
        Me.tcq_employeecode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_employeecode.uclRegionKind = ""
        Me.tcq_employeecode.uclRoles = ""
        Me.tcq_employeecode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_employeecode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcq_employeecode.uclTotalWidth = 8
        Me.tcq_employeecode.uclXPosition = 225
        Me.tcq_employeecode.uclYPosition = 120
        '
        'dgv_show
        '
        Me.dgv_show.AllowUserToAddRows = False
        Me.dgv_show.AllowUserToOrderColumns = False
        Me.dgv_show.AllowUserToResizeColumns = True
        Me.dgv_show.AllowUserToResizeRows = False
        Me.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_show.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_show.ColumnHeadersHeight = 4
        Me.dgv_show.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv_show, 4)
        Me.dgv_show.CurrentCell = Nothing
        Me.dgv_show.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_show.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_show.Location = New System.Drawing.Point(4, 53)
        Me.dgv_show.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_show.MultiSelect = False
        Me.dgv_show.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_show.Name = "dgv_show"
        Me.dgv_show.RowHeadersWidth = 41
        Me.dgv_show.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_show.Size = New System.Drawing.Size(652, 575)
        Me.dgv_show.TabIndex = 7
        Me.dgv_show.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_show.uclBatchColIndex = ""
        Me.dgv_show.uclClickToCheck = False
        Me.dgv_show.uclColumnAlignment = ""
        Me.dgv_show.uclColumnCheckBox = False
        Me.dgv_show.uclColumnControlType = ""
        Me.dgv_show.uclColumnWidth = ""
        Me.dgv_show.uclDoCellEnter = True
        Me.dgv_show.uclHasNewRow = False
        Me.dgv_show.uclHeaderText = ""
        Me.dgv_show.uclIsAlternatingRowsColors = True
        Me.dgv_show.uclIsComboBoxGridQuery = True
        Me.dgv_show.uclIsComboxClickTriggerDropDown = False
        Me.dgv_show.uclIsDoOrderCheck = True
        Me.dgv_show.uclIsSortable = False
        Me.dgv_show.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_show.uclNonVisibleColIndex = ""
        Me.dgv_show.uclReadOnly = False
        Me.dgv_show.uclShowCellBorder = False
        Me.dgv_show.uclSortColIndex = ""
        Me.dgv_show.uclTreeMode = False
        Me.dgv_show.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_save)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_delete)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(438, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(222, 43)
        Me.FlowLayoutPanel2.TabIndex = 9
        '
        'btn_save
        '
        Me.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_save.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_save.Location = New System.Drawing.Point(4, 4)
        Me.btn_save.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(102, 35)
        Me.btn_save.TabIndex = 2
        Me.btn_save.Text = "F12-儲存"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_delete.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_delete.Location = New System.Drawing.Point(114, 4)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(104, 35)
        Me.btn_delete.TabIndex = 3
        Me.btn_delete.Text = "全部刪除"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_up)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_down)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(666, 52)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(119, 100)
        Me.FlowLayoutPanel1.TabIndex = 10
        '
        'btn_up
        '
        Me.btn_up.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_up.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_up.Location = New System.Drawing.Point(4, 4)
        Me.btn_up.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(102, 35)
        Me.btn_up.TabIndex = 3
        Me.btn_up.Text = "F3-Up"
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_down
        '
        Me.btn_down.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_down.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn_down.Location = New System.Drawing.Point(4, 47)
        Me.btn_down.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(102, 35)
        Me.btn_down.TabIndex = 4
        Me.btn_down.Text = "F4-Down"
        Me.btn_down.UseVisualStyleBackColor = True
        '
        'PUBMedicalTypeSortSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBMedicalTypeSortSetupUI"
        Me.TabText = "PUBMedicalTypeSortSetupUI"
        Me.Text = "PUBMedicalTypeSortSetupUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents tcq_employeecode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents dgv_show As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents btn_down As System.Windows.Forms.Button
End Class
