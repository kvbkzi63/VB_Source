Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Client.CMM
Imports System.Text
Imports Syscom.Comm.BASE
Imports Syscom.Client.UCL.ComboBoxGridCell

Public Class UCLComboBoxGridOpenWindowUC


#Region "全域變數宣告"

    Dim WithEvents mgrComboBox As EventManager = EventManager.getInstance '宣告EventManager

    Dim _uclNonVisibleColIndex As String
    Dim _uclVisibleColIndex As String
    Private _uclHeaderText As String = ""
    Private _uclColumnWidth As String = ""
    Private _uclIsAlternatingRowsColor As String = "Y"


    ' Dim pvtDS As DataSet
    Dim dsDB As DataSet
    Dim dsGrid As DataSet
    Dim cboName As String
    Dim CodeColIndex As Integer = 0
    Dim NameColIndex As Integer = 1
    Dim CellRowIndex As Integer = 0
    Dim CellColIndex As Integer = 0
    '用在datagridview的ComboBoxGrid
    Dim cbodgv As UCLDataGridViewUC = Nothing

    Public Shared gblFont As String = "微軟正黑體"                '系統字體
    Public Shared gblFontSize_1024_768 As Integer = 12            '系統字體大小(1024x768)
    Public Shared gblFontSize_1920_1080 As Integer = 16           '系統字體大小(1920x1080)

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
            If dsGrid IsNot Nothing Then
                SetNonVisibleCol()
            End If

        End Set
    End Property



    Public Property uclVisibleColIndex() As String
        Get
            Return _uclVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclVisibleColIndex = value
            If dsGrid IsNot Nothing Then
                SetVisibleCol()
            End If

        End Set
    End Property

#End Region

    ''' <summary>
    '''  設定GridView 資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetDataSet(ByVal ds As DataSet)
        cbo_dgv.DataSource = ds
    End Sub


    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

        '設定成共用的字型
        Me.Font = AppConfigUtil.ControlFont
        If Screen.PrimaryScreen.Bounds.Width >= 1920 Then
            cbo_dgv.Font = New Font(gblFont, gblFontSize_1920_1080)
        End If

        Me.TopMost = True
        'Color.WhiteSmoke
        'cbo_dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' name:Parent元件名稱
    ''' ds:來源資料
    ''' CodeIndex:代碼的索引
    ''' NameIndex:名稱的索引
    ''' ColIndex:目前Cell的Column Index
    ''' RowIndex:目前Cell的Row Index
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Overloads Sub Initial(ByVal comboBoxName As String, ByVal ds As DataSet, ByVal ColIndex As Integer, ByVal RowIndex As Integer, ByRef dgv As UCLDataGridViewUC)
        'ByRef grid As UCLDataGridViewUI,
        Try
            'cbodgv = grid
            CellColIndex = ColIndex
            CellRowIndex = RowIndex

            '==============================
            Try
                If ds.Tables(0).Columns.Contains("Order_Code") Then
                    Dim OrderCodeForSortingList As New ArrayList
                    If Not ds.Tables(0).Columns.Contains("OrderCode_SortValue") Then
                        ds.Tables(0).Columns.Add("OrderCode_SortValue")
                    End If

                    If Not ds.Tables(0).Columns.Contains("Valid_Order_SortValue") Then
                        ds.Tables(0).Columns.Add("Valid_Order_SortValue")
                    End If

                    Try

                        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            If Not OrderCodeForSortingList.Contains(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim) Then
                                OrderCodeForSortingList.Add(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim)
                            End If
                        Next
                         
                        Dim sort As New NaturalSortComparer
                        OrderCodeForSortingList.Sort(sort)

                        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            If OrderCodeForSortingList.IndexOf(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim).ToString.Trim.Length = 1 Then
                                ds.Tables(0).Rows(i).Item("OrderCode_SortValue") = "00" & OrderCodeForSortingList.IndexOf(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim)
                            ElseIf OrderCodeForSortingList.IndexOf(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim).ToString.Trim.Length = 2 Then
                                ds.Tables(0).Rows(i).Item("OrderCode_SortValue") = "0" & OrderCodeForSortingList.IndexOf(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim)
                            Else
                                ds.Tables(0).Rows(i).Item("OrderCode_SortValue") = OrderCodeForSortingList.IndexOf(ds.Tables(0).Rows(i).Item("Order_Code").ToString.Trim)
                            End If

                            If ds.Tables(0).Columns.Contains("Is_Valid_Order") AndAlso ds.Tables(0).Rows(i).Item("Is_Valid_Order").ToString.Trim = "Y" Then
                                ds.Tables(0).Rows(i).Item("Valid_Order_SortValue") = "1"
                            Else

                                ds.Tables(0).Rows(i).Item("Valid_Order_SortValue") = "2"

                            End If
                        Next
                    Catch ex As Exception
                    End Try

                    Dim view As DataView
                    view = ds.Tables(0).DefaultView

                    view.Sort = ds.Tables(0).Columns("Valid_Order_SortValue").ColumnName & "," & ds.Tables(0).Columns("OrderCode_SortValue").ColumnName
                     
                    ds.Tables.Clear()
                    ds.Tables.Add(view.ToTable.Copy)

                End If
            Catch ex As Exception
            End Try
            '==============================

            dsGrid = ds
            cboName = comboBoxName
            cbodgv = dgv
            If dsGrid IsNot Nothing AndAlso dsGrid.Tables(0).Rows.Count > 0 Then
                cbo_dgv.DataSource = dsGrid.Tables(0)
                'CodeColIndex = CodeIndex
                'NameColIndex = NameIndex
                ' SetHeaderText()
                ' SetColumnAlignment()

                ' SetColReadOnly()
                cbo_dgv.ClearSelection()
                ' SortableColumnIndex()
                If _uclVisibleColIndex IsNot Nothing AndAlso _uclVisibleColIndex.Trim() <> "" Then
                    SetVisibleCol()
                Else
                    SetNonVisibleCol()
                End If

                SetHeaderText()
                SetColWidth()



                'ProcessDrugColor()

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub



    Public Sub ProcessDrugColor(ByVal uclSource As UCLComboBoxGridUC.DBSource)


        Try
            If Not (dsGrid.Tables(0).Columns.Contains("Opd_Lack_Id") AndAlso dsGrid.Tables(0).Columns.Contains("Emg_Lack_Id") AndAlso dsGrid.Tables(0).Columns.Contains("Ipd_Lack_Id")) Then
                Exit Sub
            End If

            If dsGrid.Tables(0).Columns.Contains("UclOrderMixedNew") Then
                '使用新版
                cbo_dgv.CurrentCell = Nothing

                For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1

                    If (dsGrid.Tables(0).Rows(i).Item("Opd_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Opd_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.O) OrElse _
                        (dsGrid.Tables(0).Rows(i).Item("Emg_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Emg_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.E) OrElse _
                        (dsGrid.Tables(0).Rows(i).Item("Ipd_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Ipd_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.I) Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If

                    If dsGrid.Tables(0).Rows(i).Item("DC").ToString.ToUpper.Trim = "Y" Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If

                    If dsGrid.Tables(0).Columns.Contains("Is_Valid_Order") AndAlso dsGrid.Tables(0).Rows(i).Item("Is_Valid_Order").ToString.ToUpper.Trim = "N" Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If

                    If cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray AndAlso dsGrid.Tables(0).Rows(i).Item("Is_Alternative").ToString.Trim <> "Y" Then
                        '沒有替代的 就不顯示
                        cbo_dgv.Rows(i).Visible = False
                    End If

                Next

            Else
                For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1

                    If (dsGrid.Tables(0).Rows(i).Item("Opd_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Opd_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.O) OrElse _
                        (dsGrid.Tables(0).Rows(i).Item("Emg_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Emg_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.E) OrElse _
                        (dsGrid.Tables(0).Rows(i).Item("Ipd_Lack_Id") IsNot DBNull.Value AndAlso dsGrid.Tables(0).Rows(i).Item("Ipd_Lack_Id").ToString.Trim <> "N" AndAlso uclSource = UCLComboBoxGridUC.DBSource.I) Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If

                    If dsGrid.Tables(0).Rows(i).Item("DC").ToString.ToUpper.Trim = "Y" Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If

                    If dsGrid.Tables(0).Columns.Contains("Is_Valid_Order") AndAlso dsGrid.Tables(0).Rows(i).Item("Is_Valid_Order").ToString.ToUpper.Trim = "N" Then
                        cbo_dgv.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    End If
                Next

            End If


            If dsGrid.Tables.Count = 2 AndAlso dsGrid.Tables(0).Columns.Contains("Pharmacy_12_Code") Then

                For i As Integer = 0 To dsGrid.Tables(0).Rows.Count - 1

                    If dsGrid.Tables(1).Select(" Pharmacy_12_Code='" & dsGrid.Tables(0).Rows(i).Item("Pharmacy_12_Code").ToString.Trim & "' And Property_Id='05' ").Count > 0 Then
                        cbo_dgv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    End If

                Next

            End If
        Catch ex As Exception

        End Try


    End Sub

    ''' <summary>
    ''' 取得GridView
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Public Function getGridView() As DataGridView
        Return cbo_dgv
    End Function

    ''' <summary>
    ''' 設定GridView是否可見
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetGridVisible(ByVal bool As Boolean)
        cbo_dgv.Visible = bool
        Me.Visible = bool
    End Sub


    ''' <summary>
    '''  設定顯示的grid column
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetVisibleCol()
        Try
            If _uclVisibleColIndex IsNot Nothing AndAlso _uclVisibleColIndex.Trim() <> "" Then
                Dim colIndex As String() = Split(_uclVisibleColIndex.Trim(), ",")

                For i As Integer = 0 To cbo_dgv.Columns.Count - 1
                    cbo_dgv.Columns(i).Visible = False
                Next

                For i As Integer = 0 To colIndex.Length - 1
                    cbo_dgv.Columns(CInt(colIndex(i))).Visible = True
                Next
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    ''' <summary>
    '''  設定隱藏的grid column
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetNonVisibleCol()
        Try
            If _uclNonVisibleColIndex IsNot Nothing AndAlso _uclNonVisibleColIndex.Trim() <> "" Then
                Dim colIndex As String() = Split(_uclNonVisibleColIndex.Trim(), ",")

                For i As Integer = 0 To colIndex.Length - 1
                    cbo_dgv.Columns(CInt(colIndex(i))).Visible = False
                Next
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    ''' <summary>
    '''  設定Grid Header Text
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetHeaderText()
        If _uclHeaderText.Trim() <> "" Then

            Try
                Dim headerStr As String() = Split(_uclHeaderText, ",")

                If dsGrid.Tables(0).Columns.Count >= headerStr.Length Then



                    For i As Integer = 0 To headerStr.Length - 1
                        If headerStr(i).Trim() <> "" Then
                            cbo_dgv.Columns(i).HeaderText = headerStr(i).Trim()

                        End If
                    Next

                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Public Sub SetColWidth()
        If _uclColumnWidth.Trim() <> "" Then
            Try
                Dim widthStr As String() = Split(_uclColumnWidth, ",")

                If dsGrid.Tables(0).Columns.Count >= widthStr.Length Then

                    For i As Integer = 0 To widthStr.Length - 1
                        If widthStr(i).Trim() <> "" AndAlso CInt(widthStr(i).Trim()) > 0 AndAlso i >= 0 AndAlso i <= cbo_dgv.Columns.Count - 1 Then
                            cbo_dgv.Columns(i).Width = CInt(widthStr(i).Trim())

                        End If
                    Next

                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            End Try
        End If
    End Sub




#Region "Event"


    Private Sub cbo_dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles cbo_dgv.CellClick
        Try

            If e.RowIndex >= 0 Then
                '啟動EventManager的RaiseEvent
                Dim row As DataGridViewRow
                row = cbo_dgv.SelectedRows(0)

                Try
                    If dsGrid.Tables(0).Columns.Contains("DC") AndAlso dsGrid.Tables(0).Rows(e.RowIndex).Item("DC").ToString.Trim = "Y" AndAlso cbodgv.cboGrid_cell.IsCanSelectDcOrder = YNData.N Then
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try

                Me.Visible = False
                mgrComboBox.RaiseUclOpenWindowComboBoxGridValue(cboName, CellRowIndex, CellColIndex, row)

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub GetFirstRow()
        Try

            '啟動EventManager的RaiseEvent
            Dim row As DataGridViewRow
            row = cbo_dgv.Rows(0)

            Me.Visible = False
            mgrComboBox.RaiseUclOpenWindowComboBoxGridValue(cboName, CellRowIndex, CellColIndex, row)

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try


            Select Case keyData
                Case Keys.Enter
                    Dim row As DataGridViewRow
                    row = cbo_dgv.SelectedRows(0)
                    Me.Visible = False
                    mgrComboBox.RaiseUclOpenWindowComboBoxGridValue(cboName, CellRowIndex, CellColIndex, row)
                    Return True '回傳True 才不下移一個Row
                Case Keys.Escape

                    Me.Visible = False
                    Return True
                Case Keys.Space
                    cbodgv.ComboBoxGridFlag = True
                    Dim row As DataGridViewRow
                    row = cbo_dgv.SelectedRows(0)
                    Me.Visible = False
                    mgrComboBox.RaiseUclOpenWindowComboBoxGridValue(cboName, CellRowIndex, CellColIndex, row)




                    Return True '回傳True 才不下移一個Row
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

#End Region


    '當ComboBoxGrid 按下 向下鍵時  選擇第一 筆資料
    Private Sub UCLComboBoxGridOpenWindowUI_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '會有挑選的跟顯示的不同的結果 先mark 起來 2016/10/11
        'cbo_dgv.BindingContext(cbo_dgv.DataSource).Position = 1
    End Sub


    Public Sub AutoAdjust()
        If Me.Visible Then


            Dim dgvHeight As Integer = 0
            Dim dgvWidth As Integer = 0


            dgvHeight = dsGrid.Tables(0).Rows.Count * 25 + cbo_dgv.ColumnHeadersHeight

            'If dgvHeight < Me.Height Then
            Me.Height = dgvHeight
            'End If

            For i As Integer = 0 To cbo_dgv.Columns.Count - 1
                If cbo_dgv.Columns(i).Visible Then
                    dgvWidth += cbo_dgv.Columns(i).Width
                End If
            Next

            If dgvWidth < Me.Width Then
                Me.Width = dgvWidth + 10
            End If
        End If
    End Sub
End Class

Public Class NaturalSortComparer
    Implements IComparer

    Public Function Compare(ByVal x As Object,
                ByVal y As Object) As Integer Implements IComparer.Compare

        ' [1] Validate the arguments.
        Dim s1 As String = x
        If s1 = Nothing Then
            Return 0
        End If

        Dim s2 As String = y
        If s2 = Nothing Then
            Return 0
        End If

        Dim len1 As Integer = s1.Length
        Dim len2 As Integer = s2.Length
        Dim marker1 As Integer = 0
        Dim marker2 As Integer = 0

        ' [2] Loop over both Strings.
        While marker1 < len1 And marker2 < len2

            ' [3] Get Chars.
            Dim ch1 As Char = s1(marker1)
            Dim ch2 As Char = s2(marker2)

            Dim space1(len1) As Char
            Dim loc1 As Integer = 0
            Dim space2(len2) As Char
            Dim loc2 As Integer = 0

            ' [4] Collect digits for String one.
            Do
                space1(loc1) = ch1
                loc1 += 1
                marker1 += 1

                If marker1 < len1 Then
                    ch1 = s1(marker1)
                Else
                    Exit Do
                End If
            Loop While Char.IsDigit(ch1) = Char.IsDigit(space1(0))

            ' [5] Collect digits for String two.
            Do
                space2(loc2) = ch2
                loc2 += 1
                marker2 += 1

                If marker2 < len2 Then
                    ch2 = s2(marker2)
                Else
                    Exit Do
                End If
            Loop While Char.IsDigit(ch2) = Char.IsDigit(space2(0))

            ' [6] Convert to Strings.
            Dim str1 = New String(space1)
            Dim str2 = New String(space2)

            ' [7] Parse Strings into Integers.
            Dim result As Integer
            If Char.IsDigit(space1(0)) And Char.IsDigit(space2(0)) Then
                Dim thisNumericChunk = Integer.Parse(str1)
                Dim thatNumericChunk = Integer.Parse(str2)
                result = thisNumericChunk.CompareTo(thatNumericChunk)
            Else
                result = str1.CompareTo(str2)
            End If

            ' [8] Return result if not equal.
            If Not result = 0 Then
                Return result
            End If
        End While

        ' [9] Compare lengths.
        Return len1 - len2
    End Function

End Class
