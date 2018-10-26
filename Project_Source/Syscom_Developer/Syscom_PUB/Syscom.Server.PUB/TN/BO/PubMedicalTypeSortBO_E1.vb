'/*
'*****************************************************************************
'*
'*    Page/Class Name:  看診目的排序設定
'*              Title:	PubMedicalTypeSortBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Chi,Wang
'*        Create Date:	2017-04-06
'*      Last Modifier:	Chi,Wang
'*   Last Modify Date:	2017-04-06
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


Public Class PubMedicalTypeSortBO_E1
    Inherits PubMedicalTypeSortBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubMedicalTypeSortBO_E1
    Public Overloads Shared Function GetInstance() As PubMedicalTypeSortBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubMedicalTypeSortBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
#Region " 新增排序檔 "

    ''' <summary>
    ''' 新增排序檔
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function InsertPubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("insert into Pub_Medical_Type_Sort (medical_type_id, employee_code, sort_value)")
            Content.AppendLine("select pm.Medical_Type_Id, @employeecode, 0")
            Content.AppendLine("from PUB_Medical_Type pm")
            Content.AppendLine("where pm.Dc='N'")
            Content.AppendLine("and not exists (select so.sort_value from pub_medical_type_sort so")
            Content.AppendLine("  where so.Medical_Type_Id=pm.Medical_Type_Id")
            Content.AppendLine("  and so.employee_code=@employeecode )")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            ' For Each row As DataRow In ds.Tables(0).Rows
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@employeecode", stremployeecode)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            ' Next

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
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

#Region "     修改 Method "

#Region " 1.	依Grid順序, 由上至下排流水號 "

    ''' <summary>
    ''' 1.	依Grid順序, 由上至下排流水號
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function UpdatePubMedicalTypeSort(ByVal ds As DataSet, ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            'loop 給序號
            If ds.Tables.Count > 0 Then
                ds.Tables(0).Columns.Add("sort_value", Type.GetType("System.Int32"))
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    ds.Tables(0).Rows(i).Item("sort_value") = i + 1
                Next
            End If

            
            Dim Content As New StringBuilder
            Content.AppendLine("update pub_medical_type_sort set sort_value=@sortvalue ")
            Content.AppendLine("where employee_code=@employeecode and medical_type_id=@medicaltypeid")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@employeecode", stremployeecode)
                    command.Parameters.AddWithValue("@sortvalue", row.Item("sort_value"))
                    command.Parameters.AddWithValue("@medicaltypeid", row.Item("medical_type_id"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            count = 1
            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
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

#Region "     刪除 Method "

#Region " 刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function DeletePubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete pub_medical_type_sort where employee_code='" & stremployeecode & "'"

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
                'Command.Parameters.AddWithValue("@Case_No", row.Item("Case_No"))

                count = command.ExecuteNonQuery
            End Using

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
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

#Region "     查詢 Method "
#Region " Refresh Grid, 查詢sql "

    ''' <summary>
    ''' Refresh Grid, 查詢sql
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Function QueryPubMedicalTypeSort(ByVal stremployeecode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("select so.medical_type_id, pm.medical_type_name")
            Content.AppendLine("from pub_medical_type_sort so")
            Content.AppendLine("join PUB_Medical_Type pm on pm.medical_type_id=so.medical_type_id")
            Content.AppendLine("where so.employee_code=@employeecode")
            Content.AppendLine("order by so.sort_value")

            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@employeecode", stremployeecode)

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

#End Region

End Class

