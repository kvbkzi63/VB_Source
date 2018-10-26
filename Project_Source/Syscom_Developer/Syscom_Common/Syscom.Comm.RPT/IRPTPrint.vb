'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表列印抽象類別
'*              Title:	IRPTPrint
'*        Description:	報表列印抽象類別，為所有 Server/Client 中報表列印類別提供基底內容
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-03-10
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-03-10
'*
'*****************************************************************************
'*/

Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop.Excel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP

''' <summary>
''' 報表列印抽象類別，為所有 Server/Client 中報表列印類別提供基底內容
''' </summary>
''' <remarks></remarks>
Public MustInherit Class IRPTPrint

    Public Shared ReadOnly client As Integer = 1
    Public Shared ReadOnly server As Integer = 2
    Private Shared rand As New Random(CInt(Now.ToString("fffff")))
    Protected printerCondition As Object

    '取得報表所需資料
    Protected MustOverride Function _queryRPTData(ByRef queryCondition As Object()) As DataSet
    ''產生報表
    'Protected MustOverride Function _genReport(ByRef data As DataSet) As Object
    '取得印表機
    Protected MustOverride Function _getPrinterName(ByRef id As String) As String
    '取得報表列印 JOB ID
    Protected MustOverride Function _getRpt_Print_Job_ID() As String
    '列印報表
    Protected MustOverride Sub _printReport(ByRef rpt As Object)

    ' ''' <summary>
    ' ''' 列印報表
    ' ''' </summary>
    ' ''' <param name="queryCondition">查詢報表條件</param>
    ' ''' <returns>Report Job ID</returns>
    ' ''' <remarks></remarks>
    'Public Function print(ByRef queryCondition As Object()) As String
    '    Try
    '        '取得報表資料
    '        Dim data As DataSet = _queryRPTData(queryCondition)
    '        If data Is Nothing Then
    '            Throw New RPTBusinessException("RPTCMMA001")
    '        End If

    '        '列印報表   
    '        Return print(data)
    '    Catch rptex As RPTBusinessException
    '        Throw rptex
    '    Catch cmex As CommonException
    '        Throw cmex
    '    Catch ex As Exception
    '        Throw New RPTBusinessException("RPTCMMA001", ex)
    '    End Try
    'End Function

    ' ''' <summary>
    ' ''' 列印報表
    ' ''' </summary>
    ' ''' <param name="data">報表資料</param>
    ' ''' <returns>Report Job ID</returns>
    ' ''' <remarks></remarks>
    'Public Function print(ByRef data As DataSet) As String
    '    Dim result As String = ""

    '    '產生報表
    '    Dim rpt As Object
    '    Try
    '        rpt = _genReport(data)
    '    Catch rptex As RPTBusinessException
    '        Throw rptex
    '    Catch cmex As CommonException
    '        Throw cmex
    '    Catch ex As Exception
    '        Throw New RPTBusinessException("RPTCMMA002", ex)
    '    End Try

    '    '列印報表
    '    Try
    '        result = _getRpt_Print_Job_ID()
    '        _printReport(rpt)
    '    Catch rptex As RPTBusinessException
    '        Throw rptex
    '    Catch cmex As CommonException
    '        Throw cmex
    '    Catch ex As Exception
    '        Throw New RPTBusinessException("RPTCMMA003", ex)
    '    End Try

    '    Return result
    'End Function

    ''' <summary>
    ''' 設定 Office Word/Excel 物件的 ActivePrinter 
    ''' </summary>
    ''' <param name="rpt">Word/Excel 物件</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <remarks></remarks>
    Protected Overridable Sub setActivePrinterbyName(ByRef rpt As Object, ByRef printerName As String)
        Try
            Dim defaultPrinter As String = ""

            If TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then
                defaultPrinter = rpt.ActivePrinter
            ElseIf TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                defaultPrinter = rpt.ActivePrinter
            Else
                Dim pd As New PrintDocument
                defaultPrinter = pd.PrinterSettings.PrinterName
                pd.Dispose()
                pd = Nothing
            End If

            Dim foundName As Boolean = False
            Dim foundActivePrinterName As Boolean = False

            If PrinterSettings.InstalledPrinters.Count > 0 Then
                For i As Integer = 0 To (PrinterSettings.InstalledPrinters.Count - 1)
                    '先找系統內，有無該印表機名稱
                    If printerName = (PrinterSettings.InstalledPrinters.Item(i)) Then
                        foundName = True
                        Exit For
                    End If
                Next
            Else
                '系統未安裝任何印表機
                Throw New RPTBusinessException("RPTCMMA010")
            End If

            '找不到印表機，使用預設印表機
            If Not foundName Then
                printerName = defaultPrinter
            End If

            If Not setActivePrinter(rpt, printerName) Then
                '初始的印表機名稱，無法設定 Active 印表機
                Throw New RPTBusinessException("RPTCMMA007")
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA009", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定 Office Word/Excel 物件的 ActivePrinter 
    ''' </summary>
    ''' <param name="rpt">Word/Excel 物件</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <returns>設定成功 true，反之 False</returns>
    ''' <remarks>這個method 主要是提供給setActivePrinterbyName使用</remarks>
    Protected Function setActivePrinter(ByRef rpt As Object, ByRef printerName As String) As Boolean
        Try
            If TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then
                rpt.WordBasic.FilePrintSetup(Printer:=printerName, DoNotSetAsSysDefault:=1)
                Return True
            ElseIf TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                rpt.ActivePrinter = ConvertToExcelPrinterFriendlyName(printerName)
                Return True
            ElseIf TypeOf rpt Is FileInfo Then
                'SetPrinterNameToTxtFile(rpt, printerName)
                Return True

            ElseIf TypeOf rpt Is System.String Then
                '2016/04/03 Sean:使用預設印表機
                Return True

            Else
                '錯誤的報表物件
                Throw New RPTBusinessException("RPTCMMA006")
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("CMMCMMD001", ex)
        End Try
    End Function

    Protected Function ConvertToExcelPrinterFriendlyName(ByVal printerName As String) As String

        'If Not printerName.Contains("on") Then
        Dim key = Microsoft.Win32.Registry.CurrentUser
        Dim subkey = key.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\Devices")

        Dim value = subkey.GetValue(printerName)
        If (value Is Nothing) Then
            'Throw New Exception(String.Format("Device not found: {0}", printerName))
            Return printerName

        End If

        Dim portName = value.ToString().Substring(9)

        Return String.Format("{0} on {1}", printerName, portName)
        'Else

        'Return printerName
        'End If

    End Function

    ''' <summary>
    ''' 關閉Word與App
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub FinishWork(ByRef rpt As Object)
        If rpt IsNot Nothing Then
            Try
                If TypeOf rpt Is Microsoft.Office.Interop.Excel.Application Then
                    '處理 Excel 物件關閉
                    Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
                    '處理 active 物件
                    If objApp.ActiveWorkbook IsNot Nothing Then
                        objApp.ActiveWorkbook.Close(False)
                    End If
                    objApp.Quit()
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)
                    objApp = Nothing

                ElseIf TypeOf rpt Is Microsoft.Office.Interop.Word.Application Then
                    '處理 Word 物件關閉
                    Dim objApp As Microsoft.Office.Interop.Word.Application = rpt
                    '處理 active 物件
                    If objApp.ActiveDocument IsNot Nothing Then
                        'objApp.ActiveDocument.Quit(SaveChanges:=WdSaveOptions.wdDoNotSaveChanges)
                        objApp.ActiveDocument.Close(False)
                    End If
                    objApp.Quit(SaveChanges:=WdSaveOptions.wdDoNotSaveChanges)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)
                    objApp = Nothing
                Else
                    rpt = Nothing
                End If
            Catch ex As Exception
                Throw New RPTBusinessException("CMMCMMD001", ex)
            End Try
            GC.Collect()
        End If

    End Sub

#Region "TXT 專用 by roger"

    ''' <summary>
    ''' 寫入 Rtf File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Overridable Function WriteRtfFile(ByRef reportData As String, ByRef reportId As String) As FileInfo
        Return WriteRtfFile(reportData, reportId, Encoding.Unicode)
    End Function
    ''' <summary>
    ''' 寫入 Rtf File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Function WriteRtfFile(ByRef reportData As String, ByRef reportId As String, ByRef txtEncode As Encoding) As FileInfo
        Return WriteFile(reportData, reportId, txtEncode, ".rtf") '加了斷行，以利分隔出 "印表機" 字串
    End Function

    ''' <summary>
    ''' 寫入 Txt File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Overridable Function WriteTxtFile(ByRef reportData As String, ByRef reportId As String) As FileInfo
        Return WriteTxtFile(reportData, reportId, Encoding.Unicode)
    End Function
    ''' <summary>
    ''' 寫入 Txt File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Function WriteTxtFile(ByRef reportData As String, ByRef reportId As String, ByRef txtEncode As Encoding) As FileInfo
        Return WriteFile(reportData, reportId, txtEncode, ".txt")
    End Function

    ''' <summary>
    ''' 寫入 File
    ''' </summary>
    ''' <param name="reportData">寫入檔案的資料</param>
    ''' <param name="reportId">報表代碼</param>
    ''' <param name="txtEncode">文字編碼</param>
    ''' <param name="fileExtension">附檔名</param>
    ''' <returns>FileInfo</returns>
    ''' <remarks></remarks>
    Protected Function WriteFile(ByRef reportData As String, ByRef reportId As String, ByRef txtEncode As Encoding, ByRef fileExtension As String) As FileInfo
        Try
            Dim fileObj As FileInfo
            Dim defaultTxtDirectoryPath As String = My.Application.Info.DirectoryPath & "\txtReport\"
            Dim fullFileName As String = New StringBuilder().Append(defaultTxtDirectoryPath).Append(reportId).Append("-").Append(rand.Next(1, 1000)).Append(Now.ToString("-yyyyMMdd-HHmmssfffff")).Append(fileExtension).ToString

            fileObj = New IO.FileInfo(fullFileName)

            '假如沒有資料夾，先建立資料夾
            If (Not fileObj.Directory.Exists) Then
                fileObj.Directory.Create()
            End If

            Dim objStream As StreamWriter = New StreamWriter(fileObj.OpenWrite, txtEncode)

            objStream.WriteLine(reportData)

            objStream.Flush()
            objStream.Close()
            objStream.Dispose()

            Return fileObj
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA002", ex)
        End Try
    End Function

    ''' <summary>
    ''' 將印表機名稱加入txt File中
    ''' </summary>
    ''' <param name="rpt">txt 檔</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function SetPrinterNameToTxtFile(ByRef rpt As FileInfo, ByRef printerName As String) As FileInfo
        Return SetPrinterNameToTxtFile(rpt, printerName, Encoding.Unicode)
    End Function
    ''' <summary>
    ''' 將印表機名稱加入txt File中
    ''' </summary>
    ''' <param name="rpt">txt 檔</param>
    ''' <param name="printerName">印表機名稱</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function SetPrinterNameToTxtFile(ByRef rpt As FileInfo, ByRef printerName As String, ByRef txtEncode As Encoding) As FileInfo
        Try
            '取得第一列資料
            Dim strContents As String
            Dim objReader As New StreamReader(rpt.FullName, txtEncode)
            strContents = objReader.ReadToEnd()
            objReader.Close()

            '覆蓋第一列資料
            Dim objWriter As New StreamWriter(rpt.FullName, False, txtEncode)
            objWriter.Write(printerName & strContents)
            objWriter.Close()
            Return rpt
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA009", ex)
        End Try
    End Function

#End Region

End Class
