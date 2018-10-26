<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArmLogonFailureUI
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDay = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_EndDay = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dgvShowData = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Query = New System.Windows.Forms.Button()
        Me.btn_Excel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvShowData, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 642)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_StartDay)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_EndDay)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(762, 40)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "日期："
        '
        'dtp_StartDay
        '
        Me.dtp_StartDay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDay.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDay.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_StartDay.Location = New System.Drawing.Point(65, 3)
        Me.dtp_StartDay.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDay.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDay.Name = "dtp_StartDay"
        Me.dtp_StartDay.Size = New System.Drawing.Size(132, 27)
        Me.dtp_StartDay.TabIndex = 0
        Me.dtp_StartDay.uclReadOnly = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(203, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "~"
        '
        'dtp_EndDay
        '
        Me.dtp_EndDay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDay.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDay.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_EndDay.Location = New System.Drawing.Point(225, 3)
        Me.dtp_EndDay.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDay.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDay.Name = "dtp_EndDay"
        Me.dtp_EndDay.Size = New System.Drawing.Size(132, 27)
        Me.dtp_EndDay.TabIndex = 1
        Me.dtp_EndDay.uclReadOnly = False
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.AllowUserToOrderColumns = False
        Me.dgvShowData.AllowUserToResizeColumns = True
        Me.dgvShowData.AllowUserToResizeRows = False
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShowData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.ColumnHeadersVisible = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvShowData, 3)
        Me.dgvShowData.CurrentCell = Nothing
        Me.dgvShowData.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShowData.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvShowData.Location = New System.Drawing.Point(3, 49)
        Me.dgvShowData.MultiSelect = False
        Me.dgvShowData.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.RowHeadersWidth = 41
        Me.dgvShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(956, 590)
        Me.dgvShowData.TabIndex = 2
        Me.dgvShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvShowData.uclBatchColIndex = ""
        Me.dgvShowData.uclClickToCheck = False
        Me.dgvShowData.uclColumnAlignment = ""
        Me.dgvShowData.uclColumnCheckBox = False
        Me.dgvShowData.uclColumnControlType = ""
        Me.dgvShowData.uclColumnWidth = ""
        Me.dgvShowData.uclDoCellEnter = True
        Me.dgvShowData.uclHasNewRow = False
        Me.dgvShowData.uclHeaderText = ""
        Me.dgvShowData.uclIsAlternatingRowsColors = True
        Me.dgvShowData.uclIsComboBoxGridQuery = True
        Me.dgvShowData.uclIsComboxClickTriggerDropDown = False
        Me.dgvShowData.uclIsDoOrderCheck = True
        Me.dgvShowData.uclIsSortable = False
        Me.dgvShowData.uclMultiSelectShowCheckBoxHeader = True
        Me.dgvShowData.uclNonVisibleColIndex = ""
        Me.dgvShowData.uclReadOnly = False
        Me.dgvShowData.uclShowCellBorder = False
        Me.dgvShowData.uclSortColIndex = ""
        Me.dgvShowData.uclTreeMode = False
        Me.dgvShowData.uclVisibleColIndex = ""
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Query)
        Me.FlowLayoutPanel2.Controls.Add(Me.btn_Excel)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(771, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(191, 40)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(3, 3)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(84, 33)
        Me.btn_Query.TabIndex = 0
        Me.btn_Query.Text = "查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'btn_Excel
        '
        Me.btn_Excel.Location = New System.Drawing.Point(93, 3)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(95, 33)
        Me.btn_Excel.TabIndex = 1
        Me.btn_Excel.Text = "匯出Excel"
        Me.btn_Excel.UseVisualStyleBackColor = True
        '
        'ArmLogonFailureUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ArmLogonFailureUI"
        Me.TabText = "ArmLogonFailureUI"
        Me.Text = "ArmLogonFailureUI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dtp_StartDay As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDay As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents btn_Excel As System.Windows.Forms.Button
    Friend WithEvents dgvShowData As Syscom.Client.UCL.UCLDataGridViewUC
End Class
