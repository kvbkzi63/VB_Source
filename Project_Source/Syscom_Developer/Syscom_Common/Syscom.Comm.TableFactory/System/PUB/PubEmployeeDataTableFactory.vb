Imports System.Data.SqlClient
Public Class PubEmployeeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Employee"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Employee_Code", "Assume_Effect_Date", "Employee_Name", "Employee_En_Name", "Idno",   _
             "Assume_End_Date", "Professal_Kind_Id", "Emp_Status_Id", "Dept_Code", "Acc_Dept",   _
             "Email", "Tel_Mobile", "Nrs_Level_Id", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 20, 40, 20,   _
             -1, 5, 5, 6, 6,   _
             50, 20, 5, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubEmployeeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Employee_Code") = New Object
        dataRow("Assume_Effect_Date") = New Object
        dataRow("Employee_Name") = New Object
        dataRow("Employee_En_Name") = New Object
        dataRow("Idno") = New Object
        dataRow("Assume_End_Date") = New Object
        dataRow("Professal_Kind_Id") = New Object
        dataRow("Emp_Status_Id") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Acc_Dept") = New Object
        dataRow("Email") = New Object
        dataRow("Tel_Mobile") = New Object
        dataRow("Nrs_Level_Id") = New Object
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
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Assume_Effect_Date")
            dt.Columns.Add("Employee_Name")
            dt.Columns.Add("Employee_En_Name")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Assume_End_Date")
            dt.Columns.Add("Professal_Kind_Id")
            dt.Columns.Add("Emp_Status_Id")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Acc_Dept")
            dt.Columns.Add("Email")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns.Add("Nrs_Level_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
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
            dt.Columns.Add("Assume_Effect_Date")
            dt.Columns("Assume_Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Employee_Name")
            dt.Columns("Employee_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_En_Name")
            dt.Columns("Employee_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Assume_End_Date")
            dt.Columns("Assume_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Professal_Kind_Id")
            dt.Columns("Professal_Kind_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emp_Status_Id")
            dt.Columns("Emp_Status_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Dept")
            dt.Columns("Acc_Dept").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Email")
            dt.Columns("Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns("Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nrs_Level_Id")
            dt.Columns("Nrs_Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
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
            dt.Columns.Add("Assume_Effect_Date")
            dt.Columns.Add("Employee_Name")
            dt.Columns.Add("Employee_En_Name")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Assume_End_Date")
            dt.Columns.Add("Professal_Kind_Id")
            dt.Columns.Add("Emp_Status_Id")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Acc_Dept")
            dt.Columns.Add("Email")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns.Add("Nrs_Level_Id")
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

  Class PUBEmployeePt
    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Assume_Effect_Date As String = "Assume_Effect_Date"
    Public ReadOnly Property Assume_Effect_Date() As System.String 
    Get
        Return m_Assume_Effect_Date
    End Get
    End Property

    Private m_Employee_Name As String = "Employee_Name"
    Public ReadOnly Property Employee_Name() As System.String 
    Get
        Return m_Employee_Name
    End Get
    End Property

    Private m_Employee_En_Name As String = "Employee_En_Name"
    Public ReadOnly Property Employee_En_Name() As System.String 
    Get
        Return m_Employee_En_Name
    End Get
    End Property

    Private m_Idno As String = "Idno"
    Public ReadOnly Property Idno() As System.String 
    Get
        Return m_Idno
    End Get
    End Property

    Private m_Assume_End_Date As String = "Assume_End_Date"
    Public ReadOnly Property Assume_End_Date() As System.String 
    Get
        Return m_Assume_End_Date
    End Get
    End Property

    Private m_Professal_Kind_Id As String = "Professal_Kind_Id"
    Public ReadOnly Property Professal_Kind_Id() As System.String 
    Get
        Return m_Professal_Kind_Id
    End Get
    End Property

    Private m_Emp_Status_Id As String = "Emp_Status_Id"
    Public ReadOnly Property Emp_Status_Id() As System.String 
    Get
        Return m_Emp_Status_Id
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Acc_Dept As String = "Acc_Dept"
    Public ReadOnly Property Acc_Dept() As System.String 
    Get
        Return m_Acc_Dept
    End Get
    End Property

    Private m_Email As String = "Email"
    Public ReadOnly Property Email() As System.String 
    Get
        Return m_Email
    End Get
    End Property

    Private m_Tel_Mobile As String = "Tel_Mobile"
    Public ReadOnly Property Tel_Mobile() As System.String 
    Get
        Return m_Tel_Mobile
    End Get
    End Property

    Private m_Nrs_Level_Id As String = "Nrs_Level_Id"
    Public ReadOnly Property Nrs_Level_Id() As System.String 
    Get
        Return m_Nrs_Level_Id
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
