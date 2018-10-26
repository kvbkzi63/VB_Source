Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports Com.Syscom.WinFormsUI.Docking

'Imports System.Collections.Specialized '20121009/fangchen/新增為了自建型別'querycmdCollection'中的'ListDictionary' datatype



Public Class ScreenUtil

    'Structure querycmdCollection '20121008/fangchen/傳給查詢共用程式querySqlServer作為儲存查詢的參數之用
    '    Dim TableName As String
    '    Dim CommandType As Integer
    '    Dim CommandText As String
    '    'Dim ParamList As ListDictionary '需Imports System.Collections.Specialized
    '    Dim ParamList(,) As Object
    'End Structure
    Enum ValidateType
        Number
        Float
        Decimal2
        IP
        DateData
        CustomerLessOne '小於1的數字()
        CustomerDecimal
        Time
    End Enum

    Enum CustomerValidateType
        CustomerLessOne '小於1的數字
        CustomerDecimal
    End Enum

    '''當畫面上有錯誤輸入時將背景顏色替換掉
    Public Shared BACK_COLOR_ERROR_INPUT As Color = Color.Pink  '<---未來這可改成讀取設定檔
    '''畫面上輸入的預設顏色
    Public Shared BACK_COLOR_DEFAULT As Color = Color.White '...這要查一下目前預設顏色是不是這個 
    '必要輸入欄位
    Public Shared MUST_KEYIN_COLOR As Color = Color.Red

    Public Shared Sub Lock(ByRef caller As Object)
        If (TypeOf caller Is Form) Then
            DirectCast(caller, Form).Cursor = Cursors.WaitCursor
        ElseIf (TypeOf caller Is Label) Then
            DirectCast(caller, Label).Cursor = Cursors.WaitCursor
        ElseIf (TypeOf caller Is Button) Then
            DirectCast(caller, Button).Cursor = Cursors.WaitCursor
        End If
    End Sub

    Public Shared Sub UnLock(ByRef caller As Object)
        If (TypeOf caller Is Form) Then
            DirectCast(caller, Form).Cursor = Cursors.Default
        ElseIf (TypeOf caller Is Label) Then
            DirectCast(caller, Label).Cursor = Cursors.Default
        ElseIf (TypeOf caller Is Button) Then
            DirectCast(caller, Button).Cursor = Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' 處理 sort 之後，focus 位移的問題
    ''' </summary>
    ''' <param name="DataGridView1">DataGridView 控制項</param>
    ''' <param name="columnIndex">cell index</param>
    ''' <param name="values">與cell 比對的值</param>
    ''' <remarks></remarks>
    Public Shared Sub setRowFocus(ByRef DataGridView1 As DataGridView, ByRef columnIndex As Integer(), ByRef values As String())
        If DataGridView1.ContainsFocus Then
            DataGridView1.CurrentRow.Selected = False
            DataGridView1.CurrentCell = Nothing

            '每一行比對值
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim found = False
                Dim matchCount = 0
                '比對cell 與 輸入值
                For Each index As Integer In columnIndex
                    If Not values(index).Equals(CStr(row.Cells(index).Value)) Then
                        matchCount = 0
                        Exit For
                    Else
                        matchCount += 1
                    End If
                    If matchCount = columnIndex.Length Then
                        found = True
                    End If
                Next
                If found Then
                    row.Selected = True
                    DataGridView1.CurrentCell = row.Cells.Item(0)
                    For Each index As Integer In columnIndex
                        values(index) = CStr(DataGridView1.CurrentRow.Cells(index).Value)
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub


    ''' <summary>
    ''' 利用grid key定位focus位移
    ''' </summary>
    ''' <param name="DataGridView1">DataGridView</param>
    ''' <param name="DataTable1">DataTable</param>
    ''' <param name="DataRow1">DataRow</param>
    ''' <remarks></remarks>
    Public Shared Sub setRowFocusByPrimaryKey(ByRef DataGridView1 As DataGridView, ByRef DataTable1 As DataTable, ByRef DataRow1 As DataRow)
        If DataTable1.PrimaryKey.Count > 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim matchCount = 0
                For Each strDataColumn As DataColumn In DataTable1.PrimaryKey
                    If Not row.Cells(strDataColumn.ColumnName).Value.Equals(DataRow1(strDataColumn.ColumnName)) Then
                        matchCount = 0
                        Exit For
                    Else
                        matchCount += 1
                    End If

                Next
                If matchCount = DataTable1.PrimaryKey.Count Then
                    DataGridView1.CurrentCell = row.Cells.Item(0)
                    Exit For
                End If
            Next
        End If
    End Sub
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

    ''' <summary>
    ''' 程式說明：顯示格式化過的資料在DataGridView
    ''' 開發人員：谷官
    ''' 開發日期：2009.10.21
    ''' </summary>
    ''' <param name="dgv">顯示資料的DataGridView</param>
    ''' <param name="dt">欲顯示的資料</param>
    ''' <param name="columnNameMap">DataGridView欄位和資料庫欄位Mapping的Array</param>
    ''' <param name="clearSelectionFlag">是否清除資料行的選取狀態</param>
    ''' <remarks></remarks>
    Public Shared Sub showDataGridViewResult(ByRef dgv As DataGridView, ByVal dt As DataTable, ByVal columnNameMap(,) As String, ByVal clearSelectionFlag As Boolean)
        Try
            dgv.DataSource = Nothing
            dgv.Columns.Clear()
            dgv.DataSource = dt.Copy
            '----------------------------------------------------------------------------
            '#Step1.設定欄位顯示的名稱與顯示與否
            '----------------------------------------------------------------------------
            For i As Integer = 0 To columnNameMap.GetUpperBound(0)
                If Not columnNameMap(i, 0).Equals("") Then
                    '1.設定欄位顯示的名稱
                    dgv.Columns(i).HeaderText = columnNameMap(i, 0)
                    '2.設定欄位為唯讀
                    dgv.Columns(i).ReadOnly = True
                    '3.設定欄位顯示與否
                    If columnNameMap(i, 2).Trim.Equals("N") Then
                        dgv.Columns(i).Visible = False
                    Else
                        '設定顯示的欄位長度
                        If Not columnNameMap(i, columnNameMap.GetUpperBound(1)).Trim.Equals("") Then
                            dgv.Columns(i).Width = CInt(columnNameMap(i, columnNameMap.GetUpperBound(1)).Trim)
                        End If
                    End If
                    '4.設定欄位的顯示格式
                    If Not columnNameMap(i, columnNameMap.GetUpperBound(1) - 1).Trim.Equals("N") Then
                        Select Case columnNameMap(i, columnNameMap.GetUpperBound(1) - 1)
                            Case "DT"   '日期&時間
                                dgv.Columns(i).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                            Case "D"    '日期
                                dgv.Columns(i).DefaultCellStyle.Format = "yyyy/MM/dd"
                            Case "M"    '金額
                                dgv.Columns(i).DefaultCellStyle.Format = "#,##0.##"

                                '靠右對齊
                                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                'Case "NO"   '數字
                                '    dgv.Columns(i).DefaultCellStyle.Format = "0.00"
                                '    '靠右對齊
                                'Case "NO1"   '數字
                                '    dgv.Columns(i).DefaultCellStyle.Format = "0"
                                '    '靠右對齊
                                '    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "NO1", "NO1_L", "NO1_R"   '數字
                                dgv.Columns(i).DefaultCellStyle.Format = "0.00"

                                '靠左對齊
                                If columnNameMap(i, columnNameMap.GetUpperBound(1) - 1).Equals("NO1_L") Then
                                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                                End If

                                '靠右對齊
                                If columnNameMap(i, columnNameMap.GetUpperBound(1) - 1).Equals("NO1_R") Then
                                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                End If
                            Case "NO2", "NO2_L", "NO2_R"   '數字
                                dgv.Columns(i).DefaultCellStyle.Format = "0"

                                '靠左對齊
                                If columnNameMap(i, columnNameMap.GetUpperBound(1) - 1).Equals("NO2_L") Then
                                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                                End If

                                '靠右對齊
                                If columnNameMap(i, columnNameMap.GetUpperBound(1) - 1).Equals("NO2_R") Then
                                    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                End If
                        End Select
                    End If
                End If
            Next
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            'Step2.清除Grid的選取行狀態
            '----------------------------------------------------------------------------
            If clearSelectionFlag Then dgv.ClearSelection()
            '----------------------------------------------------------------------------
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Add Columns to DataGridView
    ''' 開發人員：Fang-Chen Hwang
    ''' 開發日期：2012.10.08
    ''' </summary>
    ''' 設定DataGridView的欄位,並依據參數決定是否要增加"選"(checkbox)的欄位
    ''' <param name="dgv">欲顯示資料的DataGridView控制項</param>
    ''' <param name="columnNameMap">DataGridView欄位和資料庫欄位Mapping的Array</param>
    ''' <param name="checkBoxColumn">是否要增加"選"的欄位</param>
    ''' <remarks></remarks>
    Public Shared Sub addGridViewColumns(ByVal dgv As DataGridView, ByVal columnNameMap(,) As String, ByVal checkBoxColumn As Boolean)
        For columnidx As Integer = 0 To columnNameMap.GetUpperBound(0)
            '1.設定欄位名稱
            If columnNameMap(columnidx, 3).Trim.Equals("C") Then 'comboxbox
                Dim cmb As New DataGridViewComboBoxColumn
                dgv.Columns.Add(cmb)
                dgv.Columns(columnidx).Name = columnNameMap(columnidx, 1) '設定欄位名稱
                dgv.Columns(columnidx).HeaderText = columnNameMap(columnidx, 0) '設定欄位顯示的名稱
            Else
                dgv.Columns.Add(columnNameMap(columnidx, 1), columnNameMap(columnidx, 0))
            End If
            '2.設定欄位顯示的名稱
            ' dgv.Columns(columnidx).HeaderText = columnNameMap(columnidx, 0)
            '3.設定欄位與dt欄位的對應
            dgv.Columns(columnidx).DataPropertyName = columnNameMap(columnidx, 1)
            '4.設定欄位顯示與否
            If columnNameMap(columnidx, 2).Trim.Equals("N") Then
                dgv.Columns(columnidx).Visible = False
            Else
                dgv.Columns(columnidx).Visible = True
            End If
            '5.設定欄位為唯讀
            If columnNameMap(columnidx, 5).Trim.Equals("N") Then
                dgv.Columns(columnidx).ReadOnly = False
            Else
                dgv.Columns(columnidx).ReadOnly = True
            End If
            '6. 設定顯示的欄位長度
            If Not columnNameMap(columnidx, 4).Trim.Equals("") Then
                dgv.Columns(columnidx).Width = CInt(columnNameMap(columnidx, 4).Trim)
            Else
                dgv.Columns(columnidx).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End If
            '7. 設定欄位的顯示格式
            If Not columnNameMap(columnidx, 3).Trim.Equals("N") Then
                Select Case columnNameMap(columnidx, 3)
                    Case "DT"   '日期&時間
                        dgv.Columns(columnidx).DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                    Case "D"    '日期
                        dgv.Columns(columnidx).DefaultCellStyle.Format = "yyyy/MM/dd"
                    Case "M"    '金額
                        dgv.Columns(columnidx).DefaultCellStyle.Format = "#,##0.##"
                        '靠右對齊
                        dgv.Columns(columnidx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'Case "NO"   '數字
                        '    dgv.Columns(i).DefaultCellStyle.Format = "0.00"
                        '    '靠右對齊
                        'Case "NO1"   '數字
                        '    dgv.Columns(i).DefaultCellStyle.Format = "0"
                        '    '靠右對齊
                        '    dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case "NO1", "NO1_L", "NO1_R"   '數字
                        dgv.Columns(columnidx).DefaultCellStyle.Format = "0.00"

                        '靠左對齊
                        If columnNameMap(columnidx, columnNameMap.GetUpperBound(1) - 1).Equals("NO1_L") Then
                            dgv.Columns(columnidx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        End If

                        '靠右對齊
                        If columnNameMap(columnidx, columnNameMap.GetUpperBound(1) - 1).Equals("NO1_R") Then
                            dgv.Columns(columnidx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                    Case "NO2", "NO2_L", "NO2_R"   '數字
                        dgv.Columns(columnidx).DefaultCellStyle.Format = "0"

                        '靠左對齊
                        If columnNameMap(columnidx, columnNameMap.GetUpperBound(1) - 1).Equals("NO2_L") Then
                            dgv.Columns(columnidx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        End If

                        '靠右對齊
                        If columnNameMap(columnidx, columnNameMap.GetUpperBound(1) - 1).Equals("NO2_R") Then
                            dgv.Columns(columnidx).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                End Select
            End If
        Next
        '增加"選"的欄位
        If checkBoxColumn Then
            Dim ckbColumn As New DataGridViewCheckBoxColumn
            ckbColumn.SortMode = DataGridViewColumnSortMode.Automatic
            dgv.Columns.Insert(0, ckbColumn)
            dgv.Columns(0).Name = "choice"
            dgv.Columns(0).HeaderText = "選"
            dgv.Columns(0).Width = 30
            dgv.Columns(0).Frozen = True
            dgv.Columns(0).ReadOnly = False
        End If
    End Sub
    ''' <summary>
    ''' 程式說明：顯示Readonly格式化過的資料在DataGridView(允許dt與columnNameMap的欄位不同)
    ''' 開發人員：Fang-Chen Hwang
    ''' 開發日期：2012.10.08
    ''' </summary>
    ''' <param name="dgv">顯示資料的DataGridView</param>
    ''' <param name="dt">欲顯示的資料</param>
    ''' <param name="columnNameMap">DataGridView欄位和資料庫欄位Mapping的Array</param>
    ''' <param name="checkBoxColumn">是否清除資料行的選取狀態</param>
    ''' <remarks></remarks>
    Public Shared Sub showReadonlyDataGridView(ByRef dgv As DataGridView, ByVal dt As DataTable, ByVal columnNameMap(,) As String, ByVal checkBoxColumn As Boolean)
        Dim rowidx As Integer, columnidx As Integer
        Try
            '----------------------------------------------------------------------------
            '#Step1. 清除資料
            '----------------------------------------------------------------------------
            dgv.Rows.Clear()
            '----------------------------------------------------------------------------
            '#Step2. Add Columns
            '---------------------------------------------------------------------------- 
            If dgv.Columns.Count = 0 Then
                addGridViewColumns(dgv, columnNameMap, checkBoxColumn)
            End If
            '----------------------------------------------------------------------------
            '#Step3.Add rows 
            '----------------------------------------------------------------------------
            For Each row In dt.Rows
                rowidx = dgv.Rows.Add()
                For columnidx = 0 To columnNameMap.GetUpperBound(0)
                    If checkBoxColumn Then
                        dgv.Rows.Item(rowidx).Cells(columnidx + 1).Value = row(columnNameMap(columnidx, 1))
                    Else
                        dgv.Rows.Item(rowidx).Cells(columnidx).Value = row(columnNameMap(columnidx, 1))
                    End If
                Next
            Next
            '----------------------------------------------------------------------------
            'Step4.清除Grid的選取行狀態
            '----------------------------------------------------------------------------
            dgv.ClearSelection()
            '----------------------------------------------------------------------------
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 關閉DockPanel的Form
    ''' </summary>
    ''' <param name="dp">DockPanel</param>
    ''' <param name="formName">表單名稱</param>
    Public Shared Sub closeDockForm(ByRef dp As DockPanel, ByVal formName As String)
        Dim formIndex As Integer = checkDockFormExistOrNot(dp, formName)

        If formIndex > -1 Then
            CType(dp.Contents(formIndex), Form).Close()
        Else
            '找不到form
        End If
    End Sub
    Public Shared Function checkDockFormExistOrNot(ByRef dp As DockPanel, ByVal formName As String) As Integer
        For iIndex As Integer = 0 To dp.Contents.Count - 1
            If CType(dp.Contents(iIndex), Form).Name = formName Then
                Return iIndex
            End If
        Next
        Return -1
    End Function
    ''' <summary>
    ''' 開啟DockPanel的Form
    ''' </summary>
    ''' <param name="dp">DockPanel</param>
    ''' <param name="formName">表單名稱</param>
    ''' 
    Public Shared Sub openDockForm(ByRef dp As DockPanel, ByVal formName As String)
        'For iIndex As Integer = 0 To dp.Contents.Count - 1
        '    If CType(dp.Contents(iIndex), Form).Name = formName Then
        '        CType(dp.Contents(iIndex), Form).
        '        Exit Sub
        '    End If
        'Next
    End Sub
#Region "20091121 健檢系統 by yaya"
    ''' <summary>
    ''' 驗證數字
    ''' </summary>
    ''' <param name="type">型態</param>
    ''' <param name="data">驗證的字串</param>
    ''' <param name="count">小數位數</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' count為取到小數第幾位，若沒有就以小數第一位為default
    ''' </remarks>
    Public Shared Function ValidateString(ByVal type As CustomerValidateType, ByVal data As String, ByVal count As Integer) As Boolean
        Try
            Dim RegularExpressions As StringBuilder = New StringBuilder
            Dim flag As Boolean = False
            If (count < 1) Then count = 1
            Select Case type
                Case CustomerValidateType.CustomerDecimal
                    '到小數點count位'
                    RegularExpressions.Append("^-?\d+(\.\d{1,").Append(count).Append("})?$")
                Case CustomerValidateType.CustomerLessOne
                    '小於1的整數取到小數count位
                    RegularExpressions.Append("^(([0]?\.\d{1,").Append(count).Append("})|([01](\.[0]*)?))$")
                Case Else
                    Throw New Exception("pattern error!")
            End Select
            If (RegularExpressions IsNot Nothing AndAlso RegularExpressions.ToString.Trim.Length > 0) Then
                flag = System.Text.RegularExpressions.Regex.IsMatch(data, RegularExpressions.ToString)
            End If
            Return flag
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ValidateString(ByVal type As ValidateType, ByVal data As String) As Boolean
        Try
            Dim RegularExpressions As String
            Dim flag As Boolean = False
            Select Case type
                Case ValidateType.Number
                    '數字格式
                    RegularExpressions = "^[0-9]*$"
                Case ValidateType.Float
                    '浮點數
                    RegularExpressions = "^(-?\\d+)(\\.\\d+)?$"
                Case ValidateType.Decimal2
                    '到小數點二位'
                    RegularExpressions = "^-?\d+(\.\d{1,2})?$"
                Case ValidateType.IP
                    'IP位址
                    RegularExpressions = "^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$"
                Case ValidateType.DateData
                    '日期格式(yyyyMMdd)(包含閏年判斷)
                    RegularExpressions = "(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})(((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)(0[1-9]|[12][0-9]|30))|(02(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))0229)"
                Case ValidateType.Time  '時間(HHmm)
                    RegularExpressions = "(0[0-9]|1[0-9]|2[0-3])(0[0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9])"
                Case Else
                    Throw New Exception("pattern error!")
            End Select
            If (RegularExpressions IsNot Nothing AndAlso RegularExpressions.ToString.Trim.Length > 0) Then
                flag = System.Text.RegularExpressions.Regex.IsMatch(data, RegularExpressions)
            End If
            Return flag
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' combobox選取的Value
    ''' </summary>
    ''' <param name="cbo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function selectedComboBoxValue(ByRef cbo As ComboBox) As String
        Try
            Dim value As String
            If (cbo.SelectedIndex > -1) Then
                If (cbo.SelectedIndex = 0) Then
                    If (TypeOf cbo.SelectedItem Is DataRowView) Then
                        Dim row As DataRowView = DirectCast(cbo.SelectedItem, DataRowView)
                        value = StringUtil.nvl(row(cbo.SelectedIndex))
                    Else
                        value = ""
                    End If
                Else
                    value = StringUtil.nvl(cbo.SelectedValue)
                End If
            Else
                value = ""
            End If
            Return value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 自動設定ComboBox下拉選單的自動寬度
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Shared Sub AutoAdjustComboBox(ByRef obj As ComboBox)
        Try
            Dim longest As Integer = AutoAdjustComboBoxWidth(obj)
            obj.DropDownWidth = longest
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 取得combobox 下拉選單的適當寬度
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AutoAdjustComboBoxWidth(ByRef obj As ComboBox) As Integer
        Try
            Dim longest As Integer = 1
            'scroll bar寬度
            Dim vertScrollBarWidth As Integer
            Dim g As Graphics = Graphics.FromImage(New Bitmap(1, 1))
            If (obj.Items.Count > obj.MaxDropDownItems) Then vertScrollBarWidth = SystemInformation.VerticalScrollBarWidth
            For Each data As DataRowView In obj.Items
                Dim width As Integer = CInt(g.MeasureString(data.Item(obj.DisplayMember).ToString, obj.Font).Width) + vertScrollBarWidth
                If (width > longest) Then longest = width
            Next
            Return longest
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得combobox 下拉選單的適當寬度
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AutoAdjustComboBoxWidth(ByRef obj As DataGridViewComboBoxColumn) As Integer
        Try
            Dim longest As Integer = 1
            'scroll bar寬度
            Dim vertScrollBarWidth As Integer
            Dim g As Graphics = Graphics.FromImage(New Bitmap(1, 1))
            If (obj.Items.Count > obj.MaxDropDownItems) Then vertScrollBarWidth = SystemInformation.VerticalScrollBarWidth
            For Each data As DataRow In DirectCast(obj.DataSource, DataTable).Rows
                Dim width As Integer = CInt(g.MeasureString(data.Item(obj.DisplayMember).ToString, obj.DefaultCellStyle.Font).Width) + vertScrollBarWidth
                If (width > longest) Then longest = width
            Next
            Return longest
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "set datasource to combobox"
    ''' <summary>
    ''' 將資料填入comboBox中
    ''' </summary>
    ''' <param name="cbo">comboBox object</param>
    ''' <param name="dt">dataTable</param>
    ''' <remarks></remarks>
    Public Shared Sub setComboBoxInfo(ByVal cbo As ComboBox, ByVal valueMenber As String, ByVal displayMember As String, _
                                ByVal dt As DataTable, ByVal IsEmptyFlag As Boolean, ByVal selectedIndex As Integer)
        Try
            If (IsEmptyFlag) Then
                cbo.DataSource = getEmptyData(dt)
            Else
                cbo.DataSource = dt
            End If

            cbo.ValueMember = valueMenber
            cbo.DisplayMember = displayMember
            cbo.DropDownWidth = AutoAdjustComboBoxWidth(cbo)
            cbo.SelectedIndex = selectedIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function getEmptyData(ByVal dt As DataTable) As DataTable
        Try
            Dim row As DataRow = dt.NewRow

            For i As Integer = 0 To dt.Columns.Count - 1
                row(i) = ""
            Next
            dt.Rows.InsertAt(row, 0)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
