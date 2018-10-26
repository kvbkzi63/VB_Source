Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP
Imports System.ServiceModel

Public Class NFCDataSender


#Region "Global Param"
    Dim nfcManager As NfcServiceManager = NfcServiceManager.getInstance
    Dim pubManager As PubServiceManager = PubServiceManager.getInstance
    '更新版本及時通知(ExternalFunction)
    Private globalNotifyDeploy As String = "C"
    Private currentUserId As String = AppContext.userProfile.userId
    '目前使用者的權限集合
    Private CurrentMenberOf As String = AppContext.userProfile.userMemberOf

    Public convertGroupType As String = "P"
    '權限是否進行特殊控管
    Private gblMemberControl As Boolean = True
    Private gblUserRight As DataSet = Nothing
#End Region

   

    Private Sub NFCDataSender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            chk_Spec_Flag.Visible = False

            Dim strDate As String = (Now.ToString(DateUtil.DateTypeSlash))
            dtp_StartDate.SetValue(strDate)
            dtp_EndDate.SetValue(strDate)

            'treeview()

            DataGridView1.ReadOnly = True
            RefreshGrid()

            Rdo_H.Checked = True
            convertGroupType = "C"
            treeview("4")
            '權限特殊控管設定 20160517 By Will,Lin
            Select Case Syscom.Comm.BASE.HospConfigUtil.HospConfig
                Case Comm.BASE.HospConfigUtil.hospConfigList.Tw_Taci
                    SetMemberControlForTaci()
                Case Else

            End Select

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


                If (UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False) Is Nothing Or UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows.Count = 0) Then
                    ErrorMsg += "請選擇要發送的對象!(個人、科室、群組或全院)" & vbCrLf
                End If

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

                If Not (chk_Mail.Checked OrElse chk_SMS.Checked OrElse chk_windows.Checked) Then
                    ErrorMsg += "請選擇發送方式(電子郵件、簡訊、浮動視窗" & vbCrLf
                End If

                If ErrorMsg <> "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {ErrorMsg})
                    Exit Sub
                End If

                Dim startTime As String = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                Dim endTime As String = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text

                Dim subject As String = txt_Subject.Text.Trim
                Dim msg As String = rtb_Msg.Text.Trim
                If chk_Spec_Flag.Checked Then
                    specFlag = "Y"
                Else
                    specFlag = "N"
                End If

                MessageHandling.ShowInfoMsg("CMMCMMB100", New String() {"發送訊息"})


                '===================
                Dim groupTxID As String = Now.ToString("yyyyMMddHHmmssfff")
                Dim saveDS As New DataSet

                saveDS.Tables.Add(NfcNotifyMsgDataTableFactory.getDataTable.Clone)
                convertGroupType = getGroupType()
                If chk_Mail.Checked Then
                    For i As Integer = 0 To UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows.Count - 1
                        Dim row As DataRow = saveDS.Tables(0).NewRow
                        row("MID") = saveDS.Tables(0).Rows.Count
                        row("SendDate") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        row("Type") = "M"
                        row("Start_Time") = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                        row("End_Time") = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text
                        row("Status") = ""
                        row("Subject") = txt_Subject.Text.Trim
                        row("MsgBody") = rtb_Msg.Text.Trim
                        row("Recipient") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Create_User") = currentUserId
                        row("Create_Time") = row("SendDate")
                        row("Modified_User") = currentUserId
                        row("Modified_Time") = row("SendDate")
                        row("ReplyMsg") = ""
                        row("ExternalFuction") = ""
                        row("App_System_No") = AppSystemNo
                        row("Sub_System_No") = SubSystemNo
                        row("Tsk_Task_no") = TskTaskno
                        row("Fun_Function_No") = FunFunctionNo
                        row("Level") = level
                        row("Group_Type") = convertGroupType
                        row("Group_ID") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Group_tx_Id") = groupTxID
                        row("Spec_Flag") = specFlag

                        saveDS.Tables(0).Rows.Add(row)
                    Next
                End If

                If chk_SMS.Checked Then
                    For i As Integer = 0 To UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows.Count - 1
                        Dim row As DataRow = saveDS.Tables(0).NewRow
                        row("MID") = saveDS.Tables(0).Rows.Count
                        row("SendDate") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        row("Type") = "S"
                        row("Start_Time") = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                        row("End_Time") = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text
                        row("Status") = ""
                        row("Subject") = txt_Subject.Text.Trim
                        row("MsgBody") = rtb_Msg.Text.Trim
                        row("Recipient") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Create_User") = currentUserId
                        row("Create_Time") = row("SendDate")
                        row("Modified_User") = currentUserId
                        row("Modified_Time") = row("SendDate")
                        row("ReplyMsg") = ""
                        row("ExternalFuction") = ""
                        row("App_System_No") = AppSystemNo
                        row("Sub_System_No") = SubSystemNo
                        row("Tsk_Task_no") = TskTaskno
                        row("Fun_Function_No") = FunFunctionNo
                        row("Level") = level
                        row("Group_Type") = convertGroupType
                        row("Group_ID") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Group_tx_Id") = groupTxID
                        row("Spec_Flag") = specFlag

                        saveDS.Tables(0).Rows.Add(row)
                    Next
                End If

                If chk_windows.Checked Then
                    For i As Integer = 0 To UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows.Count - 1
                        Dim row As DataRow = saveDS.Tables(0).NewRow
                        row("MID") = saveDS.Tables(0).Rows.Count
                        row("SendDate") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        row("Type") = "W"
                        row("Start_Time") = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text
                        row("End_Time") = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text
                        row("Status") = ""
                        row("Subject") = txt_Subject.Text.Trim
                        row("MsgBody") = rtb_Msg.Text.Trim
                        row("Recipient") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Create_User") = currentUserId
                        row("Create_Time") = row("SendDate")
                        row("Modified_User") = currentUserId
                        row("Modified_Time") = row("SendDate")
                        row("ReplyMsg") = ""
                        row("ExternalFuction") = ""
                        row("App_System_No") = AppSystemNo
                        row("Sub_System_No") = SubSystemNo
                        row("Tsk_Task_no") = TskTaskno
                        row("Fun_Function_No") = FunFunctionNo
                        row("Level") = level
                        row("Group_Type") = convertGroupType
                        row("Group_ID") = UclTreeViewAdvUC1.GetSelectedItemsResultInDataTable(False).Rows(i).Item("Layer_Code_Id").ToString.Trim
                        row("Group_tx_Id") = groupTxID
                        row("Spec_Flag") = specFlag

                        saveDS.Tables(0).Rows.Add(row)
                    Next
                End If

                Dim result As String = nfcManager.InsertNFCNotifyMsg(saveDS)

                If result <> "" Then
                    MessageHandling.ShowErrorMsg("發送失敗:" & result)
                End If
                RefreshGrid()
            End If


        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub RefreshGrid()
        Dim queryData As DataSet = nfcManager.QueryNFCNotifyMsgByUserId(currentUserId)
        DataGridView1.Rows.Clear()

        If queryData IsNot Nothing AndAlso queryData.Tables.Count > 0 Then
            For i As Integer = 0 To queryData.Tables(0).Rows.Count - 1
                addDataGridView(nvl(queryData.Tables(0).Rows(i).Item("Type")), nvl(queryData.Tables(0).Rows(i).Item("Start_Time")), nvl(queryData.Tables(0).Rows(i).Item("End_Time")), queryData.Tables(0).Rows(i).Item("Subject"), queryData.Tables(0).Rows(i).Item("MsgBody"), nvl(queryData.Tables(0).Rows(i).Item("SendDate")), queryData.Tables(0).Rows(i).Item("Employee_Name").ToString.Trim, queryData.Tables(0).Rows(i).Item("Group_tx_Id").ToString.Trim)
            Next
        End If

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

#Region "TreeView1"
    Private Sub treeview(ByVal flag As String)

        Try
            Dim employeeDS As DataSet = pubManager.queryEmployeeALL
            Dim DetpList As New ArrayList
            Dim CurrentParentCodeId As String = ""
            Dim CurrentParentCodeName As String = ""
            Select Case flag
                Case 1 '個人
                    If employeeDS.Tables(0).Rows.Count > 0 Then
                        UclTreeViewAdvUC1.TreeViewName = "科部清單"
                        UclTreeViewAdvUC1.SetTreeView(employeeDS.Tables(0), "code1", "name1", "code2", "name2")
                        UclTreeViewAdvUC1.ExpandNodeByTop()
                    End If
                Case "2" '科室
                    If employeeDS.Tables(1).Rows.Count > 0 Then
                        UclTreeViewAdvUC1.TreeViewName = "科部清單"
                        UclTreeViewAdvUC1.SetTreeView(employeeDS.Tables(1), "code1", "name1", "code2", "name2")
                        UclTreeViewAdvUC1.ExpandNodeByTop()
                    End If
                Case "3" '群組
                    'If employeeDS.Tables(1).Rows.Count > 0 Then
                    '    UclTreeViewAdvUC1.TreeViewName = "科部清單"
                    '    UclTreeViewAdvUC1.SetTreeView(employeeDS.Tables(2), "code1", "name1", "code2", "name2")
                    '    UclTreeViewAdvUC1.ExpandNodeByTop()
                    'End If
                    Dim groupDS As DataSet = NfcServiceManager.getInstance.queryGroupByUser(currentUserId)
                    If groupDS.Tables(0).Rows.Count > 0 Then
                        groupDS.Tables(0).Rows.Add("", "", "2021", "群組")
                        UclTreeViewAdvUC1.TreeViewName = "科部清單"
                        UclTreeViewAdvUC1.SetTreeView(groupDS.Tables(0), "code1", "name1", "code2", "name2")
                        UclTreeViewAdvUC1.ExpandNodeByTop()
                    Else
                        groupDS.Tables(0).Rows.Add("", "", "2021", "群組")
                        UclTreeViewAdvUC1.TreeViewName = "科部清單"
                        UclTreeViewAdvUC1.SetTreeView(groupDS.Tables(0), "code1", "name1", "code2", "name2")
                        UclTreeViewAdvUC1.ExpandNodeByTop()
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"沒有建立群組，請至群組成員維護建立群組和維護群組成員"})
                    End If
                Case "4" '全院
                    Dim table1 As DataTable = New DataTable("all")
                    table1.Columns.Add("code1")
                    table1.Columns.Add("name1")
                    table1.Columns.Add("code2")
                    table1.Columns.Add("name2")


                    table1.Rows.Add("00000", "本院", "00001", "全院")
                    table1.Rows.Add("", "", "00000", "本院")

                    UclTreeViewAdvUC1.SetTreeView(table1, "code1", "name1", "code2", "name2")
                    UclTreeViewAdvUC1.ExpandNodeByTop()
            End Select

        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs)
        'RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck

        'Call CheckAllChildNodes(e.Node)

        'If e.Node.Checked Then
        '    If e.Node.Parent Is Nothing = False Then
        '        Dim allChecked As Boolean = True
        '        Call IsEveryChildChecked(e.Node.Parent, allChecked)
        '        If allChecked Then
        '            e.Node.Parent.Checked = True
        '            Call ShouldParentsBeChecked(e.Node.Parent)
        '        End If
        '    End If
        'Else
        '    Dim parentNode As TreeNode = e.Node.Parent
        '    While parentNode Is Nothing = False
        '        parentNode.Checked = False
        '        parentNode = parentNode.Parent
        '    End While
        'End If

        'AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
    End Sub

    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            Call IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then
                checkValue = False
            End If
        Next
    End Sub

    Private Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            Dim allChecked As Boolean = True
            Call IsEveryChildChecked(startNode.Parent, allChecked)
            If allChecked Then
                startNode.Parent.Checked = True
                Call ShouldParentsBeChecked(startNode.Parent)
            End If
        End If
    End Sub
#End Region

#Region "DataGridView"
    Dim RowNum As Integer = 0
    Dim OldRowNum As Integer = 0

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim selectRowIndex As Integer = Me.DataGridView1.CurrentRow.Index

        'txt_Subject.Text = DataGridView1.Item(4, selectRowIndex).Value
        'rtb_Msg.Text = DataGridView1.Item(5, selectRowIndex).Value

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then
            
            Dim diagDS As DataSet = New DataSet("NfcModify")
            Dim diagTable As DataTable = New DataTable("NFC_Notify_Msg")
            diagDS.Tables.Add(diagTable)

            diagTable.Columns.Add("Start_Time", Type.GetType("System.String"))
            diagTable.Columns.Add("End_Time", Type.GetType("System.String"))
            diagTable.Columns.Add("Subject", Type.GetType("System.String"))
            diagTable.Columns.Add("MsgBody", Type.GetType("System.String"))
            diagTable.Columns.Add("Group_tx_Id", Type.GetType("System.String"))


            Dim row As DataRow = diagDS.Tables(0).NewRow
            row("Start_Time") = DataGridView1.Item(2, selectRowIndex).Value
            row("End_Time") = DataGridView1.Item(3, selectRowIndex).Value
            row("Subject") = DataGridView1.Item(4, selectRowIndex).Value
            row("MsgBody") = DataGridView1.Item(5, selectRowIndex).Value
            row("Group_tx_Id") = DataGridView1.Item(8, selectRowIndex).Value

            diagDS.Tables(0).Rows.Add(row)

            Dim tmpDate As DateTime = DataGridView1.Item(2, selectRowIndex).Value
            Dim tmpNow As DateTime = DateUtil.TransDateToROC(Now) + " " + Now.ToString("HH:mm")

            If tmpDate.ToString("yyyy-MM-dd HH:mm") > tmpNow.ToString("yyyy-MM-dd HH:mm") Then
                Dim frm As Form = New NFCModifySendUI(diagDS)
                frm.ShowDialog()
                RefreshGrid()
            End If
            
        End If

    End Sub
    Private Sub DataGridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseMove
        Dim HitTest As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)
        Try
            If Not HitTest Is Nothing Then
                If HitTest.Type = DataGridViewHitTestType.Cell Then
                    RowNum = HitTest.RowIndex
                    DataGridView1.Rows(RowNum).Selected = True
                    If OldRowNum <> RowNum Then
                        DataGridView1.Rows(OldRowNum).Selected = False
                    End If
                    OldRowNum = RowNum
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Sub addDataGridView(ByVal _type As String, ByVal sDate As String, ByVal eDate As String, ByVal subject As String, ByVal msg As String, ByVal sendDate As String, ByVal recipient As String, ByVal GroupTxId As String)

        Dim rowCount As Integer = DataGridView1.Rows.Count
        Dim _Status As String = ""
        DataGridView1.Rows.Add()

        If IsDate(eDate) Then
            DataGridView1.Rows(rowCount).Cells(3).Value = DateUtil.TransDateToROC(CDate(eDate)) & " " & CDate(eDate).ToString("HH:mm")
            If eDate < Now Then
                'DataGridView1.Rows(rowCount).DefaultCellStyle.BackColor = Color.DarkGray
                _Status = "1"
            End If
            If sDate <= Now AndAlso eDate >= Now Then
                'DataGridView1.Rows(rowCount).DefaultCellStyle.BackColor = Color.GreenYellow
                _Status = "2"
            End If
            If sDate > Now Then
                'DataGridView1.Rows(rowCount).DefaultCellStyle.BackColor = Color.Pink
                _Status = "3"
            End If
        End If

        DataGridView1.Rows(rowCount).Cells(0).Value = convertStatus(_Status)

        DataGridView1.Rows(rowCount).Cells(1).Value = convertType(_type)


        If IsDate(sDate) Then
            DataGridView1.Rows(rowCount).Cells(2).Value = DateUtil.TransDateToROC(CDate(sDate)) & " " & CDate(sDate).ToString("HH:mm")
        End If

        DataGridView1.Rows(rowCount).Cells(4).Value = subject
        DataGridView1.Rows(rowCount).Cells(5).Value = msg

        If IsDate(sendDate) Then
            DataGridView1.Rows(rowCount).Cells(6).Value = DateUtil.TransDateToROC(CDate(sendDate)) & " " & CDate(sendDate).ToString("HH:mm")
        End If

        DataGridView1.Rows(rowCount).Cells(7).Value = recipient
        DataGridView1.Rows(rowCount).Cells(8).Value = GroupTxId
    End Sub
#End Region

#Region "搜尋TreeView"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_SearchNodeText.Click
        UclTreeViewAdvUC1.search_TxtName(TextBox1.Text.Trim)
    End Sub
#End Region

#Region "轉換功能"


    Function convertType(ByVal _type As String) As String
        Try
            Select Case _type
                Case "W"
                    Return "浮動視窗"
                Case "M"
                    Return "電子郵件"
                Case "S"
                    Return "簡訊"
                Case "G"
                    Return "群組"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Function convertStatus(ByVal _type As String) As String
        Try
            Select Case _type
                Case "1"
                    Return "歷史"
                Case "2"
                    Return "效期內"
                Case "3"
                    Return "未來"

                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Function getGroupType() As String
        If Rdo_H.Checked Then Return "C"
        If rdo_G.Checked Then Return "G"
        If rdo_D.Checked Then Return "D"
        If rdo_P.Checked Then Return "P"
        Return ""
    End Function
#End Region

#Region "Radio Button Click 事件"

    Private Sub rdo_P_CheckedChanged(sender As Object, e As EventArgs) Handles rdo_P.CheckedChanged
        If rdo_P.Checked Then
            convertGroupType = "P"
            treeview("1")
        End If
    End Sub

    Private Sub rdo_D_CheckedChanged(sender As Object, e As EventArgs) Handles rdo_D.CheckedChanged
        If rdo_D.Checked Then
            convertGroupType = "D"
            treeview("2")
        End If
    End Sub

    Private Sub rdo_G_CheckedChanged(sender As Object, e As EventArgs) Handles rdo_G.CheckedChanged
        If rdo_G.Checked Then
            convertGroupType = "G"
            treeview("3")
        End If
    End Sub

    Private Sub Rdo_H_CheckedChanged(sender As Object, e As EventArgs) Handles Rdo_H.CheckedChanged
        If Rdo_H.Checked Then
            convertGroupType = "C"
            treeview("4")
        End If
    End Sub
#End Region

    Private Sub Btn_Query_Click(sender As Object, e As EventArgs) Handles Btn_Query.Click
        Dim startDate As String = dtp_QryStartDate.GetUsDateStr
        Dim endDate As String = dtp_QryEndDate.GetUsDateStr

        If startDate <> "" Then
            If mtb_StartTimeQ.Text.Trim <> "" Then
                startDate = startDate + " " + mtb_StartTimeQ.Text.Trim + ":00.000"
            Else
                startDate = startDate + " " + "00:00:00.000"
            End If

        End If
        If endDate <> "" Then
            If mtb_EndTimeQ.Text.Trim <> "" Then
                endDate = endDate + " " + mtb_EndTimeQ.Text.Trim + ":00.000"
            Else
                endDate = endDate + " " + "23:59:00.000"
            End If

        End If



        Dim finctionNo As String = "!@#$" & Txt_QueryNsg.Text.Trim
        Dim msgType As String = ""
        Dim level As String = ""
        Dim status As String = ""
        Dim recipient As String = tcq_Employee.getCode()
        Dim sendUser As String = AppContext.userProfile.userId
        Try
            If Rdo_Before.Checked Then
                status = "A"
            ElseIf Rdo_Now.Checked Then
                status = "B"
            ElseIf Rdo_After.Checked Then
                status = "C"
            End If

            Dim queryData As DataSet = nfcManager.QueryNFCNotifyMsgByCond(startDate, endDate, finctionNo, msgType, level, status, recipient, sendUser)
            DataGridView1.Rows.Clear()

            If queryData IsNot Nothing AndAlso queryData.Tables.Count > 0 Then
                For i As Integer = 0 To queryData.Tables(0).Rows.Count - 1
                    addDataGridView(nvl(queryData.Tables(0).Rows(i).Item("Type")), nvl(queryData.Tables(0).Rows(i).Item("Start_Time")), nvl(queryData.Tables(0).Rows(i).Item("End_Time")), queryData.Tables(0).Rows(i).Item("Subject"), queryData.Tables(0).Rows(i).Item("MsgBody"), nvl(queryData.Tables(0).Rows(i).Item("SendDate")), (queryData.Tables(0).Rows(i).Item("Employee_Name")).ToString.Trim, queryData.Tables(0).Rows(i).Item("Group_tx_Id"))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chk_windows_CheckedChanged(sender As Object, e As EventArgs) Handles chk_windows.CheckedChanged
        If chk_windows.Checked Then
            chk_Spec_Flag.Visible = True
        Else
            chk_Spec_Flag.Visible = False
            chk_Spec_Flag.Checked = False
        End If
    End Sub

#Region "     權限特殊控管設定"

    Private Sub SetMemberControlForTaci()
        Try
            Dim Roles As String()

            Select Case Syscom.Comm.BASE.HospConfigUtil.HospConfig
                Case Comm.BASE.HospConfigUtil.hospConfigList.Tw_Taci
                    dtp_StartDate.SetValue(Now.ToString("yyyy/MM/dd"))
                    mtb_StartTime.Text = Now.ToString("HH") & ":" & Now.ToString("mm")
                    Roles = New String() {"ARM_Admin", "CNC_Admin", "CNC_Demo", "CNC_HN", "OMO_Admin", "OMO_Nurse"}
                    Rdo_H.Checked = False
                    rdo_P.Checked = True
                    rdo_D.Checked = True
                    rdo_G.Checked = True
                    '依據Spec 擁有全院發送權限為 ARM_Admin、CNC_Admin、CNC_Demo、CNC_HN、OMO_Admin、OMO_Nurse
                    For Each Str As String In Roles
                        If CurrentMenberOf.Contains(Str) Then
                            Rdo_H.Checked = True
                            Exit Sub
                        End If
                    Next
                Case Else

            End Select



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"權限控管設定"})
        End Try

    End Sub

#End Region
End Class