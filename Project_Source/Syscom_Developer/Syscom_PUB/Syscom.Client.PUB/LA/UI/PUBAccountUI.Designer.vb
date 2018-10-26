<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBAccountUI
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBAccountUI))
        Me.palMaintain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblAccountId = New System.Windows.Forms.Label()
        Me.lblReceiptAccountId = New System.Windows.Forms.Label()
        Me.cmbReceiptAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblInsuAccountId = New System.Windows.Forms.Label()
        Me.lblAcc1AccountId = New System.Windows.Forms.Label()
        Me.cmbInsuAccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbAcc1AccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblAcc2AccountId = New System.Windows.Forms.Label()
        Me.cmbAcc2AccountId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ckbDc = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.palMaintain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 92)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(931, 246)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(929, 209)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(929, 209)
        '
        'palMaintain
        '
        Me.palMaintain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palMaintain.Controls.Add(Me.TableLayoutPanel1)
        Me.palMaintain.Dock = System.Windows.Forms.DockStyle.Top
        Me.palMaintain.Location = New System.Drawing.Point(0, 0)
        Me.palMaintain.Name = "palMaintain"
        Me.palMaintain.Size = New System.Drawing.Size(931, 92)
        Me.palMaintain.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmbAccountId, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAccountId, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblReceiptAccountId, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbReceiptAccountId, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInsuAccountId, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcc1AccountId, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbInsuAccountId, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbAcc1AccountId, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcc2AccountId, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbAcc2AccountId, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbDc, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(929, 89)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cmbAccountId
        '
        Me.cmbAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAccountId.DropDownWidth = 20
        Me.cmbAccountId.DroppedDown = False
        Me.cmbAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAccountId.Location = New System.Drawing.Point(154, 10)
        Me.cmbAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAccountId.Name = "cmbAccountId"
        Me.cmbAccountId.SelectedIndex = -1
        Me.cmbAccountId.SelectedItem = Nothing
        Me.cmbAccountId.SelectedText = ""
        Me.cmbAccountId.SelectedValue = ""
        Me.cmbAccountId.SelectionStart = 0
        Me.cmbAccountId.Size = New System.Drawing.Size(133, 24)
        Me.cmbAccountId.TabIndex = 0
        Me.cmbAccountId.uclDisplayIndex = "0,1"
        Me.cmbAccountId.uclIsAutoClear = True
        Me.cmbAccountId.uclIsFirstItemEmpty = True
        Me.cmbAccountId.uclIsTextMode = False
        Me.cmbAccountId.uclShowMsg = False
        Me.cmbAccountId.uclValueIndex = "0"
        '
        'lblAccountId
        '
        Me.lblAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAccountId.AutoSize = True
        Me.lblAccountId.ForeColor = System.Drawing.Color.Red
        Me.lblAccountId.Location = New System.Drawing.Point(3, 14)
        Me.lblAccountId.Name = "lblAccountId"
        Me.lblAccountId.Size = New System.Drawing.Size(144, 16)
        Me.lblAccountId.TabIndex = 1
        Me.lblAccountId.Text = "*院內費用項目代碼"
        '
        'lblReceiptAccountId
        '
        Me.lblReceiptAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblReceiptAccountId.AutoSize = True
        Me.lblReceiptAccountId.Location = New System.Drawing.Point(313, 14)
        Me.lblReceiptAccountId.Name = "lblReceiptAccountId"
        Me.lblReceiptAccountId.Size = New System.Drawing.Size(136, 16)
        Me.lblReceiptAccountId.TabIndex = 2
        Me.lblReceiptAccountId.Text = "收據費用項目代碼"
        '
        'cmbReceiptAccountId
        '
        Me.cmbReceiptAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbReceiptAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbReceiptAccountId.DropDownWidth = 20
        Me.cmbReceiptAccountId.DroppedDown = False
        Me.cmbReceiptAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbReceiptAccountId.Location = New System.Drawing.Point(456, 10)
        Me.cmbReceiptAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbReceiptAccountId.Name = "cmbReceiptAccountId"
        Me.cmbReceiptAccountId.SelectedIndex = -1
        Me.cmbReceiptAccountId.SelectedItem = Nothing
        Me.cmbReceiptAccountId.SelectedText = ""
        Me.cmbReceiptAccountId.SelectedValue = ""
        Me.cmbReceiptAccountId.SelectionStart = 0
        Me.cmbReceiptAccountId.Size = New System.Drawing.Size(128, 24)
        Me.cmbReceiptAccountId.TabIndex = 3
        Me.cmbReceiptAccountId.uclDisplayIndex = "0,1"
        Me.cmbReceiptAccountId.uclIsAutoClear = True
        Me.cmbReceiptAccountId.uclIsFirstItemEmpty = True
        Me.cmbReceiptAccountId.uclIsTextMode = False
        Me.cmbReceiptAccountId.uclShowMsg = False
        Me.cmbReceiptAccountId.uclValueIndex = "0"
        '
        'lblInsuAccountId
        '
        Me.lblInsuAccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblInsuAccountId.AutoSize = True
        Me.lblInsuAccountId.Location = New System.Drawing.Point(625, 14)
        Me.lblInsuAccountId.Name = "lblInsuAccountId"
        Me.lblInsuAccountId.Size = New System.Drawing.Size(136, 16)
        Me.lblInsuAccountId.TabIndex = 4
        Me.lblInsuAccountId.Text = "健保費用項目代碼"
        '
        'lblAcc1AccountId
        '
        Me.lblAcc1AccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAcc1AccountId.AutoSize = True
        Me.lblAcc1AccountId.Location = New System.Drawing.Point(3, 58)
        Me.lblAcc1AccountId.Name = "lblAcc1AccountId"
        Me.lblAcc1AccountId.Size = New System.Drawing.Size(144, 16)
        Me.lblAcc1AccountId.TabIndex = 5
        Me.lblAcc1AccountId.Text = "會計費用項目代碼1"
        '
        'cmbInsuAccountId
        '
        Me.cmbInsuAccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbInsuAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbInsuAccountId.DropDownWidth = 20
        Me.cmbInsuAccountId.DroppedDown = False
        Me.cmbInsuAccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbInsuAccountId.Location = New System.Drawing.Point(768, 10)
        Me.cmbInsuAccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbInsuAccountId.Name = "cmbInsuAccountId"
        Me.cmbInsuAccountId.SelectedIndex = -1
        Me.cmbInsuAccountId.SelectedItem = Nothing
        Me.cmbInsuAccountId.SelectedText = ""
        Me.cmbInsuAccountId.SelectedValue = ""
        Me.cmbInsuAccountId.SelectionStart = 0
        Me.cmbInsuAccountId.Size = New System.Drawing.Size(119, 24)
        Me.cmbInsuAccountId.TabIndex = 6
        Me.cmbInsuAccountId.uclDisplayIndex = "0,1"
        Me.cmbInsuAccountId.uclIsAutoClear = True
        Me.cmbInsuAccountId.uclIsFirstItemEmpty = True
        Me.cmbInsuAccountId.uclIsTextMode = False
        Me.cmbInsuAccountId.uclShowMsg = False
        Me.cmbInsuAccountId.uclValueIndex = "0"
        '
        'cmbAcc1AccountId
        '
        Me.cmbAcc1AccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAcc1AccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAcc1AccountId.DropDownWidth = 20
        Me.cmbAcc1AccountId.DroppedDown = False
        Me.cmbAcc1AccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAcc1AccountId.Location = New System.Drawing.Point(154, 54)
        Me.cmbAcc1AccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAcc1AccountId.Name = "cmbAcc1AccountId"
        Me.cmbAcc1AccountId.SelectedIndex = -1
        Me.cmbAcc1AccountId.SelectedItem = Nothing
        Me.cmbAcc1AccountId.SelectedText = ""
        Me.cmbAcc1AccountId.SelectedValue = ""
        Me.cmbAcc1AccountId.SelectionStart = 0
        Me.cmbAcc1AccountId.Size = New System.Drawing.Size(133, 24)
        Me.cmbAcc1AccountId.TabIndex = 7
        Me.cmbAcc1AccountId.uclDisplayIndex = "0,1"
        Me.cmbAcc1AccountId.uclIsAutoClear = True
        Me.cmbAcc1AccountId.uclIsFirstItemEmpty = True
        Me.cmbAcc1AccountId.uclIsTextMode = False
        Me.cmbAcc1AccountId.uclShowMsg = False
        Me.cmbAcc1AccountId.uclValueIndex = "0"
        '
        'lblAcc2AccountId
        '
        Me.lblAcc2AccountId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAcc2AccountId.AutoSize = True
        Me.lblAcc2AccountId.Location = New System.Drawing.Point(305, 58)
        Me.lblAcc2AccountId.Name = "lblAcc2AccountId"
        Me.lblAcc2AccountId.Size = New System.Drawing.Size(144, 16)
        Me.lblAcc2AccountId.TabIndex = 8
        Me.lblAcc2AccountId.Text = "會計費用項目代碼2"
        '
        'cmbAcc2AccountId
        '
        Me.cmbAcc2AccountId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbAcc2AccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbAcc2AccountId.DropDownWidth = 20
        Me.cmbAcc2AccountId.DroppedDown = False
        Me.cmbAcc2AccountId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAcc2AccountId.Location = New System.Drawing.Point(456, 54)
        Me.cmbAcc2AccountId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAcc2AccountId.Name = "cmbAcc2AccountId"
        Me.cmbAcc2AccountId.SelectedIndex = -1
        Me.cmbAcc2AccountId.SelectedItem = Nothing
        Me.cmbAcc2AccountId.SelectedText = ""
        Me.cmbAcc2AccountId.SelectedValue = ""
        Me.cmbAcc2AccountId.SelectionStart = 0
        Me.cmbAcc2AccountId.Size = New System.Drawing.Size(128, 24)
        Me.cmbAcc2AccountId.TabIndex = 9
        Me.cmbAcc2AccountId.uclDisplayIndex = "0,1"
        Me.cmbAcc2AccountId.uclIsAutoClear = True
        Me.cmbAcc2AccountId.uclIsFirstItemEmpty = True
        Me.cmbAcc2AccountId.uclIsTextMode = False
        Me.cmbAcc2AccountId.uclShowMsg = False
        Me.cmbAcc2AccountId.uclValueIndex = "0"
        '
        'ckbDc
        '
        Me.ckbDc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ckbDc.AutoSize = True
        Me.ckbDc.Location = New System.Drawing.Point(702, 56)
        Me.ckbDc.Name = "ckbDc"
        Me.ckbDc.Size = New System.Drawing.Size(59, 20)
        Me.ckbDc.TabIndex = 10
        Me.ckbDc.Text = "停用"
        Me.ckbDc.UseVisualStyleBackColor = True
        '
        'PUBAccountUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 338)
        Me.Controls.Add(Me.palMaintain)
        Me.Name = "PUBAccountUI"
        Me.Text = "PUBAccountUI"
        Me.Controls.SetChildIndex(Me.palMaintain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.palMaintain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents palMaintain As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblAccountId As System.Windows.Forms.Label
    Friend WithEvents lblReceiptAccountId As System.Windows.Forms.Label
    Friend WithEvents cmbReceiptAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblInsuAccountId As System.Windows.Forms.Label
    Friend WithEvents lblAcc1AccountId As System.Windows.Forms.Label
    Friend WithEvents cmbInsuAccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbAcc1AccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblAcc2AccountId As System.Windows.Forms.Label
    Friend WithEvents cmbAcc2AccountId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ckbDc As System.Windows.Forms.CheckBox
End Class
