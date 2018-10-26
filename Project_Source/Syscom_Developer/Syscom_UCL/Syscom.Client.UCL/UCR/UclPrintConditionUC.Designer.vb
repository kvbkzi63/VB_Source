Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> <Designer(GetType(FixedHeightControlDesigner))> _
Partial Class UclPrintConditionUC
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UclPrintConditionUC))
        Me.TableLayoutPanelPrintCondition = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_StationNo = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.rdo_StationNo = New System.Windows.Forms.RadioButton()
        Me.rdo_UserTermCode = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanelPrintCondition.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanelPrintCondition
        '
        Me.TableLayoutPanelPrintCondition.ColumnCount = 4
        Me.TableLayoutPanelPrintCondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelPrintCondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelPrintCondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelPrintCondition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelPrintCondition.Controls.Add(Me.cbo_StationNo, 3, 0)
        Me.TableLayoutPanelPrintCondition.Controls.Add(Me.rdo_StationNo, 2, 0)
        Me.TableLayoutPanelPrintCondition.Controls.Add(Me.rdo_UserTermCode, 1, 0)
        Me.TableLayoutPanelPrintCondition.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanelPrintCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPrintCondition.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelPrintCondition.Name = "TableLayoutPanelPrintCondition"
        Me.TableLayoutPanelPrintCondition.RowCount = 1
        Me.TableLayoutPanelPrintCondition.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPrintCondition.Size = New System.Drawing.Size(342, 30)
        Me.TableLayoutPanelPrintCondition.TabIndex = 0
        '
        'cbo_StationNo
        '
        Me.cbo_StationNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_StationNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_StationNo.DropDownWidth = 20
        Me.cbo_StationNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_StationNo.Location = New System.Drawing.Point(238, 3)
        Me.cbo_StationNo.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_StationNo.Name = "cbo_StationNo"
        Me.cbo_StationNo.SelectedIndex = -1
        Me.cbo_StationNo.SelectedItem = Nothing
        Me.cbo_StationNo.SelectedText = ""
        Me.cbo_StationNo.SelectedValue = ""
        Me.cbo_StationNo.SelectionStart = 0
        Me.cbo_StationNo.Size = New System.Drawing.Size(88, 24)
        Me.cbo_StationNo.TabIndex = 1
        Me.cbo_StationNo.uclDisplayIndex = "0,1"
        Me.cbo_StationNo.uclIsAutoClear = True
        Me.cbo_StationNo.uclIsFirstItemEmpty = True
        Me.cbo_StationNo.uclIsTextMode = False
        Me.cbo_StationNo.uclShowMsg = False
        Me.cbo_StationNo.uclValueIndex = "0"
        '
        'rdo_StationNo
        '
        Me.rdo_StationNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_StationNo.AutoSize = True
        Me.rdo_StationNo.Location = New System.Drawing.Point(161, 5)
        Me.rdo_StationNo.Name = "rdo_StationNo"
        Me.rdo_StationNo.Size = New System.Drawing.Size(74, 20)
        Me.rdo_StationNo.TabIndex = 0
        Me.rdo_StationNo.Text = "護理站"
        Me.rdo_StationNo.UseVisualStyleBackColor = True
        '
        'rdo_UserTermCode
        '
        Me.rdo_UserTermCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rdo_UserTermCode.AutoSize = True
        Me.rdo_UserTermCode.Checked = True
        Me.rdo_UserTermCode.Location = New System.Drawing.Point(65, 5)
        Me.rdo_UserTermCode.Name = "rdo_UserTermCode"
        Me.rdo_UserTermCode.Size = New System.Drawing.Size(90, 20)
        Me.rdo_UserTermCode.TabIndex = 0
        Me.rdo_UserTermCode.TabStop = True
        Me.rdo_UserTermCode.Text = "登入位置"
        Me.rdo_UserTermCode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "列印至"
        '
        'PcsUclPrintConditionUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanelPrintCondition)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PcsUclPrintConditionUC"
        Me.Size = New System.Drawing.Size(342, 30)
        Me.TableLayoutPanelPrintCondition.ResumeLayout(False)
        Me.TableLayoutPanelPrintCondition.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanelPrintCondition As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdo_UserTermCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_StationNo As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_StationNo As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
