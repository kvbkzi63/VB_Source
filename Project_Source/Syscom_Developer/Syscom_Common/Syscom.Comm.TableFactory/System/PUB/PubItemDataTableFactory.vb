Imports System.Data.SqlClient
Public Class PubItemDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:59:09
    Public Shared ReadOnly tableName as String="PUB_Item"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Item_Code", "Item_Name", "Use_Type", "Data_Type", "Class_Code",   _
             "Field_Code", "Program_Code", "Method_Code", "Item_Param", "Value_Source_Type",   _
             "Value_Source_Program", "Unit_Exchange_Program", "Return_Checking_Flag", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 100, 3, 5, 5,   _
             50, 50, 50, 60, 1,   _
             500, 50, 1, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubItemDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Item_Code") = New Object
        dataRow("Item_Name") = New Object
        dataRow("Use_Type") = New Object
        dataRow("Data_Type") = New Object
        dataRow("Class_Code") = New Object
        dataRow("Field_Code") = New Object
        dataRow("Program_Code") = New Object
        dataRow("Method_Code") = New Object
        dataRow("Item_Param") = New Object
        dataRow("Value_Source_Type") = New Object
        dataRow("Value_Source_Program") = New Object
        dataRow("Unit_Exchange_Program") = New Object
        dataRow("Return_Checking_Flag") = New Object
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
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Item_Name")
            dt.Columns.Add("Use_Type")
            dt.Columns.Add("Data_Type")
            dt.Columns.Add("Class_Code")
            dt.Columns.Add("Field_Code")
            dt.Columns.Add("Program_Code")
            dt.Columns.Add("Method_Code")
            dt.Columns.Add("Item_Param")
            dt.Columns.Add("Value_Source_Type")
            dt.Columns.Add("Value_Source_Program")
            dt.Columns.Add("Unit_Exchange_Program")
            dt.Columns.Add("Return_Checking_Flag")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Item_Code")
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
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Name")
            dt.Columns("Item_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Use_Type")
            dt.Columns("Use_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Data_Type")
            dt.Columns("Data_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Class_Code")
            dt.Columns("Class_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Code")
            dt.Columns("Field_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Program_Code")
            dt.Columns("Program_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Method_Code")
            dt.Columns("Method_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Param")
            dt.Columns("Item_Param").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Value_Source_Type")
            dt.Columns("Value_Source_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Value_Source_Program")
            dt.Columns("Value_Source_Program").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unit_Exchange_Program")
            dt.Columns("Unit_Exchange_Program").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Return_Checking_Flag")
            dt.Columns("Return_Checking_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Item_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
