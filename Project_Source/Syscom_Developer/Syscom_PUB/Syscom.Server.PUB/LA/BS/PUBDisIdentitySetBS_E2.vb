﻿'/*
'*****************************************************************************
'*
'*    Page/Class Name:  優待身份折扣設定檔
'*              Title:	PUBDisIdentitySetBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-11
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-11
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO



Public Class PUBDisIdentitySetBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBDisIdentitySetBS_E2
    Public Shared Function GetInstance() As PUBDisIdentitySetBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDisIdentitySetBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "

#Region "2009 PUBPatientQuotaBS 病患合約機構記帳累積檔, add by tony"
    ''' <summary>
    ''' 確定儲存病患合約機構記帳累積檔資料
    ''' </summary>
    ''' <param name="saveData">病患合約機構記帳累積檔資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBDisIdentitySet(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        'Dim instancePUBPartBO As New PUBPartBO
        Dim instancePUBDisIdentitySetBO As New PUBDisIdentitySetBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PubDisIdentitySetBO.tableName
        Dim strDisIdentityCode As String
        Dim strOrderTypeId As String
        Dim strAccountId As String
        Dim strOrderCode As String
        Dim strSubIdentityCode As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PubDisIdentitySetBO.GetInstance.getConnection
                    hisConn.Open()
                    strDisIdentityCode = saveData.Tables(0).Rows(0)("Dis_Identity_Code").ToString
                    strOrderTypeId = saveData.Tables(0).Rows(0)("Order_Type_Id").ToString
                    strAccountId = saveData.Tables(0).Rows(0)("Account_Id").ToString
                    strOrderCode = saveData.Tables(0).Rows(0)("Order_Code").ToString
                    strSubIdentityCode = saveData.Tables(0).Rows(0)("Sub_Identity_Code").ToString
                    dsDB = instancePUBDisIdentitySetBO.queryPUBDisIdentitySetByCond(System.DateTime.MinValue, strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn).Copy
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBDisIdentitySetBO.insert(saveData, hisConn)
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
                                    instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                    instancePUBDisIdentitySetBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBDisIdentitySetBO.insert(saveData, hisConn)
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
                                        instancePUBDisIdentitySetBO.update(saveData, hisConn)
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
                                                    instancePUBDisIdentitySetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                                instancePUBDisIdentitySetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBDisIdentitySetBO.insert(saveData, hisConn)
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
                                        instancePUBDisIdentitySetBO.update(saveData, hisConn)
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
                                                    instancePUBDisIdentitySetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                                instancePUBDisIdentitySetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
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
                                            instancePUBDisIdentitySetBO.update(dsTemp, hisConn)
                                            instancePUBDisIdentitySetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBDisIdentitySetBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '
                    dsReturn = instancePUBDisIdentitySetBO.queryPUBDisIdentitySetByCond(System.DateTime.MinValue, strSubIdentityCode, strDisIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
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

#End Region

End Class

