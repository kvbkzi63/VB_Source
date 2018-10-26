Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

Public Class PUBRuleCloneUI


    '============================
    '程式說明：複製規則
    '修改日期：2009.12.30
    '修改日期：2009.12.30
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initBelongDT As DataTable, ByVal initItemCode As String, ByVal initValueData As String, ByVal initRuleSDS As DataSet)

        belongDT = initBelongDT
        itemCode = initItemCode
        valueData = initValueData
        ruleSDS = initRuleSDS
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim QueryRuleColumn() As String = {"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E", "Value_Data"}
    Dim QueryRuleColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}

    Private confirmFlag As Boolean = False
    'Dim OrderCode As String = ""
    Dim ruleSDS As DataSet = Nothing
    Private belongDT As DataTable = Nothing
    Dim itemCode As String = ""
    Dim valueData As String = ""

    Dim itemHash As New Hashtable

    Dim selectedNodeName As String = ""
    Private continuousCondition As String = ""

    Public Property Condition() As String
        Get
            Return continuousCondition
        End Get
        Set(ByVal value As String)
            continuousCondition = value
        End Set
    End Property

    'Private NhiIndexDT As DataTable = Nothing

    'Public Property NhiIndexData() As DataTable
    '    Get
    '        Return NhiIndexDT
    '    End Get
    '    Set(ByVal value As DataTable)
    '        NhiIndexDT = value
    '    End Set
    'End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleCloneUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        lb_ruleinfo.Text = ""

        If DataSetUtil.IsContainsData(belongDT) Then

            For Each dr As DataRow In belongDT.Rows
                Dim item As String = CType(dr.Item("Item_Code"), String).Trim

                If Not itemHash.ContainsKey(item) Then
                    itemHash.Add(item, dr)
                End If
            Next

        End If

        ucl_comb_ruleinit.DataSource = belongDT.Copy
        ucl_comb_ruleinit.uclValueIndex = "0"
        ucl_comb_ruleinit.uclDisplayIndex = "1"


        ucl_comb_ruleinit.SelectedValue = itemCode


        If itemHash.ContainsKey(itemCode) Then
            lb_item.Text = CType(CType(itemHash.Item(itemCode), DataRow).Item("Item_Name"), String).Trim
        End If


        Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, QueryRuleColumn, QueryRuleColumnType)
        Dim paramdr As DataRow = paramDT.NewRow
        '{"Item_Code", "Rule_Name", "Check_Type", "Check_Identity", "Limit_Alert_Level", "Valid_Date_S", "Valid_Date_E"}


        paramdr.Item(QueryRuleColumn(0)) = itemCode



        '----------------------------------

        If DataSetUtil.IsContainsData(ruleSDS) Then
            If (ruleSDS.Tables.Contains(PubRuleDataTableFactory.tableName) AndAlso ruleSDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count > 0) AndAlso _
            (ruleSDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) AndAlso ruleSDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows.Count > 0) Then



                Dim firstrulecode As String = CType(ruleSDS.Tables(PubRuleDataTableFactory.tableName).Rows(0).Item("Rule_Code"), String).Trim

                Dim ruleDtlRow() As DataRow = ruleSDS.Tables(PubRuleDetailDataTableFactory.tableName).Select(" Rule_Code = '" & firstrulecode & "' ")

                If ruleDtlRow IsNot Nothing AndAlso ruleDtlRow.Length > 0 Then
                    Dim itemCode As String = CType(ruleDtlRow(0).Item("Item_Code"), String).Trim

                End If

            End If

            putIntoTree(ruleSDS)
        End If


        ucl_comb_ruleinit.Focus()
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

                    tv_ruleinfo.Nodes.Add(groupNote)
                End While

            End If

            'MessageHandling.showInfoByKey("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB901")
        Else
            'MessageHandling.showInfoByKey("CMMCMMB000")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB933")
        End If
    End Sub

    Private Sub updateClickMsg(ByVal clickMsg As String)
        selectedNodeName = clickMsg
        lb_ruleinfo.Text = clickMsg
        Condition = clickMsg



        'nodeName >> ruledetail> pk,>maintain>

        If ruleSDS IsNot Nothing Then
            If ruleSDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) Then

                Dim detaildr() As DataRow = ruleSDS.Tables(PubRuleDetailDataTableFactory.tableName).Select(" Rule_Code = '" & clickMsg & "' ")
                If detaildr IsNot Nothing AndAlso detaildr.Length > 0 Then

                    If ruleSDS.Tables.Contains(PubRuleMaintainDataTableFactory.tableName) Then

                        '找maintain pkey
                        Dim maintainsn As Integer = -1
                        Dim seqno As Integer = -1
                        Dim itemcode As String = ""

                        If Not IsDBNull(detaildr(0).Item("Rule_Maintain_Sn")) Then
                            maintainsn = CType(detaildr(0).Item("Rule_Maintain_Sn"), Integer)
                        End If
                        If Not IsDBNull(detaildr(0).Item("Seq_No")) Then
                            seqno = CType(detaildr(0).Item("Seq_No"), Integer)
                        End If
                        If Not IsDBNull(detaildr(0).Item("Item_Code")) Then
                            itemcode = CType(detaildr(0).Item("Item_Code"), String).Trim
                        End If

                        If (maintainsn <= 0) AndAlso (seqno <> -1) AndAlso (Not itemcode.Equals("")) Then
                            Dim selectStr As New StringBuilder
                            selectStr.Append(" Rule_Maintain_Sn = ").Append(maintainsn).Append(" and Seq_No = ").Append(seqno).Append(" and Item_Code = '").Append(itemcode).Append("' ")
                            Dim maintaindr() As DataRow = ruleSDS.Tables(PubRuleMaintainDataTableFactory.tableName).Select(selectStr.ToString)

                            If maintaindr IsNot Nothing AndAlso maintaindr.Length > 0 Then

                                If Not IsDBNull(maintaindr(0).Item("Maintain_Value_Str")) Then
                                    ucl_rtb_valuedata.Text = CType(maintaindr(0).Item("Maintain_Value_Str"), String).Trim
                                Else
                                    If Not IsDBNull(detaildr(0).Item("Value_Data")) Then
                                        ucl_rtb_valuedata.Text = CType(detaildr(0).Item("Value_Data"), String).Trim
                                    Else
                                        ucl_rtb_valuedata.Text = ""
                                    End If
                                End If

                            Else

                                If Not IsDBNull(detaildr(0).Item("Value_Data")) Then
                                    ucl_rtb_valuedata.Text = CType(detaildr(0).Item("Value_Data"), String).Trim
                                Else
                                    ucl_rtb_valuedata.Text = ""
                                End If

                            End If

                        Else

                            If Not IsDBNull(detaildr(0).Item("Value_Data")) Then
                                ucl_rtb_valuedata.Text = CType(detaildr(0).Item("Value_Data"), String).Trim
                            Else
                                ucl_rtb_valuedata.Text = ""
                            End If

                        End If

                    Else
                        If Not IsDBNull(detaildr(0).Item("Value_Data")) Then
                            ucl_rtb_valuedata.Text = CType(detaildr(0).Item("Value_Data"), String).Trim
                        Else
                            ucl_rtb_valuedata.Text = ""
                        End If

                    End If

                Else
                    ucl_rtb_valuedata.Text = ""
                End If
            Else
                ucl_rtb_valuedata.Text = ""
            End If
        Else
            ucl_rtb_valuedata.Text = ""
        End If


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

        Return confirmFlag

    End Function

    Private Function clone() As Boolean

        Condition = lb_ruleinfo.Text.Trim()

        confirmFlag = True
        Me.Dispose()

    End Function

    Private Sub clear()
        lb_ruleinfo.Text = ""
        ucl_comb_ruleinit.SelectedIndex = -1
        ucl_rtb_valuedata.Text = ""

        ucl_comb_ruleinit.Focus()
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRuleCloneUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                clear()
            Case Keys.F12
                clone()
        End Select
    End Sub

    ''' <summary>
    ''' 複製
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clone.Click
        clone()
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub

#End Region


#Region "觸發事件"

    Private Sub tv_ruleinfo_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_ruleinfo.NodeMouseDoubleClick
        updateClickMsg("")

        Dim node As TreeNode = tv_ruleinfo.SelectedNode
        If node IsNot Nothing Then
            Dim nodeName As String = node.Name

            updateClickMsg(nodeName)


        End If
    End Sub

    Private Sub tv_ruleinfo_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tv_ruleinfo.NodeMouseClick
        updateClickMsg("")
    End Sub

#End Region
    
End Class
