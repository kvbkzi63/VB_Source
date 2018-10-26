Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.TableFactory
'Imports nckuh.server.pub

Public Class PUBAddOrderListUI
    Inherits Syscom.Client.UCL.BaseFormUI
    '============================
    '程式說明：群組醫令清單
    '修改日期：2009.10.31
    '修改日期：2009.10.31
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initAddOrderCode As String, ByVal previousHash As Hashtable)



        enterAddOrderCode = initAddOrderCode
        'SyscodeDT = initSyscodeDT
        'SystemDate = initSystemDate

        If previousHash IsNot Nothing Then
            GroupOrderHash = previousHash
        Else
            GroupOrderHash.Clear()
        End If


        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ContentColumn() As String = {"群組碼", "群組名稱", "群組註記", "查看明細", "Dc", "Is_New", "建立者", "建立時間", "修改者", "修改時間"}
    Dim ContentColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim AddOrderColumn() As String = {"Add_Order_Code", "Add_Order_Name", "Group_Id", "Dc", "Is_New", "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    Dim AddOrderColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}
     Dim isConfirm As Boolean = False
    Dim enterAddOrderCode As String = ""
    'Dim GroupId As String = ""
    Dim SystemDate As Date = DateUtil.getSystemDate
    Dim SyscodeDT As DataTable = Nothing

    Private AddOrderDT As DataTable = Nothing
    Private AddOrderDetailDT As DataTable = Nothing
    Private UpdataDS As New DataSet

    Private modGroupOrderHash As Hashtable = New Hashtable '{addordercode-groupid, nexthash}

    Public Property GroupOrderHash() As Hashtable
        Get
            Return modGroupOrderHash
        End Get
        Set(ByVal value As Hashtable)
            modGroupOrderHash = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBGroupOrderListUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        loadPubServiceManager()
        '啟動hot key
        Me.KeyPreview = True

        'If SyscodeDT Is Nothing Then
        Dim typeId() As Integer = {39, 510}
        SyscodeDT = pub.querySyscodeByTypeIds(typeId)
        'End If



        If (enterAddOrderCode IsNot Nothing) And (Not enterAddOrderCode.Equals("")) Then
            ucl_txt_group_order.Text = enterAddOrderCode


            If GroupOrderHash IsNot Nothing AndAlso GroupOrderHash.ContainsKey("PUBAddOrder") Then
                AddOrderDT = CType(GroupOrderHash.Item("PUBAddOrder"), DataTable)
            Else
                queryAddOrderData()
            End If

        End If



        ucl_combo_group_mark.DataSource = createComboBoxTable("groupmark", SyscodeDT.Select(" Type_Id in (39, 510) "))
        ucl_combo_group_mark.uclValueIndex = "0"
        ucl_combo_group_mark.uclDisplayIndex = "0,1"


        'Grid

        'DGV
        ucl_dgv_content.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(ContentColumn)
        ucl_dgv_content.uclColumnWidth = "120, 120, 120, 120, 100, 100,100,100,100,100" '998
        ucl_dgv_content.uclColumnAlignment = "0"
        ucl_dgv_content.uclNonVisibleColIndex = "5, 6"
 
        'Hash版
        Dim ContentDS As DataSet = New DataSet
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, ContentDS)

        Dim btn_cell As New ButtonCell()
        btn_cell.Text = "明細"
         _hashTable.Add(4, btn_cell)

        'MVC的view

        ucl_dgv_content.Initial(_hashTable)

        orderToGrid()

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
    ''' Create DataTable By DataSource Parameter Column 0 key, column 1 value
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="dataSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createComboBoxTable(ByVal tableName As String, ByRef dataSource As DataTable) As DataTable
        Dim returnDT As DataTable = DataSetUtil.createDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

        For i As Integer = 0 To (dataSource.Rows.Count - 1)
            Dim dr As DataRow = returnDT.NewRow
            dr.Item(ComboBoxColumn(0)) = CType(dataSource.Rows(i).Item(0), String).Trim
            dr.Item(ComboBoxColumn(1)) = CType(dataSource.Rows(i).Item(1), String).Trim
            returnDT.Rows.Add(dr)
        Next

        Return returnDT

    End Function

    ''' <summary>
    ''' (從syscode)Create DataTable By DataRows Parameter Column 1 key, column 3 value
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="dataRows"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createComboBoxTable(ByVal tableName As String, ByRef dataRows() As DataRow) As DataTable

        Dim returnDT As DataTable = DataSetUtil.createDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

        If dataRows IsNot Nothing AndAlso dataRows.Length > 0 Then

            For i As Integer = 0 To (dataRows.Length - 1)
                Dim dr As DataRow = returnDT.NewRow
                dr.Item(ComboBoxColumn(0)) = CType(dataRows(i).Item(1), String).Trim
                dr.Item(ComboBoxColumn(1)) = CType(dataRows(i).Item(3), String).Trim
                returnDT.Rows.Add(dr)
            Next

        End If

        Return returnDT

    End Function

    Private Sub orderToGrid()
        Dim ContentDS As DataSet = New DataSet
        Dim ContentDT As DataTable = DataSetUtil.createDataTable("content", Nothing, ContentColumn, ContentColumnType)

        If DataSetUtil.IsContainsData(AddOrderDT) Then
            For i As Integer = 0 To (AddOrderDT.Rows.Count - 1)
                Dim ContentDR As DataRow = ContentDT.NewRow
                'ContentColumn() As String = {"群組醫令碼", "群組醫令名稱", "群組註記", "查看明細"}

                If Not IsDBNull(AddOrderDT.Rows(i).Item("Add_Order_Code")) Then
                    ContentDR.Item(ContentColumn(0)) = CType(AddOrderDT.Rows(i).Item("Add_Order_Code"), String).Trim
                End If

                If Not IsDBNull(AddOrderDT.Rows(i).Item("Add_Order_Name")) Then
                    ContentDR.Item(ContentColumn(1)) = CType(AddOrderDT.Rows(i).Item("Add_Order_Name"), String).Trim
                End If

                If Not IsDBNull(AddOrderDT.Rows(i).Item("Group_Id")) Then
                    ContentDR.Item(ContentColumn(2)) = CType(AddOrderDT.Rows(i).Item("Group_Id"), String).Trim
                    ucl_combo_group_mark.SelectedValue = CType(AddOrderDT.Rows(i).Item("Group_Id"), String).Trim
                End If

                'If Not IsDBNull(AddOrderDT.Rows(i).Item("Add_Order_Code")) Then
                '    ContentDR.Item(ContentColumn(3)) = CType(AddOrderDT.Rows(i).Item("Add_Order_Code"), String).Trim
                'End If

                If Not IsDBNull(AddOrderDT.Rows(i).Item("Dc")) Then
                    ContentDR.Item(ContentColumn(4)) = CType(AddOrderDT.Rows(i).Item("Dc"), String).Trim
                End If

                If Not IsDBNull(AddOrderDT.Rows(i).Item("Is_New")) Then
                    ContentDR.Item(ContentColumn(5)) = CType(AddOrderDT.Rows(i).Item("Is_New"), String).Trim
                End If

                If CType(ContentDR.Item(ContentColumn(4)), String).Trim.Equals("N") Then
                    ContentDT.Rows.Add(ContentDR)
                End If
                If Not IsDBNull(AddOrderDT.Rows(i).Item("Create_User")) Then
                    ContentDR.Item(ContentColumn(6)) = CType(AddOrderDT.Rows(i).Item("Create_User"), String).Trim
                End If
                If Not IsDBNull(AddOrderDT.Rows(i).Item("Create_Time")) Then
                    ContentDR.Item(ContentColumn(7)) = CType(AddOrderDT.Rows(i).Item("Create_Time"), String).Trim
                End If
                If Not IsDBNull(AddOrderDT.Rows(i).Item("Modified_User")) Then
                    ContentDR.Item(ContentColumn(8)) = CType(AddOrderDT.Rows(i).Item("Modified_User"), String).Trim
                End If
                If Not IsDBNull(AddOrderDT.Rows(i).Item("Modified_Time")) Then
                    ContentDR.Item(ContentColumn(9)) = CType(AddOrderDT.Rows(i).Item("Modified_Time"), String).Trim
                End If
            Next

            If GroupOrderHash.ContainsKey("PUBAddOrder") Then
                GroupOrderHash.Item("PUBAddOrder") = AddOrderDT
            Else
                GroupOrderHash.Add("PUBAddOrder", AddOrderDT)
            End If
        End If




        ContentDS.Tables.Add(ContentDT)
        '----------------------------------------------

        ucl_dgv_content.SetDS(ContentDS)

        '重新設定列高，以免Btn的字被切掉
        For i As Int32 = 0 To ucl_dgv_content.Rows.Count - 1
            ucl_dgv_content.Rows(i).Height = 30
        Next

        ucl_txt_group_order.Focus()

    End Sub

    'Private 

    ''' <summary>
    ''' 查詢群組醫令
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub queryAddOrderData()

        'clear
        Dim AddOrderCode As String = ucl_txt_group_order.Text.Trim
        Dim GroupId As String = ucl_combo_group_mark.SelectedValue.Trim
        ucl_txt_group_order.Text = ""
        ucl_combo_group_mark.SelectedIndex = -1
        AddOrderDT = putQueryAddOrderToDT(Nothing)
        orderToGrid()
        GroupOrderHash.Clear()

        'reset
        ucl_txt_group_order.Text = AddOrderCode
        ucl_combo_group_mark.SelectedValue = GroupId

        'If AddOrderCode.Length = 0 Then
        '    AddOrderDT = putQueryAddOrderToDT(Nothing)
        '    orderToGrid()

        '    'MessageHandling.showErrorByKey("CMMCMMB009")
        '    '********************2010/2/9 Modify By Alan**********************
        '    MessageHandling.ShowErrorMsg("CMMCMMB009", New String() {}, "")


        '    ucl_txt_group_order.Focus()
        'Else
        AddOrderDT = putQueryAddOrderToDT(pub.queryAddOrderData(AddOrderCode))

        orderToGrid()

        If DataSetUtil.IsContainsData(AddOrderDT) Then

        Else

            'MessageHandling.showErrorByKey("CMMCMMB000")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB000", New String() {}, "")

            'MessageHandling.showErrorByKey("CMMCMMB000")
            ucl_txt_group_order.Focus()
        End If

        'End If
    End Sub

    Private Function putQueryAddOrderToDT(ByVal queryAddOrderDT As DataTable) As DataTable
        Dim returnAddOrderDT As DataTable = DataSetUtil.createDataTable("PUBAddOrder", Nothing, AddOrderColumn, AddOrderColumnType)

        If DataSetUtil.IsContainsData(queryAddOrderDT) Then
            For i As Integer = 0 To (queryAddOrderDT.Rows.Count - 1)
                Dim returnAddOrderDR As DataRow = returnAddOrderDT.NewRow
                returnAddOrderDR.Item("Add_Order_Code") = CType(queryAddOrderDT.Rows(i).Item("Add_Order_Code"), String).Trim
                returnAddOrderDR.Item("Add_Order_Name") = CType(queryAddOrderDT.Rows(i).Item("Add_Order_Name"), String).Trim
                returnAddOrderDR.Item("Group_Id") = CType(queryAddOrderDT.Rows(i).Item("Group_Id"), String).Trim
                returnAddOrderDR.Item("Dc") = CType(queryAddOrderDT.Rows(i).Item("Dc"), String).Trim
                returnAddOrderDR.Item("Is_New") = CType(queryAddOrderDT.Rows(i).Item("Is_New"), String).Trim
                returnAddOrderDR.Item("Create_User") = CType(queryAddOrderDT.Rows(i).Item("Create_User"), String).Trim
                returnAddOrderDR.Item("Create_Time") = CType(queryAddOrderDT.Rows(i).Item("Create_Time"), String).Trim
                returnAddOrderDR.Item("Modified_User") = CType(queryAddOrderDT.Rows(i).Item("Modified_User"), String).Trim
                returnAddOrderDR.Item("Modified_Time") = CType(queryAddOrderDT.Rows(i).Item("Modified_Time"), String).Trim

                returnAddOrderDT.Rows.Add(returnAddOrderDR)
            Next

        End If

        Return returnAddOrderDT

    End Function

    ''' <summary>
    ''' 刪除群組醫令
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub removeAddOrder()

        'Update PUB_Add_Order Set Dc=Y。

        'TODO
        'dialog模式存進remove的地方
        'TODO
        '存進remove的地方
        Dim selectIndex() As Integer = ucl_dgv_content.GetSelectedIndex

        If selectIndex IsNot Nothing AndAlso selectIndex.Length > 0 Then


            For i As Integer = 0 To (selectIndex.Length - 1)
                AddOrderDT.Rows(selectIndex(i)).Item("Dc") = "Y"
                pub.deleteAddOrder(AddOrderDT.Rows(selectIndex(i)).Item("Add_Order_Code"))
            Next

            orderToGrid()

        End If


    End Sub

    ''' <summary>
    ''' 新增群組醫令
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddAddOrder()

        ''先check欄位
        'AddOrderCode = ucl_txt_group_order.Text.Trim

        'Dim GroupId As String = CType(ucl_combo_group_mark.SelectedValue, String).Trim

        'Dim key As String = AddOrderCode & "-" & GroupId

        'Dim paramHash As Hashtable = Nothing
        'If GroupOrderHash.ContainsKey(key) Then
        '    paramHash = CType(GroupOrderHash.Item(key), Hashtable)
        'End If

        'Dim dt As New DataTable
        ''"醫令代碼", "名稱", "換", "隨原項目計算", "劑量", "頻次", "用法", "天數", "總量", "計", "被連帶醫令可刪", "Add_Order_Detail_No", "Is_New", "Dc", "自費計價註記", "健保計價註記","建立者","建立時間","修改者","修改時間"
        'dt.Columns.Add("醫令代碼")
        'dt.Columns.Add("名稱")
        'dt.Columns.Add("總量")
        'dt.Columns.Add("自費計價註記")
        'dt.Columns.Add("健保計價註記")
        'dt.Columns.Add("建立者")
        'dt.Columns.Add("建立時間")
        'dt.Columns.Add("修改者")
        'dt.Columns.Add("修改時間")

        'Dim row As DataRow = dt.NewRow
        'row("醫令代碼") = ""
        'row("名稱") = ""
        'row("總量") = ""
        'row("自費計價註記") = ""
        'row("健保計價註記") = ""
        'row("建立者") = ""
        'row("建立時間") = ""
        'row("修改者") = ""
        'row("修改時間") = ""
        'dt.Rows.Add(row)

        Dim paramHash As Hashtable = Nothing

        Dim maintain As PUBAddOrderDetailUI = New PUBAddOrderDetailUI(paramHash)
        maintain.ShowAndPrepareReturnData()

        Dim AddOrderHAsh As Hashtable = maintain.GroupOrderDtlHash

        If AddOrderHAsh IsNot Nothing Then
            If AddOrderHAsh.ContainsKey("PUBAddOrder") Then
                Dim newAddOrderDT As DataTable = CType(AddOrderHAsh.Item("PUBAddOrder"), DataTable)
                Dim newAddOrderDetailDT As DataTable = CType(maintain.GroupOrderDtlHash.Item("PUBAddOrderDetail"), DataTable)

                updateAddOrderUnit(newAddOrderDT)
                UpdataDataSet(newAddOrderDT, newAddOrderDetailDT)

                '先check欄位
                Dim AddOrderCode As String = CType(newAddOrderDT.Rows(0).Item("Add_Order_Code"), String).Trim

                Dim GroupId As String = CType(newAddOrderDT.Rows(0).Item("Group_Id"), String).Trim

                Dim key As String = AddOrderCode & "-" & GroupId


                If GroupOrderHash.ContainsKey(key) Then
                    paramHash = CType(GroupOrderHash.Item(key), Hashtable)
                End If



                If GroupOrderHash.ContainsKey(key) Then
                    GroupOrderHash.Item(key) = AddOrderHAsh
                Else
                    GroupOrderHash.Add(key, AddOrderHAsh)
                End If

            End If
            'If AddOrderDtlHAsh.ContainsKey("PUBAddOrderDetail") Then
            '    AddOrderDT = CType(AddOrderDtlHAsh.Item("PUBAddOrderDetail"), DataTable)
            'End If



            '加入ui grid
            'ordercode, ordername, groupid

        End If





        'If DataSetUtil.IsContainsData(ucl_dgv_content.GetDBDS) Then
        '    If isDialogFlag Then
        '        '是被呼叫...存DT, DS
        '    Else
        '        '直接儲存
        '    End If
        'Else
        '    MessageHandling.showErrorByKey("CMMCMMB012")
        'End If
    End Sub

    Private Sub updateAddOrderUnit(ByVal newAddOrderDT As DataTable)

        If DataSetUtil.IsContainsData(newAddOrderDT) Then
            Dim AddOrderCode As String = CType(newAddOrderDT.Rows(0).Item("Add_Order_Code"), String).Trim
            Dim AddOrderName As String = CType(newAddOrderDT.Rows(0).Item("Add_Order_Name"), String).Trim

            If DataSetUtil.IsContainsData(AddOrderDT) Then
                Dim containFlag As Boolean = False
                For i As Integer = 0 To (AddOrderDT.Rows.Count - 1)
                    If AddOrderCode.Equals(CType(AddOrderDT.Rows(i).Item("Add_Order_Code"), String).Trim) Then
                        containFlag = True

                        AddOrderDT.Rows(i).Item("Add_Order_Name") = AddOrderName
                    End If
                Next

                If containFlag Then

                Else
                    AddOrderDT.Rows.Add(newAddOrderDT.Rows(0).ItemArray)
                End If
            Else
                'AddOrderDT.Rows.Add(newAddOrderDT.Rows(0).ItemArray)
                AddOrderDT = putQueryAddOrderToDT(Nothing)
                AddOrderDT.Rows.Add(newAddOrderDT.Rows(0).ItemArray)
            End If


        End If
        'dim ucl_dgv_content.GetDBDS 

        'AddOrderDT
        orderToGrid()
    End Sub

    Private Function confirm() As Boolean
        '--------------------------------------
        '20100412 AddOrderDT
        isConfirm = True

        Me.Dispose()
    End Function

    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()


        Return isConfirm

    End Function

    Private Function UpdataDataSet(ByVal orderDT As DataTable, ByVal orderDetailDT As DataTable) As Integer
        Dim count As Integer = 0
        Dim newOrderDT As DataTable = PubAddOrderDataTableFactory.getDataTable
        Dim newOrderDr As DataRow
        Dim newOrderDetailDT As DataTable = PubAddOrderDetailDataTableFactory.getDataTable
        Dim newOrderDetailDr As DataRow

        Try
            For Each dr As DataRow In orderDT.Rows
                newOrderDr = newOrderDT.NewRow
                For Each c As DataColumn In orderDT.Columns

                    Try
                        If dr(c).ToString.Trim <> "" Then
                            newOrderDr(c.ToString) = dr(c)
                        End If
                    Catch ex As Exception
                        Continue For
                    End Try
                Next
                newOrderDr("Modified_User") = AppContext.userProfile.userId
                newOrderDr("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                newOrderDr("Create_User") = AppContext.userProfile.userId
                If newOrderDr("Create_Time").ToString.Trim.Equals("") Then
                    newOrderDr("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                End If
                newOrderDT.Rows.Add(newOrderDr)
            Next

            For Each dr As DataRow In orderDetailDT.Rows
                newOrderDetailDr = newOrderDetailDT.NewRow
                For Each c As DataColumn In orderDetailDT.Columns
                    Try
                        If dr(c).ToString.Trim <> "" Then
                            newOrderDetailDr(c.ToString) = dr(c)
                        End If
                    Catch ex As Exception
                        Continue For
                    End Try
                Next
                newOrderDetailDr("Modified_User") = AppContext.userProfile.userId
                newOrderDetailDr("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                newOrderDetailDr("Create_User") = AppContext.userProfile.userId
                If newOrderDetailDr("Create_Time").ToString.Trim.Equals("") Then
                    newOrderDetailDr("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                End If
                newOrderDetailDT.Rows.Add(newOrderDetailDr)

            Next
            UpdataDS = Nothing
            UpdataDS = New DataSet
            UpdataDS.Tables.Add(newOrderDT.Copy)
            UpdataDS.Tables.Add(newOrderDetailDT.Copy)
            '更新資料庫
            count = pub.UpdateAddOrder(UpdataDS)
            Return count
        Catch ex As Exception
            Return count
        End Try
    End Function

#End Region

#Region "########## 觸發事件 ##########"

#End Region

    ''' <summary>
    ''' 快速鍵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PUBGroupOrderListUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                queryAddOrderData()
            Case e.Shift And Keys.F12
                removeAddOrder()
            Case Keys.F12
                AddAddOrder()
        End Select
    End Sub

    Private Sub ucl_dgv_content_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucl_dgv_content.CellClick

        If DataSetUtil.IsContainsData(ucl_dgv_content.GetDBDS) Then

            Dim clickAddOrderCode As String = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(0)), String).Trim
            Dim clickGroupId As String = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(2)), String).Trim

            ucl_txt_group_order.Text = clickAddOrderCode
            ucl_combo_group_mark.SelectedValue = clickGroupId

            If GroupOrderHash.ContainsKey("Add_Order_Code") Then
                GroupOrderHash.Item("Add_Order_Code") = clickAddOrderCode
            Else
                GroupOrderHash.Add("Add_Order_Code", clickAddOrderCode)
            End If


            Select Case e.ColumnIndex
                Case 4
                    Dim rowIndex As Integer = e.RowIndex
                    '{"群組醫令碼", "群組醫令名稱", "群組註記", "查看明細"}
                    Dim AddOrderCode As String = ""
                    Dim GroupId As String = ""
                    Dim AddOrderName As String = ""
                    Dim Dc As String = "N"
                    Dim IsNew As String = "N"
                    If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(0))) Then
                        AddOrderCode = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(0)), String).Trim
                    End If
                    If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(1))) Then
                        AddOrderName = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(1)), String).Trim
                    End If
                    If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(2))) Then
                        GroupId = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(2)), String).Trim
                    End If

                    If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(4))) Then
                        Dc = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(4)), String).Trim
                    End If
                    If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(5))) Then
                        IsNew = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(ContentColumn(5)), String).Trim
                    End If

                    '-------------------------------------------------------------
                    '20100412
                    Dim key As String = AddOrderCode & "-" & GroupId
                    'GroupOrderHash
                    If GroupOrderHash.ContainsKey(key) Then
                        Dim maintain As PUBAddOrderDetailUI = New PUBAddOrderDetailUI(CType(GroupOrderHash.Item(key), Hashtable))
                        maintain.ShowAndPrepareReturnData()

                        If maintain.GroupOrderDtlHash IsNot Nothing AndAlso maintain.GroupOrderDtlHash.ContainsKey("PUBAddOrder") Then
                            Dim newAddOrderDT As DataTable = CType(maintain.GroupOrderDtlHash.Item("PUBAddOrder"), DataTable)
                            Dim newAddOrderDetailDT As DataTable = CType(maintain.GroupOrderDtlHash.Item("PUBAddOrderDetail"), DataTable)
                            UpdataDS = New DataSet
                            UpdataDataSet(newAddOrderDT, newAddOrderDetailDT)

                            updateAddOrderUnit(newAddOrderDT)

                            GroupOrderHash.Item(key) = maintain.GroupOrderDtlHash
                        End If




                    Else

                        Dim forQueryAddOrderDT As DataTable = DataSetUtil.createDataTable("PUBAddOrder", Nothing, AddOrderColumn, AddOrderColumnType)

                        Dim orderDR As DataRow = forQueryAddOrderDT.NewRow
                        orderDR.Item("Add_Order_Code") = AddOrderCode
                        orderDR.Item("Add_Order_Name") = AddOrderName
                        orderDR.Item("Group_Id") = GroupId
                        orderDR.Item("Dc") = Dc
                        orderDR.Item("Is_New") = IsNew

                        forQueryAddOrderDT.Rows.Add(orderDR)
                        Dim addOrderHash As New Hashtable
                        addOrderHash.Add("PUBAddOrder", forQueryAddOrderDT)

                        Dim maintain As PUBAddOrderDetailUI = New PUBAddOrderDetailUI(addOrderHash)
                        maintain.ShowAndPrepareReturnData()


                        If maintain.GroupOrderDtlHash IsNot Nothing AndAlso maintain.GroupOrderDtlHash.ContainsKey("PUBAddOrder") Then
                            Dim newAddOrderDT As DataTable = CType(maintain.GroupOrderDtlHash.Item("PUBAddOrder"), DataTable)
                            Dim newAddOrderDetailDT As DataTable = CType(maintain.GroupOrderDtlHash.Item("PUBAddOrderDetail"), DataTable)
                            UpdataDataSet(newAddOrderDT, newAddOrderDetailDT)
                            updateAddOrderUnit(newAddOrderDT)

                            GroupOrderHash.Add(key, maintain.GroupOrderDtlHash)
                        End If


                    End If
                    'key

            End Select

        End If
    End Sub

    Private Sub btn_add_group_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_group_order.Click
        AddAddOrder()
    End Sub

    Private Sub btn_delete_group_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_group_order.Click
        removeAddOrder()
    End Sub

    Private Sub btn_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click
        'query by Add_order_code
        queryAddOrderData()
    End Sub

    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirm()
    End Sub


End Class
