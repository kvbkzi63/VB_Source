'2010-01-15 Add By Alan
'程式名稱：訊息顯示共通介面
'傳入參數說明
'inErrorCode(訊息代碼)：依標準規範定義
'inMessage(訊息說明)
'inDetail(詳細錯誤)
'inReceiver(收件人)：若為空白，則寄發至程式中預設之收件者
 
Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.ComponentModel
Imports Syscom.Comm.BASE

Public Class MessageHandlingUI
    Dim gblErrorType As String
    Dim gblErrorCode As String
    Dim gblMessage As String
    Dim gblDetail As String
    Dim gblReceiver As String
    Dim gblMailDetail As String
    Public Shared ReadOnly ERR = "E"
    Public Shared ReadOnly WARN = "W"
    Public Shared ReadOnly QUESTION = "Q"
    Public Shared ReadOnly INFO_SHOW_MSGBOX = "I"

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        SetControlByLanguage()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "     根據語言設定控制項的名稱 "

    ''' <summary>
    ''' 根據語言設定控制項的名稱
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-1</remarks>
    Private Sub SetControlByLanguage()

        Try

            Select Case AppConfigUtil.AppLanguage

                '簡體中文
                Case AppConfigUtil.Language.SimplifiedChinese

                    'lbl_Info_Error.Text = "错误"

                    lbl_Mail_Reciever.Text = "收件者"

                    lbl_Mail_Title.Text = "主旨"

                    lbl_Content.Text = "内容"

                    btn_Confirm.Text = "F12-确定"

                    btn_DetailMsg.Text = "     详细错误"

                    tbp_Msg.Text = "信息"

                    tbp_Info.Text = "通知"

                    '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    'lbl_Info_Error.Text = "錯誤"

                    lbl_Mail_Reciever.Text = "收件者"

                    lbl_Mail_Title.Text = "主旨"

                    lbl_Content.Text = "內容"

                    btn_Confirm.Text = "F12-確定"

                    btn_DetailMsg.Text = "     詳細錯誤"

                    tbp_Msg.Text = "訊息"

                    tbp_Info.Text = "通知"


            End Select

          

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region


    Sub showError(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String, ByVal inReceiver As String)
        setInit(ERR, inErrorCode, inMessage, inDetail, inReceiver)
    End Sub

    Sub showWarn(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inReceiver As String)
        setInit(WARN, inErrorCode, inMessage, "", inReceiver)
    End Sub

    Sub showQuestion(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inReceiver As String)
        setInit(QUESTION, inErrorCode, inMessage, "", inReceiver)
    End Sub

    Sub showInfo(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inReceiver As String)
        setInit(INFO_SHOW_MSGBOX, inErrorCode, inMessage, "", inReceiver)
    End Sub

    Private Sub setInit(ByVal inErrorType As String, ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String, ByVal inReceiver As String)
        gblErrorType = inErrorType
        gblErrorCode = inErrorCode
        gblMessage = inMessage
        gblDetail = inDetail
        gblReceiver = inReceiver

        PictureBox1.Visible = True
        PictureBox2.Visible = False
        Me.Size = New Drawing.Size(370, 230)
        btn_Confirm.Location = New Drawing.Point(270, 160)
        lbl_Content.Visible = False

        SetControlByLanguage()


        Select Case AppConfigUtil.AppLanguage

            '簡體中文
            Case AppConfigUtil.Language.SimplifiedChinese

                Me.Text = "错误编号：" & gblErrorType & "-" & gblErrorCode

                '繁體中文
            Case AppConfigUtil.Language.TraditionalChinese

                Me.Text = "錯誤編號：" & gblErrorType & "-" & gblErrorCode

        End Select

        Select Case gblErrorType
            Case "E"
                PictureBox3.Image = My.Resources.Resources.ProgressError.ToBitmap

                Select Case AppConfigUtil.AppLanguage

                    '簡體中文
                    Case AppConfigUtil.Language.SimplifiedChinese

                        lbl_Info_Error.Text = "错误"

                        '繁體中文
                    Case AppConfigUtil.Language.TraditionalChinese

                        lbl_Info_Error.Text = "錯誤"

                End Select
 
            Case "W"
                PictureBox3.Image = My.Resources.Resources.ProgressWarn.ToBitmap

                Select Case AppConfigUtil.AppLanguage

                    '簡體中文
                    Case AppConfigUtil.Language.SimplifiedChinese

                        lbl_Info_Error.Text = "警告"

                        '繁體中文
                    Case AppConfigUtil.Language.TraditionalChinese

                        lbl_Info_Error.Text = "警告"

                End Select

            Case "Q"
                PictureBox3.Image = My.Resources.Resources.ProgressQuestion.ToBitmap

                Select Case AppConfigUtil.AppLanguage

                    '簡體中文
                    Case AppConfigUtil.Language.SimplifiedChinese

                        lbl_Info_Error.Text = "问题"

                        '繁體中文
                    Case AppConfigUtil.Language.TraditionalChinese

                        lbl_Info_Error.Text = "問題"

                End Select

            Case "I"
                PictureBox3.Image = My.Resources.Resources.ProgressInfo

                Select Case AppConfigUtil.AppLanguage

                    '簡體中文
                    Case AppConfigUtil.Language.SimplifiedChinese

                        lbl_Info_Error.Text = "资讯"

                        '繁體中文
                    Case AppConfigUtil.Language.TraditionalChinese

                        lbl_Info_Error.Text = "資訊"

                End Select

        End Select

        RichTextBox1.Text = gblMessage.Trim

        RichTextBox2.Text = gblDetail.Trim
        RichTextBox2.Visible = False
        RichTextBox3.Visible = False

        TextBox1.Text = gblReceiver.Trim
        If TextBox1.Text.Trim = "" Then
            '預設收件者
        End If

        If gblDetail.Trim = "" Then
            btn_DetailMsg.Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = False

            Select Case AppConfigUtil.AppLanguage

                '簡體中文
                Case AppConfigUtil.Language.SimplifiedChinese

                    gblMailDetail = "错误讯息：" & vbCrLf & gblMessage & vbCrLf

                    '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    gblMailDetail = "錯誤訊息：" & vbCrLf & gblMessage & vbCrLf

            End Select

        Else

            Select Case AppConfigUtil.AppLanguage

                '簡體中文
                Case AppConfigUtil.Language.SimplifiedChinese

                    gblMailDetail = "错误讯息：" & vbCrLf & gblMessage & vbCrLf & vbCrLf & "详细内容：" & vbCrLf & gblDetail

                    '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    gblMailDetail = "錯誤訊息：" & vbCrLf & gblMessage & vbCrLf & vbCrLf & "詳細內容：" & vbCrLf & gblDetail

            End Select

        End If

        Select Case AppConfigUtil.AppLanguage

            '簡體中文
            Case AppConfigUtil.Language.SimplifiedChinese

                TextBox2.Text = "错误讯息通知：" & gblErrorType & "-" & gblErrorCode

                '繁體中文
            Case AppConfigUtil.Language.TraditionalChinese

                TextBox2.Text = "錯誤訊息通知：" & gblErrorType & "-" & gblErrorCode

        End Select

      

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DetailMsg.Click
        If PictureBox1.Visible Then
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            Me.Size = New Drawing.Size(370, 500)
            btn_Confirm.Location = New Drawing.Point(136, 430)
            RichTextBox2.Visible = True
        Else
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Me.Size = New Drawing.Size(370, 230)
            btn_Confirm.Location = New Drawing.Point(270, 160)
            RichTextBox2.Visible = False

        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Me.Size = New Drawing.Size(370, 230)
            btn_DetailMsg.Visible = True
            btn_Confirm.Location = New Drawing.Point(270, 160)
            lbl_Content.Visible = False


            Select Case AppConfigUtil.AppLanguage

                '簡體中文
                Case AppConfigUtil.Language.SimplifiedChinese

                    btn_Confirm.Text = "F12-确定"

                    '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    btn_Confirm.Text = "F12-確定"

            End Select


            gblMailDetail = RichTextBox3.Text
            RichTextBox3.Visible = False
            RichTextBox2.Visible = False

            If gblDetail.Trim = "" Then
                btn_DetailMsg.Visible = False
                PictureBox1.Visible = False
                PictureBox2.Visible = False
            End If

        Else
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            btn_DetailMsg.Visible = False
            Me.Size = New Drawing.Size(370, 500)
            btn_Confirm.Location = New Drawing.Point(136, 430)
            lbl_Content.Visible = True


            Select Case AppConfigUtil.AppLanguage

                '簡體中文
                Case AppConfigUtil.Language.SimplifiedChinese

                    btn_Confirm.Text = "F12-传送"

                    '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    btn_Confirm.Text = "F12-傳送"

            End Select

            RichTextBox2.Visible = False
            RichTextBox3.Visible = True

            RichTextBox3.Text = gblMailDetail

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click

        If TabControl1.SelectedIndex = 1 Then
            '傳送E-Mail
            Dim pvtAttachments As String() = {}
            sendMail("syscom_ncku@pchome.com.tw", "nckuHis", TextBox1.Text.Trim, TextBox2.Text.Trim, RichTextBox3.Text.Trim, Net.Mail.MailPriority.Normal, _
                                                "smtp.pchome.com.tw", 25, "syscom_ncku@pchome.com.tw", "nckuHis", True)

        End If

        Me.Dispose()

    End Sub

    Public Shared Sub sendMail(ByVal fromEmail As String, ByVal fromName As String, ByVal toEmail As String, ByVal subject As String, ByVal body As String, ByVal Priority As MailPriority, ByVal SMTP_Host As String, ByVal Port As Integer, ByVal Id As String, ByVal Password As String, ByVal MsgWindow As Boolean)
        Try
            ' Mail Message Setting 
            Dim from As New MailAddress(fromEmail, fromName, Encoding.UTF8)

            Dim mail As New MailMessage(from, New MailAddress(toEmail))

            mail.Subject = subject
            mail.SubjectEncoding = Encoding.UTF8

            mail.Body = body
            mail.BodyEncoding = Encoding.UTF8
            mail.IsBodyHtml = False
            mail.Priority = MailPriority.High

            ' SMTP Setting 
            Dim client As New SmtpClient()
            client.Host = SMTP_Host
            client.Port = Port
            client.Credentials = New NetworkCredential(Id, Password)
            client.EnableSsl = False

            ' Send Mail 
            client.SendAsync(mail, mail)


            ' Sent Compeleted Eevet 
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Button1_Click(sender, e)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Button1_Click(sender, e)
    End Sub
End Class
