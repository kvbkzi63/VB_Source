Imports System.Collections
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP
Imports System.Drawing

Public Class JobQABugListGridviewUC


    Dim WithEvents eventMgr As EventManager

#Region "     初始化"

    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        LoadEventManager()
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


    Private GridColumnSetting As String(,) = {{"Version_Id", "Version_Id", "N", "0"},
                                              {"Test_Version", "版次", "Y", "60"},
                                              {"Total_Amount", "總數", "Y", "70"},
                                              {"Total_UnClose", "未結案", "Y", "70"},
                                              {"Total_Closed", "已結案", "Y", "65"},
                                              {"Total_UnTest", "待複測", "Y", "60"},
                                              {"Urgent_UnClose", "未結案(U)", "Y", "105"},
                                              {"Urgent_Closed", "已結案(U)", "Y", "113"},
                                              {"Important_UnClose", "未結案(I)", "Y", "105"},
                                              {"Important_Closed", "已結案(I)", "Y", "115"},
                                              {"Normal_UnClose", "未結案(N)", "Y", "105"},
                                              {"Normal_Closed", "已結案(N)", "Y", "115"},
                                              {"Version_Desc", "Version_Desc", "N", "0"},
                                              {"Close_Flag", "Close_Flag", "N", "0"},
                                              {"Deploy_Date", "Deploy_Date", "N", "0"}}

    Enum ColumnIndex As Integer
        Version_Id
        Test_Version
        Total_Amount
        Total_UnClose
        Total_Closed
        Total_UnTest
        Urgent_UnClose
        Urgent_Closed
        Important_UnClose
        Important_Closed
        Normal_UnClose
        Normal_Closed
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
    Public Sub ShowBugListGrid(ByVal ds As DataSet)

        Try

            dgv_BugVerList.Initial(GetHashTable(GetGridDs(ds)))
            dgv_BugVerList.uclHeaderText = GetGridColumnSetting(GetColumnSettingType.Header)
            dgv_BugVerList.uclColumnWidth = GetGridColumnSetting(GetColumnSettingType.Width)
            dgv_BugVerList.uclVisibleColIndex = GetColumnViewIndex()
            dgv_BugVerList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For Each tstEnum As ColumnIndex In System.Enum.GetValues(GetType(ColumnIndex))
                dgv_BugVerList.Columns(CInt(tstEnum)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgv_BugVerList.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For i As Int32 = 0 To dgv_BugVerList.GetDBDS.Tables(0).Rows.Count - 1
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Total_UnClose, i, Color.Red)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Urgent_UnClose, i, Color.Red)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Important_UnClose, i, Color.Red)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Normal_UnClose, i, Color.Red)

                dgv_BugVerList.SetCellForeColor(ColumnIndex.Total_Closed, i, Color.Gray)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Urgent_Closed, i, Color.Gray)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Important_Closed, i, Color.Gray)
                dgv_BugVerList.SetCellForeColor(ColumnIndex.Normal_Closed, i, Color.Gray)

                dgv_BugVerList.SetCellForeColor(ColumnIndex.Total_UnTest, i, Color.DodgerBlue)


            Next


            SetLabelNumber()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得Grid 標題"})
        End Try

    End Sub





#End Region

#Region "     Grid事件"

    '''' <summary>
    '''' Grid Cell Click
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    'Private Sub dgv_BugVerList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_BugVerList.CellClick

    '    If e.RowIndex < 0 Then Exit Sub

    '    eventMgr.RaiseJobQACreateNewJobUC_GridCellClick(dgv_BugVerList.GetDBDS.Tables(0).Rows(e.RowIndex))
    'End Sub

    ''' <summary>
    ''' 統計數量
    ''' </summary>
    Private Sub SetLabelNumber()
        Try
            If dgv_BugVerList.GetDBDS.Tables(0).Rows.Count > 0 Then


                lbl_ImportBug_Finished.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Important_Closed"))

                lbl_ImportBug_UnFinish.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Important_UnClose"))
                lbl_NormalBug_Finished.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Normal_Closed"))
                lbl_NormalBug_UnFinish.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Normal_UnClose"))
                lbl_UrgentBug_Finished.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Urgent_Closed"))
                lbl_UrgentBug_UnFinish.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Urgent_UnClose"))
                lbl_TotalBug_All.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Total_Amount"))
                lbl_TotalBug_Finished.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Total_Closed"))
                lbl_TotalBug_NonTest.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Total_UnTest"))
                lbl_TotalBug_UnFinish.Text = dgv_BugVerList.GetDBDS.Tables(0).AsEnumerable.
                                              Sum(Function(c) c("Total_UnClose"))
            Else
                ClearAll()
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Label統計數量"})
        End Try
    End Sub
#End Region

#Region "     外部函數"

    Public Sub ClearAll()
        dgv_BugVerList.ClearDS()
        lbl_ImportBug_Finished.Text = 0
        lbl_ImportBug_UnFinish.Text = 0
        lbl_NormalBug_Finished.Text = 0
        lbl_NormalBug_UnFinish.Text = 0
        lbl_UrgentBug_Finished.Text = 0
        lbl_UrgentBug_UnFinish.Text = 0
        lbl_TotalBug_All.Text = 0
        lbl_TotalBug_Finished.Text = 0
        lbl_TotalBug_NonTest.Text = 0
        lbl_TotalBug_UnFinish.Text = 0
    End Sub
#End Region
End Class
