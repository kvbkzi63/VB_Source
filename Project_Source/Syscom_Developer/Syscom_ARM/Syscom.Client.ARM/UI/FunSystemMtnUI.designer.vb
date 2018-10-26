<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FunSystemMtnUI

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
        Me.tlp_nonButton = New System.Windows.Forms.TableLayoutPanel()
        Me.sub_system_no = New System.Windows.Forms.ComboBox()
        Me.app_system_no = New System.Windows.Forms.ComboBox()
        Me.lbl_FunFunctionName = New System.Windows.Forms.Label()
        Me.fun_function_no = New System.Windows.Forms.TextBox()
        Me.lbl_FunFunctionNo = New System.Windows.Forms.Label()
        Me.fun_function_name = New System.Windows.Forms.TextBox()
        Me.lbl_FunTaskNo = New System.Windows.Forms.Label()
        Me.fun_task_no = New System.Windows.Forms.ComboBox()
        Me.lbl_Sort = New System.Windows.Forms.Label()
        Me.fun_display_order = New System.Windows.Forms.TextBox()
        Me.lbl_FunContent = New System.Windows.Forms.Label()
        Me.fun_content = New System.Windows.Forms.TextBox()
        Me.lbl_Memo = New System.Windows.Forms.Label()
        Me.lbl_SystemNo = New System.Windows.Forms.Label()
        Me.lbl_SubSystemNo = New System.Windows.Forms.Label()
        Me.lbl_Special = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbt_SpecialN = New System.Windows.Forms.RadioButton()
        Me.rbt_SpecialY = New System.Windows.Forms.RadioButton()
        Me.lbl_DC = New System.Windows.Forms.Label()
        Me.txt_Memo = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbt_DCN = New System.Windows.Forms.RadioButton()
        Me.rbt_DCY = New System.Windows.Forms.RadioButton()
        Me.IMaintainPanel.SuspendLayout()
        Me.tlp_nonButton.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IMaintainPanel
        '
        Me.IMaintainPanel.Location = New System.Drawing.Point(0, 209)
        Me.IMaintainPanel.Size = New System.Drawing.Size(1008, 410)
        '
        'dgvPanel
        '
        Me.dgvPanel.Size = New System.Drawing.Size(1006, 375)
        '
        'tlp_nonButton
        '
        Me.tlp_nonButton.ColumnCount = 4
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_nonButton.Controls.Add(Me.sub_system_no, 3, 0)
        Me.tlp_nonButton.Controls.Add(Me.app_system_no, 1, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_FunFunctionName, 0, 2)
        Me.tlp_nonButton.Controls.Add(Me.fun_function_no, 3, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_FunFunctionNo, 2, 1)
        Me.tlp_nonButton.Controls.Add(Me.fun_function_name, 1, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_FunTaskNo, 0, 1)
        Me.tlp_nonButton.Controls.Add(Me.fun_task_no, 1, 1)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Sort, 2, 2)
        Me.tlp_nonButton.Controls.Add(Me.fun_display_order, 3, 2)
        Me.tlp_nonButton.Controls.Add(Me.lbl_FunContent, 0, 3)
        Me.tlp_nonButton.Controls.Add(Me.fun_content, 1, 3)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Memo, 0, 4)
        Me.tlp_nonButton.Controls.Add(Me.lbl_SystemNo, 0, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_SubSystemNo, 2, 0)
        Me.tlp_nonButton.Controls.Add(Me.lbl_Special, 0, 5)
        Me.tlp_nonButton.Controls.Add(Me.Panel1, 1, 5)
        Me.tlp_nonButton.Controls.Add(Me.lbl_DC, 2, 5)
        Me.tlp_nonButton.Controls.Add(Me.txt_Memo, 1, 4)
        Me.tlp_nonButton.Controls.Add(Me.Panel2, 3, 5)
        Me.tlp_nonButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_nonButton.Location = New System.Drawing.Point(0, 0)
        Me.tlp_nonButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tlp_nonButton.Name = "tlp_nonButton"
        Me.tlp_nonButton.RowCount = 6
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_nonButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlp_nonButton.Size = New System.Drawing.Size(1008, 209)
        Me.tlp_nonButton.TabIndex = 2
        '
        'sub_system_no
        '
        Me.sub_system_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.sub_system_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sub_system_no.FormattingEnabled = True
        Me.sub_system_no.Location = New System.Drawing.Point(539, 7)
        Me.sub_system_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sub_system_no.Name = "sub_system_no"
        Me.sub_system_no.Size = New System.Drawing.Size(206, 24)
        Me.sub_system_no.TabIndex = 2
        '
        'app_system_no
        '
        Me.app_system_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.app_system_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.app_system_no.FormattingEnabled = True
        Me.app_system_no.Location = New System.Drawing.Point(89, 7)
        Me.app_system_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.app_system_no.Name = "app_system_no"
        Me.app_system_no.Size = New System.Drawing.Size(156, 24)
        Me.app_system_no.TabIndex = 1
        '
        'lbl_FunFunctionName
        '
        Me.lbl_FunFunctionName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_FunFunctionName.AutoSize = True
        Me.lbl_FunFunctionName.Location = New System.Drawing.Point(3, 77)
        Me.lbl_FunFunctionName.Name = "lbl_FunFunctionName"
        Me.lbl_FunFunctionName.Size = New System.Drawing.Size(80, 16)
        Me.lbl_FunFunctionName.TabIndex = 1
        Me.lbl_FunFunctionName.Text = "*功能名稱"
        '
        'fun_function_no
        '
        Me.fun_function_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fun_function_no.Location = New System.Drawing.Point(539, 37)
        Me.fun_function_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fun_function_no.Name = "fun_function_no"
        Me.fun_function_no.Size = New System.Drawing.Size(156, 27)
        Me.fun_function_no.TabIndex = 4
        '
        'lbl_FunFunctionNo
        '
        Me.lbl_FunFunctionNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_FunFunctionNo.AutoSize = True
        Me.lbl_FunFunctionNo.ForeColor = System.Drawing.Color.Red
        Me.lbl_FunFunctionNo.Location = New System.Drawing.Point(453, 43)
        Me.lbl_FunFunctionNo.Name = "lbl_FunFunctionNo"
        Me.lbl_FunFunctionNo.Size = New System.Drawing.Size(80, 16)
        Me.lbl_FunFunctionNo.TabIndex = 0
        Me.lbl_FunFunctionNo.Text = "*功能代碼"
        '
        'fun_function_name
        '
        Me.fun_function_name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fun_function_name.Location = New System.Drawing.Point(89, 71)
        Me.fun_function_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fun_function_name.Name = "fun_function_name"
        Me.fun_function_name.Size = New System.Drawing.Size(206, 27)
        Me.fun_function_name.TabIndex = 5
        '
        'lbl_FunTaskNo
        '
        Me.lbl_FunTaskNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_FunTaskNo.AutoSize = True
        Me.lbl_FunTaskNo.ForeColor = System.Drawing.Color.Red
        Me.lbl_FunTaskNo.Location = New System.Drawing.Point(3, 43)
        Me.lbl_FunTaskNo.Name = "lbl_FunTaskNo"
        Me.lbl_FunTaskNo.Size = New System.Drawing.Size(80, 16)
        Me.lbl_FunTaskNo.TabIndex = 5
        Me.lbl_FunTaskNo.Text = "*作業代碼"
        '
        'fun_task_no
        '
        Me.fun_task_no.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fun_task_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fun_task_no.FormattingEnabled = True
        Me.fun_task_no.Location = New System.Drawing.Point(89, 41)
        Me.fun_task_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fun_task_no.Name = "fun_task_no"
        Me.fun_task_no.Size = New System.Drawing.Size(342, 24)
        Me.fun_task_no.TabIndex = 3
        '
        'lbl_Sort
        '
        Me.lbl_Sort.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sort.AutoSize = True
        Me.lbl_Sort.Location = New System.Drawing.Point(453, 77)
        Me.lbl_Sort.Name = "lbl_Sort"
        Me.lbl_Sort.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Sort.TabIndex = 7
        Me.lbl_Sort.Text = "*排列順序"
        '
        'fun_display_order
        '
        Me.fun_display_order.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fun_display_order.Location = New System.Drawing.Point(539, 71)
        Me.fun_display_order.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fun_display_order.Name = "fun_display_order"
        Me.fun_display_order.Size = New System.Drawing.Size(78, 27)
        Me.fun_display_order.TabIndex = 6
        '
        'lbl_FunContent
        '
        Me.lbl_FunContent.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_FunContent.AutoSize = True
        Me.lbl_FunContent.Location = New System.Drawing.Point(3, 111)
        Me.lbl_FunContent.Name = "lbl_FunContent"
        Me.lbl_FunContent.Size = New System.Drawing.Size(80, 16)
        Me.lbl_FunContent.TabIndex = 10
        Me.lbl_FunContent.Text = "*功能明細"
        '
        'fun_content
        '
        Me.fun_content.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_nonButton.SetColumnSpan(Me.fun_content, 3)
        Me.fun_content.Location = New System.Drawing.Point(89, 105)
        Me.fun_content.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fun_content.Name = "fun_content"
        Me.fun_content.Size = New System.Drawing.Size(504, 27)
        Me.fun_content.TabIndex = 7
        '
        'lbl_Memo
        '
        Me.lbl_Memo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Memo.AutoSize = True
        Me.lbl_Memo.Location = New System.Drawing.Point(3, 144)
        Me.lbl_Memo.Name = "lbl_Memo"
        Me.lbl_Memo.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Memo.TabIndex = 12
        Me.lbl_Memo.Text = "*系統備註"
        '
        'lbl_SystemNo
        '
        Me.lbl_SystemNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SystemNo.AutoSize = True
        Me.lbl_SystemNo.ForeColor = System.Drawing.Color.Red
        Me.lbl_SystemNo.Location = New System.Drawing.Point(3, 9)
        Me.lbl_SystemNo.Name = "lbl_SystemNo"
        Me.lbl_SystemNo.Size = New System.Drawing.Size(80, 16)
        Me.lbl_SystemNo.TabIndex = 14
        Me.lbl_SystemNo.Text = "*系統代碼"
        '
        'lbl_SubSystemNo
        '
        Me.lbl_SubSystemNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_SubSystemNo.AutoSize = True
        Me.lbl_SubSystemNo.ForeColor = System.Drawing.Color.Red
        Me.lbl_SubSystemNo.Location = New System.Drawing.Point(437, 9)
        Me.lbl_SubSystemNo.Name = "lbl_SubSystemNo"
        Me.lbl_SubSystemNo.Size = New System.Drawing.Size(96, 16)
        Me.lbl_SubSystemNo.TabIndex = 15
        Me.lbl_SubSystemNo.Text = "*子系統代碼"
        '
        'lbl_Special
        '
        Me.lbl_Special.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Special.AutoSize = True
        Me.lbl_Special.Location = New System.Drawing.Point(3, 181)
        Me.lbl_Special.Name = "lbl_Special"
        Me.lbl_Special.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Special.TabIndex = 16
        Me.lbl_Special.Text = "*按鈕權限"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.Controls.Add(Me.rbt_SpecialN)
        Me.Panel1.Controls.Add(Me.rbt_SpecialY)
        Me.Panel1.Location = New System.Drawing.Point(90, 172)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 31)
        Me.Panel1.TabIndex = 8
        '
        'rbt_SpecialN
        '
        Me.rbt_SpecialN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_SpecialN.AutoSize = True
        Me.rbt_SpecialN.Location = New System.Drawing.Point(62, 7)
        Me.rbt_SpecialN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.rbt_SpecialN.Name = "rbt_SpecialN"
        Me.rbt_SpecialN.Size = New System.Drawing.Size(14, 13)
        Me.rbt_SpecialN.TabIndex = 9
        Me.rbt_SpecialN.TabStop = True
        Me.rbt_SpecialN.UseVisualStyleBackColor = True
        '
        'rbt_SpecialY
        '
        Me.rbt_SpecialY.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_SpecialY.AutoSize = True
        Me.rbt_SpecialY.Location = New System.Drawing.Point(4, 7)
        Me.rbt_SpecialY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.rbt_SpecialY.Name = "rbt_SpecialY"
        Me.rbt_SpecialY.Size = New System.Drawing.Size(14, 13)
        Me.rbt_SpecialY.TabIndex = 8
        Me.rbt_SpecialY.TabStop = True
        Me.rbt_SpecialY.UseVisualStyleBackColor = True
        '
        'lbl_DC
        '
        Me.lbl_DC.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_DC.AutoSize = True
        Me.lbl_DC.Location = New System.Drawing.Point(453, 181)
        Me.lbl_DC.Name = "lbl_DC"
        Me.lbl_DC.Size = New System.Drawing.Size(80, 16)
        Me.lbl_DC.TabIndex = 2
        Me.lbl_DC.Text = "*是否有效"
        '
        'txt_Memo
        '
        Me.tlp_nonButton.SetColumnSpan(Me.txt_Memo, 3)
        Me.txt_Memo.Location = New System.Drawing.Point(89, 139)
        Me.txt_Memo.Name = "txt_Memo"
        Me.txt_Memo.Size = New System.Drawing.Size(504, 27)
        Me.txt_Memo.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.Controls.Add(Me.rbt_DCN)
        Me.Panel2.Controls.Add(Me.rbt_DCY)
        Me.Panel2.Location = New System.Drawing.Point(540, 172)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(155, 31)
        Me.Panel2.TabIndex = 9
        '
        'rbt_DCN
        '
        Me.rbt_DCN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_DCN.AutoSize = True
        Me.rbt_DCN.Location = New System.Drawing.Point(63, 7)
        Me.rbt_DCN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.rbt_DCN.Name = "rbt_DCN"
        Me.rbt_DCN.Size = New System.Drawing.Size(14, 13)
        Me.rbt_DCN.TabIndex = 11
        Me.rbt_DCN.TabStop = True
        Me.rbt_DCN.UseVisualStyleBackColor = True
        '
        'rbt_DCY
        '
        Me.rbt_DCY.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_DCY.AutoSize = True
        Me.rbt_DCY.Location = New System.Drawing.Point(4, 6)
        Me.rbt_DCY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 3)
        Me.rbt_DCY.Name = "rbt_DCY"
        Me.rbt_DCY.Size = New System.Drawing.Size(14, 13)
        Me.rbt_DCY.TabIndex = 10
        Me.rbt_DCY.TabStop = True
        Me.rbt_DCY.UseVisualStyleBackColor = True
        '
        'FunSystemMtnUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.Controls.Add(Me.tlp_nonButton)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FunSystemMtnUI"
        Me.Text = "功能維護"
        Me.Controls.SetChildIndex(Me.tlp_nonButton, 0)
        Me.Controls.SetChildIndex(Me.IMaintainPanel, 0)
        Me.IMaintainPanel.ResumeLayout(False)
        Me.tlp_nonButton.ResumeLayout(False)
        Me.tlp_nonButton.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_nonButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbt_DCN As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_DCY As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_FunFunctionName As System.Windows.Forms.Label
    Friend WithEvents lbl_DC As System.Windows.Forms.Label
    Friend WithEvents fun_function_no As System.Windows.Forms.TextBox
    Friend WithEvents lbl_FunFunctionNo As System.Windows.Forms.Label
    Friend WithEvents fun_function_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_FunTaskNo As System.Windows.Forms.Label
    Friend WithEvents fun_task_no As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Sort As System.Windows.Forms.Label
    Friend WithEvents fun_display_order As System.Windows.Forms.TextBox
    Friend WithEvents lbl_FunContent As System.Windows.Forms.Label
    Friend WithEvents fun_content As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Memo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbt_SpecialN As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_SpecialY As System.Windows.Forms.RadioButton
    Friend WithEvents sub_system_no As System.Windows.Forms.ComboBox
    Friend WithEvents app_system_no As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_SystemNo As System.Windows.Forms.Label
    Friend WithEvents lbl_SubSystemNo As System.Windows.Forms.Label
    Friend WithEvents lbl_Special As Windows.Forms.Label
    Friend WithEvents txt_Memo As Windows.Forms.TextBox
End Class
