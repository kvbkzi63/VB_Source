
'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入元件
'*              Title:	PUBLabIndication04UI
'*        Description:	資訊室人員設定急診值班別之起迄時間
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Margaret Tsai
'*        Create Date:	2016-07-18
'*      Last Modifier:	Margaret Tsai
'*   Last Modify Date:	2016-07-18
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.ServiceModel
Imports System.Configuration
Imports Syscom.Client.Servicefactory


Public Class PUBLabIndication04
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "
    Dim gb_checked_count As Integer = Nothing   '勾選者 項目數

    '提供其他UI讀取XML檔案
    Public gblXmlData As String = ""
    Public gblArrayData(2) As String


#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    '回傳選定資料
    Public dsReturn As DataSet = Nothing

    '取得維護表格名稱
    Dim DBName As String = "PUBLabIndication04Ou"

    'Grid使用的標題
    Dim columnNameGrid() As String = "PKey,選1,過敏原1,選2,過敏原2,選3,過敏原3".Split(",")

    '設定Grid欄位寬度
    Dim columnWidth As String = "0,50,180,50,180,50,180"

    '設定Grid顯示欄位
    Dim columnVisible As String = "1,2,3,4,5,6"

    '設定可編輯的欄位位置索引
    Dim columnEditIndex() As String = {"1", "3", "5"}

    '設定必填欄位位置索引
    Dim columnNotNullIndex() As String = {"0"} ' {"1", "2", "3", "4", "5", "6"}

    '設定PKey欄位位置索引
    Dim columnPKeyIndex() As String = {"0"}

    '取得維護表字段名
    Dim columnNameDB() As String = "PKey, check1, Code_En_Name1, check2, Code_En_Name2, check3, Code_En_Name3".Split(",")

    '取得維護表字段長度
    Dim columnsLength() As Integer = {20, 50, 180, 50, 180, 50, 180}

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
    Dim PUB As IPubServiceManager

#End Region

#Region "     使用的Event宣告 "


    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region


#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     儲存 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Function SaveData() As Boolean

        Dim dsResult As New DataSet

        Try

            Dim returnBoolean As Boolean = True

            '顯示 “最多選取7項過敏原，請確認!”
            'If gb_checked_count >= 8 Then
            '    MessageBox.Show("最多選取7項過敏原，請確認!")
            '    'MessageHandling.ShowWarnMsg("CMMCMMB315", New String() {"最多選取7項過敏原，請確認!"})
            '    Return returnBoolean
            'Else
            '檢核通過開始抓值
            'dsReturn = getCheckDataByDataSet()
            'gblXmlData = XMLUtil.DataSetToXML(dsReturn)

            gblArrayData = getCheckDataByArray()

            'End If

            Return True

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region


#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

    'Public Sub initialComboBox()
    '    '執行查詢
    '    dsDept_Code = Ppf.PUBLabIndication04QueryDepartmentCbo()

    '    Try
    '        If dsDept_Code.Tables.Count > 0 Then
    '            If dsDept_Code.Tables(0).Rows.Count = 0 Then
    '                '查無資料
    '                MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
    '            Else
    '                '初始化使用單位
    '                Me.cmbDept_Code.DataSource = dsDept_Code.Tables(0)
    '                Me.cmbDept_Code.uclDisplayIndex = "0,1"
    '                Me.cmbDept_Code.uclValueIndex = "0"
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Public Function initialGridComboBox(ByVal iTypeId As String) As DataSet
    '    Dim dsDB As DataSet
    '    '執行查詢
    '    dsDB = Ppf.PUBLabIndication04QueryPpf_codeCbo(iTypeId.Trim)

    '    Try
    '        If dsDB.Tables.Count > 0 Then
    '            If dsDB.Tables(PpfCodeDataTableFactory.tableName).Rows.Count = 0 Then
    '                '查無資料
    '                MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return dsDB
    'End Function
    'Public Function initialGridHHMM() As DataSet
    '    Try
    '        Dim dsReturn As New DataSet
    '        Dim str() As String = "0000,0100,0200,0300,0400,0500,0600,0700,0800,0900,1000,1100,1200,1300,1400,1500,1600,1700,1800,1900,2000,2100,2200,2300".Split(",")

    '        Dim tbl As New DataTable
    '        tbl.Columns.Add("Code", GetType(String))
    '        tbl.Columns.Add("Name", GetType(String))

    '        For i = LBound(str) To UBound(str)
    '            tbl.Rows.Add(str(i), str(i))
    '        Next

    '        dsReturn.Tables.Add(tbl)
    '        Return dsReturn
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try
            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            '初始化 - DataGridView
            Dim inDsData As New DataSet
            inDsData = PUB.PUBLabIndication04QureyPUBLabIndication04
            ShowDgv(inDsData)

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

            PUB = PubServiceManager.getInstance()

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
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
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
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
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

    ''' <summary>ShowDgv
    ''' 初始化 - DataGridView
    ''' </summary>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Sub ShowDgv(ByVal inDsData As DataSet)

        Try
            '構建空的Grid
            Dim htGrid As New Hashtable()
            Dim dsData As New DataSet

            Dim txt_cell1 As New TextBoxCell()
            txt_cell1.MaxLength = 20

            Dim chk_cell1 As New CheckBoxCell()
            Dim txt_cell2 As New TextBoxCell()
            txt_cell2.MaxLength = 150

            Dim chk_cell2 As New CheckBoxCell()
            Dim txt_cell3 As New TextBoxCell()
            txt_cell3.MaxLength = 150

            Dim chk_cell3 As New CheckBoxCell()
            Dim txt_cell4 As New TextBoxCell()
            txt_cell4.MaxLength = 150

            htGrid.Add(0, txt_cell1)
            htGrid.Add(1, chk_cell1)
            htGrid.Add(2, txt_cell2)
            htGrid.Add(3, chk_cell2)
            htGrid.Add(4, txt_cell3)
            htGrid.Add(5, chk_cell3)
            htGrid.Add(6, txt_cell4)

            If inDsData IsNot Nothing AndAlso inDsData.Tables.Count > 0 Then

                '' 修改查詢結果中欄位名稱
                'For i = 0 To inDsData.Tables(0).Columns.Count - 1
                '    inDsData.Tables(0).Columns(i).ColumnName = columnNameGrid(i)
                'Next

                dsData = inDsData.Copy

            Else
                dsData = genDS(DataSet_Type.Grid, DBName)
            End If
            dsData.Tables(0).PrimaryKey = Nothing
            htGrid.Add(-1, dsData)
            dgv_Data.Initial(htGrid)

            'Grid內容設定
            setGridData()

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})

        End Try

    End Sub

    ''' <summary>
    ''' Grid 綁值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGridData()

        '設定攔寬
        dgv_Data.uclColumnWidth = columnWidth

        '設定隱藏欄位
        dgv_Data.uclVisibleColIndex = columnVisible

        dgv_Data.uclHeaderText = "PKey,選,過敏原,選,過敏原,選,過敏原"

        '[選]欄，預設全選
        For i As Integer = 0 To dgv_Data.Rows.Count - 1
            dgv_Data.Rows(i).Cells(0).Value = True
            'Me.dgv_Data.SetRowReadOnly(i, True)
            'Me.dgv_Data.SetCellReadOnly(0, i, False)
        Next
        '隱藏[選]欄
        dgv_Data.Columns(0).Visible = False

        '預設不能編輯的欄位
        For i As Integer = 0 To dgv_Data.Rows.Count - 1
            For j As Integer = 0 To dgv_Data.Columns.Count - 1
                Select Case j
                    Case "1", "3", "5"
                        dgv_Data.SetCellReadOnly(j, i, False)
                    Case "2", "4", "6"
                        dgv_Data.SetCellReadOnly(j, i, True)
                End Select
            Next
        Next

        '設定固定欄位，不隨著水平捲軸移動
        dgv_Data.Columns(2).Frozen = True

        dgv_Data.Refresh()
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
    End Function
#End Region

#End Region

#Region "     必填檢查 "

#End Region

#Region "     事件集合 "

#Region "Grid相關處理"

    ''' <summary>
    ''' CellValueChanged 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_Data_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellValueChanged
        Dim pvtRowIndex As Integer = e.RowIndex

        '-------------------------------------------------------------
        '"PK,選1,過敏原1,選2,過敏原2,選3,過敏原3"====>若勾選"選1,選2,選3"，則判斷小於8項    
        '-------------------------------------------------------------
        Select Case e.ColumnIndex
            Case 1, 3, 5
                If dgv_Data.Rows(pvtRowIndex).Cells(e.ColumnIndex).Value Then '加入 勾選者清單
                    gb_checked_count = gb_checked_count + 1
                    '顯示 “最多選取7項過敏原，請確認!”
                    'If gb_checked_count >= 8 Then

                    '    dgv_Data.Rows(pvtRowIndex).Cells(e.ColumnIndex).Value = False
                    '    dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item(e.ColumnIndex) = "N"
                    '    dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item(e.ColumnIndex) = "N"
                    '    MessageBox.Show("最多選取7項過敏原，請確認!")
                    '    'MessageHandling.ShowWarnMsg("CMMCMMB315", New String() {"最多選取7項過敏原，請確認!"})
                    '    Return
                    'End If
                Else
                    If gb_checked_count > 0 Then
                        gb_checked_count = gb_checked_count - 1
                    End If
                End If

        End Select
    End Sub
#End Region

#End Region

#Region "     取得勾選的Dataset資料 "

    Private Function getCheckData() As DataSet

        Dim dsCheckData As New DataSet
        'Dataset:建第1個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(0).TableName = "特殊屬性表單"
        dsCheckData.Tables(0).Columns.Add("特殊屬性表單代碼")
        dsCheckData.Tables(0).Columns.Add("特殊屬性表單名稱")
        '存值入各欄位
        Dim rowDt1 As DataRow = dsCheckData.Tables(0).NewRow
        rowDt1.Item("特殊屬性表單代碼") = "PUBLabIndication04"
        rowDt1.Item("特殊屬性表單名稱") = "建生特異性過敏原檢查單"
        dsCheckData.Tables(0).Rows.Add(rowDt1)

        'Dataset:建第2個table
        '取 勾選者清單
        Dim strSelectItem As String = Nothing
        Dim j, k As Integer
        For j = 0 To dgv_Data.Rows.Count - 1
            k = 1
            While k <= 6 ' PKey,選1,過敏原1,選2,過敏原2,選3,過敏原3
                If dgv_Data.Rows(j).Cells(k).Value Then
                    If strSelectItem Is Nothing Then
                        strSelectItem = dgv_Data.Rows(j).Cells(k + 1).Value.ToString.Trim
                    Else
                        strSelectItem = strSelectItem & "$" & dgv_Data.Rows(j).Cells(k + 1).Value.ToString.Trim
                    End If
                End If
                k = k + 2
            End While
        Next

        Dim arySelectItem() As String = strSelectItem.Split("$")
        dsCheckData.Tables.Add()
        dsCheckData.Tables(1).TableName = "過敏原"
        '建立 欄位
        For i As Integer = LBound(arySelectItem) To UBound(arySelectItem)
            dsCheckData.Tables(1).Columns.Add(arySelectItem(i).ToString.Trim)
        Next
        '存值入各欄位
        Dim rowDt2 As DataRow = dsCheckData.Tables(1).NewRow
        For i As Integer = LBound(arySelectItem) To UBound(arySelectItem)
            rowDt2.Item(i) = "Y"
        Next
        dsCheckData.Tables(1).Rows.Add(rowDt2)
        '--------------------------------------------------------------------------------
        'Dataset:建第3個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(2).TableName = "Indication"
        dsCheckData.Tables(2).Columns.Add("Indication_Type")
        dsCheckData.Tables(2).Columns.Add("Allergy_Item")
        
        '存值
        For i As Integer = LBound(arySelectItem) To UBound(arySelectItem)
            dsCheckData.Tables(2).NewRow()
            dsCheckData.Tables(2).Rows.Add()
            dsCheckData.Tables(2).Rows(i).Item("Indication_Type") = "2" '1:By檢驗單 2:By Order
            dsCheckData.Tables(2).Rows(i).Item("Allergy_Item") = arySelectItem(i).ToString.Trim
        Next


        Return dsCheckData

    End Function

    Private Function getCheckDataByArray() As String()

        Dim pvtResult(2) As String

        pvtResult(0) = "2"  '1:By檢驗單 2:By Order

        pvtResult(1) = ""

        Dim strSelectItem As String = ""
        Dim j, k As Integer
        For j = 0 To dgv_Data.Rows.Count - 1
            k = 1
            While k <= 6 ' PKey,選1,過敏原1,選2,過敏原2,選3,過敏原3
                If dgv_Data.Rows(j).Cells(k).Value Then
                    If pvtResult(1) = "" Then
                        'pvtResult(1) &= "CAP--過敏原：" & dgv_Data.Rows(j).Cells(k + 1).Value.ToString.Trim
                        pvtResult(1) &= dgv_Data.Rows(j).Cells(k + 1).Value.ToString.Trim
                    Else
                        pvtResult(1) &= "、" & dgv_Data.Rows(j).Cells(k + 1).Value.ToString.Trim
                    End If
                End If
                k = k + 2
            End While
        Next

        Return pvtResult

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
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (SaveData()) Then

                '左下方顯示 儲存 成功
                ShowInfoMsg("CMMCMMB301", "儲存")

                Me.Close()

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

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F12

                    '如果按下Shift，則為刪除
                    If e.Shift = False Then
                        ''刪除
                        'If (btn_Delete.Enabled) Then
                        '    btn_Delete.PerformClick()
                        'End If
                        '如果未按下Shift，則為新增/儲存
                        'Else

                        '儲存
                        If (btn_Save.Enabled) Then
                            btn_Save.PerformClick()
                        End If
                    End If
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

#End Region

   
End Class

