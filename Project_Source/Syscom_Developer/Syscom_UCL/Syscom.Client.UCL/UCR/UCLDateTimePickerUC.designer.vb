<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLDateTimePickerUC
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
    Public Sub InitializeComponent()
        Me.baseDTP = New System.Windows.Forms.DateTimePicker()
        Me.baseMTB = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'baseDTP
        '
        Me.baseDTP.CalendarForeColor = System.Drawing.SystemColors.InfoText
        Me.baseDTP.CustomFormat = " "
        Me.baseDTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.baseDTP.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.baseDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.baseDTP.Location = New System.Drawing.Point(0, 0)
        Me.baseDTP.Name = "baseDTP"
        Me.baseDTP.Size = New System.Drawing.Size(132, 27)
        Me.baseDTP.TabIndex = 0
        '
        'baseMTB
        '
        Me.baseMTB.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.baseMTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.baseMTB.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.baseMTB.Location = New System.Drawing.Point(2, 4)
        Me.baseMTB.Name = "baseMTB"
        Me.baseMTB.Size = New System.Drawing.Size(93, 20)
        Me.baseMTB.TabIndex = 0
        Me.baseMTB.ValidatingType = GetType(Date)
        '
        'UCLDateTimePickerUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.baseMTB)
        Me.Controls.Add(Me.baseDTP)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "UCLDateTimePickerUC"
        Me.Size = New System.Drawing.Size(132, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents baseDTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents baseMTB As System.Windows.Forms.MaskedTextBox

End Class
