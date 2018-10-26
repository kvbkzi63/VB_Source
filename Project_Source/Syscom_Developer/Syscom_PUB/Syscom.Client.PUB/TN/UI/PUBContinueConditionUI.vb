Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

'Imports nckuh.server.pub

Public Class PUBContinueConditionUI


    '============================
    '程式說明：續接條件
    '修改日期：2009.11.30
    '修改日期：2009.11.30
    '開發人員：Jen
    '============================

    Public Sub New(ByVal initItemDT As DataTable, ByVal initValueData As String, ByVal initRuleCode As String, ByVal queryInitFlag As Boolean)

        isQueryInitRule = queryInitFlag

        itemDT = initItemDT
        Condition = initRuleCode
        valueData = initValueData
        'OrderCode = initOrderCode
        'SyscodeDT = initSyscode
        'NhiIndexData = initNhiIndexDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initItemDT As DataTable, ByVal initValueData As String, ByVal initRuleSDS As DataSet, ByVal queryInitFlag As Boolean)

        isQueryInitRule = queryInitFlag

        itemDT = initItemDT
        ruleSDS = initRuleSDS
        valueData = initValueData
        'OrderCode = initOrderCode
        'SyscodeDT = initSyscode
        'NhiIndexData = initNhiIndexDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim isQueryInitRule As Boolean = False

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim paramData() As String = {"Item_Code", "Valid_Date_S", "Valid_Date_E"}
    Dim paramDataType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate}

    Dim ruleCode As String = ""
    Dim valueData As String = ""
    Dim itemDT As DataTable
    Dim itemHash As New Hashtable

    Private confirmFlag As Boolean = False
    Dim selectedNodeName As String = ""

    Private ruleSDS As DataSet = Nothing
    Private continuousCondition As String = ""

    Public Property Condition() As String
        Get
            Return continuousCondition
        End Get
        Set(ByVal value As String)
            continuousCondition = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBContinueConditionUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        Me.KeyPreview = True

        If DataSetUtil.IsContainsData(itemDT) Then
            For Each dr As DataRow In itemDT.Rows
                Dim key As String = CType(dr.Item("Item_Code"), String).Trim
                If Not itemHash.ContainsKey(key) Then
                    itemHash.Add(key, dr)
                End If
            Next
        End If
        ucl_comb_belongitem.DataSource = itemDT

        ucl_comb_belongitem.uclValueIndex = "0"
        ucl_comb_belongitem.uclDisplayIndex = "1"

        ucl_txt_clickmsg.Text = Condition

        ucl_txt_initcond.Text = valueData

        If isQueryInitRule Then


            ucl_comb_belongitem.Enabled = False
            ucl_txt_initcond.Enabled = False
            ucl_dtp_effstart.Enabled = False
            ucl_dtp_effend.Enabled = False

            cb_showrelated.Enabled = False
            cb_showinperiod.Enabled = False

            btn_query.Enabled = False
            btn_clear.Enabled = False

            If DataSetUtil.IsContainsData(ruleSDS) Then
                If (ruleSDS.Tables.Contains(PubRuleDataTableFactory.tableName) AndAlso ruleSDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count > 0) AndAlso _
                (ruleSDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) AndAlso ruleSDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows.Count > 0) Then



                    Dim firstrulecode As String = CType(ruleSDS.Tables(PubRuleDataTableFactory.tableName).Rows(0).Item("Rule_Code"), String).Trim

                    Dim ruleDtlRow() As DataRow = ruleSDS.Tables(PubRuleDetailDataTableFactory.tableName).Select(" Rule_Code = '" & firstrulecode & "' ")

                    If ruleDtlRow IsNot Nothing AndAlso ruleDtlRow.Length > 0 Then
                        Dim itemCode As String = CType(ruleDtlRow(0).Item("Item_Code"), String).Trim
                        ucl_comb_belongitem.SelectedValue = itemCode
                    End If

                End If

                putIntoTree(ruleSDS)
            End If

        Else

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
            'MessageHandling.showInfoByKey("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB001",New String(){} )
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


        If allPass Then
            cleanFieldsColor()
        Else
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
    ''' 用dialog方式開啟,有確認= true
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()

        Return confirmFlag

    End Function

    Private Sub query()
        'if checked

        tv_corr_condition.Nodes.Clear()

        'condition
        Dim itemCode As String = ucl_comb_belongitem.SelectedValue

        Dim valueData As String = ucl_txt_initcond.Text.Trim

        'Dim initCond As String = ucl_txt_initcond.Text
        'Dim startdate As Date = Date.Parse(ucl_dtp_effstart.GetUsDateStr)
        'Dim enddate As Date = Date.Parse(ucl_dtp_effend.GetUsDateStr)
        'PUB_Rule_Detail 
        '
        Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, paramData, paramDataType)
        Dim paramdr As DataRow = paramDT.NewRow
        paramdr.Item(paramData(0)) = itemCode

        If IsDate(ucl_dtp_effstart.GetUsDateStr) Then
            Try
                paramdr.Item(paramData(1)) = Date.Parse(ucl_dtp_effstart.GetUsDateStr)
            Catch ex As Exception

            End Try

        End If

        If IsDate(ucl_dtp_effend.GetUsDateStr) Then
            Try
                paramdr.Item(paramData(2)) = Date.Parse(ucl_dtp_effend.GetUsDateStr)
            Catch ex As Exception

            End Try

        End If

        paramDT.Rows.Add(paramdr)


        Dim ruleDS As DataSet = pub.queryRuleGroup(paramDT)
        

        

        putIntoTree(ruleDS)


        'Dim tmpNote1 As New TreeNode
        ''設定【根目錄】相關屬性內容   
        'tmpNote1.Text = "首頁"
        'tmpNote1.Name = "AAAAA"

        'Dim tmpNote1_2 As New TreeNode
        ''設定【根目錄】相關屬性內容   
        'tmpNote1_2.Text = "次層2"
        'tmpNote1_2.Name = "CCC"
        'tmpNote1.Nodes.Add(tmpNote1_2)

        'Dim tmpNote1_1 As New TreeNode
        ''設定【根目錄】相關屬性內容   
        'tmpNote1_1.Text = "次層1"
        'tmpNote1_1.Name = "BBB"
        'tmpNote1.Nodes.Add(tmpNote1_1)


        ''Tree建立該Node   
        'tv_corr_condition.Nodes.Add(tmpNote1)





    End Sub

    Private Function confirm() As Boolean

        Condition = ucl_txt_clickmsg.Text.Trim()

        confirmFlag = True
        Me.Dispose()

    End Function

    Private Sub clear()
        ucl_comb_belongitem.SelectedIndex = -1
        ucl_txt_clickmsg.Text = ""
        tv_corr_condition.Nodes.Clear()
    End Sub

    Private Sub updateClickMsg(ByVal clickMsg As String)

        selectedNodeName = clickMsg
        ucl_txt_clickmsg.Text = clickMsg
        Condition = clickMsg

    End Sub

    Private Sub putIntoTree(ByVal dataRuleDS As DataSet)
        If DataSetUtil.IsContainsData(dataRuleDS) Then
            Dim groupHash As New Hashtable
            Dim initRuleHash As New Hashtable

            If dataRuleDS.Tables.Contains(PubRuleDataTableFactory.tableName) Then
                For Each dr As DataRow In dataRuleDS.Tables(PubRuleDataTableFactory.tableName).Rows
                    initRuleHash.Add(CType(dr.Item("Rule_Code"), String).Trim, CType(dr.Item("Rule_Name"), String).Trim)
                Next
            End If

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
                        key.Append(selitemcode)
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
                    End If

                Next
            End If

            If groupHash.Count > 0 Then

                Dim groupenu As IDictionaryEnumerator = groupHash.GetEnumerator
                While groupenu.MoveNext
                    Dim grouplist As ArrayList = CType(groupHash.Item(groupenu.Key), ArrayList)
                    Dim groupNote As New TreeNode
                    groupNote.Name = "" 'groupenu.Key
                    groupNote.Text = groupenu.Key
                    '.....
                    If grouplist IsNot Nothing AndAlso grouplist.Count > 0 Then
                        For i As Integer = 0 To (grouplist.Count - 1)
                            Dim childrulecode As String = CType(grouplist.Item(i), String).Trim
                            If initRuleHash.ContainsKey(childrulecode) Then
                                Dim childNote As New TreeNode
                                childNote.Name = childrulecode
                                childNote.Text = CType(initRuleHash.Item(childrulecode), String).Trim

                                groupNote.Nodes.Add(childNote)
                            End If
                        Next
                    End If

                    tv_corr_condition.Nodes.Add(groupNote)
                End While

            End If

            'MessageHandling.showInfoByKey("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB001",New String(){} )
        Else
            'MessageHandling.showInfoByKey("CMMCMMB000")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB000",New String(){} )
        End If
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBContinueConditionUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If isQueryInitRule Then
            Select Case e.KeyCode
                Case Keys.F12
                    confirm()
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.F1
                    query()
                Case Keys.F5
                    clear()
                Case Keys.F12
                    confirm()
            End Select
        End If
        
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
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click
        query()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub

#End Region



    'Private Sub ucl_comb_belongtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ucl_comb_belongitem.SelectedIndex = -1
    '    Dim valueKey As String = ucl_comb_belongtype.SelectedValue
    '    If valueKey IsNot Nothing AndAlso valueKey.Trim.Length > 0 Then
    '        valueKey = valueKey.Trim
    '        If checkItemClusterHash.ContainsKey(valueKey) Then
    '            ucl_comb_belongitem.DataSource = CType(checkItemClusterHash.Item(valueKey), DataTable)
    '            ucl_comb_belongitem.uclValueIndex = "0"
    '            ucl_comb_belongitem.uclDisplayIndex = "1"
    '        Else
    '            ucl_comb_belongitem.DataSource.Clear()
    '        End If
    '    Else
    '        ucl_comb_belongitem.DataSource.Clear()
    '    End If
    'End Sub


    Private Sub tv_corr_condition_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_corr_condition.NodeMouseDoubleClick
        updateClickMsg("")

        Dim node As TreeNode = tv_corr_condition.SelectedNode
        If node IsNot Nothing Then
            Dim nodeName As String = node.Name

            updateClickMsg(nodeName)
        Else

        End If
    End Sub

    Private Sub tv_corr_condition_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_corr_condition.NodeMouseClick
        updateClickMsg("")
    End Sub

    
End Class
