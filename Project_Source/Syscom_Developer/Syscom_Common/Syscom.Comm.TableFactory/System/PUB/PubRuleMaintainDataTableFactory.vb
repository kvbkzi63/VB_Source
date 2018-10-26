Imports System.Data.SqlClient
Public Class PubRuleMaintainDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/8/13 下午 05:21:43
    Public Shared ReadOnly tableName as String="PUB_Rule_Maintain"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rule_Maintain_Sn", "Seq_No", "Item_Code", "Maintain_Value_Str"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.Int32", "System.Int32", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, -1, 6, 4000}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubRuleMaintainDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rule_Maintain_Sn") = New Object
        dataRow("Seq_No") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Maintain_Value_Str") = New Object
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
            dt.Columns.Add("Rule_Maintain_Sn")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Maintain_Value_Str")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Maintain_Sn")
            pkColArray(1) = dt.Columns("Seq_No")
            pkColArray(2) = dt.Columns("Item_Code")
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
            dt.Columns.Add("Rule_Maintain_Sn")
            dt.Columns("Rule_Maintain_Sn").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Maintain_Value_Str")
            dt.Columns("Maintain_Value_Str").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Maintain_Sn")
            pkColArray(1) = dt.Columns("Seq_No")
            pkColArray(2) = dt.Columns("Item_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
