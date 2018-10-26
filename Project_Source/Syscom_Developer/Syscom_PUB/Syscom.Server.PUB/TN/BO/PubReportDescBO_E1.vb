'/*
'*****************************************************************************
'*
'*    Page/Class Name:  單張報表描述檔維護
'*              Title:	PubReportDescBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	ChenYu.Guo
'*        Create Date:	2015-06-01
'*      Last Modifier:	ChenYu.Guo
'*   Last Modify Date:	2015-06-01
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text



Public Class PubReportDescBO_E1
    Inherits PubReportDescBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubReportDescBO_E1
    Public Overloads Shared Function GetInstance() As PubReportDescBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubReportDescBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region " 依欄位搜尋 "

    ''' <summary>
    ''' 依欄位搜尋
    ''' </summary>
    ''' <param name="reportID" >報表代碼</param>
    ''' <param name="reportName" >報表名稱</param>
    ''' <param name="SystemCode" >系統別</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-01</remarks>
    Public Function QueryByLikeColumn(ByRef reportID As String, ByRef reportName As String, ByRef SystemCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Report_ID , Report_Name , System_Code , Report_Desc , Create_User ,  ")
            content.AppendLine(" Create_Time , Modified_User , Modified_Time from " & tableName)
            content.AppendLine("   where Report_ID like @Report_ID ")
            content.AppendLine(" and Report_Name like @Report_Name ")
            content.AppendLine(" and System_Code like @System_Code ")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Report_ID", "%" & reportID & "%")
            command.Parameters.AddWithValue("@Report_Name", "%" & reportName & "%")
            command.Parameters.AddWithValue("@System_Code", "%" & SystemCode & "%")

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

End Class

