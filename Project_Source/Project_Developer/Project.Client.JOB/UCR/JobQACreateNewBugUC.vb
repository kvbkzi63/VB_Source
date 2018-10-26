Imports System.Collections
Imports System.Data
Imports System.ServiceModel
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP
Imports JOBClientServiceFactory
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility.ScreenUtil
Imports System.Diagnostics
Imports Project.Comm.JOB

Public Class JobQACreateNewBugUC

    Private GridColumnSetting As String(,) = {{"FID", "FID", "N", "0"},
                                              {"File_Name", "檔案名稱", "Y", "200"},
                                              {"DownLoad", "下載", "Y", "50"},
                                              {"Delete", "刪除", "Y", "50"},
                                              {"Sort_Value", "Sort_Value", "N", "0"}}


    Dim WithEvents eventMgr As EventManager
    Dim BugDT As DataTable = JobQaBugRecordDataTableFactory.getDataTableWithNoPK


#Region "     外部屬性"

    Private m_Project_Id As String

    Public Property Project_Id As String
        Get
            Return m_Project_Id
        End Get
        Set(value As String)
            m_Project_Id = value
        End Set
    End Property

    Private m_Bug_Id As String

    Public Property Bug_Id As String
        Get
            Return m_Bug_Id
        End Get
        Set(value As String)
            m_Bug_Id = value
        End Set
    End Property

    Private m_VerID As String

    Public Property Ver_Id As String
        Get
            Return m_VerID
        End Get
        Set(value As String)
            m_VerID = value
        End Set
    End Property
    Private m_BugStatus As String = ""
    Public Property BugStatus As String
        Get
            Return m_BugStatus
        End Get
        Set(value As String)
            m_BugStatus = value
        End Set
    End Property
    Enum CallType As Integer
        CreateNewIssue
        ModifyIssue
    End Enum

    Private MyCallType As CallType = CallType.CreateNewIssue

    Public WriteOnly Property SetCallType As CallType
        Set(value As CallType)
            MyCallType = value
        End Set
    End Property

#End Region

#Region "     初始化"

    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        LoadEventManager()

        TableLayoutPanel1.Enabled = (MyCallType = CallType.CreateNewIssue)
    End Sub



#Region "     初始化下拉選單與明細"

    Public Sub Initial(ByVal CallType As CallType, ByVal VerId As String, ByVal Status As String)
        Try
            Me.Ver_Id = VerId
            Me.BugStatus = Status
            InitialComboBox()
            InitialGrid()

            cbo_Function.Enabled = (CInt(BugStatus) = 1)
            cbo_IssueClassify.Enabled = (CInt(BugStatus) = 1)
            cbo_IssueLevel.Enabled = (CInt(BugStatus) = 1)
            cbo_System.Enabled = (CInt(BugStatus) = 1)
            rtb_IssueDescription.Enabled = (CInt(BugStatus) = 1)
            txt_IssueSubject.Enabled = (CInt(BugStatus) = 1)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        End Try


    End Sub
    Private Sub InitialComboBox()
        Try
            Dim IssueLevelDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9004)
            Dim IssueClassifyDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9005)

            If CheckHasValue(IssueLevelDS) Then
                cbo_IssueLevel.DataSource = IssueLevelDS.Tables(0).Copy
                cbo_IssueLevel.uclDisplayIndex = "1"
                cbo_IssueLevel.uclValueIndex = "0"
            End If

            If CheckHasValue(IssueClassifyDS) Then
                cbo_IssueClassify.DataSource = IssueClassifyDS.Tables(0).Copy
                cbo_IssueClassify.uclDisplayIndex = "1"
                cbo_IssueClassify.uclValueIndex = "0"
            End If

        Catch cmex As CommonException
            MessageBox.Show(cmex.ToString)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try
    End Sub

    Private Sub InitialGrid()
        Try

            If MyCallType = CallType.CreateNewIssue Then
                ShowAttGrid(New DataSet)
            Else
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryBugDetailForModifiy)
                SendDS.Tables(0).Rows.Add("QueryBugDetailForModifiy", Bug_Id, Me.Ver_Id)
                Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
                If CheckHasValue(retDS) Then

                    If CheckHasValue(retDS.Tables(0)) Then
                        ReceiveProjectChanged(retDS.Tables(0).Rows(0).Item("Project_Id").ToString.Trim)

                        cbo_System.SelectedValue = retDS.Tables(0).Rows(0).Item("System_Code").ToString.Trim
                        cbo_Function.SelectedValue = retDS.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
                        cbo_IssueClassify.SelectedValue = retDS.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim
                        cbo_IssueLevel.SelectedValue = retDS.Tables(0).Rows(0).Item("Issue_Level").ToString.Trim
                        txt_IssueSubject.Text = retDS.Tables(0).Rows(0).Item("Issue_Subject").ToString.Trim
                        rtb_IssueDescription.Text = retDS.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim

                        Dim bugDR As DataRow = BugDT.NewRow
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Bug_Id) = Bug_Id
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Function_Code) = retDS.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.System_Code) = retDS.Tables(0).Rows(0).Item("System_Code").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Classify) = retDS.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Desc) = retDS.Tables(0).Rows(0).Item("Issue_Desc").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Level) = retDS.Tables(0).Rows(0).Item("Issue_Level").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Subject) = retDS.Tables(0).Rows(0).Item("Issue_Subject").ToString.Trim
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Modified_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Version_Id) = Ver_Id
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Test_Result) = BugStatus
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Test_Note) = retDS.Tables(0).Rows(0).Item("Test_Note").ToString.Trim
                        If IsDate(retDS.Tables(0).Rows(0).Item("Retest_Date")) Then
                            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Retest_Date) = CDate(retDS.Tables(0).Rows(0).Item("Retest_Date")).ToString("yyyy/MM/dd")
                        End If
                        bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Retest_Version) = retDS.Tables(0).Rows(0).Item("Retest_Version").ToString.Trim

                            BugDT.Rows.Add(bugDR)
                        End If
                        If CheckHasValue(retDS.Tables(1)) Then
                        Dim AttDS As New DataSet
                        AttDS.Tables.Add(retDS.Tables(1).Copy)
                        ShowAttGrid(AttDS)
                    Else
                        ShowAttGrid(New DataSet)
                    End If

                End If

            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        End Try
    End Sub

#End Region
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

#Region "     Grid顯示控制"
    Enum ColumnIndex As Integer
        FID
        File_Name
        DownLoad
        Delete
        Sort_Value
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
            Dim btnCell As New Syscom.Client.UCL.ButtonCell
            btnCell.Text = "下載"
            Dim btnDeleteCell As New Syscom.Client.UCL.ButtonCell
            btnDeleteCell.Text = "刪除"

            ht.Add(-1, ds)
            ht.Add(ColumnIndex.DownLoad, btnCell)
            ht.Add(ColumnIndex.Delete, btnDeleteCell)
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
    Public Sub ShowAttGrid(ByVal ds As DataSet)

        Try

            dgv_AttFiles.Initial(GetHashTable(GetGridDs(ds)))
            dgv_AttFiles.uclHeaderText = GetGridColumnSetting(GetColumnSettingType.Header)
            dgv_AttFiles.uclColumnWidth = GetGridColumnSetting(GetColumnSettingType.Width)
            dgv_AttFiles.uclVisibleColIndex = GetColumnViewIndex()
            dgv_AttFiles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid 標題"})
        End Try

    End Sub

#End Region

#Region "     下拉選單事件"
    ''' <summary>
    ''' 接收專案改變的事件拋出
    ''' </summary>
    ''' <param name="ProjectID"></param>
    Private Sub ReceiveProjectChanged(ByVal ProjectID As String) Handles eventMgr.ReceiveProjectChanged
        Try
            Me.Project_Id = ProjectID
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QuerySystemDataByProjectID)
            SendDS.Tables(0).Rows.Add("QuerySystemDataByProjectID", ProjectID, "")
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                cbo_System.DataSource = retDS.Tables(0).Copy
                cbo_System.uclDisplayIndex = "2"
                cbo_System.uclValueIndex = "1"
                cbo_System.SelectedValue = ""
                cbo_System_SelectedIndexChanged(cbo_System, New EventArgs)
            Else
                cbo_System.DataSource = Nothing
                cbo_System.SelectedValue = ""
                cbo_Function.DataSource = Nothing
                cbo_Function.SelectedValue = ""
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"下拉選單事件"})
        End Try
    End Sub

    Private Sub cbo_System_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_System.SelectedIndexChanged
        Try
            If sender.SelectedValue <> "" Then
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryFunctionDataByProjectIDandSystemCode)
                SendDS.Tables(0).Rows.Add("QueryFunctionDataByProjectIDandSystemCode", Project_Id, sender.SelectedValue)
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


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"下拉選單事件"})
        End Try

    End Sub




#End Region

#Region "     按鈕事件"
    ''' <summary>
    ''' 新增上傳附檔
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Lock(Me)
        Try
            If txt_FilePath.Text = "" OrElse Not IO.File.Exists(txt_FilePath.Text) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "路徑不正確或者檔案不存在，請重新輸入")
                Exit Sub
            Else
                Dim file As New IO.FileInfo(txt_FilePath.Text)

                If dgv_AttFiles.GetDBDS.Tables(0).Select("File_Name = '" & file.Name & "'").Length > 0 Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "重複上傳")
                End If
                Dim FID As String = ProjectClientBP.getInstance.UploadFileToFTM(txt_FilePath.Text)
                dgv_AttFiles.AddNewRow()
                dgv_AttFiles.GetDBDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("File_Name") = file.Name
                dgv_AttFiles.GetGridDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("File_Name") = file.Name
                dgv_AttFiles.GetDBDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("Sort_Value") = dgv_AttFiles.Rows.Count
                dgv_AttFiles.GetGridDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("Sort_Value") = dgv_AttFiles.Rows.Count
                dgv_AttFiles.GetDBDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("FID") = FID
                dgv_AttFiles.GetGridDS.Tables(0).Rows(dgv_AttFiles.Rows.Count - 1).Item("FID") = FID
                txt_FilePath.Text = ""
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增上傳附檔"})
        Finally
            UnLock(Me)
        End Try

    End Sub
    ''' <summary>
    ''' 瀏覽資料夾
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Browse_Click(sender As Object, e As EventArgs) Handles btn_Browse.Click
        Try
            Dim fd As New OpenFileDialog

            If fd.ShowDialog = DialogResult.OK Then
                txt_FilePath.Text = fd.FileName
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"瀏覽資料夾"})
        End Try

    End Sub
    ''' <summary>
    ''' 新增並送出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Confirm.Click
        Lock(Me)
        Try
            If CheckBeforeSave() Then Exit Sub

            Dim SendDS As DataSet = GetActionDS()
            Dim ResultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(ResultDS) AndAlso ResultDS.Tables(0).Rows(0).Item(0) > 0 Then
                ClearAll()
                MessageHandling.ShowWarnMsg("CMMCMMB300", "儲存成功")
                eventMgr.RaiseJobQACreateNewJobUC_CreateNewBug(sender, e)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "儲存失敗")
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增並送出"})
        Finally
            UnLock(Me)
        End Try

    End Sub


#End Region

#Region "     Grid事件"
    ''' <summary>
    ''' 點擊下載
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_AttFiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_AttFiles.CellClick
        Lock(Me)
        If e.RowIndex < 0 Then Exit Sub
        Try

            Select Case e.ColumnIndex
                Case ColumnIndex.DownLoad
                    Dim FID As String = dgv_AttFiles.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ColumnIndex.FID).ToString.Trim
                    Process.Start(ProjectClientBP.getInstance.LoadFileByFID(FID, dgv_AttFiles.GetDBDS.Tables(0).Rows(e.RowIndex).Item(ColumnIndex.File_Name).ToString.Trim))
                Case ColumnIndex.Delete
                    dgv_AttFiles.RemoveRowAt(e.RowIndex)
            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點擊下載"})
        Finally
            UnLock(Me)
        End Try
    End Sub


#End Region

#Region "     檢核"
    ''' <summary>
    ''' 送出前檢核
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckBeforeSave() As Boolean
        Try
            If cbo_Function.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "功能歸屬不得為空")
                Return True
            End If
            If cbo_System.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "系統別不得為空")
                Return True
            End If
            If cbo_IssueLevel.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "嚴重性不得為空")
                Return True
            End If
            If cbo_IssueClassify.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "BUG類別不得為空")
                Return True
            End If
            If txt_IssueSubject.Text = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "主述不得空白")
                Return True
            End If
            If rtb_IssueDescription.Text = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "問題描述不得空白")
                Return True
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢核"})
        End Try
        Return False
    End Function

#End Region
#Region "     取得存檔前的DS"

    Private Function GetActionDS() As DataSet
        Dim SendDS As DataSet = Nothing
        Dim dr As DataRow = Nothing



        Try
            If MyCallType = CallType.ModifyIssue Then Return GetSaveDS(DsType.UpdateAttFiles)

            SendDS = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.CreateNewBug)
            dr = SendDS.Tables(0).NewRow
            dr(0) = "CreateNewBug"
            dr("Project_Id") = Project_Id
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Version_Id) = Ver_Id
            dr(JobQaBugRecordDataTableFactory.DBColumnName.System_Code) = cbo_System.SelectedValue
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Function_Code) = cbo_Function.SelectedValue
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Subject) = txt_IssueSubject.Text
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Desc) = rtb_IssueDescription.Text
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Level) = cbo_IssueLevel.SelectedValue
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Classify) = cbo_IssueClassify.SelectedValue
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Create_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Modified_User) = dr(JobQaBugRecordDataTableFactory.DBColumnName.Create_User)
            dr(JobQaBugRecordDataTableFactory.DBColumnName.Test_Result) = BugStatus
            SendDS.Tables(0).Rows.Add(dr)
            If dgv_AttFiles.GetDBDS.Tables(0).Rows.Count > 0 Then
                For i As Int32 = 0 To dgv_AttFiles.GetDBDS.Tables(0).Rows.Count - 1
                    Dim AttDr As DataRow = SendDS.Tables(1).NewRow
                    AttDr(JobQaAttachedFilesDataTableFactory.DBColumnName.Bug_Id) = Bug_Id
                    AttDr(JobQaAttachedFilesDataTableFactory.DBColumnName.Version_Id) = Ver_Id
                    AttDr(JobQaAttachedFilesDataTableFactory.DBColumnName.FID) = dgv_AttFiles.GetDBDS.Tables(0).Rows(i)("FID")
                    AttDr(JobQaAttachedFilesDataTableFactory.DBColumnName.File_Name) = dgv_AttFiles.GetDBDS.Tables(0).Rows(i)("File_Name")
                    AttDr(JobQaAttachedFilesDataTableFactory.DBColumnName.Sort_Value) = i
                    SendDS.Tables(1).Rows.Add(AttDr)
                Next
            End If



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Get ActionDS"})
        End Try
        Return SendDS
    End Function


    Enum DsType As Integer
        UpdateAttFiles
        UpdateBugRecordForRetest
    End Enum

    ''' <summary>
    ''' 取得修改存檔的DS
    ''' </summary>
    ''' <returns></returns>
    Public Function GetSaveDS(ByVal type As DsType) As DataSet


        Dim retDS As New DataSet
        Try
            If CheckBeforeSave() Then Return Nothing

            Dim ActionDT As New DataTable
            ActionDT.Columns.Add("Action")
            ActionDT.Columns.Add("Type")
            ActionDT.Rows.Add("UpdateBugRecordForRetest", type.ToString)
            Dim AttDT As DataTable = JobQaAttachedFilesDataTableFactory.getDataTableWithNoPK
            Dim bugDR As DataRow = BugDT.Rows(0)


            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Bug_Id) = Bug_Id
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Function_Code) = cbo_Function.SelectedValue
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.System_Code) = cbo_System.SelectedValue
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Classify) = cbo_IssueClassify.SelectedValue
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Desc) = rtb_IssueDescription.Text
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Level) = cbo_IssueLevel.SelectedValue
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Issue_Subject) = txt_IssueSubject.Text
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Modified_User) = Syscom.Comm.Utility.AppContext.userProfile.userId
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Version_Id) = Ver_Id
            bugDR(JobQaBugRecordDataTableFactory.DBColumnName.Test_Result) = BugStatus

            Dim cnt As Int32 = 0
            If dgv_AttFiles.Rows.Count > 0 Then
                For Each dr As DataRow In dgv_AttFiles.GetDBDS.Tables(0).Rows
                    Dim AttDR As DataRow = AttDT.NewRow
                    AttDR(JobQaAttachedFilesDataTableFactory.DBColumnName.Bug_Id) = Bug_Id
                    AttDR(JobQaAttachedFilesDataTableFactory.DBColumnName.File_Name) = dr("File_Name")
                    AttDR(JobQaAttachedFilesDataTableFactory.DBColumnName.FID) = dr("FID")
                    AttDR(JobQaAttachedFilesDataTableFactory.DBColumnName.Sort_Value) = cnt
                    AttDR(JobQaAttachedFilesDataTableFactory.DBColumnName.Version_Id) = Ver_Id

                    AttDT.Rows.Add(AttDR.ItemArray)
                    cnt += 1
                Next
            End If

            retDS.Tables.Add(ActionDT)
            retDS.Tables.Add(BugDT.Copy)
            retDS.Tables.Add(AttDT)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得修改存檔的DS"})
        End Try
        Return retDS
    End Function
#End Region
#Region "     清除"

    Public Sub ClearAll()
        dgv_AttFiles.ClearDS()
        dgv_AttFiles.ClearSelection()
        txt_FilePath.Text = ""
        cbo_Function.SelectedValue = ""
        cbo_IssueClassify.SelectedValue = ""
        cbo_IssueLevel.SelectedValue = ""
        cbo_System.SelectedValue = ""
        rtb_IssueDescription.Text = ""
        txt_IssueSubject.Text = ""
    End Sub
#End Region

End Class
