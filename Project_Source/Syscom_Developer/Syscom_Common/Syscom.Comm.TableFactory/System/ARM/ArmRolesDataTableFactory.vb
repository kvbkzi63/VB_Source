Imports System.Data.SqlClient
Public Class ArmRolesDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:14
    Public Shared ReadOnly tableName as String="ARM_Roles"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Employee_Code", "Role", "Update_User", "Update_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmRolesDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Employee_Code") = New Object
        dataRow("Role") = New Object
        dataRow("Update_User") = New Object
        dataRow("Update_Time") = New Object
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
            dt.Columns.Add("Role")
            dt.Columns.Add("Update_User")
            dt.Columns.Add("Update_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Role")
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
            dt.Columns.Add("Role")
            dt.Columns("Role").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Update_User")
            dt.Columns("Update_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Update_Time")
            dt.Columns("Update_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Role")
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
            dt.Columns.Add("Role")
            dt.Columns.Add("Update_User")
            dt.Columns.Add("Update_Time")
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

  Class ARMRolesPt
    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Role As String = "Role"
    Public ReadOnly Property Role() As System.String 
    Get
        Return m_Role
    End Get
    End Property

    Private m_Update_User As String = "Update_User"
    Public ReadOnly Property Update_User() As System.String 
    Get
        Return m_Update_User
    End Get
    End Property

    Private m_Update_Time As String = "Update_Time"
    Public ReadOnly Property Update_Time() As System.String 
    Get
        Return m_Update_Time
    End Get
    End Property

  End Class

End Class
