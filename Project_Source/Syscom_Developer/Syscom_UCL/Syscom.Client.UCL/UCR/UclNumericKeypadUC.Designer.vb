<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclNumericKeypadUC
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
        Me.btn_OpenUI = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txt_numeric = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_OpenUI
        '
        Me.btn_OpenUI.Location = New System.Drawing.Point(134, 0)
        Me.btn_OpenUI.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_OpenUI.Name = "btn_OpenUI"
        Me.btn_OpenUI.Size = New System.Drawing.Size(33, 27)
        Me.btn_OpenUI.TabIndex = 0
        Me.btn_OpenUI.Text = "..."
        Me.btn_OpenUI.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.41177!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.58824!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_OpenUI, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_numeric, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 27)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'txt_numeric
        '
        Me.txt_numeric.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_numeric.Location = New System.Drawing.Point(0, 0)
        Me.txt_numeric.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_numeric.MaxLength = 10
        Me.txt_numeric.Name = "txt_numeric"
        Me.txt_numeric.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_numeric.SelectionStart = 0
        Me.txt_numeric.Size = New System.Drawing.Size(134, 27)
        Me.txt_numeric.TabIndex = 1
        Me.txt_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_numeric.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_numeric.ToolTipTag = Nothing
        Me.txt_numeric.uclDollarSign = False
        Me.txt_numeric.uclDotCount = 10
        Me.txt_numeric.uclIntCount = 10
        Me.txt_numeric.uclMinus = False
        Me.txt_numeric.uclReadOnly = False
        Me.txt_numeric.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_numeric.uclTrimZero = True
        '
        'UclNumericKeypadUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UclNumericKeypadUC"
        Me.Size = New System.Drawing.Size(170, 27)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents btn_OpenUI As System.Windows.Forms.Button
    Public WithEvents txt_numeric As Syscom.Client.UCL.UCLTextBoxUC

End Class
