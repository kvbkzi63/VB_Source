<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLPopMemoUI
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel
        Me.ucl_txt_content = New Syscom.Client.ucl.UCLTextBoxUC
        Me.btn_pop = New System.Windows.Forms.Button
        Me.tlp_parent.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 2
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlp_parent.Controls.Add(Me.ucl_txt_content, 0, 0)
        Me.tlp_parent.Controls.Add(Me.btn_pop, 1, 0)
        Me.tlp_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_parent.Location = New System.Drawing.Point(0, 0)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 1
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(100, 27)
        Me.tlp_parent.TabIndex = 0
        '
        'ucl_txt_content
        '
        Me.ucl_txt_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_txt_content.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucl_txt_content.Location = New System.Drawing.Point(0, 0)
        Me.ucl_txt_content.Margin = New System.Windows.Forms.Padding(0)
        Me.ucl_txt_content.MaxLength = 10
        Me.ucl_txt_content.Name = "ucl_txt_content"
        Me.ucl_txt_content.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucl_txt_content.SelectionStart = 0
        Me.ucl_txt_content.Size = New System.Drawing.Size(73, 27)
        Me.ucl_txt_content.TabIndex = 0
        Me.ucl_txt_content.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucl_txt_content.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucl_txt_content.uclDollarSign = False
        Me.ucl_txt_content.uclDotCount = 0
        Me.ucl_txt_content.uclIntCount = 2
        Me.ucl_txt_content.uclMinus = False
        Me.ucl_txt_content.uclReadOnly = False
        Me.ucl_txt_content.uclTextType = Syscom.Client.ucl.UCLTextBoxUC.uclTextTypeData.Any_Type
        '
        'btn_pop
        '
        Me.btn_pop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_pop.Location = New System.Drawing.Point(73, 0)
        Me.btn_pop.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_pop.Name = "btn_pop"
        Me.btn_pop.Size = New System.Drawing.Size(27, 27)
        Me.btn_pop.TabIndex = 1
        Me.btn_pop.Text = "..."
        Me.btn_pop.UseVisualStyleBackColor = True
        '
        'UCLPopMemoUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlp_parent)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UCLPopMemoUC"
        Me.Size = New System.Drawing.Size(100, 27)
        Me.tlp_parent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucl_txt_content As Syscom.Client.ucl.UCLTextBoxUC
    Friend WithEvents btn_pop As System.Windows.Forms.Button

End Class
