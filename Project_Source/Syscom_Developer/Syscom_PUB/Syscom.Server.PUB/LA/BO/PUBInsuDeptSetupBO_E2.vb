'/*
'*****************************************************************************
'*
'*    Page/Class Name:  MDC24各部位外傷診斷碼維護作業
'*              Title:	DrgMdc24DiagnosisBo
'*        Description:	MDC24各部位外傷診斷碼維護作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Remote_Liu
'*        Create Date:	2016-05-11
'*      Last Modifier:	Remote_Liu
'*   Last Modify Date:	2016-05-11
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

Public Class PUBInsuDeptSetupBO_E2
    Inherits PUBInsuDeptSetupBO

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
    Public Overloads Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Insu_Dept_Code , Insu_Dept_Code_Name , Insu_Dept_Code_En_Name , Dc , Create_User , Create_Time , Modified_User , Modified_Time " & _
             "  ) " & _
             " values(@Insu_Dept_Code ,  @Insu_Dept_Code_Name , @Insu_Dept_Code_En_Name , @Dc , @Create_User , @Create_Time ,@Modified_User ,@Modified_Time  " & _
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
                    command.Parameters.AddWithValue("@Insu_Dept_Code", row.Item("Insu_Dept_Code"))
                    command.Parameters.AddWithValue("@Insu_Dept_Code_Name", row.Item("Insu_Dept_Code_Name"))
                    command.Parameters.AddWithValue("@Insu_Dept_Code_En_Name", row.Item("Insu_Dept_Code_En_Name"))
                    command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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

#Region " 修改"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Overloads Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Insu_Dept_Code=@Insu_Dept_Code,Insu_Dept_Code_Name=@Insu_Dept_Code_Name ,  Insu_Dept_Code_En_Name=@Insu_Dept_Code_En_Name , Dc=@Dc, Modified_User=@Modified_User, Modified_Time=@Modified_Time " & _
            "  " & _
            " where  Insu_Dept_Code=@Insu_Dept_Code  "
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
                    command.Parameters.AddWithValue("@Insu_Dept_Code", row.Item("Insu_Dept_Code"))
                    command.Parameters.AddWithValue("@Insu_Dept_Code_Name", row.Item("Insu_Dept_Code_Name"))
                    command.Parameters.AddWithValue("@Insu_Dept_Code_En_Name", row.Item("Insu_Dept_Code_En_Name"))
                    command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    ' command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    ' command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
    Public Function deleteChoose(ByVal dsDelete As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim countTemp As Integer = 0
            Dim sqlString As String = "delete from PUB_Insu_Dept where Insu_Dept_Code=@Insu_Dept_Code "
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
                    command.Parameters.AddWithValue("@Insu_Dept_Code", row.Item("Insu_Dept_Code"))
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

#Region "     以PK查詢資料(健保科別)"

    ''' <summary>
    ''' 以PK查詢資料(健保科別)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryByPKROC(ByRef Insu_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT A.Insu_Dept_Code, " & vbCrLf)
            Content.AppendLine("       A.Insu_Dept_Code_Name, " & vbCrLf)
            Content.AppendLine("       A.Insu_Dept_Code_En_Name, " & vbCrLf)
            Content.AppendLine("       A.Dc, " & vbCrLf)
            Content.AppendLine("       A.Create_User, " & vbCrLf)
            Content.AppendLine("       A.Create_Time, " & vbCrLf)
            Content.AppendLine("       dbo.Adtoroctime(A.Create_Time)   AS Create_Time_ROC, " & vbCrLf)
            Content.AppendLine("       A.Modified_User, " & vbCrLf)
            Content.AppendLine("       A.Modified_Time, " & vbCrLf)
            Content.AppendLine("       dbo.Adtoroctime(A.Modified_Time) AS Modified_Time_ROC " & vbCrLf)
            Content.AppendLine("FROM   PUB_Insu_Dept A " & vbCrLf)
            Content.AppendLine("WHERE   A.Insu_Dept_Code = @Insu_Dept_Code " & vbCrLf)
            'If pk_Body_Part.Length > 0 Then
            '    Content.AppendLine(" AND A.Body_Part = @Body_Part " & vbCrLf)
            'End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Insu_Dept_Code", Insu_Dept_Code)

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

#Region "     查詢全部(民國年)"

    ''' <summary>
    ''' 查詢全部(民國年)
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryAllROC(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.Append("SELECT A.Insu_Dept_Code, " & vbCrLf)
            content.Append("       A.Insu_Dept_Code_Name, " & vbCrLf)
            content.Append("       A.Insu_Dept_Code_En_Name, " & vbCrLf)
            content.Append("       A.Dc, " & vbCrLf)
            content.Append("       A.Create_User, " & vbCrLf)
            content.Append("       A.Create_Time, " & vbCrLf)
            content.Append("       dbo.Adtoroctime(A.Create_Time)   AS Create_Time_ROC, " & vbCrLf)
            content.Append("       A.Modified_User, " & vbCrLf)
            content.Append("       A.Modified_Time, " & vbCrLf)
            content.Append("       dbo.Adtoroctime(A.Modified_Time) AS Modified_Time_ROC " & vbCrLf)
            content.Append("FROM   PUB_Insu_Dept A " & vbCrLf)

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

