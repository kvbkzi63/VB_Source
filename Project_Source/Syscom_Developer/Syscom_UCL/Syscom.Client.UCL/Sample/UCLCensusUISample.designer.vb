<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLCensusUISample
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCLCensusUISample))
        Me.Label1 = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.UclCensusAddrUI1 = New Syscom.Client.ucl.UCLCensusAddrUI
        Me.UclCensusUI1 = New Syscom.Client.ucl.UCLCensusUI
        Me.Button11 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "住址元件注意事項"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(29, 52)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(774, 151)
        Me.RichTextBox1.TabIndex = 26
        Me.RichTextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "UclCensusUI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 334)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "UclCensusAddrUI1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(502, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 34)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "設定值 0101"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(593, 326)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 34)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "設定值 105"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(40, 249)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(137, 23)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "取得戶籍地代碼"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(195, 249)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(165, 23)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "取得戶籍地名稱"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(384, 249)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(185, 23)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "取得郵遞區號代碼"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(575, 249)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(213, 23)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "取得郵遞區號名稱"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(560, 371)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(213, 23)
        Me.Button7.TabIndex = 38
        Me.Button7.Text = "取得郵遞區號名稱"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(369, 371)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(185, 23)
        Me.Button8.TabIndex = 37
        Me.Button8.Text = "取得郵遞區號代碼"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(180, 371)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(165, 23)
        Me.Button9.TabIndex = 36
        Me.Button9.Text = "取得戶籍地名稱"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(25, 371)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(137, 23)
        Me.Button10.TabIndex = 35
        Me.Button10.Text = "取得戶籍地代碼"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'UclCensusAddrUI1
        '
        Me.UclCensusAddrUI1.doFlag = True
        Me.UclCensusAddrUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCensusAddrUI1.Location = New System.Drawing.Point(164, 334)
        Me.UclCensusAddrUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclCensusAddrUI1.Name = "UclCensusAddrUI1"
        Me.UclCensusAddrUI1.SelectAreaCode = ""
        Me.UclCensusAddrUI1.SelectAreaName = ""
        Me.UclCensusAddrUI1.SelectedValue = ""
        Me.UclCensusAddrUI1.SelectPostalCode = ""
        Me.UclCensusAddrUI1.SelectPostalName = ""
        Me.UclCensusAddrUI1.Size = New System.Drawing.Size(422, 26)
        Me.UclCensusAddrUI1.TabIndex = 1
        Me.UclCensusAddrUI1.TxtAddress = ""
        Me.UclCensusAddrUI1.uclCboWidth = 150
        Me.UclCensusAddrUI1.uclDisplayIndex = "0,1"
        Me.UclCensusAddrUI1.uclShowType = Syscom.Client.ucl.UCLCensusAddrUI.uclShowData.showPostal
        Me.UclCensusAddrUI1.uclValueIndex = "0"
        Me.UclCensusAddrUI1.uclXPosition = 225
        Me.UclCensusAddrUI1.uclYPosition = 120
        '
        'UclCensusUI1
        '
        Me.UclCensusUI1.doFlag = True
        Me.UclCensusUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCensusUI1.Location = New System.Drawing.Point(163, 211)
        Me.UclCensusUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclCensusUI1.Name = "UclCensusUI1"
        Me.UclCensusUI1.SelectAreaCode = ""
        Me.UclCensusUI1.SelectAreaName = ""
        Me.UclCensusUI1.SelectedValue = ""
        Me.UclCensusUI1.SelectPostalCode = ""
        Me.UclCensusUI1.SelectPostalName = ""
        Me.UclCensusUI1.Size = New System.Drawing.Size(330, 26)
        Me.UclCensusUI1.TabIndex = 0
        Me.UclCensusUI1.uclCboWidth = 294
        Me.UclCensusUI1.uclDisplayIndex = "0,1"
        Me.UclCensusUI1.uclShowType = Syscom.Client.ucl.UCLCensusUI.uclShowData.showArea
        Me.UclCensusUI1.uclValueIndex = "0"
        Me.UclCensusUI1.uclXPosition = 225
        Me.UclCensusUI1.uclYPosition = 120
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(560, 400)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(213, 23)
        Me.Button11.TabIndex = 39
        Me.Button11.Text = "取得TextBox Text"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 429)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UclCensusAddrUI1)
        Me.Controls.Add(Me.UclCensusUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclCensusUI1 As Syscom.Client.ucl.UCLCensusUI
    Friend WithEvents UclCensusAddrUI1 As Syscom.Client.ucl.UCLCensusAddrUI
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
End Class
