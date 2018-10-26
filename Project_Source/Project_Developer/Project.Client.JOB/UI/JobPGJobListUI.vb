'/*
'*****************************************************************************
'*
'*    Page/Class Name:  PG工作清單
'*              Title:	JobPGJobListUI
'*        Description:	提供PG查看未完成工作事項
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-04-19
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-04-19
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports JOBClientServiceFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections
Imports System.Net
Imports System.Text
Imports System.IO
Imports Syscom.Client.Servicefactory
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports Syscom.Client.FTM
Imports System.Collections.Generic
Imports System.IO.Compression
Imports System.Drawing
Imports Microsoft.TeamFoundation.Client
Imports Microsoft.TeamFoundation.VersionControl.Client
Imports System.Linq

Public Class JobPGJobListUI
    Inherits BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"
    Private gblReportFID As String = ""
    Private JobPGSubmitUI As JobPGSubmitUI = Nothing
    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    Dim FTPFolder As Data.DataTable = Nothing

    Private GridColumns As String() = {"派工編號", "工作狀態", "派工日期", "預計完成日", "派工人員", "專案代碼", "專案名稱", "所屬醫院", "系統代碼", "系統名稱", "功能代碼", "功能名稱", "需求類別", "主旨", "處理狀況", "查看", "FID", "Issue_Desc", "RTF_FID", "Reject_Flag", "作廢", "Seq_No", "需交測試報告", "Hospital_Code", "已上傳測報", "SD_Note", "SA_DeadLine", "SA_Cost", "SD_DeadLine", "SD_Cost", "Job_Special_Status"}
    Private GridVisibleColIndex As String = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,20,22,24"
    Private GridTodoListColumns As String() = {"派工編號", "預估完成日", "主旨", "內容描述"}
    Private GridTodoListVisibleColIndex As String = "0,1,2,3,4"

    Private JobList As DataSet = Nothing
    Private gblSavePath As New ApplicationServices.ApplicationBase
    Private ReplyDialogUI As JobSAReplyDialogUI = Nothing

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Job As IJOBServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobPGJobListUI
    Public Shared Function GetInstance() As JobPGJobListUI
        If myInstance Is Nothing Then
            myInstance = New JobPGJobListUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "

    Enum GridIndex As Int32
        JOB_Code
        JOB_Status
        Assign_Date
        Issue_Deadline
        Assign_User
        Project_ID
        Project_Name
        Hosp_Code
        System_Code
        System_Name
        Function_Code
        Function_Name
        Issue_Classify
        Mail_Subject
        Status
        Check
    End Enum


#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Private Function QueryData() As Boolean

        Try
            ClearAll()
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QyeryPGJobList)
            Dim status As String = ""
            If rbt_All.Checked Then
                status = "All"
            ElseIf rbt_Finish.Checked Then
                status = "Finish"
            ElseIf rbt_UnFinish.Checked Then
                status = "UnFinish"
            ElseIf rbt_Reply.Checked Then
                status = "Reply"
            ElseIf rbt_UnProcess.Checked Then
                status = "UnProcess"
            ElseIf rbt_Cancel.Checked Then
                status = "Cancel"
            End If

            SendDS.Tables(0).Rows.Add("QyeryPGJobList", CurrentUserID, status, ucl_AssignDate.GetTimeInterval(0), ucl_AssignDate.GetTimeInterval(1))
            JobList = Job.PRJDoAction(SendDS)


            initialGrid(GetDataGridDS(JobList))

            EmgJobAlert()


            Dim TodoListDS As New DataSet
            TodoListDS.Tables.Add(JobList.Tables("TodoList").Copy)
            dgv_ToDoList.Initial(TodoListDS, String.Join(",", GridTodoListColumns), GridTodoListVisibleColIndex)

            TabControl1.TabPages(1).Enabled = False
            TabControl1.TabPages(2).Enabled = False



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try
        Return True
    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()
            Label1.Text = "登錄者:" & AppContext.userProfile.userName
            initialComboBox()
            QueryData()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub initialComboBox()
        Try
            Dim IssueLevel As String = PubServiceManager.getInstance.GetPubConfigValue("JOB_Issue_Level")
            Dim IssueCost As String = PubServiceManager.getInstance.GetPubConfigValue("JOB_Issue_Cost_Time")
            Dim IssueLevelDS As New DataSet
            IssueLevelDS.Tables.Add(New DataTable)
            IssueLevelDS.Tables(0).Columns.Add("Code_Id")
            IssueLevelDS.Tables(0).Columns.Add("Code_Name")
            Dim IssueCostDS As New DataSet
            IssueCostDS.Tables.Add(New DataTable)
            IssueCostDS.Tables(0).Columns.Add("Code_Id")
            IssueCostDS.Tables(0).Columns.Add("Code_Name")
            Dim dr As DataRow

            For Each s As String In IssueLevel.Split(",")
                dr = IssueLevelDS.Tables(0).NewRow
                dr("Code_Id") = s.Split("-")(0)
                dr("Code_Name") = s.Split("-")(1)
                IssueLevelDS.Tables(0).Rows.Add(dr.ItemArray)
            Next
            For Each s As String In IssueCost.Split(",")
                dr = IssueCostDS.Tables(0).NewRow
                dr("Code_Id") = s.Split("-")(0)
                dr("Code_Name") = s.Split("-")(1)
                IssueCostDS.Tables(0).Rows.Add(dr.ItemArray)
            Next

            cbo_IssueLevel.DataSource = IssueLevelDS.Tables(0).Copy
            cbo_IssueLevel.uclValueIndex = "0"
            cbo_IssueLevel.uclDisplayIndex = "0,1"
            'cbo_CostTime.DataSource = IssueCostDS.Tables(0).Copy
            'cbo_CostTime.uclValueIndex = "0"
            'cbo_CostTime.uclDisplayIndex = "0,1"


            Dim tfsCbo As New DataSet
            tfsCbo.Tables.Add(New DataTable("TFS"))
            tfsCbo.Tables(0).Columns.Add("Code_Id")
            tfsCbo.Tables(0).Columns.Add("Code_Name")
            tfsCbo.Tables(0).Rows.Add("http://hisap2.syscom.com.tw:8080/tfs/DefaultCollection", "台北版控")
            tfsCbo.Tables(0).Rows.Add("http://60.249.205.145:8080/tfs/DefaultCollection", "高雄版控")

            cbo_TFSAddress.DataSource = tfsCbo.Tables(0).Copy
            cbo_TFSAddress.uclDisplayIndex = "1"
            cbo_TFSAddress.uclValueIndex = "0"
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Private Sub LoadServiceManager()

        Try

            Job = JOBServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-19</remarks>
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
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
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

#End Region

#Region "     必填檢查 "



#End Region

#Region "     事件集合 "

    Private Sub dgv_JobList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_JobList.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Try
            If dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Reject_Flag").ToString.Trim.Equals("1") Then
                ReplyDialogUI = New JobSAReplyDialogUI(JobSAReplyDialogUI.CallType.PGCheck, dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("JOB_Code").ToString.Trim, False)
                ReplyDialogUI.ShowDialog()
            End If
            If dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("RTF_FID").ToString.Trim.Length > 0 Then
                rtb_SANote.LoadFile(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("RTF_FID")))
            Else
                btn_DownLoadFile.Enabled = False
            End If
            rtb_SDNote.Text = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("SD_Note").ToString.Trim
            'rtb_PGNote.Text = "需求:" & dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Mail_Subject").ToString.Trim & vbCrLf
            btn_DownLoadFile.Enabled = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("FID").ToString.Trim.Length > 0
            TabControl1.TabPages(1).Enabled = Not (dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Status").ToString.Trim.Equals("已完成") OrElse dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Cancel").ToString.Trim.Equals("Y"))
            TabControl1.TabPages(2).Enabled = Not (dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Status").ToString.Trim.Equals("已完成") OrElse dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Cancel").ToString.Trim.Equals("Y"))
            Select Case e.ColumnIndex
                Case CInt(GridIndex.Check)
                    TabControl1.SelectedIndex = 1
            End Select



        Catch ex As Exception
        Finally
            If ReplyDialogUI IsNot Nothing Then
                ReplyDialogUI.Dispose()
                ReplyDialogUI = Nothing
            End If
        End Try

    End Sub

    Private Sub dgv_JobList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_JobList.CellDoubleClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        TabControl1.TabPages(1).Enabled = True
        TabControl1.TabPages(2).Enabled = True
        Try

            If dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("RTF_FID").ToString.Trim.Length > 0 Then
                rtb_SANote.LoadFile(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("RTF_FID")))
            Else
                rtb_SANote.Text = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Issue_Desc").ToString.Trim
            End If
            btn_DownLoadFile.Enabled = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("FID").ToString.Trim.Length > 0

            dtp_SA_DeadLine.SetValue(dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("SA_DeadLine"))
            dtp_SD_DeadLine.SetValue(dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Issue_Desc"))
            txt_SA_Cost.Text = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("SA_Cost").ToString.Trim
            txt_SD_Cost.Text = dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("SD_Cost").ToString.Trim

            If dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("Reject_Flag").ToString.Trim.Equals("1") Then
                ReplyDialogUI = New JobSAReplyDialogUI(JobSAReplyDialogUI.CallType.PGCheck, dgv_JobList.GetDBDS.Tables(0).Rows(e.RowIndex)("JOB_Code").ToString.Trim, False)
                ReplyDialogUI.ShowDialog()
            End If

            TabControl1.SelectedIndex = 1

        Catch ex As Exception
        Finally
            If ReplyDialogUI IsNot Nothing Then
                ReplyDialogUI.Dispose()
                ReplyDialogUI = Nothing
            End If
        End Try

    End Sub

    ''' <summary>
    ''' 頁籤切換
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Try

            Select Case TabControl1.SelectedTab.Name
                Case "tp_DBModifiy"

                    Dim JobDBModifyReplyUI = New JobDBModifyReplyUI()
                    JobDBModifyReplyUI.TopLevel = False
                    JobDBModifyReplyUI.Parent = Panel_DBModifiy
                    JobDBModifyReplyUI.Dock = DockStyle.Fill
                    JobDBModifyReplyUI.Show()


            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"頁籤切換"})
        End Try



    End Sub

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "
    ''' <summary>
    ''' 連結TFS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_LinkTfs_Click(sender As Object, e As EventArgs) Handles btn_LinkTfs.Click
        Lock(Me)
        Try

            If txt_TfsUserId.Text = "" OrElse txt_TfsPassword.Text = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "帳號或密碼不得為空")
                Exit Sub
            End If
            If cbo_TFSAddress.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "尚未選擇簽入版控位置")
                Exit Sub
            End If

            ulb_WorkSpaces.Items.Clear()

            SetTfsLoginInfo(cbo_TFSAddress.SelectedValue, txt_TfsUserId.Text, txt_TfsPassword.Text)

            For Each wk As Workspace In GetAllWorkSpace(txt_TfsUserId.Text)
                ulb_WorkSpaces.Items.Add(wk.Name)

            Next

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"連結TFS"})
        Finally
            UnLock(Me)
            writePwd()
        End Try
    End Sub
#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Will.Lin on 2017-04-19</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            'Select Case e.KeyCode


            '    Case Keys.F1

            '        '查詢
            '        If btn_Query.Enabled Then
            '            btn_Query.PerformClick()
            '        End If

            '        'Case Keys.Enter
            '        'Me.ProcessTabKey(True)

            'End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

        Finally

            '解除螢幕鎖定
            UnLock(Me)

        End Try

    End Sub

#End Region

#End Region

#Region "     內部函數"

    ''' <summary>
    ''' 取得Grid的ds
    ''' </summary>
    ''' <returns></returns>
    Private Function GetDataGridDS(ByVal input As DataSet) As DataSet

        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("GridDT"))
        retDS.Tables("GridDT").Columns.Add("JOB_Code")
        retDS.Tables("GridDT").Columns.Add("JOB_Status")
        retDS.Tables("GridDT").Columns.Add("Assign_Date")
        retDS.Tables("GridDT").Columns.Add("Issue_Deadline")
        retDS.Tables("GridDT").Columns.Add("Assign_User")
        retDS.Tables("GridDT").Columns.Add("Project_ID")
        retDS.Tables("GridDT").Columns.Add("Project_Name")
        retDS.Tables("GridDT").Columns.Add("Hospital_Short_Name")
        retDS.Tables("GridDT").Columns.Add("System_Code")
        retDS.Tables("GridDT").Columns.Add("System_Name")
        retDS.Tables("GridDT").Columns.Add("Function_Code")
        retDS.Tables("GridDT").Columns.Add("Function_Name")
        retDS.Tables("GridDT").Columns.Add("Issue_Classify")
        retDS.Tables("GridDT").Columns.Add("Mail_Subject")
        retDS.Tables("GridDT").Columns.Add("Status")
        retDS.Tables("GridDT").Columns.Add("Check")
        retDS.Tables("GridDT").Columns.Add("FID")
        retDS.Tables("GridDT").Columns.Add("Issue_Desc")
        retDS.Tables("GridDT").Columns.Add("RTF_FID")
        retDS.Tables("GridDT").Columns.Add("Reject_Flag")
        retDS.Tables("GridDT").Columns.Add("Cancel")
        retDS.Tables("GridDT").Columns.Add("Seq_No")
        retDS.Tables("GridDT").Columns.Add("Test_Report_Flag")
        retDS.Tables("GridDT").Columns.Add("Hospital_Code")
        retDS.Tables("GridDT").Columns.Add("Uploaded")
        retDS.Tables("GridDT").Columns.Add("SD_Note")
        retDS.Tables("GridDT").Columns.Add("SA_DeadLine")
        retDS.Tables("GridDT").Columns.Add("SA_Cost")
        retDS.Tables("GridDT").Columns.Add("SD_DeadLine")
        retDS.Tables("GridDT").Columns.Add("SD_Cost")
        retDS.Tables("GridDT").Columns.Add("Job_Special_Status")

        Try
            For Each dr As DataRow In input.Tables(0).Rows
                Dim dr1 As DataRow = retDS.Tables(0).NewRow
                dr1("JOB_Code") = dr("JOB_Code")
                dr1("Assign_Date") = dr("Assign_Date")
                dr1("Assign_User") = dr("Assign_User")
                dr1("Project_Name") = dr("Project_Name")
                dr1("System_Name") = dr("System_Name")
                dr1("Function_Name") = dr("Function_Name")
                dr1("Project_ID") = dr("Project_ID")
                dr1("System_Code") = dr("System_Code")
                dr1("Function_Code") = dr("Function_Code")
                dr1("Issue_Classify") = dr("Issue_Classify")
                If IsDate(dr("Finish_Date")) Then
                    dr1("Status") = "已完成"
                ElseIf dr("Reject_Flag").ToString.Trim.Equals("1") Then
                    dr1("Status") = "SA測試未通過"
                ElseIf IsDate(dr("Reply_Date")) Then
                    dr1("Status") = "已提交"
                Else
                    dr1("Status") = "未處理"
                End If
                dr1("Check") = ""
                dr1("FID") = dr("FID")
                dr1("RTF_FID") = dr("RTF_FID")
                dr1("Issue_Desc") = dr("Issue_Desc")
                dr1("Reject_Flag") = dr("Reject_Flag")
                dr1("Cancel") = dr("Cancel")
                dr1("Seq_No") = dr("Seq_No")
                dr1("Mail_Subject") = dr("Mail_Subject")
                dr1("Test_Report_Flag") = dr("Test_Report_Flag")
                dr1("Hospital_Short_Name") = dr("Hospital_Short_Name")
                dr1("Hospital_Code") = dr("Hospital_Code")
                dr1("Issue_Deadline") = dr("Issue_Deadline")
                dr1("Uploaded") = dr("Uploaded")
                dr1("SD_Note") = dr("SD_Note")
                dr1("SA_DeadLine") = dr("SA_DeadLine")
                dr1("SA_Cost") = dr("SA_Cost")
                dr1("SD_DeadLine") = dr("SD_DeadLine")
                dr1("SD_Cost") = dr("SD_Cost")
                dr1("JOB_Status") = dr("JOB_Status")
                dr1("Job_Special_Status") = dr("Job_Special_Status")
                retDS.Tables(0).Rows.Add(dr1)
            Next



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PG工作清單"})
        End Try
        Return retDS
    End Function

    Private Sub initialGrid(ByVal ds As DataSet)

        Dim ht As New Hashtable

        Try
            Dim btnCellCheck As New ButtonCell
            btnCellCheck.Text = "查看"
            Dim btnCellSubmit As New ButtonCell
            btnCellSubmit.Text = "提交"
            Dim dtpCell As New DtpCell
            Dim cboCell As New ComboBoxCell
            Dim cboDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode("9999", False)
            cboCell.Ds = cboDS.Copy

            cboCell.DisplayIndex = 1
            cboCell.ValueIndex = 0


            Dim JOBStatusDS As New DataSet
            Dim cboStatusCell As New ComboBoxCell
            JOBStatusDS.Tables.Add(New DataTable("Status"))
            JOBStatusDS.Tables(0).Columns.Add("Code_Id")
            JOBStatusDS.Tables(0).Columns.Add("Code_Name")
            JOBStatusDS.Tables(0).Rows.Add("0", "待辦")
            JOBStatusDS.Tables(0).Rows.Add("1", "進行中")
            JOBStatusDS.Tables(0).Rows.Add("2", "已完成")
            cboStatusCell.Ds = JOBStatusDS.Copy

            cboStatusCell.DisplayIndex = 1
            cboStatusCell.ValueIndex = 0


            ht.Add(-1, ds)
            ht.Add(CInt(GridIndex.JOB_Status), cboStatusCell)
            ht.Add(CInt(GridIndex.Assign_Date), dtpCell)
            ht.Add(CInt(GridIndex.Check), btnCellCheck)
            ht.Add(CInt(GridIndex.Issue_Classify), cboCell)
            ht.Add(CInt(GridIndex.Issue_Deadline), New DtpCell)
            dgv_JobList.Initial(ht, String.Join(",", GridColumns), GridVisibleColIndex)


            For i As Int32 = 2 To GridColumns.Length - 1
                dgv_JobList.SetColReadOnly(i, True)
            Next
            Dim JobOnIt As Boolean = ds.Tables(0).AsEnumerable.Where(Function(c) c.Item("JOB_Status").ToString.Trim = "1").Count > 0
            For x As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(x).Item("Cancel").ToString.Trim.Equals("Y") Then
                    For z As Int32 = 0 To GridColumns.Length - 1
                        dgv_JobList.SetRowColor(x, Color.Crimson)
                    Next
                    dgv_JobList.SetRowReadOnly(x, True)
                    Continue For
                End If
                For z As Int32 = 0 To GridColumns.Length - 1
                    If ds.Tables(0).Rows(x).Item("Status").Equals("已完成") Then
                        dgv_JobList.SetCellColor(z, x, Color.LightBlue)
                    ElseIf ds.Tables(0).Rows(x).Item("Status").Equals("已提交") Then
                        dgv_JobList.SetCellColor(z, x, Color.Yellow)
                    ElseIf ds.Tables(0).Rows(x).Item("Status").Equals("SA測試未通過") Then
                        dgv_JobList.SetCellColor(z, x, Color.OrangeRed)
                    Else
                        dgv_JobList.SetCellColor(z, x, Color.LightPink)
                    End If
                Next
            Next


            SetJOBStatus()

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PG工作清單"})
        End Try
    End Sub

    Private Sub SetJOBStatus()
        Try
            Dim JobOnIt As Boolean = dgv_JobList.GetDBDS.Tables(0).AsEnumerable.Where(Function(c) c.Item("JOB_Status").ToString.Trim = "1").Count > 0
            For i As Int32 = 0 To dgv_JobList.GetDBDS.Tables(0).Rows.Count - 1
                If JobOnIt AndAlso dgv_JobList.GetDBDS.Tables(0).Rows(i).Item("JOB_Status").ToString.Trim.Equals("1") Then
                    dgv_JobList.SetRowReadOnly(i, False)
                ElseIf dgv_JobList.GetDBDS.Tables(0).Rows(i).Item("JOB_Status").ToString.Trim.Equals("0") Then
                    dgv_JobList.SetRowReadOnly(i, JobOnIt)
                Else
                    dgv_JobList.SetRowReadOnly(i, True)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UploadFileToFTM(ByVal FilePath As String)

        Dim strFilePath As String = ""
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "上傳中，請稍後‧‧‧")
            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = FilePath  '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = Nothing '沒有縮圖的需求給nothing
            dataRow("File_Note") = "測試報告" '檔案註解
            dataRow("Create_User") = CurrentUserID '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = CurrentUserID '修改人員
            dataRow("Modified_Time") = Now '修改時間

            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(FilePath) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
            If AppContext.userProfile.userId.Length > 8 Then
                dataRow("FileSub") = AppContext.userProfile.userId.Substring(0, 8)  ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            Else
                dataRow("FileSub") = AppContext.userProfile.userId
            End If
            dataRow("FileTime") = Now '指定檔案時間
            dataRow("FID") = 0 '預設給0，後端會再重新給值
            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            Dim client = FtmServiceManager.getInstance
            Dim s() = client.uploadNewFile(dataSet)
            gblReportFID = s(0)
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")

        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", ex.ToString)
            Throw ex
        End Try
    End Sub


    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        QueryData()
    End Sub

    ''' <summary>
    ''' 提交程式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_UploadFiles_Click(sender As Object, e As EventArgs) Handles btn_UploadFiles.Click
        Try
            Lock(Me)

            If CheckBeforeSubmit() Then
                Exit Sub
            End If
            Dim PendingChangesDT As DataTable = tva_PendingChanges.GetSelectedItemsResultInDataTable(True)
            If ckb_Upload.Checked Then

                Dim jobPGSubmitUI As New JobPGSubmitUI(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index))
                jobPGSubmitUI.SetFilePath(PendingChangesDT.Select("Parent_Code_Id <> '' "))
                If Not jobPGSubmitUI.ShowDialog() Then
                    Exit Sub
                Else
                    If jobPGSubmitUI.FileName.Length > 0 Then
                        rtb_PGNote.Text = rtb_PGNote.Text & vbCrLf & " 檔案:" & jobPGSubmitUI.FileName
                    End If
                End If
            End If
            Dim CheckInChangeSetNo As Integer = 0
            '連結TFS做檔案簽入
            Try
                If ckb_LinkToTFS.Checked Then
                    CheckInChangeSetNo = CheckInFiles(version.QueryWorkspaces(ulb_WorkSpaces.SelectedItem,
                                                                                txt_TfsUserId.Text,
                                                                                Environment.MachineName)(0),
                                                     tva_PendingChanges.GetSelectedItemsResultInDataTable(True))
                    If CheckInChangeSetNo = 0 Then Exit Sub
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Try
                ProcessAttachments()

            Catch ex As Exception
                MessageHandling.ShowErrorMsg("CMMCMMB300", ex.ToString)
                Exit Sub
            End Try


            Dim JOBCode As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("JOB_Code").ToString.Trim
            Dim SystemCode As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("System_Code").ToString.Trim
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.UpdatePGJobSubmit)
            SendDS.Tables(0).Rows.Add("UpdatePGJobSubmit", JOBCode, AppContext.userProfile.userId,
                                      "Will_Lin@syscom.com.tw", AppContext.userProfile.userName, rtb_PGNote.Text,
                                      gblReportFID, SystemCode, txt_CostTime.Text, cbo_IssueLevel.SelectedValue,
                                      CheckInChangeSetNo,
                                      rtb_PGNote.Text)
            Dim resultDS As DataSet = Job.PRJDoAction(SendDS)

            If CheckMethodUtil.CheckHasValue(resultDS) AndAlso resultDS.Tables(0).Rows(0).Item(0) > 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "提交成功")
                If CheckMethodUtil.CheckHasValue(dgv_ToDoList.GetDBDS.Tables(0)) Then UpdateJOBStatus(dgv_ToDoList.GetDBDS.Tables(0).Rows(dgv_ToDoList.GetSelectedIndex(0)).Item("Job_Code").ToString.Trim, "1")
            End If
            TabControl1.SelectedTab = tp_JobList
                QueryData()

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"PG工作清單"})
        Finally
            UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' 下載SA附件檔案
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_DownLoadFile_Click(sender As Object, e As EventArgs) Handles btn_DownLoadFile.Click
        Try
            Process.Start(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim))
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 上傳測試報告
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_UploadTestReport_Click(sender As Object, e As EventArgs) Handles btn_UploadTestReport.Click
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filePaths As String() = OpenFileDialog1.FileNames
            For Each s As String In filePaths
                If CheckPathIsExist(s) Then
                    dgv_ReportPath.Rows.Add(False, s)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' 點選工作區
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ulb_WorkSpaces_Click(sender As Object, e As EventArgs) Handles ulb_WorkSpaces.Click
        Try

            GetAllPendingChangesByWorkSpace(txt_TfsUserId.Text, CType(sender, ListBox).SelectedItem)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點選工作區"})
        End Try
    End Sub


    Private Sub ckb_LinkToTFS_CheckedChanged(sender As Object, e As EventArgs) Handles ckb_LinkToTFS.CheckedChanged

        Try
            txt_TfsUserId.Enabled = CType(sender, CheckBox).Checked
            txt_TfsPassword.Enabled = CType(sender, CheckBox).Checked
            cbo_TFSAddress.Enabled = CType(sender, CheckBox).Checked
            ulb_WorkSpaces.Enabled = CType(sender, CheckBox).Checked
            tva_PendingChanges.Enabled = CType(sender, CheckBox).Checked
            btn_LinkTfs.Enabled = CType(sender, CheckBox).Checked
            ClearTFSControls()
        Catch ex As Exception

        End Try

    End Sub

    Private Function CheckPathIsExist(ByVal path As String) As Boolean

        'If dgv_Path.Rows.Count <= 0 Then Return False

        CheckPathIsExist = True
        For i As Int32 = 0 To dgv_ReportPath.Rows.Count - 1

            If dgv_ReportPath.Rows(i).Cells("FilePath").Value.ToString.Equals(path) Then
                Return False
            End If
        Next
        Return CheckPathIsExist

    End Function
    ''' <summary>
    ''' 附件打包(含簽入版控)
    ''' </summary>
    Private Sub ProcessAttachments()

        If dgv_ReportPath.Rows.Count = 0 Then Exit Sub

        Dim serverPath As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Hospital_Short_Name").ToString.Trim & "\" &
                                   dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Project_Name").ToString.Trim & "\" &
                                   Now.ToString("yyyy") & " " & Now.ToString("MM")


        If Not dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Project_Id").ToString.Trim.ToUpper.Equals("NIS") Then
            serverPath &= "\" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("System_Code").ToString.Trim()
        End If
        Dim path As String = Environment.GetEnvironmentVariable("TEMP").ToString & CurrentUserID & "\TestReport\" & serverPath
        Dim AttPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TestReport\"
        Dim AttDir As New DirectoryInfo(AttPath)
        Dim dir As New DirectoryInfo(path)


        Try
            MappingWorkSpace(serverPath, path)

            Dim FileName As String = ""


            If dir.Exists = True Then dir.Delete(True)
            Threading.Thread.Sleep(500)
            dir.Create()
            If AttDir.Exists Then AttDir.Delete(True)
            Threading.Thread.Sleep(500)
            AttDir.Create()
            For i As Int32 = 0 To dgv_ReportPath.Rows.Count - 1
                Dim FileExtension As String = System.IO.Path.GetExtension(dgv_ReportPath.Rows(i).Cells("FilePath").Value.ToString)
                FileName = Now.ToString("yyyyMMdd") & "-" &
                           dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Project_Name").ToString.Trim & "-" &
                           dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Hospital_Short_Name").ToString.Trim & "-" &
                           dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("System_Code").ToString.Trim & "-" &
                           dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Function_Name").ToString.Trim & "-" & "測試報告-" &
                           dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Mail_Subject").ToString.Trim
                If FileExtension.Contains(".doc") Then FileExtension = ".docx"
                System.IO.File.Copy(dgv_ReportPath.Rows(i).Cells("FilePath").Value.ToString, path & "\" & FileName & FileExtension, True)
                If IO.File.Exists(path & "\" & FileName & FileExtension) Then
                    System.IO.File.Copy(dgv_ReportPath.Rows(i).Cells("FilePath").Value.ToString, AttPath & FileName & FileExtension, True)
                    pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "測試報告簽入中，請稍後‧‧‧")
                    CheckInFiles(wk, path & "\" & FileName & FileExtension)
                Else
                    Throw New Exception(dgv_ReportPath.Rows(i).Cells("FilePath").Value.ToString & " 複製失敗")
                End If
            Next
            path = CompressFile(AttDir)
            UploadFileToFTM(path)

        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", ex.ToString)
            Throw ex
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
    End Sub

    Private Function CheckBeforeSubmit() As Boolean
        Try

            If dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Test_Report_Flag").ToString.Trim.Equals("Y") Then
                If dgv_ReportPath.Rows.Count = 0 Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "此需求須附測試報告!!")
                    Return True
                End If
            End If

            If txt_CostTime.Text = "" Then
                txt_CostTime.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "耗費時間未填!!")
                Return True
            Else
                txt_CostTime.BackColor = System.Drawing.Color.White
            End If

            If cbo_IssueLevel.SelectedValue = "" Then
                cbo_IssueLevel.BackColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "難易度未填!!")
                Return True
            Else
                cbo_IssueLevel.BackColor = System.Drawing.Color.White
            End If

            If ckb_LinkToTFS.Checked AndAlso ulb_WorkSpaces.SelectedItem Is Nothing Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "尚未連結本機工作區")
                Return True
            End If

            If CheckMethodUtil.CheckHasValue(dgv_ToDoList.GetDBDS.Tables(0)) Then
                If dgv_ToDoList.GetSelectedIndex Is Nothing Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "請至少選一項未辦理之工作項目")
                    Return True
                ElseIf dgv_ToDoList.GetSelectedIndex.Length > 1 Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "同時僅能啟動一項待辦項目")
                    Return True
                End If
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"提交前檢核"})
        End Try
        Return False
    End Function

#Region "     急件提醒"

    Private Sub EmgJobAlert()

        Try

            If dgv_JobList.GetDBDS().Tables(0).AsEnumerable.Where(Function(c) c.Item("Job_Special_Status").ToString = "E").Count > 0 AndAlso dgv_JobList.GetDBDS().Tables(0).AsEnumerable.Where(Function(c) c.Item("Job_Special_Status").ToString = "E" And c.Item("JOB_Status") = "1").Count = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "尚有急件工作未處理，請優先進行!!")
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Sub

#End Region


#Region "文件壓縮"

    Public Function CompressFile(directorySelected As DirectoryInfo) As String
        Dim fileFullName As String = directorySelected.Parent.FullName & "\" & directorySelected.FullName.Split("\")(directorySelected.FullName.Split("\").Length - 2) & ".zip"
        '如果檔案存在，就問是否要刪除
        Dim fileinfo As New FileInfo(fileFullName)
        If fileinfo.Exists Then fileinfo.Delete()
        ZipFile.CreateFromDirectory(directorySelected.FullName, fileFullName)
        directorySelected.Delete(True)
        Return fileFullName
    End Function

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Delete_dgv_Path()
    End Sub

    Private Sub Delete_dgv_Path()
        If dgv_ReportPath.Rows.Count <= 0 Then Exit Sub
        Dim selectRow As New Collections.Generic.List(Of DataGridViewRow)


        For i As Int32 = 0 To dgv_ReportPath.Rows.Count - 1
            If dgv_ReportPath.Rows(i).Cells(0).Value Then
                selectRow.Add(dgv_ReportPath.Rows(i))
            End If
        Next

        For Each dr As DataGridViewRow In selectRow
            dgv_ReportPath.Rows.Remove(dr)
        Next

    End Sub

    Private Sub btn_ClearPath_Click(sender As Object, e As EventArgs) Handles btn_ClearPath.Click
        dgv_ReportPath.Rows.Clear()
    End Sub

    Private Sub ClearAll()
        Try
            dgv_ReportPath.Rows.Clear()
            rtb_SANote.Clear()
            rtb_PGNote.Text = ""
            rtb_SDNote.Clear()
            gblReportFID = ""
            tva_PendingChanges.ClearAllNodes()
            ulb_WorkSpaces.Items.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ClearTFSControls()
        Try
            txt_TfsUserId.Text = ""
            txt_TfsPassword.Text = ""
            cbo_TFSAddress.SelectedValue = ""
            ulb_WorkSpaces.Items.Clear()
            tva_PendingChanges.ClearAllNodes()
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "     版本控制"
    Dim tpc As TfsTeamProjectCollection
    Dim version As VersionControlServer
    Dim wkspace As String
    Dim wk As Workspace

    Private Sub SetTfsLoginInfo(ByVal address As String, ByVal UserId As String, ByVal Password As String)
        tpc = New TfsTeamProjectCollection(New Uri(address), New System.Net.NetworkCredential(UserId, Password))
        version = tpc.GetService(GetType(VersionControlServer))
     End Sub

    ''' <summary>
    ''' 產生以及配對工作區
    ''' </summary>
    ''' <param name="ServerPath"></param>
    ''' <param name="localPath"></param>
    ''' <returns></returns>
    Private Function MappingWorkSpace(ByVal ServerPath As String, ByVal localPath As String) As Boolean

        Try
            '初始化版控資訊
            SetTfsLoginInfo("http://hisap2.syscom.com.tw:8080/tfs/DefaultCollection", CurrentUserID, "Syscom@123")
            wkspace = "TestReport_" & CurrentUserID
            Dim wkFd As WorkingFolder = New WorkingFolder("$/SyscomDocument/TestReport/" & ServerPath, localPath)
            AddHandler version.NonFatalError, AddressOf version_NonFatalError

            Workstation.Current.ReloadCache()
            Dim wss = version.QueryWorkspaces(wkspace, CurrentUserID, Environment.MachineName)
            If wss.Length = 0 Then
                wk = version.CreateWorkspace(wkspace, CurrentUserID)
            Else
                wk = wss(0)
            End If
            If Not wk.IsLocalPathMapped(localPath) Then
                Workstation.Current.EnsureUpdateWorkspaceInfoCache(version, CurrentUserID)
                wk.CreateMapping(wkFd)
            End If
            '取新版以免有未對應檔案造成無法簽入
            wk.Get()



        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", "MappingWorkSpace" & ex.ToString)
            Throw ex
        End Try
        Return False
    End Function

    Private Sub version_NonFatalError(ByVal sender As Object, ByVal e As ExceptionEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 簽版控(測試報告)
    ''' </summary>
    ''' <param name="wk">工作區</param>
    ''' <param name="astrSource">本地路徑</param>
    ''' <returns></returns>
    Function CheckInFiles(ByVal wk As Workspace, ByVal astrSource As String) As Integer

        If wk.PendAdd(astrSource) = 0 AndAlso wk.PendEdit(astrSource) = 0 Then Return 0

        Dim objItemSpec(1) As ItemSpec

        Try
            objItemSpec(0) = New ItemSpec(astrSource, RecursionType.Full)
            Return wk.CheckIn(New WorkspaceCheckInParameters(objItemSpec, "CheckIn TestReport From JobAPP"))

        Catch ex As Exception
            Try
                MessageHandling.ShowErrorMsg("CMMCMMB300", " CheckInFiles Catch" & ex.ToString)

                If wk.Undo(objItemSpec, RecursionType.Full) > 0 Then
                    wk.GetItems(objItemSpec, DeletedState.Any, ItemType.Any, False, GetItemsOptions.Download)
                    Return wk.CheckIn(New WorkspaceCheckInParameters(objItemSpec, "CheckIn TestReport From JobAPP"))
                End If
            Catch ex1 As Exception
                MessageHandling.ShowErrorMsg("CMMCMMB300", " CheckInFiles " & ex1.ToString)
                Throw ex1
            End Try
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' 取得該USER在本地所有工作區
    ''' </summary>
    ''' <param name="UserId"></param>
    ''' <returns></returns>
    Public Function GetAllWorkSpace(ByVal UserId As String) As List(Of Workspace)
        Dim list As New List(Of Workspace)
        For Each w In version.QueryWorkspaces(Nothing, UserId, Environment.MachineName)
            list.Add(w)
        Next
        Return list

    End Function
    ''' <summary>
    ''' 取得所有異動的檔案目錄
    ''' </summary>
    ''' <param name="UserId"></param>
    ''' <param name="wkSpaceName"></param>
    ''' <returns></returns>
    Public Sub GetAllPendingChangesByWorkSpace(ByVal UserId As String, ByVal wkSpaceName As String)
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "取得工作區異動項目中，請稍後‧‧‧")

            Dim pendingDataset As New DataSet
            pendingDataset.Tables.Add(New DataTable("Changes"))
            pendingDataset.Tables(0).Columns.Add("FileName")
            pendingDataset.Tables(0).Columns.Add("FileFolder")
            Dim wks = version.QueryWorkspaces(wkSpaceName, UserId, Environment.MachineName)
            Dim Floders As New List(Of String)
            If wks.Length > 0 Then
                For Each wk As Workspace In wks
                    wk.RefreshIfNeeded()
                    For Each localPath As WorkingFolder In wk.Folders
                        For Each PendingChanges As PendingChange In wk.GetPendingChanges(localPath.LocalItem, RecursionType.Full, False)
                            Dim a As String = PendingChanges.LocalItem
                            pendingDataset.Tables(0).Rows.Add(PendingChanges.FileName, PendingChanges.LocalOrServerFolder)
                        Next
                    Next
                    If CheckMethodUtil.CheckHasValue(pendingDataset) Then
                        tva_PendingChanges.SetTreeView(CreateTreeDataTable(pendingDataset), "Parent_Code_Id", "Parent_Code_Name", "Layer_Code_Id", "Layer_Code_Name", True)

                    Else
                        tva_PendingChanges.ClearAllNodes()
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "工作區無異動項目")
                    End If
                Next
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
    End Sub

    Function CheckInFiles(ByVal wk As Workspace, ByVal astrSource As DataTable) As Integer
        Dim cnt As Integer = astrSource.Select("Parent_Code_Id <> '' ").Count
        If cnt <= 0 Then
            MessageHandling.ShowWarnMsg("CMMCMMB300", "未選擇任何要簽入的檔案")
            Return 0
        End If
        Dim objItemSpec(cnt - 1) As ItemSpec
        pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "簽入中，請稍後‧‧‧")
        If rtb_PGNote.Text.ToString.Trim = "" Then
            MessageHandling.ShowWarnMsg("CMMCMMB300", "未填寫變更集備註")
            Return 0
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End If

        Try
            Dim notice As New StringBuilder
            Dim changeSetNote As String = "【V】"
            changeSetNote &= "【" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Hospital_Short_Name").ToString.Trim & "】"
            changeSetNote &= "【" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Function_Name").ToString.Trim & "】"
            changeSetNote &= "【" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Mail_Subject").ToString.Trim & "】:"
            changeSetNote &= rtb_PGNote.Text
            notice.AppendLine("本次簽入檔案如下:")
            For Each dr As DataRow In astrSource.AsEnumerable.Where(Function(c) c("Parent_Code_Id").ToString.Trim <> "" AndAlso Not c("Layer_Code_Id").ToString.EndsWith("\"))
                objItemSpec(cnt - 1) = New ItemSpec(dr("Layer_Code_Id").ToString.Trim, RecursionType.Full)
                notice.AppendLine(dr("Layer_Code_Name").ToString.Trim)
                cnt -= 1
            Next

            notice.AppendLine("修改內容:")
            notice.AppendLine(rtb_PGNote.Text)
            notice.AppendLine("是否確認簽入?")

            If MessageHandling.ShowQuestionMsg("CMMCMMB300", notice.ToString) = DialogResult.Yes Then
                Return wk.CheckIn(New WorkspaceCheckInParameters(objItemSpec, changeSetNote))
            Else
                Return 0
            End If



        Catch ex As Exception
            MessageHandling.ShowWarnMsg("CMMCMMB300", "本地檔案與TFS版本有衝突尚未解決，請排除後重新點選工作區載入")
            tva_PendingChanges.ClearAllNodes()
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
        Return 0
    End Function
    ''' <summary>
    ''' 產生樹狀結構資料表
    ''' </summary>
    ''' <param name="pendingDataset"></param>
    ''' <returns></returns>
    Private Function CreateTreeDataTable(ByVal pendingDataset As DataSet) As DataTable
        Dim treeDS As New DataSet

        Try
            treeDS.Tables.Add(New DataTable("Tree"))
            treeDS.Tables(0).Columns.Add("Parent_Code_Id")
            treeDS.Tables(0).Columns.Add("Parent_Code_Name")
            treeDS.Tables(0).Columns.Add("Layer_Code_Id")
            treeDS.Tables(0).Columns.Add("Layer_Code_Name")
            Dim query = (From q In pendingDataset.Tables(0)
                         Group By Folder_Path = q.Item("FileFolder") Into grp = Group).
                     Select(Function(c) New With {.Folder_Path = c.Folder_Path}).ToList
            Dim TempList As New List(Of String())
            For Each d In query
                TempList.Add(d.Folder_Path.ToString.Split("\"))
            Next
            '產生所有根目錄
            For Each s1 As String() In TempList
                Dim FullPath As String = ""
                For Each s2 As String In s1
                    Dim drP As DataRow = treeDS.Tables(0).NewRow
                    If FullPath = "" Then
                        drP(0) = ""
                        drP(1) = ""
                    Else
                        drP(0) = FullPath
                        drP(1) = FullPath.ToString.Substring(0, FullPath.ToString.Length - 1)
                    End If
                    FullPath &= s2 & "\"
                    drP(2) = FullPath
                    drP(3) = s2
                    If treeDS.Tables(0).Select("Layer_Code_Id='" & FullPath & "'").Length <> 0 Then Continue For
                    treeDS.Tables(0).Rows.Add(drP.ItemArray)
                Next
            Next
            '加上所有的Leaf
            For i As Int32 = 0 To pendingDataset.Tables(0).Rows.Count - 1
                Dim drC As DataRow = treeDS.Tables(0).NewRow
                drC(0) = pendingDataset.Tables(0).Rows(i).Item("FileFolder").ToString & "\"
                drC(1) = pendingDataset.Tables(0).Rows(i).Item("FileFolder").ToString.Substring(0, pendingDataset.Tables(0).Rows(i).Item("FileFolder").ToString.Length - 1)
                drC(2) = pendingDataset.Tables(0).Rows(i).Item("FileFolder").ToString & "\" & pendingDataset.Tables(0).Rows(i).Item("FileName").ToString
                drC(3) = pendingDataset.Tables(0).Rows(i).Item("FileName").ToString
                treeDS.Tables(0).Rows.Add(drC.ItemArray)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return treeDS.Tables(0).Copy
    End Function


#End Region

#Region "     版控密碼暫存"

    Dim mydocpath As String = ""


    Private Function CheckTempPassword() As Boolean
        Try
            Return IO.File.Exists(mydocpath)

        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try
        Return False
    End Function

    Private Sub writePwd()
        Try
            Dim strUser As String = txt_TfsUserId.Text.Trim.ToUpper
            Dim strPwd As String = txt_TfsPassword.Text.Trim

            Using outfile As System.IO.StreamWriter = New System.IO.StreamWriter(mydocpath, False)
                outfile.WriteLine(strUser)
                outfile.WriteLine(strPwd)
            End Using
        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub readPwd()
        Try
            If System.IO.File.Exists(mydocpath) Then
                Dim objReader As New System.IO.StreamReader(mydocpath)
                Dim sLine As String = ""
                Dim arrText As New ArrayList()
                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()
                txt_TfsUserId.Text = arrText(0).ToString
                txt_TfsPassword.Text = arrText(1)
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub cbo_TFSAddress_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_TFSAddress.SelectedIndexChanged
        Try


            Select Case cbo_TFSAddress.Text
                Case "台北版控"
                    mydocpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\tpePassWord.txt"
                Case "高雄版控"
                    mydocpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\kmuhPassWord.txt"
            End Select
            If CheckTempPassword() Then
                readPwd()
            Else
                txt_TfsPassword.Text = ""
                txt_TfsUserId.Text = ""
            End If


        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try
    End Sub
#Region "    更新工作狀態"
    Private Sub dgv_JobList_CellValueChanged(sender As Object, e As EventArgs) Handles dgv_JobList.CellValueChanged
        If dgv_JobList.CurrentCell.ColumnIndex <> GridIndex.JOB_Status Then Exit Sub

        Try
            If dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentCell.RowIndex).Item("JOB_Status").Equals("2") Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無法自行選擇完成，請透過提交更新工作狀態")
            Else
                SetJOBStatus()
                UpdateJOBStatus(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentCell.RowIndex).Item("JOB_Code"), dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentCell.RowIndex).Item("JOB_Status"))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            btn_Query.PerformClick()
        End Try
    End Sub
    Private Sub UpdateJOBStatus(ByVal JOB_Code As String, ByVal JOB_Status As String)

        Try
            Dim SendDS As New DataSet
            SendDS.Tables.Add(New DataTable("Action"))
            SendDS.Tables(0).Columns.Add("Action")
            SendDS.Tables(0).Columns.Add("JOB_Code")
            SendDS.Tables(0).Columns.Add("Status")
            SendDS.Tables(0).Columns.Add("Create_User")
            SendDS.Tables(0).Rows.Add("UpdateJobStatus", JOB_Code, JOB_Status, CurrentUserID)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            If CheckMethodUtil.CheckHasValue(retDS) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "工作狀態已更新")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#End Region

#End Region

#End Region

End Class

