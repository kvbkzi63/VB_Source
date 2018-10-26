<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLHorizontalDataGridViewUC
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
        Me.tlpGridData = New System.Windows.Forms.TableLayoutPanel
        Me.SuspendLayout()
        '
        'tlpGridData
        '
        Me.tlpGridData.AutoSize = True
        Me.tlpGridData.ColumnCount = 1
        Me.tlpGridData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpGridData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGridData.Location = New System.Drawing.Point(0, 0)
        Me.tlpGridData.Name = "tlpGridData"
        Me.tlpGridData.RowCount = 1
        Me.tlpGridData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGridData.Size = New System.Drawing.Size(315, 364)
        Me.tlpGridData.TabIndex = 0
        '
        'UCLHorizontalDataGridViewUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.tlpGridData)
        Me.Name = "UCLHorizontalDataGridViewUI"
        Me.Size = New System.Drawing.Size(315, 364)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpGridData As System.Windows.Forms.TableLayoutPanel

End Class
