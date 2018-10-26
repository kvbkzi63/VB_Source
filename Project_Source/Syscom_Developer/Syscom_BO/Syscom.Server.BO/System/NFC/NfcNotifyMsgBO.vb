Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class NfcNotifyMsgBO
    'Syscom's CodeGen Produced This VB Code @ 2015/1/15 下午 05:51:07
    Public Shared ReadOnly tableName As String = "NFC_Notify_Msg"
    Private Shared myInstance As NfcNotifyMsgBO
    Public Shared Function GetInstance() As NfcNotifyMsgBO
        If myInstance Is Nothing Then
            myInstance = New NfcNotifyMsgBO()
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
            " MID , SendDate , Type , Start_Time , End_Time ,  " & _
             " Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  " & _
             " Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  " & _
             " Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP " & _
             "  ) " & _
             " values( @MID , @SendDate , @Type , @Start_Time , @End_Time ,  " & _
             " @Status , @Subject , @MsgBody , @ReplyMsg , @ExternalFuction ,  " & _
             " @Recipient , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Level ,  " & _
             " @Group_Type , @Group_Id , @Group_tx_Id , @Spec_Flag , @Call_IP " & _
             "              )"
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
            " MID , SendDate , Type , Start_Time , End_Time ,  " & _
             " Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  " & _
             " Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  " & _
             " Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP " & _
             "  ) " & _
             " values( @MID , @SendDate , @Type , @Start_Time , @End_Time ,  " & _
             " @Status , @Subject , @MsgBody , @ReplyMsg , @ExternalFuction ,  " & _
             " @Recipient , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Level ,  " & _
             " @Group_Type , @Group_Id , @Group_tx_Id , @Spec_Flag , @Call_IP " & _
             "              )"
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
            " MID , SendDate , Type , Start_Time , End_Time ,  " & _
             " Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  " & _
             " Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  " & _
             " Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP " & _
             "  ) " & _
             " values( @MID , @SendDate , @Type , @Start_Time , @End_Time ,  " & _
             " @Status , @Subject , @MsgBody , @ReplyMsg , @ExternalFuction ,  " & _
             " @Recipient , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @App_System_No , @Sub_System_No , @Tsk_Task_no , @Fun_Function_No , @Level ,  " & _
             " @Group_Type , @Group_Id , @Group_tx_Id , @Spec_Flag , @Call_IP " & _
             "              )"
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
            " Type=@Type , Start_Time=@Start_Time , End_Time=@End_Time " & _
            "  , Status=@Status , Subject=@Subject , MsgBody=@MsgBody , ReplyMsg=@ReplyMsg , ExternalFuction=@ExternalFuction " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , App_System_No=@App_System_No , Sub_System_No=@Sub_System_No , Tsk_Task_no=@Tsk_Task_no , Fun_Function_No=@Fun_Function_No , Level=@Level " & _
            "  , Group_Type=@Group_Type , Group_Id=@Group_Id , Group_tx_Id=@Group_tx_Id , Spec_Flag=@Spec_Flag , Call_IP=@Call_IP " & _
            "  " & _
            " where  MID=@MID and SendDate=@SendDate and Recipient=@Recipient            "
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
            " Type=@Type , Start_Time=@Start_Time , End_Time=@End_Time " & _
            "  , Status=@Status , Subject=@Subject , MsgBody=@MsgBody , ReplyMsg=@ReplyMsg , ExternalFuction=@ExternalFuction " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , App_System_No=@App_System_No , Sub_System_No=@Sub_System_No , Tsk_Task_no=@Tsk_Task_no , Fun_Function_No=@Fun_Function_No , Level=@Level " & _
            "  , Group_Type=@Group_Type , Group_Id=@Group_Id , Group_tx_Id=@Group_tx_Id , Spec_Flag=@Spec_Flag , Call_IP=@Call_IP " & _
            "  " & _
            " where  MID=@MID and SendDate=@SendDate and Recipient=@Recipient            "
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
            " Type=@Type , Start_Time=@Start_Time , End_Time=@End_Time " & _
            "  , Status=@Status , Subject=@Subject , MsgBody=@MsgBody , ReplyMsg=@ReplyMsg , ExternalFuction=@ExternalFuction " & _
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , App_System_No=@App_System_No , Sub_System_No=@Sub_System_No , Tsk_Task_no=@Tsk_Task_no , Fun_Function_No=@Fun_Function_No , Level=@Level " & _
            "  , Group_Type=@Group_Type , Group_Id=@Group_Id , Group_tx_Id=@Group_tx_Id , Spec_Flag=@Spec_Flag , Call_IP=@Call_IP " & _
            "  " & _
            " where  MID=@MID and SendDate=@SendDate and Recipient=@Recipient            "
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
                    Command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    Command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    Command.Parameters.AddWithValue("@Type", row.Item("Type"))
                    Command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    Command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    Command.Parameters.AddWithValue("@Status", row.Item("Status"))
                    Command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    Command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    Command.Parameters.AddWithValue("@ReplyMsg", row.Item("ReplyMsg"))
                    Command.Parameters.AddWithValue("@ExternalFuction", row.Item("ExternalFuction"))
                    Command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@App_System_No", row.Item("App_System_No"))
                    Command.Parameters.AddWithValue("@Sub_System_No", row.Item("Sub_System_No"))
                    Command.Parameters.AddWithValue("@Tsk_Task_no", row.Item("Tsk_Task_no"))
                    Command.Parameters.AddWithValue("@Fun_Function_No", row.Item("Fun_Function_No"))
                    Command.Parameters.AddWithValue("@Level", row.Item("Level"))
                    Command.Parameters.AddWithValue("@Group_Type", row.Item("Group_Type"))
                    Command.Parameters.AddWithValue("@Group_Id", row.Item("Group_Id"))
                    Command.Parameters.AddWithValue("@Group_tx_Id", row.Item("Group_tx_Id"))
                    Command.Parameters.AddWithValue("@Spec_Flag", row.Item("Spec_Flag"))
                    Command.Parameters.AddWithValue("@Call_IP", row.Item("Call_IP"))
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
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function delete(ByRef pk_MID As System.String, ByRef pk_SendDate As System.DateTime, ByRef pk_Recipient As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " MID=@MID and SendDate=@SendDate and Recipient=@Recipient "
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
                Command.Parameters.AddWithValue("@MID", pk_MID)
                Command.Parameters.AddWithValue("@SendDate", pk_SendDate)
                Command.Parameters.AddWithValue("@Recipient", pk_Recipient)
                count = Command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function queryByPK(ByRef pk_MID As System.String, ByRef pk_SendDate As System.DateTime, ByRef pk_Recipient As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" MID , SendDate , Type , Start_Time , End_Time ,  ")
            content.AppendLine(" Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  ")
            content.AppendLine(" Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  ")
            content.AppendLine(" Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where MID=@MID and SendDate=@SendDate and Recipient=@Recipient            ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@MID", pk_MID)
            Command.Parameters.AddWithValue("@SendDate", pk_SendDate)
            Command.Parameters.AddWithValue("@Recipient", pk_Recipient)
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
            Throw New CommonException("CMMCMMD001", ex)
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
    Public Function queryByLikePK(ByRef pk_MID As System.String, ByRef pk_SendDate As System.DateTime, ByRef pk_Recipient As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" MID , SendDate , Type , Start_Time , End_Time ,  ")
            content.AppendLine(" Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  ")
            content.AppendLine(" Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  ")
            content.AppendLine(" Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where MID like @MID and SendDate like @SendDate and Recipient like @Recipient ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@MID", pk_MID & "%")
            Command.Parameters.AddWithValue("@SendDate", pk_SendDate & "%")
            Command.Parameters.AddWithValue("@Recipient", pk_Recipient & "%")
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
            Throw New CommonException("CMMCMMD001", ex)
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
            content.AppendLine(" MID , SendDate , Type , Start_Time , End_Time ,  ")
            content.AppendLine(" Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  ")
            content.AppendLine(" Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  ")
            content.AppendLine(" Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP ")
            content.AppendLine("                 from " & tableName)
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
            Throw New CommonException("CMMCMMD001", ex)
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
            Throw New CommonException("CMMCMMD001", ex)
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
            content.Append("select   MID , SendDate , Type , Start_Time , End_Time ,  " & _
             " Status , Subject , MsgBody , ReplyMsg , ExternalFuction ,  " & _
             " Recipient , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " App_System_No , Sub_System_No , Tsk_Task_no , Fun_Function_No , Level ,  " & _
             " Group_Type , Group_Id , Group_tx_Id , Spec_Flag , Call_IP " & _
             "             from " & tableName & " where 1=1 ")
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


#End Region

#Region "查詢當天發版通知,註記已讀"
    ''' <summary>
    '''查詢當天發版通知
    ''' </summary>
    ''' <param name="_type">執行程式</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks></remarks>
    Public Function QueryDeployByToDay(ByVal _type As String, ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim nowDateTime As Date = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
        'Dim sqlString As String = "select MID,SendDate,Recipient, Subject,MsgBody,[Type],Create_User from NFC_Notify_Msg where Start_Time <=@nowDateTime " _
        '                        & " and End_Time>=@nowDateTime  and [Type]=@_type  and Status <> 'Y' and ([Recipient]=@Recipient) or [Type]='C')  "
        Dim sqlString As String = "select * from NFC_Notify_Msg with(nolock) " & _
                                  " where (Start_Time <=@nowDateTime " & _
                                  " and End_Time>=@nowDateTime  and [Type]=@_type and (ReplyMsg='' or ReplyMsg IS NULL)  and (Status <> 'Y' or Spec_Flag='Y') and  [Recipient]=@Recipient ) " & _
                                  "or ([Group_Id]='ALL' and Start_Time <=@nowDateTime and  End_Time>=@nowDateTime)"


        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
            command.Parameters.AddWithValue("@nowDateTime", nowDateTime)
            command.Parameters.AddWithValue("@_type", _type)
            command.Parameters.AddWithValue("@Recipient", EmployeeCode)
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
    ''' 駐記為已讀
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <remarks></remarks>
    Public Function reMarkRead(ByVal ds As Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Dim sqlStr As String = "update NFC_Notify_Msg set Status=@Status , Modified_User=@Modified_User , Modified_Time=@Modified_Time where   MID=@MID and SendDate=@SendDate and Recipient=@Recipient and Type='W' "

        If connFlag Then
            conn = getConnection()
            conn.Open()
        End If
        Try
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlStr
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    command.Parameters.AddWithValue("@SendDate", row.Item("SendDate"))
                    command.Parameters.AddWithValue("@Recipient", row.Item("Recipient"))

                    command.Parameters.AddWithValue("@Status", "Y")
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Recipient"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)
                    Dim cnt As Integer = command.ExecuteNonQuery
                End Using
            Next
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return 0
    End Function
   
    Public Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Dim sqlStr As String = "update NFC_Notify_Msg set Spec_Flag=@spec_Flag , Modified_User=@modified_User  where   MID=@mid  "
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlStr
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@MID", mid)
                command.Parameters.AddWithValue("@spec_Flag", "O")

                command.Parameters.AddWithValue("@Modified_User", modified_User)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery
            End Using

            Return 0
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
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


#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 NFC_Notify_Msg 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region


End Class
