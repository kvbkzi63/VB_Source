<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclTimeIntervalUC
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.dtp_Start = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_StartTime = New System.Windows.Forms.TextBox()
        Me.lbl_between = New System.Windows.Forms.Label()
        Me.dtp_End = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_EndTime = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_Start)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_StartTime)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_between)
        Me.FlowLayoutPanel1.Controls.Add(Me.dtp_End)
        Me.FlowLayoutPanel1.Controls.Add(Me.txt_EndTime)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(341, 33)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'dtp_Start
        '
        Me.dtp_Start.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Start.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Start.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtp_Start.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_Start.Location = New System.Drawing.Point(0, 3)
        Me.dtp_Start.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.dtp_Start.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Start.MinDate = New Date(2012, 1, 1, 0, 0, 0, 0)
        Me.dtp_Start.Name = "dtp_Start"
        Me.dtp_Start.Size = New System.Drawing.Size(112, 27)
        Me.dtp_Start.TabIndex = 11
        Me.dtp_Start.uclReadOnly = False
        '
        'txt_StartTime
        '
        Me.txt_StartTime.Location = New System.Drawing.Point(112, 3)
        Me.txt_StartTime.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.txt_StartTime.MaxLength = 4
        Me.txt_StartTime.Name = "txt_StartTime"
        Me.txt_StartTime.Size = New System.Drawing.Size(43, 27)
        Me.txt_StartTime.TabIndex = 14
        '
        'lbl_between
        '
        Me.lbl_between.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_between.AutoSize = True
        Me.lbl_between.Location = New System.Drawing.Point(158, 7)
        Me.lbl_between.Name = "lbl_between"
        Me.lbl_between.Size = New System.Drawing.Size(16, 16)
        Me.lbl_between.TabIndex = 13
        Me.lbl_between.Text = "~"
        '
        'dtp_End
        '
        Me.dtp_End.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_End.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_End.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtp_End.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_End.Location = New System.Drawing.Point(177, 3)
        Me.dtp_End.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.dtp_End.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_End.MinDate = New Date(2012, 1, 1, 0, 0, 0, 0)
        Me.dtp_End.Name = "dtp_End"
        Me.dtp_End.Size = New System.Drawing.Size(112, 27)
        Me.dtp_End.TabIndex = 12
        Me.dtp_End.uclReadOnly = False
        '
        'txt_EndTime
        '
        Me.txt_EndTime.Location = New System.Drawing.Point(289, 3)
        Me.txt_EndTime.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.txt_EndTime.MaxLength = 4
        Me.txt_EndTime.Name = "txt_EndTime"
        Me.txt_EndTime.Size = New System.Drawing.Size(43, 27)
        Me.txt_EndTime.TabIndex = 15
        '
        'UclTimeIntervalUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UclTimeIntervalUC"
        Me.Size = New System.Drawing.Size(358, 42)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dtp_Start As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_StartTime As System.Windows.Forms.TextBox
    Friend WithEvents lbl_between As System.Windows.Forms.Label
    Friend WithEvents dtp_End As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_EndTime As System.Windows.Forms.TextBox

End Class
