<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRisFormMaintainSheetDetailUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRisFormMaintainSheetDetailUI))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanelTop = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_SheetCode = New System.Windows.Forms.Label()
        Me.cbo_SheetList = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanelButton = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.dgv_OrderList = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.btn_OCQuery = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_OrderCode = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanelTop.SuspendLayout()
        Me.FlowLayoutPanelButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanelTop
        '
        Me.TableLayoutPanelTop.ColumnCount = 3
        Me.TableLayoutPanelTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelTop.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanelTop.Controls.Add(Me.lbl_SheetCode, 0, 1)
        Me.TableLayoutPanelTop.Controls.Add(Me.cbo_SheetList, 1, 1)
        Me.TableLayoutPanelTop.Controls.Add(Me.btn_OCQuery, 2, 0)
        Me.TableLayoutPanelTop.Controls.Add(Me.txt_OrderCode, 1, 0)
        Me.TableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelTop.Name = "TableLayoutPanelTop"
        Me.TableLayoutPanelTop.RowCount = 2
        Me.TableLayoutPanelTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelTop.Size = New System.Drawing.Size(740, 58)
        Me.TableLayoutPanelTop.TabIndex = 0
        '
        'lbl_SheetCode
        '
        Me.lbl_SheetCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SheetCode.AutoSize = True
        Me.lbl_SheetCode.Location = New System.Drawing.Point(35, 38)
        Me.lbl_SheetCode.Name = "lbl_SheetCode"
        Me.lbl_SheetCode.Size = New System.Drawing.Size(40, 16)
        Me.lbl_SheetCode.TabIndex = 0
        Me.lbl_SheetCode.Text = "表單"
        '
        'cbo_SheetList
        '
        Me.cbo_SheetList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SheetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SheetList.DropDownWidth = 20
        Me.cbo_SheetList.DroppedDown = False
        Me.cbo_SheetList.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SheetList.Location = New System.Drawing.Point(78, 34)
        Me.cbo_SheetList.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_SheetList.Name = "cbo_SheetList"
        Me.cbo_SheetList.SelectedIndex = -1
        Me.cbo_SheetList.SelectedItem = Nothing
        Me.cbo_SheetList.SelectedText = ""
        Me.cbo_SheetList.SelectedValue = ""
        Me.cbo_SheetList.SelectionStart = 0
        Me.cbo_SheetList.Size = New System.Drawing.Size(280, 24)
        Me.cbo_SheetList.TabIndex = 1
        Me.cbo_SheetList.uclDisplayIndex = "0,1"
        Me.cbo_SheetList.uclIsAutoClear = True
        Me.cbo_SheetList.uclIsFirstItemEmpty = True
        Me.cbo_SheetList.uclIsTextMode = False
        Me.cbo_SheetList.uclShowMsg = False
        Me.cbo_SheetList.uclValueIndex = "0"
        '
        'FlowLayoutPanelButton
        '
        Me.FlowLayoutPanelButton.Controls.Add(Me.btn_Delete)
        Me.FlowLayoutPanelButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanelButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanelButton.Location = New System.Drawing.Point(0, 58)
        Me.FlowLayoutPanelButton.Name = "FlowLayoutPanelButton"
        Me.FlowLayoutPanelButton.Size = New System.Drawing.Size(740, 35)
        Me.FlowLayoutPanelButton.TabIndex = 1
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(647, 3)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(90, 28)
        Me.btn_Delete.TabIndex = 1
        Me.btn_Delete.Text = "刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'dgv_OrderList
        '
        Me.dgv_OrderList.AllowUserToAddRows = False
        Me.dgv_OrderList.AllowUserToOrderColumns = False
        Me.dgv_OrderList.AllowUserToResizeColumns = True
        Me.dgv_OrderList.AllowUserToResizeRows = False
        Me.dgv_OrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_OrderList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_OrderList.ColumnHeadersHeight = 4
        Me.dgv_OrderList.ColumnHeadersVisible = True
        Me.dgv_OrderList.CurrentCell = Nothing
        Me.dgv_OrderList.DataSource = Nothing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_OrderList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_OrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_OrderList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_OrderList.Location = New System.Drawing.Point(0, 93)
        Me.dgv_OrderList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgv_OrderList.MultiSelect = True
        Me.dgv_OrderList.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_OrderList.Name = "dgv_OrderList"
        Me.dgv_OrderList.RowHeadersWidth = 41
        Me.dgv_OrderList.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_OrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_OrderList.Size = New System.Drawing.Size(740, 326)
        Me.dgv_OrderList.TabIndex = 2
        Me.dgv_OrderList.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_OrderList.uclBatchColIndex = ""
        Me.dgv_OrderList.uclClickToCheck = True
        Me.dgv_OrderList.uclColumnAlignment = ""
        Me.dgv_OrderList.uclColumnCheckBox = True
        Me.dgv_OrderList.uclColumnControlType = ""
        Me.dgv_OrderList.uclColumnWidth = ""
        Me.dgv_OrderList.uclDoCellEnter = True
        Me.dgv_OrderList.uclHasNewRow = False
        Me.dgv_OrderList.uclHeaderText = ""
        Me.dgv_OrderList.uclIsAlternatingRowsColors = True
        Me.dgv_OrderList.uclIsComboBoxGridQuery = True
        Me.dgv_OrderList.uclIsComboxClickTriggerDropDown = False
        Me.dgv_OrderList.uclIsDoOrderCheck = True
        Me.dgv_OrderList.uclIsSortable = False
        Me.dgv_OrderList.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_OrderList.uclNonVisibleColIndex = ""
        Me.dgv_OrderList.uclReadOnly = False
        Me.dgv_OrderList.uclShowCellBorder = False
        Me.dgv_OrderList.uclSortColIndex = ""
        Me.dgv_OrderList.uclTreeMode = False
        Me.dgv_OrderList.uclVisibleColIndex = ""
        '
        'btn_OCQuery
        '
        Me.btn_OCQuery.Location = New System.Drawing.Point(361, 3)
        Me.btn_OCQuery.Name = "btn_OCQuery"
        Me.btn_OCQuery.Size = New System.Drawing.Size(90, 28)
        Me.btn_OCQuery.TabIndex = 2
        Me.btn_OCQuery.Text = "查詢"
        Me.btn_OCQuery.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "查詢醫令"
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Location = New System.Drawing.Point(81, 3)
        Me.txt_OrderCode.MaxLength = 20
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.Size = New System.Drawing.Size(274, 27)
        Me.txt_OrderCode.TabIndex = 4
        '
        'PUBRisFormMaintainSheetDetailUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 419)
        Me.Controls.Add(Me.dgv_OrderList)
        Me.Controls.Add(Me.FlowLayoutPanelButton)
        Me.Controls.Add(Me.TableLayoutPanelTop)
        Me.Name = "PUBRisFormMaintainSheetDetailUI"
        Me.TableLayoutPanelTop.ResumeLayout(False)
        Me.TableLayoutPanelTop.PerformLayout()
        Me.FlowLayoutPanelButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_SheetCode As System.Windows.Forms.Label
    Friend WithEvents cbo_SheetList As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanelButton As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents dgv_OrderList As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_OCQuery As System.Windows.Forms.Button
    Friend WithEvents txt_OrderCode As System.Windows.Forms.TextBox
End Class
