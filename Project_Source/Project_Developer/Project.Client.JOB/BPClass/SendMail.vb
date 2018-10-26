Imports System.Net.Mail

Public Class SendMail
    Private UserName As String = "134201"
    Private PassWord As String = "134201"
    Private Sender As String = "Kaiwen_Hsiao@syscom.com.tw"
    Private Shared instance As SendMail

    Private _cMail As New System.Net.Mail.SmtpClient("mail.syscom.com.tw")
    Private _MailCredentials As New System.Net.NetworkCredential(UserName, PassWord)
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

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Sender">寄件者</param>
    ''' <param name="Receiver">收件者</param>
    ''' <param name="Title">標題</param>
    ''' <param name="Message">內容</param>
    ''' <returns></returns>
    Public Overloads Function SendMail(ByVal Receiver As String, ByVal Title As String, ByVal Message As String) As Int32
        Try
            _cMail.Credentials = _MailCredentials
            Dim mail As MailMessage = New MailMessage(Sender, Receiver, Title, Message)
            _cMail.Send(mail)

        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' 寄送MAIL 無附加檔案
    ''' </summary>
    ''' <param name="Sender">寄件者</param>
    ''' <param name="MainReceiver">主收件者</param>
    ''' <param name="CCUser">CC人員，以;分開</param>
    ''' <param name="Title">標題</param>
    ''' <param name="Message">內容</param>
    ''' <returns></returns>
    Public Overloads Function SendMail(ByVal MainReceiver As String, ByVal CCUser As String, ByVal Title As String, ByVal Message As String) As Int32
        Try
            Dim cc As String() = CCUser.Split(";")
            _cMail.Credentials = _MailCredentials

            Dim mail As MailMessage = New MailMessage(Sender, MainReceiver, Title, Message)
            For Each c As String In cc
                If c.Equals("") Then Continue For
                mail.CC.Add(c)
            Next
            _cMail.Send(mail)

        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function

    ''' <summary>
    ''' 寄送MAIL 附加檔案
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="MainReceiver"></param>
    ''' <param name="CCUser"></param>
    ''' <param name="Title"></param>
    ''' <param name="Message"></param>
    ''' <param name="FilePath">檔案路徑，多個附件請以;號隔開</param>
    ''' <returns></returns>
    Public Overloads Function SendMail(ByVal MainReceiver As String, ByVal CCUser As String, ByVal Title As String, ByVal Message As String, ByVal FilePath As String) As Int32
        Try
            Dim cc As String() = CCUser.Split(";")
            Dim path As String() = FilePath.Split(";")
            _cMail.Credentials = _MailCredentials

            Dim mail As MailMessage = New MailMessage(Sender, MainReceiver, Title, Message)
            For Each c As String In cc
                If c.Equals("") Then Continue For
                mail.CC.Add(c)
            Next
            For Each f As String In path
                _Attachment = New System.Net.Mail.Attachment(f)
                mail.Attachments.Add(_Attachment)
            Next
            _cMail.Send(mail)

        Catch ex As Exception
            Return 1
        End Try
        Return 0
    End Function

End Class
