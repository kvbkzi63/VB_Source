<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclExportUI
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ucl_report = New Syscom.Client.UCL.UCLExportListUC()
        Me.SuspendLayout()
        '
        'ucl_report
        '
        Me.ucl_report.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucl_report.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ucl_report.Location = New System.Drawing.Point(0, 0)
        Me.ucl_report.Margin = New System.Windows.Forms.Padding(4)
        Me.ucl_report.Name = "ucl_report"
        Me.ucl_report.Size = New System.Drawing.Size(964, 641)
        Me.ucl_report.TabIndex = 0
        '
        'UclExportUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.ucl_report)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "UclExportUI"
        Me.TabText = "UclExportUI"
        Me.Text = "UclExportUI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucl_report As Syscom.Client.UCL.UCLExportListUC
End Class
