Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class JobSaDbmodifiedRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2017/7/28 下午 08:28:01
    Public Shared ReadOnly tableName As String="JOB_SA_DBModified_Record"
    Private Shared myInstance As JobSaDbmodifiedRecordBO
    Public Shared Function GetInstance() As JobSaDbmodifiedRecordBO
        If myInstance Is Nothing Then
            myInstance = New JobSaDbmodifiedRecordBO()
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
            Dim sqlString As String = "insert into " & tableName & "(" &
            " Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  " &
             " Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  " &
             " Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Project_ID , @Seq_No , @DBA_Employee_Code , @DB_Name , @Table_Name ,  " &
             " @Table_Ch_Name , @Index , @Restrict , @Modified_Classify , @Sql_Script ,  " &
             " @Is_Modified , @Reject_Reason , @Modified_FID , @Create_User , @Create_Time ,  " &
             " @Modified_User , @Modified_Time             )"
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  " &
             " Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  " &
             " Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Project_ID , @Seq_No , @DBA_Employee_Code , @DB_Name , @Table_Name ,  " &
             " @Table_Ch_Name , @Index , @Restrict , @Modified_Classify , @Sql_Script ,  " &
             " @Is_Modified , @Reject_Reason , @Modified_FID , @Create_User , @Create_Time ,  " &
             " @Modified_User , @Modified_Time             )"
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  " &
             " Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  " &
             " Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Project_ID , @Seq_No , @DBA_Employee_Code , @DB_Name , @Table_Name ,  " &
             " @Table_Ch_Name , @Index , @Restrict , @Modified_Classify , @Sql_Script ,  " &
             " @Is_Modified , @Reject_Reason , @Modified_FID , @Create_User , @Create_Time ,  " &
             " @Modified_User , @Modified_Time             )"
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
            " DBA_Employee_Code=@DBA_Employee_Code , DB_Name=@DB_Name , Table_Name=@Table_Name " &
            "  , Table_Ch_Name=@Table_Ch_Name , Index=@Index , Restrict=@Restrict , Modified_Classify=@Modified_Classify , Sql_Script=@Sql_Script " &
            "  , Is_Modified=@Is_Modified , Reject_Reason=@Reject_Reason , Modified_FID=@Modified_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Project_ID=@Project_ID and Seq_No=@Seq_No            "
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " DBA_Employee_Code=@DBA_Employee_Code , DB_Name=@DB_Name , Table_Name=@Table_Name " &
            "  , Table_Ch_Name=@Table_Ch_Name , Index=@Index , Restrict=@Restrict , Modified_Classify=@Modified_Classify , Sql_Script=@Sql_Script " &
            "  , Is_Modified=@Is_Modified , Reject_Reason=@Reject_Reason , Modified_FID=@Modified_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Project_ID=@Project_ID and Seq_No=@Seq_No            "
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
            " DBA_Employee_Code=@DBA_Employee_Code , DB_Name=@DB_Name , Table_Name=@Table_Name " &
            "  , Table_Ch_Name=@Table_Ch_Name , Index=@Index , Restrict=@Restrict , Modified_Classify=@Modified_Classify , Sql_Script=@Sql_Script " &
            "  , Is_Modified=@Is_Modified , Reject_Reason=@Reject_Reason , Modified_FID=@Modified_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Project_ID=@Project_ID and Seq_No=@Seq_No            "
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
                    command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                    command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                    command.Parameters.AddWithValue("@DBA_Employee_Code", row.Item("DBA_Employee_Code"))
                    command.Parameters.AddWithValue("@DB_Name", row.Item("DB_Name"))
                    command.Parameters.AddWithValue("@Table_Name", row.Item("Table_Name"))
                    command.Parameters.AddWithValue("@Table_Ch_Name", row.Item("Table_Ch_Name"))
                    command.Parameters.AddWithValue("@Index", row.Item("Index"))
                    command.Parameters.AddWithValue("@Restrict", row.Item("Restrict"))
                    command.Parameters.AddWithValue("@Modified_Classify", row.Item("Modified_Classify"))
                    command.Parameters.AddWithValue("@Sql_Script", row.Item("Sql_Script"))
                    command.Parameters.AddWithValue("@Is_Modified", row.Item("Is_Modified"))
                    command.Parameters.AddWithValue("@Reject_Reason", row.Item("Reject_Reason"))
                    command.Parameters.AddWithValue("@Modified_FID", row.Item("Modified_FID"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
    Public Function delete(ByRef pk_Project_ID As System.String, ByRef pk_Seq_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " &
            " Project_ID=@Project_ID and Seq_No=@Seq_No "
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
                command.Parameters.AddWithValue("@Project_ID", pk_Project_ID)
                command.Parameters.AddWithValue("@Seq_No", pk_Seq_No)
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
    Public Function queryByPK(ByRef pk_Project_ID As System.String, ByRef pk_Seq_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  ")
            content.AppendLine(" Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  ")
            content.AppendLine(" Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  ")
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Project_ID=@Project_ID and Seq_No=@Seq_No            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Project_ID", pk_Project_ID)
            command.Parameters.AddWithValue("@Seq_No", pk_Seq_No)
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
    Public Function queryByLikePK(ByRef pk_Project_ID As System.String, ByRef pk_Seq_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  ")
            content.AppendLine(" Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  ")
            content.AppendLine(" Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  ")
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Project_ID like @Project_ID and Seq_No like @Seq_No ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Project_ID", pk_Project_ID & "%")
            command.Parameters.AddWithValue("@Seq_No", pk_Seq_No & "%")
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
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  ")
            content.AppendLine(" Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  ")
            content.AppendLine(" Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  ")
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
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
            content.Append("select   Project_ID , Seq_No , DBA_Employee_Code , DB_Name , Table_Name ,  " &
             " Table_Ch_Name , Index , Restrict , Modified_Classify , Sql_Script ,  " &
             " Is_Modified , Reject_Reason , Modified_FID , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time            from " & tableName & " where 1=1 ")
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
    '''取得表格 JOB_SA_DBModified_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
