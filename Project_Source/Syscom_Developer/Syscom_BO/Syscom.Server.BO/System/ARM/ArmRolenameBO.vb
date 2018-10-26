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
Public Class ArmRolenameBO
    'Syscom's CodeGen Produced This VB Code @ 2016/6/4 上午 11:09:25
    ''' <summary>
    ''' The table name
    ''' </summary>
    Public Shared ReadOnly tableName As String = "ARM_RoleName"
    ''' <summary>
    ''' My instance
    ''' </summary>
    Private Shared myInstance As ArmRolenameBO
    ''' <summary>
    ''' Gets the instance.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetInstance() As ArmRolenameBO
        If myInstance Is Nothing Then
            myInstance = New ArmRolenameBO()
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
    ''' <exception cref="CommonException">CMMCMMB912</exception>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " roleID , roleName , isValid , opd_flag , eis_flag ,  " & _
             " pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  " & _
             " IsAgent , roleMember , del_Flag ) " & _
             " values( @roleID , @roleName , @isValid , @opd_flag , @eis_flag ,  " & _
             " @pcs_flag , @creator_no , @create_datetime , @operator_no , @update_datetime ,  " & _
             " @IsAgent , @roleMember , @del_Flag             )"
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 新增(傳入單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="assignTime">傳入單一Create_Time</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB912</exception>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " roleID , roleName , isValid , opd_flag , eis_flag ,  " & _
             " pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  " & _
             " IsAgent , roleMember , del_Flag ) " & _
             " values( @roleID , @roleName , @isValid , @opd_flag , @eis_flag ,  " & _
             " @pcs_flag , @creator_no , @create_datetime , @operator_no , @update_datetime ,  " & _
             " @IsAgent , @roleMember , @del_Flag             )"
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 新增(設定單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 新增筆數
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB912</exception>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " roleID , roleName , isValid , opd_flag , eis_flag ,  " & _
             " pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  " & _
             " IsAgent , roleMember , del_Flag ) " & _
             " values( @roleID , @roleName , @isValid , @opd_flag , @eis_flag ,  " & _
             " @pcs_flag , @creator_no , @create_datetime , @operator_no , @update_datetime ,  " & _
             " @IsAgent , @roleMember , @del_Flag             )"
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB913</exception>
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " roleName=@roleName , isValid=@isValid , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
            "  , pcs_flag=@pcs_flag , creator_no=@creator_no , create_datetime=@create_datetime , operator_no=@operator_no , update_datetime=@update_datetime " & _
            "  , IsAgent=@IsAgent , roleMember=@roleMember , del_Flag=@del_Flag " & _
            " where  roleID=@roleID            "
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 更新資料庫內容,設定單一Create_Time
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB913</exception>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " roleName=@roleName , isValid=@isValid , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
            "  , pcs_flag=@pcs_flag , creator_no=@creator_no , create_datetime=@create_datetime , operator_no=@operator_no , update_datetime=@update_datetime " & _
            "  , IsAgent=@IsAgent , roleMember=@roleMember , del_Flag=@del_Flag " & _
            " where  roleID=@roleID            "
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 更新資料庫內容,傳入單一更新時間
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="assignTime">單一更新時間</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB913</exception>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " roleName=@roleName , isValid=@isValid , opd_flag=@opd_flag , eis_flag=@eis_flag " & _
            "  , pcs_flag=@pcs_flag , creator_no=@creator_no , create_datetime=@create_datetime , operator_no=@operator_no , update_datetime=@update_datetime " & _
            "  , IsAgent=@IsAgent , roleMember=@roleMember , del_Flag=@del_Flag " & _
            " where  roleID=@roleID            "
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
                    command.Parameters.AddWithValue("@roleID", row.Item("roleID"))
                    command.Parameters.AddWithValue("@roleName", row.Item("roleName"))
                    command.Parameters.AddWithValue("@isValid", row.Item("isValid"))
                    command.Parameters.AddWithValue("@opd_flag", row.Item("opd_flag"))
                    command.Parameters.AddWithValue("@eis_flag", row.Item("eis_flag"))
                    command.Parameters.AddWithValue("@pcs_flag", row.Item("pcs_flag"))
                    command.Parameters.AddWithValue("@creator_no", row.Item("creator_no"))
                    command.Parameters.AddWithValue("@create_datetime", row.Item("create_datetime"))
                    command.Parameters.AddWithValue("@operator_no", row.Item("operator_no"))
                    command.Parameters.AddWithValue("@update_datetime", row.Item("update_datetime"))
                    command.Parameters.AddWithValue("@IsAgent", row.Item("IsAgent"))
                    command.Parameters.AddWithValue("@roleMember", row.Item("roleMember"))
                    command.Parameters.AddWithValue("@del_Flag", row.Item("del_Flag"))
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
    ''' 以ＰＫ刪除資料
    ''' </summary>
    ''' <param name="pk_roleID">The pk role identifier.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB914</exception>
    Public Function delete(ByRef pk_roleID As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " roleID=@roleID "
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
                command.Parameters.AddWithValue("@roleID", pk_roleID)
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
    ''' 以ＰＫ查詢資料
    ''' </summary>
    ''' <param name="pk_roleID">The pk role identifier.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB911</exception>
    Public Function queryByPK(ByRef pk_roleID As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" roleID , roleName , isValid , opd_flag , eis_flag ,  ")
            content.AppendLine(" pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  ")
            content.AppendLine(" IsAgent , roleMember , del_Flag                from " & tableName)
            content.AppendLine("   where roleID=@roleID            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@roleID", pk_roleID)
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
    ''' 以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <param name="pk_roleID">The pk role identifier.</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB911</exception>
    Public Function queryByLikePK(ByRef pk_roleID As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" roleID , roleName , isValid , opd_flag , eis_flag ,  ")
            content.AppendLine(" pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  ")
            content.AppendLine(" IsAgent , roleMember , del_Flag                from " & tableName)
            content.AppendLine("   where roleID like @roleID ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@roleID", pk_roleID & "%")
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
    ''' 查詢全部
    ''' </summary>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料全部資料內容
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB911</exception>
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
            content.AppendLine(" roleID , roleName , isValid , opd_flag , eis_flag ,  ")
            content.AppendLine(" pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  ")
            content.AppendLine(" IsAgent , roleMember , del_Flag                from " & tableName)
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
    ''' 以 SQL String 動態查詢
    ''' </summary>
    ''' <param name="sqlString">查詢的 SQL 字串</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB911</exception>
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
    ''' 動態查詢
    ''' </summary>
    ''' <param name="columnName">查詢的欄位名稱</param>
    ''' <param name="columnValue">查詢的欄位值</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns>
    ''' 查詢資料
    ''' </returns>
    ''' <exception cref="SQLDatabaseException"></exception>
    ''' <exception cref="CommonException">CMMCMMB911</exception>
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
            content.Append("select   roleID , roleName , isValid , opd_flag , eis_flag ,  " & _
             " pcs_flag , creator_no , create_datetime , operator_no , update_datetime ,  " & _
             " IsAgent , roleMember , del_Flag            from " & tableName & " where 1=1 ")
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
    ''' 取得表格 ARM_RoleName 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>
    ''' 資料庫連線
    ''' </returns>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function
#End Region

End Class