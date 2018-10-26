'/*
'*****************************************************************************
'*
'*    Page/Class Name:  加收部分負擔基本檔
'*              Title:	PUBAddPartBS_E2
'*        Description:	加收部分負擔基本檔
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



Public Class PUBAddPartBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBAddPartBS_E2
    Public Shared Function GetInstance() As PUBAddPartBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBAddPartBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

    ''' <summary>
    ''' 確定加收部分負擔基本檔資料
    ''' </summary>
    ''' <param name="dsSaveData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function confirmPUBAddPart(ByVal dsSaveData As DataSet) As DataSet
        Dim dsDB As DataSet
        Dim dsReturn As DataSet
        Dim dsTemp As New DataSet
        Dim dr As DataRow
        Dim instancePUBAddPartBO As New PUBAddPartBO_E2
        Dim strEffectDate As String = String.Empty
        Dim tableDB As String = PubAddPartBO.tableName
        Dim strPartTypeId As String
        Dim i As Integer
        '交易保護開始
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PubAddPartBO.GetInstance.getConnection
                    hisConn.Open()
                    strPartTypeId = dsSaveData.Tables(0).Rows(0)("Part_Type_Id").ToString
                    '先以部份負擔代碼作為條件查詢出所有記錄
                    dsDB = instancePUBAddPartBO.queryPUBAddPartByCond(System.DateTime.MinValue, strPartTypeId, hisConn)

                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(tableDB).Rows.Count = 0 Then
                            '直接做新增
                            If dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString > Now.ToString("yyyy/MM/dd") Then
                                dsSaveData.Tables(0).Rows(0)("Dc") = "Y"
                            End If
                            instancePUBAddPartBO.insertPUBAddPart(dsSaveData, hisConn)
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
                                   dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                    '先做修改後做新增
                                    dr = dsDB.Tables(tableDB).Rows(i - 1)
                                    dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                    instancePUBAddPartBO.update(dsTemp, hisConn)
                                    instancePUBAddPartBO.insertPUBAddPart(dsSaveData, hisConn)
                                Else
                                    '直接做新增
                                    instancePUBAddPartBO.insertPUBAddPart(dsSaveData, hisConn)
                                End If
                            Else
                                '找到
                                '判斷是否是最後一筆紀錄
                                If i = dsDB.Tables(tableDB).Rows.Count - 1 Then
                                    '是
                                    '判斷最後一筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        instancePUBAddPartBO.update(dsSaveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增
                                                    instancePUBAddPartBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strPartTypeId, dsDB.Tables(tableDB).Rows(i)("Add_Part_No"), hisConn)
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBAddPartBO.update(dsTemp, hisConn)
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBAddPartBO.update(dsTemp, hisConn)
                                                instancePUBAddPartBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strPartTypeId, dsDB.Tables(tableDB).Rows(i)("Add_Part_No"), hisConn)
                                            End If
                                        Else
                                            '否
                                            '先做修改後做新增 
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBAddPartBO.update(dsTemp, hisConn)
                                            dsSaveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If
                                        instancePUBAddPartBO.insertPUBAddPart(dsSaveData, hisConn)
                                    End If
                                Else
                                    '不是
                                    '判斷當前該筆DB生效日是否等於畫面輸入生效日
                                    If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") = _
                                       dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                        '是
                                        '直接做修改
                                        If dsSaveData.Tables(0).Rows(0)("End_Date").ToString >= _
                                           CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                            dsSaveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                        End If
                                        instancePUBAddPartBO.update(dsSaveData, hisConn)
                                    Else
                                        '判斷畫面輸入生效日是否小於等於今天
                                        If dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString <= Now.ToString("yyyy/MM/dd") Then
                                            '是
                                            If i = 0 Then
                                                '判斷畫面輸入生效日是否小於DB生效日
                                                If CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd") > _
                                                   dsSaveData.Tables(0).Rows(0)("Effect_Date").ToString Then
                                                    '是
                                                    '先做刪除後做新增
                                                    instancePUBAddPartBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strPartTypeId, dsDB.Tables(tableDB).Rows(i)("Add_Part_No"), hisConn)
                                                    dsSaveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                Else
                                                    '先做修改後做新增
                                                    dr = dsDB.Tables(tableDB).Rows(i)
                                                    dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                    dr("Dc") = "Y"
                                                    dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                    instancePUBAddPartBO.update(dsTemp, hisConn)
                                                    dsSaveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            Else
                                                '先做修改後做刪除再做新增
                                                dr = dsDB.Tables(tableDB).Rows(i - 1)
                                                dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                                dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                                instancePUBAddPartBO.update(dsTemp, hisConn)
                                                instancePUBAddPartBO.delete(CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")), strPartTypeId, dsDB.Tables(tableDB).Rows(i)("Add_Part_No"), hisConn)
                                                If dsSaveData.Tables(0).Rows(0)("End_Date").ToString > _
                                                   CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).ToString("yyyy/MM/dd") Then
                                                    dsSaveData.Tables(0).Rows(0)("End_Date") = CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")).AddDays(-1).ToString("yyyy/MM/dd")
                                                End If
                                            End If
                                        Else
                                            '否
                                            '先做修改後做刪除再做新增
                                            dr = dsDB.Tables(tableDB).Rows(i)
                                            dr("End_Date") = CDate(dsSaveData.Tables(0).Rows(0)("Effect_Date")).AddDays(-1)
                                            dsTemp.Tables(0).Rows.Add(dr.ItemArray)
                                            instancePUBAddPartBO.update(dsTemp, hisConn)
                                            instancePUBAddPartBO.delete(CDate(dsDB.Tables(tableDB).Rows(i + 1)("Effect_Date")), strPartTypeId, dsDB.Tables(tableDB).Rows(i)("Add_Part_No"), hisConn)
                                            dsSaveData.Tables(0).Rows(0)("Dc") = "Y"
                                        End If

                                        instancePUBAddPartBO.insertPUBAddPart(dsSaveData, hisConn)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    '處理完成後再以本部份負擔代碼作為條件查詢出所有記錄返回客戶端用來顯示
                    dsReturn = instancePUBAddPartBO.queryPUBAddPartByCond(System.DateTime.MinValue, strPartTypeId, hisConn)
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

