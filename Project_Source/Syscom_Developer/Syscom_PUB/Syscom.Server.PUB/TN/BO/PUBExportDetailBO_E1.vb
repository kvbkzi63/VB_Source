'/*
'*****************************************************************************
'*
'*    Page/Class Name:  統計查詢設定作業
'*              Title:	PUBExportDetailBO_E1
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


Public Class PUBExportDetailBO_E1
    Inherits PubExportDetailBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBExportDetailBO_E1
    Public Overloads Shared Function GetInstance() As PUBExportDetailBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBExportDetailBO_E1
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
    ''' <summary>
    '''刪除內容
    ''' </summary>
    ''' <returns>刪除內容</returns>
    ''' <remarks></remarks>
    Public Function deleteAll(ByVal Report_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Report_Id=@Report_Id "
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
                command.Parameters.AddWithValue("@Report_Id", Report_Id)
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
            Dim Content As New StringBuilder
            Content.AppendLine("           Select PED.Report_Id, ")
            Content.AppendLine("                  PED.Sort_No, ")
            Content.AppendLine("                  PED.Field_Name, ")
            Content.AppendLine("                  PED.Field_Code, ")
            Content.AppendLine("                  PED.Field_Description, ")
            Content.AppendLine("                  PED.Form_Control_Type, ")
            Content.AppendLine("                  PED.Is_Nreq, ")
            Content.AppendLine("                  PED.Field_Nreq_Cond, ")
            Content.AppendLine("                  PED.Field_Nreq_Code, ")
            Content.AppendLine("                  '' as DeleteButton,  ")
            Content.AppendLine("                  PED.Default_Value,  ")
            Content.AppendLine("                  PED.Cbo_Source_Data  ")
            Content.AppendLine("           from  Pub_Export_Detail PED")
            Content.AppendLine("		Inner Join ARM_Fun_System AFS On AFS.Fun_System_Memo=PED.Report_Id")
            If Report_Id <> "" Then
                Content.AppendLine("   where AFS.fun_function_no = @Report_Id ")
            End If
            command.CommandText = content.ToString
            If Report_Id <> "" Then
                command.Parameters.AddWithValue("@Report_Id", Report_Id)
            End If
            content.Append("Order by Sort_No")



            Using da As SqlDataAdapter = New SqlDataAdapter(command)
                Using dt As DataTable = New DataTable("ExportDetailDT")

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

