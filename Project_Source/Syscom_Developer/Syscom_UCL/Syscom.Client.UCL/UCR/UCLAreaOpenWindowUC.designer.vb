<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLAreaOpenWindowUC
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            mgr = Nothing
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
        Me.TreeView_Area = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'TreeView_Area
        '
        Me.TreeView_Area.Dock = System.Windows.Forms.DockStyle.Top
        Me.TreeView_Area.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TreeView_Area.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Area.Name = "TreeView_Area"
        Me.TreeView_Area.Size = New System.Drawing.Size(228, 339)
        Me.TreeView_Area.TabIndex = 0
        '
        'UCLAreaOpenWindowUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(228, 339)
        Me.Controls.Add(Me.TreeView_Area)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UCLAreaOpenWindowUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "戶籍地查詢"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView_Area As System.Windows.Forms.TreeView
End Class
