'/*
'*****************************************************************************
'*
'*    Page/Class Name:  合約身份折扣記帳設定檔維護
'*              Title:	PUBContractSetBS_E2
'*        Description:	合約身份折扣記帳設定檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-08-31
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-08-31
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory



Public Class PUBContractSetBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBContractSetBS_E2
    Public Shared Function GetInstance() As PUBContractSetBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBContractSetBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

    ''' <summary>
    ''' 確定儲存合約機構記帳累計資料
    ''' </summary>
    ''' <param name="saveData">合約機構記帳累計檔資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmContractSet(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim instancePUBContractSetBO As New PUBContractSetBO_E2
        Dim instancePUBContractBO As New PUBContractBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PubContractSetBO.tableName
        Dim tablePubContract As String = PubContractBO.tableName
        Dim strContractCode As String
        Dim strOrderTypeId As String
        Dim strAccountId As String
        Dim strOrderCode As String
        Dim strSubIdentityCode As String
        Dim i As Integer

        'PUBContract
        Dim dsPubConAs As New DataSet
        Dim columnNameDB() As String = PubContractDataTableFactory.columnsName
        dsPubConAs.Tables.Add(tablePubContract)
        For j As Integer = 0 To columnNameDB.Length - 1
            dsPubConAs.Tables(tablePubContract).Columns.Add(columnNameDB(j))
        Next


        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Try
                Using hisConn As SqlConnection = PubContractSetBO.GetInstance.getConnection
                    hisConn.Open()
                    strContractCode = saveData.Tables(0).Rows(0)("Contract_Code").ToString
                    strOrderTypeId = saveData.Tables(0).Rows(0)("Order_Type_Id").ToString
                    strAccountId = saveData.Tables(0).Rows(0)("Account_Id").ToString
                    strOrderCode = saveData.Tables(0).Rows(0)("Order_Code").ToString
                    strSubIdentityCode = saveData.Tables(0).Rows(0)("Sub_Identity_Code").ToString
                    '先根據生效日 合約機關代碼 醫令類型 院內費用項目 醫令項目代碼取得所有資料
                    dsDB = instancePUBContractSetBO.queryPUBContractSetByCond(System.DateTime.MinValue, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, True, hisConn)

                    '更新PUB_Contrant
                    Dim drDB As DataRow = dsPubConAs.Tables(tablePubContract).NewRow()
                    '將輸入區資料塞入DB1中
                    drDB("Contract_Code") = strContractCode.ToString.Trim
                    drDB("Sub_Identity_Code") = strSubIdentityCode.ToString.Trim
                    drDB("Is_Use_Set") = "Y"
                    dsPubConAs.Tables(tablePubContract).Rows.Add(drDB)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBContractSetBO.insert(saveData, hisConn)
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
                                '判斷DB最後一筆停止日是否大於等於畫面輸入生效日
                                If CDate(dsDB.Tables(tableDB).Rows(i - 1)("End_Date")).ToString("yyyy/MM/dd") >= _
                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                    '先做修改後做新增
                                    dr = dsDB.Tables(tableDB).Rows(i - 1)
                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                    instancePUBContractSetBO.update(dsTemp, hisConn)
                                    instancePUBContractSetBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBContractSetBO.insert(saveData, hisConn)
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
                                        instancePUBContractSetBO.update(saveData, hisConn)
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
                                                    instancePUBContractSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBContractSetBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBContractSetBO.update(dsTemp, hisConn)
                                                instancePUBContractSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBContractSetBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBContractSetBO.insert(saveData, hisConn)
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
                                        instancePUBContractSetBO.update(saveData, hisConn)
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
                                                    instancePUBContractSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBContractSetBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBContractSetBO.update(dsTemp, hisConn)
                                                instancePUBContractSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
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
                                            instancePUBContractSetBO.update(dsTemp, hisConn)
                                            instancePUBContractSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBContractSetBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If

                    Dim iPUBCon As Integer = 0
                    iPUBCon = instancePUBContractBO.updatePUBContratByCond(dsPubConAs, hisConn)
                    '處理完成後根據生效日 合約機關代碼 醫令類型 院內費用項目 醫令項目代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instancePUBContractSetBO.queryPUBContractSetByCond(System.DateTime.MinValue, strContractCode, strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, True, hisConn)
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

#Region "2011/03/18 門診健檢套餐報價作業 加作折扣設定頁籤-存檔 add by mark zhang"
    ''' <summary>
    ''' 門診健檢套餐報價作業 加作折扣設定頁籤-存檔
    ''' </summary>
    ''' <param name="saveData">存檔資料</param>
    ''' <param name="strEffectDate">有效起日</param>
    ''' <param name="strContractCode">合約機構</param>
    ''' <param name="strSubIdentityCode">第二身分</param>
    ''' <param name="strOrderCode">套餐的批價代碼</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function insertPUBContractSetByCond(ByVal saveData As DataSet, _
                                               ByVal strEffectDate As String, _
                                               ByVal strContractCode As String, _
                                               ByVal strSubIdentityCode As String, _
                                               ByVal strOrderCode As String) As Integer
        Dim dsDB As DataSet
        Dim instancePUBContractSetBO As New PUBContractSetBO_E2
        Dim iCnt As Integer

        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PubContractSetBO.GetInstance.getConnection
                    hisConn.Open()
                    dsDB = instancePUBContractSetBO.queryPUBContractSet(strEffectDate, strContractCode, strSubIdentityCode, strOrderCode, hisConn)
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(0).Rows(0)("count").ToString.Trim > 0 Then
                            instancePUBContractSetBO.deletePubContractSet3(strEffectDate, strContractCode, strSubIdentityCode, strOrderCode, hisConn)
                        End If
                    End If

                    iCnt = instancePUBContractSetBO.insert(saveData, hisConn)
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
        Return iCnt
    End Function
#End Region

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Will.Lin on 2015-08-31</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

