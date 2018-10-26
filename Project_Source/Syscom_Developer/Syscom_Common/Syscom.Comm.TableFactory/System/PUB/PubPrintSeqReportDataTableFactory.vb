Imports System.Data.SqlClient
Public Class PubPrintSeqReportDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/11/1 下午 02:55:25
    Public Shared ReadOnly tableName As String = "PUB_Print_Seq_Report"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Send_Date", "MedNo", "ReportID", "ReportFileFID", "Printer_Name", _
             "ExFunction1", "ExFunction2", "PrintUser"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 20, 13, 31, 50, _
             50, 100, 8}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubPrintSeqReportDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Send_Date") = New Object
        dataRow("MedNo") = New Object
        dataRow("ReportID") = New Object
        dataRow("ReportFileFID") = New Object
        dataRow("Printer_Name") = New Object
        dataRow("ExFunction1") = New Object
        dataRow("ExFunction2") = New Object
        dataRow("PrintUser") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Send_Date")
            dt.Columns.Add("MedNo")
            dt.Columns.Add("ReportID")
            dt.Columns.Add("ReportFileFID")
            dt.Columns.Add("Printer_Name")
            dt.Columns.Add("ExFunction1")
            dt.Columns.Add("ExFunction2")
            dt.Columns.Add("PrintUser")
            Dim pkColArray(4) As DataColumn
            pkColArray(0) = dt.Columns("Send_Date")
            pkColArray(1) = dt.Columns("MedNo")
            pkColArray(2) = dt.Columns("ReportID")
            pkColArray(3) = dt.Columns("ReportFileFID")
            pkColArray(4) = dt.Columns("Printer_Name")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Send_Date")
            dt.Columns("Send_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("MedNo")
            dt.Columns("MedNo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ReportID")
            dt.Columns("ReportID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ReportFileFID")
            dt.Columns("ReportFileFID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Printer_Name")
            dt.Columns("Printer_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ExFunction1")
            dt.Columns("ExFunction1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ExFunction2")
            dt.Columns("ExFunction2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("PrintUser")
            dt.Columns("PrintUser").DataType = System.Type.GetType("System.String")
            Dim pkColArray(4) As DataColumn
            pkColArray(0) = dt.Columns("Send_Date")
            pkColArray(1) = dt.Columns("MedNo")
            pkColArray(2) = dt.Columns("ReportID")
            pkColArray(3) = dt.Columns("ReportFileFID")
            pkColArray(4) = dt.Columns("Printer_Name")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
