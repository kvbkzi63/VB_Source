Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class OmoPreventationHealthCare
    'Syscom's CodeGen Produced This VB Code @ 2016/1/19 下午 05:19:11
    Public Shared ReadOnly tableName As String = "OMO_Preventation_Health_Care"
    Private Shared myInstance As OmoPreventationHealthCare
    Public Shared Function GetInstance() As OmoPreventationHealthCare
        If myInstance Is Nothing Then
            myInstance = New OmoPreventationHealthCare()
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
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  " & _
             " Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  " & _
             " Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  " & _
             " Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  " & _
             " Create_Time , Modified_User , Modified_Time , Remind_Cnt ) " & _
             " values( @Chart_No , @Prevent_No , @Care_Item_Code , @Care_Order_Code , @Care_Cardseq ,  " & _
             " @Outpatient_Sn , @Is_Positive , @Is_Will , @Effect_Date , @End_Date ,  " & _
             " @Remind_Date , @Remind_User , @Remind_Dept , @Execute_Date , @Outpatient_Sn_Exe ,  " & _
             " @Execute_User , @Execute_Dept , @Execute_Date_External , @Execute_External_Hospital , @Create_User ,  " & _
             " @Create_Time , @Modified_User , @Modified_Time , @Remind_Cnt             )"
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  " & _
             " Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  " & _
             " Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  " & _
             " Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  " & _
             " Create_Time , Modified_User , Modified_Time , Remind_Cnt ) " & _
             " values( @Chart_No , @Prevent_No , @Care_Item_Code , @Care_Order_Code , @Care_Cardseq ,  " & _
             " @Outpatient_Sn , @Is_Positive , @Is_Will , @Effect_Date , @End_Date ,  " & _
             " @Remind_Date , @Remind_User , @Remind_Dept , @Execute_Date , @Outpatient_Sn_Exe ,  " & _
             " @Execute_User , @Execute_Dept , @Execute_Date_External , @Execute_External_Hospital , @Create_User ,  " & _
             " @Create_Time , @Modified_User , @Modified_Time , @Remind_Cnt             )"
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  " & _
             " Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  " & _
             " Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  " & _
             " Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  " & _
             " Create_Time , Modified_User , Modified_Time , Remind_Cnt ) " & _
             " values( @Chart_No , @Prevent_No , @Care_Item_Code , @Care_Order_Code , @Care_Cardseq ,  " & _
             " @Outpatient_Sn , @Is_Positive , @Is_Will , @Effect_Date , @End_Date ,  " & _
             " @Remind_Date , @Remind_User , @Remind_Dept , @Execute_Date , @Outpatient_Sn_Exe ,  " & _
             " @Execute_User , @Execute_Dept , @Execute_Date_External , @Execute_External_Hospital , @Create_User ,  " & _
             " @Create_Time , @Modified_User , @Modified_Time , @Remind_Cnt             )"
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Care_Item_Code=@Care_Item_Code , Care_Order_Code=@Care_Order_Code , Care_Cardseq=@Care_Cardseq " & _
            "  , Outpatient_Sn=@Outpatient_Sn , Is_Positive=@Is_Positive , Is_Will=@Is_Will , Effect_Date=@Effect_Date , End_Date=@End_Date " & _
            "  , Remind_Date=@Remind_Date , Remind_User=@Remind_User , Remind_Dept=@Remind_Dept , Execute_Date=@Execute_Date , Outpatient_Sn_Exe=@Outpatient_Sn_Exe " & _
            "  , Execute_User=@Execute_User , Execute_Dept=@Execute_Dept , Execute_Date_External=@Execute_Date_External , Execute_External_Hospital=@Execute_External_Hospital , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Remind_Cnt=@Remind_Cnt " & _
            " where  Chart_No=@Chart_No and Prevent_No=@Prevent_No            "
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Care_Item_Code=@Care_Item_Code , Care_Order_Code=@Care_Order_Code , Care_Cardseq=@Care_Cardseq " & _
            "  , Outpatient_Sn=@Outpatient_Sn , Is_Positive=@Is_Positive , Is_Will=@Is_Will , Effect_Date=@Effect_Date , End_Date=@End_Date " & _
            "  , Remind_Date=@Remind_Date , Remind_User=@Remind_User , Remind_Dept=@Remind_Dept , Execute_Date=@Execute_Date , Outpatient_Sn_Exe=@Outpatient_Sn_Exe " & _
            "  , Execute_User=@Execute_User , Execute_Dept=@Execute_Dept , Execute_Date_External=@Execute_Date_External , Execute_External_Hospital=@Execute_External_Hospital , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Remind_Cnt=@Remind_Cnt " & _
            " where  Chart_No=@Chart_No and Prevent_No=@Prevent_No            "
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Care_Item_Code=@Care_Item_Code , Care_Order_Code=@Care_Order_Code , Care_Cardseq=@Care_Cardseq " & _
            "  , Outpatient_Sn=@Outpatient_Sn , Is_Positive=@Is_Positive , Is_Will=@Is_Will , Effect_Date=@Effect_Date , End_Date=@End_Date " & _
            "  , Remind_Date=@Remind_Date , Remind_User=@Remind_User , Remind_Dept=@Remind_Dept , Execute_Date=@Execute_Date , Outpatient_Sn_Exe=@Outpatient_Sn_Exe " & _
            "  , Execute_User=@Execute_User , Execute_Dept=@Execute_Dept , Execute_Date_External=@Execute_Date_External , Execute_External_Hospital=@Execute_External_Hospital , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Remind_Cnt=@Remind_Cnt " & _
            " where  Chart_No=@Chart_No and Prevent_No=@Prevent_No            "
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
                    Command.Parameters.AddWithValue("@Prevent_No", row.Item("Prevent_No"))
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn", row.Item("Outpatient_Sn"))
                    Command.Parameters.AddWithValue("@Is_Positive", row.Item("Is_Positive"))
                    Command.Parameters.AddWithValue("@Is_Will", row.Item("Is_Will"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Remind_Date", row.Item("Remind_Date"))
                    Command.Parameters.AddWithValue("@Remind_User", row.Item("Remind_User"))
                    Command.Parameters.AddWithValue("@Remind_Dept", row.Item("Remind_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date", row.Item("Execute_Date"))
                    Command.Parameters.AddWithValue("@Outpatient_Sn_Exe", row.Item("Outpatient_Sn_Exe"))
                    Command.Parameters.AddWithValue("@Execute_User", row.Item("Execute_User"))
                    Command.Parameters.AddWithValue("@Execute_Dept", row.Item("Execute_Dept"))
                    Command.Parameters.AddWithValue("@Execute_Date_External", row.Item("Execute_Date_External"))
                    Command.Parameters.AddWithValue("@Execute_External_Hospital", row.Item("Execute_External_Hospital"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@Remind_Cnt", row.Item("Remind_Cnt"))
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
    Public Function delete(ByRef pk_Chart_No As System.String, ByRef pk_Prevent_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Chart_No=@Chart_No and Prevent_No=@Prevent_No "
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
                Command.Parameters.AddWithValue("@Prevent_No", pk_Prevent_No)
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
    Public Function queryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Prevent_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  ")
            content.AppendLine(" Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  ")
            content.AppendLine(" Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  ")
            content.AppendLine(" Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  ")
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Remind_Cnt                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No and Prevent_No=@Prevent_No            ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
            Command.Parameters.AddWithValue("@Prevent_No", pk_Prevent_No)
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
    Public Function queryByLikePK(ByRef pk_Chart_No As System.String, ByRef pk_Prevent_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  ")
            content.AppendLine(" Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  ")
            content.AppendLine(" Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  ")
            content.AppendLine(" Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  ")
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Remind_Cnt                from " & tableName)
            content.AppendLine("   where Chart_No like @Chart_No and Prevent_No like @Prevent_No ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Chart_No", pk_Chart_No & "%")
            Command.Parameters.AddWithValue("@Prevent_No", pk_Prevent_No & "%")
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
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  ")
            content.AppendLine(" Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  ")
            content.AppendLine(" Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  ")
            content.AppendLine(" Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  ")
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Remind_Cnt                from " & tableName)
            command.CommandText = content.tostring
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
    Public Function dynamicQuery(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
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
    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select   Chart_No , Prevent_No , Care_Item_Code , Care_Order_Code , Care_Cardseq ,  " & _
             " Outpatient_Sn , Is_Positive , Is_Will , Effect_Date , End_Date ,  " & _
             " Remind_Date , Remind_User , Remind_Dept , Execute_Date , Outpatient_Sn_Exe ,  " & _
             " Execute_User , Execute_Dept , Execute_Date_External , Execute_External_Hospital , Create_User ,  " & _
             " Create_Time , Modified_User , Modified_Time , Remind_Cnt            from " & tableName & " where 1=1 ")
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
    '''取得表格 OMO_Preventation_Health_Care 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function
#End Region

End Class
