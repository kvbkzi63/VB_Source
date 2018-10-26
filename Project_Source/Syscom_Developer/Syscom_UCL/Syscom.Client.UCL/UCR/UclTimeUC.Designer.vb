<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclTimeUC
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
        Me.btn_KeypadOpen = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_Time = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_KeypadOpen
        '
        Me.btn_KeypadOpen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_KeypadOpen.Enabled = False
        Me.btn_KeypadOpen.Location = New System.Drawing.Point(61, 0)
        Me.btn_KeypadOpen.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_KeypadOpen.Name = "btn_KeypadOpen"
        Me.btn_KeypadOpen.Size = New System.Drawing.Size(46, 28)
        Me.btn_KeypadOpen.TabIndex = 1
        Me.btn_KeypadOpen.Text = "..."
        Me.btn_KeypadOpen.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btn_KeypadOpen, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Time, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(107, 28)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'txt_Time
        '
        Me.txt_Time.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Time.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Time.Location = New System.Drawing.Point(0, 0)
        Me.txt_Time.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Time.MaxLength = 10
        Me.txt_Time.Name = "txt_Time"
        Me.txt_Time.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Time.SelectionStart = 0
        Me.txt_Time.Size = New System.Drawing.Size(61, 27)
        Me.txt_Time.TabIndex = 0
        Me.txt_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Time.ToolTipTag = Nothing
        Me.txt_Time.uclDollarSign = False
        Me.txt_Time.uclDotCount = 0
        Me.txt_Time.uclIntCount = 2
        Me.txt_Time.uclMinus = False
        Me.txt_Time.uclReadOnly = False
        Me.txt_Time.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        Me.txt_Time.uclTrimZero = True
        '
        'UclTimeUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UclTimeUC"
        Me.Size = New System.Drawing.Size(107, 28)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents txt_Time As Syscom.Client.UCL.UCLTextBoxUC
    Public WithEvents btn_KeypadOpen As System.Windows.Forms.Button

End Class
