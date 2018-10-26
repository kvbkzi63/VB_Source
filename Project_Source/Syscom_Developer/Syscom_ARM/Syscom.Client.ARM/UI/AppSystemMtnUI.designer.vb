<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppSystemMtnUI

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
        Me.lbl_SystemCode = New System.Windows.Forms.Label
        Me.app_system_no = New System.Windows.Forms.TextBox
        Me.lbl_SystemName = New System.Windows.Forms.Label
        Me.app_system_name = New System.Windows.Forms.TextBox
        Me.lbl_Sort = New System.Windows.Forms.Label
        Me.app_display_order = New System.Windows.Forms.TextBox
        Me.lbl_DCYN = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RdoBtnN = New System.Windows.Forms.RadioButton
        Me.RdoBtnY = New System.Windows.Forms.RadioButton
        Me.IMaintainPanel.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IMaintainPanel
        '
        Me.IMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IMaintainPanel.Location = New System.Drawing.Point(0, 65)
        Me.IMaintainPanel.Size = New System.Drawing.Size(1008, 554)
        '
        'dgvPanel
        '
        Me.dgvPanel.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.dgvPanel.Size = New System.Drawing.Size(1006, 524)
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 4
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 664.0!))
        Me.tlp_nonButton.Controls.Add(Me.lbl_SystemCode, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.app_system_no, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_SystemName, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.app_system_name, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Sort, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.app_display_order, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_DCYN, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.Panel2, 3, 1)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 2
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1008, 65)
        Me.tlp_nonButton.TabIndex = 2
        '
        'lbl_SystemCode
        '
        Me.lbl_SystemCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SystemCode.AutoSize = True
        Me.lbl_SystemCode.ForeColor = System.Drawing.Color.Red
        Me.lbl_SystemCode.Location = New System.Drawing.Point(20, 8)
        Me.lbl_SystemCode.Name = "lbl_SystemCode"
        Me.lbl_SystemCode.Size = New System.Drawing.Size(80, 16)
        Me.lbl_SystemCode.TabIndex = 0
        Me.lbl_SystemCode.Text = "*系統代碼"
        '
        'app_system_no
        '
        Me.app_system_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.app_system_no.Location = New System.Drawing.Point(106, 3)
        Me.app_system_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.app_system_no.Name = "app_system_no"
        Me.app_system_no.Size = New System.Drawing.Size(131, 27)
        Me.app_system_no.TabIndex = 1
        '
        'lbl_SystemName
        '
        Me.lbl_SystemName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SystemName.AutoSize = True
        Me.lbl_SystemName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_SystemName.Location = New System.Drawing.Point(261, 8)
        Me.lbl_SystemName.Name = "lbl_SystemName"
        Me.lbl_SystemName.Size = New System.Drawing.Size(80, 16)
        Me.lbl_SystemName.TabIndex = 1
        Me.lbl_SystemName.Text = "*系統名稱"
        '
        'app_system_name
        '
        Me.app_system_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.app_system_name.Location = New System.Drawing.Point(347, 3)
        Me.app_system_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.app_system_name.Name = "app_system_name"
        Me.app_system_name.Size = New System.Drawing.Size(156, 27)
        Me.app_system_name.TabIndex = 2
        '
        'lbl_Sort
        '
        Me.lbl_Sort.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sort.AutoSize = True
        Me.lbl_Sort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_Sort.Location = New System.Drawing.Point(20, 41)
        Me.lbl_Sort.Name = "lbl_Sort"
        Me.lbl_Sort.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Sort.TabIndex = 5
        Me.lbl_Sort.Text = "*排列順序"
        '
        'app_display_order
        '
        Me.app_display_order.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.app_display_order.Location = New System.Drawing.Point(106, 35)
        Me.app_display_order.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.app_display_order.Name = "app_display_order"
        Me.app_display_order.Size = New System.Drawing.Size(78, 27)
        Me.app_display_order.TabIndex = 3
        '
        'lbl_DCYN
        '
        Me.lbl_DCYN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DCYN.AutoSize = True
        Me.lbl_DCYN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_DCYN.Location = New System.Drawing.Point(261, 41)
        Me.lbl_DCYN.Name = "lbl_DCYN"
        Me.lbl_DCYN.Size = New System.Drawing.Size(80, 16)
        Me.lbl_DCYN.TabIndex = 2
        Me.lbl_DCYN.Text = "*是否有效"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.Controls.Add(Me.RdoBtnN)
        Me.Panel2.Controls.Add(Me.RdoBtnY)
        Me.Panel2.Location = New System.Drawing.Point(348, 38)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(155, 22)
        Me.Panel2.TabIndex = 4
        '
        'RdoBtnN
        '
        Me.RdoBtnN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RdoBtnN.AutoSize = True
        Me.RdoBtnN.Location = New System.Drawing.Point(58, 2)
        Me.RdoBtnN.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoBtnN.Name = "RdoBtnN"
        Me.RdoBtnN.Size = New System.Drawing.Size(14, 13)
        Me.RdoBtnN.TabIndex = 5
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
        Me.RdoBtnY.TabIndex = 4
        Me.RdoBtnY.TabStop = True
        Me.RdoBtnY.UseVisualStyleBackColor = True
        '
        'AppSystemMtnUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Name = "AppSystemMtnUI"
        Me.Text = "系統維護"
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
    Friend WithEvents lbl_SystemCode As System.Windows.Forms.Label
    Friend WithEvents lbl_SystemName As System.Windows.Forms.Label
    Friend WithEvents lbl_DCYN As System.Windows.Forms.Label
    Friend WithEvents app_system_no As System.Windows.Forms.TextBox
    Friend WithEvents app_system_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Sort As System.Windows.Forms.Label
    Friend WithEvents app_display_order As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RdoBtnN As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBtnY As System.Windows.Forms.RadioButton
End Class
