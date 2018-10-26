<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLGridViewPartnerUISample
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.UclGridRowUpDownUI2 = New Syscom.Client.ucl.UCLGridRowUpDownUC
        Me.UclDataGridViewUI2 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.UclGridUpComboBoxUI1 = New Syscom.Client.ucl.UCLGridUpComboBoxUC
        Me.UclGridRowUpDownUI1 = New Syscom.Client.ucl.UCLGridRowUpDownUC
        Me.UclDataGridViewUI1 = New Syscom.Client.ucl.UCLDataGridViewUC
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 144)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "UCLGridRowUpDownUI"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(451, 298)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "UCLGridUpComboBoxUI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 182)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "資料列上下移動按鈕"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(271, 274)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(333, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "資料行整批修改(多選用,請先設定為NonVisible)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(457, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "屬性與方法設定請參考UCL共用元件使用說明.doc 第10,11項元件"
        '
        'UclGridRowUpDownUI2
        '
        Me.UclGridRowUpDownUI2.Location = New System.Drawing.Point(190, 338)
        Me.UclGridRowUpDownUI2.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.UclGridRowUpDownUI2.Name = "UclGridRowUpDownUI2"
        Me.UclGridRowUpDownUI2.Size = New System.Drawing.Size(35, 127)
        Me.UclGridRowUpDownUI2.TabIndex = 37
        '
        'UclDataGridViewUI2
        '
        Me.UclDataGridViewUI2.AllowDrop = True
        Me.UclDataGridViewUI2.AllowUserToAddRows = False
        Me.UclDataGridViewUI2.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI2.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI2.AllowUserToResizeRows = True
        Me.UclDataGridViewUI2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI2.CurrentCell = Nothing
        Me.UclDataGridViewUI2.DataSource = Nothing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI2.DefaultCellStyle = DataGridViewCellStyle3
        Me.UclDataGridViewUI2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI2.Location = New System.Drawing.Point(234, 326)
        Me.UclDataGridViewUI2.Margin = New System.Windows.Forms.Padding(9, 7, 9, 7)
        Me.UclDataGridViewUI2.MultiSelect = True
        Me.UclDataGridViewUI2.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI2.Name = "UclDataGridViewUI2"
        Me.UclDataGridViewUI2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI2.Size = New System.Drawing.Size(460, 148)
        Me.UclDataGridViewUI2.TabIndex = 36
        Me.UclDataGridViewUI2.uclColumnAlignment = ""
        Me.UclDataGridViewUI2.uclColumnCheckBox = True
        Me.UclDataGridViewUI2.uclColumnControlType = ""
        Me.UclDataGridViewUI2.uclColumnWidth = ""
        Me.UclDataGridViewUI2.uclHeaderText = ""
        Me.UclDataGridViewUI2.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI2.uclReadOnly = False
        Me.UclDataGridViewUI2.uclSortColIndex = ""
        '
        'UclGridUpComboBoxUI1
        '
        Me.UclGridUpComboBoxUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclGridUpComboBoxUI1.Location = New System.Drawing.Point(274, 295)
        Me.UclGridUpComboBoxUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclGridUpComboBoxUI1.Name = "UclGridUpComboBoxUI1"
        Me.UclGridUpComboBoxUI1.Size = New System.Drawing.Size(176, 24)
        Me.UclGridUpComboBoxUI1.TabIndex = 2
        Me.UclGridUpComboBoxUI1.Visible = False
        '
        'UclGridRowUpDownUI1
        '
        Me.UclGridRowUpDownUI1.Location = New System.Drawing.Point(191, 107)
        Me.UclGridRowUpDownUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclGridRowUpDownUI1.Name = "UclGridRowUpDownUI1"
        Me.UclGridRowUpDownUI1.Size = New System.Drawing.Size(34, 135)
        Me.UclGridRowUpDownUI1.TabIndex = 1
        '
        'UclDataGridViewUI1
        '
        Me.UclDataGridViewUI1.AllowDrop = True
        Me.UclDataGridViewUI1.AllowUserToAddRows = False
        Me.UclDataGridViewUI1.AllowUserToOrderColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeColumns = True
        Me.UclDataGridViewUI1.AllowUserToResizeRows = True
        Me.UclDataGridViewUI1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UclDataGridViewUI1.CurrentCell = Nothing
        Me.UclDataGridViewUI1.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UclDataGridViewUI1.DefaultCellStyle = DataGridViewCellStyle1
        Me.UclDataGridViewUI1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.UclDataGridViewUI1.Location = New System.Drawing.Point(237, 97)
        Me.UclDataGridViewUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclDataGridViewUI1.MultiSelect = False
        Me.UclDataGridViewUI1.MultiSelectType = Syscom.Client.ucl.UCLDataGridViewUC.SelectType.SelectAll
        Me.UclDataGridViewUI1.Name = "UclDataGridViewUI1"
        Me.UclDataGridViewUI1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UclDataGridViewUI1.Size = New System.Drawing.Size(460, 150)
        Me.UclDataGridViewUI1.TabIndex = 0
        Me.UclDataGridViewUI1.uclColumnAlignment = ""
        Me.UclDataGridViewUI1.uclColumnCheckBox = False
        Me.UclDataGridViewUI1.uclColumnControlType = ""
        Me.UclDataGridViewUI1.uclColumnWidth = ""
        Me.UclDataGridViewUI1.uclHeaderText = ""
        Me.UclDataGridViewUI1.uclNonVisibleColIndex = ""
        Me.UclDataGridViewUI1.uclReadOnly = False
        Me.UclDataGridViewUI1.uclSortColIndex = ""
        '
        'UCLGridViewPartnerUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 490)
        Me.Controls.Add(Me.UclGridRowUpDownUI2)
        Me.Controls.Add(Me.UclDataGridViewUI2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UclGridUpComboBoxUI1)
        Me.Controls.Add(Me.UclGridRowUpDownUI1)
        Me.Controls.Add(Me.UclDataGridViewUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLGridViewPartnerUISample"
        Me.Text = "UCLGridViewPartnerUISample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclDataGridViewUI1 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents UclGridRowUpDownUI1 As Syscom.Client.ucl.UCLGridRowUpDownUC
    Friend WithEvents UclGridUpComboBoxUI1 As Syscom.Client.ucl.UCLGridUpComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UclDataGridViewUI2 As Syscom.Client.ucl.UCLDataGridViewUC
    Friend WithEvents UclGridRowUpDownUI2 As Syscom.Client.ucl.UCLGridRowUpDownUC
End Class
