Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.ComponentModel
Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class MailUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 寄送Email
    ''' </summary>
    ''' <param name="fromEmail">收件者</param>
    ''' <param name="fromName">收件者名稱</param>
    ''' <param name="toEmail">寄件者</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="body">內容</param>
    ''' <param name="Priority">重要性</param>
    ''' <param name="SMTP_Host">SMTP位址</param>
    ''' <param name="Port">埠</param>
    ''' <param name="Id">使用者帳號</param>
    ''' <param name="Password">使用者密碼</param>
    ''' <param name="MsgWindow">是否彈出寄送結果訊息視窗</param>
    ''' <param name="attachments">附加檔案的路徑(字串陣列)</param>
    ''' <remarks></remarks>
    Public Shared Sub Send_mail(ByVal fromEmail As String, ByVal fromName As String, ByVal toEmail As String, ByVal subject As String, ByVal body As String, ByVal Priority As MailPriority, ByVal SMTP_Host As String, ByVal Port As Integer, ByVal Id As String, ByVal Password As String, ByVal MsgWindow As Boolean, Optional ByVal attachments() As String = Nothing, Optional ByVal EnableSsl As Boolean = True, Optional ByVal IsBodyHtml As Boolean = False)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            ' Mail Message Setting 
            Dim from As New MailAddress(fromEmail, fromName, Encoding.UTF8)
            Dim mail As New MailMessage

            If toEmail.Contains(",") Then
                Dim mailToken() As String = toEmail.Split(",")
                For Each token As String In mailToken
                    mail.To.Add(token)
                Next
            Else
                mail.To.Add(toEmail)
            End If

            mail.From = [from]

            mail.Subject = subject
            mail.SubjectEncoding = Encoding.UTF8
            mail.Body = body
            mail.BodyEncoding = Encoding.UTF8

            mail.IsBodyHtml = IsBodyHtml
            mail.Priority = MailPriority.High

            '為了避免 Relay access denied
            mail.ReplyToList.Add([from])
            mail.Sender = [from]

            '附加檔案
            If attachments IsNot Nothing AndAlso attachments.Count > 0 Then
                For i As Integer = 0 To attachments.Count - 1
                    mail.Attachments.Add(New Mail.Attachment(attachments(i)))
                Next
            End If

            ' SMTP Setting 
            Dim client As New SmtpClient(SMTP_Host, Port)
            client.Credentials = New NetworkCredential(Id, Password)
            client.EnableSsl = EnableSsl

            ' Send Mail 
            client.SendAsync(mail, mail)

            If MsgWindow = True Then
                AddHandler client.SendCompleted, AddressOf client_SendCompleted
            End If

            ' Sent Compeleted Eevet
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Sub

    ''' <summary>
    ''' 完成郵寄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub client_SendCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If e.[Error] IsNot Nothing Then
                Windows.Forms.MessageBox.Show(e.[Error].ToString())
            Else
                Windows.Forms.MessageBox.Show("Message sent.")
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Sub

End Class