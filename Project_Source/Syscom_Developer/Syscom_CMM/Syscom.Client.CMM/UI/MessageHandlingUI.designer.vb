<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageHandlingUI
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btn_DetailMsg = New System.Windows.Forms.Button
        Me.btn_Confirm = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tbp_Msg = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.lbl_Info_Error = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.tbp_Info = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.lbl_Mail_Title = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lbl_Mail_Reciever = New System.Windows.Forms.Label
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox
        Me.lbl_Content = New System.Windows.Forms.Label
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbp_Msg.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_Info.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Syscom.Client.CMM.My.Resources.Resources.Expand_Window
        Me.PictureBox1.Location = New System.Drawing.Point(8, 167)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Syscom.Client.CMM.My.Resources.Resources.Close_Window
        Me.PictureBox2.Location = New System.Drawing.Point(9, 167)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'btn_DetailMsg
        '
        Me.btn_DetailMsg.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_DetailMsg.Location = New System.Drawing.Point(3, 160)
        Me.btn_DetailMsg.Name = "btn_DetailMsg"
        Me.btn_DetailMsg.Size = New System.Drawing.Size(102, 30)
        Me.btn_DetailMsg.TabIndex = 5
        Me.btn_DetailMsg.Text = "     詳細錯誤"
        Me.btn_DetailMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_DetailMsg.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn_Confirm.Location = New System.Drawing.Point(270, 160)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(80, 30)
        Me.btn_Confirm.TabIndex = 6
        Me.btn_Confirm.Text = "F12-確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbp_Msg)
        Me.TabControl1.Controls.Add(Me.tbp_Info)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(6, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(343, 151)
        Me.TabControl1.TabIndex = 7
        '
        'tbp_Msg
        '
        Me.tbp_Msg.Controls.Add(Me.Panel1)
        Me.tbp_Msg.Location = New System.Drawing.Point(4, 26)
        Me.tbp_Msg.Name = "tbp_Msg"
        Me.tbp_Msg.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Msg.Size = New System.Drawing.Size(335, 121)
        Me.tbp_Msg.TabIndex = 0
        Me.tbp_Msg.Text = "訊息"
        Me.tbp_Msg.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.lbl_Info_Error)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(339, 121)
        Me.Panel1.TabIndex = 0
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.LightGray
        Me.RichTextBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(4, 32)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(329, 86)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'lbl_Info_Error
        '
        Me.lbl_Info_Error.AutoSize = True
        Me.lbl_Info_Error.Location = New System.Drawing.Point(36, 9)
        Me.lbl_Info_Error.Name = "lbl_Info_Error"
        Me.lbl_Info_Error.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Info_Error.TabIndex = 7
        Me.lbl_Info_Error.Text = "錯誤"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Syscom.Client.CMM.My.Resources.Resources.ProgressInfo
        Me.PictureBox3.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(28, 26)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'tbp_Info
        '
        Me.tbp_Info.Controls.Add(Me.Panel2)
        Me.tbp_Info.Location = New System.Drawing.Point(4, 26)
        Me.tbp_Info.Name = "tbp_Info"
        Me.tbp_Info.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Info.Size = New System.Drawing.Size(335, 121)
        Me.tbp_Info.TabIndex = 1
        Me.tbp_Info.Text = "通知 "
        Me.tbp_Info.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.lbl_Mail_Title)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.lbl_Mail_Reciever)
        Me.Panel2.Location = New System.Drawing.Point(-2, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(339, 121)
        Me.Panel2.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(72, 43)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(259, 72)
        Me.TextBox2.TabIndex = 13
        '
        'lbl_Mail_Title
        '
        Me.lbl_Mail_Title.AutoSize = True
        Me.lbl_Mail_Title.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_Mail_Title.Location = New System.Drawing.Point(6, 43)
        Me.lbl_Mail_Title.Name = "lbl_Mail_Title"
        Me.lbl_Mail_Title.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Mail_Title.TabIndex = 12
        Me.lbl_Mail_Title.Text = "主    旨："
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(72, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(259, 23)
        Me.TextBox1.TabIndex = 11
        '
        'lbl_Mail_Reciever
        '
        Me.lbl_Mail_Reciever.AutoSize = True
        Me.lbl_Mail_Reciever.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_Mail_Reciever.Location = New System.Drawing.Point(6, 12)
        Me.lbl_Mail_Reciever.Name = "lbl_Mail_Reciever"
        Me.lbl_Mail_Reciever.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Mail_Reciever.TabIndex = 10
        Me.lbl_Mail_Reciever.Text = "收件者："
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.LightGray
        Me.RichTextBox2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox2.Location = New System.Drawing.Point(3, 196)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox2.Size = New System.Drawing.Size(345, 227)
        Me.RichTextBox2.TabIndex = 8
        Me.RichTextBox2.Text = ""
        '
        'lbl_Content
        '
        Me.lbl_Content.AutoSize = True
        Me.lbl_Content.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_Content.Location = New System.Drawing.Point(3, 167)
        Me.lbl_Content.Name = "lbl_Content"
        Me.lbl_Content.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Content.TabIndex = 9
        Me.lbl_Content.Text = "內容"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.Color.White
        Me.RichTextBox3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RichTextBox3.Location = New System.Drawing.Point(3, 197)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox3.Size = New System.Drawing.Size(345, 227)
        Me.RichTextBox3.TabIndex = 10
        Me.RichTextBox3.Text = ""
        '
        'MessageHandlingUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 462)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.lbl_Content)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_Confirm)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_DetailMsg)
        Me.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Location = New System.Drawing.Point(380, 200)
        Me.Name = "MessageHandlingUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "錯誤編號：W-000001"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbp_Msg.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_Info.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_DetailMsg As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbp_Msg As System.Windows.Forms.TabPage
    Friend WithEvents tbp_Info As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Info_Error As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Content As System.Windows.Forms.Label
    Friend WithEvents lbl_Mail_Title As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Mail_Reciever As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
End Class
