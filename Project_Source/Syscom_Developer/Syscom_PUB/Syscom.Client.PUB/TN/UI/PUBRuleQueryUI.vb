Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

'Imports nckuh.server.pub

Public Class PUBRuleQueryUI


    '============================
    '程式說明：查詢畫面
    '修改日期：2009.11.30
    '修改日期：2009.11.30
    '開發人員：Jen
    '============================


    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal rule_code As String, ByVal value_data As String)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        Me.ruleCode = rule_code


        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub



#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance
    Dim h1 As New Hashtable
    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim paramData() As String = {"Item_Code", "Value_Data", "Is_Order", "Is_Insu"}
    Dim paramDataType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim detailParamData() As String = {"Item_Code", "Value_Data", "Operator"}
    Dim detailParamDataType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ItemColumn() As String = {"Item_Code", "Item_Name"}
    Dim ItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    'Dim PubItemColumn() As String = {"Item_Code", "Item_Name", "Data_Type", "Return_Checking_Flag"}
    'Dim PubItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim RuleDetailParamColumn() As String = {"檢查類別", "檢查項目", "值域", "條件關係"}
    Dim RuleDetailParamColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim CheckTypeId() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "K"}
    Dim CheckTypeName() As String = {"A.一般檢查項目", "B.療程檢查項目", "C.執行(申報)次數檢查項目", "D.醫師科診檢查項目", "E.病患基本資料檢查項目", "F.牙科檢查項目", "G.檢驗檢查(LIS)檢查項目", "H.用藥安全", "K.其他"}

    Dim ConditionRelationId() As String = {"AND", "OR"}
    Dim ConditionRelationName() As String = {"AND", "OR"}

    Dim PUBRuleCheckUIExist As Boolean = False
    Dim RuleCheckUI As Com.Syscom.WinFormsUI.Docking.DockContent

    Dim ruleCode As String = ""
    'Dim valueData As String = ""
    Dim itemDT As DataTable
    Dim itemHash As New Hashtable

    Dim isOrder As Boolean = False
    Dim isInsu As Boolean = False

    Dim checkItemClusterHash As Hashtable = New Hashtable 'type, itemdt

    Private confirmFlag As Boolean = False
    Dim selectedNodeName As String = ""

    Dim systemDate As Date = Syscom.Comm.Utility.DateUtil.getSystemDate

    Dim ruleDS As DataSet = Nothing

    'Private continuousCondition As String = ""

    'Public Property Condition() As String
    '    Get
    '        Return continuousCondition
    '    End Get
    '    Set(ByVal value As String)
    '        continuousCondition = value
    '    End Set
    'End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleQueryUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        Me.KeyPreview = True

        'Add By Elly 2016/05/23 --start
        Me.tlp_grid.Visible = False
        '--end
        Dim itemDS As DataSet = pub.initPUBRuleQueryInfo

        If DataSetUtil.IsContainsData(itemDS) Then
            If itemDS.Tables.Contains(PubItemDataTableFactory.tableName) Then
                itemDT = itemDS.Tables(PubItemDataTableFactory.tableName)
            End If

            If itemDS.Tables.Contains("systemdate") Then
                If DataSetUtil.IsContainsData(itemDS.Tables("systemdate")) Then
                    If Not IsDBNull(itemDS.Tables("systemdate").Rows(0).Item("System_Date")) Then
                        systemDate = CType(itemDS.Tables("systemdate").Rows(0).Item("System_Date"), Date)
                    End If
                End If
            End If
        End If

        If DataSetUtil.IsContainsData(itemDT) Then
            For Each dr As DataRow In itemDT.Rows
                Dim key As String = CType(dr.Item("Item_Code"), String).Trim
                If Not itemHash.ContainsKey(key) Then
                    itemHash.Add(key, dr)
                End If
            Next
        End If


        'ucl_txt_clickmsg.Text = Condition

        'ucl_txt_initcond.Text = valueData




        'ucl_comb_belongitem.Enabled = False
        'ucl_txt_initcond.Enabled = False
        ''ucl_dtp_effstart.Enabled = False
        ''ucl_dtp_effend.Enabled = False

        'cb_showrelated.Enabled = False
        'cb_showinperiod.Enabled = False

        'btn_query.Enabled = False
        'btn_clear.Enabled = False



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

        '檢查項目
        Dim queryItemDT = DataSetUtil.GenDataTable("query", Nothing, ItemColumn, ItemColumnType)
        Dim gridItemDT As DataTable = DataSetUtil.GenDataTable("grid", Nothing, ItemColumn, ItemColumnType)
        Dim checkItemDataHash As New Hashtable
        Dim ItemCodeList As New ArrayList




        If DataSetUtil.IsContainsData(itemDT) Then

            '偷藏pubitem


            For Each dr As DataRow In itemDT.Rows
                If Not IsDBNull(dr.Item("Use_Type")) Then
                    Dim itemCode As String = CType(dr.Item(ItemColumn(0)), String).Trim
                    Dim itemName As String = CType(dr.Item(ItemColumn(1)), String).Trim
                    'Dim dataType As String = CType(dr.Item(PubItemColumn(2)), String).Trim
                    'Dim returnCheckinFlag As String = CType(dr.Item(PubItemColumn(3)), String).Trim
                    Dim useType As String = CType(dr.Item("Use_Type"), String).Trim

                    ItemCodeList.Add(itemCode)

                    'checkItemDataHash
                    If Not checkItemDataHash.ContainsKey(itemCode) Then
                        checkItemDataHash.Add(itemCode, dr)
                    Else
                        'contain..impossible
                    End If

                    'Dim griditemdr As DataRow = gridItemDT.NewRow
                    'griditemdr.Item(PubItemColumn(0)) = itemCode
                    'griditemdr.Item(PubItemColumn(1)) = itemName
                    'griditemdr.Item(PubItemColumn(2)) = dataType
                    'griditemdr.Item(PubItemColumn(3)) = returnCheckinFlag
                    'gridItemDT.Rows.Add(griditemdr)

                    If useType.Equals("000") Then

                        Dim griditemdr As DataRow = gridItemDT.NewRow
                        griditemdr.Item(ItemColumn(0)) = itemCode
                        griditemdr.Item(ItemColumn(1)) = itemName
                        gridItemDT.Rows.Add(griditemdr)

                        Dim sdr As DataRow = queryItemDT.NewRow
                        sdr.Item(ItemColumn(0)) = itemCode
                        sdr.Item(ItemColumn(1)) = itemName
                        queryItemDT.Rows.Add(sdr)

                    ElseIf useType.Equals("001") Then
                        Dim griditemdr As DataRow = gridItemDT.NewRow
                        griditemdr.Item(ItemColumn(0)) = itemCode
                        griditemdr.Item(ItemColumn(1)) = itemName
                        gridItemDT.Rows.Add(griditemdr)

                    ElseIf useType.Equals("002") Then

                        Dim sdr As DataRow = queryItemDT.NewRow
                        sdr.Item(ItemColumn(0)) = itemCode
                        sdr.Item(ItemColumn(1)) = itemName
                        queryItemDT.Rows.Add(sdr)

                    End If
                End If
            Next

        End If

        'detail處
        If DataSetUtil.IsContainsData(gridItemDT) Then
            For Each dr As DataRow In gridItemDT.Rows
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


            ucl_comb_belongitem.DataSource = gridItemDT.Copy

            ucl_comb_belongitem.uclValueIndex = "0"
            ucl_comb_belongitem.uclDisplayIndex = "1"
        End If


        ''init first Grid資料
        ''----------------------------------------------
        Dim detailDS As DataSet = New DataSet
        Dim detailDT As DataTable = DataSetUtil.GenDataTable("detail", Nothing, RuleDetailParamColumn, RuleDetailParamColumnType)

        '"檢查類別", "檢查項目", "值域", '"條件關係"}

        'Hash版
        detailDS.Tables.Add(detailDT)
        Dim _hashTable As Hashtable = New Hashtable
        _hashTable.Add(-1, detailDS)

        Dim cmb_type_cell As New ComboBoxCell()
        Dim cmb_item_cell As New ComboBoxCell()
        Dim cmb_relation_cell As New ComboBoxCell()

        Dim valuetxt_cell As New TextBoxCell()


        Dim chk_cell As New CheckBoxCell()

        Dim cmb_typeDS As New DataSet
        cmb_typeDS.Tables.Add(checkTypeDT.Copy)
        cmb_type_cell.Ds = cmb_typeDS
        cmb_type_cell.ValueIndex = "0"
        cmb_type_cell.DisplayIndex = "1"

        Dim cmb_itemDS As New DataSet
        cmb_itemDS.Tables.Add(gridItemDT.Copy)
        cmb_item_cell.Ds = cmb_itemDS
        cmb_item_cell.ValueIndex = "0"
        cmb_item_cell.DisplayIndex = "1"

        'relationDT
        Dim cmb_relDS As New DataSet
        cmb_relDS.Tables.Add(relationDT)
        cmb_relation_cell.Ds = cmb_relDS
        cmb_relation_cell.ValueIndex = "0"
        cmb_relation_cell.DisplayIndex = "1"

        _hashTable.Add(0, cmb_type_cell)
        _hashTable.Add(1, cmb_item_cell)

        valuetxt_cell.MaxLength = 20
        _hashTable.Add(2, valuetxt_cell)

        _hashTable.Add(3, cmb_relation_cell)

        ucl_dgv_checkcond.Initial(_hashTable)

        ucl_dgv_checkcond.uclHeaderText = Syscom.Client.UCL.UCLDataGridViewUC.convertColumnToHeader(RuleDetailParamColumn)
        ucl_dgv_checkcond.uclColumnWidth = "110,110,150,98"
        ucl_dgv_checkcond.uclColumnAlignment = "0"
        'ucl_dgv_checkcond.uclNonVisibleColIndex = "13,14,15,16,17"

        ucl_dgv_checkcond.AddNewRow()
        '---------------------------------------------


        btn_doctor.Visible = False

        ucl_comb_belongitem.Focus()

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
            'MessageHandling.ShowInfoMsg("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB901")
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

        If ucl_comb_belongitem.SelectedIndex > 0 Then

        Else
            ucl_comb_belongitem.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            comp = ucl_comb_belongitem
            allPass = False
        End If


        If allPass Then
            cleanFieldsColor()
        Else
            'MessageHandling.showErrorByKey("CMMCMMB009")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB309")
            comp.Focus()
        End If

        Return allPass
    End Function

    Private Function checkGridColumn() As Boolean
        ucl_dgv_checkcond.ClearSelection()

        Dim result As Boolean = True
        Dim gridDS As DataSet = ucl_dgv_checkcond.GetDBDS.Copy
        If DataSetUtil.IsContainsData(gridDS) Then


            For i As Integer = 0 To (gridDS.Tables(0).Rows.Count - 1)
                ucl_dgv_checkcond.SetRowColor(i, System.Drawing.Color.White)
            Next

            'Dim copyGridDT As DataTable = gridDS.Tables(0).Copy
            'copyGridDT.Clear()

            'For i As Integer = 0 To (gridDS.Tables(0).Rows.Count - 1)
            '    If (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0)), String).Trim.Length = 0) _
            '    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)), String).Trim.Length = 0) _
            '    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)), String).Trim.Length = 0) _
            '    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)), String).Trim.Length = 0) Then

            '    Else
            '        copyGridDT.Rows.Add(gridDS.Tables(0).Rows(i).ItemArray)
            '    End If
            'Next

            'Dim resetDS As New DataSet
            'resetDS.Tables.Add(copyGridDT)
            'ucl_dgv_checkcond.Visible = False
            'ucl_dgv_checkcond.SetDS(resetDS)
            'ucl_dgv_checkcond.Visible = True

            'gridDS = ucl_dgv_checkcond.GetDBDS.Copy

            If DataSetUtil.IsContainsData(gridDS) Then
                Dim errorIndex As Integer = -1
                For i As Integer = 0 To (gridDS.Tables(0).Rows.Count - 1)
                    'RuleDetailParamColumn {"檢查類別", "檢查項目", "值域", "條件關係"}


                    If (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0)), String).Trim.Length = 0) _
                    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)), String).Trim.Length = 0) _
                    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)), String).Trim.Length = 0) _
                    AndAlso (IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3))) Or CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)), String).Trim.Length = 0) Then

                    Else
                        If (Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(0)), String).Trim.Length > 0 Then

                        Else
                            errorIndex = i
                            Exit For
                        End If

                        If (Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)), String).Trim.Length > 0 Then

                        Else
                            errorIndex = i
                            Exit For
                        End If

                        If (Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)), String).Trim.Length > 0 Then

                        Else
                            errorIndex = i
                            Exit For
                        End If

                        If i < (gridDS.Tables(0).Rows.Count - 1) Then
                            If (Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)), String).Trim.Length > 0 Then

                            Else
                                errorIndex = i
                                Exit For
                            End If
                        End If
                    End If



                Next


                If errorIndex <> -1 Then
                    ucl_dgv_checkcond.SetRowColor(errorIndex, System.Drawing.Color.Pink)
                    result = False
                Else
                    result = True
                End If

            Else
                result = True
            End If



        Else
            result = True
        End If



        Return result

    End Function


    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            ucl_comb_belongitem.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function getDetailQueryParamDT() As DataTable
        'detail info
        'detailParamData
        Dim dtlParamDT As DataTable = DataSetUtil.GenDataTable("detailparam", Nothing, detailParamData, detailParamDataType)
        Dim detailCondDS As DataSet = ucl_dgv_checkcond.GetDBDS
        If DataSetUtil.IsContainsData(detailCondDS) Then
            Dim detailCondDT As DataTable = detailCondDS.Tables(0)
            '{"檢查類別", "檢查項目", "值域", "條件關係"}
            Return detailCondDT 'add from remove warning
        Else
            Return Nothing
        End If

    End Function

    ''----------------------------------------------------------------------------
    ''用對話視窗方式開啟，不執行資料庫動作(存DataSet)
    ''----------------------------------------------------------------------------
    '''' <summary>
    '''' 用dialog方式開啟,有確認= true
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function ShowAndPrepareReturnData() As Boolean
    '    Me.ShowDialog()
    '    Return confirmFlag
    'End Function


    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub query()

        If checkColumn() Then
            tv_corr_condition.Nodes.Clear()

            'condition
            Dim itemCode As String = ucl_comb_belongitem.SelectedValue

            Dim valueData As String = ucl_txt_initcond.Text.Trim

            Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, paramData, paramDataType)
            Dim paramdr As DataRow = paramDT.NewRow
            paramdr.Item(paramData(0)) = itemCode

            If ucl_txt_initcond.Text.Trim.Length > 0 Then
                paramdr.Item(paramData(1)) = ucl_txt_initcond.Text.Trim
            End If

            If isOrder Then
                paramdr.Item(paramData(2)) = "Y"
            Else
                paramdr.Item(paramData(2)) = "N"
            End If

            If isInsu Then
                paramdr.Item(paramData(3)) = "Y"
            Else
                paramdr.Item(paramData(3)) = "N"
            End If

            paramDT.Rows.Add(paramdr)


            If checkGridColumn() Then
                '''''

                Dim dtlParamDT As DataTable = DataSetUtil.GenDataTable("detailparam", Nothing, detailParamData, detailParamDataType)


                Dim gridDS As DataSet = ucl_dgv_checkcond.GetDBDS
                If DataSetUtil.IsContainsData(gridDS) Then



                    Dim errorIndex As Integer = -1
                    For i As Integer = 0 To (gridDS.Tables(0).Rows.Count - 1)
                        'RuleDetailParamColumn {"檢查項目", "值域", "條件關係"}

                        Dim dtldr As DataRow = dtlParamDT.NewRow

                        If ((Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)), String).Trim.Length > 0) _
                        AndAlso ((Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)), String).Trim.Length > 0) Then

                            dtldr.Item(detailParamData(0)) = CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(1)), String).Trim
                            dtldr.Item(detailParamData(1)) = CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(2)), String).Trim

                            If i < (gridDS.Tables(0).Rows.Count - 1) Then
                                If (Not IsDBNull(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)))) AndAlso CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)), String).Trim.Length > 0 Then
                                    dtldr.Item(detailParamData(2)) = CType(gridDS.Tables(0).Rows(i).Item(RuleDetailParamColumn(3)), String).Trim

                                    dtlParamDT.Rows.Add(dtldr)
                                Else

                                End If
                            Else
                                dtlParamDT.Rows.Add(dtldr)
                            End If
                        Else

                        End If
                    Next


                Else

                End If


                ruleDS = pub.queryRuleByCondition(paramDT, dtlParamDT)
                ' ruleDS = nckuh.server.pub.PUBDelegate.getInstance.queryRuleByCondition(paramDT, dtlParamDT)


                putIntoTree(ruleDS, cb_showinperiod.Checked)
            Else
                'MessageHandling.showErrorByKey("CMMCMMB009")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB309")

            End If


        Else

        End If

    End Sub






    Private Function confirm() As Boolean

        'Condition = ucl_txt_clickmsg.Text.Trim()

        'confirmFlag = True
        'Me.Dispose()

        'PUBRuleCheckUI

        Dim nodeName As String = ""

        If ucl_txt_clickmsg.Text.Trim.Length > 0 Then
            nodeName = ucl_txt_clickmsg.Text.Trim

            If Me.DockPanel IsNot Nothing Then
                If Not PUBRuleCheckUIExist Then
                    RuleCheckUI = New PUBRuleCheckUI(nodeName)

                    PUBRuleCheckUIExist = True

                    RuleCheckUI.Show(Me.DockPanel)

                Else
                    '  MessageHandling.showError("看診作業已經開啟")
                    If RuleCheckUI IsNot Nothing Then
                        RuleCheckUI.Dispose()
                    End If

                    RuleCheckUI = New PUBRuleCheckUI(nodeName)

                    PUBRuleCheckUIExist = True
                    RuleCheckUI.Show(Me.DockPanel)
                End If

            Else
                If Not PUBRuleCheckUIExist Then
                    RuleCheckUI = New PUBRuleCheckUI(nodeName)

                    RuleCheckUI.TopLevel = True
                    RuleCheckUI.TopMost = True
                    RuleCheckUI.TopMost = False
                    RuleCheckUI.Show()
                    PUBRuleCheckUIExist = True
                Else
                    If RuleCheckUI IsNot Nothing Then
                        RuleCheckUI.Dispose()
                    End If

                    RuleCheckUI = New PUBRuleCheckUI(nodeName)

                    PUBRuleCheckUIExist = True
                    'RuleCheckUI.Show(Me.DockPanel)
                    RuleCheckUI.Show()
                End If

            End If
        Else
            'MessageHandling.showErrorByKey("CMMCMMB008")
            '********************2010/2/9 Modify By Alan**********************
            'MessageHandling.showErrorMsg("CMMCMMB304", New String() {"規則"}, "")

            If Me.DockPanel IsNot Nothing Then
                If Not PUBRuleCheckUIExist Then
                    RuleCheckUI = New PUBRuleCheckUI("")

                    PUBRuleCheckUIExist = True

                    RuleCheckUI.Show(Me.DockPanel)

                Else
                    '  MessageHandling.showError("看診作業已經開啟")
                    If RuleCheckUI IsNot Nothing Then
                        RuleCheckUI.Dispose()
                    End If

                    RuleCheckUI = New PUBRuleCheckUI("")

                    PUBRuleCheckUIExist = True
                    RuleCheckUI.Show(Me.DockPanel)
                End If

            Else
                If Not PUBRuleCheckUIExist Then
                    RuleCheckUI = New PUBRuleCheckUI("")

                    RuleCheckUI.TopLevel = True
                    RuleCheckUI.TopMost = True
                    RuleCheckUI.TopMost = False
                    RuleCheckUI.Show()
                    PUBRuleCheckUIExist = True
                Else
                    If RuleCheckUI IsNot Nothing Then
                        RuleCheckUI.Dispose()
                    End If

                    RuleCheckUI = New PUBRuleCheckUI("")

                    PUBRuleCheckUIExist = True
                    'RuleCheckUI.Show(Me.DockPanel)
                    RuleCheckUI.Show()
                End If

            End If

        End If

    End Function





    Private Sub clear()
        ' ucl_comb_belongitem.SelectedIndex = -1
        isOrder = False
        isInsu = False
        ucl_txt_initcond.Text = ""
        ucl_txt_clickmsg.Text = ""
        cb_showinperiod.Checked = False
        cb_showrelated.Checked = False
        ucl_dgv_checkcond.ClearDS()
        ruleDS = Nothing
        tv_corr_condition.Nodes.Clear()

        '2016/06/02 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han
        Me.lblName.Text = ""
    End Sub






    Private Sub updateClickMsg(ByVal clickMsg As String)

        selectedNodeName = clickMsg
        ucl_txt_clickmsg.Text = clickMsg
        ''Condition = clickMsg

    End Sub







    Private Sub putIntoTree(ByVal dataRuleDS As DataSet, ByVal isFilterDate As Boolean)
        tv_corr_condition.Nodes.Clear()

        If DataSetUtil.IsContainsData(dataRuleDS) Then
            Dim groupHash As New Hashtable
            Dim initRuleHash As New Hashtable

            If dataRuleDS.Tables.Contains(PubRuleDataTableFactory.tableName) Then
                For Each dr As DataRow In dataRuleDS.Tables(PubRuleDataTableFactory.tableName).Rows
                    If Not IsDBNull(dr.Item("Rule_Code")) Then
                        Dim key As String = CType(dr.Item("Rule_Code"), String).Trim
                        If Not initRuleHash.ContainsKey(key) Then
                            initRuleHash.Add(CType(dr.Item("Rule_Code"), String).Trim, dr)
                        End If
                    End If
                Next
            End If
            Dim queryhash As New Hashtable
            Dim ii As Integer = 0

            If dataRuleDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) Then
                For Each dr As DataRow In dataRuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows
                    Dim key As StringBuilder = New StringBuilder
                    key.Append("歸屬項目[")
                    Dim selrulecode As String = CType(dr.Item("Rule_Code"), String).Trim
                    Dim selitemcode As String = CType(dr.Item("Item_Code"), String).Trim
                    If itemHash.ContainsKey(selitemcode) Then

                        Dim valuedr As DataRow = CType(itemHash.Item(selitemcode), DataRow)

                        Dim value As String = ""
                        If Not IsDBNull(valuedr.Item("Item_Name")) Then
                            value = CType(valuedr.Item("Item_Name"), String).Trim
                        Else
                            value = selitemcode
                        End If
                        Dim datatype As String = ""
                        If Not IsDBNull(valuedr.Item("Data_Type")) Then
                            datatype = CType(valuedr.Item("Data_Type"), String).Trim
                        End If
                        Dim returnCheckinFlag As String = "N"
                        If Not IsDBNull(valuedr.Item("Return_Checking_Flag")) Then
                            returnCheckinFlag = CType(valuedr.Item("Return_Checking_Flag"), String).Trim
                        End If

                        key.Append(value).Append("]")

                        If Not IsDBNull(dr.Item("Value_Data")) Then
                            Dim contentValue As String = CType(dr.Item("Value_Data"), String).Trim
                            key.Append(" = ")

                            '1:文字  2:數值 3:布林  4:呼叫外部程式 
                            If datatype.Length > 0 Then
                                If datatype.Equals("1") Then
                                    key.Append("'").Append(contentValue).Append("'")
                                ElseIf datatype.Equals("4") Then
                                    If returnCheckinFlag.Equals("N") Then
                                        key.Append("True")
                                    Else
                                        key.Append(contentValue)
                                    End If
                                ElseIf datatype.Equals("5") Then
                                    key.Append("'").Append(contentValue).Append("'")
                                Else
                                    key.Append(contentValue)
                                End If
                            Else
                                key.Append(contentValue)
                            End If
                        Else

                        End If

                    Else
                        key.Append(selitemcode).Append("]")
                    End If

                    Dim hashKey As String = key.ToString

                    If groupHash.ContainsKey(hashKey) Then
                        Dim list As ArrayList = CType(groupHash.Item(hashKey), ArrayList)
                        list.Add(selrulecode)

                        groupHash.Item(hashKey) = list
                    Else
                        Dim list As ArrayList = New ArrayList
                        list.Add(selrulecode)

                        groupHash.Add(hashKey, list)
                        queryhash.Add(ii, hashKey)
                        ii = ii + 1
                    End If

                Next
            End If

            If groupHash.Count > 0 Then
                For j = 0 To ii - 1
                    Dim group_key As String = queryhash.Item(j)


                    '    Dim groupenu As IDictionaryEnumerator = groupHash.GetEnumerator
                    '    While groupenu.MoveNext
                    ' Dim grouplist As ArrayList = CType(groupHash.Item(groupenu.Key), ArrayList)
                    If Not group_key Is Nothing Then


                        Dim grouplist As ArrayList = CType(groupHash.Item(group_key), ArrayList)
                        Dim groupNote As New TreeNode
                        groupNote.Name = "" 'groupenu.Key
                        '  groupNote.Text = groupenu.Key
                        groupNote.Text = group_key
                        '.....
                        If grouplist IsNot Nothing AndAlso grouplist.Count > 0 Then
                            For i As Integer = 0 To (grouplist.Count - 1)
                                Dim childrulecode As String = CType(grouplist.Item(i), String).Trim
                                If initRuleHash.ContainsKey(childrulecode) Then
                                    Dim ruleDr As DataRow = CType(initRuleHash.Item(childrulecode), DataRow)
                                    Dim childNode As New TreeNode
                                    childNode.Name = childrulecode

                                    If Not IsDBNull(ruleDr.Item("Rule_Name")) Then
                                        childNode.Text = "規則名稱 = " & CType(ruleDr.Item("Rule_Name"), String).Trim
                                    Else
                                        childNode.Text = "無規則名稱"
                                    End If

                                    If (Not IsDBNull(ruleDr.Item("Valid_Date_S"))) AndAlso (Not IsDBNull(ruleDr.Item("Valid_Date_E"))) Then
                                        Dim vs As Date = CType(ruleDr.Item("Valid_Date_S"), Date)
                                        Dim ve As Date = CType(ruleDr.Item("Valid_Date_E"), Date)

                                        Dim childPeriodSNode As New TreeNode
                                        'childPeriodSNode.Name = vs.ToString("yyyy/MM/dd")
                                        childPeriodSNode.Text = "起始時間 : " & vs.ToString("yyyy/MM/dd")
                                        childNode.Nodes.Add(childPeriodSNode)

                                        Dim childPeriodENode As New TreeNode
                                        'childPeriodENode.Name = ve.ToString("yyyy/MM/dd")
                                        childPeriodENode.Text = "終止時間 : " & ve.ToString("yyyy/MM/dd")
                                        childNode.Nodes.Add(childPeriodENode)

                                        If isFilterDate Then
                                            If (systemDate.CompareTo(vs) >= 0) AndAlso (systemDate.CompareTo(ve) <= 0) Then
                                                groupNote.Nodes.Add(childNode)
                                            End If
                                        Else
                                            groupNote.Nodes.Add(childNode)
                                        End If

                                    Else
                                        groupNote.Nodes.Add(childNode)
                                    End If



                                End If
                            Next
                        End If

                        tv_corr_condition.Nodes.Add(groupNote)
                        '  End While
                    End If
                Next
            End If

            'MessageHandling.ShowInfoMsg("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB901", New String() {})
        Else
            'MessageHandling.ShowInfoMsg("CMMCMMB000")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB933")
        End If
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRuleQueryUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                query()
            Case Keys.F5
                clear()
            Case Keys.F10
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
        Try
            ScreenUtil.Lock(Me)
            confirm()
        Catch ex As Exception
            'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showError(ex.ToString)
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMB300", New String() {ex.ToString}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub


    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click
        Try
            ScreenUtil.Lock(Me)
            query()

        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Try
            ScreenUtil.Lock(Me)
            clear()

        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub







    Private Sub ucl_dgv_checkcond_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucl_dgv_checkcond.CellEnter
        If e.ColumnIndex = 1 Then
            Dim ds As DataSet = ucl_dgv_checkcond.GetDBDS
            If Not IsDBNull(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailParamColumn(0))) Then
                Dim type As String = CType(ds.Tables(0).Rows(e.RowIndex).Item(RuleDetailParamColumn(0)), String).Trim
                If checkItemClusterHash.ContainsKey(type) Then
                    Dim thisTypeDS As DataSet = New DataSet
                    Dim thisTypeDT As DataTable = CType(checkItemClusterHash.Item(type), DataTable)
                    thisTypeDS.Tables.Add(thisTypeDT.Copy)
                    ucl_dgv_checkcond.SetComboBoxCellDataSet(thisTypeDS, e.RowIndex, e.ColumnIndex)
                End If

            Else
                'null....no reaction
            End If

        End If
    End Sub

#End Region





    Private Sub tv_corr_condition_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_corr_condition.NodeMouseDoubleClick

        Dim node As TreeNode = tv_corr_condition.SelectedNode
        If (node IsNot Nothing) AndAlso node.Name.Trim.Length > 0 Then
            Dim nodeName As String = node.Name

            updateClickMsg(nodeName)
        Else
            updateClickMsg("")
        End If

    End Sub



    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        If checkGridColumn() Then
            ucl_dgv_checkcond.AddNewRow()
        End If
    End Sub

    Private Sub btn_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_remove.Click
        If ucl_dgv_checkcond.CurrentRow.Index <> -1 Then
            '沒點選會從第0個開始刪

            Dim gridDS As DataSet = ucl_dgv_checkcond.GetDBDS.Copy
            If DataSetUtil.IsContainsData(gridDS) Then
                gridDS.Tables(0).Rows.RemoveAt(ucl_dgv_checkcond.CurrentCell.RowIndex)

                ucl_dgv_checkcond.Visible = False
                ucl_dgv_checkcond.SetDS(gridDS)
                ucl_dgv_checkcond.Visible = True

            End If

        Else
            'MessageHandling.showErrorByKey("CMMCMMB008")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMB008", New String() {}, "")
        End If
    End Sub

    Private Sub ucl_comb_belongitem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_belongitem.SelectedIndexChanged
        isOrder = False
        isInsu = False

        If ucl_comb_belongitem.SelectedValue.Trim.Equals("D00002") Then
            '看診醫師
            btn_doctor.Visible = True

        Else
            btn_doctor.Visible = False

            If ucl_comb_belongitem.SelectedValue.Trim.Equals("A00004") Then
                'A00004(成大碼)
                isOrder = True


            ElseIf ucl_comb_belongitem.SelectedValue.Trim.Equals("A00006") Then
                'A00006(健保碼)
                isInsu = True

            End If


        End If

        '2016/06/02 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han
        Me.lblName.Text = ""

    End Sub

    Private Sub btn_doctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_doctor.Click
        Dim consultDrUI As PUBConsultDoctorUI = New PUBConsultDoctorUI(ucl_txt_initcond.Text.Trim)
        Dim result As Boolean = consultDrUI.ShowAndPrepareReturnData

        If result Then
            '友確認
            ucl_txt_initcond.Text = consultDrUI.ValueData
        Else

        End If

    End Sub

    Private Sub cb_showinperiod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_showinperiod.CheckedChanged
        If cb_showinperiod.Checked Then
            '篩日期
            putIntoTree(ruleDS, cb_showinperiod.Checked)
        Else
            '不篩
            putIntoTree(ruleDS, cb_showinperiod.Checked)
        End If
    End Sub



    Private Sub tlp_btn_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tlp_btn.Paint

    End Sub


    Private Sub tv_corr_condition_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_corr_condition.NodeMouseClick
        For i = 0 To e.Node.Nodes.Count - 1
            If e.Node.Level = 1 Then
                If e.Node.Nodes.Count < 3 Then


                    Dim rule_name As String = pub.getExprre(e.Node.Name)
                    Dim t1 As New TreeNode
                    t1.Name = "rule_name"
                    t1.Text = rule_name
                    e.Node.Nodes.Add(t1)

                    'If e.Node.Nodes(i).Level = 2 Then

                    '    If Not rule_name.Equals("") Then
                    '        e.Node.Nodes(i).Text = e.Node.Nodes(i).Text & "規則名稱=" & rule_name
                    '    Else
                    '        e.Node.Nodes(i).Text = e.Node.Nodes(i).Text & "無規則名稱"
                    '    End If
                    '    '  e.Node.Nodes(i).Text = "規則名稱 = " & 
                    'End If
                    'h1.Add(e.Node.Name, t1)
                End If
            End If
        Next




    End Sub

#Region "2016/06/02 SDSPEC-100-10-12(觸發規則顯示項目中文名稱) Add By Li.Han"
    ''' <summary>
    ''' 起始條件值的Leave Event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ucl_txt_initcond_Leave(sender As Object, e As EventArgs) Handles ucl_txt_initcond.Leave
        Me.lblName.Text = fGetOrderName(ucl_comb_belongitem.SelectedValue, ucl_txt_initcond.Text.Trim)
    End Sub

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

End Class