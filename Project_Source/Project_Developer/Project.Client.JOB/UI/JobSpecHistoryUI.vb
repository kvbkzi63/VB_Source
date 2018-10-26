'/*
'*****************************************************************************
'*
'*    Page/Class Name:  Spec歷史紀錄下載
'*              Title:	JobSpecHistoryUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-12-06
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-12-06
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
Imports System.Data
Imports System.Collections
Imports JOBClientServiceFactory
Imports Project.Client.JOB.ProjectClientBP
Imports System.Diagnostics

Public Class JobSpecHistoryUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobSpecHistoryUI
    Public Shared Function GetInstance() As JobSpecHistoryUI
        If myInstance Is Nothing Then
            myInstance = New JobSpecHistoryUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#Region "     Grid欄位顯示變數"

    Enum GetColumnSettingType As Integer
        Header = 1
        Width = 3
    End Enum
    ''' <summary>
    ''' 取得Grid欄位變數
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <returns></returns>
    Private Function GetDataGridColumn(ByVal dgv As UCLDataGridViewUC) As String(,)

        Try

            Select Case dgv.Name
                Case dgv_AttList.Name
                    Return {{"Source", "來源", "Y", "50"},
                            {"Create_User", "派送者", "Y", "60"},
                            {"Create_Time", "派送時間", "Y", "80"},
                            {"FID", "下載", "Y", "50"}}
                Case dgv_JobList.Name
                    Return {{"Assign_Date", "派送日", "Y", "80"},
                            {"Assign_User", "派送者", "Y", "60"},
                            {"Hospital_Name", "所屬醫院", "Y", "100"},
                            {"Project_Name", "所屬專案", "Y", "100"},
                            {"System_Name", "所屬系統", "Y", "100"},
                            {"Function_Name", "歸屬功能", "Y", "100"},
                            {"Mail_Subject", "主旨", "Y", "200"},
                            {"Job_Code", "Job_Code", "N", "0"}}
            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetDataGridColumn"})
        End Try
        Return Nothing
    End Function

#End Region

#End Region

#Region "     屬性設定 "

    Enum ActionType As Integer
        QueryJobRecord
        GetSpecRecord
    End Enum


#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            ShowDataGridView(dgv_JobList, JOBServiceManager.getInstance.PRJDoAction(GetActionDS(ActionType.QueryJobRecord)))
            Return returnBoolean

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
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            ClearAll()

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


#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入事件管理員
            LoadEventManager()
            intialComboBox()
            ShowDataGridView(dgv_AttList, New DataSet)
            ShowDataGridView(dgv_JobList, New DataSet)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     顯示Grid"
    ''' <summary>
    ''' 顯示Grid
    ''' </summary>
    Private Sub ShowDataGridView(ByRef dgv As UCLDataGridViewUC, ByVal ds As DataSet)
        Try
            dgv.Initial(GetGridHashTable(dgv, ds))
            dgv.uclVisibleColIndex = GetColumnViewIndex(GetDataGridColumn(dgv))
            dgv.uclHeaderText = GetGridColumnSetting(GetDataGridColumn(dgv), GetColumnSettingType.Header)
            dgv.uclColumnWidth = GetGridColumnSetting(GetDataGridColumn(dgv), GetColumnSettingType.Width)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"ShowDataGridView"})
        End Try
    End Sub



    ''' <summary>
    ''' 取得設定欄位字串
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetGridColumnSetting(ByVal GridColumnSetting As String(,), ByVal setType As GetColumnSettingType) As String
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
    Private Function GetColumnViewIndex(ByVal GridColumnSetting As String(,)) As String
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
    ''' <returns></returns>
    Private Function GetGridHashTable(ByRef dgv As UCLDataGridViewUC, ByVal input As DataSet) As Hashtable
        Dim ht As New Hashtable
        Try
            Select Case dgv.Name
                Case dgv_AttList.Name
                    Dim btnCell As New ButtonCell
                    btnCell.Text = "下載"
                    ht.Add(-1, GetGridDs(input, GetDataGridColumn(dgv)))
                    ht.Add(3, btnCell)

                Case dgv_JobList.Name
                    ht.Add(-1, GetGridDs(input, GetDataGridColumn(dgv)))
            End Select


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得HashTable"})
        End Try
        Return ht
    End Function
    ''' <summary>
    ''' 產生GridDS
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    Private Function GetGridDs(ByVal ds As DataSet, ByVal GridColumnSetting As String(,)) As DataSet
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
#End Region

#Region "     初始化下拉選單"
    Dim initialDS As DataSet = Nothing
    Private Sub intialComboBox()
        Try
            If initialDS Is Nothing Then
                initialDS = JOBServiceManager.getInstance.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))
            End If

            If CheckHasValue(initialDS.Tables("Project")) Then
                cbo_Project.DataSource = initialDS.Tables("Project").Copy
                cbo_Project.uclDisplayIndex = "0,1"
                cbo_Project.uclValueIndex = "0"
            End If
            If initialDS.Tables.Contains("HospList") Then
                cbo_Hosp.DataSource = initialDS.Tables("HospList").Copy
                cbo_Hosp.uclDisplayIndex = "0,1"
                cbo_Hosp.uclValueIndex = "0"
            End If

            Dim ActionDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryEmployeeListByLevel)
            ActionDS.Tables(0).Rows.Add("QueryEmployeeListByLevel", "2")
            Dim AssignUser As DataSet = JOBServiceManager.getInstance.PRJDoAction(ActionDS)
            If CheckHasValue(AssignUser) Then
                cbo_AssignUser.DataSource = AssignUser.Tables(0).Copy
                cbo_AssignUser.uclDisplayIndex = "0,1"
                cbo_AssignUser.uclValueIndex = "0"
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#End Region


#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-12-6</remarks>
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
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
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


#Region "     取得存檔的Dataset資料 "
    ''' <summary>
    ''' 取得ActionDS
    ''' </summary>
    ''' <param name="Action"></param>
    ''' <returns></returns>
    Private Function GetActionDS(ByVal Action As ActionType) As DataSet
        Dim ds As New DataSet
        ds.Tables.Add(New DataTable("Action"))
        ds.Tables(0).Columns.Add("Action")

        Try

            Select Case Action
                Case ActionType.GetSpecRecord
                    ds.Tables(0).Columns.Add("Job_Code")
                    ds.Tables(0).Rows.Add("GetSpecRecord", dgv_JobList.GetDBDS.Tables(0).Rows(dgv_JobList.CurrentCell.RowIndex).Item("Job_Code").ToString.Trim)
                Case ActionType.QueryJobRecord
                    ds.Tables(0).Columns.Add("Hospital_Code")
                    ds.Tables(0).Columns.Add("Project_ID")
                    ds.Tables(0).Columns.Add("System_Code")
                    ds.Tables(0).Columns.Add("Function_Code")
                    ds.Tables(0).Columns.Add("Create_User")
                    ds.Tables(0).Columns.Add("Assign_SDate")
                    ds.Tables(0).Columns.Add("Assign_EDate")
                    ds.Tables(0).Rows.Add("QueryJobAssignRecord",
                                          cbo_Hosp.SelectedValue,
                                          cbo_Project.SelectedValue,
                                          cbo_System.SelectedValue,
                                          cbo_Function.SelectedValue,
                                          dtp_StartDate.GetUsDateStr,
                                          dtp_EndDate.GetUsDateStr)
            End Select

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"GetActionDS"})
        End Try
        Return ds
    End Function

#End Region

#Region "     清除功能 "

    Private Sub ClearAll()
        Try
            cbo_Hosp.SelectedValue = ""
            cbo_Project.SelectedValue = ""
            cbo_System.SelectedValue = ""
            cbo_Function.SelectedValue = ""
            cbo_AssignUser.SelectedValue = ""
            dtp_StartDate.Clear()
            dtp_EndDate.Clear()
            dgv_JobList.ClearDS()
            dgv_AttList.ClearDS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
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

#Region "     清除 鎖定功能 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (ClearData()) Then

                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "清除")

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
    ''' <remarks>by Will.Lin on 2017-12-06</remarks>
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

                Case Keys.F5

                    '清除
                    If btn_Clear.Enabled Then
                        btn_Clear.PerformClick()
                    End If

                    'Case Keys.Enter
                    'Me.ProcessTabKey(True)

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

#Region "     事件處理"

    Private Sub cbo_Project_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Project.SelectedIndexChanged

        If cbo_Project.SelectedValue.GetType().ToString.Equals("System.String") AndAlso cbo_Project.SelectedValue <> "" Then
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

    ''' <summary>
    ''' 點擊Grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_JobList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_JobList.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            ShowDataGridView(dgv_AttList, JOBServiceManager.getInstance.PRJDoAction(GetActionDS(ActionType.GetSpecRecord)))

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"點擊Grid"})
        End Try

    End Sub
    ''' <summary>
    ''' 下載附件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_AttList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_AttList.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Try

            If e.ColumnIndex = 3 AndAlso dgv_AttList.ButtonIsEnable(e.RowIndex, e.ColumnIndex) Then
                Process.Start(ProjectClientBP.getInstance.LoadFileByFID(dgv_AttList.GetDBDS.Tables(0).Rows(dgv_AttList.CurrentRow.Index).Item("FID").ToString.Trim))
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"下載附件"})
        End Try
    End Sub



#End Region


#End Region

End Class

