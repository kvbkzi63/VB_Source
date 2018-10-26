<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFCDeploySender
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

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
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_Send = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mtb_EndTime = New System.Windows.Forms.MaskedTextBox()
        Me.mtb_StartTime = New System.Windows.Forms.MaskedTextBox()
        Me.rtb_Msg = New System.Windows.Forms.RichTextBox()
        Me.lbl_Msg = New System.Windows.Forms.Label()
        Me.txt_Subject = New System.Windows.Forms.TextBox()
        Me.lbl_Subject = New System.Windows.Forms.Label()
        Me.lbl_EndTime = New System.Windows.Forms.Label()
        Me.dtp_EndDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.lbl_EndDate = New System.Windows.Forms.Label()
        Me.lbl_StartTime = New System.Windows.Forms.Label()
        Me.lbl_StartDate = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "發送日期時間"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "開始日期時間"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "結束日期時間"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 130
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "主旨"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 140
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "訊息內容"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 240
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "發送日期"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 140
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "發送對象"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 380
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "發送對象"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'btn_Send
        '
        Me.btn_Send.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Send.Location = New System.Drawing.Point(671, 64)
        Me.btn_Send.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Send.Name = "btn_Send"
        Me.btn_Send.Size = New System.Drawing.Size(100, 35)
        Me.btn_Send.TabIndex = 12
        Me.btn_Send.Text = "發送"
        Me.btn_Send.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(517, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "(請輸入00:00~23:59)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(517, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "(請輸入00:00~23:59)"
        '
        'mtb_EndTime
        '
        Me.mtb_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_EndTime.BackColor = System.Drawing.Color.White
        Me.mtb_EndTime.Location = New System.Drawing.Point(361, 68)
        Me.mtb_EndTime.Margin = New System.Windows.Forms.Padding(4)
        Me.mtb_EndTime.Mask = "90:00"
        Me.mtb_EndTime.Name = "mtb_EndTime"
        Me.mtb_EndTime.Size = New System.Drawing.Size(148, 27)
        Me.mtb_EndTime.TabIndex = 7
        Me.mtb_EndTime.ValidatingType = GetType(Date)
        '
        'mtb_StartTime
        '
        Me.mtb_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mtb_StartTime.BackColor = System.Drawing.Color.White
        Me.mtb_StartTime.Location = New System.Drawing.Point(361, 12)
        Me.mtb_StartTime.Margin = New System.Windows.Forms.Padding(4)
        Me.mtb_StartTime.Mask = "90:00"
        Me.mtb_StartTime.Name = "mtb_StartTime"
        Me.mtb_StartTime.Size = New System.Drawing.Size(148, 27)
        Me.mtb_StartTime.TabIndex = 3
        Me.mtb_StartTime.ValidatingType = GetType(Date)
        '
        'rtb_Msg
        '
        Me.rtb_Msg.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.rtb_Msg, 6)
        Me.rtb_Msg.Dock = System.Windows.Forms.DockStyle.Left
        Me.rtb_Msg.Location = New System.Drawing.Point(84, 156)
        Me.rtb_Msg.Margin = New System.Windows.Forms.Padding(4)
        Me.rtb_Msg.Name = "rtb_Msg"
        Me.rtb_Msg.Size = New System.Drawing.Size(687, 204)
        Me.rtb_Msg.TabIndex = 11
        Me.rtb_Msg.Text = "HIS系統於15:00更新程式,更新完成後請重新登入系統,版本序號為135."
        '
        'lbl_Msg
        '
        Me.lbl_Msg.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Msg.AutoSize = True
        Me.lbl_Msg.Location = New System.Drawing.Point(36, 250)
        Me.lbl_Msg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Msg.Name = "lbl_Msg"
        Me.lbl_Msg.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Msg.TabIndex = 10
        Me.lbl_Msg.Text = "訊息"
        '
        'txt_Subject
        '
        Me.txt_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Subject.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.txt_Subject, 6)
        Me.txt_Subject.Location = New System.Drawing.Point(84, 118)
        Me.txt_Subject.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Subject.Name = "txt_Subject"
        Me.txt_Subject.Size = New System.Drawing.Size(687, 27)
        Me.txt_Subject.TabIndex = 9
        Me.txt_Subject.Text = "新醫療系統更新通知"
        '
        'lbl_Subject
        '
        Me.lbl_Subject.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Subject.AutoSize = True
        Me.lbl_Subject.Location = New System.Drawing.Point(36, 124)
        Me.lbl_Subject.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Subject.Name = "lbl_Subject"
        Me.lbl_Subject.Size = New System.Drawing.Size(40, 16)
        Me.lbl_Subject.TabIndex = 8
        Me.lbl_Subject.Text = "主旨"
        '
        'lbl_EndTime
        '
        Me.lbl_EndTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndTime.AutoSize = True
        Me.lbl_EndTime.Location = New System.Drawing.Point(281, 73)
        Me.lbl_EndTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_EndTime.Name = "lbl_EndTime"
        Me.lbl_EndTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndTime.TabIndex = 6
        Me.lbl_EndTime.Text = "結束時間"
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_EndDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_EndDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_EndDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_EndDate.Location = New System.Drawing.Point(84, 63)
        Me.dtp_EndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_EndDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_EndDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(189, 36)
        Me.dtp_EndDate.TabIndex = 5
        Me.dtp_EndDate.uclReadOnly = False
        '
        'lbl_EndDate
        '
        Me.lbl_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_EndDate.AutoSize = True
        Me.lbl_EndDate.Location = New System.Drawing.Point(4, 73)
        Me.lbl_EndDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_EndDate.Name = "lbl_EndDate"
        Me.lbl_EndDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_EndDate.TabIndex = 4
        Me.lbl_EndDate.Text = "結束日期"
        '
        'lbl_StartTime
        '
        Me.lbl_StartTime.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartTime.AutoSize = True
        Me.lbl_StartTime.Location = New System.Drawing.Point(281, 17)
        Me.lbl_StartTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_StartTime.Name = "lbl_StartTime"
        Me.lbl_StartTime.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartTime.TabIndex = 2
        Me.lbl_StartTime.Text = "開始時間"
        '
        'lbl_StartDate
        '
        Me.lbl_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_StartDate.AutoSize = True
        Me.lbl_StartDate.Location = New System.Drawing.Point(4, 17)
        Me.lbl_StartDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_StartDate.Name = "lbl_StartDate"
        Me.lbl_StartDate.Size = New System.Drawing.Size(72, 16)
        Me.lbl_StartDate.TabIndex = 1
        Me.lbl_StartDate.Text = "開始日期"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_StartDate.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_StartDate.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_StartDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtp_StartDate.Location = New System.Drawing.Point(84, 7)
        Me.dtp_StartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_StartDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_StartDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(189, 36)
        Me.dtp_StartDate.TabIndex = 0
        Me.dtp_StartDate.uclReadOnly = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_StartDate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_StartDate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_StartTime, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_EndDate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_EndDate, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_EndTime, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Subject, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Subject, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_Msg, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_Msg, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.mtb_StartTime, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.mtb_EndTime, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Send, 5, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 212.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(820, 437)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'NFCDeploySender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 455)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NFCDeploySender"
        Me.Text = "NFCDeploySender"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_Send As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mtb_EndTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_StartTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rtb_Msg As System.Windows.Forms.RichTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_StartDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_StartDate As System.Windows.Forms.Label
    Friend WithEvents lbl_StartTime As System.Windows.Forms.Label
    Friend WithEvents lbl_EndDate As System.Windows.Forms.Label
    Friend WithEvents dtp_EndDate As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents lbl_EndTime As System.Windows.Forms.Label
    Friend WithEvents lbl_Subject As System.Windows.Forms.Label
    Friend WithEvents txt_Subject As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Msg As System.Windows.Forms.Label
End Class
