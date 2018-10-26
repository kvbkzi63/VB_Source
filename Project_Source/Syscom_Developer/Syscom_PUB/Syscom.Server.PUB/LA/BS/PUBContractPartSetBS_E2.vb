Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class PUBContractPartSetBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBContractPartSetBS_E2
    Public Shared Function GetInstance() As PUBContractPartSetBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBContractPartSetBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "20090915 PUBContractPartSetBS 部份負擔基本檔維護, add by Syscom Pearl"
    ''' <summary>
    ''' 確定儲存合約身份部份負擔記帳設定檔
    ''' </summary>
    ''' <param name="saveData">合約身份部份負擔記帳設定檔</param>
    ''' <returns>資料查詢結果</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBContractPart(ByVal saveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim instancePUBContractPartSetBO As New PUBContractPartSetBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PUBContractPartSetBO_E2.tableName
        Dim strContractCode As String
        Dim strSubIdentityCode As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PubContractPartSetBO.GetInstance.getConnection
                    hisConn.Open()
                    strContractCode = saveData.Tables(0).Rows(0)("Contract_Code").ToString
                    strSubIdentityCode = saveData.Tables(0).Rows(0)("Sub_Identity_Code").ToString
                    '先以部份負擔代碼作為條件查詢出所有記錄
                    dsDB = instancePUBContractPartSetBO.queryPUBContractPartSetByCond(System.DateTime.MinValue, strContractCode, strSubIdentityCode, hisConn)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If saveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                saveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBContractPartSetBO.insert(saveData, hisConn)
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
                                    instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                    instancePUBContractPartSetBO.insert(saveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBContractPartSetBO.insert(saveData, hisConn)
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
                                        instancePUBContractPartSetBO.update(saveData, hisConn)
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
                                                    instancePUBContractPartSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                                instancePUBContractPartSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBContractPartSetBO.insert(saveData, hisConn)
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
                                        instancePUBContractPartSetBO.update(saveData, hisConn)
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
                                                    instancePUBContractPartSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                                    saveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(saveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                                instancePUBContractPartSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strContractCode, strSubIdentityCode, hisConn)
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
                                            instancePUBContractPartSetBO.update(dsTemp, hisConn)
                                            instancePUBContractPartSetBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strContractCode, strSubIdentityCode, hisConn)
                                            saveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBContractPartSetBO.insert(saveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '處理完成後再以本部份負擔代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instancePUBContractPartSetBO.queryPUBContractPartSetByCond(System.DateTime.MinValue, strContractCode, strSubIdentityCode, hisConn)
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
End Class
