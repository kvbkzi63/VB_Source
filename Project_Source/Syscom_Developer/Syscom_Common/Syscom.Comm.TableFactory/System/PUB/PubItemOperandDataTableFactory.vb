Imports System.Data.SqlClient
Public Class PubItemOperandDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2009/10/17 上午 11:50:59
    Public Shared ReadOnly tableName as String="PUB_Item_Operand"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Use_Type", "Item_Code", "Operand_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 6, 5}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubItemOperandDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Use_Type") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Operand_Code") = New Object
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
            dt.Columns.Add("Use_Type")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Operand_Code")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Use_Type")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Operand_Code")
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
            dt.Columns.Add("Use_Type")
            dt.Columns("Use_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Operand_Code")
            dt.Columns("Operand_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Use_Type")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Operand_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
