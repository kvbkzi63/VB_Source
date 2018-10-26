
'/*
'*****************************************************************************
'*
'*    Page/Class Name:  費用項目對應檔-BO
'*              Title:	PUBAccountBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-11
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-11
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP


Public Class PubPuleReasonBO_E2
    Inherits PubRuleReasonBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly tableNamePubsyscode As String = "PUB_SYSCODE"

    Private Shared myInstance As PubPuleReasonBO_E2
    Public Overloads Shared Function GetInstance() As PubPuleReasonBO_E2
        If myInstance Is Nothing Then
            myInstance = New PubPuleReasonBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPkRuleCode(ByVal pk_Rule_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Rule_Code , Rule_Reason_Id , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time                from " & tableName)
            content.AppendLine("   where Rule_Code=@Rule_Code            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "     刪除 Method "
    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteByPkRuleCode(ByVal pk_Rule_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Rule_Code=@Rule_Code  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

End Class


