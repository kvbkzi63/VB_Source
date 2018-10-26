<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSource = New System.Windows.Forms.Button()
        Me.btnGO = New System.Windows.Forms.Button()
        Me.btnTarget = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tbxTarget = New System.Windows.Forms.TextBox()
        Me.tbxSource = New System.Windows.Forms.TextBox()
        Me.lbxSource = New System.Windows.Forms.ListBox()
        Me.lbxTarget = New System.Windows.Forms.ListBox()
        Me.lbxDifferent = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(519, 77)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSource.TabIndex = 0
        Me.btnSource.Text = "Source"
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'btnGO
        '
        Me.btnGO.Location = New System.Drawing.Point(25, 258)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(710, 23)
        Me.btnGO.TabIndex = 1
        Me.btnGO.Text = "GO"
        Me.btnGO.UseVisualStyleBackColor = True
        '
        'btnTarget
        '
        Me.btnTarget.Location = New System.Drawing.Point(1072, 77)
        Me.btnTarget.Name = "btnTarget"
        Me.btnTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnTarget.TabIndex = 2
        Me.btnTarget.Text = "Tag"
        Me.btnTarget.UseVisualStyleBackColor = True
        '
        'tbxTarget
        '
        Me.tbxTarget.Location = New System.Drawing.Point(795, 76)
        Me.tbxTarget.Name = "tbxTarget"
        Me.tbxTarget.Size = New System.Drawing.Size(271, 22)
        Me.tbxTarget.TabIndex = 3
        '
        'tbxSource
        '
        Me.tbxSource.Location = New System.Drawing.Point(25, 86)
        Me.tbxSource.Name = "tbxSource"
        Me.tbxSource.Size = New System.Drawing.Size(271, 22)
        Me.tbxSource.TabIndex = 4
        '
        'lbxSource
        '
        Me.lbxSource.FormattingEnabled = True
        Me.lbxSource.ItemHeight = 12
        Me.lbxSource.Location = New System.Drawing.Point(25, 114)
        Me.lbxSource.Name = "lbxSource"
        Me.lbxSource.Size = New System.Drawing.Size(748, 124)
        Me.lbxSource.TabIndex = 5
        '
        'lbxTarget
        '
        Me.lbxTarget.FormattingEnabled = True
        Me.lbxTarget.ItemHeight = 12
        Me.lbxTarget.Location = New System.Drawing.Point(795, 104)
        Me.lbxTarget.Name = "lbxTarget"
        Me.lbxTarget.Size = New System.Drawing.Size(271, 124)
        Me.lbxTarget.TabIndex = 6
        '
        'lbxDifferent
        '
        Me.lbxDifferent.FormattingEnabled = True
        Me.lbxDifferent.ItemHeight = 12
        Me.lbxDifferent.Location = New System.Drawing.Point(25, 287)
        Me.lbxDifferent.Name = "lbxDifferent"
        Me.lbxDifferent.Size = New System.Drawing.Size(710, 148)
        Me.lbxDifferent.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 455)
        Me.Controls.Add(Me.lbxDifferent)
        Me.Controls.Add(Me.lbxTarget)
        Me.Controls.Add(Me.lbxSource)
        Me.Controls.Add(Me.tbxSource)
        Me.Controls.Add(Me.tbxTarget)
        Me.Controls.Add(Me.btnTarget)
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.btnSource)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSource As Windows.Forms.Button
    Friend WithEvents btnGO As Windows.Forms.Button
    Friend WithEvents btnTarget As Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents tbxTarget As Windows.Forms.TextBox
    Friend WithEvents tbxSource As Windows.Forms.TextBox
    Friend WithEvents lbxSource As Windows.Forms.ListBox
    Friend WithEvents lbxTarget As Windows.Forms.ListBox
    Friend WithEvents lbxDifferent As Windows.Forms.ListBox
End Class
