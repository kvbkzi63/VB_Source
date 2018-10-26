Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Server.BO
'Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Public Class NfcNotifierByfunctionBO
    'Roger's CodeGen Produced This VB Code @ 2010/8/24 下午 04:33:51
    Public Shared ReadOnly tableName as String="NFC_Notifier_ByFunction"
    Private Shared myInstance As NfcNotifierByfunctionBO
    Public Shared Function GetInstance() As NfcNotifierByfunctionBO
        If myInstance Is Nothing Then
            myInstance = New NfcNotifierByfunctionBO()
        End If 
        Return myInstance 
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
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from "& tableName
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Notifier_ID ,  " & _
             " Notifier_Name , EMail , Employee_Flag , BBCall_Flag , MSN_Flag ,  " & _
             " OP_Flag , Mail_Flag , Error_Flag , Warn_Flag , Info_Flag " & _
             "  ) " & _
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Notifier_ID ,  " & _
             " @Notifier_Name , @EMail , @Employee_Flag , @BBCall_Flag , @MSN_Flag ,  " & _
             " @OP_Flag , @Mail_Flag , @Error_Flag , @Warn_Flag , @Info_Flag " & _
             "              )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                    Command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                    Command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    Command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                    Command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                    Command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                    Command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                    Command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                    Command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                    Command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                    Command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Notifier_ID ,  " & _
             " Notifier_Name , EMail , Employee_Flag , BBCall_Flag , MSN_Flag ,  " & _
             " OP_Flag , Mail_Flag , Error_Flag , Warn_Flag , Info_Flag " & _
             "  ) " & _
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Notifier_ID ,  " & _
             " @Notifier_Name , @EMail , @Employee_Flag , @BBCall_Flag , @MSN_Flag ,  " & _
             " @OP_Flag , @Mail_Flag , @Error_Flag , @Warn_Flag , @Info_Flag " & _
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
                    command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                    command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                    command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                    command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                    command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                    command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                    command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                    command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                    command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
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
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Notifier_ID ,  " & _
             " Notifier_Name , EMail , Employee_Flag , BBCall_Flag , MSN_Flag ,  " & _
             " OP_Flag , Mail_Flag , Error_Flag , Warn_Flag , Info_Flag " & _
             "  ) " & _
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Notifier_ID ,  " & _
             " @Notifier_Name , @EMail , @Employee_Flag , @BBCall_Flag , @MSN_Flag ,  " & _
             " @OP_Flag , @Mail_Flag , @Error_Flag , @Warn_Flag , @Info_Flag " & _
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
                    command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                    command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                    command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                    command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                    command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                    command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                    command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                    command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                    command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
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
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
                conn = getConnection()
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
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
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select * from " & tableName & " where 1=1 ")
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_App_System_No As System.String, ByRef pk_Sub_System_No As System.String, ByRef pk_Tsk_Task_no As System.String, ByRef pk_Fun_Function_No As System.String, ByRef pk_Notifier_ID As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where App_System_No=@App_System_No and Sub_System_No=@Sub_System_No and Tsk_Task_no=@Tsk_Task_no and Fun_Function_No=@Fun_Function_No and Notifier_ID=@Notifier_ID            "
            Command.Parameters.AddWithValue("@App_System_No", pk_App_System_No)
            Command.Parameters.AddWithValue("@Sub_System_No", pk_Sub_System_No)
            Command.Parameters.AddWithValue("@Tsk_Task_no", pk_Tsk_Task_no)
            Command.Parameters.AddWithValue("@Fun_Function_No", pk_Fun_Function_No)
            Command.Parameters.AddWithValue("@Notifier_ID", pk_Notifier_ID)
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_App_System_No as System.String,ByRef pk_Sub_System_No as System.String,ByRef pk_Tsk_Task_no as System.String,ByRef pk_Fun_Function_No as System.String,ByRef pk_Notifier_ID as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " App_System_No=@App_System_No and Sub_System_No=@Sub_System_No and Tsk_Task_no=@Tsk_Task_no and Fun_Function_No=@Fun_Function_No and Notifier_ID=@Notifier_ID " & _ 
            "  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@App_System_No", pk_App_System_No)
                Command.Parameters.AddWithValue("@Sub_System_No", pk_Sub_System_No)
                Command.Parameters.AddWithValue("@Tsk_Task_no", pk_Tsk_Task_no)
                Command.Parameters.AddWithValue("@Fun_Function_No", pk_Fun_Function_No)
                Command.Parameters.AddWithValue("@Notifier_ID", pk_Notifier_ID)
                count = Command.ExecuteNonQuery
                End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function update(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString as String ="update " & tableName & " set " & _
            " Notifier_Name=@Notifier_Name , EMail=@EMail , Employee_Flag=@Employee_Flag , BBCall_Flag=@BBCall_Flag , MSN_Flag=@MSN_Flag " & _ 
            "  , OP_Flag=@OP_Flag , Mail_Flag=@Mail_Flag , Error_Flag=@Error_Flag , Warn_Flag=@Warn_Flag , Info_Flag=@Info_Flag " & _ 
            "  " & _ 
            " where  App_System_No=@App_System_No and Sub_System_No=@Sub_System_No and Tsk_Task_no=@Tsk_Task_no and Fun_Function_No=@Fun_Function_No and Notifier_ID=@Notifier_ID " & _ 
            "             "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                        Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                        Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                        Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                        Command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                        Command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                        Command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                        Command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                        Command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                        Command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                        Command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                        Command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                        Command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                        Command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                        Command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
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
            Dim sqlString As String = "update " & tableName & " set " & _
            " Notifier_Name=@Notifier_Name , EMail=@EMail , Employee_Flag=@Employee_Flag , BBCall_Flag=@BBCall_Flag , MSN_Flag=@MSN_Flag " & _
            "  , OP_Flag=@OP_Flag , Mail_Flag=@Mail_Flag , Error_Flag=@Error_Flag , Warn_Flag=@Warn_Flag , Info_Flag=@Info_Flag " & _
            "  " & _
            " where  App_System_No=@App_System_No and Sub_System_No=@Sub_System_No and Tsk_Task_no=@Tsk_Task_no and Fun_Function_No=@Fun_Function_No and Notifier_ID=@Notifier_ID " & _
            "             "
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
                    command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                    command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                    command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                    command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                    command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                    command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                    command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                    command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                    command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
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
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
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
            Dim sqlString As String = "update " & tableName & " set " & _
            " Notifier_Name=@Notifier_Name , EMail=@EMail , Employee_Flag=@Employee_Flag , BBCall_Flag=@BBCall_Flag , MSN_Flag=@MSN_Flag " & _
            "  , OP_Flag=@OP_Flag , Mail_Flag=@Mail_Flag , Error_Flag=@Error_Flag , Warn_Flag=@Warn_Flag , Info_Flag=@Info_Flag " & _
            "  " & _
            " where  App_System_No=@App_System_No and Sub_System_No=@Sub_System_No and Tsk_Task_no=@Tsk_Task_no and Fun_Function_No=@Fun_Function_No and Notifier_ID=@Notifier_ID " & _
            "             "
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
                    command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    command.Parameters.AddWithValue("@Notifier_ID", row.Item("Notifier_ID"))
                    command.Parameters.AddWithValue("@Notifier_Name", row.Item("Notifier_Name"))
                    command.Parameters.AddWithValue("@EMail", row.Item("EMail"))
                    command.Parameters.AddWithValue("@Employee_Flag", row.Item("Employee_Flag"))
                    command.Parameters.AddWithValue("@BBCall_Flag", row.Item("BBCall_Flag"))
                    command.Parameters.AddWithValue("@MSN_Flag", row.Item("MSN_Flag"))
                    command.Parameters.AddWithValue("@OP_Flag", row.Item("OP_Flag"))
                    command.Parameters.AddWithValue("@Mail_Flag", row.Item("Mail_Flag"))
                    command.Parameters.AddWithValue("@Error_Flag", row.Item("Error_Flag"))
                    command.Parameters.AddWithValue("@Warn_Flag", row.Item("Warn_Flag"))
                    command.Parameters.AddWithValue("@Info_Flag", row.Item("Info_Flag"))
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
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''取得表格 NFC_Notifier_ByFunction 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 

End Class
