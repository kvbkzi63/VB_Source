﻿'/*
'*****************************************************************************
'*
'*    Page/Class Name:  五都戶籍地設定維護
'*              Title:	
'*        Description:	五都戶籍地設定維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Xiaozhi,Yu
'*        Create Date:	2016-05-24
'*      Last Modifier:	Xiaozhi,Yu
'*   Last Modify Date:	2016-05-24
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO

Public Class PUBAreaCodeNBO_E2
    Inherits PubAreaCodeNBO

#Region "     使用的Instance宣告 "

    'Public Shared ReadOnly tableName As String = "DRG_MDC24_Diagnosis"
    'Private Shared myInstance As PUBInsuDeptSetupBO_E2
    'Public Shared Function GetInstance() As PUBInsuDeptSetupBO_E2
    '    If myInstance Is Nothing Then
    '        myInstance = New PUBInsuDeptSetupBO_E2
    '    End If
    '    Return myInstance
    'End Function

#End Region

#Region "     新增 Method "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function InsertAreaCode(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Area_Code , Orig_Area_Code , Area_Name , County_Code , Sort_Value " & _
             "  ) " & _
             " values(@Area_Code ,  @Orig_Area_Code , @Area_Name , @County_Code , @Sort_Value  " & _
             "              )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                    command.Parameters.AddWithValue("@Orig_Area_Code", row.Item("Orig_Area_Code"))
                    command.Parameters.AddWithValue("@Area_Name", row.Item("Area_Name"))
                    command.Parameters.AddWithValue("@County_Code", row.Item("County_Code"))
                    command.Parameters.AddWithValue("@Sort_Value", row.Item("Sort_Value"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     修改 Method "

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function UpdateAreaCode(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Area_Code=@Area_Code, Orig_Area_Code=@Orig_Area_Code ,  Area_Name=@Area_Name , County_Code=@County_Code, Sort_Value=@Sort_Value " & _
            "  " & _
            " where  Area_Code=@Area_Code  and  Orig_Area_Code=@Orig_Area_Code"
            ' AND Create_User=@Create_User AND Create_Time=@Create_Time 
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                    command.Parameters.AddWithValue("@Orig_Area_Code", row.Item("Orig_Area_Code"))
                    command.Parameters.AddWithValue("@Area_Name", row.Item("Area_Name"))
                    command.Parameters.AddWithValue("@County_Code", row.Item("County_Code"))
                    command.Parameters.AddWithValue("@Sort_Value", row.Item("Sort_Value"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
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
    ''' 多筆刪除資料(勾選項目)
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteAreaCodeChoose(ByVal dsDelete As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim countTemp As Integer = 0
            Dim sqlString As String = "delete from PUB_Area_Code_N where Area_Code=@Area_Code and Orig_Area_Code=@Orig_Area_Code "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In dsDelete.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                    command.Parameters.AddWithValue("@Orig_Area_Code", row.Item("Orig_Area_Code"))
                    countTemp = command.ExecuteNonQuery
                    count += countTemp
                End Using
            Next
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

#Region "     以PK查詢資料(戶籍地代碼)"

    ''' <summary>
    ''' 以PK查詢資料(戶籍地代碼)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryAreaCodeByPK(ByRef Area_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT A.Area_Code, " & vbCrLf)
            Content.AppendLine("       A.Orig_Area_Code, " & vbCrLf)
            Content.AppendLine("       A.Area_Name, " & vbCrLf)
            Content.AppendLine("       A.County_Code, " & vbCrLf)
            Content.AppendLine("       A.Sort_Value " & vbCrLf)
            Content.AppendLine("FROM   PUB_Area_Code_N A " & vbCrLf)
            Content.AppendLine("WHERE   A.Area_Code = @Area_Code " & vbCrLf)
            'If pk_Body_Part.Length > 0 Then
            '    Content.AppendLine(" AND A.Body_Part = @Body_Part " & vbCrLf)
            'End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Area_Code", Area_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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

#Region "     查詢全部"

    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryAreaCodeAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            Content.AppendLine("SELECT A.Area_Code, " & vbCrLf)
            content.AppendLine("       A.Orig_Area_Code, " & vbCrLf)
            content.AppendLine("       A.Area_Name, " & vbCrLf)
            content.AppendLine("       A.County_Code, " & vbCrLf)
            content.AppendLine("       A.Sort_Value " & vbCrLf)
            content.AppendLine("FROM   PUB_Area_Code_N A " & vbCrLf)

            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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


#End Region


End Class
