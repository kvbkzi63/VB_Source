Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class IccInteractVerify3BO
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:52:39
    Public Shared ReadOnly tableName As String="ICC_Interact_Verify3"
    Private Shared myInstance As IccInteractVerify3BO
    Public Shared Function GetInstance() As IccInteractVerify3BO
        If myInstance Is Nothing Then
            myInstance = New IccInteractVerify3BO()
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
            " Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  " & _ 
             " Max_Value , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Serial_Sn , @ID , @ID_Values , @One_Of_IDs , @Min_Value ,  " & _ 
             " @Max_Value , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  " & _ 
             " Max_Value , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Serial_Sn , @ID , @ID_Values , @One_Of_IDs , @Min_Value ,  " & _ 
             " @Max_Value , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  " & _ 
             " Max_Value , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Serial_Sn , @ID , @ID_Values , @One_Of_IDs , @Min_Value ,  " & _ 
             " @Max_Value , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
            " ID=@ID , ID_Values=@ID_Values , One_Of_IDs=@One_Of_IDs , Min_Value=@Min_Value " & _ 
            "  , Max_Value=@Max_Value , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Serial_Sn=@Serial_Sn            "
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " ID=@ID , ID_Values=@ID_Values , One_Of_IDs=@One_Of_IDs , Min_Value=@Min_Value " & _ 
            "  , Max_Value=@Max_Value , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Serial_Sn=@Serial_Sn            "
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
            " ID=@ID , ID_Values=@ID_Values , One_Of_IDs=@One_Of_IDs , Min_Value=@Min_Value " & _ 
            "  , Max_Value=@Max_Value , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Serial_Sn=@Serial_Sn            "
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
                        Command.Parameters.AddWithValue("@Serial_Sn", row.Item("Serial_Sn"))
                        Command.Parameters.AddWithValue("@ID", row.Item("ID"))
                        Command.Parameters.AddWithValue("@ID_Values", row.Item("ID_Values"))
                        Command.Parameters.AddWithValue("@One_Of_IDs", row.Item("One_Of_IDs"))
                        Command.Parameters.AddWithValue("@Min_Value", row.Item("Min_Value"))
                        Command.Parameters.AddWithValue("@Max_Value", row.Item("Max_Value"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
    Public Function delete(ByRef pk_Serial_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Serial_Sn=@Serial_Sn "
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
                Command.Parameters.AddWithValue("@Serial_Sn", pk_Serial_Sn)
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
    Public Function queryByPK(ByRef pk_Serial_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  ") 
            content.AppendLine(" Max_Value , Create_User , Create_Time , Modified_User , Modified_Time ") 
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Serial_Sn=@Serial_Sn            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Serial_Sn",pk_Serial_Sn)
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
    Public Function queryByLikePK(ByRef pk_Serial_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  ") 
            content.AppendLine(" Max_Value , Create_User , Create_Time , Modified_User , Modified_Time ") 
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Serial_Sn like @Serial_Sn "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Serial_Sn",pk_Serial_Sn & "%")
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
            content.AppendLine(" Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  ") 
            content.AppendLine(" Max_Value , Create_User , Create_Time , Modified_User , Modified_Time ") 
            content.AppendLine("                 from " & tableName )
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
            content.Append("select   Serial_Sn , ID , ID_Values , One_Of_IDs , Min_Value ,  " & _ 
             " Max_Value , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "             from " & tableName & " where 1=1 ")
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
    '''取得表格 ICC_Interact_Verify3 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region

End Class
