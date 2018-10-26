Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Text
Imports Syscom.Comm.Utility

Public Class SendMail
    Private UserName As String = "HOSP-Service"
    Private PassWord As String = "7C8B31AD41A4EFBED666E00B4701E19B"
    Private Sender As String = "HOSP-Service@syscom.com.tw"
    Private Shared instance As SendMail

    Private _cMail As New System.Net.Mail.SmtpClient("mail.syscom.com.tw", 25)
    Private _MailCredentials As New System.Net.NetworkCredential()
    Private _MailMessage As System.Net.Mail.MailMessage
    Private _Attachment As System.Net.Mail.Attachment

    Public Shared Function getInstance() As SendMail
        Try
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            If instance Is Nothing Then
                instance = New SendMail
            End If
            Return New SendMail
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub New()
        _MailCredentials = New System.Net.NetworkCredential(UserName, PassWordUtil.Decrypt(PassWord.Trim, PassWordUtil.getPrimaryKey))

    End Sub
    ''' <summary>
    ''' SendMail
    ''' <param name="Receiver">收件者</param>
    ''' <param name="Title">標題</param>
    ''' <param name="Message">內容</param>
    ''' <returns></returns>
    ''' </summary>
    Public Overloads Function SendMail(ByVal Receiver As String, ByVal Title As String, ByVal Message As String, Optional ByVal IsHtml As Boolean = False) As Int32
        Try

            _cMail.Credentials = _MailCredentials
            Dim mail As MailMessage = New MailMessage(Sender, Receiver)
            mail.Subject = Title
            mail.Body = Message
            mail.BodyEncoding = UTF8Encoding.UTF8
            mail.IsBodyHtml = IsHtml
            _cMail.Send(mail)

        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("發送失敗:" & ex.ToString, ex)
        End Try
        Return 1
    End Function
    ''' <summary>
    ''' 寄送MAIL 無附加檔案
    ''' </summary>
    ''' <param name="MainReceiver">主收件者</param>
    ''' <param name="CCUser">CC人員，以;分開</param>
    ''' <param name="Title">標題</param>
    ''' <param name="Message">內容</param>
    ''' <returns></returns>
    Public Overloads Function SendMail(ByVal MainReceiver As String, ByVal CCUser As String, ByVal Title As String, ByVal Message As String, Optional ByVal IsHtml As Boolean = False) As Int32
        Try
            Dim cc As String() = CCUser.Split(";")
            _cMail.Credentials = _MailCredentials
            Dim mail As MailMessage = New MailMessage(Sender, MainReceiver)
            For Each c As String In cc
                If c.Equals("") Then Continue For
                mail.CC.Add(c)
            Next
            mail.Subject = Title
            mail.Body = Message
            mail.BodyEncoding = UTF8Encoding.UTF8
            mail.IsBodyHtml = IsHtml
            _cMail.Send(mail)

        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("發送失敗:" & ex.ToString, ex)
        End Try
        Return 1
    End Function

    ''' <summary>
    ''' 寄送MAIL 附加檔案
    ''' </summary>
    ''' <param name="MainReceiver"></param>
    ''' <param name="CCUser"></param>
    ''' <param name="Title"></param>
    ''' <param name="Message"></param>
    ''' <returns></returns>
    Public Overloads Function SendMail(ByVal MainReceiver As String, ByVal CCUser As String, ByVal Title As String, ByVal Message As String, ByVal file As Stream, ByVal attName As String, Optional ByVal IsHtml As Boolean = False) As Int32
        Try
            Dim cc As String() = CCUser.Split(";")
            _cMail.Credentials = _MailCredentials

            Dim mail As MailMessage = New MailMessage(Sender, MainReceiver)
            For Each c As String In cc
                If c.Equals("") Then Continue For
                mail.CC.Add(c)
            Next
            _Attachment = New System.Net.Mail.Attachment(file, attName)
            mail.Attachments.Add(_Attachment)
            mail.Subject = Title
            mail.Body = Message
            'mail.AlternateViews.Add(rtfMessage)
            mail.BodyEncoding = UTF8Encoding.UTF8
            mail.IsBodyHtml = IsHtml
            _cMail.Send(mail)

        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg("發送失敗:" & ex.ToString, ex)
        End Try
        Return 1
    End Function

End Class
