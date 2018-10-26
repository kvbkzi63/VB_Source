Imports System.Data.SqlClient
Public Class PubRuleDetailDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/8/13 下午 05:21:43
    Public Shared ReadOnly tableName as String="PUB_Rule_Detail"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rule_Code", "Seq_No", "Item_Code", "Item_Param", "Operator_Code",   _
             "Value_Data", "Value_Unit", "Is_Count_O", "Is_Count_E", "Is_Count_I",   _
             "Logical_Symbol", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "Rule_Maintain_Sn"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, -1, 6, 60, 5,   _
             1000, 5, 1, 1, 1,   _
             5, 10, -1, 10, -1,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubRuleDetailDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rule_Code") = New Object
        dataRow("Seq_No") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Item_Param") = New Object
        dataRow("Operator_Code") = New Object
        dataRow("Value_Data") = New Object
        dataRow("Value_Unit") = New Object
        dataRow("Is_Count_O") = New Object
        dataRow("Is_Count_E") = New Object
        dataRow("Is_Count_I") = New Object
        dataRow("Logical_Symbol") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Rule_Maintain_Sn") = New Object
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
            dt.Columns.Add("Rule_Code")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Item_Param")
            dt.Columns.Add("Operator_Code")
            dt.Columns.Add("Value_Data")
            dt.Columns.Add("Value_Unit")
            dt.Columns.Add("Is_Count_O")
            dt.Columns.Add("Is_Count_E")
            dt.Columns.Add("Is_Count_I")
            dt.Columns.Add("Logical_Symbol")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Rule_Maintain_Sn")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
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
            dt.Columns.Add("Rule_Code")
            dt.Columns("Rule_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Param")
            dt.Columns("Item_Param").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Operator_Code")
            dt.Columns("Operator_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Value_Data")
            dt.Columns("Value_Data").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Value_Unit")
            dt.Columns("Value_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Count_O")
            dt.Columns("Is_Count_O").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Count_E")
            dt.Columns("Is_Count_E").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Count_I")
            dt.Columns("Is_Count_I").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Logical_Symbol")
            dt.Columns("Logical_Symbol").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Rule_Maintain_Sn")
            dt.Columns("Rule_Maintain_Sn").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            pkColArray(1) = dt.Columns("Seq_No")
            pkColArray(2) = dt.Columns("Item_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
