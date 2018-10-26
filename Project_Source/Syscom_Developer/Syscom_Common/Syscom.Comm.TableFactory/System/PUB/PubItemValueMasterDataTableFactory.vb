Imports System.Data.SqlClient
Public Class PubItemValueMasterDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2009/10/17 上午 11:51:00
    Public Shared ReadOnly tableName as String="PUB_Item_Value_Master"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Use_Type", "Item_Code", "Seq_No", "Value_Group_Name", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 6, -1, 50, 10,   _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubItemValueMasterDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Use_Type") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Seq_No") = New Object
        dataRow("Value_Group_Name") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
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
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Value_Group_Name")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Use_Type")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Seq_No")
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
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Value_Group_Name")
            dt.Columns("Value_Group_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Use_Type")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Seq_No")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class