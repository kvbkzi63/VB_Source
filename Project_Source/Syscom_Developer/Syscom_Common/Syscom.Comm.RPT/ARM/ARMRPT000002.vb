'*****************************************************************************
'*
'*    Page/Class Name:	ARMRPT000002.vb
'*              Title:	多面向查詢匯出
'*        Description:	多面向查詢匯出
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Rich
'*        Create Date:	2014/12/19
'*      Last Modifier:
'*   Last Modify Date:	
'*
'*****************************************************************************

Imports Microsoft.Office.Interop.Excel
Imports Syscom.Comm.Utility
Imports Syscom.Comm.RPT

Public Class ARMRPT000002
    Inherits IReport

    Public Sub New()
        reportId = "ARMRPT000002"
        'reportTitle = NIS.Comm.Utility.ResourceUtil.getResourceString(NIS.Comm.Utility.ResourceUtil.RPT, reportId)
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
            'Dim sLeftHeader = vbCr & "&10&""新細明體,Regular""報表編號：{0}" & vbCr & "報表頁次：第 &P/ &N頁" & vbCr & "列印條件：{1}"
            Dim sCenterHeader = "&12&""新細明體,Regular""" & " {0}" & vbCr & "&12&""新細明體,Regular""" & " {1}"
            'Dim sRightHeader = vbCr & "&10&""新細明體,Regular""列印日期：{0}" & vbCr & "列印人員：{1}"

            reportTitle = "高雄市立聯合醫院"
            'reportTitle = HospUtil.Name

            Dim strFormName As String = dt.TableName

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
                    .CenterHeader = String.Format(sCenterHeader, reportTitle, strFormName)
                    .PrintHeadings = False
                    .PrintGridlines = False
                    .CenterVertically = False
                    .PaperSize = Me.reportSize
                    .PrintTitleRows = "$1:$3"
                    .PrintTitleColumns = ""
                End With

                '設置列印區字體大小
                objWS.Range("A" & 1, "I" & 1).WrapText = True

                objWS.Cells(1, 1).Value = "人員"
                objWS.Cells(1, 3).Value = ""
                objWS.Cells(1, 5).Value = "角色"
                objWS.Cells(1, 7).Value = ""
                objWS.Cells(2, 1).Value = "功能"
                objWS.Cells(2, 3).Value = ""
                objWS.Cells(2, 5).Value = ""
                objWS.Cells(2, 7).Value = ""
                objWS.Cells(3, 1).Value = "'-----------------------------------------------------------------------------------------------------------------------"

                With condData.Rows(0)
                    objWS.Cells(1, 2).Value = .Item("Employee_Name").ToString.Trim
                    objWS.Cells(1, 4).Value = ""
                    objWS.Cells(1, 6).Value = .Item("Role_Name").ToString.Trim
                    objWS.Cells(1, 8).Value = ""
                    objWS.Cells(2, 2).Value = .Item("Fun_Function_Name").ToString.Trim
                    objWS.Cells(2, 4).Value = ""
                    objWS.Cells(2, 6).Value = ""
                    objWS.Cells(2, 8).Value = ""
                End With

                Dim rowIndex As Integer = 4
                Dim colIndex As Integer = 1
                For i As Integer = 3 To condData.Columns.Count - 1
                    objWS.Cells(rowIndex, colIndex).Value = condData.Columns(i).ColumnName
                    colIndex += 1
                Next
                rowIndex += 1
                colIndex = 1

                For Each row As DataRow In dt.Rows
                    For Each col As DataColumn In dt.Columns
                        objWS.Cells(rowIndex, colIndex).Value = row(col.ColumnName).ToString.Trim
                        colIndex += 1
                    Next
                    rowIndex += 1
                    colIndex = 1
                Next

                Return objApp
            End If
        Catch ex As Exception
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
