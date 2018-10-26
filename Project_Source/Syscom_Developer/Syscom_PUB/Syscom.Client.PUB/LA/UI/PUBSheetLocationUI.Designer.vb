<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBSheetLocationUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBSheetLocationUI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSheetCode = New System.Windows.Forms.Label()
        Me.lblZoneId = New System.Windows.Forms.Label()
        Me.lblSheetLocationDesc = New System.Windows.Forms.Label()
        Me.txtSheetLocationDesc = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.cmbSheetCode = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.cmbZoneId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.txtSheetContectTel = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblSheetContectTel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 89)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(903, 392)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(901, 355)
        '
        'dgvShowData
        '
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(901, 355)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblSheetCode, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblZoneId, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSheetLocationDesc, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSheetLocationDesc, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbSheetCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbZoneId, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSheetContectTel, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSheetContectTel, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(903, 89)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblSheetCode
        '
        Me.lblSheetCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSheetCode.AutoSize = True
        Me.lblSheetCode.ForeColor = System.Drawing.Color.Red
        Me.lblSheetCode.Location = New System.Drawing.Point(59, 14)
        Me.lblSheetCode.Name = "lblSheetCode"
        Me.lblSheetCode.Size = New System.Drawing.Size(80, 16)
        Me.lblSheetCode.TabIndex = 0
        Me.lblSheetCode.Text = "*表單代碼"
        Me.lblSheetCode.UseMnemonic = False
        '
        'lblZoneId
        '
        Me.lblZoneId.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblZoneId.AutoSize = True
        Me.lblZoneId.ForeColor = System.Drawing.Color.Red
        Me.lblZoneId.Location = New System.Drawing.Point(366, 14)
        Me.lblZoneId.Name = "lblZoneId"
        Me.lblZoneId.Size = New System.Drawing.Size(80, 16)
        Me.lblZoneId.TabIndex = 2
        Me.lblZoneId.Text = "*診區代碼"
        '
        'lblSheetLocationDesc
        '
        Me.lblSheetLocationDesc.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSheetLocationDesc.AutoSize = True
        Me.lblSheetLocationDesc.Location = New System.Drawing.Point(3, 58)
        Me.lblSheetLocationDesc.Name = "lblSheetLocationDesc"
        Me.lblSheetLocationDesc.Size = New System.Drawing.Size(136, 16)
        Me.lblSheetLocationDesc.TabIndex = 4
        Me.lblSheetLocationDesc.Text = "表單檢查位置說明"
        '
        'txtSheetLocationDesc
        '
        Me.txtSheetLocationDesc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtSheetLocationDesc, 3)
        Me.txtSheetLocationDesc.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSheetLocationDesc.Location = New System.Drawing.Point(145, 53)
        Me.txtSheetLocationDesc.MaxLength = 100
        Me.txtSheetLocationDesc.Name = "txtSheetLocationDesc"
        Me.txtSheetLocationDesc.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSheetLocationDesc.SelectionStart = 0
        Me.txtSheetLocationDesc.Size = New System.Drawing.Size(447, 27)
        Me.txtSheetLocationDesc.TabIndex = 5
        Me.txtSheetLocationDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSheetLocationDesc.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSheetLocationDesc.uclDollarSign = False
        Me.txtSheetLocationDesc.uclDotCount = 0
        Me.txtSheetLocationDesc.uclIntCount = 2
        Me.txtSheetLocationDesc.uclMinus = False
        Me.txtSheetLocationDesc.uclReadOnly = False
        Me.txtSheetLocationDesc.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSheetLocationDesc.uclTrimZero = True
        '
        'cmbSheetCode
        '
        Me.cmbSheetCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbSheetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSheetCode.DropDownWidth = 20
        Me.cmbSheetCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSheetCode.Location = New System.Drawing.Point(142, 10)
        Me.cmbSheetCode.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSheetCode.Name = "cmbSheetCode"
        Me.cmbSheetCode.SelectedIndex = -1
        Me.cmbSheetCode.SelectedItem = Nothing
        Me.cmbSheetCode.SelectedText = ""
        Me.cmbSheetCode.SelectedValue = ""
        Me.cmbSheetCode.SelectionStart = 0
        Me.cmbSheetCode.Size = New System.Drawing.Size(221, 24)
        Me.cmbSheetCode.TabIndex = 1
        Me.cmbSheetCode.uclDisplayIndex = "0,1"
        Me.cmbSheetCode.uclIsAutoClear = True
        Me.cmbSheetCode.uclIsFirstItemEmpty = True
        Me.cmbSheetCode.uclIsTextMode = False
        Me.cmbSheetCode.uclShowMsg = False
        Me.cmbSheetCode.uclValueIndex = "0"
        '
        'cmbZoneId
        '
        Me.cmbZoneId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cmbZoneId, 2)
        Me.cmbZoneId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbZoneId.DropDownWidth = 20
        Me.cmbZoneId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbZoneId.Location = New System.Drawing.Point(449, 10)
        Me.cmbZoneId.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbZoneId.Name = "cmbZoneId"
        Me.cmbZoneId.SelectedIndex = -1
        Me.cmbZoneId.SelectedItem = Nothing
        Me.cmbZoneId.SelectedText = ""
        Me.cmbZoneId.SelectedValue = ""
        Me.cmbZoneId.SelectionStart = 0
        Me.cmbZoneId.Size = New System.Drawing.Size(212, 24)
        Me.cmbZoneId.TabIndex = 3
        Me.cmbZoneId.uclDisplayIndex = "0,1"
        Me.cmbZoneId.uclIsAutoClear = True
        Me.cmbZoneId.uclIsFirstItemEmpty = True
        Me.cmbZoneId.uclIsTextMode = False
        Me.cmbZoneId.uclShowMsg = False
        Me.cmbZoneId.uclValueIndex = "0"
        '
        'txtSheetContectTel
        '
        Me.txtSheetContectTel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSheetContectTel.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSheetContectTel.Location = New System.Drawing.Point(708, 53)
        Me.txtSheetContectTel.MaxLength = 100
        Me.txtSheetContectTel.Name = "txtSheetContectTel"
        Me.txtSheetContectTel.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSheetContectTel.SelectionStart = 0
        Me.txtSheetContectTel.Size = New System.Drawing.Size(157, 27)
        Me.txtSheetContectTel.TabIndex = 7
        Me.txtSheetContectTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSheetContectTel.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSheetContectTel.uclDollarSign = False
        Me.txtSheetContectTel.uclDotCount = 0
        Me.txtSheetContectTel.uclIntCount = 2
        Me.txtSheetContectTel.uclMinus = False
        Me.txtSheetContectTel.uclReadOnly = False
        Me.txtSheetContectTel.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSheetContectTel.uclTrimZero = True
        '
        'lblSheetContectTel
        '
        Me.lblSheetContectTel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSheetContectTel.AutoSize = True
        Me.lblSheetContectTel.Location = New System.Drawing.Point(598, 58)
        Me.lblSheetContectTel.Name = "lblSheetContectTel"
        Me.lblSheetContectTel.Size = New System.Drawing.Size(104, 16)
        Me.lblSheetContectTel.TabIndex = 6
        Me.lblSheetContectTel.Text = "表單連絡分機"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "*郵遞區號"
        Me.Label1.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(295, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "郵遞區號名稱"
        '
        'PUBSheetLocationUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 481)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PUBSheetLocationUI"
        Me.Text = "PUBSheetLocationUI"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSheetCode As System.Windows.Forms.Label
    Friend WithEvents lblZoneId As System.Windows.Forms.Label
    Friend WithEvents lblSheetLocationDesc As System.Windows.Forms.Label
    Friend WithEvents lblSheetContectTel As System.Windows.Forms.Label
    Friend WithEvents txtSheetContectTel As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSheetLocationDesc As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents cmbSheetCode As Syscom.Client.UCL.UCLComboBoxUC
    Friend WithEvents cmbZoneId As Syscom.Client.UCL.UCLComboBoxUC
End Class
