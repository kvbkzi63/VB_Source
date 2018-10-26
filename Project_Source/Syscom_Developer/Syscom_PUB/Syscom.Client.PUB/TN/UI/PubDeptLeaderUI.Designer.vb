<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubDeptLeaderUI
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tcq_DeptCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.tcq_LeaderEmployeeCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp_Effect_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_End_Date = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 54)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 587)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 550)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 550)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tlp_Main)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 54)
        Me.Panel1.TabIndex = 0
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 8
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main.Controls.Add(Me.tcq_DeptCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.tcq_LeaderEmployeeCode, 3, 0)
        Me.tlp_Main.Controls.Add(Me.Label3, 4, 0)
        Me.tlp_Main.Controls.Add(Me.dtp_Effect_Date, 5, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 6, 0)
        Me.tlp_Main.Controls.Add(Me.dtp_End_Date, 7, 0)
        Me.tlp_Main.Location = New System.Drawing.Point(3, 3)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 1
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(957, 46)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "*科室代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(251, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "*主管員工代碼"
        '
        'tcq_DeptCode
        '
        Me.tcq_DeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_DeptCode.doFlag = True
        Me.tcq_DeptCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_DeptCode.Location = New System.Drawing.Point(86, 10)
        Me.tcq_DeptCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_DeptCode.Name = "tcq_DeptCode"
        Me.tcq_DeptCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_DeptCode.TabIndex = 2
        Me.tcq_DeptCode.uclBaseDate = "2016/07/13"
        Me.tcq_DeptCode.uclCboWidth = 125
        Me.tcq_DeptCode.uclCodeName = ""
        Me.tcq_DeptCode.uclCodeName1 = ""
        Me.tcq_DeptCode.uclCodeName2 = ""
        Me.tcq_DeptCode.uclCodeValue = ""
        Me.tcq_DeptCode.uclCodeValue1 = ""
        Me.tcq_DeptCode.uclCodeValue2 = ""
        Me.tcq_DeptCode.uclControlFlag = True
        Me.tcq_DeptCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.ODept
        Me.tcq_DeptCode.uclDisplayIndex = "0,1"
        Me.tcq_DeptCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_DeptCode.uclIsAutoAddZero = False
        Me.tcq_DeptCode.uclIsBtnVisible = True
        Me.tcq_DeptCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_DeptCode.uclIsEnglishDept = False
        Me.tcq_DeptCode.uclIsReturnDS = False
        Me.tcq_DeptCode.uclIsShowMsgBox = True
        Me.tcq_DeptCode.uclIsTextAutoClear = True
        Me.tcq_DeptCode.uclLabel = ""
        Me.tcq_DeptCode.uclMsgValue = Nothing
        Me.tcq_DeptCode.uclNoDataOpenWindow = False
        Me.tcq_DeptCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_DeptCode.uclQueryField = Nothing
        Me.tcq_DeptCode.uclQueryValue = Nothing
        Me.tcq_DeptCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_DeptCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Department
        Me.tcq_DeptCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcq_DeptCode.uclTotalWidth = 8
        Me.tcq_DeptCode.uclXPosition = 225
        Me.tcq_DeptCode.uclYPosition = 120
        '
        'tcq_LeaderEmployeeCode
        '
        Me.tcq_LeaderEmployeeCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tcq_LeaderEmployeeCode.doFlag = True
        Me.tcq_LeaderEmployeeCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tcq_LeaderEmployeeCode.Location = New System.Drawing.Point(366, 10)
        Me.tcq_LeaderEmployeeCode.Margin = New System.Windows.Forms.Padding(0)
        Me.tcq_LeaderEmployeeCode.Name = "tcq_LeaderEmployeeCode"
        Me.tcq_LeaderEmployeeCode.Size = New System.Drawing.Size(162, 26)
        Me.tcq_LeaderEmployeeCode.TabIndex = 3
        Me.tcq_LeaderEmployeeCode.uclBaseDate = "2016/07/13"
        Me.tcq_LeaderEmployeeCode.uclCboWidth = 125
        Me.tcq_LeaderEmployeeCode.uclCodeName = ""
        Me.tcq_LeaderEmployeeCode.uclCodeName1 = ""
        Me.tcq_LeaderEmployeeCode.uclCodeName2 = ""
        Me.tcq_LeaderEmployeeCode.uclCodeValue = ""
        Me.tcq_LeaderEmployeeCode.uclCodeValue1 = ""
        Me.tcq_LeaderEmployeeCode.uclCodeValue2 = ""
        Me.tcq_LeaderEmployeeCode.uclControlFlag = True
        Me.tcq_LeaderEmployeeCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.tcq_LeaderEmployeeCode.uclDisplayIndex = "0,1"
        Me.tcq_LeaderEmployeeCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tcq_LeaderEmployeeCode.uclIsAutoAddZero = False
        Me.tcq_LeaderEmployeeCode.uclIsBtnVisible = True
        Me.tcq_LeaderEmployeeCode.uclIsCheckDoctorOnDuty = False
        Me.tcq_LeaderEmployeeCode.uclIsEnglishDept = False
        Me.tcq_LeaderEmployeeCode.uclIsReturnDS = False
        Me.tcq_LeaderEmployeeCode.uclIsShowMsgBox = True
        Me.tcq_LeaderEmployeeCode.uclIsTextAutoClear = True
        Me.tcq_LeaderEmployeeCode.uclLabel = ""
        Me.tcq_LeaderEmployeeCode.uclMsgValue = Nothing
        Me.tcq_LeaderEmployeeCode.uclNoDataOpenWindow = False
        Me.tcq_LeaderEmployeeCode.uclPUBEmployeeProfessalKindId = ""
        Me.tcq_LeaderEmployeeCode.uclQueryField = Nothing
        Me.tcq_LeaderEmployeeCode.uclQueryValue = Nothing
        Me.tcq_LeaderEmployeeCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.tcq_LeaderEmployeeCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Employee
        Me.tcq_LeaderEmployeeCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.tcq_LeaderEmployeeCode.uclTotalWidth = 8
        Me.tcq_LeaderEmployeeCode.uclXPosition = 225
        Me.tcq_LeaderEmployeeCode.uclYPosition = 120
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(531, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "*生效日期"
        '
        'dtp_Effect_Date
        '
        Me.dtp_Effect_Date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_Effect_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Effect_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Effect_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_Effect_Date.Location = New System.Drawing.Point(617, 9)
        Me.dtp_Effect_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Effect_Date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Effect_Date.Name = "dtp_Effect_Date"
        Me.dtp_Effect_Date.Size = New System.Drawing.Size(132, 27)
        Me.dtp_Effect_Date.TabIndex = 5
        Me.dtp_Effect_Date.uclReadOnly = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(755, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "結束日期"
        '
        'dtp_End_Date
        '
        Me.dtp_End_Date.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_End_Date.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_End_Date.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_End_Date.Location = New System.Drawing.Point(833, 9)
        Me.dtp_End_Date.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_End_Date.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_End_Date.Name = "dtp_End_Date"
        Me.dtp_End_Date.Size = New System.Drawing.Size(132, 27)
        Me.dtp_End_Date.TabIndex = 7
        Me.dtp_End_Date.uclReadOnly = False
        '
        'PubDeptLeaderUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PubDeptLeaderUI"
        Me.Text = "PubDeptLeaderUI"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tcq_DeptCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents tcq_LeaderEmployeeCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_Effect_Date As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_End_Date As Syscom.Client.UCL.UCLDateTimePickerUC
End Class
