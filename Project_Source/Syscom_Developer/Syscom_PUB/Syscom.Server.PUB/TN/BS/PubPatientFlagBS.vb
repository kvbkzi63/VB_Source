'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患註記維護
'*              Title:	PubPatientFlag
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan.Tsai
'*        Create Date:	2015-08-02
'*      Last Modifier:	Alan.Tsai
'*   Last Modify Date:	2015-08-02
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL

Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports System.Text


Public Class PubPatientFlagBS

    Public Shared ReadOnly tableName As String = "PUB_Patient_Flag"

#Region "########## getInstance ##########"

    Private Shared myInstance As PubPatientFlagBS

    Public Overloads Function getInstance() As PubPatientFlagBS
        If myInstance Is Nothing Then
            myInstance = New PubPatientFlagBS()
        End If
        Return myInstance
    End Function

    Public Sub New()
    End Sub

#End Region

#Region "     新增 "

    ''' <summary>
    ''' 資料新增
    ''' </summary>
    ''' <param name="inSource_Type">來源別(O：門診、E：急診、I：住院、空白：僅寫入PUB_Patient_Flag)</param>
    ''' <param name="inChart_No">病歷號</param>
    ''' <param name="inMedical_Sn">就醫號</param>
    ''' <param name="inFlag_Id">特殊註記代碼(需驗證是否存在PUB_SysCode.Type_Id='30')</param>
    ''' <param name="inCreate_Uer">建立人員</param>
    ''' <param name="inIs_SyncToPUB">是否同步至PUB_Patient_Flag</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function insertPatientFlag(ByVal inSource_Type As String, ByVal inChart_No As String, _
                                      ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                                      ByVal inCreate_Uer As String, ByVal inIs_SyncToPUB As String) As DataSet

        Dim resultDs As New DataSet               '回傳DataSet
        Dim pvtSystemTime As String = ""          '系統時間
        Dim pvtSysDate As String = ""             '系統日期

        Dim scope As TransactionScope = Nothing

        Try
            '-------------------------------------------------------
            'For Debug
            '-------------------------------------------------------
            'inSource_Type = "O"
            'inChart_No = "99999999"
            'inMedical_Sn = "99999999"
            'inFlag_Id = "101"
            'inCreate_Uer = "alan"
            'inIs_SyncToPUB = "Y"

            'inSource_Type = "E"
            'inChart_No = "88888888"
            'inMedical_Sn = "88888888"
            'inFlag_Id = "102"
            'inCreate_Uer = "alan"
            'inIs_SyncToPUB = "Y"

            'inSource_Type = "I"
            'inChart_No = "77777777"
            'inMedical_Sn = "77777777"
            'inFlag_Id = "103"
            'inCreate_Uer = "alan"
            'inIs_SyncToPUB = "Y"

            'inSource_Type = " "
            'inChart_No = "66666666"
            'inMedical_Sn = "66666666"
            'inFlag_Id = "104"
            'inCreate_Uer = "alan"
            'inIs_SyncToPUB = "N"

            '-------------------------------------------------------

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")
            pvtSysDate = Now.ToString("yyyy/MM/dd")

            resultDs.Tables.Add("Save_Result")
            resultDs.Tables("Save_Result").Columns.Add("Exe_Status")
            resultDs.Tables("Save_Result").Columns.Add("Exe_Message")

            scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Using conn As System.Data.IDbConnection = CType(getConnectionBySourceType(inSource_Type), SqlConnection)

                conn.Open()

                '-------------------------------------------------------------
                '1.查詢病患註記是否存在PUB_SysCode(Type_Id='30')設定檔
                '-------------------------------------------------------------
                Dim pvtSysCodeDs As New DataSet
                pvtSysCodeDs = queryPUBSysCodeByPKey(inFlag_Id, conn)

                If pvtSysCodeDs IsNot Nothing AndAlso pvtSysCodeDs.Tables IsNot Nothing AndAlso pvtSysCodeDs.Tables(0).Rows.Count > 0 Then
                    '-------------------------------------------------------------
                    '2.依來源別新增至對應的表格
                    '-------------------------------------------------------------
                    Try
                        '2-1. 新增至對應表格
                        insertPatientFlagByTable(inSource_Type, inMedical_Sn, inFlag_Id, inChart_No, pvtSysDate, inCreate_Uer, pvtSystemTime, inCreate_Uer, pvtSystemTime, conn)

                        '2-2.新增成功，才寫入BK檔
                        insertBackup(inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, pvtSysDate, inCreate_Uer, pvtSystemTime, inCreate_Uer, pvtSystemTime)

                        '2-3.若同步註記(inIs_SyncToPUB)='Y'，則寫入PUB_Patient_Flag
                        If inIs_SyncToPUB = "Y" Then
                            Dim pvtPTFlagDs As New DataSet
                            pvtPTFlagDs = queryPUBPatientFlagByPKey(inChart_No, inFlag_Id)

                            If pvtPTFlagDs IsNot Nothing AndAlso pvtPTFlagDs.Tables IsNot Nothing AndAlso pvtPTFlagDs.Tables(0).Rows.Count > 0 Then
                                '若該代碼已存在PUB_Patient_Flag，則不再做任何處理
                            Else
                                '2-3-1. 新增至PUB_Patient_Flag
                                insertPatientFlagByTable(" ", inMedical_Sn, inFlag_Id, inChart_No, pvtSysDate, inCreate_Uer, pvtSystemTime, inCreate_Uer, pvtSystemTime, conn)

                                '2-3-2. 新增成功，才寫入BK檔
                                insertBackup(" ", inChart_No, inMedical_Sn, inFlag_Id, pvtSysDate, inCreate_Uer, pvtSystemTime, inCreate_Uer, pvtSystemTime)

                            End If
                        End If

                    Catch sql_ex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                        resultDs.Tables(0).Rows(0).Item("Exe_Message") = sql_ex.ToString
                        Return resultDs
                        '-------------------------------------------------------------

                    Catch ex As Exception
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                        resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString
                        Return resultDs
                        '-------------------------------------------------------------
                    End Try

                Else
                    resultDs.Tables(0).Rows.Add()
                    resultDs.Tables(0).NewRow()
                    resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                    resultDs.Tables(0).Rows(0).Item("Exe_Message") = "該病患註記不存在!"
                    Return resultDs

                End If

                '-------------------------------------------------------------
                '2.完成交易處理
                '-------------------------------------------------------------
                scope.Complete()
                '-------------------------------------------------------------

            End Using


        Catch cmex As CommonException
            resultDs.Tables(0).Rows.Add()
            resultDs.Tables(0).NewRow()
            resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
            resultDs.Tables(0).Rows(0).Item("Exe_Message") = cmex.ToString
            Return resultDs

        Catch ex As Exception
            resultDs.Tables(0).Rows.Add()
            resultDs.Tables(0).NewRow()
            resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
            resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString
            Return resultDs

        Finally
            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                resultDs.Tables(0).Rows.Add()
                resultDs.Tables(0).NewRow()
                resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString
            End Try

        End Try

        If resultDs.Tables(0).Rows.Count = 0 Then
            resultDs.Tables(0).Rows.Add()
            resultDs.Tables(0).NewRow()
            resultDs.Tables(0).Rows(0).Item("Exe_Status") = "Y"
            resultDs.Tables(0).Rows(0).Item("Exe_Message") = ""
        End If

        Return resultDs

    End Function

#End Region

#Region "     刪除 "
    ''' <summary>
    ''' 資料刪除 
    ''' </summary>
    ''' <param name="inSource_Type">來源別(O：門診、E：急診、I：住院、空白：僅刪除PUB_Patient_Flag)</param>
    ''' <param name="inChart_No">病歷號</param>
    ''' <param name="inMedical_Sn">就醫號</param>
    ''' <param name="inFlag_Id">特殊註記代碼(需驗證是否存在PUB_SysCode.Type_Id='30')</param>
    ''' <param name="inCancel_Uer">刪除人員</param>
    ''' <param name="inIs_SyncToPUB">是否同步刪除PUB_Patient_Flag</param>
    ''' <returns>DataSet</returns>    
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function deletePatientFlag(ByVal inSource_Type As String, ByVal inChart_No As String, _
                                      ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                                      ByVal inCancel_Uer As String, ByVal inIs_SyncToPUB As String) As DataSet

        Dim resultDs As New DataSet          '回傳DataSet
        Dim pvtSystemTime As String          '系統時間

        Dim scope As TransactionScope = Nothing

        Try

            pvtSystemTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

            resultDs.Tables.Add("Save_Result")
            resultDs.Tables("Save_Result").Columns.Add("Exe_Status")
            resultDs.Tables("Save_Result").Columns.Add("Exe_Message")

            scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

            Using conn As System.Data.IDbConnection = CType(getConnectionBySourceType(inSource_Type), SqlConnection)

                conn.Open()

                '-------------------------------------------------------------
                '1.查詢病患註記是否存在PUB_SysCode(Type_Id='30')設定檔
                '-------------------------------------------------------------
                Dim pvtSysCodeDs As New DataSet
                pvtSysCodeDs = queryPUBSysCodeByPKey(inFlag_Id, conn)

                If pvtSysCodeDs IsNot Nothing AndAlso pvtSysCodeDs.Tables IsNot Nothing AndAlso pvtSysCodeDs.Tables(0).Rows.Count > 0 Then
                    '-------------------------------------------------------------
                    '2.依來源別刪除對應的表格
                    '-------------------------------------------------------------
                    Try
                        '2-1. 查詢欲刪除資料的建立者是否為同一人
                        Dim pvtDelDs As New DataSet
                        pvtDelDs = queryPatientFlagByCancelUser(inSource_Type, inMedical_Sn, inChart_No, inFlag_Id, conn)

                        '若為同一人才允許刪除該筆資料
                        'If pvtDelDs IsNot Nothing AndAlso pvtDelDs.Tables IsNot Nothing AndAlso pvtDelDs.Tables(0).Rows.Count > 0 andalso _
                        '   pvtDelDs.Tables(0).Rows(0).Item("Create_User").ToString.Trim = inCancel_Uer Then
                        deletePatientFlagByTable(inSource_Type, inMedical_Sn, inChart_No, inFlag_Id, conn)
                        'Else
                        '    '非本人則回傳錯誤訊息
                        '    resultDs.Tables(0).Rows.Add()
                        '    resultDs.Tables(0).NewRow()
                        '    resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                        '    resultDs.Tables(0).Rows(0).Item("Exe_Message") = "非本人新增資料，不可刪除!"
                        'End If

                        '2-2.新增成功，才寫入BK檔
                        If inSource_Type <> " " Then
                            deleteBackup(inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, "", _
                                         pvtDelDs.Tables(0).Rows(0).Item("Create_User").ToString.Trim, _
                                         pvtDelDs.Tables(0).Rows(0).Item("Create_Time").ToString.Trim, _
                                         inCancel_Uer, pvtSystemTime)
                        Else
                            deleteBackup(inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, _
                                         pvtDelDs.Tables(0).Rows(0).Item("Record_Date").ToString("yyyy/MM/dd"), _
                                         pvtDelDs.Tables(0).Rows(0).Item("Create_User").ToString.Trim, _
                                         pvtDelDs.Tables(0).Rows(0).Item("Create_Time").ToString.Trim, _
                                         inCancel_Uer, pvtSystemTime)

                        End If


                        '2-3.若同步註記(inIs_SyncToPUB)='Y'，則刪除PUB_Patient_Flag
                        If inIs_SyncToPUB = "Y" Then
                            Dim pvtPTFlagDs As New DataSet
                            pvtPTFlagDs = queryPatientFlagByCancelUser(" ", inMedical_Sn, inChart_No, inFlag_Id, conn)

                            If pvtPTFlagDs IsNot Nothing AndAlso pvtPTFlagDs.Tables IsNot Nothing AndAlso pvtPTFlagDs.Tables(0).Rows.Count > 0 Then
                                '2-3-1. 刪除PUB_Patient_Flag
                                deletePatientFlagByTable(" ", inMedical_Sn, inChart_No, inFlag_Id, conn)

                                '2-3-2. 刪除成功，才寫入BK檔
                                deleteBackup(" ", inChart_No, inMedical_Sn, inFlag_Id, _
                                             pvtPTFlagDs.Tables(0).Rows(0).Item("Record_Date").ToString("yyyy/MM/dd"), _
                                             pvtPTFlagDs.Tables(0).Rows(0).Item("Create_User").ToString.Trim, _
                                             pvtPTFlagDs.Tables(0).Rows(0).Item("Create_Time").ToString.Trim, _
                                             inCancel_Uer, pvtSystemTime)

                            End If
                        End If

                    Catch sql_ex As SqlException
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                        resultDs.Tables(0).Rows(0).Item("Exe_Message") = sql_ex.ToString
                        '-------------------------------------------------------------

                    Catch ex As Exception
                        '-------------------------------------------------------------
                        '將ErrMsg寫入回傳DataSet
                        '-------------------------------------------------------------
                        resultDs.Tables(0).Rows.Add()
                        resultDs.Tables(0).NewRow()
                        resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                        resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString
                        '-------------------------------------------------------------
                    End Try

                Else
                    resultDs.Tables(0).Rows.Add()
                    resultDs.Tables(0).NewRow()
                    resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                    resultDs.Tables(0).Rows(0).Item("Exe_Message") = "該病患註記不存在!"

                End If

                '-------------------------------------------------------------
                '2.完成交易處理
                '-------------------------------------------------------------
                scope.Complete()
                '-------------------------------------------------------------

            End Using


        Catch cmex As CommonException
            resultDs.Tables(0).Rows.Add()
            resultDs.Tables(0).NewRow()
            resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
            resultDs.Tables(0).Rows(0).Item("Exe_Message") = cmex.ToString

        Catch ex As Exception
            resultDs.Tables(0).Rows.Add()
            resultDs.Tables(0).NewRow()
            resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
            resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString

        Finally
            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                resultDs.Tables(0).Rows.Add()
                resultDs.Tables(0).NewRow()
                resultDs.Tables(0).Rows(0).Item("Exe_Status") = "N"
                resultDs.Tables(0).Rows(0).Item("Exe_Message") = ex.ToString
            End Try
        End Try

        resultDs.Tables(0).Rows.Add()
        resultDs.Tables(0).NewRow()
        resultDs.Tables(0).Rows(0).Item("Exe_Status") = "Y"
        resultDs.Tables(0).Rows(0).Item("Exe_Message") = ""
        Return resultDs

    End Function

#End Region

#Region "     查詢 "

    ''' <summary>
    '''查詢傳入病患註記是否存在PUB_SysCode(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function queryPUBSysCodeByPKey(ByVal inCode_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("Select  * ")
            content.AppendLine("From PUB_SysCode   ")
            content.AppendLine("Where Type_Id='30' and Code_Id=@inCode_Id ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@inCode_Id", inCode_Id)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_SysCode")
                adapter.Fill(ds, "PUB_SysCode")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''查詢傳入病患註記是否存在PUB_Patient_Flag
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function queryPUBPatientFlagByPKey(ByVal inChart_No As String, ByVal inFlag_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("Select  * ")
            content.AppendLine("From PUB_Patient_Flag   ")
            content.AppendLine("Where Chart_No=@inChart_No and Flag_Id=@inFlag_Id ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@inChart_No", inChart_No)
            command.Parameters.AddWithValue("@inFlag_Id", inFlag_Id)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, "PUB_Patient_Flag")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''查詢要刪除資料的建立者是否為本人
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function queryPatientFlagByCancelUser(ByVal inSource_Type As String, ByVal inMedical_Sn As String, _
                                                 ByVal inChart_No As String, ByVal inFlag_Id As String, _
                                                 Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            Select Case inSource_Type
                Case "O"
                    content.AppendLine("Select  * ")
                    content.AppendLine("From OMO_Patient_Flag ")
                    content.AppendLine("Where Outpatient_Sn=@Medical_Sn and Flag_Id=@Flag_Id ")

                Case "E"
                    content.AppendLine("Select  * ")
                    content.AppendLine("From EMO_Patient_Flag ")
                    content.AppendLine("Where Outpatient_Sn=@Medical_Sn and Flag_Id=@Flag_Id ")

                Case "I"
                    content.AppendLine("Select  * ")
                    content.AppendLine("From INP_Patient_Flag ")
                    content.AppendLine("Where Case_No=@Medical_Sn and Flag_Id=@Flag_Id ")

                Case " "
                    content.AppendLine("Select  * ")
                    content.AppendLine("From PUB_Patient_Flag ")
                    content.AppendLine("Where Chart_No=@Chart_No and Flag_Id=@Flag_Id ")

            End Select

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Medical_Sn", inMedical_Sn)
            command.Parameters.AddWithValue("@Chart_No", inChart_No)
            command.Parameters.AddWithValue("@inFlag_Id", inFlag_Id)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Patient_Flag")
                adapter.Fill(ds, "Patient_Flag")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


#End Region

#Region "     新增 Method "
    ''' <summary>
    '''新增至對應表格
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function insertPatientFlagByTable(ByVal inSource_Type As String,
                                             ByVal inMedical_Sn As String,
                                             ByVal inFlag_Id As String,
                                             ByVal inChart_No As String,
                                             ByVal inRecord_Date As String,
                                             ByVal inCreate_User As String,
                                             ByVal inCreate_Time As String,
                                             ByVal inModified_User As String,
                                             ByVal inModified_Time As String,
                                             Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0

            Dim sqlString As String = ""

            Select Case inSource_Type
                Case "O"
                    sqlString = "insert into OMO_Patient_Flag " & _
                                "(Outpatient_Sn , Flag_Id , Chart_No , Create_User , Create_Time ) " & _
                                " Values" & _
                                "(@Medical_Sn , @Flag_Id , @Chart_No , @Create_User , @Create_Time )"

                Case "E"
                    sqlString = "insert into EMO_Patient_Flag " & _
                                "(Outpatient_Sn , Flag_Id , Chart_No , Create_User , Create_Time ) " & _
                                " Values" & _
                                "(@Medical_Sn , @Flag_Id , @Chart_No , @Create_User , @Create_Time )"

                Case "I"
                    sqlString = "insert into INP_Patient_Flag " & _
                                "(Case_No , Flag_Id , Chart_No , Create_User , Create_Time ) " & _
                                " Values" & _
                                "(@Medical_Sn , @Flag_Id , @Chart_No , @Create_User , @Create_Time )"

                Case " "
                    sqlString = "insert into PUB_Patient_Flag " & _
                                "(Chart_No , Flag_Id , Record_Date , Create_User , Create_Time , Modified_User , Modified_Time ) " & _
                                " Values" & _
                                "(@Chart_No , @Flag_Id , @Record_Date , @Create_User , @Create_Time , @Modified_User , @Modified_Time )"


            End Select


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
                command.Parameters.AddWithValue("@Medical_Sn", inMedical_Sn)
                command.Parameters.AddWithValue("@Flag_Id", inFlag_Id)
                command.Parameters.AddWithValue("@Chart_No", inChart_No)
                command.Parameters.AddWithValue("@Record_Date", inRecord_Date)
                command.Parameters.AddWithValue("@Create_User", inCreate_User)
                command.Parameters.AddWithValue("@Create_Time", inCreate_Time)
                command.Parameters.AddWithValue("@Modified_User", inModified_User)
                command.Parameters.AddWithValue("@Modified_Time", inModified_Time)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "     刪除 Method "
    ''' <summary>
    '''刪除對應表格
    ''' </summary>
    ''' <returns>刪除筆數</returns>
    ''' <remarks>by Alan Tsai on 2015-08-02</remarks>
    Public Function deletePatientFlagByTable(ByVal inSource_Type As String,
                                             ByVal inMedical_Sn As String,
                                             ByVal inChart_No As String,
                                             ByVal inFlag_Id As String,
                                             Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0

            Dim sqlString As String = ""

            Select Case inSource_Type
                Case "O"
                    sqlString = "Delete OMO_Patient_Flag " & _
                                "Where Outpatient_Sn=@Medical_Sn and Flag_Id=@Flag_Id "

                Case "E"
                    sqlString = "Delete EMO_Patient_Flag " & _
                                "Where Outpatient_Sn=@Medical_Sn and Flag_Id=@Flag_Id "

                Case "I"
                    sqlString = "Delete INP_Patient_Flag " & _
                                "Where Case_No=@Medical_Sn and Flag_Id=@Flag_Id "

                Case " "
                    sqlString = "Delete PUB_Patient_Flag " & _
                                "Where Chart_No=@Chart_No and Flag_Id=@Flag_Id "


            End Select


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
                command.Parameters.AddWithValue("@Medical_Sn", inMedical_Sn)
                command.Parameters.AddWithValue("@Flag_Id", inFlag_Id)
                command.Parameters.AddWithValue("@Chart_No", inChart_No)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
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
    Public Shared Function getDataTableBKWithSchema(ByVal inSource_Type As String) As DataTable
        Try
            Dim dt As New DataTable

            Select Case inSource_Type
                Case "O"
                    dt = New DataTable("OMO_Patient_Flag_BK")
                    dt.Columns.Add("Action")
                    dt.Columns("Action").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Backup_Time")
                    dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
                    dt.Columns.Add("Outpatient_Sn")
                    dt.Columns("Outpatient_Sn").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Flag_Id")
                    dt.Columns("Flag_Id").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Chart_No")
                    dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_User")
                    dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_Time")
                    dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")

                    Dim pkColArray(3) As DataColumn
                    pkColArray(0) = dt.Columns("Action")
                    pkColArray(1) = dt.Columns("Backup_Time")
                    pkColArray(2) = dt.Columns("Outpatient_Sn")
                    pkColArray(3) = dt.Columns("Flag_Id")
                    dt.PrimaryKey = pkColArray

                Case "E"
                    dt = New DataTable("EMO_Patient_Flag_BK")
                    dt.Columns.Add("Action")
                    dt.Columns("Action").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Backup_Time")
                    dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
                    dt.Columns.Add("Outpatient_Sn")
                    dt.Columns("Outpatient_Sn").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Flag_Id")
                    dt.Columns("Flag_Id").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Chart_No")
                    dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_User")
                    dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_Time")
                    dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")

                    Dim pkColArray(3) As DataColumn
                    pkColArray(0) = dt.Columns("Action")
                    pkColArray(1) = dt.Columns("Backup_Time")
                    pkColArray(2) = dt.Columns("Outpatient_Sn")
                    pkColArray(3) = dt.Columns("Flag_Id")
                    dt.PrimaryKey = pkColArray

                Case "I"
                    dt = New DataTable("INP_Patient_Flag_BK")
                    dt.Columns.Add("Action")
                    dt.Columns("Action").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Backup_Time")
                    dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
                    dt.Columns.Add("Case_No")
                    dt.Columns("Case_No").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Flag_Id")
                    dt.Columns("Flag_Id").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Chart_No")
                    dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_User")
                    dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_Time")
                    dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")

                    Dim pkColArray(3) As DataColumn
                    pkColArray(0) = dt.Columns("Action")
                    pkColArray(1) = dt.Columns("Backup_Time")
                    pkColArray(2) = dt.Columns("Case_No")
                    pkColArray(3) = dt.Columns("Flag_Id")
                    dt.PrimaryKey = pkColArray

                Case " "
                    dt = New DataTable("PUB_Patient_Flag_BK")
                    dt.Columns.Add("Action")
                    dt.Columns("Action").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Backup_Time")
                    dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
                    dt.Columns.Add("Chart_No")
                    dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Flag_Id")
                    dt.Columns("Flag_Id").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Flag_Memo")
                    dt.Columns("Flag_Memo").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Record_Date")
                    dt.Columns("Record_Date").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_User")
                    dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Create_Time")
                    dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
                    dt.Columns.Add("Modified_User")
                    dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
                    dt.Columns.Add("Modified_Time")
                    dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")

                    Dim pkColArray(3) As DataColumn
                    pkColArray(0) = dt.Columns("Action")
                    pkColArray(1) = dt.Columns("Backup_Time")
                    pkColArray(2) = dt.Columns("Chart_No")
                    pkColArray(3) = dt.Columns("Flag_Id")
                    dt.PrimaryKey = pkColArray

            End Select

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub insertBackup(ByVal inSource_Type As String, ByVal inChart_No As String, _
                               ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                               ByVal inRecord_Date As String, _
                               ByVal inCreate_User As String, ByVal inCreate_Time As String, _
                               ByVal inModified_User As String, ByVal inModified_Time As String)
        dataBackup("Insert", inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, inRecord_Date, inCreate_User, inCreate_Time, inModified_User, inModified_Time)
    End Sub

    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="inSource_Type"></param>
    ''' <remarks></remarks>
    Protected Sub deleteBackup(ByVal inSource_Type As String, ByVal inChart_No As String, _
                               ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                               ByVal inRecord_Date As String, _
                               ByVal inCreate_User As String, ByVal inCreate_Time As String, _
                               ByVal inModified_User As String, ByVal inModified_Time As String)
        dataBackup("Delete", inSource_Type, inChart_No, inMedical_Sn, inFlag_Id, inRecord_Date, inCreate_User, inCreate_Time, inModified_User, inModified_Time)
    End Sub


    ''' <summary>
    ''' 備份主程式
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Protected Sub dataBackup(ByRef action As String,
                             ByVal inSource_Type As String, ByVal inChart_No As String, _
                             ByVal inMedical_Sn As String, ByVal inFlag_Id As String, _
                             ByVal inRecord_Date As String, _
                             ByVal inCreate_Uer As String, ByVal inCreate_Time As String, _
                             ByVal inModified_User As String, ByVal inModified_Time As String)
        Dim bkDS = New DataSet
        Dim bkTable = getDataTableBKWithSchema(inSource_Type)
        Dim bkRow = bkTable.NewRow()
        bkRow("Action") = action
        bkRow("Backup_Time") = CDate(inCreate_Time)

        Select Case inSource_Type
            Case "O"
                bkRow("Outpatient_Sn") = inMedical_Sn
                bkRow("Flag_Id") = inFlag_Id
                bkRow("Chart_No") = inChart_No
                bkRow("Create_User") = inCreate_Uer
                bkRow("Create_Time") = inCreate_Time

            Case "E"
                bkRow("Outpatient_Sn") = inMedical_Sn
                bkRow("Flag_Id") = inFlag_Id
                bkRow("Chart_No") = inChart_No
                bkRow("Create_User") = inCreate_Uer
                bkRow("Create_Time") = inCreate_Time

            Case "I"
                bkRow("Case_No") = inMedical_Sn
                bkRow("Flag_Id") = inFlag_Id
                bkRow("Chart_No") = inChart_No
                bkRow("Create_User") = inCreate_Uer
                bkRow("Create_Time") = inCreate_Time

            Case " "
                bkRow("Chart_No") = inChart_No
                bkRow("Flag_Id") = inFlag_Id
                bkRow("Flag_Memo") = ""

                If inRecord_Date <> "" Then
                    bkRow("Record_Date") = inRecord_Date
                Else
                    bkRow("Record_Date") = DBNull.Value
                End If

                bkRow("Create_User") = inCreate_Uer
                bkRow("Create_Time") = inCreate_Time
                bkRow("Modified_User") = inModified_User
                bkRow("Modified_Time") = inModified_Time

        End Select

        bkTable.Rows.Add(bkRow)
        bkDS.Tables.Add(bkTable)
        MessageQueueUtil.getInstance.sendBackupTableMessage(bkDS)
    End Sub

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Alan.Tsai on 2015-08-02</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

    Public Function getConnectionBySourceType(ByVal inSourceType As String) As IDbConnection

        Select Case inSourceType
            Case "O"
                Return SQLConnFactory.getInstance.getOpdDBSqlConn

            Case "E"
                Return SQLConnFactory.getInstance.getEisDBSqlConn

            Case "I"
                Return SQLConnFactory.getInstance.getPcsDBSqlConn

        End Select

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

