Imports System.Data.SqlClient
Imports System.IO
Imports System.Transactions
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.PUB

Public Class UCLMailSetupBS
    Dim log As LOGDelegate = LOGDelegate.getInstance

    Public Function querySMTPData() As System.Data.DataSet

        Dim pub As PUBDelegate = PUBDelegate.getInstance
        Dim pvtSMTPData As DataSet = Nothing

        Try

            '取得SMTP設定值
            pvtSMTPData = pub.queryPUBConfigWhereConfigNameIn("'SMTP_Address','SMTP_ID','SMTP_Password','SMTP_Port','SMTP_SSL_Flag'")

            Using ds As DataSet = New DataSet
                ds.Merge(pvtSMTPData)
                Return ds
            End Using

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If (pvtSMTPData IsNot Nothing) Then pvtSMTPData.Dispose()
        End Try
    End Function



End Class
