<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayMsgDialog
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Create_Users = New System.Windows.Forms.TextBox()
        Me.txt_Type = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Start_Times = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Subjects = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MsgBodys = New System.Windows.Forms.RichTextBox()
        Me.Types = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.End_Times = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SendDates = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MIDs = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_ReplayMsg = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_ReplayMsg = New System.Windows.Forms.Button()
        Me.grp_ReplayMSG = New System.Windows.Forms.GroupBox()
        Me.cbo_Phrase = New System.Windows.Forms.ComboBox()
        Me.grp_Phrase = New System.Windows.Forms.GroupBox()
        Me.grp_ReplayMSG.SuspendLayout()
        Me.grp_Phrase.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(616, 292)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(103, 36)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "關閉"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(456, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "發送者："
        '
        'Create_Users
        '
        Me.Create_Users.Location = New System.Drawing.Point(533, 8)
        Me.Create_Users.Margin = New System.Windows.Forms.Padding(4)
        Me.Create_Users.Name = "Create_Users"
        Me.Create_Users.ReadOnly = True
        Me.Create_Users.Size = New System.Drawing.Size(146, 27)
        Me.Create_Users.TabIndex = 2
        '
        'txt_Type
        '
        Me.txt_Type.Location = New System.Drawing.Point(298, 8)
        Me.txt_Type.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Type.Name = "txt_Type"
        Me.txt_Type.ReadOnly = True
        Me.txt_Type.Size = New System.Drawing.Size(150, 27)
        Me.txt_Type.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "型態："
        '
        'Start_Times
        '
        Me.Start_Times.Location = New System.Drawing.Point(148, 92)
        Me.Start_Times.Margin = New System.Windows.Forms.Padding(4)
        Me.Start_Times.Name = "Start_Times"
        Me.Start_Times.ReadOnly = True
        Me.Start_Times.Size = New System.Drawing.Size(196, 27)
        Me.Start_Times.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "啟用日期/時間："
        '
        'Subjects
        '
        Me.Subjects.Location = New System.Drawing.Point(102, 135)
        Me.Subjects.Margin = New System.Windows.Forms.Padding(4)
        Me.Subjects.Name = "Subjects"
        Me.Subjects.ReadOnly = True
        Me.Subjects.Size = New System.Drawing.Size(577, 27)
        Me.Subjects.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 139)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "主旨："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 189)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "內容"
        '
        'MsgBodys
        '
        Me.MsgBodys.Location = New System.Drawing.Point(98, 185)
        Me.MsgBodys.Margin = New System.Windows.Forms.Padding(4)
        Me.MsgBodys.Name = "MsgBodys"
        Me.MsgBodys.ReadOnly = True
        Me.MsgBodys.Size = New System.Drawing.Size(510, 143)
        Me.MsgBodys.TabIndex = 10
        Me.MsgBodys.Text = ""
        '
        'Types
        '
        Me.Types.Location = New System.Drawing.Point(533, 52)
        Me.Types.Margin = New System.Windows.Forms.Padding(4)
        Me.Types.Name = "Types"
        Me.Types.ReadOnly = True
        Me.Types.Size = New System.Drawing.Size(146, 27)
        Me.Types.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(471, 56)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "類別："
        '
        'End_Times
        '
        Me.End_Times.Location = New System.Drawing.Point(533, 92)
        Me.End_Times.Margin = New System.Windows.Forms.Padding(4)
        Me.End_Times.Name = "End_Times"
        Me.End_Times.ReadOnly = True
        Me.End_Times.Size = New System.Drawing.Size(146, 27)
        Me.End_Times.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(402, 96)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "截止日期/時間："
        '
        'SendDates
        '
        Me.SendDates.Location = New System.Drawing.Point(148, 52)
        Me.SendDates.Margin = New System.Windows.Forms.Padding(4)
        Me.SendDates.Name = "SendDates"
        Me.SendDates.ReadOnly = True
        Me.SendDates.Size = New System.Drawing.Size(196, 27)
        Me.SendDates.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 56)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "發送日期/時間："
        '
        'MIDs
        '
        Me.MIDs.Location = New System.Drawing.Point(102, 8)
        Me.MIDs.Margin = New System.Windows.Forms.Padding(4)
        Me.MIDs.Name = "MIDs"
        Me.MIDs.ReadOnly = True
        Me.MIDs.Size = New System.Drawing.Size(134, 27)
        Me.MIDs.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 12)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "訊息編號："
        '
        'txt_ReplayMsg
        '
        Me.txt_ReplayMsg.Location = New System.Drawing.Point(79, 18)
        Me.txt_ReplayMsg.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ReplayMsg.Multiline = True
        Me.txt_ReplayMsg.Name = "txt_ReplayMsg"
        Me.txt_ReplayMsg.Size = New System.Drawing.Size(517, 168)
        Me.txt_ReplayMsg.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 30)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "回覆內容"
        '
        'btn_ReplayMsg
        '
        Me.btn_ReplayMsg.Location = New System.Drawing.Point(604, 151)
        Me.btn_ReplayMsg.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_ReplayMsg.Name = "btn_ReplayMsg"
        Me.btn_ReplayMsg.Size = New System.Drawing.Size(96, 35)
        Me.btn_ReplayMsg.TabIndex = 21
        Me.btn_ReplayMsg.Text = "回覆確認"
        Me.btn_ReplayMsg.UseVisualStyleBackColor = True
        '
        'grp_ReplayMSG
        '
        Me.grp_ReplayMSG.Controls.Add(Me.txt_ReplayMsg)
        Me.grp_ReplayMSG.Controls.Add(Me.Label10)
        Me.grp_ReplayMSG.Controls.Add(Me.btn_ReplayMsg)
        Me.grp_ReplayMSG.Location = New System.Drawing.Point(12, 374)
        Me.grp_ReplayMSG.Name = "grp_ReplayMSG"
        Me.grp_ReplayMSG.Size = New System.Drawing.Size(707, 180)
        Me.grp_ReplayMSG.TabIndex = 23
        Me.grp_ReplayMSG.TabStop = False
        Me.grp_ReplayMSG.Text = "GroupBox1"
        '
        'cbo_Phrase
        '
        Me.cbo_Phrase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Phrase.FormattingEnabled = True
        Me.cbo_Phrase.Location = New System.Drawing.Point(85, 15)
        Me.cbo_Phrase.Name = "cbo_Phrase"
        Me.cbo_Phrase.Size = New System.Drawing.Size(511, 24)
        Me.cbo_Phrase.TabIndex = 24
        '
        'grp_Phrase
        '
        Me.grp_Phrase.Controls.Add(Me.cbo_Phrase)
        Me.grp_Phrase.Location = New System.Drawing.Point(12, 329)
        Me.grp_Phrase.Name = "grp_Phrase"
        Me.grp_Phrase.Size = New System.Drawing.Size(601, 45)
        Me.grp_Phrase.TabIndex = 22
        Me.grp_Phrase.TabStop = False
        Me.grp_Phrase.Text = "常用片語"
        '
        'DisplayMsgDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(729, 566)
        Me.Controls.Add(Me.grp_Phrase)
        Me.Controls.Add(Me.grp_ReplayMSG)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.MIDs)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SendDates)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.End_Times)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Types)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.MsgBodys)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Subjects)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Start_Times)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Type)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Create_Users)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DisplayMsgDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "訊息詳細內容"
        Me.grp_ReplayMSG.ResumeLayout(False)
        Me.grp_ReplayMSG.PerformLayout()
        Me.grp_Phrase.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Create_Users As System.Windows.Forms.TextBox
    Friend WithEvents txt_Type As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Start_Times As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Subjects As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MsgBodys As System.Windows.Forms.RichTextBox
    Friend WithEvents Types As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents End_Times As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SendDates As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MIDs As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_ReplayMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_ReplayMsg As System.Windows.Forms.Button
    Friend WithEvents grp_ReplayMSG As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_Phrase As System.Windows.Forms.ComboBox
    Friend WithEvents grp_Phrase As System.Windows.Forms.GroupBox

End Class
