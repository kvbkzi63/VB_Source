
Imports System.Drawing


Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

''' <summary>
''' 程式說明：提供Horizontal的DataGridView清單, 修改自EMOPatientListUI與EMOPatientListGridUC
''' 開發日期：2010.12.03
''' 開發人員：Barry
''' </summary>
''' <remarks></remarks>
Public Class UCLHorizontalDataGridViewUC

    'Public colName() As String = New String() {"1", "2", "床號", "病患姓名", "年齡", "性別", "備註", "chartNo", "outPatientSn", "tip1", "tip2", "remarkTip", "arrivalTime", "triageRank", "condition"}
    Public _uclDataPerGrid As Integer = 14 '每個grid可以放的筆數
    Public _uclDefaultDgvNum As Integer = 2 '預設需要的Grid數
    Public _uclDtList As List(Of DataTable) = New List(Of DataTable)

    '每個DataGridView都會被設定為相同的值
    Private _uclHeaderText As String = ""
    Private _uclColumnWidth As String = ""
    Private _uclNonVisibleColIndex As String = ""
    Private _uclHeaderFontSize As String = ""
    Private _uclColumnAlignment As String = ""  ' 0:靠左對齊 ,  1:靠右對齊 ,  2:置中
    ''' <summary>
    ''' 設定每個DataGridView的寬度
    ''' </summary>
    ''' <remarks></remarks>
    Private _uclDgvWidth As String = "200"
    ''' <summary>
    ''' 設定本元件是否要預設要選取第一筆資料,預設為false
    ''' </summary>
    ''' <remarks></remarks>
    Private _uclIsFirstRowSelected As Boolean = False
    Private _MultiSelect As Boolean = False
    Private _uclColumnCheckBox As Boolean = False


    '本元件的事件定義
    Public Event CellFormatting(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
    Public Event CellMouseEnter(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    Public Event CellClick(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    Public Event CellDoubleClick(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    Public Event CellValueChanged(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    Public Event DataBindingComplete(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
    ''' <summary>
    ''' 當第一個Gird的第一列被選取時會觸發此事件,另外必須將uclIsFirstRowSelected設為true
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="selectedRow"></param>
    ''' <remarks></remarks>
    Public Event FirtRowSelected(ByVal dgv As System.Windows.Forms.DataGridView, ByVal selectedRow As System.Windows.Forms.DataGridViewRow)



    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

        'initUI(dt)
    End Sub
    Public Sub initUI(ByRef dt As DataTable)
        Try
            If tlpGridData.Controls.Count > 0 Then
                tlpGridData.Controls.Clear()
            End If

            Dim totalRows As Integer = dt.Rows.Count '總筆數
            Dim divideTimes As Integer = Math.Floor(totalRows / _uclDataPerGrid) '需分割的次數
            Dim needGirdCount As Integer = divideTimes + 1 '需要的gird數
            Dim currGridCount As Integer = tlpGridData.Controls.Count '目前已有的grid數
            needGirdCount = IIf(needGirdCount < _uclDefaultDgvNum, _uclDefaultDgvNum, needGirdCount) '設定版面需要的欄位數,不得少於defaultList
            tlpGridData.ColumnCount = needGirdCount

            _uclDtList = DataSetUtil.divideDataTable(dt, _uclDataPerGrid)

            tlpGridData.ColumnStyles.Clear() '一定要有,先清除掉原來的欄位的寬度設定

            '先清除舊資料,避免有殘留資料存在
            For i As Integer = 0 To tlpGridData.Controls.Count - 1
                Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (i)), UCLDataGridViewUC)
                dgv.ClearDS()
                '重新設定所有Column的大小,以免因為前面的clear造成格式不見
                tlpGridData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, _uclDgvWidth))
            Next

            '調整Grid數,多的移除不夠的新增
            If needGirdCount <> currGridCount Then
                If needGirdCount > currGridCount Then '需要的gird數>目前已有的,需新增

                    Dim diffCount = needGirdCount - currGridCount
                    For i As Integer = 1 To diffCount
                        addBlankGrid(currGridCount)
                        currGridCount += 1
                    Next

                Else '移除
                    Dim diffCount = currGridCount - needGirdCount
                    For i As Integer = 1 To diffCount
                        If currGridCount <= _uclDefaultDgvNum Then '不能少於defaultList,但要清除內容
                            Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (currGridCount - 1)), UCLDataGridViewUC)
                            dgv.ClearDS()
                        Else
                            tlpGridData.Controls.Remove(tlpGridData.Controls.Item("dgv" & (currGridCount - 1))) '移除
                        End If
                        currGridCount -= 1
                    Next

                End If

            End If

            '設定dgv的資料
            For idx As Integer = 0 To _uclDtList.Count - 1
                Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (idx)), UCLDataGridViewUC)
                setGridData(idx, dgv, _uclDtList(idx))

                '設定Dgv的事件
                AddHandler dgv.CellFormatting, AddressOf RaiseCellFormatting
                AddHandler dgv.CellMouseEnter, AddressOf RaiseCellMouseEnter
                AddHandler dgv.CellClick, AddressOf RaiseCellClick
                AddHandler dgv.CellDoubleClick, AddressOf RaiseCellDoubleClick
                AddHandler dgv.CellValueChanged, AddressOf RaiseCellValueChanged
                'AddHandler dgv.shown, AddressOf RaiseShow
                AddHandler dgv.dgv.DataBindingComplete, AddressOf RaiseDataBindingComplete

            Next

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub
    ''' <summary>
    ''' 將所有DataGridView的選擇取消,只能在dgv初始化完後呼叫才有用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearDgvAllSelection()
        For idx As Integer = 0 To _uclDtList.Count - 1
            Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (idx)), UCLDataGridViewUC)
            'If dgv.CurrentRow IsNot Nothing Then
            '    dgv.CurrentRow.Selected = False '只能用在該dgv有currentRow
            'End If
            dgv.ClearSelection()

            'If dgv.Rows.Count > 0 Then'用在將第一筆資料取消
            '    dgv.Rows(0).Selected = False '這個也沒有用, 原本就是false了
            'End If
        Next
    End Sub

    ''' <summary>
    ''' 將所有DataGridView的選擇取消,只能在dgv初始化完後呼叫才有用
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectedAllDgvRows()
        For idx As Integer = 0 To _uclDtList.Count - 1
            Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (idx)), UCLDataGridViewUC)


            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(0).Value = True
                dgv.GetGridDS.Tables(0).Rows(i).Item(0) = "Y"
                dgv.GetDBDS.Tables(0).Rows(i).Item(0) = "Y"
                selectedRow.Add(dgv.Rows(i))
            Next


        Next
    End Sub

    ''' <summary>
    ''' 將所有DataGridView的選擇取消,只能在dgv初始化完後呼叫才有用
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeSelectedAllDgvRows()
        For idx As Integer = 0 To _uclDtList.Count - 1
            Dim dgv As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv" & (idx)), UCLDataGridViewUC)


            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(0).Value = False
                dgv.GetGridDS.Tables(0).Rows(i).Item(0) = "N"
                dgv.GetDBDS.Tables(0).Rows(i).Item(0) = "N"

            Next


        Next
        selectedRow.Clear()
    End Sub


    ''' <summary>
    ''' 建立新的空白Dgv並且設定其屬性
    ''' </summary>
    ''' <param name="idx"></param>
    ''' <remarks></remarks>
    Private Sub addBlankGrid(ByVal idx As Integer)
        Dim dgv As UCLDataGridViewUC = New UCLDataGridViewUC
        'Dim ds As DataSet = New DataSet
        dgv.Name = "dgv" & idx

        'tlpGridData.Controls.Add(dgv, idx, 0)
        tlpGridData.Controls.Add(dgv)
        '設定Column的大小
        'tlpGridData.ColumnStyles(idx) = New ColumnStyle(SizeType.Absolute, 350)
        'tlpGridData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, _uclDgvWidth))
        'tlpGridData.ColumnStyles.Item(idx).Width = 100

        dgv.Dock = Windows.Forms.DockStyle.Fill

        'setGridData(dgv, New DataTable)
    End Sub

    ''' <summary>
    ''' 將資料餵給Dgv並且設定其屬性
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="perDt"></param>
    ''' <remarks></remarks>
    Private Sub setGridData(ByVal idx As Integer, ByRef dgv As UCLDataGridViewUC, ByRef perDt As DataTable)
        'Dim idx As Integer = CInt(perDt.TableName)
        'Dim dgv As UCLDataGridViewUC = New UCLDataGridViewUC
        '設定Column的大小
        tlpGridData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, _uclDgvWidth))

        Dim ds As DataSet = New DataSet
        ds.Tables.Add(perDt)



        '加入第0個欄位為checkbox
        If _MultiSelect Then

            'dgv.uclColumnCheckBox = True
            'dgv.MultiSelect = True

            Dim hash As New Hashtable
            hash.Add(-1, ds)
            hash.Add(0, New CheckBoxCell)
            dgv.Initial(hash)
        Else
            dgv.Initial(ds)
        End If

        dgv.uclHeaderText = _uclHeaderText
        dgv.uclColumnWidth = _uclColumnWidth
        dgv.uclNonVisibleColIndex = _uclNonVisibleColIndex
        dgv.uclColumnAlignment = _uclColumnAlignment
        '多選功能
        'dgv.uclColumnCheckBox = _uclColumnCheckBox
        'dgv.MultiSelect = _MultiSelect
        setHeaderFontSize(dgv)
        dgv.GetSelectedIndex()
    End Sub

    ''' <summary>
    ''' 設定Dgv的Header文字大小
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub setHeaderFontSize(ByRef dgv As UCLDataGridViewUC)
        If _uclHeaderFontSize.Trim() <> "" Then

            Try
                Dim headerStr As String() = Split(_uclHeaderFontSize, ",")

                If dgv.GetDBDS.Tables(0).Columns.Count >= headerStr.Length Then

                    If dgv.MultiSelect AndAlso dgv.uclColumnCheckBox Then
                        For i As Integer = 1 To headerStr.Length
                            If headerStr(i - 1).Trim() <> "" AndAlso i >= 0 Then
                                dgv.Columns.Item(i).HeaderCell.Style.Font = New Font(Me.Font.FontFamily, CInt(headerStr(i - 1).Trim()))
                            End If
                        Next
                    Else
                        '沒有多選就從0開始
                        For i As Integer = 0 To headerStr.Length - 1
                            If headerStr(i).Trim() <> "" AndAlso i >= 0 Then
                                dgv.Columns.Item(i).HeaderCell.Style.Font = New Font(Me.Font.FontFamily, CInt(headerStr(i).Trim()))

                            End If
                        Next
                    End If


                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            End Try
        End If
    End Sub
    Public selectedRow As HashSet(Of DataGridViewRow) = New HashSet(Of DataGridViewRow)

#Region "事件設定"
    Private Sub RaiseCellFormatting(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        RaiseEvent CellFormatting(dgv, e)
    End Sub
    Private Sub RaiseCellMouseEnter(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        RaiseEvent CellMouseEnter(dgv, e)
    End Sub
    Private Sub RaiseCellValueChanged(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        clearDgvAllSelection()
        dgv.CurrentCell.Selected = True
        If MultiSelect AndAlso e.ColumnIndex = 0 Then
            If dgv.Item(0, e.RowIndex).Value = True Then
                selectedRow.Add(dgv.CurrentRow)
            Else
                selectedRow.Remove(dgv.CurrentRow)
            End If
        End If

        RaiseEvent CellClick(dgv, e)
    End Sub
    Private Sub RaiseCellClick(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            ScreenUtil.Lock(Me)
            clearDgvAllSelection()
            dgv.CurrentCell.Selected = True
            RaiseEvent CellClick(dgv, e)
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ex.StackTrace}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub
    Private Sub RaiseCellDoubleClick(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            ScreenUtil.Lock(Me)
            clearDgvAllSelection()
            dgv.CurrentCell.Selected = True
            RaiseEvent CellDoubleClick(dgv, e)
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ex.StackTrace}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try

    End Sub
    Private Sub RaiseShow(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        clearDgvAllSelection()
        dgv.CurrentCell.Selected = True
        RaiseEvent CellDoubleClick(dgv, e)
    End Sub
    Private Sub RaiseDataBindingComplete(ByVal dgv As System.Windows.Forms.DataGridView, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        'Dim dgv As DataGridView = CType(sender, DataGridView)
        dgv.ClearSelection() '初始化完後清除所有選擇的項目
        '預選第一筆資料
        If _uclIsFirstRowSelected Then
            Dim uc As UCLDataGridViewUC = CType(tlpGridData.Controls.Item("dgv0"), UCLDataGridViewUC)
            'gridUC = uc
            If uc.Rows.Count > 0 Then
                'uc.CurrentCell.Selected = Nothing
                'MsgBox(uc.dgv.SelectedCells(0).Selected)
                uc.Rows(0).Selected = True
                RaiseEvent FirtRowSelected(dgv, uc.CurrentRow)
                'uc.CurrentCellAddress.Y = -1
                'uc.CurrentCell = Nothing
                'uc.ClearSelection()
                'uc.dgv.CurrentCellAddress.Y = 0
            End If
        End If
        RaiseEvent DataBindingComplete(dgv, e)
    End Sub

#End Region

#Region "屬性設定"
    Public Property uclHeaderText() As String
        Get
            Return _uclHeaderText
        End Get
        Set(ByVal value As String)
            _uclHeaderText = value
        End Set
    End Property

    Public Property uclColumnWidth() As String
        Get
            Return _uclColumnWidth
        End Get
        Set(ByVal value As String)
            _uclColumnWidth = value
        End Set
    End Property
    Public Property uclNonVisibleColIndex() As String
        Get
            Return _uclNonVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclNonVisibleColIndex = value
        End Set
    End Property
    Public Property uclHeaderFontSize() As String
        Get
            Return _uclHeaderFontSize
        End Get
        Set(ByVal value As String)
            _uclHeaderFontSize = value
        End Set
    End Property

    Public Property uclDataPerGrid() As String
        Get
            Return _uclDataPerGrid
        End Get
        Set(ByVal value As String)
            _uclDataPerGrid = value
        End Set
    End Property
    Public Property uclDefaultDgvNum() As String
        Get
            Return _uclDefaultDgvNum
        End Get
        Set(ByVal value As String)
            _uclDefaultDgvNum = value
        End Set
    End Property
    Public Property uclDtList() As List(Of DataTable)
        Get
            Return _uclDtList
        End Get
        Set(ByVal value As List(Of DataTable))
            _uclDtList = value
        End Set
    End Property
    Public Property uclDgvWidth() As String
        Get
            Return _uclDgvWidth
        End Get
        Set(ByVal value As String)
            _uclDgvWidth = value
        End Set
    End Property
    Public Property uclIsFirstRowSelected() As String
        Get
            Return _uclIsFirstRowSelected
        End Get
        Set(ByVal value As String)
            _uclIsFirstRowSelected = value
        End Set
    End Property
    Public Property uclColumnAlignment() As String
        Get
            Return _uclColumnAlignment
        End Get
        Set(ByVal value As String)
            _uclColumnAlignment = value
        End Set
    End Property
    Public Property uclColumnCheckBox() As Boolean
        Get
            Return _uclColumnCheckBox
        End Get
        Set(ByVal value As Boolean)
            _uclColumnCheckBox = value
        End Set
    End Property
    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value
        End Set
    End Property
#End Region
End Class
