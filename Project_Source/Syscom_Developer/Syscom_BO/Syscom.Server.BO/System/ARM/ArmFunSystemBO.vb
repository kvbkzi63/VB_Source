Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class ArmFunSystemBO
    'Syscom's CodeGen Produced This VB Code @ 2017/11/15 上午 10:09:59
    Public Shared ReadOnly tableName As String = "ARM_Fun_System"
    Private Shared myInstance As ArmFunSystemBO
    Public Shared Function GetInstance() As ArmFunSystemBO
        If myInstance Is Nothing Then
            myInstance = New ArmFunSystemBO()
        End If
        Return myInstance
    End Function

#Region " 新增"

    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" &
            " fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  " &
             " fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  " &
             " fun_update_datetime , Fun_System_Memo ) " &
             " values( @fun_function_no , @fun_function_name , @fun_task_no , @fun_content , @fun_special_flag ,  " &
             " @fun_display_order , @fun_flag_no , @fun_creator_no , @fun_create_datetime , @fun_operator_no ,  " &
             " @fun_update_datetime , @Fun_System_Memo             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_creator_no", row.Item("fun_creator_no"))
                    command.Parameters.AddWithValue("@fun_create_datetime", Now)
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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

    ''' <summary>
    '''新增(傳入單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="assignTime">傳入單一Create_Time</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" &
            " fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  " &
             " fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  " &
             " fun_update_datetime , Fun_System_Memo ) " &
             " values( @fun_function_no , @fun_function_name , @fun_task_no , @fun_content , @fun_special_flag ,  " &
             " @fun_display_order , @fun_flag_no , @fun_creator_no , @fun_create_datetime , @fun_operator_no ,  " &
             " @fun_update_datetime , @Fun_System_Memo             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_creator_no", row.Item("fun_creator_no"))
                    command.Parameters.AddWithValue("@fun_create_datetime", Now)
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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

    ''' <summary>
    '''新增(設定單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" &
            " fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  " &
             " fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  " &
             " fun_update_datetime , Fun_System_Memo ) " &
             " values( @fun_function_no , @fun_function_name , @fun_task_no , @fun_content , @fun_special_flag ,  " &
             " @fun_display_order , @fun_flag_no , @fun_creator_no , @fun_create_datetime , @fun_operator_no ,  " &
             " @fun_update_datetime , @Fun_System_Memo             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_creator_no", row.Item("fun_creator_no"))
                    command.Parameters.AddWithValue("@fun_create_datetime", Now)
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " &
            " fun_function_name=@fun_function_name , fun_task_no=@fun_task_no , fun_content=@fun_content , fun_special_flag=@fun_special_flag " &
            "  , fun_display_order=@fun_display_order , fun_flag_no=@fun_flag_no, fun_operator_no=@fun_operator_no " &
            "  , fun_update_datetime=@fun_update_datetime , Fun_System_Memo=@Fun_System_Memo " &
            " where  fun_function_no=@fun_function_no            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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

    ''' <summary>
    '''更新資料庫內容,設定單一Create_Time
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " &
            " fun_function_name=@fun_function_name , fun_task_no=@fun_task_no , fun_content=@fun_content , fun_special_flag=@fun_special_flag " &
            "  , fun_display_order=@fun_display_order , fun_flag_no=@fun_flag_no ,  fun_operator_no=@fun_operator_no " &
            "  , fun_update_datetime=@fun_update_datetime , Fun_System_Memo=@Fun_System_Memo " &
            " where  fun_function_no=@fun_function_no            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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

    ''' <summary>
    '''更新資料庫內容,傳入單一更新時間
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="assignTime">單一更新時間</param>
    ''' <remarks></remarks>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " &
            " fun_function_name=@fun_function_name , fun_task_no=@fun_task_no , fun_content=@fun_content , fun_special_flag=@fun_special_flag " &
            "  , fun_display_order=@fun_display_order , fun_flag_no=@fun_flag_no ,   fun_operator_no=@fun_operator_no " &
            "  , fun_update_datetime=@fun_update_datetime , Fun_System_Memo=@Fun_System_Memo " &
            " where  fun_function_no=@fun_function_no            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@fun_function_name", row.Item("fun_function_name"))
                    command.Parameters.AddWithValue("@fun_task_no", row.Item("fun_task_no"))
                    command.Parameters.AddWithValue("@fun_content", row.Item("fun_content"))
                    command.Parameters.AddWithValue("@fun_special_flag", row.Item("fun_special_flag"))
                    command.Parameters.AddWithValue("@fun_display_order", row.Item("fun_display_order"))
                    command.Parameters.AddWithValue("@fun_flag_no", row.Item("fun_flag_no"))
                    command.Parameters.AddWithValue("@fun_operator_no", row.Item("fun_operator_no"))
                    command.Parameters.AddWithValue("@fun_update_datetime", Now)
                    command.Parameters.AddWithValue("@Fun_System_Memo", row.Item("Fun_System_Memo"))
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

#Region " 刪除"

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_fun_function_no As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " &
            " fun_function_no=@fun_function_no "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@fun_function_no", pk_fun_function_no)
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

#Region " 查詢"

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_fun_function_no As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  ")
            content.AppendLine(" fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  ")
            content.AppendLine(" fun_update_datetime , Fun_System_Memo                from " & tableName)
            content.AppendLine("   where fun_function_no=@fun_function_no            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@fun_function_no", pk_fun_function_no)
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

    ''' <summary>
    '''以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByLikePK(ByRef pk_fun_function_no As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  ")
            content.AppendLine(" fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  ")
            content.AppendLine(" fun_update_datetime , Fun_System_Memo                from " & tableName)
            content.AppendLine("   where fun_function_no like @fun_function_no ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@fun_function_no", pk_fun_function_no & "%")
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

    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  ")
            content.AppendLine(" fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  ")
            content.AppendLine(" fun_update_datetime , Fun_System_Memo                from " & tableName)
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

    ''' <summary>
    '''以 SQL String 動態查詢
    ''' </summary>
    ''' <param name="sqlString">查詢的 SQL 字串</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks>不建議直接使用此方法</remarks>
    Public Function dynamicQuery(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
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

    ''' <summary>
    '''動態查詢
    ''' </summary>
    ''' <param name="columnName">查詢的欄位名稱</param>
    ''' <param name="columnValue">查詢的欄位值</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks></remarks>
    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select   fun_function_no , fun_function_name , fun_task_no , fun_content , fun_special_flag ,  " &
             " fun_display_order , fun_flag_no , fun_creator_no , fun_create_datetime , fun_operator_no ,  " &
             " fun_update_datetime , Fun_System_Memo            from " & tableName & " where 1=1 ")
            For i = 0 To columnName.Length - 1
                content.Append("and ").Append(columnName(i)).Append("=@").Append(columnName(i)).AppendLine(" ")
            Next
            command.CommandText = content.ToString
            For i = 0 To columnName.Length - 1
                command.Parameters.AddWithValue("@" & columnName(i), columnValue(i))
            Next
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

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 ARM_Fun_System 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function
#End Region

End Class
