Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

'Imports nckuh.server.pub

'============================
'程式說明：檢核規則維護
'修改日期：2009.11.26
'修改日期：2009.11.26
'開發人員：Jen
'============================

Public Class PUBRuleCheckUI

    Public Sub New(ByVal inputInitRuleCode As String)
        initSRuleCode = inputInitRuleCode
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

    Public Sub New(ByVal inputInitRuleCode As String, ByVal Order_code As String)
        initSRuleCode = inputInitRuleCode
        initSOrderCode = Order_code
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        Me.source = "2"
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

#Region "列舉型別  2013-11-26  黃富昌"

    Public Enum EnumTransactionMode
        儲存 = 1
        刪除 = 2
    End Enum

#End Region

#Region "########## 宣告物件 ##########"

    Dim IsDgvCheckReasonInitial As Boolean = False

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance
    Dim source As String = ""
    Dim ErrorKeyFlag As Boolean = False

    Dim loginUser As String = AppContext.userProfile.userId
    Dim systemDate As Date = Syscom.Comm.Utility.DateUtil.getSystemDate
    Dim ifuserorCreate As Boolean = False

    Dim initSRuleCode As String = ""
    Dim initSOrderCode As String = ""

    Dim ValueDataColumn() As String = {"Old_Rule_Code", "Value_Data", "Valid_Date_S"}
    Dim ValueDataColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ItemColumn() As String = {"Item_Code", "Item_Name"}
    Dim ItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim QueryRuleColumn() As String = {"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E", "Value_Data"}
    Dim QueryRuleColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}

    Dim PubItemColumn() As String = {"Item_Code", "Item_Name", "Data_Type", "Return_Checking_Flag"}
    Dim PubItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}


    Dim ItemParamColumn() As String = {"Item_Code", "Item_Param"}
    Dim ItemParamColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim RuleDetailColumn() As String = {"檢查類別", "檢查項目", "Ｘ", "Ｙ", "Ｚ", "運算項目", "值域", "單位", "計算門診", "計算急診", "計算住院", "條件關係", "Seq_No", "Is_New", "Create_User", "Create_Time", "Rule_Maintain_Sn"}
    Dim gblRuleDetailColumn As String = "檢查類別,檢查項目,Ｘ,Ｙ,Ｚ,運算項目,值域,單位,計算門診,計算急診,計算住院,條件關係,Seq_No,Is_New,Create_User,Create_Time,Rule_Maintain_Sn"

    Dim RuleDetailColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDate, _
                                             DataSetUtil.TypeInteger}

    '檢核現制強度
    '0-不顯示任何訊息", "1-通知(顯示於訊息列)", "2-警告(提示使用者)", "3-錯誤(強制中斷)"
    Dim CheckLevelId() As String = {"0", "1", "2", "3"}
    Dim CheckLevelName() As String = {"不顯示任何訊息", "通知(顯示於訊息列)", "警告(提示使用者)", "錯誤(強制中斷)"}

    '檢核類別
    '"逐一檢核", "全面檢核"
    Dim CheckExeTypeId() As String = {"0", "1"}
    Dim CheckExeTypeName() As String = {"逐一檢核", "全面檢核"}

    '檢核對象伸分
    '"0-全部身分", "1-僅自費身分", "2-僅健保身分"
    Dim CheckIdentityId() As String = {"0", "1", "2"}
    Dim CheckIdentityName() As String = {"全部身分", "僅自費身分", "僅健保身分"}

    Dim CheckTypeId() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "K"}
    Dim CheckTypeName() As String = {"A.一般檢查項目", "B.療程檢查項目", "C.執行(申報)次數檢查項目", "D.醫師科診檢查項目", "E.病患基本資料檢查項目", "F.牙科檢查項目", "G.檢驗檢查(LIS)檢查項目", "H.用藥安全", "K.其他"}

    Dim ConditionRelationId() As String = {"AND", "OR"}
    Dim ConditionRelationName() As String = {"AND", "OR"}

    '符合定義的欄位
    Dim DefinedCheckinColumn() As String = {"Effect_Date", "End_Date"}
    Dim DefinedCheckinColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}


    Dim initRuleCode As String = ""
    Dim ruleCode As String = ""
    Dim hasRuleData As Boolean = False

    Dim belongHash As Hashtable = New Hashtable
    Dim checkItemClusterHash As Hashtable = New Hashtable 'type, itemdt
    Dim checkItemDataHash As Hashtable = New Hashtable 'itemcode, dr
    Dim operationhash As New Hashtable 'operationcode轉換
    Dim checkItemUnitHash As Hashtable = New Hashtable


    Dim valueUnitHash As Hashtable = New Hashtable

    Dim dataTypeHash As Hashtable = New Hashtable 'syscode 802

    Dim maxSeqNo As Integer = 0

    'rule
    Dim createUser As String = ""
    Dim createTimeStr As String = ""
    'initdetail
    Dim initcreateUser As String = ""
    Dim initcreateTimeStr As String = ""
    Dim initRuleMaintainSn As Integer = -1


    Dim ruleclassdr As DataRow = Nothing
    Dim successClassdr As DataRow = Nothing
    Dim faultclassdr As DataRow = Nothing

    Dim belongItemDT As DataTable
    Dim dialogItemDT As DataTable
    Dim selectedItemDT As DataTable

    Dim itemOperatorHash As New Hashtable

    '基本804運算元
    Dim operatorDT As DataTable
    Dim operatorHash As New Hashtable

    Dim ItemCodeList As ArrayList = New ArrayList

    Dim initConditionMsg As String = ""

    Dim ruleValidDateS As String = ""
    Dim ruleValidDateE As String = ""

    Dim queryItemDT As DataTable = Nothing

    Dim initialDataFlag As Boolean = True

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleCheckUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        'Add BY Elly 2016/05/23  --start
        Me.TabPage2.Parent = Nothing
        Me.TabPage4.Parent = Nothing
        '--end
        '開啟keypreview
        Me.KeyPreview = True
        Dim ds As DataSet = pub.RuleDynamicQuery("select   PIVU.Unit_Code ,PU.Unit_Name,PIVU.Item_Code  from PUB_Item_Value_Unit as PIVU  inner join PUB_Unit  as PU  on PU.Unit_Code =PIVU.Unit_Code   ORDER BY PIVU.Is_Default DESC")

        '關閉visible
        Me.tlp_frame.RowStyles.Item(2).Height = 0
        'Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))

        lb_init_belong.Text = ""
        ucl_txt_x.Text = ""
        lb_x.Enabled = False
        lb_x.Visible = False
        ucl_txt_x.Enabled = False
        ucl_txt_x.Visible = False
        btn_query.Visible = False
        rdo_isPrN.Checked = True
        If loginUser.Equals("") Then
            loginUser = "SYSTEM"
        End If

        '--------------------------------------------------------------------------------------------------------
        '固定資料
        '檢核強度
        Dim checkLevelDT As DataTable = DataSetUtil.GenDataTable("level", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (CheckLevelId.Count - 1)
            Dim checkdr As DataRow = checkLevelDT.NewRow
            checkdr.Item(ItemColumn(0)) = CheckLevelId(i)
            checkdr.Item(ItemColumn(1)) = CheckLevelName(i)
            checkLevelDT.Rows.Add(checkdr)
        Next

        '執行類別
        Dim checkExeTypeDT As DataTable = DataSetUtil.GenDataTable("exetype", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (CheckExeTypeId.Count - 1)
            Dim checkdr As DataRow = checkExeTypeDT.NewRow
            checkdr.Item(ItemColumn(0)) = CheckExeTypeId(i)
            checkdr.Item(ItemColumn(1)) = CheckExeTypeName(i)
            checkExeTypeDT.Rows.Add(checkdr)
        Next

        '檢核身分
        Dim checkIdentityDT As DataTable = DataSetUtil.GenDataTable("identity", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (CheckIdentityId.Count - 1)
            Dim checkdr As DataRow = checkIdentityDT.NewRow
            checkdr.Item(ItemColumn(0)) = CheckIdentityId(i)
            checkdr.Item(ItemColumn(1)) = CheckIdentityName(i)
            checkIdentityDT.Rows.Add(checkdr)
        Next

        '檢查項目類別
        Dim checkTypeDT As DataTable = DataSetUtil.GenDataTable("type", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (CheckTypeId.Count - 1)
            Dim checkdr As DataRow = checkTypeDT.NewRow
            checkdr.Item(ItemColumn(0)) = CheckTypeId(i)
            checkdr.Item(ItemColumn(1)) = CheckTypeName(i)
            checkTypeDT.Rows.Add(checkdr)
        Next

        '條件關係
        Dim relationDT As DataTable = DataSetUtil.GenDataTable("relation", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (ConditionRelationId.Count - 1)
            Dim relationdr As DataRow = relationDT.NewRow
            relationdr.Item(ItemColumn(0)) = ConditionRelationId(i)
            relationdr.Item(ItemColumn(1)) = ConditionRelationName(i)
            relationDT.Rows.Add(relationdr)
        Next

        '初始元件資料
        ucl_comb_res_strength.DataSource = checkLevelDT
        ucl_comb_res_strength.uclValueIndex = "0"
        ucl_comb_res_strength.uclDisplayIndex = "1"

        ucl_comb_exe_type.DataSource = checkExeTypeDT
        ucl_comb_exe_type.uclValueIndex = "0"
        ucl_comb_exe_type.uclDisplayIndex = "1"
        ucl_comb_exe_type.SelectedValue = ""

        ucl_comb_check_ident.DataSource = checkIdentityDT
        ucl_comb_check_ident.uclValueIndex = "0"
        ucl_comb_check_ident.uclDisplayIndex = "1"
        '--------------------------------------------------------------------------------------------------------


        '--------------------------------------------------------------------------------------------------------
        'init Rule資料
        Dim ItemDS As DataSet = pub.initPUBRuleCheckUIInfo()

        'systemDate
        If ItemDS.Tables.Contains("systemdate") Then
            systemDate = CType(ItemDS.Tables("systemdate").Rows(0).Item("System_Date"), Date)
        End If

        belongItemDT = DataSetUtil.GenDataTable("belong", Nothing, ItemColumn, ItemColumnType)

        selectedItemDT = DataSetUtil.GenDataTable("selected", Nothing, ItemColumn, ItemColumnType)

        Dim selectedParamItemDT As DataTable = DataSetUtil.GenDataTable("selectedparam", Nothing, ItemParamColumn, ItemParamColumnType)

        Dim unitDT As DataTable = DataSetUtil.GenDataTable("unit", Nothing, ItemColumn, ItemColumnType)
        operatorDT = DataSetUtil.GenDataTable("operator", Nothing, ItemColumn, ItemColumnType)


        If DataSetUtil.IsContainsData(ItemDS) Then
            'syscode
            'TODO
            If ItemDS.Tables.Contains(PubSyscodeDataTableFactory.tableName) Then
                Dim syscodeDT As DataTable = ItemDS.Tables(PubSyscodeDataTableFactory.tableName)
                '801,802,803,804
                Dim datatypeDr() As DataRow = syscodeDT.Select(" Type_Id = 802", "Code_Id")
                If datatypeDr IsNot Nothing AndAlso datatypeDr.Length > 0 Then
                    For Each dr As DataRow In datatypeDr
                        Dim key As String = CType(dr.Item("Code_Id"), String).Trim
                        If Not dataTypeHash.ContainsKey(key) Then
                            dataTypeHash.Add(key, CType(dr.Item("Code_En_Name"), String).Trim)
                        End If
                    Next
                End If

                Dim operandDr() As DataRow = syscodeDT.Select(" Type_Id = 804", "Code_Id")
                If operandDr IsNot Nothing AndAlso operandDr.Length > 0 Then
                    For Each dr As DataRow In operandDr
                        Dim newdr As DataRow = operatorDT.NewRow

                        Dim opeId As String = CType(dr.Item("Code_Id"), String).Trim
                        Dim opeName As String = CType(dr.Item("Code_Name"), String).Trim
                        Dim opeEname As String = CType(dr.Item("Code_En_Name"), String).Trim
                        newdr.Item(ItemColumn(0)) = opeId
                        newdr.Item(ItemColumn(1)) = opeName
                        If Not operatorHash.ContainsKey(opeId) Then
                            operatorHash.Add(opeId, opeName)
                        End If

                        If Not operationhash.ContainsKey(opeId) Then
                            operationhash.Add(opeId, opeEname)
                        End If


                        operatorDT.Rows.Add(newdr)
                    Next
                End If
            End If



            'unit
            If ItemDS.Tables.Contains(PubUnitDataTableFactory.tableName) Then
                For Each dr As DataRow In ItemDS.Tables(PubUnitDataTableFactory.tableName).Rows
                    Dim newdr As DataRow = unitDT.NewRow
                    newdr.Item(ItemColumn(0)) = CType(dr.Item("Unit_Code"), String).Trim
                    newdr.Item(ItemColumn(1)) = CType(dr.Item("Unit_Name"), String).Trim
                    unitDT.Rows.Add(newdr)
                Next
            End If

            'Value_Unit
            If ItemDS.Tables.Contains(PubItemValueUnitDataTableFactory.tableName) Then
                'valueUnitDT = ItemDS.Tables(PubItemValueUnitDataTableFactory.tableName)
            End If

            'other initdata

            If ItemDS.Tables.Contains(PubItemDataTableFactory.tableName) Then
                Dim ItemDT As DataTable = ItemDS.Tables(PubItemDataTableFactory.tableName)

                queryItemDT = ItemDS.Tables(PubItemDataTableFactory.tableName).Copy

                '偷藏pubitem
                dialogItemDT = DataSetUtil.GenDataTable("pubitem", Nothing, PubItemColumn, PubItemColumnType)

                If DataSetUtil.IsContainsData(ItemDT) Then
                    For Each dr As DataRow In ItemDT.Rows
                        If Not IsDBNull(dr.Item("Use_Type")) Then
                            Dim itemCode As String = CType(dr.Item(PubItemColumn(0)), String).Trim
                            Dim itemName As String = CType(dr.Item(PubItemColumn(1)), String).Trim
                            Dim dataType As String = CType(dr.Item(PubItemColumn(2)), String).Trim
                            Dim returnCheckinFlag As String = CType(dr.Item(PubItemColumn(3)), String).Trim
                            Dim useType As String = CType(dr.Item("Use_Type"), String).Trim

                            ItemCodeList.Add(itemCode)

                            'checkItemDataHash
                            If Not checkItemDataHash.ContainsKey(itemCode) Then
                                checkItemDataHash.Add(itemCode, dr)
                            Else
                                'contain..impossible
                            End If

                            Dim dialogitemdr As DataRow = dialogItemDT.NewRow
                            dialogitemdr.Item(PubItemColumn(0)) = itemCode
                            dialogitemdr.Item(PubItemColumn(1)) = itemName
                            dialogitemdr.Item(PubItemColumn(2)) = dataType
                            dialogitemdr.Item(PubItemColumn(3)) = returnCheckinFlag
                            dialogItemDT.Rows.Add(dialogitemdr)

                            If useType.Equals("000") Then
                                Dim bdr As DataRow = belongItemDT.NewRow
                                bdr.Item(ItemColumn(0)) = itemCode
                                bdr.Item(ItemColumn(1)) = itemName
                                belongItemDT.Rows.Add(bdr)

                                Dim sdr As DataRow = selectedItemDT.NewRow
                                sdr.Item(ItemColumn(0)) = itemCode
                                sdr.Item(ItemColumn(1)) = itemName
                                selectedItemDT.Rows.Add(sdr)

                            ElseIf useType.Equals("001") Then

                                Dim bdr As DataRow = belongItemDT.NewRow
                                bdr.Item(ItemColumn(0)) = itemCode
                                bdr.Item(ItemColumn(1)) = itemName
                                belongItemDT.Rows.Add(bdr)

                            ElseIf useType.Equals("002") Then

                                Dim sdr As DataRow = selectedItemDT.NewRow
                                sdr.Item(ItemColumn(0)) = itemCode
                                sdr.Item(ItemColumn(1)) = itemName
                                selectedItemDT.Rows.Add(sdr)

                            End If
                        End If
                    Next
                End If

            End If









            '歸屬
            'belongHash
            If DataSetUtil.IsContainsData(belongItemDT) Then
                For Each dr As DataRow In belongItemDT.Rows
                    Dim key As String = CType(dr.Item(ItemColumn(0)), String).Trim
                    '放入歸屬中
                    If Not belongHash.ContainsKey(CType(dr.Item(ItemColumn(0)), String).Trim) Then
                        belongHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                    End If
                Next
            End If

            'detail處
            If DataSetUtil.IsContainsData(selectedItemDT) Then
                For Each dr As DataRow In selectedItemDT.Rows
                    Dim key As String = CType(dr.Item(ItemColumn(0)), String).Trim

                    If key.Length > 0 Then

                        Dim typeKey As String = key.Substring(0, 1)
                        '放入檢查項目{typekey, dt} pair中

                        If checkItemClusterHash.ContainsKey(typeKey) Then
                            'append
                            Dim itemDT As DataTable = CType(checkItemClusterHash.Item(typeKey), DataTable)
                            itemDT.Rows.Add(dr.ItemArray)

                            checkItemClusterHash.Item(typeKey) = itemDT
                        Else
                            'new
                            Dim itemDT As DataTable = DataSetUtil.GenDataTable("item", Nothing, ItemColumn, ItemColumnType)

                            itemDT.Rows.Add(dr.ItemArray)

                            checkItemClusterHash.Add(typeKey, itemDT)
                        End If





                        If Not checkItemUnitHash.ContainsKey(key) Then
                            Dim ds1 As DataRow() = ds.Tables(0).Select("Item_Code='" + key + "'")
                            Dim copyds As DataTable = New DataTable
                            copyds.Columns.Add(ds.Tables(0).Columns(0).ColumnName)
                            copyds.Columns.Add(ds.Tables(0).Columns(1).ColumnName)

                            For i = 0 To ds1.Length - 1
                                Dim ros As DataRow = copyds.NewRow
                                For ii = 0 To copyds.Columns.Count - 1
                                    ros.Item(ii) = ds1(i).Item(ii)
                                Next
                                copyds.Rows.Add(ros)
                            Next
                            checkItemUnitHash.Add(key, copyds.Copy)
                        End If

                    End If
                Next
            End If

            '
            If ItemDS.Tables.Contains(PubItemOperatorDataTableFactory.tableName) Then
                Dim itemOperDT As DataTable = ItemDS.Tables(PubItemOperatorDataTableFactory.tableName)
                If ItemCodeList.Count > 0 Then
                    If DataSetUtil.IsContainsData(itemOperDT) Then
                        Dim itemopedr() As DataRow = Nothing
                        For i As Integer = 0 To (ItemCodeList.Count - 1)
                            Dim eachItemCode As String = CType(ItemCodeList.Item(i), String).Trim
                            itemopedr = itemOperDT.Select(" Item_Code = '" & eachItemCode & "'")
                            If itemopedr IsNot Nothing AndAlso itemopedr.Length > 0 Then
                                Dim eachItemOpeDT As DataTable = DataSetUtil.GenDataTable("itemoper", Nothing, ItemColumn, ItemColumnType)
                                For j As Integer = 0 To (itemopedr.Length - 1)
                                    If Not IsDBNull(itemopedr(j).Item("Operator_Code")) Then
                                        Dim eachopeCode As String = CType(itemopedr(j).Item("Operator_Code"), String).Trim
                                        If operatorHash.ContainsKey(eachopeCode) Then
                                            Dim eachopedr As DataRow = eachItemOpeDT.NewRow
                                            eachopedr.Item(ItemColumn(0)) = eachopeCode
                                            eachopedr.Item(ItemColumn(1)) = CType(operatorHash.Item(eachopeCode), String).Trim

                                            eachItemOpeDT.Rows.Add(eachopedr)
                                        End If

                                    End If
                                Next

                                If DataSetUtil.IsContainsData(eachItemOpeDT) Then
                                    If Not itemOperatorHash.ContainsKey(eachItemCode) Then
                                        itemOperatorHash.Add(eachItemCode, eachItemOpeDT)
                                    End If

                                End If
                            End If
                        Next
                    End If

                End If
                'itemOperatorHash
                'itemOperatorDT = ItemDS.Tables(PubItemOperatorDataTableFactory.tableName)
            End If

            ucl_comb_item_belong.DataSource = belongItemDT.Copy
            ucl_comb_item_belong.uclValueIndex = "0"
            ucl_comb_item_belong.uclDisplayIndex = "1"
            If Me.source.Equals("2") Then
                ucl_comb_item_belong.SelectedValue = "A00004"
                ucl_txt_belong_info.Text = Me.initSOrderCode

            End If


        End If


        '*****************************************************************************************************
        'init first Grid資料
        '*****************************************************************************************************
      
        Dim detailDS As DataSet = DataSetUtil.GenDataSet("detail", gblRuleDetailColumn.Split(","))
        Dim _hash As Hashtable = New Hashtable
        _hash.Add(-1, detailDS)

        '檢查類別
        Dim cmb_type_cell As New ComboBoxCell()
        '檢查項目
        Dim cmb_item_cell As New ComboBoxCell()
        '運算項目
        Dim cmb_oper_cell As New ComboBoxCell()
        '單位
        Dim cmb_unit_cell As New ComboBoxCell()
        '條件關係
        Dim cmb_rel_cell As New ComboBoxCell()
        '計算急診,計算住院,計算住院
        Dim cmb_cell As New ComboBoxCell()

        Dim valuetxt_cell As New TextBoxCell()
        Dim rangetxt_cell As New TextBoxCell()

        Dim popMsgCell As New UCLPopMemoUI

        Dim chk_cell As New CheckBoxCell()

        '----------------------------------------------------------------------

        '檢查類別
        Dim cmb_typeDS As New DataSet
        cmb_typeDS.Tables.Add(checkTypeDT.Copy)
        cmb_type_cell.Ds = cmb_typeDS
        cmb_type_cell.ValueIndex = "0"
        cmb_type_cell.DisplayIndex = "1"

        '檢查項目
        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(selectedItemDT.Copy)
        cmb_item_cell.Ds = cmb_itemDS
        cmb_item_cell.ValueIndex = "0"
        cmb_item_cell.DisplayIndex = "1"

        '運算項目
        Dim cmb_operDS As New DataSet
        cmb_operDS.Tables.Add(operatorDT)
        cmb_oper_cell.Ds = cmb_operDS
        cmb_oper_cell.ValueIndex = "0"
        cmb_oper_cell.DisplayIndex = "1"

        '單位
        Dim cmb_unitDS As New DataSet
        cmb_unitDS.Tables.Add(unitDT)
        cmb_unit_cell.Ds = cmb_unitDS
        cmb_unit_cell.ValueIndex = "0"
        cmb_unit_cell.DisplayIndex = "1"

        '條件關係
        Dim cmb_relDS As New DataSet
        cmb_relDS.Tables.Add(relationDT)
        cmb_rel_cell.Ds = cmb_relDS
        cmb_rel_cell.ValueIndex = "0"
        cmb_rel_cell.DisplayIndex = "1"

        '-----------------------------------------------------------

        '檢查類別
        _hash.Add(1, cmb_type_cell)
        '檢查項目
        _hash.Add(2, cmb_item_cell)
        'Ｘ,Ｙ,Ｚ
        valuetxt_cell.MaxLength = 20
        _hash.Add(3, valuetxt_cell)
        _hash.Add(4, valuetxt_cell)
        _hash.Add(5, valuetxt_cell)
        '運算項目
        _hash.Add(6, cmb_oper_cell)
        '值域
        popMsgCell.setProperties(500)
        _hash.Add(7, popMsgCell)
        '單位
        _hash.Add(8, cmb_unit_cell)
        '計算急診,計算住院,計算住院
        _hash.Add(9, chk_cell)
        _hash.Add(10, chk_cell)
        _hash.Add(11, chk_cell)
        '條件關係
        _hash.Add(12, cmb_rel_cell)
        'Seq_No,Is_New,Create_User,Create_Time,Rule_Maintain_Sn
        _hash.Add(13, valuetxt_cell)
        _hash.Add(14, valuetxt_cell)
        _hash.Add(15, valuetxt_cell)
        _hash.Add(16, valuetxt_cell)
        _hash.Add(17, valuetxt_cell)

        '檢查類別,檢查項目,Ｘ,Ｙ,Ｚ,運算項目,值域,單位,計算門診,計算急診,計算住院,條件關係,Seq_No,Is_New,Create_User,Create_Time,Rule_Maintain_Sn
        ucl_dgv_detail.uclHeaderText = gblRuleDetailColumn
        ucl_dgv_detail.uclColumnWidth = "110,110,30,30,30,80,100,70,75,75,75,80,50,50,50,50,80"
        ucl_dgv_detail.uclVisibleColIndex = "0,1,2,3,4,5,6,7,8,9,10,11,12" ',13,14,15,16,17

        ucl_dgv_detail.Initial(_hash)

        '*****************************************************************************************************

        ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
        ucl_dtp_end_eff_date.SetValue("2099/12/31")

        cb_fo.Checked = True
        cb_fe.Checked = True
        cb_fi.Checked = False
        rdo_isPrN.Checked = True
        rdo_isPrY.Checked = True
        cb_boe.Checked = True
        cb_bi.Checked = False

        ucl_comb_res_strength.SelectedValue = "2"

        'Modify By　Elly 2016/05/23  -start
        'ucl_comb_exe_type.SelectedValue = "0"
        ucl_comb_exe_type.SelectedValue = "1"
        '--end
        ucl_comb_check_ident.SelectedValue = "2"

        ucl_txt_rule_name.Focus()


        If initSRuleCode IsNot Nothing AndAlso initSRuleCode.Length > 0 Then
            Dim ruleDS As DataSet = pub.querySelectedRuleData(initSRuleCode)
            
            ruleDataToUI(ruleDS, False)
            MessageHandling.ShowInfoMsg("CMMCMMB901")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB901")

            initialDataFlag = False
        Else
            initialDataFlag = False
        End If

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
            MessageHandling.ShowInfoMsg("CMMCMMB901")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB901")
            Throw ex
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------
    '欄位檢核

    ''' <summary>
    ''' 條件欄位檢查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkConditionDataComplete() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True

        If Not ucl_comb_item_belong.SelectedIndex > 0 Then
            ucl_comb_item_belong.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_item_belong
        End If

        If (ucl_txt_x.Enabled = True And ucl_txt_x.Visible = True) AndAlso (Not ucl_txt_x.Text.Length > 0) Then
            ucl_txt_x.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_x
        End If

        If (Not ucl_txt_belong_info.Text.Trim.Length > 0) Or (Not (initConditionMsg.Length > 0)) Then
            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_belong_info
        Else
            'checkItemDataHash
            If ucl_comb_item_belong.SelectedIndex > 0 Then
                Dim selectItem As String = ucl_comb_item_belong.SelectedValue.Trim
                If checkItemDataHash.ContainsKey(selectItem) Then
                    Dim itemdr As DataRow = CType(checkItemDataHash.Item(selectItem), DataRow)
                    If IsDBNull(itemdr.Item("Value_Source_Program")) Then
                        '檢查是否有不合字元
                        If (initConditionMsg.IndexOf("[") > -1) Or (initConditionMsg.IndexOf("]") > -1) Or (initConditionMsg.IndexOf("-") > -1) Then
                            ' MessageHandling.showError("起始條件內容出現不合法字元")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"起始條件內容出現不合法字元"}, "起始條件內容出現不合法字元")
                        End If
                    ElseIf CType(itemdr.Item("Value_Source_Program"), String).Trim.Length = 0 Then
                        '檢查是否有不合字元
                        If (initConditionMsg.IndexOf("[") > -1) Or (initConditionMsg.IndexOf("]") > -1) Or (initConditionMsg.IndexOf("-") > -1) Then
                            ' MessageHandling.showError("起始條件內容出現不合法字元")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"起始條件內容出現不合法字元"}, "起始條件內容出現不合法字元")
                        End If
                    Else
                        '可填
                    End If

                End If
            End If


        End If

        If Not ucl_comb_res_strength.SelectedIndex > 0 Then
            ucl_comb_res_strength.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_res_strength
        End If

        If Not ucl_comb_exe_type.SelectedIndex > 0 Then
            ucl_comb_exe_type.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_exe_type
        End If

        If Not ucl_comb_check_ident.SelectedIndex > 0 Then
            ucl_comb_check_ident.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_check_ident
        End If

        If Not ucl_txt_rule_name.Text.Length > 0 Then
            ucl_txt_rule_name.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_rule_name
        End If

        If Not IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
            ucl_dtp_start_eff_date.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_dtp_start_eff_date

            If Not IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
                ucl_dtp_end_eff_date.SetValue("2099/12/31")

                'ucl_dtp_end_eff_date.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                'allPass = False
                'comp = ucl_dtp_end_eff_date
            End If

        Else

            If Not IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
                ucl_dtp_end_eff_date.SetValue("2099/12/31")

                'ucl_dtp_end_eff_date.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                'allPass = False
                'comp = ucl_dtp_end_eff_date
            Else
                '2都date
                If ucl_dtp_start_eff_date.GetUsDateStr.CompareTo(ucl_dtp_end_eff_date.GetUsDateStr) > 0 Then
                    ucl_dtp_end_eff_date.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    allPass = False
                    comp = ucl_dtp_end_eff_date
                End If
            End If

        End If




        If allPass Then
            cleanFieldsColor()
        Else
            ' MessageHandling.showErrorByKey("CMMCMMB009")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB309")
            ErrorKeyFlag = True
            comp.Focus()
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            ucl_comb_item_belong.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_txt_x.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_txt_rule_name.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_comb_res_strength.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_comb_exe_type.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_comb_check_ident.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_txt_rule_name.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_dtp_start_eff_date.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            ucl_dtp_end_eff_date.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

            ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 檢查Grid資料合法
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkGridDataComplete() As Boolean
        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS
        If DataSetUtil.IsContainsData(gridDS) Then
            'RuleDetailColumn() As String = {"檢查類別", "檢查項目", "Ｘ", "Ｙ", "Ｚ", "運算項目", "值域", "單位", 
            '"計算門診", "計算急診", "計算住院", "條件關係", "Seq_No", "Is_New", "Create_User", "Create_Time","Rule_Maintain_Sn"}
            Dim complete As Boolean = True
            For Each dr As DataRow In gridDS.Tables(0).Rows
                If IsDBNull(dr.Item(RuleDetailColumn(0))) Or IsDBNull(dr.Item(RuleDetailColumn(1))) Or IsDBNull(dr.Item(RuleDetailColumn(5))) Or IsDBNull(dr.Item(RuleDetailColumn(6))) Or IsDBNull(dr.Item(RuleDetailColumn(11))) _
                Or CType(dr.Item(RuleDetailColumn(0)), String).Trim.Equals("") Or CType(dr.Item(RuleDetailColumn(1)), String).Trim.Equals("") Or CType(dr.Item(RuleDetailColumn(5)), String).Trim.Equals("") Or CType(dr.Item(RuleDetailColumn(6)), String).Trim.Equals("") Or CType(dr.Item(RuleDetailColumn(11)), String).Trim.Equals("") Then
                    complete = False
                End If

                If complete Then
                    Dim itemCode As String = CType(dr.Item(RuleDetailColumn(1)), String).Trim
                    If checkItemDataHash.ContainsKey(itemCode) Then
                        Dim ItemName As String = CType(CType(checkItemDataHash.Item(itemCode), DataRow).Item("Item_Name"), String).Trim
                        Dim dataType As String = CType(CType(checkItemDataHash.Item(itemCode), DataRow).Item("Data_Type"), String).Trim

                        If ItemName.Contains("X") Then
                            If IsDBNull(dr.Item(RuleDetailColumn(2))) Then
                                complete = False
                            Else
                                If CType(dr.Item(RuleDetailColumn(2)), String).Trim.Equals("") Then
                                    complete = False
                                End If
                            End If
                        End If

                        If complete And ItemName.Contains("Y") Then
                            If IsDBNull(dr.Item(RuleDetailColumn(3))) Then
                                complete = False
                            Else
                                If CType(dr.Item(RuleDetailColumn(3)), String).Trim.Equals("") Then
                                    complete = False
                                End If
                            End If
                        End If

                        If complete And ItemName.Contains("Z") Then
                            If IsDBNull(dr.Item(RuleDetailColumn(4))) Then
                                complete = False
                            Else
                                If CType(dr.Item(RuleDetailColumn(4)), String).Trim.Equals("") Then
                                    complete = False
                                End If
                            End If
                        End If

                        'if datatype = 3....只有true or false(boolean value)
                        If dataType.Equals("3") Then
                            If Not IsDBNull(dr.Item(RuleDetailColumn(6))) Then
                                Dim value As String = CType(dr.Item(RuleDetailColumn(6)), String).Trim
                                If value.Equals("true") Or value.Equals("false") Then

                                Else
                                    complete = False
                                    'TODO 值域錯誤
                                End If
                            End If
                        End If

                    End If
                End If

            Next

            Return complete

        Else
            Return True
        End If

    End Function

    '--------------------------------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------------------------------
    '欄位資料對應到畫面

    ''' <summary>
    ''' 將rule資料對應到畫面上
    ''' </summary>
    ''' <param name="ruleDS"></param>
    ''' <remarks></remarks>
    Private Sub ruleDataToUI(ByRef ruleDS As DataSet, ByVal cloneFlag As Boolean)

        '"INIT-" & PubRuleDataTableFactory.tableName
        '"CHECK-" & PubRuleDataTableFactory.tableName
        ruleCode = ""
        initRuleCode = ""

        If DataSetUtil.IsContainsData(ruleDS) Then

            hasRuleData = True

            'ruleClassToUI
            If ruleDS.Tables.Contains(PubRuleClassDataTableFactory.tableName) Then
                Dim ruleClassDT As DataTable = ruleDS.Tables(PubRuleClassDataTableFactory.tableName).Copy
                ruleClassToUI(ruleClassDT)
            End If

            'rule
            Dim initRuleDetailName As String = "INIT-" & PubRuleDetailDataTableFactory.tableName
            If ruleDS.Tables.Contains(initRuleDetailName) Then
                Dim ruleDetailDT As DataTable = ruleDS.Tables(initRuleDetailName).Copy
                initRuleDetailToUI(ruleDetailDT)
            End If

            'rule
            Dim initRuleName As String = "INIT-" & PubRuleDataTableFactory.tableName
            If ruleDS.Tables.Contains(initRuleName) Then
                Dim initRuleDT As DataTable = ruleDS.Tables(initRuleName).Copy
                initRuleToUI(initRuleDT)
            End If

            Dim checkRuleDetailName As String = "CHECK-" & PubRuleDetailDataTableFactory.tableName
            If ruleDS.Tables.Contains(checkRuleDetailName) Then
                Dim ruleDetailDT As DataTable = ruleDS.Tables(checkRuleDetailName).Copy
                checkRuleDetailToUI(ruleDetailDT)
            End If

            'ruleMaintainToUI
            If ruleDS.Tables.Contains(PubRuleMaintainDataTableFactory.tableName) Then
                Dim ruleMaintainDT As DataTable = ruleDS.Tables(PubRuleMaintainDataTableFactory.tableName).Copy
                ruleMaintainToUI(ruleMaintainDT)
            End If

          
            '是否複製規則?
            If cloneFlag Then
                hasRuleData = False
                ruleCode = ""
                initRuleCode = ""
            Else

            End If

        Else
            hasRuleData = False
            '資料錯誤
            ' MessageHandling.showError("無符合條件之資料")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"無符合條件之資料"}, "")
        End If


    End Sub
    'pub_rule內容
    Private Sub initRuleToUI(ByRef ruleDT As DataTable)
        ' [Rule_Code]
        ',[Rule_Name]
        ',[Check_Type]
        ',[Expression_Str]
        ',[Check_Identity]
        ',[Limit_Alert_Level]
        ',[Is_Sending_Alert_Mail]
        ',[Is_Enabled_Client]
        ',[Is_Enabled_Server]
        ',[Is_Only_O]
        ',[Is_Only_E]
        ',[Is_Only_I]
        ',[True_Message]
        ',[False_Message]
        ',[Valid_Date_S]
        ',[Valid_Date_E]
        ',[Original_Rule_Code]
        ',[Create_User]
        ',[Create_Time]
        ',[Modified_User]
        ',[Modified_Time]
        If DataSetUtil.IsContainsData(ruleDT) Then

            '檢核條件匯入下面塊  XXX
            Dim initdr As DataRow = ruleDT.Rows(0)

            If initdr IsNot Nothing Then
                'If Not IsDBNull(initdr.Item("Rule_Code")) Then
                '    initRuleCode = CType(initdr.Item("Rule_Code"), String).Trim
                'End If

                If Not IsDBNull(initdr.Item("Rule_Name")) Then
                    ucl_txt_rule_name.Text = CType(initdr.Item("Rule_Name"), String).Trim
                End If

                '強度
                If Not IsDBNull(initdr.Item("Limit_Alert_Level")) Then
                    ucl_comb_res_strength.SelectedValue = CType(initdr.Item("Limit_Alert_Level"), String).Trim
                End If
                '類型
                If Not IsDBNull(initdr.Item("Check_Type")) Then
                    ucl_comb_exe_type.SelectedValue = CType(initdr.Item("Check_Type"), String).Trim
                End If
                '身分
                If Not IsDBNull(initdr.Item("Check_Identity")) Then
                    ucl_comb_check_ident.SelectedValue = CType(initdr.Item("Check_Identity"), String).Trim
                End If


                If Not IsDBNull(initdr.Item("Valid_Date_S")) Then
                    ucl_dtp_start_eff_date.SetValue(CType(initdr.Item("Valid_Date_S"), Date).ToString("yyyy/MM/dd"))
                    ruleValidDateS = CType(initdr.Item("Valid_Date_S"), Date).ToString("yyyy/MM/dd")
                End If
                If Not IsDBNull(initdr.Item("Valid_Date_E")) Then
                    ucl_dtp_end_eff_date.SetValue(CType(initdr.Item("Valid_Date_E"), Date).ToString("yyyy/MM/dd"))
                    ruleValidDateE = CType(initdr.Item("Valid_Date_E"), Date).ToString("yyyy/MM/dd")
                End If

                If Not IsDBNull(initdr.Item("Is_Enabled_Client")) Then
                    If CType(initdr.Item("Is_Enabled_Client"), String).Trim.Equals("Y") Then
                        If Not IsDBNull(initdr.Item("Is_Only_CO")) Then
                            If CType(initdr.Item("Is_Only_CO"), String).Trim.Equals("Y") Then
                                cb_fo.Checked = True
                            Else
                                cb_fo.Checked = False
                            End If
                        Else
                            cb_fo.Checked = False
                        End If

                        If Not IsDBNull(initdr.Item("Is_Only_CE")) Then
                            If CType(initdr.Item("Is_Only_CE"), String).Trim.Equals("Y") Then
                                cb_fe.Checked = True
                            Else
                                cb_fe.Checked = False
                            End If
                        Else
                            cb_fe.Checked = False
                        End If

                        If Not IsDBNull(initdr.Item("Is_Only_CI")) Then
                            If CType(initdr.Item("Is_Only_CI"), String).Trim.Equals("Y") Then
                                cb_fi.Checked = True
                            Else
                                cb_fi.Checked = False
                            End If
                        Else
                            cb_fi.Checked = False
                        End If
                    Else
                        cb_fo.Checked = False
                        cb_fe.Checked = False
                        cb_fi.Checked = False
                    End If
                Else
                    cb_fo.Checked = False
                    cb_fe.Checked = False
                    cb_fi.Checked = False
                End If

                If Not IsDBNull(initdr.Item("Is_Prior_Review")) Then
                    If CType(initdr.Item("Is_Prior_Review"), String).Trim.Equals("Y") Then
                        rdo_isPrY.Checked = True
                        rdo_isPrN.Checked = False
                    Else
                        rdo_isPrY.Checked = False
                        rdo_isPrN.Checked = True
                    End If
                End If


                If Not IsDBNull(initdr.Item("Is_Enabled_Server")) Then
                    If CType(initdr.Item("Is_Enabled_Server"), String).Trim.Equals("Y") Then
                        'cb_back.Checked = True

                        If (Not IsDBNull(initdr.Item("Is_Only_SO"))) AndAlso (Not IsDBNull(initdr.Item("Is_Only_SE"))) Then
                            If CType(initdr.Item("Is_Only_SO"), String).Trim.Equals("Y") AndAlso CType(initdr.Item("Is_Only_SE"), String).Trim.Equals("Y") Then
                                cb_boe.Checked = True
                            Else
                                cb_boe.Checked = False
                            End If
                        Else
                            cb_boe.Checked = False
                        End If

                        If Not IsDBNull(initdr.Item("Is_Only_SI")) Then
                            If CType(initdr.Item("Is_Only_SI"), String).Trim.Equals("Y") Then
                                cb_bi.Checked = True
                            Else
                                cb_bi.Checked = False
                            End If
                        Else
                            cb_bi.Checked = False
                        End If

                    Else
                        cb_boe.Checked = False
                        cb_bi.Checked = False
                    End If
                Else
                    cb_boe.Checked = False
                    cb_bi.Checked = False
                End If


                '成功訊息
                If Not IsDBNull(initdr.Item("True_Message")) Then
                    ucl_rt_successmsg.Text = CType(initdr.Item("True_Message"), String).Trim
                End If
                If Not IsDBNull(initdr.Item("Ext_No")) Then
                    txt_message.Text = CType(initdr.Item("Ext_No"), String).Trim
                End If
                '失敗訊息
                If Not IsDBNull(initdr.Item("False_Message")) Then
                    ucl_rt_faultmsg.Text = CType(initdr.Item("False_Message"), String).Trim
                End If

                '訊息
                If Not IsDBNull(initdr.Item("Info_Message")) Then
                    ucl_rt_process_msg.Text = CType(initdr.Item("Info_Message"), String).Trim
                End If

                createUser = CType(initdr.Item("Create_User"), String).Trim
                '2010/04/09拿掉
                '要讓大家改
                'If createUser.Trim.Equals(loginUser.ToString.Trim) Then
                'ifuserorCreate = True
                'Else
                '    ifuserorCreate = False
                'End If
                ifuserorCreate = True

                createTimeStr = CType(initdr.Item("Create_Time"), Date).ToString("yyyy/MM/dd HH:mm:ss")
            Else
                'TODO
                '無檢核條件資料
            End If


        Else
            '無資料

        End If
    End Sub

    Private Sub initRuleDetailToUI(ByRef ruleDetailDT As DataTable)
        If DataSetUtil.IsContainsData(ruleDetailDT) Then
            '起始條件內容值
            If Not IsDBNull(ruleDetailDT.Rows(0).Item("Item_Code")) Then

                ucl_comb_item_belong.SelectedValue = CType(ruleDetailDT.Rows(0).Item("Item_Code"), String).Trim
                If ucl_comb_item_belong.Text.Contains("X") Then
                    lb_x.Enabled = True
                    lb_x.Visible = True
                    Dim xind As Integer = ucl_comb_item_belong.Text.IndexOf("X")

                    If (ucl_comb_item_belong.Text.Length - 1) > xind Then
                        lb_x.Text = ucl_comb_item_belong.Text.Substring(0, xind)
                        lb_init_belong.Text = ucl_comb_item_belong.Text.Substring(xind + 1)
                    Else
                        'final len = x
                        lb_x.Text = ucl_comb_item_belong.Text.Substring(0, xind - 1)
                        lb_init_belong.Text = ""
                    End If
                    ucl_txt_x.Enabled = True
                    ucl_txt_x.Visible = True
                    ucl_txt_x.Text = CType(ruleDetailDT.Rows(0).Item("Item_Param"), String).Substring(2)
                End If

            End If

            If Not IsDBNull(ruleDetailDT.Rows(0).Item("Value_Data")) Then
                ucl_txt_belong_info.Text = CType(ruleDetailDT.Rows(0).Item("Value_Data"), String).Trim
                initConditionMsg = ucl_txt_belong_info.Text
                Me.lblName.Text = Space(18) & fGetOrderName(ucl_comb_item_belong.SelectedValue, ucl_txt_belong_info.Text.Trim)
                If Not IsDBNull(ruleDetailDT.Rows(0).Item("Rule_Maintain_Sn")) Then
                    initRuleMaintainSn = CType(ruleDetailDT.Rows(0).Item("Rule_Maintain_Sn"), Integer)
                End If
            End If

        End If

    End Sub

    'grid細項
    Private Sub checkRuleDetailToUI(ByRef ruleDetailDT As DataTable)
        ' [Rule_Code]
        ',[Seq_No]
        ',[Item_Code]
        ',[Item_Param]
        ',[Operator_Code]
        ',[Value_Data]
        ',[Value_Unit]
        ',[Is_Count_O]
        ',[Is_Count_E]
        ',[Is_Count_I]
        ',[Logical_Symbol]
        ',[Create_User]
        ',[Create_Time]
        ',[Modified_User]
        ',[Modified_Time]
        ',[Rule_Maintain_Sn]
        If DataSetUtil.IsContainsData(ruleDetailDT) Then
            '檢核條件內容值
            'ruleCode = CType(ruleDetailDT.Rows(0).Item("Rule_Code"), String).Trim


            '檢核條件內容值

            'map to {"檢查類別", "檢查項目", "Ｘ", "Ｙ", "Ｚ", "運算項目", "值域", "單位", "計算門診", "計算急診", "計算住院", "條件關係"}

            Dim detailDS As DataSet = New DataSet
            Dim detailDT As DataTable = DataSetUtil.GenDataTable("detail", Nothing, RuleDetailColumn, RuleDetailColumnType)
            '....for
            For Each detaildr As DataRow In ruleDetailDT.Rows

                If IsDBNull(detaildr.Item("Item_Code")) Or IsDBNull(detaildr.Item("Item_Code")) _
                Or CType(detaildr.Item("Item_Code"), String).Trim.Equals("") Or CType(detaildr.Item("Item_Code"), String).Trim.Equals("") Then

                Else

                    'maxSeqNo
                    Dim seqNo As Integer = CType(detaildr.Item("Seq_No"), Integer)
                    If seqNo > maxSeqNo Then
                        maxSeqNo = seqNo
                    End If

                    Dim newdr As DataRow = detailDT.NewRow

                    Dim itemCode As String = CType(detaildr.Item("Item_Code"), String).Trim

                    newdr.Item(RuleDetailColumn(0)) = itemCode.Substring(0, 1)
                    newdr.Item(RuleDetailColumn(1)) = itemCode

                    'checkItemHash checkItemParamHash
                    Dim itemName As String = ""
                    Dim itemParam As String = ""
                    If checkItemDataHash.ContainsKey(itemCode) Then
                        itemName = CType(CType(checkItemDataHash.Item(itemCode), DataRow).Item("Item_Name"), String).Trim
                        itemParam = detaildr.Item("Item_Param").ToString.Trim

                        Dim itemParamSplit() As String = itemParam.Split(";")

                        If itemName.Contains("X") Then
                            newdr.Item(RuleDetailColumn(2)) = ""
                            For j As Integer = 0 To (itemParamSplit.Length - 1)
                                If itemParamSplit(j).Contains("X") Then
                                    Dim xindex As Integer = itemParamSplit(j).IndexOf("X")
                                    newdr.Item(RuleDetailColumn(2)) = itemParamSplit(j).Substring(xindex + 2, itemParamSplit(j).Length - (xindex + 2))
                                End If
                            Next


                        End If

                        If itemName.Contains("Y") Then
                            newdr.Item(RuleDetailColumn(3)) = ""
                            For j As Integer = 0 To (itemParamSplit.Length - 1)
                                If itemParamSplit(j).Contains("Y") Then
                                    Dim xindex As Integer = itemParamSplit(j).IndexOf("Y")
                                    newdr.Item(RuleDetailColumn(3)) = itemParamSplit(j).Substring(xindex + 2, itemParamSplit(j).Length - (xindex + 2))
                                End If
                            Next
                        End If

                        If itemName.Contains("Z") Then
                            newdr.Item(RuleDetailColumn(4)) = ""
                            For j As Integer = 0 To (itemParamSplit.Length - 1)
                                If itemParamSplit(j).Contains("Z") Then
                                    Dim xindex As Integer = itemParamSplit(j).IndexOf("Z")
                                    newdr.Item(RuleDetailColumn(4)) = itemParamSplit(j).Substring(xindex + 2, itemParamSplit(j).Length - (xindex + 2))
                                End If
                            Next
                        End If

                    Else
                        newdr.Item(RuleDetailColumn(2)) = ""
                        newdr.Item(RuleDetailColumn(3)) = ""
                        newdr.Item(RuleDetailColumn(4)) = ""
                    End If

                    If Not IsDBNull(detaildr.Item("Operator_Code")) Then
                        newdr.Item(RuleDetailColumn(5)) = CType(detaildr.Item("Operator_Code"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(5)) = ""
                    End If
                    If Not IsDBNull(detaildr.Item("Value_Data")) Then
                        newdr.Item(RuleDetailColumn(6)) = CType(detaildr.Item("Value_Data"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(6)) = ""
                    End If
                    If Not IsDBNull(detaildr.Item("Value_Unit")) Then
                        newdr.Item(RuleDetailColumn(7)) = CType(detaildr.Item("Value_Unit"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(7)) = ""
                    End If
                    If Not IsDBNull(detaildr.Item("Is_Count_O")) Then
                        newdr.Item(RuleDetailColumn(8)) = CType(detaildr.Item("Is_Count_O"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(8)) = "N"
                    End If
                    If Not IsDBNull(detaildr.Item("Is_Count_E")) Then
                        newdr.Item(RuleDetailColumn(9)) = CType(detaildr.Item("Is_Count_E"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(9)) = "N"
                    End If
                    If Not IsDBNull(detaildr.Item("Is_Count_I")) Then
                        newdr.Item(RuleDetailColumn(10)) = CType(detaildr.Item("Is_Count_I"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(10)) = "N"
                    End If
                    If Not IsDBNull(detaildr.Item("Logical_Symbol")) Then
                        newdr.Item(RuleDetailColumn(11)) = CType(detaildr.Item("Logical_Symbol"), String).Trim
                    Else
                        newdr.Item(RuleDetailColumn(11)) = ""
                    End If


                    newdr.Item(RuleDetailColumn(12)) = CType(detaildr.Item("Seq_No"), Integer)
                    newdr.Item(RuleDetailColumn(13)) = "N"

                    newdr.Item(RuleDetailColumn(14)) = CType(detaildr.Item("Create_User"), String).Trim
                    newdr.Item(RuleDetailColumn(15)) = CType(detaildr.Item("Create_Time"), Date)

                    If Not IsDBNull(detaildr.Item("Rule_Maintain_Sn")) Then
                        newdr.Item(RuleDetailColumn(16)) = CType(detaildr.Item("Rule_Maintain_Sn"), Integer)
                    End If

                    detailDT.Rows.Add(newdr)

                End If


            Next

            detailDS.Tables.Add(detailDT)

            ucl_dgv_detail.Visible = False
            ucl_dgv_detail.SetDS(detailDS)
            ucl_dgv_detail.Visible = True

        End If


    End Sub
    '接續動作
    Private Sub ruleClassToUI(ByRef ruleClassDT As DataTable)
        '1 起始 , 檢核
        '3 成功街
        '4 失敗皆
        'Rule_Code, Condition_Type, Seq_No, Condition_Rule_Code, Logical_Symbol, Create_User , Create_Time , Modified_User , Modified_Time
        ''
        If DataSetUtil.IsContainsData(ruleClassDT) Then
            For Each dr As DataRow In ruleClassDT.Rows
                Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim

                If conditionType.Equals("1") Then
                    ruleCode = CType(dr.Item("Rule_Code"), String).Trim
                    initRuleCode = CType(dr.Item("Condition_Rule_Code"), String).Trim

                    ruleclassdr = dr
                ElseIf conditionType.Equals("2") Then
                    '成功
                    ucl_txt_success_cond.Text = CType(dr.Item("Rule_Code"), String).Trim
                    successClassdr = dr
                ElseIf conditionType.Equals("3") Then
                    '失敗
                    ucl_txt_fault_cond.Text = CType(dr.Item("Rule_Code"), String).Trim
                    faultclassdr = dr
                End If

            Next
        End If
    End Sub

    Private Sub ruleMaintainToUI(ByRef ruleMaintainDT As DataTable)

        If DataSetUtil.IsContainsData(ruleMaintainDT) Then
            If Not IsDBNull(ruleMaintainDT.Rows(0).Item("Maintain_Value_Str")) Then
                initConditionMsg = CType(ruleMaintainDT.Rows(0).Item("Maintain_Value_Str"), String)
            Else
                initConditionMsg = ""
            End If

        Else
            initConditionMsg = ""
        End If

        If initConditionMsg.Length > 30 Then
            ucl_txt_belong_info.Text = initConditionMsg.Substring(0, 26) & ".."
        Else
            ucl_txt_belong_info.Text = initConditionMsg
        End If

        'Dim valueDataStr As New StringBuilder
        'For i As Integer = 0 To (detailInitdr.Length - 1)
        '    If Not IsDBNull(detailInitdr(i).Item("Value_Data")) Then
        '        valueDataStr.Append(CType(detailInitdr(i).Item("Value_Data"), String).Trim).Append(",")
        '    End If
        'Next
        'If valueDataStr.Length > 0 Then
        '    valueDataStr.Remove(valueDataStr.Length - 1, 1)
        'End If

        'initConditionMsg = valueDataStr.ToString
        'If initConditionMsg.Length > 30 Then
        '    ucl_txt_belong_info.Text = initConditionMsg.Substring(0, 26) & ".."
        'Else
        '    ucl_txt_belong_info.Text = initConditionMsg
        'End If
    End Sub

    '-------------------------
    'ui to grid
    ''' <summary>
    ''' 將畫面資料對應到dt
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiToDT(ByVal confirmType As String) As DataSet
        Dim confirmRuleDS As New DataSet



        Dim itemCode As String = ucl_comb_item_belong.SelectedValue.Trim
        Dim valueDataDT As DataTable = DataSetUtil.GenDataTable("valuedata", Nothing, ValueDataColumn, ValueDataColumnType)
        Dim valuedr As DataRow = valueDataDT.NewRow
        valuedr.Item(ValueDataColumn(0)) = ruleCode
        valuedr.Item(ValueDataColumn(1)) = initConditionMsg
        valuedr.Item(ValueDataColumn(2)) = ruleValidDateS
        valueDataDT.Rows.Add(valuedr)

        confirmRuleDS.Tables.Add(valueDataDT)


        If confirmType.Equals(SQLDataUtil.ADD_TYPE) Then
            'result = pub.confirmRuleData(SQLDataUtil.ADD_TYPE, ruleDS)
            ruleCode = ""
            initRuleCode = ""
        ElseIf confirmType.Equals(SQLDataUtil.MOD_TYPE) Then
            'result = pub.confirmRuleData(SQLDataUtil.MOD_TYPE, ruleDS)
        ElseIf confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
            'result = pub.confirmRuleData(SQLDataUtil.CLONE_TYPE, ruleDS)
            ruleCode = ""
            initRuleCode = ""
        End If



        'confirmRuleDS
        Dim ruleDT As DataTable = uiRuleToDT()
        Dim ruleDetailDT As DataTable = uiRuleDetailToDT()
        Dim ruleClassDT As DataTable = uiRuleClassToDT()


        If DataSetUtil.IsContainsData(ruleDT) Then

            If confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                    ruleDT.Rows(i).Item("Original_Rule_Code") = CType(valueDataDT.Rows(0).Item(ValueDataColumn(0)), String).Trim
                Next
            End If

            confirmRuleDS.Tables.Add(ruleDT)

            If DataSetUtil.IsContainsData(ruleDetailDT) Then
                confirmRuleDS.Tables.Add(ruleDetailDT)
            End If
            If DataSetUtil.IsContainsData(ruleClassDT) Then
                confirmRuleDS.Tables.Add(ruleClassDT)
            End If
        End If

        Return confirmRuleDS

    End Function

    Private Function uiRuleToDT() As DataTable
        ' [Rule_Code]
        ',[Rule_Name]
        ',[Check_Type]
        ',[Expression_Str]
        ',[Check_Identity]
        ',[Limit_Alert_Level]
        ',[Is_Sending_Alert_Mail]
        ',[Is_Enabled_Client]
        ',[Is_Enabled_Server]
        ',[Is_Only_O]
        ',[Is_Only_E]
        ',[Is_Only_I]
        ',[True_Message]
        ',[False_Message]
        ',[Valid_Date_S]
        ',[Valid_Date_E]
        ',[Original_Rule_Code]
        ',[Create_User]
        ',[Create_Time]
        ',[Modified_User]
        ',[Modified_Time]

        Dim hasData As Boolean = False
        If Not initRuleCode.Equals("") Then
            hasData = True
        End If

        Dim ruleDT As DataTable = PubRuleDataTableFactory.getDataTableWithSchema
        Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim

        'TODO 取號
        If ruleCode.Equals("") Then
            ruleCode = genRuleCode(itemCodeIni)
        End If

        If initRuleCode.Equals("") Then
            initRuleCode = ruleCode & "-S1"
        End If

        '------------------------------------------------------------------------------------
        '起始條件

        Dim initDr As DataRow = ruleDT.NewRow
        initDr.Item("Rule_Code") = initRuleCode
        initDr.Item("Rule_Name") = ucl_txt_rule_name.Text.Trim
        initDr.Item("Check_Type") = ucl_comb_exe_type.SelectedValue
        '[Expression_Str]

        '-------20091221
        Dim initExpStr As New StringBuilder
        If checkItemDataHash.ContainsKey(itemCodeIni) Then
            Dim itemdr As DataRow = CType(checkItemDataHash.Item(itemCodeIni), DataRow)

            'ucl_txt_belong_info
            Dim valueData As String = initConditionMsg
            'ucl_txt_belong_info.Text.Trim
            'initConditionMsg
            Dim valueDataSplit() As String = valueData.Split(",")
            If valueDataSplit IsNot Nothing AndAlso valueDataSplit.Length > 0 Then
                For i As Integer = 0 To (valueDataSplit.Length - 1)
                    initExpStr.Append(getExpressionStr(CType(itemdr.Item("Class_Code"), String).Trim, CType(itemdr.Item("Field_Code"), String).Trim, CType(itemdr.Item("Data_Type"), String).Trim, CType(itemdr.Item("Return_Checking_Flag"), String).Trim, valueDataSplit(i)))
                    initExpStr.Append("|")
                Next

                If initExpStr.Length > 0 Then
                    initExpStr.Remove(initExpStr.Length - 1, 1)
                End If
            Else
                '無
            End If

            'initExpStr = getExpressionStr(CType(itemdr.Item("Class_Code"), String).Trim, CType(itemdr.Item("Field_Code"), String).Trim, CType(itemdr.Item("Data_Type"), String).Trim, CType(itemdr.Item("Return_Checking_Flag"), String).Trim)
        End If
        initDr.Item("Expression_Str") = initExpStr.ToString
        '------20091221


        initDr.Item("Check_Identity") = ucl_comb_check_ident.SelectedValue
        initDr.Item("Limit_Alert_Level") = ucl_comb_res_strength.SelectedValue
        initDr.Item("Ext_No") = txt_message.Text
        'Clinet enable
        Dim enableC As Boolean = False
        If cb_fo.Checked Then
            initDr.Item("Is_Only_CO") = "Y"
            enableC = True
        Else
            initDr.Item("Is_Only_CO") = "N"
        End If
        If cb_fe.Checked Then
            initDr.Item("Is_Only_CE") = "Y"
            enableC = True
        Else
            initDr.Item("Is_Only_CE") = "N"
        End If
        If cb_fi.Checked Then
            initDr.Item("Is_Only_CI") = "Y"
            enableC = True
        Else
            initDr.Item("Is_Only_CI") = "N"
        End If

        If enableC Then
            initDr.Item("Is_Enabled_Client") = "Y"
        Else
            initDr.Item("Is_Enabled_Client") = "N"
        End If

        'Server enable
        Dim enableS As Boolean = False
        If cb_boe.Checked Then
            initDr.Item("Is_Only_SO") = "Y"
            initDr.Item("Is_Only_SE") = "Y"
            enableS = True
        Else
            initDr.Item("Is_Only_SO") = "N"
            initDr.Item("Is_Only_SE") = "N"
        End If
        If cb_bi.Checked Then
            initDr.Item("Is_Only_SI") = "Y"
            enableS = True
        Else
            initDr.Item("Is_Only_SI") = "N"
        End If
        initDr.Item("Is_Prior_Review") = "N"
        If enableS Then
            initDr.Item("Is_Enabled_Server") = "Y"
        Else
            initDr.Item("Is_Enabled_Server") = "N"
        End If
        If rdo_isPrN.Checked = True Then
            initDr.Item("Is_Prior_Review") = "N"
        Else
            initDr.Item("Is_Prior_Review") = "Y"

        End If

        initDr.Item("True_Message") = ucl_rt_successmsg.Text
        initDr.Item("False_Message") = ucl_rt_faultmsg.Text
        initDr.Item("Valid_Date_S") = Date.Parse(ucl_dtp_start_eff_date.GetUsDateStr)
        initDr.Item("Valid_Date_E") = Date.Parse(ucl_dtp_end_eff_date.GetUsDateStr)
        ',[Original_Rule_Code] ??

        If hasData Then
            initDr.Item("Create_User") = createUser
            If Not createTimeStr.Equals("") Then
                Try
                    initDr.Item("Create_Time") = Date.Parse(createTimeStr)
                Catch ex As Exception

                End Try
            End If

            initDr.Item("Modified_User") = loginUser
        Else
            'new
            initDr.Item("Create_User") = loginUser
            initDr.Item("Create_Time") = systemDate
        End If


        ruleDT.Rows.Add(initDr)

        '------------------------------------------------------------------------------------
        '檢核條件
        '------------------------------------------------------------------------------------

        Dim checkDr As DataRow = ruleDT.NewRow
        checkDr.Item("Rule_Code") = ruleCode
        checkDr.Item("Rule_Name") = ucl_txt_rule_name.Text.Trim
        checkDr.Item("Check_Type") = ucl_comb_exe_type.SelectedValue
        checkDr.Item("Ext_No") = txt_message.Text
        '[Expression_Str] getExpressionStr(CType(checkDr.Item("Check_Type")))
        Dim detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy


        '----20091221
        If DataSetUtil.IsContainsData(detailDS) Then
            Dim expStr As New StringBuilder
            For i As Integer = 0 To (detailDS.Tables(0).Rows.Count - 1)
                Dim itemCode As String = CType(detailDS.Tables(0).Rows(i).Item(RuleDetailColumn(1)), String).Trim
                Dim valueData As String = CType(detailDS.Tables(0).Rows(i).Item(RuleDetailColumn(6)), String).Trim
                Dim relation As String = CType(detailDS.Tables(0).Rows(i).Item(RuleDetailColumn(11)), String).Trim
                Dim relationSymbol As String = ""
                If relation.Equals("AND") Then
                    relationSymbol = "&"
                ElseIf relation.Equals("OR") Then
                    relationSymbol = "|"
                End If
                '修改by 洗心革面的markwu
                '在修改expStr的部份，將原本都是=的
                '改成在外部界面時。有些是吃外面給的operation 子
                '另外，感謝前人的功勞。operation 子的hashtable是operationhash

                If checkItemDataHash.ContainsKey(itemCode) Then
                    Dim itemdr As DataRow = CType(checkItemDataHash.Item(itemCode), DataRow)
                    expStr.Append(getExpressionStr(CType(itemdr.Item("Class_Code"), String).Trim, CType(itemdr.Item("Field_Code"), String).Trim, CType(itemdr.Item("Data_Type"), String).Trim, CType(itemdr.Item("Return_Checking_Flag"), String).Trim, valueData, Me.operationhash.Item(CType(detailDS.Tables(0).Rows(i).Item(RuleDetailColumn(5)), String).Trim)))
                    expStr.Append(relationSymbol)
                End If
            Next

            If expStr.Length > 0 Then
                expStr.Remove(expStr.Length - 1, 1)
            End If

            checkDr.Item("Expression_Str") = expStr.ToString
        Else
            checkDr.Item("Expression_Str") = ""
        End If
        '----20091221


        checkDr.Item("Check_Identity") = ucl_comb_check_ident.SelectedValue
        checkDr.Item("Limit_Alert_Level") = ucl_comb_res_strength.SelectedValue
        If rdo_isPrN.Checked = True Then
            checkDr.Item("Is_Prior_Review") = "N"
        Else
            checkDr.Item("Is_Prior_Review") = "Y"

        End If
        'Clinet enable
        Dim enableCc As Boolean = False
        If cb_fo.Checked Then
            checkDr.Item("Is_Only_CO") = "Y"
            enableCc = True
        Else
            checkDr.Item("Is_Only_CO") = "N"
        End If
        If cb_fe.Checked Then
            checkDr.Item("Is_Only_CE") = "Y"
            enableCc = True
        Else
            checkDr.Item("Is_Only_CE") = "N"
        End If
        If cb_fi.Checked Then
            checkDr.Item("Is_Only_CI") = "Y"
            enableCc = True
        Else
            checkDr.Item("Is_Only_CI") = "N"
        End If

        If enableCc Then
            checkDr.Item("Is_Enabled_Client") = "Y"
        Else
            checkDr.Item("Is_Enabled_Client") = "N"
        End If

        'Server enable
        Dim enableSc As Boolean = False
        If cb_boe.Checked Then
            checkDr.Item("Is_Only_SO") = "Y"
            checkDr.Item("Is_Only_SE") = "Y"
            enableSc = True
        Else
            checkDr.Item("Is_Only_SO") = "N"
            checkDr.Item("Is_Only_SE") = "N"
        End If
        If cb_bi.Checked Then
            checkDr.Item("Is_Only_SI") = "Y"
            enableSc = True
        Else
            checkDr.Item("Is_Only_SI") = "N"
        End If

        If enableSc Then
            checkDr.Item("Is_Enabled_Server") = "Y"
        Else
            checkDr.Item("Is_Enabled_Server") = "N"
        End If

        checkDr.Item("True_Message") = ucl_rt_successmsg.Text
        checkDr.Item("False_Message") = ucl_rt_faultmsg.Text
        checkDr.Item("Info_Message") = ucl_rt_process_msg.Text

        checkDr.Item("Valid_Date_S") = Date.Parse(ucl_dtp_start_eff_date.GetUsDateStr)
        checkDr.Item("Valid_Date_E") = Date.Parse(ucl_dtp_end_eff_date.GetUsDateStr)
        ',[Original_Rule_Code] ??

        If hasData Then
            checkDr.Item("Create_User") = createUser
            If Not createTimeStr.Equals("") Then
                Try
                    checkDr.Item("Create_Time") = Date.Parse(createTimeStr)
                Catch ex As Exception

                End Try
            End If

            checkDr.Item("Modified_User") = loginUser
        Else
            'new
            checkDr.Item("Create_User") = loginUser
            checkDr.Item("Create_Time") = systemDate
        End If

        ruleDT.Rows.Add(checkDr)

        Return ruleDT

    End Function

    Private Function uiRuleDetailToDT() As DataTable
        Dim ruleDetailDT As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema
        Dim itemName As String = ""

        '起始
        If initConditionMsg IsNot Nothing AndAlso initConditionMsg.Length > 0 Then



            Dim initdetaildr As DataRow = ruleDetailDT.NewRow
            initdetaildr.Item("Seq_No") = 1
            initdetaildr.Item("Rule_Code") = initRuleCode
            initdetaildr.Item("Item_Code") = ucl_comb_item_belong.SelectedValue.Trim

            If checkItemDataHash.ContainsKey(initdetaildr.Item("Item_Code")) Then
                itemName = CType(CType(checkItemDataHash.Item(initdetaildr.Item("Item_Code")), DataRow).Item("Item_Name"), String).Trim

                If itemName.Contains("X") Then


                    Dim paramStr As StringBuilder = New StringBuilder

                    paramStr.Append("X=").Append(ucl_txt_x.Text.Trim).Append(";")

                    If paramStr.Length > 0 Then
                        paramStr.Remove(paramStr.Length - 1, 1)
                    End If
                    initdetaildr.Item("Item_Param") = paramStr.ToString

                End If
            End If


            initdetaildr.Item("Operator_Code") = "02"
            initdetaildr.Item("Value_Data") = initConditionMsg
            initdetaildr.Item("Logical_Symbol") = "OR"

            'TODOTODO
            initdetaildr.Item("Is_Count_O") = IIf((cb_fo.Checked Or cb_boe.Checked), "Y", "N")
            initdetaildr.Item("Is_Count_E") = IIf((cb_fe.Checked Or cb_boe.Checked), "Y", "N")
            initdetaildr.Item("Is_Count_I") = IIf((cb_fi.Checked Or cb_bi.Checked), "Y", "N")

            If Not initcreateUser.Equals("") Then
                initdetaildr.Item("Create_User") = initcreateUser
                If Not initcreateTimeStr.Equals("") Then
                    Try
                        initdetaildr.Item("Create_Time") = Date.Parse(initcreateTimeStr)
                    Catch ex As Exception

                    End Try
                End If

                initdetaildr.Item("Modified_User") = loginUser
            Else
                initdetaildr.Item("Create_User") = loginUser
                initdetaildr.Item("Create_Time") = systemDate
            End If

            initdetaildr.Item("Rule_Maintain_Sn") = initRuleMaintainSn

            ruleDetailDT.Rows.Add(initdetaildr)


        End If





        '檢核
        If DataSetUtil.IsContainsData(ucl_dgv_detail.GetDBDS) Then
            Dim detailDT As DataTable = ucl_dgv_detail.GetDBDS.Tables(0)

            Dim dataComplete As Boolean = True

            'detailDT > ruleDetailDT
            For i As Integer = 0 To (detailDT.Rows.Count - 1)
                Dim detaildr As DataRow = ruleDetailDT.NewRow
                detaildr.Item("Rule_Code") = ruleCode
                If detailDT.Rows(i).Item(RuleDetailColumn(12)).ToString <> "" Then
                    detaildr.Item("Seq_No") = CType(detailDT.Rows(i).Item(RuleDetailColumn(12)), Integer)
                Else
                    detaildr.Item("Seq_No") = i
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(1)).ToString <> "" Then
                    detaildr.Item("Item_Code") = CType(detailDT.Rows(i).Item(RuleDetailColumn(1)), String).Trim
                Else
                    detaildr.Item("Item_Code") = ""
                End If
              
                'If checkItemDataHash.ContainsKey(initdetaildr.Item("Item_Code")) Then
                'CType(CType(checkItemDataHash.Item(CType(detailDT.Rows(i).Item(RuleDetailColumn(1)), String).Trim), DataRow).Item("Item_Name"), String).Trim
                If checkItemDataHash.ContainsKey(CType(detailDT.Rows(i).Item(RuleDetailColumn(1)), String)) Then
                    itemName = CType(CType(checkItemDataHash.Item(CType(detailDT.Rows(i).Item(RuleDetailColumn(1)), String).Trim), DataRow).Item("Item_Name"), String).Trim
                Else
                    itemName = CType(detailDT.Rows(i).Item(RuleDetailColumn(1)), String)
                End If

                Dim paramStr As StringBuilder = New StringBuilder
                If itemName.Contains("X") Then
                    If Not IsDBNull(detailDT.Rows(i).Item(RuleDetailColumn(2))) Then
                        Dim xvalue As String = CType(detailDT.Rows(i).Item(RuleDetailColumn(2)), String).Trim
                        If Not xvalue.Equals("") Then
                            paramStr.Append("X=").Append(xvalue).Append(";")
                        Else
                            '要給資料啦
                            dataComplete = False
                        End If
                    Else
                        '要給資料啦
                        dataComplete = False
                    End If
                End If

                If itemName.Contains("Y") Then
                    If Not IsDBNull(detailDT.Rows(i).Item(RuleDetailColumn(3))) Then
                        Dim xvalue As String = CType(detailDT.Rows(i).Item(RuleDetailColumn(3)), String).Trim
                        If Not xvalue.Equals("") Then
                            paramStr.Append("Y=").Append(xvalue).Append(";")
                        Else
                            '要給資料啦
                            dataComplete = False
                        End If
                    Else
                        '要給資料啦
                        dataComplete = False
                    End If
                End If

                If itemName.Contains("Z") Then
                    If Not IsDBNull(detailDT.Rows(i).Item(RuleDetailColumn(4))) Then
                        Dim xvalue As String = CType(detailDT.Rows(i).Item(RuleDetailColumn(4)), String).Trim
                        If Not xvalue.Equals("") Then
                            paramStr.Append("Z=").Append(xvalue).Append(";")
                        Else
                            '要給資料啦
                            dataComplete = False
                        End If
                    Else
                        '要給資料啦
                        dataComplete = False
                    End If
                End If

                If paramStr.Length > 0 Then
                    paramStr.Remove(paramStr.Length - 1, 1)
                End If
                detaildr.Item("Item_Param") = paramStr.ToString

                detaildr.Item("Operator_Code") = CType(detailDT.Rows(i).Item(RuleDetailColumn(5)), String).Trim

                If detailDT.Rows(i).Item(RuleDetailColumn(6)).ToString <> "" Then
                    detaildr.Item("Value_Data") = CType(detailDT.Rows(i).Item(RuleDetailColumn(6)), String).Trim
                Else
                    detaildr.Item("Value_Data") = ""
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(7)).ToString <> "" Then
                    detaildr.Item("Value_Unit") = CType(detailDT.Rows(i).Item(RuleDetailColumn(7)), String).Trim
                Else
                    detaildr.Item("Value_Unit") = ""
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(8)).ToString <> "" Then
                    detaildr.Item("Is_Count_O") = CType(detailDT.Rows(i).Item(RuleDetailColumn(8)), String).Trim
                Else
                    detaildr.Item("Is_Count_O") = ""
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(9)).ToString <> "" Then
                    detaildr.Item("Is_Count_E") = CType(detailDT.Rows(i).Item(RuleDetailColumn(9)), String).Trim
                Else
                    detaildr.Item("Is_Count_E") = ""
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(10)).ToString <> "" Then
                    detaildr.Item("Is_Count_I") = CType(detailDT.Rows(i).Item(RuleDetailColumn(10)), String).Trim
                Else
                    detaildr.Item("Is_Count_I") = ""
                End If

                If detailDT.Rows(i).Item(RuleDetailColumn(11)).ToString <> "" Then
                    detaildr.Item("Logical_Symbol") = CType(detailDT.Rows(i).Item(RuleDetailColumn(11)), String).Trim
                Else
                    detaildr.Item("Logical_Symbol") = ""
                End If

                Dim isNew As String = ""
                If detailDT.Rows(i).Item(RuleDetailColumn(13)).ToString <> "" Then
                    isNew = CType(detailDT.Rows(i).Item(RuleDetailColumn(13)), String).Trim
                Else
                    isNew = ""
                End If


                If isNew.Equals("Y") Then
                    detaildr.Item("Create_User") = loginUser
                    detaildr.Item("Create_Time") = systemDate
                Else

                    If detailDT.Rows(i).Item(RuleDetailColumn(14)).ToString <> "" Then
                        detaildr.Item("Create_User") = CType(detailDT.Rows(i).Item(RuleDetailColumn(14)), String).Trim
                    Else
                        detaildr.Item("Create_User") = ""
                    End If

                    If detailDT.Rows(i).Item(RuleDetailColumn(15)).ToString <> "" Then
                        detaildr.Item("Create_Time") = CType(detailDT.Rows(i).Item(RuleDetailColumn(15)), Date)
                    Else
                        detaildr.Item("Create_Time") = CType(Now, Date)
                    End If

                    detaildr.Item("Modified_User") = loginUser
                End If

                detaildr.Item("Rule_Maintain_Sn") = initRuleMaintainSn

                ruleDetailDT.Rows.Add(detaildr)

            Next

            Return ruleDetailDT

        Else
            Return Nothing
        End If

    End Function

    Private Function uiRuleClassToDT() As DataTable
        ''1 起始 , 檢核(just關係描述,在server端補其全部)
        ''3 成功街
        ''4 失敗皆
        ''Rule_Code, Condition_Type, Seq_No, Condition_Rule_Code, Logical_Symbol, Create_User , Create_Time , Modified_User , Modified_Time

        Dim ruleClassDT As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema

        If ruleclassdr IsNot Nothing Then
            'init has old
            ruleclassdr.Item("Rule_Code") = ruleCode
            ruleclassdr.Item("Condition_Rule_Code") = initRuleCode
            ruleclassdr.Item("Modified_Time") = DBNull.Value
            ruleClassDT.Rows.Add(ruleclassdr.ItemArray)
        Else
            ruleclassdr = ruleClassDT.NewRow

            ruleclassdr.Item("Rule_Code") = ruleCode
            ruleclassdr.Item("Condition_Type") = "1"
            ruleclassdr.Item("Seq_No") = 1
            ruleclassdr.Item("Condition_Rule_Code") = initRuleCode
            'ruleclassdr.Item("Logical_Symbol") = ""
            ruleclassdr.Item("Create_User") = loginUser
            ruleclassdr.Item("Create_Time") = systemDate

            ruleClassDT.Rows.Add(ruleclassdr)
        End If

        If ucl_txt_success_cond.Text.Trim.Length > 0 Then
            If successClassdr IsNot Nothing Then
                'init has old
                successClassdr.Item("Rule_Code") = ucl_txt_success_cond.Text.Trim
                successClassdr.Item("Condition_Rule_Code") = ruleCode
                successClassdr.Item("Modified_Time") = DBNull.Value
                ruleClassDT.Rows.Add(successClassdr.ItemArray)
            Else
                successClassdr = ruleClassDT.NewRow

                successClassdr.Item("Rule_Code") = ucl_txt_success_cond.Text.Trim
                successClassdr.Item("Condition_Type") = "2"
                successClassdr.Item("Seq_No") = 1
                successClassdr.Item("Condition_Rule_Code") = ruleCode
                'successClassdr.Item("Logical_Symbol") = ""
                successClassdr.Item("Create_User") = loginUser
                successClassdr.Item("Create_Time") = systemDate

                ruleClassDT.Rows.Add(successClassdr)
            End If
        End If

        If ucl_txt_fault_cond.Text.Trim.Length > 0 Then
            If faultclassdr IsNot Nothing Then
                'init has old
                faultclassdr.Item("Rule_Code") = ucl_txt_fault_cond.Text.Trim
                faultclassdr.Item("Condition_Rule_Code") = ruleCode
                faultclassdr.Item("Modified_Time") = DBNull.Value
                ruleClassDT.Rows.Add(faultclassdr.ItemArray)
            Else
                faultclassdr = ruleClassDT.NewRow

                faultclassdr.Item("Rule_Code") = ucl_txt_fault_cond.Text.Trim
                faultclassdr.Item("Condition_Type") = "3"
                faultclassdr.Item("Seq_No") = 1
                faultclassdr.Item("Condition_Rule_Code") = ruleCode
                'faultClassdr.Item("Logical_Symbol") = ""
                faultclassdr.Item("Create_User") = loginUser
                faultclassdr.Item("Create_Time") = systemDate

                ruleClassDT.Rows.Add(faultclassdr)
            End If
        End If

        Return ruleClassDT

    End Function

    ''' <summary>
    ''' 取得ExpressStr
    ''' </summary>
    ''' <param name="classCode"></param>
    ''' <param name="fieldCode"></param>
    ''' <param name="dataType"></param>
    ''' <param name="returnCheckinFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getExpressionStr(ByVal classCode As String, ByVal fieldCode As String, ByVal dataType As String, ByVal returnCheckinFlag As String, ByVal valueData As String, Optional ByVal operation_code As String = "=") As String
        If dataTypeHash.ContainsKey(classCode) Then
            Dim express As String = CType(dataTypeHash.Item(classCode), String).Trim & "@" & fieldCode
            If dataType.Equals("1") Then '文字
                express = express & operation_code & "'" & valueData & "'"
            ElseIf dataType.Equals("4") Then '外部
                If returnCheckinFlag.Equals("N") Then
                    express = express & "=True"
                Else
                    express = express & operation_code & valueData & ""
                End If
            ElseIf dataType.Equals("5") Then '外部
                express = express & "='" & valueData & "'"
            Else
                express = express & operation_code & valueData & ""
            End If

            Return "(" & express & ")"
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' 補上預設資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub patchData()
        '補上condition
        If Not IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
            ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
        End If
        If Not IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
            ucl_dtp_end_eff_date.SetValue("2099/12/31")
        End If
        '補上grid
        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        Dim modifyFlag As Boolean = False
        If DataSetUtil.IsContainsData(gridDS) Then
            For Each dr As DataRow In gridDS.Tables(0).Rows
                If Not IsDBNull(dr.Item(RuleDetailColumn(11))) Then '條件關西

                    If CType(dr.Item(RuleDetailColumn(11)), String).Trim.Equals("") Then
                        dr.Item(RuleDetailColumn(11)) = "AND"
                        modifyFlag = True
                    Else
                        modifyFlag = True
                    End If
                Else
                    dr.Item(RuleDetailColumn(11)) = "AND"
                    modifyFlag = True
                End If
            Next
        End If
        If modifyFlag Then
            ucl_dgv_detail.Visible = False
            ucl_dgv_detail.SetDS(gridDS)
            ucl_dgv_detail.Visible = True
        End If

    End Sub



    ''' <summary>
    ''' handle 新增 or 修改
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function confirm() As Boolean

        Try

            '補上預設資料
            patchData()

            '排除非本系統規則
            Dim thisSystemFlag As Boolean = False

            Dim checkresult As Boolean = checkConditionDataComplete()

            If initRuleCode IsNot Nothing AndAlso initRuleCode.Length = 0 AndAlso ruleCode IsNot Nothing AndAlso ruleCode.Length = 0 Then
                Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim
                'TODO 取號
                If ruleCode.Equals("") Then
                    ruleCode = genRuleCode(itemCodeIni)
                End If

                If initRuleCode.Equals("") Then
                    initRuleCode = ruleCode & "-S1"
                End If
            End If

            If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 3 AndAlso initRuleCode.Substring(0, 3).Equals("PUB") Then
                thisSystemFlag = True
            Else
                thisSystemFlag = False
            End If

            If checkresult Then
                If thisSystemFlag Then

                    Dim checkgrid As Boolean = checkGridDataComplete()

                    If checkgrid Then


                        Dim confirmUI As PUBRuleConfirmQuestionUI = New PUBRuleConfirmQuestionUI(hasRuleData)
                        Dim ocnfirmDialogFlag As Boolean = confirmUI.ShowAndPrepareReturnData()

                        If ocnfirmDialogFlag Then
                            If confirmUI.SelectedConfirmType.Length > 0 Then

                                Dim checkSelectTypeMatchData As Boolean = checkSelectConfirmTypeMatchData(confirmUI.SelectedConfirmType)

                                If checkSelectTypeMatchData Then
                                    Dim ruleDS As DataSet = uiToDT(confirmUI.SelectedConfirmType)

                                    If DataSetUtil.IsContainsData(ruleDS) Then
                                        '1:.我要建立新規則
                                        '   對應處理--> 將目前畫面上資料, 另取新 Rule_Code 存檔.
                                        '2:.只是修正現行規則的錯誤
                                        '   對應處理--> 將目前畫面上資料, update目前 Rule_Code 內容.
                                        '3. 調整目前規則,增加新版本.
                                        '   對應處理--> 3-1. 將目前畫面上資料(先視為新的rule)
                                        '               3-2. 比對新rule中有效起日要大於來源rule內容中的有效起日,
                                        '                    若沒有則提室使用者錯誤, 並放棄儲存.
                                        '               3-3. 若 3-2 PASS, 將新rule內容另取新Rule_Code 儲存. 
                                        '                    同時將來源Rule 中的有效迄日改為新rule 有效起日的前一日曆天.
                                        '                    同時將新Rule 中的來源規則代碼[Original_Rule_Code]填入來源rule的 Rule_Code.
                                        'Dim dresult As DialogResult = MessageHandling.showQuestion("1:.我要建立新規則")

                                        Dim checkDefinedDT As DataTable = getDefinedInfoData() 'ForCheck

                                        ruleDS.Tables.Add(checkDefinedDT)

                                        'TODO:規則儲存前先取得原檢核規則資料 2013-11-21 黃富昌
                                        Dim strSelectedConfirmType = confirmUI.SelectedConfirmType
                                        Dim bIsRequireRecord As Boolean = False
                                        Dim dataSet As DataSet = Nothing
                                        Dim dataTable As DataTable
                                        Dim dataRow As DataRow
                                        '如果PUBRuleConfirmQuestionUI.SelectedConfirmType是修正或調整的話就記錄
                                        If Not strSelectedConfirmType = SQLDataUtil.ADD_TYPE Then bIsRequireRecord = True
                                        If bIsRequireRecord Then
                                            Dim dsRule = pub.querySelectedRuleData(Me.initSRuleCode)
                                            Dim strPubRuleDTName = "CHECK-" & PubRuleDataTableFactory.tableName
                                            Dim strPubRuleMaintainDTName = PubRuleMaintainDataTableFactory.tableName
                                            Dim dtPubRule As DataTable
                                            Dim dtPubRuleMaintain As DataTable
                                            Dim strRuleCode = String.Empty
                                            Dim strRuleName = String.Empty
                                            Dim strMaintain_Value_Str = String.Empty
                                            Dim strCheck_Condition = String.Empty
                                            If DataSetUtil.IsContainsData(dsRule) Then
                                                If dsRule.Tables.Contains(strPubRuleDTName) Then
                                                    dtPubRule = dsRule.Tables(strPubRuleDTName).Copy
                                                    strRuleCode = dtPubRule.Rows(0).Item("Rule_Code").ToString
                                                    strRuleName = dtPubRule.Rows(0).Item("Rule_Name").ToString
                                                End If
                                                If dsRule.Tables.Contains(strPubRuleMaintainDTName) Then
                                                    dtPubRuleMaintain = dsRule.Tables(strPubRuleMaintainDTName).Copy
                                                    strMaintain_Value_Str = dtPubRuleMaintain.Rows(0).Item("Maintain_Value_Str").ToString
                                                End If
                                            End If
                                            strCheck_Condition = pub.getExprre(Me.initSRuleCode)
                                            dataSet = New DataSet
                                            dataTable = PubRuleTransactionLogDataTableFactory.getDataTableWithSchema
                                            dataRow = dataTable.NewRow()
                                            dataRow("Rule_Code") = strRuleCode
                                            dataRow("Transaction_Date") = Now
                                            dataRow("Rule_Name") = strRuleName
                                            dataRow("Maintain_Value_Str") = strMaintain_Value_Str
                                            dataRow("Check_Condition") = strCheck_Condition
                                            dataRow("Transaction_Mode") = EnumTransactionMode.儲存
                                            dataRow("Transaction_User") = Me.loginUser
                                            dataTable.Rows.Add(dataRow)
                                            dataSet.Tables.Add(dataTable)
                                        End If


                                        '**********************************************************************************************************************************
                                        '檢核規則理由 (dgv_CheckReason)
                                        '**********************************************************************************************************************************

                                        '先檢核規則理由DGV有沒有初始化過
                                        If IsDgvCheckReasonInitial = False Then

                                            tbc_content.SelectedTab = TabPage1

                                            initialCheckReasonDataGridView()

                                            IsDgvCheckReasonInitial = True
                                        End If


                                        Dim dsPubRuleReason As DataSet = DataSetUtil.GenDataSet("PubRuleReason", "Rule_Code,Rule_Reason_Id,Create_User,Create_Time,Modified_User,Modified_Time".Split(","))

                                        For i = 0 To dgv_CheckReason.GetDBDS.Tables(0).Rows.Count - 1

                                            '將檢核規則理由 (dgv_CheckReason)有勾選的選項，放入要儲存的DS當中
                                            If dgv_CheckReason.GetDBDS.Tables(0).Rows(i).Item("Check").ToString = "Y" Then

                                                Dim dr As DataRow = dsPubRuleReason.Tables(0).NewRow

                                                If initSRuleCode <> "" Then
                                                    dr.Item("Rule_Code") = initSRuleCode
                                                Else
                                                    dr.Item("Rule_Code") = ruleCode 'ucl_txt_rule_name.Text.ToString
                                                End If

                                                dr.Item("Rule_Reason_Id") = dgv_CheckReason.GetDBDS.Tables(0).Rows(i).Item("Code_Id").ToString
                                                dr.Item("Create_User") = AppContext.userProfile.userId
                                                dr.Item("Create_Time") = Now
                                                dr.Item("Modified_User") = AppContext.userProfile.userId
                                                dr.Item("Modified_Time") = Now

                                                dsPubRuleReason.Tables(0).Rows.Add(dr)

                                            End If
                                        Next

                                        ruleDS.Tables.Add(dsPubRuleReason.Tables("PubRuleReason").Copy)

                                        '**********************************************************************************************************************************

                                        Dim result As Integer = -1
                                        If confirmUI.SelectedConfirmType.Equals(SQLDataUtil.ADD_TYPE) Then
                                            result = pub.confirmRuleData(SQLDataUtil.ADD_TYPE, ruleDS)
                                        ElseIf confirmUI.SelectedConfirmType.Equals(SQLDataUtil.MOD_TYPE) Then
                                            result = pub.confirmRuleData(SQLDataUtil.MOD_TYPE, ruleDS)
                                        ElseIf confirmUI.SelectedConfirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                                            result = pub.confirmRuleData(SQLDataUtil.CLONE_TYPE, ruleDS)
                                        End If

                                        If result = -1 Then
                                            ' MessageHandling.showError("資料儲存方式不存在")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"資料儲存方式不存在"}, "資料儲存方式不存在")
                                        ElseIf result = SQLDataUtil.EXECUTE_SUCCESS Then

                                            'TODO:規則儲存成功後記錄使用者更新檢核規則 2013-11-21 黃富昌
                                            If bIsRequireRecord Then
                                                pub.InsertPUB_Rule_Transaction_Log(dataSet)
                                            End If

                                            ucl_dgv_detail.ClearSelection()
                                            MessageHandling.ShowInfoMsg("CMMCMMB006")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowInfoMsg("CMMCMMB006", New String() {})
                                        ElseIf result = SQLDataUtil.EXECUTE_FAIL Then
                                            ' MessageHandling.showErrorByKey("CMMCMMD007")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowErrorMsg("CMMCMMD007", New String() {}, "系統產生error")
                                        ElseIf result = SQLDataUtil.EXECUTE_LACK_OF_DATA Then
                                            ' MessageHandling.showError("對應資料不存在")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"對應資料不存在"}, "對應資料不存在")
                                            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                            ucl_txt_belong_info.Focus()
                                        ElseIf result = SQLDataUtil.EXECUTE_LACK_OF_BASIC Then
                                            ' MessageHandling.showError("對應基本資料規則未設定")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"對應基本資料規則未設定"}, "對應基本資料規則未設定")
                                            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                            ucl_txt_belong_info.Focus()
                                        Else
                                            ' MessageHandling.showError("確認資料過程錯誤")
                                            '********************2010/2/9 Modify By Alan**********************
                                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"確認資料過程錯誤"}, "確認資料過程錯誤")
                                        End If


                                    Else
                                        ' MessageHandling.showError("規則資料不完整")
                                        '********************2010/2/9 Modify By Alan**********************
                                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"規則資料不完整"}, "規則資料不完整")
                                    End If
                                Else
                                    'MessageHandling.showInfo("畫面資料錯誤")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"畫面資料錯誤"})
                                End If




                            Else
                                '尚未選擇廚存方式
                                ' MessageHandling.showError("尚未選擇資料儲存方式")
                                '********************2010/2/9 Modify By Alan**********************
                                '  ' MessageHandling.showError ("CMMCMMB300", New String() {"尚未選擇資料儲存方式"}, "")

                            End If
                        Else
                            '沒確認,no做動作
                            ' MessageHandling.showError("尚未選取儲存方式")
                            '********************2010/2/9 Modify By Alan**********************
                            '  'MessageHandling.showErrorMsg("CMMCMMB300", New String() {"尚未選取儲存方式"}, "")
                        End If

                    Else
                        ' MessageHandling.showError("條件資料不完整")
                        '********************2010/2/9 Modify By Alan**********************
                        ' 'MessageHandling.showErrorMsg("CMMCMMB300", New String() {"條件資料不完整"}, "")
                    End If
                Else
                    ' MessageHandling.showError("非本系統新增的規則請於該系統編輯")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"非本系統新增的規則請於該系統編輯"}, "非本系統新增的規則請於該系統編輯")
                End If
            Else
                'MessageHandling.showInfo("規則資料不完整")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"規則資料不完整"})
            End If

        Catch ex As Exception

        End Try

       

    End Function

    Private Sub delete()
        'TODO
        'prepare RuleDS
        If ifuserorCreate = True Then


            If ruleCode IsNot Nothing AndAlso ruleCode.Length > 0 Then

                'TODO:規則刪除前先取得檢核規則資料 2013-11-21 黃富昌
                Dim dsRule = pub.querySelectedRuleData(Me.initSRuleCode)
                Dim strPubRuleDTName = "CHECK-" & PubRuleDataTableFactory.tableName
                Dim strPubRuleMaintainDTName = PubRuleMaintainDataTableFactory.tableName
                Dim dtPubRule As DataTable
                Dim dtPubRuleMaintain As DataTable
                Dim strRuleCode = String.Empty
                Dim strRuleName = String.Empty
                Dim strMaintain_Value_Str = String.Empty
                Dim strCheck_Condition = String.Empty
                If DataSetUtil.IsContainsData(dsRule) Then
                    If dsRule.Tables.Contains(strPubRuleDTName) Then
                        dtPubRule = dsRule.Tables(strPubRuleDTName).Copy
                        strRuleCode = dtPubRule.Rows(0).Item("Rule_Code").ToString
                        strRuleName = dtPubRule.Rows(0).Item("Rule_Name").ToString
                    End If
                    If dsRule.Tables.Contains(strPubRuleMaintainDTName) Then
                        dtPubRuleMaintain = dsRule.Tables(strPubRuleMaintainDTName).Copy
                        strMaintain_Value_Str = dtPubRuleMaintain.Rows(0).Item("Maintain_Value_Str").ToString
                    End If
                End If
                strCheck_Condition = pub.getExprre(Me.initSRuleCode)
                Dim dataSet As DataSet = New DataSet
                Dim dataTable As DataTable = PubRuleTransactionLogDataTableFactory.getDataTableWithSchema
                Dim dataRow As DataRow = dataTable.NewRow()
                dataRow("Rule_Code") = strRuleCode
                dataRow("Transaction_Date") = Now
                dataRow("Rule_Name") = strRuleName
                dataRow("Maintain_Value_Str") = strMaintain_Value_Str
                dataRow("Check_Condition") = strCheck_Condition
                dataRow("Transaction_Mode") = EnumTransactionMode.刪除
                dataRow("Transaction_User") = Me.loginUser
                dataTable.Rows.Add(dataRow)
                dataSet.Tables.Add(dataTable)

                '**********************************************************************************************************************************
                '檢核規則理由 (dgv_CheckReason)
                '**********************************************************************************************************************************

                '先檢核規則理由DGV有沒有初始化過
                If IsDgvCheckReasonInitial = False Then

                    initialCheckReasonDataGridView()

                    IsDgvCheckReasonInitial = True
                End If

                Dim resultPubRuleReason As Integer = pub.deleteByPkRuleCode(initSRuleCode) 'ucl_txt_x.Text.ToString

                '**********************************************************************************************************************************

                Dim result As Boolean = pub.deleteRuleData(ruleCode)
                If result Then

                    'TODO:規則刪除成功後記錄使用者刪除檢核規則 2013-11-21 黃富昌
                    pub.InsertPUB_Rule_Transaction_Log(dataSet)

                    clear()
                    MessageHandling.ShowInfoMsg("CMMCMMB904")
                    '********************2010/2/9 Modify By Alan**********************
                    ' MessageHandling.showInfoMsg("CMMCMMB004", New String() {})
                Else
                    ' MessageHandling.showErrorByKey("CMMCMMD004")
                    '********************2010/2/9 Modify By Alan**********************
                    ' 'MessageHandling.showErrorMsg("CMMCMMD004", New String() {}, "")
                End If
            Else
                ' MessageHandling.showError("無須刪除資料")
                '********************2010/2/9 Modify By Alan**********************
                ' 'MessageHandling.showErrorMsg("CMMCMMB300", New String() {"無須刪除資料"}, "")
            End If


            'If (initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0) AndAlso (ruleCode IsNot Nothing AndAlso ruleCode.Length > 0) Then
            '    Dim result As Boolean = pub.deleteRuleData(initRuleCode, ruleCode)
            '    If result Then
            '        clear()
            '        MessageHandling.showInfoByKey("CMMCMMB004")
            '    Else
            '       ' MessageHandling.showErrorByKey("CMMCMMD004")
            '    End If
            'Else
            '   ' MessageHandling.showError("無須刪除資料")
            'End If
        Else
            'MessageHandling.showWarn("不是同一人，只能讀取")
            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"不是同一人，只能讀取"})
        End If
    End Sub

    Private Sub clear()

        ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
        ucl_dtp_end_eff_date.SetValue("2099/12/31")


        cb_fo.Checked = True
        cb_fe.Checked = True
        cb_fi.Checked = False

        cb_boe.Checked = True
        cb_bi.Checked = False

        ucl_comb_res_strength.SelectedValue = "2"
        ucl_comb_exe_type.SelectedValue = "0"
        ucl_comb_check_ident.SelectedValue = "2"

        ucl_comb_item_belong.SelectedIndex = -1


        ucl_txt_x.Text = ""
        ucl_txt_belong_info.Text = ""
        initConditionMsg = ""
        lb_init_belong.Text = ""

        ucl_txt_rule_name.Text = ""

        ruleValidDateS = ""
        ruleValidDateE = ""

        ucl_dgv_detail.ClearDS()
        ucl_rt_successmsg.Text = ""
        ucl_txt_success_cond.Text = ""
        ucl_rt_faultmsg.Text = ""
        ucl_txt_fault_cond.Text = ""
        ucl_rt_process_msg.Text = ""


        'ucl_txt_rule_name.Text = ""
        maxSeqNo = 0
        'rule
        createUser = ""
        createTimeStr = ""
        'initdetail
        initcreateUser = ""
        initcreateTimeStr = ""
        initRuleMaintainSn = -1

        ruleclassdr = Nothing
        successClassdr = Nothing
        faultclassdr = Nothing

        initRuleCode = ""
        ruleCode = ""

        hasRuleData = False

        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(selectedItemDT.Copy)
        ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)

        ucl_txt_rule_name.Focus()

        '2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han
        Me.lblName.Text = ""

    End Sub

    ''' <summary>
    ''' 取得新的RuleCode
    ''' </summary>
    ''' <param name="itemCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function genRuleCode(ByRef itemCode As String) As String
        Return "PUB@" & itemCode & pub.getRuleSerialNo
    End Function

    ''' <summary>
    ''' 取得valuedata可供查詢條件資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getDefinedInfoData() As DataTable
        Dim definedCheckDT As DataTable = DataSetUtil.GenDataTable("ForCheck", Nothing, DefinedCheckinColumn, DefinedCheckinColumnType)
        Dim defineddr As DataRow = definedCheckDT.NewRow
        If IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
            defineddr.Item(DefinedCheckinColumn(0)) = ucl_dtp_start_eff_date.GetUsDateStr
        End If

        If IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
            defineddr.Item(DefinedCheckinColumn(1)) = ucl_dtp_end_eff_date.GetUsDateStr
        End If

        definedCheckDT.Rows.Add(defineddr)

        Return definedCheckDT

    End Function

    ''' <summary>
    ''' 檢查點選的儲存模式與畫面資料是否相容
    ''' </summary>
    ''' <param name="confirmType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkSelectConfirmTypeMatchData(ByVal confirmType As String) As Boolean

        Dim returnCheckResult As Boolean = True

        If confirmType.Equals(SQLDataUtil.ADD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.MOD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then

            Try
                Dim nowEffDateStart As String = Date.Parse(ucl_dtp_start_eff_date.GetUsDateStr).ToString("yyyy/MM/dd")

                If nowEffDateStart.CompareTo(ruleValidDateS) <= 0 Then
                    ' MessageHandling.showError("新rule中有效起日要大於來源rule內容中的有效起日")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"新rule中有效起日要大於來源rule內容中的有效起日"}, "新rule中有效起日要大於來源rule內容中的有效起日")
                    ucl_dtp_start_eff_date.Focus()
                    returnCheckResult = False
                Else

                End If

            Catch ex As Exception
                ' MessageHandling.showError("有效起日格式錯誤")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"有效起日格式錯誤"}, "")
            End Try

        End If

        Return returnCheckResult

    End Function

    ''' <summary>
    ''' 檢核訊息是否正確格式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkMessageCorrect(ByRef unprocessMsg As String, ByVal itemCode As String) As Boolean

        If unprocessMsg.Length > 0 Then

            Dim processResult As Boolean = True

            If unprocessMsg.Length > 0 AndAlso unprocessMsg.IndexOf(vbCrLf) > -1 Then
                unprocessMsg = Replace(unprocessMsg, vbCrLf, "")
            End If

            If unprocessMsg.Substring(unprocessMsg.Length - 1, 1).Equals(",") Then
                Return False
            End If

            'Dim splitMsg() As String = unprocessMsg.Split(",")
            'If splitMsg IsNot Nothing AndAlso splitMsg.Length > 0 Then
            '    For i As Integer = 0 To (splitMsg.Length - 1)
            '        If isSplitMessageCorrect(splitMsg(i)) Then

            '        Else
            '            processResult = False
            '        End If
            '    Next

            'Else
            '    processResult = False
            'End If

            If itemCode IsNot Nothing AndAlso itemCode.Length > 0 Then

                If checkItemDataHash.ContainsKey(itemCode) Then
                    Dim itemdr As DataRow = CType(checkItemDataHash.Item(itemCode), DataRow)
                    If IsDBNull(itemdr.Item("Value_Source_Program")) Then
                        '檢查是否有不合字元
                        If (unprocessMsg.IndexOf("[") > -1) Or (unprocessMsg.IndexOf("]") > -1) Or (unprocessMsg.IndexOf("-") > -1) Then
                            ' MessageHandling.showError("起始條件內容出現不合法字元")
                            processResult = False
                        End If
                    ElseIf CType(itemdr.Item("Value_Source_Program"), String).Trim.Length = 0 Then
                        '檢查是否有不合字元
                        If (unprocessMsg.IndexOf("[") > -1) Or (unprocessMsg.IndexOf("]") > -1) Or (unprocessMsg.IndexOf("-") > -1) Then
                            ' MessageHandling.showError("起始條件內容出現不合法字元")
                            processResult = False
                        End If
                    Else
                        '可填
                    End If

                End If
            End If


            Return processResult
        Else
            'no need check
            Return True

        End If

    End Function

    '''' <summary>
    '''' 細分的每項是否合法?
    '''' </summary>
    '''' <param name="splitMsg"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function isSplitMessageCorrect(ByRef splitMsg As String) As Boolean
    '    If splitMsg IsNot Nothing AndAlso splitMsg.Length > 0 Then
    '        If splitMsg.Contains("-") Then
    '            'range
    '            Dim rangeSplit() As String = splitMsg.Split("-")
    '            If rangeSplit IsNot Nothing AndAlso rangeSplit.Length = 2 Then
    '                Dim stepCorrect As Boolean = True

    '                For i As Integer = 0 To (rangeSplit.Length - 1)
    '                    If rangeSplit(i).IndexOf("X") > -1 Then
    '                        stepCorrect = False
    '                    Else

    '                    End If
    '                Next

    '                If rangeSplit(0).CompareTo(rangeSplit(1)) > 0 Then
    '                    stepCorrect = False
    '                End If

    '                Return stepCorrect

    '            Else
    '                '不合規則
    '                Return False
    '            End If
    '        Else
    '            'not range
    '            Return True
    '        End If
    '    Else
    '        Return False
    '    End If

    'End Function


    ''' <summary>
    ''' 彈出編輯valuedata視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub popEditValueDataWindow()

        If ucl_comb_item_belong.SelectedValue.Trim.Equals("D00002") Then
            '看診醫師

            Dim consultDrUI As PUBConsultDoctorUI = New PUBConsultDoctorUI(initConditionMsg)
            Dim result As Boolean = consultDrUI.ShowAndPrepareReturnData

            If result Then
                '友確認
                If consultDrUI.ValueData.Length > 30 Then
                    ucl_txt_belong_info.Text = consultDrUI.ValueData.Substring(0, 26) & ".."
                    initConditionMsg = consultDrUI.ValueData
                Else
                    ucl_txt_belong_info.Text = consultDrUI.ValueData
                    initConditionMsg = consultDrUI.ValueData
                End If
            Else

            End If

            ucl_txt_belong_info.Focus()
        Else
            Dim rangeInput As PUBRuleRangeInputUI = New PUBRuleRangeInputUI(initConditionMsg)
            rangeInput.ShowAndPrepareReturnData()

            If rangeInput.ConfirmMsg.Length > 30 Then
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg.Substring(0, 26) & ".."
                initConditionMsg = rangeInput.ConfirmMsg
            Else
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg
                initConditionMsg = rangeInput.ConfirmMsg
            End If


            ucl_txt_belong_info.Focus()
        End If


    End Sub

    ''' <summary>
    ''' 彈出複製規則視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub popCloneRuleWindow()

        If ucl_comb_item_belong.SelectedIndex > 0 Then
            '--------
            Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, QueryRuleColumn, QueryRuleColumnType)

            Dim paramdr As DataRow = paramDT.NewRow
            '{"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E"}

            If ucl_comb_item_belong.SelectedIndex > 0 Then
                paramdr.Item(QueryRuleColumn(0)) = ucl_comb_item_belong.SelectedValue.Trim
            End If

            paramDT.Rows.Add(paramdr)
            '----------------------------

            Dim cmb_itemDS As New DataSet
            cmb_itemDS.Tables.Add(selectedItemDT.Copy)
            ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)

            Dim ruleSDS As DataSet = pub.queryRuleDataByRuleParam(paramDT)

            If DataSetUtil.IsContainsData(ruleSDS) Then
                If ruleSDS.Tables.Contains(PubRuleDataTableFactory.tableName) Then

                    Dim cloneRule As PUBRuleCloneUI = New PUBRuleCloneUI(dialogItemDT.Copy, ucl_comb_item_belong.SelectedValue.Trim, initConditionMsg, ruleSDS)

                    Dim result As Boolean = cloneRule.ShowAndPrepareReturnData()
                    If result Then
                        Dim rule As String = cloneRule.Condition
                        If rule IsNot Nothing AndAlso rule.Length > 0 Then
                            '查詢出來 複製規則
                            'TODO 0105


                            Dim ruleDS As DataSet = pub.querySelectedRuleData(rule)
                            ruleDataToUI(ruleDS, True)
                            MessageHandling.ShowInfoMsg("CMMCMMB901")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowInfoMsg("CMMCMMB901")

                        Else
                            '沒選 不變
                        End If

                    Else
                        '沒確認 不變
                    End If

                End If
            End If

            ucl_txt_rule_name.Focus()
        Else
            ucl_comb_item_belong.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            ucl_comb_item_belong.Focus()
            ' MessageHandling.showErrorByKey("CMMCMMB009")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB309")

        End If

    End Sub

#End Region

#Region "########## 觸發事件 ##########"

#Region "     頁簽變更相關功能 by Kaiwen "
    Private Sub tbc_content_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbc_content.SelectedIndexChanged

        '**********************************************************************************************************************************************************************************
        '頁簽變更才進行dgv初始化
        '**********************************************************************************************************************************************************************************

        '檢核規則理由dgv_CheckReason初始化
        If IsDgvCheckReasonInitial = False AndAlso tbc_content.SelectedIndex = 2 Then

            initialCheckReasonDataGridView()

            IsDgvCheckReasonInitial = True
        End If

        '**********************************************************************************************************************************************************************************

    End Sub

#End Region

#Region "     初始化-檢核規則理由(dgv_CheckReason) "

    Private Sub initialCheckReasonDataGridView()
        Try

            '================================================================
            '初始化 dgv 的Table
            '================================================================
            Dim ds As DataSet = DataSetUtil.GenDataSet("PUB_Syscode10001", "Check,Code_Id,Code_En_Name".Split(","))
            Dim dsPubSysCode As DataSet = pub.queryPUBSysCode("10001")

            If dsPubSysCode.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow

                For Each row As DataRow In dsPubSysCode.Tables(0).Rows
                    dr = ds.Tables(0).NewRow

                    dr.Item("Check") = ""
                    dr.Item("Code_Id") = row.Item("Code_Id")
                    dr.Item("Code_En_Name") = row.Item("Code_En_Name")
              
                    ds.Tables(0).Rows.Add(dr)
                Next
             
            End If
          
           
                '初始化 Grid 的Text Cell
                Dim _hash As Hashtable = New Hashtable
                _hash.Add(-1, ds)

                '初始化 選擇
                Dim txtCellCheck As New CheckBoxCell()
                _hash.Add(0, txtCellCheck)


                '初始化 理由代碼(Code_Id)
                Dim txtCellCode_Id As New TextBoxCell()
                _hash.Add(1, txtCellCode_Id)

                '初始化 理由名稱(Code_En_Name)
                Dim txtCellUnit As New TextBoxCell()
                _hash.Add(2, txtCellUnit)



            Dim ruleDS_queryByPkRuleCode As DataSet = pub.queryRuleReasonByRuleCode(initSRuleCode)
          
            If ruleDS_queryByPkRuleCode IsNot Nothing Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    For y = 0 To ruleDS_queryByPkRuleCode.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i).Item("Code_Id").ToString = ruleDS_queryByPkRuleCode.Tables(0).Rows(y).Item("Rule_Reason_Id").ToString Then
                            ds.Tables(0).Rows(i).Item("Check") = "Y"
                        End If
                    Next
                Next
            End If
         
            '================================================================
            '初始化 dgv
            '================================================================
            dgv_CheckReason.Initial(_hash)
            dgv_CheckReason.uclHeaderText = "選擇,理由代碼,理由名稱"
            dgv_CheckReason.uclVisibleColIndex = "0,1,2"
            dgv_CheckReason.uclColumnWidth = "50,100,200"

            '================================================================


        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "     新增條件按鈕功能 "

    Private Sub btn_addgrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addgrid.Click
        Try
            addRow()
        Catch ex As Exception
            MessageHandling.ShowInfoMsg("CMMCMMB300", "新增條件按鈕失敗")
        End Try

    End Sub

    Private Sub addRow()

        Dim New_dsDgvDetail As DataSet = ucl_dgv_detail.GetDBDS.Copy

        New_dsDgvDetail.Tables(0).Rows.Add(New_dsDgvDetail.Tables(0).NewRow())

        ucl_dgv_detail.SetDS(New_dsDgvDetail)

    End Sub

#End Region

#Region "     刪除條件按鈕功能 "

    Private Sub btn_removegrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_removegrid.Click
        deleteRow()
    End Sub

    Private Sub deleteRow()

        Dim old_detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        Dim New_detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        New_detailDS.Tables(0).Clear()

        If DataSetUtil.IsContainsData(old_detailDS) Then

            '判斷是否有勾選選項
            Dim selectedIndex() As Integer = ucl_dgv_detail.GetSelectedIndex

            '若selectedIndex中有值，則進行：
            If selectedIndex IsNot Nothing AndAlso selectedIndex.Length > 0 Then

                '判斷沒有勾選的選項，並將其放置在新的New_detailDS中
                Dim UnSelectedIndex() As Integer = ucl_dgv_detail.GetUnSelectedIndex

                '若UnSelectedIndex中有值，則進行：
                If UnSelectedIndex IsNot Nothing AndAlso UnSelectedIndex.Length > 0 Then

                    '將沒有勾選的選項，並將其放置在新的New_detailDS中
                    For i As Integer = 0 To (UnSelectedIndex.Length - 1)
                        New_detailDS.Tables(0).Rows.Add(old_detailDS.Tables(0).Rows(UnSelectedIndex(i)).ItemArray)
                    Next

                Else   '若UnSelectedIndex中無值，則表示全部刪除：

                End If

                '設定與顯示ucl_dgv_detail
                ucl_dgv_detail.SetDS(New_detailDS)

            Else
                MessageHandling.ShowErrorMsg("CMMCMMB300", "尚未勾選刪除項目")
            End If

        End If

    End Sub

#End Region

#Region "     F10-儲存 按鈕功能 "

    ''' <summary>
    ''' F10-儲存 按鈕功能 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        confirm()
    End Sub

#End Region

#Region "     SF12-刪除 按鈕功能 "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        delete()
    End Sub

#End Region

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRuleCheckUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                'query()
            Case Keys.F5
                clear()
            Case Keys.F10
                confirm()
            Case Keys.Shift And Keys.F12
                delete()
        End Select

    End Sub

    Private Sub ucl_comb_item_belong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_item_belong.SelectedIndexChanged

        If initialDataFlag Then
            '初始不需動作
        Else
            If ucl_comb_item_belong.SelectedValue.Trim.Length > 0 Then
                Dim belongStr As String = IIf(belongHash.ContainsKey(ucl_comb_item_belong.SelectedValue.Trim), CType(belongHash.Item(ucl_comb_item_belong.SelectedValue.Trim), String).Trim & " = ", "")

                'lb_init_belong.Text
                If belongStr.Contains("X") Then
                    lb_x.Enabled = True
                    lb_x.Visible = True

                    '
                    Dim xind As Integer = belongStr.IndexOf("X")

                    If (belongStr.Length - 1) > xind Then
                        lb_x.Text = belongStr.Substring(0, xind)
                        lb_init_belong.Text = belongStr.Substring(xind + 1)
                    Else
                        'final len = x
                        lb_x.Text = belongStr.Substring(0, xind - 1)
                        lb_init_belong.Text = ""
                    End If

                    ucl_txt_x.Enabled = True
                    ucl_txt_x.Visible = True
                Else
                    lb_init_belong.Text = belongStr
                    ucl_txt_x.Text = ""
                    lb_x.Enabled = False
                    lb_x.Visible = False

                    ucl_txt_x.Enabled = False
                    ucl_txt_x.Visible = False

                End If

            Else
                lb_init_belong.Text = ""

                ucl_txt_x.Text = ""
                lb_x.Enabled = False
                lb_x.Visible = False

                ucl_txt_x.Enabled = False
                ucl_txt_x.Visible = False
            End If

            ucl_txt_belong_info.Text = ""
            initConditionMsg = ""

            ruleValidDateS = ""
            ruleValidDateE = ""

            '--------
            If Not IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
                ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
            End If
            If Not IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
                ucl_dtp_end_eff_date.SetValue("2099/12/31")
            End If

            cb_fo.Checked = True
            cb_fe.Checked = True
            cb_fi.Checked = False

            cb_boe.Checked = True
            cb_bi.Checked = False

            ucl_comb_res_strength.SelectedValue = "2"
            ucl_comb_exe_type.SelectedValue = "0"
            ucl_comb_check_ident.SelectedValue = "2"

            ucl_txt_rule_name.Text = ""
            ucl_rt_successmsg.Text = ""
            ucl_txt_success_cond.Text = ""
            ucl_rt_faultmsg.Text = ""
            ucl_txt_fault_cond.Text = ""
            ucl_rt_process_msg.Text = ""

            '清除掉
            'ucl_txt_rule_name.Text = ""
            maxSeqNo = 0
            'rule
            createUser = ""
            createTimeStr = ""
            'initdetail
            initcreateUser = ""
            initcreateTimeStr = ""
            initRuleMaintainSn = -1

            ruleclassdr = Nothing
            successClassdr = Nothing
            faultclassdr = Nothing


            initRuleCode = ""
            ruleCode = ""

            hasRuleData = False

            Dim cmb_itemDS As New DataSet
            cmb_itemDS.Tables.Add(selectedItemDT.Copy)
            ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)


            ucl_dgv_detail.ClearDS()

            '2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han
            Me.lblName.Text = ""

        End If


    End Sub

    Private Sub ucl_dgv_detail_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucl_dgv_detail.CellEnter
        If e.ColumnIndex = 2 Then
            Dim ds As DataSet = ucl_dgv_detail.GetDBDS
            If Not IsDBNull(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(0))) Then
                Dim type As String = CType(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(0)), String).Trim
                If checkItemClusterHash.ContainsKey(type) Then
                    Dim thisTypeDS As DataSet = New DataSet
                    Dim thisTypeDT As DataTable = CType(checkItemClusterHash.Item(type), DataTable)
                    thisTypeDS.Tables.Add(thisTypeDT.Copy)
                    ucl_dgv_detail.SetComboBoxCellDataSet(thisTypeDS, e.RowIndex, e.ColumnIndex)
                End If

            Else
                'null....no reaction
            End If
        ElseIf e.ColumnIndex = 8 Then
            Dim ds As DataSet = ucl_dgv_detail.GetDBDS
            If Not IsDBNull(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(1))) Then
                Dim type As String = CType(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(1)), String).Trim
                If checkItemUnitHash.ContainsKey(type) Then
                    Dim thisTypeDS As DataSet = New DataSet
                    Dim thisTypeDT As DataTable = CType(checkItemUnitHash.Item(type), DataTable)
                    thisTypeDS.Tables.Add(thisTypeDT.Copy)
                    ucl_dgv_detail.SetComboBoxCellDataSet(thisTypeDS, e.RowIndex, 8)
                End If


            Else
                'null....no reaction
            End If


        ElseIf e.ColumnIndex = 6 Then
            '帶出後面運算子
            Dim ds As DataSet = ucl_dgv_detail.GetDBDS
            If Not IsDBNull(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(1))) Then
                Dim rowitem As String = CType(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailColumn(1)), String).Trim
                'itemOperatorDT As DataTable

                'operandDT As DataTable
                Dim thisOperDS As DataSet = New DataSet

                If itemOperatorHash.ContainsKey(rowitem) Then

                    Dim rowItemOpeDT As DataTable = CType(itemOperatorHash.Item(rowitem), DataTable).Copy
                    thisOperDS.Tables.Add(rowItemOpeDT)
                    ucl_dgv_detail.SetComboBoxCellDataSet(thisOperDS, e.RowIndex, e.ColumnIndex)

                Else
                    thisOperDS.Tables.Add(operatorDT.Copy)
                    ucl_dgv_detail.SetComboBoxCellDataSet(thisOperDS, e.RowIndex, e.ColumnIndex)
                End If

            End If


        End If
    End Sub

    Private Sub btn_success_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_success_select.Click

        Dim succSelect As PUBContinueConditionUI = New PUBContinueConditionUI(dialogItemDT.Copy, "", ucl_txt_success_cond.Text.Trim, False)
        Dim result As Boolean = succSelect.ShowAndPrepareReturnData()
        If result Then
            ucl_txt_success_cond.Text = succSelect.Condition
        Else
            '沒確認 不變
        End If

    End Sub

    Private Sub btn_fault_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fault_select.Click
        Dim faultSelect As PUBContinueConditionUI = New PUBContinueConditionUI(dialogItemDT.Copy, "", ucl_txt_fault_cond.Text.Trim, False)
        Dim result As Boolean = faultSelect.ShowAndPrepareReturnData()
        If result Then
            ucl_txt_fault_cond.Text = faultSelect.Condition
        Else

        End If

    End Sub

    'TODO
    Private Sub ucl_txt_belong_info_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_txt_belong_info.Leave
        'ucl_comb_item_belong
        Dim useValueData As String = ""

        If initConditionMsg.Length > 30 Then
            If ((initConditionMsg.Substring(0, 26) & "..").Equals(ucl_txt_belong_info.Text.Trim)) Then
                useValueData = initConditionMsg
                'ok

                If ucl_comb_item_belong.SelectedIndex > 0 Then
                    Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
                    If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then

                        'ok
                        If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
                            ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
                        End If
                    Else
                        'msg 格式不合' MessageHandling.showError("起始條件內容出現不合法字元")
                        ' MessageHandling.showError("起始條件內容不符合規則")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
                        ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        ucl_txt_belong_info.Focus()
                    End If
                End If

            Else
                '修改過且不一致
                popEditValueDataWindow()
            End If
        Else
            '輸入
            If (ucl_txt_belong_info.Text.Equals(initConditionMsg)) Then
                '沒變
                useValueData = initConditionMsg

                If ucl_comb_item_belong.SelectedIndex > 0 Then
                    Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
                    If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then

                        'ok
                        If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
                            ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
                        End If
                    Else
                        'msg 格式不合' MessageHandling.showError("起始條件內容出現不合法字元")
                        ' MessageHandling.showError("起始條件內容不符合規則")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
                        ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        ucl_txt_belong_info.Focus()
                    End If
                End If

            Else
                'TODO檢合格式是否正確
                Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
                If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then
                    initConditionMsg = ucl_txt_belong_info.Text.Trim
                    useValueData = initConditionMsg
                    'ok


                    If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
                        ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
                    End If

                Else
                    'msg 格式不合' MessageHandling.showError("起始條件內容出現不合法字元")
                    ' MessageHandling.showError("起始條件內容不符合規則")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
                    ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    ucl_txt_belong_info.Focus()
                End If

            End If
        End If

        '2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han Start
        Me.lblName.Text = Space(18) & fGetOrderName(ucl_comb_item_belong.SelectedValue, ucl_txt_belong_info.Text.Trim)
        If Me.lblName.Text.Length > 42 Then
            Me.lblName.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Else
            Me.lblName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        End If
        '2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han End
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub


    Private Sub condition_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles condition_dtl.Click
        '彈出編輯視窗
        popEditValueDataWindow()
    End Sub

    Private Sub vtn_clone_rule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vtn_clone_rule.Click
        '彈出複製規則視窗
        popCloneRuleWindow()
    End Sub

#End Region

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han"
    ''' <summary>
    ''' 取得中文名稱
    ''' </summary>
    ''' <param name="strItem_Code"></param>
    ''' <param name="strOrder_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fGetOrderName(ByVal strItem_Code As String, ByVal strOrder_Code As String) As String
        Dim strName As String = ""
        Dim strSQL As String = ""

        If strItem_Code = "" Or strOrder_Code = "" Then
            Return strName
        End If

        Select Case strItem_Code
            Case "A00004"
                '規則歸屬項目選取『院內碼』(A00004)時
                strSQL = " Select Order_Name From PUB_Order Where Order_Code ='" & strOrder_Code & "'  and Dc = 'N'"
            Case "A00006"
                '規則歸屬項目選取『健保碼』(A00006)時
                strSQL = " select A.Order_Name  from pub_order A left join pub_order_price B on (A.order_code=B.Order_code and A.dc='N' and B.dc='N' and B.Main_Identity_Id='2') where A.order_code='" & strOrder_Code & "'"
            Case "A00021"
                '規則歸屬項目選取『病歷號』(A00021)時
                strSQL = " Select Patient_Name From PUB_Patient Where Chart_No = '" & strOrder_Code & "'"
            Case "A00022"
                '規則歸屬項目選取『健保編碼(備註代碼)』(A00022)時
                Return strName
            Case "A00024"
                '規則歸屬項目選取『適應症診斷』(A00024)時
                strSQL = " Select Disease_Name From PUB_Disease_ICD10 Where ICD_Code = '" & strOrder_Code & "'"
            Case "A00025"
                '規則歸屬項目選取『前X適應症診斷』(A00025)時
                strSQL = " Select Disease_Name From PUB_Disease_ICD10 Where ICD_Code = '" & strOrder_Code & "'"
            Case "A00026"
                '規則歸屬項目選取『限科診』(A00026)時
                strSQL = " Select Dept_Name From PUB_Department Where Dept_Code = '" & strOrder_Code & "'"
            Case "A00027"
                '規則歸屬項目選取『套裝醫令碼』(A00027)時
                strSQL = " Select Package_Name From OMO_Package Where Package_Code = '" & strOrder_Code & "'"
            Case "A00031"
                '規則歸屬項目選取『藥劑部院內12碼』(A00031)時
                strSQL = " Select Scientific_Name From OPH_Pharmacy_Base Where Pharmacy_12_Code = '" & strOrder_Code & "'"
            Case "C00012"
                '規則歸屬項目選取『開立慢箋』(C00012)時
                Return strName
            Case "D00004"
                '規則歸屬項目選取『健保門診科別』(D00004)時
                strSQL = " Select Insu_dept_Code_Name From PUB_INSU_DEPT Where Insu_Dept_Code = '" & strOrder_Code & "'"
            Case "D00005"
                '規則歸屬項目選取『就醫類型』(D00005)時
                strSQL = " Select Code_Name From PUB_Syscode Where Type_Id = 102 and Code_Id = '" & strOrder_Code & "'"
            Case "D00006"
                '規則歸屬項目選取『健保住院科別』(D00006)時
                strSQL = " Select Insu_dept_Code_Name From PUB_INSU_DEPT Where Insu_Dept_Code = '" & strOrder_Code & "'"
            Case "D00012"
                '規則歸屬項目選取『看診醫師』(D00012)時
                strSQL = " Select Employee_Name From PUB_Doctor d Join PUB_Employee e On d.Employee_Code = e.Employee_Code Where Doctor_Code= '" & strOrder_Code & "'"
            Case "D00013"
                '規則歸屬項目選取『看診科別』(D00013)時
                strSQL = " Select Dept_Name From PUB_Department Where Dept_Code = '" & strOrder_Code & "'"
            Case "K00001"
                '規則歸屬項目選取『就醫卡號』(K00001)時
                Return strName
            Case "K00007"
                '規則歸屬項目選取『案件分類』(K00007)時
                strSQL = " Select Code_Name From PUB_Syscode Where Type_Id = 504 and Code_Id = '" & strOrder_Code & "'"
            Case "K00016"
                '規則歸屬項目選取『限職業傷害診斷病』(K00016)時
                strSQL = " Select Disease_Name From PUB_Disease_ICD10 Where ICD_Code = '" & strOrder_Code & "'"
        End Select

        strName = pub.PUBRulequeryRuleNameByCode(strSQL)

        Return strName
    End Function
#End Region

#Region "2016/06/18 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han"
    Private Sub PUBRuleCheckUI_TextChanged() Handles MyBase.TextChanged

        Me.lblName.Text = Space(18) & fGetOrderName(ucl_comb_item_belong.SelectedValue, ucl_txt_belong_info.Text.Trim)
        If Me.lblName.Text.Length > 42 Then
            Me.lblName.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Else
            Me.lblName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        End If
    End Sub
#End Region
    
  
End Class

Public Class SQLDataUtil

    ''' <summary>
    ''' Server端執行"確認"完畢後的結果(待補)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared EXECUTE_SUCCESS As Integer = 1024001
    Public Shared EXECUTE_FAIL As Integer = 1024002
    Public Shared EXECUTE_LACK_OF_BASIC As Integer = 1024003
    Public Shared EXECUTE_LACK_OF_DATA As Integer = 1024004

    ''' <summary>
    ''' 取得資料後的編輯狀態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ADD_TYPE As String = "ADD_TYPE"
    Public Shared MOD_TYPE As String = "MOD_TYPE"
    Public Shared CLONE_TYPE As String = "CLONE_TYPE"
End Class