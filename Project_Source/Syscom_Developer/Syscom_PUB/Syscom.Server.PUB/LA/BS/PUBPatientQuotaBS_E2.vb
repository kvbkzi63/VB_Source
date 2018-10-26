'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患合約機構記帳累積檔
'*              Title:	PUBPatientQuotaBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-08
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-08
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO



Public Class PUBPatientQuotaBS_E2
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientQuotaBS_E2
    Public Shared Function GetInstance() As PUBPatientQuotaBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientQuotaBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     確認 Method "
#Region "2009 PUBPatientQuotaBS 病患合約機構記帳累積檔, add by tony"
    ''' <summary>
    ''' 確定儲存病患合約機構記帳累積檔資料
    ''' </summary>
    ''' <param name="saveData">病患合約機構記帳累積檔資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBPatientQuota(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        'Dim instancePUBPartBO As New PUBPartBO
        Dim instancePUBPatientQuotaBO As New PUBPatientQuotaBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PubPatientQuotaBO.tableName
        Dim strContractCode As String
        Dim strChartNo As String
        Dim strSubIdentityCode As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Try
                Using hisConn As SqlConnection = PubPatientQuotaBO.GetInstance.getConnection
                    hisConn.Open()
                    strContractCode = saveData.Tables(0).Rows(0)("Contract_Code").ToString
                    strChartNo = saveData.Tables(0).Rows(0)("Chart_No").ToString
                    strSubIdentityCode = saveData.Tables(0).Rows(0)("Sub_Identity_Code").ToString
                    '
                    dsDB = instancePUBPatientQuotaBO.queryPUBPatientQuotaByCond(System.DateTime.MinValue, strContractCode, strChartNo, strSubIdentityCode, hisConn)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBPatientQuotaBO.insert(saveData, hisConn)
                        Else
                            dsTemp = dsDB.Clone
                            '做循環查找DC=N的紀錄
                            For i = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                                If dsDB.Tables(tableDB).Rows(i)("Dc").ToString() = "N" Then
                                    Exit For
                                End If
                            Next
                            If i = dsDB.Tables(tableDB).Rows.Count Then
                                '未找到
                                '判斷DB最後一筆結束日是否大於等於畫面輸入生效日
                                If CDate(dsDB.Tables(tableDB).Rows(i - 1)("End_Date")).ToString("yyyy/MM/dd") >= _
                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                    '先做修改後做新增
                                    dr = dsDB.Tables(tableDB).Rows(i - 1)
                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                    instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                    instancePUBPatientQuotaBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBPatientQuotaBO.insert(saveData, hisConn)
                                End If
                            Else
                                '找到
                                '判斷是否是最後一筆紀錄
                                If i = dsDB.Tables(tableDB).Rows.Count - 1 Then
                                    '是
                                    '判斷最後一筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        instancePUBPatientQuotaBO.update(saveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If saveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增 
                                                    instancePUBPatientQuotaBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strChartNo, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                                instancePUBPatientQuotaBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strChartNo, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBPatientQuotaBO.insert(saveData, hisConn)
                                    End If
                                Else
                                    '不是
                                    '判斷當前該筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        If saveData.Tables(0).Rows(0)("End_Date").ToString >= _
                                           CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                            saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                        End If
                                        instancePUBPatientQuotaBO.update(saveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If saveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增 
                                                    instancePUBPatientQuotaBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strChartNo, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                                instancePUBPatientQuotaBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strChartNo, hisConn)
                                                If saveData.Tables(0).Rows(0)("End_Date").ToString > _
                                                   CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            End If
                                        Else
                                            '否
                                            '先做修改後做刪除再做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBPatientQuotaBO.update(dsTemp, hisConn)
                                            instancePUBPatientQuotaBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strContractCode, strSubIdentityCode, strChartNo, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBPatientQuotaBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '
                    dsReturn = instancePUBPatientQuotaBO.queryPUBPatientQuotaByCond(System.DateTime.MinValue, strContractCode, strChartNo, strSubIdentityCode, hisConn)
                    hisConn.Close()
                End Using
                '提交保護
                ts.Complete()
            Catch commEx As CommonException
                ts.Dispose()
                Throw commEx
            Catch ex As Exception
                ts.Dispose()
                Throw ex
            End Try
        End Using
        Return dsReturn
    End Function
#End Region
#Region "20101014 for PIPWriteQSPatientQuota  add by liuye"
    Function insertPUBPatientQuotaforPIPQS(ByVal dsDB As DataSet, ByVal dtOrderRecord As DataTable, ByRef strReturn As String) As String
        Dim icount As Integer = 0
        Dim arrMessgae As String = ""

        If dsDB.Tables.Count > 0 AndAlso dsDB.Tables(0).Rows.Count > 0 Then
            '交易保護開始

            'Using ts As TransactionScope = New TransactionScope()
            Try
                Dim pubinstance As New PUBPatientQuotaBO_E2
                'Using hisConn As SqlConnection = PubPatientQuotaBO.GetInstance.getConnection 'getAuthenticConnection
                '    hisConn.Open()
                For j As Integer = 0 To dsDB.Tables(0).Rows.Count - 1

                    'If dsDB.Tables.Count > 0 AndAlso dsDB.Tables(0).Rows.Count > 0 Then
                    '第二身分(SubIdentity)為’31’時，一週補助500元，其他身分一週補助250元
                    Dim perprice As Integer = IIf(dsDB.Tables(0).Rows(j)("Sub_Identity_Code").ToString.Trim = "33", 500, 250)

                    If dtOrderRecord.Rows.Count > 0 Then
                        'Mark By Will
                        'Dim pipinstance As New PipPrjDrugBO_E2
                        Dim strVisitDate As String = ChangeDateFormat(dsDB.Tables(0).Rows(j)("Effect_Date").ToString.Trim)
                        Dim strChartNoq As String = dsDB.Tables(0).Rows(j)("Chart_No").ToString.Trim
                        Dim strSubIdentityCode0 As String = dtOrderRecord.Rows(0)("SubIdentity").ToString.Trim
                        Dim strsubIcode As String = dsDB.Tables(0).Rows(j)("Sub_Identity_Code").ToString.Trim
                        '先計算歷史額度是否還可以繼續補助的週數
                        Dim maxweekCount As Integer = 2
                        Dim strStage As String = ""
                        Dim pubpatientQuotabo As New PUBPatientQuotaBO_E2
                        Dim dsAmt As DataSet = pubpatientQuotabo.queryPUBPatientQuotaQuotaAmt(strChartNoq, strVisitDate, strsubIcode) ', hisConn)

                        If dsAmt.Tables.Count > 0 Then
                            If dsAmt.Tables(2).Rows.Count = 0 Then
                                arrMessgae = "今年戒菸療程補助已到期，本次戒菸無任何金額補助。" & vbCrLf
                                strReturn = "A99|"
                                Return arrMessgae
                            End If

                            If dsAmt.Tables(0).Rows.Count > 0 Then
                                If dsAmt.Tables(0).Rows(0)("Quota_Amt_Sum").ToString.Trim <> "" Then
                                    Dim count As Integer = 0
                                    If CDec(dsAmt.Tables(0).Rows(0)("Quota_Amt_Sum").ToString.Trim) Mod perprice = 0 Then
                                        count = 8 - CDec(dsAmt.Tables(0).Rows(0)("Quota_Amt_Sum").ToString.Trim) / perprice
                                    Else
                                        count = 7 - (CDec(dsAmt.Tables(0).Rows(0)("Quota_Amt_Sum").ToString.Trim) \ perprice)
                                    End If
                                    If count > 0 AndAlso count <= 2 Then
                                        maxweekCount = count
                                        strStage = dsAmt.Tables(0).Rows(0)("Case_Apply_Stage").ToString.Trim
                                    ElseIf count <= 0 Then
                                        '>8週
                                        arrMessgae = "今年戒菸療程補助已到期，本次戒菸無任何金額補助。" & vbCrLf
                                        strReturn = "A99|"
                                        Return arrMessgae
                                    End If
                                End If
                            End If
                            '當該病歷號在PIP_Case_Main中未結案紀錄(只會有一筆)的收案日(含當日)後最接近本次VisitDate 的紀錄，當PUB_Patient_Quota該筆紀錄中的Effect_Date距
                            '本次VisitDate小於6天時：顯示「距離前次戒菸就醫日(YYYY/MM/DD)未超過6天，本次戒菸無法補助，或建議醫師調整使用天數。」
                            If dsAmt.Tables(1) IsNot Nothing AndAlso dsAmt.Tables(1).Rows.Count > 0 Then
                                If dsAmt.Tables(1).Rows(0)("mindays").ToString.Trim <> "" Then
                                    If CInt(dsAmt.Tables(1).Rows(0)("mindays").ToString.Trim) < 6 Then
                                        Dim strdate As String = CDate(dsAmt.Tables(1).Rows(0)("Effect_Date").ToString.Trim).ToString("yyyy/MM/dd")
                                        arrMessgae = "距離前次戒菸就醫日(" & strdate & ")未超過6天，本次戒菸無法補助，或建議醫師調整使用天數。" & vbCrLf
                                        strReturn = "A98|"
                                        Return arrMessgae
                                    End If
                                End If
                            End If
                        End If
                        '計算補助額度
                        'Mark By Will
                        ' Dim dsOrderCode As DataSet = pipinstance.QueryPipPrjDrugBOE2OrderCode("QS", strVisitDate) ', hisConn)

                        'If dsOrderCode.Tables.Count > 0 AndAlso dsOrderCode.Tables(0).Rows.Count > 0 Then
                        '    Dim strOrderCodes As String = ""
                        '    For i As Integer = 0 To dsOrderCode.Tables(0).Rows.Count - 1
                        '        If i = 0 Then
                        '            strOrderCodes = strOrderCodes & "'" & dsOrderCode.Tables(0).Rows(i)("Drug_Order_Code").ToString.Trim & "'"
                        '        Else
                        '            strOrderCodes = strOrderCodes & "," & "'" & dsOrderCode.Tables(0).Rows(i)("Drug_Order_Code").ToString.Trim & "'"
                        '        End If
                        '    Next
                        '    Dim strselect As String = "(Dc<>'Y' or Dc is Null) and (Cancel<>'Y' or Cancel is Null) and (Is_Force <>'Y' or Is_Force is Null)  and Order_Code in (" & strOrderCodes & ") "
                        '    Dim strSort As String = "Order_Effect_Date Asc "
                        '    Dim dr() As DataRow = dtOrderRecord.Select(strselect, strSort)

                        '    If dr.Count > 0 Then
                        '        Dim QuotaAmt As Integer = 0
                        '        If dr.Count = 1 Then
                        '            If dr(0)("Order_Effect_Date").ToString.Trim <> "" AndAlso dr(0)("Order_End_Date").ToString.Trim <> "" Then
                        '                Dim weekcount As Integer = 0 ' CInt((DateDiff(DateInterval.Day, CDate(ChangeDateFormat(dr(0)("Order_Effect_Date").ToString.Trim)), CDate(ChangeDateFormat(dr(0)("Order_End_Date").ToString.Trim))) + 1) / 7)
                        '                Dim intdiff As Integer = (DateDiff(DateInterval.Day, CDate(ChangeDateFormat(dr(0)("Order_Effect_Date").ToString.Trim)), CDate(ChangeDateFormat(dr(0)("Order_End_Date").ToString.Trim))) + 1)
                        '                If intdiff Mod 7 = 0 Then
                        '                    weekcount = intdiff / 7
                        '                Else
                        '                    weekcount = (intdiff \ 7) + 1
                        '                End If
                        '                If weekcount > 2 Then
                        '                    '1.	當次服藥日期大於2週時：顯示「本次戒菸藥物已超過單次補助天數上限(14天)，本次僅補助此上限金額，或建議醫師調整使用天數。」
                        '                    If maxweekCount = 2 Then
                        '                        arrMessgae = "本次戒菸藥物已超過單次補助天數上限(14天)，本次僅補助此上限金額，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = 2 * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A77|+002312;+007022;+002322;"
                        '                            ' getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A77|+002312;+007022;+002314;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    ElseIf maxweekCount < 2 Then
                        '                        arrMessgae = "今年(第" & strStage & "次)戒菸療程補助金額僅剩" & maxweekCount & "週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = maxweekCount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A88|+002312;+007021;+002321;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A88|+002312;+007021;+002313;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    End If
                        '                Else
                        '                    If weekcount > maxweekCount Then
                        '                        '2.	當次剩餘額度不足補助當次服藥使用週數時：顯示「今年(第XX次)戒菸療程補助金額僅剩YY週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。」
                        '                        arrMessgae = "今年(第" & strStage & "次)戒菸療程補助金額僅剩" & maxweekCount & "週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = maxweekCount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A88|+002312;+007021;+002321;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A88|+002312;+007021;+002313;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    Else
                        '                        QuotaAmt = weekcount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            If weekcount = 1 Then
                        '                                strReturn = "A00|+002312;+007021;+002321;"
                        '                                ' getStrValue(dtOrderRecord, strReturn)
                        '                            Else
                        '                                strReturn = "A00|+002312;+007022;+002322;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            End If
                        '                        Else
                        '                            If weekcount = 1 Then
                        '                                strReturn = "A00|+002312;+007021;+002313;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            Else
                        '                                strReturn = "A00|+002312;+007022;+002314;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            End If
                        '                        End If
                        '                    End If
                        '                End If
                        '                'QuotaAmt = IIf(weekcount < 8, weekcount * perprice, 2000)
                        '            End If
                        '        Else
                        '            Dim maxDate As String = ChangeDateFormat(dr(dr.Count - 1)("Order_End_Date").ToString.Trim)
                        '            Dim intdays As Integer = 0
                        '            For i As Integer = 0 To dr.Count - 2
                        '                If dr(i)("Order_End_Date").ToString.Trim <> "" And dr(i + 1)("Order_Effect_Date").ToString.Trim <> "" Then
                        '                    If DateDiff(DateInterval.Day, CDate(ChangeDateFormat(dr(i)("Order_End_Date").ToString.Trim)), CDate(ChangeDateFormat(dr(i + 1)("Order_Effect_Date").ToString.Trim))) > 1 Then
                        '                        intdays = intdays + DateDiff(DateInterval.Day, CDate(dr(i)("Order_End_Date").ToString.Trim), CDate(dr(i + 1)("Order_Effect_Date").ToString.Trim)) - 1
                        '                    End If
                        '                End If
                        '                If dr(i)("Order_End_Date").ToString.Trim <> "" Then
                        '                    If maxDate < ChangeDateFormat(dr(i)("Order_End_Date").ToString.Trim) Then
                        '                        maxDate = ChangeDateFormat(dr(i)("Order_End_Date").ToString.Trim)
                        '                    End If
                        '                End If
                        '            Next
                        '            If maxDate <> "" AndAlso dr(0)("Order_Effect_Date").ToString.Trim <> "" Then
                        '                Dim weekcount As Integer = 0
                        '                Dim intdiff As Integer = (DateDiff(DateInterval.Day, CDate(ChangeDateFormat(dr(0)("Order_Effect_Date").ToString.Trim)), CDate(maxDate)) + 1 - intdays)
                        '                If intdiff Mod 7 = 0 Then
                        '                    weekcount = intdiff / 7
                        '                Else
                        '                    weekcount = (intdiff \ 7) + 1
                        '                End If
                        '                ' CInt((DateDiff(DateInterval.Day, CDate(ChangeDateFormat(dr(0)("Order_Effect_Date").ToString.Trim)), CDate(maxDate)) + 1 - intdays) / 7)
                        '                If weekcount > 2 Then
                        '                    '1.	當次服藥日期大於2週時：顯示「本次戒菸藥物已超過單次補助天數上限(14天)，本次僅補助此上限金額，或建議醫師調整使用天數。」
                        '                    If maxweekCount = 2 Then
                        '                        arrMessgae = "本次戒菸藥物已超過單次補助天數上限(14天)，本次僅補助此上限金額，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = 2 * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A77|+002312;+007022;+002322;"
                        '                            ' getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A77|+002312;+007022;+002314;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    ElseIf maxweekCount < 2 Then
                        '                        '2.	當次剩餘額度不足補助當次服藥使用週數時：顯示「今年(第XX次)戒菸療程補助金額僅剩YY週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。」
                        '                        arrMessgae = "今年(第" & strStage & "次)戒菸療程補助金額僅剩" & maxweekCount & "週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = maxweekCount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A88|+002312;+007021;+002321;"
                        '                            ' getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A88|+002312;+007021;+002313;"
                        '                            ' getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    End If
                        '                Else
                        '                    If weekcount > maxweekCount Then
                        '                        '2.	當次剩餘額度不足補助當次服藥使用週數時：顯示「今年(第XX次)戒菸療程補助金額僅剩YY週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。」
                        '                        arrMessgae = "今年(第" & strStage & "次)戒菸療程補助金額僅剩" & maxweekCount & "週，本次僅以該剩餘金額補助，或建議醫師調整使用天數。" & vbCrLf
                        '                        QuotaAmt = maxweekCount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            strReturn = "A88|+002312;+007021;+002321;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        Else
                        '                            strReturn = "A88|+002312;+007021;+002313;"
                        '                            'getStrValue(dtOrderRecord, strReturn)
                        '                        End If
                        '                    Else
                        '                        QuotaAmt = weekcount * perprice
                        '                        If strSubIdentityCode0 = "33" Then
                        '                            If weekcount = 1 Then
                        '                                strReturn = "A00|+002312;+007021;+002321;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            Else
                        '                                strReturn = "A00|+002312;+007022;+002322;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            End If
                        '                        Else
                        '                            If weekcount = 1 Then
                        '                                strReturn = "A00|+002312;+007021;+002313;"
                        '                                ' getStrValue(dtOrderRecord, strReturn)
                        '                            Else
                        '                                strReturn = "A00|+002312;+007022;+002314;"
                        '                                'getStrValue(dtOrderRecord, strReturn)
                        '                            End If
                        '                        End If
                        '                    End If
                        '                End If
                        '                'QuotaAmt = IIf(weekcount < 8, weekcount * perprice, 2000)
                        '            End If
                        '        End If
                        '        If QuotaAmt <> 0 Then
                        '            dsDB.Tables(0).Rows(j)("Quota_Amt") = QuotaAmt
                        '        End If
                        '    End If
                        'End If
                    End If
                Next
                ' hisConn.Close()
                'End Using
                Dim tOpt As TransactionOptions = New TransactionOptions()

                'tOpt.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                'tOpt.Timeout = New TimeSpan(0, 0, 60)
                Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiresNewTransactionScope()
                    Try
                        Using connpub As SqlConnection = PubPatientQuotaBO.GetInstance.getAuthenticConnection
                            connpub.Open()
                            For k As Integer = 0 To dsDB.Tables(0).Rows.Count - 1
                                Dim strEffectDate As String = dsDB.Tables(0).Rows(k)("Effect_Date").ToString.Trim
                                Dim strContractCode As String = dsDB.Tables(0).Rows(k)("Contract_Code").ToString.Trim
                                Dim strSubIdentityCode As String = dsDB.Tables(0).Rows(k)("Sub_Identity_Code").ToString.Trim
                                Dim strChartNo As String = dsDB.Tables(0).Rows(k)("Chart_No").ToString.Trim
                                Try
                                    icount = pubinstance.delete(strEffectDate, strContractCode, strSubIdentityCode, strChartNo, connpub)
                                Catch ex As Exception

                                End Try
                            Next
                            icount = icount + pubinstance.insert(dsDB, connpub)
                            connpub.Close()
                        End Using

                        'Dim connpub As SqlConnection = PubPatientQuotaBO.GetInstance.getAuthenticConnection
                        ' connpub.Open()

                        'connpub.Close()

                        'End If
                        ts.Complete()
                    Catch commEx As CommonException
                        ts.Dispose()
                        Throw commEx
                    Catch ex As Exception
                        ts.Dispose()
                        Throw ex
                    End Try
                End Using
            Catch ex2 As Exception
                Throw ex2
            End Try
        End If

        Return arrMessgae
    End Function
    Function ChangeDateFormat(ByVal strdate As String) As String
        Dim strreturn As String = ""
        If strdate <> "" Then
            strreturn = CDate(strdate).ToString("yyyy/MM/dd")
        End If
        Return strreturn
    End Function

#End Region
#End Region

End Class

