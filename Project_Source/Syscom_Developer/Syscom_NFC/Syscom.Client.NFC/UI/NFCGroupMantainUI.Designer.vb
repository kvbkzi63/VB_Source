<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NFCGroupMantainUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NFCGroupMantainUI))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grp_Group = New System.Windows.Forms.GroupBox()
        Me.txt_GroupID = New System.Windows.Forms.TextBox()
        Me.btn_DeleteGroup = New System.Windows.Forms.Button()
        Me.btn_SaveGroup = New System.Windows.Forms.Button()
        Me.txt_groupName = New System.Windows.Forms.TextBox()
        Me.uclCbo_NfcGroup = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.uclCbo_Dept = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_RemoveFromTree = New System.Windows.Forms.Button()
        Me.btn_AddFromTree = New System.Windows.Forms.Button()
        Me.Label_Station = New System.Windows.Forms.Label()
        Me.tre_MyPatient = New System.Windows.Forms.TreeView()
        Me.tre_Dept = New System.Windows.Forms.TreeView()
        Me.GroupBox2.SuspendLayout()
        Me.grp_Group.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grp_Group)
        Me.GroupBox2.Controls.Add(Me.uclCbo_NfcGroup)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btn_Clear)
        Me.GroupBox2.Controls.Add(Me.uclCbo_Dept)
        Me.GroupBox2.Controls.Add(Me.btn_Exit)
        Me.GroupBox2.Controls.Add(Me.btn_Save)
        Me.GroupBox2.Controls.Add(Me.btn_RemoveFromTree)
        Me.GroupBox2.Controls.Add(Me.btn_AddFromTree)
        Me.GroupBox2.Controls.Add(Me.Label_Station)
        Me.GroupBox2.Controls.Add(Me.tre_MyPatient)
        Me.GroupBox2.Controls.Add(Me.tre_Dept)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(919, 548)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'grp_Group
        '
        Me.grp_Group.Controls.Add(Me.txt_GroupID)
        Me.grp_Group.Controls.Add(Me.btn_DeleteGroup)
        Me.grp_Group.Controls.Add(Me.btn_SaveGroup)
        Me.grp_Group.Controls.Add(Me.txt_groupName)
        Me.grp_Group.Location = New System.Drawing.Point(682, 27)
        Me.grp_Group.Name = "grp_Group"
        Me.grp_Group.Size = New System.Drawing.Size(214, 153)
        Me.grp_Group.TabIndex = 15
        Me.grp_Group.TabStop = False
        Me.grp_Group.Text = "新增群組名稱"
        '
        'txt_GroupID
        '
        Me.txt_GroupID.Location = New System.Drawing.Point(8, 36)
        Me.txt_GroupID.Name = "txt_GroupID"
        Me.txt_GroupID.Size = New System.Drawing.Size(200, 27)
        Me.txt_GroupID.TabIndex = 3
        Me.txt_GroupID.Visible = False
        '
        'btn_DeleteGroup
        '
        Me.btn_DeleteGroup.Location = New System.Drawing.Point(102, 107)
        Me.btn_DeleteGroup.Name = "btn_DeleteGroup"
        Me.btn_DeleteGroup.Size = New System.Drawing.Size(75, 29)
        Me.btn_DeleteGroup.TabIndex = 2
        Me.btn_DeleteGroup.Text = "刪除"
        Me.btn_DeleteGroup.UseVisualStyleBackColor = True
        '
        'btn_SaveGroup
        '
        Me.btn_SaveGroup.Location = New System.Drawing.Point(14, 107)
        Me.btn_SaveGroup.Name = "btn_SaveGroup"
        Me.btn_SaveGroup.Size = New System.Drawing.Size(82, 29)
        Me.btn_SaveGroup.TabIndex = 1
        Me.btn_SaveGroup.Text = "存檔"
        Me.btn_SaveGroup.UseVisualStyleBackColor = True
        '
        'txt_groupName
        '
        Me.txt_groupName.Location = New System.Drawing.Point(8, 69)
        Me.txt_groupName.Name = "txt_groupName"
        Me.txt_groupName.Size = New System.Drawing.Size(202, 27)
        Me.txt_groupName.TabIndex = 0
        '
        'uclCbo_NfcGroup
        '
        Me.uclCbo_NfcGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.uclCbo_NfcGroup.DropDownWidth = 20
        Me.uclCbo_NfcGroup.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclCbo_NfcGroup.Location = New System.Drawing.Point(414, 23)
        Me.uclCbo_NfcGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.uclCbo_NfcGroup.Name = "uclCbo_NfcGroup"
        Me.uclCbo_NfcGroup.SelectedIndex = -1
        Me.uclCbo_NfcGroup.SelectedItem = Nothing
        Me.uclCbo_NfcGroup.SelectedText = ""
        Me.uclCbo_NfcGroup.SelectedValue = ""
        Me.uclCbo_NfcGroup.SelectionStart = 0
        Me.uclCbo_NfcGroup.Size = New System.Drawing.Size(261, 24)
        Me.uclCbo_NfcGroup.TabIndex = 13
        Me.uclCbo_NfcGroup.uclDisplayIndex = "0,1"
        Me.uclCbo_NfcGroup.uclIsAutoClear = True
        Me.uclCbo_NfcGroup.uclIsFirstItemEmpty = True
        Me.uclCbo_NfcGroup.uclIsTextMode = False
        Me.uclCbo_NfcGroup.uclShowMsg = False
        Me.uclCbo_NfcGroup.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(369, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "群組："
        '
        'btn_Clear
        '
        Me.btn_Clear.Location = New System.Drawing.Point(325, 442)
        Me.btn_Clear.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(82, 31)
        Me.btn_Clear.TabIndex = 9
        Me.btn_Clear.Text = "F5-清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'uclCbo_Dept
        '
        Me.uclCbo_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclCbo_Dept.DropDownWidth = 20
        Me.uclCbo_Dept.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclCbo_Dept.Location = New System.Drawing.Point(43, 23)
        Me.uclCbo_Dept.Margin = New System.Windows.Forms.Padding(0)
        Me.uclCbo_Dept.Name = "uclCbo_Dept"
        Me.uclCbo_Dept.SelectedIndex = -1
        Me.uclCbo_Dept.SelectedItem = Nothing
        Me.uclCbo_Dept.SelectedText = ""
        Me.uclCbo_Dept.SelectedValue = ""
        Me.uclCbo_Dept.SelectionStart = 0
        Me.uclCbo_Dept.Size = New System.Drawing.Size(271, 24)
        Me.uclCbo_Dept.TabIndex = 8
        Me.uclCbo_Dept.uclDisplayIndex = "0,1"
        Me.uclCbo_Dept.uclIsAutoClear = True
        Me.uclCbo_Dept.uclIsFirstItemEmpty = True
        Me.uclCbo_Dept.uclIsTextMode = False
        Me.uclCbo_Dept.uclShowMsg = False
        Me.uclCbo_Dept.uclValueIndex = "0"
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(414, 442)
        Me.btn_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(82, 31)
        Me.btn_Exit.TabIndex = 7
        Me.btn_Exit.Text = "離開"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(235, 442)
        Me.btn_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(82, 31)
        Me.btn_Save.TabIndex = 6
        Me.btn_Save.Text = "F12-儲存"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_RemoveFromTree
        '
        Me.btn_RemoveFromTree.Location = New System.Drawing.Point(322, 227)
        Me.btn_RemoveFromTree.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_RemoveFromTree.Name = "btn_RemoveFromTree"
        Me.btn_RemoveFromTree.Size = New System.Drawing.Size(84, 29)
        Me.btn_RemoveFromTree.TabIndex = 4
        Me.btn_RemoveFromTree.Text = "<-移除"
        Me.btn_RemoveFromTree.UseVisualStyleBackColor = True
        '
        'btn_AddFromTree
        '
        Me.btn_AddFromTree.Enabled = False
        Me.btn_AddFromTree.Location = New System.Drawing.Point(322, 190)
        Me.btn_AddFromTree.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_AddFromTree.Name = "btn_AddFromTree"
        Me.btn_AddFromTree.Size = New System.Drawing.Size(84, 29)
        Me.btn_AddFromTree.TabIndex = 3
        Me.btn_AddFromTree.Text = "加入->"
        Me.btn_AddFromTree.UseVisualStyleBackColor = True
        '
        'Label_Station
        '
        Me.Label_Station.AutoSize = True
        Me.Label_Station.Location = New System.Drawing.Point(-3, 27)
        Me.Label_Station.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Station.Name = "Label_Station"
        Me.Label_Station.Size = New System.Drawing.Size(56, 16)
        Me.Label_Station.TabIndex = 2
        Me.Label_Station.Text = "科室："
        '
        'tre_MyPatient
        '
        Me.tre_MyPatient.CheckBoxes = True
        Me.tre_MyPatient.Location = New System.Drawing.Point(414, 50)
        Me.tre_MyPatient.Margin = New System.Windows.Forms.Padding(4)
        Me.tre_MyPatient.Name = "tre_MyPatient"
        Me.tre_MyPatient.Size = New System.Drawing.Size(261, 375)
        Me.tre_MyPatient.TabIndex = 1
        '
        'tre_Dept
        '
        Me.tre_Dept.CheckBoxes = True
        Me.tre_Dept.Location = New System.Drawing.Point(43, 50)
        Me.tre_Dept.Margin = New System.Windows.Forms.Padding(4)
        Me.tre_Dept.Name = "tre_Dept"
        Me.tre_Dept.Size = New System.Drawing.Size(271, 375)
        Me.tre_Dept.TabIndex = 0
        '
        'NFCGroupMantainUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 475)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "NFCGroupMantainUI"
        Me.TabText = "NFCGroupMantainUI"
        Me.Text = "NFCGroupMantainUI"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grp_Group.ResumeLayout(False)
        Me.grp_Group.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents uclCbo_NfcGroup As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
    Friend WithEvents uclCbo_Dept As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromTree As System.Windows.Forms.Button
    Friend WithEvents btn_AddFromTree As System.Windows.Forms.Button
    Friend WithEvents Label_Station As System.Windows.Forms.Label
    Friend WithEvents tre_MyPatient As System.Windows.Forms.TreeView
    Friend WithEvents tre_Dept As System.Windows.Forms.TreeView
    Friend WithEvents grp_Group As System.Windows.Forms.GroupBox
    Friend WithEvents btn_DeleteGroup As System.Windows.Forms.Button
    Friend WithEvents btn_SaveGroup As System.Windows.Forms.Button
    Friend WithEvents txt_groupName As System.Windows.Forms.TextBox
    Friend WithEvents txt_GroupID As System.Windows.Forms.TextBox
End Class
