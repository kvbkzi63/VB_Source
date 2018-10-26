Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class PubNhiCodeImportBO
    'Syscom's CodeGen Produced This VB Code @ 2016/9/17 下午 03:45:19
    Public Shared ReadOnly tableName As String="PUB_Nhi_Code_Import"
    Private Shared myInstance As PubNhiCodeImportBO
    Public Shared Function GetInstance() As PubNhiCodeImportBO
        If myInstance Is Nothing Then
            myInstance = New PubNhiCodeImportBO()
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
            " Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  " & _ 
             " Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  " & _ 
             " Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Nhi_Import_Sn , @Item_No , @Insu_Code , @Insu_Name , @Brand ,  " & _ 
             " @Content_Desc , @Form_Desc , @Spec_Desc , @Orig_Price , @New_Price ,  " & _ 
             " @Effect_Date , @Trans_User , @Trans_Time , @Create_User , @Create_Time ,  " & _ 
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
            " Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  " & _ 
             " Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  " & _ 
             " Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Nhi_Import_Sn , @Item_No , @Insu_Code , @Insu_Name , @Brand ,  " & _ 
             " @Content_Desc , @Form_Desc , @Spec_Desc , @Orig_Price , @New_Price ,  " & _ 
             " @Effect_Date , @Trans_User , @Trans_Time , @Create_User , @Create_Time ,  " & _ 
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
            " Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  " & _ 
             " Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  " & _ 
             " Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time ) " & _ 
             " values( @Nhi_Import_Sn , @Item_No , @Insu_Code , @Insu_Name , @Brand ,  " & _ 
             " @Content_Desc , @Form_Desc , @Spec_Desc , @Orig_Price , @New_Price ,  " & _ 
             " @Effect_Date , @Trans_User , @Trans_Time , @Create_User , @Create_Time ,  " & _ 
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
            " Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Brand=@Brand " & _ 
            "  , Content_Desc=@Content_Desc , Form_Desc=@Form_Desc , Spec_Desc=@Spec_Desc , Orig_Price=@Orig_Price , New_Price=@New_Price " & _ 
            "  , Effect_Date=@Effect_Date , Trans_User=@Trans_User , Trans_Time=@Trans_Time , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Nhi_Import_Sn=@Nhi_Import_Sn and Item_No=@Item_No            "
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
            " Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Brand=@Brand " & _ 
            "  , Content_Desc=@Content_Desc , Form_Desc=@Form_Desc , Spec_Desc=@Spec_Desc , Orig_Price=@Orig_Price , New_Price=@New_Price " & _ 
            "  , Effect_Date=@Effect_Date , Trans_User=@Trans_User , Trans_Time=@Trans_Time , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Nhi_Import_Sn=@Nhi_Import_Sn and Item_No=@Item_No            "
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
            " Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Brand=@Brand " & _ 
            "  , Content_Desc=@Content_Desc , Form_Desc=@Form_Desc , Spec_Desc=@Spec_Desc , Orig_Price=@Orig_Price , New_Price=@New_Price " & _ 
            "  , Effect_Date=@Effect_Date , Trans_User=@Trans_User , Trans_Time=@Trans_Time , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Nhi_Import_Sn=@Nhi_Import_Sn and Item_No=@Item_No            "
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
                        Command.Parameters.AddWithValue("@Nhi_Import_Sn", row.Item("Nhi_Import_Sn"))
                        Command.Parameters.AddWithValue("@Item_No", row.Item("Item_No"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Brand", row.Item("Brand"))
                        Command.Parameters.AddWithValue("@Content_Desc", row.Item("Content_Desc"))
                        Command.Parameters.AddWithValue("@Form_Desc", row.Item("Form_Desc"))
                        Command.Parameters.AddWithValue("@Spec_Desc", row.Item("Spec_Desc"))
                        Command.Parameters.AddWithValue("@Orig_Price", row.Item("Orig_Price"))
                        Command.Parameters.AddWithValue("@New_Price", row.Item("New_Price"))
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Trans_User", row.Item("Trans_User"))
                        Command.Parameters.AddWithValue("@Trans_Time", row.Item("Trans_Time"))
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
    Public Function delete(ByRef pk_Nhi_Import_Sn As System.String,ByRef pk_Item_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Nhi_Import_Sn=@Nhi_Import_Sn and Item_No=@Item_No "
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
                Command.Parameters.AddWithValue("@Nhi_Import_Sn", pk_Nhi_Import_Sn)
                Command.Parameters.AddWithValue("@Item_No", pk_Item_No)
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
    Public Function queryByPK(ByRef pk_Nhi_Import_Sn As System.String,ByRef pk_Item_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  ") 
            content.AppendLine(" Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  ") 
            content.AppendLine(" Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Nhi_Import_Sn=@Nhi_Import_Sn and Item_No=@Item_No            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Nhi_Import_Sn",pk_Nhi_Import_Sn)
            Command.Parameters.AddWithValue("@Item_No",pk_Item_No)
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
    Public Function queryByLikePK(ByRef pk_Nhi_Import_Sn As System.String,ByRef pk_Item_No As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  ") 
            content.AppendLine(" Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  ") 
            content.AppendLine(" Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Nhi_Import_Sn like @Nhi_Import_Sn and Item_No like @Item_No "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Nhi_Import_Sn",pk_Nhi_Import_Sn & "%")
            Command.Parameters.AddWithValue("@Item_No",pk_Item_No & "%")
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
            content.AppendLine(" Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  ") 
            content.AppendLine(" Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  ") 
            content.AppendLine(" Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  ") 
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
            content.Append("select   Nhi_Import_Sn , Item_No , Insu_Code , Insu_Name , Brand ,  " & _ 
             " Content_Desc , Form_Desc , Spec_Desc , Orig_Price , New_Price ,  " & _ 
             " Effect_Date , Trans_User , Trans_Time , Create_User , Create_Time ,  " & _ 
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
    '''取得表格 PUB_Nhi_Code_Import 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPUBDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Nhi_Code_Import 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
