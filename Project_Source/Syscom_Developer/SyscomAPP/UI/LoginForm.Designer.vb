Imports System.Deployment.Application
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            'DeleteSymbolicLink---------------------------
            'If ApplicationDeployment.IsNetworkDeployed Then
            '    'Dim link As New MKLink
            '    'link.DeleteLink()
            '    'If System.IO.File.Exists(link.GetAppPath & "\SVN\uploadLog.exe") Then
            '    '    Dim p As StartProcess = New StartProcess
            '    '    p.Start(link.GetAppPath & "\SVN\uploadLog.exe", "", 5)
            '    'End If
            'End If
            '--------------------------------------------

            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.ALL = New System.Windows.Forms.RadioButton()
        Me.CNC = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.TxtStationNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cbo_Station = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OK
        '
        Me.OK.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.OK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.OK.Image = CType(resources.GetObject("OK.Image"), System.Drawing.Image)
        Me.OK.Location = New System.Drawing.Point(390, 276)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(74, 27)
        Me.OK.TabIndex = 6
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Cancel.Image = CType(resources.GetObject("Cancel.Image"), System.Drawing.Image)
        Me.Cancel.Location = New System.Drawing.Point(470, 276)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(74, 27)
        Me.Cancel.TabIndex = 7
        '
        'ALL
        '
        Me.ALL.AutoSize = True
        Me.ALL.BackColor = System.Drawing.Color.Transparent
        Me.ALL.Checked = True
        Me.ALL.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ALL.ForeColor = System.Drawing.Color.SteelBlue
        Me.ALL.Location = New System.Drawing.Point(461, 245)
        Me.ALL.Name = "ALL"
        Me.ALL.Size = New System.Drawing.Size(94, 20)
        Me.ALL.TabIndex = 4
        Me.ALL.TabStop = True
        Me.ALL.Text = "護理系統"
        Me.ALL.UseVisualStyleBackColor = False
        Me.ALL.Visible = False
        '
        'CNC
        '
        Me.CNC.AutoSize = True
        Me.CNC.BackColor = System.Drawing.Color.Transparent
        Me.CNC.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CNC.ForeColor = System.Drawing.Color.SteelBlue
        Me.CNC.Location = New System.Drawing.Point(565, 246)
        Me.CNC.Name = "CNC"
        Me.CNC.Size = New System.Drawing.Size(60, 20)
        Me.CNC.TabIndex = 5
        Me.CNC.TabStop = True
        Me.CNC.Text = "護理"
        Me.CNC.UseVisualStyleBackColor = False
        Me.CNC.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(350, 244)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(117, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "版 面 配 置："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PasswordTextBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.SteelBlue
        Me.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PasswordTextBox.Location = New System.Drawing.Point(497, 173)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(144, 27)
        Me.PasswordTextBox.TabIndex = 2
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.UsernameTextBox.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.SteelBlue
        Me.UsernameTextBox.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.UsernameTextBox.Location = New System.Drawing.Point(497, 135)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(143, 27)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PasswordLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.PasswordLabel.Location = New System.Drawing.Point(392, 175)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(114, 25)
        Me.PasswordLabel.TabIndex = 30
        Me.PasswordLabel.Text = "密          碼："
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.UsernameLabel.Location = New System.Drawing.Point(392, 137)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(114, 25)
        Me.UsernameLabel.TabIndex = 31
        Me.UsernameLabel.Text = "使用者名稱："
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtStationNo
        '
        Me.TxtStationNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtStationNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtStationNo.ForeColor = System.Drawing.Color.SteelBlue
        Me.TxtStationNo.Location = New System.Drawing.Point(247, 278)
        Me.TxtStationNo.MaxLength = 5
        Me.TxtStationNo.Name = "TxtStationNo"
        Me.TxtStationNo.Size = New System.Drawing.Size(123, 27)
        Me.TxtStationNo.TabIndex = 8
        Me.TxtStationNo.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(350, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 25)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "單          位："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Cbo_Station
        '
        Me.Cbo_Station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.Cbo_Station.DropDownWidth = 20
        Me.Cbo_Station.DroppedDown = False
        Me.Cbo_Station.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cbo_Station.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cbo_Station.Location = New System.Drawing.Point(461, 212)
        Me.Cbo_Station.Margin = New System.Windows.Forms.Padding(0)
        Me.Cbo_Station.Name = "Cbo_Station"
        Me.Cbo_Station.SelectedIndex = -1
        Me.Cbo_Station.SelectedItem = Nothing
        Me.Cbo_Station.SelectedText = ""
        Me.Cbo_Station.SelectedValue = ""
        Me.Cbo_Station.SelectionStart = 0
        Me.Cbo_Station.Size = New System.Drawing.Size(180, 24)
        Me.Cbo_Station.TabIndex = 3
        Me.Cbo_Station.uclDisplayIndex = "0,1"
        Me.Cbo_Station.uclIsAutoClear = True
        Me.Cbo_Station.uclIsFirstItemEmpty = True
        Me.Cbo_Station.uclIsTextMode = False
        Me.Cbo_Station.uclShowMsg = False
        Me.Cbo_Station.uclValueIndex = "0"
        Me.Cbo_Station.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(550, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 26)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "忘記密碼"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(653, 320)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cbo_Station)
        Me.Controls.Add(Me.TxtStationNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CNC)
        Me.Controls.Add(Me.ALL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "護理資訊系統"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ALL As System.Windows.Forms.RadioButton
    Friend WithEvents CNC As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents TxtStationNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Station As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
