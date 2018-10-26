<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PUBDeptSectUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PUBDeptSectUI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeptCode = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblOrderCode = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSectionId = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.lblSiteName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSectionEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDeptAliasEnName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtSectionName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.txtDeptAliasName = New Syscom.Client.UCL.UCLTextBoxUC()
        Me.chkDC = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboDeptSectKindId = New Syscom.Client.UCL.UCLComboBoxUC()
        Me.IUCLMaintainPanel.SuspendLayout()
        Me.pal_1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IUCLMaintainPanel
        '
        Me.IUCLMaintainPanel.Location = New System.Drawing.Point(0, 150)
        Me.IUCLMaintainPanel.Size = New System.Drawing.Size(922, 323)
        '
        'pal_1
        '
        Me.pal_1.Size = New System.Drawing.Size(920, 286)
        '
        'dgvShowData
        '
        Me.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvShowData.ColumnHeadersHeight = 4
        Me.dgvShowData.Size = New System.Drawing.Size(920, 286)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 150)
        Me.Panel1.TabIndex = 6
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDeptCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOrderCode, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSectionId, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSiteName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSectionEnName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDeptAliasEnName, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSectionName, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDeptAliasName, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkDC, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDeptSectKindId, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(914, 142)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "科診英文別名"
        '
        'txtDeptCode
        '
        Me.txtDeptCode.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptCode.Location = New System.Drawing.Point(114, 4)
        Me.txtDeptCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDeptCode.MaxLength = 10
        Me.txtDeptCode.Name = "txtDeptCode"
        Me.txtDeptCode.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptCode.SelectionStart = 0
        Me.txtDeptCode.Size = New System.Drawing.Size(75, 27)
        Me.txtDeptCode.TabIndex = 1
        Me.txtDeptCode.Tag = ""
        Me.txtDeptCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptCode.ToolTipTag = Nothing
        Me.txtDeptCode.uclDollarSign = False
        Me.txtDeptCode.uclDotCount = 0
        Me.txtDeptCode.uclIntCount = 2
        Me.txtDeptCode.uclMinus = False
        Me.txtDeptCode.uclReadOnly = False
        Me.txtDeptCode.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptCode.uclTrimZero = True
        '
        'lblOrderCode
        '
        Me.lblOrderCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblOrderCode.AutoSize = True
        Me.lblOrderCode.ForeColor = System.Drawing.Color.Red
        Me.lblOrderCode.Location = New System.Drawing.Point(35, 9)
        Me.lblOrderCode.Name = "lblOrderCode"
        Me.lblOrderCode.Size = New System.Drawing.Size(72, 16)
        Me.lblOrderCode.TabIndex = 0
        Me.lblOrderCode.Text = "科別代碼"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(204, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "診別代碼"
        '
        'txtSectionId
        '
        Me.txtSectionId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSectionId.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSectionId.Location = New System.Drawing.Point(283, 4)
        Me.txtSectionId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSectionId.MaxLength = 10
        Me.txtSectionId.Name = "txtSectionId"
        Me.txtSectionId.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSectionId.SelectionStart = 0
        Me.txtSectionId.Size = New System.Drawing.Size(95, 27)
        Me.txtSectionId.TabIndex = 3
        Me.txtSectionId.Tag = ""
        Me.txtSectionId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSectionId.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSectionId.ToolTipTag = Nothing
        Me.txtSectionId.uclDollarSign = False
        Me.txtSectionId.uclDotCount = 0
        Me.txtSectionId.uclIntCount = 2
        Me.txtSectionId.uclMinus = False
        Me.txtSectionId.uclReadOnly = False
        Me.txtSectionId.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSectionId.uclTrimZero = True
        '
        'lblSiteName
        '
        Me.lblSiteName.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSiteName.AutoSize = True
        Me.lblSiteName.Location = New System.Drawing.Point(35, 44)
        Me.lblSiteName.Name = "lblSiteName"
        Me.lblSiteName.Size = New System.Drawing.Size(72, 16)
        Me.lblSiteName.TabIndex = 6
        Me.lblSiteName.Text = "診別英文"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(385, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "診別名稱"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(385, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "科診別名"
        '
        'txtSectionEnName
        '
        Me.txtSectionEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtSectionEnName, 3)
        Me.txtSectionEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSectionEnName.Location = New System.Drawing.Point(114, 39)
        Me.txtSectionEnName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSectionEnName.MaxLength = 10
        Me.txtSectionEnName.Name = "txtSectionEnName"
        Me.txtSectionEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSectionEnName.SelectionStart = 0
        Me.txtSectionEnName.Size = New System.Drawing.Size(264, 27)
        Me.txtSectionEnName.TabIndex = 7
        Me.txtSectionEnName.Tag = ""
        Me.txtSectionEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSectionEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSectionEnName.ToolTipTag = Nothing
        Me.txtSectionEnName.uclDollarSign = False
        Me.txtSectionEnName.uclDotCount = 0
        Me.txtSectionEnName.uclIntCount = 2
        Me.txtSectionEnName.uclMinus = False
        Me.txtSectionEnName.uclReadOnly = False
        Me.txtSectionEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSectionEnName.uclTrimZero = True
        '
        'txtDeptAliasEnName
        '
        Me.txtDeptAliasEnName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDeptAliasEnName, 2)
        Me.txtDeptAliasEnName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptAliasEnName.Location = New System.Drawing.Point(114, 74)
        Me.txtDeptAliasEnName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDeptAliasEnName.MaxLength = 10
        Me.txtDeptAliasEnName.Name = "txtDeptAliasEnName"
        Me.txtDeptAliasEnName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptAliasEnName.SelectionStart = 0
        Me.txtDeptAliasEnName.Size = New System.Drawing.Size(161, 27)
        Me.txtDeptAliasEnName.TabIndex = 11
        Me.txtDeptAliasEnName.Tag = ""
        Me.txtDeptAliasEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptAliasEnName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptAliasEnName.ToolTipTag = Nothing
        Me.txtDeptAliasEnName.uclDollarSign = False
        Me.txtDeptAliasEnName.uclDotCount = 0
        Me.txtDeptAliasEnName.uclIntCount = 2
        Me.txtDeptAliasEnName.uclMinus = False
        Me.txtDeptAliasEnName.uclReadOnly = False
        Me.txtDeptAliasEnName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptAliasEnName.uclTrimZero = True
        '
        'txtSectionName
        '
        Me.txtSectionName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSectionName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtSectionName.Location = New System.Drawing.Point(464, 4)
        Me.txtSectionName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSectionName.MaxLength = 10
        Me.txtSectionName.Name = "txtSectionName"
        Me.txtSectionName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSectionName.SelectionStart = 0
        Me.txtSectionName.Size = New System.Drawing.Size(279, 27)
        Me.txtSectionName.TabIndex = 5
        Me.txtSectionName.Tag = ""
        Me.txtSectionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSectionName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtSectionName.ToolTipTag = Nothing
        Me.txtSectionName.uclDollarSign = False
        Me.txtSectionName.uclDotCount = 0
        Me.txtSectionName.uclIntCount = 2
        Me.txtSectionName.uclMinus = False
        Me.txtSectionName.uclReadOnly = False
        Me.txtSectionName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtSectionName.uclTrimZero = True
        '
        'txtDeptAliasName
        '
        Me.txtDeptAliasName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDeptAliasName.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtDeptAliasName.Location = New System.Drawing.Point(464, 39)
        Me.txtDeptAliasName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDeptAliasName.MaxLength = 10
        Me.txtDeptAliasName.Name = "txtDeptAliasName"
        Me.txtDeptAliasName.PasswordChar = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDeptAliasName.SelectionStart = 0
        Me.txtDeptAliasName.Size = New System.Drawing.Size(279, 27)
        Me.txtDeptAliasName.TabIndex = 9
        Me.txtDeptAliasName.Tag = ""
        Me.txtDeptAliasName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeptAliasName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.txtDeptAliasName.ToolTipTag = Nothing
        Me.txtDeptAliasName.uclDollarSign = False
        Me.txtDeptAliasName.uclDotCount = 0
        Me.txtDeptAliasName.uclIntCount = 2
        Me.txtDeptAliasName.uclMinus = False
        Me.txtDeptAliasName.uclReadOnly = False
        Me.txtDeptAliasName.uclTextType = Syscom.Client.UCL.UCLTextBoxUC.uclTextTypeData.Any_Type
        Me.txtDeptAliasName.uclTrimZero = True
        '
        'chkDC
        '
        Me.chkDC.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkDC.AutoSize = True
        Me.chkDC.Location = New System.Drawing.Point(385, 77)
        Me.chkDC.Name = "chkDC"
        Me.chkDC.Size = New System.Drawing.Size(59, 20)
        Me.chkDC.TabIndex = 16
        Me.chkDC.Text = "停用"
        Me.chkDC.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "科診屬性"
        '
        'cboDeptSectKindId
        '
        Me.cboDeptSectKindId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboDeptSectKindId, 3)
        Me.cboDeptSectKindId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cboDeptSectKindId.DropDownWidth = 20
        Me.cboDeptSectKindId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboDeptSectKindId.Location = New System.Drawing.Point(110, 110)
        Me.cboDeptSectKindId.Margin = New System.Windows.Forms.Padding(0)
        Me.cboDeptSectKindId.Name = "cboDeptSectKindId"
        Me.cboDeptSectKindId.SelectedIndex = -1
        Me.cboDeptSectKindId.SelectedItem = Nothing
        Me.cboDeptSectKindId.SelectedText = ""
        Me.cboDeptSectKindId.SelectedValue = ""
        Me.cboDeptSectKindId.SelectionStart = 0
        Me.cboDeptSectKindId.Size = New System.Drawing.Size(268, 26)
        Me.cboDeptSectKindId.TabIndex = 18
        Me.cboDeptSectKindId.uclDisplayIndex = "0,1"
        Me.cboDeptSectKindId.uclIsAutoClear = True
        Me.cboDeptSectKindId.uclIsFirstItemEmpty = True
        Me.cboDeptSectKindId.uclIsTextMode = False
        Me.cboDeptSectKindId.uclShowMsg = False
        Me.cboDeptSectKindId.uclValueIndex = "0"
        '
        'PUBDeptSectUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 473)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PUBDeptSectUI"
        Me.Text = "科診維護"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.IUCLMaintainPanel, 0)
        Me.IUCLMaintainPanel.ResumeLayout(False)
        Me.pal_1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtDeptCode As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents chkDC As System.Windows.Forms.CheckBox
    Friend WithEvents lblOrderCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSectionId As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSiteName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSectionEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDeptAliasEnName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtSectionName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents txtDeptAliasName As Syscom.Client.UCL.UCLTextBoxUC
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDeptSectKindId As Syscom.Client.UCL.UCLComboBoxUC
End Class
