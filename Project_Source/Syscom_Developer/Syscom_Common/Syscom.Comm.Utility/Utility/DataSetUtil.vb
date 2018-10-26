'/*
'*****************************************************************************
'*
'*    Page/Class Name:  DataSet 與 DataTable 產生元件
'*              Title:	DataSetUtil
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co., Ltd. , CloudMaster Co., Ltd.
'*            Company:	Syscom Computer Co,.Ltd , CloudMaster Co., Ltd.
'*            @author:	Sean.Lin
'*        Create Date:	2013-12-25
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-12-25
'*
'*****************************************************************************

Imports Microsoft.Office.Interop
Imports System.Windows.Forms
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.StringUtil
Imports System.Text

Public Class DataSetUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    '為了前端畫面暫時先加入變數
    'Public Shared ReadOnly TypeString As Integer = 1
    'Public Shared ReadOnly TypeDate As Integer = 2
    'Public Shared ReadOnly TypeDateTime As Integer = 3
    Public Shared TypeInteger As Integer = 1 'integer
    Public Shared TypeString As Integer = 2 'String
    Public Shared TypeDecimal As Integer = 3 'Decimal
    Public Shared TypeDate As Integer = 4 'Date
    Public Shared TypeDateTime As Integer = 5 'DateTime
    Public Shared TypeBoolean As Integer = 6 'Boolean



#Region " 判斷是否有資料 (由於舊系統全部都有，先暫時加入)"

    Public Overloads Shared Function IsContainsData(ByVal content As DataTable) As Boolean
        If content IsNot Nothing AndAlso content.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Shared Function IsContainsData(ByVal content As DataSet) As Boolean
        Dim isContain As Boolean = False
        If content IsNot Nothing AndAlso content.Tables.Count > 0 Then
            For i As Integer = 0 To (content.Tables.Count - 1)
                If content.Tables(i).Rows.Count > 0 Then
                    isContain = True
                End If
            Next

            Return isContain
        Else
            Return False
        End If

    End Function

#End Region

#Region " 建立 DataSet"

    ''' <summary>
    ''' 建立DataSet，傳入 TableName、ColumnsName、pkColums(PK 欄位名稱陣列)
    ''' </summary>
    ''' <param name="tableName">DataSet的Table 名稱</param>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <param name="pkColums">DataTable的 PK 欄位名稱陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-25</remarks>
    Public Overloads Shared Function GenDataSet(ByVal tableName As String, ByVal columnsName() As String, ByVal pkColums() As String) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim ds As New DataSet(tableName)
            ds.Tables.Add(GenDataTable(tableName, columnsName, pkColums))
            Return ds
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 建立DataSet，傳入 TableName、ColumnsName 
    ''' </summary>
    ''' <param name="tableName">DataSet的Table名稱</param>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-13</remarks>
    Public Overloads Shared Function GenDataSet(ByVal tableName As String, ByVal columnsName() As String) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            '2014-02-10 Sean , tableName 不可為空
            If tableName = "" Then
                tableName = "tableName"
            End If

            Dim ds As New DataSet(tableName)
            ds.Tables.Add(GenDataTable(tableName, columnsName))
            Return ds
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 建立DataSet，傳入 ColumnsName，DataTable的預設名稱為DataTable
    ''' </summary>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-25</remarks>
    Public Overloads Shared Function GenDataSet(ByVal columnsName() As String) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return GenDataSet("DataTable", columnsName)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region " 建立 DataTable"

    ''' <summary>
    ''' 建立DataTable，傳入 tableName、columnsName 陣列、pkColums(PK 欄位名稱陣列) 
    ''' </summary>
    ''' <param name="tableName">DataTable名稱</param>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <param name="pkColums">DataTable的 PK 欄位名稱陣列</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-25</remarks>
    Public Overloads Shared Function GenDataTable(ByVal tableName As String, ByVal ColumnsName() As String, ByVal pkColums() As String) As DataTable
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim dt As DataTable = New DataTable(tableName)
            Dim colName As String

            For Each colName In ColumnsName
                dt.Columns.Add(colName)
            Next

            If (pkColums IsNot Nothing AndAlso pkColums.Length > 0) Then
                Dim pkColArray(pkColums.Length) As DataColumn
                For i = 0 To pkColums.Length - 1
                    pkColArray(i) = dt.Columns(pkColums(i))
                Next
                dt.PrimaryKey = pkColArray
            End If

            Return dt
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 建立DataTable，傳入tableName、columnsName 陣列
    ''' </summary>
    ''' <param name="tableName">DataTable名稱</param>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-25</remarks>
    Public Overloads Shared Function GenDataTable(ByVal tableName As String, ByVal columnsName() As String) As DataTable
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return GenDataTable(tableName, columnsName, Nothing)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 建立DataTable，傳入columnsName 陣列，預設名稱為  DataTable
    ''' </summary>
    ''' <param name="columnsName">DataTable的欄位名稱陣列</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Copy From Syscom and Modified by Sean 2013-12-25</remarks>
    Public Overloads Shared Function GenDataTable(ByVal columnsName() As String) As DataTable
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return GenDataTable("DataTable", columnsName, Nothing)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 建立DataTable with DataType(靜態函式)
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="pkColums">DataTable的PK</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <param name="columnType">DataTable的欄位定義</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GenDataTable(ByVal dtName As String, ByVal pkColums() As String, ByVal columnsName() As String, ByVal columnType() As Integer) As DataTable
        Dim dt As DataTable = New DataTable(dtName)

        Try

            For i As Integer = 0 To (columnsName.Length - 1)
                dt.Columns.Add(columnsName(i))
            Next

            If columnType IsNot Nothing AndAlso columnsName.Length = columnType.Length Then
                For i As Integer = 0 To (columnType.Length - 1)
                    Select Case columnType(i)
                        Case TypeInteger
                            dt.Columns(columnsName(i)).DataType = GetType(System.Int32)
                        Case TypeString
                            dt.Columns(columnsName(i)).DataType = GetType(System.String)
                        Case TypeDecimal
                            dt.Columns(columnsName(i)).DataType = GetType(System.Decimal)
                        Case TypeDate
                            dt.Columns(columnsName(i)).DataType = GetType(Date)
                        Case TypeDateTime
                            dt.Columns(columnsName(i)).DataType = GetType(System.DateTime)
                        Case TypeBoolean
                            dt.Columns(columnsName(i)).DataType = GetType(System.Boolean)
                        Case Else '亂丟參數就給String型態
                            dt.Columns(columnsName(i)).DataType = GetType(System.String)
                    End Select
                Next
            End If

            If (pkColums IsNot Nothing AndAlso pkColums.Length > 0) Then
                Dim pkColArray(pkColums.Length) As DataColumn
                For i = 0 To pkColums.Length - 1
                    pkColArray(i) = dt.Columns(pkColums(i))
                Next
                dt.PrimaryKey = pkColArray
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

        Return dt
    End Function

#End Region

#Region " 將DataSet中的多筆資料列合併成ㄧ列"

    ''' <summary>
    ''' 將DataSet中pkeyIndex欄位相同的多筆資料列合併成ㄧ列，且可合併多個欄位
    ''' </summary>
    ''' <param name="dsOrg">DataSet來源名稱</param>
    ''' <param name="pkeyIndex">合併判斷條件(欄位索引陣列)</param>
    ''' <param name="mergeIndex">合併欄位名稱陣列</param>
    ''' <param name="symbol">欄位合併分隔符號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function MergeRowData(ByVal dsOrg As DataSet, ByVal pkeyIndex As Array, ByVal mergeIndex As Array, ByVal symbol As String) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim pvtRowCount As Integer
            Dim pvtCompareStr As String = ""
            Dim pvtOrginalStr As String = ""

            '新增DataSet合併後欄位名稱(因若存入原合併的欄位會有超出長度限制的錯誤)
            For p = 0 To mergeIndex.Length - 1
                dsOrg.Tables(0).Columns.Add("M_" & mergeIndex(p))
            Next

            pvtRowCount = dsOrg.Tables(0).Rows.Count - 1

            For i = 0 To pvtRowCount
                If i > pvtRowCount Then Exit For
                If i <> 0 Then
                    For j = 0 To pkeyIndex.Length - 1
                        pvtOrginalStr &= dsOrg.Tables(0).Rows(i).Item(pkeyIndex(j)).ToString.Trim
                    Next

                    'Console.WriteLine("")
                    'Console.WriteLine("來源字串=>" & i & "=>" & pvtOrginalStr)
                    'Console.WriteLine("比對字串=>" & i & "=>" & pvtCompareStr)

                    If pvtCompareStr = pvtOrginalStr Then
                        For k = 0 To mergeIndex.Length - 1
                            dsOrg.Tables(0).Rows(i - 1).Item("M_" & mergeIndex(k)) = dsOrg.Tables(0).Rows(i - 1).Item("M_" & mergeIndex(k)) & _
                                                                                     symbol & dsOrg.Tables(0).Rows(i).Item(mergeIndex(k))
                        Next

                        dsOrg.Tables(0).Rows.RemoveAt(i)
                        i -= 1
                        pvtRowCount -= 1
                    Else
                        pvtCompareStr = pvtOrginalStr

                        For k = 0 To mergeIndex.Length - 1
                            dsOrg.Tables(0).Rows(i).Item("M_" & mergeIndex(k)) = dsOrg.Tables(0).Rows(i).Item(mergeIndex(k))
                        Next
                    End If
                    pvtOrginalStr = ""
                Else
                    For j = 0 To pkeyIndex.Length - 1
                        pvtCompareStr &= dsOrg.Tables(0).Rows(i).Item(pkeyIndex(j)).ToString.Trim
                    Next

                    For k = 0 To mergeIndex.Length - 1
                        dsOrg.Tables(0).Rows(i).Item("M_" & mergeIndex(k)) = dsOrg.Tables(0).Rows(i).Item(mergeIndex(k))
                    Next
                    'Console.WriteLine("來源字串=>" & i & "=>" & pvtCompareStr)
                    'Console.WriteLine("比對字串=>" & i & "=>" & pvtOrginalStr)
                End If
            Next
            Return dsOrg
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將DataSet中pkeyIndex欄位相同的多筆資料列合併成ㄧ列，且可合併多個欄位；
    ''' 合併的列前面都加上數字，且可指定要插入的位置(請依序)
    ''' </summary>
    ''' <param name="dsOrg">DataSet來源</param>
    ''' <param name="dsTableName">要合併的Table Name</param>
    ''' <param name="pkeyIndex">合併判斷條件(欄位索引陣列)</param>
    ''' <param name="mergeIndex">合併欄位名稱陣列</param>
    ''' <param name="locationIndex">插入位置欄位陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function MergeRowDataWithNumber(ByVal dsOrg As DataSet, ByVal dsTableName As String, ByVal pkeyIndex As Array, ByVal mergeIndex As Array, ByVal locationIndex As Array) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return MergeRowDataWithNumberBase(dsOrg, dsTableName, pkeyIndex, mergeIndex, locationIndex, True)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將DataSet中pkeyIndex欄位相同的多筆資料列合併成ㄧ列，且可合併多個欄位；
    ''' 合併的列前面都加上數字，且可指定要插入的位置(請依序)，但資料之間不換行
    ''' </summary>
    ''' <param name="dsOrg">DataSet來源</param>
    ''' <param name="dsTableName">要合併的Table Name</param>
    ''' <param name="pkeyIndex">合併判斷條件(欄位索引陣列)</param>
    ''' <param name="mergeIndex">合併欄位名稱陣列</param>
    ''' <param name="locationIndex">插入位置欄位陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function MergeRowDataWithNumberWithoutvbCrLf(ByVal dsOrg As DataSet, ByVal dsTableName As Int32, ByVal pkeyIndex As Array, ByVal mergeIndex As Array, ByVal locationIndex As Array) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return MergeRowDataWithNumberBase(dsOrg, dsTableName, pkeyIndex, mergeIndex, locationIndex, False)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將DataSet中pkeyIndex欄位相同的多筆資料列合併成ㄧ列，且可合併多個欄位；
    ''' 合併的列前面都加上數字，且可指定要插入的位置(請依序)，換行記號，True: 換行，False 不換行。
    ''' </summary>
    ''' <param name="dsOrg">DataSet來源</param>
    ''' <param name="dsTableName">要合併的Table Name</param>
    ''' <param name="pkeyIndex">合併判斷條件(欄位索引陣列)</param>
    ''' <param name="mergeIndex">合併欄位名稱陣列</param>
    ''' <param name="locationIndex">插入位置欄位陣列</param>
    ''' <param name="wrapFlag" >換行記號，True: 換行，False 不換行 </param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Private Shared Function MergeRowDataWithNumberBase(ByVal dsOrg As DataSet, ByVal dsTableName As Int32, ByVal pkeyIndex As Array, ByVal mergeIndex As Array, ByVal locationIndex As Array, ByVal wrapFlag As Boolean) As DataSet
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim pvtRowCount As Integer
            Dim pvtCompareStr As String = ""
            Dim pvtOrginalStr As String = ""
            Dim int_Count_Index As Int32 = 1

            '新增DataSet合併後欄位名稱(因若存入原合併的欄位會有超出長度限制的錯誤)
            For p = 0 To mergeIndex.Length - 1
                dsOrg.Tables(dsTableName).Columns.Add("M_" & mergeIndex(p))

                '設定column的位置
                dsOrg.Tables(dsTableName).Columns.Item("M_" & mergeIndex(p)).SetOrdinal(locationIndex(p))

            Next

            pvtRowCount = dsOrg.Tables(dsTableName).Rows.Count - 1

            '組合每一個列
            For i = 0 To pvtRowCount
                If i > pvtRowCount Then Exit For
                If i <> 0 Then
                    For j = 0 To pkeyIndex.Length - 1
                        pvtOrginalStr &= dsOrg.Tables(dsTableName).Rows(i).Item(pkeyIndex(j)).ToString.Trim
                    Next

                    'Console.WriteLine("")
                    'Console.WriteLine("來源字串=>" & i & "=>" & pvtOrginalStr)
                    'Console.WriteLine("比對字串=>" & i & "=>" & pvtCompareStr)

                    '是否還是同一行
                    If pvtCompareStr = pvtOrginalStr Then

                        '為了避免迴圈一直判斷是否要加入符號，所以先判斷，故有兩個相同的迴圈，但差異只有一個換行符號
                        '加入換行符號
                        If wrapFlag Then
                            For k = 0 To mergeIndex.Length - 1
                                dsOrg.Tables(dsTableName).Rows(i - 1).Item("M_" & mergeIndex(k)) = dsOrg.Tables(dsTableName).Rows(i - 1).Item("M_" & mergeIndex(k)).ToString.Trim & _
                                                                                      vbCrLf & int_Count_Index & "." & dsOrg.Tables(dsTableName).Rows(i).Item(mergeIndex(k)).ToString.Trim
                            Next
                        Else
                            '不需換行
                            For k = 0 To mergeIndex.Length - 1
                                dsOrg.Tables(dsTableName).Rows(i - 1).Item("M_" & mergeIndex(k)) = dsOrg.Tables(dsTableName).Rows(i - 1).Item("M_" & mergeIndex(k)).ToString.Trim & _
                                                                                         int_Count_Index & "." & dsOrg.Tables(dsTableName).Rows(i).Item(mergeIndex(k)).ToString.Trim
                            Next
                        End If

                        dsOrg.Tables(dsTableName).Rows.RemoveAt(i)
                        i -= 1
                        pvtRowCount -= 1

                        int_Count_Index = int_Count_Index + 1
                        '不同行，新開一行
                    Else
                        int_Count_Index = 1
                        pvtCompareStr = pvtOrginalStr

                        For k = 0 To mergeIndex.Length - 1
                            dsOrg.Tables(dsTableName).Rows(i).Item("M_" & mergeIndex(k)) = int_Count_Index & "." & dsOrg.Tables(dsTableName).Rows(i).Item(mergeIndex(k)).ToString.Trim
                        Next

                        int_Count_Index = int_Count_Index + 1
                    End If
                    pvtOrginalStr = ""
                Else
                    int_Count_Index = 1

                    For j = 0 To pkeyIndex.Length - 1
                        pvtCompareStr &= dsOrg.Tables(dsTableName).Rows(i).Item(pkeyIndex(j)).ToString.Trim
                    Next

                    For k = 0 To mergeIndex.Length - 1
                        dsOrg.Tables(dsTableName).Rows(i).Item("M_" & mergeIndex(k)) = int_Count_Index & "." & dsOrg.Tables(dsTableName).Rows(i).Item(mergeIndex(k)).ToString.Trim
                    Next
                    'Console.WriteLine("來源字串=>" & i & "=>" & pvtCompareStr)
                    'Console.WriteLine("比對字串=>" & i & "=>" & pvtOrginalStr)

                    '開頭數字加1
                    int_Count_Index = int_Count_Index + 1
                End If
            Next
            Return dsOrg
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 分割DataTable,每個DataTable的名稱為其索引值
    ''' </summary>
    ''' <param name="dt">整個DataTable</param>
    ''' <param name="perCount">每個DataTable所要存放的資料筆數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function divideDataTable(ByRef dt As DataTable, ByVal perCount As Integer) As List(Of DataTable)
        Dim list As List(Of DataTable) = New List(Of DataTable)

        Dim totalRows As Integer = dt.Rows.Count '總筆數
        Dim divideTimes As Integer = Math.Floor(totalRows / perCount) '需分割的次數
        '分割DataTable
        Dim startIdx As Integer = 0
        Dim endIdx As Integer
        For times As Integer = 0 To divideTimes
            endIdx = ((times + 1) * perCount)
            endIdx = IIf(endIdx > totalRows, totalRows, endIdx) 'endIdx不能大於totalrows

            'Dim gridDt As DataTable = DataSetUtil.createDataTable(times, colName)
            'Dim gridDt As DataTable = New DataTable
            ''建立所有的欄位
            'For Each dc As DataColumn In dt.Columns
            '    gridDt.Columns.Add(dc.ColumnName, dc.GetType)
            'Next
            Dim gridDt As DataTable = dt.Copy
            gridDt.Clear()

            Dim rowIdx As Integer = 0 '代表該DataTable的第幾列資料
            While startIdx < endIdx
                Dim dr As DataRow = gridDt.NewRow
                '複製所有欄位的資料
                For Each dc As DataColumn In dt.Columns
                    dr(dc.ColumnName) = dt.Rows(startIdx)(dc.ColumnName)
                Next
                gridDt.Rows.Add(dr)
                startIdx = startIdx + 1
            End While
            list.Add(gridDt)
        Next

        Return list
    End Function

#Region "   匯出成Excel "

    ''' <summary> 把DataSet指定的資料表匯出成Excel </summary>
    ''' <param name="ds">資料集</param>
    ''' <param name="TableName">資料表名稱</param>
    ''' <param name="columnName">欄位名稱</param>
    ''' <remarks></remarks>
    Public Shared Sub DataSetToExcel(ByVal ds As DataSet, ByVal TableName As List(Of String), ByVal columnName As List(Of String()), Optional ByVal visibleTableName As Boolean = False)

        If ds IsNot Nothing AndAlso TableName.Count > 0 AndAlso TableName.Count = columnName.Count Then

            For j As Int16 = 0 To TableName.Count - 1

                DataTableToExcel(ds.Tables(TableName(j)), columnName(j), visibleTableName)

            Next

        End If
    End Sub

    ''' <summary> 把DataSet的第一張資料表匯出成Excel </summary>
    ''' <param name="ds">資料集</param>
    ''' <param name="columnName">欄位名稱</param>
    ''' <remarks></remarks>
    Public Shared Sub DataSetToExcel(ByVal ds As DataSet, ByVal columnName As String(), Optional ByVal visibleTableName As Boolean = False)
        If ds IsNot Nothing AndAlso ds.Tables(0) IsNot Nothing Then
            DataTableToExcel(ds.Tables(0), columnName, visibleTableName)
        End If
    End Sub

    ''' <summary> 把DataTable匯出成Excel </summary>
    ''' <param name="dt">資料表</param>
    ''' <param name="columnName">欄位名稱</param>
    ''' <remarks></remarks>
    Public Shared Sub DataTableToExcel(ByVal dt As DataTable, ByVal columnName As String(), Optional ByVal visibleTableName As Boolean = False)
        Dim xlsapp As New Excel.Application
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            xlsapp.Workbooks.Add()
            xlsapp.Visible = False
            xlsapp.Selection.Merge()
            xlsapp.Columns(3).WrapText = True '自動換行
            If visibleTableName = True Then
                Dim xlssheet As Excel.Worksheet = xlsapp.Worksheets.Item(1)
                xlssheet.Name = dt.TableName
            End If

            Dim i As Int16
            For i = 1 To dt.Columns.Count
                xlsapp.Cells(1, i) = columnName(i - 1)
            Next
            Dim rowindex As Integer = 2
            Dim colindex As Integer
            Dim col As DataColumn
            Dim row As DataRow
            Dim nxh As Integer = 1
            For Each row In dt.Rows
                colindex = 1

                For Each col In dt.Columns

                    xlsapp.Cells(rowindex, colindex) = RTrim(Convert.ToString(row(col.ColumnName)))

                    colindex += 1
                Next
                rowindex += 1
                nxh += 1
            Next

            xlsapp.Columns.AutoFit()

            xlsapp.Visible = True

        Catch cmex As CommonException
            FinishWork(xlsapp)
            Throw cmex
        Catch ex As Exception
            FinishWork(xlsapp)
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)

        End Try
    End Sub

    ''' <summary>
    ''' 關閉 Word 程式
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub FinishWork(ByRef objApp As Application)

        '回收 Word
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)

        '清除應用程式的物件
        objApp = Nothing

        '回收 memory
        GC.Collect()
    End Sub

    ''' <summary>
    ''' 關閉 Excel 程式
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub FinishWork(ByRef objApp As Excel.Application)

        '回收 Excel
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)

        '清除應用程式的物件
        objApp = Nothing

        '回收 memory
        GC.Collect()
    End Sub

#End Region

#Region "   匯出CSV 字串"


    ''' <summary>
    ''' 程式說明：取得DataTable內的所有Content，回傳For Csv字串
    ''' 開發人員：Charles
    ''' 開發日期：2013.07.02
    ''' </summary>
    ''' <param name="SourceDt">來源資料表</param>
    ''' <param name="ISstringFlag">文字型態輸出:true: ="內容",False :  內容</param>
    ''' <returns>Str</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDataTableContentForCsv(ByVal SourceDt As DataTable, Optional ByVal ISstringFlag As Boolean = True) As String
        Try
            Dim RtnStr As New StringBuilder

            If DataSetUtil.IsContainsData(SourceDt) Then

                For RIndex As Integer = 0 To SourceDt.Rows.Count - 1


                    RtnStr.AppendLine(GetRowContentForCsv(SourceDt.Rows(RIndex), ISstringFlag))

                Next

            End If

            Return RtnStr.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得DataRow內的所有Content，回傳For Csv字串
    ''' 開發人員：Charles
    ''' 開發日期：2013.07.02
    ''' </summary>
    ''' <param name="SourceRow">來源資料列</param>
    ''' <param name="ISstringFlag">文字型態輸出:true: ="內容",False :  內容</param>
    ''' <returns>Str</returns>
    ''' <remarks></remarks>
    Public Shared Function GetRowContentForCsv(ByVal SourceRow As DataRow, Optional ByVal ISstringFlag As Boolean = True) As String
        Try
            Dim RtnStr As New StringBuilder

            If SourceRow IsNot Nothing Then

                'strOut.Append("=" & """" & su.nvl(dataDr("案")) & """")
                'strOut.Append(",").Append("=" & """" & su.nvl(dataDr("科")) & """")
                'strOut.Append(",").Append("=" & """" & su.nvl(dataDr("病歷號")) & """")
                'strOut.Append(",").Append("=" & """" & su.nvl(dataDr("住院號")) & """")
                For iIndex As Integer = 0 To SourceRow.Table.Columns.Count - 1
                    If iIndex > 0 Then
                        RtnStr.Append(",")
                    End If


                    If ISstringFlag Then

                        If SourceRow.Table.Columns(iIndex).DataType Is GetType(DateTime) Then

                            If nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName)).Contains("""") Then

                            End If

                            If Not "".Equals(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName))) Then
                                RtnStr.Append("=" & """" & CDate(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName))).ToShortDateString & """")
                            Else
                                RtnStr.Append("=" & """" & nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName)) & """")
                            End If

                        Else
                            RtnStr.Append("=" & """" & nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName)) & """")
                        End If
                    Else

                        If SourceRow.Table.Columns(iIndex).DataType Is GetType(DateTime) Then

                            If Not "".Equals(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName))) Then
                                RtnStr.Append(CDate(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName))).ToShortDateString)
                            Else
                                RtnStr.Append(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName)))
                            End If

                        Else
                            RtnStr.Append(nvl(SourceRow(SourceRow.Table.Columns(iIndex).ColumnName)))
                        End If
                    End If



                Next

            End If

            Return RtnStr.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


    ''' <summary>
    ''' 檢查Table是否存在於DataSet
    ''' </summary>
    ''' <param name="ds">DataSet</param>
    ''' <param name="dtName">Table Name</param>
    ''' <param name="checkIncludeDataFlag">包含檢查資料與否</param>
    ''' <param name="checkColumnExistOrNotFlag">包含檢查欄位與否</param>
    ''' <returns></returns>
    Public Shared Function CheckTableExistOrNot(ByVal ds As DataSet, ByVal dtName As String, ByVal checkIncludeDataFlag As Boolean, Optional ByVal checkColumnExistOrNotFlag As Boolean = False, Optional ByVal columnName() As String = Nothing) As Boolean
        If ds Is Nothing Then
            Return False
        Else
            If ds.Tables.Count.Equals(0) Then
                Return False
            Else
                If ds.Tables.Contains(dtName) Then

                    If checkColumnExistOrNotFlag Then
                        Dim chkResult As Boolean = CheckColumnExistOrNot(ds.Tables(dtName), columnName, checkIncludeDataFlag)

                        If Not chkResult Then
                            Return chkResult
                        End If
                    End If

                    If checkIncludeDataFlag Then
                        Return IsContainsData(ds.Tables(dtName))
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If
            End If
        End If
    End Function

    ''' <summary>
    ''' 檢查欄位是否存在於Table
    ''' </summary>
    ''' <param name="dt">Table</param>
    ''' <param name="columnName">欄位資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckColumnExistOrNot(ByVal dt As DataTable, ByVal columnName() As String, ByVal checkIncludeDataFlag As Boolean) As Boolean
        If dt Is Nothing Then
            Return False
        Else
            If checkIncludeDataFlag Then
                If Not IsContainsData(dt) Then
                    Return False
                End If
            End If

            If columnName Is Nothing Then
                Return False
            Else
                If dt.Columns.Count >= columnName.Length Then
                    For iIndex As Integer = 0 To columnName.Length - 1
                        Try
                            Dim tempStr As String = dt.Columns(columnName(iIndex)).ColumnName
                        Catch ex As Exception
                            Return False
                        End Try
                    Next

                    Return True
                Else
                    Return False
                End If
            End If
        End If
    End Function

#Region "   createDataTable for EFS"
    ''' <summary>
    ''' 建立只有一個DataTable的DataSet
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <param name="columnsName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function createDataSet(ByVal TableName As String, ByVal columnsName() As String) As DataSet
        Dim ds As New DataSet(TableName)
        Try
            ds.Tables.Add(createDataTable(TableName, columnsName))

        Catch ex As Exception
            Throw ex
        Finally
            ds.Dispose()
        End Try
        Return ds
    End Function
    ''' <summary>
    ''' 建立只有一個DataTable的DataSet,DataSet的預設名稱為"DataSet"
    ''' </summary>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function createDataSet(ByVal columnsName() As String) As DataSet
        Return createDataSet("DataSet", columnsName)
    End Function
    ''' <summary>
    ''' 建立DataTable
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="pkColums">DataTable的PK</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Overloads Function createDataTable(ByVal dtName As String, ByVal pkColums() As String, ByVal columnsName() As String) As DataTable
        Dim dt As DataTable = New DataTable(dtName)
        Try
            Dim colName As String

            For Each colName In columnsName
                dt.Columns.Add(colName)
            Next

            If (pkColums IsNot Nothing AndAlso pkColums.Length > 0) Then
                Dim pkColArray(pkColums.Length) As DataColumn
                For i = 0 To pkColums.Length - 1
                    pkColArray(i) = dt.Columns(pkColums(i))
                Next
                dt.PrimaryKey = pkColArray
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' 建立DataTable,預設名稱為"DataTable"
    ''' </summary>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function createDataTable(ByVal columnsName() As String) As DataTable
        Return createDataTable("DataTable", Nothing, columnsName, Nothing)
    End Function
    ''' <summary>
    ''' 建立DataTable
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function createDataTable(ByVal dtName As String, ByVal columnsName() As String) As DataTable
        Return createDataTable(dtName, Nothing, columnsName, Nothing)
    End Function
    Public Overloads Shared Function createDataTable(ByVal columnsName() As String, ByVal columnsValue() As String) As DataTable
        Dim arr As String(,) = New String(0, columnsValue.GetLength(0) - 1) {} '建立一個二為陣列
        For colIdx As Integer = 0 To columnsValue.GetLength(0) - 1
            arr(0, colIdx) = columnsValue(colIdx)
        Next
        Return createDataTable("DataTable", columnsName, arr)
    End Function
    Public Overloads Shared Function createDataTable(ByVal columnsName() As String, ByVal columnsValue()() As String) As DataTable
        Return createDataTable("DataTable", columnsName, columnsValue)
    End Function
    Public Overloads Shared Function createDataTable(ByVal columnsName() As String, ByVal columnsValue(,) As String) As DataTable
        Return createDataTable("DataTable", columnsName, columnsValue)
    End Function
    ''' <summary>
    ''' 建立DataTable與使用不規則二元陣列的值
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <param name="columnsValue">DataTable的資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function createDataTable(ByVal dtName As String, ByVal columnsName() As String, ByVal columnsValue()() As String) As DataTable
        Dim dt As DataTable = createDataTable(dtName, columnsName)
        For Each row() As String In columnsValue
            Dim cols() As String = New String(row.Length - 1) {}
            For colIdx As Integer = 0 To row.Length - 1
                cols(colIdx) = row(colIdx)
            Next
            dt.Rows.Add(cols)
        Next
        Return dt
    End Function
    ''' <summary>
    ''' 建立DataTable與規則二元陣列的值
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <param name="columnsValue">DataTable的資料</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function createDataTable(ByVal dtName As String, ByVal columnsName() As String, ByVal columnsValue(,) As String) As DataTable
        Dim dt As DataTable = createDataTable(dtName, columnsName)

        For rowIdx As Integer = 0 To columnsValue.GetLength(0) - 1
            Dim cols() As String = New String(columnsValue.GetLength(1) - 1) {}
            For colIdx As Integer = 0 To columnsValue.GetLength(1) - 1
                cols(colIdx) = columnsValue(rowIdx, colIdx)
            Next
            dt.Rows.Add(cols)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 建立DataTable with DataType(靜態函式)
    ''' </summary>
    ''' <param name="dtName">DataTable名稱</param>
    ''' <param name="pkColums">DataTable的PK</param>
    ''' <param name="columnsName">DataTable的欄位</param>
    ''' <param name="columnType">DataTable的欄位定義</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function createDataTable(ByVal dtName As String, ByVal pkColums() As String, ByVal columnsName() As String, ByVal columnType() As Integer) As DataTable
        Dim dt As DataTable = New DataTable(dtName)

        Try

            For i As Integer = 0 To (columnsName.Length - 1)
                dt.Columns.Add(columnsName(i))
            Next

            If columnType IsNot Nothing AndAlso columnsName.Length = columnType.Length Then
                For i As Integer = 0 To (columnType.Length - 1)
                    Select Case columnType(i)
                        Case TypeInteger
                            dt.Columns(columnsName(i)).DataType = GetType(System.Int32)
                        Case TypeString
                            dt.Columns(columnsName(i)).DataType = GetType(System.String)
                        Case TypeDecimal
                            dt.Columns(columnsName(i)).DataType = GetType(System.Decimal)
                        Case TypeDate
                            dt.Columns(columnsName(i)).DataType = GetType(Date)
                        Case TypeDateTime
                            dt.Columns(columnsName(i)).DataType = GetType(System.DateTime)
                        Case TypeBoolean
                            dt.Columns(columnsName(i)).DataType = GetType(System.Boolean)
                        Case Else '亂丟參數就給String型態
                            dt.Columns(columnsName(i)).DataType = GetType(System.String)
                    End Select
                Next
            End If

            If (pkColums IsNot Nothing AndAlso pkColums.Length > 0) Then
                Dim pkColArray(pkColums.Length) As DataColumn
                For i = 0 To pkColums.Length - 1
                    pkColArray(i) = dt.Columns(pkColums(i))
                Next
                dt.PrimaryKey = pkColArray
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

        Return dt
    End Function
    ''' <summary>
    ''' 依照傳入的DataTable建立新的DataSet物件
    ''' 因為和CNC的名稱重複,故改成genDs
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dsName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function genDs(ByVal dt As DataTable, Optional ByVal dsName As String = "dsName") As DataSet
        Dim ds As DataSet = New DataSet(dsName)
        ds.Tables.Add(dt.Copy)
        Return ds
    End Function
    ''' <summary>
    ''' 顯示DataTable
    ''' </summary>
    ''' <param name="table">DataTable</param>    
    ''' <remarks></remarks>
    Public Shared Sub displayDataTable(ByVal table As DataTable)
        If Not table Is Nothing Then
            For Each col As DataColumn In table.Columns
                Console.Write(col.ColumnName & "(" & col.DataType.FullName & "),")
            Next
            Console.WriteLine("")
            Dim i As Integer = 0
            For Each row As DataRow In table.Rows
                i += 1
                Console.WriteLine("row:" & i)
                For Each obj As Object In row.ItemArray
                    Console.Write(obj.ToString & ",")
                Next
            Next
        End If
    End Sub


    ''' <summary>
    ''' 取得原DataSet中某一列資料，並複製到另一個新的DataSet
    ''' </summary>
    ''' <param name="Originalds">原DataSet</param>
    ''' <param name="TableIndex">表格Index</param>
    ''' <param name="RowIndex">資料列Index</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function cloneRowDataSet(ByVal Originalds As DataSet, ByVal TableIndex As Integer, ByVal RowIndex As Integer) As DataSet
        Dim Tempds As New DataSet
        Try
            '複製原始表格結構至Tempds
            Tempds.Tables.Add(Originalds.Tables(TableIndex).Clone)

            '取出原始表格資料列並複製到Tempds
            Tempds.Tables(0).Rows.Add(Originalds.Tables(TableIndex).Rows(RowIndex).ItemArray)

        Catch ex As Exception
            Throw ex
        Finally
            Tempds.Dispose()
        End Try
        Return Tempds
    End Function


    ''' <summary>
    ''' Sort Dataset
    ''' </summary>
    ''' <param name="Originalds">原DataSet</param>
    ''' <param name="TableIndex">表格Index</param>
    ''' <param name="ColumnIndex">資料行Index</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function SortDataSet(ByVal Originalds As DataSet, ByVal TableIndex As Integer, ByVal ColumnIndex As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If ColumnIndex >= 0 AndAlso ColumnIndex <= Originalds.Tables(TableIndex).Columns.Count - 1 Then
                Dim view As DataView
                view = Originalds.Tables(TableIndex).DefaultView
                view.Sort = Originalds.Tables(TableIndex).Columns(ColumnIndex).ColumnName

                ds.Tables.Add(view.ToTable.Copy)

            End If
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            ds.Dispose()
        End Try

    End Function

    ''' <summary>
    ''' 將DataSet中PKeyIndex欄位相同的多筆資料列合併成ㄧ列，且可合併多個欄位
    ''' 合併的列前面都加上數字，且可指定要插入的位置(請依序)
    ''' </summary>
    ''' <param name="orgDS">DataSet來源名稱</param>
    ''' <param name="PKeyIndex">合併判斷條件(欄位索引陣列)</param>
    ''' <param name="MergeIndex">合併欄位名稱陣列</param>
    ''' <param name="LocationIndex">插入位置欄位陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Shared Function MergeRowDataWithNumber(ByVal orgDS As DataSet, ByVal DS_Table_Index As Int32, ByVal PKeyIndex As Array, ByVal MergeIndex As Array, ByVal LocationIndex As Array) As DataSet

        Dim pvtRowCount As Integer
        Dim pvtCompareStr As String = ""
        Dim pvtOrginalStr As String = ""
        Dim int_Count_Index As Int32 = 1

        '新增DataSet合併後欄位名稱(因若存入原合併的欄位會有超出長度限制的錯誤)
        For p = 0 To MergeIndex.Length - 1
            orgDS.Tables(DS_Table_Index).Columns.Add("M_" & MergeIndex(p))

            '設定column的位置
            orgDS.Tables(DS_Table_Index).Columns.Item("M_" & MergeIndex(p)).SetOrdinal(LocationIndex(p))

        Next

        pvtRowCount = orgDS.Tables(DS_Table_Index).Rows.Count - 1

        For i = 0 To pvtRowCount

            If i > pvtRowCount Then Exit For

            If i <> 0 Then

                For j = 0 To PKeyIndex.Length - 1
                    pvtOrginalStr &= orgDS.Tables(DS_Table_Index).Rows(i).Item(PKeyIndex(j)).ToString.Trim
                Next

                'Console.WriteLine("")
                'Console.WriteLine("來源字串=>" & i & "=>" & pvtOrginalStr)
                'Console.WriteLine("比對字串=>" & i & "=>" & pvtCompareStr)


                If pvtCompareStr = pvtOrginalStr Then

                    For k = 0 To MergeIndex.Length - 1
                        orgDS.Tables(DS_Table_Index).Rows(i - 1).Item("M_" & MergeIndex(k)) = orgDS.Tables(DS_Table_Index).Rows(i - 1).Item("M_" & MergeIndex(k)).ToString.Trim & _
                                                                                  vbCrLf & int_Count_Index & "." & orgDS.Tables(DS_Table_Index).Rows(i).Item(MergeIndex(k)).ToString.Trim
                    Next

                    orgDS.Tables(DS_Table_Index).Rows.RemoveAt(i)
                    i -= 1
                    pvtRowCount -= 1

                    int_Count_Index = int_Count_Index + 1

                Else

                    int_Count_Index = 1

                    pvtCompareStr = pvtOrginalStr


                    For k = 0 To MergeIndex.Length - 1
                        orgDS.Tables(DS_Table_Index).Rows(i).Item("M_" & MergeIndex(k)) = int_Count_Index & "." & orgDS.Tables(DS_Table_Index).Rows(i).Item(MergeIndex(k)).ToString.Trim
                    Next

                    int_Count_Index = int_Count_Index + 1

                End If

                pvtOrginalStr = ""

            Else
                int_Count_Index = 1

                For j = 0 To PKeyIndex.Length - 1
                    pvtCompareStr &= orgDS.Tables(DS_Table_Index).Rows(i).Item(PKeyIndex(j)).ToString.Trim
                Next

                For k = 0 To MergeIndex.Length - 1
                    orgDS.Tables(DS_Table_Index).Rows(i).Item("M_" & MergeIndex(k)) = int_Count_Index & "." & orgDS.Tables(DS_Table_Index).Rows(i).Item(MergeIndex(k)).ToString.Trim
                Next
                'Console.WriteLine("來源字串=>" & i & "=>" & pvtCompareStr)
                'Console.WriteLine("比對字串=>" & i & "=>" & pvtOrginalStr)

                '開頭數字加1
                int_Count_Index = int_Count_Index + 1

            End If

        Next

        '新增DataSet合併後欄位名稱(因若存入原合併的欄位會有超出長度限制的錯誤)
        'For p = 0 To MergeIndex.Length - 1
        '    'orgDS.Tables(DS_Table_Index).Columns.Add()

        '    '設定column的位置
        '    orgDS.Tables(DS_Table_Index).Columns.Item("M_" & MergeIndex(p)).SetOrdinal(LocationIndex(p))

        'Next

        Return orgDS

    End Function


    ''' <summary>
    ''' 檢查dt1與dt2的欄位資料是否相同,chkCols若有輸入則是代表指檢查這些欄位,若沒輸入則表示檢察dt1的所有欄位
    ''' 要注意dt1與dt2的欄位要完全相同,否則視為不同
    ''' </summary>
    ''' <param name="dt1"></param>
    ''' <param name="dt2"></param>
    ''' <param name="chkCols"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isSameDataTable(ByVal dt1 As DataTable, ByVal dt2 As DataTable, Optional ByVal chkCols As String() = Nothing) As Boolean

        If dt1.Columns.Count <> dt2.Columns.Count Then '檢查兩個DataTable的欄位數是否一樣
            Return False
        End If

        If dt1.Rows.Count <> dt2.Rows.Count Then '檢查兩個DataTable的筆數是否一樣
            Return False
        End If

        Dim data1 As New HashSet(Of String)
        Dim data2 As New HashSet(Of String)
        Dim allColData1 As String = ""
        Dim allColData2 As String = ""
        '組出所有需要檢查欄位的資料
        If chkCols Is Nothing Then
            For i As Integer = 0 To dt1.Rows.Count - 1
                allColData1 = ""
                allColData2 = ""
                For Each dc As DataColumn In dt1.Columns
                    allColData1 = allColData1 + "|" + nvl(dt1.Rows(i).Item(dc.ColumnName))
                    allColData2 = allColData2 + "|" + nvl(dt2.Rows(i).Item(dc.ColumnName))
                Next
                data1.Add(allColData1)
                data2.Add(allColData2)
            Next

        Else
            For i As Integer = 0 To dt1.Rows.Count - 1
                allColData1 = ""
                allColData2 = ""
                For Each dc As String In chkCols
                    allColData1 = allColData1 + "|" + nvl(dt1.Rows(i).Item(dc))
                    allColData2 = allColData2 + "|" + nvl(dt2.Rows(i).Item(dc))
                Next
                data1.Add(allColData1)
                data2.Add(allColData2)
            Next

        End If

        '檢查所有資料是否都一樣
        For i As Integer = 0 To data1.Count - 1
            If Not data2.Contains(data1.ElementAt(i)) Then
                Return False
            End If
        Next

        Return True
    End Function

#End Region

End Class
