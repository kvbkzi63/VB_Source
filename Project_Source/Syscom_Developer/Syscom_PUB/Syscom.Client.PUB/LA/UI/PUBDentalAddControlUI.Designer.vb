<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBDentalAddControlUI
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlp_1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tcqDeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblDoctorCode = New System.Windows.Forms.Label()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.ckbDc = New System.Windows.Forms.CheckBox()
        Me.txtDoctorCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.tcqOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlp_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 89)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(989, 404)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(987, 367)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(987, 367)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tlp_1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 86)
        Me.Panel1.TabIndex = 0
        '
        'tlp_1
        '
        Me.tlp_1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_1.ColumnCount = 4
        Me.tlp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_1.Controls.Add(Me.tcqDeptCode, 1, 0)
        Me.tlp_1.Controls.Add(Me.lblDoctorCode, 2, 0)
        Me.tlp_1.Controls.Add(Me.lblDeptCode, 0, 0)
        Me.tlp_1.Controls.Add(Me.lblOrderCode, 0, 1)
        Me.tlp_1.Controls.Add(Me.ckbDc, 3, 1)
        Me.tlp_1.Controls.Add(Me.txtDoctorCode, 3, 0)
        Me.tlp_1.Controls.Add(Me.tcqOrderCode, 1, 1)
        Me.tlp_1.Location = New System.Drawing.Point(3, 3)
        Me.tlp_1.Name = "tlp_1"
        Me.tlp_1.RowCount = 2
        Me.tlp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_1.Size = New System.Drawing.Size(983, 80)
        Me.tlp_1.TabIndex = 0
        '
        'tcqDeptCode
        '
        Me.tcqDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcqDeptCode.doFlag = True
        Me.tcqDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcqDeptCode.Location = New System.Drawing.Point(118, 7)
        Me.tcqDeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcqDeptCode.Name = "tcqDeptCode"
        Me.tcqDeptCode.Size = New System.Drawing.Size(342, 26)
        Me.tcqDeptCode.TabIndex = 0
        Me.tcqDeptCode.uclBaseDate = "2015/05/01"
        Me.tcqDeptCode.uclCboWidth = 306
        Me.tcqDeptCode.uclCodeName = ""
        Me.tcqDeptCode.uclCodeValue1 = ""
        Me.tcqDeptCode.uclCodeValue2 = ""
        Me.tcqDeptCode.uclControlFlag = True
        Me.tcqDeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcqDeptCode.uclDisplayIndex = "0,1"
        Me.tcqDeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcqDeptCode.uclIsAutoAddZero = False
        Me.tcqDeptCode.uclIsCheckDoctorOnDuty = False
        Me.tcqDeptCode.uclIsReturnDS = False
        Me.tcqDeptCode.uclIsShowMsgBox = True
        Me.tcqDeptCode.uclIsTextAutoClear = True
        Me.tcqDeptCode.uclMsgValue = Nothing
        Me.tcqDeptCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcqDeptCode.uclQueryField = Nothing
        Me.tcqDeptCode.uclQueryValue = Nothing
        Me.tcqDeptCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcqDeptCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.tcqDeptCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcqDeptCode.uclTotalWidth = 8
        Me.tcqDeptCode.uclXPosition = 225
        Me.tcqDeptCode.uclYPosition = 120
        '
        'lblDoctorCode
        '
        Me.lblDoctorCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDoctorCode.AutoSize = True
        Me.lblDoctorCode.ForeColor = System.Drawing.Color.Red
        Me.lblDoctorCode.Location = New System.Drawing.Point(463, 12)
        Me.lblDoctorCode.Name = "lblDoctorCode"
        Me.lblDoctorCode.Size = New System.Drawing.Size(80, 16)
        Me.lblDoctorCode.TabIndex = 3
        Me.lblDoctorCode.Text = "*醫師代號"
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(3, 12)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(112, 16)
        Me.lblDeptCode.TabIndex = 1
        Me.lblDeptCode.Text = "*院內科別代碼"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(3, 52)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(64, 16)
        Me.lblOrderCode.TabIndex = 2
        Me.lblOrderCode.Text = "*醫令碼"
        '
        'ckbDc
        '
        Me.ckbDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDc.AutoSize = True
        Me.ckbDc.Location = New System.Drawing.Point(549, 50)
        Me.ckbDc.Name = "ckbDc"
        Me.ckbDc.Size = New System.Drawing.Size(59, 20)
        Me.ckbDc.TabIndex = 3
        Me.ckbDc.Text = "停用"
        Me.ckbDc.UseVisualStyleBackColor = True
        '
        'txtDoctorCode
        '
        Me.txtDoctorCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDoctorCode.doFlag = True
        Me.txtDoctorCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDoctorCode.Location = New System.Drawing.Point(546, 7)
        Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDoctorCode.Name = "txtDoctorCode"
        Me.txtDoctorCode.Size = New System.Drawing.Size(408, 26)
        Me.txtDoctorCode.TabIndex = 1
        Me.txtDoctorCode.uclBaseDate = "2015/05/01"
        Me.txtDoctorCode.uclCboWidth = 372
        Me.txtDoctorCode.uclCodeName = ""
        Me.txtDoctorCode.uclCodeValue1 = ""
        Me.txtDoctorCode.uclCodeValue2 = ""
        Me.txtDoctorCode.uclControlFlag = True
        Me.txtDoctorCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtDoctorCode.uclDisplayIndex = "0,1"
        Me.txtDoctorCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtDoctorCode.uclIsAutoAddZero = False
        Me.txtDoctorCode.uclIsCheckDoctorOnDuty = False
        Me.txtDoctorCode.uclIsReturnDS = False
        Me.txtDoctorCode.uclIsShowMsgBox = True
        Me.txtDoctorCode.uclIsTextAutoClear = True
        Me.txtDoctorCode.uclMsgValue = Nothing
        Me.txtDoctorCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtDoctorCode.uclQueryField = Nothing
        Me.txtDoctorCode.uclQueryValue = Nothing
        Me.txtDoctorCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtDoctorCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.txtDoctorCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txtDoctorCode.uclTotalWidth = 8
        Me.txtDoctorCode.uclXPosition = 225
        Me.txtDoctorCode.uclYPosition = 120
        '
        'tcqOrderCode
        '
        Me.tcqOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcqOrderCode.doFlag = True
        Me.tcqOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcqOrderCode.Location = New System.Drawing.Point(118, 47)
        Me.tcqOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcqOrderCode.Name = "tcqOrderCode"
        Me.tcqOrderCode.Size = New System.Drawing.Size(342, 26)
        Me.tcqOrderCode.TabIndex = 2
        Me.tcqOrderCode.uclBaseDate = "2015/05/01"
        Me.tcqOrderCode.uclCboWidth = 306
        Me.tcqOrderCode.uclCodeName = ""
        Me.tcqOrderCode.uclCodeValue1 = ""
        Me.tcqOrderCode.uclCodeValue2 = ""
        Me.tcqOrderCode.uclControlFlag = True
        Me.tcqOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcqOrderCode.uclDisplayIndex = "0,1"
        Me.tcqOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcqOrderCode.uclIsAutoAddZero = False
        Me.tcqOrderCode.uclIsCheckDoctorOnDuty = False
        Me.tcqOrderCode.uclIsReturnDS = False
        Me.tcqOrderCode.uclIsShowMsgBox = True
        Me.tcqOrderCode.uclIsTextAutoClear = True
        Me.tcqOrderCode.uclMsgValue = Nothing
        Me.tcqOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcqOrderCode.uclQueryField = Nothing
        Me.tcqOrderCode.uclQueryValue = Nothing
        Me.tcqOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcqOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.tcqOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcqOrderCode.uclTotalWidth = 8
        Me.tcqOrderCode.uclXPosition = 225
        Me.tcqOrderCode.uclYPosition = 120
        '
        'PUBDentalAddControlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 493)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PUBDentalAddControlUI"
        Me.TabText = "牙科轉診加成控制檔維護"
        Me.Text = "牙科轉診加成控制檔維護"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tlp_1.ResumeLayout(False)
        Me.tlp_1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlp_1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tcqDeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lblDoctorCode As System.Windows.Forms.Label
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents txtDoctorCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents ckbDc As System.Windows.Forms.CheckBox
    Friend WithEvents tcqOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
