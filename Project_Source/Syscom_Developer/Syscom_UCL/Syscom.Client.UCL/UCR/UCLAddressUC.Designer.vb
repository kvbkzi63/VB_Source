<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLAddressUC
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            pvtReceiveMgr = Nothing
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_Area = New System.Windows.Forms.ComboBox()
        Me.cbo_Vil = New System.Windows.Forms.ComboBox()
        Me.btn_Area = New Syscom.Client.UCL.UCLBtnCodeQueryUC()
        Me.Txt_Address = New System.Windows.Forms.TextBox()
        Me.btn_Vil = New Syscom.Client.UCL.UCLBtnCodeQueryUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Area, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbo_Vil, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Area, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txt_Address, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Vil, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(681, 27)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'cbo_Area
        '
        Me.cbo_Area.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Area.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbo_Area.FormattingEnabled = True
        Me.cbo_Area.Location = New System.Drawing.Point(0, 1)
        Me.cbo_Area.Margin = New System.Windows.Forms.Padding(0)
        Me.cbo_Area.Name = "cbo_Area"
        Me.cbo_Area.Size = New System.Drawing.Size(125, 24)
        Me.cbo_Area.TabIndex = 0
        '
        'cbo_Vil
        '
        Me.cbo_Vil.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbo_Vil.FormattingEnabled = True
        Me.cbo_Vil.Location = New System.Drawing.Point(157, 3)
        Me.cbo_Vil.Margin = New System.Windows.Forms.Padding(3, 0, 1, 0)
        Me.cbo_Vil.Name = "cbo_Vil"
        Me.cbo_Vil.Size = New System.Drawing.Size(80, 24)
        Me.cbo_Vil.TabIndex = 2
        '
        'btn_Area
        '
        Me.btn_Area.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Area.Location = New System.Drawing.Point(125, 0)
        Me.btn_Area.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Area.Name = "btn_Area"
        Me.btn_Area.Size = New System.Drawing.Size(29, 27)
        Me.btn_Area.TabIndex = 4
        Me.btn_Area.uclAreaCode = ""
        Me.btn_Area.uclBtnText = "..."
        Me.btn_Area.uclEnableQueryList = True
        Me.btn_Area.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.btn_Area.uclIsCheckDoctorOnDuty = False
        Me.btn_Area.uclIsReturnDS = False
        Me.btn_Area.uclQueryField = Nothing
        Me.btn_Area.uclQueryValue = Nothing
        Me.btn_Area.uclRefHosp = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclRefHospData.All
        Me.btn_Area.uclSelectType = Syscom.Client.UCL.UCLBtnCodeQueryUC.SelectType.SingleSelect
        Me.btn_Area.uclTableName = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclQueryTable.PUB_Area
        Me.btn_Area.uclXPosition = 225
        Me.btn_Area.uclYPosition = 120
        '
        'Txt_Address
        '
        Me.Txt_Address.Dock = System.Windows.Forms.DockStyle.Top
        Me.Txt_Address.Location = New System.Drawing.Point(270, 0)
        Me.Txt_Address.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Txt_Address.Name = "Txt_Address"
        Me.Txt_Address.Size = New System.Drawing.Size(411, 27)
        Me.Txt_Address.TabIndex = 3
        '
        'btn_Vil
        '
        Me.btn_Vil.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_Vil.Location = New System.Drawing.Point(238, 0)
        Me.btn_Vil.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_Vil.Name = "btn_Vil"
        Me.btn_Vil.Size = New System.Drawing.Size(29, 27)
        Me.btn_Vil.TabIndex = 5
        Me.btn_Vil.uclAreaCode = ""
        Me.btn_Vil.uclBtnText = "..."
        Me.btn_Vil.uclEnableQueryList = True
        Me.btn_Vil.uclIsCanSelectReserveChartNoForMultiChartNo = True
        Me.btn_Vil.uclIsCheckDoctorOnDuty = False
        Me.btn_Vil.uclIsReturnDS = False
        Me.btn_Vil.uclQueryField = Nothing
        Me.btn_Vil.uclQueryValue = Nothing
        Me.btn_Vil.uclRefHosp = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclRefHospData.All
        Me.btn_Vil.uclSelectType = Syscom.Client.UCL.UCLBtnCodeQueryUC.SelectType.SingleSelect
        Me.btn_Vil.uclTableName = Syscom.Client.UCL.UCLBtnCodeQueryUC.uclQueryTable.PUB_Vil
        Me.btn_Vil.uclXPosition = 225
        Me.btn_Vil.uclYPosition = 120
        '
        'UCLAddressUC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UCLAddressUC"
        Me.Size = New System.Drawing.Size(681, 26)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbo_Area As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Address As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Vil As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Area As Syscom.Client.UCL.UCLBtnCodeQueryUC
    Friend WithEvents btn_Vil As Syscom.Client.UCL.UCLBtnCodeQueryUC

End Class
