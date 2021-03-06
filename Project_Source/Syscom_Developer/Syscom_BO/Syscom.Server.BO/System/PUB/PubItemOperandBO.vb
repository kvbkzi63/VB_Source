Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Public Class PubItemOperandBO
    'Roger's CodeGen Produced This VB Code @ 2009/10/17 上午 11:50:59
    Public Shared ReadOnly tableName as String="PUB_Item_Operand"
    Private Shared myInstance As PubItemOperandBO
    Public Shared Function GetInstance() As PubItemOperandBO
        If myInstance Is Nothing Then
            myInstance = New PubItemOperandBO()
        End If 
        Return myInstance 
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
            command.CommandText = "select * from "& tableName
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Use_Type , Item_Code , Operand_Code ) " & _ 
             " values( @Use_Type , @Item_Code , @Operand_Code             )"
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
                        Command.Parameters.AddWithValue("@Use_Type", row.Item("Use_Type"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Operand_Code", row.Item("Operand_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Use_Type , Item_Code , Operand_Code ) " & _ 
             " values( @Use_Type , @Item_Code , @Operand_Code             )"
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
                        Command.Parameters.AddWithValue("@Use_Type", row.Item("Use_Type"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Operand_Code", row.Item("Operand_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Use_Type , Item_Code , Operand_Code ) " & _ 
             " values( @Use_Type , @Item_Code , @Operand_Code             )"
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
                        Command.Parameters.AddWithValue("@Use_Type", row.Item("Use_Type"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Operand_Code", row.Item("Operand_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
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
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
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
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function


    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_Use_Type as System.String,ByRef pk_Item_Code as System.String,ByRef pk_Operand_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  "& tableName &" where Use_Type=@Use_Type and Item_Code=@Item_Code and Operand_Code=@Operand_Code            "
            Command.Parameters.AddWithValue("@Use_Type",pk_Use_Type)
            Command.Parameters.AddWithValue("@Item_Code",pk_Item_Code)
            Command.Parameters.AddWithValue("@Operand_Code",pk_Operand_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_Use_Type as System.String,ByRef pk_Item_Code as System.String,ByRef pk_Operand_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Use_Type=@Use_Type and Item_Code=@Item_Code and Operand_Code=@Operand_Code "
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
                Command.Parameters.AddWithValue("@Use_Type", pk_Use_Type)
                Command.Parameters.AddWithValue("@Item_Code", pk_Item_Code)
                Command.Parameters.AddWithValue("@Operand_Code", pk_Operand_Code)
                count = Command.ExecuteNonQuery
                End Using
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

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
            Dim sqlString as String ="update " & tableName & " set " & _
            "  " & _ 
            " where  Use_Type=@Use_Type and Item_Code=@Item_Code and Operand_Code=@Operand_Code            "
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
                        Command.Parameters.AddWithValue("@Use_Type", row.Item("Use_Type"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Operand_Code", row.Item("Operand_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
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
            Dim sqlString as String ="update " & tableName & " set " & _
            "  " & _ 
            " where  Use_Type=@Use_Type and Item_Code=@Item_Code and Operand_Code=@Operand_Code            "
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
                        Command.Parameters.AddWithValue("@Use_Type", row.Item("Use_Type"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Operand_Code", row.Item("Operand_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 

End Class
