<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLComboBoxGridUISample
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

            pvtReceiveComboBoxGridMgr = Nothing
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgv_DiagnosisFavor = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(370, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "請在Order_Code 欄位的Cell中雙點擊以進入隨輸隨選"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "請輸入至少3碼 再按Enter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 385)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "按下ESC 可退出隨輸隨選模式"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 306)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "查到多筆資料時~請選擇一筆資料"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 348)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "只查到一筆符合的資料時,會直接帶回"
        '
        'dgv_DiagnosisFavor
        '
        Me.dgv_DiagnosisFavor.AllowDrop = True
        Me.dgv_DiagnosisFavor.AllowUserToAddRows = True
        Me.dgv_DiagnosisFavor.AllowUserToOrderColumns = True
        Me.dgv_DiagnosisFavor.AllowUserToResizeColumns = True
        Me.dgv_DiagnosisFavor.AllowUserToResizeRows = True
        Me.dgv_DiagnosisFavor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_DiagnosisFavor.ColumnHeadersVisible = True
        Me.dgv_DiagnosisFavor.CurrentCell = Nothing
        Me.dgv_DiagnosisFavor.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_DiagnosisFavor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_DiagnosisFavor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_DiagnosisFavor.Location = New System.Drawing.Point(15, 14)
        Me.dgv_DiagnosisFavor.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.dgv_DiagnosisFavor.MultiSelect = True
        Me.dgv_DiagnosisFavor.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.DeleteAll
        Me.dgv_DiagnosisFavor.Name = "dgv_DiagnosisFavor"
        Me.dgv_DiagnosisFavor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DiagnosisFavor.Size = New System.Drawing.Size(578, 194)
        Me.dgv_DiagnosisFavor.TabIndex = 9
        Me.dgv_DiagnosisFavor.uclBatchColIndex = ""
        Me.dgv_DiagnosisFavor.uclClickToCheck = False
        Me.dgv_DiagnosisFavor.uclColumnAlignment = ""
        Me.dgv_DiagnosisFavor.uclColumnCheckBox = True
        Me.dgv_DiagnosisFavor.uclColumnControlType = ""
        Me.dgv_DiagnosisFavor.uclColumnWidth = ""
        Me.dgv_DiagnosisFavor.uclDoCellEnter = True
        Me.dgv_DiagnosisFavor.uclHasNewRow = False
        Me.dgv_DiagnosisFavor.uclHeaderText = ""
        Me.dgv_DiagnosisFavor.uclIsComboBoxGridQuery = True
        Me.dgv_DiagnosisFavor.uclIsSortable = False
        Me.dgv_DiagnosisFavor.uclNonVisibleColIndex = ""
        Me.dgv_DiagnosisFavor.uclReadOnly = False
        Me.dgv_DiagnosisFavor.uclShowCellBorder = False
        Me.dgv_DiagnosisFavor.uclSortColIndex = ""
        Me.dgv_DiagnosisFavor.uclTreeMode = False
        Me.dgv_DiagnosisFavor.uclVisibleColIndex = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(530, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "解析度"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UCLComboBoxGridUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 414)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_DiagnosisFavor)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLComboBoxGridUISample"
        Me.Text = "UCLComboBoxGridUISample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_DiagnosisFavor As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
