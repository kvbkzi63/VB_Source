Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubAppLogBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:46
    Public Shared ReadOnly tableName As String="PUB_App_Log"
    Private Shared myInstance As PubAppLogBO
    Public Shared Function GetInstance() As PubAppLogBO
        If myInstance Is Nothing Then
            myInstance = New PubAppLogBO()
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
    Public Function insert(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  " & _ 
             " Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  " & _ 
             " Execution_String ) " & _ 
             " values( @Execution_Time , @Execution_IP , @Employee_Code , @Employee_Name , @System_Code ,  " & _ 
             " @Caller_System_Code , @Query_Item_Id , @Result_Count , @Output_Type , @Output_Target_Name ,  " & _ 
             " @Execution_String             )"
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet,ByVal assignTime As DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
             currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  " & _ 
             " Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  " & _ 
             " Execution_String ) " & _ 
             " values( @Execution_Time , @Execution_IP , @Employee_Code , @Employee_Name , @System_Code ,  " & _ 
             " @Caller_System_Code , @Query_Item_Id , @Result_Count , @Output_Type , @Output_Target_Name ,  " & _ 
             " @Execution_String             )"
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  " & _ 
             " Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  " & _ 
             " Execution_String ) " & _ 
             " values( @Execution_Time , @Execution_IP , @Employee_Code , @Employee_Name , @System_Code ,  " & _ 
             " @Caller_System_Code , @Query_Item_Id , @Result_Count , @Output_Type , @Output_Target_Name ,  " & _ 
             " @Execution_String             )"
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function update(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Employee_Name=@Employee_Name , System_Code=@System_Code " & _ 
            "  , Caller_System_Code=@Caller_System_Code , Query_Item_Id=@Query_Item_Id , Result_Count=@Result_Count , Output_Type=@Output_Type , Output_Target_Name=@Output_Target_Name " & _ 
            "  , Execution_String=@Execution_String " & _ 
            " where  Execution_Time=@Execution_Time and Execution_IP=@Execution_IP and Employee_Code=@Employee_Code            "
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Employee_Name=@Employee_Name , System_Code=@System_Code " & _ 
            "  , Caller_System_Code=@Caller_System_Code , Query_Item_Id=@Query_Item_Id , Result_Count=@Result_Count , Output_Type=@Output_Type , Output_Target_Name=@Output_Target_Name " & _ 
            "  , Execution_String=@Execution_String " & _ 
            " where  Execution_Time=@Execution_Time and Execution_IP=@Execution_IP and Employee_Code=@Employee_Code            "
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet,ByVal assignTime As DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Employee_Name=@Employee_Name , System_Code=@System_Code " & _ 
            "  , Caller_System_Code=@Caller_System_Code , Query_Item_Id=@Query_Item_Id , Result_Count=@Result_Count , Output_Type=@Output_Type , Output_Target_Name=@Output_Target_Name " & _ 
            "  , Execution_String=@Execution_String " & _ 
            " where  Execution_Time=@Execution_Time and Execution_IP=@Execution_IP and Employee_Code=@Employee_Code            "
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
                        Command.Parameters.AddWithValue("@Execution_Time", row.Item("Execution_Time"))
                        Command.Parameters.AddWithValue("@Execution_IP", row.Item("Execution_IP"))
                        Command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                        Command.Parameters.AddWithValue("@Employee_Name", row.Item("Employee_Name"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Caller_System_Code", row.Item("Caller_System_Code"))
                        Command.Parameters.AddWithValue("@Query_Item_Id", row.Item("Query_Item_Id"))
                        Command.Parameters.AddWithValue("@Result_Count", row.Item("Result_Count"))
                        Command.Parameters.AddWithValue("@Output_Type", row.Item("Output_Type"))
                        Command.Parameters.AddWithValue("@Output_Target_Name", row.Item("Output_Target_Name"))
                        Command.Parameters.AddWithValue("@Execution_String", row.Item("Execution_String"))
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
    Public Function delete(ByRef pk_Execution_Time As System.DateTime,ByRef pk_Execution_IP As System.String,ByRef pk_Employee_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Execution_Time=@Execution_Time and Execution_IP=@Execution_IP and Employee_Code=@Employee_Code "
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
                Command.Parameters.AddWithValue("@Execution_Time", pk_Execution_Time)
                Command.Parameters.AddWithValue("@Execution_IP", pk_Execution_IP)
                Command.Parameters.AddWithValue("@Employee_Code", pk_Employee_Code)
                count = Command.ExecuteNonQuery
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
    Public Function queryByPK(ByRef pk_Execution_Time As System.DateTime,ByRef pk_Execution_IP As System.String,ByRef pk_Employee_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  ") 
            content.AppendLine(" Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  ") 
            content.AppendLine(" Execution_String                from " & tableName)
            content.AppendLine("   where Execution_Time=@Execution_Time and Execution_IP=@Execution_IP and Employee_Code=@Employee_Code            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Execution_Time",pk_Execution_Time)
            Command.Parameters.AddWithValue("@Execution_IP",pk_Execution_IP)
            Command.Parameters.AddWithValue("@Employee_Code",pk_Employee_Code)
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
    Public Function queryByLikePK(ByRef pk_Execution_Time As System.DateTime,ByRef pk_Execution_IP As System.String,ByRef pk_Employee_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  ") 
            content.AppendLine(" Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  ") 
            content.AppendLine(" Execution_String                from " & tableName)
            content.AppendLine("   where Execution_Time like @Execution_Time and Execution_IP like @Execution_IP and Employee_Code like @Employee_Code "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Execution_Time",pk_Execution_Time & "%")
            Command.Parameters.AddWithValue("@Execution_IP",pk_Execution_IP & "%")
            Command.Parameters.AddWithValue("@Employee_Code",pk_Employee_Code & "%")
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
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  ") 
            content.AppendLine(" Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  ") 
            content.AppendLine(" Execution_String                from " & tableName )
            command.CommandText = content .tostring
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
    Public Function dynamicQuery(ByRef sqlString As String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
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
    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(),Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select   Execution_Time , Execution_IP , Employee_Code , Employee_Name , System_Code ,  " & _ 
             " Caller_System_Code , Query_Item_Id , Result_Count , Output_Type , Output_Target_Name ,  " & _ 
             " Execution_String            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_App_Log 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_App_Log 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class