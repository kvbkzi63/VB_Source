<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLTextCodeQueryUISample
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.UclBtnCodeQueryUI3 = New Syscom.Client.ucl.UCLBtnCodeQueryUI
        Me.UclListBoxUI1 = New Syscom.Client.ucl.UCLListBoxUI
        Me.UclCheckListBoxUI1 = New Syscom.Client.ucl.UCLCheckListBoxUI
        Me.UclBtnCodeQueryUI2 = New Syscom.Client.ucl.UCLBtnCodeQueryUI
        Me.UclTextCodeQueryUI2 = New Syscom.Client.ucl.UCLTextCodeQueryUI
        Me.UclBtnCodeQueryUI1 = New Syscom.Client.ucl.UCLBtnCodeQueryUI
        Me.UclTextCodeQueryUI1 = New Syscom.Client.ucl.UCLTextCodeQueryUI
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "CodeValue1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "CodeValue2:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "CodeName"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Table 查詢元件"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(220, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "CodeName"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(220, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "CodeValue2:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "CodeValue1:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(220, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "CodeName"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(220, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "CodeValue2:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(220, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "CodeValue1:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(220, 348)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 16)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "預設顯示Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(220, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "預設顯示Code"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(476, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "多選"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(359, 154)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UclBtnCodeQueryUI3
        '
        Me.UclBtnCodeQueryUI3.Location = New System.Drawing.Point(703, 232)
        Me.UclBtnCodeQueryUI3.Margin = New System.Windows.Forms.Padding(4)
        Me.UclBtnCodeQueryUI3.Name = "UclBtnCodeQueryUI3"
        Me.UclBtnCodeQueryUI3.Size = New System.Drawing.Size(29, 27)
        Me.UclBtnCodeQueryUI3.TabIndex = 22
        Me.UclBtnCodeQueryUI3.uclBtnText = "..."
        Me.UclBtnCodeQueryUI3.uclEnableQueryList = True
        Me.UclBtnCodeQueryUI3.uclIsCheckDoctorOnDuty = False
        Me.UclBtnCodeQueryUI3.uclIsReturnDS = False
        Me.UclBtnCodeQueryUI3.uclQueryValue = Nothing
        Me.UclBtnCodeQueryUI3.uclRefHosp = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclRefHospData.All
        Me.UclBtnCodeQueryUI3.uclSelectType = Syscom.Client.ucl.UCLBtnCodeQueryUI.SelectType.MultiSelect
        Me.UclBtnCodeQueryUI3.uclTableName = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclQueryTable.PUB_Department
        Me.UclBtnCodeQueryUI3.uclXPosition = 225
        Me.UclBtnCodeQueryUI3.uclYPosition = 120
        '
        'UclListBoxUI1
        '
        Me.UclListBoxUI1.Location = New System.Drawing.Point(479, 232)
        Me.UclListBoxUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclListBoxUI1.Name = "UclListBoxUI1"
        Me.UclListBoxUI1.Size = New System.Drawing.Size(217, 132)
        Me.UclListBoxUI1.TabIndex = 21
        Me.UclListBoxUI1.uclCodeFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclItemShowFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclNameFieldIndexStr = Nothing
        Me.UclListBoxUI1.uclNonSelectedItemIndex = ""
        Me.UclListBoxUI1.uclSelectedItemIndex = ""
        Me.UclListBoxUI1.uclSelectionMode = Syscom.Client.ucl.UCLListBoxUI.uclSelectionStyle.One
        Me.UclListBoxUI1.uclSeparator = Syscom.Client.ucl.UCLListBoxUI.uclSeparatorType.OneSpace_Dash_OneSpace
        '
        'UclCheckListBoxUI1
        '
        Me.UclCheckListBoxUI1.Location = New System.Drawing.Point(479, 37)
        Me.UclCheckListBoxUI1.Margin = New System.Windows.Forms.Padding(4)
        Me.UclCheckListBoxUI1.Name = "UclCheckListBoxUI1"
        Me.UclCheckListBoxUI1.SelectedIndex = -1
        Me.UclCheckListBoxUI1.Size = New System.Drawing.Size(217, 165)
        Me.UclCheckListBoxUI1.TabIndex = 18
        Me.UclCheckListBoxUI1.uclCodeFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclDataSource = Nothing
        Me.UclCheckListBoxUI1.uclItemShowFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclNameFieldIndexStr = ""
        Me.UclCheckListBoxUI1.uclNonSelectedItemIndex = ""
        Me.UclCheckListBoxUI1.uclSelectedItemIndex = ""
        Me.UclCheckListBoxUI1.uclSeparator = Syscom.Client.ucl.UCLCheckListBoxUI.uclSeparatorType.OneSpace_Dash_OneSpace
        '
        'UclBtnCodeQueryUI2
        '
        Me.UclBtnCodeQueryUI2.Location = New System.Drawing.Point(704, 37)
        Me.UclBtnCodeQueryUI2.Margin = New System.Windows.Forms.Padding(4)
        Me.UclBtnCodeQueryUI2.Name = "UclBtnCodeQueryUI2"
        Me.UclBtnCodeQueryUI2.Size = New System.Drawing.Size(29, 27)
        Me.UclBtnCodeQueryUI2.TabIndex = 17
        Me.UclBtnCodeQueryUI2.uclBtnText = "..."
        Me.UclBtnCodeQueryUI2.uclEnableQueryList = True
        Me.UclBtnCodeQueryUI2.uclIsCheckDoctorOnDuty = False
        Me.UclBtnCodeQueryUI2.uclIsReturnDS = False
        Me.UclBtnCodeQueryUI2.uclQueryValue = Nothing
        Me.UclBtnCodeQueryUI2.uclRefHosp = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclRefHospData.All
        Me.UclBtnCodeQueryUI2.uclSelectType = Syscom.Client.ucl.UCLBtnCodeQueryUI.SelectType.MultiSelect
        Me.UclBtnCodeQueryUI2.uclTableName = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclQueryTable.PUB_Department
        Me.UclBtnCodeQueryUI2.uclXPosition = 225
        Me.UclBtnCodeQueryUI2.uclYPosition = 120
        '
        'UclTextCodeQueryUI2
        '
        Me.UclTextCodeQueryUI2.doFlag = True
        Me.UclTextCodeQueryUI2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclTextCodeQueryUI2.Location = New System.Drawing.Point(47, 264)
        Me.UclTextCodeQueryUI2.Margin = New System.Windows.Forms.Padding(0)
        Me.UclTextCodeQueryUI2.Name = "UclTextCodeQueryUI2"
        Me.UclTextCodeQueryUI2.Size = New System.Drawing.Size(162, 26)
        Me.UclTextCodeQueryUI2.TabIndex = 8
        Me.UclTextCodeQueryUI2.uclCboWidth = 126
        Me.UclTextCodeQueryUI2.uclCodeName = ""
        Me.UclTextCodeQueryUI2.uclCodeValue1 = ""
        Me.UclTextCodeQueryUI2.uclCodeValue2 = ""
        Me.UclTextCodeQueryUI2.uclControlFlag = True
        Me.UclTextCodeQueryUI2.uclDisplayIndex = "0,1"
        Me.UclTextCodeQueryUI2.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.UclTextCodeQueryUI2.uclIsCheckDoctorOnDuty = False
        Me.UclTextCodeQueryUI2.uclIsReturnDS = False
        Me.UclTextCodeQueryUI2.uclIsShowMsgBox = True
        Me.UclTextCodeQueryUI2.uclIsTextAutoClear = True
        Me.UclTextCodeQueryUI2.uclQueryValue = Nothing
        Me.UclTextCodeQueryUI2.uclRefHosp = Syscom.Client.ucl.UCLTextCodeQueryUI.uclRefHospData.All
        Me.UclTextCodeQueryUI2.uclTableName = Syscom.Client.ucl.UCLTextCodeQueryUI.uclQueryTable.OPH_Pharmacy_Base
        Me.UclTextCodeQueryUI2.uclTextBoxShow = Syscom.Client.ucl.UCLTextCodeQueryUI.ShowText.Name
        Me.UclTextCodeQueryUI2.uclXPosition = 225
        Me.UclTextCodeQueryUI2.uclYPosition = 120
        '
        'UclBtnCodeQueryUI1
        '
        Me.UclBtnCodeQueryUI1.Location = New System.Drawing.Point(26, 37)
        Me.UclBtnCodeQueryUI1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.UclBtnCodeQueryUI1.Name = "UclBtnCodeQueryUI1"
        Me.UclBtnCodeQueryUI1.Size = New System.Drawing.Size(29, 27)
        Me.UclBtnCodeQueryUI1.TabIndex = 2
        Me.UclBtnCodeQueryUI1.uclBtnText = "..."
        Me.UclBtnCodeQueryUI1.uclEnableQueryList = True
        Me.UclBtnCodeQueryUI1.uclIsCheckDoctorOnDuty = False
        Me.UclBtnCodeQueryUI1.uclIsReturnDS = False
        Me.UclBtnCodeQueryUI1.uclQueryValue = Nothing
        Me.UclBtnCodeQueryUI1.uclRefHosp = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclRefHospData.All
        Me.UclBtnCodeQueryUI1.uclSelectType = Syscom.Client.ucl.UCLBtnCodeQueryUI.SelectType.SingleSelect
        Me.UclBtnCodeQueryUI1.uclTableName = Syscom.Client.ucl.UCLBtnCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.UclBtnCodeQueryUI1.uclXPosition = 225
        Me.UclBtnCodeQueryUI1.uclYPosition = 120
        '
        'UclTextCodeQueryUI1
        '
        Me.UclTextCodeQueryUI1.doFlag = True
        Me.UclTextCodeQueryUI1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclTextCodeQueryUI1.Location = New System.Drawing.Point(47, 151)
        Me.UclTextCodeQueryUI1.Margin = New System.Windows.Forms.Padding(0)
        Me.UclTextCodeQueryUI1.Name = "UclTextCodeQueryUI1"
        Me.UclTextCodeQueryUI1.Size = New System.Drawing.Size(152, 26)
        Me.UclTextCodeQueryUI1.TabIndex = 0
        Me.UclTextCodeQueryUI1.uclCboWidth = 116
        Me.UclTextCodeQueryUI1.uclCodeName = ""
        Me.UclTextCodeQueryUI1.uclCodeValue1 = ""
        Me.UclTextCodeQueryUI1.uclCodeValue2 = ""
        Me.UclTextCodeQueryUI1.uclControlFlag = True
        Me.UclTextCodeQueryUI1.uclDisplayIndex = "0,1"
        Me.UclTextCodeQueryUI1.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.UclTextCodeQueryUI1.uclIsCheckDoctorOnDuty = False
        Me.UclTextCodeQueryUI1.uclIsReturnDS = False
        Me.UclTextCodeQueryUI1.uclIsShowMsgBox = True
        Me.UclTextCodeQueryUI1.uclIsTextAutoClear = True
        Me.UclTextCodeQueryUI1.uclQueryValue = "D"
        Me.UclTextCodeQueryUI1.uclRefHosp = Syscom.Client.ucl.UCLTextCodeQueryUI.uclRefHospData.All
        Me.UclTextCodeQueryUI1.uclTableName = Syscom.Client.ucl.UCLTextCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.UclTextCodeQueryUI1.uclTextBoxShow = Syscom.Client.ucl.UCLTextCodeQueryUI.ShowText.Name
        Me.UclTextCodeQueryUI1.uclXPosition = 225
        Me.UclTextCodeQueryUI1.uclYPosition = 120
        '
        'UCLTextCodeQueryUISample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 393)
        Me.Controls.Add(Me.UclBtnCodeQueryUI3)
        Me.Controls.Add(Me.UclListBoxUI1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.UclCheckListBoxUI1)
        Me.Controls.Add(Me.UclBtnCodeQueryUI2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.UclTextCodeQueryUI2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UclBtnCodeQueryUI1)
        Me.Controls.Add(Me.UclTextCodeQueryUI1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLTextCodeQueryUISample"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UclTextCodeQueryUI1 As Syscom.Client.ucl.UCLTextCodeQueryUI
    Friend WithEvents UclBtnCodeQueryUI1 As Syscom.Client.ucl.UCLBtnCodeQueryUI
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UclTextCodeQueryUI2 As Syscom.Client.ucl.UCLTextCodeQueryUI
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UclBtnCodeQueryUI2 As Syscom.Client.ucl.UCLBtnCodeQueryUI
    Friend WithEvents UclCheckListBoxUI1 As Syscom.Client.ucl.UCLCheckListBoxUI
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UclListBoxUI1 As Syscom.Client.ucl.UCLListBoxUI
    Friend WithEvents UclBtnCodeQueryUI3 As Syscom.Client.ucl.UCLBtnCodeQueryUI
End Class
