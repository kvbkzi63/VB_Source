Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.ServiceModel
Imports System.Data
''' <summary>
'''
''' </summary>
Public Class ArmRolerightsBO
    'Syscom's CodeGen Produced This VB Code @ 2012/12/19 下午 03:58:28
    ''' <summary>
    ''' The table name
    ''' </summary>
    Public Shared ReadOnly tableName As String = "arm_rolerights"
    ''' <summary>
    ''' My instance
    ''' </summary>
    Private Shared myInstance As ArmRolerightsBO
    ''' <summary>
    ''' Gets the instance.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetInstance() As ArmRolerightsBO
        If myInstance Is Nothing Then
            myInstance = New ArmRolerightsBO()
        End If
        Return myInstance
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
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from " & tableName
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
    ''' 新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD002</exception>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " rrs_role_id , rrs_rights_id , rrs_rights_type , opd_flag , eis_flag ,  " & _
             " pcs_flag ,btnInsert_flag,btnUpdate_flag,btnDelete_flag,btnQuery_flag,btnSave_flag,btnPrint_flag) " & _
             " values( @rrs_role_id , @rrs_rights_id , @rrs_rights_type , @opd_flag , @eis_flag ,  " & _
             " @pcs_flag    ,@btnInsert_flag,@btnUpdate_flag,@btnDelete_flag,@btnQuery_flag,@btnSave_flag,@btnPrint_flag         )"
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
    ''' <exception cref="CommonException">CMMCMMD002</exception>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
      " rrs_role_id , rrs_rights_id , rrs_rights_type , opd_flag , eis_flag ,  " & _
       " pcs_flag ,btnInsert_flag,btnUpdate_flag,btnDelete_flag,btnQuery_flag,btnSave_flag,btnPrint_flag) " & _
       " values( @rrs_role_id , @rrs_rights_id , @rrs_rights_type , @opd_flag , @eis_flag ,  " & _
       " @pcs_flag    ,@btnInsert_flag,@btnUpdate_flag,@btnDelete_flag,@btnQuery_flag,@btnSave_flag,@btnPrint_flag         )"
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
    ''' <exception cref="CommonException">CMMCMMD002</exception>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
  " rrs_role_id , rrs_rights_id , rrs_rights_type , opd_flag , eis_flag ,  " & _
   " pcs_flag ,btnInsert_flag,btnUpdate_flag,btnDelete_flag,btnQuery_flag,btnSave_flag,btnPrint_flag) " & _
   " values( @rrs_role_id , @rrs_rights_id , @rrs_rights_type , @opd_flag , @eis_flag ,  " & _
   " @pcs_flag    ,@btnInsert_flag,@btnUpdate_flag,@btnDelete_flag,@btnQuery_flag,@btnSave_flag,@btnPrint_flag         )"
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
                conn = getAuthenticConnection()
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <param name="pk_rrs_role_id">The pk RRS role identifier.</param>
    ''' <param name="pk_rrs_rights_id">The pk RRS rights identifier.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD001</exception>
    Public Function queryByPK(ByRef pk_rrs_role_id As System.String, ByRef pk_rrs_rights_id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where rrs_role_id=@rrs_role_id and rrs_rights_id=@rrs_rights_id            "
            command.Parameters.AddWithValue("@rrs_role_id", pk_rrs_role_id)
            command.Parameters.AddWithValue("@rrs_rights_id", pk_rrs_rights_id)
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
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <param name="pk_rrs_role_id">The pk RRS role identifier.</param>
    ''' <param name="pk_rrs_rights_id">The pk RRS rights identifier.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD004</exception>
    Public Function delete(ByRef pk_rrs_role_id As System.String, ByRef pk_rrs_rights_id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " rrs_role_id=@rrs_role_id and rrs_rights_id=@rrs_rights_id "
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
                command.Parameters.AddWithValue("@rrs_role_id", pk_rrs_role_id)
                command.Parameters.AddWithValue("@rrs_rights_id", pk_rrs_rights_id)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMD003</exception>
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " rrs_rights_type=@rrs_rights_type , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
            "  , pcs_flag=@pcs_flag ,btnInsert_flag = @btnInsert_flag ,btnUpdate_flag = @btnUpdate_flag ,btnDelete_flag = @btnDelete_flag " & _
            ",btnQuery_flag = @btnQuery_flag ,btnSave_flag = @btnSave_flag ,btnPrint_flag = @btnPrint_flag) " & _
            " where  rrs_role_id=@rrs_role_id and rrs_rights_id=@rrs_rights_id            "
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
    ''' <exception cref="CommonException">CMMCMMD003</exception>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
       " rrs_rights_type=@rrs_rights_type , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
       "  , pcs_flag=@pcs_flag ,btnInsert_flag = @btnInsert_flag ,btnUpdate_flag = @btnUpdate_flag ,btnDelete_flag = @btnDelete_flag " & _
       ",btnQuery_flag = @btnQuery_flag ,btnSave_flag = @btnSave_flag ,btnPrint_flag = @btnPrint_flag) " & _
       " where  rrs_role_id=@rrs_role_id and rrs_rights_id=@rrs_rights_id            "
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
    ''' <exception cref="CommonException">CMMCMMD003</exception>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
    " rrs_rights_type=@rrs_rights_type , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
    "  , pcs_flag=@pcs_flag ,btnInsert_flag = @btnInsert_flag ,btnUpdate_flag = @btnUpdate_flag ,btnDelete_flag = @btnDelete_flag " & _
    ",btnQuery_flag = @btnQuery_flag ,btnSave_flag = @btnSave_flag ,btnPrint_flag = @btnPrint_flag) " & _
    " where  rrs_role_id=@rrs_role_id and rrs_rights_id=@rrs_rights_id            "
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
                    command.Parameters.AddWithValue("@rrs_role_id", row.Item("rrs_role_id"))
                    command.Parameters.AddWithValue("@rrs_rights_id", row.Item("rrs_rights_id"))
                    command.Parameters.AddWithValue("@rrs_rights_type", row.Item("rrs_rights_type"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))

                    command.Parameters.AddWithValue("@btnInsert_flag", row.Item("btnInsert_flag"))
                    command.Parameters.AddWithValue("@btnUpdate_flag", row.Item("btnUpdate_flag"))
                    command.Parameters.AddWithValue("@btnDelete_flag", row.Item("btnDelete_flag"))
                    command.Parameters.AddWithValue("@btnQuery_flag", row.Item("btnQuery_flag"))
                    command.Parameters.AddWithValue("@btnSave_flag", row.Item("btnSave_flag"))
                    command.Parameters.AddWithValue("@btnPrint_flag", row.Item("btnPrint_flag"))

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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 取得表格 arm_rolerights 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>
    ''' 資料庫連線
    ''' </returns>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    ''' <summary>
    ''' 取得表格 arm_rolerights 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上
    ''' </summary>
    ''' <returns>
    ''' 資料庫連線
    ''' </returns><remarks>
    ''' queryByPK 目前也用這個，因為是單檔查詢且為 PK 條件
    ''' </remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function

End Class