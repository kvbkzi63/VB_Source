Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubOrderMappingSpecimenBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:51
    Public Shared ReadOnly tableName As String="PUB_Order_Mapping_Specimen"
    Private Shared myInstance As PubOrderMappingSpecimenBO
    Public Shared Function GetInstance() As PubOrderMappingSpecimenBO
        If myInstance Is Nothing Then
            myInstance = New PubOrderMappingSpecimenBO()
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
            " Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  " & _ 
             " Control_Value , Time_Control_Id , Is_Default_Vessel ) " & _ 
             " values( @Order_Code , @Specimen_Id , @Vessel_Id , @Is_Default , @Specimen_Sort_Value ,  " & _ 
             " @Control_Value , @Time_Control_Id , @Is_Default_Vessel             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
            " Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  " & _ 
             " Control_Value , Time_Control_Id , Is_Default_Vessel ) " & _ 
             " values( @Order_Code , @Specimen_Id , @Vessel_Id , @Is_Default , @Specimen_Sort_Value ,  " & _ 
             " @Control_Value , @Time_Control_Id , @Is_Default_Vessel             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
            " Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  " & _ 
             " Control_Value , Time_Control_Id , Is_Default_Vessel ) " & _ 
             " values( @Order_Code , @Specimen_Id , @Vessel_Id , @Is_Default , @Specimen_Sort_Value ,  " & _ 
             " @Control_Value , @Time_Control_Id , @Is_Default_Vessel             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
            " Is_Default=@Is_Default , Specimen_Sort_Value=@Specimen_Sort_Value " & _ 
            "  , Control_Value=@Control_Value , Time_Control_Id=@Time_Control_Id , Is_Default_Vessel=@Is_Default_Vessel " & _ 
            " where  Order_Code=@Order_Code and Specimen_Id=@Specimen_Id and Vessel_Id=@Vessel_Id            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
            " Is_Default=@Is_Default , Specimen_Sort_Value=@Specimen_Sort_Value " & _ 
            "  , Control_Value=@Control_Value , Time_Control_Id=@Time_Control_Id , Is_Default_Vessel=@Is_Default_Vessel " & _ 
            " where  Order_Code=@Order_Code and Specimen_Id=@Specimen_Id and Vessel_Id=@Vessel_Id            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
            " Is_Default=@Is_Default , Specimen_Sort_Value=@Specimen_Sort_Value " & _ 
            "  , Control_Value=@Control_Value , Time_Control_Id=@Time_Control_Id , Is_Default_Vessel=@Is_Default_Vessel " & _ 
            " where  Order_Code=@Order_Code and Specimen_Id=@Specimen_Id and Vessel_Id=@Vessel_Id            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Specimen_Id", row.Item("Specimen_Id"))
                        Command.Parameters.AddWithValue("@Vessel_Id", row.Item("Vessel_Id"))
                        Command.Parameters.AddWithValue("@Is_Default", row.Item("Is_Default"))
                        Command.Parameters.AddWithValue("@Specimen_Sort_Value", row.Item("Specimen_Sort_Value"))
                        Command.Parameters.AddWithValue("@Control_Value", row.Item("Control_Value"))
                        Command.Parameters.AddWithValue("@Time_Control_Id", row.Item("Time_Control_Id"))
                        Command.Parameters.AddWithValue("@Is_Default_Vessel", row.Item("Is_Default_Vessel"))
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
    Public Function delete(ByRef pk_Order_Code As System.String,ByRef pk_Specimen_Id As System.String,ByRef pk_Vessel_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Order_Code=@Order_Code and Specimen_Id=@Specimen_Id and Vessel_Id=@Vessel_Id "
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
                Command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                Command.Parameters.AddWithValue("@Specimen_Id", pk_Specimen_Id)
                Command.Parameters.AddWithValue("@Vessel_Id", pk_Vessel_Id)
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
    Public Function queryByPK(ByRef pk_Order_Code As System.String,ByRef pk_Specimen_Id As System.String,ByRef pk_Vessel_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  ") 
            content.AppendLine(" Control_Value , Time_Control_Id , Is_Default_Vessel                from " & tableName)
            content.AppendLine("   where Order_Code=@Order_Code and Specimen_Id=@Specimen_Id and Vessel_Id=@Vessel_Id            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code)
            Command.Parameters.AddWithValue("@Specimen_Id",pk_Specimen_Id)
            Command.Parameters.AddWithValue("@Vessel_Id",pk_Vessel_Id)
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
    Public Function queryByLikePK(ByRef pk_Order_Code As System.String,ByRef pk_Specimen_Id As System.String,ByRef pk_Vessel_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  ") 
            content.AppendLine(" Control_Value , Time_Control_Id , Is_Default_Vessel                from " & tableName)
            content.AppendLine("   where Order_Code like @Order_Code and Specimen_Id like @Specimen_Id and Vessel_Id like @Vessel_Id "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code & "%")
            Command.Parameters.AddWithValue("@Specimen_Id",pk_Specimen_Id & "%")
            Command.Parameters.AddWithValue("@Vessel_Id",pk_Vessel_Id & "%")
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
            content.AppendLine(" Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  ") 
            content.AppendLine(" Control_Value , Time_Control_Id , Is_Default_Vessel                from " & tableName )
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
            content.Append("select   Order_Code , Specimen_Id , Vessel_Id , Is_Default , Specimen_Sort_Value ,  " & _ 
             " Control_Value , Time_Control_Id , Is_Default_Vessel            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Order_Mapping_Specimen 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Order_Mapping_Specimen 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
