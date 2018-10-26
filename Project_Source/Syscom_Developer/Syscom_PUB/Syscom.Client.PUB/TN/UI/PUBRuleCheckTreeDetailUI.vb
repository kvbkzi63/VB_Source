Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

Public Class PUBRuleCheckTreeDetailUI

    '============================
    '程式說明：健保療程
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================

    Public Sub New(ByVal initSelectedItemDT As DataTable, ByVal initOperatorDT As DataTable, ByVal initUnitDT As DataTable, ByVal initRelationDT As DataTable, ByVal checkRuleObj As PUBCheckRuleObj)

        selectedItemDT = initSelectedItemDT
        operatorDT = initOperatorDT
        unitDT = initUnitDT
        relationDT = initRelationDT
        pubCheckRuleObject = checkRuleObj
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ItemColumn() As String = {"Item_Code", "Item_Name"}
    Dim ItemColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim CheckTypeId() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "K"}
    Dim CheckTypeName() As String = {"A.一般檢查項目", "B.療程檢查項目", "C.執行(申報)次數檢查項目", "D.醫師科診檢查項目", "E.病患基本資料檢查項目", "F.牙科檢查項目", "G.檢驗檢查(LIS)檢查項目", "H.用藥安全", "K.其他"}

    'Dim ConditionRelationId() As String = {"AND", "OR"}
    'Dim ConditionRelationName() As String = {"AND", "OR"}

    Dim selectedItemDT As DataTable
    Dim checkItemClusterHash As Hashtable = New Hashtable 'type, itemdt
    Dim operatorDT As DataTable
    Dim unitDT As DataTable
    Dim relationDT As DataTable

    Dim itemBelongHash As Hashtable = New Hashtable


    Dim checkItemDataHash As Hashtable = New Hashtable
    Dim checkItemUnitHash As Hashtable = New Hashtable
    Dim operatorHash As Hashtable = New Hashtable
    Dim valueUnitHash As Hashtable = New Hashtable
    Dim condHash As Hashtable = New Hashtable

    Dim ruleCode As String = ""
    Dim seqNo As Integer = 1

    Dim confirmFlag As Boolean = False
    Dim ruleDataDetail As PUBCheckRuleObj = Nothing

    Public Property pubCheckRuleObject() As PUBCheckRuleObj
        Get
            Return ruleDataDetail
        End Get
        Set(ByVal value As PUBCheckRuleObj)
            ruleDataDetail = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleCheckTreeDetailUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()
        Dim ds As DataSet = pub.RuleDynamicQuery("select  PIVU.Unit_Code ,PU.Unit_Name,PIVU.Item_Code  from PUB_Item_Value_Unit as PIVU  inner join PUB_Unit  as PU  on PU.Unit_Code =PIVU.Unit_Code  ORDER BY PIVU.Is_Default DESC")
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

                    '歸屬
                    If Not itemBelongHash.ContainsKey(CType(dr.Item(ItemColumn(0)), String).Trim) Then
                        itemBelongHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                    End If

                    If Not checkItemDataHash.ContainsKey(key) Then
                        checkItemDataHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                    End If

                    If Not checkItemUnitHash.ContainsKey(key) Then
                        Dim ds1 As DataRow() = ds.Tables(0).Select("Item_Code='" + key + "'")
                        Dim copyds As DataTable = New DataTable
                        copyds.Columns.Add(ds.Tables(0).Columns(0).ColumnName)
                        copyds.Columns.Add(ds.Tables(0).Columns(1).ColumnName)

                        For i = 0 To ds1.Length - 1
                            Dim ros As DataRow = copyds.NewRow
                            For ii = 0 To copyds.Columns.Count - 1
                                ros.Item(ii) = ds1(0).Item(ii)
                            Next
                            copyds.Rows.Add(ros)
                        Next
                        checkItemUnitHash.Add(key, copyds.Copy)
                    End If

                End If
            Next
        End If

        If DataSetUtil.IsContainsData(operatorDT) Then
            For Each dr As DataRow In operatorDT.Rows
                Dim key As String = CType(dr.Item(ItemColumn(0)), String).Trim
                If Not operatorHash.ContainsKey(key) Then
                    operatorHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                End If
            Next
        End If

        If DataSetUtil.IsContainsData(unitDT) Then
            For Each dr As DataRow In unitDT.Rows
                Dim key As String = CType(dr.Item(ItemColumn(0)), String).Trim
                If Not valueUnitHash.ContainsKey(key) Then
                    valueUnitHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                End If
            Next
        End If

        If DataSetUtil.IsContainsData(relationDT) Then
            For Each dr As DataRow In relationDT.Rows
                Dim key As String = CType(dr.Item(ItemColumn(0)), String).Trim
                If Not condHash.ContainsKey(key) Then
                    condHash.Add(key, CType(dr.Item(ItemColumn(1)), String).Trim)
                End If
            Next
        End If

        '--------------------------------------------------------------------------------------------------------
        '固定資料

        '檢查項目類別
        Dim checkTypeDT As DataTable = DataSetUtil.GenDataTable("type", Nothing, ItemColumn, ItemColumnType)
        For i As Integer = 0 To (CheckTypeId.Count - 1)
            Dim checkdr As DataRow = checkTypeDT.NewRow
            checkdr.Item(ItemColumn(0)) = CheckTypeId(i)
            checkdr.Item(ItemColumn(1)) = CheckTypeName(i)
            checkTypeDT.Rows.Add(checkdr)
        Next
        ucl_comb_type.DataSource = checkTypeDT.Copy
        ucl_comb_type.uclValueIndex = "0"
        ucl_comb_type.uclDisplayIndex = "1"

        'operatorDT
        ucl_comb_oper.DataSource = operatorDT.Copy
        ucl_comb_oper.uclValueIndex = "0"
        ucl_comb_oper.uclDisplayIndex = "1"

        '單位
        ucl_comb_unit.DataSource = unitDT.Copy
        ucl_comb_unit.uclValueIndex = "0"
        ucl_comb_unit.uclDisplayIndex = "1"

        '條件關係
        ucl_comb_condrelation.DataSource = relationDT.Copy
        ucl_comb_condrelation.uclValueIndex = "0"
        ucl_comb_condrelation.uclDisplayIndex = "1"
        ucl_comb_condrelation.SelectedIndex = 1






        If pubCheckRuleObject IsNot Nothing Then

            Dim key As String = pubCheckRuleObject.Item.Substring(0, 1)
            ucl_comb_type.SelectedValue = key

            '----------------------------------
            '組成PUBRuleDataClass, set to property
            '----------------------------------
            ruleCode = pubCheckRuleObject.RuleCode
            seqNo = pubCheckRuleObject.SeqNo
            ucl_txt_itemdescrib.Text = pubCheckRuleObject.Desc
            ucl_comb_item.SelectedValue = pubCheckRuleObject.Item
            ucl_txt_x.Text = pubCheckRuleObject.ParaX
            ucl_txt_y.Text = pubCheckRuleObject.ParaY
            ucl_txt_z.Text = pubCheckRuleObject.ParaZ
            ucl_comb_oper.SelectedValue = pubCheckRuleObject.OperatorCode
            ucl_txt_belong_info.Text = pubCheckRuleObject.ValueData
            ucl_comb_unit.SelectedValue = pubCheckRuleObject.Unit
            cb_o.Checked = pubCheckRuleObject.CountO
            cb_e.Checked = pubCheckRuleObject.CountE
            cb_i.Checked = pubCheckRuleObject.CountI
            ucl_comb_condrelation.SelectedValue = pubCheckRuleObject.LogicSymbol
            cb_passcheck.Checked = pubCheckRuleObject.IsByPassCheck
            Chk_before.Checked = pubCheckRuleObject.IsPriorReview
            If pubCheckRuleObject.InputNoticeLabel.Length > 0 Then
                cb_inputnotice.Checked = True
            Else
                cb_inputnotice.Checked = False
            End If

        End If

        ucl_txt_itemdescrib.Focus()
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
            MessageHandling.ShowInfoMsg("CMMCMMB901")
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
        Dim returnDT As DataTable = DataSetUtil.GenDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

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

        If dataRows IsNot Nothing AndAlso dataRows.Length > 0 Then
            Dim returnDT As DataTable = DataSetUtil.GenDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

            For i As Integer = 0 To (dataRows.Length - 1)
                Dim dr As DataRow = returnDT.NewRow
                dr.Item(ComboBoxColumn(0)) = CType(dataRows(i).Item(1), String).Trim
                dr.Item(ComboBoxColumn(1)) = CType(dataRows(i).Item(3), String).Trim
                returnDT.Rows.Add(dr)
            Next

            Return returnDT
        Else
            Return Nothing
        End If

    End Function

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

        'ucl_txt_itemdescrib ucl_comb_type ucl_comb_item

        'ucl_comb_oper ucl_txt_belong_info ucl_comb_unit ucl_comb_condrelation

        If Not ucl_txt_itemdescrib.Text.Trim.Length > 0 Then
            ucl_txt_itemdescrib.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_itemdescrib
        End If

        If Not ucl_comb_type.SelectedIndex > 0 Then
            ucl_comb_type.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_type
        End If

        If Not ucl_comb_item.SelectedIndex > 0 Then
            ucl_comb_item.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_item
        Else
            Dim itemValue As String = ucl_comb_item.SelectedValue.Trim

            Dim belongStr As String = IIf(itemBelongHash.ContainsKey(itemValue), CType(itemBelongHash.Item(itemValue), String).Trim, "")


            If belongStr.Contains("X") Then
                If Not ucl_txt_x.Text.Length > 0 Then
                    ucl_txt_x.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    allPass = False
                    comp = ucl_txt_x
                End If
            ElseIf belongStr.Contains("Y") Then
                If Not ucl_txt_y.Text.Length > 0 Then
                    ucl_txt_y.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    allPass = False
                    comp = ucl_txt_y
                End If
            ElseIf belongStr.Contains("Z") Then
                If Not ucl_txt_z.Text.Length > 0 Then
                    ucl_txt_z.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    allPass = False
                    comp = ucl_txt_z
                End If
            End If
        End If

        If Not ucl_comb_oper.SelectedIndex > 0 Then
            ucl_comb_oper.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_oper
        End If

        If Not ucl_txt_belong_info.Text.Trim.Length > 0 Then
            ucl_txt_belong_info.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_txt_belong_info
        End If

        'If Not ucl_comb_unit.SelectedIndex > 0 Then
        '    ucl_comb_unit.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = ucl_comb_unit
        'End If

        If Not ucl_comb_condrelation.SelectedIndex > 0 Then
            ucl_comb_condrelation.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
            allPass = False
            comp = ucl_comb_condrelation
        End If

        If allPass Then
            cleanFieldsColor()
        Else
            ErrorKeyFlag = True
            comp.Focus()
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 彈出編輯valuedata視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub popEditValueDataWindow()

        If ucl_comb_item.SelectedIndex > 0 Then
            If ucl_comb_item.SelectedValue.Trim.Equals("D00002") Then
                '看診醫師

                Dim consultDrUI As PUBConsultDoctorUI = New PUBConsultDoctorUI(ucl_txt_belong_info.Text)
                Dim result As Boolean = consultDrUI.ShowAndPrepareReturnData

                If result Then
                    'has確認
                    ucl_txt_belong_info.Text = consultDrUI.ValueData
                Else

                End If
            Else
                Dim rangeInput As PUBRuleRangeInputUI = New PUBRuleRangeInputUI(ucl_txt_belong_info.Text)
                Dim result As Boolean = rangeInput.ShowAndPrepareReturnData()

                If result Then
                    'has確認
                    ucl_txt_belong_info.Text = rangeInput.ConfirmMsg
                Else

                End If
            End If
            ucl_txt_belong_info.Focus()
        Else
            'MessageHandling.showError("新rule中有效起日要大於來源rule內容中的有效起日")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB304", New String() {"檢查項目"}, "")
            ucl_comb_item.Focus()
        End If

    End Sub

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

    Private Function confirm() As Boolean
        confirmFlag = False

        If checkColumn() Then

            '----------------------------------
            '組成PUBRuleDataClass, set to property
            '----------------------------------
            Dim isO As Boolean = cb_o.Checked
            Dim isE As Boolean = cb_e.Checked
            Dim isI As Boolean = cb_i.Checked

            Dim isByPassCheck As Boolean = cb_passcheck.Checked
            Dim isbefforecheck As Boolean = Chk_before.Checked
            Dim inputNoticeLabelMsg As String = ""
            If cb_inputnotice.Checked Then
                inputNoticeLabelMsg = "Hash Message in PUBRuleCheckTreeDetailUI "
            Else
                inputNoticeLabelMsg = ""
            End If

            If pubCheckRuleObject IsNot Nothing Then
                pubCheckRuleObject.RuleCode = ruleCode
                pubCheckRuleObject.SeqNo = seqNo
                pubCheckRuleObject.Desc = ucl_txt_itemdescrib.Text
                pubCheckRuleObject.Item = ucl_comb_item.SelectedValue
                pubCheckRuleObject.ParaX = ucl_txt_x.Text
                pubCheckRuleObject.ParaY = ucl_txt_y.Text
                pubCheckRuleObject.ParaZ = ucl_txt_z.Text
                pubCheckRuleObject.OperatorCode = ucl_comb_oper.SelectedValue
                pubCheckRuleObject.ValueData = ucl_txt_belong_info.Text
                pubCheckRuleObject.Unit = ucl_comb_unit.SelectedValue 'old source ucl_comb_unit.Text
                pubCheckRuleObject.CountO = isO
                pubCheckRuleObject.CountE = isE
                pubCheckRuleObject.CountI = isI
                pubCheckRuleObject.LogicSymbol = ucl_comb_condrelation.SelectedValue
                pubCheckRuleObject.IsByPassCheck = isByPassCheck
                pubCheckRuleObject.IsPriorReview = isbefforecheck

                pubCheckRuleObject.InputNoticeLabel = inputNoticeLabelMsg

                'pubCheckRuleObject.Level = Level_Renamed
                'pubCheckRuleObject.id = id_Renamed
                'pubCheckRuleObject.pid = pid_Renamed
            Else
                Dim checkRuleObj As New PUBCheckRuleObj(checkItemDataHash, operatorHash, valueUnitHash, condHash, ruleCode, seqNo, ucl_txt_itemdescrib.Text, ucl_comb_item.SelectedValue, ucl_txt_x.Text, ucl_txt_y.Text, ucl_txt_z.Text, ucl_comb_oper.SelectedValue, ucl_txt_belong_info.Text, ucl_comb_unit.SelectedValue, _
                                                    isO, isE, isI, ucl_comb_condrelation.SelectedValue, isByPassCheck, inputNoticeLabelMsg, isbefforecheck)
                pubCheckRuleObject = checkRuleObj
            End If



            confirmFlag = True

        Else
            confirmFlag = False
        End If

        Return confirmFlag

    End Function

    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()

        Return confirmFlag

    End Function

#End Region



#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBTreatmentControlUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F12

        End Select
    End Sub

#End Region


    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirmFlag = confirm()

        If confirmFlag Then
            Me.Dispose()
        Else

        End If

    End Sub

    Private Sub condition_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles condition_dtl.Click
        popEditValueDataWindow()
    End Sub

    Private Sub ucl_comb_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_type.SelectedIndexChanged

        If ucl_comb_type.SelectedIndex > 0 Then
            Dim type As String = ucl_comb_type.SelectedValue.Trim
            If checkItemClusterHash.ContainsKey(type) Then
                Dim thisTypeDT As DataTable = CType(checkItemClusterHash.Item(type), DataTable)
                ucl_comb_item.DataSource = thisTypeDT.Copy
                ucl_comb_item.uclValueIndex = "0"
                ucl_comb_item.uclDisplayIndex = "1"


            End If

            If checkItemUnitHash.ContainsKey(type) Then
                Dim thisTypeDS As DataSet = New DataSet
                Dim thisTypeDT As DataTable = CType(checkItemUnitHash.Item(type), DataTable)
                ucl_comb_unit.DataSource = thisTypeDT.Copy
                ucl_comb_unit.uclValueIndex = "0"
                ucl_comb_unit.uclDisplayIndex = "1"

            End If

        Else
            ucl_comb_item.DataSource = Nothing
        End If

    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub cb_passcheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_passcheck.CheckedChanged
        If cb_passcheck.Checked = True Then
            ucl_comb_type.SelectedValue = "A"
            ucl_comb_oper.SelectedValue = "01"
            ucl_txt_belong_info.Text = "0"
            ucl_comb_item.SelectedValue = "A00008"
        End If
    End Sub
End Class
