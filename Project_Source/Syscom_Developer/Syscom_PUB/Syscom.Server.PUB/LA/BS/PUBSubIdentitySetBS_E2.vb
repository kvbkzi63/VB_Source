'/*
'*****************************************************************************
'*
'*    Page/Class Name:  身份二代碼計價設定檔維護
'*              Title:	PUBSubIdentitySetBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-04
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-04
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO



Public Class PUBSubIdentitySetBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBSubIdentitySetBS_E2
    Public Shared Function GetInstance() As PUBSubIdentitySetBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSubIdentitySetBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "

    ''' <summary>
    ''' 確定儲存身份二代碼計價設定檔資料
    ''' </summary>
    ''' <param name="saveData">身份二代碼計價設定檔資料</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBSubIdentitySet(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim strTableName As String = PubSubIdentitySetBO.tableName
        Dim instanceBO As New PUBSubIdentitySetBO_E2
        '生效日
        Dim strEffectDate As String = String.Empty
        '身份二代碼
        Dim strSubIdentityCode As String
        '醫令類型
        Dim strOrderTypeId As String
        '院內費用項目
        Dim strAccountId As String
        '醫令項目代碼
        Dim strOrderCode As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PubSubIdentitySetBO.GetInstance.getConnection
                    hisConn.Open()
                    strSubIdentityCode = saveData.Tables(0).Rows(0)("Sub_Identity_Code").ToString
                    strOrderTypeId = saveData.Tables(0).Rows(0)("Order_Type_Id").ToString
                    strAccountId = saveData.Tables(0).Rows(0)("Account_Id").ToString
                    strOrderCode = saveData.Tables(0).Rows(0)("Order_Code").ToString
                    '先以身份二代碼,醫令類型,院內費用項目,醫令項目代碼作為條件查詢出所有記錄
                    dsDB = instanceBO.queryPUBSubIdentitySetByCond(System.DateTime.MinValue, _
                                                                                    strSubIdentityCode, _
                                                                                    strOrderTypeId, _
                                                                                    strAccountId, _
                                                                                    strOrderCode, hisConn)
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(strTableName).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instanceBO.insert(saveData, hisConn)
                        Else
                            dsTemp = dsDB.Clone
                            '做循環查找DC=N的紀錄
                            For i = 0 To dsDB.Tables(strTableName).Rows.Count - 1
                                If dsDB.Tables(strTableName).Rows(i)("Dc").ToString() = "N" Then
                                    Exit For
                                End If
                            Next
                            If i = dsDB.Tables(strTableName).Rows.Count Then
                                '未找到
                                '判斷DB最後一筆結束日是否大於等於畫面輸入生效日
                                If CDate(dsDB.Tables(strTableName).Rows(i - 1)("End_Date")).ToString("yyyy/MM/dd") >= _
                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                    '先做修改後做新增
                                    dr = dsDB.Tables(strTableName).Rows(i - 1)
                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                    instanceBO.update(dsTemp, hisConn)
                                    instanceBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instanceBO.insert(saveData, hisConn)
                                End If
                            Else
                                '找到
                                '判斷是否是最後一筆紀錄
                                If i = dsDB.Tables(strTableName).Rows.Count - 1 Then
                                    '是
                                    '判斷最後一筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        instanceBO.update(saveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If saveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增
                                                    instanceBO.delete(CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")), _
                                                                                       strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(strTableName).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instanceBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(strTableName).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instanceBO.update(dsTemp, hisConn)
                                                instanceBO.delete(CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")), _
                                                                                   strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(strTableName).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instanceBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instanceBO.insert(saveData, hisConn)
                                    End If
                                Else
                                    '不是
                                    '判斷當前該筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        If saveData.Tables(0).Rows(0)("End_Date").ToString >= _
                                           CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                            saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                        End If
                                        instanceBO.update(saveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If saveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   saveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增
                                                    instanceBO.delete(CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")), _
                                                                      strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(strTableName).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instanceBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(strTableName).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instanceBO.update(dsTemp, hisConn)
                                                instanceBO.delete(CDate(dsDB.Tables(strTableName).Rows(i)("Effect_Date")), _
                                                                  strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                                If saveData.Tables(0).Rows(0)("End_Date").ToString > _
                                                   CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            End If
                                        Else
                                            '否
                                            '先做修改後做刪除再做新增
                                            dr = dsDB.Tables(strTableName).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instanceBO.update(dsTemp, hisConn)
                                            instanceBO.delete(CDate(dsDB.Tables(strTableName).Rows(i + 1)("Effect_Date")), _
                                                              strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instanceBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '處理完成後再以本身份二代碼,醫令類型,院內費用項目,醫令項目代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instanceBO.queryPUBSubIdentitySetByCond(System.DateTime.MinValue, _
                                                                     strSubIdentityCode, strOrderTypeId, strAccountId, strOrderCode, hisConn)
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

#Region "     修改 Method "

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Will,Lin on 2015-09-04</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

