Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Public Class PubRuleDetailBO
    'Roger's CodeGen Produced This VB Code @ 2010/8/13 下午 05:21:42
    Public Shared ReadOnly tableName as String="PUB_Rule_Detail"
    Private Shared myInstance As PubRuleDetailBO
    Public Shared Function GetInstance() As PubRuleDetailBO
        If myInstance Is Nothing Then
            myInstance = New PubRuleDetailBO()
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
            " Rule_Code , Seq_No , Item_Code , Item_Param , Operator_Code ,  " & _ 
             " Value_Data , Value_Unit , Is_Count_O , Is_Count_E , Is_Count_I ,  " & _ 
             " Logical_Symbol , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Rule_Maintain_Sn ) " & _ 
             " values( @Rule_Code , @Seq_No , @Item_Code , @Item_Param , @Operator_Code ,  " & _ 
             " @Value_Data , @Value_Unit , @Is_Count_O , @Is_Count_E , @Is_Count_I ,  " & _ 
             " @Logical_Symbol , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Rule_Maintain_Sn             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
            " Rule_Code , Seq_No , Item_Code , Item_Param , Operator_Code ,  " & _ 
             " Value_Data , Value_Unit , Is_Count_O , Is_Count_E , Is_Count_I ,  " & _ 
             " Logical_Symbol , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Rule_Maintain_Sn ) " & _ 
             " values( @Rule_Code , @Seq_No , @Item_Code , @Item_Param , @Operator_Code ,  " & _ 
             " @Value_Data , @Value_Unit , @Is_Count_O , @Is_Count_E , @Is_Count_I ,  " & _ 
             " @Logical_Symbol , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Rule_Maintain_Sn             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
            " Rule_Code , Seq_No , Item_Code , Item_Param , Operator_Code ,  " & _ 
             " Value_Data , Value_Unit , Is_Count_O , Is_Count_E , Is_Count_I ,  " & _ 
             " Logical_Symbol , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Rule_Maintain_Sn ) " & _ 
             " values( @Rule_Code , @Seq_No , @Item_Code , @Item_Param , @Operator_Code ,  " & _ 
             " @Value_Data , @Value_Unit , @Is_Count_O , @Is_Count_E , @Is_Count_I ,  " & _ 
             " @Logical_Symbol , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Rule_Maintain_Sn             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
    Public Function queryByPK(ByRef pk_Rule_Code as System.String,ByRef pk_Seq_No as System.Int32,ByRef pk_Item_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  "& tableName &" where Rule_Code=@Rule_Code and Seq_No=@Seq_No and Item_Code=@Item_Code            "
            Command.Parameters.AddWithValue("@Rule_Code",pk_Rule_Code)
            Command.Parameters.AddWithValue("@Seq_No",pk_Seq_No)
            Command.Parameters.AddWithValue("@Item_Code",pk_Item_Code)
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
    Public Function delete(ByRef pk_Rule_Code as System.String,ByRef pk_Seq_No as System.Int32,ByRef pk_Item_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Rule_Code=@Rule_Code and Seq_No=@Seq_No and Item_Code=@Item_Code "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)
                Command.Parameters.AddWithValue("@Seq_No", pk_Seq_No)
                Command.Parameters.AddWithValue("@Item_Code", pk_Item_Code)
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
            " Item_Param=@Item_Param , Operator_Code=@Operator_Code " & _ 
            "  , Value_Data=@Value_Data , Value_Unit=@Value_Unit , Is_Count_O=@Is_Count_O , Is_Count_E=@Is_Count_E , Is_Count_I=@Is_Count_I " & _ 
            "  , Logical_Symbol=@Logical_Symbol , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Rule_Maintain_Sn=@Rule_Maintain_Sn " & _ 
            " where  Rule_Code=@Rule_Code and Seq_No=@Seq_No and Item_Code=@Item_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
    '''更新資料庫內容,設定單一Create_Time
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString as String ="update " & tableName & " set " & _
            " Item_Param=@Item_Param , Operator_Code=@Operator_Code " & _ 
            "  , Value_Data=@Value_Data , Value_Unit=@Value_Unit , Is_Count_O=@Is_Count_O , Is_Count_E=@Is_Count_E , Is_Count_I=@Is_Count_I " & _ 
            "  , Logical_Symbol=@Logical_Symbol , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Rule_Maintain_Sn=@Rule_Maintain_Sn " & _ 
            " where  Rule_Code=@Rule_Code and Seq_No=@Seq_No and Item_Code=@Item_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
            " Item_Param=@Item_Param , Operator_Code=@Operator_Code " & _ 
            "  , Value_Data=@Value_Data , Value_Unit=@Value_Unit , Is_Count_O=@Is_Count_O , Is_Count_E=@Is_Count_E , Is_Count_I=@Is_Count_I " & _ 
            "  , Logical_Symbol=@Logical_Symbol , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Rule_Maintain_Sn=@Rule_Maintain_Sn " & _ 
            " where  Rule_Code=@Rule_Code and Seq_No=@Seq_No and Item_Code=@Item_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Seq_No", row.Item("Seq_No"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Item_Param", row.Item("Item_Param"))
                        Command.Parameters.AddWithValue("@Operator_Code", row.Item("Operator_Code"))
                        Command.Parameters.AddWithValue("@Value_Data", row.Item("Value_Data"))
                        Command.Parameters.AddWithValue("@Value_Unit", row.Item("Value_Unit"))
                        Command.Parameters.AddWithValue("@Is_Count_O", row.Item("Is_Count_O"))
                        Command.Parameters.AddWithValue("@Is_Count_E", row.Item("Is_Count_E"))
                        Command.Parameters.AddWithValue("@Is_Count_I", row.Item("Is_Count_I"))
                        Command.Parameters.AddWithValue("@Logical_Symbol", row.Item("Logical_Symbol"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Rule_Maintain_Sn", row.Item("Rule_Maintain_Sn"))
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
    '''取得表格 PUB_Rule_Detail 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOPDDBSqlConn
    End Function 


    ''' <summary>
    '''取得表格 PUB_Rule_Detail 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>queryByPK 目前也用這個，因為是單檔查詢且為 PK 條件</remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 

End Class
