Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class PubPatientPersonalHabitsBO
    'Syscom's CodeGen Produced This VB Code @ 2016/8/15 下午 01:42:15
    Public Shared ReadOnly tableName As String="PUB_Patient_Personal_Habits"
    Private Shared myInstance As PubPatientPersonalHabitsBO
    Public Shared Function GetInstance() As PubPatientPersonalHabitsBO
        If myInstance Is Nothing Then
            myInstance = New PubPatientPersonalHabitsBO()
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
            " Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  " & _ 
             " Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  " & _ 
             " Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  " & _ 
             " Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  " & _ 
             " Smoker_Name , Smoker_Relation ) " & _ 
             " values( @Chart_No , @Smoke_Id , @Smoke_Advise , @Smoke_Qty , @Smoke_Year ,  " & _ 
             " @Drink_Wine_Id , @Wine_Kind , @Wine_Qty , @Wine_Year , @Eat_Nut_Id ,  " & _ 
             " @Nut_Advise , @Nut_Qty , @Nut_Year , @Exercise_Id , @Exercise_Year ,  " & _ 
             " @Last_Ask_Date , @Advise_Date , @Advise_User , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Passive_Smoking , @Is_Smoker_Advise , @Smoker_Advise_Date ,  " & _ 
             " @Smoker_Name , @Smoker_Relation             )"
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
            " Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  " & _ 
             " Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  " & _ 
             " Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  " & _ 
             " Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  " & _ 
             " Smoker_Name , Smoker_Relation ) " & _ 
             " values( @Chart_No , @Smoke_Id , @Smoke_Advise , @Smoke_Qty , @Smoke_Year ,  " & _ 
             " @Drink_Wine_Id , @Wine_Kind , @Wine_Qty , @Wine_Year , @Eat_Nut_Id ,  " & _ 
             " @Nut_Advise , @Nut_Qty , @Nut_Year , @Exercise_Id , @Exercise_Year ,  " & _ 
             " @Last_Ask_Date , @Advise_Date , @Advise_User , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Passive_Smoking , @Is_Smoker_Advise , @Smoker_Advise_Date ,  " & _ 
             " @Smoker_Name , @Smoker_Relation             )"
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
            " Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  " & _ 
             " Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  " & _ 
             " Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  " & _ 
             " Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  " & _ 
             " Smoker_Name , Smoker_Relation ) " & _ 
             " values( @Chart_No , @Smoke_Id , @Smoke_Advise , @Smoke_Qty , @Smoke_Year ,  " & _ 
             " @Drink_Wine_Id , @Wine_Kind , @Wine_Qty , @Wine_Year , @Eat_Nut_Id ,  " & _ 
             " @Nut_Advise , @Nut_Qty , @Nut_Year , @Exercise_Id , @Exercise_Year ,  " & _ 
             " @Last_Ask_Date , @Advise_Date , @Advise_User , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Passive_Smoking , @Is_Smoker_Advise , @Smoker_Advise_Date ,  " & _ 
             " @Smoker_Name , @Smoker_Relation             )"
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
            " Smoke_Id=@Smoke_Id , Smoke_Advise=@Smoke_Advise , Smoke_Qty=@Smoke_Qty , Smoke_Year=@Smoke_Year " & _ 
            "  , Drink_Wine_Id=@Drink_Wine_Id , Wine_Kind=@Wine_Kind , Wine_Qty=@Wine_Qty , Wine_Year=@Wine_Year , Eat_Nut_Id=@Eat_Nut_Id " & _ 
            "  , Nut_Advise=@Nut_Advise , Nut_Qty=@Nut_Qty , Nut_Year=@Nut_Year , Exercise_Id=@Exercise_Id , Exercise_Year=@Exercise_Year " & _ 
            "  , Last_Ask_Date=@Last_Ask_Date , Advise_Date=@Advise_Date , Advise_User=@Advise_User , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Passive_Smoking=@Is_Passive_Smoking , Is_Smoker_Advise=@Is_Smoker_Advise , Smoker_Advise_Date=@Smoker_Advise_Date " & _ 
            "  , Smoker_Name=@Smoker_Name , Smoker_Relation=@Smoker_Relation " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
            " Smoke_Id=@Smoke_Id , Smoke_Advise=@Smoke_Advise , Smoke_Qty=@Smoke_Qty , Smoke_Year=@Smoke_Year " & _ 
            "  , Drink_Wine_Id=@Drink_Wine_Id , Wine_Kind=@Wine_Kind , Wine_Qty=@Wine_Qty , Wine_Year=@Wine_Year , Eat_Nut_Id=@Eat_Nut_Id " & _ 
            "  , Nut_Advise=@Nut_Advise , Nut_Qty=@Nut_Qty , Nut_Year=@Nut_Year , Exercise_Id=@Exercise_Id , Exercise_Year=@Exercise_Year " & _ 
            "  , Last_Ask_Date=@Last_Ask_Date , Advise_Date=@Advise_Date , Advise_User=@Advise_User , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Passive_Smoking=@Is_Passive_Smoking , Is_Smoker_Advise=@Is_Smoker_Advise , Smoker_Advise_Date=@Smoker_Advise_Date " & _ 
            "  , Smoker_Name=@Smoker_Name , Smoker_Relation=@Smoker_Relation " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
            " Smoke_Id=@Smoke_Id , Smoke_Advise=@Smoke_Advise , Smoke_Qty=@Smoke_Qty , Smoke_Year=@Smoke_Year " & _ 
            "  , Drink_Wine_Id=@Drink_Wine_Id , Wine_Kind=@Wine_Kind , Wine_Qty=@Wine_Qty , Wine_Year=@Wine_Year , Eat_Nut_Id=@Eat_Nut_Id " & _ 
            "  , Nut_Advise=@Nut_Advise , Nut_Qty=@Nut_Qty , Nut_Year=@Nut_Year , Exercise_Id=@Exercise_Id , Exercise_Year=@Exercise_Year " & _ 
            "  , Last_Ask_Date=@Last_Ask_Date , Advise_Date=@Advise_Date , Advise_User=@Advise_User , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Passive_Smoking=@Is_Passive_Smoking , Is_Smoker_Advise=@Is_Smoker_Advise , Smoker_Advise_Date=@Smoker_Advise_Date " & _ 
            "  , Smoker_Name=@Smoker_Name , Smoker_Relation=@Smoker_Relation " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Smoke_Id", row.Item("Smoke_Id"))
                        Command.Parameters.AddWithValue("@Smoke_Advise", row.Item("Smoke_Advise"))
                        Command.Parameters.AddWithValue("@Smoke_Qty", row.Item("Smoke_Qty"))
                        Command.Parameters.AddWithValue("@Smoke_Year", row.Item("Smoke_Year"))
                        Command.Parameters.AddWithValue("@Drink_Wine_Id", row.Item("Drink_Wine_Id"))
                        Command.Parameters.AddWithValue("@Wine_Kind", row.Item("Wine_Kind"))
                        Command.Parameters.AddWithValue("@Wine_Qty", row.Item("Wine_Qty"))
                        Command.Parameters.AddWithValue("@Wine_Year", row.Item("Wine_Year"))
                        Command.Parameters.AddWithValue("@Eat_Nut_Id", row.Item("Eat_Nut_Id"))
                        Command.Parameters.AddWithValue("@Nut_Advise", row.Item("Nut_Advise"))
                        Command.Parameters.AddWithValue("@Nut_Qty", row.Item("Nut_Qty"))
                        Command.Parameters.AddWithValue("@Nut_Year", row.Item("Nut_Year"))
                        Command.Parameters.AddWithValue("@Exercise_Id", row.Item("Exercise_Id"))
                        Command.Parameters.AddWithValue("@Exercise_Year", row.Item("Exercise_Year"))
                        Command.Parameters.AddWithValue("@Last_Ask_Date", row.Item("Last_Ask_Date"))
                        Command.Parameters.AddWithValue("@Advise_Date", row.Item("Advise_Date"))
                        Command.Parameters.AddWithValue("@Advise_User", row.Item("Advise_User"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Passive_Smoking", row.Item("Is_Passive_Smoking"))
                        Command.Parameters.AddWithValue("@Is_Smoker_Advise", row.Item("Is_Smoker_Advise"))
                        Command.Parameters.AddWithValue("@Smoker_Advise_Date", row.Item("Smoker_Advise_Date"))
                        Command.Parameters.AddWithValue("@Smoker_Name", row.Item("Smoker_Name"))
                        Command.Parameters.AddWithValue("@Smoker_Relation", row.Item("Smoker_Relation"))
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
    Public Function delete(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Chart_No=@Chart_No "
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
    Public Function queryByPK(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  ") 
            content.AppendLine(" Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  ") 
            content.AppendLine(" Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  ") 
            content.AppendLine(" Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  ") 
            content.AppendLine(" Smoker_Name , Smoker_Relation                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No)
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
    Public Function queryByLikePK(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  ") 
            content.AppendLine(" Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  ") 
            content.AppendLine(" Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  ") 
            content.AppendLine(" Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  ") 
            content.AppendLine(" Smoker_Name , Smoker_Relation                from " & tableName)
            content.AppendLine("   where Chart_No like @Chart_No "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No & "%")
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
            content.AppendLine(" Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  ") 
            content.AppendLine(" Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  ") 
            content.AppendLine(" Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  ") 
            content.AppendLine(" Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  ") 
            content.AppendLine(" Smoker_Name , Smoker_Relation                from " & tableName )
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
            content.Append("select   Chart_No , Smoke_Id , Smoke_Advise , Smoke_Qty , Smoke_Year ,  " & _ 
             " Drink_Wine_Id , Wine_Kind , Wine_Qty , Wine_Year , Eat_Nut_Id ,  " & _ 
             " Nut_Advise , Nut_Qty , Nut_Year , Exercise_Id , Exercise_Year ,  " & _ 
             " Last_Ask_Date , Advise_Date , Advise_User , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Passive_Smoking , Is_Smoker_Advise , Smoker_Advise_Date ,  " & _ 
             " Smoker_Name , Smoker_Relation            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Patient_Personal_Habits 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient_Personal_Habits 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
