Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubPatientBodyrecordBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName As String="PUB_Patient_BodyRecord"
    Private Shared myInstance As PubPatientBodyrecordBO
    Public Shared Function GetInstance() As PubPatientBodyrecordBO
        If myInstance Is Nothing Then
            myInstance = New PubPatientBodyrecordBO()
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
            " Chart_No , Measure_Time , Height , Weight , Pulse ,  " & _ 
             " Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  " & _ 
             " Create_Time , Source_Type_Id , Keyin_Unit ) " & _ 
             " values( @Chart_No , @Measure_Time , @Height , @Weight , @Pulse ,  " & _ 
             " @Breath , @Temperature , @Blood_Pressure , @Blood_Diastolic , @Create_User ,  " & _ 
             " @Create_Time , @Source_Type_Id , @Keyin_Unit             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
            " Chart_No , Measure_Time , Height , Weight , Pulse ,  " & _ 
             " Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  " & _ 
             " Create_Time , Source_Type_Id , Keyin_Unit ) " & _ 
             " values( @Chart_No , @Measure_Time , @Height , @Weight , @Pulse ,  " & _ 
             " @Breath , @Temperature , @Blood_Pressure , @Blood_Diastolic , @Create_User ,  " & _ 
             " @Create_Time , @Source_Type_Id , @Keyin_Unit             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
            " Chart_No , Measure_Time , Height , Weight , Pulse ,  " & _ 
             " Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  " & _ 
             " Create_Time , Source_Type_Id , Keyin_Unit ) " & _ 
             " values( @Chart_No , @Measure_Time , @Height , @Weight , @Pulse ,  " & _ 
             " @Breath , @Temperature , @Blood_Pressure , @Blood_Diastolic , @Create_User ,  " & _ 
             " @Create_Time , @Source_Type_Id , @Keyin_Unit             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
            " Height=@Height , Weight=@Weight , Pulse=@Pulse " & _ 
            "  , Breath=@Breath , Temperature=@Temperature , Blood_Pressure=@Blood_Pressure , Blood_Diastolic=@Blood_Diastolic , Source_Type_Id=@Source_Type_Id , Keyin_Unit=@Keyin_Unit " & _ 
            " where  Chart_No=@Chart_No and Measure_Time=@Measure_Time            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
            " Height=@Height , Weight=@Weight , Pulse=@Pulse " & _ 
            "  , Breath=@Breath , Temperature=@Temperature , Blood_Pressure=@Blood_Pressure , Blood_Diastolic=@Blood_Diastolic , Source_Type_Id=@Source_Type_Id , Keyin_Unit=@Keyin_Unit " & _ 
            " where  Chart_No=@Chart_No and Measure_Time=@Measure_Time            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
            " Height=@Height , Weight=@Weight , Pulse=@Pulse " & _ 
            "  , Breath=@Breath , Temperature=@Temperature , Blood_Pressure=@Blood_Pressure , Blood_Diastolic=@Blood_Diastolic , Source_Type_Id=@Source_Type_Id , Keyin_Unit=@Keyin_Unit " & _ 
            " where  Chart_No=@Chart_No and Measure_Time=@Measure_Time            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Height", row.Item("Height"))
                        Command.Parameters.AddWithValue("@Weight", row.Item("Weight"))
                        Command.Parameters.AddWithValue("@Pulse", row.Item("Pulse"))
                        Command.Parameters.AddWithValue("@Breath", row.Item("Breath"))
                        Command.Parameters.AddWithValue("@Temperature", row.Item("Temperature"))
                        Command.Parameters.AddWithValue("@Blood_Pressure", row.Item("Blood_Pressure"))
                        Command.Parameters.AddWithValue("@Blood_Diastolic", row.Item("Blood_Diastolic"))
                        Command.Parameters.AddWithValue("@Source_Type_Id", row.Item("Source_Type_Id"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
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
    Public Function delete(ByRef pk_Chart_No As System.String,ByRef pk_Measure_Time As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Chart_No=@Chart_No and Measure_Time=@Measure_Time "
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
                Command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
                Command.Parameters.AddWithValue("@Measure_Time", pk_Measure_Time)
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
    Public Function queryByPK(ByRef pk_Chart_No As System.String,ByRef pk_Measure_Time As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , dbo.adtoRoctime(Measure_Time) as Measure_Time , Height , Weight , Pulse ,  ")
            content.AppendLine(" Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  ") 
            content.AppendLine(" Create_Time , Source_Type_Id , Keyin_Unit                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No and Measure_Time=@Measure_Time            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No)
            command.Parameters.AddWithValue("@Measure_Time", CDate(pk_Measure_Time))
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
    Public Function queryByLikePK(ByRef pk_Chart_No As System.String,ByRef pk_Measure_Time As System.DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , dbo.adtoRoctime(Measure_Time) as Measure_Time, Height , Weight , Pulse ,  ")
            content.AppendLine(" Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  ") 
            content.AppendLine(" Create_Time , Source_Type_Id , Keyin_Unit                from " & tableName)
            content.AppendLine("   where Chart_No like @Chart_No and Measure_Time like @Measure_Time "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No & "%")
            command.Parameters.AddWithValue("@Measure_Time", CDate(pk_Measure_Time) & "%")
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
            content.AppendLine(" Chart_No , dbo.adtoRoctime(Measure_Time) as Measure_Time , Height , Weight , Pulse ,  ")
            content.AppendLine(" Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  ") 
            content.AppendLine(" Create_Time , Source_Type_Id , Keyin_Unit                from " & tableName )
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
            content.Append("select   Chart_No , dbo.adtoRoctime(Measure_Time) as Measure_Time , Height , Weight , Pulse ,  " & _
             " Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  " & _
             " Create_Time , Source_Type_Id , Keyin_Unit            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Patient_BodyRecord 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient_BodyRecord 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
