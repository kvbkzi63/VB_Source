
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP
Imports System.ServiceModel

Public Class NFCDeploySender
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent


#Region "Global Param"
    Dim nfcManager As NfcServiceManager = NfcServiceManager.getInstance
    Dim pubManager As PubServiceManager = PubServiceManager.getInstance
    '更新版本及時通知(ExternalFunction)
    Private currentUserId As String = AppContext.userProfile.userId
    '目前使用者的權限集合
    Private CurrentMenberOf As String = AppContext.userProfile.userMemberOf
    '權限是否進行特殊控管
    Private gblMemberControl As Boolean = True
    Private gblUserRight As DataSet = Nothing
#End Region



    Private Sub NFCDataSender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strDate As String = (Now.ToString(DateUtil.DateTypeSlash))
            dtp_StartDate.SetValue(strDate)
            dtp_EndDate.SetValue(strDate)
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub btn_Send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Send.Click
        Try
            UCLScreenUtil.Lock(Me)
            CleanBackColor()
            Dim ErrorMsg As String = ""
            Dim extStr As String = ""
            'add Pub ================================================
            Dim AppSystemNo As String = ""
            Dim SubSystemNo As String = ""
            Dim TskTaskno As String = ""
            Dim FunFunctionNo As String = ""
            Dim level As String = ""
            Dim specFlag As String = ""
            If Me.Tag.ToString.Split(","c).Count = 3 Then
                AppSystemNo = "HIS"
                SubSystemNo = Me.Tag.ToString.Split(","c)(0)
                TskTaskno = Me.Tag.ToString.Split(","c)(1)
                FunFunctionNo = Me.Tag.ToString.Split(","c)(2)
                level = "1"
            End If

            '=======================================================

            If (Not CheckFields()) Then


                If CDate(dtp_StartDate.GetUsDateStr).Date < Now.Date Then 'mtb_StartTime
                    ErrorMsg += "開始日期不可小於今日" & vbCrLf
                    dtp_StartDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
                End If

                If CDate(dtp_StartDate.GetUsDateStr).Date <= CDate(dtp_EndDate.GetUsDateStr).Date Then
                    If Replace(mtb_StartTime.Text, ":", "") > Replace(mtb_EndTime.Text, ":", "") Then
                        ErrorMsg += "結束日期時間不可大於開始日期時間" & vbCrLf
                        dtp_EndDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
                        mtb_EndTime.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                Else
                    ErrorMsg += "開始日期不可大於結束日期" & vbCrLf
                    dtp_StartDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
                End If
                '20160517 By Will , 依據Sean發送的Spec 
                If CDate(dtp_EndDate.GetUsDateStr).Date < Now.Date Then 'mtb_StartTime
                    ErrorMsg += "輸入時間小於現在時間" & vbCrLf
                    dtp_EndDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
                End If

                If ErrorMsg <> "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {ErrorMsg})
                    Exit Sub
                End If

                Dim startTime As String = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                Dim endTime As String = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text

                Dim subject As String = txt_Subject.Text.Trim
                Dim msg As String = rtb_Msg.Text.Trim


                '===================
                Dim groupTxID As String = Now.ToString("yyyyMMddHHmmssfff")
                Dim saveDS As New DataSet

                saveDS.Tables.Add(NfcNotifyMsgDataTableFactory.getDataTable.Clone)

                Dim row As DataRow = saveDS.Tables(0).NewRow
                row("MID") = saveDS.Tables(0).Rows.Count
                row("SendDate") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                row("Type") = "W"
                row("Start_Time") = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                row("End_Time") = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text
                row("Status") = ""
                row("Subject") = txt_Subject.Text.Trim
                row("MsgBody") = rtb_Msg.Text.Trim
                row("Recipient") = "Deploy"
                row("Create_User") = currentUserId
                row("Create_Time") = row("SendDate")
                row("Modified_User") = currentUserId
                row("Modified_Time") = row("SendDate")
                row("App_System_No") = AppSystemNo
                row("Sub_System_No") = SubSystemNo
                row("Tsk_Task_no") = TskTaskno
                row("Fun_Function_No") = FunFunctionNo
                row("Level") = level
                row("Group_Type") = "P"
                row("Group_ID") = "ALL"
                row("Group_tx_Id") = groupTxID
                row("Spec_Flag") = specFlag

                saveDS.Tables(0).Rows.Add(row)
                Dim result As String = nfcManager.InsertNFCNotifyMsg(saveDS)

                If result <> "" Then
                    MessageHandling.ShowErrorMsg("發送失敗:" & result)
                End If

            End If


        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub


    Private Function CheckFields() As Boolean
        Try
            Dim IsError As Boolean = False

            If (dtp_StartDate.GetUsDateStr.Length = 0) Then
                IsError = True
                dtp_StartDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If
            If (StringUtil.nvl(mtb_StartTime.Text).Equals(":")) Then
                IsError = True
                mtb_StartTime.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If
            If (dtp_EndDate.GetUsDateStr.Length = 0) Then
                IsError = True
                dtp_EndDate.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If
            If (StringUtil.nvl(mtb_EndTime.Text).Equals(":")) Then
                IsError = True
                mtb_EndTime.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If
            If (StringUtil.nvl(txt_Subject.Text).Length = 0) Then
                IsError = True
                txt_Subject.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If
            If (StringUtil.nvl(rtb_Msg.Text).Length = 0) Then
                IsError = True
                rtb_Msg.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End If

            Try
                DateTime.Parse(dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text.Trim)
            Catch ex As Exception
                IsError = True
                mtb_StartTime.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End Try
            Try
                DateTime.Parse(dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text.Trim)
            Catch ex As Exception
                IsError = True
                mtb_EndTime.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
            End Try

            If (IsError) Then
                MessageHandling.ShowInfoMsg("CMMCMMB101", New String() {"欄位"})
            End If

            Return IsError
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    Private Sub CleanBackColor()
        Try
            dtp_StartDate.BackColor = Color.White
            mtb_StartTime.BackColor = Color.White
            dtp_EndDate.BackColor = Color.White
            mtb_EndTime.BackColor = Color.White
            txt_Subject.BackColor = Color.White
            rtb_Msg.BackColor = Color.White
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class