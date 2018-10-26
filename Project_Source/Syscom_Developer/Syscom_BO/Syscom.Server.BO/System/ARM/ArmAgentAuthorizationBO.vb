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
Public Class ArmAgentAuthorizationBO
    'Syscom's CodeGen Produced This VB Code @ 2014/11/28 下午 01:17:49
    ''' <summary>
    ''' The table name
    ''' </summary>
    Public Shared ReadOnly tableName As String = "ARM_Agent_Authorization"
    ''' <summary>
    ''' My instance
    ''' </summary>
    Private Shared myInstance As ArmAgentAuthorizationBO
    ''' <summary>
    ''' Gets the instance.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetInstance() As ArmAgentAuthorizationBO
        If myInstance Is Nothing Then
            myInstance = New ArmAgentAuthorizationBO()
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date " & _
             "  ) " & _
             " values( @Employee_Code , @Agent_Employee_Code , @Role_Id , @Effect_Date , @End_Date " & _
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date " & _
             "  ) " & _
             " values( @Employee_Code , @Agent_Employee_Code , @Role_Id , @Effect_Date , @End_Date " & _
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date " & _
             "  ) " & _
             " values( @Employee_Code , @Agent_Employee_Code , @Role_Id , @Effect_Date , @End_Date " & _
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date " & _
            "  " & _
            " where  Employee_Code=@Employee_Code and Agent_Employee_Code=@Agent_Employee_Code and Role_Id=@Role_Id and Effect_Date=@Effect_Date            "
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date " & _
            "  " & _
            " where  Employee_Code=@Employee_Code and Agent_Employee_Code=@Agent_Employee_Code and Role_Id=@Role_Id and Effect_Date=@Effect_Date            "
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date " & _
            "  " & _
            " where  Employee_Code=@Employee_Code and Agent_Employee_Code=@Agent_Employee_Code and Role_Id=@Role_Id and Effect_Date=@Effect_Date            "
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
                    command.Parameters.AddWithValue("@Employee_Code", row.Item("Employee_Code"))
                    command.Parameters.AddWithValue("@Agent_Employee_Code", row.Item("Agent_Employee_Code"))
                    command.Parameters.AddWithValue("@Role_Id", row.Item("Role_Id"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <param name="pk_Employee_Code">The pk employee code.</param>
    ''' <param name="pk_Agent_Employee_Code">The pk agent employee code.</param>
    ''' <param name="pk_Role_Id">The pk role identifier.</param>
    ''' <param name="pk_Effect_Date">The pk effect date.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function delete(ByRef pk_Employee_Code As System.String, ByRef pk_Agent_Employee_Code As System.String, ByRef pk_Role_Id As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Employee_Code=@Employee_Code and Agent_Employee_Code=@Agent_Employee_Code and Role_Id=@Role_Id and Effect_Date=@Effect_Date "
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
                command.Parameters.AddWithValue("@Employee_Code", pk_Employee_Code)
                command.Parameters.AddWithValue("@Agent_Employee_Code", pk_Agent_Employee_Code)
                command.Parameters.AddWithValue("@Role_Id", pk_Role_Id)
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <param name="pk_Employee_Code">The pk employee code.</param>
    ''' <param name="pk_Agent_Employee_Code">The pk agent employee code.</param>
    ''' <param name="pk_Role_Id">The pk role identifier.</param>
    ''' <param name="pk_Effect_Date">The pk effect date.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function queryByPK(ByRef pk_Employee_Code As System.String, ByRef pk_Agent_Employee_Code As System.String, ByRef pk_Role_Id As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Employee_Code=@Employee_Code and Agent_Employee_Code=@Agent_Employee_Code and Role_Id=@Role_Id and Effect_Date=@Effect_Date            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Employee_Code", pk_Employee_Code)
            command.Parameters.AddWithValue("@Agent_Employee_Code", pk_Agent_Employee_Code)
            command.Parameters.AddWithValue("@Role_Id", pk_Role_Id)
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <param name="pk_Employee_Code">The pk employee code.</param>
    ''' <param name="pk_Agent_Employee_Code">The pk agent employee code.</param>
    ''' <param name="pk_Role_Id">The pk role identifier.</param>
    ''' <param name="pk_Effect_Date">The pk effect date.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function queryByLikePK(ByRef pk_Employee_Code As System.String, ByRef pk_Agent_Employee_Code As System.String, ByRef pk_Role_Id As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Employee_Code like @Employee_Code and Agent_Employee_Code like @Agent_Employee_Code and Role_Id like @Role_Id and Effect_Date like @Effect_Date   ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Employee_Code", pk_Employee_Code & "%")
            command.Parameters.AddWithValue("@Agent_Employee_Code", pk_Agent_Employee_Code & "%")
            command.Parameters.AddWithValue("@Role_Id", pk_Role_Id & "%")
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date & "%")
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
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
            content.AppendLine(" Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date ")
            content.AppendLine("                 from " & tableName)
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    ''' <remarks>
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
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
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
            content.Append("select   Employee_Code , Agent_Employee_Code , Role_Id , Effect_Date , End_Date " & _
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
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' 取得表格 ARM_Agent_Authorization 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>
    ''' 資料庫連線
    ''' </returns>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function
#End Region

End Class