Imports System.Data.SqlClient
Public Class ArmLogonInfoDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_Logon_Info"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "App_System_No", "Machine_Name", "IP_Address", "Employee_Code", "Agent_Employee_Code",   _
             "Login_Date", "Logout_Date"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, 39, 8, 8,   _
             -1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmLogonInfoDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("App_System_No") = New Object
        dataRow("Machine_Name") = New Object
        dataRow("IP_Address") = New Object
        dataRow("Employee_Code") = New Object
        dataRow("Agent_Employee_Code") = New Object
        dataRow("Login_Date") = New Object
        dataRow("Logout_Date") = New Object
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
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Machine_Name")
            dt.Columns.Add("IP_Address")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Agent_Employee_Code")
            dt.Columns.Add("Login_Date")
            dt.Columns.Add("Logout_Date")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("App_System_No")
            pkColArray(1) = dt.Columns("Machine_Name")
            pkColArray(2) = dt.Columns("IP_Address")
            pkColArray(3) = dt.Columns("Employee_Code")
            pkColArray(4) = dt.Columns("Agent_Employee_Code")
            pkColArray(5) = dt.Columns("Login_Date")
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
            dt.Columns.Add("App_System_No")
            dt.Columns("App_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Machine_Name")
            dt.Columns("Machine_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("IP_Address")
            dt.Columns("IP_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_Code")
            dt.Columns("Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Agent_Employee_Code")
            dt.Columns("Agent_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Login_Date")
            dt.Columns("Login_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Logout_Date")
            dt.Columns("Logout_Date").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("App_System_No")
            pkColArray(1) = dt.Columns("Machine_Name")
            pkColArray(2) = dt.Columns("IP_Address")
            pkColArray(3) = dt.Columns("Employee_Code")
            pkColArray(4) = dt.Columns("Agent_Employee_Code")
            pkColArray(5) = dt.Columns("Login_Date")
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
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Machine_Name")
            dt.Columns.Add("IP_Address")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Agent_Employee_Code")
            dt.Columns.Add("Login_Date")
            dt.Columns.Add("Logout_Date")
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

  Class ARMLogonInfoPt
    Private m_App_System_No As String = "App_System_No"
    Public ReadOnly Property App_System_No() As System.String 
    Get
        Return m_App_System_No
    End Get
    End Property

    Private m_Machine_Name As String = "Machine_Name"
    Public ReadOnly Property Machine_Name() As System.String 
    Get
        Return m_Machine_Name
    End Get
    End Property

    Private m_IP_Address As String = "IP_Address"
    Public ReadOnly Property IP_Address() As System.String 
    Get
        Return m_IP_Address
    End Get
    End Property

    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Agent_Employee_Code As String = "Agent_Employee_Code"
    Public ReadOnly Property Agent_Employee_Code() As System.String 
    Get
        Return m_Agent_Employee_Code
    End Get
    End Property

    Private m_Login_Date As String = "Login_Date"
    Public ReadOnly Property Login_Date() As System.String 
    Get
        Return m_Login_Date
    End Get
    End Property

    Private m_Logout_Date As String = "Logout_Date"
    Public ReadOnly Property Logout_Date() As System.String 
    Get
        Return m_Logout_Date
    End Get
    End Property

  End Class

End Class
