'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：UI畫面顯示相關功能及函式
'=======
'======= 程式說明：1.提供控制項顏色設定。
'=======
'=======           2.鎖定/解鎖UI。
'=======
'=======           3.控制項清除。
'=======
'======= 建立日期：2011-11-29
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports System.Data
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Reflection
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.CMM
Imports Com.Syscom.WinFormsUI.Docking
Imports Microsoft.Office.Interop
Imports Syscom.Comm.EXP

Public Class UCLScreenUtil

#Region "     變數宣告 "

#Region "     控制項顏色 "

    '''當畫面上有錯誤輸入時將背景顏色替換掉
    Public Shared BACK_COLOR_ERROR_INPUT As Color = Color.Pink

    '''畫面上輸入的預設顏色
    Public Shared BACK_COLOR_DEFAULT As Color = SystemColors.Control

#End Region

#Region "     定義一個資料型態以顯示GridView上的DB欄位、中文顯示名稱欄位、顯示與否、長度控制與否、長度控制的數值 "

    ''' <summary>
    ''' 定義一個資料型態以顯示GridView上的DB欄位、中文顯示名稱欄位、顯示與否、長度控制與否、長度控制的數值。
    ''' 
    ''' DB欄位 => dbColumn ； 
    ''' 
    ''' 中文顯示名稱欄位 =>  textColumn，空字串表示不顯示該欄位；
    ''' 
    ''' 長度控制的數值 => lengthValue，0 表示不控制該欄位；
    ''' 
    ''' </summary>
    Public Structure dgvShowColumn

        Dim globalDbColumn As String

        Dim globalTextColumn As String

        Dim globalLengthValue As Integer


#Region "     初始化資料結構的值"

        ''' <summary>
        ''' 初始化資料結構的值
        ''' </summary>
        ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
        Public Sub New(ByVal inputdbColumn As String, ByVal inputtextColumn As String, ByVal inputlengthValue As Integer)

            globalDbColumn = inputdbColumn

            globalTextColumn = inputtextColumn

            globalLengthValue = inputlengthValue

        End Sub

#End Region

#Region "     設定資料結構的值"

        ''' <summary>
        ''' 設定資料結構的值
        ''' </summary>
        ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
        Public Sub setValue(ByVal inputdbColumn As String, ByVal inputtextColumn As String, ByVal inputlengthValue As Integer)

            globalDbColumn = inputdbColumn

            globalTextColumn = inputtextColumn

            globalLengthValue = inputlengthValue

        End Sub

#End Region

#Region "     屬性設定"

#Region "     屬性設定 - DBColumn"

        ''' <summary>
        ''' 屬性設定 - DBColumn
        ''' </summary>
        ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
        Property DBColumn() As String
            Get
                Return globalDbColumn
            End Get
            Set(ByVal value As String)
                globalDbColumn = value
            End Set
        End Property

#End Region

#Region "     屬性設定 - TextColumn"

        ''' <summary>
        ''' 屬性設定 - DBColumn
        ''' </summary>
        ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
        Property TextColumn() As String
            Get
                Return globalTextColumn
            End Get
            Set(ByVal value As String)
                globalTextColumn = value
            End Set
        End Property

#End Region

#Region "     屬性設定 - LengthValue"

        ''' <summary>
        ''' 屬性設定 - LengthValue
        ''' </summary>
        ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
        Property LengthValue() As Integer
            Get
                Return globalLengthValue
            End Get
            Set(ByVal value As Integer)
                globalLengthValue = value
            End Set
        End Property

#End Region

#End Region

    End Structure

#End Region

#Region "     存放現在點選的病人的DS "

    Private Shared globalPatientInfoDS As DataSet = Nothing

#End Region

#End Region

#Region "     Grid 相關 "
  
#Region "     設定顯示的 UCLDataGridView ,要顯示 Dataset,要顯示的中文欄位名稱(EX: ""住院號,病歷號""),要顯示的欄位寬度(EX: ""400,300""),要顯示的欄位(EX: ""1,3""),是否要折行 "

    ''' <summary>
    ''' 設定顯示的 UCLDataGridView ,要顯示 Dataset,要顯示的中文欄位名稱(EX: "住院號,病歷號"),要顯示的欄位寬度(EX: "400,300"),要顯示的欄位(EX: "1,3"),是否要折行
    ''' </summary>
    ''' <param name="dgv_Show" >要顯的 UCLDataGridViewUI </param>
    ''' <param name="_ds" >要顯示的Dataset</param>
    ''' <param name="ColumnTextDgv" >要顯示的中文欄位名稱，EX: "住院號,病歷號"</param>
    ''' <param name="ColumnWidthDgv" >要顯示的欄位寬度，EX: "400,300"</param>
    ''' <param name="ColumnVisibleDgv" >要顯示的欄位，EX: "1,3"</param>
    ''' <param name="WrapFlag" >是否要折行</param>
    ''' <remarks>by Sean.Lin on 2012-6-28</remarks>
    Public Shared Sub ShowDgv(ByVal dgv_Show As UCLDataGridViewUC, ByVal _ds As DataSet, ByVal ColumnTextDgv As String, ByVal ColumnWidthDgv As String, ByVal ColumnVisibleDgv As String, ByVal WrapFlag As Boolean)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            dgv_Show.Initial(_ds)
            dgv_Show.uclHeaderText = ColumnTextDgv
            dgv_Show.uclColumnWidth = ColumnWidthDgv
            dgv_Show.uclVisibleColIndex = ColumnVisibleDgv

            If WrapFlag Then

                SetGridWrap(dgv_Show)

            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定顯示的Grid - ShowDgv", "", caller)

        End Try

    End Sub

#End Region

#Region "     設定顯示的 UCLDataGridView ,要顯示 Dataset,要顯示的中文欄位名稱(EX: ""住院號,病歷號""),要顯示的欄位寬度(EX: ""400,300""),要顯示的欄位(EX: ""1,3""),是否要折行 "

    ''' <summary>
    ''' 設定顯示的 UCLDataGridView ,要顯示 Dataset,要顯示的中文欄位名稱(EX: "住院號,病歷號"),要顯示的欄位寬度(EX: "400,300"),要顯示的欄位(EX: "1,3"),是否要折行
    ''' </summary>
    ''' <param name="dgv_Show" >要顯的 UCLDataGridViewUI </param>
    ''' <param name="_ds" >要顯示的Dataset</param>
    ''' <param name="ColumnTextDgv" >要顯示的中文欄位名稱，EX: "住院號,病歷號"</param>
    ''' <param name="ColumnWidthDgv" >要顯示的欄位寬度，EX: "400,300"</param>
    ''' <param name="ColumnVisibleDgv" >要顯示的欄位，EX: "1,3"</param>
    ''' <param name="WrapFlag" >是否要折行</param>
    ''' <remarks>by Sean.Lin on 2012-6-28</remarks>
    Public Shared Sub ShowDgv(ByVal dgv_Show As UCLDataGridViewUC, ByVal _ds As DataSet, ByVal ColumnTextDgv As String, ByVal ColumnWidthDgv As String, ByVal ColumnVisibleDgv As String, ByVal WrapFlag As Boolean, ByVal WrapOnlyRows As Boolean)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            dgv_Show.Initial(_ds)
            dgv_Show.uclHeaderText = ColumnTextDgv
            dgv_Show.uclColumnWidth = ColumnWidthDgv
            dgv_Show.uclVisibleColIndex = ColumnVisibleDgv

            If WrapOnlyRows Then
                SetGridWrapOnlyRows(dgv_Show)
            End If

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定顯示的Grid - ShowDgv", "", caller)

        End Try

    End Sub

#End Region


#Region "     設定顯示的 UCLDataGridView ,要顯示  DataTable,要顯示的中文欄位名稱(EX: ""住院號,病歷號""),要顯示的欄位寬度(EX: ""400,300""),要顯示的欄位(EX: ""1,3""),是否要折行 "

    ''' <summary>
    ''' 設定顯示的 UCLDataGridView ,要顯示 DataTable,要顯示的中文欄位名稱(EX: "住院號,病歷號"),要顯示的欄位寬度(EX: "400,300"),要顯示的欄位(EX: "1,3"),是否要折行
    ''' </summary>
    ''' <param name="dgv_Show" >要顯的 UCLDataGridViewUI </param>
    ''' <param name="dt" >要顯示的 System.Data.DataTable</param>
    ''' <param name="ColumnTextDgv" >要顯示的中文欄位名稱，EX: "住院號,病歷號"</param>
    ''' <param name="ColumnWidthDgv" >要顯示的欄位寬度，EX: "400,300"</param>
    ''' <param name="ColumnVisibleDgv" >要顯示的欄位，EX: "1,3"</param>
    ''' <param name="WrapFlag" >是否要折行</param>
    ''' <remarks>by Sean.Lin on 2012-6-28</remarks>
    Public Shared Sub ShowDgv(ByVal dgv_Show As UCLDataGridViewUC, ByVal dt As System.Data.DataTable, ByVal ColumnTextDgv As String, ByVal ColumnWidthDgv As String, ByVal ColumnVisibleDgv As String, ByVal WrapFlag As Boolean)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim _ds As New DataSet

            _ds.Tables.Add(dt.Copy)

            ShowDgv(dgv_Show, _ds, ColumnTextDgv, ColumnWidthDgv, ColumnVisibleDgv, WrapFlag)

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定顯示的Grid - ShowDgv", "", caller)

        End Try

    End Sub

#End Region


#Region "     設定顯示的 UCLDataGridView ,要顯示  HashTable,要顯示的中文欄位名稱(EX: ""住院號,病歷號""),要顯示的欄位寬度(EX: ""400,300""),要顯示的欄位(EX: ""1,3""),是否要折行 "

    ''' <summary>
    ''' 設定顯示的 UCLDataGridView ,要顯示 HashTable,要顯示的中文欄位名稱(EX: "住院號,病歷號"),要顯示的欄位寬度(EX: "400,300"),要顯示的欄位(EX: "1,3"),是否要折行
    ''' </summary>
    ''' <param name="dgv_Show" >要顯的 UCLDataGridViewUI </param>
    ''' <param name="ht" >要顯示的 Hashtable</param>
    ''' <param name="ColumnTextDgv" >要顯示的中文欄位名稱，EX: "住院號,病歷號"</param>
    ''' <param name="ColumnWidthDgv" >要顯示的欄位寬度，EX: "400,300"</param>
    ''' <param name="ColumnVisibleDgv" >要顯示的欄位，EX: "1,3"</param>
    ''' <param name="WrapFlag" >是否要折行</param>
    ''' <remarks>by Sean.Lin on 2012-6-28</remarks>
    Public Shared Sub ShowDgv(ByVal dgv_Show As UCLDataGridViewUC, ByVal ht As Hashtable, ByVal ColumnTextDgv As String, ByVal ColumnWidthDgv As String, ByVal ColumnVisibleDgv As String, ByVal WrapFlag As Boolean)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try


            dgv_Show.Initial(ht)
            dgv_Show.uclHeaderText = ColumnTextDgv
            dgv_Show.uclColumnWidth = ColumnWidthDgv
            dgv_Show.uclVisibleColIndex = ColumnVisibleDgv

            If WrapFlag Then

                SetGridWrap(dgv_Show)

            End If

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定顯示的Grid - ShowDgv", "", caller)

        End Try

    End Sub

#End Region

#Region "     根據輸入的 UCLGrid、欄位、Dataset 顯示在UCLGrid上 -  Dataset 的 Tables(0) "

    ''' <summary>
    ''' 根據輸入的 UCLGrid、欄位、Dataset 顯示在UCLGrid上 -  Dataset 的 Tables(0) ，中文欄位為空字串則不顯示
    ''' </summary>
    ''' <param name="dgv_Input">要顯示的Grid物件</param>
    ''' <param name="ColumnData">Table的欄位顯示資料</param>
    ''' <param name="inputDS" >要顯示的資料DataSet</param>
    ''' <remarks>by Sean on 2011-10-31"</remarks>
    Public Shared Sub ShowdgvText(ByRef dgv_Input As UCLDataGridViewUC, ByVal ColumnData() As dgvShowColumn, ByVal inputDS As DataSet)
        Try


            '檢查要顯示的 DataSet 資料
            If CheckHasTable(inputDS) Then

                ShowdgvText(dgv_Input, ColumnData, inputDS.Tables(0))

            Else
                ShowErrorMsg("CMMCMMD101", "要顯示的 DataTable 不存在，顯示")
            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMD101", "要顯示的 DataTable 不存在，顯示")

        End Try
    End Sub


#End Region

#Region "     根據輸入的 UCLGrid、欄位、DataTable 顯示在UCLGrid "

    ''' <summary>
    ''' 根據輸入的 UCLGrid、欄位、DataTable 顯示在UCLGrid上，中文欄位為空字串則不顯示
    ''' </summary>
    ''' <param name="dgv_Input">要顯示的Grid物件</param>
    ''' <param name="ColumnData">Table的欄位顯示資料</param>
    ''' <param name="inputDT" >要顯示的資料Table</param>
    ''' <remarks>by Sean on 2011-10-31"</remarks>
    Public Shared Sub ShowdgvText(ByRef dgv_Input As UCLDataGridViewUC, ByVal ColumnData() As dgvShowColumn, ByVal inputDT As DataTable, Optional ByVal ColumnWidthDgv As String = Nothing)
        Try

            '檢查ColumnData
            If CheckIsNothing(ColumnData) Then

                '檢查dgv_Input
                If CheckIsNothing(dgv_Input) Then

                    '檢查要顯示的 DataTable 
                    If CheckIsNothing(inputDT) Then

                        '功能主體----------------------------------------------------------------------------------

                        '清除所有的欄位  2012/03/03 Mark By Sean
                        'dgv_Input.Columns.Clear()

                        '加入暫存的DS
                        Dim tempDS As DataSet = New DataSet

                        tempDS.Tables.Add(inputDT.Copy)

                        '設定Grid View 來源
                        dgv_Input.Initial(tempDS)

                        '將欄位名稱改成中文
                        For i As Integer = 0 To ColumnData.Length - 1
                            dgv_Input.Columns(ColumnData(i).DBColumn.ToString).HeaderText = ColumnData(i).TextColumn.ToString

                            '中文欄位為空字串則不顯示
                            If ColumnData(i).TextColumn.ToString = "" Then

                                dgv_Input.Columns(ColumnData(i).DBColumn).Visible = False

                            Else

                                dgv_Input.Columns(ColumnData(i).DBColumn).Visible = True

                            End If


                            '確定是否需要限制輸入長度
                            If ColumnData(i).LengthValue > 0 Then

                                '是才限制長度
                                If dgv_Input.Columns((ColumnData(i).DBColumn)).GetType.ToString = "System.Windows.Forms.DataGridViewTextBoxColumn" Then

                                    CType(dgv_Input.Columns(ColumnData(i).DBColumn), DataGridViewTextBoxColumn).MaxInputLength = ColumnData(i).LengthValue.ToString

                                End If

                            End If

                            If ColumnWidthDgv IsNot Nothing Then

                                dgv_Input.uclColumnWidth = ColumnWidthDgv

                            End If


                            If ColumnData(i).DBColumn.ToString = "Create_Time" Then

                                dgv_Input.Columns(ColumnData(i).DBColumn).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                            End If

                            If ColumnData(i).DBColumn.ToString = "Modified_Time" Then

                                dgv_Input.Columns(ColumnData(i).DBColumn).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                            End If
                            'modified by mark Zhang 2012/02/03 end

                        Next

                        '功能主體結束-----------------------------------------------------------------------------

                    Else
                        ShowErrorMsg("CMMCMMD101", "要顯示的 DataTable 不存在，顯示")
                    End If

                Else
                    ShowErrorMsg("CMMCMMD101", "輸欲顯示的Grid 不存在，顯示")
                End If

            Else
                ShowErrorMsg("CMMCMMD101", "欲顯示的資料 不存在，顯示")
            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMD101", "欲顯示的資料 不存在，顯示")

        End Try
    End Sub


#End Region

#Region "     根據輸入的 Grid、欄位、產生一個DataTable 顯示在Grid上"

    ''' <summary>
    ''' 根據輸入的 Grid、欄位、產生一個DataTable 顯示在Grid上，中文欄位為空字串則不顯示
    ''' </summary>
    ''' <param name="dgv_Input">要顯示的Grid物件</param>
    ''' <param name="ColumnData">Table的欄位顯示資料</param>
    ''' <remarks>by Sean on 2011-12-6"</remarks>
    Public Shared Sub ShowdgvText(ByRef dgv_Input As UCLDataGridViewUC, ByVal ColumnData() As dgvShowColumn)
        Try

            '檢查ColumnData
            If CheckIsNothing(ColumnData) Then

                '檢查dgv_Input
                If CheckIsNothing(dgv_Input) Then

                    '功能主體----------------------------------------------------------------------------------

                    '清除所有的欄位
                    dgv_Input.Columns.Clear()

                    '設定Grid View 來源
                    Dim ds As New DataSet
                    ds.Tables.Add(GenDataTable("temp", ColumnData).Copy)
                    dgv_Input.DataSource = ds

                    '將欄位名稱改成中文
                    For i As Integer = 0 To ColumnData.Length - 1
                        dgv_Input.Columns(ColumnData(i).DBColumn.ToString).HeaderText = ColumnData(i).TextColumn.ToString

                        '中文欄位為空字串則不顯示
                        If ColumnData(i).TextColumn.ToString = "" Then

                            dgv_Input.Columns(ColumnData(i).DBColumn).Visible = False

                        Else

                            dgv_Input.Columns(ColumnData(i).DBColumn).Visible = True

                        End If


                        '確定是否需要限制輸入長度
                        If ColumnData(i).LengthValue > 0 Then

                            '是才限制長度
                            If dgv_Input.Columns((ColumnData(i).DBColumn)).GetType.ToString = "System.Windows.Forms.DataGridViewTextBoxColumn" Then

                                CType(dgv_Input.Columns(ColumnData(i).DBColumn), DataGridViewTextBoxColumn).MaxInputLength = ColumnData(i).LengthValue.ToString

                            End If

                        End If

                        '設定時間的顯示格式
                        'modified by mark Zhang 2012/02/03 begin
                        'If dgv_Input.Columns.Contains("Create_Time") Then

                        '    dgv_Input.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                        'End If

                        'If dgv_Input.Columns.Contains("Modified_Time") Then

                        '    dgv_Input.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                        'End If

                        If ColumnData(i).DBColumn.ToString = "Create_Time" Then

                            dgv_Input.Columns(ColumnData(i).DBColumn).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                        End If

                        If ColumnData(i).DBColumn.ToString = "Modified_Time" Then

                            dgv_Input.Columns(ColumnData(i).DBColumn).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                        End If
                        'modified by mark Zhang 2012/02/03 end

                    Next

                    '功能主體結束-----------------------------------------------------------------------------

                Else
                    ShowErrorMsg("CMMCMMD101", "輸欲顯示的Grid 不存在，顯示")
                End If

            Else
                ShowErrorMsg("CMMCMMD101", "欲顯示的資料 不存在，顯示")
            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMD101", "根據輸入的 Grid、欄位、產生一個DataTable 顯示在Grid上")

        End Try
    End Sub


#End Region

#Region "     設定傳入的 Grid 折行 "

    ''' <summary>
    ''' 設定傳入的 Grid 折行
    ''' </summary>
    ''' <param name="UCLDgv" >要設定折行的Grid</param>
    ''' <remarks>by Sean.Lin on 2012-5-23</remarks>
    Public Shared Sub SetGridWrap(ByRef UCLDgv As UCLDataGridViewUC)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            UCLDgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            'UCLDgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
            UCLDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            UCLDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定傳入的 Grid 折行", "", caller)

        End Try

    End Sub

#End Region

#Region "     設定傳入的 Grid 折行 "

    ''' <summary>
    ''' 設定傳入的 Grid 折行
    ''' </summary>
    ''' <param name="UCLDgv" >要設定折行的Grid</param>
    ''' <remarks>by James on 2012-5-23</remarks>
    Public Shared Sub SetGridWrapOnlyRows(ByRef UCLDgv As UCLDataGridViewUC)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            UCLDgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            'UCLDgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
            'UCLDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            UCLDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定傳入的 Grid 折行", "", caller)

        End Try

    End Sub

#End Region


#Region "     清除傳入的 Grid 的選擇列，使其不會出現藍色列 "

    ''' <summary>
    ''' 清除傳入的 Grid 的選擇列，使其不會出現藍色列
    ''' </summary>
    ''' <param name="UCLDgv" >要設定的Grid</param>
    ''' <remarks>by Sean.Lin on 2012-5-23</remarks>
    Public Shared Sub ClearGridRow(ByRef UCLDgv As UCLDataGridViewUC)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            UCLDgv.CurrentCell = Nothing

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定傳入的 Grid 折行", "", caller)

        End Try

    End Sub

#End Region

#End Region

#Region "     開啟一個UI並Dock在畫面上 "

    ''' <summary>
    ''' 開啟一個UI並Dock在畫面上，如果畫面上已經有了該UI
    ''' 
    ''' 會根據 closeFlag -> True:關閉現有 UI，重新開啟。False:不動作。
    '''
    ''' UIEnName:程式英文名稱，UICnName:程式中文名稱，UIForm:UI物件，DockPanel:DockPanel物件。
    ''' </summary>
    ''' <param name="UIEnName " >程式英文名稱</param>
    ''' <param name="UICnName " >程式中文名稱</param>
    ''' <param name="UIForm" >UI Form 物件</param>
    ''' <param name="DockPanel" >Dock 的Panel 物件</param>
    ''' <remarks>by Sean.Lin on 2012-4-10</remarks>
    Public Shared Sub OpenDockUI(ByVal UIEnName As String, ByVal UICnName As String, ByRef UIForm As Form, ByRef DockPanel As DockPanel, ByVal closeFlag As Boolean)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim dockUI As DockContent = Nothing

            '設定要展開的UI
            Dim dockCount As Integer = 0
            dockCount = DockPanel.Contents.Count
            For dockCount = 1 To dockCount
                If CType(DockPanel.Contents(dockCount - 1), Form).Name = UIEnName Then

                    '關閉現有的表單
                    If closeFlag Then

                        CType(DockPanel.Contents(dockCount - 1), Form).Close()

                    End If


                End If
            Next

            dockUI = UIForm

            '設定UI的名字
            dockUI.Text = UICnName
            dockUI.TabText = UICnName

            '開啟新的表單
            If closeFlag Then

                dockUI.Show(DockPanel, Com.Syscom.WinFormsUI.Docking.DockState.Document)

            End If



        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "開啟一個UI並Dock在畫面上", "", caller)

        End Try

    End Sub

#End Region

#Region "     通用控制項相關 "

#Region "     清除控制項 "

#Region "     清除控制項 "

    ''' <summary>
    ''' 清除控制項欄位資料
    ''' 
    ''' </summary>
    ''' <param name="container"></param>
    ''' <remarks>by Sean on 2011-10-26"</remarks>
    Public Shared Sub CleanControls(ByVal container As Control)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            '檢查是不是Nothing，不適才會繼續運作
            If CheckIsNothing(container) Then

                Select Case container.GetType.ToString

                    Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.TableLayoutPanel", "System.Windows.Forms.GroupBox"

                        For Each ctl As Control In container.Controls

                            Select Case ctl.GetType.ToString

                                Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.GroupBox"
                                    CleanControls(ctl)


                                Case "System.Windows.Forms.TableLayoutPanel"

                                    For i As Integer = 0 To CType(ctl, TableLayoutPanel).ColumnCount - 1

                                        For j As Integer = 0 To CType(ctl, TableLayoutPanel).RowCount - 1

                                            '取出物件，減少運算
                                            Dim ctl_Temp As Control = (CType(ctl, TableLayoutPanel).GetControlFromPosition(i, j))

                                            '確認物件是否存在
                                            If Not ctl_Temp Is Nothing Then

                                                '清除物件
                                                CleanControls(ctl_Temp)

                                            End If

                                        Next

                                    Next

                                Case Else

                                    '非容器，清除物件
                                    CleanSingleControl(ctl)

                            End Select

                        Next

                    Case Else

                        '非容器，清除物件
                        CleanSingleControl(container)

                End Select


            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "清除控制項欄位資料", "", caller)

        End Try
    End Sub

#End Region

#Region "     清除控制項 - 內部"

    ''' <summary>
    ''' 負責清除控制項欄位資料的實際操作
    ''' </summary>
    ''' <remarks>by Sean on 2011-10-26"</remarks>
    Private Shared Sub CleanSingleControl(ByVal ctl As Control)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Select Case ctl.GetType.ToString

                Case "System.Windows.Forms.TextBox", "Syscom.Client.UCL.UCLChartNoUC"
                    ctl.Text = ""
                    SetControlToCorrectColor(ctl)

                Case "System.Windows.Forms.ComboBox"
                    CType(ctl, System.Windows.Forms.ComboBox).SelectedValue = ""
                    SetControlToCorrectColor(ctl)


                Case "System.Windows.Forms.CheckBox"
                    CType(ctl, System.Windows.Forms.CheckBox).Checked = False
                    SetControlToCorrectColor(ctl)

                Case "System.Windows.Forms.RadioButton"
                    CType(ctl, System.Windows.Forms.RadioButton).Checked = False
                    SetControlToCorrectColor(ctl)


                Case "Syscom.Client.UCL.UCLComboBoxUC"
                    CType(ctl, Syscom.Client.UCL.UCLComboBoxUC).SelectedValue = ""
                    SetControlToCorrectColor(ctl)


                Case "Syscom.Client.UCL.UCLTextBoxUC"

                    ctl.Text = ""
                    SetControlToCorrectColor(ctl)

                Case "Syscom.Client.UCL.UCLDatrTimePickerWithTimeUC"
                    CType(ctl, UCLDatrTimePickerWithTimeUC).clear()

                Case "Syscom.Client.UCL.UclTimeIntervalUC"

                    CType(ctl, UclTimeIntervalUC).Clear()

                    'UCLTextBoxUC
                Case "System.Windows.Forms.MaskedTextBox"
                    ctl.Text = ""
                    SetControlToCorrectColor(ctl)

                Case "Syscom.Client.UCL.UCLDateTimePickerUC"
                    CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).Clear()
                    SetControlToCorrectColor(ctl)

                Case "System.Windows.Forms.Label"

                    'Do nothing

                Case "System.Windows.Forms.Button"

                    'Do nothing


                Case Else

                    ctl.Text = ""
                    SetControlToCorrectColor(ctl)


            End Select


        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "清除控制項欄位資料", "", caller)

        End Try
    End Sub

#End Region

#End Region

#Region "     控制項檢查 "

#Region "     控制項檢查 "

    ''' <summary>
    ''' 檢查控制項欄位資料
    ''' 有值 => Return True
    ''' 沒值 => Return False
    ''' 
    ''' </summary>
    ''' <param name="container"></param>
    ''' <remarks>by Sean on 2011-12-02"</remarks>
    Public Overloads Shared Function CheckControlHasValue(ByVal container As Control) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim returnBoolean As Boolean = True


            '檢查是不是Nothing，不是才會繼續運作
            If CheckIsNothing(container) Then


                Select Case container.GetType.ToString

                    Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.TableLayoutPanel", "System.Windows.Forms.GroupBox"

                        For Each ctl As Control In container.Controls

                            Select Case ctl.GetType.ToString

                                Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.GroupBox", "OPD.Client.OHM.OHMTextCodeQueryUI"
                                    CheckControlHasValue(ctl)


                                Case "System.Windows.Forms.TableLayoutPanel"

                                    For i As Integer = 0 To CType(ctl, TableLayoutPanel).ColumnCount - 1

                                        For j As Integer = 0 To CType(ctl, TableLayoutPanel).RowCount - 1

                                            '取出物件，減少運算
                                            Dim ctl_Temp As Control = (CType(ctl, TableLayoutPanel).GetControlFromPosition(i, j))

                                            '確認物件是否存在
                                            If Not ctl_Temp Is Nothing Then

                                                '檢查物件
                                                CheckControlHasValue(ctl_Temp)

                                            End If

                                        Next

                                    Next

                                Case Else

                                    '非容器，直接進行檢查
                                    returnBoolean = CheckSingleControl(ctl)

                            End Select

                        Next

                    Case Else

                        returnBoolean = CheckSingleControl(container)

                End Select

            Else

                returnBoolean = False

            End If

            Return returnBoolean

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "控制項檢查", "", caller)

        End Try
    End Function

#End Region

#Region "     控制項檢查 - 內部 "

    ''' <summary>
    ''' 檢查控制項欄位資料
    ''' 有值 => Return True
    ''' 沒值 => Return False
    ''' 
    ''' </summary>
    ''' <remarks>by Sean on 2011-12-02"</remarks>
    Private Shared Function CheckSingleControl(ByVal ctl As Control) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim returnBoolean As Boolean = True


            Select Case ctl.GetType.ToString


                Case "System.Windows.Forms.TextBox", "Syscom.Client.UCL.UCLChartNoUC"

                    If ctl.Text = "" Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                Case "System.Windows.Forms.ComboBox"

                    If nvl(CType(ctl, System.Windows.Forms.ComboBox).SelectedValue) = "" Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                Case "System.Windows.Forms.CheckBox"

                    If CType(ctl, System.Windows.Forms.CheckBox).Checked = False Then

                        '回傳值回False
                        returnBoolean = False

                    End If

                Case "System.Windows.Forms.RadioButton"
                    If CType(ctl, System.Windows.Forms.RadioButton).Checked = False Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                Case "Syscom.Client.UCL.UCLComboBoxUC"

                    If nvl(CType(ctl, Syscom.Client.UCL.UCLComboBoxUC).SelectedValue) = "" Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                Case "Syscom.Client.UCL.UCLTextBoxUC"

                    If ctl.Text = "" Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                    'UCLTextBoxUC 
                Case "System.Windows.Forms.MaskedTextBox"

                    Dim tempboolean As Boolean = False

                    Try
                        'false 表不通過
                        If Not CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).IsEmpty Then

                            '回傳值回False
                            returnBoolean = False

                        Else

                            If Not CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).CheckIsDate Then

                                '回傳值回False
                                returnBoolean = False


                            End If

                        End If

                    Catch ex As Exception
                        tempboolean = True
                    End Try


                    If ctl.Text = "" And tempboolean Or nvl(ctl.Text).Length <= 8 Then

                        '回傳值回False
                        returnBoolean = False

                    End If


                    'UCLDateTimePickerUC 
                Case "Syscom.Client.UCL.UCLDateTimePickerUC"

                    'TRUE 表不通過
                    If CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).IsEmpty Then

                        '回傳值回False
                        returnBoolean = False

                    Else

                        If Not CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).CheckIsDate Then

                            '回傳值回False
                            returnBoolean = False


                        End If

                    End If


                    'UCLDateTimePickerUC 
                Case "Syscom.Client.UCL.UCLYmPickerUC"


                    '判斷是否為空值
                    If "".Equals(CType(ctl, Syscom.Client.UCL.UCLYmPickerUC).GetUsYmStr) Then

                        '回傳值回False
                        returnBoolean = False


                    End If

                Case "System.Windows.Forms.Label"



                Case "Syscom.Client.UCL.UCLTextCodeQueryUI"

                    '判斷是否沒有取道Test Code 的值!
                    If CType(ctl, Syscom.Client.UCL.UCLTextCodeQueryUI).getCode = "" Then

                        '回傳值回False
                        returnBoolean = False

                    End If
                Case "OPD.Client.OHM.OHMTextCodeQueryUI"


                Case Else

                    ShowErrorMsg("CMMCMMB300", "不在檢核範圍內，請聯絡Sean", "", caller)


            End Select

            If returnBoolean = False Then

                '改成錯誤的顏色
                SetControlToErrorColor(ctl)

            Else

                '改成正確的顏色
                SetControlToCorrectColor(ctl)

            End If



            Return returnBoolean

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "控制項檢查", "", caller)

        End Try
    End Function

#End Region

#End Region

#Region "     清除控制項底色 "

    ''' <summary>
    ''' 清除控制項底色
    ''' 
    ''' </summary>
    ''' <param name="container"></param>
    ''' <remarks>by Sean on 2011-12-05"</remarks>
    Public Shared Sub CleanControlsBackcolor(ByVal container As Control)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try


            '有包含多個控制項，表示為容器，要跑For 迴圈，取出控制項
            If container.Controls.Count > 0 Then

                For Each ctl As Control In container.Controls

                    Select Case ctl.GetType.ToString

                        Case "System.Windows.Forms.Panel"
                            CleanControlsBackcolor(ctl)

                        Case "System.Windows.Forms.FlowLayoutPanel"
                            CleanControlsBackcolor(ctl)

                        Case "System.Windows.Forms.TableLayoutPanel"

                            For i As Integer = 0 To CType(ctl, TableLayoutPanel).ColumnCount - 1

                                For j As Integer = 0 To CType(ctl, TableLayoutPanel).RowCount - 1


                                    '取出物件，減少運算
                                    Dim ctl_Temp As Control = (CType(ctl, TableLayoutPanel).GetControlFromPosition(i, j))

                                    '確認物件是否存在
                                    If Not ctl_Temp Is Nothing Then

                                        '清除
                                        CleanControlsBackcolor(ctl_Temp)

                                    End If

                                Next

                            Next

                        Case "System.Windows.Forms.GroupBox"

                            CleanControlsBackcolor(ctl)

                        Case Else

                            SetControlToCorrectColor(ctl)

                    End Select

                Next


                '不包含任何控制項，表示本身為一個Control
            ElseIf container.Controls.Count = 0 Then

                SetControlToCorrectColor(container)

            End If



        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "清除控制項底色", "", caller)

        End Try
    End Sub

#End Region

#Region "     控制項檢查 - 數字 "

#Region "     控制項檢查 - 數字 "

    ''' <summary>
    ''' 檢查控制項欄位資料是否為數字
    ''' 數字 => Return True
    ''' 非數字 => Return False
    ''' 
    ''' </summary>
    ''' <param name="container"></param>
    ''' <remarks>by Sean on 2011-12-02"</remarks>
    Public Shared Function CheckControlIsNumber(ByVal container As Control) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim returnBoolean As Boolean = True


            '檢查是不是Nothing，不是才會繼續運作
            If CheckIsNothing(container) Then

                Select Case container.GetType.ToString

                    Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.TableLayoutPanel", "System.Windows.Forms.GroupBox"

                        For Each ctl As Control In container.Controls

                            Select Case ctl.GetType.ToString

                                Case "System.Windows.Forms.Panel", "System.Windows.Forms.FlowLayoutPanel", "System.Windows.Forms.GroupBox"
                                    CheckControlIsNumber(ctl)


                                Case "System.Windows.Forms.TableLayoutPanel"

                                    For i As Integer = 0 To CType(ctl, TableLayoutPanel).ColumnCount - 1

                                        For j As Integer = 0 To CType(ctl, TableLayoutPanel).RowCount - 1

                                            '取出物件，減少運算
                                            Dim ctl_Temp As Control = (CType(ctl, TableLayoutPanel).GetControlFromPosition(i, j))

                                            '確認物件是否存在
                                            If Not ctl_Temp Is Nothing Then

                                                '檢查物件
                                                CheckControlIsNumber(ctl_Temp)

                                            End If

                                        Next

                                    Next

                                Case Else

                                    '非容器，直接進行檢查
                                    returnBoolean = CheckIsNumberSingleControl(ctl)

                            End Select

                        Next

                    Case Else

                        returnBoolean = CheckIsNumberSingleControl(container)

                End Select

            Else

                returnBoolean = False

            End If

            Return returnBoolean

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "控制項檢查 - 數字", "", caller)

        End Try
    End Function

#End Region

#Region "     控制項檢查 - 內部 "

    ''' <summary>
    ''' 檢查控制項欄位資料
    ''' 數字 => Return True
    ''' 非數字 => Return False
    ''' 
    ''' </summary>
    ''' <remarks>by Sean on 2011-12-02"</remarks>
    Private Shared Function CheckIsNumberSingleControl(ByVal ctl As Control) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim returnBoolean As Boolean = True


            Select Case ctl.GetType.ToString


                Case "System.Windows.Forms.TextBox", "Syscom.Client.UCL.UCLTextBoxUC"

                    '判斷是否為數字
                    returnBoolean = CheckMethodUtil.CheckIsNumber(ctl.Text)

                Case "System.Windows.Forms.ComboBox"

                    '判斷是否為數字
                    returnBoolean = CheckMethodUtil.CheckIsNumber(nvl(CType(ctl, System.Windows.Forms.ComboBox).SelectedValue))

                Case "System.Windows.Forms.CheckBox", "System.Windows.Forms.RadioButton", "Syscom.Client.UCL.UCLDateTimePickerUC"

                    '回傳值回False
                    returnBoolean = False

                Case "Syscom.Client.UCL.UCLComboBoxUC"

                    '判斷是否為數字
                    returnBoolean = CheckMethodUtil.CheckIsNumber(nvl(CType(ctl, Syscom.Client.UCL.UCLComboBoxUC).SelectedValue))


                    'UCLTextBoxUC 
                Case "System.Windows.Forms.MaskedTextBox"

                    Dim tempboolean As Boolean = False

                    Try
                        'false 表不通過
                        If Not CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).IsEmpty Then

                            '回傳值回False
                            returnBoolean = False

                        Else

                            If Not CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).CheckIsDate Then

                                '回傳值回False
                                returnBoolean = False


                            End If

                        End If

                    Catch ex As Exception
                        tempboolean = True
                    End Try


                    If ctl.Text = "" And tempboolean Or nvl(ctl.Text).Length <= 8 Then

                        '回傳值回False
                        returnBoolean = False

                    End If

                Case Else

                    ShowErrorMsg("CMMCMMB000", "不在檢核範圍內，請聯絡Sean", "", caller)


            End Select

            If returnBoolean = False Then

                '改成錯誤的顏色
                SetControlToErrorColor(ctl)

            Else

                '改成正確的顏色
                SetControlToCorrectColor(ctl)

            End If



            Return returnBoolean

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "控制項檢查", "", caller)

        End Try
    End Function

#End Region

#End Region

#Region "     設定控制項元件為正常的顏色 "

    ''' <summary>
    ''' 設定控制項元件為正常的顏色
    ''' </summary>
    ''' <remarks>by Sean on 2011-10-26"</remarks>
    Public Shared Sub SetControlToCorrectColor(ByRef inpoutControl As Object)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            '如果可輸入才會變成白色
            If inpoutControl.enabled = True Then

                Select Case inpoutControl.GetType.ToString

                    Case "System.Windows.Forms.CheckBox"

                        inpoutControl.backcolor = System.Drawing.Color.Transparent

                    Case "System.Windows.Forms.RadioButton"

                        inpoutControl.backcolor = System.Drawing.Color.Transparent

                    Case "System.Windows.Forms.Label"

                        inpoutControl.backcolor = System.Drawing.Color.Transparent

                    Case Else

                        inpoutControl.backcolor = Color.White

                End Select

            Else
                '不可輸入的顏色
                inpoutControl.backcolor = BACK_COLOR_DEFAULT

            End If



        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定控制項元件為正常的顏色", "", caller)

        End Try


    End Sub

#End Region

#Region "     設定控制項元件為錯誤的顏色 "

    ''' <summary>
    ''' 設定控制項元件為錯誤的顏色
    ''' </summary>
    ''' <param name="inpoutControl" >要設定顏色的控制項</param>
    ''' <remarks>by Sean on 2011-10-26"</remarks>
    Public Shared Sub SetControlToErrorColor(ByRef inpoutControl As Object)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            inpoutControl.backcolor = BACK_COLOR_ERROR_INPUT

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "設定控制項元件為錯誤的顏色", "", caller)

        End Try
    End Sub

#End Region

#End Region

#Region "     根據輸入產生一個  System.Data.DataTable - For Maintain 程式使用 "

#Region "     根據輸入的TableName和欄位字串產生一個 System.Data.DataTable"

    ''' <summary>
    ''' 根據輸入的TableName和欄位字串集合產生一個 System.Data.DataTable
    ''' 輸入為:  Table Name (字串) 和  Table的欄位 (字串集合)
    ''' </summary>
    ''' <param name="TableName">要建立之DataSet的Table名字</param>
    ''' <param name="ColumnData">Table的欄位</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean on 2011-12-6"</remarks>
    Private Shared Function GenUCLDataTable(ByVal TableName As String, ByVal ColumnData() As dgvShowColumn) As System.Data.DataTable
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim DT_Temp As New System.Data.DataTable

            '新增Table的欄位
            For i As Integer = 0 To ColumnData.Length - 1

                DT_Temp.Columns.Add(ColumnData(i).DBColumn)

            Next

            Return DT_Temp

        Catch ex As Exception
            ShowErrorMsg("CMMCMMB302", "產生 System.Data.DataTable", "", caller)
            Throw ex
        End Try
    End Function


#End Region

#Region "     根據輸入的TableName和欄位字串產生一個DataSet並包含一個空的Table "

    ''' <summary>
    ''' 根據輸入的TableName和欄位字串集合產生一個DataSet並包含一個空的Table
    ''' 輸入為:  Table Name (字串) 和  Table的欄位 (字串集合)
    ''' </summary>
    ''' <param name="TableName">要建立之DataSet的Table名字</param>
    ''' <param name="ColumnData">Table的欄位</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean on 2011-12-6"</remarks>
    Private Shared Function GenUCLDataSet(ByVal TableName As String, ByVal ColumnData() As dgvShowColumn) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim DS_Temp As New DataSet

            '新增一個Table
            DS_Temp.Tables.Add(TableName)

            '新增Table的欄位
            For i As Integer = 0 To ColumnData.Length - 1
                DS_Temp.Tables(0).Columns.Add(ColumnData(i).DBColumn)
            Next

            Return DS_Temp

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "根據輸入的TableName和欄位字串產生一個DataSet並包含一個空的Table ", "", caller)
            Throw ex
        End Try
    End Function

#End Region

#End Region

#Region "     彈出一個視窗，提供使用者選擇檔案，回傳 FilePath "

    ''' <summary>
    ''' 彈出一個視窗，提供使用者選擇檔案，回傳 FilePath，若沒有選擇檔案則回傳空字串。
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-7-24</remarks>
    Public Shared Function GetFilePath() As String

        Dim returnString As String = ""
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            '彈出視窗供使用者選擇要使用之文件
            Dim Dialog_Temp As OpenFileDialog = New OpenFileDialog()

            Dialog_Temp.Title = "請選擇檔案"

            'Dialog_Temp.Filter = "jpg文件(*.jpg)|*.jpg|gif文件(*.gif)|*.gif"

            If (Dialog_Temp.ShowDialog() = DialogResult.OK) Then

                '取得檔案位置
                returnString = Dialog_Temp.FileName

            End If

            Return returnString

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "彈出一個視窗，提供使用者選擇檔案，回傳 FilePath", "", caller)

            Return returnString

        End Try

    End Function

#End Region

#Region "     傳入檔案路徑，開啟Excel，並將其轉成 System.Data.DataTable 回傳。RowStartIndex 表示要當作Column Name 的那一行，檔案將從 RowStartIndex 下一行視為檔案資料的開始。 "

    ''' <summary>
    ''' 傳入檔案路徑，開啟Excel，並將其轉成 System.Data.DataTable 回傳，第一列必須為 Column Name。
    ''' FilePath     ： 要讀取的檔案路徑。
    ''' TableName    ： 回傳的Table Name。
    ''' SheetName    ： 要開啟的工作表的名稱。
    ''' </summary>
    ''' <param name="FilePath" >要讀取的檔案路徑</param>
    ''' <param name="TableName" >回傳的Table Name</param>
    ''' <param name="SheetName" >要開啟的工作表的名稱。</param>
    ''' <returns> System.Data.DataTable</returns>
    ''' <remarks>by Sean.Lin on 2012-7-24</remarks>
    Public Shared Function ConvertExcelToDataTable(ByVal FilePath As String, ByVal TableName As String, Optional ByVal SheetName As String = "Sheet1") As System.Data.DataTable

        Dim returnDatatable As New System.Data.DataTable
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            '檢查檔案是否存在
            If Not System.IO.File.Exists(FilePath) Then

                '檔案不存在
                ShowErrorMsg("CMMCMMB302", "檔案不存在，讀取", "", caller)

                Return Nothing

            End If

            '取得檔案型態
            Dim Data_Tpye As String = FilePath.ToString.Substring(FilePath.LastIndexOf(".") + 1)


            '判斷是否為 Excel
            If Data_Tpye = "xls" Then

                '讀取Excel的資料字串
                Dim ReadExcel As String
                ReadExcel = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + FilePath + "; Extended Properties=Excel 8.0;"

                Dim DS As New DataSet(TableName)

                '讀取資料
                Using adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("select * from [" & SheetName & "$]", ReadExcel)
                    adapter.Fill(DS, TableName)
                End Using


                returnDatatable = DS.Tables(0)

                Return returnDatatable

            Else

                '檔案不是 Excel
                ShowErrorMsg("CMMCMMB302", "請使用 Office 2003 的 xls 檔案，謝謝。", "", caller)

                Return Nothing

            End If


            Return Nothing

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "傳入檔案路徑，開啟Excel，並將其轉成 System.Data.DataTable 回傳。RowStartIndex 表示要當作Column Name 的那一行，檔案將從 RowStartIndex 下一行視為檔案資料的開始。", "", caller)

            Return Nothing

        End Try

    End Function

#End Region

#Region "     判斷 CheckBox Value，如為True 回傳Y；False 回傳N "

    ''' <summary>
    ''' 判斷 CheckBox Value，如為True 回傳Y，False 回傳N
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2013-8-8</remarks>
    Public Shared Function GetCkbCheckValue(ByRef ckbObj As CheckBox) As String

        Dim returnString As String = "N"

        Try

            If ckbObj.Checked Then

                returnString = "Y"

            End If

            Return returnString

        Catch ex As Exception

            Throw ex

            Return "N"

        End Try

    End Function

#End Region

#Region "     判斷 傳入值，如果為 Y，回傳True；如為 N，回傳False"

    ''' <summary>
    ''' 判斷 傳入值，如果為 Y，則打勾CheckBox，N 則取消勾勾
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-8</remarks>
    Public Shared Function GetCkbTrueFlase(ByVal checkValue As String) As Boolean

        Try

            If checkValue = "Y" Then

                Return True

            Else

                Return False

            End If


        Catch ex As Exception

            Throw ex

            Return False

        End Try

    End Function

#End Region

#Region "     鎖定/解鎖 螢幕 "

    ''' <summary>
    ''' 鎖定螢幕畫面
    ''' </summary>
    ''' <remarks>Copy by Sean.Lin on 2014-06-09</remarks>
    Public Shared Sub Lock(ByRef caller As Object)
        If (TypeOf caller Is Control) Then
            DirectCast(caller, Control).Cursor = Cursors.WaitCursor
        End If
    End Sub

    ''' <summary>
    ''' 解除鎖定螢幕畫面
    ''' </summary>
    ''' <remarks>Copy by Sean.Lin on 2014-06-09</remarks>
    Public Shared Sub UnLock(ByRef caller As Object)
        If (TypeOf caller Is Control) Then
            DirectCast(caller, Control).Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "     顯示問題視窗，傳入要顯示的文字，回傳：確定:True，取消:False "

    ''' <summary>
    ''' 顯示問題視窗，傳入要顯示的文字，回傳：確定:True，取消:False
    ''' </summary>
    ''' <param name="Data" >要顯示的資料</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sean.Lin on 2013-1-18</remarks>
    Public Shared Function ShowQuestionDialog(ByVal Data As System.Text.StringBuilder) As Boolean


        Try

            Return ShowQuestionDialog(Data, 450, 400, "確認視窗")

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示問題視窗，可設定顯示資料，確定:True，取消:False"})


        End Try

    End Function

#End Region

#Region "     顯示問題視窗，傳入要顯示的文字、視窗寬度、視窗高度，回傳：確定:True，取消:False "

    ''' <summary>
    ''' 顯示問題視窗，傳入要顯示的文字、視窗寬度、視窗高度，回傳：確定:True，取消:False
    ''' </summary>
    ''' <param name="Data" >要顯示的資料</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sean.Lin on 2013-1-18</remarks>
    Public Shared Function ShowQuestionDialog(ByVal Data As System.Text.StringBuilder, ByVal width As Integer, ByVal Height As Integer) As Boolean

        Try

            Return ShowQuestionDialog(Data, width, Height, "確認視窗")

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示問題視窗，可設定顯示資料，確定:True，取消:False"})

        End Try

    End Function

#End Region

#Region "     顯示問題視窗，傳入要顯示的文字、視窗寬度、視窗高度、視窗的名稱，回傳：確定:True，取消:False "

    ''' <summary>
    ''' 顯示問題視窗，傳入要顯示的文字、視窗寬度、視窗高度、視窗的名稱，回傳：確定:True，取消:False
    ''' </summary>
    ''' <param name="Data" >要顯示的資料</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sean.Lin on 2013-1-18</remarks>
    Public Shared Function ShowQuestionDialog(ByVal Data As System.Text.StringBuilder, ByVal width As Integer, ByVal Height As Integer, ByVal UIText As String) As Boolean

        Dim returnBoolean As Boolean

        Try


            Dim m_DialogUI As New UCLQuestionDialogUI

            Dim result As String = ""


            m_DialogUI.Text = UIText

            m_DialogUI.Width = width

            m_DialogUI.Height = Height

            m_DialogUI.SetData(Data)


            m_DialogUI.ShowDialog()

            result = m_DialogUI.DialogResult

            If result = "1" Then

                returnBoolean = True

            Else
                '不允許 

                returnBoolean = False

            End If


            Return returnBoolean

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示問題視窗，可設定顯示資料，確定:True，取消:False"})

        End Try

    End Function

#End Region

#Region "     只有三隻LA程式有用，考慮移走 "


    ''' <summary>
    ''' 利用grid DataRow定位focus位移
    ''' </summary>
    ''' <param name="DataGridView1">DataGridView</param>
    ''' <param name="DataRow1">DataRow</param>
    ''' <remarks></remarks>
    Public Shared Sub setRowFocusByDataRow(ByRef DataGridView1 As DataGridView, ByRef DataRow1 As DataRow)
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim matchCount = 0
            For Each strDataColumn As DataColumn In DataRow1.Table.Columns
                If Not row.Cells(strDataColumn.ColumnName).Value.Equals(DataRow1(strDataColumn.ColumnName)) Then
                    matchCount = 0
                    Exit For
                Else
                    matchCount += 1
                End If
            Next
            If matchCount = DataRow1.Table.Columns.Count Then
                DataGridView1.CurrentCell = row.Cells.Item(0)
                Exit For
            End If
        Next
    End Sub
    ''' <summary>
    ''' 利用grid DataRowView定位focus位移
    ''' </summary>
    ''' <param name="DataGridView1">DataGridView</param>
    ''' <param name="DataRowView1">DataRowView</param>
    ''' <remarks></remarks>
    Public Shared Sub setRowFocusByDataRowView(ByRef DataGridView1 As DataGridView, ByRef DataRowView1 As DataRowView)
        If Not DataRowView1 Is Nothing Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.DataBoundItem.Equals(DataRowView1) Then
                    DataGridView1.CurrentCell = row.Cells.Item(0)
                    Exit For
                End If
            Next
        End If
    End Sub


#End Region


#Region "     根據輸入產生一個 DataTable - For Maintain 程式使用 "

#Region "     根據輸入的TableName和欄位字串產生一個DataTable"

    ''' <summary>
    ''' 根據輸入的TableName和欄位字串集合產生一個DataTable
    ''' 輸入為:  Table Name (字串) 和  Table的欄位 (字串集合)
    ''' </summary>
    ''' <param name="TableName">要建立之DataSet的Table名字</param>
    ''' <param name="ColumnData">Table的欄位</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean on 2011-12-6"</remarks>
    Private Shared Function GenDataTable(ByVal TableName As String, ByVal ColumnData() As dgvShowColumn) As DataTable
        Try
            Dim DT_Temp As New DataTable

            '新增Table的欄位
            For i As Integer = 0 To ColumnData.Length - 1

                DT_Temp.Columns.Add(ColumnData(i).DBColumn)

            Next

            Return DT_Temp

        Catch ex As Exception
            ShowErrorMsg("CMMCMMB302", "產生DataTable")
            Throw ex
        End Try
    End Function


#End Region

#Region "     根據輸入的TableName和欄位字串產生一個DataSet並包含一個空的Table "

    ''' <summary>
    ''' 根據輸入的TableName和欄位字串集合產生一個DataSet並包含一個空的Table
    ''' 輸入為:  Table Name (字串) 和  Table的欄位 (字串集合)
    ''' </summary>
    ''' <param name="TableName">要建立之DataSet的Table名字</param>
    ''' <param name="ColumnData">Table的欄位</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sean on 2011-12-6"</remarks>
    Private Shared Function PCSGenDataSet(ByVal TableName As String, ByVal ColumnData() As dgvShowColumn) As DataSet
        Try
            Dim DS_Temp As New DataSet

            '新增一個Table
            DS_Temp.Tables.Add(TableName)

            '新增Table的欄位
            For i As Integer = 0 To ColumnData.Length - 1
                DS_Temp.Tables(0).Columns.Add(ColumnData(i).DBColumn)
            Next

            Return DS_Temp

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "根據輸入的TableName和欄位字串產生一個DataSet並包含一個空的Table ")
            Throw ex
        End Try
    End Function

#End Region

#End Region

End Class

