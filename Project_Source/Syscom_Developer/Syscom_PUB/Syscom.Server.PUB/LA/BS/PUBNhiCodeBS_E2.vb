'/*
'*****************************************************************************
'*
'*    Page/Class Name:  健保支付標準檔
'*              Title:	PUBNhiCodeBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-15
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-15
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP



Public Class PUBNhiCodeBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBNhiCodeBS_E2
    Public Shared Function GetInstance() As PUBNhiCodeBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBNhiCodeBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "20100603 確定"

    ''' <summary>
    ''' 確定儲存健保部份負擔資料
    ''' </summary>
    ''' <param name="saveData">部份負擔基本檔資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBNhiCode(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim instancePUBNhiCodeBO As New PUBNhiCodeBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PubNhiCodeBO.tableName
        Dim strNhiCode As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Try
                Using hisConn As SqlConnection = PubNhiCodeBO.GetInstance.getConnection
                    hisConn.Open()
                    strNhiCode = saveData.Tables(0).Rows(0)("Insu_Code").ToString
                    strEffectDate = saveData.Tables(0).Rows(0)("Effect_Date").ToString 'Effect_Date
                    '先以部份負擔代碼作為條件查詢出所有記錄
                    dsDB = instancePUBNhiCodeBO.queryPUBNhiCodeDateByCond(System.DateTime.MinValue, strNhiCode, hisConn)
                    'dsDB = instancePUBNhiCodeBO.queryPUBNhiCodeDateByCond("", strNhiCode, hisConn)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBNhiCodeBO.insert(saveData, hisConn)
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
                                    instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                    instancePUBNhiCodeBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBNhiCodeBO.insert(saveData, hisConn)
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
                                        instancePUBNhiCodeBO.update(saveData, hisConn)
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
                                                    instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                'dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                '20110421 add by yunfei
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd").Trim > saveData.Tables(0).Rows(0)("Effect_Date").ToString.Trim Then
                                                    dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                    For j As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                                                        If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd").Trim > saveData.Tables(0).Rows(0)("Effect_Date").ToString.Trim And _
                                                        CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd").Trim <= Now.ToString("yyyy/MM/dd") Then
                                                            instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)
                                                        End If
                                                    Next
                                                Else
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                End If
                                                dr("Dc") = "Y"
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                                '2010421 add by yunfei
                                                'instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBNhiCodeBO.insert(saveData, hisConn)
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
                                        instancePUBNhiCodeBO.update(saveData, hisConn)
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
                                                    instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                '20110421 UPDATE BY YUNFEI
                                                'dr = dsDB.Tables(tableDB).Rows(i - 1)

                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd").Trim > saveData.Tables(0).Rows(0)("Effect_Date").ToString.Trim Then
                                                    dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                    instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)

                                                Else
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                End If

                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                '20110421 ADD BY YUNFEI
                                                dr("Dc") = "Y"

                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                                '20110421 DELETE BY YUNFEI
                                                'instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strNhiCode, hisConn)

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
                                            instancePUBNhiCodeBO.update(dsTemp, hisConn)
                                            instancePUBNhiCodeBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strNhiCode, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBNhiCodeBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '處理完成後再以本部份負擔代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instancePUBNhiCodeBO.queryPUBNhiCodeDateByCond(System.DateTime.MinValue, strNhiCode, hisConn)
                    'dsReturn = instancePUBNhiCodeBO.queryPUBNhiCodeDateByCond("", strNhiCode, hisConn)
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

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Will,Lin on 2015-09-15</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

