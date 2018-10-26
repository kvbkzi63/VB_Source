Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility

Public Class PrinterSelectBO
    Private Shared bo As PrinterSelectBO = New PrinterSelectBO

    Public Shared Function getInstance() As PrinterSelectBO
        Return bo
    End Function

    ''' <summary>
    ''' 取得印表機名稱
    ''' </summary>
    ''' <param name="id">報表ID</param>
    ''' <param name="type">區分是由client 或是 server 來取得印表機列印</param>
    ''' <param name="con">取得印表機的附加條件</param>
    ''' <returns>印表機名稱</returns>
    ''' <remarks></remarks>
    Public Function getPrinterName(ByRef id As String, ByRef type As Integer, ByRef con As Object) As String
        '取得印表機名稱，此部份正在實做中，先以 "Microsoft XPS Document Writer" 取代
        Dim printerName = ""
        Dim operPUB As PubPrintConfigBO = PubPrintConfigBO.GetInstance

        Dim printerConfig As DataSet = operPUB.queryByPK(id, CStr(type), CStr(con))

        '以輸入條件查詢
        If DataSetUtil.IsContainsData(printerConfig) Then
            printerName = CType(printerConfig.Tables(0).Rows(0).Item("Printer_Name"), String)
        End If

        '以輸入條件前兩個，外加印表機的附加條件=* 查詢
        If "".Equals(printerName) AndAlso (Not "*".Equals(con)) Then
            printerConfig = operPUB.queryByPK(id, CStr(type), "*")
            If printerConfig IsNot Nothing AndAlso printerConfig.Tables.Count > 0 AndAlso printerConfig.Tables(0).Rows.Count > 0 Then
                printerName = CType(printerConfig.Tables(0).Rows(0).Item("Printer_Name"), String)
            End If
        End If

        '以輸入條件後兩個，外加報表ID=* 查詢
        If "".Equals(printerName) AndAlso (Not "*".Equals(con)) Then
            printerConfig = operPUB.queryByPK("*", CStr(type), CStr(con))
            If printerConfig IsNot Nothing AndAlso printerConfig.Tables.Count > 0 AndAlso printerConfig.Tables(0).Rows.Count > 0 Then
                printerName = CType(printerConfig.Tables(0).Rows(0).Item("Printer_Name"), String)
            End If
        End If

        '至此，若仍沒有資料  回傳 printerName 預設值 ""
        Return printerName
    End Function

    '''' <summary>
    ''''取得資料庫連線
    '''' </summary>
    '''' <returns>資料庫連線</returns>
    '''' <remarks></remarks>
    'Protected Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getOpdDBSqlConn
    'End Function

End Class
