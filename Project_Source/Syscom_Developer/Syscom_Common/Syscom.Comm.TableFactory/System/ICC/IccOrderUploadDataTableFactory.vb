Imports System.Data.SqlClient
Public Class IccOrderUploadDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/9/28 上午 11:01:52
    Public Shared ReadOnly tableName as String="ICC_Order_Upload"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Sn", "A71", "A72", "A73", "A74",   _
             "A75", "A76", "A77", "A78", "A79",   _
             "Health_Sn", "Execute_No"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.Int16", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 13, 1, 12, 6,   _
             18, -1, -1, 2, 40,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccOrderUploadDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Sn") = New Object
        dataRow("A71") = New Object
        dataRow("A72") = New Object
        dataRow("A73") = New Object
        dataRow("A74") = New Object
        dataRow("A75") = New Object
        dataRow("A76") = New Object
        dataRow("A77") = New Object
        dataRow("A78") = New Object
        dataRow("A79") = New Object
        dataRow("Health_Sn") = New Object
        dataRow("Execute_No") = New Object
        dataTable.Rows.Add(dataRow) 
        dataSet.Tables.Add(dataTable) 
    End sub 

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Order_Sn")
            dt.Columns.Add("A71")
            dt.Columns.Add("A72")
            dt.Columns.Add("A73")
            dt.Columns.Add("A74")
            dt.Columns.Add("A75")
            dt.Columns.Add("A76")
            dt.Columns.Add("A77")
            dt.Columns.Add("A78")
            dt.Columns.Add("A79")
            dt.Columns.Add("Health_Sn")
            dt.Columns.Add("Execute_No")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Sn")
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
            dt.Columns.Add("Order_Sn")
            dt.Columns("Order_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A71")
            dt.Columns("A71").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A72")
            dt.Columns("A72").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A73")
            dt.Columns("A73").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A74")
            dt.Columns("A74").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A75")
            dt.Columns("A75").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A76")
            dt.Columns("A76").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("A77")
            dt.Columns("A77").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("A78")
            dt.Columns("A78").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A79")
            dt.Columns("A79").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Health_Sn")
            dt.Columns("Health_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Execute_No")
            dt.Columns("Execute_No").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Sn")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
