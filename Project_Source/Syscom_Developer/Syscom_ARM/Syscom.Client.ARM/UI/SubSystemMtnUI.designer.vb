<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubSystemMtnUI

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
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RdoBtnN = New System.Windows.Forms.RadioButton
        Me.RdoBtnY = New System.Windows.Forms.RadioButton
        Me.lbl_sub_system_name = New System.Windows.Forms.Label
        Me.lbl_DCYN = New System.Windows.Forms.Label
        Me.sub_system_no = New System.Windows.Forms.TextBox
        Me.lbl_sub_system_no = New System.Windows.Forms.Label
        Me.sub_system_name = New System.Windows.Forms.TextBox
        Me.lbl_sub_app_system_no = New System.Windows.Forms.Label
        Me.sub_app_system_no = New System.Windows.Forms.ComboBox
        Me.lbl_sub_display_order = New System.Windows.Forms.Label
        Me.sub_display_order = New System.Windows.Forms.TextBox
        Me.IMaintainPanel.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IMaintainPanel
        '
        Me.IMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IMaintainPanel.Location = New System.Drawing.Point(0, 93)
        Me.IMaintainPanel.Size = New System.Drawing.Size(1008, 526)
        '
        'dgvPanel
        '
        Me.dgvPanel.Location = New System.Drawing.Point(1, 35)
        Me.dgvPanel.Size = New System.Drawing.Size(1006, 490)
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 4
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600.0!))
        Me.tlp_nonButton.Controls.Add(Me.Panel2, 1, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_sub_system_name, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_DCYN, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.sub_system_no, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_sub_system_no, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.sub_system_name, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_sub_app_system_no, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.sub_app_system_no, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_sub_display_order, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.sub_display_order, 3, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 3
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1008, 93)
        Me.tlp_nonButton.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdoBtnN)
        Me.Panel2.Controls.Add(Me.RdoBtnY)
        Me.Panel2.Location = New System.Drawing.Point(120, 66)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(154, 22)
        Me.Panel2.TabIndex = 5
        '
        'RdoBtnN
        '
        Me.RdoBtnN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RdoBtnN.AutoSize = True
        Me.RdoBtnN.Location = New System.Drawing.Point(58, 2)
        Me.RdoBtnN.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnN.Name = "RdoBtnN"
        Me.RdoBtnN.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnN.TabIndex = 6
        Me.RdoBtnN.TabStop = True
        Me.RdoBtnN.UseVisualStyleBackColor = True
        '
        'RdoBtnY
        '
        Me.RdoBtnY.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RdoBtnY.AutoSize = True
        Me.RdoBtnY.Location = New System.Drawing.Point(4, 2)
        Me.RdoBtnY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnY.Name = "RdoBtnY"
        Me.RdoBtnY.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnY.TabIndex = 5
        Me.RdoBtnY.TabStop = True
        Me.RdoBtnY.UseVisualStyleBackColor = True
        '
        'lbl_sub_system_name
        '
        Me.lbl_sub_system_name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_sub_system_name.AutoSize = True
        Me.lbl_sub_system_name.Location = New System.Drawing.Point(17, 37)
        Me.lbl_sub_system_name.Name = "lbl_sub_system_name"
        Me.lbl_sub_system_name.Size = New System.Drawing.Size(96, 16)
        Me.lbl_sub_system_name.TabIndex = 1
        Me.lbl_sub_system_name.Text = "*子系統名稱"
        '
        'lbl_DCYN
        '
        Me.lbl_DCYN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DCYN.AutoSize = True
        Me.lbl_DCYN.Location = New System.Drawing.Point(33, 70)
        Me.lbl_DCYN.Name = "lbl_DCYN"
        Me.lbl_DCYN.Size = New System.Drawing.Size(80, 16)
        Me.lbl_DCYN.TabIndex = 2
        Me.lbl_DCYN.Text = "*是否有效"
        '
        'sub_system_no
        '
        Me.sub_system_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sub_system_no.Location = New System.Drawing.Point(411, 2)
        Me.sub_system_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sub_system_no.Name = "sub_system_no"
        Me.sub_system_no.Size = New System.Drawing.Size(156, 27)
        Me.sub_system_no.TabIndex = 2
        '
        'lbl_sub_system_no
        '
        Me.lbl_sub_system_no.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_sub_system_no.AutoSize = True
        Me.lbl_sub_system_no.ForeColor = System.Drawing.Color.Red
        Me.lbl_sub_system_no.Location = New System.Drawing.Point(309, 6)
        Me.lbl_sub_system_no.Name = "lbl_sub_system_no"
        Me.lbl_sub_system_no.Size = New System.Drawing.Size(96, 16)
        Me.lbl_sub_system_no.TabIndex = 0
        Me.lbl_sub_system_no.Text = "*子系統代碼"
        '
        'sub_system_name
        '
        Me.sub_system_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sub_system_name.Location = New System.Drawing.Point(119, 32)
        Me.sub_system_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sub_system_name.Name = "sub_system_name"
        Me.sub_system_name.Size = New System.Drawing.Size(186, 27)
        Me.sub_system_name.TabIndex = 3
        '
        'lbl_sub_app_system_no
        '
        Me.lbl_sub_app_system_no.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_sub_app_system_no.AutoSize = True
        Me.lbl_sub_app_system_no.ForeColor = System.Drawing.Color.Red
        Me.lbl_sub_app_system_no.Location = New System.Drawing.Point(33, 6)
        Me.lbl_sub_app_system_no.Name = "lbl_sub_app_system_no"
        Me.lbl_sub_app_system_no.Size = New System.Drawing.Size(80, 16)
        Me.lbl_sub_app_system_no.TabIndex = 5
        Me.lbl_sub_app_system_no.Text = "*系統代碼"
        '
        'sub_app_system_no
        '
        Me.sub_app_system_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sub_app_system_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sub_app_system_no.FormattingEnabled = True
        Me.sub_app_system_no.Location = New System.Drawing.Point(119, 2)
        Me.sub_app_system_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sub_app_system_no.Name = "sub_app_system_no"
        Me.sub_app_system_no.Size = New System.Drawing.Size(156, 24)
        Me.sub_app_system_no.TabIndex = 1
        '
        'lbl_sub_display_order
        '
        Me.lbl_sub_display_order.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_sub_display_order.AutoSize = True
        Me.lbl_sub_display_order.Location = New System.Drawing.Point(325, 37)
        Me.lbl_sub_display_order.Name = "lbl_sub_display_order"
        Me.lbl_sub_display_order.Size = New System.Drawing.Size(80, 16)
        Me.lbl_sub_display_order.TabIndex = 7
        Me.lbl_sub_display_order.Text = "*排列順序"
        '
        'sub_display_order
        '
        Me.sub_display_order.Location = New System.Drawing.Point(411, 30)
        Me.sub_display_order.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sub_display_order.Name = "sub_display_order"
        Me.sub_display_order.Size = New System.Drawing.Size(78, 27)
        Me.sub_display_order.TabIndex = 4
        '
        'SubSystemMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "SubSystemMtnUI"
        Me.Text = "子系統維護"
        Me.Controls.SetChildIndex(Me.tlp_nonButton, 0)
        Me.Controls.SetChildIndex(Me.IMaintainPanel, 0)
        Me.IMaintainPanel.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_sub_system_no As System.Windows.Forms.Label
    Friend WithEvents lbl_sub_system_name As System.Windows.Forms.Label
    Friend WithEvents lbl_DCYN As System.Windows.Forms.Label
    Friend WithEvents sub_system_no As System.Windows.Forms.TextBox
    Friend WithEvents sub_system_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_sub_app_system_no As System.Windows.Forms.Label
    Friend WithEvents sub_app_system_no As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_sub_display_order As System.Windows.Forms.Label
    Friend WithEvents sub_display_order As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBtnY As System.Windows.Forms.RadioButton
End Class
