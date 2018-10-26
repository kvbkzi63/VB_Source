Imports System.Text
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports System.Data.SqlClient
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports Syscom.Client.CMM

Public Class PUBRuleBP

    Dim pub As IPubServiceManager = PubServiceManager.getInstance
    Dim nfc As NfcServiceManager = NfcServiceManager.getInstance
    Dim log As Syscom.Client.CMM.LOGDelegate = Syscom.Client.CMM.LOGDelegate.getInstance
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    Public ExpressionStr As String
    Public SetValueStr As String

    Public returnValue As Boolean
    Public messageDataSet As New DataSet("messageDataSet")
    Private msg As New ArrayList

    Private InitialCode As String = Nothing

    Private ItemCode As String = Nothing
    Private ItemName As String = Nothing
    Private ValueData As String = Nothing
    Private SeqNo As String = Nothing
    Private WarningLevel As Integer = 1

    Public Sub New()
        Dim RuleInfo As New DataTable("RuleInfo")
        Dim MasterMessage As New DataTable("MasterMessage")
        Dim InitialMessage As New DataTable("InitialMessage")
        Dim TrueMessage As New DataTable("TrueMessage")
        Dim FalseMessage As New DataTable("FalseMessage")
        Dim FalseCondition As New DataTable("FalseCondition")
        Dim TrueCondition As New DataTable("TrueCondition")
        Dim ExceptionMessage As New DataTable("ExceptionMessage")

        '取得被API所搜尋到的檢核條件內容 (by Rule_Code)
        RuleInfo.Columns.Add("RuleCode")
        RuleInfo.Columns.Add("ItemCode")
        RuleInfo.Columns.Add("ItemName")
        RuleInfo.Columns.Add("ValueData")
        RuleInfo.Columns.Add("ExpressionStr")
        RuleInfo.Columns.Add("CheckResult")
        '取得被API所搜尋到的檢核條件內容及結果 (by相同 Item_Code 與 Value_Data)
        MasterMessage.Columns.Add("ItemCode")
        MasterMessage.Columns.Add("ItemName")
        MasterMessage.Columns.Add("ValueData")
        MasterMessage.Columns.Add("LimitAlertLevel")
        MasterMessage.Columns.Add("CheckResult")
        '取得起始條件失敗回傳訊息
        InitialMessage.Columns.Add("RuleCode")
        InitialMessage.Columns.Add("ItemCode")
        InitialMessage.Columns.Add("ItemName")
        InitialMessage.Columns.Add("ValueData")
        InitialMessage.Columns.Add("LimitAlertLevel")
        InitialMessage.Columns.Add("Message")
        '檢核條件成功回傳訊息
        TrueMessage.Columns.Add("RuleCode")
        TrueMessage.Columns.Add("LimitAlertLevel")
        TrueMessage.Columns.Add("Message")
        TrueMessage.Columns.Add("parentRuleCode")
        '檢核條件失敗回傳訊息
        FalseMessage.Columns.Add("ItemCode")
        FalseMessage.Columns.Add("ValueData")
        FalseMessage.Columns.Add("OrderCode")
        FalseMessage.Columns.Add("OrderName")
        FalseMessage.Columns.Add("RuleCode")
        FalseMessage.Columns.Add("LimitAlertLevel")
        FalseMessage.Columns.Add("Message")
        FalseMessage.Columns.Add("parentRuleCode")
        FalseMessage.Columns.Add("OPHRuleReason")
        '所有條件中檢核失敗的項目訊息
        FalseCondition.Columns.Add("RuleCode")
        FalseCondition.Columns.Add("SeqNo")
        FalseCondition.Columns.Add("ItemCode")
        FalseCondition.Columns.Add("ReturnCheckingFlag")
        FalseCondition.Columns.Add("ExpressionStr")
        FalseCondition.Columns.Add("RtnData")
        FalseCondition.Columns.Add("RtnDataUnit")
        FalseCondition.Columns.Add("RtnDs")
        '所有條件中檢核成功的項目訊息
        TrueCondition.Columns.Add("RuleCode")
        TrueCondition.Columns.Add("SeqNo")
        TrueCondition.Columns.Add("ItemCode")
        TrueCondition.Columns.Add("ReturnCheckingFlag")
        TrueCondition.Columns.Add("ExpressionStr")
        TrueCondition.Columns.Add("RtnData")
        TrueCondition.Columns.Add("RtnDataUnit")
        TrueCondition.Columns.Add("RtnDs")
        '例外狀況的項目訊息
        ExceptionMessage.Columns.Add("RuleCode")
        ExceptionMessage.Columns.Add("LogTime")
        ExceptionMessage.Columns.Add("Message")

        messageDataSet.Tables.Add(RuleInfo)
        messageDataSet.Tables.Add(MasterMessage)
        messageDataSet.Tables.Add(InitialMessage)
        messageDataSet.Tables.Add(TrueMessage)
        messageDataSet.Tables.Add(FalseMessage)
        messageDataSet.Tables.Add(FalseCondition)
        messageDataSet.Tables.Add(TrueCondition)
        messageDataSet.Tables.Add(ExceptionMessage)
    End Sub

    ''' <summary>
    ''' 轉換 ItemCode 為 RuleCode，並進行檢核
    ''' </summary>
    ''' <param name="Location">檢核發生的site描述: "C"->Client端 or "S"->Server端</param>
    ''' <param name="SystemType">檢核發生系統歸屬: "O"->門診 or "E"->急診 or "I"->住院</param>
    ''' <param name="TriggerItemSet">提供 API 搜尋檢核條件條件值</param>
    ''' <param name="OperationDS">檢核API 在檢核過程中需要使用的資料</param>
    ''' <param name="AutoAppendHistoryOrders">是否自動新增當次就醫歷史醫令，預設為Y</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleTransfer(ByVal Location As String, ByVal SystemType As String, ByVal TriggerItemSet As DataSet, ByVal OperationDS As DataSet, Optional ByVal AutoAppendHistoryOrders As String = "Y") As Boolean
        Try
            log.fileDebugMsg("RuleTransfer-開始進入 RuleTransfer")

            Dim totalResult As Boolean = True
            Dim Source As String = Location.ToUpper & SystemType.ToUpper

            If Not TriggerItemSet.Tables(0).Columns.Contains("ItemName") Then
                TriggerItemSet.Tables(0).Columns.Add("ItemName")
            End If

            If Not TriggerItemSet.Tables(0).Columns.Contains("IsForce") Then
                TriggerItemSet.Tables(0).Columns.Add("IsForce")
            End If

            '20120529 add by Rich, 大中要求因應急診住院當次就醫，需要自動將歷史醫令加入檢核的來源 Dataset 中。
            If OperationDS.Tables.Contains("Order_Record") Then
                If Not OperationDS.Tables("Order_Record").Columns.Contains("Order_Status") Then
                    OperationDS.Tables("Order_Record").Columns.Add("Order_Status")
                End If

                For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                    If row.Item("Order_Status").ToString.Trim = "" Then
                        row.Item("Order_Status") = "A"
                    End If
                Next
            End If

            If AutoAppendHistoryOrders = "Y" AndAlso OperationDS.Tables.Contains("Medical_Record") AndAlso OperationDS.Tables("Medical_Record").Rows.Count > 0 AndAlso OperationDS.Tables("Medical_Record").Rows(0).Item("Medical_Sn").ToString.Trim <> "" Then

                'Step.1.取得歷史醫令
                Dim dsCurrentOrderset As DataSet = GetCurrentOrderset(OperationDS.Tables("Medical_Record").Rows(0).Item("Medical_Sn").ToString.Trim, SystemType, Location)
                If dsCurrentOrderset.Tables(0).Rows.Count > 0 Then

                    'Step.2.合併現有醫令
                    If OperationDS.Tables.Contains("Order_Record") Then

                        '取得最大號
                        Dim MaxOrderSno As Integer = 1
                        For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                            If CInt(row.Item("Order_Sno")) > MaxOrderSno Then
                                MaxOrderSno = CInt(row.Item("Order_Sno"))
                            End If
                        Next

                        '若是傳進來的 Order_Sno 為空的話 , 則賦予值
                        For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                            If row.Item("Order_Sno").ToString.Trim = "" Then
                                MaxOrderSno += 1
                                If MaxOrderSno < 10 Then
                                    row.Item("Order_Sno") = MaxOrderSno.ToString.PadLeft(2, "0")
                                Else
                                    row.Item("Order_Sno") = MaxOrderSno.ToString
                                End If
                            End If
                        Next

                        For Each CurrentRow As DataRow In dsCurrentOrderset.Tables(0).Rows

                            Dim check As Boolean = False
                            For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                                If CurrentRow.Item("Order_Record_No").ToString.Trim = row.Item("Order_Record_No").ToString.Trim Then
                                    check = True
                                    Exit For
                                End If
                            Next

                            If check = True Then
                                Continue For
                            Else
                                Dim insertRow As DataRow = OperationDS.Tables("Order_Record").NewRow

                                For Each colOp As DataColumn In OperationDS.Tables("Order_Record").Columns

                                    '20120615 add by Rich, 大中要求把 OperationDs.Tables(“Order_Record”) 中新增加的 row 的資料欄位中有一個名稱為 【Order_Sno】的值(為文字格式的數字內容)，需要人工給號(依照傳入的 table 中最大 的 Order_Sno 在往後增加填入，在 Order_Record table 中的 Order_Sno 要保證都有值且不重複)
                                    If colOp.ColumnName = "Order_Sno" Then
                                        MaxOrderSno += 1
                                        If MaxOrderSno < 10 Then
                                            insertRow.Item(colOp.ColumnName) = MaxOrderSno.ToString.PadLeft(2, "0")
                                        Else
                                            insertRow.Item(colOp.ColumnName) = MaxOrderSno.ToString
                                        End If
                                        Continue For
                                    End If

                                    For Each col As DataColumn In dsCurrentOrderset.Tables(0).Columns
                                        If colOp.ColumnName = col.ColumnName Then
                                            If colOp.DataType Is GetType(System.Decimal) AndAlso CurrentRow.Item(col.ColumnName).ToString.Trim = "" Then
                                                insertRow.Item(colOp.ColumnName) = 0
                                            ElseIf col.DataType Is GetType(System.DateTime) Then
                                                If IsDBNull(CurrentRow.Item(col.ColumnName)) Then
                                                    insertRow.Item(colOp.ColumnName) = String.Empty
                                                Else
                                                    insertRow.Item(colOp.ColumnName) = CDate(CurrentRow.Item(col.ColumnName)).ToString("yyyy-MM-dd HH:mm:ss")
                                                End If
                                            Else
                                                insertRow.Item(colOp.ColumnName) = CurrentRow.Item(col.ColumnName)
                                            End If
                                            Exit For
                                        End If
                                    Next
                                Next

                                OperationDS.Tables("Order_Record").Rows.Add(insertRow)
                            End If
                        Next
                    End If
                End If
            End If

            '刪除掉 Order_Status 為 D 的資料列
            If OperationDS.Tables.Contains("Order_Record") Then
                For i As Integer = OperationDS.Tables("Order_Record").Rows.Count - 1 To 0 Step -1
                    With OperationDS.Tables("Order_Record").Rows(i)
                        If .Item("Order_Status").ToString.Trim = "D" Then
                            OperationDS.Tables("Order_Record").Rows.RemoveAt(i)
                        End If
                    End With
                Next
            End If

            TriggerItemSet.DataSetName = "TriggerItemSet"
            OperationDS.DataSetName = "OperationDS"
            log.fileDebugMsg("RuleTransfer-TriggerItemSet XML：" & vbNewLine & TriggerItemSet.GetXml)
            log.fileDebugMsg("RuleTransfer-未展延前的 OperationDS XML：" & vbNewLine & OperationDS.GetXml)

            '若沒有欄位RuleCode或該RuleCode欄位沒有值時
            If TriggerItemSet.Tables(0).Columns.Contains("RuleCode") AndAlso TriggerItemSet.Tables(0).Rows(0).Item("RuleCode").ToString.Trim <> "" Then

                '20130909 modified by Ken.
                '無論欄位 IsCodeExchanged為何，則進行轉換延展
                Dim api As New PUBRuleEngineAPI

                Try
                    If Location = "S" AndAlso OperationDS.Tables.Contains("Order_Record") AndAlso OperationDS.Tables("Order_Record").Columns.Contains("Insu_Code") Then

                        OperationDS = Me.Ext_OrderCode_To_InsuCode_X(OperationDS, Nothing)
                    Else
                        OperationDS = api.Ext_OrderCode_To_InsuCode(OperationDS, "Order_Record", "Order_Code", "Insu_Code", "Insu_Group_Code", "Order_Date", "Order_Name")
                    End If
                Catch ex As Exception
                    'Do Nothing
                End Try

                '若是欄位RuleCode有值時
                For Each RuleCodeRow As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows

                    Dim LimitLevel As Integer = 0
                    Dim totalRuleResult As Integer = 1
                    ItemCode = RuleCodeRow.Item("ItemCode").ToString.Trim
                    ItemName = RuleCodeRow.Item("ItemName").ToString.Trim
                    ValueData = RuleCodeRow.Item("ValueData").ToString.Trim

                    '全面檢查
                    'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                    '    Continue For
                    'End If

                    Dim singleRuleResult As Integer = 1

                    '20110307 modify by Rich, 當IsForce此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                    If RuleCodeRow.Item("IsForce").ToString.Trim.ToUpper = "Y" Then
                        If RuleCodeRow.Item("RuleCode").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                            Continue For
                        End If
                    End If

                    '逐一檢查
                    If Not CheckRule(RuleCodeRow.Item("RuleCode").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("RuleCode").ToString.Trim, Source, ItemCode, RuleCodeRow.Item("ItemParam").ToString.Trim, ValueData) Then
                        singleRuleResult = 0
                        totalRuleResult = 0
                        totalResult = False
                    End If

                    '=============寫入檢核訊息===============
                    Dim RuleCode As String = RuleCodeRow.Item("RuleCode").ToString.Trim
                    Dim _CheckResult As Integer = singleRuleResult
                    messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                    '========================================

                    '=============寫入檢核訊息===============
                    Dim LimitAlertLevel As Integer = LimitLevel
                    Dim CheckResult As Integer = totalRuleResult
                    messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                    '========================================
                Next

            Else
                '無論欄位 IsCodeExchanged為何，則進行轉換延展
                Dim api As New PUBRuleEngineAPI

                Try
                    If Location = "S" AndAlso OperationDS.Tables.Contains("Order_Record") AndAlso OperationDS.Tables("Order_Record").Columns.Contains("Insu_Code") Then

                        OperationDS = Me.Ext_OrderCode_To_InsuCode_X(OperationDS, Nothing)
                    Else
                        OperationDS = api.Ext_OrderCode_To_InsuCode(OperationDS, "Order_Record", "Order_Code", "Insu_Code", "Insu_Group_Code", "Order_Date", "Order_Name")
                    End If
                Catch ex As Exception
                    'Do Nothing
                End Try

                log.fileDebugMsg("RuleTransfer-已展延後的 OperationDS XML：" & vbNewLine & OperationDS.GetXml)

                log.fileDebugMsg("RuleTransfer-Step.1 開始進入轉換健保碼規則對應")

                If OperationDS.Tables.Contains("Order_Record") Then
                    '若欄位 ItemCode 為 A00004，則新增 A00006、A00022，A00006 -> Insu_Code、A00022 -> Insu_Group_Code
                    '若欄位 ItemCode 為 A00006，則新增 A00022，A00006 -> Insu_Group_Code
                    Dim tempDs As DataSet = TriggerItemSet.Copy
                    For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                        If row.Item("ItemCode").ToString.Trim = "A00004" Then
                            If row.Item("ValueData").ToString.Trim <> "" Then
                                Dim queryRows() As DataRow = OperationDS.Tables("Order_Record").Select(" Order_Code = '" & row.Item("ValueData").ToString.Trim & "' ")
                                If Not OperationDS.Tables("Order_Record").Columns.Contains("Insu_Group_Code") Then
                                    OperationDS.Tables("Order_Record").Columns.Add("Insu_Group_Code")
                                End If
                                For Each oneRow As DataRow In queryRows
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00006", DBNull.Value, oneRow.Item("Insu_Code").ToString.Trim, "N", DBNull.Value})
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, oneRow.Item("Insu_Group_Code").ToString.Trim, "N", DBNull.Value})
                                Next
                            Else
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00006", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                            End If
                        ElseIf row.Item("ItemCode").ToString.Trim = "A00006" Then
                            If row.Item("ValueData").ToString.Trim <> "" Then
                                Dim queryRows() As DataRow = OperationDS.Tables("Order_Record").Select(" Insu_Code = '" & row.Item("ValueData").ToString.Trim & "' ")
                                If Not OperationDS.Tables("Order_Record").Columns.Contains("Insu_Group_Code") Then
                                    OperationDS.Tables("Order_Record").Columns.Add("Insu_Group_Code")
                                End If
                                For Each oneRow As DataRow In queryRows
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, oneRow.Item("Insu_Group_Code").ToString.Trim, "N", DBNull.Value})
                                Next
                            Else
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                            End If
                        End If
                    Next
                    TriggerItemSet = tempDs.Copy

                    '若ItemCode對應的ValueData為空白，則將同ItemCode的其他筆數刪除
                    Dim same As New ArrayList
                    For Each row As DataRow In tempDs.Tables(0).Rows
                        If row.Item("ValueData").ToString.Trim = "" AndAlso (Not same.Contains(row.Item("ItemCode").ToString.Trim)) Then
                            same.Add(row.Item("ItemCode").ToString.Trim)
                            For i As Integer = TriggerItemSet.Tables(0).Rows.Count - 1 To 0 Step -1
                                If TriggerItemSet.Tables(0).Rows(i).Item("ItemCode").ToString.Trim = row.Item("ItemCode").ToString.Trim AndAlso TriggerItemSet.Tables(0).Rows(i).Item("ValueData").ToString.Trim <> "" Then
                                    TriggerItemSet.Tables(0).Rows.RemoveAt(i)
                                End If
                            Next
                        End If
                    Next
                End If

                log.fileDebugMsg("RuleTransfer-Step.1 結束進入轉換健保碼規則對應")

                log.fileDebugMsg("RuleTransfer-Step.2 開始進入所有檢核邏輯程式執行(包含內部外部)")

                '20110104 fix by Rich, 取得ItemName
                Dim Item_Code As String = ""
                For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                    If Item_Code <> "" Then
                        Item_Code &= ","
                    End If
                    Item_Code &= "'" & row.Item("ItemCode").ToString.Trim & "'"
                Next
                Dim dsItemName As DataSet = pub.queryItemName(Item_Code)
                If DataSetUtil.IsContainsData(dsItemName) Then
                    dsItemName.Tables(0).PrimaryKey = New DataColumn() {dsItemName.Tables(0).Columns("Item_Code")}
                    For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                        If dsItemName.Tables(0).Rows.Contains(row.Item("ItemCode").ToString.Trim) Then
                            row.Item("ItemName") = dsItemName.Tables(0).Rows.Find(row.Item("ItemCode").ToString.Trim).Item("Item_Name").ToString.Trim
                        End If
                    Next
                End If

                '20110214 add by Rich, 大中要求加入基準日判斷在最上層
                Dim Base_Date As String = ""
                If OperationDS.Tables("Medical_Record").Columns.Contains("Nhi_Ym") Then
                    If OperationDS.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim.Insert(4, "-") & "-" & "01 00:00:00"
                    ElseIf OperationDS.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim
                    ElseIf OperationDS.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim
                    Else
                        Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                Else
                    Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                End If

                For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows

                    '取得ItemParam參數值
                    Dim token() As String = row.Item("ItemParam").ToString.Trim.Split(";")
                    Dim var(token.Count - 1) As String
                    Dim val(token.Count - 1) As String

                    '參數變數型態皆為 String
                    For i As Integer = 0 To token.Count - 1
                        Dim tempToken() As String = token(i).Split("=")
                        If tempToken.Count > 1 Then
                            var(i) = tempToken(0)
                            val(i) = tempToken(1)
                        End If
                    Next

                    '判斷TriggerItemSet中該資料列的ValueData是否有值
                    If row.Item("ValueData").ToString.Trim <> "" Then
                        Dim ds As DataSet = pub.queryRuleCode(row.Item("ItemCode").ToString.Trim, row.Item("ValueData").ToString.Trim, Base_Date)

                        ItemCode = row.Item("ItemCode").ToString.Trim
                        ItemName = row.Item("ItemName").ToString.Trim
                        ValueData = row.Item("ValueData").ToString.Trim

                        Dim LimitLevel As Integer = 0
                        Dim totalRuleResult As Integer = 1

                        If ds.Tables("PUB_RuleCode").Rows.Count <> 0 Then
                            For Each RuleCodeRow As DataRow In ds.Tables("PUB_RuleCode").Rows
                                '全面檢查
                                'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                                '    Continue For
                                'End If

                                '20110307 modify by Rich, 當IsForce此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                If row.Item("IsForce").ToString.Trim.ToUpper = "Y" Then
                                    If RuleCodeRow.Item("Rule_Code").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                                        Continue For
                                    End If
                                End If

                                Dim singleRuleResult As Integer = 1
                                '逐一檢查
                                If Not CheckRule(RuleCodeRow.Item("Rule_Code").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("Rule_Code").ToString.Trim, Source, ItemCode, row.Item("ItemParam").ToString.Trim, ValueData) Then
                                    singleRuleResult = 0
                                    totalRuleResult = 0
                                    totalResult = False
                                End If

                                '=============寫入檢核訊息===============
                                Dim RuleCode As String = RuleCodeRow.Item("Rule_Code").ToString.Trim
                                Dim _CheckResult As Integer = singleRuleResult
                                messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                                '========================================
                            Next
                        Else
                            '找不到對應的RuleCode
                        End If
                        '=============寫入檢核訊息===============
                        Dim LimitAlertLevel As Integer = LimitLevel
                        Dim CheckResult As Integer = totalRuleResult
                        messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                        '========================================
                    Else
                        Dim ds As DataSet = pub.queryClassAndField(row.Item("ItemCode").ToString.Trim, val(0))

                        Dim LimitLevel As Integer = 0
                        Dim totalRuleResult As Integer = 1

                        If ds.Tables("PUB_Rule").Rows.Count <> 0 Then
                            For Each MatchRow As DataRow In ds.Tables("PUB_Rule").Rows

                                '20110519 add by Rich, 大中要求若對應的 Table 與 Column 不存在時，則 By Pass
                                If Not (OperationDS.Tables.Contains(MatchRow.Item("TableName").ToString.Trim) AndAlso OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains(MatchRow.Item("ColumnName").ToString.Trim)) Then
                                    Continue For
                                End If

                                '特殊規則
                                Select Case row.Item("ItemCode").ToString.Trim
                                    Case "A00009"

                                        '20120601 add by Rich, 加入判別 Table 是否為 Order_Record , 用來加入 Order_Status 欄位
                                        Dim colStr() As String = Nothing
                                        If MatchRow.Item("TableName").ToString.Trim = "Order_Record" Then
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim, "Order_Status"}
                                        Else
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim}
                                        End If

                                        For Each OperationDtRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).DefaultView.ToTable(True, colStr).Select("Icd_Sort_Value <= '" & row.Item("ValueData") & "'")

                                            '20120530 add by Rich, 大中要求若是遇到 Order_Record 且 Order_Status 為空的則不進行規則檢核
                                            If MatchRow.Item("TableName").ToString.Trim = "Order_Record" AndAlso OperationDtRow.Item("Order_Status").ToString.Trim = "" Then
                                                Continue For
                                            End If

                                            ItemCode = row.Item("ItemCode").ToString.Trim
                                            ItemName = row.Item("ItemName").ToString.Trim
                                            ValueData = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim

                                            Dim _ds As DataSet = pub.queryRuleCode(ItemCode, ValueData, Base_Date)

                                            For Each RuleCodeRow As DataRow In _ds.Tables("PUB_RuleCode").Rows
                                                '全面檢查
                                                'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                                                '    Continue For
                                                'End If

                                                '20110307 modify by Rich, 當Is_Force此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                                Dim chkOPH As Boolean = False
                                                If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Force") Then
                                                    For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                        If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                            If tempRow.Item("Is_Force").ToString.Trim.ToUpper = "Y" Then
                                                                chkOPH = True
                                                            End If
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                '20110905 add by Rich, 大中要求加入判斷Is_Preadmission有值並為'Y'時，，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                                If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Preadmission") Then
                                                    For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                        If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                            If tempRow.Item("Is_Preadmission").ToString.Trim.ToUpper = "Y" Then
                                                                chkOPH = True
                                                            End If
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                If chkOPH = True Then
                                                    If RuleCodeRow.Item("Rule_Code").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                                                        Continue For
                                                    End If
                                                End If

                                                Dim singleRuleResult As Integer = 1
                                                '逐一檢查
                                                If Not CheckRule(RuleCodeRow.Item("Rule_Code").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("Rule_Code").ToString.Trim, Source, ItemCode, row.Item("ItemParam").ToString.Trim, ValueData) Then
                                                    singleRuleResult = 0
                                                    totalRuleResult = 0
                                                    totalResult = False
                                                End If

                                                '=============寫入檢核訊息===============
                                                Dim RuleCode As String = RuleCodeRow.Item("Rule_Code").ToString.Trim
                                                Dim _CheckResult As Integer = singleRuleResult
                                                messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                                                '========================================
                                            Next
                                        Next
                                    Case Else

                                        '20120601 add by Rich, 加入判別 Table 是否為 Order_Record , 用來加入 Order_Status 欄位
                                        Dim colStr() As String = Nothing
                                        If MatchRow.Item("TableName").ToString.Trim = "Order_Record" Then
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim, "Order_Status"}
                                        Else
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim}
                                        End If

                                        For Each OperationDtRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).DefaultView.ToTable(True, colStr).Rows

                                            '20120530 add by Rich, 大中要求若是遇到 Order_Record 且 Order_Status 為空的則不進行規則檢核
                                            If MatchRow.Item("TableName").ToString.Trim = "Order_Record" AndAlso OperationDtRow.Item("Order_Status").ToString.Trim = "" Then
                                                Continue For
                                            End If

                                            ItemCode = row.Item("ItemCode").ToString.Trim
                                            ItemName = row.Item("ItemName").ToString.Trim
                                            ValueData = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim

                                            Dim _ds As DataSet = pub.queryRuleCode(ItemCode, ValueData, Base_Date)

                                            For Each RuleCodeRow As DataRow In _ds.Tables("PUB_RuleCode").Rows
                                                '全面檢查
                                                'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                                                '    Continue For
                                                'End If

                                                '20110307 modify by Rich, 當IsForce此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                                Dim chkOPH As Boolean = False
                                                If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Force") Then
                                                    For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                        If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                            If tempRow.Item("Is_Force").ToString.Trim.ToUpper = "Y" Then
                                                                chkOPH = True
                                                            End If
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                '20110905 add by Rich, 大中要求加入判斷Is_Preadmission有值並為'Y'時，，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                                If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Preadmission") Then
                                                    For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                        If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                            If tempRow.Item("Is_Preadmission").ToString.Trim.ToUpper = "Y" Then
                                                                chkOPH = True
                                                            End If
                                                            Exit For
                                                        End If
                                                    Next
                                                End If
                                                If chkOPH = True Then
                                                    If RuleCodeRow.Item("Rule_Code").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                                                        Continue For
                                                    End If
                                                End If

                                                Dim singleRuleResult As Integer = 1
                                                '逐一檢查
                                                If Not CheckRule(RuleCodeRow.Item("Rule_Code").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("Rule_Code").ToString.Trim, Source, ItemCode, row.Item("ItemParam").ToString.Trim, ValueData) Then
                                                    singleRuleResult = 0
                                                    totalRuleResult = 0
                                                    totalResult = False
                                                End If

                                                '=============寫入檢核訊息===============
                                                Dim RuleCode As String = RuleCodeRow.Item("Rule_Code").ToString.Trim
                                                Dim _CheckResult As Integer = singleRuleResult
                                                messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                                                '========================================
                                            Next
                                        Next
                                End Select
                            Next
                        Else
                            '找不到對應的RuleCode
                        End If
                        '=============寫入檢核訊息===============
                        Dim LimitAlertLevel As Integer = LimitLevel
                        Dim CheckResult As Integer = totalRuleResult
                        messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                        '========================================
                    End If
                Next
                log.fileDebugMsg("RuleTransfer-Step.2 結束進入所有檢核邏輯程式執行(包含內部外部)")
            End If
            'Return totalResult
            log.fileDebugMsg("RuleTransfer-結束進入 RuleTransfer")
            log.fileDebugMsg("RuleTransfer-messageDataSet XML：" & vbNewLine & messageDataSet.GetXml)
            Return True
        Catch ex As Exception
            log.fileErrorMsg("RuleTransfer-發生錯誤：" & ex.Message, ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Ext_OrderCode_To_InsuCode_X
    ''' </summary>
    ''' <param name="OperationDs">傳入之醫令</param>
    ''' <param name="Param">其它相關參數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <date>2013-08-10</date>
    Private Function Ext_OrderCode_To_InsuCode_X(ByVal OperationDs As DataSet, ByVal Param As Dictionary(Of String, Object))

        '(OperationDS, "Order_Record", "Order_Code", "Insu_Code", "Insu_Group_Code", "Order_Date", "Order_Name")
        If OperationDs.Tables.Contains("Order_Record") Then Return OperationDs

        Dim _dtOrderRecord As DataTable = OperationDs.Tables("Order_Record")

        If Not _dtOrderRecord.Columns.Contains("Insu_Group_Code") Then
            _dtOrderRecord.Columns.Add("Insu_Group_Code", GetType(String))
        End If

        Dim _pubService As IPubServiceManager = PubServiceManager.getInstance

        For Each _dr As DataRow In _dtOrderRecord.Rows
            Dim _insuCode As String = _dr("Insu_Code").ToString.Trim
            Dim _insuGroupCode As String = _dr("Insu_Group_Code").ToString.Trim

            If _insuCode.Length = 0 OrElse _insuGroupCode.Length > 0 Then Continue For

            Dim _orderEffectDate As Date = Now.Date
            If Not IsDBNull(_dr("Order_Effect_Date")) AndAlso _dr("Order_Effect_Date").ToString.Trim.Length > 0 Then
                _orderEffectDate = CDate(_dr("Order_Effect_Date")).Date
            End If

            '取得此Insu_Code 之Insu_Group_Code ----------            
            Dim var1 As New System.Text.StringBuilder
            var1.AppendFormat("SELECT RTRIM(A.Order_Code)      AS Order_Code, " & vbCrLf)
            var1.AppendFormat("       RTRIM(A.Insu_Code)       AS Insu_Code, " & vbCrLf)
            var1.AppendFormat("       RTRIM(A.Insu_Group_Code) AS Insu_Group_Code " & vbCrLf)
            var1.AppendFormat("FROM   PUB_order_Price A " & vbCrLf)
            var1.AppendFormat("WHERE  Insu_Code = '{0}' " & vbCrLf, _insuCode.Replace("'", "''"))
            var1.AppendFormat("       AND '{0}' BETWEEN A.Effect_Date AND A.End_Date " & vbCrLf, _orderEffectDate.ToString("yyyy/MM/dd"))
            var1.AppendFormat("       AND ISNULL(A.Insu_Group_Code, '') != '' ")

            Dim resultDS As DataSet = _pubService.RuleDynamicQuery(var1.ToString)
            Dim _dtResult As DataTable = resultDS.Tables(0)

            If _dtResult.Rows.Count > 0 Then
                Dim _drResult As DataRow = _dtResult.Rows(0)

                _dr("Insu_Group_Code") = _drResult("Insu_Group_Code").ToString
            End If
            'END 取得此Insu_Code 之Insu_Group_Code ------

            If IsDBNull(_dr("Order_End_Date")) OrElse _dr("Order_End_Date").ToString.Trim.Length = 0 Then
                _dr("Order_End_Date") = _dr("Order_Effect_Date")
            End If

            If IsDBNull(_dr("Tqty")) OrElse _dr("Tqty").ToString.Trim.Length = 0 Then
                _dr("Tqty") = 1
            End If
        Next


        Return OperationDs
    End Function

    ''' <summary>
    ''' 執行檢核流程
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <param name="CheckDataSet">檢核資料內容</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckRule(ByVal RuleCode As String, ByVal CheckDataSet As DataSet, ByRef LimitLevel As Integer, ByVal ParentRuleCode As String, ByVal Source As String, ByVal TriggerItemCode As String, ByVal TriggerItemPara As String, ByVal TriggerValueData As String) As Boolean
        Try
            '步驟一︰依照 RuleCode 取得 DB 資料，取得起始條件、成功失敗條件的 RuleCode
            Dim tempBoolean As Boolean = Nothing
            Dim Medical_Identity_Id As String = CheckDataSet.Tables("Medical_Record").Rows(0).Item("Main_Identity_Id").ToString.Trim
            Dim Base_Date As String = ""
            If CheckDataSet.Tables("Medical_Record").Columns.Contains("Nhi_Ym") Then
                If CheckDataSet.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim <> "" Then
                    Base_Date = CheckDataSet.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim.Insert(4, "-") & "-" & "01 00:00:00"
                ElseIf CheckDataSet.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim <> "" Then
                    Base_Date = CheckDataSet.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim
                ElseIf CheckDataSet.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim <> "" Then
                    Base_Date = CheckDataSet.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim
                Else
                    Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                End If
            Else
                Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
            End If

            log.fileDebugMsg("CheckRule-Step.1 開始撈取資料庫所需資料")
            Dim dsCheckRule As DataSet = pub.getCheckRuleDS(RuleCode, TriggerValueData, Source, Medical_Identity_Id, Base_Date)
            log.fileDebugMsg("CheckRule-Step.1 開始撈取資料庫所需資料")

            Dim PUBRuleClass As DataTable = dsCheckRule.Tables(0).Copy
            Dim PUBRule As DataTable = dsCheckRule.Tables(1).Copy

            If Not DataSetUtil.IsContainsData(PUBRule) Then
                Throw New Exception("PUR_Rule 找不到對應的資料")
            End If

            If DataSetUtil.IsContainsData(PUBRuleClass) Then
                PUBRuleClass.PrimaryKey = New DataColumn() {PUBRuleClass.Columns("Rule_Code"), PUBRuleClass.Columns("Condition_Type")}

                '判斷該條件是否有起始條件
                If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "1"}) Then
                    Dim IniRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "1"}).Item("Condition_Rule_Code").ToString
                    InitialCode = IniRuleCode
                    If CheckRule(IniRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData) Then
                        If CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData) Then
                            If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "2"}) Then
                                Dim successRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "2"}).Item("Condition_Rule_Code").ToString
                                Return CheckRule(successRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData)
                            Else
                                tempBoolean = True
                                '=============寫入檢核訊息===============
                                If tempBoolean Then
                                    If RuleCode = ParentRuleCode Then
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ""})
                                    Else
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ParentRuleCode})
                                    End If
                                Else
                                    If RuleCode = ParentRuleCode Then
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                        Dim Order_Name As String = ""
                                        Dim Order_Code As String = ""
                                        If TriggerItemCode = "A00004" Then
                                            Order_Code = TriggerValueData
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next
                                        ElseIf TriggerItemCode = "A00006" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        ElseIf TriggerItemCode = "A00031" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        End If
                                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim()
                                        Dim Phrase_Name As String = ""
                                        If OPH_Rule_Reason <> "" Then
                                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                            If DataSetUtil.IsContainsData(ophDS) Then
                                                For Each row As DataRow In ophDS.Tables(0).Rows
                                                    If Phrase_Name <> "" Then
                                                        Phrase_Name &= "|"
                                                    End If
                                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                                Next
                                            End If
                                        End If
                                        If CInt(Limit_Level) <= WarningLevel Then
                                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                            pvtReceiveMgr.RaiseNFCForceRefresh()
                                        Else
                                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                                        End If
                                    Else
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                        Dim Order_Code As String = ""
                                        Dim Order_Name As String = ""
                                        If TriggerItemCode = "A00004" Then
                                            Order_Code = TriggerValueData
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next
                                        ElseIf TriggerItemCode = "A00006" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        ElseIf TriggerItemCode = "A00031" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        End If
                                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                        Dim Phrase_Name As String = ""
                                        If OPH_Rule_Reason <> "" Then
                                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                            If DataSetUtil.IsContainsData(ophDS) Then
                                                For Each row As DataRow In ophDS.Tables(0).Rows
                                                    If Phrase_Name <> "" Then
                                                        Phrase_Name &= "|"
                                                    End If
                                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                                Next
                                            End If
                                        End If
                                        If CInt(Limit_Level) <= WarningLevel Then
                                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                            pvtReceiveMgr.RaiseNFCForceRefresh()
                                        Else
                                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                        End If
                                    End If
                                End If
                                '========================================
                                Return tempBoolean
                            End If
                        Else
                            If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "3"}) Then
                                Dim failRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "3"}).Item("Condition_Rule_Code").ToString
                                Return CheckRule(failRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData)
                            Else
                                tempBoolean = False
                                '=============寫入檢核訊息===============
                                If tempBoolean Then
                                    If RuleCode = ParentRuleCode Then
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ""})
                                    Else
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ParentRuleCode})
                                    End If
                                Else
                                    If RuleCode = ParentRuleCode Then
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                        Dim Order_Code As String = ""
                                        Dim Order_Name As String = ""
                                        If TriggerItemCode = "A00004" Then
                                            Order_Code = TriggerValueData
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next
                                        ElseIf TriggerItemCode = "A00006" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        ElseIf TriggerItemCode = "A00031" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        End If
                                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                        Dim Phrase_Name As String = ""
                                        If OPH_Rule_Reason <> "" Then
                                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                            If DataSetUtil.IsContainsData(ophDS) Then
                                                For Each row As DataRow In ophDS.Tables(0).Rows
                                                    If Phrase_Name <> "" Then
                                                        Phrase_Name &= "|"
                                                    End If
                                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                                Next
                                            End If
                                        End If
                                        If CInt(Limit_Level) <= WarningLevel Then
                                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                            pvtReceiveMgr.RaiseNFCForceRefresh()
                                        Else
                                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                                        End If
                                    Else
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                        Dim Order_Code As String = ""
                                        Dim Order_Name As String = ""
                                        If TriggerItemCode = "A00004" Then
                                            Order_Code = TriggerValueData
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next
                                        ElseIf TriggerItemCode = "A00006" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        ElseIf TriggerItemCode = "A00031" Then
                                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                                    Exit For
                                                End If
                                            Next

                                        End If
                                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                        Dim Phrase_Name As String = ""
                                        If OPH_Rule_Reason <> "" Then
                                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                            If DataSetUtil.IsContainsData(ophDS) Then
                                                For Each row As DataRow In ophDS.Tables(0).Rows
                                                    If Phrase_Name <> "" Then
                                                        Phrase_Name &= "|"
                                                    End If
                                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                                Next
                                            End If
                                        End If
                                        If CInt(Limit_Level) <= WarningLevel Then
                                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                            pvtReceiveMgr.RaiseNFCForceRefresh()
                                        Else
                                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                        End If
                                    End If
                                End If
                                '========================================
                                Return tempBoolean
                            End If
                        End If
                    Else
                        '起始條件失敗
                        '=============寫入檢核訊息===============
                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                        messageDataSet.Tables("InitialMessage").Rows.Add(New Object() {IniRuleCode, ItemCode, ItemName, ValueData, Limit_Level, "0"})
                        '========================================
                    End If
                Else
                    '該條件無起始條件！
                    If CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData) Then
                        If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "2"}) Then
                            Dim successRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "2"}).Item("Condition_Rule_Code").ToString
                            Return CheckRule(successRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData)
                        Else
                            tempBoolean = True
                            '=============寫入檢核訊息===============
                            If tempBoolean Then
                                If RuleCode = ParentRuleCode Then
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                    messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ""})
                                Else
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                    messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ParentRuleCode})
                                End If
                            Else
                                If RuleCode = ParentRuleCode Then
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                    Dim Order_Code As String = ""
                                    Dim Order_Name As String = ""
                                    If TriggerItemCode = "A00004" Then
                                        Order_Code = TriggerValueData
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TriggerItemCode = "A00006" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    ElseIf TriggerItemCode = "A00031" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    End If
                                    Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                    Dim Phrase_Name As String = ""
                                    If OPH_Rule_Reason <> "" Then
                                        Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                        If DataSetUtil.IsContainsData(ophDS) Then
                                            For Each row As DataRow In ophDS.Tables(0).Rows
                                                If Phrase_Name <> "" Then
                                                    Phrase_Name &= "|"
                                                End If
                                                Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                            Next
                                        End If
                                    End If
                                    If CInt(Limit_Level) <= WarningLevel Then
                                        nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                        pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                                    End If
                                Else
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                    Dim Order_Code As String = ""
                                    Dim Order_Name As String = ""
                                    If TriggerItemCode = "A00004" Then
                                        Order_Code = TriggerValueData
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TriggerItemCode = "A00006" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    ElseIf TriggerItemCode = "A00031" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    End If
                                    Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                    Dim Phrase_Name As String = ""
                                    If OPH_Rule_Reason <> "" Then
                                        Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                        If DataSetUtil.IsContainsData(ophDS) Then
                                            For Each row As DataRow In ophDS.Tables(0).Rows
                                                If Phrase_Name <> "" Then
                                                    Phrase_Name &= "|"
                                                End If
                                                Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                            Next
                                        End If
                                    End If
                                    If CInt(Limit_Level) <= WarningLevel Then
                                        nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                        pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                    End If
                                End If
                            End If
                            '========================================
                            Return tempBoolean
                        End If
                    Else
                        If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "3"}) Then
                            Dim failRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "3"}).Item("Condition_Rule_Code").ToString
                            Return CheckRule(failRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData)
                        Else
                            tempBoolean = False
                            '=============寫入檢核訊息===============
                            If tempBoolean Then
                                If RuleCode = ParentRuleCode Then
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                    messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ""})
                                Else
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                                    messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ParentRuleCode})
                                End If
                            Else
                                If RuleCode = ParentRuleCode Then
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                    Dim Order_Code As String = ""
                                    Dim Order_Name As String = ""
                                    If TriggerItemCode = "A00004" Then
                                        Order_Code = TriggerValueData
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TriggerItemCode = "A00006" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    ElseIf TriggerItemCode = "A00031" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    End If
                                    Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                    Dim Phrase_Name As String = ""
                                    If OPH_Rule_Reason <> "" Then
                                        Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                        If DataSetUtil.IsContainsData(ophDS) Then
                                            For Each row As DataRow In ophDS.Tables(0).Rows
                                                If Phrase_Name <> "" Then
                                                    Phrase_Name &= "|"
                                                End If
                                                Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                            Next
                                        End If
                                    End If
                                    If CInt(Limit_Level) <= WarningLevel Then
                                        nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                        pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                                    End If
                                Else
                                    If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                        LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                    End If

                                    Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                                    Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                                    Dim Order_Code As String = ""
                                    Dim Order_Name As String = ""
                                    If TriggerItemCode = "A00004" Then
                                        Order_Code = TriggerValueData
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TriggerItemCode = "A00006" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    ElseIf TriggerItemCode = "A00031" Then
                                        For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                            If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                                Order_Code = row.Item("Order_Code").ToString.Trim
                                                Order_Name = row.Item("Order_Name").ToString.Trim
                                                Exit For
                                            End If
                                        Next

                                    End If
                                    Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                                    Dim Phrase_Name As String = ""
                                    If OPH_Rule_Reason <> "" Then
                                        Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                                        If DataSetUtil.IsContainsData(ophDS) Then
                                            For Each row As DataRow In ophDS.Tables(0).Rows
                                                If Phrase_Name <> "" Then
                                                    Phrase_Name &= "|"
                                                End If
                                                Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                            Next
                                        End If
                                    End If
                                    If CInt(Limit_Level) <= WarningLevel Then
                                        nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                                        pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                    End If
                                End If
                            End If
                            '========================================
                            Return tempBoolean
                        End If
                    End If
                End If
            Else
                'MsgBox(RuleCode & "︰無關連條件！")
                tempBoolean = CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData)
                '=============寫入檢核訊息===============
                If tempBoolean Then
                    If RuleCode = ParentRuleCode Then
                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                        End If

                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ""})
                    ElseIf RuleCode = InitialCode Then
                        '成功不寫入TrueMessage訊息
                    Else
                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                        End If

                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                        Dim True_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("True_Message").ToString()
                        messageDataSet.Tables("TrueMessage").Rows.Add(New Object() {RuleCode, Limit_Level, True_Message, ParentRuleCode})
                    End If
                Else
                    If RuleCode = ParentRuleCode Then
                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                        End If

                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                        Dim Order_Code As String = ""
                        Dim Order_Name As String = ""
                        If TriggerItemCode = "A00004" Then
                            Order_Code = TriggerValueData
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next
                        ElseIf TriggerItemCode = "A00006" Then
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next

                        ElseIf TriggerItemCode = "A00031" Then
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next

                        End If
                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                        Dim Phrase_Name As String = ""
                        If OPH_Rule_Reason <> "" Then
                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                            If DataSetUtil.IsContainsData(ophDS) Then
                                For Each row As DataRow In ophDS.Tables(0).Rows
                                    If Phrase_Name <> "" Then
                                        Phrase_Name &= "|"
                                    End If
                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                Next
                            End If
                        End If
                        If CInt(Limit_Level) <= WarningLevel Then
                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                            pvtReceiveMgr.RaiseNFCForceRefresh()
                        Else
                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                        End If
                    ElseIf RuleCode = InitialCode Then
                        '失敗不寫入FalseMessage訊息
                    Else
                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                        End If

                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()
                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()
                        Dim Order_Code As String = ""
                        Dim Order_Name As String = ""
                        If TriggerItemCode = "A00004" Then
                            Order_Code = TriggerValueData
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Order_Code").ToString.Trim Then
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next
                        ElseIf TriggerItemCode = "A00006" Then
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Insu_Code").ToString.Trim Then
                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next

                        ElseIf TriggerItemCode = "A00031" Then
                            For Each row As DataRow In CheckDataSet.Tables("Order_Record").Rows
                                If TriggerValueData = row.Item("Pharmacy_12_Code").ToString.Trim Then
                                    Order_Code = row.Item("Order_Code").ToString.Trim
                                    Order_Name = row.Item("Order_Name").ToString.Trim
                                    Exit For
                                End If
                            Next

                        End If
                        Dim OPH_Rule_Reason As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("OPH_Rule_Reason").ToString.Trim
                        Dim Phrase_Name As String = ""
                        If OPH_Rule_Reason <> "" Then
                            Dim ophDS As DataSet = pub.queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
                            If DataSetUtil.IsContainsData(ophDS) Then
                                For Each row As DataRow In ophDS.Tables(0).Rows
                                    If Phrase_Name <> "" Then
                                        Phrase_Name &= "|"
                                    End If
                                    Phrase_Name &= row.Item("Phrase_Name").ToString.Trim
                                Next
                            End If
                        End If
                        If CInt(Limit_Level) <= WarningLevel Then
                            nfc.NotifyUI(New String() {AppContext.userProfile.userId}, "檢核錯誤", False_Message)
                            pvtReceiveMgr.RaiseNFCForceRefresh()
                        Else
                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                        End If
                    End If
                End If
                '========================================
                Return tempBoolean
            End If
        Catch ex As Exception
            Dim currentTime As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
            '=============寫入檢核訊息===============
            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, currentTime, ex.Message})
            '========================================
            log.fileErrorMsg(currentTime & " CheckRule(" & RuleCode & ")：" & ex.Message, ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 執行檢核
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <param name="CheckDataSet">檢核資料內容</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CallForm(ByVal RuleCode As String, ByVal CheckDataSet As DataSet, ByVal Source As String, ByVal TriggerItemCode As String, ByVal TriggerItemPara As String, ByVal TriggerValueData As String) As Boolean
        Try
            '步驟一︰依照 RuleCode 取得 DB 資料，並取得該邏輯判斷式字串 ExpressionStr

            '處理過程成功與否
            Dim ProcessFlag As Boolean = True

            log.fileDebugMsg("CallForm-Step.1 開始撈取資料庫所需資料")
            Dim dsCallForm As DataSet = pub.getCallFormDS(RuleCode)
            log.fileDebugMsg("CallForm-Step.1 結束撈取資料庫所需資料")

            Dim PUBRule As DataTable = dsCallForm.Tables(0).Copy
            Dim PUBRuleDetail As DataTable = dsCallForm.Tables(1).Copy
            Dim PUBRuleEng As DataTable = dsCallForm.Tables(2).Copy

            If Not DataSetUtil.IsContainsData(PUBRule) Then
                '中文判斷式撈不到資料
                'Throw New Exception("PUBRule 為空的")
            End If
            If Not DataSetUtil.IsContainsData(PUBRuleDetail) Then
                Throw New Exception("PUBRuleDetail 為空的")
            End If
            If Not DataSetUtil.IsContainsData(PUBRuleEng) Then
                Throw New Exception("PUBRuleEng為空的")
            End If

            Dim assem As [Assembly] = [Assembly].GetExecutingAssembly()
            Dim strString As System.Text.StringBuilder = New System.Text.StringBuilder  '用來存放設值字串
            Dim expString As System.Text.StringBuilder = New System.Text.StringBuilder  '用來存放判斷字串

            expString.Append(PUBRuleEng.Rows(0).Item("Expression_Str").ToString)

            If DataSetUtil.IsContainsData(CheckDataSet) Then
                Dim ruleEngineForm As System.Type = Nothing
                Dim ruleEngine As Object = Nothing
                Dim classFlag As New ArrayList  '識別是否已經存在
                Dim rtnDataUnit As New Hashtable
                Dim rtnDs As New Hashtable

                '步驟一︰根據 PUBRuleDetail 的 Class_Name 來 New Class，並找相對應的 Method 值來組合設值字串
                For Each row As DataRow In PUBRuleDetail.Rows
                    Select Case row.Item("Data_Type").ToString.Trim
                        Case "1", "2", "3"
                            log.fileDebugMsg("CallForm-Step.2-1 開始進行內部資料項目檢核")
                            If CheckDataSet.Tables.Contains(row.Item("Class_Name").ToString.Trim) Then
                                If CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Columns.Contains(row.Item("Field_Code").ToString.Trim) Then
                                    If strString.ToString.Trim <> "" Then
                                        strString.Append(";")
                                    End If
                                    strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                    If CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Columns(row.Item("Field_Code").ToString.Trim).DataType Is GetType(String) Then
                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        strString.Append("='" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim & "'")
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        strString.Append("='" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim & "'")
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_Code").ToString.Trim Then
                                                        strString.Append("='" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim & "'")
                                                        Exit For
                                                    End If
                                                End If
                                            Next

                                            If Not strString.ToString.Contains("=") Then
                                                strString.Append("='" & TriggerValueData & "'")
                                            End If
                                        Else
                                            strString.Append("='" & CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows(0).Item(row.Item("Field_Code").ToString.Trim).ToString.Trim & "'")
                                        End If
                                    Else
                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        strString.Append("=" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim)
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        strString.Append("=" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim)
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_code").ToString.Trim Then
                                                        strString.Append("=" & oneRow.Item(row.Item("Field_Code").ToString.Trim).ToString.Trim)
                                                        Exit For
                                                    End If
                                                End If
                                            Next

                                            If Not strString.ToString.Contains("=") Then
                                                strString.Append("=" & TriggerValueData)
                                            End If
                                        Else
                                            strString.Append("=" & CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows(0).Item(row.Item("Field_Code").ToString.Trim).ToString.Trim)
                                        End If
                                    End If

                                    '同一Table是否有多列？
                                Else
                                    Throw New Exception("OperationDS 中的 " & row.Item("Class_Name").ToString.Trim & " 抓取不到需要的 Column：" & row.Item("Field_Code").ToString.Trim)
                                End If
                            Else
                                Throw New Exception("OperationDS 中抓取不到需要的 Table：" & row.Item("Class_Name").ToString.Trim)
                            End If
                            log.fileDebugMsg("CallForm-Step.2-1 結束進行內部資料項目檢核")
                        Case "4"
                            log.fileDebugMsg("CallForm-Step.2-2 開始進行外部資料項目檢核")
                            If row.Item("Method_Code").ToString.Trim <> "" Then

                                '取得ItemParam參數值
                                Dim token() As String = row.Item("Item_Param").ToString.Trim.Split(";")
                                Dim var(token.Count - 1) As String
                                Dim val(token.Count - 1) As String
                                '參數變數型態皆為 String
                                For i As Integer = 0 To token.Count - 1
                                    Dim tempToken() As String = token(i).Split("=")
                                    If tempToken.Count > 1 Then
                                        var(i) = tempToken(0)
                                        val(i) = tempToken(1)
                                    End If
                                Next

                                If Not classFlag.Contains(row.Item("Program_Code").ToString.Trim) Then
                                    classFlag.Add(row.Item("Program_Code").ToString.Trim)

                                    '宣告並建立Class
                                    ruleEngineForm = assem.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim)
                                    ruleEngine = Activator.CreateInstance(ruleEngineForm)

                                    '加入CheckDataSet中的DataTable名稱為Pub_Rule
                                    If CheckDataSet.Tables.Contains("Pub_Rule") Then
                                        CheckDataSet.Tables("Pub_Rule").Rows.Clear()
                                        CheckDataSet.Tables("Pub_Rule").Rows.Add()
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("OperatorCode") = row.Item("Operator_Code").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueData") = row.Item("Value_Data").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueUnit") = row.Item("Value_Unit").ToString.Trim
                                        If var(0) IsNot Nothing Then
                                            For i As Integer = 0 To var.Count - 1
                                                Select Case var(i).ToString.Trim.ToUpper
                                                    Case "X"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueX") = val(i)
                                                    Case "Y"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueY") = val(i)
                                                    Case "Z"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueZ") = val(i)
                                                    Case Else
                                                        Throw New Exception("參數不在範圍內")
                                                End Select
                                            Next
                                        End If
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountO") = row.Item("Is_Count_O").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountE") = row.Item("Is_Count_E").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountI") = row.Item("Is_Count_I").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("CheckIdentity") = row.Item("Check_Identity").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("Location") = Source
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerItemCode") = TriggerItemCode
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerItemPara") = TriggerItemPara
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerValueData") = TriggerValueData

                                        '20130506 add by Rich, 大中要求加入TriggerSno的資料
                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        Else
                                            CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = ""
                                        End If
                                    Else
                                        Dim dt As New DataTable("Pub_Rule")
                                        dt.Columns.Add("OperatorCode")
                                        dt.Columns.Add("ValueData")
                                        dt.Columns.Add("ValueUnit")
                                        dt.Columns.Add("ValueX")
                                        dt.Columns.Add("ValueY")
                                        dt.Columns.Add("ValueZ")
                                        dt.Columns.Add("IsCountO")
                                        dt.Columns.Add("IsCountE")
                                        dt.Columns.Add("IsCountI")
                                        dt.Columns.Add("CheckIdentity")
                                        dt.Columns.Add("Location")
                                        dt.Columns.Add("TriggerItemCode")
                                        dt.Columns.Add("TriggerItemPara")
                                        dt.Columns.Add("TriggerValueData")
                                        dt.Columns.Add("TriggerSno")
                                        dt.Rows.Add()
                                        dt.Rows(0).Item("OperatorCode") = row.Item("Operator_Code").ToString.Trim
                                        dt.Rows(0).Item("ValueData") = row.Item("Value_Data").ToString.Trim
                                        dt.Rows(0).Item("ValueUnit") = row.Item("Value_Unit").ToString.Trim
                                        If var(0) IsNot Nothing Then
                                            For i As Integer = 0 To var.Count - 1
                                                Select Case var(i).ToString.Trim.ToUpper
                                                    Case "X"
                                                        dt.Rows(0).Item("ValueX") = val(i)
                                                    Case "Y"
                                                        dt.Rows(0).Item("ValueY") = val(i)
                                                    Case "Z"
                                                        dt.Rows(0).Item("ValueZ") = val(i)
                                                    Case Else
                                                        Throw New Exception("參數不在範圍內")
                                                End Select
                                            Next
                                        End If
                                        dt.Rows(0).Item("IsCountO") = row.Item("Is_Count_O").ToString.Trim
                                        dt.Rows(0).Item("IsCountE") = row.Item("Is_Count_E").ToString.Trim
                                        dt.Rows(0).Item("IsCountI") = row.Item("Is_Count_I").ToString.Trim
                                        dt.Rows(0).Item("CheckIdentity") = row.Item("Check_Identity").ToString.Trim
                                        dt.Rows(0).Item("Location") = Source
                                        dt.Rows(0).Item("TriggerItemCode") = TriggerItemCode
                                        dt.Rows(0).Item("TriggerItemPara") = TriggerItemPara
                                        dt.Rows(0).Item("TriggerValueData") = TriggerValueData

                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        Else
                                            dt.Rows(0).Item("TriggerSno") = ""
                                        End If

                                        CheckDataSet.Tables.Add(dt)
                                    End If

                                    '設定值
                                    ruleEngine.PUBREAPIData = CheckDataSet

                                    '呼叫外部 Class 中的 Method
                                    log.fileDebugMsg("CallForm-Step.2-2-1 開始進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                    If Boolean.Parse(CallByName(ruleEngine, row.Item("Method_Code").ToString.Trim, CallType.Get)) Then
                                        log.fileDebugMsg("CallForm-Step.2-2-1 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                        If strString.ToString.Trim <> "" Then
                                            strString.Append(";")
                                        End If
                                        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                        strString.Append("=" & ruleEngine.rtnData.ToString)
                                        If ruleEngine.rtnDataUnit IsNot Nothing Then
                                            If rtnDataUnit.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDataUnit.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDataUnit.ToString)
                                            Else
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDataUnit.ToString)
                                            End If
                                        Else
                                            If rtnDataUnit.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDataUnit.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            Else
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            End If
                                        End If
                                        If ruleEngine.rtnDs IsNot Nothing Then
                                            If rtnDs.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDs.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDs.GetXml)
                                            Else
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDs.GetXml)
                                            End If
                                        Else
                                            If rtnDs.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDs.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            Else
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            End If
                                        End If
                                    Else
                                        log.fileDebugMsg("CallForm-Step.2-2-1 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                        '執行檢核失敗
                                        ProcessFlag = False
                                    End If
                                Else
                                    '加入CheckDataSet中的DataTable名稱為Pub_Rule
                                    If CheckDataSet.Tables.Contains("Pub_Rule") Then
                                        CheckDataSet.Tables("Pub_Rule").Rows.Clear()
                                        CheckDataSet.Tables("Pub_Rule").Rows.Add()
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("OperatorCode") = row.Item("Operator_Code").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueData") = row.Item("Value_Data").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueUnit") = row.Item("Value_Unit").ToString.Trim
                                        If var(0) IsNot Nothing Then
                                            For i As Integer = 0 To var.Count - 1
                                                Select Case var(i).ToString.Trim.ToUpper
                                                    Case "X"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueX") = val(i)
                                                    Case "Y"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueY") = val(i)
                                                    Case "Z"
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("ValueZ") = val(i)
                                                    Case Else
                                                        Throw New Exception("參數不在範圍內")
                                                End Select
                                            Next
                                        End If
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountO") = row.Item("Is_Count_O").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountE") = row.Item("Is_Count_E").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("IsCountI") = row.Item("Is_Count_I").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("CheckIdentity") = row.Item("Check_Identity").ToString.Trim
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("Location") = Source
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerItemCode") = TriggerItemCode
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerItemPara") = TriggerItemPara
                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerValueData") = TriggerValueData

                                        '20130506 add by Rich, 大中要求加入TriggerSno的資料
                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_code").ToString.Trim Then
                                                        CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        Else
                                            CheckDataSet.Tables("Pub_Rule").Rows(0).Item("TriggerSno") = ""
                                        End If
                                    Else
                                        Dim dt As New DataTable("Pub_Rule")
                                        dt.Columns.Add("OperatorCode")
                                        dt.Columns.Add("ValueData")
                                        dt.Columns.Add("ValueUnit")
                                        dt.Columns.Add("ValueX")
                                        dt.Columns.Add("ValueY")
                                        dt.Columns.Add("ValueZ")
                                        dt.Columns.Add("IsCountO")
                                        dt.Columns.Add("IsCountE")
                                        dt.Columns.Add("IsCountI")
                                        dt.Columns.Add("CheckIdentity")
                                        dt.Columns.Add("Location")
                                        dt.Columns.Add("TriggerItemCode")
                                        dt.Columns.Add("TriggerItemPara")
                                        dt.Columns.Add("TriggerValueData")
                                        dt.Columns.Add("TriggerSno")
                                        dt.Rows.Add()
                                        dt.Rows(0).Item("OperatorCode") = row.Item("Operator_Code").ToString.Trim
                                        dt.Rows(0).Item("ValueData") = row.Item("Value_Data").ToString.Trim
                                        dt.Rows(0).Item("ValueUnit") = row.Item("Value_Unit").ToString.Trim
                                        If var(0) IsNot Nothing Then
                                            For i As Integer = 0 To var.Count - 1
                                                Select Case var(i).ToString.Trim.ToUpper
                                                    Case "X"
                                                        dt.Rows(0).Item("ValueX") = val(i)
                                                    Case "Y"
                                                        dt.Rows(0).Item("ValueY") = val(i)
                                                    Case "Z"
                                                        dt.Rows(0).Item("ValueZ") = val(i)
                                                    Case Else
                                                        Throw New Exception("參數不在範圍內")
                                                End Select
                                            Next
                                        End If
                                        dt.Rows(0).Item("IsCountO") = row.Item("Is_Count_O").ToString.Trim
                                        dt.Rows(0).Item("IsCountE") = row.Item("Is_Count_E").ToString.Trim
                                        dt.Rows(0).Item("IsCountI") = row.Item("Is_Count_I").ToString.Trim
                                        dt.Rows(0).Item("CheckIdentity") = row.Item("Check_Identity").ToString.Trim
                                        dt.Rows(0).Item("Location") = Source
                                        dt.Rows(0).Item("TriggerItemCode") = TriggerItemCode
                                        dt.Rows(0).Item("TriggerItemPara") = TriggerItemPara
                                        dt.Rows(0).Item("TriggerValueData") = TriggerValueData

                                        If row.Item("Class_Name").ToString.Trim = "Order_Record" Then
                                            For Each oneRow As DataRow In CheckDataSet.Tables(row.Item("Class_Name").ToString.Trim).Rows
                                                If TriggerItemCode = "A00004" Then
                                                    If TriggerValueData = oneRow.Item("Order_Code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00006" Then
                                                    If TriggerValueData = oneRow.Item("Insu_Code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                ElseIf TriggerItemCode = "A00031" Then
                                                    If TriggerValueData = oneRow.Item("Pharmacy_12_code").ToString.Trim Then
                                                        dt.Rows(0).Item("TriggerSno") = oneRow.Item("Order_Sno").ToString.Trim
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        Else
                                            dt.Rows(0).Item("TriggerSno") = ""
                                        End If

                                        CheckDataSet.Tables.Add(dt)
                                    End If

                                    '設定值
                                    ruleEngine.PUBREAPIData = CheckDataSet

                                    '呼叫外部 Class 中的 Method
                                    log.fileDebugMsg("CallForm-Step.2-2-2 開始進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                    If Boolean.Parse(CallByName(ruleEngine, row.Item("Method_Code").ToString.Trim, CallType.Get)) Then
                                        log.fileDebugMsg("CallForm-Step.2-2-2 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                        If strString.ToString.Trim <> "" Then
                                            strString.Append(";")
                                        End If
                                        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                        strString.Append("=" & ruleEngine.rtnData.ToString)
                                        If ruleEngine.rtnDataUnit IsNot Nothing Then
                                            If rtnDataUnit.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDataUnit.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDataUnit.ToString)
                                            Else
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDataUnit.ToString)
                                            End If
                                        Else
                                            If rtnDataUnit.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDataUnit.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            Else
                                                rtnDataUnit.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            End If
                                        End If
                                        If ruleEngine.rtnDs IsNot Nothing Then
                                            If rtnDs.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDs.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDs.GetXml)
                                            Else
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, ruleEngine.rtnDs.GetXml)
                                            End If
                                        Else
                                            If rtnDs.Contains(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim) Then
                                                rtnDs.Remove(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim)
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            Else
                                                rtnDs.Add(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim, "")
                                            End If
                                        End If
                                    Else
                                        log.fileDebugMsg("CallForm-Step.2-2-2 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                        '執行檢核失敗
                                        ProcessFlag = False
                                    End If
                                End If
                            Else
                                If row.Item("Item_Param").ToString.Trim <> "" Then
                                    Dim token() As Object = row.Item("Item_Param").ToString.Trim.Split(";")
                                    'Dim token() As String = "X=8211001;N=4".Split(";")
                                    Dim var(token.Count - 1) As String
                                    Dim val(token.Count - 1) As String

                                    '參數變數型態皆為 String
                                    For i As Integer = 0 To token.Count - 1
                                        Dim tempToken() As String = token(i).Split("=")
                                        If tempToken.Count > 1 Then
                                            var(i) = tempToken(0)
                                            val(i) = tempToken(1)
                                        End If
                                    Next

                                    Dim tExForm As System.Type = assem.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim)
                                    Dim exFormAsObj As Object = Activator.CreateInstance(tExForm, val)

                                    If strString.ToString.Trim <> "" Then
                                        strString.Append(";")
                                    End If
                                    strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                                Else
                                    Dim tExForm As System.Type = assem.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim)
                                    Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)

                                    If strString.ToString.Trim <> "" Then
                                        strString.Append(";")
                                    End If
                                    strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                                End If
                            End If
                            log.fileDebugMsg("CallForm-Step.2-2 結束進行外部資料項目檢核")
                        Case "5"
                            If row.Item("Item_Param").ToString.Trim <> "" Then
                                Dim token() As Object = row.Item("Item_Param").ToString.Trim.Split(";")
                                Dim var(token.Count - 1) As String
                                Dim val(token.Count - 1) As String

                                '參數變數型態皆為 String
                                For i As Integer = 0 To token.Count - 1
                                    Dim tempToken() As String = token(i).Split("=")
                                    If tempToken.Count > 1 Then
                                        var(i) = tempToken(0)
                                        val(i) = tempToken(1)
                                    End If
                                Next

                                Dim exFormAsObj As Object = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim), val)
                                Dim myF As Form = CType(exFormAsObj, Form)
                                myF.ShowDialog()
                                If strString.ToString.Trim <> "" Then
                                    strString.Append(";")
                                End If
                                strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                            Else
                                Dim tExForm As System.Type = assem.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim)
                                Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)
                                Dim myF As Form = CType(exFormAsObj, Form)
                                myF.ShowDialog()
                                If strString.ToString.Trim <> "" Then
                                    strString.Append(";")
                                End If
                                strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                            End If
                        Case "6"
                            If row.Item("Item_Param").ToString.Trim <> "" Then
                                Dim token() As Object = row.Item("Item_Param").ToString.Trim.Split(";")
                                Dim var(token.Count - 1) As String
                                Dim val(token.Count - 1) As String

                                '參數變數型態皆為 String
                                For i As Integer = 0 To token.Count - 1
                                    Dim tempToken() As String = token(i).Split("=")
                                    If tempToken.Count > 1 Then
                                        var(i) = tempToken(0)
                                        val(i) = tempToken(1)
                                    End If
                                Next

                                Dim exFormAsObj As Object = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim), val)
                                Dim myF As Form = CType(exFormAsObj, Form)
                                myF.ShowDialog()
                                If strString.ToString.Trim <> "" Then
                                    strString.Append(";")
                                End If
                                strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(CallForm(exFormAsObj.returnValue, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData))
                            Else
                                Dim tExForm As System.Type = assem.GetType("Syscom.Client.PUB." & row.Item("Program_Code").ToString.Trim)
                                Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)
                                Dim myF As Form = CType(exFormAsObj, Form)
                                myF.ShowDialog()
                                If strString.ToString.Trim <> "" Then
                                    strString.Append(";")
                                End If
                                strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(CallForm(exFormAsObj.returnValue, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData))
                            End If
                    End Select
                Next

                '設值字串
                SetValueStr = strString.ToString
                ExpressionStr = expString.ToString

                Dim pubRuleParserBP As PUBRuleParserBP = pubRuleParserBP.GetInstance

                Try
                    log.fileDebugMsg("CallForm-Step.3 開始進入實際比對[" & ExpressionStr & "][" & SetValueStr & "]")
                    If pubRuleParserBP.checkValue(ExpressionStr, SetValueStr) Then
                        ProcessFlag = pubRuleParserBP.postFix(ExpressionStr)
                    Else
                        ProcessFlag = False
                    End If
                    log.fileDebugMsg("CallForm-Step.3 結束進入實際比對[" & ExpressionStr & "][" & SetValueStr & "]")
                Catch ex As Exception
                    Throw ex
                Finally
                    If pubRuleParserBP.msg IsNot Nothing Then
                        For i As Integer = 0 To pubRuleParserBP.msg.Count - 1
                            Dim ReturnCheckingFlag As String = ""
                            Dim token() As String = pubRuleParserBP.msg(i).ToString.Trim.Split(";")
                            For Each row As DataRow In PUBRuleDetail.Rows
                                If row.Item("Rule_Code").ToString.Trim = RuleCode AndAlso row.Item("Item_Code").ToString.Trim = ItemCode Then
                                    SeqNo = row.Item("Seq_No").ToString.Trim
                                    ReturnCheckingFlag = row.Item("Return_Checking_Flag").ToString.Trim
                                End If
                            Next
                            If rtnDataUnit.Count <> 0 Then
                                If rtnDataUnit.Contains(token(0)) AndAlso rtnDs.Contains(token(0)) Then
                                    messageDataSet.Tables("FalseCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), rtnDataUnit(token(0)).ToString.Trim, rtnDs(token(0)).ToString.Trim})
                                    rtnDataUnit.Clear()
                                Else
                                    messageDataSet.Tables("FalseCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), "", ""})
                                End If
                            Else
                                messageDataSet.Tables("FalseCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), "", ""})
                            End If
                        Next
                        pubRuleParserBP.msg.Clear()
                    End If
                    If pubRuleParserBP.tmsg IsNot Nothing Then
                        For i As Integer = 0 To pubRuleParserBP.tmsg.Count - 1
                            Dim ReturnCheckingFlag As String = ""
                            Dim token() As String = pubRuleParserBP.tmsg(i).ToString.Trim.Split(";")
                            For Each row As DataRow In PUBRuleDetail.Rows
                                If row.Item("Rule_Code").ToString.Trim = RuleCode AndAlso row.Item("Item_Code").ToString.Trim = ItemCode Then
                                    SeqNo = row.Item("Seq_No").ToString.Trim
                                    ReturnCheckingFlag = row.Item("Return_Checking_Flag").ToString.Trim
                                End If
                            Next
                            If rtnDataUnit.Count <> 0 Then
                                If rtnDataUnit.Contains(token(0)) AndAlso rtnDs.Contains(token(0)) Then
                                    messageDataSet.Tables("TrueCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), rtnDataUnit(token(0)).ToString.Trim, rtnDs(token(0)).ToString.Trim})
                                    rtnDataUnit.Clear()
                                Else
                                    messageDataSet.Tables("TrueCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), "", ""})
                                End If
                            Else
                                messageDataSet.Tables("TrueCondition").Rows.Add(New Object() {RuleCode, SeqNo, PUBRuleDetail.Rows(0).Item("Item_Code").ToString.Trim, ReturnCheckingFlag, token(1), token(2), "", ""})
                            End If
                        Next
                        pubRuleParserBP.tmsg.Clear()
                    End If
                End Try
                If DataSetUtil.IsContainsData(PUBRule) Then
                    ExpressionStr = PUBRule.Rows(0).Item("RuleExpStrCht").ToString.Trim
                End If
                Return ProcessFlag
            End If
        Catch ex As Exception
            log.fileErrorMsg("CallForm(" & RuleCode & ")：" & ex.Message, ex)
            Throw ex
        End Try
    End Function

    Public Sub clearParser()
        Try
            For Each table As DataTable In messageDataSet.Tables
                table.Clear()
            Next
            msg.Clear()
            ExpressionStr = Nothing
            SetValueStr = Nothing

            returnValue = Nothing
            InitialCode = Nothing

            ItemCode = Nothing
            ItemName = Nothing
            ValueData = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "2012/05/22 add by liuye 重寫RuleTransfer，部分處理移動到Server端"

    ''' <summary>
    ''' 轉換 ItemCode 為 RuleCode，並進行檢核
    ''' </summary>
    ''' <param name="Location">檢核發生的site描述: "C"->Client端 or "S"->Server端</param>
    ''' <param name="SystemType">檢核發生系統歸屬: "O"->門診 or "E"->急診 or "I"->住院</param>
    ''' <param name="TriggerItemSet">提供 API 搜尋檢核條件條件值</param>
    ''' <param name="OperationDS">檢核API 在檢核過程中需要使用的資料</param>
    ''' <param name="AutoAppendHistoryOrders">是否自動新增當次就醫歷史醫令，預設為Y</param>
    ''' <returns></returns>
    ''' <remarks>2012/05/22</remarks>
    Public Function RuleTransfer_N1(ByVal Location As String, ByVal SystemType As String, ByVal TriggerItemSet As DataSet, ByVal OperationDS As DataSet, Optional ByVal AutoAppendHistoryOrders As String = "Y") As Boolean
        Try
            log.fileDebugMsg("RuleTransfer_N1-開始進入 RuleTransfer_N1")

            Dim totalResult As Boolean = True
            Dim Source As String = Location.ToUpper & SystemType.ToUpper

            If Not TriggerItemSet.Tables(0).Columns.Contains("ItemName") Then
                TriggerItemSet.Tables(0).Columns.Add("ItemName")
            End If

            If Not TriggerItemSet.Tables(0).Columns.Contains("IsForce") Then
                TriggerItemSet.Tables(0).Columns.Add("IsForce")
            End If

            '20120529 add by Rich, 大中要求因應急診住院當次就醫，需要自動將歷史醫令加入檢核的來源 Dataset 中。
            If OperationDS.Tables.Contains("Order_Record") Then
                If Not OperationDS.Tables("Order_Record").Columns.Contains("Order_Status") Then
                    OperationDS.Tables("Order_Record").Columns.Add("Order_Status")
                End If

                For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                    If row.Item("Order_Status").ToString.Trim = "" Then
                        row.Item("Order_Status") = "A"
                    End If
                Next
            End If

            log.fileDebugMsg("RuleTransfer_N1() - cp - 001")

            If AutoAppendHistoryOrders = "Y" AndAlso OperationDS.Tables.Contains("Medical_Record") AndAlso OperationDS.Tables("Medical_Record").Rows.Count > 0 AndAlso OperationDS.Tables("Medical_Record").Rows(0).Item("Medical_Sn").ToString.Trim <> "" Then

                'Step.1.取得歷史醫令
                Dim dsCurrentOrderset As DataSet = GetCurrentOrderset(OperationDS.Tables("Medical_Record").Rows(0).Item("Medical_Sn").ToString.Trim, SystemType, Location)
                If dsCurrentOrderset.Tables(0).Rows.Count > 0 Then

                    log.fileDebugMsg("RuleTransfer_N1() - cp - 002")

                    'Step.2.合併現有醫令
                    If OperationDS.Tables.Contains("Order_Record") Then

                        '取得最大號
                        Dim MaxOrderSno As Integer = 1
                        For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                            If CInt(row.Item("Order_Sno")) > MaxOrderSno Then
                                MaxOrderSno = CInt(row.Item("Order_Sno"))
                            End If
                        Next

                        log.fileDebugMsg("RuleTransfer_N1() - cp - 003")

                        '若是傳進來的 Order_Sno 為空的話 , 則賦予值
                        For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                            If row.Item("Order_Sno").ToString.Trim = "" Then
                                MaxOrderSno += 1
                                If MaxOrderSno < 10 Then
                                    row.Item("Order_Sno") = MaxOrderSno.ToString.PadLeft(2, "0")
                                Else
                                    row.Item("Order_Sno") = MaxOrderSno.ToString
                                End If
                            End If
                        Next

                        log.fileDebugMsg("RuleTransfer_N1() - cp - 004")

                        For Each CurrentRow As DataRow In dsCurrentOrderset.Tables(0).Rows

                            Dim check As Boolean = False
                            For Each row As DataRow In OperationDS.Tables("Order_Record").Rows
                                If CurrentRow.Item("Order_Record_No").ToString.Trim = row.Item("Order_Record_No").ToString.Trim Then
                                    check = True
                                    Exit For
                                End If
                            Next

                            If check = True Then
                                Continue For
                            Else
                                Dim insertRow As DataRow = OperationDS.Tables("Order_Record").NewRow

                                For Each colOp As DataColumn In OperationDS.Tables("Order_Record").Columns

                                    '20120615 add by Rich, 大中要求把 OperationDs.Tables(“Order_Record”) 中新增加的 row 的資料欄位中有一個名稱為 【Order_Sno】的值(為文字格式的數字內容)，需要人工給號(依照傳入的 table 中最大 的 Order_Sno 在往後增加填入，在 Order_Record table 中的 Order_Sno 要保證都有值且不重複)
                                    If colOp.ColumnName = "Order_Sno" Then
                                        MaxOrderSno += 1
                                        If MaxOrderSno < 10 Then
                                            insertRow.Item(colOp.ColumnName) = MaxOrderSno.ToString.PadLeft(2, "0")
                                        Else
                                            insertRow.Item(colOp.ColumnName) = MaxOrderSno.ToString
                                        End If
                                        Continue For
                                    End If

                                    For Each col As DataColumn In dsCurrentOrderset.Tables(0).Columns
                                        If colOp.ColumnName = col.ColumnName Then
                                            If colOp.DataType Is GetType(System.Decimal) AndAlso CurrentRow.Item(col.ColumnName).ToString.Trim = "" Then
                                                insertRow.Item(colOp.ColumnName) = 0
                                            ElseIf col.DataType Is GetType(System.DateTime) Then
                                                If IsDBNull(CurrentRow.Item(col.ColumnName)) Then
                                                    insertRow.Item(colOp.ColumnName) = String.Empty
                                                Else
                                                    insertRow.Item(colOp.ColumnName) = CDate(CurrentRow.Item(col.ColumnName)).ToString("yyyy-MM-dd HH:mm:ss")
                                                End If
                                            Else
                                                insertRow.Item(colOp.ColumnName) = CurrentRow.Item(col.ColumnName)
                                            End If
                                            Exit For
                                        End If
                                    Next
                                Next

                                OperationDS.Tables("Order_Record").Rows.Add(insertRow)
                            End If
                        Next
                    End If
                End If
            End If

            log.fileDebugMsg("RuleTransfer_N1() - cp - 005")

            '刪除掉 Order_Status 為 D 的資料列
            If OperationDS.Tables.Contains("Order_Record") Then
                For i As Integer = OperationDS.Tables("Order_Record").Rows.Count - 1 To 0 Step -1
                    With OperationDS.Tables("Order_Record").Rows(i)
                        If .Item("Order_Status").ToString.Trim = "D" Then
                            OperationDS.Tables("Order_Record").Rows.RemoveAt(i)
                        End If
                    End With
                Next
            End If

            log.fileDebugMsg("RuleTransfer_N1() - cp - 006")

            TriggerItemSet.DataSetName = "TriggerItemSet"
            OperationDS.DataSetName = "OperationDS"
            log.fileDebugMsg("RuleTransfer_N1-TriggerItemSet XML：" & vbNewLine & TriggerItemSet.GetXml)
            log.fileDebugMsg("RuleTransfer_N1-未展延前的 OperationDS XML：" & vbNewLine & OperationDS.GetXml)

            '若沒有欄位RuleCode或該RuleCode欄位沒有值時
            If TriggerItemSet.Tables(0).Columns.Contains("RuleCode") AndAlso TriggerItemSet.Tables(0).Rows(0).Item("RuleCode").ToString.Trim <> "" Then

                '20130909 modified by Ken.
                '無論欄位 IsCodeExchanged為何，則進行轉換延展
                Dim api As New PUBRuleEngineAPI

                Try
                    If Location = "S" AndAlso OperationDS.Tables.Contains("Order_Record") AndAlso OperationDS.Tables("Order_Record").Columns.Contains("Insu_Code") Then

                        OperationDS = Me.Ext_OrderCode_To_InsuCode_X(OperationDS, Nothing)
                    Else
                        OperationDS = api.Ext_OrderCode_To_InsuCode(OperationDS, "Order_Record", "Order_Code", "Insu_Code", "Insu_Group_Code", "Order_Date", "Order_Name")
                    End If
                Catch ex As Exception
                    'Do Nothing
                End Try

                '若是欄位RuleCode有值時
                For Each RuleCodeRow As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows

                    Dim LimitLevel As Integer = 0
                    Dim totalRuleResult As Integer = 1
                    ItemCode = RuleCodeRow.Item("ItemCode").ToString.Trim
                    ItemName = RuleCodeRow.Item("ItemName").ToString.Trim
                    ValueData = RuleCodeRow.Item("ValueData").ToString.Trim

                    '全面檢查
                    'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                    '    Continue For
                    'End If

                    Dim singleRuleResult As Integer = 1

                    '20110307 modify by Rich, 當IsForce此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                    If RuleCodeRow.Item("IsForce").ToString.Trim.ToUpper = "Y" Then
                        If RuleCodeRow.Item("RuleCode").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                            Continue For
                        End If
                    End If

                    '逐一檢查
                    If Not CheckRule(RuleCodeRow.Item("RuleCode").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("RuleCode").ToString.Trim, Source, ItemCode, RuleCodeRow.Item("ItemParam").ToString.Trim, ValueData) Then
                        singleRuleResult = 0
                        totalRuleResult = 0
                        totalResult = False
                    End If

                    '=============寫入檢核訊息===============
                    Dim RuleCode As String = RuleCodeRow.Item("RuleCode").ToString.Trim
                    Dim _CheckResult As Integer = singleRuleResult
                    messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                    '========================================

                    '=============寫入檢核訊息===============
                    Dim LimitAlertLevel As Integer = LimitLevel
                    Dim CheckResult As Integer = totalRuleResult
                    messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                    '========================================
                Next

            Else
                '無論欄位 IsCodeExchanged為何，則進行轉換延展
                Dim api As New PUBRuleEngineAPI

                Try
                    If Location = "S" AndAlso OperationDS.Tables.Contains("Order_Record") AndAlso OperationDS.Tables("Order_Record").Columns.Contains("Insu_Code") Then

                        OperationDS = Me.Ext_OrderCode_To_InsuCode_X(OperationDS, Nothing)
                    Else
                        OperationDS = api.Ext_OrderCode_To_InsuCode(OperationDS, "Order_Record", "Order_Code", "Insu_Code", "Insu_Group_Code", "Order_Date", "Order_Name")
                    End If
                Catch ex As Exception
                    'Do Noting.
                End Try

                log.fileDebugMsg("RuleTransfer_N1-已展延後的 OperationDS XML：" & vbNewLine & OperationDS.GetXml)

                log.fileDebugMsg("RuleTransfer_N1-Step.1 開始進入轉換健保碼規則對應")

                If OperationDS.Tables.Contains("Order_Record") Then
                    '若欄位 ItemCode 為 A00004，則新增 A00006、A00022，A00006 -> Insu_Code、A00022 -> Insu_Group_Code
                    '若欄位 ItemCode 為 A00006，則新增 A00022，A00006 -> Insu_Group_Code
                    Dim tempDs As DataSet = TriggerItemSet.Copy
                    For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                        If row.Item("ItemCode").ToString.Trim = "A00004" Then
                            If row.Item("ValueData").ToString.Trim <> "" Then
                                Dim queryRows() As DataRow = OperationDS.Tables("Order_Record").Select(" Order_Code = '" & row.Item("ValueData").ToString.Trim & "' ")
                                If Not OperationDS.Tables("Order_Record").Columns.Contains("Insu_Group_Code") Then
                                    OperationDS.Tables("Order_Record").Columns.Add("Insu_Group_Code")
                                End If
                                For Each oneRow As DataRow In queryRows
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00006", DBNull.Value, oneRow.Item("Insu_Code").ToString.Trim, "N", DBNull.Value})
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, oneRow.Item("Insu_Group_Code").ToString.Trim, "N", DBNull.Value})
                                Next
                            Else
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00006", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                            End If
                        ElseIf row.Item("ItemCode").ToString.Trim = "A00006" Then
                            If row.Item("ValueData").ToString.Trim <> "" Then
                                Dim queryRows() As DataRow = OperationDS.Tables("Order_Record").Select(" Insu_Code = '" & row.Item("ValueData").ToString.Trim & "' ")
                                If Not OperationDS.Tables("Order_Record").Columns.Contains("Insu_Group_Code") Then
                                    OperationDS.Tables("Order_Record").Columns.Add("Insu_Group_Code")
                                End If
                                For Each oneRow As DataRow In queryRows
                                    tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, oneRow.Item("Insu_Group_Code").ToString.Trim, "N", DBNull.Value})
                                Next
                            Else
                                tempDs.Tables("Trigger_Item").Rows.Add(New Object() {"A00022", DBNull.Value, DBNull.Value, "N", DBNull.Value})
                            End If
                        End If
                    Next
                    TriggerItemSet = tempDs.Copy

                    '若ItemCode對應的ValueData為空白，則將同ItemCode的其他筆數刪除
                    Dim same As New ArrayList
                    For Each row As DataRow In tempDs.Tables(0).Rows
                        If row.Item("ValueData").ToString.Trim = "" AndAlso (Not same.Contains(row.Item("ItemCode").ToString.Trim)) Then
                            same.Add(row.Item("ItemCode").ToString.Trim)
                            For i As Integer = TriggerItemSet.Tables(0).Rows.Count - 1 To 0 Step -1
                                If TriggerItemSet.Tables(0).Rows(i).Item("ItemCode").ToString.Trim = row.Item("ItemCode").ToString.Trim AndAlso TriggerItemSet.Tables(0).Rows(i).Item("ValueData").ToString.Trim <> "" Then
                                    TriggerItemSet.Tables(0).Rows.RemoveAt(i)
                                End If
                            Next
                        End If
                    Next
                End If

                log.fileDebugMsg("RuleTransfer_N1-Step.1 結束進入轉換健保碼規則對應")

                log.fileDebugMsg("RuleTransfer_N1-Step.2 開始進入所有檢核邏輯程式執行(包含內部外部)")

                '20110104 fix by Rich, 取得ItemName
                Dim Item_Code As String = ""
                For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                    If Item_Code <> "" Then
                        Item_Code &= ","
                    End If
                    Item_Code &= "'" & row.Item("ItemCode").ToString.Trim & "'"
                Next
                Dim dsItemName As DataSet = pub.queryItemName(Item_Code)
                If DataSetUtil.IsContainsData(dsItemName) Then
                    dsItemName.Tables(0).PrimaryKey = New DataColumn() {dsItemName.Tables(0).Columns("Item_Code")}
                    For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows
                        If dsItemName.Tables(0).Rows.Contains(row.Item("ItemCode").ToString.Trim) Then
                            row.Item("ItemName") = dsItemName.Tables(0).Rows.Find(row.Item("ItemCode").ToString.Trim).Item("Item_Name").ToString.Trim
                        End If
                    Next
                End If

                '20110214 add by Rich, 大中要求加入基準日判斷在最上層
                Dim Base_Date As String = ""
                If OperationDS.Tables("Medical_Record").Columns.Contains("Nhi_Ym") Then
                    If OperationDS.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Nhi_Ym").ToString.Trim.Insert(4, "-") & "-" & "01 00:00:00"
                    ElseIf OperationDS.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Visit_End_Date").ToString.Trim
                    ElseIf OperationDS.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim <> "" Then
                        Base_Date = OperationDS.Tables("Medical_Record").Rows(0).Item("Order_Date").ToString.Trim
                    Else
                        Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                Else
                    Base_Date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                End If


                Dim dtQueryCond As New DataTable
                dtQueryCond.TableName = "Trigger_Item"
                Dim colQ() As String = {"ItemCode", "ItemName", "ValueData", "Base_Date", "IsForce", "LimitLevel", "Source", "ExpressionStr", "ItemParam", "InitialCode"}
                For i As Integer = 0 To colQ.Count - 1
                    dtQueryCond.Columns.Add(colQ(i))
                Next
                'dsQcond.Tables.Add(dtQueryCond)

                For Each row As DataRow In TriggerItemSet.Tables("Trigger_Item").Rows

                    '取得ItemParam參數值
                    Dim token() As String = row.Item("ItemParam").ToString.Trim.Split(";")
                    Dim var(token.Count - 1) As String
                    Dim val(token.Count - 1) As String

                    '參數變數型態皆為 String
                    For i As Integer = 0 To token.Count - 1
                        Dim tempToken() As String = token(i).Split("=")
                        If tempToken.Count > 1 Then
                            var(i) = tempToken(0)
                            val(i) = tempToken(1)
                        End If
                    Next

                    '判斷TriggerItemSet中該資料列的ValueData是否有值
                    If row.Item("ValueData").ToString.Trim <> "" Then
                        '20120523 切出去的部分
                        Dim LimitLevel As Integer = 0
                        Dim totalRuleResult As Integer = 1
                        'Dim dsQcond As New DataSet
                        'Dim dtQueryCond As New DataTable
                        'dtQueryCond.TableName = "Trigger_Item"
                        'Dim colQ() As String = {"ItemCode", "ItemName", "ValueData", "Base_Date", "IsForce", "LimitLevel", "Source", "ExpressionStr", "ItemParam", "InitialCode"}
                        'For i As Integer = 0 To colQ.Count - 1
                        '    dtQueryCond.Columns.Add(colQ(i))
                        'Next
                        dtQueryCond.Rows.Add()

                        With dtQueryCond.Rows(dtQueryCond.Rows.Count - 1)
                            .Item("ItemCode") = row.Item("ItemCode").ToString.Trim
                            .Item("ItemName") = row.Item("ItemName").ToString.Trim
                            .Item("ValueData") = row.Item("ValueData").ToString.Trim
                            .Item("Base_Date") = Base_Date
                            If row.Item("IsForce").ToString.Trim.ToUpper = "Y" Then
                                .Item("IsForce") = "Y"
                            Else
                                .Item("IsForce") = "N"
                            End If
                            .Item("LimitLevel") = LimitLevel
                            .Item("Source") = Source
                            .Item("ExpressionStr") = ExpressionStr
                            .Item("ItemParam") = row.Item("ItemParam").ToString.Trim
                            .Item("InitialCode") = InitialCode
                        End With

                    Else
                        Dim ds As DataSet = pub.queryClassAndField(row.Item("ItemCode").ToString.Trim, val(0))

                        Dim LimitLevel As Integer = 0
                        Dim totalRuleResult As Integer = 1

                        If ds.Tables("PUB_Rule").Rows.Count <> 0 Then

                            For Each MatchRow As DataRow In ds.Tables("PUB_Rule").Rows

                                '20110519 add by Rich, 大中要求若對應的 Table 與 Column 不存在時，則 By Pass
                                If Not (OperationDS.Tables.Contains(MatchRow.Item("TableName").ToString.Trim) AndAlso OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains(MatchRow.Item("ColumnName").ToString.Trim)) Then
                                    Continue For
                                End If

                                '特殊規則
                                Select Case row.Item("ItemCode").ToString.Trim
                                    Case "A00009"

                                        '20120601 add by Rich, 加入判別 Table 是否為 Order_Record , 用來加入 Order_Status 欄位
                                        Dim colStr() As String = Nothing
                                        If MatchRow.Item("TableName").ToString.Trim = "Order_Record" Then
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim, "Order_Status"}
                                        Else
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim}
                                        End If

                                        For Each OperationDtRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).DefaultView.ToTable(True, colStr).Select("Icd_Sort_Value <= '" & row.Item("ValueData") & "'")

                                            '20120530 add by Rich, 大中要求若是遇到 Order_Record 且 Order_Status 為空的則不進行規則檢核
                                            If MatchRow.Item("TableName").ToString.Trim = "Order_Record" AndAlso OperationDtRow.Item("Order_Status").ToString.Trim = "" Then
                                                Continue For
                                            End If

                                            '20120523 切出去的部分
                                            dtQueryCond.Rows.Add()
                                            Dim chkOPH As Boolean = False
                                            If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Force") Then
                                                For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                    If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                        If tempRow.Item("Is_Force").ToString.Trim.ToUpper = "Y" Then
                                                            chkOPH = True
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                            '20110905 add by Rich, 大中要求加入判斷Is_Preadmission有值並為'Y'時，，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                            If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Preadmission") Then
                                                For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                    If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                        If tempRow.Item("Is_Preadmission").ToString.Trim.ToUpper = "Y" Then
                                                            chkOPH = True
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                            With dtQueryCond.Rows(dtQueryCond.Rows.Count - 1)
                                                .Item("ItemCode") = row.Item("ItemCode").ToString.Trim
                                                .Item("ItemName") = row.Item("ItemName").ToString.Trim
                                                .Item("ValueData") = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim
                                                .Item("Base_Date") = Base_Date
                                                If chkOPH = True Then
                                                    .Item("IsForce") = "Y"
                                                Else
                                                    .Item("IsForce") = "N"
                                                End If
                                                .Item("LimitLevel") = LimitLevel
                                                .Item("Source") = Source
                                                .Item("ExpressionStr") = ExpressionStr
                                                .Item("ItemParam") = row.Item("ItemParam").ToString.Trim
                                                .Item("InitialCode") = InitialCode
                                            End With
                                        Next
                                    Case Else

                                        '20120601 add by Rich, 加入判別 Table 是否為 Order_Record , 用來加入 Order_Status 欄位
                                        Dim colStr() As String = Nothing
                                        If MatchRow.Item("TableName").ToString.Trim = "Order_Record" Then
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim, "Order_Status"}
                                        Else
                                            colStr = New String() {MatchRow.Item("ColumnName").ToString.Trim}
                                        End If

                                        For Each OperationDtRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).DefaultView.ToTable(True, colStr).Rows

                                            '20120530 add by Rich, 大中要求若是遇到 Order_Record 且 Order_Status 為空的則不進行規則檢核
                                            If MatchRow.Item("TableName").ToString.Trim = "Order_Record" AndAlso OperationDtRow.Item("Order_Status").ToString.Trim = "" Then
                                                Continue For
                                            End If

                                            'ItemCode = row.Item("ItemCode").ToString.Trim
                                            'ItemName = row.Item("ItemName").ToString.Trim
                                            'ValueData = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim

                                            '20120523 切出去的部分
                                            dtQueryCond.Rows.Add()
                                            Dim chkOPH As Boolean = False
                                            If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Force") Then
                                                For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                    If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                        If tempRow.Item("Is_Force").ToString.Trim.ToUpper = "Y" Then
                                                            chkOPH = True
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                            '20110905 add by Rich, 大中要求加入判斷Is_Preadmission有值並為'Y'時，，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')
                                            If OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Columns.Contains("Is_Preadmission") Then
                                                For Each tempRow As DataRow In OperationDS.Tables(MatchRow.Item("TableName").ToString.Trim).Rows
                                                    If tempRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim Then
                                                        If tempRow.Item("Is_Preadmission").ToString.Trim.ToUpper = "Y" Then
                                                            chkOPH = True
                                                        End If
                                                        Exit For
                                                    End If
                                                Next
                                            End If
                                            With dtQueryCond.Rows(dtQueryCond.Rows.Count - 1)
                                                .Item("ItemCode") = row.Item("ItemCode").ToString.Trim
                                                .Item("ItemName") = row.Item("ItemName").ToString.Trim
                                                .Item("ValueData") = OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim
                                                .Item("Base_Date") = Base_Date
                                                If chkOPH = True Then
                                                    .Item("IsForce") = "Y"
                                                Else
                                                    .Item("IsForce") = "N"
                                                End If
                                                .Item("LimitLevel") = LimitLevel
                                                .Item("Source") = Source
                                                .Item("ExpressionStr") = ExpressionStr
                                                .Item("ItemParam") = row.Item("ItemParam").ToString.Trim
                                                .Item("InitialCode") = InitialCode
                                            End With
                                            'Dim dsM As DataSet = messageDataSet.Clone
                                            'Dim icount As Integer = pub.QuerymessageDataSet_L(dsQcond, OperationDS, totalRuleResult, dsM, InitialCode)
                                            'messageDataSet.Merge(dsM)
                                        Next
                                End Select
                            Next
                        Else
                            '找不到對應的RuleCode
                        End If
                        ''=============寫入檢核訊息===============
                        'Dim LimitAlertLevel As Integer = LimitLevel
                        'Dim CheckResult As Integer = totalRuleResult
                        'messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                        ''========================================
                    End If
                Next
                Dim dsM As DataSet = messageDataSet.Clone
                Dim dsQcond As New DataSet
                Dim dtQuery2 As DataTable = dtQueryCond.DefaultView.ToTable("Trigger_Item", True, colQ)
                dsQcond.Tables.Add(dtQuery2)
                Dim icount As Integer = pub.QuerymessageDataSet_L(dsQcond, OperationDS, 1, dsM)
                Dim colMaster() As String = {"ItemCode", "ItemName", "ValueData", "LimitAlertLevel", "CheckResult"}
                Dim dtview As DataView = dsM.Tables("MasterMessage").DefaultView
                Dim dtMast As DataTable = dtview.ToTable("MasterMessage", True, colMaster)
                dsM.Tables("MasterMessage").Rows.Clear()
                dsM.Tables("MasterMessage").Merge(dtMast)


                messageDataSet.Merge(dsM)
                log.fileDebugMsg("RuleTransfer_N1-Step.2 結束進入所有檢核邏輯程式執行(包含內部外部)")
            End If
            'Return totalResult
            log.fileDebugMsg("RuleTransfer_N1-結束進入 RuleTransfer_N1")
            log.fileDebugMsg("RuleTransfer_N1-messageDataSet XML：" & vbNewLine & messageDataSet.GetXml)
            Return True
        Catch ex As Exception
            log.fileErrorMsg("RuleTransfer_N1-發生錯誤：" & ex.Message, ex)
            Return False
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 搜尋歷史醫令
    ''' </summary>
    ''' <param name="Medical_Sn">就醫序號</param>
    ''' <param name="SystemType">系統歸屬 {O}門診 or {E}急診 or {I}住院</param>
    ''' <param name="Location">C,P,S</param>
    ''' <returns>所有歷史醫令的資料集</returns>
    ''' <remarks>by Rich on 2012-05-30</remarks>
    Public Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet
        Try
            Dim dsCurrentOrderset As DataSet = pub.GetCurrentOrderset(Medical_Sn, SystemType, Location)
            Return dsCurrentOrderset
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
