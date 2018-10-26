<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLDatrTimePickerWithTimeUC
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
        Me.dtp_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_Time = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'dtp_Date
        '
        Me.dtp_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Date.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_Date.Location = New System.Drawing.Point(3, 3)
        Me.dtp_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Date.MinDate = New Date(2012, 1, 1, 0, 0, 0, 0)
        Me.dtp_Date.Name = "dtp_Date"
        Me.dtp_Date.Size = New System.Drawing.Size(112, 27)
        Me.dtp_Date.TabIndex = 15
        Me.dtp_Date.uclReadOnly = False
        '
        'txt_Time
        '
        Me.txt_Time.Location = New System.Drawing.Point(121, 3)
        Me.txt_Time.MaxLength = 4
        Me.txt_Time.Name = "txt_Time"
        Me.txt_Time.Size = New System.Drawing.Size(43, 27)
        Me.txt_Time.TabIndex = 16
        '
        'UCLDatrTimePickerWithTimeUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.dtp_Date)
        Me.Controls.Add(Me.txt_Time)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLDatrTimePickerWithTimeUC"
        Me.Size = New System.Drawing.Size(167, 33)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_Date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_Time As System.Windows.Forms.TextBox

End Class
