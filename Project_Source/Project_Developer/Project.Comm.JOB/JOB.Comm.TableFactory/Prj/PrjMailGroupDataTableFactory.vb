Imports System.Data.SqlClient
Public Class PrjMailGroupDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/8/10 下午 04:29:18
    Public Shared ReadOnly tableName as String="PRJ_Mail_Group"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Group_Id", "Group_Name", "Belong_Employee_Code", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time", "Temporary"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 50, 10, 10, -1,   _
             10, -1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PrjMailGroupDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Group_Id") = New Object
        dataRow("Group_Name") = New Object
        dataRow("Belong_Employee_Code") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Temporary") = New Object
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
            dt.Columns.Add("Group_Id")
            dt.Columns.Add("Group_Name")
            dt.Columns.Add("Belong_Employee_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Temporary")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Group_Id")
            pkColArray(1) = dt.Columns("Belong_Employee_Code")
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
            dt.Columns.Add("Group_Id")
            dt.Columns("Group_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Group_Name")
            dt.Columns("Group_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Belong_Employee_Code")
            dt.Columns("Belong_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Temporary")
            dt.Columns("Temporary").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Group_Id")
            pkColArray(1) = dt.Columns("Belong_Employee_Code")
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
            dt.Columns.Add("Group_Id")
            dt.Columns.Add("Group_Name")
            dt.Columns.Add("Belong_Employee_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Temporary")
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

  Class PRJMailGroupPt
    Private m_Group_Id As String = "Group_Id"
    Public ReadOnly Property Group_Id() As System.String 
    Get
        Return m_Group_Id
    End Get
    End Property

    Private m_Group_Name As String = "Group_Name"
    Public ReadOnly Property Group_Name() As System.String 
    Get
        Return m_Group_Name
    End Get
    End Property

    Private m_Belong_Employee_Code As String = "Belong_Employee_Code"
    Public ReadOnly Property Belong_Employee_Code() As System.String 
    Get
        Return m_Belong_Employee_Code
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

    Private m_Temporary As String = "Temporary"
    Public ReadOnly Property Temporary() As System.String 
    Get
        Return m_Temporary
    End Get
    End Property

  End Class

End Class
