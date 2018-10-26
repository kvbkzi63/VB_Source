<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFCModifySendUI
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_StartDate = New System.Windows.Forms.Label()
        Me.lbl_StartTime = New System.Windows.Forms.Label()
        Me.lbl_EndDate = New System.Windows.Forms.Label()
        Me.lbl_EndTime = New System.Windows.Forms.Label()
        Me.lbl_Subject = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.lbl_Msg = New System.Windows.Forms.Label()
        Me.rtb_Msg = New System.Windows.Forms.RichTextBox()
        Me.mtb_StartTime = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_EndTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_GroupTxId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Update = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_StartDate
        '
        Me.lbl_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartDate.AutoSize = True
        Me.lbl_StartDate.Location = New System.Drawing.Point(3, 17)
        Me.lbl_StartDate.Name = "lbl_StartDate"
        Me.lbl_StartDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartDate.TabIndex = 17
        Me.lbl_StartDate.Text = "開始日期"
        '
        'lbl_StartTime
        '
        Me.lbl_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartTime.AutoSize = True
        Me.lbl_StartTime.Location = New System.Drawing.Point(213, 17)
        Me.lbl_StartTime.Name = "lbl_StartTime"
        Me.lbl_StartTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartTime.TabIndex = 18
        Me.lbl_StartTime.Text = "開始時間"
        '
        'lbl_EndDate
        '
        Me.lbl_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndDate.AutoSize = True
        Me.lbl_EndDate.Location = New System.Drawing.Point(3, 59)
        Me.lbl_EndDate.Name = "lbl_EndDate"
        Me.lbl_EndDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndDate.TabIndex = 20
        Me.lbl_EndDate.Text = "結束日期"
        '
        'lbl_EndTime
        '
        Me.lbl_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndTime.AutoSize = True
        Me.lbl_EndTime.Location = New System.Drawing.Point(213, 59)
        Me.lbl_EndTime.Name = "lbl_EndTime"
        Me.lbl_EndTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndTime.TabIndex = 22
        Me.lbl_EndTime.Text = "結束時間"
        '
        'lbl_Subject
        '
        Me.lbl_Subject.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Subject.AutoSize = True
        Me.lbl_Subject.Location = New System.Drawing.Point(35, 97)
        Me.lbl_Subject.Name = "lbl_Subject"
        Me.lbl_Subject.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Subject.TabIndex = 24
        Me.lbl_Subject.Text = "主旨"
        '
        'txt_Subject
        '
        Me.txt_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Subject.BackColor = System.Drawing.Color.White
        Me.txt_Subject.Location = New System.Drawing.Point(81, 93)
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.Size = New System.Drawing.Size(779, 27)
        Me.txt_Subject.TabIndex = 25
        '
        'lbl_Msg
        '
        Me.lbl_Msg.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Msg.AutoSize = True
        Me.lbl_Msg.Location = New System.Drawing.Point(35, 191)
        Me.lbl_Msg.Name = "lbl_Msg"
        Me.lbl_Msg.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Msg.TabIndex = 26
        Me.lbl_Msg.Text = "訊息"
        '
        'rtb_Msg
        '
        Me.rtb_Msg.BackColor = System.Drawing.Color.White
        Me.rtb_Msg.Location = New System.Drawing.Point(81, 141)
        Me.rtb_Msg.Name = "rtb_Msg"
        Me.rtb_Msg.Size = New System.Drawing.Size(793, 164)
        Me.rtb_Msg.TabIndex = 27
        Me.rtb_Msg.Text = ""
        '
        'mtb_StartTime
        '
        Me.mtb_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_StartTime.BackColor = System.Drawing.Color.White
        Me.mtb_StartTime.Location = New System.Drawing.Point(291, 11)
        Me.mtb_StartTime.Mask = "90:00"
        Me.mtb_StartTime.Name = "mtb_StartTime"
        Me.mtb_StartTime.Size = New System.Drawing.Size(100, 27)
        Me.mtb_StartTime.TabIndex = 19
        Me.mtb_StartTime.ValidatingType = GetType(Date)
        '
        'mtb_EndTime
        '
        Me.mtb_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_EndTime.BackColor = System.Drawing.Color.White
        Me.mtb_EndTime.Location = New System.Drawing.Point(291, 53)
        Me.mtb_EndTime.Mask = "90:00"
        Me.mtb_EndTime.Name = "mtb_EndTime"
        Me.mtb_EndTime.Size = New System.Drawing.Size(100, 27)
        Me.mtb_EndTime.TabIndex = 23
        Me.mtb_EndTime.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(397, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "(請輸入00:00~23:59)"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(397, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "(請輸入00:00~23:59)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(81, 11)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(126, 27)
        Me.dtp_StartDate.TabIndex = 16
        Me.dtp_StartDate.uclReadOnly = False
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(81, 53)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(126, 27)
        Me.dtp_EndDate.TabIndex = 21
        Me.dtp_EndDate.uclReadOnly = False
        '
        'txt_GroupTxId
        '
        Me.txt_GroupTxId.Location = New System.Drawing.Point(642, 11)
        Me.txt_GroupTxId.Name = "txt_GroupTxId"
        Me.txt_GroupTxId.ReadOnly = True
        Me.txt_GroupTxId.Size = New System.Drawing.Size(183, 27)
        Me.txt_GroupTxId.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(583, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "識別碼"
        '
        'btn_Update
        '
        Me.btn_Update.Location = New System.Drawing.Point(375, 326)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(75, 24)
        Me.btn_Update.TabIndex = 32
        Me.btn_Update.Text = "修改"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(460, 325)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 24)
        Me.btn_Delete.TabIndex = 33
        Me.btn_Delete.Text = "刪除"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(549, 325)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 24)
        Me.btn_Cancel.TabIndex = 34
        Me.btn_Cancel.Text = "取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'NFCModifySendUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 361)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Update)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_GroupTxId)
        Me.Controls.Add(Me.dtp_StartDate)
        Me.Controls.Add(Me.lbl_StartDate)
        Me.Controls.Add(Me.lbl_StartTime)
        Me.Controls.Add(Me.lbl_EndDate)
        Me.Controls.Add(Me.dtp_EndDate)
        Me.Controls.Add(Me.lbl_EndTime)
        Me.Controls.Add(Me.lbl_Subject)
        Me.Controls.Add(Me.txt_Subject)
        Me.Controls.Add(Me.lbl_Msg)
        Me.Controls.Add(Me.rtb_Msg)
        Me.Controls.Add(Me.mtb_StartTime)
        Me.Controls.Add(Me.mtb_EndTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NFCModifySendUI"
        Me.Text = "NFCModifySendUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_StartDate As System.Windows.Forms.Label
    Friend WithEvents lbl_StartTime As System.Windows.Forms.Label
    Friend WithEvents lbl_EndDate As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_EndTime As System.Windows.Forms.Label
    Friend WithEvents lbl_Subject As System.Windows.Forms.Label
    Friend WithEvents txt_Subject As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Msg As System.Windows.Forms.Label
    Friend WithEvents rtb_Msg As System.Windows.Forms.RichTextBox
    Friend WithEvents mtb_StartTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_EndTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_GroupTxId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Update As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
