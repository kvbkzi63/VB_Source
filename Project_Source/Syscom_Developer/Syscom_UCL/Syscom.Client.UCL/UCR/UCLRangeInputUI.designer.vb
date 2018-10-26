<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLRangeInputUI
    Inherits Syscom.Client.UCL.BaseFormUI
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
        Me.gb_parent = New System.Windows.Forms.GroupBox()
        Me.tlp_frame = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_conditionmsg = New System.Windows.Forms.Label()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.ucl_rbt_range = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.gb_parent.SuspendLayout()
        Me.tlp_frame.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_frame)
        Me.gb_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_parent.Location = New System.Drawing.Point(0, 0)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(445, 383)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_frame
        '
        Me.tlp_frame.ColumnCount = 1
        Me.tlp_frame.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_frame.Controls.Add(Me.lb_conditionmsg, 0, 0)
        Me.tlp_frame.Controls.Add(Me.btn_confirm, 0, 2)
        Me.tlp_frame.Controls.Add(Me.ucl_rbt_range, 0, 1)
        Me.tlp_frame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_frame.Location = New System.Drawing.Point(3, 23)
        Me.tlp_frame.Name = "tlp_frame"
        Me.tlp_frame.RowCount = 3
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_frame.Size = New System.Drawing.Size(439, 357)
        Me.tlp_frame.TabIndex = 0
        '
        'lb_conditionmsg
        '
        Me.lb_conditionmsg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lb_conditionmsg.AutoSize = True
        Me.lb_conditionmsg.Location = New System.Drawing.Point(3, 0)
        Me.lb_conditionmsg.Name = "lb_conditionmsg"
        Me.lb_conditionmsg.Size = New System.Drawing.Size(0, 16)
        Me.lb_conditionmsg.TabIndex = 1
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(346, 243)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(90, 27)
        Me.btn_confirm.TabIndex = 2
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'ucl_rbt_range
        '
        Me.ucl_rbt_range.Location = New System.Drawing.Point(4, 20)
        Me.ucl_rbt_range.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_rbt_range.Name = "ucl_rbt_range"
        Me.ucl_rbt_range.Size = New System.Drawing.Size(423, 132)
        Me.ucl_rbt_range.TabIndex = 3
        Me.ucl_rbt_range.uclMaxLength = 32767
        Me.ucl_rbt_range.uclReadOnly = False
        Me.ucl_rbt_range.uclWordWrap = True
        '
        'UCLRangeInputUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 383)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "UCLRangeInputUI"
        Me.TabText = "範圍值域輸入"
        Me.Text = "範圍值域輸入"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_frame.ResumeLayout(False)
        Me.tlp_frame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_frame As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_conditionmsg As System.Windows.Forms.Label
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents ucl_rbt_range As Syscom.Client.ucl.UCLRichTextBoxUC
End Class
