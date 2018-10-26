Imports System.Collections
Imports System.Data
Imports System.ServiceModel
Imports System.Windows.Forms
Imports Syscom.Comm.EXP
Imports JOBClientServiceFactory
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Project.Comm.JOB
Imports Syscom.Comm.Utility.ScreenUtil
Imports Syscom.Client.UCL
Imports Syscom.Comm.Utility
Imports System.Collections.Generic

Public Class JobQAJobListUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "     事件宣告"

    Dim WithEvents eventMgr As EventManager



#End Region

    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。


        JobQABugListGridviewUC1.ShowBugListGrid(New DataSet)
        InitialComboBox()
        LoadEventManager()
    End Sub



#Region "     初始化"
    Dim initialDS As DataSet
    Private Sub InitialComboBox()


        Try

            initialDS = JOBServiceManager.getInstance.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))
            If initialDS.Tables("Project").Rows.Count > 0 Then
                cbo_Project.DataSource = initialDS.Tables("Project").Copy
                cbo_Project.uclDisplayIndex = "1"
                cbo_Project.uclValueIndex = "0"
            End If

            Dim KindDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9003)

            If Syscom.Comm.Utility.CheckMethodUtil.CheckHasValue(KindDS) Then
                cbo_DeployKind.DataSource = KindDS.Tables(0).Copy
                cbo_DeployKind.uclDisplayIndex = "1"
                cbo_DeployKind.uclValueIndex = "0"
            End If
            If initialDS.Tables.Contains("HospList") Then
                cbo_Hosp.DataSource = initialDS.Tables("HospList").Copy
                cbo_Hosp.uclDisplayIndex = "0,1"
                cbo_Hosp.uclValueIndex = "0"
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化下拉選單"})
        End Try


    End Sub


#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-9-30</remarks>
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
    ''' <remarks>by Sean.Lin on 2017-09-30</remarks>
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
#Region "     控制項事件"

    ''' <summary>
    ''' 填入資料
    ''' </summary>
    ''' <param name="dr"></param>
    Private Sub SetData(ByVal dr As DataRow)


        Try

            txt_CurrentVer.Text = dr("Test_Version").ToString.Trim
            txt_CurrentVer.Tag = dr("Version_Id").ToString.Trim
            dtp_CurrentVerDate.SetValue(CDate(dr("Deploy_Date").ToString.Trim).ToString("yyyy/MM/dd"))
            rtb_VerDescription.Text = dr("Version_Desc").ToString.Trim
            ckb_IsClose.Checked = dr("Close_Flag").ToString.Trim.Equals("Y")
            btn_Update.Enabled = Not ckb_IsClose.Checked
            rtb_VerDescription.Enabled = Not ckb_IsClose.Checked
            btn_Close.Enabled = Not ckb_IsClose.Checked

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Grid點擊事件"})
        End Try
    End Sub

    ''' <summary>
    ''' TabControl1_SelectedIndexChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Try

            Select Case CType(TabControl1, TabControl).SelectedIndex
                Case 1
                    If txt_CurrentVer.Text = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "尚未選擇版次")
                        TabControl1.SelectedIndex = 0
                        CreateNewBugUC.Enabled = False
                        Exit Sub
                    ElseIf ckb_IsClose.Checked Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "已關帳不得再新增該版次BUG")
                        TabControl1.SelectedIndex = 0
                        CreateNewBugUC.Enabled = False
                        Exit Sub
                    Else

                        CreateNewBugUC.Project_Id = cbo_Project.SelectedValue
                        CreateNewBugUC.Enabled = True
                        CreateNewBugUC.Initial(JobQACreateNewBugUC.CallType.CreateNewIssue, txt_CurrentVer.Tag, "01")
                    End If

                Case 2
                    If txt_CurrentVer.Text = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "尚未選擇版次")
                        TabControl1.SelectedIndex = 0
                        Exit Sub
                    End If
                    btn_QueryBugRecord.PerformClick()

            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"TabControl1_SelectedIndexChanged"})
        End Try

    End Sub

    ''' <summary>
    ''' 點擊Grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_BugRecord_Click(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_BugRecord.CellClick
        Try
            If e.RowIndex < 0 Then Exit Sub



            Dim ui As New JobQACheckBugHistoryUI(dgv_BugRecord.GetDBDS.Tables(0).Rows(e.RowIndex)("Version_Id").ToString.Trim, dgv_BugRecord.GetDBDS.Tables(0).Rows(e.RowIndex)("Test_Version").ToString.Trim, dgv_BugRecord.GetDBDS.Tables(0).Rows(e.RowIndex)("Bug_Id").ToString.Trim)
            ui.BugStatus = dgv_BugRecord.GetDBDS.Tables(0).Rows(e.RowIndex)("Status").ToString.Trim
            ui.ShowDialog()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點擊Grid"})
        End Try

    End Sub
    ''' <summary>
    ''' 專案改變
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_Project_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Project.SelectedIndexChanged
        Try
            ClearAll()
            If sender.SelectedValue <> "" Then
                eventMgr.RaiseProjectChangedEvent(sender.SelectedValue)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案改變"})
        End Try
    End Sub
    ''' <summary>
    ''' 發版類別改變
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_DeployKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_DeployKind.SelectedIndexChanged
        Try
            ClearAll()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"專案改變"})
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click, eventMgr.JobQACreateNewBugUC_CreateNewBug
        Lock(Me)
        Try
            If CheckBeforeAction(CheckType.Query) Then Exit Sub
            TabControl1.SelectedIndex = 0
            Query()

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally
            UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' 新增版次
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_CreateNew_Click(sender As Object, e As EventArgs) Handles btn_CreateNew.Click
        Lock(Me)

        Try
            If CheckBeforeAction(CheckType.CreateNew) Then
                btn_Close.Enabled = True
                btn_Update.Enabled = True
                Exit Sub
            End If
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.CreateNewTestVer)
            Dim dr As DataRow = SendDS.Tables(0).NewRow
            dr("Action") = "CreateNewTestVer"

            dr(JobQaTestRecordDataTableFactory.DBColumnName.Deploy_Kind) = cbo_DeployKind.SelectedValue
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Project_Id) = cbo_Project.SelectedValue
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Hospital_Code) = cbo_Hosp.SelectedValue
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Deploy_Date) = dtp_NewVerDate.GetUsDateStr
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Test_Version) = txt_NewVer.Text
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Version_Desc) = rtb_VerDescription.Text
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Create_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
            dr(JobQaTestRecordDataTableFactory.DBColumnName.Modified_User) = dr(JobQaTestRecordDataTableFactory.DBColumnName.Create_User)
            SendDS.Tables(0).Rows.Add(dr)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) AndAlso retDS.Tables(0).Rows(0).Item(0) > 0 Then
                Query()
                txt_NewVer.Text = ""
                dtp_NewVerDate.Clear()
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被新增")
                JobQABugListGridviewUC1.ShowBugListGrid(New DataSet)
            End If




            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"關帳並新增版次"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 修改版次
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        Lock(Me)
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.UpdateVersionDesc)
            SendDS.Tables(0).Rows.Add("UpdateVersionDesc",
                                      rtb_VerDescription.Text,
                                      Syscom.Comm.Utility.AppContext.userProfile.userId,
                                      txt_CurrentVer.Tag)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            If CheckHasValue(retDS) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "修改成功")
                Query()
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改版次"})
        Finally
            UnLock(Me)
        End Try

    End Sub

    Private Sub btn_QueryBugRecord_Click(sender As Object, e As EventArgs) Handles btn_QueryBugRecord.Click
        Lock(Me)
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryBugRecord)
            Dim BugStatus As String = ""
            If rbt_StillWaitting.Checked Then
                BugStatus = "StillWatting"
            ElseIf rbt_UnClose.Checked Then
                BugStatus = "UnClose"
            End If
            SendDS.Tables(0).Rows.Add("QueryBugRecord",
                                      IIf(rbt_CurrVer.Checked, txt_CurrentVer.Tag, ""),
                                      IIf(rbt_OnlyMe.Checked, Syscom.Comm.Utility.AppContext.userProfile.userId, ""),
                                      BugStatus,
                                      cbo_Hosp.SelectedValue,
                                      cbo_Project.SelectedValue,
                                      cbo_DeployKind.SelectedValue)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            If CheckHasValue(retDS) Then
                ShowBugRecordGrid(retDS)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無資料")
                ShowBugRecordGrid(New DataSet)

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改版次"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 關帳
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Lock(Me)
        Try
            If CheckBeforeAction(CheckType.Close) Then Exit Sub


            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.TestVersionClose)

            SendDS.Tables(0).Rows.Add("TestVersionClose", txt_CurrentVer.Tag)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
            If CheckHasValue(retDS) AndAlso CInt(retDS.Tables(0).Rows(0).Item(0)) > 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "關帳完成")
                ClearAll()
                TabControl1.SelectedIndex = 0
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "關帳失敗")
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改版次"})
        Finally
            UnLock(Me)
        End Try
    End Sub


    Private Sub CreateNewVersion(sender As Object, e As EventArgs) Handles txt_NewVer.TextChanged, dtp_NewVerDate.TextChanged

        Try
            If txt_NewVer.Text = "" Then
                rtb_VerDescription.Enabled = False
                btn_Close.Enabled = True
                btn_Update.Enabled = True
            Else
                rtb_VerDescription.Enabled = True
                btn_Close.Enabled = False
                btn_Update.Enabled = False
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查看BUG明細"})
        End Try
    End Sub
    ''' <summary>
    ''' 匯出報表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        Lock(Me)
        Try
            If CheckBeforeAction(CheckType.ExportReport) Then Exit Sub

            Dim retDS As DataSet = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(GetActionDS)

            If CheckHasValue(retDS) Then
                ExportExcel(retDS.Tables(0), "", 0, 0)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無資料")
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出報表"})
        Finally
            UnLock(Me)

        End Try
    End Sub

#End Region

#Region "     Grid顯示控制"


    Private GridColumnSetting As String(,) = {{"Test_Version", "版次", "Y", "60"}, {"Bug_Id", "BUG_ID", "Y", "80"},
                                              {"Test_Employee_Code", "Test_Employee_Code", "N", "0"},
                                              {"Test_Employee_Name", "測試者", "Y", "50"},
                                              {"Status", "Status", "Y", "50"},
                                              {"Issue_Level", "嚴重性", "Y", "60"},
                                              {"Issue_Classify", "問題類別", "Y", "60"},
                                              {"Issue_Subject", "問題主述", "Y", "200"},
                                              {"Version_Id", "Version_Id", "N", "0"}}

    Enum ColumnIndex As Integer
        Test_Version
        Bug_Id
        Test_Employee_Code
        Test_Employee_Name
        Status
        Issue_Level
        Issue_Classify
        Issue_Subject
        Version_Id
    End Enum
    Enum GetColumnSettingType As Integer
        Header = 1
        Width = 3
    End Enum
    ''' <summary>
    ''' 產生GridDS
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetGridDs(ByVal ds As DataSet) As DataSet
        Dim retDS As New DataSet
        retDS.Tables.Add("GridDT")

        Try
            For i As Int32 = 0 To GridColumnSetting.GetUpperBound(0)
                retDS.Tables(0).Columns.Add(GridColumnSetting(i, 0))
            Next
            If Syscom.Comm.Utility.CheckMethodUtil.CheckHasValue(ds) Then

                For i As Int32 = 0 To ds.Tables(0).Rows.Count - 1
                    Dim dr As DataRow = retDS.Tables(0).NewRow
                    For Each c As DataColumn In retDS.Tables(0).Columns
                        If ds.Tables(0).Columns.Contains(c.ColumnName) Then
                            dr(c.ColumnName) = ds.Tables(0).Rows(i).Item(c.ColumnName)
                        End If
                    Next
                    retDS.Tables(0).Rows.Add(dr.ItemArray)
                Next
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"產生GridDS"})
        End Try
        Return retDS
    End Function

    ''' <summary>
    ''' 取得設定欄位字串
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetGridColumnSetting(ByVal setType As GetColumnSettingType) As String
        Dim str As String = ""

        Try
            For i As Int32 = 0 To GridColumnSetting.GetUpperBound(0)
                str = str & GridColumnSetting(i, setType) & ","
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得設定欄位字串"})
        End Try
        Return str.Substring(0, str.Length - 1)

    End Function

    ''' <summary>
    ''' 取得顯示欄位
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetColumnViewIndex() As String
        Dim str As String = ""

        Try
            For i As Int32 = 0 To GridColumnSetting.GetUpperBound(0)
                If GridColumnSetting(i, 2).Equals("Y") Then
                    str = str & i & ","
                End If
            Next
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得顯示欄位"})
        End Try
        Return str

    End Function
    ''' <summary>
    ''' 取得HashTable
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetHashTable(ByVal ds As DataSet) As Hashtable
        Dim ht As New Hashtable
        Try
            Dim StatusDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9006)
            Dim IssueLevelDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9004)
            Dim IssueClassifyDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9005)

            Dim cboStatusCell As New ComboBoxCell
            Dim cboLevelCell As New ComboBoxCell
            Dim cboClasifyCell As New ComboBoxCell
            If CheckHasValue(StatusDS) Then
                Dim cboDS As New DataSet
                cboDS.Tables.Add(StatusDS.Tables(0).Copy)
                cboStatusCell.Ds = cboDS
                cboStatusCell.DisplayIndex = "1"
                cboStatusCell.ValueIndex = "0"
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "PUB_SYSCODE Type_ID(9006)尚未建檔")
            End If
            If CheckHasValue(IssueLevelDS) Then
                cboLevelCell.Ds = IssueLevelDS.Copy
                cboLevelCell.DisplayIndex = "1"
                cboLevelCell.ValueIndex = "0"
            End If

            If CheckHasValue(IssueClassifyDS) Then
                cboClasifyCell.Ds = IssueClassifyDS.Copy
                cboClasifyCell.DisplayIndex = "1"
                cboClasifyCell.ValueIndex = "0"
            End If
            ht.Add(-1, ds)
            ht.Add(ColumnIndex.Status, cboStatusCell)
            ht.Add(ColumnIndex.Issue_Level, cboLevelCell)
            ht.Add(ColumnIndex.Issue_Classify, cboClasifyCell)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得HashTable"})
        End Try
        Return ht
    End Function
    ''' <summary>
    ''' 顯示Grid
    ''' </summary>
    ''' <param name="ds"></param>
    Public Sub ShowBugRecordGrid(ByVal ds As DataSet)

        Try

            dgv_BugRecord.Initial(GetHashTable(GetGridDs(ds)))
            dgv_BugRecord.uclHeaderText = GetGridColumnSetting(GetColumnSettingType.Header)
            dgv_BugRecord.uclColumnWidth = GetGridColumnSetting(GetColumnSettingType.Width)
            dgv_BugRecord.uclVisibleColIndex = GetColumnViewIndex()
            dgv_BugRecord.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Test_Version).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Bug_Id).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Issue_Classify).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Issue_Level).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Status).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv_BugRecord.Columns(ColumnIndex.Test_Employee_Name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid 標題"})
        End Try

    End Sub




#End Region

#Region "     內部私有函數"

#Region "     檢核"
    Enum CheckType As Integer
        Query
        CreateNew
        Close
        Modify
        ExportReport
    End Enum


    ''' <summary>
    ''' 檢核
    ''' </summary>
    ''' <param name="action"></param>
    ''' <returns></returns>
    Private Function CheckBeforeAction(ByVal action As CheckType) As Boolean
        Try
            Select Case action
                Case CheckType.Query, CheckType.ExportReport
                    If cbo_Project.SelectedValue = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "專案未選")
                        Return True
                    End If
                    If cbo_DeployKind.SelectedValue = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "發版類別未選")
                        Return True
                    End If
                    Return False
                Case CheckType.CreateNew
                    If txt_NewVer.Text = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "版號不得為空")
                        Return True
                    End If
                    If rtb_VerDescription.Text = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "描述不得為空")
                        Return True
                    End If
                    If Not IsDate(dtp_NewVerDate.GetUsDateStr) Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "上版日期未選")
                        Return True
                    End If
                    Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.GetMaxTestVersionBeforeCreate)
                    SendDS.Tables(0).Rows.Add("GetMaxTestVersionBeforeCreate", cbo_Project.SelectedValue, cbo_DeployKind.SelectedValue, cbo_Hosp.SelectedValue)
                    Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
                    If CheckHasValue(retDS) AndAlso retDS.Tables(0).Rows(0).Item(0) <> 0 Then
                        If CInt(retDS.Tables(0).Rows(0).Item(0)) = CInt(txt_NewVer.Text) AndAlso CInt(retDS.Tables(0).Rows(0).Item(0)) <> 0 Then
                            MessageHandling.ShowWarnMsg("CMMCMMB300", "此版號已存在，請重新查詢")
                            txt_NewVer.Text = ""
                            dtp_NewVerDate.Clear()
                            Return True
                        End If
                    End If

                    If txt_CurrentVer.Text <> "" AndAlso Not ckb_IsClose.Checked Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "尚未關帳不得新增版次")
                        txt_NewVer.Text = ""
                        dtp_NewVerDate.Clear()
                        Return True
                    End If

                    Return False
                Case CheckType.Close
                    Return False
                    Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.CheckJobStatusBeforeClose)
                    SendDS.Tables(0).Rows.Add("CheckJobStatusBeforeClose", txt_CurrentVer.Tag)
                    Dim Result As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
                    If CheckHasValue(Result) AndAlso Result.Tables(0).Rows.Count > 0 Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", "尚有派工中的問題，請確認問題狀態後再做關帳操作")
                        Return True
                    End If

            End Select


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢核"})
        End Try
        Return True
    End Function


#End Region

#Region "     查詢"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    Private Sub Query()
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryTestVerByProjectAndDeployKind)
            SendDS.Tables(0).Rows.Add("QueryTestVerByProjectAndDeployKind", cbo_Project.SelectedValue, cbo_DeployKind.SelectedValue, cbo_Hosp.SelectedValue)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                JobQABugListGridviewUC1.ShowBugListGrid(retDS)
                SetData(retDS.Tables(0).Rows(0))
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無資料")
                JobQABugListGridviewUC1.ShowBugListGrid(New DataSet)
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try
    End Sub



#End Region

#Region "     清除"

    Private Sub ClearAll()
        txt_CurrentVer.Text = ""
        txt_CurrentVer.Tag = Nothing
        dtp_CurrentVerDate.Clear()
        txt_NewVer.Text = ""
        dtp_NewVerDate.Clear()
        rtb_VerDescription.Text = ""
        dgv_BugRecord.ClearDS()
        dgv_BugRecord.ClearSelection()
        JobQABugListGridviewUC1.ClearAll()
        btn_Close.Enabled = False
        btn_Update.Enabled = False
        ckb_IsClose.Checked = False

    End Sub





#End Region

#Region "     設定"

    ''' <summary>
    ''' 設定查詢要丟的資料集
    ''' </summary>
    ''' <returns></returns>
    Private Function GetActionDS() As DataSet
        Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.ExportTestRecord)
        Dim row As DataRow = SendDS.Tables(0).Rows.Add()
        Try
            row("Action") = "ExportTestRecord"
            row("Project_Id") = cbo_Project.SelectedValue
            row("Deploy_Kind") = cbo_DeployKind.SelectedValue
            row("Test_Version_Condition") = IIf(rbt_CurrVer.Checked AndAlso IsNumeric(txt_CurrentVer.Text), txt_CurrentVer.Text, "")
            row("BUG_ID") = "Y"
            row("Test_Version") = ckb_TestVer.Checked
            row("System_Name") = ckb_System.Checked
            row("Function_Name") = ckb_Function.Checked
            row("Status") = ckb_Status.Checked
            row("Issue_Subject") = ckb_Subject.Checked
            row("Issue_Desc") = ckb_Desc.Checked
            row("Issue_Classify") = ckb_Classify.Checked
            row("Issue_Level") = ckb_Severity.Checked
            row("Test_Employee_Name") = ckb_TestUser.Checked
            row("Hospital_Code") = cbo_Hosp.SelectedValue


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出報表"})

        End Try
        Return SendDS
    End Function
#End Region

#Region "     匯出報表"

#Region "　　匯出Excel"

    ''' <summary> 
    ''' 把Data匯出成Excel，包含天地
    ''' </summary>
    ''' <param name="dtPrint">資料表</param>
    ''' <param name="columnName">欄位名稱，nothing 則直接使用ds 的Column </param>
    ''' <param name="columnWidth">設定資料的寬度，nothing 則使用Auto Header 的Size，如果要用預設的則丟空字串，EX: "0,1,,,,,10"</param>
    ''' <param name="columnHeight">設定資料的高度，nothing 則使用Auto Header 的Size，如果要用預設的則丟空字串，EX: "0,1,,,,,10"</param>
    ''' <param name="reportName">報表名稱</param>
    ''' <remarks>add by qun,2017/3/10,excel欄位寬度完全按照參數傳入設置</remarks>
    Private Sub ExportExcel(ByVal dtPrint As DataTable, ByVal reportName As String, ByVal columnWidth As Int32, ByVal columnHeight As Int32)
        Dim eventMgr As EventManager = Nothing

        Try
            Dim columnName As String() = Nothing
            '設定 EventMgr
            eventMgr = EventManager.getInstance()

            Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
            Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

            Dim RowIndex As Integer = 1
            '----------------------------------------------------------------------------
            '#Step1.Create Excel物件
            '----------------------------------------------------------------------------
            'On Error Resume Next
            Try
                xlApp = New Microsoft.Office.Interop.Excel.Application
            Catch ex As Exception
                '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
                If Err.Number() <> 0 Then Err.Clear()

                '執行一個新的Excel Application            
                xlApp = CreateObject("Excel.Application")

                If Err.Number() <> 0 Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"電腦沒有安裝Excel!"}, "")
                    Exit Sub
                End If
            End Try
            '--------------------------------------------------
            '----------------------------------------------------------------------------
            '#Step2.匯出DataSet的資料到Excel
            '----------------------------------------------------------------------------
            eventMgr.RaiseUclWaitingForm("WaitingStart", "匯出檔案中，請稍後‧‧‧")

            Try
                '取得表頭欄位名稱陣列
                'Dim columnName As String() = gblColumnNameExcelTitle.Split(",")

                xlApp.Visible = False

                '開新活頁簿
                xlBook = xlApp.Workbooks.Add
                '設定活頁簿為焦點
                xlBook.Activate()
                '選取第1張活頁簿
                xlSheet = xlBook.Worksheets(1)

                '設定字型(前4行為表單資訊)
                xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).Font.Name = "新細明體"
                xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                Dim columnStr As String = ""
                For i As Integer = 0 To dtPrint.Columns.Count - 1
                    columnStr += dtPrint.Columns(i).ColumnName & ","
                Next
                If columnStr.LastIndexOf(",") = columnStr.Length - 1 Then
                    columnStr = columnStr.Substring(0, columnStr.Length - 1)
                End If
                columnName = columnStr.Split(",")

                '開始列印表頭部分資訊
                'PrintHeadFont(reportName, reportId, xlSheet, dtPrint, columnName, RowIndex)

                '2015/11/30 使用新版拆開的 列印方式
                '開始列印表頭部分資訊
                PrintPageHeader(reportName, xlSheet, dtPrint, RowIndex)


                '開始列印表格 Header 部分資訊
                RowIndex = PrintColumnHeaderSetColumWidth(xlSheet, dtPrint, columnName, RowIndex)
                '填入表身資料
                RowIndex = PrintdtBody(xlApp, xlSheet, dtPrint, columnName, RowIndex)

                ''儲存Excel
                SaveFileDialog1.FileName = cbo_Project.SelectedValue & "-BugExport-" & Now.ToString("yyyyMMdd") & ".xlsx"
                If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                    xlBook.SaveAs(SaveFileDialog1.FileName)
                End If
                xlApp.Visible = True


            Catch ex As Exception
                ClientExceptionHandler.ProccessException(ex)
            Finally

                eventMgr.RaiseUclWaitingForm("WaitingEnd", "")

                '回收Excel
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                If xlApp IsNot Nothing Then xlApp = Nothing
                If xlBook IsNot Nothing Then xlBook = Nothing
                If xlSheet IsNot Nothing Then xlSheet = Nothing
                If xlRange IsNot Nothing Then xlRange = Nothing
                'GC.Collect()
            End Try

        Catch cmex As CommonException
            ' FinishWork(xlsapp)
            Throw cmex
        Catch ex As Exception
            'FinishWork(xlsapp)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If Not eventMgr Is Nothing Then
                eventMgr = Nothing
            End If
        End Try
    End Sub

#Region "　　表頭 "

    ''' <summary>
    ''' 列印時負責處理表頭
    ''' <paramref name=" xlsheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <param name="reportName">Name of the report.</param>
    ''' <param name="reportId">The report identifier.</param>
    ''' <param name="xlSheet">The xl sheet.</param>
    ''' <param name="dtPrint">The dt print.</param>
    ''' <param name="columnName">Name of the column.</param>
    ''' <param name="rowIndex">Index of the row.</param>
    ''' <returns>System.Int32.</returns>
    ''' <remarks>by Will.Lin on 2015-8-5 ； Sean Lin 2015/11/24</remarks>
    Private Function PrintPageHeader(ByVal reportName As String, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByRef rowIndex As Integer) As Integer
        Try
            '------------------------------------------------
            '報表名稱從第一列第一行開始
            '------------------------------------------------
            '報表編號從第二列第一行開始到第三行，Merge
            '列印日期從第二列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------
            '列印者  從第三列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------

            Dim endColIndexReportId As Integer = 3

            Dim startColIndexPrint As Integer = 4
            Dim endColIndexPrint As Integer = 5

            '有五行以上，調整 Print columnIndex 位置
            If dtPrint.Columns.Count > 5 Then
                endColIndexReportId = dtPrint.Columns.Count - 2
                startColIndexPrint = dtPrint.Columns.Count - 1
                endColIndexPrint = dtPrint.Columns.Count
            End If

            '標題
            xlSheet.Cells(rowIndex, 1) = cbo_Project.SelectedValue & "-BugExport-" & Now.ToString("yyyy/MM/dd")
            xlSheet.Cells(rowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlSheet.Cells(rowIndex, 1).Font.Size = 10
            xlSheet.Cells(rowIndex, 1).Font.Name = "新細明體"
            '設定第一列儲存格合併，合併整個第一列
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Merge()
            rowIndex += 1
            '列印日期
            xlSheet.Cells(rowIndex, startColIndexPrint) = "列印日期：" & DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm"))
            xlSheet.Cells(rowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Name = "新細明體"
            xlSheet.Range(xlSheet.Cells(rowIndex, startColIndexPrint), xlSheet.Cells(rowIndex, endColIndexPrint)).Merge()
            rowIndex += 1

            '列印查詢人員
            xlSheet.Cells(rowIndex, startColIndexPrint) = "列印人員：" & AppContext.userProfile.userName
            xlSheet.Cells(rowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Name = "新細明體"
            xlSheet.Range(xlSheet.Cells(rowIndex, startColIndexPrint), xlSheet.Cells(rowIndex, endColIndexPrint)).Merge()
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "　　標題欄位 "

    ''' <summary>
    ''' 列印時負責處理標題欄位的部分
    ''' <paramref name=" xlsheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <param name="xlSheet">The xl sheet.</param>
    ''' <param name="dtPrint">The dt print.</param>
    ''' <param name="columnName">Name of the column.</param>
    ''' <param name="columnWidth">Width of the column.</param>
    ''' <param name="rowIndex">Index of the row.</param> 
    ''' <returns>System.Int32.</returns>
    ''' <remarks>by Will.Lin on 2015-8-5 ；Sean Lin 2015/11/24</remarks>
    Private Function PrintColumnHeader(ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByVal columnWidth As String(), ByRef rowIndex As Integer, Optional ByVal VisibleTableName As Boolean = False) As Integer
        Try

            '填入表格的Title
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Value = columnName
            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Font.Name = "新細明體"
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Font.Size = 10
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0
            For i As Integer = 0 To columnName.Length - 1
                xlSheet.Columns(i + 1).ColumnWidth = 15
                xlSheet.Columns(i + 1).ColumnHeight = 15
            Next
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 列印時負責處理標題欄位的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>add by qun,2017/3/10,欄位寬度按照參數傳入設置 </remarks>
    Private Shared Function PrintColumnHeaderSetColumWidth(ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByRef rowIndex As Integer) As Integer
        Try

            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0

            '根據傳入的rowIndex 進行列印 Table 的 Column Header
            '填入表格的Title
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Value = columnName
            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Font.Name = "新細明體"
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Font.Size = "10"
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For i As Integer = 0 To columnName.Length - 1
                xlSheet.Columns(i + 1).ColumnWidth = 15
                xlSheet.Rows(rowIndex).RowHeight = 15
            Next
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "　　表格內容 "

    ''' <summary>
    ''' 列印時負責處理表格內容的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref><paramref name=" dtPrint ">要匯出的資料集</paramref><paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <param name="xlApp">The xl application.</param>
    ''' <param name="xlSheet">The xl sheet.</param>
    ''' <param name="dtPrint">The dt print.</param>
    ''' <param name="columnName">Name of the column.</param>
    ''' <param name="rowIndex">Index of the row.</param>
    ''' <param name="wrapFlag">if set to <c>true</c> [wrap flag].</param>
    ''' <returns>System.Int32.</returns>
    ''' <exception cref="System.Exception"></exception>
    ''' <remarks>by Will.Lin on 2015-8-5 ；Sean Lin 2015/11/24</remarks>
    Private Function PrintdtBody(ByRef xlApp As Microsoft.Office.Interop.Excel.Application, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByRef rowIndex As Integer) As Integer
        Dim objrow As Integer = -1
        Dim state As String = "start"

        Try

            Try
                xlApp.Interactive = False

                If xlApp.Ready = False Then
                    Threading.Thread.Sleep(2)
                End If

            Catch ex As Exception

            End Try

            '填入表身資料
            For iRow As Integer = 0 To dtPrint.Rows.Count - 1
                '時間日期處理
                For ItemIndex = 0 To dtPrint.Rows(iRow).ItemArray.Length - 1

                    state = "WrapText"

                    If IsDate(dtPrint.Rows(iRow).ItemArray(ItemIndex)) Then
                        state = "Date"
                        xlSheet.Range(xlSheet.Cells(iRow + rowIndex, ItemIndex + 1), xlSheet.Cells(iRow + rowIndex, ItemIndex + 1)).Value = Convert.ToString(dtPrint.Rows(iRow).ItemArray(ItemIndex))
                    Else
                        state = "Value"
                        xlSheet.Range(xlSheet.Cells(iRow + rowIndex, ItemIndex + 1), xlSheet.Cells(iRow + rowIndex, ItemIndex + 1)).Value = dtPrint.Rows(iRow).Item(ItemIndex)
                    End If

                Next
                objrow = iRow
                If iRow Mod 100 = 0 Then
                    EventManager.getInstance.RaiseUclWaitingForm("WaitingEnd", "")
                    EventManager.getInstance.RaiseUclWaitingForm("WaitingStart", "匯出Excel資料中 ( " & iRow & " / " & dtPrint.Rows.Count & " )，請稍後‧‧‧")
                End If
            Next

            '回傳列印完的最後一行
            Return rowIndex + dtPrint.Rows.Count

        Catch comex As System.Runtime.InteropServices.COMException
            Throw New Exception(String.Format("objrow:{0},dtPrint.rows:{1},dtPrint.columns{2},rowindex:{3},state:{4},data:{5},ex:{6}", objrow, dtPrint.Rows.Count, dtPrint.Columns.Count, rowIndex, state, String.Join(",", dtPrint.Rows(objrow).ItemArray), comex.Message))
        Catch ex As Exception
            Throw ex
        Finally
            If xlApp.Interactive = False Then xlApp.Interactive = True
        End Try

    End Function

#End Region


#End Region

#End Region

#End Region

#Region "     外部事件"
    ''' <summary>
    ''' BUG狀態異動
    ''' </summary>
    Private Sub JobQACheckBugHistoryUI_StatusModified() Handles eventMgr.JobQACheckBugHistoryUI_StatusModified
        Try
            btn_QueryBugRecord.PerformClick()
            btn_Query.PerformClick()
            TabControl1.SelectedIndex = 2

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"BUG狀態異動"})
        End Try
    End Sub

#End Region
End Class