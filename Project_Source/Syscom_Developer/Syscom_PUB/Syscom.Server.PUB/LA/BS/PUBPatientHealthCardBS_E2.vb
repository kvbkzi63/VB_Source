'/*
'*****************************************************************************
'*
'*    Page/Class Name:  全國醫療服務卡維護檔新增修改
'*              Title:	PUBPatientHealthCardBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO



Public Class PUBPatientHealthCardBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientHealthCardBS_E2
    Public Shared Function GetInstance() As PUBPatientHealthCardBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientHealthCardBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     修改 Method "
    ''' <summary>
    ''' 新增交易保護
    ''' </summary>
    ''' <param name="dsHealth">PUB_Patient_Health_Card資料</param>
    ''' <param name="dsFlag">PUB_Patient_Flag資料</param>
    ''' <returns>成功時：1；失敗時：0</returns>
    ''' <remarks></remarks>
    Public Function insertPUBHealthAndFlag(ByVal dsHealth As DataSet, ByVal dsFlag As DataSet, ByVal blFlag As Boolean) As Integer
        Dim instancePUBPatientHealthCard As New PUBPatientHealthCardBO_E2
        Dim instancePubPatientFlag As New PubPatientFlagBO_E2
        Dim iPubPatientFlag As Integer = 0
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Try
                Using hisConn As SqlConnection = PubSheetBO.GetInstance.getConnection
                    hisConn.Open()
                    If blFlag Then
                        instancePUBPatientHealthCard.insert(dsHealth, hisConn)
                        iPubPatientFlag = instancePubPatientFlag.insert(dsFlag, hisConn)
                        hisConn.Close()
                    Else
                        instancePUBPatientHealthCard.update(dsHealth, hisConn)
                        iPubPatientFlag = instancePubPatientFlag.insert(dsFlag, hisConn)
                        hisConn.Close()
                    End If

                End Using
                If iPubPatientFlag > 0 Then
                    ts.Complete()
                Else
                    ts.Dispose()
                    iPubPatientFlag = 0
                End If
            Catch commEx As CommonException
                ts.Dispose()
                iPubPatientFlag = 0
                Throw commEx
            Catch ex As Exception
                ts.Dispose()
                iPubPatientFlag = 0
                Throw ex
            End Try
        End Using
        Return iPubPatientFlag
    End Function
#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Will,Lin on 2015-09-14</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

