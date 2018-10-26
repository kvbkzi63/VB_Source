<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLExcelImportUC
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_Import = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_Import
        '
        Me.Btn_Import.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Btn_Import.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Import.Name = "Btn_Import"
        Me.Btn_Import.Size = New System.Drawing.Size(95, 28)
        Me.Btn_Import.TabIndex = 0
        Me.Btn_Import.Text = "F2-匯入"
        Me.Btn_Import.UseVisualStyleBackColor = True
        '
        'UCLExcelImportUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Btn_Import)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLExcelImportUC"
        Me.Size = New System.Drawing.Size(95, 28)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Import As System.Windows.Forms.Button

End Class
