<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubAccDeptUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbt_IsCollectno = New System.Windows.Forms.RadioButton()
        Me.rbt_IsCollectyes = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbt_IsPrimaryno = New System.Windows.Forms.RadioButton()
        Me.rbt_IsPrimaryyes = New System.Windows.Forms.RadioButton()
        Me.lbl_IsCollect = New System.Windows.Forms.Label()
        Me.lbl_IsPrimary = New System.Windows.Forms.Label()
        Me.txt_AccClassId = New System.Windows.Forms.TextBox()
        Me.lbl_AccClassId = New System.Windows.Forms.Label()
        Me.txt_AccLevelSame = New System.Windows.Forms.TextBox()
        Me.lbl_AccLevelSame = New System.Windows.Forms.Label()
        Me.txt_AccLevel = New System.Windows.Forms.TextBox()
        Me.lbl_AccLevel = New System.Windows.Forms.Label()
        Me.txt_AccDeptTypeId = New System.Windows.Forms.TextBox()
        Me.lbl_AccDeptTypeId = New System.Windows.Forms.Label()
        Me.txt_AccDeptUpper = New System.Windows.Forms.TextBox()
        Me.lbl_AccDeptUpper = New System.Windows.Forms.Label()
        Me.txt_AccDeptName = New System.Windows.Forms.TextBox()
        Me.lbl_AccDeptName = New System.Windows.Forms.Label()
        Me.txt_AccDept = New System.Windows.Forms.TextBox()
        Me.lbl_AccDept = New System.Windows.Forms.Label()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 187)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 454)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 417)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 417)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbt_IsCollectno)
        Me.Panel3.Controls.Add(Me.rbt_IsCollectyes)
        Me.Panel3.Location = New System.Drawing.Point(476, 112)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(108, 35)
        Me.Panel3.TabIndex = 49
        '
        'rbt_IsCollectno
        '
        Me.rbt_IsCollectno.AutoSize = True
        Me.rbt_IsCollectno.Location = New System.Drawing.Point(58, 10)
        Me.rbt_IsCollectno.Name = "rbt_IsCollectno"
        Me.rbt_IsCollectno.Size = New System.Drawing.Size(42, 20)
        Me.rbt_IsCollectno.TabIndex = 48
        Me.rbt_IsCollectno.TabStop = True
        Me.rbt_IsCollectno.Text = "否"
        Me.rbt_IsCollectno.UseVisualStyleBackColor = True
        '
        'rbt_IsCollectyes
        '
        Me.rbt_IsCollectyes.AutoSize = True
        Me.rbt_IsCollectyes.Location = New System.Drawing.Point(3, 10)
        Me.rbt_IsCollectyes.Name = "rbt_IsCollectyes"
        Me.rbt_IsCollectyes.Size = New System.Drawing.Size(42, 20)
        Me.rbt_IsCollectyes.TabIndex = 47
        Me.rbt_IsCollectyes.TabStop = True
        Me.rbt_IsCollectyes.Text = "是"
        Me.rbt_IsCollectyes.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbt_IsPrimaryno)
        Me.Panel2.Controls.Add(Me.rbt_IsPrimaryyes)
        Me.Panel2.Location = New System.Drawing.Point(476, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(108, 37)
        Me.Panel2.TabIndex = 48
        '
        'rbt_IsPrimaryno
        '
        Me.rbt_IsPrimaryno.AutoSize = True
        Me.rbt_IsPrimaryno.Location = New System.Drawing.Point(58, 10)
        Me.rbt_IsPrimaryno.Name = "rbt_IsPrimaryno"
        Me.rbt_IsPrimaryno.Size = New System.Drawing.Size(42, 20)
        Me.rbt_IsPrimaryno.TabIndex = 48
        Me.rbt_IsPrimaryno.TabStop = True
        Me.rbt_IsPrimaryno.Text = "否"
        Me.rbt_IsPrimaryno.UseVisualStyleBackColor = True
        '
        'rbt_IsPrimaryyes
        '
        Me.rbt_IsPrimaryyes.AutoSize = True
        Me.rbt_IsPrimaryyes.Location = New System.Drawing.Point(3, 10)
        Me.rbt_IsPrimaryyes.Name = "rbt_IsPrimaryyes"
        Me.rbt_IsPrimaryyes.Size = New System.Drawing.Size(42, 20)
        Me.rbt_IsPrimaryyes.TabIndex = 47
        Me.rbt_IsPrimaryyes.TabStop = True
        Me.rbt_IsPrimaryyes.Text = "是"
        Me.rbt_IsPrimaryyes.UseVisualStyleBackColor = True
        '
        'lbl_IsCollect
        '
        Me.lbl_IsCollect.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_IsCollect.AutoSize = True
        Me.lbl_IsCollect.Location = New System.Drawing.Point(334, 121)
        Me.lbl_IsCollect.Name = "lbl_IsCollect"
        Me.lbl_IsCollect.Size = New System.Drawing.Size(136, 16)
        Me.lbl_IsCollect.TabIndex = 47
        Me.lbl_IsCollect.Text = "是否彙總成本中心"
        '
        'lbl_IsPrimary
        '
        Me.lbl_IsPrimary.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_IsPrimary.AutoSize = True
        Me.lbl_IsPrimary.Location = New System.Drawing.Point(366, 79)
        Me.lbl_IsPrimary.Name = "lbl_IsPrimary"
        Me.lbl_IsPrimary.Size = New System.Drawing.Size(104, 16)
        Me.lbl_IsPrimary.TabIndex = 46
        Me.lbl_IsPrimary.Text = "是否基層單位"
        '
        'txt_AccClassId
        '
        Me.txt_AccClassId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccClassId.Location = New System.Drawing.Point(476, 36)
        Me.txt_AccClassId.MaxLength = 5
        Me.txt_AccClassId.Name = "txt_AccClassId"
        Me.txt_AccClassId.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccClassId.TabIndex = 45
        '
        'lbl_AccClassId
        '
        Me.lbl_AccClassId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccClassId.AutoSize = True
        Me.lbl_AccClassId.Location = New System.Drawing.Point(398, 41)
        Me.lbl_AccClassId.Name = "lbl_AccClassId"
        Me.lbl_AccClassId.Size = New System.Drawing.Size(72, 16)
        Me.lbl_AccClassId.TabIndex = 44
        Me.lbl_AccClassId.Text = "歸屬類別"
        '
        'txt_AccLevelSame
        '
        Me.txt_AccLevelSame.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccLevelSame.Location = New System.Drawing.Point(476, 3)
        Me.txt_AccLevelSame.MaxLength = 5
        Me.txt_AccLevelSame.Name = "txt_AccLevelSame"
        Me.txt_AccLevelSame.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccLevelSame.TabIndex = 43
        '
        'lbl_AccLevelSame
        '
        Me.lbl_AccLevelSame.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccLevelSame.AutoSize = True
        Me.lbl_AccLevelSame.Location = New System.Drawing.Point(382, 8)
        Me.lbl_AccLevelSame.Name = "lbl_AccLevelSame"
        Me.lbl_AccLevelSame.Size = New System.Drawing.Size(88, 16)
        Me.lbl_AccLevelSame.TabIndex = 42
        Me.lbl_AccLevelSame.Text = "同層級代碼"
        '
        'txt_AccLevel
        '
        Me.txt_AccLevel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccLevel.Location = New System.Drawing.Point(113, 155)
        Me.txt_AccLevel.MaxLength = 5
        Me.txt_AccLevel.Name = "txt_AccLevel"
        Me.txt_AccLevel.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccLevel.TabIndex = 41
        '
        'lbl_AccLevel
        '
        Me.lbl_AccLevel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccLevel.AutoSize = True
        Me.lbl_AccLevel.Location = New System.Drawing.Point(35, 160)
        Me.lbl_AccLevel.Name = "lbl_AccLevel"
        Me.lbl_AccLevel.Size = New System.Drawing.Size(72, 16)
        Me.lbl_AccLevel.TabIndex = 40
        Me.lbl_AccLevel.Text = "分攤層級"
        '
        'txt_AccDeptTypeId
        '
        Me.txt_AccDeptTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccDeptTypeId.Location = New System.Drawing.Point(113, 116)
        Me.txt_AccDeptTypeId.MaxLength = 5
        Me.txt_AccDeptTypeId.Name = "txt_AccDeptTypeId"
        Me.txt_AccDeptTypeId.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccDeptTypeId.TabIndex = 39
        '
        'lbl_AccDeptTypeId
        '
        Me.lbl_AccDeptTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccDeptTypeId.AutoSize = True
        Me.lbl_AccDeptTypeId.Location = New System.Drawing.Point(3, 121)
        Me.lbl_AccDeptTypeId.Name = "lbl_AccDeptTypeId"
        Me.lbl_AccDeptTypeId.Size = New System.Drawing.Size(104, 16)
        Me.lbl_AccDeptTypeId.TabIndex = 38
        Me.lbl_AccDeptTypeId.Text = "成本中心類別"
        '
        'txt_AccDeptUpper
        '
        Me.txt_AccDeptUpper.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccDeptUpper.Location = New System.Drawing.Point(113, 74)
        Me.txt_AccDeptUpper.MaxLength = 6
        Me.txt_AccDeptUpper.Name = "txt_AccDeptUpper"
        Me.txt_AccDeptUpper.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccDeptUpper.TabIndex = 37
        '
        'lbl_AccDeptUpper
        '
        Me.lbl_AccDeptUpper.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccDeptUpper.AutoSize = True
        Me.lbl_AccDeptUpper.Location = New System.Drawing.Point(3, 79)
        Me.lbl_AccDeptUpper.Name = "lbl_AccDeptUpper"
        Me.lbl_AccDeptUpper.Size = New System.Drawing.Size(104, 16)
        Me.lbl_AccDeptUpper.TabIndex = 36
        Me.lbl_AccDeptUpper.Text = "上層成本中心"
        '
        'txt_AccDeptName
        '
        Me.txt_AccDeptName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccDeptName.Location = New System.Drawing.Point(113, 36)
        Me.txt_AccDeptName.MaxLength = 100
        Me.txt_AccDeptName.Name = "txt_AccDeptName"
        Me.txt_AccDeptName.Size = New System.Drawing.Size(215, 27)
        Me.txt_AccDeptName.TabIndex = 35
        '
        'lbl_AccDeptName
        '
        Me.lbl_AccDeptName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccDeptName.AutoSize = True
        Me.lbl_AccDeptName.Location = New System.Drawing.Point(67, 41)
        Me.lbl_AccDeptName.Name = "lbl_AccDeptName"
        Me.lbl_AccDeptName.Size = New System.Drawing.Size(40, 16)
        Me.lbl_AccDeptName.TabIndex = 34
        Me.lbl_AccDeptName.Text = "名稱"
        '
        'txt_AccDept
        '
        Me.txt_AccDept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AccDept.Location = New System.Drawing.Point(113, 3)
        Me.txt_AccDept.MaxLength = 6
        Me.txt_AccDept.Name = "txt_AccDept"
        Me.txt_AccDept.Size = New System.Drawing.Size(100, 27)
        Me.txt_AccDept.TabIndex = 33
        '
        'lbl_AccDept
        '
        Me.lbl_AccDept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_AccDept.AutoSize = True
        Me.lbl_AccDept.Location = New System.Drawing.Point(35, 8)
        Me.lbl_AccDept.Name = "lbl_AccDept"
        Me.lbl_AccDept.Size = New System.Drawing.Size(72, 16)
        Me.lbl_AccDept.TabIndex = 32
        Me.lbl_AccDept.Text = "成本中心"
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Panel3, 3, 3)
        Me.tlp_Main.Controls.Add(Me.lbl_AccDept, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Panel2, 3, 2)
        Me.tlp_Main.Controls.Add(Me.txt_AccDept, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_AccLevel, 1, 4)
        Me.tlp_Main.Controls.Add(Me.txt_AccClassId, 3, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_IsCollect, 2, 3)
        Me.tlp_Main.Controls.Add(Me.lbl_AccLevelSame, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_IsPrimary, 2, 2)
        Me.tlp_Main.Controls.Add(Me.txt_AccLevelSame, 3, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_AccDeptName, 0, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_AccClassId, 2, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_AccDeptUpper, 0, 2)
        Me.tlp_Main.Controls.Add(Me.lbl_AccDeptTypeId, 0, 3)
        Me.tlp_Main.Controls.Add(Me.txt_AccDeptTypeId, 1, 3)
        Me.tlp_Main.Controls.Add(Me.lbl_AccLevel, 0, 4)
        Me.tlp_Main.Controls.Add(Me.txt_AccDeptUpper, 1, 2)
        Me.tlp_Main.Controls.Add(Me.txt_AccDeptName, 1, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 5
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 187)
        Me.tlp_Main.TabIndex = 1
        '
        'PubAccDeptUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PubAccDeptUI"
        Me.Text = "PubAccDeptUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbt_IsCollectno As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_IsCollectyes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbt_IsPrimaryno As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_IsPrimaryyes As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_IsCollect As System.Windows.Forms.Label
    Friend WithEvents lbl_IsPrimary As System.Windows.Forms.Label
    Friend WithEvents txt_AccClassId As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccClassId As System.Windows.Forms.Label
    Friend WithEvents txt_AccLevelSame As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccLevelSame As System.Windows.Forms.Label
    Friend WithEvents txt_AccLevel As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccLevel As System.Windows.Forms.Label
    Friend WithEvents txt_AccDeptTypeId As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccDeptTypeId As System.Windows.Forms.Label
    Friend WithEvents txt_AccDeptUpper As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccDeptUpper As System.Windows.Forms.Label
    Friend WithEvents txt_AccDeptName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccDeptName As System.Windows.Forms.Label
    Friend WithEvents txt_AccDept As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AccDept As System.Windows.Forms.Label
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
End Class
