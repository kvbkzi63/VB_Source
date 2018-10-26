Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubInsuCodeBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:50
    Public Shared ReadOnly tableName As String="PUB_Insu_Code"
    Private Shared myInstance As PubInsuCodeBO
    Public Shared Function GetInstance() As PubInsuCodeBO
        If myInstance Is Nothing Then
            myInstance = New PubInsuCodeBO()
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
            " Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  " & _ 
             " Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  " & _ 
             " Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time ) " & _ 
             " values( @Effect_Date , @Order_Type_Id , @Order_Code , @Insu_Code_Seq , @Is_Multi_Map_Flag ,  " & _ 
             " @Insu_Code , @Insu_Name , @Price , @Tqty , @Insu_Account_Id ,  " & _ 
             " @Is_Emg_Add , @Is_Kid_Add , @Is_Dental_Add , @Is_Holiday_Add , @Is_Dept_Add ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            " Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  " & _ 
             " Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  " & _ 
             " Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time ) " & _ 
             " values( @Effect_Date , @Order_Type_Id , @Order_Code , @Insu_Code_Seq , @Is_Multi_Map_Flag ,  " & _ 
             " @Insu_Code , @Insu_Name , @Price , @Tqty , @Insu_Account_Id ,  " & _ 
             " @Is_Emg_Add , @Is_Kid_Add , @Is_Dental_Add , @Is_Holiday_Add , @Is_Dept_Add ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            " Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  " & _ 
             " Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  " & _ 
             " Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time ) " & _ 
             " values( @Effect_Date , @Order_Type_Id , @Order_Code , @Insu_Code_Seq , @Is_Multi_Map_Flag ,  " & _ 
             " @Insu_Code , @Insu_Name , @Price , @Tqty , @Insu_Account_Id ,  " & _ 
             " @Is_Emg_Add , @Is_Kid_Add , @Is_Dental_Add , @Is_Holiday_Add , @Is_Dept_Add ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            " Is_Multi_Map_Flag=@Is_Multi_Map_Flag " & _ 
            "  , Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Price=@Price , Tqty=@Tqty , Insu_Account_Id=@Insu_Account_Id " & _ 
            "  , Is_Emg_Add=@Is_Emg_Add , Is_Kid_Add=@Is_Kid_Add , Is_Dental_Add=@Is_Dental_Add , Is_Holiday_Add=@Is_Holiday_Add , Is_Dept_Add=@Is_Dept_Add " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Order_Type_Id=@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            " Is_Multi_Map_Flag=@Is_Multi_Map_Flag " & _ 
            "  , Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Price=@Price , Tqty=@Tqty , Insu_Account_Id=@Insu_Account_Id " & _ 
            "  , Is_Emg_Add=@Is_Emg_Add , Is_Kid_Add=@Is_Kid_Add , Is_Dental_Add=@Is_Dental_Add , Is_Holiday_Add=@Is_Holiday_Add , Is_Dept_Add=@Is_Dept_Add " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Order_Type_Id=@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
            " Is_Multi_Map_Flag=@Is_Multi_Map_Flag " & _ 
            "  , Insu_Code=@Insu_Code , Insu_Name=@Insu_Name , Price=@Price , Tqty=@Tqty , Insu_Account_Id=@Insu_Account_Id " & _ 
            "  , Is_Emg_Add=@Is_Emg_Add , Is_Kid_Add=@Is_Kid_Add , Is_Dental_Add=@Is_Dental_Add , Is_Holiday_Add=@Is_Holiday_Add , Is_Dept_Add=@Is_Dept_Add " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Order_Type_Id=@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                        Command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                        Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                        Command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                        Command.Parameters.AddWithValue("@Price", row.Item("Price"))
                        Command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                        Command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                        Command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                        Command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                        Command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                        Command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
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
    Public Function delete(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Type_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Insu_Code_Seq As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Order_Type_Id=@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq "
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
                Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                Command.Parameters.AddWithValue("@Order_Type_Id", pk_Order_Type_Id)
                Command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                Command.Parameters.AddWithValue("@Insu_Code_Seq", pk_Insu_Code_Seq)
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
    Public Function queryByPK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Type_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Insu_Code_Seq As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  ") 
            content.AppendLine(" Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  ") 
            content.AppendLine(" Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time                from " & tableName)
            content.AppendLine("   where Effect_Date=@Effect_Date and Order_Type_Id=@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date)
            Command.Parameters.AddWithValue("@Order_Type_Id",pk_Order_Type_Id)
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code)
            Command.Parameters.AddWithValue("@Insu_Code_Seq",pk_Insu_Code_Seq)
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
    Public Function queryByLikePK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Type_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Insu_Code_Seq As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  ") 
            content.AppendLine(" Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  ") 
            content.AppendLine(" Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time                from " & tableName)
            content.AppendLine("   where Effect_Date like @Effect_Date and Order_Type_Id like @Order_Type_Id and Order_Code like @Order_Code and Insu_Code_Seq like @Insu_Code_Seq "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date & "%")
            Command.Parameters.AddWithValue("@Order_Type_Id",pk_Order_Type_Id & "%")
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code & "%")
            Command.Parameters.AddWithValue("@Insu_Code_Seq",pk_Insu_Code_Seq & "%")
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
            content.AppendLine(" Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  ") 
            content.AppendLine(" Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  ") 
            content.AppendLine(" Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time                from " & tableName )
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
            content.Append("select   Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  " & _ 
             " Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  " & _ 
             " Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Is_Dept_Add ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Insu_Code 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Insu_Code 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
