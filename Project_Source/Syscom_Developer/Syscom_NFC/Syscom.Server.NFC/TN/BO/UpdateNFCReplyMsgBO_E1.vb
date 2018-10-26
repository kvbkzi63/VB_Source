Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.SNC

Public Class UpdateNFCReplyMsgBO_E1


#Region "     查詢 NFC_Notify_Msg "

    ''' <summary>
    ''' 查詢 查詢危險值通報處理情形回覆
    ''' </summary>
    ''' <param name="MID" >編號</param>
    ''' <param name="UserId" >查詢接收人員</param>
    ''' <param name="StartDate" >查詢發送日期(起)</param>
    ''' <param name="EndDate" >查詢發送日期(迄)</param>
    ''' <param name="Status" >查詢類別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryNFCNotifyMsg(ByVal MID As String, ByVal UserId As String, ByVal StartDate As String, ByVal EndDate As String, ByVal Status As String) As DataSet

        Dim ds As New DataSet
        Dim strNowDate As String = Now.ToString("yyyyMMdd")
        'StartDate = StartDate & "" & "00:00:00"
        'EndDate = EndDate & "" & "23:59:59"
        'SendDate <='2017-03-01 23:59:59'
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder

            sqlString.Append("Select A.MID, A.MsgBody, A.SendDate, B.Employee_Name as Recipient, A.ReplyMsg, " & vbCrLf)
            sqlString.Append("C.Employee_Name as Modified_User " & vbCrLf)
            sqlString.Append("From NFC_Notify_Msg A " & vbCrLf)
            sqlString.Append("Left Join PUB_Employee B On A.Recipient = B.Employee_Code " & vbCrLf)  '開單醫師
            sqlString.Append("Left Join PUB_Employee C On A.Modified_User = c.Employee_Code " & vbCrLf) '處理人員
            sqlString.Append("Where A.subject='危險值通報' " & vbCrLf)
            sqlString.Append("and a.Recipient = '" & UserId & "' " & vbCrLf)
            sqlString.Append("and a.SendDate >='" & StartDate & "' and a.SendDate <='" & EndDate & "' " & vbCrLf)
            If Status = "" Then
                sqlString.Append("and A.Status = '' " & vbCrLf)
            Else
                sqlString.Append("and A.Status = 'Y' " & vbCrLf)
            End If
            If MID <> "" Then
                sqlString.Append("and A.MID = '" & MID & "' " & vbCrLf)
            End If
            sqlString.Append("order By A.SendDate desc" & vbCrLf)


            command.CommandText = sqlString.ToString
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
#End Region



#Region "     更新 NFC_Notify_Msg "

    ''' <summary>
    ''' 查詢 查詢危險值通報處理情形回覆
    ''' </summary>
    ''' <param name="MID" >編號</param>
    ''' <param name="ReplyMsg" >處理情形</param>
    ''' <param name="Modified_User" >處理人員</param>
    ''' <param name="Modified_Time" >處理時間</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateNFCNotifyMsg(ByVal MID As String, ByVal ReplyMsg As String, ByVal Modified_User As String, _
                                       ByVal Modified_Time As String) As DataSet

        Dim ds As New DataSet

        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder

            If ReplyMsg.ToString = "" Then
                ReplyMsg = "已處理"
            End If

            sqlString.Append("UPDATE NFC_Notify_Msg " & vbCrLf)
            sqlString.Append("set ReplyMsg = '" & ReplyMsg & "', " & vbCrLf)
            If ReplyMsg <> "" Then '處理情形不為空，表示已處理，將類別的狀態改為Y(已處理)
                sqlString.Append("Status = 'Y', " & vbCrLf)
            End If
            sqlString.Append("Modified_User='" & Modified_User & "',  " & vbCrLf)
            sqlString.Append("Modified_Time='" & Modified_Time & "' " & vbCrLf)
            sqlString.Append("WHERE MID ='" & MID & "'  " & vbCrLf)

            command.CommandText = sqlString.ToString
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
