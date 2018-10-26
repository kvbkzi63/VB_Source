Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class IccFeedbackDuporderBO
    'Syscom's CodeGen Produced This VB Code @ 2016/10/17 下午 02:24:11
    Public Shared ReadOnly tableName As String="ICC_FeedBack_DupOrder"
    Private Shared myInstance As IccFeedbackDuporderBO
    Public Shared Function GetInstance() As IccFeedbackDuporderBO
        If myInstance Is Nothing Then
            myInstance = New IccFeedbackDuporderBO()
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
            " Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  " & _ 
             " Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  " & _ 
             " Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  " & _ 
             " Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  " & _ 
             " Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Import_Sn , @Import_Year , @Import_Season , @Hospital_Id , @Media_Type ,  " & _ 
             " @Nhi_Ym , @Nhi_Type_Id , @Nhi_Date , @Idno , @Birth_Date ,  " & _ 
             " @Nhi_Case_Type , @Nhi_Seqno , @Order_No , @Order_Insu_Code , @Order_Tqty ,  " & _ 
             " @Order_Price , @Order_Amt , @Order_Days , @Order_Left_Days , @Order_Earlier_Id ,  " & _ 
             " @Order_Excute_time , @Order_Execute_End_Time , @Dup_days , @Dup_Amt , @Dup_Flag ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
            " Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  " & _ 
             " Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  " & _ 
             " Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  " & _ 
             " Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  " & _ 
             " Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Import_Sn , @Import_Year , @Import_Season , @Hospital_Id , @Media_Type ,  " & _ 
             " @Nhi_Ym , @Nhi_Type_Id , @Nhi_Date , @Idno , @Birth_Date ,  " & _ 
             " @Nhi_Case_Type , @Nhi_Seqno , @Order_No , @Order_Insu_Code , @Order_Tqty ,  " & _ 
             " @Order_Price , @Order_Amt , @Order_Days , @Order_Left_Days , @Order_Earlier_Id ,  " & _ 
             " @Order_Excute_time , @Order_Execute_End_Time , @Dup_days , @Dup_Amt , @Dup_Flag ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
            " Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  " & _ 
             " Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  " & _ 
             " Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  " & _ 
             " Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  " & _ 
             " Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Import_Sn , @Import_Year , @Import_Season , @Hospital_Id , @Media_Type ,  " & _ 
             " @Nhi_Ym , @Nhi_Type_Id , @Nhi_Date , @Idno , @Birth_Date ,  " & _ 
             " @Nhi_Case_Type , @Nhi_Seqno , @Order_No , @Order_Insu_Code , @Order_Tqty ,  " & _ 
             " @Order_Price , @Order_Amt , @Order_Days , @Order_Left_Days , @Order_Earlier_Id ,  " & _ 
             " @Order_Excute_time , @Order_Execute_End_Time , @Dup_days , @Dup_Amt , @Dup_Flag ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
            " Hospital_Id=@Hospital_Id , Media_Type=@Media_Type " & _ 
            "  , Nhi_Ym=@Nhi_Ym , Nhi_Type_Id=@Nhi_Type_Id , Nhi_Date=@Nhi_Date , Idno=@Idno , Birth_Date=@Birth_Date " & _ 
            "  , Nhi_Case_Type=@Nhi_Case_Type , Nhi_Seqno=@Nhi_Seqno , Order_No=@Order_No , Order_Insu_Code=@Order_Insu_Code , Order_Tqty=@Order_Tqty " & _ 
            "  , Order_Price=@Order_Price , Order_Amt=@Order_Amt , Order_Days=@Order_Days , Order_Left_Days=@Order_Left_Days , Order_Earlier_Id=@Order_Earlier_Id " & _ 
            "  , Order_Excute_time=@Order_Excute_time , Order_Execute_End_Time=@Order_Execute_End_Time , Dup_days=@Dup_days , Dup_Amt=@Dup_Amt , Dup_Flag=@Dup_Flag " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Sn=@Import_Sn and Import_Year=@Import_Year and Import_Season=@Import_Season            "
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
            " Hospital_Id=@Hospital_Id , Media_Type=@Media_Type " & _ 
            "  , Nhi_Ym=@Nhi_Ym , Nhi_Type_Id=@Nhi_Type_Id , Nhi_Date=@Nhi_Date , Idno=@Idno , Birth_Date=@Birth_Date " & _ 
            "  , Nhi_Case_Type=@Nhi_Case_Type , Nhi_Seqno=@Nhi_Seqno , Order_No=@Order_No , Order_Insu_Code=@Order_Insu_Code , Order_Tqty=@Order_Tqty " & _ 
            "  , Order_Price=@Order_Price , Order_Amt=@Order_Amt , Order_Days=@Order_Days , Order_Left_Days=@Order_Left_Days , Order_Earlier_Id=@Order_Earlier_Id " & _ 
            "  , Order_Excute_time=@Order_Excute_time , Order_Execute_End_Time=@Order_Execute_End_Time , Dup_days=@Dup_days , Dup_Amt=@Dup_Amt , Dup_Flag=@Dup_Flag " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Sn=@Import_Sn and Import_Year=@Import_Year and Import_Season=@Import_Season            "
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
            " Hospital_Id=@Hospital_Id , Media_Type=@Media_Type " & _ 
            "  , Nhi_Ym=@Nhi_Ym , Nhi_Type_Id=@Nhi_Type_Id , Nhi_Date=@Nhi_Date , Idno=@Idno , Birth_Date=@Birth_Date " & _ 
            "  , Nhi_Case_Type=@Nhi_Case_Type , Nhi_Seqno=@Nhi_Seqno , Order_No=@Order_No , Order_Insu_Code=@Order_Insu_Code , Order_Tqty=@Order_Tqty " & _ 
            "  , Order_Price=@Order_Price , Order_Amt=@Order_Amt , Order_Days=@Order_Days , Order_Left_Days=@Order_Left_Days , Order_Earlier_Id=@Order_Earlier_Id " & _ 
            "  , Order_Excute_time=@Order_Excute_time , Order_Execute_End_Time=@Order_Execute_End_Time , Dup_days=@Dup_days , Dup_Amt=@Dup_Amt , Dup_Flag=@Dup_Flag " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Import_Sn=@Import_Sn and Import_Year=@Import_Year and Import_Season=@Import_Season            "
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
                        Command.Parameters.AddWithValue("@Import_Sn", row.Item("Import_Sn"))
                        Command.Parameters.AddWithValue("@Import_Year", row.Item("Import_Year"))
                        Command.Parameters.AddWithValue("@Import_Season", row.Item("Import_Season"))
                        Command.Parameters.AddWithValue("@Hospital_Id", row.Item("Hospital_Id"))
                        Command.Parameters.AddWithValue("@Media_Type", row.Item("Media_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Ym", row.Item("Nhi_Ym"))
                        Command.Parameters.AddWithValue("@Nhi_Type_Id", row.Item("Nhi_Type_Id"))
                        Command.Parameters.AddWithValue("@Nhi_Date", row.Item("Nhi_Date"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Nhi_Case_Type", row.Item("Nhi_Case_Type"))
                        Command.Parameters.AddWithValue("@Nhi_Seqno", row.Item("Nhi_Seqno"))
                        Command.Parameters.AddWithValue("@Order_No", row.Item("Order_No"))
                        Command.Parameters.AddWithValue("@Order_Insu_Code", row.Item("Order_Insu_Code"))
                        Command.Parameters.AddWithValue("@Order_Tqty", row.Item("Order_Tqty"))
                        Command.Parameters.AddWithValue("@Order_Price", row.Item("Order_Price"))
                        Command.Parameters.AddWithValue("@Order_Amt", row.Item("Order_Amt"))
                        Command.Parameters.AddWithValue("@Order_Days", row.Item("Order_Days"))
                        Command.Parameters.AddWithValue("@Order_Left_Days", row.Item("Order_Left_Days"))
                        Command.Parameters.AddWithValue("@Order_Earlier_Id", row.Item("Order_Earlier_Id"))
                        Command.Parameters.AddWithValue("@Order_Excute_time", row.Item("Order_Excute_time"))
                        Command.Parameters.AddWithValue("@Order_Execute_End_Time", row.Item("Order_Execute_End_Time"))
                        Command.Parameters.AddWithValue("@Dup_days", row.Item("Dup_days"))
                        Command.Parameters.AddWithValue("@Dup_Amt", row.Item("Dup_Amt"))
                        Command.Parameters.AddWithValue("@Dup_Flag", row.Item("Dup_Flag"))
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
    Public Function delete(ByRef pk_Import_Sn As System.String,ByRef pk_Import_Year As System.String,ByRef pk_Import_Season As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Import_Sn=@Import_Sn and Import_Year=@Import_Year and Import_Season=@Import_Season "
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
                Command.Parameters.AddWithValue("@Import_Sn", pk_Import_Sn)
                Command.Parameters.AddWithValue("@Import_Year", pk_Import_Year)
                Command.Parameters.AddWithValue("@Import_Season", pk_Import_Season)
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
    Public Function queryByPK(ByRef pk_Import_Sn As System.String,ByRef pk_Import_Year As System.String,ByRef pk_Import_Season As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  ") 
            content.AppendLine(" Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  ") 
            content.AppendLine(" Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  ") 
            content.AppendLine(" Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  ") 
            content.AppendLine(" Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Import_Sn=@Import_Sn and Import_Year=@Import_Year and Import_Season=@Import_Season            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Import_Sn",pk_Import_Sn)
            Command.Parameters.AddWithValue("@Import_Year",pk_Import_Year)
            Command.Parameters.AddWithValue("@Import_Season",pk_Import_Season)
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
    Public Function queryByLikePK(ByRef pk_Import_Sn As System.String,ByRef pk_Import_Year As System.String,ByRef pk_Import_Season As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  ") 
            content.AppendLine(" Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  ") 
            content.AppendLine(" Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  ") 
            content.AppendLine(" Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  ") 
            content.AppendLine(" Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Import_Sn like @Import_Sn and Import_Year like @Import_Year and Import_Season like @Import_Season "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Import_Sn",pk_Import_Sn & "%")
            Command.Parameters.AddWithValue("@Import_Year",pk_Import_Year & "%")
            Command.Parameters.AddWithValue("@Import_Season",pk_Import_Season & "%")
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
            content.AppendLine(" Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  ") 
            content.AppendLine(" Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  ") 
            content.AppendLine(" Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  ") 
            content.AppendLine(" Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  ") 
            content.AppendLine(" Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName )
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
            content.Append("select   Import_Sn , Import_Year , Import_Season , Hospital_Id , Media_Type ,  " & _ 
             " Nhi_Ym , Nhi_Type_Id , Nhi_Date , Idno , Birth_Date ,  " & _ 
             " Nhi_Case_Type , Nhi_Seqno , Order_No , Order_Insu_Code , Order_Tqty ,  " & _ 
             " Order_Price , Order_Amt , Order_Days , Order_Left_Days , Order_Earlier_Id ,  " & _ 
             " Order_Excute_time , Order_Execute_End_Time , Dup_days , Dup_Amt , Dup_Flag ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time            from " & tableName & " where 1=1 ")
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
    '''取得表格 ICC_FeedBack_DupOrder 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPcsDBSqlConn
    End Function 
#End Region

End Class
