Imports System.Data.SqlClient
Public Class PubOrderStandingDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:51
    Public Shared ReadOnly tableName as String="PUB_Order_Standing"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Dept_Code", "Order_Code", "Service_Start_Time", "Service_End_Time", "Week",   _
             "Consumption_Unit", "Dc", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Int32",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 20, 5, 5, -1,   _
             10, 1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderStandingDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Dept_Code") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Service_Start_Time") = New Object
        dataRow("Service_End_Time") = New Object
        dataRow("Week") = New Object
        dataRow("Consumption_Unit") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Service_Start_Time")
            dt.Columns.Add("Service_End_Time")
            dt.Columns.Add("Week")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Order_Code")
            pkColArray(2) = dt.Columns("Service_Start_Time")
            pkColArray(3) = dt.Columns("Service_End_Time")
            pkColArray(4) = dt.Columns("Week")
            pkColArray(5) = dt.Columns("Consumption_Unit")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Service_Start_Time")
            dt.Columns("Service_Start_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Service_End_Time")
            dt.Columns("Service_End_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Week")
            dt.Columns("Week").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns("Consumption_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Order_Code")
            pkColArray(2) = dt.Columns("Service_Start_Time")
            pkColArray(3) = dt.Columns("Service_End_Time")
            pkColArray(4) = dt.Columns("Week")
            pkColArray(5) = dt.Columns("Consumption_Unit")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Service_Start_Time")
            dt.Columns.Add("Service_End_Time")
            dt.Columns.Add("Week")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
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

  Class PUBOrderStandingPt
    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Service_Start_Time As String = "Service_Start_Time"
    Public ReadOnly Property Service_Start_Time() As System.String 
    Get
        Return m_Service_Start_Time
    End Get
    End Property

    Private m_Service_End_Time As String = "Service_End_Time"
    Public ReadOnly Property Service_End_Time() As System.String 
    Get
        Return m_Service_End_Time
    End Get
    End Property

    Private m_Week As String = "Week"
    Public ReadOnly Property Week() As System.String 
    Get
        Return m_Week
    End Get
    End Property

    Private m_Consumption_Unit As String = "Consumption_Unit"
    Public ReadOnly Property Consumption_Unit() As System.String 
    Get
        Return m_Consumption_Unit
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

    Private m_Create_User As String = "Create_User"
    Public ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private m_Create_Time As String = "Create_Time"
    Public ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private m_Modified_User As String = "Modified_User"
    Public ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private m_Modified_Time As String = "Modified_Time"
    Public ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

  End Class

End Class
