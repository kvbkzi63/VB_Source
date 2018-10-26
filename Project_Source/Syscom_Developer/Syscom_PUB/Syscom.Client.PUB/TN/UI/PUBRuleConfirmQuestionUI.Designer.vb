<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRuleConfirmQuestionUI
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
        Me.gb_parent = New System.Windows.Forms.GroupBox
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel
        Me.lb_urleprocess = New System.Windows.Forms.Label
        Me.btn_confirm = New System.Windows.Forms.Button
        Me.tlp_confirm = New System.Windows.Forms.TableLayoutPanel
        Me.cb_add = New System.Windows.Forms.CheckBox
        Me.cb_modifyerror = New System.Windows.Forms.CheckBox
        Me.cb_insertanother = New System.Windows.Forms.CheckBox
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
        Me.tlp_confirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_frame)
        Me.gb_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_parent.Location = New System.Drawing.Point(0, 0)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(292, 266)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_frame.Controls.Add(Me.lb_urleprocess, 0, 0)
        Me.tlp_frame.Controls.Add(Me.btn_confirm, 0, 2)
        Me.tlp_frame.Controls.Add(Me.tlp_confirm, 0, 1)
        Me.tlp_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_frame.Location = New System.Drawing.Point(3, 23)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 3
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.1512!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.8488!))
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp_frame.Size = New System.Drawing.Size(286, 240)
        Me.tlp_frame.TabIndex = 0
        '
        'lb_urleprocess
        '
        Me.lb_urleprocess.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_urleprocess.AutoSize = True
        Me.lb_urleprocess.Location = New System.Drawing.Point(3, 8)
        Me.lb_urleprocess.Name = "lb_urleprocess"
        Me.lb_urleprocess.Size = New System.Drawing.Size(168, 16)
        Me.lb_urleprocess.TabIndex = 1
        Me.lb_urleprocess.Text = "此規則的處理方式為："
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(193, 206)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 2
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'tlp_confirm
        '
        Me.tlp_confirm.ColumnCount = 1
        Me.tlp_confirm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_confirm.Controls.Add(Me.cb_add, 0, 0)
        Me.tlp_confirm.Controls.Add(Me.cb_modifyerror, 0, 1)
        Me.tlp_confirm.Controls.Add(Me.cb_insertanother, 0, 2)
        Me.tlp_confirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_confirm.Location = New System.Drawing.Point(3, 35)
        Me.tlp_confirm.Name = "tlp_confirm"
        Me.tlp_confirm.RowCount = 3
        Me.tlp_confirm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tlp_confirm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tlp_confirm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.tlp_confirm.Size = New System.Drawing.Size(280, 161)
        Me.tlp_confirm.TabIndex = 3
        '
        'cb_add
        '
        Me.cb_add.AutoSize = True
        Me.cb_add.Location = New System.Drawing.Point(3, 3)
        Me.cb_add.Name = "cb_add"
        Me.cb_add.Size = New System.Drawing.Size(155, 20)
        Me.cb_add.TabIndex = 0
        Me.cb_add.Text = "1:.我要建立新規則"
        Me.cb_add.UseVisualStyleBackColor = True
        '
        'cb_modifyerror
        '
        Me.cb_modifyerror.AutoSize = True
        Me.cb_modifyerror.Location = New System.Drawing.Point(3, 56)
        Me.cb_modifyerror.Name = "cb_modifyerror"
        Me.cb_modifyerror.Size = New System.Drawing.Size(219, 20)
        Me.cb_modifyerror.TabIndex = 1
        Me.cb_modifyerror.Text = "2:.只是修正現行規則的錯誤"
        Me.cb_modifyerror.UseVisualStyleBackColor = True
        '
        'cb_insertanother
        '
        Me.cb_insertanother.AutoSize = True
        Me.cb_insertanother.Location = New System.Drawing.Point(3, 109)
        Me.cb_insertanother.Name = "cb_insertanother"
        Me.cb_insertanother.Size = New System.Drawing.Size(227, 20)
        Me.cb_insertanother.TabIndex = 2
        Me.cb_insertanother.Text = "3. 調整目前規則,增加新版本."
        Me.cb_insertanother.UseVisualStyleBackColor = True
        '
        'PUBRuleConfirmQuestionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBRuleConfirmQuestionUI"
        Me.TabText = "確認規則"
        Me.Text = "確認規則"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.tlp_frame.PerformLayout()
        Me.tlp_confirm.ResumeLayout(False)
        Me.tlp_confirm.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_urleprocess As System.Windows.Forms.Label
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents tlp_confirm As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_add As System.Windows.Forms.CheckBox
    Friend WithEvents cb_modifyerror As System.Windows.Forms.CheckBox
    Friend WithEvents cb_insertanother As System.Windows.Forms.CheckBox
End Class
