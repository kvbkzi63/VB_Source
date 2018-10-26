Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class PubExportDetailBO
    'Syscom's CodeGen Produced This VB Code @ 2017/12/6 上午 08:41:14
    Public Shared ReadOnly tableName As String="PUB_Export_Detail"
    Private Shared myInstance As PubExportDetailBO
    Public Shared Function GetInstance() As PubExportDetailBO
        If myInstance Is Nothing Then
            myInstance = New PubExportDetailBO()
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
            " Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  " & _ 
             " Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  " & _ 
             " Cbo_Source_Data ) " & _ 
             " values( @Report_Id , @Sort_No , @Field_Name , @Field_Code , @Field_Description ,  " & _ 
             " @Form_Control_Type , @Is_Nreq , @Field_Nreq_Cond , @Field_Nreq_Code , @Default_Value ,  " & _ 
             " @Cbo_Source_Data             )"
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
            " Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  " & _ 
             " Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  " & _ 
             " Cbo_Source_Data ) " & _ 
             " values( @Report_Id , @Sort_No , @Field_Name , @Field_Code , @Field_Description ,  " & _ 
             " @Form_Control_Type , @Is_Nreq , @Field_Nreq_Cond , @Field_Nreq_Code , @Default_Value ,  " & _ 
             " @Cbo_Source_Data             )"
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
            " Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  " & _ 
             " Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  " & _ 
             " Cbo_Source_Data ) " & _ 
             " values( @Report_Id , @Sort_No , @Field_Name , @Field_Code , @Field_Description ,  " & _ 
             " @Form_Control_Type , @Is_Nreq , @Field_Nreq_Cond , @Field_Nreq_Code , @Default_Value ,  " & _ 
             " @Cbo_Source_Data             )"
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
            " Field_Name=@Field_Name , Field_Code=@Field_Code , Field_Description=@Field_Description " & _ 
            "  , Form_Control_Type=@Form_Control_Type , Is_Nreq=@Is_Nreq , Field_Nreq_Cond=@Field_Nreq_Cond , Field_Nreq_Code=@Field_Nreq_Code , Default_Value=@Default_Value " & _ 
            "  , Cbo_Source_Data=@Cbo_Source_Data " & _ 
            " where  Report_Id=@Report_Id and Sort_No=@Sort_No            "
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
            " Field_Name=@Field_Name , Field_Code=@Field_Code , Field_Description=@Field_Description " & _ 
            "  , Form_Control_Type=@Form_Control_Type , Is_Nreq=@Is_Nreq , Field_Nreq_Cond=@Field_Nreq_Cond , Field_Nreq_Code=@Field_Nreq_Code , Default_Value=@Default_Value " & _ 
            "  , Cbo_Source_Data=@Cbo_Source_Data " & _ 
            " where  Report_Id=@Report_Id and Sort_No=@Sort_No            "
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
            " Field_Name=@Field_Name , Field_Code=@Field_Code , Field_Description=@Field_Description " & _ 
            "  , Form_Control_Type=@Form_Control_Type , Is_Nreq=@Is_Nreq , Field_Nreq_Cond=@Field_Nreq_Cond , Field_Nreq_Code=@Field_Nreq_Code , Default_Value=@Default_Value " & _ 
            "  , Cbo_Source_Data=@Cbo_Source_Data " & _ 
            " where  Report_Id=@Report_Id and Sort_No=@Sort_No            "
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
                        Command.Parameters.AddWithValue("@Report_Id", row.Item("Report_Id"))
                        Command.Parameters.AddWithValue("@Sort_No", row.Item("Sort_No"))
                        Command.Parameters.AddWithValue("@Field_Name", row.Item("Field_Name"))
                        Command.Parameters.AddWithValue("@Field_Code", row.Item("Field_Code"))
                        Command.Parameters.AddWithValue("@Field_Description", row.Item("Field_Description"))
                        Command.Parameters.AddWithValue("@Form_Control_Type", row.Item("Form_Control_Type"))
                        Command.Parameters.AddWithValue("@Is_Nreq", row.Item("Is_Nreq"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Cond", row.Item("Field_Nreq_Cond"))
                        Command.Parameters.AddWithValue("@Field_Nreq_Code", row.Item("Field_Nreq_Code"))
                        Command.Parameters.AddWithValue("@Default_Value", row.Item("Default_Value"))
                        Command.Parameters.AddWithValue("@Cbo_Source_Data", row.Item("Cbo_Source_Data"))
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
    Public Function delete(ByRef pk_Report_Id As System.String,ByRef pk_Sort_No As System.Decimal,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Report_Id=@Report_Id and Sort_No=@Sort_No "
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
                Command.Parameters.AddWithValue("@Report_Id", pk_Report_Id)
                Command.Parameters.AddWithValue("@Sort_No", pk_Sort_No)
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
    Public Function queryByPK(ByRef pk_Report_Id As System.String,ByRef pk_Sort_No As System.Decimal,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  ") 
            content.AppendLine(" Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  ") 
            content.AppendLine(" Cbo_Source_Data                from " & tableName)
            content.AppendLine("   where Report_Id=@Report_Id and Sort_No=@Sort_No            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Report_Id",pk_Report_Id)
            Command.Parameters.AddWithValue("@Sort_No",pk_Sort_No)
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
    Public Function queryByLikePK(ByRef pk_Report_Id As System.String,ByRef pk_Sort_No As System.Decimal,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  ") 
            content.AppendLine(" Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  ") 
            content.AppendLine(" Cbo_Source_Data                from " & tableName)
            content.AppendLine("   where Report_Id like @Report_Id and Sort_No like @Sort_No "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Report_Id",pk_Report_Id & "%")
            Command.Parameters.AddWithValue("@Sort_No",pk_Sort_No & "%")
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
            content.AppendLine(" Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  ") 
            content.AppendLine(" Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  ") 
            content.AppendLine(" Cbo_Source_Data                from " & tableName )
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
            content.Append("select   Report_Id , Sort_No , Field_Name , Field_Code , Field_Description ,  " & _ 
             " Form_Control_Type , Is_Nreq , Field_Nreq_Cond , Field_Nreq_Code , Default_Value ,  " & _ 
             " Cbo_Source_Data            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Export_Detail 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Export_Detail 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
