Imports System.Transactions
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO

Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.SNC

Public Class PUBRuleCheckTreeBS
    Implements IDisposable

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "########## getInstance() ##########"

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBRuleCheckTreeBS
        Try

            Return New PUBRuleCheckTreeBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Dim log As Syscom.Server.CMM.LOGDelegate = Syscom.Server.CMM.LOGDelegate.getInstance
    Private CheckColumn As String = ""

    '''' <summary>
    '''' 初始規則檢核資料
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks>Add By Jen</remarks>
    'Public Function initPUBRuleCheckUIInfo() As DataSet
    '    Dim ItemDS As New DataSet
    '    Dim ItemDT As DataTable = PUBItemBO_E1.getInstance.queryPUBItemData
    '    ItemDS.Tables.Add(ItemDT)

    '    Dim typeIds() As Integer = {801, 802, 803, 804}
    '    Dim SyscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(typeIds)
    '    ItemDS.Tables.Add(SyscodeDT)

    '    Dim PubItemValueUnitDT As DataTable = PUBItemValueUnitBO_E1.getInstance.queryItemValueUnitData
    '    ItemDS.Tables.Add(PubItemValueUnitDT)

    '    Dim PubUnitDT As DataTable = PUBUnitBO_E1.getInstance.queryUnitForCombo
    '    ItemDS.Tables.Add(PubUnitDT)

    '    If DataSetUtil.IsContainsData(ItemDT) Then
    '        Dim itemCodes(ItemDT.Rows.Count - 1) As String

    '        For i As Integer = 0 To (ItemDT.Rows.Count - 1)
    '            itemCodes(i) = CType(ItemDT.Rows(i).Item("Item_Code"), String).Trim
    '        Next

    '        Dim PubOperator As DataTable = PUBItemOperatorBO_E1.getInstance.queryOperatorData(itemCodes)

    '        If DataSetUtil.IsContainsData(PubOperator) Then
    '            ItemDS.Tables.Add(PubOperator)
    '        End If
    '    End If



    '    '系統日期
    '    Dim SystemDateColumn() As String = {"System_Date"}
    '    Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
    '    Dim SystemDateDT As DataTable = DataSetUtil.createDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
    '    Dim dateDR As DataRow = SystemDateDT.NewRow
    '    dateDR(SystemDateColumn(0)) = DateUtil.getSystemDate

    '    SystemDateDT.Rows.Add(dateDR)
    '    ItemDS.Tables.Add(SystemDateDT)

    '    Return ItemDS
    'End Function

    ''' <summary>
    ''' 查詢規則檢核資料(Query
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBRuleTreeQueryInfo() As DataSet
        Dim ItemDS As New DataSet
        Dim ItemDT As DataTable = PUBItemBO_E1.getInstance.queryPUBItemData
        ItemDS.Tables.Add(ItemDT)

        '系統日期
        Dim SystemDateColumn() As String = {"System_Date"}
        Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
        Dim SystemDateDT As DataTable = DataSetUtil.GenDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
        Dim dateDR As DataRow = SystemDateDT.NewRow
        dateDR(SystemDateColumn(0)) = DateUtil.getSystemDate

        SystemDateDT.Rows.Add(dateDR)
        ItemDS.Tables.Add(SystemDateDT)

        Return ItemDS
    End Function

    '''' <summary>
    '''' 程式說明：依名稱查詢規則
    '''' 開發人員：Jen
    '''' 開發日期：2009.11.27
    '''' </summary>
    '''' <param name="RuleParam">規則條件(起始)</param>
    '''' <returns>DataTable</returns>
    '''' <修改註記>
    '''' 1.2009/11/27, XXX
    '''' </修改註記>
    'Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet

    '    If DataSetUtil.IsContainsData(RuleParam) Then

    '        Dim ruleRelatedDT As DataTable = PUBRuleClassBO_E1.getInstance.queryInitRuleDataByParam(RuleParam)

    '        If DataSetUtil.IsContainsData(ruleRelatedDT) Then

    '            Dim RuleDS As New DataSet

    '            Dim ruleCodes(ruleRelatedDT.Rows.Count - 1) As String
    '            For i As Integer = 0 To (ruleRelatedDT.Rows.Count - 1)
    '                ruleCodes(i) = CType(ruleRelatedDT.Rows(i).Item("Trigger_Rule_Code"), String).Trim
    '            Next

    '            Try
    '                Dim initRuleDT As DataTable = PUBRuleBO_E1.getInstance.queryRuleDataByRuleCodes(ruleCodes)
    '                Dim initRuleDetailDT As DataTable = PUBRuleDetailBO_E1.getInstance.queryRuleDetailByRuleCodes(ruleCodes)

    '                Dim initMaintainDT As DataTable = PubRuleMaintainDataTableFactory.getDataTableWithSchema
    '                Dim maintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

    '                If DataSetUtil.IsContainsData(initRuleDT) Then
    '                    RuleDS.Tables.Add(initRuleDT)
    '                End If
    '                If DataSetUtil.IsContainsData(initRuleDetailDT) Then

    '                    For Each dr As DataRow In initRuleDetailDT.Rows
    '                        Dim maintainsn As Integer = -1
    '                        Dim seqno As Integer = -1
    '                        Dim itemcode As String = ""

    '                        If Not IsDBNull(dr.Item("Rule_Maintain_Sn")) Then
    '                            maintainsn = CType(dr.Item("Rule_Maintain_Sn"), Integer)
    '                        End If
    '                        If Not IsDBNull(dr.Item("Seq_No")) Then
    '                            seqno = CType(dr.Item("Seq_No"), Integer)
    '                        End If
    '                        If Not IsDBNull(dr.Item("Item_Code")) Then
    '                            itemcode = CType(dr.Item("Item_Code"), String).Trim
    '                        End If

    '                        If (maintainsn <= 0) AndAlso (seqno <= 0) AndAlso (Not itemcode.Equals("")) Then
    '                            Dim maintainds As DataSet = maintainBO.queryByPK(maintainsn, seqno, itemcode)
    '                            If DataSetUtil.IsContainsData(maintainds) Then
    '                                initMaintainDT.Rows.Add(maintainds.Tables(0).Rows(0).ItemArray)
    '                            End If

    '                        End If

    '                    Next


    '                    RuleDS.Tables.Add(initRuleDetailDT)

    '                    RuleDS.Tables.Add(initMaintainDT)
    '                End If

    '                Return RuleDS
    '            Catch ex As Exception
    '                log.dbDebugMsg("Rule Query Error")
    '                Return Nothing
    '            End Try

    '        Else
    '            Return Nothing
    '        End If

    '    Else

    '        Return Nothing
    '    End If


    'End Function


    ''' <summary>
    ''' XXXX
    ''' </summary>
    ''' <param name="selectInitRuleCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function querySelectedTreeRuleData(ByVal selectInitRuleCode As String) As DataSet
        '20111031 修改查詢邏輯，加入多個子層的查詢
        Dim thisRuleDS As New DataSet
        Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
        Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
        Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance
        Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

        Dim ruleClassDT As DataTable = ruleClassBO.queryAllTreeRuleClassByInitRuleCode(selectInitRuleCode)

        If DataSetUtil.IsContainsData(ruleClassDT) Then
            Try
                'A,1,2,3
                '1> A > lv2_children
                'Dim checkRuleList As New ArrayList

                Dim lv1RuleList As New ArrayList '存入為A的Code
                For i As Integer = 0 To (ruleClassDT.Rows.Count - 1)
                    If Not IsDBNull(ruleClassDT.Rows(i).Item("Condition_Type")) Then
                        Dim condType As String = CType(ruleClassDT.Rows(i).Item("Condition_Type"), String).Trim
                        If condType.Equals("A") Then
                            lv1RuleList.Add(CType(ruleClassDT.Rows(i).Item("Rule_Code"), String).Trim)
                        End If
                    End If
                Next

                'If lv1RuleList.Count > 0 Then
                '    Dim parent(lv1RuleList.Count - 1) As String
                '    'queryRuleDataByParentRuleCodes
                '    For i As Integer = 0 To (lv1RuleList.Count - 1)
                '        parent(i) = CType(lv1RuleList.Item(i), String).Trim
                '        checkRuleList.Add(CType(lv1RuleList.Item(i), String).Trim)
                '    Next

                '    Dim lv2ChildrenRuleDT As DataTable = ruleBO.queryRuleDataByParentRuleCodes(parent)
                '    If DataSetUtil.IsContainsData(lv2ChildrenRuleDT) Then
                '        For i As Integer = 0 To (lv2ChildrenRuleDT.Rows.Count - 1)
                '            If Not IsDBNull(lv2ChildrenRuleDT.Rows(i).Item("Rule_Code")) Then
                '                checkRuleList.Add(CType(lv2ChildrenRuleDT.Rows(i).Item("Rule_Code"), String).Trim)
                '            End If
                '        Next
                '    End If

                'End If

                thisRuleDS.Tables.Add(ruleClassDT)
                'rule
                Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCode2(selectInitRuleCode)
                If DataSetUtil.IsContainsData(initRuleDT) Then
                    initRuleDT.TableName = "INIT-" & PubRuleDataTableFactory.tableName
                End If

                'ruledtl
                'maintain data
                Dim maintainSn As Integer = -1
                Dim seqNo As Integer = -1
                Dim itemCode As String = ""
                Dim ruleMaintainDT As DataTable = Nothing
                Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCode2(selectInitRuleCode)
                If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                    initRuleDetailDT.TableName = "INIT-" & PubRuleDetailDataTableFactory.tableName

                    If (Not IsDBNull(initRuleDetailDT.Rows(0).Item("Item_Code"))) _
                        AndAlso (Not IsDBNull(initRuleDetailDT.Rows(0).Item("Seq_No"))) _
                                 AndAlso (Not IsDBNull(initRuleDetailDT.Rows(0).Item("Rule_Maintain_Sn"))) Then
                        maintainSn = CType(initRuleDetailDT.Rows(0).Item("Rule_Maintain_Sn"), Integer)
                        seqNo = CType(initRuleDetailDT.Rows(0).Item("Seq_No"), Integer)
                        itemCode = CType(initRuleDetailDT.Rows(0).Item("Item_Code"), String).Trim
                        Dim maintainDS As DataSet = ruleMaintainBO.queryByPK(maintainSn, seqNo, itemCode)
                        If DataSetUtil.IsContainsData(maintainDS) Then
                            ruleMaintainDT = maintainDS.Tables(0).Copy
                            ruleMaintainDT.TableName = PubRuleMaintainDataTableFactory.tableName
                        End If

                    End If

                End If
                If DataSetUtil.IsContainsData(initRuleDT) AndAlso DataSetUtil.IsContainsData(initRuleDetailDT) AndAlso DataSetUtil.IsContainsData(ruleMaintainDT) Then
                    thisRuleDS.Tables.Add(initRuleDT)
                    thisRuleDS.Tables.Add(initRuleDetailDT)
                    thisRuleDS.Tables.Add(ruleMaintainDT)
                    '
                    If lv1RuleList.Count > 0 Then
                        Dim checkRules(lv1RuleList.Count - 1) As String
                        For i As Integer = 0 To (lv1RuleList.Count - 1)
                            checkRules(i) = CType(lv1RuleList.Item(i), String).Trim
                        Next
                        'rule
                        '查詢A層的資料
                        Dim RuleBoE2 As PubRuleBO_E2 = PubRuleBO_E2.getInstance
                        Dim checkRuleDT As DataTable = RuleBoE2.queryRuleDataByRuleCodesL(checkRules, "1") 'ruleBO.queryRuleDataByRuleCodes2(checkRules)
                        Dim dsChild As DataSet = RuleBoE2.getRulebyParentRuleCode(checkRules, "2")
                        If dsChild IsNot Nothing AndAlso dsChild.Tables.Count > 0 Then
                            If dsChild.Tables(0).Rows.Count > 0 Then
                                checkRuleDT.Merge(dsChild.Tables(0).Copy)
                            End If
                        End If

                        If DataSetUtil.IsContainsData(checkRuleDT) Then
                            checkRuleDT.TableName = "CHECK-" & PubRuleDataTableFactory.tableName
                        End If

                        '查詢A層的資料
                        Dim checkRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes2(checkRules)
                        If dsChild IsNot Nothing AndAlso dsChild.Tables.Count > 1 Then
                            If dsChild.Tables(1).Rows.Count > 0 Then
                                checkRuleDetailDT.Merge(dsChild.Tables(1).Copy)
                            End If
                        End If
                        If DataSetUtil.IsContainsData(checkRuleDetailDT) Then
                            checkRuleDetailDT.TableName = "CHECK-" & PubRuleDetailDataTableFactory.tableName
                        End If

                        If DataSetUtil.IsContainsData(checkRuleDT) AndAlso DataSetUtil.IsContainsData(checkRuleDetailDT) Then
                            thisRuleDS.Tables.Add(checkRuleDT)
                            thisRuleDS.Tables.Add(checkRuleDetailDT)
                        End If

                    End If

                End If
            Catch ex As Exception
                log.dbErrorMsg(ex.StackTrace, ex)
                log.dbDebugMsg("PUBRuleCheckTreeBS.querySelectedTreeRuleData Error >> " & ex.Message)
            End Try

        End If

        Return thisRuleDS

    End Function



    ''' <summary>
    ''' 程式說明：確認查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2010.04.02
    ''' </summary>
    ''' <param name="confirmType">確認類別</param>
    ''' <param name="RuleDS">規則資料</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function confirmTreeRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

        Dim systemDate As Date = DateUtil.getSystemDate
        'Dim ruleCodeList As ArrayList = New ArrayList

        Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
        Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
        Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance
        Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

        Dim rulecodeValuedataHash As New Hashtable
        Dim nextFlag As Boolean = True

        Dim Scope As TransactionScope = Nothing
        Dim IsTrans As Boolean = True '交易啟用註記(Debug時可將該註記設為False，程式簽入前必須改回True)

        '取得datatype
        Dim dataTypeHash As New Hashtable
        Dim typeId() As Integer = {802}
        Dim syscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(typeId)
        Dim datatypeDr() As DataRow = syscodeDT.Select(" Type_Id = 802", "Code_Id")
        If datatypeDr IsNot Nothing AndAlso datatypeDr.Length > 0 Then
            For Each dr As DataRow In datatypeDr
                Dim key As String = CType(dr.Item("Code_Id"), String).Trim
                If Not dataTypeHash.ContainsKey(key) Then
                    dataTypeHash.Add(key, CType(dr.Item("Code_En_Name"), String).Trim)
                End If
            Next
        End If


        If DataSetUtil.IsContainsData(RuleDS) Then


            '複製規則 就要將舊規則時間變更
            If confirmType IsNot Nothing AndAlso confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                Dim valueDataDT As DataTable = Nothing

                If RuleDS.Tables.Contains("valuedata") Then
                    valueDataDT = RuleDS.Tables("valuedata").Copy
                End If

                '要將valuedata內rulecode時間範圍調整
                If DataSetUtil.IsContainsData(valueDataDT) Then
                    'rulecode更改日期
                    If (Not IsDBNull(valueDataDT.Rows(0).Item("Old_Init_Rule_Code"))) AndAlso (Not IsDBNull(valueDataDT.Rows(0).Item("Valid_Date_S"))) Then
                        Dim oldInitRuleCode As String = CType(valueDataDT.Rows(0).Item("Old_Init_Rule_Code"), String).Trim
                        Dim oldRuleClassRelatedDT As DataTable = ruleClassBO.queryAllTreeRuleClassByInitRuleCode(oldInitRuleCode)
                        Dim validEndDate As String = CType(valueDataDT.Rows(0).Item("Valid_Date_S"), String).Trim

                        If DataSetUtil.IsContainsData(oldRuleClassRelatedDT) Then

                            Dim oldList As New ArrayList
                            oldList.Add(oldInitRuleCode)
                            For i As Integer = 0 To (oldRuleClassRelatedDT.Rows.Count - 1)
                                If (Not IsDBNull(oldRuleClassRelatedDT.Rows(i).Item("Rule_Code"))) AndAlso (Not IsDBNull(oldRuleClassRelatedDT.Rows(i).Item("Condition_Type"))) Then
                                    Dim conditionType As String = CType(oldRuleClassRelatedDT.Rows(i).Item("Condition_Type"), String).Trim
                                    If conditionType.Equals("A") Then
                                        oldList.Add(CType(oldRuleClassRelatedDT.Rows(i).Item("Rule_Code"), String).Trim)
                                    End If
                                End If
                            Next

                            If oldList.Count > 0 Then

                                Dim oldRuleCodes(oldList.Count - 1) As String
                                For i As Integer = 0 To (oldList.Count - 1)
                                    oldRuleCodes(i) = CType(oldList.Item(i), String).Trim
                                Next

                                Try
                                    Dim endDate As Date = Date.Parse(validEndDate)
                                    endDate = endDate.AddDays(-1)

                                    If nextFlag Then
                                        Try
                                            Dim result As Integer = ruleBO.updateValidDateEByRuleCode(oldRuleCodes, endDate)
                                            If result = oldRuleCodes.Length Then

                                            Else
                                                nextFlag = False
                                            End If
                                        Catch ex As Exception
                                            nextFlag = False
                                            log.dbErrorMsg(ex.StackTrace, ex)
                                            log.dbDebugMsg("update Pub_Rule ValidEndDate data error >> " & ex.Message)
                                        End Try
                                    End If


                                Catch ex As Exception
                                    nextFlag = False
                                    log.dbErrorMsg(ex.StackTrace, ex)
                                    log.dbDebugMsg("update Pub_Rule ValidEndDate date parse error >> " & ex.Message)
                                End Try

                            End If

                        End If
                    End If

                End If
            End If


            '1. 取出initRuleCode
            Dim initRuleCode As String = ""
            If RuleDS.Tables.Contains(PubRuleClassDataTableFactory.tableName) Then
                Dim classDT As DataTable = RuleDS.Tables(PubRuleClassDataTableFactory.tableName)
                If DataSetUtil.IsContainsData(classDT) Then
                    For i As Integer = 0 To (classDT.Rows.Count - 1)
                        If (Not IsDBNull(classDT.Rows(i).Item("Condition_Type"))) AndAlso CType(classDT.Rows(i).Item("Condition_Type"), String).Trim.Equals("A") Then
                            initRuleCode = CType(classDT.Rows(i).Item("Condition_Rule_Code"), String).Trim()
                            Exit For
                        End If
                    Next
                End If
            End If

            '刪掉 再重加
            If IsTrans Then
                Scope = SQLConnFactory.getInstance.getRequiredTransactionScope
            End If

            'Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiredTransactionScope()

            If initRuleCode.Length > 0 Then
                Try
                    Dim result As Boolean = deleteTreeRuleData(initRuleCode)
                    If result Then

                    Else
                        nextFlag = False
                    End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                End Try
            Else
                'new 
            End If

            Dim conditionRuleCodes As New ArrayList
            Dim valuedatas As String = ""
            If nextFlag AndAlso RuleDS.Tables.Contains(PubRuleMaintainDataTableFactory.tableName) AndAlso DataSetUtil.IsContainsData(RuleDS.Tables(PubRuleMaintainDataTableFactory.tableName)) Then

                Try
                    Dim ruleMaintainDS As New DataSet
                    Dim ruleMaintainDT As DataTable = RuleDS.Tables(PubRuleMaintainDataTableFactory.tableName).Copy
                    ruleMaintainDS.Tables.Add(ruleMaintainDT)
                    '20111019 valuedata for  replace  Expression_Str value
                    If ruleMaintainDS.Tables(0).Rows.Count > 0 Then
                        valuedatas = ruleMaintainDS.Tables(0).Rows(0)("Maintain_Value_Str").ToString.Trim
                    End If
                    Dim result As Integer = ruleMaintainBO.insert(ruleMaintainDS)

                    If result = ruleMaintainDT.Rows.Count Then

                    Else
                        nextFlag = False
                        log.dbDebugMsg("insert Pub_Rule_Maintain data total error ")
                    End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                    log.dbDebugMsg("insert Pub_Rule_Maintain data error ")
                End Try
            End If

            'pub_Rule
            If nextFlag AndAlso RuleDS.Tables.Contains(PubRuleDataTableFactory.tableName) AndAlso DataSetUtil.IsContainsData(RuleDS.Tables(PubRuleDataTableFactory.tableName)) Then
                '判斷value_data中是不是有,
                '如果有將,展開。並只留下審核條件的第一筆
                Dim splict As String()
                Dim rows_count As Integer = RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count

                If RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count > 0 Then
                    splict = RuleDS.Tables(0).Copy.Rows(0).Item("Value_Data").ToString.Trim.Split(",")
                Else
                    splict = New String() {""}
                End If
                If Not splict Is Nothing Then
                    Dim index As Integer = 2
                    For i = 1 To splict.Length - 1
                        If Not splict(i).ToString.Trim.Equals("") Then
                            For k = 0 To rows_count - 1


                                Dim rows1 As DataRow = RuleDS.Tables(PubRuleDataTableFactory.tableName).NewRow
                                For j = 0 To RuleDS.Tables(PubRuleDataTableFactory.tableName).Columns.Count - 1
                                    rows1.Item(j) = RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows(k).Item(j)
                                Next
                                If rows1.Item("Rule_Code").ToString.Trim.Contains("S1") Then
                                    conditionRuleCodes.Add(rows1.Item("Rule_Code").ToString.Trim.Replace("S1", "S" & index))
                                    rows1.Item("Rule_Code") = rows1.Item("Rule_Code").ToString.Trim.Replace("S1", "S" & index)
                                    rows1.Item("Expression_Str") = rows1.Item("Expression_Str").ToString.Trim.Replace(valuedatas, splict(i))
                                    ' rows1.Item("Value_Data") = splict(i)
                                    If i = splict.Length - 1 AndAlso RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows(k)("Expression_Str").ToString.Trim.Contains(valuedatas) Then
                                        RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows(k)("Expression_Str") = RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows(k)("Expression_Str").ToString.Trim.Replace(valuedatas, splict(0))
                                    End If
                                    index = index + 1
                                    RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows.Add(rows1)
                                End If
                            Next
                        End If

                    Next

                End If


                Try




                    Dim ruleTotalDS As New DataSet






                    Dim ruleDT As DataTable = RuleDS.Tables(PubRuleDataTableFactory.tableName).Copy
                    ruleTotalDS.Tables.Add(ruleDT)
                    Dim result As Integer = ruleBO.insert(ruleTotalDS)

                    If result = ruleDT.Rows.Count Then

                    Else
                        nextFlag = False
                        log.dbDebugMsg("insert Pub_Rule data total error ")
                    End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                    log.dbDebugMsg("insert Pub_Rule data error >> " & ex.Message)
                End Try
            End If

            Dim row_count As Integer = 0
            'Pub_Rule_Detial
            If nextFlag AndAlso RuleDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) AndAlso DataSetUtil.IsContainsData(RuleDS.Tables(PubRuleDetailDataTableFactory.tableName)) Then

                Try
                    Dim ruleTotalDtlDS As New DataSet
                    Dim splict As String()
                    Dim rows_count As Integer = RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count

                    If RuleDS.Tables(PubRuleDataTableFactory.tableName).Rows.Count > 0 Then
                        splict = RuleDS.Tables(0).Copy.Rows(0).Item("Value_Data").ToString.Trim.Split(",")
                    Else
                        splict = New String() {""}
                    End If
                    row_count = splict.Length - 1
                    '判斷value_data中是不是有,
                    '如果有將,展開。並只留下審核條件的第一筆
                    Dim splict1 As String()
                    Dim rows_count1 As Integer = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows.Count

                    If RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows.Count > 0 Then
                        splict1 = RuleDS.Tables(0).Copy.Rows(0).Item("Value_Data").ToString.Trim.Split(",")
                    Else
                        splict1 = New String() {""}
                    End If
                    If Not splict1 Is Nothing Then
                        Dim index As Integer = 2
                        For i = 1 To splict1.Length - 1
                            If Not splict(i).ToString.Trim.Equals("") Then
                                For k = 0 To rows_count1 - 1


                                    Dim rows1 As DataRow = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).NewRow


                                    For j = 0 To RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Columns.Count - 1
                                        rows1.Item(j) = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows(k).Item(j)
                                    Next
                                    If rows1.Item("Rule_Code").ToString.Trim.Contains("S1") Then
                                        rows1.Item("Rule_Code") = rows1.Item("Rule_Code").ToString.Trim.Replace("S1", "S" & index)
                                        rows1.Item("Value_Data") = splict(i)
                                        index = index + 1
                                        RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Rows.Add(rows1)
                                    End If

                                Next
                            End If

                        Next

                    End If



                    Dim ruleDetailDT As DataTable = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Copy

                    ruleDetailDT.Rows(0).Item("Value_Data") = ruleDetailDT.Rows(0).Item("Value_Data").ToString.Split(",")(0).ToString

                    ruleTotalDtlDS.Tables.Add(ruleDetailDT)
                    Dim result As Integer = ruleDetailBO.insert(ruleTotalDtlDS)

                    If result = ruleDetailDT.Rows.Count Then

                    Else
                        nextFlag = False
                        log.dbDebugMsg("insert Pub_Rule_Detail data total error ")
                    End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                    log.dbDebugMsg("insert Pub_Rule_Detail data error >> " & ex.Message)
                End Try
            End If

            'Pub_Rule_Class
            If nextFlag AndAlso RuleDS.Tables.Contains(PubRuleClassDataTableFactory.tableName) AndAlso DataSetUtil.IsContainsData(RuleDS.Tables(PubRuleClassDataTableFactory.tableName)) Then

                Try
                    Dim ruleClassTotalDS As New DataSet
                    Dim ruleClassDT As DataTable = RuleDS.Tables(PubRuleClassDataTableFactory.tableName).Copy
                    Dim ruleclassDt1 As DataTable = ruleClassDT.Copy

                    'row_count 用逗號隔開的長度 
                    '判斷rule_code沒有S1的。
                    '就把條件rule_code的S1用S2,S2取代
                    'conditionRuleCodes 
                    For Each krow As DataRow In ruleclassDt1.Rows
                        If Not krow.Item("Rule_Code").ToString.Trim.Contains("S1") Then
                            For i = 0 To row_count - 1
                                Dim ckrow As DataRow = ruleClassDT.NewRow
                                For j = 0 To ruleClassDT.Columns.Count - 1
                                    ckrow.Item(j) = krow.Item(j)
                                Next
                                ckrow.Item("Condition_rule_code") = ckrow.Item("Condition_rule_code").ToString.Replace("-S1", "-S" & (i + 2))
                                ruleClassDT.Rows.Add(ckrow)
                            Next
                        Else
                            ' add the row which Condition_Type='1' 
                            If krow.Item("Condition_Type").ToString.Trim = "1" Then
                                For i = 0 To conditionRuleCodes.Count - 1
                                    Dim dr1 As DataRow = ruleClassDT.NewRow
                                    dr1.ItemArray = krow.ItemArray
                                    dr1("Rule_Code") = conditionRuleCodes(i)
                                    dr1("Condition_rule_code") = conditionRuleCodes(i)
                                    ruleClassDT.Rows.Add(dr1)
                                Next
                            End If
                        End If
                    Next

                    ruleClassTotalDS.Tables.Add(ruleClassDT)
                    Dim result As Integer = ruleClassBO.insert(ruleClassTotalDS)

                    If result = ruleClassDT.Rows.Count Then

                    Else
                        nextFlag = False
                        log.dbDebugMsg("insert Pub_Rule_Class data total error ")
                    End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                    log.dbDebugMsg("insert Pub_Rule_Class data error >> " & ex.Message)
                End Try
            End If
            '2010/10/01 
            '(新增) 儲存規則時，若是觸發項目是成大碼(A00004) or 健保碼(A00006)時，當PUB_Rule相關table存檔成功後，
            '    需要再更新PUB_Order 中對應觸發條件中成大碼 (當觸發為健保碼時，需要將健保碼轉為成大碼) 的 “Is_Icd_Check” 欄位值；
            'PUB_Order.[Is_Icd_Check](更新邏輯)
            '    1.      當適應症中所有條件均不需 “需事前審查” PUB_Rule.[Is_Prior_Rrview] 均為 ‘N’ 時，更新值為 “Y”。
            '    2.      當適應症中所有條件中若有存在 “需事前審查” PUB_Rule.[Is_Prior_Rrview] =‘Y’ 時，更新值為 “C”。
            Dim po As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
            '20120220 by liuye 適應症維護UI中若任一條件中的 “需事前審查” 被 checked à PUB_Rule.Is_Prior_Review=’Y’。PUB_Order.Is_Icd_Check 改為 ‘C’。
            Dim Is_Prior_Rrview As String = "N" 'RuleDS.Tables("Pub_Rule").Rows(0).Item("Is_Prior_Review").ToString.Trim
            Dim drIsPre() As DataRow = RuleDS.Tables("Pub_Rule").Select("Is_Prior_Review='Y'")
            If drIsPre.Count > 0 Then
                Is_Prior_Rrview = "Y"
            End If
            Dim hash_table As New Hashtable
            '更新
            Dim pub_order_tables As DataTable = PubOrderDataTableFactory.getDataTable
            Dim dd As New DataSet
            dd.Tables.Add(New DataTable)
            dd.Tables(0).Columns.Add("Order_Code")
            Dim Order_code_Ds As DataSet
            Dim item_code As String = RuleDS.Tables("PUB_Rule_Detail").Rows(0).Item("Item_code").ToString.Trim
            If Not item_code.Equals("A00004") Then



                For Each o As DataRow In RuleDS.Tables("PUB_Rule_Detail").Rows
                    If Not item_code.Equals("A00004") Then

                        Dim order_code_array As String() = o.Item("Value_Data").ToString.Trim.Split(",")
                        For i = 0 To order_code_array.Count - 1

                            Dim ck As DataRow = dd.Tables(0).NewRow
                            ck.Item(0) = order_code_array(i).ToString.Trim
                            If Not hash_table.Contains(order_code_array(i).ToString.Trim) Then

                                dd.Tables(0).Rows.Add(ck)
                                hash_table.Add(order_code_array(i).ToString.Trim, ck)
                            End If

                        Next
                    End If
                Next

                Order_code_Ds = PUBDelegate.getInstance.queryInsuCodeByOrderCode(dd)
                For Each kk As DataRow In RuleDS.Tables("PUB_Rule_Detail").Rows
                    Dim isu_code As String = kk.Item("Value_Data").ToString.Trim
                    Dim order_code_row As DataRow() = Order_code_Ds.Tables(0).Select("detail_Insu_Code='" + isu_code + "'")

                    If order_code_row.Length > 0 Then
                        kk.Item("Value_Data") = order_code_row(0).Item("Order_code")
                    End If
                    Dim kk1 As DataRow = pub_order_tables.NewRow
                    kk1.Item("Order_Code") = kk.Item("Value_Data")
                    If Is_Prior_Rrview.Equals("N") Then
                        kk1.Item("Is_Icd_Check") = "Y"
                    Else
                        kk1.Item("Is_Icd_Check") = "C"

                    End If
                    kk1.Item("Effect_Date") = Now.ToString("yyyy/MM/dd")
                    If Not hash_table.Contains(kk1.Item("Effect_Date") & kk1.Item("ORDER_CODE")) Then
                        pub_order_tables.Rows.Add(kk1)
                        hash_table.Add(kk1.Item("Effect_Date") & kk1.Item("ORDER_CODE"), kk1)
                    End If

                Next
            Else
                For Each kk As DataRow In RuleDS.Tables("PUB_Rule_Detail").Rows


                    Dim order_code_array As String() = kk.Item("Value_Data").ToString.Trim.Split(",")
                    For i = 0 To order_code_array.Count - 1
                        Dim kk1 As DataRow = pub_order_tables.NewRow

                        kk1.Item("Order_Code") = order_code_array(i).ToString.Trim
                        '利用hashtable做為記錄，來檢查order_code的重覆性
                        If Not hash_table.Contains(order_code_array(i).ToString.Trim) Then



                            If Is_Prior_Rrview.Equals("N") Then
                                kk1.Item("Is_Icd_Check") = "Y"
                            Else
                                kk1.Item("Is_Icd_Check") = "C"

                            End If
                            kk1.Item("Effect_Date") = Now.ToString("yyyy/MM/dd")

                            hash_table.Add(order_code_array(i).ToString.Trim, kk1)
                            pub_order_tables.Rows.Add(kk1)
                        End If

                    Next



                Next


            End If

            Dim PUBB As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance



            If nextFlag Then

                Try
                    Dim temp As New DataSet
                    temp.Tables.Add(pub_order_tables)
                    Dim result As Integer = PUBB.update_Is_Icd_Check(temp)

                    'If result = pub_order_tables.Rows.Count Then

                    'Else
                    '    nextFlag = False
                    '    log.dbDebugMsg("update pub_order is_icd_Check error ")
                    'End If
                Catch ex As Exception
                    nextFlag = False
                    log.dbErrorMsg(ex.StackTrace, ex)
                    log.dbDebugMsg("update pub_order is_icd_Check error  >> " & ex.Message)
                End Try
            End If


            If IsTrans Then
                If nextFlag Then
                    Scope.Complete()
                End If

                Scope.Dispose()

            End If

            'End Using

            If nextFlag Then
                Return SQLDataUtil.EXECUTE_SUCCESS
            Else
                Return SQLDataUtil.EXECUTE_FAIL
            End If

        Else
            Return SQLDataUtil.EXECUTE_FAIL
        End If

    End Function

    ''' <summary>
    ''' 程式說明：刪除查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="initRuleCode">起始檢核規則碼</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function deleteTreeRuleData(ByVal initRuleCode As String) As Boolean


        If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then
            Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance
            Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance
            Dim ruleDetailBo2 As PubRuleDetailBO_E2 = PubRuleDetailBO_E2.getInstance
            Dim result As Boolean = True
            '先查詢Class
            Dim ruleRelatedNeedDeleteDT As DataTable = ruleClassBO.queryAllTreeRuleClassByInitRuleCode(initRuleCode)

            'Dim other_rule_code As DataTable = ruleClassBO.dynamicQuery("Select * from PUB_Rule where rule_code like '" & initRuleCode.Substring(0, initRuleCode.Length - 2) & "%' and rule_code <>'" & initRuleCode & "'").Tables(0).Copy


            '統計所有Pub_Rule中的Rule_Code
            Dim ruleCodeList As New ArrayList
            If DataSetUtil.IsContainsData(ruleRelatedNeedDeleteDT) Then
                'ruleCodeList.Add(initRuleCode)
                For Each dr As DataRow In ruleRelatedNeedDeleteDT.Rows
                    Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim
                    If conditionType.Equals("A") Then
                        '先只加第一層
                        ruleCodeList.Add(CType(dr.Item("Rule_Code"), String).Trim)
                    End If
                Next
            End If




            If ruleCodeList.Count > 0 Then
                '補上第二層
                Dim pruleCodes(ruleCodeList.Count - 1) As String
                For i As Integer = 0 To (ruleCodeList.Count - 1)
                    pruleCodes(i) = CType(ruleCodeList.Item(i), String).Trim
                Next
                Dim RuleBoE2 As PubRuleBO_E2 = PubRuleBO_E2.getInstance
                '20111031 修改查詢各子節點，直到沒有
                Dim childL2RuleDT As New DataTable
                Dim dsChild2Rule As DataSet = RuleBoE2.getRulebyParentRuleCode(pruleCodes) 'ruleBO.queryRuleDataByParentRuleCodes(pruleCodes)
                If dsChild2Rule.Tables.Count > 0 Then
                    childL2RuleDT = dsChild2Rule.Tables(0).Copy
                End If

                If DataSetUtil.IsContainsData(childL2RuleDT) Then
                    For i As Integer = 0 To (childL2RuleDT.Rows.Count - 1)
                        If Not IsDBNull(childL2RuleDT.Rows(i).Item("Rule_Code")) Then
                            ruleCodeList.Add(CType(childL2RuleDT.Rows(i).Item("Rule_Code"), String).Trim)
                        End If
                    Next
                End If
            End If
            Dim dsDetial As DataSet = ruleDetailBo2.queryPUBRuleDeatilforRuleMaintainSn(initRuleCode)
            Dim ConditionRuleCodes As String = "'" & initRuleCode & "'"
            If DataSetUtil.IsContainsData(dsDetial) Then
                'ruleCodeList.Add(initRuleCode)
                For Each dr As DataRow In dsDetial.Tables(0).Rows

                    ConditionRuleCodes &= ",'" & dr.Item("Rule_Code").ToString.Trim & "'"
                    '其它會觸發的Code
                    ruleCodeList.Add(CType(dr.Item("Rule_Code"), String).Trim)

                Next
            End If


            '要刪除的rulecode準備好了, 再加入起始
            ruleCodeList.Add(initRuleCode)

            '找rulemaintain
            Dim seqno As Integer = -1
            Dim maintainSn As Integer = -1
            Dim itemcode As String = ""

            'Dim sDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCode(initRuleCode)
            Dim sDetailDT As DataTable = dsDetial.Tables(0)
            If DataSetUtil.IsContainsData(sDetailDT) Then
                If (Not IsDBNull(sDetailDT.Rows(0).Item("Seq_No"))) AndAlso (Not IsDBNull(sDetailDT.Rows(0).Item("Item_Code"))) AndAlso (Not IsDBNull(sDetailDT.Rows(0).Item("Rule_Maintain_Sn"))) Then

                    seqno = CType(sDetailDT.Rows(0).Item("Seq_No"), Integer)
                    maintainSn = CType(sDetailDT.Rows(0).Item("Rule_Maintain_Sn"), Integer)
                    itemcode = CType(sDetailDT.Rows(0).Item("Item_Code"), String).Trim

                End If
            End If


            If ruleCodeList.Count > 0 Then

                Dim ruleCodes(ruleCodeList.Count - 1) As String
                For i As Integer = 0 To (ruleCodeList.Count - 1)
                    ruleCodes(i) = CType(ruleCodeList.Item(i), String).Trim
                Next

                Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiredTransactionScope()

                    Try
                        'delete class by conditionCode
                        Dim classbo2 As PubRuleClassBO_E2 = PubRuleClassBO_E2.getInstance
                        Dim icount As Integer = classbo2.deletePubRuleClassBObyConditionRuleCode(ConditionRuleCodes)
                        'For i = 0 To ruleCodes.Length - 1
                        '    If ruleCodes(i).ToString.Contains("-S") Then
                        '        ruleClassBO.deleteTreeByInitRuleCode(ruleCodes(i).ToString)
                        '    End If

                        'Next

                        ruleBO.deleteByRuleCodes(ruleCodes)
                        ruleDetailBO.deleteByRuleCodes(ruleCodes)
                        ruleMaintainBO.delete(maintainSn, seqno, itemcode)
                    Catch ex As Exception
                        result = False
                        log.dbErrorMsg(ex.StackTrace, ex)
                    End Try

                    If result Then
                        Scope.Complete()
                    Else
                        Scope.Dispose()
                    End If

                End Using

                Return result

            Else
                Return False
            End If
        Else
            Return True
        End If

    End Function

    '''' <summary>
    '''' 取序號
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function getRuleSerialNo() As String
    '    Dim appendChar As Char = "0"
    '    Dim srn As String = StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.typeD, "PUB_Rule_Code", 1, -1), appendChar, 7)

    '    Return srn
    'End Function

    ''' <summary>
    ''' 取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRuleMaintainSerialNo() As Integer

        Dim srn As String = SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeD, "PUB_Rule_Maintain", 1, -1)
        Dim srnInt As Integer = 0
        Try
            srnInt = Integer.Parse(srn)
        Catch ex As Exception
            log.dbErrorMsg(ex.StackTrace, ex)
        End Try

        Return srnInt
    End Function


    ''' <summary>
    ''' 查可供ruleclass選的資料(Query的主查詢畫面,參數查詢)
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryTreeRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet
        '
        ', ByVal dtlParam As DataTable

        If DataSetUtil.IsContainsData(itemParam) Then

            Dim ruleDS As New DataSet

            Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance
            Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

            Dim ruleDT As DataTable = ruleBO.queryTreeRuleCodeByData(itemParam)

            If DataSetUtil.IsContainsData(ruleDT) Then

                Dim filterInitRuleHash As New Hashtable
                Dim filterInitRuleList As New ArrayList

                '查啟始 rule, ruledetail
                Dim initRuleCodes(ruleDT.Rows.Count - 1) As String
                For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                    initRuleCodes(i) = CType(ruleDT.Rows(i).Item("Rule_Code"), String).Trim
                Next

                '再過濾detail的條件
                If DataSetUtil.IsContainsData(detailParam) Then

                    Dim ruleStr As New StringBuilder

                    '{"Item_Code", "Value_Data", "Operator"}
                    For i As Integer = 0 To (detailParam.Rows.Count - 1)
                        If (Not IsDBNull(detailParam.Rows(i).Item("Item_Code"))) AndAlso (Not IsDBNull(detailParam.Rows(i).Item("Value_Data"))) Then

                            If i < (detailParam.Rows.Count - 1) Then
                                '非最後一筆
                                If (Not IsDBNull(detailParam.Rows(i).Item("Operator"))) Then

                                    ruleStr.Append(" (Item_Code = '").Append(CType(detailParam.Rows(i).Item("Item_Code"), String).Trim).Append("' ")
                                    ruleStr.Append(" and Value_Data like '%").Append(CType(detailParam.Rows(i).Item("Value_Data"), String).Trim).Append("%' ) ")

                                    If CType(detailParam.Rows(i).Item("Operator"), String).Trim.Equals("AND") Then
                                        ruleStr.Append(" and ")
                                    Else
                                        ruleStr.Append(" or ")
                                    End If

                                End If
                            Else
                                'i = (detailParam.Rows.Count - 1) 最後一筆
                                ruleStr.Append(" (Item_Code = '").Append(CType(detailParam.Rows(i).Item("Item_Code"), String).Trim).Append("' ")
                                ruleStr.Append(" and Value_Data like '%").Append(CType(detailParam.Rows(i).Item("Value_Data"), String).Trim).Append("%' ) ")

                            End If
                        End If
                    Next

                    If ruleStr.Length > 0 Then

                        '起始rule查詢rulecode
                        Dim ruleCodeDT As DataTable = ruleClassBO.queryRuleCodeByInitRuleCodes(initRuleCodes)

                        If DataSetUtil.IsContainsData(ruleCodeDT) Then
                            Dim ruleCodeInitHash As New Hashtable

                            'init-rule > rule, 查詢detail condition

                            Dim ruleCodes(ruleCodeDT.Rows.Count - 1) As String
                            For i As Integer = 0 To (ruleCodeDT.Rows.Count - 1)
                                If (Not IsDBNull(ruleCodeDT.Rows(i).Item("Rule_Code"))) AndAlso (Not IsDBNull(ruleCodeDT.Rows(i).Item("Condition_Rule_Code"))) Then
                                    Dim ruleCode As String = CType(ruleCodeDT.Rows(i).Item("Rule_Code"), String).Trim
                                    ruleCodes(i) = ruleCode
                                    If Not ruleCodeInitHash.ContainsKey(ruleCode) Then
                                        ruleCodeInitHash.Add(ruleCode, CType(ruleCodeDT.Rows(i).Item("Condition_Rule_Code"), String).Trim)
                                    End If
                                End If
                            Next

                            Dim ruleCodeDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes2(ruleCodes)

                            If DataSetUtil.IsContainsData(ruleCodeDetailDT) Then


                                Dim filterDtlDRs() As DataRow = ruleCodeDetailDT.Select(ruleStr.ToString)

                                If filterDtlDRs IsNot Nothing AndAlso filterDtlDRs.Length > 0 Then

                                    For Each dr As DataRow In filterDtlDRs
                                        If Not IsDBNull(dr.Item("Rule_Code")) Then
                                            Dim ruleCode As String = CType(dr.Item("Rule_Code"), String).Trim
                                            If ruleCodeInitHash.ContainsKey(ruleCode) Then
                                                If Not filterInitRuleHash.ContainsKey(CType(ruleCodeInitHash.Item(ruleCode), String).Trim) Then
                                                    filterInitRuleHash.Add(CType(ruleCodeInitHash.Item(ruleCode), String).Trim, "")
                                                    filterInitRuleList.Add(CType(ruleCodeInitHash.Item(ruleCode), String).Trim)
                                                End If
                                            End If

                                        End If
                                    Next



                                Else
                                    'Return Nothing

                                End If

                            Else
                                'Return Nothing
                            End If

                        Else
                            'Return Nothing
                        End If

                        'filterInitRuleList
                        If filterInitRuleList.Count > 0 Then
                            Dim filterInitRule(filterInitRuleList.Count - 1) As String
                            For i As Integer = 0 To (filterInitRuleList.Count - 1)
                                filterInitRule(i) = CType(filterInitRuleList.Item(i), String).Trim
                            Next

                            Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes2(filterInitRule)
                            Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes2(filterInitRule)

                            If DataSetUtil.IsContainsData(initRuleDT) Then
                                ruleDS.Tables.Add(initRuleDT)
                            End If
                            If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                                ruleDS.Tables.Add(initRuleDetailDT)
                            End If

                            Return ruleDS

                        Else
                            Return Nothing
                        End If

                    Else
                        '不篩選
                        Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes2(initRuleCodes)
                        Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes2(initRuleCodes)

                        If DataSetUtil.IsContainsData(initRuleDT) Then
                            ruleDS.Tables.Add(initRuleDT)
                        End If
                        If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                            ruleDS.Tables.Add(initRuleDetailDT)
                        End If

                        Return ruleDS

                    End If


                Else
                    '不篩選
                    'queryRuleCodeByInitRuleCodes

                    Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes2(initRuleCodes)
                    Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes2(initRuleCodes)

                    If DataSetUtil.IsContainsData(initRuleDT) Then
                        ruleDS.Tables.Add(initRuleDT)
                    End If
                    If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                        ruleDS.Tables.Add(initRuleDetailDT)
                    End If


                    'ruleDS.Tables(0).Columns("Rule_Name").ReadOnly = False
                    'For i = 0 To ruleDS.Tables(0).Rows.Count - 1
                    '    ruleDS.Tables(0).Rows(i).Item("Rule_Name") = PUBRuleBO_E1.getInstance.getExprre(ruleDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim)

                    'Next


                    Return ruleDS

                End If







            Else
                Return Nothing
            End If

        Else
            '查無資料
            Return Nothing
        End If


    End Function

    '------------------------------------------------------
    ''接連條件
    ''queryRuleCode
    '''' <summary>
    '''' 查可供ruleclass選的資料
    '''' </summary>
    '''' <param name="itemParam"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet
    '    If DataSetUtil.IsContainsData(itemParam) Then

    '        Dim itemCode As String = CType(itemParam.Rows(0).Item("Item_Code"), String).Trim

    '        Dim paramDate() As String = {"Item_Code", "Valid_Date_S", "Valid_Date_E", "Value_Data"}
    '        Dim paramDateType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}

    '        Dim paramDT As DataTable = DataSetUtil.createDataTable("param", Nothing, paramDate, paramDateType)
    '        Dim paramdr As DataRow = paramDT.NewRow

    '        paramdr.Item(paramDate(0)) = itemCode

    '        If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_S"))) Or (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_E"))) Then

    '            If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_S"))) Then
    '                paramdr.Item(paramDate(1)) = itemParam.Rows(0).Item("Valid_Date_S")
    '            End If

    '            If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_E"))) Then
    '                paramdr.Item(paramDate(2)) = itemParam.Rows(0).Item("Valid_Date_E")
    '            End If
    '        End If

    '        paramDT.Rows.Add(paramdr)

    '        Dim ruleDS As New DataSet

    '        Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
    '        Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance


    '        Dim ruleDT As DataTable = ruleBO.queryRuleCodeByDataForContinue(paramDT)

    '        If DataSetUtil.IsContainsData(ruleDT) Then

    '            '查啟始 rule, ruledetail
    '            Dim ruleCodes(ruleDT.Rows.Count - 1) As String
    '            For i As Integer = 0 To (ruleDT.Rows.Count - 1)
    '                ruleCodes(i) = CType(ruleDT.Rows(i).Item("Rule_Code"), String).Trim
    '            Next

    '            Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes(ruleCodes)
    '            Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(ruleCodes)

    '            If DataSetUtil.IsContainsData(initRuleDT) Then
    '                ruleDS.Tables.Add(initRuleDT)
    '            End If
    '            If DataSetUtil.IsContainsData(initRuleDetailDT) Then
    '                ruleDS.Tables.Add(initRuleDetailDT)
    '            End If

    '            Return ruleDS
    '        Else
    '            Return Nothing
    '        End If

    '    Else
    '        '查無資料
    '        Return Nothing
    '    End If

    '    'Else
    '    'Return Nothing
    '    'End If

    'End Function


    '    Private Function insertBasicData() As Boolean

    '        Dim conn As IDbConnection = SQLConnFactory.getInstance.getPubDBSqlConn()
    '        conn.Open()

    '        Dim ItemCode() As String = {"A00007", _
    '"A00008", _
    '"A00009", _
    '"A00010", _
    '"A00011", _
    '"B00001", _
    '"B00002", _
    '"B00003", _
    '"C00001", _
    '"C00002", _
    '"C00003", _
    '"C00004", _
    '"C00005", _
    '"C00006", _
    '"C00007", _
    '"C00009", _
    '"C00010", _
    '"C00011", _
    '"C00012", _
    '"D00001", _
    '"D00002", _
    '"D00003", _
    '"D00004", _
    '"D00005", _
    '"E00001", _
    '"E00002", _
    '"E00003", _
    '"E00004", _
    '"E00005", _
    '"E00006", _
    '"E00007", _
    '"E00008", _
    '"F00001", _
    '"F00002", _
    '"F00003", _
    '"F00004", _
    '"F00005", _
    '"G00001", _
    '"G00002", _
    '"H00001", _
    '"H00002", _
    '"H00003", _
    '"H00004", _
    '"H00005", _
    '"H00006", _
    '"H00007", _
    '"H00008", _
    '"H00009", _
    '"H00011", _
    '"H00012", _
    '"H00013", _
    '"H00014", _
    '"H00017", _
    '"H00022", _
    '"H00023", _
    '"H00024", _
    '"H00025", _
    '"K00001", _
    '"K00003", _
    '"K00004", _
    '"K00005", _
    '"K00006"}

    '        Dim unitcode() As String = {"B001", "B002", "B003", "B004", "B005", "B006", "B007", "B008", "B009", "B010"}

    '        Dim count As Integer = 0

    '        Try
    '            Dim currentTime = Now

    '            Dim sqlString As String = ""
    '            '"insert into PUB_Item_Value_Unit values('A00006', 'B001', 'Y', '810303', '2009/11/30', null, null) "

    '            For i As Integer = 0 To (ItemCode.Length - 1)

    '                For j As Integer = 0 To (unitcode.Length - 1)
    '                    sqlString = "insert into PUB_Item_Value_Unit values('" & ItemCode(i) & "', '" & unitcode(j) & "', 'Y', '810303', '2009/11/30', null, null) "
    '                    Using command As SqlCommand = New SqlCommand
    '                        With command
    '                            .CommandText = sqlString
    '                            .CommandType = CommandType.Text
    '                            .Connection = CType(conn, SqlConnection)
    '                        End With

    '                        Dim cnt As Integer = command.ExecuteNonQuery
    '                        count = count + cnt
    '                    End Using

    '                Next

    '            Next




    '        Catch sqlex As SqlException
    '            Throw sqlex
    '        Catch ex As Exception
    '            Throw New CommonException("CMMCMMD002", ex)
    '        Finally
    '            conn.Close()
    '            conn.Dispose()
    '            conn = Nothing
    '        End Try


    '        Return count

    '    End Function


    '    Private Function isValueDataNeedSplit(ByVal valueData As String) As String
    '        If valueData IsNot Nothing AndAlso valueData.Length > 0 Then
    '            If valueData.IndexOf(",") > -1 Or valueData.IndexOf("[") > -1 Or valueData.IndexOf("]") > -1 Or valueData.IndexOf("X") > -1 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Else
    '            Return False
    '        End If
    '    End Function

    '''' <summary>
    '''' 查該項目碼資料
    '''' </summary>
    '''' <param name="initValueData"></param>
    '''' <param name="dbSourceProgram"></param>
    '''' <param name="checkDefinedDT"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function splitValueDataToUnit(ByVal initValueData As String, ByVal dbSourceProgram As String, ByVal checkDefinedDT As DataTable) As DataTable
    '    Dim SyscodeBO As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance

    '    Dim unitStr As New StringBuilder
    '    Dim rangeList As New ArrayList
    '    Dim likeList As New ArrayList


    '    Dim splitValueData() As String = initValueData.Split(",")


    '    If splitValueData IsNot Nothing AndAlso splitValueData.Length > 0 Then


    '        If checkSourceProgramCorrect(dbSourceProgram) Then

    '            '------------------------------------------------------------
    '            'TODO 應該從pub_item查出來
    '            '------------------------------------------------------------

    '            Dim dbSplit() As String = dbSourceProgram.Split(";")

    '            Dim queryCondition As New StringBuilder


    '            If DataSetUtil.IsContainsData(checkDefinedDT) AndAlso (dbSplit IsNot Nothing AndAlso dbSplit.Length > 0) Then
    '                Dim selectIndex As Integer = dbSplit(0).IndexOf("select")
    '                Dim fromIndex As Integer = dbSplit(0).IndexOf("from")

    '                CheckColumn = dbSplit(0).Substring(selectIndex + 6, (fromIndex - (selectIndex + 6))).Trim

    '                queryCondition.Append(dbSplit(0))

    '                For i As Integer = 0 To (checkDefinedDT.Columns.Count - 1)

    '                    Dim dc As String = checkDefinedDT.Columns(i).ColumnName

    '                    For j As Integer = 1 To (dbSplit.Length - 1)
    '                        Dim seperatemark As String = "#" & dc & "#"
    '                        If dbSplit(j).IndexOf(seperatemark) > -1 Then
    '                            Dim replaceMsg As String = "'" & CType(checkDefinedDT.Rows(0).Item(dc), String).Trim & "'"
    '                            dbSplit(j) = dbSplit(j).Replace(seperatemark, replaceMsg)

    '                            queryCondition.Append(dbSplit(j))

    '                        End If

    '                    Next

    '                Next

    '            End If

    '            Dim combineCondition As New StringBuilder

    '            For i As Integer = 0 To (splitValueData.Length - 1)
    '                Dim containSpecial As Integer = 0

    '                If splitValueData(i).Contains("[") AndAlso splitValueData(i).IndexOf("[") = 0 Then
    '                    containSpecial += 1
    '                End If
    '                If splitValueData(i).Contains("]") AndAlso splitValueData(i).IndexOf("]") = (splitValueData(i).Length - 1) Then
    '                    containSpecial += 1
    '                End If
    '                If splitValueData(i).Contains("-") Then
    '                    If containSpecial = 2 Then
    '                        Dim content As String = splitValueData(i).Substring(1, splitValueData(i).Length - 2)

    '                        Dim splitContent() As String = content.Split("-")

    '                        If splitContent.Length = 2 Then
    '                            containSpecial += 1
    '                        End If

    '                    End If
    '                End If

    '                If containSpecial = 3 Then
    '                    'rangeStr
    '                    Dim content As String = splitValueData(i).Substring(1, splitValueData(i).Length - 2)
    '                    Dim splitContent() As String = content.Split("-")
    '                    Dim result As String = " between '" & splitContent(0).Trim & "' and '" & splitContent(1).Trim & "'"
    '                    rangeList.Add(result)

    '                ElseIf containSpecial = 0 Then
    '                    If splitValueData(i).Contains("X") Then
    '                        'likeStr
    '                        splitValueData(i) = splitValueData(i).Trim.Replace("X", "%")
    '                        Dim result As String = " like '" & splitValueData(i) & "'"
    '                        likeList.Add(result)
    '                    Else
    '                        'unitStr
    '                        Dim result As String = "'" & splitValueData(i).Trim & "'"
    '                        unitStr.Append(result).Append(",")
    '                    End If
    '                End If

    '            Next

    '            If unitStr.Length > 0 Then
    '                unitStr.Remove(unitStr.Length - 1, 1)
    '            End If


    '            If unitStr.Length > 0 Then
    '                combineCondition.Append(" ").Append(CheckColumn).Append(" in (").Append(unitStr.ToString).Append(") ")
    '            End If

    '            If likeList.Count > 0 Then
    '                If combineCondition.Length > 0 Then
    '                    combineCondition.Append(" or ")
    '                End If

    '                For i As Integer = 0 To (likeList.Count - 1)
    '                    combineCondition.Append(" ").Append(CheckColumn).Append(likeList(i).ToString).Append(" ")

    '                    If i <> (likeList.Count - 1) Then
    '                        combineCondition.Append(" or ")
    '                    End If
    '                Next
    '            End If

    '            If rangeList.Count > 0 Then
    '                If combineCondition.Length > 0 Then
    '                    combineCondition.Append(" or ")
    '                End If

    '                For i As Integer = 0 To (rangeList.Count - 1)
    '                    combineCondition.Append(" ").Append(CheckColumn).Append(rangeList(i).ToString).Append(" ")

    '                    If i <> (rangeList.Count - 1) Then
    '                        combineCondition.Append(" or ")
    '                    End If
    '                Next
    '            End If

    '            If CheckColumn.Length > 0 AndAlso queryCondition.Length > 0 AndAlso combineCondition.Length > 0 Then
    '                Try
    '                    Dim exeSql As String = queryCondition.ToString & " and " & combineCondition.ToString
    '                    Dim existDS As DataSet = SyscodeBO.dynamicQuery(exeSql)

    '                    If DataSetUtil.IsContainsData(existDS) Then
    '                        Return existDS.Tables(0).Copy
    '                    Else
    '                        Return Nothing
    '                    End If

    '                Catch ex As Exception
    '                    log.dbDebugMsg("RuleCheckBS queryExistIcdCodeByCondition fail")
    '                    Throw ex
    '                End Try

    '            Else
    '                Return Nothing
    '            End If

    '        Else
    '            CheckColumn = "Check_Column"
    '            Dim returnSplitDT As DataTable = DataSetUtil.createDataTable("result", Nothing, New String() {CheckColumn}, New Integer() {DataSetUtil.TypeString})
    '            'splitValueData

    '            For i As Integer = 0 To (splitValueData.Length - 1)
    '                Dim splitdr As DataRow = returnSplitDT.NewRow
    '                splitdr.Item(CheckColumn) = splitValueData(i)
    '                returnSplitDT.Rows.Add(splitdr)
    '            Next

    '            Return returnSplitDT
    '        End If


    '    Else
    '        Return Nothing
    '    End If
    'End Function

    'Private Function checkSourceProgramCorrect(ByVal dbSourceProgram As String) As Boolean
    '    'dbSourceProgram
    '    Dim result As Boolean = True

    '    If dbSourceProgram IsNot Nothing AndAlso dbSourceProgram.Length > 0 Then
    '        Dim findIndex As Integer = -1
    '        findIndex = dbSourceProgram.IndexOf("select")
    '        If findIndex = -1 Then
    '            result = False
    '        End If

    '        If result Then
    '            findIndex = dbSourceProgram.IndexOf("from")
    '            If findIndex = -1 Then
    '                result = False
    '            End If
    '        End If

    '    Else
    '        result = False
    '    End If

    '    Return result

    'End Function

    ' ''--------------------------
    '''' <summary>
    '''' 取得ExpressStr
    '''' </summary>
    '''' <param name="classCode"></param>
    '''' <param name="fieldCode"></param>
    '''' <param name="dataType"></param>
    '''' <param name="returnCheckinFlag"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function getExpressionStr(ByVal dataTypeHash As Hashtable, ByVal classCode As String, ByVal fieldCode As String, ByVal dataType As String, ByVal returnCheckinFlag As String, ByVal valueData As String) As String
    '    If dataTypeHash.ContainsKey(classCode) Then
    '        Dim express As String = CType(dataTypeHash.Item(classCode), String).Trim & "@" & fieldCode
    '        If dataType.Equals("1") Then '文字
    '            express = express & "='" & valueData & "'"
    '        ElseIf dataType.Equals("4") Then '外部
    '            If returnCheckinFlag.Equals("N") Then
    '                express = express & "=True"
    '            Else
    '                express = express & "=" & valueData & ""
    '            End If
    '        ElseIf dataType.Equals("5") Then '外部
    '            express = express & "='" & valueData & "'"
    '        Else
    '            express = express & "=" & valueData & ""
    '        End If

    '        Return "(" & express & ")"
    '    Else
    '        Return ""
    '    End If
    'End Function

End Class
