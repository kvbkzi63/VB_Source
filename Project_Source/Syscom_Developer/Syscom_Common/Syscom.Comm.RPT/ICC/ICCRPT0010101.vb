'*****************************************************************************
'*
'*    Page/Class Name:	ICCRPT0010101.vb
'*              Title:	雲端藥歷重複用藥
'*        Description:	雲端藥歷重複用藥
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Runxia
'*        Create Date:	2015/12/09
'*      Last Modifier:
'*   Last Modify Date:	
'*
'*****************************************************************************

Imports Microsoft.Office.Interop.Excel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.RPT
Public Class ICCRPT0010101
    Inherits IReport

    Public Sub New()
        reportId = "ICCRPT0010101"
        reportSize = XlPaperSize.xlPaperA4
    End Sub

    Dim objApp As Application
    Dim objWB As Workbook
    Dim objWS As Worksheet

    Public Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Try
            'Setp1. 取得列印資料(傳入的參數) rpt(0) = 前端條件   rpt(1) = departments
            Dim condData As System.Data.DataTable = data.Tables(0)
            Dim dt As System.Data.DataTable = data.Tables(1)

            '設置報表頭部的   左右中  顯示  格式
            Dim sLeftHeader = vbCr & "&10&""標楷體,Regular""報表編號：{0}" & vbCr & "報表頁次：第 &P/ &N頁" & vbCr & "列印條件：{1}"
            Dim sCenterHeader = "&14&""標楷體,Regular""" & " {0}"
            Dim sRightHeader = vbCr & "&10&""標楷體,Regular""列印日期：{0}" & vbCr & "列印人員：{1}"

            reportTitle = IIf(reportTitle = "", "雲端藥歷重複用藥", reportTitle)
            '列印條件
            Dim strCondition As String = ""

            If CType(condData.Rows(0).Item("Query_Type"), String) = "1" Then
                strCondition = "查詢類別：" + "重複用藥"
            ElseIf CType(condData.Rows(0).Item("Query_Type"), String) = "2" Then
                strCondition = "查詢類別：" + "交互作用"
            ElseIf CType(condData.Rows(0).Item("Query_Type"), String) = "3" Then
                strCondition = "查詢類別：" + "不分"
            End If

            strCondition = strCondition & "就醫日期：" + DateUtil.TransDateToROC(Trim(CType(condData.Rows(0).Item("ST_VisitDate"), String))) + "~" _
                                                       + DateUtil.TransDateToROC(Trim(CType(condData.Rows(0).Item("ED_VisitDate"), String)))

            If StringUtil.nvl(condData.Rows(0).Item("Chart_No")) <> "" Then
                strCondition = strCondition + "病歷號：" + StringUtil.nvl(condData.Rows(0).Item("Chart_No"))
            End If
            Dim endString As String = "  " & Chr(9)
            '列印日期
            Dim strDate As String = DateUtil.TransDateTimeToROC(Trim(CType(Now.ToString(DateUtil.DateTimeMinuteTypeSlash), String)))
            If dt Is Nothing Then
                '無資料
                '不用列印
                Return Nothing
            Else
                ' Connect to excel
                objApp = New Application

                ' Create a new workbook
                objWB = objApp.Workbooks.Add()

                ' Create a new worksheet
                objWS = objWB.ActiveSheet()

                With objWS.PageSetup
                    '設置報表頭部的   左右中  顯示數據
                    .LeftHeader = String.Format(sLeftHeader, reportId, strCondition)
                    .CenterHeader = String.Format(sCenterHeader, reportTitle)
                    .RightHeader = String.Format(sRightHeader, strDate, StringUtil.appendCharToRight(AppContext.userProfile.userName, " ".Chars(0), 7) & endString)
                    .LeftMargin = objApp.InchesToPoints(0.3)
                    .RightMargin = objApp.InchesToPoints(0.2)
                    .TopMargin = objApp.InchesToPoints(1.3)
                    .BottomMargin = objApp.InchesToPoints(1)
                    .HeaderMargin = objApp.InchesToPoints(0.5)
                    .FooterMargin = objApp.InchesToPoints(0.5)
                    .PrintHeadings = False
                    .PrintGridlines = False
                    .CenterVertically = False
                    .PaperSize = Me.reportSize
                    .PrintTitleRows = "$1:$1"
                    .PrintTitleColumns = ""
                End With

                '設置列印區字體大小
                objWS.Range("A:J").Font.Size = 10
                objWS.Range("A:J").Font.Name = "標楷體"

                '第一行 Row Header 寬度
                Dim rowHeaderwidth As Integer() = {8, 9, 8, 8, 8, 4, 13, 13, 12, 9}
                objWS.Range("A1").Cells.ColumnWidth = rowHeaderwidth(0)
                objWS.Range("B1").Cells.ColumnWidth = rowHeaderwidth(1)
                objWS.Range("C1").Cells.ColumnWidth = rowHeaderwidth(2)
                objWS.Range("D1").Cells.ColumnWidth = rowHeaderwidth(3)
                objWS.Range("E1").Cells.ColumnWidth = rowHeaderwidth(4)
                objWS.Range("F1").Cells.ColumnWidth = rowHeaderwidth(5)
                objWS.Range("G1").Cells.ColumnWidth = rowHeaderwidth(6)
                objWS.Range("H1").Cells.ColumnWidth = rowHeaderwidth(7)
                objWS.Range("I1").Cells.ColumnWidth = rowHeaderwidth(8)
                objWS.Range("J1").Cells.ColumnWidth = rowHeaderwidth(9)

                '設置列印區字體大小
                objWS.Range("A" & 1, "I" & 1).WrapText = True
              
                Dim rowIndex As Integer = 1
                objWS.Cells(rowIndex, 1).Value = "查詢類別"
                objWS.Cells(rowIndex, 2).Value = "就醫日期"
                objWS.Cells(rowIndex, 3).Value = "病歷號"
                objWS.Cells(rowIndex, 4).Value = "病患姓名"
                objWS.Cells(rowIndex, 5).Value = "醫令代碼"
                objWS.Cells(rowIndex, 6).Value = "序號"
                objWS.Cells(rowIndex, 7).Value = "疑義內容"
                objWS.Cells(rowIndex, 8).Value = "醫師使用理由"
                objWS.Cells(rowIndex, 9).Value = "建立者"
                objWS.Cells(rowIndex, 10).Value = "建立時間"
                rowIndex += 1

                For Each row As DataRow In dt.Rows
                    objWS.Cells(rowIndex, 1).Value = StringUtil.nvl(row("查詢類別"))
                    objWS.Cells(rowIndex, 2).Value = StringUtil.nvl(row("就醫日期"))
                    objWS.Cells(rowIndex, 3).Value = StringUtil.nvl(row("病歷號"))
                    objWS.Cells(rowIndex, 4).Value = StringUtil.nvl(row("病患姓名"))
                    objWS.Cells(rowIndex, 5).Value = StringUtil.nvl(row("醫令代碼"))
                    objWS.Cells(rowIndex, 6).Value = StringUtil.nvl(row("序號"))
                    objWS.Cells(rowIndex, 7).Value = StringUtil.nvl(row("疑義內容"))
                    objWS.Cells(rowIndex, 8).Value = StringUtil.nvl(row("醫師使用理由"))
                    objWS.Cells(rowIndex, 9).Value = StringUtil.nvl(row("建立者"))
                    objWS.Cells(rowIndex, 10).Value = StringUtil.nvl(row("建立時間"))
                    rowIndex += 1
                Next

                rowIndex -= 1
                objWS.Range("G:H").WrapText = True
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThin
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThin
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlEdgeTop).Weight = XlBorderWeight.xlThin
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlThin
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlInsideHorizontal).Weight = XlBorderWeight.xlThin
                objWS.Range(objWS.Cells(1, 1), objWS.Cells(rowIndex, 10)).Borders(XlBordersIndex.xlInsideVertical).Weight = XlBorderWeight.xlThin
                Return objApp
            End If
        Catch ex As Exception
            FinishWork()
            Throw ex
        End Try
    End Function

    Sub FinishWork()
        '回收Excel
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objApp)
        objApp = Nothing
        objWB = Nothing
        objWS = Nothing
        GC.Collect()
    End Sub
End Class
