Imports System.Data.SqlClient
Public Class PrjProjectDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2018/8/28 上午 10:18:57
    Public Shared ReadOnly tableName as String="PRJ_Project"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Project_ID", "Project_Name", "Start_Date", "End_Date", "Project_Manager",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Project_Status"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.DateTime", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, -1, -1, 10,   _
             10, -1, 10, -1, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PrjProjectDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Project_ID") = New Object
        dataRow("Project_Name") = New Object
        dataRow("Start_Date") = New Object
        dataRow("End_Date") = New Object
        dataRow("Project_Manager") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Project_Status") = New Object
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
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("Project_Name")
            dt.Columns.Add("Start_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Project_Manager")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Project_Status")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Project_ID")
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
            dt.Columns.Add("Project_ID")
            dt.Columns("Project_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Project_Name")
            dt.Columns("Project_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Start_Date")
            dt.Columns("Start_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Project_Manager")
            dt.Columns("Project_Manager").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Project_Status")
            dt.Columns("Project_Status").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Project_ID")
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
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("Project_Name")
            dt.Columns.Add("Start_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Project_Manager")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Project_Status")
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

  Class PRJProjectPt
    Private m_Project_ID As String = "Project_ID"
    Public ReadOnly Property Project_ID() As System.String 
    Get
        Return m_Project_ID
    End Get
    End Property

    Private m_Project_Name As String = "Project_Name"
    Public ReadOnly Property Project_Name() As System.String 
    Get
        Return m_Project_Name
    End Get
    End Property

    Private m_Start_Date As String = "Start_Date"
    Public ReadOnly Property Start_Date() As System.String 
    Get
        Return m_Start_Date
    End Get
    End Property

    Private m_End_Date As String = "End_Date"
    Public ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
    End Get
    End Property

    Private m_Project_Manager As String = "Project_Manager"
    Public ReadOnly Property Project_Manager() As System.String 
    Get
        Return m_Project_Manager
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

    Private m_Project_Status As String = "Project_Status"
    Public ReadOnly Property Project_Status() As System.String 
    Get
        Return m_Project_Status
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_Project_ID As String = "Project_ID"
    Public Shared ReadOnly Property Project_ID() As System.String 
    Get
        Return m_Project_ID
    End Get
    End Property

    Private Shared ReadOnly m_Project_Name As String = "Project_Name"
    Public Shared ReadOnly Property Project_Name() As System.String 
    Get
        Return m_Project_Name
    End Get
    End Property

    Private Shared ReadOnly m_Start_Date As String = "Start_Date"
    Public Shared ReadOnly Property Start_Date() As System.String 
    Get
        Return m_Start_Date
    End Get
    End Property

    Private Shared ReadOnly m_End_Date As String = "End_Date"
    Public Shared ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
    End Get
    End Property

    Private Shared ReadOnly m_Project_Manager As String = "Project_Manager"
    Public Shared ReadOnly Property Project_Manager() As System.String 
    Get
        Return m_Project_Manager
    End Get
    End Property

    Private Shared ReadOnly m_Create_User As String = "Create_User"
    Public Shared ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private Shared ReadOnly m_Create_Time As String = "Create_Time"
    Public Shared ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private Shared ReadOnly m_Modified_User As String = "Modified_User"
    Public Shared ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private Shared ReadOnly m_Modified_Time As String = "Modified_Time"
    Public Shared ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

    Private Shared ReadOnly m_Project_Status As String = "Project_Status"
    Public Shared ReadOnly Property Project_Status() As System.String 
    Get
        Return m_Project_Status
    End Get
    End Property

  End Class

End Class
