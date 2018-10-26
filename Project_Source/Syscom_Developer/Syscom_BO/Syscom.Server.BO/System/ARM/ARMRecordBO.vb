Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

''' <summary>
'''
''' </summary>
Public Class ArmRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2014/11/6 下午 03:32:51
    ''' <summary>
    ''' The table name
    ''' </summary>
    Public Shared ReadOnly tableName As String = "ARM_Record"
    ''' <summary>
    ''' My instance
    ''' </summary>
    Private Shared myInstance As ArmRecordBO
    ''' <summary>
    ''' Gets the instance.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetInstance() As ArmRecordBO
        If myInstance Is Nothing Then
            myInstance = New ArmRecordBO()
        End If
        Return myInstance
    End Function

#Region " 新增"

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name " & _
             "  ) " & _
             " values( @Rec_User , @Rec_DateTime , @Sub_System_No , @fun_function_no , @Fun_Function_Name " & _
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 新增(傳入單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="assignTime">傳入單一Create_Time</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name " & _
             "  ) " & _
             " values( @Rec_User , @Rec_DateTime , @Sub_System_No , @fun_function_no , @Fun_Function_Name " & _
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 新增(設定單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name " & _
             "  ) " & _
             " values( @Rec_User , @Rec_DateTime , @Sub_System_No , @fun_function_no , @Fun_Function_Name " & _
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
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
    ''' 更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Sub_System_No=@Sub_System_No , fun_function_no=@fun_function_no , Fun_Function_Name=@Fun_Function_Name " & _
            "  " & _
            " where  Rec_User=@Rec_User and Rec_DateTime=@Rec_DateTime            "
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 更新資料庫內容,設定單一Create_Time
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Sub_System_No=@Sub_System_No , fun_function_no=@fun_function_no , Fun_Function_Name=@Fun_Function_Name " & _
            "  " & _
            " where  Rec_User=@Rec_User and Rec_DateTime=@Rec_DateTime            "
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 更新資料庫內容,傳入單一更新時間
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="assignTime">單一更新時間</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Sub_System_No=@Sub_System_No , fun_function_no=@fun_function_no , Fun_Function_Name=@Fun_Function_Name " & _
            "  " & _
            " where  Rec_User=@Rec_User and Rec_DateTime=@Rec_DateTime            "
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
                    command.Parameters.AddWithValue("@Rec_User", row.Item("Rec_User"))
                    command.Parameters.AddWithValue("@Rec_DateTime", row.Item("Rec_DateTime"))
                    command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    command.Parameters.AddWithValue("@fun_function_no", row.Item("fun_function_no"))
                    command.Parameters.AddWithValue("@Fun_Function_Name", row.Item("Fun_Function_Name"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
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
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <param name="pk_Rec_User">The pk record user.</param>
    ''' <param name="pk_Rec_DateTime">The pk record date time.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Public Function delete(ByRef pk_Rec_User As System.String, ByRef pk_Rec_DateTime As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Rec_User=@Rec_User and Rec_DateTime=@Rec_DateTime "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Rec_User", pk_Rec_User)
                command.Parameters.AddWithValue("@Rec_DateTime", pk_Rec_DateTime)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
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
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <param name="pk_Rec_User">The pk record user.</param>
    ''' <param name="pk_Rec_DateTime">The pk record date time.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    Public Function queryByPK(ByRef pk_Rec_User As System.String, ByRef pk_Rec_DateTime As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Rec_User=@Rec_User and Rec_DateTime=@Rec_DateTime            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Rec_User", pk_Rec_User)
            command.Parameters.AddWithValue("@Rec_DateTime", pk_Rec_DateTime)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢全部
    ''' </summary>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料全部資料內容
    ''' </returns>
    Public Function queryAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name ")
            content.AppendLine("                 from " & tableName)
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 以 SQL String 動態查詢
    ''' </summary>
    ''' <param name="sqlString">查詢的 SQL 字串</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料
    ''' </returns><remarks>
    ''' 不建議直接使用此方法
    ''' </remarks>
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
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 動態查詢
    ''' </summary>
    ''' <param name="columnName">查詢的欄位名稱</param>
    ''' <param name="columnValue">查詢的欄位值</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料
    ''' </returns>
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
            content.Append("select   Rec_User , Rec_DateTime , Sub_System_No , fun_function_no , Fun_Function_Name " & _
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
            Throw sqlex
        Catch ex As Exception
            Throw ex
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
    ''' 取得表格 ARM_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>
    ''' 資料庫連線
    ''' </returns>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function
#End Region

End Class