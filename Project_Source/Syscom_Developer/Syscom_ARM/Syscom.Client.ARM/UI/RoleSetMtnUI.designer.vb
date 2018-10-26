<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoleSetMtnUI

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
        Me.bt_ok = New System.Windows.Forms.Button
        Me.bt_cancel = New System.Windows.Forms.Button
        Me.lbl_userID = New System.Windows.Forms.Label
        Me.lbl_userName = New System.Windows.Forms.Label
        Me.txt_userName = New System.Windows.Forms.TextBox
        Me.txt_userID = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.tree_Review = New Syscom.Client.UCL.UCLTreeViewAdvUC
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt_ok
        '
        Me.bt_ok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_ok.Location = New System.Drawing.Point(136, 479)
        Me.bt_ok.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bt_ok.Name = "bt_ok"
        Me.bt_ok.Size = New System.Drawing.Size(75, 27)
        Me.bt_ok.TabIndex = 6
        Me.bt_ok.Text = "確定"
        '
        'bt_cancel
        '
        Me.bt_cancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cancel.Location = New System.Drawing.Point(257, 479)
        Me.bt_cancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(75, 27)
        Me.bt_cancel.TabIndex = 7
        Me.bt_cancel.Text = "取消"
        '
        'lbl_userID
        '
        Me.lbl_userID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_userID.AutoSize = True
        Me.lbl_userID.Location = New System.Drawing.Point(18, 8)
        Me.lbl_userID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_userID.Name = "lbl_userID"
        Me.lbl_userID.Size = New System.Drawing.Size(88, 16)
        Me.lbl_userID.TabIndex = 8
        Me.lbl_userID.Text = "使用者代碼"
        '
        'lbl_userName
        '
        Me.lbl_userName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_userName.AutoSize = True
        Me.lbl_userName.Location = New System.Drawing.Point(260, 8)
        Me.lbl_userName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_userName.Name = "lbl_userName"
        Me.lbl_userName.Size = New System.Drawing.Size(88, 16)
        Me.lbl_userName.TabIndex = 9
        Me.lbl_userName.Text = "使用者名稱"
        '
        'txt_userName
        '
        Me.txt_userName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_userName.Location = New System.Drawing.Point(356, 3)
        Me.txt_userName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_userName.Name = "txt_userName"
        Me.txt_userName.ReadOnly = True
        Me.txt_userName.Size = New System.Drawing.Size(122, 27)
        Me.txt_userName.TabIndex = 10
        '
        'txt_userID
        '
        Me.txt_userID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_userID.Location = New System.Drawing.Point(114, 3)
        Me.txt_userID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_userID.Name = "txt_userID"
        Me.txt_userID.ReadOnly = True
        Me.txt_userID.Size = New System.Drawing.Size(120, 27)
        Me.txt_userID.TabIndex = 11
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tree_Review, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.bt_cancel, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_userName, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.bt_ok, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_userID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_userName, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_userID, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(508, 511)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'tree_Review
        '
        Me.tree_Review.AutoScroll = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.tree_Review, 4)
        Me.tree_Review.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tree_Review.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tree_Review.IsShowGroupCheckBox = False
        Me.tree_Review.Location = New System.Drawing.Point(4, 37)
        Me.tree_Review.Margin = New System.Windows.Forms.Padding(4)
        Me.tree_Review.Name = "tree_Review"
        Me.tree_Review.SelectedItemsResult = Nothing
        Me.tree_Review.SelectedResult = Nothing
        Me.tree_Review.SelectedTempItemsResult = Nothing
        Me.tree_Review.Size = New System.Drawing.Size(500, 433)
        Me.tree_Review.TabIndex = 12
        Me.tree_Review.TreeViewName = ""
        '
        'RoleSetMtnUI
        '
        Me.AcceptButton = Me.bt_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_cancel
        Me.ClientSize = New System.Drawing.Size(508, 511)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RoleSetMtnUI"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TabText = "歸屬角色"
        Me.Text = "歸屬角色"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt_ok As System.Windows.Forms.Button
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents lbl_userID As System.Windows.Forms.Label
    Friend WithEvents lbl_userName As System.Windows.Forms.Label
    Friend WithEvents txt_userName As System.Windows.Forms.TextBox
    Friend WithEvents txt_userID As System.Windows.Forms.TextBox
    Friend WithEvents tree_Review As Syscom.Client.UCL.UCLTreeViewAdvUC
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
