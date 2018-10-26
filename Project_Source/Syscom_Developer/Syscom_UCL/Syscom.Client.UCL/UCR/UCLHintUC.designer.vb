<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLHintUC
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
        Me.btn_Query = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_Query
        '
        Me.btn_Query.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Query.Location = New System.Drawing.Point(0, 0)
        Me.btn_Query.Name = "btn_Query"
        Me.btn_Query.Size = New System.Drawing.Size(22, 24)
        Me.btn_Query.TabIndex = 0
        Me.btn_Query.Text = "?"
        Me.btn_Query.UseVisualStyleBackColor = True
        '
        'UCLHintUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btn_Query)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ForeColor = System.Drawing.Color.Green
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLHintUC"
        Me.Size = New System.Drawing.Size(22, 24)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Query As System.Windows.Forms.Button

End Class
