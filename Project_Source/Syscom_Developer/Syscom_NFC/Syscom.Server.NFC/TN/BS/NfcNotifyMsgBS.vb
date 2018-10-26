Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.SNC

Public Class NfcNotifyMsgBS

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As NfcNotifyMsgBS
        Get
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New NfcNotifyMsgBS()
    End Class

#End Region

#Region "     公佈欄新增資料(發送) NFC_Notify_Msg "
    ''' <summary>
    ''' 取得訊息群組ID NFC_Notify_Msg
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNFCSerialNo() As String
        Return StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeC, "NFC", 1, -1), "0".Chars(0), 10)
    End Function
 
    ''' <summary>
    ''' 根據傳入的 NFC_Notify_Msg資料包 新增到 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="data" >NFC_Notify_Msg資料包</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertNFCNotifyMsg(ByVal data As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim NfcType As String = ""
        Dim sendDate As String = ""
        Dim StartTime As String = ""
        Dim EndTime As String = ""
        Dim Status As String = ""
        Dim Subject As String = ""
        Dim MsgBody As String = ""
        Dim ReplyMsg As String = ""
        Dim ExternalFuction As String = ""
        Dim Recipient As String = ""
        Dim CreateUser As String = ""
        Dim CreateTime As String = ""
        Dim ModifiedUser As String = ""
        Dim ModifiedTime As String = ""
        Dim AppSystemNo As String = ""
        Dim SubSystemNo As String = ""
        Dim TskTaskNo As String = ""
        Dim FunFunctionNo As String = ""
        Dim Level As String = ""
        Dim GroupType As String = ""
        Dim GroupId As String = ""
        Dim GrouptxId As String = ""
        Dim specFlag As String = ""
        Dim callIP As String = ""
        Dim CurrentDateTime As Date = Now
        Dim EmployeeCode As String = ""
        Try

            'Dim groupID As String = Now.ToString("yyyyMMddHHmmssfff")
            Dim newDataDS As New DataSet
            newDataDS.Tables.Add(NfcNotifyMsgDataTableFactory.getDataTable.Clone)
            'Dim newTable As DataTable = New DataTable("NFC_Notify_Msg")
            'newDataDS.Tables.Add(newTable)

            For i As Integer = 0 To data.Tables(0).Rows.Count - 1
                sendDate = data.Tables(0).Rows(i).Item("sendDate").ToString
                StartTime = data.Tables(0).Rows(i).Item("Start_Time").ToString
                EndTime = data.Tables(0).Rows(i).Item("End_Time").ToString
                Subject = data.Tables(0).Rows(i).Item("Subject").ToString
                MsgBody = data.Tables(0).Rows(i).Item("MsgBody").ToString
                CreateUser = data.Tables(0).Rows(i).Item("Create_User").ToString
                ModifiedUser = data.Tables(0).Rows(i).Item("Modified_User").ToString
                AppSystemNo = data.Tables(0).Rows(i).Item("App_System_No").ToString
                SubSystemNo = data.Tables(0).Rows(i).Item("Sub_System_No").ToString
                TskTaskNo = data.Tables(0).Rows(i).Item("Tsk_Task_No").ToString
                FunFunctionNo = data.Tables(0).Rows(i).Item("Fun_Function_No").ToString
                Level = data.Tables(0).Rows(i).Item("Level").ToString
                specFlag = data.Tables(0).Rows(i).Item("spec_Flag").ToString
                ReplyMsg = ""
                ExternalFuction = data.Tables(0).Rows(i).Item("ExternalFuction").ToString
                GroupType = data.Tables(0).Rows(i).Item("Group_Type").ToString
                GroupId = data.Tables(0).Rows(i).Item("Group_Id").ToString
                GrouptxId = data.Tables(0).Rows(i).Item("Group_Tx_Id").ToString
                NfcType = data.Tables(0).Rows(i).Item("Type").ToString
                Recipient = data.Tables(0).Rows(i).Item("Recipient").ToString
                Select Case GroupType
                    Case "G"
                        Dim gDS As New DataSet
                        gDS = QueryGroupUser(GroupId)

                        For Each row As DataRow In gDS.Tables(0).Rows
                            Dim _row As DataRow = newDataDS.Tables(0).NewRow

                            EmployeeCode = row.Item("Employee_Code").ToString
                            If NfcType = "M" Then
                                _row.Item("Recipient") = QueryMailByUserId(EmployeeCode)
                            Else
                                _row.Item("Recipient") = EmployeeCode
                            End If
                            _row.Item("MID") = getNFCSerialNo()
                            _row.Item("SendDate") = sendDate
                            _row.Item("Start_Time") = StartTime
                            _row.Item("End_Time") = EndTime
                            _row.Item("Status") = Status
                            _row.Item("Subject") = Subject
                            _row.Item("MsgBody") = MsgBody
                            _row.Item("ReplyMsg") = ReplyMsg.ToString
                            _row.Item("ExternalFuction") = ExternalFuction.ToString
                            _row.Item("Create_User") = CreateUser
                            _row.Item("Modified_User") = ModifiedUser
                            _row.Item("App_System_No") = AppSystemNo
                            _row.Item("Sub_System_No") = SubSystemNo
                            _row.Item("Tsk_Task_no") = TskTaskNo
                            _row.Item("Fun_Function_No") = FunFunctionNo
                            _row.Item("Level") = Level
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("Create_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Modified_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Group_Type") = GroupType
                            _row.Item("Group_Id") = GroupId
                            _row.Item("Group_Tx_Id") = GrouptxId
                            _row.Item("Type") = NfcType
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("call_IP") = callIP
                            newDataDS.Tables(0).Rows.Add(_row)

                        Next

                    Case "D"
                        Dim gDS As New DataSet
                        gDS = QueryDepartmentUser(GroupId)

                        For Each row As DataRow In gDS.Tables(0).Rows
                            Dim _row As DataRow = newDataDS.Tables(0).NewRow

                            EmployeeCode = row.Item("Employee_Code").ToString
                            If NfcType = "M" Then
                                _row.Item("Recipient") = QueryMailByUserId(EmployeeCode)
                            Else
                                _row.Item("Recipient") = EmployeeCode
                            End If
                            _row.Item("MID") = getNFCSerialNo()
                            _row.Item("SendDate") = sendDate
                            _row.Item("Start_Time") = StartTime
                            _row.Item("End_Time") = EndTime
                            _row.Item("Status") = Status
                            _row.Item("Subject") = Subject
                            _row.Item("MsgBody") = MsgBody
                            _row.Item("ReplyMsg") = ReplyMsg.ToString
                            _row.Item("ExternalFuction") = ExternalFuction.ToString
                            _row.Item("Create_User") = CreateUser
                            _row.Item("Modified_User") = ModifiedUser
                            _row.Item("App_System_No") = AppSystemNo
                            _row.Item("Sub_System_No") = SubSystemNo
                            _row.Item("Tsk_Task_no") = TskTaskNo
                            _row.Item("Fun_Function_No") = FunFunctionNo
                            _row.Item("Level") = Level
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("Create_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Modified_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Group_Type") = GroupType
                            _row.Item("Group_Id") = GroupId
                            _row.Item("Group_Tx_Id") = GrouptxId
                            _row.Item("Type") = NfcType
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("call_IP") = callIP
                            newDataDS.Tables(0).Rows.Add(_row)

                        Next
                    Case "C"
                        Dim gDS As New DataSet
                        gDS = QueryALLUser()

                        For Each row As DataRow In gDS.Tables(0).Rows
                            Dim _row As DataRow = newDataDS.Tables(0).NewRow

                            EmployeeCode = row.Item("Employee_Code").ToString
                            If NfcType = "M" Then
                                _row.Item("Recipient") = QueryMailByUserId(EmployeeCode)
                            Else
                                _row.Item("Recipient") = EmployeeCode
                            End If
                            _row.Item("MID") = getNFCSerialNo()
                            _row.Item("SendDate") = sendDate
                            _row.Item("Start_Time") = StartTime
                            _row.Item("End_Time") = EndTime
                            _row.Item("Status") = Status
                            _row.Item("Subject") = Subject
                            _row.Item("MsgBody") = MsgBody
                            _row.Item("ReplyMsg") = ReplyMsg.ToString
                            _row.Item("ExternalFuction") = ExternalFuction.ToString
                            _row.Item("Create_User") = CreateUser
                            _row.Item("Modified_User") = ModifiedUser
                            _row.Item("App_System_No") = AppSystemNo
                            _row.Item("Sub_System_No") = SubSystemNo
                            _row.Item("Tsk_Task_no") = TskTaskNo
                            _row.Item("Fun_Function_No") = FunFunctionNo
                            _row.Item("Level") = Level
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("Create_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Modified_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                            _row.Item("Group_Type") = GroupType
                            _row.Item("Group_Id") = GroupId
                            _row.Item("Group_Tx_Id") = GrouptxId
                            _row.Item("Type") = NfcType
                            _row.Item("spec_Flag") = specFlag
                            _row.Item("call_IP") = callIP
                            newDataDS.Tables(0).Rows.Add(_row)

                        Next
                    Case "P"

                        If NfcType = "M" Then
                            data.Tables(0).Rows(i).Item("Recipient") = QueryMailByUserId(Recipient)
                        End If
                        data.Tables(0).Rows(i).Item("SendDate") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                        data.Tables(0).Rows(i).Item("Create_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                        data.Tables(0).Rows(i).Item("Modified_Time") = CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss")
                End Select

            Next
            If GroupType <> "P" Then
                Dim count As Integer = NfcNotifyMsgBO.GetInstance.insert(newDataDS, conn)
            Else
                Dim count As Integer = NfcNotifyMsgBO.GetInstance.insert(data, conn)
            End If


            Return ""
        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

    End Function

#End Region

#Region "     查詢 NFC_Notify_Msg "

    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="UserId" >查詢 NFC_Notify_Msg</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As DataSet

        Dim ds As New DataSet
        Dim strNowDate As String = Now.ToString("yyyyMMdd")
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            
            sqlString.Append("SELECT A.* , B.Employee_Name " & vbCrLf)
            sqlString.Append("  FROM NFC_Notify_Msg A " & vbCrLf)
            sqlString.Append("  LEFT OUTER JOIN pub_employee B " & vbCrLf)
            sqlString.Append("  on A.Recipient=B.employee_code " & vbCrLf)
            sqlString.Append("  where  A.Create_User = @Create_User " & vbCrLf)
            sqlString.Append("  and convert(varchar,SendDate,112)=@strNowDate " & vbCrLf)
            sqlString.Append("  order By A.SendDate desc")

            command.CommandText = sqlString.ToString '" Select * From NFC_Notify_Msg Where Create_User = @Create_User   "
            command.Parameters.AddWithValue("@Create_User", UserId)
            command.Parameters.AddWithValue("@strNowDate", strNowDate)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Notify_Msg")
                adapter.Fill(ds, "NFC_Notify_Msg")
            End Using

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function
    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="UserId" >根據Mail 取得UserID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryMailByUserId(ByVal UserId As String) As String

        Dim ds As New DataSet
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select EMail from PUB_Employee  where Employee_Code= @Employee_Code   "
            command.Parameters.AddWithValue("@Employee_Code", UserId)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Notify_Msg")
                adapter.Fill(ds, "NFC_Notify_Msg")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("EMail").ToString
            Else
                Return ""
            End If

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function
    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="mail" >根據UserID取得Mail</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryUserNameByMail(ByVal mail As String) As String

        Dim ds As New DataSet
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select Employee_Name from PUB_Employee  where EMail= @mail   "
            command.Parameters.AddWithValue("@mail", mail)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Notify_Msg")
                adapter.Fill(ds, "NFC_Notify_Msg")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("Employee_Name").ToString
            Else
                Return "系統管理者"
            End If

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As DataSet

        Dim ds As New DataSet
        Dim TypeStr As String = ""
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select B.Employee_Name , A.*   From NFC_Notify_Msg A , PUB_Employee B  Where 1=1 And A.Recipient =B.Employee_Code    "

            command.CommandText = "select A.*,B.Employee_Name,C.Employee_Name as sendUser from NFC_Notify_Msg A " & _
                                  "LEFT OUTER JOIN pub_employee B  ON A.Recipient = b.Employee_Code  " & _
                                  "LEFT OUTER JOIN pub_employee C  ON A.Create_User = C.Employee_Code   where 1=1  "

            If StartSendDate <> "" And IsDate(StartSendDate) Then
                command.CommandText += " And CAST(A.SendDate AS DateTime)>='" & StartSendDate & "' "
            End If

            If EndSendDate <> "" And IsDate(EndSendDate) Then
                command.CommandText += " And CAST(A.SendDate AS DateTime)<='" & EndSendDate & "' "
            End If


            If Fun_Function_No.Trim <> "" Then
                Dim newValue As String = Fun_Function_No.Replace("!@#$", "")
                If Fun_Function_No.Substring(0, 4) = "!@#$" Then
                    If newValue <> "" Then
                        command.CommandText += " And A.MsgBody like '%" & newValue & "%' "
                    End If

                Else
                    command.CommandText += " And A.Fun_Function_No='" & Fun_Function_No & "' "
                End If

            End If

            If Type.Contains("W") Then
                TypeStr += " A.Type='W' "
            End If

            If Type.Contains("M") Then
                If TypeStr = "" Then
                    TypeStr += " A.Type='M' "
                Else
                    TypeStr += " Or A.Type='M' "
                End If
            End If

            If Type.Contains("S") Then
                If TypeStr = "" Then
                    TypeStr += " A.Type='S' "
                Else
                    TypeStr += " Or A.Type='S' "
                End If
            End If

            If TypeStr <> "" Then
                command.CommandText += " And (" & TypeStr & ")"
            End If


            If Level <> "" Then
                command.CommandText += " And A.Level='" & Level & "' "
            End If

            If Status = "Y" Then
                command.CommandText += " And A.Status='" & Status & "' And A.Spec_Flag='N' "
            ElseIf Status = "N" Then
                command.CommandText += " And A.Status='' "
            ElseIf Status = "O" Then
                command.CommandText += " And A.Spec_Flag='O' "
            ElseIf Status = "X" Then
                command.CommandText += " And A.Spec_Flag='Y'  And A.Status='Y' "
            ElseIf Status = "A" Then
                command.CommandText += " And cast(A.End_Time as DateTime) < '" & Now.ToString("yyyy-MM-dd HH:mm:00.000") & "' "
            ElseIf Status = "B" Then
                command.CommandText += " And cast(A.End_Time as DateTime) >= '" & Now.ToString("yyyy-MM-dd HH:mm:00.000") & "'  And cast(A.Start_Time as date) <= '" & Now.ToString("yyyy-MM-dd") & "' "
            ElseIf Status = "C" Then
                command.CommandText += " And cast(A.Start_Time as DateTime) > '" & Now.ToString("yyyy-MM-dd HH:mm:00.000") & "' "
            End If


            If Recipient <> "" Then
                If Recipient.Contains("@@@") Then
                    command.CommandText += " And A.Recipient in (  Select Employee_Code   From   PUB_Employee   Where Dept_Code = '" & Recipient.Replace("@@@", "") & "' ) "
                Else
                    command.CommandText += " And A.Recipient='" & Recipient & "' "
                End If

            End If

            If sendUser <> "" Then
                command.CommandText += " And A.Create_User='" & sendUser & "' "
            End If

            command.CommandText += " And A.Group_Type <> 'NULL'  "

            '2015-05-15 Add By Alan-加入排序條件
            command.CommandText += " Order By A.SendDate Desc "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Notify_Msg")
                adapter.Fill(ds, "NFC_Notify_Msg")
            End Using
            For Each row As DataRow In ds.Tables(0).Rows
                Dim tmpMail As String = row.Item("Recipient").ToString.Trim
                If row.Item("Type") = "M" Then
                    row.Item("Employee_Name") = QueryUserNameByMail(tmpMail)
                End If
            Next

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function


    ''' <summary>
    ''' initial initialNfcQueryExportUI
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function initialNfcQueryExportUI() As DataSet

        Dim ds As New DataSet
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            'command.CommandText = " select fun_function_no, fun_function_name from ARM_Fun_System order by fun_function_no   "
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select distinct B.Fun_Function_No,B.fun_function_name " & vbCrLf)
            sqlString.Append("from NFC_Notify_Msg A ,ARM_Fun_System  B " & vbCrLf)
            sqlString.Append("where a.Fun_Function_No=b.fun_function_no")
            command.CommandText = sqlString.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("ARM_Fun_System")
                adapter.Fill(ds, "ARM_Fun_System")
            End Using

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function
#End Region

#Region "     取得所屬群組成員"
    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="GroupID" >根據GroupID取得UserID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryGroupUser(ByVal GroupID As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                'conn.Open()
            End If
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select A.Employee_Code,B.Employee_Name from NFC_Group_Maintain  A " & vbCrLf)
            sqlString.Append("left outer join PUB_Employee B on A.Employee_Code=B.Employee_Code " & vbCrLf)
            sqlString.Append("where Group_Id=@Group_ID")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Group_Id", GroupID)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Group_Maintain")
                adapter.Fill(ds, "NFC_Group_Maintain")
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
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="DeptCode" >根據DeptCode取得UserID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryDepartmentUser(ByVal DeptCode As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                'conn.Open()
            End If
            Dim cTime As String = Now.ToString("yyyy-MM-dd")
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("  select * from PUB_Employee " & vbCrLf)
            sqlString.Append("  where Dept_Code=@DeptCode " & vbCrLf)
            sqlString.Append("  and cast(Assume_end_Date as date) >=@cTime")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@DeptCode", DeptCode)
            command.Parameters.AddWithValue("@cTime", cTime)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Employee")
                adapter.Fill(ds, "PUB_Employee")
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
    ''' 查詢 NFC_Notify_Msg 根據DeptCode取得UserID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function QueryALLUser(Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                'conn.Open()
            End If
            Dim cTime As String = Now.ToString("yyyy-MM-dd")
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("  select * from PUB_Employee " & vbCrLf)
            sqlString.Append("  where cast(Assume_end_Date as date) >=@cTime " & vbCrLf)

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@cTime", cTime)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Employee")
                adapter.Fill(ds, "PUB_Employee")
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

#Region "     訊息群組維護"
    '新增群組名稱
    Public Function insertGroup(ByVal groupName As String, createUser As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Dim tableName As String = "NFC_Group"
        Try
            Dim groupID As String = getGroupID()
            Dim currentTime = Now
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Group_Id , Group_Name , Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time ) " & _
             " values( @Group_Id , @Group_Name , @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time             )"
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
                command.Parameters.AddWithValue("@Group_Id", groupID)
                command.Parameters.AddWithValue("@Group_Name", groupName)
                command.Parameters.AddWithValue("@Create_User", createUser)
                command.Parameters.AddWithValue("@Create_Time", currentTime)
                command.Parameters.AddWithValue("@Modified_User", createUser)
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                Dim cnt As Integer = command.ExecuteNonQuery

            End Using
            Return 0
        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function

    '刪除群組名稱
    Public Function deleteGroup(ByVal groupID As String) As Integer
        Try

            Dim obj As New Syscom.Server.BO.NfcGroupBO

            Using nfcConn As System.Data.IDbConnection = getConnection()
                nfcConn.Open()
                obj.delete(groupID)
            End Using

            Return 0
        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try
    End Function
    '查詢群組名稱By User
    Public Function queryGroupByUser(ByVal employee_Code As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = getConnection()
                'conn.Open()
            End If
            'Dim sqlString As New System.Text.StringBuilder
            'sqlString.Append("select * from NFC_Group where Create_User=@employee_Code " & vbCrLf)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("Select '2021' as code1 , '群組' as name1 , " & vbCrLf)
            sqlString.Append("Group_Id as code2 , Group_Name as name2 " & vbCrLf)
            sqlString.Append("From  NFC_Group  Where Create_User=@employee_Code")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@employee_Code", employee_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Group")
                adapter.Fill(ds, "NFC_Group")
            End Using
            'ds.Tables(0).Rows.Add("", "", "2021", "群組")
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

    '取得群組代碼
    Function getGroupID(Optional ByVal conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Dim groupID As String = ""
        Try
            If connFlag Then
                conn = getConnection()
                'conn.Open()
            End If
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select max(Group_Id)+1 as groupID from NFC_Group")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Group")
                adapter.Fill(ds, "NFC_Group")
            End Using

            If IsDBNull(ds.Tables(0).Rows(0).Item("groupID")) Then
                groupID = "10000"
            Else
                groupID = ds.Tables(0).Rows(0).Item("groupID").ToString
            End If
            Return groupID

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


    '新增訊息群組成員
    Public Function insertGroupMember(ByVal ds As DataSet) As Integer
        Try
            If ds.Tables(0).Rows.Count > 0 Then

                Dim obj As New Syscom.Server.BO.NfcGroupMaintainBO
                Dim groupID As String = ds.Tables(0).Rows(0).Item("Group_Id").ToString.Trim
                Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope
                    Using nfcConn As System.Data.IDbConnection = getConnection()
                        nfcConn.Open()
                        deleteGroupMemberByGroupID(groupID, nfcConn)
                        obj.insert(ds, nfcConn)
                    End Using
                    Scope.Complete()
                End Using
            End If

            Return 0
        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try
    End Function
    '刪除訊息群組成員
    Public Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer
        Try
            Dim obj As New Syscom.Server.BO.NfcGroupMaintainBO
            obj.delete(groupID, employeeCode)
            Return 0
        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try
    End Function
    Public Function deleteGroupMembers(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim obj As New Syscom.Server.BO.NfcGroupMaintainBO
            For Each row As DataRow In ds.Tables(0).Rows
                obj.delete(row.Item("Group_Id"), row.Item("Employee_Code"), conn)
                count = count + 1
            Next
            Return count

        Catch sqlex As SqlException
            Return sqlex.ToString
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try
    End Function
    ''' <summary>
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="GroupID" >根據GroupID取得UserID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryGroupMember(ByVal GroupID As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = getConnection()
                'conn.Open()
            End If
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select A.Employee_Code as code2,B.Employee_Name as name2 from NFC_Group_Maintain  A " & vbCrLf)
            sqlString.Append("left outer join PUB_Employee B on A.Employee_Code=B.Employee_Code " & vbCrLf)
            sqlString.Append("where A.Group_Id=@Group_ID")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Group_ID", GroupID)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Group_Maintain")
                adapter.Fill(ds, "NFC_Group_Maintain")
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
    ''' 查詢 NFC_Notify_Msg
    ''' </summary>
    ''' <param name="GroupID" >根據GroupID取得UserID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryGroupMember1(ByVal GroupID As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = getConnection()
                'conn.Open()
            End If
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select A.Employee_Code,B.Employee_Name from NFC_Group_Maintain  A " & vbCrLf)
            sqlString.Append("left outer join PUB_Employee B on A.Employee_Code=B.Employee_Code " & vbCrLf)
            sqlString.Append("where A.Group_Id=@Group_ID")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Group_ID", GroupID)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Group_Maintain")
                adapter.Fill(ds, "NFC_Group_Maintain")
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
    '''以群組ID刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteGroupMemberByGroupID(ByRef Group_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from NFC_Group_Maintain where " & _
            " Group_Id=@Group_Id  "
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
                command.Parameters.AddWithValue("@Group_Id", Group_Id)
                count = command.ExecuteNonQuery
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
    ''' <summary>
    ''' 刪除發布訊息
    ''' </summary>
    ''' <param name="Group_Tx_Id"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from NFC_Notify_Msg where " & _
            " Group_Tx_ID=@Group_Tx_Id  "
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
                command.Parameters.AddWithValue("@Group_Tx_Id", Group_Tx_Id)
                count = command.ExecuteNonQuery
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

    Public Function updateSender(ByRef ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update NFC_Notify_Msg set Start_Time=@Start_Time" & _
            ",End_Time=@End_Time " & _
            ",Subject=@Subject " & _
            ",MsgBody=@MsgBody " & _
            "where  Group_Tx_Id=@Group_Tx_Id  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Start_Time", row.Item("Start_Time"))
                    command.Parameters.AddWithValue("@End_Time", row.Item("End_Time"))
                    command.Parameters.AddWithValue("@Subject", row.Item("Subject"))
                    command.Parameters.AddWithValue("@MsgBody", row.Item("MsgBody"))
                    command.Parameters.AddWithValue("@Group_Tx_Id", row.Item("Group_Tx_Id"))
                    count = command.ExecuteNonQuery
                    count = count + 1
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

#Region "   取得訊息片語"
    Public Function getNfcPhrase(ByVal ID As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As New DataSet
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                'conn.Open()
            End If
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select NFC_Phrase_ID,NFC_Phrase_Name from NFC_Phrase  " & vbCrLf)
            sqlString.Append("where 1=1 and  NFC_Phrase_ID like @NFC_Phrase_ID")

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@NFC_Phrase_ID", ID & "%")
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NFC_Phrase")
                adapter.Fill(ds, "NFC_Phrase")
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

#Region "     取得在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 住院DB 在所屬資料庫的連線
    ''' </summary>
    ''' ''' <returns>資料庫連線</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class
