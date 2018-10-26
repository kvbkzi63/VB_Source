<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLYmPickerUC
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
        Me.dtp_ym = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.txt_ym = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.dtp_ym, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_ym, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(100, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtp_ym
        '
        Me.dtp_ym.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_ym.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_ym.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_ym.Location = New System.Drawing.Point(81, 4)
        Me.dtp_ym.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_ym.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_ym.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_ym.Name = "dtp_ym"
        Me.dtp_ym.Size = New System.Drawing.Size(15, 25)
        Me.dtp_ym.TabIndex = 1
        Me.dtp_ym.uclReadOnly = False
        '
        'txt_ym
        '
        Me.txt_ym.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_ym.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ym.Location = New System.Drawing.Point(3, 3)
        Me.txt_ym.MaxLength = 10
        Me.txt_ym.Name = "txt_ym"
        Me.txt_ym.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ym.SelectionStart = 0
        Me.txt_ym.Size = New System.Drawing.Size(71, 27)
        Me.txt_ym.TabIndex = 2
        Me.txt_ym.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ym.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt
        Me.txt_ym.ToolTipTag = Nothing
        Me.txt_ym.uclDollarSign = False
        Me.txt_ym.uclDotCount = 0
        Me.txt_ym.uclIntCount = 5
        Me.txt_ym.uclMinus = False
        Me.txt_ym.uclReadOnly = False
        Me.txt_ym.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ym.uclTrimZero = True
        '
        'UCLYmPickerUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLYmPickerUC"
        Me.Size = New System.Drawing.Size(100, 33)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtp_ym As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_ym As Syscom.Client.UCL.UCLTextBoxUC

End Class
