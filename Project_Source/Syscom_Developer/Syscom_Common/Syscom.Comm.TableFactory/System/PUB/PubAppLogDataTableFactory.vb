Imports System.Data.SqlClient
Public Class PubAppLogDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_App_Log"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Execution_Time", "Execution_IP", "Employee_Code", "Employee_Name", "System_Code",   _
             "Caller_System_Code", "Query_Item_Id", "Result_Count", "Output_Type", "Output_Target_Name",   _
             "Execution_String"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 39, 10, 10, 5,   _
             5, 5, -1, 1, 500,   _
             4000}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAppLogDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Execution_Time") = New Object
        dataRow("Execution_IP") = New Object
        dataRow("Employee_Code") = New Object
        dataRow("Employee_Name") = New Object
        dataRow("System_Code") = New Object
        dataRow("Caller_System_Code") = New Object
        dataRow("Query_Item_Id") = New Object
        dataRow("Result_Count") = New Object
        dataRow("Output_Type") = New Object
        dataRow("Output_Target_Name") = New Object
        dataRow("Execution_String") = New Object
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
            dt.Columns.Add("Execution_Time")
            dt.Columns.Add("Execution_IP")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Employee_Name")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Caller_System_Code")
            dt.Columns.Add("Query_Item_Id")
            dt.Columns.Add("Result_Count")
            dt.Columns.Add("Output_Type")
            dt.Columns.Add("Output_Target_Name")
            dt.Columns.Add("Execution_String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Execution_Time")
            pkColArray(1) = dt.Columns("Execution_IP")
            pkColArray(2) = dt.Columns("Employee_Code")
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
            dt.Columns.Add("Execution_Time")
            dt.Columns("Execution_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Execution_IP")
            dt.Columns("Execution_IP").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_Code")
            dt.Columns("Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_Name")
            dt.Columns("Employee_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Caller_System_Code")
            dt.Columns("Caller_System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Query_Item_Id")
            dt.Columns("Query_Item_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Result_Count")
            dt.Columns("Result_Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Output_Type")
            dt.Columns("Output_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Output_Target_Name")
            dt.Columns("Output_Target_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Execution_String")
            dt.Columns("Execution_String").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Execution_Time")
            pkColArray(1) = dt.Columns("Execution_IP")
            pkColArray(2) = dt.Columns("Employee_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataTable - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithNoPK() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Execution_Time")
            dt.Columns.Add("Execution_IP")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Employee_Name")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Caller_System_Code")
            dt.Columns.Add("Query_Item_Id")
            dt.Columns.Add("Result_Count")
            dt.Columns.Add("Output_Type")
            dt.Columns.Add("Output_Target_Name")
            dt.Columns.Add("Execution_String")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSet() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTable() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithSchema() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTableWithSchema() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithNoPK() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTableWithNoPK() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

  Class PUBAppLogPt
    Private m_Execution_Time As String = "Execution_Time"
    Public ReadOnly Property Execution_Time() As System.String 
    Get
        Return m_Execution_Time
    End Get
    End Property

    Private m_Execution_IP As String = "Execution_IP"
    Public ReadOnly Property Execution_IP() As System.String 
    Get
        Return m_Execution_IP
    End Get
    End Property

    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Employee_Name As String = "Employee_Name"
    Public ReadOnly Property Employee_Name() As System.String 
    Get
        Return m_Employee_Name
    End Get
    End Property

    Private m_System_Code As String = "System_Code"
    Public ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

    Private m_Caller_System_Code As String = "Caller_System_Code"
    Public ReadOnly Property Caller_System_Code() As System.String 
    Get
        Return m_Caller_System_Code
    End Get
    End Property

    Private m_Query_Item_Id As String = "Query_Item_Id"
    Public ReadOnly Property Query_Item_Id() As System.String 
    Get
        Return m_Query_Item_Id
    End Get
    End Property

    Private m_Result_Count As String = "Result_Count"
    Public ReadOnly Property Result_Count() As System.String 
    Get
        Return m_Result_Count
    End Get
    End Property

    Private m_Output_Type As String = "Output_Type"
    Public ReadOnly Property Output_Type() As System.String 
    Get
        Return m_Output_Type
    End Get
    End Property

    Private m_Output_Target_Name As String = "Output_Target_Name"
    Public ReadOnly Property Output_Target_Name() As System.String 
    Get
        Return m_Output_Target_Name
    End Get
    End Property

    Private m_Execution_String As String = "Execution_String"
    Public ReadOnly Property Execution_String() As System.String 
    Get
        Return m_Execution_String
    End Get
    End Property

  End Class

End Class
