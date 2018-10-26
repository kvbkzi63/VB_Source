'/*
'*****************************************************************************
'*
'*    Page/Class Name:  DB異動申請回覆
'*              Title:	JobDBModifyReplyUI
'*        Description:	DB異動申請回覆
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-05-02
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-05-02
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil

Imports System.Windows.Forms
Imports JOBClientServiceFactory
Imports System.Data
Imports System.Collections
Imports System.Diagnostics

Public Class JobDBModifyReplyUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"
    Private dgvColumnHeaderText As String = "申請日,申請人, Project_ID, Seq_No, 專案名稱, 表格名稱, 表格中文名稱, 異動類型, 限制, 處理狀況, 申請單,回覆"
    Private dgvColumns As String() = {"Create_Time", "Create_User", "Project_ID", "Seq_No", "Project_Name", "Table_Name", "Table_Ch_Name", "Modified_Classify", "Restrict", "Is_Modified", "Modified_FID", "Reject_Reason"}
    Private dgvColumnsVisitIndex As String = "0,1,4,5,6,7,8,9,10,11"
    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection
    Private m_ProjectID As String = ""

    Enum GridColumnsIndex As Integer
        Create_Time
        Employee_Name
        Project_ID
        Seq_No
        Project_Name
        Table_Name
        Table_Ch_Name
        Modified_Classify
        Restrict
        Is_Modified
        Modified_FID
        Reject_Reason
    End Enum
#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Job As IJOBServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobDBModifyReplyUI
    Public Shared Function GetInstance() As JobDBModifyReplyUI
        If myInstance Is Nothing Then
            myInstance = New JobDBModifyReplyUI
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



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     修改 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Private Function UpdateData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
        End Try

    End Function

#End Region

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Private Function QueryData() As Boolean

        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QuerySADBModifyRecord)
            Dim Condition As String = ""
            If rbt_Finished.Checked Then
                Condition = "Finished"
            ElseIf rbt_UnFinish.Checked Then
                Condition = "UnFinish"
            End If
            SendDS.Tables(0).Rows.Add("QuerySADBModifyRecord", CurrentUserID, cbo_Project.SelectedValue, Condition)

            Dim retDS As DataSet = Job.PRJDoAction(SendDS)

            If CheckMethodUtil.CheckHasValue(retDS) Then
                InitialGrid(retDS)
            Else
                InitialGrid(New DataSet)
            End If


            Return True

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "


    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

    End Sub

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            InitialUI()

            QueryData()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub InitialUI()

        Try

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryDBModifyInitialData)
            SendDS.Tables(0).Rows.Add("QueryDBModifyInitialData")
            Dim retDS As DataSet = Job.PRJDoAction(SendDS)

            If CheckMethodUtil.CheckHasValue(retDS) Then
                cbo_Project.DataSource = retDS.Tables(0).Copy
                cbo_Project.uclDisplayIndex = "0,1"
                cbo_Project.uclValueIndex = "0"
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub InitialGrid(ByVal inputDS As DataSet)


        Try
            dgv_DBModifiyList.Initial(GetDgvHT(GetGridDS(inputDS)))
            dgv_DBModifiyList.uclHeaderText = dgvColumnHeaderText
            dgv_DBModifiyList.uclVisibleColIndex = dgvColumnsVisitIndex

            If CheckMethodUtil.CheckHasTable(inputDS) Then
                For i As Int32 = 0 To inputDS.Tables(0).Rows.Count - 1
                    If inputDS.Tables(0).Rows(i).Item("Modified_FID").ToString.Trim.Length > 0 Then
                        dgv_DBModifiyList.EnableButton(i, GridColumnsIndex.Modified_FID)
                    Else
                        dgv_DBModifiyList.DisableButton(i, GridColumnsIndex.Modified_FID)
                    End If
                    If inputDS.Tables(0).Rows(i).Item("Is_Modified").ToString.Trim.Equals("未處理") Then
                        dgv_DBModifiyList.SetRowColor(i, System.Drawing.Color.LightPink)
                        dgv_DBModifiyList.EnableButton(i, GridColumnsIndex.Reject_Reason)
                    ElseIf inputDS.Tables(0).Rows(i).Item("Is_Modified").ToString.Trim.Equals("已處理") Then
                        dgv_DBModifiyList.SetRowColor(i, System.Drawing.Color.LightBlue)
                        dgv_DBModifiyList.DisableButton(i, GridColumnsIndex.Reject_Reason)
                    End If


                Next
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Function GetDgvHT(ByVal ds As DataSet) As Hashtable

        Dim ht As New Hashtable
        Try

            Dim btnCell As New ButtonCell
            btnCell.Text = "下載"
            Dim btnCell2 As New ButtonCell
            btnCell2.Text = "回覆"
            ht.Add(-1, ds)
            ht.Add(GridColumnsIndex.Modified_FID, btnCell)
            ht.Add(GridColumnsIndex.Reject_Reason, btnCell2)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetDgvHT"})
        End Try
        Return ht
    End Function

    Private Function GetGridDS(ByVal ds As DataSet) As DataSet
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("GridDT"))

        Try


            For i As Int32 = 0 To dgvColumns.Length - 1
                retDS.Tables("GridDT").Columns.Add(dgvColumns(i))
            Next

            If CheckMethodUtil.CheckHasValue(ds, "JOB_SA_DBModified_Record") Then

                For Each dr As DataRow In ds.Tables("JOB_SA_DBModified_Record").Rows
                    Dim newDR As DataRow = retDS.Tables(0).NewRow
                    For Each c As DataColumn In ds.Tables(0).Columns
                        If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                            If c.ColumnName.Trim.Equals("Modified_Classify") OrElse c.ColumnName.Trim.Equals("Restrict") Then
                                newDR(c.ColumnName) = GetStr(dr(c.ColumnName), c.ColumnName)
                            ElseIf IsDate(dr(c.ColumnName)) Then
                                newDR(c.ColumnName) = CDate(dr(c.ColumnName)).ToString("yyyy/MM/dd")
                            Else
                                newDR(c.ColumnName) = dr(c.ColumnName)
                            End If
                        End If
                    Next
                    retDS.Tables(0).Rows.Add(newDR)
                Next
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetGridDS"})
        End Try
        Return retDS
    End Function

    Private Function GetStr(ByVal UserInput As String, ByVal Type As String) As String
        Dim Values As String() = UserInput.Split(",")
        Dim retStr As String = ""
        Try

            For Each s As String In Values
                Select Case Type
                    Case "Modified_Classify"
                        Select Case s
                            Case "1"
                                retStr = retStr & "新增Table,"
                            Case "2"
                                retStr = retStr & "欄位異動,"
                            Case "3"
                                retStr = retStr & "欄位型態異動,"
                            Case "4"
                                retStr = retStr & "欄位長度異動,"
                            Case "5"
                                retStr = retStr & "Create Index,"
                            Case "6"
                                retStr = retStr & "PK異動,"
                            Case "7"
                                retStr = retStr & "其他,"
                        End Select
                    Case "Restrict"
                        Select Case s
                            Case "1"
                                retStr = retStr & "無限制,"
                            Case "2"
                                retStr = retStr & "必須和程式同步(BO同步),"
                            Case "3"
                                retStr = retStr & "其他,"
                        End Select
                End Select
            Next

            If retStr.Length > 0 Then
                retStr = retStr.Substring(0, retStr.Length - 1)
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetStr"})
        End Try
        Return retStr
    End Function

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
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
    ''' <remarks>by Will.Lin on 2017-5-2</remarks>
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
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
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

    Private Sub dgv_DBModifiyList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_DBModifiyList.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Try
            Select Case e.ColumnIndex
                Case GridColumnsIndex.Modified_FID
                    If dgv_DBModifiyList.ButtonIsEnable(e.RowIndex, GridColumnsIndex.Modified_FID) Then
                        Process.Start(ProjectClientBP.getInstance.LoadFileByFID(dgv_DBModifiyList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex).ToString.Trim))
                    End If
                Case GridColumnsIndex.Reject_Reason
                    If dgv_DBModifiyList.ButtonIsEnable(e.RowIndex, GridColumnsIndex.Reject_Reason) Then
                        Dim ProjectID As String = dgv_DBModifiyList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(GridColumnsIndex.Project_ID).ToString.Trim
                        Dim SeqNo As String = dgv_DBModifiyList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(GridColumnsIndex.Seq_No).ToString.Trim
                        Dim RejectReason As String = dgv_DBModifiyList.GetDBDS.Tables(0).Rows(e.RowIndex).Item(GridColumnsIndex.Reject_Reason).ToString.Trim
                        Dim JobSAReplyDialogUI As JobSAReplyDialogUI = Nothing
                        Try
                            JobSAReplyDialogUI = New JobSAReplyDialogUI(JobSAReplyDialogUI.CallType.DBAReply, ProjectID, SeqNo, RejectReason, True)
                            If JobSAReplyDialogUI.ShowDialog() Then
                                QueryData()
                                MessageBox.Show("異動回覆完成")
                            End If

                        Catch ex As Exception
                            MessageBox.Show("異動回覆失敗")
                        Finally
                            JobSAReplyDialogUI.Dispose()
                            JobSAReplyDialogUI = Nothing
                        End Try
                    End If

            End Select


        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "     取得存檔的Dataset資料 "



#End Region

#Region "     清除功能 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "查詢")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region
#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Will.Lin on 2017-05-02</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode
                Case Keys.F1

                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
                    End If


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

#End Region

#End Region

End Class

