'/*
'*****************************************************************************
'*
'*    Page/Class Name:  訊息顯示共通介面
'*              Title:	UCLMessageHandlingUI
'*        Description:	可用方法說明
'*                      showError   ：顯示錯誤訊息視窗
'*                      showWarn    ：顯示警告訊息視窗
'*                      showQuestion：顯示問題訊息視窗(因有回傳值問題，不再由此畫面顯示，改以MessageBox處理)
'*                      showInfo    ：顯示資訊訊息視窗
'*                      傳入參數說明
'*                      inErrorCode(訊息代碼)：依標準規範定義
'*                      inMessage(訊息說明)
'*                      inDetail(詳細錯誤)
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan
'*        Create Date:	2010-01-15
'*      Last Modifier:	Alan
'*   Last Modify Date:	2010-01-15
'*
'*****************************************************************************
'*/

Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.ComponentModel
Imports Syscom.Comm.BASE
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM

Public Class UCLMessageHandlingUI

    Private gblErrorType As STATUS
    Private gblErrorCode As String
    Private gblMessage As String
    Private gblDetail As String
    Private gblMailDetail As String
    Private p As New System.Diagnostics.Process

    ''' <summary>
    ''' 列舉訊息狀態
    ''' </summary>
    ''' <remarks></remarks>
    Enum STATUS
        ERR
        WARN
        QUESTION
        INFO
    End Enum

    ''' <summary>
    ''' 阻止無參數宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    ''' <summary>
    ''' 須參數傳入宣告(WCF專用)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal inErrorType As STATUS, ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        gblErrorType = inErrorType
        gblErrorCode = inErrorCode
        gblMessage = inMessage
        gblDetail = inDetail

        initial()
    End Sub

    ''' <summary>
    ''' 須參數傳入宣告
    ''' </summary>
    ''' <param name="inErrorType"></param>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <param name="inDetail"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal inErrorType As STATUS, ByVal inErrorCode As String, ByVal inMessage As String(), Optional ByVal inDetail As String = "")
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        gblErrorType = inErrorType
        gblErrorCode = inErrorCode

        If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
            gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
        Else
            gblMessage = MessageValueObject.getMessageValue(inErrorCode)
        End If

        gblDetail = inDetail

        initial()
    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initial()
        Try
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Me.Size = New Drawing.Size(370, 230)
            btn_OK.Location = New Drawing.Point(270, 160)
            Label2.Visible = False

            '根據語言 設定對應的 繁體/簡體 文字
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese
                    Me.Text = "訊息代碼：" & gblErrorCode
                    Select Case gblErrorType
                        Case STATUS.ERR
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressError
                            Label1.Text = "錯誤"
                            If gblDetail.Trim = "" Then
                                TabControl1.Controls.Remove(TabControl1.TabPages(1))
                            End If
                        Case STATUS.WARN
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressWarn
                            Label1.Text = "警告"
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                        Case STATUS.QUESTION
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressQuestion
                            Label1.Text = "問題"
                            TabPage2.IsAccessible = False
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                        Case STATUS.INFO
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressInfo
                            Label1.Text = "資訊"
                            TabPage2.IsAccessible = False
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                    End Select

                    If gblDetail.Trim = "" Then
                        btn_DetailMsg.Visible = False
                        PictureBox1.Visible = False
                        PictureBox2.Visible = False
                        gblMailDetail = "錯誤訊息：" & vbCrLf & gblMessage & vbCrLf
                    Else
                        gblMailDetail = "錯誤訊息：" & vbCrLf & gblMessage & vbCrLf & vbCrLf & "詳細內容：" & vbCrLf & gblDetail
                    End If

                    TextBox2.Text = "錯誤訊息通知：" & gblErrorCode
                Case AppConfigUtil.Language.SimplifiedChinese
                    Me.Text = "信息代码：" & gblErrorCode
                    Select Case gblErrorType
                        Case STATUS.ERR
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressError
                            Label1.Text = "错误"
                            If gblDetail.Trim = "" Then
                                TabControl1.Controls.Remove(TabControl1.TabPages(1))
                            End If
                        Case STATUS.WARN
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressWarn
                            Label1.Text = "警告"
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                        Case STATUS.QUESTION
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressQuestion
                            Label1.Text = "问题"
                            TabPage2.IsAccessible = False
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                        Case STATUS.INFO
                            PictureBox3.Image = Syscom.Client.UCL.My.Resources.Resources.ProgressInfo
                            Label1.Text = "资讯"
                            TabPage2.IsAccessible = False
                            TabControl1.Controls.Remove(TabControl1.TabPages(1))
                    End Select

                    If gblDetail.Trim = "" Then
                        btn_DetailMsg.Visible = False
                        PictureBox1.Visible = False
                        PictureBox2.Visible = False
                        gblMailDetail = "错误信息：" & vbCrLf & gblMessage & vbCrLf
                    Else
                        gblMailDetail = "错误信息：" & vbCrLf & gblMessage & vbCrLf & vbCrLf & "详细内容：" & vbCrLf & gblDetail
                    End If

                    TextBox2.Text = "错误讯息通知：" & gblErrorCode
            End Select


            RichTextBox1.Text = gblMessage.Trim

            RichTextBox2.Text = gblDetail.Trim
            RichTextBox2.Visible = False
            RichTextBox3.Visible = False

            KeyPreview = True

            If TextBox1.Text.Trim = "" Then
                '預設收件者
            End If

            '依解析度等比例放大
            If UCLFormUtil.isResizeable Then
                Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                UCLFormUtil.ReDrawForm(Me)
                UCLFormUtil.ReSetLocToScreenCenter(Me)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 明細內容被點選
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-23</remarks>
    Private Sub btn_DetailMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DetailMsg.Click
        If PictureBox1.Visible Then
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            Me.Size = New Drawing.Size(370, 500)
            btn_OK.Location = New Drawing.Point(136, 430)
            RichTextBox2.Visible = True
        Else
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Me.Size = New Drawing.Size(370, 230)
            btn_OK.Location = New Drawing.Point(270, 160)
            RichTextBox2.Visible = False

        End If
    End Sub

    ''' <summary>
    ''' 切換 Tab 後的相應動作
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-23</remarks>
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            Me.Size = New Drawing.Size(370, 230)
            btn_DetailMsg.Visible = True
            btn_OK.Location = New Drawing.Point(270, 160)
            Label2.Visible = False


            '根據語言 設定對應的 繁體/簡體 文字
            Select Case AppConfigUtil.AppLanguage

                Case AppConfigUtil.Language.TraditionalChinese

                    btn_OK.Text = "F12-確定"

                Case AppConfigUtil.Language.SimplifiedChinese

                    btn_OK.Text = "F12-确定"

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
            btn_OK.Location = New Drawing.Point(136, 430)
            Label2.Visible = True

            '根據語言 設定對應的 繁體/簡體 文字
            Select Case AppConfigUtil.AppLanguage

                Case AppConfigUtil.Language.TraditionalChinese

                    btn_OK.Text = "F12-傳送"

                Case AppConfigUtil.Language.SimplifiedChinese

                    btn_OK.Text = "F12-传送"

            End Select


            RichTextBox2.Visible = False
            RichTextBox3.Visible = True

            RichTextBox3.Text = gblMailDetail

        End If
    End Sub

    ''' <summary>
    ''' 確定被點選後的相應動作
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-23</remarks>
    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click


        If TabControl1.SelectedIndex = 1 Then
            If TextBox1.Text.Trim <> "" Then
                '取得SMTP設定資料
                Dim uclOW As IUclServiceManager = UclServiceManager.getInstance
                Dim pvtSMTPDS As DataSet
                Dim pvtSMTP_Address As String
                Dim pvtSMTP_ID As String
                Dim pvtSMTP_Password As String
                Dim pvtSMTP_Port As String
                Dim pvtSMTP_SSL_Flag As Boolean

                pvtSMTPDS = uclOW.querySMTPData()

                If pvtSMTPDS IsNot Nothing AndAlso pvtSMTPDS.Tables(0) IsNot Nothing AndAlso pvtSMTPDS.Tables(0).Rows.Count = 5 Then
                    pvtSMTP_Address = pvtSMTPDS.Tables(0).Rows(0).Item("Config_Value").ToString.Trim
                    pvtSMTP_ID = pvtSMTPDS.Tables(0).Rows(1).Item("Config_Value").ToString.Trim
                    pvtSMTP_Password = pvtSMTPDS.Tables(0).Rows(2).Item("Config_Value").ToString.Trim
                    pvtSMTP_Port = pvtSMTPDS.Tables(0).Rows(3).Item("Config_Value").ToString.Trim
                    If pvtSMTPDS.Tables(0).Rows(4).Item("Config_Value").ToString.Trim = "Y" Then
                        pvtSMTP_SSL_Flag = True
                    Else
                        pvtSMTP_SSL_Flag = False
                    End If


                    Dim pvtAttachments As String() = {}
                    sendMail(pvtSMTP_ID, pvtSMTP_ID, TextBox1.Text.Trim, TextBox2.Text.Trim, RichTextBox3.Text.Trim, Net.Mail.MailPriority.Normal, _
                                                        pvtSMTP_Address, pvtSMTP_Port, pvtSMTP_ID, pvtSMTP_Password, pvtSMTP_SSL_Flag, True)
                Else

                    '根據語言 設定對應的 繁體/簡體 文字
                    Select Case AppConfigUtil.AppLanguage

                        Case AppConfigUtil.Language.TraditionalChinese

                            MessageHandling.ShowErrorMsg("CMMCMMD009", New String() {"資料庫SMTP設定"}, "")

                        Case AppConfigUtil.Language.SimplifiedChinese

                            MessageHandling.ShowErrorMsg("CMMCMMD009", New String() {"数据库SMTP设定"}, "")

                    End Select



                End If

                Me.Dispose()

            Else

                '根據語言 設定對應的 繁體/簡體 文字
                Select Case AppConfigUtil.AppLanguage

                    Case AppConfigUtil.Language.TraditionalChinese

                        MessageHandling.ShowErrorMsg("CMMCMMB101", New String() {"收件者"}, "")

                    Case AppConfigUtil.Language.SimplifiedChinese

                        MessageHandling.ShowErrorMsg("CMMCMMB101", New String() {"收件者"}, "")

                End Select

            End If

        Else
            Me.Dispose()
        End If



    End Sub

    Public Shared Sub sendMail(ByVal fromEmail As String, ByVal fromName As String, ByVal toEmail As String, ByVal subject As String, ByVal body As String, ByVal Priority As MailPriority, ByVal SMTP_Host As String, ByVal Port As Integer, ByVal Id As String, ByVal Password As String, ByVal EnableSSL As Boolean, ByVal MsgWindow As Boolean)
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
            client.EnableSsl = EnableSSL

            ' Send Mail 
            client.SendAsync(mail, mail)


            ' Sent Compeleted Eevet 
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 明細內容被點選
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        btn_DetailMsg_Click(sender, e)
    End Sub

    ''' <summary>
    ''' 明細內容被點選
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        btn_DetailMsg_Click(sender, e)
    End Sub

    ''' <summary>
    ''' 熱鍵
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLMessageHandlingUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                btn_OK_Click(sender, e)
        End Select
    End Sub

    ''' <summary>
    ''' 開啟瀏覽器
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RichTextBox1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        p = System.Diagnostics.Process.Start("IExplore.exe", e.LinkText)
    End Sub

End Class
