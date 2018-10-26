Imports System.Data.SqlClient
Public Class PubRuleTransactionLogDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2013/11/26 上午 11:19:05
    Public Shared ReadOnly tableName as String="PUB_Rule_Transaction_Log"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rule_Code", "Transaction_Date", "Rule_Name", "Maintain_Value_Str", "Check_Condition",   _
             "Transaction_Mode", "Transaction_User"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String",   _
             "System.Int16", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, -1, 1000, 4000, 4000,   _
             -1, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubRuleTransactionLogDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rule_Code") = New Object
        dataRow("Transaction_Date") = New Object
        dataRow("Rule_Name") = New Object
        dataRow("Maintain_Value_Str") = New Object
        dataRow("Check_Condition") = New Object
        dataRow("Transaction_Mode") = New Object
        dataRow("Transaction_User") = New Object
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
            dt.Columns.Add("Transaction_Date")
            dt.Columns.Add("Rule_Name")
            dt.Columns.Add("Maintain_Value_Str")
            dt.Columns.Add("Check_Condition")
            dt.Columns.Add("Transaction_Mode")
            dt.Columns.Add("Transaction_User")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            pkColArray(1) = dt.Columns("Transaction_Date")
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
            dt.Columns.Add("Transaction_Date")
            dt.Columns("Transaction_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Rule_Name")
            dt.Columns("Rule_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Maintain_Value_Str")
            dt.Columns("Maintain_Value_Str").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Check_Condition")
            dt.Columns("Check_Condition").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transaction_Mode")
            dt.Columns("Transaction_Mode").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("Transaction_User")
            dt.Columns("Transaction_User").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            pkColArray(1) = dt.Columns("Transaction_Date")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
