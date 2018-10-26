'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檢查醫令不須報到部門維護作業
'*              Title:	PubOrderExamNocheckinDeptUI
'*        Description:	檢查醫令不須報到部門維護作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Jun
'*        Create Date:	2016-06-30
'*      Last Modifier:	Jun
'*   Last Modify Date:	2016-06-30
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Comm.TableFactory


Public Class PubOrderExamNocheckinDeptUI
    Inherits BaseFormUI
#Region "       建構子"
    Public Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal chartNo As String)
        Me.m_Order_Code = chartNo
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
#End Region

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubOrderExamNocheckinDeptDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubOrderExamNocheckinDeptDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubOrderExamNocheckinDeptDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "科別代碼,診別,科診名稱,醫令代碼,來源別"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "60,60,120,120,60"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4"

    'Grid使用的標題--"Status"與"ErrMsg","Check_Index"為新增隱藏字段
    Dim columnNameGrid() As String = {"科別代碼", "診別", "科診名稱", "醫令代碼", "來源別", "Status", "ErrMsg", "Check_Index"}
    Dim columnNameDB() As String = {"Dept_Code", "Section_Id", "Dept_Sect_Name", "Order_Code", "Kind_Id", "Create_User", "Create_Time", "Modified_User", "Modified_Time"}

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum

#End Region


#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubOrderExamNocheckinDeptUI
    Public Shared Function GetInstance() As PubOrderExamNocheckinDeptUI
        If myInstance Is Nothing Then
            myInstance = New PubOrderExamNocheckinDeptUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "
    Dim m_Order_Code = ""
#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     儲存 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Private Function SaveData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim deleteCount As Integer = 0
            Dim insertCount As Integer = 0
            Dim dtSelected_O As DataTable = getDataForDB(dgv_O.GetSelectedDS.Tables(0)).Tables(0)
            Dim dtSelected_E As DataTable = getDataForDB(dgv_E.GetSelectedDS.Tables(0)).Tables(0)
            Dim dtSelected_I As DataTable = getDataForDB(dgv_I.GetSelectedDS.Tables(0)).Tables(0)

            dt = dtSelected_O.Copy()
            dt.Merge(dtSelected_E)
            dt.Merge(dtSelected_I)
            ds.Tables.Add(dt)

            Try
                deleteCount = Pub.PUBOrderExamNocheckinDeptdelete(m_Order_Code)
            Catch ex As Exception
                Throw New CommonException("CMMCMMB915", "PUBOrderExamNocheckinDeptdelete")
            End Try

            If CheckMethodUtil.CheckHasValue(ds) Then
                Try
                    insertCount = Pub.PUBOrderExamNocheckinDeptinsert(ds)
                Catch ex As Exception
                    Throw New CommonException("CMMCMMB915", "PUBOrderExamNocheckinDeptinsert")
                End Try
            End If

            setDgvOEI()

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
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

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            '設定門診、急診、住院DataGridView資料
            setDgvOEI()

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
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Private Sub LoadServiceManager()

        Try

            Pub = PubServiceManager.getInstance()

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
    ''' <remarks>by Jun on 2016-6-30</remarks>
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
    ''' <remarks>by Jun on 2016-06-30</remarks>
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

#End Region

#Region "     必填檢查 "



#End Region

#Region "     事件集合 "



#End Region

#Region "     取得存檔的Dataset資料 "



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
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (SaveData()) Then

                '左下方顯示 儲存 成功
                ShowInfoMsg("CMMCMMB301", "儲存")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
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
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F12

                    '如果按下Shift，則為刪除
                    If e.Shift = True Then

                        '如果未按下Shift，則為新增/儲存
                    Else

                        '儲存

                        If (btn_Save.Enabled) Then

                            btn_Save.PerformClick()

                        End If

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

#Region "     設定HashTable"
    Private Function getHashTable() As Hashtable
        Dim htGrid As New Hashtable
        Dim txt1 As New TextBoxCell
        Dim txt2 As New TextBoxCell
        Dim txt3 As New TextBoxCell
        Dim txt4 As New TextBoxCell
        Dim txt5 As New TextBoxCell
        htGrid.Add(1, txt1)
        htGrid.Add(2, txt2)
        htGrid.Add(3, txt3)
        htGrid.Add(4, txt4)
        htGrid.Add(5, txt5)
        Return htGrid
    End Function

    Private Function getDataForDgv(ByVal dt As DataTable) As DataSet
        Dim dsData As New DataSet
        If CheckMethodUtil.CheckHasValue(dt) Then

            ' 修改查詢結果中欄位名稱
            For i = 0 To dt.Columns.Count - 1
                dt.Columns(i).ColumnName = columnNameGrid(i)
            Next

            '在查詢結果中加入"Status"與"ErrMsg,"Check_Index"隱藏欄位"
            If Not dt.Columns.Contains("Status") Then dt.Columns.Add("Status")
            If Not dt.Columns.Contains("ErrMsg") Then dt.Columns.Add("ErrMsg")
            If Not dt.Columns.Contains("Check_Index") Then dt.Columns.Add("Check_Index")

            For j = 0 To dt.Rows.Count - 1
                dt.Rows(j).Item("Status") = "U"
            Next
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            dsData = ds.Copy

        Else
            dsData = genDS(DataSet_Type.Grid, gblTableName)
        End If
        Return dsData
    End Function

    Private Function getDataForDB(ByVal dt As DataTable) As DataSet
        Dim dsData As New DataSet
        If CheckMethodUtil.CheckHasValue(dt) Then

            ' 修改查詢結果中欄位名稱
            For i = 0 To dt.Columns.Count - 1
                dt.Columns(i).ColumnName = columnNameDB(i)
            Next

            '在查詢結果中加入"Status"與"ErrMsg,"Check_Index"隱藏欄位"
            If Not dt.Columns.Contains("Create_User") Then dt.Columns.Add("Create_User")
            If Not dt.Columns.Contains("Create_Time") Then dt.Columns.Add("Create_Time")
            If Not dt.Columns.Contains("Modified_User") Then dt.Columns.Add("Modified_User")
            If Not dt.Columns.Contains("Modified_Time") Then dt.Columns.Add("Modified_Time")

            For j = 0 To dt.Rows.Count - 1
                'dt.Rows(j).Item("Section_Id") = StringUtil.nvl(dt.Rows(j).Item("Section_Id"))
                dt.Rows(j).Item("Create_User") = CurrentUserID
                dt.Rows(j).Item("Create_Time") = Now
                dt.Rows(j).Item("Modified_User") = DBNull.Value
                dt.Rows(j).Item("Modified_Time") = DBNull.Value
                dt.Rows(j).Item("Order_Code") = Me.m_Order_Code
            Next
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            dsData = ds.Copy

        Else
            dsData = genDS(DataSet_Type.DB, gblTableName)
        End If
        Return dsData
    End Function

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
                For i As Integer = 0 To gblColumnNameDB.Length - 1
                    dsTemp.Tables(table).Columns.Add(gblColumnNameDB(i))
                Next

                '新增Status與ErrMsg,"Check_Index"欄位
                dsTemp.Tables(table).Columns.Add("Status")
                dsTemp.Tables(table).Columns.Add("ErrMsg")
                dsTemp.Tables(table).Columns.Add("Check_Index")

        End Select
        Return dsTemp
    End Function
#End Region

    Private Sub setDataToDgv(ByVal htGrid As Hashtable, ByVal dsData As DataSet, ByVal dgv_Data As UCLDataGridViewUC)
        htGrid.Add(-1, dsData)
        dgv_Data.Initial(htGrid)

        '設定攔寬
        dgv_Data.uclColumnWidth = gblColumnWidthDgv

        '設定隱藏欄位
        dgv_Data.uclVisibleColIndex = gblColumnVisibleDgv

        ''新增空白列
        'dgv_Data.AddNewRow()
        If dgv_Data.Rows.Count > 0 Then
            '設定Status值為I
            dgv_Data.GetDBDS.Tables(0).Rows(dgv_Data.Rows.Count - 1).Item("Status") = "I"
            dgv_Data.GetGridDS.Tables(0).Rows(dgv_Data.Rows.Count - 1).Item("Status") = "I"
            dgv_Data.Rows(dgv_Data.Rows.Count - 1).Cells("Status").Value = "I"

            '除了[選]以外，其它欄位設定為不啟用
            For i As Integer = 0 To dgv_Data.Rows.Count - 1
                dgv_Data.SetRowReadOnly(i, True)
                dgv_Data.SetCellReadOnly(0, i, False)
            Next
        End If

        '設定固定欄位，不隨著水平捲軸移動
        dgv_Data.Columns(1).Frozen = True

        dgv_Data.Refresh()
    End Sub

    Private Sub setDgv(ByVal dt As DataTable, ByVal dgv_Data As UCLDataGridViewUC)
        '取得HashTable
        Dim htGrid As Hashtable = getHashTable()
        '取得顯示在畫面上的資料
        Dim dsData As DataSet = getDataForDgv(dt)
        '將取得的資料設定到DataGridView
        setDataToDgv(htGrid, dsData, dgv_Data)
        '初始化DataGridView的CheckBox
        initializeCheckBox(dgv_Data)
    End Sub

    Private Sub initializeCheckBox(ByRef dgv_Data As UCLDataGridViewUC)
        Dim dgvDBDS As DataSet = dgv_Data.GetDBDS
        For Each dr As DataRow In dgvDBDS.Tables(0).Rows
            Dim i As Integer = dgvDBDS.Tables(0).Rows.IndexOf(dr)
            If Not "".Equals(StringUtil.nvl(dr.Item("醫令代碼"))) Then
                dgv_Data.Rows(i).Cells(0).Value = True
            End If
        Next
        'dgv_Data.Refresh()
    End Sub


    Private Sub setDgvOEI()
        Dim ds As DataSet = Pub.getInitialOrderExamNoCheckinDept(Me.m_Order_Code)

        setDgv(ds.Tables(0), dgv_O)
        setDgv(ds.Tables(1), dgv_E)
        setDgv(ds.Tables(2), dgv_I)
        dgv_O.Focus()
        dgv_I.Focus()
        dgv_E.Focus()
    End Sub
#End Region

#End Region

End Class

