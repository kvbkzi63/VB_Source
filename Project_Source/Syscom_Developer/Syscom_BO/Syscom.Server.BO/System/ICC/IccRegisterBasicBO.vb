Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.ServiceModel
Imports System.Data
Public Class IccRegisterBasicBO
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:37
    Public Shared ReadOnly tableName as String="ICC_Register_Basic"
    Private Shared myInstance As IccRegisterBasicBO
    Public Shared Function GetInstance() As IccRegisterBasicBO
        If myInstance Is Nothing Then
            myInstance = New IccRegisterBasicBO()
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
            " Card_Sn , Name , Idno , Birthday , Sex_Id ,  " & _
             " IssueDate , Cancel_Mard_Id , Insurer_Code , Insurer_Mark_Id , Card_ExpiredDate ,  " & _
             " Count , Baby_Birthday , Births_Mark_ID , Is_Basic_Data , Is_Register_Basic ,  " & _
             " Is_Register_Basic2 , Create_Time ) " & _
             " values( @Card_Sn , @Name , @Idno , @Birthday , @Sex_Id ,  " & _
             " @IssueDate , @Cancel_Mard_Id , @Insurer_Code , @Insurer_Mark_Id , @Card_ExpiredDate ,  " & _
             " @Count , @Baby_Birthday , @Births_Mark_ID , @Is_Basic_Data , @Is_Register_Basic ,  " & _
             " @Is_Register_Basic2 , @Create_Time             )"
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
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                    Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                    Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                    Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                    Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                    Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                    Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                    Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                    Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                    Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                    Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                    Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
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
            " Card_Sn , Name , Idno , Birthday , Sex_Id ,  " & _
             " IssueDate , Cancel_Mard_Id , Insurer_Code , Insurer_Mark_Id , Card_ExpiredDate ,  " & _
             " Count , Baby_Birthday , Births_Mark_ID , Is_Basic_Data , Is_Register_Basic ,  " & _
             " Is_Register_Basic2 , Create_Time ) " & _
             " values( @Card_Sn , @Name , @Idno , @Birthday , @Sex_Id ,  " & _
             " @IssueDate , @Cancel_Mard_Id , @Insurer_Code , @Insurer_Mark_Id , @Card_ExpiredDate ,  " & _
             " @Count , @Baby_Birthday , @Births_Mark_ID , @Is_Basic_Data , @Is_Register_Basic ,  " & _
             " @Is_Register_Basic2 , @Create_Time             )"
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
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                    Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                    Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                    Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                    Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                    Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                    Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                    Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                    Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                    Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                    Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                    Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
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
            " Card_Sn , Name , Idno , Birthday , Sex_Id ,  " & _
             " IssueDate , Cancel_Mard_Id , Insurer_Code , Insurer_Mark_Id , Card_ExpiredDate ,  " & _
             " Count , Baby_Birthday , Births_Mark_ID , Is_Basic_Data , Is_Register_Basic ,  " & _
             " Is_Register_Basic2 , Create_Time ) " & _
             " values( @Card_Sn , @Name , @Idno , @Birthday , @Sex_Id ,  " & _
             " @IssueDate , @Cancel_Mard_Id , @Insurer_Code , @Insurer_Mark_Id , @Card_ExpiredDate ,  " & _
             " @Count , @Baby_Birthday , @Births_Mark_ID , @Is_Basic_Data , @Is_Register_Basic ,  " & _
             " @Is_Register_Basic2 , @Create_Time             )"
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
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                    Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                    Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                    Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                    Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                    Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                    Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                    Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                    Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                    Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                    Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                    Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
                    Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
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
    Public Function queryByPK(ByRef pk_Card_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where Card_Sn=@Card_Sn            "
            Command.Parameters.AddWithValue("@Card_Sn", pk_Card_Sn)
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
    Public Function delete(ByRef pk_Card_Sn as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Card_Sn=@Card_Sn "
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
                Command.Parameters.AddWithValue("@Card_Sn", pk_Card_Sn)
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
            " Name=@Name , Idno=@Idno , Birthday=@Birthday , Sex_Id=@Sex_Id " & _ 
            "  , IssueDate=@IssueDate , Cancel_Mard_Id=@Cancel_Mard_Id , Insurer_Code=@Insurer_Code , Insurer_Mark_Id=@Insurer_Mark_Id , Card_ExpiredDate=@Card_ExpiredDate " & _ 
            "  , Count=@Count , Baby_Birthday=@Baby_Birthday , Births_Mark_ID=@Births_Mark_ID , Is_Basic_Data=@Is_Basic_Data , Is_Register_Basic=@Is_Register_Basic " & _ 
            "  , Is_Register_Basic2=@Is_Register_Basic2 " & _ 
            " where  Card_Sn=@Card_Sn            "
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
                        Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                        Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                        Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                        Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                        Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                        Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                        Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                        Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                        Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                        Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
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
            " Name=@Name , Idno=@Idno , Birthday=@Birthday , Sex_Id=@Sex_Id " & _
            "  , IssueDate=@IssueDate , Cancel_Mard_Id=@Cancel_Mard_Id , Insurer_Code=@Insurer_Code , Insurer_Mark_Id=@Insurer_Mark_Id , Card_ExpiredDate=@Card_ExpiredDate " & _
            "  , Count=@Count , Baby_Birthday=@Baby_Birthday , Births_Mark_ID=@Births_Mark_ID , Is_Basic_Data=@Is_Basic_Data , Is_Register_Basic=@Is_Register_Basic " & _
            "  , Is_Register_Basic2=@Is_Register_Basic2 " & _
            " where  Card_Sn=@Card_Sn            "
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
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                    Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                    Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                    Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                    Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                    Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                    Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                    Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                    Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                    Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                    Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                    Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
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
            " Name=@Name , Idno=@Idno , Birthday=@Birthday , Sex_Id=@Sex_Id " & _
            "  , IssueDate=@IssueDate , Cancel_Mard_Id=@Cancel_Mard_Id , Insurer_Code=@Insurer_Code , Insurer_Mark_Id=@Insurer_Mark_Id , Card_ExpiredDate=@Card_ExpiredDate " & _
            "  , Count=@Count , Baby_Birthday=@Baby_Birthday , Births_Mark_ID=@Births_Mark_ID , Is_Basic_Data=@Is_Basic_Data , Is_Register_Basic=@Is_Register_Basic " & _
            "  , Is_Register_Basic2=@Is_Register_Basic2 " & _
            " where  Card_Sn=@Card_Sn            "
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
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@Name", row.Item("Name"))
                    Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    Command.Parameters.AddWithValue("@Birthday", row.Item("Birthday"))
                    Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                    Command.Parameters.AddWithValue("@IssueDate", row.Item("IssueDate"))
                    Command.Parameters.AddWithValue("@Cancel_Mard_Id", row.Item("Cancel_Mard_Id"))
                    Command.Parameters.AddWithValue("@Insurer_Code", row.Item("Insurer_Code"))
                    Command.Parameters.AddWithValue("@Insurer_Mark_Id", row.Item("Insurer_Mark_Id"))
                    Command.Parameters.AddWithValue("@Card_ExpiredDate", row.Item("Card_ExpiredDate"))
                    Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                    Command.Parameters.AddWithValue("@Baby_Birthday", row.Item("Baby_Birthday"))
                    Command.Parameters.AddWithValue("@Births_Mark_ID", row.Item("Births_Mark_ID"))
                    Command.Parameters.AddWithValue("@Is_Basic_Data", row.Item("Is_Basic_Data"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic", row.Item("Is_Register_Basic"))
                    Command.Parameters.AddWithValue("@Is_Register_Basic2", row.Item("Is_Register_Basic2"))
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
    '''取得表格 ICC_Register_Basic 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 

End Class
