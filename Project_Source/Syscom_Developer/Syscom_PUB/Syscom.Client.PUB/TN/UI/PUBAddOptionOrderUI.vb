Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports log4net
Imports Syscom.Client.UCL
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility

'Imports nckuh.server.pub

Public Class PUBAddOptionOrderUI
    Inherits Syscom.Client.UCL.BaseFormUI


    '============================
    '程式說明：群組醫令明細替代檔
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================

    Public Sub New(ByVal initAddOrderCode As String, ByVal initOriginalOrderCode As String, ByVal initAddOrderDetailNo As Integer, ByVal AlterDT As DataTable)

        AddOrderCode = initAddOrderCode
        OriginalOrderCode = initOriginalOrderCode
        AddOrderDetailNo = initAddOrderDetailNo
        OrderAlterData = AlterDT

        'SyscodeDT = initSyscode

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ContentColumn() As String = {"醫令代碼", "名稱", "數量", "Add_Order_Detail_No", "Is_New", "Dc"}
    Dim ContentColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDecimal, DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString}

    ' Dim OrderAlterColumn() As String = {"Add_Order_Code", "Add_Order_Detail_No", "Option_Order_Code", "Tqty", "Dc", "Is_New"}
    ' Dim OrderAlterColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString}

    ' [Add_Order_Code] 群組醫令碼
    ',[Add_Order_Detail_No]
    ',[Option_Order_Code]
    ',[Tqty]
    ',[Dc]

    Private isConfirm As Boolean = False
    Dim AddOrderCode As String = ""
    Dim OriginalOrderCode As String = ""
    Dim AddOrderDetailNo As Integer = 0
    'Private SyscodeDT As DataTable = Nothing
    Private OrderAlterDT As DataTable = Nothing

    Public Property OrderAlterData() As DataTable
        Get
            Return OrderAlterDT
        End Get
        Set(ByVal value As DataTable)
            OrderAlterDT = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBGroupOrderAlterUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        ucl_txt_original_order.Text = OriginalOrderCode

        ucl_dgv_list.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(ContentColumn)
        ucl_dgv_list.uclColumnWidth = "120, 180, 80, 0, 0, 0" '380
        ucl_dgv_list.uclColumnAlignment = "0"
        ucl_dgv_list.uclNonVisibleColIndex = "4, 5, 6"


        '-----------------------------------
        If DataSetUtil.IsContainsData(OrderAlterData) Then
            'dialog傳入舊資料
        Else
            '無傳入醫令替代資料 >> Query
            OrderAlterData = pub.queryAddOptionOrderData(AddOrderCode, AddOrderDetailNo)
        End If


        'init empty Grid資料
        '----------------------------------------------
        Dim listDS As DataSet = New DataSet
        Dim listDT As DataTable = DataSetUtil.createDataTable("list", Nothing, ContentColumn, ContentColumnType)
        listDS.Tables.Add(listDT)

        'Hash版
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, listDS)

        '-------
        '隨書隨選
        Dim cboGrid_cell1 As New ComboBoxGridCell()


        '設定隨輸隨選所開起的GridView大小
        cboGrid_cell1.GridWidth = 400
        cboGrid_cell1.GridHeight = 300

        '從SQLServer查詢資料
        cboGrid_cell1.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer

        '設定隨輸隨選要查詢哪一種Table  可參考 UCLComboBoxGridBO 會從DB中查詢的值
        cboGrid_cell1.QueryData = ComboBoxGridCell.Data.PUB_Order

        '根據Order_Code 作隨輸隨選 
        cboGrid_cell1.QueryType = ComboBoxGridCell.By.Code
        cboGrid_cell1.ValueIndex = "1"
        cboGrid_cell1.OrderTypeId = ComboBoxGridCell.OrderTypeIdData.None
        '根據Order_En_Name 作隨輸隨選  (同時間只能選擇一種 By.Code  or By.Name)
        'cboGrid_cell1.QueryType = ComboBoxGridCell.By.Name
        'cboGrid_cell1.ValueIndex = "2"


        '設定隨輸隨選所開起的GridView 的欄位名稱
        cboGrid_cell1.HeaderText = " 隱藏欄位0,名稱Order_Code,名稱Order_En_Name"

        '設定隨輸隨選所開起的GridView 要隱藏哪些欄位
        ' cboGrid_cell1.NonVisibleColIndex = "0,3,4,5,6,7,8,10,11,12,13,14"

        '隨輸隨選元件名稱   配合 receiveComboBoxGrid Event的 CtlName
        cboGrid_cell1.CtlName = "cboGrid_cell1"
        '-------

        Dim txt_cell As New TextBoxCell()

        Dim txt_int_cell As New TextBoxCell()
        txt_int_cell.uclTextType = UCLTextBoxUC.uclTextTypeData.Integer_Type


        _hashTable.Add(1, cboGrid_cell1)

        _hashTable.Add(3, txt_int_cell)

        ucl_dgv_list.Initial(_hashTable)


        optionOrderToGrid()

        Me.KeyPreview = True

    End Sub

#End Region

#Region "########## 共用函式 ##########"

    ''' <summary>
    ''' 取得clientservice
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadPubServiceManager()
        Try
            pub = PubServiceManager.getInstance
        Catch ex As Exception
            'MessageHandling.showInfoByKey("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkColumn() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True
        'If Not UclComboBoxUILender.SelectedIndex > 0 Then
        '    UclComboBoxUILender.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = UclComboBoxUILender
        'End If


        If allPass Then
            cleanFieldsColor()
        Else
            ErrorKeyFlag = True
            comp.Focus()
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 新增new row
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub addNewRow()
        '檢查...
        Try
            Dim AddOptionDT As DataTable = ucl_dgv_list.GetDBDS.Tables(0).Copy

            Dim addOptionDR As DataRow = AddOptionDT.NewRow

            If AddOrderDetailNo = 0 Then
                AddOrderDetailNo = 1
            End If

            addOptionDR.Item(ContentColumn(3)) = AddOrderDetailNo
            addOptionDR.Item(ContentColumn(4)) = "Y"
            addOptionDR.Item(ContentColumn(5)) = "N"

            AddOptionDT.Rows.Add(addOptionDR)

            Dim AddOptionDS As New DataSet
            AddOptionDS.Tables.Add(AddOptionDT)

            ucl_dgv_list.Visible = False
            ucl_dgv_list.SetDS(AddOptionDS)
            ucl_dgv_list.Visible = True

            'Dim alterDR As DataRow = OrderAlterData.NewRow
            'alterDR.Item("Option_Order_Code") = ""
            'alterDR.Item("Add_Order_Detail_No") = AddOrderDetailNo
            'alterDR.Item("Is_New") = "Y"
            'alterDR.Item("Dc") = "N"

            'OrderAlterData.Rows.Add(alterDR)

            'optionOrderToGrid()
        Catch ex As Exception

        End Try

    End Sub


    ''' <summary>
    ''' 對應替代醫令到grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub optionOrderToGrid()

        Dim ContentDS As DataSet = New DataSet
        Dim ContentDT As DataTable = DataSetUtil.createDataTable("content", Nothing, ContentColumn, ContentColumnType)
        '----------------------------------------------

        If DataSetUtil.IsContainsData(OrderAlterData) Then

            For i As Integer = 0 To (OrderAlterData.Rows.Count - 1)
                Dim Dc As String = "N"
                Dim listDR As DataRow = ContentDT.NewRow

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Option_Order_Code")) Then
                    listDR.Item(ContentColumn(0)) = CType(OrderAlterData.Rows(i).Item("Option_Order_Code"), String).Trim
                End If

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Order_Name")) Then
                    listDR.Item(ContentColumn(1)) = CType(OrderAlterData.Rows(i).Item("Order_Name"), String).Trim
                End If

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Tqty")) Then
                    listDR.Item(ContentColumn(2)) = CType(OrderAlterData.Rows(i).Item("Tqty"), Decimal)
                Else
                    listDR.Item(ContentColumn(2)) = 0
                End If

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Add_Order_Detail_No")) Then
                    listDR.Item(ContentColumn(3)) = CType(OrderAlterData.Rows(i).Item("Add_Order_Detail_No"), Integer)
                Else
                    listDR.Item(ContentColumn(3)) = 0
                End If

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Is_New")) Then
                    listDR.Item(ContentColumn(4)) = CType(OrderAlterData.Rows(i).Item("Is_New"), String).Trim
                End If

                If Not IsDBNull(OrderAlterData.Rows(i).Item("Dc")) Then
                    Dc = CType(OrderAlterData.Rows(i).Item("Dc"), String).Trim

                    listDR.Item(ContentColumn(5)) = Dc
                Else
                    listDR.Item(ContentColumn(5)) = "N"
                End If



                If Not Dc.Equals("Y") Then
                    ContentDT.Rows.Add(listDR)
                End If

            Next


            ' [Add_Order_Code] 群組醫令碼
            ',[Add_Order_Detail_No]
            ',[Option_Order_Code]
            ',[Tqty]
            ',[Dc]
            'pk_Add_Order_Code pk_Add_Order_Detail_No pk_Option_Order_Code

        End If


        ContentDS.Tables.Add(ContentDT)
        '----------------------------------------------

        ucl_dgv_list.SetDS(ContentDS)
        ucl_txt_original_order.Focus()

    End Sub

    Private Function gridToAddOptionOrder() As DataTable


        '{"醫令代碼", "名稱", "數量", "Add_Order_Detail_No", "Is_New", "Dc"} ContentColumn
        OrderAlterData.Clear()

        Try
            Dim gridAddOptionDT As DataTable = ucl_dgv_list.GetDBDS.Tables(0).Copy



            If DataSetUtil.IsContainsData(gridAddOptionDT) Then
                For Each optiondr As DataRow In gridAddOptionDT.Rows
                    If (Not IsDBNull(optiondr.Item(ContentColumn(0)))) AndAlso CType(optiondr.Item(ContentColumn(0)), String).Trim.Length > 0 Then
                        Dim addoptiondr As DataRow = OrderAlterData.NewRow

                        addoptiondr.Item("Add_Order_Code") = AddOrderCode
                        addoptiondr.Item("Add_Order_Detail_No") = CType(optiondr.Item(ContentColumn(3)), Integer)
                        addoptiondr.Item("Option_Order_Code") = CType(optiondr.Item(ContentColumn(0)), String).Trim
                        addoptiondr.Item("Tqty") = CType(optiondr.Item(ContentColumn(2)), Integer)
                        addoptiondr.Item("Dc") = CType(optiondr.Item(ContentColumn(5)), String).Trim

                        addoptiondr.Item("Is_New") = CType(optiondr.Item(ContentColumn(4)), String).Trim
                        If Not IsDBNull(optiondr.Item(ContentColumn(1))) Then
                            addoptiondr.Item("Order_Name") = CType(optiondr.Item(ContentColumn(1)), String).Trim
                        Else
                            addoptiondr.Item("Order_Name") = ""
                        End If


                        If CType(optiondr.Item(ContentColumn(4)), String).Trim.Equals("Y") AndAlso CType(optiondr.Item(ContentColumn(5)), String).Trim.Equals("Y") Then
                            'do nothing
                        Else
                            OrderAlterData.Rows.Add(addoptiondr)
                        End If
                    End If

                Next

            End If

        Catch ex As Exception

        End Try

        Return OrderAlterData

        ',[Add_Order_Code]()
        ',[Add_Order_Detail_No]
        ',[Option_Order_Code]
        ',[Tqty]
        ',[Dc]

    End Function

    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            'UclComboBoxUILender.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendType.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendReason.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendDept.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

            ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '----------------------------------------------------------------------------
    '用對話視窗方式開啟，不執行資料庫動作(存DataSet)
    '----------------------------------------------------------------------------
    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()

        Return isConfirm

    End Function

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub confirm()

        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            isConfirm = True
            '檢查資料內容
            'TODO
            OrderAlterData = gridToAddOptionOrder()

            'If DataSetUtil.IsContainsData(OrderAlterData) Then

            '    For i As Integer = (OrderAlterData.Rows.Count - 1) To 0 Step -1
            '        Dim orderCode As String = CType(OrderAlterData.Rows(i).Item("Option_Order_Code"), String).Trim
            '        Dim isNew As String = CType(OrderAlterData.Rows(i).Item("Is_New"), String).Trim
            '        Dim dc As String = CType(OrderAlterData.Rows(i).Item("Dc"), String).Trim

            '        If orderCode.Equals("") Or (isNew.Equals("Y") AndAlso dc.Equals("Y")) Then
            '            OrderAlterData.Rows.RemoveAt(i)
            '        End If

            '    Next

            'End If

            'MessageHandling.showInfoByKey("CMMCMMB015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB015", New String() {})

        Catch ex As Exception
        Finally
            ScreenUtil.UnLock(Me)
            Me.Dispose()
        End Try

    End Sub


    ''' <summary>
    ''' 刪除群組醫令替代
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub removeOptionOrder()

        'Update PUB_Add_Order Set Dc=Y。

        'TODO 
        '存進remove的地方
        Dim selectIndex() As Integer = ucl_dgv_list.GetSelectedIndex

        If selectIndex IsNot Nothing AndAlso selectIndex.Length > 0 Then
            'Dim contentDS As DataSet = ucl_dgv_list.GetDBDS.Copy

            Dim AlterOrderCode As String = CType(ucl_dgv_list.GetDBDS.Tables(0).Rows(selectIndex(0)).Item(ContentColumn(0)), String).Trim
            Dim AddOrderDetailNo As Integer = CType(ucl_dgv_list.GetDBDS.Tables(0).Rows(selectIndex(0)).Item(ContentColumn(3)), Integer)

            If DataSetUtil.IsContainsData(OrderAlterData) Then

                For i As Integer = 0 To (OrderAlterData.Rows.Count - 1)
                    If (Not IsDBNull(OrderAlterData.Rows(i).Item("Option_Order_Code"))) AndAlso (Not IsDBNull(OrderAlterData.Rows(i).Item("Add_Order_Detail_No"))) _
                    AndAlso CType(OrderAlterData.Rows(i).Item("Option_Order_Code"), String).Trim.Equals(AlterOrderCode) AndAlso (CType(OrderAlterData.Rows(i).Item("Add_Order_Detail_No"), Integer) = AddOrderDetailNo) Then
                        OrderAlterData.Rows(i).Item("Dc") = "Y"
                    End If

                Next

            End If

            'contentDS.Tables(0).Rows.RemoveAt(selectIndex(0))

            optionOrderToGrid()
            'setDSToGrid(contentDS)

            'hash
        End If

    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBGroupOrderAlterUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Shift And Keys.F12
                '刪除醫令
                removeOptionOrder()
            Case Keys.F12
                confirm()
        End Select
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirm()
    End Sub

    ''' <summary>
    ''' 刪除醫令
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        removeOptionOrder()
    End Sub

    Private Sub btn_newrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newrow.Click
        addNewRow()
        'DS加資料
    End Sub

    '----------------------------------------------------------------------------------------------------------------
    '隨輸隨選
    '----------------------------------------------------------------------------------------------------------------

    '加入必要的Event Handle
    Dim WithEvents pvtReceiveComboBoxGridMgr As EventManager = EventManager.getInstance

    '處理隨輸隨選選擇一筆資料時所觸發的Event
    Private Sub receiveComboBoxGrid(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As DataGridViewRow) Handles pvtReceiveComboBoxGridMgr.UclOpenWindowComboBoxGridValue

        If Not ucl_dgv_list.IsComboBoxGridSetValue Then
            '此段請加上
            Exit Sub
        End If

        If ctlName = "cboGrid_cell1" Then

            '回寫資料到GridDS , DBDS 的Order_Code
            ucl_dgv_list.GetGridDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells(1).Value.ToString.Trim
            ucl_dgv_list.GetDBDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells(1).Value.ToString.Trim


            '回寫資料到GridDS , DBDS 的 Order_En_name
            ucl_dgv_list.GetGridDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value.ToString.Trim
            ucl_dgv_list.GetDBDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value.ToString.Trim

            'row的值是根據隨輸隨選 所選擇某一筆資料整個Row的值
            '以上適情況將row.Cell的值填入 GridView GridDS , DBDS 中

            ucl_dgv_list.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If rowIndex = ucl_dgv_list.Rows.Count - 1 Then

                '適需要添加此行,會自動在最後一行新增一空白列,可讓使用者繼續輸入
                'ucl_dgv_list.AddNewRow()
            End If

            ucl_dgv_list.Refresh()

        End If
    End Sub

#End Region



End Class
