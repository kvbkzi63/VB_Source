'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBInsuCodeBS_E2.vb
'*              Title:	醫令項目代碼對應健保碼
'*        Description:	醫令項目代碼對應健保碼
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2010/06/03
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions
Imports log4net
Imports Syscom.Comm.EXP


Public Class PUBInsuCodeBS_E2

    Private Shared myInstance As PUBInsuCodeBS_E2

    Public Overloads Function getInstance() As PUBInsuCodeBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBInsuCodeBS_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    ''' 確定儲存
    ''' </summary>
    ''' <param name="saveData">資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBInsuCode(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim instancePUBInsuCodeBO As New PUBInsuCodeBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PUBInsuCodeBO_E2.tableName
        Dim strOrderCode As String
        Dim i As Integer

        '交易保護開始
        Using ts As TransactionScope = Nothing
            Try
                Using hisConn As SqlConnection = PUBInsuCodeBO_E2.GetInstance.getConnection
                    hisConn.Open()
                    strOrderCode = saveData.Tables(0).Rows(0)("Order_Code").ToString
                    '先以部份負擔代碼作為條件查詢出所有記錄
                    dsDB = instancePUBInsuCodeBO.queryPubInsuCode2(strOrderCode, hisConn)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                'saveData.Tables(0).Rows(0)("Dc") = "Y"
                                For Each drTemp As DataRow In saveData.Tables(0).Rows
                                    drTemp.Item("Dc") = "Y"
                                Next
                            End If
                            instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
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
                                    '添加新的方法
                                    instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                    instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
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
                                        'instancePUBInsuCodeBO.deletePubInsuCode(saveData, hisConn)
                                        'instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
                                        instancePUBInsuCodeBO.update(saveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If saveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    ''是
                                                    ''先做刪除後做新增
                                                    ''instancePUBInsuCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strOrderCode, hisConn)
                                                    instancePUBInsuCodeBO.deletePubInsuCode(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd"), dsDB.Tables(tableDB).Rows(i)("Order_Code").ToString, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    For Each drTemp As DataRow In dsDB.Tables(0).Rows
                                                        If drTemp.Item("Effect_Date") = CDate(dsDB.Tables(tableDB).Rows(i).Item("Effect_Date")) Then
                                                            drTemp.Item("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                            drTemp.Item("Dc") = "Y"
                                                            dsTemp.Tables(0).Rows.Add(drTemp.ItemArray)
                                                        End If
                                                    Next
                                                    'dr = dsDB.Tables(tableDB).Rows(i)
                                                    'dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    'dr("Dc") = "Y"
                                                    'dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                                instancePUBInsuCodeBO.deletePubInsuCode(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strOrderCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                            'saveData.Tables(0).Rows(0)("Dc") = "Y"
                                            For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                drTemp.Item("Dc") = "Y"
                                            Next
                                        End If
                                        instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
                                    End If
                                Else
                                    '不是
                                    '判斷當前該筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        ''直接做修改
                                        If saveData.Tables(0).Rows(0)("End_Date").ToString >= _
                                           CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                            'saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                            For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                drTemp.Item("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                            Next
                                        End If
                                        'instancePUBInsuCodeBO.deletePubInsuCode(saveData, hisConn)
                                        'instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
                                        instancePUBInsuCodeBO.update(saveData, hisConn)
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
                                                    instancePUBInsuCodeBO.deletePubInsuCode(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strOrderCode, hisConn)
                                                    For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                        drTemp.Item("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                    Next
                                                    'saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    For Each drTemp As DataRow In dsDB.Tables(0).Rows
                                                        If drTemp.Item("Effect_Date") = dsDB.Tables(tableDB).Rows(i).Item("Effect_Date") Then
                                                            drTemp.Item("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                            drTemp.Item("Dc") = "Y"
                                                            dsTemp.Tables(0).Rows.Add(drTemp.ItemArray)
                                                        End If
                                                    Next
                                                    instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                                    For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                        drTemp.Item("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                    Next
                                                    'dr = dsDB.Tables(tableDB).Rows(i)
                                                    'dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    'dr("Dc") = "Y"
                                                    'dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    'instancePUBInsuCodeBO.update(dsTemp, hisConn)
                                                    'saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                For Each drTemp As DataRow In dsDB.Tables(0).Rows
                                                    If drTemp.Item("Effect_Date") = dsDB.Tables(tableDB).Rows(i - 1).Item("Effect_Date") Then
                                                        drTemp.Item("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                        drTemp.Item("Dc") = "Y"
                                                        dsTemp.Tables(0).Rows.Add(drTemp.ItemArray)
                                                    End If
                                                Next
                                                'dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                'dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                'dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                                instancePUBInsuCodeBO.deletePubInsuCode(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strOrderCode, hisConn)
                                                'instancePUBInsuCodeBO.update(dsTemp, hisConn)
                                                'instancePUBInsuCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strOrderCode, hisConn)
                                                If saveData.Tables(0).Rows(0)("End_Date").ToString > _
                                                   CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                                    ' saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                    For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                        drTemp.Item("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                    Next
                                                End If
                                            End If
                                        Else
                                            '否
                                            '先做修改後做刪除再做新增

                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)

                                            'instancePUBInsuCodeBO.update(dsTemp, hisConn)
                                            'instancePUBInsuCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strOrderCode, hisConn)
                                            instancePUBInsuCodeBO.updatePUBInsuCodeByEffectDate(dsTemp, hisConn)
                                            instancePUBInsuCodeBO.deletePubInsuCode(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strOrderCode, hisConn)
                                            'saveData.Tables(0).Rows(0)("Dc") = "Y"
                                            For Each drTemp As DataRow In saveData.Tables(0).Rows
                                                drTemp.Item("Dc") = "Y"
                                            Next
                                        End If
                                        instancePUBInsuCodeBO.insertPUBInsuCode(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '處理完成後再以本部份負擔代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instancePUBInsuCodeBO.queryPubInsuCode("", strOrderCode, hisConn)
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


End Class
