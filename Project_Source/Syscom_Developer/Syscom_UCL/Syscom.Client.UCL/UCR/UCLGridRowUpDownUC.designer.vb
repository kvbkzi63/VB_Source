<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLGridRowUpDownUC
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
        Me.btn_Up = New System.Windows.Forms.Button()
        Me.btn_Down = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Up
        '
        Me.btn_Up.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Up.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Up.Location = New System.Drawing.Point(0, 0)
        Me.btn_Up.Name = "btn_Up"
        Me.btn_Up.Size = New System.Drawing.Size(46, 41)
        Me.btn_Up.TabIndex = 0
        Me.btn_Up.Text = "︽"
        Me.btn_Up.UseVisualStyleBackColor = True
        '
        'btn_Down
        '
        Me.btn_Down.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_Down.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Down.Location = New System.Drawing.Point(0, 71)
        Me.btn_Down.Name = "btn_Down"
        Me.btn_Down.Size = New System.Drawing.Size(46, 41)
        Me.btn_Down.TabIndex = 1
        Me.btn_Down.Text = "︾"
        Me.btn_Down.UseVisualStyleBackColor = True
        '
        'UCLGridRowUpDownUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btn_Down)
        Me.Controls.Add(Me.btn_Up)
        Me.Name = "UCLGridRowUpDownUC"
        Me.Size = New System.Drawing.Size(46, 112)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Up As System.Windows.Forms.Button
    Friend WithEvents btn_Down As System.Windows.Forms.Button

End Class
