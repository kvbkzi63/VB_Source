<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLPatientInfoUISample
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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
        Me.UclPatientInfoUI1 = New Syscom.Client.ucl.UCLPatientInfoUI
        Me.UclPatientContactUI1 = New Syscom.Client.ucl.UCLPatientContactUI
        Me.SuspendLayout()
        '
        'UclPatientInfoUI1
        '
        Me.UclPatientInfoUI1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.UclPatientInfoUI1.Location = New System.Drawing.Point(-3, 0)
        Me.UclPatientInfoUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclPatientInfoUI1.Name = "UclPatientInfoUI1"
        Me.UclPatientInfoUI1.Size = New System.Drawing.Size(1010, 90)
        Me.UclPatientInfoUI1.TabIndex = 0
        Me.UclPatientInfoUI1.uclIsShowTelAndAddr = True
        '
        'UclPatientContactUI1
        '
        Me.UclPatientContactUI1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.UclPatientContactUI1.Location = New System.Drawing.Point(0, 89)
        Me.UclPatientContactUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclPatientContactUI1.Name = "UclPatientContactUI1"
        Me.UclPatientContactUI1.Size = New System.Drawing.Size(1515, 61)
        Me.UclPatientContactUI1.TabIndex = 1
        '
        'UCLPatientInfoUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 429)
        Me.Controls.Add(Me.UclPatientContactUI1)
        Me.Controls.Add(Me.UclPatientInfoUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLPatientInfoUISample"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UclPatientInfoUI1 As Syscom.Client.ucl.UCLPatientInfoUI
    Friend WithEvents UclPatientContactUI1 As Syscom.Client.ucl.UCLPatientContactUI

End Class
