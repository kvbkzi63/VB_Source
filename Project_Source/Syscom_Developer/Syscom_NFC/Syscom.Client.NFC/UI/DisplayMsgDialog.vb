Imports System.Windows.Forms
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP

Public Class DisplayMsgDialog

    Sub New(ByVal row As DataRow, ByVal ds As DataSet)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        '初始化片語
        If Not ds Is Nothing Then
            For Each pRow As DataRow In ds.Tables("NFC_Phrase").Rows
                cbo_Phrase.Items.Add(pRow.Item("NFC_Phrase_Name").ToString.Trim)
            Next
            cbo_Phrase.SelectedIndex = 0
        End If


        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        txt_ReplayMsg.Text = row.Item("ReplyMsg").ToString.Trim
        MIDs.Text = row.Item("MID")
        SendDates.Text = DateUtil.TransDateToROC(CDate(row.Item("SendDate"))) & " " & Format(row.Item("SendDate"), "HH:mm")
        'txt_Type.Text = IIf(row.Item("Employee_Name") Is DBNull.Value, "", row.Item("Employee_Name"))
        '複製要顯示的部分               
        Dim msgType = row.Item("Group_Type").ToString.Trim '類別
        Dim _type = row.Item("Type").ToString.Trim   '型態
        Dim _specFlag As String = row.Item("Spec_Flag").ToString.Trim

        Types.Text = convertMsgType(msgType)
        Subjects.Text = row.Item("Subject")
        MsgBodys.Text = row.Item("MsgBody")
        txt_Type.Text = convertType(_type)

        '判斷是否 危險值通報 才顯示片語點選
        If row.Item("Subject").ToString = "危險值通報" Then
            grp_Phrase.Visible = True
        Else
            grp_Phrase.Visible = False
        End If

        'Create_Users.Text = row.Item("sendUser")
        Create_Users.Text = IIf(row.Item("sendUser") Is DBNull.Value, "", row.Item("sendUser"))
        Start_Times.Text = IIf(row.Item("Start_Time") Is DBNull.Value, "無", DateUtil.TransDateToROC(CDate(row.Item("Start_Time"))) & " " & Format(row.Item("Start_Time"), "HH:mm"))
        End_Times.Text = IIf(row.Item("End_Time") Is DBNull.Value, "無", DateUtil.TransDateToROC(CDate(row.Item("End_Time"))) & " " & Format(row.Item("End_Time"), "HH:mm"))
        If row.Item("ReplyMsg").ToString <> "" Then
            grp_ReplayMSG.Text = "訊息已經回覆了!"
            grp_ReplayMSG.ForeColor = Color.Red
            grp_ReplayMSG.Enabled = False
        Else
            grp_ReplayMSG.Text = ""
            grp_ReplayMSG.Enabled = True
        End If
        If _specFlag = "Y" OrElse _specFlag = "O" Then
            grp_ReplayMSG.Visible = True
            Me.Width = 745
            Me.Height = 605
        Else
            grp_ReplayMSG.Visible = False
            Me.Width = 745
            Me.Height = 400
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Function convertType(ByVal _type As String) As String
        Try
            Select Case _type
                Case "W"
                    Return "浮動視窗"
                Case "M"
                    Return "電子郵件"
                Case "S"
                    Return "簡訊"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Function convertMsgType(ByVal MsgType As String) As String
        Try
            Select Case MsgType
                Case "P"
                    Return "個人"
                Case "D"
                    Return "科室"
                Case "G"
                    Return "群組"
                Case "C"
                    Return "全院"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Sub DisplayMsgDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_ReplayMsg.Focus()
    End Sub

    Private Sub btn_ReplayMsg_Click(sender As Object, e As EventArgs) Handles btn_ReplayMsg.Click
        Dim _mid As String = MIDs.Text.Trim
        Dim _replayMsg As String = txt_ReplayMsg.Text.Trim
        Dim _user As String = AppContext.userProfile.userId
        Try
            If txt_ReplayMsg.Text.Trim <> "" Then
                Servicefactory.NfcServiceManager.getInstance.UpdateReplayMsg(_mid, _replayMsg, _user)
                Syscom.Client.CMM.MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"回覆完成!"})
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Syscom.Client.CMM.MessageHandling.ShowWarnMsg("請輸入回覆內容!")
            End If
            
        Catch ex As Exception
            System.Console.WriteLine("Err")
        End Try

    End Sub

    Private Sub cbo_Phrase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Phrase.SelectedIndexChanged
        txt_ReplayMsg.Text = cbo_Phrase.Text
    End Sub
End Class
