Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class OphAlertRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2015/11/23 下午 08:08:04
    Public Shared ReadOnly tableName As String="OPH_Alert_Record"
    Private Shared myInstance As OphAlertRecordBO
    Public Shared Function GetInstance() As OphAlertRecordBO
        If myInstance Is Nothing Then
            myInstance = New OphAlertRecordBO()
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
            " Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  " & _ 
             " Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  " & _ 
             " Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  " & _ 
             " Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  " & _ 
             " Create_User , Create_Time , False_Message ) " & _ 
             " values( @Medical_Sn , @Item_Code , @Order_Code1 , @Order_Sn , @Opd_Visit_Date ,  " & _ 
             " @Order_Record_No , @Counter_Code , @Pharmacy_Sn , @Pharmacy_Sn_No , @Chart_No ,  " & _ 
             " @Pharmacy_12_Code1 , @Order_Record_No2 , @Order_Code2 , @Pharmacy_12_Code2 , @Dept_Code ,  " & _ 
             " @Order_Doctor_Code , @Doubt_Content , @Rule_Reason_Code , @Rule_Reason_Else , @Limit_Alert_Level ,  " & _ 
             " @Create_User , @Create_Time , @False_Message             )"
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
            " Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  " & _ 
             " Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  " & _ 
             " Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  " & _ 
             " Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  " & _ 
             " Create_User , Create_Time , False_Message ) " & _ 
             " values( @Medical_Sn , @Item_Code , @Order_Code1 , @Order_Sn , @Opd_Visit_Date ,  " & _ 
             " @Order_Record_No , @Counter_Code , @Pharmacy_Sn , @Pharmacy_Sn_No , @Chart_No ,  " & _ 
             " @Pharmacy_12_Code1 , @Order_Record_No2 , @Order_Code2 , @Pharmacy_12_Code2 , @Dept_Code ,  " & _ 
             " @Order_Doctor_Code , @Doubt_Content , @Rule_Reason_Code , @Rule_Reason_Else , @Limit_Alert_Level ,  " & _ 
             " @Create_User , @Create_Time , @False_Message             )"
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
            " Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  " & _ 
             " Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  " & _ 
             " Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  " & _ 
             " Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  " & _ 
             " Create_User , Create_Time , False_Message ) " & _ 
             " values( @Medical_Sn , @Item_Code , @Order_Code1 , @Order_Sn , @Opd_Visit_Date ,  " & _ 
             " @Order_Record_No , @Counter_Code , @Pharmacy_Sn , @Pharmacy_Sn_No , @Chart_No ,  " & _ 
             " @Pharmacy_12_Code1 , @Order_Record_No2 , @Order_Code2 , @Pharmacy_12_Code2 , @Dept_Code ,  " & _ 
             " @Order_Doctor_Code , @Doubt_Content , @Rule_Reason_Code , @Rule_Reason_Else , @Limit_Alert_Level ,  " & _ 
             " @Create_User , @Create_Time , @False_Message             )"
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
            " Opd_Visit_Date=@Opd_Visit_Date " & _ 
            "  , Order_Record_No=@Order_Record_No , Counter_Code=@Counter_Code , Pharmacy_Sn=@Pharmacy_Sn , Pharmacy_Sn_No=@Pharmacy_Sn_No , Chart_No=@Chart_No " & _ 
            "  , Pharmacy_12_Code1=@Pharmacy_12_Code1 , Order_Record_No2=@Order_Record_No2 , Order_Code2=@Order_Code2 , Pharmacy_12_Code2=@Pharmacy_12_Code2 , Dept_Code=@Dept_Code " & _ 
            "  , Order_Doctor_Code=@Order_Doctor_Code , Doubt_Content=@Doubt_Content , Rule_Reason_Code=@Rule_Reason_Code , Rule_Reason_Else=@Rule_Reason_Else , Limit_Alert_Level=@Limit_Alert_Level " & _ 
            "  , False_Message=@False_Message " & _ 
            " where  Medical_Sn=@Medical_Sn and Item_Code=@Item_Code and Order_Code1=@Order_Code1 and Order_Sn=@Order_Sn            "
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
            " Opd_Visit_Date=@Opd_Visit_Date " & _ 
            "  , Order_Record_No=@Order_Record_No , Counter_Code=@Counter_Code , Pharmacy_Sn=@Pharmacy_Sn , Pharmacy_Sn_No=@Pharmacy_Sn_No , Chart_No=@Chart_No " & _ 
            "  , Pharmacy_12_Code1=@Pharmacy_12_Code1 , Order_Record_No2=@Order_Record_No2 , Order_Code2=@Order_Code2 , Pharmacy_12_Code2=@Pharmacy_12_Code2 , Dept_Code=@Dept_Code " & _ 
            "  , Order_Doctor_Code=@Order_Doctor_Code , Doubt_Content=@Doubt_Content , Rule_Reason_Code=@Rule_Reason_Code , Rule_Reason_Else=@Rule_Reason_Else , Limit_Alert_Level=@Limit_Alert_Level " & _ 
            "  , False_Message=@False_Message " & _ 
            " where  Medical_Sn=@Medical_Sn and Item_Code=@Item_Code and Order_Code1=@Order_Code1 and Order_Sn=@Order_Sn            "
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
            " Opd_Visit_Date=@Opd_Visit_Date " & _ 
            "  , Order_Record_No=@Order_Record_No , Counter_Code=@Counter_Code , Pharmacy_Sn=@Pharmacy_Sn , Pharmacy_Sn_No=@Pharmacy_Sn_No , Chart_No=@Chart_No " & _ 
            "  , Pharmacy_12_Code1=@Pharmacy_12_Code1 , Order_Record_No2=@Order_Record_No2 , Order_Code2=@Order_Code2 , Pharmacy_12_Code2=@Pharmacy_12_Code2 , Dept_Code=@Dept_Code " & _ 
            "  , Order_Doctor_Code=@Order_Doctor_Code , Doubt_Content=@Doubt_Content , Rule_Reason_Code=@Rule_Reason_Code , Rule_Reason_Else=@Rule_Reason_Else , Limit_Alert_Level=@Limit_Alert_Level " & _ 
            "  , False_Message=@False_Message " & _ 
            " where  Medical_Sn=@Medical_Sn and Item_Code=@Item_Code and Order_Code1=@Order_Code1 and Order_Sn=@Order_Sn            "
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
                        Command.Parameters.AddWithValue("@Medical_Sn", row.Item("Medical_Sn"))
                        Command.Parameters.AddWithValue("@Item_Code", row.Item("Item_Code"))
                        Command.Parameters.AddWithValue("@Order_Code1", row.Item("Order_Code1"))
                        Command.Parameters.AddWithValue("@Order_Sn", row.Item("Order_Sn"))
                        Command.Parameters.AddWithValue("@Opd_Visit_Date", row.Item("Opd_Visit_Date"))
                        Command.Parameters.AddWithValue("@Order_Record_No", row.Item("Order_Record_No"))
                        Command.Parameters.AddWithValue("@Counter_Code", row.Item("Counter_Code"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn", row.Item("Pharmacy_Sn"))
                        Command.Parameters.AddWithValue("@Pharmacy_Sn_No", row.Item("Pharmacy_Sn_No"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code1", row.Item("Pharmacy_12_Code1"))
                        Command.Parameters.AddWithValue("@Order_Record_No2", row.Item("Order_Record_No2"))
                        Command.Parameters.AddWithValue("@Order_Code2", row.Item("Order_Code2"))
                        Command.Parameters.AddWithValue("@Pharmacy_12_Code2", row.Item("Pharmacy_12_Code2"))
                        Command.Parameters.AddWithValue("@Dept_Code", row.Item("Dept_Code"))
                        Command.Parameters.AddWithValue("@Order_Doctor_Code", row.Item("Order_Doctor_Code"))
                        Command.Parameters.AddWithValue("@Doubt_Content", row.Item("Doubt_Content"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Code", row.Item("Rule_Reason_Code"))
                        Command.Parameters.AddWithValue("@Rule_Reason_Else", row.Item("Rule_Reason_Else"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
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
    Public Function delete(ByRef pk_Medical_Sn As System.String,ByRef pk_Item_Code As System.String,ByRef pk_Order_Code1 As System.String,ByRef pk_Order_Sn As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Medical_Sn=@Medical_Sn and Item_Code=@Item_Code and Order_Code1=@Order_Code1 and Order_Sn=@Order_Sn "
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
                Command.Parameters.AddWithValue("@Medical_Sn", pk_Medical_Sn)
                Command.Parameters.AddWithValue("@Item_Code", pk_Item_Code)
                Command.Parameters.AddWithValue("@Order_Code1", pk_Order_Code1)
                Command.Parameters.AddWithValue("@Order_Sn", pk_Order_Sn)
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
    Public Function queryByPK(ByRef pk_Medical_Sn As System.String,ByRef pk_Item_Code As System.String,ByRef pk_Order_Code1 As System.String,ByRef pk_Order_Sn As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  ") 
            content.AppendLine(" Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  ") 
            content.AppendLine(" Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  ") 
            content.AppendLine(" Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  ") 
            content.AppendLine(" Create_User , Create_Time , False_Message                from " & tableName)
            content.AppendLine("   where Medical_Sn=@Medical_Sn and Item_Code=@Item_Code and Order_Code1=@Order_Code1 and Order_Sn=@Order_Sn            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Medical_Sn",pk_Medical_Sn)
            Command.Parameters.AddWithValue("@Item_Code",pk_Item_Code)
            Command.Parameters.AddWithValue("@Order_Code1",pk_Order_Code1)
            Command.Parameters.AddWithValue("@Order_Sn",pk_Order_Sn)
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
    Public Function queryByLikePK(ByRef pk_Medical_Sn As System.String,ByRef pk_Item_Code As System.String,ByRef pk_Order_Code1 As System.String,ByRef pk_Order_Sn As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  ") 
            content.AppendLine(" Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  ") 
            content.AppendLine(" Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  ") 
            content.AppendLine(" Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  ") 
            content.AppendLine(" Create_User , Create_Time , False_Message                from " & tableName)
            content.AppendLine("   where Medical_Sn like @Medical_Sn and Item_Code like @Item_Code and Order_Code1 like @Order_Code1 and Order_Sn like @Order_Sn "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Medical_Sn",pk_Medical_Sn & "%")
            Command.Parameters.AddWithValue("@Item_Code",pk_Item_Code & "%")
            Command.Parameters.AddWithValue("@Order_Code1",pk_Order_Code1 & "%")
            Command.Parameters.AddWithValue("@Order_Sn",pk_Order_Sn & "%")
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
            content.AppendLine(" Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  ") 
            content.AppendLine(" Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  ") 
            content.AppendLine(" Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  ") 
            content.AppendLine(" Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  ") 
            content.AppendLine(" Create_User , Create_Time , False_Message                from " & tableName )
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
            content.Append("select   Medical_Sn , Item_Code , Order_Code1 , Order_Sn , Opd_Visit_Date ,  " & _ 
             " Order_Record_No , Counter_Code , Pharmacy_Sn , Pharmacy_Sn_No , Chart_No ,  " & _ 
             " Pharmacy_12_Code1 , Order_Record_No2 , Order_Code2 , Pharmacy_12_Code2 , Dept_Code ,  " & _ 
             " Order_Doctor_Code , Doubt_Content , Rule_Reason_Code , Rule_Reason_Else , Limit_Alert_Level ,  " & _ 
             " Create_User , Create_Time , False_Message            from " & tableName & " where 1=1 ")
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
    '''取得表格 OPH_Alert_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
