Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM

Public Class JobSaAssignRecordBO
    'Syscom's CodeGen Produced This VB Code @ 2018/10/9 下午 05:22:27
    Public Shared ReadOnly tableName As String="JOB_SA_Assign_Record"
    Private Shared myInstance As JobSaAssignRecordBO
    Public Shared Function GetInstance() As JobSaAssignRecordBO
        If myInstance Is Nothing Then
            myInstance = New JobSaAssignRecordBO()
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
            " JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  " & _ 
             " System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  " & _ 
             " Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  " & _ 
             " Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  " & _ 
             " Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  " & _ 
             " Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  " & _ 
             " SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status ) " & _ 
             " values( @JOB_Code , @Assign_Date , @Project_ID , @PG_Employee_Code , @Finish_Date ,  " & _ 
             " @System_Code , @Function_Code , @Issue_Classify , @Issue_Deadline , @Issue_Desc ,  " & _ 
             " @Reply_Date , @FID , @RTF_FID , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Reject_Flag , @Cancel , @Cancel_User ,  " & _ 
             " @Cancel_Time , @Cancel_Reason , @Mail_Subject , @Mail_Group_Id , @Test_Report_Flag ,  " & _ 
             " @Assign_Source , @SD_Confirm , @SD_Note , @SD_Employee_Code , @Issue_Level ,  " & _ 
             " @Issue_Cost_Time , @Job_Status , @Estimate_Cost , @SD_Estimate_Cost , @SD_Cost_Time ,  " & _ 
             " @SD_Issue_Deadline , @SD_Confirm_Date , @Hospital_Code , @Job_Special_Status             )"
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
            " JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  " & _ 
             " System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  " & _ 
             " Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  " & _ 
             " Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  " & _ 
             " Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  " & _ 
             " Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  " & _ 
             " SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status ) " & _ 
             " values( @JOB_Code , @Assign_Date , @Project_ID , @PG_Employee_Code , @Finish_Date ,  " & _ 
             " @System_Code , @Function_Code , @Issue_Classify , @Issue_Deadline , @Issue_Desc ,  " & _ 
             " @Reply_Date , @FID , @RTF_FID , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Reject_Flag , @Cancel , @Cancel_User ,  " & _ 
             " @Cancel_Time , @Cancel_Reason , @Mail_Subject , @Mail_Group_Id , @Test_Report_Flag ,  " & _ 
             " @Assign_Source , @SD_Confirm , @SD_Note , @SD_Employee_Code , @Issue_Level ,  " & _ 
             " @Issue_Cost_Time , @Job_Status , @Estimate_Cost , @SD_Estimate_Cost , @SD_Cost_Time ,  " & _ 
             " @SD_Issue_Deadline , @SD_Confirm_Date , @Hospital_Code , @Job_Special_Status             )"
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
            " JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  " & _ 
             " System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  " & _ 
             " Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  " & _ 
             " Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  " & _ 
             " Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  " & _ 
             " Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  " & _ 
             " SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status ) " & _ 
             " values( @JOB_Code , @Assign_Date , @Project_ID , @PG_Employee_Code , @Finish_Date ,  " & _ 
             " @System_Code , @Function_Code , @Issue_Classify , @Issue_Deadline , @Issue_Desc ,  " & _ 
             " @Reply_Date , @FID , @RTF_FID , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Reject_Flag , @Cancel , @Cancel_User ,  " & _ 
             " @Cancel_Time , @Cancel_Reason , @Mail_Subject , @Mail_Group_Id , @Test_Report_Flag ,  " & _ 
             " @Assign_Source , @SD_Confirm , @SD_Note , @SD_Employee_Code , @Issue_Level ,  " & _ 
             " @Issue_Cost_Time , @Job_Status , @Estimate_Cost , @SD_Estimate_Cost , @SD_Cost_Time ,  " & _ 
             " @SD_Issue_Deadline , @SD_Confirm_Date , @Hospital_Code , @Job_Special_Status             )"
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
            " Assign_Date=@Assign_Date , Project_ID=@Project_ID , PG_Employee_Code=@PG_Employee_Code , Finish_Date=@Finish_Date " & _ 
            "  , System_Code=@System_Code , Function_Code=@Function_Code , Issue_Classify=@Issue_Classify , Issue_Deadline=@Issue_Deadline , Issue_Desc=@Issue_Desc " & _ 
            "  , Reply_Date=@Reply_Date , FID=@FID , RTF_FID=@RTF_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Reject_Flag=@Reject_Flag , Cancel=@Cancel , Cancel_User=@Cancel_User " & _ 
            "  , Cancel_Time=@Cancel_Time , Cancel_Reason=@Cancel_Reason , Mail_Subject=@Mail_Subject , Mail_Group_Id=@Mail_Group_Id , Test_Report_Flag=@Test_Report_Flag " & _ 
            "  , Assign_Source=@Assign_Source , SD_Confirm=@SD_Confirm , SD_Note=@SD_Note , SD_Employee_Code=@SD_Employee_Code , Issue_Level=@Issue_Level " & _ 
            "  , Issue_Cost_Time=@Issue_Cost_Time , Job_Status=@Job_Status , Estimate_Cost=@Estimate_Cost , SD_Estimate_Cost=@SD_Estimate_Cost , SD_Cost_Time=@SD_Cost_Time " & _ 
            "  , SD_Issue_Deadline=@SD_Issue_Deadline , SD_Confirm_Date=@SD_Confirm_Date , Hospital_Code=@Hospital_Code , Job_Special_Status=@Job_Special_Status " & _ 
            " where  JOB_Code=@JOB_Code            "
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
            " Assign_Date=@Assign_Date , Project_ID=@Project_ID , PG_Employee_Code=@PG_Employee_Code , Finish_Date=@Finish_Date " & _ 
            "  , System_Code=@System_Code , Function_Code=@Function_Code , Issue_Classify=@Issue_Classify , Issue_Deadline=@Issue_Deadline , Issue_Desc=@Issue_Desc " & _ 
            "  , Reply_Date=@Reply_Date , FID=@FID , RTF_FID=@RTF_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Reject_Flag=@Reject_Flag , Cancel=@Cancel , Cancel_User=@Cancel_User " & _ 
            "  , Cancel_Time=@Cancel_Time , Cancel_Reason=@Cancel_Reason , Mail_Subject=@Mail_Subject , Mail_Group_Id=@Mail_Group_Id , Test_Report_Flag=@Test_Report_Flag " & _ 
            "  , Assign_Source=@Assign_Source , SD_Confirm=@SD_Confirm , SD_Note=@SD_Note , SD_Employee_Code=@SD_Employee_Code , Issue_Level=@Issue_Level " & _ 
            "  , Issue_Cost_Time=@Issue_Cost_Time , Job_Status=@Job_Status , Estimate_Cost=@Estimate_Cost , SD_Estimate_Cost=@SD_Estimate_Cost , SD_Cost_Time=@SD_Cost_Time " & _ 
            "  , SD_Issue_Deadline=@SD_Issue_Deadline , SD_Confirm_Date=@SD_Confirm_Date , Hospital_Code=@Hospital_Code , Job_Special_Status=@Job_Special_Status " & _ 
            " where  JOB_Code=@JOB_Code            "
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
            " Assign_Date=@Assign_Date , Project_ID=@Project_ID , PG_Employee_Code=@PG_Employee_Code , Finish_Date=@Finish_Date " & _ 
            "  , System_Code=@System_Code , Function_Code=@Function_Code , Issue_Classify=@Issue_Classify , Issue_Deadline=@Issue_Deadline , Issue_Desc=@Issue_Desc " & _ 
            "  , Reply_Date=@Reply_Date , FID=@FID , RTF_FID=@RTF_FID , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Reject_Flag=@Reject_Flag , Cancel=@Cancel , Cancel_User=@Cancel_User " & _ 
            "  , Cancel_Time=@Cancel_Time , Cancel_Reason=@Cancel_Reason , Mail_Subject=@Mail_Subject , Mail_Group_Id=@Mail_Group_Id , Test_Report_Flag=@Test_Report_Flag " & _ 
            "  , Assign_Source=@Assign_Source , SD_Confirm=@SD_Confirm , SD_Note=@SD_Note , SD_Employee_Code=@SD_Employee_Code , Issue_Level=@Issue_Level " & _ 
            "  , Issue_Cost_Time=@Issue_Cost_Time , Job_Status=@Job_Status , Estimate_Cost=@Estimate_Cost , SD_Estimate_Cost=@SD_Estimate_Cost , SD_Cost_Time=@SD_Cost_Time " & _ 
            "  , SD_Issue_Deadline=@SD_Issue_Deadline , SD_Confirm_Date=@SD_Confirm_Date , Hospital_Code=@Hospital_Code , Job_Special_Status=@Job_Special_Status " & _ 
            " where  JOB_Code=@JOB_Code            "
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
                        Command.Parameters.AddWithValue("@JOB_Code", row.Item("JOB_Code"))
                        Command.Parameters.AddWithValue("@Assign_Date", row.Item("Assign_Date"))
                        Command.Parameters.AddWithValue("@Project_ID", row.Item("Project_ID"))
                        Command.Parameters.AddWithValue("@PG_Employee_Code", row.Item("PG_Employee_Code"))
                        Command.Parameters.AddWithValue("@Finish_Date", row.Item("Finish_Date"))
                        Command.Parameters.AddWithValue("@System_Code", row.Item("System_Code"))
                        Command.Parameters.AddWithValue("@Function_Code", row.Item("Function_Code"))
                        Command.Parameters.AddWithValue("@Issue_Classify", row.Item("Issue_Classify"))
                        Command.Parameters.AddWithValue("@Issue_Deadline", row.Item("Issue_Deadline"))
                        Command.Parameters.AddWithValue("@Issue_Desc", row.Item("Issue_Desc"))
                        Command.Parameters.AddWithValue("@Reply_Date", row.Item("Reply_Date"))
                        Command.Parameters.AddWithValue("@FID", row.Item("FID"))
                        Command.Parameters.AddWithValue("@RTF_FID", row.Item("RTF_FID"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Reject_Flag", row.Item("Reject_Flag"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Cancel_Reason", row.Item("Cancel_Reason"))
                        Command.Parameters.AddWithValue("@Mail_Subject", row.Item("Mail_Subject"))
                        Command.Parameters.AddWithValue("@Mail_Group_Id", row.Item("Mail_Group_Id"))
                        Command.Parameters.AddWithValue("@Test_Report_Flag", row.Item("Test_Report_Flag"))
                        Command.Parameters.AddWithValue("@Assign_Source", row.Item("Assign_Source"))
                        Command.Parameters.AddWithValue("@SD_Confirm", row.Item("SD_Confirm"))
                        Command.Parameters.AddWithValue("@SD_Note", row.Item("SD_Note"))
                        Command.Parameters.AddWithValue("@SD_Employee_Code", row.Item("SD_Employee_Code"))
                        Command.Parameters.AddWithValue("@Issue_Level", row.Item("Issue_Level"))
                        Command.Parameters.AddWithValue("@Issue_Cost_Time", row.Item("Issue_Cost_Time"))
                        Command.Parameters.AddWithValue("@Job_Status", row.Item("Job_Status"))
                        Command.Parameters.AddWithValue("@Estimate_Cost", row.Item("Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Estimate_Cost", row.Item("SD_Estimate_Cost"))
                        Command.Parameters.AddWithValue("@SD_Cost_Time", row.Item("SD_Cost_Time"))
                        Command.Parameters.AddWithValue("@SD_Issue_Deadline", row.Item("SD_Issue_Deadline"))
                        Command.Parameters.AddWithValue("@SD_Confirm_Date", row.Item("SD_Confirm_Date"))
                        Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                        Command.Parameters.AddWithValue("@Job_Special_Status", row.Item("Job_Special_Status"))
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
    Public Function delete(ByRef pk_JOB_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " JOB_Code=@JOB_Code "
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
                Command.Parameters.AddWithValue("@JOB_Code", pk_JOB_Code)
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
    Public Function queryByPK(ByRef pk_JOB_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  ") 
            content.AppendLine(" System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  ") 
            content.AppendLine(" Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  ") 
            content.AppendLine(" Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  ") 
            content.AppendLine(" Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  ") 
            content.AppendLine(" Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  ") 
            content.AppendLine(" SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status                from " & tableName)
            content.AppendLine("   where JOB_Code=@JOB_Code            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@JOB_Code",pk_JOB_Code)
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
    Public Function queryByLikePK(ByRef pk_JOB_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  ") 
            content.AppendLine(" System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  ") 
            content.AppendLine(" Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  ") 
            content.AppendLine(" Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  ") 
            content.AppendLine(" Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  ") 
            content.AppendLine(" Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  ") 
            content.AppendLine(" SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status                from " & tableName)
            content.AppendLine("   where JOB_Code like @JOB_Code "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@JOB_Code",pk_JOB_Code & "%")
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
            content.AppendLine(" JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  ") 
            content.AppendLine(" System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  ") 
            content.AppendLine(" Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  ") 
            content.AppendLine(" Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  ") 
            content.AppendLine(" Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  ") 
            content.AppendLine(" Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  ") 
            content.AppendLine(" SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status                from " & tableName )
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
            content.Append("select   JOB_Code , Assign_Date , Project_ID , PG_Employee_Code , Finish_Date ,  " & _ 
             " System_Code , Function_Code , Issue_Classify , Issue_Deadline , Issue_Desc ,  " & _ 
             " Reply_Date , FID , RTF_FID , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Reject_Flag , Cancel , Cancel_User ,  " & _ 
             " Cancel_Time , Cancel_Reason , Mail_Subject , Mail_Group_Id , Test_Report_Flag ,  " & _ 
             " Assign_Source , SD_Confirm , SD_Note , SD_Employee_Code , Issue_Level ,  " & _ 
             " Issue_Cost_Time , Job_Status , Estimate_Cost , SD_Estimate_Cost , SD_Cost_Time ,  " & _ 
             " SD_Issue_Deadline , SD_Confirm_Date , Hospital_Code , Job_Special_Status            from " & tableName & " where 1=1 ")
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
    '''取得表格 JOB_SA_Assign_Record 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function 
#End Region

End Class
