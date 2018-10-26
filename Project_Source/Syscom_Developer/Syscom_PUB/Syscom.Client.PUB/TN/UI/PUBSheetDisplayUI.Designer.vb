<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSheetDisplayUI
    ' Inherits Syscom.Client.UCL.IUCLMaintainFormUI

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSheetDisplayUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Sheet_Type_Id = New System.Windows.Forms.Label()
        Me.lbl_Sheet_Main_Display = New System.Windows.Forms.Label()
        Me.lbl_Sheet_Sub_Display = New System.Windows.Forms.Label()
        Me.txt_Sheet_Sub_Display = New System.Windows.Forms.TextBox()
        Me.txt_Sheet_Main_Display = New System.Windows.Forms.TextBox()
        Me.txt_Sheet_Main_Display_Name = New System.Windows.Forms.TextBox()
        Me.lbl_Sheet_Main_Display_Name = New System.Windows.Forms.Label()
        Me.lbl_Sheet_Sub_Display_Name = New System.Windows.Forms.Label()
        Me.txt_Sheet_Sub_Display_Name = New System.Windows.Forms.TextBox()
        Me.UclCbo_Sheet_Type_Id = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 100)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 541)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 504)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 504)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 6
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.lbl_Sheet_Type_Id, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_Sheet_Main_Display, 2, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_Sheet_Sub_Display, 2, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Sheet_Sub_Display, 3, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Sheet_Main_Display, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Sheet_Main_Display_Name, 5, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_Sheet_Main_Display_Name, 4, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_Sheet_Sub_Display_Name, 4, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Sheet_Sub_Display_Name, 5, 1)
        Me.tlp_Main.Controls.Add(Me.UclCbo_Sheet_Type_Id, 1, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 100)
        Me.tlp_Main.TabIndex = 1
        '
        'lbl_Sheet_Type_Id
        '
        Me.lbl_Sheet_Type_Id.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sheet_Type_Id.AutoSize = True
        Me.lbl_Sheet_Type_Id.Location = New System.Drawing.Point(3, 8)
        Me.lbl_Sheet_Type_Id.Name = "lbl_Sheet_Type_Id"
        Me.lbl_Sheet_Type_Id.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Sheet_Type_Id.TabIndex = 0
        Me.lbl_Sheet_Type_Id.Text = "表單類別"
        '
        'lbl_Sheet_Main_Display
        '
        Me.lbl_Sheet_Main_Display.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sheet_Main_Display.AutoSize = True
        Me.lbl_Sheet_Main_Display.Location = New System.Drawing.Point(206, 8)
        Me.lbl_Sheet_Main_Display.Name = "lbl_Sheet_Main_Display"
        Me.lbl_Sheet_Main_Display.Size = New System.Drawing.Size(120, 16)
        Me.lbl_Sheet_Main_Display.TabIndex = 1
        Me.lbl_Sheet_Main_Display.Text = "表單顯示主分類"
        '
        'lbl_Sheet_Sub_Display
        '
        Me.lbl_Sheet_Sub_Display.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sheet_Sub_Display.AutoSize = True
        Me.lbl_Sheet_Sub_Display.Location = New System.Drawing.Point(206, 58)
        Me.lbl_Sheet_Sub_Display.Name = "lbl_Sheet_Sub_Display"
        Me.lbl_Sheet_Sub_Display.Size = New System.Drawing.Size(120, 16)
        Me.lbl_Sheet_Sub_Display.TabIndex = 2
        Me.lbl_Sheet_Sub_Display.Text = "表單顯示次分類"
        '
        'txt_Sheet_Sub_Display
        '
        Me.txt_Sheet_Sub_Display.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sheet_Sub_Display.Location = New System.Drawing.Point(332, 53)
        Me.txt_Sheet_Sub_Display.Name = "txt_Sheet_Sub_Display"
        Me.txt_Sheet_Sub_Display.Size = New System.Drawing.Size(100, 27)
        Me.txt_Sheet_Sub_Display.TabIndex = 5
        '
        'txt_Sheet_Main_Display
        '
        Me.txt_Sheet_Main_Display.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sheet_Main_Display.Location = New System.Drawing.Point(332, 3)
        Me.txt_Sheet_Main_Display.Name = "txt_Sheet_Main_Display"
        Me.txt_Sheet_Main_Display.Size = New System.Drawing.Size(100, 27)
        Me.txt_Sheet_Main_Display.TabIndex = 4
        '
        'txt_Sheet_Main_Display_Name
        '
        Me.txt_Sheet_Main_Display_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sheet_Main_Display_Name.Location = New System.Drawing.Point(596, 3)
        Me.txt_Sheet_Main_Display_Name.Name = "txt_Sheet_Main_Display_Name"
        Me.txt_Sheet_Main_Display_Name.Size = New System.Drawing.Size(100, 27)
        Me.txt_Sheet_Main_Display_Name.TabIndex = 6
        '
        'lbl_Sheet_Main_Display_Name
        '
        Me.lbl_Sheet_Main_Display_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sheet_Main_Display_Name.AutoSize = True
        Me.lbl_Sheet_Main_Display_Name.Location = New System.Drawing.Point(438, 8)
        Me.lbl_Sheet_Main_Display_Name.Name = "lbl_Sheet_Main_Display_Name"
        Me.lbl_Sheet_Main_Display_Name.Size = New System.Drawing.Size(152, 16)
        Me.lbl_Sheet_Main_Display_Name.TabIndex = 7
        Me.lbl_Sheet_Main_Display_Name.Text = "表單顯示主分類名稱"
        '
        'lbl_Sheet_Sub_Display_Name
        '
        Me.lbl_Sheet_Sub_Display_Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Sheet_Sub_Display_Name.AutoSize = True
        Me.lbl_Sheet_Sub_Display_Name.Location = New System.Drawing.Point(438, 58)
        Me.lbl_Sheet_Sub_Display_Name.Name = "lbl_Sheet_Sub_Display_Name"
        Me.lbl_Sheet_Sub_Display_Name.Size = New System.Drawing.Size(152, 16)
        Me.lbl_Sheet_Sub_Display_Name.TabIndex = 8
        Me.lbl_Sheet_Sub_Display_Name.Text = "表單顯示次分類名稱"
        '
        'txt_Sheet_Sub_Display_Name
        '
        Me.txt_Sheet_Sub_Display_Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Sheet_Sub_Display_Name.Location = New System.Drawing.Point(596, 53)
        Me.txt_Sheet_Sub_Display_Name.Name = "txt_Sheet_Sub_Display_Name"
        Me.txt_Sheet_Sub_Display_Name.Size = New System.Drawing.Size(100, 27)
        Me.txt_Sheet_Sub_Display_Name.TabIndex = 9
        '
        'UclCbo_Sheet_Type_Id
        '
        Me.UclCbo_Sheet_Type_Id.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.UclCbo_Sheet_Type_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.UclCbo_Sheet_Type_Id.DropDownWidth = 20
        Me.UclCbo_Sheet_Type_Id.DroppedDown = False
        Me.UclCbo_Sheet_Type_Id.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UclCbo_Sheet_Type_Id.Location = New System.Drawing.Point(78, 6)
        Me.UclCbo_Sheet_Type_Id.Margin = New System.Windows.Forms.Padding(0)
        Me.UclCbo_Sheet_Type_Id.Name = "UclCbo_Sheet_Type_Id"
        Me.UclCbo_Sheet_Type_Id.SelectedIndex = -1
        Me.UclCbo_Sheet_Type_Id.SelectedItem = Nothing
        Me.UclCbo_Sheet_Type_Id.SelectedText = ""
        Me.UclCbo_Sheet_Type_Id.SelectedValue = ""
        Me.UclCbo_Sheet_Type_Id.SelectionStart = 0
        Me.UclCbo_Sheet_Type_Id.Size = New System.Drawing.Size(125, 20)
        Me.UclCbo_Sheet_Type_Id.TabIndex = 11
        Me.UclCbo_Sheet_Type_Id.uclDisplayIndex = "0,1"
        Me.UclCbo_Sheet_Type_Id.uclIsAutoClear = True
        Me.UclCbo_Sheet_Type_Id.uclIsFirstItemEmpty = True
        Me.UclCbo_Sheet_Type_Id.uclIsTextMode = False
        Me.UclCbo_Sheet_Type_Id.uclShowMsg = False
        Me.UclCbo_Sheet_Type_Id.uclValueIndex = "0"
        '
        'PUBSheetDisplayUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBSheetDisplayUI"
        Me.Text = "PUBSheetDisplayUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Sheet_Type_Id As System.Windows.Forms.Label
    Friend WithEvents lbl_Sheet_Main_Display As System.Windows.Forms.Label
    Friend WithEvents lbl_Sheet_Sub_Display As System.Windows.Forms.Label
    Friend WithEvents txt_Sheet_Sub_Display As System.Windows.Forms.TextBox
    Friend WithEvents txt_Sheet_Main_Display As System.Windows.Forms.TextBox
    Friend WithEvents txt_Sheet_Main_Display_Name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Sheet_Main_Display_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Sheet_Sub_Display_Name As System.Windows.Forms.Label
    Friend WithEvents txt_Sheet_Sub_Display_Name As System.Windows.Forms.TextBox
    Friend WithEvents UclCbo_Sheet_Type_Id As Syscom.Client.UCL.UCLComboBoxUC
End Class
