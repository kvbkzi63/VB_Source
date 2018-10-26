Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports System.Configuration
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Word
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Comm.RPT
Imports Syscom.Server.CMM
Imports Syscom.Server.FTM
Imports Syscom.Server.SNC

Public MustInherit Class IRPTPrintServer
    Inherits IRPTPrint

    Private Shared ReadOnly apTempLocalDir As String = ConfigurationManager.AppSettings.Item("TempFile")
    Private Shared ReadOnly dir As New DirectoryInfo(apTempLocalDir)

    '取得報表資料
    Protected MustOverride Function queryRPTData(ByRef queryCondition As Object()) As DataSet
    '產生報表
    Protected MustOverride Function genReport(ByRef data As DataSet) As Object
    '列印報表
    Protected MustOverride Sub printReport(ByRef rpt As Object)

    '取得報表資料
    Protected Overrides Function _queryRPTData(ByRef queryCondition As Object()) As DataSet
        Return queryRPTData(queryCondition)
    End Function
    '產生報表
    Protected Function _genReport(ByRef data As DataSet) As Object
        Return genReport(data)
    End Function
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
        Return PrinterSelectBO.getInstance.getPrinterName(id, Syscom.Comm.RPT.IRPTPrint.server, printerCondition)
    End Function
    '取得印表機
    Protected Overridable Function getPrinterName(ByRef id As String, ByVal PrinterCondition As String) As String
        Return PrinterSelectBO.getInstance.getPrinterName(id, Syscom.Comm.RPT.IRPTPrint.server, PrinterCondition)
    End Function
    '取得報表列印 JOB ID
    Protected Function getRpt_Print_Job_ID() As String
        Return SNCDelegate.getInstance.getReportSerialNo
    End Function

    ''' <summary>
    ''' 列印報表
    ''' </summary>
    ''' <param name="queryCondition">查詢報表條件</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function print(ByRef queryCondition As Object()) As String
        Try
            '取得報表資料
            Dim data As DataSet = _queryRPTData(queryCondition)
            If data Is Nothing Then
                Throw New RPTBusinessException("RPTCMMA001")
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

    ''' <summary>
    ''' 列印報表
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <returns>Report Job ID</returns>
    ''' <remarks></remarks>
    Public Function print(ByRef data As DataSet) As String
        Dim result As String = ""

        '產生報表
        Dim rpt As Object
        Try
            rpt = _genReport(data)
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
            _printReport(rpt)
        Catch rptex As RPTBusinessException
            Throw rptex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003", ex)
        End Try

        Return result
    End Function

#Region "Office 物件的列印跟關閉 (可以被覆寫)"

    ''' <summary>
    ''' 輸出列印到印表機(先暫時用AP Server列印，後續再移轉)
    ''' </summary>
    ''' <param name="rpt">報表物件</param>
    ''' <param name="PrinterName">印表機名稱</param>
    ''' <param name="medNo">領藥號(藥局 only)</param>
    ''' <param name="conn">傳入以開啟的opd/pub sql conn</param>
    ''' <param name="exFunction1">額外功能1，報表列印分流標簽，藥局固定給 "PH" </param>
    ''' <param name="exFunction2">額外功能2，目前拿來當作部分檔名(daemon server 上的 ok/bad 目錄內的檔名)，ex:藥袋55555555</param>
    ''' <remarks></remarks>
    Public Overridable Sub PrintOut(ByRef rpt As Object, ByRef PrinterName As String, Optional ByRef medNo As String = "", Optional ByRef conn As SqlClient.SqlConnection = Nothing, Optional ByRef exFunction1 As String = "", Optional ByRef exFunction2 As String = "")

        LOGDelegate.getInstance.dbInfoMsg("IRPTPrintServer.PrintOut 開始運作，PrinterName=" & PrinterName & ",medNo=" & medNo)
        If Not dir.Exists Then
            dir.Create()
            'LOGDelegate.getInstance.fileDebugMsg("apTempLocalDir Not Exists Create Now " & apTempLocalDir)
        Else
            'LOGDelegate.getInstance.fileDebugMsg("apTempLocalDir Exists " & apTempLocalDir)
        End If
        If rpt IsNot Nothing Then
            '設定  active printer     
            'LOGDelegate.getInstance.fileDebugMsg("Report Type is " & rpt.GetType().FullName & " ,PrinterName = " & PrinterName)
            If TypeOf rpt Is FileInfo Then 'Txt Report
                Try
                    'Dim fileName = apTempLocalDir & "\" & Now.ToString("yyyyMMdd") & "-" & SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.typeA, "TEXTRPT", 1, 99999) & ".txt"
                    Dim tfile As FileInfo = rpt
                    If tfile.Exists Then
                        SetPrinterNameToTxtFile(rpt, PrinterName)


                        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
                        Dim dataTable As System.Data.DataTable = FileTransferDataFormat.getDataTableWithSchema
                        Dim dataRow As System.Data.DataRow = dataTable.NewRow()
                        dataRow("FID") = 0 '自動續號
                        dataRow("File_Name") = tfile.FullName  '檔案路徑
                        dataRow("Order_Seq") = 1 '顯示順序
                        dataRow("Image_Thumb") = Nothing ' IIf(ImageTool.IsImage(fileName), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(fileName), ImageTool.getFormatByFileName(fileName)), Nothing) '縮圖

                        dataRow("Create_User") = ServerAppContext.userProfile.userId '上傳人員
                        dataRow("Create_Time") = Now '上傳時間
                        dataRow("Modified_User") = ServerAppContext.userProfile.userId '修改人員
                        dataRow("Modified_Time") = Now '修改時間

                        dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(tfile.FullName) '將檔案轉成 byte array
                        dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I

                        If tfile.Extension.ToLower = ".rtf" Then
                            dataRow("File_Note") = "RTF Print" '檔案註解
                            dataRow("FileSub") = "RPTRTF" ' Rich Text File
                        Else
                            dataRow("File_Note") = "Text Print" '檔案註解
                            dataRow("FileSub") = "RPTTXT" ' Text File
                        End If

                        dataRow("FileTime") = Now '指定檔案時間

                        dataTable.Rows.Add(dataRow)
                        dataSet.Tables.Add(dataTable)
                        LOGDelegate.getInstance.dbInfoMsg("FTMDelegate.getInstance.uploadNewFile 開始運作，PrinterName=" & PrinterName & ",medNo=" & medNo)
                        Dim s() = FTMDelegate.getInstance.uploadNewFile(dataSet)
                        LOGDelegate.getInstance.dbInfoMsg("FTMDelegate.getInstance.uploadNewFile 結束運作，PrinterName=" & PrinterName & ",medNo=" & medNo)
                        Dim mqDs As System.Data.DataSet = MessageQueueUtil.getInstance.getReportMessageBody()
                        Dim mqDT As System.Data.DataTable = mqDs.Tables("RPT")
                        Dim mqRow As System.Data.DataRow = mqDT.NewRow()
                        mqRow("Med_NO") = medNo
                        mqRow("ReportID") = getRpt_Print_Job_ID()
                        mqRow("ReportFileFID") = s(0)
                        mqRow("PrinterName") = PrinterName
                        mqRow("PrintUser") = ServerAppContext.userProfile.userId
                        mqDT.Rows.Add(mqRow)
                        LOGDelegate.getInstance.fileDebugMsg("Report File Send Start " & s(0) & " , PrinterName=" & PrinterName & " - " & Now)
                        'nckuh.common.log.LOGDelegate.GetInstance.getDBLogger.Error("medNo " & medNo)
                        'If medNo IsNot Nothing AndAlso (Not "".Equals(medNo)) Then
                        Dim dataSets As DataSet = New DataSet
                        Dim dataTables As System.Data.DataTable = PubPrintSeqReportDataTableFactory.getDataTableWithSchema
                        Dim dataRows As DataRow = dataTables.NewRow()
                        dataRows("Send_Date") = Now
                        dataRows("MedNo") = mqRow("Med_NO")
                        dataRows("ReportID") = mqRow("ReportID")
                        dataRows("ReportFileFID") = mqRow("ReportFileFID")
                        dataRows("Printer_Name") = mqRow("PrinterName")
                        dataRows("PrintUser") = mqRow("PrintUser")

                        dataRows("ExFunction1") = exFunction1
                        dataRows("ExFunction2") = exFunction2

                        dataTables.Rows.Add(dataRows)
                        dataSets.Tables.Add(dataTables)
                        LOGDelegate.getInstance.dbInfoMsg("PubPrintSeqReportBO.GetInstance.insert 開始運作，PrinterName=" & PrinterName & ",medNo=" & medNo & ",FID=" & mqRow("ReportFileFID"))
                        PubPrintSeqReportBO.GetInstance.insert(dataSets, conn)
                        LOGDelegate.getInstance.dbInfoMsg("PubPrintSeqReportBO.GetInstance.insert 結束運作，PrinterName=" & PrinterName & ",medNo=" & medNo & ",FID=" & mqRow("ReportFileFID"))
                        'Else
                        '    MessageQueueUtil.getInstance.sendReportMessage(mqDs)
                        'End If

                        LOGDelegate.getInstance.fileDebugMsg("Report File Send End " & s(0) & " , PrinterName=" & PrinterName & " - " & Now)
                        tfile.Delete()

                    End If
                Catch cmex As CommonException
                    Throw cmex
                Catch ex As Exception
                    Throw New CommonException("CMMCMMD001", ex)
                End Try
            ElseIf TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then ' Excel Report
                Try
                    '處理 Excel 物件列印          

                    Dim fileName = apTempLocalDir & "\" & Now.ToString("yyyyMMdd") & "-" & SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeA, "EXCELRPT", 1, 99999) & ".xls"
                    Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
                    objApp.Visible = False
                    If objApp.ActiveWorkbook IsNot Nothing Then
                        LOGDelegate.getInstance.fileDebugMsg("objApp.ActiveSheet.SaveCopyAs " & fileName)
                        Try
                            objApp.ActiveWorkbook.SaveCopyAs(fileName)
                            LOGDelegate.getInstance.fileDebugMsg("objApp.ActiveWorkbook.SaveCopyAs Success")
                        Catch cmex As CommonException
                            Throw cmex
                        Catch ex As Exception
                            Throw New CommonException("CMMCMMD001", ex)
                        End Try
                        FinishWork(rpt)
                        LOGDelegate.getInstance.fileDebugMsg("FinishWork")
                        Dim xlsDocFile = New FileInfo(fileName)
                        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
                        Dim dataTable As System.Data.DataTable = FileTransferDataFormat.getDataTableWithSchema
                        Dim dataRow As System.Data.DataRow = dataTable.NewRow()

                        dataRow("File_Name") = fileName '檔案路徑
                        dataRow("Order_Seq") = 1 '顯示順序
                        dataRow("Image_Thumb") = Nothing 'IIf(ImageTool.IsImage(fileName), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(fileName), ImageTool.getFormatByFileName(fileName)), Nothing) '縮圖
                        dataRow("File_Note") = "Excel Print" '檔案註解
                        dataRow("Create_User") = ServerAppContext.userProfile.userId '上傳人員
                        dataRow("Create_Time") = Now '上傳時間
                        dataRow("Modified_User") = ServerAppContext.userProfile.userId '修改人員
                        dataRow("Modified_Time") = Now '修改時間

                        dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(fileName) '將檔案轉成 byte array
                        dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
                        dataRow("FileSub") = "RPTXLS" ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
                        dataRow("FileTime") = Now '指定檔案時間

                        dataTable.Rows.Add(dataRow)
                        dataSet.Tables.Add(dataTable)

                        Dim s() = FTMDelegate.getInstance.uploadNewFile(dataSet)

                        Dim mqDs As System.Data.DataSet = MessageQueueUtil.getInstance.getReportMessageBody()
                        Dim mqDT As System.Data.DataTable = mqDs.Tables("RPT")
                        Dim mqRow As System.Data.DataRow = mqDT.NewRow()
                        mqRow("Med_NO") = medNo
                        mqRow("ReportID") = getRpt_Print_Job_ID()
                        mqRow("ReportFileFID") = s(0)
                        mqRow("PrinterName") = PrinterName
                        mqRow("PrintUser") = ServerAppContext.userProfile.userId
                        'If medNo IsNot Nothing AndAlso "" <> medNo Then
                        Dim dataSets As DataSet = New DataSet
                        Dim dataTables As DataTable = PubPrintSeqReportDataTableFactory.getDataTableWithSchema
                        Dim dataRows As DataRow = dataTable.NewRow()
                        dataRow("Send_Date") = Now
                        dataRow("MedNo") = mqRow("Med_NO")
                        dataRow("ReportID") = mqRow("ReportID")
                        dataRow("ReportFileFID") = mqRow("ReportFileFID")
                        dataRow("Printer_Name") = mqRow("PrinterName")
                        dataRow("PrintUser") = mqRow("PrintUser")
                        dataTable.Rows.Add(dataRow)
                        dataSet.Tables.Add(dataTable)
                        PubPrintSeqReportBO.GetInstance.insert(dataSet, conn)
                        'Else
                        '    MessageQueueUtil.getInstance.sendReportMessage(mqDs)
                        'End If
                        'FinishWork(rpt)
                        xlsDocFile.Delete()

                    Else
                        Throw New RPTBusinessException("RPTCMMA006")
                    End If
                Catch rex As RPTBusinessException
                    Throw rex
                Catch cmex As CommonException
                    Throw cmex
                Catch ex As Exception
                    Throw New CommonException("CMMCMMD001", ex)
                End Try
            ElseIf TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then ' Word Report\
                Throw New Exception("暫時無法處理WORD後端列印")
                'Try
                '處理 Word 物件列印
                'Dim fileName = apTempLocalDir & "\" & Now.ToString("yyyyMMdd") & "-" & SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.typeA, "WORDRPT", 1, 99999) & ".doc"
                'Dim objApp As Microsoft.Office.Interop.Word.Application = rpt
                'objApp.Visible = False
                'If objApp.ActiveDocument IsNot Nothing Then
                '    Dim wrdDoc As Document = objApp.ActiveDocument

                '    log.Error("objApp.ActiveDocument SaveAs " & fileName)
                '    Try

                '        For i = 0 To 20
                '            Try
                '                wrdDoc.SaveAs(fileName, i, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                '                log.Error(i & " success")
                '                Exit For
                '            Catch ex As Exception
                '                log.Error(i & " Exception")
                '            End Try

                '        Next

                '        'wrdDoc.SaveAs(FileName:=fileName, FileFormat:=WdSaveFormat.wdFormatRTF)
                '    Catch ex As Exception
                '        log.Error(ex)
                '        log.Error("objApp.ActiveDocument Save as  Fail")
                '        Throw ex
                '    End Try

                '    wrdDoc = Nothing
                '    FinishWork(rpt)
                '    Dim wrdDocFile = New FileInfo(fileName)
                '    Dim dataSet As System.Data.DataSet = New System.Data.DataSet
                '    Dim dataTable As System.Data.DataTable = FileTransferDataFormat.getDataTableWithSchema
                '    Dim dataRow As System.Data.DataRow = dataTable.NewRow()

                '    dataRow("File_Name") = fileName '檔案路徑
                '    dataRow("Order_Seq") = 1 '顯示順序
                '    dataRow("Image_Thumb") = Nothing 'IIf(ImageTool.IsImage(fileName), ImageTool.convertImageToByteArray(ImageTool.getThumbnailImage(fileName), ImageTool.getFormatByFileName(fileName)), Nothing) '縮圖
                '    dataRow("File_Note") = "Word Print" '檔案註解
                '    dataRow("Create_User") = "RPTModule" '上傳人員
                '    dataRow("Create_Time") = Now '上傳時間
                '    dataRow("Modified_User") = "RPTModule" '修改人員
                '    dataRow("Modified_Time") = Now '修改時間

                '    dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(fileName) '將檔案轉成 byte array
                '    dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
                '    dataRow("FileSub") = "RPTDOC" ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
                '    dataRow("FileTime") = Now '指定檔案時間

                '    dataTable.Rows.Add(dataRow)
                '    dataSet.Tables.Add(dataTable)

                '    Dim s() = FTMDelegate.getInstance.uploadNewFile(dataSet)

                '    Dim mqDs As System.Data.DataSet = MessageQueueUtil.getInstance.getReportMessageBody()
                '    Dim mqDT As System.Data.DataTable = mqDs.Tables("RPT")
                '    Dim mqRow As System.Data.DataRow = mqDT.NewRow()
                '    mqRow("ReportID") = getRpt_Print_Job_ID()
                '    mqRow("ReportFileFID") = s(0)
                '    mqRow("PrinterName") = PrinterName
                '    MessageQueueUtil.getInstance.sendReportMessage(mqDs)
                '    'FinishWork(rpt)
                '    wrdDocFile.Delete()
                'Else
                '    Throw New RPTBusinessException("RPTCMMA006")
                'End If
                '    Catch rex As RPTBusinessException
                '        Throw rex
                '    Catch ex As Exception
                '        log.Error(ex)
                '        Throw ex
                '    End Try
            Else
                Throw New RPTBusinessException("RPTCMMA006")
            End If
        End If
        LOGDelegate.getInstance.dbInfoMsg("IRPTPrintServer.PrintOut 結束運作，PrinterName=" & PrinterName & ",medNo=" & medNo)
    End Sub

    ''' <summary>
    ''' 將印表機名稱加入txt File中
    ''' </summary>
    ''' <param name="rpt">txt 檔</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function SetPrinterNameToTxtFile(ByRef rpt As FileInfo, ByRef printerName As String) As FileInfo
        'Return SetPrinterNameToTxtFile(rpt, printerName, System.Text.Encoding.GetEncoding("big5"))
        Return SetPrinterNameToTxtFile(rpt, printerName, System.Text.Encoding.Unicode)
    End Function

    ''' <summary>
    ''' 寫入Txt File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Overrides Function WriteTxtFile(ByRef reportData As String, ByRef reportId As String) As FileInfo
        '        Return WriteTxtFile(reportData, reportId, System.Text.Encoding.GetEncoding("big5"))
        Return WriteTxtFile(reportData, reportId, System.Text.Encoding.Unicode)
    End Function

#End Region

End Class
