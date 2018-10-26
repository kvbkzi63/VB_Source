Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class JobQaBugRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2017/11/3 上午 10:08:57
    Public Shared ReadOnly tableName As String = "Job_QA_Bug_Record"
    Private Shared myInstance As JobQaBugRecordBO
    Public Shared Function GetInstance() As JobQaBugRecordBO
        If myInstance Is Nothing Then
            myInstance = New JobQaBugRecordBO()
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
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" &
            " Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  " &
             " Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  " &
             " Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Bug_Id , @Version_Id , @System_Code , @Function_Code , @Issue_Subject ,  " &
             " @Issue_Desc , @Issue_Level , @Issue_Classify , @Retest_Date , @Retest_Version ,  " &
             " @Test_Result , @Test_Note , @JOB_Code , @Create_User , @Create_Time ,  " &
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
            " Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  " &
             " Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  " &
             " Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Bug_Id , @Version_Id , @System_Code , @Function_Code , @Issue_Subject ,  " &
             " @Issue_Desc , @Issue_Level , @Issue_Classify , @Retest_Date , @Retest_Version ,  " &
             " @Test_Result , @Test_Note , @JOB_Code , @Create_User , @Create_Time ,  " &
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
            " Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  " &
             " Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  " &
             " Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  " &
             " Modified_User , Modified_Time ) " &
             " values( @Bug_Id , @Version_Id , @System_Code , @Function_Code , @Issue_Subject ,  " &
             " @Issue_Desc , @Issue_Level , @Issue_Classify , @Retest_Date , @Retest_Version ,  " &
             " @Test_Result , @Test_Note , @JOB_Code , @Create_User , @Create_Time ,  " &
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
            " System_Code=@System_Code , Function_Code=@Function_Code , Issue_Subject=@Issue_Subject " &
            "  , Issue_Desc=@Issue_Desc , Issue_Level=@Issue_Level , Issue_Classify=@Issue_Classify , Retest_Date=@Retest_Date , Retest_Version=@Retest_Version " &
            "  , Test_Result=@Test_Result , Test_Note=@Test_Note , JOB_Code=@JOB_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Bug_Id=@Bug_Id and Version_Id=@Version_Id            "
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
            " System_Code=@System_Code , Function_Code=@Function_Code , Issue_Subject=@Issue_Subject " &
            "  , Issue_Desc=@Issue_Desc , Issue_Level=@Issue_Level , Issue_Classify=@Issue_Classify , Retest_Date=@Retest_Date , Retest_Version=@Retest_Version " &
            "  , Test_Result=@Test_Result , Test_Note=@Test_Note , JOB_Code=@JOB_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Bug_Id=@Bug_Id and Version_Id=@Version_Id            "
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
            " System_Code=@System_Code , Function_Code=@Function_Code , Issue_Subject=@Issue_Subject " &
            "  , Issue_Desc=@Issue_Desc , Issue_Level=@Issue_Level , Issue_Classify=@Issue_Classify , Retest_Date=@Retest_Date , Retest_Version=@Retest_Version " &
            "  , Test_Result=@Test_Result , Test_Note=@Test_Note , JOB_Code=@JOB_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " &
            " where  Bug_Id=@Bug_Id and Version_Id=@Version_Id            "
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
                    command.Parameters.AddWithValue("@Bug_Id", row.Item("Bug_Id"))
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))
                    command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                    command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                    command.Parameters.AddWithValue("@Issue_Subject", row.Item("Issue_Subject"))
                    command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                    command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                    command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                    command.Parameters.AddWithValue("@Retest_Date", row.Item("Retest_Date"))
                    command.Parameters.AddWithValue("@Retest_Version", row.Item("Retest_Version"))
                    command.Parameters.AddWithValue("@Test_Result", row.Item("Test_Result"))
                    command.Parameters.AddWithValue("@Test_Note", row.Item("Test_Note"))
                    command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
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
    Public Function delete(ByRef pk_Bug_Id As System.String, ByRef pk_Version_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " &
            " Bug_Id=@Bug_Id and Version_Id=@Version_Id "
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
                command.Parameters.AddWithValue("@Bug_Id", pk_Bug_Id)
                command.Parameters.AddWithValue("@Version_Id", pk_Version_Id)
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
    Public Function queryByPK(ByRef pk_Bug_Id As System.String, ByRef pk_Version_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  ")
            content.AppendLine(" Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  ")
            content.AppendLine(" Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  ")
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Bug_Id=@Bug_Id and Version_Id=@Version_Id            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Bug_Id", pk_Bug_Id)
            command.Parameters.AddWithValue("@Version_Id", pk_Version_Id)
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
    Public Function queryByLikePK(ByRef pk_Bug_Id As System.String, ByRef pk_Version_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  ")
            content.AppendLine(" Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  ")
            content.AppendLine(" Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  ")
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Bug_Id like @Bug_Id and Version_Id like @Version_Id ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Bug_Id", pk_Bug_Id & "%")
            command.Parameters.AddWithValue("@Version_Id", pk_Version_Id & "%")
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
            content.AppendLine(" Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  ")
            content.AppendLine(" Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  ")
            content.AppendLine(" Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  ")
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
            content.Append("select   Bug_Id , Version_Id , System_Code , Function_Code , Issue_Subject ,  " &
             " Issue_Desc , Issue_Level , Issue_Classify , Retest_Date , Retest_Version ,  " &
             " Test_Result , Test_Note , JOB_Code , Create_User , Create_Time ,  " &
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
    '''取得表格 Job_QA_Bug_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
