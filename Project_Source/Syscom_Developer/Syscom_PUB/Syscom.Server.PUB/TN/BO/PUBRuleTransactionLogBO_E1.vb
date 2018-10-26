Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text


Public Class PUBRuleTransactionLogBO_E1
    Inherits PubRuleTransactionLogBO

    Private Shared instance As PUBRuleTransactionLogBO_E1

    Public Overloads Shared Function getInstance() As PUBRuleTransactionLogBO_E1
        If instance Is Nothing Then
            instance = New PUBRuleTransactionLogBO_E1
        End If
        Return instance
    End Function


#Region "**20140227 add by SC - 檢核規則異動紀錄查詢 (全部)"

    Dim tableName1 As String = "PUB_Rule_Transaction_Log"

    Public Function queryPUBRuleTransactionLogAll() As System.Data.DataSet

        Dim SqlStr As String = ""
        Try
            Dim ds As DataSet

            '.\nckuHisOPD\Developer\NCKUHCommon\HisComm.BO\OPDBO\PUB\PubRuleTransactionLogBO.vb
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection) 'OPD DB
            Dim sqlConn As SqlClient.SqlConnection = CType(getAuthenticConnection(), SqlConnection) 'getAuthenticConnection -> NCKM_Common DB

            Dim command As SqlCommand = sqlConn.CreateCommand()

            SqlStr += " select prt_log.*,emp.Employee_Name"
            SqlStr += " ,Transaction_Mode_Name=case Transaction_Mode when 1 then '儲存' when 2 then '刪除' else convert(varchar,Transaction_Mode) end"
            SqlStr += " from PUB_Rule_Transaction_Log prt_log"
            SqlStr += " left join PUB_Employee emp on prt_log.Transaction_User=emp.Employee_Code"

            command.CommandText = SqlStr

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region


End Class
