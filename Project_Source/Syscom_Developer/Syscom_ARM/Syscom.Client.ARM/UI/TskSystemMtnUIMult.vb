'/*
'*****************************************************************************
'*
'*    Page/Class Name:  作業維護(多筆)
'*              Title:	TskSystemMtnUIMult
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich
'*        Create Date:	2015-03-03
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.ServiceModel
Imports System.Configuration
Imports System.Drawing
Imports System.Windows.Forms

Public Class TskSystemMtnUIMult
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '取得維護表格名稱
    Private DBName As String = ArmTskSystemDataTableFactory.tableName

    'Grid使用的標題
    Private columnNameGrid() As String = {"系統代碼", "系統名稱", "子系統代碼", "子系統名稱", "作業代碼", "作業名稱", "排列順序", "是否有效", "是否有效中文", "建立者", "建立時間", "修改者", "修改時間"}

    '設定Grid欄位寬度
    Private columnWidth As String = "100,150,100,150,100,150,100,100,100,100,150,100,150"

    '設定Grid顯示欄位
    Private columnVisible As String = "1,2,3,4,5,6,7,8,10,11,12,13"

    '設定可編輯的欄位位置索引
    Private columnEditIndex() As String = {"5", "6", "7", "8"}

    '設定必填欄位位置索引
    Private columnNotNullIndex() As String = {"5", "6", "7", "8"}

    '設定PKey欄位位置索引
    Private columnPKeyIndex() As String = {"1"}

    '設定建立時間與修改時間的欄位索引
    Private gblCreateTimeIdx As Integer = 11
    Private gblModifiedTimeIdx As Integer = 13

    '是否的 Code Type 代號
    Private CodeTypeDC As String = "9000"

    '取得維護表字段名
    Private columnNameDB() As String = ArmTskSystemDataTableFactory.columnsName

    '取得維護表字段長度
    Private columnsLength() As Integer = ArmTskSystemDataTableFactory.columnsLength

    '系統代碼下拉選單
    Private dsAppSystemCbo As DataSet
    Private dsSubSystemCbo As DataSet

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        TextBox
        DataRow
        Footer
        Separator
        Header
        Pager
    End Enum

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Private Cmm As ICmmServiceManager

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Private WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Function SaveData() As Boolean
        Dim dsResult As New DataSet
        Try
            Dim returnBoolean As Boolean = True

            '欄位檢核
            If checkFieldIsNull() Then

                '取得存檔資料
                Dim dsSave As New DataSet
                dsSave = getCheckData()

                '執行存檔
                If dsSave IsNot Nothing AndAlso dsSave.Tables IsNot Nothing AndAlso dsSave.Tables(0).Rows.Count > 0 Then

                    Dim count As Integer = 0
                    For Each row As DataRow In dsSave.Tables(0).Rows
                        count += ARM.TskDelete(row("org_tsk_task_no"))
                    Next
                    count += ARM.TskInsert(dsSave)

                    If count = 0 Then
                        '若失敗則將畫面上資料顏色、訊息做設定
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"存檔失敗，請確認!"})
                        returnBoolean = False
                    Else
                        '若成功則將畫面資料修改
                        Dim dsDB As DataSet = ARM.TskGetAllSystem(cbo_AppSystem.SelectedValue, cbo_SubSystem.SelectedValue, "", "", "", "")
                        ShowDgv(dsDB)
                    End If
                Else
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請勾選要存檔的資料!"})
                    returnBoolean = False
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"欄位不可為空白!"})
                returnBoolean = False
            End If

            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try
    End Function

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Function DeleteData() As Boolean
        Try
            Dim dsResult As New DataSet
            Dim returnBoolean As Boolean = True

            '取得刪除資料
            Dim dsDelete As New DataSet
            dsDelete = getCheckData()

            If dsDelete IsNot Nothing AndAlso dsDelete.Tables IsNot Nothing AndAlso dsDelete.Tables(0).Rows.Count > 0 Then

                If (MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {}) = Windows.Forms.DialogResult.Yes) Then

                    '執行刪除
                    Dim count As Integer = 0
                    For Each row As DataRow In dsDelete.Tables(0).Rows
                        count += ARM.TskDelete(row("tsk_task_no"))
                    Next

                    If count = 0 Then
                        '若失敗則將畫面上資料顏色、訊息做設定
                        returnBoolean = False
                    Else
                        '若成功則將畫面資料移除
                        Dim dsDB As DataSet = ARM.TskGetAllSystem(cbo_AppSystem.SelectedValue, cbo_SubSystem.SelectedValue, "", "", "", "")
                        ShowDgv(dsDB)
                        'For i As Integer = dgv_Data.Rows.Count - 1 To 0 Step -1
                        '    If dgv_Data.Rows(i).Cells(0).Value Then
                        '        dgv_Data.GetDBDS.Tables(0).Rows.RemoveAt(i)
                        '        dgv_Data.GetGridDS.Tables(0).Rows.RemoveAt(i)
                        '    End If
                        'Next
                    End If
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請勾選要刪除的資料!"})
                returnBoolean = False
            End If

            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        End Try
    End Function

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Function QueryData() As Boolean
        Try
            Dim returnBoolean As Boolean = True
            Dim dsDB As DataSet = ARM.TskGetAllSystem(cbo_AppSystem.SelectedValue, cbo_SubSystem.SelectedValue, "", "", "", "")
            ShowDgv(dsDB)
            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try
    End Function

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Function ClearData() As Boolean
        Try
            Dim returnBoolean As Boolean = True
            cbo_AppSystem.SelectedValue = ""
            cbo_SubSystem.SelectedValue = ""
            ShowDgv(New DataSet)
            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try
    End Function

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Public Sub ShownMe() Handles Me.Shown
        Try
            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            dsAppSystemCbo = ARM.AppGetAppSystemCombobox
            If dsAppSystemCbo.Tables.Count > 0 Then
                dsAppSystemCbo.Tables(0).PrimaryKey = New DataColumn() {dsAppSystemCbo.Tables(0).Columns(0)}
            End If
            cbo_AppSystem.DataSource = dsAppSystemCbo.Tables(0).Copy
            cbo_AppSystem.uclDisplayIndex = "2"
            cbo_AppSystem.uclValueIndex = "0"

            dsSubSystemCbo = ARM.SubGetSubSystemCombobox(cbo_AppSystem.SelectedValue)
            If dsSubSystemCbo.Tables.Count > 0 Then
                dsSubSystemCbo.Tables(0).PrimaryKey = New DataColumn() {dsSubSystemCbo.Tables(0).Columns(0)}
            End If
            cbo_SubSystem.DataSource = dsSubSystemCbo.Tables(0).Copy
            cbo_SubSystem.uclDisplayIndex = "2"
            cbo_SubSystem.uclValueIndex = "0"

            '初始化 - DataGridView
            ShowDgv(New DataSet)

            Me.KeyPreview = True
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub LoadServiceManager()
        Try
            Cmm = CmmServiceManager.getInstance
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try
    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-11-4</remarks>
    Private Sub LoadEventManager()
        Try
            eventMgr = EventManager.getInstance()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try
    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            eventMgr = Nothing
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try
    End Sub

#End Region

#Region "     初始化 - DataGridView "

    ''' <summary>
    ''' 初始化 - DataGridView
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Private Sub ShowDgv(ByVal inDsData As DataSet)
        Try
            '構建空的Grid
            Dim htGrid As New Hashtable()
            Dim dsData As New DataSet
            Dim txt_cell1 As New TextBoxCell()
            Dim txt_cell2 As New TextBoxCell()
            Dim txt_cell3 As New TextBoxCell()
            Dim cbo_cell1 As New ComboBoxCell()
            Dim cbo_cell2 As New ComboBoxCell()
            Dim cbo_cell3 As New ComboBoxCell()
            Dim cbo_cell4 As New ComboBoxCell()
            Dim cbo_cell5 As New ComboBoxCell()
            txt_cell1.MaxLength = 10
            txt_cell2.MaxLength = 40
            txt_cell3.MaxLength = 2
            txt_cell3.uclTextType = TextBoxCell.uclTextTypeData.Integer_Type

            cbo_cell1.Ds = dsAppSystemCbo.Copy
            cbo_cell1.DisplayIndex = "0"
            cbo_cell1.ValueIndex = "0"

            cbo_cell2.Ds = dsAppSystemCbo.Copy
            cbo_cell2.DisplayIndex = "1"
            cbo_cell2.ValueIndex = "0"

            cbo_cell3.Ds = dsSubSystemCbo.Copy
            cbo_cell3.DisplayIndex = "0"
            cbo_cell3.ValueIndex = "0"

            cbo_cell4.Ds = dsSubSystemCbo.Copy
            cbo_cell4.DisplayIndex = "1"
            cbo_cell4.ValueIndex = "0"

            cbo_cell5.Ds = Cmm.CMMSysCodeBSSysCodeQuery(CodeTypeDC)
            cbo_cell5.DisplayIndex = "1"
            cbo_cell5.ValueIndex = "0"

            If inDsData IsNot Nothing AndAlso inDsData.Tables.Count > 0 Then
                ' 修改查詢結果中欄位名稱
                For i = 0 To inDsData.Tables(0).Columns.Count - 1
                    inDsData.Tables(0).Columns(i).ColumnName = columnNameGrid(i)
                Next
                dsData = inDsData.Copy
            Else
                dsData = genDS(DataSet_Type.Grid, DBName)
            End If

            '增加原始系統代碼欄位
            If Not dsData.Tables(0).Columns.Contains("原作業代碼") Then
                dsData.Tables(0).Columns.Add("原作業代碼")
            End If

            For Each row As DataRow In dsData.Tables(0).Rows
                row("原作業代碼") = row("作業代碼")
            Next

            dsData.Tables(0).PrimaryKey = Nothing
            htGrid.Add(-1, dsData)
            htGrid.Add(1, cbo_cell1)
            htGrid.Add(2, cbo_cell2)
            htGrid.Add(3, cbo_cell3)
            htGrid.Add(4, cbo_cell4)
            htGrid.Add(5, txt_cell1)
            htGrid.Add(6, txt_cell2)
            htGrid.Add(7, txt_cell3)
            htGrid.Add(8, cbo_cell5)

            dgv_Data.Initial(htGrid)
            dgv_Data.uclColumnWidth = columnWidth
            dgv_Data.uclVisibleColIndex = columnVisible
            dgv_Data.AddNewRow()

            '設定固定欄位，不隨著水平捲軸移動
            dgv_Data.Columns(1).Frozen = True

            dgv_Data.Refresh()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#End Region

#Region "     產生一個DataSet並包含一個空的Table 給Grid用 或 DB用 "

    ''' <summary>
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer, ByVal table As String) As DataSet
        Try
            Dim dsTemp As New DataSet
            Select Case type
                Case DataSet_Type.Grid
                    '給Grid用Table
                    dsTemp.Tables.Add(table)
                    For i As Integer = 0 To columnNameGrid.Length - 1
                        dsTemp.Tables(table).Columns.Add(columnNameGrid(i))
                    Next
                Case DataSet_Type.DB
                    '給DB用Table
                    dsTemp.Tables.Add(table)
                    For i As Integer = 0 To columnNameDB.Length - 1
                        dsTemp.Tables(table).Columns.Add(columnNameDB(i))
                    Next
            End Select
            Return dsTemp
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Function

#End Region

#End Region

#Region "     必填檢查 "

    ''' <summary>
    ''' 檢查欄位是否為空白
    ''' </summary>
    ''' <remarks></remarks>
    Private Function checkFieldIsNull() As Boolean
        Try
            Dim pvtCheckFlag As Boolean = True
            Dim pvtErrorMsg As String = ""

            '-------------------------------------------------------------
            '僅需針對[選]有打勾的欄位做檢核
            '-------------------------------------------------------------
            For i = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1

                pvtErrorMsg = ""

                If dgv_Data.Rows(i).Cells(0).Value Then

                    For j = 0 To columnNotNullIndex.Length - 1

                        If dgv_Data.Rows(i).Cells(CInt(columnNotNullIndex(j))).Value.ToString.Trim = "" Then
                            If pvtErrorMsg <> "" Then
                                pvtErrorMsg &= "," & columnNameGrid(CInt(columnNotNullIndex(j)) - 1)
                                dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.Pink)
                            Else
                                pvtErrorMsg = columnNameGrid(CInt(columnNotNullIndex(j)) - 1)
                                dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.Pink)
                            End If

                            pvtCheckFlag = False

                        Else
                            Me.dgv_Data.SetRowColor(i, Color.White)
                            dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.White)
                        End If

                    Next

                    If pvtErrorMsg <> "" Then
                        pvtErrorMsg &= "欄位值不可為空白!"
                    End If

                    'dgv_Data.Rows(i).Cells("ErrMsg").Value = pvtErrorMsg

                    For p = 0 To columnNameGrid.Count - 1
                        dgv_Data.Rows(i).Cells(p).ToolTipText = pvtErrorMsg
                    Next

                End If

            Next
            '-------------------------------------------------------------

            Return pvtCheckFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Function

#End Region

#Region "     事件集合 "

    ''' <summary>
    ''' CellEnter 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_Data_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellEnter
        '根據row i  col 0 的值來取得新的dataset 我們就叫做newDS
        '然後動態設定給 combox cell  column 1的位置
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            Dim newDS As DataSet = ARM.SubGetSubSystemCombobox(dgv_Data.Rows(e.RowIndex).Cells(1).Value)
            dgv_Data.SetComboBoxCellDataSet(newDS, e.RowIndex, 3)
            dgv_Data.SetComboBoxCellDataSet(newDS, e.RowIndex, 4)
        End If
    End Sub

    ''' <summary>
    ''' CellValueChanged 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_Data_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellValueChanged
        Try
            Dim pvtRowIndex As Integer = e.RowIndex

            '-------------------------------------------------------------
            '若離開的Cell為最後一列，且第1個Cell有值，則自動新增空白列
            '-------------------------------------------------------------
            If e.ColumnIndex = 1 AndAlso _
               pvtRowIndex = dgv_Data.Rows.Count - 1 AndAlso _
               dgv_Data.Rows(pvtRowIndex).Cells(1).Value.ToString.Trim <> "" Then

                '新增空白列
                dgv_Data.AddNewRow()
            End If
            '-------------------------------------------------------------
            '若離開的Cell為前兩欄，則自動填入資料
            '-------------------------------------------------------------
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                If dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1).ToString.Trim <> "" Then
                    Dim row As DataRow = dsAppSystemCbo.Tables(0).Rows.Find(dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1))
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0) = row(0)
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1) = row(0)
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0) = row(0)
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(1) = row(1)
                Else
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0) = ""
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1) = ""
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0) = ""
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(1) = ""
                End If

                '清除子系統資料
                dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(2) = ""
                dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(3) = ""
                dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(2) = ""
                dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(3) = ""
            ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                If dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1).ToString.Trim <> "" Then
                    Dim dsSubTemp = ARM.SubGetSubSystemCombobox(dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim)
                    If dsSubTemp.Tables.Count > 0 Then
                        dsSubTemp.Tables(0).PrimaryKey = New DataColumn() {dsSubTemp.Tables(0).Columns(0)}
                    End If
                    If dsSubTemp.Tables(0).Rows.Contains(dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1)) Then
                        Dim row As DataRow = dsSubTemp.Tables(0).Rows.Find(dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex - 1))
                        dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(2) = row(0)
                        dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(3) = row(0)
                        dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(2) = row(0)
                        dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(3) = row(1)
                    End If
                Else
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(2) = ""
                    dgv_Data.GetDBDS.Tables(0).Rows(e.RowIndex).Item(3) = ""
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(2) = ""
                    dgv_Data.GetGridDS.Tables(0).Rows(e.RowIndex).Item(3) = ""
                End If
            End If

            Me.dgv_Data.Refresh()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 選擇系統代碼觸發事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_AppSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_AppSystem.SelectedIndexChanged
        Try
            dsSubSystemCbo = ARM.SubGetSubSystemCombobox(cbo_AppSystem.SelectedValue)
            If dsSubSystemCbo.Tables.Count > 0 Then
                dsSubSystemCbo.Tables(0).PrimaryKey = New DataColumn() {dsSubSystemCbo.Tables(0).Columns(0)}
            End If
            cbo_SubSystem.DataSource = dsSubSystemCbo.Tables(0).Copy
            cbo_SubSystem.uclDisplayIndex = "2"
            cbo_SubSystem.uclValueIndex = "0"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "     取得勾選的Dataset資料 "

    Private Function getCheckData() As DataSet
        Try
            Dim pvtSysTime As String = Now.ToString("yyyy/MM/dd HH:mm:ss")
            Dim dsCheckData As DataSet = genDS(DataSet_Type.DB, DBName)
            dsCheckData.Tables(0).Columns.Add("org_tsk_task_no")
            Dim drCheckData As DataRow = Nothing

            '將勾選資料加入至DataSet
            For i = 0 To dgv_Data.Rows.Count - 1
                With dgv_Data.GetDBDS.Tables(0).Rows(i)
                    If dgv_Data.Rows(i).Cells(0).Value Then
                        drCheckData = dsCheckData.Tables(0).NewRow()
                        drCheckData("tsk_sub_system_no") = .Item("子系統代碼").ToString.Trim
                        drCheckData("tsk_task_no") = .Item("作業代碼").ToString.Trim
                        drCheckData("tsk_task_name") = .Item("作業名稱").ToString.Trim
                        drCheckData("tsk_display_order") = .Item("排列順序").ToString.Trim
                        drCheckData("tsk_task_flag_no") = .Item("是否有效").ToString.Trim
                        drCheckData("tsk_creator_no") = CurrentUserID
                        drCheckData("tsk_create_datetime") = pvtSysTime
                        drCheckData("tsk_operator_no") = CurrentUserID
                        drCheckData("tsk_update_datetime") = pvtSysTime
                        drCheckData("org_tsk_task_no") = .Item("原作業代碼").ToString.Trim
                        dsCheckData.Tables(0).Rows.Add(drCheckData)
                    End If
                End With
            Next

            Return dsCheckData
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "     清除功能 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     儲存 鎖定功能 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        Try
            '鎖定螢幕
            Lock(Me)
            '清除左下方訊息欄
            ClearInfoMsg()
            If (SaveData()) Then
                '左下方顯示 儲存 成功
                ShowInfoMsg("CMMCMMB301", "儲存")
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"儲存 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     刪除 鎖定功能 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        Try
            '鎖定螢幕
            Lock(Me)
            '清除左下方訊息欄
            ClearInfoMsg()
            If (DeleteData()) Then
                '左下方顯示 刪除 成功
                ShowInfoMsg("CMMCMMB301", "刪除")
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        Try
            '鎖定螢幕
            Lock(Me)
            '清除左下方訊息欄
            ClearInfoMsg()
            If (QueryData()) Then
                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "查詢")
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     清除 鎖定功能 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        Try
            '鎖定螢幕
            Lock(Me)
            '清除左下方訊息欄
            ClearInfoMsg()
            If (ClearData()) Then
                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "清除")
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region

#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            '鎖定螢幕
            Lock(Me)
            Select Case e.KeyCode
                Case Keys.F12
                    '如果按下Shift，則為刪除
                    If e.Shift = True Then
                        '刪除
                        If (btn_Delete.Enabled) Then
                            btn_Delete.PerformClick()
                        End If
                        '如果未按下Shift，則為新增/儲存
                    Else
                        '儲存
                        If (btn_Save.Enabled) Then
                            btn_Save.PerformClick()
                        End If
                    End If
                Case Keys.F1
                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
                    End If
                Case Keys.F5
                    '清除
                    If btn_Clear.Enabled Then
                        btn_Clear.PerformClick()
                    End If
                    'Case Keys.Enter
                    'Me.ProcessTabKey(True)
            End Select
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region

#End Region

#End Region

End Class

