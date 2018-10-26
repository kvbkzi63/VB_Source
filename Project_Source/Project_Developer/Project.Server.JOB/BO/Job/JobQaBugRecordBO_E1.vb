'/*
'*****************************************************************************
'*
'*    Page/Class Name:  JobQaBugRecordBO_E1
'*              Title:	JobQaBugRecordBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-10-01
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-10-01
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Project.Comm.JOB
Imports Syscom.Server.SNC
Imports Project.Server.JOB
Imports Syscom.Server.CMM



Public Class JobQaBugRecordBO_E1
    Inherits JobQaBugRecordBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobQaBugRecordBO_E1
    Public Overloads Shared Function GetInstance() As JobQaBugRecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobQaBugRecordBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
#Region " 新增BUG "

    ''' <summary>
    ''' 新增BUG
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function CreateNewBug(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("Result")
        retDS.Tables(0).Columns.Add("BugCnt")
        retDS.Tables(0).Columns.Add("AttCnt")
        retDS.Tables(0).Columns.Add("UpdateCnt")
        Try
            Dim count As Integer = 0

            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                Dim retDR As DataRow = retDS.Tables(0).NewRow

                '新增BUG紀錄
                Dim NewBugID As String = input.Tables(0).Rows(0)("Project_Id").ToString.Trim &
                                         Now.ToString("yyyy") &
                                         Syscom.Comm.Utility.StringUtil.appendCharToLeft(GetMaxSeqNo(input.Tables(0).Rows(0)("Version_Id").ToString.Trim, conn), CChar("0"), 6)
                For Each dr As DataRow In input.Tables(0).Rows
                    dr(JobQaBugRecordDataTableFactory.DBColumnName.Bug_Id) = NewBugID
                Next
                LOGDelegate.getInstance.dbDebugMsg(input.GetXml)

                retDR(0) = insert(input, conn)
                retDR(1) = InsertAttFiles(input, NewBugID, conn)

                'retDR("UpdateCnt") = UpdateBugAmount(input, UpdateAmountType.Create, conn)
                '新增附件紀錄
                retDS.Tables(0).Rows.Add(retDR)
                scope.Complete()

            End Using



            Return retDS

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString & " 123 " & input.GetXml, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function
    Private Function InsertAttFiles(ByVal ds As DataSet, Optional ByVal NewBugID As String = "", Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim attDS As New DataSet

            For Each dr As DataRow In ds.Tables(JobQaAttachedFilesDataTableFactory.tableName).Rows
                dr(JobQaAttachedFilesDataTableFactory.DBColumnName.Bug_Id) = NewBugID
                dr(JobQaAttachedFilesDataTableFactory.DBColumnName.File_Name) = NewBugID & "-" &
                                                                                   Syscom.Comm.Utility.StringUtil.appendCharToLeft(dr(JobQaAttachedFilesDataTableFactory.DBColumnName.Sort_Value), CChar("0"), 3) & "." &
                                                                                   dr(JobQaAttachedFilesDataTableFactory.DBColumnName.File_Name).ToString.Split(".")(1)
            Next
            attDS.Tables.Add(ds.Tables(JobQaAttachedFilesDataTableFactory.tableName).Copy)

            Return JobQaAttachedFilesBO_E1.GetInstance.insert(attDS, conn)

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try


    End Function
#End Region

#End Region

#Region "     修改 Method "

    Enum UpdateAmountType
        Create
        Close
    End Enum
#Region " 更新版次的BUG數量 "

    ''' <summary>
    ''' 更新版次的BUG數量
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function UpdateBugAmount(ByVal ds As DataSet, ByVal ActionType As UpdateAmountType, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim IssueLevel As String = ds.Tables(0).Rows(0).Item(0)
            Dim Content As New StringBuilder


            Select Case ds.Tables(0).Rows(0).Item("Issue_Level").ToString.Trim
                Case "1"
                    IssueLevel = "Urgent"
                Case "2"
                    IssueLevel = "Important"
                Case "3"
                    IssueLevel = "Normal"
            End Select
            Content.AppendLine("Update Job_QA_Test_Record ")
            Select Case ActionType
                Case UpdateAmountType.Create
                    Content.AppendLine("   Set Total_Amount=Total_Amount+1,")
                    Content.AppendLine("	   Total_UnClose=Total_UnClose+1,")
                    Content.AppendLine("	   " & IssueLevel & "_UnClose=" & IssueLevel & "_UnClose+1,")
                Case UpdateAmountType.Close
                    Content.AppendLine("   Set Total_Closed=Total_Closed+1,")
                    Content.AppendLine("	   Total_UnClose=Total_UnClose-1,")
                    Content.AppendLine("	   " & IssueLevel & "_UnClose=" & IssueLevel & "_UnClose-1,")
                    Content.AppendLine("	   " & IssueLevel & "_Closed=" & IssueLevel & "_Closed+1,")
            End Select
            Content.AppendLine("	   Modified_User=@Modified_User,")
            Content.AppendLine("       Modified_Time=getdate()")
            Content.AppendLine("Where Version_Id=@Version_Id")
            Content.AppendLine("")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                command.Parameters.AddWithValue("@Version_Id", ds.Tables(0).Rows(0).Item("Version_Id").ToString.Trim)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新版次的BUG數量"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


    ''' <summary>
    ''' 更新版次的複測數量
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-01</remarks>
    Public Function UpdateUnTestAmount(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim IssueLevel As String = ds.Tables(0).Rows(0).Item(0)
            Dim Content As New StringBuilder
            Content.AppendLine("Update Job_QA_Test_Record ")
            Content.AppendLine("   Set Total_UnTest=Total_UnTest-1,")
            Content.AppendLine("	   Modified_User=@Modified_User,")
            Content.AppendLine("       Modified_Time=getdate()")
            Content.AppendLine("Where Version_Id=@Version_Id")
            Content.AppendLine("")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Modified_User", ds.Tables(0).Rows(0).Item("Modified_User").ToString.Trim)
                command.Parameters.AddWithValue("@Version_Id", ds.Tables(0).Rows(0).Item("Version_Id").ToString.Trim)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新複測數量"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region " 儲存複測結果 "

    ''' <summary>
    ''' 儲存複測結果
    ''' </summary>
    ''' <param name="input" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function UpdateBugRecordForRetest(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("Result"))

        retDS.Tables(0).Columns.Add("UpdateBugRecordCnt")
        retDS.Tables(0).Columns.Add("DeleteAttCnt")
        retDS.Tables(0).Columns.Add("InsertAttCnt")
        retDS.Tables(0).Columns.Add("LogCnt")
        retDS.Tables(0).Columns.Add("UpdateTestRecordCnt")

        Dim retDR As DataRow = retDS.Tables(0).NewRow
        Dim LogMsg As String = ""
        Try
            Dim currentTime = Now
            Dim count As Integer = 0


            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                LogMsg = "更新BugRecord "
                Dim BugDS As New DataSet
                Try
                    Dim OldBugDS As DataSet = queryByPK(input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Bug_Id"), input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Version_Id"), conn)
                    BugDS.Tables.Add(input.Tables(JobQaBugRecordDataTableFactory.tableName).Copy)
                    BugDS.Tables(0).Rows(0).Item("JOB_Code") = OldBugDS.Tables(0).Rows(0).Item("JOB_Code")
                    retDR("UpdateBugRecordCnt") = update(BugDS, conn)

                Catch sqlex As SqlException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                    Throw New SQLDatabaseException(sqlex)
                Catch cmex As CommonException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                    Throw cmex
                Catch ex As Exception
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                    Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
                End Try
                LogMsg = ""
                LogMsg = "寫入異動紀錄 "

                Try
                    retDR("LogCnt") = InsertNewBugModifiedLog(input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Bug_Id"), input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Version_Id"), conn)
                Catch sqlex As SqlException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                    Throw New SQLDatabaseException(sqlex)
                Catch cmex As CommonException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                    Throw cmex
                Catch ex As Exception
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                    Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
                End Try
                LogMsg = ""
                LogMsg = "結案回寫Test Record "
                Try

                    If input.Tables(0).Rows(0).Item("Type").ToString.Equals("UpdateBugRecordForRetest") Then
                        retDR("UpdateTestRecordCnt") = 0
                        '結案回寫Test Record
                        Select Case input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Test_Result").ToString.Trim
                            Case "07"
                            'retDR("UpdateTestRecordCnt") += UpdateBugAmount(BugDS, UpdateAmountType.Close, conn)
                            Case "02"
                                Dim RejectDS As DataSet = JobReject(input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Bug_Id"), input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Version_Id"), conn)
                        End Select
                        retDR("UpdateTestRecordCnt") += UpdateUnTestAmount(BugDS, conn)
                    End If
                Catch sqlex As SqlException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                    Throw New SQLDatabaseException(sqlex)
                Catch cmex As CommonException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                    Throw cmex
                Catch ex As Exception
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                    Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
                End Try
                LogMsg = ""
                LogMsg = "砍掉附件資料 "

                Try
                    retDR("DeleteAttCnt") = DeleteAttFiles(input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Bug_Id"), input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Version_Id"), conn)
                    If Syscom.Comm.Utility.CheckMethodUtil.CheckHasValue(input.Tables(JobQaAttachedFilesDataTableFactory.tableName)) Then


                        'Dim AttDS As New DataSet
                        'AttDS.Tables.Add(input.Tables(JobQaAttachedFilesDataTableFactory.tableName).Copy)
                        'retDR("InsertAttCnt") = JobQaAttachedFilesBO_E1.GetInstance.insert(AttDS, conn)
                        retDR("InsertAttCnt") = InsertAttFiles(input, input.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0).Item("Bug_Id"), conn)
                    End If
                    retDS.Tables(0).Rows.Add(retDR)

                Catch sqlex As SqlException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                    Throw New SQLDatabaseException(sqlex)
                Catch cmex As CommonException
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                    Throw cmex
                Catch ex As Exception
                    LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                    Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
                End Try
                LogMsg = ""

                scope.Complete()
            End Using

            Return retDS

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    ''' <summary>
    ''' 寫入Log
    ''' </summary>
    ''' <param name="Bug_Id"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Public Function InsertNewBugModifiedLog(ByVal Bug_Id As String, ByVal Version_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim currentTime = Now
            Dim count As Integer = 0
            Dim LogDS As DataSet = JobQaBugRecordModifiyLogDataTableFactory.getDataSetWithSchema
            Dim LogDR As DataRow = LogDS.Tables(0).NewRow
            LogDR(JobQaBugRecordModifiyLogDataTableFactory.DBColumnName.Log_Id) = Now.ToString("yyyyMMdd") & "-" & StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeA, "BUGLOG", 0, 9999), CChar("0"), 4)

            Dim ds As DataSet = queryByPK(Bug_Id, Version_Id, conn)

            For Each c As DataColumn In ds.Tables(0).Columns
                If LogDS.Tables(0).Columns.Contains(c.ColumnName) Then
                    LogDR(c.ColumnName) = ds.Tables(0).Rows(0).Item(c.ColumnName)
                End If
            Next
            LogDS.Tables(0).Rows.Add(LogDR.ItemArray)

            Return JobQaBugRecordModifiyLogBO.GetInstance.insert(LogDS, conn)

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增Log"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function
    ''' <summary>
    ''' QA退件
    ''' </summary>
    ''' <param name="Bug_Id"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    Private Function JobReject(ByVal Bug_Id As String, ByVal Version_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Dim LogMsg As String = ""
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim BugDS As DataSet
            Dim JobDS As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            LogMsg = "取得BugDS "
            Try
                BugDS = queryByPK(Bug_Id, Version_Id, conn)
            Catch sqlex As SqlException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
            End Try
            LogMsg = ""

            LogMsg = "取得派工紀錄 "
            Try
                JobDS = JobSAAssignRecordBO_E1.GetInstance.queryByPK(BugDS.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim, conn)
                Dim JobDR As DataRow = JobDS.Tables(0).Rows(0)
                JobDR("Reply_Date") = DBNull.Value
                JobDR("Finish_Date") = DBNull.Value
                JobDR("Modified_User") = BugDS.Tables(0).Rows(0).Item("Modified_User").ToString.Trim

                If JobSAAssignRecordBO_E1.GetInstance.update(JobDS, conn) <= 0 Then Throw New Exception
            Catch sqlex As SqlException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
            End Try
            LogMsg = ""

            LogMsg = "更新派工紀錄狀態 "
            Try
                Dim RejectDS As New DataSet
                RejectDS.Tables.Add(New DataTable("Reject"))
                RejectDS.Tables(0).Columns.Add("JOB_Code")
                RejectDS.Tables(0).Columns.Add("Reply_Note")
                RejectDS.Tables(0).Columns.Add("FID")
                RejectDS.Tables(0).Columns.Add("SA_Reply_ATT_FID")
                RejectDS.Tables(0).Columns.Add("Modified_User")
                Dim dr As DataRow = RejectDS.Tables(0).NewRow
                dr("JOB_Code") = BugDS.Tables(0).Rows(0).Item("JOB_Code").ToString.Trim
                dr("Reply_Note") = BugDS.Tables(0).Rows(0).Item("Test_Note").ToString.Trim
                dr("FID") = DBNull.Value
                dr("SA_Reply_ATT_FID") = DBNull.Value
                dr("Modified_User") = BugDS.Tables(0).Rows(0).Item("Modified_User").ToString.Trim
                RejectDS.Tables(0).Rows.Add(dr)
                Return JobSAAssignRecordBO_E1.GetInstance.RejectJobSubmit(RejectDS, "QA", conn)


            Catch sqlex As SqlException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & sqlex.ToString, sqlex)
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & cmex.ToString, cmex)
                Throw cmex
            Catch ex As Exception
                LOGDelegate.getInstance.dbErrorMsg(LogMsg & ex.ToString, ex)
                Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
            End Try
            LogMsg = ""


        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {LogMsg})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
        Return Nothing
    End Function


#End Region

#Region "     關帳"

#Region " 版次關帳 "

    ''' <summary>
    ''' 版次關帳
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-03</remarks>
    Public Function TestVersionClose(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add("Result")
        retDS.Tables(0).Columns.Add("Cnt")
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim cmdStr As New StringBuilder
            cmdStr.AppendLine("Update Job_QA_Test_Record")
            cmdStr.AppendLine("   Set Close_Flag='Y'")
            cmdStr.AppendLine(" Where Version_Id=@Version_Id")
            cmdStr.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Version_Id", row.Item("Version_Id"))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            retDS.Tables(0).Rows.Add(count)
            Return retDS

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"版次關帳"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region "     查詢是否有進行中的派工"

#Region " 查詢是否有進行中的派工 "

    ''' <summary>
    ''' 查詢是否有進行中的派工
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-03</remarks>
    Public Function CheckJobStatusBeforeClose(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim cmdStr As New StringBuilder
            cmdStr.AppendLine("Select * ")
            cmdStr.AppendLine("  From Job_QA_Test_Record JQTR")
            cmdStr.AppendLine("Inner Join Job_QA_Bug_Record JQBR On JQBR.Version_Id=JQTR.Version_Id And JQBR.Test_Result in ('03','04','05','06')")
            cmdStr.AppendLine("Where JQTR.Version_Id=@Version_Id")
            cmdStr.AppendLine("")
            cmdStr.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = cmdStr.ToString

            command.Parameters.AddWithValue("@Version_Id", input.Tables(0).Rows(0).Item("Version_Id"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds


        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢是否有進行中的派工"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region


#End Region

#End Region

#Region "     刪除 Method "
#Region " 刪除附件 "

    ''' <summary>
    ''' 刪除附件
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function DeleteAttFiles(ByVal BugId As String, ByVal Version_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From Job_QA_Attached_Files Where Bug_Id=@Bug_Id And Version_Id=@Version_Id"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Bug_Id", BugId)
                command.Parameters.AddWithValue("@Version_Id", Version_Id)

                count = command.ExecuteNonQuery
            End Using

            Return count

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     查詢 Method "

#Region " 查看BUG明細 "

    ''' <summary>
    ''' 查看BUG明細
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function QueryBugDetailForModifiy(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("Select * ")
            Content.AppendLine("  From Job_QA_Test_Record JQTR")
            Content.AppendLine(" Inner Join Job_QA_Bug_Record JQR On JQR.Version_Id=JQTR.Version_Id")
            Content.AppendLine(" Left Join Job_QA_Attached_Files JQAF On JQAF.Bug_Id=JQR.Bug_Id")
            Content.AppendLine(" Where JQTR.Version_Id=@Version_Id")
            Content.AppendLine("   And JQR.Bug_Id=@Bug_Id")

            Content.AppendLine(";")
            Content.AppendLine("Select * ")
            Content.AppendLine("  From Job_QA_Attached_Files")
            Content.AppendLine(" Where Bug_Id=@Bug_Id")
            Content.AppendLine("   And Version_Id=@Version_Id")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Bug_Id", input.Tables(0).Rows(0).Item("Bug_Id"))
            command.Parameters.AddWithValue("@Version_Id", input.Tables(0).Rows(0).Item("Version_Id"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"查看BUG明細"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#Region " 初始化註記相關GRID "

    ''' <summary>
    ''' 初始化註記相關GRID
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function InitialJobNoteGrid(ByVal input As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("  Select RTRIM(PE.Employee_Name) As SA_Name")
            Content.AppendLine("		,RTRIM(JSAR.Issue_Desc)  As Remark")
            Content.AppendLine("        ,Convert(Char,JSAR.Create_Time,120) Remark_Date")
            Content.AppendLine("        ,RTRIM(Bug_Id) As Bug_Id")
            Content.AppendLine("        ,RTRIM(JSAR.Create_User) as SA_Employee_Code")
            Content.AppendLine("    From Job_QA_Bug_Record JQBR")
            Content.AppendLine("Inner Join JOB_SA_Assign_Record JSAR On JSAR.JOB_Code=JQBR.JOB_Code")
            Content.AppendLine("Inner Join Pub_Employee PE On PE.Employee_Code=JSAR.Create_User And PE.Nrs_Level_Id='2'")
            Content.AppendLine("   Where Bug_Id=@Bug_Id")
            Content.AppendLine("     And Version_Id=@Version_Id")
            Content.AppendLine(";")
            Content.AppendLine("  Select RTRIM(PE.Employee_Name) As SD_Name")
            Content.AppendLine("		,RTRIM(JSAR.SD_Note) As Remark")
            Content.AppendLine("        ,Convert(Char,JSAR.SD_Confirm_Date,120) Remark_Date")
            Content.AppendLine("        ,RTRIM(Bug_Id) AS Bug_Id")
            Content.AppendLine("        ,RTRIM(SD_Employee_Code) AS SD_Employee_Code")
            Content.AppendLine("    From Job_QA_Bug_Record JQBR")
            Content.AppendLine("Inner Join JOB_SA_Assign_Record JSAR On JSAR.JOB_Code=JQBR.JOB_Code")
            Content.AppendLine("Inner Join Pub_Employee PE On PE.Employee_Code=JSAR.SD_Employee_Code And PE.Nrs_Level_Id='3'")
            Content.AppendLine("   Where Bug_Id=@Bug_Id")
            Content.AppendLine("     And Version_Id=@Version_Id")
            Content.AppendLine(";")
            Content.AppendLine("  Select Top 1 RTRIM(PE.Employee_Name) As PG_Name")
            Content.AppendLine("		,RTRIM(JPJR.Issue_Desc) As Remark")
            Content.AppendLine("        ,Convert(Char,JPJR.Create_Time,120) Remark_Date")
            Content.AppendLine("        ,RTRIM(Bug_Id) As Bug_Id")
            Content.AppendLine("        ,RTRIM(JPJR.Create_User) as PG_Employee_Code")
            Content.AppendLine("    From Job_QA_Bug_Record JQBR")
            Content.AppendLine("Inner Join JOB_PG_JOB_Record JPJR On JPJR.JOB_Code=JQBR.JOB_Code")
            Content.AppendLine("Inner Join Pub_Employee PE On PE.Employee_Code=JPJR.Create_User  ")
            Content.AppendLine("   Where Bug_Id=@Bug_Id")
            Content.AppendLine("     And Version_Id=@Version_Id")
            Content.AppendLine("   Order By JPJR.Create_Time Desc")
            Content.AppendLine(";")
            Content.AppendLine("  Select * ")
            Content.AppendLine("    From Job_QA_Bug_Record JQBR")
            Content.AppendLine("   Where Bug_Id=@Bug_Id")
            Content.AppendLine("     And Version_Id=@Version_Id")
            Content.AppendLine("   Order By JQBR.Create_Time Desc")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Bug_Id", input.Tables(0).Rows(0).Item("Bug_Id"))
            command.Parameters.AddWithValue("@Version_Id", input.Tables(0).Rows(0).Item("Version_Id"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using

            ds.Tables(0).TableName = "SA"
            ds.Tables(1).TableName = "SD"
            ds.Tables(2).TableName = "PG"
            ds.Tables(3).TableName = "Job_QA_Bug_Record"

            Return ds

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#End Region

#Region " GetMaxSeqNo "
#Region " GetMaxSeqNo "

    ''' <summary>
    ''' GetMaxSeqNo
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Function GetMaxSeqNo(ByVal Version_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("  Select Count(1) + 1  ")
            Content.AppendLine("    From Job_QA_Bug_Record JQBR")
            Content.AppendLine("   Where 1=1")
            Content.AppendLine("     And Version_Id=@Version_Id")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@Version_Id", Version_Id)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using

            Return ds.Tables(0).Rows(0).Item(0).ToString

        Catch sqlex As SqlException
            LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            LOGDelegate.getInstance.dbErrorMsg(cmex.ToString, cmex)
            Throw cmex
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#End Region

#End Region

End Class

