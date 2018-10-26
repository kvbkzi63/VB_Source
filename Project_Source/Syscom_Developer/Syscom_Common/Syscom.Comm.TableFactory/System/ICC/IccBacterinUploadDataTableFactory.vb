Imports System.Data.SqlClient
Public Class IccBacterinUploadDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/9/28 上午 10:59:57
    Public Shared ReadOnly tableName as String="ICC_Bacterin_Upload"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Bacterin_Sn", "A61", "A62", "A63", "A64",   _
             "A79", "Inoculation_Sn", "Execute_No"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, 7, 10, 12, _
             40, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccBacterinUploadDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Bacterin_Sn") = New Object
        dataRow("A61") = New Object
        dataRow("A62") = New Object
        dataRow("A63") = New Object
        dataRow("A64") = New Object
        dataRow("A79") = New Object
        dataRow("Inoculation_Sn") = New Object
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
            dt.Columns.Add("Bacterin_Sn")
            dt.Columns.Add("A61")
            dt.Columns.Add("A62")
            dt.Columns.Add("A63")
            dt.Columns.Add("A64")
            dt.Columns.Add("A79")
            dt.Columns.Add("Inoculation_Sn")
            dt.Columns.Add("Execute_No")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Bacterin_Sn")
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
            dt.Columns.Add("Bacterin_Sn")
            dt.Columns("Bacterin_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A61")
            dt.Columns("A61").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A62")
            dt.Columns("A62").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A63")
            dt.Columns("A63").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A64")
            dt.Columns("A64").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A79")
            dt.Columns("A79").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Inoculation_Sn")
            dt.Columns("Inoculation_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Execute_No")
            dt.Columns("Execute_No").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Bacterin_Sn")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
