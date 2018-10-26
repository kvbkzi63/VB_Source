Imports System.Text
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Word
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Comm.RPT
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.BASE

Public MustInherit Class IRPTPrintClient
    Inherits IRPTPrint

#Region " 變數宣告 "

    Dim NewreportId As String   ' 列印報表、預覽報表要用
    Dim Pub As PubServiceManager = PubServiceManager.getInstance()

    Protected defaultTxtDirectoryPath As String = My.Application.Info.DirectoryPath & "\txtReport\"
    Protected reportId As String
    Protected printerName As String
    Protected reportType As String
    Protected gblReportAlarmCount As Integer = -1
#End Region

#Region " Override Method 宣告 "

    '取得報表資料
    Protected MustOverride Function queryRPTData(ByRef queryCondition As Object()) As DataSet
    '產生報表
    Protected MustOverride Function genReport(ByRef data As DataSet) As Object

    '列印報表
    Protected Overridable Sub printReport(ByRef rpt As Object)
    End Sub

    '取得報表資料
    Protected Overrides Function _queryRPTData(ByRef queryCondition As Object()) As DataSet
        Return queryRPTData(queryCondition)
    End Function
    ''產生報表
    'Protected Overrides Function _genReport(ByRef data As DataSet) As Object
    '    Return genReport(data)
    'End Function

    '取得印表機
    Protected Overrides Function _getPrinterName(ByRef id As String) As String
        Return getPrinterName(id)
    End Function

    '取得報表列印 JOB ID
    Protected Overrides Function _getRpt_Print_Job_ID() As String
        Return getRpt_Print_Job_ID()
    End Function

    '列印報表
    Protected Overrides Sub _printReport(ByRef rpt As Object)
        printReport(rpt)
    End Sub

    '取得印表機
    Protected Overridable Function getPrinterName(ByRef id As String) As String
        Return printerName 'RptServiceManager.getInstance.getPrinterName(id, Syscom.Comm.RPT.IRPTPrint.client, printerCondition)
    End Function

#End Region

    '取得報表列印 JOB ID -主要用於紀錄 報表有被印過
    Protected Function getRpt_Print_Job_ID() As String
        Return "" ' RptServiceManager.getInstance.getReportID()
    End Function

#Region "Client 端報表的預覽與列印功能 "

#Region " 預覽功能 "

#Region " 預覽報表 -  queryCondition "

#Region " 預覽報表 -  必須自行檢查是否有無資料 "

    ''' <summary>
    ''' 預覽報表 - 必須自行檢查是否有無資料
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef queryCondition As Object()) As String
        '取得報表資料
        Dim data As DataSet
        Try
            '取得報表ID
            NewreportId = queryCondition(0)

            data = queryRPTData(queryCondition)



            If data Is Nothing Then
                Throw New RPTBusinessException("RPTCMMA001")
            End If

            '預覽報表           
            Return preview(data)
        Catch rptex As RPTBusinessException
            LOGDelegate.getInstance.fileErrorMsg(rptex.getErrorMessage, rptex)
            Throw rptex
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw New RPTBusinessException("RPTCMMA001", ex)
        End Try

    End Function
    Public Function previewtxt(ByRef queryCondition As Object()) As String
        '取得報表資料
        Dim data As DataSet
        Try
            '取得報表ID
            NewreportId = queryCondition(0)

            data = queryRPTData(queryCondition)



            If data Is Nothing Then
                Throw New RPTBusinessException("RPTCMMA001")
            End If

            '預覽報表           
            Return previewtxt(data)
        Catch rptex As RPTBusinessException
            LOGDelegate.getInstance.fileErrorMsg(rptex.getErrorMessage, rptex)
            Throw rptex
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw New RPTBusinessException("RPTCMMA001", ex)
        End Try

    End Function

#End Region

#Region " 預覽報表 -  checkTableName "

    ''' <summary>
    ''' 預覽報表 - checkTableName
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <param name="checkTableName">要檢查的TableName</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef queryCondition As Object(), ByVal checkTableName As String, ByVal showWarnFlag As Boolean) As String
        '取得報表資料
        Dim data As DataSet
        Try
            data = queryRPTData(queryCondition)

            '預覽報表           
            Return preview(data, checkTableName, showWarnFlag)

        Catch rptex As RPTBusinessException
            LOGDelegate.getInstance.fileErrorMsg(rptex.getErrorMessage, rptex)
            Throw rptex
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw New RPTBusinessException("RPTCMMA001", ex)
        End Try

    End Function

#End Region

#Region " 預覽報表 -  checkTableNameArray "

    ''' <summary>
    ''' 預覽報表 - checkTableNameArray
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <param name="checkTableNameArray">要檢查的tableName 陣列</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef queryCondition As Object(), ByVal checkTableNameArray As String(), ByVal showWarnFlag As Boolean) As String
        '取得報表資料
        Dim data As DataSet
        Try
            data = queryRPTData(queryCondition)

            '預覽報表           
            Return preview(data, checkTableNameArray, showWarnFlag)

        Catch rptex As RPTBusinessException
            LOGDelegate.getInstance.fileErrorMsg(rptex.getErrorMessage, rptex)
            Throw rptex
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw New RPTBusinessException("RPTCMMA001", ex)
        End Try

    End Function

#End Region

#End Region

#Region " 預覽報表 -  DataSet "

#Region " 預覽報表 -  必須自行檢查是否有無資料 "

    ''' <summary>
    ''' 預覽報表 - 必須自行檢查是否有無資料
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef data As DataSet) As String

        '產生報表
        Dim rpt As Object
        Dim result As String = ""

        If NewreportId <> Nothing Then
            '取得報表AlarmCount
            gblReportAlarmCount = Pub.PUBReportAlarmCountQuery(NewreportId)
        End If

        If CheckMethodUtil.CheckHasValue(data) AndAlso _
              gblReportAlarmCount <> -1 AndAlso _
                data.Tables(0).Rows.Count >= gblReportAlarmCount Then

            InsertPUBPrintRecord(data)

            MessageHandling.ShowWarnMsg("CMMCMMB300", "大量資料預覽，資料筆數:" & data.Tables(0).Rows.Count & "筆，警告筆數:" & gblReportAlarmCount & "筆，已記錄!")

        End If

        Try
            rpt = genReport(data)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA002", ex)
        End Try

        '預覽報表
        Try
            'result = _getRpt_Print_Job_ID()
            previewReport(rpt)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA004", ex)
        End Try

        Return result
    End Function

    Public Function previewtxt(ByRef data As DataSet) As String

        '產生報表
        Dim rpt As Object
        Dim result As String = ""

        If NewreportId <> Nothing Then
            '取得報表AlarmCount
            gblReportAlarmCount = Pub.PUBReportAlarmCountQuery(NewreportId)
        End If

        If CheckMethodUtil.CheckHasValue(data) AndAlso _
              gblReportAlarmCount <> -1 AndAlso _
                data.Tables(0).Rows.Count >= gblReportAlarmCount Then

            InsertPUBPrintRecord(data)

            MessageHandling.ShowWarnMsg("CMMCMMB300", "大量資料預覽，資料筆數:" & data.Tables(0).Rows.Count & "筆，警告筆數:" & gblReportAlarmCount & "筆，已記錄!")

        End If

        Try
            rpt = genReport(data)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA002", ex)
        End Try

        '預覽報表
        Try
            'result = _getRpt_Print_Job_ID()
            previewtxtReport(rpt)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA004", ex)
        End Try

        Return result
    End Function
#End Region

#Region " 預覽報表 -  checkTableName "

    ''' <summary>
    ''' 預覽報表 -  checkTableName
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <param name="checkTableName">要檢查的TableName</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef data As DataSet, ByVal checkTableName As String, ByVal showWarnFlag As Boolean) As String


        '檢查Dataset
        Try

            '檢查是否有值可以列印，有值才列印
            If CheckRptHasData(data, checkTableName, showWarnFlag) Then
                '預覽報表           
                Return preview(data)

            Else

                Return ""

            End If

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA004", ex)
        End Try

    End Function

#End Region

#Region " 預覽報表 -  checkTableNameArray "


    ''' <summary>
    ''' 預覽報表 - checkTableNameArray
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <param name="checkTableNameArray">要檢查的TableName 陣列</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function preview(ByRef data As DataSet, ByVal checkTableNameArray As String(), ByVal showWarnFlag As Boolean) As String

        '檢查Dataset
        Try

            '檢查是否有值可以列印，有值才列印
            If CheckRptHasData(data, checkTableNameArray, showWarnFlag) Then
                '預覽報表           
                Return preview(data)

            Else

                Return ""

            End If

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA004", ex)
        End Try

    End Function

#End Region

#End Region


#End Region

#Region " 列印功能 "

#Region " 列印報表 - queryCondition "

#Region " 列印報表 - 必須自行檢查是否有無資料 "

    ''' <summary>
    ''' 列印報表 - 必須自行檢查是否有無資料
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef queryCondition As Object()) As String
        Try
            '取得報表ID
            NewreportId = queryCondition(0)

            '取得報表資料
            Dim data As DataSet = _queryRPTData(queryCondition)

            If data Is Nothing Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", "查無報表資料的記錄，無法列印!")
                Return ""
                Exit Function
            End If

            '列印報表   
            Return print(data)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA001", ex)
        End Try
    End Function

#End Region

#Region " 列印報表 - checkTableName "

    ''' <summary>
    ''' 列印報表 - checkTableName
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <param name="checkTableName">要檢查的TableName</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef queryCondition As Object(), ByVal checkTableName As String, ByVal showWarnFlag As Boolean) As String
        Try
            '取得報表資料
            Dim data As DataSet = _queryRPTData(queryCondition)

            '列印報表   
            Return print(data, checkTableName, showWarnFlag)

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try
    End Function

#End Region

#Region " 列印報表 - checkTableNameArray "

    ''' <summary>
    ''' 列印報表 - checkTableNameArray
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <param name="checkTableNameArray">要檢查的tableName 陣列</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef queryCondition As Object(), ByVal checkTableNameArray As String(), ByVal showWarnFlag As Boolean) As String
        Try
            '取得報表資料
            Dim data As DataSet = _queryRPTData(queryCondition)

            '列印報表   
            Return print(data, checkTableNameArray, showWarnFlag)

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try
    End Function

#End Region

#End Region

#Region " 列印報表 - DataSet "

#Region " 列印報表 - 必須自行檢查是否有無資料 "

    ''' <summary>
    ''' 列印報表 - 必須自行檢查是否有無資料
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef data As DataSet) As String

        Dim result As String = ""

        If NewreportId <> Nothing Then
            '取得報表AlarmCount
            gblReportAlarmCount = Pub.PUBReportAlarmCountQuery(NewreportId)
        End If
        If CheckMethodUtil.CheckHasValue(data) AndAlso _
              gblReportAlarmCount <> -1 AndAlso _
                data.Tables(0).Rows.Count >= gblReportAlarmCount Then

            InsertPUBPrintRecord(data)

            MessageHandling.ShowWarnMsg("CMMCMMB300", "大量資料列印，資料筆數:" & data.Tables(0).Rows.Count & "筆，警告筆數:" & gblReportAlarmCount & "筆，已記錄!")

        End If
        '產生報表
        Dim rpt As Object
        Try
            rpt = genReport(data)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA002", ex)
        End Try

        '列印報表
        Try
            result = _getRpt_Print_Job_ID()
            PrintOut(rpt, printerName)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try

        Return result
    End Function

#End Region

#Region " 列印報表 - checkTableName "

    ''' <summary>
    ''' 列印報表 - checkTableName
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef data As DataSet, ByVal checkTableName As String, ByVal showWarnFlag As Boolean) As String


        '檢查Dataset
        Try

            '檢查是否有值可以列印，有值才列印
            If CheckRptHasData(data, checkTableName, showWarnFlag) Then

                '列印報表           
                Return print(data)

            Else

                Return ""

            End If

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try

    End Function

#End Region

#Region " 列印報表 - checkTableNameArray  "

    ''' <summary>
    ''' 列印報表 - checkTableNameArray 
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <param name="checkTableNameArray">要檢查的tableName 陣列</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Shadows Function print(ByRef data As DataSet, ByVal checkTableNameArray As String(), ByVal showWarnFlag As Boolean) As String


        '檢查Dataset
        Try

            '檢查是否有值可以列印，有值才列印
            If CheckRptHasData(data, checkTableNameArray, showWarnFlag) Then

                '列印報表           
                Return print(data)

            Else

                Return ""

            End If

        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try

    End Function

#End Region

#End Region

#End Region

#Region " 輸出列印到印表機 "

    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr

    ''' <summary>
    ''' 輸出列印到印表機
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub PrintOut(ByRef rpt As Object, ByRef PrinterName As String)
        If rpt IsNot Nothing Then
            '設定  active printer
            setActivePrinterbyName(rpt, PrinterName)

            If TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                '處理 Excel 物件列印
                Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
                If objApp.ActiveSheet IsNot Nothing Then
                    Dim objWS As Worksheet = objApp.ActiveSheet()
                    objWS.PrintOut(Preview:=False)

                    Try
                        rpt.DisplayAlerts = False
                        Dim strVer = rpt.Version
                        Dim iHandle = IntPtr.Zero

                        Dim intPID As Integer
                        If CInt(strVer) > 9 Then
                            iHandle = New IntPtr(CType(rpt.Parent.Hwnd, Integer))
                        Else
                            iHandle = FindWindow(Nothing, rpt.Caption)
                        End If
                        rpt.Workbooks.Close()
                        rpt.Quit()
                        Runtime.InteropServices.Marshal.ReleaseComObject(rpt)
                        rpt = Nothing
                        Dim intResult = GetWindowThreadProcessId(iHandle, intPID)
                        Dim proc = System.Diagnostics.Process.GetProcessById(intPID)
                        proc.Kill()
                    Catch ex As Exception
                    End Try
                  
                Else
                    Throw New RPTBusinessException("RPTCMMA006")
                End If

            ElseIf TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then
                '處理 Word 物件列印
                Dim objApp As Microsoft.Office.Interop.Word.Application = rpt
                If objApp.ActiveDocument IsNot Nothing Then
                    Dim wrdDoc As Document = objApp.ActiveDocument
                    wrdDoc.PrintOut(Background:=False)
                    Try

                        If wrdDoc IsNot Nothing Then wrdDoc.Close(WdSaveOptions.wdDoNotSaveChanges)

                        If objApp IsNot Nothing Then
                            objApp.Quit(SaveChanges:=WdSaveOptions.wdDoNotSaveChanges)
                            objApp = Nothing
                        End If


                    Catch ex As Exception
                    End Try
                Else
                    Throw New RPTBusinessException("RPTCMMA006")
                End If
            ElseIf TypeOf rpt Is FileInfo Then
                If CType(rpt, FileInfo).Extension.ToLower = ".rtf" Then
                    PrintRtfFile(rpt, "-p")
                Else
                    If reportType = "Img" Then
                        PrintTxtFileImg(rpt, "-p")
                    Else
                        PrintTxtFile(rpt, "-p")
                    End If
                End If

                '檔案路徑
            ElseIf TypeOf rpt Is System.String Then
                'Sean  暫時先用
                printFile(rpt, "-p")
            End If

        End If
    End Sub
    ''' <summary>
    ''' 針對txt含有圖檔輸出列印到印表機
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub PrintOutImg(ByRef rpt As Object, ByRef PrinterName As String)
        If rpt IsNot Nothing Then
            '設定  active printer
            setActivePrinterbyName(rpt, PrinterName)
            PrintTxtFileImg(rpt, "-p")

        End If
    End Sub


#End Region

#End Region

#Region "     產生報表的相關Info - 無須異動 "

    ''' <summary>
    ''' 產生報表的相關Info - 無須異動
    ''' </summary>
    ''' <param name="report">報表的邏輯檔</param>
    ''' <param name="rptInfo">查詢得到的ReportInfoClient</param>
    ''' <remarks></remarks>
    Public Sub getReportInfo(ByRef report As IReport, ByRef rptInfo As ReportInfoClient)

        Try

            '設定相關資料
            report.reportId = rptInfo.reportId '報表代碼
            report.reportTitle = rptInfo.reportTitle '報表抬頭
            report.printerName = rptInfo.printerName  '印表機名稱
            report.PrinterType = rptInfo.PrinterType  '報表型態
            report.PrinterCond = rptInfo.PrinterCond '報表條件
            report.hospital_CH = rptInfo.hospital_CH '醫院中文名稱
            report.hospital_EN = rptInfo.hospital_EN  '醫院英文名稱
            report.Language_Type_Id = rptInfo.Language_Type_Id '中英文類別(1-中文; 2-英文)
            report.Hospital_Code = rptInfo.Hospital_Code '醫院代碼
            report.Effect_Date = rptInfo.Effect_Date '生效日期
            report.End_Date = rptInfo.End_Date '結束日期
            report.Hospital_Name = rptInfo.Hospital_Name '醫院名稱
            report.Hospital_Short_Name = rptInfo.Hospital_Short_Name '醫院簡稱
            report.Telephone = rptInfo.Telephone '電話
            report.Fax = rptInfo.Fax '傳真
            report.Voice_Tel = rptInfo.Voice_Tel '電腦語音專線
            report.Postal_Code = rptInfo.Postal_Code '郵遞區號
            report.Address = rptInfo.Address '聯絡地址
            report.Principal_Name = rptInfo.Principal_Name '負責人姓名
            report.Principal_Email = rptInfo.Principal_Email '負責人Email
            report.Hospital_Level_Id = rptInfo.Hospital_Level_Id '醫療院所層級(A-醫學中心; B-區域醫院; C-地區醫院; D-基層院所)
            report.URL = rptInfo.URL '網址
            report.Unified_Business_No = rptInfo.Unified_Business_No '醫院統編
            report.Alarm_Count = rptInfo.Alarm_Count                   '警示筆數
            gblReportAlarmCount = rptInfo.Alarm_Count '設定警示筆數，供iReportClient 判斷使用
            report.System_Code = rptInfo.System_Code    '系統別(ex. CNC、OMO....)
            report.Report_Desc = rptInfo.Report_Desc    '描述說明

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


#Region " 事件 "

#Region " 將列印報表、預覽報表的資料 新增至 PUB_Print_Record "

    Private Sub InsertPUBPrintRecord(ByVal data As DataSet)

        Dim ds As New DataSet

        ds = genDataSet(ds, "PUB_Print_Record", New String() {"Report_ID", "Rpt_Count", "Create_User", "Create_Time", "Report_Name", "Print_IP", "Print_Machine_Name"})
        Dim InsertPUBPrintRecord_Row As DataRow = ds.Tables("PUB_Print_Record").NewRow
        InsertPUBPrintRecord_Row("Report_ID") = NewreportId
        InsertPUBPrintRecord_Row("Rpt_Count") = data.Tables(0).Rows.Count
        InsertPUBPrintRecord_Row("Create_User") = AppContext.userProfile.userId
        InsertPUBPrintRecord_Row("Create_Time") = Now
        InsertPUBPrintRecord_Row("Report_Name") = ""
        InsertPUBPrintRecord_Row("Print_IP") = AppContext.userProfile.userIP
        InsertPUBPrintRecord_Row("Print_Machine_Name") = ""
        ds.Tables("PUB_Print_Record").Rows.Add(InsertPUBPrintRecord_Row)

        Dim count As Integer = Pub.insertRPTPrintClient(ds)

        If count = 0 Then
            MessageHandling.ShowWarnMsg("CMMCMMB302", New String() {"新增"})
        End If

    End Sub

#End Region

#End Region


#Region " 內部功能 "

#Region " 列印報表 "

#Region " 列印 RichTextFile 檔案 "

    ''' <summary>
    ''' 列印 RichTextFile 檔案
    ''' </summary>
    ''' <param name="rpt">列印物件</param>
    ''' <param name="printType">列印方式</param>
    ''' <remarks>    
    ''' </remarks>
    ''' -p:直接列印
    ''' "" 是預覽列印
    Private Sub PrintRtfFile(ByRef rpt As Object, ByRef printType As String)
        Dim process As New System.Diagnostics.Process

        Try

            Dim fullFileName As String = CType(rpt, FileInfo).FullName
            Dim compiler As New System.Diagnostics.ProcessStartInfo("""" & My.Application.Info.DirectoryPath & "\TxtPrint\RtfPreview.exe " & """", printType.Trim & " " & """" & fullFileName & """")
            compiler.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            compiler.CreateNoWindow = True
            compiler.UseShellExecute = False
            compiler.RedirectStandardOutput = True
            process.Start(compiler)
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw ex
        Finally
            If (process IsNot Nothing) Then
                process.Close()
                process.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region " 列印TXT檔案 "

    ''' <summary>
    ''' 列印TXT檔案
    ''' </summary>
    ''' <param name="rpt">列印物件</param>
    ''' <param name="printType">列印方式：-p:直接列印，default：是預覽列印</param>
    ''' <remarks>
    ''' -p:直接列印
    ''' default是預覽列印
    ''' </remarks>
    Private Sub PrintTxtFile(ByRef rpt As Object, ByRef printType As String)
        Dim process As System.Diagnostics.Process = Nothing
        Try
            process = New Process
            Dim fullFileName As String = CType(rpt, FileInfo).FullName
            '---add on 20160115 By Lits 暫時解決OPDPrinter
            If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_Kmuh Then
                Dim fileObj = New IO.FileInfo(fullFileName)
                SetOPDPrinterToTxtFile(fileObj)
            End If
            '-------------------------------------------------

            process.Start(My.Application.Info.DirectoryPath & "\TxtPrint\TxtPreview.exe", printType & " " & fullFileName)
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw ex
        Finally
            If (process IsNot Nothing) Then
                process.Close()
                process.Dispose()
            End If
        End Try
    End Sub



    'add on 20160115 By Lits 暫時解決OPDPrinter
    Protected Function SetOPDPrinterToTxtFile(ByRef rpt As FileInfo) As FileInfo


        Try
            '取得第一列資料
            Dim sw As New StringWriter
            Dim strContents As String = ""
            Dim strContents_1 As String = ""
            Dim _array As Array
            Dim objReader As New StreamReader(rpt.FullName)

            _array = (objReader.ReadLine).Split(";")
            If _array(0) = "" Then ' Or _array(0).ToString.ToLower <> "opdprinter" Then
                _array(0) = "OPDPrinter"


                strContents = objReader.ReadToEnd()
                objReader.Close()

                strContents_1 += _array(0)
                For i As Int16 = 1 To _array.Length - 1
                    strContents_1 = strContents_1 + ";" + _array(i)
                Next
                strContents_1 = strContents_1 + vbCrLf + strContents


                '覆蓋第一列資料
                Dim objWriter As New StreamWriter(rpt.FullName, False, Encoding.Unicode)
                objWriter.Write(strContents_1)
                objWriter.Close()
            End If
            Return rpt
        Catch
            Throw New Exception
        End Try
    End Function

#End Region

#Region " 列印TXT檔案包含圖檔列印 "


    ''' <summary>
    ''' 列印TXT檔案包含圖檔列印
    ''' </summary>
    ''' <param name="rpt">列印物件</param>
    ''' <param name="printType">列印方式：-p:直接列印；無預覽列印</param>
    ''' <remarks>
    ''' -p:直接列印
    ''' 無預覽列印
    ''' </remarks>
    Private Sub PrintTxtFileImg(ByRef rpt As Object, ByRef printType As String)
        Dim process As System.Diagnostics.Process = Nothing
        Try
            Dim fullFileName As String = CType(rpt, FileInfo).FullName
            '---add on 20160115 By Lits 暫時解決OPDPrinter
            If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_Kmuh Then
                Dim fileObj = New IO.FileInfo(fullFileName)
                SetOPDPrinterToTxtFile(fileObj)
            End If
            '-------------------------------------------------
            If printType <> "" Then
                process = New Process
                process.Start("""" & My.Application.Info.DirectoryPath & "\TxtPrint\EFSPic.exe " & """", printType.Trim & " " & """" & fullFileName & """")
            Else
                Dim p As New StartProcess
                p.Start("""" & My.Application.Info.DirectoryPath & "\TxtPrint\EFSPic.exe " & """", printType.Trim & " " & """" & fullFileName & """", 5)

            End If

        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw ex
        Finally
            If (process IsNot Nothing) Then
                process.Close()
                process.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region " 列印html檔案 "

    ''' <summary>
    ''' 列印html檔案
    ''' </summary>
    ''' <param name="rpt">列印物件</param>
    ''' <param name="inRptType">列印方式：-p:直接列印，default：是預覽列印</param>
    ''' <param name="inHtmlFile">Html檔名</param>
    ''' <remarks>
    ''' -p:直接列印
    ''' default是預覽列印
    ''' </remarks>
    Private Sub PrintHtmlFile(ByRef rpt As Object, ByRef inRptType As String, ByRef inHtmlFile As String)
        Dim pvtPath As String = My.Application.Info.DirectoryPath
        Dim process As System.Diagnostics.Process = Nothing

        Try
            process = New Process

            '若為html則更改txt檔名為html
            If inRptType = "" Then
                Dim fullFileName As String = CType(rpt, FileInfo).FullName
                Dim NewFileName As String = fullFileName.Replace(".txt", ".html")
                Dim fi As New FileInfo(fullFileName)
                fi.MoveTo(NewFileName)

                process.Start(NewFileName)
            Else
                process.Start(pvtPath & "\" & inHtmlFile)
            End If
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw ex
        Finally
            If (process IsNot Nothing) Then
                process.Close()
                process.Dispose()
            End If
        End Try
    End Sub
#End Region

#Region " 列印html檔案(For圖檔) "

    ''' <summary>
    ''' 列印html檔案(For圖檔)
    ''' </summary>
    Private Sub PrintHtmlImgFile(ByRef rpt As Object)
        Dim pvtPath As String = My.Application.Info.DirectoryPath
        Dim pvthtmlFile As String = "ViewReport.htm"

        Try
            '先在Local端產生圖檔
            PrintTxtFileImg(rpt, "-g")

            '產生html檔
            Dim filename As String = "TxtPrint."
            Dim sw As StreamWriter = New StreamWriter(pvtPath & "\" & pvthtmlFile)

            sw.Write("<!DOCTYPE html> ")
            sw.WriteLine("<html lang=""zh-TW"">")
            sw.WriteLine("<head>")
            sw.WriteLine("<meta charset=""utf-8"" />")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            '取得圖檔路徑與名稱
            For Each filetmp As String In My.Computer.FileSystem.GetFiles(pvtPath, _
                                                                          FileIO.SearchOption.SearchTopLevelOnly, _
                                                                          "*.jpg")
                If filetmp.Replace(pvtPath & "\", "").Substring(0, filename.Length) = filename Then
                    sw.WriteLine("<img src=""" & filetmp & """ >")
                End If
            Next

            sw.WriteLine("</body>")
            sw.WriteLine("</html>")

            sw.Close()

            '開啟html檔
            PrintHtmlFile(rpt, "Img", pvthtmlFile)

        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw ex
        End Try

    End Sub


#End Region

#End Region

#Region " 預覽報表 -  主要邏輯 "

    Public Sub ActivateDocumentWindow(ByVal a_strDocName As String)
        Dim Alllocal As Process() = Process.GetProcesses()
        Dim Item As Process

        'Loop through all processes to locate and activate our document
        For Each Item In Alllocal
            'if the main title is not blank 
            If Item.MainWindowTitle.ToString <> "" Then
                If InStr(Item.MainWindowTitle.ToString, a_strDocName) > 0 Then
                    Dim intOurDoc As Integer = Item.Id
                    AppActivate(intOurDoc)
                    Exit For
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' 預覽報表 - 主要邏輯
    ''' </summary>
    ''' <param name="rpt">報表</param>
    ''' <remarks></remarks>
    Private Sub previewReport(ByRef rpt As Object)

        Try

            If rpt IsNot Nothing Then
                If TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                    'Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
                    'objApp.Visible = True
                    'objApp.BringToFront()
                    '2015-01-05 Sean 將Word 推到畫面最前端
                    rpt.Visible = True
                    'rpt.Activate()
                    'rpt.BringToFront()
                    
                    rpt.WindowState = 1


                ElseIf TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then

                    '2015-01-05 Sean 將Word 推到畫面最前端
                    rpt.Visible = True
                    'rpt.Activate()
                    'rpt.BringToFront()
                    Dim strFilename As String = rpt.Documents.Parent.ActiveWindow.Caption
                    'strFilename = CreateObject("scripting.filesystemobject").getbasename(rpt.Name)
                    rpt.WindowState = 1
                    ActivateDocumentWindow(strFilename)
                ElseIf TypeOf rpt Is FileInfo Then
                    If CType(rpt, FileInfo).Extension.ToLower = ".rtf" Then
                        PrintRtfFile(rpt, "")

                    Else
                        If reportType = "Img" Then
                            PrintTxtFileImg(rpt, "")
                        ElseIf reportType = "htmlImg" Then
                            PrintHtmlImgFile(rpt)
                        ElseIf reportType = "html" Then
                            PrintHtmlFile(rpt, "", "")

                        Else
                            PrintTxtFileImg(rpt, "")
                        End If
                    End If

                    '檔案路徑
                ElseIf TypeOf rpt Is System.String Then
                    previewFile(rpt)
                End If
            Else
                Throw New RPTBusinessException("RPTCMMA006")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub previewtxtReport(ByRef rpt As Object)

        Try

            If rpt IsNot Nothing Then
                If TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                    'Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
                    'objApp.Visible = True
                    'objApp.BringToFront()
                    '2015-01-05 Sean 將Word 推到畫面最前端
                    rpt.Visible = True
                    'rpt.Activate()
                    'rpt.BringToFront()
                    rpt.WindowState = 1

                ElseIf TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then

                    '2015-01-05 Sean 將Word 推到畫面最前端
                    rpt.Visible = True
                    'rpt.Activate()
                    'rpt.BringToFront()
                    rpt.WindowState = 1

                ElseIf TypeOf rpt Is FileInfo Then
                    If CType(rpt, FileInfo).Extension.ToLower = ".rtf" Then
                        PrintRtfFile(rpt, "")

                    Else
                        If reportType = "Img" Then
                            PrintTxtFileImg(rpt, "")
                        ElseIf reportType = "htmlImg" Then
                            PrintHtmlImgFile(rpt)
                        ElseIf reportType = "html" Then
                            PrintHtmlFile(rpt, "", "")

                        Else
                            PrintTxtFile(rpt, "")
                        End If
                    End If

                    '檔案路徑
                ElseIf TypeOf rpt Is System.String Then
                    previewFile(rpt)
                End If
            Else
                Throw New RPTBusinessException("RPTCMMA006")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region " 預覽報表 - by 路徑 "

    ''' <summary>
    ''' 預覽報表 - by 路徑
    ''' </summary>
    ''' <param name="filePath">檔案路徑</param>
    ''' <remarks>by Sean.Lin on 2015-10-06</remarks>
    Private Sub previewFile(ByVal filePath As String)

        Try

            '預設 Process
            Dim p As Process = Nothing

            ''MessageBox.Show("開啟的位置:" & FileName)
            p = System.Diagnostics.Process.Start(filePath)

            'System.Diagnostics.Process.Start("Iexplore.exe", pdfPath)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"預覽檔案 - by 路徑"})

        End Try

    End Sub

#End Region

#Region " 列印報表 - by 路徑 "

    ''' <summary>
    ''' 列印報表 - by 路徑
    ''' </summary>
    ''' <param name="filePath">檔案路徑</param>
    ''' <param name="printType">列印方式：-p:直接列印，default：是預覽列印</param>
    ''' <remarks>by Sean.Lin on 2015-10-06</remarks>
    Private Sub printFile(ByVal filePath As String, ByRef printType As String)


        Dim psiPrint As New System.Diagnostics.ProcessStartInfo()
        Try


            psiPrint.Verb = "print"
            psiPrint.WindowStyle = ProcessWindowStyle.Hidden
            psiPrint.FileName = filePath
            psiPrint.UseShellExecute = True
            System.Diagnostics.Process.Start(psiPrint)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"列印檔案 - by 路徑"})
        Finally

            psiPrint = Nothing
        End Try

    End Sub

#End Region

#Region " 檢查Rpt有無資料"

#Region " 檢查Rpt有無資料 - ds.Tables(0)，True：有值可列印；False：無值可列印 "

    ''' <summary>
    ''' 檢查Rpt有無資料 - ds.Tables(0)，True：有值可列印；False：無值可列印
    ''' </summary>
    ''' <param name="ds">表單資料的DS</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <remarks>by Sean.Lin on 2015-09-08</remarks>
    Protected Function CheckRptHasData(ByVal ds As DataSet, Optional showWarnFlag As Boolean = True) As Boolean

        Try

            If CheckMethodUtil.CheckHasTable(ds) Then
                Return CheckRptHasData(ds.Tables(0), showWarnFlag)
            Else

                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無 Table 可列印!")
                Return False

            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查Rpt有無資料 - ds.Tables(0)"})
        End Try

    End Function

#End Region

#Region " 檢查Rpt有無資料 - ds + TableName，True：有值可列印；False：無值可列印 "

    ''' <summary>
    ''' 檢查Rpt有無資料 - ds + TableName，True：有值可列印；False：無值可列印
    ''' </summary>
    ''' <param name="ds">表單資料的DS</param>
    ''' <param name="tableName">列印的Table Name</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <remarks>by Sean.Lin on 2015-09-08</remarks>
    Protected Function CheckRptHasData(ByVal ds As DataSet, ByVal tableName As String, Optional showWarnFlag As Boolean = True) As Boolean

        Try

            If CheckMethodUtil.CheckHasTable(ds, tableName) Then
                Return CheckRptHasData(ds.Tables(tableName), showWarnFlag)
            Else

                MessageHandling.ShowWarnMsg("CMMCMMB300", "查無 Table 可列印!")
                Return False

            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查Rpt有無資料 - ds + TableName"})

        End Try

    End Function

#End Region

#Region " 檢查Rpt有無資料 - ds + TableName Array，True：有值可列印；False：無值可列印 "

    ''' <summary>
    ''' 檢查Rpt有無資料 - ds + TableName Array，True：有值可列印；False：無值可列印
    ''' </summary>
    ''' <param name="ds">表單資料的DS</param>
    ''' <param name="tableNameArray">Table Name 的 Array</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <remarks>by Sean.Lin on 2015-09-08</remarks>
    Protected Function CheckRptHasData(ByVal ds As DataSet, ByVal tableNameArray As String(), Optional showWarnFlag As Boolean = True) As Boolean

        Try
            Dim errorString As New StringBuilder
            Dim returnFlag As Boolean = True

            For Each tableName As String In tableNameArray

                If CheckMethodUtil.CheckHasTable(ds, tableName) Then

                    If CheckMethodUtil.CheckHasValue(ds, tableName) Then

                    Else
                        '查無資料
                        errorString.Append("TableName： " & tableName & " 無資料!")

                        returnFlag = False
                    End If

                Else

                    errorString.Append("TableName： " & tableName & " 不存在!")

                    returnFlag = False

                End If

            Next

            '有查無資料與必須提示
            If returnFlag = False And showWarnFlag = True Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", errorString.ToString)
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查Rpt有無資料 - ds + TableName"})

        End Try

    End Function

#End Region

#Region " 檢查Rpt有無資料 "

    ''' <summary>
    ''' 檢查Rpt有無資料，True：有值可列印；False：無值可列印
    ''' </summary>
    ''' <param name="dt">表單資料的DT</param>
    ''' <param name="showWarnFlag">是否提示查無資料，True：提示，False：不提示</param>
    ''' <remarks>by Sean.Lin on 2015-09-08</remarks>
    Protected Function CheckRptHasData(ByVal dt As System.Data.DataTable, Optional showWarnFlag As Boolean = True) As Boolean

        Try

            If CheckMethodUtil.CheckHasValue(dt) Then

                Return True

            ElseIf dt Is Nothing Then

                '提示不可return nothing
                MessageHandling.ShowWarnMsg("CMMCMMB300", "不可return nothing!")
                Return False

            ElseIf showWarnFlag = True Then
                '查無資料，且需要提示
                MessageHandling.ShowWarnMsg("CMMCMMB933")
                Return False

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查Rpt有無資料 - dt"})

        End Try

    End Function

#End Region

#End Region

#Region " 產生DataSet "

    ''' <summary>
    ''' 產生DataSet
    ''' </summary>
    ''' <param name="saveData"></param>
    ''' <param name="tableName"></param>
    ''' <param name="columnNameDB"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function

#End Region

#End Region






End Class

