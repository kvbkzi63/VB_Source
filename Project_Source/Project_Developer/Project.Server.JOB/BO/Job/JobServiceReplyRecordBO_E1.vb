'/*
'*****************************************************************************
'*
'*    Page/Class Name:  需求退件紀錄
'*              Title:	JobServiceReplyRecordBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-09-09
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-09-09
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class JobServiceReplyRecordBO_E1
    Inherits JobServiceReplyRecordBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobServiceReplyRecordBO_E1
    Public Overloads Shared Function GetInstance() As JobServiceReplyRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobServiceReplyRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
#Region " 新增退件紀錄 "

    ''' <summary>
    ''' 新增退件紀錄
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-09-09</remarks>
    Public Function CreateNewServiceRejectRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("resultDT"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                For Each dr As DataRow In ds.Tables(0).Rows
                    dr("Seq_No") = GetRejectRecordSeqNoByIssueId(dr("Issue_Id").ToString.Trim, conn)
                Next
                retDS.Tables(0).Rows.Add(insert(ds, conn) + UpdateServiceRecord(ds.Tables(0).Rows(0), conn))
                scope.Complete()
                Return retDS
            End Using
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
#Region " 更新需求狀態 "

    ''' <summary>
    ''' 更新需求狀態
    ''' </summary>
    ''' <param name="dr" >資料列</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-09-09</remarks>
    Public Function UpdateServiceRecord(ByVal dr As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine(" Update JOB_Service_Record ")
            Content.AppendLine("    Set Issue_Status=@Issue_Status")
            Content.AppendLine("       ,Modified_User=@Modified_User")
            Content.AppendLine("	   ,Modified_Time=getdate()")
            '被退件
            If dr("Reply_Type").Equals("6") Then
                Content.AppendLine("	   ,Finish_Date = null")
            ElseIf dr("Reply_Type").Equals("5") Then
                Content.AppendLine("	   ,Finish_Date =getdate()")
            End If
            Content.AppendLine(" Where Issue_Id=@Issue_Id")
            Content.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Issue_Status", dr("Reply_Type"))
                command.Parameters.AddWithValue("@Issue_Id", dr("Issue_Id"))
                command.Parameters.AddWithValue("@Modified_User", dr("Modified_User"))

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

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

#End Region

#Region "     查詢 Method "

#Region " 查詢退件紀錄 "

    ''' <summary>
    ''' 查詢退件紀錄
    ''' </summary>
    ''' <param name="ds" >需求單號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-09-09</remarks>
    Public Function QueryServiceRejectRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim IssueId As String = ds.Tables(0).Rows(0).Item("Issue_Id").ToString.Trim
        Dim retDS As DataSet

        Try

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT  JSRR.Issue_Id")
            Content.AppendLine("	   ,JSRR.Reason_FID")
            Content.AppendLine("       ,JSRR.Create_User")
            Content.AppendLine("	   ,JSRR.Create_Time")
            Content.AppendLine("	   ,RTRIM(PS.Code_Name) Reply_Type")
            Content.AppendLine("  FROM  JOB_Service_Reply_Record JSRR")
            Content.AppendLine("Inner Join Pub_Syscode  PS On PS.Type_Id='9998' And PS.Code_Id=JSRR.Reply_Type")
            Content.AppendLine("  Where JSRR.Issue_Id=@Issue_Id")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Issue_Id", IssueId)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet(tableName)
                adapter.Fill(retDS, tableName)
            End Using

            Return retDS

        Catch sqlex As SqlException
            retDS = New DataSet()
            retDS.Tables.Add(New DataTable("Result"))
            retDS.Tables(0).Columns.Add("result")
            retDS.Tables(0).Rows.Add(sqlex.ToString)
            Return retDS
        Catch cmex As CommonException
            retDS = New DataSet()
            retDS.Tables.Add(New DataTable("Result"))
            retDS.Tables(0).Columns.Add("result")
            retDS.Tables(0).Rows.Add(cmex.ToString)
            Return retDS
        Catch ex As Exception
            retDS = New DataSet()
            retDS.Tables.Add(New DataTable("Result"))
            retDS.Tables(0).Columns.Add("result")
            retDS.Tables(0).Rows.Add(ex.ToString)
            Return retDS
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 取得最大流水號 "

    ''' <summary>
    ''' 取得最大流水號
    ''' </summary>
    ''' <param name="IssueId" >需求單號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-09-09</remarks>
    Public Function GetRejectRecordSeqNoByIssueId(ByVal IssueId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT  count(0) + 1 ")
            Content.AppendLine("  FROM  JOB_Service_Reply_Record ")
            Content.AppendLine("  Where Issue_Id=@Issue_Id")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Issue_Id", IssueId)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return CInt(ds.Tables(0).Rows(0).Item(0))

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

