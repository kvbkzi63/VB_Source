<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBLabIndication02
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbt_1 = New System.Windows.Forms.RadioButton()
        Me.rbt_2 = New System.Windows.Forms.RadioButton()
        Me.rbt_3 = New System.Windows.Forms.RadioButton()
        Me.rbt_4 = New System.Windows.Forms.RadioButton()
        Me.rbt_5 = New System.Windows.Forms.RadioButton()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Save, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(441, 150)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 105)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(428, 105)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(420, 24)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "檢體為『Sputum』時，請輸入下面資訊："
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_1)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_2)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_3)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_4)
        Me.FlowLayoutPanel3.Controls.Add(Me.rbt_5)
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(3, 33)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(420, 69)
        Me.FlowLayoutPanel3.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "檢體來源     "
        '
        'rbt_1
        '
        Me.rbt_1.AutoSize = True
        Me.rbt_1.Location = New System.Drawing.Point(101, 3)
        Me.rbt_1.Name = "rbt_1"
        Me.rbt_1.Size = New System.Drawing.Size(84, 20)
        Me.rbt_1.TabIndex = 1
        Me.rbt_1.TabStop = True
        Me.rbt_1.Text = "p't cough"
        Me.rbt_1.UseVisualStyleBackColor = True
        '
        'rbt_2
        '
        Me.rbt_2.AutoSize = True
        Me.rbt_2.Location = New System.Drawing.Point(191, 3)
        Me.rbt_2.Name = "rbt_2"
        Me.rbt_2.Size = New System.Drawing.Size(99, 20)
        Me.rbt_2.TabIndex = 1
        Me.rbt_2.TabStop = True
        Me.rbt_2.Text = "oral suction"
        Me.rbt_2.UseVisualStyleBackColor = True
        '
        'rbt_3
        '
        Me.rbt_3.AutoSize = True
        Me.rbt_3.Location = New System.Drawing.Point(296, 3)
        Me.rbt_3.Name = "rbt_3"
        Me.rbt_3.Size = New System.Drawing.Size(112, 20)
        Me.rbt_3.TabIndex = 1
        Me.rbt_3.TabStop = True
        Me.rbt_3.Text = "Endo. suction"
        Me.rbt_3.UseVisualStyleBackColor = True
        '
        'rbt_4
        '
        Me.rbt_4.AutoSize = True
        Me.rbt_4.Location = New System.Drawing.Point(100, 29)
        Me.rbt_4.Margin = New System.Windows.Forms.Padding(100, 3, 3, 3)
        Me.rbt_4.Name = "rbt_4"
        Me.rbt_4.Size = New System.Drawing.Size(129, 20)
        Me.rbt_4.TabIndex = 1
        Me.rbt_4.TabStop = True
        Me.rbt_4.Text = "Tracheal suction"
        Me.rbt_4.UseVisualStyleBackColor = True
        '
        'rbt_5
        '
        Me.rbt_5.AutoSize = True
        Me.rbt_5.Location = New System.Drawing.Point(235, 29)
        Me.rbt_5.Name = "rbt_5"
        Me.rbt_5.Size = New System.Drawing.Size(134, 20)
        Me.rbt_5.TabIndex = 1
        Me.rbt_5.TabStop = True
        Me.rbt_5.Text = "bronchial suction"
        Me.rbt_5.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(348, 114)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(87, 28)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "F12-確定"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'PUBLabIndication02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 154)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PUBLabIndication02"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "細菌檢驗申請單"
        Me.Text = "細菌檢驗申請單"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbt_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_5 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
End Class
