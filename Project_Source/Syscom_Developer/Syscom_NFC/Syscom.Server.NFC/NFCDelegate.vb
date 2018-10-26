Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.CMM
Imports Syscom.Server.SNC

Public Class NFCDelegate

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
    Public Shared ReadOnly Property getInstance() As NFCDelegate
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

        Public Shared ReadOnly instance As New NFCDelegate()
    End Class

#End Region

#Region "   群組維護"
    ''' <summary>
    ''' 查詢NFC群組成員
    ''' </summary>
    ''' <param name="groupID">NFC群組ID</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢NFC群組成員</remarks>
    Public Function queryGroupMember(ByVal groupID As String) As DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.queryGroupMember(groupID)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 查詢NFC群組成員
    ''' </summary>
    ''' <param name="groupID">NFC群組ID</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢NFC群組成員</remarks>
    Public Function queryGroupMember1(ByVal groupID As String) As DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.queryGroupMember1(groupID)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 新增群組成員
    ''' </summary>
    ''' <param name="ds">群組成員dataset</param>
    ''' <returns>Integer</returns>
    ''' <remarks>新增群組成員</remarks>
    Public Function insertGroupMember(ByVal ds As DataSet) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.insertGroupMember(ds)
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
    ''' <summary>
    ''' 刪除群組成員
    ''' </summary>
    ''' <param name="groupID">NFC群組ID</param>
    ''' <param name="employeeCode">員工代碼</param>
    ''' <returns>Integer</returns>
    ''' <remarks>刪除群組成員</remarks>
    Public Function deleteGroupMember(ByVal groupID As String, ByVal employeeCode As String) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.deleteGroupMember(groupID, employeeCode)
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
    ''' <summary>
    ''' 刪除訊息群組成員
    ''' </summary>
    ''' <param name="ds">訊息群組成員dataset</param>
    ''' <returns>Integer</returns>
    ''' <remarks>刪除訊息群組成員</remarks>
    Public Function deleteGroupMembers(ByVal ds As DataSet) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.deleteGroupMembers(ds)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
    ''' <summary>
    ''' 刪除寄件人藉由訊息群組ID
    ''' </summary>
    ''' <param name="Group_Tx_Id">群組訊息ID</param>
    ''' <returns>Integer</returns>
    ''' <remarks>刪除寄件人藉由群組訊息ID</remarks>
    Public Function deleteSenderByGroupTxId(ByRef Group_Tx_Id As System.String) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.deleteSenderByGroupTxId(Group_Tx_Id)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
    ''' <summary>
    ''' 修改寄件人
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>修改寄件人</remarks>
    Public Function updateSender(ByRef ds As System.Data.DataSet) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.updateSender(ds)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' 新增群組名稱
    ''' </summary>
    ''' <param name="groupName">群組名稱</param>
    ''' <param name="createUser">創作者</param>
    ''' <returns>Integer</returns>
    ''' <remarks>新增群組名稱</remarks>
    Public Function insertGroup(ByVal groupName As String, createUser As String) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.insertGroup(groupName, createUser)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' 刪除群組名稱
    ''' </summary>
    ''' <param name="groupID">群組ID</param>
    ''' <returns>Integer</returns>
    ''' <remarks>刪除群組名稱</remarks>
    Public Function deleteGroup(ByVal groupID As String) As Integer
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.deleteGroup(groupID)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' 查詢群組名稱By User
    ''' </summary>
    ''' <param name="employee_Code">員工代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢群組名稱By User</remarks>
    Public Function queryGroupByUser(ByVal employee_Code As String) As System.Data.DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.queryGroupByUser(employee_Code)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "   更新IP and 回饋"
    ''' <summary>
    ''' 更新讀取IP 
    ''' </summary>
    ''' <param name="mid">訊息ID</param>
    ''' <param name="call_IP">USER端IP</param>
    ''' <param name="modified_User">修改人</param>
    ''' <param name="conn">資料連線</param>
    ''' <returns>Integer</returns>
    ''' <remarks>更新讀取IP </remarks>
    Public Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim instance As NfcNotifyMsgBO_E1 = NfcNotifyMsgBO_E1.getInstance
            Return instance.UpdateIP(mid, call_IP, modified_User)
        Catch cmex As CommonException
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' 更新 回饋="O"
    ''' </summary>
    ''' <param name="mid">訊息ID</param>
    ''' <param name="modified_User">修改人</param>
    ''' <param name="conn">資料連線</param>
    ''' <returns>Integer</returns>
    ''' <remarks>更新 回饋="O"</remarks>
    Public Function UpdateSpecFlag(ByVal mid As String, ByVal modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim instance As NfcNotifyMsgBO = NfcNotifyMsgBO.GetInstance
            Return instance.UpdateSpecFlag(mid, modified_User)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
    ''' <summary>
    ''' 回復訊息
    ''' </summary>
    ''' <param name="mid"></param>
    ''' <param name="replayMsg"></param>
    ''' <param name="modifyUser"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateReplayMsg(ByVal mid As String, ByVal replayMsg As String, ByVal modifyUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim instance As NfcNotifyMsgBO_E1 = NfcNotifyMsgBO_E1.getInstance
            'instance.UpdateSpecFlag(mid, modifyUser)
            Return instance.UpdateReplayMsg(mid, replayMsg, modifyUser)

        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
#End Region

#Region "   NFC新增查詢"


    ''' <summary>
    ''' 新增訊息
    ''' </summary>
    ''' <param name="data">訊息DataSet</param>
    ''' <returns>String</returns>
    ''' <remarks>新增訊息</remarks>
    Public Function InsertNFCNotifyMsg(ByVal data As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            For i As Integer = 0 To data.Tables(0).Rows.Count - 1
                data.Tables(0).Rows(i).Item("MID") = getNFCSerialNo()
            Next
            Return instance.InsertNFCNotifyMsg(data, conn)
        Catch cmex As CommonException
            Return cmex.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    ''' <summary>
    ''' 查詢訊息By UserID
    ''' </summary>
    ''' <param name="UserId">使用者ID</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢訊息By UserID</remarks>
    Public Function QueryNFCNotifyMsgByUserId(ByVal UserId As String) As DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.QueryNFCNotifyMsgByUserId(UserId)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 查詢訊息 By 條件
    ''' </summary>
    ''' <param name="StartSendDate">開始寄送日期</param>
    ''' <param name="EndSendDate">結束寄送日期</param>
    ''' <param name="Fun_Function_No">功能編碼</param>
    ''' <param name="Type">型態</param>
    ''' <param name="Level">層級</param>
    ''' <param name="Status">狀態</param>
    ''' <param name="Recipient">接受人</param>
    ''' <param name="sendUser">傳送人</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢訊息 By 條件</remarks>
    Public Function QueryNFCNotifyMsgByCond(ByVal StartSendDate As String, ByVal EndSendDate As String, ByVal Fun_Function_No As String, ByVal Type As String, ByVal Level As String, ByVal Status As String, ByVal Recipient As String, ByVal sendUser As String) As DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.QueryNFCNotifyMsgByCond(StartSendDate, EndSendDate, Fun_Function_No, Type, Level, Status, Recipient, sendUser)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 初始化NFC查詢輸出UI
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>初始化NFC查詢輸出UI</remarks>
    Public Function initialNfcQueryExportUI() As DataSet
        Try
            Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Return instance.initialNfcQueryExportUI()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#Region "   取得訊息序號"
    Private Function getNFCSerialNo() As String
        Return StringUtil.appendCharToLeft(SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeC, "NFC", 1, -1), "0".Chars(0), 10)
    End Function
#End Region

#Region "   駐記為已讀"

    ''' <summary>
    ''' 駐記為已讀
    ''' </summary>
    ''' <param name="ds">駐記DataSet</param>
    ''' <param name="conn">資料連線</param>
    ''' <remarks>駐記為已讀</remarks>
    Private Sub markRead(ByVal ds As Data.DataSet, ByRef conn As SqlConnection)
        Dim sqlStr As String = "update NFC_Notify_Msg set Status=@Status , Modified_User=@Modified_User , Modified_Time=@Modified_Time where   MID=@MID and SendDate=@SendDate and Recipient=@Recipient and Type='A' "
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
                command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery

            End Using
        Next

    End Sub

#End Region

    ''' <summary>
    ''' 取得員工部門代碼
    ''' </summary>
    ''' <param name="empNO">員工號</param>
    ''' <param name="conn">資料庫連線 hisDB</param>
    ''' <returns>String</returns>
    ''' <remarks>取得員工部門代碼</remarks>
    Private Function getDepNo(ByVal empNO As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing
        Dim result As String = ""
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                conn.Open()
            End If
            Dim sqlstr As New StringBuilder("select Dept_Code from PUB_Employee where Employee_Code='" & empNO & "'")
            Dim dataSet As DataSet = New DataSet

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlstr.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    dataSet = New DataSet("PUB_Employee")
                    adapter.Fill(dataSet, "PUB_Employee")
                    adapter.FillSchema(dataSet, SchemaType.Mapped, "PUB_Employee")
                End Using
            End Using

            If dataSet IsNot Nothing AndAlso dataSet.Tables.Count > 0 AndAlso dataSet.Tables(0).Rows.Count > 0 Then
                If IsDBNull(dataSet.Tables(0).Rows.Item(0).Item(0)) = False Then
                    result = dataSet.Tables(0).Rows.Item(0).Item(0)
                End If
            End If
            Return result
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
    ''' 讀取個人訊息，可不傳 depNo，由程式去撈資料
    ''' </summary>
    ''' <param name="empNO">員工號</param>
    ''' <param name="conn">資料庫連線 hisDB</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>讀取個人訊息，可不傳 depNo，由程式去撈資料</remarks>
    Public Function readUIMessage(ByVal empNO As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Return readUIMessage(empNO, "", conn)
    End Function
    ''' <summary>
    ''' 讀取個人訊息，需傳 depNo
    ''' </summary>
    ''' <param name="empNO">員工號</param>
    ''' <param name="depNo">部門代碼</param>
    ''' <param name="conn">資料庫連線 hisDB</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>讀取個人訊息，需傳 depNo</remarks>
    Public Function readUIMessage(ByVal empNO As String, ByVal depNo As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                conn.Open()
            End If

            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

            'Dim sqlstr As New StringBuilder("select * from NFC_Notify_Msg where ")
            'sqlstr.Append("(Type='C' and Start_Time<=@Start_Time and End_Time>=@End_Time) or ")
            'If depNo IsNot Nothing AndAlso depNo <> "" AndAlso depNo.Trim.Length >= 2 Then
            '    sqlstr.Append("(Type='B' and Start_Time<=@Start_Time and End_Time>=@End_Time and Recipient= substring(@RecipientDep,1,2)  ) or ")
            'End If
            'If empNO IsNot Nothing AndAlso empNO <> "" Then
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT  A.MID " & vbCrLf)
            sqlString.Append("      ,A.SendDate " & vbCrLf)
            sqlString.Append("      ,A.Type " & vbCrLf)
            sqlString.Append("      ,A.Start_Time " & vbCrLf)
            sqlString.Append("      ,A.End_Time " & vbCrLf)
            sqlString.Append("      ,A.Status " & vbCrLf)
            sqlString.Append("      ,A.Subject " & vbCrLf)
            sqlString.Append("      ,A.MsgBody " & vbCrLf)
            sqlString.Append("      ,A.ReplyMsg " & vbCrLf)
            sqlString.Append("      ,A.ExternalFuction " & vbCrLf)
            sqlString.Append("      ,A.Recipient " & vbCrLf)
            sqlString.Append("      ,A.Create_User " & vbCrLf)
            sqlString.Append("      ,A.Create_Time " & vbCrLf)
            sqlString.Append("      ,A.Modified_User " & vbCrLf)
            sqlString.Append("      ,A.Modified_Time " & vbCrLf)
            sqlString.Append("      ,A.App_System_No " & vbCrLf)
            sqlString.Append("      ,A.Sub_System_No " & vbCrLf)
            sqlString.Append("      ,A.Tsk_Task_no " & vbCrLf)
            sqlString.Append("      ,A.Fun_Function_No " & vbCrLf)
            sqlString.Append("      ,A.Level " & vbCrLf)
            sqlString.Append("	  ,B.Employee_Name " & vbCrLf)
            sqlString.Append("  FROM NFC_Notify_Msg A with(nolock), pub_employee B with(nolock) " & vbCrLf)
            sqlString.Append("  where A.Create_User=b.Employee_Code and ")



            sqlString.Append("( Recipient= @RecipientEmp and cast(Start_Time as date)<=@Start_Time and cast(End_Time as date)>=@End_Time )")
            'End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Dim cTime As DateTime = Now.Date.ToString("yyyy-MM-dd")
                command.Parameters.AddWithValue("@Start_Time", cTime)
                command.Parameters.AddWithValue("@End_Time", cTime)
                'command.Parameters.AddWithValue("@RecipientDep", depNo)
                command.Parameters.AddWithValue("@RecipientEmp", empNO)

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    dataSet = New DataSet("NFC_Notify_Msg")
                    adapter.Fill(dataSet, "NFC_Notify_Msg")
                    adapter.FillSchema(dataSet, SchemaType.Mapped, "NFC_Notify_Msg")
                End Using
            End Using
            markRead(dataSet, conn)

            Return dataSet
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
    ''' 讀取24小時前的個人訊息，不需傳 depNo，由程式去撈資料
    ''' </summary>
    ''' <param name="empNO">員工號</param>
    ''' <param name="conn">資料庫連線 hisDB</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>讀取24小時前的個人訊息，不需傳 depNo，由程式去撈資料</remarks>
    Public Function readUIMessage24Hr(ByVal empNO As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Return readUIMessage24Hr(empNO, getDepNo(empNO, conn), conn)
    End Function
    ''' <summary>
    ''' 讀取24小時前的個人訊息，需傳 depNo
    ''' </summary>
    ''' <param name="empNO">員工號</param>
    ''' <param name="depNo">部門代碼</param>
    ''' <param name="conn">資料庫連線 hisDB</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>讀取24小時前的個人訊息，需傳 depNo</remarks>
    Public Function readUIMessage24Hr(ByVal empNO As String, ByVal depNo As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                conn.Open()
            End If

            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema
            ' not (Start_Time > cTime or End_Time < oTime)

            'Dim sqlString As New System.Text.StringBuilder
            'sqlString.Append("select A.*,B.Employee_Name,C.Employee_Name as sendUser " & vbCrLf)
            'sqlString.Append("from NFC_Notify_Msg A " & vbCrLf)
            'sqlString.Append("LEFT OUTER JOIN pub_employee B  ON A.Recipient = b.Employee_Code " & vbCrLf)
            'sqlString.Append("LEFT OUTER JOIN pub_employee C  ON A.Create_User = C.Employee_Code " & vbCrLf)
            'sqlString.Append("where A.Type='W' and ( cast(A.Start_Time as date)>=dateadd(DAY, -3, getdate()) " & vbCrLf)
            'sqlString.Append(" or ( A.Start_Time <= getdate() and  cast(A.End_Time as date)>= getdate()  )) " & vbCrLf)
            'sqlString.Append("and  A.Recipient=@RecipientEmp  ")

            'Dim sqlString As New System.Text.StringBuilder
            'sqlString.Append("select A.*,B.Employee_Name,C.Employee_Name as sendUser " & vbCrLf)
            'sqlString.Append(" from NFC_Notify_Msg A " & vbCrLf)
            'sqlString.Append(" LEFT OUTER JOIN pub_employee B  ON A.Recipient = b.Employee_Code " & vbCrLf)
            'sqlString.Append(" LEFT OUTER JOIN pub_employee C  ON A.Create_User = C.Employee_Code " & vbCrLf)
            'sqlString.Append(" where ((A.Type='W'   and ( cast(A.Start_Time as date)>=dateadd(DAY, -3, getdate()) and A.Subject<>'危險值通報')  or (A.Subject='危險值通報' and A.Type='W' and A.Spec_Flag='Y' )) " & vbCrLf)
            'sqlString.Append("  or ( A.Start_Time <= getdate() and  cast(A.End_Time as date)>= getdate() and A.Type='W') and  A.Subject<>'危險值通報') " & vbCrLf)
            'sqlString.Append("  and  (A.Recipient=@RecipientEmp) " & vbCrLf)
            'sqlString.Append("    " & vbCrLf)
            'sqlString.Append("  order by SendDate desc")

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT A.*, " & vbCrLf)
            sqlString.Append("       B.Employee_Name, " & vbCrLf)
            sqlString.Append("       C.Employee_Name AS sendUser " & vbCrLf)
            sqlString.Append("FROM   NFC_Notify_Msg A with (NOLOCK) " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN pub_employee B with (NOLOCK)" & vbCrLf)
            sqlString.Append("                    ON A.Recipient = b.Employee_Code " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN pub_employee C with (NOLOCK)" & vbCrLf)
            sqlString.Append("                    ON A.Create_User = C.Employee_Code " & vbCrLf)
            sqlString.Append("WHERE  ( " & vbCrLf)
            sqlString.Append("( A.Type = 'W' " & vbCrLf)
            sqlString.Append("	AND ( Cast(A.Start_Time AS DATE) >= Dateadd(DAY, -3, Getdate()) " & vbCrLf)
            sqlString.Append("	AND ( A.Subject <> '危險值通報' and a.ExternalFuction<>'Y') ) " & vbCrLf)
            sqlString.Append("    OR ( A.Subject = '危險值通報' " & vbCrLf)
            sqlString.Append("		AND A.Type = 'W' " & vbCrLf)
            sqlString.Append("		AND A.Spec_Flag = 'Y' ) ) " & vbCrLf)
            sqlString.Append("    OR ( A.Start_Time <= Getdate() " & vbCrLf)
            sqlString.Append("        AND Cast(A.End_Time AS DATE) >= Getdate() " & vbCrLf)
            sqlString.Append("        AND A.Type = 'W' ) " & vbCrLf)
            sqlString.Append("    AND A.Subject <> '危險值通報' ) " & vbCrLf)
            sqlString.Append("       AND ( A.Recipient = @RecipientEmp ) " & vbCrLf)
            sqlString.Append("	   --and a.ExternalFuction<>'Y' " & vbCrLf)
            sqlString.Append("ORDER  BY SendDate DESC")





            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Dim cTime As DateTime = Now
                Dim oTime As DateTime = cTime.AddDays(-4)
                command.Parameters.AddWithValue("@yesDay", oTime)
                command.Parameters.AddWithValue("@nowDay", cTime)
                command.Parameters.AddWithValue("@RecipientDep", depNo)
                command.Parameters.AddWithValue("@RecipientEmp", empNO)


                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    dataSet = New DataSet("NFC_Notify_Msg")
                    adapter.Fill(dataSet, "NFC_Notify_Msg")
                    adapter.FillSchema(dataSet, SchemaType.Mapped, "NFC_Notify_Msg")
                End Using
            End Using
            markRead(dataSet, conn)

            Return dataSet
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
    ''' 通知到所有使用者 UI 畫面
    ''' </summary>    
    ''' <param name="msg">通知訊息</param>
    ''' <param name="startTime">訊息開始時間</param>
    ''' <param name="endTime">訊息結束時間</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks>通知到所有使用者 UI 畫面</remarks>
    Public Sub NotifyAllUI(ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal external As String = "", Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try


            If connFlag Then
                conn = NfcNotifyMsgBO.GetInstance.getConnection
                conn.Open()
            End If

            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema



            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 
            dataRow("MID") = getNFCSerialNo()
            dataRow("SendDate") = Now
            dataRow("Type") = "C"
            dataRow("Start_Time") = startTime
            dataRow("End_Time") = endTime
            dataRow("Status") = ""
            dataRow("Subject") = subject
            dataRow("MsgBody") = msg
            dataRow("ReplyMsg") = ""
            dataRow("ExternalFuction") = external
            dataRow("Recipient") = ""
            Dim name = ServerAppContext.userProfile.userId
            dataRow("Create_User") = ServerAppContext.userProfile.userId
            dataRow("Create_Time") = Now
            dataRow("Modified_User") = ServerAppContext.userProfile.userId
            dataRow("Modified_Time") = Now
            dataRow("App_System_No") = App_System_No
            dataRow("Sub_System_No") = Sub_System_No
            dataRow("Tsk_Task_no") = Tsk_Task_no
            dataRow("Fun_Function_No") = Fun_Function_No
            dataRow("Level") = "1"
            dataRow("Call_IP") = ""
            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            NfcNotifyMsgBO.GetInstance.insert(dataSet, conn)

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
    End Sub
    ''' <summary>
    ''' 通知到部門使用者 UI 畫面
    ''' </summary>
    ''' <param name="empDept">部門</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="startTime">訊息開始時間</param>
    ''' <param name="endTime">訊息結束時間</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks>通知到部門使用者 UI 畫面</remarks>
    Public Sub NotifyDepUI(ByVal empDept As String, ByVal subject As String, ByVal msg As String, ByVal startTime As DateTime, ByVal endTime As DateTime, Optional ByVal external As String = "", Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If empDept IsNot Nothing AndAlso empDept.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim dataSet As DataSet = New DataSet
                Dim dataTable As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema



                Dim dataRow As DataRow = dataTable.NewRow()
                '使用自己的資料來源取代 New Object 
                dataRow("MID") = getNFCSerialNo()
                dataRow("SendDate") = Now
                dataRow("Type") = "B"
                dataRow("Start_Time") = startTime
                dataRow("End_Time") = endTime
                dataRow("Status") = ""
                dataRow("Subject") = subject
                dataRow("MsgBody") = msg
                dataRow("ReplyMsg") = ""
                dataRow("ExternalFuction") = external
                dataRow("Recipient") = empDept
                dataRow("Create_User") = ServerAppContext.userProfile.userId
                dataRow("Create_Time") = Now
                dataRow("Modified_User") = ServerAppContext.userProfile.userId
                dataRow("Modified_Time") = Now
                dataRow("App_System_No") = App_System_No
                dataRow("Sub_System_No") = Sub_System_No
                dataRow("Tsk_Task_no") = Tsk_Task_no
                dataRow("Fun_Function_No") = Fun_Function_No
                dataRow("Level") = "1"
                dataRow("Call_IP") = ""
                dataTable.Rows.Add(dataRow)
                dataSet.Tables.Add(dataTable)
                NfcNotifyMsgBO.GetInstance.insert(dataSet, conn)


            End If
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
    End Sub
    ''' <summary>
    ''' 通知到多個使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">多人通知</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks>通知到多個使用者 UI 畫面</remarks>
    Public Sub NotifyUI(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal external As String = "", Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If drEmpNo IsNot Nothing AndAlso drEmpNo.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In drEmpNo

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "A"
                    dataRow("Start_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    dataRow("End_Time") = Now.ToString("yyyy-MM-dd") + " 23:59:59"
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    dataRow("ExternalFuction") = external
                    dataRow("Recipient") = empNo
                    dataRow("Create_User") = ServerAppContext.userProfile.userId
                    dataRow("Create_Time") = Now
                    dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If
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
    End Sub
    ''' <summary>
    ''' 通知到使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks>通知到使用者 UI 畫面</remarks>
    Public Sub NotifyUI(ByVal drEmpNo As String, ByVal subject As String, ByVal msg As String, Optional ByVal external As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Try
            NotifyUI(New String() {drEmpNo}, subject, msg, external:=external, conn:=conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 通知到使用者 Mail
    ''' </summary>
    ''' <param name="EmpMail">多個員工 Mail</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg">需要回覆或連絡時的內容 ex: 請回 call 2065  陳先生 </param>
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, Optional ByVal replymsg As String = "", Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim msgAdd As New StringBuilder
            msgAdd.AppendLine("Dear Receiver")
            msgAdd.AppendLine("  此封信件為系統通知用，無須回覆。底下為內容：")
            msgAdd.AppendLine("")
            msgAdd.AppendLine(msg)
            msgAdd.AppendLine("")
            msgAdd.AppendLine(replymsg)
            msgAdd.AppendLine("")
            msgAdd.AppendLine("                       Sincerely " & Now)
            msg = msgAdd.ToString
            If EmpMail IsNot Nothing AndAlso EmpMail.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In EmpMail

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "M"
                    dataRow("Start_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    dataRow("End_Time") = Now.ToString("yyyy-MM-dd") + " 23:59:59"
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    'dataRow("ExternalFuction") = external
                    dataRow("Recipient") = empNo
                    dataRow("Create_User") = ServerAppContext.userProfile.userId
                    dataRow("Create_Time") = Now
                    dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If

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

    End Sub
#Region "for ESR"
    ''' <summary>
    ''' 異常通報系統回饋到使用者 Mail
    ''' </summary>
    ''' <param name="EmpMail">多個員工 Mail</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg"></param>
    ''' <remarks>
    ''' Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好
    ''' Created in  2014/11/6, 下午 05:32 by Chris
    ''' </remarks>
    Public Sub NotifyMailWithEsrFormat(ByVal EmpMail() As String, ByVal subject As String, ByVal msg As String, ByVal replymsg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal spec_Flag As String, Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim msgAdd As New StringBuilder
            msgAdd.AppendLine(msg)
            msgAdd.AppendLine(replymsg)

            msg = msgAdd.ToString
            If EmpMail IsNot Nothing AndAlso EmpMail.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In EmpMail

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "M"
                    dataRow("Start_Time") = Now.ToString("yyyy/MM/dd")
                    dataRow("End_Time") = "2099/12/31"
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    'dataRow("ExternalFuction") = external
                    dataRow("Recipient") = empNo
                    If CreateUser <> "" Then
                        dataRow("Create_User") = CreateUser
                        dataRow("Modified_User") = CreateUser
                    Else
                        dataRow("Create_User") = ServerAppContext.userProfile.userId
                        dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    End If

                    dataRow("Create_Time") = Now
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Spec_Flag") = spec_Flag
                    dataRow("Group_Type") = "P"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If

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

    End Sub

    ''' <summary>
    ''' 通知到多個使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">原工編號</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">訊息</param>
    ''' <param name="Start_Time">開始時間</param>
    ''' <param name="End_Time">結束時間</param>
    ''' <param name="conn">The connection.</param>
    ''' <remarks>
    ''' Created in  2014/11/6, 下午 05:58 by Chris
    ''' </remarks>
    ''' <exception cref="Syscom.Comm.EXP.CommonException">CMMCMMD001</exception>
    Public Sub NotifyUIWithStartAndEndTime(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Start_Time As String, End_Time As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal spec_Flag As String, Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Dim _mid As String = ""
        Try
            If drEmpNo IsNot Nothing AndAlso drEmpNo.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema
                Dim external As String = ""

                For Each empNo In drEmpNo

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object
                    _mid = getNFCSerialNo()
                    dataRow("MID") = _mid
                    dataRow("SendDate") = Now
                    dataRow("Type") = "W"
                    dataRow("Start_Time") = Start_Time
                    dataRow("End_Time") = End_Time
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    dataRow("ExternalFuction") = external
                    dataRow("Recipient") = empNo
                    If CreateUser <> "" Then
                        dataRow("Create_User") = CreateUser
                        dataRow("Modified_User") = CreateUser
                    Else
                        dataRow("Create_User") = ServerAppContext.userProfile.userId
                        dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    End If
                    dataRow("Create_Time") = Now
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Spec_Flag") = spec_Flag
                    dataRow("Group_Type") = "P"
                    dataRow("Group_Id") = ""
                    dataRow("Group_tx_Id") = _mid
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If
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
    End Sub

    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">員工號(多人)</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="conn">The connection.</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Created in  2014/11/6, 下午 04:23 by Chris
    ''' </remarks>
    Public Function NotifySMSMultiWithSubject(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, ByVal App_System_No As String, ByVal Sub_System_No As String, ByVal Tsk_Task_no As String, ByVal Fun_Function_No As String, ByVal CreateUser As String, ByVal spec_Flag As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet = New DataSet
        
        Dim callIP As String = ""
        Try
            If drEmpNo IsNot Nothing AndAlso drEmpNo.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In drEmpNo

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "S"
                    dataRow("Start_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    dataRow("End_Time") = Now.ToString("yyyy-MM-dd") + " 23:59:59"
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    If msg.Length > 160 Then
                        msg = msg.Substring(0, 160) '最多 160
                    End If
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    dataRow("ExternalFuction") = ""
                    dataRow("Recipient") = empNo
                    If CreateUser <> "" Then
                        dataRow("Create_User") = CreateUser
                        dataRow("Modified_User") = CreateUser
                    Else
                        dataRow("Create_User") = ServerAppContext.userProfile.userId
                        dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    End If

                    dataRow("Create_Time") = Now


                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Spec_Flag") = spec_Flag
                    dataRow("Group_Type") = "P"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If

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

        Return ds

    End Function
#End Region

    ''' <summary>
    ''' 通知到使用者 Mail
    ''' </summary>
    ''' <param name="subject">主旨</param>
    ''' <param name="msg">內容</param>
    ''' <param name="replymsg">需要回覆或連絡時的內容 ex: 請回 call 2065  陳先生 </param>
    ''' <remarks>Mail 格式可以兩種：1. john.smith@example.com 2. "John Smith"＜john.smith@example.com＞  ,第二種比較好</remarks>
    Public Sub NotifyMail(ByVal EmpMail As String, ByVal subject As String, ByVal msg As String, Optional ByVal replymsg As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Try
            NotifyMail(New String() {EmpMail}, subject, msg, replymsg, conn:=conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">員工號</param>
    ''' <param name="msg">通知訊息</param>    
    ''' <remarks>通知訊息最多 160 個字</remarks>
    Public Function NotifySMS(ByVal drEmpNo() As String, ByVal msg As String, Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet = New DataSet

        Try
            If drEmpNo IsNot Nothing AndAlso drEmpNo.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In drEmpNo

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "S"
                    dataRow("Start_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    dataRow("End_Time") = Now.ToString("yyyy-MM-dd") + " 23:59:59"
                    dataRow("Status") = ""
                    dataRow("Subject") = "SMS"
                    If msg.Length > 160 Then
                        msg = msg.Substring(0, 160) '最多 160
                    End If
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    dataRow("ExternalFuction") = ""
                    dataRow("Recipient") = empNo
                    dataRow("Create_User") = ServerAppContext.userProfile.userId
                    dataRow("Create_Time") = Now
                    dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If

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

        Return ds

    End Function




    ''' <summary>
    ''' 通知到使用者 B.B.Call 
    ''' </summary>
    ''' <param name="drEmpNo">多個員工號</param>
    ''' <param name="msg">通知訊息</param>    
    ''' <remarks>通知訊息最多 160 個字</remarks>
    Public Function NotifySMS(ByVal drEmpNo As String, ByVal msg As String, Optional ByVal conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim returnDS As New DataSet

        Try
            returnDS = NotifySMS(New String() {drEmpNo}, msg, conn:=conn)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return returnDS

    End Function

    ''' <summary>
    ''' Notify共用介面-依【功能】設定的對象與方式進行通知 
    ''' </summary>
    ''' <param name="inSystemNo">系統代碼</param>
    ''' <param name="inSubSystemNo">子系統代碼</param>
    ''' <param name="inTaskNo">作業代碼</param>
    ''' <param name="inFunctionNo">功能代碼</param>
    ''' <param name="inMsgTitle">通知訊息主旨</param>
    ''' <param name="inMsgLevel">通知訊息等級</param>   
    ''' <param name="inMsgContent">通知訊息內容</param>  
    ''' <remarks>通知訊息等級: Error  Warn   Info</remarks>
    Public Sub NotifyByFunctionNo(ByVal inSystemNo As String, ByVal inSubSystemNo As String, ByVal inTaskNo As String, ByVal inFunctionNo As String, _
                                 ByVal inMsgTitle As String, ByVal inMsgLevel As String, ByVal inMsgContent As String)

        Try

            Dim CallNFCNotifier As New NfcNotifierByfunctionBO
            CallNFCNotifier = NfcNotifierByfunctionBO.GetInstance

            '將訊息等級加入Titel中
            If inMsgLevel.Trim <> "" Then inMsgTitle = inMsgLevel.Trim & " - " & inMsgTitle.Trim

            '---------------------------------------------1.Mail通知----------------------------------------------------------
            Dim pvtMailNotifierDS As New DataSet
            pvtMailNotifierDS = CallNFCNotifier.dynamicQueryWithColumnValue(New String() {"App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "Mail_Flag"}, _
                                                                            New String() {inSystemNo, inSubSystemNo, inTaskNo, inFunctionNo, "Y"})


            '取得通知對象EMail
            If pvtMailNotifierDS IsNot Nothing AndAlso pvtMailNotifierDS.Tables IsNot Nothing AndAlso pvtMailNotifierDS.Tables(0).Rows.Count > 0 Then

                Dim pvtMailNotifier(pvtMailNotifierDS.Tables(0).Rows.Count) As String

                For i = 0 To pvtMailNotifierDS.Tables(0).Rows.Count - 1

                    '判斷傳入訊息等級是否需通知
                    If (inMsgLevel.ToUpper = "ERROR" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Error_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "WARN" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Warn_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "INFO" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Info_Flag").ToString.Trim = "Y") Then

                        pvtMailNotifier(i) = pvtMailNotifierDS.Tables(0).Rows(i).Item("EMail").ToString.Trim

                        '呼叫Notify-Mail共用介面
                        NotifyMail(pvtMailNotifier(i), inMsgTitle, inMsgContent)
                    End If

                Next

            End If


            '---------------------------------------------2.B.B.Call通知-----------------------------------------------------
            Dim pvtBBCallNotifierDS As New DataSet
            pvtBBCallNotifierDS = CallNFCNotifier.dynamicQueryWithColumnValue(New String() {"App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "BBCall_Flag"}, _
                                                                              New String() {inSystemNo, inSubSystemNo, inTaskNo, inFunctionNo, "Y"})
            '取得B.B.Call通知對象員工號
            If pvtBBCallNotifierDS IsNot Nothing AndAlso pvtBBCallNotifierDS.Tables IsNot Nothing AndAlso pvtBBCallNotifierDS.Tables(0).Rows.Count > 0 Then

                Dim pvtBBCallNotifier(pvtBBCallNotifierDS.Tables(0).Rows.Count) As String

                '將主旨加入訊息內容
                inMsgContent = inMsgTitle & vbCrLf & inMsgContent

                For i = 0 To pvtMailNotifierDS.Tables(0).Rows.Count - 1

                    '判斷傳入訊息等級是否需通知
                    If (inMsgLevel.ToUpper = "ERROR" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Error_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "WARN" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Warn_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "INFO" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Info_Flag").ToString.Trim = "Y") Then

                        pvtBBCallNotifier(i) = pvtBBCallNotifierDS.Tables(0).Rows(i).Item("Notifier_ID").ToString.Trim

                        '呼叫Notify-Mail共用介面
                        NotifySMS(pvtBBCallNotifier(i), inMsgContent)

                    End If

                Next

            End If


            '---------------------------------------------3.UI通知----------------------------------------------------------
            Dim pvtUINotifierDS As New DataSet
            pvtUINotifierDS = CallNFCNotifier.dynamicQueryWithColumnValue(New String() {"App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "MSN_Flag"}, _
                                                                          New String() {inSystemNo, inSubSystemNo, inTaskNo, inFunctionNo, "Y"})
            '取得B.B.Call通知對象員工號
            If pvtUINotifierDS IsNot Nothing AndAlso pvtUINotifierDS.Tables IsNot Nothing AndAlso pvtUINotifierDS.Tables(0).Rows.Count > 0 Then

                Dim pvtUINotifier(pvtUINotifierDS.Tables(0).Rows.Count) As String

                For i = 0 To pvtUINotifierDS.Tables(0).Rows.Count - 1

                    '判斷傳入訊息等級是否需通知
                    If (inMsgLevel.ToUpper = "ERROR" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Error_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "WARN" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Warn_Flag").ToString.Trim = "Y") OrElse _
                        (inMsgLevel.ToUpper = "INFO" AndAlso pvtMailNotifierDS.Tables(0).Rows(i).Item("Info_Flag").ToString.Trim = "Y") Then

                        pvtUINotifier(i) = pvtUINotifierDS.Tables(0).Rows(i).Item("Notifier_ID").ToString.Trim

                        '呼叫Notify-Mail共用介面
                        NotifyUI(pvtUINotifier(i), inMsgTitle, inMsgContent)

                    End If

                Next

            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 通知對象維護-查詢
    ''' </summary>
    ''' <param name="columnName">欄位名稱</param>
    ''' <param name="columnValue">欄位值</param>    
    ''' <remarks>通知對象維護-查詢</remarks>
    Public Function queryNFCNotifierByFunc(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet

        Try
            Dim CallNFCNotifier As New NfcNotifierByfunctionBO
            CallNFCNotifier = NfcNotifierByfunctionBO.GetInstance

            Return CallNFCNotifier.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    ''' <summary>
    ''' 通知對象維護-存檔
    ''' </summary>
    ''' <param name="inSaveData">存檔資料</param>
    ''' <remarks>通知對象維護-存檔</remarks>
    Public Function saveNFCNotifierByFunc(ByVal inSaveData As DataSet) As Integer

        Try
            Dim CallNFCNotifier As New NfcNotifierByfunctionBO
            CallNFCNotifier = NfcNotifierByfunctionBO.GetInstance

            Dim pvtPKeyDs As New DataSet
            Dim pvtReturnValue As Integer

            '判斷該筆資料是否存在
            pvtPKeyDs = CallNFCNotifier.queryByPK(inSaveData.Tables(0).Rows(0).Item("App_System_No").ToString.Trim, _
                                        inSaveData.Tables(0).Rows(0).Item("Sub_System_No").ToString.Trim(), _
                                        inSaveData.Tables(0).Rows(0).Item("Tsk_Task_no").ToString.Trim, _
                                        inSaveData.Tables(0).Rows(0).Item("Fun_Function_No").ToString.Trim, _
                                        inSaveData.Tables(0).Rows(0).Item("Notifier_ID").ToString.Trim)
            '若存再則更新，否則新增
            If pvtPKeyDs IsNot Nothing AndAlso pvtPKeyDs.Tables IsNot Nothing AndAlso pvtPKeyDs.Tables(0).Rows.Count > 0 Then
                pvtReturnValue = CallNFCNotifier.update(inSaveData)
            Else
                pvtReturnValue = CallNFCNotifier.insert(inSaveData)
            End If

            Return pvtReturnValue
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return 0

    End Function

    ''' <summary>
    ''' 通知對象維護-刪除
    ''' </summary>
    ''' <param name="inDeleteData">刪除資料</param>
    ''' <remarks> 通知對象維護-刪除</remarks>
    Public Function deleteNFCNotifierByFunc(ByVal inDeleteData As DataSet) As Integer

        Try
            Dim CallNFCNotifier As New NfcNotifierByfunctionBO
            CallNFCNotifier = NfcNotifierByfunctionBO.GetInstance

            Dim pvtReturnValue As Integer

            For i = 0 To inDeleteData.Tables(0).Rows.Count - 1

                pvtReturnValue = CallNFCNotifier.delete(inDeleteData.Tables(0).Rows(i).Item("App_System_No").ToString.Trim, _
                                        inDeleteData.Tables(0).Rows(i).Item("Sub_System_No").ToString.Trim(), _
                                        inDeleteData.Tables(0).Rows(i).Item("Tsk_Task_no").ToString.Trim, _
                                        inDeleteData.Tables(0).Rows(i).Item("Fun_Function_No").ToString.Trim, _
                                        inDeleteData.Tables(0).Rows(i).Item("Notifier_ID").ToString.Trim)
            Next

            Return pvtReturnValue
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return 0

    End Function

    ''' <summary>
    '''  取得發版通知-查詢
    ''' </summary>
    ''' <param name="columnName">欄位名稱</param>
    ''' <param name="columnValue">欄位值</param>    
    ''' <remarks>取得發版通知-查詢</remarks>
    Public Function getNotifyMessageByDeploy(ByRef columnName As String(), ByRef columnValue As Object()) As DataSet

        Try
            Dim GetNFCmessage As New NfcNotifyMsgBO
            GetNFCmessage = NfcNotifyMsgBO.GetInstance

            Return GetNFCmessage.dynamicQueryWithColumnValue(columnName, columnValue)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function
    ''' <summary>
    '''  取得發版通知-查詢-By StartTime,EndTime,Extunction
    ''' </summary>
    ''' <param name="_type">型態</param>
    ''' <param name="user">使用者</param>
    ''' <remarks> 取得發版通知-查詢-By StartTime,EndTime,Extunction</remarks>
    Public Function QueryDeployByToDay(ByVal _type As String, ByVal user As String) As System.Data.DataSet

        Try
            Dim GetNFCmessage As New NfcNotifyMsgBO
            GetNFCmessage = NfcNotifyMsgBO.GetInstance

            Return GetNFCmessage.QueryDeployByToDay(_type, user)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    ''' <summary>
    '''  取得發版通知-查詢-By StartTime,EndTime,Extunction
    ''' </summary>
    ''' <param name="ds">型態</param>
    ''' <remarks>取得發版通知-查詢-By StartTime,EndTime,Extunction</remarks>
    Public Function reMarkRead(ByVal ds As DataSet) As Integer

        Try
            Dim GetNFCmessage As New NfcNotifyMsgBO
            GetNFCmessage = NfcNotifyMsgBO.GetInstance

            Return GetNFCmessage.reMarkRead(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

#Region "   取得訊息片語"
    Public Function getNfcPhrase(ByVal ID As String) As DataSet
        Try
            Dim nfcPhrase As NfcNotifyMsgBS
            nfcPhrase = NfcNotifyMsgBS.getInstance
            Return nfcPhrase.getNfcPhrase(ID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
   
#End Region

#Region "UI立即通知"
    ''' <summary>
    ''' 立即通知到多個使用者 UI 畫面
    ''' </summary>
    ''' <param name="drEmpNo">多人通知</param>
    ''' <param name="msg">通知訊息</param>
    ''' <param name="external">預留其他的功能所需的值</param>
    ''' <remarks>立即通知到多個使用者 UI 畫面</remarks>
    Public Sub NotifyUIRigthNow(ByVal drEmpNo() As String, ByVal subject As String, ByVal msg As String, Optional ByVal external As String = "", Optional ByVal App_System_No As String = "", Optional ByVal Sub_System_No As String = "", Optional ByVal Tsk_Task_no As String = "", Optional ByVal Fun_Function_No As String = "", Optional ByVal conn As System.Data.IDbConnection = Nothing)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If drEmpNo IsNot Nothing AndAlso drEmpNo.Length > 0 Then

                If connFlag Then
                    conn = NfcNotifyMsgBO.GetInstance.getConnection
                    conn.Open()
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema

                For Each empNo In drEmpNo

                    Dim dataRow As DataRow = dt.NewRow()
                    '使用自己的資料來源取代 New Object 
                    dataRow("MID") = getNFCSerialNo()
                    dataRow("SendDate") = Now
                    dataRow("Type") = "A"
                    dataRow("Start_Time") = Now
                    dataRow("End_Time") = Now
                    dataRow("Status") = ""
                    dataRow("Subject") = subject
                    dataRow("MsgBody") = msg
                    dataRow("ReplyMsg") = ""
                    dataRow("ExternalFuction") = external
                    dataRow("Recipient") = empNo
                    dataRow("Create_User") = ServerAppContext.userProfile.userId
                    dataRow("Create_Time") = Now
                    dataRow("Modified_User") = ServerAppContext.userProfile.userId
                    dataRow("Modified_Time") = Now
                    dataRow("App_System_No") = App_System_No
                    dataRow("Sub_System_No") = Sub_System_No
                    dataRow("Tsk_Task_no") = Tsk_Task_no
                    dataRow("Fun_Function_No") = Fun_Function_No
                    dataRow("Level") = "1"
                    dataRow("Call_IP") = ""
                    dt.Rows.Add(dataRow)
                Next

                ds.Tables.Add(dt)
                NfcNotifyMsgBO.GetInstance.insert(ds, conn)
            End If
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
    End Sub
#End Region

#Region "2017/03/10 更新訊息結束時間(Nfc_Notify_Msg) by Jun"

#Region "     更新訊息結束時間 "
    ''' <summary>
    ''' 更新訊息結束時間
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function updateNfcNotifyMsgEndTime(ByVal ds As System.Data.DataSet) As Integer

        Dim m_NfcNotifyMsg As NfcNotifyMsgBO_E1 = NfcNotifyMsgBO_E1.getInstance
        Try

            Return m_NfcNotifyMsg.updateNfcNotifyMsgEndTime(ds)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新訊息結束時間"})

        End Try

    End Function

#End Region


#Region "     以主旨取得通知訊息 "
    ''' <summary>
    ''' 以主旨取得通知訊息
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function queryNfcNotifyMsgBySubject(ByVal subject As String) As System.Data.DataSet

        Dim instance As NfcNotifyMsgBO_E1 = NfcNotifyMsgBO_E1.getInstance
        Try

            Return instance.queryNfcNotifyMsgBySubject(subject)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"以主旨取得通知訊息"})

        End Try

    End Function

#End Region


#End Region

#Region "2017/03/21 查詢危險值通報處理情形回覆  by Tony.Chu"

#Region "     查詢 "
    ''' <summary>
    ''' 查詢危險值通報處理情形回覆
    ''' </summary>
    ''' <param name="UserId" >查詢接收人員</param>
    ''' <param name="StartDate" >查詢發送日期(起)</param>
    ''' <param name="EndDate" >查詢發送日期(迄)</param>
    ''' <param name="Status" >查詢類別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, ByVal Status As String) As DataSet
        Try
            'Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Dim m_UpdateNFCReplyMsgBO_E1 As UpdateNFCReplyMsgBO_E1 = New UpdateNFCReplyMsgBO_E1

            Return m_UpdateNFCReplyMsgBO_E1.QueryNFCNotifyMsg(MID, UserId, StartDate, EndDate, Status)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region


#Region "     更新 "
    ''' <summary>
    ''' 更新危險值通報處理情形回覆
    ''' </summary>
    ''' <param name="MID" >編號</param>
    ''' <param name="ReplyMsg" >處理情形</param>
    ''' <param name="Modified_User" >處理人員</param>
    ''' <param name="Modified_Time" >處理時間</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, ByVal Modified_Time As String) As DataSet
        Try
            'Dim instance As NfcNotifyMsgBS = NfcNotifyMsgBS.getInstance
            Dim m_UpdateNFCReplyMsgBO_E1 As UpdateNFCReplyMsgBO_E1 = New UpdateNFCReplyMsgBO_E1

            Return m_UpdateNFCReplyMsgBO_E1.UpdateNFCNotifyMsg(MID, ReplyMsg, Modified_User, Modified_Time)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region

#End Region

End Class
