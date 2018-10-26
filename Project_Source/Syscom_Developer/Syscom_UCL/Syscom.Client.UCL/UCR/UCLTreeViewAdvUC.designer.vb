<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLTreeViewAdvUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.tre_TreeViewAdv = New System.Windows.Forms.TreeView
        Me.pal_Condition = New System.Windows.Forms.Panel
        Me.chk_Group = New System.Windows.Forms.CheckBox
        Me.pal_Condition.SuspendLayout()
        Me.SuspendLayout()
        '
        'tre_TreeViewAdv
        '
        Me.tre_TreeViewAdv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tre_TreeViewAdv.Location = New System.Drawing.Point(0, 23)
        Me.tre_TreeViewAdv.Name = "tre_TreeViewAdv"
        Me.tre_TreeViewAdv.ShowNodeToolTips = True
        Me.tre_TreeViewAdv.Size = New System.Drawing.Size(283, 373)
        Me.tre_TreeViewAdv.TabIndex = 0
        '
        'pal_Condition
        '
        Me.pal_Condition.Controls.Add(Me.chk_Group)
        Me.pal_Condition.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Condition.Location = New System.Drawing.Point(0, 0)
        Me.pal_Condition.Name = "pal_Condition"
        Me.pal_Condition.Size = New System.Drawing.Size(283, 23)
        Me.pal_Condition.TabIndex = 1
        '
        'chk_Group
        '
        Me.chk_Group.AutoSize = True
        Me.chk_Group.Font = New System.Drawing.Font("標楷體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.chk_Group.ForeColor = System.Drawing.Color.Blue
        Me.chk_Group.Location = New System.Drawing.Point(3, 3)
        Me.chk_Group.Name = "chk_Group"
        Me.chk_Group.Size = New System.Drawing.Size(128, 19)
        Me.chk_Group.TabIndex = 0
        Me.chk_Group.Text = "選取相同項目"
        Me.chk_Group.UseVisualStyleBackColor = True
        '
        'TreeViewAdvUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.tre_TreeViewAdv)
        Me.Controls.Add(Me.pal_Condition)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "TreeViewAdvUC"
        Me.Size = New System.Drawing.Size(283, 396)
        Me.pal_Condition.ResumeLayout(False)
        Me.pal_Condition.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pal_Condition As System.Windows.Forms.Panel
    Public WithEvents chk_Group As System.Windows.Forms.CheckBox
    Public WithEvents tre_TreeViewAdv As System.Windows.Forms.TreeView

End Class
