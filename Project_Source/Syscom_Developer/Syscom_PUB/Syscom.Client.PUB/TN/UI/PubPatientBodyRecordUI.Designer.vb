<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PubPatientBodyRecordUI
    'Inherits System.Windows.Forms.Form

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
        Me.txt_Chart_No = New Syscom.Client.UCL.UCLTextCodeQueryUI()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Measure_Time = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Height = New System.Windows.Forms.TextBox()
        Me.txt_Weight = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Pulse = New System.Windows.Forms.TextBox()
        Me.txt_Breath = New System.Windows.Forms.TextBox()
        Me.txt_Temperature = New System.Windows.Forms.TextBox()
        Me.txt_Blood_Pressure = New System.Windows.Forms.TextBox()
        Me.txt_Blood_Diastolic = New System.Windows.Forms.TextBox()
        Me.dtp_Measure_Time = New Syscom.Client.UCL.UCLDateTimePickerUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.tlp_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 135)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(964, 506)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(962, 469)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(962, 469)
        '
        'tlp_Main
        '
        Me.tlp_Main.ColumnCount = 6
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_Main.Controls.Add(Me.txt_Chart_No, 1, 0)
        Me.tlp_Main.Controls.Add(Me.Label1, 0, 0)
        Me.tlp_Main.Controls.Add(Me.txt_Measure_Time, 4, 0)
        Me.tlp_Main.Controls.Add(Me.Label2, 2, 0)
        Me.tlp_Main.Controls.Add(Me.Label4, 0, 1)
        Me.tlp_Main.Controls.Add(Me.Label5, 2, 1)
        Me.tlp_Main.Controls.Add(Me.Label7, 0, 2)
        Me.tlp_Main.Controls.Add(Me.Label8, 2, 2)
        Me.tlp_Main.Controls.Add(Me.Label9, 4, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Height, 1, 1)
        Me.tlp_Main.Controls.Add(Me.txt_Weight, 3, 1)
        Me.tlp_Main.Controls.Add(Me.Label10, 0, 3)
        Me.tlp_Main.Controls.Add(Me.Label11, 2, 3)
        Me.tlp_Main.Controls.Add(Me.txt_Pulse, 1, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Breath, 3, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Temperature, 5, 2)
        Me.tlp_Main.Controls.Add(Me.txt_Blood_Pressure, 1, 3)
        Me.tlp_Main.Controls.Add(Me.txt_Blood_Diastolic, 3, 3)
        Me.tlp_Main.Controls.Add(Me.dtp_Measure_Time, 3, 0)
        Me.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_Main.Location = New System.Drawing.Point(0, 0)
        Me.tlp_Main.Name = "tlp_Main"
        Me.tlp_Main.RowCount = 4
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Main.Size = New System.Drawing.Size(964, 135)
        Me.tlp_Main.TabIndex = 0
        '
        'txt_Chart_No
        '
        Me.txt_Chart_No.doFlag = True
        Me.txt_Chart_No.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txt_Chart_No.Location = New System.Drawing.Point(88, 0)
        Me.txt_Chart_No.Margin = New System.Windows.Forms.Padding(0)
        Me.txt_Chart_No.Name = "txt_Chart_No"
        Me.txt_Chart_No.Size = New System.Drawing.Size(162, 26)
        Me.txt_Chart_No.TabIndex = 1
        Me.txt_Chart_No.uclBaseDate = "2015/05/23"
        Me.txt_Chart_No.uclCboWidth = 126
        Me.txt_Chart_No.uclCodeName = ""
        Me.txt_Chart_No.uclCodeName1 = ""
        Me.txt_Chart_No.uclCodeName2 = ""
        Me.txt_Chart_No.uclCodeValue = ""
        Me.txt_Chart_No.uclCodeValue1 = ""
        Me.txt_Chart_No.uclCodeValue2 = ""
        Me.txt_Chart_No.uclControlFlag = True
        Me.txt_Chart_No.uclDeptType = Syscom.Client.UCL.UCLTextCodeQueryUI.DeptType.None
        Me.txt_Chart_No.uclDisplayIndex = "0,1"
        Me.txt_Chart_No.uclDropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txt_Chart_No.uclIsAutoAddZero = False
        Me.txt_Chart_No.uclIsBtnVisible = True
        Me.txt_Chart_No.uclIsCheckDoctorOnDuty = False
        Me.txt_Chart_No.uclIsEnglishDept = False
        Me.txt_Chart_No.uclIsReturnDS = False
        Me.txt_Chart_No.uclIsShowMsgBox = True
        Me.txt_Chart_No.uclIsTextAutoClear = True
        Me.txt_Chart_No.uclLabel = ""
        Me.txt_Chart_No.uclMsgValue = Nothing
        Me.txt_Chart_No.uclPUBEmployeeProfessalKindId = ""
        Me.txt_Chart_No.uclQueryField = Nothing
        Me.txt_Chart_No.uclQueryValue = Nothing
        Me.txt_Chart_No.uclRefHosp = Syscom.Client.UCL.UCLTextCodeQueryUI.uclRefHospData.All
        Me.txt_Chart_No.uclTableName = Syscom.Client.UCL.UCLTextCodeQueryUI.uclQueryTable.PUB_Patient
        Me.txt_Chart_No.uclTextBoxShow = Syscom.Client.UCL.UCLTextCodeQueryUI.ShowText.CodeAndName
        Me.txt_Chart_No.uclTotalWidth = 8
        Me.txt_Chart_No.uclXPosition = 225
        Me.txt_Chart_No.uclYPosition = 120
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "病歷號"
        '
        'txt_Measure_Time
        '
        Me.txt_Measure_Time.Location = New System.Drawing.Point(464, 3)
        Me.txt_Measure_Time.MaxLength = 8
        Me.txt_Measure_Time.Name = "txt_Measure_Time"
        Me.txt_Measure_Time.Size = New System.Drawing.Size(53, 27)
        Me.txt_Measure_Time.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "測量時間"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "身高(公分)"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "體重(公斤)"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "脈搏"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(295, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "呼吸"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(477, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "體溫"
        '
        'txt_Height
        '
        Me.txt_Height.Location = New System.Drawing.Point(91, 36)
        Me.txt_Height.Name = "txt_Height"
        Me.txt_Height.Size = New System.Drawing.Size(156, 27)
        Me.txt_Height.TabIndex = 11
        '
        'txt_Weight
        '
        Me.txt_Weight.Location = New System.Drawing.Point(341, 36)
        Me.txt_Weight.Name = "txt_Weight"
        Me.txt_Weight.Size = New System.Drawing.Size(117, 27)
        Me.txt_Weight.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 109)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "收縮壓"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(279, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "舒張壓"
        '
        'txt_Pulse
        '
        Me.txt_Pulse.Location = New System.Drawing.Point(91, 69)
        Me.txt_Pulse.Name = "txt_Pulse"
        Me.txt_Pulse.Size = New System.Drawing.Size(156, 27)
        Me.txt_Pulse.TabIndex = 15
        '
        'txt_Breath
        '
        Me.txt_Breath.Location = New System.Drawing.Point(341, 69)
        Me.txt_Breath.Name = "txt_Breath"
        Me.txt_Breath.Size = New System.Drawing.Size(117, 27)
        Me.txt_Breath.TabIndex = 16
        '
        'txt_Temperature
        '
        Me.txt_Temperature.Location = New System.Drawing.Point(523, 69)
        Me.txt_Temperature.Name = "txt_Temperature"
        Me.txt_Temperature.Size = New System.Drawing.Size(117, 27)
        Me.txt_Temperature.TabIndex = 17
        '
        'txt_Blood_Pressure
        '
        Me.txt_Blood_Pressure.Location = New System.Drawing.Point(91, 102)
        Me.txt_Blood_Pressure.Name = "txt_Blood_Pressure"
        Me.txt_Blood_Pressure.Size = New System.Drawing.Size(156, 27)
        Me.txt_Blood_Pressure.TabIndex = 18
        '
        'txt_Blood_Diastolic
        '
        Me.txt_Blood_Diastolic.Location = New System.Drawing.Point(341, 102)
        Me.txt_Blood_Diastolic.Name = "txt_Blood_Diastolic"
        Me.txt_Blood_Diastolic.Size = New System.Drawing.Size(117, 27)
        Me.txt_Blood_Diastolic.TabIndex = 19
        '
        'dtp_Measure_Time
        '
        Me.dtp_Measure_Time.DisplayLocale = Syscom.Client.UCL.UCLDateTimePickerUC.Locale.US
        Me.dtp_Measure_Time.DisplayMode = Syscom.Client.UCL.UCLDateTimePickerUC.DisplayType.SystemDefault
        Me.dtp_Measure_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtp_Measure_Time.Location = New System.Drawing.Point(341, 3)
        Me.dtp_Measure_Time.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtp_Measure_Time.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtp_Measure_Time.Name = "dtp_Measure_Time"
        Me.dtp_Measure_Time.Size = New System.Drawing.Size(117, 27)
        Me.dtp_Measure_Time.TabIndex = 0
        Me.dtp_Measure_Time.uclReadOnly = False
        '
        'PubPatientBodyRecordUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 641)
        Me.Controls.Add(Me.tlp_Main)
        Me.Name = "PubPatientBodyRecordUI"
        Me.TabText = "護理資訊"
        Me.Text = "病人身高體重登記作業"
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_Measure_Time As Syscom.Client.UCL.UCLDateTimePickerUC
    Friend WithEvents txt_Measure_Time As System.Windows.Forms.TextBox
    Friend WithEvents txt_Height As System.Windows.Forms.TextBox
    Friend WithEvents txt_Weight As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Pulse As System.Windows.Forms.TextBox
    Friend WithEvents txt_Breath As System.Windows.Forms.TextBox
    Friend WithEvents txt_Temperature As System.Windows.Forms.TextBox
    Friend WithEvents txt_Blood_Pressure As System.Windows.Forms.TextBox
    Friend WithEvents txt_Blood_Diastolic As System.Windows.Forms.TextBox
    Friend WithEvents txt_Chart_No As Syscom.Client.UCL.UCLTextCodeQueryUI
End Class
