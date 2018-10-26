'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PubRuleClassBO_E2.vb
'*              Title:	PubRuleClassBO_E2
'*        Description:	PubRuleClassBO_E2
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
Public Class PubRuleClassBO_E2
    Inherits PubRuleClassBO

    Private Shared instance As PubRuleClassBO_E2

    Public Overloads Shared Function getInstance() As PubRuleClassBO_E2
        If instance Is Nothing Then
            instance = New PubRuleClassBO_E2
        End If
        Return instance
    End Function

    Public Function deletePubRuleClassBObyConditionRuleCode(ByRef ConditionRuleCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            "  Condition_Rule_Code in (" & ConditionRuleCode & ") "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

End Class
