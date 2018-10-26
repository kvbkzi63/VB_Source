<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLCensusUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveTreeMgr = Nothing
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
        Me.Cbo_Area = New System.Windows.Forms.ComboBox
        Me.Btn_AreaCodeQuery = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cbo_Area
        '
        Me.Cbo_Area.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Cbo_Area.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cbo_Area.FormattingEnabled = True
        Me.Cbo_Area.Location = New System.Drawing.Point(1, 1)
        Me.Cbo_Area.Margin = New System.Windows.Forms.Padding(1)
        Me.Cbo_Area.Name = "Cbo_Area"
        Me.Cbo_Area.Size = New System.Drawing.Size(183, 24)
        Me.Cbo_Area.TabIndex = 0
        '
        'Btn_AreaCodeQuery
        '
        Me.Btn_AreaCodeQuery.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Btn_AreaCodeQuery.Location = New System.Drawing.Point(185, 0)
        Me.Btn_AreaCodeQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_AreaCodeQuery.Name = "Btn_AreaCodeQuery"
        Me.Btn_AreaCodeQuery.Size = New System.Drawing.Size(34, 26)
        Me.Btn_AreaCodeQuery.TabIndex = 1
        Me.Btn_AreaCodeQuery.Text = "..."
        Me.Btn_AreaCodeQuery.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Cbo_Area, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_AreaCodeQuery, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(220, 26)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'UCLCensusUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UCLCensusUI"
        Me.Size = New System.Drawing.Size(220, 26)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cbo_Area As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_AreaCodeQuery As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
