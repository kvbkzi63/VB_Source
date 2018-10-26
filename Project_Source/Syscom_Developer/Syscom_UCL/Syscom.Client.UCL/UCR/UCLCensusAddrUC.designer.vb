<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLCensusAddrUC
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
    Public components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cbo_Postal = New System.Windows.Forms.ComboBox
        Me.Txt_Address = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Cbo_Postal
        '
        Me.Cbo_Postal.Dock = System.Windows.Forms.DockStyle.Left
        Me.Cbo_Postal.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cbo_Postal.FormattingEnabled = True
        Me.Cbo_Postal.Location = New System.Drawing.Point(0, 0)
        Me.Cbo_Postal.Margin = New System.Windows.Forms.Padding(4)
        Me.Cbo_Postal.Name = "Cbo_Postal"
        Me.Cbo_Postal.Size = New System.Drawing.Size(206, 24)
        Me.Cbo_Postal.TabIndex = 0
        '
        'Txt_Address
        '
        Me.Txt_Address.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Txt_Address.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Txt_Address.Location = New System.Drawing.Point(206, 0)
        Me.Txt_Address.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_Address.Name = "Txt_Address"
        Me.Txt_Address.Size = New System.Drawing.Size(216, 27)
        Me.Txt_Address.TabIndex = 1
        '
        'UCLCensusAddrUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Txt_Address)
        Me.Controls.Add(Me.Cbo_Postal)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLCensusAddrUI"
        Me.Size = New System.Drawing.Size(422, 26)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cbo_Postal As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Address As System.Windows.Forms.TextBox

End Class
