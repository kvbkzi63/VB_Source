'/*
'*****************************************************************************
'*
'*    Page/Class Name:  信件群組設定
'*              Title:	JobMailGroupBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-06-16
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-06-16
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class JobMailGroupBO_E1
    Inherits PrjMailGroupBO
#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobMailGroupBO_E1
    Public Overloads Shared Function GetInstance() As JobMailGroupBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobMailGroupBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
    ''' <summary>
    ''' 信件群組設定
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function InsertNewMailGroup(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("")
            Content.AppendLine("insert into PRJ_Mail_Group (Group_Id,Group_Name,Belong_Employee_Code,Create_User,Create_Time,Modified_User,Modified_Time)")
            Content.AppendLine("")
            Content.AppendLine("Values (@Group_Id,@Group_Name,@Belong_Employee_Code,@Create_User,@Create_Time,@Modified_User,@Modified_Time)")
            Content.AppendLine("")


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    command.Parameters.AddWithValue("@Group_Name", row.Item("Group_Name"))
                    command.Parameters.AddWithValue("@Belong_Employee_Code", row.Item("Belong_Employee_Code"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Create_Time", Now)
                    command.Parameters.AddWithValue("@Modified_Time", Now)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)
            Return retDS

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


    ''' <summary>
    ''' 信件群組設定
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function InsertMailGroupDetail(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("")
            Content.AppendLine("insert into PRJ_Mail_Group_Detail (Group_Id,Employee_Code,Belong_Employee_Code,EMail,Create_User,Create_Time,Modified_User,Modified_Time)")
            Content.AppendLine("")
            Content.AppendLine("Values (@Group_Id,@Employee_Code,@Belong_Employee_Code,@EMail,@Create_User,@Create_Time,@Modified_User,@Modified_Time)")
            Content.AppendLine("")


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Belong_Employee_Code", row.Item("Belong_Employee_Code"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Create_Time", Now)
                    command.Parameters.AddWithValue("@Modified_Time", Now)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)
            Return retDS

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


#Region "     建立臨時郵件群組"

    Public Function CreateTempMailGroup(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Dim GupTable As DataSet = Project.Comm.JOB.PrjMailGroupDataTableFactory.getDataSetWithSchema
        Dim GupDetailTable As DataSet = Project.Comm.JOB.PrjMailGroupDetailDataTableFactory.getDataSetWithSchema
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim GroupId As String = QueryTempGroupId(ds.Tables(0).Rows(0).Item("Employee_Code"), conn)
            Dim GpDR As DataRow = GupTable.Tables(0).NewRow
            GpDR("Group_Id") = GroupId
            GpDR("Group_Name") = "Temp"
            GpDR("Belong_Employee_Code") = ds.Tables(0).Rows(0).Item("Employee_Code")
            GpDR("Create_User") = ds.Tables(0).Rows(0).Item("Employee_Code")
            GpDR("Modified_User") = ds.Tables(0).Rows(0).Item("Employee_Code")
            GpDR("Temporary") = "Y"
            GupTable.Tables(0).Rows.Add(GpDR)
            For Each s As String In ds.Tables(0).Rows(0).Item("MailList").ToString.Trim.Split(";")
                Dim GpdDR As DataRow = GupDetailTable.Tables(0).NewRow
                GpdDR("Group_Id") = GroupId
                GpdDR("Belong_Employee_Code") = ds.Tables(0).Rows(0).Item("Employee_Code")
                GpdDR("Employee_Code") = s.Split("-")(0)
                GpdDR("EMail") = s.Split("-")(1)
                GpdDR("Create_User") = ds.Tables(0).Rows(0).Item("Employee_Code")
                GpdDR("Modified_User") = ds.Tables(0).Rows(0).Item("Employee_Code")
                GupDetailTable.Tables(0).Rows.Add(GpdDR)
            Next
            If insert(GupTable, conn) + PrjMailGroupDetailBO.GetInstance.insert(GupDetailTable, conn) > 0 Then
                retDS.Tables(0).Rows.Add(GroupId)
            End If
            Return retDS

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

#Region " 取得流水號 "

    ''' <summary>
    ''' 取得流水號
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-08-10</remarks>
    Public Function QueryTempGroupId(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine(" Select Count(Group_Id) +1 ")
            Content.AppendLine("   From PRJ_Mail_Group")
            Content.AppendLine("  Where Belong_Employee_Code=@Belong_Employee_Code")
            Content.AppendLine("    And Temporary='Y'")
            Content.AppendLine("")
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Belong_Employee_Code", EmployeeCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using



            Return "TEMP" & Syscom.Comm.Utility.StringUtil.appendCharToLeft(ds.Tables(0).Rows(0).Item(0), CChar("0"), 6)

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得流水號"})
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
    ''' <summary>
    ''' 信件群組設定
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function UpdateMailGroup(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update PRJ_Mail_Group Set Group_Name=@Group_Name ,Modified_User=@Modified_User, Modified_Time=@Modified_Time")
            Content.AppendLine("Where Group_Id=@Group_Id")
            Content.AppendLine("  And Belong_Employee_Code=@Belong_Employee_Code")
            Content.AppendLine("")


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Group_Name", row.Item("Group_Name"))
                    command.Parameters.AddWithValue("@Belong_Employee_Code", row.Item("Belong_Employee_Code"))
                    command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)

            Return retDS

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

    ''' <summary>
    ''' 信件群組設定
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function UpdateMailGroupDetail(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Update PRJ_Mail_Group_Detail Set EMail=@EMail ,Modified_User=@Modified_User, Modified_Time=@Modified_Time")
            Content.AppendLine("Where Group_Id=@Group_Id")
            Content.AppendLine("  And Belong_Employee_Code=@Belong_Employee_Code")
            Content.AppendLine("  And Employee_Code=@Employee_Code")
            Content.AppendLine("")


            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Belong_Employee_Code", row.Item("Belong_Employee_Code"))
                    command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)

            Return retDS

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

#Region "     刪除 Method "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function DeleteMailGroup(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim GroupID As String = ds.Tables(0).Rows(0).Item("Group_ID")
        Dim BelongEmployeeCode As String = ds.Tables(0).Rows(0).Item("Belong_Employee_Code")
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Delete From PRJ_Mail_Group_Detail Where Group_Id=@Group_Id;")
            Content.AppendLine("Delete From PRJ_Mail_Group Where Group_Id=@Group_Id and Belong_Employee_Code=@Belong_Employee_Code;")
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


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
                    command.Parameters.AddWithValue("@Belong_Employee_Code", BelongEmployeeCode)
                    command.Parameters.AddWithValue("@Group_Id", GroupID)

                    count = command.ExecuteNonQuery
                End Using
                retDS.Tables(0).Rows.Add(count)
                scope.Complete()
            End Using
            Return retDS

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


    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-06-16</remarks>
    Public Function DeleteMailGroupDetail(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim GroupID As String = ds.Tables(0).Rows(0).Item("Group_ID")
        Dim BelongEmployeeCode As String = ds.Tables(0).Rows(0).Item("Belong_Employee_Code")
        Dim EmployeeCode As String = ds.Tables(0).Rows(0).Item("Employee_Code")
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))
        retDS.Tables(0).Columns.Add("Result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("Delete From PRJ_Mail_Group_Detail Where Group_Id=@Group_Id And Belong_Employee_Code=@Belong_Employee_Code And Employee_Code=@Employee_Code;")

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
                command.Parameters.AddWithValue("@Belong_Employee_Code", BelongEmployeeCode)
                command.Parameters.AddWithValue("@Employee_Code", EmployeeCode)
                command.Parameters.AddWithValue("@Group_Id", GroupID)

                count = command.ExecuteNonQuery
            End Using
            retDS.Tables(0).Rows.Add(count)
            Return retDS

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

#Region "     查詢 Method "


    Public Function QueryJobMailGroup(ByVal InputDS As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim GroupID As String = InputDS.Tables(0).Rows(0).Item("Group_ID")
        Dim BelongEmployeeCode As String = InputDS.Tables(0).Rows(0).Item("Belong_Employee_Code")
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("Select RTRIM(Group_Id) Group_Id")
            Content.AppendLine("	  ,RTRIM(Group_Name) Group_Name")
            Content.AppendLine("	  ,RTRIM(PMG.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) As Belong_Employee_Code")
            Content.AppendLine("	  ,RTRIM(PMG.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) AS Create_User")
            Content.AppendLine("	  ,PMG.Create_Time")
            Content.AppendLine("	  ,RTRIM(PMG.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) AS Modified_User")
            Content.AppendLine("	  ,PMG.Modified_Time")
            Content.AppendLine("  From PRJ_Mail_Group PMG")
            Content.AppendLine("Inner Join PUB_Employee PE on PE.Employee_Code= PMG.Belong_Employee_Code")
            Content.AppendLine("Where 1=1")
            Content.AppendLine("And Belong_Employee_Code=@BelongEmployeeCode")
            Content.AppendLine(" And isnull(Temporary,'N')='N'")
            If GroupID.Length > 0 Then
                Content.AppendLine("And Group_Id=@GroupID")
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@GroupID", GroupID)
            command.Parameters.AddWithValue("@BelongEmployeeCode", BelongEmployeeCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PRJ_Mail_Group")
                adapter.Fill(ds, "PRJ_Mail_Group")
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


    Public Function QueryJobMailGroupDetail(ByVal InputDS As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim GroupID As String = InputDS.Tables(0).Rows(0).Item("Group_ID").ToString
        Dim BelongEmployeeCode As String = InputDS.Tables(0).Rows(0).Item("Belong_Employee_Code").ToString
        Dim EmployeeCode As String = InputDS.Tables(0).Rows(0).Item("Employee_Code").ToString
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("            Select RTRIM(Group_Id) Group_Id")
            Content.AppendLine("            	  ,RTRIM(PMGD.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) As Belong_Employee_Name")
            Content.AppendLine("            	  ,RTRIM(PMGD.Employee_Code) + '-' + RTRIM(PE2.Employee_Name) As Employee_Name")
            Content.AppendLine("            	  ,RTRIM(PMGD.EMail) As EMail")
            Content.AppendLine("            	  ,RTRIM(PMGD.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) AS Create_User")
            Content.AppendLine("            	  ,PMGD.Create_Time")
            Content.AppendLine("            	  ,RTRIM(PMGD.Belong_Employee_Code) + '-' + RTRIM(PE.Employee_Name) AS Modified_User")
            Content.AppendLine("            	  ,PMGD.Modified_Time")
            Content.AppendLine("            	  ,PMGD.Employee_Code")
            Content.AppendLine("              From PRJ_Mail_Group_Detail PMGD")
            Content.AppendLine("            Inner Join PUB_Employee PE on PE.Employee_Code= PMGD.Belong_Employee_Code            ")
            Content.AppendLine("			Inner Join PUB_Employee PE2 on PE2.Employee_Code= PMGD.Employee_Code")
            Content.AppendLine("            Where 1=1")
            Content.AppendLine("            And PMGD.Belong_Employee_Code=@BelongEmployeeCode")
            Content.AppendLine("            And PMGD.Group_Id=@GroupID")
            If EmployeeCode.Length > 0 Then
                Content.AppendLine("            And PMGD.Employee_Code=@Employee_Code")
            End If
            Content.AppendLine("       ")
            Content.AppendLine("")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@GroupID", GroupID)
            command.Parameters.AddWithValue("@BelongEmployeeCode", BelongEmployeeCode)
            If EmployeeCode.Length > 0 Then
                command.Parameters.AddWithValue("@Employee_Code", EmployeeCode)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PRJ_Mail_Group_Detail")
                adapter.Fill(ds, "PRJ_Mail_Group_Detail")
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

    Public Function GetMailAddressFromGroup(ByVal JOB_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("Select Substring(SubQuery.Email,2,len(SubQuery.Email)) AS Email From(")
            Content.AppendLine("Select(")
            Content.AppendLine("Select  ',' +  RTRIM(PMGD.EMail) ")
            Content.AppendLine("  From PRJ_Mail_Group PMG")
            Content.AppendLine("Inner Join PRJ_Mail_Group_Detail PMGD On PMGD .Belong_Employee_Code=PMG.Belong_Employee_Code And PMGD.Group_Id=PMG.Group_Id")
            Content.AppendLine("Inner Join JOB_SA_Assign_Record JSAR On JSAR.JOB_Code=@JOB_Code ")
            Content.AppendLine(" Where PMG.Belong_Employee_Code=JSAR.Create_User")
            Content.AppendLine("   And PMG.Group_Id=JSAR.Mail_Group_Id")
            Content.AppendLine("    FOR XML PATH(''))  AS EMail)  SubQuery ")
            Content.AppendLine("")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@JOB_Code", JOB_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("MailGroup")
                adapter.Fill(ds, "MailGroup")
            End Using

            Return ds.Tables(0).Rows(0).Item("EMail").ToString.Trim

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

End Class

