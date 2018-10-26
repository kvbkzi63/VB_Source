Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports log4net
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
'Imports nckuh.server.pub

Public Class PUBAddOrderDetailUI
    Inherits Syscom.Client.UCL.BaseFormUI

    '============================
    '程式說明：群組醫令清單
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal previousHash As Hashtable)

        'AddOrderCode = initAddOrderCode
        'GroupId = initGroupId
        'AddOrderName = initAddOrderName



        If previousHash IsNot Nothing Then
            'TODO'set進去 畫面中
            '畫面顯示資料....
            GroupOrderDtlHash = previousHash
        End If


        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ContentColumn() As String = {"醫令代碼", "名稱", "換", "隨原項目計算", "劑量", "頻次", "用法", "天數", "總量", "計", "被連帶醫令可刪", "Add_Order_Detail_No", "Is_New", "Dc", "自費計價註記", "健保計價註記","建立者","建立時間","修改者","修改時間"}
    Dim ContentColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                          DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                          DataSetUtil.TypeString, DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                          DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim isConfirm As Boolean = False


    Dim AddOrderCode As String = ""
    Dim GroupId As String = ""
    Dim MaxOrderDetailNo As Integer = 0
    Dim AddOrderName As String = ""
    Dim Dc As String = "N"
    Dim IsNew As String = "N"
    Dim SystemDate As Date = DateUtil.getSystemDate
    Dim SyscodeDT As DataTable = Nothing
    Dim GroupAlterHash As Hashtable = New Hashtable
    Dim loginUser As String = AppContext.userProfile.userId
    Dim newAddOrderDetailDT As DataTable = PubAddOrderDetailDataTableFactory.getDataTable
    Private modGroupOrderDtlHash As Hashtable = New Hashtable
    Dim gblIsAdd As String = ""
    Dim gblIsDelete As String = ""
    Dim gblAddIndex As Integer = 0

    Public Property GroupOrderDtlHash() As Hashtable '一個群組依令內含物: {"PUBAddOrderDetail":datatable ; key(OptionOrder): datatable}
        Get
            Return modGroupOrderDtlHash
        End Get
        Set(ByVal value As Hashtable)
            modGroupOrderDtlHash = value
        End Set
    End Property

    Private AddOrderDT As DataTable = Nothing
    Private AddOrderDetailDT As DataTable = Nothing

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBGroupOrderMaintainUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        loadPubServiceManager()

        Me.KeyPreview = True


        Dim typeId() As Integer = {39, 510}
        SyscodeDT = pub.querySyscodeByTypeIds(typeId)

        ucl_combo_group_mark.DataSource = createComboBoxTable("groupmark", SyscodeDT.Select(" Type_Id = 39 "))
        ucl_combo_group_mark.uclValueIndex = "0"
        ucl_combo_group_mark.uclDisplayIndex = "0,1"


        If GroupOrderDtlHash IsNot Nothing Then
            If GroupOrderDtlHash.ContainsKey("PUBAddOrder") Then
                AddOrderDT = CType(GroupOrderDtlHash.Item("PUBAddOrder"), DataTable)
                If DataSetUtil.IsContainsData(AddOrderDT) Then
                    '....
                    AddOrderCode = CType(AddOrderDT.Rows(0).Item("Add_Order_Code"), String).Trim
                    GroupId = CType(AddOrderDT.Rows(0).Item("Group_Id"), String).Trim
                    AddOrderName = CType(AddOrderDT.Rows(0).Item("Add_Order_Name"), String).Trim

                    Dc = CType(AddOrderDT.Rows(0).Item("Dc"), String).Trim
                    IsNew = CType(AddOrderDT.Rows(0).Item("Is_New"), String).Trim

                    If Not AddOrderCode.Equals("") Then
                        ucl_txt_group_order.Text = AddOrderCode

                        '群組醫令鎖住
                        ucl_txt_group_order.Enabled = False
                        ucl_combo_group_mark.Enabled = False
                    End If

                    If Not GroupId.Equals("") Then
                        ucl_combo_group_mark.SelectedValue = GroupId
                    End If

                    If Not AddOrderName.Equals("") Then
                        txt_group_name.Text = AddOrderName
                    End If

                End If
            End If

            If GroupOrderDtlHash.ContainsKey("PUBAddOrderDetail") Then
                AddOrderDetailDT = CType(GroupOrderDtlHash.Item("PUBAddOrderDetail"), DataTable)
            Else
                AddOrderDetailDT = pub.queryAddOrderDetailData(AddOrderCode)
            End If

            If GroupOrderDtlHash.ContainsKey("PUBAddOptionalOrder") Then
                GroupAlterHash = CType(GroupOrderDtlHash.Item("PUBAddOptionalOrder"), Hashtable)
            Else
                '.....................................
            End If


            'MaxOrderDetailNo
            If DataSetUtil.IsContainsData(AddOrderDetailDT) Then

                For i As Integer = 0 To (AddOrderDetailDT.Rows.Count - 1)
                    Dim nowDetailNo As Integer = -1
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No")) Then
                        nowDetailNo = CType(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No"), Integer)

                        If nowDetailNo > MaxOrderDetailNo Then
                            MaxOrderDetailNo = nowDetailNo
                        End If
                    End If
                Next

            End If

        Else
            '新增
            Dc = "N"
            IsNew = "Y"

        End If



        'Hash版
        Dim ContentDS As DataSet = New DataSet
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, ContentDS)
        '-------
        '隨書隨選
        Dim cboGrid_cell1 As New ComboBoxGridCell()




        '從SQLServer查詢資料
        cboGrid_cell1.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer

        '設定隨輸隨選要查詢哪一種Table  可參考 UCLComboBoxGridBO 會從DB中查詢的值
        cboGrid_cell1.QueryData = ComboBoxGridCell.Data.PUB_Order_Mixed

        '根據Order_Code 作隨輸隨選 
        cboGrid_cell1.QueryType = ComboBoxGridCell.By.Code
        cboGrid_cell1.OrderTypeId = ComboBoxGridCell.OrderTypeIdData.None
        '根據Order_En_Name 作隨輸隨選  (同時間只能選擇一種 By.Code  or By.Name)
        'cboGrid_cell1.QueryType = ComboBoxGridCell.By.Name
        'cboGrid_cell1.ValueIndex = "2"


        '設定隨輸隨選所開起的GridView 的欄位名稱
        cboGrid_cell1.HeaderText = "醫令代碼,醫令名稱"
        '設定隨輸隨選所開起的GridView大小
        cboGrid_cell1.GridWidth = 700
        cboGrid_cell1.GridHeight = 300
        cboGrid_cell1.ColumnWidth = "100,300"
        cboGrid_cell1.VisibleColIndex = "0,1"
        cboGrid_cell1.ValueIndex = "0"

        '隨輸隨選元件名稱   配合 receiveComboBoxGrid Event的 CtlName
        cboGrid_cell1.CtlName = "cboGrid_cell1"
        '-------
        Dim txt_cell As New TextBoxCell()
        txt_cell.MaxLength = 20

        Dim txt_flo_cell As New TextBoxCell()
        txt_flo_cell.MaxLength = 20
        txt_flo_cell.uclTextType = TextBoxCell.uclTextTypeData.Money_Type
        '自費註記下拉選單
        Dim cbo_SelfCharge As New ComboBoxCell
        Dim SelfChargeDs As New DataSet
        Dim SelfChargeDt As New DataTable
        SelfChargeDt.Columns.Add("Value")
        SelfChargeDt.Rows.Add("Y")
        SelfChargeDt.Rows.Add("O")
        SelfChargeDt.Rows.Add("X")
        SelfChargeDs.Tables.Add(SelfChargeDt)
        cbo_SelfCharge.Ds = SelfChargeDs.Copy
        cbo_SelfCharge.DisplayIndex = 0

        '健保註記下拉選單
        Dim Insu_Charge As New ComboBoxCell
        Dim InsuChargeDs As New DataSet
        Dim InsuChargeDt As New DataTable
        InsuChargeDt.Columns.Add("Value")
        InsuChargeDt.Rows.Add("S")
        InsuChargeDt.Rows.Add("N")
        InsuChargeDt.Rows.Add("X")
        InsuChargeDt.Rows.Add("O")
        SelfChargeDt.Rows.Add("O")

        InsuChargeDs.Tables.Add(InsuChargeDt)
        Insu_Charge.Ds = InsuChargeDs.Copy
        Insu_Charge.DisplayIndex = 0

        _hashTable.Add(1, cboGrid_cell1)
        _hashTable.Add(9, New TextBoxCell)
        _hashTable.Add(15, cbo_SelfCharge)
        _hashTable.Add(16, Insu_Charge)



        'DGV
        ucl_dgv_content.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(ContentColumn)

        ucl_dgv_content.uclColumnWidth = "100,120,100,120,120,87,87,87,87,87,100,100,100,100,100,100,100,100,100,100"

        ucl_dgv_content.uclColumnAlignment = "0"
        'ucl_dgv_content.uclNonVisibleColIndex = "12,13,14"
        ucl_dgv_content.uclVisibleColIndex = "0,1,2,9,15,16,17,18,19,20"
        ucl_dgv_content.Initial(_hashTable)

        orderDetailToGrid()
        ucl_dgv_content.AddNewRow()
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

    Private Sub addNewRow()
        '檢查...

        Dim detailDR As DataRow = AddOrderDetailDT.NewRow
        MaxOrderDetailNo = MaxOrderDetailNo + 1
        gblAddIndex = MaxOrderDetailNo

        detailDR.Item("Add_Order_Detail_No") = MaxOrderDetailNo
        detailDR.Item("Is_New") = "Y"
        detailDR.Item("Dc") = "N"

        AddOrderDetailDT.Rows.Add(detailDR)

        '檢查前一筆資料是否有內容，否則不新增新的資料行
        If (AddOrderDetailDT.Rows.Count > 1) Then
            Dim i As Integer = (AddOrderDetailDT.Rows.Count - 2)
            If IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Code")) And IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Name")) And IsDBNull(AddOrderDetailDT.Rows(i).Item("Tqty")) And IsDBNull(AddOrderDetailDT.Rows(i).Item("Self_Charge_Flag")) And IsDBNull(AddOrderDetailDT.Rows(i).Item("Insu_Charge_Flag")) Then
                AddOrderDetailDT.Rows.RemoveAt(i + 1)
            End If
        End If

        orderDetailToGrid()

    End Sub


    Dim ContentDS As DataSet = New DataSet
    Dim ContentDT As DataTable = DataSetUtil.createDataTable("content", Nothing, ContentColumn, ContentColumnType)
    Private Sub orderDetailToGrid()

        '----------------------------------------------
        Try
            ContentDT.Clear()
            If DataSetUtil.IsContainsData(AddOrderDetailDT) Then
                For i As Integer = 0 To (AddOrderDetailDT.Rows.Count - 1)
                    Dim ContentDR As DataRow = ContentDT.NewRow

                    '"醫令代碼", "名稱", "換", "隨原項目計算", "劑量", "頻次", "用法", "天數", "總量", "計", "被連帶醫令可刪", "Add_Order_Detail_No"

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Code")) Then
                        ContentDR.Item(ContentColumn(0)) = CType(AddOrderDetailDT.Rows(i).Item("Order_Code"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Name")) Then
                        ContentDR.Item(ContentColumn(1)) = CType(AddOrderDetailDT.Rows(i).Item("Order_Name"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_By_Orig_Order_Code")) Then
                        ContentDR.Item(ContentColumn(3)) = CType(AddOrderDetailDT.Rows(i).Item("Is_By_Orig_Order_Code"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(3)) = "N"
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Dosage")) Then
                        ContentDR.Item(ContentColumn(4)) = CType(AddOrderDetailDT.Rows(i).Item("Dosage"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Frequency_Code")) Then
                        ContentDR.Item(ContentColumn(5)) = CType(AddOrderDetailDT.Rows(i).Item("Frequency_Code"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Usage_Code")) Then
                        ContentDR.Item(ContentColumn(6)) = CType(AddOrderDetailDT.Rows(i).Item("Usage_Code"), String).Trim
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Days")) Then
                        ContentDR.Item(ContentColumn(7)) = CType(AddOrderDetailDT.Rows(i).Item("Days"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Tqty")) Then
                        ContentDR.Item(ContentColumn(8)) = CType(AddOrderDetailDT.Rows(i).Item("Tqty"), String).Trim
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_Compute")) Then
                        ContentDR.Item(ContentColumn(9)) = CType(AddOrderDetailDT.Rows(i).Item("Is_Compute"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(9)) = "N"
                    End If

                    'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_Del")) Then
                    '    ContentDR.Item(ContentColumn(10)) = CType(AddOrderDetailDT.Rows(i).Item("Is_Del"), String).Trim
                    'Else
                    '    ContentDR.Item(ContentColumn(10)) = "N"
                    'End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No")) Then
                        ContentDR.Item(ContentColumn(11)) = CType(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No"), Integer)
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Self_Charge_Flag")) Then
                        ContentDR.Item(ContentColumn(14)) = CType(AddOrderDetailDT.Rows(i).Item("Self_Charge_Flag"), String)
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Insu_Charge_Flag")) Then
                        ContentDR.Item(ContentColumn(15)) = CType(AddOrderDetailDT.Rows(i).Item("Insu_Charge_Flag"), String)
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_New")) Then
                        ContentDR.Item(ContentColumn(12)) = CType(AddOrderDetailDT.Rows(i).Item("Is_New"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(12)) = "Y"
                    End If

                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Dc")) Then
                        ContentDR.Item(ContentColumn(13)) = CType(AddOrderDetailDT.Rows(i).Item("Dc"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(13)) = "Y"
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Create_User")) Then
                        ContentDR.Item(ContentColumn(16)) = CType(AddOrderDetailDT.Rows(i).Item("Create_User"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(16)) = AppContext.userProfile.userId
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Create_Time")) Then
                        ContentDR.Item(ContentColumn(17)) = DateUtil.TransDateTimeToROC(CType(AddOrderDetailDT.Rows(i).Item("Create_Time"), Date))
                    Else
                        ContentDR.Item(ContentColumn(17)) = DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Modified_User")) Then
                        ContentDR.Item(ContentColumn(18)) = CType(AddOrderDetailDT.Rows(i).Item("Modified_User"), String).Trim
                    Else
                        ContentDR.Item(ContentColumn(18)) = AppContext.userProfile.userId
                    End If
                    If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Modified_Time")) Then
                        ContentDR.Item(ContentColumn(19)) = DateUtil.TransDateTimeToROC(CType(AddOrderDetailDT.Rows(i).Item("Modified_Time"), Date))
                    Else
                        ContentDR.Item(ContentColumn(19)) = DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    End If

                    '如果Dc = N，把資料加入資料行
                    If CType(ContentDR.Item(ContentColumn(13)), String).Trim.Equals("N") Then
                        ContentDT.Rows.Add(ContentDR)
                    End If

                Next

                '刪除顯示在gridview的資料表上的資料也同時刪除輸入的資料表上的資料
                Dim tmpDt As DataTable = Nothing
                tmpDt = AddOrderDetailDT.Copy
                For k As Integer = (AddOrderDetailDT.Rows.Count - 1) To 0 Step -1
                    '判斷刪除
                    If CType(AddOrderDetailDT.Rows(k).Item(ContentColumn(13)), String).Trim.Equals("Y") Then
                        tmpDt.Rows.RemoveAt(k)
                    End If
                Next
                AddOrderDetailDT = Nothing
                AddOrderDetailDT = tmpDt.Copy

                '判斷是否為"新增醫令"或"刪除醫令"事件
                If gblIsAdd = "Y" Or gblIsDelete = "Y" Then
                    ContentDS.Tables.Remove("Content")
                    ContentDS.Tables.Add(ContentDT.Copy)
                End If

            End If


            If DataSetUtil.IsContainsData(ContentDS.Tables("Content")) Then

            Else
                ContentDS.Tables.Clear()
                ContentDS.Tables.Add(ContentDT.Copy)
            End If

            '----------------------------------------------

            ucl_dgv_content.SetDS(ContentDS.Copy)

            ucl_txt_group_order.Focus()

            gblIsAdd = ""
            gblIsDelete = ""
        Catch ex As Exception

        End Try


    End Sub

    Private Function gridToDatatable() As DataTable

        Dim AddOrderDtlDT As DataTable = AddOrderDetailDT.Copy
        AddOrderDtlDT.Clear()
        Dim Add_Order_Detail_No As Integer = 0

        Dim gridDS As DataSet = ucl_dgv_content.GetDBDS
        If DataSetUtil.IsContainsData(gridDS) Then
            Dim groupOrderDT As DataTable = gridDS.Tables(0).Copy




            For Each detaildr As DataRow In groupOrderDT.Rows
                '"醫令代碼", "名稱", "XX換", "隨原項目計算", "劑量", "頻次", "用法", "天數", "總量", "計", 
                '"被連帶醫令可刪", "Add_Order_Detail_No", "Is_New", "Dc"}
                For Each dr As DataRow In AddOrderDetailDT.Select("Add_Order_Detail_No ='" & CType(detaildr.Item(ContentColumn(11)), Integer) & "'")
                    dr("Add_Order_Code") = ucl_txt_group_order.Text
                    Add_Order_Detail_No += 1
                    dr("Add_Order_Detail_No") = Add_Order_Detail_No 'CType(detaildr.Item(ContentColumn(11)), Integer)
                    dr("Order_Code") = CType(detaildr.Item(ContentColumn(0)), String).Trim
                    dr("Is_By_Orig_Order_Code") = "Y"
                    dr("Dosage") = CType(detaildr.Item(ContentColumn(8)), Integer)
                    dr("Days") = 1
                    dr("Tqty") = CType(detaildr.Item(ContentColumn(8)), Integer)
                    dr("Usage_Code") = ""
                    dr("Frequency_Code") = ""
                    dr("Is_Compute") = "Y"
                    dr("Self_Charge_Flag") = CType(detaildr.Item(ContentColumn(14)), String).Trim
                    dr("Insu_Charge_Flag") = CType(detaildr.Item(ContentColumn(15)), String).Trim
                    dr("Dc") = "N" ' CType(detaildr.Item(ContentColumn(13)), String).Trim
                    dr("Is_New") = CType(detaildr.Item(ContentColumn(12)), String).Trim
                    dr("Create_User") = loginUser
                    dr("Create_Time") = SystemDate
                    dr("Modified_User") = loginUser
                    dr("Modified_Time") = SystemDate
                    If (Not IsDBNull(detaildr.Item(ContentColumn(1)))) Then
                        dr("Order_Name") = CType(detaildr.Item(ContentColumn(1)), String).Trim
                    Else
                        dr("Order_Name") = ""
                    End If
                Next
                If detaildr("醫令代碼").ToString.Trim() <> "" AndAlso detaildr("名稱").ToString.Trim() <> "" AndAlso _
                    detaildr("總量").ToString.Trim() <> "" AndAlso detaildr("自費計價註記").ToString.Trim() <> "" AndAlso detaildr("健保計價註記").ToString.Trim() <> "" Then

                    Dim AddOrderDtlDR As DataRow = AddOrderDtlDT.NewRow
                    AddOrderDtlDR.Item("Add_Order_Code") = ucl_txt_group_order.Text
                    Add_Order_Detail_No += 1
                    AddOrderDtlDR.Item("Add_Order_Detail_No") = Add_Order_Detail_No ' CType(detaildr.Item(ContentColumn(11)), Integer)
                    AddOrderDtlDR.Item("Order_Code") = CType(detaildr.Item(ContentColumn(0)), String).Trim
                    AddOrderDtlDR.Item("Is_By_Orig_Order_Code") = "Y"
                    AddOrderDtlDR.Item("Dosage") = CType(detaildr.Item(ContentColumn(8)), Integer)
                    AddOrderDtlDR.Item("Days") = 1
                    AddOrderDtlDR.Item("Tqty") = CType(detaildr.Item(ContentColumn(8)), Integer)
                    AddOrderDtlDR.Item("Usage_Code") = ""
                    AddOrderDtlDR.Item("Frequency_Code") = ""
                    AddOrderDtlDR.Item("Is_Compute") = "Y"
                    AddOrderDtlDR.Item("Self_Charge_Flag") = CType(detaildr.Item(ContentColumn(14)), String).Trim
                    AddOrderDtlDR.Item("Insu_Charge_Flag") = CType(detaildr.Item(ContentColumn(15)), String).Trim

                    AddOrderDtlDR.Item("Dc") = "N" ' CType(detaildr.Item(ContentColumn(13)), String).Trim

                    AddOrderDtlDR.Item("Is_New") = CType(detaildr.Item(ContentColumn(12)), String).Trim

                    AddOrderDtlDR.Item("Create_User") = loginUser
                    AddOrderDtlDR.Item("Create_Time") = SystemDate
                    AddOrderDtlDR.Item("Modified_User") = loginUser
                    AddOrderDtlDR.Item("Modified_Time") = SystemDate
                    If (Not IsDBNull(detaildr.Item(ContentColumn(1)))) Then
                        AddOrderDtlDR.Item("Order_Name") = CType(detaildr.Item(ContentColumn(1)), String).Trim
                    Else
                        AddOrderDtlDR.Item("Order_Name") = ""
                    End If

                    '......

                    AddOrderDtlDT.Rows.Add(AddOrderDtlDR)

                End If



            Next

            Return AddOrderDtlDT.Copy

            ',[Add_Order_Code]
            ',[Add_Order_Detail_No]
            ',[Order_Code]
            ',[Is_By_Orig_Order_Code]
            ',[Dosage]
            ',[Days]
            ',[Tqty]
            ',[Usage_Code]
            ',[Frequency_Code]
            ',[Is_Compute]
            ',[Is_Ask_Add]
            ',[Sheet_Code]
            ',[Is_Exclude_Duplicate]
            ',[Is_Ask_Exclude_Duplicate]
            ',[Is_Del]
            ',[Dc]
            ',[Create_User]
            ',[Create_Time]
            ',[Modified_User]
            ',[Modified_Time]



            '--------------------------------------


            'Dim ContentDR As DataRow = ContentDT.NewRow
            ''"醫令代碼", "名稱", "換", "隨原項目計算", "劑量", "頻次", "用法", "天數", "總量", "計", "被連帶醫令可刪", "Add_Order_Detail_No"

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Code")) Then
            '    ContentDR.Item(ContentColumn(0)) = CType(AddOrderDetailDT.Rows(i).Item("Order_Code"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Order_Name")) Then
            '    ContentDR.Item(ContentColumn(1)) = CType(AddOrderDetailDT.Rows(i).Item("Order_Name"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_By_Orig_Order_Code")) Then
            '    ContentDR.Item(ContentColumn(3)) = CType(AddOrderDetailDT.Rows(i).Item("Is_By_Orig_Order_Code"), String).Trim
            'Else
            '    ContentDR.Item(ContentColumn(3)) = "N"
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Dosage")) Then
            '    ContentDR.Item(ContentColumn(4)) = CType(AddOrderDetailDT.Rows(i).Item("Dosage"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Frequency_Code")) Then
            '    ContentDR.Item(ContentColumn(5)) = CType(AddOrderDetailDT.Rows(i).Item("Frequency_Code"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Usage_Code")) Then
            '    ContentDR.Item(ContentColumn(6)) = CType(AddOrderDetailDT.Rows(i).Item("Usage_Code"), String).Trim
            'End If
            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Days")) Then
            '    ContentDR.Item(ContentColumn(7)) = CType(AddOrderDetailDT.Rows(i).Item("Days"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Tqty")) Then
            '    ContentDR.Item(ContentColumn(8)) = CType(AddOrderDetailDT.Rows(i).Item("Tqty"), String).Trim
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_Compute")) Then
            '    ContentDR.Item(ContentColumn(9)) = CType(AddOrderDetailDT.Rows(i).Item("Is_Compute"), String).Trim
            'Else
            '    ContentDR.Item(ContentColumn(9)) = "N"
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_Del")) Then
            '    ContentDR.Item(ContentColumn(10)) = CType(AddOrderDetailDT.Rows(i).Item("Is_Del"), String).Trim
            'Else
            '    ContentDR.Item(ContentColumn(10)) = "N"
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No")) Then
            '    ContentDR.Item(ContentColumn(11)) = CType(AddOrderDetailDT.Rows(i).Item("Add_Order_Detail_No"), Integer)
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Is_New")) Then
            '    ContentDR.Item(ContentColumn(12)) = CType(AddOrderDetailDT.Rows(i).Item("Is_New"), String).Trim
            'Else
            '    ContentDR.Item(ContentColumn(12)) = "Y"
            'End If

            'If Not IsDBNull(AddOrderDetailDT.Rows(i).Item("Dc")) Then
            '    ContentDR.Item(ContentColumn(13)) = CType(AddOrderDetailDT.Rows(i).Item("Dc"), String).Trim
            'Else
            '    ContentDR.Item(ContentColumn(13)) = "Y"
            'End If

            'If CType(ContentDR.Item(ContentColumn(13)), String).Trim.Equals("N") Then
            '    ContentDT.Rows.Add(ContentDR)
            'End If


            '-------------------------------------------------
             
            ' Return AddOrderDetailDT.Copy
        Else
            Return Nothing
        End If

    End Function

    Private Function condToDatatable() As DataTable

        Dim AddOrderColumn() As String = {"Add_Order_Code", "Add_Order_Name", "Group_Id", "Dc", "Is_New"}
        Dim AddOrderColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

        Dim PUBAddOrderDT As DataTable = DataSetUtil.createDataTable("PUBAddOrder", Nothing, AddOrderColumn, AddOrderColumnType)

        Dim orderDR As DataRow = PUBAddOrderDT.NewRow
        orderDR.Item("Add_Order_Code") = ucl_txt_group_order.Text.Trim
        orderDR.Item("Add_Order_Name") = txt_group_name.Text.Trim
        orderDR.Item("Group_Id") = ucl_combo_group_mark.SelectedValue
        orderDR.Item("Dc") = Dc
        orderDR.Item("Is_New") = IsNew

        PUBAddOrderDT.Rows.Add(orderDR)

        Return PUBAddOrderDT

    End Function





    Private Sub Clear()

        ucl_txt_group_order.Text = ""
        ucl_combo_group_mark.SelectedIndex = -1
        txt_group_name.Text = ""

        ucl_dgv_content.ClearDS()

        ucl_txt_group_order.Focus()

    End Sub

    ''' <summary>
    ''' 刪除群組醫令細目
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub removeAddOrderDetail()

        Try
            'Update PUB_Add_Order Set Dc=Y。

            'TODO
            '存進remove的地方
            Dim selectIndex() As Integer = ucl_dgv_content.GetSelectedIndex

            If selectIndex IsNot Nothing AndAlso selectIndex.Length > 0 Then

                For i As Integer = 0 To (selectIndex.Length - 1)
                    If selectIndex(i) < AddOrderDetailDT.Rows.Count - 1 Then
                        AddOrderDetailDT.Rows(selectIndex(i)).Item("Dc") = "Y"
                    End If
                Next

                orderDetailToGrid()

            End If

        Catch ex As Exception

        End Try
       
    End Sub


    Private Sub confirm()
        '回去



        'AddOrderDetailDT先處理正確


        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            isConfirm = True
            '檢查資料內容
            'TODO

            AddOrderDT = condToDatatable()
            AddOrderDetailDT = gridToDatatable()

            If GroupOrderDtlHash.ContainsKey("PUBAddOrder") Then
                GroupOrderDtlHash.Item("PUBAddOrder") = AddOrderDT
            Else
                GroupOrderDtlHash.Add("PUBAddOrder", AddOrderDT)
            End If
            If GroupOrderDtlHash.ContainsKey("PUBAddOrderDetail") Then
                GroupOrderDtlHash.Item("PUBAddOrderDetail") = AddOrderDetailDT
            Else
                GroupOrderDtlHash.Add("PUBAddOrderDetail", AddOrderDetailDT)
            End If

            'TODO AddOrderDetailDT >> key, datatable

            If GroupOrderDtlHash.ContainsKey("PUBAddOptionalOrder") Then
                GroupOrderDtlHash.Item("PUBAddOptionalOrder") = GroupAlterHash
            Else
                GroupOrderDtlHash.Add("PUBAddOptionalOrder", GroupAlterHash)
            End If


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
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean


        Me.ShowDialog()

        Return isConfirm

    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBGroupOrderMaintainUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                'EnterQuery()
            Case Keys.F12
                confirm()
            Case Keys.F5
                'clear()
        End Select
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucl_dgv_content_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucl_dgv_content.CellClick

        If DataSetUtil.IsContainsData(ucl_dgv_content.GetDBDS) Then

            Select Case e.ColumnIndex
                Case 3
                    '確認該筆資料是完整的 才彈出視窗
                    Try

                        Dim OrderCode As String = ""
                        Dim AddOrderDetailNo As Integer = 0
                        If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(0))) Then
                            OrderCode = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(0)), String).Trim
                        End If

                        If Not IsDBNull(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(11))) Then
                            AddOrderDetailNo = CType(ucl_dgv_content.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ContentColumn(11)), Integer)
                        End If

                        Dim key As String = OrderCode & "-" & AddOrderDetailNo

                        Dim enterDT As DataTable = Nothing

                        If GroupAlterHash.ContainsKey(key) Then
                            enterDT = CType(GroupAlterHash.Item(key), DataTable)
                            Dim alter As PUBAddOptionOrderUI = New PUBAddOptionOrderUI(AddOrderCode, OrderCode, AddOrderDetailNo, enterDT)
                            Dim result As Boolean = alter.ShowAndPrepareReturnData()
                            If result Then
                                GroupAlterHash.Item(key) = alter.OrderAlterData
                            Else

                            End If
                        Else
                            Dim alter As PUBAddOptionOrderUI = New PUBAddOptionOrderUI(AddOrderCode, OrderCode, AddOrderDetailNo, Nothing)
                            Dim result As Boolean = alter.ShowAndPrepareReturnData()
                            If result Then
                                GroupAlterHash.Add(key, alter.OrderAlterData)
                            Else

                            End If
                        End If
                    Catch ex As Exception

                    End Try





            End Select

        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Clear()
        ucl_dgv_content.AddNewRow()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        gblIsDelete = "Y"
        'removeAddOrderDetail()
        Dim selectIndex() As Integer = ucl_dgv_content.GetSelectedIndex

        If selectIndex IsNot Nothing AndAlso selectIndex.Length > 0 Then

            For i As Integer = (selectIndex.Length - 1) To 0 Step -1
                If selectIndex(i) < ucl_dgv_content.Rows.Count - 1 Then
                    ucl_dgv_content.RemoveRowAt(selectIndex(i))
                End If
            Next
            'orderDetailToGrid()
        End If

        'ucl_dgv_content.AddNewRow()
    End Sub

    Private Sub btn_addrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addrow.Click
        gblIsAdd = "Y"
        addNewRow()
        'dt要加入empty grid
    End Sub

    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        '確認後丟回去
        confirm()
    End Sub

#End Region

    '加入必要的Event Handle
    Dim WithEvents pvtReceiveComboBoxGridMgr As EventManager = EventManager.getInstance

    '處理隨輸隨選選擇一筆資料時所觸發的Eventˇㄉ
    Private Sub receiveComboBoxGrid(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As DataGridViewRow) Handles pvtReceiveComboBoxGridMgr.UclOpenWindowComboBoxGridValue

        If Not ucl_dgv_content.IsComboBoxGridSetValue Then
            '此段請加上
            Exit Sub
        End If

        If ctlName = "cboGrid_cell1" Then

            '回寫資料到GridDS , DBDS 的Order_Code
            ucl_dgv_content.Rows(rowIndex).Cells("醫令代碼").Value = row.Cells("Order_Code").Value.ToString.Trim
            ucl_dgv_content.GetGridDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells("Order_Code").Value.ToString.Trim
            ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells("Order_Code").Value.ToString.Trim


            '回寫資料到GridDS , DBDS 的 Order_En_name
            ucl_dgv_content.GetGridDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells("Order_En_Name").Value.ToString.Trim
            ucl_dgv_content.GetDBDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells("Order_En_Name").Value.ToString.Trim

            'row的值是根據隨輸隨選 所選擇某一筆資料整個Row的值
            '以上適情況將row.Cell的值填入 GridView GridDS , DBDS 中

            ucl_dgv_content.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If rowIndex = ucl_dgv_content.Rows.Count - 1 Then

                '適需要添加此行,會自動在最後一行新增一空白列,可讓使用者繼續輸入
                'ucl_dgv_content.AddNewRow()
            End If

            ucl_dgv_content.Refresh()
            ucl_dgv_content.CurrentCell = ucl_dgv_content.Rows(ucl_dgv_content.Rows.Count - 1).Cells("醫令代碼")

        End If
    End Sub


    Private Sub ucl_dgv_content_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles ucl_dgv_content.CellValueChanged
        Try
            If e.ColumnIndex = 1 AndAlso e.RowIndex >= 0 Then
                '當Order_Code欄位值改變後，新增一row
                If ucl_dgv_content.Rows.Count = 0 Then
                    ucl_dgv_content.AddNewRow()
                ElseIf ucl_dgv_content.Rows(ucl_dgv_content.Rows.Count - 1).Cells("醫令代碼").Value.ToString.Trim <> "" Then
                    ucl_dgv_content.AddNewRow()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
