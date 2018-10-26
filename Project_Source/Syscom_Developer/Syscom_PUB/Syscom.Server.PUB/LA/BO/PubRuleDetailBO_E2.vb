'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBRuleDeatilBO_E2.vb
'*              Title:	PUBRuleDeatilBO_E2
'*        Description:	PUBRuleDeatilBO_E2
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	liuye
'*        Create Date:	2011/10/19
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection
Public Class PubRuleDetailBO_E2
    Inherits PubRuleDetailBO
    Private Shared instance As PubRuleDetailBO_E2

    Public Overloads Shared Function getInstance() As PubRuleDetailBO_E2
        If instance Is Nothing Then
            instance = New PubRuleDetailBO_E2
        End If
        Return instance
    End Function
    ''' <summary>
    '''  查詢相同RuleMaintainSn的資料
    ''' </summary>
    ''' <param name="RuleCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBRuleDeatilforRuleMaintainSn(ByRef RuleCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select A.Rule_Code,A.Rule_Maintain_Sn,A.Seq_No,A.Item_Code from PUB_Rule_Detail A " & _
                                  " inner join PUB_Rule_Detail B on B.Rule_Code=@Rule_Code  and A.Rule_Maintain_Sn=B.Rule_Maintain_Sn " & _
                                  " and A.Seq_No=B.Seq_No and A.Item_Code=B.Item_Code and A.Rule_Code<>@Rule_Code "

            command.Parameters.AddWithValue("@Rule_Code", RuleCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


End Class
