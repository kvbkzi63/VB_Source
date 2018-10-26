Imports System.Collections
Imports System.Data
Imports System.ServiceModel
Imports System.Windows.Forms
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Project.Comm.JOB
Imports Syscom.Client.CMM
Imports JOBClientServiceFactory
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility.ScreenUtil
Imports System.Collections.Generic
Imports Syscom.Client.UCL


Public Class JobQACheckBugHistoryUI

    Dim WithEvents eventMgr As EventManager


#Region "     自訂外部屬性"

    Private m_Bug_Id As String = ""
    ''' <summary>
    ''' 設定Bug_Id
    ''' </summary>
    ''' <returns></returns>
    Public Property Bug_Id As String
        Get
            Return m_Bug_Id
        End Get
        Set(value As String)
            m_Bug_Id = value
            lbl_BugId.Text = Bug_Id
        End Set
    End Property

    Private m_Ver_Id As String = ""
    ''' <summary>
    ''' 設定Ver_Id
    ''' </summary>
    ''' <returns></returns>
    Public Property Ver_Id As String
        Get
            Return m_Ver_Id
        End Get
        Set(value As String)
            m_Ver_Id = value
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
    Private m_IsSD As Boolean = False
    ''' <summary>
    ''' 判斷角色
    ''' </summary>
    ''' <returns></returns>
    Public Property IsSD As Boolean
        Get
            Return m_IsSD
        End Get
        Set(value As Boolean)
            m_IsSD = value
        End Set
    End Property

#End Region


#Region "     初始化"

    Public Sub New(ByVal VerID As String, ByVal TestVer As String, ByVal BugId As String)
        ' 設計工具需要此呼叫。
        InitializeComponent()
        Lock(Me)
        Try
            Me.Ver_Id = VerID
            Me.Bug_Id = BugId
            lbl_Ver.Text = TestVer
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-10-02</remarks>
    Public Sub ShownMe() Handles Me.Shown
        Lock(Me)
        Try
            LoadEventManager()
            ShowGridView(New DataSet, dgv_PGRemark)
            ShowGridView(New DataSet, dgv_SARemark)
            ShowGridView(New DataSet, dgv_SDRemark)
            JobQACreateNewJobUC1.SetCallType = JobQACreateNewBugUC.CallType.ModifyIssue
            JobQACreateNewJobUC1.Bug_Id = Bug_Id
            dtp_RetestDate.SetValue(Now.ToString("yyyy/MM/dd"))
            InitialComboBox()
            JobQACreateNewJobUC1.Initial(JobQACreateNewBugUC.CallType.ModifyIssue, Ver_Id, BugStatus)
            If IsNumeric(BugStatus) Then
                'JobQACreateNewJobUC1.Enabled = (CInt(BugStatus) = 1)
                InitialGrid()
                dtp_RetestDate.Enabled = (CInt(BugStatus) = 6)
                txt_RetestVer.Enabled = (CInt(BugStatus) = 6)
                rtb_Note.Enabled = (CInt(BugStatus) = 6)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        Finally
            UnLock(Me)
        End Try

    End Sub

    Private Sub InitialComboBox()
        Try

            Dim StatusDS As DataSet = PubServiceManager.getInstance.queryPUBSysCode(9006)
            If CheckHasValue(StatusDS) Then
                Dim cboDS As New DataSet
                cboDS.Tables.Add(StatusDS.Tables(0).Select("Code_En_Name = 'QA'").CopyToDataTable)
                cbo_RetestResult.DataSource = StatusDS.Tables(0).Select("Code_En_Name = 'QA'").CopyToDataTable
                cbo_RetestResult.uclDisplayIndex = "1"
                cbo_RetestResult.uclValueIndex = "0"
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "PUB_SYSCODE Type_ID(9006)尚未建檔")
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化Grid
    ''' </summary>
    Private Sub InitialGrid()

        Try

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InitialJobNoteGrid)
            SendDS.Tables(0).Rows.Add("InitialJobNoteGrid", Bug_Id, Ver_Id)

            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasTable(retDS) Then
                Dim SaDS As New DataSet
                SaDS.Tables.Add(retDS.Tables("SA").Copy)
                ShowGridView(SaDS, dgv_SARemark)
                Dim SdDS As New DataSet
                SdDS.Tables.Add(retDS.Tables("SD").Copy)
                ShowGridView(SdDS, dgv_SDRemark)
                Dim PgDS As New DataSet
                PgDS.Tables.Add(retDS.Tables("PG").Copy)
                ShowGridView(PgDS, dgv_PGRemark)
                If CheckHasValue(retDS, "Job_QA_Bug_Record") Then
                    SetData(retDS.Tables("Job_QA_Bug_Record"))
                End If
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化Grid"})
        End Try


    End Sub

    ''' <summary>
    ''' 填入複測結果
    ''' </summary>
    ''' <param name="dt"></param>
    Private Sub SetData(ByVal dt As DataTable)
        Try
            txt_RetestVer.Text = dt.Rows(0).Item("Retest_Version").ToString.Trim
            cbo_RetestResult.SelectedValue = dt.Rows(0).Item("Test_Result").ToString.Trim
            dtp_RetestDate.SetValue(dt.Rows(0).Item("Retest_Date").ToString.Trim)
            rtb_Note.Text = dt.Rows(0).Item("Test_Note").ToString.Trim
        Catch ex As Exception
            Throw ex
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

#Region "     Grid顯示控制"


    Private SDGridColumnSetting As String(,) = {{"Bug_Id", "BUG_ID", "N", "0"},
                                                {"SD_Employee_Code", "Test_Employee_Code", "N", "0"},
                                                {"SD_Name", "註記人", "Y", "0"},
                                                {"Remark_Date", "日期時間", "Y", "80"},
                                                {"Remark", "註記說明", "Y", "80"}}
    Private SAGridColumnSetting As String(,) = {{"Bug_Id", "BUG_ID", "N", "0"},
                                                {"SA_Employee_Code", "SA_Employee_Code", "N", "0"},
                                                {"SA_Name", "註記人", "Y", "0"},
                                                {"Remark_Date", "日期時間", "Y", "80"},
                                                {"Remark", "註記說明", "Y", "80"}}
    Private PGGridColumnSetting As String(,) = {{"Bug_Id", "BUG_ID", "N", "0"},
                                                {"PG_Employee_Code", "Test_Employee_Code", "N", "0"},
                                                {"PG_Name", "註記人", "Y", "0"},
                                                {"Remark_Date", "日期時間", "Y", "80"},
                                                {"Remark", "註記說明", "Y", "80"}}

    Enum RemarkGridColumnIndex As Integer
        Bug_Id
        Employee_Code
        Employee_Name
        Remark_Date
        Remark
    End Enum
    Enum GetColumnSettingType As Integer
        Header = 1
        Width = 3
    End Enum
    Enum GridType As Integer
        SD = 1
        SA = 2
        PG = 3
    End Enum
    ''' <summary>
    ''' 產生GridDS
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetGridDs(ByVal ds As DataSet, ByVal GridType As GridType) As DataSet
        Dim retDS As New DataSet
        retDS.Tables.Add("GridDT")

        Try
            Select Case GridType
                Case GridType.PG
                    For i As Int32 = 0 To PGGridColumnSetting.GetUpperBound(0)
                        retDS.Tables(0).Columns.Add(PGGridColumnSetting(i, 0))
                    Next
                Case GridType.SA
                    For i As Int32 = 0 To SAGridColumnSetting.GetUpperBound(0)
                        retDS.Tables(0).Columns.Add(SAGridColumnSetting(i, 0))
                    Next
                Case GridType.SD
                    For i As Int32 = 0 To SDGridColumnSetting.GetUpperBound(0)
                        retDS.Tables(0).Columns.Add(SDGridColumnSetting(i, 0))
                    Next
            End Select

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
    Private Function GetGridColumnSetting(ByVal setType As GetColumnSettingType, ByVal GridType As GridType) As String
        Dim str As String = ""

        Try
            Select Case GridType
                Case GridType.PG
                    For i As Int32 = 0 To PGGridColumnSetting.GetUpperBound(0)
                        str = str & PGGridColumnSetting(i, setType) & ","
                    Next
                Case GridType.SA
                    For i As Int32 = 0 To SAGridColumnSetting.GetUpperBound(0)
                        str = str & SAGridColumnSetting(i, setType) & ","
                    Next
                Case GridType.SD
                    For i As Int32 = 0 To SDGridColumnSetting.GetUpperBound(0)
                        str = str & SDGridColumnSetting(i, setType) & ","
                    Next
            End Select

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
    Private Function GetColumnViewIndex(ByVal GridType As GridType) As String
        Dim str As String = ""

        Try
            Select Case GridType
                Case GridType.PG
                    For i As Int32 = 0 To PGGridColumnSetting.GetUpperBound(0)
                        If PGGridColumnSetting(i, 2).Equals("Y") Then
                            str = str & i & ","
                        End If
                    Next
                Case GridType.SA
                    For i As Int32 = 0 To SAGridColumnSetting.GetUpperBound(0)
                        If SAGridColumnSetting(i, 2).Equals("Y") Then
                            str = str & i & ","
                        End If
                    Next
                Case GridType.SD
                    For i As Int32 = 0 To SDGridColumnSetting.GetUpperBound(0)
                        If SDGridColumnSetting(i, 2).Equals("Y") Then
                            str = str & i & ","
                        End If
                    Next
            End Select

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
            ht.Add(-1, ds)
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
    Public Sub ShowGridView(ByVal ds As DataSet, ByRef dgv As Syscom.Client.UCL.UCLDataGridViewUC)
        Dim gridType As GridType = 0
        Try

            Select Case dgv.Name
                Case "dgv_PGRemark"
                    gridType = GridType.PG
                Case "dgv_SDRemark"
                    gridType = GridType.SD
                Case "dgv_SARemark"
                    gridType = GridType.SA

            End Select

            dgv.Initial(GetHashTable(GetGridDs(ds, gridType)))
            dgv.uclHeaderText = GetGridColumnSetting(GetColumnSettingType.Header, gridType)
            dgv.uclColumnWidth = GetGridColumnSetting(GetColumnSettingType.Width, gridType)
            dgv.uclVisibleColIndex = GetColumnViewIndex(gridType)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid 標題"})
        End Try

    End Sub


#End Region

#Region "     控制項事件"

    ''' <summary>
    ''' 存檔
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Try
            If CheckBeforeSave() OrElse GetSaveDS() Is Nothing Then Exit Sub
            Dim SendDS As DataSet = GetSaveDS()
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "儲存成功")
                eventMgr.RaiseJobQACheckBugHistoryUI_StatusModified()
                Me.Close()
            Else

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"存檔"})
        End Try

    End Sub

#End Region

#Region "     內部私有函數"

    Private Function CheckBeforeSave() As Boolean
        Try

            If txt_RetestVer.Text = "" AndAlso (BugStatus = "05" OrElse BugStatus = "06") Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "複測版本未填")
                Return True
            ElseIf IsNumeric(txt_RetestVer.Text) AndAlso CInt(txt_RetestVer.Text) > CInt(lbl_Ver.Text) Then
                If MessageBox.Show("複測版本大於當前版次，是否繼續?", "提示", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Else
                    Return True
                End If
            End If
            If cbo_RetestResult.SelectedValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "複測結果未填")
                Return True
            End If
            If Not IsDate(dtp_RetestDate.GetUsDateStr) AndAlso (BugStatus = "05" OrElse BugStatus = "06") Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "複測日期未填")
                Return True
            End If
            Dim SDReplyList As New List(Of String) From {"08", "09", "10"}
            If IsSD AndAlso Not SDReplyList.Contains(cbo_RetestResult.SelectedValue) Then

                MessageHandling.ShowWarnMsg("CMMCMMB300", "SD/SA 請能回覆【暫緩處理】【非BUG】【不處裡】")
                Return True
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"存檔前檢核"})
        End Try
        Return False
    End Function

    ''' <summary>
    ''' 取得存檔DS
    ''' </summary>
    ''' <returns></returns>
    Private Function GetSaveDS() As DataSet
        Dim retDS As DataSet = Nothing
        Try

            retDS = JobQACreateNewJobUC1.GetSaveDS(JobQACreateNewBugUC.DsType.UpdateBugRecordForRetest)

            If CheckHasValue(retDS, JobQaBugRecordDataTableFactory.tableName) Then
                Dim dr As DataRow = retDS.Tables(JobQaBugRecordDataTableFactory.tableName).Rows(0)
                dr(JobQaBugRecordDataTableFactory.DBColumnName.Retest_Date) = dtp_RetestDate.GetUsDateStr
                dr(JobQaBugRecordDataTableFactory.DBColumnName.Retest_Version) = txt_RetestVer.Text
                dr(JobQaBugRecordDataTableFactory.DBColumnName.Test_Note) = rtb_Note.Text
                dr(JobQaBugRecordDataTableFactory.DBColumnName.Test_Result) = cbo_RetestResult.SelectedValue
                dr(JobQaBugRecordDataTableFactory.DBColumnName.Version_Id) = Ver_Id
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得存檔DS"})
        End Try
        Return retDS
    End Function

    Private Sub JobQACreateNewBugUC_CreateNewBug(sender As Object, e As EventArgs) Handles eventMgr.JobQACreateNewBugUC_CreateNewBug
        Me.Close()
    End Sub
#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Sean.Lin on 2017-11-03</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.Escape
                    Me.Close()
            End Select

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

End Class