<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UclMutiGridUI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UclMutiGridUI))
        Me.flp_Button = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_Show = New Syscom.Client.UCL.UCLDataGridViewUC()
        Me.rtb_Phrase = New System.Windows.Forms.RichTextBox()
        Me.cbo_Phrase = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.flp_Button.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'flp_Button
        '
        Me.flp_Button.Controls.Add(Me.btn_Cancel)
        Me.flp_Button.Controls.Add(Me.btn_Confirm)
        Me.flp_Button.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flp_Button.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flp_Button.Location = New System.Drawing.Point(0, 583)
        Me.flp_Button.Name = "flp_Button"
        Me.flp_Button.Size = New System.Drawing.Size(964, 37)
        Me.flp_Button.TabIndex = 1
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(871, 3)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(90, 28)
        Me.btn_Cancel.TabIndex = 0
        Me.btn_Cancel.Text = "取消"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Location = New System.Drawing.Point(775, 3)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(90, 28)
        Me.btn_Confirm.TabIndex = 1
        Me.btn_Confirm.Text = "確認"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_Show, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rtb_Phrase, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Phrase, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(964, 583)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'dgv_Show
        '
        Me.dgv_Show.AllowUserToAddRows = False
        Me.dgv_Show.AllowUserToOrderColumns = False
        Me.dgv_Show.AllowUserToResizeColumns = True
        Me.dgv_Show.AllowUserToResizeRows = False
        Me.dgv_Show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgv_Show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Show.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Show.ColumnHeadersHeight = 4
        Me.dgv_Show.ColumnHeadersVisible = True
        Me.dgv_Show.CurrentCell = Nothing
        Me.dgv_Show.DataSource = Nothing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Show.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Show.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2
        Me.dgv_Show.Location = New System.Drawing.Point(4, 4)
        Me.dgv_Show.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_Show.MultiSelect = True
        Me.dgv_Show.MultiSelectType = Syscom.Client.UCL.UCLDataGridViewUC.SelectType.SelectAll
        Me.dgv_Show.Name = "dgv_Show"
        Me.dgv_Show.RowHeadersWidth = 41
        Me.dgv_Show.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dgv_Show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Show.Size = New System.Drawing.Size(964, 437)
        Me.dgv_Show.TabIndex = 0
        Me.dgv_Show.uclAlternatingRowsColors = System.Drawing.Color.White
        Me.dgv_Show.uclBatchColIndex = ""
        Me.dgv_Show.uclClickToCheck = False
        Me.dgv_Show.uclColumnAlignment = ""
        Me.dgv_Show.uclColumnCheckBox = True
        Me.dgv_Show.uclColumnControlType = ""
        Me.dgv_Show.uclColumnWidth = ""
        Me.dgv_Show.uclDoCellEnter = True
        Me.dgv_Show.uclHasNewRow = False
        Me.dgv_Show.uclHeaderText = ""
        Me.dgv_Show.uclIsAlternatingRowsColors = True
        Me.dgv_Show.uclIsComboBoxGridQuery = True
        Me.dgv_Show.uclIsComboxClickTriggerDropDown = False
        Me.dgv_Show.uclIsDoOrderCheck = True
        Me.dgv_Show.uclIsDoQueryComboBoxGrid = True
        Me.dgv_Show.uclIsSortable = False
        Me.dgv_Show.uclMultiSelectShowCheckBoxHeader = True
        Me.dgv_Show.uclNonVisibleColIndex = ""
        Me.dgv_Show.uclReadOnly = False
        Me.dgv_Show.uclShowCellBorder = False
        Me.dgv_Show.uclSortColIndex = ""
        Me.dgv_Show.uclTreeMode = False
        Me.dgv_Show.uclVisibleColIndex = ""
        '
        'rtb_Phrase
        '
        Me.rtb_Phrase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Phrase.Location = New System.Drawing.Point(3, 448)
        Me.rtb_Phrase.Name = "rtb_Phrase"
        Me.rtb_Phrase.Size = New System.Drawing.Size(966, 94)
        Me.rtb_Phrase.TabIndex = 1
        Me.rtb_Phrase.Text = ""
        '
        'cbo_Phrase
        '
        Me.cbo_Phrase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_Phrase.DropDownWidth = 20
        Me.cbo_Phrase.DroppedDown = False
        Me.cbo_Phrase.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Phrase.Location = New System.Drawing.Point(0, 545)
        Me.cbo_Phrase.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Phrase.Name = "cbo_Phrase"
        Me.cbo_Phrase.SelectedIndex = -1
        Me.cbo_Phrase.SelectedItem = Nothing
        Me.cbo_Phrase.SelectedText = ""
        Me.cbo_Phrase.SelectedValue = ""
        Me.cbo_Phrase.SelectionStart = 0
        Me.cbo_Phrase.Size = New System.Drawing.Size(302, 24)
        Me.cbo_Phrase.TabIndex = 2
        Me.cbo_Phrase.uclDisplayIndex = "0,1"
        Me.cbo_Phrase.uclIsAutoClear = True
        Me.cbo_Phrase.uclIsFirstItemEmpty = True
        Me.cbo_Phrase.uclIsTextMode = False
        Me.cbo_Phrase.uclShowMsg = False
        Me.cbo_Phrase.uclValueIndex = "0"
        '
        'UclMutiGridUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 620)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.flp_Button)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "UclMutiGridUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabText = "多選作業畫面"
        Me.Text = "多選作業畫面"
        Me.flp_Button.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Show As Syscom.Client.UCL.UCLDataGridViewUC
    Friend WithEvents flp_Button As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Confirm As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rtb_Phrase As System.Windows.Forms.RichTextBox
    Friend WithEvents cbo_Phrase As Syscom.Client.UCL.UCLComboBoxUC
End Class
