Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class JobProjectMaintainBO_E1
    Inherits PrjProjectBO
#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobProjectMaintainBO_E1
    Public Overloads Shared Function GetInstance() As JobProjectMaintainBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobProjectMaintainBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region " 專案維護作業 "
#Region "     初始化UI"


#End Region

#Region "     新增"

    Public Function InsertNewProject(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")

        Try
            retDS.Tables(0).Rows.Add(insert(input, conn))

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

        Return Nothing
    End Function

    Public Function InsertNewSystem(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [PRJ_Project_System]")
            Content.AppendLine("           ([Project_ID]")
            Content.AppendLine("           ,[System_Code]")
            Content.AppendLine("           ,[System_Name]")
            Content.AppendLine("           ,[SA_Employee_Code]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Project_ID")
            Content.AppendLine("           ,@System_Code")
            Content.AppendLine("           ,@System_Name")
            Content.AppendLine("           ,@SA_Employee_Code")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,@Create_Time")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In input.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@System_Name", row.Item("System_Name"))
                    command.Parameters.AddWithValue("@SA_Employee_Code", row.Item("SA_Employee_Code"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", Now)
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
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

        Return Nothing
    End Function

    Public Function InsertNewFunction(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [PRJ_Project_System_Function]")
            Content.AppendLine("           ([Project_ID]")
            Content.AppendLine("           ,[System_Code]")
            Content.AppendLine("           ,[Function_Code]")
            Content.AppendLine("           ,[Function_Name]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Project_ID")
            Content.AppendLine("           ,@System_Code")
            Content.AppendLine("           ,@Function_Code")
            Content.AppendLine("           ,@Function_Name")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,@Create_Time")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In input.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Function_Name", row.Item("Function_Name"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", Now)
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
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

        Return Nothing
    End Function

    ''' <summary>
    ''' 專案功能整批匯入
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function ImportSystemAndFunctionList(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Table1"))
        retDS.Tables(0).Columns.Add("System_Total")
        retDS.Tables(0).Columns.Add("System_Count")
        retDS.Tables(0).Columns.Add("Function_Total")
        retDS.Tables(0).Columns.Add("Function_Count")
        Dim SystemCount As Int32 = 0
        Dim FunctionCount As Int32 = 0
        Try


            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Dim SystemDS As New DataSet
                Dim FunctionDS As New DataSet


                For Each dr As DataRow In input.Tables(Project.Comm.JOB.PrjProjectSystemDataTableFactory.tableName).Rows
                    SystemCount += InsertNewSystemOneByOne(dr, conn)
                Next
                For Each dr As DataRow In input.Tables(Project.Comm.JOB.PrjProjectSystemFunctionDataTableFactory.tableName).Rows
                    FunctionCount += InsertNewFunctionOneByOne(dr, conn)
                Next

                retDS.Tables(0).Rows.Add(input.Tables(Project.Comm.JOB.PrjProjectSystemDataTableFactory.tableName).Rows.Count, SystemCount,
                                          input.Tables(Project.Comm.JOB.PrjProjectSystemFunctionDataTableFactory.tableName).Rows.Count, FunctionCount)
                scope.Complete()
            End Using
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
        Return retDS
    End Function
    ''' <summary>
    ''' 單筆新增(整批匯入用)
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function InsertNewSystemOneByOne(ByVal input As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [PRJ_Project_System]")
            Content.AppendLine("           ([Project_ID]")
            Content.AppendLine("           ,[System_Code]")
            Content.AppendLine("           ,[System_Name]")
            Content.AppendLine("           ,[SA_Employee_Code]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Project_ID")
            Content.AppendLine("           ,@System_Code")
            Content.AppendLine("           ,@System_Name")
            Content.AppendLine("           ,@SA_Employee_Code")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,@Create_Time")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Project_ID", input.Item("Project_ID"))
                command.Parameters.AddWithValue("@System_Code", input.Item("System_Code"))
                command.Parameters.AddWithValue("@System_Name", input.Item("System_Name"))
                command.Parameters.AddWithValue("@SA_Employee_Code", input.Item("SA_Employee_Code"))
                command.Parameters.AddWithValue("@Create_User", input.Item("Create_User"))
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", input.Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Try
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                Catch ex As Exception
                    count = 0
                End Try

            End Using
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
        Return 0
    End Function
    ''' <summary>
    ''' 單筆新增(整批匯入用)
    ''' </summary>
    ''' <param name="input"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function InsertNewFunctionOneByOne(ByVal input As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0

            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [PRJ_Project_System_Function]")
            Content.AppendLine("           ([Project_ID]")
            Content.AppendLine("           ,[System_Code]")
            Content.AppendLine("           ,[Function_Code]")
            Content.AppendLine("           ,[Function_Name]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Project_ID")
            Content.AppendLine("           ,@System_Code")
            Content.AppendLine("           ,@Function_Code")
            Content.AppendLine("           ,@Function_Name")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,@Create_Time")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Project_ID", input.Item("Project_ID"))
                command.Parameters.AddWithValue("@System_Code", input.Item("System_Code"))
                command.Parameters.AddWithValue("@Function_Code", input.Item("Function_Code"))
                command.Parameters.AddWithValue("@Function_Name", input.Item("Function_Name"))
                command.Parameters.AddWithValue("@Create_User", input.Item("Create_User"))
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", input.Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Try
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                Catch ex As Exception
                    count = 0
                End Try

            End Using
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

        Return 0
    End Function

#End Region

#Region "     修改"

    Public Function UpdateProject(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE [PRJ_Project]")
            Content.AppendLine("   SET [Project_Name] =  @Project_Name")
            Content.AppendLine("      ,[Start_Date] = @Start_Date ")
            Content.AppendLine("      ,[End_Date] = @End_Date ")
            Content.AppendLine("      ,[Project_Manager] = @Project_Manager")
            Content.AppendLine("      ,[Project_Status] = @Project_Status")
            Content.AppendLine("      ,[Modified_User] = @Modified_User")
            Content.AppendLine("      ,[Modified_Time] = @Modified_Time")
            Content.AppendLine(" WHERE Project_Id =@Project_Id")
            Content.AppendLine("")
            Content.AppendLine("")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In input.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Project_Name", row.Item("Project_Name"))
                    command.Parameters.AddWithValue("@Start_Date", row.Item("Start_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Project_Manager", row.Item("Project_Manager"))
                    command.Parameters.AddWithValue("@Project_Status", row.Item("Project_Status"))
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
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

        Return Nothing
    End Function

    Public Function UpdateProjectSystem(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE [PRJ_Project_System]")
            Content.AppendLine("   SET [System_Name] =  @System_Name")
            Content.AppendLine("      ,[SA_Employee_Code] = @SA_Employee_Code ")
            Content.AppendLine("      ,[Modified_User] = @Modified_User")
            Content.AppendLine("      ,[Modified_Time] = @Modified_Time")
            Content.AppendLine(" WHERE Project_Id =@Project_Id")
            Content.AppendLine("   And System_Code=@System_Code")
            Content.AppendLine("")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In input.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@System_Name", row.Item("System_Name"))
                    command.Parameters.AddWithValue("@SA_Employee_Code", row.Item("SA_Employee_Code"))
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
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

        Return Nothing
    End Function


    Public Function UpdateProjectFunction(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE [PRJ_Project_System_Function]")
            Content.AppendLine("   SET [Function_Name] =  @Function_Name")
            Content.AppendLine("      ,[Modified_User] = @Modified_User")
            Content.AppendLine("      ,[Modified_Time] = @Modified_Time")
            Content.AppendLine("      ,[Dc] = @Dc")
            Content.AppendLine(" WHERE Project_Id =@Project_Id")
            Content.AppendLine("   And System_Code=@System_Code")
            Content.AppendLine("   And Function_Code=@Function_Code")
            Content.AppendLine("")
            Content.AppendLine("")

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            For Each row As DataRow In input.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Function_Name", row.Item("Function_Name"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)
                    command.Parameters.AddWithValue("@Dc", row.Item("Dc"))

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

        Return Nothing
    End Function
#End Region


#Region "     刪除"

    Public Function DeleteProject(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim ProjectID As String = input.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                Dim count As Int32 = 0
                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Dim Content As New StringBuilder
                Content.AppendLine("DELETE FROM PRJ_Project_System_Function Where Project_ID=@Project_ID")


                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)

                    count += command.ExecuteNonQuery
                End Using

                Content.Clear()
                Content.AppendLine("DELETE FROM PRJ_Project_System Where Project_ID=@Project_ID")

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)

                    count += command.ExecuteNonQuery
                End Using

                Content.Clear()
                Content.AppendLine("DELETE FROM PRJ_Project Where Project_ID=@Project_ID")

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)

                    count += command.ExecuteNonQuery
                End Using

                scope.Complete()

                retDS.Tables(0).Rows.Add(count)
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

        Return Nothing
    End Function


    Public Function DeleteProjectSystem(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim ProjectID As String = input.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            Dim SystemCode As String = input.Tables(0).Rows(0).Item("System_Code").ToString.Trim
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                Dim count As Int32 = 0
                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Dim Content As New StringBuilder
                Content.AppendLine("DELETE FROM PRJ_Project_System_Function Where Project_ID=@Project_ID And System_Code=@System_Code")


                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)
                    command.Parameters.AddWithValue("@System_Code", SystemCode)

                    count += command.ExecuteNonQuery
                End Using

                Content.Clear()
                Content.AppendLine("DELETE FROM PRJ_Project_System Where Project_ID=@Project_ID And System_Code=@System_Code")

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)
                    command.Parameters.AddWithValue("@System_Code", SystemCode)

                    count += command.ExecuteNonQuery
                End Using

                scope.Complete()

                retDS.Tables(0).Rows.Add(count)
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

        Return Nothing
    End Function

    Public Function DeleteProjectSystemFunction(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("RESULT")
        retDS.Tables(0).Columns.Add("result")
        Try
            Dim ProjectID As String = input.Tables(0).Rows(0).Item("Project_ID").ToString.Trim
            Dim SystemCode As String = input.Tables(0).Rows(0).Item("System_Code").ToString.Trim
            Dim FunctionCode As String = input.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                Dim count As Int32 = 0
                If connFlag Then
                    conn = GetConnection()
                    conn.Open()
                End If

                Dim Content As New StringBuilder
                Content.AppendLine("DELETE FROM PRJ_Project_System_Function Where Project_ID=@Project_ID and System_Code=@System_Code and Function_Code=@Function_Code")


                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Project_ID", ProjectID)
                    command.Parameters.AddWithValue("@System_Code", SystemCode)
                    command.Parameters.AddWithValue("@Function_Code", FunctionCode)
                    count += command.ExecuteNonQuery
                End Using

                scope.Complete()

                retDS.Tables(0).Rows.Add(count)
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

        Return Nothing
    End Function
#End Region

#Region "     查詢"
    ''' <summary>
    ''' 專案維護作業(查詢專案清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function QueryJobProjectMaintainData(ByVal Project_ID As String, ByVal Project_Name As String, ByVal Start_Date As String, ByVal End_Date As String, ByVal Project_Manager As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("  SELECT RTRIM(PR.Project_ID) Project_ID")
            Content.AppendLine("      ,RTRIM(PR.Project_Name) Project_Name")
            Content.AppendLine("      ,RTRIM(PR.Start_Date) Start_Date ")
            Content.AppendLine("      ,RTRIM(PR.End_Date) End_Date ")
            Content.AppendLine("      ,RTRIM(PR.Project_Manager) Project_Manager ")
            Content.AppendLine("      ,RTRIM(PS.Code_Name) Project_Status ")
            Content.AppendLine("      ,RTRIM(PR.Create_User) Create_User ")
            Content.AppendLine("      ,RTRIM(PR.Create_Time) Create_Time  ")
            Content.AppendLine("      ,RTRIM(PR.Modified_User) Modified_User  ")
            Content.AppendLine("      ,RTRIM(PR.Modified_Time) Modified_Time  ")
            Content.AppendLine("  FROM PRJ_Project PR")
            Content.AppendLine(" Left Join PUB_Syscode PS On PS.Type_Id=10000 And PR. Project_Status=PS.Code_Id")
            Content.AppendLine(" Where 1=1")

            If Project_ID.Length > 0 Then
                Content.AppendLine(" And Project_ID=@Project_ID")
            End If
            If Project_Name.Length > 0 Then
                Content.AppendLine(" And Project_Name=@Project_Name")
            End If
            If Start_Date.Length > 0 Then
                Content.AppendLine(" And Start_Date=@Start_Date")
            End If
            If End_Date.Length > 0 Then
                Content.AppendLine(" And End_Date=@End_Date")
            End If
            If Project_Manager.Length > 0 Then
                Content.AppendLine(" And Project_Manager=@Project_Manager")
            End If
            Content.AppendLine(" Order By Project_Name")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            If Project_ID.Length > 0 Then
                command.Parameters.AddWithValue("@Project_ID", Project_ID)
            End If
            If Project_Name.Length > 0 Then
                command.Parameters.AddWithValue("@Project_Name", Project_Name)
            End If
            If Start_Date.Length > 0 Then
                command.Parameters.AddWithValue("@Start_Date", Start_Date)
            End If
            If End_Date.Length > 0 Then
                command.Parameters.AddWithValue("@End_Date", End_Date)
            End If
            If Project_Manager.Length > 0 Then
                command.Parameters.AddWithValue("@Project_Manager", Project_Manager)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案維護作業(查詢專案清單)"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


    ''' <summary>
    ''' 專案維護作業(查詢系統清單)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-04-14</remarks>
    Public Function QueryJobProjectSystem(ByVal Project_ID As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Project_ID]")
            Content.AppendLine("      ,[System_Code]")
            Content.AppendLine("      ,[System_Name]")
            Content.AppendLine("      ,[SA_Employee_Code]")
            Content.AppendLine("      ,[Create_User]")
            Content.AppendLine("      ,[Create_Time]")
            Content.AppendLine("      ,[Modified_User]")
            Content.AppendLine("      ,[Modified_Time]")
            Content.AppendLine("  FROM [PRJ_Project_System]")
            Content.AppendLine(" Where Project_Id=@Project_Id")
            Content.AppendLine(" Order By System_Name")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Project_ID", Project_ID)


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案維護作業(查詢系統清單)"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function
    ''' <summary>
    ''' 專案維護作業(查詢功能清單)
    ''' </summary>
    ''' <param name="Project_ID"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function QueryJobProjectSystemFunction(ByVal Project_ID As String, ByVal System_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = GetConnection()
                conn.Open()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Project_ID]")
            Content.AppendLine("      ,[System_Code]")
            Content.AppendLine("      ,[Function_Code]")
            Content.AppendLine("      ,[Function_Name]")
            Content.AppendLine("      ,[Dc]")
            Content.AppendLine("      ,[Create_User]")
            Content.AppendLine("      ,[Create_Time]")
            Content.AppendLine("      ,[Modified_User]")
            Content.AppendLine("      ,[Modified_Time]")
            Content.AppendLine("  FROM [PRJ_Project_System_Function]")
            Content.AppendLine("  Where Project_ID=@Project_ID")
            Content.AppendLine("    And System_Code=@System_Code")
            Content.AppendLine(" Order By Function_Name")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Project_ID", Project_ID)
            command.Parameters.AddWithValue("@System_Code", System_Code)


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案維護作業(查詢系統清單)"})
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


#Region "     取得連線"

    Private Function GetConnection() As SqlConnection
        Return Syscom.Server.SQL.SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

#End Region
End Class
