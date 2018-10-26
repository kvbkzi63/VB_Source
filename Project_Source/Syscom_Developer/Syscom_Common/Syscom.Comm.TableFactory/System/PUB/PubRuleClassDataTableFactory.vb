Imports System.Data.SqlClient
Public Class PubRuleClassDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/8/13 下午 05:21:42
    Public Shared ReadOnly tableName as String="PUB_Rule_Class"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rule_Code", "Condition_Type", "Seq_No", "Condition_Rule_Code", "Logical_Symbol",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, 1, -1, 40, 5,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubRuleClassDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rule_Code") = New Object
        dataRow("Condition_Type") = New Object
        dataRow("Seq_No") = New Object
        dataRow("Condition_Rule_Code") = New Object
        dataRow("Logical_Symbol") = New Object
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
            dt.Columns.Add("Rule_Code")
            dt.Columns.Add("Condition_Type")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Condition_Rule_Code")
            dt.Columns.Add("Logical_Symbol")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            pkColArray(1) = dt.Columns("Condition_Type")
            pkColArray(2) = dt.Columns("Seq_No")
            pkColArray(3) = dt.Columns("Condition_Rule_Code")
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
            dt.Columns.Add("Condition_Type")
            dt.Columns("Condition_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Condition_Rule_Code")
            dt.Columns("Condition_Rule_Code").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            pkColArray(1) = dt.Columns("Condition_Type")
            pkColArray(2) = dt.Columns("Seq_No")
            pkColArray(3) = dt.Columns("Condition_Rule_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
