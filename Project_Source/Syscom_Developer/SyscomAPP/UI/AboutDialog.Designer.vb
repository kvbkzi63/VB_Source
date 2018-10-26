Partial Class AboutDialog
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overloads Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"
	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.buttonOK = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.labelLibVersion = New System.Windows.Forms.Label
        Me.labelAppVersion = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'buttonOK
        '
        Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonOK.Location = New System.Drawing.Point(240, 184)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(75, 23)
        Me.buttonOK.TabIndex = 0
        Me.buttonOK.Text = "OK"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(24, 59)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(109, 16)
        Me.label1.TabIndex = 1
        Me.label1.Text = "DockSample Version:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(24, 119)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(272, 19)
        Me.label2.TabIndex = 2
        Me.label2.Text = "作者：Lits"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(24, 81)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(123, 12)
        Me.label3.TabIndex = 3
        Me.label3.Text = "DockPanel Suite Version:"
        '
        'labelLibVersion
        '
        Me.labelLibVersion.Location = New System.Drawing.Point(148, 81)
        Me.labelLibVersion.Name = "labelLibVersion"
        Me.labelLibVersion.Size = New System.Drawing.Size(97, 13)
        Me.labelLibVersion.TabIndex = 4
        '
        'labelAppVersion
        '
        Me.labelAppVersion.Location = New System.Drawing.Point(129, 59)
        Me.labelAppVersion.Name = "labelAppVersion"
        Me.labelAppVersion.Size = New System.Drawing.Size(97, 13)
        Me.labelAppVersion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "公司：凌群電腦"
        '
        'AboutDialog
        '
        Me.AcceptButton = Me.buttonOK
        Me.CancelButton = Me.buttonOK
        Me.ClientSize = New System.Drawing.Size(322, 215)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.labelAppVersion)
        Me.Controls.Add(Me.labelLibVersion)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	#End Region

	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private buttonOK As System.Windows.Forms.Button
	Private label3 As System.Windows.Forms.Label
	Private labelLibVersion As System.Windows.Forms.Label
    Private labelAppVersion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
