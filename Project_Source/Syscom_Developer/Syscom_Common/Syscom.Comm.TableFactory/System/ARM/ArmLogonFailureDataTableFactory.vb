Imports System.Data.SqlClient
Public Class ArmLogonFailureDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_Logon_Failure"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Employee_Code", "Login_Try_Date", "Login_Try_Times", "Machine_Name", "IP_Address"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.Int32", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             8, -1, -1, 20, 39  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmLogonFailureDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Employee_Code") = New Object
        dataRow("Login_Try_Date") = New Object
        dataRow("Login_Try_Times") = New Object
        dataRow("Machine_Name") = New Object
        dataRow("IP_Address") = New Object
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
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Login_Try_Date")
            dt.Columns.Add("Login_Try_Times")
            dt.Columns.Add("Machine_Name")
            dt.Columns.Add("IP_Address")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Login_Try_Date")
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
            dt.Columns.Add("Employee_Code")
            dt.Columns("Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Login_Try_Date")
            dt.Columns("Login_Try_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Login_Try_Times")
            dt.Columns("Login_Try_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Machine_Name")
            dt.Columns("Machine_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("IP_Address")
            dt.Columns("IP_Address").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Login_Try_Date")
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
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Login_Try_Date")
            dt.Columns.Add("Login_Try_Times")
            dt.Columns.Add("Machine_Name")
            dt.Columns.Add("IP_Address")
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

  Class ARMLogonFailurePt
    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Login_Try_Date As String = "Login_Try_Date"
    Public ReadOnly Property Login_Try_Date() As System.String 
    Get
        Return m_Login_Try_Date
    End Get
    End Property

    Private m_Login_Try_Times As String = "Login_Try_Times"
    Public ReadOnly Property Login_Try_Times() As System.String 
    Get
        Return m_Login_Try_Times
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

  End Class

End Class
