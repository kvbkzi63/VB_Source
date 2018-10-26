Imports Syscom.Client.UCL

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PUBPatientTransferRiskUI
    Inherits BaseFormUI

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
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RichTextBox6 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox5 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox4 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_G = New System.Windows.Forms.RadioButton()
        Me.rbt_Y = New System.Windows.Forms.RadioButton()
        Me.rbt_R = New System.Windows.Forms.RadioButton()
        Me.lbl_PatientInfo = New System.Windows.Forms.Label()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 1
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 0, 2)
        Me.tlp_Main.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.tlp_Main.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 3
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.23746!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.76254!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(944, 641)
        Me.tlp_Main.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Exit)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Save)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 602)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(936, 35)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(836, 4)
        Me.btn_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(96, 27)
        Me.btn_Exit.TabIndex = 0
        Me.btn_Exit.Text = "ESC-離開 "
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(732, 4)
        Me.btn_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(96, 27)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F10-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.94684!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.05315!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 339.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox6, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox5, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox4, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 130)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.29787!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.70213!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(938, 465)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'RichTextBox6
        '
        Me.RichTextBox6.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox6.Enabled = False
        Me.RichTextBox6.Location = New System.Drawing.Point(599, 340)
        Me.RichTextBox6.Name = "RichTextBox6"
        Me.RichTextBox6.Size = New System.Drawing.Size(334, 120)
        Me.RichTextBox6.TabIndex = 11
        Me.RichTextBox6.Text = "■傳送員"
        '
        'RichTextBox5
        '
        Me.RichTextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox5.Enabled = False
        Me.RichTextBox5.Location = New System.Drawing.Point(101, 340)
        Me.RichTextBox5.Name = "RichTextBox5"
        Me.RichTextBox5.Size = New System.Drawing.Size(490, 120)
        Me.RichTextBox5.TabIndex = 10
        Me.RichTextBox5.Text = "運送時情況穩定，欲接受檢查或手術，目前無特殊症狀者"
        '
        'RichTextBox4
        '
        Me.RichTextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox4.Enabled = False
        Me.RichTextBox4.Location = New System.Drawing.Point(599, 208)
        Me.RichTextBox4.Name = "RichTextBox4"
        Me.RichTextBox4.Size = New System.Drawing.Size(334, 124)
        Me.RichTextBox4.TabIndex = 9
        Me.RichTextBox4.Text = "■護理師(由醫師評估)"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox3.Enabled = False
        Me.RichTextBox3.Location = New System.Drawing.Point(101, 208)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(490, 124)
        Me.RichTextBox3.TabIndex = 8
        Me.RichTextBox3.Text = "過去24小時病情比較不穩定，但預測轉送中病情穩定者"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox2.Enabled = False
        Me.RichTextBox2.Location = New System.Drawing.Point(599, 83)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(334, 117)
        Me.RichTextBox2.TabIndex = 7
        Me.RichTextBox2.Text = "■醫護人員(護理師或專科護理師或呼吸治療師或醫師)- 由醫師評估" & Global.Microsoft.VisualBasic.ChrW(10) & "■傳送員"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(5, 340)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(88, 120)
        Me.Panel7.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(46, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "綠"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(5, 208)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(88, 124)
        Me.Panel5.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Yellow
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(88, 124)
        Me.Panel6.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 27)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "黃"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 54)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "分" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "級"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Red
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(5, 83)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(88, 117)
        Me.Panel4.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(46, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "紅"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(599, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(334, 70)
        Me.Panel3.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(113, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 27)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "運送者"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(101, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(490, 70)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(139, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "病 人 情 況(參考)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(88, 70)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "分" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "級"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Enabled = False
        Me.RichTextBox1.Location = New System.Drawing.Point(101, 83)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(490, 117)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = "目前不穩定或轉送中病情可能不穩定者"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_PatientInfo, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.59504!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.40496!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(938, 121)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.583691!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.41631!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.FlowLayoutPanel2, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 85)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(932, 33)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "運送等級"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_G)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_Y)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_R)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(86, 5)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(153, 23)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'rbt_G
        '
        Me.rbt_G.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_G.AutoSize = True
        Me.rbt_G.BackColor = System.Drawing.Color.LimeGreen
        Me.rbt_G.Location = New System.Drawing.Point(3, 3)
        Me.rbt_G.Name = "rbt_G"
        Me.rbt_G.Size = New System.Drawing.Size(42, 20)
        Me.rbt_G.TabIndex = 0
        Me.rbt_G.TabStop = True
        Me.rbt_G.Text = "綠"
        Me.rbt_G.UseVisualStyleBackColor = False
        '
        'rbt_Y
        '
        Me.rbt_Y.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_Y.AutoSize = True
        Me.rbt_Y.BackColor = System.Drawing.Color.Yellow
        Me.rbt_Y.Location = New System.Drawing.Point(51, 3)
        Me.rbt_Y.Name = "rbt_Y"
        Me.rbt_Y.Size = New System.Drawing.Size(42, 20)
        Me.rbt_Y.TabIndex = 1
        Me.rbt_Y.TabStop = True
        Me.rbt_Y.Text = "黃"
        Me.rbt_Y.UseVisualStyleBackColor = False
        '
        'rbt_R
        '
        Me.rbt_R.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_R.AutoSize = True
        Me.rbt_R.BackColor = System.Drawing.Color.Red
        Me.rbt_R.Location = New System.Drawing.Point(99, 3)
        Me.rbt_R.Name = "rbt_R"
        Me.rbt_R.Size = New System.Drawing.Size(42, 20)
        Me.rbt_R.TabIndex = 2
        Me.rbt_R.TabStop = True
        Me.rbt_R.Text = "紅"
        Me.rbt_R.UseVisualStyleBackColor = False
        '
        'lbl_PatientInfo
        '
        Me.lbl_PatientInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_PatientInfo.AutoSize = True
        Me.lbl_PatientInfo.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbl_PatientInfo.Location = New System.Drawing.Point(3, 27)
        Me.lbl_PatientInfo.Name = "lbl_PatientInfo"
        Me.lbl_PatientInfo.Size = New System.Drawing.Size(74, 27)
        Me.lbl_PatientInfo.TabIndex = 1
        Me.lbl_PatientInfo.Text = "ptInfo"
        '
        'PUBPatientTransferRiskUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.KeyPreview = True
        Me.Name = "PUBPatientTransferRiskUI"
        Me.TabText = "病患運送等級修改作業"
        Me.Text = "病患運送等級修改作業"
        Me.tlp_Main.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_Main As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btn_Exit As Button
    Friend WithEvents btn_Save As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RichTextBox6 As RichTextBox
    Friend WithEvents RichTextBox5 As RichTextBox
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents rbt_G As RadioButton
    Friend WithEvents rbt_Y As RadioButton
    Friend WithEvents rbt_R As RadioButton
    Friend WithEvents lbl_PatientInfo As Label
End Class
