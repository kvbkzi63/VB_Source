<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLFilePathUC
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_Path = New System.Windows.Forms.Button()
        Me.txt_Path = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Path, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Path, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(300, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Btn_Path
        '
        Me.Btn_Path.Location = New System.Drawing.Point(267, 3)
        Me.Btn_Path.Name = "Btn_Path"
        Me.Btn_Path.Size = New System.Drawing.Size(30, 27)
        Me.Btn_Path.TabIndex = 1
        Me.Btn_Path.Text = "..."
        Me.Btn_Path.UseVisualStyleBackColor = True
        '
        'txt_Path
        '
        Me.txt_Path.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_Path.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Path.Location = New System.Drawing.Point(3, 3)
        Me.txt_Path.MaxLength = 250
        Me.txt_Path.Name = "txt_Path"
        Me.txt_Path.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Path.SelectionStart = 0
        Me.txt_Path.Size = New System.Drawing.Size(258, 27)
        Me.txt_Path.TabIndex = 0
        Me.txt_Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Path.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Path.ToolTipTag = Nothing
        Me.txt_Path.uclDollarSign = False
        Me.txt_Path.uclDotCount = 0
        Me.txt_Path.uclIntCount = 2
        Me.txt_Path.uclMinus = False
        Me.txt_Path.uclReadOnly = False
        Me.txt_Path.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Path.uclTrimZero = True
        '
        'UCLFilePathUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UCLFilePathUC"
        Me.Size = New System.Drawing.Size(300, 33)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txt_Path As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Btn_Path As System.Windows.Forms.Button

End Class
