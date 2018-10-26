<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBMajorcareUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBMajorcareUI))
        Me.pal_Manitain = New System.Windows.Forms.Panel()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMajorcareCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cmbMajorcareTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMajorcareName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_CaseType = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_OrderCodeList = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tcq_ExamineOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.chk_IsUsed = New System.Windows.Forms.CheckBox()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.pal_Manitain.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 135)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(985, 345)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(983, 308)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(983, 308)
        '
        'pal_Manitain
        '
        Me.pal_Manitain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pal_Manitain.Controls.Add(Me.tlp_Main)
        Me.pal_Manitain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pal_Manitain.Location = New System.Drawing.Point(0, 0)
        Me.pal_Manitain.Name = "pal_Manitain"
        Me.pal_Manitain.Size = New System.Drawing.Size(985, 135)
        Me.pal_Manitain.TabIndex = 0
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 5
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 0, 1)
        Me.tlp_Main.Controls.Add(Me.txtMajorcareCode, 1, 1)
        Me.tlp_Main.Controls.Add(Me.cmbMajorcareTypeId, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label3, 2, 1)
        Me.tlp_Main.Controls.Add(Me.txtMajorcareName, 3, 1)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 2)
        Me.tlp_Main.Controls.Add(Me.cmb_CaseType, 1, 2)
        Me.tlp_Main.Controls.Add(Me.Label5, 3, 2)
        Me.tlp_Main.Controls.Add(Me.Label6, 0, 3)
        Me.tlp_Main.Controls.Add(Me.txt_OrderCodeList, 1, 3)
        Me.tlp_Main.Controls.Add(Me.FlowLayoutPanel1, 4, 2)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 4
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(983, 135)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "特定治療項目類別"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(11, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "*特定治療項目代碼"
        '
        'txtMajorcareCode
        '
        Me.txtMajorcareCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMajorcareCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtMajorcareCode.Location = New System.Drawing.Point(162, 36)
        Me.txtMajorcareCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMajorcareCode.MaxLength = 2
        Me.txtMajorcareCode.Name = "txtMajorcareCode"
        Me.txtMajorcareCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMajorcareCode.SelectionStart = 0
        Me.txtMajorcareCode.Size = New System.Drawing.Size(60, 27)
        Me.txtMajorcareCode.TabIndex = 2
        Me.txtMajorcareCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMajorcareCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtMajorcareCode.ToolTipTag = Nothing
        Me.txtMajorcareCode.uclDollarSign = False
        Me.txtMajorcareCode.uclDotCount = 0
        Me.txtMajorcareCode.uclIntCount = 2
        Me.txtMajorcareCode.uclMinus = False
        Me.txtMajorcareCode.uclReadOnly = False
        Me.txtMajorcareCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtMajorcareCode.uclTrimZero = True
        '
        'cmbMajorcareTypeId
        '
        Me.cmbMajorcareTypeId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.cmbMajorcareTypeId, 3)
        Me.cmbMajorcareTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMajorcareTypeId.DropDownWidth = 20
        Me.cmbMajorcareTypeId.DroppedDown = False
        Me.cmbMajorcareTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMajorcareTypeId.Location = New System.Drawing.Point(162, 4)
        Me.cmbMajorcareTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMajorcareTypeId.Name = "cmbMajorcareTypeId"
        Me.cmbMajorcareTypeId.SelectedIndex = -1
        Me.cmbMajorcareTypeId.SelectedItem = Nothing
        Me.cmbMajorcareTypeId.SelectedText = ""
        Me.cmbMajorcareTypeId.SelectedValue = ""
        Me.cmbMajorcareTypeId.SelectionStart = 0
        Me.cmbMajorcareTypeId.Size = New System.Drawing.Size(226, 24)
        Me.cmbMajorcareTypeId.TabIndex = 1
        Me.cmbMajorcareTypeId.uclDisplayIndex = "0,1"
        Me.cmbMajorcareTypeId.uclIsAutoClear = True
        Me.cmbMajorcareTypeId.uclIsFirstItemEmpty = True
        Me.cmbMajorcareTypeId.uclIsTextMode = False
        Me.cmbMajorcareTypeId.uclShowMsg = False
        Me.cmbMajorcareTypeId.uclValueIndex = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "名稱"
        '
        'txtMajorcareName
        '
        Me.txtMajorcareName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txtMajorcareName, 2)
        Me.txtMajorcareName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtMajorcareName.Location = New System.Drawing.Point(314, 36)
        Me.txtMajorcareName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMajorcareName.MaxLength = 10
        Me.txtMajorcareName.Name = "txtMajorcareName"
        Me.txtMajorcareName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMajorcareName.SelectionStart = 0
        Me.txtMajorcareName.Size = New System.Drawing.Size(424, 27)
        Me.txtMajorcareName.TabIndex = 3
        Me.txtMajorcareName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMajorcareName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtMajorcareName.ToolTipTag = Nothing
        Me.txtMajorcareName.uclDollarSign = False
        Me.txtMajorcareName.uclDotCount = 0
        Me.txtMajorcareName.uclIntCount = 2
        Me.txtMajorcareName.uclMinus = False
        Me.txtMajorcareName.uclReadOnly = False
        Me.txtMajorcareName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtMajorcareName.uclTrimZero = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "預設案件分類"
        '
        'cmb_CaseType
        '
        Me.cmb_CaseType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.cmb_CaseType, 2)
        Me.cmb_CaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmb_CaseType.DropDownWidth = 20
        Me.cmb_CaseType.DroppedDown = False
        Me.cmb_CaseType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmb_CaseType.Location = New System.Drawing.Point(162, 71)
        Me.cmb_CaseType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmb_CaseType.Name = "cmb_CaseType"
        Me.cmb_CaseType.SelectedIndex = -1
        Me.cmb_CaseType.SelectedItem = Nothing
        Me.cmb_CaseType.SelectedText = ""
        Me.cmb_CaseType.SelectedValue = ""
        Me.cmb_CaseType.SelectionStart = 0
        Me.cmb_CaseType.Size = New System.Drawing.Size(144, 24)
        Me.cmb_CaseType.TabIndex = 1
        Me.cmb_CaseType.uclDisplayIndex = "0,1"
        Me.cmb_CaseType.uclIsAutoClear = True
        Me.cmb_CaseType.uclIsFirstItemEmpty = True
        Me.cmb_CaseType.uclIsTextMode = False
        Me.cmb_CaseType.uclShowMsg = False
        Me.cmb_CaseType.uclValueIndex = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(313, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "診察費醫令碼"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "特定治療連帶醫令碼"
        '
        'txt_OrderCodeList
        '
        Me.txt_OrderCodeList.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tlp_Main.SetColumnSpan(Me.txt_OrderCodeList, 4)
        Me.txt_OrderCodeList.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txt_OrderCodeList.Location = New System.Drawing.Point(162, 103)
        Me.txt_OrderCodeList.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_OrderCodeList.MaxLength = 10
        Me.txt_OrderCodeList.Name = "txt_OrderCodeList"
        Me.txt_OrderCodeList.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txt_OrderCodeList.SelectionStart = 0
        Me.txt_OrderCodeList.Size = New System.Drawing.Size(576, 27)
        Me.txt_OrderCodeList.TabIndex = 3
        Me.txt_OrderCodeList.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txt_OrderCodeList.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txt_OrderCodeList.ToolTipTag = Nothing
        Me.txt_OrderCodeList.uclDollarSign = False
        Me.txt_OrderCodeList.uclDotCount = 0
        Me.txt_OrderCodeList.uclIntCount = 2
        Me.txt_OrderCodeList.uclMinus = False
        Me.txt_OrderCodeList.uclReadOnly = False
        Me.txt_OrderCodeList.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txt_OrderCodeList.uclTrimZero = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.tcq_ExamineOrderCode)
        Me.FlowLayoutPanel1.Controls.Add(Me.chk_IsUsed)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(423, 70)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(315, 26)
        Me.FlowLayoutPanel1.TabIndex = 4
        '
        'tcq_ExamineOrderCode
        '
        Me.tcq_ExamineOrderCode.doFlag = True
        Me.tcq_ExamineOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_ExamineOrderCode.Location = New System.Drawing.Point(0, 0)
        Me.tcq_ExamineOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_ExamineOrderCode.Name = "tcq_ExamineOrderCode"
        Me.tcq_ExamineOrderCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_ExamineOrderCode.TabIndex = 0
        Me.tcq_ExamineOrderCode.uclBaseDate = ""
        Me.tcq_ExamineOrderCode.uclCboWidth = 125
        Me.tcq_ExamineOrderCode.uclCodeName = ""
        Me.tcq_ExamineOrderCode.uclCodeName1 = ""
        Me.tcq_ExamineOrderCode.uclCodeName2 = ""
        Me.tcq_ExamineOrderCode.uclCodeValue = ""
        Me.tcq_ExamineOrderCode.uclCodeValue1 = ""
        Me.tcq_ExamineOrderCode.uclCodeValue2 = ""
        Me.tcq_ExamineOrderCode.uclConditionDate = ""
        Me.tcq_ExamineOrderCode.uclControlFlag = True
        Me.tcq_ExamineOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_ExamineOrderCode.uclDisplayIndex = "0,1"
        Me.tcq_ExamineOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_ExamineOrderCode.uclIsAutoAddZero = False
        Me.tcq_ExamineOrderCode.uclIsBtnVisible = True
        Me.tcq_ExamineOrderCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_ExamineOrderCode.uclIsCheckDrLicense = True
        Me.tcq_ExamineOrderCode.uclIsCheckTime = True
        Me.tcq_ExamineOrderCode.uclIsEnglishDept = False
        Me.tcq_ExamineOrderCode.uclIsReturnDS = False
        Me.tcq_ExamineOrderCode.uclIsShowMsgBox = True
        Me.tcq_ExamineOrderCode.uclIsTextAutoClear = True
        Me.tcq_ExamineOrderCode.uclLabel = ""
        Me.tcq_ExamineOrderCode.uclMsgValue = Nothing
        Me.tcq_ExamineOrderCode.uclNoDataOpenWindow = False
        Me.tcq_ExamineOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_ExamineOrderCode.uclQueryField = Nothing
        Me.tcq_ExamineOrderCode.uclQueryValue = Nothing
        Me.tcq_ExamineOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_ExamineOrderCode.uclRegionKind = ""
        Me.tcq_ExamineOrderCode.uclRoles = ""
        Me.tcq_ExamineOrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order_Examination
        Me.tcq_ExamineOrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.tcq_ExamineOrderCode.uclTotalWidth = 8
        Me.tcq_ExamineOrderCode.uclXPosition = 225
        Me.tcq_ExamineOrderCode.uclYPosition = 120
        '
        'chk_IsUsed
        '
        Me.chk_IsUsed.AutoSize = True
        Me.chk_IsUsed.Location = New System.Drawing.Point(172, 3)
        Me.chk_IsUsed.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.chk_IsUsed.Name = "chk_IsUsed"
        Me.chk_IsUsed.Size = New System.Drawing.Size(123, 20)
        Me.chk_IsUsed.TabIndex = 1
        Me.chk_IsUsed.Text = "是否前台使用"
        Me.chk_IsUsed.UseVisualStyleBackColor = True
        '
        'PUBMajorcareUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.pal_Manitain)
        Me.Name = "PUBMajorcareUI"
        Me.Text = "特定治療項目基本檔"
        Me.Controls.SetChildIndex(Me.pal_Manitain, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.pal_Manitain.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend pal_Manitain As System.Windows.Forms.Panel
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMajorcareCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cmbMajorcareTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMajorcareName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_CaseType As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_OrderCodeList As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tcq_ExamineOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents chk_IsUsed As System.Windows.Forms.CheckBox
End Class
