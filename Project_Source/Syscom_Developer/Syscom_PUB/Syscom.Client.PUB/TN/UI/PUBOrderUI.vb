Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text

Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL


'Imports nckuh.server.pub

Public Class PUBOrderUI

    '============================
    '程式說明：醫療支付公用主作檔-處置/其他
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================
    '*************************************************************************************************
    ' 修改日期    修改者     項目
    '-------------------------------------------------------------------------------------------------
    '2014.02.11   唐子晴    1. 加入使用者權限 , 設定僅有管理者才有新增、修改、刪除功能
    '                          (管理者員工號:001528、010024、032135)
    '                       2. 執行刪除時 , 新增Log紀錄
    '2014.02.19   唐子晴    1. 新增異動日期欄位於醫令項目價格中
    '*************************************************************************************************

#Region "########## 宣告物件 ##########"


    Dim loginUser As String = AppContext.userProfile.userId

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    '2010-04-28 delete by Alan-OK
    '                                      0          1       2       3        4        5         6           7           8           9            10           11          12          13         14         15              16             17          18      19       20                   
    'modify by 唐子晴 2014.02.19---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ''Dim OrderPriceColumn() As String = {"主身分", "生效日", "單價", "差額", "停止日", "比率", "急件加成", "兒童加成", "牙科加成", "科別加成", "群組醫令碼", "門診可用", "急診可用", "住院可用", "健保碼", "組合健保碼", "健保費用項目", "健保醫令類別", "Dc", "Is_New"}
    ''Dim OrderPriceColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeString, _
    ''                                        DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
    ''                                        DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
    Dim OrderPriceColumn() As String = {"主身分", "生效日", "單價", "差額", "停止日", "比率", "急件加成", "兒童加成", "牙科加成", "科別加成", "群組醫令碼", "門診可用", "急診可用", "住院可用", "健保碼", "組合健保碼", "健保費用項目", "健保醫令類別", "Dc", "Is_New", "異動日期"}
    Dim OrderPriceColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeString, _
                                            DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                            DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    'Syscode
    Dim AddSyscodeDT As DataTable = Nothing
    Dim GroupSyscodeDT As DataTable = Nothing
    Dim NhiSyscodeDT As DataTable = Nothing
    '畫面上keep資料
    Dim keepOrderDT As DataTable
    Dim keepOrderMajorcareDT As DataTable
    Dim keepOrderPriceDT As DataTable
    Dim keepOrderPriceHistoryDT As DataTable
    '療程控制
    Dim cureControlDT As DataTable = Nothing
    'Grid內 彈出暫存的hash
    Dim emgHash As Hashtable = New Hashtable
    Dim chdHash As Hashtable = New Hashtable
    Dim tohHash As Hashtable = New Hashtable
    Dim hlyHash As Hashtable = New Hashtable
    Dim goHash As Hashtable = New Hashtable

    Dim SystemDate As Date = DateUtil.getSystemDate
    Dim GridSelectedIndexList As ArrayList = New ArrayList

    Dim AllowOrderTypeId() As String = {"D", "I"}
    'add by 唐子晴 2014.02.11 --------------------
    Dim AllowOrderMode() As String = {"D", "E"} 'D-刪除 , E-修改
    Dim authority As Boolean = False
    '---------------------------------------------
    Dim checkMainIdDT As DataTable = Nothing

    Dim defaultEndDate As Date = Date.Parse("2999/12/31")

    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager

    Dim gblErrorMsg As String
    Dim gblCellColumnIndex, gblCellRowIndex As Integer
    Dim gblEffectDate As String
    Dim gblIsInventory As String
    Dim gblIsIcdCheck As String
    Dim gblIsOrderExist As Boolean = False
    Dim gblInsuCode As String




#Region "特殊處理狀態"
    'update
    Private SpecialProcessStatus0 As String = "102400"
    'insert
    Private SpecialProcessStatus1 As String = "102401"
    Private SpecialProcessStatus2 As String = "102402"
    Private SpecialProcessStatus3 As String = "102403"
    Private SpecialProcessStatus4 As String = "102404"
#End Region

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBOrderUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        '2010-04-28 delete by Alan-OK
        'PUBOrderUI_ucl_dcbg_order.uclDc = ""
        Me.KeyPreview = True
        '-------------------------
        'PUBOrderUI_ucl_txtcq_ordercode.Enabled = True
        cb_OrderCheck.Enabled = False
        cb_OrderCheck.Visible = False
        btn_OrderCheck.Enabled = True
        cb_Indication.Enabled = False
        cb_Indication.Visible = False
        btn_Indication.Enabled = True
        cb_NhiSheet.Enabled = False
        btn_Nhi.Enabled = False
        btn_Delete.Enabled = True
        btn_Query.Enabled = False

        ' PUBOrderUI_ucl_txtcq_ordercode.Visible = True
        btn_Delete.Visible = True
        btn_Query.Visible = False

        lb_NhiCode.Visible = False
        txt_NhiCode.Visible = False
        lb_Name.Visible = False
        txt_Name.Visible = False
        '-------------------------

        '-------------------------------
        'textCodeQuer設定
        'PUBOrderUI_ucl_txtcq_ordercode.uclIsShowMsgBox = True
        'PUBOrderUI_ucl_txtcq_ordercode.uclIsTextAutoClear = True
        'PUBOrderUI_ucl_txtcq_ordercode.uclIsReturnDS = True
        ' PUBOrderUI_ucl_txtcq_ordercode.uclQueryValue = "D"
        '-------------------------------


        Me.KeyPreview = True

        loadPubServiceManager()


        'Grid combo使用
        Dim MainIDDS As DataSet = New DataSet
        Dim InsuFeeItemDS As DataSet = New DataSet
        Dim InsuOrderTypeDS As DataSet = New DataSet



        Dim mainIdentityDT As DataTable = Nothing
        Dim insuFeeItemDT As DataTable = Nothing
        Dim insuOrderTypeDT As DataTable = Nothing


        '初始資料
        Dim initDS As DataSet = pub.initPUBOrderInfo("Order")

        '------------------------------
        '醫令類型(固定..)
        Dim orderTypeDT As DataTable = DataSetUtil.createDataTable("ordertype", Nothing, ComboBoxColumn, ComboBoxColumnType)

        Dim drD As DataRow = orderTypeDT.NewRow
        drD.Item(ComboBoxColumn(0)) = AllowOrderTypeId(0)
        drD.Item(ComboBoxColumn(1)) = "共通性處置(行政類醫令)"
        orderTypeDT.Rows.Add(drD)

        'Dim drI As DataRow = orderTypeDT.NewRow
        'drI.Item(ComboBoxColumn(0)) = AllowOrderTypeId(1)
        'drI.Item(ComboBoxColumn(1)) = "健保申報用"
        'orderTypeDT.Rows.Add(drI)

        uclcomb_OrderType.DataSource = orderTypeDT
        uclcomb_OrderType.uclValueIndex = "0"
        uclcomb_OrderType.uclDisplayIndex = "0,1"
        uclcomb_OrderType.SelectedValue = AllowOrderTypeId(0)

        Dim pvtOPDSelectDS As New DataSet
        pvtOPDSelectDS.Tables.Add("Select_Data")
        pvtOPDSelectDS.Tables(0).Columns.Add("Select_Id")
        pvtOPDSelectDS.Tables(0).Columns.Add("Select_Name")

        pvtOPDSelectDS.Tables(0).Rows.Add()
        pvtOPDSelectDS.Tables(0).Rows(0).Item("Select_Id") = "N"
        pvtOPDSelectDS.Tables(0).Rows(0).Item("Select_Name") = "門診不可用"

        pvtOPDSelectDS.Tables(0).Rows.Add()
        pvtOPDSelectDS.Tables(0).Rows(1).Item("Select_Id") = "Y"
        pvtOPDSelectDS.Tables(0).Rows(1).Item("Select_Name") = "門診可用"

        pvtOPDSelectDS.Tables(0).Rows.Add()
        pvtOPDSelectDS.Tables(0).Rows(2).Item("Select_Id") = "C"
        pvtOPDSelectDS.Tables(0).Rows(2).Item("Select_Name") = "門診批價可用"

        cbo_OPD.DataSource = pvtOPDSelectDS.Tables(0).Copy
        cbo_OPD.uclValueIndex = "0"
        cbo_OPD.uclDisplayIndex = "0,1"


        Dim pvtEMGSelectDS As New DataSet
        pvtEMGSelectDS.Tables.Add("Select_Data")
        pvtEMGSelectDS.Tables(0).Columns.Add("Select_Id")
        pvtEMGSelectDS.Tables(0).Columns.Add("Select_Name")

        pvtEMGSelectDS.Tables(0).Rows.Add()
        pvtEMGSelectDS.Tables(0).Rows(0).Item("Select_Id") = "N"
        pvtEMGSelectDS.Tables(0).Rows(0).Item("Select_Name") = "急診不可用"

        pvtEMGSelectDS.Tables(0).Rows.Add()
        pvtEMGSelectDS.Tables(0).Rows(1).Item("Select_Id") = "Y"
        pvtEMGSelectDS.Tables(0).Rows(1).Item("Select_Name") = "急診可用"

        pvtEMGSelectDS.Tables(0).Rows.Add()
        pvtEMGSelectDS.Tables(0).Rows(2).Item("Select_Id") = "C"
        pvtEMGSelectDS.Tables(0).Rows(2).Item("Select_Name") = "急診批價可用"

        cbo_EMG.DataSource = pvtEMGSelectDS.Tables(0).Copy
        cbo_EMG.uclValueIndex = "0"
        cbo_EMG.uclDisplayIndex = "0,1"

        Dim pvtIPDSelectDS As New DataSet
        pvtIPDSelectDS.Tables.Add("Select_Data")
        pvtIPDSelectDS.Tables(0).Columns.Add("Select_Id")
        pvtIPDSelectDS.Tables(0).Columns.Add("Select_Name")

        pvtIPDSelectDS.Tables(0).Rows.Add()
        pvtIPDSelectDS.Tables(0).Rows(0).Item("Select_Id") = "N"
        pvtIPDSelectDS.Tables(0).Rows(0).Item("Select_Name") = "住院不可用"

        pvtIPDSelectDS.Tables(0).Rows.Add()
        pvtIPDSelectDS.Tables(0).Rows(1).Item("Select_Id") = "Y"
        pvtIPDSelectDS.Tables(0).Rows(1).Item("Select_Name") = "住院可用"

        pvtIPDSelectDS.Tables(0).Rows.Add()
        pvtIPDSelectDS.Tables(0).Rows(2).Item("Select_Id") = "C"
        pvtIPDSelectDS.Tables(0).Rows(2).Item("Select_Name") = "住院批價可用"

        cbo_IPD.DataSource = pvtIPDSelectDS.Tables(0).Copy
        cbo_IPD.uclValueIndex = "0"
        cbo_IPD.uclDisplayIndex = "0,1"
        '-------------------------------

        '2010-04-28 delete by Alan-OK
        'If uclcomb_OrderType.SelectedIndex > 0 Then
        '    'Dim whereStr As String = " Order_Type_Id = '" & uclcomb_OrderType.SelectedValue & "' and Dc <> 'Y' "
        '    Dim whereStr As String = " Order_Type_Id = '" & uclcomb_OrderType.SelectedValue & "' "
        '    PUBOrderUI_ucl_dcbg_order.uclWhereCondition = whereStr
        'Else
        '    'Dim whereStr As String = " Dc <> 'Y' "
        '    'ucl_dcbg_order.uclWhereCondition = whereStr
        'End If

        ucl_dtp_enddate.SetValue(defaultEndDate)

        '讀取DB
        If DataSetUtil.IsContainsData(initDS) Then

            If initDS.Tables.Contains("pubsyscode") Then

                Dim selectOutDRs() As DataRow

                '院內費用項目
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 41 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    uclcomb_HosItem.DataSource = createComboBoxTable("feeitem", selectOutDRs)
                    uclcomb_HosItem.uclValueIndex = "0"
                    uclcomb_HosItem.uclDisplayIndex = "0,1"
                Else
                    '
                End If

                '醫令治療屬性
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 36 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    uclcomb_order_treat_prop.DataSource = createComboBoxTable("ordertreat", selectOutDRs)
                    uclcomb_order_treat_prop.uclValueIndex = "0"
                    uclcomb_order_treat_prop.uclDisplayIndex = "0,1"
                Else
                    '
                End If

                '固定費用
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 69 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    uclcomb_fix_fee.DataSource = createComboBoxTable("fixfee", selectOutDRs)
                    uclcomb_fix_fee.uclValueIndex = "0"
                    uclcomb_fix_fee.uclDisplayIndex = "0,1"
                Else
                    '
                End If

                '管理分類
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 902 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    uclcb_classify.DataSource = createComboBoxTable("classify", selectOutDRs)
                    uclcb_classify.uclValueIndex = "0"
                    uclcb_classify.uclDisplayIndex = "0,1"
                Else
                    '
                End If


                '---------------------------------------------------------------------
                'cell combo  : 18 主身分, 43 健保費用項目,  501 健保醫令類別
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 18 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    mainIdentityDT = createComboBoxTable("mainidentity", selectOutDRs)

                    checkMainIdDT = mainIdentityDT.Copy
                Else
                    '
                End If

                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 43 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    insuFeeItemDT = createComboBoxTable("insufeeitem", selectOutDRs)
                Else
                    '
                End If

                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 501 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    insuOrderTypeDT = createComboBoxTable("insuordertype", selectOutDRs)
                Else
                    '
                End If

                '39, 510  群組註記
                '----------------------------------------------------------------------
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id in (39, 510) ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    GroupSyscodeDT = PubSyscodeDataTableFactory.getDataTable
                    GroupSyscodeDT.TableName = "pubsyscode"
                    For i As Integer = 0 To (selectOutDRs.Length - 1)
                        GroupSyscodeDT.Rows.Add(selectOutDRs(i).ItemArray)
                    Next

                Else
                    '
                End If

                '加成用
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id in (18,19,41) ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    AddSyscodeDT = PubSyscodeDataTableFactory.getDataTable
                    AddSyscodeDT.TableName = "pubsyscode"
                    For i As Integer = 0 To (selectOutDRs.Length - 1)
                        AddSyscodeDT.Rows.Add(selectOutDRs(i).ItemArray)
                    Next

                Else
                    '
                End If

                '健保用
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id in (40,511) ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    NhiSyscodeDT = PubSyscodeDataTableFactory.getDataTable
                    NhiSyscodeDT.TableName = "pubsyscode"
                    For i As Integer = 0 To (selectOutDRs.Length - 1)
                        NhiSyscodeDT.Rows.Add(selectOutDRs(i).ItemArray)
                    Next
                Else
                    '
                End If

            End If

            If initDS.Tables.Contains("majorcare") Then
                uclcomb_majorcare.DataSource = createComboBoxTable("majorcare", initDS.Tables("majorcare"))
                uclcomb_majorcare.uclValueIndex = "0"
                uclcomb_majorcare.uclDisplayIndex = "0,1"
            End If

            If initDS.Tables.Contains("unit") Then
                uclcomb_ChargeUnit.DataSource = createComboBoxTable("unit", initDS.Tables("unit"))
                uclcomb_ChargeUnit.uclValueIndex = "0"
                uclcomb_ChargeUnit.uclDisplayIndex = "0,1"
            End If

        End If

        '日期部份

        'SystemDate 
        If initDS.Tables.Contains("systemdate") Then
            If DataSetUtil.IsContainsData(initDS.Tables("systemdate")) Then
                SystemDate = CType(initDS.Tables("systemdate").Rows(0).Item("System_Date"), Date)
            End If
        End If

        ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))

        '-------------------------------------------------------------------------------------------------------------------
        'DGV部分

        '建立gridview
        'ucldgv_OrderItem
        '2010-04-28 delete by Alan-OK
        ucldgv_OrderPrice.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(OrderPriceColumn)
        'modify by 唐子晴 2014.02.19----------------------------------------------------------------------------------------
        ''ucldgv_OrderPrice.uclColumnWidth = "75, 90, 75, 75, 90,60, 60, 60, 60, 60, 0, 0, 0, 0, 180,30, 120, 120, 0, 0"
        ucldgv_OrderPrice.uclColumnWidth = "75, 90, 75, 75, 90,60, 60, 60, 60, 60, 0, 0, 0, 0, 180,30, 120, 120, 0, 0, 150"
        '-----------------------------------------------------------------------------------------------------------------
        ucldgv_OrderPrice.uclColumnAlignment = "0"
        ucldgv_OrderPrice.uclNonVisibleColIndex = "10,11,12,13,15,18,19"


        'init Grid資料
        '----------------------------------------------
        Dim OrderPriceDS As DataSet = New DataSet
        Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
        OrderPriceDS.Tables.Add(OrderPriceDT)
        '----------------------------------------------


        'Hash版
        Dim _hashTable As Hashtable = New Hashtable

        Dim txt_cell As New TextBoxCell()
        Dim date_cell As New DtpCell()
        Dim ratio_cell As New TextBoxCell()
        Dim btn_cell As New ButtonCell()
        Dim chk_cell As New CheckBoxCell()

        'add by 唐子晴 2014.02.19---------------------
        Dim txt_cell_readOnly As New UCLTextBoxUC()
        txt_cell_readOnly.uclReadOnly = True
        '-------------------------------------------
        '宣告Datagridveiw中 EndDate的欄位屬性
        Dim EndDate_date_cell As New UCLDateTimePickerCellUC()
        EndDate_date_cell.Enabled = False


        _hashTable.Add(-1, OrderPriceDS)

        'MVC的view
        '1.主身分
        If DataSetUtil.IsContainsData(mainIdentityDT) Then
            Dim cbo_mainidentitycell As New ComboBoxCell()
            'DS
            MainIDDS.Tables.Add(mainIdentityDT)
            cbo_mainidentitycell.Ds = MainIDDS
            cbo_mainidentitycell.DisplayIndex = "1"
            cbo_mainidentitycell.ValueIndex = "0"

            _hashTable.Add(0, cbo_mainidentitycell)
        End If

        _hashTable.Add(1, date_cell)
        _hashTable.Add(2, txt_cell)
        _hashTable.Add(3, txt_cell)
        _hashTable.Add(4, EndDate_date_cell)
        _hashTable.Add(5, ratio_cell)
        _hashTable.Add(6, chk_cell)
        _hashTable.Add(7, chk_cell)
        _hashTable.Add(8, chk_cell)
        _hashTable.Add(9, chk_cell)
        _hashTable.Add(14, txt_cell)
        ' _hashTable.Add(15, btn_cell)

        'add by 唐子晴 2014.02.19---------------
        _hashTable.Add(20, txt_cell_readOnly)
        '-------------------------------------

        Dim chk_typecell As New CheckBoxCell()
        'check

        '_hashTable.Add(10, chk_typecell)
        '_hashTable.Add(11, chk_typecell)
        '_hashTable.Add(12, chk_typecell)

        If DataSetUtil.IsContainsData(insuFeeItemDT) Then
            Dim cbo_insufeeitemcell As New ComboBoxCell()
            'DS
            InsuFeeItemDS.Tables.Add(insuFeeItemDT)
            cbo_insufeeitemcell.Ds = InsuFeeItemDS
            cbo_insufeeitemcell.DisplayIndex = "1"
            cbo_insufeeitemcell.ValueIndex = "0"

            _hashTable.Add(16, cbo_insufeeitemcell)
        End If

        If DataSetUtil.IsContainsData(insuOrderTypeDT) Then
            Dim cbo_insuordertypecell As New ComboBoxCell()
            'DS
            InsuOrderTypeDS.Tables.Add(insuOrderTypeDT)
            cbo_insuordertypecell.Ds = InsuOrderTypeDS
            cbo_insuordertypecell.DisplayIndex = "1"
            cbo_insuordertypecell.ValueIndex = "0"

            _hashTable.Add(17, cbo_insuordertypecell)
        End If

        ucldgv_OrderPrice.Initial(_hashTable)

        addNewGridRow()
        '2010-04-28 delete by Alan-OK
        PUBOrderUI_ucl_txtcq_ordercode.Focus()
        'PUBOrderUI_ucl_dcbg_order.Focus()
        'ucl_txtcq_ordercode.Focus()

        '2011-07-14 Add By Alan
        '判斷登入角色若為Pub_Maintain,則不允許按確定與刪除Button
        'If Not AppContext.userProfile.userMemberOf.Contains("Pub_Maintain") Then
        '    btn_Confirm.Enabled = False
        '    btn_Delete.Enabled = False
        'End If

        'add by 唐子晴 2014.02.11 ------------------------------------------------------------------------------
        'Dim sysCodeDRs() As DataRow = initDS.Tables("pubsyscode").Select(" Type_Id = 1262 and Code_Name='" & loginUser & "' ")
        'If sysCodeDRs IsNot Nothing AndAlso sysCodeDRs.Length > 0 Then
        '    btn_Confirm.Enabled = True
        '    btn_Delete.Enabled = True
        '    authority = True
        'Else
        '    btn_Confirm.Enabled = False
        '    btn_Delete.Enabled = False
        '    authority = False
        'End If
        '--------------------------------------------------------------------------------------------------------
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

    Private Function checkCorrectType(ByVal orderTypeId As String) As Boolean
        Dim correct As Boolean = False
        For i As Integer = 0 To (AllowOrderTypeId.Length - 1)
            If orderTypeId.Equals(AllowOrderTypeId(i)) Then
                correct = True
            End If
        Next

        Return correct
    End Function

    '-----------------------------
    '查詢後的資料處置動作
    '-----------------------------
    ''' <summary>
    ''' 將DB資料對映到UI
    ''' </summary>
    ''' <param name="OrderDS"></param>
    ''' <remarks></remarks>
    Private Sub OrderRelatedDataToUI(ByVal OrderDS As DataSet, ByVal leaveFlag As Boolean)
        '醫令資料 to UI
        cb_pricehistory.Checked = False
        ucldgv_OrderPrice.Enabled = True
        gblIsInventory = "N"
        gblIsIcdCheck = "N"
        gblIsOrderExist = False

        If DataSetUtil.IsContainsData(OrderDS) Then

            If OrderDS.Tables.Contains(PubOrderDataTableFactory.tableName) Then

                Dim dbOrderDT As DataTable = OrderDS.Tables(PubOrderDataTableFactory.tableName)

                Dim dbOrderTypeId As String = CType(dbOrderDT.Rows(0).Item("Order_Type_Id"), String).Trim

                If checkCorrectType(dbOrderTypeId) Then
                    keepOrderDT = OrderDS.Tables(PubOrderDataTableFactory.tableName).Copy
                    orderToConditionUI(dbOrderDT)

                    '有master, detail才需顯示
                    'TODO:  Majorcare的項目從pub_majorcare抓,  但存detail檔在pub_order_majorcare
                    If OrderDS.Tables.Contains(PubOrderMajorcareDataTableFactory.tableName) Then
                        Dim dbOrderMajorcareDT As DataTable = OrderDS.Tables(PubOrderMajorcareDataTableFactory.tableName)
                        keepOrderMajorcareDT = OrderDS.Tables(PubOrderMajorcareDataTableFactory.tableName).Copy
                        orderMajorcareToCondition(dbOrderMajorcareDT)
                    End If

                    'TODO: cure_control
                    If OrderDS.Tables.Contains(PubCureControlDataTableFactory.tableName) Then
                        Dim dbCureControlDT As DataTable = OrderDS.Tables(PubCureControlDataTableFactory.tableName).Copy
                        cureControlToCondition(dbCureControlDT)
                    End If

                    '*************** 歷史資料暫存
                    If OrderDS.Tables.Contains(PubOrderPriceDataTableFactory.tableName & "-" & "History") Then
                        keepOrderPriceHistoryDT = OrderDS.Tables(PubOrderPriceDataTableFactory.tableName & "-" & "History").Copy
                    Else

                    End If

                    If OrderDS.Tables.Contains(PubOrderPriceDataTableFactory.tableName) Then
                        Dim dbOrderPriceDT As DataTable = OrderDS.Tables(PubOrderPriceDataTableFactory.tableName)
                        keepOrderPriceDT = OrderDS.Tables(PubOrderPriceDataTableFactory.tableName).Copy


                        orderPriceToGrid(dbOrderPriceDT, False)


                    Else

                    End If

                    gblIsOrderExist = True

                Else
                    '該醫令非處置/其他類別
                    'MessageHandling.showError("該醫令非處置/其他類別")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令非處置/其他類別"}, "")
                    Clear()
                End If

            Else
                '查無Order資料
                If leaveFlag Then
                    'MessageHandling.showError("查無醫令資料")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                Else
                    'MessageHandling.showError("查無醫令資料")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                    '2010-04-28 delete by Alan-OK
                    PUBOrderUI_ucl_txtcq_ordercode.Focus()
                    'PUBOrderUI_ucl_dcbg_order.Focus()
                    'ucl_txtcq_ordercode.Focus()
                End If
            End If

        Else
            '查無Order資料
            If leaveFlag Then
                'MessageHandling.showError("查無醫令資料")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
            Else
                'MessageHandling.showError("查無醫令資料")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                '2010-04-28 delete by Alan-OK
                PUBOrderUI_ucl_txtcq_ordercode.Focus()
                'PUBOrderUI_ucl_dcbg_order.Focus()
                'ucl_txtcq_ordercode.Focus()
            End If
        End If

    End Sub

    '子功能data to OrderUI
    Private Sub orderToConditionUI(ByRef OrderDT As DataTable)
        If DataSetUtil.IsContainsData(OrderDT) Then
            '[Effect_Date](, [Order_Code]),[Order_En_Name],[Order_Name],[Order_En_Short_Name],[Order_Short_Name],
            '[Order_Type_Id],[Account_Id],[Is_Cure],[Cure_Type_Id],[Treatment_Type_Id],[Charge_Unit],[Nhi_Transrate],
            '[Nhi_Unit],[Is_Order_Check],[Is_Indication],[Fix_Order_Id],[Is_Exclude_Drug],[Order_Note],[Order_Memo],
            '[Order_Flag],[Is_Agree_Sheet],[Is_Nhi_Sheet],[Is_Nhi_Index],[Is_Prior_Review],[Dc],[End_Date],[Create_User],
            '[Create_Time],[Modified_User],[Modified_Time],[Manage_Id],[Is_IC_Card_Order],[Dc_Reason]

            '-------------------------------
            Dim OrderDR As DataRow = OrderDT.Rows(0)

            If Not IsDBNull(OrderDR.Item("Order_Code")) Then
                '2010-04-28 delete by Alan-OK
                PUBOrderUI_ucl_txtcq_ordercode.Text = CType(OrderDR.Item("Order_Code"), String).Trim
                PUBOrderUI_ucl_txtcq_ordercode.doFlag = False
                'PUBOrderUI_ucl_dcbg_order.Text = CType(OrderDR.Item("Order_Code"), String).Trim
                '修正瀏覽上、下筆資料，再各類加成時，醫令碼不同步的問題(2014-5-23-王崇益)
                PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 = CType(OrderDR.Item("Order_Code"), String).Trim
            Else
                '2010-04-28 delete by Alan-OK
                PUBOrderUI_ucl_txtcq_ordercode.Text = ""
                'PUBOrderUI_ucl_dcbg_order.Text = ""
            End If

            If Not IsDBNull(OrderDR.Item("Order_Name")) Then
                txt_ZhName.Text = CType(OrderDR.Item("Order_Name"), String).Trim
                PUBOrderUI_ucl_txtcq_ordercode.uclCodeName = CType(OrderDR.Item("Order_Name"), String).Trim
            Else
                txt_ZhName.Text = ""
            End If
            If Not IsDBNull(OrderDR.Item("Order_Short_Name")) Then
                txt_SCName.Text = CType(OrderDR.Item("Order_Short_Name"), String).Trim
            Else
                txt_SCName.Text = ""
            End If
            If Not IsDBNull(OrderDR.Item("Order_En_Name")) Then
                txt_EnName.Text = CType(OrderDR.Item("Order_En_Name"), String).Trim
                txt_Name.Text = CType(OrderDR.Item("Order_En_Name"), String).Trim
            Else
                txt_EnName.Text = ""
                txt_Name.Text = ""
            End If

            'txt_NhiCode.Text = ""
            'txt_Name.Text = ""

            If Not IsDBNull(OrderDR.Item("Order_En_Short_Name")) Then
                txt_SEName.Text = CType(OrderDR.Item("Order_En_Short_Name"), String).Trim
            Else
                txt_SEName.Text = ""
            End If
            If Not IsDBNull(OrderDR.Item("Order_Type_Id")) Then
                uclcomb_OrderType.SelectedValue = CType(OrderDR.Item("Order_Type_Id"), String).Trim
            Else
                uclcomb_OrderType.SelectedIndex = -1
            End If
            If Not IsDBNull(OrderDR.Item("Account_Id")) Then
                uclcomb_HosItem.SelectedValue = CType(OrderDR.Item("Account_Id"), String).Trim
            Else
                uclcomb_HosItem.SelectedIndex = -1
            End If
            If Not IsDBNull(OrderDR.Item("Charge_Unit")) Then
                uclcomb_ChargeUnit.SelectedValue = CType(OrderDR.Item("Charge_Unit"), String).Trim
            Else
                uclcomb_ChargeUnit.SelectedIndex = -1
            End If
            If Not IsDBNull(OrderDR.Item("Treatment_Type_Id")) Then
                uclcomb_order_treat_prop.SelectedValue = CType(OrderDR.Item("Treatment_Type_Id"), String).Trim
            Else
                uclcomb_order_treat_prop.SelectedIndex = -1
            End If
            If Not IsDBNull(OrderDR.Item("Order_Memo")) Then
                memo_OrderMemo.Text = CType(OrderDR.Item("Order_Memo"), String).Trim
            Else
                memo_OrderMemo.Text = ""
            End If
            If Not IsDBNull(OrderDR.Item("Order_Note")) Then
                txt_Note.Text = CType(OrderDR.Item("Order_Note"), String).Trim
            Else
                txt_Note.Text = ""
            End If
            'If Not IsDBNull(OrderDR.Item("Order_Flag")) Then
            '    txt_Flag.Text = CType(OrderDR.Item("Order_Flag"), String).Trim
            'Else
            '    txt_Flag.Text = ""
            'End If
            If Not IsDBNull(OrderDR.Item("Is_Order_Check")) Then
                If CType(OrderDR.Item("Is_Order_Check"), String).Trim.Equals("Y") Then
                    cb_OrderCheck.Checked = True
                Else
                    cb_OrderCheck.Checked = False
                End If
            Else
                cb_OrderCheck.Checked = False
            End If
            'If Not IsDBNull(OrderDR.Item("Is_Indication")) Then
            '    If CType(OrderDR.Item("Is_Indication"), String).Trim.Equals("Y") Then
            '        cb_Indication.Checked = True
            '    Else
            '        cb_Indication.Checked = False
            '    End If
            'Else
            '    cb_Indication.Checked = False
            'End If
            If Not IsDBNull(OrderDR.Item("Is_Nhi_Sheet")) Then
                If CType(OrderDR.Item("Is_Nhi_Sheet"), String).Trim.Equals("Y") Then
                    cb_NhiSheet.Checked = True
                Else
                    cb_NhiSheet.Checked = False
                End If
            Else
                cb_NhiSheet.Checked = False
            End If
            If Not IsDBNull(OrderDR.Item("Fix_Order_Id")) Then
                uclcomb_fix_fee.SelectedValue = CType(OrderDR.Item("Fix_Order_Id"), String).Trim
            End If
            If Not IsDBNull(OrderDR.Item("Is_Cure")) Then
                If CType(OrderDR.Item("Is_Cure"), String).Trim.Equals("Y") Then
                    cb_NhiCureTypeId.Checked = True
                Else
                    cb_NhiCureTypeId.Checked = False
                End If
            Else
                cb_NhiCureTypeId.Checked = False
            End If

            If Not IsDBNull(OrderDR.Item("Dc")) Then
                If CType(OrderDR.Item("Dc"), String).Trim.Equals("Y") Then
                    cb_Dc.Checked = True
                Else
                    cb_Dc.Checked = False
                End If
            Else
                cb_Dc.Checked = False
            End If

            'If Not IsDBNull(OrderDR.Item("Dc")) Then
            '    If CType(OrderDR.Item("Dc"), String).Trim.Equals("Y") Then
            '        cb_Dc.Checked = True
            '        If Not IsDBNull(OrderDR.Item("Dc")) Then
            '            Try
            '                If IsDate(OrderDR.Item("End_Date")) Then
            '                    ucl_dtp_enddate.SetValue(CType(OrderDR.Item("End_Date"), Date).ToString("yyyy/MM/dd"))
            '                End If
            '            Catch ex As Exception

            '            End Try
            '        End If
            '    Else
            '        cb_Dc.Checked = False

            '    End If
            'End If

            ucl_dtp_enddate.SetValue(CType(OrderDR.Item("End_Date"), Date).ToString("yyyy/MM/dd"))

            'If Not IsDBNull(OrderDR.Item("Manage_Id")) Then
            '    uclcb_classify.SelectedValue = CType(OrderDR.Item("Manage_Id"), String).Trim
            'Else
            '    uclcb_classify.SelectedIndex = -1
            'End If
            If Not IsDBNull(OrderDR.Item("Effect_Date")) Then
                ucldtp_EffectDate.SetValue(CType(OrderDR.Item("Effect_Date"), Date))
                gblEffectDate = ucldtp_EffectDate.GetUsDateStr
            Else
                gblEffectDate = ""
            End If

            If Not IsDBNull(OrderDR.Item("Is_Order_Price_Special")) Then
                If CType(OrderDR.Item("Is_Order_Price_Special"), String).Trim.Equals("Y") Then
                    cb_orderprice_spec.Checked = True
                Else
                    cb_orderprice_spec.Checked = False
                End If
            Else
                cb_orderprice_spec.Checked = False
            End If

            If Not IsDBNull(OrderDR.Item("Include_Order_Mark")) Then
                txt_IncludeOrder.Text = OrderDR.Item("Include_Order_Mark").ToString.Trim
            Else
                txt_IncludeOrder.Text = ""
            End If

            '2010-04-29 Add By Alan
            'If Not IsDBNull(OrderDR.Item("Insu_Cover_Opd")) Then
            '    'If CType(OrderDR.Item("Insu_Cover_Opd"), String).Trim.Equals("Y") Then
            '    '    cb_OPD.Checked = True
            '    'Else
            '    '    cb_OPD.Checked = False
            '    'End If
            '    cbo_OPD.SelectedValue = CType(OrderDR.Item("Insu_Cover_Opd"), String).Trim
            'Else
            cbo_OPD.SelectedValue = OrderDR.Item("Insu_Cover_Opd").ToString.Trim
            'End If

            'If Not IsDBNull(OrderDR.Item("Insu_Cover_Emg")) Then
            '    'If CType(OrderDR.Item("Insu_Cover_Emg"), String).Trim.Equals("Y") Then
            '    '    cb_EMG.Checked = True
            '    'Else
            '    '    cb_EMG.Checked = False
            '    'End If
            '    cbo_EMG.SelectedValue = CType(OrderDR.Item("Insu_Cover_Emg"), String).Trim
            'Else
            cbo_EMG.SelectedValue = OrderDR.Item("Insu_Cover_Emg").ToString.Trim
            'End If

            'If Not IsDBNull(OrderDR.Item("Insu_Cover_Ipd")) Then
            '    'If CType(OrderDR.Item("Insu_Cover_Ipd"), String).Trim.Equals("Y") Then
            '    '    cb_IPD.Checked = True
            '    'Else
            '    '    cb_IPD.Checked = False
            '    'End If
            '    cbo_IPD.SelectedValue = CType(OrderDR.Item("Insu_Cover_Ipd"), String).Trim
            'Else
            cbo_IPD.SelectedValue = OrderDR.Item("Insu_Cover_Ipd").ToString.Trim
            'End If

            'gblIsInventory = CType(OrderDR.Item("Is_Inventory"), String).Trim
            gblIsIcdCheck = CType(OrderDR.Item("Is_Icd_Check"), String).Trim

        End If
    End Sub
    '子功能data to majorcare field
    Private Sub orderMajorcareToCondition(ByRef OrderMajorcareDT As DataTable)
        If DataSetUtil.IsContainsData(OrderMajorcareDT) Then
            uclcomb_majorcare.SelectedValue = CType(OrderMajorcareDT.Rows(0).Item("Majorcare_Code"), String).Trim
        Else
            uclcomb_majorcare.SelectedIndex = -1
        End If
    End Sub
    '子功能data to curecontrol
    Private Sub cureControlToCondition(ByRef dbCureControlDT As DataTable)
        If DataSetUtil.IsContainsData(dbCureControlDT) Then
            Dim CureTypeColumn() As String = {"Cure_Type_Id", "Time_Control_Id", "Control_Value", "Max_Cnt", "Is_Reg_Fee", "Is_Fee_Check"}
            Dim CureTypeColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger, _
                                                   DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString}
            Dim transCureControlDT As DataTable = DataSetUtil.createDataTable("curecontrol", Nothing, CureTypeColumn, CureTypeColumnType)

            Dim cureDR As DataRow = transCureControlDT.NewRow
            cureDR.Item(CureTypeColumn(0)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(0))
            cureDR.Item(CureTypeColumn(1)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(1))
            cureDR.Item(CureTypeColumn(2)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(2))
            cureDR.Item(CureTypeColumn(3)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(3))
            cureDR.Item(CureTypeColumn(4)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(4))
            cureDR.Item(CureTypeColumn(5)) = dbCureControlDT.Rows(0).Item(CureTypeColumn(5))
            transCureControlDT.Rows.Add(cureDR)

            cureControlDT = transCureControlDT
        End If
    End Sub
    '子功能data to order_price grid
    Private Sub orderPriceToGrid(ByRef DBOrderPriceDT As DataTable, ByRef isHistory As Boolean)
        If DataSetUtil.IsContainsData(DBOrderPriceDT) Then
            '...
            Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)


            For Each dr As DataRow In DBOrderPriceDT.Rows
                Dim OrderPriceDR As DataRow = OrderPriceDT.NewRow

                ' [Effect_Date],[Order_Code] [Main_Identity_Id],[Price],[Add_Price],[Material_Ratio],[Material_Account_Id],[Is_Emg_Add],[Is_Kid_Add],[Is_Dental_Add],[Is_Holiday_Add],[Insu_Code],[Insu_Cover_Opd],[Insu_Cover_Emg],[Insu_Cover_Ipd],[Insu_Account_Id],[Insu_Order_Type_Id],[Opd_Add_Order_Code],[Emg_Add_Order_Code],[Ipd_Add_Order_Code],[Emg_Nursing_Add_Order_Code],[Ipd_Nursing_Add_Order_Code],[Dc],[End_Date],[Create_User],[Create_Time],[Modified_User],[Modified_Time],[Insu_Group_Code]
                'mapping
                '"主身分", "生效日", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", "假日加成", "群組醫令碼", 
                '"門診可用", "急診可用", "住院可用", "健保碼", "健保費用項目", "健保醫令類別"
                If Not IsDBNull(dr.Item("Main_Identity_Id")) Then
                    OrderPriceDR.Item(OrderPriceColumn(0)) = CType(dr.Item("Main_Identity_Id"), String).Trim
                End If
                If Not IsDBNull(dr.Item("Effect_Date")) Then
                    OrderPriceDR.Item(OrderPriceColumn(1)) = CType(dr.Item("Effect_Date"), Date)
                End If
                If Not IsDBNull(dr.Item("Price")) Then
                    OrderPriceDR.Item(OrderPriceColumn(2)) = CType(dr.Item("Price"), Decimal)
                End If
                If Not IsDBNull(dr.Item("Add_Price")) Then
                    OrderPriceDR.Item(OrderPriceColumn(3)) = CType(dr.Item("Add_Price"), Decimal)
                End If
                If Not IsDBNull(dr.Item("End_Date")) Then
                    OrderPriceDR.Item(OrderPriceColumn(4)) = CType(dr.Item("End_Date"), Date)
                End If

                If Not IsDBNull(dr.Item("Order_Ratio")) Then
                    OrderPriceDR.Item(OrderPriceColumn(5)) = CType(dr.Item("Order_Ratio"), Decimal)
                Else
                    OrderPriceDR.Item(OrderPriceColumn(5)) = 0
                End If

                If Not IsDBNull(dr.Item("Is_Emg_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(6)) = CType(dr.Item("Is_Emg_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(6)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Kid_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(7)) = CType(dr.Item("Is_Kid_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(7)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Dental_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(8)) = CType(dr.Item("Is_Dental_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(8)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Dept_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(9)) = CType(dr.Item("Is_Dept_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(9)) = "N"
                End If

                'Opd_Add_Order_Code, Emg_Add_Order_Code, Ipd_Add_Order_Code, Emg_Nursing_Add_Order_Code, Ipd_Nursing_Add_Order_Code
                OrderPriceDR.Item(OrderPriceColumn(10)) = getGroupAddOrder(dr)

                'If Not IsDBNull(dr.Item("Insu_Cover_Opd")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(11)) = CType(dr.Item("Insu_Cover_Opd"), String).Trim
                'End If
                'If Not IsDBNull(dr.Item("Insu_Cover_Emg")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(12)) = CType(dr.Item("Insu_Cover_Emg"), String).Trim
                'End If
                'If Not IsDBNull(dr.Item("Insu_Cover_Ipd")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(13)) = CType(dr.Item("Insu_Cover_Ipd"), String).Trim
                'End If
                If Not IsDBNull(dr.Item("Insu_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(14)) = CType(dr.Item("Insu_Code"), String).Trim
                    gblInsuCode = CType(dr.Item("Insu_Code"), String).Trim
                End If
                If Not IsDBNull(dr.Item("Insu_Account_Id")) Then
                    If CType(dr.Item("Insu_Account_Id"), String).Trim.Length > 0 Then
                        OrderPriceDR.Item(OrderPriceColumn(16)) = CType(dr.Item("Insu_Account_Id"), String).Trim
                    End If
                End If
                If Not IsDBNull(dr.Item("Insu_Order_Type_Id")) Then
                    If CType(dr.Item("Insu_Order_Type_Id"), String).Trim.Length > 0 Then
                        OrderPriceDR.Item(OrderPriceColumn(17)) = CType(dr.Item("Insu_Order_Type_Id"), String).Trim
                    End If
                End If

                If Not IsDBNull(dr.Item("Dc")) Then
                    OrderPriceDR.Item(OrderPriceColumn(18)) = CType(dr.Item("Dc"), String).Trim
                End If

                OrderPriceDR.Item(OrderPriceColumn(19)) = "N"

                '群組

                'add by 唐子晴 2014.02.19 ---------------------------------------------------
                If Not IsDBNull(dr.Item("Modified_Time")) Then
                    OrderPriceDR.Item(OrderPriceColumn(20)) = CType(CDate(dr.Item("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss"), String)
                End If
                '----------------------------------------------------------------------------

                OrderPriceDT.Rows.Add(OrderPriceDR)
            Next

            updateGridView(OrderPriceDT)
        Else
            'addOneEmptyRecordToGrid()
            Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
            updateGridView(OrderPriceDT)
        End If

        If Not isHistory Then
            '加一行
            addNewGridRow()

            For i = 0 To ucldgv_OrderPrice.GetDBDS.Tables(0).Rows.Count - 2
                ucldgv_OrderPrice.SetCellReadOnly(0, i, True)
            Next

        End If

    End Sub

    ''' <summary>
    ''' 更新Grid view(已備妥grid)
    ''' </summary>
    ''' <param name="OrderPriceDT"></param>
    ''' <remarks></remarks>
    Private Sub updateGridView(ByRef OrderPriceDT As DataTable)
        'To Grid Data
        ucldgv_OrderPrice.ClearDS()
        Dim OrderPriceDS As DataSet = New DataSet
        OrderPriceDS.Tables.Add(OrderPriceDT)
        ucldgv_OrderPrice.Visible = False
        ucldgv_OrderPrice.SetDS(OrderPriceDS)
        ucldgv_OrderPrice.Visible = True
    End Sub

    '--------------------------

    ''' <summary>
    ''' 欄位檢查(查詢)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkQueryKey() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True

        'ucl_txtcq_ordercode.uclCodeValue1 = ucl_txtcq_ordercode.Text

        'If Not ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
        '    ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = ucl_txtcq_ordercode
        'End If

        '2010-04-28 delete by Alan-OK
        If Not PUBOrderUI_ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
            PUBOrderUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = PUBOrderUI_ucl_txtcq_ordercode
        End If

        'If Not uclcomb_OrderType.SelectedIndex > 0 Then
        '    uclcomb_OrderType.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = uclcomb_OrderType
        'End If

        If allPass Then
            cleanFieldsColor()
        Else
            'CMMCMMB009
            'MessageHandling.showErrorByKey("CMMCMMB009")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB009", New String() {}, "")
            comp.Focus()
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 欄位檢查(確認)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkConfirmKey() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True

        gblErrorMsg = ""
        'If Not ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
        '    ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = ucl_txtcq_ordercode
        'End If

        '2010-04-28 delete by Alan-OK
        If Not PUBOrderUI_ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
            PUBOrderUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = PUBOrderUI_ucl_txtcq_ordercode
            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",醫令項目代碼"
            Else
                gblErrorMsg = "醫令項目代碼"
            End If

        End If

        If Not uclcomb_OrderType.SelectedIndex > 0 Then
            uclcomb_OrderType.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = uclcomb_OrderType
            End If

            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",醫令類型"
            Else
                gblErrorMsg = "醫令類型"
            End If
        End If
        If Not uclcomb_HosItem.SelectedIndex > 0 Then
            uclcomb_HosItem.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = uclcomb_HosItem
            End If

            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",院內費用項目"
            Else
                gblErrorMsg = "院內費用項目"
            End If
        End If
        'If Not uclcomb_ChargeUnit.SelectedIndex > 0 Then
        '    uclcomb_ChargeUnit.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    If comp Is Nothing Then
        '        comp = uclcomb_ChargeUnit
        '    End If
        'End If
        'If Not uclcomb_fix_fee.SelectedIndex > 0 Then
        '    uclcomb_fix_fee.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    If comp Is Nothing Then
        '        comp = uclcomb_fix_fee
        '    End If
        'End If

        If gblEffectDate <> ucldtp_EffectDate.GetUsDateStr AndAlso DateDiff(DateInterval.Day, DateUtil.getSystemDate, Date.Parse(ucldtp_EffectDate.GetUsDateStr)) < 0 Then
            ucldtp_EffectDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = ucldtp_EffectDate
            End If

            MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"生效日", "系統日期"}, "")
            Return allPass
        End If

        If Not IsDate(ucldtp_EffectDate.GetUsDateStr) Then
            ucldtp_EffectDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = ucldtp_EffectDate
            End If

            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",生效日"
            Else
                gblErrorMsg = "生效日"
            End If
        End If

        If cb_Dc.Checked Then

            If IsDate(ucl_dtp_enddate.GetUsDateStr) Then

            Else
                ucl_dtp_enddate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                allPass = False
                If comp Is Nothing Then
                    comp = ucl_dtp_enddate
                End If
                If gblErrorMsg <> "" Then
                    gblErrorMsg &= ",停用日期"
                Else
                    gblErrorMsg = "停用日期"
                End If
            End If
        End If

        If IsDate(ucl_dtp_enddate.GetUsDateStr) Then

            If DateDiff(DateInterval.Day, Date.Parse(ucl_dtp_enddate.GetUsDateStr), Date.Parse(ucldtp_EffectDate.GetUsDateStr)) > 0 Then
                allPass = False
                If comp Is Nothing Then
                    comp = ucl_dtp_enddate
                End If
                MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"停用日期", "生效日"}, "")

            End If

        End If


        If allPass Then
            cleanFieldsColor()
        Else
            'MessageHandling.showErrorByKey("CMMCMMB009")
            '********************2010/2/9 Modify By Alan**********************
            If gblErrorMsg <> "" Then
                MessageHandling.ShowErrorMsg("CMMCMMB305", New String() {gblErrorMsg}, "")
                comp.Focus()
            End If
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 檢核Grid row資料的正確性
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkGridData() As Boolean
        If checkGridRowHasData(True, 0) Then

            Return checkDataContentCorrect()
        Else
            addNewGridRow()
            Return False
        End If
    End Function

    '子功能 欄位has data檢查
    Private Function checkGridRowHasData(ByVal chkAllFlag As Boolean, ByVal chkIndex As Integer) As Boolean
        '檢查時, 第一藍莓資料就不要
        GridSelectedIndexList.Clear()

        'OrderPriceColumn() As String = 
        '{"主身分", "生效日", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", 
        ' "假日加成", "群組醫令碼", "門診可用", "急診可用", "住院可用", "健保碼", "健保費用項目", "健保醫令類別", "Dc"}

        gblErrorMsg = ""

        Dim checkDataPass As Boolean = True
        Dim pvtChkMainFlag As Boolean = False '判斷是否有主身分
        Dim pvtExeChkFlag As Boolean = True

        If DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) Then
            Dim PriceDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy

            '檢查不符列...
            For i As Integer = 0 To (PriceDT.Rows.Count - 1)

                Dim GridSelectedIndex As Integer = -1

                If chkAllFlag Then
                    pvtExeChkFlag = True
                Else
                    If chkIndex = i AndAlso CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim <> "" Then
                        pvtExeChkFlag = True
                    Else
                        pvtExeChkFlag = False
                    End If
                End If

                If pvtExeChkFlag AndAlso (Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(0)))) AndAlso (Not CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim.Equals("")) Then

                    If CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim.Equals("2") Then '健保
                        '檢查健保欄位 13, 14, 15
                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(14))) Then
                            If chkNhiCode(PUBOrderUI_ucl_txtcq_ordercode.Text.Trim) Then
                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(i).Item("健保碼") = "ZZZZZZ"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(i).Item("健保碼") = "ZZZZZZ"
                            Else
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",健保碼"
                                Else
                                    gblErrorMsg = "健保碼"
                                End If
                            End If


                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(14)), String).Trim.Equals("") Then
                            If chkNhiCode(PUBOrderUI_ucl_txtcq_ordercode.Text.Trim) Then
                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(i).Item("健保碼") = "ZZZZZZ"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(i).Item("健保碼") = "ZZZZZZ"
                            Else
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",健保碼"
                                Else
                                    gblErrorMsg = "健保碼"
                                End If
                            End If
                        Else

                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(16))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保費用項目"
                            Else
                                gblErrorMsg = "健保費用項目"
                            End If
                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(16)), String).Trim.Equals("") Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保費用項目"
                            Else
                                gblErrorMsg = "健保費用項目"
                            End If
                        Else

                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(17))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保醫令類別"
                            Else
                                gblErrorMsg = "健保醫令類別"
                            End If
                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(17)), String).Trim.Equals("") Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保醫令類別"
                            Else
                                gblErrorMsg = "健保醫令類別"
                            End If
                        Else

                        End If
                    Else
                        pvtChkMainFlag = True
                    End If

                    If GridSelectedIndex <> -1 Then
                        'show該列error
                    Else
                        '檢查下面 keepOrderPriceDT
                        'If ((keepOrderPriceDT IsNot Nothing AndAlso keepOrderPriceDT.Rows.Count - 1 >= i AndAlso Date.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(1))).ToString("yyyy/MM/dd") <> Date.Parse(keepOrderPriceDT.Rows(i).Item("Effect_Date")).ToString("yyyy/MM/dd")) OrElse _
                        '    (keepOrderPriceDT Is Nothing OrElse keepOrderPriceDT.Rows.Count = 0)) AndAlso _
                        '     DateDiff(DateInterval.Day, HisComm.Utility.DateUtil.getSystemDate, Date.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(1)))) < 0 Then
                        '    GridSelectedIndex = i
                        '    MessageHandling.showErrorMsg("CMMCMMB102", New String() {"生效日", "系統日期"}, "")
                        '    Return False
                        'End If

                        If DateDiff(DateInterval.Day, Date.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(1))), PriceDT.Rows(i).Item(OrderPriceColumn(4))) < 0 Then
                            GridSelectedIndex = i
                            MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"停止日", "生效日"}, "")
                            Return False
                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(1))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",生效日"
                            Else
                                gblErrorMsg = "生效日"
                            End If
                        Else

                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(2))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",單價"
                            Else
                                gblErrorMsg = "單價"
                            End If
                        Else
                            Dim price As Decimal = -1
                            Try
                                price = Decimal.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(2)))
                            Catch ex As Exception
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",單價"
                                Else
                                    gblErrorMsg = "單價"
                                End If
                            End Try
                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(3))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",差額"
                            Else
                                gblErrorMsg = "差額"
                            End If
                        Else
                            Dim addprice As Decimal = -1
                            Try
                                addprice = Decimal.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(3)))
                            Catch ex As Exception
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",差額"
                                Else
                                    gblErrorMsg = "差額"
                                End If
                            End Try
                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(4))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",停止日"
                            Else
                                gblErrorMsg = "停止日"
                            End If
                        Else

                        End If




                    End If

                    If GridSelectedIndex <> -1 Then
                        checkDataPass = False
                        GridSelectedIndexList.Add(GridSelectedIndex)
                    End If

                Else
                    '該筆資料不要
                End If

            Next

            '若未有自費身份，則顯示錯誤訊息
            If pvtExeChkFlag AndAlso checkDataPass = True AndAlso pvtChkMainFlag = False Then
                GridSelectedIndexList.Add(0)
                gblErrorMsg = "該醫令必須有自費價格"
            End If

            If GridSelectedIndexList.Count > 0 Then
                For i As Integer = 0 To (GridSelectedIndexList.Count - 1)
                    ucldgv_OrderPrice.SetRowColor(CType(GridSelectedIndexList.Item(i), Integer), System.Drawing.Color.Pink)
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB305", New String() {gblErrorMsg}, "")
                Return False
            Else
                Return True
            End If
        Else
            '若未有自費身份，則顯示錯誤訊息
            If pvtExeChkFlag AndAlso checkDataPass = True AndAlso pvtChkMainFlag = False Then
                GridSelectedIndexList.Add(0)
                gblErrorMsg = "該醫令必須有自費價格"
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {gblErrorMsg}, "")
                Return False
            End If
            'grid無資料...
            Return True
        End If
    End Function

    ''' <summary>
    ''' 將沒填第一欄資料的篩掉
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub confirmFilterData()

        If DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) Then
            Dim PriceDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy

            Dim ResultPriceDT As DataTable = PriceDT.Copy
            ResultPriceDT.Clear()

            For i As Integer = 0 To (PriceDT.Rows.Count - 1)

                If (Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(0)))) AndAlso (Not CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim.Equals("")) Then
                    ResultPriceDT.Rows.Add(PriceDT.Rows(i).ItemArray)
                End If
            Next

            Dim PriceDS As New DataSet
            PriceDS.Tables.Add(ResultPriceDT)

            ucldgv_OrderPrice.Visible = False
            ucldgv_OrderPrice.SetDS(PriceDS)
            ucldgv_OrderPrice.Visible = True
        End If
    End Sub

    '子功能 資料正確性檢查
    Private Function checkDataContentCorrect() As Boolean
        '有資料檢查已完成

        Dim hasExistFlag As Boolean = False
        Dim hasEmptyFlag As Boolean = False

        If DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) Then
            Dim PriceDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy

            If PriceDT.Rows.Count > 1 Then

                Dim mainIdHash As New Hashtable
                For i As Integer = 0 To (PriceDT.Rows.Count - 1)
                    If Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(0))) Then
                        Dim tmpMainid As String = CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim

                        If tmpMainid.Equals("") Then
                            hasEmptyFlag = True
                        End If

                        If mainIdHash.ContainsKey(tmpMainid) Then
                            hasExistFlag = True
                        Else
                            mainIdHash.Add(tmpMainid, "")
                        End If

                    Else
                        hasEmptyFlag = True
                    End If
                Next

                If hasEmptyFlag Then
                    '主身分空白
                ElseIf hasExistFlag Then
                    '主身分重複
                Else
                    '處理資料內容
                    '0      1     2    3    4
                    'L1234  L234  L34  L4
                    '{"主身分", "生效日", "單價", "差額", "停止日"
                    For i As Integer = 0 To (PriceDT.Rows.Count - 1)
                        If CType(PriceDT.Rows(i).Item(OrderPriceColumn(18)), String).Trim.Equals("N") Then
                            Dim IMaim As String = CType(PriceDT.Rows(i).Item(OrderPriceColumn(0)), String).Trim
                            Dim IEffect As Date = CType(PriceDT.Rows(i).Item(OrderPriceColumn(1)), Date)
                            Dim IEnd As Date = CType(PriceDT.Rows(i).Item(OrderPriceColumn(4)), Date)

                            If (i + 1) <= (PriceDT.Rows.Count - 1) Then
                                For j As Integer = (i + 1) To (PriceDT.Rows.Count - 1)
                                    If CType(PriceDT.Rows(j).Item(OrderPriceColumn(18)), String).Trim.Equals("N") Then
                                        '...check logic & replace PriceDT.Rows(i)與 PriceDT.Rows(j)
                                        Dim JMaim As String = CType(PriceDT.Rows(j).Item(OrderPriceColumn(0)), String).Trim
                                        Dim JEffect As Date = CType(PriceDT.Rows(j).Item(OrderPriceColumn(1)), Date)
                                        Dim JEnd As Date = CType(PriceDT.Rows(j).Item(OrderPriceColumn(4)), Date)

                                        If IMaim.Equals(JMaim) Then
                                            '改i日期
                                            If IEnd.CompareTo(JEffect) >= 0 Then

                                                If CType(PriceDT.Rows(j).Item(OrderPriceColumn(4)), Date).CompareTo(CType(PriceDT.Rows(i).Item(OrderPriceColumn(4)), Date)) > 0 Then

                                                Else
                                                    PriceDT.Rows(j).Item(OrderPriceColumn(4)) = PriceDT.Rows(i).Item(OrderPriceColumn(4))
                                                End If

                                                PriceDT.Rows(i).Item(OrderPriceColumn(4)) = JEffect.AddDays(-1)

                                                If JEffect.CompareTo(SystemDate) > 0 Then
                                                    PriceDT.Rows(i).Item(OrderPriceColumn(18)) = "N"
                                                    PriceDT.Rows(j).Item(OrderPriceColumn(19)) = "Y"
                                                Else
                                                    PriceDT.Rows(i).Item(OrderPriceColumn(18)) = "Y"
                                                End If

                                            End If
                                            '.....
                                            '.....


                                        Else
                                            '不管
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If

            End If

            If hasEmptyFlag Then
                'MessageHandling.showError("主身分不可空白")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"主身分不可空白"}, "")
                Return False
            ElseIf hasExistFlag Then
                '主身分重複
                'MessageHandling.showError("主身分不可重複")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"主身分不可重複"}, "")
                Return False
            Else
                updateGridView(PriceDT)

                Return True
            End If

        Else
            Return True
        End If


    End Function

    ''' <summary>
    ''' 取得群組醫令碼
    ''' </summary>
    ''' <param name="pricedr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getGroupAddOrder(ByRef pricedr As DataRow) As String
        Dim AddOrderCode As String = ""

        'Opd_Add_Order_Code, Emg_Add_Order_Code, Ipd_Add_Order_Code, Emg_Nursing_Add_Order_Code, Ipd_Nursing_Add_Order_Code

        If Not IsDBNull(pricedr.Item("Opd_Add_Order_Code")) Then
            AddOrderCode = CType(pricedr.Item("Opd_Add_Order_Code"), String).Trim
        ElseIf Not IsDBNull(pricedr.Item("Emg_Add_Order_Code")) Then
            AddOrderCode = CType(pricedr.Item("Emg_Add_Order_Code"), String).Trim
        ElseIf Not IsDBNull(pricedr.Item("Ipd_Add_Order_Code")) Then
            AddOrderCode = CType(pricedr.Item("Ipd_Add_Order_Code"), String).Trim
        ElseIf Not IsDBNull(pricedr.Item("Emg_Nursing_Add_Order_Code")) Then
            AddOrderCode = CType(pricedr.Item("Emg_Nursing_Add_Order_Code"), String).Trim
        ElseIf Not IsDBNull(pricedr.Item("Ipd_Nursing_Add_Order_Code")) Then
            AddOrderCode = CType(pricedr.Item("Ipd_Nursing_Add_Order_Code"), String).Trim
        End If

        Return AddOrderCode

    End Function

    ''' <summary>
    ''' 設回欄位預設顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()

        Try
            '先將需要檢查欄位的back color設為default
            'ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            '2010-04-28 delete by Alan
            PUBOrderUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'PUBOrderUI_ucl_dcbg_order.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            uclcomb_OrderType.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            uclcomb_HosItem.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'uclcomb_ChargeUnit.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'uclcomb_fix_fee.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub addNewGridRow()

        Dim GridDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

        ucldgv_OrderPrice.AddNewRow()

        GridDS = ucldgv_OrderPrice.GetDBDS.Copy

        If GridDS IsNot Nothing AndAlso GridDS.Tables.Count > 0 AndAlso GridDS.Tables(0).Rows.Count > 0 Then
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(0)) = ""
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(1)) = SystemDate.ToString("yyyy/MM/dd")
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(4)) = defaultEndDate.ToString("yyyy/MM/dd")
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(5)) = "1"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(6)) = "N"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(7)) = "N"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(8)) = "N"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(9)) = "N"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(10)) = ""

            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(11)) = "Y"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(12)) = "Y"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(13)) = "Y"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(18)) = "N"
            GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(19)) = "Y"

            ucldgv_OrderPrice.ClearDS()
            ucldgv_OrderPrice.Visible = False
            ucldgv_OrderPrice.SetDS(GridDS)
            ucldgv_OrderPrice.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub query(ByVal leaveFlag As Boolean)

        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            'Dim OrderCode As String = ucl_txtcq_ordercode.Text.Trim

            '2010-04-28 delete by Alan-OK
            'Dim OrderCode As String = PUBOrderUI_ucl_dcbg_order.Text.Trim
            Dim OrderCode As String = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
            Dim QueryDate As Date = SystemDate

            If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                QueryDate = Date.Parse(ucldtp_EffectDate.GetUsDateStr)
            End If

            'Dim OrderTypeId As String = uclcomb_OrderType.SelectedValue

            Dim OrderDS As DataSet = pub.queryOrderData(OrderCode, QueryDate)

            OrderRelatedDataToUI(OrderDS, leaveFlag)
        End If

    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Confirm() As Boolean

        confirmFilterData()

        'if CheckColumn and data format or lose data
        'Dim PassDataDS As New DataSet

        If checkConfirmKey() Then

            If checkGridData() Then

                'TODO 檢查 出來 醫令馬 型態 步可變動...

                GridSelectedIndexList.Clear()

                Dim OrderRelatedDS As DataSet = New DataSet

                Dim oldToProcessOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithNoPK
                Dim newOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithNoPK

                Dim OrderMajorcareColumn() As String = {"Order_Code", "Majorcare_Code", "Mode"}
                Dim OrderMajorcareColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
                Dim OrderMajorcareDT As DataTable = DataSetUtil.createDataTable("ordermajorcare", Nothing, OrderMajorcareColumn, OrderMajorcareColumnType)
                Dim checkCureFlag As Boolean = False

                'order
                If keepOrderDT IsNot Nothing AndAlso keepOrderDT.Rows(0).Item("Order_Code").ToString.Trim <> PUBOrderUI_ucl_txtcq_ordercode.Text.Trim Then

                    keepOrderDT.Clear()

                    If keepOrderMajorcareDT IsNot Nothing Then
                        keepOrderMajorcareDT.Clear()
                    End If

                    If keepOrderPriceDT IsNot Nothing Then
                        keepOrderPriceDT.Clear()
                    End If

                    If keepOrderPriceHistoryDT IsNot Nothing Then
                        keepOrderPriceHistoryDT.Clear()
                    End If

                End If
                If DataSetUtil.IsContainsData(keepOrderDT) Then

                    Dim row As DataRow = oldToProcessOrderDT.NewRow
                    For i = 0 To oldToProcessOrderDT.Columns.Count - 1
                        row(i) = DBNull.Value
                    Next
                    oldToProcessOrderDT.Rows.Add(row)

                    For i = 0 To oldToProcessOrderDT.Columns.Count - 1
                        For j = 0 To keepOrderDT.Columns.Count - 1
                            If oldToProcessOrderDT.Columns.Item(i).ToString = keepOrderDT.Columns.Item(j).ToString Then
                                oldToProcessOrderDT.Rows(0).Item(i) = keepOrderDT.Rows(0).Item(j).ToString
                                Exit For
                            Else
                                oldToProcessOrderDT.Rows(0).Item(i) = DBNull.Value

                            End If

                        Next
                        ' i = i + 1
                    Next

                    'oldToProcessOrderDT.Rows.Add(keepOrderDT.Rows(0).ItemArray)

                    'update order
                    'oldToProcessOrderDT.Rows(0).Item("Order_Code") = ucl_txtcq_ordercode.Text.Trim

                    '2010-04-28 delete by Alan-OK
                    oldToProcessOrderDT.Rows(0).Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
                    'oldToProcessOrderDT.Rows(0).Item("Order_Code") = PUBOrderUI_ucl_dcbg_order.Text.Trim

                    oldToProcessOrderDT.Rows(0).Item("Order_Name") = txt_ZhName.Text.Trim
                    oldToProcessOrderDT.Rows(0).Item("Order_Short_Name") = txt_SCName.Text.Trim
                    oldToProcessOrderDT.Rows(0).Item("Order_En_Name") = txt_EnName.Text.Trim
                    oldToProcessOrderDT.Rows(0).Item("Order_En_Short_Name") = txt_SEName.Text.Trim
                    If uclcomb_OrderType.SelectedIndex > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Order_Type_Id") = uclcomb_OrderType.SelectedValue
                    End If
                    If uclcomb_HosItem.SelectedIndex > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Account_Id") = uclcomb_HosItem.SelectedValue
                    End If
                    If uclcomb_ChargeUnit.SelectedIndex > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Charge_Unit") = uclcomb_ChargeUnit.SelectedValue
                        oldToProcessOrderDT.Rows(0).Item("Nhi_Unit") = uclcomb_ChargeUnit.SelectedValue
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Charge_Unit") = ""
                        oldToProcessOrderDT.Rows(0).Item("Nhi_Unit") = ""
                    End If
                    If cb_NhiCureTypeId.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Is_Cure") = "Y"
                        checkCureFlag = True
                        If cb_NhiCureTypeId.Checked AndAlso DataSetUtil.IsContainsData(cureControlDT) Then
                            'nhi
                            oldToProcessOrderDT.Rows(0).Item("Cure_Type_Id") = CType(cureControlDT.Rows(0).Item("Cure_Type_Id"), String).Trim
                        Else
                            oldToProcessOrderDT.Rows(0).Item("Cure_Type_Id") = DBNull.Value
                        End If

                    Else
                        oldToProcessOrderDT.Rows(0).Item("Is_Cure") = "N"
                        checkCureFlag = False
                        oldToProcessOrderDT.Rows(0).Item("Cure_Type_Id") = DBNull.Value
                    End If

                    If uclcomb_order_treat_prop.SelectedIndex > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Treatment_Type_Id") = uclcomb_order_treat_prop.SelectedValue
                    End If
                    'If memo_OrderMemo.Text.Trim.Length > 0 Then
                    '    oldToProcessOrderDT.Rows(0).Item("Order_Memo") = memo_OrderMemo.Text
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Order_Memo") = ""
                    'End If

                    If txt_Note.Text.Trim.Length > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Order_Note") = txt_Note.Text
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Order_Note") = ""
                    End If
                    'If txt_Flag.Text.Trim.Length > 0 Then
                    '    oldToProcessOrderDT.Rows(0).Item("Order_Flag") = txt_Flag.Text
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Order_Flag") = ""
                    'End If
                    If cb_OrderCheck.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Is_Order_Check") = "Y"
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Is_Order_Check") = "N"
                    End If
                    'If cb_Indication.Checked Then
                    '    oldToProcessOrderDT.Rows(0).Item("Is_Indication") = "Y"
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Is_Indication") = "N"
                    'End If
                    If cb_NhiSheet.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Is_Nhi_Sheet") = "Y"
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Is_Nhi_Sheet") = "N"
                    End If

                    If cb_Dc.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Dc") = "Y"
                        Try
                            If IsDate(ucl_dtp_enddate.GetUsDateStr) Then
                                oldToProcessOrderDT.Rows(0).Item("End_Date") = ucl_dtp_enddate.GetUsDateStr.ToString.Substring(0, 10)
                            Else
                                oldToProcessOrderDT.Rows(0).Item("End_Date") = Date.Parse(SystemDate.ToString("yyyy/MM/dd"))
                            End If
                        Catch ex As Exception
                            oldToProcessOrderDT.Rows(0).Item("End_Date") = Date.Parse(SystemDate.ToString("yyyy/MM/dd"))
                        End Try
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Dc") = "N"
                        oldToProcessOrderDT.Rows(0).Item("End_Date") = ucl_dtp_enddate.GetUsDateStr.ToString.Substring(0, 10)
                    End If

                    If uclcomb_fix_fee.SelectedIndex > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Fix_Order_Id") = uclcomb_fix_fee.SelectedValue
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Fix_Order_Id") = ""
                    End If

                    'If uclcb_classify.SelectedIndex > 0 Then
                    '    oldToProcessOrderDT.Rows(0).Item("Manage_Id") = uclcb_classify.SelectedValue
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Manage_Id") = ""
                    'End If

                    'TODO.....
                    If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                        oldToProcessOrderDT.Rows(0).Item("Effect_Date") = ucldtp_EffectDate.GetUsDateStr.Substring(0, 10)
                    End If


                    If cb_orderprice_spec.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Is_Order_Price_Special") = "Y"
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Is_Order_Price_Special") = "N"
                    End If

                    'If cb_incorder_mark.Checked Then
                    '    oldToProcessOrderDT.Rows(0).Item("Include_Order_Mark") = "Y"
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Include_Order_Mark") = "N"
                    'End If
                    oldToProcessOrderDT.Rows(0).Item("Include_Order_Mark") = txt_IncludeOrder.Text.Trim


                    '2010-04-29 Add By Alan
                    'If cb_OPD.Checked Then
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Opd") = "Y"
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Opd") = "N"
                    'End If
                    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Opd") = cbo_OPD.SelectedValue

                    'If cb_EMG.Checked Then
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Emg") = "Y"
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Emg") = "N"
                    'End If
                    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Emg") = cbo_EMG.SelectedValue

                    'If cb_IPD.Checked Then
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Ipd") = "Y"
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Ipd") = "N"
                    'End If
                    oldToProcessOrderDT.Rows(0).Item("Insu_Cover_Ipd") = cbo_IPD.SelectedValue

                    oldToProcessOrderDT.Rows(0).Item("Is_Prior_Review") = "N"
                    'oldToProcessOrderDT.Rows(0).Item("Brand") = ""
                    'oldToProcessOrderDT.Rows(0).Item("Is_Inventory") = gblIsInventory
                    oldToProcessOrderDT.Rows(0).Item("Is_Icd_Check") = gblIsIcdCheck


                    oldToProcessOrderDT.Rows(0).Item("Modified_User") = loginUser
                    oldToProcessOrderDT.Rows(0).Item("Modified_Time") = SystemDate

                    '成本價格
                    oldToProcessOrderDT.Rows(0).Item("Cost_Price") = 0

                Else
                    Dim newOrderDr As DataRow = newOrderDT.NewRow
                    '新增TODO

                    If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                        newOrderDr.Item("Effect_Date") = ucldtp_EffectDate.GetUsDateStr.Substring(0, 10)
                    End If

                    'newOrderDr.Item("Order_Code") = ucl_txtcq_ordercode.Text.Trim
                    '2010-04-28 delete by Alan-OK
                    newOrderDr.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim()
                    'newOrderDr.Item("Order_Code") = PUBOrderUI_ucl_dcbg_order.Text.Trim

                    newOrderDr.Item("Order_Name") = txt_ZhName.Text.Trim
                    newOrderDr.Item("Order_Short_Name") = txt_SCName.Text.Trim
                    newOrderDr.Item("Order_En_Name") = txt_EnName.Text.Trim
                    newOrderDr.Item("Order_En_Short_Name") = txt_SEName.Text.Trim
                    If uclcomb_OrderType.SelectedIndex > 0 Then
                        newOrderDr.Item("Order_Type_Id") = uclcomb_OrderType.SelectedValue
                    End If
                    If uclcomb_HosItem.SelectedIndex > 0 Then
                        newOrderDr.Item("Account_Id") = uclcomb_HosItem.SelectedValue
                    End If
                    If uclcomb_ChargeUnit.SelectedIndex > 0 Then
                        newOrderDr.Item("Charge_Unit") = uclcomb_ChargeUnit.SelectedValue
                        newOrderDr.Item("Nhi_Unit") = uclcomb_ChargeUnit.SelectedValue
                    Else
                        newOrderDr.Item("Charge_Unit") = ""
                        newOrderDr.Item("Nhi_Unit") = ""
                    End If

                    newOrderDr.Item("Nhi_Transrate") = 1

                    If cb_NhiCureTypeId.Checked Then
                        newOrderDr.Item("Is_Cure") = "Y"
                        checkCureFlag = True
                        If cb_NhiCureTypeId.Checked AndAlso DataSetUtil.IsContainsData(cureControlDT) Then
                            'nhi
                            newOrderDr.Item("Cure_Type_Id") = CType(cureControlDT.Rows(0).Item("Cure_Type_Id"), String).Trim
                        Else
                            newOrderDr.Item("Cure_Type_Id") = DBNull.Value
                        End If

                    Else
                        newOrderDr.Item("Is_Cure") = "N"
                        checkCureFlag = False
                        newOrderDr.Item("Cure_Type_Id") = DBNull.Value
                    End If

                    newOrderDr.Item("Is_Exclude_Drug") = "N"


                    If uclcomb_order_treat_prop.SelectedIndex > 0 Then
                        newOrderDr.Item("Treatment_Type_Id") = uclcomb_order_treat_prop.SelectedValue
                    End If

                    ''memo_OrderMemo
                    '' 
                    If memo_OrderMemo.Text.Trim.Length > 0 Then
                        newOrderDr.Item("Order_Memo") = memo_OrderMemo.Text
                    Else
                        newOrderDr.Item("Order_Memo") = ""
                    End If

                    If txt_Note.Text.Trim.Length > 0 Then
                        newOrderDr.Item("Order_Note") = txt_Note.Text
                    Else
                        newOrderDr.Item("Order_Note") = ""
                    End If

                    'If txt_Flag.Text.Trim.Length > 0 Then
                    '    newOrderDr.Item("Order_Flag") = txt_Flag.Text
                    'Else
                    '    newOrderDr.Item("Order_Flag") = ""
                    'End If

                    newOrderDr.Item("Is_Agree_Sheet") = "N"
                    'newOrderDr.Item("Is_Nhi_Index") = "N"
                    newOrderDr.Item("Is_Prior_Review") = "N"


                    If cb_OrderCheck.Checked Then
                        newOrderDr.Item("Is_Order_Check") = "Y"
                    Else
                        newOrderDr.Item("Is_Order_Check") = "N"
                    End If
                    'If cb_Indication.Checked Then
                    '    newOrderDr.Item("Is_Indication") = "Y"
                    'Else
                    '    newOrderDr.Item("Is_Indication") = "N"
                    'End If
                    If cb_NhiSheet.Checked Then
                        newOrderDr.Item("Is_Nhi_Sheet") = "Y"
                    Else
                        newOrderDr.Item("Is_Nhi_Sheet") = "N"
                    End If



                    If cb_Dc.Checked Then
                        newOrderDr.Item("Dc") = "Y"
                        Try
                            If IsDate(ucl_dtp_enddate.GetUsDateStr) Then
                                newOrderDr.Item("End_Date") = ucl_dtp_enddate.GetUsDateStr.ToString.Substring(0, 10)
                            Else
                                newOrderDr.Item("End_Date") = Date.Parse(SystemDate.ToString("yyyy/MM/dd"))
                            End If
                        Catch ex As Exception
                            newOrderDr.Item("End_Date") = Date.Parse(SystemDate.ToString("yyyy/MM/dd"))
                        End Try
                    Else
                        newOrderDr.Item("Dc") = "N"
                    End If


                    If uclcomb_fix_fee.SelectedIndex > 0 Then
                        newOrderDr.Item("Fix_Order_Id") = uclcomb_fix_fee.SelectedValue
                    Else
                        newOrderDr.Item("Fix_Order_Id") = ""
                    End If

                    'If uclcb_classify.SelectedIndex > 0 Then
                    '    newOrderDr.Item("Manage_Id") = uclcb_classify.SelectedValue
                    'End If

                    'newOrderDr.Item("Dc") = "N"
                    newOrderDr.Item("Is_IC_Card_Order") = "N"
                    newOrderDr.Item("Is_Order_Price_Special") = "N"
                    newOrderDr.Item("Dc_Reason") = ""


                    newOrderDr.Item("End_Date") = "2999/12/31"

                    If cb_orderprice_spec.Checked Then
                        newOrderDr.Item("Is_Order_Price_Special") = "Y"
                    Else
                        newOrderDr.Item("Is_Order_Price_Special") = "N"
                    End If

                    'If cb_incorder_mark.Checked Then
                    '    newOrderDr.Item("Include_Order_Mark") = "Y"
                    'Else
                    '    newOrderDr.Item("Include_Order_Mark") = "N"
                    'End If
                    newOrderDr.Item("Include_Order_Mark") = txt_IncludeOrder.Text.Trim

                    '2010-04-29 Add By Alan
                    'If cb_OPD.Checked Then
                    '    newOrderDr.Item("Insu_Cover_Opd") = "Y"
                    'Else
                    '    newOrderDr.Item("Insu_Cover_Opd") = "N"
                    'End If
                    If cbo_OPD.SelectedValue = "" Then
                        newOrderDr.Item("Insu_Cover_Opd") = 0
                    Else
                        newOrderDr.Item("Insu_Cover_Opd") = cbo_OPD.SelectedValue

                    End If
                    'If cb_EMG.Checked Then
                    '    newOrderDr.Item("Insu_Cover_Emg") = "Y"
                    'Else
                    '    newOrderDr.Item("Insu_Cover_Emg") = "N"
                    'End If
                    If cbo_EMG.SelectedValue = "" Then
                        newOrderDr.Item("Insu_Cover_Emg") = 0
                    Else
                        newOrderDr.Item("Insu_Cover_Emg") = cbo_EMG.SelectedValue

                    End If
                    'If cb_IPD.Checked Then
                    '    newOrderDr.Item("Insu_Cover_Ipd") = "Y"
                    'Else
                    '    newOrderDr.Item("Insu_Cover_Ipd") = "N"
                    'End If
                    If cbo_IPD.SelectedValue = "" Then
                        newOrderDr.Item("Insu_Cover_Ipd") = 0
                    Else
                        newOrderDr.Item("Insu_Cover_Ipd") = cbo_IPD.SelectedValue

                    End If

                    newOrderDr.Item("Is_Prior_Review") = "N"
                    'newOrderDr.Item("Brand") = ""
                    'newOrderDr.Item("Is_Inventory") = "N"
                    newOrderDr.Item("Is_Icd_Check") = "N"
                    newOrderDr.Item("Create_User") = loginUser
                    newOrderDr.Item("Create_Time") = SystemDate
                    newOrderDr.Item("Modified_User") = loginUser
                    newOrderDr.Item("Modified_Time") = SystemDate

                    newOrderDT.Rows.Add(newOrderDr)

                End If


                '-----------------------------------------------------------------
                'check dialog的動作
                Dim checkDS As DataSet = Nothing
                If DataSetUtil.IsContainsData(keepOrderDT) Then
                    checkDS = pub.checkProcessStatus(keepOrderDT, oldToProcessOrderDT)
                    If DataSetUtil.IsContainsData(checkDS) Then

                        'MessageHandling.showError("有資料 " & checkDS.DataSetName)

                        If checkDS.Tables.Contains("Delete") Then
                            Dim selectDR As DialogResult = MessageHandling.ShowQuestionMsg("CMMCMMB300", New String() {"要刪除資料?"})
                        Else

                        End If

                    Else

                        'MessageHandling.showError("無資料 " & checkDS.DataSetName)
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"無資料 " & checkDS.DataSetName}, "")
                    End If
                Else
                    checkDS = pub.checkProcessStatus(Nothing, newOrderDT)
                    If DataSetUtil.IsContainsData(checkDS) Then

                        'MessageHandling.showError("有資料 " & checkDS.DataSetName)

                        If checkDS.Tables.Contains("Delete") Then
                            'MessageHandling.showQuestion("刪除資料 ")
                            MessageHandling.ShowQuestionMsg("CMMCMMB300", New String() {"刪除資料?"})

                        Else

                        End If
                    Else

                        'MessageHandling.showError("無資料 " & checkDS.DataSetName)
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"無資料 " & checkDS.DataSetName}, "")
                    End If
                End If

                '-----------------------------------------------------------------
                '小結 order(update or insert)

                If DataSetUtil.IsContainsData(checkDS) Then


                    'If checkDS.Tables.Contains("Insert") Then
                    '    Dim insertDT As DataTable = checkDS.Tables("Insert").Copy
                    '    insertDT.TableName = "insertorder"
                    '    OrderRelatedDS.Tables.Add(insertDT)
                    'ElseIf checkDS.Tables.Contains("Update") Then
                    '    Dim updateDT As DataTable = checkDS.Tables("Update").Copy
                    '    updateDT.TableName = "updateorder"
                    '    OrderRelatedDS.Tables.Add(updateDT)
                    'ElseIf checkDS.Tables.Contains("Delete") Then
                    '    Dim deleteDT As DataTable = checkDS.Tables("Delete").Copy
                    '    deleteDT.TableName = "deleteorder"
                    '    OrderRelatedDS.Tables.Add(deleteDT)
                    'End If
                    If checkDS.Tables.Contains("Update") Then
                        Dim updateDT As DataTable = checkDS.Tables("Update").Copy
                        updateDT.TableName = "updateorder"
                        OrderRelatedDS.Tables.Add(updateDT)
                    ElseIf checkDS.Tables.Contains("Insert") Then
                        Dim insertDT As DataTable = checkDS.Tables("Insert").Copy
                        insertDT.TableName = "insertorder"
                        OrderRelatedDS.Tables.Add(insertDT)
                    ElseIf checkDS.Tables.Contains("Delete") Then
                        Dim deleteDT As DataTable = checkDS.Tables("Delete").Copy
                        deleteDT.TableName = "deleteorder"
                        OrderRelatedDS.Tables.Add(deleteDT)
                    End If


                    'majorcare
                    If uclcomb_majorcare.SelectedIndex > 0 Then
                        'has項目才要異動
                        Dim containFlag As Boolean = False

                        If DataSetUtil.IsContainsData(keepOrderMajorcareDT) Then
                            '檢查是否有在紀錄內?
                            For Each dr As DataRow In keepOrderMajorcareDT.Rows
                                If CType(dr.Item("Majorcare_Code"), String).Trim.Equals(uclcomb_majorcare.SelectedValue.Trim) Then
                                    containFlag = True
                                End If
                            Next
                        End If

                        If Not containFlag Then
                            '不存在,增入
                            Dim OrderMCDR As DataRow = OrderMajorcareDT.NewRow
                            'OrderMCDR.Item("Order_Code") = ucl_txtcq_ordercode.Text.Trim
                            '2010-04-28 delete by Alan-OK
                            OrderMCDR.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim()
                            'OrderMCDR.Item("Order_Code") = PUBOrderUI_ucl_dcbg_order.Text.Trim

                            OrderMCDR.Item("Majorcare_Code") = uclcomb_majorcare.SelectedValue.Trim
                            OrderMCDR.Item("Mode") = "Insert"
                            OrderMajorcareDT.Rows.Add(OrderMCDR)

                        End If
                    Else
                        '項目勾掉要刪除??
                        Dim OrderMCDR As DataRow = OrderMajorcareDT.NewRow
                        'OrderMCDR.Item("Order_Code") = ucl_txtcq_ordercode.Text.Trim
                        '2010-04-28 delete by Alan-OK
                        OrderMCDR.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim()
                        'OrderMCDR.Item("Order_Code") = PUBOrderUI_ucl_dcbg_order.Text.Trim

                        OrderMCDR.Item("Majorcare_Code") = uclcomb_majorcare.SelectedValue.Trim
                        OrderMCDR.Item("Mode") = "Delete"
                        OrderMajorcareDT.Rows.Add(OrderMCDR)
                    End If



                    '------------------------------------------------------
                    '小結 curecontrol, majorcare, 

                    If checkCureFlag Then
                        If DataSetUtil.IsContainsData(cureControlDT) Then '有Is_New註記
                            cureControlDT.TableName = "curecontrol"
                            OrderRelatedDS.Tables.Add(cureControlDT.Copy)
                        End If
                    Else
                        '沒勾選的編輯就不理...
                    End If

                    If DataSetUtil.IsContainsData(OrderMajorcareDT) Then '有Is_New註記
                        OrderMajorcareDT.TableName = "majorcare"
                        OrderRelatedDS.Tables.Add(OrderMajorcareDT.Copy)
                    End If



                    If DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) Then
                        '畫面至少會有一筆

                        Dim UIPriceDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

                        ' [Effect_Date],[Order_Code] [Main_Identity_Id],[Price],[Add_Price],[Material_Ratio],[Material_Account_Id],
                        '[Is_Emg_Add],[Is_Kid_Add],[Is_Dental_Add],[Is_Holiday_Add],[Insu_Code],[Insu_Cover_Opd],[Insu_Cover_Emg],
                        '[Insu_Cover_Ipd],[Insu_Account_Id],[Insu_Order_Type_Id],[Opd_Add_Order_Code],[Emg_Add_Order_Code],
                        '[Ipd_Add_Order_Code],[Emg_Nursing_Add_Order_Code],[Ipd_Nursing_Add_Order_Code],[Dc],[End_Date],
                        '[Create_User],[Create_Time],[Modified_User],[Modified_Time],[Insu_Group_Code]
                        'mapping
                        '"主身分", "生效日", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", "假日加成", "群組醫令碼", 
                        '"門診可用", "急診可用", "住院可用", "健保碼", "健保費用項目", "健保醫令類別"

                        Dim addOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema

                        '----------------------------------------------------------------------------
                        'Order_Price
                        '看有無查出資料
                        '有的話要把舊的時間改掉

                        '加入keepOrderPriceDT
                        For Each dr As DataRow In UIPriceDS.Tables(0).Rows
                            If (Not IsDBNull(dr.Item(OrderPriceColumn(0)))) AndAlso CType(dr.Item(OrderPriceColumn(0)), String).Trim.Length > 0 _
                            AndAlso (Not (CType(dr.Item(OrderPriceColumn(18)), String).Trim.Equals("Y") And CType(dr.Item(OrderPriceColumn(19)), String).Trim.Equals("Y"))) Then
                                Dim MainId As String = CType(dr.Item(OrderPriceColumn(0)), String).Trim
                                Dim EffectDate As Date = CType(dr.Item(OrderPriceColumn(1)), Date)
                                Dim newOPDr As DataRow = addOrderPriceDT.NewRow

                                'TODO: process new...
                                '新增

                                'process new...
                                newOPDr.Item("Effect_Date") = EffectDate
                                newOPDr.Item("Main_Identity_Id") = MainId
                                'newOPDr.Item("Order_Code") = ucl_txtcq_ordercode.Text.Trim
                                '2010-04-28 delete by Alan
                                newOPDr.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim()
                                'newOPDr.Item("Order_Code") = PUBOrderUI_ucl_dcbg_order.Text.Trim

                                newOPDr.Item("Price") = CType(dr.Item(OrderPriceColumn(2)), Decimal)
                                newOPDr.Item("Add_Price") = CType(dr.Item(OrderPriceColumn(3)), Decimal)

                                If Not IsDBNull(dr.Item(OrderPriceColumn(4))) Then
                                    If IsDate(CType(dr.Item(OrderPriceColumn(4)), Date)) Then
                                        newOPDr.Item("End_Date") = CType(dr.Item(OrderPriceColumn(4)), Date)
                                    Else
                                        newOPDr.Item("End_Date") = DBNull.Value
                                    End If
                                Else
                                    newOPDr.Item("End_Date") = DBNull.Value
                                End If

                                '2010-11-23 Add By Alan-若PUB_Order該筆資料DC，則PUB_Order_Price亦需同步迄日
                                If cb_Dc.Checked Then
                                    newOPDr.Item("End_Date") = CType(ucl_dtp_enddate.Text.Trim, Date)
                                End If

                                If Not IsDBNull(dr.Item(OrderPriceColumn(5))) Then
                                    newOPDr.Item("Order_Ratio") = CType(dr.Item(OrderPriceColumn(5)), Decimal)
                                Else
                                    newOPDr.Item("Order_Ratio") = 1
                                End If

                                newOPDr.Item("Material_Ratio") = 0
                                newOPDr.Item("Material_Account_Id") = ""

                                If Not IsDBNull(dr.Item(OrderPriceColumn(6))) Then
                                    newOPDr.Item("Is_Emg_Add") = CType(dr.Item(OrderPriceColumn(6)), String).Trim
                                Else
                                    newOPDr.Item("Is_Emg_Add") = "N"
                                End If
                                If Not IsDBNull(dr.Item(OrderPriceColumn(7))) Then
                                    newOPDr.Item("Is_Kid_Add") = CType(dr.Item(OrderPriceColumn(7)), String).Trim
                                Else
                                    newOPDr.Item("Is_Kid_Add") = "N"
                                End If
                                If Not IsDBNull(dr.Item(OrderPriceColumn(8))) Then
                                    newOPDr.Item("Is_Dental_Add") = CType(dr.Item(OrderPriceColumn(8)), String).Trim
                                Else
                                    newOPDr.Item("Is_Dental_Add") = "N"
                                End If

                                If Not IsDBNull(dr.Item(OrderPriceColumn(9))) Then
                                    newOPDr.Item("Is_Dept_Add") = CType(dr.Item(OrderPriceColumn(9)), String).Trim
                                Else
                                    newOPDr.Item("Is_Dept_Add") = "N"
                                End If

                                newOPDr.Item("Is_Holiday_Add") = "N"

                                '2091014TODOhas群組醫令給群組醫令碼
                                If Not IsDBNull(dr.Item(OrderPriceColumn(10))) Then
                                    newOPDr.Item("Opd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(10)), String).Trim
                                    newOPDr.Item("Emg_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(10)), String).Trim
                                    newOPDr.Item("Ipd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(10)), String).Trim
                                    newOPDr.Item("Emg_Nursing_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(10)), String).Trim
                                    newOPDr.Item("Ipd_Nursing_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(10)), String).Trim
                                Else
                                    newOPDr.Item("Opd_Add_Order_Code") = ""
                                    newOPDr.Item("Emg_Add_Order_Code") = ""
                                    newOPDr.Item("Ipd_Add_Order_Code") = ""
                                    newOPDr.Item("Emg_Nursing_Add_Order_Code") = ""
                                    newOPDr.Item("Ipd_Nursing_Add_Order_Code") = ""
                                End If






                                'If Not IsDBNull(dr.Item(OrderPriceColumn(11))) Then
                                '    newOPDr.Item("Insu_Cover_Opd") = CType(dr.Item(OrderPriceColumn(11)), String).Trim
                                'Else
                                '    newOPDr.Item("Insu_Cover_Opd") = "N"
                                'End If
                                'If Not IsDBNull(dr.Item(OrderPriceColumn(12))) Then
                                '    newOPDr.Item("Insu_Cover_Emg") = CType(dr.Item(OrderPriceColumn(12)), String).Trim
                                'Else
                                '    newOPDr.Item("Insu_Cover_Emg") = "N"
                                'End If
                                'If Not IsDBNull(dr.Item(OrderPriceColumn(13))) Then
                                '    newOPDr.Item("Insu_Cover_Ipd") = CType(dr.Item(OrderPriceColumn(13)), String).Trim
                                'Else
                                '    newOPDr.Item("Insu_Cover_Ipd") = "N"
                                'End If


                                '身分2健保的
                                If Not IsDBNull(dr.Item(OrderPriceColumn(14))) Then
                                    newOPDr.Item("Insu_Code") = CType(dr.Item(OrderPriceColumn(14)), String).Trim
                                End If

                                If Not IsDBNull(dr.Item(OrderPriceColumn(16))) Then
                                    newOPDr.Item("Insu_Account_Id") = CType(dr.Item(OrderPriceColumn(16)), String).Trim
                                End If

                                If Not IsDBNull(dr.Item(OrderPriceColumn(17))) Then
                                    newOPDr.Item("Insu_Order_Type_Id") = CType(dr.Item(OrderPriceColumn(17)), String).Trim
                                End If

                                newOPDr.Item("Insu_Apply_Price") = 0


                                newOPDr.Item("Create_User") = loginUser
                                newOPDr.Item("Create_Time") = SystemDate
                                newOPDr.Item("Modified_User") = loginUser
                                newOPDr.Item("Modified_Time") = SystemDate

                                newOPDr.Item("Dc") = "N"
                                '2010-11-23 Add By Alan-若PUB_Order該筆資料DC，則PUB_Order_Price亦需同步為DC
                                If cb_Dc.Checked Then
                                    newOPDr.Item("Dc") = "Y"
                                End If

                                'TODO....
                                addOrderPriceDT.Rows.Add(newOPDr)
                            End If

                        Next

                        addNewGridRow()

                        'keepOrderPriceDT 更新 or 新增醫令
                        'addOrderPriceDT 新增

                        '------------------------------------------------------
                        '小結 orderprice, addorderprice


                        'If DataSetUtil.IsContainsData(keepOrderPriceDT) Then
                        '    keepOrderPriceDT.TableName = "updateorderprice"
                        '    OrderRelatedDS.Tables.Add(keepOrderPriceDT.Copy)
                        'End If

                        If DataSetUtil.IsContainsData(addOrderPriceDT) Then
                            addOrderPriceDT.TableName = "insertorderprice"
                            OrderRelatedDS.Tables.Add(addOrderPriceDT.Copy)
                        End If
                        '----------------------------------------------------

                        'UIPriceDS取出key
                        Dim EmgAddUpdate As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                        Dim EmgAddInsert As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema

                        Dim KidAddUpdate As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                        Dim KidAddInsert As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema

                        Dim DentalAddUpdate As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                        Dim DentalAddInsert As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema

                        Dim DeptAddUpdate As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                        Dim DeptAddInsert As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                        'Dim HolidayAddUpdate As DataTable = PubHolidayAddDataTableFactory.getDataTableWithSchema
                        'Dim HolidayAddInsert As DataTable = PubHolidayAddDataTableFactory.getDataTableWithSchema

                        '群組依令
                        Dim AddOrderDT As DataTable = PubAddOrderDataTableFactory.getDataTableWithSchema
                        Dim AddOrderDtlDT As DataTable = PubAddOrderDetailDataTableFactory.getDataTableWithSchema
                        Dim AddOptionOrderDT As DataTable = PubAddOptionOrderDataTableFactory.getDataTableWithSchema

                        '取得加成資訊
                        If gblInsuCode <> "" Then
                            Dim pvtAddDT As New DataTable
                            pvtAddDT = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)

                            If pvtAddDT IsNot Nothing AndAlso pvtAddDT.Rows.Count > 0 Then

                                Dim pvtIsOpenEmgAddOption, pvtO, pvtE, pvtI As Boolean

                                For i As Integer = 0 To (UIPriceDS.Tables(0).Rows.Count - 1)

                                    If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(18)), String).Trim.Equals("N") AndAlso _
                                        (Not IsDBNull(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)))) AndAlso _
                                        (CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)), String).Trim.Length > 0) Then

                                        Dim mianId As String = CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)), String).Trim

                                        '急件加成
                                        If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(6)), String).Trim.Equals("Y") Then

                                            If pvtIsOpenEmgAddOption = False Then

                                                Dim openDialog As PUBEmgAddOptionUI = New PUBEmgAddOptionUI
                                                openDialog.ShowDialog()

                                                If openDialog.chk_O.Checked Then pvtO = True
                                                If openDialog.chk_E.Checked Then pvtE = True
                                                If openDialog.chk_I.Checked Then pvtI = True

                                                pvtIsOpenEmgAddOption = True

                                            End If

                                            For n = 0 To 2
                                                If n = 0 AndAlso pvtO = False Then Continue For
                                                If n = 1 AndAlso pvtE = False Then Continue For
                                                If n = 2 AndAlso pvtI = False Then Continue For

                                                Dim emgI As DataRow = EmgAddInsert.NewRow
                                                emgI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Trim
                                                emgI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                                emgI.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
                                                emgI.Item("Emg_Add_Ratio") = pvtAddDT.Rows(0).Item("Emg_Add_Ratio")
                                                emgI.Item("Dc") = "N"
                                                emgI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(4).ToString.Trim
                                                emgI.Item("Create_User") = loginUser
                                                emgI.Item("Create_Time") = SystemDate

                                                Select Case n
                                                    Case 0
                                                        emgI.Item("Pt_From_Id") = "O"
                                                    Case 1
                                                        emgI.Item("Pt_From_Id") = "E"
                                                    Case 2
                                                        emgI.Item("Pt_From_Id") = "I"
                                                End Select
                                                EmgAddInsert.Rows.Add(emgI)
                                            Next

                                            EmgAddInsert.TableName = "emginsert"

                                        End If

                                        '兒童加成
                                        If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(7)), String).Trim.Equals("Y") Then

                                            For n = 0 To 4
                                                Dim pvtIsExist As Boolean
                                                Dim kidI As DataRow = KidAddInsert.NewRow
                                                kidI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Trim
                                                kidI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                                kidI.Item("Pt_From_Id") = ""
                                                kidI.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
                                                kidI.Item("Age_Type_Id") = "2"
                                                kidI.Item("Dc") = "N"
                                                kidI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(4).ToString.Trim
                                                kidI.Item("Create_User") = loginUser
                                                kidI.Item("Create_Time") = SystemDate

                                                Select Case n
                                                    Case 0
                                                        If pvtAddDT.Rows(0).Item("Kid_Add_Ratio1").ToString.Trim <> "" AndAlso _
                                                           CDec(pvtAddDT.Rows(0).Item("Kid_Add_Ratio1").ToString.Trim) > 0.0 Then
                                                            kidI.Item("Age_Start") = "0"
                                                            kidI.Item("Age_End") = "5"
                                                            kidI.Item("Kid_Add_Ratio") = pvtAddDT.Rows(0).Item("Kid_Add_Ratio1").ToString.Trim
                                                            pvtIsExist = True
                                                        Else
                                                            pvtIsExist = False
                                                        End If

                                                    Case 1
                                                        If pvtAddDT.Rows(0).Item("Kid_Add_Ratio2").ToString.Trim <> "" AndAlso _
                                                           CDec(pvtAddDT.Rows(0).Item("Kid_Add_Ratio2").ToString.Trim) > 0.0 Then
                                                            kidI.Item("Age_Start") = "6"
                                                            kidI.Item("Age_End") = "23"
                                                            kidI.Item("Kid_Add_Ratio") = pvtAddDT.Rows(0).Item("Kid_Add_Ratio2").ToString.Trim
                                                            pvtIsExist = True
                                                        Else
                                                            pvtIsExist = False
                                                        End If

                                                    Case 2
                                                        If pvtAddDT.Rows(0).Item("Kid_Add_Ratio3").ToString.Trim <> "" AndAlso _
                                                           CDec(pvtAddDT.Rows(0).Item("Kid_Add_Ratio3").ToString.Trim) > 0.0 Then
                                                            kidI.Item("Age_Start") = "24"
                                                            kidI.Item("Age_End") = "83"
                                                            kidI.Item("Kid_Add_Ratio") = pvtAddDT.Rows(0).Item("Kid_Add_Ratio3").ToString.Trim
                                                            pvtIsExist = True
                                                        Else
                                                            pvtIsExist = False
                                                        End If

                                                    Case 3
                                                        If pvtAddDT.Rows(0).Item("Kid_Add_Ratio4").ToString.Trim <> "" AndAlso _
                                                           CDec(pvtAddDT.Rows(0).Item("Kid_Add_Ratio4").ToString.Trim) > 0.0 Then
                                                            kidI.Item("Age_Start") = "0"
                                                            kidI.Item("Age_End") = "48"
                                                            kidI.Item("Kid_Add_Ratio") = pvtAddDT.Rows(0).Item("Kid_Add_Ratio4").ToString.Trim
                                                            pvtIsExist = True
                                                        Else
                                                            pvtIsExist = False
                                                        End If

                                                    Case 4
                                                        If pvtAddDT.Rows(0).Item("Kid_Add_Ratio5").ToString.Trim <> "" AndAlso _
                                                           CDec(pvtAddDT.Rows(0).Item("Kid_Add_Ratio5").ToString.Trim) > 0.0 Then
                                                            kidI.Item("Age_Start") = "0"
                                                            kidI.Item("Age_End") = "47"
                                                            kidI.Item("Kid_Add_Ratio") = pvtAddDT.Rows(0).Item("Kid_Add_Ratio5").ToString.Trim
                                                            pvtIsExist = True
                                                        Else
                                                            pvtIsExist = False
                                                        End If

                                                End Select

                                                If pvtIsExist Then KidAddInsert.Rows.Add(kidI)

                                            Next

                                            KidAddInsert.TableName = "kidinsert"

                                        End If

                                        '牙科加成
                                        If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(8)), String).Trim.Equals("Y") Then
                                            Dim dentalI As DataRow = DentalAddInsert.NewRow
                                            dentalI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Trim
                                            dentalI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                            dentalI.Item("Pt_From_Id") = ""
                                            dentalI.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
                                            dentalI.Item("Dental_Add_Ratio") = pvtAddDT.Rows(0).Item("Dental_Add_Ratio").ToString.Trim
                                            dentalI.Item("Dc") = "N"
                                            dentalI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(4).ToString.Trim
                                            dentalI.Item("Create_User") = loginUser
                                            dentalI.Item("Create_Time") = SystemDate

                                            DentalAddInsert.Rows.Add(dentalI)

                                            DentalAddInsert.TableName = "dentalinsert"

                                        End If

                                        '科別加成
                                        If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(9)), String).Trim.Equals("Y") Then

                                            '取得科別
                                            Dim pvtDept As New ArrayList
                                            Dim pvtDeptStr As String = pvtAddDT.Rows(0).Item("Dept_Code_Set").ToString.Trim
                                            Dim pvtCutStr As String = ","
                                            Dim pvtValue As String

                                            Dim pvtCutIndex As Integer
                                            Do
                                                pvtCutIndex = pvtDeptStr.IndexOf(pvtCutStr)
                                                If pvtCutIndex = -1 Then
                                                    pvtDept.Add(pvtDeptStr)
                                                    Exit Do
                                                Else
                                                    pvtValue = pvtDeptStr.Substring(0, pvtCutIndex)
                                                    pvtDeptStr = pvtDeptStr.Substring(pvtCutIndex + 1)
                                                    pvtDept.Add(pvtValue)
                                                End If
                                            Loop

                                            For n = 0 To pvtDept.Count - 1

                                                Dim deptI As DataRow = DeptAddInsert.NewRow
                                                deptI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Trim
                                                deptI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                                deptI.Item("Pt_From_Id") = ""
                                                deptI.Item("Dept_Code") = pvtDept.Item(n)
                                                deptI.Item("Order_Code") = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
                                                deptI.Item("Dept_Add_Ratio") = pvtAddDT.Rows(0).Item("Dept_Add_Ratio").ToString.Trim
                                                deptI.Item("Dc") = "N"
                                                deptI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(4).ToString.Trim
                                                deptI.Item("Create_User") = loginUser
                                                deptI.Item("Create_Time") = SystemDate

                                                DeptAddInsert.Rows.Add(deptI)

                                            Next

                                            DeptAddInsert.TableName = "deptinsert"

                                        End If

                                    End If
                                Next
                            End If
                        End If

                        For i As Integer = 0 To (UIPriceDS.Tables(0).Rows.Count - 1)
                            'Dim keyindex As String = i

                            If (Not (CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(18)), String).Trim.Equals("Y") AndAlso _
                                     CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(19)), String).Trim.Equals("Y"))) AndAlso _
                                     (Not IsDBNull(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)))) AndAlso _
                                     (CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)), String).Trim.Length > 0) Then

                                Dim mianId As String = CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)), String).Trim

                                'If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(6)), String).Trim.Equals("Y") Then
                                '    '急件
                                '    '{"Effect_Date", "Main_Identity_Id", "Pt_From_Id", "Order_Code", _
                                '    '"Emg_Add_Ratio", "Dc", "End_Date", "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Is_New"}
                                '    If emgHash.ContainsKey(mianId) Then
                                '        Dim emgDT As DataTable = CType(emgHash.Item(mianId), DataTable)
                                '        For Each dr As DataRow In emgDT.Rows

                                '            If CType(dr.Item("Is_New"), String).Trim.Equals("Y") Then

                                '                If CType(dr.Item("Dc"), String).Trim.Equals("Y") Then
                                '                    '不要

                                '                Else
                                '                    'Dc=N is new > insert
                                '                    Dim emgI As DataRow = EmgAddInsert.NewRow
                                '                    emgI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                    emgI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                    emgI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                    emgI.Item("Order_Code") = dr.Item("Order_Code")
                                '                    emgI.Item("Emg_Add_Ratio") = dr.Item("Emg_Add_Ratio")
                                '                    emgI.Item("Dc") = dr.Item("Dc")
                                '                    If Not IsDBNull(dr.Item("End_Date")) Then
                                '                        emgI.Item("End_Date") = dr.Item("End_Date")
                                '                    End If
                                '                    emgI.Item("Create_User") = dr.Item("Create_User")
                                '                    emgI.Item("Create_Time") = dr.Item("Create_Time")

                                '                    EmgAddInsert.Rows.Add(emgI)
                                '                End If

                                '            Else
                                '                'no new> update
                                '                Dim emgI As DataRow = EmgAddUpdate.NewRow
                                '                emgI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                emgI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                emgI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                emgI.Item("Order_Code") = dr.Item("Order_Code")
                                '                emgI.Item("Emg_Add_Ratio") = dr.Item("Emg_Add_Ratio")
                                '                emgI.Item("Dc") = dr.Item("Dc")
                                '                If Not IsDBNull(dr.Item("End_Date")) Then
                                '                    emgI.Item("End_Date") = dr.Item("End_Date")
                                '                End If
                                '                emgI.Item("Create_User") = dr.Item("Create_User")
                                '                emgI.Item("Create_Time") = dr.Item("Create_Time")
                                '                emgI.Item("Modified_User") = dr.Item("Modified_User")
                                '                emgI.Item("Modified_Time") = dr.Item("Modified_Time")

                                '                EmgAddUpdate.Rows.Add(emgI)
                                '            End If

                                '            '...
                                '        Next
                                '        EmgAddUpdate.TableName = "emgupdate"
                                '        EmgAddInsert.TableName = "emginsert"

                                '    End If
                                'End If

                                'If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(7)), String).Trim.Equals("Y") Then
                                '    '兒童
                                '    If chdHash.ContainsKey(mianId) Then
                                '        Dim kidDT As DataTable = CType(chdHash.Item(mianId), DataTable)
                                '        For Each dr As DataRow In kidDT.Rows

                                '            If CType(dr.Item("Is_New"), String).Trim.Equals("Y") Then

                                '                If CType(dr.Item("Dc"), String).Trim.Equals("Y") Then
                                '                    '不要

                                '                Else
                                '                    'Dc=N is new > insert
                                '                    Dim kidI As DataRow = KidAddInsert.NewRow
                                '                    kidI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                    kidI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                    kidI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                    kidI.Item("Order_Code") = dr.Item("Order_Code")
                                '                    kidI.Item("Age_Type_Id") = dr.Item("Age_Type_Id")
                                '                    kidI.Item("Age_Start") = dr.Item("Age_Start")
                                '                    kidI.Item("Age_End") = dr.Item("Age_End")
                                '                    kidI.Item("Kid_Add_Ratio") = dr.Item("Kid_Add_Ratio")
                                '                    kidI.Item("Dc") = dr.Item("Dc")
                                '                    If Not IsDBNull(dr.Item("End_Date")) Then
                                '                        kidI.Item("End_Date") = dr.Item("End_Date")
                                '                    End If
                                '                    kidI.Item("Create_User") = dr.Item("Create_User")
                                '                    kidI.Item("Create_Time") = dr.Item("Create_Time")

                                '                    KidAddInsert.Rows.Add(kidI)
                                '                End If

                                '            Else
                                '                'no new> update
                                '                Dim kidI As DataRow = KidAddUpdate.NewRow
                                '                kidI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                kidI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                kidI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                kidI.Item("Order_Code") = dr.Item("Order_Code")
                                '                kidI.Item("Age_Type_Id") = dr.Item("Age_Type_Id")
                                '                kidI.Item("Age_Start") = dr.Item("Age_Start")
                                '                kidI.Item("Age_End") = dr.Item("Age_End")
                                '                kidI.Item("Kid_Add_Ratio") = dr.Item("Kid_Add_Ratio")
                                '                kidI.Item("Dc") = dr.Item("Dc")
                                '                If Not IsDBNull(dr.Item("End_Date")) Then
                                '                    kidI.Item("End_Date") = dr.Item("End_Date")
                                '                End If
                                '                kidI.Item("Create_User") = dr.Item("Create_User")
                                '                kidI.Item("Create_Time") = dr.Item("Create_Time")
                                '                kidI.Item("Modified_User") = dr.Item("Modified_User")
                                '                kidI.Item("Modified_Time") = dr.Item("Modified_Time")

                                '                KidAddUpdate.Rows.Add(kidI)
                                '            End If
                                '            '...
                                '        Next

                                '        KidAddUpdate.TableName = "kidupdate"
                                '        KidAddInsert.TableName = "kidinsert"
                                '    End If
                                'End If

                                'If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(8)), String).Trim.Equals("Y") Then
                                '    '牙科
                                '    If tohHash.ContainsKey(mianId) Then
                                '        Dim dentalDT As DataTable = CType(tohHash.Item(mianId), DataTable)
                                '        For Each dr As DataRow In dentalDT.Rows
                                '            If CType(dr.Item("Is_New"), String).Trim.Equals("Y") Then

                                '                If CType(dr.Item("Dc"), String).Trim.Equals("Y") Then
                                '                    '不要

                                '                Else
                                '                    'Dc=N is new > insert
                                '                    Dim dentalI As DataRow = DentalAddInsert.NewRow
                                '                    dentalI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                    dentalI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                    dentalI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                    dentalI.Item("Order_Code") = dr.Item("Order_Code")
                                '                    dentalI.Item("Dental_Add_Ratio") = dr.Item("Dental_Add_Ratio")
                                '                    dentalI.Item("Dc") = dr.Item("Dc")
                                '                    If Not IsDBNull(dr.Item("End_Date")) Then
                                '                        dentalI.Item("End_Date") = dr.Item("End_Date")
                                '                    End If
                                '                    dentalI.Item("Create_User") = dr.Item("Create_User")
                                '                    dentalI.Item("Create_Time") = dr.Item("Create_Time")

                                '                    DentalAddInsert.Rows.Add(dentalI)
                                '                End If

                                '            Else
                                '                'no new> update
                                '                Dim dentalI As DataRow = DentalAddUpdate.NewRow
                                '                dentalI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                dentalI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                dentalI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                dentalI.Item("Order_Code") = dr.Item("Order_Code")
                                '                dentalI.Item("Dental_Add_Ratio") = dr.Item("Dental_Add_Ratio")
                                '                dentalI.Item("Dc") = dr.Item("Dc")
                                '                If Not IsDBNull(dr.Item("End_Date")) Then
                                '                    dentalI.Item("End_Date") = dr.Item("End_Date")
                                '                End If
                                '                dentalI.Item("Create_User") = dr.Item("Create_User")
                                '                dentalI.Item("Create_Time") = dr.Item("Create_Time")
                                '                dentalI.Item("Modified_User") = dr.Item("Modified_User")
                                '                dentalI.Item("Modified_Time") = dr.Item("Modified_Time")

                                '                DentalAddUpdate.Rows.Add(dentalI)
                                '            End If

                                '            '...
                                '        Next

                                '        DentalAddUpdate.TableName = "dentalupdate"
                                '        DentalAddInsert.TableName = "dentalinsert"
                                '    End If
                                'End If

                                'If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(9)), String).Trim.Equals("Y") Then
                                '    '假日
                                '    If hlyHash.ContainsKey(mianId) Then
                                '        Dim holidayDT As DataTable = CType(hlyHash.Item(mianId), DataTable)
                                '        For Each dr As DataRow In holidayDT.Rows

                                '            If CType(dr.Item("Is_New"), String).Trim.Equals("Y") Then

                                '                If CType(dr.Item("Dc"), String).Trim.Equals("Y") Then
                                '                    '不要

                                '                Else
                                '                    'Dc=N is new > insert
                                '                    Dim holidayI As DataRow = HolidayAddInsert.NewRow
                                '                    holidayI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                    holidayI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                    holidayI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                    holidayI.Item("Order_Code") = dr.Item("Order_Code")
                                '                    holidayI.Item("Holiday_Add_Ratio") = dr.Item("Holiday_Add_Ratio")
                                '                    holidayI.Item("Dc") = dr.Item("Dc")
                                '                    If Not IsDBNull(dr.Item("End_Date")) Then
                                '                        holidayI.Item("End_Date") = dr.Item("End_Date")
                                '                    End If
                                '                    holidayI.Item("Create_User") = dr.Item("Create_User")
                                '                    holidayI.Item("Create_Time") = dr.Item("Create_Time")

                                '                    HolidayAddInsert.Rows.Add(holidayI)
                                '                End If

                                '            Else
                                '                'no new> update
                                '                Dim holidayI As DataRow = HolidayAddUpdate.NewRow
                                '                holidayI.Item("Effect_Date") = dr.Item("Effect_Date")
                                '                holidayI.Item("Main_Identity_Id") = dr.Item("Main_Identity_Id")
                                '                holidayI.Item("Pt_From_Id") = dr.Item("Pt_From_Id")
                                '                holidayI.Item("Order_Code") = dr.Item("Order_Code")
                                '                holidayI.Item("Holiday_Add_Ratio") = dr.Item("Holiday_Add_Ratio")
                                '                holidayI.Item("Dc") = dr.Item("Dc")
                                '                If Not IsDBNull(dr.Item("End_Date")) Then
                                '                    holidayI.Item("End_Date") = dr.Item("End_Date")
                                '                End If
                                '                holidayI.Item("Create_User") = dr.Item("Create_User")
                                '                holidayI.Item("Create_Time") = dr.Item("Create_Time")
                                '                holidayI.Item("Modified_User") = dr.Item("Modified_User")
                                '                holidayI.Item("Modified_Time") = dr.Item("Modified_Time")

                                '                HolidayAddUpdate.Rows.Add(holidayI)
                                '            End If

                                '            '...
                                '        Next

                                '        HolidayAddUpdate.TableName = "holidayupdate"
                                '        HolidayAddInsert.TableName = "holidayinsert"
                                '    End If
                                'End If


                                If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(10)), String).Trim.Equals("Y") Then
                                    '群組醫令碼  PUB_Add_Order, PUB_Add_Order_Detail, PUB_Add_Option_Order
                                    'TODO  goHash = { rowKey ,   groupHash}
                                    ' groupHash = "AddOrderCodeDT", AddOrderDT 
                                    '             {AddOrderCode-GroupId, nexthash}

                                    ' nexthash = ["AddOrderDetail", AddOrderDetailDT], 
                                    '            ["AddOptionalOrder", GroupAlterHash = {OrderCode-AddOrderDetailNo, OrderAlterDataDT}]


                                    'addorder欄位, query, 更新手上的, 刪除all, insert
                                    Dim rowKey As String = CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(0)), String).Trim


                                    '----------------------------------------------------------------------------------------
                                    '群組依令
                                    '----------------------------------------------------------------------------------------
                                    'AddOrderDT
                                    'AddOrderDtlDT
                                    'AddOptionOrderDT
                                    If goHash.ContainsKey(rowKey) Then

                                        Dim groupHash As Hashtable = CType(goHash.Item(rowKey), Hashtable)
                                        If groupHash IsNot Nothing AndAlso groupHash.ContainsKey("PUBAddOrder") Then
                                            Dim AddOrderCodeDT As DataTable = CType(groupHash.Item("PUBAddOrder"), DataTable)

                                            If DataSetUtil.IsContainsData(AddOrderCodeDT) Then
                                                For Each addOrderDr As DataRow In AddOrderCodeDT.Rows

                                                    If (Not IsDBNull(addOrderDr.Item("Add_Order_Code"))) AndAlso (Not IsDBNull(addOrderDr.Item("Group_Id"))) Then

                                                        '----- process into AddOrderDT
                                                        Dim newAddOrderDr As DataRow = AddOrderDT.NewRow
                                                        '..............
                                                        '"Add_Order_Code", "Add_Order_Name", "Group_Id", "Dc", "Create_User",   _
                                                        '"Create_Time", "Modified_User", "Modified_Time"
                                                        newAddOrderDr.Item("Add_Order_Code") = CType(addOrderDr.Item("Add_Order_Code"), String).Trim
                                                        newAddOrderDr.Item("Add_Order_Name") = CType(addOrderDr.Item("Add_Order_Name"), String).Trim
                                                        newAddOrderDr.Item("Group_Id") = CType(addOrderDr.Item("Group_Id"), String).Trim
                                                        newAddOrderDr.Item("Dc") = "N"
                                                        newAddOrderDr.Item("Create_User") = loginUser
                                                        newAddOrderDr.Item("Create_Time") = SystemDate
                                                        'newAddOrderDr.Item("Modified_User") = ""
                                                        'newAddOrderDr.Item("Modified_Time") = ""
                                                        '
                                                        '"System.String", "System.String", "System.String", "System.String", "System.String",   _
                                                        '"System.DateTime", "System.String", "System.DateTime"


                                                        AddOrderDT.Rows.Add(newAddOrderDr)
                                                        '------
                                                        '--
                                                        'pop "Add_Order_Code" - "Group_Id" >> nexthash
                                                        Dim addOrderDtlKey As String = ""

                                                        If groupHash.ContainsKey(addOrderDtlKey) Then
                                                            ' nexthash = ["AddOrderDetail", AddOrderDetailDT], 
                                                            '            ["AddOptionalOrder", GroupAlterHash = {OrderCode-AddOrderDetailNo, OrderAlterDataDT}]
                                                            Dim nextHash As Hashtable = CType(groupHash.Item(addOrderDtlKey), Hashtable)
                                                            If nextHash.ContainsKey("PUBAddOrderDetail") Then

                                                                Dim AddOrderDetailDT As DataTable = CType(nextHash.Item("PUBAddOrderDetail"), DataTable)

                                                                Dim GroupAlterHash As New Hashtable
                                                                If nextHash.ContainsKey("PUBAddOptionalOrder") Then
                                                                    GroupAlterHash = CType(nextHash.Item("PUBAddOptionalOrder"), Hashtable)
                                                                End If

                                                                For Each addOrderDtlDr As DataRow In AddOrderDetailDT.Rows
                                                                    '----- process into AddOrderDtlDT
                                                                    Dim newAddOrderDtlDr As DataRow = AddOrderDtlDT.NewRow
                                                                    '..............
                                                                    '"Add_Order_Code", "Add_Order_Detail_No", "Order_Code", "Is_By_Orig_Order_Code", "Dosage",   _
                                                                    '"Days", "Tqty", "Usage_Code", "Frequency_Code", "Is_Compute",   _
                                                                    '"Is_Ask_Add", "Sheet_Code", "Is_Exclude_Duplicate", "Is_Ask_Exclude_Duplicate", "Is_Del",   _
                                                                    '"Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
                                                                    newAddOrderDtlDr.Item("Add_Order_Code") = CType(addOrderDtlDr.Item("Add_Order_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Add_Order_Detail_No") = CType(addOrderDtlDr.Item("Add_Order_Detail_No"), Integer)
                                                                    newAddOrderDtlDr.Item("Order_Code") = CType(addOrderDtlDr.Item("Order_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_By_Orig_Order_Code") = CType(addOrderDtlDr.Item("Is_By_Orig_Order_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Dosage") = CType(addOrderDtlDr.Item("Dosage"), Decimal)
                                                                    newAddOrderDtlDr.Item("Days") = CType(addOrderDtlDr.Item("Days"), Decimal)
                                                                    newAddOrderDtlDr.Item("Tqty") = CType(addOrderDtlDr.Item("Tqty"), Decimal)
                                                                    newAddOrderDtlDr.Item("Usage_Code") = CType(addOrderDtlDr.Item("Usage_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Frequency_Code") = CType(addOrderDtlDr.Item("Frequency_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_Compute") = CType(addOrderDtlDr.Item("Is_Compute"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_Ask_Add") = CType(addOrderDtlDr.Item("Is_Ask_Add"), String).Trim
                                                                    newAddOrderDtlDr.Item("Sheet_Code") = CType(addOrderDtlDr.Item("Sheet_Code"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_Exclude_Duplicate") = CType(addOrderDtlDr.Item("Is_Exclude_Duplicate"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_Ask_Exclude_Duplicate") = CType(addOrderDtlDr.Item("Is_Ask_Exclude_Duplicate"), String).Trim
                                                                    newAddOrderDtlDr.Item("Is_Del") = CType(addOrderDtlDr.Item("Is_Del"), String).Trim
                                                                    newAddOrderDtlDr.Item("Dc") = "N"
                                                                    newAddOrderDtlDr.Item("Create_User") = loginUser
                                                                    newAddOrderDtlDr.Item("Create_Time") = SystemDate
                                                                    'newAddOrderDtlDr.Item("Modified_User") = ""
                                                                    'newAddOrderDtlDr.Item("Modified_Time") = ""
                                                                    '
                                                                    '"System.String", "System.Int32", "System.String", "System.String", "System.Decimal",   _
                                                                    '"System.Decimal", "System.Decimal", "System.String", "System.String", "System.String",   _
                                                                    '"System.String", "System.String", "System.String", "System.String", "System.String",   _
                                                                    '"System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _

                                                                    AddOrderDtlDT.Rows.Add(newAddOrderDtlDr)
                                                                    '------
                                                                    '--
                                                                    'pop "OrderCode-AddOrderDetailNo" >> OrderAlterDataDT from GroupAlterHash
                                                                    Dim addOrderAlterKey As String = ""
                                                                    If GroupAlterHash.ContainsKey(addOrderAlterKey) Then
                                                                        Dim AlterDT As DataTable = CType(GroupAlterHash.Item(addOrderAlterKey), DataTable)
                                                                        If DataSetUtil.IsContainsData(AlterDT) Then
                                                                            '----- process into AddOptionOrderDT
                                                                            Dim newAddOptionOrderDr As DataRow = AddOptionOrderDT.NewRow
                                                                            '..............
                                                                            '"Add_Order_Code", "Add_Order_Detail_No", "Option_Order_Code", "Tqty", "Dc"  _
                                                                            newAddOptionOrderDr.Item("Add_Order_Code") = CType(addOrderDtlDr.Item("Add_Order_Code"), String).Trim
                                                                            newAddOptionOrderDr.Item("Add_Order_Detail_No") = CType(addOrderDtlDr.Item("Add_Order_Detail_No"), Integer)
                                                                            newAddOptionOrderDr.Item("Option_Order_Code") = CType(addOrderDtlDr.Item("Option_Order_Code"), String).Trim
                                                                            newAddOptionOrderDr.Item("Tqty") = CType(addOrderDtlDr.Item("Tqty"), Decimal)
                                                                            newAddOptionOrderDr.Item("Dc") = "N"
                                                                            '
                                                                            '"System.String", "System.Int32", "System.String", "System.Decimal", "System.String"  _

                                                                            AddOptionOrderDT.Rows.Add(newAddOptionOrderDr)

                                                                            '------
                                                                            '--
                                                                        End If

                                                                    End If

                                                                Next

                                                            End If

                                                        Else
                                                            '沒dtl
                                                        End If
                                                    End If

                                                Next
                                            End If
                                        End If
                                    Else
                                        '勾選卻沒設定, 刪除(加入flag設定)
                                    End If
                                Else

                                End If
                                '----------------------------------------------------------------------------------------

                                'promote_ratio '
                                'key是row..取出data,編排成datatable放進ds中

                            Else
                                '無效的
                            End If


                        Next

                        '--------------------------------------------------
                        '小結 加成

                        If DataSetUtil.IsContainsData(EmgAddUpdate) Then
                            OrderRelatedDS.Tables.Add(EmgAddUpdate.Copy)
                        End If
                        If DataSetUtil.IsContainsData(EmgAddInsert) Then
                            OrderRelatedDS.Tables.Add(EmgAddInsert.Copy)
                        End If
                        If DataSetUtil.IsContainsData(KidAddUpdate) Then
                            OrderRelatedDS.Tables.Add(KidAddUpdate.Copy)
                        End If
                        If DataSetUtil.IsContainsData(KidAddInsert) Then
                            OrderRelatedDS.Tables.Add(KidAddInsert.Copy)
                        End If
                        If DataSetUtil.IsContainsData(DentalAddUpdate) Then
                            OrderRelatedDS.Tables.Add(DentalAddUpdate.Copy)
                        End If
                        If DataSetUtil.IsContainsData(DentalAddInsert) Then
                            OrderRelatedDS.Tables.Add(DentalAddInsert.Copy)
                        End If
                        If DataSetUtil.IsContainsData(DeptAddUpdate) Then
                            OrderRelatedDS.Tables.Add(DeptAddUpdate.Copy)
                        End If
                        If DataSetUtil.IsContainsData(DeptAddInsert) Then
                            OrderRelatedDS.Tables.Add(DeptAddInsert.Copy)
                        End If

                        '群組依令
                        If DataSetUtil.IsContainsData(AddOrderDT) Then
                            OrderRelatedDS.Tables.Add(AddOrderDT.Copy)
                        End If
                        If DataSetUtil.IsContainsData(AddOrderDtlDT) Then
                            OrderRelatedDS.Tables.Add(AddOrderDtlDT.Copy)
                        End If
                        If DataSetUtil.IsContainsData(AddOptionOrderDT) Then
                            OrderRelatedDS.Tables.Add(AddOptionOrderDT.Copy)
                        End If

                    Else
                        '...無價格資料
                    End If


                    '總結 order(insert or update), curecontrol, majorcare, orderprice, orderprice, addorderprice
                    'emgupdate,insert; kidupdate,insert; dentalupdate,insert; holidayupdate,insert

                    If OrderRelatedDS.Tables.Contains("updateorder") Then
                        Dim commitResult As Integer = pub.commitOrderRelatedData(OrderRelatedDS)

                        If commitResult = 1 Then
                            'MessageHandling.showInfoByKey("CMMCMMB005")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB301", New String() {"儲存"})
                        ElseIf commitResult = -1 Then
                            'MessageHandling.showErrorByKey("CMMCMMD005")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowErrorMsg("CMMCMMD005", New String() {}, "")
                        Else
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令已被停用，且生效日必須大於" & commitResult}, "")
                        End If

                    ElseIf OrderRelatedDS.Tables.Contains("insertorder") Then
                        Dim commitResult As Integer = pub.commitOrderRelatedData(OrderRelatedDS)

                        If commitResult = 1 Then
                            'MessageHandling.showInfoByKey("CMMCMMB002")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB002", New String() {})
                        ElseIf commitResult = -1 Then
                            'MessageHandling.showErrorByKey("CMMCMMD002")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowErrorMsg("CMMCMMD002", New String() {}, "")
                        Else
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令已被停用，且生效日必須大於" & commitResult}, "")
                        End If
                    Else
                        'MessageHandling.showErrorByKey("CMMCMMB000")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowErrorMsg("CMMCMMB000", New String() {}, "")
                    End If
                Else

                End If

            Else
                '資料不正確
                'MessageHandling.showErrorByKey("CMMCMMB202")
                '********************2010/2/9 Modify By Alan**********************
                'MessageHandling.showErrorMsg("CMMCMMB202", New String() {}, "")
            End If

        End If

    End Function

    ''' <summary>
    ''' 清除畫面資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Clear()
        uclcomb_OrderType.SelectedValue = AllowOrderTypeId(0)
        cleanFieldsColor()

        keepOrderDT = Nothing
        keepOrderPriceDT = Nothing
        keepOrderPriceHistoryDT = Nothing
        keepOrderMajorcareDT = Nothing

        cureControlDT = Nothing
        'Grid內
        emgHash.Clear()
        chdHash.Clear()
        tohHash.Clear()
        hlyHash.Clear()
        goHash.Clear()
        'hash清除
        'ucl_txtcq_ordercode.Text = ""
        '2010-04-28 delete by Alan
        PUBOrderUI_ucl_txtcq_ordercode.Text = ""
        'PUBOrderUI_ucl_dcbg_order.Text = ""
        txt_NhiCode.Text = ""
        txt_Name.Text = ""
        txt_ZhName.Text = ""
        txt_SCName.Text = ""
        txt_EnName.Text = ""
        txt_SEName.Text = ""

        txt_NhiCode.Text = ""
        txt_Name.Text = ""

        uclcomb_OrderType.SelectedIndex = 1
        uclcomb_HosItem.SelectedIndex = -1
        uclcomb_ChargeUnit.SelectedIndex = -1
        uclcomb_majorcare.SelectedIndex = -1
        memo_OrderMemo.Text = ""
        txt_Note.Text = ""
        txt_Flag.Text = ""

        cb_NhiCureTypeId.Checked = False
        cb_Dc.Checked = False

        cb_orderprice_spec.Checked = False

        uclcomb_order_treat_prop.SelectedIndex = -1
        uclcomb_fix_fee.SelectedIndex = -1

        ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))
        uclcb_classify.SelectedIndex = -1

        lb_Nhi_Name.Text = ""

        Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
        updateGridView(OrderPriceDT)

        GridSelectedIndexList.Clear()

        '2010-04-28 delete by Alan-OK
        'PUBOrderUI_ucl_dcbg_order.uclWhereCondition = ""

        ucl_dtp_enddate.SetValue(defaultEndDate)

        cb_pricehistory.Checked = False
        ucldgv_OrderPrice.Enabled = True

        'cb_incorder_mark.Checked = False
        txt_IncludeOrder.Text = ""

        '2010-04-29 Add By Alan
        'cb_OPD.Checked = False
        'cb_EMG.Checked = False
        'cb_IPD.Checked = False
        cbo_OPD.SelectedValue = "N"
        cbo_EMG.SelectedValue = "N"
        cbo_IPD.SelectedValue = "N"

        addNewGridRow()

        '2010-04-28 delete by Alan-OK
        PUBOrderUI_ucl_txtcq_ordercode.Focus()
        'PUBOrderUI_ucl_dcbg_order.Focus()
        'ucl_txtcq_ordercode.Focus()

        '2011-07-14 Add By Alan
        '判斷登入角色若為Pub_Maintain,則不允許按確定與刪除Button
        'If Not AppContext.userProfile.userMemberOf.Contains("Pub_Maintain") Then
        '    btn_Confirm.Enabled = False
        '    btn_Delete.Enabled = False
        'End If
        chk_OrderHistory.Checked = False

    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' 健保
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_NhiProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NhiCureControl.Click

        Dim NHI As PUBCureControlUI = New PUBCureControlUI("curecontrol", NhiSyscodeDT, cureControlDT)

        Dim nhiResult As Boolean = NHI.ShowAndPrepareReturnData()
        If nhiResult Then
            cureControlDT = NHI.CureControlData
            If DataSetUtil.IsContainsData(cureControlDT) Then
                cb_NhiCureTypeId.Checked = True
            End If

        End If

    End Sub

    ''' <summary>
    ''' 組合醫令
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucldgv_OrderPrice_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellClick

        Dim orderCode As String = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
        Dim MainID As String = ""

        If orderCode.Length > 0 AndAlso DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) AndAlso checkGridRowHasData(False, e.RowIndex) Then

            If GridSelectedIndexList.Count > 0 Then
                For i As Integer = 0 To (GridSelectedIndexList.Count - 1)
                    ucldgv_OrderPrice.SetRowColor(CType(GridSelectedIndexList.Item(i), Integer), System.Drawing.Color.White)
                Next

                GridSelectedIndexList.Clear()
            End If

            MainID = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(0)), String).Trim

            Select Case e.ColumnIndex
                Case 6
                    '"急件加成",
                    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                    Dim pvtReturnData As New DataTable

                    If gblInsuCode = "" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "2" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "健保" Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"健保碼尚未設定"}, "")
                        Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                        updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                        updateGridView(updateDT)
                    End If

                    If MainID <> "" Then
                        pvtReturnData = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)
                        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                           pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim <> "Y" Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令不允許急件加成"}, "")
                            Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                            updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                            updateGridView(updateDT)
                        End If
                    End If

                Case 7
                    '"兒童加成", 
                    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                    Dim pvtReturnData As New DataTable

                    If gblInsuCode = "" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "2" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "健保" Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"健保碼尚未設定"}, "")
                        Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                        updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                        updateGridView(updateDT)
                    End If

                    If MainID <> "" Then
                        pvtReturnData = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)
                        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                           pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim <> "Y" Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令不允許兒童加成"}, "")
                            Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                            updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                            updateGridView(updateDT)
                        End If
                    End If

                Case 8
                    '"牙科加成", 
                    'Dim MainID As String = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0)
                    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                    Dim pvtReturnData As New DataTable

                    If gblInsuCode = "" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "2" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "健保" Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"健保碼尚未設定"}, "")
                        Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                        updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                        updateGridView(updateDT)
                    End If

                    If MainID <> "" Then
                        pvtReturnData = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)
                        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                           pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim <> "Y" Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令不允許牙科加成"}, "")
                            Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                            updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                            updateGridView(updateDT)
                        End If
                    End If

                Case 9
                    '"科別加成", 
                    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                    Dim pvtReturnData As New DataTable

                    If gblInsuCode = "" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "2" AndAlso _
                       ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim <> "健保" Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"健保碼尚未設定"}, "")
                        Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                        updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                        updateGridView(updateDT)
                    End If

                    If MainID <> "" Then
                        pvtReturnData = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)
                        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                           pvtReturnData.Rows(0).Item("Is_Dept_Add").ToString.Trim <> "Y" Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令不允許科別加成"}, "")
                            Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                            updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
                            updateGridView(updateDT)
                        End If
                    End If

            End Select

        ElseIf MainID = "" Then
            Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
            updateDT.Rows(e.RowIndex).Item(e.ColumnIndex) = "N"
            updateGridView(updateDT)
        End If

        Select Case e.ColumnIndex

            Case 15
                gblCellColumnIndex = e.ColumnIndex
                gblCellRowIndex = e.RowIndex

                If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(0).ToString.Trim = "2" Then
                    Dim openForm As PUBInsuCodeUI
                    Dim pvtrtnData As ArrayList
                    openForm = New PUBInsuCodeUI(PUBOrderUI_ucl_txtcq_ordercode.Text.Trim, uclcomb_OrderType.SelectedValue.ToString.Trim)
                    pvtrtnData = openForm.ShowDialog()
                    '更新健保碼與單價
                    If pvtrtnData.Count > 0 Then
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = pvtrtnData.Item(0).ToString.Trim
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = pvtrtnData.Item(1).ToString.Trim

                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = pvtrtnData.Item(0).ToString.Trim
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = pvtrtnData.Item(1).ToString.Trim
                    End If
                Else
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"非健保身分"}, "")
                End If

        End Select
    End Sub


    ''' <summary>
    ''' 醫令項目費用
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucldgv_OrderPrice_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellDoubleClick

        'Dim orderCode As String = ucl_txtcq_ordercode.Text.Trim

        '2010-04-28 delete by Alan-OK
        Dim orderCode As String = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim

        If orderCode.Length > 0 AndAlso DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) AndAlso checkGridRowHasData(False, e.RowIndex) Then

            If GridSelectedIndexList.Count > 0 Then
                'Dim GridDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                'updateGridView(GridDT)

                For i As Integer = 0 To (GridSelectedIndexList.Count - 1)
                    ucldgv_OrderPrice.SetRowColor(CType(GridSelectedIndexList.Item(i), Integer), System.Drawing.Color.White)
                Next

                GridSelectedIndexList.Clear()
            End If

            'Dim OrderCode As String = txt_OrderCode.Text.Trim
            Dim MainID As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(0)), String).Trim

            Select Case e.ColumnIndex
                'Case 6
                '    '"急件加成",

                '    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                '    Dim pvtReturnData As New DataTable

                '    If MainID <> "" Then
                '        pvtReturnData = pub.queryPubNhiCodeEffectData(HisComm.Utility.DateUtil.SystemDate("yyyy/MM/dd"), ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim)
                '        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                '           pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim <> "Y" Then
                '            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"該醫令不允許急件加成"}, "")
                '        Else
                '            Dim C_O As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(11), String).Trim.Equals("Y") Then
                '                C_O = True
                '            End If

                '            Dim C_E As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(12), String).Trim.Equals("Y") Then
                '                C_E = True
                '            End If

                '            Dim C_I As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(13), String).Trim.Equals("Y") Then
                '                C_I = True
                '            End If

                '            Dim EndDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(4), String).Trim

                '            'Dim rowKey As String = Integer.Parse(e.RowIndex)

                '            Dim PromoteData As DataTable = Nothing

                '            If emgHash.ContainsKey(MainID) Then
                '                PromoteData = CType(emgHash.Item(MainID), DataTable)
                '            End If

                '            Dim emgDialog As PUBEmgAddUI = New PUBEmgAddUI(EffectDate, MainID, C_O, C_E, C_I, orderCode, EndDate, AddSyscodeDT, PromoteData, SystemDate)

                '            Dim result As Boolean = emgDialog.ShowAndPrepareReturnData()

                '            PromoteData = emgDialog.AddData

                '            Dim flag As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(6), String).Trim
                '            If DataSetUtil.IsContainsData(PromoteData) Then
                '                If emgHash.ContainsKey(MainID) Then
                '                    emgHash.Item(MainID) = PromoteData
                '                Else
                '                    emgHash.Add(MainID, PromoteData)
                '                End If

                '                If flag.Equals("N") Then
                '                    'to Y
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(6) = "Y"
                '                    updateGridView(updateDT)
                '                End If
                '            Else
                '                If emgHash.ContainsKey(MainID) Then
                '                    emgHash.Remove(MainID)
                '                Else

                '                End If

                '                If flag.Equals("Y") Then
                '                    'to N
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(6) = "N"
                '                    updateGridView(updateDT)
                '                End If

                '            End If

                '        End If
                '    End If



                'Case 7
                '    '"兒童加成", 
                '    'Dim MainID As String = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0)
                '    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                '    Dim pvtReturnData As New DataTable

                '    If MainID <> "" Then
                '        pvtReturnData = pub.queryPubNhiCodeEffectData(HisComm.Utility.DateUtil.SystemDate("yyyy/MM/dd"), ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim)
                '        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                '           pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim <> "Y" Then
                '            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"該醫令不允許兒童加成"}, "")
                '        Else
                '            Dim C_O As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(11), String).Trim.Equals("Y") Then
                '                C_O = True
                '            End If

                '            Dim C_E As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(12), String).Trim.Equals("Y") Then
                '                C_E = True
                '            End If

                '            Dim C_I As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(13), String).Trim.Equals("Y") Then
                '                C_I = True
                '            End If

                '            Dim EndDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(4), String).Trim

                '            'Dim rowKey As String = Integer.Parse(e.RowIndex)

                '            Dim PromoteData As DataTable = Nothing

                '            If chdHash.ContainsKey(MainID) Then
                '                PromoteData = CType(chdHash.Item(MainID), DataTable)
                '            End If

                '            Dim chdDialog As PUBKidAddUI = New PUBKidAddUI(EffectDate, MainID, C_O, C_E, C_I, orderCode, EndDate, AddSyscodeDT, PromoteData, SystemDate)

                '            Dim result As Boolean = chdDialog.ShowAndPrepareReturnData()

                '            PromoteData = chdDialog.AddData


                '            '加成內至少要有一資料...
                '            Dim flag As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(7), String).Trim
                '            If DataSetUtil.IsContainsData(PromoteData) Then
                '                If chdHash.ContainsKey(MainID) Then
                '                    chdHash.Item(MainID) = PromoteData
                '                Else
                '                    chdHash.Add(MainID, PromoteData)
                '                End If

                '                If flag.Equals("N") Then
                '                    'to Y
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(7) = "Y"
                '                    updateGridView(updateDT)
                '                End If
                '            Else
                '                If chdHash.ContainsKey(MainID) Then
                '                    chdHash.Remove(MainID)
                '                Else

                '                End If

                '                If flag.Equals("Y") Then
                '                    'to N
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(7) = "N"
                '                    updateGridView(updateDT)
                '                End If

                '            End If
                '        End If
                '    End If


                'Case 8
                '    '"牙科加成", 
                '    'Dim MainID As String = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0)
                '    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                '    Dim pvtReturnData As New DataTable

                '    If MainID <> "" Then
                '        pvtReturnData = pub.queryPubNhiCodeEffectData(HisComm.Utility.DateUtil.SystemDate("yyyy/MM/dd"), ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim)
                '        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                '           pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim <> "Y" Then
                '            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"該醫令不允許牙科加成"}, "")
                '        Else
                '            Dim C_O As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(11), String).Trim.Equals("Y") Then
                '                C_O = True
                '            End If

                '            Dim C_E As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(12), String).Trim.Equals("Y") Then
                '                C_E = True
                '            End If

                '            Dim C_I As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(13), String).Trim.Equals("Y") Then
                '                C_I = True
                '            End If

                '            Dim EndDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(4), String).Trim

                '            'Dim rowKey As String = Integer.Parse(e.RowIndex)

                '            Dim PromoteData As DataTable = Nothing

                '            If tohHash.ContainsKey(MainID) Then
                '                PromoteData = CType(tohHash.Item(MainID), DataTable)
                '            End If

                '            Dim tohDialog As PUBDentalAddUI = New PUBDentalAddUI(EffectDate, MainID, C_O, C_E, C_I, orderCode, EndDate, AddSyscodeDT, PromoteData, SystemDate)

                '            Dim result As Boolean = tohDialog.ShowAndPrepareReturnData()

                '            PromoteData = tohDialog.AddData

                '            Dim flag As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(8), String).Trim
                '            If DataSetUtil.IsContainsData(PromoteData) Then
                '                If tohHash.ContainsKey(MainID) Then
                '                    tohHash.Item(MainID) = PromoteData
                '                Else
                '                    tohHash.Add(MainID, PromoteData)
                '                End If

                '                If flag.Equals("N") Then
                '                    'to Y
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(8) = "Y"
                '                    updateGridView(updateDT)
                '                End If
                '            Else
                '                If tohHash.ContainsKey(MainID) Then
                '                    tohHash.Remove(MainID)
                '                Else

                '                End If

                '                If flag.Equals("Y") Then
                '                    'to N
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(8) = "N"
                '                    updateGridView(updateDT)
                '                End If

                '            End If
                '        End If
                '    End If

                'Case 9
                '    '"假日加成", 
                '    'Dim MainID As String = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0)
                '    Dim EffectDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(1), String).Trim
                '    Dim pvtReturnData As New DataTable

                '    If MainID <> "" Then
                '        pvtReturnData = pub.queryPubNhiCodeEffectData(HisComm.Utility.DateUtil.SystemDate("yyyy/MM/dd"), ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim)
                '        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 AndAlso _
                '           pvtReturnData.Rows(0).Item("Is_Holiday_Add").ToString.Trim <> "Y" Then
                '            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"該醫令不允許假日加成"}, "")
                '        Else
                '            Dim C_O As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(11), String).Trim.Equals("Y") Then
                '                C_O = True
                '            End If

                '            Dim C_E As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(12), String).Trim.Equals("Y") Then
                '                C_E = True
                '            End If

                '            Dim C_I As Boolean = False
                '            If CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(13), String).Trim.Equals("Y") Then
                '                C_I = True
                '            End If

                '            Dim EndDate As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(4), String).Trim

                '            'Dim rowKey As String = Integer.Parse(e.RowIndex)

                '            Dim PromoteData As DataTable = Nothing

                '            If hlyHash.ContainsKey(MainID) Then
                '                PromoteData = CType(hlyHash.Item(MainID), DataTable)
                '            End If

                '            Dim hlyDialog As PUBHolidayAddUI = New PUBHolidayAddUI(EffectDate, MainID, C_O, C_E, C_I, orderCode, EndDate, AddSyscodeDT, PromoteData, SystemDate)

                '            Dim result As Boolean = hlyDialog.ShowAndPrepareReturnData()

                '            PromoteData = hlyDialog.AddData

                '            Dim flag As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(9), String).Trim
                '            If DataSetUtil.IsContainsData(PromoteData) Then
                '                If hlyHash.ContainsKey(MainID) Then
                '                    hlyHash.Item(MainID) = PromoteData
                '                Else
                '                    hlyHash.Add(MainID, PromoteData)
                '                End If

                '                If flag.Equals("N") Then
                '                    'to Y
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(9) = "Y"
                '                    updateGridView(updateDT)
                '                End If
                '            Else
                '                If hlyHash.ContainsKey(MainID) Then
                '                    hlyHash.Remove(MainID)
                '                Else

                '                End If

                '                If flag.Equals("Y") Then
                '                    'to N
                '                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                '                    updateDT.Rows(e.RowIndex).Item(9) = "N"
                '                    updateGridView(updateDT)
                '                End If

                '            End If
                '        End If
                '    End If


                Case 10

                    If (Not IsDBNull(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(0)))) AndAlso CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(0)), String).Trim.Length > 0 Then

                        'Dim rowKey As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(0)), String).Trim()

                        'TODO群組醫令碼
                        Dim AddOrderCode As String = ""

                        If Not IsDBNull(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(9)) AndAlso CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(9), String).Trim.Length > 0 Then
                            AddOrderCode = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(10), String).Trim
                        End If


                        Dim result As Boolean = False
                        If goHash.ContainsKey(MainID) Then

                            Dim addOrderList As PUBAddOrderListUI = New PUBAddOrderListUI(AddOrderCode, CType(goHash.Item(MainID), Hashtable))

                            result = addOrderList.ShowAndPrepareReturnData()

                            'Dim gomDialog As PUBAddOrderListUI = New PUBAddOrderListUI(AddOrderCode, GroupSyscodeDT, SystemDate, CType(goHash.Item(MainID), Hashtable))
                            'result = gomDialog.ShowAndPrepareReturnData()
                            'goHash.Item(MainID) = gomDialog.GroupOrderHash
                            If result Then

                                If addOrderList.GroupOrderHash.ContainsKey("Add_Order_Code") Then
                                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                                    updateDT.Rows(e.RowIndex).Item(10) = CType(addOrderList.GroupOrderHash.Item("Add_Order_Code"), String)
                                    updateGridView(updateDT)
                                End If

                                goHash.Item(MainID) = addOrderList.GroupOrderHash
                            End If
                        Else
                            Dim addOrderList As PUBAddOrderListUI = New PUBAddOrderListUI(AddOrderCode, Nothing)

                            result = addOrderList.ShowAndPrepareReturnData()

                            'Dim gomDialog As PUBAddOrderListUI = New PUBAddOrderListUI(AddOrderCode, GroupSyscodeDT, SystemDate, Nothing)
                            'result = gomDialog.ShowAndPrepareReturnData()
                            'goHash.Add(MainID, gomDialog.GroupOrderHash)
                            If result Then

                                If addOrderList.GroupOrderHash.ContainsKey("Add_Order_Code") Then
                                    Dim updateDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                                    updateDT.Rows(e.RowIndex).Item(10) = CType(addOrderList.GroupOrderHash.Item("Add_Order_Code"), String)
                                    updateGridView(updateDT)
                                End If

                                goHash.Add(MainID, addOrderList.GroupOrderHash)
                            End If
                        End If

                    End If



            End Select

        Else
            '無資料不反應
            'MessageHandling.showError("醫令資料不完整")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"醫令資料不完整"}, "")
        End If

    End Sub

    ''' <summary>
    ''' 查醫令項目代碼帶出資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        query(False)
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click
        Confirm()
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        Clear()
        'cb_OPD.Checked = True
        'cb_EMG.Checked = True
        'cb_IPD.Checked = True
        cbo_OPD.SelectedValue = "Y"
        cbo_EMG.SelectedValue = "Y"
        cbo_IPD.SelectedValue = "Y"
        MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {""})
    End Sub

    ''' <summary>
    ''' 快速鍵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PUBOrderUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                query(False)
            Case Keys.F12
                Confirm()
            Case Keys.F5
                Clear()
            Case Keys.Shift And Keys.F12
                deleteOrder()
        End Select
    End Sub

#End Region

    Private Sub btn_PreRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PreRecord.Click
        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            '2010-04-28 delete by Alan-OK
            Dim OrderCode As String = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
            Dim OrderTypeId As String = uclcomb_OrderType.SelectedValue.Trim

            Dim OrderDS As DataSet

            If chk_OrderHistory.Checked Then
                If gblIsOrderExist Then
                    OrderDS = pub.queryPreOrNextRecordOrder2(OrderCode, OrderTypeId, ucldtp_EffectDate.Text, True)
                Else
                    OrderDS = pub.queryPreOrNextRecordOrder2(OrderCode, OrderTypeId, "", True)
                End If
            Else
                OrderDS = pub.queryPreOrNextRecordOrder(OrderCode, OrderTypeId, True)
            End If

            OrderRelatedDataToUI(OrderDS, False)
        End If
    End Sub

    Private Sub btn_NextRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NextRecord.Click
        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            '2010-04-28 delete by Alan-OK
            Dim OrderCode As String = PUBOrderUI_ucl_txtcq_ordercode.Text.Trim
            Dim OrderTypeId As String = uclcomb_OrderType.SelectedValue.Trim
            Dim OrderDS As DataSet

            If chk_OrderHistory.Checked Then
                If gblIsOrderExist Then
                    OrderDS = pub.queryPreOrNextRecordOrder2(OrderCode, OrderTypeId, ucldtp_EffectDate.Text, False)
                Else
                    OrderDS = pub.queryPreOrNextRecordOrder2(OrderCode, OrderTypeId, "", False)
                End If
            Else
                OrderDS = pub.queryPreOrNextRecordOrder(OrderCode, OrderTypeId, False)
            End If

            OrderRelatedDataToUI(OrderDS, False)
        End If
    End Sub

    Private Sub cb_pricehistory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_pricehistory.CheckedChanged

        If cb_pricehistory.Checked = True Then
            orderPriceToGrid(keepOrderPriceHistoryDT, True)
            'ucldgv_OrderPrice.Enabled = False
        Else
            ucldgv_OrderPrice.Enabled = True
            orderPriceToGrid(keepOrderPriceDT, False)
        End If

    End Sub

    Private Sub ucldgv_OrderPrice_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellEnter
        gblCellColumnIndex = e.ColumnIndex
        gblCellRowIndex = e.RowIndex
    End Sub

    Private Sub ucldgv_OrderPrice_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellValueChanged
        Dim pvtSelectedRow As Integer
        Dim pvtTotalRow As Integer

        Select Case e.ColumnIndex
            Case 0
                If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count > 0 Then
                    If ucldgv_OrderPrice.GetSelectedRowsIndex <> "" Then
                        pvtSelectedRow = CInt(ucldgv_OrderPrice.GetSelectedRowsIndex)
                        pvtTotalRow = ucldgv_OrderPrice.Rows.Count
                    Else
                        Exit Sub
                    End If

                    If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(0).ToString.Trim <> "" Then
                        For i = 0 To pvtTotalRow - 1
                            If i <> pvtSelectedRow AndAlso _
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(0).ToString.Trim = _
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(i).Item(0).ToString.Trim Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該主身分已存在"}, "")

                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtSelectedRow).Item(0) = ""
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(0) = ""
                                ucldgv_OrderPrice.Rows(pvtSelectedRow).Cells(0).Value = ""

                                Exit Sub
                            End If
                        Next
                        'ucldgv_OrderPrice.AddNewRow()
                        If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtTotalRow - 1).Item(0).ToString.Trim <> "" Then
                            addNewGridRow()
                        End If

                    Else
                        pvtTotalRow = ucldgv_OrderPrice.Rows.Count

                        ucldgv_OrderPrice.RemoveRowAt(gblCellRowIndex)

                        If gblCellRowIndex = pvtTotalRow - 1 Then
                            addNewGridRow()
                        End If
                    End If

                End If

            Case 14 '健保碼
                Dim pvtReturnData As New DataTable
                If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim <> "" Then
                    Dim pvtDate As String
                    If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("生效日").ToString.Trim <> "" Then
                        pvtDate = CDate(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("生效日")).ToString("yyyy/MM/dd")
                    Else
                        pvtDate = DateUtil.SystemDate("yyyy/MM/dd")
                    End If

                    pvtReturnData = pub.queryPubNhiCodeEffectData(pvtDate, ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim, PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)

                    If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 Then

                        '健保碼真的有改動才修改Grid內容
                        If gblInsuCode <> ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim Then
                            gblInsuCode = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼").ToString.Trim
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = pvtReturnData.Rows(0).Item("Insu_Code").ToString.Trim
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = pvtReturnData.Rows(0).Item("Insu_Code").ToString.Trim
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells("健保碼").Value = pvtReturnData.Rows(0).Item("Insu_Code").ToString.Trim

                            '單價  
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = pvtReturnData.Rows(0).Item("Price").ToString.Trim
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = pvtReturnData.Rows(0).Item("Price").ToString.Trim
                            'ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(2).Value = pvtReturnData.Rows(0).Item("Price").ToString.Trim

                            '健保費用項目
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = pvtReturnData.Rows(0).Item("Insu_Account_Id").ToString.Trim
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = pvtReturnData.Rows(0).Item("Insu_Account_Id").ToString.Trim
                            ucldgv_OrderPrice.ComboBoxCellSelectedValue(pvtReturnData.Rows(0).Item("Insu_Account_Id").ToString.Trim, gblCellRowIndex, 16)

                            '健保醫令類別
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = pvtReturnData.Rows(0).Item("Insu_Order_Type_Id").ToString.Trim
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = pvtReturnData.Rows(0).Item("Insu_Order_Type_Id").ToString.Trim
                            ucldgv_OrderPrice.ComboBoxCellSelectedValue(pvtReturnData.Rows(0).Item("Insu_Order_Type_Id").ToString.Trim, gblCellRowIndex, 17)

                            '更新特定治療項目,檢查折扣(健保用)
                            If pvtReturnData.Rows(0).Item("Majorcare_Code").ToString.Trim <> "" Then
                                uclcomb_majorcare.SelectedValue = pvtReturnData.Rows(0).Item("Majorcare_Code").ToString.Trim
                            End If

                            lb_Nhi_Name.Text = pvtReturnData.Rows(0).Item("Insu_Code").ToString.Trim & " - " & pvtReturnData.Rows(0).Item("Insu_Name").ToString.Trim

                            '若異動後的健保碼所對應的註記為N, 則需更新至Grid
                            '2011-08-25 修改為不帶預設值，皆設為N(含自費項)
                            Dim pvtOwnRowIndex As Integer
                            For m = 0 To ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count - 1
                                If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "1" OrElse _
                                   ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "自費" Then

                                    pvtOwnRowIndex = m

                                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                                    ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(6).Value = "N"

                                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                                    ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(7).Value = "N"

                                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                                    ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(8).Value = "N"

                                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                                    ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(9).Value = "N"

                                    Exit For
                                End If
                            Next

                            'If pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim = "N" Then
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(6).Value = "N"
                            'End If

                            'If pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim = "N" Then
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(7).Value = "N"
                            'End If

                            'If pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim = "N" Then
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(8).Value = "N"
                            'End If

                            'If pvtReturnData.Rows(0).Item("Is_Holiday_Add").ToString.Trim = "N" Then
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(9).Value = "N"
                            'End If

                        End If


                    Else
                        '健保碼
                        gblInsuCode = ""
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = ""
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = ""


                        '單價  
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = "0"
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = "0"
                        'ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(2).Value = pvtReturnData.Rows(0).Item("Price").ToString.Trim

                        '健保費用項目
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = ""
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = ""
                        ucldgv_OrderPrice.ComboBoxCellSelectedValue("", gblCellRowIndex, 16)

                        '健保醫令類別
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = ""
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = ""
                        ucldgv_OrderPrice.ComboBoxCellSelectedValue("", gblCellRowIndex, 17)

                        lb_Nhi_Name.Text = ""

                        Dim pvtOwnRowIndex As Integer
                        For m = 0 To ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count - 1
                            If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "1" OrElse _
                               ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "自費" Then

                                pvtOwnRowIndex = m

                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                                ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(6).Value = "N"

                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                                ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(7).Value = "N"

                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                                ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(8).Value = "N"

                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                                ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(9).Value = "N"

                                Exit For
                            End If
                        Next

                        'If pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim = "N" Then
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                        ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(6).Value = "N"
                        'End If                        

                        'If pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim = "N" Then
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                        ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(7).Value = "N"
                        'End If

                        'If pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim = "N" Then
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                        ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(8).Value = "N"
                        'End If

                        'If pvtReturnData.Rows(0).Item("Is_Dept_Add").ToString.Trim = "N" Then
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                        ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                        ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(9).Value = "N"
                        'End If

                    End If
                Else
                    '健保碼
                    If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(0).ToString.Trim = "2" OrElse _
                        ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(0).ToString.Trim = "健保" Then
                        gblInsuCode = ""
                    End If
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = ""
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保碼") = ""


                    '單價  
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = "0"
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("單價") = "0"
                    'ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(2).Value = pvtReturnData.Rows(0).Item("Price").ToString.Trim

                    '健保費用項目
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = ""
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保費用項目") = ""
                    ucldgv_OrderPrice.ComboBoxCellSelectedValue("", gblCellRowIndex, 16)

                    '健保醫令類別
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = ""
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item("健保醫令類別") = ""
                    ucldgv_OrderPrice.ComboBoxCellSelectedValue("", gblCellRowIndex, 17)

                    lb_Nhi_Name.Text = ""

                    Dim pvtOwnRowIndex As Integer
                    For m = 0 To ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count - 1
                        If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "1" OrElse _
                           ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(m).Item(0).ToString.Trim = "自費" Then

                            pvtOwnRowIndex = m

                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(6) = "N"
                            ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(6).Value = "N"

                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(7) = "N"
                            ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(7).Value = "N"

                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(8) = "N"
                            ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(8).Value = "N"

                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtOwnRowIndex).Item(9) = "N"
                            ucldgv_OrderPrice.Rows(pvtOwnRowIndex).Cells(9).Value = "N"

                            Exit For
                        End If
                    Next

                    'If pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim = "N" Then
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(6) = "N"
                    ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(6).Value = "N"
                    'End If                        

                    'If pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim = "N" Then
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(7) = "N"
                    ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(7).Value = "N"
                    'End If

                    'If pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim = "N" Then
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(8) = "N"
                    ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(8).Value = "N"
                    'End If

                    'If pvtReturnData.Rows(0).Item("Is_Dept_Add").ToString.Trim = "N" Then
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(9) = "N"
                    ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(9).Value = "N"

                End If

        End Select

    End Sub

    Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Select Case uclName
            Case Me.Name & "PUBOrderUI_ucl_txtcq_ordercode"
                PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 = uclCodeValue1.Trim
                PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue2 = uclCodeValue2.Trim
                PUBOrderUI_ucl_txtcq_ordercode.uclCodeName = uclCodeName.Trim
                PUBOrderUI_ucl_txtcq_ordercode.Text = uclCodeValue1.Trim
                query(True)
        End Select

    End Sub

    Private Sub doUcrOpenWindowValue2(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowValue2

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Select Case uclName
                Case Me.Name & "PUBOrderUI_ucl_txtcq_ordercode", "tbp_Condition" & "PUBOrderUI_ucl_txtcq_ordercode"
                    PUBOrderUI_ucl_txtcq_ordercode.Text = ds.Tables(0).Rows(0).Item("醫令項目代碼").ToString.Trim
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 = ds.Tables(0).Rows(0).Item("醫令項目代碼").ToString.Trim
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeName = ds.Tables(0).Rows(0).Item("英文名稱").ToString.Trim
                    ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))

                    If PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1.Trim <> "" Then
                        query(True)
                    End If

            End Select
        Else
            Select Case uclName
                Case Me.Name & "PUBOrderUI_ucl_txtcq_ordercode", "tbp_Condition" & "PUBOrderUI_ucl_txtcq_ordercode"
                    'PUBOrderUI_ucl_txtcq_ordercode.Text = ""
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
                    PUBOrderUI_ucl_txtcq_ordercode.uclCodeName = ""
                    ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))
            End Select
        End If

    End Sub

    Private Sub cb_Dc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Dc.CheckedChanged
        If cb_Dc.Checked Then
            ucl_dtp_enddate.SetValue(Date.Parse(SystemDate.ToString("yyyy/MM/dd")))
        Else
            ucl_dtp_enddate.SetValue(defaultEndDate)
        End If
    End Sub

    Private Sub ucldtp_EffectDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucldtp_EffectDate.Leave
        If gblEffectDate <> ucldtp_EffectDate.GetUsDateStr Then
            ucl_dtp_enddate.SetValue(defaultEndDate)
        End If
    End Sub

    Private Function chkNhiCode(ByVal inOrderCode As String) As Boolean
        Dim pvtReturnData As New DataTable

        pvtReturnData = pub.queryPubInsuCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), AllowOrderTypeId(0), inOrderCode)

        If pvtReturnData IsNot Nothing AndAlso pvtReturnData.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btn_OrderCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OrderCheck.Click
        Dim openRuleCheck As New PUBRuleQueryUI
        openRuleCheck.ShowDialog()
    End Sub

    Private Sub btn_Indication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Indication.Click
        Dim openIndication As New PUBTreeRuleQueryUI
        openIndication.ShowDialog()
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        deleteOrder()
    End Sub

    Private Sub deleteOrder()
        If (PUBOrderUI_ucl_txtcq_ordercode.Text.Trim <> "" AndAlso MessageHandling.ShowQuestionMsg("CMMCMMB303", New String() {"刪除"}) = Windows.Forms.DialogResult.Yes) Then
            Dim pvtResult As Integer

            Try
                'add by 唐子晴 2014.02.11 -----------------------------------------------------------------------------------------------------------------------------------
                Dim pvtLogResult = pub.deletePUBOrderLog(PUBOrderUI_ucl_txtcq_ordercode.Text.Trim, txt_ZhName.Text.Trim, AllowOrderTypeId(0), AllowOrderMode(0), loginUser)
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                pvtResult = pub.deletePUBOrderByOrderCode(PUBOrderUI_ucl_txtcq_ordercode.Text.Trim)

                If pvtResult = 0 Then
                    MessageHandling.ShowErrorMsg("CMMCMMB302", New String() {"刪除"}, "")

                Else
                    MessageHandling.ShowInfoMsg("CMMCMMB301", New String() {"刪除"})
                    Clear()
                End If

            Catch ex As Exception
                MessageHandling.ShowErrorMsg("CMMCMMB302", New String() {"刪除"}, ex.ToString)
            End Try

        End If
    End Sub

    Private Sub chk_OrderHistory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_OrderHistory.CheckedChanged
        'If chk_OrderHistory.Checked Then
        '    btn_Confirm.Enabled = False
        '    btn_Delete.Enabled = False
        '    btn_PreRecord_Click(sender, e)
        'End If
    End Sub

    Private Sub btn_AddQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1 <> "" Then
            Dim pubAddQuery As New PUBAddQueryUI(PUBOrderUI_ucl_txtcq_ordercode.uclCodeValue1, PUBOrderUI_ucl_txtcq_ordercode.uclCodeName)
            pubAddQuery.ShowDialog()
        End If
    End Sub

#Region "     停用日期與 Gridveiw 更新"

    ''' <summary>
    ''' 若ucl_dtp_enddate有變更日期的話
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucl_dtp_enddate_Leave(sender As Object, e As EventArgs) Handles ucl_dtp_enddate.Leave

        If ucl_dtp_enddate.GetUsDateStr <> "" Then

            TransDateSame()

        End If

    End Sub
    ''' <summary>
    ''' 若cb_Dc(停用按鈕)有被打勾的話
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cb_Dc_Click(sender As Object, e As EventArgs) Handles cb_Dc.Click

        If cb_Dc.Checked = True Then

            TransDateSame()

        End If

    End Sub

    Private Sub TransDateSame()

        Dim GridDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy
        For i = 0 To GridDS.Tables(0).Rows.Count - 1
            GridDS.Tables(0).Rows(i).Item(OrderPriceColumn(4)) = ucl_dtp_enddate.GetTwDateStr
        Next
        ucldgv_OrderPrice.ClearDS()
        ucldgv_OrderPrice.Visible = False
        ucldgv_OrderPrice.SetDS(GridDS)
        ucldgv_OrderPrice.Visible = True

    End Sub

#End Region

End Class
