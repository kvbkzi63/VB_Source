'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBRuleTransferN1BS_E2.vb
'*              Title:	PUBRuleTransferN1BS_E2
'*        Description:	PUBRuleTransferN1BS_E2
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	liuye
'*        Create Date:	2012/05/23
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Server.NFC
Imports System.Reflection

Public Class PUBRuleTransferN1BS_E2
    Private Shared myInstance As PUBRuleTransferN1BS_E2

    Public Overloads Function getInstance() As PUBRuleTransferN1BS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBRuleTransferN1BS_E2()
        End If
        Return myInstance
    End Function
    Private WarningLevel As Integer = 0
    Dim ItemCode As String = ""
    Dim ValueData As String = ""
    Dim ItemName As String = ""
    Dim LimitLevel As String = ""

    ''' <summary>
    ''' 與RuleTransfer_N1關聯的切出部分
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QuerymessageDataSet(ByVal dsQueryCond As DataSet, ByVal OperationDS As DataSet, ByRef totalRuleResult2 As Integer, ByRef messageDataSet As DataSet) As Integer
        Try            
            Dim ireturn As Integer = 1
            For Each IQrow As DataRow In dsQueryCond.Tables("Trigger_Item").Rows
                'Dim MatchRow As DataRow = dsQueryCond.Tables("PUB_Rule").Rows(0)
                ItemCode = IQrow("ItemCode").ToString.Trim() 'row.Item("ItemCode").ToString.Trim
                ItemName = IQrow("ItemName").ToString.Trim ' row.Item("ItemName").ToString.Trim
                ValueData = IQrow("ValueData").ToString.Trim 'OperationDtRow.Item(MatchRow.Item("ColumnName").ToString.Trim).ToString.Trim
                Dim Base_Date As String = IQrow("Base_Date").ToString.Trim
                Dim IsForce As String = IQrow("IsForce").ToString.Trim
                LimitLevel = IQrow("LimitLevel").ToString.Trim
                Dim Source As String = IQrow("Source").ToString.Trim
                Dim ExpressionStr As String = IQrow("ExpressionStr").ToString.Trim
                Dim ItemParam As String = IQrow("ItemParam").ToString.Trim
                Dim InitialCode As String = IQrow("InitialCode").ToString.Trim
                'Dim totalRuleResult As Integer = IQrow("totalRuleResult").ToString.Trim
                Dim instance As PUBRuleBS = PUBRuleBS.getInstance

                messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {"QuerymessageDataSet", Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #66 開始 queryRuleCode"})
                Dim _ds As DataSet = instance.queryRuleCode(ItemCode, ValueData, Base_Date)

                For Each RuleCodeRow As DataRow In _ds.Tables("PUB_RuleCode").Rows
                    Dim totalRuleResult As Integer = 1
                    '全面檢查
                    'If Not CheckRule(row.Item("Rule_Code").ToString.Trim, OperationDS) Then
                    '    Continue For
                    'End If

                    '20110307 modify by Rich, 當Is_Force此欄位有值並為'Y'時，表示觸發的值代表[強迫自費]的料號，該ValueData在搜尋檢核條件時僅需納入藥局的規則(RuleCode前3碼為'OPH')

                    'If IsForce = "Y" Then
                    '    If RuleCodeRow.Item("Rule_Code").ToString.Trim.Substring(0, 3).ToUpper <> "OPH" Then
                    '        '新增判斷如果搜尋到的檢核規則名稱不是【A00004-9130307限心臟內外科開立】且醫令不是【心臟冠狀動脈掃描(自費)】(Order_Code:9130308)的話,才不納入檢核 2014-2-25 黃富昌 
                    '        If RuleCodeRow.Item("Rule_Name").ToString.Trim <> "A00004-9130307限心臟內外科開立" AndAlso ValueData <> "9130308" Then
                    '            Continue For
                    '        End If
                    '    End If
                    'End If

                    Dim singleRuleResult As Integer = 1
                    '逐一檢查
                    If Not CheckRule(RuleCodeRow.Item("Rule_Code").ToString.Trim, OperationDS, LimitLevel, RuleCodeRow.Item("Rule_Code").ToString.Trim, Source, ItemCode, ItemParam, ValueData, InitialCode, messageDataSet) Then
                        singleRuleResult = 0
                        totalRuleResult = 0
                        'totalResult = False
                    End If
                    '=============寫入檢核訊息===============
                    Dim RuleCode As String = RuleCodeRow.Item("Rule_Code").ToString.Trim
                    Dim _CheckResult As Integer = singleRuleResult
                    messageDataSet.Tables("RuleInfo").Rows.Add(New Object() {RuleCode, ItemCode, ItemName, ValueData, ExpressionStr, _CheckResult})
                    '========================================
                    '=============寫入檢核訊息===============
                    Dim LimitAlertLevel As Integer = LimitLevel
                    Dim CheckResult As Integer = totalRuleResult
                    messageDataSet.Tables("MasterMessage").Rows.Add(New Object() {ItemCode, ItemName, ValueData, LimitAlertLevel, CheckResult})
                    '========================================
                Next
            Next

            Return ireturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 執行檢核流程
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <param name="CheckDataSet">檢核資料內容</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckRule(ByVal RuleCode As String, ByVal CheckDataSet As DataSet, ByRef LimitLevel As Integer, ByVal ParentRuleCode As String, ByVal Source As String, ByVal TriggerItemCode As String, ByVal TriggerItemPara As String, ByVal TriggerValueData As String, ByRef InitialCode As String, ByRef messageDataSet As DataSet) As Boolean
        Try
            Dim nfc As NFCDelegate = NFCDelegate.getInstance
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance

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

            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "144 開始 getCheckRuleDS"})
            'log.Debug("CheckRule-Step.1 開始撈取資料庫所需資料")
            Dim dsCheckRule As DataSet = instance.getCheckRuleDS(RuleCode, TriggerValueData, Source, Medical_Identity_Id, Base_Date)
            'log.Debug("CheckRule-Step.1 開始撈取資料庫所需資料")

            Dim PUBRuleClass As DataTable = dsCheckRule.Tables(0).Copy
            Dim PUBRule As DataTable = dsCheckRule.Tables(1).Copy
            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #151"})
            If Not DataSetUtil.IsContainsData(PUBRule) Then
                Throw New Exception("PUR_Rule 找不到對應的資料")
            End If

            If DataSetUtil.IsContainsData(PUBRuleClass) Then
                messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule-"})
                PUBRuleClass.PrimaryKey = New DataColumn() {PUBRuleClass.Columns("Rule_Code"), PUBRuleClass.Columns("Condition_Type")}

                '判斷該條件是否有起始條件
                If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "1"}) Then
                    Dim IniRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "1"}).Item("Condition_Rule_Code").ToString
                    InitialCode = IniRuleCode
                    If CheckRule(IniRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData, InitialCode, messageDataSet) Then
                        If CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData, messageDataSet) Then
                            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #166"})
                            If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "2"}) Then
                                Dim successRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "2"}).Item("Condition_Rule_Code").ToString
                                Return CheckRule(successRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData, InitialCode, messageDataSet)
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

                                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                            ''pvtReceiveMgr.RaiseNFCForceRefresh()
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

                                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                            ''pvtReceiveMgr.RaiseNFCForceRefresh()
                                        Else
                                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                        End If
                                    End If
                                End If
                                '========================================
                                Return tempBoolean
                            End If
                        Else
                            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #310"})
                            If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "3"}) Then
                                Dim failRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "3"}).Item("Condition_Rule_Code").ToString
                                Return CheckRule(failRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData, InitialCode, messageDataSet)
                            Else
                                tempBoolean = False
                                '=============寫入檢核訊息===============
                                'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #317"})
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
                                    'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #337"})
                                    If RuleCode = ParentRuleCode Then
                                        If CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level")) > LimitLevel Then
                                            LimitLevel = CInt(PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level"))
                                        End If

                                        Dim Limit_Level As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("Limit_Alert_Level").ToString()

                                        Dim False_Message As String = PUBRule.Rows.Find(New Object() {RuleCode}).Item("False_Message").ToString()

                                        If PUBRule.Columns.Contains("Ext_No") Then
                                            False_Message = False_Message & "。請洽：" & PUBRule.Rows.Find(New Object() {RuleCode}).Item("Ext_No").ToString()
                                        End If



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

                                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                            ''pvtReceiveMgr.RaiseNFCForceRefresh()
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

                                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                            ''pvtReceiveMgr.RaiseNFCForceRefresh()
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
                    If CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData, messageDataSet) Then
                        messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #466"})
                        If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "2"}) Then
                            Dim successRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "2"}).Item("Condition_Rule_Code").ToString
                            Return CheckRule(successRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData, InitialCode, messageDataSet)
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

                                        Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                        ''pvtReceiveMgr.RaiseNFCForceRefresh()
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

                                        Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                        ''pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                    End If
                                End If
                            End If
                            '========================================
                            Return tempBoolean
                        End If
                    Else
                        messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #610"})
                        If PUBRuleClass.Rows.Contains(New Object() {RuleCode, "3"}) Then
                            Dim failRuleCode As String = PUBRuleClass.Rows.Find(New Object() {RuleCode, "3"}).Item("Condition_Rule_Code").ToString
                            Return CheckRule(failRuleCode, CheckDataSet, LimitLevel, RuleCode, Source, TriggerItemCode, TriggerItemPara, TriggerValueData, InitialCode, messageDataSet)
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

                                        Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                        ''pvtReceiveMgr.RaiseNFCForceRefresh()
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

                                        Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                                        ''pvtReceiveMgr.RaiseNFCForceRefresh()
                                    Else
                                        messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, ParentRuleCode, Phrase_Name})
                                    End If
                                End If
                            End If
                            '========================================
                            Return tempBoolean
                            messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #752"})
                        End If
                    End If
                End If
            Else
                'MsgBox(RuleCode & "︰無關連條件！")
                messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #758"})
                tempBoolean = CallForm(RuleCode, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData, messageDataSet)
                '=============寫入檢核訊息===============
                If tempBoolean Then
                    'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #762"})
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
                    'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #783"})
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
                            'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #823"})
                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                            ''pvtReceiveMgr.RaiseNFCForceRefresh()
                        Else
                            messageDataSet.Tables("FalseMessage").Rows.Add(New Object() {TriggerItemCode, TriggerValueData, Order_Code, Order_Name, RuleCode, Limit_Level, False_Message, "", Phrase_Name})
                        End If
                    ElseIf RuleCode = InitialCode Then
                        '失敗不寫入FalseMessage訊息
                    Else
                        'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #843"})
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
                            'messageDataSet.Tables("ExceptionMessage").Rows.Add(New Object() {RuleCode, Now.ToString("yyyy-MM-dd HH:mm:ss"), "CheckRule- #882"})
                            Dim ophDS As DataSet = queryPhraseNameByOPHRuleReason(OPH_Rule_Reason)
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
                            'pvtReceiveMgr.RaiseNFCForceRefresh()
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
            'log.Error(currentTime & " CheckRule(" & RuleCode & ")：" & ex.Message)
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
    Public Function CallForm(ByVal RuleCode As String, ByVal CheckDataSet As DataSet, ByVal Source As String, ByVal TriggerItemCode As String, ByVal TriggerItemPara As String, ByVal TriggerValueData As String, ByRef messageDataSet As DataSet) As Boolean
        Try
            Dim SeqNo As String = Nothing
            Dim ExpressionStr As String
            Dim SetValueStr As String
            '步驟一︰依照 RuleCode 取得 DB 資料，並取得該邏輯判斷式字串 ExpressionStr
            Dim instance As PUBRuleBS = PUBRuleBS.getInstance
            '處理過程成功與否
            Dim ProcessFlag As Boolean = True

            'log.Debug("CallForm-Step.1 開始撈取資料庫所需資料")
            Dim dsCallForm As DataSet = instance.getCallFormDS(RuleCode)
            'log.Debug("CallForm-Step.1 結束撈取資料庫所需資料")

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
                            'log.Debug("CallForm-Step.2-1 開始進行內部資料項目檢核")
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
                            'log.Debug("CallForm-Step.2-1 結束進行內部資料項目檢核")
                        Case "4"
                            'log.Debug("CallForm-Step.2-2 開始進行外部資料項目檢核")
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
                                    ruleEngineForm = assem.GetType("Syscom.Server.PUB." & row.Item("Program_Code").ToString.Trim)
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
                                    'log.Debug("CallForm-Step.2-2-1 開始進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                    If Boolean.Parse(CallByName(ruleEngine, row.Item("Method_Code").ToString.Trim, CallType.Get)) Then
                                        'log.Debug("CallForm-Step.2-2-1 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
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
                                        'log.Debug("CallForm-Step.2-2-1 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
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
                                    'log.Debug("CallForm-Step.2-2-2 開始進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
                                    If Boolean.Parse(CallByName(ruleEngine, row.Item("Method_Code").ToString.Trim, CallType.Get)) Then
                                        'log.Debug("CallForm-Step.2-2-2 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
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
                                        'log.Debug("CallForm-Step.2-2-2 結束進入 PUBRuleEngineAPI " & row.Item("Method_Code").ToString.Trim)
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

                                    Dim tExForm As System.Type = assem.GetType("Syscom.Server.PUB." & row.Item("Program_Code").ToString.Trim)
                                    Dim exFormAsObj As Object = Activator.CreateInstance(tExForm, val)

                                    If strString.ToString.Trim <> "" Then
                                        strString.Append(";")
                                    End If
                                    strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                                Else
                                    Dim tExForm As System.Type = assem.GetType("Syscom.Server.PUB." & row.Item("Program_Code").ToString.Trim)
                                    Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)

                                    If strString.ToString.Trim <> "" Then
                                        strString.Append(";")
                                    End If
                                    strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                                End If
                            End If
                            'log.Debug("CallForm-Step.2-2 結束進行外部資料項目檢核")
                            'Case "5"
                            '    If row.Item("Item_Param").ToString.Trim <> "" Then
                            '        Dim token() As Object = row.Item("Item_Param").ToString.Trim.Split(";")
                            '        Dim var(token.Count - 1) As String
                            '        Dim val(token.Count - 1) As String

                            '        '參數變數型態皆為 String
                            '        For i As Integer = 0 To token.Count - 1
                            '            Dim tempToken() As String = token(i).Split("=")
                            '            If tempToken.Count > 1 Then
                            '                var(i) = tempToken(0)
                            '                val(i) = tempToken(1)
                            '            End If
                            '        Next

                            '        Dim exFormAsObj As Object = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly.GetType("nckuh.client.pub." & row.Item("Program_Code").ToString.Trim), val)
                            '        Dim myF As Form = CType(exFormAsObj, Form)
                            '        myF.ShowDialog()
                            '        If strString.ToString.Trim <> "" Then
                            '            strString.Append(";")
                            '        End If
                            '        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                            '    Else
                            '        Dim tExForm As System.Type = assem.GetType("nckuh.client.pub." & row.Item("Program_Code").ToString.Trim)
                            '        Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)
                            '        Dim myF As Form = CType(exFormAsObj, Form)
                            '        myF.ShowDialog()
                            '        If strString.ToString.Trim <> "" Then
                            '            strString.Append(";")
                            '        End If
                            '        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(exFormAsObj.returnValue)
                            '    End If
                            'Case "6"
                            '    If row.Item("Item_Param").ToString.Trim <> "" Then
                            '        Dim token() As Object = row.Item("Item_Param").ToString.Trim.Split(";")
                            '        Dim var(token.Count - 1) As String
                            '        Dim val(token.Count - 1) As String

                            '        '參數變數型態皆為 String
                            '        For i As Integer = 0 To token.Count - 1
                            '            Dim tempToken() As String = token(i).Split("=")
                            '            If tempToken.Count > 1 Then
                            '                var(i) = tempToken(0)
                            '                val(i) = tempToken(1)
                            '            End If
                            '        Next

                            '        Dim exFormAsObj As Object = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly.GetType("nckuh.client.pub." & row.Item("Program_Code").ToString.Trim), val)
                            '        Dim myF As Form = CType(exFormAsObj, Form)
                            '        myF.ShowDialog()
                            '        If strString.ToString.Trim <> "" Then
                            '            strString.Append(";")
                            '        End If
                            '        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(CallForm(exFormAsObj.returnValue, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData))
                            '    Else
                            '        Dim tExForm As System.Type = assem.GetType("nckuh.client.pub." & row.Item("Program_Code").ToString.Trim)
                            '        Dim exFormAsObj As Object = Activator.CreateInstance(tExForm)
                            '        Dim myF As Form = CType(exFormAsObj, Form)
                            '        myF.ShowDialog()
                            '        If strString.ToString.Trim <> "" Then
                            '            strString.Append(";")
                            '        End If
                            '        strString.Append(row.Item("Class_Name").ToString.Trim & "@" & row.Item("Field_Code").ToString.Trim & "=").Append(CallForm(exFormAsObj.returnValue, CheckDataSet, Source.Substring(0, 1), TriggerItemCode, TriggerItemPara, TriggerValueData))
                            '    End If
                    End Select
                Next

                '設值字串
                SetValueStr = strString.ToString
                ExpressionStr = expString.ToString

                Dim pubRuleParserBS As pubRuleParserBS = pubRuleParserBS.GetInstance

                Try
                    'log.Debug("CallForm-Step.3 開始進入實際比對[" & ExpressionStr & "][" & SetValueStr & "]")
                    If pubRuleParserBS.checkValue(ExpressionStr, SetValueStr) Then
                        ProcessFlag = pubRuleParserBS.postFix(ExpressionStr)
                    Else
                        ProcessFlag = False
                    End If
                    'log.Debug("CallForm-Step.3 結束進入實際比對[" & ExpressionStr & "][" & SetValueStr & "]")
                Catch ex As Exception
                    Throw ex
                Finally
                    If pubRuleParserBS.msg IsNot Nothing Then
                        For i As Integer = 0 To pubRuleParserBS.msg.Count - 1
                            Dim ReturnCheckingFlag As String = ""
                            Dim token() As String = pubRuleParserBS.msg(i).ToString.Trim.Split(";")
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
                        pubRuleParserBS.msg.Clear()
                    End If
                    If pubRuleParserBS.tmsg IsNot Nothing Then
                        For i As Integer = 0 To pubRuleParserBS.tmsg.Count - 1
                            Dim ReturnCheckingFlag As String = ""
                            Dim token() As String = pubRuleParserBS.tmsg(i).ToString.Trim.Split(";")
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
                        pubRuleParserBS.tmsg.Clear()
                    End If
                End Try
                If DataSetUtil.IsContainsData(PUBRule) Then
                    ExpressionStr = PUBRule.Rows(0).Item("RuleExpStrCht").ToString.Trim
                End If
                Return ProcessFlag
            End If
        Catch ex As Exception
            'log.Error("CallForm(" & RuleCode & ")：" & ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 據RuleCode查詢Phrase_Name
    ''' </summary>
    ''' <param name="OPH_Rule_Reason"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks>20120522 從OPH Copy過來</remarks>
    Public Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ophBo As New OphPhraseBO
            Dim tableName As String = OphPhraseBO.tableName
            Dim ds As DataSet
            If connFlag Then
                conn = ophBo.getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select Phrase_Name " & _
            " From " & tableName & " " & _
            " Where Phrase_Code_Id = @Phrase_Code_Id "
            command.Parameters.AddWithValue("@Phrase_Code_Id", OPH_Rule_Reason)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
End Class
