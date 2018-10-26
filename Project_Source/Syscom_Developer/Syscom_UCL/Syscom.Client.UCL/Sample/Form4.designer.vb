<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.UclComboBoxUI1 = New Syscom.Client.UCL.UCLComboBoxUI
        Me.UclGridRowUpDownUI1 = New Syscom.Client.UCL.UCLGridRowUpDownUI
        Me.UclTextCodeQueryUI4 = New Syscom.Client.UCL.UCLTextCodeQueryUI
        Me.UclTextBoxUI1 = New Syscom.Client.UCL.UCLTextBoxUI
        Me.UclBtnCodeQueryUI1 = New Syscom.Client.UCL.UCLBtnCodeQueryUI
        Me.uclDgv = New Syscom.Client.UCL.UCLDataGridViewUI
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Button12 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(670, 393)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(404, 143)
        Me.DataGridView1.TabIndex = 3
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(834, 328)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(939, 334)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(592, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "原DataSet"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "改過後Grid"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(589, 409)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(46, 386)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(522, 150)
        Me.DataGridView2.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 341)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "對應的Code DataSet"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(1091, 396)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 32
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(147, 9)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 36
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(281, 341)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(125, 23)
        Me.Button10.TabIndex = 37
        Me.Button10.Text = "Add New Row"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(921, 543)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1002, 543)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(451, 341)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 48
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(589, 355)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 50
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(698, 355)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 51
        Me.Button11.Text = "Button11"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'UclComboBoxUI1
        '
        Me.UclComboBoxUI1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclComboBoxUI1.DropDownWidth = 20
        Me.UclComboBoxUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclComboBoxUI1.Location = New System.Drawing.Point(191, 341)
        Me.UclComboBoxUI1.Name = "UclComboBoxUI1"
        Me.UclComboBoxUI1.SelectedIndex = -1
        Me.UclComboBoxUI1.SelectedItem = Nothing
        Me.UclComboBoxUI1.SelectedText = ""
        Me.UclComboBoxUI1.SelectedValue = ""
        Me.UclComboBoxUI1.SelectionStart = 0
        Me.UclComboBoxUI1.Size = New System.Drawing.Size(161, 24)
        Me.UclComboBoxUI1.TabIndex = 52
        Me.UclComboBoxUI1.uclDisplayIndex = "0,1"
        Me.UclComboBoxUI1.uclIsAutoClear = True
        Me.UclComboBoxUI1.uclShowMsg = False
        Me.UclComboBoxUI1.uclValueIndex = "0"
        '
        'UclGridRowUpDownUI1
        '
        Me.UclGridRowUpDownUI1.Location = New System.Drawing.Point(13, 152)
        Me.UclGridRowUpDownUI1.Name = "UclGridRowUpDownUI1"
        Me.UclGridRowUpDownUI1.Size = New System.Drawing.Size(46, 112)
        Me.UclGridRowUpDownUI1.TabIndex = 49
        '
        'UclTextCodeQueryUI4
        '
        Me.UclTextCodeQueryUI4.doFlag = True
        Me.UclTextCodeQueryUI4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclTextCodeQueryUI4.Location = New System.Drawing.Point(428, 5)
        Me.UclTextCodeQueryUI4.Margin = New System.Windows.Forms.Padding(0)
        Me.UclTextCodeQueryUI4.Name = "UclTextCodeQueryUI4"
        Me.UclTextCodeQueryUI4.Size = New System.Drawing.Size(162, 26)
        Me.UclTextCodeQueryUI4.TabIndex = 47
        Me.UclTextCodeQueryUI4.uclCboWidth = 126
        Me.UclTextCodeQueryUI4.uclCodeName = ""
        Me.UclTextCodeQueryUI4.uclCodeValue1 = ""
        Me.UclTextCodeQueryUI4.uclCodeValue2 = ""
        Me.UclTextCodeQueryUI4.uclControlFlag = True
        Me.UclTextCodeQueryUI4.uclDisplayIndex = "0,1"
        Me.UclTextCodeQueryUI4.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.UclTextCodeQueryUI4.uclIsReturnDS = False
        Me.UclTextCodeQueryUI4.uclIsShowMsgBox = True
        Me.UclTextCodeQueryUI4.uclIsTextAutoClear = True
        Me.UclTextCodeQueryUI4.uclQueryValue = Nothing
        Me.UclTextCodeQueryUI4.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.UclTextCodeQueryUI4.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.UclTextCodeQueryUI4.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.UclTextCodeQueryUI4.uclXPosition = 225
        Me.UclTextCodeQueryUI4.uclYPosition = 120
        '
        'UclTextBoxUI1
        '
        Me.UclTextBoxUI1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.UclTextBoxUI1.Location = New System.Drawing.Point(229, 5)
        Me.UclTextBoxUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclTextBoxUI1.MaxLength = 10
        Me.UclTextBoxUI1.Name = "UclTextBoxUI1"
        Me.UclTextBoxUI1.PasswordChar = "*"
        Me.UclTextBoxUI1.SelectionStart = 0
        Me.UclTextBoxUI1.Size = New System.Drawing.Size(129, 27)
        Me.UclTextBoxUI1.TabIndex = 46
        Me.UclTextBoxUI1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.UclTextBoxUI1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.UclTextBoxUI1.uclDollarSign = False
        Me.UclTextBoxUI1.uclDotCount = 0
        Me.UclTextBoxUI1.uclIntCount = 2
        Me.UclTextBoxUI1.uclMinus = False
        Me.UclTextBoxUI1.uclReadOnly = False
        Me.UclTextBoxUI1.uclTextType = Syscom.Client.UCL.UCLTextBoxUI.uclTextTypeData.Any_Type
        '
        'UclBtnCodeQueryUI1
        '
        Me.UclBtnCodeQueryUI1.Location = New System.Drawing.Point(377, 5)
        Me.UclBtnCodeQueryUI1.Name = "UclBtnCodeQueryUI1"
        Me.UclBtnCodeQueryUI1.Size = New System.Drawing.Size(29, 27)
        Me.UclBtnCodeQueryUI1.TabIndex = 42
        Me.UclBtnCodeQueryUI1.uclBtnText = "..."
        Me.UclBtnCodeQueryUI1.uclEnableQueryList = True
        Me.UclBtnCodeQueryUI1.uclIsReturnDS = False
        Me.UclBtnCodeQueryUI1.uclQueryValue = Nothing
        Me.UclBtnCodeQueryUI1.uclRefHosp = Syscom.Client.UCL.UCLBtnCodeQueryUI.uclRefHospData.All
        Me.UclBtnCodeQueryUI1.uclSelectType = Syscom.Client.UCL.UCLBtnCodeQueryUI.SelectType.SingleSelect
        Me.UclBtnCodeQueryUI1.uclTableName = Syscom.Client.UCL.UCLBtnCodeQueryUI.uclQueryTable.PUB_Employee
        Me.UclBtnCodeQueryUI1.uclXPosition = 225
        Me.UclBtnCodeQueryUI1.uclYPosition = 120
        '
        'uclDgv
        '
        Me.uclDgv.AllowDrop = True
        Me.uclDgv.AllowUserToAddRows = True
        Me.uclDgv.AllowUserToOrderColumns = True
        Me.uclDgv.AllowUserToResizeColumns = True
        Me.uclDgv.AllowUserToResizeRows = True
        Me.uclDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.uclDgv.ColumnHeadersVisible = True
        Me.uclDgv.CurrentCell = Nothing
        Me.uclDgv.DataSource = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.uclDgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.uclDgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.uclDgv.Location = New System.Drawing.Point(89, 39)
        Me.uclDgv.MultiSelect = True
        Me.uclDgv.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUI.SelectType.Doubt
        Me.uclDgv.Name = "uclDgv"
        Me.uclDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.uclDgv.Size = New System.Drawing.Size(1098, 289)
        Me.uclDgv.TabIndex = 10
        Me.uclDgv.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.uclDgv.uclBatchColIndex = ""
        Me.uclDgv.uclClickToCheck = False
        Me.uclDgv.uclColumnAlignment = ""
        Me.uclDgv.uclColumnCheckBox = True
        Me.uclDgv.uclColumnControlType = ""
        Me.uclDgv.uclColumnWidth = ""
        Me.uclDgv.uclDoCellEnter = True
        Me.uclDgv.uclHasNewRow = False
        Me.uclDgv.uclHeaderText = ""
        Me.uclDgv.uclIsAlternatingRowsColors = True
        Me.uclDgv.uclIsComboBoxGridQuery = True
        Me.uclDgv.uclIsDoOrderCheck = True
        Me.uclDgv.uclIsSortable = False
        Me.uclDgv.uclNonVisibleColIndex = ""
        Me.uclDgv.uclReadOnly = False
        Me.uclDgv.uclShowCellBorder = False
        Me.uclDgv.uclSortColIndex = ""
        Me.uclDgv.uclTreeMode = False
        Me.uclDgv.uclVisibleColIndex = ""
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Column1"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 74
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.HeaderText = "Column2"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = "Column1"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(8, 89)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 53
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 575)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.UclComboBoxUI1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.UclGridRowUpDownUI1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.UclTextCodeQueryUI4)
        Me.Controls.Add(Me.UclTextBoxUI1)
        Me.Controls.Add(Me.UclBtnCodeQueryUI1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.uclDgv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents uclDgv As Syscom.Client.UCL.UCLDataGridViewUI
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn

    Friend WithEvents UclComboBoxGridUI1 As Syscom.Client.UCL.UCLComboBoxGridUI
    Friend WithEvents UclIdentityUI1 As Syscom.Client.UCL.UCLIdentityUI

    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UclBtnCodeQueryUI1 As Syscom.Client.UCL.UCLBtnCodeQueryUI
    Friend WithEvents UclTextBoxUI1 As Syscom.Client.UCL.UCLTextBoxUI
    Friend WithEvents UclTextCodeQueryUI4 As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents UclGridRowUpDownUI1 As Syscom.Client.UCL.UCLGridRowUpDownUI
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents UclComboBoxUI1 As Syscom.Client.UCL.UCLComboBoxUI
    Friend WithEvents UclChartNoUI1 As Syscom.Client.UCL.UCLChartNoUI
    Friend WithEvents Button12 As System.Windows.Forms.Button


End Class
