<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobExtensionDialogUI
    Inherits System.Windows.Forms.Form

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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtp_NewDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "展延至"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(197, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "確定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtp_NewDate
        '
        Me.dtp_NewDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_NewDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_NewDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_NewDate.Location = New System.Drawing.Point(67, 36)
        Me.dtp_NewDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_NewDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_NewDate.Name = "dtp_NewDate"
        Me.dtp_NewDate.Size = New System.Drawing.Size(124, 27)
        Me.dtp_NewDate.TabIndex = 3
        Me.dtp_NewDate.uclIsFixedBackColor = False
        Me.dtp_NewDate.uclReadOnly = False
        '
        'JobExtensionDialogUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 83)
        Me.Controls.Add(Me.dtp_NewDate)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "JobExtensionDialogUI"
        Me.Text = "需求展延"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents dtp_NewDate As Syscom.Client.UCL.UCLDateTimePickerUC
End Class
