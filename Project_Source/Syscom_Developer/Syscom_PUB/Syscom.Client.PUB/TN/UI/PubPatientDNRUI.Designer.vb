<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPatientDNRUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PubPatientDNRUI))
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.txtChartNo = New Syscom.Client.UCL.UCLChartNoUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbtSourceKind1 = New System.Windows.Forms.RadioButton()
        Me.rbtSourceKind2 = New System.Windows.Forms.RadioButton()
        Me.cboDNRKindId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtIdno = New Syscom.Client.UCL.UCLChartNoUC()
        Me.txtPatientName = New Syscom.Client.UCL.UCLChartNoUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 70)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 572)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 535)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 535)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 6
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 358.0!))
        Me.tlp_Main.Controls.Add(Me.txtChartNo, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label3, 4, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label5, 2, 1)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.tlp_Main.Controls.Add(Me.cboDNRKindId, 3, 1)
        Me.tlp_Main.Controls.Add(Me.txtIdno, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txtPatientName, 5, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 2
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 70)
        Me.tlp_Main.TabIndex = 0
        '
        'txtChartNo
        '
        Me.txtChartNo.doFlag = False
        Me.txtChartNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtChartNo.IsAutoAddZero = False
        Me.txtChartNo.IsShowAddress = False
        Me.txtChartNo.IsShowTelHome = False
        Me.txtChartNo.Location = New System.Drawing.Point(95, 4)
        Me.txtChartNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChartNo.Name = "txtChartNo"
        Me.txtChartNo.Size = New System.Drawing.Size(140, 27)
        Me.txtChartNo.TabIndex = 6
        Me.txtChartNo.uclDigitCount = 8
        Me.txtChartNo.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.txtChartNo.uclIsDoReserveChartNo = True
        Me.txtChartNo.uclIsInteractionChartNo = True
        Me.txtChartNo.uclIsNameInputAutoPopWindow = False
        Me.txtChartNo.uclIsShowReserveChartNoMsg = True
        Me.txtChartNo.uclIsShowReserveChartNoQuestionMsg = False
        Me.txtChartNo.uclNeedCheckId = True
        Me.txtChartNo.uclNeedCheckIdByPubBP = True
        Me.txtChartNo.uclNeedSql = True
        Me.txtChartNo.uclReadOnly = False
        Me.txtChartNo.uclTextType = Syscom.Client.UCL.UCLChartNoUC.uclTextTypeData.ChartNo
        Me.txtChartNo.uclTxtBoxWidth = 140
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*病歷號"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(272, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "身分證號"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(553, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "姓名"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "來源"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(272, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "DNR類別"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtSourceKind1)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbtSourceKind2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(94, 38)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(172, 29)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'rbtSourceKind1
        '
        Me.rbtSourceKind1.AutoSize = True
        Me.rbtSourceKind1.Location = New System.Drawing.Point(3, 3)
        Me.rbtSourceKind1.Name = "rbtSourceKind1"
        Me.rbtSourceKind1.Size = New System.Drawing.Size(74, 20)
        Me.rbtSourceKind1.TabIndex = 0
        Me.rbtSourceKind1.TabStop = True
        Me.rbtSourceKind1.Text = "健保局"
        Me.rbtSourceKind1.UseVisualStyleBackColor = True
        '
        'rbtSourceKind2
        '
        Me.rbtSourceKind2.AutoSize = True
        Me.rbtSourceKind2.Location = New System.Drawing.Point(83, 3)
        Me.rbtSourceKind2.Name = "rbtSourceKind2"
        Me.rbtSourceKind2.Size = New System.Drawing.Size(58, 20)
        Me.rbtSourceKind2.TabIndex = 1
        Me.rbtSourceKind2.TabStop = True
        Me.rbtSourceKind2.Text = "醫院"
        Me.rbtSourceKind2.UseVisualStyleBackColor = True
        '
        'cboDNRKindId
        '
        Me.cboDNRKindId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDNRKindId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDNRKindId.DropDownWidth = 20
        Me.cboDNRKindId.DroppedDown = False
        Me.cboDNRKindId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboDNRKindId.Location = New System.Drawing.Point(359, 40)
        Me.cboDNRKindId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboDNRKindId.Name = "cboDNRKindId"
        Me.cboDNRKindId.SelectedIndex = -1
        Me.cboDNRKindId.SelectedItem = Nothing
        Me.cboDNRKindId.SelectedText = ""
        Me.cboDNRKindId.SelectedValue = ""
        Me.cboDNRKindId.SelectionStart = 0
        Me.cboDNRKindId.Size = New System.Drawing.Size(174, 24)
        Me.cboDNRKindId.TabIndex = 10
        Me.cboDNRKindId.uclDisplayIndex = "0,1"
        Me.cboDNRKindId.uclIsAutoClear = True
        Me.cboDNRKindId.uclIsFirstItemEmpty = True
        Me.cboDNRKindId.uclIsTextMode = False
        Me.cboDNRKindId.uclShowMsg = False
        Me.cboDNRKindId.uclValueIndex = "0"
        '
        'txtIdno
        '
        Me.txtIdno.doFlag = False
        Me.txtIdno.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtIdno.IsAutoAddZero = False
        Me.txtIdno.IsShowAddress = False
        Me.txtIdno.IsShowTelHome = False
        Me.txtIdno.Location = New System.Drawing.Point(363, 4)
        Me.txtIdno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdno.Name = "txtIdno"
        Me.txtIdno.Size = New System.Drawing.Size(140, 27)
        Me.txtIdno.TabIndex = 11
        Me.txtIdno.uclDigitCount = 10
        Me.txtIdno.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.txtIdno.uclIsDoReserveChartNo = True
        Me.txtIdno.uclIsInteractionChartNo = True
        Me.txtIdno.uclIsNameInputAutoPopWindow = False
        Me.txtIdno.uclIsShowReserveChartNoMsg = True
        Me.txtIdno.uclIsShowReserveChartNoQuestionMsg = False
        Me.txtIdno.uclNeedCheckId = True
        Me.txtIdno.uclNeedCheckIdByPubBP = True
        Me.txtIdno.uclNeedSql = True
        Me.txtIdno.uclReadOnly = True
        Me.txtIdno.uclTextType = Syscom.Client.UCL.UCLChartNoUC.uclTextTypeData.IdNo
        Me.txtIdno.uclTxtBoxWidth = 140
        '
        'txtPatientName
        '
        Me.txtPatientName.doFlag = False
        Me.txtPatientName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPatientName.IsAutoAddZero = False
        Me.txtPatientName.IsShowAddress = False
        Me.txtPatientName.IsShowTelHome = False
        Me.txtPatientName.Location = New System.Drawing.Point(610, 4)
        Me.txtPatientName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(140, 27)
        Me.txtPatientName.TabIndex = 11
        Me.txtPatientName.uclDigitCount = 10
        Me.txtPatientName.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.txtPatientName.uclIsDoReserveChartNo = True
        Me.txtPatientName.uclIsInteractionChartNo = True
        Me.txtPatientName.uclIsNameInputAutoPopWindow = False
        Me.txtPatientName.uclIsShowReserveChartNoMsg = True
        Me.txtPatientName.uclIsShowReserveChartNoQuestionMsg = False
        Me.txtPatientName.uclNeedCheckId = True
        Me.txtPatientName.uclNeedCheckIdByPubBP = True
        Me.txtPatientName.uclNeedSql = True
        Me.txtPatientName.uclReadOnly = True
        Me.txtPatientName.uclTextType = Syscom.Client.UCL.UCLChartNoUC.uclTextTypeData.PatientName
        Me.txtPatientName.uclTxtBoxWidth = 140
        '
        'PubPatientDNRUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 642)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PubPatientDNRUI"
        Me.TabText = "PubPatientDNRUI"
        Me.Text = "PubPatientDNRUI"
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtChartNo As Syscom.Client.UCL.UCLChartNoUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbtSourceKind1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSourceKind2 As System.Windows.Forms.RadioButton
    Friend WithEvents cboDNRKindId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtIdno As Syscom.Client.UCL.UCLChartNoUC
    Friend WithEvents txtPatientName As Syscom.Client.UCL.UCLChartNoUC
End Class
