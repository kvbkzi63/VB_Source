<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobQABugListGridviewUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_NormalBug_Finished = New System.Windows.Forms.Label()
        Me.lbl_NormalBug_UnFinish = New System.Windows.Forms.Label()
        Me.lbl_ImportBug_Finished = New System.Windows.Forms.Label()
        Me.lbl_ImportBug_UnFinish = New System.Windows.Forms.Label()
        Me.lbl_UrgentBug_Finished = New System.Windows.Forms.Label()
        Me.lbl_UrgentBug_UnFinish = New System.Windows.Forms.Label()
        Me.lbl_TotalBug_NonTest = New System.Windows.Forms.Label()
        Me.lbl_TotalBug_Finished = New System.Windows.Forms.Label()
        Me.lbl_TotalBug_UnFinish = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_TotalBug_All = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_BugVerList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.765408!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.163022!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.063618!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.057654!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.554672!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.93439!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.33201!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.02783!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.13916!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.2326!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.45023!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_NormalBug_Finished, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_NormalBug_UnFinish, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_ImportBug_Finished, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_ImportBug_UnFinish, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_UrgentBug_Finished, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_UrgentBug_UnFinish, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_TotalBug_NonTest, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_TotalBug_Finished, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_TotalBug_UnFinish, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_TotalBug_All, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 319)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1006, 25)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lbl_NormalBug_Finished
        '
        Me.lbl_NormalBug_Finished.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_NormalBug_Finished.AutoSize = True
        Me.lbl_NormalBug_Finished.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_NormalBug_Finished.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lbl_NormalBug_Finished.Location = New System.Drawing.Point(891, 4)
        Me.lbl_NormalBug_Finished.Name = "lbl_NormalBug_Finished"
        Me.lbl_NormalBug_Finished.Size = New System.Drawing.Size(112, 16)
        Me.lbl_NormalBug_Finished.TabIndex = 10
        Me.lbl_NormalBug_Finished.Text = "44"
        Me.lbl_NormalBug_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_NormalBug_UnFinish
        '
        Me.lbl_NormalBug_UnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_NormalBug_UnFinish.AutoSize = True
        Me.lbl_NormalBug_UnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_NormalBug_UnFinish.ForeColor = System.Drawing.Color.Red
        Me.lbl_NormalBug_UnFinish.Location = New System.Drawing.Point(778, 4)
        Me.lbl_NormalBug_UnFinish.Name = "lbl_NormalBug_UnFinish"
        Me.lbl_NormalBug_UnFinish.Size = New System.Drawing.Size(107, 16)
        Me.lbl_NormalBug_UnFinish.TabIndex = 9
        Me.lbl_NormalBug_UnFinish.Text = "33"
        Me.lbl_NormalBug_UnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ImportBug_Finished
        '
        Me.lbl_ImportBug_Finished.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ImportBug_Finished.AutoSize = True
        Me.lbl_ImportBug_Finished.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ImportBug_Finished.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lbl_ImportBug_Finished.Location = New System.Drawing.Point(676, 4)
        Me.lbl_ImportBug_Finished.Name = "lbl_ImportBug_Finished"
        Me.lbl_ImportBug_Finished.Size = New System.Drawing.Size(96, 16)
        Me.lbl_ImportBug_Finished.TabIndex = 8
        Me.lbl_ImportBug_Finished.Text = "33"
        Me.lbl_ImportBug_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ImportBug_UnFinish
        '
        Me.lbl_ImportBug_UnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ImportBug_UnFinish.AutoSize = True
        Me.lbl_ImportBug_UnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ImportBug_UnFinish.ForeColor = System.Drawing.Color.Red
        Me.lbl_ImportBug_UnFinish.Location = New System.Drawing.Point(555, 4)
        Me.lbl_ImportBug_UnFinish.Name = "lbl_ImportBug_UnFinish"
        Me.lbl_ImportBug_UnFinish.Size = New System.Drawing.Size(115, 16)
        Me.lbl_ImportBug_UnFinish.TabIndex = 7
        Me.lbl_ImportBug_UnFinish.Text = "12"
        Me.lbl_ImportBug_UnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_UrgentBug_Finished
        '
        Me.lbl_UrgentBug_Finished.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_UrgentBug_Finished.AutoSize = True
        Me.lbl_UrgentBug_Finished.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_UrgentBug_Finished.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lbl_UrgentBug_Finished.Location = New System.Drawing.Point(441, 4)
        Me.lbl_UrgentBug_Finished.Name = "lbl_UrgentBug_Finished"
        Me.lbl_UrgentBug_Finished.Size = New System.Drawing.Size(108, 16)
        Me.lbl_UrgentBug_Finished.TabIndex = 6
        Me.lbl_UrgentBug_Finished.Text = "12"
        Me.lbl_UrgentBug_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_UrgentBug_UnFinish
        '
        Me.lbl_UrgentBug_UnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_UrgentBug_UnFinish.AutoSize = True
        Me.lbl_UrgentBug_UnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_UrgentBug_UnFinish.ForeColor = System.Drawing.Color.Red
        Me.lbl_UrgentBug_UnFinish.Location = New System.Drawing.Point(331, 4)
        Me.lbl_UrgentBug_UnFinish.Name = "lbl_UrgentBug_UnFinish"
        Me.lbl_UrgentBug_UnFinish.Size = New System.Drawing.Size(104, 16)
        Me.lbl_UrgentBug_UnFinish.TabIndex = 5
        Me.lbl_UrgentBug_UnFinish.Text = "11"
        Me.lbl_UrgentBug_UnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TotalBug_NonTest
        '
        Me.lbl_TotalBug_NonTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalBug_NonTest.AutoSize = True
        Me.lbl_TotalBug_NonTest.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_TotalBug_NonTest.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_TotalBug_NonTest.Location = New System.Drawing.Point(255, 4)
        Me.lbl_TotalBug_NonTest.Name = "lbl_TotalBug_NonTest"
        Me.lbl_TotalBug_NonTest.Size = New System.Drawing.Size(70, 16)
        Me.lbl_TotalBug_NonTest.TabIndex = 4
        Me.lbl_TotalBug_NonTest.Text = "14"
        Me.lbl_TotalBug_NonTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TotalBug_Finished
        '
        Me.lbl_TotalBug_Finished.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalBug_Finished.AutoSize = True
        Me.lbl_TotalBug_Finished.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_TotalBug_Finished.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.lbl_TotalBug_Finished.Location = New System.Drawing.Point(184, 4)
        Me.lbl_TotalBug_Finished.Name = "lbl_TotalBug_Finished"
        Me.lbl_TotalBug_Finished.Size = New System.Drawing.Size(65, 16)
        Me.lbl_TotalBug_Finished.TabIndex = 3
        Me.lbl_TotalBug_Finished.Text = "12"
        Me.lbl_TotalBug_Finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TotalBug_UnFinish
        '
        Me.lbl_TotalBug_UnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalBug_UnFinish.AutoSize = True
        Me.lbl_TotalBug_UnFinish.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_TotalBug_UnFinish.ForeColor = System.Drawing.Color.Red
        Me.lbl_TotalBug_UnFinish.Location = New System.Drawing.Point(123, 4)
        Me.lbl_TotalBug_UnFinish.Name = "lbl_TotalBug_UnFinish"
        Me.lbl_TotalBug_UnFinish.Size = New System.Drawing.Size(55, 16)
        Me.lbl_TotalBug_UnFinish.TabIndex = 2
        Me.lbl_TotalBug_UnFinish.Text = "22"
        Me.lbl_TotalBug_UnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "總計"
        '
        'lbl_TotalBug_All
        '
        Me.lbl_TotalBug_All.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalBug_All.AutoSize = True
        Me.lbl_TotalBug_All.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_TotalBug_All.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl_TotalBug_All.Location = New System.Drawing.Point(61, 4)
        Me.lbl_TotalBug_All.Name = "lbl_TotalBug_All"
        Me.lbl_TotalBug_All.Size = New System.Drawing.Size(56, 16)
        Me.lbl_TotalBug_All.TabIndex = 1
        Me.lbl_TotalBug_All.Text = "11"
        Me.lbl_TotalBug_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Bug"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(330, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Urgent Bug"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightCoral
        Me.Label3.Location = New System.Drawing.Point(554, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Important Bug"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DarkOrange
        Me.Label4.Location = New System.Drawing.Point(772, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(231, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Normal Bug"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgv_BugVerList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1006, 292)
        Me.Panel2.TabIndex = 3
        '
        'dgv_BugVerList
        '
        Me.dgv_BugVerList.AllowUserToAddRows = False
        Me.dgv_BugVerList.AllowUserToOrderColumns = False
        Me.dgv_BugVerList.AllowUserToResizeColumns = True
        Me.dgv_BugVerList.AllowUserToResizeRows = False
        Me.dgv_BugVerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_BugVerList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_BugVerList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_BugVerList.ColumnHeadersHeight = 4
        Me.dgv_BugVerList.ColumnHeadersVisible = True
        Me.dgv_BugVerList.CurrentCell = Nothing
        Me.dgv_BugVerList.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_BugVerList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_BugVerList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_BugVerList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_BugVerList.Location = New System.Drawing.Point(0, 0)
        Me.dgv_BugVerList.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_BugVerList.MultiSelect = False
        Me.dgv_BugVerList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_BugVerList.Name = "dgv_BugVerList"
        Me.dgv_BugVerList.RowHeadersWidth = 41
        Me.dgv_BugVerList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_BugVerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_BugVerList.Size = New System.Drawing.Size(1006, 292)
        Me.dgv_BugVerList.TabIndex = 0
        Me.dgv_BugVerList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_BugVerList.uclBatchColIndex = ""
        Me.dgv_BugVerList.uclClickToCheck = False
        Me.dgv_BugVerList.uclColumnAlignment = ""
        Me.dgv_BugVerList.uclColumnCheckBox = False
        Me.dgv_BugVerList.uclColumnControlType = ""
        Me.dgv_BugVerList.uclColumnWidth = ""
        Me.dgv_BugVerList.uclDoCellEnter = True
        Me.dgv_BugVerList.uclHasNewRow = False
        Me.dgv_BugVerList.uclHeaderText = ""
        Me.dgv_BugVerList.uclIsAlternatingRowsColors = True
        Me.dgv_BugVerList.uclIsComboBoxGridQuery = True
        Me.dgv_BugVerList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_BugVerList.uclIsDoOrderCheck = True
        Me.dgv_BugVerList.uclIsDoQueryComboBoxGrid = True
        Me.dgv_BugVerList.uclIsSortable = False
        Me.dgv_BugVerList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_BugVerList.uclNonVisibleColIndex = ""
        Me.dgv_BugVerList.uclReadOnly = False
        Me.dgv_BugVerList.uclShowCellBorder = False
        Me.dgv_BugVerList.uclSortColIndex = ""
        Me.dgv_BugVerList.uclTreeMode = False
        Me.dgv_BugVerList.uclVisibleColIndex = ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.50497!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.2664!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66998!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.35984!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1006, 27)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'JobQABugListGridviewUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "JobQABugListGridviewUC"
        Me.Size = New System.Drawing.Size(1006, 344)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents dgv_BugVerList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents lbl_NormalBug_Finished As Windows.Forms.Label
    Friend WithEvents lbl_NormalBug_UnFinish As Windows.Forms.Label
    Friend WithEvents lbl_ImportBug_Finished As Windows.Forms.Label
    Friend WithEvents lbl_ImportBug_UnFinish As Windows.Forms.Label
    Friend WithEvents lbl_UrgentBug_Finished As Windows.Forms.Label
    Friend WithEvents lbl_UrgentBug_UnFinish As Windows.Forms.Label
    Friend WithEvents lbl_TotalBug_NonTest As Windows.Forms.Label
    Friend WithEvents lbl_TotalBug_Finished As Windows.Forms.Label
    Friend WithEvents lbl_TotalBug_UnFinish As Windows.Forms.Label
    Friend WithEvents lbl_TotalBug_All As Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As Windows.Forms.TableLayoutPanel
End Class
