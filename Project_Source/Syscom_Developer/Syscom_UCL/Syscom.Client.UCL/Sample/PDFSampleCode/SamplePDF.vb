'/*
'*****************************************************************************
'*
'*    Page/Class Name:  SamplePDF
'*              Title:	範例報表
'*        Description:	PDF共用範例報表測試
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2016-06-24
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2016-06-24
'*
'*****************************************************************************
'*/

Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DateUtil
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.RPT
Imports Syscom.Comm.BASE
Imports System.IO
Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP

Public Class SamplePDF
    Inherits IReport

#Region "　　 PDF 全域變數宣告"

    '記憶體產生pdf
    Private mymemory As New MemoryStream

    '接收資料集
    Public Shared gblDsInput As DataSet

    'Pdf Document
    Private gblDocPdf As Document = New Document

    'PDF編輯器
    Private pdfwrite As PdfWriter

    '字型設定
    '標楷體
    Public Shared bfChinese As BaseFont = BaseFont.CreateFont("C:\WINDOWS\Fonts\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)

    '字體設定(大小顏色)
    Public Shared gblBfFont As New Font(bfChinese, 12)

    '表頭欄位
    Dim gblHeader As String() = New String() {"欄位1", "欄位2", "欄位3", "欄位4", "欄位5", "欄位6"}

    '存檔的路徑Path
    Private gblSavePath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\"

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

#End Region

#Region "　　 PDF 報表邏輯"

#Region "　　 PDF 產生報表結構"

    ''' <summary>
    ''' 報表主結構
    ''' </summary>
    ''' <param name="dsPrint" >傳入的Data</param>
    ''' <remarks>ByWill.Lin</remarks>
    Public Overrides Function genReport(ByRef dsPrint As System.Data.DataSet) As Object
        Try

            '***************************** ↓設定紙張種類，依需求調整↓*****************************
            gblDocPdf = New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
            '***************************** ↑設定紙張種類，依需求調整↑*****************************




            '***************************** ↓設定PDF編輯器，沒必要不需要做修改↓*****************************
            pdfwrite = PdfWriter.GetInstance(gblDocPdf, mymemory)
            '***************************** ↑設定PDF編輯器，沒必要不需要做修改↑*****************************




            '***************************** ↓設定PDF邊界，依需求調整↓*****************************
            gblDocPdf.SetMargins(1, 1, gblContentHeaderMargin, gblContenteFooterMargin)
            '***************************** ↑設定PDF邊界，依需求調整↑*****************************




            '***************************** ↓設定全域資料集，沒必要不需要做修改↓*****************************
            gblDsInput = dsPrint
            '***************************** ↑設定全域資料集，沒必要不需要做修改↑*****************************



            '***************************** ↓PDF 事件 頁首頁尾Override，沒必要不需要做修改↓*****************************
            pdfwrite.PageEvent = New OverridPdfEvent
            '***************************** ↑PDF 事件 頁首頁尾Override，沒必要不需要做修改↑*****************************


            '***************************** ↓進入建立報表主邏輯，沒特別需求不需變更↓*****************************
            gblDocPdf.Open()
            genReportByFilter(dsPrint)
            gblDocPdf.Close()
            '***************************** ↑進入建立報表主邏輯，沒特別需求不需變更↑*****************************






            '***************************** ↓固定的資料輸出設定，沒特別需求不需變更↓*****************************

            'PDF內容
            Dim content As Byte() = mymemory.ToArray

            '判斷Folder，不存在則自行打開
            If System.IO.Directory.Exists(gblSavePath) Then

            Else
                System.IO.Directory.CreateDirectory(gblSavePath)
            End If

            Dim filePathName As String = gblSavePath & Now.ToString("MMddHHmmss") & ".pdf"

            '產生PDF檔案
            Using fs As FileStream = File.Create(filePathName)
                fs.Write(content, 0, content.Length)
            End Using

            Return filePathName
            '***************************** ↑固定的資料輸出設定，沒特別需求不需變更↑*****************************
        Catch rptex As Syscom.Comm.EXP.RPTBusinessException
            MessageHandling.ShowWarnMsg("PDF共用報表類別" + rptex.getErrorCode)
            Throw rptex
        Catch cmex As CommonException
            Throw New CommonException("CMMCMMB302", cmex, New String() {"列印 " & "報表名稱:---請自行修改------" & "(一般表單共用報表類別)"})
        Catch ex As Exception
            If gblDocPdf IsNot Nothing Then
                gblDocPdf.Close()
                gblDocPdf.Dispose()
                gblDocPdf = Nothing
            End If
            Throw ex
        End Try

    End Function

#End Region

#Region "　　 PDF 報表主邏輯"
    ''' <summary>
    ''' 產生報表主邏輯
    ''' </summary>
    ''' <param name="dsPrint" >傳入的Data</param>
    ''' <remarks></remarks>
    Public Function genReportByFilter(ByRef dsPrint As System.Data.DataSet) As Object

        '定義表格的Table
        Dim RecordDataTable As PdfPTable = Nothing

        Try

            '設定欄寬--請依據gblHeader設定的欄位數量去設定相對應的欄位寬度
            Dim tableColumnWidth As Int32() = New Int32() {100, 100, 100, 100, 100, 100}

            Try


                '產生Pdf表格
                RecordDataTable = New PdfPTable((tableColumnWidth.ToList.ConvertAll(Function(x) Convert.ToSingle(x)).ToArray))
                '設定PDF表格總寬度 
                RecordDataTable.TotalWidth = tableColumnWidth.Sum
                '設定表格第一列為表頭
                RecordDataTable.HeaderRows = 1

                '產生標題列
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(0), gblBfFont)))
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(1), gblBfFont)))
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(2), gblBfFont)))
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(3), gblBfFont)))
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(4), gblBfFont)))
                RecordDataTable.AddCell(New PdfPCell(New Phrase(gblHeader(5), gblBfFont)))
                '固定大小
                RecordDataTable.LockedWidth = True


                '循環列印紀錄在表格裡面
                For Each recordRow As DataRow In dsPrint.Tables(1).Rows
                    '針對每一個Row的每一個Cell填入資料
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column1").ToString.Trim, gblBfFont)))
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column2").ToString.Trim, gblBfFont)))
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column3").ToString.Trim, gblBfFont)))
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column4").ToString.Trim, gblBfFont)))
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column5").ToString.Trim, gblBfFont)))
                    RecordDataTable.AddCell(New PdfPCell(New Phrase(recordRow.Item("Column6").ToString.Trim, gblBfFont)))
                Next
                '將剛組好的PDF頁面加入PDFDoc裡面
                gblDocPdf.Add(RecordDataTable)
                'gblDocPdf.NewPage()'如果有需要換頁才使用
            Catch rptex As Syscom.Comm.EXP.RPTBusinessException
                MessageHandling.ShowWarnMsg("PDF共用報表類別" + rptex.getErrorCode)
                Throw rptex
            Catch cmex As CommonException
                Throw New CommonException("CMMCMMB302", cmex, New String() {"列印 " & "報表名稱:---請自行修改------" & "(共用報表類別)"})
            Catch ex As Exception
                Throw ex
            End Try

            Return gblDocPdf
        Catch rptex As Syscom.Comm.EXP.RPTBusinessException
            MessageHandling.ShowWarnMsg("PDF共用報表類別" + rptex.getErrorCode)
            Throw rptex
        Catch cmex As CommonException
            Throw New CommonException("CMMCMMB302", cmex, New String() {"列印 " & "報表名稱:---請自行修改------" & "(PDF共用報表類別)"})
        Catch ex As Exception

            Throw ex


        End Try

    End Function

#End Region

#Region "　　 PDF 頁首頁尾事件處理"

    ''' <summary> PdfPageEventHelper </summary>
    Public Class OverridPdfEvent
        Inherits PdfPageEventHelper

        Private cb As PdfContentByte

        Private template As PdfTemplate

        Private bf As BaseFont = Nothing
        Private uf As BaseFont = Nothing

        ''' <summary> 開啟Document Event </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="docPdf">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnOpenDocument(writer As PdfWriter, docPdf As iTextSharp.text.Document)
            MyBase.OnOpenDocument(writer, docPdf)

            Try
                '********************* 針對頁首頁尾的體字設定，沒必要不需修改 *********************
                '標楷體
                bf = BaseFont.CreateFont("C:\WINDOWS\Fonts\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)
                cb = writer.DirectContent
                template = cb.CreateTemplate(50, 50)
            Catch rptex As Syscom.Comm.EXP.RPTBusinessException
                MessageHandling.ShowWarnMsg("PDF共用報表類別" + rptex.getErrorCode)
                Throw rptex
            Catch cmex As CommonException
                Throw New CommonException("CMMCMMB302", cmex, New String() {"列印 " & "報表名稱:---請自行修改------" & "(一般表單共用報表類別)"})
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        ''' <summary> Pdf頁尾Event </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="docPdf">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnEndPage(writer As PdfWriter, docPdf As iTextSharp.text.Document)
            MyBase.OnEndPage(writer, docPdf)

            '取得印表人員資訊
            Dim dtLoginInfo As System.Data.DataTable = gblDsInput.Tables("Login_User")
            Dim PrintUser As String = "列印者:"



            Dim pagesize As Rectangle = docPdf.PageSize
            '*********************↓設定醫院名稱-可自行調整↓*********************
            cb.BeginText()
            cb.SetRGBColorFill(100, 100, 100)
            cb.SetFontAndSize(bf, 18)
            '設定字體內容&位置 
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, HospConfigUtil.Name, pagesize.GetLeft(290), pagesize.GetTop(gblFirstHeaderMargin), 0)
            cb.EndText()
            '*********************↑設定醫院名稱-可自行調整↑*********************



            '*********************↓設定報表名稱-可自行調整↓*********************
            cb.BeginText()
            cb.SetFontAndSize(bf, 18)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "報表名稱:可自行設定", pagesize.GetLeft(290), pagesize.GetTop(gblSecondHeaderMargin), 0)
            cb.EndText()
            '*********************↑設定報表名稱-可自行調整↑*********************





            '*********************↓設定列印者-可自行調整↓*********************
            cb.BeginText()
            cb.SetFontAndSize(bf, 9)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PrintUser & " " & DateUtil.TransDateTimeToROC(Now.ToString("yyyy/MM/dd HH:mm")) + vbCrLf, pagesize.GetLeft(300 + bf.GetWidthPoint("系統管理者", 18)), pagesize.GetTop(gblSecondHeaderMargin), 0)
            cb.EndText()
            '*********************↑設定列印者-可自行調整↑*********************





            '*********************↓設定報表頁碼-有需要才動↓*********************
            Dim text As String = "共  " & writer.PageNumber & " / "
            '設定字體顏色
            cb.SetRGBColorFill(100, 100, 100)
            cb.BeginText()
            '設定字體&大小
            cb.SetFontAndSize(bf, 9)
            '設定文字在CB所屬區塊的位置
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text, pagesize.GetLeft(290), pagesize.GetBottom(gblPageFooterMargin), 0)
            cb.EndText()
            '設定CB在整份PDF的頁尾位置
            cb.AddTemplate(template, pagesize.GetLeft(290) + bf.GetWidthPoint(text, 9) / 2, pagesize.GetBottom(gblPageFooterMargin))
            '*********************↑設定頁尾字串-有需要才動↑*********************
        End Sub


        ''' <summary> 關閉DocumentEvent </summary>
        ''' <param name="writer">PDF編輯器</param>
        ''' <param name="document">PDF文件</param>
        ''' <remarks></remarks>
        Public Overrides Sub OnCloseDocument(writer As PdfWriter, document As iTextSharp.text.Document)
            MyBase.OnCloseDocument(writer, document)

            '*********************↓設定報表頁碼-有需要才動↓*********************
            template.BeginText()
            template.SetFontAndSize(bf, 9)
            template.SetTextMatrix(0, 0)
            template.ShowText((writer.PageNumber - 1).ToString & " 頁")
            template.EndText()
            '*********************↑設定報表頁碼-有需要才動↑*********************
        End Sub


    End Class

#End Region

#End Region

#Region "　　 PDF 初始化 "

    ''' <summary>
    ''' New 本身的物件
    ''' </summary>
    ''' <remarks> ByWill.Lin</remarks>
    Public Sub New()

        '*********************報表代號，請自行修改*********************

        Me.reportId = "XXXRPT0000001"
        Me.reportTitle = ResourceUtil.getResourceString(ResourceUtil.RPT, reportId)
    End Sub

#End Region



End Class

