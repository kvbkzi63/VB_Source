<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLDrugPackageDtlUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelBottom = New System.Windows.Forms.Panel
        Me.btnOK = New System.Windows.Forms.Button
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.dgvShowData = New UCLDataGridViewUC
        Me.PanelBottom.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.btnOK)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 386)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(814, 47)
        Me.PanelBottom.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(345, 7)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 28)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "F10-完成"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.dgvShowData)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(814, 386)
        Me.PanelTop.TabIndex = 1
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.AllowUserToOrderColumns = False
        Me.dgvShowData.AllowUserToResizeColumns = True
        Me.dgvShowData.AllowUserToResizeRows = False
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.ColumnHeadersVisible = True
        Me.dgvShowData.CurrentCell = Nothing
        Me.dgvShowData.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShowData.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgvShowData.Location = New System.Drawing.Point(0, 0)
        Me.dgvShowData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvShowData.MultiSelect = True
        Me.dgvShowData.MultiSelectType = UCLDataGridViewUC.SelectType.SelectAll
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.RowHeadersWidth = 41
        Me.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShowData.Size = New System.Drawing.Size(814, 386)
        Me.dgvShowData.TabIndex = 0
        Me.dgvShowData.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgvShowData.uclBatchColIndex = ""
        Me.dgvShowData.uclClickToCheck = False
        Me.dgvShowData.uclColumnAlignment = ""
        Me.dgvShowData.uclColumnCheckBox = True
        Me.dgvShowData.uclColumnControlType = ""
        Me.dgvShowData.uclColumnWidth = ""
        Me.dgvShowData.uclDoCellEnter = True
        Me.dgvShowData.uclHasNewRow = False
        Me.dgvShowData.uclHeaderText = ""
        Me.dgvShowData.uclIsAlternatingRowsColors = True
        Me.dgvShowData.uclIsComboBoxGridQuery = True
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
        'UCLDrugPackageDtlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 433)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLDrugPackageDtlUI"
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents dgvShowData As UCLDataGridViewUC
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
