<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBReportAlarmUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBReportAlarmUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_ReportID = New System.Windows.Forms.Label()
        Me.txt_ReportID = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lbl_RptIsActive = New System.Windows.Forms.Label()
        Me.lbl_RptAlarmCount = New System.Windows.Forms.Label()
        Me.cmb_ReportID = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbt_RptIsActiveYes = New System.Windows.Forms.RadioButton()
        Me.rbt_RptIsActiveNo = New System.Windows.Forms.RadioButton()
        Me.txt_ReportName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txt_RptAlarmCount = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 103)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 538)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 501)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 501)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 7
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 1)
        Me.tlp_Main.Controls.Add(Me.lbl_ReportID, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_ReportID, 1, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_RptIsActive, 5, 0)
        Me.tlp_Main.Controls.Add(Me.lbl_RptAlarmCount, 3, 0)
        Me.tlp_Main.Controls.Add(Me.cmb_ReportID, 2, 0)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 6, 0)
        Me.tlp_Main.Controls.Add(Me.txt_ReportName, 1, 1)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel2, 4, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 103)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "查詢報表名稱"
        '
        'lbl_ReportID
        '
        Me.lbl_ReportID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_ReportID.AutoSize = True
        Me.lbl_ReportID.ForeColor = System.Drawing.Color.Red
        Me.lbl_ReportID.Location = New System.Drawing.Point(43, 17)
        Me.lbl_ReportID.Name = "lbl_ReportID"
        Me.lbl_ReportID.Size = New System.Drawing.Size(64, 16)
        Me.lbl_ReportID.TabIndex = 0
        Me.lbl_ReportID.Text = "*報表ID"
        '
        'txt_ReportID
        '
        Me.txt_ReportID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportID.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ReportID.Location = New System.Drawing.Point(113, 12)
        Me.txt_ReportID.MaxLength = 20
        Me.txt_ReportID.Name = "txt_ReportID"
        Me.txt_ReportID.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ReportID.SelectionStart = 0
        Me.txt_ReportID.Size = New System.Drawing.Size(159, 27)
        Me.txt_ReportID.TabIndex = 3
        Me.txt_ReportID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ReportID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ReportID.ToolTipTag = Nothing
        Me.txt_ReportID.uclDollarSign = False
        Me.txt_ReportID.uclDotCount = 0
        Me.txt_ReportID.uclIntCount = 2
        Me.txt_ReportID.uclMinus = False
        Me.txt_ReportID.uclReadOnly = False
        Me.txt_ReportID.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ReportID.uclTrimZero = True
        '
        'lbl_RptIsActive
        '
        Me.lbl_RptIsActive.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_RptIsActive.AutoSize = True
        Me.lbl_RptIsActive.Location = New System.Drawing.Point(718, 17)
        Me.lbl_RptIsActive.Name = "lbl_RptIsActive"
        Me.lbl_RptIsActive.Size = New System.Drawing.Size(104, 16)
        Me.lbl_RptIsActive.TabIndex = 2
        Me.lbl_RptIsActive.Text = "是否生效啟用"
        '
        'lbl_RptAlarmCount
        '
        Me.lbl_RptAlarmCount.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_RptAlarmCount.AutoSize = True
        Me.lbl_RptAlarmCount.Location = New System.Drawing.Point(410, 17)
        Me.lbl_RptAlarmCount.Name = "lbl_RptAlarmCount"
        Me.lbl_RptAlarmCount.Size = New System.Drawing.Size(104, 16)
        Me.lbl_RptAlarmCount.TabIndex = 1
        Me.lbl_RptAlarmCount.Text = "警示筆數設定"
        '
        'cmb_ReportID
        '
        Me.cmb_ReportID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmb_ReportID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_ReportID.DropDownWidth = 20
        Me.cmb_ReportID.DroppedDown = False
        Me.cmb_ReportID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmb_ReportID.Location = New System.Drawing.Point(275, 12)
        Me.cmb_ReportID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmb_ReportID.Name = "cmb_ReportID"
        Me.cmb_ReportID.SelectedIndex = -1
        Me.cmb_ReportID.SelectedItem = Nothing
        Me.cmb_ReportID.SelectedText = ""
        Me.cmb_ReportID.SelectedValue = ""
        Me.cmb_ReportID.SelectionStart = 0
        Me.cmb_ReportID.Size = New System.Drawing.Size(132, 27)
        Me.cmb_ReportID.TabIndex = 6
        Me.cmb_ReportID.uclDisplayIndex = "0,1"
        Me.cmb_ReportID.uclIsAutoClear = True
        Me.cmb_ReportID.uclIsFirstItemEmpty = True
        Me.cmb_ReportID.uclIsTextMode = False
        Me.cmb_ReportID.uclShowMsg = False
        Me.cmb_ReportID.uclValueIndex = "0"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_RptIsActiveYes)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbt_RptIsActiveNo)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(828, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(130, 45)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'rbt_RptIsActiveYes
        '
        Me.rbt_RptIsActiveYes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_RptIsActiveYes.AutoSize = True
        Me.rbt_RptIsActiveYes.Location = New System.Drawing.Point(3, 11)
        Me.rbt_RptIsActiveYes.Margin = New System.Windows.Forms.Padding(3, 11, 3, 3)
        Me.rbt_RptIsActiveYes.Name = "rbt_RptIsActiveYes"
        Me.rbt_RptIsActiveYes.Size = New System.Drawing.Size(58, 20)
        Me.rbt_RptIsActiveYes.TabIndex = 2
        Me.rbt_RptIsActiveYes.TabStop = True
        Me.rbt_RptIsActiveYes.Text = "啟用"
        Me.rbt_RptIsActiveYes.UseVisualStyleBackColor = True
        '
        'rbt_RptIsActiveNo
        '
        Me.rbt_RptIsActiveNo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbt_RptIsActiveNo.AutoSize = True
        Me.rbt_RptIsActiveNo.Location = New System.Drawing.Point(67, 11)
        Me.rbt_RptIsActiveNo.Margin = New System.Windows.Forms.Padding(3, 11, 3, 3)
        Me.rbt_RptIsActiveNo.Name = "rbt_RptIsActiveNo"
        Me.rbt_RptIsActiveNo.Size = New System.Drawing.Size(58, 20)
        Me.rbt_RptIsActiveNo.TabIndex = 3
        Me.rbt_RptIsActiveNo.TabStop = True
        Me.rbt_RptIsActiveNo.Text = "停用"
        Me.rbt_RptIsActiveNo.UseVisualStyleBackColor = True
        '
        'txt_ReportName
        '
        Me.txt_ReportName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_ReportName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_ReportName.Location = New System.Drawing.Point(113, 63)
        Me.txt_ReportName.MaxLength = 20
        Me.txt_ReportName.Name = "txt_ReportName"
        Me.txt_ReportName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_ReportName.SelectionStart = 0
        Me.txt_ReportName.Size = New System.Drawing.Size(159, 27)
        Me.txt_ReportName.TabIndex = 9
        Me.txt_ReportName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_ReportName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_ReportName.ToolTipTag = Nothing
        Me.txt_ReportName.uclDollarSign = False
        Me.txt_ReportName.uclDotCount = 0
        Me.txt_ReportName.uclIntCount = 2
        Me.txt_ReportName.uclMinus = False
        Me.txt_ReportName.uclReadOnly = False
        Me.txt_ReportName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_ReportName.uclTrimZero = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanel2.Controls.Add(Me.txt_RptAlarmCount)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(520, 6)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(192, 38)
        Me.FlowLayoutPanel2.TabIndex = 12
        '
        'txt_RptAlarmCount
        '
        Me.txt_RptAlarmCount.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_RptAlarmCount.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_RptAlarmCount.Location = New System.Drawing.Point(3, 3)
        Me.txt_RptAlarmCount.MaxLength = 10
        Me.txt_RptAlarmCount.Name = "txt_RptAlarmCount"
        Me.txt_RptAlarmCount.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_RptAlarmCount.SelectionStart = 0
        Me.txt_RptAlarmCount.Size = New System.Drawing.Size(56, 27)
        Me.txt_RptAlarmCount.TabIndex = 4
        Me.txt_RptAlarmCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_RptAlarmCount.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_RptAlarmCount.ToolTipTag = Nothing
        Me.txt_RptAlarmCount.uclDollarSign = False
        Me.txt_RptAlarmCount.uclDotCount = 0
        Me.txt_RptAlarmCount.uclIntCount = 2
        Me.txt_RptAlarmCount.uclMinus = False
        Me.txt_RptAlarmCount.uclReadOnly = False
        Me.txt_RptAlarmCount.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_RptAlarmCount.uclTrimZero = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "(最低比數100筆)"
        '
        'PUBReportAlarmUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Name = "PUBReportAlarmUI"
        Me.Text = "報表警示設定維護檔"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_ReportID As System.Windows.Forms.Label
    Friend WithEvents lbl_RptAlarmCount As System.Windows.Forms.Label
    Friend WithEvents txt_ReportID As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lbl_RptIsActive As System.Windows.Forms.Label
    Friend WithEvents cmb_ReportID As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbt_RptIsActiveYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbt_RptIsActiveNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ReportName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txt_RptAlarmCount As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
