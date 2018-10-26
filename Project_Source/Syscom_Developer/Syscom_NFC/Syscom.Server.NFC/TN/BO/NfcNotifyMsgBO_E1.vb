Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Data.SqlClient

Public Class NfcNotifyMsgBO_E1
    Inherits NfcNotifyMsgBO
    Dim log As Syscom.Server.CMM.LOGDelegate = Syscom.Server.CMM.LOGDelegate.getInstance
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
    Public Shared Shadows ReadOnly Property getInstance() As NfcNotifyMsgBO_E1
        Get
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

        Public Shared ReadOnly instance As New NfcNotifyMsgBO_E1()
    End Class

#End Region

#Region "更新回覆訊息"
    ''' <summary>
    ''' 更新回覆訊息
    ''' </summary>
    ''' <param name="MID"></param>
    ''' <param name="replayMsg"></param>
    ''' <param name="modifyUser"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateReplayMsg(ByVal MID As String, ByVal replayMsg As String, ByVal modifyUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim ds As New DataSet
        Dim subject As String = ""
        Dim _Recipient = ""
        Try
            ds = queryGroupTxId(MID)
            subject = ds.Tables(0).Rows(0).Item("subject").ToString

            If replayMsg.ToString = "" Then
                replayMsg = "已處理"
            End If

            If subject <> "危險值通報" Then
                UpdateReplayMsg_1(MID, replayMsg, modifyUser, modifyUser)
            Else
                '針對 [危險值通報] 只要一人回覆視同群組已回覆
                For Each row As DataRow In ds.Tables(0).Rows
                    _Recipient = row.Item("Recipient").ToString
                    UpdateReplayMsg_1(row.Item("MID").ToString, replayMsg, _Recipient, modifyUser)
                Next
            End If
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    ''' <summary>
    ''' 更新回覆訊息-私
    ''' </summary>
    ''' <param name="MID"></param>
    ''' <param name="replayMsg"></param>
    ''' <param name="modifyUser"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function UpdateReplayMsg_1(ByVal MID As String, ByVal replayMsg As String, ByVal Recipient As String, ByVal modifyUser As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Spec_Flag=@spec_Flag, ReplyMsg=@ReplyMsg , Status=@Status , Modified_User=@Modified_User,[Modified_Time]=@Modified_Time " & _
            " where  [MID]=@MID and [Recipient]=@Recipient  "
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
                command.Parameters.AddWithValue("@MID", MID.ToString)
                command.Parameters.AddWithValue("@Status", "Y")
                command.Parameters.AddWithValue("@ReplyMsg", replayMsg.ToString)
                command.Parameters.AddWithValue("@Recipient", Recipient.ToString)
                command.Parameters.AddWithValue("@spec_Flag", "O")
                command.Parameters.AddWithValue("@Modified_User", modifyUser.ToString)
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
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

    Function queryGroupTxId(ByVal mid As String) As DataSet
        Dim ds As New DataSet
        Dim conn As System.Data.IDbConnection = Nothing
        Try
            conn = NfcNotifyMsgBO.GetInstance.getConnection

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("select MID,Group_tx_Id,Subject,Recipient from NFC_Notify_Msg where " & vbCrLf)
            sqlString.Append("Group_tx_Id in( " & vbCrLf)
            sqlString.Append("select Group_tx_Id from NFC_Notify_Msg where MID=@mid " & vbCrLf)
            sqlString.Append(") and  [type]='W'")


            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@mid", mid)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Group_tx_Id")
                adapter.Fill(ds, "Group_tx_Id")
            End Using
            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "更新讀取IP"
    ''' <summary>
    ''' 更新讀取IP
    ''' </summary>
    ''' <param name="mid"></param>
    ''' <param name="call_IP"></param>
    ''' <param name="modified_User"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateIP(ByVal mid As String, ByVal call_IP As String, ByVal modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim cnt As Integer = 0
        'Dim connFlag As Boolean = conn Is Nothing
        'Dim sqlStr As String = "update NFC_Notify_Msg set Call_IP=@call_IP,Modified_Time=@Modified_Time   where   MID=@MID and Recipient=@modified_User "
        Try
            '    If connFlag Then
            '        conn = getConnection()
            '        conn.Open()
            '    End If

            '    Dim command As SqlCommand = New SqlCommand
            '    With command
            '        .CommandText = sqlStr
            '        .CommandType = CommandType.Text
            '        .Connection = CType(conn, SqlConnection)
            '        .Parameters.AddWithValue("@MID", mid.ToString)
            '        .Parameters.AddWithValue("@call_IP", call_IP.ToString)
            '        .Parameters.AddWithValue("@Modified_User", modified_User.ToString)
            '        .Parameters.AddWithValue("@Modified_Time", Now)
            '    End With
            '    cnt = command.ExecuteNonQuery
            Return cnt
        Catch sqlex As SqlException
            'log.dbErrorMsg("strSQL：" & sqlStr.ToString & "(MID=" & mid & " modified_User=" & modified_User & "  call_IP=" & call_IP & " cnt=" & cnt.ToString & ")", sqlex)
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            'If connFlag Then
            '    conn.Close()
            '    conn.Dispose()
            '    conn = Nothing
            'End If
        End Try
    End Function
#End Region

#Region " 以主旨取得通知訊息 "

    ''' <summary>
    ''' 以主旨取得通知訊息
    ''' </summary>
    ''' <param name="subject" ></param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function queryNfcNotifyMsgBySubject(ByVal subject As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT * " & vbCrLf)
            varname1.Append("FROM   NFC_Notify_Msg " & vbCrLf)
            varname1.Append("WHERE  [Type] = 'W' " & vbCrLf)
            varname1.Append("       AND Subject = @Subject " & vbCrLf)
            varname1.Append("ORDER  BY SendDate DESC")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@Subject", subject)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
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

#Region " 更新訊息結束時間 "

    ''' <summary>
    ''' 更新訊息結束時間
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Jun on 2017-03-10</remarks>
    Public Function updateNfcNotifyMsgEndTime(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("UPDATE NFC_Notify_Msg " & vbCrLf)
            varname1.Append("SET    modified_user = @Modified_User, " & vbCrLf)
            varname1.Append("       modified_time = Getdate(), " & vbCrLf)
            varname1.Append("	    End_Time = Getdate(), " & vbCrLf)
            varname1.Append("	    ExternalFuction = 'Y', " & vbCrLf)
            varname1.Append("       Status = 'Y' " & vbCrLf)
            varname1.Append("WHERE  [Type] = 'W' " & vbCrLf)
            varname1.Append("       AND [MID] = @MID")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With Command
                        .CommandText = varname1.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@MID", row.Item("MID"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))

                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            Return count

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region
End Class
