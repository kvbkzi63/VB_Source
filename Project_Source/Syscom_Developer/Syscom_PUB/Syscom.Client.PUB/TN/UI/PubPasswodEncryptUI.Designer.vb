<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPasswodEncryptUI
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Btn_Open = New System.Windows.Forms.Button()
        Me.dgv_Show = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Btn_Open)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(964, 36)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'Btn_Open
        '
        Me.Btn_Open.Location = New System.Drawing.Point(3, 3)
        Me.Btn_Open.Name = "Btn_Open"
        Me.Btn_Open.Size = New System.Drawing.Size(177, 28)
        Me.Btn_Open.TabIndex = 1
        Me.Btn_Open.Text = "F1-開啟帳密Excel"
        Me.Btn_Open.UseVisualStyleBackColor = True
        '
        'dgv_Show
        '
        Me.dgv_Show.AllowUserToAddRows = False
        Me.dgv_Show.AllowUserToOrderColumns = False
        Me.dgv_Show.AllowUserToResizeColumns = True
        Me.dgv_Show.AllowUserToResizeRows = False
        Me.dgv_Show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        Me.dgv_Show.ColumnHeadersHeight = 4
        Me.dgv_Show.ColumnHeadersVisible = True
        Me.dgv_Show.CurrentCell = Nothing
        Me.dgv_Show.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Show.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Show.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Show.Location = New System.Drawing.Point(0, 36)
        Me.dgv_Show.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Show.MultiSelect = False
        Me.dgv_Show.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Show.Name = "dgv_Show"
        Me.dgv_Show.RowHeadersWidth = 41
        Me.dgv_Show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Show.Size = New System.Drawing.Size(964, 605)
        Me.dgv_Show.TabIndex = 3
        Me.dgv_Show.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Show.uclBatchColIndex = ""
        Me.dgv_Show.uclClickToCheck = False
        Me.dgv_Show.uclColumnAlignment = ""
        Me.dgv_Show.uclColumnCheckBox = False
        Me.dgv_Show.uclColumnControlType = ""
        Me.dgv_Show.uclColumnWidth = ""
        Me.dgv_Show.uclDoCellEnter = True
        Me.dgv_Show.uclHasNewRow = False
        Me.dgv_Show.uclHeaderText = ""
        Me.dgv_Show.uclIsAlternatingRowsColors = True
        Me.dgv_Show.uclIsComboBoxGridQuery = True
        Me.dgv_Show.uclIsDoOrderCheck = True
        Me.dgv_Show.uclIsSortable = False
        Me.dgv_Show.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Show.uclNonVisibleColIndex = ""
        Me.dgv_Show.uclReadOnly = False
        Me.dgv_Show.uclShowCellBorder = False
        Me.dgv_Show.uclSortColIndex = ""
        Me.dgv_Show.uclTreeMode = False
        Me.dgv_Show.uclVisibleColIndex = ""
        '
        'PubPasswodEncryptUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.dgv_Show)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Name = "PubPasswodEncryptUI"
        Me.TabText = "PubPasswodEncryptUI"
        Me.Text = "PubPasswodEncryptUI"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Btn_Open As System.Windows.Forms.Button
    Friend WithEvents dgv_Show As Syscom.Client.UCL.UCLDataGridViewUC
End Class
