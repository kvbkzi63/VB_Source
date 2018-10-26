<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBOrderAlternativeUI
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
        Me.tlp_Main = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_OrderCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.txt_AlternativeCode = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 40)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(788, 309)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(786, 272)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(786, 272)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 4
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.71066!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.28934!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171.0!))
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 282.0!))
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main.Controls.Add(Me.txt_OrderCode, 1, 0)
        Me.tlp_Main.Controls.Add(Me.txt_AlternativeCode, 3, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 1
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Main.Size = New System.Drawing.Size(788, 40)
        Me.tlp_Main.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "醫令代碼"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(382, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "可替代醫令代碼"
        '
        'txt_OrderCode
        '
        Me.txt_OrderCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_OrderCode.doFlag = True
        Me.txt_OrderCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_OrderCode.Location = New System.Drawing.Point(102, 7)
        Me.txt_OrderCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_OrderCode.Name = "txt_OrderCode"
        Me.txt_OrderCode.Size = New System.Drawing.Size(162, 26)
        Me.txt_OrderCode.TabIndex = 2
        Me.txt_OrderCode.uclBaseDate = ""
        Me.txt_OrderCode.uclCboWidth = 125
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
        Me.txt_OrderCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txt_OrderCode.uclTotalWidth = 8
        Me.txt_OrderCode.uclXPosition = 225
        Me.txt_OrderCode.uclYPosition = 120
        '
        'txt_AlternativeCode
        '
        Me.txt_AlternativeCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_AlternativeCode.doFlag = True
        Me.txt_AlternativeCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_AlternativeCode.Location = New System.Drawing.Point(505, 7)
        Me.txt_AlternativeCode.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_AlternativeCode.Name = "txt_AlternativeCode"
        Me.txt_AlternativeCode.Size = New System.Drawing.Size(162, 26)
        Me.txt_AlternativeCode.TabIndex = 3
        Me.txt_AlternativeCode.uclBaseDate = ""
        Me.txt_AlternativeCode.uclCboWidth = 125
        Me.txt_AlternativeCode.uclCodeName = ""
        Me.txt_AlternativeCode.uclCodeName1 = ""
        Me.txt_AlternativeCode.uclCodeName2 = ""
        Me.txt_AlternativeCode.uclCodeValue = ""
        Me.txt_AlternativeCode.uclCodeValue1 = ""
        Me.txt_AlternativeCode.uclCodeValue2 = ""
        Me.txt_AlternativeCode.uclConditionDate = ""
        Me.txt_AlternativeCode.uclControlFlag = True
        Me.txt_AlternativeCode.uclDeptCode = ""
        Me.txt_AlternativeCode.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_AlternativeCode.uclDisplayIndex = "0,1"
        Me.txt_AlternativeCode.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_AlternativeCode.uclIsAutoAddZero = False
        Me.txt_AlternativeCode.uclIsBtnVisible = True
        Me.txt_AlternativeCode.uclIsCheckDoctorOnDuty = False
        Me.txt_AlternativeCode.uclIsCheckDrLicense = True
        Me.txt_AlternativeCode.uclIsCheckTime = True
        Me.txt_AlternativeCode.uclIsEnglishDept = False
        Me.txt_AlternativeCode.uclIsReturnDS = False
        Me.txt_AlternativeCode.uclIsShowMsgBox = True
        Me.txt_AlternativeCode.uclIsTextAutoClear = True
        Me.txt_AlternativeCode.uclLabel = ""
        Me.txt_AlternativeCode.uclMsgValue = Nothing
        Me.txt_AlternativeCode.uclNoDataOpenWindow = False
        Me.txt_AlternativeCode.uclPUBEmployeeProfessalKindId = ""
        Me.txt_AlternativeCode.uclQueryField = Nothing
        Me.txt_AlternativeCode.uclQueryValue = Nothing
        Me.txt_AlternativeCode.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_AlternativeCode.uclRegionKind = ""
        Me.txt_AlternativeCode.uclRoles = ""
        Me.txt_AlternativeCode.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Order
        Me.txt_AlternativeCode.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.Code
        Me.txt_AlternativeCode.uclTotalWidth = 8
        Me.txt_AlternativeCode.uclXPosition = 225
        Me.txt_AlternativeCode.uclYPosition = 120
        '
        'PUBOrderAlternativeUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 349)
        Me.Controls.Add(Me.tlp_Main)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "PUBOrderAlternativeUI"
        Me.Text = "PUBOrderAlternativeUI"
        Me.Controls.SetChildIndex(Me.tlp_Main, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.tlp_Main.ResumeLayout(False)
        Me.tlp_Main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlp_Main As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_OrderCode As Syscom.Client.UCL.UCLTextCodeQueryUI
    Friend WithEvents txt_AlternativeCode As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
