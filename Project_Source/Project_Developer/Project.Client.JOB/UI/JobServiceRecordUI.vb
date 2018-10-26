
Imports System.ServiceModel
Imports JOBClientServiceFactory
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Project.Comm.JOB
Imports System.Windows.Forms
Imports Syscom.Comm.EXP
Imports System.Data
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Client.Servicefactory
Imports System.Collections
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.ScreenUtil

Public Class JobServiceRecordUI
    Inherits Syscom.Client.UCL.BaseFormUI



#Region "     變數宣告"
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    Dim CurrentUserID As String = Syscom.Comm.Utility.AppContext.userProfile.userId
    Dim initialDS As DataSet
    Dim rejectDTPt As New JobServiceReplyRecordDataTableFactory.JOBServiceReplyRecordPt
    Dim GridColumnsAndHeaderText As String(,) = {{"Import", "帶入", "Y"},
                                                 {"Update", "修改", "Y"},
                                                 {"Reply", "回覆", "Y"},
                                                 {"JOB_Code", "派工單號", "Y"},
                                                 {"Project_Id", "Project_Id", "N"},
                                                 {"Project_Name", "所屬專案", "Y"},
                                                 {"Hospital_Code", "Hospital_Code", "N"},
                                                 {"Hospital_Short_Name", "所屬醫院", "Y"},
                                                 {"System_Code", "System_Code", "N"},
                                                 {"System_Name", "系統別", "Y"},
                                                 {"Function_Code", "Function_Code", "N"},
                                                 {"Function_Name", "功能名稱", "Y"},
                                                 {"Receive_DateTime", "提出日", "Y"},
                                                 {"Issue_Source", "來源", "Y"},
                                                 {"Issue_Classify", "需求類別", "Y"},
                                                 {"Issue_Status", "處理狀態", "Y"},
                                                 {"Contact_User", "提出人", "Y"},
                                                 {"Contact_Way", "聯絡方式", "Y"},
                                                 {"Contact_Note", "電話/傳真/EMail", "Y"},
                                                 {"Processing_Approach", "處理過程", "Y"},
                                                 {"Processing_Employee_Code", "Processing_Employee_Code", "N"},
                                                 {"Processing_Employee_Name", "處理人員", "Y"},
                                                 {"SA", "負責SA", "Y"},
                                                 {"SD", "權責SD", "Y"},
                                                 {"PG", "PG姓名", "Y"},
                                                 {"Processing_Cost", "處理工時(hr)", "Y"},
                                                 {"Finish_Date", "完成日", "Y"},
                                                 {"Estimated_Finish_Date", "預期完成日", "Y"},
                                                 {"Issue_Description", "問題描述", "Y"},
                                                 {"Note", "備註", "Y"},
                                                 {"Cancel", "取消", "Y"},
                                                 {"Issue_Id", "Issue_Id", "N"},
                                                 {"Create_User", "Create_User", "N"}}
    Dim RejectDgvGridColumnsAndHeaderText As String(,) = {{"Imoprt", "查看", "Y"},
                                                 {"Create_Time", "建立日期", "Y"},
                                                 {"Create_User", "建立者", "Y"},
                                                 {"Reply_Type", "狀態", "Y"},
                                                 {"Issue_Id", "Issue_Id", "N"},
                                                 {"Reason_FID", "Reason_FID", "N"}}
    Enum GridColumnsIndex As Integer
        Import
        Update
        Reply
        Job_Code
        Project_Id
        Project_Name
        Hospital_Code
        Hospital_Short_Name
        System_Code
        System_Name
        Function_Code
        Function_Name
        Receive_DateTime
        Issue_Source
        Issue_Classify
        Issue_Status
        Contact_User
        Contact_Way
        Contact_Note
        Processing_Approach
        Processing_Employee_Code
        Processing_Employee_Name
        SA
        SD
        PG
        Processing_Cost
        Finish_Date
        Estimated_Finish_Date
        Issue_Description
        Note
        Cancel
        Issue_Id
        Create_User
    End Enum
    Enum RejectDgvColumnsIndex As Integer
        Imoprt
        Create_Time
        Create_User
    End Enum
    Enum IssueStatus As Integer
        TransToSA = 2
        Finish = 1
        AssignAlready = 3
        Reject = 6
        Close = 5
    End Enum
#End Region

#Region "     控制項事件"


    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-14</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            InitialComboBox()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub
    ''' <summary>
    ''' 新增需求紀錄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_CreateIssueRecord_Click(sender As Object, e As EventArgs) Handles btn_CreateIssueRecord.Click
        Try

            If CheckBeforeSave() Then
                Exit Sub
            End If

            Dim resultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(GetSaveDS(ActionKind.CreateNewIssueRecord))

            If CheckHasValue(resultDS) Then
                MessageHandling.ShowInfoMsg("CMMCMMB300", "新增成功")
                ClearControlValue(tlp_Issue)
                btn_Query.PerformClick()
                TabControl1.SelectedIndex = 0
                txt_UploadPath.Text = ""
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"病人主檔維護作業"})
        End Try
    End Sub


    ''' <summary>
    ''' 清除新增需求紀錄表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_ClearIssue_Click(sender As Object, e As EventArgs) Handles btn_ClearIssue.Click
        Try
            ClearControlValue(tlp_Issue)
            btn_CreateIssueRecord.Enabled = True
            btn_Update.Enabled = False
            cbo_Project.Enabled = True
            cbo_System.Enabled = True
            cbo_Function.Enabled = True
            cbo_Hosp.Enabled = True
            cbo_IssueClassify.Enabled = True
            cbo_Issue_Source.Enabled = True
            txt_UploadPath.Text = ""
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除新增需求紀錄表"})
        End Try
    End Sub
    ''' <summary>
    ''' 清除查詢紀錄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        Try
            ClearControlValue(tlp_Query)
            dgv_IssueList.ClearDS()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除查詢"})
        End Try
    End Sub

    ''' <summary>
    ''' 選專案清除功能與重置系統清單
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_Project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Project.SelectedIndexChanged
        Try
            If cbo_Project.SelectedValue.GetType().ToString.Equals("System.String") Then
                Dim query = From System In initialDS.Tables("System").AsEnumerable()
                            Where System.Field(Of String)("Project_ID").ToString.Trim = cbo_Project.SelectedValue.ToString
                            Select System
                If query.AsDataView.Count > 0 Then
                    cbo_System.DataSource = query.CopyToDataTable
                    cbo_System.uclDisplayIndex = "0,1"
                    cbo_System.uclValueIndex = "0"
                End If
                cbo_System.SelectedIndex = 0

            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"選專案清除功能與重置系統清單"})
        End Try

    End Sub


    ''' <summary>
    ''' 選專案清除功能與重置系統清單
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_QueryProjectId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_QueryProjectId.SelectedIndexChanged
        Try
            If cbo_QueryProjectId.SelectedValue.GetType().ToString.Equals("System.String") Then
                Dim query = From System In initialDS.Tables("System").AsEnumerable()
                            Where System.Field(Of String)("Project_ID").ToString.Trim = cbo_QueryProjectId.SelectedValue.ToString
                            Select System
                If query.AsDataView.Count > 0 Then
                    cbo_QuerySystemCode.DataSource = query.CopyToDataTable
                    cbo_QuerySystemCode.uclDisplayIndex = "0,1"
                    cbo_QuerySystemCode.uclValueIndex = "0"
                End If
                cbo_QuerySystemCode.SelectedIndex = 0
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"選專案清除功能與重置系統清單"})
        End Try

    End Sub


    ''' <summary>
    ''' 選系統別重置功能清單
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_System_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_System.SelectedIndexChanged
        Try
            If sender.SelectedValue <> "" Then
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryFunctionDataByProjectIDandSystemCode)
                SendDS.Tables(0).Rows.Add("QueryFunctionDataByProjectIDandSystemCode", cbo_Project.SelectedValue, sender.SelectedValue)
                Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

                If CheckHasValue(retDS) Then
                    cbo_Function.DataSource = retDS.Tables(0).Copy
                    cbo_Function.uclDisplayIndex = "3"
                    cbo_Function.uclValueIndex = "2"
                End If
            Else
                cbo_Function.DataSource = Nothing
                cbo_Function.SelectedValue = ""
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"選系統別重置功能清單"})
        End Try

    End Sub

    ''' <summary>
    ''' 選系統別重置功能清單
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_QuerySystemCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_QuerySystemCode.SelectedIndexChanged
        Try
            If cbo_QuerySystemCode.SelectedValue.GetType().ToString.Equals("System.String") Then
                Dim query = From f In initialDS.Tables("Function").AsEnumerable()
                            Where f.Field(Of String)("Project_ID").ToString.Trim = cbo_QueryProjectId.SelectedValue.ToString _
                          And f.Field(Of String)("System_Code").ToString.Trim = cbo_QuerySystemCode.SelectedValue.ToString
                            Select f
                If query.AsDataView.Count > 0 Then
                    cbo_QueryFunctionCode.DataSource = query.CopyToDataTable
                    cbo_QueryFunctionCode.uclDisplayIndex = "1"
                    cbo_QueryFunctionCode.uclValueIndex = "0"
                End If
                cbo_QueryFunctionCode.SelectedIndex = 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"選系統別重置功能清單"})
        End Try

    End Sub


    ''' <summary>
    ''' 查詢需求列表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Try

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryServiceRecordList)
            SendDS.Tables(0).Rows.Add("QueryServiceRecordList",
                                      cbo_QueryProjectId.SelectedValue,
                                      cbo_QuerySystemCode.SelectedValue,
                                      cbo_QueryFunctionCode.SelectedValue,
                                      cbo_QueryIssueStatus.SelectedValue,
                                      dtp_SDate.GetUsDateStr,
                                      dtp_EDate.GetUsDateStr,
                                      cbo_QueryProcessingEmployee.SelectedValue,
                                      cbo_QueryHosp.SelectedValue,
                                      txt_JobCode.Text)
            Dim ResultDS As DataSet = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(SendDS)


            If CheckHasValue(ResultDS) Then
                ShowDgv(GenGridDataSet(ResultDS, GridColumnsAndHeaderText))
            Else
                ShowDgv(GenGridDataSet(New DataSet, GridColumnsAndHeaderText))
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢需求列表"})
        End Try

    End Sub

    ''' <summary>
    ''' 夾帶附件檔案
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_UploadAtt_Click(sender As Object, e As EventArgs) Handles btn_UploadAtt.Click
        Try
            If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txt_UploadPath.Text = String.Join(";", OpenFileDialog1.FileNames)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_IssueList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_IssueList.CellClick
        Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub



            Select Case e.ColumnIndex
                Case GridColumnsIndex.Import, GridColumnsIndex.Update
                    If dgv_IssueList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        'Set Data
                        SetDataToControls(dgv_IssueList.GetDBDS.Tables(0).Rows(e.RowIndex), e.ColumnIndex)
                        TabControl1.SelectedIndex = 1
                    End If
                Case GridColumnsIndex.Cancel
                    If dgv_IssueList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim ui As JobTextDialogUI = New JobTextDialogUI
                        ui.SetUIText = "作廢原因輸入"
                        ui.ExitWithoutInput = False
                        Dim CancelReason As String = ui.showDialog()
                        ui.Dispose()
                        ui = Nothing
                        If CancelReason.Length > 0 Then
                            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.CancelServiceRecord)
                            SendDS.Tables(0).Rows.Add(ActionName.CancelServiceRecord.ToString,
                                                       dgv_IssueList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Issue_Id").ToString.Trim,
                                                       CancelReason, CurrentUserID)
                            Dim retDS As DataSet = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(SendDS)

                            If CheckMethodUtil.CheckHasValue(retDS) Then
                                MessageHandling.ShowWarnMsg("CMMCMMB300", "作廢成功")
                                btn_Query.PerformClick()
                            End If
                        End If
                    End If
                Case GridColumnsIndex.Reply
                    TabControl1.SelectedIndex = 2
            End Select


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Grid被選取"})
        End Try
    End Sub

    Private Sub btn_ClearReject_Click(sender As Object, e As EventArgs) Handles btn_ClearReject.Click
        Lock(Me)
        Try

            rtb_Reason.Clear()


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try

            Select Case CType(sender, TabControl).SelectedIndex
                Case 1

                Case 2
                    rtb_Reason.Clear()
                    dgv_RejectRecord.ClearDS()
                    dgv_RejectRecord.ClearSelection()
                    tlp_RejectMain.Enabled = dgv_IssueList.CurrentCell IsNot Nothing
                    If tlp_RejectMain.Enabled Then
                        LoarRejectRecord(dgv_IssueList.GetDBDS.Tables(0).Rows(dgv_IssueList.CurrentCell.RowIndex).Item(rejectDTPt.Issue_Id).ToString.Trim)
                    End If
            End Select

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"索引改變"})

        End Try
    End Sub
    Private Sub dgv_RejectRecord_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_RejectRecord.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse Not dgv_RejectRecord.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then Exit Sub
        pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "載入中，請稍後‧‧‧")
        Lock(Me)
        Try
            grb_Reason.Enabled = True
            Dim FID As String = dgv_RejectRecord.GetDBDS.Tables(0).Rows(dgv_RejectRecord.CurrentCell.RowIndex).Item(rejectDTPt.Reason_FID).ToString.Trim
            Dim FilePath As String = ProjectClientBP.getInstance.LoadFileByFID(FID)
            rtb_Reason.LoadFile(FilePath)
            IO.File.Delete(FilePath)

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入紀錄"})
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
            UnLock(Me)
        End Try
    End Sub
    Private Sub rdb_Close_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_Close.CheckedChanged
        Try
            grb_Reason.Enabled = Not CType(sender, RadioButton).Checked

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"結案選項"})
        End Try
    End Sub

    Private Sub btn_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Confirm.Click
        Lock(Me)
        Try
            If rdb_Reject.Checked AndAlso rtb_Reason.Text.Length = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "理由不可空白!!")
                Exit Sub
            End If
            Select Case rdb_Reject.Checked
                Case True
                    CreateNewReplyRecord(dgv_IssueList.GetDBDS.Tables(0).Rows(dgv_IssueList.CurrentCell.RowIndex)("Issue_Id").ToString.Trim, ReplyType.Reject)
                Case False
                    CreateNewReplyRecord(dgv_IssueList.GetDBDS.Tables(0).Rows(dgv_IssueList.CurrentCell.RowIndex)("Issue_Id").ToString.Trim, ReplyType.Close)
            End Select


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"結案選項"})
        Finally
            UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' 匯出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        Lock(Me)
        Try
            If cbo_QueryProjectId.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "專案未選")
                Exit Sub
            End If

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.ServerRecordExport)
            SendDS.Tables(0).Rows.Add("ServerRecordExport", cbo_QueryProjectId.SelectedValue)
            Dim ResultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            Dim Columns As String() = {"派工單號", "所屬專案", "醫院別", "提出日期時間", "來源", "提出單位/使用者", "分機/Mail", "問題敘述", "問題分類", "作業點", "問題回覆 / 處理過程", "處理人員", "處理工時(hr)", "完成日", "狀態", "備註"}
            Dim ColumnWidth As String() = {"30", "18", "12", "30", "10", "30", "17", "130", "10", "25", "50", "12", "16", "30", "9", "70"}

            Syscom.Client.CMM.CmmMethodUtil.DataToExcelWithFormate(ResultDS.Tables(0), Columns, ColumnWidth, "ServiceRecord", "", False)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出"})
        Finally
            UnLock(Me)
        End Try
    End Sub


    ''' <summary>
    ''' 修改紀錄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        Lock(Me)
        Try
            If CheckBeforeSave() Then
                Exit Sub
            End If

            Dim resultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(GetSaveDS(ActionKind.ModifyIssueRecord))

            If CheckHasValue(resultDS) Then
                MessageHandling.ShowInfoMsg("CMMCMMB300", "更新成功")
                ClearControlValue(tlp_Issue)
                btn_Query.PerformClick()
                TabControl1.SelectedIndex = 0
                txt_UploadPath.Text = ""
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改紀錄"})
        Finally
            UnLock(Me)
        End Try
    End Sub

#End Region
#Region "     內部函數"

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="pl"></param>
    Private Sub ClearControlValue(ByRef pl As TableLayoutPanel)

        Try
            For Each c As Control In pl.Controls
                Try
                    Select Case c.GetType.ToString
                        Case "System.Windows.Forms.RichTextBox"
                            CType(c, System.Windows.Forms.RichTextBox).Text = ""
                            CType(c, System.Windows.Forms.RichTextBox).Enabled = True
                        Case "Syscom.Client.UCL.UCLComboBoxUC"
                            CType(c, Syscom.Client.UCL.UCLComboBoxUC).SelectedIndex = 0
                            CType(c, Syscom.Client.UCL.UCLComboBoxUC).SelectedValue = ""
                            CType(c, Syscom.Client.UCL.UCLComboBoxUC).Enabled = True

                        Case "Syscom.Client.UCL.UCLTextBoxUC"
                            CType(c, Syscom.Client.UCL.UCLTextBoxUC).Text = ""
                            CType(c, Syscom.Client.UCL.UCLTextBoxUC).Enabled = True

                        Case "Syscom.Client.UCL.UCLDateTimePickerUC"
                            CType(c, Syscom.Client.UCL.UCLDateTimePickerUC).Clear()
                            CType(c, Syscom.Client.UCL.UCLDateTimePickerUC).Enabled = True
                        Case "Syscom.Client.UCL.UCLRichTextBoxUC"
                            CType(c, Syscom.Client.UCL.UCLRichTextBoxUC).Text = ""
                            CType(c, Syscom.Client.UCL.UCLRichTextBoxUC).Enabled = True
                    End Select
                Catch

                End Try
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除新增需求紀錄表"})
        End Try

    End Sub

    ''' <summary>
    ''' 初始化下拉選單
    ''' </summary>
    Private Sub InitialComboBox()

        Try
            initialDS = JOBServiceManager.getInstance.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))

            If CheckHasTable(initialDS, "Project") Then
                cbo_QueryProjectId.DataSource = initialDS.Tables("Project").Copy
                cbo_QueryProjectId.uclDisplayIndex = "0,1"
                cbo_QueryProjectId.uclValueIndex = "0"
                cbo_Project.DataSource = initialDS.Tables("Project").Copy
                cbo_Project.uclDisplayIndex = "0,1"
                cbo_Project.uclValueIndex = "0"
            End If
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryEmployeeListByLevel)
            SendDS.Tables(0).Rows.Add("QueryEmployeeListByLevel", "0")
            Dim EmployeeDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            cbo_Processing_Employee_Code.DataSource = EmployeeDS.Tables("PUB_Employee").Copy
            cbo_Processing_Employee_Code.uclDisplayIndex = "1"
            cbo_Processing_Employee_Code.uclValueIndex = "0"

            cbo_QueryProcessingEmployee.DataSource = EmployeeDS.Tables("PUB_Employee").Copy
            cbo_QueryProcessingEmployee.uclDisplayIndex = "1"
            cbo_QueryProcessingEmployee.uclValueIndex = "0"

            Try
                cbo_QueryIssueStatus.DataSource = PubServiceManager.getInstance.queryPUBSysCode("9998", False).Tables(0)
                cbo_QueryIssueStatus.uclDisplayIndex = "0,1"
                cbo_QueryIssueStatus.uclValueIndex = "0"
            Catch ex As Exception

            End Try

            Try
                cbo_Issue_Status.DataSource = cbo_QueryIssueStatus.DataSource.Copy
                cbo_Issue_Status.uclDisplayIndex = "0,1"
                cbo_Issue_Status.uclValueIndex = "0"
            Catch ex As Exception

            End Try

            Try
                cbo_IssueClassify.DataSource = PubServiceManager.getInstance.queryPUBSysCode("9999", False).Tables(0)
                cbo_IssueClassify.uclDisplayIndex = "0,1"
                cbo_IssueClassify.uclValueIndex = "0"
            Catch ex As Exception

            End Try

            Try
                cbo_Issue_Source.DataSource = PubServiceManager.getInstance.queryPUBSysCode("9997", False).Tables(0)
                cbo_Issue_Source.uclDisplayIndex = "0,1"
                cbo_Issue_Source.uclValueIndex = "0"
            Catch ex As Exception

            End Try

            Try
                cbo_Contact_Way.DataSource = cbo_Issue_Source.DataSource.Copy
                cbo_Contact_Way.uclDisplayIndex = "0,1"
                cbo_Contact_Way.uclValueIndex = "0"
            Catch ex As Exception

            End Try


            Try
                If initialDS.Tables.Contains("HospList") Then
                    cbo_Hosp.DataSource = initialDS.Tables("HospList").Copy
                    cbo_Hosp.uclDisplayIndex = "0,1"
                    cbo_Hosp.uclValueIndex = "0"
                    cbo_QueryHosp.DataSource = initialDS.Tables("HospList").Copy
                    cbo_QueryHosp.uclDisplayIndex = "0,1"
                    cbo_QueryHosp.uclValueIndex = "0"

                End If
            Catch ex As Exception

            End Try
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化下拉選單"})
        End Try


    End Sub

    ''' <summary>
    ''' Show Dgv
    ''' </summary>
    ''' <param name="ds"></param>
    Private Sub ShowDgv(ByVal ds As DataSet)

        Dim ht As New Hashtable
        Dim HeaderText As String = ""
        Dim VisiableIndex As String = ""
        Try
            Dim CellDS As DataSet
            CellDS = New DataSet
            CellDS.Tables.Add(cbo_IssueClassify.DataSource.Copy)
            Dim cboIssueClassifyCell As New Syscom.Client.UCL.ComboBoxCell
            cboIssueClassifyCell.Ds = CellDS.Copy
            cboIssueClassifyCell.DisplayIndex = "0,1"
            cboIssueClassifyCell.ValueIndex = "0"

            CellDS = New DataSet
            CellDS.Tables.Add(cbo_Contact_Way.DataSource.Copy)
            Dim cboContactWayCell As New Syscom.Client.UCL.ComboBoxCell
            cboContactWayCell.Ds = CellDS.Copy
            cboContactWayCell.DisplayIndex = "0,1"
            cboContactWayCell.ValueIndex = "0"


            CellDS = New DataSet
            CellDS.Tables.Add(cbo_Issue_Status.DataSource.Copy)
            Dim cboIssueStatusCell As New Syscom.Client.UCL.ComboBoxCell
            cboIssueStatusCell.Ds = CellDS.Copy
            cboIssueStatusCell.DisplayIndex = "0,1"
            cboIssueStatusCell.ValueIndex = "0"
            CellDS = New DataSet
            CellDS.Tables.Add(cbo_Issue_Source.DataSource.Copy)
            Dim cboIssueSourceCell As New Syscom.Client.UCL.ComboBoxCell
            cboIssueSourceCell.Ds = CellDS.Copy
            cboIssueSourceCell.DisplayIndex = "0,1"
            cboIssueSourceCell.ValueIndex = "0"
            Dim btnImport As New Syscom.Client.UCL.ButtonCell
            btnImport.Text = "帶入"
            Dim btnUpdate As New Syscom.Client.UCL.ButtonCell
            btnUpdate.Text = "修改"
            Dim cancelbtn As New Syscom.Client.UCL.ButtonCell
            cancelbtn.Text = "作廢"
            Dim replybtn As New Syscom.Client.UCL.ButtonCell
            replybtn.Text = "回覆"
            ht.Add(-1, ds)
            ht.Add(GridColumnsIndex.Issue_Classify, cboIssueClassifyCell)
            ht.Add(GridColumnsIndex.Contact_Way, cboContactWayCell)
            ht.Add(GridColumnsIndex.Issue_Source, cboIssueSourceCell)
            ht.Add(GridColumnsIndex.Issue_Status, cboIssueStatusCell)
            ht.Add(GridColumnsIndex.Finish_Date, New Syscom.Client.UCL.DtpCell)
            ht.Add(GridColumnsIndex.Estimated_Finish_Date, New Syscom.Client.UCL.DtpCell)

            ht.Add(GridColumnsIndex.Reply, replybtn)
            ht.Add(GridColumnsIndex.Cancel, cancelbtn)
            ht.Add(GridColumnsIndex.Import, btnImport)
            ht.Add(GridColumnsIndex.Update, btnUpdate)

            For i As Int32 = 0 To GridColumnsAndHeaderText.GetUpperBound(0)
                HeaderText = HeaderText & GridColumnsAndHeaderText(i, 1) & ","
                If GridColumnsAndHeaderText(i, 2).Equals("Y") Then
                    VisiableIndex = VisiableIndex & i & ","
                End If
            Next
            HeaderText = HeaderText.Substring(0, HeaderText.Length - 1)
            VisiableIndex = VisiableIndex.Substring(0, VisiableIndex.Length - 1)
            dgv_IssueList.Initial(ht, HeaderText, VisiableIndex)
            dgv_IssueList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                Select Case CInt(ds.Tables(0).Rows(i).Item("Issue_Status"))
                    Case IssueStatus.AssignAlready
                        dgv_IssueList.SetRowColor(i, Drawing.Color.Yellow)
                    Case IssueStatus.Close
                        dgv_IssueList.SetRowColor(i, Drawing.Color.LightBlue)
                    Case IssueStatus.TransToSA
                        dgv_IssueList.SetRowColor(i, Drawing.Color.Red)
                    Case IssueStatus.Reject
                        dgv_IssueList.SetRowColor(i, Drawing.Color.LightGreen)
                    Case IssueStatus.Finish
                        dgv_IssueList.SetRowColor(i, Drawing.Color.LightPink)

                End Select
                If CheckCanBeCancel(i) Then
                    dgv_IssueList.EnableButton(i, GridColumnsIndex.Cancel)
                    dgv_IssueList.EnableButton(i, GridColumnsIndex.Update)
                Else
                    dgv_IssueList.DisableButton(i, GridColumnsIndex.Cancel)
                    dgv_IssueList.DisableButton(i, GridColumnsIndex.Update)
                End If
            Next



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢需求列表"})
        End Try

    End Sub
    Private Sub ShowRejectDgv(ByVal ds As DataSet)
        Dim ht As New Hashtable
        Dim HeaderText As String = ""
        Dim VisiableIndex As String = ""
        Try
            Dim CellDS As DataSet
            CellDS = New DataSet
            CellDS.Tables.Add(cbo_Processing_Employee_Code.DataSource.Copy)
            Dim RejoectUser As New Syscom.Client.UCL.ComboBoxCell
            RejoectUser.Ds = CellDS.Copy
            RejoectUser.DisplayIndex = "0,1"
            RejoectUser.ValueIndex = "0"


            Dim checkbtn As New Syscom.Client.UCL.ButtonCell
            checkbtn.Text = "查看"

            ht.Add(-1, ds)

            ht.Add(RejectDgvColumnsIndex.Create_Time, New Syscom.Client.UCL.DtpCell)
            ht.Add(RejectDgvColumnsIndex.Create_User, RejoectUser)
            ht.Add(RejectDgvColumnsIndex.Imoprt, checkbtn)


            dgv_RejectRecord.Initial(ht)


            For i As Int32 = 0 To RejectDgvGridColumnsAndHeaderText.GetUpperBound(0)
                HeaderText = HeaderText & RejectDgvGridColumnsAndHeaderText(i, 1) & ","
                If RejectDgvGridColumnsAndHeaderText(i, 2).Equals("Y") Then
                    VisiableIndex = VisiableIndex & i & ","
                End If
            Next

            dgv_RejectRecord.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            HeaderText = HeaderText.Substring(0, HeaderText.Length - 1)
            VisiableIndex = VisiableIndex.Substring(0, VisiableIndex.Length - 1)
            dgv_RejectRecord.uclHeaderText = HeaderText
            dgv_RejectRecord.uclVisibleColIndex = VisiableIndex
            For i As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("Reason_FID").ToString.Trim = "" Then
                    dgv_RejectRecord.DisableButton(i, RejectDgvColumnsIndex.Imoprt)
                End If
            Next
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示退件紀錄"})
        End Try
    End Sub

    ''' <summary>
    ''' 取得Grid要的DS
    ''' </summary>
    ''' <param name="inputDS"></param>
    ''' <returns></returns>
    Private Function GenGridDataSet(ByVal inputDS As DataSet, ByVal GridColumnSet As String(,)) As DataSet
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("GridDT"))
        Try
            For i As Int32 = 0 To GridColumnSet.GetUpperBound(0)
                retDS.Tables(0).Columns.Add(GridColumnSet(i, 0))
            Next

            If CheckHasValue(inputDS) Then
                For Each dr As DataRow In inputDS.Tables(0).Rows
                    Dim newDr As DataRow = retDS.Tables(0).NewRow
                    For Each c As DataColumn In inputDS.Tables(0).Columns
                        If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                            newDr(c.ColumnName) = dr(c.ColumnName)
                        End If
                    Next
                    retDS.Tables(0).Rows.Add(newDr)
                Next
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid要的DS"})
        End Try
        Return retDS
    End Function


    Enum ActionKind As Integer
        CreateNewIssueRecord
        ModifyIssueRecord
    End Enum
    Private Function GetSaveDS(ByVal Action As ActionKind) As DataSet
        Dim retDS As New DataSet
        Dim retDT As DataTable = Project.Comm.JOB.JobServiceRecordDataTableFactory.getDataTableWithNoPK
        Dim pt = New Comm.JOB.JobServiceRecordDataTableFactory.JOBServiceRecordPt
        retDT.Columns.Add("Action")
        Try
            Dim newDR As DataRow = retDT.NewRow
            newDR("Action") = Action.ToString
            newDR(pt.Project_Id) = cbo_Project.SelectedValue
            newDR(pt.System_Code) = cbo_System.SelectedValue
            newDR(pt.Function_Code) = cbo_Function.SelectedValue
            newDR(pt.Estimated_Finish_Date) = dtp_Estimated_Finish_Date.GetUsDateStr
            newDR(pt.Receive_DateTime) = dtp_ReceiveDate.GetUsDateStr & " " & txt_ReceiveTime.Text
            newDR(pt.Contact_Way) = cbo_Contact_Way.SelectedValue
            newDR(pt.Contact_User) = txt_Contact_User.Text
            newDR(pt.Contact_Note) = txt_Contact_Note.Text
            newDR(pt.Note) = txt_Note.Text
            newDR(pt.Processing_Approach) = txt_Processing_Approach.Text
            newDR(pt.Processing_Cost) = txt_Processing_Cost.Text
            newDR(pt.Processing_Employee_Code) = cbo_Processing_Employee_Code.SelectedValue
            newDR(pt.Issue_Classify) = cbo_IssueClassify.SelectedValue
            newDR(pt.Issue_Description) = txt_Issue_Description.Text
            newDR(pt.Issue_Status) = cbo_Issue_Status.SelectedValue
            newDR(pt.Issue_Source) = cbo_Issue_Source.SelectedValue
            newDR(pt.Create_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
            newDR(pt.Modified_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
            newDR(pt.Hospital_Code) = cbo_Hosp.SelectedValue
            If txt_UploadPath.Text.Length > 0 Then
                newDR(pt.Att_FID) = ProjectClientBP.getInstance.ProcessAttachments(txt_UploadPath.Text.Split(";"))
            End If
            If Action = ActionKind.ModifyIssueRecord Then
                newDR(pt.Issue_Id) = btn_Update.Tag

            End If


            retDT.Rows.Add(newDR)
            retDS.Tables.Add(retDT)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid要的DS"})
        End Try
        Return retDS
    End Function

    ''' <summary>
    ''' 檢核(存檔前)
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckBeforeSave() As Boolean
        Try
            If cbo_Hosp.SelectedValue.ToString.Trim = "" Then
                cbo_Hosp.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "所屬醫院未填!!")
                Return True
            Else
                cbo_Hosp.BackColor = System.Drawing.Color.White
            End If
            If cbo_Project.SelectedValue.ToString.Trim = "" Then
                cbo_Project.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "所屬專案未填!!")
                Return True
            Else
                cbo_Project.BackColor = System.Drawing.Color.White
            End If

            If cbo_System.SelectedValue.ToString.Trim = "" Then
                cbo_System.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "系統別未填!!")
                Return True
            Else
                cbo_System.BackColor = System.Drawing.Color.White
            End If


            If cbo_Function.SelectedValue.ToString.Trim = "" Then
                cbo_Function.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "所屬功能未填!!")
                Return True
            Else
                cbo_Function.BackColor = System.Drawing.Color.White
            End If

            If cbo_Issue_Source.SelectedValue.ToString.Trim = "" Then
                cbo_Issue_Source.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "未選來源!!")
                Return True
            Else
                cbo_Issue_Source.BackColor = System.Drawing.Color.White
            End If


            If cbo_IssueClassify.SelectedValue.ToString.Trim = "" Then
                cbo_IssueClassify.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "未選分類!!")
                Return True
            Else
                cbo_IssueClassify.BackColor = System.Drawing.Color.White
            End If

            If dtp_ReceiveDate.GetUsDateStr.Replace("/", "") = "" Then
                dtp_ReceiveDate.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "接收日期未填!!")
                Return True
            Else
                dtp_ReceiveDate.BackColor = System.Drawing.Color.White
            End If

            If txt_ReceiveTime.Text.Replace(":", "").Trim = "" Then
                txt_ReceiveTime.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "接收時間未填!!")
                Return True
            Else
                txt_ReceiveTime.BackColor = System.Drawing.Color.White
            End If

            If txt_Contact_User.Text = "" Then
                txt_Contact_User.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "提出單位/使用者 未填!!")
                Return True
            Else
                txt_Contact_User.BackColor = System.Drawing.Color.White
            End If

            'If cbo_Contact_Way.SelectedValue.ToString.Trim = "" Then
            '    cbo_Contact_Way.BackColor = System.Drawing.Color.Red
            '    MessageHandling.ShowWarnMsg("CMMCMMB300", "聯絡方式 未填!!")
            '    Return True
            'Else
            '    cbo_Contact_Way.BackColor = System.Drawing.Color.White
            'End If

            If cbo_Processing_Employee_Code.SelectedValue.ToString.Trim = "" Then
                cbo_Processing_Employee_Code.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "處理人員 未填!!")
                Return True
            Else
                cbo_Processing_Employee_Code.BackColor = System.Drawing.Color.White
            End If

            If cbo_Issue_Status.SelectedValue.ToString.Trim = "" Then
                cbo_Issue_Status.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "處理狀況 未填!!")
                Return True
            Else
                cbo_Issue_Status.BackColor = System.Drawing.Color.White
            End If

            If txt_Issue_Description.Text = "" Then
                txt_Issue_Description.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "問題描述 未填!!")
                Return True
            Else
                txt_Issue_Description.BackColor = System.Drawing.Color.White
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢核(存檔前)"})
        End Try
        Return False
    End Function

    Private Sub SetDataToControls(ByVal row As DataRow, ByVal Status As GridColumnsIndex)
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "載入中，請稍後‧‧‧")

            cbo_Hosp.SelectedValue = row("Hospital_Code").ToString.Trim
            cbo_Project.SelectedValue = row("Project_Id").ToString.Trim
            cbo_System.SelectedValue = row("System_Code").ToString.Trim
            cbo_Function.SelectedValue = row("Function_Code").ToString.Trim
            cbo_IssueClassify.SelectedValue = row("Issue_Classify").ToString.Trim
            cbo_Issue_Source.SelectedValue = row("Issue_Source").ToString.Trim
            cbo_Issue_Status.SelectedValue = row("Issue_Status").ToString.Trim
            cbo_Processing_Employee_Code.SelectedValue = row("Processing_Employee_Code").ToString.Trim
            dtp_ReceiveDate.SetValue(CDate(row("Receive_DateTime").ToString.Trim).ToString("yyyy/MM/dd"))
            txt_ReceiveTime.Text = CDate(row("Receive_DateTime").ToString.Trim).ToString("HH:mm")
            If IsDate(row("Estimated_Finish_Date").ToString.Trim) Then
                dtp_Estimated_Finish_Date.SetValue(row("Estimated_Finish_Date").ToString.Trim)
            End If
            txt_Contact_Note.Text = row("Contact_Note").ToString.Trim
            txt_Contact_User.Text = row("Contact_User").ToString.Trim
            txt_Processing_Cost.Text = row("Processing_Cost").ToString.Trim
            txt_Issue_Description.Text = row("Issue_Description").ToString.Trim
            txt_Processing_Approach.Text = row("Processing_Approach").ToString.Trim
            txt_Note.Text = row("Note").ToString.Trim
            Select Case Status
                Case GridColumnsIndex.Import
                    btn_CreateIssueRecord.Enabled = True
                    btn_Update.Enabled = False
                    cbo_Project.Enabled = True
                    cbo_System.Enabled = True
                    cbo_Function.Enabled = True
                    cbo_Hosp.Enabled = True
                    cbo_IssueClassify.Enabled = True
                    cbo_Issue_Source.Enabled = True
                    cbo_Issue_Status.Enabled = True
                Case GridColumnsIndex.Update
                    btn_CreateIssueRecord.Enabled = False
                    btn_Update.Enabled = True
                    cbo_Project.Enabled = False
                    cbo_System.Enabled = False
                    cbo_Function.Enabled = False
                    cbo_Hosp.Enabled = False
                    cbo_IssueClassify.Enabled = False
                    cbo_Issue_Source.Enabled = False
                    cbo_Issue_Status.Enabled = False
                    btn_Update.Tag = row("Issue_Id").ToString.Trim
            End Select

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定資料"})
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
    End Sub


    Private Function CheckCanBeCancel(ByVal rowIndex As Int32) As Boolean
        Try


            Select Case CInt(dgv_IssueList.GetDBDS.Tables(0).Rows(rowIndex).Item("Issue_Status"))
                Case IssueStatus.AssignAlready, IssueStatus.Finish, IssueStatus.Close
                    Return False

            End Select

            If dgv_IssueList.GetDBDS.Tables(0).Rows(rowIndex).Item("Create_User").ToString.Equals(CurrentUserID) Then
                Return True
            Else
                Return False
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定資料"})
        End Try
        Return True
    End Function


    Private Sub LoarRejectRecord(ByVal IssueId As String)
        pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "載入中，請稍後‧‧‧")

        Try
            Dim IsClose As Boolean = CInt(dgv_IssueList.GetDBDS().Tables(0).Rows(dgv_IssueList.CurrentCell.RowIndex).Item("Issue_Status").ToString.Trim) = CInt(ReplyType.Close)
            rdb_Close.Enabled = Not IsClose
            rdb_Reject.Enabled = Not IsClose
            btn_Confirm.Enabled = Not IsClose
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.LoarRejectRecord)
            SendDS.Tables(0).Rows.Add(ActionName.LoarRejectRecord.ToString,
                                      dgv_IssueList.GetDBDS().Tables(0).Rows(dgv_IssueList.CurrentCell.RowIndex).Item("Issue_Id").ToString.Trim)

            Dim ResultDS As DataSet = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(SendDS)
            If CheckHasValue(ResultDS) Then
                ShowRejectDgv(GenGridDataSet(ResultDS, RejectDgvGridColumnsAndHeaderText))
            Else
                ShowRejectDgv(GenGridDataSet(New DataSet, RejectDgvGridColumnsAndHeaderText))
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入退件紀錄"})
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
    End Sub
    Enum ReplyType As Integer
        Close = 5
        Reject = 6
    End Enum
    Private Sub CreateNewReplyRecord(ByVal IssueId As String, ByVal Type As ReplyType)
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.CreateNewServiceRejectRecord)
            Dim dr As DataRow = SendDS.Tables(0).NewRow

            dr("Action") = ActionName.CreateNewServiceRejectRecord.ToString
            dr(rejectDTPt.Issue_Id) = IssueId
            dr(rejectDTPt.Create_User) = CurrentUserID
            dr(rejectDTPt.Modified_User) = CurrentUserID
            Select Case Type
                Case ReplyType.Reject
                    dr(rejectDTPt.Reason_FID) = ProjectClientBP.getInstance.GetRTFFID(rtb_Reason)
            End Select
            dr(rejectDTPt.Reply_Type) = CInt(Type)

            SendDS.Tables(0).Rows.Add(dr)
            Dim retDS As DataSet = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                rtb_Reason.Clear()
                TabControl1.SelectedIndex = 0
                btn_Query.PerformClick()
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被新增")
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增紀錄"})

        End Try

    End Sub





#End Region

End Class