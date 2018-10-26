<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBOrderStandingUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBOrderStandingUI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ckbDC = New System.Windows.Forms.CheckBox()
        Me.txtConsumptionDept = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblConsumptionDept = New System.Windows.Forms.Label()
        Me.cmbWeek = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.lblWeek = New System.Windows.Forms.Label()
        Me.txtServiceEndTime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblService_End_Time = New System.Windows.Forms.Label()
        Me.txtServiceStartTime = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblService_Start_Time = New System.Windows.Forms.Label()
        Me.txtOrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.cboDeptCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 93)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(925, 393)
        Me.IUCLMaintainPanel.TabIndex = 1
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(923, 356)
        Me.pal_1.TabIndex = 99
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(923, 356)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 93)
        Me.Panel1.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ckbDC, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtConsumptionDept, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblConsumptionDept, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbWeek, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWeek, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtServiceEndTime, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblService_End_Time, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtServiceStartTime, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblService_Start_Time, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtOrderCode, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblOrderCode, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDeptCode, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboDeptCode, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.91304!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.08696!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(923, 91)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ckbDC
        '
        Me.ckbDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ckbDC.AutoSize = True
        Me.ckbDC.Location = New System.Drawing.Point(849, 57)
        Me.ckbDC.Margin = New System.Windows.Forms.Padding(6)
        Me.ckbDC.Name = "ckbDC"
        Me.ckbDC.Size = New System.Drawing.Size(59, 20)
        Me.ckbDC.TabIndex = 6
        Me.ckbDC.Text = "停用"
        Me.ckbDC.UseVisualStyleBackColor = True
        '
        'txtConsumptionDept
        '
        Me.txtConsumptionDept.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtConsumptionDept.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtConsumptionDept.Location = New System.Drawing.Point(710, 54)
        Me.txtConsumptionDept.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConsumptionDept.MaxLength = 10
        Me.txtConsumptionDept.Name = "txtConsumptionDept"
        Me.txtConsumptionDept.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsumptionDept.SelectionStart = 0
        Me.txtConsumptionDept.Size = New System.Drawing.Size(129, 27)
        Me.txtConsumptionDept.TabIndex = 5
        Me.txtConsumptionDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtConsumptionDept.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtConsumptionDept.ToolTipTag = Nothing
        Me.txtConsumptionDept.uclDollarSign = False
        Me.txtConsumptionDept.uclDotCount = 0
        Me.txtConsumptionDept.uclIntCount = 2
        Me.txtConsumptionDept.uclMinus = False
        Me.txtConsumptionDept.uclReadOnly = False
        Me.txtConsumptionDept.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtConsumptionDept.uclTrimZero = True
        '
        'lblConsumptionDept
        '
        Me.lblConsumptionDept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblConsumptionDept.AutoSize = True
        Me.lblConsumptionDept.ForeColor = System.Drawing.Color.Red
        Me.lblConsumptionDept.Location = New System.Drawing.Point(622, 59)
        Me.lblConsumptionDept.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConsumptionDept.Name = "lblConsumptionDept"
        Me.lblConsumptionDept.Size = New System.Drawing.Size(80, 16)
        Me.lblConsumptionDept.TabIndex = 10
        Me.lblConsumptionDept.Text = "*消耗單位"
        '
        'cmbWeek
        '
        Me.cmbWeek.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbWeek.DropDownWidth = 20
        Me.cmbWeek.DroppedDown = False
        Me.cmbWeek.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbWeek.Location = New System.Drawing.Point(417, 55)
        Me.cmbWeek.Margin = New System.Windows.Forms.Padding(6)
        Me.cmbWeek.Name = "cmbWeek"
        Me.cmbWeek.SelectedIndex = -1
        Me.cmbWeek.SelectedItem = Nothing
        Me.cmbWeek.SelectedText = ""
        Me.cmbWeek.SelectedValue = ""
        Me.cmbWeek.SelectionStart = 0
        Me.cmbWeek.Size = New System.Drawing.Size(163, 24)
        Me.cmbWeek.TabIndex = 4
        Me.cmbWeek.uclDisplayIndex = "0,1"
        Me.cmbWeek.uclIsAutoClear = True
        Me.cmbWeek.uclIsFirstItemEmpty = True
        Me.cmbWeek.uclIsTextMode = False
        Me.cmbWeek.uclShowMsg = False
        Me.cmbWeek.uclValueIndex = "0"
        '
        'lblWeek
        '
        Me.lblWeek.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblWeek.AutoSize = True
        Me.lblWeek.ForeColor = System.Drawing.Color.Red
        Me.lblWeek.Location = New System.Drawing.Point(359, 59)
        Me.lblWeek.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWeek.Name = "lblWeek"
        Me.lblWeek.Size = New System.Drawing.Size(48, 16)
        Me.lblWeek.TabIndex = 8
        Me.lblWeek.Text = "*星期"
        '
        'txtServiceEndTime
        '
        Me.txtServiceEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtServiceEndTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtServiceEndTime.Location = New System.Drawing.Point(124, 54)
        Me.txtServiceEndTime.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServiceEndTime.MaxLength = 10
        Me.txtServiceEndTime.Name = "txtServiceEndTime"
        Me.txtServiceEndTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServiceEndTime.SelectionStart = 0
        Me.txtServiceEndTime.Size = New System.Drawing.Size(146, 27)
        Me.txtServiceEndTime.TabIndex = 3
        Me.txtServiceEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtServiceEndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtServiceEndTime.ToolTipTag = Nothing
        Me.txtServiceEndTime.uclDollarSign = False
        Me.txtServiceEndTime.uclDotCount = 0
        Me.txtServiceEndTime.uclIntCount = 2
        Me.txtServiceEndTime.uclMinus = False
        Me.txtServiceEndTime.uclReadOnly = False
        Me.txtServiceEndTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        Me.txtServiceEndTime.uclTrimZero = True
        '
        'lblService_End_Time
        '
        Me.lblService_End_Time.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblService_End_Time.AutoSize = True
        Me.lblService_End_Time.ForeColor = System.Drawing.Color.Red
        Me.lblService_End_Time.Location = New System.Drawing.Point(4, 59)
        Me.lblService_End_Time.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblService_End_Time.Name = "lblService_End_Time"
        Me.lblService_End_Time.Size = New System.Drawing.Size(112, 16)
        Me.lblService_End_Time.TabIndex = 6
        Me.lblService_End_Time.Text = "*服務結束時間"
        '
        'txtServiceStartTime
        '
        Me.txtServiceStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtServiceStartTime.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtServiceStartTime.Location = New System.Drawing.Point(710, 8)
        Me.txtServiceStartTime.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServiceStartTime.MaxLength = 10
        Me.txtServiceStartTime.Name = "txtServiceStartTime"
        Me.txtServiceStartTime.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServiceStartTime.SelectionStart = 0
        Me.txtServiceStartTime.Size = New System.Drawing.Size(129, 27)
        Me.txtServiceStartTime.TabIndex = 2
        Me.txtServiceStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtServiceStartTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtServiceStartTime.ToolTipTag = Nothing
        Me.txtServiceStartTime.uclDollarSign = False
        Me.txtServiceStartTime.uclDotCount = 0
        Me.txtServiceStartTime.uclIntCount = 2
        Me.txtServiceStartTime.uclMinus = False
        Me.txtServiceStartTime.uclReadOnly = False
        Me.txtServiceStartTime.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Time_Hour24AndMinute
        Me.txtServiceStartTime.uclTrimZero = True
        '
        'lblService_Start_Time
        '
        Me.lblService_Start_Time.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblService_Start_Time.AutoSize = True
        Me.lblService_Start_Time.ForeColor = System.Drawing.Color.Red
        Me.lblService_Start_Time.Location = New System.Drawing.Point(590, 14)
        Me.lblService_Start_Time.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblService_Start_Time.Name = "lblService_Start_Time"
        Me.lblService_Start_Time.Size = New System.Drawing.Size(112, 16)
        Me.lblService_Start_Time.TabIndex = 4
        Me.lblService_Start_Time.Text = "*服務開始時間"
        '
        'txtOrderCode
        '
        Me.txtOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtOrderCode.doFlag = True
        Me.txtOrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOrderCode.Location = New System.Drawing.Point(417, 9)
        Me.txtOrderCode.Margin = New System.Windows.Forms.Padding(6)
        Me.txtOrderCode.Name = "txtOrderCode"
        Me.txtOrderCode.Size = New System.Drawing.Size(162, 26)
        Me.txtOrderCode.TabIndex = 1
        Me.txtOrderCode.uclBaseDate = ""
        Me.txtOrderCode.uclCboWidth = 126
        Me.txtOrderCode.uclCodeName = ""
        Me.txtOrderCode.uclCodeName1 = ""
        Me.txtOrderCode.uclCodeName2 = ""
        Me.txtOrderCode.uclCodeValue = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.uclCodeValue2 = ""
        Me.txtOrderCode.uclConditionDate = ""
        Me.txtOrderCode.uclControlFlag = True
        Me.txtOrderCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txtOrderCode.uclDisplayIndex = "0,1"
        Me.txtOrderCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtOrderCode.uclIsAutoAddZero = False
        Me.txtOrderCode.uclIsBtnVisible = True
        Me.txtOrderCode.uclIsCheckDoctorOnDuty = False
        Me.txtOrderCode.uclIsCheckDrLicense = True
        Me.txtOrderCode.uclIsCheckTime = True
        Me.txtOrderCode.uclIsEnglishDept = False
        Me.txtOrderCode.uclIsReturnDS = False
        Me.txtOrderCode.uclIsShowMsgBox = True
        Me.txtOrderCode.uclIsTextAutoClear = True
        Me.txtOrderCode.uclLabel = ""
        Me.txtOrderCode.uclMsgValue = Nothing
        Me.txtOrderCode.uclNoDataOpenWindow = False
        Me.txtOrderCode.uclPUBEmployeeProfessalKindId = ""
        Me.txtOrderCode.uclQueryField = Nothing
        Me.txtOrderCode.uclQueryValue = Nothing
        Me.txtOrderCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txtOrderCode.uclRegionKind = ""
        Me.txtOrderCode.uclRoles = ""
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
        Me.lblOrderCode.Location = New System.Drawing.Point(295, 14)
        Me.lblOrderCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(112, 16)
        Me.lblOrderCode.TabIndex = 2
        Me.lblOrderCode.Text = "*醫令項目代碼"
        '
        'lblDeptCode
        '
        Me.lblDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.ForeColor = System.Drawing.Color.Red
        Me.lblDeptCode.Location = New System.Drawing.Point(17, 14)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(100, 16)
        Me.lblDeptCode.TabIndex = 0
        Me.lblDeptCode.Text = "*科別/護理站"
        '
        'cboDeptCode
        '
        Me.cboDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDeptCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboDeptCode.DropDownWidth = 20
        Me.cboDeptCode.DroppedDown = False
        Me.cboDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboDeptCode.Location = New System.Drawing.Point(124, 10)
        Me.cboDeptCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDeptCode.Name = "cboDeptCode"
        Me.cboDeptCode.SelectedIndex = -1
        Me.cboDeptCode.SelectedItem = Nothing
        Me.cboDeptCode.SelectedText = ""
        Me.cboDeptCode.SelectedValue = ""
        Me.cboDeptCode.SelectionStart = 0
        Me.cboDeptCode.Size = New System.Drawing.Size(163, 24)
        Me.cboDeptCode.TabIndex = 11
        Me.cboDeptCode.uclDisplayIndex = "0,1"
        Me.cboDeptCode.uclIsAutoClear = True
        Me.cboDeptCode.uclIsFirstItemEmpty = True
        Me.cboDeptCode.uclIsTextMode = False
        Me.cboDeptCode.uclShowMsg = False
        Me.cboDeptCode.uclValueIndex = "0"
        '
        'PUBOrderStandingUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 486)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PUBOrderStandingUI"
        Me.TabText = "常備醫令檔維護"
        Me.Text = "常備醫令檔維護"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbWeek As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents lblWeek As System.Windows.Forms.Label
    Friend WithEvents lblService_Start_Time As System.Windows.Forms.Label
    Friend WithEvents lblService_End_Time As System.Windows.Forms.Label
    Friend WithEvents txtOrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents ckbDC As System.Windows.Forms.CheckBox
    Friend WithEvents lblConsumptionDept As System.Windows.Forms.Label
    Friend WithEvents txtConsumptionDept As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtServiceStartTime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtServiceEndTime As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lblDeptCode As System.Windows.Forms.Label
    Friend WithEvents cboDeptCode As Syscom.Client.UCL.UCLComboBoxUC
End Class
