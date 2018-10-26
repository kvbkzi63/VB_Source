Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.ServiceModel
Imports System.Data
Public Class IccInoculationUploadBO
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:32
    Public Shared ReadOnly tableName as String="ICC_Inoculation_Upload"
    Private Shared myInstance As IccInoculationUploadBO
    Public Shared Function GetInstance() As IccInoculationUploadBO
        If myInstance Is Nothing Then
            myInstance = New IccInoculationUploadBO()
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
            " Inoculation_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A16 , A20 , A21 ,  " & _ 
             " A24 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Is_Baby_Stool ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , TreatmentTime ,  " & _ 
             " Is_Fix , Fix_Inoculation_Sn ) " & _ 
             " values( @Inoculation_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A16 , @A20 , @A21 ,  " & _ 
             " @A24 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Is_Baby_Stool ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @TreatmentTime ,  " & _ 
             " @Is_Fix , @Fix_Inoculation_Sn             )"
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
            " Inoculation_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A16 , A20 , A21 ,  " & _ 
             " A24 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Is_Baby_Stool ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , TreatmentTime ,  " & _ 
             " Is_Fix , Fix_Inoculation_Sn ) " & _ 
             " values( @Inoculation_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A16 , @A20 , @A21 ,  " & _ 
             " @A24 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Is_Baby_Stool ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @TreatmentTime ,  " & _ 
             " @Is_Fix , @Fix_Inoculation_Sn             )"
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
            " Inoculation_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A16 , A20 , A21 ,  " & _ 
             " A24 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Is_Baby_Stool ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , TreatmentTime ,  " & _ 
             " Is_Fix , Fix_Inoculation_Sn ) " & _ 
             " values( @Inoculation_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A16 , @A20 , @A21 ,  " & _ 
             " @A24 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Is_Baby_Stool ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @TreatmentTime ,  " & _ 
             " @Is_Fix , @Fix_Inoculation_Sn             )"
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
    Public Function queryByPK(ByRef pk_Inoculation_Sn as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  "& tableName &" where Inoculation_Sn=@Inoculation_Sn            "
            Command.Parameters.AddWithValue("@Inoculation_Sn",pk_Inoculation_Sn)
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
    Public Function delete(ByRef pk_Inoculation_Sn as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Inoculation_Sn=@Inoculation_Sn "
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
                Command.Parameters.AddWithValue("@Inoculation_Sn", pk_Inoculation_Sn)
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A16=@A16 , A20=@A20 , A21=@A21 " & _ 
            "  , A24=@A24 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Is_Baby_Stool=@Is_Baby_Stool " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , TreatmentTime=@TreatmentTime " & _ 
            "  , Is_Fix=@Is_Fix , Fix_Inoculation_Sn=@Fix_Inoculation_Sn " & _ 
            " where  Inoculation_Sn=@Inoculation_Sn            "
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A16=@A16 , A20=@A20 , A21=@A21 " & _ 
            "  , A24=@A24 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Is_Baby_Stool=@Is_Baby_Stool " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , TreatmentTime=@TreatmentTime " & _ 
            "  , Is_Fix=@Is_Fix , Fix_Inoculation_Sn=@Fix_Inoculation_Sn " & _ 
            " where  Inoculation_Sn=@Inoculation_Sn            "
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A16=@A16 , A20=@A20 , A21=@A21 " & _ 
            "  , A24=@A24 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Is_Baby_Stool=@Is_Baby_Stool " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , TreatmentTime=@TreatmentTime " & _ 
            "  , Is_Fix=@Is_Fix , Fix_Inoculation_Sn=@Fix_Inoculation_Sn " & _ 
            " where  Inoculation_Sn=@Inoculation_Sn            "
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
                        Command.Parameters.AddWithValue("@Inoculation_Sn", row.Item("Inoculation_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Is_Baby_Stool", row.Item("Is_Baby_Stool"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@TreatmentTime", row.Item("TreatmentTime"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Inoculation_Sn", row.Item("Fix_Inoculation_Sn"))
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
    '''取得表格 ICC_Inoculation_Upload 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOPDDBSqlConn
    End Function 

End Class
