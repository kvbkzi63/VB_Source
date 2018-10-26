<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPreventiveCareExeSetupUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPreventiveCareExeSetupUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UclCbo_Care_Order_Code = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.UclCbo_Pre_Care_Order_Code = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.UclCbo_Age_Control_Id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Age_Start = New System.Windows.Forms.TextBox()
        Me.txt_Age_End = New System.Windows.Forms.TextBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 133)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(1354, 600)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(1352, 563)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(1352, 563)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 2)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Care_Order_Code, 1, 0)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Pre_Care_Order_Code, 1, 1)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Age_Control_Id, 1, 2)
        Me.tlp_Main.Controls.Add(Me.Label4, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Age_Start, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Age_End, 3, 1)
        Me.tlp_Main.Controls.Add(Me.Label5, 2, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 3
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(1354, 133)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "下次時程代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "前次時程代碼"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "時間控制類型"
        '
        'UclCbo_Care_Order_Code
        '
        Me.UclCbo_Care_Order_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Care_Order_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Care_Order_Code.DropDownWidth = 20
        Me.UclCbo_Care_Order_Code.DroppedDown = False
        Me.UclCbo_Care_Order_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Care_Order_Code.Location = New System.Drawing.Point(112, 4)
        Me.UclCbo_Care_Order_Code.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Care_Order_Code.Name = "UclCbo_Care_Order_Code"
        Me.UclCbo_Care_Order_Code.SelectedIndex = -1
        Me.UclCbo_Care_Order_Code.SelectedItem = Nothing
        Me.UclCbo_Care_Order_Code.SelectedText = ""
        Me.UclCbo_Care_Order_Code.SelectedValue = ""
        Me.UclCbo_Care_Order_Code.SelectionStart = 0
        Me.UclCbo_Care_Order_Code.Size = New System.Drawing.Size(188, 27)
        Me.UclCbo_Care_Order_Code.TabIndex = 3
        Me.UclCbo_Care_Order_Code.uclDisplayIndex = "0,1"
        Me.UclCbo_Care_Order_Code.uclIsAutoClear = True
        Me.UclCbo_Care_Order_Code.uclIsFirstItemEmpty = True
        Me.UclCbo_Care_Order_Code.uclIsTextMode = False
        Me.UclCbo_Care_Order_Code.uclShowMsg = False
        Me.UclCbo_Care_Order_Code.uclValueIndex = "0"
        '
        'UclCbo_Pre_Care_Order_Code
        '
        Me.UclCbo_Pre_Care_Order_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Pre_Care_Order_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Pre_Care_Order_Code.DropDownWidth = 20
        Me.UclCbo_Pre_Care_Order_Code.DroppedDown = False
        Me.UclCbo_Pre_Care_Order_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Pre_Care_Order_Code.Location = New System.Drawing.Point(112, 39)
        Me.UclCbo_Pre_Care_Order_Code.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Pre_Care_Order_Code.Name = "UclCbo_Pre_Care_Order_Code"
        Me.UclCbo_Pre_Care_Order_Code.SelectedIndex = -1
        Me.UclCbo_Pre_Care_Order_Code.SelectedItem = Nothing
        Me.UclCbo_Pre_Care_Order_Code.SelectedText = ""
        Me.UclCbo_Pre_Care_Order_Code.SelectedValue = ""
        Me.UclCbo_Pre_Care_Order_Code.SelectionStart = 0
        Me.UclCbo_Pre_Care_Order_Code.Size = New System.Drawing.Size(188, 27)
        Me.UclCbo_Pre_Care_Order_Code.TabIndex = 4
        Me.UclCbo_Pre_Care_Order_Code.uclDisplayIndex = "0,1"
        Me.UclCbo_Pre_Care_Order_Code.uclIsAutoClear = True
        Me.UclCbo_Pre_Care_Order_Code.uclIsFirstItemEmpty = True
        Me.UclCbo_Pre_Care_Order_Code.uclIsTextMode = False
        Me.UclCbo_Pre_Care_Order_Code.uclShowMsg = False
        Me.UclCbo_Pre_Care_Order_Code.uclValueIndex = "0"
        '
        'UclCbo_Age_Control_Id
        '
        Me.UclCbo_Age_Control_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Age_Control_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Age_Control_Id.DropDownWidth = 20
        Me.UclCbo_Age_Control_Id.DroppedDown = False
        Me.UclCbo_Age_Control_Id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Age_Control_Id.Location = New System.Drawing.Point(112, 88)
        Me.UclCbo_Age_Control_Id.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Age_Control_Id.Name = "UclCbo_Age_Control_Id"
        Me.UclCbo_Age_Control_Id.SelectedIndex = -1
        Me.UclCbo_Age_Control_Id.SelectedItem = Nothing
        Me.UclCbo_Age_Control_Id.SelectedText = ""
        Me.UclCbo_Age_Control_Id.SelectedValue = ""
        Me.UclCbo_Age_Control_Id.SelectionStart = 0
        Me.UclCbo_Age_Control_Id.Size = New System.Drawing.Size(188, 27)
        Me.UclCbo_Age_Control_Id.TabIndex = 5
        Me.UclCbo_Age_Control_Id.uclDisplayIndex = "0,1"
        Me.UclCbo_Age_Control_Id.uclIsAutoClear = True
        Me.UclCbo_Age_Control_Id.uclIsFirstItemEmpty = True
        Me.UclCbo_Age_Control_Id.uclIsTextMode = False
        Me.UclCbo_Age_Control_Id.uclShowMsg = False
        Me.UclCbo_Age_Control_Id.uclValueIndex = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(304, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "下次執行時程起(>=)"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(304, 44)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "下次執行時程迄(<=)"
        '
        'txt_Age_Start
        '
        Me.txt_Age_Start.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Age_Start.Location = New System.Drawing.Point(458, 4)
        Me.txt_Age_Start.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Age_Start.Name = "txt_Age_Start"
        Me.txt_Age_Start.Size = New System.Drawing.Size(148, 27)
        Me.txt_Age_Start.TabIndex = 8
        '
        'txt_Age_End
        '
        Me.txt_Age_End.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Age_End.Location = New System.Drawing.Point(458, 39)
        Me.txt_Age_End.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Age_End.Name = "txt_Age_End"
        Me.txt_Age_End.Size = New System.Drawing.Size(148, 27)
        Me.txt_Age_End.TabIndex = 9
        '
        'PUBPreventiveCareExeSetupUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBPreventiveCareExeSetupUI"
        Me.Text = "預防保健執行設定維護"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UclCbo_Care_Order_Code As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents UclCbo_Pre_Care_Order_Code As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents UclCbo_Age_Control_Id As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Age_Start As System.Windows.Forms.TextBox
    Friend WithEvents txt_Age_End As System.Windows.Forms.TextBox
End Class
