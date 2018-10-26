Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.BASE.HospConfigUtil
Imports System.Windows.Forms
Imports Syscom.Client.CMM

''' <summary>
''' 程式說明：常用醫令選取
''' 開發人員：Alan
''' 開發日期：2010.12.07
''' </summary>
Public Class UCLDiagFavorDialogUI

    'Select * From PUB_Disease_ICD10_Mapping
    'Insert into OMO_Favor_ICD Values ('1','603780','0012_常用診斷',1,'001.0','A00.0','AAA1',1,'Y','Y','Y','N','alan','2015-07-12','alan','2015-07-12')
    'Insert into OMO_Favor_ICD Values ('1','603780','0012_常用診斷',2,'001.1','A00.1','AAA2',2,'Y','Y','Y','N','alan','2015-07-12','alan','2015-07-12')
    'Insert into OMO_Favor_ICD Values ('1','603780','0012_常用診斷',3,'M86.121','A00.1','AAA2',3,'Y','Y','Y','N','alan','2015-07-12','alan','2015-07-12')


    Private OMOSourceUI As New Object      '呼叫來源UI

    Dim gblDoctorCode As String = ""       '醫師代碼
    Dim gblDeptCode As String = ""         '科別代碼
    Dim gblDiagType As String = ""         '診斷類別(1.出院診斷,2.手術診斷,3.意外診斷,4.腫瘤診斷)
    Dim gblSystemNo As String = ""         '系統別
    Dim gblSourceType As String = "O"      '門急住別 O:門診 E:急診 I:住院

    Dim gblFavorId As String = ""          '常用類別 1:個人常用 2:科常用 3:ICD9  4:ICD10 5:ICD10健保科
    Dim gblDebugFlag As Boolean = False    'DebugFlag
    Dim gblInitFlag As Boolean = True      '初始化註記
    Dim dsInit As New DataSet              '初始化資料
    Dim gblDiagFavorData As New DataSet    '常用診斷資料
    Dim ds As New DataSet                  '查詢的結果
    Dim gblFavorcolumnName() As String
    Dim gblTreSelIndex As Integer = -1     '選取樹狀節點索引

    Dim gblDataRows As Integer = 0         '資料筆數
    Dim gblShowRows As Integer = 0         '設定列數
    Dim gblShowColumns As Integer = 0      '計算行數
    Dim MedicineOrderName As ArrayList = New ArrayList
    Dim gblColumnWidth As String        'Grid各欄位寬度
    Dim dsOrderName As New DataSet         '藥品英文名稱
    Dim gblRowIndex As Integer = 0
    Dim gblColumnIndex As Integer = 0

    Dim gblOrderFavorData As New DataSet '設定已選取Grid
    Dim gblUISource As String = ""       '呼叫來源 EFS
    Public gblCheckDs As New DataSet     '回傳已選取DataSet

    Dim uclService As IUclServiceManager = UclServiceManager.getInstance

    Public Sub New()
        Try
            InitializeComponent()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal DiagType As String, ByVal SystemNo As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()

            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblDiagType = DiagType
            Me.gblSystemNo = SystemNo
            Me.gblSourceType = SourceType

            Me.OMOSourceUI = OMOSourceUI

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal DiagType As String, ByVal SystemNo As String, ByVal SourceType As String, ByVal UISource As String)
        Try
            InitializeComponent()

            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblDiagType = DiagType
            Me.gblSystemNo = SystemNo
            Me.gblSourceType = SourceType
            Me.gblUISource = UISource

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    Private Sub ShowForm()
        Try

            If gblDiagType = "" Then
                gblDebugFlag = True
                gblDoctorCode = "A11174"
                gblDeptCode = "03"
                gblDiagType = "1"
                'gblUISource = "EFS"
            End If

            '依傳入[診斷類別]參數值設定畫面Title
            Select Case gblDiagType
                Case "1"
                    Me.Text = "診斷查詢"

                Case "2"
                    Me.Text = "診斷查詢"
                    Me.rbt_FavorId3.Text = "PCS9"
                    Me.rbt_FavorId4.Text = "PCS10"
                    Me.rbt_FavorId5.Text = "PCS10健保科"

                Case "3"
                    Me.Text = "意外診斷查詢"

                Case "4"
                    Me.Text = "腫瘤診斷查詢"

            End Select

            '查詢初始化資料
            dsInit = uclService.queryOMODiagFavorInit(gblSourceType, gblDiagType, gblDoctorCode, gblDeptCode, txt_Diag_Code.Text.Trim, txt_Diag_Desc.Text.Trim)

            cbo_Dept.DataSource = dsInit.Tables("PUB_Department").Copy
            cbo_Dept.uclDisplayIndex = "0, 1"
            cbo_Dept.uclValueIndex = "0"

            cbo_Insu_Dept.DataSource = dsInit.Tables("PUB_Insu_Dept").Copy
            cbo_Insu_Dept.uclDisplayIndex = "0, 1"
            cbo_Insu_Dept.uclValueIndex = "0"

            '已選取診斷設定
            Dim hashTable As New Hashtable()
            If gblDiagType = "2" Then
                gblFavorcolumnName = New String() {"PCS9_Code", "PCS10_Code", "Is_Doubt", "PCS10_Desc", "Is_Chronic_Disease", "Is_Severe_Disease", "Infection_Type_Id"}
            Else
                gblFavorcolumnName = New String() {"ICD9_Code", "ICD10_Code", "Is_Doubt", "ICD10_Desc", "Is_Chronic_Disease", "Is_Severe_Disease", "Infection_Type_Id"}
            End If

            gblDiagFavorData = genDataSet(gblDiagFavorData, "Favor_Data", gblFavorcolumnName)

            Dim chk_cell As New CheckBoxCell
            hashTable.Add(5, chk_cell)
            hashTable.Add(6, chk_cell)

            hashTable.Add(-1, gblDiagFavorData)
            dgv_Selected.Initial(hashTable)
            dgv_Selected.uclVisibleColIndex = "0,1,2,3,4,5,6"
            If gblDiagType = "2" Then
                dgv_Selected.uclHeaderText = "PCS9,PCS10,疑,PCS10名稱,慢,重"
            Else
                dgv_Selected.uclHeaderText = "ICD9,ICD10,疑,ICD10名稱,慢,重"
            End If

            dgv_Selected.uclColumnWidth = "60,60,30,120,30,30"
            dgv_Selected.SetColReadOnly(5, True)
            dgv_Selected.SetColReadOnly(6, True)

            gblInitFlag = False

            Me.setCategory(dsInit.Tables("OMO_Favor_Diag_Doctor").Copy)

            If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                tre_Category.Nodes(0).BackColor = Color.DeepSkyBlue
                tre_Category.Nodes(0).ForeColor = Color.White
            End If

            If gblDiagType = "2" Then
                gblFavorcolumnName = New String() {"PCS9_Code", "PCS10_Code", "Is_Doubt", "PCS10_Desc", "Is_Chronic_Disease", "Is_Severe_Disease", "Infection_Type_Id"}
            Else
                gblFavorcolumnName = New String() {"ICD9_Code", "ICD10_Code", "Is_Doubt", "ICD10_Desc", "Is_Chronic_Disease", "Is_Severe_Disease", "Infection_Type_Id"}
            End If


            gblOrderFavorData = genDataSet(gblOrderFavorData, "Favor_Data", gblFavorcolumnName)

            Me.KeyPreview = True '啟用才能觸發快速鍵功能

            '依解析度等比例放大
            If UCLFormUtil.isResizeable Then
                Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                UCLFormUtil.ReDrawForm(Me)
                UCLFormUtil.ReSetLocToScreenCenter(Me)
            End If

            If gblOrderFavorData Is Nothing OrElse gblOrderFavorData.Tables Is Nothing OrElse gblOrderFavorData.Tables(0).Rows.Count = 0 Then
                'tre_Category.SelectedNode = tre_Category.Nodes(0)
            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    Private Sub UCLDiagFavorDialogUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ShowForm()
    End Sub

    Private Sub rbt_FavorId1_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_FavorId1.CheckedChanged
        
        gblTreSelIndex = -1

        If rbt_FavorId1.Checked Then
            cbo_Dept.SelectedValue = ""
            cbo_Dept.Enabled = False
            cbo_Insu_Dept.SelectedValue = ""
            cbo_Insu_Dept.Enabled = False
            cbo_ICD10_Dept.SelectedValue = ""
            cbo_ICD10_Dept.Enabled = False
            If gblInitFlag = False Then
                setCategory(dsInit.Tables("OMO_Favor_Diag_Doctor").Copy)
            End If

            If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                tre_Category.SelectedNode = tre_Category.Nodes(0)
            End If

            If rbt_FavorId1.Checked Then btn_Query_Click(sender, e)

        End If

    End Sub

    Private Sub rbt_FavorId2_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_FavorId2.CheckedChanged
        
        gblTreSelIndex = -1

        cbo_Dept.SelectedValue = gblDeptCode

        If rbt_FavorId2.Checked Then

            cbo_Dept.SelectedValue = ""
            cbo_Dept.Enabled = True
            cbo_Insu_Dept.SelectedValue = ""
            cbo_Insu_Dept.Enabled = False
            cbo_ICD10_Dept.SelectedValue = ""
            cbo_ICD10_Dept.Enabled = False

            setCategory(dsInit.Tables("OMO_Favor_Diag_Dept").Copy)

            If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                tre_Category.SelectedNode = tre_Category.Nodes(0)
            End If

            If rbt_FavorId2.Checked Then btn_Query_Click(sender, e)
        End If

    End Sub

    Private Sub rbt_FavorId3_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_FavorId3.CheckedChanged
        tre_Category.Nodes.Clear()
        dgv_FavorData.ClearDS()
        gblTreSelIndex = -1

        If rbt_FavorId3.Checked Then

            cbo_Dept.SelectedValue = ""
            cbo_Dept.Enabled = False
            cbo_Insu_Dept.SelectedValue = ""
            cbo_Insu_Dept.Enabled = False
            cbo_ICD10_Dept.SelectedValue = ""
            cbo_ICD10_Dept.Enabled = False

            If txt_Diag_Code.Text.Trim <> "" OrElse txt_Diag_Desc.Text.Trim <> "" Then
                Dim pvtDiagCategoryDs As New DataSet
                pvtDiagCategoryDs = uclService.queryDiagCategory(gblDiagType, txt_Diag_Code.Text.Trim, txt_Diag_Desc.Text.Trim)

                setCategory(pvtDiagCategoryDs.Tables(0).Copy)

                If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                    tre_Category.SelectedNode = tre_Category.Nodes(0)
                End If

                'If rbt_FavorId3.Checked Then btn_Query_Click(sender, e)
            Else
                'MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"診斷代碼或名稱至少需輸入1項"})
            End If

        End If

    End Sub

    Private Sub rbt_FavorId4_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_FavorId4.CheckedChanged
        
        gblTreSelIndex = -1

        dgv_FavorData.ClearDS()
        tre_Category.Nodes.Clear()

        If rbt_FavorId4.Checked Then
            cbo_Dept.SelectedValue = ""
            cbo_Dept.Enabled = False
            cbo_Insu_Dept.SelectedValue = ""
            cbo_Insu_Dept.Enabled = False
            cbo_ICD10_Dept.SelectedValue = ""
            cbo_ICD10_Dept.Enabled = False

            Dim pvtDiagCategoryDs As New DataSet
            pvtDiagCategoryDs = uclService.queryICD10Category("", gblDiagType, "N")

            setCategory(pvtDiagCategoryDs.Tables(0).Copy)

            If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                tre_Category.SelectedNode = tre_Category.Nodes(0)
            End If

            'If rbt_FavorId4.Checked Then btn_Query_Click(sender, e)

        End If

    End Sub

    Private Sub rbt_FavorId5_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_FavorId5.CheckedChanged

        gblTreSelIndex = -1

        dgv_FavorData.ClearDS()
        tre_Category.Nodes.Clear()

        If rbt_FavorId5.Checked Then
            cbo_Dept.SelectedValue = ""
            cbo_Dept.Enabled = False
            cbo_Insu_Dept.SelectedValue = ""
            cbo_Insu_Dept.Enabled = True
            cbo_ICD10_Dept.SelectedValue = ""
            cbo_ICD10_Dept.Enabled = False
        End If

    End Sub

    Private Sub cbo_Insu_Dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Insu_Dept.SelectedIndexChanged
        cbo_ICD10_Dept.SelectedValue = ""
        cbo_ICD10_Dept.Enabled = True
        Dim pvtSubInsuDeptDs As New DataSet
        pvtSubInsuDeptDs = uclService.queryPUBInsuSubDept(gblSourceType, gblDiagType, cbo_Insu_Dept.SelectedValue)

        cbo_ICD10_Dept.DataSource = pvtSubInsuDeptDs.Tables("PUB_Insu_Sub_Dept").Copy
        cbo_ICD10_Dept.uclDisplayIndex = "0, 1"
        cbo_ICD10_Dept.uclValueIndex = "0"

    End Sub

    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click

        ProcessQuery(False)

    End Sub

    Private Sub ProcessQuery(ByVal IsCellClick As Boolean)
        Dim pvtSelType As String = ""
        Dim pvtFavorId As String = ""
        Dim pvtDoctorDeptCode As String = ""
        Dim pvtFavorCategory As String = ""
        Dim pvtICDCode As String = ""
        Dim pvtICD10ChapterId As String = ""
        Dim pvtInsuDeptCode As String = ""
        Dim pvtInsuSubDeptCode As String = ""

        dgv_FavorData.ClearDS()

        If rbt_FavorId3.Checked AndAlso txt_Diag_Code.Text.Trim = "" AndAlso txt_Diag_Desc.Text.Trim = "" Then
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"診斷代碼或名稱至少需輸入一項!"}, "")
            txt_Diag_Code.Focus()
            Exit Sub

        End If

        '==================================

        'If tre_Category.Nodes.Count = 0 Then
       
        If rbt_FavorId3.Checked Then
            tre_Category.Nodes.Clear()
            dgv_FavorData.ClearDS()
            gblTreSelIndex = -1

            If tre_Category.Nodes.Count = 0 Then
                cbo_Dept.SelectedValue = ""
                cbo_Dept.Enabled = False
                cbo_Insu_Dept.SelectedValue = ""
                cbo_Insu_Dept.Enabled = False
                cbo_ICD10_Dept.SelectedValue = ""
                cbo_ICD10_Dept.Enabled = False
            End If
           
            If txt_Diag_Code.Text.Trim <> "" OrElse txt_Diag_Desc.Text.Trim <> "" Then
                Dim pvtDiagCategoryDs As New DataSet
                pvtDiagCategoryDs = uclService.queryDiagCategory(gblDiagType, txt_Diag_Code.Text.Trim, txt_Diag_Desc.Text.Trim)

                setCategory(pvtDiagCategoryDs.Tables(0).Copy)

                If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                    'tre_Category.SelectedNode = tre_Category.Nodes(0)
                End If

                'If rbt_FavorId3.Checked Then btn_Query_Click(sender, e)
            Else
                'MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"診斷代碼或名稱至少需輸入1項"})
            End If

        End If


        'End If
        '=================================


        If rbt_FavorId1.Checked Then
            pvtSelType = "1"
            pvtFavorId = "1"
            pvtDoctorDeptCode = gblDoctorCode


        ElseIf rbt_FavorId2.Checked Then
            pvtSelType = "2"
            pvtFavorId = "2"
            pvtDoctorDeptCode = cbo_Dept.SelectedValue


        ElseIf rbt_FavorId3.Checked Then
            pvtSelType = "3"

        ElseIf rbt_FavorId4.Checked Then
            pvtSelType = "4"

        ElseIf rbt_FavorId5.Checked Then
            pvtSelType = "5"
            pvtInsuDeptCode = cbo_Insu_Dept.SelectedValue
            pvtInsuSubDeptCode = cbo_ICD10_Dept.SelectedValue

        End If

        If gblTreSelIndex <> -1 Then
            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                If gblTreSelIndex = 0 AndAlso tre_Category.Nodes(gblTreSelIndex).Text = "全部" Then
                    pvtFavorCategory = ""
                Else
                    pvtFavorCategory = tre_Category.Nodes(gblTreSelIndex).Text
                End If

            ElseIf rbt_FavorId3.Checked Then
                pvtICDCode = tre_Category.Nodes(gblTreSelIndex).Tag.ToString

            ElseIf rbt_FavorId4.Checked Then
                pvtICD10ChapterId = tre_Category.Nodes(gblTreSelIndex).Tag.ToString

            ElseIf rbt_FavorId5.Checked Then
                pvtInsuDeptCode = cbo_Insu_Dept.SelectedValue
                pvtInsuSubDeptCode = cbo_ICD10_Dept.SelectedValue

            End If

        End If

        'If chk_NoCatag.Checked AndAlso txt_Diag_Code.Text = "" Then
        '    pvtICDCode = ""
        'End If

        If Not IsCellClick Then
            pvtICDCode = ""
        End If

        ds = uclService.queryICDDetail(pvtSelType, gblSourceType, gblDiagType, _
                                          pvtFavorId, pvtDoctorDeptCode, pvtFavorCategory, _
                                          pvtICDCode, pvtICD10ChapterId, pvtInsuDeptCode, pvtInsuSubDeptCode, _
                                          txt_Diag_Code.Text.Trim, txt_Diag_Desc.Text.Trim)

        If ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

            MedicineOrderName.Clear()

            gblDataRows = ds.Tables(0).Rows.Count

            'gblShowRows = 17    '設定列數
            'gblShowColumns = 0  '計算行數

            '設定列數
            If gblDataRows > 0 Then

                gblShowRows = gblDataRows / 2

                If gblDataRows Mod 2 = 1 Then
                    gblShowRows += 1
                End If

            End If

            gblShowColumns = 0 '計算行數

            For Each row As DataRow In ds.Tables(0).Rows
                MedicineOrderName.Add(row.Item("Diag_Name").ToString.Trim)
            Next

            If gblDataRows Mod gblShowRows <> 0 Then
                If gblDataRows < gblShowRows Then
                    gblShowColumns = 1
                Else
                    gblShowColumns = (gblDataRows \ gblShowRows) + 1
                End If
            Else
                gblShowColumns = gblDataRows \ gblShowRows
            End If

            gblColumnWidth = ResetGridData(gblShowColumns)

            '根據一列兩欄的排列方式給予 DataSet 值
            If ds.Tables.Count > 0 Then
                For i As Integer = 0 To gblDataRows - 1

                    dsOrderName.Tables("OrderName").Rows.Add()
                    For j = 0 To gblShowColumns - 1
                        dsOrderName.Tables("OrderName").Rows(i).Item(j * 2) = "N"
                        If (gblShowRows * j + i + 1) <= gblDataRows Then
                            dsOrderName.Tables("OrderName").Rows(i).Item(j * 2 + 1) = MedicineOrderName(i + gblShowRows * j)
                        End If
                    Next
                    If i = gblShowRows - 1 Then Exit For
                Next
            End If

            Dim hashTable As New Hashtable()
            hashTable.Add(-1, dsOrderName.Copy)

            Dim pvtNonVisible As String = ""

            For m = 0 To gblShowColumns - 1
                hashTable.Add(m * 2, New CheckBoxCell())
                If m <> 0 Then
                    pvtNonVisible &= "," & m * 2
                Else
                    pvtNonVisible = "0"
                End If
            Next

            dgv_FavorData.Initial(hashTable)
            dgv_FavorData.uclColumnWidth = gblColumnWidth
            dgv_FavorData.uclNonVisibleColIndex = pvtNonVisible

            dgv_FavorData.AllowUserToResizeRows = False
            dgv_FavorData.AllowDrop = False
            dgv_FavorData.ClearSelection()
            dgv_FavorData.Font = New Font("細明體", 9)
        End If
    End Sub

    Private Sub UCLDiagFavorDialogUI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1

                '查詢
                btn_Query_Click(sender, e)

        End Select
    End Sub

    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function

    Private Sub setCategory(ByVal dt As DataTable)

        tre_Category.Nodes.Clear()

        For i = 0 To dt.Rows.Count - 1

            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                If i <> 0 Then
                    tre_Category.Nodes.Add(dt.Rows(i - 1).Item("Favor_Category").ToString.Trim)

                Else
                    tre_Category.Nodes.Add("全部")

                End If

            Else
                tre_Category.Nodes.Add(dt.Rows(i).Item("Favor_Category").ToString.Trim)

                If rbt_FavorId3.Checked OrElse rbt_FavorId4.Checked Then
                    tre_Category.Nodes(i).Tag = dt.Rows(i).Item("ICD_Code").ToString.Trim
                End If

                If i = dt.Rows.Count - 1 Then Exit For

            End If

        Next

    End Sub

    Private Sub tre_Category_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tre_Category.AfterSelect

        If gblInitFlag = False Then
            gblTreSelIndex = e.Node.Index
            'btn_Query_Click(sender, e)
            ProcessQuery(True)
        End If

        For i = 0 To tre_Category.Nodes.Count - 1
            If tre_Category.Nodes(i).IsSelected Then
                tre_Category.Nodes(i).BackColor = Color.DeepSkyBlue
                tre_Category.Nodes(i).ForeColor = Color.White
            Else
                tre_Category.Nodes(i).BackColor = Color.White
                tre_Category.Nodes(i).ForeColor = Color.Black
            End If
        Next

    End Sub

    Private Function ResetGridData(ByVal inColumns As Integer) As String
        Dim outColumnWidth As String = ""
        Dim columnNameDB(inColumns * 2 - 1) As String

        For i = 0 To inColumns - 1
            columnNameDB(i * 2) = "Flag" & i
            columnNameDB(i * 2 + 1) = "OrderName" & i
            If outColumnWidth <> "" Then
                outColumnWidth &= ",20,325"
            Else
                outColumnWidth &= "20,325"
            End If

        Next

        If dsOrderName.Tables.Contains("OrderName") Then
            dsOrderName.Tables.Remove("OrderName")
        End If

        dsOrderName = genDataSet(dsOrderName, "OrderName", columnNameDB)

        Return outColumnWidth
    End Function

    Private Sub returnRowData(ByVal IsDBClick As Boolean)
        Try

            Dim pvtInsertIndex As Integer = 0
            pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count


            '新增資料列
            Dim row1 As DataRow
            row1 = gblOrderFavorData.Tables(0).NewRow

            If gblDiagType = "2" Then
                row1("PCS9_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD_Code").ToString.Trim
                row1("PCS10_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD10_Code").ToString.Trim
                row1("Is_Doubt") = ""
                row1("PCS10_Desc") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD10_Name").ToString.Trim
                row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Chronic_Disease").ToString.Trim
                row1("Is_Severe_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Severe_Disease").ToString.Trim
                row1("Infection_Type_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Infection_Type_Id").ToString.Trim
            Else
                row1("ICD9_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD_Code").ToString.Trim
                row1("ICD10_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD10_Code").ToString.Trim
                row1("Is_Doubt") = ""
                row1("ICD10_Desc") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("ICD10_Name").ToString.Trim
                row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Chronic_Disease").ToString.Trim
                row1("Is_Severe_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Severe_Disease").ToString.Trim
                row1("Infection_Type_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Infection_Type_Id").ToString.Trim
            End If


            dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
            dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)

            If dgv_Selected.Rows.Count > 0 Then
                dgv_Selected.Rows(pvtInsertIndex).Selected = True
                dgv_Selected.CurrentCell = dgv_Selected.Item(0, dgv_Selected.Rows.Count - 1)
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        If gblUISource = "EFS" Then
            gblCheckDs = dgv_Selected.GetDBDS

        Else
            Dim pvtCount As Integer = dgv_Selected.GetDBDS.Tables(0).Rows.Count - 1
            For i = 0 To pvtCount
                If dgv_Selected.Rows(i).Cells.Item(0).Value IsNot Nothing AndAlso _
                   dgv_Selected.Rows(i).Cells.Item(0).Value Then
                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(i)
                    dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(i)
                    i -= 1
                    pvtCount -= 1
                    If i = pvtCount Then Exit For
                End If
                If i = pvtCount Then Exit For
            Next

            Dim pvtRows As Integer
            pvtRows = dgv_Selected.GetDBDS.Tables(0).Rows.Count

            If gblDiagType = "2" Then
                dgv_Selected.GetDBDS.Tables(0).Columns(0).ColumnName = "ICD9_Code"
                dgv_Selected.GetDBDS.Tables(0).Columns(1).ColumnName = "ICD10_Code"
                dgv_Selected.GetDBDS.Tables(0).Columns(3).ColumnName = "ICD10_Desc"
            End If

            For m = 0 To pvtRows - 1
                If gblDebugFlag Then
                    If gblDiagType = "2" Then
                        Console.WriteLine("PCS10_Code=>" & dgv_Selected.GetDBDS.Tables(0).Rows(m).Item("PCS10_Code").ToString.Trim & "---" & dgv_Selected.GetDBDS.Tables(0).Rows(m).Item("PCS9_Code").ToString.Trim)
                    Else
                        Console.WriteLine("ICD10_Code=>" & dgv_Selected.GetDBDS.Tables(0).Rows(m).Item("ICD10_Code").ToString.Trim & "---" & dgv_Selected.GetDBDS.Tables(0).Rows(m).Item("ICD9_Code").ToString.Trim)
                    End If

                Else
                    OMOSourceUI.InsertFavorOrder("1", dgv_Selected.GetDBDS)
                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(0)
                End If

            Next

        End If

        Me.Close()

    End Sub

    Private Sub txt_Diag_Code_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Diag_Code.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btn_Query_Click(sender, e)
        End Select

    End Sub

    Private Sub txt_Diag_Desc_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Diag_Desc.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btn_Query_Click(sender, e)
        End Select
    End Sub

    Private Sub dgv_FavorData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_FavorData.CellClick
        'gblDBClickFlag = True
        gblRowIndex = e.RowIndex
        gblColumnIndex = e.ColumnIndex \ 2

        returnRowData(True)

        dgv_Selected.SetColReadOnly(5, True)
        dgv_Selected.SetColReadOnly(6, True)
    End Sub
End Class