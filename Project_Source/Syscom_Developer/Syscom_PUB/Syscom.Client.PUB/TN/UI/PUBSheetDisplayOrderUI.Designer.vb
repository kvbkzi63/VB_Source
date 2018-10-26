<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSheetDisplayOrderUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSheetDisplayOrderUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UclCbo_Sheet_Sub_Display = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_Order_Display_Code = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UclCbo_Order_Code = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txt_Order_Display_Name = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UclCbo_Main_Body_Site = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UclCbo_Side_Id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UclCbo_Body_Site = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Display_Sort_Value = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 133)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 508)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 471)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 471)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 9
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Sheet_Sub_Display, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Order_Display_Code, 1, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label2, 3, 0)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Order_Code, 4, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Order_Display_Name, 4, 1)
        Me.tlp_Main.Controls.Add(Me.Label4, 2, 1)
        Me.tlp_Main.Controls.Add(Me.Label5, 5, 0)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Main_Body_Site, 6, 0)
        Me.tlp_Main.Controls.Add(Me.Label7, 7, 0)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Side_Id, 8, 0)
        Me.tlp_Main.Controls.Add(Me.Label6, 5, 1)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Body_Site, 6, 1)
        Me.tlp_Main.Controls.Add(Me.Label8, 7, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Display_Sort_Value, 8, 1)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 133)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "表單顯示次分類"
        '
        'UclCbo_Sheet_Sub_Display
        '
        Me.UclCbo_Sheet_Sub_Display.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.UclCbo_Sheet_Sub_Display, 2)
        Me.UclCbo_Sheet_Sub_Display.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Sheet_Sub_Display.DropDownWidth = 20
        Me.UclCbo_Sheet_Sub_Display.DroppedDown = False
        Me.UclCbo_Sheet_Sub_Display.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Sheet_Sub_Display.Location = New System.Drawing.Point(128, 0)
        Me.UclCbo_Sheet_Sub_Display.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Sheet_Sub_Display.Name = "UclCbo_Sheet_Sub_Display"
        Me.UclCbo_Sheet_Sub_Display.SelectedIndex = -1
        Me.UclCbo_Sheet_Sub_Display.SelectedItem = Nothing
        Me.UclCbo_Sheet_Sub_Display.SelectedText = ""
        Me.UclCbo_Sheet_Sub_Display.SelectedValue = ""
        Me.UclCbo_Sheet_Sub_Display.SelectionStart = 0
        Me.UclCbo_Sheet_Sub_Display.Size = New System.Drawing.Size(209, 27)
        Me.UclCbo_Sheet_Sub_Display.TabIndex = 4
        Me.UclCbo_Sheet_Sub_Display.uclDisplayIndex = "0,1"
        Me.UclCbo_Sheet_Sub_Display.uclIsAutoClear = True
        Me.UclCbo_Sheet_Sub_Display.uclIsFirstItemEmpty = True
        Me.UclCbo_Sheet_Sub_Display.uclIsTextMode = False
        Me.UclCbo_Sheet_Sub_Display.uclShowMsg = False
        Me.UclCbo_Sheet_Sub_Display.uclValueIndex = "0"
        '
        'txt_Order_Display_Code
        '
        Me.txt_Order_Display_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Order_Display_Code.Location = New System.Drawing.Point(132, 66)
        Me.txt_Order_Display_Code.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Order_Display_Code.Name = "txt_Order_Display_Code"
        Me.txt_Order_Display_Code.Size = New System.Drawing.Size(143, 27)
        Me.txt_Order_Display_Code.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "醫令顯示代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(341, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "醫令代碼"
        '
        'UclCbo_Order_Code
        '
        Me.UclCbo_Order_Code.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Order_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Order_Code.DropDownWidth = 20
        Me.UclCbo_Order_Code.DroppedDown = False
        Me.UclCbo_Order_Code.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Order_Code.Location = New System.Drawing.Point(417, 0)
        Me.UclCbo_Order_Code.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Order_Code.Name = "UclCbo_Order_Code"
        Me.UclCbo_Order_Code.SelectedIndex = -1
        Me.UclCbo_Order_Code.SelectedItem = Nothing
        Me.UclCbo_Order_Code.SelectedText = ""
        Me.UclCbo_Order_Code.SelectedValue = ""
        Me.UclCbo_Order_Code.SelectionStart = 0
        Me.UclCbo_Order_Code.Size = New System.Drawing.Size(202, 27)
        Me.UclCbo_Order_Code.TabIndex = 5
        Me.UclCbo_Order_Code.uclDisplayIndex = "0,1"
        Me.UclCbo_Order_Code.uclIsAutoClear = True
        Me.UclCbo_Order_Code.uclIsFirstItemEmpty = True
        Me.UclCbo_Order_Code.uclIsTextMode = False
        Me.UclCbo_Order_Code.uclShowMsg = False
        Me.UclCbo_Order_Code.uclValueIndex = "0"
        '
        'txt_Order_Display_Name
        '
        Me.txt_Order_Display_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Order_Display_Name.Location = New System.Drawing.Point(421, 66)
        Me.txt_Order_Display_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Order_Display_Name.Name = "txt_Order_Display_Name"
        Me.txt_Order_Display_Name.Size = New System.Drawing.Size(198, 27)
        Me.txt_Order_Display_Name.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.tlp_Main.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Location = New System.Drawing.Point(309, 72)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "醫令顯示名稱"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(626, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "預設大部位"
        '
        'UclCbo_Main_Body_Site
        '
        Me.UclCbo_Main_Body_Site.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Main_Body_Site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Main_Body_Site.DropDownWidth = 20
        Me.UclCbo_Main_Body_Site.DroppedDown = False
        Me.UclCbo_Main_Body_Site.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Main_Body_Site.Location = New System.Drawing.Point(717, 3)
        Me.UclCbo_Main_Body_Site.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Main_Body_Site.Name = "UclCbo_Main_Body_Site"
        Me.UclCbo_Main_Body_Site.SelectedIndex = -1
        Me.UclCbo_Main_Body_Site.SelectedItem = Nothing
        Me.UclCbo_Main_Body_Site.SelectedText = ""
        Me.UclCbo_Main_Body_Site.SelectedValue = ""
        Me.UclCbo_Main_Body_Site.SelectionStart = 0
        Me.UclCbo_Main_Body_Site.Size = New System.Drawing.Size(125, 20)
        Me.UclCbo_Main_Body_Site.TabIndex = 11
        Me.UclCbo_Main_Body_Site.uclDisplayIndex = "0,1"
        Me.UclCbo_Main_Body_Site.uclIsAutoClear = True
        Me.UclCbo_Main_Body_Site.uclIsFirstItemEmpty = True
        Me.UclCbo_Main_Body_Site.uclIsTextMode = False
        Me.UclCbo_Main_Body_Site.uclShowMsg = False
        Me.UclCbo_Main_Body_Site.uclValueIndex = "0"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(845, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "預設側位"
        '
        'UclCbo_Side_Id
        '
        Me.UclCbo_Side_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Side_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Side_Id.DropDownWidth = 20
        Me.UclCbo_Side_Id.DroppedDown = False
        Me.UclCbo_Side_Id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Side_Id.Location = New System.Drawing.Point(920, 3)
        Me.UclCbo_Side_Id.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Side_Id.Name = "UclCbo_Side_Id"
        Me.UclCbo_Side_Id.SelectedIndex = -1
        Me.UclCbo_Side_Id.SelectedItem = Nothing
        Me.UclCbo_Side_Id.SelectedText = ""
        Me.UclCbo_Side_Id.SelectedValue = ""
        Me.UclCbo_Side_Id.SelectionStart = 0
        Me.UclCbo_Side_Id.Size = New System.Drawing.Size(118, 20)
        Me.UclCbo_Side_Id.TabIndex = 14
        Me.UclCbo_Side_Id.uclDisplayIndex = "0,1"
        Me.UclCbo_Side_Id.uclIsAutoClear = True
        Me.UclCbo_Side_Id.uclIsFirstItemEmpty = True
        Me.UclCbo_Side_Id.uclIsTextMode = False
        Me.UclCbo_Side_Id.uclShowMsg = False
        Me.UclCbo_Side_Id.uclValueIndex = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(642, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "預設部位"
        '
        'UclCbo_Body_Site
        '
        Me.UclCbo_Body_Site.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Body_Site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Body_Site.DropDownWidth = 20
        Me.UclCbo_Body_Site.DroppedDown = False
        Me.UclCbo_Body_Site.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Body_Site.Location = New System.Drawing.Point(717, 70)
        Me.UclCbo_Body_Site.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Body_Site.Name = "UclCbo_Body_Site"
        Me.UclCbo_Body_Site.SelectedIndex = -1
        Me.UclCbo_Body_Site.SelectedItem = Nothing
        Me.UclCbo_Body_Site.SelectedText = ""
        Me.UclCbo_Body_Site.SelectedValue = ""
        Me.UclCbo_Body_Site.SelectionStart = 0
        Me.UclCbo_Body_Site.Size = New System.Drawing.Size(125, 20)
        Me.UclCbo_Body_Site.TabIndex = 12
        Me.UclCbo_Body_Site.uclDisplayIndex = "0,1"
        Me.UclCbo_Body_Site.uclIsAutoClear = True
        Me.UclCbo_Body_Site.uclIsFirstItemEmpty = True
        Me.UclCbo_Body_Site.uclIsTextMode = False
        Me.UclCbo_Body_Site.uclShowMsg = False
        Me.UclCbo_Body_Site.uclValueIndex = "0"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(877, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "排序"
        '
        'txt_Display_Sort_Value
        '
        Me.txt_Display_Sort_Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Display_Sort_Value.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_Display_Sort_Value.Location = New System.Drawing.Point(923, 66)
        Me.txt_Display_Sort_Value.MaxLength = 10
        Me.txt_Display_Sort_Value.Name = "txt_Display_Sort_Value"
        Me.txt_Display_Sort_Value.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_Display_Sort_Value.SelectionStart = 0
        Me.txt_Display_Sort_Value.Size = New System.Drawing.Size(129, 27)
        Me.txt_Display_Sort_Value.TabIndex = 16
        Me.txt_Display_Sort_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_Display_Sort_Value.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_Display_Sort_Value.ToolTipTag = Nothing
        Me.txt_Display_Sort_Value.uclDollarSign = False
        Me.txt_Display_Sort_Value.uclDotCount = 0
        Me.txt_Display_Sort_Value.uclIntCount = 2
        Me.txt_Display_Sort_Value.uclMinus = False
        Me.txt_Display_Sort_Value.uclReadOnly = False
        Me.txt_Display_Sort_Value.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_Display_Sort_Value.uclTrimZero = True
        '
        'PUBSheetDisplayOrderUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBSheetDisplayOrderUI"
        Me.Text = "表單開單顯示醫令檔維護"
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UclCbo_Sheet_Sub_Display As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents UclCbo_Order_Code As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txt_Order_Display_Code As System.Windows.Forms.TextBox
    Friend WithEvents txt_Order_Display_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UclCbo_Main_Body_Site As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents UclCbo_Body_Site As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UclCbo_Side_Id As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Display_Sort_Value As Syscom.Client.UCL.UCLTextBoxUC
End Class
