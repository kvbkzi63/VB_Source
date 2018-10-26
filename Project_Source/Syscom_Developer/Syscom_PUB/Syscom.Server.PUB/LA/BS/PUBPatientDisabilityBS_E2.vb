'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患殘障記錄檔
'*              Title:	PUBPatientDisabilityBS_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-09-18
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-09-18
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP



Public Class PUBPatientDisabilityBS_E2

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientDisabilityBS_E2
    Public Shared Function GetInstance() As PUBPatientDisabilityBS_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientDisabilityBS_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "
    ''' <summary>
    ''' 確定儲存病患殘障記錄檔資料
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>成功 = true,失敗 = false</returns>
    ''' <remarks></remarks>
    Public Function confirmPUBPatientDisability(ByVal strChartNo As String, ByVal strEffectDate As String, ByVal ds As DataSet, ByVal blflag As Boolean) As Integer
        Dim flag As Integer = 0
        Dim PUBPatientDisabilityBO As PUBPatientDisabilityBO_E2 = PUBPatientDisabilityBO_E2.GetInstance()

        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()
            Try
                Using hisConn As SqlConnection = PUBPatientDisabilityBO.getConnection
                    hisConn.Open()
                    If blflag Then
                        PUBPatientDisabilityBO.deleteByCond(strChartNo, strEffectDate, hisConn)
                        PUBPatientDisabilityBO.insert(ds, hisConn)
                    Else
                        PUBPatientDisabilityBO.insert(ds, hisConn)
                    End If
                    hisConn.Close()
                End Using
                ts.Complete()
                flag = 1
            Catch commEx As CommonException
                ts.Dispose()
                Throw commEx
            Catch ex As Exception
                ts.Dispose()
                Throw ex
            End Try
        End Using
        Return flag
    End Function


#End Region

End Class

