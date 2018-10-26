<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFCDataReader
    Inherits Syscom.Client.UCL.BaseFormUI

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
        Me.components = New System.ComponentModel.Container()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ReloadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.flp_Button = New System.Windows.Forms.FlowLayoutPanel()
        Me.pal_Detail = New System.Windows.Forms.Panel()
        Me.NFCDGV = New System.Windows.Forms.DataGridView()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MsgBody = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Create_User = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flp_Button.SuspendLayout()
        Me.pal_Detail.SuspendLayout()
        CType(Me.NFCDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(4, 43)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(232, 31)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "讀取過期訊息( 三天內)"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(124, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 31)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "即時更新"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReloadTimer
        '
        Me.ReloadTimer.Interval = 1000
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(4, 4)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 31)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "清除畫面"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'flp_Button
        '
        Me.flp_Button.Controls.Add(Me.Button3)
        Me.flp_Button.Controls.Add(Me.Button1)
        Me.flp_Button.Controls.Add(Me.Button2)
        Me.flp_Button.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flp_Button.Location = New System.Drawing.Point(0, 490)
        Me.flp_Button.Name = "flp_Button"
        Me.flp_Button.Size = New System.Drawing.Size(296, 77)
        Me.flp_Button.TabIndex = 6
        '
        'pal_Detail
        '
        Me.pal_Detail.Controls.Add(Me.NFCDGV)
        Me.pal_Detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pal_Detail.Location = New System.Drawing.Point(0, 0)
        Me.pal_Detail.Name = "pal_Detail"
        Me.pal_Detail.Size = New System.Drawing.Size(296, 490)
        Me.pal_Detail.TabIndex = 7
        '
        'NFCDGV
        '
        Me.NFCDGV.AllowUserToAddRows = False
        Me.NFCDGV.AllowUserToDeleteRows = False
        Me.NFCDGV.AllowUserToOrderColumns = True
        Me.NFCDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.NFCDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type, Me.Column1, Me.Subject, Me.MsgBody, Me.MID, Me.SendDate, Me.Create_User})
        Me.NFCDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NFCDGV.Location = New System.Drawing.Point(0, 0)
        Me.NFCDGV.Margin = New System.Windows.Forms.Padding(4)
        Me.NFCDGV.MultiSelect = False
        Me.NFCDGV.Name = "NFCDGV"
        Me.NFCDGV.ReadOnly = True
        Me.NFCDGV.RowHeadersVisible = False
        Me.NFCDGV.RowTemplate.Height = 24
        Me.NFCDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.NFCDGV.Size = New System.Drawing.Size(296, 490)
        Me.NFCDGV.TabIndex = 2
        '
        'Type
        '
        Me.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Type.FillWeight = 60.0!
        Me.Type.HeaderText = "類別"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 65
        '
        'Column1
        '
        Me.Column1.HeaderText = "型態"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Subject
        '
        Me.Subject.DataPropertyName = "Subject"
        Me.Subject.HeaderText = "主旨"
        Me.Subject.Name = "Subject"
        Me.Subject.ReadOnly = True
        '
        'MsgBody
        '
        Me.MsgBody.DataPropertyName = "MsgBody"
        Me.MsgBody.FillWeight = 250.0!
        Me.MsgBody.HeaderText = "內容"
        Me.MsgBody.Name = "MsgBody"
        Me.MsgBody.ReadOnly = True
        Me.MsgBody.Width = 250
        '
        'MID
        '
        Me.MID.DataPropertyName = "MID"
        Me.MID.HeaderText = "訊息編號"
        Me.MID.Name = "MID"
        Me.MID.ReadOnly = True
        '
        'SendDate
        '
        Me.SendDate.DataPropertyName = "SendDate"
        Me.SendDate.FillWeight = 180.0!
        Me.SendDate.HeaderText = "訊息傳送日期/時間"
        Me.SendDate.Name = "SendDate"
        Me.SendDate.ReadOnly = True
        Me.SendDate.Width = 180
        '
        'Create_User
        '
        Me.Create_User.DataPropertyName = "Create_User"
        Me.Create_User.HeaderText = "發送者"
        Me.Create_User.Name = "Create_User"
        Me.Create_User.ReadOnly = True
        '
        'NFCDataReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 567)
        Me.Controls.Add(Me.pal_Detail)
        Me.Controls.Add(Me.flp_Button)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(260, 39)
        Me.Name = "NFCDataReader"
        Me.TabText = "訊息視窗"
        Me.Text = "訊息視窗"
        Me.flp_Button.ResumeLayout(False)
        Me.pal_Detail.ResumeLayout(False)
        CType(Me.NFCDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ReloadTimer As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents flp_Button As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pal_Detail As System.Windows.Forms.Panel
    Friend WithEvents NFCDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MsgBody As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Create_User As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
