<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBExamineUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBExamineUI))
        Me.palMantain = New System.Windows.Forms.Panel()
        Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMainIdentityId = New System.Windows.Forms.Label()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.chkFirstReg = New System.Windows.Forms.CheckBox()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.cmbExamineTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblExamineTypeId = New System.Windows.Forms.Label()
        Me.lblSectionId = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.txtDeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.cmbSectionId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.ckbDC = New System.Windows.Forms.CheckBox()
        Me.cmbMedicalTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.palMantain.SuspendLayout()
        Me.tlpHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 80)
        Me.IUCLMaintainPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.IUCLMaintainPanel.Padding = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 400)
        Me.IUCLMaintainPanel.TabIndex = 0
        '
        'pal_1
        '
        Me.pal_1.Location = New System.Drawing.Point(2, 36)
        Me.pal_1.Size = New System.Drawing.Size(981, 363)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(981, 363)
        '
        'palMantain
        '
        Me.palMantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palMantain.Controls.Add(Me.tlpHeader)
        Me.palMantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.palMantain.Location = New System.Drawing.Point(0, 0)
        Me.palMantain.Margin = New System.Windows.Forms.Padding(4)
        Me.palMantain.Name = "palMantain"
        Me.palMantain.Size = New System.Drawing.Size(985, 80)
        Me.palMantain.TabIndex = 0
        '
        'tlpHeader
        '
        Me.tlpHeader.ColumnCount = 9
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHeader.Controls.Add(Me.lblMainIdentityId, 0, 0)
        Me.tlpHeader.Controls.Add(Me.cmbSubIdentityCode, 1, 0)
        Me.tlpHeader.Controls.Add(Me.chkFirstReg, 2, 0)
        Me.tlpHeader.Controls.Add(Me.lblDeptCode, 3, 0)
        Me.tlpHeader.Controls.Add(Me.txtOrderCode, 7, 1)
        Me.tlpHeader.Controls.Add(Me.cmbExamineTypeId, 4, 1)
        Me.tlpHeader.Controls.Add(Me.lblExamineTypeId, 2, 1)
        Me.tlpHeader.Controls.Add(Me.lblSectionId, 6, 0)
        Me.tlpHeader.Controls.Add(Me.lblOrderCode, 6, 1)
        Me.tlpHeader.Controls.Add(Me.txtDeptCode, 5, 0)
        Me.tlpHeader.Controls.Add(Me.cmbSectionId, 7, 0)
        Me.tlpHeader.Controls.Add(Me.ckbDC, 8, 1)
        Me.tlpHeader.Controls.Add(Me.cmbMedicalTypeId, 1, 1)
        Me.tlpHeader.Controls.Add(Me.Label1, 0, 1)
        Me.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpHeader.Location = New System.Drawing.Point(0, 0)
        Me.tlpHeader.Name = "tlpHeader"
        Me.tlpHeader.RowCount = 2
        Me.tlpHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpHeader.Size = New System.Drawing.Size(983, 78)
        Me.tlpHeader.TabIndex = 0
        '
        'lblMainIdentityId
        '
        Me.lblMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMainIdentityId.AutoSize = True
        Me.lblMainIdentityId.ForeColor = System.Drawing.Color.Red
        Me.lblMainIdentityId.Location = New System.Drawing.Point(4, 11)
        Me.lblMainIdentityId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMainIdentityId.Name = "lblMainIdentityId"
        Me.lblMainIdentityId.Size = New System.Drawing.Size(64, 16)
        Me.lblMainIdentityId.TabIndex = 0
        Me.lblMainIdentityId.Text = "*身份二"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(94, 7)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(161, 24)
        Me.cmbSubIdentityCode.TabIndex = 0
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'chkFirstReg
        '
        Me.chkFirstReg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkFirstReg.AutoSize = True
        Me.chkFirstReg.ForeColor = System.Drawing.Color.Red
        Me.chkFirstReg.Location = New System.Drawing.Point(264, 9)
        Me.chkFirstReg.Name = "chkFirstReg"
        Me.chkFirstReg.Size = New System.Drawing.Size(67, 20)
        Me.chkFirstReg.TabIndex = 1
        Me.chkFirstReg.Text = "*初診"
        Me.chkFirstReg.UseVisualStyleBackColor = True
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptCode.AutoSize = True
        Me.tlpHeader.SetColumnSpan(Me.lblDeptCode, 2)
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(338, 11)
        Me.lblDeptCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(80, 16)
        Me.lblDeptCode.TabIndex = 2
        Me.lblDeptCode.Text = "*院內科別"
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(710, 45)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(176, 26)
        Me.txtOrderCode.TabIndex = 6
        Me.txtOrderCode.uclBaseDate = "2015/05/01"
        Me.txtOrderCode.uclCboWidth = 140
        Me.txtOrderCode.uclCodeName = ""
        Me.txtOrderCode.uclCodeName1 = ""
        Me.txtOrderCode.uclCodeName2 = ""
        Me.txtOrderCode.uclCodeValue = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.uclCodeValue2 = ""
        Me.txtOrderCode.uclControlFlag = True
        Me.txtOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtOrderCode.uclDisplayIndex = "0,1"
        Me.txtOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtOrderCode.uclIsAutoAddZero = False
        Me.txtOrderCode.uclIsBtnVisible = True
        Me.txtOrderCode.uclIsCheckDoctorOnDuty = False
        Me.txtOrderCode.uclIsEnglishDept = False
        Me.txtOrderCode.uclIsReturnDS = False
        Me.txtOrderCode.uclIsShowMsgBox = True
        Me.txtOrderCode.uclIsTextAutoClear = True
        Me.txtOrderCode.uclLabel = ""
        Me.txtOrderCode.uclMsgValue = Nothing
        Me.txtOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtOrderCode.uclQueryField = Nothing
        Me.txtOrderCode.uclQueryValue = Nothing
        Me.txtOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.txtOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txtOrderCode.uclTotalWidth = 8
        Me.txtOrderCode.uclXPosition = 225
        Me.txtOrderCode.uclYPosition = 120
        '
        'cmbExamineTypeId
        '
        Me.cmbExamineTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlpHeader.SetColumnSpan(Me.cmbExamineTypeId, 2)
        Me.cmbExamineTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbExamineTypeId.DropDownWidth = 20
        Me.cmbExamineTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbExamineTypeId.Location = New System.Drawing.Point(371, 46)
        Me.cmbExamineTypeId.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbExamineTypeId.Name = "cmbExamineTypeId"
        Me.cmbExamineTypeId.SelectedIndex = -1
        Me.cmbExamineTypeId.SelectedItem = Nothing
        Me.cmbExamineTypeId.SelectedText = ""
        Me.cmbExamineTypeId.SelectedValue = ""
        Me.cmbExamineTypeId.SelectionStart = 0
        Me.cmbExamineTypeId.Size = New System.Drawing.Size(263, 24)
        Me.cmbExamineTypeId.TabIndex = 5
        Me.cmbExamineTypeId.uclDisplayIndex = "0,1"
        Me.cmbExamineTypeId.uclIsAutoClear = True
        Me.cmbExamineTypeId.uclIsFirstItemEmpty = True
        Me.cmbExamineTypeId.uclIsTextMode = False
        Me.cmbExamineTypeId.uclShowMsg = False
        Me.cmbExamineTypeId.uclValueIndex = "0"
        '
        'lblExamineTypeId
        '
        Me.lblExamineTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblExamineTypeId.AutoSize = True
        Me.tlpHeader.SetColumnSpan(Me.lblExamineTypeId, 2)
        Me.lblExamineTypeId.ForeColor = System.Drawing.Color.Red
        Me.lblExamineTypeId.Location = New System.Drawing.Point(265, 50)
        Me.lblExamineTypeId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExamineTypeId.Name = "lblExamineTypeId"
        Me.lblExamineTypeId.Size = New System.Drawing.Size(96, 16)
        Me.lblExamineTypeId.TabIndex = 3
        Me.lblExamineTypeId.Text = "*診察費類別"
        '
        'lblSectionId
        '
        Me.lblSectionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSectionId.AutoSize = True
        Me.lblSectionId.ForeColor = System.Drawing.Color.Red
        Me.lblSectionId.Location = New System.Drawing.Point(644, 11)
        Me.lblSectionId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSectionId.Name = "lblSectionId"
        Me.lblSectionId.Size = New System.Drawing.Size(48, 16)
        Me.lblSectionId.TabIndex = 6
        Me.lblSectionId.Text = "*診別"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(644, 50)
        Me.lblOrderCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(56, 16)
        Me.lblOrderCode.TabIndex = 1
        Me.lblOrderCode.Text = "批價碼"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptCode.doFlag = True
        Me.txtDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDeptCode.Location = New System.Drawing.Point(428, 6)
        Me.txtDeptCode.Margin = New System.Windows.Forms.Padding(6)
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.Size = New System.Drawing.Size(206, 26)
        Me.txtDeptCode.TabIndex = 2
        Me.txtDeptCode.uclBaseDate = "2015/05/01"
        Me.txtDeptCode.uclCboWidth = 170
        Me.txtDeptCode.uclCodeName = ""
        Me.txtDeptCode.uclCodeName1 = ""
        Me.txtDeptCode.uclCodeName2 = ""
        Me.txtDeptCode.uclCodeValue = ""
        Me.txtDeptCode.uclCodeValue1 = ""
        Me.txtDeptCode.uclCodeValue2 = ""
        Me.txtDeptCode.uclControlFlag = True
        Me.txtDeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtDeptCode.uclDisplayIndex = "0,1"
        Me.txtDeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtDeptCode.uclIsAutoAddZero = False
        Me.txtDeptCode.uclIsBtnVisible = True
        Me.txtDeptCode.uclIsCheckDoctorOnDuty = False
        Me.txtDeptCode.uclIsEnglishDept = False
        Me.txtDeptCode.uclIsReturnDS = False
        Me.txtDeptCode.uclIsShowMsgBox = True
        Me.txtDeptCode.uclIsTextAutoClear = True
        Me.txtDeptCode.uclLabel = ""
        Me.txtDeptCode.uclMsgValue = Nothing
        Me.txtDeptCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtDeptCode.uclQueryField = Nothing
        Me.txtDeptCode.uclQueryValue = Nothing
        Me.txtDeptCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtDeptCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.txtDeptCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txtDeptCode.uclTotalWidth = 8
        Me.txtDeptCode.uclXPosition = 225
        Me.txtDeptCode.uclYPosition = 120
        '
        'cmbSectionId
        '
        Me.cmbSectionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSectionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSectionId.DropDownWidth = 20
        Me.cmbSectionId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSectionId.Location = New System.Drawing.Point(710, 7)
        Me.cmbSectionId.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbSectionId.Name = "cmbSectionId"
        Me.cmbSectionId.SelectedIndex = -1
        Me.cmbSectionId.SelectedItem = Nothing
        Me.cmbSectionId.SelectedText = ""
        Me.cmbSectionId.SelectedValue = ""
        Me.cmbSectionId.SelectionStart = 0
        Me.cmbSectionId.Size = New System.Drawing.Size(176, 24)
        Me.cmbSectionId.TabIndex = 3
        Me.cmbSectionId.uclDisplayIndex = "0,1"
        Me.cmbSectionId.uclIsAutoClear = True
        Me.cmbSectionId.uclIsFirstItemEmpty = True
        Me.cmbSectionId.uclIsTextMode = False
        Me.cmbSectionId.uclShowMsg = False
        Me.cmbSectionId.uclValueIndex = "0"
        '
        'ckbDC
        '
        Me.ckbDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDC.AutoSize = True
        Me.ckbDC.Location = New System.Drawing.Point(898, 48)
        Me.ckbDC.Margin = New System.Windows.Forms.Padding(6)
        Me.ckbDC.Name = "ckbDC"
        Me.ckbDC.Size = New System.Drawing.Size(59, 20)
        Me.ckbDC.TabIndex = 7
        Me.ckbDC.Text = "停用"
        Me.ckbDC.UseVisualStyleBackColor = True
        '
        'cmbMedicalTypeId
        '
        Me.cmbMedicalTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbMedicalTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMedicalTypeId.DropDownWidth = 20
        Me.cmbMedicalTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMedicalTypeId.Location = New System.Drawing.Point(94, 46)
        Me.cmbMedicalTypeId.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbMedicalTypeId.Name = "cmbMedicalTypeId"
        Me.cmbMedicalTypeId.SelectedIndex = -1
        Me.cmbMedicalTypeId.SelectedItem = Nothing
        Me.cmbMedicalTypeId.SelectedText = ""
        Me.cmbMedicalTypeId.SelectedValue = ""
        Me.cmbMedicalTypeId.SelectionStart = 0
        Me.cmbMedicalTypeId.Size = New System.Drawing.Size(161, 24)
        Me.cmbMedicalTypeId.TabIndex = 4
        Me.cmbMedicalTypeId.uclDisplayIndex = "0,1"
        Me.cmbMedicalTypeId.uclIsAutoClear = True
        Me.cmbMedicalTypeId.uclIsFirstItemEmpty = True
        Me.cmbMedicalTypeId.uclIsTextMode = False
        Me.cmbMedicalTypeId.uclShowMsg = False
        Me.cmbMedicalTypeId.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(4, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "*看診目的"
        '
        'PUBExamineUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.palMantain)
        Me.Name = "PUBExamineUI"
        Me.Text = "診察費基本檔維護"
        Me.Controls.SetChildIndex(Me.palMantain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.palMantain.ResumeLayout(False)
        Me.tlpHeader.ResumeLayout(False)
        Me.tlpHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents palMantain As System.Windows.Forms.Panel
    Friend WithEvents lblMainIdentityId As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents lblExamineTypeId As System.Windows.Forms.Label
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbExamineTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents txtDeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents ckbDC As System.Windows.Forms.CheckBox
    Friend WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbSectionId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblSectionId As System.Windows.Forms.Label
    Friend WithEvents chkFirstReg As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMedicalTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
