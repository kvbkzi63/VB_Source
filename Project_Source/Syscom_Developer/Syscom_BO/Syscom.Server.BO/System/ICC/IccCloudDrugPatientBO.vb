Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class IccCloudDrugPatientBO
    'Syscom's CodeGen Produced This VB Code @ 2015/11/19 上午 09:46:21
    Public Shared ReadOnly tableName As String="ICC_Cloud_Drug_Patient"
    Private Shared myInstance As IccCloudDrugPatientBO
    Public Shared Function GetInstance() As IccCloudDrugPatientBO
        If myInstance Is Nothing Then
            myInstance = New IccCloudDrugPatientBO()
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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  " & _
             " FID , Is_Agree , Is_Old_Agree , Cancel , Cancel_User , Cancel_Time ,  " & _
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _
             " values( @Id_No , @Medical_Date , @Chart_No , @Agree_Effect_Date , @Agree_End_Date ,  " & _
             " @FID , @Is_Agree , @Cancel , @Cancel_User , @Cancel_Time ,  " & _
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  " & _
             " FID , Is_Agree , Is_Old_Agree , Cancel , Cancel_User , Cancel_Time ,  " & _
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _
             " values( @Id_No , @Medical_Date , @Chart_No , @Agree_Effect_Date , @Agree_End_Date ,  " & _
             " @FID , @Is_Agree , @Cancel , @Cancel_User , @Cancel_Time ,  " & _
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Old_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  " & _
             " FID , Is_Agree , Is_Old_Agree , Cancel , Cancel_User , Cancel_Time ,  " & _
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _
             " values( @Id_No , @Medical_Date , @Chart_No , @Agree_Effect_Date , @Agree_End_Date ,  " & _
             " @FID , @Is_Agree , @Cancel , @Cancel_User , @Cancel_Time ,  " & _
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Old_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
            Dim sqlString As String = "update " & tableName & " set " & _
            " Chart_No=@Chart_No , Agree_Effect_Date=@Agree_Effect_Date , Agree_End_Date=@Agree_End_Date " & _
            "  , FID=@FID , Is_Agree=@Is_Agree , Is_Old_Agree=@Is_Old_Agree , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Id_No=@Id_No and Medical_Date=@Medical_Date            "
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Old_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
            Dim sqlString As String = "update " & tableName & " set " & _
            " Chart_No=@Chart_No , Agree_Effect_Date=@Agree_Effect_Date , Agree_End_Date=@Agree_End_Date " & _
            "  , FID=@FID , Is_Agree=@Is_Agree , Is_Old_Agree=@Is_Old_Agree , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Id_No=@Id_No and Medical_Date=@Medical_Date            "
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Old_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
            Dim sqlString As String = "update " & tableName & " set " & _
            " Chart_No=@Chart_No , Agree_Effect_Date=@Agree_Effect_Date , Agree_End_Date=@Agree_End_Date " & _
            "  , FID=@FID , Is_Agree=@Is_Agree , Is_Old_Agree=@Is_Old_Agree , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Id_No=@Id_No and Medical_Date=@Medical_Date            "
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
                        Command.Parameters.AddWithValue("@Id_No", row.Item("Id_No"))
                        Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Agree_Effect_Date", row.Item("Agree_Effect_Date"))
                        Command.Parameters.AddWithValue("@Agree_End_Date", row.Item("Agree_End_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                    command.Parameters.AddWithValue("@Is_Agree", row.Item("Is_Agree"))
                    command.Parameters.AddWithValue("@Is_Old_Agree", row.Item("Is_Old_Agree"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
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
    Public Function delete(ByRef pk_Id_No As System.String,ByRef pk_Medical_Date As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Id_No=@Id_No and Medical_Date=@Medical_Date "
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
                Command.Parameters.AddWithValue("@Id_No", pk_Id_No)
                Command.Parameters.AddWithValue("@Medical_Date", pk_Medical_Date)
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
    Public Function queryByPK(ByRef pk_Id_No As System.String,ByRef pk_Medical_Date As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  ") 
            content.AppendLine(" FID , Is_Agree , Cancel , Cancel_User , Cancel_Time ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time, Is_Old_Agree                 from " & tableName)
            content.AppendLine("   where Id_No=@Id_No and Medical_Date=@Medical_Date            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Id_No",pk_Id_No)
            Command.Parameters.AddWithValue("@Medical_Date",pk_Medical_Date)
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
    Public Function queryByLikePK(ByRef pk_Id_No As System.String,ByRef pk_Medical_Date As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  ") 
            content.AppendLine(" FID , Is_Agree , Cancel , Cancel_User , Cancel_Time ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time, Is_Old_Agree                from " & tableName)
            content.AppendLine("   where Id_No like @Id_No and Medical_Date like @Medical_Date "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Id_No",pk_Id_No & "%")
            Command.Parameters.AddWithValue("@Medical_Date",pk_Medical_Date & "%")
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
            content.AppendLine(" Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  ") 
            content.AppendLine(" FID , Is_Agree , Cancel , Cancel_User , Cancel_Time ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time, Is_Old_Agree                from " & tableName)
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
            content.Append("select   Id_No , Medical_Date , Chart_No , Agree_Effect_Date , Agree_End_Date ,  " & _
             " FID , Is_Agree , Cancel , Cancel_User , Cancel_Time ,  " & _
             " Create_User , Create_Time , Modified_User , Modified_Time, Is_Old_Agree            from " & tableName & " where 1=1 ")
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
    '''取得表格 ICC_Cloud_Drug_Patient 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
