'/*
'*****************************************************************************
'*
'*    Page/Class Name:  片語維護作業
'*              Title:	JobPhraseBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2018-08-06
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2018-08-06
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

Public Class JobPhraseBO_E1
    Inherits PubPhraseBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobPhraseBO_E1
    Public Overloads Shared Function GetInstance() As JobPhraseBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobPhraseBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
#Region " 新增片語 "

    ''' <summary>
    ''' 新增片語
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2018-08-06</remarks>
    Public Overloads Function InsertInto(ByVal ds As DataSet) As DataSet


        Try
            ds.Tables(0).Rows(0).Item("Phrase_No") = QueryMaxSeqNo()
            insert(ds)
            Return queryByPK(ds.Tables(0).Rows(0).Item("Phrase_No"))


        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        End Try
        Return Nothing
    End Function

#End Region

#End Region

#Region "     修改 Method "
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="ds" >修改</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2018-08-06</remarks>
    Public Overloads Function UpdatePhrase(ByVal ds As DataSet) As DataSet

        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("cnt")
        Try
            retDS.Tables(0).Rows.Add(update(ds))

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        End Try
        Return retDS
    End Function
#End Region

#Region "     刪除 Method "
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="ds" >刪除資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2018-08-06</remarks>
    Public Overloads Function deletePhrase(ByVal ds As DataSet) As DataSet

        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("cnt")
        Try
            retDS.Tables(0).Rows.Add(delete(ds.Tables(0).Rows(0).Item("Phrase_No")))

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        End Try
        Return retDS
    End Function
#End Region

#Region " 查詢片語 "

    ''' <summary>
    ''' 查詢片語
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2018-08-06</remarks>
    Public Function QueryPhrasebyCond(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim IsPublic As String = input.Tables(0).Rows(0).Item("Is_Public").ToString.Trim
        Dim CreateUser As String = input.Tables(0).Rows(0).Item("Create_User").ToString.Trim
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Phrase_No]")
            Content.AppendLine("      ,[Phrase_Content]")
            Content.AppendLine("      ,[Is_Public]")
            Content.AppendLine("      ,[Create_User]")
            Content.AppendLine("      ,[Create_Time]")
            Content.AppendLine("      ,[Modified_User]")
            Content.AppendLine("      ,[Modified_Time]")
            Content.AppendLine("  FROM [PUB_Phrase]")
            Content.AppendLine(" Where 1=1")

            If IsPublic = "Y" Then
                Content.AppendLine(" And Is_Public='" & IsPublic & "'")
            Else
                Content.AppendLine(" And Create_User='" & CreateUser & "'")
            End If


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

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
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 查詢片語序號 "

    ''' <summary>
    ''' 查詢片語序號
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2018-08-06</remarks>
    Public Function QueryMaxSeqNo(Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Count(1)+1 From PUB_Phrase"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds.Tables(0).Rows(0).Item(0)

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢片語序號"})
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

