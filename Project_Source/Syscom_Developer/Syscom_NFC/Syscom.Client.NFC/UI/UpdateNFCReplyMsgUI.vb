'/*
'*****************************************************************************
'*
'*    Page/Class Name:  危險值通報處理情形回覆
'*              Title:	危險值通報處理情形回覆
'*        Description:	1.修改 2.查詢 3.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Tony.Chu
'*        Create Date:	2017-03-21
'*      Last Modifier:	Tony.Chu
'*   Last Modify Date:	2017-03-21
'*
'*****************************************************************************
'*/

Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL
Imports Microsoft.Office.Interop
Imports Syscom.Comm.EXP

Public Class UpdateNFCReplyMsgUI


#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private currentUserId As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     使用的Instance宣告 "

    Private nfcManager As NfcServiceManager = NfcServiceManager.getInstance

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Margaret.Tsai on 2016-07-06</remarks>
    Private Sub LoadServiceManager()

        Try

            nfcManager = NfcServiceManager.getInstance

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Tony.Chu on 2017-03-21</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Tony.Chu on 2017-03-21</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region

#Region "Global Param"

    Dim initDS As DataSet
    Dim dgvDS As DataSet
    Dim strSortAble As String = "4,7"

#End Region

#End Region


#Region "     初始化 - 顯示UI "

#Region "    顯示UI畫面"
    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Tony.Chu on 2017-03-21</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()


            '預設值
            initialUpdateNFCReplyMsgUI()


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "    UI初始化"

    Private Sub initialUpdateNFCReplyMsgUI()

        cbo_Status.Items.Add("未處理") '""  
        cbo_Status.Items.Add("已處理") '"Y"
        cbo_Status.SelectedIndex = 0   '預設為未處理


        Dim pDS As New DataSet '抓片語
        Dim client As Servicefactory.NfcServiceManager = Servicefactory.NfcServiceManager.getInstance
        pDS = client.getNfcPhrase("A")

        If pDS.Tables(0).Rows.Count > 0 Then
            For i = 0 To pDS.Tables(0).Rows.Count - 1
                Cbo_Phrase.Items.Add(pDS.Tables(0).Rows(i).Item("NFC_Phrase_Name"))
            Next
        End If

        Dim dtp_StartDate As String = ""
        Dim dtp_EndDate As String = ""

    End Sub

#End Region


#End Region


#Region "     按鈕事件 "

#Region "     查詢 "

    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click


        If (CheckFields()) Then '檢查必填欄位

            Exit Sub

        End If


        Dim ReplyMsg As String
        Dim Status As String
        Dim Recipient As String
        Dim MID As String

        If cbo_Status.SelectedIndex = 0 Then      '類別 未處理
            Status = ""
        ElseIf cbo_Status.SelectedIndex = 1 Then  '類別 已處理
            Status = "Y"
        End If


        If tcq_Recipient.getCode() <> "" Then
            Recipient = tcq_Recipient.getCode()
        End If

        Dim queryDS As DataSet = nfcManager.QueryNFCNotifyMsg(MID, Recipient, dtp_StartDate.GetUsDateStr + " 00:00", dtp_EndDate.GetUsDateStr + " 23:59", Status)
        dgvDS = New DataSet


        dgvDS.Tables.Add()
        dgvDS.Tables(0).Columns.Add("MID")
        dgvDS.Tables(0).Columns.Add("MsgBody")
        dgvDS.Tables(0).Columns.Add("SendDate")
        dgvDS.Tables(0).Columns.Add("Recipient")
        dgvDS.Tables(0).Columns.Add("ReplyMsg")
        dgvDS.Tables(0).Columns.Add("Modified_User")


        If queryDS.Tables(0).Rows.Count > 0 Then

            For i As Integer = 0 To queryDS.Tables(0).Rows.Count - 1

                dgvDS.Tables(0).Rows.Add()
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("MID") = queryDS.Tables(0).Rows(i).Item("MID").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("MsgBody") = queryDS.Tables(0).Rows(i).Item("MsgBody").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("SendDate") = DateUtil.TransDateToROC(CDate(queryDS.Tables(0).Rows(i).Item("SendDate"))) & " " & CDate(queryDS.Tables(0).Rows(i).Item("SendDate")).ToString("HH:mm")
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Recipient") = queryDS.Tables(0).Rows(i).Item("Recipient").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("ReplyMsg") = queryDS.Tables(0).Rows(i).Item("ReplyMsg").ToString.Trim
                dgvDS.Tables(0).Rows(dgvDS.Tables(0).Rows.Count - 1).Item("Modified_User") = queryDS.Tables(0).Rows(i).Item("Modified_User").ToString.Trim

            Next
        Else
            dgvDS = New DataSet
            MsgBox("查無資料")
        End If

        dgv.Initial(dgvDS)
        dgv.uclHeaderText = "編號,簡訊內容,發送日期,開單醫師,處理情形,處理人員"
        dgv.uclColumnWidth = "100,470,120,80,80,80"
        strSortAble = "0,1,2,3,4,5"
        dgv.uclSortColIndex = strSortAble

    End Sub

#End Region

#Region "     清除 "

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click


        tcq_Recipient.SetText("")
        dtp_StartDate.SetValue("")
        dtp_EndDate.SetValue("")
        Cbo_Phrase.Text = ""


        Me.txt_Subject.Text = "" '簡訊內容
        Me.Txt_DateTime.Text = "" '發送日期
        Me.Txt_EmployeeName.Text = "" '開單醫師
        Me.txt_ReplyMsg.Text = "" '處理情形

        dgvDS = New DataSet
        dgv.Initial(dgvDS)
    End Sub

#End Region

#Region "     確認(更新) "

    Private Sub Btn_Enter_click(sender As Object, e As EventArgs) Handles btn_Enter.Click

        If (CheckFields()) Then '檢查必填欄位

            Exit Sub

        End If

        Try


            Dim queryDs As DataSet

            '被點選的資料列大於零，才執行動作
            If dgv.CurrentCellAddress.Y >= 0 Then


                Dim Modified_Time = Format(Now, "yyyy/MM/dd HH:mm:ss")  '修改時間
                Dim ReplyMsg = txt_ReplyMsg.Text  '處理情形
                Dim Modified_User = currentUserId '處理人員
                Dim MID = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("MID").Value) '簡訊內容

                'Update 資料
                queryDs = nfcManager.UpdateNFCNotifyMsg(MID, ReplyMsg, Modified_User, Modified_Time)


                Me.txt_Subject.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("MsgBody").Value) '簡訊內容
                Me.Txt_DateTime.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("SendDate").Value) '發送日期
                Me.txt_ReplyMsg.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("ReplyMsg").Value) '處理情形

                Dim status As String

                If ReplyMsg <> "" Then
                    status = "Y" '類別 已處理
                    cbo_Status.SelectedIndex = 1
                Else
                    status = "" '類別 未處理
                    cbo_Status.SelectedIndex = 0
                End If


                Dim Recipient As String
                If tcq_Recipient.getCode() <> "" Then
                    Recipient = tcq_Recipient.getCode()
                End If

                '更新後再次查詢
                Dim queryDS1 As DataSet = nfcManager.QueryNFCNotifyMsg(MID, Recipient, dtp_StartDate.GetUsDateStr + " 00:00", dtp_EndDate.GetUsDateStr + " 23:59", status)


                If queryDS1.Tables(0).Rows.Count > 0 Then

                    dgvDS = New DataSet

                    dgvDS.Tables.Add()
                    dgvDS.Tables(0).Columns.Add("MID")
                    dgvDS.Tables(0).Columns.Add("MsgBody")
                    dgvDS.Tables(0).Columns.Add("SendDate")
                    dgvDS.Tables(0).Columns.Add("Recipient")
                    dgvDS.Tables(0).Columns.Add("ReplyMsg")
                    dgvDS.Tables(0).Columns.Add("Modified_User")


                    dgvDS.Tables(0).Rows.Add()
                    dgvDS.Tables(0).Rows(0).Item("MID") = queryDS1.Tables(0).Rows(0).Item("MID").ToString.Trim
                    dgvDS.Tables(0).Rows(0).Item("MsgBody") = queryDS1.Tables(0).Rows(0).Item("MsgBody").ToString.Trim
                    dgvDS.Tables(0).Rows(0).Item("SendDate") = DateUtil.TransDateToROC(CDate(queryDS1.Tables(0).Rows(0).Item("SendDate"))) & " " & CDate(queryDS1.Tables(0).Rows(0).Item("SendDate")).ToString("HH:mm")
                    dgvDS.Tables(0).Rows(0).Item("Recipient") = queryDS1.Tables(0).Rows(0).Item("Recipient").ToString.Trim
                    dgvDS.Tables(0).Rows(0).Item("ReplyMsg") = queryDS1.Tables(0).Rows(0).Item("ReplyMsg").ToString.Trim
                    If dgvDS.Tables(0).Rows(0).Item("ReplyMsg") = "" Or dgvDS.Tables(0).Rows(0).Item("ReplyMsg") = "unknow" Then
                        dgvDS.Tables(0).Rows(0).Item("Modified_User") = ""
                    Else
                        dgvDS.Tables(0).Rows(0).Item("Modified_User") = queryDS1.Tables(0).Rows(0).Item("Modified_User").ToString.Trim
                    End If

                    txt_ReplyMsg.Text = queryDS1.Tables(0).Rows(0).Item("ReplyMsg").ToString.Trim

                    dgv.Initial(dgvDS)
                    dgv.uclHeaderText = "編號,簡訊內容,發送日期,開單醫師,處理情形,處理人員"
                    dgv.uclColumnWidth = "100,470,120,80,80,80"
                    strSortAble = "0,1,2,3,4,5"
                    dgv.uclSortColIndex = strSortAble

                End If


            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try


    End Sub

#End Region


#End Region

#Region "     檢查必填欄位 "

    Private Function CheckFields() As Boolean
        Try
            Dim IsError As Boolean = False

            If (dtp_StartDate.GetUsDateStr.Length = 0) Then '發送日期(起)
                IsError = True
                dtp_StartDate.BackColor = Color.White
                MsgBox("請填寫發送日期(起)")
            End If

            If (dtp_EndDate.GetUsDateStr.Length = 0) Then  '發送日期(迄)
                IsError = True
                dtp_EndDate.BackColor = Color.White
                MsgBox("請填寫發送日期(迄)")
            End If

            If (tcq_Recipient.Text.Length = 0) Then  '接收人員
                IsError = True
                tcq_Recipient.BackColor = Color.White
                MsgBox("請填寫接收人員")
            End If

            Return IsError

        Catch ex As Exception


            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Function

#End Region

#Region "     資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Hsiao.Kaiwen on 2015-9-6</remarks>
    Public Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick

        Try

            '被點選的資料列大於零，才執行動作
            If dgv.CurrentCellAddress.Y >= 0 Then

                Me.txt_Subject.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("MsgBody").Value) '簡訊內容
                Me.Txt_DateTime.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("SendDate").Value) '發送日期
                Me.Txt_EmployeeName.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("Recipient").Value) '開單醫師
                Me.txt_ReplyMsg.Text = StringUtil.nvl(dgv.Rows(dgv.CurrentCellAddress.Y).Cells("ReplyMsg").Value) '處理情形

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region

#Region "   片語選擇 "
    Private Sub Cbo_Phrase_Change(sender As Object, e As EventArgs) Handles Cbo_Phrase.SelectedIndexChanged

        If Cbo_Phrase.SelectedIndex >= 0 Then
            txt_ReplyMsg.Text = Cbo_Phrase.Text & txt_ReplyMsg.Text
        Else
            txt_ReplyMsg.Text = txt_ReplyMsg.Text
        End If

    End Sub
#End Region

End Class