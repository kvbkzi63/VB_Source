Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.EXP

Public Class PUBOrderMaterialUI

    '============================
    '程式說明：醫療支付公用主作檔-衛材
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================
    '*************************************************************************************************
    ' 修改日期    修改者     項目
    '-------------------------------------------------------------------------------------------------
    '2013.12.12   唐子晴    1. 清除單價調整紀錄殘值
    '2013.12.18   唐子晴    1. 當該筆醫令代碼為停用時，帶出歷史價格
    '                        2. 新建檔案時 , 門急住顯示'可使用'
    '2013.12.20   唐子晴    1. 修改醫令停用時 , 因價格記錄未變更為停用 , 而造成歷史價格未能正確帶出
    '2014.01.02   唐子晴    1. 修改健保加成原則
    '2014.01.13   唐子晴    1. 料號第一字為"Q" , 取消健保加成公式
    '                        2. 當給付註記為"4-部份差額-健保給付"時 , 設定健保"差額"欄位不可為空白 
    '2014.01.21   唐子晴    1. 修改健保加成原則
    '                          < 100 * 1.8
    '                          101 ~ 1000 * 1.6
    '                          1001 ~ 5000 * 1.5
    '                          > 5001 * 1.2
    '2014.01.27   唐子晴    1. 放寬醫令價格單價欄位字數 , 整數部份由6碼改為8碼
    '                        2. 當停用勾選 ,設定門急住不可使用
    '2014.02.06   唐子晴    1. 加入使用者權限 , 設定僅有管理者才有新增、修改、刪除功能
    '                          (管理者員工號:001528、010024、032135)
    '                        2. 執行刪除時 , 新增Log紀錄
    '2014.02.11   唐子晴    1. 修正使用者權限
    '2014.02.18   唐子晴    1. 修正停用後, 該筆料號可新增之功能
    '                        2. 新增異動日期欄位於醫令項目價格中
    '2014.03.12   唐子晴    修正停用後 , 該筆料號可編輯之功能
    '2014.03.28   唐子晴    1. 料號為I5 I6 I8 I9 開頭，院內費用項目預設為：35-其他費用
    '                        2. 修改新增料號邏輯
    '2014.05.06   唐子晴    1. 停用日期空白時, 修正為空白, 勿顯示今日日期
    '*************************************************************************************************

#Region "########## 宣告物件 ##########"

    Dim GblPubOrderPrice As New DataSet

    Dim cbo_ChargeFlagCell As New ComboBoxCell() '計價註記 Combobox
    Dim loginUser As String = AppContext.userProfile.userId

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance
    '                                      0         1             2          3        4        5          6          7            8            9            10          11        12          13        14            15          16              17           18           19      20        21        
    'modify by 唐子晴 2014.02.18 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ''Dim OrderPriceColumn() As String = {"主身分", "生效日", "健保核定單價", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", "科別加成", "群組醫令碼", "門診可用", "急診可用", "住院可用", "健保碼", "健保編碼", "組合健保碼", "健保費用項目", "健保醫令類別", "Dc", "Is_New"}
    ''Dim OrderPriceColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, _
    ''                                        DataSetUtil.TypeDate, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
    ''                                        DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
    ''                                        DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
    ''                                        DataSetUtil.TypeString}
    Dim OrderPriceColumn() As String = {"主身分", "生效日", "健保核定單價", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", "科別加成", "群組醫令碼", "門診可用", "急診可用", "住院可用", "健保碼", "健保編碼", "組合健保碼", "健保費用項目", "健保醫令類別", "Dc", "Is_New", "異動日期", "計價註記", "門診連帶碼", "急診連帶碼", "住院連帶碼", "比率"}
    Dim OrderPriceColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, _
                                            DataSetUtil.TypeDate, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                            DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                            DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                            DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDecimal}
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

    Dim AllowOrderTypeId() As String = {"G"}
    'add by 唐子晴 2014.02.06 --------------------
    Dim AllowOrderMode() As String = {"D", "E"} 'D-刪除 , E-修改
    Dim authority As Boolean = False
    '---------------------------------------------
    Dim checkMainIdDT As DataTable = Nothing

    Dim defaultEndDate As Date = Date.Parse("2910/12/31")

    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager

    Dim gblErrorMsg As String
    Dim gblCellColumnIndex, gblCellRowIndex As Integer
    Dim gblEffectDate As String
    Dim gblEndDate As String
    Dim gblIsInventory As String
    Dim gblIsIcdCheck As String
    Dim gblIsOrderExist As Boolean = False
    Dim gblInsuCode As String
    Dim gblOrderMaterialDT As New DataTable

    Enum PUB_Order_Price
        Main_Identity_Id = 0                  '主身分
        Effect_Date = 1                       '生效日
        Insu_Apply_Price = 2                 '健保核定單價
        Price = 3                             '單價
        Add_Price = 4                         '差額
        End_Date = 5                          '停止日
        Is_Emg_Add = 6                        '急件加成
        Is_Kid_Add = 7                        '兒童加成
        Is_Dental_Add = 8                     '牙科加成
        Is_Dept_Add = 9                       '科別加成
        Add_Order_Code = 10                   '群組醫令碼
        Insu_Cover_Opd = 11                   '門診可用
        Insu_Cover_Emg = 12                   '急診可用
        Insu_Cover_Ipd = 13                   '住院可用
        Insu_Code = 14                        '健保碼
        Insu_Group_Code = 15                  '健保編碼
        Insu_Combine_Code = 16                '組合健保碼
        Insu_Account_Id = 17                  '健保費用項目
        Insu_Order_Type_Id = 18               '健保醫令類別
        DC = 19                               'Dc
        Is_New = 20                           'Is_New
        'add by 唐子晴 2014.02.18 ----------------------
        Modified_Time = 21                    '異動日期
        '-----------------------------------------------
        Charge_Flag = 22                     '計價註記
        Opd_Add_Order_Code = 23              '門診連帶碼
        Emg_Add_Order_Code = 24              '急診連帶碼
        Ipd_Add_Order_Code = 25              '住院連帶碼
        Order_Ratio = 26                      '比率


    End Enum



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
        Me.KeyPreview = True
        'PUBOrderMaterailUI_ucl_dcbg_order.uclDc = "Dc"
        '-------------------------
        PUBMaterialUI_ucl_txtcq_ordercode.Enabled = True
        cb_OrderCheck.Enabled = False
        cb_OrderCheck.Visible = False
        btn_OrderCheck.Enabled = True
        cb_Indication.Enabled = False
        cb_Indication.Visible = False
        btn_Indication.Enabled = True
        cb_NhiSheet.Enabled = False
        btn_Nhi.Enabled = False

        btn_PreRecord.Enabled = True
        btn_NextRecord.Enabled = True
        btn_Delete.Enabled = True
        btn_Query.Enabled = False

        PUBMaterialUI_ucl_txtcq_ordercode.Visible = True
        btn_PreRecord.Visible = True
        btn_NextRecord.Visible = True
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
        PUBMaterialUI_ucl_txtcq_ordercode.uclQueryValue = "G"
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

        Dim drG As DataRow = orderTypeDT.NewRow
        drG.Item(ComboBoxColumn(0)) = AllowOrderTypeId(0)
        drG.Item(ComboBoxColumn(1)) = "衛材"
        orderTypeDT.Rows.Add(drG)

        uclcomb_OrderType.DataSource = orderTypeDT
        uclcomb_OrderType.uclValueIndex = "0"
        uclcomb_OrderType.uclDisplayIndex = "0,1"
        uclcomb_OrderType.SelectedValue = AllowOrderTypeId(0)

        'add by 唐子晴 2013.11.25===========================================
        Dim pvtPriceRuleDS As New DataSet
        pvtPriceRuleDS.Tables.Add("priceRule")
        pvtPriceRuleDS.Tables(0).Columns.Add("Rule_Id")
        pvtPriceRuleDS.Tables(0).Columns.Add("Rule_Name")

        pvtPriceRuleDS.Tables(0).Rows.Add()
        pvtPriceRuleDS.Tables(0).Rows(0).Item("Rule_Id") = "A"
        pvtPriceRuleDS.Tables(0).Rows(0).Item("Rule_Name") = ".科部上簽自訂"

        pvtPriceRuleDS.Tables(0).Rows.Add()
        pvtPriceRuleDS.Tables(0).Rows(1).Item("Rule_Id") = "B"
        pvtPriceRuleDS.Tables(0).Rows(1).Item("Rule_Name") = ".科部建議價格"

        pvtPriceRuleDS.Tables(0).Rows.Add()
        pvtPriceRuleDS.Tables(0).Rows(2).Item("Rule_Id") = "C"
        pvtPriceRuleDS.Tables(0).Rows(2).Item("Rule_Name") = ".衛生局加成"

        ucl_Flag.DataSource = pvtPriceRuleDS.Tables(0).Copy
        ucl_Flag.uclValueIndex = "0"
        ucl_Flag.uclDisplayIndex = "0,1"
        '====================================================================


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

        pvtOPDSelectDS.Tables(0).Rows.Add()
        pvtOPDSelectDS.Tables(0).Rows(3).Item("Select_Id") = "H"
        pvtOPDSelectDS.Tables(0).Rows(3).Item("Select_Name") = "健檢可用"

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

        pvtEMGSelectDS.Tables(0).Rows.Add()
        pvtEMGSelectDS.Tables(0).Rows(3).Item("Select_Id") = "H"
        pvtEMGSelectDS.Tables(0).Rows(3).Item("Select_Name") = "健檢可用"

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

        pvtIPDSelectDS.Tables(0).Rows.Add()
        pvtIPDSelectDS.Tables(0).Rows(3).Item("Select_Id") = "H"
        pvtIPDSelectDS.Tables(0).Rows(3).Item("Select_Name") = "健檢可用"

        cbo_IPD.DataSource = pvtIPDSelectDS.Tables(0).Copy
        cbo_IPD.uclValueIndex = "0"
        cbo_IPD.uclDisplayIndex = "0,1"

        'add by 唐子晴 2013.11.25=======
        txt_ChargeUnit.Text = "EA"
        txt_ClaimUnit.Text = "EA"
        '===============================

     
        '讀取DB
        If DataSetUtil.IsContainsData(initDS) Then

            '-------------------------------------------------------------------------
            '代碼檔
            '-------------------------------------------------------------------------
            If initDS.Tables.Contains("pubsyscode") Then

                Dim selectOutDRs() As DataRow

                '院內費用項目
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 41 ")
                If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
                    uclcomb_HosItem.DataSource = createComboBoxTable("feeitem", selectOutDRs)
                    uclcomb_HosItem.uclValueIndex = "0"
                    uclcomb_HosItem.uclDisplayIndex = "0,1"
                    'add by 唐子晴 2013.11.25================
                    uclcomb_HosItem.SelectedValue = "21"
                    '========================================
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

                '39  群組註記
                '----------------------------------------------------------------------
                selectOutDRs = initDS.Tables("pubsyscode").Select(" Type_Id = 39 ")
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

            'If initDS.Tables.Contains("unit") Then
            '    uclcomb_ChargeUnit.DataSource = createComboBoxTable("unit", initDS.Tables("unit"))
            '    uclcomb_ChargeUnit.uclValueIndex = "0"
            '    uclcomb_ChargeUnit.uclDisplayIndex = "0,1"
            'End If

        End If


        '-------------------------------------------------------------------------
        '單位
        '-------------------------------------------------------------------------
        'If initDS.Tables.Contains("unit") Then
        '    ucl_claimunit.DataSource = createComboBoxTable("unit", initDS.Tables("unit"))
        '    ucl_claimunit.uclValueIndex = "0"
        '    ucl_claimunit.uclDisplayIndex = "0,1"
        'End If

        '日期部份
        If initDS.Tables.Contains("systemdate") Then
            If DataSetUtil.IsContainsData(initDS.Tables("systemdate")) Then
                SystemDate = CType(initDS.Tables("systemdate").Rows(0).Item("System_Date"), Date)
            End If
        End If

        ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))
        ucl_dtp_enddate.SetValue(defaultEndDate)
        '-------------------------------------------------------------------------
        'DGV部分
        '-------------------------------------------------------------------------
        '建立gridview
        'ucldgv_OrderItem
        'init Grid資料
        '----------------------------------------------
        Dim OrderPriceDS As DataSet = New DataSet
        Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
        OrderPriceDS.Tables.Add(OrderPriceDT)
        '----------------------------------------------

        'Hash版
        Dim _hashTable As Hashtable = New Hashtable

        Dim txt_cell As New TextBoxCell()
        Dim btn_cell As New ButtonCell()
        Dim txt_price_cell As New TextBoxCell()
        Dim chk_cell As New CheckBoxCell()
        Dim cmb_cell As New ComboBoxCell

        'add by 唐子晴 2014.02.18 -------------------
        Dim txt_cell_readOnly As New UCL.UCLTextBoxUC()
        txt_cell_readOnly.uclReadOnly = True
        '--------------------------------------------
        '宣告Datagridveiw中 EndDate的欄位屬性
        Dim EndDate_date_cell As New DtpCell()
        EndDate_date_cell.DisplayLocale = 1


        '因為Money_Type有問題，使用數字鍵盤(NumberPAD)時，按小數點會出現連續二點，故改為Interger_Type
        'txt_price_cell.uclTextType = TextBoxCell.uclTextTypeData.Money_Type
        txt_price_cell.uclTextType = TextBoxCell.uclTextTypeData.Integer_Type
        'modify by 唐子晴 2014.01.27-------------
        txt_price_cell.uclIntCount = 8
        'txt_price_cell.uclIntCount = 6 '整數位數
        '----------------------------------------
        txt_price_cell.uclDotCount = 2 '小數位數
        txt_price_cell.uclMinus = False '是否會有負值

        '宣告Datagridveiw中 Effect_Date的欄位屬性
        Dim date_cell As New DtpCell()
        date_cell.DisplayLocale = UCLDateTimePickerCellUC.Locale.TW


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

            _hashTable.Add(CInt(PUB_Order_Price.Main_Identity_Id), cbo_mainidentitycell)
        End If

        _hashTable.Add(CInt(PUB_Order_Price.Effect_Date), date_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Price), txt_price_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Add_Price), txt_price_cell)
        _hashTable.Add(CInt(PUB_Order_Price.End_Date), EndDate_date_cell)
        _hashTable.Add(6, chk_cell)
        _hashTable.Add(7, chk_cell)
        _hashTable.Add(8, chk_cell)
        _hashTable.Add(9, chk_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Insu_Code), txt_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Insu_Group_Code), txt_cell)
        ' _hashTable.Add(CInt(PUB_Order_Price.Insu_Combine_Code), btn_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Insu_Apply_Price), txt_price_cell)
        'add by 唐子晴 2014.02.18 --------------------------------------------
        _hashTable.Add(CInt(PUB_Order_Price.Modified_Time), txt_cell_readOnly)
        '---------------------------------------------------------------------
        _hashTable.Add(CInt(PUB_Order_Price.Opd_Add_Order_Code), txt_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Emg_Add_Order_Code), txt_cell)
        _hashTable.Add(CInt(PUB_Order_Price.Ipd_Add_Order_Code), txt_cell)
        _hashTable.Add(26, txt_cell)

        Dim chk_typecell As New CheckBoxCell()


        '計價註記 Combobox
        Dim dsChargeFlag As New DataSet
        Dim dt As New DataTable
        dt.Columns.Add("item")
        dt.Columns.Add("item1")
        dt.Rows.Add("Y", "S")
        dt.Rows.Add("O", "N")
        dt.Rows.Add("X", "X")
        dsChargeFlag.Tables.Add(dt.Copy)
        cbo_ChargeFlagCell.Ds = dsChargeFlag.Copy
        cbo_ChargeFlagCell.DisplayIndex = "0"
        cbo_ChargeFlagCell.ValueIndex = "0"
        _hashTable.Add(CInt(PUB_Order_Price.Charge_Flag), cbo_ChargeFlagCell)

        If DataSetUtil.IsContainsData(insuFeeItemDT) Then
            Dim cbo_insufeeitemcell As New ComboBoxCell()
            'DS
            InsuFeeItemDS.Tables.Add(insuFeeItemDT)
            cbo_insufeeitemcell.Ds = InsuFeeItemDS
            cbo_insufeeitemcell.DisplayIndex = "1"
            cbo_insufeeitemcell.ValueIndex = "0"

            _hashTable.Add(CInt(PUB_Order_Price.Insu_Account_Id), cbo_insufeeitemcell)
        End If

        If DataSetUtil.IsContainsData(insuOrderTypeDT) Then
            Dim cbo_insuordertypecell As New ComboBoxCell()
            'DS
            InsuOrderTypeDS.Tables.Add(insuOrderTypeDT)
            cbo_insuordertypecell.Ds = InsuOrderTypeDS
            cbo_insuordertypecell.DisplayIndex = "1"
            cbo_insuordertypecell.ValueIndex = "0"

            _hashTable.Add(CInt(PUB_Order_Price.Insu_Order_Type_Id), cbo_insuordertypecell)
        End If

        ucldgv_OrderPrice.Initial(_hashTable)

        ucldgv_OrderPrice.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(OrderPriceColumn)
        'modify by 唐子晴 2014.02.18 --------------------------------------------------------------------------------------------
        ''ucldgv_OrderPrice.uclColumnWidth = "75, 90, 120, 75, 75, 90, 60, 60, 60, 60, 0, 0, 0, 0, 180, 120,30, 120, 120, 0, 0"
        ucldgv_OrderPrice.uclColumnWidth = "75, 90, 120, 75, 75, 90, 60, 60, 60, 60, 0, 0, 0, 0, 180, 120,30, 120, 120, 0, 0, 150,80,80,80,80,50"

        '------------------------------------------------------------------------------------------------------------------------

        ucldgv_OrderPrice.uclColumnAlignment = "0"
        ucldgv_OrderPrice.uclNonVisibleColIndex = "" & PUB_Order_Price.Add_Order_Code
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Cover_Opd
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Cover_Emg
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Cover_Ipd
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Combine_Code
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.DC
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Is_New
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Combine_Code
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Apply_Price
        ucldgv_OrderPrice.uclNonVisibleColIndex &= "," & PUB_Order_Price.Insu_Group_Code

        addNewGridRow()

        'PUBOrderMaterailUI_ucl_dcbg_order.Focus()
        PUBMaterialUI_ucl_txtcq_ordercode.Focus()

        '將Effect_Date、End_Date設為ReadOnly
        For i As Integer = 0 To ucldgv_OrderPrice.Rows.Count - 1
            Me.ucldgv_OrderPrice.SetCellReadOnly(1, i, True)
            Me.ucldgv_OrderPrice.SetCellReadOnly(5, i, True)
        Next

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
    ''' <remarks></remarks>
    Dim insuCode As String
    Dim insuGroupCode As String
    Private Sub OrderRelatedDataToUI(ByVal OrderDS As DataSet, ByVal leaveFlag As Boolean, Optional ByVal queryOrderCode As String = Nothing)

        Dim str_TempOrderCode As String = PUBMaterialUI_ucl_txtcq_ordercode.Text.ToString.Trim

        '醫令資料 to UI
        cb_pricehistory.Checked = False
        ucldgv_OrderPrice.Enabled = True
        gblIsInventory = "N"
        gblIsIcdCheck = "N"
        insuCode = ""
        insuGroupCode = ""
        gblIsOrderExist = False
        Dim orderCode As String = ""

        '若有傳入queryOrderCode則填入orderCode(只有query()在用),否則從OrderDS取(上一筆與下一筆用)
        If queryOrderCode IsNot Nothing Then
            orderCode = queryOrderCode
        Else
            If DataSetUtil.IsContainsData(OrderDS) Then
                orderCode = OrderDS.Tables(0).Rows(0).Item("Order_Code").ToString.Trim
            End If
        End If

        '加入PUB_Mis_Purchase_Data的檢查
        Dim dbMisPurData As DataTable = Nothing 'pub.queryPubMisPurchaseData(orderCode)

        If DataSetUtil.IsContainsData(OrderDS) Or DataSetUtil.IsContainsData(dbMisPurData) Then

            If DataSetUtil.IsContainsData(OrderDS) = False AndAlso DataSetUtil.IsContainsData(dbMisPurData) = True Then '若沒有PUB_Order沒有資料,建立一個
                'todo 建立PUB_Order
                Dim orderDT As DataTable = DataSetUtil.GenDataTable(PubOrderDataTableFactory.tableName, Nothing, PubOrderDataTableFactory.columnsName)
                orderDT.Rows.Add(orderDT.NewRow())
                OrderDS.Tables.Add(orderDT)

                '建立PUB_Order_Price,新增table就可以了,不用row data
                OrderDS.Tables.Add(DataSetUtil.createDataTable(PubOrderPriceDataTableFactory.tableName, Nothing, OrderPriceColumn, OrderPriceColumnType))
            End If
            '將PUB_Mis_Purchase_Data的資料填入
            Dim dbOrderDT2 As DataTable = OrderDS.Tables(PubOrderDataTableFactory.tableName)
            If DataSetUtil.IsContainsData(dbMisPurData) Then
                If Not String.IsNullOrEmpty(dbMisPurData.Rows(0).Item("Purchase_Code")) Then
                    dbOrderDT2.Rows(0).Item("Order_Code") = dbMisPurData.Rows(0).Item("Purchase_Code")
                End If
                If Not String.IsNullOrEmpty(dbMisPurData.Rows(0).Item("Order_Type_Id")) Then
                    dbOrderDT2.Rows(0).Item("Order_Type_Id") = dbMisPurData.Rows(0).Item("Order_Type_Id")
                End If
                If dbMisPurData.Rows(0).Item("Order_En_Name").ToString.Trim <> "" Then
                    dbOrderDT2.Rows(0).Item("Order_En_Name") = dbMisPurData.Rows(0).Item("Order_En_Name")
                End If
                If dbMisPurData.Rows(0).Item("Order_Name").ToString.Trim <> "" Then
                    dbOrderDT2.Rows(0).Item("Order_Name") = dbMisPurData.Rows(0).Item("Order_Name")
                End If
                If dbMisPurData.Rows(0).Item("Memo").ToString.Trim <> "" Then
                    dbOrderDT2.Rows(0).Item("Order_Note") = dbMisPurData.Rows(0).Item("Memo")
                End If
                If dbMisPurData.Rows(0).Item("Brand").ToString.Trim <> "" Then
                    dbOrderDT2.Rows(0).Item("Brand") = dbMisPurData.Rows(0).Item("Brand")
                End If
                'add by 唐子晴 2013.12.11-----------------------------------------------------
                ucl_PriceAdjustment.Text = dbMisPurData.Rows(0).Item("Price_Adjustment").ToString.Trim
                '-----------------------------------------------------------------------------
                '原先的PUB_Order沒有的欄位
                txt_format.Text = dbMisPurData.Rows(0).Item("Spec").ToString.Trim
                txt_purchaseprice.Text = dbMisPurData.Rows(0).Item("Purchase_Price").ToString.Trim
                txt_purchaseunit.Text = dbMisPurData.Rows(0).Item("Purchase_Price_Unit").ToString.Trim
                txt_storagetype.Text = dbMisPurData.Rows(0).Item("Stock_Unit").ToString.Trim
                '健保的Order_Price資料
                insuCode = dbMisPurData.Rows(0).Item("Insu_Code").ToString.Trim
                insuGroupCode = dbMisPurData.Rows(0).Item("Insu_Group_Code").ToString.Trim
            End If


            If OrderDS.Tables.Contains(PubOrderDataTableFactory.tableName) Then
                Dim dbOrderDT As DataTable = OrderDS.Tables(PubOrderDataTableFactory.tableName)

                Dim dbOrderTypeId As String = CType(dbOrderDT.Rows(0).Item("Order_Type_Id"), String).Trim

                If checkCorrectType(dbOrderTypeId) Then

                    keepOrderDT = OrderDS.Tables(PubOrderDataTableFactory.tableName).Copy
                    orderToConditionUI(dbOrderDT)

                    '有master, detail才需顯示

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
                    
                        If keepOrderDT.Rows(0).Item("Dc").ToString.Trim = "N" Then
                            keepOrderPriceDT = OrderDS.Tables(PubOrderPriceDataTableFactory.tableName).Copy
                            orderPriceToGrid(dbOrderPriceDT, False)

                            If GblPubOrderPrice IsNot Nothing AndAlso GblPubOrderPrice.Tables.Count > 0 Then
                                GblPubOrderPrice.Clear()
                                Dim dsTemp As New DataSet
                                dsTemp.Tables.Add(keepOrderPriceDT.Copy)
                                GblPubOrderPrice = dsTemp.Copy
                            Else
                                GblPubOrderPrice.Clear()
                                GblPubOrderPrice.Tables.Add(keepOrderPriceDT.Copy)
                            End If
                        End If
                        '-----------------------------------------------------------------------------------

                    Else
                        ''add by 唐子晴 2013.12.18 --------------------------------------------------------------------------------------
                        If keepOrderDT.Rows(0).Item("Dc").ToString.Trim = "N" Then
                            'modify by 唐子晴 2014.03.28 ---------------------------------
                            If keepOrderDT.Rows(0).Item("Insu_Cover_Emg").ToString.Trim = "" AndAlso _
                                keepOrderDT.Rows(0).Item("Insu_Cover_Ipd").ToString.Trim = "" AndAlso _
                                keepOrderDT.Rows(0).Item("Insu_Cover_Opd").ToString.Trim() = "" Then
                                cbo_IPD.SelectedIndex = "2"
                                cbo_EMG.SelectedIndex = "2"
                                cbo_OPD.SelectedIndex = "2"
                            End If
                            '-------------------------------------------------------------
                        Else

                            '判斷OrderDS當中是否有相關Table
                            If OrderDS.Tables.Contains(PubOrderPriceDataTableFactory.tableName & "-" & "History") Then
                                cb_pricehistory.Checked = True
                                keepOrderPriceDT = OrderDS.Tables(PubOrderPriceDataTableFactory.tableName & "-" & "History").Clone
                                orderPriceToGrid(OrderDS.Tables(PubOrderPriceDataTableFactory.tableName & "-" & "History").Copy, True)
                            End If
                           
                        End If
                        ''--------------------------------------------------------------------------------------------------
                    End If

                    gblIsOrderExist = True

                Else
                    '查無Order資料
                    'MessageHandling.showError("該醫令非衛材類別")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令非衛材類別"}, "")
                    Clear()
                End If

            Else
                Clear()
                If leaveFlag Then
                  
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                Else
                 
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                    PUBMaterialUI_ucl_txtcq_ordercode.Focus()
                End If
            End If

        Else
            Clear()
            If leaveFlag Then

                If DataSetUtil.IsContainsData(OrderDS) = False Then

                    If MessageBox.Show("是否需要新增此筆資料，若是需要，請按下「是」並直接輸入相關的欄位", "注意", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        txt_ZhName.Text = str_TempOrderCode
                    End If

                End If

            Else
                'MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無醫令資料"}, "")
                PUBMaterialUI_ucl_txtcq_ordercode.Focus()
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
                PUBMaterialUI_ucl_txtcq_ordercode.Text = CType(OrderDR.Item("Order_Code"), String).Trim
                PUBMaterialUI_ucl_txtcq_ordercode.doFlag = False
            Else
                PUBMaterialUI_ucl_txtcq_ordercode.Text = ""
            End If

            If Not IsDBNull(OrderDR.Item("Order_Name")) Then
                txt_ZhName.Text = CType(OrderDR.Item("Order_Name"), String).Trim
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
            End If

            'txt_NhiCode.Text = ""
            'txt_Name.Text = ""

            If Not IsDBNull(OrderDR.Item("Order_En_Short_Name")) Then
                txt_SEName.Text = CType(OrderDR.Item("Order_En_Short_Name"), String).Trim
            End If
            If Not IsDBNull(OrderDR.Item("Order_Type_Id")) Then
                uclcomb_OrderType.SelectedValue = CType(OrderDR.Item("Order_Type_Id"), String).Trim
            End If
            If Not IsDBNull(OrderDR.Item("Account_Id")) Then
                'modify by 唐子晴 2014.03.28 -----------------------------------------------------
                If Not IsDBNull(OrderDR.Item("Order_Code").ToString.Trim) Then
                    Select Case OrderDR.Item("Order_Code").ToString.Trim.Substring(0, 2).ToUpper
                        Case "I5"
                            uclcomb_HosItem.SelectedValue = 35
                        Case "I6"
                            uclcomb_HosItem.SelectedValue = 35
                        Case "I8"
                            uclcomb_HosItem.SelectedValue = 35
                        Case "I9"
                            uclcomb_HosItem.SelectedValue = 35
                        Case Else
                            uclcomb_HosItem.SelectedValue = CType(OrderDR.Item("Account_Id"), String).Trim
                    End Select
                End If
                ''uclcomb_HosItem.SelectedValue = CType(OrderDR.Item("Account_Id"), String).Trim
                '----------------------------------------------------------------------------------
            End If
            If Not IsDBNull(OrderDR.Item("Charge_Unit")) Then
                txt_ChargeUnit.Text = CType(OrderDR.Item("Charge_Unit"), String).Trim
            End If

            If Not IsDBNull(OrderDR.Item("Order_Memo")) Then
                txt_Note.Text = CType(OrderDR.Item("Order_Memo"), String).Trim
            End If
            If Not IsDBNull(OrderDR.Item("Order_Note")) Then
                txt_OrederNote.Text = CType(OrderDR.Item("Order_Note"), String).Trim
            End If
            'modify by 唐子晴 2013.11.25============================================
            ''If Not IsDBNull(OrderDR.Item("Order_Flag")) Then
            ''    txt_Flag.Text = CType(OrderDR.Item("Order_Flag"), String).Trim
            ''End If
            'If Not IsDBNull(OrderDR.Item("Order_Flag")) Then
            '    ucl_Flag.SelectedValue = CType(OrderDR.Item("Order_Flag"), String).Trim
            'End If
            '========================================================================
            If Not IsDBNull(OrderDR.Item("Is_Order_Check")) Then
                If CType(OrderDR.Item("Is_Order_Check"), String).Trim.Equals("Y") Then
                    cb_OrderCheck.Checked = True
                Else
                    cb_OrderCheck.Checked = False
                End If
            End If
            'If Not IsDBNull(OrderDR.Item("Is_Indication")) Then
            '    If CType(OrderDR.Item("Is_Indication"), String).Trim.Equals("Y") Then
            '        cb_Indication.Checked = True
            '    Else
            '        cb_Indication.Checked = False
            '    End If
            'End If
            If Not IsDBNull(OrderDR.Item("Is_Nhi_Sheet")) Then
                If CType(OrderDR.Item("Is_Nhi_Sheet"), String).Trim.Equals("Y") Then
                    cb_NhiSheet.Checked = True
                Else
                    cb_NhiSheet.Checked = False
                End If
            End If

            If Not IsDBNull(OrderDR.Item("Nhi_Transrate")) Then

                txt_chargetransclaim.Text = CType(OrderDR.Item("Nhi_Transrate"), String).Trim

            End If

            If Not IsDBNull(OrderDR.Item("Nhi_Unit")) Then

                txt_ClaimUnit.Text = CType(OrderDR.Item("Nhi_Unit"), String).Trim

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

            If Not IsDBNull(OrderDR.Item("End_Date")) Then
                ucl_dtp_enddate.SetValue(CType(OrderDR.Item("End_Date"), Date).ToString("yyyy/MM/dd"))
                'add by 唐子晴 2014.05.06--
            Else
                ucl_dtp_enddate.Text = ""
                '---------------------------
            End If

            'If Not IsDBNull(OrderDR.Item("Manage_Id")) Then
            '    If Not IsDBNull(OrderDR.Item("Manage_Id")) Then
            '        uclcb_classify.SelectedValue = CType(OrderDR.Item("Manage_Id"), String).Trim
            '    End If
            'End If

            If Not IsDBNull(OrderDR.Item("Effect_Date")) Then
                ucldtp_EffectDate.SetValue(CType(OrderDR.Item("Effect_Date"), Date))
                gblEffectDate = ucldtp_EffectDate.GetUsDateStr
            Else
                gblEffectDate = ""
            End If

            If Not IsDBNull(OrderDR.Item("Material_Used_Cnt")) Then
                ucl_mat_use_cnt.Text = CType(OrderDR.Item("Material_Used_Cnt"), Integer)
            Else
                ucl_mat_use_cnt.Text = ""
            End If

            If Not IsDBNull(OrderDR.Item("Include_Order_Mark")) Then
                txt_IncludeOrder.Text = OrderDR.Item("Include_Order_Mark").ToString.Trim
            Else
                txt_IncludeOrder.Text = ""
            End If

            '健保內含項(不計價)
            If Not IsDBNull(OrderDR.Item("Include_Order_Mark")) And OrderDR.Item("Include_Order_Mark").ToString = "A" Then
                chk_IncludeOrderMark.Checked = True
            Else
                chk_IncludeOrderMark.Checked = False
            End If

            cbo_OPD.SelectedValue = OrderDR.Item("Insu_Cover_Opd").ToString.Trim

            cbo_EMG.SelectedValue = OrderDR.Item("Insu_Cover_Emg").ToString.Trim

            cbo_IPD.SelectedValue = OrderDR.Item("Insu_Cover_Ipd").ToString.Trim

            If Not IsDBNull(OrderDR.Item("Is_Prior_Review")) Then
                If CType(OrderDR.Item("Is_Prior_Review"), String).Trim.Equals("Y") Then
                    cb_preview.Checked = True
                Else
                    cb_preview.Checked = False
                End If
            Else
                cb_preview.Checked = False
            End If

            'If Not IsDBNull(OrderDR.Item("Brand")) Then
            '    txt_Brand.Text = CType(OrderDR.Item("Brand"), String).Trim
            'Else
            '    txt_Brand.Text = ""
            'End If

            'If Not IsDBNull(OrderDR.Item("Is_Inventory")) Then
            '    gblIsInventory = CType(OrderDR.Item("Is_Inventory"), String).Trim
            'Else
            '    gblIsInventory = ""
            'End If

            txt_CostPrice.Text = OrderDR.Item("Cost_Price").ToString.Trim

            If Not IsDBNull(OrderDR.Item("Is_Icd_Check")) Then
                gblIsIcdCheck = CType(OrderDR.Item("Is_Icd_Check"), String).Trim

            Else
                gblIsIcdCheck = ""
            End If

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
        '檢查是否有Main_Identity_Id=2的資料,沒有就新增, 有再檢查健保碼與健保編碼是否有值,若有就不覆蓋,若沒有就覆蓋
        Dim isId2Exist As Boolean = False
        Dim isId1Exist As Boolean = False
        'add by 唐子晴 2014.03.12
        insuCode = ""
        insuGroupCode = ""
        '-------------------
        If DataSetUtil.IsContainsData(DBOrderPriceDT) Then
            '...
            Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)


            For Each dr As DataRow In DBOrderPriceDT.Rows
                Dim OrderPriceDR As DataRow = OrderPriceDT.NewRow
                ' [Effect_Date],[Order_Code] [Main_Identity_Id],[Price],[Add_Price],[Material_Ratio],[Material_Account_Id],[Is_Emg_Add],[Is_Kid_Add],[Is_Dental_Add],[Is_Holiday_Add],[Insu_Code],[Insu_Cover_Opd],[Insu_Cover_Emg],[Insu_Cover_Ipd],[Insu_Account_Id],[Insu_Order_Type_Id],[Opd_Add_Order_Code],[Emg_Add_Order_Code],[Ipd_Add_Order_Code],[Emg_Nursing_Add_Order_Code],[Ipd_Nursing_Add_Order_Code],[Dc],[End_Date],[Create_User],[Create_Time],[Modified_User],[Modified_Time],[Insu_Group_Code]
                'mapping                
                '"主身分", "生效日", "單價", "差額", "停止日", "急件加成", "兒童加成", "牙科加成", "假日加成", "群組醫令碼", 
                '"門診可用", "急診可用", "住院可用", "健保碼", "健保編碼", "健保費用項目", "健保醫令類別", "健保核定單價", "Dc", "Is_New"
                If Not IsDBNull(dr.Item("Main_Identity_Id")) Then
                    If dr.Item("Main_Identity_Id").ToString.Trim = "1" Then
                        isId1Exist = True
                    End If
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)) = CType(dr.Item("Main_Identity_Id"), String).Trim
                End If
                If Not IsDBNull(dr.Item("Effect_Date")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Effect_Date)) = CType(dr.Item("Effect_Date"), Date)
                End If
                If Not IsDBNull(dr.Item("Price")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Price)) = CType(dr.Item("Price"), Decimal)
                End If
                If Not IsDBNull(dr.Item("Add_Price")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Add_Price)) = CType(dr.Item("Add_Price"), Decimal)
                End If
                If Not IsDBNull(dr.Item("End_Date")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.End_Date)) = CType(dr.Item("End_Date"), Date)
                End If
                If Not IsDBNull(dr.Item("Is_Emg_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add)) = CType(dr.Item("Is_Emg_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Kid_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add)) = CType(dr.Item("Is_Kid_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Dental_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add)) = CType(dr.Item("Is_Dental_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add)) = "N"
                End If
                If Not IsDBNull(dr.Item("Is_Dept_Add")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Dept_Add)) = CType(dr.Item("Is_Dept_Add"), String).Trim
                Else
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_Dept_Add)) = "N"
                End If

                'Opd_Add_Order_Code, Emg_Add_Order_Code, Ipd_Add_Order_Code, Emg_Nursing_Add_Order_Code, Ipd_Nursing_Add_Order_Code
                OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)) = getGroupAddOrder(dr)

                'If Not IsDBNull(dr.Item("Insu_Cover_Opd")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Opd)) = CType(dr.Item("Insu_Cover_Opd"), String).Trim
                'End If
                'If Not IsDBNull(dr.Item("Insu_Cover_Emg")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Emg)) = CType(dr.Item("Insu_Cover_Emg"), String).Trim
                'End If

                'If Not IsDBNull(dr.Item("Insu_Cover_Ipd")) Then
                '    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Ipd)) = CType(dr.Item("Insu_Cover_Ipd"), String).Trim
                'End If
                If Not IsDBNull(dr.Item("Insu_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Code)) = CType(dr.Item("Insu_Code"), String).Trim
                    gblInsuCode = CType(dr.Item("Insu_Code"), String).Trim
                End If
                If Not IsDBNull(dr.Item("Insu_Group_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code)) = CType(dr.Item("Insu_Group_Code"), String).Trim
                End If
                If Not IsDBNull(dr.Item("Insu_Account_Id")) Then
                    If CType(dr.Item("Insu_Account_Id"), String).Trim.Length > 0 Then
                        OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id)) = CType(dr.Item("Insu_Account_Id"), String).Trim
                    End If
                End If
                If Not IsDBNull(dr.Item("Insu_Order_Type_Id")) Then
                    If CType(dr.Item("Insu_Order_Type_Id"), String).Trim.Length > 0 Then
                        OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id)) = CType(dr.Item("Insu_Order_Type_Id"), String).Trim
                    End If
                End If

                If Not IsDBNull(dr.Item("Insu_Apply_Price")) Then
                    If CType(dr.Item("Insu_Apply_Price"), String).Trim.Length > 0 Then
                        OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price)) = CType(dr.Item("Insu_Apply_Price"), Decimal)
                    End If
                End If

                If Not IsDBNull(dr.Item("Dc")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.DC)) = CType(dr.Item("Dc"), String).Trim
                End If

                OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Is_New)) = "N"
                '若原先的Order_Price沒有健保碼與健保碼就填入PUB_Mis_Purchase_Data的
                If dr.Item("Main_Identity_Id").ToString.Trim = "2" Then
                    isId2Exist = True
                    If dr.Item("Insu_Code").ToString.Trim = "" Then
                        dr.Item("Insu_Code") = insuCode
                    End If
                    If dr.Item("Insu_Group_Code").ToString.Trim = "" Then
                        dr.Item("Insu_Group_Code") = insuGroupCode
                    End If
                End If

                '計價註記
                If Not IsDBNull(dr.Item("Charge_Flag")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag)) = CType(dr.Item("Charge_Flag"), String).Trim
                End If

                '門診連帶碼
                If Not IsDBNull(dr.Item("Opd_Add_Order_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code)) = CType(dr.Item("Opd_Add_Order_Code"), String).Trim
                End If

                '急診連帶碼
                If Not IsDBNull(dr.Item("Emg_Add_Order_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code)) = CType(dr.Item("Emg_Add_Order_Code"), String).Trim
                End If

                '住院連帶碼
                If Not IsDBNull(dr.Item("Ipd_Add_Order_Code")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code)) = CType(dr.Item("Ipd_Add_Order_Code"), String).Trim
                End If

                '比率
                If Not IsDBNull(dr.Item("Order_Ratio")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio)) = CType(dr.Item("Order_Ratio"), Decimal)
                Else
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio)) = 0
                End If

                '群組

                'add by 唐子晴 2014.02.18 ------------------------------------------------------------------------------------
                If Not IsDBNull(dr.Item("Modified_Time")) Then
                    OrderPriceDR.Item(OrderPriceColumn(PUB_Order_Price.Modified_Time)) = CType(CDate(dr.Item("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss"), String)
                End If
                '-------------------------------------------------------------------------------------------------------------
                OrderPriceDT.Rows.Add(OrderPriceDR)
            Next

            updateGridView(OrderPriceDT)

        Else
            'addOneEmptyRecordToGrid()
            Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
            updateGridView(OrderPriceDT)
            '直接加入一個新的健保列
            'addNewGridRow("1", "", "")
            'addNewGridRow("2", insuCode, insuGroupCode)

            'add by 唐子晴 2014.02.19
            isId2Exist = True
            '-----------------
        End If

        If Not isId1Exist Then
            addNewGridRow("1", "", "")
        End If
        If Not isId2Exist And (insuCode.Trim <> "" Or insuGroupCode.Trim <> "") Then
            addNewGridRow("2", insuCode, insuGroupCode)
        End If

        If Not isHistory Then
            '加一行
            addNewGridRow()

            'modify by 唐子晴 2014.02.19-----------------------------------------
            ''For i = 0 To ucldgv_OrderPrice.GetDBDS.Tables(0).Rows.Count - 2
            ''    ucldgv_OrderPrice.SetCellReadOnly(0, i, True)
            ''Next
            If ucldgv_OrderPrice.GetDBDS.Tables.Count > 0 Then
                For i = 0 To ucldgv_OrderPrice.GetDBDS.Tables(0).Rows.Count - 2
                    ucldgv_OrderPrice.SetCellReadOnly(0, i, True)
                Next
            End If
            '---------------------------------------------------------------------            
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
        If Not PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
            PUBMaterialUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = PUBMaterialUI_ucl_txtcq_ordercode
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

        If Not PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim.Length > 0 Then
            PUBMaterialUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = PUBMaterialUI_ucl_txtcq_ordercode
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

        'If cb_preview.Checked AndAlso txt_Brand.Text.Trim = "" Then
        '    txt_Brand.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = txt_Brand
        '    If gblErrorMsg <> "" Then
        '        gblErrorMsg &= ",廠牌"
        '    Else
        '        gblErrorMsg = "廠牌"
        '    End If
        'End If

        If txt_ChargeUnit.Text.Trim = "" Then
            txt_ChargeUnit.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = txt_ChargeUnit
            End If
            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",計價單位"
            Else
                gblErrorMsg = "計價單位"
            End If
        End If

        If txt_chargetransclaim.Text.Trim.Equals("") Then
            txt_chargetransclaim.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = txt_chargetransclaim
            End If
            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",計價轉換申報單位"
            Else
                gblErrorMsg = "計價轉換申報單位"
            End If
        End If

        If txt_ClaimUnit.Text.Trim = "" Then
            txt_ClaimUnit.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            If comp Is Nothing Then
                comp = txt_ClaimUnit
            End If
            If gblErrorMsg <> "" Then
                gblErrorMsg &= ",申報單位"
            Else
                gblErrorMsg = "申報單位"
            End If
        End If

        'If gblEffectDate <> ucldtp_EffectDate.GetUsDateStr AndAlso DateDiff(DateInterval.Day, DateUtil.getSystemDate, Date.Parse(ucldtp_EffectDate.GetUsDateStr)) < 0 Then
        '    ucldtp_EffectDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    If comp Is Nothing Then
        '        comp = ucldtp_EffectDate
        '    End If

        '    MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"生效日", "系統日期"}, "")
        '    Return allPass
        'End If

        'If Not IsDate(ucldtp_EffectDate.GetUsDateStr) Then
        '    ucldtp_EffectDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    If comp Is Nothing Then
        '        comp = ucldtp_EffectDate
        '    End If
        '    If gblErrorMsg <> "" Then
        '        gblErrorMsg &= ",生效日"
        '    Else
        '        gblErrorMsg = "生效日"
        '    End If
        'End If

        'If cb_Dc.Checked Then
        '    If IsDate(ucl_dtp_enddate.GetUsDateStr) Then

        '    Else
        '        ucl_dtp_enddate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '        allPass = False
        '        If comp Is Nothing Then
        '            comp = ucl_dtp_enddate
        '        End If
        '        If gblErrorMsg <> "" Then
        '            gblErrorMsg &= ",停用日期"
        '        Else
        '            gblErrorMsg = "停用日期"
        '        End If
        '    End If
        'End If

        'If IsDate(ucl_dtp_enddate.GetUsDateStr) Then

        '    If DateDiff(DateInterval.Day, Date.Parse(ucl_dtp_enddate.GetUsDateStr), Date.Parse(ucldtp_EffectDate.GetUsDateStr)) > 0 Then
        '        allPass = False
        '        If comp Is Nothing Then
        '            comp = ucl_dtp_enddate
        '        End If
        '        MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"停用日期", "生效日"}, "")

        '    End If

        'End If

        'add by 唐子晴 2013.11.25==========================================
        'If Not uclcb_classify.SelectedIndex > 0 Then
        '    uclcb_classify.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    If comp Is Nothing Then
        '        comp = uclcb_classify
        '    End If
        '    If gblErrorMsg <> "" Then
        '        gblErrorMsg &= ",給付註記"
        '    Else
        '        gblErrorMsg = "給付註記"
        '    End If
        'End If
        '==================================================================

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
        'add by 唐子晴 2013.12.11---
        If cb_Dc.Checked Then
            Return True
        End If
        '---------------------------

        If checkGridRowHasData(True, 0) Then
            Return checkDataContentCorrect()
        Else
            addNewGridRow()
            Return False
        End If
    End Function

    '子功能 欄位has data檢查
    Private Function checkGridRowHasData(ByVal chkAllFlag As Boolean, ByVal chkIndex As Integer) As Boolean

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
                    If chkIndex = i AndAlso CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim <> "" Then
                        pvtExeChkFlag = True
                    Else
                        pvtExeChkFlag = False
                    End If
                End If

                If pvtExeChkFlag AndAlso (Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)))) AndAlso (Not CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Equals("")) Then
                    If CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Equals("2") Then '健保
                        '檢查健保欄位 13, 14, 15
                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code))) Then
                            If chkNhiCode(PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim) Then
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
                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code)), String).Trim.Equals("") Then
                            If chkNhiCode(PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim) Then
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

                        'If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code))) Then
                        '    GridSelectedIndex = i
                        '    If gblErrorMsg <> "" Then
                        '        gblErrorMsg &= ",健保編碼"
                        '    Else
                        '        gblErrorMsg = "健保編碼"
                        '    End If
                        'ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code)), String).Trim.Equals("") Then
                        '    GridSelectedIndex = i
                        '    If gblErrorMsg <> "" Then
                        '        gblErrorMsg &= ",健保編碼"
                        '    Else
                        '        gblErrorMsg = "健保編碼"
                        '    End If
                        'Else

                        'End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保費用項目"
                            Else
                                gblErrorMsg = "健保費用項目"
                            End If
                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id)), String).Trim.Equals("") Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",健保費用項目"
                            Else
                                gblErrorMsg = "健保費用項目"
                            End If
                        Else

                        End If
                        'add by 唐子晴 2014.01.13---------------------------------------
                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Add_Price))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",差額"
                            Else
                                gblErrorMsg = "差額"
                            End If
                        ElseIf CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Add_Price)), String).Trim.Equals("0") Then
                            If uclcb_classify.SelectedValue = "4" Then
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",差額"
                                Else
                                    gblErrorMsg = "差額"
                                End If
                            End If
                        Else

                        End If
                        '-------------------------------------------------------------
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

                        If DateDiff(DateInterval.Day, Date.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date))), PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date))) < 0 Then
                            GridSelectedIndex = i
                            'MessageHandling.ShowErrorMsg("CMMCMMB102", New String() {"停止日", "生效日"}, "")
                            Return False
                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",生效日"
                            Else
                                gblErrorMsg = "生效日"
                            End If
                        Else

                        End If

                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Price))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",單價"
                            Else
                                gblErrorMsg = "單價"
                            End If
                        Else
                            Dim price As Decimal = -1
                            Try
                                price = Decimal.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Price)))
                            Catch ex As Exception
                                GridSelectedIndex = i
                                If gblErrorMsg <> "" Then
                                    gblErrorMsg &= ",單價"
                                Else
                                    gblErrorMsg = "單價"
                                End If
                            End Try
                        End If
                        'modify by 唐子晴 2014.01.13---------------------------------
                        ''If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Add_Price))) Then
                        ''    GridSelectedIndex = i
                        ''Else
                        ''    Dim addprice As Decimal = -1
                        ''    Try
                        ''        addprice = Decimal.Parse(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Add_Price)))
                        ''    Catch ex As Exception
                        ''        GridSelectedIndex = i
                        ''        If gblErrorMsg <> "" Then
                        ''            gblErrorMsg &= ",差額"
                        ''        Else
                        ''            gblErrorMsg = "差額"
                        ''        End If
                        ''    End Try
                        ''End If
                        '--------------------------------------------------------
                        If IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date))) Then
                            GridSelectedIndex = i
                            If gblErrorMsg <> "" Then
                                gblErrorMsg &= ",停用日期"
                            Else
                                gblErrorMsg = "停用日期"
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
            '無資料...
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

                If (Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)))) AndAlso (Not CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Equals("")) Then
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
                    If Not IsDBNull(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id))) Then
                        Dim tmpMainid As String = CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim

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
                        If CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.DC)), String).Trim.Equals("N") Then
                            Dim IMaim As String = CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim
                            Dim IEffect As Date = CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date)), Date)
                            Dim IEnd As Date = PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date)).ToString.Substring(0, 10)

                            If (i + 1) <= (PriceDT.Rows.Count - 1) Then
                                For j As Integer = (i + 1) To (PriceDT.Rows.Count - 1)
                                    If CType(PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.DC)), String).Trim.Equals("N") Then
                                        '...check logic & replace PriceDT.Rows(i)與 PriceDT.Rows(j)
                                        Dim JMaim As String = CType(PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim
                                        Dim JEffect As Date = CType(PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date)), Date)
                                        Dim JEnd As Date = CType(PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.End_Date)), Date)

                                        If IMaim.Equals(JMaim) Then
                                            '改i日期
                                            If IEnd.CompareTo(JEffect) >= 0 Then

                                                If CType(PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.End_Date)), Date).CompareTo(CType(PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date)), Date)) > 0 Then

                                                Else
                                                    PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.End_Date)) = PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date))
                                                End If

                                                PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.End_Date)) = JEffect.AddDays(-1)

                                                If JEffect.CompareTo(SystemDate) > 0 Then
                                                    PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.DC)) = "N"
                                                    PriceDT.Rows(j).Item(OrderPriceColumn(PUB_Order_Price.Is_New)) = "Y"
                                                Else
                                                    PriceDT.Rows(i).Item(OrderPriceColumn(PUB_Order_Price.DC)) = "Y"
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
            PUBMaterialUI_ucl_txtcq_ordercode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            uclcomb_OrderType.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            uclcomb_HosItem.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            txt_ChargeUnit.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub addNewGridRow()

        addNewGridRow("", "", "")

    End Sub
    Private Sub addNewGridRow(ByVal mainIdentityId As String, ByVal insuCode As String, ByVal insuGroupCode As String)

        Dim GridDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

        If GridDS.Tables(0).Rows.Count - 1 < 1 Then '只保留自費和健保兩個存取空間

            ucldgv_OrderPrice.AddNewRow()

            GridDS = ucldgv_OrderPrice.GetDBDS.Copy

            If GridDS IsNot Nothing AndAlso GridDS.Tables.Count > 0 AndAlso GridDS.Tables(0).Rows.Count > 0 AndAlso GridDS.Tables(0).Rows.Count - 1 < 2 Then
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)) = mainIdentityId
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date)) = SystemDate.ToString("yyyy/MM/dd")
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.End_Date)) = defaultEndDate.ToString("yyyy/MM/dd") ' DateUtil.TransDateToROC(defaultEndDate) 
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add)) = "N"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add)) = "N"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add)) = "N"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Is_Dept_Add)) = "N"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)) = ""

                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Opd)) = "Y"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Emg)) = "Y"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Cover_Ipd)) = "Y"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.DC)) = "N"
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Is_New)) = "Y"

                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code)) = insuCode
                GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code)) = insuGroupCode

                'add by 唐子晴 2014.02.18 -------------------------------------------------------------------------------------------------
                If mainIdentityId <> "" AndAlso mainIdentityId = 2 Then
                    GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id)) = 50
                    GridDS.Tables(0).Rows(GridDS.Tables(0).Rows.Count - 1).Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id)) = 3
                End If
                '--------------------------------------------------------------------------------------------------------------------------
                ucldgv_OrderPrice.ClearDS()
                ucldgv_OrderPrice.Visible = False
                ucldgv_OrderPrice.SetDS(GridDS)
                ucldgv_OrderPrice.Visible = True
            End If

        End If

    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub query(ByVal leaveFlag As Boolean)

        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            Dim OrderCode As String = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
            Dim QueryDate As Date = SystemDate

            If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                QueryDate = Date.Parse(ucldtp_EffectDate.GetUsDateStr)
            End If
            Dim OrderDS As DataSet = pub.queryOrderData(OrderCode, QueryDate)

            If OrderDS.Tables.Contains("PUB_Material_Selfpay_Apply") Then
                gblOrderMaterialDT = OrderDS.Tables("PUB_Material_Selfpay_Apply").Copy
            Else
                gblOrderMaterialDT = Nothing
            End If

            '將資料帶入相關控制項當中
            Try
                OrderRelatedDataToUI(OrderDS, leaveFlag, OrderCode)
            Catch ex As Exception

            End Try

         
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

                '----------------------------------------------------------------------------------------
                '醫令主檔部份
                '
                '----------------------------------------------------------------------------------------
                If keepOrderDT IsNot Nothing AndAlso keepOrderDT.Rows(0).Item("Order_Code").ToString.Trim <> PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim Then

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
                    oldToProcessOrderDT.Rows(0).Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
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
                    If txt_ChargeUnit.Text.Trim <> "" Then
                        oldToProcessOrderDT.Rows(0).Item("Charge_Unit") = txt_ChargeUnit.Text.Trim
                        oldToProcessOrderDT.Rows(0).Item("Nhi_Unit") = txt_ClaimUnit.Text.Trim
                        oldToProcessOrderDT.Rows(0).Item("Nhi_Transrate") = txt_chargetransclaim.Text.Trim
                    End If

                    If txt_Note.Text.Trim.Length > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Order_Memo") = txt_Note.Text
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Order_Memo") = ""
                    End If

                    If txt_OrederNote.Text.Trim.Length > 0 Then
                        oldToProcessOrderDT.Rows(0).Item("Order_Note") = txt_OrederNote.Text
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Order_Note") = ""
                    End If
                    'modify by 唐子晴 2013.11.25=============================================
                    ''If txt_Flag.Text.Trim.Length > 0 Then
                    ''    oldToProcessOrderDT.Rows(0).Item("Order_Flag") = txt_Flag.Text
                    ''Else
                    ''    oldToProcessOrderDT.Rows(0).Item("Order_Flag") = ""
                    ''End If
                    ' oldToProcessOrderDT.Rows(0).Item("Order_Flag") = ucl_Flag.SelectedValue
                    '========================================================================

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

                    If txt_ClaimUnit.Text.Trim <> "" Then
                        oldToProcessOrderDT.Rows(0).Item("Nhi_Unit") = txt_ClaimUnit.Text.Trim
                    End If

                    'If uclcb_classify.SelectedIndex > 0 Then
                    '    oldToProcessOrderDT.Rows(0).Item("Manage_Id") = uclcb_classify.SelectedValue
                    'Else
                    '    oldToProcessOrderDT.Rows(0).Item("Manage_Id") = ""
                    'End If

                    'TODO.....
                    If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                        oldToProcessOrderDT.Rows(0).Item("Effect_Date") = ucldtp_EffectDate.GetUsDateStr
                    End If

                    If ucl_mat_use_cnt.Text.Trim.Length > 0 Then
                        Dim useCnt As Integer = 0
                        Try
                            useCnt = Integer.Parse(ucl_mat_use_cnt.Text.Trim())
                        Catch ex As Exception
                        End Try
                        oldToProcessOrderDT.Rows(0).Item("Material_Used_Cnt") = useCnt
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Material_Used_Cnt") = DBNull.Value
                    End If


                 ' Material_Used_Cnt
                    oldToProcessOrderDT.Rows(0).Item("Material_Used_Cnt") = 0

                    '健保內含項(不計價)
                    If chk_IncludeOrderMark.Checked = True Then
                        oldToProcessOrderDT.Rows(0).Item("Include_Order_Mark") = "A" 'txt_IncludeOrder
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Include_Order_Mark") = ""
                    End If

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

                    If cb_preview.Checked Then
                        oldToProcessOrderDT.Rows(0).Item("Is_Prior_Review") = "Y"
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Is_Prior_Review") = "N"
                    End If

                    '成本價格
                    If txt_CostPrice.Text.Trim <> "" Then
                        oldToProcessOrderDT.Rows(0).Item("Cost_Price") = txt_CostPrice.Text.Trim
                    Else
                        oldToProcessOrderDT.Rows(0).Item("Cost_Price") = 0
                    End If

                    oldToProcessOrderDT.Rows(0).Item("Fix_Order_Id") = "N"
                    oldToProcessOrderDT.Rows(0).Item("Is_Alternative") = "N"

                    'oldToProcessOrderDT.Rows(0).Item("Is_Inventory") = gblIsInventory
                    oldToProcessOrderDT.Rows(0).Item("Is_Icd_Check") = gblIsIcdCheck

                    oldToProcessOrderDT.Rows(0).Item("Modified_User") = loginUser
                    oldToProcessOrderDT.Rows(0).Item("Modified_Time") = SystemDate
                Else
                    Dim newOrderDr As DataRow = newOrderDT.NewRow
                    '新增TODO

                    If IsDate(ucldtp_EffectDate.GetUsDateStr) Then
                        newOrderDr.Item("Effect_Date") = ucldtp_EffectDate.GetUsDateStr
                    End If

                    newOrderDr.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim

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
                    If txt_ChargeUnit.Text.Trim <> "" Then
                        newOrderDr.Item("Charge_Unit") = txt_ChargeUnit.Text.Trim
                        'newOrderDr.Item("Nhi_Unit") = uclcomb_ChargeUnit.SelectedValue
                    End If

                    If txt_ClaimUnit.Text.Trim <> "" Then
                        newOrderDr.Item("Nhi_Unit") = txt_ClaimUnit.Text.Trim
                    End If

                    newOrderDr.Item("Nhi_Transrate") = txt_chargetransclaim.Text.Trim

                    newOrderDr.Item("Is_Cure") = "N"
                    newOrderDr.Item("Is_Exclude_Drug") = "N"
                    newOrderDr.Item("Fix_Order_Id") = ""

                    'memo_OrderMemo
                    ' 
                    If txt_Note.Text.Trim.Length > 0 Then
                        newOrderDr.Item("Order_Memo") = txt_Note.Text
                    Else
                        newOrderDr.Item("Order_Memo") = ""
                    End If

                    If txt_OrederNote.Text.Trim.Length > 0 Then
                        newOrderDr.Item("Order_Note") = txt_OrederNote.Text
                    Else
                        newOrderDr.Item("Order_Note") = ""
                    End If

                    'modify by 唐子晴 2013.11.25================================
                    ''If txt_Flag.Text.Trim.Length > 0 Then
                    ''    newOrderDr.Item("Order_Flag") = txt_Flag.Text
                    ''Else
                    ''    newOrderDr.Item("Order_Flag") = ""
                    ''End If
                    ' newOrderDr.Item("Order_Flag") = ucl_Flag.SelectedValue
                    '=========================================================

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

                    If uclcb_classify.SelectedIndex > 0 Then
                        newOrderDr.Item("Manage_Id") = 1 'uclcb_classify.SelectedValue
                    End If

                    'newOrderDr.Item("Dc") = "N"
                    newOrderDr.Item("Is_IC_Card_Order") = "N"
                    newOrderDr.Item("Is_Order_Price_Special") = "N"
                    newOrderDr.Item("Dc_Reason") = ""

                    newOrderDr.Item("End_Date") = "2910/12/31"

                    If ucl_mat_use_cnt.Text.Trim.Length > 0 Then
                        Dim useCnt As Integer = 0
                        Try
                            useCnt = Integer.Parse(ucl_mat_use_cnt.Text.Trim())
                        Catch ex As Exception
                        End Try
                        newOrderDr.Item("Material_Used_Cnt") = useCnt
                    Else
                        newOrderDr.Item("Material_Used_Cnt") = DBNull.Value
                    End If

                    'Material_Used_Cnt
                    newOrderDr.Item("Material_Used_Cnt") = 0

                    '健保內含項(不計價)
                    If chk_IncludeOrderMark.Checked = True Then
                        newOrderDr.Item("Include_Order_Mark") = "A" 'txt_IncludeOrder
                    Else
                        newOrderDr.Item("Include_Order_Mark") = ""
                    End If

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

                    If cb_preview.Checked Then
                        newOrderDr.Item("Is_Prior_Review") = "Y"
                    Else
                        newOrderDr.Item("Is_Prior_Review") = "N"
                    End If


                    'If txt_Brand.Text.Trim.Length > 0 Then
                    '    newOrderDr.Item("Brand") = txt_Brand.Text
                    'Else
                    '    newOrderDr.Item("Brand") = ""
                    'End If

                    '成本價格
                    If txt_CostPrice.Text.Trim <> "" Then
                        newOrderDr.Item("Cost_Price") = txt_CostPrice.Text.Trim
                    Else
                        newOrderDr.Item("Cost_Price") = 0
                    End If

                    newOrderDr.Item("Fix_Order_Id") = "N"
                    newOrderDr.Item("Is_Alternative") = "N"

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


                    '----------------------------------------------------------------------------------------
                    '醫令價格部份
                    '
                    '----------------------------------------------------------------------------------------
                    If DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) Then
                        '畫面至少會有一筆

                        Dim UIPriceDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

                        Dim addOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema

                        'add by 唐子晴 2014.03.12 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        Dim updateOrderPriceDt As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                        'modify by 唐子晴 2014.03.28---------------------------------------------------
                        Dim DBPriceDt As DataTable
                        If Not keepOrderPriceDT Is Nothing Then
                            If keepOrderPriceDT.TableName = PubOrderPriceDataTableFactory.tableName Then
                                DBPriceDt = keepOrderPriceDT.Copy
                            Else
                                DBPriceDt = keepOrderPriceHistoryDT.Copy
                            End If
                        ElseIf Not keepOrderPriceHistoryDT Is Nothing Then
                            DBPriceDt = keepOrderPriceHistoryDT.Copy
                        Else
                            DBPriceDt = PubOrderPriceDataTableFactory.getDataTableWithSchema
                        End If
                        '---------------------------------------------------------------------------------
                        If cb_pricehistory.Checked = True Then

                            For cnt As Integer = 0 To UIPriceDS.Tables(0).Rows.Count - 1

                                Try
                                    Dim updateFlag As Boolean = False
                                    Dim updateOPDr As DataRow = DBPriceDt.Rows(cnt)

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date))) <> DBPriceDt.Rows(cnt).Item("Effect_Date") Then
                                        updateOPDr.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Effect_Date))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price))) = True, 0, UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price))) <> DBPriceDt.Rows(cnt).Item("Insu_Apply_Price") Then
                                        updateOPDr.Item("Insu_Apply_Price") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Price))) = True, 0, UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Price))) <> DBPriceDt.Rows(cnt).Item("Price") Then
                                        updateOPDr.Item("Price") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Price))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Add_Price))) = True, 0, UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Add_Price))) <> DBPriceDt.Rows(cnt).Item("Add_Price") Then
                                        updateOPDr.Item("Add_Price") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Add_Price))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.End_Date))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.End_Date))) <> DBPriceDt.Rows(cnt).Item("End_Date") Then
                                        updateOPDr.Item("End_Date") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.End_Date))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add))) <> DBPriceDt.Rows(cnt).Item("Is_Emg_Add") Then
                                        updateOPDr.Item("Is_Emg_Add") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add))) <> DBPriceDt.Rows(cnt).Item("Is_Kid_Add") Then
                                        updateOPDr.Item("Is_Kid_Add") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add))) <> DBPriceDt.Rows(cnt).Item("Is_Dental_Add") Then
                                        updateOPDr.Item("Is_Dental_Add") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Insu_Code").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Insu_Code").ToString.Trim) Then
                                        updateOPDr.Item("Insu_Code") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Code))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Insu_Group_Code").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Insu_Group_Code").ToString.Trim) Then
                                        updateOPDr.Item("Insu_Group_Code") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Insu_Account_Id").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Insu_Account_Id").ToString.Trim) Then
                                        updateOPDr.Item("Insu_Account_Id") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id))
                                        updateFlag = True
                                    End If

                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Insu_Order_Type_Id").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Insu_Order_Type_Id").ToString.Trim) Then
                                        updateOPDr.Item("Insu_Order_Type_Id") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id))
                                        updateFlag = True
                                    End If

                                    '計價註記
                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Charge_Flag").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Charge_Flag").ToString.Trim) Then
                                        updateOPDr.Item("Charge_Flag") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag))
                                        updateFlag = True
                                    End If

                                    '門診連帶碼
                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Opd_Add_Order_Code").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Opd_Add_Order_Code").ToString.Trim) Then
                                        updateOPDr.Item("Opd_Add_Order_Code") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code))
                                        updateFlag = True
                                    End If

                                    '急診連帶碼
                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Emg_Add_Order_Code").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Emg_Add_Order_Code").ToString.Trim) Then
                                        updateOPDr.Item("Emg_Add_Order_Code") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code))
                                        updateFlag = True
                                    End If

                                    '住院連帶碼
                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Ipd_Add_Order_Code").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Ipd_Add_Order_Code").ToString.Trim) Then
                                        updateOPDr.Item("Ipd_Add_Order_Code") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code))
                                        updateFlag = True
                                    End If

                                    '比率
                                    If IIf(IsDBNull(UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio))) = True, "", UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio))) <> IIf(IsDBNull(DBPriceDt.Rows(cnt).Item("Order_Ratio").ToString.Trim) = True, "", DBPriceDt.Rows(cnt).Item("Order_Ratio").ToString.Trim) Then
                                        updateOPDr.Item("Order_Ratio") = UIPriceDS.Tables(0).Rows(cnt).Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio))
                                        updateFlag = True
                                    End If

                                    If updateFlag Then
                                        updateOPDr.Item("Modified_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                                        updateOPDr.Item("Modified_User") = loginUser
                                        updateOrderPriceDt.ImportRow(updateOPDr)
                                    End If


                                Catch ex As Exception
                                    MessageBox.Show(ex.Source)
                                End Try


                            Next
                            '---------------------------------------------------------------------------------------------------------------------------------------------
                        Else
                            '都新的

                            '加入keepOrderPriceDT
                            For Each dr As DataRow In UIPriceDS.Tables(0).Rows
                                If (Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)))) AndAlso CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Length > 0 _
                                AndAlso (Not (CType(dr.Item(OrderPriceColumn(PUB_Order_Price.DC)), String).Trim.Equals("Y") And CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_New)), String).Trim.Equals("Y"))) Then
                                    Dim MainId As String = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim
                                    Dim EffectDate As String = dr.Item(OrderPriceColumn(1))
                                    Dim EndDate As String = CType(dr.Item(OrderPriceColumn(5)), Date).ToShortDateString
                                    Dim newOPDr As DataRow = addOrderPriceDT.NewRow

                                    'TODO: process new...
                                    '新增

                                    'process new...
                                    newOPDr.Item("Effect_Date") = EffectDate
                                    newOPDr.Item("Main_Identity_Id") = MainId
                                    newOPDr.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim

                                    newOPDr.Item("Price") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Price)), Decimal)

                                    'Add_Price
                                    If dr.Item(OrderPriceColumn(CInt(PUB_Order_Price.Add_Price))).ToString = "" Then
                                        newOPDr.Item("Add_Price") = 0
                                    Else

                                        newOPDr.Item("Add_Price") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Price)), Decimal)

                                    End If

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(4))) Then
                                        If EndDate <> "" Then
                                            newOPDr.Item("End_Date") = EndDate
                                        Else
                                            newOPDr.Item("End_Date") = DBNull.Value
                                        End If
                                    Else
                                        newOPDr.Item("End_Date") = DBNull.Value
                                    End If

                                    newOPDr.Item("Order_Ratio") = 1
                                    newOPDr.Item("Material_Ratio") = 0
                                    newOPDr.Item("Material_Account_Id") = ""

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add))) Then
                                        newOPDr.Item("Is_Emg_Add") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Emg_Add)), String).Trim
                                    Else
                                        newOPDr.Item("Is_Emg_Add") = "N"
                                    End If
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add))) Then
                                        newOPDr.Item("Is_Kid_Add") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Kid_Add)), String).Trim
                                    Else
                                        newOPDr.Item("Is_Kid_Add") = "N"
                                    End If
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add))) Then
                                        newOPDr.Item("Is_Dental_Add") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Dental_Add)), String).Trim
                                    Else
                                        newOPDr.Item("Is_Dental_Add") = "N"
                                    End If

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Dept_Add))) Then
                                        newOPDr.Item("Is_Dept_Add") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Is_Dept_Add)), String).Trim
                                    Else
                                        newOPDr.Item("Is_Dept_Add") = "N"
                                    End If

                                    newOPDr.Item("Is_Holiday_Add") = "N"

                                    '計價註記
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag))) Then
                                        newOPDr.Item("Charge_Flag") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Charge_Flag)), String).Trim
                                    Else
                                        newOPDr.Item("Charge_Flag") = ""
                                    End If

                                    '門診連帶碼
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code))) Then
                                        newOPDr.Item("Opd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Opd_Add_Order_Code)), String).Trim
                                    Else
                                        newOPDr.Item("Opd_Add_Order_Code") = ""
                                    End If

                                    '急診連帶碼
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code))) Then
                                        newOPDr.Item("Emg_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Emg_Add_Order_Code)), String).Trim
                                    Else
                                        newOPDr.Item("Emg_Add_Order_Code") = ""
                                    End If

                                    '住院連帶碼
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code))) Then
                                        newOPDr.Item("Ipd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Ipd_Add_Order_Code)), String).Trim
                                    Else
                                        newOPDr.Item("Ipd_Add_Order_Code") = ""
                                    End If

                                    '比率
                                    If dr.Item(OrderPriceColumn(CInt(PUB_Order_Price.Order_Ratio))).ToString = "" Then
                                        newOPDr.Item("Order_Ratio") = 0
                                    Else
                                        newOPDr.Item("Order_Ratio") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Order_Ratio)), Decimal)
                                    End If

                                    '2091014 TODO has群組醫令給群組醫令碼
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code))) Then
                                        'newOPDr.Item("Opd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim
                                        'newOPDr.Item("Emg_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim
                                        'newOPDr.Item("Ipd_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim
                                        'newOPDr.Item("Emg_Nursing_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim
                                        'newOPDr.Item("Ipd_Nursing_Add_Order_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim
                                    Else
                                        newOPDr.Item("Opd_Add_Order_Code") = ""
                                        newOPDr.Item("Emg_Add_Order_Code") = ""
                                        newOPDr.Item("Ipd_Add_Order_Code") = ""
                                        newOPDr.Item("Emg_Nursing_Add_Order_Code") = ""
                                        newOPDr.Item("Ipd_Nursing_Add_Order_Code") = ""
                                    End If


                                    '身分2健保的
                                    '"健保碼", "健保編碼", "健保費用項目", "健保醫令類別", "健保核定單價", "Dc", "Is_New"}
                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Code))) Then
                                        newOPDr.Item("Insu_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Code)), String).Trim
                                    End If

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code))) Then
                                        newOPDr.Item("Insu_Group_Code") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Group_Code)), String).Trim
                                    End If

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id))) Then
                                        newOPDr.Item("Insu_Account_Id") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Account_Id)), String).Trim
                                    End If

                                    If Not IsDBNull(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id))) Then
                                        newOPDr.Item("Insu_Order_Type_Id") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Order_Type_Id)), String).Trim
                                    End If

                                    If dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price)).ToString <> "" Then
                                        newOPDr.Item("Insu_Apply_Price") = CType(dr.Item(OrderPriceColumn(PUB_Order_Price.Insu_Apply_Price)), Decimal)
                                    Else
                                        newOPDr.Item("Insu_Apply_Price") = 0
                                    End If

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
                        End If
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
                        'add by 唐子晴 2014.03.12 ----------------------------
                        If DataSetUtil.IsContainsData(updateOrderPriceDt) Then
                            updateOrderPriceDt.TableName = "updateorderprice"
                            OrderRelatedDS.Tables.Add(updateOrderPriceDt.Copy)
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
                            pvtAddDT = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), gblInsuCode, PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim)

                            If pvtAddDT IsNot Nothing AndAlso pvtAddDT.Rows.Count > 0 Then

                                Dim pvtIsOpenEmgAddOption, pvtO, pvtE, pvtI As Boolean

                                For i As Integer = 0 To (UIPriceDS.Tables(0).Rows.Count - 1)

                                    If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.DC)), String).Trim.Equals("N") AndAlso _
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
                                                emgI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Substring(0, 10)
                                                emgI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                                emgI.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
                                                emgI.Item("Emg_Add_Ratio") = pvtAddDT.Rows(0).Item("Emg_Add_Ratio")
                                                emgI.Item("Dc") = "N"
                                                emgI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(5).ToString.Substring(0, 10)
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
                                                kidI.Item("Effect_Date") = UIPriceDS.Tables(0).Rows(i).Item(1).ToString.Substring(0, 10)
                                                kidI.Item("Main_Identity_Id") = UIPriceDS.Tables(0).Rows(i).Item(0).ToString.Trim
                                                kidI.Item("Pt_From_Id") = ""
                                                kidI.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
                                                kidI.Item("Age_Type_Id") = "2"
                                                kidI.Item("Dc") = "N"
                                                kidI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(5).ToString.Substring(0, 10)
                                                kidI.Item("Create_User") = loginUser
                                                kidI.Item("Create_Time") = Date.Now

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
                                            dentalI.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
                                            dentalI.Item("Dental_Add_Ratio") = pvtAddDT.Rows(0).Item("Dental_Add_Ratio").ToString.Trim
                                            dentalI.Item("Dc") = "N"
                                            dentalI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(5).ToString.Trim
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
                                                deptI.Item("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
                                                deptI.Item("Dept_Add_Ratio") = pvtAddDT.Rows(0).Item("Dept_Add_Ratio").ToString.Trim
                                                deptI.Item("Dc") = "N"
                                                deptI.Item("End_Date") = UIPriceDS.Tables(0).Rows(i).Item(5).ToString.Trim
                                                deptI.Item("Create_User") = loginUser
                                                deptI.Item("Create_Time") = Date.Now

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

                            If (Not (CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.DC)), String).Trim.Equals("Y") AndAlso _
                                     CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Is_New)), String).Trim.Equals("Y"))) AndAlso _
                                     (Not IsDBNull(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)))) AndAlso _
                                     (CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Length > 0) Then

                                Dim mianId As String = CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim


                                If CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Add_Order_Code)), String).Trim.Equals("Y") Then
                                    '群組醫令碼  PUB_Add_Order, PUB_Add_Order_Detail, PUB_Add_Option_Order
                                    'TODO  goHash = { rowKey ,   groupHash}
                                    ' groupHash = "AddOrderCodeDT", AddOrderDT 
                                    '             {AddOrderCode-GroupId, nexthash}

                                    ' nexthash = ["AddOrderDetail", AddOrderDetailDT], 
                                    '            ["AddOptionalOrder", GroupAlterHash = {OrderCode-AddOrderDetailNo, OrderAlterDataDT}]


                                    'addorder欄位, query, 更新手上的, 刪除all, insert
                                    Dim rowKey As String = CType(UIPriceDS.Tables(0).Rows(i).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim


                                    '----------------------------------------------------------------------------------------
                                    '群組依令
                                    '----------------------------------------------------------------------------------------
                                    'AddOrderDT
                                    'AddOrderDtlDT
                                    'AddOptionOrderDT
                                    If goHash.ContainsKey(rowKey) Then

                                        Dim groupHash As Hashtable = CType(goHash.Item(rowKey), Hashtable)
                                        If groupHash IsNot Nothing AndAlso groupHash.ContainsKey("AddOrderCodeDT") Then
                                            Dim AddOrderCodeDT As DataTable = CType(groupHash.Item("AddOrderCodeDT"), DataTable)

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
                                                        newAddOrderDr.Item("Create_Time") = Date.Now
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
                                                            If nextHash.ContainsKey("AddOrderDetail") Then

                                                                Dim AddOrderDetailDT As DataTable = CType(nextHash.Item("AddOrderDetail"), DataTable)

                                                                Dim GroupAlterHash As New Hashtable
                                                                If nextHash.ContainsKey("AddOptionalOrder") Then
                                                                    GroupAlterHash = CType(nextHash.Item("AddOptionalOrder"), Hashtable)
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



                    '檢核有效日期
                    Dim strOldEffectDate1 As Date = CDate(Now.ToLongDateString) '自費/健保
                    Dim strOldEffectDate2 As Date = CDate(Now.ToLongDateString) '健保/自費

                    If GblPubOrderPrice IsNot Nothing AndAlso GblPubOrderPrice.Tables.Count > 0 AndAlso GblPubOrderPrice.Tables(0).Rows.Count > 0 Then
                        strOldEffectDate1 = GblPubOrderPrice.Tables(0).Rows(0).Item("Effect_Date")
                        If GblPubOrderPrice.Tables(0).Rows.Count > 1 Then
                            strOldEffectDate2 = GblPubOrderPrice.Tables(0).Rows(1).Item("Effect_Date")
                        End If
                    End If


                    Dim strEffectDate1 As Date = CDate(Now.ToLongDateString)
                    Dim strEffectDate2 As Date = CDate(Now.ToLongDateString)

                    If OrderRelatedDS IsNot Nothing AndAlso OrderRelatedDS.Tables.Count >= 4 AndAlso OrderRelatedDS.Tables(3).Rows.Count > 0 Then
                        strEffectDate1 = OrderRelatedDS.Tables(3).Rows(0).Item("Effect_Date")
                        If OrderRelatedDS.Tables(3).Rows.Count > 1 Then
                            strEffectDate2 = OrderRelatedDS.Tables(3).Rows(1).Item("Effect_Date")
                        End If
                    End If

                    If (strOldEffectDate1 > strEffectDate1 OrElse strOldEffectDate2 > strEffectDate2) Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"有效日期不得小於今日"}, "")
                        Exit Function
                    ElseIf ((strOldEffectDate1 < CDate(Now.ToLongDateString) OrElse strOldEffectDate2 < CDate(Now.ToLongDateString)) AndAlso ((CDate(Now.ToLongDateString) > strEffectDate1 AndAlso strOldEffectDate1 <> strEffectDate1) _
                           OrElse (CDate(Now.ToLongDateString) > strEffectDate2) AndAlso strOldEffectDate2 <> strEffectDate2)) Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"有效日期不得小於今日"}, "")
                        Exit Function
                    End If

                    If OrderRelatedDS.Tables.Contains("updateorder") Then
                        Dim commitResult As Integer = pub.commitOrderRelatedData(OrderRelatedDS)

                        If commitResult = 1 Then
                            'MessageHandling.showInfoByKey("CMMCMMB005")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB301", New String() {"儲存"})

                            'add by 唐子晴 2013.11.25==========================================================
                            MessageBox.Show("儲存成功", "CMMCMMB002", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                            '==================================================================================
                        ElseIf commitResult = -1 Then
                            'MessageHandling.showErrorByKey("CMMCMMD005")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB302", New String() {"儲存"})
                        Else
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令已被停用，且生效日必須大於" & commitResult}, "")
                        End If

                    ElseIf OrderRelatedDS.Tables.Contains("insertorder") Then
                        'add by 唐子晴 2013.11.25==========
                        '  btn_Confirm.Enabled = False
                        '==================================
                        Dim commitResult As Integer = pub.commitOrderRelatedData(OrderRelatedDS)

                        If commitResult = 1 Then
                            'MessageHandling.showInfoByKey("CMMCMMB002")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB002", New String() {})

                            'add by 唐子晴 2013.11.25=======================
                            MessageBox.Show("新增成功", "CMMCMMB002", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, False)
                            Clear()
                            '===============================================
                        ElseIf commitResult = -1 Then
                            'MessageHandling.showErrorByKey("CMMCMMD002")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB302", New String() {"儲存"})
                        Else
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該醫令已被停用，且生效日必須大於" & commitResult}, "")
                        End If
                        'add by 唐子晴 2013.11.25========
                        ' btn_Confirm.Enabled = True
                        '================================
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
        PUBMaterialUI_ucl_txtcq_ordercode.Text = ""
        txt_NhiCode.Text = ""
        txt_Name.Text = ""
        txt_ZhName.Text = ""
        txt_SCName.Text = ""
        txt_EnName.Text = ""
        txt_SEName.Text = ""
        txt_OrederNote.Text = ""

        txt_NhiCode.Text = ""
        txt_Name.Text = ""

        uclcomb_OrderType.SelectedIndex = 1
        'mark by 唐子晴 2013.11.25============
        ''uclcomb_HosItem.SelectedIndex = -1
        '=====================================
        txt_format.Text = ""
        txt_purchaseprice.Text = ""
        'mark by 唐子晴 2013.11.25============
        ''txt_ChargeUnit.Text = ""
        ''txt_ClaimUnit.Text = ""
        '=====================================
        txt_Note.Text = ""
        txt_Note.Text = ""
        'mark by 唐子晴 2013.11.25============
        ''txt_Flag.Text = ""
        '=====================================

        txt_purchaseunit.Text = ""
        txt_chargetransclaim.Text = "1"
        txt_storagetype.Text = ""

        cb_Dc.Checked = False

        ucl_mat_use_cnt.Text = ""
        'cb_incorder_mark.Checked = False
        txt_IncludeOrder.Text = ""

        ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))
        uclcb_classify.SelectedIndex = -1

        lb_Nhi_Name.Text = ""

        Dim OrderPriceDT As DataTable = DataSetUtil.createDataTable("orderprice", Nothing, OrderPriceColumn, OrderPriceColumnType)
        updateGridView(OrderPriceDT)

        GridSelectedIndexList.Clear()


        ucl_dtp_enddate.SetValue(defaultEndDate)

        cb_pricehistory.Checked = False
        ucldgv_OrderPrice.Enabled = True

        '2010-04-29 Add By Alan
        'cb_OPD.Checked = False
        'cb_EMG.Checked = False
        'cb_IPD.Checked = False
        cbo_OPD.SelectedValue = "Y"
        cbo_EMG.SelectedValue = "Y"
        cbo_IPD.SelectedValue = "Y"

        'add by 唐子晴 2013.11.25============
        ucl_Flag.Text = ""
        uclcomb_HosItem.SelectedIndex = 14
        txt_ChargeUnit.Text = "EA"
        txt_ClaimUnit.Text = "EA"
        '=====================================
        'add by 唐子晴 2013.12.12-------------
        ucl_PriceAdjustment.Text = ""
        '-------------------------------------

        cb_preview.Checked = False
        txt_Brand.Text = ""

        addNewGridRow()

        PUBMaterialUI_ucl_txtcq_ordercode.Focus()

        '2011-07-14 Add By Alan
        '判斷登入角色若為Pub_M_Maintain,則不允許按確定與刪除Button
        'If Not AppContext.userProfile.userMemberOf.Contains("Pub_M_Maintain") Then
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
    Private Sub btn_NhiProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NHI As PUBCureControlUI = New PUBCureControlUI("curecontrol", NhiSyscodeDT, cureControlDT)

        Dim nhiResult As Boolean = NHI.ShowAndPrepareReturnData()
        If nhiResult Then
            cureControlDT = NHI.CureControlData
        End If
    End Sub

  
    ''' <summary>
    ''' 醫令項目費用
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucldgv_OrderPrice_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim orderCode As String = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim

        If orderCode.Length > 0 AndAlso DataSetUtil.IsContainsData(ucldgv_OrderPrice.GetDBDS) AndAlso checkGridRowHasData(False, e.RowIndex) Then

            If GridSelectedIndexList.Count > 0 Then
                'Dim GridDT As DataTable = ucldgv_OrderPrice.GetDBDS.Tables(0).Copy
                'updateGridView(GridDT)

                For i As Integer = 0 To (GridSelectedIndexList.Count - 1)
                    ucldgv_OrderPrice.SetRowColor(CType(GridSelectedIndexList.Item(i), Integer), System.Drawing.Color.White)
                Next

                GridSelectedIndexList.Clear()
            End If


            'Dim OrderCode As String = ucl_txtcq_ordercode.Text.Trim
            Dim MainID As String = CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim

            Select Case e.ColumnIndex
             
                Case PUB_Order_Price.Add_Order_Code
                    If (Not IsDBNull(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)))) AndAlso CType(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item(OrderPriceColumn(PUB_Order_Price.Main_Identity_Id)), String).Trim.Length > 0 Then

                      
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
        If uclcb_classify.SelectedValue = "2" OrElse uclcb_classify.SelectedValue = "3" OrElse _
           uclcb_classify.SelectedValue = "4" OrElse uclcb_classify.SelectedValue = "5" OrElse _
           uclcb_classify.SelectedValue = "6" Then
            btn_SelfpayApply_Click(New System.Object, New EventArgs)
        End If
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

        'add by 唐子晴 2013.11.25=======
        txt_ChargeUnit.Text = "EA"
        txt_ClaimUnit.Text = "EA"
        '===============================
        'add by 唐子晴 2013.12.12-------
        ucl_PriceAdjustment.Text = ""
        '-------------------------------

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

    ''' <summary>
    ''' grid增加新row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_AddNewRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        addNewGridRow()
    End Sub

    '------------------------------------------------------------------------------------------
    '離開TextCodeQuery後查出資料? 查出後動作
    '------------------------------------------------------------------------------------------

    'Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager
    'Dim mainDS, mainDS2 As New DataSet

    'Private Sub doUcrOpenWindowValue2(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowValue2

    '    If uclName IsNot Nothing AndAlso uclName.Equals("PUBOrderMaterialUIucl_txtcq_ordercode") Then
    '        If DataSetUtil.IsContainsData(ds) Then
    '            '確實有醫令,才查詢
    '            ucl_txtcq_ordercode.Text = CType(ds.Tables(0).Rows(0).Item(0), String).Trim
    '            query(False)
    '        Else
    '            '不動作
    '        End If
    '    End If

    'End Sub

    '------------------------------------------------------------------------------------------
    'TextCodeQuery 結束
    '------------------------------------------------------------------------------------------


#End Region

    Private Sub btn_PreRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PreRecord.Click
        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            Dim OrderCode As String = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
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

            Clear()
            OrderRelatedDataToUI(OrderDS, False)
        End If
    End Sub

    Private Sub btn_NextRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NextRecord.Click
        If checkQueryKey() Then
            GridSelectedIndexList.Clear()

            Dim OrderCode As String = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim
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

            Clear()
            OrderRelatedDataToUI(OrderDS, False)
        End If
    End Sub


    Private Sub ucldgv_OrderPrice_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellEnter

        gblCellColumnIndex = e.ColumnIndex
        gblCellRowIndex = e.RowIndex
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


    Private Sub ucldgv_OrderPrice_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucldgv_OrderPrice.CellValueChanged
        Dim pvtSelectedRow As Integer
        Dim pvtTotalRow As Integer

        Select Case e.ColumnIndex
            Case PUB_Order_Price.Add_Price
                Exit Sub
            Case PUB_Order_Price.Main_Identity_Id
                If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count > 0 Then
                    If ucldgv_OrderPrice.GetSelectedRowsIndex <> "" Then
                        pvtSelectedRow = CInt(ucldgv_OrderPrice.GetSelectedRowsIndex)
                        pvtTotalRow = ucldgv_OrderPrice.Rows.Count
                    Else
                        Exit Sub
                    End If

                    If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(PUB_Order_Price.Main_Identity_Id).ToString.Trim <> "" Then
                        For i = 0 To pvtTotalRow - 1
                            If i <> pvtSelectedRow AndAlso _
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(PUB_Order_Price.Main_Identity_Id).ToString.Trim = _
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(i).Item(PUB_Order_Price.Main_Identity_Id).ToString.Trim Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"該主身分已存在"}, "")


                                ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(pvtSelectedRow).Item(PUB_Order_Price.Main_Identity_Id) = ""
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtSelectedRow).Item(PUB_Order_Price.Main_Identity_Id) = ""
                                ucldgv_OrderPrice.Rows(pvtSelectedRow).Cells(PUB_Order_Price.Main_Identity_Id).Value = ""

                                Exit Sub
                            End If
                        Next
                        'ucldgv_OrderPrice.AddNewRow()
                        If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtTotalRow - 1).Item(PUB_Order_Price.Main_Identity_Id).ToString.Trim <> "" Then
                            If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtTotalRow - 1).Item(PUB_Order_Price.Main_Identity_Id).ToString.Trim = "2" Then
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtTotalRow - 1).Item(PUB_Order_Price.Insu_Account_Id) = "50"
                                ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(pvtTotalRow - 1).Item(PUB_Order_Price.Insu_Order_Type_Id) = "3"
                            End If
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

                'Add by 唐子晴 2013.11.25======================================================
            Case PUB_Order_Price.Insu_Apply_Price
                Dim userKeyInsuApplyPrice As String
                Dim price As Double
                Dim addPrice As Double

                Dim mainId As Integer

                If ucldgv_OrderPrice.GetGridDS.Tables(0).Rows.Count > 0 Then

                    'add by 唐子晴 2014.01.13---------------------------------
                    If PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim.ToUpper.Substring(0, 1) = "Q" Then
                        Return
                    End If
                    '-------------------------------------------------------
                    mainId = Convert.ToInt32(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Main_Identity_Id).ToString().Trim())
                    Select Case mainId
                        Case 1
                            '主身份:自費  user input:健保核定價格
                            userKeyInsuApplyPrice = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Insu_Apply_Price).ToString()
                            Select Case ucl_Flag.SelectedValue
                                Case "B"
                                    If memo_OrderMemo.Text.Trim() <> "" And InStr(memo_OrderMemo.Text.Trim(), "科部建議價格", CompareMethod.Text) > 0 Then
                                        Dim idx1 As Integer = memo_OrderMemo.Text.Trim().IndexOf("科部建議價格")
                                        Dim idx2 As Integer = memo_OrderMemo.Text.Trim().IndexOf("元")

                                        idx1 = idx1 + 6
                                        price = Convert.ToDecimal(memo_OrderMemo.Text.Trim().Substring(idx1, (idx2 - idx1)))
                                    Else
                                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"科部建議價格"}, "")
                                    End If
                                Case "C"
                                    price = userKeyInsuApplyPrice * 1.5
                                Case ""
                                    'modify by 唐子晴 2014.01.21-----------------------------------------------------
                                    'If userKeyInsuApplyPrice <= 50 Then
                                    '    price = userKeyInsuApplyPrice * 1.8
                                    'ElseIf userKeyInsuApplyPrice >= 51 And userKeyInsuApplyPrice <= 100 Then
                                    '    price = userKeyInsuApplyPrice * 1.5
                                    'ElseIf userKeyInsuApplyPrice >= 101 And userKeyInsuApplyPrice <= 5000 Then
                                    '    price = userKeyInsuApplyPrice * 1.3
                                    'ElseIf userKeyInsuApplyPrice >= 5001 Then
                                    '    price = userKeyInsuApplyPrice * 1.2
                                    'End If
                                    If userKeyInsuApplyPrice <= 100 Then
                                        price = userKeyInsuApplyPrice * 1.8
                                    ElseIf userKeyInsuApplyPrice >= 101 And userKeyInsuApplyPrice <= 1000 Then
                                        price = userKeyInsuApplyPrice * 1.6
                                    ElseIf userKeyInsuApplyPrice >= 1001 And userKeyInsuApplyPrice <= 5000 Then
                                        price = userKeyInsuApplyPrice * 1.5
                                    ElseIf userKeyInsuApplyPrice >= 5001 Then
                                        price = userKeyInsuApplyPrice * 1.2
                                    End If
                                    '--------------------------------------------------------------------------------
                            End Select

                            'modify by 唐子晴 2013.12.11 ------------------------------------------------------------------
                            ''ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(PUB_Order_Price.Price).Value = price.ToString()
                            ''ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = price.ToString()
                            ''ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = price.ToString()
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(PUB_Order_Price.Price).Value = Math.Round(price, 1).ToString()
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = Math.Round(price, 1).ToString()
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = Math.Round(price, 1).ToString()
                            '-----------------------------------------------------------------------------------------------


                        Case 2
                            '主身份:健保  user input:健保核定價格 
                            userKeyInsuApplyPrice = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Insu_Apply_Price).ToString()
                            If userKeyInsuApplyPrice <= 29999 Then
                                price = userKeyInsuApplyPrice * 1.05
                            ElseIf userKeyInsuApplyPrice >= 30000 Then
                                price = userKeyInsuApplyPrice + 1500
                            End If

                            'modify by 唐子晴 2014.01.21-----------------------------------------------------------------
                            'If userKeyInsuApplyPrice <= 5000 Then
                            '    addPrice = userKeyInsuApplyPrice * 1.3
                            '    'modify by 唐子晴 2014.01.02------------
                            '    'If price >= 4165 Then
                            '    If userKeyInsuApplyPrice >= 4165 Then
                            '        '---------------------------------------
                            '        addPrice = userKeyInsuApplyPrice + 1250
                            '    End If
                            'ElseIf userKeyInsuApplyPrice >= 5001 And userKeyInsuApplyPrice <= 30000 Then
                            '    addPrice = userKeyInsuApplyPrice * 1.25
                            '    If userKeyInsuApplyPrice >= 24000 Then
                            '        addPrice = userKeyInsuApplyPrice + 6000
                            '    End If
                            'ElseIf userKeyInsuApplyPrice >= 30001 And userKeyInsuApplyPrice <= 50000 Then
                            '    addPrice = userKeyInsuApplyPrice * 1.2
                            '    If userKeyInsuApplyPrice >= 37500 Then
                            '        addPrice = userKeyInsuApplyPrice + 7500
                            '    End If
                            'ElseIf userKeyInsuApplyPrice >= 50001 Then
                            '    addPrice = userKeyInsuApplyPrice * 1.15
                            '    If userKeyInsuApplyPrice >= 133330 Then
                            '        addPrice = userKeyInsuApplyPrice + 20000
                            '    End If
                            'End If
                            If userKeyInsuApplyPrice <= 100 Then
                                addPrice = userKeyInsuApplyPrice * 1.8
                            ElseIf userKeyInsuApplyPrice >= 101 And userKeyInsuApplyPrice <= 1000 Then
                                addPrice = userKeyInsuApplyPrice * 1.6
                            ElseIf userKeyInsuApplyPrice >= 1001 And userKeyInsuApplyPrice <= 5000 Then
                                addPrice = userKeyInsuApplyPrice * 1.5
                            ElseIf userKeyInsuApplyPrice >= 5001 Then
                                addPrice = userKeyInsuApplyPrice * 1.2
                            End If
                            '----------------------------------------------------------------------------------------------

                            'modify by 唐子晴 2013.12.11 ------------------------------------------------------------------
                            ''ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(PUB_Order_Price.Price).Value = price.ToString()
                            ''ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = price.ToString()
                            ''ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = price.ToString()

                            ''ucldgv_OrderPrice.Rows(gblCellRowIndex - 1).Cells(PUB_Order_Price.Price).Value = addPrice.ToString()
                            ''ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex - 1).Item(PUB_Order_Price.Price) = addPrice.ToString()
                            ''ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex - 1).Item(PUB_Order_Price.Price) = addPrice.ToString()
                            ucldgv_OrderPrice.Rows(gblCellRowIndex).Cells(PUB_Order_Price.Price).Value = Math.Round(price, 1).ToString()
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = Math.Round(price, 1).ToString()
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex).Item(PUB_Order_Price.Price) = Math.Round(price, 1).ToString()

                            ucldgv_OrderPrice.Rows(gblCellRowIndex - 1).Cells(PUB_Order_Price.Price).Value = Math.Round(addPrice, 1).ToString()
                            ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(gblCellRowIndex - 1).Item(PUB_Order_Price.Price) = Math.Round(addPrice, 1).ToString()
                            ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(gblCellRowIndex - 1).Item(PUB_Order_Price.Price) = Math.Round(addPrice, 1).ToString()
                            '-----------------------------------------------------------------------------------------------

                    End Select

                End If
                '============================================================================





            Case 14  '判斷健保碼所對應到的急診加成、兒童加成、牙科加成、科別加成
                Dim strInsuCode As String = ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item("健保碼").ToString.Trim
                Dim pvtReturnData As New DataTable
                pvtReturnData = pub.queryPubNhiCodeEffectData(DateUtil.SystemDate("yyyy/MM/dd"), strInsuCode, PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim)

                If pvtReturnData.Rows.Count > 0 AndAlso strInsuCode <> "" Then

                    ucldgv_OrderPrice.Rows(e.RowIndex).Cells(6).Value = IIf(pvtReturnData.Rows(0).Item("Is_Emg_Add").ToString.Trim = "Y", True, False)
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item("急件加成") = pvtReturnData.Rows(0).Item("Is_Emg_Add")
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item("急件加成") = pvtReturnData.Rows(0).Item("Is_Emg_Add")

                    ucldgv_OrderPrice.Rows(e.RowIndex).Cells(7).Value = IIf(pvtReturnData.Rows(0).Item("Is_Kid_Add").ToString.Trim = "Y", True, False)
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item("兒童加成") = pvtReturnData.Rows(0).Item("Is_Kid_Add")
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item("兒童加成") = pvtReturnData.Rows(0).Item("Is_Kid_Add")

                    ucldgv_OrderPrice.Rows(e.RowIndex).Cells(8).Value = IIf(pvtReturnData.Rows(0).Item("Is_Dental_Add").ToString.Trim = "Y", True, False)
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item("牙科加成") = pvtReturnData.Rows(0).Item("Is_Dental_Add")
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item("牙科加成") = pvtReturnData.Rows(0).Item("Is_Dental_Add")

                    ucldgv_OrderPrice.Rows(e.RowIndex).Cells(9).Value = IIf(pvtReturnData.Rows(0).Item("Is_Dept_Add").ToString.Trim = "Y", True, False)
                    ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(e.RowIndex).Item("科別加成") = pvtReturnData.Rows(0).Item("Is_Dept_Add")
                    ucldgv_OrderPrice.GetGridDS.Tables(0).Rows(e.RowIndex).Item("科別加成") = pvtReturnData.Rows(0).Item("Is_Dept_Add")

                End If

        End Select
    End Sub

    Private Sub PUBMaterialUI_ucl_txtcq_ordercode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PUBMaterialUI_ucl_txtcq_ordercode.Leave
        Dim str_temp As String = PUBMaterialUI_ucl_txtcq_ordercode.Text
        If PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1.Trim <> "" Then
            query(True)
        End If
        PUBMaterialUI_ucl_txtcq_ordercode.Text = str_temp
    End Sub

    Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Select Case uclName
            Case Me.Name & "PUBMaterialUI_ucl_txtcq_ordercode"
                PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1 = uclCodeValue1.Trim
                PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue2 = uclCodeValue2.Trim
                PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName = uclCodeName.Trim
                PUBMaterialUI_ucl_txtcq_ordercode.Text = uclCodeValue1.Trim
                query(True)
        End Select

    End Sub

    Private Sub doUcrOpenWindowValue2(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowValue2

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Select Case uclName
                Case Me.Name & "PUBMaterialUI_ucl_txtcq_ordercode", "tbp_Condition" & "PUBMaterialUI_ucl_txtcq_ordercode"
                    PUBMaterialUI_ucl_txtcq_ordercode.Text = ds.Tables(0).Rows(0).Item("醫令項目代碼").ToString.Trim
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1 = ds.Tables(0).Rows(0).Item("醫令項目代碼").ToString.Trim
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName = ds.Tables(0).Rows(0).Item("英文名稱").ToString.Trim
                    ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))

                    If PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1.Trim <> "" Then
                        query(True)
                    End If

            End Select
        Else
            Select Case uclName
                Case Me.Name & "PUBMaterialUI_ucl_txtcq_ordercode", "tbp_Condition" & "PUBMaterialUI_ucl_txtcq_ordercode"
                    'PUBOrderUI_ucl_txtcq_ordercode.Text = ""
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1 = ""
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue2 = ""
                    PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName = ""
                    ucldtp_EffectDate.SetValue(SystemDate.ToString("yyyy/MM/dd"))
                    txt_chargetransclaim.Text = "1"
            End Select
        End If

    End Sub

    Private Sub cb_Dc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Dc.CheckedChanged
        If cb_Dc.Checked Then
            ucl_dtp_enddate.SetValue(Date.Parse(SystemDate.ToString("yyyy/MM/dd")))
            'add by 唐子晴 2014.01.27-----
            cbo_OPD.SelectedValue = "N"
            cbo_EMG.SelectedValue = "N"
            cbo_IPD.SelectedValue = "N"
            '-----------------------------
        Else
            ucl_dtp_enddate.SetValue(DateUtil.GetTwYear("2910/12/31"))
            'add by 唐子晴 2014.02.18 --
            cbo_OPD.SelectedValue = "Y"
            cbo_EMG.SelectedValue = "Y"
            cbo_IPD.SelectedValue = "Y"
            '---------------------------
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

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        deleteOrder()
    End Sub

    Private Sub deleteOrder()
        If (PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim <> "" AndAlso MessageHandling.ShowQuestionMsg("CMMCMMB303", New String() {"刪除"}) = Windows.Forms.DialogResult.Yes) Then
            Dim pvtResult As Integer

            Try
                'add by 唐子晴 2014.02.06 -----------------------------------------------------------------------------------------------------------------------------------
                Dim pvtLogResult = pub.deletePUBOrderLog(PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim, txt_ZhName.Text.Trim, AllowOrderTypeId(0), AllowOrderMode(0), loginUser)
                '------------------------------------------------------------------------------------------------------------------------------------------------------------
                pvtResult = pub.deletePUBOrderByOrderCode(PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim)

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
        If chk_OrderHistory.Checked Then
            'btn_Confirm.Enabled = False
            'btn_Delete.Enabled = False
            btn_PreRecord_Click(sender, e)
        End If
    End Sub

    Private Sub txt_ClaimUnit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ClaimUnit.Leave
        If txt_ChargeUnit.Text.Trim = "" Then
            txt_ChargeUnit.Text = txt_ClaimUnit.Text.Trim
        End If
    End Sub

    Private Sub btn_AddQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddQuery.Click
        If Me.PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1 <> "" Then
            Dim pubAddQuery As New PUBAddQueryUI(PUBMaterialUI_ucl_txtcq_ordercode.uclCodeValue1, PUBMaterialUI_ucl_txtcq_ordercode.uclCodeName)
            pubAddQuery.ShowDialog()
        End If
    End Sub

    Private Sub btn_SelfpayApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelfpayApply.Click


        Dim DgvShowDataDs As New DataSet
        Dim returnTable As New DataTable
      
        returnTable.Columns.Add("Order_Code")
        returnTable.Columns.Add("Effect_Date")

        Dim drSave As DataRow = returnTable.NewRow()

        drSave("Order_Code") = PUBMaterialUI_ucl_txtcq_ordercode.Text.Trim

        drSave("Effect_Date") = ucldtp_EffectDate.GetUsDateStr

        returnTable.Rows.Add(drSave)

        DgvShowDataDs.Tables.Add(returnTable.Copy)

        Dim PUBMaterialSelfpayApplyUI As New PUBMaterialSelfpayApplyUI()
        PUBMaterialSelfpayApplyUI.SeleDsPUBMaterialSelfpayApplyShow = DgvShowDataDs
        PUBMaterialSelfpayApplyUI.ShowDialog()
     
    End Sub

    'add by 唐子晴 2013.11.25==========================================
    Private Sub btn_OrderRemark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OrderRemark.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("醫令備註", txt_Note.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_Note.Text = pvtOpen.pvtContent
    End Sub
    '=================================================================
    'add by 唐子晴 2013.12.11-------------------------------------------
    Private Sub uclcb_classify_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uclcb_classify.SelectedIndexChanged
        If uclcb_classify.SelectedValue = "7" Then
            txt_IncludeOrder.Text = "A"
        Else
            txt_IncludeOrder.Text = ""
        End If
    End Sub

    Private Sub ucl_Flag_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucl_Flag.SelectedIndexChanged
        Dim ret As Integer
        If ucl_Flag.SelectedValue = "B" Then
            Dim price As Integer
            price = InStr(memo_OrderMemo.Text.Trim(), "科部建議價格")

            If price <= 0 Then
                memo_OrderMemo.Text = memo_OrderMemo.Text.Trim + "科部建議價格 元"
            Else
                memo_OrderMemo.Text = memo_OrderMemo.Text.Trim
            End If

        Else
            If memo_OrderMemo.Text <> "" Then
                ret = memo_OrderMemo.Text.Trim.LastIndexOf("科部建議價格")
                memo_OrderMemo.Text = memo_OrderMemo.Text.Trim.Substring(0, ret)
            Else
                memo_OrderMemo.Text = ""
            End If

        End If
    End Sub
    '--------------------------------------------------------------------
#Region "    將健保與自費日期變一致 "

    Private Sub ucldgv_OrderPrice_CellValueChanged(sender As Object, e As EventArgs) Handles ucldgv_OrderPrice.CellValueChanged
        Try

            If ucldgv_OrderPrice.GetDBDS.Tables(0).Rows.Count = 2 Then

                '將健保或自費的生效日變成一致
                If ucldgv_OrderPrice.CurrentCellAddress.X = 1 Then

                    ucldtp_EffectDate.SetValue(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(0).Item(OrderPriceColumn(1)))
                    ' TransDateSame()

                ElseIf ucldgv_OrderPrice.CurrentCellAddress.X = 5 Then '將健保或自費的到期日變成一致
                    ucl_dtp_enddate.SetValue(ucldgv_OrderPrice.GetDBDS.Tables(0).Rows(0).Item(OrderPriceColumn(5)))
                    ' TransDateSame()

                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub TransDateSame()
        Try
            Dim GridDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

            For i = 0 To GridDS.Tables(0).Rows.Count - 1
                GridDS.Tables(0).Rows(i).Item(OrderPriceColumn(5)) = ucl_dtp_enddate.GetUsDateStr
            Next

            ucldgv_OrderPrice.Visible = False
            ucldgv_OrderPrice.SetDS(GridDS)
            ucldgv_OrderPrice.Visible = True
        Catch ex As Exception
            '丟出錯誤訊息，並記錄到DB
            Throw New CommonException("CMMCMMB300", ex, New String() {"轉日期"})
        End Try


    End Sub

#End Region

#Region "    根據自費健保選項變更計價註記"

    Private Sub ucldgv_OrderPrice_CurrentCellChanged(sender As Object, e As EventArgs) Handles ucldgv_OrderPrice.CurrentCellChanged
        If ucldgv_OrderPrice.CurrentCellAddress.Y >= 0 Then
            If StringUtil.nvl(ucldgv_OrderPrice.Rows(ucldgv_OrderPrice.CurrentCellAddress.Y).Cells("主身分").Value) = "健保" Then

                cbo_ChargeFlagCell.DisplayIndex = "1"
                cbo_ChargeFlagCell.ValueIndex = "1"

            ElseIf StringUtil.nvl(ucldgv_OrderPrice.Rows(ucldgv_OrderPrice.CurrentCellAddress.Y).Cells("主身分").Value) = "自費" Then

                cbo_ChargeFlagCell.DisplayIndex = "0"
                cbo_ChargeFlagCell.ValueIndex = "0"

            End If
        End If
    End Sub

#End Region

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

        ElseIf cb_Dc.Checked = False Then

            Try
                Dim GridDS As DataSet = ucldgv_OrderPrice.GetDBDS.Copy

                For i = 0 To GridDS.Tables(0).Rows.Count - 1
                    GridDS.Tables(0).Rows(i).Item(OrderPriceColumn(5)) = "2910/12/31"
                Next

                ucldgv_OrderPrice.Visible = False
                ucldgv_OrderPrice.SetDS(GridDS)
                ucldgv_OrderPrice.Visible = True
            Catch ex As Exception
                '丟出錯誤訊息，並記錄到DB
                Throw New CommonException("CMMCMMB300", ex, New String() {"轉日期"})
            End Try
        End If

    End Sub

    

#End Region

  
End Class
