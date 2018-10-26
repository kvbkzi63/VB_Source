
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.EXP
Imports System.ServiceModel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports Syscom.Comm.BASE

'Imports System.Data
'Imports Microsoft.Office.Interop.Excel


Public Class CmmMethodUtil

    Private Shared _PubServiceManager As IPubServiceManager = PubServiceManager.getInstance
    Private Shared _CMMServiceManager As ICmmServiceManager = CmmServiceManager.getInstance

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

#End Region

#Region "2015/08/18 取得APP 伺服器系統日期時間 By Lits"


#Region "取得APP 伺服器系統日期時間 "

    ''' <summary>
    ''' 從Client端取得後端APP 伺服器系統日期時間
    ''' </summary>
    ''' <returns>日期格式 </returns>
    ''' <remarks></remarks>
    Public Shared Function getApServerSystemNow() As DateTime
        Try
            Return _PubServiceManager.getApServerSystemDateTime
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP 伺服器系統日期時間"})
        End Try
    End Function

#End Region

#Region "取得APP 伺服器系統日期時間；日期格式yyyy/MM/dd "

    ''' <summary>
    ''' 從Client端取得後端APP 伺服器系統日期；日期格式yyyy/MM/dd
    ''' </summary>
    ''' <returns>日期格式yyyy/MM/dd String </returns>
    ''' <remarks></remarks>
    Public Shared Function getApServerSystemDate() As String
        Try
            Return _PubServiceManager.getApServerSystemDateTime.ToString(Syscom.Comm.Utility.DateUtil.DateTypeSlash)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd"})
        End Try
    End Function

#End Region

#Region "取得APP 伺服器系統日期時間；日期格式yyyy/MM/dd HH:mm "
    ''' <summary>
    ''' 從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm
    ''' </summary>
    ''' <returns>日期時間格式yyyy/MM/dd HH:mm String</returns>
    ''' <remarks></remarks>
    Public Shared Function getApServerSystemDateTimeMinute() As String
        Try
            Return _PubServiceManager.getApServerSystemDateTime.ToString(Syscom.Comm.Utility.DateUtil.DateTimeMinuteTypeSlash)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm"})
        End Try


    End Function
#End Region

#Region "取得APP 伺服器系統日期時間；日期格式yyyy/MM/dd HH:mm:ss"
    ''' <summary>
    ''' 從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm:ss
    ''' </summary>
    ''' <returns>日期時間格式yyyy/MM/dd HH:mm:ss String</returns>
    ''' <remarks></remarks>
    Public Shared Function getApServerSystemDateTime() As String
        Try
            Return _PubServiceManager.getApServerSystemDateTime.ToString(Syscom.Comm.Utility.DateUtil.DateTimeTypeSlash)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm:ss"})
        End Try


    End Function
#End Region

#Region "取得APP 伺服器系統日期時間；日期格式yyyy/MM/dd HH:mm:ss.fff "
    ''' <summary>
    ''' 從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm:ss.fff
    ''' </summary>
    ''' <returns>日期時間格式yyyy/MM/dd HH:mm:ss.ss String</returns>
    ''' <remarks></remarks>
    Public Shared Function getApServerSystemFullDateTime() As String
        Try
            Return _PubServiceManager.getApServerSystemDateTime.ToString(Syscom.Comm.Utility.DateUtil.DateTimeFullTypeSlash)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP 伺服器系統日期時間；日期時間格式yyyy/MM/dd HH:mm:ss.fff"})
        End Try

    End Function
#End Region





#End Region

#Region "查詢參數檔 - 多筆"
    Public Shared Function CMMSysCodeQueryPubConfigMuti(ByVal configName As String()) As DataSet
        Try
            Return _CMMServiceManager.CMMSysCodeQueryPubConfigMuti(configName)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從Client端取得後端APP Pub_Config"})
        End Try

    End Function
#End Region

#Region "　　匯出Excel"

#Region "　　匯出Excel"

    ''' <summary> 
    ''' 把Data匯出成Excel，包含天地
    ''' </summary>
    ''' <param name="dtPrint">資料表</param>
    ''' <param name="columnName">欄位名稱，nothing 則直接使用ds 的Column </param>
    ''' <param name="columnWidth">設定資料的寬度，nothing 則使用Auto Header 的Size，如果要用預設的則丟空字串，EX: "0,1,,,,,10"</param>
    ''' <param name="reportName">報表名稱</param>
    ''' <param name="reportId">報表 ID </param>
    ''' <param name="wrapFlag">折行；True:折行；False:不折行</param>
    ''' <remarks>copy from  Will.Lin,Modified by Sean.Lin on 2015-10-15</remarks>
    Public Shared Sub DataToExcelWithFormate(ByVal dtPrint As DataTable, ByVal columnName As String(), ByVal columnWidth As String(), ByVal reportName As String, ByVal reportId As String, ByVal wrapFlag As Boolean)
        Dim eventMgr As EventManager = Nothing

        Try

            If CheckMethodUtil.CheckIsNothing(dtPrint) Then

                '設定 EventMgr
                eventMgr = EventManager.getInstance()

                Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

                Dim RowIndex As Integer = 1
                '----------------------------------------------------------------------------
                '#Step1.Create Excel物件
                '----------------------------------------------------------------------------
                'On Error Resume Next
                Try
                    xlApp = New Microsoft.Office.Interop.Excel.Application
                Catch ex As Exception
                    '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
                    If Err.Number() <> 0 Then Err.Clear()

                    '執行一個新的Excel Application            
                    xlApp = CreateObject("Excel.Application")

                    If Err.Number() <> 0 Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"電腦沒有安裝Excel!"}, "")
                        Exit Sub
                    End If
                End Try
                '--------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step2.匯出DataSet的資料到Excel
                '----------------------------------------------------------------------------
                eventMgr.RaiseUclWaitingForm("WaitingStart", "匯出檔案中，請稍後‧‧‧")

                Try
                    '取得表頭欄位名稱陣列
                    'Dim columnName As String() = gblColumnNameExcelTitle.Split(",")

                    xlApp.Visible = False

                    '開新活頁簿
                    xlBook = xlApp.Workbooks.Add
                    '設定活頁簿為焦點
                    xlBook.Activate()
                    '選取第1張活頁簿
                    xlSheet = xlBook.Worksheets(1)

                    '設定字型(前4行為表單資訊)
                    xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).Font.Name = "標楷體"
                    xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    '判斷有無表頭，沒有的話，用dt本身資料取代
                    If columnName Is Nothing Then
                        Dim columnStr As String = ""
                        For i As Integer = 0 To dtPrint.Columns.Count - 1
                            columnStr += dtPrint.Columns(i).ColumnName & ","
                        Next
                        If columnStr.LastIndexOf(",") = columnStr.Length - 1 Then
                            columnStr = columnStr.Substring(0, columnStr.Length - 1)
                        End If
                        columnName = columnStr.Split(",")
                    End If

                    '開始列印表頭部分資訊
                    'PrintHeadFont(reportName, reportId, xlSheet, dtPrint, columnName, RowIndex)

                    '2015/11/30 使用新版拆開的 列印方式
                    '開始列印表頭部分資訊
                    PrintPageHeader(reportName, reportId, xlSheet, dtPrint, columnName, RowIndex)


                    '開始列印表格 Header 部分資訊
                    RowIndex = PrintColumnHeader(xlSheet, dtPrint, columnName, columnWidth, RowIndex)
                    '填入表身資料
                    RowIndex = PrintdtBody(xlApp, xlSheet, dtPrint, columnName, RowIndex, wrapFlag)

                    ''填入表身資料
                    'For iRow As Integer = 0 To dtPrint.Rows.Count - 1
                    '    xlSheet.Range(xlSheet.Cells(iRow + RowIndex, 1), xlSheet.Cells(iRow + RowIndex, dtPrint.Columns.Count)).Value = dtPrint.Rows(iRow).ItemArray
                    'Next
                    ''畫下框線
                    'xlSheet.Range(xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
                    'xlSheet.Range(xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).Weight = 2

                    ''儲存Excel
                    'xlBook.SaveAs(filePath)
                    xlApp.Visible = True


                Catch ex As Exception
                    ClientExceptionHandler.ProccessException(ex)
                Finally

                    eventMgr.RaiseUclWaitingForm("WaitingEnd", "")

                    '回收Excel
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                    If xlApp IsNot Nothing Then xlApp = Nothing
                    If xlBook IsNot Nothing Then xlBook = Nothing
                    If xlSheet IsNot Nothing Then xlSheet = Nothing
                    If xlRange IsNot Nothing Then xlRange = Nothing
                    'GC.Collect()
                End Try

            Else

                MessageHandling.ShowWarnMsg("CMMCMMB300", "列印的資料 DataTable 不存在!")

            End If

        Catch cmex As CommonException
            ' FinishWork(xlsapp)
            Throw cmex
        Catch ex As Exception
            'FinishWork(xlsapp)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If Not eventMgr Is Nothing Then
                eventMgr = Nothing
            End If
        End Try
    End Sub

    ''' <summary> 
    ''' 把Data匯出成Excel，包含天地
    ''' </summary>
    ''' <param name="dtPrint">資料表</param>
    ''' <param name="columnName">欄位名稱，nothing 則直接使用ds 的Column </param>
    ''' <param name="columnWidth">設定資料的寬度，nothing 則使用Auto Header 的Size，如果要用預設的則丟空字串，EX: "0,1,,,,,10"</param>
    ''' <param name="reportName">報表名稱</param>
    ''' <param name="reportId">報表 ID </param>
    ''' <param name="wrapFlag">折行；True:折行；False:不折行</param>
    ''' <remarks>add by qun,2017/3/10,excel欄位寬度完全按照參數傳入設置</remarks>
    Public Shared Sub DataToExcelWithFormateSetColumWidth(ByVal dtPrint As DataTable, ByVal columnName As String(), ByVal columnWidth As String(), ByVal reportName As String, ByVal reportId As String, ByVal wrapFlag As Boolean)
        Dim eventMgr As EventManager = Nothing

        Try

            If CheckMethodUtil.CheckIsNothing(dtPrint) Then

                '設定 EventMgr
                eventMgr = EventManager.getInstance()

                Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

                Dim RowIndex As Integer = 1
                '----------------------------------------------------------------------------
                '#Step1.Create Excel物件
                '----------------------------------------------------------------------------
                'On Error Resume Next
                Try
                    xlApp = New Microsoft.Office.Interop.Excel.Application
                Catch ex As Exception
                    '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
                    If Err.Number() <> 0 Then Err.Clear()

                    '執行一個新的Excel Application            
                    xlApp = CreateObject("Excel.Application")

                    If Err.Number() <> 0 Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"電腦沒有安裝Excel!"}, "")
                        Exit Sub
                    End If
                End Try
                '--------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step2.匯出DataSet的資料到Excel
                '----------------------------------------------------------------------------
                eventMgr.RaiseUclWaitingForm("WaitingStart", "匯出檔案中，請稍後‧‧‧")

                Try
                    '取得表頭欄位名稱陣列
                    'Dim columnName As String() = gblColumnNameExcelTitle.Split(",")

                    xlApp.Visible = False

                    '開新活頁簿
                    xlBook = xlApp.Workbooks.Add
                    '設定活頁簿為焦點
                    xlBook.Activate()
                    '選取第1張活頁簿
                    xlSheet = xlBook.Worksheets(1)

                    '設定字型(前4行為表單資訊)
                    xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).Font.Name = "標楷體"
                    xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(dtPrint.Rows.Count + 4, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    '判斷有無表頭，沒有的話，用dt本身資料取代
                    If columnName Is Nothing Then
                        Dim columnStr As String = ""
                        For i As Integer = 0 To dtPrint.Columns.Count - 1
                            columnStr += dtPrint.Columns(i).ColumnName & ","
                        Next
                        If columnStr.LastIndexOf(",") = columnStr.Length - 1 Then
                            columnStr = columnStr.Substring(0, columnStr.Length - 1)
                        End If
                        columnName = columnStr.Split(",")
                    End If

                    '開始列印表頭部分資訊
                    'PrintHeadFont(reportName, reportId, xlSheet, dtPrint, columnName, RowIndex)

                    '2015/11/30 使用新版拆開的 列印方式
                    '開始列印表頭部分資訊
                    PrintPageHeader(reportName, reportId, xlSheet, dtPrint, columnName, RowIndex)


                    '開始列印表格 Header 部分資訊
                    RowIndex = PrintColumnHeaderSetColumWidth(xlSheet, dtPrint, columnName, columnWidth, RowIndex)
                    '填入表身資料
                    RowIndex = PrintdtBody(xlApp, xlSheet, dtPrint, columnName, RowIndex, wrapFlag)

                    ''填入表身資料
                    'For iRow As Integer = 0 To dtPrint.Rows.Count - 1
                    '    xlSheet.Range(xlSheet.Cells(iRow + RowIndex, 1), xlSheet.Cells(iRow + RowIndex, dtPrint.Columns.Count)).Value = dtPrint.Rows(iRow).ItemArray
                    'Next
                    ''畫下框線
                    'xlSheet.Range(xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
                    'xlSheet.Range(xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).Weight = 2

                    ''儲存Excel
                    'xlBook.SaveAs(filePath)
                    xlApp.Visible = True


                Catch ex As Exception
                    ClientExceptionHandler.ProccessException(ex)
                Finally

                    eventMgr.RaiseUclWaitingForm("WaitingEnd", "")

                    '回收Excel
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                    If xlApp IsNot Nothing Then xlApp = Nothing
                    If xlBook IsNot Nothing Then xlBook = Nothing
                    If xlSheet IsNot Nothing Then xlSheet = Nothing
                    If xlRange IsNot Nothing Then xlRange = Nothing
                    'GC.Collect()
                End Try

            Else

                MessageHandling.ShowWarnMsg("CMMCMMB300", "列印的資料 DataTable 不存在!")

            End If

        Catch cmex As CommonException
            ' FinishWork(xlsapp)
            Throw cmex
        Catch ex As Exception
            'FinishWork(xlsapp)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If Not eventMgr Is Nothing Then
                eventMgr = Nothing
            End If
        End Try
    End Sub
#End Region

#Region "　　匯出Excel - 單一表單，多個Table 列印在一頁"

    ''' <summary> 
    ''' 把Data匯出成Excel，包含天地，列印DS 裡面 TableName 所有的資料
    ''' 
    '''  單一表單，多個Table 列印在一頁
    ''' </summary>
    ''' <param name="dsPrint">資料集</param> 
    ''' <param name="columnNameList">欄位名稱，nothing 則直接使用ds 的Column </param>
    ''' <param name="reportName">報表名稱</param>
    ''' <param name="reportId">報表 ID </param>
    ''' <remarks>copy from  Will.Lin,Modified by Sean.Lin on 2015-10-15</remarks>
    Public Shared Sub DataToExcelWithFormate(ByVal dsPrint As DataSet, ByVal columnNameList As List(Of String()), ByVal reportName As String, ByVal reportId As String, ByVal wrapFlag As Boolean, Optional ByVal VisibleTableName As Boolean = False)
        Dim eventMgr As EventManager = Nothing

        Try

            If CheckMethodUtil.CheckIsNothing(dsPrint) Then

                '設定 EventMgr
                eventMgr = EventManager.getInstance()

                Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

                Dim RowIndex As Integer = 1
                '----------------------------------------------------------------------------
                '#Step1.Create Excel物件
                '----------------------------------------------------------------------------
                'On Error Resume Next
                Try
                    xlApp = New Microsoft.Office.Interop.Excel.Application
                Catch ex As Exception
                    '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
                    If Err.Number() <> 0 Then Err.Clear()

                    '執行一個新的Excel Application            
                    xlApp = CreateObject("Excel.Application")

                    If Err.Number() <> 0 Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"電腦沒有安裝Excel!"}, "")
                        Exit Sub
                    End If
                End Try
                '--------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step2.匯出DataSet的資料到Excel
                '----------------------------------------------------------------------------
                eventMgr.RaiseUclWaitingForm("WaitingStart", "匯出檔案中，請稍後‧‧‧")

                Try
                    '取得表頭欄位名稱陣列
                    'Dim columnName As String() = gblColumnNameExcelTitle.Split(",")

                    xlApp.Visible = False

                    '開新活頁簿
                    xlBook = xlApp.Workbooks.Add
                    '設定活頁簿為焦點
                    xlBook.Activate()
                    '選取第1張活頁簿
                    xlSheet = xlBook.Worksheets(1)


                    '開始列印表頭部分資訊
                    PrintPageHeader(reportName, reportId, xlSheet, dsPrint.Tables(0), columnNameList(0), RowIndex)

                    '列印的ClumnName 的 ListIndex
                    Dim columnListIndex As Integer = 0

                    '循環列印每一個 Table
                    For Each dtPrint As DataTable In dsPrint.Tables

                        '設定字型
                        xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Font.Name = "標楷體"
                        xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                        '判斷有無表頭，沒有的話，用dt本身資料取代
                        If columnNameList(columnListIndex) Is Nothing Then
                            Dim columnStr As String = ""
                            For i As Integer = 0 To dtPrint.Columns.Count - 1
                                columnStr += dtPrint.Columns(i).ColumnName & ","
                            Next
                            If columnStr.LastIndexOf(",") = columnStr.Length - 1 Then
                                columnStr = columnStr.Substring(0, columnStr.Length - 1)
                            End If
                            columnNameList(columnListIndex) = columnStr.Split(",")
                        End If

                        '開始列印表格Header 部分資訊
                        RowIndex = PrintColumnHeader(xlSheet, dtPrint, columnNameList(columnListIndex), Nothing, RowIndex, VisibleTableName)

                        '列印表身內容
                        RowIndex = PrintdtBody(xlApp, xlSheet, dtPrint, columnNameList(columnListIndex), RowIndex, wrapFlag)

                        '換 列印的Table Column 的 Index
                        columnListIndex += 1

                        '空一行，以便分隔DT
                        RowIndex += 1

                    Next

                    ''儲存Excel
                    'xlBook.SaveAs(filePath)
                    xlApp.Visible = True


                Catch ex As Exception
                    ClientExceptionHandler.ProccessException(ex)
                Finally

                    eventMgr.RaiseUclWaitingForm("WaitingEnd", "")

                    '回收Excel
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                    If xlApp IsNot Nothing Then xlApp = Nothing
                    If xlBook IsNot Nothing Then xlBook = Nothing
                    If xlSheet IsNot Nothing Then xlSheet = Nothing
                    If xlRange IsNot Nothing Then xlRange = Nothing
                    'GC.Collect()
                End Try

            Else

                MessageHandling.ShowWarnMsg("CMMCMMB300", "列印的資料 DataTable 不存在!")

            End If

        Catch cmex As CommonException
            ' FinishWork(xlsapp)
            Throw cmex
        Catch ex As Exception
            'FinishWork(xlsapp)
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If Not eventMgr Is Nothing Then
                eventMgr = Nothing
            End If
        End Try
    End Sub

#End Region

#Region "　　表頭與標題欄位 "

    ''' <summary>
    ''' 列印時負責處理表頭與標題欄位的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Private Shared Sub PrintHeadFont(ByVal reportName As String, ByVal reportId As String, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByRef RowIndex As Integer)
        Try
            '------------------------------------------------
            '報表名稱從第一列第一行開始 
            '------------------------------------------------
            '報表編號從第二列第一行開始到第三行，Merge 
            '列印日期從第二列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------
            '列印者  從第三列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------

            Dim endColIndexReportId As Integer = 3

            Dim startColIndexPrint As Integer = 4
            Dim endColIndexPrint As Integer = 5

            '有五行以上，調整 Print columnIndex 位置
            If dtPrint.Columns.Count > 5 Then
                endColIndexReportId = dtPrint.Columns.Count - 2
                startColIndexPrint = dtPrint.Columns.Count - 1
                endColIndexPrint = dtPrint.Columns.Count
            End If

            '列印報表名稱
            xlSheet.Cells(RowIndex, 1) = reportName
            xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlSheet.Cells(RowIndex, 1).Font.Size = 20
            xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
            '設定第一列儲存格合併，合併整個第一列
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Merge()
            RowIndex += 1

            '判斷有無報表編號，有的話才列印
            If reportId <> "" Then
                '列印報表編號
                xlSheet.Cells(RowIndex, 1) = "報表編號：" & reportId
                xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                xlSheet.Cells(RowIndex, 1).Font.Size = 10
                xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
                xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, endColIndexReportId)).Merge()
            End If

            '列印日期
            xlSheet.Cells(RowIndex, startColIndexPrint) = "列印日期：" & DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm"))
            xlSheet.Cells(RowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(RowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(RowIndex, startColIndexPrint).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, startColIndexPrint), xlSheet.Cells(RowIndex, endColIndexPrint)).Merge()
            RowIndex += 1

            '列印查詢人員
            xlSheet.Cells(RowIndex, startColIndexPrint) = "列印人員：" & AppContext.userProfile.userName
            xlSheet.Cells(RowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(RowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(RowIndex, startColIndexPrint).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, startColIndexPrint), xlSheet.Cells(RowIndex, endColIndexPrint)).Merge()
            RowIndex += 1


            '填入表頭的Title
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Value = columnName

            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0
            For i As Integer = 0 To columnName.Length - 1
                clnWidth = columnName(i).Length
                xlSheet.Columns(i + 1).ColumnWidth = (2.5 * clnWidth)
            Next
            '畫上框線
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Borders(8).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Borders(8).Weight = 2
            '畫下框線
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, dtPrint.Columns.Count)).Borders(9).Weight = 2
            RowIndex += 1

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "　　表頭 "

    ''' <summary>
    ''' 列印時負責處理表頭
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5 ； Sean Lin 2015/11/24</remarks>
    Private Shared Function PrintPageHeader(ByVal reportName As String, ByVal reportId As String, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByRef rowIndex As Integer) As Integer
        Try
            '------------------------------------------------
            '報表名稱從第一列第一行開始 
            '------------------------------------------------
            '報表編號從第二列第一行開始到第三行，Merge 
            '列印日期從第二列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------
            '列印者  從第三列第四行開始到最後一行(最少到第五行)
            '------------------------------------------------

            Dim endColIndexReportId As Integer = 3

            Dim startColIndexPrint As Integer = 4
            Dim endColIndexPrint As Integer = 5

            '有五行以上，調整 Print columnIndex 位置
            If dtPrint.Columns.Count > 5 Then
                endColIndexReportId = dtPrint.Columns.Count - 2
                startColIndexPrint = dtPrint.Columns.Count - 1
                endColIndexPrint = dtPrint.Columns.Count
            End If

            '列印報表名稱
            xlSheet.Cells(rowIndex, 1) = reportName
            xlSheet.Cells(rowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlSheet.Cells(rowIndex, 1).Font.Size = 20
            xlSheet.Cells(rowIndex, 1).Font.Name = "標楷體"
            '設定第一列儲存格合併，合併整個第一列
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Merge()
            rowIndex += 1

            '判斷有無報表編號，有的話才列印
            If reportId <> "" Then
                '列印報表編號
                xlSheet.Cells(rowIndex, 1) = "報表編號：" & reportId
                xlSheet.Cells(rowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                xlSheet.Cells(rowIndex, 1).Font.Size = 10
                xlSheet.Cells(rowIndex, 1).Font.Name = "標楷體"
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, endColIndexReportId)).Merge()
            End If

            '列印日期
            xlSheet.Cells(rowIndex, startColIndexPrint) = "列印日期：" & DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm"))
            xlSheet.Cells(rowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(rowIndex, startColIndexPrint), xlSheet.Cells(rowIndex, endColIndexPrint)).Merge()
            rowIndex += 1

            '列印查詢人員
            xlSheet.Cells(rowIndex, startColIndexPrint) = "列印人員：" & AppContext.userProfile.userName
            xlSheet.Cells(rowIndex, startColIndexPrint).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Size = 10
            xlSheet.Cells(rowIndex, startColIndexPrint).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(rowIndex, startColIndexPrint), xlSheet.Cells(rowIndex, endColIndexPrint)).Merge()
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "　　標題欄位 "

    ''' <summary>
    ''' 列印時負責處理標題欄位的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5 ；Sean Lin 2015/11/24 </remarks>
    Private Shared Function PrintColumnHeader(ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByVal columnWidth As String(), ByRef rowIndex As Integer, Optional ByVal VisibleTableName As Boolean = False) As Integer
        Try

            '根據傳入的rowIndex 進行列印 Table 的 Column Header

            If VisibleTableName Then
                '填入表格的Title
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Value = dtPrint.TableName
                '設置表頭字體、大小並且置中
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Font.Name = "標楷體"
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                rowIndex += 1
            End If


            '填入表格的Title
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Value = columnName
            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0
            For i As Integer = 0 To columnName.Length - 1

                '不為空，才重新設定寬度
                If Not columnWidth Is Nothing AndAlso columnWidth(i).ToString.Trim <> "" Then

                    clnWidth = columnWidth(i)
                    '判斷 新的 欄位寬度 比較長，才設定寬度
                    If xlSheet.Columns(i + 1).ColumnWidth < clnWidth Then
                        xlSheet.Columns(i + 1).ColumnWidth = clnWidth
                    End If

                Else
                    '未設定，給予基礎寬度
                    clnWidth = columnName(i).Length
                    '判斷 新的 欄位寬度 比較長，才設定寬度
                    If xlSheet.Columns(i + 1).ColumnWidth < (2.5 * clnWidth) Then
                        xlSheet.Columns(i + 1).ColumnWidth = (2.5 * clnWidth)
                    End If
                End If

            Next

            '畫標題上框線
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(8).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(8).Weight = 2
            '畫標題下框線
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(9).Weight = 2
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' 列印時負責處理標題欄位的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>add by qun,2017/3/10,欄位寬度按照參數傳入設置 </remarks>
    Private Shared Function PrintColumnHeaderSetColumWidth(ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByVal columnWidth As String(), ByRef rowIndex As Integer, Optional ByVal VisibleTableName As Boolean = False) As Integer
        Try

            '根據傳入的rowIndex 進行列印 Table 的 Column Header

            If VisibleTableName Then
                '填入表格的Title
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Value = dtPrint.TableName
                '設置表頭字體、大小並且置中
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).Font.Name = "標楷體"
                xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                rowIndex += 1
            End If


            '填入表格的Title
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Value = columnName
            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0
            For i As Integer = 0 To columnName.Length - 1

                '不為空，才重新設定寬度
                If Not columnWidth Is Nothing AndAlso columnWidth(i).ToString.Trim <> "" Then

                    clnWidth = columnWidth(i)
                    xlSheet.Columns(i + 1).ColumnWidth = clnWidth
                Else
                    '未設定，給予基礎寬度
                    clnWidth = columnName(i).Length
                    '判斷 新的 欄位寬度 比較長，才設定寬度
                    If xlSheet.Columns(i + 1).ColumnWidth < (2.5 * clnWidth) Then
                        xlSheet.Columns(i + 1).ColumnWidth = (2.5 * clnWidth)
                    End If
                End If

            Next

            '畫標題上框線
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(8).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(8).Weight = 2
            '畫標題下框線
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(rowIndex, 1), xlSheet.Cells(rowIndex, dtPrint.Columns.Count)).Borders(9).Weight = 2
            rowIndex += 1

            Return rowIndex

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "　　表格內容 "

    ''' <summary>
    ''' 列印時負責處理表格內容的部分
    ''' <paramref name=" sheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" dtPrint ">要匯出的資料集</paramref>
    ''' <paramref name=" columnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5 ；Sean Lin 2015/11/24 </remarks>
    Private Shared Function PrintdtBody(ByRef xlApp As Microsoft.Office.Interop.Excel.Application, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtPrint As DataTable, ByVal columnName As String(), ByRef rowIndex As Integer, ByVal wrapFlag As Boolean) As Integer
        Dim objrow As Integer = -1
        Dim state As String = "start"

        Try

            Try
                xlApp.Interactive = False

                If xlApp.Ready = False Then
                    Threading.Thread.Sleep(2)
                End If

            Catch ex As Exception

            End Try

            '填入表身資料
            For iRow As Integer = 0 To dtPrint.Rows.Count - 1

                'state = "Value"

                'xlSheet.Range(xlSheet.Cells(iRow + rowIndex, 1), xlSheet.Cells(iRow + rowIndex, dtPrint.Columns.Count)).Value = dtPrint.Rows(iRow).ItemArray

                'state = "WrapText"

                'xlSheet.Range(xlSheet.Cells(iRow + rowIndex, 1), xlSheet.Cells(iRow + rowIndex, dtPrint.Columns.Count)).WrapText = wrapFlag

                '時間日期處理
                For ItemIndex = 0 To dtPrint.Rows(iRow).ItemArray.Length - 1

                    state = "WrapText"

                    xlSheet.Range(xlSheet.Cells(iRow + rowIndex, ItemIndex + 1), xlSheet.Cells(iRow + rowIndex, ItemIndex + 1)).WrapText = wrapFlag

                    If IsDate(dtPrint.Rows(iRow).ItemArray(ItemIndex)) Then
                        state = "Date"
                        xlSheet.Range(xlSheet.Cells(iRow + rowIndex, ItemIndex + 1), xlSheet.Cells(iRow + rowIndex, ItemIndex + 1)).Value = Convert.ToString(dtPrint.Rows(iRow).ItemArray(ItemIndex))
                    Else
                        state = "Value"
                        xlSheet.Range(xlSheet.Cells(iRow + rowIndex, ItemIndex + 1), xlSheet.Cells(iRow + rowIndex, ItemIndex + 1)).Value = dtPrint.Rows(iRow).Item(ItemIndex)
                    End If

                Next
                objrow = iRow
                If iRow Mod 100 = 0 Then
                    EventManager.getInstance.RaiseUclWaitingForm("WaitingEnd", "")
                    EventManager.getInstance.RaiseUclWaitingForm("WaitingStart", "匯出Excel資料中 ( " & iRow & " / " & dtPrint.Rows.Count & " )，請稍後‧‧‧")
                End If

            Next

            '畫下框線
            xlSheet.Range(xlSheet.Cells(rowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(rowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(rowIndex + dtPrint.Rows.Count - 1, 1), xlSheet.Cells(rowIndex + dtPrint.Rows.Count - 1, dtPrint.Columns.Count)).Borders(9).Weight = 2

            '回傳列印完的最後一行
            Return rowIndex + dtPrint.Rows.Count

        Catch comex As System.Runtime.InteropServices.COMException
            Throw New Exception(String.Format("objrow:{0},dtPrint.rows:{1},dtPrint.columns{2},rowindex:{3},state:{4},data:{5},ex:{6}", objrow, dtPrint.Rows.Count, dtPrint.Columns.Count, rowIndex, state, String.Join(",", dtPrint.Rows(objrow).ItemArray), comex.Message))
        Catch ex As Exception
            Throw ex
        Finally
            If xlApp.Interactive = False Then xlApp.Interactive = True
        End Try

    End Function

#End Region

#End Region


#Region "　　匯入Excel"



    ''' <summary>
    ''' 匯入Excel檔案
    ''' </summary>
    ''' <param name="filePath">欲匯入的檔案完整路徑</param>
    ''' <param name="SheetIndex">要開啟的指定工作表</param>
    ''' <param name="OutTableName"> 回傳的Table Name</param>
    ''' <param name="includeColumnHeader">True：包含第一列、False：不包含第一列</param>
    ''' <returns>DataSet(OutTableName)</returns>
    ''' <remarks></remarks>
    Public Shared Function ImportExcelDataAndConvertIntoDataSet(ByVal filePath As String, Optional ByVal SheetIndex As Integer = 1, Optional ByVal OutTableName As String = "excelData", Optional ByVal includeColumnHeader As Boolean = False) As DataSet
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

        '----------------------------------------------------------------------------
        '#Step1.Create Excel物件
        '----------------------------------------------------------------------------
        'On Error Resume Next
        Try
            '一部電腦僅執行一個Excel Application, 就算中突開啟Excel也不會影響程式執行        
            '在工作管理員中只會看見一個EXCEL.exe在執行，不會浪費電腦資源        
            '引用正在執行的Excel Application        
            xlApp = GetObject(, "Excel.Application")
        Catch ex As Exception
            '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
            If Err.Number() <> 0 Then Err.Clear()

            '執行一個新的Excel Application            
            xlApp = CreateObject("Excel.Application")
            If Err.Number() <> 0 Then
                MsgBox("電腦沒有安裝Excel")
            End If
        End Try
        '----------------------------------------------------------------------------
        '#Step2.Open Excel檔案
        '----------------------------------------------------------------------------
        '打開已經存在的EXCEL工件簿文件        
        xlBook = xlApp.Workbooks.Open(filePath)
        '停用警告訊息
        xlApp.DisplayAlerts = False

        xlApp.Visible = False
        '設定活頁簿為焦點
        xlBook.Activate()
        '顯示第一個子視窗
        'xlBook.Parent.Windows(1).Visible = True

        '引用第一個工作表
        xlSheet = xlBook.Worksheets(SheetIndex)
        '設定工作表為焦點
        xlSheet.Activate()
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        '#Step3.取得工作表中已使用的Range
        '----------------------------------------------------------------------------
        xlRange = xlSheet.UsedRange
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        '#Step4.將Excel資料轉成Data Set
        '----------------------------------------------------------------------------
        Try
            Using dsData As DataSet = ExcelConvertDataSet(includeColumnHeader, xlRange.Value, OutTableName)
                Return dsData
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            xlApp.Quit()
            If xlApp IsNot Nothing Then xlApp = Nothing
            If xlBook IsNot Nothing Then xlBook = Nothing
            If xlSheet IsNot Nothing Then xlSheet = Nothing
            If xlRange IsNot Nothing Then xlRange = Nothing
        End Try
        '----------------------------------------------------------------------------
    End Function


    ''' <summary>
    ''' 將Excel的資料轉換成DataSet
    ''' </summary>
    ''' <param name="includeColumnHeader">資料是否包含欄位的Header</param>
    ''' <param name="dataArray">資料的2維陣列</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Private Shared Function ExcelConvertDataSet(ByVal includeColumnHeader As Boolean, ByVal dataArray(,) As Object, Optional ByVal OutTableName As String = "excelData") As DataSet
        Dim rowStartIndex As Integer = 1

        '如果資料包含Header，則資料行的Index從1開始
        If includeColumnHeader Then
            rowStartIndex = 2
        End If

        Try
            Using ds As DataSet = New DataSet
                ds.Tables.Add(OutTableName)

                With ds.Tables(0)
                    '----------------------------------------------------------------------------
                    '#Step1.建立Column的Header
                    '----------------------------------------------------------------------------
                    For iColumn As Integer = 1 To dataArray.GetUpperBound(1)
                        '如果資料包含Header，則以Header資料為Column的Header
                        '2014-03-01 Modified by 嚴崑銘，修正因 Nothing 而造成的 Exception
                        If includeColumnHeader Then
                            .Columns.Add(nvl(dataArray(1, iColumn)))
                        Else
                            .Columns.Add(iColumn.ToString)
                        End If
                    Next
                    '----------------------------------------------------------------------------
                    '#Step2.塞資料
                    '----------------------------------------------------------------------------
                    For iRow As Integer = rowStartIndex To dataArray.GetUpperBound(0)
                        Dim objArray(dataArray.GetUpperBound(1) - 1) As Object
                        For iColumn As Integer = 1 To dataArray.GetUpperBound(1)
                            If dataArray(iRow, iColumn) Is Nothing Then
                                objArray(iColumn - 1) = ""
                            Else
                                objArray(iColumn - 1) = dataArray(iRow, iColumn).ToString.Trim
                            End If
                        Next
                        .Rows.Add(objArray)
                    Next
                End With

                Return ds

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "　　匯出PDF"

#Region "　　匯出PDF"

#Region "變數宣告"

    '取得 第一行 Header 距離頁首的距離
    Private Shared gblTableColumnsWidth As Object

    '取得 第一行 Header 距離頁首的距離
    Private Shared gblFirstHeaderMargin As Integer = 40

    '取得 第二行 Header 距離頁首的距離
    Private Shared gblSecondHeaderMargin As Integer = 60

    '取得 第三行 Header 距離頁首的距離
    Private Shared gblThirdHeaderMargin As Integer = 80

    '取得 頁碼 Footer  距離頁尾的距離
    Private Shared gblPageFooterMargin As Integer = 45

    '取得 內文 距離頁首的距離
    Private Shared gblContentHeaderMargin As Integer = 85

    '取得 內文 距離頁尾的距離
    Private Shared gblContenteFooterMargin As Integer = 60

    '接收資料集
    Private Shared gblDsInput As DataSet

    '字型設定
    '標楷體
    Private Shared gblBfChinese As BaseFont = BaseFont.CreateFont("C:\WINDOWS\Fonts\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)

    '字體設定(大小顏色)
    Private Shared gblBfFont As New Font(gblBfChinese, 12)

    '紙張種類
    Private Shared gblDocPdf As Document = New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)

    Private Shared gblReportName As String = "'"

#End Region


    ''' <summary> 
    ''' 把Data匯出成Pdf，包含天地，列印DS 裡面 TableName 所有的資料
    '''  單一表單，多個Table 列印在一頁
    ''' </summary>
    ''' <param name="dsPrint">資料集</param> 
    ''' <param name="reportName">報表名稱</param>
    ''' <param name="reportId">報表 ID </param>
    ''' <remarks>copy from  Will.Lin,Modified by Sean.Lin on 2015-10-15</remarks>
    Public Shared Function DataToPdfWithFormate(ByVal dsPrint As DataSet, ByVal reportName As String, ByVal reportId As String) As Object
        '設定存檔路徑
        Dim pdfFilePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "VS" & Now.ToString("yyyyMMddHHssmmfff") & ".pdf"
        gblReportName = reportName
        Try

            If gblDocPdf Is Nothing Then
                gblDocPdf = New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
            End If


            '設定邊界
            gblDocPdf.SetMargins(1, 1, gblContentHeaderMargin, gblContenteFooterMargin)

            '設定DS，以提供Header 與Footer 使用
            gblDsInput = dsPrint

            '設定Pdf Writer
            Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(gblDocPdf, New FileStream(pdfFilePath, FileMode.Create))
            'pdf事件Override
            pdfwrite.PageEvent = New ProcesssPDFHeaderFooter
            '開啟文件
            gblDocPdf.SetPageSize(PageSize.A4.Rotate())

            '產生Pdf Table 於 Pdf 上
            genReportByFilter(dsPrint)

            Return pdfFilePath

        Catch ex As Exception

            Throw ex
        Finally

            gblDocPdf.Close()
            gblDocPdf = Nothing
            'gblDocPdf.Dispose()

            Dim p As New Process()
            p.StartInfo.FileName = pdfFilePath
            p.Start()
        End Try
    End Function

    ''' <summary>
    ''' 一般報表的列印格式
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub GenRecordDataForNormal(ByVal DT_Content As DataTable)

        Try
            '定義表格的Table
            Dim pdfDtRecordData As PdfPTable = Nothing


            '設定欄寬
            Dim tableColumnWidth As Int32()
            ReDim tableColumnWidth(DT_Content.Columns.Count - 1)
            For y As Int32 = 0 To tableColumnWidth.Length - 1
                tableColumnWidth(y) = 100
            Next
            '產生Pdf表格
            pdfDtRecordData = New PdfPTable((tableColumnWidth.ToList.ConvertAll(Function(x) Convert.ToSingle(x)).ToArray))
            '設定pdf表格總寬度
            pdfDtRecordData.TotalWidth = tableColumnWidth.Sum
            '設定表格第一列為表頭
            pdfDtRecordData.HeaderRows = 1

            '固定大小
            pdfDtRecordData.LockedWidth = True


            Dim i As Int32 = 1
            Dim cell As PdfPCell = Nothing
            '標頭列
            For Each c As DataColumn In DT_Content.Columns
                cell = New PdfPCell(New Phrase(c.ColumnName, gblBfFont))
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfDtRecordData.AddCell(cell)
            Next
            '資料列印
            For rowIndex As Integer = 0 To DT_Content.Rows.Count - 1
                For Each c As DataColumn In DT_Content.Columns
                    Dim str As String = " "
                    '防止空格不被顯示出來，要塞一個空白進去
                    If nvl(DT_Content.Rows(rowIndex).Item(c.ColumnName)) <> "" Then
                        str = nvl(DT_Content.Rows(rowIndex).Item(c.ColumnName))
                    End If
                    cell = New PdfPCell(New Phrase(str, gblBfFont))
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfDtRecordData.AddCell(cell)
                    cell.Border = 1
                Next
                '將表格加入pdf
            Next
            If pdfDtRecordData IsNot Nothing Then
                gblDocPdf.Add(pdfDtRecordData)
                gblDocPdf.NewPage()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " 產生 Pdf Table"

    ''' <summary>
    ''' 產生 Pdf Table
    ''' </summary>
    ''' <param name="dsPrintS" >傳入的Data</param>
    ''' <remarks></remarks>
    Public Shared Function genReportByFilter(ByRef dsPrintS As System.Data.DataSet) As Object


        Dim DT_Content As System.Data.DataTable = dsPrintS.Tables(0).Copy
        Dim SpiltDS As New DataSet
        Try
            '欄位超過八個，強制分割成第二個TABLE
            If DT_Content.Columns.Count > 8 Then
                SpiltDS = SplitDT(DT_Content)
            Else
                SpiltDS.Tables.Add(DT_Content)
            End If

            gblDocPdf.Open()

            For Each dt As DataTable In SpiltDS.Tables

                GenRecordDataForNormal(dt)
            Next



            Return gblDocPdf

        Catch ex As Exception

            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' 分割單一TABLE為多個TABLE
    ''' </summary>
    ''' <param name="InputDt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SplitDT(ByVal InputDt As DataTable) As DataSet
        Try
            Dim retDS As New DataSet
            Dim retDT As New DataTable
            '每8個欄位切出一個TABLE
            Dim TableCount As Int32 = Math.Ceiling(InputDt.Columns.Count / 8)
            Dim ColumnIndex As Int32 = 0
            Dim newRow As DataRow
            For i As Int32 = 0 To TableCount - 1
                retDT = New DataTable
                retDT.TableName = i
                'Step 1 先將Columns找出來
                For y As Int32 = 0 To 7
                    If ColumnIndex > InputDt.Columns.Count - 1 Then
                        Exit For
                    End If
                    retDT.Columns.Add(InputDt.Columns(ColumnIndex).ColumnName)
                    ColumnIndex += 1
                Next
                'Step 2 將每個row的資料填入
                For Each dr As DataRow In InputDt.Rows
                    newRow = retDT.NewRow
                    For z As Int32 = 0 To 7
                        If z + (i * 8) = InputDt.Columns.Count Then
                            Exit For
                        End If
                        newRow(z) = nvl(dr(z + (i * 8)))
                    Next
                    retDT.Rows.Add(newRow)
                Next
                retDS.Tables.Add(retDT.Copy)

            Next

            Return retDS
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Class ProcesssPDFHeaderFooter
        Inherits PdfPageEventHelper

        Dim gblCb As PdfContentByte
        Dim gblTemplate As PdfTemplate
        Dim gblBf As BaseFont
        Dim dt As DateTime = Now.ToString("yyyy/MM/dd HH:mm:ss")



        ''' <summary> 開啟Document Event </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="document">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnOpenDocument(writer As PdfWriter, document As Document)
            MyBase.OnOpenDocument(writer, document)

            Try
                '標楷體
                gblBf = BaseFont.CreateFont("C:\WINDOWS\Fonts\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)
                gblCb = writer.DirectContent
                gblTemplate = gblCb.CreateTemplate(50, 50)

            Catch ex As DocumentException

            End Try
        End Sub
        ''' <summary> Pdf頁首Event </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="document">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            MyBase.OnEndPage(writer, document)

            Dim pageSize As Rectangle = document.PageSize
            gblCb.SetColorFill(BaseColor.GRAY)

            '******************************************************************************************************
            '設定頁首頁尾字串
            '******************************************************************************************************
            '設定醫院名稱
            gblCb.SaveState()
            gblCb.BeginText()
            gblCb.SetRGBColorFill(100, 100, 100)
            gblCb.SetFontAndSize(gblBf, 18)
            '設定醫院名稱字串
            gblCb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, HospConfigUtil.Name, pageSize.GetLeft(410), pageSize.GetTop(gblFirstHeaderMargin), 0)
            gblCb.EndText()
            gblCb.RestoreState()

            '設定報表名稱
            gblCb.BeginText()
            gblCb.SetFontAndSize(gblBf, 18)
            '設定報表名稱字串
            gblCb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, gblReportName, pageSize.GetLeft(410), pageSize.GetTop(gblSecondHeaderMargin), 0)
            gblCb.EndText()

            '設定列印時間
            gblCb.BeginText()
            gblCb.SetFontAndSize(gblBf, 8)
            gblCb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "列印時間：" & dt, pageSize.GetRight(40), pageSize.GetTop(30), 0)
            gblCb.EndText()
            '列印者
            gblCb.BeginText()
            gblCb.SetFontAndSize(gblBf, 8)
            gblCb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "列印者： " & AppContext.userProfile.userName & vbCrLf, pageSize.GetRight(169), pageSize.GetTop(50), 0)
            gblCb.EndText()

            '頁尾字串
            Dim text As String = "共  " & writer.PageNumber & " / "
            gblCb.SetRGBColorFill(100, 100, 100)
            gblCb.BeginText()
            gblCb.SetFontAndSize(gblBf, 9)
            gblCb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text, pageSize.GetLeft(410), pageSize.GetBottom(gblPageFooterMargin), 0)
            gblCb.EndText()
            gblCb.AddTemplate(gblTemplate, pageSize.GetLeft(410) + gblBf.GetWidthPoint(text, 9) / 2, pageSize.GetBottom(gblPageFooterMargin))


        End Sub


        ''' <summary> 關閉DocumentEvent </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="document">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnCloseDocument(writer As PdfWriter, document As iTextSharp.text.Document)

            Try

                MyBase.OnCloseDocument(writer, document)

                '設定總頁數
                gblTemplate.BeginText()
                gblTemplate.SetFontAndSize(gblBf, 9)
                gblTemplate.SetTextMatrix(0, 0)
                gblTemplate.ShowText((writer.PageNumber - 1).ToString & " 頁")
                gblTemplate.EndText()

            Catch ex As Exception
                Throw ex
            Finally
                If gblCb IsNot Nothing Then

                    gblCb = Nothing
                End If

                If gblTemplate IsNot Nothing Then

                    gblTemplate = Nothing
                End If

            End Try
        End Sub
    End Class


#End Region


#End Region

End Class
