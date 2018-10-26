<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSystemVersionUI
    'Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSystemVersionUI))
        Me.pal_Query_Condition = New System.Windows.Forms.Panel
        Me.cbo_System = New Syscom.Client.UCL.UCLComboBoxUC
        Me.cbo_Version_No = New Syscom.Client.UCL.UCLComboBoxUC
        Me.Label6 = New System.Windows.Forms.Label
        Me.系統別 = New System.Windows.Forms.Label
        Me.btn_Query = New System.Windows.Forms.Button
        Me.dgvShowData = New System.Windows.Forms.DataGridView
        Me.btn_NextVersion = New System.Windows.Forms.Button
        Me.btn_PreVersion = New System.Windows.Forms.Button
        Me.pal_Query_Condition.SuspendLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pal_Query_Condition
        '
        Me.pal_Query_Condition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Query_Condition.Controls.Add(Me.cbo_System)
        Me.pal_Query_Condition.Controls.Add(Me.cbo_Version_No)
        Me.pal_Query_Condition.Controls.Add(Me.Label6)
        Me.pal_Query_Condition.Controls.Add(Me.系統別)
        Me.pal_Query_Condition.Location = New System.Drawing.Point(12, 12)
        Me.pal_Query_Condition.Name = "pal_Query_Condition"
        Me.pal_Query_Condition.Size = New System.Drawing.Size(984, 57)
        Me.pal_Query_Condition.TabIndex = 1
        '
        'cbo_System
        '
        Me.cbo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_System.DropDownWidth = 20
        Me.cbo_System.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_System.Location = New System.Drawing.Point(617, 14)
        Me.cbo_System.Name = "cbo_System"
        Me.cbo_System.SelectedIndex = -1
        Me.cbo_System.SelectedItem = Nothing
        Me.cbo_System.SelectedText = ""
        Me.cbo_System.SelectedValue = ""
        Me.cbo_System.SelectionStart = 0
        Me.cbo_System.Size = New System.Drawing.Size(307, 24)
        Me.cbo_System.TabIndex = 56
        Me.cbo_System.uclDisplayIndex = "0,1"
        Me.cbo_System.uclIsAutoClear = True
        Me.cbo_System.uclShowMsg = False
        Me.cbo_System.uclValueIndex = "0"
        '
        'cbo_Version_No
        '
        Me.cbo_Version_No.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Version_No.DropDownWidth = 20
        Me.cbo_Version_No.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Version_No.Location = New System.Drawing.Point(138, 11)
        Me.cbo_Version_No.Name = "cbo_Version_No"
        Me.cbo_Version_No.SelectedIndex = -1
        Me.cbo_Version_No.SelectedItem = Nothing
        Me.cbo_Version_No.SelectedText = ""
        Me.cbo_Version_No.SelectedValue = ""
        Me.cbo_Version_No.SelectionStart = 0
        Me.cbo_Version_No.Size = New System.Drawing.Size(246, 24)
        Me.cbo_Version_No.TabIndex = 55
        Me.cbo_Version_No.uclDisplayIndex = "0,1"
        Me.cbo_Version_No.uclIsAutoClear = True
        Me.cbo_Version_No.uclShowMsg = False
        Me.cbo_Version_No.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(76, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "版本號"
        '
        '系統別
        '
        Me.系統別.AutoSize = True
        Me.系統別.Location = New System.Drawing.Point(546, 14)
        Me.系統別.Name = "系統別"
        Me.系統別.Size = New System.Drawing.Size(56, 16)
        Me.系統別.TabIndex = 52
        Me.系統別.Text = "系統別"
        '
        'btn_Query
        '
        Me.btn_Query.Location = New System.Drawing.Point(921, 75)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(75, 29)
        Me.btn_Query.TabIndex = 2
        Me.btn_Query.Text = "F1-查詢"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'dgvShowData
        '
        Me.dgvShowData.AllowUserToAddRows = False
        Me.dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShowData.Location = New System.Drawing.Point(12, 110)
        Me.dgvShowData.Name = "dgvShowData"
        Me.dgvShowData.RowHeadersVisible = False
        Me.dgvShowData.RowTemplate.Height = 24
        Me.dgvShowData.Size = New System.Drawing.Size(984, 520)
        Me.dgvShowData.TabIndex = 3
        '
        'btn_NextVersion
        '
        Me.btn_NextVersion.Location = New System.Drawing.Point(829, 75)
        Me.btn_NextVersion.Name = "btn_NextVersion"
        Me.btn_NextVersion.Size = New System.Drawing.Size(86, 29)
        Me.btn_NextVersion.TabIndex = 4
        Me.btn_NextVersion.Text = "下ㄧ版本"
        Me.btn_NextVersion.UseVisualStyleBackColor = True
        '
        'btn_PreVersion
        '
        Me.btn_PreVersion.Location = New System.Drawing.Point(732, 75)
        Me.btn_PreVersion.Name = "btn_PreVersion"
        Me.btn_PreVersion.Size = New System.Drawing.Size(91, 29)
        Me.btn_PreVersion.TabIndex = 5
        Me.btn_PreVersion.Text = "前一版本"
        Me.btn_PreVersion.UseVisualStyleBackColor = True
        '
        'PUBSystemVersionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 642)
        Me.Controls.Add(Me.btn_PreVersion)
        Me.Controls.Add(Me.btn_NextVersion)
        Me.Controls.Add(Me.dgvShowData)
        Me.Controls.Add(Me.btn_Query)
        Me.Controls.Add(Me.pal_Query_Condition)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBSystemVersionUI"
        Me.TabText = "系統版本更新記錄查詢"
        Me.Text = "系統版本更新記錄查詢"
        Me.pal_Query_Condition.ResumeLayout(False)
        Me.pal_Query_Condition.PerformLayout()
        CType(Me.dgvShowData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pal_Query_Condition As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 系統別 As System.Windows.Forms.Label
    Friend WithEvents btn_Query As System.Windows.Forms.Button
    Friend WithEvents dgvShowData As System.Windows.Forms.DataGridView
    Friend WithEvents btn_NextVersion As System.Windows.Forms.Button
    Friend WithEvents btn_PreVersion As System.Windows.Forms.Button
    Friend WithEvents cbo_Version_No As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_System As Syscom.Client.UCL.UCLComboBoxUC
End Class
