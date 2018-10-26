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

'============================
'說明：註解為old TreeList source 是舊程序使用【DevExpress.XtraTreeList.TreeList】的寫法，現在改為【UCLDataGridView】
'new source 為新添加的部分
'============================

Public Class PUBRuleCheckTreeUI
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    Public Sub New()
        initRuleCode = ""
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

    Public Sub New(ByVal queryInitRuleCode As String)
        initRuleCode = queryInitRuleCode
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim loginUser As String = AppContext.userProfile.userId
    Dim systemDate As Date = Syscom.Comm.Utility.DateUtil.getSystemDate

    '--------------------------------------
    '欄位
    '--------------------------------------
    Dim ItemColumn() As String = {"Item_Code", "Item_Name"}
    Dim ItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim QueryRuleColumn() As String = {"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E", "Value_Data"}
    Dim QueryRuleColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}

    Dim PubItemColumn() As String = {"Item_Code", "Item_Name", "Data_Type", "Return_Checking_Flag"}
    Dim PubItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}


    Dim ItemParamColumn() As String = {"Item_Code", "Item_Param"}
    Dim ItemParamColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    '--------------------------------------
    '欄位內容
    '--------------------------------------
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
    'Dim hasRuleData As Boolean = False

    Dim belongHash As Hashtable = New Hashtable
    Dim checkItemClusterHash As Hashtable = New Hashtable 'type, itemdt
    Dim checkItemDataHash As Hashtable = New Hashtable 'itemcode, dr

    'for list
    Dim itemHash As New Hashtable
    Dim itemOperatorHash As New Hashtable
    Dim valueUnitHash As New Hashtable
    Dim condHash As New Hashtable

    Dim dataTypeHash As Hashtable = New Hashtable 'syscode 802

    'Dim maxSeqNo As Integer = 0

    Dim initcreateUser As String = ""
    Dim initcreateTimeStr As String = ""
    Dim initRuleMaintainSn As Integer = 0

    'Dim ruleclassdr As DataRow = Nothing
    'Dim successClassdr As DataRow = Nothing
    'Dim faultclassdr As DataRow = Nothing

    Dim belongItemDT As DataTable
    Dim dialogItemDT As DataTable
    Dim selectedItemDT As DataTable
    Dim unitDT As DataTable
    Dim relationDT As DataTable



    '基本804運算元
    Dim operatorDT As DataTable
    Dim operatorHash As New Hashtable



    Dim ItemCodeList As ArrayList = New ArrayList
    'Dim ruleValidDateS As String = ""
    'Dim ruleValidDateE As String = ""
    Dim queryItemDT As DataTable = Nothing
    'Dim initialDataFlag As Boolean = False

    '-----------------------------------------------
    'TreeList
    Dim ruleDataClass As New PUBRuleDataClass()

    Dim myColorCheme(0 To 4) As Color
    Dim FirstLevel As Integer = 1
    Dim maxid As Integer = 1
    Dim tmpChildrenList As New ArrayList

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleCheckTreeUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try


            '-------------------------------------------------------------------------------------------
            '停用該元件 '目前已設定的規則
            '-------------------------------------------------------------------------------------------
            ucl_dgv_detail.Enabled = False
            ucl_dgv_detail.Visible = False

            gb_settedrule.Visible = False

            Me.tlp_frame.RowStyles.Item(1).Height = 0
            'Me.tlp_frame.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
            vtn_clone_rule.Visible = False '複製規則 button
            btn_query.Visible = False 'F1-查詢
            '-------------------------------------------------------------------------------------------

            loadPubServiceManager()

            '開啟keypreview
            Me.KeyPreview = True


            '歸屬條件區的X先不看見
            lb_init_belong.Text = ""
            ucl_txt_x.Text = ""
            lb_x.Enabled = False
            lb_x.Visible = False
            ucl_txt_x.Enabled = False
            ucl_txt_x.Visible = False

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
            relationDT = DataSetUtil.GenDataTable("relation", Nothing, ItemColumn, ItemColumnType)
            For i As Integer = 0 To (ConditionRelationId.Count - 1)
                Dim relationdr As DataRow = relationDT.NewRow
                relationdr.Item(ItemColumn(0)) = ConditionRelationId(i)
                relationdr.Item(ItemColumn(1)) = ConditionRelationName(i)
                relationDT.Rows.Add(relationdr)

                If Not condHash.ContainsKey(ConditionRelationId(i)) Then
                    condHash.Add(ConditionRelationId(i), ConditionRelationName(i))
                End If
            Next

            '初始元件資料
            ucl_comb_res_strength.DataSource = checkLevelDT
            ucl_comb_res_strength.uclValueIndex = "0"
            ucl_comb_res_strength.uclDisplayIndex = "1"

            ucl_comb_exe_type.DataSource = checkExeTypeDT
            ucl_comb_exe_type.uclValueIndex = "0"
            ucl_comb_exe_type.uclDisplayIndex = "1"

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

            unitDT = DataSetUtil.GenDataTable("unit", Nothing, ItemColumn, ItemColumnType)
            operatorDT = DataSetUtil.GenDataTable("operator", Nothing, ItemColumn, ItemColumnType)


            If DataSetUtil.IsContainsData(ItemDS) Then
                'syscode
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
                        '20120105 add Order_En_Name
                        operatorDT.Columns.Add("Code_En_Name")
                        For Each dr As DataRow In operandDr
                            Dim newdr As DataRow = operatorDT.NewRow
                            Dim opeId As String = CType(dr.Item("Code_Id"), String).Trim
                            Dim opeName As String = CType(dr.Item("Code_Name"), String).Trim
                            Dim opeEnName As String = CType(dr.Item("Code_En_Name"), String).Trim
                            newdr.Item(ItemColumn(0)) = opeId
                            newdr.Item(ItemColumn(1)) = opeName
                            newdr.Item("Code_En_Name") = opeEnName
                            If Not operatorHash.ContainsKey(opeId) Then
                                operatorHash.Add(opeId, opeName)
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

                        If Not valueUnitHash.ContainsKey(newdr.Item(ItemColumn(0))) Then
                            valueUnitHash.Add(newdr.Item(ItemColumn(0)), newdr.Item(ItemColumn(1)))
                        End If
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

                                If Not itemHash.ContainsKey(itemCode) Then
                                    itemHash.Add(itemCode, itemName)
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

                        End If
                    Next
                End If


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

                End If

                ucl_comb_item_belong.DataSource = belongItemDT.Copy
                ucl_comb_item_belong.uclValueIndex = "0"
                ucl_comb_item_belong.uclDisplayIndex = "1"
            End If


            ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
            ucl_dtp_end_eff_date.SetValue("2099/12/31")

            cb_fo.Checked = True
            cb_fe.Checked = True
            cb_fi.Checked = False

            cb_boe.Checked = True
            cb_bi.Checked = False

            '預設
            ucl_comb_res_strength.SelectedValue = "2"
            ucl_comb_exe_type.SelectedValue = "0"
            ucl_comb_check_ident.SelectedValue = "2"

            '------------------------------------------------------
            'TreeList 預設設定
            'tl_detail.DataSource = ruleDataClass            'old TreeList source wait
            'tl_detail.PopulateColumns()
            'tl_detail.BestFitColumns()
            'tl_detail.ExpandAll()
            InitColumnsVisibleOrder()

            ruleDataClass.Remove(ruleDataClass.Item(0))

            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source

            myColorCheme(0) = Color.LightBlue
            myColorCheme(1) = Color.LightGoldenrodYellow
            myColorCheme(2) = Color.LightGray
            myColorCheme(3) = Color.LightPink
            myColorCheme(4) = Color.LightSeaGreen

            '-------------------------------------------------------------------------
            'TODO 倒入進來的資料
            '-------------------------------------------------------------------------
            If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then
                Dim ruleDS As DataSet = pub.querySelectedTreeRuleData(initRuleCode)
                submitRuleDataToUI(ruleDS, False)
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB901")

                'initialDataFlag = False
            Else
                'initialDataFlag = False
            End If


            'Focus
            If ucl_comb_item_belong.SelectedIndex > 0 Then
                ucl_txt_rule_name.Focus()
            Else
                '無歸屬項目
                ucl_comb_item_belong.Focus()
            End If
            Me.KeyPreview = True
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
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
        Dim hasIllegalChar As Boolean = False

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

        If (Not ucl_txt_belong_info.Text.Trim.Length > 0) Then
            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_belong_info
        Else
            'checkItemDataHash
            If ucl_comb_item_belong.SelectedIndex > 0 Then
                Dim selectItem As String = ucl_comb_item_belong.SelectedValue.Trim
                If checkItemDataHash.ContainsKey(selectItem) Then
                    Dim initConditionMsg As String = ucl_txt_belong_info.Text
                    Dim itemdr As DataRow = CType(checkItemDataHash.Item(selectItem), DataRow)
                    If (IsDBNull(itemdr.Item("Value_Source_Program"))) Or (CType(itemdr.Item("Value_Source_Program"), String).Trim.Length = 0) Then
                        '檢查是否有不合字元
                        If (initConditionMsg.IndexOf("[") > -1) Or (initConditionMsg.IndexOf("]") > -1) Or (initConditionMsg.IndexOf("-") > -1) Or (initConditionMsg.Contains(",")) Then
                            hasIllegalChar = True
                            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            allPass = False
                            comp = ucl_txt_belong_info

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

            If hasIllegalChar Then
                'MessageHandling.showErrorByKey("CMMCMMB009")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB009")
            Else
                'MessageHandling.showError("起始條件內容出現不合法字元")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB300")
            End If

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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------




    '--------------------------------------------------------------------------------------------------------------
    '資料庫內Data to UI
    '--------------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' 將rule資料對應到畫面上
    ''' </summary>
    ''' <param name="ruleDS"></param>
    ''' <remarks></remarks>
    Private Sub submitRuleDataToUI(ByRef ruleDS As DataSet, ByVal cloneFlag As Boolean)

        '"INIT-" & PubRuleDataTableFactory.tableName
        '"CHECK-" & PubRuleDataTableFactory.tableName

        '清空起始條件紀錄
        initRuleCode = ""

        If DataSetUtil.IsContainsData(ruleDS) Then

            'hasRuleData = True

            '--------------------------------------
            'ruleClassToUI
            '--------------------------------------
            If ruleDS.Tables.Contains(PubRuleClassDataTableFactory.tableName) Then
                Dim ruleClassDT As DataTable = ruleDS.Tables(PubRuleClassDataTableFactory.tableName).Copy
                ruleClassToUI(ruleClassDT)

                '--------------------------------------
                'rule_detail(init)
                '--------------------------------------
                Dim initRuleDetailName As String = "INIT-" & PubRuleDetailDataTableFactory.tableName
                If ruleDS.Tables.Contains(initRuleDetailName) Then
                    Dim ruleDetailDT As DataTable = ruleDS.Tables(initRuleDetailName).Copy
                    initRuleDetailToUI(ruleDetailDT)
                End If

                '--------------------------------------
                'rule
                '--------------------------------------
                Dim initRuleName As String = "INIT-" & PubRuleDataTableFactory.tableName
                If ruleDS.Tables.Contains(initRuleName) Then
                    Dim initRuleDT As DataTable = ruleDS.Tables(initRuleName).Copy
                    initRuleToUI(initRuleDT)
                End If


                '--------------------------------------
                'rule(check)
                '--------------------------------------
                Dim checkRuleName As String = "CHECK-" & PubRuleDataTableFactory.tableName
                If ruleDS.Tables.Contains(checkRuleName) Then
                    Dim checkRuleDT As DataTable = ruleDS.Tables(checkRuleName).Copy
                    checkRuleToUI(checkRuleDT, ruleClassDT)

                    '--------------------------------------
                    'rule_detail(check)
                    '--------------------------------------
                    Dim checkRuleDetailName As String = "CHECK-" & PubRuleDetailDataTableFactory.tableName
                    If ruleDS.Tables.Contains(checkRuleDetailName) Then
                        Dim checkRuleDetailDT As DataTable = ruleDS.Tables(checkRuleDetailName).Copy
                        checkRuleDetailToUI(checkRuleDetailDT)
                    End If

                End If
            End If







            If ruleDS.Tables.Contains(PubRuleMaintainDataTableFactory.tableName) Then
                Dim ruleMaintainDT As DataTable = ruleDS.Tables(PubRuleMaintainDataTableFactory.tableName).Copy
                ruleMaintainToUI(ruleMaintainDT)
            End If

            '-----------------------------------------------------
            '是否複製規則? 是複製就RuleCode清空
            If cloneFlag Then
                'hasRuleData = False
                initRuleCode = ""

                If ruleDataClass IsNot Nothing AndAlso ruleDataClass.Count > 0 Then

                    For i As Integer = 0 To (ruleDataClass.Count - 1)
                        CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode = ""
                    Next

                    'tl_detail.RefreshDataSource()             'old TreeList source
                    'tl_detail.BestFitColumns()            'old TreeList source

                End If
            End If

        Else
            'hasRuleData = False
            '資料錯誤
            'MessageHandling.showError("無符合條件之資料")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB933")
        End If

        'new source wait
        tl_detail_RefreshDataSource()
    End Sub

    ''' <summary>
    ''' rule關係(接續動作)
    ''' </summary>
    ''' <param name="ruleClassDT"></param>
    ''' <remarks></remarks>
    Private Sub ruleClassToUI(ByRef ruleClassDT As DataTable)
        '該份資料的ruleclass
        '1 起始 , 檢核
        '3 成功接續
        '4 失敗接續
        ''
        If DataSetUtil.IsContainsData(ruleClassDT) Then
            For Each dr As DataRow In ruleClassDT.Rows
                Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim

                If conditionType.Equals("A") Then
                    initRuleCode = CType(dr.Item("Condition_Rule_Code"), String).Trim
                    'ruleclassdr = dr
                ElseIf conditionType.Equals("2") Then
                    '成功
                    ucl_txt_success_cond.Text = CType(dr.Item("Rule_Code"), String).Trim
                    'successClassdr = dr
                ElseIf conditionType.Equals("3") Then
                    '失敗
                    ucl_txt_fault_cond.Text = CType(dr.Item("Rule_Code"), String).Trim
                    'faultclassdr = dr
                End If

            Next
        End If

    End Sub

    ''' <summary>
    ''' pub_rule內容(起始條件)
    ''' </summary>
    ''' <param name="ruleDT"></param>
    ''' <remarks></remarks>
    Private Sub initRuleToUI(ByRef ruleDT As DataTable)

        If DataSetUtil.IsContainsData(ruleDT) Then

            '檢核條件匯入下面塊  XXX
            Dim initdr As DataRow = ruleDT.Rows(0)

            If initdr IsNot Nothing Then
                '20111114 Is_Sorted_ByName
                'If Not IsDBNull(initdr.Item("Is_Sorted_ByName")) Then
                If initdr.Item("Is_Sorted_ByName").ToString.Trim = "Y" Then
                    Me.ckbIsSortedByName.Checked = True
                Else
                    Me.ckbIsSortedByName.Checked = False
                End If
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
                    'ruleValidDateS = CType(initdr.Item("Valid_Date_S"), Date).ToString("yyyy/MM/dd")
                End If
                If Not IsDBNull(initdr.Item("Valid_Date_E")) Then
                    ucl_dtp_end_eff_date.SetValue(CType(initdr.Item("Valid_Date_E"), Date).ToString("yyyy/MM/dd"))
                    'ruleValidDateE = CType(initdr.Item("Valid_Date_E"), Date).ToString("yyyy/MM/dd")
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

                If Not IsDBNull(initdr.Item("Is_Enabled_Server")) Then
                    If CType(initdr.Item("Is_Enabled_Server"), String).Trim.Equals("Y") Then

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
                '失敗訊息
                If Not IsDBNull(initdr.Item("False_Message")) Then
                    ucl_rt_faultmsg.Text = CType(initdr.Item("False_Message"), String).Trim
                End If

                '提示訊息
                If Not IsDBNull(initdr.Item("Info_Message")) Then
                    ucl_rt_process_msg.Text = CType(initdr.Item("Info_Message"), String).Trim
                End If

                '提示訊息
                If Not IsDBNull(initdr.Item("Ext_No")) Then
                    txt_msg.Text = CType(initdr.Item("Ext_No"), String).Trim
                End If


                initcreateUser = CType(initdr.Item("Create_User"), String).Trim
                initcreateTimeStr = CType(initdr.Item("Create_Time"), Date).ToString("yyyy/MM/dd HH:mm:ss")

            Else
                '無檢核條件資料
            End If

        Else
            '無資料

        End If
    End Sub

    ''' <summary>
    ''' 起始條件內容值 to UI
    ''' </summary>
    ''' <param name="ruleDetailDT"></param>
    ''' <remarks></remarks>
    Private Sub initRuleDetailToUI(ByRef ruleDetailDT As DataTable)
        If DataSetUtil.IsContainsData(ruleDetailDT) Then
            '起始條件內容值
            Dim initRuleDtlDr As DataRow = ruleDetailDT.Rows(0)

            If Not IsDBNull(initRuleDtlDr.Item("Item_Code")) Then
                ucl_comb_item_belong.SelectedValue = CType(initRuleDtlDr.Item("Item_Code"), String).Trim
            End If

            If Not IsDBNull(initRuleDtlDr.Item("Value_Data")) Then
                ucl_txt_belong_info.Text = CType(initRuleDtlDr.Item("Value_Data"), String).Trim
                If Not IsDBNull(initRuleDtlDr.Item("Rule_Maintain_Sn")) Then
                    initRuleMaintainSn = CType(initRuleDtlDr.Item("Rule_Maintain_Sn"), Integer)
                End If
            End If

        End If

    End Sub

    ''' <summary>
    ''' pub_rule內容(檢核條件)
    ''' </summary>
    ''' <param name="ruleDT"></param>
    ''' <remarks></remarks>
    Private Sub checkRuleToUI(ByRef ruleDT As DataTable, ByRef ruleClassDT As DataTable)

        ruleDataClass.Clear()

        If DataSetUtil.IsContainsData(ruleClassDT) AndAlso DataSetUtil.IsContainsData(ruleDT) Then

            Dim CondAHash As New Hashtable

            '第一層
            For Each dr As DataRow In ruleClassDT.Rows
                Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim

                If conditionType.Equals("A") Then
                    Dim checkRruleCode As String = CType(dr.Item("Rule_Code"), String).Trim
                    CondAHash.Add(checkRruleCode, "")
                End If
            Next


            Dim redunRuleDT As DataTable = ruleDT.Copy
            redunRuleDT.Clear()

            Dim idIndex As Integer = 1
            '最大層數
            Dim maxlevel As Integer = 1
            For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                If Not IsDBNull(ruleDT.Rows(i).Item("Rule_Code")) Then

                    Dim checkRuleCode As String = CType(ruleDT.Rows(i).Item("Rule_Code"), String).Trim

                    If CondAHash.ContainsKey(checkRuleCode) Then
                        '找到第一層
                        'process obj
                        'Dim checkRuleObj As New PUBCheckRuleObj(ruleCode, seqNo, ucl_txt_itemdescrib.Text, ucl_comb_item.SelectedValue, ucl_txt_x.Text, ucl_txt_y.Text, ucl_txt_z.Text, ucl_comb_oper.SelectedValue, ucl_txt_belong_info.Text, ucl_comb_unit.SelectedValue, _
                        '                            isO, isE, isI, ucl_comb_condrelation.SelectedValue, isByPassCheck, inputNoticeLabelMsg)

                        Dim lv1CheckRuleObj As PUBCheckRuleObj = checkRuleDataToObj(ruleDT.Rows(i), "1", 0, idIndex)

                        idIndex = idIndex + 1

                        ruleDataClass.Add(lv1CheckRuleObj)

                    Else
                        redunRuleDT.Rows.Add(ruleDT.Rows(i).ItemArray)
                        If IsNumeric(ruleDT.Rows(i)("level").ToString.Trim) Then
                            If maxlevel < CInt(ruleDT.Rows(i)("level").ToString.Trim) Then
                                maxlevel = CInt(ruleDT.Rows(i)("level").ToString.Trim)
                            End If
                        End If

                    End If
                End If
            Next

            '--------------------------------------------------------
            '第二層(先處理到第二層)
            If DataSetUtil.IsContainsData(redunRuleDT) Then
                '20111031 處理多層子節點的情況
                For i As Integer = 2 To maxlevel
                    'ruleDataClass
                    Dim Ptlevel As String = (i - 1).ToString
                    Dim drchild() As DataRow = redunRuleDT.Select("level='" & i.ToString.Trim & "'")
                    Dim customerInfo = From cust In ruleDataClass Where cust.Level = Ptlevel 'As IEnumerable(Of PUBCheckRuleObj)
                    If customerInfo.Count > 0 Then
                        For Each row In drchild
                            Dim parentRuleCode As String = CType(row("Parent_Rule_Code"), String).Trim
                            For Each lv1CheckRuleObj As PUBCheckRuleObj In customerInfo
                                If lv1CheckRuleObj.RuleCode.Equals(parentRuleCode) Then
                                    Dim lv2CheckRuleObj As PUBCheckRuleObj = checkRuleDataToObj(row, i.ToString, lv1CheckRuleObj.id, idIndex)
                                    idIndex = idIndex + 1
                                    ruleDataClass.Add(lv2CheckRuleObj)
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                Next

                '20111031
                'For i As Integer = 0 To (redunRuleDT.Rows.Count - 1)
                '    If (Not IsDBNull(redunRuleDT.Rows(i).Item("Rule_Code"))) AndAlso (Not IsDBNull(redunRuleDT.Rows(i).Item("Parent_Rule_Code"))) Then

                '        Dim checkRuleCode As String = CType(redunRuleDT.Rows(i).Item("Rule_Code"), String).Trim
                '        Dim parentRuleCode As String = CType(redunRuleDT.Rows(i).Item("Parent_Rule_Code"), String).Trim

                '        If ruleDataClass.Count > 0 Then

                '            For j As Integer = 0 To (ruleDataClass.Count - 1)
                '                Dim lv1CheckRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(j), PUBCheckRuleObj)
                '                If lv1CheckRuleObj.RuleCode.Equals(parentRuleCode) Then

                '                    Dim lv2CheckRuleObj As PUBCheckRuleObj = checkRuleDataToObj(redunRuleDT.Rows(i), "2", lv1CheckRuleObj.id, idIndex)

                '                    idIndex = idIndex + 1

                '                    ruleDataClass.Add(lv2CheckRuleObj)

                '                End If
                '            Next

                '        End If


                '    End If
                'Next

            End If


            '------------------------------------
            'update max index
            maxid = idIndex



            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source


        Else
            '無資料

        End If
    End Sub

    ''' <summary>
    ''' 檢核規則細項to UI
    ''' 調整成物件
    ''' </summary>
    ''' <param name="ruleDetailDT"></param>
    ''' <remarks></remarks>
    Private Sub checkRuleDetailToUI(ByRef ruleDetailDT As DataTable)


        If DataSetUtil.IsContainsData(ruleDetailDT) AndAlso ruleDataClass IsNot Nothing AndAlso ruleDataClass.Count > 0 Then

            For i As Integer = 0 To (ruleDetailDT.Rows.Count - 1)
                Dim checkRuleDetailDr As DataRow = ruleDetailDT.Rows(i)

                If Not IsDBNull(checkRuleDetailDr.Item("Rule_Code")) Then
                    Dim checkRuleCode As String = checkRuleDetailDr.Item("Rule_Code")

                    For j As Integer = 0 To (ruleDataClass.Count - 1)
                        Dim listRuleCode As String = CType(ruleDataClass.Item(j), PUBCheckRuleObj).RuleCode
                        If checkRuleCode.Equals(listRuleCode) Then

                            Dim SeqNo As Integer = 0
                            If (Not IsDBNull(checkRuleDetailDr.Item("Seq_No"))) Then
                                SeqNo = CType(checkRuleDetailDr.Item("Seq_No"), Integer)
                            End If
                            Dim Item As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Item_Code"))) Then
                                Item = CType(checkRuleDetailDr.Item("Item_Code"), String).Trim
                            End If
                            Dim ParaX As String = ""
                            Dim ParaY As String = ""
                            Dim ParaZ As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Item_Param"))) Then
                                Dim splitParam() As String = CType(checkRuleDetailDr.Item("Item_Param"), String).Trim.Split(";")
                                If splitParam IsNot Nothing AndAlso splitParam.Length > 0 Then
                                    For k As Integer = 0 To (splitParam.Length - 1)
                                        If splitParam(k).Length > 2 Then
                                            If splitParam(k).Substring(0, 2).Equals("X=") Then
                                                ParaX = splitParam(k).Substring(2, (splitParam(k).Length - 2))
                                            ElseIf splitParam(k).Substring(0, 2).Equals("Y=") Then
                                                ParaY = splitParam(k).Substring(2, (splitParam(k).Length - 2))
                                            ElseIf splitParam(k).Substring(0, 2).Equals("Z=") Then
                                                ParaZ = splitParam(k).Substring(2, (splitParam(k).Length - 2))
                                            End If
                                        End If
                                    Next

                                End If
                            End If
                            Dim OperatorCode As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Operator_Code"))) Then
                                OperatorCode = CType(checkRuleDetailDr.Item("Operator_Code"), String).Trim()
                            End If
                            Dim ValueData As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Value_Data"))) Then
                                ValueData = CType(checkRuleDetailDr.Item("Value_Data"), String).Trim()
                            End If
                            Dim Unit As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Value_Unit"))) Then
                                Unit = CType(checkRuleDetailDr.Item("Value_Unit"), String).Trim()
                            End If
                            Dim CountO As Boolean = True
                            If (Not IsDBNull(checkRuleDetailDr.Item("Is_Count_O"))) Then
                                If CType(checkRuleDetailDr.Item("Is_Count_O"), String).Trim().Equals("Y") Then
                                    CountO = True
                                Else
                                    CountO = False
                                End If
                            End If
                            Dim CountE As Boolean = True
                            If (Not IsDBNull(checkRuleDetailDr.Item("Is_Count_E"))) Then
                                If CType(checkRuleDetailDr.Item("Is_Count_E"), String).Trim().Equals("Y") Then
                                    CountE = True
                                Else
                                    CountE = False
                                End If
                            End If
                            Dim CountI As Boolean = True
                            If (Not IsDBNull(checkRuleDetailDr.Item("Is_Count_I"))) Then
                                If CType(checkRuleDetailDr.Item("Is_Count_I"), String).Trim().Equals("Y") Then
                                    CountI = True
                                Else
                                    CountI = False
                                End If
                            End If
                            Dim LogicSymbol As String = ""
                            If (Not IsDBNull(checkRuleDetailDr.Item("Logical_Symbol"))) Then
                                LogicSymbol = CType(checkRuleDetailDr.Item("Logical_Symbol"), String).Trim()
                            End If

                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).SeqNo = SeqNo
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).Item = Item
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).ParaX = ParaX
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).ParaY = ParaY
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).ParaZ = ParaZ
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).OperatorCode = OperatorCode
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).ValueData = ValueData
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).Unit = Unit
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).CountO = CountO
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).CountE = CountE
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).CountI = CountI
                            CType(ruleDataClass.Item(j), PUBCheckRuleObj).LogicSymbol = LogicSymbol


                        End If
                    Next

                End If
            Next

            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source

        End If

    End Sub

    ''' <summary>
    ''' rule>>產生treelist物件
    ''' </summary>
    ''' <param name="ruleDr"></param>
    ''' <param name="level"></param>
    ''' <param name="pid"></param>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkRuleDataToObj(ByRef ruleDr As DataRow, ByRef level As String, ByRef pid As Integer, ByRef id As Integer) As PUBCheckRuleObj

        If (Not IsDBNull(ruleDr.Item("Rule_Code"))) AndAlso (Not IsDBNull(ruleDr.Item("Rule_Name"))) _
        AndAlso (Not IsDBNull(ruleDr.Item("Is_Bypass_Check"))) AndAlso (Not IsDBNull(ruleDr.Item("Input_Notice_Label"))) Then

            Dim ruleCode As String = CType(ruleDr.Item("Rule_Code"), String).Trim
            Dim SeqNo As Integer = 0
            Dim Desc As String = CType(ruleDr.Item("Rule_Name"), String).Trim
            Dim Item As String = ""
            Dim ParaX As String = ""
            Dim ParaY As String = ""
            Dim ParaZ As String = ""
            Dim OperatorCode As String = ""
            Dim ValueData As String = ""
            Dim Unit As String = ""
            Dim CountO As Boolean = True
            Dim CountE As Boolean = True
            Dim CountI As Boolean = True
            Dim LogicSymbol As String = ""


            Dim IsByPassCheck As Boolean = False
            Dim IsPriorReview As Boolean = False
            If (Not IsDBNull(ruleDr.Item("Is_Bypass_Check"))) Then
                If CType(ruleDr.Item("Is_Bypass_Check"), String).Trim.Equals("N") Then
                    IsByPassCheck = False
                Else
                    IsByPassCheck = True
                End If
            End If
            If (Not IsDBNull(ruleDr.Item("Is_Prior_Review"))) Then
                If CType(ruleDr.Item("Is_Prior_Review"), String).Trim.Equals("N") Then
                    IsPriorReview = False
                Else
                    IsPriorReview = True
                End If
            End If

            Dim InputNoticeLabel As String = ""
            If (Not IsDBNull(ruleDr.Item("Input_Notice_Label"))) Then
                InputNoticeLabel = CType(ruleDr.Item("Input_Notice_Label"), String).Trim
            End If

            Dim checkRuleObj As New PUBCheckRuleObj(itemHash, operatorHash, valueUnitHash, condHash, ruleCode, SeqNo, Desc, Item, ParaX, ParaY, ParaZ, OperatorCode, ValueData, Unit, _
                                                    CountO, CountE, CountI, LogicSymbol, IsByPassCheck, InputNoticeLabel, IsPriorReview)
            checkRuleObj.Level = level
            checkRuleObj.id = id
            checkRuleObj.pid = pid

            Return checkRuleObj

        Else

            Return Nothing

        End If

    End Function

    ''' <summary>
    ''' rulemaintain的資料Maintain_Value_Str是起始條件的值
    ''' </summary>
    ''' <param name="ruleMaintainDT"></param>
    ''' <remarks></remarks>
    Private Sub ruleMaintainToUI(ByRef ruleMaintainDT As DataTable)

        If DataSetUtil.IsContainsData(ruleMaintainDT) Then
            If Not IsDBNull(ruleMaintainDT.Rows(0).Item("Maintain_Value_Str")) Then
                ucl_txt_belong_info.Text = CType(ruleMaintainDT.Rows(0).Item("Maintain_Value_Str"), String)
            Else
                ucl_txt_belong_info.Text = ""
            End If

        Else
            ucl_txt_belong_info.Text = ""
        End If

    End Sub


    '--------------------------------------------------------------------------------------------------------------


    '---------------------------------------------------------------------------
    'ui 收集資料to DS
    '---------------------------------------------------------------------------

    ''' <summary>
    ''' 將畫面資料對應到dts,集合成DS(全部) ruleclass, rule, ruledetail
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiToDT(ByVal confirmType As String) As DataSet

        Dim confirmRuleDS As New DataSet
        Dim itemCode As String = ucl_comb_item_belong.SelectedValue.Trim

        Dim originalRuleCode As String = initRuleCode & ""
        ''看是否有做同一份資料copy儲存
        Dim ValueDataColumn() As String = {"Old_Init_Rule_Code", "Value_Data", "Valid_Date_S"}
        Dim ValueDataColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
        Dim valueDataDT As DataTable = DataSetUtil.GenDataTable("valuedata", Nothing, ValueDataColumn, ValueDataColumnType)
        Dim valuedr As DataRow = valueDataDT.NewRow
        valuedr.Item(ValueDataColumn(0)) = initRuleCode
        valuedr.Item(ValueDataColumn(1)) = ucl_txt_belong_info.Text
        valuedr.Item(ValueDataColumn(2)) = ucl_dtp_start_eff_date.GetUsDateStr
        valueDataDT.Rows.Add(valuedr)
        confirmRuleDS.Tables.Add(valueDataDT)




        If confirmType.Equals(SQLDataUtil.ADD_TYPE) Then
            giveNewRuleCode()
        ElseIf confirmType.Equals(SQLDataUtil.MOD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
            giveNewRuleCode()
        End If

        Dim ruleDT As DataTable = uiRuleToDT()
        Dim ruleMaintainDT As DataTable = uiRuleMaintainToDT()
        Dim newruleMatian_Str As String = ""
        If ruleMaintainDT.Rows.Count > 0 Then
            newruleMatian_Str = ruleMaintainDT.Rows(0).Item("Rule_Maintain_Sn").ToString
        Else
            newruleMatian_Str = initRuleMaintainSn
        End If


        Dim ruleDetailDT As DataTable = uiRuleDetailToDT(newruleMatian_Str)
        Dim ruleClassDT As DataTable = uiRuleClassToDT()

        If DataSetUtil.IsContainsData(ruleDetailDT) AndAlso DataSetUtil.IsContainsData(ruleMaintainDT) Then
            Dim ruleMaintainSn As Integer = ruleMaintainDT.Rows(0).Item("Rule_Maintain_Sn")
            For i As Integer = 0 To (ruleDetailDT.Rows.Count - 1)
                If Not IsDBNull(ruleDetailDT.Rows(i).Item("Rule_Code")) Then
                    If CType(ruleDetailDT.Rows(i).Item("Rule_Code"), String).Trim.Equals(initRuleCode) Then
                        ruleDetailDT.Rows(i).Item("Rule_Maintain_Sn") = ruleMaintainSn
                        Exit For
                    End If
                End If
            Next
        End If

        If DataSetUtil.IsContainsData(ruleDT) Then
            If confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                    If originalRuleCode.Length > 0 Then
                        ruleDT.Rows(i).Item("Original_Rule_Code") = originalRuleCode
                    End If
                Next
            End If

            confirmRuleDS.Tables.Add(ruleDT)

            If DataSetUtil.IsContainsData(ruleMaintainDT) Then
                confirmRuleDS.Tables.Add(ruleMaintainDT)
            End If

            If DataSetUtil.IsContainsData(ruleDetailDT) Then
                confirmRuleDS.Tables.Add(ruleDetailDT)
            End If

            If DataSetUtil.IsContainsData(ruleClassDT) Then
                confirmRuleDS.Tables.Add(ruleClassDT)
            End If
        End If

        Return confirmRuleDS

    End Function

    ''' <summary>
    ''' 將Pub_Rule匯到Datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiRuleToDT() As DataTable

        Dim ruleDT As DataTable = PubRuleDataTableFactory.getDataTableWithSchema
        Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim

        '------------------------------------------------------------------------------------
        '起始條件
        '------------------------------------------------------------------------------------
        ''檢查號碼(取號
        'checkOrGiveNewRuleCode()
        '20111114 依項目說明排序
        Dim isSortbyName As String = "N"
        If Me.ckbIsSortedByName.Checked Then
            isSortbyName = "Y"
        End If

        Dim initDr As DataRow = ruleDT.NewRow
        Dim Sindex As Integer = initRuleCode.LastIndexOf("S")
        initDr.Item("Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
        initDr.Item("Rule_Name") = ucl_txt_rule_name.Text.Trim
        initDr.Item("Check_Type") = ucl_comb_exe_type.SelectedValue
        initDr.Item("Is_Sorted_ByName") = isSortbyName
        '[Expression_Str]
        Dim initExpStr As New StringBuilder
        If checkItemDataHash.ContainsKey(itemCodeIni) Then
            Dim itemdr As DataRow = CType(checkItemDataHash.Item(itemCodeIni), DataRow)

            Dim valueData As String = ucl_txt_belong_info.Text
            initExpStr.Append(getExpressionStr(CType(itemdr.Item("Class_Code"), String).Trim, CType(itemdr.Item("Field_Code"), String).Trim, CType(itemdr.Item("Data_Type"), String).Trim, CType(itemdr.Item("Return_Checking_Flag"), String).Trim, valueData))

        End If
        initDr.Item("Expression_Str") = initExpStr.ToString
        initDr.Item("Check_Identity") = ucl_comb_check_ident.SelectedValue
        initDr.Item("Limit_Alert_Level") = ucl_comb_res_strength.SelectedValue

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

        If enableS Then
            initDr.Item("Is_Enabled_Server") = "Y"
        Else
            initDr.Item("Is_Enabled_Server") = "N"
        End If


        initDr.Item("True_Message") = ucl_rt_successmsg.Text
        initDr.Item("False_Message") = ucl_rt_faultmsg.Text
        initDr.Item("Info_Message") = ucl_rt_process_msg.Text
        initDr.Item("Valid_Date_S") = Date.Parse(ucl_dtp_start_eff_date.GetUsDateStr)
        initDr.Item("Valid_Date_E") = Date.Parse(ucl_dtp_end_eff_date.GetUsDateStr)

        initDr.Item("Parent_Rule_Code") = ""
        initDr.Item("Is_Bypass_Check") = "N"
        initDr.Item("Is_Prior_Review") = "N"
        initDr.Item("Input_Notice_Label") = ""

        If initcreateUser.Length > 0 AndAlso initcreateTimeStr.Length > 0 Then
            initDr.Item("Create_User") = initcreateUser
            If Not initcreateTimeStr.Equals("") Then
                Try
                    initDr.Item("Create_Time") = Date.Parse(initcreateTimeStr)
                Catch ex As Exception

                End Try
            End If

            initDr.Item("Modified_User") = loginUser
        Else
            'new
            initDr.Item("Create_User") = loginUser
            initDr.Item("Create_Time") = systemDate
        End If

        initDr.Item("Ext_No") = txt_msg.Text

        ruleDT.Rows.Add(initDr)

        '------------------------------------------------------------------------------------
        '檢核條件
        '------------------------------------------------------------------------------------

        If DataSetUtil.IsContainsData(ruleDT) Then

            If ruleDataClass IsNot Nothing Then
                '有資料,處理rule.. 1-1

                For i As Integer = 0 To (ruleDataClass.Count - 1)

                    Dim checkRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(i), PUBCheckRuleObj)

                    Dim checkDr As DataRow = ruleDT.NewRow
                    '----------------------------------------------------------------------------
                    '主面板上
                    '----------------------------------------------------------------------------
                    checkDr.Item("Check_Type") = ucl_comb_exe_type.SelectedValue '逐一/全面檢核
                    checkDr.Item("Check_Identity") = ucl_comb_check_ident.SelectedValue
                    checkDr.Item("Limit_Alert_Level") = ucl_comb_res_strength.SelectedValue

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

                    '----------------------------------------------------------------------------
                    'detail資料中
                    '----------------------------------------------------------------------------
                    checkDr.Item("Rule_Code") = checkRuleObj.RuleCode
                    checkDr.Item("Rule_Name") = checkRuleObj.Desc
                    '20111114
                    checkDr.Item("Is_Sorted_ByName") = isSortbyName
                    '[Expression_Str]
                    Dim expStr As New StringBuilder
                    Dim checkItemCode As String = checkRuleObj.Item
                    Dim checkValueData As String = checkRuleObj.ValueData
                    Dim OperatorCode As String = getOpertionCode(checkRuleObj.OperatorCode)
                    Dim relationSymbol As String = ""



                    Dim relation As String = checkRuleObj.LogicSymbol
                    If relation.Equals("AND") Then
                        relationSymbol = "&"
                    ElseIf relation.Equals("OR") Then
                        relationSymbol = "|"
                    End If






                    If checkItemDataHash.ContainsKey(checkItemCode) Then
                        Dim itemdr As DataRow = CType(checkItemDataHash.Item(checkItemCode), DataRow)
                        expStr.Append(getExpressionStr(CType(itemdr.Item("Class_Code"), String).Trim, CType(itemdr.Item("Field_Code"), String).Trim, CType(itemdr.Item("Data_Type"), String).Trim, CType(itemdr.Item("Return_Checking_Flag"), String).Trim, checkValueData, OperatorCode))
                        expStr.Append(relationSymbol)
                    End If
                    If expStr.Length > 0 Then
                        expStr.Remove(expStr.Length - 1, 1)
                        checkDr.Item("Expression_Str") = expStr.ToString
                    Else
                        checkDr.Item("Expression_Str") = ""
                    End If

                    '[Original_Rule_Code] 複制規則才會用到

                    checkDr.Item("Parent_Rule_Code") = ""

                    If checkRuleObj.pid > 0 Then
                        '有parent
                        For j As Integer = 0 To (ruleDataClass.Count - 1)
                            Dim parentRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(j), PUBCheckRuleObj)
                            If checkRuleObj.pid = parentRuleObj.id Then
                                checkDr.Item("Parent_Rule_Code") = parentRuleObj.RuleCode
                                Exit For
                            End If
                        Next
                    Else
                        '無parent,指向起始條件rulecode
                        checkDr.Item("Parent_Rule_Code") = initRuleCode
                    End If
                    If checkRuleObj.IsByPassCheck Then
                        checkDr.Item("Is_Bypass_Check") = "Y"
                    Else
                        checkDr.Item("Is_Bypass_Check") = "N"
                    End If
                    If checkRuleObj.IsPriorReview Then

                        checkDr.Item("Is_Prior_Review") = "Y"
                    Else
                        checkDr.Item("Is_Prior_Review") = "N"
                    End If


                    If checkRuleObj.InputNoticeLabel.Length > 0 Then
                        checkDr.Item("Input_Notice_Label") = checkRuleObj.InputNoticeLabel
                    Else
                        checkDr.Item("Input_Notice_Label") = ""
                    End If

                    If initcreateUser.Length > 0 AndAlso initcreateTimeStr.Length > 0 Then
                        checkDr.Item("Create_User") = initcreateUser
                        If Not initcreateTimeStr.Equals("") Then
                            Try
                                checkDr.Item("Create_Time") = Date.Parse(initcreateTimeStr)
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

                Next

            End If

        End If

        Return ruleDT

    End Function

    Function getOpertionCode(ByVal operValue As String) As String
        Dim operEnName As String = ""
        Try
            If operatorDT IsNot Nothing AndAlso operatorDT.Rows.Count > 0 Then
                If operatorDT.Columns.Contains("Code_En_Name") Then
                    Dim dr() As DataRow = operatorDT.Select(ItemColumn(0) & "='" & operValue & "'")
                    If dr IsNot Nothing AndAlso dr.Count > 0 Then
                        operEnName = dr(0)("Code_En_Name").ToString.Trim
                    End If
                End If
            End If

        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
        Return operEnName
    End Function

    ''' <summary>
    ''' 將Pub_Rule_Detail匯到Datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiRuleDetailToDT(ByVal rule_mainsn As String) As DataTable
        Dim ruleDetailDT As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema
        Dim itemName As String = ""

        '-----------------------------------------------------------------------------
        '起始Detail
        '-----------------------------------------------------------------------------
        Dim initConditionMsg As String = ucl_txt_belong_info.Text

        If initConditionMsg IsNot Nothing AndAlso initConditionMsg.Length > 0 Then

            Dim initdetaildr As DataRow = ruleDetailDT.NewRow
            Dim Sindex As Integer = initRuleCode.LastIndexOf("S")
            initdetaildr.Item("Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
            initdetaildr.Item("Item_Code") = ucl_comb_item_belong.SelectedValue.Trim
            initdetaildr.Item("Seq_No") = 1

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

            initdetaildr.Item("Rule_Maintain_Sn") = rule_mainsn

            ruleDetailDT.Rows.Add(initdetaildr)

        End If

        '-----------------------------------------------------------------------------
        '檢核detail
        '-----------------------------------------------------------------------------
        If DataSetUtil.IsContainsData(ruleDetailDT) Then
            If ruleDataClass IsNot Nothing Then
                '有資料,處理rule.. 1-1
                For i As Integer = 0 To (ruleDataClass.Count - 1)
                    Dim checkRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(i), PUBCheckRuleObj)

                    Dim detaildr As DataRow = ruleDetailDT.NewRow
                    detaildr.Item("Rule_Code") = checkRuleObj.RuleCode
                    detaildr.Item("Seq_No") = checkRuleObj.SeqNo
                    detaildr.Item("Item_Code") = checkRuleObj.Item

                    If checkItemDataHash.ContainsKey(checkRuleObj.Item) Then
                        itemName = CType(CType(checkItemDataHash.Item(checkRuleObj.Item), DataRow).Item("Item_Name"), String).Trim
                    Else
                        itemName = checkRuleObj.Item
                    End If

                    Dim dataComplete As Boolean = True

                    Dim paramStr As StringBuilder = New StringBuilder
                    If itemName.Contains("X") Then
                        If checkRuleObj.ParaX.Trim.Length > 0 Then
                            Dim xvalue As String = checkRuleObj.ParaX.Trim
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
                        If checkRuleObj.ParaY.Trim.Length > 0 Then
                            Dim xvalue As String = checkRuleObj.ParaY.Trim
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
                        If checkRuleObj.ParaZ.Trim.Length > 0 Then
                            Dim xvalue As String = checkRuleObj.ParaZ.Trim
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

                    'dataComplete

                    If paramStr.Length > 0 Then
                        paramStr.Remove(paramStr.Length - 1, 1)
                    End If
                    detaildr.Item("Item_Param") = paramStr.ToString

                    detaildr.Item("Operator_Code") = checkRuleObj.OperatorCode

                    detaildr.Item("Value_Data") = checkRuleObj.ValueData
                    detaildr.Item("Value_Unit") = checkRuleObj.Unit
                    detaildr.Item("Is_Count_O") = IIf((checkRuleObj.CountO), "Y", "N")
                    detaildr.Item("Is_Count_E") = IIf((checkRuleObj.CountE), "Y", "N")
                    detaildr.Item("Is_Count_I") = IIf((checkRuleObj.CountI), "Y", "N")
                    detaildr.Item("Logical_Symbol") = checkRuleObj.LogicSymbol

                    If Not initcreateUser.Equals("") Then
                        detaildr.Item("Create_User") = initcreateUser
                        If Not initcreateTimeStr.Equals("") Then
                            Try
                                detaildr.Item("Create_Time") = Date.Parse(initcreateTimeStr)
                            Catch ex As Exception

                            End Try
                        End If
                    Else
                        detaildr.Item("Create_User") = loginUser
                        detaildr.Item("Create_Time") = systemDate
                    End If

                    detaildr.Item("Rule_Maintain_Sn") = 0
                    'initRuleMaintainSn

                    ruleDetailDT.Rows.Add(detaildr)

                Next
            End If
        End If

        Return ruleDetailDT

    End Function

    ''' <summary>
    ''' 將Pub_Rule_Class匯到Datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiRuleClassToDT() As DataTable
        Dim ruleClassDT As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema

        '1: 起始條件  2 : 執行成功接續條件  3 : 執行失敗接續條件
        'A: 階層式(第一層)條件的起始條件

        '------------------------------------------------------------------------
        'conditionType = A 格式
        '------------------------------------------------------------------------
        Dim Sindex As Integer = initRuleCode.LastIndexOf("S")
        If ruleDataClass IsNot Nothing Then
            '有資料,處理rule.. 1-1
            For i As Integer = 0 To (ruleDataClass.Count - 1)
                Dim checkRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(i), PUBCheckRuleObj)

                If checkRuleObj.Level = FirstLevel Then
                    'class儲存第一層

                    Dim dtlClassDr As DataRow = ruleClassDT.NewRow

                    dtlClassDr.Item("Rule_Code") = checkRuleObj.RuleCode
                    dtlClassDr.Item("Condition_Type") = "A"
                    dtlClassDr.Item("Seq_No") = 1
                    dtlClassDr.Item("Condition_Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
                    dtlClassDr.Item("Logical_Symbol") = checkRuleObj.LogicSymbol
                    dtlClassDr.Item("Create_User") = loginUser
                    dtlClassDr.Item("Create_Time") = systemDate

                    ruleClassDT.Rows.Add(dtlClassDr)

                End If
            Next
        End If

        '------------------------------------------------------------------------
        'conditionType = 1 格式
        '------------------------------------------------------------------------
        Dim ruleclassdr As DataRow = ruleClassDT.NewRow
        '20111019  S後面可能有多個數字 先增一筆S1的
        ruleclassdr.Item("Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
        ruleclassdr.Item("Condition_Type") = "1"
        ruleclassdr.Item("Seq_No") = 1
        ruleclassdr.Item("Condition_Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
        ruleclassdr.Item("Logical_Symbol") = ""
        ruleclassdr.Item("Create_User") = loginUser
        ruleclassdr.Item("Create_Time") = systemDate

        ruleClassDT.Rows.Add(ruleclassdr)

        '------------------------------------------------------------------------
        'conditionType = 2 格式
        '------------------------------------------------------------------------
        If ucl_txt_success_cond.Text.Trim.Length > 0 Then

            Dim successClassdr As DataRow = ruleClassDT.NewRow

            successClassdr.Item("Rule_Code") = ucl_txt_success_cond.Text.Trim
            successClassdr.Item("Condition_Type") = "2"
            successClassdr.Item("Seq_No") = 1
            successClassdr.Item("Condition_Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
            successClassdr.Item("Logical_Symbol") = ""
            successClassdr.Item("Create_User") = loginUser
            successClassdr.Item("Create_Time") = systemDate

            ruleClassDT.Rows.Add(successClassdr)

        End If

        '------------------------------------------------------------------------
        'conditionType = 3 格式
        '------------------------------------------------------------------------
        If ucl_txt_fault_cond.Text.Trim.Length > 0 Then

            Dim faultclassdr As DataRow = ruleClassDT.NewRow

            faultclassdr.Item("Rule_Code") = ucl_txt_fault_cond.Text.Trim
            faultclassdr.Item("Condition_Type") = "3"
            faultclassdr.Item("Seq_No") = 1
            faultclassdr.Item("Condition_Rule_Code") = initRuleCode.Substring(0, Sindex + 1) & "1"
            faultclassdr.Item("Logical_Symbol") = ""
            faultclassdr.Item("Create_User") = loginUser
            faultclassdr.Item("Create_Time") = systemDate

            ruleClassDT.Rows.Add(faultclassdr)

        End If


        'If ruleclassdr IsNot Nothing Then
        '    'init has old
        '    ruleclassdr.Item("Rule_Code") = ruleCode
        '    ruleclassdr.Item("Condition_Rule_Code") = initRuleCode
        '    ruleclassdr.Item("Modified_Time") = DBNull.Value
        '    ruleClassDT.Rows.Add(ruleclassdr.ItemArray)
        'Else
        '    ruleclassdr = ruleClassDT.NewRow

        '    ruleclassdr.Item("Rule_Code") = ruleCode
        '    ruleclassdr.Item("Condition_Type") = "1"
        '    ruleclassdr.Item("Seq_No") = 1
        '    ruleclassdr.Item("Condition_Rule_Code") = initRuleCode
        '    'ruleclassdr.Item("Logical_Symbol") = ""
        '    ruleclassdr.Item("Create_User") = loginUser
        '    ruleclassdr.Item("Create_Time") = systemDate

        '    ruleClassDT.Rows.Add(ruleclassdr)
        'End If

        'If ucl_txt_success_cond.Text.Trim.Length > 0 Then
        '    If successClassdr IsNot Nothing Then
        '        'init has old
        '        successClassdr.Item("Rule_Code") = ucl_txt_success_cond.Text.Trim
        '        successClassdr.Item("Condition_Rule_Code") = ruleCode
        '        successClassdr.Item("Modified_Time") = DBNull.Value
        '        ruleClassDT.Rows.Add(successClassdr.ItemArray)
        '    Else
        '        successClassdr = ruleClassDT.NewRow

        '        successClassdr.Item("Rule_Code") = ucl_txt_success_cond.Text.Trim
        '        successClassdr.Item("Condition_Type") = "2"
        '        successClassdr.Item("Seq_No") = 1
        '        successClassdr.Item("Condition_Rule_Code") = ruleCode
        '        'successClassdr.Item("Logical_Symbol") = ""
        '        successClassdr.Item("Create_User") = loginUser
        '        successClassdr.Item("Create_Time") = systemDate

        '        ruleClassDT.Rows.Add(successClassdr)
        '    End If
        'End If

        'If ucl_txt_fault_cond.Text.Trim.Length > 0 Then
        '    If faultclassdr IsNot Nothing Then
        '        'init has old
        '        faultclassdr.Item("Rule_Code") = ucl_txt_fault_cond.Text.Trim
        '        faultclassdr.Item("Condition_Rule_Code") = ruleCode
        '        faultclassdr.Item("Modified_Time") = DBNull.Value
        '        ruleClassDT.Rows.Add(faultclassdr.ItemArray)
        '    Else
        '        faultclassdr = ruleClassDT.NewRow

        '        faultclassdr.Item("Rule_Code") = ucl_txt_fault_cond.Text.Trim
        '        faultclassdr.Item("Condition_Type") = "3"
        '        faultclassdr.Item("Seq_No") = 1
        '        faultclassdr.Item("Condition_Rule_Code") = ruleCode
        '        'faultClassdr.Item("Logical_Symbol") = ""
        '        faultclassdr.Item("Create_User") = loginUser
        '        faultclassdr.Item("Create_Time") = systemDate

        '        ruleClassDT.Rows.Add(faultclassdr)
        '    End If
        'End If

        Return ruleClassDT

    End Function

    ''' <summary>
    ''' 將Pub_Rule_Maintain匯到Datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiRuleMaintainToDT() As DataTable

        Dim seqNo As Integer = 1
        Dim RuleMaintainSn As Integer = pub.getRuleMaintainSerialNo()

        Dim ruleMaintainDT As DataTable = PubRuleMaintainDataTableFactory.getDataTableWithSchema
        Dim maintaindr As DataRow = ruleMaintainDT.NewRow

        maintaindr.Item("Rule_Maintain_Sn") = RuleMaintainSn
        maintaindr.Item("Seq_No") = seqNo
        maintaindr.Item("Item_Code") = ucl_comb_item_belong.SelectedValue
        maintaindr.Item("Maintain_Value_Str") = ucl_txt_belong_info.Text

        ruleMaintainDT.Rows.Add(maintaindr)

        Return ruleMaintainDT

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
    Private Function getExpressionStr(ByVal classCode As String, ByVal fieldCode As String, ByVal dataType As String, ByVal returnCheckinFlag As String, ByVal valueData As String, Optional ByVal Operation_Code As String = "=") As String
        If dataTypeHash.ContainsKey(classCode) Then
            Dim express As String = CType(dataTypeHash.Item(classCode), String).Trim & "@" & fieldCode
            If dataType.Equals("1") Then '文字
                express = express & Operation_Code & "'" & valueData & "'"
            ElseIf dataType.Equals("4") Then '外部
                If returnCheckinFlag.Equals("N") Then
                    express = express & "=True"
                Else
                    express = express & Operation_Code & valueData & ""
                End If
            ElseIf dataType.Equals("5") Then '外部
                express = express & "='" & valueData & "'"
            Else
                express = express & Operation_Code & valueData & ""
            End If

            Return "(" & express & ")"
        Else
            Return ""
        End If



        'If dataTypeHash.ContainsKey(classCode) Then
        '    Dim express As String = CType(dataTypeHash.Item(classCode), String).Trim & "@" & fieldCode
        '    If dataType.Equals("1") Then '文字
        '        express = express & Operation_Code & "'" & valueData & "'"
        '    ElseIf dataType.Equals("4") Then '外部
        '        If returnCheckinFlag.Equals("N") Then
        '            express = express & "=True"
        '        Else
        '            express = express & "=" & valueData & ""
        '        End If
        '    ElseIf dataType.Equals("5") Then '外部
        '        express = express & "='" & valueData & "'"
        '    Else
        '        express = express & "=" & valueData & ""
        '    End If

        '    Return "(" & express & ")"
        'Else
        '    Return ""
        'End If
    End Function

    '--------------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' 取得新的RuleCode(PUB內才可新增)
    ''' </summary>
    ''' <param name="itemCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function genRuleCode(ByRef itemCode As String) As String
        Return "ICD@" & itemCode & pub.getRuleSerialNo
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
    ''' 取新號
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub giveNewRuleCode()
        '--------------------------------------------------------------------
        ''若沒有rulecode則給新
        'If (initRuleCode Is Nothing Or initRuleCode.Length = 0) Then
        '    Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim
        '    '取號
        '    Dim ruleCode = genRuleCode(itemCodeIni)
        '    initRuleCode = ruleCode & "-S1"  '起始
        'Else
        '    'has data
        'End If

        Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim
        '取號
        Dim ruleCode = genRuleCode(itemCodeIni)
        initRuleCode = ruleCode & "-S1"  '起始

    End Sub

    ''' <summary>
    ''' 補上預設資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub patchConditionData()

        '補上condition
        If Not IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
            ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
        End If
        If Not IsDate(ucl_dtp_end_eff_date.GetUsDateStr) Then
            ucl_dtp_end_eff_date.SetValue("2099/12/31")
        End If

    End Sub


    ''' <summary>
    ''' 補上預設資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub patchCheckDetailData(ByRef confirmType As String)

        If confirmType.Equals(SQLDataUtil.ADD_TYPE) Then
            '20111114 對畫面已有資料重新存入新檔，需清除Rule_Code，然後取新序號新增
            For i As Integer = 0 To (ruleDataClass.Count - 1)
                CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode = ""
            Next
        ElseIf confirmType.Equals(SQLDataUtil.MOD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
            For i As Integer = 0 To (ruleDataClass.Count - 1)
                CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode = ""
            Next
        End If

        'ruleDataClass.Clear()
        'tmpPUBCheckRuleObj.RuleCode = genRuleCode(tmpPUBCheckRuleObj.Item)
        If ruleDataClass IsNot Nothing AndAlso ruleDataClass.Count > 0 Then
            For i As Integer = 0 To (ruleDataClass.Count - 1)
                If CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode IsNot Nothing AndAlso _
                CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode.Length > 0 Then

                Else
                    CType(ruleDataClass.Item(i), PUBCheckRuleObj).RuleCode = genRuleCode(CType(ruleDataClass.Item(i), PUBCheckRuleObj).Item)
                End If
            Next

            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source

            'new source wait
            tl_detail_RefreshDataSource()
        End If

    End Sub


    ''' <summary>
    ''' 檢查點選的儲存模式與畫面資料是否相容
    ''' </summary>
    ''' <param name="confirmType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkSelectConfirmTypeMatchData(ByVal confirmType As String, ByRef existInitRuleDT As DataTable) As Boolean

        patchCheckDetailData(confirmType)

        Dim returnCheckResult As Boolean = True

        If confirmType.Equals(SQLDataUtil.ADD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.MOD_TYPE) Then

        ElseIf confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then

            Try
                Dim nowEffDateStart As String = Date.Parse(ucl_dtp_start_eff_date.GetUsDateStr).ToString("yyyy/MM/dd")

                If DataSetUtil.IsContainsData(existInitRuleDT) AndAlso (Not IsDBNull(existInitRuleDT.Rows(0).Item("Valid_Date_S"))) Then
                    Dim ruleValidDateS As String = CType(existInitRuleDT.Rows(0).Item("Valid_Date_S"), Date).ToString("yyyy/MM/dd")
                    If nowEffDateStart.CompareTo(ruleValidDateS) <= 0 Then
                        'MessageHandling.showError("新rule中有效起日要大於來源rule內容中的有效起日")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"新rule中有效起日要大於來源rule內容中的有效起日"}, "新rule中有效起日要大於來源rule內容中的有效起日")
                        ucl_dtp_start_eff_date.Focus()
                        returnCheckResult = False
                    Else

                    End If
                End If

            Catch ex As Exception
                'MessageHandling.showError("有效起日格式錯誤")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {"有效起日格式錯誤"}, "有效起日格式錯誤")
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

            If itemCode IsNot Nothing AndAlso itemCode.Length > 0 Then

                If checkItemDataHash.ContainsKey(itemCode) Then
                    Dim itemdr As DataRow = CType(checkItemDataHash.Item(itemCode), DataRow)
                    If IsDBNull(itemdr.Item("Value_Source_Program")) Then
                        '檢查是否有不合字元
                        If (unprocessMsg.IndexOf("[") > -1) Or (unprocessMsg.IndexOf("]") > -1) Or (unprocessMsg.IndexOf("-") > -1) Then
                            'MessageHandling.showError("起始條件內容出現不合法字元")
                            processResult = False
                        End If
                    ElseIf CType(itemdr.Item("Value_Source_Program"), String).Trim.Length = 0 Then
                        '檢查是否有不合字元
                        If (unprocessMsg.IndexOf("[") > -1) Or (unprocessMsg.IndexOf("]") > -1) Or (unprocessMsg.IndexOf("-") > -1) Then
                            'MessageHandling.showError("起始條件內容出現不合法字元")
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

    ''' <summary>
    ''' 彈出編輯valuedata視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub popEditValueDataWindow()

        If ucl_comb_item_belong.SelectedValue.Trim.Equals("D00002") Then
            '看診醫師

            Dim consultDrUI As PUBConsultDoctorUI = New PUBConsultDoctorUI(ucl_txt_belong_info.Text)
            Dim result As Boolean = consultDrUI.ShowAndPrepareReturnData

            If result Then
                'has確認
                If consultDrUI.ValueData.Length > 30 Then
                    ucl_txt_belong_info.Text = consultDrUI.ValueData.Substring(0, 26) & ".."
                    ucl_txt_belong_info.Text = consultDrUI.ValueData
                Else
                    ucl_txt_belong_info.Text = consultDrUI.ValueData
                    ucl_txt_belong_info.Text = consultDrUI.ValueData
                End If
            Else

            End If

            ucl_txt_belong_info.Focus()
        Else
            Dim rangeInput As PUBRuleRangeInputUI = New PUBRuleRangeInputUI(ucl_txt_belong_info.Text)
            rangeInput.ShowAndPrepareReturnData()

            If rangeInput.ConfirmMsg.Length > 30 Then
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg.Substring(0, 26) & ".."
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg
            Else
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg
                ucl_txt_belong_info.Text = rangeInput.ConfirmMsg
            End If


            ucl_txt_belong_info.Focus()
        End If


    End Sub

    ''' <summary>
    ''' confirm = handle 新增 or 修改 X
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function confirm() As Boolean

        '先補上預設資料
        patchConditionData()

        '排除非本系統規則
        Dim thisSystemOrNewFlag As Boolean = False

        Dim checkresult As Boolean = checkConditionDataComplete()

        If checkresult Then

            '--------------------------------------------------------------------
            '是否本系統
            If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then

                If initRuleCode.Length > 3 AndAlso initRuleCode.Substring(0, 3).Equals("ICD") Then
                    thisSystemOrNewFlag = True
                Else
                    thisSystemOrNewFlag = False
                End If
            Else
                thisSystemOrNewFlag = True
            End If
            '--------------------------------------------------------------------

            If thisSystemOrNewFlag Then

                'checkOrGiveNewRuleCode()
                ''--------------------------------------------------------------------
                ''若沒有rulecode則給新
                'If initRuleCode IsNot Nothing AndAlso initRuleCode.Length = 0 AndAlso ruleCode IsNot Nothing AndAlso ruleCode.Length = 0 Then
                '    Dim itemCodeIni As String = CType(ucl_comb_item_belong.SelectedValue, String).Trim
                '    'TODO 取號
                '    If ruleCode.Equals("") Then
                '        ruleCode = genRuleCode(itemCodeIni)
                '    End If

                '    If initRuleCode.Equals("") Then
                '        initRuleCode = ruleCode & "-S1"
                '    End If
                'Else
                '    initRuleCode = ""
                '    ruleCode = ""
                'End If
                ''--------------------------------------------------------------------

                '--------------20100327
                'Dim checkgrid As Boolean = True 'checkGridDataComplete()

                'If checkgrid Then

                Dim hasRuleData As Boolean = False
                Dim existInitRuleDT As DataTable = pub.dynamicQuery("Select * from PUB_Rule where Rule_Code='" & initRuleCode & "'").Tables(0).Copy
                If DataSetUtil.IsContainsData(existInitRuleDT) Then
                    hasRuleData = True
                End If

                '選擇要確認的方式為??
                Dim confirmUI As PUBRuleConfirmQuestionUI = New PUBRuleConfirmQuestionUI(hasRuleData)
                Dim ocnfirmDialogFlag As Boolean = confirmUI.ShowAndPrepareReturnData()

                If ocnfirmDialogFlag Then
                    If confirmUI.SelectedConfirmType.Length > 0 Then

                        Dim checkSelectTypeMatchData As Boolean = checkSelectConfirmTypeMatchData(confirmUI.SelectedConfirmType, existInitRuleDT)

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

                                Dim result As Integer = -1
                                If confirmUI.SelectedConfirmType.Equals(SQLDataUtil.ADD_TYPE) Then
                                    result = pub.confirmTreeRuleData(SQLDataUtil.ADD_TYPE, ruleDS)
                                ElseIf confirmUI.SelectedConfirmType.Equals(SQLDataUtil.MOD_TYPE) Then
                                    result = pub.confirmTreeRuleData(SQLDataUtil.MOD_TYPE, ruleDS)
                                ElseIf confirmUI.SelectedConfirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                                    result = pub.confirmTreeRuleData(SQLDataUtil.CLONE_TYPE, ruleDS)
                                End If

                                If result = -1 Then
                                    'MessageHandling.showError("資料儲存方式不存在")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"資料儲存方式不存在"}, "資料儲存方式不存在")
                                ElseIf result = SQLDataUtil.EXECUTE_SUCCESS Then
                                    'ucl_dgv_detail.ClearSelection()
                                    'MessageHandling.showInfoByKey("CMMCMMB006")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.ShowInfoMsg("CMMCMMB906")
                                ElseIf result = SQLDataUtil.EXECUTE_FAIL Then
                                    'MessageHandling.showErrorByKey("CMMCMMD007")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMD007", New String() {}, "")
                                ElseIf result = SQLDataUtil.EXECUTE_LACK_OF_DATA Then
                                    'MessageHandling.showError("對應資料不存在")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"對應資料不存在"}, "對應資料不存在")
                                    ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                    ucl_txt_belong_info.Focus()
                                ElseIf result = SQLDataUtil.EXECUTE_LACK_OF_BASIC Then
                                    'MessageHandling.showError("對應基本資料規則未設定")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"對應基本資料規則未設定"}, "對應基本資料規則未設定")
                                    ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                    ucl_txt_belong_info.Focus()
                                Else
                                    'MessageHandling.showError("確認資料過程錯誤")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"確認資料過程錯誤"}, "確認資料過程錯誤")
                                End If


                            Else
                                'MessageHandling.showError("規則資料不完整")
                                '********************2010/2/9 Modify By Alan**********************
                                MessageHandling.showErrorMsg("CMMCMMB300", New String() {"規則資料不完整"}, "規則資料不完整")
                            End If
                        Else
                            'MessageHandling.showInfo("畫面資料錯誤")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showInfoMsg("CMMCMMB300", New String() {"畫面資料錯誤"})
                        End If




                    Else
                        '尚未選擇廚存方式
                        'MessageHandling.showError("尚未選擇資料儲存方式")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"尚未選擇資料儲存方式"}, "尚未選擇資料儲存方式")
                    End If
                Else
                    '沒確認,no做動作
                    'MessageHandling.showError("尚未選取儲存方式")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"尚未選取儲存方式"}, "尚未選取儲存方式")
                End If

                'Else
                '     'MessageHandling.showError("條件資料不完整")
                '    '********************2010/2/9 Modify By Alan**********************
                '  MessageHandling.showErrorMsg("CMMCMMB300", New String() {"條件資料不完整"}, "")
                'End If
            Else
                'MessageHandling.showError("非本系統新增的規則請於該系統編輯")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {"非本系統新增的規則請於該系統編輯"}, "非本系統新增的規則請於該系統編輯")
            End If
        Else
            'MessageHandling.showInfo("規則資料不完整")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB300", New String() {"規則資料不完整"})
        End If

    End Function

    ''' <summary>
    ''' 刪除該筆 X
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub delete()
        'initRuleCode

        If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then
            Dim result As Boolean = pub.deleteRuleData(initRuleCode)
            If result Then
                clear()
                'MessageHandling.showInfoByKey("CMMCMMB004")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB904")
            Else
                'MessageHandling.showErrorByKey("CMMCMMD004")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB914")
            End If
        Else
            'MessageHandling.showError("無須刪除資料")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"無須刪除資料"}, "無須刪除資料")
        End If


    End Sub

    ''' <summary>
    ''' 清除回預設
    ''' </summary>
    ''' <remarks></remarks>
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
        lb_init_belong.Text = ""

        ucl_txt_rule_name.Text = ""

        'ruleValidDateS = ""
        'ruleValidDateE = ""

        '清除treelist
        ruleDataClass.Clear()
        'tl_detail.RefreshDataSource()            'old TreeList source
        'tl_detail.BestFitColumns()            'old TreeList source
        tl_detail.ClearDS()

        ucl_rt_successmsg.Text = ""
        ucl_txt_success_cond.Text = ""
        ucl_rt_faultmsg.Text = ""
        ucl_txt_fault_cond.Text = ""
        ucl_rt_process_msg.Text = ""


        'ucl_txt_rule_name.Text = ""
        'maxSeqNo = 0
        'rule
        'createUser = ""
        'createTimeStr = ""
        'initdetail
        initcreateUser = ""
        initcreateTimeStr = ""
        initRuleMaintainSn = 0

        'ruleclassdr = Nothing
        'successClassdr = Nothing
        'faultclassdr = Nothing

        initRuleCode = ""
        'ruleCode = ""

        'hasRuleData = False

        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(selectedItemDT.Copy)
        'ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)

        ucl_comb_item_belong.Focus()
    End Sub




    '--------------------------------------------------------------------------------
    'TreeList modify method
    '--------------------------------------------------------------------------------
#Region "TreeList simulate"


    'new source
    Dim RuleDetailColumn() As String = {"項目說明", "檢查項目", "Ｘ", "Ｙ", "Ｚ", "運算項目", "值域", "單位", "合計門診", "合計急診", "合計住院", "條件關係", _
                                        "RuleCode", "Level", "SeqNo", "IsByPassCheck", "IsPriorReview", "InputNoticeLabel", "id", "pid", "prefix"}
    Dim RuleDetailColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger, DataSetUtil.TypeString, _
                                             DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
    Dim parentExpandSymbol As String = "--"
    Dim parentCollapseSymbol As String = "+"
    Dim childExpandPrefixSymbol As String = "  "
    Dim childExpandSymbol As String = "|_"


    ''' <summary>
    ''' Refresh grid by ruleDataClass(PUBCheckRuleObj list)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tl_detail_RefreshDataSource()
        tl_detail.ClearDS()
        If ruleDataClass IsNot Nothing AndAlso ruleDataClass.Count > 0 Then
            For index = 0 To ruleDataClass.Count - 1
                If ruleDataClass(index).pid = 0 Then
                    addRowToGrid(ruleDataClass(index), True, 0)
                Else
                    'find parent rowindex
                    Dim ParentRowIndex As Integer
                    For rowindex = 0 To tl_detail.Rows.Count - 1
                        If tl_detail.Rows(rowindex).Cells("id").Value() = ruleDataClass(index).pid Then
                            ParentRowIndex = rowindex
                            Exit For
                        End If
                    Next

                    addRowToGrid(ruleDataClass(index), False, ParentRowIndex) 'wait
                End If
            Next
        End If

        tl_detail.SetEditCell(0, 1)

    End Sub


    ''' <summary>
    ''' delete Row From Grid table by id
    ''' </summary>
    ''' <param name="detailDT"></param>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub deleteRowFromDS(detailDT As DataTable, id As String)
        'remove child
        For Each dr As DataRow In detailDT.Select("pid = '" & id & "'")
            deleteRowFromDS(detailDT, dr("id"))
        Next
        'remove self
        detailDT.Rows.Remove(detailDT.Select("id = '" & id & "'")(0))

    End Sub


    ''' <summary>
    ''' delete Row From Grid by rowIndex
    ''' </summary>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Private Sub deleteRowFromGrid(rowIndex As Integer)
        'new source
        tl_detail.Visible = False

        Dim detailDS As DataSet = tl_detail.GetDBDS.Copy
        Dim detailDT As DataTable = detailDS.Tables(0)
        Dim pid As String = detailDT.Rows(rowIndex)("pid")
        Dim id As String = detailDT.Rows(rowIndex)("id")

        deleteRowFromDS(detailDT, id)
        'remove 【¬-】
        If pid <> "0" Then '不是level 1 才處理
            If detailDT.Select("pid = '" & pid & "'").Length = 0 Then '已經沒有其他的兄弟
                Dim parentDr As DataRow = detailDT.Select("id = '" & pid & "'")(0)
                'If parentDr("level") = 1 Then '且父親是level 1 ，則去掉【¬-】
                Dim prefix As String = parentDr.Item(RuleDetailColumn(20))
                'parentDr.Item(RuleDetailColumn(0)) = parentDr.Item(RuleDetailColumn(0)).ToString.Replace(prefix, "")
                parentDr.Item(RuleDetailColumn(0)) = parentDr.Item(RuleDetailColumn(0)).ToString.Substring(prefix.Length)

                prefix = prefix.Replace(parentExpandSymbol, "")
                parentDr.Item(RuleDetailColumn(0)) = prefix & parentDr.Item(RuleDetailColumn(0))
                parentDr.Item(RuleDetailColumn(20)) = prefix
                'End If
            End If
        End If

        tl_detail.SetDS(detailDS)
        tl_detail.Visible = True
        For index = 0 To tl_detail.Rows.Count - 1
            tl_detail.SetRowReadOnly(index, True)
        Next

        If pid = "0" Then
            If tl_detail.Rows.Count > 0 Then
                tl_detail.SetEditCell(rowIndex, 1)
            End If
        Else
            tl_detail.SetEditCell(rowIndex - 1, 1)
        End If
    End Sub


    ''' <summary>
    ''' add PUBCheckRuleObj to Grid 
    ''' </summary>
    ''' <param name="tmpPUBCheckRuleObj"></param>
    ''' <param name="IsParent"></param>
    ''' <param name="ParentRowIndex"></param>
    ''' <remarks></remarks>
    Private Sub addRowToGrid(tmpPUBCheckRuleObj As PUBCheckRuleObj, IsParent As Boolean, ParentRowIndex As Integer)
        'new source
        tl_detail.Visible = False
        Dim rowInsertIndex As Integer = 0
        Dim desc As String = tmpPUBCheckRuleObj.Desc
        Dim prefix As String = ""

        If IsParent Then '新增條件
            tl_detail.AddNewRow()
            rowInsertIndex = tl_detail.Rows.Count
        Else '新增子項
            rowInsertIndex = ParentRowIndex + 1 ' + tl_detail.GetDBDS.Tables(0).Select("pub_rule_code = '" & ParentRowIndex & "'").count()  )
            tl_detail.AddNewRowAt(rowInsertIndex)
            rowInsertIndex = rowInsertIndex + 1
        End If

        Dim detailDS As DataSet = tl_detail.GetDBDS.Copy

        If Not IsParent Then
            '【¬-】
            Dim descParent As String = detailDS.Tables(0).Rows(ParentRowIndex).Item(RuleDetailColumn(0))
            'If detailDS.Tables(0).Rows(ParentRowIndex).Item(RuleDetailColumn(20)) = "" Then 'only for level 1
            Dim parentprefix As String = detailDS.Tables(0).Rows(ParentRowIndex).Item(RuleDetailColumn(20))
            If parentprefix.IndexOf(parentExpandSymbol) < 0 Then
                'tl_detail.Rows(ParentRowIndex).Cells("項目說明").Value = "¬-" & descParent
                detailDS.Tables(0).Rows(ParentRowIndex).Item(RuleDetailColumn(0)) = parentprefix & parentExpandSymbol & descParent.Substring(parentprefix.Length)
                detailDS.Tables(0).Rows(ParentRowIndex).Item(RuleDetailColumn(20)) = parentprefix & parentExpandSymbol
            End If
            '[|_]前綴Level-1個
            prefix = String.Concat(Enumerable.Repeat(childExpandPrefixSymbol, Integer.Parse(tmpPUBCheckRuleObj.Level) - 1)) & childExpandSymbol
            desc = prefix & desc
        End If

        With detailDS.Tables(0).Rows(rowInsertIndex - 1)
            .Item(RuleDetailColumn(0)) = desc ' tmpPUBCheckRuleObj.Desc
            .Item(RuleDetailColumn(1)) = tmpPUBCheckRuleObj.Item
            .Item(RuleDetailColumn(2)) = tmpPUBCheckRuleObj.ParaX
            .Item(RuleDetailColumn(3)) = tmpPUBCheckRuleObj.ParaY
            .Item(RuleDetailColumn(4)) = tmpPUBCheckRuleObj.ParaZ
            .Item(RuleDetailColumn(5)) = tmpPUBCheckRuleObj.OperatorCode
            .Item(RuleDetailColumn(6)) = tmpPUBCheckRuleObj.ValueData
            .Item(RuleDetailColumn(7)) = tmpPUBCheckRuleObj.Unit
            .Item(RuleDetailColumn(8)) = IIf(tmpPUBCheckRuleObj.CountO, "Y", "N")
            .Item(RuleDetailColumn(9)) = IIf(tmpPUBCheckRuleObj.CountE, "Y", "N")
            .Item(RuleDetailColumn(10)) = IIf(tmpPUBCheckRuleObj.CountI, "Y", "N")
            .Item(RuleDetailColumn(11)) = tmpPUBCheckRuleObj.LogicSymbol
            .Item(RuleDetailColumn(12)) = tmpPUBCheckRuleObj.RuleCode
            .Item(RuleDetailColumn(13)) = tmpPUBCheckRuleObj.Level
            .Item(RuleDetailColumn(14)) = tmpPUBCheckRuleObj.SeqNo
            .Item(RuleDetailColumn(15)) = tmpPUBCheckRuleObj.IsByPassCheck
            .Item(RuleDetailColumn(16)) = tmpPUBCheckRuleObj.IsPriorReview
            .Item(RuleDetailColumn(17)) = tmpPUBCheckRuleObj.InputNoticeLabel
            .Item(RuleDetailColumn(18)) = tmpPUBCheckRuleObj.id
            .Item(RuleDetailColumn(19)) = tmpPUBCheckRuleObj.pid
            .Item(RuleDetailColumn(20)) = prefix
        End With
        tl_detail.SetDS(detailDS)

        tl_detail.Visible = True
        For index = 0 To tl_detail.Rows.Count - 1
            tl_detail.SetRowReadOnly(index, True)
        Next

        tl_detail.SetEditCell(rowInsertIndex - 1, 1)

    End Sub


    ''' <summary>
    '''  fill GridRow with PUBCheckRuleObj
    ''' </summary>
    ''' <param name="tmpPUBCheckRuleObj"></param>
    ''' <param name="rowIndex"></param>
    ''' <remarks></remarks>
    Private Sub fillGridRowByPUBCheckRuleObj(tmpPUBCheckRuleObj As PUBCheckRuleObj, rowIndex As Integer)
        With tl_detail.Rows(rowIndex)
            .Cells("項目說明").Value = .Cells("prefix").Value & tmpPUBCheckRuleObj.Desc
            .Cells("檢查項目").Value = tmpPUBCheckRuleObj.ItemName
            .Cells("Ｘ").Value = tmpPUBCheckRuleObj.ParaX
            .Cells("Ｙ").Value = tmpPUBCheckRuleObj.ParaY
            .Cells("Ｚ").Value = tmpPUBCheckRuleObj.ParaZ
            .Cells("運算項目").Value = tmpPUBCheckRuleObj.OperatorName
            .Cells("值域").Value = tmpPUBCheckRuleObj.ValueData
            .Cells("單位").Value = tmpPUBCheckRuleObj.UnitName
            .Cells(8).Value = tmpPUBCheckRuleObj.CountO
            .Cells(9).Value = tmpPUBCheckRuleObj.CountE
            .Cells(10).Value = tmpPUBCheckRuleObj.CountI
            .Cells("條件關係").Value = tmpPUBCheckRuleObj.LogicSymbol

            .Cells("RuleCode").Value = tmpPUBCheckRuleObj.RuleCode
            .Cells("Level").Value = tmpPUBCheckRuleObj.Level
            .Cells("SeqNo").Value = tmpPUBCheckRuleObj.SeqNo
            .Cells("IsByPassCheck").Value = tmpPUBCheckRuleObj.IsByPassCheck
            .Cells("IsPriorReview").Value = tmpPUBCheckRuleObj.IsPriorReview
            .Cells("InputNoticeLabel").Value = tmpPUBCheckRuleObj.InputNoticeLabel
            .Cells("id").Value = tmpPUBCheckRuleObj.id
            .Cells("pid").Value = tmpPUBCheckRuleObj.pid
            '.Cells("prefix").Value

        End With
        Dim detailDS As DataSet = tl_detail.GetDBDS
        With detailDS.Tables(0).Rows(rowIndex)

            .Item(RuleDetailColumn(8)) = IIf(tmpPUBCheckRuleObj.CountO, "Y", "N")
            .Item(RuleDetailColumn(9)) = IIf(tmpPUBCheckRuleObj.CountE, "Y", "N")
            .Item(RuleDetailColumn(10)) = IIf(tmpPUBCheckRuleObj.CountI, "Y", "N")

        End With
    End Sub

    ''' <summary>
    ''' 新增treeListRow條件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addTreeListRow() As Boolean
        '20111101 增每層(Focus)節點的同一層節點
        'Dim id As Integer = 0
        ' 第一層，Parent應該是0
        Dim xpid As Integer = 0
        Dim levelnow As Integer = FirstLevel
        Dim p_screen As New PUBRuleCheckTreeDetailUI(selectedItemDT.Copy, operatorDT.Copy, unitDT.Copy, relationDT.Copy, Nothing)
        Dim result As Boolean = p_screen.ShowAndPrepareReturnData()


        If result Then

            'old TreeList source
            'If tl_detail.Nodes.Count <> 0 Then
            '    'id = tl_detail.FocusedNode.Id
            '    levelnow = tl_detail.FocusedNode.Item("Level")
            '    xpid = tl_detail.FocusedNode.Item("pid")
            'End If

            'new source
            'Dim selectedIndex As Integer = tl_detail.CurrentCellAddress.Y
            'If selectedIndex IsNot Nothing Then
            '    If selectedIndex.Length = 1 Then
            '        'levelnow = tl_detail.Rows(selectedIndex).Cells(14).Value
            '        'xpid = tl_detail.Rows(selectedIndex).Cells(29).Value
            '        levelnow = tl_detail.Rows(selectedIndex).Cells("Level").Value
            '        xpid = tl_detail.Rows(selectedIndex).Cells("pid").Value
            '    End If
            'End If

            Dim tmpPUBCheckRuleObj As PUBCheckRuleObj = p_screen.pubCheckRuleObject
            tmpPUBCheckRuleObj.Level = levelnow 'FirstLevel  'xLevel
            tmpPUBCheckRuleObj.id = maxid
            tmpPUBCheckRuleObj.pid = 0 '-1 'xpid

            'tmpPUBCheckRuleObj.RuleCode = genRuleCode(tmpPUBCheckRuleObj.Item)

            maxid = maxid + 1

            ruleDataClass.Add(tmpPUBCheckRuleObj)

            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source

            'addRowToGrid(tmpPUBCheckRuleObj, True, -1)
            addRowToGrid(tmpPUBCheckRuleObj, True, 0)

        End If
        p_screen.Close()

        Return result

    End Function

    ''' <summary>
    ''' 新增子條件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addTreeListSubRow() As Boolean
        'old TreeList source
        'If tl_detail.Nodes.Count = 0 Then Exit Function
        'new source 
        If tl_detail.Rows.Count = 0 Then Exit Function
        If tl_detail.CurrentCellAddress.Y < 0 Then Exit Function
        'Dim id As Integer = 0

        Dim p_screen As New PUBRuleCheckTreeDetailUI(selectedItemDT.Copy, operatorDT.Copy, unitDT.Copy, relationDT.Copy, Nothing)
        Dim result As Boolean = p_screen.ShowAndPrepareReturnData

        If result Then
            'id = tl_detail.FocusedNode.Id
            'Dim xpid As Integer = tl_detail.FocusedNode.Item("id")
            'Dim xLevel As Integer = tl_detail.FocusedNode.Item("Level")
            Dim selectedIndex As Integer = tl_detail.CurrentCellAddress.Y
            Dim xpid As Integer = tl_detail.Rows(selectedIndex).Cells("id").Value
            Dim xLevel As Integer = tl_detail.Rows(selectedIndex).Cells("Level").Value
            xLevel = xLevel + 1 '往下一層

            Dim tmpPUBCheckRuleObj As PUBCheckRuleObj = p_screen.pubCheckRuleObject
            tmpPUBCheckRuleObj.Level = xLevel
            tmpPUBCheckRuleObj.id = maxid
            tmpPUBCheckRuleObj.pid = xpid

            'tmpPUBCheckRuleObj.RuleCode = genRuleCode(tmpPUBCheckRuleObj.Item)

            maxid = maxid + 1

            ruleDataClass.Add(tmpPUBCheckRuleObj)

            'tl_detail.RefreshDataSource()            'old TreeList source
            'tl_detail.BestFitColumns()            'old TreeList source

            addRowToGrid(tmpPUBCheckRuleObj, False, selectedIndex)

        End If

        p_screen.Close()

        Return result

    End Function

    ''' <summary>
    ''' 修改treeListRow條件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function modTreeListRow() As Boolean
        'old TreeList source
        'Dim selectIndex As Integer = tl_detail.FocusedNode.Id
        'new source
        Dim selectIndex As Integer = tl_detail.CurrentCellAddress.Y
        If selectIndex > -1 Then
            'find ruleDataClass Index
            Dim ruleDataClassIndex As Integer
            For index = 0 To ruleDataClass.Count - 1
                If ruleDataClass(index).id = tl_detail.Rows(selectIndex).Cells("id").Value() Then
                    ruleDataClassIndex = index
                    Exit For
                End If
            Next
            'Dim checkRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(selectIndex), PUBCheckRuleObj)
            Dim checkRuleObj As PUBCheckRuleObj = CType(ruleDataClass.Item(ruleDataClassIndex), PUBCheckRuleObj)
            Dim p_screen As New PUBRuleCheckTreeDetailUI(selectedItemDT.Copy, operatorDT.Copy, unitDT.Copy, relationDT.Copy, checkRuleObj)
            Dim result As Boolean = p_screen.ShowAndPrepareReturnData()
            If result Then
                'ruleDataClass.Item(selectIndex) = p_screen.pubCheckRuleObject
                ruleDataClass.Item(ruleDataClassIndex) = p_screen.pubCheckRuleObject
                'tl_detail.RefreshDataSource()            'old TreeList source
                'tl_detail.BestFitColumns()            'old TreeList source

                'new source
                fillGridRowByPUBCheckRuleObj(p_screen.pubCheckRuleObject, selectIndex)

                p_screen.Close()
                Return True
            Else
                Return False
            End If
        Else
            '沒選
            Return False
        End If
    End Function

    ''' <summary>
    ''' 刪除點選的treelist row
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function deleteTreeListRow() As Boolean
        Try
            tmpChildrenList.Clear()
            'old TreeList source
            Dim id As Integer = 0
            'If tl_detail.Nodes.Count <> 0 Then
            If tl_detail.Rows.Count <> 0 Then
                If tl_detail.CurrentCellAddress.Y < 0 Then Exit Function

                'Dim selectIndex As Integer = tl_detail.FocusedNode.Id
                Dim selectIndex As Integer = tl_detail.CurrentCellAddress.Y
                'id = CType(ruleDataClass.Item(selectIndex), PUBCheckRuleObj).id
                id = tl_detail.Rows(selectIndex).Cells("id").Value()
                'ruleDataClass.Remove(ruleDataClass.Item(id))
                'and刪除child pid = id
                If ruleDataClass.Count > 0 Then


                    '刪該node
                    For j As Integer = 0 To (ruleDataClass.Count - 1)
                        If CType(ruleDataClass.Item(j), PUBCheckRuleObj).id = id Then
                            ruleDataClass.Remove(CType(ruleDataClass.Item(j), PUBCheckRuleObj))
                            Exit For
                        End If
                    Next

                    '刪children
                    deleteChild(ruleDataClass, id)

                    Dim removeCnt As Integer = tmpChildrenList.Count

                    Console.WriteLine(removeCnt)

                    If removeCnt > 0 Then

                        For i As Integer = 0 To (removeCnt - 1)
                            Dim contentid As Integer = CType(tmpChildrenList.Item(i), Integer)


                            For j As Integer = 0 To (ruleDataClass.Count - 1)
                                If CType(ruleDataClass.Item(j), PUBCheckRuleObj).id = contentid Then
                                    ruleDataClass.Remove(CType(ruleDataClass.Item(j), PUBCheckRuleObj))
                                    Exit For
                                End If
                            Next


                        Next

                    End If

                    'For i As Integer = 0 To (ruleDataClass.Count - 1)
                    '    Dim cpid As Integer = CType(ruleDataClass.Item(i), PUBCheckRuleObj).pid
                    '    If cpid = id Then
                    '        Dim cid As Integer = CType(ruleDataClass.Item(i), PUBCheckRuleObj).id
                    '        ruleDataClass.Remove(ruleDataClass.Item(cid))
                    '    End If
                    'Next
                    deleteRowFromGrid(selectIndex)
                End If

                'tl_detail.RefreshDataSource()            'old TreeList source
                'tl_detail.BestFitColumns()            'old TreeList source

                Return True
            Else
                Return False
            End If
        Catch e As Exception
            Dim s As String = e.ToString
        End Try
    End Function


    ''' <summary>
    ''' treelist刪除該pid的小孩(及其小小孩)
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="pid"></param>
    ''' <remarks></remarks>
    Private Sub deleteChild(ByRef list As ArrayList, ByRef pid As Integer)

        For i As Integer = 0 To (list.Count - 1)
            Dim cpid As Integer = CType(list.Item(i), PUBCheckRuleObj).pid
            If cpid = pid Then
                '找到小孩,才繼續找其下
                Dim cid As Integer = CType(list.Item(i), PUBCheckRuleObj).id

                tmpChildrenList.Add(cid)

                'list.Remove(list.Item(cid))
                deleteChild(list, cid)
            Else

            End If
        Next

    End Sub


    ''' <summary>
    ''' treelist欄位設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitColumnsVisibleOrder()
        'old TreeList source
        'tl_detail.Columns("Desc").Caption = "項目說明"
        'tl_detail.Columns("ItemName").Caption = "檢查項目"
        'tl_detail.Columns("ParaX").Caption = "X"
        'tl_detail.Columns("ParaY").Caption = "Y"
        'tl_detail.Columns("ParaZ").Caption = "Z"
        'tl_detail.Columns("OperatorName").Caption = "運算項目"
        'tl_detail.Columns("ValueData").Caption = "值域"
        'tl_detail.Columns("UnitName").Caption = "單位"
        'tl_detail.Columns("CountO").Caption = "合計門診"
        'tl_detail.Columns("CountE").Caption = "合計急診"
        'tl_detail.Columns("CountI").Caption = "合計住院"
        'tl_detail.Columns("LogicSymbolName").Caption = "條件關係"


        'tl_detail.Columns("Desc").OptionsColumn.AllowSort = False
        ''tl_detail.Columns("Desc").SortOrder = SortOrder.Ascending
        'tl_detail.Columns("ItemName").OptionsColumn.AllowSort = False
        'tl_detail.Columns("ParaX").OptionsColumn.AllowSort = False
        'tl_detail.Columns("ParaY").OptionsColumn.AllowSort = False
        'tl_detail.Columns("ParaZ").OptionsColumn.AllowSort = False
        'tl_detail.Columns("OperatorName").OptionsColumn.AllowSort = False
        'tl_detail.Columns("ValueData").OptionsColumn.AllowSort = False
        'tl_detail.Columns("UnitName").OptionsColumn.AllowSort = False
        'tl_detail.Columns("CountO").OptionsColumn.AllowSort = False
        'tl_detail.Columns("CountE").OptionsColumn.AllowSort = False
        'tl_detail.Columns("CountI").OptionsColumn.AllowSort = False
        'tl_detail.Columns("LogicSymbolName").OptionsColumn.AllowSort = False

        'tl_detail.Columns("Desc").VisibleIndex = 0
        'tl_detail.Columns("ItemName").VisibleIndex = 1
        'tl_detail.Columns("ParaX").VisibleIndex = 2
        'tl_detail.Columns("ParaY").VisibleIndex = 3
        'tl_detail.Columns("ParaZ").VisibleIndex = 4
        'tl_detail.Columns("OperatorName").VisibleIndex = 5
        'tl_detail.Columns("ValueData").VisibleIndex = 6
        'tl_detail.Columns("UnitName").VisibleIndex = 7
        'tl_detail.Columns("CountO").VisibleIndex = 8
        'tl_detail.Columns("CountE").VisibleIndex = 9
        'tl_detail.Columns("CountI").VisibleIndex = 10
        'tl_detail.Columns("LogicSymbolName").VisibleIndex = 11


        'tl_detail.Columns("Desc").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("ItemName").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("ParaX").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("ParaY").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("ParaZ").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("OperatorName").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("ValueData").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("UnitName").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("CountO").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("CountE").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("CountI").OptionsColumn.AllowEdit = False
        'tl_detail.Columns("LogicSymbolName").OptionsColumn.AllowEdit = False

        ''tl_detail.Columns("id").Visible = False
        ''tl_detail.Columns("pid").Visible = False
        'tl_detail.Columns("RuleCode").Visible = False

        'tl_detail.Columns("Item").Visible = False
        'tl_detail.Columns("OperatorCode").Visible = False
        'tl_detail.Columns("Unit").Visible = False
        'tl_detail.Columns("LogicSymbol").Visible = False

        'tl_detail.Columns("Level").Visible = False
        'tl_detail.Columns("SeqNo").Visible = False
        'tl_detail.Columns("IsByPassCheck").Visible = False
        'tl_detail.Columns("IsPriorReview").Visible = False
        'tl_detail.Columns("InputNoticeLabel").Visible = False



        Dim detailDS As DataSet = New DataSet
        Dim detailDT As DataTable = DataSetUtil.GenDataTable("detail", Nothing, RuleDetailColumn, RuleDetailColumnType)


        tl_detail.uclHeaderText = Syscom.Client.UCL.UCLDataGridViewUC.convertColumnToHeader(RuleDetailColumn)
        tl_detail.uclColumnWidth = "80,110,30,30,30,80,100,70,75,75,75,80,0,0,0,0,0,0,0,0,0"
        'tl_detail.uclColumnWidth = "80,110,30,30,30,80,80,70,60,60,60,80,0,0,0,0,0,0,0,0,60"
        tl_detail.uclColumnAlignment = "0"
        tl_detail.uclNonVisibleColIndex = "12,13,14,15,16,17,18,19,20"
        'tl_detail.uclNonVisibleColIndex = "12,13,14,15,16,17,18,19"

        'Hash版
        detailDS.Tables.Add(detailDT)
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, detailDS)


        Dim desctext_cell As New TextBoxCell()
        Dim cmb_item_cell As New ComboBoxCell()
        Dim cmb_oper_cell As New ComboBoxCell()
        Dim cmb_unit_cell As New ComboBoxCell()
        Dim cmb_rel_cell As New ComboBoxCell()
        Dim cmb_cell As New ComboBoxCell()
        Dim valuetxt_cell As New TextBoxCell()
        Dim rangetxt_cell As New TextBoxCell()

        Dim popMsgCell As New UCLPopMemoUI

        Dim chk_cell As New CheckBoxCell()

        'Item
        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(HashTableToDataTable(itemHash))
        cmb_item_cell.Ds = cmb_itemDS
        cmb_item_cell.ValueIndex = "0"
        cmb_item_cell.DisplayIndex = "1"

        'OperatorCode
        Dim cmb_operDS As New DataSet
        cmb_operDS.Tables.Add(HashTableToDataTable(operatorHash))
        cmb_oper_cell.Ds = cmb_operDS
        cmb_oper_cell.ValueIndex = "0"
        cmb_oper_cell.DisplayIndex = "1"

        'unit
        Dim cmb_unitDS As New DataSet
        cmb_unitDS.Tables.Add(HashTableToDataTable(valueUnitHash))
        cmb_unit_cell.Ds = cmb_unitDS
        cmb_unit_cell.ValueIndex = "0"
        cmb_unit_cell.DisplayIndex = "1"

        'LogicSymbol
        Dim cmb_relDS As New DataSet
        cmb_relDS.Tables.Add(HashTableToDataTable(condHash))
        cmb_rel_cell.Ds = cmb_relDS
        cmb_rel_cell.ValueIndex = "0"
        cmb_rel_cell.DisplayIndex = "1"

        ' _hashTable.Add(0, desctext_cell)
        _hashTable.Add(1, cmb_item_cell)

        valuetxt_cell.MaxLength = 20
        _hashTable.Add(2, valuetxt_cell)
        _hashTable.Add(3, valuetxt_cell)
        _hashTable.Add(4, valuetxt_cell)

        _hashTable.Add(5, cmb_oper_cell)

        'rangetxt_cell.MaxLength = 500
        '_hashTable.Add(7, rangetxt_cell)

        '--------------------------
        '20100112
        popMsgCell.setProperties(500)
        _hashTable.Add(6, popMsgCell)

        _hashTable.Add(7, cmb_unit_cell)

        _hashTable.Add(8, chk_cell)
        _hashTable.Add(9, chk_cell)
        _hashTable.Add(10, chk_cell)
        _hashTable.Add(11, cmb_rel_cell)
        'MVC的view

        tl_detail.Initial(_hashTable)

        'tl_detail.uclReadOnly = True
        '除了[選]以外，其它欄位設定為不啟用
        'Me.dgv_Data.SetRowReadOnly(dgv_Data.GetDBDS.Tables(0).Rows.Count - 1, True)
        'Me.dgv_Data.SetCellReadOnly(0, dgv_Data.GetDBDS.Tables(0).Rows.Count - 1, False)
        'not work
        '  For index = 1 To 11
        ' tl_detail.SetRowReadOnly(0, True)
        '   Next

    End Sub

    '''' <summary>
    '''' treelist欄位設定
    '''' </summary>
    '''' <remarks></remarks>
    'Public Sub InitColumnsVisibleOrder()
    '    tl_detail.Columns("Desc").Caption = "項目說明"
    '    tl_detail.Columns("Item").Caption = "檢查項目"
    '    tl_detail.Columns("ParaX").Caption = "X"
    '    tl_detail.Columns("ParaY").Caption = "Y"
    '    tl_detail.Columns("ParaZ").Caption = "Z"
    '    tl_detail.Columns("OperatorCode").Caption = "運算項目"
    '    tl_detail.Columns("ValueData").Caption = "值域"
    '    tl_detail.Columns("Unit").Caption = "單位"
    '    tl_detail.Columns("CountO").Caption = "合計門診"
    '    tl_detail.Columns("CountE").Caption = "合計急診"
    '    tl_detail.Columns("CountI").Caption = "合計住院"
    '    tl_detail.Columns("LogicSymbol").Caption = "條件關係"

    '    tl_detail.Columns("Desc").VisibleIndex = 0
    '    tl_detail.Columns("Item").VisibleIndex = 1
    '    tl_detail.Columns("ParaX").VisibleIndex = 2
    '    tl_detail.Columns("ParaY").VisibleIndex = 3
    '    tl_detail.Columns("ParaZ").VisibleIndex = 4
    '    tl_detail.Columns("OperatorCode").VisibleIndex = 5
    '    tl_detail.Columns("ValueData").VisibleIndex = 6
    '    tl_detail.Columns("Unit").VisibleIndex = 7
    '    tl_detail.Columns("CountO").VisibleIndex = 8
    '    tl_detail.Columns("CountE").VisibleIndex = 9
    '    tl_detail.Columns("CountI").VisibleIndex = 10
    '    tl_detail.Columns("LogicSymbol").VisibleIndex = 11


    '    tl_detail.Columns("Desc").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("Item").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("ParaX").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("ParaY").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("ParaZ").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("OperatorCode").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("ValueData").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("Unit").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("CountO").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("CountE").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("CountI").OptionsColumn.AllowEdit = False
    '    tl_detail.Columns("LogicSymbol").OptionsColumn.AllowEdit = False


    '    'tl_detail.Columns("id").Visible = False
    '    'tl_detail.Columns("pid").Visible = False
    '    tl_detail.Columns("RuleCode").Visible = False
    '    tl_detail.Columns("Level").Visible = False
    '    tl_detail.Columns("SeqNo").Visible = False
    '    tl_detail.Columns("IsByPassCheck").Visible = False
    '    tl_detail.Columns("InputNoticeLabel").Visible = False



    '    'Dim repositoryItemComboBoxCondRelation As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
    '    'repositoryItemComboBoxCondRelation.AllowFocused = False
    '    'repositoryItemComboBoxCondRelation.AutoHeight = False
    '    ''repositoryItemComboBoxCondRelation.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
    '    'repositoryItemComboBoxCondRelation.Items.AddRange(New Object() {"AND@@", "OR@@"})
    '    ''ConditionRelationId)

    '    'repositoryItemComboBoxCondRelation.Items.

    '    'repositoryItemComboBoxCondRelation.Name = "repositoryItemComboBoxCondRelation"



    'End Sub

    '--------------------------------------------------------------------------------

    '''' <summary>
    '''' 彈出複製規則視窗
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub popCloneRuleWindow()

    '    If ucl_comb_item_belong.SelectedIndex > 0 Then
    '        '--------
    '        Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, QueryRuleColumn, QueryRuleColumnType)

    '        Dim paramdr As DataRow = paramDT.NewRow
    '        '{"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E"}

    '        If ucl_comb_item_belong.SelectedIndex > 0 Then
    '            paramdr.Item(QueryRuleColumn(0)) = ucl_comb_item_belong.SelectedValue.Trim
    '        End If

    '        paramDT.Rows.Add(paramdr)
    '        '----------------------------

    '        Dim cmb_itemDS As New DataSet
    '        cmb_itemDS.Tables.Add(selectedItemDT.Copy)
    '        ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)

    '        Dim ruleSDS As DataSet = pub.queryRuleDataByRuleParam(paramDT)

    '        If DataSetUtil.IsContainsData(ruleSDS) Then
    '            If ruleSDS.Tables.Contains(PubRuleDataTableFactory.tableName) Then

    '                Dim cloneRule As PUBRuleCloneUI = New PUBRuleCloneUI(dialogItemDT.Copy, ucl_comb_item_belong.SelectedValue.Trim, initConditionMsg, ruleSDS)

    '                Dim result As Boolean = cloneRule.ShowAndPrepareReturnData()
    '                If result Then
    '                    Dim rule As String = cloneRule.Condition
    '                    If rule IsNot Nothing AndAlso rule.Length > 0 Then
    '                        '查詢出來 複製規則
    '                        'TODO 0105


    '                        Dim ruleDS As DataSet = pub.querySelectedRuleData(rule)
    '                        ruleDataToUI(ruleDS, True)
    '                        'MessageHandling.showInfoByKey("CMMCMMB001")
    '                        '********************2010/2/9 Modify By Alan**********************
    '                        MessageHandling.showInfoMsg("CMMCMMB001",New String(){} )

    '                    Else
    '                        '沒選 不變
    '                    End If

    '                Else
    '                    '沒確認 不變
    '                End If

    '            End If
    '        End If

    '        ucl_txt_rule_name.Focus()
    '    Else
    '        ucl_comb_item_belong.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
    '        ucl_comb_item_belong.Focus()
    '         'MessageHandling.showErrorByKey("CMMCMMB009")
    '        '********************2010/2/9 Modify By Alan**********************
    '      MessageHandling.showErrorMsg("CMMCMMB009",New String(){} ,"")

    '    End If

    'End Sub

    ''' <summary>
    ''' convert HashTable To DataTable
    ''' </summary>
    ''' <param name="hashtable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function HashTableToDataTable(hashtable As Hashtable) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Key")
        dt.Columns.Add("Value")
        For Each item In hashtable
            dt.Rows.Add(item.Key, item.Value)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' grid cell DoubleClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tl_detail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tl_detail.CellDoubleClick
        Console.WriteLine("tl_detail_CellDoubleClick")
        If e.RowIndex < 0 Then Exit Sub 'Title row
        Try
            Dim result As Boolean = modTreeListRow()
            If result Then
                MessageHandling.ShowInfoMsg("CMMCMMB903")
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
    End Sub


    ''' <summary>
    ''' grid column 1 Click simulate treelist
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tl_detail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tl_detail.CellClick
        Console.WriteLine("tl_detail_CellClick")
        If e.RowIndex < 0 Then Exit Sub 'Title row
        If tl_detail.CurrentCellAddress.X <> 0 Then Exit Sub
        Dim selectIndex As Integer = tl_detail.CurrentCellAddress.Y
        Dim detailDS As DataSet = tl_detail.GetDBDS
        Dim detailDT As DataTable = detailDS.Tables(0)
        Dim prefix As String = detailDT.Rows(selectIndex)("prefix")
        Dim id As String = detailDT.Rows(selectIndex)("id")

        If prefix.IndexOf(parentExpandSymbol) >= 0 Then
            HideRowFromGrid(detailDT, id)
            'prefix 目前收起是包括所有子系，所以搬到HideRowFromGrid處理，unHideRowFromGrid只處理一層子，所以在此處理
            'Dim desc As String = detailDT.Rows(selectIndex).Item(RuleDetailColumn(0))
            'detailDT.Rows(selectIndex)("prefix") = prefix.Replace(parentExpandSymbol, parentCollapseSymbol)
            'tl_detail.Rows(selectIndex).Cells("prefix").Value = prefix.Replace(parentExpandSymbol, parentCollapseSymbol)

            'detailDT.Rows(selectIndex).Item(RuleDetailColumn(0)) = desc.Replace(parentExpandSymbol, parentCollapseSymbol)
            'tl_detail.Rows(selectIndex).Cells("項目說明").Value = desc.Replace(parentExpandSymbol, parentCollapseSymbol)

        ElseIf prefix.IndexOf(parentCollapseSymbol) >= 0 Then
            unHideRowFromGrid(id)
            'prefix
            Dim desc As String = detailDT.Rows(selectIndex).Item(RuleDetailColumn(0))
            detailDT.Rows(selectIndex)("prefix") = prefix.Replace(parentCollapseSymbol, parentExpandSymbol)
            tl_detail.Rows(selectIndex).Cells("prefix").Value = prefix.Replace(parentCollapseSymbol, parentExpandSymbol)

            detailDT.Rows(selectIndex).Item(RuleDetailColumn(0)) = desc.Replace(parentCollapseSymbol, parentExpandSymbol)
            tl_detail.Rows(selectIndex).Cells("項目說明").Value = desc.Replace(parentCollapseSymbol, parentExpandSymbol)


        End If

    End Sub


    ''' <summary>
    ''' unHide Row From Grid by id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub unHideRowFromGrid(id As String)
        'show child
        For index = 0 To tl_detail.Rows.Count - 1
            If tl_detail.Rows(index).Cells("pid").Value() = id Then
                tl_detail.Rows(index).Visible = True
                'tl_detail.Rows(index).Height = 0
                'unHideRowFromGrid(tl_detail.Rows(index).Cells("id").Value())
            End If
        Next

    End Sub

    ''' <summary>
    ''' Hide Row From Grid by id
    ''' </summary>
    ''' <param name="detailDT"></param>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub HideRowFromGrid(detailDT As DataTable, id As String)
        'hide child
        For index = 0 To tl_detail.Rows.Count - 1
            If tl_detail.Rows(index).Cells("pid").Value() = id Then
                tl_detail.Rows(index).Visible = False
                'tl_detail.Rows(index).Height = 0
                HideRowFromGrid(detailDT, tl_detail.Rows(index).Cells("id").Value())
            End If
        Next

        'prefix
        Dim dr As DataRow = detailDT.Select("id = '" & id & "'")(0)
        Dim prefix As String = dr("prefix")
        If prefix.IndexOf(parentExpandSymbol) >= 0 Then
            Dim desc As String = dr.Item(RuleDetailColumn(0))
            'modify Datatable
            dr("prefix") = prefix.Replace(parentExpandSymbol, parentCollapseSymbol)
            dr.Item(RuleDetailColumn(0)) = desc.Replace(parentExpandSymbol, parentCollapseSymbol)

            'modify grid
            For index = 0 To tl_detail.Rows.Count - 1
                If tl_detail.Rows(index).Cells("id").Value() = id Then
                    tl_detail.Rows(index).Cells("prefix").Value = prefix.Replace(parentExpandSymbol, parentCollapseSymbol)
                    tl_detail.Rows(index).Cells("項目說明").Value = desc.Replace(parentExpandSymbol, parentCollapseSymbol)
                End If
            Next
        End If

    End Sub

#End Region

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRuleCheckTreeUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                'query()
            Case Keys.F5
                clear()
            Case Keys.F10
                'confirm()
            Case Keys.Shift And Keys.F12
                delete()
        End Select

    End Sub

    '--------------------------------------------------------------------------------
    'TreeList新增列
    '--------------------------------------------------------------------------------
    Private Sub btn_addgrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addgrid.Click
        'addRow()
        addTreeListRow()
    End Sub

    '--------------------------------------------------------------------------------
    'TreeList刪除列
    '--------------------------------------------------------------------------------
    Private Sub btn_removegrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_removegrid.Click
        deleteTreeListRow()
    End Sub

    Private Sub btn_addsubgrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addsubgrid.Click
        addTreeListSubRow()
    End Sub

    '--------------------------------------------------------------------------------

    ''' <summary>
    ''' 確認(更新 or 新增)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            confirm()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Try
            delete()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 歸屬項目一變動,就要刷新資料重打
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucl_comb_item_belong_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_item_belong.SelectedIndexChanged


        If ucl_comb_item_belong.SelectedValue.Trim.Length > 0 Then
            Dim belongStr As String = IIf(belongHash.ContainsKey(ucl_comb_item_belong.SelectedValue.Trim), CType(belongHash.Item(ucl_comb_item_belong.SelectedValue.Trim), String).Trim & " = ", "")
            '--------------------------------------------------------------------------------
            '若有X,(啟始條件區)開放編輯
            '--------------------------------------------------------------------------------
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


                Dim length As Integer = Syscom.Comm.Utility.StringUtil.StringLengthCount(lb_x.Text)
                lb_x.Width = length * 15
                Dim columnStyle0 As ColumnStyle = CType(Me.tlp_initcondition.ColumnStyles.Item(0), ColumnStyle) '= (New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
                columnStyle0.SizeType = System.Windows.Forms.SizeType.Absolute
                columnStyle0.Width = length * 15 + 10
                Me.tlp_initcondition.ColumnStyles.Item(0) = columnStyle0

            Else
                lb_init_belong.Text = belongStr

                ucl_txt_x.Text = ""
                lb_x.Enabled = False
                lb_x.Visible = False
                ucl_txt_x.Enabled = False
                ucl_txt_x.Visible = False


                Dim columnStyle0 As ColumnStyle = CType(Me.tlp_initcondition.ColumnStyles.Item(0), ColumnStyle) '= (New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
                columnStyle0.SizeType = System.Windows.Forms.SizeType.Absolute
                columnStyle0.Width = 0
                Me.tlp_initcondition.ColumnStyles.Item(0) = columnStyle0

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
        'ruleValidDateS = ""
        'ruleValidDateE = ""

        '--------------------------------------------------------------------------------
        '生效日當月第一日
        '--------------------------------------------------------------------------------
        If Not IsDate(ucl_dtp_start_eff_date.GetUsDateStr) Then
            ucl_dtp_start_eff_date.SetValue(systemDate.ToString("yyyy/MM") & "/01")
        End If

        '--------------------------------------------------------------------------------
        '終止日
        '--------------------------------------------------------------------------------
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
        'maxSeqNo = 0
        'rule
        'createUser = ""
        'createTimeStr = ""
        'initdetail
        initcreateUser = ""
        initcreateTimeStr = ""
        initRuleMaintainSn = 0

        'ruleclassdr = Nothing
        'successClassdr = Nothing
        'faultclassdr = Nothing


        initRuleCode = ""
        'ruleCode = ""

        'hasRuleData = False

        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(selectedItemDT.Copy)

        '----------------------
        '更新combobox column資料
        'ucl_dgv_detail.SetComboBoxCellDataSet(cmb_itemDS, -1, 2)
        'ucl_dgv_detail.ClearDS()


    End Sub

    ''' <summary>
    ''' 成功接續
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_success_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_success_select.Click

        Dim succSelect As PUBContinueConditionUI = New PUBContinueConditionUI(dialogItemDT.Copy, "", ucl_txt_success_cond.Text.Trim, False)
        Dim result As Boolean = succSelect.ShowAndPrepareReturnData()
        If result Then
            ucl_txt_success_cond.Text = succSelect.Condition
        Else
            '沒確認 不變
        End If

    End Sub

    ''' <summary>
    ''' 失敗接續
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_fault_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fault_select.Click
        Dim faultSelect As PUBContinueConditionUI = New PUBContinueConditionUI(dialogItemDT.Copy, "", ucl_txt_fault_cond.Text.Trim, False)
        Dim result As Boolean = faultSelect.ShowAndPrepareReturnData()
        If result Then
            ucl_txt_fault_cond.Text = faultSelect.Condition
        Else

        End If

    End Sub

    'TODO

    ''' <summary>
    ''' 起始條件內容(檢查是否合規則) X
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucl_txt_belong_info_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_txt_belong_info.Leave
        'ucl_comb_item_belong
        'Dim useValueData As String = ""

        ''Dim initConditionMsg As String = ucl_txt_belong_info.Text
        'If initConditionMsg.Length > 30 Then

        '    If ((initConditionMsg.Substring(0, 26) & "..").Equals(ucl_txt_belong_info.Text.Trim)) Then
        '        useValueData = initConditionMsg
        '        'ok

        '        If ucl_comb_item_belong.SelectedIndex > 0 Then
        '            Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
        '            If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then

        '                'ok
        '                If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
        '                    ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
        '                End If
        '            Else
        '                'msg 格式不合 'MessageHandling.showError("起始條件內容出現不合法字元")
        '                 'MessageHandling.showError("起始條件內容不符合規則")
        '                '********************2010/2/9 Modify By Alan**********************
        '              MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
        '                ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '                ucl_txt_belong_info.Focus()
        '            End If
        '        End If

        '    Else
        '        '修改過且不一致
        '        popEditValueDataWindow()
        '    End If
        'Else
        '輸入
        'If (ucl_txt_belong_info.Text.Equals(initConditionMsg)) Then
        '    '沒變
        '    useValueData = initConditionMsg

        '    If ucl_comb_item_belong.SelectedIndex > 0 Then
        '        Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
        '        If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then

        '            'ok
        '            If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
        '                ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
        '            End If
        '        Else
        '            'msg 格式不合 'MessageHandling.showError("起始條件內容出現不合法字元")
        '             'MessageHandling.showError("起始條件內容不符合規則")
        '            '********************2010/2/9 Modify By Alan**********************
        '          MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
        '            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '            ucl_txt_belong_info.Focus()
        '        End If
        '    End If

        'Else
        '    'TODO檢合格式是否正確
        '    Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
        '    If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then
        '        initConditionMsg = ucl_txt_belong_info.Text.Trim
        '        useValueData = initConditionMsg
        '        'ok

        '        If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
        '            ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
        '        End If

        '    Else
        '        'msg 格式不合 'MessageHandling.showError("起始條件內容出現不合法字元")
        '         'MessageHandling.showError("起始條件內容不符合規則")
        '        '********************2010/2/9 Modify By Alan**********************
        '      MessageHandling.showErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
        '        ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '        ucl_txt_belong_info.Focus()
        '    End If

        'End If
        'End If

        'TODO檢合格式是否正確
        Dim checkItemCode As String = ucl_comb_item_belong.SelectedValue
        If checkMessageCorrect(ucl_txt_belong_info.Text.Trim, checkItemCode) Then
            'ok
            If (Not ucl_comb_item_belong.SelectedValue.Trim.Equals("")) AndAlso (Not ucl_txt_belong_info.Text.Trim.Equals("")) AndAlso (ucl_txt_rule_name.Text.Trim.Equals("")) Then
                ucl_txt_rule_name.Text = ucl_comb_item_belong.SelectedValue.Trim & "-" & ucl_txt_belong_info.Text & "-" & systemDate.ToString("yyyyMMddHHmmss")
            End If

        Else
            'msg 格式不合 'MessageHandling.showError("起始條件內容出現不合法字元")
            'MessageHandling.showError("起始條件內容不符合規則")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"起始條件內容不符合規則"}, "")
            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            ucl_txt_belong_info.Focus()
        End If


    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Try
            clear()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 彈出編輯視窗
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub condition_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles condition_dtl.Click
        Try
            popEditValueDataWindow()
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.LOGDelegate.getInstance.fileErrorMsg(ex.ToString, ex)
        End Try
    End Sub

    'Private Sub vtn_clone_rule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vtn_clone_rule.Click
    '    '彈出複製規則視窗
    '    popCloneRuleWindow()
    'End Sub


#End Region



End Class
