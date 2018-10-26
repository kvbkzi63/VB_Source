'/*
'*****************************************************************************
'*
'*    Page/Class Name:  郵遞區號對應戶籍地設定維護
'*              Title:	
'*        Description:	郵遞區號對應戶籍地設定維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Xiaozhi,Yu
'*        Create Date:	2016-05-26
'*      Last Modifier:	Xiaozhi,Yu
'*   Last Modify Date:	2016-05-26
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

Public Class PUBPostalAreaBO_E2
    Inherits PubPostalAreaBO

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
    Public Function InsertPostalArea(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Postal_Code , Area_Code  " & _
             "  ) " & _
             " values(@Postal_Code ,  @Area_Code   " & _
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
                    command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
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
    Public Function UpdatePostalArea(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Postal_Code=@Postal_Code, Area_Code=@Area_Code " & _
            "  " & _
            " where  Postal_Code=@Postal_Code "
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
                    command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
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
    Public Function deletePostalAreaChoose(ByVal dsDelete As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim countTemp As Integer = 0
            Dim sqlString As String = "delete from PUB_Postal_Area where Postal_Code=@Postal_Code  "
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
                    command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
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

#Region "     以PK查詢資料(郵遞區號)"

    ''' <summary>
    ''' 以PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryPostalAreaByPK(ByRef Postal_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Postal_Code, " & vbCrLf)
            Content.AppendLine("       Area_Code " & vbCrLf)
            Content.AppendLine("FROM   PUB_Postal_Area " & vbCrLf)
            Content.AppendLine("WHERE   Postal_Code = @Postal_Code " & vbCrLf)
            'If pk_Body_Part.Length > 0 Then
            '    Content.AppendLine(" AND A.Body_Part = @Body_Part " & vbCrLf)
            'End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Postal_Code", Postal_Code)

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

#Region "     以所有PK查詢資料(郵遞區號)"

    ''' <summary>
    ''' 以所有PK查詢資料(郵遞區號)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryPostalAreaByPKAll(ByRef Postal_Code As System.String, ByRef Area_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Postal_Code, " & vbCrLf)
            Content.AppendLine("       Area_Code " & vbCrLf)
            Content.AppendLine("FROM   PUB_Postal_Area " & vbCrLf)
            Content.AppendLine("WHERE   Postal_Code = @Postal_Code and Area_Code = @Area_Code" & vbCrLf)
            'If pk_Body_Part.Length > 0 Then
            '    Content.AppendLine(" AND A.Body_Part = @Body_Part " & vbCrLf)
            'End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Postal_Code", Postal_Code)
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
    Public Function queryPostalAreaAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("SELECT Postal_Code, " & vbCrLf)
            content.AppendLine("       Area_Code " & vbCrLf)
            content.AppendLine("FROM   PUB_Postal_Area " & vbCrLf)

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

