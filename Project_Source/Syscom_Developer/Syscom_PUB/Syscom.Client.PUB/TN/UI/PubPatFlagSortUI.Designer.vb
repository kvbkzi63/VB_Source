<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPatFlagSortUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PubPatFlagSortUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbtFlagSortId1 = New System.Windows.Forms.RadioButton()
        Me.rbtFlagSortId2 = New System.Windows.Forms.RadioButton()
        Me.txtFlagSortContent = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cboFlagId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 68)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 574)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 537)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 537)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 376.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412.0!))
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label3, 2, 0)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txtFlagSortContent, 1, 1)
        Me.tlp_Main.Controls.Add(Me.cboFlagId, 1, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.41177!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.58823!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 68)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*特殊註記"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "內容值"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(473, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "顯示分類"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtFlagSortId1)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtFlagSortId2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(555, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(406, 31)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'rbtFlagSortId1
        '
        Me.rbtFlagSortId1.AutoSize = True
        Me.rbtFlagSortId1.Location = New System.Drawing.Point(3, 3)
        Me.rbtFlagSortId1.Name = "rbtFlagSortId1"
        Me.rbtFlagSortId1.Size = New System.Drawing.Size(74, 20)
        Me.rbtFlagSortId1.TabIndex = 0
        Me.rbtFlagSortId1.TabStop = True
        Me.rbtFlagSortId1.Text = "系統別"
        Me.rbtFlagSortId1.UseVisualStyleBackColor = True
        '
        'rbtFlagSortId2
        '
        Me.rbtFlagSortId2.AutoSize = True
        Me.rbtFlagSortId2.Location = New System.Drawing.Point(83, 3)
        Me.rbtFlagSortId2.Name = "rbtFlagSortId2"
        Me.rbtFlagSortId2.Size = New System.Drawing.Size(58, 20)
        Me.rbtFlagSortId2.TabIndex = 0
        Me.rbtFlagSortId2.TabStop = True
        Me.rbtFlagSortId2.Text = "角色"
        Me.rbtFlagSortId2.UseVisualStyleBackColor = True
        '
        'txtFlagSortContent
        '
        Me.txtFlagSortContent.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtFlagSortContent.Location = New System.Drawing.Point(97, 40)
        Me.txtFlagSortContent.MaxLength = 10
        Me.txtFlagSortContent.Name = "txtFlagSortContent"
        Me.txtFlagSortContent.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFlagSortContent.SelectionStart = 0
        Me.txtFlagSortContent.Size = New System.Drawing.Size(339, 27)
        Me.txtFlagSortContent.TabIndex = 2
        Me.txtFlagSortContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFlagSortContent.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtFlagSortContent.ToolTipTag = Nothing
        Me.txtFlagSortContent.uclDollarSign = False
        Me.txtFlagSortContent.uclDotCount = 0
        Me.txtFlagSortContent.uclIntCount = 2
        Me.txtFlagSortContent.uclMinus = False
        Me.txtFlagSortContent.uclReadOnly = False
        Me.txtFlagSortContent.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtFlagSortContent.uclTrimZero = True
        '
        'cboFlagId
        '
        Me.cboFlagId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboFlagId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlagId.DropDownWidth = 20
        Me.cboFlagId.DroppedDown = False
        Me.cboFlagId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboFlagId.Location = New System.Drawing.Point(94, 6)
        Me.cboFlagId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboFlagId.Name = "cboFlagId"
        Me.cboFlagId.SelectedIndex = -1
        Me.cboFlagId.SelectedItem = Nothing
        Me.cboFlagId.SelectedText = ""
        Me.cboFlagId.SelectedValue = ""
        Me.cboFlagId.SelectionStart = 0
        Me.cboFlagId.Size = New System.Drawing.Size(342, 24)
        Me.cboFlagId.TabIndex = 3
        Me.cboFlagId.uclDisplayIndex = "0,1"
        Me.cboFlagId.uclIsAutoClear = True
        Me.cboFlagId.uclIsFirstItemEmpty = True
        Me.cboFlagId.uclIsTextMode = False
        Me.cboFlagId.uclShowMsg = False
        Me.cboFlagId.uclValueIndex = "0"
        '
        'PubPatFlagSortUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PubPatFlagSortUI"
        Me.TabText = "PubPatFlagSortUI"
        Me.Text = "PubPatFlagSortUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbtFlagSortId1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFlagSortId2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtFlagSortContent As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cboFlagId As Syscom.Client.UCL.UCLComboBoxUC
End Class
