<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBContinueConditionUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBContinueConditionUI))
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_stop = New System.Windows.Forms.Button
        Me.gb_corr_rule = New System.Windows.Forms.GroupBox
        Me.tv_corr_condition = New System.Windows.Forms.TreeView
        Me.tlp_period = New System.Windows.Forms.TableLayoutPanel
        Me.lb_to = New System.Windows.Forms.Label
        Me.ucl_dtp_effstart = New Syscom.Client.ucl.UCLDateTimePickerUC
        Me.ucl_dtp_effend = New Syscom.Client.ucl.UCLDateTimePickerUC
        Me.cb_showrelated = New System.Windows.Forms.CheckBox
        Me.cb_showinperiod = New System.Windows.Forms.CheckBox
        Me.btn_query = New System.Windows.Forms.Button
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.lb_rulebelong_item = New System.Windows.Forms.Label
        Me.ucl_comb_belongitem = New Syscom.Client.UCL.UCLComboBoxUC
        Me.ucl_txt_initcond = New Syscom.Client.UCL.UCLTextBoxUC
        Me.lb_initcondition = New System.Windows.Forms.Label
        Me.lb_effectdate = New System.Windows.Forms.Label
        Me.ucl_txt_clickmsg = New Syscom.Client.UCL.UCLTextBoxUC
        Me.lb_selectednode = New System.Windows.Forms.Label
        Me.tlp_parent.SuspendLayout()
        Me.gb_corr_rule.SuspendLayout()
        Me.tlp_period.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 3
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.90196!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.47059!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82353!))
        Me.tlp_parent.Controls.Add(Me.btn_clear, 2, 3)
        Me.tlp_parent.Controls.Add(Me.btn_stop, 2, 1)
        Me.tlp_parent.Controls.Add(Me.gb_corr_rule, 0, 6)
        Me.tlp_parent.Controls.Add(Me.tlp_period, 1, 2)
        Me.tlp_parent.Controls.Add(Me.cb_showrelated, 0, 4)
        Me.tlp_parent.Controls.Add(Me.cb_showinperiod, 0, 5)
        Me.tlp_parent.Controls.Add(Me.btn_query, 2, 2)
        Me.tlp_parent.Controls.Add(Me.btn_confirm, 2, 0)
        Me.tlp_parent.Controls.Add(Me.lb_rulebelong_item, 0, 0)
        Me.tlp_parent.Controls.Add(Me.ucl_comb_belongitem, 1, 0)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_initcond, 1, 1)
        Me.tlp_parent.Controls.Add(Me.lb_initcondition, 0, 1)
        Me.tlp_parent.Controls.Add(Me.lb_effectdate, 0, 2)
        Me.tlp_parent.Controls.Add(Me.ucl_txt_clickmsg, 1, 3)
        Me.tlp_parent.Controls.Add(Me.lb_selectednode, 0, 3)
        Me.tlp_parent.Location = New System.Drawing.Point(2, 3)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 7
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(510, 422)
        Me.tlp_parent.TabIndex = 0
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_clear.Location = New System.Drawing.Point(413, 88)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 27)
        Me.btn_clear.TabIndex = 14
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_stop
        '
        Me.btn_stop.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_stop.Enabled = False
        Me.btn_stop.Location = New System.Drawing.Point(413, 30)
        Me.btn_stop.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(90, 27)
        Me.btn_stop.TabIndex = 12
        Me.btn_stop.Text = "SF10-停用"
        Me.btn_stop.UseVisualStyleBackColor = True
        '
        'gb_corr_rule
        '
        Me.tlp_parent.SetColumnSpan(Me.gb_corr_rule, 3)
        Me.gb_corr_rule.Controls.Add(Me.tv_corr_condition)
        Me.gb_corr_rule.Location = New System.Drawing.Point(3, 177)
        Me.gb_corr_rule.Name = "gb_corr_rule"
        Me.gb_corr_rule.Size = New System.Drawing.Size(504, 242)
        Me.gb_corr_rule.TabIndex = 0
        Me.gb_corr_rule.TabStop = False
        Me.gb_corr_rule.Text = "符合查詢條件規則"
        '
        'tv_corr_condition
        '
        Me.tv_corr_condition.Location = New System.Drawing.Point(3, 17)
        Me.tv_corr_condition.Name = "tv_corr_condition"
        Me.tv_corr_condition.Size = New System.Drawing.Size(497, 222)
        Me.tv_corr_condition.TabIndex = 0
        '
        'tlp_period
        '
        Me.tlp_period.ColumnCount = 3
        Me.tlp_period.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlp_period.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlp_period.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlp_period.Controls.Add(Me.lb_to, 1, 0)
        Me.tlp_period.Controls.Add(Me.ucl_dtp_effstart, 0, 0)
        Me.tlp_period.Controls.Add(Me.ucl_dtp_effend, 2, 0)
        Me.tlp_period.Location = New System.Drawing.Point(126, 58)
        Me.tlp_period.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_period.Name = "tlp_period"
        Me.tlp_period.RowCount = 1
        Me.tlp_period.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_period.Size = New System.Drawing.Size(287, 29)
        Me.tlp_period.TabIndex = 8
        '
        'lb_to
        '
        Me.lb_to.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_to.AutoSize = True
        Me.lb_to.Location = New System.Drawing.Point(132, 6)
        Me.lb_to.Name = "lb_to"
        Me.lb_to.Size = New System.Drawing.Size(22, 16)
        Me.lb_to.TabIndex = 11
        Me.lb_to.Text = "至"
        '
        'ucl_dtp_effstart
        '
        Me.ucl_dtp_effstart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_effstart.DisplayLocale = Syscom.Client.ucl.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_effstart.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_effstart.Location = New System.Drawing.Point(0, 1)
        Me.ucl_dtp_effstart.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_dtp_effstart.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_effstart.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_effstart.Name = "ucl_dtp_effstart"
        Me.ucl_dtp_effstart.Size = New System.Drawing.Size(120, 27)
        Me.ucl_dtp_effstart.TabIndex = 0
        Me.ucl_dtp_effstart.uclReadOnly = False
        '
        'ucl_dtp_effend
        '
        Me.ucl_dtp_effend.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_dtp_effend.DisplayLocale = Syscom.Client.ucl.UCLDateTimePickerUC.Locale.US
        Me.ucl_dtp_effend.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_dtp_effend.Location = New System.Drawing.Point(157, 1)
        Me.ucl_dtp_effend.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_dtp_effend.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.ucl_dtp_effend.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ucl_dtp_effend.Name = "ucl_dtp_effend"
        Me.ucl_dtp_effend.Size = New System.Drawing.Size(120, 27)
        Me.ucl_dtp_effend.TabIndex = 1
        Me.ucl_dtp_effend.uclReadOnly = False
        '
        'cb_showrelated
        '
        Me.cb_showrelated.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_showrelated.AutoSize = True
        Me.tlp_parent.SetColumnSpan(Me.cb_showrelated, 2)
        Me.cb_showrelated.Enabled = False
        Me.cb_showrelated.Location = New System.Drawing.Point(3, 120)
        Me.cb_showrelated.Name = "cb_showrelated"
        Me.cb_showrelated.Size = New System.Drawing.Size(319, 20)
        Me.cb_showrelated.TabIndex = 9
        Me.cb_showrelated.Text = "同時顯示對應健保碼/成大碼相關規則設定"
        Me.cb_showrelated.UseVisualStyleBackColor = True
        '
        'cb_showinperiod
        '
        Me.cb_showinperiod.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_showinperiod.AutoSize = True
        Me.tlp_parent.SetColumnSpan(Me.cb_showinperiod, 2)
        Me.cb_showinperiod.Enabled = False
        Me.cb_showinperiod.Location = New System.Drawing.Point(3, 149)
        Me.cb_showinperiod.Name = "cb_showinperiod"
        Me.cb_showinperiod.Size = New System.Drawing.Size(203, 20)
        Me.cb_showinperiod.TabIndex = 10
        Me.cb_showinperiod.Text = "只顯示未過期的條件規則"
        Me.cb_showinperiod.UseVisualStyleBackColor = True
        '
        'btn_query
        '
        Me.btn_query.Location = New System.Drawing.Point(413, 58)
        Me.btn_query.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_query.Name = "btn_query"
        Me.btn_query.Size = New System.Drawing.Size(90, 27)
        Me.btn_query.TabIndex = 11
        Me.btn_query.Text = "F1-查詢"
        Me.btn_query.UseVisualStyleBackColor = True
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_confirm.Location = New System.Drawing.Point(413, 1)
        Me.btn_confirm.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 13
        Me.btn_confirm.Text = "F10-確定"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'lb_rulebelong_item
        '
        Me.lb_rulebelong_item.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_rulebelong_item.AutoSize = True
        Me.lb_rulebelong_item.Location = New System.Drawing.Point(19, 6)
        Me.lb_rulebelong_item.Name = "lb_rulebelong_item"
        Me.lb_rulebelong_item.Size = New System.Drawing.Size(104, 16)
        Me.lb_rulebelong_item.TabIndex = 2
        Me.lb_rulebelong_item.Text = "規則歸屬項目"
        '
        'ucl_comb_belongitem
        '
        Me.ucl_comb_belongitem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_belongitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_belongitem.DropDownWidth = 20
        Me.ucl_comb_belongitem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_belongitem.Location = New System.Drawing.Point(126, 2)
        Me.ucl_comb_belongitem.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_comb_belongitem.Name = "ucl_comb_belongitem"
        Me.ucl_comb_belongitem.SelectedIndex = -1
        Me.ucl_comb_belongitem.SelectedItem = Nothing
        Me.ucl_comb_belongitem.SelectedText = ""
        Me.ucl_comb_belongitem.SelectedValue = ""
        Me.ucl_comb_belongitem.SelectionStart = 0
        Me.ucl_comb_belongitem.Size = New System.Drawing.Size(160, 24)
        Me.ucl_comb_belongitem.TabIndex = 6
        Me.ucl_comb_belongitem.uclDisplayIndex = "0,1"
        Me.ucl_comb_belongitem.uclShowMsg = False
        Me.ucl_comb_belongitem.uclValueIndex = "0"
        '
        'ucl_txt_initcond
        '
        Me.ucl_txt_initcond.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_initcond.Enabled = False
        Me.ucl_txt_initcond.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_initcond.Location = New System.Drawing.Point(126, 30)
        Me.ucl_txt_initcond.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_initcond.MaxLength = 10
        Me.ucl_txt_initcond.Name = "ucl_txt_initcond"
        Me.ucl_txt_initcond.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_initcond.SelectionStart = 0
        Me.ucl_txt_initcond.Size = New System.Drawing.Size(160, 27)
        Me.ucl_txt_initcond.TabIndex = 7
        Me.ucl_txt_initcond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_initcond.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_initcond.uclDollarSign = False
        Me.ucl_txt_initcond.uclDotCount = 0
        Me.ucl_txt_initcond.uclIntCount = 2
        Me.ucl_txt_initcond.uclMinus = False
        Me.ucl_txt_initcond.uclReadOnly = False
        Me.ucl_txt_initcond.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lb_initcondition
        '
        Me.lb_initcondition.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_initcondition.AutoSize = True
        Me.lb_initcondition.Location = New System.Drawing.Point(51, 35)
        Me.lb_initcondition.Name = "lb_initcondition"
        Me.lb_initcondition.Size = New System.Drawing.Size(72, 16)
        Me.lb_initcondition.TabIndex = 3
        Me.lb_initcondition.Text = "起始條件"
        '
        'lb_effectdate
        '
        Me.lb_effectdate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_effectdate.AutoSize = True
        Me.lb_effectdate.Location = New System.Drawing.Point(51, 64)
        Me.lb_effectdate.Name = "lb_effectdate"
        Me.lb_effectdate.Size = New System.Drawing.Size(72, 16)
        Me.lb_effectdate.TabIndex = 4
        Me.lb_effectdate.Text = "生效日期"
        '
        'ucl_txt_clickmsg
        '
        Me.ucl_txt_clickmsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_txt_clickmsg.Enabled = False
        Me.ucl_txt_clickmsg.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_txt_clickmsg.Location = New System.Drawing.Point(126, 88)
        Me.ucl_txt_clickmsg.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_clickmsg.MaxLength = 100
        Me.ucl_txt_clickmsg.Name = "ucl_txt_clickmsg"
        Me.ucl_txt_clickmsg.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_clickmsg.SelectionStart = 0
        Me.ucl_txt_clickmsg.Size = New System.Drawing.Size(178, 27)
        Me.ucl_txt_clickmsg.TabIndex = 15
        Me.ucl_txt_clickmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_clickmsg.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_clickmsg.uclDollarSign = False
        Me.ucl_txt_clickmsg.uclDotCount = 0
        Me.ucl_txt_clickmsg.uclIntCount = 2
        Me.ucl_txt_clickmsg.uclMinus = False
        Me.ucl_txt_clickmsg.uclReadOnly = False
        Me.ucl_txt_clickmsg.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'lb_selectednode
        '
        Me.lb_selectednode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_selectednode.AutoSize = True
        Me.lb_selectednode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lb_selectednode.Location = New System.Drawing.Point(38, 93)
        Me.lb_selectednode.Name = "lb_selectednode"
        Me.lb_selectednode.Size = New System.Drawing.Size(85, 16)
        Me.lb_selectednode.TabIndex = 16
        Me.lb_selectednode.Text = "*點選規則"
        '
        'PUBContinueConditionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 427)
        Me.Controls.Add(Me.tlp_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBContinueConditionUI"
        Me.TabText = "續接條件"
        Me.Text = "續接條件"
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.gb_corr_rule.ResumeLayout(False)
        Me.tlp_period.ResumeLayout(False)
        Me.tlp_period.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gb_corr_rule As System.Windows.Forms.GroupBox
    Friend WithEvents lb_rulebelong_item As System.Windows.Forms.Label
    Friend WithEvents lb_initcondition As System.Windows.Forms.Label
    Friend WithEvents lb_effectdate As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_belongitem As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ucl_txt_initcond As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents tlp_period As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_to As System.Windows.Forms.Label
    Friend WithEvents ucl_dtp_effstart As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents ucl_dtp_effend As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents cb_showrelated As System.Windows.Forms.CheckBox
    Friend WithEvents cb_showinperiod As System.Windows.Forms.CheckBox
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_stop As System.Windows.Forms.Button
    Friend WithEvents btn_query As System.Windows.Forms.Button
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents tv_corr_condition As System.Windows.Forms.TreeView
    Friend WithEvents ucl_txt_clickmsg As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_selectednode As System.Windows.Forms.Label
End Class
