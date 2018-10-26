<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclTimeKeypadUI
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbl_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.flp_timeBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt_time = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_notify = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_MDigits = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_MDigits9 = New System.Windows.Forms.Button()
        Me.btn_MDigits0 = New System.Windows.Forms.Button()
        Me.btn_MDigits1 = New System.Windows.Forms.Button()
        Me.btn_MDigits2 = New System.Windows.Forms.Button()
        Me.btn_MDigits3 = New System.Windows.Forms.Button()
        Me.btn_MDigits4 = New System.Windows.Forms.Button()
        Me.btn_MDigits5 = New System.Windows.Forms.Button()
        Me.btn_MDigits6 = New System.Windows.Forms.Button()
        Me.btn_MDigits7 = New System.Windows.Forms.Button()
        Me.btn_MDigits8 = New System.Windows.Forms.Button()
        Me.flp_button = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.tlp_Htens = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_HTens0 = New System.Windows.Forms.Button()
        Me.btn_HTens2 = New System.Windows.Forms.Button()
        Me.btn_HTens1 = New System.Windows.Forms.Button()
        Me.tlp_HDigits = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_HDigits9 = New System.Windows.Forms.Button()
        Me.btn_HDigits8 = New System.Windows.Forms.Button()
        Me.btn_HDigits7 = New System.Windows.Forms.Button()
        Me.btn_HDigits6 = New System.Windows.Forms.Button()
        Me.btn_HDigits5 = New System.Windows.Forms.Button()
        Me.btn_HDigits4 = New System.Windows.Forms.Button()
        Me.btn_HDigits3 = New System.Windows.Forms.Button()
        Me.btn_HDigits2 = New System.Windows.Forms.Button()
        Me.btn_HDigits1 = New System.Windows.Forms.Button()
        Me.btn_HDigits0 = New System.Windows.Forms.Button()
        Me.tlp_MTens = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_MTens0 = New System.Windows.Forms.Button()
        Me.btn_MTens1 = New System.Windows.Forms.Button()
        Me.btn_MTens2 = New System.Windows.Forms.Button()
        Me.btn_MTens3 = New System.Windows.Forms.Button()
        Me.btn_MTens4 = New System.Windows.Forms.Button()
        Me.btn_MTens5 = New System.Windows.Forms.Button()
        Me.tbl_Main.SuspendLayout()
        Me.flp_timeBox.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tlp_MDigits.SuspendLayout()
        Me.flp_button.SuspendLayout()
        Me.tlp_Htens.SuspendLayout()
        Me.tlp_HDigits.SuspendLayout()
        Me.tlp_MTens.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbl_Main
        '
        Me.tbl_Main.ColumnCount = 1
        Me.tbl_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tbl_Main.Controls.Add(Me.flp_timeBox, 0, 0)
        Me.tbl_Main.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.tbl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbl_Main.Location = New System.Drawing.Point(0, 0)
        Me.tbl_Main.Name = "tbl_Main"
        Me.tbl_Main.RowCount = 2
        Me.tbl_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tbl_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 347.0!))
        Me.tbl_Main.Size = New System.Drawing.Size(368, 385)
        Me.tbl_Main.TabIndex = 0
        '
        'flp_timeBox
        '
        Me.flp_timeBox.Controls.Add(Me.txt_time)
        Me.flp_timeBox.Controls.Add(Me.lbl_notify)
        Me.flp_timeBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp_timeBox.Location = New System.Drawing.Point(3, 3)
        Me.flp_timeBox.Name = "flp_timeBox"
        Me.flp_timeBox.Size = New System.Drawing.Size(362, 32)
        Me.flp_timeBox.TabIndex = 0
        '
        'txt_time
        '
        Me.txt_time.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_time.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_time.Location = New System.Drawing.Point(3, 3)
        Me.txt_time.MaxLength = 10
        Me.txt_time.Name = "txt_time"
        Me.txt_time.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_time.SelectionStart = 0
        Me.txt_time.Size = New System.Drawing.Size(83, 27)
        Me.txt_time.TabIndex = 0
        Me.txt_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_time.ToolTipTag = Nothing
        Me.txt_time.uclDollarSign = False
        Me.txt_time.uclDotCount = 0
        Me.txt_time.uclIntCount = 2
        Me.txt_time.uclMinus = False
        Me.txt_time.uclReadOnly = False
        Me.txt_time.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        Me.txt_time.uclTrimZero = True
        '
        'lbl_notify
        '
        Me.lbl_notify.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_notify.AutoSize = True
        Me.lbl_notify.Location = New System.Drawing.Point(92, 8)
        Me.lbl_notify.Name = "lbl_notify"
        Me.lbl_notify.Size = New System.Drawing.Size(264, 16)
        Me.lbl_notify.TabIndex = 1
        Me.lbl_notify.Text = "請點選下方鍵盤或輸入四位時間數字"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tlp_MDigits, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flp_button, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.tlp_Htens, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tlp_HDigits, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tlp_MTens, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 41)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.857142!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.714287!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.57143!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(362, 341)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'tlp_MDigits
        '
        Me.tlp_MDigits.ColumnCount = 1
        Me.tlp_MDigits.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits9, 0, 9)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits0, 0, 0)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits1, 0, 1)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits2, 0, 2)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits3, 0, 3)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits4, 0, 4)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits5, 0, 5)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits6, 0, 6)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits7, 0, 7)
        Me.tlp_MDigits.Controls.Add(Me.btn_MDigits8, 0, 8)
        Me.tlp_MDigits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_MDigits.Location = New System.Drawing.Point(273, 3)
        Me.tlp_MDigits.Name = "tlp_MDigits"
        Me.tlp_MDigits.RowCount = 10
        Me.TableLayoutPanel1.SetRowSpan(Me.tlp_MDigits, 10)
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MDigits.Size = New System.Drawing.Size(86, 297)
        Me.tlp_MDigits.TabIndex = 46
        '
        'btn_MDigits9
        '
        Me.btn_MDigits9.Location = New System.Drawing.Point(3, 273)
        Me.btn_MDigits9.Name = "btn_MDigits9"
        Me.btn_MDigits9.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits9.TabIndex = 44
        Me.btn_MDigits9.Text = "9"
        Me.btn_MDigits9.UseVisualStyleBackColor = True
        '
        'btn_MDigits0
        '
        Me.btn_MDigits0.BackColor = System.Drawing.SystemColors.Control
        Me.btn_MDigits0.Location = New System.Drawing.Point(3, 3)
        Me.btn_MDigits0.Name = "btn_MDigits0"
        Me.btn_MDigits0.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits0.TabIndex = 35
        Me.btn_MDigits0.Text = "0"
        Me.btn_MDigits0.UseVisualStyleBackColor = False
        '
        'btn_MDigits1
        '
        Me.btn_MDigits1.Location = New System.Drawing.Point(3, 33)
        Me.btn_MDigits1.Name = "btn_MDigits1"
        Me.btn_MDigits1.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits1.TabIndex = 36
        Me.btn_MDigits1.Text = "1"
        Me.btn_MDigits1.UseVisualStyleBackColor = True
        '
        'btn_MDigits2
        '
        Me.btn_MDigits2.Location = New System.Drawing.Point(3, 63)
        Me.btn_MDigits2.Name = "btn_MDigits2"
        Me.btn_MDigits2.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits2.TabIndex = 37
        Me.btn_MDigits2.Text = "2"
        Me.btn_MDigits2.UseVisualStyleBackColor = True
        '
        'btn_MDigits3
        '
        Me.btn_MDigits3.Location = New System.Drawing.Point(3, 93)
        Me.btn_MDigits3.Name = "btn_MDigits3"
        Me.btn_MDigits3.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits3.TabIndex = 38
        Me.btn_MDigits3.Text = "3"
        Me.btn_MDigits3.UseVisualStyleBackColor = True
        '
        'btn_MDigits4
        '
        Me.btn_MDigits4.Location = New System.Drawing.Point(3, 123)
        Me.btn_MDigits4.Name = "btn_MDigits4"
        Me.btn_MDigits4.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits4.TabIndex = 39
        Me.btn_MDigits4.Text = "4"
        Me.btn_MDigits4.UseVisualStyleBackColor = True
        '
        'btn_MDigits5
        '
        Me.btn_MDigits5.Location = New System.Drawing.Point(3, 153)
        Me.btn_MDigits5.Name = "btn_MDigits5"
        Me.btn_MDigits5.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits5.TabIndex = 40
        Me.btn_MDigits5.Text = "5"
        Me.btn_MDigits5.UseVisualStyleBackColor = True
        '
        'btn_MDigits6
        '
        Me.btn_MDigits6.Location = New System.Drawing.Point(3, 183)
        Me.btn_MDigits6.Name = "btn_MDigits6"
        Me.btn_MDigits6.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits6.TabIndex = 41
        Me.btn_MDigits6.Text = "6"
        Me.btn_MDigits6.UseVisualStyleBackColor = True
        '
        'btn_MDigits7
        '
        Me.btn_MDigits7.Location = New System.Drawing.Point(3, 213)
        Me.btn_MDigits7.Name = "btn_MDigits7"
        Me.btn_MDigits7.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits7.TabIndex = 42
        Me.btn_MDigits7.Text = "7"
        Me.btn_MDigits7.UseVisualStyleBackColor = True
        '
        'btn_MDigits8
        '
        Me.btn_MDigits8.Location = New System.Drawing.Point(3, 243)
        Me.btn_MDigits8.Name = "btn_MDigits8"
        Me.btn_MDigits8.Size = New System.Drawing.Size(80, 24)
        Me.btn_MDigits8.TabIndex = 43
        Me.btn_MDigits8.Text = "8"
        Me.btn_MDigits8.UseVisualStyleBackColor = True
        '
        'flp_button
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.flp_button, 4)
        Me.flp_button.Controls.Add(Me.btn_Cancel)
        Me.flp_button.Controls.Add(Me.btn_Confirm)
        Me.flp_button.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flp_button.Location = New System.Drawing.Point(3, 306)
        Me.flp_button.Name = "flp_button"
        Me.flp_button.Size = New System.Drawing.Size(356, 32)
        Me.flp_button.TabIndex = 32
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(278, 3)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 26)
        Me.btn_Cancel.TabIndex = 1
        Me.btn_Cancel.Text = "取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(197, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(75, 26)
        Me.btn_Confirm.TabIndex = 0
        Me.btn_Confirm.Text = "確定"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'tlp_Htens
        '
        Me.tlp_Htens.ColumnCount = 1
        Me.tlp_Htens.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Htens.Controls.Add(Me.btn_HTens0, 0, 0)
        Me.tlp_Htens.Controls.Add(Me.btn_HTens2, 0, 2)
        Me.tlp_Htens.Controls.Add(Me.btn_HTens1, 0, 1)
        Me.tlp_Htens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_Htens.Location = New System.Drawing.Point(3, 3)
        Me.tlp_Htens.Name = "tlp_Htens"
        Me.tlp_Htens.RowCount = 3
        Me.TableLayoutPanel1.SetRowSpan(Me.tlp_Htens, 10)
        Me.tlp_Htens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Htens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Htens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Htens.Size = New System.Drawing.Size(84, 297)
        Me.tlp_Htens.TabIndex = 43
        '
        'btn_HTens0
        '
        Me.btn_HTens0.BackColor = System.Drawing.SystemColors.Control
        Me.btn_HTens0.Location = New System.Drawing.Point(3, 3)
        Me.btn_HTens0.Name = "btn_HTens0"
        Me.btn_HTens0.Size = New System.Drawing.Size(78, 24)
        Me.btn_HTens0.TabIndex = 14
        Me.btn_HTens0.Text = "0"
        Me.btn_HTens0.UseVisualStyleBackColor = False
        '
        'btn_HTens2
        '
        Me.btn_HTens2.Location = New System.Drawing.Point(3, 63)
        Me.btn_HTens2.Name = "btn_HTens2"
        Me.btn_HTens2.Size = New System.Drawing.Size(78, 24)
        Me.btn_HTens2.TabIndex = 15
        Me.btn_HTens2.Text = "2"
        Me.btn_HTens2.UseVisualStyleBackColor = True
        '
        'btn_HTens1
        '
        Me.btn_HTens1.Location = New System.Drawing.Point(3, 33)
        Me.btn_HTens1.Name = "btn_HTens1"
        Me.btn_HTens1.Size = New System.Drawing.Size(78, 24)
        Me.btn_HTens1.TabIndex = 13
        Me.btn_HTens1.Text = "1"
        Me.btn_HTens1.UseVisualStyleBackColor = True
        '
        'tlp_HDigits
        '
        Me.tlp_HDigits.ColumnCount = 1
        Me.tlp_HDigits.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits9, 0, 9)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits8, 0, 8)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits7, 0, 7)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits6, 0, 6)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits5, 0, 5)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits4, 0, 4)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits3, 0, 3)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits2, 0, 2)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits1, 0, 1)
        Me.tlp_HDigits.Controls.Add(Me.btn_HDigits0, 0, 0)
        Me.tlp_HDigits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_HDigits.Location = New System.Drawing.Point(93, 3)
        Me.tlp_HDigits.Name = "tlp_HDigits"
        Me.tlp_HDigits.RowCount = 10
        Me.TableLayoutPanel1.SetRowSpan(Me.tlp_HDigits, 10)
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_HDigits.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_HDigits.Size = New System.Drawing.Size(84, 297)
        Me.tlp_HDigits.TabIndex = 44
        '
        'btn_HDigits9
        '
        Me.btn_HDigits9.Location = New System.Drawing.Point(3, 273)
        Me.btn_HDigits9.Name = "btn_HDigits9"
        Me.btn_HDigits9.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits9.TabIndex = 42
        Me.btn_HDigits9.Text = "9"
        Me.btn_HDigits9.UseVisualStyleBackColor = True
        '
        'btn_HDigits8
        '
        Me.btn_HDigits8.Location = New System.Drawing.Point(3, 243)
        Me.btn_HDigits8.Name = "btn_HDigits8"
        Me.btn_HDigits8.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits8.TabIndex = 41
        Me.btn_HDigits8.Text = "8"
        Me.btn_HDigits8.UseVisualStyleBackColor = True
        '
        'btn_HDigits7
        '
        Me.btn_HDigits7.Location = New System.Drawing.Point(3, 213)
        Me.btn_HDigits7.Name = "btn_HDigits7"
        Me.btn_HDigits7.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits7.TabIndex = 40
        Me.btn_HDigits7.Text = "7"
        Me.btn_HDigits7.UseVisualStyleBackColor = True
        '
        'btn_HDigits6
        '
        Me.btn_HDigits6.Location = New System.Drawing.Point(3, 183)
        Me.btn_HDigits6.Name = "btn_HDigits6"
        Me.btn_HDigits6.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits6.TabIndex = 39
        Me.btn_HDigits6.Text = "6"
        Me.btn_HDigits6.UseVisualStyleBackColor = True
        '
        'btn_HDigits5
        '
        Me.btn_HDigits5.Location = New System.Drawing.Point(3, 153)
        Me.btn_HDigits5.Name = "btn_HDigits5"
        Me.btn_HDigits5.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits5.TabIndex = 38
        Me.btn_HDigits5.Text = "5"
        Me.btn_HDigits5.UseVisualStyleBackColor = True
        '
        'btn_HDigits4
        '
        Me.btn_HDigits4.Location = New System.Drawing.Point(3, 123)
        Me.btn_HDigits4.Name = "btn_HDigits4"
        Me.btn_HDigits4.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits4.TabIndex = 37
        Me.btn_HDigits4.Text = "4"
        Me.btn_HDigits4.UseVisualStyleBackColor = True
        '
        'btn_HDigits3
        '
        Me.btn_HDigits3.Location = New System.Drawing.Point(3, 93)
        Me.btn_HDigits3.Name = "btn_HDigits3"
        Me.btn_HDigits3.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits3.TabIndex = 36
        Me.btn_HDigits3.Text = "3"
        Me.btn_HDigits3.UseVisualStyleBackColor = True
        '
        'btn_HDigits2
        '
        Me.btn_HDigits2.Location = New System.Drawing.Point(3, 63)
        Me.btn_HDigits2.Name = "btn_HDigits2"
        Me.btn_HDigits2.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits2.TabIndex = 35
        Me.btn_HDigits2.Text = "2"
        Me.btn_HDigits2.UseVisualStyleBackColor = True
        '
        'btn_HDigits1
        '
        Me.btn_HDigits1.Location = New System.Drawing.Point(3, 33)
        Me.btn_HDigits1.Name = "btn_HDigits1"
        Me.btn_HDigits1.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits1.TabIndex = 34
        Me.btn_HDigits1.Text = "1"
        Me.btn_HDigits1.UseVisualStyleBackColor = True
        '
        'btn_HDigits0
        '
        Me.btn_HDigits0.BackColor = System.Drawing.SystemColors.Control
        Me.btn_HDigits0.Location = New System.Drawing.Point(3, 3)
        Me.btn_HDigits0.Name = "btn_HDigits0"
        Me.btn_HDigits0.Size = New System.Drawing.Size(78, 24)
        Me.btn_HDigits0.TabIndex = 33
        Me.btn_HDigits0.Text = "0"
        Me.btn_HDigits0.UseVisualStyleBackColor = False
        '
        'tlp_MTens
        '
        Me.tlp_MTens.ColumnCount = 1
        Me.tlp_MTens.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_MTens.Controls.Add(Me.btn_MTens0, 0, 0)
        Me.tlp_MTens.Controls.Add(Me.btn_MTens1, 0, 1)
        Me.tlp_MTens.Controls.Add(Me.btn_MTens2, 0, 2)
        Me.tlp_MTens.Controls.Add(Me.btn_MTens3, 0, 3)
        Me.tlp_MTens.Controls.Add(Me.btn_MTens4, 0, 4)
        Me.tlp_MTens.Controls.Add(Me.btn_MTens5, 0, 5)
        Me.tlp_MTens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_MTens.Location = New System.Drawing.Point(183, 3)
        Me.tlp_MTens.Name = "tlp_MTens"
        Me.tlp_MTens.RowCount = 10
        Me.TableLayoutPanel1.SetRowSpan(Me.tlp_MTens, 10)
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_MTens.Size = New System.Drawing.Size(84, 297)
        Me.tlp_MTens.TabIndex = 45
        '
        'btn_MTens0
        '
        Me.btn_MTens0.BackColor = System.Drawing.SystemColors.Control
        Me.btn_MTens0.Location = New System.Drawing.Point(3, 3)
        Me.btn_MTens0.Name = "btn_MTens0"
        Me.btn_MTens0.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens0.TabIndex = 34
        Me.btn_MTens0.Text = "0"
        Me.btn_MTens0.UseVisualStyleBackColor = False
        '
        'btn_MTens1
        '
        Me.btn_MTens1.Location = New System.Drawing.Point(3, 33)
        Me.btn_MTens1.Name = "btn_MTens1"
        Me.btn_MTens1.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens1.TabIndex = 35
        Me.btn_MTens1.Text = "1"
        Me.btn_MTens1.UseVisualStyleBackColor = True
        '
        'btn_MTens2
        '
        Me.btn_MTens2.Location = New System.Drawing.Point(3, 63)
        Me.btn_MTens2.Name = "btn_MTens2"
        Me.btn_MTens2.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens2.TabIndex = 36
        Me.btn_MTens2.Text = "2"
        Me.btn_MTens2.UseVisualStyleBackColor = True
        '
        'btn_MTens3
        '
        Me.btn_MTens3.Location = New System.Drawing.Point(3, 93)
        Me.btn_MTens3.Name = "btn_MTens3"
        Me.btn_MTens3.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens3.TabIndex = 37
        Me.btn_MTens3.Text = "3"
        Me.btn_MTens3.UseVisualStyleBackColor = True
        '
        'btn_MTens4
        '
        Me.btn_MTens4.Location = New System.Drawing.Point(3, 123)
        Me.btn_MTens4.Name = "btn_MTens4"
        Me.btn_MTens4.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens4.TabIndex = 38
        Me.btn_MTens4.Text = "4"
        Me.btn_MTens4.UseVisualStyleBackColor = True
        '
        'btn_MTens5
        '
        Me.btn_MTens5.Location = New System.Drawing.Point(3, 153)
        Me.btn_MTens5.Name = "btn_MTens5"
        Me.btn_MTens5.Size = New System.Drawing.Size(78, 24)
        Me.btn_MTens5.TabIndex = 39
        Me.btn_MTens5.Text = "5"
        Me.btn_MTens5.UseVisualStyleBackColor = True
        '
        'UclTimeKeypadUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 385)
        Me.Controls.Add(Me.tbl_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "UclTimeKeypadUI"
        Me.TabText = "UclTimeKeypadUI"
        Me.Text = "時間鍵盤"
        Me.tbl_Main.ResumeLayout(False)
        Me.flp_timeBox.ResumeLayout(False)
        Me.flp_timeBox.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tlp_MDigits.ResumeLayout(False)
        Me.flp_button.ResumeLayout(False)
        Me.tlp_Htens.ResumeLayout(False)
        Me.tlp_HDigits.ResumeLayout(False)
        Me.tlp_MTens.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flp_timeBox As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_time As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_notify As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_HTens1 As System.Windows.Forms.Button
    Friend WithEvents btn_HTens2 As System.Windows.Forms.Button
    Friend WithEvents btn_HTens0 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits0 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits1 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits2 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits3 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits4 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits5 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits6 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits7 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits8 As System.Windows.Forms.Button
    Friend WithEvents btn_HDigits9 As System.Windows.Forms.Button
    Friend WithEvents tlp_Htens As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_HDigits As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_MDigits As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_MDigits0 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits1 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits2 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits3 As System.Windows.Forms.Button
    Friend WithEvents tlp_MTens As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_MTens0 As System.Windows.Forms.Button
    Friend WithEvents btn_MTens1 As System.Windows.Forms.Button
    Friend WithEvents btn_MTens2 As System.Windows.Forms.Button
    Friend WithEvents btn_MTens3 As System.Windows.Forms.Button
    Friend WithEvents btn_MTens4 As System.Windows.Forms.Button
    Friend WithEvents btn_MTens5 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits9 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits4 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits5 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits6 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits7 As System.Windows.Forms.Button
    Friend WithEvents btn_MDigits8 As System.Windows.Forms.Button
    Friend WithEvents flp_button As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
End Class
