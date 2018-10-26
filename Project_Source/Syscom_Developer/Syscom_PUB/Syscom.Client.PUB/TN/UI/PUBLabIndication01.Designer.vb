<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBLabIndication01
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbt_1 = New System.Windows.Forms.RadioButton()
        Me.rbt_2 = New System.Windows.Forms.RadioButton()
        Me.rbt_3 = New System.Windows.Forms.RadioButton()
        Me.rbt_4 = New System.Windows.Forms.RadioButton()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbt_Y = New System.Windows.Forms.RadioButton()
        Me.rbt_N = New System.Windows.Forms.RadioButton()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_5 = New System.Windows.Forms.RadioButton()
        Me.rbt_6 = New System.Windows.Forms.RadioButton()
        Me.rbt_7 = New System.Windows.Forms.RadioButton()
        Me.rbt_8 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Save, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(509, 219)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 175)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel5, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(497, 172)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_1)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_2)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_3)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbt_4)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 71)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(487, 29)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "檢體來源"
        '
        'rbt_1
        '
        Me.rbt_1.AutoSize = True
        Me.rbt_1.Location = New System.Drawing.Point(81, 3)
        Me.rbt_1.Name = "rbt_1"
        Me.rbt_1.Size = New System.Drawing.Size(74, 20)
        Me.rbt_1.TabIndex = 1
        Me.rbt_1.TabStop = True
        Me.rbt_1.Text = "中段尿"
        Me.rbt_1.UseVisualStyleBackColor = True
        '
        'rbt_2
        '
        Me.rbt_2.AutoSize = True
        Me.rbt_2.Location = New System.Drawing.Point(161, 3)
        Me.rbt_2.Name = "rbt_2"
        Me.rbt_2.Size = New System.Drawing.Size(58, 20)
        Me.rbt_2.TabIndex = 1
        Me.rbt_2.TabStop = True
        Me.rbt_2.Text = "導尿"
        Me.rbt_2.UseVisualStyleBackColor = True
        '
        'rbt_3
        '
        Me.rbt_3.AutoSize = True
        Me.rbt_3.Location = New System.Drawing.Point(225, 3)
        Me.rbt_3.Name = "rbt_3"
        Me.rbt_3.Size = New System.Drawing.Size(90, 20)
        Me.rbt_3.TabIndex = 1
        Me.rbt_3.TabStop = True
        Me.rbt_3.Text = "單次導尿"
        Me.rbt_3.UseVisualStyleBackColor = True
        '
        'rbt_4
        '
        Me.rbt_4.AutoSize = True
        Me.rbt_4.Location = New System.Drawing.Point(321, 3)
        Me.rbt_4.Name = "rbt_4"
        Me.rbt_4.Size = New System.Drawing.Size(90, 20)
        Me.rbt_4.TabIndex = 2
        Me.rbt_4.TabStop = True
        Me.rbt_4.Text = "小孩導尿"
        Me.rbt_4.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel4.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(487, 28)
        Me.FlowLayoutPanel4.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(280, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "檢體為『尿液』時，請輸入下面資訊："
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel5.Controls.Add(Me.rbt_Y)
        Me.FlowLayoutPanel5.Controls.Add(Me.rbt_N)
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(3, 37)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(487, 28)
        Me.FlowLayoutPanel5.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "使用抗生素"
        '
        'rbt_Y
        '
        Me.rbt_Y.AutoSize = True
        Me.rbt_Y.Location = New System.Drawing.Point(97, 3)
        Me.rbt_Y.Name = "rbt_Y"
        Me.rbt_Y.Size = New System.Drawing.Size(42, 20)
        Me.rbt_Y.TabIndex = 1
        Me.rbt_Y.TabStop = True
        Me.rbt_Y.Text = "是"
        Me.rbt_Y.UseVisualStyleBackColor = True
        '
        'rbt_N
        '
        Me.rbt_N.AutoSize = True
        Me.rbt_N.Location = New System.Drawing.Point(145, 3)
        Me.rbt_N.Name = "rbt_N"
        Me.rbt_N.Size = New System.Drawing.Size(42, 20)
        Me.rbt_N.TabIndex = 1
        Me.rbt_N.TabStop = True
        Me.rbt_N.Text = "否"
        Me.rbt_N.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(418, 184)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(87, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_5)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_6)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_7)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 106)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(487, 29)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'rbt_5
        '
        Me.rbt_5.AutoSize = True
        Me.rbt_5.Location = New System.Drawing.Point(81, 3)
        Me.rbt_5.Name = "rbt_5"
        Me.rbt_5.Size = New System.Drawing.Size(106, 20)
        Me.rbt_5.TabIndex = 1
        Me.rbt_5.TabStop = True
        Me.rbt_5.Text = "恥骨上穿刺"
        Me.rbt_5.UseVisualStyleBackColor = True
        '
        'rbt_6
        '
        Me.rbt_6.AutoSize = True
        Me.rbt_6.Location = New System.Drawing.Point(193, 3)
        Me.rbt_6.Name = "rbt_6"
        Me.rbt_6.Size = New System.Drawing.Size(74, 20)
        Me.rbt_6.TabIndex = 1
        Me.rbt_6.TabStop = True
        Me.rbt_6.Text = "腎臟尿"
        Me.rbt_6.UseVisualStyleBackColor = True
        '
        'rbt_7
        '
        Me.rbt_7.AutoSize = True
        Me.rbt_7.Location = New System.Drawing.Point(273, 3)
        Me.rbt_7.Name = "rbt_7"
        Me.rbt_7.Size = New System.Drawing.Size(122, 20)
        Me.rbt_7.TabIndex = 1
        Me.rbt_7.TabStop = True
        Me.rbt_7.Text = "腎臟造廔管尿"
        Me.rbt_7.UseVisualStyleBackColor = True
        '
        'rbt_8
        '
        Me.rbt_8.AutoSize = True
        Me.rbt_8.Location = New System.Drawing.Point(81, 3)
        Me.rbt_8.Name = "rbt_8"
        Me.rbt_8.Size = New System.Drawing.Size(90, 20)
        Me.rbt_8.TabIndex = 2
        Me.rbt_8.TabStop = True
        Me.rbt_8.Text = "膀胱鏡尿"
        Me.rbt_8.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "                "
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_8)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 141)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(487, 29)
        Me.FlowLayoutPanel3.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "                "
        '
        'PUBLabIndication01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.IsActiveAutoSize = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PUBLabIndication01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "細菌檢驗申請單"
        Me.Text = "細菌檢驗申請單"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbt_Y As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_N As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_3 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents rbt_4 As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbt_8 As System.Windows.Forms.RadioButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbt_5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_7 As System.Windows.Forms.RadioButton
End Class
