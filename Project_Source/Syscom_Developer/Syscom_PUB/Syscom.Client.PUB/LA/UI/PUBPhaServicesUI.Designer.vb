<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBPhaServicesUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBPhaServicesUI))
        Me.palMantain = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMainIdentityId = New System.Windows.Forms.Label()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.lblPhaServicesTypeId = New System.Windows.Forms.Label()
        Me.cmbMainIdentityId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbPhaServicesTypeId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtDeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.chkDc = New System.Windows.Forms.CheckBox()
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
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblMainIdentityId, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDeptCode, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOrderCode, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPhaServicesTypeId, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbMainIdentityId, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbPhaServicesTypeId, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDeptCode, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOrderCode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkDc, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 80)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblMainIdentityId
        '
        Me.lblMainIdentityId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMainIdentityId.AutoSize = True
        Me.lblMainIdentityId.ForeColor = System.Drawing.Color.Red
        Me.lblMainIdentityId.Location = New System.Drawing.Point(31, 12)
        Me.lblMainIdentityId.Name = "lblMainIdentityId"
        Me.lblMainIdentityId.Size = New System.Drawing.Size(64, 16)
        Me.lblMainIdentityId.TabIndex = 0
        Me.lblMainIdentityId.Text = "*主身份"
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(267, 12)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(112, 16)
        Me.lblDeptCode.TabIndex = 1
        Me.lblDeptCode.Text = "*院內科別代碼"
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(39, 52)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(56, 16)
        Me.lblOrderCode.TabIndex = 2
        Me.lblOrderCode.Text = "批價碼"
        '
        'lblPhaServicesTypeId
        '
        Me.lblPhaServicesTypeId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPhaServicesTypeId.AutoSize = True
        Me.lblPhaServicesTypeId.ForeColor = System.Drawing.Color.Red
        Me.lblPhaServicesTypeId.Location = New System.Drawing.Point(593, 12)
        Me.lblPhaServicesTypeId.Name = "lblPhaServicesTypeId"
        Me.lblPhaServicesTypeId.Size = New System.Drawing.Size(128, 16)
        Me.lblPhaServicesTypeId.TabIndex = 3
        Me.lblPhaServicesTypeId.Text = "*藥事服務費類別"
        '
        'cmbMainIdentityId
        '
        Me.cmbMainIdentityId.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMainIdentityId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbMainIdentityId.DropDownWidth = 20
        Me.cmbMainIdentityId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMainIdentityId.Location = New System.Drawing.Point(102, 8)
        Me.cmbMainIdentityId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMainIdentityId.Name = "cmbMainIdentityId"
        Me.cmbMainIdentityId.SelectedIndex = -1
        Me.cmbMainIdentityId.SelectedItem = Nothing
        Me.cmbMainIdentityId.SelectedText = ""
        Me.cmbMainIdentityId.SelectedValue = ""
        Me.cmbMainIdentityId.SelectionStart = 0
        Me.cmbMainIdentityId.Size = New System.Drawing.Size(139, 24)
        Me.cmbMainIdentityId.TabIndex = 10001
        Me.cmbMainIdentityId.uclDisplayIndex = "0,1"
        Me.cmbMainIdentityId.uclIsAutoClear = True
        Me.cmbMainIdentityId.uclIsFirstItemEmpty = True
        Me.cmbMainIdentityId.uclIsTextMode = False
        Me.cmbMainIdentityId.uclShowMsg = False
        Me.cmbMainIdentityId.uclValueIndex = "0"
        '
        'cmbPhaServicesTypeId
        '
        Me.cmbPhaServicesTypeId.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPhaServicesTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbPhaServicesTypeId.DropDownWidth = 20
        Me.cmbPhaServicesTypeId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbPhaServicesTypeId.Location = New System.Drawing.Point(728, 8)
        Me.cmbPhaServicesTypeId.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPhaServicesTypeId.Name = "cmbPhaServicesTypeId"
        Me.cmbPhaServicesTypeId.SelectedIndex = -1
        Me.cmbPhaServicesTypeId.SelectedItem = Nothing
        Me.cmbPhaServicesTypeId.SelectedText = ""
        Me.cmbPhaServicesTypeId.SelectedValue = ""
        Me.cmbPhaServicesTypeId.SelectionStart = 0
        Me.cmbPhaServicesTypeId.Size = New System.Drawing.Size(139, 24)
        Me.cmbPhaServicesTypeId.TabIndex = 10003
        Me.cmbPhaServicesTypeId.uclDisplayIndex = "0,1"
        Me.cmbPhaServicesTypeId.uclIsAutoClear = True
        Me.cmbPhaServicesTypeId.uclIsFirstItemEmpty = True
        Me.cmbPhaServicesTypeId.uclIsTextMode = False
        Me.cmbPhaServicesTypeId.uclShowMsg = False
        Me.cmbPhaServicesTypeId.uclValueIndex = "0"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDeptCode, 2)
        Me.txtDeptCode.doFlag = False
        Me.txtDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDeptCode.Location = New System.Drawing.Point(382, 7)
        Me.txtDeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.Size = New System.Drawing.Size(147, 26)
        Me.txtDeptCode.TabIndex = 10002
        Me.txtDeptCode.uclBaseDate = "2015/05/01"
        Me.txtDeptCode.uclCboWidth = 111
        Me.txtDeptCode.uclCodeName = ""
        Me.txtDeptCode.uclCodeValue1 = ""
        Me.txtDeptCode.uclCodeValue2 = ""
        Me.txtDeptCode.uclControlFlag = True
        Me.txtDeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtDeptCode.uclDisplayIndex = "0,1"
        Me.txtDeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtDeptCode.uclIsAutoAddZero = False
        Me.txtDeptCode.uclIsCheckDoctorOnDuty = False
        Me.txtDeptCode.uclIsReturnDS = False
        Me.txtDeptCode.uclIsShowMsgBox = True
        Me.txtDeptCode.uclIsTextAutoClear = True
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
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtOrderCode, 2)
        Me.txtOrderCode.doFlag = False
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(98, 47)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(147, 26)
        Me.txtOrderCode.TabIndex = 10004
        Me.txtOrderCode.uclBaseDate = "2015/05/01"
        Me.txtOrderCode.uclCboWidth = 111
        Me.txtOrderCode.uclCodeName = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.uclCodeValue2 = ""
        Me.txtOrderCode.uclControlFlag = True
        Me.txtOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtOrderCode.uclDisplayIndex = "0,1"
        Me.txtOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtOrderCode.uclIsAutoAddZero = False
        Me.txtOrderCode.uclIsCheckDoctorOnDuty = False
        Me.txtOrderCode.uclIsReturnDS = False
        Me.txtOrderCode.uclIsShowMsgBox = True
        Me.txtOrderCode.uclIsTextAutoClear = True
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
        'chkDc
        '
        Me.chkDc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDc.AutoSize = True
        Me.chkDc.Location = New System.Drawing.Point(385, 50)
        Me.chkDc.Name = "chkDc"
        Me.chkDc.Size = New System.Drawing.Size(59, 20)
        Me.chkDc.TabIndex = 10005
        Me.chkDc.Text = "停用"
        Me.chkDc.UseVisualStyleBackColor = True
        '
        'PUBPhaServicesUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 480)
        Me.Controls.Add(Me.palMantain)
        Me.Name = "PUBPhaServicesUI"
        Me.Text = "藥事服務費基本檔維護"
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
    Friend WithEvents lblMainIdentityId As System.Windows.Forms.Label
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lblPhaServicesTypeId As System.Windows.Forms.Label
    Friend WithEvents cmbMainIdentityId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbPhaServicesTypeId As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents txtDeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents chkDc As System.Windows.Forms.CheckBox
End Class
