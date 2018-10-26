<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubDrAddControlUI
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDc = New System.Windows.Forms.CheckBox()
        Me.txt_DeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txt_OrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txt_EmployeeCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 40)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 601)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 564)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 564)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlp_Main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 40)
        Me.Panel1.TabIndex = 0
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 7
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.19463!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.80537!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Main.Controls.Add(Me.lblDeptCode, 0, 0)
        Me.tlp_Main.Controls.Add(Me.lblOrderCode, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 4, 0)
        Me.tlp_Main.Controls.Add(Me.chkDc, 6, 0)
        Me.tlp_Main.Controls.Add(Me.txt_DeptCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_OrderCode, 3, 0)
        Me.tlp_Main.Controls.Add(Me.txt_EmployeeCode, 5, 0)
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 1
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(964, 40)
        Me.tlp_Main.TabIndex = 0
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(3, 12)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(80, 16)
        Me.lblDeptCode.TabIndex = 0
        Me.lblDeptCode.Text = "*科別代碼"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(304, 12)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(64, 16)
        Me.lblOrderCode.TabIndex = 2
        Me.lblOrderCode.Text = "*醫令碼"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(590, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "*醫師代號"
        '
        'chkDc
        '
        Me.chkDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDc.AutoSize = True
        Me.chkDc.Location = New System.Drawing.Point(880, 10)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 20)
        Me.chkDc.TabIndex = 4
        Me.chkDc.Text = "停用"
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'txt_DeptCode
        '
        Me.txt_DeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_DeptCode.doFlag = True
        Me.txt_DeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_DeptCode.Location = New System.Drawing.Point(95, 7)
        Me.txt_DeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_DeptCode.Name = "txt_DeptCode"
        Me.txt_DeptCode.Size = New System.Drawing.Size(201, 26)
        Me.txt_DeptCode.TabIndex = 1
        Me.txt_DeptCode.uclBaseDate = ""
        Me.txt_DeptCode.uclCboWidth = 167
        Me.txt_DeptCode.uclCodeName = ""
        Me.txt_DeptCode.uclCodeName1 = ""
        Me.txt_DeptCode.uclCodeName2 = ""
        Me.txt_DeptCode.uclCodeValue = ""
        Me.txt_DeptCode.uclCodeValue1 = ""
        Me.txt_DeptCode.uclCodeValue2 = ""
        Me.txt_DeptCode.uclConditionDate = ""
        Me.txt_DeptCode.uclControlFlag = True
        Me.txt_DeptCode.uclDeptCode = ""
        Me.txt_DeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_DeptCode.uclDisplayIndex = "0,1"
        Me.txt_DeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_DeptCode.uclIsAutoAddZero = False
        Me.txt_DeptCode.uclIsBtnVisible = True
        Me.txt_DeptCode.uclIsCheckDoctorOnDuty = False
        Me.txt_DeptCode.uclIsCheckDrLicense = True
        Me.txt_DeptCode.uclIsCheckTime = True
        Me.txt_DeptCode.uclIsEnglishDept = False
        Me.txt_DeptCode.uclIsReturnDS = False
        Me.txt_DeptCode.uclIsShowMsgBox = True
        Me.txt_DeptCode.uclIsTextAutoClear = True
        Me.txt_DeptCode.uclLabel = ""
        Me.txt_DeptCode.uclMsgValue = Nothing
        Me.txt_DeptCode.uclNoDataOpenWindow = False
        Me.txt_DeptCode.uclPUBEmployeeProfessalKindId = ""
        Me.txt_DeptCode.uclQueryField = Nothing
        Me.txt_DeptCode.uclQueryValue = Nothing
        Me.txt_DeptCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_DeptCode.uclRegionKind = ""
        Me.txt_DeptCode.uclRoles = ""
        Me.txt_DeptCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.txt_DeptCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txt_DeptCode.uclTotalWidth = 8
        Me.txt_DeptCode.uclXPosition = 225
        Me.txt_DeptCode.uclYPosition = 120
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_OrderCode.doFlag = True
        Me.txt_OrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_OrderCode.Location = New System.Drawing.Point(381, 7)
        Me.txt_OrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.Size = New System.Drawing.Size(203, 26)
        Me.txt_OrderCode.TabIndex = 2
        Me.txt_OrderCode.uclBaseDate = ""
        Me.txt_OrderCode.uclCboWidth = 167
        Me.txt_OrderCode.uclCodeName = ""
        Me.txt_OrderCode.uclCodeName1 = ""
        Me.txt_OrderCode.uclCodeName2 = ""
        Me.txt_OrderCode.uclCodeValue = ""
        Me.txt_OrderCode.uclCodeValue1 = ""
        Me.txt_OrderCode.uclCodeValue2 = ""
        Me.txt_OrderCode.uclConditionDate = ""
        Me.txt_OrderCode.uclControlFlag = True
        Me.txt_OrderCode.uclDeptCode = ""
        Me.txt_OrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_OrderCode.uclDisplayIndex = "0,1"
        Me.txt_OrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_OrderCode.uclIsAutoAddZero = False
        Me.txt_OrderCode.uclIsBtnVisible = True
        Me.txt_OrderCode.uclIsCheckDoctorOnDuty = False
        Me.txt_OrderCode.uclIsCheckDrLicense = True
        Me.txt_OrderCode.uclIsCheckTime = True
        Me.txt_OrderCode.uclIsEnglishDept = False
        Me.txt_OrderCode.uclIsReturnDS = False
        Me.txt_OrderCode.uclIsShowMsgBox = True
        Me.txt_OrderCode.uclIsTextAutoClear = True
        Me.txt_OrderCode.uclLabel = ""
        Me.txt_OrderCode.uclMsgValue = Nothing
        Me.txt_OrderCode.uclNoDataOpenWindow = False
        Me.txt_OrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.txt_OrderCode.uclQueryField = Nothing
        Me.txt_OrderCode.uclQueryValue = Nothing
        Me.txt_OrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_OrderCode.uclRegionKind = ""
        Me.txt_OrderCode.uclRoles = ""
        Me.txt_OrderCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.txt_OrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txt_OrderCode.uclTotalWidth = 8
        Me.txt_OrderCode.uclXPosition = 225
        Me.txt_OrderCode.uclYPosition = 120
        '
        'txt_EmployeeCode
        '
        Me.txt_EmployeeCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_EmployeeCode.doFlag = True
        Me.txt_EmployeeCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_EmployeeCode.Location = New System.Drawing.Point(681, 7)
        Me.txt_EmployeeCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_EmployeeCode.Name = "txt_EmployeeCode"
        Me.txt_EmployeeCode.Size = New System.Drawing.Size(196, 26)
        Me.txt_EmployeeCode.TabIndex = 3
        Me.txt_EmployeeCode.uclBaseDate = ""
        Me.txt_EmployeeCode.uclCboWidth = 167
        Me.txt_EmployeeCode.uclCodeName = ""
        Me.txt_EmployeeCode.uclCodeName1 = ""
        Me.txt_EmployeeCode.uclCodeName2 = ""
        Me.txt_EmployeeCode.uclCodeValue = ""
        Me.txt_EmployeeCode.uclCodeValue1 = ""
        Me.txt_EmployeeCode.uclCodeValue2 = ""
        Me.txt_EmployeeCode.uclConditionDate = ""
        Me.txt_EmployeeCode.uclControlFlag = True
        Me.txt_EmployeeCode.uclDeptCode = ""
        Me.txt_EmployeeCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_EmployeeCode.uclDisplayIndex = "0,1"
        Me.txt_EmployeeCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_EmployeeCode.uclIsAutoAddZero = False
        Me.txt_EmployeeCode.uclIsBtnVisible = True
        Me.txt_EmployeeCode.uclIsCheckDoctorOnDuty = False
        Me.txt_EmployeeCode.uclIsCheckDrLicense = True
        Me.txt_EmployeeCode.uclIsCheckTime = True
        Me.txt_EmployeeCode.uclIsEnglishDept = False
        Me.txt_EmployeeCode.uclIsReturnDS = False
        Me.txt_EmployeeCode.uclIsShowMsgBox = True
        Me.txt_EmployeeCode.uclIsTextAutoClear = True
        Me.txt_EmployeeCode.uclLabel = ""
        Me.txt_EmployeeCode.uclMsgValue = Nothing
        Me.txt_EmployeeCode.uclNoDataOpenWindow = False
        Me.txt_EmployeeCode.uclPUBEmployeeProfessalKindId = ""
        Me.txt_EmployeeCode.uclQueryField = Nothing
        Me.txt_EmployeeCode.uclQueryValue = Nothing
        Me.txt_EmployeeCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_EmployeeCode.uclRegionKind = ""
        Me.txt_EmployeeCode.uclRoles = ""
        Me.txt_EmployeeCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Doctor
        Me.txt_EmployeeCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txt_EmployeeCode.uclTotalWidth = 8
        Me.txt_EmployeeCode.uclXPosition = 225
        Me.txt_EmployeeCode.uclYPosition = 120
        '
        'PubDrAddControlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PubDrAddControlUI"
        Me.Text = "PubDrAddControlUI"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
    Friend WithEvents txt_DeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents txt_OrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents txt_EmployeeCode As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
