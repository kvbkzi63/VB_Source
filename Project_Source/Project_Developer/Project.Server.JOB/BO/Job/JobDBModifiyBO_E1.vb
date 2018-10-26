Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Public Class JobDBModifiyBO_E1

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobDBModifiyBO_E1
    Public Overloads Shared Function GetInstance() As JobDBModifiyBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobDBModifiyBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region " DB異動申請(PG回覆初始化查詢) "

    ''' <summary>
    ''' DB異動申請(PG回覆初始化查詢)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Public Function QuerySADBModifyRecord(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As DataSet
            Dim Query_Condition As String = ds.Tables(0).Rows(0).Item("Query_Condition").ToString.Trim
            Dim ProjectID As String = ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If


            Dim Content As New StringBuilder
            Content.AppendLine("SELECT RTRIM(JSDR.Create_Time) AS Create_Time,")
            Content.AppendLine("	   RTRIM(PE.Employee_Name) AS Create_User,")
            Content.AppendLine("	   RTRIM(JSDR.Project_ID) AS Project_ID, ")
            Content.AppendLine("	   RTRIM(JSDR.Seq_No) AS Seq_No, ")
            Content.AppendLine("	   RTRIM(PP.Project_Name) AS Project_Name, ")
            Content.AppendLine("	   RTRIM(JSDR.Table_Name) AS Table_Name, ")
            Content.AppendLine("	   RTRIM(JSDR.Table_Ch_Name) AS Table_Ch_Name, ")
            Content.AppendLine("	   RTRIM(JSDR.Modified_Classify) AS Modified_Classify,  ")
            Content.AppendLine("	   RTRIM(JSDR.[Restrict]) AS 'Restrict',")
            Content.AppendLine("	   Case RTRIM(JSDR.Is_Modified)")
            Content.AppendLine("	   When 'Y' Then '已處理' ")
            Content.AppendLine("	   When 'N' Then '退件'")
            Content.AppendLine("	   Else '未處理'")
            Content.AppendLine("	   End AS 'Is_Modified',")
            Content.AppendLine("	   RTRIM(JSDR.Modified_FID) AS Modified_FID,")
            Content.AppendLine("	   RTRIM(JSDR.Reject_Reason) AS Reject_Reason")
            Content.AppendLine("  FROM JOB_SA_DBModified_Record JSDR")
            Content.AppendLine(" Inner Join PRJ_Project PP On PP.Project_ID=JSDR.Project_ID")
            Content.AppendLine(" Inner Join Pub_Employee PE On JSDR.Create_User=PE.Employee_Code")
            Content.AppendLine("Where 1=1")
            Content.AppendLine("  And JSDR.DBA_Employee_Code=@DBA_Employee_Code")

            If ProjectID.Length > 0 Then
                Content.AppendLine("  And JSDR.Project_ID=@Project_ID")
            End If
            If Query_Condition.Length > 0 Then
                Select Case Query_Condition
                    Case "Finished"
                        Content.AppendLine("  And JSDR.Is_Modified='Y'")
                    Case "UnFinish"
                        Content.AppendLine("  And JSDR.Is_Modified IS NULL ")
                End Select
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@DBA_Employee_Code", ds.Tables(0).Rows(0).Item("DBA_Employee_Code"))
            If ProjectID.Length > 0 Then
                command.Parameters.AddWithValue("@Project_ID", ProjectID)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet("JOB_SA_DBModified_Record")
                adapter.Fill(retDS, "JOB_SA_DBModified_Record")
            End Using

            Return retDS

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

    Public Function QueryDBModifyInitialData(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Project_ID]")
            Content.AppendLine("      ,[Project_Name]")
            Content.AppendLine("  FROM  PRJ_Project ")
            Content.AppendLine("  Where End_Date is null")
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet()
                adapter.Fill(retDS)
            End Using

            Return retDS

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

#Region " DB異動申請(DBA回覆) "

    ''' <summary>
    ''' DB異動申請(DBA回覆)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Public Function DBAReplyModify(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Dim Project_ID As String = ds.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
        Dim Seq_No As String = ds.Tables(0).Rows(0).Item("Seq_No").ToString.Trim
        Dim Reject_Reason As String = ds.Tables(0).Rows(0).Item("Reject_Reason").ToString.Trim
        Dim Modified_User As String = ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("RESULT"))
        retDS.Tables(0).Columns.Add("Count")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update Job_SA_DBModified_Record")
            Content.AppendLine("   Set Modified_User=@Modified_User")
            If Reject_Reason.Length > 0 Then
                Content.AppendLine("      ,Reject_Reason=@Reject_Reason")
                Content.AppendLine("      ,Is_Modified='N'")
            Else
                Content.AppendLine("      ,Is_Modified='Y'")
            End If
            Content.AppendLine("      ,Modified_Time=getdate()")
            Content.AppendLine(" Where Project_ID=@Project_ID ")
            Content.AppendLine("   And Seq_No=@Seq_No")


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                If Reject_Reason.Length > 0 Then
                    command.Parameters.AddWithValue("@Reject_Reason", Reject_Reason)
                End If
                command.Parameters.AddWithValue("@Project_ID", Project_ID)
                command.Parameters.AddWithValue("@Seq_No", Seq_No)
                command.Parameters.AddWithValue("@Modified_User", Modified_User)


                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt

                retDS.Tables(0).Rows.Add(count)
            End Using

            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"回覆DB異動"})
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
