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


Public Class PUBRuleCheckBS
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

    Public Shared Function getInstance() As PUBRuleCheckBS
        Try

            Return New PUBRuleCheckBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Dim log As Syscom.Server.CMM.LOGDelegate = Syscom.Server.CMM.LOGDelegate.getInstance
    Private CheckColumn As String = ""

    ''' <summary>
    ''' 初始規則檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBRuleCheckUIInfo() As DataSet
        Dim ItemDS As New DataSet
        Dim ItemDT As DataTable = PUBItemBO_E1.getInstance.queryPUBItemData
        ItemDS.Tables.Add(ItemDT)

        Dim typeIds() As Integer = {801, 802, 803, 804}
        Dim SyscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(typeIds)
        ItemDS.Tables.Add(SyscodeDT)

        Dim PubItemValueUnitDT As DataTable = PUBItemValueUnitBO_E1.getInstance.queryItemValueUnitData
        ItemDS.Tables.Add(PubItemValueUnitDT)

        Dim PubUnitDT As DataTable = PUBUnitBO_E1.getInstance.queryUnitForCombo
        ItemDS.Tables.Add(PubUnitDT)

        If DataSetUtil.IsContainsData(ItemDT) Then
            Dim itemCodes(ItemDT.Rows.Count - 1) As String

            For i As Integer = 0 To (ItemDT.Rows.Count - 1)
                itemCodes(i) = CType(ItemDT.Rows(i).Item("Item_Code"), String).Trim
            Next

            Dim PubOperator As DataTable = PUBItemOperatorBO_E1.getInstance.queryOperatorData(itemCodes)

            If DataSetUtil.IsContainsData(PubOperator) Then
                ItemDS.Tables.Add(PubOperator)
            End If
        End If



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

    ''' <summary>
    ''' 查詢規則檢核資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBRuleQueryInfo() As DataSet
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

    ''' <summary>
    ''' 程式說明：依名稱查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleParam">規則條件(起始)</param>
    ''' <returns>DataTable</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataSet

        If DataSetUtil.IsContainsData(RuleParam) Then

            Dim ruleRelatedDT As DataTable = PUBRuleClassBO_E1.getInstance.queryInitRuleDataByParam(RuleParam)

            If DataSetUtil.IsContainsData(ruleRelatedDT) Then

                Dim RuleDS As New DataSet

                Dim ruleCodes(ruleRelatedDT.Rows.Count - 1) As String
                For i As Integer = 0 To (ruleRelatedDT.Rows.Count - 1)
                    ruleCodes(i) = CType(ruleRelatedDT.Rows(i).Item("Trigger_Rule_Code"), String).Trim
                Next

                Try
                    Dim initRuleDT As DataTable = PUBRuleBO_E1.getInstance.queryRuleDataByRuleCodes(ruleCodes)
                    Dim initRuleDetailDT As DataTable = PUBRuleDetailBO_E1.getInstance.queryRuleDetailByRuleCodes(ruleCodes)

                    Dim initMaintainDT As DataTable = PubRuleMaintainDataTableFactory.getDataTableWithSchema
                    Dim maintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

                    If DataSetUtil.IsContainsData(initRuleDT) Then
                        RuleDS.Tables.Add(initRuleDT)
                    End If
                    If DataSetUtil.IsContainsData(initRuleDetailDT) Then

                        For Each dr As DataRow In initRuleDetailDT.Rows
                            Dim maintainsn As Integer = -1
                            Dim seqno As Integer = -1
                            Dim itemcode As String = ""

                            If Not IsDBNull(dr.Item("Rule_Maintain_Sn")) Then
                                maintainsn = CType(dr.Item("Rule_Maintain_Sn"), Integer)
                            End If
                            If Not IsDBNull(dr.Item("Seq_No")) Then
                                seqno = CType(dr.Item("Seq_No"), Integer)
                            End If
                            If Not IsDBNull(dr.Item("Item_Code")) Then
                                itemcode = CType(dr.Item("Item_Code"), String).Trim
                            End If

                            If (maintainsn <= 0) AndAlso (seqno <= 0) AndAlso (Not itemcode.Equals("")) Then
                                Dim maintainds As DataSet = maintainBO.queryByPK(maintainsn, seqno, itemcode)
                                If DataSetUtil.IsContainsData(maintainds) Then
                                    initMaintainDT.Rows.Add(maintainds.Tables(0).Rows(0).ItemArray)
                                End If

                            End If

                        Next


                        RuleDS.Tables.Add(initRuleDetailDT)

                        RuleDS.Tables.Add(initMaintainDT)
                    End If

                    Return RuleDS
                Catch ex As Exception
                    log.dbDebugMsg("Rule Query Error")
                    Return Nothing
                End Try

            Else
                Return Nothing
            End If

        Else

            Return Nothing
        End If


    End Function



    Public Function querySelectedRuleData(ByVal selectInitRuleCode As String) As DataSet

        Dim RuleDS As New DataSet
        '-------------------------------------------------------
        'selectInitRuleCode ->起始rulecode去查資料
        If selectInitRuleCode IsNot Nothing AndAlso selectInitRuleCode.Length > 0 Then

            '起始>>接到rule_code
            Dim selectedRuleDT As DataTable = PUBRuleClassBO_E1.getInstance.queryRuleCodeByInitRuleCode(selectInitRuleCode)

            If DataSetUtil.IsContainsData(selectedRuleDT) Then
                Dim selectRuleCode As String = CType(selectedRuleDT.Rows(0).Item("Rule_Code"), String).Trim

                Dim ruleClassDT As DataTable = PUBRuleClassBO_E1.getInstance.queryRuleClassByRuleCode(selectRuleCode)
                If DataSetUtil.IsContainsData(ruleClassDT) Then 'condition_type = 1,2,3

                    Dim initRule As String = ""
                    Dim checkRule As String = ""

                    For Each classdr As DataRow In ruleClassDT.Rows
                        Dim conditionType As String = CType(ruleClassDT.Rows(0).Item("Condition_Type"), String).Trim
                        If conditionType.Equals("1") Then

                            initRule = CType(classdr.Item("Condition_Rule_Code"), String).Trim

                            checkRule = CType(ruleClassDT.Rows(0).Item("Rule_Code"), String).Trim

                        ElseIf conditionType.Equals("2") Then '成功街

                        ElseIf conditionType.Equals("3") Then '失敗皆

                        End If
                    Next

                    RuleDS.Tables.Add(ruleClassDT.Copy)


                    '起始
                    Dim initRuleDT As DataTable = PUBRuleBO_E1.getInstance.queryRuleDataByRuleCode(initRule)
                    If DataSetUtil.IsContainsData(initRuleDT) Then
                        initRuleDT.TableName = "INIT-" & PubRuleDataTableFactory.tableName
                        RuleDS.Tables.Add(initRuleDT)
                    End If
                    '檢核
                    Dim checkRuleDT As DataTable = PUBRuleBO_E1.getInstance.queryRuleDataByRuleCode(checkRule)
                    If DataSetUtil.IsContainsData(checkRuleDT) Then
                        checkRuleDT.TableName = "CHECK-" & PubRuleDataTableFactory.tableName
                        RuleDS.Tables.Add(checkRuleDT)
                    End If

                    Dim initRuleDetailDT As DataTable = PUBRuleDetailBO_E1.getInstance.queryRuleDetailByRuleCode(initRule)

                    If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                        initRuleDetailDT.TableName = "INIT-" & PubRuleDetailDataTableFactory.tableName
                        RuleDS.Tables.Add(initRuleDetailDT)
                        'Rule_Maintain_Sn
                        If Not IsDBNull(initRuleDetailDT.Rows(0).Item("Rule_Maintain_Sn")) Then
                            Dim maintainsn As Integer = CType(initRuleDetailDT.Rows(0).Item("Rule_Maintain_Sn"), Integer)
                            If maintainsn > 0 Then
                                Dim itemCode As String = CType(initRuleDetailDT.Rows(0).Item("Item_Code"), String).Trim

                                Dim ruleMaintainDS As DataSet = PUBRuleMaintainBO_E1.getInstance.queryByPK(maintainsn, 1, itemCode)
                                If DataSetUtil.IsContainsData(ruleMaintainDS) Then
                                    Dim ruleMaintainDT As DataTable = ruleMaintainDS.Tables(0).Copy
                                    ruleMaintainDT.TableName = PubRuleMaintainDataTableFactory.tableName
                                    RuleDS.Tables.Add(ruleMaintainDT)
                                End If
                            Else
                                'no Rule_Maintain_Sn
                            End If
                        Else
                            'no Rule_Maintain_Sn

                        End If


                        Dim checkRuleDetailDT As DataTable = PUBRuleDetailBO_E1.getInstance.queryRuleDetailByRuleCode(checkRule)
                        If DataSetUtil.IsContainsData(checkRuleDetailDT) Then
                            checkRuleDetailDT.TableName = "CHECK-" & PubRuleDetailDataTableFactory.tableName
                            RuleDS.Tables.Add(checkRuleDetailDT)
                        End If

                        Return RuleDS

                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        Else
            Return Nothing
        End If


    End Function



    ''' <summary>
    ''' 程式說明：確認查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="confirmType">確認類別</param>
    ''' <param name="RuleDS">規則資料</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function confirmRuleData(ByVal confirmType As String, ByVal RuleDS As DataSet) As Integer

        Dim systemDate As Date = DateUtil.getSystemDate
        'Dim ruleCodeList As ArrayList = New ArrayList

        Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
        Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
        Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance

        ''
        Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

        Dim rulecodeValuedataHash As New Hashtable

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

        'check insert or update

        If DataSetUtil.IsContainsData(RuleDS) Then
            Dim processSRuleDT As DataTable = PubRuleDataTableFactory.getDataTableWithSchema

            Dim insertRuleDT As DataTable = PubRuleDataTableFactory.getDataTableWithSchema
            'Dim updateRuleDT As DataTable = PubRuleDataTableFactory.getDataTableWithSchema

            Dim processSRuleDetailDT As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema

            Dim insertRuleDetailDT As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema
            'Dim updateRuleDetailDT As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema

            Dim processSRuleClassDT As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema

            Dim insertRuleClassDT As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema
            'Dim updateRuleClassDT As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema

            Dim initRuleCode As String = "" '第一筆
            Dim checkRuleCode As String = ""

            Dim initRuleDR As DataRow = Nothing '第一筆
            Dim checkRuleDR As DataRow = Nothing

            Dim SItemCode As String = ""

            Dim valueDataDT As DataTable = Nothing

            '新增到PubRuleReason裡面
            If RuleDS.Tables.Contains("PubRuleReason") AndAlso RuleDS.Tables("PubRuleReason").Rows.Count > 0 Then

                Dim dsRuleReason As New DataSet
                dsRuleReason.Tables.Add(RuleDS.Tables("PubRuleReason").Copy)

                Dim PubRuleReasonBO As PubRuleReasonBO = PubRuleReasonBO.GetInstance
                Dim PubPuleReasonBOE2 As PubPuleReasonBO_E2 = PubPuleReasonBO_E2.GetInstance

                '先刪除，再新增
                Dim deleteRuleReason As String = dsRuleReason.Tables("PubRuleReason").Rows(0).Item("Rule_Code").ToString.Trim
                PubPuleReasonBOE2.deleteByPkRuleCode(deleteRuleReason)
                PubRuleReasonBO.insert(dsRuleReason)

            End If

            'TODO rule_class
            If RuleDS.Tables.Contains(PubRuleClassDataTableFactory.tableName) Then
                'processSRuleDT 
                'insertRuleDT 
                'updateRuleDT

                Dim ruleClassDT As DataTable = RuleDS.Tables(PubRuleClassDataTableFactory.tableName).Copy
                'Dim seqno As Integer = 1
                For Each dr As DataRow In ruleClassDT.Rows
                    If Not IsDBNull(dr.Item("Condition_Type")) Then
                        If CType(dr.Item("Condition_Type"), String).Trim.Equals("1") Then
                            '應該只有一筆
                            '起始條件, modify it(前端弄成-S1)
                            initRuleCode = CType(dr.Item("Condition_Rule_Code"), String).Trim
                            checkRuleCode = CType(dr.Item("Rule_Code"), String).Trim

                            processSRuleClassDT.Rows.Add(dr.ItemArray)

                        Else
                            If Not IsDBNull(dr.Item("Modified_User")) Then
                                'update
                                dr.Item("Modified_Time") = systemDate
                                insertRuleClassDT.Rows.Add(dr.ItemArray)
                            Else
                                'insert
                                Dim checkDS As DataSet = ruleClassBO.queryByPK(CType(dr.Item("Rule_Code"), String).Trim, CType(dr.Item("Condition_Type"), String).Trim, CType(dr.Item("Seq_No"), Integer), CType(dr.Item("Condition_Rule_Code"), String).Trim)
                                If DataSetUtil.IsContainsData(checkDS) Then
                                    dr.Item("Modified_User") = CType(dr.Item("Create_User"), String).Trim
                                    dr.Item("Modified_Time") = systemDate

                                    dr.Item("Create_User") = CType(checkDS.Tables(0).Rows(0).Item("Create_User"), String).Trim
                                    dr.Item("Create_Time") = CType(checkDS.Tables(0).Rows(0).Item("Create_Time"), Date)

                                    insertRuleClassDT.Rows.Add(dr.ItemArray)
                                Else
                                    dr.Item("Create_Time") = systemDate
                                    insertRuleClassDT.Rows.Add(dr.ItemArray)
                                End If
                            End If

                        End If

                    End If


                Next
            End If


            '已取得 initRuleCode checkRuleCode 

            If (initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0) AndAlso (checkRuleCode IsNot Nothing AndAlso checkRuleCode.Length > 0) Then


                If RuleDS.Tables.Contains(PubRuleDataTableFactory.tableName) Then

                    Dim ruleDT As DataTable = RuleDS.Tables(PubRuleDataTableFactory.tableName).Copy



                    For Each dr As DataRow In ruleDT.Rows

                        Dim processRuleCode As String = CType(dr.Item("Rule_Code"), String).Trim

                        'ruleCodeList.Add(processRuleCode)


                        If processRuleCode.Equals(initRuleCode) Then
                            '起始
                            If Not IsDBNull(dr.Item("Modified_User")) Then
                                'update
                                dr.Item("Modified_Time") = systemDate
                                initRuleDR = dr
                                'processSRuleDT.Rows.Add(dr.ItemArray)

                                processSRuleDT.Rows.Add(dr.ItemArray)
                            Else
                                'insert
                                Dim checkDS As DataSet = ruleBO.queryByPK(CType(dr.Item("Rule_Code"), String).Trim)
                                If DataSetUtil.IsContainsData(checkDS) Then
                                    dr.Item("Modified_User") = CType(dr.Item("Create_User"), String).Trim
                                    dr.Item("Modified_Time") = systemDate

                                    dr.Item("Create_User") = CType(checkDS.Tables(0).Rows(0).Item("Create_User"), String).Trim
                                    dr.Item("Create_Time") = CType(checkDS.Tables(0).Rows(0).Item("Create_Time"), Date)

                                    'processSRuleDT.Rows.Add(dr.ItemArray)
                                    initRuleDR = dr

                                    processSRuleDT.Rows.Add(dr.ItemArray)

                                Else
                                    dr.Item("Create_Time") = systemDate
                                    'processSRuleDT.Rows.Add(dr.ItemArray)
                                    initRuleDR = dr

                                    processSRuleDT.Rows.Add(dr.ItemArray)
                                End If

                            End If
                        Else
                            '檢核
                            If Not IsDBNull(dr.Item("Modified_User")) Then
                                'update
                                dr.Item("Modified_Time") = systemDate
                                'updateRuleDT.Rows.Add(dr.ItemArray)
                                checkRuleDR = dr

                                insertRuleDT.Rows.Add(dr.ItemArray)
                            Else
                                'insert
                                Dim checkDS As DataSet = ruleBO.queryByPK(CType(dr.Item("Rule_Code"), String).Trim)
                                If DataSetUtil.IsContainsData(checkDS) Then
                                    dr.Item("Modified_User") = CType(dr.Item("Create_User"), String).Trim
                                    dr.Item("Modified_Time") = systemDate

                                    dr.Item("Create_User") = CType(checkDS.Tables(0).Rows(0).Item("Create_User"), String).Trim
                                    dr.Item("Create_Time") = CType(checkDS.Tables(0).Rows(0).Item("Create_Time"), Date)

                                    'updateRuleDT.Rows.Add(dr.ItemArray)
                                    checkRuleDR = dr

                                    insertRuleDT.Rows.Add(dr.ItemArray)
                                Else
                                    dr.Item("Create_Time") = systemDate
                                    'insertRuleDT.Rows.Add(dr.ItemArray)
                                    checkRuleDR = dr


                                    insertRuleDT.Rows.Add(dr.ItemArray)
                                End If

                            End If

                        End If

                    Next

                End If


                '981229 TODO

                Dim initValueData As String = ""
                If RuleDS.Tables.Contains("valuedata") Then
                    valueDataDT = RuleDS.Tables("valuedata")
                    If DataSetUtil.IsContainsData(valueDataDT) Then

                        initValueData = CType(valueDataDT.Rows(0).Item("Value_Data"), String).Trim

                        'dataTypeHash

                    End If

                End If


                'Dim belongItemCode As String = ""
                'belongItemCode = tmpInitRule.Substring(4, tmpInitRule.Length - 4)
                'belongItemCode = belongItemCode.Substring(0, belongItemCode.Length - 10)


                Dim ruleMaintainDT As DataTable = PubRuleMaintainDataTableFactory.getDataTableWithSchema
                Dim maintaindr As DataRow = ruleMaintainDT.NewRow


                'ruleDetail
                If RuleDS.Tables.Contains(PubRuleDetailDataTableFactory.tableName) Then
                    Dim ruleDetailDT As DataTable = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Copy
                    Dim PUB_Rule_Detail_Seq_No As Integer = 0
                    Dim PUB_Rule_Maintain_Detail_Seq_No As Integer = 0

                    Dim RuleMaintainSn As Integer = -1
                    For Each dr As DataRow In ruleDetailDT.Rows
                        Dim processRuleCode As String = CType(dr.Item("Rule_Code"), String).Trim
                        If processRuleCode.Equals(initRuleCode) Then
                            'if initValueData 只有一筆 不加maintain

                            SItemCode = CType(dr.Item("Item_Code"), String).Trim
                            Dim needSplit As Boolean = isValueDataNeedSplit(initValueData)

                            If needSplit Then
                                Dim seqNo As Integer = 1

                                'Rule_Maintain_Sn
                                If RuleMaintainSn = -1 Then
                                    If CType(dr.Item("Rule_Maintain_Sn"), Integer) = -1 Then
                                        RuleMaintainSn = getRuleMaintainSerialNo()
                                    Else
                                        RuleMaintainSn = CType(dr.Item("Rule_Maintain_Sn"), Integer)
                                    End If
                                End If

                                maintaindr.Item("Rule_Maintain_Sn") = RuleMaintainSn
                                'If PUB_Rule_Maintain_Detail_Seq_No = 0 Then
                                '    PUB_Rule_Maintain_Detail_Seq_No = QueryPubRuleMaintainMaxSeqNo(RuleMaintainSn) + 1
                                'Else
                                PUB_Rule_Maintain_Detail_Seq_No = PUB_Rule_Maintain_Detail_Seq_No + 1
                                'End If

                                maintaindr.Item("Seq_No") = PUB_Rule_Maintain_Detail_Seq_No
                                maintaindr.Item("Item_Code") = SItemCode
                                maintaindr.Item("Maintain_Value_Str") = initValueData

                                ruleMaintainDT.Rows.Add(maintaindr)

                                '加入process 啟始條件(特別處理)

                                dr.Item("Rule_Maintain_Sn") = RuleMaintainSn
                                processSRuleDetailDT.Rows.Add(dr.ItemArray)
                            Else
                                '不需分
                                dr.Item("rule_maintain_Sn") = -1
                                dr.Item("Value_Data") = initValueData
                                processSRuleDetailDT.Rows.Add(dr.ItemArray)
                            End If

                            Exit For

                        End If

                    Next

                    'processSRuleDetailDT 內只有一筆


                    For Each dr As DataRow In ruleDetailDT.Rows

                        Dim ruleCode As String = CType(dr.Item("Rule_Code"), String).Trim
                        Dim seqNo As Integer = CType(dr.Item("Seq_No"), Integer)
                        Dim itemCode As String = CType(dr.Item("Item_Code"), String).Trim

                        If ruleCode.Equals(checkRuleCode) Then

                            dr.Item("Rule_Maintain_Sn") = RuleMaintainSn

                            If Not IsDBNull(dr.Item("Modified_User")) Then
                                'update
                                dr.Item("Modified_Time") = systemDate
                                insertRuleDetailDT.Rows.Add(dr.ItemArray)
                            Else
                                'insert
                                Dim checkDS As DataSet = ruleDetailBO.queryByPK(ruleCode, seqNo, itemCode)
                                If DataSetUtil.IsContainsData(checkDS) Then
                                    dr.Item("Modified_User") = CType(dr.Item("Create_User"), String).Trim
                                    dr.Item("Modified_Time") = systemDate

                                    dr.Item("Create_User") = CType(checkDS.Tables(0).Rows(0).Item("Create_User"), String).Trim
                                    dr.Item("Create_Time") = CType(checkDS.Tables(0).Rows(0).Item("Create_Time"), Date)

                                    insertRuleDetailDT.Rows.Add(dr.ItemArray)
                                Else
                                    dr.Item("Create_Time") = systemDate


                                    log.dbDebugMsg("ItemArrayCount =>> " & dr.ItemArray.Count)
                                    For i As Integer = 0 To (dr.ItemArray.Count - 1)
                                        log.dbDebugMsg("-----ItemArrayDetail =>> " & dr.ItemArray(i))
                                    Next
                                    log.dbDebugMsg("RuleDetailColumnCount =>> " & insertRuleDetailDT.Columns.Count)
                                    For i As Integer = 0 To (insertRuleDetailDT.Columns.Count - 1)
                                        log.dbDebugMsg("-----RuleDetailColumnDetail =>> " & insertRuleDetailDT.Columns.Item(i).ColumnName)
                                    Next

                                    insertRuleDetailDT.Rows.Add(dr.ItemArray)
                                End If
                                'insertRuleDetailDT.Rows.Add(dr.ItemArray)
                            End If

                        End If


                    Next

                End If


                '----------------------------------------
                If initValueData.Length > 0 AndAlso SItemCode.Length > 0 Then

                    If isValueDataNeedSplit(initValueData) Then

                        '轉置資料
                        '看分成多個已存在的成大碼
                        '
                        '...
                        'SItemCode
                        Dim itemDS As DataSet = PUBItemBO_E1.getInstance.queryByPK(SItemCode)

                        Dim checkDefineDT As DataTable = Nothing
                        If RuleDS.Tables.Contains("ForCheck") Then
                            checkDefineDT = RuleDS.Tables("ForCheck")
                        End If

                        '-------------------------------
                        '轉成多筆起始
                        'processSRuleDT
                        If DataSetUtil.IsContainsData(itemDS) Then

                            Dim valueProgram As String = ""
                            If (Not IsDBNull(itemDS.Tables(0).Rows(0).Item("Value_Source_Program"))) Then
                                valueProgram = CType(itemDS.Tables(0).Rows(0).Item("Value_Source_Program"), String)
                            End If


                            '------
                            'add 2015/11/11
                            Dim item_code = RuleDS.Tables(PubRuleDetailDataTableFactory.tableName).Copy.Rows(0)("Item_Code").ToString
                            Dim existValueDataCheckDT As DataTable = splitValueDataToUnit(initValueData, valueProgram, checkDefineDT, item_code)

                            If DataSetUtil.IsContainsData(existValueDataCheckDT) Then
                                If DataSetUtil.IsContainsData(processSRuleDT) Then
                                    Dim ClassCode As String = CType(itemDS.Tables(0).Rows(0).Item("Class_Code"), String).Trim
                                    Dim FieldCode As String = CType(itemDS.Tables(0).Rows(0).Item("Field_Code"), String).Trim
                                    Dim DataType As String = CType(itemDS.Tables(0).Rows(0).Item("Data_Type"), String).Trim
                                    Dim ReturnCheckingFlag As String = CType(itemDS.Tables(0).Rows(0).Item("Return_Checking_Flag"), String).Trim
                                    '1
                                    processSRuleDT.Rows(0).Item("Expression_Str") = getExpressionStr(dataTypeHash, ClassCode, FieldCode, DataType, ReturnCheckingFlag, CType(existValueDataCheckDT.Rows(0).Item(CheckColumn), String).Trim)



                                    Dim templateDT As DataTable = processSRuleDT.Copy

                                    processSRuleDT.Clear()

                                    'insertRuleClassDT

                                    Dim templateSClassDT As DataTable = processSRuleClassDT.Copy

                                    processSRuleClassDT.Clear()

                                    If existValueDataCheckDT.Rows.Count > 0 Then

                                        '第一個之後

                                        For i As Integer = 0 To (existValueDataCheckDT.Rows.Count - 1)

                                            Dim index As Integer = i + 1
                                            templateDT.Rows(0).Item("Rule_Code") = checkRuleCode & "-S" & index
                                            templateDT.Rows(0).Item("Expression_Str") = getExpressionStr(dataTypeHash, ClassCode, FieldCode, DataType, ReturnCheckingFlag, CType(existValueDataCheckDT.Rows(i).Item(CheckColumn), String).Trim)

                                            rulecodeValuedataHash.Add(CType(templateDT.Rows(0).Item("Rule_Code"), String).Trim, CType(existValueDataCheckDT.Rows(i).Item(CheckColumn), String).Trim)

                                            processSRuleDT.Rows.Add(templateDT.Rows(0).ItemArray)


                                            templateSClassDT.Rows(0).Item("Condition_Rule_Code") = checkRuleCode & "-S" & index

                                            processSRuleClassDT.Rows.Add(templateSClassDT.Rows(0).ItemArray)

                                        Next

                                    End If

                                End If



                                'processSRuleDetailDT 1

                                If DataSetUtil.IsContainsData(processSRuleDetailDT) Then
                                    Dim tempSRuleDetailDT As DataTable = processSRuleDetailDT.Copy

                                    processSRuleDetailDT.Clear()


                                    If DataSetUtil.IsContainsData(processSRuleDT) Then
                                        For i As Integer = 0 To (processSRuleDT.Rows.Count - 1)
                                            Dim ruleCode As String = CType(processSRuleDT.Rows(i).Item("Rule_Code"), String).Trim

                                            tempSRuleDetailDT.Rows(0).Item("Rule_Code") = ruleCode

                                            If rulecodeValuedataHash.ContainsKey(ruleCode) Then
                                                tempSRuleDetailDT.Rows(0).Item("Value_Data") = rulecodeValuedataHash.Item(ruleCode)

                                                If Not IsDBNull(tempSRuleDetailDT.Rows(0).Item("Modified_User")) Then
                                                    tempSRuleDetailDT.Rows(0).Item("Modified_Time") = systemDate
                                                Else
                                                    tempSRuleDetailDT.Rows(0).Item("Create_Time") = systemDate
                                                End If

                                                processSRuleDetailDT.Rows.Add(tempSRuleDetailDT.Rows(0).ItemArray)
                                            End If

                                        Next
                                    End If


                                End If



                            Else
                                Return SQLDataUtil.EXECUTE_LACK_OF_DATA
                            End If

                            '------

                        Else
                            Return SQLDataUtil.EXECUTE_LACK_OF_BASIC
                        End If

                    Else
                        '不需轉,目前的資料即可使用

                    End If

                Else
                    Return SQLDataUtil.EXECUTE_LACK_OF_DATA '
                End If


                Dim ruleRelatedNeedDeleteDT As DataTable = ruleClassBO.queryRuleClassByRuleCode(checkRuleCode)
                Dim ruleCodeList As New ArrayList


                If DataSetUtil.IsContainsData(ruleRelatedNeedDeleteDT) Then
                    ruleCodeList.Add(checkRuleCode)
                    For Each dr As DataRow In ruleRelatedNeedDeleteDT.Rows
                        Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim
                        If conditionType.Equals("1") Then
                            ruleCodeList.Add(CType(dr.Item("Condition_Rule_Code"), String).Trim)
                        Else '2 or 3
                            ruleCodeList.Add(CType(dr.Item("Rule_Code"), String).Trim)
                        End If
                    Next
                End If



                Dim nextFlag As Boolean = True







                Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiredTransactionScope()

                    'TODO
                    If confirmType IsNot Nothing AndAlso confirmType.Equals(SQLDataUtil.CLONE_TYPE) Then
                        '要將valuedata內rulecode時間範圍調整
                        If DataSetUtil.IsContainsData(valueDataDT) Then
                            'rulecode更改日期
                            Dim oldRuleClassRelated As DataTable = ruleClassBO.queryRuleClassByRuleCode(CType(valueDataDT.Rows(0).Item("Old_Rule_Code"), String).Trim)
                            If DataSetUtil.IsContainsData(oldRuleClassRelated) Then
                                Dim RuleHash As New Hashtable
                                Dim ruleList As New ArrayList
                                For i As Integer = 0 To (oldRuleClassRelated.Rows.Count - 1)
                                    Dim rule As String = CType(oldRuleClassRelated.Rows(i).Item("Rule_Code"), String).Trim
                                    Dim condrule As String = CType(oldRuleClassRelated.Rows(i).Item("Condition_Rule_Code"), String).Trim

                                    If Not RuleHash.ContainsKey(rule) Then
                                        RuleHash.Add(rule, "")
                                        ruleList.Add(rule)
                                    End If

                                    If Not RuleHash.ContainsKey(condrule) Then
                                        RuleHash.Add(condrule, "")
                                        ruleList.Add(condrule)
                                    End If

                                Next

                                If ruleList.Count > 0 Then

                                    Dim ruleCodes(ruleList.Count - 1) As String
                                    For i As Integer = 0 To (ruleList.Count - 1)
                                        ruleCodes(i) = CType(ruleList.Item(i), String).Trim
                                    Next

                                    Dim validDate As String = CType(valueDataDT.Rows(0).Item("Valid_Date_S"), String).Trim
                                    Try
                                        Dim endDate As Date = Date.Parse(validDate)
                                        endDate = endDate.AddDays(-1)

                                        If nextFlag AndAlso ruleCodes.Length > 0 Then
                                            Try
                                                Dim result As Integer = ruleBO.updateValidDateEByRuleCode(ruleCodes, endDate)
                                                If result > 0 Then

                                                Else
                                                    nextFlag = False
                                                End If
                                            Catch ex As Exception
                                                nextFlag = False
                                                log.dbDebugMsg("update Pub_Rule-S date data error >> " & ex.Message)
                                            End Try
                                        End If


                                    Catch ex As Exception
                                        nextFlag = False
                                        log.dbDebugMsg("Pub_Rule-S date parse error >> " & ex.Message)
                                    End Try

                                End If


                            End If


                        End If
                    End If

                    If ruleCodeList.Count > 0 Then
                        Dim ruleCodes(ruleCodeList.Count - 1) As String
                        For i As Integer = 0 To (ruleCodeList.Count - 1)
                            ruleCodes(i) = CType(ruleCodeList.Item(i), String).Trim
                        Next

                        'all delete
                        ruleBO.deleteByRuleCodes(ruleCodes)
                        ruleDetailBO.deleteByRuleCodes(ruleCodes)
                        'ruleclass
                        ruleClassBO.deleteByRuleCode(checkRuleCode)

                    End If



                    If DataSetUtil.IsContainsData(ruleMaintainDT) Then
                        ruleMaintainBO.delete(CType(ruleMaintainDT.Rows(0).Item("Rule_Maintain_Sn"), Integer), CType(ruleMaintainDT.Rows(0).Item("Seq_No"), Integer), CType(ruleMaintainDT.Rows(0).Item("Item_Code"), String))

                    End If


                    If nextFlag AndAlso DataSetUtil.IsContainsData(insertRuleDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(insertRuleDT)
                            Dim result As Integer = ruleBO.insertBySetCreateTime(insertDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule data error >> " & ex.Message)
                        End Try
                    End If

                    'If nextFlag AndAlso DataSetUtil.IsContainsData(updateRuleDT) Then
                    '    Try
                    '        Dim updateDS As DataSet = New DataSet
                    '        updateDS.Tables.Add(updateRuleDT)
                    '        Dim result As Integer = ruleBO.insertBySetCreateTime(updateDS)
                    '    Catch ex As Exception
                    '        nextFlag = False
                    '        log.dbDebugMsg("update Pub_Rule data error >> " & ex.Message)
                    '    End Try
                    'End If


                    'processSRuleDT
                    If nextFlag AndAlso DataSetUtil.IsContainsData(processSRuleDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(processSRuleDT)
                            Dim result As Integer = ruleBO.insertBySetCreateTime(insertDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule-S data error >> " & ex.Message)
                        End Try
                    End If



                    'processSRuleDetailDT

                    If nextFlag AndAlso DataSetUtil.IsContainsData(insertRuleDetailDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(insertRuleDetailDT)
                            Dim result As Integer = ruleDetailBO.insertBySetCreateTime(insertDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule_Detail data error >> " & ex.Message)
                        End Try
                    End If






                    'If nextFlag AndAlso DataSetUtil.IsContainsData(updateRuleDetailDT) Then
                    '    Try
                    '        Dim updateDS As DataSet = New DataSet
                    '        updateDS.Tables.Add(updateRuleDetailDT)
                    '        Dim result As Integer = ruleDetailBO.insertBySetCreateTime(updateDS)
                    '    Catch ex As Exception
                    '        nextFlag = False
                    '        log.dbDebugMsg("update Pub_Rule_Detail data error >> " & ex.Message)
                    '    End Try
                    'End If

                    If nextFlag AndAlso DataSetUtil.IsContainsData(processSRuleDetailDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(processSRuleDetailDT)
                            Dim result As Integer = ruleDetailBO.insertBySetCreateTime(insertDS)
                            '增加  如果是成大碼和健保碼
                            '要回去改變PUB_Order的is_order_check="Y"
                            '健保碼要轉換成大碼
                            '
                            'Item_code='A00004 成大碼
                            'Item_Cdoe='A00006 健保碼
                            Dim Item_code As String = insertDS.Tables(0).Rows(0).Item("Item_Code").ToString.Trim
                            Dim order_code As String = ""
                            Dim pp As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance

                            If Item_code.Equals("A00004") Or Item_code.Equals("A00006") Then



                                If Item_code.Equals("A00004") Then
                                    order_code = insertDS.Tables(0).Rows(0).Item("Value_Data").ToString.Trim

                                ElseIf Item_code.Equals("A00006") Then

                                    '成大碼轉健保碼
                                    Dim t1 As New DataSet
                                    t1.Tables.Add(New DataTable)
                                    t1.Tables(0).Columns.Add("Order_Code")
                                    Dim asr As DataRow = t1.Tables(0).NewRow
                                    asr.Item("Order_code") = ""


                                End If

                                Dim sql As String = "Update PUB_Order set is_Order_Check='Y' where order_code='" + order_code + "'"
                                result = pp.updatepub_order(sql)

                            End If



                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule_Detail-S data error >> " & ex.Message)
                        End Try
                    End If









                    If nextFlag AndAlso DataSetUtil.IsContainsData(insertRuleClassDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(insertRuleClassDT)
                            Dim result As Integer = ruleClassBO.insertBySetCreateTime(insertDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule_Class data error >> " & ex.Message)
                        End Try
                    End If


                    If nextFlag AndAlso DataSetUtil.IsContainsData(processSRuleClassDT) Then
                        Try
                            Dim insertDS As DataSet = New DataSet
                            insertDS.Tables.Add(processSRuleClassDT)
                            Dim result As Integer = ruleClassBO.insertBySetCreateTime(insertDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule_Class data error >> " & ex.Message)
                        End Try
                    End If


                    'If nextFlag AndAlso DataSetUtil.IsContainsData(updateRuleClassDT) Then
                    '    Try
                    '        Dim updateDS As DataSet = New DataSet
                    '        updateDS.Tables.Add(updateRuleClassDT)
                    '        Dim result As Integer = ruleClassBO.insertBySetCreateTime(updateDS)
                    '    Catch ex As Exception
                    '        nextFlag = False
                    '        log.dbDebugMsg("update Pub_Rule_Class data error >> " & ex.Message)
                    '    End Try
                    'End If

                    If nextFlag AndAlso DataSetUtil.IsContainsData(ruleMaintainDT) Then
                        'ruleMaintainBO.delete(CType(ruleMaintainDT.Rows(0).Item("Rule_Maintain_Sn"), Integer), CType(ruleMaintainDT.Rows(0).Item("Seq_No"), Integer), CType(ruleMaintainDT.Rows(0).Item("Item_Code"), String))

                        Dim maintainDS As New DataSet
                        maintainDS.Tables.Add(ruleMaintainDT)
                        Try
                            Dim result As Integer = ruleMaintainBO.insert(maintainDS)
                        Catch ex As Exception
                            nextFlag = False
                            log.dbDebugMsg("insert Pub_Rule_Maintain data error >> " & ex.Message)
                        End Try

                    End If


                    If nextFlag Then
                        'process complete
                        Scope.Complete()
                    Else
                        Scope.Dispose()
                    End If



                    '增加  如果是成大碼和健保碼
                    '要回去改變PUB_Order的is_order_check="Y"
                    '健保碼要轉換成大碼
                    '
                    'Item_code='A00004 成大碼
                    'Item_Cdoe='A00006 健保碼







                End Using

                If nextFlag Then
                    Return SQLDataUtil.EXECUTE_SUCCESS
                Else
                    Return SQLDataUtil.EXECUTE_SUCCESS
                End If

            Else
                'rulecode不可維空
                Return False
            End If






        Else
            Return False
        End If

    End Function


    ''' <summary>
    ''' 取得PUB_Rule_Maintain 目前最大Seq_No
    ''' </summary>
    ''' <param name="Rule_Maintain_Sn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPubRuleMaintainMaxSeqNo(ByVal Rule_Maintain_Sn As String) As Integer
        Try
             
            Dim TableInfoDS As DataSet
            
            Using opdConn = SQLConnFactory.getInstance.getOpdDBSqlConn

                opdConn.Open()

                Dim command As SqlCommand = opdConn.CreateCommand()
                 
                command.CommandText = "  Select ISNULL(Max(Seq_No),0) from  PUB_Rule_Maintain where Rule_Maintain_Sn=@Rule_Maintain_Sn  ; "

                command.Parameters.AddWithValue("@Rule_Maintain_Sn", Rule_Maintain_Sn)

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    TableInfoDS = New DataSet()
                    adapter.Fill(TableInfoDS)
                End Using
                 
                opdConn.Close()

            End Using

            Return CInt(TableInfoDS.Tables(0).Rows(0).Item(0))

        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' 取得PUB_Rule_Detail 目前最大Seq_No
    ''' </summary>
    ''' <param name="Rule_Code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPubRuleDetailMaxSeqNo(ByVal Rule_Code As String) As Integer
        Try

            Dim TableInfoDS As DataSet

            Using opdConn = SQLConnFactory.getInstance.getOpdDBSqlConn

                opdConn.Open()

                Dim command As SqlCommand = opdConn.CreateCommand()

                command.CommandText = "  Select ISNULL(Max(Seq_No),0) from  PUB_Rule_Detail where Rule_Code=@Rule_Code  ; "

                command.Parameters.AddWithValue("@Rule_Code", Rule_Code)

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    TableInfoDS = New DataSet()
                    adapter.Fill(TableInfoDS)
                End Using

                opdConn.Close()

            End Using

            Return CInt(TableInfoDS.Tables(0).Rows(0).Item(0))

        Catch ex As Exception
            Return 0
        End Try
    End Function


    ''' <summary>
    ''' 程式說明：刪除查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="ruleCode">檢核規則碼</param>
    ''' <returns>Boolean</returns>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function deleteRuleData(ByVal ruleCode As String) As Boolean

        Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
        Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
        Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance
        Dim ruleMaintainBO As PUBRuleMaintainBO_E1 = PUBRuleMaintainBO_E1.getInstance

        Dim result As Boolean = True

        Dim ruleRelatedNeedDeleteDT As DataTable = ruleClassBO.queryRuleClassByRuleCode(ruleCode)
        Dim ruleCodeList As New ArrayList



        Dim oneInitRuleCode As String = ""
        If DataSetUtil.IsContainsData(ruleRelatedNeedDeleteDT) Then
            ruleCodeList.Add(ruleCode)
            For Each dr As DataRow In ruleRelatedNeedDeleteDT.Rows
                Dim conditionType As String = CType(dr.Item("Condition_Type"), String).Trim
                If conditionType.Equals("1") Then
                    oneInitRuleCode = CType(dr.Item("Condition_Rule_Code"), String).Trim
                    ruleCodeList.Add(CType(dr.Item("Condition_Rule_Code"), String).Trim)
                Else '2 or 3
                    ruleCodeList.Add(CType(dr.Item("Rule_Code"), String).Trim)
                End If
            Next
        End If

        Dim seqno As Integer = -1
        Dim maintainSn As Integer = -1
        Dim itemcode As String = ""

        Dim sDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCode(oneInitRuleCode)
        If DataSetUtil.IsContainsData(sDetailDT) Then
            If (Not IsDBNull(sDetailDT.Rows(0).Item("Seq_No"))) AndAlso (Not IsDBNull(sDetailDT.Rows(0).Item("Item_Code"))) AndAlso (Not IsDBNull(sDetailDT.Rows(0).Item("Rule_Maintain_Sn"))) Then

                seqno = CType(sDetailDT.Rows(0).Item("Seq_No"), Integer)
                maintainSn = CType(sDetailDT.Rows(0).Item("Rule_Maintain_Sn"), Integer)
                itemcode = CType(sDetailDT.Rows(0).Item("Item_Code"), String).Trim

            End If
        End If





        If ruleCode IsNot Nothing AndAlso ruleCodeList.Count > 0 Then
            Dim ruleCodes(ruleCodeList.Count - 1) As String
            For i As Integer = 0 To (ruleCodeList.Count - 1)
                ruleCodes(i) = CType(ruleCodeList.Item(i), String).Trim
            Next

            Using Scope As TransactionScope = Syscom.Server.SQL.SQLConnFactory.getInstance.getRequiredTransactionScope()

                Try
                    ruleClassBO.deleteByRuleCode(ruleCode)

                    ruleBO.deleteByRuleCodes(ruleCodes)
                    ruleDetailBO.deleteByRuleCodes(ruleCodes)

                    ruleMaintainBO.delete(maintainSn, seqno, itemcode)


                Catch ex As Exception
                    result = False
                End Try

                If result Then
                    'process complete
                    Scope.Complete()
                Else
                    Scope.Dispose()
                End If

            End Using

            Return result

        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' 取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getRuleSerialNo() As String
        Dim appendChar As Char = "0"
        Dim srn As String = StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeD, "PUB_Rule_Code", 1, -1), appendChar, 7)

        Return srn
    End Function

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

        End Try

        Return srnInt
    End Function


    ''' <summary>
    ''' 查可供ruleclass選的資料
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleByCondition(ByVal itemParam As DataTable, ByVal detailParam As DataTable) As DataSet

        ', ByVal dtlParam As DataTable

        If DataSetUtil.IsContainsData(itemParam) Then

            Dim ruleDS As New DataSet

            Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance
            Dim ruleClassBO As PUBRuleClassBO_E1 = PUBRuleClassBO_E1.getInstance

            Dim ruleDT As DataTable = ruleBO.queryRuleCodeByData(itemParam)

            If DataSetUtil.IsContainsData(ruleDT) Then

                Dim filterInitRuleHash As New Hashtable
                Dim filterInitRuleList As New ArrayList

                '查啟始 rule, ruledetail
                Dim initRuleCodes(ruleDT.Rows.Count - 1) As String
                For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                    initRuleCodes(i) = CType(ruleDT.Rows(i).Item("Rule_Code"), String).Trim
                Next

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

                            Dim ruleCodeDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(ruleCodes)

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

                            Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes(filterInitRule)
                            Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(filterInitRule)

                            If DataSetUtil.IsContainsData(initRuleDT) Then
                                ruleDS.Tables.Add(initRuleDT)
                            End If
                            If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                                ruleDS.Tables.Add(initRuleDetailDT)
                            End If

                            ruleDS.Tables(0).Columns("Rule_Name").ReadOnly = False
                            'For i = 0 To ruleDS.Tables(0).Rows.Count - 1
                            '    ruleDS.Tables(0).Rows(i).Item("Rule_Name") = PUBRuleBO_E1.getInstance.getExprre(ruleDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim)

                            'Next


                            Return ruleDS

                        Else
                            Return Nothing
                        End If

                    Else
                        '不篩選
                        Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes(initRuleCodes)
                        Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(initRuleCodes)

                        If DataSetUtil.IsContainsData(initRuleDT) Then
                            ruleDS.Tables.Add(initRuleDT)
                        End If
                        If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                            ruleDS.Tables.Add(initRuleDetailDT)
                        End If

                        ruleDS.Tables(0).Columns("Rule_Name").ReadOnly = False
                        'For i = 0 To ruleDS.Tables(0).Rows.Count - 1
                        '    ruleDS.Tables(0).Rows(i).Item("Rule_Name") = PUBRuleBO_E1.getInstance.getExprre(ruleDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim)

                        'Next


                        Return ruleDS

                    End If


                Else
                    '不篩選
                    'queryRuleCodeByInitRuleCodes

                    Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes(initRuleCodes)
                    Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(initRuleCodes)

                    If DataSetUtil.IsContainsData(initRuleDT) Then
                        ruleDS.Tables.Add(initRuleDT)
                        ruleDS.Tables(0).Columns("Rule_Name").ReadOnly = False
                    End If
                    If DataSetUtil.IsContainsData(initRuleDetailDT) Then
                        ruleDS.Tables.Add(initRuleDetailDT)
                    End If


                    Dim con As IDbConnection = PubAccountBO.GetInstance.getConnection

                    'For i = 0 To ruleDS.Tables(0).Rows.Count - 1


                    '    ruleDS.Tables(0).Rows(i).Item("Rule_Name") = PUBRuleBO_E1.getInstance.getExprre(ruleDS.Tables(0).Rows(i).Item("Rule_Code").ToString.Trim)

                    'Next
                    con.Close()

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
    '接連條件
    'queryRuleCode
    ''' <summary>
    ''' 查可供ruleclass選的資料
    ''' </summary>
    ''' <param name="itemParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleGroup(ByVal itemParam As DataTable) As DataSet
        If DataSetUtil.IsContainsData(itemParam) Then

            Dim itemCode As String = CType(itemParam.Rows(0).Item("Item_Code"), String).Trim

            Dim paramDate() As String = {"Item_Code", "Valid_Date_S", "Valid_Date_E", "Value_Data"}
            Dim paramDateType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}

            Dim paramDT As DataTable = DataSetUtil.GenDataTable("param", Nothing, paramDate, paramDateType)
            Dim paramdr As DataRow = paramDT.NewRow

            paramdr.Item(paramDate(0)) = itemCode

            If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_S"))) Or (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_E"))) Then

                If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_S"))) Then
                    paramdr.Item(paramDate(1)) = itemParam.Rows(0).Item("Valid_Date_S")
                End If

                If (Not IsDBNull(itemParam.Rows(0).Item("Valid_Date_E"))) Then
                    paramdr.Item(paramDate(2)) = itemParam.Rows(0).Item("Valid_Date_E")
                End If
            End If

            paramDT.Rows.Add(paramdr)

            Dim ruleDS As New DataSet

            Dim ruleBO As PUBRuleBO_E1 = PUBRuleBO_E1.getInstance
            Dim ruleDetailBO As PUBRuleDetailBO_E1 = PUBRuleDetailBO_E1.getInstance


            Dim ruleDT As DataTable = ruleBO.queryRuleCodeByDataForContinue(paramDT)

            If DataSetUtil.IsContainsData(ruleDT) Then

                '查啟始 rule, ruledetail
                Dim ruleCodes(ruleDT.Rows.Count - 1) As String
                For i As Integer = 0 To (ruleDT.Rows.Count - 1)
                    ruleCodes(i) = CType(ruleDT.Rows(i).Item("Rule_Code"), String).Trim
                Next

                Dim initRuleDT As DataTable = ruleBO.queryRuleDataByRuleCodes(ruleCodes)
                Dim initRuleDetailDT As DataTable = ruleDetailBO.queryRuleDetailByRuleCodes(ruleCodes)

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
            '查無資料
            Return Nothing
        End If

        'Else
        'Return Nothing
        'End If

    End Function


    Private Function insertBasicData() As Boolean

        Dim conn As IDbConnection = SQLConnFactory.getInstance.getPubDBSqlConn()
        conn.Open()

        Dim ItemCode() As String = {"A00007", _
"A00008", _
"A00009", _
"A00010", _
"A00011", _
"B00001", _
"B00002", _
"B00003", _
"C00001", _
"C00002", _
"C00003", _
"C00004", _
"C00005", _
"C00006", _
"C00007", _
"C00009", _
"C00010", _
"C00011", _
"C00012", _
"D00001", _
"D00002", _
"D00003", _
"D00004", _
"D00005", _
"E00001", _
"E00002", _
"E00003", _
"E00004", _
"E00005", _
"E00006", _
"E00007", _
"E00008", _
"F00001", _
"F00002", _
"F00003", _
"F00004", _
"F00005", _
"G00001", _
"G00002", _
"H00001", _
"H00002", _
"H00003", _
"H00004", _
"H00005", _
"H00006", _
"H00007", _
"H00008", _
"H00009", _
"H00011", _
"H00012", _
"H00013", _
"H00014", _
"H00017", _
"H00022", _
"H00023", _
"H00024", _
"H00025", _
"K00001", _
"K00003", _
"K00004", _
"K00005", _
"K00006"}

        Dim unitcode() As String = {"B001", "B002", "B003", "B004", "B005", "B006", "B007", "B008", "B009", "B010"}

        Dim count As Integer = 0

        Try
            Dim currentTime = Now

            Dim sqlString As String = ""
            '"insert into PUB_Item_Value_Unit values('A00006', 'B001', 'Y', '810303', '2009/11/30', null, null) "

            For i As Integer = 0 To (ItemCode.Length - 1)

                For j As Integer = 0 To (unitcode.Length - 1)
                    sqlString = "insert into PUB_Item_Value_Unit values('" & ItemCode(i) & "', '" & unitcode(j) & "', 'Y', '810303', '2009/11/30', null, null) "
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With

                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using

                Next

            Next




        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try


        Return count

    End Function


    Private Function isValueDataNeedSplit(ByVal valueData As String) As String
        If valueData IsNot Nothing AndAlso valueData.Length > 0 Then
            If valueData.IndexOf(",") > -1 Or valueData.IndexOf("[") > -1 Or valueData.IndexOf("]") > -1 Or valueData.IndexOf("X") > -1 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 查該項目碼資料
    ''' </summary>
    ''' <param name="initValueData"></param>
    ''' <param name="dbSourceProgram"></param>
    ''' <param name="checkDefinedDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function splitValueDataToUnit(ByVal initValueData As String, ByVal dbSourceProgram As String, ByVal checkDefinedDT As DataTable, item_code As String) As DataTable
        Dim SyscodeBO As PUBSysCodeBO_E1 = PUBSysCodeBO_E1.getInstance

        Dim unitStr As New StringBuilder
        Dim rangeList As New ArrayList
        Dim likeList As New ArrayList


        Dim splitValueData() As String = initValueData.Split(",")


        If splitValueData IsNot Nothing AndAlso splitValueData.Length > 0 Then


            If checkSourceProgramCorrect(dbSourceProgram) Then

                '------------------------------------------------------------
                'TODO 應該從pub_item查出來
                '------------------------------------------------------------

                Dim dbSplit() As String = dbSourceProgram.Split(";")

                Dim queryCondition As New StringBuilder


                If DataSetUtil.IsContainsData(checkDefinedDT) AndAlso (dbSplit IsNot Nothing AndAlso dbSplit.Length > 0) Then
                    Dim selectIndex As Integer = dbSplit(0).IndexOf("select")
                    Dim fromIndex As Integer = dbSplit(0).IndexOf("from")

                    CheckColumn = dbSplit(0).Substring(selectIndex + 6, (fromIndex - (selectIndex + 6))).Trim

                    queryCondition.Append(dbSplit(0))

                    For i As Integer = 0 To (checkDefinedDT.Columns.Count - 1)

                        Dim dc As String = checkDefinedDT.Columns(i).ColumnName

                        For j As Integer = 1 To (dbSplit.Length - 1)
                            Dim seperatemark As String = "#" & dc & "#"
                            If dbSplit(j).IndexOf(seperatemark) > -1 Then
                                Dim replaceMsg As String = "'" & CType(checkDefinedDT.Rows(0).Item(dc), String).Trim & "'"
                                dbSplit(j) = dbSplit(j).Replace(seperatemark, replaceMsg)

                                queryCondition.Append(dbSplit(j))

                            End If

                        Next

                    Next

                End If

                Dim combineCondition As New StringBuilder

                For i As Integer = 0 To (splitValueData.Length - 1)
                    Dim containSpecial As Integer = 0

                    If splitValueData(i).Contains("[") AndAlso splitValueData(i).IndexOf("[") = 0 Then
                        containSpecial += 1
                    End If
                    If splitValueData(i).Contains("]") AndAlso splitValueData(i).IndexOf("]") = (splitValueData(i).Length - 1) Then
                        containSpecial += 1
                    End If
                    If splitValueData(i).Contains("-") Then
                        If containSpecial = 2 Then
                            Dim content As String = splitValueData(i).Substring(1, splitValueData(i).Length - 2)

                            Dim splitContent() As String = content.Split("-")

                            If splitContent.Length = 2 Then
                                containSpecial += 1
                            End If

                        End If
                    End If

                    If containSpecial = 3 Then
                        'rangeStr
                        Dim content As String = splitValueData(i).Substring(1, splitValueData(i).Length - 2)
                        Dim splitContent() As String = content.Split("-")
                        Dim result As String = " between '" & splitContent(0).Trim & "' and '" & splitContent(1).Trim & "'"
                        rangeList.Add(result)

                    ElseIf containSpecial = 0 Then
                        If splitValueData(i).Contains("X") Then
                            'likeStr
                            'modefied 2015/11/16
                            Dim result As String = ""
                            If item_code = "A00008" Or item_code = "A00009" Or item_code = "A00024" Or item_code = "A00025" Then
                                splitValueData(i) = splitValueData(i).Trim.Replace("X", "%")
                                result = " like '" & splitValueData(i) & "'"
                            Else
                                result = " = '" & splitValueData(i) & "'"
                            End If
                            likeList.Add(result)
                        Else
                            'unitStr
                            Dim result As String = "'" & splitValueData(i).Trim & "'"
                            unitStr.Append(result).Append(",")
                        End If
                    End If

                Next

                If unitStr.Length > 0 Then
                    unitStr.Remove(unitStr.Length - 1, 1)
                End If


                If unitStr.Length > 0 Then
                    combineCondition.Append(" ").Append(CheckColumn).Append(" in (").Append(unitStr.ToString).Append(") ")
                End If

                If likeList.Count > 0 Then
                    If combineCondition.Length > 0 Then
                        combineCondition.Append(" or ")
                    End If

                    For i As Integer = 0 To (likeList.Count - 1)
                        combineCondition.Append(" ").Append(CheckColumn).Append(likeList(i).ToString).Append(" ")

                        If i <> (likeList.Count - 1) Then
                            combineCondition.Append(" or ")
                        End If
                    Next
                End If

                If rangeList.Count > 0 Then
                    If combineCondition.Length > 0 Then
                        combineCondition.Append(" or ")
                    End If

                    For i As Integer = 0 To (rangeList.Count - 1)
                        combineCondition.Append(" ").Append(CheckColumn).Append(rangeList(i).ToString).Append(" ")

                        If i <> (rangeList.Count - 1) Then
                            combineCondition.Append(" or ")
                        End If
                    Next
                End If

                If CheckColumn.Length > 0 AndAlso queryCondition.Length > 0 AndAlso combineCondition.Length > 0 Then
                    Try
                        '2010/05/25 苦命markwu增加code
                        '主要是在抓 sql的時侯，distinct掉
                        Dim exeSql As String = queryCondition.ToString & " and " & combineCondition.ToString
                        exeSql = exeSql.Replace("select", "select distinct")
                        Dim existDS As DataSet = SyscodeBO.dynamicQuery(exeSql)

                        If DataSetUtil.IsContainsData(existDS) Then
                            Return existDS.Tables(0).Copy
                        Else
                            Return Nothing
                        End If

                    Catch ex As Exception
                        log.dbDebugMsg("RuleCheckBS queryExistIcdCodeByCondition fail")
                        Throw ex
                    End Try

                Else
                    Return Nothing
                End If

            Else
                CheckColumn = "Check_Column"
                Dim returnSplitDT As DataTable = DataSetUtil.GenDataTable("result", Nothing, New String() {CheckColumn}, New Integer() {DataSetUtil.TypeString})
                'splitValueData

                For i As Integer = 0 To (splitValueData.Length - 1)
                    Dim splitdr As DataRow = returnSplitDT.NewRow
                    splitdr.Item(CheckColumn) = splitValueData(i)
                    returnSplitDT.Rows.Add(splitdr)
                Next

                Return returnSplitDT
            End If


        Else
            Return Nothing
        End If
    End Function

    Private Function checkSourceProgramCorrect(ByVal dbSourceProgram As String) As Boolean
        'dbSourceProgram
        Dim result As Boolean = True

        If dbSourceProgram IsNot Nothing AndAlso dbSourceProgram.Length > 0 Then
            Dim findIndex As Integer = -1
            findIndex = dbSourceProgram.IndexOf("select")
            If findIndex = -1 Then
                result = False
            End If

            If result Then
                findIndex = dbSourceProgram.IndexOf("from")
                If findIndex = -1 Then
                    result = False
                End If
            End If

        Else
            result = False
        End If

        Return result

    End Function

    ''--------------------------
    ''' <summary>
    ''' 取得ExpressStr
    ''' </summary>
    ''' <param name="classCode"></param>
    ''' <param name="fieldCode"></param>
    ''' <param name="dataType"></param>
    ''' <param name="returnCheckinFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getExpressionStr(ByVal dataTypeHash As Hashtable, ByVal classCode As String, ByVal fieldCode As String, ByVal dataType As String, ByVal returnCheckinFlag As String, ByVal valueData As String) As String
        If dataTypeHash.ContainsKey(classCode) Then
            Dim express As String = CType(dataTypeHash.Item(classCode), String).Trim & "@" & fieldCode
            If dataType.Equals("1") Then '文字
                express = express & "='" & valueData & "'"
            ElseIf dataType.Equals("4") Then '外部
                If returnCheckinFlag.Equals("N") Then
                    express = express & "=True"
                Else
                    express = express & "=" & valueData & ""
                End If
            ElseIf dataType.Equals("5") Then '外部
                express = express & "='" & valueData & "'"
            Else
                express = express & "=" & valueData & ""
            End If

            Return "(" & express & ")"
        Else
            Return ""
        End If
    End Function

End Class
