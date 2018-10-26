<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLTextCodeQueryUI
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveMgr = Nothing
            pvtDS = Nothing
            OtherQueryConditionDS = Nothing
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
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.Btn_CodeQuery = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_CodeValue = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_CodeQuery
        '
        Me.Btn_CodeQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Btn_CodeQuery.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_CodeQuery.Location = New System.Drawing.Point(169, 0)
        Me.Btn_CodeQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_CodeQuery.Name = "Btn_CodeQuery"
        Me.Btn_CodeQuery.Size = New System.Drawing.Size(35, 26)
        Me.Btn_CodeQuery.TabIndex = 2
        Me.Btn_CodeQuery.Text = "..."
        Me.Btn_CodeQuery.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_CodeQuery, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_CodeValue, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(204, 26)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'cbo_CodeValue
        '
        Me.cbo_CodeValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_CodeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbo_CodeValue.FormattingEnabled = True
        Me.cbo_CodeValue.Location = New System.Drawing.Point(1, 1)
        Me.cbo_CodeValue.Margin = New System.Windows.Forms.Padding(1)
        Me.cbo_CodeValue.Name = "cbo_CodeValue"
        Me.cbo_CodeValue.Size = New System.Drawing.Size(167, 24)
        Me.cbo_CodeValue.TabIndex = 1
        '
        'UCLTextCodeQueryUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UCLTextCodeQueryUI"
        Me.Size = New System.Drawing.Size(204, 26)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_CodeQuery As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbo_CodeValue As System.Windows.Forms.ComboBox

End Class
