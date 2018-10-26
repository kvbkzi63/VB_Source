Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Windows.Forms
Imports JOBClientServiceFactory
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.Drawing
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports System.ServiceModel
Imports System.Collections
Imports Syscom.Comm.Utility.ScreenUtil
Imports System.Text.RegularExpressions
Imports Project.Comm.JOB
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Client.UCL
Imports System.Diagnostics
Imports System.Linq


Public Class JobSAJobListUI
    Inherits Syscom.Client.UCL.BaseFormUI
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance


#Region "     變數宣告"
    Protected initialDS As DataSet
    Protected job As IJOBServiceManager = Nothing
    Protected issueClassify As DataTable
    Protected jobListDT As DataTable = Nothing
    Protected dgvDT As New DataTable
    Protected dgvJobListColumnsText As String = "派工編號,派工人員,分類 ,派工日,預期完成日,SD預期完成日,主旨,專案名稱,所屬醫院,系統別,作業別,需求評估時間,負責PG,處理狀況,下載測試報告,測試回覆,作廢,SD覆核,展延交期,SA-Spec,SD-Spec,SA修改,SD修改"
    Protected dgvJobListColumns As String() = {"JOB_Code", "Assign_User", "Issue_Classify", "Assign_Date", "Issue_Deadline", "SD_Issue_Deadline", "Mail_Subject", "Project_Name", "Hospital_Short_Name", "System_Name", "Function_Name", "Estimate_Cost", "Employee_Name", "Status", "Reply", "DownLoadTestReport", "Function_Code", "Issue_Desc", "Cancel", "SD_Employee_Code", "Test_Report_Flag", "FID", "SD_Confirm", "SD_Note", "System_Code", "Hospital_Code", "Project_Id", "PG_Employee_Code", "Delay_Days", "SA_Spec_FID", "SD_Spec_FID", "RTF_FID"}
    Protected dgvJobListVisitIndex As String = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22"
    Protected dgvModifiedListColumnsText As String() = {"專案名稱", "申請日", "DB名稱", "Table名稱", "異動類別", "負責人員", "處理狀況", "下載異動申請表", "查看回覆"}
    Protected dgvModifiedLisdColumns As String() = {"Project_Name", "Create_Time", "DB_Name", "Table_Name", "Modified_Classify", "DBA_Name", "Status", "FID", "Project_ID", "Seq_No", "Reject_Reason"}
    Protected dgvModifiedLisdVisitIndex As String = "0,1,2,3,4,5,6,7,8"
    Protected dgvIssueRecordListColumnsText As String = "提出日,需求類別,所屬專案,所屬醫院,系統別,功能名稱,需求編號,需求描述,紀錄者,來源,附件,預計完成日"
    Protected dgvIssueRecordListColumns As String() = {"Receive_Date", "Issue_Classify", "Project_Name", "Hospital_Short_Name", "System_Name", "Function_Name", "Issue_Id", "Issue_Description", "Employee_En_Name", "Source", "Project_Id", "System_Code", "Function_Code", "Hospital_Code", "Att_FID", "Version_Id", "Test_Version", "Estimated_Finish_Date"}
    Protected dgvIssueRecordListVisitIndex As String = "0,1,2,3,4,5,6,7,8,9,10"
    Protected dgvPhraseColumns As String() = {"Phrase_Content"}
    Protected dgvPhraseVisitIndex As String = "0"

    Protected MailUi As Syscom.Client.UCL.UclMutiGridUI = New Syscom.Client.UCL.UclMutiGridUI

    Protected CurrentUserID As String = AppContext.userProfile.userId
    Protected gblFID As String = ""
    Protected gblRtbFID As String = ""
    Protected path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\JOB\"
    Protected JobDBModifiedApplyUI As JobDBmodifyApplyUI = Nothing
    Protected JobMailUI As JobMailGroupMaintainUI = Nothing
    Protected gblDBModifiedRecordDS As DataSet = Nothing
    Protected gblAssignSource As String = "" '2= SA  3=SD

    '是否清除查詢條件的判斷
    '0 維持全部清除
    '1 清除被點選的PG、系統、專案、全域變數
    Protected gblCleanConditionFlag As Integer = 0


    '是否自動點選第一筆
    'true 點選
    'False 不點選
    Protected gblClickFirstRowFlag As Boolean = True

    '判斷是否點選主旨會顯示完整的工作內容
    'true 顯示
    'False 不顯示
    Protected gblShowJobDetail As Boolean = False

    '專案的下拉選單是否增加空白行
    'true 顯示空白
    'False 不顯示
    Protected gblProjectCboEmptyRow As Boolean = False

    '專案的預設查詢區間天數
    Protected gblDefaultQueryDays As Integer = -7

    '是否自動開啟下載的檔案
    'true 自動開啟
    'False 不自動開啟
    Protected gblOpenDownloadFile As Boolean = True

    '預設指定路徑
    '空白，不預設
    Protected gblDefaultDownloadPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\JOB\"

    Enum JOBGridIndex As Integer
        Assign_User
        JOB_Code
        Issue_Classify
        Assign_Date
        Issue_Deadline
        SD_Issue_Deadline
        Subject
        Project_Name
        Hospital_Short_Name
        System_Name
        Function_Name
        Estimate_Cost
        Employee_Name
        Status
        DownLoadTestReport
        Reply
        Cancel
        SDConfirm
        Extension
        SA_Spec_FID
        SD_Spec_FID
        SA_Modifiy
        SD_Modifiy
    End Enum
    Enum ModifiedRecordGridIndex As Integer
        Project_Name
        Create_Date
        DB_Name
        Table_Name
        Modified_Classify
        DBA_Name
        Status
        FID
        Project_ID
        Seq_No
        Reject_Reason
    End Enum

    Dim WithEvents prjUI As New JobProjectMaintainUI

#End Region

#Region "     屬性宣告"

    Private m_ProjectID As String
    Public Property ProjectID As String
        Get
            Return m_ProjectID
        End Get
        Set(value As String)
            m_ProjectID = value
        End Set
    End Property


    Private m_System As String
    Public Property SystemID As String
        Get
            Return cbo_System.SelectedValue
        End Get
        Set(value As String)
            cbo_System.SelectedValue = value
        End Set
    End Property

    Public ReadOnly Property PGEmployee As String
        Get
            Return cbo_PGName.SelectedValue
        End Get
    End Property

    Private Sub ProjectModified() Handles pvtReceiveMgr.ProjectModified
        Try
            cbo_Project.Tag = cbo_Project.SelectedValue
            cbo_System.Tag = cbo_System.SelectedValue
            cbo_Function.Tag = cbo_Function.SelectedValue
            initialComboBox(False)
            cbo_Project.SelectedValue = cbo_Project.Tag
            cbo_System.SelectedValue = cbo_System.Tag
            cbo_Function.SelectedValue = cbo_Function.Tag

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案資訊異動"})
        End Try

    End Sub
#End Region

#Region " * 初始化 - 畫面  "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-14</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '客製化初始資料
            initialDataSpecial()

            '基本初始化資料
            initialData()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region


    ''' <summary>
    ''' 初始化畫面  
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-14</remarks>
    Public Overridable Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()


            '*******************************************************************************
            '修改 初始化的Combox 沒有則不需要 **********************************************
            '*******************************************************************************
            gblAssignSource = AppContext.userProfile.userNrsLevelId
            '初始化 - ComboBox
            initialComboBox(False)

            '*******************************************************************************
            SD_Page.Enabled = False
            dtp_AssignDateS.SetValue(Now.AddDays(gblDefaultQueryDays))
            dtp_AssignDateE.SetValue(Now)
            dtp_IssueDateStart.SetValue(Now.AddDays(-3).ToString("yyyy/MM/dd"))
            initialdgvIssueRecordListGrid(New DataSet)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub



    ''' <summary>
    ''' 客製化初始化畫面，被覆寫  
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-14</remarks>
    Public Overridable Sub initialDataSpecial()

        Try


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


    Protected Overridable Sub initialComboBox(ByVal isInitialed As Boolean)


        Try
            initialDS = job.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))

            If Not isInitialed Then


                Dim dtTemp As DataTable = initialDS.Tables("Project").Copy

                If gblProjectCboEmptyRow = True Then

                    '增加空白行 
                    Dim dr As DataRow = dtTemp.NewRow
                    dr.Item("Project_Id") = ""
                    dr.Item("Project_Name") = ""

                    dtTemp.Rows.InsertAt(dr, 0)

                End If
                cbo_Project.DataSource = initialDS.Tables("Project").Copy
                cbo_Project.uclDisplayIndex = "1"
                cbo_Project.uclValueIndex = "0"
                If issueClassify Is Nothing Then
                    issueClassify = PubServiceManager.getInstance.queryPUBSysCode("9999", False).Tables(0)
                End If
                cbo_IssueClassify.DataSource = issueClassify.Copy
                cbo_IssueClassify.DisplayMember = "Code_Name"
                cbo_IssueClassify.ValueMember = "Code_Id"


                If initialDS.Tables.Contains("PGList") Then
                    cbo_PGName.DataSource = initialDS.Tables("PGList").Copy
                    cbo_PGName.uclDisplayIndex = "1"
                    cbo_PGName.uclValueIndex = "0"
                    Dim newPGDT As DataTable = initialDS.Tables("PGList").AsEnumerable.Where(Function(c) Not c.Item(1).ToString.Contains("離職")).CopyToDataTable
                    newPGDT.Merge(initialDS.Tables("SDList").Copy)
                    cbo_NewPG.DataSource = newPGDT
                    cbo_NewPG.uclDisplayIndex = "1"
                    cbo_NewPG.uclValueIndex = "0"
                End If
                If initialDS.Tables.Contains("SAList") Then
                    cbo_SAName.DataSource = initialDS.Tables("SAList").Copy
                    cbo_SAName.uclDisplayIndex = "1"
                    cbo_SAName.uclValueIndex = "0"
                End If
                If initialDS.Tables.Contains("SDList") Then
                    cbo_SD.DataSource = initialDS.Tables("SDList").Copy
                    cbo_SD.uclDisplayIndex = "1"
                    cbo_SD.uclValueIndex = "0"
                    cbo_SDName.DataSource = initialDS.Tables("SDList").Copy
                    cbo_SDName.uclDisplayIndex = "1"
                    cbo_SDName.uclValueIndex = "0"
                    cbo_JobMainSD.DataSource = initialDS.Tables("SDList").Copy
                    cbo_JobMainSD.uclDisplayIndex = "1"
                    cbo_JobMainSD.uclValueIndex = "0"
                    cbo_JobMainSD.Enabled = AppContext.userProfile.userNrsLevelId.Equals("3")

                End If

                If initialDS.Tables.Contains("HospList") Then
                    cbo_Hosp.DataSource = initialDS.Tables("HospList").Copy
                    cbo_Hosp.uclDisplayIndex = "0,1"
                    cbo_Hosp.uclValueIndex = "0"
                End If
            End If

            If initialDS.Tables.Contains("MailGroup") Then
                cbo_MailGroup.DataSource = initialDS.Tables("MailGroup").Copy
                cbo_MailGroup.uclDisplayIndex = "0,1"
                cbo_MailGroup.uclValueIndex = "0"
            End If



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    Protected Sub initialdgvJobGrid(ByVal inputDS As DataSet)


        Dim limitDelayDays As Int32 = CInt(PubServiceManager.getInstance.GetPubConfigValue("JOB_DelayDay"))

        dgv_JobList.Initial(GetdgvJobGridHT(inputDS), dgvJobListColumnsText, dgvJobListVisitIndex)

        For i As Int32 = 0 To inputDS.Tables("JOBLISTDT").Rows.Count - 1
            If inputDS.Tables("JOBLISTDT").Rows(i).Item("DownLoadTestReport").ToString.Trim.Length = 0 Then
                dgv_JobList.DisableButton(i, JOBGridIndex.DownLoadTestReport)
            Else
                dgv_JobList.EnableButton(i, JOBGridIndex.DownLoadTestReport)
            End If
            If inputDS.Tables("JOBLISTDT").Rows(i).Item("Status").ToString.Trim.Equals("已提交") AndAlso inputDS.Tables("JOBLISTDT").Rows(i).Item("Reply").ToString.Trim.Equals("") Then
                dgv_JobList.EnableButton(i, JOBGridIndex.Reply)
            Else
                dgv_JobList.DisableButton(i, JOBGridIndex.Reply)
            End If

            If inputDS.Tables("JOBLISTDT").Rows(i).Item("Status").ToString.Trim.Equals("未提交") Then
                dgv_JobList.EnableButton(i, JOBGridIndex.Extension)
            Else
                dgv_JobList.DisableButton(i, JOBGridIndex.Extension)
            End If

            'If inputDS.Tables("JOBLISTDT").Rows(i).Item("Status").ToString.Trim.Equals("未提交") AndAlso
            '       (IsNumeric(inputDS.Tables("JOBLISTDT").Rows(i).Item("Delay_Days").ToString) AndAlso CInt(inputDS.Tables("JOBLISTDT").Rows(i).Item("Delay_Days").ToString) > limitDelayDays) Then
            '    dgv_JobList.EnableButton(i, JOBGridIndex.Extension)
            'Else
            '    dgv_JobList.DisableButton(i, JOBGridIndex.Extension)
            'End If

            If inputDS.Tables("JOBLISTDT").Rows(i).Item("Cancel").ToString.Trim.Equals("Y") OrElse inputDS.Tables("JOBLISTDT").Rows(i).Item("Status").ToString.Trim.Equals("已完成") Then
                dgv_JobList.DisableButton(i, JOBGridIndex.Cancel)
            Else
                dgv_JobList.EnableButton(i, JOBGridIndex.Cancel)
            End If


            If inputDS.Tables("JOBLISTDT").Rows(i).Item("Cancel").ToString.Trim.Equals("Y") OrElse inputDS.Tables("JOBLISTDT").Rows(i).Item("SD_Confirm").ToString.Trim.Equals("Y") OrElse Not AppContext.userProfile.userNrsLevelId.Equals("3") Then
                dgv_JobList.DisableButton(i, JOBGridIndex.SDConfirm)
            Else
                '3=SD 2=SA
                If AppContext.userProfile.userNrsLevelId.Equals("3") Then
                    dgv_JobList.EnableButton(i, JOBGridIndex.SDConfirm)
                End If
            End If
            If AppContext.userProfile.userNrsLevelId.Equals("3") Then
                dgv_JobList.EnableButton(i, JOBGridIndex.SD_Modifiy)
                dgv_JobList.DisableButton(i, JOBGridIndex.SA_Modifiy)
            Else
                dgv_JobList.EnableButton(i, JOBGridIndex.SA_Modifiy)
                dgv_JobList.DisableButton(i, JOBGridIndex.SD_Modifiy)
            End If
            If inputDS.Tables("JOBLISTDT").Rows(i).Item("SA_Spec_FID").ToString.Trim.Length = 0 Then
                dgv_JobList.DisableButton(i, JOBGridIndex.SA_Spec_FID)
            Else
                dgv_JobList.EnableButton(i, JOBGridIndex.SA_Spec_FID)
            End If
            If inputDS.Tables("JOBLISTDT").Rows(i).Item("SD_Spec_FID").ToString.Trim.Length = 0 Then
                dgv_JobList.DisableButton(i, JOBGridIndex.SD_Spec_FID)
            Else
                dgv_JobList.EnableButton(i, JOBGridIndex.SD_Spec_FID)
            End If
        Next

        If dgv_JobList.Rows.Count > 0 Then

            '2017-11-07 Sean 根據參數決定是否預設選擇第一個Row
            If gblClickFirstRowFlag = True Then
                dgv_JobList.CurrentCell = dgv_JobList.Rows(0).Cells(0)
            End If
            dgv_JobList.Columns(JOBGridIndex.Subject).Frozen = True

        End If

    End Sub

    Private Sub initialdgvDBModifiedGrid(ByVal inputDS As DataSet)


        dgv_DBModifiedList.Initial(GetdgvDBModifiedGridHT(inputDS))

        For i As Int32 = 0 To inputDS.Tables("Modified_Record").Rows.Count - 1
            If inputDS.Tables("Modified_Record").Rows(i).Item("FID").ToString.Trim.Length = 0 Then
                dgv_DBModifiedList.DisableButton(i, ModifiedRecordGridIndex.FID)
            Else
                dgv_DBModifiedList.EnableButton(i, ModifiedRecordGridIndex.FID)
            End If
            If inputDS.Tables("Modified_Record").Rows(i).Item("Status").ToString.Trim.Equals("退件") Then
                dgv_DBModifiedList.EnableButton(i, ModifiedRecordGridIndex.Project_ID)
            Else
                dgv_DBModifiedList.DisableButton(i, ModifiedRecordGridIndex.Project_ID)
            End If
        Next

        If dgv_DBModifiedList.Rows.Count > 0 Then
            dgv_DBModifiedList.CurrentCell = dgv_DBModifiedList.Rows(0).Cells(0)
        End If
        For x As Int32 = 0 To dgvModifiedListColumnsText.Length - 1
            dgv_DBModifiedList.Columns(x).HeaderText = dgvModifiedListColumnsText(x)
        Next
        dgv_DBModifiedList.uclVisibleColIndex = dgvModifiedLisdVisitIndex


    End Sub

    Protected Sub initialdgvIssueRecordListGrid(ByVal inputDS As DataSet)

        Try
            dgv_IssueRecordList.Initial(GetdgvIssueRecordListGridHT(GetIssueRecordListDS(inputDS)))
            For i As Int32 = 0 To dgv_IssueRecordList.GetDBDS.Tables(0).Rows.Count - 1
                If dgv_IssueRecordList.GetDBDS.Tables(0).Rows(i).Item("Att_FID").ToString.Trim.Length = 0 Then
                    dgv_IssueRecordList.DisableButton(i, 10)
                End If
            Next
            dgv_IssueRecordList.Columns(1).Frozen = True
            dgv_IssueRecordList.uclVisibleColIndex = dgvIssueRecordListVisitIndex
            dgv_IssueRecordList.uclHeaderText = dgvIssueRecordListColumnsText

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化需求紀錄列表"})
        End Try


    End Sub


    Private Function GetdgvJobGridHT(ByVal inputDS As DataSet) As Hashtable

        Dim ht As New Hashtable


        Try
            Dim btnCell As New Syscom.Client.UCL.ButtonCell
            btnCell.Text = "下載測試報告"
            Dim btnReplyCell As New Syscom.Client.UCL.ButtonCell
            btnReplyCell.Text = "回覆"
            Dim btnCancellCell As New Syscom.Client.UCL.ButtonCell
            btnCancellCell.Text = "作廢"
            Dim btnSDReplyCell As New Syscom.Client.UCL.ButtonCell
            btnSDReplyCell.Text = "SD覆核"
            Dim btnExtension As New Syscom.Client.UCL.ButtonCell
            btnExtension.Text = "延展交期"
            Dim IssueCell As New Syscom.Client.UCL.ComboBoxCell
            Dim btnSASpec As New Syscom.Client.UCL.ButtonCell
            btnSASpec.Text = "下載"
            Dim btnSDSpec As New Syscom.Client.UCL.ButtonCell
            btnSDSpec.Text = "下載"
            Dim btnSAModifiy As New Syscom.Client.UCL.ButtonCell
            btnSAModifiy.Text = "修改異動"
            Dim btnSDModifiy As New Syscom.Client.UCL.ButtonCell
            btnSDModifiy.Text = "修改異動"
            Dim ds As New DataSet
            ds.Tables.Add(issueClassify.Copy)
            IssueCell.Ds = ds.Copy
            IssueCell.DisplayIndex = "1"
            IssueCell.ValueIndex = "0"


            ht.Add(-1, inputDS)
            ht.Add(JOBGridIndex.Issue_Classify, IssueCell)
            ht.Add(JOBGridIndex.DownLoadTestReport, btnCell)
            ht.Add(JOBGridIndex.Reply, btnReplyCell)
            ht.Add(JOBGridIndex.Cancel, btnCancellCell)
            ht.Add(JOBGridIndex.SDConfirm, btnSDReplyCell)
            ht.Add(JOBGridIndex.Extension, btnExtension)
            ht.Add(JOBGridIndex.SA_Spec_FID, btnSASpec)
            ht.Add(JOBGridIndex.SD_Spec_FID, btnSDSpec)
            ht.Add(JOBGridIndex.SA_Modifiy, btnSAModifiy)
            ht.Add(JOBGridIndex.SD_Modifiy, btnSDModifiy)
            'ht.Add(JOBGridIndex.Issue_Deadline, New Syscom.Client.UCL.DtpCell)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetGridHT"})
        End Try
        Return ht
    End Function

    Private Function GetdgvDBModifiedGridHT(ByVal inputDS As DataSet) As Hashtable

        Dim ht As New Hashtable


        Try
            Dim btnCell As New Syscom.Client.UCL.ButtonCell
            btnCell.Text = "下載"
            Dim btn2Cell As New Syscom.Client.UCL.ButtonCell
            btn2Cell.Text = "查看"
            ht.Add(-1, inputDS)
            ht.Add(ModifiedRecordGridIndex.FID, btnCell)
            ht.Add(ModifiedRecordGridIndex.Project_ID, btn2Cell)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetGridHT"})
        End Try
        Return ht
    End Function

    Private Function GetdgvIssueRecordListGridHT(ByVal inputDS As DataSet) As Hashtable

        Dim ht As New Hashtable


        Try

            Dim btnCell As New ButtonCell
            btnCell.Text = "附件"
            ht.Add(-1, inputDS)
            ht.Add(1, New Syscom.Client.UCL.DtpCell)
            ht.Add(11, btnCell)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetGridHT"})
        End Try
        Return ht
    End Function

    Protected Function GetDgvJobGridDS(ByVal inputDS As DataSet) As DataSet
        Dim retDS As New DataSet

        retDS.Tables.Add(New DataTable("JOBLISTDT"))

        For i As Int32 = 0 To dgvJobListColumns.Length - 1
            retDS.Tables(0).Columns.Add(dgvJobListColumns(i))
        Next

        Try
            If Not CheckMethodUtil.CheckHasValue(inputDS) Then Return retDS
            For Each dr As DataRow In inputDS.Tables("JOBLIST").Rows
                Dim newDR As DataRow = retDS.Tables(0).NewRow

                For Each c As DataColumn In inputDS.Tables("JOBLIST").Columns
                    If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                        newDR(c.ColumnName) = dr(c.ColumnName)
                    End If
                Next


                If Not dr("Cancel").Equals("Y") Then
                    If IsDate(dr("Finish_Date").ToString.Trim) Then
                        newDR("Status") = "已完成"
                    ElseIf IsDate(dr("Reply_Date").ToString.Trim) Then
                        newDR("Status") = "已提交"
                    ElseIf Not dr("SD_Confirm").ToString.Equals("Y") Then
                        newDR("Status") = "SD尚未覆核"
                    Else
                        newDR("Status") = "未提交"
                    End If
                Else
                    newDR("Status") = "已作廢"
                End If
                newDR("DownLoadTestReport") = dr("Report_FID")
                newDR("Reply") = dr("Reject_Flag")
                newDR("SD_Issue_Deadline") = dr("SD_Issue_Deadline")
                retDS.Tables(0).Rows.Add(newDR)
            Next


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得GridDS"})
        End Try
        Return retDS
    End Function

    Private Function GetDgvDBModifiedGridDS(ByVal inputDS As DataSet) As DataSet
        Dim retDS As New DataSet

        retDS.Tables.Add(New DataTable("Modified_Record"))

        For i As Int32 = 0 To dgvModifiedLisdColumns.Length - 1
            retDS.Tables(0).Columns.Add(dgvModifiedLisdColumns(i))
        Next

        Try
            If Not CheckMethodUtil.CheckHasValue(inputDS, "Modified_Record") Then Return retDS
            For Each dr As DataRow In inputDS.Tables("Modified_Record").Rows
                Dim newDR As DataRow = retDS.Tables(0).NewRow
                newDR("Project_Name") = dr("Project_Name")
                newDR("Create_Time") = CDate(dr("Create_Time")).ToString("yyyy/MM/dd")
                newDR("DB_Name") = dr("DB_Name")
                newDR("Table_Name") = dr("Table_Name")

                If dr("Modified_Classify").ToString.Trim.Length > 0 Then
                    Dim modifiedClassify As String() = dr("Modified_Classify").ToString.Trim.Split(",")
                    Dim s As String = ""
                    For i As Int32 = 0 To modifiedClassify.Length - 1
                        Select Case modifiedClassify(i)
                            Case "1"
                                s = s & "新增Table、"
                            Case "2"
                                s = s & "欄位異動、"
                            Case "3"
                                s = s & "欄位型態異動、"
                            Case "4"
                                s = s & "欄位長度異動、"
                            Case "5"
                                s = s & "Create Index、"
                            Case "6"
                                s = s & "PK異動、"
                            Case "7"
                                s = s & "其他"
                        End Select
                    Next
                    If s.Length > 0 Then
                        s = s.Substring(0, s.Length - 1)
                        newDR("Modified_Classify") = s
                    End If

                End If
                newDR("DBA_Name") = dr("DBA_Name")
                newDR("Status") = dr("Modified_Status")
                newDR("FID") = dr("Modified_FID").ToString.Trim
                newDR("Project_ID") = dr("Project_ID").ToString.Trim
                newDR("Seq_No") = dr("Seq_No").ToString.Trim
                newDR("Reject_Reason") = dr("Reject_Reason").ToString.Trim

                retDS.Tables(0).Rows.Add(newDR)
            Next

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得GridDS"})
        End Try
        Return retDS
    End Function


    Private Function GetIssueRecordListDS(ByVal inputDS As DataSet) As DataSet
        Dim retDS As New DataSet

        retDS.Tables.Add(New DataTable("IssueList"))

        For i As Int32 = 0 To dgvIssueRecordListColumns.Length - 1
            retDS.Tables(0).Columns.Add(dgvIssueRecordListColumns(i))
        Next

        Try
            If Not CheckMethodUtil.CheckHasValue(inputDS, "Issue_List") Then Return retDS
            For Each dr As DataRow In inputDS.Tables("Issue_List").Rows
                Dim newDR As DataRow = retDS.Tables(0).NewRow
                For Each c As DataColumn In inputDS.Tables(0).Columns
                    If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                        newDR(c.ColumnName) = dr(c.ColumnName)
                    End If
                Next
                retDS.Tables(0).Rows.Add(newDR)
            Next

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得GridDS"})
        End Try
        Return retDS
    End Function


    Private Function GetPhraseGridDS(ByVal inputDS As DataSet) As DataSet
        Dim retDS As New DataSet

        retDS.Tables.Add(New DataTable("Phrase"))

        For i As Int32 = 0 To dgvPhraseColumns.Length - 1
            retDS.Tables(0).Columns.Add(dgvPhraseColumns(i))
        Next

        Try
            If Not CheckMethodUtil.CheckHasValue(inputDS) Then Return retDS
            For Each dr As DataRow In inputDS.Tables(0).Rows
                Dim newDR As DataRow = retDS.Tables(0).NewRow
                For Each c As DataColumn In inputDS.Tables(0).Columns
                    If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                        newDR(c.ColumnName) = dr(c.ColumnName)
                    End If
                Next
                retDS.Tables(0).Rows.Add(newDR)
            Next

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得GridDS"})
        End Try
        Return retDS

    End Function
#Region "     *載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-4-14</remarks>
    Protected Sub LoadServiceManager()
        Try


            job = JOBServiceManager.getInstance()

            '*******************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入服務管理員"})
        End Try

    End Sub

#End Region

#End Region

#Region "     事件處理"
    Private Sub btn_QueryPhrase_Click(sender As Object, e As EventArgs) Handles btn_QueryPhrase.Click
        Try
            Dim ds As DataSet = New DataSet
            ds.Tables.Add(New DataTable("Action"))
            ds.Tables("Action").Columns.Add("Action")
            ds.Tables("Action").Columns.Add("Create_User")
            ds.Tables("Action").Columns.Add("Is_Public")
            ds.Tables("Action").Rows.Add("QueryPhraseList", CurrentUserID, IIf(rbt_IsPublic.Checked, "Y", "N"))


            dgv_Phrase.Initial(GetPhraseGridDS(JOBServiceManager.getInstance.PRJDoAction(ds)))
            dgv_Phrase.uclVisibleColIndex = dgvPhraseVisitIndex
            dgv_Phrase.uclHeaderText = "片語內容"
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
        End Try
    End Sub
    Private Sub dgv_Phrase_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Phrase.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            rtb_Desc.Text &= dgv_Phrase.GetDBDS.Tables(0).Rows(e.RowIndex).Item(0).ToString.Trim
        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
        End Try
    End Sub



    Private Sub cbo_Project_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Project.SelectedIndexChanged

        If cbo_Project.SelectedValue.GetType().ToString.Equals("System.String") AndAlso cbo_Project.SelectedValue <> "" Then
            ProjectID = cbo_Project.SelectedValue.ToString
            Dim query = From System In initialDS.Tables("System").AsEnumerable()
                        Where System.Field(Of String)("Project_ID").ToString.Trim = cbo_Project.SelectedValue.ToString
                        Select System
            If query.AsDataView.Count > 0 Then
                cbo_System.DataSource = query.CopyToDataTable
                cbo_System.uclDisplayIndex = "0,1"
                cbo_System.uclValueIndex = "0"
            End If
        End If
        cbo_System.SelectedValue = ""

        '如果為SA角色，而專案在保固期，則躍升為SD角色(3)，否則開發中專案維持SA角色(2)
        If AppContext.userProfile.userNrsLevelId.Equals("2") Then
            If initialDS.Tables("Project").AsEnumerable().Where(Function(c) c.Item("Project_Id") = cbo_Project.SelectedValue.ToString).Select(Function(s) s.Item("Project_Status").ToString.Trim)(0) = "2" Then
                gblAssignSource = "3"
            Else
                gblAssignSource = AppContext.userProfile.userNrsLevelId
            End If
        Else
            gblAssignSource = "3"
        End If

    End Sub
    Private Sub cbo_System_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_System.SelectedIndexChanged


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


    End Sub

    Private Sub btn_SelectFile_Click(sender As Object, e As EventArgs) Handles btn_SelectFile.Click
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filePaths As String() = OpenFileDialog1.FileNames
            For Each s As String In filePaths
                If CheckPathIsExist(s) Then
                    dgv_Path.Rows.Add(False, s)
                End If
            Next
        End If
    End Sub
    Protected Overridable Sub dgv_JobList_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_JobList.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            SD_Page.Enabled = dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex)
            gb_SAJobTransfer.Enabled = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Status").ToString.Trim.Equals("未提交")
            Select Case e.ColumnIndex
                Case JOBGridIndex.Reply
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim Job_Code As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
                        Dim ui As JobSAReplyDialogUI = New JobSAReplyDialogUI(JobSAReplyDialogUI.CallType.SAReply, Job_Code, False)
                        ui.ShowDialog()
                        ui.Dispose()
                        ui = Nothing
                        '查詢方式改寫By Sean
                        'Query() 

                        '清除被點選的PG、系統、專案
                        If gblCleanConditionFlag = 1 Then
                            ClearAllGblVariables()

                            '清空 指定PG、系統、專案
                            CleanPrjFunEmp()

                        End If

                        btn_QueryJobList.PerformClick()
                    End If
                Case JOBGridIndex.DownLoadTestReport
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Try


                            DownloadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("DownLoadTestReport").ToString.Trim, gblDefaultDownloadPath, gblOpenDownloadFile, True)

                        Catch ex As Exception
                            Throw ex
                        End Try
                    End If

                Case JOBGridIndex.Cancel

                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim Job_Code As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
                        Dim ui As JobTextDialogUI = New JobTextDialogUI
                        ui.SetUIText = "作廢原因輸入"
                        ui.ExitWithoutInput = False
                        Dim CancelReason As String = ui.showDialog()
                        ui.Dispose()
                        ui = Nothing
                        If CancelReason.Length > 0 Then
                            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.CancelJob)
                            SendDS.Tables(0).Rows.Add("CancelJob", Job_Code, CancelReason, CurrentUserID, IIf(AppContext.userProfile.userNrsLevelId.Equals("3"), "SD", "SA"))
                            Dim retDS As DataSet = job.PRJDoAction(SendDS)

                            If CheckMethodUtil.CheckHasValue(retDS) Then
                                MessageHandling.ShowWarnMsg("CMMCMMB300", "作廢成功")
                                '查詢方式改寫By Sean
                                'Query() 
                                btn_QueryJobList.PerformClick()
                            End If
                        End If
                    End If
                Case JOBGridIndex.SDConfirm
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        TabControl1.SelectedTab = tp_AssignJob
                        TabControl2.SelectedTab = SD_Page
                        btn_SDConfirm.Enabled = True
                        btn_ReUploadSpec.Enabled = False
                        If IsDate(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Deadline").ToString.Trim) Then
                            dtp_SD_Issue_Deadline.SetValue(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Deadline").ToString.Trim)
                        End If
                        txt_SD_Estimate_Cost.Text = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Estimate_Cost").ToString.Trim
                    End If
                Case JOBGridIndex.Extension
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim Job_Code As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
                        Dim Assign_Date As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Deadline").ToString.Trim
                        Dim ui As New JobExtensionDialogUI(JobCode:=Job_Code, oriDate:=Assign_Date)
                        If ui.Showdialog(True) Then
                            '查詢方式改寫By Sean
                            'Query() 
                            btn_QueryJobList.PerformClick()
                        End If
                    End If
                Case JOBGridIndex.SA_Spec_FID
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Process.Start(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item(JOBGridIndex.SA_Spec_FID.ToString).ToString.Trim))
                    End If
                Case JOBGridIndex.SD_Spec_FID
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Process.Start(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item(JOBGridIndex.SD_Spec_FID.ToString).ToString.Trim))
                    End If
                          '點主旨顯示內容
                Case JOBGridIndex.Subject

                    If gblShowJobDetail = True Then
                        '顯示工作內容
                        ShowDetails()

                    End If
                Case JOBGridIndex.SA_Modifiy
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim Job_Code As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
                        Dim ui As New JobModifiyUI(JobModifiyUI.Character.SA, Job_Code)
                        ui.ShowDialog()
                        btn_QueryJobList.PerformClick()
                    End If
                Case JOBGridIndex.SD_Modifiy
                    If dgv_JobList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        Dim Job_Code As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
                        Dim ui As New JobModifiyUI(JobModifiyUI.Character.SD, Job_Code)
                        ui.ShowDialog()
                        btn_QueryJobList.PerformClick()
                    End If
            End Select

        Catch ex As Exception
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try

    End Sub
    Private Sub dgv_IssueRecordList_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_IssueRecordList.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            Select Case e.ColumnIndex
                Case 0
                    Exit Sub
                Case 10
                    If dgv_IssueRecordList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                        DownloadFileByFID(dgv_IssueRecordList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Att_FID").ToString, path, True, True)
                    End If

            End Select

            If dgv_IssueRecordList.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Source").ToString.Equals("QA") Then
                Try

                    Dim ui As New JobQACheckBugHistoryUI(dgv_IssueRecordList.GetDBDS.Tables(0).Rows(e.RowIndex)("Version_Id").ToString.Trim, dgv_IssueRecordList.GetDBDS.Tables(0).Rows(e.RowIndex)("Test_Version").ToString.Trim, dgv_IssueRecordList.GetDBDS.Tables(0).Rows(e.RowIndex)("Issue_Id").ToString.Trim)
                    ui.BugStatus = "04" '預設給04不可修改內容僅能回覆
                    ui.IsSD = True
                    ui.ShowDialog()
                Catch cmex As CommonException
                    Throw cmex
                Catch ex As Exception
                    Throw New CommonException("CMMCMMB302", ex, New String() {"點擊Grid"})
                End Try
            End If

        Catch ex As Exception
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try

    End Sub
    'Private Sub dgv_DBModifiedList_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_DBModifiedList.CellClick

    '    If e.RowIndex < 0 Then Exit Sub

    '    Try
    '        Select Case e.ColumnIndex

    '            Case ModifiedRecordGridIndex.FID
    '                If dgv_DBModifiedList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
    '                    Try

    '                        '判斷有無預設存檔路徑，沒有的話才讓使用者選擇
    '                        Dim blSelectFile As Boolean = False

    '                        If gblDefaultDownloadPath = "" Then
    '                            If FolderName.ShowDialog = DialogResult.OK Then
    '                                blSelectFile = True
    '                            End If
    '                        Else
    '                            FolderName.SelectedPath = gblDefaultDownloadPath
    '                            blSelectFile = True
    '                        End If

    '                        If blSelectFile Then
    '                            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "下載中，請稍後‧‧‧")
    '                            Dim client = FtmServiceManager.getInstance
    '                            Dim FID As String = dgv_DBModifiedList.GetDBDS.Tables(0).Rows(dgv_DBModifiedList.CurrentRow.Index).Item("FID").ToString.Trim
    '                            'Step.1 下載檔案
    '                            Dim obj As Object = client.downloadFile(FID)
    '                            'Step.3 取得檔案副檔名
    '                            Dim DataType As String = FID.Split(".")(1)
    '                            '(0) 檔案資料byte() , (1) client端的預設檔名
    '                            '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
    '                            FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
    '                            '判斷Folder，不存在則自行打開
    '                            If Not System.IO.Directory.Exists(FolderName.SelectedPath) Then
    '                                System.IO.Directory.CreateDirectory(FolderName.SelectedPath)
    '                            End If

    '                            Dim FilePath As String = FolderName.SelectedPath & "\" & FID

    '                            Using fs As FileStream = File.Create(FilePath)
    '                                fs.Write(obj(0), 0, obj(0).Length)
    '                            End Using
    '                            MessageBox.Show("下載完成")

    '                            '開啟
    '                            If gblOpenDownloadFile = True Then
    '                                Process.Start(FilePath)
    '                            End If

    '                        End If


    '                    Catch ex As Exception
    '                        Throw ex
    '                    End Try
    '                End If

    '            Case ModifiedRecordGridIndex.Project_ID
    '                If dgv_DBModifiedList.ButtonIsEnable(e.RowIndex, ModifiedRecordGridIndex.Project_ID) Then
    '                    Dim ProjectID As String = dgv_DBModifiedList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ModifiedRecordGridIndex.Project_ID).ToString.Trim
    '                    Dim SeqNo As String = dgv_DBModifiedList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ModifiedRecordGridIndex.Seq_No).ToString.Trim
    '                    Dim RejectReason As String = dgv_DBModifiedList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ModifiedRecordGridIndex.Reject_Reason).ToString.Trim
    '                    Dim Status As String = dgv_DBModifiedList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ModifiedRecordGridIndex.Status).ToString.Trim

    '                    Dim JobSAReplyDialogUI As JobSAReplyDialogUI = Nothing
    '                    Try
    '                        JobSAReplyDialogUI = New JobSAReplyDialogUI(JobSAReplyDialogUI.CallType.SACheck, ProjectID, SeqNo, RejectReason, Status.Equals("已處理"))
    '                        JobSAReplyDialogUI.ShowDialog()


    '                    Catch ex As Exception

    '                    Finally
    '                        JobSAReplyDialogUI.Dispose()
    '                        JobSAReplyDialogUI = Nothing
    '                    End Try
    '                End If
    '        End Select

    '    Catch ex As Exception
    '    Finally
    '        pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
    '    End Try

    'End Sub

    ''' <summary>
    ''' 頁籤切換
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Overridable Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Try
            '123456
            Select Case TabControl1.SelectedTab.Name
                Case "tp_DBModified"
                    InitialDBModifiedPage(gblDBModifiedRecordDS)

                    ProjectID = cbo_Project.SelectedValue
                    SystemID = cbo_System.SelectedValue
                    If JobDBModifiedApplyUI Is Nothing Then JobDBModifiedApplyUI = New JobDBmodifyApplyUI
                    JobDBModifiedApplyUI.SetParent(Me)
                    JobDBModifiedApplyUI.TopLevel = False
                    JobDBModifiedApplyUI.Parent = Panel_DBModified
                    JobDBModifiedApplyUI.Dock = DockStyle.Fill
                    JobDBModifiedApplyUI.Show()
                Case "tp_MailSetting"
                    JobMailUI = Nothing
                    JobMailUI = New JobMailGroupMaintainUI
                    JobMailUI.FormBorderStyle = FormBorderStyle.None
                    JobMailUI.TopLevel = False
                    JobMailUI.Parent = Panel_Mail
                    JobMailUI.Dock = DockStyle.Fill
                    JobMailUI.Show()

                Case "tp_AssignJob"
                    initialComboBox(True)
                    If Not CheckHasValue(dgv_IssueRecordList.GetSelectedDS) Then
                        SetDetails()
                    End If
                Case "tp_IssueList"

                    If dgv_IssueRecordList.Rows.Count = 0 Then
                        dgv_IssueRecordList.Enabled = True
                        QueryIssueList()
                    End If
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

    ''' <summary>
    ''' 派工確定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Overridable Sub btn_AssignConfirm_Click(sender As Object, e As EventArgs) Handles btn_AssignConfirm.Click

        '流程
        '寫資料庫>打包檔案>寄信
        Try
            Dim filePath As String = ""

            If CheckInput(False) OrElse CheckBeforeConfirm() Then
                Exit Sub
            End If

            ProcessAttachments()


            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.AssignNewJOB)
            SendDS.Tables(0).Rows.Add("AssignNewJOB",
                                       GetMainReceiver(CodeType.Code),
                                        cbo_Project.SelectedValue,
                                        cbo_System.SelectedValue,
                                        cbo_Function.SelectedValue,
                                        cbo_IssueClassify.SelectedValue,
                                        dtp_DeadLine.GetUsDateStr,
                                        rtb_Desc.Text,
                                        CurrentUserID,
                                        gblFID,
                                        GetMainReceiver(CodeType.Code),
                                        CCUser,
                                        GetMainReceiver(CodeType.Text), gblRtbFID, GetMailSubject(), GetMailGroup,
                                        IIf(ckb_NeedTestReport.Checked, "Y", "N"),
                                        gblAssignSource,
                                        cbo_SD.SelectedValue,
                                        "",
                                        "",
                                        txt_EstimateCost.Text,
                                        GetIssueIdString,
                                        Now.ToString("yyyy/MM/dd"),
                                        cbo_Hosp.SelectedValue,
                                        GetTarget,
                                        GetJobStatus)
            '夾帶附件檔
            SendDS.Tables.Add(GetSpecFileDataTable)
            Dim result As DataSet = job.PRJDoAction(SendDS)

            If result IsNot Nothing AndAlso result.Tables(0).Rows(0).Item(0) > 0 Then
                ClearAll()

                '查詢方式改寫By Sean
                'Query() 
                btn_QueryJobList.PerformClick()

                TabControl1.SelectedTab = tp_JobList
            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
    End Sub

    Protected Overridable Sub btn_QueryJobList_Click(sender As Object, e As EventArgs) Handles btn_QueryJobList.Click
        Try
            Query()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    Private Sub ckb_TempMailGroup_CheckedChanged(sender As Object, e As EventArgs) Handles ckb_TempMailGroup.CheckedChanged
        Try
            If sender.checked Then
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryEmployeeListByLevel)
                SendDS.Tables(0).Rows.Add("QueryEmployeeListByLevel", "1")
                '取得 Combobox的 資料
                Dim cboDS As DataSet = job.PRJDoAction(SendDS)
                MailUi = New Syscom.Client.UCL.UclMutiGridUI
                MailUi.ShowDialog("臨時郵件群組", cboDS, "員工編號,員工名稱,英文名稱,電子郵件", "2,3,4", "0,100,100,200", True)

                cbo_MailGroup.Enabled = Not CheckMethodUtil.CheckHasValue(MailUi.GetSelectedDS)
            Else
                cbo_MailGroup.Enabled = True
            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub


    Private Sub rbt_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbt_PG.CheckedChanged, rbt_SA.CheckedChanged, rbt_SD.CheckedChanged

        Try
            cbo_PGName.Enabled = rbt_PG.Checked
            cbo_SAName.Enabled = rbt_SA.Checked
            cbo_SDName.Enabled = rbt_SD.Checked
            cbo_SD.Enabled = rbt_PG.Checked
            If cbo_PGName.Enabled Then
                cbo_SAName.SelectedValue = ""
                cbo_SDName.SelectedValue = ""
            End If

            If cbo_SAName.Enabled Then
                cbo_PGName.SelectedValue = ""
                cbo_SDName.SelectedValue = ""
            End If

            If cbo_SDName.Enabled Then
                cbo_SAName.SelectedValue = ""
                cbo_PGName.SelectedValue = ""
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 帶入派工
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_SetData_Click(sender As Object, e As EventArgs) Handles btn_SetData.Click

        Lock(Me)
        Try
            If dgv_IssueRecordList.SelectedIndex.Length = 0 Then Exit Sub
            SetDataByIssue()


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"帶入派工"})
        Finally
            UnLock(Me)
        End Try

    End Sub

    ''' <summary>
    ''' 清除重選
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_ClearAndReset_Click(sender As Object, e As EventArgs) Handles btn_ClearAndReset.Click
        If dgv_IssueRecordList.Rows.Count <= 0 Then Exit Sub
        Lock(Me)

        Try
            dgv_IssueRecordList.Enabled = True
            dgv_IssueRecordList.SetSelectAll(False)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除重選"})
        Finally
            UnLock(Me)
        End Try


    End Sub

    ''' <summary>
    ''' 重新查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_QueryIssue_Click(sender As Object, e As EventArgs) Handles btn_QueryIssue.Click
        Lock(Me)
        Try
            QueryIssueList()

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"重新查詢"})
        Finally
            UnLock(Me)
        End Try

    End Sub


    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        Lock(Me)
        Try
            ClearAll()
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"重新查詢"})
        Finally
            UnLock(Me)
        End Try

    End Sub

    ''' <summary>
    ''' 工作轉派
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_SAJobTransfer_Click(sender As Object, e As EventArgs) Handles btn_SAJobTransfer.Click
        Lock(Me)
        Try
            If txt_TransferReason.Text = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "原因不得為空")
                Exit Sub
            End If
            If cbo_NewPG.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "未選轉派人")
                Exit Sub
            End If
            If cbo_NewPG.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("PG_Employee_Code").ToString.Trim Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "不得為同一人")
                cbo_NewPG.SelectedValue = ""
                Exit Sub
            End If
            Dim JobCode As String = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.SAJobTransfer)
            SendDS.Tables(0).Rows.Add("SAJobTransfer", JobCode, cbo_NewPG.SelectedValue, txt_TransferReason.Text, CurrentUserID, AppContext.userProfile.userNrsLevelId, dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) AndAlso retDS.Tables(0).Rows(0).Item(0) > 0 Then
                txt_TransferReason.Text = ""
                cbo_NewPG.SelectedValue = ""
                gb_SAJobTransfer.Enabled = False
                btn_QueryJobList.PerformClick()
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"工作轉派"})
        Finally
            UnLock(Me)
        End Try
    End Sub


#End Region

#Region "     內部函數"

#Region "檢核"
    ''' <summary>
    ''' 檢核選中的項目是否為同一類
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckSelectedIssueKindIsSame() As Boolean
        Try

            Dim query = (From q In dgv_IssueRecordList.GetSelectedDS.Tables(0)
                         Group By Project_Id = q.Item("Project_Id"), System_Code = q.Item("System_Code"), Function_Code = q.Item("Function_Code") Into grp = Group).
                     Select(Function(c) New With {.Project_Id = c.Project_Id}).ToList

            Return query.Count > 1

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢核選中問題項目類別"})

        End Try
    End Function
    Private Function UploadFileToFTM(ByVal FilePath As String) As String

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
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = "roger" '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = "roger" '修改人員
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
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
            Return s(0)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
        Return ""
    End Function

    Protected Sub UploadFileToFTM(ByVal data As Byte())

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
            dataRow("File_Note") = "testing" '檔案註解
            dataRow("Create_User") = CurrentUserID '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = CurrentUserID '修改人員
            dataRow("Modified_Time") = Now '修改時間
            dataRow("FileByteArray") = data
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
            gblFID = s(0)
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
    End Sub

    Protected Function CheckPathIsExist(ByVal path As String) As Boolean

        'If dgv_Path.Rows.Count <= 0 Then Return False

        CheckPathIsExist = True
        For i As Int32 = 0 To dgv_Path.Rows.Count - 1

            If dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Equals(path) Then
                Return False
            End If
        Next
        Return CheckPathIsExist

    End Function

    Protected Function CheckInput(ByVal isSD As Boolean) As Boolean
        Dim SpeChrList As String() = {"\", "/", "*", ":", "?", """", "<", ">"}

        Try
            For Each s As String In SpeChrList
                If txt_Subject.Text.Contains(s) Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "標題不可含特殊符號如:'\/*:?""<>")
                    Return True
                End If
            Next

            '有上傳檔案但是未進行補正上傳  提示
            If dgv_SDSpecPath.Rows.Count > 0 AndAlso (gblFID = "" OrElse dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim.Equals(gblFID)) Then
                If MessageBox.Show("有新增檔案但尚未進行補正上傳，是否確認送出??", "確認", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Return True
                End If
            End If

        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", ex.ToString)
            Throw ex
        End Try

        CheckInput = False

        If (rbt_PG.Checked AndAlso cbo_PGName.SelectedValue = "") OrElse
           (AppContext.userProfile.userNrsLevelId.Equals("3") AndAlso cbo_PGName.SelectedValue = "9999999") Then
            cbo_PGName.BackColor = Color.Red
            Return True
        Else
            cbo_PGName.BackColor = Color.White
        End If

        If (rbt_SA.Checked AndAlso cbo_SAName.SelectedValue = "") Then
            cbo_SAName.BackColor = Color.Red
            Return True
        Else
            cbo_SAName.BackColor = Color.White
        End If
        If (rbt_SD.Checked AndAlso cbo_SDName.SelectedValue = "") Then
            cbo_SDName.BackColor = Color.Red
            Return True
        Else
            cbo_SDName.BackColor = Color.White
        End If

        If cbo_Function.SelectedValue = "" Then
            cbo_Function.BackColor = Color.Red
            Return True
        Else
            cbo_Function.BackColor = Color.White
        End If
        If txt_Subject.Text = "" Then
            txt_Subject.BackColor = Color.Red
            Return True
        Else
            txt_Subject.BackColor = Color.White
        End If
        If cbo_SD.Enabled AndAlso cbo_SD.SelectedValue = "" Then
            cbo_SD.BackColor = Color.Red
            Return True
        Else
            cbo_SD.BackColor = Color.White
        End If

        If cbo_Hosp.SelectedValue = "" Then
            cbo_Hosp.BackColor = Color.Red
            Return True
        Else
            cbo_Hosp.BackColor = Color.White
        End If
        If txt_EstimateCost.Text = "" Then
            txt_EstimateCost.BackColor = Color.Red
            Return True
        Else
            txt_EstimateCost.BackColor = Color.White
        End If
        If dtp_DeadLine.GetUsDateStr = "" Then
            dtp_DeadLine.BackColor = Color.Red
            Return True
        Else
            dtp_DeadLine.BackColor = Color.White
        End If
        If isSD Then
            If txt_SD_Estimate_Cost.Text = "" Then
                txt_SD_Estimate_Cost.BackColor = Color.Red
                Return True
            Else
                txt_SD_Estimate_Cost.BackColor = Color.White
            End If
            If dtp_SD_Issue_Deadline.GetUsDateStr = "" Then
                dtp_SD_Issue_Deadline.BackColor = Color.Red
                Return True
            Else
                dtp_SD_Issue_Deadline.BackColor = Color.White
            End If
        End If

        Return CheckInput

    End Function


    Private Sub btn_ClearPath_Click(sender As Object, e As EventArgs) Handles btn_ClearPath.Click


        ClearAll()

    End Sub



    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Delete_dgv_Path()
    End Sub

    Private Sub Delete_dgv_Path()
        If dgv_Path.Rows.Count <= 0 Then Exit Sub
        Dim selectRow As New Collections.Generic.List(Of DataGridViewRow)


        For i As Int32 = 0 To dgv_Path.Rows.Count - 1
            If dgv_Path.Rows(i).Cells(0).Value Then
                selectRow.Add(dgv_Path.Rows(i))
            End If
        Next

        For Each dr As DataGridViewRow In selectRow
            dgv_Path.Rows.Remove(dr)
        Next

    End Sub


#End Region

#Region "     查詢"

    Protected Function Query() As Boolean
        Dim ret As Boolean = False
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryJobList)
            Dim AssignDateS As String = dtp_AssignDateS.GetUsDateStr
            Dim AssignDateE As String = dtp_AssignDateE.GetUsDateStr
            Dim PGEmployeeCode As String = cbo_PGName.SelectedValue
            Dim CreateUser As String = GetAssignUser()
            Dim ProjectID As String = cbo_Project.SelectedValue
            Dim SystemCode As String = cbo_System.SelectedValue
            Dim Status As String = ""
            Dim Cancel As String = IIf(ckb_Cancel.Checked, "Y", "N")

            If rbt_All.Checked Then
                Status = "All"
            ElseIf rbt_Close.Checked Then
                Status = "Close"
            ElseIf rbt_UnClose.Checked Then
                Status = "UnClose"
            ElseIf rbt_UnConfirm.Checked Then
                Status = "UnConfirm"
            ElseIf rbt_UnProcess.Checked Then
                Status = "UnProcess"
            End If
            SendDS.Tables(0).Rows.Add("QueryJobList", AssignDateS, AssignDateE, PGEmployeeCode, ProjectID, SystemCode, CreateUser, gblAssignSource, IIf(ckb_IsSDConfirm.Checked, "Y", "N"), Status, Cancel, cbo_JobMainSD.SelectedValue)
            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing AndAlso CheckMethodUtil.CheckHasValue(resultDS, "Modified_Record") Then
                gblDBModifiedRecordDS = New DataSet
                gblDBModifiedRecordDS.Tables.Add(resultDS.Tables("Modified_Record").Copy)
                If JobDBModifiedApplyUI IsNot Nothing Then InitialDBModifiedPage(gblDBModifiedRecordDS)
            End If

            If resultDS IsNot Nothing AndAlso resultDS.Tables(0).Rows.Count > 0 Then
                initialdgvJobGrid(GetDgvJobGridDS(resultDS))
            Else
                initialdgvJobGrid(GetDgvJobGridDS(New DataSet))
                ClearAll()
            End If

            Return True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
        Return ret
    End Function

    Private Sub InitialDBModifiedPage(ByVal ds As DataSet)
        Try
            If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                initialdgvDBModifiedGrid(GetDgvDBModifiedGridDS(ds))
            Else
                initialdgvDBModifiedGrid(GetDgvDBModifiedGridDS(New DataSet))
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub


#End Region

#Region "     Set內容"
    ''' <summary>
    ''' 依據選取的問題單做系統設定
    ''' </summary>
    Protected Sub SetDataByIssue()
        Try


            If CheckSelectedIssueKindIsSame() Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "所選項目必須歸屬於同一【專案】【系統】【功能】，請重新選擇")
                btn_ClearAndReset.PerformClick()
                TabControl1.SelectedTab = tp_IssueList
            Else
                txt_Subject.Text = ""
                dtp_DeadLine.Clear()
                cbo_SD.SelectedValue = ""
                MailUi = Nothing
                ckb_TempMailGroup.Checked = False
                txt_EstimateCost.Text = ""
                btn_ClearPath.PerformClick()
                cbo_Project.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Project_Id").ToString
                cbo_Hosp.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Hospital_Code").ToString
                cbo_System.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("System_Code").ToString
                cbo_Function.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Function_Code").ToString
                cbo_Hosp.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Hospital_Code").ToString
                cbo_IssueClassify.SelectedValue = dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Issue_Classify").ToString.Split("-")(0)
                dtp_DeadLine.SetValue(dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Estimated_Finish_Date"))
                If dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Att_FID").ToString.Length > 0 Then
                    For Each AttFID In dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows(0).Item("Att_FID").ToString.Split(",")
                        If AttFID.Trim.Equals("") Then Continue For
                        AddNewAttFile(AttFID)
                    Next
                End If
                For Each dr As DataRow In dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows
                    rtb_Desc.Text &= "===============================================================" & vbCrLf
                    rtb_Desc.Text &= dr("Issue_Description").ToString & vbCrLf
                    rtb_Desc.Text &= "===============================================================" & vbCrLf
                Next
                dgv_IssueRecordList.Enabled = False
                TabControl1.SelectedTab = tp_AssignJob
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub SetDetails()
        Try
            If dgv_JobList.Rows.Count = 0 Then Exit Sub

            If dgv_JobList.CurrentCell Is Nothing Then
                dgv_JobList.CurrentCell = dgv_JobList.Rows(0).Cells(0)
            End If
            cbo_Project.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Project_Id").ToString.Trim
            cbo_System.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("System_Code").ToString.Trim
            cbo_Function.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Function_Code").ToString.Trim
            rtb_Desc.LoadFile(ProjectClientBP.getInstance.LoadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("RTF_FID").ToString.Trim))
            cbo_IssueClassify.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Classify").ToString.Trim
            cbo_PGName.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("PG_Employee_Code").ToString.Trim

            If IsDate(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Deadline").ToString.Trim) Then
                dtp_DeadLine.SetValue(CDate(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Deadline").ToString.Trim).ToString("yyyy/MM/dd"))
            End If

            cbo_SD.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("SD_Employee_Code").ToString.Trim
            ckb_NeedTestReport.Checked = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Test_Report_Flag").ToString.Trim.Equals("Y")
            txt_Subject.Text = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Mail_Subject").ToString.Trim
            rtb_SDNote.Text = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("SD_Note").ToString.Trim
            txt_EstimateCost.Text = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Estimate_Cost").ToString.Trim
            btn_DownloadSpecFile.Enabled = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim.Length > 0
            cbo_Hosp.SelectedValue = dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Hospital_Code").ToString.Trim

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     打包附件項目"

    Protected Function ProcessAttachments() As String
        Try
            Dim attachments As New List(Of Byte())
            Dim _pathSpec As String = path & "SPEC"
            Dim _pathDesc As String = path & "Desc"
            If dgv_Path.Rows.Count > 0 Then
                Dim dir As New DirectoryInfo(path & "SPEC")
                If dir.Exists Then
                    dir.Delete(True)
                End If
                dir.Create()
                For i As Int32 = 0 To dgv_Path.Rows.Count - 1
                    Dim FileName As String = dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\")(dgv_Path.Rows(i).Cells("FilePath").Value.ToString.Split("\").Length - 1)
                    CopyFiles(dgv_Path.Rows(i).Cells("FilePath").Value.ToString, _pathSpec & "\" & FileName)
                Next
                gblFID = UploadFileToFTM(ProjectClientBP.getInstance.CompressFile(New DirectoryInfo(_pathSpec)))
            Else
                gblFID = ""
            End If

            Dim dir1 = New DirectoryInfo(_pathDesc)
            If dir1.Exists = False Then
                dir1.Create()
            End If
            Dim filePath As String = _pathDesc & Convert.ToString("\" & Now.ToString("yyyyMMddHHmmss") & ".rtf")
            Using outputFile As New StreamWriter(filePath, True)
                outputFile.WriteLine(rtb_Desc.Rtf)
            End Using
            gblRtbFID = UploadFileToFTM(filePath)

            Return path
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Function CopyFiles(ByVal Spath As String, ByVal Dpath As String) As Boolean
        Try
            System.IO.File.Copy(Spath, Dpath, True)

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return True
    End Function

#End Region

#Region "     取得檔案存檔DT"

    Protected Function GetSpecFileDataTable() As DataTable
        Dim SpecFilesDT As DataTable = JobSaSpecfilesDataTableFactory.getDataTableWithNoPK

        Try
            If gblFID <> "" Then
                Dim dr As DataRow = SpecFilesDT.NewRow
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.JOB_Code) = ""
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.FID) = gblFID
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.Source) = gblAssignSource
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.Create_User) = CurrentUserID
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.Create_Time) = ""
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.Modified_User) = CurrentUserID
                dr(JobSaSpecfilesDataTableFactory.DBColumnName.Modified_Time) = ""
                SpecFilesDT.Rows.Add(dr)

            End If


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return SpecFilesDT
    End Function

#End Region

#Region "     寄發Mail"
    Protected MainReceiver As String = ""
    Protected CCUser As String = ""
    Private Function SendMailAfterInsert(ByVal JobCode As String, ByVal ProjectCode As String,
                              ByVal SystemCode As String,
                              ByVal PGEmployeeCode As String,
                              ByVal FunctionCode As String, ByVal IssueClassify As String, ByVal DeadLine As String,
                              ByVal Desc As String, ByVal filePath As String) As Int32

        Try
            Dim mailTitle As New StringBuilder
            Dim message As New StringBuilder
            '信件標題
            mailTitle.Append("[派工通知]").Append(JobCode).Append("")

            '信件內容
            message.Append("派工編號:  ").Append(JobCode).Append("   ").Append("派工日: ").Append(Now.ToString("yyyy/MM/dd HH:mm:ss")).AppendLine()
            message.Append("所屬專案: ").Append(ProjectCode).Append("   ").Append("系統別: ").Append(SystemCode).AppendLine()
            message.Append(" 負責人員:").Append(PGEmployeeCode).Append("-").Append(cbo_PGName.Text).Append("   ").Append("歸屬功能(UI名稱): ").Append(FunctionCode).AppendLine()

            Select Case IssueClassify
                Case "1"
                    message.Append("需求類別: ").Append("需求").AppendLine()
                Case "2"
                    message.Append("需求類別: ").Append("BUG").AppendLine()
                Case "3"
                    message.Append("需求類別: ").Append("需求+BUG").AppendLine()
            End Select
            message.Append("預期完成日: ").Append(DeadLine).AppendLine()
            message.Append("備註:").AppendLine()
            message.Append(Desc).AppendLine()

            SendMail.getInstance.SendMail(MainReceiver, CCUser, mailTitle.ToString, message.ToString, IIf(filePath.Length > 0, filePath, Nothing))
        Catch ex As Exception
            Return 1
        End Try
        Return 0


    End Function
#End Region

#Region "     取得郵件群組"

    Protected Function GetMailGroup() As String

        Try
            If ckb_TempMailGroup.Checked Then

                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.CreateTempMailGroup)
                SendDS.Tables(0).Rows.Add("CreateTempMailGroup", CurrentUserID, GetTempMailStr(GetMailGroupByID))
                Dim ds As DataSet = job.PRJDoAction(SendDS)
                If CheckMethodUtil.CheckHasValue(ds) Then
                    Return ds.Tables(0).Rows(0).Item(0)
                End If

            Else
                Return cbo_MailGroup.SelectedValue
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function
    Protected Function GetMailGroupByID() As DataSet
        If cbo_MailGroup.SelectedValue = "" Then Return Nothing
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryMailGroupDetail)
            SendDS.Tables(0).Rows.Add("QueryMailGroupDetail", cbo_MailGroup.SelectedValue, CurrentUserID, "")
            Return job.PRJDoAction(SendDS)

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Protected Function GetTempMailStr(ByVal oriMailDs As DataSet) As String
        Dim MailList1 = MailUi.GetSelectedDS().Tables(0).AsEnumerable.Select(Function(c) c("Employee_Code").ToString.Trim & "-" & c("EMail").ToString.Trim)
        Try
            If CheckHasValue(oriMailDs) Then
                Return String.Join(";", MailList1) & ";" & String.Join(";", oriMailDs.Tables(0).AsEnumerable.Select(Function(c) c("Employee_Code").ToString.Trim & "-" & c("EMail").ToString.Trim))
            Else
                Return String.Join(";", MailList1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function
#End Region

#Region "     取得主要發送對象"
    Enum CodeType As Integer
        Code
        Text
    End Enum
    Protected Function GetMainReceiver(ByVal v As CodeType) As String

        Try
            If rbt_PG.Checked Then
                If v = CodeType.Code Then
                    Return cbo_PGName.SelectedValue
                Else
                    Return cbo_PGName.Text
                End If
            End If
            If rbt_SA.Checked Then
                If v = CodeType.Code Then
                    Return cbo_SAName.SelectedValue
                Else
                    Return cbo_SAName.Text
                End If
            End If
            If rbt_SD.Checked Then
                If v = CodeType.Code Then
                    Return cbo_SDName.SelectedValue
                Else
                    Return cbo_SDName.Text
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function

    Protected Function GetTarget() As String

        Try
            If rbt_PG.Checked Then
                Return "PG"
            End If
            If rbt_SA.Checked Then
                Return "SA"
            End If
            If rbt_SD.Checked Then
                Return "SD"
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function

    Protected Function GetJobStatus() As String

        Try
            If rbt_E.Checked Then
                Return "E"
            End If
            If rbt_R.Checked Then
                Return "R"
            End If
            If rbt_N.Checked Then
                Return "N"
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function

    Protected Function GetMailSubject() As String

        Try
            If rbt_E.Checked Then
                Return "【急】" & txt_Subject.Text
            End If
            If rbt_R.Checked Then
                Return "【補】" & txt_Subject.Text
            End If
            If rbt_N.Checked Then
                Return "【一般】" & txt_Subject.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function
#End Region

#Region "     清除"

    Protected Sub ClearAll()

        Try
            ClearAllControls()
            ClearAllGblVariables()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub


    ''' <summary>
    ''' 清空專案、系統、PG
    ''' </summary>
    Private Sub CleanPrjFunEmp()
        '指定PG清空
        cbo_PGName.SelectedValue = ""
        cbo_PGName.SelectedIndex = 0

        '指定系統清空
        cbo_System.SelectedValue = ""
        cbo_System.SelectedIndex = 0

        '指定專案清空
        cbo_Project.SelectedValue = ""
        cbo_Project.SelectedIndex = 0
    End Sub
#End Region

#Region "     清除控制項"

    Protected Sub ClearAllControls()

        Try
            dgv_Path.Rows.Clear()
            dgv_JobList.DataSource = Nothing
            cbo_Function.DataSource = Nothing
            dgv_IssueRecordList.ClearDS()
            dgv_IssueRecordList.DataSource = Nothing
            dgv_IssueRecordList.ClearSelection()
            cbo_System.SelectedValue = ""
            cbo_IssueClassify.SelectedIndex = 0
            rtb_Desc.Text = ""
            dtp_DeadLine.SetValue(Now)
            dtp_SD_Issue_Deadline.Clear()
            txt_Subject.Text = ""
            rtb_Desc.Text = ""
            If MailUi IsNot Nothing Then MailUi.Dispose()
            cbo_MailGroup.Enabled = True
            txt_TransferReason.Text = ""
            cbo_NewPG.SelectedValue = ""
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#End Region

#Region "     清除控全域變數"

    Protected Sub ClearAllGblVariables()

        Try

            gblFID = ""
            gblRtbFID = ""
            If MailUi IsNot Nothing Then MailUi.Dispose()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#End Region

#Region "     下載檔案"

    Protected Function DownloadFileByFID(ByVal FID As String, ByVal DefaultDownLoadPath As String, ByVal OpenFile As Boolean, ByVal ReBuildPath As Boolean) As String
        Dim FilePath As String = ""
        Try


            '判斷有無預設存檔路徑，沒有的話才讓使用者選擇
            Dim blSelectFile As Boolean = False

            If DefaultDownLoadPath = "" Then
                If FolderName.ShowDialog = DialogResult.OK Then
                    blSelectFile = True
                End If
            Else
                FolderName.SelectedPath = DefaultDownLoadPath
                blSelectFile = True
            End If

            If blSelectFile Then
                pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "下載中，請稍後‧‧‧")

                'Step.1 下載檔案
                Dim obj As Object = FtmServiceManager.getInstance.downloadFile(FID)
                'Step.3 取得檔案副檔名
                Dim DataType As String = FID.Split(".")(1)
                '(0) 檔案資料byte() , (1) client端的預設檔名
                '不滿意預設路徑或檔名，請自行修改後傳入　FileTransferTool.convertByteArrayToFile
                FileTransferTool.convertByteArrayToFile(obj(0), obj(1))
                '判斷Folder，不存在則自行打開
                Dim di As New DirectoryInfo(FolderName.SelectedPath)
                If ReBuildPath AndAlso di.Exists Then
                    di.Delete(True)
                    di.Create()
                ElseIf Not di.Exists Then
                    di.Create()
                End If

                FilePath = FolderName.SelectedPath & FID
                Using fs As FileStream = File.Create(FilePath)
                    fs.Write(obj(0), 0, obj(0).Length)
                End Using
                '開啟
                If OpenFile Then
                    MessageBox.Show("下載完成")
                    Process.Start(FilePath)
                End If
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"下載檔案"})
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try
        Return FilePath
    End Function


#End Region

#Region "確認前提示"

    Protected Function CheckBeforeConfirm() As Boolean
        Try
            If Not ckb_NeedTestReport.Checked AndAlso MessageBox.Show("確認無須測試報告?", "確認", MessageBoxButtons.YesNo) = DialogResult.No Then
                Return True
            End If

            Return MessageBox.Show(GetConfirmInfo, "確認派工資訊", MessageBoxButtons.YesNo) = DialogResult.No

        Catch cmm As CommonException
            Throw cmm
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function GetConfirmInfo() As String
        Try
            Dim s As New StringBuilder
            Dim MainReceiver As String = ""
            If rbt_PG.Checked Then
                MainReceiver = cbo_PGName.Text
            ElseIf rbt_SA.Checked Then
                MainReceiver = cbo_SAName.Text
            Else
                MainReceiver = cbo_SDName.Text
            End If
            s.Append("負責人員:").Append(MainReceiver).AppendLine()
            s.Append("專案:").Append(cbo_Project.SelectedValue).Append("-").Append(cbo_Project.Text).AppendLine()
            s.Append("系統:").Append(cbo_System.SelectedValue).Append("-").Append(cbo_System.Text).AppendLine()
            s.Append("功能:").Append(cbo_Function.SelectedValue).Append("-").Append(cbo_Function.Text).AppendLine()
            s.Append("需求主旨:").Append(txt_Subject.Text).AppendLine()
            s.Append("需求類別:").Append(cbo_IssueClassify.Text).AppendLine()
            s.Append("預計完成日:").Append(dtp_DeadLine.GetUsDateStr).AppendLine()
            s.Append("是否須附測試報告(Y/N):").Append(IIf(ckb_NeedTestReport.Checked, "Y", "N"))


            Return s.ToString

        Catch cmm As CommonException
            Throw cmm
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "SD覆核"

    Private Sub btn_DownloadSpecFile_Click(sender As Object, e As EventArgs) Handles btn_DownloadSpecFile.Click
        Try
            If dgv_JobList.CurrentRow Is Nothing Then Exit Sub
            DownloadFileByFID(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim, gblDefaultDownloadPath, gblOpenDownloadFile, True)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"下載檔案"})
        End Try

    End Sub

    Private Sub btn_AddSpecFile_Click(sender As Object, e As EventArgs) Handles btn_AddSpecFile.Click
        Try
            Dim ds As DataSet
            If dgv_SDSpecPath.Rows.Count > 0 Then
                ds = dgv_SDSpecPath.GetDBDS
            Else
                ds = New DataSet
                ds.Tables.Add(New DataTable("NewSpec"))
                ds.Tables(0).Columns.Add("Path")
            End If


            If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim filePaths As String() = OpenFileDialog1.FileNames
                For Each s As String In filePaths
                    ds.Tables(0).Rows.Add(s)
                Next
                dgv_SDSpecPath.Initial(ds)
            End If

            btn_DeleteFile.Enabled = dgv_SDSpecPath.Rows.Count > 0
            btn_ReUploadSpec.Enabled = dgv_SDSpecPath.Rows.Count > 0

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增檔案"})
        End Try

    End Sub

    Private Sub btn_ReUploadSpec_Click(sender As Object, e As EventArgs) Handles btn_ReUploadSpec.Click
        Try
            If dgv_SDSpecPath.Rows.Count = 0 Then
                btn_ReUploadSpec.Enabled = False
                Exit Sub
            End If


            Lock(Me)
            Dim dir As New DirectoryInfo(path & "SPEC")
            If dir.Exists Then
                dir.Delete(True)
            End If
            dir.Create()
            For i As Int32 = 0 To dgv_SDSpecPath.Rows.Count - 1
                Dim FileName As String = dgv_SDSpecPath.Rows(i).Cells("Path").Value.ToString.Split("\")(dgv_SDSpecPath.Rows(i).Cells("Path").Value.ToString.Split("\").Length - 1)
                CopyFiles(dgv_SDSpecPath.Rows(i).Cells("Path").Value.ToString, path & "SPEC" & "\" & FileName)
            Next


            gblFID = UploadFileToFTM(ProjectClientBP.getInstance.CompressFile(dir))
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"重新上傳"})
        Finally
            MessageBox.Show("上傳成功")
            UnLock(Me)
        End Try

    End Sub

    Protected Overridable Sub btn_SDConfirm_Click(sender As Object, e As EventArgs) Handles btn_SDConfirm.Click
        Try
            Lock(Me)

            If CheckInput(True) Then Exit Sub

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.SDConfirm)
            SendDS.Tables(0).Rows.Add("SDConfirmJOB",
                                        dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Job_Code").ToString.Trim,
                                        IIf(gblFID = "", dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("FID").ToString.Trim, gblFID),
                                        rtb_SDNote.Text, cbo_Project.SelectedValue,
                                        cbo_System.SelectedValue, cbo_Function.SelectedValue, GetMainReceiver(CodeType.Code), GetMainReceiver(CodeType.Text),
                                        cbo_IssueClassify.SelectedValue, dtp_DeadLine.GetUsDateStr, rtb_Desc.Text, gblAssignSource, txt_EstimateCost.Text,
                                        txt_SD_Estimate_Cost.Text, txt_SD_Cost_Time.Text, dtp_SD_Issue_Deadline.GetUsDateStr)
            SendDS.Tables.Add(GetSpecFileDataTable)
            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If CheckMethodUtil.CheckHasValue(resultDS) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "派工已送出!!")
                dgv_SDSpecPath.ClearDS()
                TabControl1.SelectedTab = tp_JobList
                btn_SDConfirm.Enabled = False

                '根據種類進行判斷，
                '全部清除
                If gblCleanConditionFlag = 0 Then
                    ClearAll()

                    '不清除控制項，維持原本條件
                ElseIf gblCleanConditionFlag = 1 Then
                    ClearAllGblVariables()

                    '清空 指定PG、系統、專案
                    CleanPrjFunEmp()

                End If

                '查詢方式改寫By Sean
                'Query() 
                btn_QueryJobList.PerformClick()


            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"重新上傳"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub btn_DeleteFile_Click(sender As Object, e As EventArgs) Handles btn_DeleteFile.Click
        Try
            If dgv_SDSpecPath.SelectedIndex().Length = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "未選擇任何資料")
            End If
            dgv_SDSpecPath.RemoveAllSelectedRow()
            btn_DeleteFile.Enabled = dgv_SDSpecPath.Rows.Count > 0
            btn_ReUploadSpec.Enabled = dgv_SDSpecPath.Rows.Count > 0
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增檔案"})
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Try
            QueryIssueList()

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢未解決需求紀錄"})
        End Try
    End Sub


#End Region
#End Region

#Region "     存檔前取得需求編號"

    Protected Function GetIssueIdString() As String
        Dim IssueID As String = ""




        Try
            If CheckHasValue(dgv_IssueRecordList.GetSelectedDS) Then
                For Each dr In dgv_IssueRecordList.GetSelectedDS.Tables(0).Rows
                    IssueID &= dr("Source").ToString.Trim & "-" & dr("Issue_Id").ToString.Trim & ","
                Next
                IssueID = IssueID.Substring(0, IssueID.Length - 1)
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"存檔前取得需求編號"})
        End Try
        Return IssueID
    End Function

#End Region

#Region "     查詢需求單"

    Protected Sub QueryIssueList()

        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryUnfinishIssueRecordList)
            SendDS.Tables(0).Rows.Add("QueryUnfinishIssueRecordList", dtp_IssueDateStart.GetUsDateStr)
            Dim ResultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            dgv_IssueRecordList.Enabled = True

            If CheckMethodUtil.CheckHasValue(ResultDS) Then
                initialdgvIssueRecordListGrid(ResultDS)
            Else
                initialdgvIssueRecordListGrid(New DataSet)
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢需求單"})
        End Try
    End Sub

#End Region

#Region "     取得要查詢的建立者"

    Private Function GetAssignUser() As String
        Try

            If rbt_SA.Checked Then
                Return cbo_SAName.SelectedValue
            ElseIf rbt_SD.Checked Then
                Return cbo_SDName.SelectedValue
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return ""
    End Function
#End Region

#End Region

#Region "     Show內容派工內容"

    ''' <summary>
    ''' Show內容派工內容
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-09-20</remarks>
    Protected Sub ShowDetails()
        Try
            If dgv_JobList.CurrentCell Is Nothing Then
                dgv_JobList.CurrentCell = dgv_JobList.Rows(0).Cells(0)
            End If

            Dim stbData As New StringBuilder

            stbData.AppendLine("工作內容")

            stbData.AppendLine("主旨：" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Mail_Subject").ToString.Trim)

            stbData.AppendLine("備註：")
            stbData.AppendLine(dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Issue_Desc").ToString.Trim)

            stbData.AppendLine("")
            stbData.AppendLine("SA：" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Assign_User").ToString.Trim)
            ' stbData.AppendLine("SD：" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("SD_Employee_Code").ToString.Trim)

            stbData.AppendLine("PG：" & dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentRow.Index).Item("Employee_Name").ToString.Trim)

            Dim uclDialogUI As Syscom.Client.UCL.UclMutiGridUI = Syscom.Client.UCL.UclMutiGridUI.GetInstance
            uclDialogUI.ShowDialogText("工作內容", stbData.ToString)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     插入附加檔案"



    Private Sub AddNewAttFile(ByVal FID As String)
        Try

            Dim FilePath As String = DownloadFileByFID(FID, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\JOB\", False, False)
            If CheckPathIsExist(FilePath) Then
                dgv_Path.Rows.Add(False, FilePath)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

End Class