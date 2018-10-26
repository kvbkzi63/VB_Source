<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyFavoritesUI
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
        Me.Btn_Insert = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Close = New System.Windows.Forms.Button()
        Me.Txt_UserProfile = New System.Windows.Forms.TextBox()
        Me.Chk_List = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Chk_Default = New System.Windows.Forms.CheckBox()
        Me.Btn_UpDefault = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_Insert
        '
        Me.Btn_Insert.Location = New System.Drawing.Point(-2, -1)
        Me.Btn_Insert.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Insert.Name = "Btn_Insert"
        Me.Btn_Insert.Size = New System.Drawing.Size(125, 31)
        Me.Btn_Insert.TabIndex = 0
        Me.Btn_Insert.Text = "加入我的最愛"
        Me.ToolTip1.SetToolTip(Me.Btn_Insert, "將下面文字方塊名稱,點選[加入我的最愛]儲存成我的最愛")
        Me.Btn_Insert.UseVisualStyleBackColor = True
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Location = New System.Drawing.Point(131, -1)
        Me.Btn_Delete.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(116, 31)
        Me.Btn_Delete.TabIndex = 1
        Me.Btn_Delete.Text = "刪除我的最愛"
        Me.ToolTip1.SetToolTip(Me.Btn_Delete, "從下面清單中點選我的最愛名稱,點選[刪除我的最愛]")
        Me.Btn_Delete.UseVisualStyleBackColor = True
        '
        'Btn_Close
        '
        Me.Btn_Close.Location = New System.Drawing.Point(255, -1)
        Me.Btn_Close.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Close.Name = "Btn_Close"
        Me.Btn_Close.Size = New System.Drawing.Size(80, 31)
        Me.Btn_Close.TabIndex = 3
        Me.Btn_Close.Text = "關閉"
        Me.Btn_Close.UseVisualStyleBackColor = True
        '
        'Txt_UserProfile
        '
        Me.Txt_UserProfile.Location = New System.Drawing.Point(51, 37)
        Me.Txt_UserProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_UserProfile.Name = "Txt_UserProfile"
        Me.Txt_UserProfile.Size = New System.Drawing.Size(196, 27)
        Me.Txt_UserProfile.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.Txt_UserProfile, "輸入我的最愛名稱,點選[加入我的最愛]儲存目前開啟作業到我的最愛")
        '
        'Chk_List
        '
        Me.Chk_List.FormattingEnabled = True
        Me.Chk_List.ItemHeight = 16
        Me.Chk_List.Location = New System.Drawing.Point(3, 119)
        Me.Chk_List.Name = "Chk_List"
        Me.Chk_List.Size = New System.Drawing.Size(332, 404)
        Me.Chk_List.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.Chk_List, "點選兩下即可開啟我的最愛,點選一下將我的最愛帶到上方文字方塊中工加入或刪除")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "輸入:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "滑鼠點兩下即可開啟我的最愛"
        '
        'Chk_Default
        '
        Me.Chk_Default.AutoSize = True
        Me.Chk_Default.Location = New System.Drawing.Point(254, 44)
        Me.Chk_Default.Name = "Chk_Default"
        Me.Chk_Default.Size = New System.Drawing.Size(59, 20)
        Me.Chk_Default.TabIndex = 8
        Me.Chk_Default.Text = "預設"
        Me.Chk_Default.UseVisualStyleBackColor = True
        '
        'Btn_UpDefault
        '
        Me.Btn_UpDefault.Location = New System.Drawing.Point(248, 70)
        Me.Btn_UpDefault.Name = "Btn_UpDefault"
        Me.Btn_UpDefault.Size = New System.Drawing.Size(87, 26)
        Me.Btn_UpDefault.TabIndex = 9
        Me.Btn_UpDefault.Text = "變更預設"
        Me.Btn_UpDefault.UseVisualStyleBackColor = True
        '
        'MyFavoritesUI
        '
        Me.AllowEndUserDocking = False
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(337, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btn_UpDefault)
        Me.Controls.Add(Me.Chk_Default)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chk_List)
        Me.Controls.Add(Me.Txt_UserProfile)
        Me.Controls.Add(Me.Btn_Close)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Insert)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MyFavoritesUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "MyFavoritesUI"
        Me.Text = "MyFavoritesUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Insert As System.Windows.Forms.Button
    Friend WithEvents Btn_Delete As System.Windows.Forms.Button
    Friend WithEvents Btn_Close As System.Windows.Forms.Button
    Friend WithEvents Txt_UserProfile As System.Windows.Forms.TextBox
    Friend WithEvents Chk_List As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Chk_Default As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_UpDefault As System.Windows.Forms.Button
End Class
