<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleCloneUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRuleCloneUI))
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel
        Me.tlp_button = New System.Windows.Forms.TableLayoutPanel
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_clone = New System.Windows.Forms.Button
        Me.tv_ruleinfo = New System.Windows.Forms.TreeView
        Me.gb_cloneup = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lb_rule_init_item = New System.Windows.Forms.Label
        Me.lb_initrange = New System.Windows.Forms.Label
        Me.ucl_rtb_valuedata = New Syscom.Client.UCL.UCLRichTextBoxUC
        Me.ucl_comb_ruleinit = New Syscom.Client.UCL.UCLComboBoxUC
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.lb_item = New System.Windows.Forms.Label
        Me.lb_rulebelong = New System.Windows.Forms.Label
        Me.lb_rulecontent = New System.Windows.Forms.Label
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tlp_selected = New System.Windows.Forms.TableLayoutPanel
        Me.lb_selectedrule = New System.Windows.Forms.Label
        Me.lb_ruleinfo = New System.Windows.Forms.Label
        Me.tlp_frame.SuspendLayout()
        Me.tlp_button.SuspendLayout()
        Me.gb_cloneup.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tlp_selected.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_frame.Controls.Add(Me.tlp_button, 0, 5)
        Me.tlp_frame.Controls.Add(Me.tv_ruleinfo, 0, 2)
        Me.tlp_frame.Controls.Add(Me.gb_cloneup, 0, 4)
        Me.tlp_frame.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.tlp_frame.Controls.Add(Me.lb_rulecontent, 0, 1)
        Me.tlp_frame.Controls.Add(Me.tlp_selected, 0, 3)
        Me.tlp_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_frame.Location = New System.Drawing.Point(0, 0)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 6
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.0!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_frame.Size = New System.Drawing.Size(442, 406)
        Me.tlp_frame.TabIndex = 1
        '
        'tlp_button
        '
        Me.tlp_button.ColumnCount = 2
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.17164!))
        Me.tlp_button.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.82836!))
        Me.tlp_button.Controls.Add(Me.btn_clear, 0, 0)
        Me.tlp_button.Controls.Add(Me.btn_clone, 1, 0)
        Me.tlp_button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_button.Location = New System.Drawing.Point(3, 370)
        Me.tlp_button.Name = "tlp_button"
        Me.tlp_button.RowCount = 1
        Me.tlp_button.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_button.Size = New System.Drawing.Size(436, 33)
        Me.tlp_button.TabIndex = 3
        '
        'btn_clear
        '
        Me.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_clear.Location = New System.Drawing.Point(247, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 27)
        Me.btn_clear.TabIndex = 3
        Me.btn_clear.Text = "F5-清除"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_clone
        '
        Me.btn_clone.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_clone.Location = New System.Drawing.Point(343, 3)
        Me.btn_clone.Name = "btn_clone"
        Me.btn_clone.Size = New System.Drawing.Size(90, 27)
        Me.btn_clone.TabIndex = 2
        Me.btn_clone.Text = "F12-複製"
        Me.btn_clone.UseVisualStyleBackColor = True
        '
        'tv_ruleinfo
        '
        Me.tv_ruleinfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tv_ruleinfo.Location = New System.Drawing.Point(3, 75)
        Me.tv_ruleinfo.Name = "tv_ruleinfo"
        Me.tv_ruleinfo.Size = New System.Drawing.Size(436, 91)
        Me.tv_ruleinfo.TabIndex = 7
        '
        'gb_cloneup
        '
        Me.gb_cloneup.Controls.Add(Me.TableLayoutPanel1)
        Me.gb_cloneup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_cloneup.Location = New System.Drawing.Point(3, 208)
        Me.gb_cloneup.Name = "gb_cloneup"
        Me.gb_cloneup.Size = New System.Drawing.Size(436, 156)
        Me.gb_cloneup.TabIndex = 8
        Me.gb_cloneup.TabStop = False
        Me.gb_cloneup.Text = "複製上方所選規則的目的範圍"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lb_rule_init_item, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lb_initrange, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_rtb_valuedata, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ucl_comb_ruleinit, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 23)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 130)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lb_rule_init_item
        '
        Me.lb_rule_init_item.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_rule_init_item.AutoSize = True
        Me.lb_rule_init_item.Location = New System.Drawing.Point(3, 11)
        Me.lb_rule_init_item.Name = "lb_rule_init_item"
        Me.lb_rule_init_item.Size = New System.Drawing.Size(104, 16)
        Me.lb_rule_init_item.TabIndex = 9
        Me.lb_rule_init_item.Text = "規則觸發項目"
        '
        'lb_initrange
        '
        Me.lb_initrange.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_initrange.AutoSize = True
        Me.lb_initrange.Location = New System.Drawing.Point(3, 76)
        Me.lb_initrange.Name = "lb_initrange"
        Me.lb_initrange.Size = New System.Drawing.Size(104, 16)
        Me.lb_initrange.TabIndex = 10
        Me.lb_initrange.Text = "起始條件值域"
        '
        'ucl_rtb_valuedata
        '
        Me.ucl_rtb_valuedata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_rtb_valuedata.Location = New System.Drawing.Point(154, 43)
        Me.ucl_rtb_valuedata.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_rtb_valuedata.Name = "ucl_rtb_valuedata"
        Me.ucl_rtb_valuedata.Size = New System.Drawing.Size(272, 83)
        Me.ucl_rtb_valuedata.TabIndex = 11
        Me.ucl_rtb_valuedata.uclMaxLength = 32767
        Me.ucl_rtb_valuedata.uclReadOnly = False
        Me.ucl_rtb_valuedata.uclWordWrap = True
        '
        'ucl_comb_ruleinit
        '
        Me.ucl_comb_ruleinit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucl_comb_ruleinit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.ucl_comb_ruleinit.DropDownWidth = 20
        Me.ucl_comb_ruleinit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_comb_ruleinit.Location = New System.Drawing.Point(154, 7)
        Me.ucl_comb_ruleinit.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_comb_ruleinit.Name = "ucl_comb_ruleinit"
        Me.ucl_comb_ruleinit.SelectedIndex = -1
        Me.ucl_comb_ruleinit.SelectedItem = Nothing
        Me.ucl_comb_ruleinit.SelectedText = ""
        Me.ucl_comb_ruleinit.SelectedValue = ""
        Me.ucl_comb_ruleinit.SelectionStart = 0
        Me.ucl_comb_ruleinit.Size = New System.Drawing.Size(170, 24)
        Me.ucl_comb_ruleinit.TabIndex = 12
        Me.ucl_comb_ruleinit.uclDisplayIndex = "0,1"
        Me.ucl_comb_ruleinit.uclShowMsg = False
        Me.ucl_comb_ruleinit.uclValueIndex = "0"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lb_item, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_rulebelong, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(442, 36)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'lb_item
        '
        Me.lb_item.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_item.AutoSize = True
        Me.lb_item.Location = New System.Drawing.Point(113, 10)
        Me.lb_item.Name = "lb_item"
        Me.lb_item.Size = New System.Drawing.Size(41, 16)
        Me.lb_item.TabIndex = 5
        Me.lb_item.Text = "XXX"
        '
        'lb_rulebelong
        '
        Me.lb_rulebelong.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_rulebelong.AutoSize = True
        Me.lb_rulebelong.Location = New System.Drawing.Point(3, 10)
        Me.lb_rulebelong.Name = "lb_rulebelong"
        Me.lb_rulebelong.Size = New System.Drawing.Size(104, 16)
        Me.lb_rulebelong.TabIndex = 4
        Me.lb_rulebelong.Text = "規則歸屬項目"
        '
        'lb_rulecontent
        '
        Me.lb_rulecontent.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_rulecontent.AutoSize = True
        Me.lb_rulecontent.Location = New System.Drawing.Point(3, 46)
        Me.lb_rulecontent.Name = "lb_rulecontent"
        Me.lb_rulecontent.Size = New System.Drawing.Size(72, 16)
        Me.lb_rulecontent.TabIndex = 11
        Me.lb_rulecontent.Text = "規則內容"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "XXX"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "規則歸屬項目"
        '
        'tlp_selected
        '
        Me.tlp_selected.ColumnCount = 2
        Me.tlp_selected.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_selected.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.tlp_selected.Controls.Add(Me.lb_selectedrule, 0, 0)
        Me.tlp_selected.Controls.Add(Me.lb_ruleinfo, 1, 0)
        Me.tlp_selected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_selected.Location = New System.Drawing.Point(0, 169)
        Me.tlp_selected.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_selected.Name = "tlp_selected"
        Me.tlp_selected.RowCount = 1
        Me.tlp_selected.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_selected.Size = New System.Drawing.Size(442, 36)
        Me.tlp_selected.TabIndex = 12
        '
        'lb_selectedrule
        '
        Me.lb_selectedrule.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_selectedrule.AutoSize = True
        Me.lb_selectedrule.Location = New System.Drawing.Point(3, 10)
        Me.lb_selectedrule.Name = "lb_selectedrule"
        Me.lb_selectedrule.Size = New System.Drawing.Size(72, 16)
        Me.lb_selectedrule.TabIndex = 0
        Me.lb_selectedrule.Text = "點選規則"
        '
        'lb_ruleinfo
        '
        Me.lb_ruleinfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_ruleinfo.AutoSize = True
        Me.lb_ruleinfo.Location = New System.Drawing.Point(113, 10)
        Me.lb_ruleinfo.Name = "lb_ruleinfo"
        Me.lb_ruleinfo.Size = New System.Drawing.Size(41, 16)
        Me.lb_ruleinfo.TabIndex = 1
        Me.lb_ruleinfo.Text = "XXX"
        '
        'PUBRuleCloneUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 406)
        Me.Controls.Add(Me.tlp_frame)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRuleCloneUI"
        Me.TabText = "複製規則"
        Me.Text = "複製規則"
        Me.tlp_frame.ResumeLayout(False)
        Me.tlp_frame.PerformLayout()
        Me.tlp_button.ResumeLayout(False)
        Me.gb_cloneup.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tlp_selected.ResumeLayout(False)
        Me.tlp_selected.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_clone As System.Windows.Forms.Button
    Friend WithEvents tlp_button As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_rulebelong As System.Windows.Forms.Label
    Friend WithEvents tv_ruleinfo As System.Windows.Forms.TreeView
    Friend WithEvents gb_cloneup As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_rule_init_item As System.Windows.Forms.Label
    Friend WithEvents lb_initrange As System.Windows.Forms.Label
    Friend WithEvents ucl_rtb_valuedata As Syscom.Client.UCL.UCLRichTextBoxUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_rulecontent As System.Windows.Forms.Label
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents lb_item As System.Windows.Forms.Label
    Friend WithEvents ucl_comb_ruleinit As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents tlp_selected As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lb_selectedrule As System.Windows.Forms.Label
    Friend WithEvents lb_ruleinfo As System.Windows.Forms.Label
End Class
