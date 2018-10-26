Imports System.Data.SqlClient
Public Class PubNhiIndexSetDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:59:12
    Public Shared ReadOnly tableName as String="PUB_Nhi_Index_Set"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Nhi_Index_Type_Id"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 5}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubNhiIndexSetDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Nhi_Index_Type_Id") = New Object
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Nhi_Index_Type_Id")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Nhi_Index_Type_Id")
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
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Index_Type_Id")
            dt.Columns("Nhi_Index_Type_Id").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Nhi_Index_Type_Id")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
