<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBLabIndication10
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBLabIndication10))
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Other_LOC = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cbo_LOC = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cbo_Spec_No = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(424, 150)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(87, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Other_LOC, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_LOC, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Spec_No, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.4382!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.5618!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(508, 142)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "檢體編號"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(464, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "公分"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(141, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "位置"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "位置不明(與肛門口距離)"
        '
        'txt_Other_LOC
        '
        Me.txt_Other_LOC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Other_LOC.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Other_LOC.Location = New System.Drawing.Point(187, 103)
        Me.txt_Other_LOC.MaxLength = 10
        Me.txt_Other_LOC.Name = "txt_Other_LOC"
        Me.txt_Other_LOC.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Other_LOC.SelectionStart = 0
        Me.txt_Other_LOC.Size = New System.Drawing.Size(270, 24)
        Me.txt_Other_LOC.TabIndex = 6
        Me.txt_Other_LOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Other_LOC.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Other_LOC.ToolTipTag = Nothing
        Me.txt_Other_LOC.uclDollarSign = False
        Me.txt_Other_LOC.uclDotCount = 0
        Me.txt_Other_LOC.uclIntCount = 3
        Me.txt_Other_LOC.uclMinus = False
        Me.txt_Other_LOC.uclReadOnly = False
        Me.txt_Other_LOC.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.txt_Other_LOC.uclTrimZero = True
        '
        'cbo_LOC
        '
        Me.cbo_LOC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_LOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_LOC.DropDownWidth = 20
        Me.cbo_LOC.DroppedDown = False
        Me.cbo_LOC.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_LOC.Location = New System.Drawing.Point(188, 54)
        Me.cbo_LOC.Margin = New System.Windows.Forms.Padding(4)
        Me.cbo_LOC.Name = "cbo_LOC"
        Me.cbo_LOC.SelectedIndex = -1
        Me.cbo_LOC.SelectedItem = Nothing
        Me.cbo_LOC.SelectedText = ""
        Me.cbo_LOC.SelectedValue = ""
        Me.cbo_LOC.SelectionStart = 0
        Me.cbo_LOC.Size = New System.Drawing.Size(269, 24)
        Me.cbo_LOC.TabIndex = 108
        Me.cbo_LOC.uclDisplayIndex = "0,1"
        Me.cbo_LOC.uclIsAutoClear = True
        Me.cbo_LOC.uclIsFirstItemEmpty = True
        Me.cbo_LOC.uclIsTextMode = False
        Me.cbo_LOC.uclShowMsg = False
        Me.cbo_LOC.uclValueIndex = "0"
        '
        'cbo_Spec_No
        '
        Me.cbo_Spec_No.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Spec_No.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Spec_No.DropDownWidth = 20
        Me.cbo_Spec_No.DroppedDown = False
        Me.cbo_Spec_No.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Spec_No.Location = New System.Drawing.Point(184, 11)
        Me.cbo_Spec_No.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Spec_No.Name = "cbo_Spec_No"
        Me.cbo_Spec_No.SelectedIndex = -1
        Me.cbo_Spec_No.SelectedItem = Nothing
        Me.cbo_Spec_No.SelectedText = ""
        Me.cbo_Spec_No.SelectedValue = ""
        Me.cbo_Spec_No.SelectionStart = 0
        Me.cbo_Spec_No.Size = New System.Drawing.Size(273, 21)
        Me.cbo_Spec_No.TabIndex = 109
        Me.cbo_Spec_No.uclDisplayIndex = "0,1"
        Me.cbo_Spec_No.uclIsAutoClear = True
        Me.cbo_Spec_No.uclIsFirstItemEmpty = True
        Me.cbo_Spec_No.uclIsTextMode = False
        Me.cbo_Spec_No.uclShowMsg = False
        Me.cbo_Spec_No.uclValueIndex = "0"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(209, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "本次非開立大腸鏡病理切片"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PUBLabIndication10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btn_Save)
        Me.IsActiveAutoSize = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PUBLabIndication10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "病理切片申請單"
        Me.Text = "病理切片申請單"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Other_LOC As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cbo_LOC As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cbo_Spec_No As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
