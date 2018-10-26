<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Other
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.UclCheckListBoxUI1 = New Syscom.Client.UCL.UCLCheckListBoxUI
        Me.UclListBoxUI1 = New Syscom.Client.UCL.UCLListBoxUI
        Me.UclIdentityUI1 = New Syscom.Client.UCL.UCLIdentityUI
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "身份別元件注意事項"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "使用前請記得先呼叫Initial"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Set Initial Value"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(692, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 23)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Set Initial Value"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 201)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "UclListBoxUI元件 "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(423, 201)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "UclCheckListBoxUI元件 "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(198, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(437, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "屬性與方法設定請參考UCL共用元件使用說明.doc 第12項元件"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(433, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "屬性與方法設定請參考UCL共用元件使用說明.doc 第5 項元件"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(240, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "屬性設定後最後再呼叫Initial"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(448, 392)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(163, 23)
        Me.Button3.TabIndex = 37
        Me.Button3.Text = "Get  SelectedName"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(447, 363)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(164, 23)
        Me.Button4.TabIndex = 38
        Me.Button4.Text = "Get  SelectedCode"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(448, 421)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(163, 23)
        Me.Button6.TabIndex = 40
        Me.Button6.Text = "Get  SelectedIndex"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(633, 360)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(164, 23)
        Me.Button7.TabIndex = 41
        Me.Button7.Text = "Get  NonSelectedCode"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(633, 392)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(163, 23)
        Me.Button8.TabIndex = 42
        Me.Button8.Text = "Get  NonSelectedName"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(634, 421)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(163, 23)
        Me.Button9.TabIndex = 43
        Me.Button9.Text = "Get  NonSelectedIndex"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(692, 261)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(126, 23)
        Me.Button5.TabIndex = 44
        Me.Button5.Text = "Delete The Last"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(692, 302)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(126, 23)
        Me.Button10.TabIndex = 45
        Me.Button10.Text = "Sort Item"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaa", "aaaaaa", "aaaaaaaaaa"})
        Me.ComboBox1.Location = New System.Drawing.Point(697, 74)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 46
        '
        'UclCheckListBoxUI1
        '
        Me.UclCheckListBoxUI1.Location = New System.Drawing.Point(426, 222)
        Me.UclCheckListBoxUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclCheckListBoxUI1.Name = "UclCheckListBoxUI1"
        Me.UclCheckListBoxUI1.SelectedIndex = -1
        Me.UclCheckListBoxUI1.Size = New System.Drawing.Size(257, 147)
        Me.UclCheckListBoxUI1.TabIndex = 2
        Me.UclCheckListBoxUI1.uclCodeFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclDataSource = Nothing
        Me.UclCheckListBoxUI1.uclItemShowFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclNameFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclNonSelectedItemIndex = ""
        Me.UclCheckListBoxUI1.uclSelectedItemIndex = ""
        Me.UclCheckListBoxUI1.uclSeparator = Syscom.Client.UCL.UCLCheckListBoxUI.uclSeparatorType.OneSpace_Dash_OneSpace
        '
        'UclListBoxUI1
        '
        Me.UclListBoxUI1.Location = New System.Drawing.Point(15, 222)
        Me.UclListBoxUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclListBoxUI1.Name = "UclListBoxUI1"
        Me.UclListBoxUI1.Size = New System.Drawing.Size(247, 147)
        Me.UclListBoxUI1.TabIndex = 1
        Me.UclListBoxUI1.uclCodeFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclItemShowFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclNameFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclNonSelectedItemIndex = ""
        Me.UclListBoxUI1.uclSelectedItemIndex = ""
        Me.UclListBoxUI1.uclSelectionMode = Syscom.Client.UCL.UCLListBoxUI.uclSelectionStyle.One
        Me.UclListBoxUI1.uclSeparator = Syscom.Client.UCL.UCLListBoxUI.uclSeparatorType.OneSpace_Dash_OneSpace
        '
        'UclIdentityUI1
        '
        Me.UclIdentityUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclIdentityUI1.Location = New System.Drawing.Point(18, 74)
        Me.UclIdentityUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclIdentityUI1.Name = "UclIdentityUI1"
        Me.UclIdentityUI1.Size = New System.Drawing.Size(665, 28)
        Me.UclIdentityUI1.TabIndex = 0
        Me.UclIdentityUI1.uclConDisplayIndex = "0,1"
        Me.UclIdentityUI1.uclContract1Width = 80
        Me.UclIdentityUI1.uclContract2Width = 80
        Me.UclIdentityUI1.uclConValueIndex = "0"
        Me.UclIdentityUI1.uclDisIdDisplayIndex = "0,1"
        Me.UclIdentityUI1.uclDisIdValueIndex = "0"
        Me.UclIdentityUI1.uclDisIdWidth = 80
        Me.UclIdentityUI1.uclEnabledContract = True
        Me.UclIdentityUI1.uclEnabledDisId = True
        Me.UclIdentityUI1.uclEnabledId1 = True
        Me.UclIdentityUI1.uclEnabledId2 = True
        Me.UclIdentityUI1.uclId1Width = 80
        Me.UclIdentityUI1.uclId2Width = 80
        Me.UclIdentityUI1.uclMainIdDisplayIndex = "0,1"
        Me.UclIdentityUI1.uclMainIdValueIndex = "0"
        Me.UclIdentityUI1.uclShowContract = Syscom.Client.UCL.UCLIdentityUI.ShowContractType.ShowBoth
        Me.UclIdentityUI1.uclShowDisId = True
        Me.UclIdentityUI1.uclShowId1 = True
        Me.UclIdentityUI1.uclShowId2 = True
        Me.UclIdentityUI1.uclSubIdDisplayIndex = "0,1"
        Me.UclIdentityUI1.uclSubValueIndex = "0"
        '
        'Other
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 453)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UclCheckListBoxUI1)
        Me.Controls.Add(Me.UclListBoxUI1)
        Me.Controls.Add(Me.UclIdentityUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Other"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclIdentityUI1 As Syscom.Client.UCL.UCLIdentityUI
    Friend WithEvents UclListBoxUI1 As Syscom.Client.UCL.UCLListBoxUI
    Friend WithEvents UclCheckListBoxUI1 As Syscom.Client.UCL.UCLCheckListBoxUI
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
