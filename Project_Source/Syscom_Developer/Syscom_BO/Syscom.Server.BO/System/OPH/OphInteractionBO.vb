Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.ServiceModel
Imports Syscom.Comm.Utility
Public Class OphInteractionBO
    'Roger's CodeGen Produced This VB Code @ 2010/7/6 下午 02:33:04
    Public Shared ReadOnly tableName as String="OPH_Interaction"
    Private Shared myInstance As OphInteractionBO
    Public Shared Function GetInstance() As OphInteractionBO
        If myInstance Is Nothing Then
            myInstance = New OphInteractionBO()
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
            " Pharmacy_12_CodeA , Pharmacy_12_CodeB , Interaction_Level , Interaction_Rate_Id , Serious_Degree_Id ,  " & _ 
             " Catalog_Id , Restriction_Id , Is_Online_Remind , First_Occur_Date , Pause_Date ,  " & _ 
             " Remind_Words , Effect , Turn , Process , Discuss ,  " & _ 
             " Reference , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Pharmacy_12_CodeA , @Pharmacy_12_CodeB , @Interaction_Level , @Interaction_Rate_Id , @Serious_Degree_Id ,  " & _ 
             " @Catalog_Id , @Restriction_Id , @Is_Online_Remind , @First_Occur_Date , @Pause_Date ,  " & _ 
             " @Remind_Words , @Effect , @Turn , @Process , @Discuss ,  " & _ 
             " @Reference , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Pharmacy_12_CodeA , Pharmacy_12_CodeB , Interaction_Level , Interaction_Rate_Id , Serious_Degree_Id ,  " & _ 
             " Catalog_Id , Restriction_Id , Is_Online_Remind , First_Occur_Date , Pause_Date ,  " & _ 
             " Remind_Words , Effect , Turn , Process , Discuss ,  " & _ 
             " Reference , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Pharmacy_12_CodeA , @Pharmacy_12_CodeB , @Interaction_Level , @Interaction_Rate_Id , @Serious_Degree_Id ,  " & _ 
             " @Catalog_Id , @Restriction_Id , @Is_Online_Remind , @First_Occur_Date , @Pause_Date ,  " & _ 
             " @Remind_Words , @Effect , @Turn , @Process , @Discuss ,  " & _ 
             " @Reference , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Pharmacy_12_CodeA , Pharmacy_12_CodeB , Interaction_Level , Interaction_Rate_Id , Serious_Degree_Id ,  " & _ 
             " Catalog_Id , Restriction_Id , Is_Online_Remind , First_Occur_Date , Pause_Date ,  " & _ 
             " Remind_Words , Effect , Turn , Process , Discuss ,  " & _ 
             " Reference , Create_User , Create_Time , Modified_User , Modified_Time " & _ 
             "  ) " & _ 
             " values( @Pharmacy_12_CodeA , @Pharmacy_12_CodeB , @Interaction_Level , @Interaction_Rate_Id , @Serious_Degree_Id ,  " & _ 
             " @Catalog_Id , @Restriction_Id , @Is_Online_Remind , @First_Occur_Date , @Pause_Date ,  " & _ 
             " @Remind_Words , @Effect , @Turn , @Process , @Discuss ,  " & _ 
             " @Reference , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
    Public Function queryByPK(ByRef pk_Pharmacy_12_CodeA as System.String,ByRef pk_Pharmacy_12_CodeB as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  "& tableName &" where Pharmacy_12_CodeA=@Pharmacy_12_CodeA and Pharmacy_12_CodeB=@Pharmacy_12_CodeB            "
            Command.Parameters.AddWithValue("@Pharmacy_12_CodeA",pk_Pharmacy_12_CodeA)
            Command.Parameters.AddWithValue("@Pharmacy_12_CodeB",pk_Pharmacy_12_CodeB)
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
    Public Function delete(ByRef pk_Pharmacy_12_CodeA as System.String,ByRef pk_Pharmacy_12_CodeB as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Pharmacy_12_CodeA=@Pharmacy_12_CodeA and Pharmacy_12_CodeB=@Pharmacy_12_CodeB "
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
                Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", pk_Pharmacy_12_CodeA)
                Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", pk_Pharmacy_12_CodeB)
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
            " Interaction_Level=@Interaction_Level , Interaction_Rate_Id=@Interaction_Rate_Id , Serious_Degree_Id=@Serious_Degree_Id " & _ 
            "  , Catalog_Id=@Catalog_Id , Restriction_Id=@Restriction_Id , Is_Online_Remind=@Is_Online_Remind , First_Occur_Date=@First_Occur_Date , Pause_Date=@Pause_Date " & _ 
            "  , Remind_Words=@Remind_Words , Effect=@Effect , Turn=@Turn , Process=@Process , Discuss=@Discuss " & _ 
            "  , Reference=@Reference , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Pharmacy_12_CodeA=@Pharmacy_12_CodeA and Pharmacy_12_CodeB=@Pharmacy_12_CodeB            "
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            " Interaction_Level=@Interaction_Level , Interaction_Rate_Id=@Interaction_Rate_Id , Serious_Degree_Id=@Serious_Degree_Id " & _ 
            "  , Catalog_Id=@Catalog_Id , Restriction_Id=@Restriction_Id , Is_Online_Remind=@Is_Online_Remind , First_Occur_Date=@First_Occur_Date , Pause_Date=@Pause_Date " & _ 
            "  , Remind_Words=@Remind_Words , Effect=@Effect , Turn=@Turn , Process=@Process , Discuss=@Discuss " & _ 
            "  , Reference=@Reference , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Pharmacy_12_CodeA=@Pharmacy_12_CodeA and Pharmacy_12_CodeB=@Pharmacy_12_CodeB            "
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
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
            " Interaction_Level=@Interaction_Level , Interaction_Rate_Id=@Interaction_Rate_Id , Serious_Degree_Id=@Serious_Degree_Id " & _ 
            "  , Catalog_Id=@Catalog_Id , Restriction_Id=@Restriction_Id , Is_Online_Remind=@Is_Online_Remind , First_Occur_Date=@First_Occur_Date , Pause_Date=@Pause_Date " & _ 
            "  , Remind_Words=@Remind_Words , Effect=@Effect , Turn=@Turn , Process=@Process , Discuss=@Discuss " & _ 
            "  , Reference=@Reference , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  " & _ 
            " where  Pharmacy_12_CodeA=@Pharmacy_12_CodeA and Pharmacy_12_CodeB=@Pharmacy_12_CodeB            "
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
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeA", row.Item("Pharmacy_12_CodeA"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_CodeB", row.Item("Pharmacy_12_CodeB"))
                        Command.Parameters.AddWithValue("@Interaction_Level", row.Item("Interaction_Level"))
                        Command.Parameters.AddWithValue("@Interaction_Rate_Id", row.Item("Interaction_Rate_Id"))
                        Command.Parameters.AddWithValue("@Serious_Degree_Id", row.Item("Serious_Degree_Id"))
                        Command.Parameters.AddWithValue("@Catalog_Id", row.Item("Catalog_Id"))
                        Command.Parameters.AddWithValue("@Restriction_Id", row.Item("Restriction_Id"))
                        Command.Parameters.AddWithValue("@Is_Online_Remind", row.Item("Is_Online_Remind"))
                        Command.Parameters.AddWithValue("@First_Occur_Date", row.Item("First_Occur_Date"))
                        Command.Parameters.AddWithValue("@Pause_Date", row.Item("Pause_Date"))
                        Command.Parameters.AddWithValue("@Remind_Words", row.Item("Remind_Words"))
                        Command.Parameters.AddWithValue("@Effect", row.Item("Effect"))
                        Command.Parameters.AddWithValue("@Turn", row.Item("Turn"))
                        Command.Parameters.AddWithValue("@Process", row.Item("Process"))
                        Command.Parameters.AddWithValue("@Discuss", row.Item("Discuss"))
                        Command.Parameters.AddWithValue("@Reference", row.Item("Reference"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
    '''取得表格 OPH_Interaction 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOPDDBSqlConn
    End Function 

End Class
