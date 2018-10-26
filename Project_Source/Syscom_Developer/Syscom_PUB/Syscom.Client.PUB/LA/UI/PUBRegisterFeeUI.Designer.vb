<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBRegisterFeeUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBRegisterFeeUI))
        Me.palMantain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSubIdentityCode = New System.Windows.Forms.Label()
        Me.cmbSubIdentityCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblMedicalTypeId = New System.Windows.Forms.Label()
        Me.cmbMedicalTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbSectionId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.ckbFirstReg = New System.Windows.Forms.CheckBox()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.chkDc = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_SourceId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.palMantain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 80)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 400)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(983, 363)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(983, 363)
        '
        'palMantain
        '
        Me.palMantain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palMantain.Controls.Add(Me.TableLayoutPanel1)
        Me.palMantain.Dock = System.Windows.Forms.DockStyle.Top
        Me.palMantain.Location = New System.Drawing.Point(0, 0)
        Me.palMantain.Margin = New System.Windows.Forms.Padding(4)
        Me.palMantain.Name = "palMantain"
        Me.palMantain.Size = New System.Drawing.Size(985, 80)
        Me.palMantain.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubIdentityCode, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSubIdentityCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMedicalTypeId, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbMedicalTypeId, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSectionId, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDeptCode, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDeptCode, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ckbFirstReg, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOrderCode, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOrderCode, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkDc, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_SourceId, 6, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 80)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblSubIdentityCode
        '
        Me.lblSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSubIdentityCode.AutoSize = True
        Me.lblSubIdentityCode.ForeColor = System.Drawing.Color.Red
        Me.lblSubIdentityCode.Location = New System.Drawing.Point(3, 12)
        Me.lblSubIdentityCode.Name = "lblSubIdentityCode"
        Me.lblSubIdentityCode.Size = New System.Drawing.Size(96, 16)
        Me.lblSubIdentityCode.TabIndex = 0
        Me.lblSubIdentityCode.Text = "*身份二代碼"
        '
        'cmbSubIdentityCode
        '
        Me.cmbSubIdentityCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSubIdentityCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSubIdentityCode.DropDownWidth = 20
        Me.cmbSubIdentityCode.DroppedDown = False
        Me.cmbSubIdentityCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubIdentityCode.Location = New System.Drawing.Point(106, 8)
        Me.cmbSubIdentityCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSubIdentityCode.Name = "cmbSubIdentityCode"
        Me.cmbSubIdentityCode.SelectedIndex = -1
        Me.cmbSubIdentityCode.SelectedItem = Nothing
        Me.cmbSubIdentityCode.SelectedText = ""
        Me.cmbSubIdentityCode.SelectedValue = ""
        Me.cmbSubIdentityCode.SelectionStart = 0
        Me.cmbSubIdentityCode.Size = New System.Drawing.Size(199, 24)
        Me.cmbSubIdentityCode.TabIndex = 0
        Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
        Me.cmbSubIdentityCode.uclIsAutoClear = True
        Me.cmbSubIdentityCode.uclIsFirstItemEmpty = True
        Me.cmbSubIdentityCode.uclIsTextMode = False
        Me.cmbSubIdentityCode.uclShowMsg = False
        Me.cmbSubIdentityCode.uclValueIndex = "0"
        '
        'lblMedicalTypeId
        '
        Me.lblMedicalTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMedicalTypeId.AutoSize = True
        Me.lblMedicalTypeId.ForeColor = System.Drawing.Color.Red
        Me.lblMedicalTypeId.Location = New System.Drawing.Point(19, 52)
        Me.lblMedicalTypeId.Name = "lblMedicalTypeId"
        Me.lblMedicalTypeId.Size = New System.Drawing.Size(80, 16)
        Me.lblMedicalTypeId.TabIndex = 3
        Me.lblMedicalTypeId.Text = "*看診目的"
        '
        'cmbMedicalTypeId
        '
        Me.cmbMedicalTypeId.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMedicalTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMedicalTypeId.DropDownWidth = 20
        Me.cmbMedicalTypeId.DroppedDown = False
        Me.cmbMedicalTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMedicalTypeId.Location = New System.Drawing.Point(106, 48)
        Me.cmbMedicalTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMedicalTypeId.Name = "cmbMedicalTypeId"
        Me.cmbMedicalTypeId.SelectedIndex = -1
        Me.cmbMedicalTypeId.SelectedItem = Nothing
        Me.cmbMedicalTypeId.SelectedText = ""
        Me.cmbMedicalTypeId.SelectedValue = ""
        Me.cmbMedicalTypeId.SelectionStart = 0
        Me.cmbMedicalTypeId.Size = New System.Drawing.Size(199, 24)
        Me.cmbMedicalTypeId.TabIndex = 3
        Me.cmbMedicalTypeId.uclDisplayIndex = "0,1"
        Me.cmbMedicalTypeId.uclIsAutoClear = True
        Me.cmbMedicalTypeId.uclIsFirstItemEmpty = True
        Me.cmbMedicalTypeId.uclIsTextMode = False
        Me.cmbMedicalTypeId.uclShowMsg = False
        Me.cmbMedicalTypeId.uclValueIndex = "0"
        '
        'cmbSectionId
        '
        Me.cmbSectionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSectionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSectionId.DropDownWidth = 20
        Me.cmbSectionId.DroppedDown = False
        Me.cmbSectionId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSectionId.Location = New System.Drawing.Point(807, 8)
        Me.cmbSectionId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSectionId.Name = "cmbSectionId"
        Me.cmbSectionId.SelectedIndex = -1
        Me.cmbSectionId.SelectedItem = Nothing
        Me.cmbSectionId.SelectedText = ""
        Me.cmbSectionId.SelectedValue = ""
        Me.cmbSectionId.SelectionStart = 0
        Me.cmbSectionId.Size = New System.Drawing.Size(172, 24)
        Me.cmbSectionId.TabIndex = 2
        Me.cmbSectionId.uclDisplayIndex = "0,1"
        Me.cmbSectionId.uclIsAutoClear = True
        Me.cmbSectionId.uclIsFirstItemEmpty = True
        Me.cmbSectionId.uclIsTextMode = False
        Me.cmbSectionId.uclShowMsg = False
        Me.cmbSectionId.uclValueIndex = "0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(712, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "*診別"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptCode.doFlag = False
        Me.txtDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDeptCode.Location = New System.Drawing.Point(502, 7)
        Me.txtDeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.Size = New System.Drawing.Size(207, 26)
        Me.txtDeptCode.TabIndex = 1
        Me.txtDeptCode.uclBaseDate = "2015/05/01"
        Me.txtDeptCode.uclCboWidth = 171
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
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(387, 12)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(112, 16)
        Me.lblDeptCode.TabIndex = 1
        Me.lblDeptCode.Text = "*院內科別代碼"
        '
        'ckbFirstReg
        '
        Me.ckbFirstReg.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbFirstReg.AutoSize = True
        Me.ckbFirstReg.ForeColor = System.Drawing.Color.Red
        Me.ckbFirstReg.Location = New System.Drawing.Point(312, 10)
        Me.ckbFirstReg.Name = "ckbFirstReg"
        Me.ckbFirstReg.Size = New System.Drawing.Size(67, 20)
        Me.ckbFirstReg.TabIndex = 6
        Me.ckbFirstReg.Text = "*初診"
        Me.ckbFirstReg.UseVisualStyleBackColor = True
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(502, 47)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(207, 26)
        Me.txtOrderCode.TabIndex = 4
        Me.txtOrderCode.uclBaseDate = "2015/05/01"
        Me.txtOrderCode.uclCboWidth = 171
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
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(395, 52)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(104, 16)
        Me.lblOrderCode.TabIndex = 2
        Me.lblOrderCode.Text = "醫令項目代碼"
        '
        'chkDc
        '
        Me.chkDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDc.AutoSize = True
        Me.chkDc.Location = New System.Drawing.Point(312, 50)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 20)
        Me.chkDc.TabIndex = 5
        Me.chkDc.Text = "停用"
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(712, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "* 門診/急診"
        '
        'cbo_SourceId
        '
        Me.cbo_SourceId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_SourceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cbo_SourceId.DropDownWidth = 20
        Me.cbo_SourceId.DroppedDown = False
        Me.cbo_SourceId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_SourceId.Location = New System.Drawing.Point(807, 48)
        Me.cbo_SourceId.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.cbo_SourceId.Name = "cbo_SourceId"
        Me.cbo_SourceId.SelectedIndex = -1
        Me.cbo_SourceId.SelectedItem = Nothing
        Me.cbo_SourceId.SelectedText = ""
        Me.cbo_SourceId.SelectedValue = ""
        Me.cbo_SourceId.SelectionStart = 0
        Me.cbo_SourceId.Size = New System.Drawing.Size(172, 24)
        Me.cbo_SourceId.TabIndex = 8
        Me.cbo_SourceId.uclDisplayIndex = "0,1"
        Me.cbo_SourceId.uclIsAutoClear = True
        Me.cbo_SourceId.uclIsFirstItemEmpty = True
        Me.cbo_SourceId.uclIsTextMode = False
        Me.cbo_SourceId.uclShowMsg = False
        Me.cbo_SourceId.uclValueIndex = "0"
        '
        'PUBRegisterFeeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.palMantain)
        Me.Name = "PUBRegisterFeeUI"
        Me.TabText = "掛號費基本檔維護"
        Me.Text = "掛號費基本檔維護"
        Me.Controls.SetChildIndex(Me.palMantain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.palMantain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents palMantain As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSubIdentityCode As System.Windows.Forms.Label
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lblMedicalTypeId As System.Windows.Forms.Label
    Friend WithEvents cmbMedicalTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtDeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSubIdentityCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSectionId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents ckbFirstReg As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_SourceId As Syscom.Client.UCL.UCLComboBoxUC
End Class
