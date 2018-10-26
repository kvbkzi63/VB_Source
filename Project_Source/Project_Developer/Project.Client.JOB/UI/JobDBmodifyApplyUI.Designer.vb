<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobDBmodifyApplyUI
    Inherits Syscom.Client.UCL.BaseFormUI

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
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_TableChName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Index = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_TableName = New System.Windows.Forms.TextBox()
        Me.txt_DBName = New System.Windows.Forms.TextBox()
        Me.btn_Confirm = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtb_Desc = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.flp_ModifiedClassify = New System.Windows.Forms.FlowLayoutPanel()
        Me.ckb_CreateTable = New System.Windows.Forms.CheckBox()
        Me.ckb_ModifiedColumn = New System.Windows.Forms.CheckBox()
        Me.ckb_ColumnTypeModified = New System.Windows.Forms.CheckBox()
        Me.ckb_ModifiedLenth = New System.Windows.Forms.CheckBox()
        Me.ckb_CreateIndex = New System.Windows.Forms.CheckBox()
        Me.ckb_ModifiedIndex = New System.Windows.Forms.CheckBox()
        Me.ckb_Other = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.flp_Restrict = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbk_UnRestrict = New System.Windows.Forms.CheckBox()
        Me.ckb_Synchronize = New System.Windows.Forms.CheckBox()
        Me.ckb_OtherRestrict = New System.Windows.Forms.CheckBox()
        Me.rtb_Script = New Syscom.Client.UCL.UCLRichTextBoxUC()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.flp_ModifiedClassify.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.flp_Restrict.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_TableChName, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_Index, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_TableName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txt_DBName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_Confirm, 5, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.45901!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.54099!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1008, 84)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(461, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Table中文名稱"
        '
        'txt_TableChName
        '
        Me.txt_TableChName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_TableChName.Location = New System.Drawing.Point(574, 50)
        Me.txt_TableChName.Name = "txt_TableChName"
        Me.txt_TableChName.Size = New System.Drawing.Size(167, 27)
        Me.txt_TableChName.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(450, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "        索引" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(多個以;號分開)"
        '
        'txt_Index
        '
        Me.txt_Index.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Index.Location = New System.Drawing.Point(574, 8)
        Me.txt_Index.Name = "txt_Index"
        Me.txt_Index.Size = New System.Drawing.Size(167, 27)
        Me.txt_Index.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(46, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Table名稱"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "       DB名稱" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(多個以;號分開)"
        '
        'txt_TableName
        '
        Me.txt_TableName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_TableName.Location = New System.Drawing.Point(127, 50)
        Me.txt_TableName.Name = "txt_TableName"
        Me.txt_TableName.Size = New System.Drawing.Size(167, 27)
        Me.txt_TableName.TabIndex = 9
        '
        'txt_DBName
        '
        Me.txt_DBName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_DBName.Location = New System.Drawing.Point(127, 8)
        Me.txt_DBName.Name = "txt_DBName"
        Me.txt_DBName.Size = New System.Drawing.Size(317, 27)
        Me.txt_DBName.TabIndex = 7
        '
        'btn_Confirm
        '
        Me.btn_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Confirm.Location = New System.Drawing.Point(747, 49)
        Me.btn_Confirm.Name = "btn_Confirm"
        Me.btn_Confirm.Size = New System.Drawing.Size(150, 29)
        Me.btn_Confirm.TabIndex = 14
        Me.btn_Confirm.Text = "送出申請"
        Me.btn_Confirm.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtb_Desc)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(0, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1008, 88)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "影響說明"
        '
        'rtb_Desc
        '
        Me.rtb_Desc.Location = New System.Drawing.Point(3, 23)
        Me.rtb_Desc.Name = "rtb_Desc"
        Me.rtb_Desc.Size = New System.Drawing.Size(995, 59)
        Me.rtb_Desc.TabIndex = 21
        Me.rtb_Desc.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtb_Script)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(0, 295)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 214)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Script"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.flp_ModifiedClassify)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(2, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1006, 60)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "異動類型"
        '
        'flp_ModifiedClassify
        '
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_CreateTable)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_ModifiedColumn)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_ColumnTypeModified)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_ModifiedLenth)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_CreateIndex)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_ModifiedIndex)
        Me.flp_ModifiedClassify.Controls.Add(Me.ckb_Other)
        Me.flp_ModifiedClassify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp_ModifiedClassify.Location = New System.Drawing.Point(3, 23)
        Me.flp_ModifiedClassify.Name = "flp_ModifiedClassify"
        Me.flp_ModifiedClassify.Size = New System.Drawing.Size(1000, 34)
        Me.flp_ModifiedClassify.TabIndex = 0
        '
        'ckb_CreateTable
        '
        Me.ckb_CreateTable.AutoSize = True
        Me.ckb_CreateTable.Location = New System.Drawing.Point(3, 3)
        Me.ckb_CreateTable.Name = "ckb_CreateTable"
        Me.ckb_CreateTable.Size = New System.Drawing.Size(94, 20)
        Me.ckb_CreateTable.TabIndex = 14
        Me.ckb_CreateTable.Text = "新增Table"
        Me.ckb_CreateTable.UseVisualStyleBackColor = True
        '
        'ckb_ModifiedColumn
        '
        Me.ckb_ModifiedColumn.AutoSize = True
        Me.ckb_ModifiedColumn.Location = New System.Drawing.Point(103, 3)
        Me.ckb_ModifiedColumn.Name = "ckb_ModifiedColumn"
        Me.ckb_ModifiedColumn.Size = New System.Drawing.Size(91, 20)
        Me.ckb_ModifiedColumn.TabIndex = 15
        Me.ckb_ModifiedColumn.Text = "欄位異動"
        Me.ckb_ModifiedColumn.UseVisualStyleBackColor = True
        '
        'ckb_ColumnTypeModified
        '
        Me.ckb_ColumnTypeModified.AutoSize = True
        Me.ckb_ColumnTypeModified.Location = New System.Drawing.Point(200, 3)
        Me.ckb_ColumnTypeModified.Name = "ckb_ColumnTypeModified"
        Me.ckb_ColumnTypeModified.Size = New System.Drawing.Size(123, 20)
        Me.ckb_ColumnTypeModified.TabIndex = 16
        Me.ckb_ColumnTypeModified.Text = "欄位型態異動"
        Me.ckb_ColumnTypeModified.UseVisualStyleBackColor = True
        '
        'ckb_ModifiedLenth
        '
        Me.ckb_ModifiedLenth.AutoSize = True
        Me.ckb_ModifiedLenth.Location = New System.Drawing.Point(329, 3)
        Me.ckb_ModifiedLenth.Name = "ckb_ModifiedLenth"
        Me.ckb_ModifiedLenth.Size = New System.Drawing.Size(123, 20)
        Me.ckb_ModifiedLenth.TabIndex = 17
        Me.ckb_ModifiedLenth.Text = "欄位長度異動"
        Me.ckb_ModifiedLenth.UseVisualStyleBackColor = True
        '
        'ckb_CreateIndex
        '
        Me.ckb_CreateIndex.AutoSize = True
        Me.ckb_CreateIndex.Location = New System.Drawing.Point(458, 3)
        Me.ckb_CreateIndex.Name = "ckb_CreateIndex"
        Me.ckb_CreateIndex.Size = New System.Drawing.Size(107, 20)
        Me.ckb_CreateIndex.TabIndex = 18
        Me.ckb_CreateIndex.Text = "Create Index"
        Me.ckb_CreateIndex.UseVisualStyleBackColor = True
        '
        'ckb_ModifiedIndex
        '
        Me.ckb_ModifiedIndex.AutoSize = True
        Me.ckb_ModifiedIndex.Location = New System.Drawing.Point(571, 3)
        Me.ckb_ModifiedIndex.Name = "ckb_ModifiedIndex"
        Me.ckb_ModifiedIndex.Size = New System.Drawing.Size(78, 20)
        Me.ckb_ModifiedIndex.TabIndex = 19
        Me.ckb_ModifiedIndex.Text = "PK異動"
        Me.ckb_ModifiedIndex.UseVisualStyleBackColor = True
        '
        'ckb_Other
        '
        Me.ckb_Other.AutoSize = True
        Me.ckb_Other.Location = New System.Drawing.Point(655, 3)
        Me.ckb_Other.Name = "ckb_Other"
        Me.ckb_Other.Size = New System.Drawing.Size(67, 20)
        Me.ckb_Other.TabIndex = 20
        Me.ckb_Other.Text = "其他  "
        Me.ckb_Other.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.flp_Restrict)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Olive
        Me.GroupBox4.Location = New System.Drawing.Point(3, 84)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1005, 60)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "限制"
        '
        'flp_Restrict
        '
        Me.flp_Restrict.Controls.Add(Me.cbk_UnRestrict)
        Me.flp_Restrict.Controls.Add(Me.ckb_Synchronize)
        Me.flp_Restrict.Controls.Add(Me.ckb_OtherRestrict)
        Me.flp_Restrict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flp_Restrict.Location = New System.Drawing.Point(3, 23)
        Me.flp_Restrict.Name = "flp_Restrict"
        Me.flp_Restrict.Size = New System.Drawing.Size(999, 34)
        Me.flp_Restrict.TabIndex = 0
        '
        'cbk_UnRestrict
        '
        Me.cbk_UnRestrict.AutoSize = True
        Me.cbk_UnRestrict.Location = New System.Drawing.Point(3, 3)
        Me.cbk_UnRestrict.Name = "cbk_UnRestrict"
        Me.cbk_UnRestrict.Size = New System.Drawing.Size(75, 20)
        Me.cbk_UnRestrict.TabIndex = 11
        Me.cbk_UnRestrict.Text = "無限制"
        Me.cbk_UnRestrict.UseVisualStyleBackColor = True
        '
        'ckb_Synchronize
        '
        Me.ckb_Synchronize.AutoSize = True
        Me.ckb_Synchronize.Location = New System.Drawing.Point(84, 3)
        Me.ckb_Synchronize.Name = "ckb_Synchronize"
        Me.ckb_Synchronize.Size = New System.Drawing.Size(202, 20)
        Me.ckb_Synchronize.TabIndex = 12
        Me.ckb_Synchronize.Text = "必須和程式同步(BO同步)"
        Me.ckb_Synchronize.UseVisualStyleBackColor = True
        '
        'ckb_OtherRestrict
        '
        Me.ckb_OtherRestrict.AutoSize = True
        Me.ckb_OtherRestrict.Location = New System.Drawing.Point(292, 3)
        Me.ckb_OtherRestrict.Name = "ckb_OtherRestrict"
        Me.ckb_OtherRestrict.Size = New System.Drawing.Size(67, 20)
        Me.ckb_OtherRestrict.TabIndex = 13
        Me.ckb_OtherRestrict.Text = "其他  "
        Me.ckb_OtherRestrict.UseVisualStyleBackColor = True
        '
        'rtb_Script
        '
        Me.rtb_Script.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Script.Location = New System.Drawing.Point(3, 23)
        Me.rtb_Script.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rtb_Script.Name = "rtb_Script"
        Me.rtb_Script.Size = New System.Drawing.Size(1002, 188)
        Me.rtb_Script.TabIndex = 0
        Me.rtb_Script.uclMaxLength = 32767
        Me.rtb_Script.uclReadOnly = False
        Me.rtb_Script.uclWordWrap = False
        '
        'JobDBmodifyApplyUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 514)
        Me.CloseButton = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "JobDBmodifyApplyUI"
        Me.TabText = "資料庫異動申請"
        Me.Text = "資料庫異動申請"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.flp_ModifiedClassify.ResumeLayout(False)
        Me.flp_ModifiedClassify.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.flp_Restrict.ResumeLayout(False)
        Me.flp_Restrict.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txt_TableChName As Windows.Forms.TextBox
    Friend WithEvents txt_DBName As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txt_Index As Windows.Forms.TextBox
    Friend WithEvents txt_TableName As Windows.Forms.TextBox
    Friend WithEvents btn_Confirm As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rtb_Desc As Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents flp_ModifiedClassify As Windows.Forms.FlowLayoutPanel
    Friend WithEvents ckb_CreateTable As Windows.Forms.CheckBox
    Friend WithEvents ckb_ModifiedColumn As Windows.Forms.CheckBox
    Friend WithEvents ckb_ModifiedLenth As Windows.Forms.CheckBox
    Friend WithEvents ckb_CreateIndex As Windows.Forms.CheckBox
    Friend WithEvents ckb_ModifiedIndex As Windows.Forms.CheckBox
    Friend WithEvents ckb_Other As Windows.Forms.CheckBox
    Friend WithEvents ckb_ColumnTypeModified As Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents flp_Restrict As Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbk_UnRestrict As Windows.Forms.CheckBox
    Friend WithEvents ckb_Synchronize As Windows.Forms.CheckBox
    Friend WithEvents ckb_OtherRestrict As Windows.Forms.CheckBox
    Friend WithEvents rtb_Script As Syscom.Client.UCL.UCLRichTextBoxUC
End Class
