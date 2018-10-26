<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBCureControlUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBCureControlUI))
        Me.gb_parent = New System.Windows.Forms.GroupBox()
        Me.tlp_parent = New System.Windows.Forms.TableLayoutPanel()
        Me.lb_treatmenttype = New System.Windows.Forms.Label()
        Me.lb_timecontroltype = New System.Windows.Forms.Label()
        Me.lb_timeperiod = New System.Windows.Forms.Label()
        Me.uclcb_curetypeid = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.uclcb_timecontrolid = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ucltxt_controlvalue = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.ucltxt_maxcnt = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lb_maxtimes = New System.Windows.Forms.Label()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cb_IsRegFee = New System.Windows.Forms.CheckBox()
        Me.cb_IsFeeCheck = New System.Windows.Forms.CheckBox()
        Me.btn_Clear = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.gb_parent.SuspendLayout()
        Me.tlp_parent.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_parent
        '
        Me.gb_parent.Controls.Add(Me.tlp_parent)
        Me.gb_parent.Location = New System.Drawing.Point(3, 3)
        Me.gb_parent.Name = "gb_parent"
        Me.gb_parent.Size = New System.Drawing.Size(542, 354)
        Me.gb_parent.TabIndex = 0
        Me.gb_parent.TabStop = False
        '
        'tlp_parent
        '
        Me.tlp_parent.ColumnCount = 2
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.80569!))
        Me.tlp_parent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.19431!))
        Me.tlp_parent.Controls.Add(Me.lb_treatmenttype, 0, 0)
        Me.tlp_parent.Controls.Add(Me.lb_timecontroltype, 0, 1)
        Me.tlp_parent.Controls.Add(Me.lb_timeperiod, 0, 2)
        Me.tlp_parent.Controls.Add(Me.uclcb_curetypeid, 1, 0)
        Me.tlp_parent.Controls.Add(Me.uclcb_timecontrolid, 1, 1)
        Me.tlp_parent.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.tlp_parent.Controls.Add(Me.Panel1, 0, 3)
        Me.tlp_parent.Controls.Add(Me.FlowLayoutPanel1, 1, 4)
        Me.tlp_parent.Location = New System.Drawing.Point(5, 15)
        Me.tlp_parent.Name = "tlp_parent"
        Me.tlp_parent.RowCount = 5
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlp_parent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_parent.Size = New System.Drawing.Size(508, 309)
        Me.tlp_parent.TabIndex = 0
        '
        'lb_treatmenttype
        '
        Me.lb_treatmenttype.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_treatmenttype.AutoSize = True
        Me.lb_treatmenttype.ForeColor = System.Drawing.Color.Red
        Me.lb_treatmenttype.Location = New System.Drawing.Point(81, 26)
        Me.lb_treatmenttype.Name = "lb_treatmenttype"
        Me.lb_treatmenttype.Size = New System.Drawing.Size(72, 16)
        Me.lb_treatmenttype.TabIndex = 0
        Me.lb_treatmenttype.Text = "療程類型"
        '
        'lb_timecontroltype
        '
        Me.lb_timecontroltype.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_timecontroltype.AutoSize = True
        Me.lb_timecontroltype.ForeColor = System.Drawing.Color.Red
        Me.lb_timecontroltype.Location = New System.Drawing.Point(49, 95)
        Me.lb_timecontroltype.Name = "lb_timecontroltype"
        Me.lb_timecontroltype.Size = New System.Drawing.Size(104, 16)
        Me.lb_timecontroltype.TabIndex = 1
        Me.lb_timecontroltype.Text = "時間控制類型"
        '
        'lb_timeperiod
        '
        Me.lb_timeperiod.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_timeperiod.AutoSize = True
        Me.lb_timeperiod.ForeColor = System.Drawing.Color.Red
        Me.lb_timeperiod.Location = New System.Drawing.Point(81, 164)
        Me.lb_timeperiod.Name = "lb_timeperiod"
        Me.lb_timeperiod.Size = New System.Drawing.Size(72, 16)
        Me.lb_timeperiod.TabIndex = 2
        Me.lb_timeperiod.Text = "時間數量"
        '
        'uclcb_curetypeid
        '
        Me.uclcb_curetypeid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_curetypeid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_curetypeid.DropDownWidth = 20
        Me.uclcb_curetypeid.DroppedDown = False
        Me.uclcb_curetypeid.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_curetypeid.Location = New System.Drawing.Point(160, 22)
        Me.uclcb_curetypeid.Margin = New System.Windows.Forms.Padding(4)
        Me.uclcb_curetypeid.Name = "uclcb_curetypeid"
        Me.uclcb_curetypeid.SelectedIndex = -1
        Me.uclcb_curetypeid.SelectedItem = Nothing
        Me.uclcb_curetypeid.SelectedText = ""
        Me.uclcb_curetypeid.SelectedValue = ""
        Me.uclcb_curetypeid.SelectionStart = 0
        Me.uclcb_curetypeid.Size = New System.Drawing.Size(161, 24)
        Me.uclcb_curetypeid.TabIndex = 4
        Me.uclcb_curetypeid.uclDisplayIndex = "0,1"
        Me.uclcb_curetypeid.uclIsAutoClear = True
        Me.uclcb_curetypeid.uclIsFirstItemEmpty = True
        Me.uclcb_curetypeid.uclIsTextMode = False
        Me.uclcb_curetypeid.uclShowMsg = False
        Me.uclcb_curetypeid.uclValueIndex = "0"
        '
        'uclcb_timecontrolid
        '
        Me.uclcb_timecontrolid.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.uclcb_timecontrolid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.uclcb_timecontrolid.DropDownWidth = 20
        Me.uclcb_timecontrolid.DroppedDown = False
        Me.uclcb_timecontrolid.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.uclcb_timecontrolid.Location = New System.Drawing.Point(160, 91)
        Me.uclcb_timecontrolid.Margin = New System.Windows.Forms.Padding(4)
        Me.uclcb_timecontrolid.Name = "uclcb_timecontrolid"
        Me.uclcb_timecontrolid.SelectedIndex = -1
        Me.uclcb_timecontrolid.SelectedItem = Nothing
        Me.uclcb_timecontrolid.SelectedText = ""
        Me.uclcb_timecontrolid.SelectedValue = ""
        Me.uclcb_timecontrolid.SelectionStart = 0
        Me.uclcb_timecontrolid.Size = New System.Drawing.Size(161, 24)
        Me.uclcb_timecontrolid.TabIndex = 5
        Me.uclcb_timecontrolid.uclDisplayIndex = "0,1"
        Me.uclcb_timecontrolid.uclIsAutoClear = True
        Me.uclcb_timecontrolid.uclIsFirstItemEmpty = True
        Me.uclcb_timecontrolid.uclIsTextMode = False
        Me.uclcb_timecontrolid.uclShowMsg = False
        Me.uclcb_timecontrolid.uclValueIndex = "0"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.05263!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.94737!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ucltxt_controlvalue, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucltxt_maxcnt, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_maxtimes, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(159, 141)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(286, 46)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'ucltxt_controlvalue
        '
        Me.ucltxt_controlvalue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucltxt_controlvalue.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucltxt_controlvalue.Location = New System.Drawing.Point(4, 9)
        Me.ucltxt_controlvalue.Margin = New System.Windows.Forms.Padding(4)
        Me.ucltxt_controlvalue.MaxLength = 10
        Me.ucltxt_controlvalue.Name = "ucltxt_controlvalue"
        Me.ucltxt_controlvalue.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucltxt_controlvalue.SelectionStart = 0
        Me.ucltxt_controlvalue.Size = New System.Drawing.Size(68, 27)
        Me.ucltxt_controlvalue.TabIndex = 0
        Me.ucltxt_controlvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucltxt_controlvalue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucltxt_controlvalue.ToolTipTag = Nothing
        Me.ucltxt_controlvalue.uclDollarSign = False
        Me.ucltxt_controlvalue.uclDotCount = 0
        Me.ucltxt_controlvalue.uclIntCount = 2
        Me.ucltxt_controlvalue.uclMinus = False
        Me.ucltxt_controlvalue.uclReadOnly = False
        Me.ucltxt_controlvalue.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.ucltxt_controlvalue.uclTrimZero = True
        '
        'ucltxt_maxcnt
        '
        Me.ucltxt_maxcnt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ucltxt_maxcnt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.ucltxt_maxcnt.Location = New System.Drawing.Point(190, 9)
        Me.ucltxt_maxcnt.Margin = New System.Windows.Forms.Padding(4)
        Me.ucltxt_maxcnt.MaxLength = 10
        Me.ucltxt_maxcnt.Name = "ucltxt_maxcnt"
        Me.ucltxt_maxcnt.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.ucltxt_maxcnt.SelectionStart = 0
        Me.ucltxt_maxcnt.Size = New System.Drawing.Size(75, 27)
        Me.ucltxt_maxcnt.TabIndex = 1
        Me.ucltxt_maxcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ucltxt_maxcnt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.ucltxt_maxcnt.ToolTipTag = Nothing
        Me.ucltxt_maxcnt.uclDollarSign = False
        Me.ucltxt_maxcnt.uclDotCount = 0
        Me.ucltxt_maxcnt.uclIntCount = 2
        Me.ucltxt_maxcnt.uclMinus = False
        Me.ucltxt_maxcnt.uclReadOnly = False
        Me.ucltxt_maxcnt.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Integer_Type
        Me.ucltxt_maxcnt.uclTrimZero = True
        '
        'lb_maxtimes
        '
        Me.lb_maxtimes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lb_maxtimes.AutoSize = True
        Me.lb_maxtimes.ForeColor = System.Drawing.Color.Red
        Me.lb_maxtimes.Location = New System.Drawing.Point(79, 15)
        Me.lb_maxtimes.Name = "lb_maxtimes"
        Me.lb_maxtimes.Size = New System.Drawing.Size(104, 16)
        Me.lb_maxtimes.TabIndex = 2
        Me.lb_maxtimes.Text = "療程最大次數"
        '
        'btn_confirm
        '
        Me.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_confirm.Location = New System.Drawing.Point(127, 3)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(105, 25)
        Me.btn_confirm.TabIndex = 3
        Me.btn_confirm.Text = "F12-確認"
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.tlp_parent.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.cb_IsRegFee)
        Me.Panel1.Controls.Add(Me.cb_IsFeeCheck)
        Me.Panel1.Location = New System.Drawing.Point(3, 210)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(489, 57)
        Me.Panel1.TabIndex = 22
        '
        'cb_IsRegFee
        '
        Me.cb_IsRegFee.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cb_IsRegFee.AutoSize = True
        Me.cb_IsRegFee.ForeColor = System.Drawing.Color.Red
        Me.cb_IsRegFee.Location = New System.Drawing.Point(65, 18)
        Me.cb_IsRegFee.Name = "cb_IsRegFee"
        Me.cb_IsRegFee.Size = New System.Drawing.Size(123, 20)
        Me.cb_IsRegFee.TabIndex = 20
        Me.cb_IsRegFee.Text = "需產生掛號費"
        Me.cb_IsRegFee.UseVisualStyleBackColor = True
        Me.cb_IsRegFee.Visible = False
        '
        'cb_IsFeeCheck
        '
        Me.cb_IsFeeCheck.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cb_IsFeeCheck.AutoSize = True
        Me.cb_IsFeeCheck.ForeColor = System.Drawing.Color.Red
        Me.cb_IsFeeCheck.Location = New System.Drawing.Point(240, 18)
        Me.cb_IsFeeCheck.Name = "cb_IsFeeCheck"
        Me.cb_IsFeeCheck.Size = New System.Drawing.Size(139, 20)
        Me.cb_IsFeeCheck.TabIndex = 21
        Me.cb_IsFeeCheck.Text = "需結帳才可執行"
        Me.cb_IsFeeCheck.UseVisualStyleBackColor = True
        Me.cb_IsFeeCheck.Visible = False
        '
        'btn_Clear
        '
        Me.btn_Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Clear.Location = New System.Drawing.Point(238, 3)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(105, 25)
        Me.btn_Clear.TabIndex = 23
        Me.btn_Clear.Text = "清除"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_Clear)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_confirm)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(159, 279)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(346, 27)
        Me.FlowLayoutPanel1.TabIndex = 24
        '
        'PUBCureControlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 369)
        Me.Controls.Add(Me.gb_parent)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PUBCureControlUI"
        Me.TabText = "療程控制維護"
        Me.Text = "療程控制維護"
        Me.gb_parent.ResumeLayout(False)
        Me.tlp_parent.ResumeLayout(False)
        Me.tlp_parent.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_parent As System.Windows.Forms.GroupBox
    Friend WithEvents tlp_parent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lb_treatmenttype As System.Windows.Forms.Label
    Friend WithEvents lb_timecontroltype As System.Windows.Forms.Label
    Friend WithEvents lb_timeperiod As System.Windows.Forms.Label
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents uclcb_curetypeid As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents uclcb_timecontrolid As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ucltxt_controlvalue As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents ucltxt_maxcnt As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents lb_maxtimes As System.Windows.Forms.Label
    Friend WithEvents cb_IsRegFee As System.Windows.Forms.CheckBox
    Friend WithEvents cb_IsFeeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
End Class
