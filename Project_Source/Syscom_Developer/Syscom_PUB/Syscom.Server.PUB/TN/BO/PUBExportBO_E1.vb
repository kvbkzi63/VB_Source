'/*
'*****************************************************************************
'*
'*    Page/Class Name:  統計查詢設定作業
'*              Title:	PUBExportBO_E1
'*        Description:	1.新增、刪除、修改、查詢
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-08-10
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-08-10
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP



Public Class PUBExportBO_E1
    Inherits PubExportBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBExportBO_E1
    Public Overloads Shared Function GetInstance() As PUBExportBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBExportBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "
    ''' <summary>
    '''查詢內容
    ''' </summary>
    ''' <returns>查詢內容</returns>
    ''' <remarks></remarks>
    Public Function queryData(ByVal Report_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataTable
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select PE.Report_Id, ")
            content.AppendLine("	   PE.Report_Name, ")
            content.AppendLine("	   PE.ConnectionName, ")
            content.AppendLine("	   PE.Dc, ")
            content.AppendLine("	   PE.Report_Sql, ")
            content.AppendLine("	   PE.Create_User, ")
            content.AppendLine("	   PE.Modified_User,")
            content.AppendLine("	   PE.Footer1,")
            content.AppendLine("	   PE.Footer2 ")
            content.AppendLine("  from " & tableName & " PE")
            content.AppendLine("  Inner Join ARM_Fun_System AFS On AFS.Fun_System_Memo=PE.Report_Id")
            If Report_Id <> "" Then
                content.AppendLine("   where AFS.fun_function_no = @Report_Id ")
            End If
            command.CommandText = content.ToString
            If Report_Id <> "" Then
                command.Parameters.AddWithValue("@Report_Id", Report_Id)
            End If
            Using da As SqlDataAdapter = New SqlDataAdapter(command)
                Using dt As DataTable = New DataTable("ExportDT")

                    da.Fill(dt)

                    Return dt
                End Using
            End Using
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

