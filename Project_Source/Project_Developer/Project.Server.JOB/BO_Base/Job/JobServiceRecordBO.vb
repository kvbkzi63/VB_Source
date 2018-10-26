Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class JobServiceRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2017/11/15 下午 02:36:02
    Public Shared ReadOnly tableName As String="JOB_Service_Record"
    Private Shared myInstance As JobServiceRecordBO
    Public Shared Function GetInstance() As JobServiceRecordBO
        If myInstance Is Nothing Then
            myInstance = New JobServiceRecordBO()
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
            " Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  " & _ 
             " Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  " & _ 
             " Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  " & _ 
             " Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  " & _ 
             " Cancel , Cancel_Reason , Cancel_Time , Cancel_User ) " & _ 
             " values( @Issue_Id , @JOB_Code , @Project_Id , @System_Code , @Function_Code ,  " & _ 
             " @Receive_DateTime , @Issue_Source , @Issue_Description , @Issue_Classify , @Issue_Status ,  " & _ 
             " @Contact_User , @Contact_Way , @Contact_Note , @Processing_Approach , @Processing_Employee_Code ,  " & _ 
             " @Processing_Cost , @Finish_Date , @Estimated_Finish_Date , @Note , @Att_FID ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Hospital_Code ,  " & _ 
             " @Cancel , @Cancel_Reason , @Cancel_Time , @Cancel_User             )"
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
            " Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  " & _ 
             " Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  " & _ 
             " Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  " & _ 
             " Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  " & _ 
             " Cancel , Cancel_Reason , Cancel_Time , Cancel_User ) " & _ 
             " values( @Issue_Id , @JOB_Code , @Project_Id , @System_Code , @Function_Code ,  " & _ 
             " @Receive_DateTime , @Issue_Source , @Issue_Description , @Issue_Classify , @Issue_Status ,  " & _ 
             " @Contact_User , @Contact_Way , @Contact_Note , @Processing_Approach , @Processing_Employee_Code ,  " & _ 
             " @Processing_Cost , @Finish_Date , @Estimated_Finish_Date , @Note , @Att_FID ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Hospital_Code ,  " & _ 
             " @Cancel , @Cancel_Reason , @Cancel_Time , @Cancel_User             )"
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
            " Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  " & _ 
             " Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  " & _ 
             " Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  " & _ 
             " Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  " & _ 
             " Cancel , Cancel_Reason , Cancel_Time , Cancel_User ) " & _ 
             " values( @Issue_Id , @JOB_Code , @Project_Id , @System_Code , @Function_Code ,  " & _ 
             " @Receive_DateTime , @Issue_Source , @Issue_Description , @Issue_Classify , @Issue_Status ,  " & _ 
             " @Contact_User , @Contact_Way , @Contact_Note , @Processing_Approach , @Processing_Employee_Code ,  " & _ 
             " @Processing_Cost , @Finish_Date , @Estimated_Finish_Date , @Note , @Att_FID ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Hospital_Code ,  " & _ 
             " @Cancel , @Cancel_Reason , @Cancel_Time , @Cancel_User             )"
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
            " JOB_Code=@JOB_Code , Project_Id=@Project_Id , System_Code=@System_Code , Function_Code=@Function_Code " & _ 
            "  , Receive_DateTime=@Receive_DateTime , Issue_Source=@Issue_Source , Issue_Description=@Issue_Description , Issue_Classify=@Issue_Classify , Issue_Status=@Issue_Status " & _ 
            "  , Contact_User=@Contact_User , Contact_Way=@Contact_Way , Contact_Note=@Contact_Note , Processing_Approach=@Processing_Approach , Processing_Employee_Code=@Processing_Employee_Code " & _ 
            "  , Processing_Cost=@Processing_Cost , Finish_Date=@Finish_Date , Estimated_Finish_Date=@Estimated_Finish_Date , Note=@Note , Att_FID=@Att_FID " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Hospital_Code=@Hospital_Code " & _ 
            "  , Cancel=@Cancel , Cancel_Reason=@Cancel_Reason , Cancel_Time=@Cancel_Time , Cancel_User=@Cancel_User " & _ 
            " where  Issue_Id=@Issue_Id            "
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
            " JOB_Code=@JOB_Code , Project_Id=@Project_Id , System_Code=@System_Code , Function_Code=@Function_Code " & _ 
            "  , Receive_DateTime=@Receive_DateTime , Issue_Source=@Issue_Source , Issue_Description=@Issue_Description , Issue_Classify=@Issue_Classify , Issue_Status=@Issue_Status " & _ 
            "  , Contact_User=@Contact_User , Contact_Way=@Contact_Way , Contact_Note=@Contact_Note , Processing_Approach=@Processing_Approach , Processing_Employee_Code=@Processing_Employee_Code " & _ 
            "  , Processing_Cost=@Processing_Cost , Finish_Date=@Finish_Date , Estimated_Finish_Date=@Estimated_Finish_Date , Note=@Note , Att_FID=@Att_FID " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Hospital_Code=@Hospital_Code " & _ 
            "  , Cancel=@Cancel , Cancel_Reason=@Cancel_Reason , Cancel_Time=@Cancel_Time , Cancel_User=@Cancel_User " & _ 
            " where  Issue_Id=@Issue_Id            "
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
            " JOB_Code=@JOB_Code , Project_Id=@Project_Id , System_Code=@System_Code , Function_Code=@Function_Code " & _ 
            "  , Receive_DateTime=@Receive_DateTime , Issue_Source=@Issue_Source , Issue_Description=@Issue_Description , Issue_Classify=@Issue_Classify , Issue_Status=@Issue_Status " & _ 
            "  , Contact_User=@Contact_User , Contact_Way=@Contact_Way , Contact_Note=@Contact_Note , Processing_Approach=@Processing_Approach , Processing_Employee_Code=@Processing_Employee_Code " & _ 
            "  , Processing_Cost=@Processing_Cost , Finish_Date=@Finish_Date , Estimated_Finish_Date=@Estimated_Finish_Date , Note=@Note , Att_FID=@Att_FID " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Hospital_Code=@Hospital_Code " & _ 
            "  , Cancel=@Cancel , Cancel_Reason=@Cancel_Reason , Cancel_Time=@Cancel_Time , Cancel_User=@Cancel_User " & _ 
            " where  Issue_Id=@Issue_Id            "
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
                        Command.Parameters.AddWithValue("@Issue_Id", row.Item("Issue_Id"))
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Project_Id", row.Item("Project_Id"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Receive_DateTime", row.Item("Receive_DateTime"))
                        Command.Parameters.AddWithValue("@Issue_Source", row.Item("Issue_Source"))
                        Command.Parameters.AddWithValue("@Issue_Description", row.Item("Issue_Description"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Status", row.Item("Issue_Status"))
                        Command.Parameters.AddWithValue("@Contact_User", row.Item("Contact_User"))
                        Command.Parameters.AddWithValue("@Contact_Way", row.Item("Contact_Way"))
                        Command.Parameters.AddWithValue("@Contact_Note", row.Item("Contact_Note"))
                        Command.Parameters.AddWithValue("@Processing_Approach", row.Item("Processing_Approach"))
                        Command.Parameters.AddWithValue("@Processing_Employee_Code", row.Item("Processing_Employee_Code"))
                        Command.Parameters.AddWithValue("@Processing_Cost", row.Item("Processing_Cost"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@Estimated_Finish_Date", row.Item("Estimated_Finish_Date"))
                        Command.Parameters.AddWithValue("@Note", row.Item("Note"))
                        Command.Parameters.AddWithValue("@Att_FID", row.Item("Att_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
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
    Public Function delete(ByRef pk_Issue_Id As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Issue_Id=@Issue_Id "
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
                Command.Parameters.AddWithValue("@Issue_Id", pk_Issue_Id)
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
    Public Function queryByPK(ByRef pk_Issue_Id As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  ") 
            content.AppendLine(" Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  ") 
            content.AppendLine(" Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  ") 
            content.AppendLine(" Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  ") 
            content.AppendLine(" Cancel , Cancel_Reason , Cancel_Time , Cancel_User                from " & tableName)
            content.AppendLine("   where Issue_Id=@Issue_Id            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Issue_Id",pk_Issue_Id)
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
    Public Function queryByLikePK(ByRef pk_Issue_Id As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  ") 
            content.AppendLine(" Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  ") 
            content.AppendLine(" Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  ") 
            content.AppendLine(" Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  ") 
            content.AppendLine(" Cancel , Cancel_Reason , Cancel_Time , Cancel_User                from " & tableName)
            content.AppendLine("   where Issue_Id like @Issue_Id "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Issue_Id",pk_Issue_Id & "%")
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
            content.AppendLine(" Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  ") 
            content.AppendLine(" Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  ") 
            content.AppendLine(" Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  ") 
            content.AppendLine(" Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  ") 
            content.AppendLine(" Cancel , Cancel_Reason , Cancel_Time , Cancel_User                from " & tableName )
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
            content.Append("select   Issue_Id , JOB_Code , Project_Id , System_Code , Function_Code ,  " & _ 
             " Receive_DateTime , Issue_Source , Issue_Description , Issue_Classify , Issue_Status ,  " & _ 
             " Contact_User , Contact_Way , Contact_Note , Processing_Approach , Processing_Employee_Code ,  " & _ 
             " Processing_Cost , Finish_Date , Estimated_Finish_Date , Note , Att_FID ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Hospital_Code ,  " & _ 
             " Cancel , Cancel_Reason , Cancel_Time , Cancel_User            from " & tableName & " where 1=1 ")
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
    '''取得表格 JOB_Service_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
