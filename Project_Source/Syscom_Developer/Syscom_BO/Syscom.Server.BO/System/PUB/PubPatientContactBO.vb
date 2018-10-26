Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubPatientContactBO
    'Syscom's CodeGen Produced This VB Code @ 2016/4/9 下午 12:04:31
    Public Shared ReadOnly tableName As String="PUB_Patient_Contact"
    Private Shared myInstance As PubPatientContactBO
    Public Shared Function GetInstance() As PubPatientContactBO
        If myInstance Is Nothing Then
            myInstance = New PubPatientContactBO()
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
            " Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  " & _ 
             " Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  " & _ 
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  " & _ 
             " Vil_Code ) " & _ 
             " values( @Chart_No , @Patient_Contact_No , @Contact_Name , @Relation_Type_Id , @Contact_Tel_Home ,  " & _ 
             " @Contact_Tel_Office , @Contact_Tel_Mobile , @Contact_Postal_Code , @Contact_Address , @Contact_Email ,  " & _ 
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Keyin_Unit , @Contact_Sort_Value , @Contact_Memo , @Special_Identity , @Dist_Code ,  " & _ 
             " @Vil_Code             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row) '備份機制
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
            " Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  " & _ 
             " Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  " & _ 
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  " & _ 
             " Vil_Code ) " & _ 
             " values( @Chart_No , @Patient_Contact_No , @Contact_Name , @Relation_Type_Id , @Contact_Tel_Home ,  " & _ 
             " @Contact_Tel_Office , @Contact_Tel_Mobile , @Contact_Postal_Code , @Contact_Address , @Contact_Email ,  " & _ 
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Keyin_Unit , @Contact_Sort_Value , @Contact_Memo , @Special_Identity , @Dist_Code ,  " & _ 
             " @Vil_Code             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row) '備份機制
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
            " Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  " & _ 
             " Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  " & _ 
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  " & _ 
             " Vil_Code ) " & _ 
             " values( @Chart_No , @Patient_Contact_No , @Contact_Name , @Relation_Type_Id , @Contact_Tel_Home ,  " & _ 
             " @Contact_Tel_Office , @Contact_Tel_Mobile , @Contact_Postal_Code , @Contact_Address , @Contact_Email ,  " & _ 
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Keyin_Unit , @Contact_Sort_Value , @Contact_Memo , @Special_Identity , @Dist_Code ,  " & _ 
             " @Vil_Code             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row) '備份機制
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
            " Contact_Name=@Contact_Name , Relation_Type_Id=@Relation_Type_Id , Contact_Tel_Home=@Contact_Tel_Home " & _ 
            "  , Contact_Tel_Office=@Contact_Tel_Office , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Postal_Code=@Contact_Postal_Code , Contact_Address=@Contact_Address , Contact_Email=@Contact_Email " & _ 
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Contact_Sort_Value=@Contact_Sort_Value , Contact_Memo=@Contact_Memo , Special_Identity=@Special_Identity , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code " & _ 
            " where  Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No and Keyin_Unit=@Keyin_Unit            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                    'Add By Lits on 2016-04-08
                    '備份機制 insert BK檔Create_User，Create_Time 必須有資料
                        Dim _ds As DataSet = queryByPK(row.Item("Chart_No"),row.Item("Patient_Contact_No"),row.Item("Keyin_Unit"))
                If _ds.Tables(0).Rows.Count > 0 Then
                    row("Create_User") = _ds.Tables(0).Rows(0).Item("Create_User")
                    row("Create_Time") = _ds.Tables(0).Rows(0).Item("Create_Time")
                End If
                updateBackup(row) '備份機制
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
            " Contact_Name=@Contact_Name , Relation_Type_Id=@Relation_Type_Id , Contact_Tel_Home=@Contact_Tel_Home " & _ 
            "  , Contact_Tel_Office=@Contact_Tel_Office , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Postal_Code=@Contact_Postal_Code , Contact_Address=@Contact_Address , Contact_Email=@Contact_Email " & _ 
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Contact_Sort_Value=@Contact_Sort_Value , Contact_Memo=@Contact_Memo , Special_Identity=@Special_Identity , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code " & _ 
            " where  Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No and Keyin_Unit=@Keyin_Unit            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                    'Add By Lits on 2016-04-08
                    '備份機制 insert BK檔Create_User，Create_Time 必須有資料
                        Dim _ds As DataSet = queryByPK(row.Item("Chart_No"),row.Item("Patient_Contact_No"),row.Item("Keyin_Unit"))
                If _ds.Tables(0).Rows.Count > 0 Then
                    row("Create_User") = _ds.Tables(0).Rows(0).Item("Create_User")
                    row("Create_Time") = _ds.Tables(0).Rows(0).Item("Create_Time")
                End If
                updateBackup(row) '備份機制
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
            " Contact_Name=@Contact_Name , Relation_Type_Id=@Relation_Type_Id , Contact_Tel_Home=@Contact_Tel_Home " & _ 
            "  , Contact_Tel_Office=@Contact_Tel_Office , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Postal_Code=@Contact_Postal_Code , Contact_Address=@Contact_Address , Contact_Email=@Contact_Email " & _ 
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Contact_Sort_Value=@Contact_Sort_Value , Contact_Memo=@Contact_Memo , Special_Identity=@Special_Identity , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code " & _ 
            " where  Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No and Keyin_Unit=@Keyin_Unit            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Home", row.Item("Contact_Tel_Home"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Office", row.Item("Contact_Tel_Office"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Keyin_Unit", row.Item("Keyin_Unit"))
                        Command.Parameters.AddWithValue("@Contact_Sort_Value", row.Item("Contact_Sort_Value"))
                        Command.Parameters.AddWithValue("@Contact_Memo", row.Item("Contact_Memo"))
                        Command.Parameters.AddWithValue("@Special_Identity", row.Item("Special_Identity"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                    'Add By Lits on 2016-04-08
                    '備份機制 insert BK檔Create_User，Create_Time 必須有資料
                        Dim _ds As DataSet = queryByPK(row.Item("Chart_No"),row.Item("Patient_Contact_No"),row.Item("Keyin_Unit"))
                If _ds.Tables(0).Rows.Count > 0 Then
                    row("Create_User") = _ds.Tables(0).Rows(0).Item("Create_User")
                    row("Create_Time") = _ds.Tables(0).Rows(0).Item("Create_Time")
                End If
                updateBackup(row) '備份機制
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
    Public Function delete(ByRef pk_Chart_No As System.String,ByRef pk_Patient_Contact_No As System.Int32,ByRef pk_Keyin_Unit As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
                  deleteBackup(pk_Chart_No,pk_Patient_Contact_No,pk_Keyin_Unit,conn) '備份機制
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No and Keyin_Unit=@Keyin_Unit "
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
                Command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
                Command.Parameters.AddWithValue("@Patient_Contact_No", pk_Patient_Contact_No)
                Command.Parameters.AddWithValue("@Keyin_Unit", pk_Keyin_Unit)
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
    Public Function queryByPK(ByRef pk_Chart_No As System.String,ByRef pk_Patient_Contact_No As System.Int32,ByRef pk_Keyin_Unit As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  ") 
            content.AppendLine(" Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  ") 
            content.AppendLine(" Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  ") 
            content.AppendLine(" Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No and Keyin_Unit=@Keyin_Unit            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No)
            Command.Parameters.AddWithValue("@Patient_Contact_No",pk_Patient_Contact_No)
            Command.Parameters.AddWithValue("@Keyin_Unit",pk_Keyin_Unit)
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
    Public Function queryByLikePK(ByRef pk_Chart_No As System.String,ByRef pk_Patient_Contact_No As System.Int32,ByRef pk_Keyin_Unit As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  ") 
            content.AppendLine(" Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  ") 
            content.AppendLine(" Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  ") 
            content.AppendLine(" Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code                from " & tableName)
            content.AppendLine("   where Chart_No like @Chart_No and Patient_Contact_No like @Patient_Contact_No and Keyin_Unit like @Keyin_Unit "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No & "%")
            Command.Parameters.AddWithValue("@Patient_Contact_No",pk_Patient_Contact_No & "%")
            Command.Parameters.AddWithValue("@Keyin_Unit",pk_Keyin_Unit & "%")
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
            content.AppendLine(" Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  ") 
            content.AppendLine(" Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  ") 
            content.AppendLine(" Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  ") 
            content.AppendLine(" Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code                from " & tableName )
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
            content.Append("select   Chart_No , Patient_Contact_No , Contact_Name , Relation_Type_Id , Contact_Tel_Home ,  " & _ 
             " Contact_Tel_Office , Contact_Tel_Mobile , Contact_Postal_Code , Contact_Address , Contact_Email ,  " & _ 
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Keyin_Unit , Contact_Sort_Value , Contact_Memo , Special_Identity , Dist_Code ,  " & _ 
             " Vil_Code            from " & tableName & " where 1=1 ")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Contact_No")
            dt.Columns("Patient_Contact_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Contact_Name")
            dt.Columns("Contact_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Relation_Type_Id")
            dt.Columns("Relation_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Home")
            dt.Columns("Contact_Tel_Home").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Office")
            dt.Columns("Contact_Tel_Office").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns("Contact_Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns("Contact_Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Address")
            dt.Columns("Contact_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Email")
            dt.Columns("Contact_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Keyin_Unit")
            dt.Columns("Keyin_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Sort_Value")
            dt.Columns("Contact_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Contact_Memo")
            dt.Columns("Contact_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Special_Identity")
            dt.Columns("Special_Identity").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code")
            dt.Columns("Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code")
            dt.Columns("Vil_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(4) As DataColumn 
            pkColArray(2) = dt.Columns("Chart_No")
            pkColArray(3) = dt.Columns("Patient_Contact_No")
            pkColArray(4) = dt.Columns("Keyin_Unit")
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
        Protected Sub insertBackup(ByVal row As DataRow)
            dataBackup("Insert", row)
        End Sub
    
    
        ''' <summary>
        ''' 備份新增資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub insertBackupTable(ByVal table As DataTable)
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    insertBackup(row)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackup(ByVal row As DataRow)
            dataBackup("Update", row)
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackupTable(ByVal table As DataTable)
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    updateBackup(row)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份主程式
        ''' </summary>
        ''' <param name="action"></param>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow)
            Dim bkDS = New DataSet
            Dim bkTable = getDataTableBKWithSchema()
            Dim bkRow = bkTable.NewRow()
            bkRow("Action") = action
            bkRow("Backup_Time") = Now
                bkRow("Chart_No") = row.Item("Chart_No")
                bkRow("Patient_Contact_No") = row.Item("Patient_Contact_No")
                bkRow("Contact_Name") = row.Item("Contact_Name")
                bkRow("Relation_Type_Id") = row.Item("Relation_Type_Id")
                bkRow("Contact_Tel_Home") = row.Item("Contact_Tel_Home")
                bkRow("Contact_Tel_Office") = row.Item("Contact_Tel_Office")
                bkRow("Contact_Tel_Mobile") = row.Item("Contact_Tel_Mobile")
                bkRow("Contact_Postal_Code") = row.Item("Contact_Postal_Code")
                bkRow("Contact_Address") = row.Item("Contact_Address")
                bkRow("Contact_Email") = row.Item("Contact_Email")
                bkRow("Dc") = row.Item("Dc")
                bkRow("Create_User") = row.Item("Create_User")
                bkRow("Create_Time") = row.Item("Create_Time")
                bkRow("Modified_User") = row.Item("Modified_User")
                bkRow("Modified_Time") = row.Item("Modified_Time")
                bkRow("Keyin_Unit") = row.Item("Keyin_Unit")
                bkRow("Contact_Sort_Value") = row.Item("Contact_Sort_Value")
                bkRow("Contact_Memo") = row.Item("Contact_Memo")
                bkRow("Special_Identity") = row.Item("Special_Identity")
                bkRow("Dist_Code") = row.Item("Dist_Code")
                bkRow("Vil_Code") = row.Item("Vil_Code")
            bkTable.Rows.Add(bkRow)
            bkDS.Tables.Add(bkTable)
            MessageQueueUtil.getInstance.sendBackupTableMessage(bkDS)
        End Sub
    
    
        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
        Protected Sub deleteBackup(ByVal row As DataRow)
            Dim user As New UserProfile
            If row("Modified_User") IsNot Nothing Then
                row("Modified_User") = user.userId
            End If
            If row("Modified_Time") IsNot Nothing Then
                row("Modified_Time") = Now
            End If
            dataBackup("Delete", row)
        End Sub
    
    
         ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub deleteBackupTable(ByVal table As DataTable)
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    deleteBackup(row)
                Next
            End If
        End Sub

        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>       
        Protected Sub deleteBackup(ByVal pk_Chart_No As System.String,ByVal pk_Patient_Contact_No As System.Int32,ByVal pk_Keyin_Unit As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing)
    
            Dim bkDS As System.Data.DataSet = queryByPK(pk_Chart_No,pk_Patient_Contact_No,pk_Keyin_Unit, conn)
            If bkDS IsNot Nothing _
            AndAlso bkDS.Tables.Count > 0 _
            AndAlso bkDS.Tables(0) IsNot Nothing _
            AndAlso bkDS.Tables(0).Rows.Count > 0 _
            AndAlso bkDS.Tables(0).Rows(0) IsNot Nothing _
            Then
                deleteBackup(bkDS.Tables(0).Rows(0)) 
            Else
                'Throw New Exception("No Data To Delete")
            End If
        End Sub

#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient_Contact 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getNisDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient_Contact 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
