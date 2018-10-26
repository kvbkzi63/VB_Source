Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class IccFeedbackMb2BO
    'Syscom's CodeGen Produced This VB Code @ 2015/11/13 下午 04:15:11
    Public Shared ReadOnly tableName As String="ICC_Feedback_Mb2"
    Private Shared myInstance As IccFeedbackMb2BO
    Public Shared Function GetInstance() As IccFeedbackMb2BO
        If myInstance Is Nothing Then
            myInstance = New IccFeedbackMb2BO()
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
            " Import_Date , Count , Record_No , Detail_No , A61 ,  " & _ 
             " A62 , A63 , A64 , A71 , A72 ,  " & _ 
             " A73 , A74 , A75 , A76 , A77 ,  " & _ 
             " A78 , A80 , A81 , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Import_Date , @Count , @Record_No , @Detail_No , @A61 ,  " & _ 
             " @A62 , @A63 , @A64 , @A71 , @A72 ,  " & _ 
             " @A73 , @A74 , @A75 , @A76 , @A77 ,  " & _ 
             " @A78 , @A80 , @A81 , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Import_Date , Count , Record_No , Detail_No , A61 ,  " & _ 
             " A62 , A63 , A64 , A71 , A72 ,  " & _ 
             " A73 , A74 , A75 , A76 , A77 ,  " & _ 
             " A78 , A80 , A81 , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Import_Date , @Count , @Record_No , @Detail_No , @A61 ,  " & _ 
             " @A62 , @A63 , @A64 , @A71 , @A72 ,  " & _ 
             " @A73 , @A74 , @A75 , @A76 , @A77 ,  " & _ 
             " @A78 , @A80 , @A81 , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Import_Date , Count , Record_No , Detail_No , A61 ,  " & _ 
             " A62 , A63 , A64 , A71 , A72 ,  " & _ 
             " A73 , A74 , A75 , A76 , A77 ,  " & _ 
             " A78 , A80 , A81 , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Import_Date , @Count , @Record_No , @Detail_No , @A61 ,  " & _ 
             " @A62 , @A63 , @A64 , @A71 , @A72 ,  " & _ 
             " @A73 , @A74 , @A75 , @A76 , @A77 ,  " & _ 
             " @A78 , @A80 , @A81 , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
            Dim sqlString As String ="update " & tableName & " set " & _
            " A61=@A61 " & _ 
            "  , A62=@A62 , A63=@A63 , A64=@A64 , A71=@A71 , A72=@A72 " & _ 
            "  , A73=@A73 , A74=@A74 , A75=@A75 , A76=@A76 , A77=@A77 " & _ 
            "  , A78=@A78 , A80=@A80 , A81=@A81 , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Date=@Import_Date and Count=@Count and Record_No=@Record_No and Detail_No=@Detail_No            "
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
            Dim sqlString As String ="update " & tableName & " set " & _
            " A61=@A61 " & _ 
            "  , A62=@A62 , A63=@A63 , A64=@A64 , A71=@A71 , A72=@A72 " & _ 
            "  , A73=@A73 , A74=@A74 , A75=@A75 , A76=@A76 , A77=@A77 " & _ 
            "  , A78=@A78 , A80=@A80 , A81=@A81 , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Date=@Import_Date and Count=@Count and Record_No=@Record_No and Detail_No=@Detail_No            "
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
            Dim sqlString As String ="update " & tableName & " set " & _
            " A61=@A61 " & _ 
            "  , A62=@A62 , A63=@A63 , A64=@A64 , A71=@A71 , A72=@A72 " & _ 
            "  , A73=@A73 , A74=@A74 , A75=@A75 , A76=@A76 , A77=@A77 " & _ 
            "  , A78=@A78 , A80=@A80 , A81=@A81 , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Date=@Import_Date and Count=@Count and Record_No=@Record_No and Detail_No=@Detail_No            "
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
                        Command.Parameters.AddWithValue("@Import_Date", row.Item("Import_Date"))
                        Command.Parameters.AddWithValue("@Count", row.Item("Count"))
                        Command.Parameters.AddWithValue("@Record_No", row.Item("Record_No"))
                        Command.Parameters.AddWithValue("@Detail_No", row.Item("Detail_No"))
                        Command.Parameters.AddWithValue("@A61", row.Item("A61"))
                        Command.Parameters.AddWithValue("@A62", row.Item("A62"))
                        Command.Parameters.AddWithValue("@A63", row.Item("A63"))
                        Command.Parameters.AddWithValue("@A64", row.Item("A64"))
                        Command.Parameters.AddWithValue("@A71", row.Item("A71"))
                        Command.Parameters.AddWithValue("@A72", row.Item("A72"))
                        Command.Parameters.AddWithValue("@A73", row.Item("A73"))
                        Command.Parameters.AddWithValue("@A74", row.Item("A74"))
                        Command.Parameters.AddWithValue("@A75", row.Item("A75"))
                        Command.Parameters.AddWithValue("@A76", row.Item("A76"))
                        Command.Parameters.AddWithValue("@A77", row.Item("A77"))
                        Command.Parameters.AddWithValue("@A78", row.Item("A78"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81", row.Item("A81"))
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
    Public Function delete(ByRef pk_Import_Date As System.DateTime,ByRef pk_Count As System.Int32,ByRef pk_Record_No As System.Int32,ByRef pk_Detail_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Import_Date=@Import_Date and Count=@Count and Record_No=@Record_No and Detail_No=@Detail_No "
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
                Command.Parameters.AddWithValue("@Import_Date", pk_Import_Date)
                Command.Parameters.AddWithValue("@Count", pk_Count)
                Command.Parameters.AddWithValue("@Record_No", pk_Record_No)
                Command.Parameters.AddWithValue("@Detail_No", pk_Detail_No)
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
    Public Function queryByPK(ByRef pk_Import_Date As System.DateTime,ByRef pk_Count As System.Int32,ByRef pk_Record_No As System.Int32,ByRef pk_Detail_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Import_Date , Count , Record_No , Detail_No , A61 ,  ") 
            content.AppendLine(" A62 , A63 , A64 , A71 , A72 ,  ") 
            content.AppendLine(" A73 , A74 , A75 , A76 , A77 ,  ") 
            content.AppendLine(" A78 , A80 , A81 , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Import_Date=@Import_Date and Count=@Count and Record_No=@Record_No and Detail_No=@Detail_No            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Import_Date",pk_Import_Date)
            Command.Parameters.AddWithValue("@Count",pk_Count)
            Command.Parameters.AddWithValue("@Record_No",pk_Record_No)
            Command.Parameters.AddWithValue("@Detail_No",pk_Detail_No)
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
    Public Function queryByLikePK(ByRef pk_Import_Date As System.DateTime,ByRef pk_Count As System.Int32,ByRef pk_Record_No As System.Int32,ByRef pk_Detail_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Import_Date , Count , Record_No , Detail_No , A61 ,  ") 
            content.AppendLine(" A62 , A63 , A64 , A71 , A72 ,  ") 
            content.AppendLine(" A73 , A74 , A75 , A76 , A77 ,  ") 
            content.AppendLine(" A78 , A80 , A81 , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Import_Date like @Import_Date and Count like @Count and Record_No like @Record_No and Detail_No like @Detail_No "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Import_Date",pk_Import_Date & "%")
            Command.Parameters.AddWithValue("@Count",pk_Count & "%")
            Command.Parameters.AddWithValue("@Record_No",pk_Record_No & "%")
            Command.Parameters.AddWithValue("@Detail_No",pk_Detail_No & "%")
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
            content.AppendLine(" Import_Date , Count , Record_No , Detail_No , A61 ,  ") 
            content.AppendLine(" A62 , A63 , A64 , A71 , A72 ,  ") 
            content.AppendLine(" A73 , A74 , A75 , A76 , A77 ,  ") 
            content.AppendLine(" A78 , A80 , A81 , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName )
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
            content.Append("select   Import_Date , Count , Record_No , Detail_No , A61 ,  " & _ 
             " A62 , A63 , A64 , A71 , A72 ,  " & _ 
             " A73 , A74 , A75 , A76 , A77 ,  " & _ 
             " A78 , A80 , A81 , Create_User , Create_Time ,  " & _ 
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
    '''取得表格 ICC_Feedback_Mb2 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region

End Class
