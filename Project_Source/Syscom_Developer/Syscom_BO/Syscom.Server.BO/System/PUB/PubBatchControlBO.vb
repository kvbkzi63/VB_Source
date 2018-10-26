Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubBatchControlBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName As String="PUB_Batch_Control"
    Private Shared myInstance As PubBatchControlBO
    Public Shared Function GetInstance() As PubBatchControlBO
        If myInstance Is Nothing Then
            myInstance = New PubBatchControlBO()
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
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , PreFun_Seq_No ,  " & _ 
             " PreFun_Function_No , Fun_Function_Desc , ReExecute_Flag , Last_Execute_DateTime , Last_Execute_Result ,  " & _ 
             " Last_Success_DateTime , Total_Count , Success_Count , Fail_Count , Keep_Days ,  " & _ 
             " Person_In_Charge ) " & _ 
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @PreFun_Seq_No ,  " & _ 
             " @PreFun_Function_No , @Fun_Function_Desc , @ReExecute_Flag , @Last_Execute_DateTime , @Last_Execute_Result ,  " & _ 
             " @Last_Success_DateTime , @Total_Count , @Success_Count , @Fail_Count , @Keep_Days ,  " & _ 
             " @Person_In_Charge             )"
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
                        Command.Parameters.AddWithValue("@PreFun_Seq_No", row.Item("PreFun_Seq_No"))
                        Command.Parameters.AddWithValue("@PreFun_Function_No", row.Item("PreFun_Function_No"))
                        Command.Parameters.AddWithValue("@Fun_Function_Desc", row.Item("Fun_Function_Desc"))
                        Command.Parameters.AddWithValue("@ReExecute_Flag", row.Item("ReExecute_Flag"))
                        Command.Parameters.AddWithValue("@Last_Execute_DateTime", row.Item("Last_Execute_DateTime"))
                        Command.Parameters.AddWithValue("@Last_Execute_Result", row.Item("Last_Execute_Result"))
                        Command.Parameters.AddWithValue("@Last_Success_DateTime", row.Item("Last_Success_DateTime"))
                        Command.Parameters.AddWithValue("@Total_Count", row.Item("Total_Count"))
                        Command.Parameters.AddWithValue("@Success_Count", row.Item("Success_Count"))
                        Command.Parameters.AddWithValue("@Fail_Count", row.Item("Fail_Count"))
                        Command.Parameters.AddWithValue("@Keep_Days", row.Item("Keep_Days"))
                        Command.Parameters.AddWithValue("@Person_In_Charge", row.Item("Person_In_Charge"))
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
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , PreFun_Seq_No ,  " & _ 
             " PreFun_Function_No , Fun_Function_Desc , ReExecute_Flag , Last_Execute_DateTime , Last_Execute_Result ,  " & _ 
             " Last_Success_DateTime , Total_Count , Success_Count , Fail_Count , Keep_Days ,  " & _ 
             " Person_In_Charge ) " & _ 
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @PreFun_Seq_No ,  " & _ 
             " @PreFun_Function_No , @Fun_Function_Desc , @ReExecute_Flag , @Last_Execute_DateTime , @Last_Execute_Result ,  " & _ 
             " @Last_Success_DateTime , @Total_Count , @Success_Count , @Fail_Count , @Keep_Days ,  " & _ 
             " @Person_In_Charge             )"
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
                        Command.Parameters.AddWithValue("@PreFun_Seq_No", row.Item("PreFun_Seq_No"))
                        Command.Parameters.AddWithValue("@PreFun_Function_No", row.Item("PreFun_Function_No"))
                        Command.Parameters.AddWithValue("@Fun_Function_Desc", row.Item("Fun_Function_Desc"))
                        Command.Parameters.AddWithValue("@ReExecute_Flag", row.Item("ReExecute_Flag"))
                        Command.Parameters.AddWithValue("@Last_Execute_DateTime", row.Item("Last_Execute_DateTime"))
                        Command.Parameters.AddWithValue("@Last_Execute_Result", row.Item("Last_Execute_Result"))
                        Command.Parameters.AddWithValue("@Last_Success_DateTime", row.Item("Last_Success_DateTime"))
                        Command.Parameters.AddWithValue("@Total_Count", row.Item("Total_Count"))
                        Command.Parameters.AddWithValue("@Success_Count", row.Item("Success_Count"))
                        Command.Parameters.AddWithValue("@Fail_Count", row.Item("Fail_Count"))
                        Command.Parameters.AddWithValue("@Keep_Days", row.Item("Keep_Days"))
                        Command.Parameters.AddWithValue("@Person_In_Charge", row.Item("Person_In_Charge"))
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
            " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , PreFun_Seq_No ,  " & _ 
             " PreFun_Function_No , Fun_Function_Desc , ReExecute_Flag , Last_Execute_DateTime , Last_Execute_Result ,  " & _ 
             " Last_Success_DateTime , Total_Count , Success_Count , Fail_Count , Keep_Days ,  " & _ 
             " Person_In_Charge ) " & _ 
             " values( @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @PreFun_Seq_No ,  " & _ 
             " @PreFun_Function_No , @Fun_Function_Desc , @ReExecute_Flag , @Last_Execute_DateTime , @Last_Execute_Result ,  " & _ 
             " @Last_Success_DateTime , @Total_Count , @Success_Count , @Fail_Count , @Keep_Days ,  " & _ 
             " @Person_In_Charge             )"
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
                        Command.Parameters.AddWithValue("@PreFun_Seq_No", row.Item("PreFun_Seq_No"))
                        Command.Parameters.AddWithValue("@PreFun_Function_No", row.Item("PreFun_Function_No"))
                        Command.Parameters.AddWithValue("@Fun_Function_Desc", row.Item("Fun_Function_Desc"))
                        Command.Parameters.AddWithValue("@ReExecute_Flag", row.Item("ReExecute_Flag"))
                        Command.Parameters.AddWithValue("@Last_Execute_DateTime", row.Item("Last_Execute_DateTime"))
                        Command.Parameters.AddWithValue("@Last_Execute_Result", row.Item("Last_Execute_Result"))
                        Command.Parameters.AddWithValue("@Last_Success_DateTime", row.Item("Last_Success_DateTime"))
                        Command.Parameters.AddWithValue("@Total_Count", row.Item("Total_Count"))
                        Command.Parameters.AddWithValue("@Success_Count", row.Item("Success_Count"))
                        Command.Parameters.AddWithValue("@Fail_Count", row.Item("Fail_Count"))
                        Command.Parameters.AddWithValue("@Keep_Days", row.Item("Keep_Days"))
                        Command.Parameters.AddWithValue("@Person_In_Charge", row.Item("Person_In_Charge"))
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

'Table Without  PKey ==> There is No queryByPK , delete and update method 

#Region " 查詢"

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
            content.AppendLine(" App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , PreFun_Seq_No ,  ") 
            content.AppendLine(" PreFun_Function_No , Fun_Function_Desc , ReExecute_Flag , Last_Execute_DateTime , Last_Execute_Result ,  ") 
            content.AppendLine(" Last_Success_DateTime , Total_Count , Success_Count , Fail_Count , Keep_Days ,  ") 
            content.AppendLine(" Person_In_Charge                from " & tableName )
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
            content.Append("select   App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , PreFun_Seq_No ,  " & _ 
             " PreFun_Function_No , Fun_Function_Desc , ReExecute_Flag , Last_Execute_DateTime , Last_Execute_Result ,  " & _ 
             " Last_Success_DateTime , Total_Count , Success_Count , Fail_Count , Keep_Days ,  " & _ 
             " Person_In_Charge            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Batch_Control 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Batch_Control 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
