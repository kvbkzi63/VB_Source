Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Reflection
Imports System.Data
Imports System.Diagnostics
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubOrderExamNocheckinDeptBO
   Inherits Syscom.Comm.LOG.LOGDelegate
    'Syscom's CodeGen Produced This VB Code @ 2017/3/14 上午 11:00:00
    Public Shared ReadOnly tableName As String="PUB_Order_Exam_Nocheckin_Dept"
    Private Shared myInstance As PubOrderExamNocheckinDeptBO
    Public Shared Function GetInstance() As PubOrderExamNocheckinDeptBO
        If myInstance Is Nothing Then
            myInstance = New PubOrderExamNocheckinDeptBO()
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
            " Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Order_Code , @Kind_Id , @Dept_Code , @Section_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Order_Code , @Kind_Id , @Dept_Code , @Section_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Order_Code , @Kind_Id , @Dept_Code , @Section_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Order_Code=@Order_Code and Kind_Id=@Kind_Id and Dept_Code=@Dept_Code and Section_Id=@Section_Id            "
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
            " Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Order_Code=@Order_Code and Kind_Id=@Kind_Id and Dept_Code=@Dept_Code and Section_Id=@Section_Id            "
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
            " Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Order_Code=@Order_Code and Kind_Id=@Kind_Id and Dept_Code=@Dept_Code and Section_Id=@Section_Id            "
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
                        Command.Parameters.AddWithValue("@Kind_Id", row.Item("Kind_Id"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Section_Id", row.Item("Section_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
    Public Function delete(ByRef pk_Order_Code As System.String,ByRef pk_Kind_Id As System.String,ByRef pk_Dept_Code As System.String,ByRef pk_Section_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Order_Code=@Order_Code and Kind_Id=@Kind_Id and Dept_Code=@Dept_Code and Section_Id=@Section_Id "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                  deleteBackup(pk_Order_Code,pk_Kind_Id,pk_Dept_Code,pk_Section_Id,conn) '備份機制
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                Command.Parameters.AddWithValue("@Kind_Id", pk_Kind_Id)
                Command.Parameters.AddWithValue("@Dept_Code", pk_Dept_Code)
                Command.Parameters.AddWithValue("@Section_Id", pk_Section_Id)
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
    Public Function queryByPK(ByRef pk_Order_Code As System.String,ByRef pk_Kind_Id As System.String,ByRef pk_Dept_Code As System.String,ByRef pk_Section_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Order_Code=@Order_Code and Kind_Id=@Kind_Id and Dept_Code=@Dept_Code and Section_Id=@Section_Id            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code)
            Command.Parameters.AddWithValue("@Kind_Id",pk_Kind_Id)
            Command.Parameters.AddWithValue("@Dept_Code",pk_Dept_Code)
            Command.Parameters.AddWithValue("@Section_Id",pk_Section_Id)
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
    Public Function queryByLikePK(ByRef pk_Order_Code As System.String,ByRef pk_Kind_Id As System.String,ByRef pk_Dept_Code As System.String,ByRef pk_Section_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Order_Code like @Order_Code and Kind_Id like @Kind_Id and Dept_Code like @Dept_Code and Section_Id like @Section_Id "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code & "%")
            Command.Parameters.AddWithValue("@Kind_Id",pk_Kind_Id & "%")
            Command.Parameters.AddWithValue("@Dept_Code",pk_Dept_Code & "%")
            Command.Parameters.AddWithValue("@Section_Id",pk_Section_Id & "%")
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
            content.AppendLine(" Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableName )
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
            content.Append("select   Order_Code , Kind_Id , Dept_Code , Section_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time            from " & tableName & " where 1=1 ")
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

#Region " 備份"

    ''' <summary>
    '''取得資料庫備份表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableBKWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName & "_BK")
            dt.Columns.Add("Action")
            dt.Columns("Action").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Backup_Time")
            dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Kind_Id")
            dt.Columns("Kind_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Section_Id")
            dt.Columns("Section_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(5) As DataColumn 
            pkColArray(2) = dt.Columns("Order_Code")
            pkColArray(3) = dt.Columns("Kind_Id")
            pkColArray(4) = dt.Columns("Dept_Code")
            pkColArray(5) = dt.Columns("Section_Id")
            pkColArray(0) = dt.Columns("Action")
            pkColArray(1) = dt.Columns("Backup_Time")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    
        ''' <summary>
        ''' 備份新增資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub insertBackup(ByVal row As DataRow, ByRef conn As System.Data.IDbConnection )
            dataBackup("Insert", row, conn)
        End Sub
    
    
        ''' <summary>
        ''' 備份新增資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub insertBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection )
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    insertBackup(row, conn)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
            dataBackup("Update", row, conn)
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection )
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    updateBackup(row, conn)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份主程式
        ''' </summary>
        ''' <param name="action"></param>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow, ByRef conn As System.Data.IDbConnection )
            Dim bkDS = New DataSet
            Dim bkTable = getDataTableBKWithSchema()
            Dim bkRow = bkTable.NewRow()
            bkRow("Action") = action
            bkRow("Backup_Time") = Now
                bkRow("Order_Code") = row.Item("Order_Code")
                bkRow("Kind_Id") = row.Item("Kind_Id")
                bkRow("Dept_Code") = row.Item("Dept_Code")
                bkRow("Section_Id") = row.Item("Section_Id")
                bkRow("Create_User") = row.Item("Create_User")
                bkRow("Create_Time") = row.Item("Create_Time")
                bkRow("Modified_User") = row.Item("Modified_User")
                bkRow("Modified_Time") = row.Item("Modified_Time")
            bkTable.Rows.Add(bkRow)
            bkDS.Tables.Add(bkTable)
            If bkDS.Tables(0).Rows.Count > 0 Then
                Try
                   Dim Content As New StringBuilder
                   Content.AppendLine("	 Insert Into " & tableName & "_BK (Action,Backup_Time")
                          Content.AppendLine("      , Order_Code")
                          Content.AppendLine("      , Kind_Id")
                          Content.AppendLine("      , Dept_Code")
                          Content.AppendLine("      , Section_Id")
                          Content.AppendLine("      , Create_User")
                          Content.AppendLine("      , Create_Time")
                          Content.AppendLine("      , Modified_User")
                          Content.AppendLine("      , Modified_Time")
                 Content.AppendLine("      )")
                 Content.AppendLine("Select '" & action & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "' ,* From " & tableName & " Where 1=1 ")
                 Content.AppendLine("   And Order_Code=@Order_Code")
                 Content.AppendLine("   And Kind_Id=@Kind_Id")
                 Content.AppendLine("   And Dept_Code=@Dept_Code")
                 Content.AppendLine("   And Section_Id=@Section_Id")
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = Content.ToString  
                Command.Parameters.AddWithValue("@Order_Code", bkRow("Order_Code"))
                Command.Parameters.AddWithValue("@Kind_Id", bkRow("Kind_Id"))
                Command.Parameters.AddWithValue("@Dept_Code", bkRow("Dept_Code"))
                Command.Parameters.AddWithValue("@Section_Id", bkRow("Section_Id"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                End Using
        Catch ex As Exception
                Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()

                '寫入DBLog
                Dim logConn As IDbConnection = SQLConnFactory.getInstance.getBKDBSqlConn
                logConn.Open()
                Dim command As SqlCommand = New SqlCommand("InsertLog", logConn )
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add("@LOG_Thread", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Level", SqlDbType.VarChar, 50)
                command.Parameters.Add("@LOG_Logger", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Class", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Method", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Message", SqlDbType.NVarChar, 4000)
                command.Parameters.Add("@LOG_Exception", SqlDbType.NVarChar, 2000)

                command.Parameters("@LOG_Thread").Value = System.Threading.Thread.CurrentThread.ManagedThreadId
                command.Parameters("@LOG_Level").Value = "ERROR"
                command.Parameters("@LOG_Logger").Value = getLoggerName(caller.DeclaringType.FullName)
                command.Parameters("@LOG_Class").Value = "PUBOrderExamNocheckinDeptBO.vb"
                command.Parameters("@LOG_Method").Value = "dataBackup"
                command.Parameters("@LOG_Message").Value = "備份失敗:" & bkDS.GetXml
                command.Parameters("@LOG_Exception").Value = ex.StackTrace
                Try
                    command.ExecuteNonQuery()
                Catch logex As Exception
                Finally
                    logConn.Close()
                    logConn.Dispose()
                End Try
        End Try
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
        Protected Sub deleteBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
                row("Modified_Time") = Now
            dataBackup("Delete", row, conn)
        End Sub
    
    
         ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub deleteBackupTable(ByVal table As DataTable, Optional ByRef conn As System.Data.IDbConnection = Nothing)
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    deleteBackup(row, conn)
                Next
            End If
        End Sub

        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>       
        Protected Sub deleteBackup(ByVal pk_Order_Code As System.String,ByVal pk_Kind_Id As System.String,ByVal pk_Dept_Code As System.String,ByVal pk_Section_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing)
    
            Dim bkDS As System.Data.DataSet = queryByPK(pk_Order_Code,pk_Kind_Id,pk_Dept_Code,pk_Section_Id, conn)
            If bkDS IsNot Nothing _
            AndAlso bkDS.Tables.Count > 0 _
            AndAlso bkDS.Tables(0) IsNot Nothing _
            AndAlso bkDS.Tables(0).Rows.Count > 0 _
            AndAlso bkDS.Tables(0).Rows(0) IsNot Nothing _
            Then
                deleteBackup(bkDS.Tables(0).Rows(0), conn) 
            Else
                'Throw New Exception("No Data To Delete")
            End If
        End Sub

#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Order_Exam_Nocheckin_Dept 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        '請加入SQL Connection 於 SD CodeGen 中
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Order_Exam_Nocheckin_Dept 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
