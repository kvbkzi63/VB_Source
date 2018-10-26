Imports Syscom.Comm.RPT
Imports Microsoft.Office.Interop.Excel
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Public Class TestExcelRPT
    Inherits IRPTPrintServer
    Public Sub New()
        printerCondition = "*"
        LOGDelegate.getInstance.fileDebugMsg("before imp current user is " & GetUserName & "," & Environment.UserName)
    End Sub
    Declare Function GetUserName Lib "advapi32.dll" Alias _
       "GetUserNameA" (ByVal lpBuffer As String, _
       ByRef nSize As Integer) As Integer

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function
    Protected Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Dim sLeftHeader = vbCr & "&10&""新細明體,Regular""報表編號：{0}" & vbCr & "報表頁次：第 &P/ &N頁" & vbCr & "列印條件：{1}"
        Dim sCenterHeader = "&14&""新細明體,Regular""" & " {0}" & vbCr & "列印人員"
        Dim sRightHeader = vbCr & "&10&""新細明體,Regular"" 列印日期：{0}" & vbCr & "列印人員：{1}"
        Dim objApp As Microsoft.Office.Interop.Excel.Application
        Dim objWB As Workbook
        Dim objWS As Worksheet
        ' Connect to excel
        LOGDelegate.getInstance.fileDebugMsg("Connect to excel")
        objApp = New Application

        ' Create a new workbook
        LOGDelegate.getInstance.fileDebugMsg("Create a new workbook")
        objWB = objApp.Workbooks.Add()

        ' Create a new worksheet
        LOGDelegate.getInstance.fileDebugMsg("Create a new worksheet")
        objWS = objWB.ActiveSheet()

        '此格式排版，是為了將列印者姓名與列印日期對齊，目前的格式針對中文字元才有效果，最多六個中文字。
        '字串最後　& endString，是因為 Eccel會忽略全空白，並加上一些間距調整。
        Dim endString As String = "   " & Chr(9)

        'Dim fixedUserName = StringUtil.appendCharToRight("陳", "　".Chars(0), 6) & endString
        'Dim fixedUserName = StringUtil.appendCharToRight("陳偉", "　".Chars(0), 6) & endString
        Dim fixedUserName = StringUtil.appendCharToRight("陳偉凡", "　".Chars(0), 6) & endString
        'Dim fixedUserName = StringUtil.appendCharToRight("陳偉凡凡", "　".Chars(0), 6) & endString
        'Dim fixedUserName = StringUtil.appendCharToRight("陳偉凡凡凡", "　".Chars(0), 6) & endString
        'Dim fixedUserName = StringUtil.appendCharToRight("陳偉凡凡凡凡", "　".Chars(0), 6) & endString

        With objWS.PageSetup
            
            .RightHeader = String.Format(sRightHeader, "2009/07/12 17:33", fixedUserName)
            .LeftMargin = objApp.InchesToPoints(0.5)
            .RightMargin = objApp.InchesToPoints(0.5)
            .TopMargin = objApp.InchesToPoints(1.5)     '<--- 如果沒有動到 Header 內容，那麼用 1.5 剛好
            .BottomMargin = objApp.InchesToPoints(1)
            .HeaderMargin = objApp.InchesToPoints(0.5)
            .FooterMargin = objApp.InchesToPoints(0.5)
            .PrintHeadings = False
            .PrintGridlines = False
            .PrintTitleRows = "$1:$1"  '<--- TopMargin 設定 1.5  那麼只需要 $1 這行即可

            .CenterHorizontally = True ' <--- 置中，不一定要用

            '.PaperSize = "A4"

        End With
        objWS.Range("A:F").Font.Size = 10
        '第二行 Row Header Title
        Dim rowHeader As String() = {"健檢日期", "病歷號碼", "姓名", "健檢金額", "套裝代碼", "套裝名稱"}
        For i = 1 To rowHeader.Length
            objWS.Cells(1, i) = rowHeader(i - 1) 'TopMargin 設定 1.5  那麼只需要 第一行留給 Row Header , 所以　objWS.Cells　從　1  開始                    
        Next
        'Header 加底色        
        objWS.Range("A1:F1").Interior.Color = RGB(235, 235, 235)

        '第二行 Row Header 寬度
        Dim rowHeaderwidth As Integer() = {20, 15, 15, 10, 15, 10}
        objWS.Range("A1").Cells.ColumnWidth = rowHeaderwidth(0)
        objWS.Range("B1").Cells.ColumnWidth = rowHeaderwidth(1)
        objWS.Range("C1").Cells.ColumnWidth = rowHeaderwidth(2)
        objWS.Range("D1").Cells.ColumnWidth = rowHeaderwidth(3)
        objWS.Range("E1").Cells.ColumnWidth = rowHeaderwidth(4)
        objWS.Range("F1").Cells.ColumnWidth = rowHeaderwidth(5)

        '塞資料
        For i = 2 To 5
            For j = 1 To 6
                objWS.Cells(i, j) = i & "," & j
            Next

        Next
        '塞 Page End 字串
        objWS.Cells(300 + 1, "C").value = "------列印完畢------"
        objWS.Cells(300 + 1, "C").HorizontalAlignment = XlHAlign.xlHAlignCenter
        Return objApp
    End Function

    Protected Overrides Sub printReport(ByRef rpt As Object)
        If rpt Is Nothing Then
            '要先genReport
            Throw New RPTBusinessException("RPTCMMA006")
        Else
            Try
                'rpt.Visible = False
                PrintOut(rpt, getPrinterName("OMORPT0100101"))
            Catch cmex As CommonException
                Throw cmex
            Catch ex As Exception
                Throw New RPTBusinessException("RPTCMMA003", ex)
            Finally
                FinishWork(rpt)
            End Try
        End If
    End Sub

    Protected Overrides Function queryRPTData(ByRef queryCondition() As Object) As System.Data.DataSet
        Return Nothing
    End Function
End Class
